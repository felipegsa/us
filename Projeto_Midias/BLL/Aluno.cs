using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace BLL
{
    public class Aluno
    {
        public byte[] GetImage(string id) 
            {
                DAL.Aluno dalAluno = new DAL.Aluno();
               byte[] stream = new byte[0];
                stream = dalAluno.GetImage(id);

                return stream;
                //aqui se tiver alguma regra de negocio será implemtandada aqui
            }
        public void CadastrarAluno(Model.Aluno pAluno)
        {
            DAL.Aluno dalAluno = new DAL.Aluno();
            if (pAluno.Senha.Length < 6) { 
                throw new Exception("É necessário tem no minímo 6 caracteres na senha!");
            }
            dalAluno.CadastrarAluno(pAluno);
        }
    }      
}
