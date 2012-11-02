// JavaScript Document
$(function(){//COMEÇO JQUERY

//AJUDA:
$("#cadastro_fabricantes img[title]").tooltip();	

//VALIDAÇÃO DO FORM:	
$("#cadastro_fabricantes").validate({
rules:{//COMEÃ‡O REGRAS
	
		fabricante: {
				required: true
			}

		},//FIM REGRAS
		messages:{//COMEÃ‡O MENSAGENS
			fabricante: "&#8226; Informe o nome do fabricante"

	}//FIM MENSAGENS
	
});//FIM VALIDAÇÃO

//FANCYBOX MINIATURAS DO FABRICANTE:
$('.img_fabricante').fancybox();

});//FIM JQUERY