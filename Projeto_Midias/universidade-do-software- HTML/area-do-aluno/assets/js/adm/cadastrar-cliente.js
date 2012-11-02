// JavaScript Document
$(function(){//COMEÇO JQUERY

//AJUDA:
$("#cadastro_clientes img[title]").tooltip();	

//MASCARA PARA TELEFONE E CEP:
$("#telefone,#celular").mask("(99) 9999-9999");
$("#cep").mask("99999-999");

//VALIDAÇÃO DO FORM:	
$("#cadastro_clientes").validate({
rules:{//COMEÇO REGRAS
		nome: {
			required: true,
			minlength: 3,
			maxlength:150
		},
		email: {
			maxlength:150,
		    required: true,
		    email: true
		},
		telefone: {
			required: true
		},
		estado: {
			required: true
		},
		cidade: {
			required: true
		},
        bairro: {
			required: true,
			minlength: 3,
			maxlength:150
		},
		cep: {
			required: true
		},
        ativo: {
			required: true
		},
		logadouro: {
			required: true,
			minlength: 3,
			maxlength:150
		},
                            senha: {
			required: true,
                                           minlength: 4
		},
                            numero: {
			required: true
		}

		},//FIM REGRAS
		messages:{//COMEÇO MENSAGENS
			nome: "&#8226; Informe o nome do cliente",
			email: "&#8226; Informe um endereço de e-mail válido",
			telefone: "&#8226; Informe o telefone do cliente",
			estado: "&#8226; Informe o estado onde o cliente mora",
			cidade: "&#8226; Informe a cidade onde o cliente mora",
			bairro: "&#8226; Informe o bairro onde o cliente mora.",
                                           logadouro: "&#8226; Informe o nome da rua onde o cliente mora.",
			cep: "&#8226; Informe o cep do cliente.",
			ativo: "&#8226; Informe se o cliente vai estar disponível no catalogo.",
			senha: "&#8226; Informe uma senha de no mínimo 4 e máximo 8 caracteres.",
                                           numero: "&#8226; Informe o número da casa do cliente."
	}//FIM MENSAGENS
	
});//FIM VALIDAÇÃO

});//FIM JQUERY