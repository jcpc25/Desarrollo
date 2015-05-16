var controlador = siteRoot + "transferencias/ingresopotencia/";

$(document).ready(function () {
    //buscar();

    $('#tab-container').easytabs({
        animate: false
    });

    $('#btnBuscar').click(function () {
        buscar();
    });
});

function buscar() {
    var p;
    var cbo = $("#Pericodi2 option:selected").val();

    if (cbo == "") {
        alert('Por favor, seleccione el Periodo');
    }
    else {
        p = $("#Pericodi2 option:selected").val();
        $.ajax({
            type: 'POST',
            url: controlador + "lista",
            data: { pericodi: p },
            success: function (evt) {
                $('#listado').html(evt);
                oTable = $('#tabla').dataTable({
                    "sPaginationType": "full_numbers",
                    "destroy": "true"
                });

                //add_deleteEvent();
                //ViewEvent();
            },
            error: function () {
                mostrarError();
            }
        });
    }
}