using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Collections.Generic;
namespace Projeto_Midias
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //BLL.CursoBLL bllCurso = new BLL.CursoBLL();
            //List<Model.Curso> meuCursos = new List<Model.Curso>();

            //meuCursos = bllCurso.ConsultarCurso();
           
            //rptCursos.DataSource = meuCursos;
            //rptCursos.DataBind();
            rptCursos.DataSource = Model.Session.Session.Aluno.CursoCadastrado;
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

                Literal lblNomeCurso = (Literal)e.Item.FindControl("lblNomeCurso");
                Literal lblDescricaoCurso = (Literal)e.Item.FindControl("lblDescricaoCurso");
                Literal lblDuracaoCurso = (Literal)e.Item.FindControl("lblDuracaoCurso");
                Literal lblCadastro = (Literal)e.Item.FindControl("lblCadastro");
                LinkButton lnkAcaoCurso = (LinkButton)e.Item.FindControl("lnkAcaoCurso");


                lblNomeCurso.Text = curso.Tl_curso;
                lblDescricaoCurso.Text = curso.Ds_curso;
                lblDuracaoCurso.Text = curso.Duracao_curso;
                lblCadastro.Text = curso.Dt_cadastro.ToString();
                lnkAcaoCurso.Text = "Concluido";

            }
        }
    }
}