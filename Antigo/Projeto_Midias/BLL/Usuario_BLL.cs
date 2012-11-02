using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;
using DAL;

namespace BLL
{
    public class Usuario_BLL
    {
        private Usuario_dal usuario_dal;

        public Usuario_BLL()
        {
            this.usuario_dal = new Usuario_dal();
        }

        public int salvar(Usuario novo_usuario)
        {
            // aqui poderia ser criada uma regra de negócio. Por exemplo a verificação se o usuário já não foi cadastrado
            return usuario_dal.salvar(novo_usuario);
        }

        public List<Usuario> obter()
        {
            return usuario_dal.obter();
        }

        public Usuario obter(int id_usuario)
        {
            return usuario_dal.obter(id_usuario);
        }

        public Usuario obter(string email_usuario)
        {
            return usuario_dal.obter(email_usuario);
        }

        public Usuario obter(string email_usuario, string senha)
        {
            // este método pode ser usado para validar/logar um usuário, independentemente se é administrador ou aluno
            return usuario_dal.obter(email_usuario, senha);
        }

        public int alterar(Usuario usuario)
        {
            // aqui poderiam ser implementadas regras para alteração de usuário
            return usuario_dal.alterar(usuario);
        }

        public int excluir(int id_usuario)
        {
            // aqui poderiam ser implementadas regras para exclusão de um usuário, por exemplo, criar um histórico do aluno.
            // Esta exclusão é além de excluir o registro da tabela USUARIO, também irá excluir os registros das tabelas USUARIO_CURSO, USUARIO_AULA.
            // Pois foi implementado um DROP CASCADE.
            return usuario_dal.excluir(id_usuario);
        }
    }
}