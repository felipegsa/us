// JavaScript Document
function excluir_usuario(id,nome)
{
	var resposta = confirm('Deseja excluir o usuário '+ nome +'?');
	
	if (resposta)
	{
		 //INICIA METODO AJAX:
          $.ajax({

               type: "GET",
               url: URL + "adm/excluir_usuario/"+id,
               success: function()
               {
                    alert('Usuário '+nome+' excluída com sucesso!');
					window.location.reload(true);
               }
    
          });//FIM METODO AJAX:
	}
}

$(function(){//COMEÇO JQUERY

//AJUDA:
$("#configuracoes_sistema img[title], #novo_usuario img[title]").tooltip();	

//MASCARA PARA TELEFONES:
$("#telefone").mask("(99) 9999-9999");

//VALIDAÇÃO DO FORM:	
$("#configuracoes_sistema").validate({
rules:{//COMEÃ‡O REGRAS
		loja: {
				required: true,
				minlength: 3
			},
		telefone: "required",
		endereco: "required",
		email: {
				required: true,
				email: true
			}		
		},//FIM REGRAS
		messages:{//COMEÃ‡O MENSAGENS
			loja: "&#8226; Informe o nome da sua loja",
			telefone: "&#8226; Informe o seu número de telefone.",
			endereco: "&#8226; Informe o endereço da loja.",
			email: "&#8226; Informe um endereço de e-mail válido."


	}//FIM MENSAGENS
	
});//FIM VALIDAÇÃO

//VALIDAÇÃO DO FORM:	
$("#novo_usuario").validate({
rules:{//COMEÃ‡O REGRAS
		nome: {
				required: true,
				minlength: 3
			},
		login: {
				required: true,
				minlength: 4
			},
		senha: {
				required: true,
				minlength: 4
			},
		email: {
				required: true,
				email: true
			}		
		},//FIM REGRAS
		messages:{//COMEÃ‡O MENSAGENS
			nome: "&#8226; Informe o nome do usuário",
			login: "&#8226; Informe o login do usuário (mínimo de 4 caracteres).",
			senha: "&#8226; Informe a senha do usuário (mínimo de 4 caracteres).",
			email: "&#8226; Informe um endereço de e-mail válido."


	}//FIM MENSAGENS
	
});//FIM VALIDAÇÃO

//TABLE SORTER:
$("#todos_usuarios").tablesorter(); 
//FIM TABLE SORTER:

});//FIM JQUERY