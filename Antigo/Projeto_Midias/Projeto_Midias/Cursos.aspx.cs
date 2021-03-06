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
using Model;

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
            

            int vIdCurso = Convert.ToInt32(e.CommandArgument);         
                       
            BLL.Aluno bllAluno = new BLL.Aluno();
            bllAluno.CadastrarAlunoXCurso(vIdCurso);
            Response.Redirect("PerfilAluno.aspx");            
        }
        protected void rptCursos_ItemDataBound(Object Sender, RepeaterItemEventArgs e)
        {
            if (e.Item.DataItem != null)
            {
                Model.Curso curso = (Model.Curso)e.Item.DataItem;

                Literal lblidCurso = (Literal)e.Item.FindControl("lblidCurso");
                Literal lblNomeCurso = (Literal)e.Item.FindControl("lblNomeCurso");
                Literal lblDsCurso = (Literal)e.Item.FindControl("lblDsCurso");
                Literal lblDuracaoCurso = (Literal)e.Item.FindControl("lblDuracaoCurso");
                Literal lblDataCadastro = (Literal)e.Item.FindControl("lblDataCadastro");
                LinkButton lnkCadastrar = (LinkButton)e.Item.FindControl("lnkCadastrar");


               
                lblidCurso.Text = curso.Id_curso.ToString();
                lblNomeCurso.Text = curso.Tl_curso;
                lblDsCurso.Text = curso.Ds_curso;
                lblDuracaoCurso.Text = curso.Duracao_curso;
                lblDataCadastro.Text = curso.Dt_cadastro.ToString();
                lnkCadastrar.Text = "Cadastrar-se";
                lnkCadastrar.CommandArgument = curso.Id_curso.ToString();

            }
        }

        protected void lkd_inserir_Click(object sender, EventArgs e)
        {
            if (txtNome.Text != "" && txtDescricao.Text != "")
            {
                CursoBLL objBLL = new CursoBLL();
                Curso novo_curso = new Curso();

                // só serão inseridos os campos que até o momento a interface suporta
                novo_curso.Tl_curso = txtNome.Text;
                novo_curso.Ds_curso = txtDescricao.Text;

                // grava o novo curso e retorna seu ID_CURSO
                objBLL.salvar(novo_curso);
            }
            else
            {
                this.ClientScript.RegisterStartupScript(this.GetType(), "show", "<script>alert('Por favor preencha todos os campos.');</script>");
            }
        }
    }
}
