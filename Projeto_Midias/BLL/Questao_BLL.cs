using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;
using DAL;

namespace BLL
{
    class Questao_BLL
    {
        private Questao_dao questao_dao;

        public Questao_BLL()
        {
            questao_dao = new Questao_dao();
        }

        public int salvar(Questao questao)
        {
            if (questao == null)
                return 0;

            if ((questao.Ds_questao == "") || (questao.Curso_obj.Id_curso == 0))
                return 0;

            return questao_dao.salvar(questao);
        }

        public Questao obter(int id_questao)
        {
            return questao_dao.obter(id_questao);
        }

        public List<Questao> obterPorCurso(int id_curso)
        {
            return questao_dao.obterPorCurso(id_curso);
        }

        public int alterarDescricao(int id_questao, string descricao)
        {
            if ((id_questao == 0) || (descricao == ""))
                return 0;

            return questao_dao.alterarDescricao(id_questao, descricao);
        }

        public int alterarDescricao(int id_questao, int id_curso)
        {
            if ((id_questao == 0) || (id_curso == 0))
                return 0;

            return questao_dao.alterarCurso(id_questao, id_curso);
        }
    }
}
