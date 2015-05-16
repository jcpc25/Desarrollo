var levantamiento = "levantamiento/";
var controler = siteRoot + "transferencias/" + levantamiento;

//Funciones de busqueda
$(document).ready(function () {
    buscar();
    $('#txtFecha').Zebra_DatePicker({
    });

    $('#btnBuscar').click(function () {
        buscar();
    });                                         

});

function buscar() {
    var c;

    if ($("#Pericodi option:selected").val() == "") {
        c = 0;
    } else {
        c = $("#Pericodi option:selected").val();
    }

    $.ajax({
        type: 'POST',
        url: controler + "lista",
        data: { fecha: $('#txtFecha').val(), pericodi: c, corrinf: $('[name="radio"]:radio:checked').val() },
        success: function (evt) {
            $('#listado').html(evt);
            oTable = $('#tabla').dataTable({
                "sPaginationType": "full_numbers",
                "destroy": "true",
                "aaSorting": [[0, "desc"]]
            });

            //add_deleteEvent();
            ViewEvent();
        },
        error: function () {
            mostrarError();
        }
    });
};

mostrarError = function () {
    alert("Ha ocurrido un error");
}

AddAntiForgeryToken = function (data) {
    data.__RequestVerificationToken = $('input[name=__RequestVerificationToken]').val();
    return data;
};

//Funciones de vista detalle
var controler2 = siteRoot + "transferencias/" + levantamiento;

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