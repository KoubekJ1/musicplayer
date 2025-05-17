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

		}
	}
}
