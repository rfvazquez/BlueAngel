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


function MonstraMensagem(tipo, mensagem) {
    $("#divMsg").attr("style", "display:block");
    $("#divMsg").attr("class", tipo);
    $("#pmsg").html(mensagem);
    $("#divMsg").show(300);
}