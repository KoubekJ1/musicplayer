using musicplayer.controls;
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
        private int _length;

        private Album? _album;
        private int? _dataID;

        public Song(string name)
        {
            _name = name;
        }

        public int? GetID()
        {
            return id;
        }

        public bool PlaySong(bool replace)
        {
            //AudioPlayerManager.GetPlayerManager().Stop();
			//AudioPlayerManager.GetPlayerManager().PlayAudio(_data, replace);
			if (!AudioPlayerManager.GetPlayerManager().PlaySong(this)) return false;

            return true;
        }

		public override string? ToString()
		{
            return _name;
		}

		public byte[]? Data { get => _data; set => _data = value; }
        public string Name { get => _name; set => _name = value; }
        public int? Id { get => id; set => id = value; }
        public int Length { get => _length; set => _length = value; }
		public int? DataID { get => _dataID; set => _dataID = value; }
		public Album? Album { get => _album; set => _album = value; }
	}
}
