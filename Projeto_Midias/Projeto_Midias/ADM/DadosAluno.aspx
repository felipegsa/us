<%@ Page Language="C#" MasterPageFile="MasterUS.Master" AutoEventWireup="true" CodeBehind="DadosAluno.aspx.cs" Inherits="Projeto_Midias.DadosAluno" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="titulo_campos" style="width: 50%; float:left; padding-left: 100px;">
        <table id="tbCadastro" class="titulo_campos">
        <tr>
            <td class="titulo_campos" style="font-size:small;">
                Nome
            </td>
            <td>
                <asp:TextBox ID="txtNome" runat="server" CssClass="campos_formulario" Width="250px" Height="10px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="titulo_campos" style="font-size:small;">
                E-mail
            </td>
            <td>
                <asp:TextBox ID="txtEmail" runat="server" CssClass="campos_formulario" Width="350px" Height="10px" ></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="titulo_campos" style="font-size:small;">
                Senha
            </td>
            <td>
                <asp:TextBox ID="txtSenha" runat="server" CssClass="campos_formulario" Width="100px" Height="10px"></asp:TextBox>
            </td>
        </tr>
        </table>
          <div style="width: 50%; float:right; padding-left: 100px;">
            <asp:Button ID="btnCadastrar" runat="server" Text="Cadastrar" CssClass="botao" onclick="btnCadastrar_Click"  />
    </div>
    </div>
  
</asp:Content>
