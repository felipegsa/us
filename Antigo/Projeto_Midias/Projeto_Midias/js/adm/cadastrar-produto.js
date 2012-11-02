// JavaScript Document
$(function(){//COMEÇO JQUERY

//AJUDA:
$("#cadastro_produtos img[title]").tooltip();	

//FORMATAÇÃO DE MOEDA:
$('#preco,#promocao').priceFormat({
    prefix: '',
    centsSeparator: ',',
    thousandsSeparator: '.'
});

$('#peso').priceFormat({  
    prefix: '',  
    centsSeparator: '.',  
    centsLimit: 3,  
    thousandsSeparator: ''  
}); 

//VALIDAÇÃO DO FORM:	
$("#cadastro_produtos").validate({
rules:{//COMEÇO REGRAS
		produto: {
			required: true,
			minlength: 3,
			maxlength:150
		},
		modelo: {
			maxlength:150
		},
		disponibilidade: {
			required: true,
			minlength: 3,
			maxlength:150
		},
		garantia: {
			required: true,
			maxlength:100
		},
		peso: {
			required: true
		},
		preco: {
			required: true
		},
		ativo: {
			required: true
		},
		destaque: {
			required: true
		}

		},//FIM REGRAS
		messages:{//COMEÇO MENSAGENS
			categoria: "&#8226; Escolha a categoria do produto",
			produto: "&#8226; Informe o nome do produto (Mínimo 3 caracteres, máximo 150.)",
			modelo: "&#8226; Tamanho máximo 150 caracteres.",
			disponibilidade: "&#8226; Informe a disponibilidade do produto (Mínimo 3 caracteres, máximo 150.)",
			garantia: "&#8226; Informe a garantia do produto (Mínimo 3 caracteres, máximo 150.)",
			peso: "&#8226; Informe o peso do produto.",
			preco: "&#8226; Informe o preço do produto.",
			ativo: "&#8226; Informe se o produto vai estar disponível no catalogo.",
			destaque: "&#8226; Informe se o produto vai estar disponível na home."

	}//FIM MENSAGENS
	
});//FIM VALIDAÇÃO

//SUBCATEGORIAS:
$('#categoria').change(function(){

	categoria = $(this).val();

	//INICIA METODO AJAX:
  	$.ajax({

	       type: "GET",
	       url: URL + "adm/lista_subcategorias_adm/" + categoria,
	       success: function(subcategorias)
	       {
	            if(subcategorias != 0)
	            {
            		$("#subcategoria").removeAttr('disabled');
	            	$("#subcategoria").html(subcategorias);
	            }
	            else
	            {
	            	 $('#subcategoria').attr('disabled','disabled');
	            	$("#subcategoria").html('<option selected="selected" value="">Selecione a categoria</option>');
	            }
	           
	       }

  		});//FIM METODO AJAX:
});

//FANCYBOX MINIATURAS DO FABRICANTE:
$('.img_fabricante').fancybox();

});//FIM JQUERY