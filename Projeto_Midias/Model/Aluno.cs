using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    public class Aluno
    {   
        private string _nome;
        private string _email;
        private Curso _cursoCadastrado;
        public string Nome { 
            get 
                {return this._nome;} 
            set 
                {this._nome = value;} }
        public string Email
        {
            get
            { return this._email; }
            set
            { this._email = value; }
        }
        public Curso CursoCadastrado
        {
            get
            { return this._cursoCadastrado; }
            set
            { this._cursoCadastrado = value; }
        }
      }
}
