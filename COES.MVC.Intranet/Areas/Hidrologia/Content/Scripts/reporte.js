var controlador = siteRoot + 'hidrologia/';
$(function () {
    $('#cbEmpresa').multipleSelect({
        width: '222px',
        filter: true
    });
    $('#cbCuenca').multipleSelect({
        width: '222px',
        filter: true
    });
    $('#cbPtoMedida').multipleSelect({
        width: '222px',
        filter: true
    });
    $('#FechaDesde').Zebra_DatePicker({
        
    });

    $('#FechaHasta').Zebra_DatePicker({
       
    });

    $('#cbTipoInformacion').change(function () {
        cambiarFormatoFecha($(this).val());
    });
    $('#btnBuscar').click(function () {
        buscarDatos();
    });
    $('#btnGrafico').click(function () {
        generarGrafico();
    });
    cargarPrevio();
    buscarDatos();
});

function cambiarFormatoFecha(tipo) {
    
    switch(tipo){
        case "7":
            $('#FechaDesde').Zebra_DatePicker({
                format: 'm Y'
            });
            $('#FechaHasta').Zebra_DatePicker({
                format: 'm Y'
            });

            var fecha = new Date();
            var mes = "0" + (fecha.getMonth() + 1).toString();
            mes = mes.substr(mes.length - 2, mes.length);
            var stFecha = mes + " " +  fecha.getFullYear();
            $('#FechaDesde').val(stFecha);
            $('#FechaHasta').val(stFecha);
            break;
        default:
            $('#FechaDesde').Zebra_DatePicker({
            });
            $('#FechaHasta').Zebra_DatePicker({
            });
            $('#FechaDesde').val($('#hfFechaDesde').val());
            $('#FechaHasta').val($('#hfFechaHasta').val());

            break;
    }


}

function cargarPrevio(){
    $('#cbEmpresa').multipleSelect('checkAll');
    $('#cbCuenca').multipleSelect('checkAll');
    $('#cbPtoMedida').multipleSelect('checkAll');
    $('#cbTipoInformacion').val(6);
}
function buscarDatos() {

    $('#reporte').css("display", "block");
    $('#graficos').css("display", "none");
    mostrarListado(1);
}

function mostrarListado(nroPagina) {
    var empresa = $('#cbEmpresa').multipleSelect('getSelects');
    var cuenca = $('#cbCuenca').multipleSelect('getSelects');
    if (empresa == "[object Object]") empresa = "-1";
    $('#hfEmpresa').val(empresa);
    $('#hfCuenca').val(cuenca);
    var tipoInformacion = $('#cbTipoInformacion').val();
    $.ajax({
        type: 'POST',
        url: controlador + "reporte/lista",
        data: {
            idsEmpresa: $('#hfEmpresa').val(), idsCuenca: $('#hfCuenca').val(), idTipoInformacion: tipoInformacion,
            fechaInicial: $('#FechaDesde').val(), fechaFinal: $('#FechaHasta').val(),
            nroPagina: nroPagina
        },
        success: function (evt) {
            $('#listado').css("width", $('#mainLayout').width() + "px");
            
            $('#listado').html(evt);
            if ($('#tabla th').length > 1) {
                $('#tabla').dataTable({
                    "aoColumns": aoColumns(),
                    "bSort": false,
                    "scrollY": 430,
                    "scrollX": true,
                    "sDom": 't',
                    "iDisplayLength": 50
                });
            }
        },
        error: function () {
            alert("Ha ocurrido un error");
        }
    });
}

function aoColumns() {
    var ao = [];
    $("#tabla th").each(function (i, th) {
        switch (i) {
            case 0:
                ao.push({ "sWidth": "70px" });
                break;
            default:
                ao.push({ "sWidth": "100px" });
                break;
        }
    });
    return ao;
}

