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
		private static AudioPlayerManager s_instance;
		private static object s_instanceLock = new object();
		public static AudioPlayerManager GetPlayerManager()
		{
			lock (s_instanceLock)
			{
				if (s_instance == null) s_instance = new AudioPlayerManager();
				return s_instance;
			}
		}

		public void PlayAudio(byte[] data, bool replace)
		{
			if (_outputDevice != null)
			{
				if (replace) return;
				_outputDevice.Dispose();
			}

			_outputDevice = new WaveOutEvent();

			MemoryStream memoryStream = new MemoryStream(data);
			/*RawSourceWaveStream waveStream = new RawSourceWaveStream(memoryStream, new WaveFormat(44100, 16, 2));
			_outputDevice.Init(waveStream);*/

			/*AudioFileReader reader = new AudioFileReader(@"e:\Development\VS2022\musicplayer\you wont see me.mp3");
			_outputDevice.Init(reader);*/

			Mp3FileReader reader = new Mp3FileReader(memoryStream);
			_outputDevice.Init(reader);

			_outputDevice.Play();

			while (_outputDevice.PlaybackState == PlaybackState.Playing)
			{
				Thread.Sleep(1000);
			}

			_outputDevice.Dispose();
		}

		public static int? GetDuration(byte[] data)
		{
			MemoryStream memoryStream = new MemoryStream(data);
			return (int)Math.Ceiling(new Mp3FileReader(memoryStream).TotalTime.TotalSeconds);
		}

		private WaveOutEvent _outputDevice;

		private AudioPlayerManager()
		{
		}
	}
}
