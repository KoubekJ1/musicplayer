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
using static System.Net.Mime.MediaTypeNames;

namespace musicplayer.forms
{
	public partial class AddSongForm : Form
	{
		private Album? _album;

		private Song _song;

		public Song Song { get => _song; }

		public AddSongForm()
		{
			InitializeComponent();
			this.FormBorderStyle = FormBorderStyle.FixedSingle;
			_song = new Song("");
		}

		public AddSongForm(Song song)
		{
			InitializeComponent();
			this.FormBorderStyle = FormBorderStyle.FixedSingle;
			_song = song;

			tbName.Text = song.Name;
			lFile.Text = "Original song data";
		}

		private void AddSongForm_Load(object sender, EventArgs e)
		{

		}

		private void bFile_Click(object sender, EventArgs e)
		{
			OpenFileDialog dialog = new OpenFileDialog();
			dialog.Filter = "MP3 Files (*.mp3)|*.mp3";
			if (dialog.ShowDialog() != DialogResult.OK) return;
			try
			{
				_song.Data = File.ReadAllBytes(dialog.FileName);
				_song.DataID = null;
				lFile.Text = dialog.FileName;
			}
			catch (Exception ex)
			{
				MessageBox.Show("Unable to load song: " + dialog.FileName, "Error");
				return;
			}
		}

		private void bAdd_Click(object sender, EventArgs e)
		{
			SongDAO dao = new SongDAO();
			if (_song.Data == null)
			{
				if (_song.DataID != null)
				{
					try
					{
						_song.Data = dao.GetSongData((int)_song.DataID);
					}
					catch (Exception ex)
					{
						ErrorHandler.HandleException(ex, "Error", "Unable to load song data from the database!");
						return;
					}
				}
				else
				{
					MessageBox.Show("Please load an MP3 file containing the song data.", "No song data");
					return;
				}
			}

			_song.Length = (int)AudioPlayerManager.GetDuration(_song.Data);

			_song.Id = dao.Upload(_song);

			if (_song.Id == null)
			{
				MessageBox.Show("Upload failed due to an error.", "Error");
				this.Close();
			}
			else
			{
				MessageBox.Show("Successfully uploaded \"" + _song.Name + "\" to the database.", "Add Song");
				this.Close();
			}
		}

		private void bSelectAlbum_Click(object sender, EventArgs e)
		{
			AlbumPicker picker = new AlbumPicker();
			picker.ShowDialog();
			_album = picker.Album;
		}

		private void tbName_TextChanged(object sender, EventArgs e)
		{
			_song.Name = tbName.Text;
		}
	}
}
