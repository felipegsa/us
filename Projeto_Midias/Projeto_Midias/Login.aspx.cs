﻿using System;
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
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogar_Click(object sender, EventArgs e)
        {
            try
            {
                BLL.Login bllLogin = new BLL.Login();
                Boolean result = false;
                bllLogin.LogarUsuario(txtLogin.Text, txtPass.Text);              
                Response.Redirect("PerfilAluno.aspx?Nome=" + txtLogin.Text);
            }
            catch (ApplicationException ex)
            {
                
            }
           
        }
    }
}
