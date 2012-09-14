using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;
using System.Data;
using System.IO;

namespace DAL
{
    public class CursoDAL
    {
        public List<Model.Curso> ConsultarCursos()
        {
            List<Model.Curso> listCurso = new List<Model.Curso>();
            CommomDAL commomBase = new CommomDAL();
            commomBase.OpenConnection();
            string strCom;
            strCom = "Select       * From         TB_CURSO";   
            MySqlCommand cmd = new MySqlCommand(strCom, commomBase.connection);
            MySqlDataReader dataReader = cmd.ExecuteReader();
            while (dataReader.Read()) {
                Model.Curso objCurso = new Model.Curso();
                objCurso.Id = (int)dataReader["id"];
                objCurso.Nome = (string)dataReader["nome"];
                listCurso.Add(objCurso);
            }
            dataReader.Close();
            commomBase.CloseConnection();
            return listCurso;
        }  
        public Model.Curso CadastrarCurso(Model.Curso pCurso)
        {
            Model.Curso objCurso = new Model.Curso();            
            //Aqui irá cadastrar os cursos
           return objCurso;
        }
        public Model.Curso AlterarCursos(int pidCurso)
        {
            Model.Curso objCurso = new Model.Curso();
            //Aqui irá alterar o curso através da chave id            
            return objCurso;
        }
        public Model.Curso DeletarCursos(int pIdCurso)
        {
            Model.Curso objCurso = new Model.Curso();
            //Aqui irá fazer o delete através do idcurso
            //delete tb_curso where id_curso = pIdCurso
            return objCurso;
        }
    }
}
