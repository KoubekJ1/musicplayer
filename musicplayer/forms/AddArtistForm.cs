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

namespace musicplayer
{
	public partial class AddArtistForm : Form
	{
		private Artist _artist;

		public Artist Artist { get => _artist; }

		public AddArtistForm()
		{
			InitializeComponent();
			this.FormBorderStyle = FormBorderStyle.FixedSingle;

			_artist = new Artist("");
		}

		public AddArtistForm(Artist artist)
		{
			InitializeComponent();
			this.FormBorderStyle = FormBorderStyle.FixedSingle;

			_artist = artist;
			tbName.Text = artist.Name;
			if (_artist.Image != null) pbImage.Image = IconImage.ResizeImage(_artist.Image.Image, pbImage.Width, pbImage.Height);
		}

		private void bChangeImage_Click(object sender, EventArgs e)
		{
			OpenFileDialog dialog = new OpenFileDialog();
			dialog.Filter = "All files (*.*)|*.*|JPEG (*.jpeg)|*.jpeg|PNG (*.png)|*.png|Bitmap (*.bmp)|*.bmp";
			if (dialog.ShowDialog() != DialogResult.OK) return;
			try
			{
				_artist.Image = new IconImage(new Bitmap(dialog.FileName));
				pbImage.Image = IconImage.ResizeImage(new Bitmap(dialog.FileName), pbImage.Width, pbImage.Height);
				pbImage.SizeMode = PictureBoxSizeMode.StretchImage;
			}
			catch (Exception ex)
			{
				MessageBox.Show("Unable to load image: " + dialog.FileName, "Error");
				return;
			}
		}

		private void bAdd_Click(object sender, EventArgs e)
		{
			try
			{
				new ArtistDAO().Upload(_artist);
				MessageBox.Show("Artist " + _artist.Name + " added successfully", _artist.Name);
				this.Close();
			}
			catch (Exception ex)
			{
				ErrorHandler.HandleException(ex, "Unable to add artist", "Artist could not be added to the database due to an internal database error.");
			}
		}

		private void tbName_TextChanged(object sender, EventArgs e)
		{
			_artist.Name = tbName.Text;
		}
	}
}
