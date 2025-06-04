﻿using musicplayer.dao;
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
	public partial class SongPicker : Form
	{
		private IEnumerable<Song> _originalSongsQuery;
		private Song? _song;

		public Song? Song { get => _song; }

		public SongPicker()
		{
			InitializeComponent();
			this.FormBorderStyle = FormBorderStyle.FixedSingle;

			SongDAO dao = new SongDAO();
			_originalSongsQuery = dao.GetAll();
			foreach (var artist in _originalSongsQuery)
			{
				lbSongs.Items.Add(artist);
			}
		}

		private void tbSearch_TextChanged(object sender, EventArgs e)
		{
			// Ordinary contains doesnt work due to case sensitivity
			IEnumerable<Song> songsQuery = _originalSongsQuery.Where(art => art.Name.IndexOf(tbSearch.Text, StringComparison.OrdinalIgnoreCase) >= 0);
			lbSongs.Items.Clear();
			foreach (var songInQuery in songsQuery)
			{
				lbSongs.Items.Add(songInQuery);
			}
		}

		private void bSelect_Click(object sender, EventArgs e)
		{
			_song = lbSongs.SelectedItem as Song;
			this.Close();
		}

		private void bNew_Click(object sender, EventArgs e)
		{
			AddSongForm addSongForm = new AddSongForm();
			addSongForm.ShowDialog();
			if (addSongForm.Song.Id == null) return;
			
			_song = addSongForm.Song;
			this.Close();
		}
	}
}
