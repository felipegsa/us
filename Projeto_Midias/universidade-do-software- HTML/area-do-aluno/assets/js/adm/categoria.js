// JavaScript Document
function excluir_categoria(id,nome)
{
	var resposta = confirm('Deseja excluir a categoria '+ nome +'?');
	
	if (resposta)
	{
		 //INICIA METODO AJAX:
          $.ajax({

               type: "GET",
               url: URL + "adm/excluir_categoria/"+id,
               success: function(resposta)
               {
                    if(resposta == 1)
                    {
						alert('Categoria '+nome+' excluída com sucesso!');
						window.location.reload(true);
                    }
                    else
                    {
                    	alert('Erro ao tentar apagar esta categoria. Certifique-se que não exista nenhuma subcategoria ou produtos atrelados a ela.');
                    }
                    
               }
    
          });//FIM METODO AJAX:
	}
}

$(function(){//COMEÇO JQUERY

//AJUDA:
$("#cadastro_rapido_categorias img[title]").tooltip();	

//VALIDAÇÃO DO FORM:	
$("#cadastro_rapido_categorias").validate({
rules:{//COMEÃ‡O REGRAS
		categoria: {
				required: true,
				minlength: 3
			}

		},//FIM REGRAS
		messages:{//COMEÃ‡O MENSAGENS
			categoria: "&#8226; Informe o nome da categoria"

	}//FIM MENSAGENS
	
});//FIM VALIDAÇÃO

//TABLE SORTER:
$("#todas_categorias").tablesorter(); 

});//FIM JQUERY