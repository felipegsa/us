using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;

namespace DAL
{
    class CommomDAL
    {

        public MySqlConnection connection;
        private string server;
        private string database;
        private string uid;
        private string password;

        //Construtor
        public CommomDAL()
        {
            Initialize();
        }

        public  void Initialize()
        {
            server = "localhost";
            database = "us";
            uid = "root";
            password = "123456";
            string connectionString;
            connectionString = "SERVER=" + server + ";Port=3306;" + "DATABASE=" +
            database + ";" + "UID=" + uid + ";" + "PASSWORD=" + password + ";pooling=false;";

            connection = new MySqlConnection(connectionString);
        }
        public bool OpenConnection()
        {
            try
            {
                connection.Open();
                return true;
            }
            catch (MySqlException ex)
            {             
                switch (ex.Number)
                {
                    case 0:
                        throw new Exception("Não foi possível fazer a conexão com o banco de dados!" + ex.Message);
                }
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
            catch (MySqlException ex)
            {
                throw new Exception(ex.Message);
                return false;
            }
        }       
    }
}
