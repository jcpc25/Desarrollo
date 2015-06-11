var controlador = siteRoot + 'hidrologia/';
var tipoInformacion = 0;
var opc = 0;
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
    $('#Anho').Zebra_DatePicker({
        format: 'Y',
        onSelect: function () {
            cargarSemanaAnho()
        }
     });   
    $('#cbTipoInformacion').change(function () {
        cambiarFormatoFecha($(this).val());
        desactivaBtn();
        $('#listado').html("");
        $('#paginado').html("");
    });
    $('#btnBuscar').click(function () {
        opc = 1;
        var resultado = validarFiltros();
        if (resultado == "") {
            buscarDatos();
            activaBtn();
        }
        else {
            alert("Error:" + resultado);
        }
        
    });
    $('#btnBuscar2').click(function () {
        opc = 2;
        buscarDatos();
        
    });
    $('#btnGrafico').click(function () {
        var tipoInformacion = $('#cbTipoInformacion').val();        
        if (tipoInformacion == 5) {
            pintarPaginado(0) // 0: paginado de grafico, 1: paginado de lista
        }        
        generarGrafico(1);
    });   
    $('#btnExpotar').click(function () {
        exportarExcel();
    });
    cargarPrevio();
    buscarDatos();
    cargarSemanaAnho()
});


function validarFiltros() {
    var empresa = $('#cbEmpresa').multipleSelect('getSelects');
    var cuenca = $('#cbCuenca').multipleSelect('getSelects');
    var tipoInformacion = $('#cbTipoInformacion').val();
    var resultado = "";
    var fini = $('#FechaDesde').val();
    var ffin = $('#FechaHasta').val();    
    var semanaIni = $('#SemanaIni select').val();
    var semanaFin = $('#SemanaFin select').val();   

    if (empresa == "") {
        resultado = "Debe seleccionar una empresa."
        return resultado;
    }
    if (cuenca == "") {
        resultado = "Debe selecionar una cuenca";
        return resultado;
    }


    if (tipoInformacion == 4) { // rpte semanal        
        var com = Number(semanaIni) > Number(semanaFin);    
        if (semanaIni == 0) {
            resultado = "Debe seleccionar una semana de inicio";
            return resultado;
        }
        if (semanaFin == 0) {
            resultado = "Debe seleccionar una semana fin";
            return resultado;
        }
        if (com) {
            resultado = "La semana inicio no puede ser mayor a la semana final";
            return resultado;
        }
    }
    if (tipoInformacion == 7) { // rpte mensual        
        if ((process(fini)) > (process(ffin))) {
            resultado = "El mes inicial no puede ser mayor que el mes final’";
            return resultado;
        }
    }
    else {        
        if ((process(fini)) > (process(ffin))) {
            resultado = "La fecha inicial no puede ser mayor que la fecha final’";
            return resultado;
        }
    }
    return resultado;
}

function process(date) { //format YYYY/MM/DD
    var tipoInformacion = $('#cbTipoInformacion').val();
    
    if (tipoInformacion == 7) {
        var parts = date.split(" ");
        return new Date(parts[1], parts[0] - 1, 1);
    }
    var parts = date.split("/");
    return new Date(parts[2], parts[1]-1, parts[0]);
}

function mostrar_ocultar_FiltrosSemanal(opc) {    
    if (opc == 1) {
        $('#idTr td').show();
    }
    if (opc == 0) {
        $('#idTr td').hide();               
    }
}

function activaBtn() {
    $('#btnGrafico').show();
    $('#btnExpotar').show();
}

function desactivaBtn() {
    $('#btnGrafico').hide();
    $('#btnExpotar').hide();
}

function cargarSemanaAnho() {
    var anho = $('#Anho').val();
    $('#hfAnho').val(anho);
    $.ajax({
        type: 'POST',
        url: controlador + 'reporte/CargarSemanas',

        data: { idAnho: $('#hfAnho').val() },

        success: function (aData) {

            $('#SemanaIni').html(aData);
            $('#SemanaFin').html(aData);
        },
        error: function () {
            alert("Ha ocurrido un error");
        }
    });

}

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
            mostrar_ocultar_FiltrosSemanal(0)
            break;
        case "4":
            mostrar_ocultar_FiltrosSemanal(1)
            break;
        default:
            $('#FechaDesde').Zebra_DatePicker({
            });
            $('#FechaHasta').Zebra_DatePicker({
            });
            $('#FechaDesde').val($('#hfFechaDesde').val());
            $('#FechaHasta').val($('#hfFechaHasta').val());
            mostrar_ocultar_FiltrosSemanal(0)
            break;
    }


}

