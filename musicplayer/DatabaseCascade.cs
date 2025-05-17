using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace musicplayer
{
	public static class DatabaseCascade
	{
		public static int? UploadSongData(byte[] data)
		{
			SqlConnection connection = DatabaseConnection.GetConnection();
			connection.Open();

			SqlCommand command = new SqlCommand("INSERT INTO song_data (sd_data) OUTPUT INSERTED.sd_id VALUES (@data)", connection);
			command.Parameters.AddWithValue("data", data);
			int? id = (int?)command.ExecuteScalar();

			if (id == null)
			{
				throw new Exception("Uploaded ID is null!");
			}

			connection.Close();
			return id;
		}

		public static byte[] GetSongData(int id)
		{
			SqlConnection connection = DatabaseConnection.GetConnection();
			connection.Open();
			SqlCommand cmd = new SqlCommand("SELECT sd_data FROM song_data WHERE sd_id = @id", connection);
			cmd.Parameters.AddWithValue("id", id);

			SqlDataReader reader = cmd.ExecuteReader();

			// First discover byte amount to prevent allocating 2GB worth of empty space
			byte[] data = null;
			if (!reader.Read()) return data;
			long bufferSize = reader.GetBytes(0, 0, data, 0, 2147483647);
			data = new byte[bufferSize];
			reader.GetBytes(0, 0, data, 0, (int)bufferSize);

			connection.Close();
			return data;
		}

		public static List<Album> GetArtistAlbums(int id)
		{
			SqlConnection connection = new SqlConnection();
			connection.Open();

			SqlCommand cmd = new SqlCommand("SELECT alb_name FROM albums INNER JOIN artists_albums ON aa_alb_id = alb_id INNER JOIN artists ON aa_ar_id = ar_id WHERE ar_id = @id", connection);
			cmd.Parameters.AddWithValue("id", id);

			SqlDataReader reader = cmd.ExecuteReader();

			List<Album> list = new List<Album>();
			while (reader.Read())
			{
				Album album = new Album(reader.GetString(0));
				list.Add(album);
			}

			connection.Close();
			return list;
		}

		public static Bitmap? GetBitmap(int id)
		{
			SqlConnection connection = DatabaseConnection.GetConnection();
			connection.Open();

			SqlCommand command = new SqlCommand("SELECT img_data FROM image_data WHERE img_id = @id", connection);
			command.Parameters.AddWithValue("id", id);

			SqlDataReader reader = command.ExecuteReader();

			if (!reader.Read()) return null;

			byte[] buffer = null;
			long byteAmount = reader.GetBytes(0, 0, buffer, 0, 8000);
			buffer = new byte[byteAmount];
			reader.GetBytes(0, 0, buffer, 0, (int)byteAmount);
			MemoryStream stream = new MemoryStream(buffer);
			Bitmap bitmap = new Bitmap(stream);

			connection.Close();

			return bitmap;
		}
	}
}
