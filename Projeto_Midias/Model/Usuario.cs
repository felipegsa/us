using System;
using System.Collections.Generic;
using System.Text;
using Model.Enum;

namespace Model
{
    public class Usuario
    {
        public int Id_usuario { get; set; }
        public Tipo_usuario Tipo { get; set; }
        public string Nm_usuario { get; set; }
        public string Email_usuario { get; set; }
        public string Senha_usuario { get; set; }

        // pasta/arquivo do sistema onde será armazenada a imagem do usuário (para posteriormente ser carregada dinamicamente)
        public string Link_imagem_usuario { get; set; }

        public DateTime Dt_cadastro { get; set; }

        public Usuario()
        {
            Tipo = Tipo_usuario.NONE;
            Nm_usuario = "";
            Email_usuario = "";
            Senha_usuario = "";
            Link_imagem_usuario = "";
            Dt_cadastro = DateTime.MinValue;
        }
    }
}