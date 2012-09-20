<%@ Page Language="C#" MasterPageFile="~/MasterUS.Master" AutoEventWireup="true" CodeBehind="Cursos.aspx.cs" Inherits="Projeto_Midias.Cursos" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript" language="javascript">
        function Inserir(){
            window.open("Cursos_Inserir.aspx", "Inserir","toolbar=no,location=no,status=no,menubar=no,scrollbars=no,resizable=no,width=300,height=300");
        }   
    </script>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

<div class="corpo">
    <table>
        
        <tr>
            <td>Curso:</td>
            <td><asp:TextBox ID="txtNome" runat="server" Font-Size="8pt"></asp:TextBox></td>
        </tr>
        <tr>
            <td>Descrição:</td>
            <td><asp:TextBox ID="txtDescricao" runat="server" Font-Size="8pt"></asp:TextBox></td>
        </tr>
        <tr>
            <td align="center"><asp:LinkButton ID="lkd_inserir" runat="server" Text="Cadastrar" onclick="lkd_inserir_Click"></asp:LinkButton></td>
            <td>&nbsp;</td>
            <td align="center"><asp:LinkButton ID="lkd_limpar" runat="server" Text="Limpar"></asp:LinkButton></td>
                                
        </tr>
    </table>
</div>


<div class="tabela_dados" style="width: 74%; float:left;">
          <h1 class="titulo_principal">Cursos Cadastrados</h1>
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
