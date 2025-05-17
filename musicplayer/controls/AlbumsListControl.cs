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
	public partial class AlbumsListControl : UserControl
	{
		public AlbumsListControl()
		{
			InitializeComponent();
		}

		public void AddAlbum(Album album)
		{
			Controls.Add(new AlbumDisplayControl(album));
		}
	}
}
