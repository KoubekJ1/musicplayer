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
	public partial class AlbumSongListControl : UserControl
	{
		private Album _album;

		public AlbumSongListControl(Album album)
		{
			InitializeComponent();
			_album = album;

			if (album.Songs.Count <= 0 && album.Id != null)
			{
				album.Songs = new SongDAO().GetSongsFromAlbum((int)album.Id);
			}

			foreach (Song song in album.Songs)
			{
				SongControl songControl = new SongControl(song);
				flpSongs.Controls.Add(songControl);
			}
		}
	}
}
