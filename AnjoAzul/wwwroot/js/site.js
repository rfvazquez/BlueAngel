
function escapeRegExp(str) {
    return str.replace(/([.*+?^=!:${}()|\[\]\/\\])/g, "\\$1");
}

function replaceAll(str, find, replace) {
    return str.replace(new RegExp(escapeRegExp(find), 'g'), replace);
}

$(document).ready(function () {
    $(".menu").click(function () {
        if ($(".menu-bg").is(":visible")) {
            $(".menu-bg").fadeOut(300);
            $(".painel").removeClass("blur");
        }
        else {
            $(".menu-bg").fadeIn(300);
            $(".painel").addClass("blur");
        }
    });

    $(".menu-bg").click(function () {
        $(".painel").removeClass("blur");
        $(".menu-bg").fadeOut(300);
    });

    $(".box-sm-c").show();
    $(".box-m-c").show();
    $(".box-c").show();
    $(".box").show();
});

function Logout() {
    var pdataAnx = {};
    $.ajax({
        type: 'POST',
        url: $("#LogoutUrl").val(),
        data: pdataAnx,
        success: function (result) {
            window.location.href = result;
        }
    });
}

function MonstraMensagem(tipo, mensagem) {
    $("#divMsg").attr("style", "display:block");
    $("#divMsg").attr("class", tipo);
    $("#pmsg").html(mensagem);
    $("#divMsg").show(300);
}

function MonstraMensagemModal(tipo, mensagem) {
    $("#divMsgModal").attr("style", "display:block");
    $("#divMsgModal").attr("class", tipo);
    $("#pmsgModal").html(mensagem);
    $("#divMsgModal").show(300);
}

function AbreAguarde() {
    $("#divModalAguarde").modal();
}

function FechaAguarde() {
    $("#divModalAguarde").hide();
}


function AbrirAlterarSenha() {
    $("#divAlterarSenha").modal();
}
function FecharNovaSenha() {
    $("#divAlterarSenha").modal('hide');
}
function SalvarNovaSenha() {
    if ($("#txtAntigaSenha").val() === "") {
        MonstraMensagemModal("error", "Senha antiga não pode ser vazia!");
        $("#txtAntigaSenha").focus();
        return;
    }
    if ($("#txtNovaSenha").val() === "") {
        MonstraMensagemModal("error", "Senha nova não pode ser vazia!");
        $("#txtNovaSenha").focus();
        return;
    }
    var pdataAnx = {};

    MonstraMensagemModal("wait", "Realizando a troca de senha. Aguarde!");
    pdataAnx["novaSenha"] = $("#txtNovaSenha").val();
    pdataAnx["senhaAntiga"] = $("#txtAntigaSenha").val();

    $.ajax({
        type: 'POST',
        url: $("#AlterarSenhaUrl").val(),
        data: pdataAnx,
        success: function (resultAnexo) {
            if (resultAnexo.includes("Erro")) {
                MonstraMensagemModal("error", resultAnexo);
            } else {
                $("#txtNovaSenha").val("");
                $("#txtAntigaSenha").val("");
                $("#divAlterarSenha").modal('hide');
                MonstraMensagem("wait", "Senha Alterada com sucesso!");
            }
        }
    });
}

