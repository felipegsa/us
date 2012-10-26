using System;
using System.Collections.Generic;
using System.Text;
using Model.Enum;

namespace Model
{
    public class Aula
    {
        public int Id_aula { get; set; }
        public string Tl_aula { get; set; }
        public string Ds_aula { get; set; }
        public Curso Curso_obj { get; set; }
        public string Link_aula { get; set; }
        public DateTime Dt_cadastro { get; set; }

        public Aula()
        {
            Tl_aula = "";
            Ds_aula = "";
            Curso_obj = new Curso();
            Link_aula = "";
            Dt_cadastro = DateTime.MinValue;
        }
    }
}