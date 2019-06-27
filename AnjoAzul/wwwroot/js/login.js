function FuncaoLogin() {
    var pdata = {};
    pdata["login"] = $("#login").val();
    pdata["senha"] = $("#senha").val();

    if (pdata["login"] === "") {
        MonstraMensagem("error", "Login não pode ser em braco!");
        return;
    }

    if (pdata["senha"] === "") {
        MonstraMensagem("error", "Senha não pode ser em branco!");
        return;
    }

    MonstraMensagem("wait", "Por favor, Aguarde...!");

    $.ajax({
        url: $("#LoginUrl").val(),
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


function EsqueciSenha() {
    MonstraMensagemModal("wait", "Enviando E-Mail!");
    var pdata = {};
    pdata["email"] = $("#txtLoginEqueci").val();

    if (pdata["email"] === "") {
        MonstraMensagemModal("error", "Campo E-Mail não pode ser Branco!");
        return;
    }

    $.ajax({
        url: $("#EsqueciSenhaUrl").val(),
        data: pdata,
        type: 'POST',
        success: function (result) {
            if (result.includes("Erro")) {
                MonstraMensagemModal("error", result);
                return;
            } else {
                $("#divEsqueciSenha").modal('hide');
                MonstraMensagem("wait", result);
                return;
            }
        }
    });
}


function AbreEsqueciSenha() {
    $("#divEsqueciSenha").modal();
}