﻿var controlador = siteRoot + "mediciones/generacionrer/";

$(function () {

    $('#txtFecha').Zebra_DatePicker({
    });

    $('#cbHorizonte').change(function () {
        horizonte();
    });

    $('#cbSemana').change(function () {
        mostrarFechas();
    });

    $('#btnConsultar').click(function () {
        consultarDatos();
    });

    $('#btnCancelar').click(function () {
        cancelar();
    });
});

horizonte = function () {

    if ($('#cbHorizonte').val() == "0") {
        $('#cntFecha').css("display", "block");
        $('#cntSemana').css("display", "none");
        $('#fechasSemana').css("display", "none");
        $('#cntAnio').css("display", "none");
    }
    if ($('#cbHorizonte').val() == "1") {
        $('#cntFecha').css("display", "none");
        $('#cntSemana').css("display", "block");
        $('#fechasSemana').css("display", "block");
        $('#cntAnio').css("display", "block");
    }
};

mostrarFechas = function () {
    if ($('#cbSemana').val() != "" && $('#cbAnio').val() != "") {
        $.ajax({
            type: 'POST',
            url: controlador + 'obtenerfechasanio',
            dataType: 'json',
            data: { nroSemana: $('#cbSemana').val(), anio: $('#cbAnio').val() },
            success: function (result) {
                $('#txtFechaInicio').text(result.FechaInicio);
                $('#txtFechaFin').text(result.FechaFin);
            },
            error: function () {
                mostrarError();
            }
        });
    }
    else {
        $('#txtFechaInicio').text("");
        $('#txtFechaFin').text("");
    }
}

consultarDatos = function () {

    var mensaje = validacion();
    if (mensaje == "") {
        $.ajax({
            type: 'POST',
            url: controlador + "cumplimiento",
            data: {                
                horizonte: $('#cbHorizonte').val(), fecha: $('#txtFecha').val(), nroSemana: $('#cbSemana').val()
            },
            success: function (evt) {
                $('#listado').html(evt);
                limpiarMensaje();
            },
            error: function () {
                alert("Ha ocurrido un error");
            }
        });
    }
    else {
        mostrarAlerta(mensaje);
    }
}


validacion = function () {
    var validacion = "<ul>";
    var flag = true;
      
    if ($('#cbHorizonte').val() == "0") {
        if ($('#txtFecha').val() == "") {
            validacion = validacion + "<li>Seleccione fecha.</li>";
            flag = false;
        }
    }
    if ($('#cbHorizonte').val() == "1") {
        if ($('#cbSemana').val() == "") {
            validacion = validacion + "<li>Seleccione semana operativa.</li>";
            flag = false;
        }
        if ($('#cbAnio').val() == "") {
            validacion = validacion + "<li>Seleccione el año.</li>";
            flag = false;
        }
    }
    validacion = validacion + "</ul>";

    if (flag == true) validacion = "";

    return validacion;
}


cancelar = function () {
    document.location.href = siteRoot + "home/default";
}


mostrarAlerta = function (alerta) {
    $('#mensaje').removeClass("action-message");
    $('#mensaje').removeClass("action-error");
    $('#mensaje').addClass("action-alert");
    $('#mensaje').html(alerta);
    $('#mensaje').css("display", "block");
}

limpiarMensaje = function () {
    $('#mensaje').removeClass("action-alert");
    $('#mensaje').removeClass("action-error");
    $('#mensaje').addClass("action-message");
    $('#mensaje').html("Por favor ingrese los datos.");
}

mostrarError = function () {
    $('#mensaje').removeClass("action-message");
    $('#mensaje').removeClass("action-alert");
    $('#mensaje').addClass("action-error");
    $('#mensaje').html("Ha ocurrido un error.");
}