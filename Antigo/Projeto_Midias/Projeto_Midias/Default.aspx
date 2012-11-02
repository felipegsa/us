<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Projeto_Midias._Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
      <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
    <div>
        <!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />

<meta name="language" content="portuguese, PT-BR, português" />
<meta name="author" content="Fundação Sandto André" />
<meta name="date" content="18/04/2012" />
<meta name="copyright" content="Universidade de Software" />
<meta name="company" content="Universidade de Software" />
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

<title>Universidade do Software - FSA 2012</title>
    <link href="css/reset.css" rel="stylesheet" type="text/css" />
    <link href="css/estilobase.css" rel="stylesheet" type="text/css" />
    <link href="css/inicio.css" rel="stylesheet" type="text/css" />
    <link href="css/login.css" rel="stylesheet" type="text/css" />
    

<script type="text/javascript" src="../assets/js/jquery-1.7.2.min.js"></script>
<script type="text/javascript" src="../assets/js/jquery.validate.min.js"></script>
<script type="text/javascript" src="../assets/js/jquery.tools.min.js"></script>
<script type="text/javascript" src="../assets/js/adm/geral.js"></script>
<script type="text/javascript" src="../assets/js/adm/inicio.js"></script>
<script src="../jQuery.js" type="text/javascript"></script>

<script type="text/javascript">
$(function(){

	$('.adiciona').click(function(){
		$('#tbCursos').children().last().append('<tr><td>Linha1</td><td>Linha1</td><td>Linha1</td><td>Linha1</td><td><a href="#" title="Ver Contato"  class="remove">Excluir</a></td></tr>');
		removeRow(this);
	});

	function removeRow(target){		
		target.parent().parent().remove();
		addCourse();
	}
	
	$('.remove').click(function () {	
		var row = $('#tbCursos').children().length;		
		
		if (row > 1) {
			$(this).parent().parent().remove();
		}
  });
});
	
function changeTab(tab){
	if(tab == 'perfil'){ 
		var elem = document.getElementById("div_perfil"); 
		elem.style.display = 'block';
		var elem = document.getElementById("div_cursos"); 
		elem.style.display = 'none';

	}
	else if (tab == 'cursos'){
		var elem = document.getElementById("div_perfil"); 
		elem.style.display = 'none';
		var elem = document.getElementById("div_cursos"); 
		elem.style.display = 'block';

	}
	else{ alert('other tab'); 
	}

}

function addCourse(){alert('Curso Adicionado com sucesso. Parabéns você agora pode conferir todos os videos e opções de aprendizados.');}

</script>

</head>

<body>

<!-- LAYOUT -->
<div class="layout">

<!-- TOPO -->
<div class="topo">
	<h1><a href="#" title="Universidade do Software">Universidade do Software - Área do Aluno</a></h1>
</div>
<!-- FIM TOPO -->

<!-- MENU PRINCIPAL -->
<div class="menu_principal">
    <ul>
        <li class="btn_menu_principal" onclick="changeTab('perfil');"><a href="#" title="Perfil">Perfil</a></li>
        <li class="btn_menu_principal_precionado" onclick="changeTab('cursos');"><a href="#" title="Cursos">Cursos</a></li>
        <li class="btn_menu_principal_precionado"><a href="#" title="Jogos">Jogos</a></li>
		<li class="btn_menu_sair" style="width:44px; margin-right:0;"><a href="#" title="Sair">Sair</a></li>
    </ul>
</div>
<!-- FIM MENU PRINCIPAL -->

<!-- CORPO LAYOUT-->
<div class="corpo">

<h1 class="titulo_principal">Olá, Antonio Leonardo</h1>

<!-- COLUNA 1 -->
<div class="coluna1">

