﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Npgsql;
namespace DAL
{
    public class Login
    {
        public void LogarUsuario(string email, string pass) {

            string strCom = "Select email_usuario , nm_usuario , senha_usuario from usuario where email_usuario = :email_usuario and senha_usuario = :senha_usuario";
            int count;
            try
            {
                using (NpgsqlConnection conexao = ConnectionFactory.createConnection())
                {
                    Model.Aluno objAluno = new Model.Aluno();
                    NpgsqlCommand comm = new NpgsqlCommand(strCom, conexao);
                    comm.Parameters.AddWithValue("email_usuario", email);
                    comm.Parameters.AddWithValue("senha_usuario", pass);
                    NpgsqlDataReader dataReader = comm.ExecuteReader();

                    CarregarAluno(dataReader);                        
                }
            }
            catch (Exception ex)
            { 
                //log
                throw new ExceptionDAL(ex.Message, ex);
            }
          }
        public void CarregarAluno(NpgsqlDataReader dr)
        {
            Model.Aluno objAluno = new Model.Aluno();
            if (dr.Read())
            {
                objAluno.Nome = dr.IsDBNull(dr.GetOrdinal("nm_usuario")) ? string.Empty : dr.GetString(dr.GetOrdinal("nm_usuario"));
                objAluno.Email = dr.IsDBNull(dr.GetOrdinal("email_usuario")) ? string.Empty : dr.GetString(dr.GetOrdinal("email_usuario"));
                objAluno.Senha = dr.IsDBNull(dr.GetOrdinal("senha_usuario")) ? string.Empty : dr.GetString(dr.GetOrdinal("senha_usuario"));
                Model.Session.Session.Aluno = objAluno;
            }
            else { throw new ExceptionDAL("Não foi possível logar usuário"); }           
        }
    }
}
