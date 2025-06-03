using musicplayer.dao;
using musicplayer.dataobjects;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace musicplayer.controls
{
	public partial class SongControl : UserControl
	{
		private Song _song;

		public SongControl(Song song)
		{
			InitializeComponent();
			this._song = song;
			int minutes = song.Length / 60;
			int seconds = song.Length - minutes * 60;
			lSongName.Text = song.Name;
			lLength.Text = minutes + ":" + (seconds < 10 ? "0" : "") + seconds;
		}

		private void bPlay_Click(object sender, EventArgs e)
		{
			AudioPlayerManager.GetPlayerManager().Clear();
			if (!_song.PlaySong(true)) MessageBox.Show("Unable to load song data!", "Error");
			if (_song.Album == null) return;
			for (int i = _song.Album.Songs.IndexOf(_song) + 1; i < _song.Album.Songs.Count; i++)
			{
				AudioPlayerManager.GetPlayerManager().AddToQueue(_song.Album.Songs[i]);
			}
			for (int i = _song.Album.Songs.IndexOf(_song) - 1; i >= 0; i--)
			{
				AudioPlayerManager.GetPlayerManager().AddToHistory(_song.Album.Songs[i]);
			}
		}
	}
}
