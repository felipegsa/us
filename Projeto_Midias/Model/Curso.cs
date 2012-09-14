using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    public class Curso
    {
        private int _id;
        private String _nome;
        private String _email;
        private String _assunto;
        private int _telefone;
        private DateTime _data;
        private Enum.EAcaoCurso _acao;
        public int Id
        {
            get
            {
                return this._id;
            }
            set
            {
                this._id = value;
            }
        }
        public string Nome
        {
            get
            {
                return this._nome;
            }
            set
            {
                this._nome = value;
            }
        }
        public string Email
        {
            get
            {
                return this._email;
            }
            set
            {
                this._email = value;
            }
        }
        public string Assunto
        {
            get
            {
                return this._assunto;
            }
            set
            {
                this._assunto = value;
            }
        }
        public int Telefone
        {
            get
            {
                return this._telefone;
            }
            set
            {
                this._telefone = value;
            }
        }
        public DateTime Data
        {
            get
            {
                return this._data;
            }
            set
            {
                this._data = value;
            }
        }
        public Enum.EAcaoCurso Acao
        {
            get {
                return this._acao;
            }
            set {
                this._acao = value;
            }
        }
    }
}
