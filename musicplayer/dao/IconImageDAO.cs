using Microsoft.Data.SqlClient;
using musicplayer.dataobjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace musicplayer.dao
{
    public class IconImageDAO : IDAO<IconImage>
    {
        public IEnumerable<IconImage> GetAll()
        {
            throw new NotImplementedException();
        }

        public IconImage? GetByID(int id)
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

            IconImage image = new IconImage(bitmap, id);

            connection.Close();

            return image;
        }

        public void Remove(int id)
        {
            throw new NotImplementedException();
        }

        public int? Upload(IconImage data)
        {
            SqlConnection connection = DatabaseConnection.GetConnection();
            connection.Open();

            SqlCommand command = new SqlCommand("INSERT INTO image_data (img_data) OUTPUT INSERTED.img_id VALUES (@data)", connection);
            MemoryStream stream = new MemoryStream();
            data.Image.Save(stream, System.Drawing.Imaging.ImageFormat.Png);
            command.Parameters.AddWithValue("data", stream.ToArray());

            int? id = (int?)command.ExecuteScalar();
            data.Id = id;

            connection.Close();
            stream.Close();

			return id;
        }
    }
}
