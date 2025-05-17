using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace musicplayer
{
    public class ArtistDAO : IDAO<Artist>
    {
        public IEnumerable<Artist> GetAll()
        {
            List<Artist> list = new List<Artist>();

            SqlConnection connection = DatabaseConnection.GetConnection();
            connection.Open();

            SqlCommand command = new SqlCommand("SELECT ar_id, ar_name, ar_img_id FROM artists", connection);
            SqlDataReader reader = command.ExecuteReader();

            Artist artist;
            while (reader.Read())
            {
                artist = new Artist(reader.GetString(1));
                artist.Id = reader.GetInt32(0);
                list.Add(artist);
            }

            connection.Close();

            return list;
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
            int? imgID = reader.GetInt32(2);

            connection.Close();

            if (imgID != null)
            {
                artist.Image = new IconImageDAO().GetByID((int)imgID);
            }

            return artist;
        }

        public void Remove(int id)
        {
            throw new NotImplementedException();
        }

        public int? Upload(Artist artist)
        {
            int? imgID;
            if (artist.Image != null)
            {
                new IconImageDAO().Upload(artist.Image);
            }

            SqlConnection connection = DatabaseConnection.GetConnection();
            connection.Open();

            SqlCommand command = new SqlCommand("INSERT INTO artists (ar_name, ar_img_id) OUTPUT INSERTED.ar_id VALUES (@name, @img_id)", connection);
            command.Parameters.AddWithValue("name", artist.Name);
            command.Parameters.AddWithValue("img_id", artist.Image != null ? artist.Image.Id : null);

            int id = (int)command.ExecuteScalar();

            connection.Close();

            artist.Id = id;

            return id;
        }
    }
}
