using System;
using System.Collections.Generic;
using System.Text;
using Model.Enum;

namespace Model
{
    public class Resposta
    {
        public int id_resposta { get; set; }
        public string Ds_resposta { get; set; }
        public bool FL_correta { get; set; }
        public Questao Questao_obj { get; set; }
        public DateTime Dt_cadastro { get; set; }

        public Resposta()
        {
            Ds_resposta = "";
            FL_correta = false;
            Questao_obj = new Questao();
            Dt_cadastro = DateTime.MinValue;
        }
    }
}