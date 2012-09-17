using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Xml.Linq;

namespace Projeto_Midias
{
    public partial class DadosAluno : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btnCadastrar_Click(object sender, EventArgs e) {
            Model.Aluno objAluno = new Model.Aluno();
            objAluno.Email = txtEmail.Text;
            objAluno.Nome = txtNome.Text;
            objAluno.Senha = txtSenha.Text;

            try
            {
                BLL.Aluno bllAluno = new BLL.Aluno();
                bllAluno.CadastrarAluno(objAluno);
            }
            catch (Exception ex)
            {                
                throw new Exception(ex.Message);
            }
           
        }
    }
}
