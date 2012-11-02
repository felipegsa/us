<%@ Page Language="C#" MasterPageFile="MasterUS.Master" AutoEventWireup="true" CodeBehind="Adm_Cursos.aspx.cs" Inherits="Projeto_Midias.ADM.Adm_Cursos" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <script type="text/javascript" language="javascript">
       
       //JS

</script>

    <style type="text/css">
        .style1
        {
            width: 245px;
        }
    </style>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="corpo" visible="false">
    <h1 class="titulo_principal">Cadastrar Cursos</h1>
    <table>
        
        <tr>
            <td>Nome do Curso:</td>
            <td class="style1"><asp:TextBox ID="txtNome" runat="server" Font-Size="8pt" Width="269px"></asp:TextBox></td>            
        </tr>
        <tr>
            <td>Objetivo:</td>
            <td class="style1"><asp:TextBox ID="txtObjetivo" runat="server" Font-Size="8pt" Width="269px"></asp:TextBox></td>
            <td>Duração:</td>
            <td><asp:TextBox ID="txtDuracao" runat="server" Font-Size="8pt"></asp:TextBox></td>
        </tr>
        <tr>
            <td>Descrição:</td>
            <td colspan="3"><asp:TextBox ID="txtDescricao" runat="server" Font-Size="8pt" Height="62px" Width="625px"></asp:TextBox></td>
        </tr>
        <tr>
            <td>Tópicos:</td>
            <td class="style1"><asp:TextBox ID="txtTopicos" runat="server" Font-Size="8pt" Width="269px"></asp:TextBox></td>
            <td>Pré-Requisitos:</td>
            <td><asp:TextBox ID="txtPreRequisitos" runat="server" Font-Size="8pt" Width="269px"></asp:TextBox></td>
        </tr>
        <tr>
            <td>Aula:</td>
            <td class="style1"><asp:TextBox ID="txtAula" runat="server" Font-Size="8pt" Width="269px"></asp:TextBox></td>
            <td>Descrição:</td>
            <td><asp:TextBox ID="txtDescricaoAula" runat="server" Font-Size="8pt" Width="269px"></asp:TextBox></td>
            <td>Link:</td>
            <td><asp:TextBox ID="txtLink" runat="server" Font-Size="8pt"></asp:TextBox></td>
        </tr>
    </table>
</div>

<div class="tabela_dados" style="width: 81%; float:left;">
          <asp:Repeater ID="rptCursos" runat="server" onitemcommand="rptCursos_ItemCommand" OnItemDataBound="rptCursos_ItemDataBound">
            <HeaderTemplate>
             <table id="todos_contatos">
                <tr>
                <th width="50">Id</th>
                <th>Nome</th>
                <th>Descrição</th>
                <th>Objetivo</th> 
                <th>Tópicos</th>
                <th>Pré-Requisitos</th>
                <th>Duração</th>
                <th>Data de Cadastro</th>                
            </tr>
            </HeaderTemplate>
            <FooterTemplate>
                </table>
            </FooterTemplate>
            <ItemTemplate>
              <tr>
                <td width="50"><asp:Literal ID="lblidCurso" runat="server"></asp:Literal></td>
                <td><asp:Literal ID="lblNomeCurso" runat="server"></asp:Literal></td>
                <td><asp:Literal ID="lblDsCurso" runat="server"></asp:Literal></td>
                <td><asp:Literal ID="lblObjetivo" runat="server"></asp:Literal></td> 
                <td><asp:Literal ID="lblTopicos" runat="server"></asp:Literal></td> 
                <td><asp:Literal ID="lblPreRequisitos" runat="server"></asp:Literal></td> 
                <td><asp:Literal ID="lblDuracao" runat="server"></asp:Literal></td> 
                <td><asp:Literal ID="lblDataCadastro" runat="server"></asp:Literal></td>                
            </tr>
            </ItemTemplate>
          </asp:Repeater>
          
          <div style="text-align:center">
              <tr>
                <td><asp:Button id="btnInserir" runat="server" Text="Inserir" 
                  onclick="btnInserir_Click1" /></td>
                <td>&nbsp;</td>
                <td><asp:Button id="btnAlterar" runat="server" Text="Alterar"/></td>
                <td>&nbsp;</td>
                <td><asp:Button id="btnExcluir" runat="server" Text="Excluir"/></td>           
              </tr>                            
         </div>
 </div> 

</asp:Content>
