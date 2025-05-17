using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace musicplayer
{
    public class Artist : IDataObject
    {
        private int? _id;
        private string _name;
        private IconImage? _image;
        
        private List<Album> _albums;

        public Artist(string name)
        {
            this._name = name;
            this._albums = new List<Album>();
        }

        public Artist(string name, IconImage image)
        {
            this._name = name;
            this._image = image;
            this._albums = new List<Album>();
        }

        public int? Id { get => _id; set => _id = value; }
        public string Name { get => _name; set => _name = value; }
        public IconImage? Image { get => _image; set => _image = value; }

        public int? GetID()
        {
            return _id;
        }

        public void LoadAlbums()
        {
            if (_id == null) return;
            this._albums = DatabaseCascade.GetArtistAlbums((int)_id);
        }
    }
}
