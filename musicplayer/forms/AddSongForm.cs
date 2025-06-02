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
        private byte[]? songData;

        public AddSongForm()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
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
                songData = File.ReadAllBytes(dialog.FileName);
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
            if (songData == null)
            {
                MessageBox.Show("Please load an MP3 file containing the song data.", "No song data");
                return;
            }

            Song song = new Song(tbName.Text);
            song.Data = songData;
            song.Length = (int)AudioPlayerManager.GetDuration(songData);

            SongDAO dao = new SongDAO();
            song.Id = dao.Upload(song);

            if (song.Id == null)
            {
                MessageBox.Show("Upload failed due to an error.", "Error");
            }
            else
            {
                MessageBox.Show("Successfully uploaded \"" + song.Name + "\" to the database.", "Add Song");
                this.Close();
            }
        }
    }
}
