using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace musicplayer.controls
{
	public partial class PlayerControl : UserControl
	{
		private static PlayerControl? s_instance;
		private static object s_instanceLock = new object();

		private const string NO_SONG_TEXT = "(no song playing)";
		private const string NO_ARTIST_TEXT = "(no artist playing)";

		public static PlayerControl GetPlayerControl()
		{
			lock (s_instanceLock)
			{
				if (s_instance == null) s_instance = new PlayerControl();
				return s_instance;
			}
		}

		private System.Windows.Forms.Timer timer;

		private PlayerControl()
		{
			InitializeComponent();
			timer = new System.Windows.Forms.Timer();
			timer.Interval = 1000;
			timer.Tick += ProgressBarTimerTick;
			Disable();
		}

		public string SongName
		{
			get => lSongName.Text;
			set => lSongName.Text = value;
		}

		public string ArtistName
		{
			get => lArtist.Text;
			set => lArtist.Text = value;
		}

		public void Enable()
		{
			bBack.Enabled = true;
			bPlayPause.Enabled = true;
			bNext.Enabled = true;

			trbProgress.Enabled = true;

			lSongName.Enabled = true;
			lArtist.Enabled = true;

			StartTimer();
		}

		public void Disable()
		{
			bBack.Enabled = false;
			bPlayPause.Enabled = false;
			bNext.Enabled = false;

			trbProgress.Enabled = false;
			trbProgress.Value = 0;

			lSongName.Enabled = false;
			lSongName.Text = NO_SONG_TEXT;
			lArtist.Enabled = false;
			lArtist.Text = NO_ARTIST_TEXT;

			StopTimer();
		}

		private void StartTimer()
		{
			timer.Start();
		}

		private void StopTimer()
		{
			timer.Stop();
		}

		private void SetProgress(float progress)
		{
			if (progress > 1 || progress < 0) return;
			trbProgress.Value = (int)(progress * trbProgress.Maximum);
		}

		private void ProgressBarTimerTick(object? source, EventArgs args)
		{
			SetProgress(AudioPlayerManager.GetPlayerManager().Progress);
		}

		private void trbProgress_Scroll(object sender, EventArgs e)
		{
			StopTimer();
			AudioPlayerManager.GetPlayerManager().Progress = trbProgress.Value / 100.0f;
			StartTimer();
		}

		private void trbVolume_Scroll(object sender, EventArgs e)
		{
			AudioPlayerManager.GetPlayerManager().Volume = trbVolume.Value / 100.0f;
		}

		private void bBack_Click(object sender, EventArgs e)
		{
			AudioPlayerManager.GetPlayerManager().Back();
		}

		private void bNext_Click(object sender, EventArgs e)
		{
			AudioPlayerManager.GetPlayerManager().Next();
		}
	}
}
