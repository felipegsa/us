// JavaScript Document
$(function(){//COMEÇO JQUERY

//AJUDA:
$("#editar_usuario img[title], #editar_usuario img[title]").tooltip();	

//VALIDAÇÃO DO FORM:	
$("#editar_usuario").validate({
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
				required: false,
				minlength: 4
			},
		email: {
				required: true,
				email: true
			},		
		},//FIM REGRAS
		messages:{//COMEÃ‡O MENSAGENS
			nome: "&#8226; Informe o nome do usuário",
			login: "&#8226; Informe o login do usuário (mínimo de 4 caracteres).",
			senha: "&#8226; Informe a senha do usuário (mínimo de 4 caracteres).",
			email: "&#8226; Informe um indereço de e-mail válido."


	}//FIM MENSAGENS
	
});//FIM VALIDAÇÃO

});//FIM JQUERY