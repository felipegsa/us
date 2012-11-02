using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;
using DAL;

namespace BLL
{
    public class Aula_BLL
    {
        private Aula_dal aula_dao;

        public Aula_BLL()
        {
            this.aula_dao = new Aula_dal();
        }

        public int salvar(Aula nova_aula)
        {
            // validações
            // ...

            return aula_dao.salvar(nova_aula);
        }

        public Aula obter(int id_aula)
        {
            return aula_dao.obter(id_aula);
        }

        public List<Aula> obter(Curso id_curso)
        {
            // validações
            // ...

            if (id_curso.Id_curso < 1)
            {
                // retorna uma lista vazia
                return new List<Aula>();
            }

            return aula_dao.obter(id_curso);
        }

        public List<Aula> obter(Usuario id_usuario)
        {
            // validações
            // ...

            if (id_usuario.Id_usuario < 1)
            {
                // retorna uma lista vazia
                return new List<Aula>();
            }

            return aula_dao.obter(id_usuario);
        }

        public int alterar(Aula aula)
        {
            // validações
            // ...

            return aula_dao.alterar(aula);
        }

        public int excluir(int id_aula)
        {
            // DROP CASCADED
            return aula_dao.excluir(id_aula);
        }
    }
}