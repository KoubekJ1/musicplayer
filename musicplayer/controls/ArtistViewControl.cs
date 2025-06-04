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
	public partial class ArtistViewControl : UserControl
	{
		private Artist _artist;
		private Control _artistsControl;
		private Control _artistContentControl;

		public ArtistViewControl(Artist artist, Control artistsControl, Control artistContentControl)
		{
			InitializeComponent();

			_artist = artist;
			_artistsControl = artistsControl;
			_artistContentControl = artistContentControl;

			lArtistName.Text = artist.Name;
			if (_artist.Image != null) pbImage.Image = IconImage.ResizeImage(artist.Image.Image, pbImage.Width, pbImage.Height);

			AlbumsListControl control = new AlbumsListControl(_artist.Albums, artistContentControl);
			pAlbumlist.Controls.Add(control);
		}

		private void bEdit_Click(object sender, EventArgs e)
		{
			AddArtistForm addArtistForm = new AddArtistForm(_artist);
			addArtistForm.ShowDialog();
			_artistsControl.Controls.Clear();
		}

		private void bDelete_Click(object sender, EventArgs e)
		{
			
		}
	}
}
