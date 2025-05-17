using musicplayer.dataobjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IDataObject = musicplayer.dataobjects.IDataObject;

namespace musicplayer.dao
{
    public interface IDAO<T> where T : IDataObject
    {
        public T? GetByID(int id);
        public IEnumerable<T> GetAll();
        public int? Upload(T data);
        public void Remove(int id);
    }
}
