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

namespace musicplayer
{
	public partial class AddAlbumForm : Form
	{
		Artist? _artist;

		public AddAlbumForm()
		{
			InitializeComponent();
			this.FormBorderStyle = FormBorderStyle.FixedSingle;
		}

		private void bChange_Click(object sender, EventArgs e)
		{
			OpenFileDialog dialog = new OpenFileDialog();
			dialog.Filter = "All files (*.*)|*.*|JPEG (*.jpeg)|*.jpeg|PNG (*.png)|*.png|Bitmap (*.bmp)|*.bmp";
			if (dialog.ShowDialog() != DialogResult.OK) return;
			try
			{
				pbImage.Image = IconImage.ResizeImage(new Bitmap(dialog.FileName), 256, 256);
				pbImage.SizeMode = PictureBoxSizeMode.StretchImage;
			}
			catch (Exception ex)
			{
				ErrorHandler.HandleException(ex, "Unable to load image: " + dialog.FileName, "Error");
				return;
			}
		}

		private void bAddAlbum_Click(object sender, EventArgs e)
		{
			Album album = new Album(tbName.Text);
			Bitmap? bitmap = pbImage.Image as Bitmap;
			if (bitmap != null)
			{
				album.Image = new IconImage(bitmap);
			}
			foreach (var listBoxItem in lbSongs.Items)
			{
				Song? song = listBoxItem as Song;
				if (song == null) continue;
				album.Songs.Add(song);
			}
		}

		private void bClickArtist_Click(object sender, EventArgs e)
		{
			ArtistPicker picker = new ArtistPicker();
			picker.ShowDialog();
			_artist = picker.Artist;
			if (_artist != null) lArtistName.Text = _artist.ToString();
		}
	}
}
