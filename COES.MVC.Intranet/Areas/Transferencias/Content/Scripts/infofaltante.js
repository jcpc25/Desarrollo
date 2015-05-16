
var ce = "infofaltante/";
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
        data: { PeriCodi: $("#Periodo option:selected").val() },
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
