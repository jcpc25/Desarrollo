
var cr = "codigoretiro/";
var controler2 = "transferencias/" + cr;
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
        if (confirm("Desea dar de baja  ?")) {
            id = $(this).attr("id").split("_")[1];
            $.ajax({
                type: "post",
                dataType: "text",
                url: cr + "Delete/" + id,
                data: AddAntiForgeryToken({ id: id }),
                success: function (resultado) {
                    if (resultado == "true")
                        alert("El registro se dio de baja");
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
    $.ajax({
        type: 'POST',
        url: controler + "lista",
        data: { nombreEmp: $("#EMPRCODI option:selected").text(), tipousu: $("#TIPOUSUACODI option:selected").text(), tipocont: $("#TIPOCONTCODI option:selected").text(), barr: $("#BARRCODI option:selected").text(), clinomb: $("#CLICODI option:selected").text(), fechaInicio: $('#txtfechaIni').val(), fechaFin: $('#txtfechaFin').val(), Solicodiretiobservacion: $('[name="SOLICODIRETIOBSERVACION"]:radio:checked').val(), radiobtn: $('[name="ESTADOLIST"]:radio:checked').val() },
        success: function (evt) {
            $('#listado').html(evt);
            oTable = $('#tabla').dataTable({
                "sPaginationType": "full_numbers",
                "destroy": "true"
            });
           add_deleteEvent();
           ViewEvent();
        },
        error: function (e) {
            mostrarError();
        }
    });
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
                mostrarError();
            }
        },
        error: function () {
            mostrarError();
        }
    });
}

var controler2 = siteRoot + "transferencias/" + cr;

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

mostrarError = function () {
    alert("Ha ocurrido un error.");
}