using Microsoft.Data.SqlClient;
using musicplayer.dataobjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace musicplayer.dao
{
    public class SongDAO : IDAO<Song>
    {
        public IEnumerable<Song> GetAll()
        {
            LinkedList<Song> songs = new LinkedList<Song>();

            SqlConnection connection = DatabaseConnection.GetConnection();
            connection.Open();

            SqlCommand command = new SqlCommand("SELECT so_id, so_sd_id, so_name, so_length FROM songs", connection);
            
            SqlDataReader reader = command.ExecuteReader();

            Song song;
            while (reader.Read())
            {
                song = new Song(reader.GetString(2));
                song.Id = reader.GetInt32(0);
                song.Length = reader.GetInt32(3);
				song.DataID = reader[1] != DBNull.Value ? reader.GetInt32(1) : null;
                songs.AddLast(song);
			}

            connection.Close();

            return songs;
        }

        public Song? GetByID(int id)
        {
            SqlConnection connection = DatabaseConnection.GetConnection();
            connection.Open();

            SqlCommand command = new SqlCommand("SELECT so_id, so_sd_id, so_name, so_length FROM songs WHERE so_id = @id", connection);
            command.Parameters.AddWithValue("id", id);

            SqlDataReader reader = command.ExecuteReader();
            if (!reader.Read()) return null;
            Song song = new Song(reader.GetString(2));
            song.Id = reader.GetInt32(0);
			song.Length = reader.GetInt32(3);
			song.DataID = reader[1] != DBNull.Value ? reader.GetInt32(1) : null;


			connection.Close();

            //song.Data = GetSongData(dataID);

            return song;
        }

        public List<Song> GetSongsFromAlbum(int albumID)
        {
            LinkedList<int> songIDs = new LinkedList<int>();

            SqlConnection connection = DatabaseConnection.GetConnection();
            connection.Open();

            SqlCommand command = new SqlCommand("SELECT so_id FROM songs INNER JOIN album_songs ON as_so_id = so_id WHERE as_alb_id = @id ORDER BY as_order ASC", connection);
            command.Parameters.AddWithValue("id", albumID);

            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                songIDs.AddLast(reader.GetInt32(0));
			}

			connection.Close();

            List<Song> songs = new List<Song>(songIDs.Count);

            foreach (int i in songIDs)
            {
                Song? song = GetByID(i);
                if (song == null) continue;
                songs.Add(song);
            }

            return songs;
        }

        public void Remove(int id)
        {
            SqlConnection connection = DatabaseConnection.GetConnection();
            connection.Open();

            SqlCommand command = new SqlCommand("DELETE FROM songs WHERE so_id = @id", connection);
            command.Parameters.AddWithValue("id", id);

            command.ExecuteNonQuery();

            connection.Close();
        }

        public int? Upload(Song song)
        {
            if (song.Data == null) return null;
            int? dataID = UploadSongData(song.Data);
            song.DataID = dataID;
            if (dataID == null) return null;

            SqlConnection connection = DatabaseConnection.GetConnection();
            connection.Open();

            SqlCommand command = new SqlCommand("INSERT INTO songs (so_sd_id, so_name, so_length) OUTPUT INSERTED.so_id VALUES (@data_id, @name, @length)", connection);
            command.Parameters.AddWithValue("data_id", dataID);
            //command.Parameters.AddWithValue("alb_id", song.AlbumID != null ? song.AlbumID : DBNull.Value);
            command.Parameters.AddWithValue("name", song.Name);
            command.Parameters.AddWithValue("length", song.Length);

            int? id = (int?)command.ExecuteScalar();
            song.Id = id;

            connection.Close();

            return id;
        }

        public byte[]? GetSongData(int id)
        {
            SqlConnection connection = DatabaseConnection.GetConnection();
            connection.Open();
            SqlCommand cmd = new SqlCommand("SELECT sd_data FROM song_data WHERE sd_id = @id", connection);
            cmd.Parameters.AddWithValue("id", id);

            SqlDataReader reader = cmd.ExecuteReader();

            // First discover byte amount to prevent allocating 2GB worth of empty space
            byte[]? data = null;
            if (!reader.Read()) return data;
            long bufferSize = reader.GetBytes(0, 0, data, 0, 2147483647);
            data = new byte[bufferSize];
            reader.GetBytes(0, 0, data, 0, (int)bufferSize);

            connection.Close();
            return data;
        }

        public int? UploadSongData(byte[] data)
        {
            SqlConnection connection = DatabaseConnection.GetConnection();
            connection.Open();

            SqlCommand command = new SqlCommand("INSERT INTO song_data (sd_data) OUTPUT INSERTED.sd_id VALUES (@data)", connection);
            command.Parameters.AddWithValue("data", data);
            int? id = (int?)command.ExecuteScalar();

            connection.Close();
            return id;
        }
    }
}