<div id="div_perfil" class="caixa">
<h2 class="titulo_secundario">Cursos em Andamento:</h2>
    
    <div class="tabela_dados">
    <table id="todos_contatos">
        <thead>
            <tr>
                <th width="50">Id</th>
                <th>Nome</th>
                <th>E-mail</th>
                <th>Assunto</th>
                <th>Telefone</th>
                <th>Data / Hora</th>
                <th>Ação</th>
            </tr>
        </thead>
        <tbody>
        
        <tr>
            <td>TESTE</td>
            <td>TESTE</td>
            <td>TESTE</td>
            <td>TESTE</td>
            <td>TESTE</td>
            <td>TESTE</td>
            <td>
                <a href="#" title="Ver Contato">Ola</a>
            </td>
        </tr>
   
        </tbody>
    </table>
    </div>


</div>
</div>

<!-- COLUNA 2 -->
<div class="coluna1">

<div id="div_cursos" class="caixa" style='display:none'>
<h2 class="titulo_secundario">Cursos disponíveis:</h2>
    
    <div class="tabela_dados">
    <table id="tbCursosDisp">
        <thead>
            <tr>
                <th>Curso</th>
                <th>Horas</th>
                <th>Qtde. Videos</th>
                <th>Instrutor</th>
                <th>Ação</th>               
            </tr>
        </thead>
        <tbody>
        
        <tr>
            <td>ITIL</td>
            <td>30 hrs</td>
            <td>6 videos</td>
            <td>Rubens Sales</td>          
            <td>
                <a href="#" title="Ver Contato" class="adiciona">Adicionar</a>
            </td>
        </tr>
   
        </tbody>
    </table>
    </div>
	
	<h2 class="titulo_secundario">Cursos Adicionados:</h2>
    
    <div class="tabela_dados">
    <table id="tbCursos">
        <thead>
            <tr>
                <th>Curso</th>
                <th>Horas</th>
                <th>Qtde. Videos</th>
                <th>Instrutor</th>
                <th>Ação</th>               
            </tr>
        </thead>
        <tbody>
        
        <tr>
            <td>COBIT</td>
            <td>40 hrs</td>
            <td>6 videos</td>
            <td>Denis Fernandes</td>          
            <td><a href="#" title="Ver Contato" class="remove">Excluir</a></td>
        </tr>
		<tr>
            <td>Qualidade de Sw</td>
            <td>40 hrs</td>
            <td>7 videos</td>
            <td>Tamyres Rodrigues</td>          
            <td><a href="#" title="Ver Contato"  class="remove">Excluir</a></td>
        </tr>
   
        </tbody>
    </table>
    </div>


</div>
</div>
<!-- FIM COLUNA 1 -->

<!-- COLUNA 2 -->
<div class="coluna2">

<div class="caixa_especial">
<h2 class="titulo_secundario">Últimos Cursos Cadastrados:</h2>


	<!-- PRODUTO -->
	<div class="ultimos_produtos">
		<h3 class="titulo_terceiro">TESTE</h3>
		<div class="img" style="background-image:; background-color:#fff; background-position:center center; background-repeat:no-repeat;"></div>
	    <p><a href="#" title="Editar">Editar</a> | <a href="#" title="Visualizar" target="_blank">Visualizar</a></p>
	</div>
	<!-- FIM PRODUTO -->
	

<h2 class="titulo_secundario">Pesquisar Curso:</h2>
<form action="" method="post">
<input name="pesquisa" type="text" class="campos_formulario" style="width: 128px; float: left;" value="" onFocus="if(this.value=='Pesquisar...')this.value='';" />
<input type="submit" value="Pesquisar" class="btn_submit" style="display:block; float:right;" />
<span class="clear"></span>
</form>
</div>
</div>
<!-- FIM COLUNA 2 -->

<span class="clear"></span>

</div>
<!-- FIM CORPO LAYOUT-->

</div>
<!-- LAYOUT -->

<p style="text-align:center">Sistema Aluno Universidade do Software 1.0 &copy; 2012 &nbsp;&nbsp;<a href="http://www.universidadedosoftware.com.br" title="Universidade do Software"><img src="../assets/img/adm/layout/logo-universidade.png" width="78" height="26" alt="Universidade do Software" /></a><br/>
Recomendações Mínimas: Internet Explorer 8 ou Firefox 3.6. Navegador Recomendável: Google Chrome Resolução de 1024px por 768px.</p>

</body>
</html>
    </div>
    </form>
</body>
</html>
