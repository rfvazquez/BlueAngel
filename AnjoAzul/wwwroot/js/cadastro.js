function cadastroUsuario() {
    var pdata = {};
    pdata["nome"] = $("#txtNome").val();
    pdata["sobrenome"] = $("#txtSobrenome").val();
    pdata["senha"] = $("#txtSenha").val();
    pdata["confSenha"] = $("#txtConfirmaSenha").val();
    pdata["email"] = $("#txtEmail").val();

    //Validações de campo
    if (pdata["nome"] === "" || pdata["sobrenome"] === "" || pdata["senha"] === "" ||
        pdata["confSenha"] === "" || pdata["email"] === "") {
        MonstraMensagem("error", "Todos os campos são de preenchimento obrigatório");
        return;
    }

    //Validação de senhas iguais
    if (pdata["senha"] != pdata["confSenha"]) {
        MonstraMensagem("error", "As senhas informadas não são iguais");
        return;
    }

    //Força Senha
    var regexForte = new RegExp("^(?=.*[a-z])(?=.*[A-Z])(?=.*[0-9])(?=.*[!@#\$%\^&\*])(?=.{8,})");
    if (!(regexForte.test(pdata["senha"]))) {
        MonstraMensagem("error", "A senha deve conter:\r\n - 8 Caracteres \r\n - 1 Letra Minúscula \r\n" +
            " - 1 Letra Maiúscula \r\n - 1 Número \r\n - 1 Caracter Especial ");
        return;
    }

    MonstraMensagem("wait", "Por favor, Aguarde...!");

    $.ajax({
        url: $("#CadastroUrl").val(),
        data: pdata,
        type: 'POST',
        success: function (result) {
            if (result.indexOf("Erro") > -1) {
                MonstraMensagem("error", result);
                return;
            }
            window.location.href = result;
        }
    });
}

//Valida força da senha apresentando a força da mesma
function forçaSenha() {
    var regexForte = new RegExp("^(?=.*[a-z])(?=.*[A-Z])(?=.*[0-9])(?=.*[!@#\$%\^&\*])(?=.{8,})");
    var regexMedio = new RegExp("^(?=.*[a-z])(?=.*[A-Z])(?=.*[0-9])(?=.{6,})");
    if (regexForte.test($("#txtSenha").val())) {
        $("#forçaSenha").css({ 'background-color': 'green' });
    }
    else if (regexMedio.test($("#txtSenha").val())) {
        $("#forçaSenha").css({ 'background-color': 'yellow' });
    }
    else {
        $("#forçaSenha").css({ 'background-color': 'red' });
    }
}

