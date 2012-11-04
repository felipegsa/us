using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;
using Model;

namespace BLL
{
    class Resposta_BLL
    {
        public Resposta_dao resposta_dao;

        public Resposta_BLL()
        {
            this.resposta_dao = new Resposta_dao();
        }

        public int salvar(Resposta nova_resposta)
        {
            if (nova_resposta == null)
                return 0;

            if ((nova_resposta.Ds_resposta == "") || (nova_resposta.Questao_obj.Id_questao == 0))
                return 0;

            return resposta_dao.salvar(nova_resposta);
        }

        public Resposta obter(int id_resposta)
        {
            return resposta_dao.obter(id_resposta);
        }

        public List<Resposta> obterPorQuestao(int id_questao)
        {
            return resposta_dao.obterPorQuestao(id_questao);
        }

        public int alterarDescricao(int id_resposta, string descricao)
        {
            if ((id_resposta == 0) || (descricao == ""))
                return 0;

            return resposta_dao.alterarDescricao(id_resposta, descricao);
        }

        public int alterarQuestao(int id_resposta, int id_questao)
        {
            if ((id_resposta == 0) || (id_questao == 0))
                return 0;

            return resposta_dao.alterarQuestao(id_resposta, id_questao);
        }

        public int alterarCorreta(int id_resposta, bool correta)
        {
            return resposta_dao.alterarCorreta(id_resposta, correta);
        }
    }
}
