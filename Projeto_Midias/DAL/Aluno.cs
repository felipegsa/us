using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;
using System.IO;
using Npgsql;

namespace DAL
{
    public class Aluno
    {
        public byte[] GetImage(string id) {
          byte[] img = new byte[0];

            return img;
        }
        public void CadastrarAluno(Model.Aluno pAluno)
        {
            CommomDALP commomBase = new CommomDALP();
            commomBase.OpenConnection();
            try
            {            
            string strCom;
            //TODO: VERIFICAR COMO FICARÁ AS IMAGENS
            strCom = "Insert into usuario (id_tipo_usuario,";
            strCom += " nm_usuario, email_usuario,";
            strCom += "senha_usuario, dt_cadastro, link_imagem_usuario)";
            strCom += " values  (2,:nm_usuario , :email_usuario , :senha_usuaro , now() , 'lala')";
            NpgsqlCommand cmd = new NpgsqlCommand(strCom, commomBase.connection);
            cmd.Parameters.AddWithValue(":nm_usuario", pAluno.Nome);
            cmd.Parameters.AddWithValue(":email_usuario", pAluno.Email);
            cmd.Parameters.AddWithValue(":senha_usuaro", pAluno.Senha);
            
            long result = cmd.ExecuteNonQuery();
            
            if (result != 1){
                throw new Exception("Não foi possível cadastrar o usuário!");
                }
            }
            catch (NpgsqlException ex)
            {
                throw new Exception(ex.Message);
                
            }
            finally {
                commomBase.CloseConnection();
            }
            
        }
    }
}
