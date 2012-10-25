using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL
{
    public class ExceptionDAL : ApplicationException
    {
        private string _mensagem = string.Empty;
        public string Mensagem
        {
            get
            { return this._mensagem; }
            set
            { this._mensagem = value; }
        }
        public ExceptionDAL(string pMensage, Exception pException) : base(pMensage) {
        }
        public ExceptionDAL(string pMensage) : base(pMensage){
        }
    }
}
