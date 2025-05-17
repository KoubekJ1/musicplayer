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
		public AlbumDisplayControl(Album album)
		{
			InitializeComponent();
			label.Text = album.Name;
			button.Image = album.Image?.Image;
		}
	}
}
