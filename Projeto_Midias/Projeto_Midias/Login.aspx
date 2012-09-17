<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Projeto_Midias.Login" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml"><head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />

<meta name="language" content="portuguese, PT-BR, português" />
<meta name="author" content="Plataformanet Mídia On-line http://www.plataformanet.com.br/" />
<meta name="date" content="18/04/2012" />
<meta name="copyright" content="Lojas Kamikawa Móveis Para Escritório" />
<meta name="company" content="Lojas Kamikawa Móveis Para Escritório" />
<meta name="rating" content="General" />
<meta name="classification" content="Internet" />
<meta name="doc-class" content="completed" />
<meta name="doc-rights" content="public" />
<meta name="resource-type" content="document" />
<meta name="expires" content="0" />
<meta name="robots" content="noindex,nofollow">
<meta http-equiv="cache-control" content="no-cache" />
<meta http-equiv="pragma" content="no-cache" />
<meta http-equiv="content-language" content="pt-br">
<meta http-equiv="X-UA-Compatible" content="IE=7" />
<link rel="shortcut icon" type="image/x-icon" href="../favicon.ico" />

<title>Login do Usuário</title>
<link href="css/reset.css" rel="stylesheet" type="text/css"  />
<link href="css/estilobase.css" rel="stylesheet" type="text/css"  />
<link href="css/adm/login.css" rel="stylesheet" type="text/css"  />
<link href="css/jquery.fancybox.css" rel="stylesheet" type="text/css" />
<!--[if lte IE 6]><script src="http://imasters.uol.com.br/crossbrowser/fonte.js" type="text/javascript"></script><![endif]-->

<style type="text/css">
.campos_formulario{width:192px;}
</style>

<script type="text/javascript" src="js/jquery-1.7.2.min.js"></script>
<script type="text/javascript" src="js/jquery.validate.min.js"></script>
<script type="text/javascript" src="js/jquery.fancybox.pack.js"></script>
<script type="text/javascript" src="js/adm/geral.js"></script>
<script type="text/javascript" src="js/adm/login.js"></script>

</head>

<body>

<!-- ERRO -->
<div id="erro" style="width: 342px;">
</div>
<!-- ERRO -->

<!-- FORMULÁRIO ESQUECEU SUA SENHA -->
<div style="display:none;">
	<div id="esqueceu_senha">
	
    <p>Informe o seu <strong>Login de Acesso ao sistema</strong> e o <strong>código de segurança</strong> para receber no seu e-mail cadastrado as informações necessárias.</p>
    
    <br />
    
    <form action="" method="post" name="login" id="form_esqueceu_senha">
	<table>
	  <tr>
	    <td><label for="login" class="titulo_campos">*Login:</label></td>
	    <td><input name="login" type="text" class="campos_formulario" style="width:450px;" /></td>
	  </tr>
	  <tr>
	    <td><label for="codigo" class="titulo_campos">*Código:</label></td>
	    <td><input name="codigo" type="password" class="campos_formulario" style="width:450px;" /></td>
	  </tr>
	  <tr>
	    <td>&nbsp;</td>
	    <td>&nbsp;</td>
	  </tr>
	  <td colspan="2" style="text-align:center;">
	      <input type="submit" name="button" id="button" value="Enviar" class="btn_submit" /></td>
	    </tr>
	</table>
	</form>
    
	</div>
</div>
<!-- FIM FORMULÁRIO ESQUECEU SUA SENHA -->

<!-- LOGIN -->
<div class="login">
<h1>Universidade do Software - Perfil do aluno</h1>
<h2>Digite os seus dados para o acesso:</h2>

<form id="login" runat="server">
<table>
  <tr>
    <td><label for="login" class="titulo_campos">Login:</label></td>
    <td><asp:TextBox ID="txtLogin" CssClass="campos_formulario" runat="server"></asp:TextBox></td>
  </tr>
  <tr>
    <td><label for="senha" class="titulo_campos">Senha:</label></td>
    <td><asp:TextBox ID="txtPass" CssClass="campos_formulario" runat="server" TextMode="Password"></asp:TextBox></td>
  </tr>
  <tr>
    <td>&nbsp;</td>
    <td>&nbsp;</td>
  </tr>
  <td colspan="2" style="text-align:center;">  
       <asp:Button ID="btnLogar" runat="server" Text="Logar" CssClass="botao" 
           onclick="btnLogar_Click" />
      <a class="esqueceu_senha" href="#esqueceu_senha" title="">Esqueceu sua senha?</a>
      </td>
    
</table>
</form>

</div>
<!-- FIM LOGIN -->

<p style="text-align:center">Sistema Aluno Universidade do Software 1.0 &copy; 2012&nbsp;&nbsp;<a href="http://www.universidadedosoftware.com.br" title="Universidade do Software"><img src="img/adm/layout/logo-universidade.png" width="78" height="26" alt="Universidade do Software" /></a><br/>
Recomendações Mínimas: Internet Explorer 8 ou Firefox 3.6. Navegador Recomendável: Google Chrome Resolução de 1024px por 768px.</p>

</body>
</html>