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
		private Control _artistContentControl;
		private IEnumerable<Album> _albums;

		public AlbumsListControl(IEnumerable<Album> albums, Control artistContentControl)
		{
			InitializeComponent();
			_albums = albums;
			_artistContentControl = artistContentControl;
			SetAlbums(albums, artistContentControl);			
		}

		public void SetAlbums(IEnumerable<Album> albums, Control artistContentControl)
		{
			flpAlbs.Controls.Clear();
			foreach (Album album in albums)
			{
				flpAlbs.Controls.Add(new AlbumDisplayControl(album, artistContentControl));
			}
		}

		private void tbSearch_TextChanged(object sender, EventArgs e)
		{
			SetAlbums(_albums.Where(alb => alb.Name.IndexOf(tbSearch.Text, StringComparison.OrdinalIgnoreCase) >= 0), _artistContentControl);
		}
	}
}
