$(document).ready(function () {
    $('.truncar-titulo').on('click', function () {
        $(this).toggleClass('titulo-completo');
    });

    $('.truncar-descricao').on('click', function () {
        $(this).toggleClass('descricao-completa');
    });

    $('.btn-excluir').on('click', function (e) {
        e.preventDefault(); // Previne o comportamento padrão do botão

        var tarefaID = $(this).attr('CommandArgument');
        if (!tarefaID) {
            tarefaID = $(this).data('tarefaid');
        }

        Swal.fire({
            title: "Deseja Excluir a Tarefa?",
            text: "Não será posível recuperar a tafera!",
            icon: "warning",
            showCancelButton: true,
            confirmButtonColor: "#3085d6",
            cancelButtonColor: "#d33",
            confirmButtonText: "Sim, Excluir!"
        }).then((result) => {
            if (result.isConfirmed) {
                Swal.fire({
                title: "Excluido",
                text: "Tarefaexcluida com sucesso.",
                icon: "success",
                });
            setTimeout(function () {
                window.location.href = 'Default.aspx?delete=' + tarefaID;
            }, 2000)
            }
        });
    });
});
