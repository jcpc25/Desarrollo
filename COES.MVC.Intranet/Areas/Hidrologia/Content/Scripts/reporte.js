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
        var tipoInformacion = $('#cbTipoInformacion').val();
        if (tipoInformacion != 7) {
            pintarPaginado(0) // 0: paginado de grafico, 1: paginado de lista
        }
        
        generarGrafico(1);
    });   
    $('#btnExpotar').click(function () {
        exportar();
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
        case "4":
            $('#FechaDesde').Zebra_DatePicker({
                format: 'Y'
            });
            $('#FechaHasta').Zebra_DatePicker({
                format: 'Y'
            });

            var fecha = new Date();
            //var anho = "0" + (fecha.getYear()).toString();
            var stFecha = fecha.getFullYear();
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
    var tipoInformacion = $('#cbTipoInformacion').val();   
    $('#reporte').css("display", "block");
    $('#graficos').css("display", "none");
    if (tipoInformacion != 7) {
        pintarPaginado(1)
    }
    mostrarListado(1);
}

function mostrarListado(nroPagina) {
    var empresa = $('#cbEmpresa').multipleSelect('getSelects');
    var cuenca = $('#cbCuenca').multipleSelect('getSelects');

    if (empresa == "[object Object]") empresa = "-1";
    if (empresa == "") empresa = "-1";
    if (cuenca == "[object Object]") cuenca = "-1";
    if (cuenca == "") cuenca = "-1";

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

function generarGrafico(nroPagina) {

    $('#reporte').css("display", "none");
    //$('#paginado').css("display", "none");   

    $('#excelGrafico').css("display", "block");
    $('#excelGrafico').html("<img onclick='exportar_GrafMensualQN();' width='32px' style='cursor: pointer; display: inline;' src='" + siteRoot + "Content/Images/ExportExcel.png' />");

    $('#graficos').css("display", "block");
    var empresa = $('#cbEmpresa').multipleSelect('getSelects');
    var cuenca = $('#cbCuenca').multipleSelect('getSelects');
    var ptoMedida = $('#cbPtoMedida').multipleSelect('getSelects');
    var fechadesde = $('#FechaDesde').val();
    var fechahasta = $('#FechaHasta').val();
    var tipoInformacion = $('#cbTipoInformacion').val();
        
    if (empresa == "[object Object]") empresa = "-1";
    if (empresa == "") empresa = "-1";
    if (cuenca == "[object Object]") cuenca = "-1";
    if (cuenca == "") cuenca = "-1";
    if (ptoMedida == "[object Object]") ptoMedida = "-1";
    if (ptoMedida == "") ptoMedida = -1 

    $('#hfEmpresa').val(empresa);
    $('#hfCuenca').val(cuenca);
    $('#hfPtoMedida').val(ptoMedida);
    $('#hfFechaDesde').val(fechadesde);
    $('#hfFechaHasta').val(fechahasta);

    $.ajax({
        type: 'POST',
        url: controlador + "reporte/graficoreporte",
        data: {
            fechaInicial: $('#hfFechaDesde').val(), fechaFinal: $('#hfFechaHasta').val(),
            idsEmpresas: $('#hfEmpresa').val(), idTipoInformacion: tipoInformacion, idsCuencas: $('#hfCuenca').val(),
            nroPagina: nroPagina
            //idptomedida: $('#hfPtoMedida').val()
        },
        dataType: 'json',
        success: function (result) {            
            var tipo = result.TipoReporte;
            switch(tipo){
                case 7:
                    //$('#excelGrafico').html("<img width='32px' style='cursor: pointer; display: inline;' src='" + siteRoot + "Content/Images/ExportExcel.png' />");
                    graficoHidrologiaMes(result);
                    //$('#excelGrafico').html("<img onclick='exportar_ManttoEmpresa();' width='32px' style='cursor: pointer; display: inline;' src='" + siteRoot + "Content/Images/ExportExcel.png' />");                   
                    break;
                default:
                    graficoHidrologiaDiario(result);
                    break;
            }            
        },
        error: function () {
            alert("Ha ocurrido un error en generar grafico");
        }
    });  
}

graficoHidrologiaMes = function (result) {
    var opcion = {
        chart: {
            type: 'spline'
        },
        title: {
            text: result.TituloReporte
        },
        subtitle: {
            text: 'Caudal por puntos de Medición'
        },
        xAxis: {

            categories: result.ListaCategoriaGrafico,
            style: {

                fontSize: '5'
            },

            title: {
                text: 'Meses'
            },
        },
        yAxis: {
            title: {
                text: 'Caudal (m3/s)'
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

        series: []
    };
    for (var i in result.ListaSerieName) {
        opcion.series.push({
            name: result.ListaSerieName[i],
            data: result.ListaSerieData[i]
        });
    }
    $('#graficos').highcharts(opcion);
}

graficoHidrologiaDiario = function (result) {
    var opcion = {
        chart: {
            type: 'spline'
        },
        title: {
            text: result.TituloReporte
        },
        subtitle: {
            text: 'Caudal por puntos de Medición'
        },
        xAxis: {

            categories: result.ListaCategoriaGrafico,
            style: {

                fontSize: '5'
            },

            title: {
                text: 'Meses'
            },
        },
        yAxis: {
            title: {
                text: 'Caudal (m3/s)'
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

        series: []
    };
    for (var i in result.ListaSerieName) {
        opcion.series.push({
            name: result.ListaSerieName[i],
            data: result.ListaSerieData[i]
        });
    }
    $('#graficos').highcharts(opcion);
}

function pintarPaginado(id) {
    var empresa = $('#cbEmpresa').multipleSelect('getSelects');
    var cuenca = $('#cbCuenca').multipleSelect('getSelects');

    if (empresa == "[object Object]") empresa = "-1";
    if (empresa == "") empresa = "-1";
    if (cuenca == "[object Object]") cuenca = "-1";
    if (cuenca == "") cuenca = "-1";

    $('#hfEmpresa').val(empresa);
    $('#hfCuenca').val(cuenca);

    var tipoInformacion = $('#cbTipoInformacion').val();

    $.ajax({
        type: 'POST',
        url: controlador + "reporte/paginado",
        data: {
            idsEmpresa: $('#hfEmpresa').val(), idsCuenca: $('#hfCuenca').val(), idTipoInformacion: tipoInformacion,
            fechaInicial: $('#FechaDesde').val(), fechaFinal: $('#FechaHasta').val()
        },
        success: function (evt) {
            $('#paginado').html(evt);           
            mostrarPaginado(id);
        },
        error: function () {
            alert("Ha ocurrido un error paginado");
        }
    });
}

function pintarBusqueda(nroPagina, itipo) {
    if (itipo == 0) {
        generarGrafico(nroPagina);       
    }
    else {
        mostrarListado(nroPagina);
    }
}

function exportar() {
    var empresa = $('#cbEmpresa').multipleSelect('getSelects');
    var cuenca = $('#cbCuenca').multipleSelect('getSelects');

    if (empresa == "[object Object]") empresa = "-1";
    if (empresa == "") empresa = "-1";
    if (cuenca == "[object Object]") cuenca = "-1";
    if (cuenca == "") cuenca = "-1";

    $('#hfEmpresa').val(empresa);
    $('#hfCuenca').val(cuenca);
    var tipoInformacion = $('#cbTipoInformacion').val();

    $.ajax({
        type: 'POST',
        url: controlador + 'reporte/GenerarArchivoReporte',
        data: {
            idsEmpresa: $('#hfEmpresa').val(), idsCuenca: $('#hfCuenca').val(), idTipoInformacion: tipoInformacion,
            fechaInicial: $('#FechaDesde').val(), fechaFinal: $('#FechaHasta').val(),
        },
        dataType: 'json',
        success: function (result) {
            if (result == 1) {
                window.location = controlador + "reporte/ExportarReporte?tipo=0";
            }
            if (result == -1) {
               alert("Error en reporte result")
            }
        },
        error: function () {
            mostrarError();
        }
    });
}

mostrarError = function () {
    alert("Ha ocurrido un error em reprte2 ");
}

function exportar_GrafMensualQN() {  // Genera Reporte excel de grafico Programado Mensual QN
    $.ajax({
        type: 'POST',
        url: controlador + "reporte/GenerarArchivoGrafMensualQN",
        data: {
            fechaInicial: $('#hfFechaDesde').val(), fechaFinal: $('#hfFechaHasta').val()            
        },
        dataType: 'json',
        success: function (result) {
            if (result == 1) {
                window.location = controlador + "reporte/ExportarReporte?tipo=1";
            }
            if (result == -1) {
                mostrarError();
            }
        },
        error: function () {
            alert("Error en Ajax Exportar Empresa");
        }
    });
}