function BuscaCEP() {
    var cep = replaceAll($("#txtCep").val(), "-", "");
    var script = document.createElement('script');
    script.src = 'https://viacep.com.br/ws/' + cep + '/json/?callback=RetornoCEP';
    document.body.appendChild(script);
}

function RetornoCEP(conteudo) {
    if (!("erro" in conteudo)) {
        $("#txtEndereco").val(conteudo.logradouro);
        $("#txtBairro").val(conteudo.bairro);
        $("#txtCidade").val(conteudo.localidade);
        $("#txtEstado").val(conteudo.uf);
    } 
    else {
        MonstraMensagem("error", "CEP não encontrado.");
    }
}