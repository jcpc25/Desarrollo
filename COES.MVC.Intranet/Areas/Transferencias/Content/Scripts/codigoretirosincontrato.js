var ce = "codigoretirosincontrato/";
var controler2 = "transferencias/" + ce;
var controler = siteRoot + controler2;

$(document).ready(function () {
    buscar();
  
    $('.txtFecha').Zebra_DatePicker({
    });

    $('#btnBuscar').click(function () {
        buscar();
    });

    $('#btnGenerarExcel').click(function () {
        generarExcel();
    });
});

//Funciones de eliminado de registro
function add_deleteEvent() {
    $(".delete").click(function (e) {
        e.preventDefault();
        if (confirm("Desea eliminar la información seleccionada ?")) {
            id = $(this).attr("id").split("_")[1];
            $.ajax({
                type: "post",
                dataType: "text",
                url: ce + "Delete/" + id,
                data: AddAntiForgeryToken({ id: id }),
                success: function (resultado) {
                    if (resultado == 'True')
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
function buscar() {
    var estado;
    if ($('#Activo').is(':checked')) {
        estado = 'ACT'; //alert('Activo');
    }
    if ($('#Inactivo').is(':checked')) {
        estado = 'INA'; //alert('Inactivo');
    }
     $.ajax({
        type: 'POST',
        url: controler + "lista",
        data: { nombreCli: $("#EMPRCODI option:selected").text(), nombreBarra: $("#BARRCODI option:selected").text(), fechaInicio: $('#txtfechaIni').val(), fechaFin: $('#txtfechaFin').val(), estado: estado},
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
}

var controler2 = siteRoot + "transferencias/" + ce;

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

generarExcel = function () {
    $.ajax({
        type: 'POST',
        url: controler + 'generarexcel',
        dataType: 'json',
        success: function (result) {
            if (result == 1) {
                window.location = controler + 'abrirexcel';
            }
            if (result == -1) {
                alert("Lo sentimos, se ha producido un error");
            }
        },
        error: function () {
            alert("Lo sentimos, se ha producido un error");
        }
    });
}