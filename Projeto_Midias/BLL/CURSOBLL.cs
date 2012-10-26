using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;
using DAL;

namespace BLL
{
    public class CursoBLL : BaseBLL<Curso>
    {
        private CursoDAL curso_dal;

        public CursoBLL()
        {
            this.curso_dal = new CursoDAL();
        }

        public List<Curso> ConsultarCurso()
        {
            // se tiver alguma regra de negocio será implemtandada aqui
            return curso_dal.obter();
        }

        public Curso obter(int id_curso)
        {
            // se tiver alguma regra de negocio será implemtandada aqui
            return curso_dal.obter(id_curso);
        }

        public List<Curso> obter(Curso curso)
        {
            // se tiver alguma regra de negocio será implemtandada aqui
            // parametros suportados atualmente são Id_curso e Tl_curso
            return curso_dal.obter(curso);
        }

        public List<Curso> obter(Usuario id_usuario)
        {
            // valida o id_usaurio
            if (id_usuario.Id_usuario == 0)
            {
                // retorna uma lista vazia
                return new List<Curso>();
            }

            return curso_dal.obter(id_usuario);
        }

        public int salvar(Curso novo_curso)
        {
            // se tiver alguma regra de negocio será implemtandada aqui
            return curso_dal.salvar(novo_curso);
        }

        public int alterar(Curso curso)
        {
            // se tiver alguma regra de negocio será implemtandada aqui
            return curso_dal.alterar(curso);
        }
    }
}
