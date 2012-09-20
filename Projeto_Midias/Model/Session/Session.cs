using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;

namespace Model.Session
{
    public  static class Session
    {
        public static Aluno Aluno
        {
            get { return (Aluno)HttpContext.Current.Session["Aluno"]; }
            set { HttpContext.Current.Session["Aluno"] = value; }
        }
    }
}
 