using musicplayer.controls;
using musicplayer.dao;
using musicplayer.dataobjects;
using NAudio.Wave;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace musicplayer
{
	public class AudioPlayerManager
	{
		private static AudioPlayerManager? s_instance;
		private static object s_instanceLock = new object();
		public static AudioPlayerManager GetPlayerManager()
		{
			lock (s_instanceLock)
			{
				if (s_instance == null) s_instance = new AudioPlayerManager();
				return s_instance;
			}
		}
		public static int? GetDuration(byte[] data)
		{
			MemoryStream memoryStream = new MemoryStream(data);
			return (int)Math.Ceiling(new Mp3FileReader(memoryStream).TotalTime.TotalSeconds);
		}

		private WaveOutEvent? _outputDevice;
		private Mp3FileReader? _fileReader;
		private MemoryStream? _stream;
		private float volume;

		private Queue<Song> _songQueue;
		private Queue<Song> _songHistory;
		private AudioPlayerManager()
		{
			volume = 1.0f;
			_songQueue = new Queue<Song>();
			_songHistory = new Queue<Song>();
		}

		public bool PlaySong(Song song, bool replace = true)
		{
			if (song.Data == null && song.DataID == null) return false;
			if (song.Data == null)
			{
				song.Data = new SongDAO().GetSongData((int)song.DataID);
			}
			_songHistory.Enqueue(song);

			PlayerControl.GetPlayerControl().SongName = song.Name;
			if (song.Album?.Artist != null) PlayerControl.GetPlayerControl().ArtistName = song.Album.Artist.Name;
			PlayAudio(song.Data, replace);
			song.Data = null;
			return true;
		}

		public void AddToQueue(Song song)
		{
			_songQueue.Enqueue(song);
		}

		public void AddToHistory(Song song)
		{
			_songHistory.Enqueue(song);
		}

		public void ClearQueue()
		{
			_songQueue.Clear();
		}

		public void PlayAudio(byte[] data, bool replace)
		{
			if (_outputDevice != null)
			{
				if (!replace) return;
				//_outputDevice.Stop();
				Dispose();
			}
			_outputDevice = new WaveOutEvent();

			_stream = new MemoryStream(data);
			//_paused = false;

			_fileReader = new Mp3FileReader(_stream);
			_outputDevice.Init(_fileReader);

			_outputDevice.PlaybackStopped += OnPlaybackStopped;
			_outputDevice.Volume = volume;

			_outputDevice.Play();

			PlayerControl.GetPlayerControl().Enable();
		}

		public void Stop()
		{
			_outputDevice?.Stop();
		}

		public void Next()
		{
			Stop();
			PlayNextSong();
		}

		public void Back()
		{
			if (_songHistory.Count < 1) return;
			Stop();
			if (Progress > 0.1)
			{
				PlaySong(_songHistory.Dequeue());
			}
			else
			{
				if (_songHistory.Count < 2) Clear();
				else
				{
					_songQueue.Enqueue(_songHistory.Dequeue());
					PlaySong(_songHistory.Dequeue());
				}
			}
		}

		public void Dispose()
		{
			_outputDevice?.Dispose();
			_fileReader?.Dispose();
			_stream?.Close();
		}

		private void Clear()
		{
			Dispose();
			_songQueue?.Clear();
			_songHistory?.Clear();
			PlayerControl.GetPlayerControl().Disable();
		}

		public float Progress
		{
			get
			{
				if (_outputDevice == null || _fileReader == null) return 0;
				try
				{
					return _fileReader.Position / (float)_fileReader.Length;
				}
				catch
				{
					return 0;
				}
			}

			set
			{
				if (_outputDevice == null || _fileReader == null) return;
				_fileReader.Position = (long)(_fileReader.Length * value);
			}
		}

		public float Volume
		{
			get
			{
				return volume;
			}
			set
			{
				volume = value;
				if (_outputDevice != null) _outputDevice.Volume = volume;
			}
		}

		private void PlayNextSong()
		{
			Dispose();
			Song? song;
			bool calledBreak = false;
			while (_songQueue.TryDequeue(out song))
			{
				if (song != null && PlaySong(song, true))
				{
					calledBreak = true;
					break;
				}
			}
			if (!calledBreak)
			{
				Clear();
			}
		}

		private void OnPlaybackStopped(object? sender, EventArgs args)
		{
			if (Progress >= 1)
			{
				PlayNextSong();
			}
		}
	}
}
