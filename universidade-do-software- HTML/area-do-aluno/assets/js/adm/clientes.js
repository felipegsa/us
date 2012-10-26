// JavaScript Document
function excluir_cliente(id,nome)
{
	var resposta = confirm('Deseja excluir o cliente '+ nome +' ?');
	
	if (resposta)
	{
                    //INICIA METODO AJAX:
                    $.ajax({

                        type: "GET",
                        url: URL + "adm/excluir_cliente/"+id,
                        success: function()
                        {
                                if(resposta == 1)
                                {
                                    alert('Cliente '+nome+' excluído com sucesso!');
                                    window.location.reload(true);
                                }
                                else
                                {
                                    alert('Erro ao tentar apagar esta cliente. Isto pode acontecer caso o mesmo tenha realizado algum pedido.');
                                }
                        }

                    });//FIM METODO AJAX:
	}
}

$(function(){//COMEÇO JQUERY

//TABLE SORTER:
$("#todos_clientes").tablesorter();

//AJUDA:
$("#cadastro_clientes img[title]").tooltip();	

});//FIM JQUERY