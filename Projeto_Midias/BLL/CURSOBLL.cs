using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;

namespace BLL
{
    public class CursoBLL : BaseBLL<Curso>
    {
        public List<Model.Curso> ConsultarCurso()
        {
            DAL.CursoDAL dalCurso = new DAL.CursoDAL();
            List<Model.Curso> objCurso = new List<Model.Curso>();
            objCurso = dalCurso.obter();

            return objCurso;
            //aqui se tiver alguma regra de negocio será implemtandada aqui
        }
    }
}
