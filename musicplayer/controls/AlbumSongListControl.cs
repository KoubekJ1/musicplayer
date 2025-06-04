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

			lAlbumName.Text = album.Name;
			lArtistName.Text = album.Artist != null ? album.Artist.Name : "Unknown artist";
			pbAlbumImage.Image = album.Image != null ? IconImage.ResizeImage(album.Image.Image, pbAlbumImage.Width, pbAlbumImage.Height) : null;

			if (album.Songs.Count <= 0 && album.Id != null)
			{
				album.Songs = new SongDAO().GetSongsFromAlbum((int)album.Id);
			}

			foreach (Song song in album.Songs)
			{
				song.Album = _album;
				SongControl songControl = new SongControl(song);
				flpSongs.Controls.Add(songControl);
			}
		}
	}
}
