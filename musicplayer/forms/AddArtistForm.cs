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
        private Artist? _artist;

		public Artist? Artist { get => _artist; }

		public AddArtistForm()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
        }

        private void bChangeImage_Click(object sender, EventArgs e)
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
                MessageBox.Show("Unable to load image: " + dialog.FileName, "Error");
                return;
            }
        }

        private void bAdd_Click(object sender, EventArgs e)
        {
            _artist = new Artist(tbName.Text);
            if (pbImage.Image != null)
            {
                Bitmap bitmap = pbImage.Image as Bitmap;
                if (bitmap != null) _artist.Image = new IconImage(bitmap);
            }
            try
            {
                new ArtistDAO().Upload(_artist);
                MessageBox.Show("Artist " + _artist.Name + " added successfully", _artist.Name);
			}
            catch (Exception ex)
            {
                ErrorHandler.HandleException(ex, "Unable to add artist", "Artist could not be added to the database due to an internal database error.");
            }
        }
    }
}
