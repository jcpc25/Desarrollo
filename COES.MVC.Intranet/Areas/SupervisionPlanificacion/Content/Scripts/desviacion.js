var controler = siteRoot + "supervisionPlanificacion/desviacion/";

$(document).ready(function () {
    buscar();
    $('#buscar').click(function () {
        buscar();
    });

    $('#txtFecha').Zebra_DatePicker({
    });

    oTable = $('#tabla').dataTable({
        "sPaginationType": "full_numbers",
        "destroy": "true"
    });
});


function buscar() {

    $.ajax({
        type: 'POST',
        url: controler + "grilla",
        data: { fecha: $('#txtFecha').val() },
        success: function (evt) {
            $('#listado').html(evt);
            oTable = $('#tabla').dataTable({
                "sPaginationType": "full_numbers",
                "destroy": "true"
            });
        },
        error: function () {
            mostrarErrorFormato();

        }
    });

}


mostrarErrorFormato = function () {
    alert("Error en el formato.");

}


function loadInfoFile(fileName, fileSize) {

    $('#fileInfo').html(fileName + " (" + fileSize + ")");


}

function loadValidacionFile(mensaje) {

    $('#fileInfo').html(mensaje);


}

function mostrarProgreso(porcentaje) {

    $('#progreso').text(porcentaje + "%");

}

function procesarArchivo() {
    $.ajax({
        type: 'POST',
        url: controler + 'procesararchivo',
        dataType: 'json',
        /* data: {
             file: file
         },*/

        data: { fecha: $('#txtFecha').val() },
        cache: false,
        success: function (resultado) {
            if (resultado == 1) {
                buscar();
                mostrarMensaje("Archivo procesado");
            }
            else {

                buscar();
                mostrarError();

            }
        },
        error: function () {

            mostrarError();

        }
    });
}

mostrarMensaje = function (mensaje) {
    alert(mensaje);
}

mostrarError = function () {
    alert("Ha ocurrido un error.");

}