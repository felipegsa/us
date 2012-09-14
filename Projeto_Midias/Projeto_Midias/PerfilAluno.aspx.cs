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
using System.Collections.Generic;
namespace Projeto_Midias
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            BLL.Aluno bllAluno = new BLL.Aluno();
            var stream = new MemoryStream();
            stream = bllAluno.GetImage(1);

            BLL.CursoBLL bllCurso = new BLL.CursoBLL();
            List<Model.Curso> meuCursos = new List<Model.Curso>();

            meuCursos = bllCurso.ConsultarCurso();
            
            Model.Curso objCurso;   
   

            List<Model.Curso> listObjCurso = new List<Model.Curso>();

            for (int i = 0; i < 15; i++)
            {
                objCurso = new Model.Curso();
                objCurso.Id = i;
                objCurso.Nome = "nome" + i;
                objCurso.Assunto = "Assunto" + i;
                objCurso.Telefone = i;
                objCurso.Data = DateTime.Now;
                if (i < 3)
                {
                    objCurso.Acao = Model.Enum.EAcaoCurso.Concluido;
                }
                else
                {
                    objCurso.Acao = Model.Enum.EAcaoCurso.Fazer;
                }
                listObjCurso.Add(objCurso);
            }
            rptCursos.DataSource = meuCursos;
            rptCursos.DataBind();
        }

        protected void rptCursos_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "Concluido")
               //TODO chamar o a tela com o pdf e o certificado
                throw new Exception("Falta implementar o certificado");
            else if (e.CommandName == "Fazer")
                //TODO chamar o a tela com a aula à fazer
                throw new Exception("Falta implementar o as aulas");
        }
        protected void rptCursos_ItemDataBound(Object Sender, RepeaterItemEventArgs e)
        {
            if (e.Item.DataItem != null) {
                Model.Curso curso = (Model.Curso)e.Item.DataItem;

                Literal lblidCurso = (Literal)e.Item.FindControl("lblidCurso");
                Literal lblNomeCurso = (Literal)e.Item.FindControl("lblNomeCurso");
                Literal lblEmailCurso = (Literal)e.Item.FindControl("lblEmailCurso");
                Literal lblAssuntoCurso = (Literal)e.Item.FindControl("lblAssuntoCurso");
                Literal lblTelefoneCurso = (Literal)e.Item.FindControl("lblTelefoneCurso");
                Literal lblHorarioCurso = (Literal)e.Item.FindControl("lblHorarioCurso");
                LinkButton lnkAcaoCurso = (LinkButton)e.Item.FindControl("lnkAcaoCurso");


                lblNomeCurso.Text = curso.Nome;
                lblidCurso.Text = (string)curso.Id.ToString();
                lnkAcaoCurso.Text = "Concluido";

            }
        }
    }
}