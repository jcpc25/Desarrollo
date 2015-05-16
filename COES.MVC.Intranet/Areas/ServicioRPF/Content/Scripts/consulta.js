﻿var controlador = siteRoot + 'serviciorpf/'

$(function ()
{    
    $('#FechaConsulta').Zebra_DatePicker({
    });

    $('#btnConsultar').click(function () {
        mostrar();
    });

    $('#btnExportar').click(function () {
        exportar();
    });

    $('#btnExportarReporte').click(function () {
        exportarReporte();
    });

    mostrar();
});

function mostrar()
{
    $.ajax({
        type: "POST",
        url: controlador + "consulta/consulta",
        data: { fecha: $('#FechaConsulta').val()},
        success: function (evt) {
            $('#listado').html(evt);
            oTable = $('#tabla').dataTable({
                "sPaginationType": "full_numbers",
                "aaSorting": [[0, "asc"]],
                "destroy": "true",
                "aoColumnDefs": [
                     { 'bSortable': false, 'aTargets': [5] }
                ]
            });
        },
        error: function () {
            mostrarError();
        }
    });
}

function exportar()
{
    var puntos = "";
    $('#tabla tbody tr').each(function (i, row) {
        var $actualrow = $(row);
        $checkbox = $actualrow.find('input:checked');
        if ($checkbox.is(':checked')) {
            puntos = puntos + $checkbox.val() + ",";
        }
    });

    $.ajax({
        type: 'POST',
        url: controlador + 'consulta/generararchivo',
        data: { puntos: puntos, fecha: $('#FechaConsulta').val() },
        dataType: 'json',
        success: function (result) {
            if (result == 1) {
                window.location = controlador + "consulta/exportar";
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

function exportarReporte()
{
    $.ajax({
        type: 'POST',
        url: controlador + 'consulta/generararchivoreporte',
        data: { fecha: $('#FechaConsulta').val() },
        dataType: 'json',
        success: function (result) {
            if (result == 1) {
                window.location = controlador + "consulta/exportarreporte";
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

function mostrarError()
{
    alert("Ha ocurrido un error.");
}