// JavaScript Document
function excluir_banner(id)
{
	var resposta = confirm('Deseja excluir o banner selecionado ?');
	
	if (resposta)
	{
		 //INICIA METODO AJAX:
          $.ajax({

               type: "GET",
               url: URL + "adm/excluir_banner/"+id,
               success: function()
               {
                    alert('Banner excluído com sucesso!');
					window.location.reload(true);
               }
    
          });//FIM METODO AJAX:
	}
}

$(function(){//COMEÇO JQUERY

//AJUDA:
$("#cadastro_banners img[title]").tooltip();	

//VALIDAÇÃO DO FORM:	
$("#cadastro_banners").validate({
rules:{//COMEÃ‡O REGRAS
		arquivo: {
				required: true,
				minlength: 3
			}

		},//FIM REGRAS
		messages:{//COMEÃ‡O MENSAGENS
			arquivo: "&#8226; Selecione o arquivo do banner"

	}//FIM MENSAGENS
	
});//FIM VALIDAÇÃO

//TABLE SORTER:
$("#todos_banners").tablesorter();

//FANCYBOX MINIATURAS DO BANNER:
$('.img_banner').fancybox();

});//FIM JQUERY