using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL
{
    public class Login
    {
        public void LogarUsuario(string email, string pass)
        {
            DAL.Login bllLogin = new DAL.Login();
            bllLogin.LogarUsuario(email, pass);
        }
    }
}
