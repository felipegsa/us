// JavaScript Document
function excluir_noticia(id,nome)
{
	var resposta = confirm('Deseja excluir a Noticia '+ nome +'?');
	
	if (resposta)
	{
		 //INICIA METODO AJAX:
          $.ajax({

               type: "GET",
               url: URL + "adm/excluir_noticia/"+id,
               success: function(resposta)
               {
                    //if(resposta == 1)
                    //{
                        alert('Notícia '+nome+' excluída com sucesso!');
                        window.location.reload(true);
                    //}
                    //else
                    //{
                    	//alert('Erro ao tentar apagar esta subcategoria. Certifique-se que não exista nenhuma produtos atrelados a ela.');
                    //}
               }
    
          });//FIM METODO AJAX:
	}
}

$(function(){//COMEÇO JQUERY

//AJUDA:
$("#cadastro_noticias img[title]").tooltip();	

//VALIDAÇÃO DO FORM:	
$("#cadastro_noticias").validate({
rules:{//COMEÃ‡O REGRAS
		noticia: {
				required: true,
				minlength: 3
			},

		data:{
				required: true
				
			},
                            descricao:{
                                 
                                                        required: true,
		                           minlength: 3
                            },
                            fonte: {
				required: true
				
			}
                        
                            
		
		},//FIM REGRAS
		messages:{//COMEÃ‡O MENSAGENS
			noticia: "&#8226; Informe o nome da noticia",

			data: "&#8226; Informe a data.",
                        
                                           descricao: "&#8226; Informe a descrição da noticia",
                                           
                                           fonte: "&#8226; Informe a descrição da noticia"
			
	}//FIM MENSAGENS
	
});//FIM VALIDAÇÃO

//TABLE SORTER:
$("#todas_noticias").tablesorter(); 

//MASCARA DATA:
$("#data").mask("99/99/9999");


$( "#data" ).datepicker();
// CONFIGURAÇÃO DO DATEPICKER DO JQUERYUI PARA PT-BR
$.datepicker.setDefaults({dateFormat: 'dd/mm/yy',
                          dayNames: ['Domingo','Segunda','Terça','Quarta','Quinta','Sexta','Sábado','Domingo'],
                          dayNamesMin: ['D','S','T','Q','Q','S','S','D'],
                          dayNamesShort: ['Dom','Seg','Ter','Qua','Qui','Sex','Sáb','Dom'],
                          monthNames: ['Janeiro','Fevereiro','Março','Abril','Maio','Junho','Julho','Agosto','Setembro', 'Outubro','Novembro','Dezembro'],
                          monthNamesShort: ['Jan','Fev','Mar','Abr','Mai','Jun','Jul','Ago','Set', 'Out','Nov','Dez'],
                          nextText: 'Próximo',
                          prevText: 'Anterior'
                         });
                         
//FANCYBOX MINIATURAS DO FABRICANTE:
$('.img_fabricante').fancybox();

});//FIM JQUERY