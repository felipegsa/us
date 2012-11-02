<%@ Page Language="C#" MasterPageFile="MasterUS.Master" AutoEventWireup="true" CodeBehind="PerfilAluno.aspx.cs" Inherits="Projeto_Midias.WebForm2" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">   
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div class="tabela_dados" style="width: 74%; float:left;">
          <h1 class="titulo_principal">Perfil do Aluno</h1>
          <asp:Repeater ID="rptCursos" runat="server" onitemcommand="rptCursos_ItemCommand" OnItemDataBound="rptCursos_ItemDataBound">
            <HeaderTemplate>
             <table id="todos_contatos">
                <tr>
                <th>Nome</th>
                <th>Descrição</th> 
                <th>Duração</th>
                <th>Data de cadastro</th>
                <th>Ação</th>
            </tr>
            </HeaderTemplate>
            <FooterTemplate>
                </table>
            </FooterTemplate>
            <ItemTemplate>
              <tr>
                <td><asp:Literal ID="lblNomeCurso" runat="server"></asp:Literal></td>
                <td><asp:Literal ID="lblDescricaoCurso" runat="server"></asp:Literal></td>
                <td><asp:Literal ID="lblDuracaoCurso" runat="server"></asp:Literal></td> 
                <td><asp:Literal ID="lblCadastro" runat="server"></asp:Literal></td>
                <td><asp:LinkButton ID="lnkAcaoCurso" runat="server"  CommandName="Acao"></asp:LinkButton></td>
            </tr>
            </ItemTemplate>
          </asp:Repeater>
      
 </div>
</asp:Content>
