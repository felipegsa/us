using System;
using System.Collections.Generic;
using System.Text;
using Model.Enum;

namespace Model
{
    public class Questao
    {
        public int ID_questao { get; set; }
        public string Ds_questao { get; set; }
        public Curso Curso_obj { get; set; }
        public DateTime Dt_cadastro { get; set; }

        public Questao()
        {
            Ds_questao = "";
            Curso_obj = new Curso();
            Dt_cadastro = DateTime.MinValue;
        }
    }
}