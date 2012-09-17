using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Npgsql;
namespace DAL
{
    public class Login
    {
        public Boolean LogarUsuario(string email, string pass) {
            Boolean retorno = false;
            CommomDALP commomBase = new CommomDALP();
            

            string strCom = "Select Count(*) from usuario where email_usuario = :email_usuario and senha_usuario = :senha_usuario";
            int count;
            try
            {
                    commomBase.OpenConnection();       
                    NpgsqlCommand comm = new NpgsqlCommand(strCom, commomBase.connection);
                    comm.Parameters.AddWithValue("email_usuario", email);
                    comm.Parameters.AddWithValue("senha_usuario", pass);
                    NpgsqlDataReader dataReader = comm.ExecuteReader();
                    dataReader.Read();
                    count = Convert.ToInt32(dataReader[0]);
               
                if (count != 1)
                {
                    throw new Exception("Não foi possível logar o usuário!");
                }
            }
            catch (Exception ex)
            { 
                //log
                return false;
            }
            retorno = true;
            return retorno;
        }
    }
}
