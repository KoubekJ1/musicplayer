using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace musicplayer.dataobjects
{
    public class Song : IDataObject
    {
        private int? id;
        private string _name;
        private byte[]? _data;
        private int length;

        private int? albumID; // Used when uploading to the database

        public Song(string name)
        {
            _name = name;
        }

        public int? GetID()
        {
            return id;
        }

        public void PlaySong(bool replace)
        {
            if (_data == null) return;
            AudioPlayerManager.GetPlayerManager().PlayAudio(_data, replace);
        }
        public byte[]? Data { get => _data; set => _data = value; }
        public string Name { get => _name; set => _name = value; }
        public int? Id { get => id; set => id = value; }
        public int? AlbumID { get => albumID; set => albumID = value; }
        public int Length { get => length; set => length = value; }
    }
}
