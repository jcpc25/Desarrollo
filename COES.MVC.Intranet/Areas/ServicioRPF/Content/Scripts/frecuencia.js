var controlador = siteRoot + 'serviciorpf/frecuencia/'

$(function ()
{
    $('#txtFecha').Zebra_DatePicker({
    });     

    $('#btnConsultar').click(function () {
        cargarDatos();
    });

    $('#btnReemplazar').click(function () {
        openReemplazo();
    });

   

    cargarDatos();
});

cargarDatos = function ()
{
    if ($('#txtFecha').val() != '') {
        $.ajax({
            type: "POST",
            url: controlador + "lista",
            data: { fecha: $('#txtFecha').val() },
            success: function (evt) {
                $('#listado').html(evt);
                $('#tabla').dataTable({
                    "iDisplayLength": 50
                });
            },
            error: function () {
                mostrarError();
            }
        });
    }
    else { mostrarMensaje("Seleccione fecha"); }
}

openReemplazo = function ()
{
    setTimeout(function () {
        $('#popupUnidad').bPopup({
            easing: 'easeOutBack',
            speed: 450,
            transition: 'slideDown'
        });
    }, 50);
}

reemplazar = function ()
{
    if (confirm("¿Está seguro de reemplazar los datos?"))
    {
        if ($('#cbGpsOrigen').val() != "" && $('#cbGpsDestino').val() != "")
        {
            if ($('#cbGpsOrigen').val() != $('#cbGpsDestino').val())
            {
                $.ajax({
                    type: 'POST',
                    url: controlador + 'reemplazar',
                    data: { fecha: $('#txtFecha').val(), gpsorigen: $('#cbGpsOrigen').val(), gpsdestino: $('#cbGpsDestino').val() },
                    dataType: 'json',
                    success: function (result) {
                        if (result == 1) {
                            cancelar();
                            cargarDatos();
                        }
                        if (result == -1) {
                            mostrarError();
                        }
                    },
                    error: function () {
                        mostrarError();
                    }
                });
            }
            else
            {
                mostrarMensaje("No puede seleccionar el mismo GPS.");
            }
        }
        else
        {
            mostrarMensaje("Seleccione el GPS origen y GPS destino.");
        }
    }
}

cancelar = function ()
{
    $('#popupUnidad').bPopup().close();
}

descargarFrecuencia = function (gpscodi)
{
    $.ajax({
        type: 'POST',
        url: controlador + 'exportar',
        data: { fecha: $('#txtFecha').val(), gpscodi: gpscodi },
        dataType: 'json',
        success: function (result) {
            if (result == 1) {
                window.location = controlador + "descargar";
            }
            if (result == -1) {
                mostrarError();
            }
        },
        error: function () {
            mostrarError();
        }
    });
}

mostrarError = function ()
{
    alert("Ha ocurrido un error.");
}

mostrarMensaje = function (mensaje)
{
    alert(mensaje);
}