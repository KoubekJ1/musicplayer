using musicplayer.controls;
using musicplayer.dataobjects;
using NAudio.Wave;
using System;
using System.Collections.Generic;
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
		private Task? _updateProgressBarTask;
		private AudioPlayerManager()
		{
		}

		public void PlayAudio(byte[] data, bool replace)
		{
			if (_outputDevice != null)
			{
				if (!replace) return;
				//_outputDevice.Stop();
				_outputDevice.Dispose();
			}
			_outputDevice = new WaveOutEvent();

			MemoryStream memoryStream = new MemoryStream(data);

			_fileReader = new Mp3FileReader(memoryStream);
			//memoryStream.Close();
			_outputDevice.Init(_fileReader);

			_outputDevice.PlaybackStopped += OnPlaybackStopped;

			_updateProgressBarTask = Task.Run(UpdateProgressBarTask);
			_outputDevice.Play();

		}

		public void Stop()
		{
			_outputDevice?.Stop();
		}
		public void Dispose()
		{
			_outputDevice?.Dispose();
			_fileReader?.Dispose();
			_updateProgressBarTask?.Dispose();
		}

		private void OnPlaybackStopped(object? sender, EventArgs args)
		{
			Dispose();
		}

		private void UpdateProgressBarTask()
		{
			if (_outputDevice == null || _fileReader == null) return;
			while (true)
			{
				PlayerControl.GetPlayerControl().SetProgress(_outputDevice.GetPosition() / (float)_fileReader.Length);
				Thread.Sleep(1000);
			}
		}
	}
}
