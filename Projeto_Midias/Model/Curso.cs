using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    public class Curso
    {
        private int id_curso;
        private string tl_curso;
        private string ds_curso;
        private DateTime dt_cadastro;

        public int Id_curso
        {
            get { return id_curso; }
            set { id_curso = value; }
        }

        public string Tl_curso
        {
            get { return tl_curso; }
            set { tl_curso = value; }
        }

        public string Ds_curso
        {
            get { return ds_curso; }
            set { ds_curso = value; }
        }

        public DateTime Dt_cadastro
        {
            get { return dt_cadastro; }
            set { dt_cadastro = value; }
        }

        public Curso()
        {
            this.Tl_curso = "";
            this.Ds_curso = "";
            this.Dt_cadastro = DateTime.MinValue;
        }
    }
}
