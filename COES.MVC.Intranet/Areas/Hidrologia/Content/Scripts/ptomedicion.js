var controlador = siteRoot + 'hidrologia/'
$(function () {


    $('#cbOrigLectura').val("0");
    
    $('#cbEmpresa').multipleSelect({
        width: '200px',
        filter: true
    });

    $('#cbOrigLectura').multipleSelect({
        width: '200px',
        filter: true
    });

    $('#cbTipoPuntoMedicion').multipleSelect({
        width: '200px',
        filter: true
    });

    $('#btnBuscar').click(function () {
        buscarPtoMedicion();
    });

    $('#btnNuevo').click(function () {
        nuevoPtoMedicion(0);
    });
    $('#cbOrigLectura').change(function () {
        cargarTipoPto();
    });
    cargarPrevio()
    buscarPtoMedicion();
    $(window).resize(function () {
        $('#listado').css("width", $('#mainLayout').width() + "px");
    });
});

cargarPrevio = function () {
    $('#cbEmpresa').multipleSelect('checkAll');
    $('#cbOrigLectura').multipleSelect('checkAll');
    $('#cbTipoPuntoMedicion').multipleSelect('checkAll');
}

function buscarPtoMedicion() {

    pintarPaginado();
    mostrarListado(1);
}


function nuevoPtoMedicion(id)
{
    //window.location.href = controlador + 'ptomedicion/editar';

    $.ajax({
        type: 'POST',
        url: controlador + "ptomedicion/editar?id=" + id,
        success: function (evt) {
            $('#agregarPto').html(evt);
            setTimeout(function () {
                $('#popupUnidad').bPopup({
                    easing: 'easeOutBack',
                    speed: 450,
                    transition: 'slideDown'
                });
            }, 50);
        },
        error: function () {
            mostrarError();
        }
    });
}

function pintarBusqueda(nroPagina) {
    mostrarListado(nroPagina);
}

function pintarPaginado() {
    var empresa = $('#cbEmpresa').multipleSelect('getSelects');
    var origen = $('#cbOrigLectura').multipleSelect('getSelects');
    var tipopto = $('#cbTipoPuntoMedicion').multipleSelect('getSelects');

    if (tipopto == "[object Object]") tipopto = "-1";
    $('#hfTipoPuntoMedicion').val(tipopto);
    $('#hfEmpresa').val(empresa);
    $('#hfOrigLectura').val(origen);   
    $.ajax({
        type: 'POST',
        url: controlador + "ptomedicion/paginado",
        data: {
            empresas: $('#hfEmpresa').val(),
            tipoOrigenLectura: $('#hfOrigLectura').val(),
            tipoPtomedicodi: $('#hfTipoPuntoMedicion').val(), nroPagina: 1
        },
        success: function (evt) {
            $('#paginado').html(evt);
            mostrarPaginado();
        },
        error: function () {
            alert("Ha ocurrido un error paginado");
        }
    });





}

function mostrarListado(nroPaginas) {
    var empresa = $('#cbEmpresa').multipleSelect('getSelects');
    var origen = $('#cbOrigLectura').multipleSelect('getSelects');
    var tipopto = $('#cbTipoPuntoMedicion').multipleSelect('getSelects');
    
    if (tipopto == "[object Object]") tipopto = "-1";
    $('#hfTipoPuntoMedicion').val(tipopto);
    $('#hfEmpresa').val(empresa);
    $('#hfOrigLectura').val(origen);
    $.ajax({
        type: 'POST',
        url: controlador + "ptomedicion/lista",
        data: {
            empresas: $('#hfEmpresa').val(),
            tipoOrigenLectura: $('#hfOrigLectura').val(),
            tipoPtomedicodi: $('#hfTipoPuntoMedicion').val(), nroPagina: nroPaginas
        },
        success: function (evt) {
            $('#listado').css("width", $('#mainLayout').width() + "px");

            $('#listado').html(evt);
            $('#tabla').dataTable({
                "scrollY": 430,
                "scrollX": true,
                "sDom": 't',
                "ordering": false,
                "iDisplayLength": 50
            });
        },
        error: function () {
            alert("Ha ocurrido un error");
        }
    });
}

function cargarTipoPto() {
    var origen = $('#cbOrigLectura').multipleSelect('getSelects');
    $('#hfOrigLectura').val(origen);
    $.ajax({
        type: 'POST',
        url: controlador + 'ptomedicion/TipoPtoMedicion',
        data: { tipoOrigenLectura: $('#hfOrigLectura').val() },
        success: function (aData) {
            $('#tipoptomed').html(aData);
        },
        error: function () {
            alert("Ha ocurrido un error");
        }
    });
}

function mostrarDetalle(id) {
    //location.href = controlador + "ptomedicion/editar?id=" + id;
    nuevoPtoMedicion(id)
}

cancelar = function () {
    document.location.href = controlador + "index";
}