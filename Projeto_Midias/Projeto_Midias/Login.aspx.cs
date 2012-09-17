using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

namespace Projeto_Midias
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogar_Click(object sender, EventArgs e)
        {
            BLL.Login bllLogin = new BLL.Login();
            Boolean result = false;
            result = bllLogin.LogarUsuario(txtLogin.Text, txtPass.Text);
            if (result) { 
            Response.Redirect("PerfilAluno.aspx?Nome=" + txtLogin.Text);
            }
        }
    }
}