function cargarPrevio(){
    $('#cbEmpresa').multipleSelect('checkAll');
    $('#cbCuenca').multipleSelect('checkAll');
    $('#cbPtoMedida').multipleSelect('checkAll');
    $('#cbTipoInformacion').val(5);
    var fecha = new Date();       
    var stFecha = fecha.getFullYear();
    $('#Anho').val(stFecha);
    $('#SemanaIni select').val(1);
    $('#SemanaFin select').val(1);
    $('#idTr td').hide();
    desactivaBtn();

}

function buscarDatos() {
    var tipoInformacion = $('#cbTipoInformacion').val();   
    $('#reporte').css("display", "block");
    $('#graficos').css("display", "none");
    if (tipoInformacion == 5) {
        pintarPaginado(1)
    }
    mostrarListado(1);
}

function mostrarListado(nroPagina) {
    var empresa = $('#cbEmpresa').multipleSelect('getSelects');
    var cuenca = $('#cbCuenca').multipleSelect('getSelects');
    var anho = $('#Anho').val();
    var semanaIni = $('#SemanaIni select').val();
    var semanaFin = $('#SemanaFin select').val();    
    if (semanaIni == undefined) semanaIni = 0;
    if (semanaFin == undefined) semanaFin = 1;
    if (empresa == "[object Object]") empresa = "-1";
    if (empresa == "") empresa = "-1";
    if (cuenca == "[object Object]") cuenca = "-1";
    if (cuenca == "") cuenca = "-1";

    $('#hfEmpresa').val(empresa);
    $('#hfCuenca').val(cuenca);
    $('#hfAnho').val(anho);
    $('#hfSemanaIni').val(semanaIni);
    $('#hfSemanaFin').val(semanaFin);
    var tipoInformacion = $('#cbTipoInformacion').val();

    $.ajax({
        type: 'POST',
        url: controlador + "reporte/lista",
        data: {
            idsEmpresa: $('#hfEmpresa').val(), idsCuenca: $('#hfCuenca').val(), idTipoInformacion: tipoInformacion,
            fechaInicial: $('#FechaDesde').val(), fechaFinal: $('#FechaHasta').val(),
            nroPagina: nroPagina, anho: $('#hfAnho').val(), semanaIni: $('#hfSemanaIni').val(), semanaFin: $('#hfSemanaFin').val(),
            opcion: opc
        },
        success: function (evt) {
            $('#listado').css("width", $('#mainLayout').width() + "px");
            
            $('#listado').html(evt);           
            //if ($('#tabla th').length > 1) {
            //    $('#tabla').dataTable({
            //        "aoColumns": aoColumns(),
            //        "bSort": false,
            //        "scrollY": 430,
            //        "scrollX": true,
            //        "sDom": 't',
            //        "iDisplayLength": 50
            //    });
            //}
        },
        error: function () {
            alert("Ha ocurrido un error en lista");
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
    tipoInformacion = $('#cbTipoInformacion').val();    
    $('#excelGrafico').css("display", "block");
    $('#excelGrafico').html("<img onclick='exportar_Grafico();' width='32px' style='cursor: pointer; display: inline;' src='" + siteRoot + "Content/Images/ExportExcel.png' />");
    $('#graficos').css("display", "block");
    var anho = $('#Anho').val();
    var semanaIni = $('#SemanaIni select').val();
    var semanaFin = $('#SemanaFin select').val();
    if (semanaIni == undefined) semanaIni = 0;
    if (semanaFin == undefined) semanaFin = 1;
    var empresa = $('#cbEmpresa').multipleSelect('getSelects');
    var cuenca = $('#cbCuenca').multipleSelect('getSelects');
    var ptoMedida = $('#cbPtoMedida').multipleSelect('getSelects');
    var fechadesde = $('#FechaDesde').val();
    var fechahasta = $('#FechaHasta').val();            
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
    $('#hfAnho').val(anho);
    $('#hfSemanaIni').val(semanaIni);
    $('#hfSemanaFin').val(semanaFin);

    $.ajax({
        type: 'POST',
        url: controlador + "reporte/graficoreporte",
        data: {
            fechaInicial: $('#hfFechaDesde').val(), fechaFinal: $('#hfFechaHasta').val(),
            idsEmpresas: $('#hfEmpresa').val(), idTipoInformacion: tipoInformacion, idsCuencas: $('#hfCuenca').val(),
            nroPagina: nroPagina, anho: $('#hfAnho').val(), semanaIni: $('#hfSemanaIni').val(), semanaFin: $('#hfSemanaFin').val()
            //idptomedida: $('#hfPtoMedida').val()
        },
        dataType: 'json',
        success: function (result) {            
            var tipo = result.TipoReporte;            
            switch (tipo) {
                case 7: //PROGRAMADO MENSUAL - QN
                    //$('#excelGrafico').html("<img width='32px' style='cursor: pointer; display: inline;' src='" + siteRoot + "Content/Images/ExportExcel.png' />");
                    graficoHidrologiaMes(result);
                    //$('#excelGrafico').html("<img onclick='exportar_ManttoEmpresa();' width='32px' style='cursor: pointer; display: inline;' src='" + siteRoot + "Content/Images/ExportExcel.png' />");                   
                    break;
                case 5: //EJECUTADO DIARIO - Q TURB. VERT.
                    graficoHidrologiaDiario(result);
                    break;
                case 4: ////PROGRAMADO SEMANAL - QN.
                    graficoHidrologiaSemanal(result);
                    break;
                default:
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
            text: 'Caudal por puntos de Medición - Programado Mensual'
        },
        xAxis: {

            categories: result.ListaCategoriaGrafico,
            style: {

                fontSize: '5'
            },

            title: {
                text: result.TitlexAxis
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
            text: 'Caudal por puntos de Medición - Programado Diario'
        },
        xAxis: {

            categories: result.ListaCategoriaGrafico,
            style: {

                fontSize: '5'
            },

            title: {
                text: result.TitlexAxis
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

graficoHidrologiaSemanal = function (result) {
    var opcion = {
        chart: {
            type: 'spline'
        },
        title: {
            text: result.TituloReporte
        },
        subtitle: {
            text: 'Caudal por puntos de Medición - Programado Semanal'
        },
        xAxis: {

            categories: result.ListaCategoriaGrafico,
            style: {

                fontSize: '5'
            },

            title: {
                text: result.TitlexAxis
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

function exportarExcel() {
    var empresa = $('#cbEmpresa').multipleSelect('getSelects');
    var cuenca = $('#cbCuenca').multipleSelect('getSelects');
    var anho = $('#Anho').val();
    var semanaIni = $('#SemanaIni select').val();
    var semanaFin = $('#SemanaFin select').val();    
    if (semanaIni == undefined) semanaIni = 0;
    if (semanaFin == undefined) semanaFin = 1;
    if (empresa == "[object Object]") empresa = "-1";
    if (empresa == "") empresa = "-1";
    if (cuenca == "[object Object]") cuenca = "-1";
    if (cuenca == "") cuenca = "-1";

    $('#hfEmpresa').val(empresa);
    $('#hfCuenca').val(cuenca);
    $('#hfAnho').val(anho);
    $('#hfSemanaIni').val(semanaIni);
    $('#hfSemanaFin').val(semanaFin);
    var tipoInformacion = $('#cbTipoInformacion').val();

    $.ajax({
        type: 'POST',
        url: controlador + 'reporte/GenerarArchivoReporteXLS',
        data: {
            idsEmpresa: $('#hfEmpresa').val(), idsCuenca: $('#hfCuenca').val(), idTipoInformacion: tipoInformacion,
            fechaInicial: $('#FechaDesde').val(), fechaFinal: $('#FechaHasta').val(),
            annho: $('#hfAnho').val(), semanaIni: $('#hfSemanaIni').val(), semanaFin: $('#hfSemanaFin').val()
        },
        dataType: 'json',
        success: function (result) {
            if (result == 7) {//PROGRAMADO MENSUAL - QN
                window.location = controlador + "reporte/ExportarReporte?tipo=0";
            }
            if (result == 5) {//EJECUTADO DIARIO - Q TURB. VERT.
                window.location = controlador + "reporte/ExportarReporte?tipo=2";
            }
            if (result == 4) {//PROGRAMADO SEMANAL - QN.
                window.location = controlador + "reporte/ExportarReporte?tipo=4";
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

function exportar_Grafico(){     
    var tipoinf = tipoInformacion;
    
    switch (tipoinf) {
        case '7': //PROGRAMADO MENSUAL - QN                      
            exportar_GrafMensualQN()
            break;
        case '5': //EJECUTADO DIARIO - Q TURB. VERT.
            exportar_GrafDiario01();
            break;
        default:
            break;
    }            
}

// Genera Reporte excel de grafico Programado Mensual QN
function exportar_GrafMensualQN() {    
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

// Genera Reporte excel de grafico Programado Diario Q.Turb. Vert.
function exportar_GrafDiario01() {
    $.ajax({
        type: 'POST',
        url: controlador + "reporte/GenerarArchivoGrafDiario01",
        data: {
            fechaInicial: $('#hfFechaDesde').val(), fechaFinal: $('#hfFechaHasta').val()
        },
        dataType: 'json',
        success: function (result) {
            if (result == 1) {
                window.location = controlador + "reporte/ExportarReporte?tipo=3";
            }
            if (result == -1) {
                mostrarError();
            }
        },
        error: function () {
            alert("Error en Ajax Grafico export a Excel");
        }
    });
}