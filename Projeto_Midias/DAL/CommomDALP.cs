using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Npgsql;

namespace DAL
{
    class CommomDALP
    {

        public NpgsqlConnection connection;
        private string server;
        private string database;
        private string uid;
        private string password;

        //Construtor
        public CommomDALP()
        {
            Initialize();
        }

        public void Initialize()
        {
            server = "5.184.1.37";
            database = "universidade";
            uid = "postgres";
            password = "hxhr695684";
            string connectionString;
            //connectionString = "SERVER=" + server + ";Port=5432;" + "User Id=" + uid +  ";PASSWORD=" + password + ";DATABASE=" +
            //database + ";pooling=false;";
            connectionString = "Server=" + server + ";Port=5432;Database=" + database + ";User Id=" + uid + ";Password=" + password + ";";
            connection = new NpgsqlConnection(connectionString);
        }
        public bool OpenConnection()
        {
            try
            {
                connection.Open();
                return true;
            }
            catch (NpgsqlException ex)
            {
                    throw new Exception("Não foi possível fazer a conexão com o banco de dados!" + ex.Message);
                return false;
            }
        }
        public bool CloseConnection()
        {
            try
            {
                connection.Close();
                return true;
            }
            catch (NpgsqlException ex)
            {
                throw new Exception(ex.Message);
                return false;
            }
        }
    }
}
