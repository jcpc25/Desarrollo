var controlador = siteRoot + 'eventos/'

$(function () {

    $('#FechaDesde').Zebra_DatePicker({               
    });

    $('#cbFamilia').val("0");
    $('#cbEmpresa').val("0");
    $('#cbTipoEvento').val("0");

    $('#FechaHasta').Zebra_DatePicker({      
    });

    buscarEvento();
    
    $('#btnBuscar').click(function () {
        buscarEvento();
    });

    $('#cbTipoEmpresa').change(function () {
        cargarEmpresas();
    });

    $(window).resize(function () {
        $('#listado').css("width", $('#mainLayout').width() + "px");
    });
});

function buscarEvento()
{
    pintarPaginado();
    mostrarListado(1);
}

function pintarPaginado()
{  
    $.ajax({
        type: 'POST',
        url: controlador + "evento/paginado",
        data: $('#frmBusqueda').serialize(),
        success: function (evt) {
            $('#paginado').html(evt);
            mostrarPaginado();
        },
        error: function () {
            alert("Ha ocurrido un error");
        }
    });
}

function cargarEmpresas() {
    $.ajax({
        type: 'POST',
        url: controlador + 'evento/cargarempresas',
        dataType: 'json',
        data: { idTipoEmpresa: $('#cbTipoEmpresa').val() },
        cache: false,
        success: function (aData) {
            $('#cbEmpresa').get(0).options.length = 0;
            $('#cbEmpresa').get(0).options[0] = new Option("--SELECCIONE--", "");
            $.each(aData, function (i, item) {
                $('#cbEmpresa').get(0).options[$('#cbEmpresa').get(0).options.length] = new Option(item.Text, item.Value);
            });
        },
        error: function () {
            alert("Ha ocurrido un error");
        }
    });
}

function mostrarListado(nroPagina)
{
    $('#hfNroPagina').val(nroPagina);

    $.ajax({
        type: 'POST',
        url: controlador + "evento/lista",
        data:  $('#frmBusqueda').serialize(),
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

function mostrarLeyenda()
{   
    if ($('#leyenda').css("display") == "none") {
        $('#leyenda').css("display", "block");
        $('#spanLeyenda').text("Ocultar leyenda CIER");
    }
    else if ($('#leyenda').css("display") == "block") {
        $('#leyenda').css("display", "none");
        $('#spanLeyenda').text("Mostrar leyenda CIER");
    }
}

function pintarBusqueda(nroPagina)
{
    mostrarListado(nroPagina);
}

function mostrarDetalle(id)
{
    location.href = controlador + "evento/detalle?id=" + id;
}



