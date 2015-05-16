var controlador = siteRoot + 'hidrologia/'
var oTable;
var oTableHead;
$(function () {

    $('#cbArea').val("0");
    $('#btnBuscar').click(function () {
        buscarFormato();
    });

    $('#btnNuevo').click(function () {
        nuevoFormato();
    });

    $('#tablaPtos a.edicion').click(function (e) {
        e.preventDefault();

        /* Get the row as a parent of the link that was clicked on */
        alert("HI");
        var nRow = $(this).parents('tr')[0];

        if (nEditing !== null && nEditing != nRow) {
            /* Currently editing - but not this row - restore the old before continuing to edit mode */
            restoreRow(oTable, nEditing);
            editRow(oTable, nRow);
            nEditing = nRow;
        }
        else if (nEditing == nRow && this.innerHTML == "Save") {
            /* Editing this row and want to save it */
            saveRow(oTable, nEditing);
            nEditing = null;
        }
        else {
            /* No edit in progress - let's start one */
            editRow(oTable, nRow);
            nEditing = nRow;
        }
    });

    buscarFormato();
    $(window).resize(function () {
        $('#listado').css("width", $('#mainLayout').width() + "px");
    });

});

function buscarFormato() {
    mostrarListado();
}

function mostrarListado() {

    $.ajax({
        type: 'POST',
        url: controlador + "formatomedicion/listaformato",
        data: {
            area: $('#cbArea').val()
        },
        success: function (evt) {
            $('#listado').css("width", $('#mainLayout').width() + "px");

            $('#listado').html(evt);
            $('#tabla').dataTable({
                bJQueryUI: true,
                "scrollY": 150,
                "scrollX": true,
                "sDom": 't',
                "ordering": true,
                "iDisplayLength": 50
            });
        },
        error: function () {
            alert("Ha ocurrido un error");
        }
    });
}

function mostrarDetalle2(formato) {
    
    $.ajax({
        type: 'POST',
        url: controlador + "formatomedicion/ListaHoja",
        data: {
            formato: formato           
        },
        success: function (evt) {

            $('#detalle').html(evt);

        },
        error: function () {
            alert("Ha ocurrido un error");
        }
    });

}

function mostrarDetalle(formato) {
    location.href = controlador + "formatomedicion/indexhoja?id=" + formato;
}



function nuevoFormato() {
    
    $.ajax({
        type: 'POST',
        url: controlador + "formatomedicion/agregar",
        success: function (evt) {
            $('#edicionGrupo').html(evt);
            setTimeout(function () {
                $('#popupUnidad').bPopup({
                    easing: 'easeOutBack',
                    speed: 450,
                    transition: 'slideDown'
                });
            }, 50);
            $('#alerta').css("display", "none");
            $('#mensaje').css("display", "none");
        },
        error: function () {
            mostrarError();
        }
    });
}

agregarFormato = function () {
    area = $('#cbAreas').val();
    resolucion = $("#cbResolucion").val();
    horizonte = $("#cbHorizonte").val();
    periodo = $("#cbPeriodo").val();
    nombre = $('#txtNombre').val();
    lectura = $('#idLecturas').val();
    tituloHoja = $('#txtTitulo').val();

    if (nombre == "") {
        alert("Ingresar Nombre del Formato");
        return;
    }
    if (area == 0) {
        alert("Seleccionar el area");
        return;
    }
    if (resolucion == 0) {
        alert("Seleccionar Resolución");
        return;
    }
    if (horizonte == 0) {
        alert("Seleccionar Horizonte");
        return;
    }
    if (periodo == 0) {
        alert("Seleccionar Periodo");
        return;
    }
    if (tituloHoja == "") {
        alert("Ingresar nombre del Titulo");
        return;
    }
    if (lectura == 0) {
        alert("Seleccionar Lectura");
        return;
    }

    $.ajax({

        type: 'POST',
        url: controlador + 'formatomedicion/agregarformato',
        dataType: 'json',
        data: { nombre: nombre, area: area, resolucion: resolucion, horizonte: horizonte, periodo: periodo, lectura: lectura, tituloHoja: tituloHoja },
        cache: false,
        success: function (resultado) {
            if (resultado == 1) {
                $('#popupUnidad').bPopup().close();
                // cargar();
            }
            else {
                alert("Error al grabar formato");
            }

        },
        error: function () {
            alert("Error al grabar formato");
        }

    });
 }

function validarLetras(e) { // 1

    tecla = (document.all) ? e.keyCode : e.which;
    if (tecla == 8) return true; // backspace
    if (tecla == 32) return true; // espacio
    if (e.ctrlKey && tecla == 86) { return true; } //Ctrl v
    if (e.ctrlKey && tecla == 67) { return true; } //Ctrl c
    if (e.ctrlKey && tecla == 88) { return true; } //Ctrl x

    patron = /[a-zA-Z0-9]/; //patron

    te = String.fromCharCode(tecla);
    return patron.test(te); // prueba de patron
}

validarNumero = function (item, evt) {
    evt = (evt) ? evt : window.event;
    var charCode = (evt.which) ? evt.which : evt.keyCode;

    if (charCode == 46) {
        var regex = new RegExp(/\./g)
        var count = $(item).val().match(regex).length;
        if (count > 1) {
            return false;
        }
    }

    if (charCode == 45) {
        var regex = new RegExp(/\-/g)
        var count = $(item).val().match(regex).length;
        if (count > 0) {
            return false;
        }
    }

    if (charCode > 31 && charCode != 45 && (charCode < 48 || charCode > 57)) {
        return false;
    }

    return true;
}



