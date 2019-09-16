$(function () {
    $(".Date").datepicker({
        format: "dd/mm/yyyy",
        startView: -3,//it could be -3 or -2 it means start from where date or month or year
        startDate: '0d',
        autoclose: true
    });
});