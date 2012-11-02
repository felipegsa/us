// JavaScript Document
$(function(){//COMEÇO JQUERY

//AJUDA:
$("#cadastro_rapido_produtos img[title], #cadastro_rapido_categorias img[title], #cadastro_rapido_subcategorias img[title]").tooltip();	

//VALIDAÇÃO DO FORM:	
$("#cadastro_rapido_produtos").validate({
rules:{//COMEÃ‡O REGRAS
		nome: {
				required: true,
				minlength: 3
			},
		codigo: {
				required: true,
				minlength: 3
			},
		subcategoria:{
				required: true,
				min: 1
				}
		
		},//FIM REGRAS
		messages:{//COMEÃ‡O MENSAGENS
			nome: "&#8226; Informe o nome do produto",
			codigo: "&#8226; Informe o código de referência.",
			subcategoria: "&#8226; Informe a categoria."
	}//FIM MENSAGENS
	
});//FIM VALIDAÇÃO

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

//VALIDAÇÃO DO FORM:	
$("#cadastro_rapido_subcategorias").validate({
rules:{//COMEÃ‡O REGRAS
		nome: {
				required: true,
				minlength: 3
			},
		codigo: {
				required: true,
				minlength: 3
			},
		categoria:{
				required: true,
				min: 1
			}
		
		},//FIM REGRAS
		messages:{//COMEÃ‡O MENSAGENS
			nome: "&#8226; Informe o nome da subcategoria",
			codigo: "&#8226; Informe o código de referência.",
			categoria: "&#8226; Informe a categoria."
			
	}//FIM MENSAGENS
	
});//FIM VALIDAÇÃO

});//FIM JQUERY