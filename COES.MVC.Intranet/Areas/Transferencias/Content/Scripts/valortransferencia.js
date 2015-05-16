
var ce = "valortransferencia/";
var controler2 = "transferencias/" + ce;
var controler = siteRoot + controler2;

$(document).ready(function () {
    buscar();
    buscar2();
    $('#btnBuscar').click(function () {
        buscar();
    });

    $('#tab-container').easytabs({
        animate: false
    });

    $('#btnBuscar2').click(function () {
        buscar2();
    });


    $('#Procesar').click(function () {
        Recalcular();
    });

    $('#btnGenerarExcel').click(function () {
        generarExcel();
    });

    $('#btnGenerarExcel1').click(function () {
        generarExcel1();
    });

    $('#btnGenerarExcelCuadro').click(function () {
        generarExcelCuadro();
    });

    $('#btnGenerarExcelMatriz').click(function () {
        generarExcelMatriz();
    });
});

AddAntiForgeryToken = function (data) {
    data.__RequestVerificationToken = $('input[name=__RequestVerificationToken]').val();
    return data;
};


Recalcular = function () {


    var periodo = $("#PERICODI3 option:selected").val();

    if (periodo == '')
        alert('Seleccione un Periodo');
    else {



        $.ajax({
            type: 'POST',
            url: controler + 'Recalcular',
            data: { pericodi: periodo },
            dataType: 'json',
            success: function (result) {
                if (result == 1) {
                    alert('Procesado ')
                    //buscar();
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

}




function buscar() {

    var empcodi = $("#EMPRCODI option:selected").val();
    var centgenecodi = $("#CENTGENECODI option:selected").val();
    var barrcodi = $("#BARRCODI option:selected").val();
    var pericodi = $("#PERICODI option:selected").val();

    if (empcodi == '')
        empcodi = null;
    if (centgenecodi == '')
        centgenecodi = null;
    if (barrcodi == '')
        barrcodi = null;
    if (pericodi == '')
        pericodi = null;


    $.ajax({
        type: 'POST',
        url: controler + "lista",
        data: { empcodi: empcodi, centgenecodi: centgenecodi, barrcodi: barrcodi, pericodi: pericodi },
        success: function (evt) {
            $('#listado').html(evt);
            oTable = $('#tabla').dataTable({
                "sPaginationType": "full_numbers",
                "destroy": "true"
            });

            //add_deleteEvent();
            //ViewEvent();
        },
        error: function () {
            mostrarError();
        }
    });
}



function buscar2() {

    var pericodi = $("#PERICODI2 option:selected").val();

    if (pericodi == '') {
        pericodi = 0000000;

    }


    $.ajax({
        type: 'POST',
        url: controler + "ListaInfo",
        data: { pericodi: pericodi },
        success: function (evt) {
            $('#listado2').html(evt);
            oTable = $('#tabla2').dataTable({
                "sPaginationType": "full_numbers",
                "destroy": "true"
            });

            //add_deleteEvent();
            //ViewEvent();
        },
        error: function () {
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
                window.location = ce + 'abrirexcel';
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

generarExcel1 = function () {

    if ($("#Pericodi").val() == "") {
        alert("Seleccione un Periodo");
    }
    else {

        sPericodi = $("#Pericodi").val();
        $.ajax({
            type: 'POST',
            url: controler + 'generarexcel1',
            dataType: 'json',
            data: { sPericodi: sPericodi },
            success: function (result) {
                if (result == 1) {
                    window.location = controler + 'abrirexcel1';
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
}


generarExcelCuadro = function () {
    var pericodi = $("#PERICODI4 option:selected").val();

    if (pericodi == "") {
        alert('Seleccione Periodo');
    }
    else {


        $.ajax({
            type: 'POST',
            url: controler + 'generarexcelCuadro',
            dataType: 'json',
            data: { pericodigo: pericodi },
            success: function (result) {
                if (result == 1) {
                    window.location = ce + 'abrirexcelCuadro';
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
}


generarExcelMatriz = function () {
    var pericodi = $("#PERICODI4 option:selected").val();
    if (pericodi == "") {
        alert('Seleccione Periodo');
    }
    else {
        $.ajax({
            type: 'POST',
            url: controler + 'generarexcelMatriz',
            dataType: 'json',
            data: { pericodigo: pericodi },
            success: function (result) {
                if (result == 1) {
                    window.location = ce + 'abrirexcelMatriz';
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
}




function mostrarError() {
    alert('ERROR');
}
