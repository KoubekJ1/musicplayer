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
	public partial class ArtistsControl : UserControl
	{
		private Dictionary<Button, Artist> artistButtons = new Dictionary<Button, Artist>();
		public ArtistsControl()
		{
			InitializeComponent();
			artistButtons = new Dictionary<Button, Artist>();

			var artists = new ArtistDAO().GetAll();
			foreach (Artist artist in artists.OrderBy(artist => artist.Name))
			{
				Button button = new Button();
				button.Text = artist.Name;
				button.Width = 200;
				button.Height = 100;
				button.AutoSize = true;
				button.AutoSizeMode = AutoSizeMode.GrowOnly;
				button.TextAlign = ContentAlignment.MiddleRight;
				flpArtists.Controls.Add(button);

				PictureBox pictureBox = new PictureBox();
				pictureBox.Image = artist.Image?.Image;
				//pictureBox.Dock = DockStyle.Left;
				pictureBox.Location = new Point(10, 25);
				pictureBox.Height = 50;
				pictureBox.Width = 50;
				pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
				button.Controls.Add(pictureBox);

				artistButtons.Add(button, artist);
				button.Click += ButtonClicked;

			}
		}

		private void ButtonClicked(object? sender, EventArgs e)
		{
			Button? button = sender as Button;
			if (button == null) return;
			Artist? artist = artistButtons[button];
			if (artist == null) return;
			pArtistContent.Controls.Clear();
			pArtistContent.Controls.Add(new AlbumsListControl(artist, pArtistContent));
		}
	}
}
