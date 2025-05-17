using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace musicplayer
{
    public class Album : IDataObject
    {
        private int? id;
        private string _name;
        private IconImage? _image;

        private List<Song> _songs;

        public Album(string name)
        {
            _name = name;
            _songs = new List<Song>();
        }
        public Album(string name, IconImage _image)
        {
            _name = name;
            this._image = _image;
            _songs = new List<Song>();
        }

        public int? Id { get => id; set => id = value; }
        public IconImage? Image { get => _image; set => _image = value; }

        public int? GetID()
        {
            return id;
        }

        public void LoadSongs()
        {
            if (id == null) return;
            _songs = new SongDAO().GetSongsFromAlbum((int)id);
        }
    }
}
