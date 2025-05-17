using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace musicplayer
{
    public partial class MusicPlayerWindow : Form
    {
        public MusicPlayerWindow()
        {
            InitializeComponent();
        }

        private void read_Click(object sender, EventArgs e)
        {
            string answer = Interaction.InputBox("Enter song data ID", "Read from database", "-1");
            int? id = null;
            try
            {
                id = Convert.ToInt32(answer);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Invalid answer: " + answer);
                return;
            }

            byte[] data = null;
            try
            {
                data = DatabaseCascade.GetSongData((int)id);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Unable to retrieve song data from database");
                return;
            }

            try
            {
                AudioPlayerManager.GetPlayerManager().PlayAudio(data, true);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Unable to play song");
            }
        }

        private void upload_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = "E:\\Development\\VS2022\\musicplayer";

            if (openFileDialog.ShowDialog() != DialogResult.OK)
            {
                return;
            }

            byte[] data = File.ReadAllBytes(openFileDialog.FileName);

            int? id = null;
            try
            {
                id = DatabaseCascade.UploadSongData(data);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Unable to upload to database");
                return;
            }

            if (id != null)
            {
                MessageBox.Show("Successfully uploaded song data to database\nID: " + id);
            }
            else
            {
                MessageBox.Show("ID is null!", "Error");
            }
        }

        private void artistToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new AddArtistForm().ShowDialog();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
