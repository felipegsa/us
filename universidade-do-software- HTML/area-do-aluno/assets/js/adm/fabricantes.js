// JavaScript Document
function excluir_fabricante(id,nome)
{
	var resposta = confirm('Deseja excluir o fabricante '+ nome);
	
	if (resposta)
	{
		 //INICIA METODO AJAX:
          $.ajax({

               type: "GET",
               url: URL + "adm/excluir_fabricante/"+id,
               success: function()
               {
                    alert('Fabricante '+ nome +' excluído com sucesso!');
					window.location.reload(true);
               }
    
          });//FIM METODO AJAX:
	}
}

$(function(){//COMEÇO JQUERY

//AJUDA:
$("#cadastro_fabricantes img[title]").tooltip();	

//VALIDAÇÃO DO FORM:	
$("#cadastro_fabricantes").validate({
rules:{//COMEÃ‡O REGRAS
		arquivo: {
				required: true
			},
		fabricante: {
				required: true
			}

		},//FIM REGRAS
		messages:{//COMEÃ‡O MENSAGENS
			arquivo: "&#8226; Selecione o arquivo do fabricante",
			fabricante: "&#8226; Informe o nome do fabricante"

	}//FIM MENSAGENS
	
});//FIM VALIDAÇÃO

//TABLE SORTER:
$("#todos_fabricantes").tablesorter(); 

//FANCYBOX MINIATURAS DO FABRICANTE:
$('.img_fabricante').fancybox();

});//FIM JQUERY