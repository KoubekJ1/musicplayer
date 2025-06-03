using Microsoft.VisualBasic;
using musicplayer.controls;
using musicplayer.forms;
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
			PlayerControl control = PlayerControl.GetPlayerControl();
			control.Dock = DockStyle.Top;
			this.Controls.Add(control);
			this.FormClosing += DisposeAudioManager;
		}

		private void DisposeAudioManager(object? sender, FormClosingEventArgs e)
		{
			AudioPlayerManager.GetPlayerManager().Dispose();
		}

		private void artistToolStripMenuItem_Click(object sender, EventArgs e)
		{
			new AddArtistForm().ShowDialog();
		}

		private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
		{

		}

		private void buttonArtists_Click(object sender, EventArgs e)
		{
			ArtistsControl artistsControl = new ArtistsControl();
			artistsControl.Dock = DockStyle.Fill;
			panelContent.Controls.Add(artistsControl);
		}

		private void songToolStripMenuItem_Click(object sender, EventArgs e)
		{
			new AddSongForm().ShowDialog();
		}

		private void albumToolStripMenuItem_Click(object sender, EventArgs e)
		{
			new AddAlbumForm().ShowDialog();
		}

		private void MusicPlayerWindow_Load(object sender, EventArgs e)
		{

		}
	}
}
