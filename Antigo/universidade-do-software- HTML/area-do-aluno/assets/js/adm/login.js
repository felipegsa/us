// JavaScript Document
$(function(){//COMEÇO JQUERY

//VALIDAÇÃO DO FORM:	
$("#login").validate({
errorLabelContainer: $("#erro"),
rules:{//COMEÃ‡O REGRAS
		login: {
				required: true,
				minlength: 3
			},
		senha: {
				required: true,
				minlength: 3
			}
		
		},//FIM REGRAS
		messages:{//COMEÃ‡O MENSAGENS
			login: "&#8226; Informe o seu Login",
			senha: "&#8226; Informe a sua senha."
	}//FIM MENSAGENS
});//FIM VALIDAÇÃO DO FORM

//VALIDAÇÃO DO FORM:	
$("#form_esqueceu_senha").validate({

rules:{//COMEÃ‡O REGRAS
		login: {
				required: true,
				minlength: 3
			},
		codigo: {
				required: true,
				minlength: 3
			},
		
		},//FIM REGRAS
		messages:{//COMEÃ‡O MENSAGENS
			login: "&#8226; Informe o seu Login",
			codigo: "&#8226; Informe a sua senha."
	}//FIM MENSAGENS
});//FIM VALIDAÇÃO DO FORM

//JANELA ESQUECEU SUA SENHA:
$(".esqueceu_senha").fancybox({
		maxWidth	: 550,

		fitToView	: false,
		width		: '70%',
		height		: 'autoSize',
		autoSize	: false,
		closeClick	: false,
		openEffect	: 'none',
		closeEffect	: 'none'
	});//FIM JANELA ESQUECEU SUA SENHA
	
});//FIM JQUERY