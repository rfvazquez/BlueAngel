﻿function FuncaoLogin() {
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

    $.ajax({
        url: $("#LoginUrl").val(),
        data: pdata,
        type: 'POST',
        success: function (result) {
            if (result.indexOf("Erro") > -1) {
                $(".error").slideDown(300);
                return;
            }
            window.location.href = result;
        }
    });
}