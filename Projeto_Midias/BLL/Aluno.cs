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
                var stream = new MemoryStream();
                stream = dalAluno.GetImage(id);

                return stream;
                //aqui se tiver alguma regra de negocio será implemtandada aqui
            }        
      }
}
