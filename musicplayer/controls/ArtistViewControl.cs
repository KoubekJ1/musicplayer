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
			if (MessageBox.Show("Are you sure you wish to delete \"" + _artist.Name + "\" from the database?", "Delete", MessageBoxButtons.YesNo) != DialogResult.Yes) return;
			if (_artist.Id == null)
			{
				MessageBox.Show("Artist has not been uploaded to the database", "Error");
				return;
			}

			ArtistDAO dao = new ArtistDAO();
			try
			{
				dao.Remove((int)_artist.Id);
				MessageBox.Show("Artist \"" + _artist.Name + "\" successfully deleted.", "Delete");
				_artistsControl.Controls.Clear();
			}
			catch (Exception ex)
			{
				ErrorHandler.HandleException(ex, "Error", "Unable to delete artist from the database.");
			}
		}
	}
}
