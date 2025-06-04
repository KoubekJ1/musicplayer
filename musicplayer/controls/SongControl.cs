using musicplayer.dao;
using musicplayer.dataobjects;
using musicplayer.forms;
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
		private Control _artistContentControl;

		public SongControl(Song song, Control artistContentControl)
		{
			InitializeComponent();
			this._song = song;
			this._artistContentControl = artistContentControl;
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

		private void bEdit_Click(object sender, EventArgs e)
		{
			var form = new AddSongForm(_song);
			form.ShowDialog();
			_artistContentControl.Controls.Clear();
		}

		private void bDelete_Click(object sender, EventArgs e)
		{
			if (MessageBox.Show("Are you sure you wish to delete \"" + _song.Name + "\" from the database?", "Delete", MessageBoxButtons.YesNo) != DialogResult.Yes) return;
			if (_song.Id == null)
			{
				MessageBox.Show("Song has not been uploaded to the database", "Error");
				return;
			}

			SongDAO songDAO = new SongDAO();
			try
			{
				songDAO.Remove((int)_song.Id);
				MessageBox.Show("Song \"" + _song.Name + "\" successfully deleted.", "Delete");
				_artistContentControl.Controls.Clear();
			}
			catch (Exception ex)
			{
				ErrorHandler.HandleException(ex, "Error", "Unable to delete song from the database.");
			}
		}
	}
}
