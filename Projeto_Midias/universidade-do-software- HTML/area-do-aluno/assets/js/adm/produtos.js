// JavaScript Document
function excluir_produto(id,nome)
{
	var resposta = confirm('Deseja excluir o produto '+ nome +'?');
	
	if (resposta)
	{
		 //INICIA METODO AJAX:
          $.ajax({

               type: "GET",
               url: URL + "adm/excluir_produto/"+id,
               success: function(resposta)
               {
                    if(resposta == 1)
                    {
                              alert('Produto '+nome+' excluído com sucesso!');
                              window.location.reload(true);
                    }
                    else
                    {
                         alert('Erro ao tentar apagar este produto. E possível que o mesmo esteja atrelado a algum pedido realizado no site. Se você quer simplesmente retira-lo do site, deixe-o desativado.');
                    }
               }
    
          });//FIM METODO AJAX:
	}
}

$(function(){//COMEÇO JQUERY

//TABLE SORTER:
$("#todos_produtos").tablesorter();

//FANCYBOX MINIATURAS DO FABRICANTE:
$('.img_fabricante').fancybox();
});//FIM JQUERY