<%@ Page Language="C#" MasterPageFile="~/MasterUS.Master" AutoEventWireup="true" CodeBehind="PerfilAluno.aspx.cs" Inherits="Projeto_Midias.WebForm2" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">   
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div class="tabela_dados" style="width: 74%; float:left;">
          <h1 class="titulo_principal">Perfil do Aluno</h1>
          <asp:Repeater ID="rptCursos" runat="server" onitemcommand="rptCursos_ItemCommand" OnItemDataBound="rptCursos_ItemDataBound">
            <HeaderTemplate>
             <table id="todos_contatos">
                <tr>
                <th width="50">Id</th>
                <th>Nome</th>
                <th>E-mail</th>
                <th>Assunto</th> 
                <th>Telefone</th>
                <th>Data / Hora</th>
                <th>Ação</th>
            </tr>
            </HeaderTemplate>
            <FooterTemplate>
                </table>
            </FooterTemplate>
            <ItemTemplate>
              <tr>
                <td width="50"><asp:Literal ID="lblidCurso" runat="server"></asp:Literal></td>
                <td><asp:Literal ID="lblNomeCurso" runat="server"></asp:Literal></td>
                <td><asp:Literal ID="lblEmailCurso" runat="server"></asp:Literal></td>
                <td><asp:Literal ID="lblAssuntoCurso" runat="server"></asp:Literal></td> 
                <td><asp:Literal ID="lblTelefoneCurso" runat="server"></asp:Literal></td>
                <td><asp:Literal ID="lblHorarioCurso" runat="server"></asp:Literal></td>
                <td><asp:LinkButton ID="lnkAcaoCurso" runat="server"  CommandName="Acao"></asp:LinkButton></td>
            </tr>
            </ItemTemplate>
          </asp:Repeater>
      
 </div>
</asp:Content>
