﻿var recalculo = "recalculo/";
var controler = siteRoot + "transferencias/" + recalculo;

//Funciones de busqueda
$(document).ready(function () {
    buscar();

    $('.txtFecha').Zebra_DatePicker({

    });

    $('#btnBuscar').click(function () {
        buscar();
    });

 
});

function buscar() {
    $.ajax({
        type: 'POST',
        url: controler + "lista",
        data: { nombre: $('#txtNombre').val() },
        success: function (evt) {
            $('#listado').html(evt);
            oTable = $('#tabla').dataTable({
                "sPaginationType": "full_numbers",
                "destroy": "true"
            });

            add_deleteEvent();
            ViewEvent();
        },
        error: function () {
            mostrarError();
        }
    });
};


mostrarError = function () {
    alert("Ha ocurrido un error.");
}

//Funciones de eliminado de registro
function add_deleteEvent() {
    $(".delete").click(function (e) {
        e.preventDefault();
        if (confirm("Desea eliminar la información seleccionada ?")) {
            id = $(this).attr("id").split("_")[1];
            $.ajax({
                type: "post",
                dataType: "text",
                url: recalculo + "Delete/" + id,
                data: AddAntiForgeryToken({ id: id }),
                success: function (resultado) {
                    if (resultado == "true")
                        $("#fila_" + id).remove();
                    else
                        alert("No se ha logrado eliminar el registro");
                }
            });
        }
    });
};

AddAntiForgeryToken = function (data) {
    data.__RequestVerificationToken = $('input[name=__RequestVerificationToken]').val();
    return data;
};

//Funciones de vista detalle
var controler2 = siteRoot + "transferencias/" + recalculo;

function ViewEvent() {
    $('.view').click(function () {
        id = $(this).attr("id").split("_")[1];
        abrirPopup(id);
    });
};

abrirPopup = function (id) {
    $('#popup').bPopup({
        easing: 'easeOutBack',
        speed: 450,
        transition: 'slideDown',
        loadUrl: controler2 + "View/" + id
    }
    );
}