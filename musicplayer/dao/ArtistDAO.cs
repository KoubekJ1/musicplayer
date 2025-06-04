using Microsoft.Data.SqlClient;
using musicplayer.dataobjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace musicplayer.dao
{
    public class ArtistDAO : IDAO<Artist>
    {
        public IEnumerable<Artist> GetAll()
        {
            LinkedList<Artist> artists = new LinkedList<Artist>();
            LinkedList<int?> imageIDs = new LinkedList<int?>();

			SqlConnection connection = DatabaseConnection.GetConnection();
            connection.Open();

            SqlCommand command = new SqlCommand("SELECT ar_id, ar_name, ar_img_id FROM artists", connection);
            SqlDataReader reader = command.ExecuteReader();

            Artist artist;
            while (reader.Read())
            {
                artist = new Artist(reader.GetString(1));
                artist.Id = reader.GetInt32(0);
				imageIDs.AddLast(reader.IsDBNull(2) ? null : reader.GetInt32(2));
				artists.AddLast(artist);
            }

            var imageEnumerator = imageIDs.GetEnumerator();
			foreach (Artist artist1 in artists)
            {
                if (imageEnumerator.MoveNext() && imageEnumerator.Current != null)
				artist1.Image = new IconImageDAO().GetByID((int)imageEnumerator.Current);
			}

            connection.Close();

            return artists;
        }

        public Artist? GetByID(int id)
        {
            SqlConnection connection = DatabaseConnection.GetConnection();
            connection.Open();

            SqlCommand command = new SqlCommand("SELECT ar_id, ar_name, ar_img_id FROM artists", connection);
            SqlDataReader reader = command.ExecuteReader();

            if (!reader.Read()) return null;

            Artist artist = new Artist(reader.GetString(1));
            artist.Id = reader.GetInt32(0);
            int? imgID = null;
			if (!reader.IsDBNull(2)) imgID = reader.GetInt32(2);

            connection.Close();

            if (imgID != null)
            {
                artist.Image = new IconImageDAO().GetByID((int)imgID);
            }

            return artist;
        }

        public void Remove(int id)
        {
            SqlConnection connection = DatabaseConnection.GetConnection();
            connection.Open();

            SqlCommand command = new SqlCommand("DELETE FROM artists WHERE ar_id = @id", connection);
            command.Parameters.AddWithValue("id", id);
            command.ExecuteNonQuery();

            connection.Close();
        }

        public int? Upload(Artist artist)
        {
            if (artist.Id != null)
            {
                Update(artist);
                return artist.Id;
            }

            if (artist.Image != null)
            {
                artist.Image.Id = new IconImageDAO().Upload(artist.Image);
            }

            SqlConnection connection = DatabaseConnection.GetConnection();
            connection.Open();

            SqlCommand command = new SqlCommand("INSERT INTO artists (ar_name, ar_img_id) OUTPUT INSERTED.ar_id VALUES (@name, @img_id)", connection);
            command.Parameters.AddWithValue("name", artist.Name);
            command.Parameters.AddWithValue("img_id", artist.Image != null ? artist.Image.Id : DBNull.Value);

            int id = (int)command.ExecuteScalar();

            connection.Close();

            artist.Id = id;

            return id;
        }

        public void Update(Artist artist)
        {
            if (artist.Id == null) return;

            if (artist.Image?.Id == null)
            {
                artist.Image.Id = new IconImageDAO().Upload(artist.Image);
            }

            SqlConnection connection = DatabaseConnection.GetConnection();
            connection.Open();

            SqlCommand command = new SqlCommand("UPDATE artists SET ar_name = @name, ar_img_id = @img_id WHERE ar_id = @id", connection);
            command.Parameters.AddWithValue("id", artist.Id);
            command.Parameters.AddWithValue("name", artist.Name);
            command.Parameters.AddWithValue("img_id", artist.Image?.Id != null ? artist.Image.Id : DBNull.Value);

            command.ExecuteNonQuery();

			connection.Close();
        }
    }
}
