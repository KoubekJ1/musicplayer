using musicplayer.controls;
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
	public partial class AlbumDisplayControl : UserControl
	{
		private Album _album;
		private Control _artistDisplayControl;

		public AlbumDisplayControl(Album album, Control artistDisplayControl)
		{
			InitializeComponent();
			_album = album;
			label.Text = album.Name;
			button.Image = album.Image?.Image;
			_artistDisplayControl = artistDisplayControl;
		}

		private void label_Click(object sender, EventArgs e)
		{

		}

		private void button_Click(object sender, EventArgs e)
		{
			_artistDisplayControl.Controls.Clear();
			_artistDisplayControl.Controls.Add(new AlbumSongListControl(_album));
		}
	}
}
