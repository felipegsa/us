// JavaScript Document
function excluir_subcategoria(id,nome)
{
	var resposta = confirm('Deseja excluir a subcategoria '+ nome +'?');
	
	if (resposta)
	{
		 //INICIA METODO AJAX:
          $.ajax({

               type: "GET",
               url: URL + "adm/excluir_subcategoria/"+id,
               success: function(resposta)
               {
                    //if(resposta == 1)
                    //{
						alert('Subcategoria '+nome+' excluída com sucesso!');
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
$("#cadastro_subcategorias img[title]").tooltip();	

//VALIDAÇÃO DO FORM:	
$("#cadastro_subcategorias").validate({
rules:{//COMEÃ‡O REGRAS
		subcategoria: {
				required: true,
				minlength: 3
			},

		categoria:{
				required: true,
				min: 1
			}
		
		},//FIM REGRAS
		messages:{//COMEÃ‡O MENSAGENS
			subcategoria: "&#8226; Informe o nome da subcategoria",

			categoria: "&#8226; Informe a categoria."
			
	}//FIM MENSAGENS
	
});//FIM VALIDAÇÃO

//TABLE SORTER:
$("#todas_subcategorias").tablesorter(); 

});//FIM JQUERY