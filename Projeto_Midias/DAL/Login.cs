using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Npgsql;
namespace DAL
{
    public class Login
    {
        public void LogarUsuario(string email, string pass) {
            
            string strCom = "Select Count(*) from usuario where email_usuario = :email_usuario and senha_usuario = :senha_usuario";
            int count;
            try
            {
                using (NpgsqlConnection conexao = ConnectionFactory.createConnection())
                {
                    NpgsqlCommand comm = new NpgsqlCommand(strCom, conexao);
                    comm.Parameters.AddWithValue("email_usuario", email);
                    comm.Parameters.AddWithValue("senha_usuario", pass);
                    NpgsqlDataReader dataReader = comm.ExecuteReader();
                    dataReader.Read();
                    count = Convert.ToInt32(dataReader[0]);

                    if (count != 1)
                    {
                        throw new ExceptionDAL("Não foi possível logar usuário");
                    }
                }
            }
            catch (Exception ex)
            { 
                //log
                throw new ExceptionDAL(ex.Message, ex);
            }
          }
    }
}
