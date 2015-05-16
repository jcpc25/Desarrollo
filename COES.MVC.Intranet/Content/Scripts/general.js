var controler = siteRoot + "general/";

$(document).ready(function () {
    buscar();
    $('#btnBuscar').click(function () {
        buscar();
    });
});

function buscar() {
  
    $.ajax({
        type: 'POST',
        url: controler + "grilla",
        data: { nombre: $('#txtNombre').val() },
        success: function (evt) {
            $('#listado').html(evt);
            oTable = $('#tabla').dataTable({
                "sPaginationType": "full_numbers",
                "destroy": "true"                
            });
        },
        error: function () {
            mostrarError();
        }
    });
}

