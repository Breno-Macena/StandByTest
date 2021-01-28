$(function () {
    $("#Cnpj").mask("99.999.999/9999-99");
    filter();
    $("#filter").on("submit", function (e) {
        e.preventDefault();
        filter();
    });
});

function filter() {
    var form = $('#filter')[0];
    var data = new FormData(form);

    $.ajax({
        url: '/Clientes/Clientes',
        type: 'POST',
        data: data,
        processData: false,
        contentType: false,
    }).done(function (response) {
        $("#Clientes").html(response);
    });
}