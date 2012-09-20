﻿using System;
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
using BLL;

namespace Projeto_Midias
{
    public partial class Cursos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            BLL.CursoBLL bllCurso = new BLL.CursoBLL();
            List<Model.Curso> meuCursos = new List<Model.Curso>();

            meuCursos = bllCurso.ConsultarCurso();

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
            if (e.Item.DataItem != null)
            {
                Model.Curso curso = (Model.Curso)e.Item.DataItem;

                Literal lblidCurso = (Literal)e.Item.FindControl("lblidCurso");
                Literal lblNomeCurso = (Literal)e.Item.FindControl("lblNomeCurso");
                Literal lblEmailCurso = (Literal)e.Item.FindControl("lblEmailCurso");
                Literal lblAssuntoCurso = (Literal)e.Item.FindControl("lblAssuntoCurso");
                Literal lblTelefoneCurso = (Literal)e.Item.FindControl("lblTelefoneCurso");
                Literal lblHorarioCurso = (Literal)e.Item.FindControl("lblHorarioCurso");
                LinkButton lnkAcaoCurso = (LinkButton)e.Item.FindControl("lnkAcaoCurso");


                lblNomeCurso.Text = curso.Tl_curso;
                lblidCurso.Text = (string)curso.Id_curso.ToString();
                lblAssuntoCurso.Text = curso.Ds_curso;
                lnkAcaoCurso.Text = "Concluido";

            }
        }

        protected void lkd_inserir_Click(object sender, EventArgs e)
        {
            if (txtNome.Text != "" && txtDescricao.Text != "")
            {
                CursoBLL objBLL = new CursoBLL();
                objBLL.Salvar(txtNome.Text, txtDescricao.Text);
            }
            else
            {
                this.ClientScript.RegisterStartupScript(this.GetType(), "show", "<script>alert('Por favor preencha todos os campos.');</script>");
            }
        }
    }
}
