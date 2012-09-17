using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL
{
    public class Login
    {
        public Boolean LogarUsuario(string email, string pass)
        {
            Boolean retorno = false;
            DAL.Login bllLogin = new DAL.Login();
            return bllLogin.LogarUsuario(email, pass);
        }
    }
}
