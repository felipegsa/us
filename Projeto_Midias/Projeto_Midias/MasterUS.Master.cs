using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;

namespace Projeto_Midias
{
    public partial class MasterUS : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lblSaudacao.Text = Model.Session.Session.Aluno.Nome;
            lblNome.Text = Model.Session.Session.Aluno.Nome;
        }
    }
}
