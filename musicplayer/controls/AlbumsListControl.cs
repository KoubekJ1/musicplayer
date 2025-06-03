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

namespace musicplayer
{
	public partial class AlbumsListControl : UserControl
	{
		private Artist _artist;
		private Control _artistContentControl;

		public AlbumsListControl(Artist artist, Control artistContentControl)
		{
			InitializeComponent();
			_artist = artist;
			_artistContentControl = artistContentControl;
			try
			{
				artist.LoadAlbums();
			}
			catch (Exception ex)
			{
				ErrorHandler.HandleException(ex, "Unable to load albums", "Unable to load artist albums due to an internal server error.");
				return;
			}
			foreach (Album album in artist.Albums)
			{
				flpAlbs.Controls.Add(new AlbumDisplayControl(album, artistContentControl));
			}
		}
	}
}