function generarGrafico() {

    $('#reporte').css("display", "none");
    //$('#paginado').css("display", "none");
    $('#graficos').css("display", "block");

    $.ajax({
        type: 'POST',
        url: controlador + "reporte/graficoreporte",
        data: {
            fechaInicial: $('#FechaDesde').val(), fechaFinal: $('#FechaHasta').val(),
            tiposEmpresa: $('#hfTipoEmpresa').val(), empresas: $('#hfEmpresa').val(),
            tiposEquipo: $('#hfTipoEquipo').val(), interrupcion: $('#cbInterrupcion').val(),
            tiposMantto: $('#hfTipoMantto').val(), equipos: $('#hfEquipo').val()
        },
        dataType: 'json',
        success: function (result) {
            graficoHidrologia(result);
        },
        error: function () {
            alert("Ha ocurrido un error");
        }
    });

    graficoHidrologia = function (result) {
        var json = result;
        var jsontipomanto = [];
        $('#graficos').highcharts({
            chart: {
                type: 'spline'
            },
            title: {
                text: 'Snow depth at Vikjafjellet, Norway'
            },
            subtitle: {
                text: 'Irregular time data in Highcharts JS'
            },
            xAxis: {
                type: 'datetime',
                dateTimeLabelFormats: { // don't display the dummy year
                    month: '%e. %b',
                    year: '%b'
                },
                title: {
                    text: 'Date'
                }
            },
            yAxis: {
                title: {
                    text: 'Snow depth (m)'
                },
                min: 0
            },
            tooltip: {
                headerFormat: '<b>{series.name}</b><br>',
                pointFormat: '{point.x:%e. %b}: {point.y:.2f} m'
            },

            plotOptions: {
                spline: {
                    marker: {
                        enabled: true
                    }
                }
            },

            series: [{
                name: 'Winter 2007-2008',
                // Define the data points. All series have a dummy year
                // of 1970/71 in order to be compared on the same x axis. Note
                // that in JavaScript, months start at 0 for January, 1 for February etc.
                data: [
                    [Date.UTC(1970, 9, 27), 0],
                    [Date.UTC(1970, 10, 10), 0.6],
                    [Date.UTC(1970, 10, 18), 0.7],
                    [Date.UTC(1970, 11, 2), 0.8],
                    [Date.UTC(1970, 11, 9), 0.6],
                    [Date.UTC(1970, 11, 16), 0.6],
                    [Date.UTC(1970, 11, 28), 0.67],
                    [Date.UTC(1971, 0, 1), 0.81],
                    [Date.UTC(1971, 0, 8), 0.78],
                    [Date.UTC(1971, 0, 12), 0.98],
                    [Date.UTC(1971, 0, 27), 1.84],
                    [Date.UTC(1971, 1, 10), 1.80],
                    [Date.UTC(1971, 1, 18), 1.80],
                    [Date.UTC(1971, 1, 24), 1.92],
                    [Date.UTC(1971, 2, 4), 2.49],
                    [Date.UTC(1971, 2, 11), 2.79],
                    [Date.UTC(1971, 2, 15), 2.73],
                    [Date.UTC(1971, 2, 25), 2.61],
                    [Date.UTC(1971, 3, 2), 2.76],
                    [Date.UTC(1971, 3, 6), 2.82],
                    [Date.UTC(1971, 3, 13), 2.8],
                    [Date.UTC(1971, 4, 3), 2.1],
                    [Date.UTC(1971, 4, 26), 1.1],
                    [Date.UTC(1971, 5, 9), 0.25],
                    [Date.UTC(1971, 5, 12), 0]
                ]
            }, {
                name: 'Winter 2008-2009',
                data: [
                    [Date.UTC(1970, 9, 18), 0],
                    [Date.UTC(1970, 9, 26), 0.2],
                    [Date.UTC(1970, 11, 1), 0.47],
                    [Date.UTC(1970, 11, 11), 0.55],
                    [Date.UTC(1970, 11, 25), 1.38],
                    [Date.UTC(1971, 0, 8), 1.38],
                    [Date.UTC(1971, 0, 15), 1.38],
                    [Date.UTC(1971, 1, 1), 1.38],
                    [Date.UTC(1971, 1, 8), 1.48],
                    [Date.UTC(1971, 1, 21), 1.5],
                    [Date.UTC(1971, 2, 12), 1.89],
                    [Date.UTC(1971, 2, 25), 2.0],
                    [Date.UTC(1971, 3, 4), 1.94],
                    [Date.UTC(1971, 3, 9), 1.91],
                    [Date.UTC(1971, 3, 13), 1.75],
                    [Date.UTC(1971, 3, 19), 1.6],
                    [Date.UTC(1971, 4, 25), 0.6],
                    [Date.UTC(1971, 4, 31), 0.35],
                    [Date.UTC(1971, 5, 7), 0]
                ]
            }, {
                name: 'Winter 2009-2010',
                data: [
                    [Date.UTC(1970, 9, 9), 0],
                    [Date.UTC(1970, 9, 14), 0.15],
                    [Date.UTC(1970, 10, 28), 0.35],
                    [Date.UTC(1970, 11, 12), 0.46],
                    [Date.UTC(1971, 0, 1), 0.59],
                    [Date.UTC(1971, 0, 24), 0.58],
                    [Date.UTC(1971, 1, 1), 0.62],
                    [Date.UTC(1971, 1, 7), 0.65],
                    [Date.UTC(1971, 1, 23), 0.77],
                    [Date.UTC(1971, 2, 8), 0.77],
                    [Date.UTC(1971, 2, 14), 0.79],
                    [Date.UTC(1971, 2, 24), 0.86],
                    [Date.UTC(1971, 3, 4), 0.8],
                    [Date.UTC(1971, 3, 18), 0.94],
                    [Date.UTC(1971, 3, 24), 0.9],
                    [Date.UTC(1971, 4, 16), 0.39],
                    [Date.UTC(1971, 4, 21), 0]
                ]
            }]
        });
    }

}