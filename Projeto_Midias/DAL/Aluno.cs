using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;
using System.IO;

namespace DAL
{
    public class Aluno
    {
        public byte[] GetImage(string id) {
            CommomDAL connE = new CommomDAL();
            mysqc
            cmd = conn.CreateCommand();
            cmd.CommandText = "SELECT foto FROM tb_aluno WHERE id = 1";
            //cmd.Parameters.Add("?id", id);
            using (var reader = cmd.ExecuteReader())
            {
                if (!reader.Read())
                {
                    return null;
                }

                const int CHUNK_SIZE = 2 * 1024;
                byte[] buffer = new byte[CHUNK_SIZE];
                long bytesRead;
                long fieldOffset = 0;
                using (var stream = new MemoryStream())
                {
                    while ((bytesRead = reader.GetBytes(reader.GetOrdinal("Image"), fieldOffset, buffer, 0, buffer.Length)) > 0)
                    {
                        stream.Write(buffer, 0, (int)bytesRead);
                        fieldOffset += bytesRead;
                    }
                    return stream.ToArray();
                }
            }
        }
    }
}
