<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="Projeto_Midias.index" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Universidade do Software</title>
    <link href="css/reset.css" rel="stylesheet" type="text/css" />
    <link href="css/estilo-base.css" rel="stylesheet" type="text/css" />
    <link href="css/default.css" rel="stylesheet" type="text/css" />
    <link href="css/nivo-slider.css" rel="stylesheet" type="text/css" />

    <script src="js/jquery-1.7.2.min.js" type="text/javascript"> </script> 
    <script src="js/jquery.nivo.slider.js" type="text/javascript"> </script> 
    <script src="js/jquery.nivo.slider.pack.js" type="text/javascript"> </script> 

    <script type="text/javascript">
    $(window).load(function() {
    	
	    $('#slider').nivoSlider({});
    	
	    $('#btn-login').click(function(){
    		
		    $('#login').show();
	    });
    	
	    $('#btn-fechar-login').click(function(){
    		
		    $('#login').hide();
	    });
    	
     });
    </script>
    
</head>
<body>
    <form id="form1" runat="server">
    <div>

        <!-- INICIO DO SITE -->
        <div id="corpo">
        	
            <!-- INICIO DO TOPO -->
	        <div id="topo">
            	
                <h1 class="logo">
                Universidade do Software
                </h1>
                
                <div id="btn-login">
                <p><a href="#">Área de acesso de <br />
		        alunos e Professoers</a></p>
                </div>
                
                <div id="login">
                <span>Faça seu Login:</span> <p id="btn-fechar-login"> Fechar [X]</p>
                <form action="#" id="form-login" method="post">
       	          <label id="nm-aluno" for="aluno"> Aluno </label>
                  <input id="aluno" name="tipo_login" type="radio" value="aluno" />
                  
                  <label id="nm-professor" for="professor"> Professor </label>
                  <input id="professor" name="tipo_login" type="radio" value="professor" />
                  
                  <label id="nm-login" for="login"> Login:</label>	
                  <input  id="input-login" name="login" type="text" value="login" />       
                  <label id="nm-senha" for="senha"> Senha:</label>
                  <input  id="input-senha" name="senha" type="text" value="senha" />  	 
                  <input  id="input-ok" name="ok" type="submit" value="Ok" onclick="window.open('../ADM/Adm_Cursos.aspx?nm=' + $('#input-login').val());" />
                </form>
                
                <p class="txt-login"> Esqueceu sua Senha? </p>
                </div>
                
        <!-- INICIO DO MENU PRINCIPAL -->
        <div id="menu">
        	        <ul>
            	        <li><a href="index.aspx">Inicio</a></li>
                        <li class="separa-menu"></li>
                        <li><a href="portal.aspx">O Portal</a></li>
                        <li class="separa-menu"></li>
                        <li><a href="cursos.aspx">Cursos</a></li>
                        <li class="separa-menu"></li>
                        <li><a href="atendimento.aspx">Atendimento</a></li>
                        <li class="separa-menu"></li>
                        <li style="width:184px;"><a href="colaboradores.aspx" style="width:178px;">Colaboradores</a></li>
                        
                    </ul>
                </div>
                <!-- /INICIO DO MENU PRINCIPAL -->
                
                <!-- BANNER -->
                <div id="banner">
                
                    <div class="slider-wrapper theme-default">
                        
                        <div class="ribbon"></div>	
                        
                        <div id="slider" class="nivoSlider">
                        
                        <a href="#"><img src="images/01.jpg" title="COBIT - Gestão de TI " alt="Universidade do Software" /></a>
                        <a href="#"><img src="images/02.jpg" title="Gestão de Projetos" alt="Gestão de Projetos" /></a>
                        <a href="#"><img src="images/03.jpg" title="Metodologias Agéis" alt="Metodologias Agéis" /></a>
                        <a href="#"><img src="images/04.jpg" title="Qualidade de Software" alt="Qualidade de Software" /></a>
                        <a href="#"><img src="images/05.jpg" title="Qualidade de Software" alt="Qualidade de Software" /></a>
                        <a href="#"><img src="images/06.jpg" title="Qualidade de Software" alt="Qualidade de Software" /></a>
                        </div>

                    </div>
                	
                </div>
                <!-- / BANNER -->
                </div>
                <!-- / FIM TOPO -->
                
                <!-- INICIO DO CONTEUDO -->
                <div id="conteudo">
                
        	        <!-- DIV DESTAQUES - CURSOS  -->
        	        <div id="destaques-cursos">
            	        <h1> Cursos em Destaques </h1>
        				
                        <div class="bloco-home">
                        <h2>LOREM IPSUM </h2>
            	        <img src="images/img-home.jpg" title="Curso  1" alt="Curso 1" />
				        <p class="txt-home"><a href="#">Pulvinar odio hac mus adipiscing scelerisque duis pellentesque? Amet sed magna elementum, placerat aliquam? Rhoncus massa adipiscing. Scelerisque adipiscing ut. In?</a></p>
                        </div>
                        
                        <div class="bloco-home">
                        <h2>LOREM IPSUM </h2>
            	        <img src="images/img-home.jpg" title="Curso  2" alt="Curso 2" />
				        <p class="txt-home"><a href="#">Pulvinar odio hac mus adipiscing scelerisque duis pellentesque? Amet sed magna elementum, placerat aliquam? Rhoncus massa adipiscing. Scelerisque adipiscing ut. In?</a></p>
                        </div>
                        
                        <div class="bloco-home">
                        <h2>LOREM IPSUM </h2>
            	        <img src="images/img-home.jpg" title="Curso  3" alt="Curso  3" />
				        <p class="txt-home"><a href="#">Pulvinar odio hac mus adipiscing scelerisque duis pellentesque? Amet sed magna elementum, placerat aliquam? Rhoncus massa adipiscing. Scelerisque adipiscing ut. In?</a></p>
                        </div>
                        
                        <div class="bloco-home">
                        <h2>LOREM IPSUM </h2>
            	        <img src="images/img-home.jpg" title="Curso  4" alt="Curso  4" />
				        <p class="txt-home"><a href="#">Pulvinar odio hac mus adipiscing scelerisque duis pellentesque? Amet sed magna elementum, placerat aliquam? Rhoncus massa adipiscing. Scelerisque adipiscing ut. In?</a></p>
                        </div>
                        
                    </div>
                    <!-- / DIV DESTAQUES - CURSOS  -->
                    
                    <!-- DIV COLABORADORES -->
                    <div id="colaboradores">
            	        <h2> Colaboradores </h2>
                        
                        <span> Antonio Leonardo </span>
            	        <img src="images/img-colaboradores.jpg" title="Antonio Leonardo" alt="Antonio Leonardo" />                
                        <p class="txt-home">Pulvinar odio hac mus adipiscing scelerisque duis pellentesque? Amet sed magna elementum, placerat aliquam? Rhoncus massa adipiscing. Scelerisque adipiscing ut. In?</p>
                        
          	        </div>
                    <!-- / DIV COLABORADORES -->
                    
                    <!-- DIV DEPOIMENTOS -->
                    <div id="depo">
                        <h1> Depoimentos </h1>
                        
                        <img src="images/img-depo.jpg" title="Aluno Curso x" alt="Aluno Curso x" />
                        
                        <div id="txt">
                            <div id="aspas1"></div>
                            <p class="txt-depo">Pellentesque cras nisi penatibus et dis cursus porta tincidunt tincidunt egestas rhoncus integer dolor nunc et risus? Aenean tortor ultrices porta ac et? Turpis pellentesque. Turpis cras massa? Ultrices scelerisque tristique placerat sit? Aliquam quis, et amet arcu platea. Vut aenean elementum porttitor auctor? Risus. Nascetur vel placerat in.</p>
                            <span>Nome Completo <br />
                Curso realizado pelo aluno</span>  
                            <div id="aspas2"></div>
            	        </div>
                    </div>
			        <!--/ DIV DEPOIMENTOS -->
                    
                    <!-- DIV ALUNO DO MES -->
                    <div id="aluno-mes">
           	          <h3> Aluno do Mês </h3>
                        <img src="images/img-aluno.jpg" title="Erica Lima" alt="Erica Lima" />
                        <span> Erica Lima <br />Gestão de Projetos</span>
                    </div>
                    <!-- / DIV ALUNO DO MES -->
                
                </div>
                <!-- / DIV CONTEUDO -->	
        </div>
        <!--/ DIV  FIM DO LAYOUT -->

        <!-- DIV RODAPE -->
        <div id="rodape">
        <p>© Copyright 2012 - Todos os direitos reservados - Desenvolvido por Plataformanet</p>
        <a href="#"><img class="facebook" src="images/facebook.jpg" title="Universidade do Software - Facebook" alt="Universidade do Software - Facebook" /></a>
        <a href="#"><img class="twitter" src="images/twitter.jpg" title="Universidade do Software - Twitter" alt="Universidade do Software - Twitter" /></a>
        </div>
        <!--/ RODAPE -->
                
    </div>
    </form>
</body>
</html>
