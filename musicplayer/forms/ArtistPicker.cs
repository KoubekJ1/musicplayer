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

namespace musicplayer.forms
{
	public partial class ArtistPicker : Form
	{
		private IEnumerable<Artist> _originalArtistsQuery;
		private Artist? _artist;

		public Artist? Artist { get => _artist; }

		public ArtistPicker()
		{
			InitializeComponent();
			this.FormBorderStyle = FormBorderStyle.FixedSingle;

			ArtistDAO dao = new ArtistDAO();
			_originalArtistsQuery = dao.GetAll();
			foreach (var artist in _originalArtistsQuery)
			{
				lbArtists.Items.Add(artist);
			}
		}

		private void tbSearch_TextChanged(object sender, EventArgs e)
		{
			// Ordinary contains doesnt work due to case sensitivity
			IEnumerable<Artist> artistsQuery = _originalArtistsQuery.Where(art => art.Name.IndexOf(tbSearch.Text, StringComparison.OrdinalIgnoreCase) >= 0);
			lbArtists.Items.Clear();
			foreach (var artistInQuery in artistsQuery)
			{
				lbArtists.Items.Add(artistInQuery);
			}
		}

		private void bSelect_Click(object sender, EventArgs e)
		{
			_artist = lbArtists.SelectedItem as Artist;
			this.Close();
		}
	}
}
