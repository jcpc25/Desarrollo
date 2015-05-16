
var ce = "infodesviacion/";
var controler2 = "transferencias/" + ce;
var controler = siteRoot + controler2;

$(document).ready(function () {
    $('#btnBuscar').click(function () {
        buscar();
    });
});

function buscar() {
    $.ajax({
        type: 'POST',
        url: controler + "Lista",
        data: { AnioMes: $("#Periodo option:selected").val(), Desviacion: $("#Desviacion").val(), Valorizaciones: $("#Valorizaciones").val() },
        success: function (evt) {
            $('#listado').html(evt);
            oTable = $('#tabla').dataTable({
                "sPaginationType": "full_numbers",
                "destroy": "true"
            });
        },
        error: function () {
            alert("error en Buscar");
        }
    });
}
