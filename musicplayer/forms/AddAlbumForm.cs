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
		private Album _album;

		public Album? Album { get => _album; }

		public AddAlbumForm()
		{
			InitializeComponent();
			this.FormBorderStyle = FormBorderStyle.FixedSingle;
			_album = new Album("");
		}

		public AddAlbumForm(Album album)
		{
			InitializeComponent();
			this.FormBorderStyle = FormBorderStyle.FixedSingle;
			this.Text = "Edit Album";
			bAddAlbum.Text = "Save Changes";
			_album = album;
			tbName.Text = album.Name;
			if (album.Artist != null) lArtistName.Text = album.Artist.Name;
			if (album.Image != null) pbImage.Image = IconImage.ResizeImage(album.Image.Image, pbImage.Width, pbImage.Height);

			foreach (Song song in album.Songs)
			{
				lbSongs.Items.Add(song);
			}
		}

		private void bChange_Click(object sender, EventArgs e)
		{
			OpenFileDialog dialog = new OpenFileDialog();
			dialog.Filter = "All files (*.*)|*.*|JPEG (*.jpeg)|*.jpeg|PNG (*.png)|*.png|Bitmap (*.bmp)|*.bmp";
			if (dialog.ShowDialog() != DialogResult.OK) return;
			try
			{
				_album.Image = new IconImage(new Bitmap(dialog.FileName));
				pbImage.Image = IconImage.ResizeImage(new Bitmap(dialog.FileName), pbImage.Width, pbImage.Height);
				pbImage.SizeMode = PictureBoxSizeMode.StretchImage;
			}
			catch (Exception ex)
			{
				ErrorHandler.HandleException(ex, "Unable to load image: " + dialog.FileName, "Error");
				return;
			}
		}

		/*private void bAddAlbum_Click(object sender, EventArgs e)
		{
			_album = new Album(tbName.Text);
			Bitmap? bitmap = pbImage.Image as Bitmap;
			if (bitmap != null)
			{
				_album.Image = new IconImage(bitmap);
			}
			if (_artist != null)
			{
				_album.Artist = _artist;
			}
			foreach (var listBoxItem in lbSongs.Items)
			{
				Song? song = listBoxItem as Song;
				if (song == null) continue;
				_album.Songs.Add(song);
			}

			AlbumDAO dao = new AlbumDAO();
			try
			{
				dao.Upload(_album);
				if (_album.Id != null)
				{
					MessageBox.Show("Album \"" + _album.Name + "\" was successfully uploaded.", "Add Album");
					this.Close();
				}
				else
				{
					throw new Exception("ID is null!");
				}
			}
			catch (Exception ex)
			{
				ErrorHandler.HandleException(ex, "Error", "Unable to upload album due to an internal error");
			}
		}*/

		private void bAddAlbum_Click(object sender, EventArgs e)
		{
			_album.Songs.Clear();
			foreach (var lbItem in lbSongs.Items)
			{
				Song? song = lbItem as Song;
				if (song == null) continue;
				_album.Songs.Add(song);
			}

			AlbumDAO dao = new AlbumDAO();
			try
			{
				dao.Upload(_album);
				if (_album.Id != null)
				{
					MessageBox.Show("Album \"" + _album.Name + "\" was successfully uploaded.", "Add Album");
					this.Close();
				}
				else
				{
					throw new Exception("ID is null!");
				}
			}
			catch (Exception ex)
			{
				ErrorHandler.HandleException(ex, "Error", "Unable to upload album due to an internal error");
			}
		}

		private void bClickArtist_Click(object sender, EventArgs e)
		{
			ArtistPicker picker = new ArtistPicker();
			picker.ShowDialog();
			_album.Artist = picker.Artist;
			if (_album.Artist != null) lArtistName.Text = _album.Artist.ToString();
		}

		private void bAddSong_Click(object sender, EventArgs e)
		{
			SongPicker picker = new SongPicker();
			picker.ShowDialog();
			if (picker.Song == null) return;
			lbSongs.Items.Add(picker.Song);
		}

		private void bUp_Click(object sender, EventArgs e)
		{
			if (lbSongs.SelectedItem == null || lbSongs.SelectedIndex <= 0 || lbSongs.Items.Count <= 1) return;
			int selectedIndex = lbSongs.SelectedIndex;
			int swapIndex = selectedIndex - 1;
			object? selectedSong = lbSongs.SelectedItem;
			object? swapSong = lbSongs.Items[swapIndex];

			lbSongs.Items[swapIndex] = selectedSong;
			lbSongs.Items[selectedIndex] = swapSong;

			lbSongs.SelectedIndex = swapIndex;
		}

		private void bDown_Click(object sender, EventArgs e)
		{
			if (lbSongs.SelectedItem == null || lbSongs.SelectedIndex >= lbSongs.Items.Count - 1 || lbSongs.Items.Count <= 1) return;
			int selectedIndex = lbSongs.SelectedIndex;
			int swapIndex = selectedIndex + 1;
			object? selectedSong = lbSongs.SelectedItem;
			object? swapSong = lbSongs.Items[swapIndex];

			lbSongs.Items[swapIndex] = selectedSong;
			lbSongs.Items[selectedIndex] = swapSong;

			lbSongs.SelectedIndex = swapIndex;
		}

		private void tbName_TextChanged(object sender, EventArgs e)
		{
			_album.Name = tbName.Text;
		}
	}
}
