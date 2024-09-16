$(document).ready(function () {
    // Usa a variável JavaScript para obter o ClientID do controle hidden
    var mensagemErro = $('#' + hfMensagemErroClientID).val();

    if (mensagemErro) {
        Swal.fire({
            title: "Erro",
            text: mensagemErro,
            icon: "error"
        });
    }
});
