var controlador = siteRoot + 'Admin/Estadistica/'

$(function () {

    $('#txtFechaInicio').Zebra_DatePicker({
    });

    $('#txtFechaFin').Zebra_DatePicker({
    });

    $('#btnMostrar').click(function () {
        mostrarEstadisticaGeneral();
    });

    cargarMenu();
    mostrarEstadisticaGeneral();

});

cargarMenu = function ()
{
    $.ajax({
        type: "POST",
        url: controlador + "tree",
        success: function (evt) {
            $('#tree').html(evt);
        },
        error: function (req, status, error) {
            alert("Ha ocurrido un error.");
        }
    });
}

cargarEstadisticaMenu = function (id)
{
    $.ajax({
        type: 'POST',
        url: controlador + "opcion",
        data: {
            idOpcion:id, fechaInicio: $('#txtFechaInicio').val(), fechaFin: $('#txtFechaFin').val()
        },
        success: function (evt) {
            $('#listado').html(evt);
            $('#tabla').dataTable({
                "iDisplayLength": 50
            });
        },
        error: function () {
            alert("Ha ocurrido un error");
        }
    });
}

mostrarEstadisticaGeneral = function ()
{
    $.ajax({
        type: 'POST',
        url: controlador + "aplicacion",
        data: {
            fechaInicio: $('#txtFechaInicio').val(), fechaFin: $('#txtFechaFin').val()
        },
        success: function (evt) {      
            $('#listado').html(evt);
            $('#tabla').dataTable({               
                "iDisplayLength": 50
            });
        },
        error: function () {
            alert("Ha ocurrido un error");
        }
    });
}