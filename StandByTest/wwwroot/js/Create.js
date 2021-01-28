$(function () {
    $("#Cnpj").mask("99.999.999/9999-99");
    $("#Capital").maskMoney({ thousands: '', decimal: ',' });
    $("#Capital").rules("remove", "number");
});