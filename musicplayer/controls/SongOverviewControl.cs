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

namespace musicplayer.controls
{
	public partial class SongOverviewControl : UserControl
	{
		private IEnumerable<Song> _songs;

		public SongOverviewControl(IEnumerable<Song> songs)
		{
			InitializeComponent();
			_songs = songs;
			SetSongs(songs);
		}

		private void SetSongs(IEnumerable<Song> songs)
		{
			flpSongs.Controls.Clear();
			foreach (Song song in songs)
			{
				var control = new SongControl(song);
				flpSongs.Controls.Add(control);
			}
		}

		private void tbSearch_TextChanged(object sender, EventArgs e)
		{
			IEnumerable<Song> songs = _songs.Where(song => song.Name.IndexOf (tbSearch.Text, StringComparison.OrdinalIgnoreCase) >= 0);
			SetSongs(songs);
		}
	}
}
