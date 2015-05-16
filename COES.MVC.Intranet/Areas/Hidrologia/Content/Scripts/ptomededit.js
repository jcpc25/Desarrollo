var controlador = siteRoot + 'hidrologia/'
$(function () {
    
    $('#cbEmpresaPto').change(function () {
        cargarEquipos();
    });

    $('#cbFamilia').on('change', function () {
        empresa = $('#cbEmpresa').val();
        cargarEquipos();
    });

    $('#btnGrabar').click(function () {

        grabarPtoMedicion();
    });
    $('#cbOrigenLectura2').change(function () {
        
        cargarTipoPto();
    });
    $('#btnCancelar').click(function () {
        cancelar();
    });
});


cancelar = function () {
    $('#popupUnidad').bPopup().close();
}

function validarPtopMedicion()
{

}

function grabarPtoMedicion()
{
    var descripcion = $('#cdPtomedibarranomb2').val();
    var abreviatura = $('#cdPtomedielenomb2').val();
    var empresa = $('#cbEmpresaPto').val();
    var equipo = $('#cbEquipo').val();
    var origen = $('#cbOrigenLectura2').val();
    var ptomedicodi = $('#hfPtomedicodi2').val();
    var tipopto = $('#cbTipoPtoMedicion2').val();
    var orden = $('#cdOrden').val();
    var osicodigo = $('#cdOsicodi').val();
    if (descripcion != "") {
        if (abreviatura != "") {
            if (empresa > 0) {
                if (equipo > 0) {
                    if (origen > 0) {
                        if (tipopto > 0) {
                            if (orden != "") {
                                $.ajax({
                                    type: 'POST',
                                    dataType: 'json',
                                    url: controlador + "ptomedicion/grabar",
                                    data: {
                                        empresa: empresa, equipocodi: equipo, lectura: origen, ptomedicion: ptomedicodi, orden: orden,
                                        barranomb: descripcion, elenomb: abreviatura, osicodi: osicodigo, tipopto: tipopto
                                    },
                                    success: function (resultado) {
                                        switch (resultado)
                                        {
                                            case -1:
                                                alert("Ya existe el pto de medición");
                                                break;
                                            case 0:
                                                alert("Error al grabar el pto de medición");
                                                break;
                                            case 1:
                                                $('#popupUnidad').bPopup().close();
                                                break;
                                        }

                                    },
                                    error: function () {
                                        alert("Ha ocurrido un error");
                                    }
                                });
                            }
                            else {
                                alert("Ingresar orden.");
                            }
                        }
                        else {
                            alert("Seleccionar tipo punto de medición.");
                        }
                    }
                    else {
                        alert("Seleccionar origen de lectura.");
                    }
                }
                else {
                    alert("Seleccionar equipo.");
                }
            }
            else {
                alert("Seleccionar empresa.");
            }
        }
        else {
            alert("Ingrese la abreviatura.");
        }
    }
    else {
        alert("Ingrese la descripción.");
    }

}

function cargarEquipos() {

    var familia = $('#cbFamilia').val();
    if (typeof(familia) == "undefined")
        familia = 0;
    empresa = $('#cbEmpresaPto').val();
    $.ajax({
        type: 'POST',
        url: controlador + 'ptomedicion/cargarequipos',
        dataType: 'json',
        data: { idEmpresa: empresa, idFamilia: familia },
        cache: false,
        success: function (aData) {
            $('#cbEquipo').get(0).options.length = 0;
            $('#cbEquipo').get(0).options[0] = new Option("--SELECCIONE--", "");
            $.each(aData, function (i, item) {
                $('#cbEquipo').get(0).options[$('#cbEquipo').get(0).options.length] = new Option(item.Text, item.Value);
            });
        },
        error: function () {
            alert("Ha ocurrido un error");
        }
    });
}

function cargarTipoPto() {
    var origLect = $('#cbOrigenLectura2').val();

    $.ajax({
        type: 'POST',
        url: controlador + 'ptomedicion/CargarTipoPto',
        dataType: 'json',
        data: { tipoOrigenLectura: origLect },
        cache: false,
        success: function (aData) {
            $('#cbTipoPtoMedicion2').get(0).options.length = 0;
            $('#cbTipoPtoMedicion2').get(0).options[0] = new Option("--SELECCIONE--", "");
            $.each(aData, function (i, item) {
                $('#cbTipoPtoMedicion2').get(0).options[$('#cbTipoPtoMedicion2').get(0).options.length] = new Option(item.Text, item.Value);
            });
        },
        error: function () {
            alert("Ha ocurrido un error");
        }
    });
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

