using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    public class Curso
    {
        public int Id_curso { get; set; }
        public string Tl_curso { get; set; }
        public string Ds_curso { get; set; }
        public string Obj_curso { get; set; }
        public string Topicos_curso { get; set; }
        public string Pre_req_curso { get; set; }
        public string Duracao_curso { get; set; }
        public DateTime Dt_cadastro { get; set; }

        public Curso()
        {
            this.Tl_curso = "";
            this.Ds_curso = "";
            this.Obj_curso = "";
            this.Topicos_curso = "";
            this.Pre_req_curso = "";
            this.Duracao_curso = "";
            this.Dt_cadastro = DateTime.MinValue;
        }
    }
}
