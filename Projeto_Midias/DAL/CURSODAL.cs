using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Npgsql;
using System.Data;
using System.IO;

namespace DAL
{
    public class CursoDAL
    {
        public List<Model.Curso> ConsultarCursos()
        {
            List<Model.Curso> listCurso = new List<Model.Curso>();
            CommomDALP commomBase = new CommomDALP();
            commomBase.OpenConnection();
            string strCom;
            strCom = "Select       * From         CURSO";
            NpgsqlCommand cmd = new NpgsqlCommand(strCom, commomBase.connection);
            NpgsqlDataReader dataReader = cmd.ExecuteReader();
            while (dataReader.Read()) {
                Model.Curso objCurso = new Model.Curso();
                objCurso.Id = (int)dataReader["id_curso"];
                objCurso.Nome = (string)dataReader["tl_curso"];
                objCurso.Assunto = (string)dataReader["ds_curso"];
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
