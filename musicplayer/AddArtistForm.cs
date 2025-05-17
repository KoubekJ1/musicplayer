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
        public AddArtistForm()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
        }

        private void bChangeImage_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "JPEG (*.jpeg)|*.jpeg|PNG (*.png)|*.png|Bitmap (*.bmp)|*.bmp|All files (*.*)|*.*";
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
            Artist artist = new Artist(tbName.Text);
            if (pbImage.Image != null)
            {
                Bitmap bitmap = pbImage.Image as Bitmap;
                if (bitmap != null) artist.Image = new IconImage(bitmap);
            }
            try
            {
                new ArtistDAO().Upload(artist);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Unable to add artist");
            }
        }
    }
}
