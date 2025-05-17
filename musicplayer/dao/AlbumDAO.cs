using Microsoft.Data.SqlClient;
using musicplayer.dataobjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace musicplayer.dao
{
    public class AlbumDAO : IDAO<Album>
    {
        public IEnumerable<Album> GetAll()
        {
            LinkedList<Album> albums = new LinkedList<Album>();
            LinkedList<int> imgIDs = new LinkedList<int>();

            SqlConnection connection = DatabaseConnection.GetConnection();
            connection.Open();

            SqlCommand command = new SqlCommand("SELECT alb_id, alb_name, alb_img_id FROM albums", connection);

            SqlDataReader reader = command.ExecuteReader();

            Album album;
            while (reader.Read())
            {
                album = new Album(reader.GetString(1));
                album.Id = reader.GetInt32(0);
                int? imgID = reader.GetInt32(3);
            }

            connection.Close();

            var albumEnumerator = albums.GetEnumerator();
            foreach (int imgID in imgIDs)
            {
                if (!albumEnumerator.MoveNext()) break;
                albumEnumerator.Current.Image = new IconImageDAO().GetByID(imgID);
            }

            return albums;
        }

        public Album? GetByID(int id)
        {
            SqlConnection connection = DatabaseConnection.GetConnection();
            connection.Open();

            SqlCommand command = new SqlCommand("SELECT alb_id, alb_name, alb_img_id FROM albums WHERE alb_id = @id", connection);
            command.Parameters.AddWithValue("id", id);

            SqlDataReader reader = command.ExecuteReader();
            if (!reader.Read()) return null;
            Album album = new Album(reader.GetString(1));
            album.Id = reader.GetInt32(0);
            int? imgID = reader.GetInt32(3);

            connection.Close();

            if (imgID != null)
            {
                album.Image = new IconImageDAO().GetByID((int)imgID);
            }

            return album;
        }

        public List<Album> GetArtistAlbums(int artistID)
        {
            List<Album> albums = new List<Album>();
            LinkedList<int?> imageIDs = new LinkedList<int?>();

            SqlConnection connection = DatabaseConnection.GetConnection();
            connection.Open();

            SqlCommand command = new SqlCommand("SELECT alb_id, alb_img_id, alb_name FROM albums WHERE alb_ar_id = @artist_id", connection);
            command.Parameters.AddWithValue("artist_id", artistID);

            SqlDataReader reader = command.ExecuteReader();

            Album album;
            while (reader.Read())
            {
                album = new Album(reader.GetString(2));
                album.Id = reader.GetInt32(0);
                imageIDs.AddLast(reader[1] == DBNull.Value ? null : reader.GetInt32(1));
                albums.Add(album);
            }

			connection.Close();

			int i = 0;
            foreach (int? id in imageIDs)
            {
                if (id == null)
				{
					i++;
					continue;
				}

				albums[i].Image = new IconImageDAO().GetByID((int)id);
                i++;
            }

            return albums;
        }

        public void Remove(int id)
        {
            throw new NotImplementedException();
        }

        public int? Upload(Album data)
        {
            throw new NotImplementedException();
        }
    }
}
