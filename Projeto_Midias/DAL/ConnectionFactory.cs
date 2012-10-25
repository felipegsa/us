using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Npgsql;
using NpgsqlTypes;

namespace DAL
{
    public class ConnectionFactory
    {
        private ConnectionFactory()
        {
        }

        public static NpgsqlConnection createConnection()
        {
            string connectionString = "Server=5.184.1.37;Port=5432;Database=universidade;User Id=postgres;Password=hxhr695684;Pooling=true;MinPoolSize=1;MaxPoolSize=30;CommandTimeout=30;ConnectionLifeTime=30;Timeout=40";
            NpgsqlConnection nova_conexao = null;

            try
            {
                nova_conexao = new NpgsqlConnection(connectionString);
                nova_conexao.Open();
                return nova_conexao;
            }
            catch (Exception ex)
            {
                return nova_conexao;
            }
        }
    }
}
