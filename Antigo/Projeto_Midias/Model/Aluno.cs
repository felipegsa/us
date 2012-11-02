using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    public class Aluno
    {
        private int _id;
        private string _nome;
        private string _email;
        private string _senha;
        private List<Curso> _cursoCadastrado;
        public int Id {
            get
            { return this._id; }
            set
            { this._id = value; }
        }
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
        public string Senha
        {
            get
            { return this._senha; }
            set
            { this._senha = value; }
        }
        public List<Curso> CursoCadastrado
        {
            get
            { return this._cursoCadastrado; }
            set
            { this._cursoCadastrado = value; }
        }
      }
}
