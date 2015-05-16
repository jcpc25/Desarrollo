var controlador = siteRoot + "transferencias/envioinformacion/";
var series = [];
//var seriesA = [];
var seriesB = [];
var labels = [];

$(document).ready(function () {


    
    $("#VersionG").prop("disabled", true);
    $("#PERICODI3").change(function () {
        if ($("#PERICODI3").val() != "") {
            var options = {};
            options.url = controlador + "GetVersion";
            options.type = "POST";
            options.data = JSON.stringify({ pericodi: $("#PERICODI3").val() });
            options.dataType = "json";
            options.contentType = "application/json";
            options.success = function (states) {
                console.log(states);
                $("#VersionG").empty();
                $("#VersionG").removeAttr("disabled");
                $.each(states, function (k, v) {
                    var a = '<option value=' + v.Recacodi + '>' + v.Recacodi + '</option>';
                    $('#VersionG').append(a);
                    console.log(a);
                });


            };
            options.error = function () { alert("Error retrieving version!"); };
            $.ajax(options);
        }
        else {
            $("#VersionG").empty();
            $("#VersionG").prop("disabled", true);
        }
    });




    $("#Version").prop("disabled", true);
    $("#PERICODI").change(function () {
        if ($("#PERICODI").val() != "") {
            var options = {};
            options.url = controlador + "GetVersion";
            options.type = "POST";
            options.data = JSON.stringify({ pericodi: $("#PERICODI").val() });
            options.dataType = "json";
            options.contentType = "application/json";
            options.success = function (states) {
                console.log(states);
                $("#Version").empty();
                $("#Version").removeAttr("disabled");
                $.each(states, function (k, v) {
                    var a = '<option value=' + v.Recacodi + '>' + v.Recacodi + '</option>';
                    $('#Version').append(a);
                    console.log(a);
                });


            };
            options.error = function () { alert("Error retrieving version!"); };
            $.ajax(options);
        }
        else {
            $("#Version").empty();
            $("#Version").prop("disabled", true);
        }
    });



    $('#btnGenerarExcel').click(function () {
        generarExcel();
    });

    $('#btnGenerarExcel1').click(function () {
        generarExcel1();
    });

    $('#tab-container').easytabs({
        animate: false
    });


    $('#btnVer').click(function () {
        
        listaEntregaRetiro();
    });


    $('#btnProcesarFile').click(function () {
        procesarArchivo();
    });


    $('#Clean').click(function () {

        LimpiarGrafico();
    });
});

loadInfoFile = function (fileName, fileSize) {
    $('#fileInfo').html(fileName + " (" + fileSize + ")");
}

loadValidacionFile = function (mensaje) {
    $('#fileInfo').html(mensaje);
}

mostrarProgreso = function (porcentaje) {
    $('#progreso').text(porcentaje + "%");
}

mostrarError = function () {
    alert("Ha ocurrido un error.");
}

mostrarMensaje = function (mensaje) {
    alert(mensaje);

}

generarExcel = function () {
    if ($("#PERIANIOMES option:selected").val() == "") {    
        alert("Seleccione un Periodo");
    }
    else {
        if ($("#EMPRCODI").val() == "")
        {
            alert("Seleccione una Empresa");
        }
        else{

    $.ajax({
        type: 'POST',
        url: controlador + 'generarexcel',
        dataType: 'json',
        data: { periodo: $("#PERIANIOMES option:selected").val(), sEmp:$("#EMPRCODI").val() },
        success: function (result) {
            if (result == 1) {
                window.location = controlador + 'abrirexcel';
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
}

generarExcel1 = function () {

    if ($("#Pericodi").val() == "") {
        alert("Seleccione un Periodo");
    }
    else {

        sPericodi = $("#Pericodi").val();
        $.ajax({
            type: 'POST',
            url: controlador + 'generarexcel1',
            dataType: 'json',
            data: { sPericodi: sPericodi },
            success: function (result) {
                if (result == 1) {
                    window.location = controlador + 'abrirexcel1';
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

listaEntregaRetiro = function () {
    var cbo = $("#PERICODI3 option:selected").val();

    if (cbo == "") {
        alert('Seleccione Periodo');
    }
    else {
        if ($("#EMPRCODI3").val() == "")
        {
            alert('Seleccione Empresa');
        }
        else
        {
            document.getElementById("divResultado").style.display = "";
            emprcodi = $("#EMPRCODI3").val();
            peri = $("#PERICODI3 option:selected").val();
            version = $("#VersionG").val();
          
        $.ajax({
            url: controlador + 'getListRetiroEntrega',
            type: 'GET',
            data: { periodo: peri, Empr: emprcodi, Vers: version },
            success: function (result) {

                lista(result.entr, result.reti);
            },
            error: function () {
                alert('error a listar los resultados')
            }
        });

			   $("#tabla").find("tr:gt(0)").remove();
        function lista(entr, reti) {
            //Lista de Entregas
            $.each(entr, function (k, v) {
                var sListaEntrega = "";
                sListaEntrega += "<tr>";
                sListaEntrega += '<td><a  href=# id=view_' + v.Codientrcodigo + ' ' + 'class=Vergrafico' + '><img  src="/Areas/Transferencias/Content/Images/view.gif" title="Insertar linea en el grafico" alt="Insertar linea en el grafico" /></a></td>';
                sListaEntrega += '<td>' + v.Codientrcodigo + '</td>';
                sListaEntrega += '<td>' + v.Emprnombre + '</td>';
                sListaEntrega += '<td>' + v.Centgenenombre + '</td>';
                sListaEntrega += '<td>' + v.Barrnombre + ' </td>';
                sListaEntrega += '<td>' + v.Tranentripoinformacion + ' </td>';
                sListaEntrega += '<td>' + v.Total + '</td>';
                sListaEntrega += '<td><a style="display:box;float:right" href=# id=view_' + v.Codientrcodigo + ' ' + 'class=Del ><img  src="/Areas/Transferencias/Content/Images/tachito.gif" title="Retirar linea del grafico" alt="Retirar linea del grafico" /></a></td>';
                sListaEntrega += '</tr>';
                $('#tabla').append(sListaEntrega);
            });
            //Lista de Retiros
            $.each(reti, function (k, v) {
                var sListaRetiro = '';
                sListaRetiro += '<tr>';
                sListaRetiro += '<td><a  href=# id=view_' + v.Solicodireticodigo + ' ' + 'class=Vergrafico' + '><img  src="/Areas/Transferencias/Content/Images/view.jpg" title="Insertar linea en el grafico" alt="Insertar linea en el grafico" /></a></a></td>';
                sListaRetiro += '<td>' + v.Solicodireticodigo + '</td>';
                sListaRetiro += '<td>' + v.Emprnombre + '</td>';
                sListaRetiro += '<td>' + v.Clinombre + '</td>';
                sListaRetiro += '<td>' + v.Barrnombre + ' </td>';
                sListaRetiro += '<td>' + v.Tranretitipoinformacion + ' </td>';
                sListaRetiro += '<td>' + v.Total + '</td>';
                sListaRetiro += '<td><a   style="display:box;float:right" href=# id=view_' + v.Solicodireticodigo + ' ' + 'class=Del >' + '<img  src="/Areas/Transferencias/Content/Images/tachito.gif" title="Retirar linea del grafico" alt="Retirar linea del grafico" />' + '</a></td>';
                sListaRetiro += '</tr>';
                $('#tabla').append(sListaRetiro);
            });
            add_Ver();
            Del();
        }
    }

    }


}

//Funciones llamar ver grafico
function add_Ver() {

    $(".Vergrafico").click(function (e) {
        e.preventDefault();

        id = $(this).attr("id").split("_")[1];
        ;

        peri = $("#PERICODI3 option:selected").val();
        empresa = $("#EMPRCODI3").val();
        $.ajax({
            type: "GET",
            dataType: "json",
            url: controlador + "FetchGraphData/",
            data:
                {
                    periodo: peri,
                    codigoER: id,
                    empr: empresa

                },
            success: function (result) {

                if ($.isEmptyObject(result.dataER)) {
                    alert("No hay información");
                } else {
                    testJqPlot(result.dataER, result.dataCodigo);

                }
            },
            error: function () {
                mostrarError();
            }

        });

        function testJqPlot(dataER, dataCodigo) {
            console.log(dataER)
            var line1 = [];
            var existe = 0;
            var cont = 1440;
            var line2 = [];
            //var contDia = cont / 60;

            for (var key in labels) {
                var a = labels[key];
                if (a.label == (dataCodigo))
                    existe = 1;
            }

            if (existe == 1) {
                alert('El registro ya fue previamente seleccionado');
            }
            else {

                //var contDia = cont / 60;
                if (dataCodigo[0] == 'I') {
                    $.each(dataER, function (index, item) {

                        for (var prop in item) {

                            if (prop == 'Tranentrdetah1') {
                                var contDia = cont / 1440; line1.push([contDia, 4 * item[prop]]);
                                cont += 15;
                            }
                            if (prop == 'Tranentrdetah2') {

                                var contDia = cont / 1440; line1.push([contDia, 4 * item[prop]]);
                                cont += 15;

                            }
                            if (prop == 'Tranentrdetah3') {

                                var contDia = cont / 1440; line1.push([contDia, 4 * item[prop]]);
                                cont += 15;

                            }
                            if (prop == 'Tranentrdetah4') {
                                var contDia = cont / 1440; line1.push([contDia, 4 * item[prop]]);
                                cont += 15;
                            }
                            if (prop == 'Tranentrdetah5') {
                                var contDia = cont / 1440; line1.push([contDia, 4 * item[prop]]);
                                cont += 15;
                            }
                            if (prop == 'Tranentrdetah6') {
                                var contDia = cont / 1440; line1.push([contDia, 4 * item[prop]]);
                                cont += 15;
                            }
                            if (prop == 'Tranentrdetah7') {
                                var contDia = cont / 1440; line1.push([contDia, 4 * item[prop]]);
                                cont += 15;
                            }
                            if (prop == 'Tranentrdetah8') {
                                var contDia = cont / 1440; line1.push([contDia, 4 * item[prop]]);
                                cont += 15;
                            }
                            if (prop == 'Tranentrdetah9') {
                                var contDia = cont / 1440; line1.push([contDia, 4 * item[prop]]);
                                cont += 15;
                            }

                            if (prop == 'Tranentrdetah10') {
                                var contDia = cont / 1440; line1.push([contDia, 4 * item[prop]]);
                                cont += 15;
                            }
                            if (prop == 'Tranentrdetah11') {

                                var contDia = cont / 1440; line1.push([contDia, 4 * item[prop]])
                                cont += 15;
                            }
                            if (prop == 'Tranentrdetah12') {

                                var contDia = cont / 1440; line1.push([contDia, 4 * item[prop]])
                                cont += 15;
                            }
                            if (prop == 'Tranentrdetah13') {

                                var contDia = cont / 1440; line1.push([contDia, 4 * item[prop]])
                                cont += 15;
                            }
                            if (prop == 'Tranentrdetah14') {

                                var contDia = cont / 1440; line1.push([contDia, 4 * item[prop]])
                                cont += 15;
                            }
                            if (prop == 'Tranentrdetah15') {

                                var contDia = cont / 1440; line1.push([contDia, 4 * item[prop]])
                                cont += 15;
                            }
                            if (prop == 'Tranentrdetah16') {

                                var contDia = cont / 1440; line1.push([contDia, 4 * item[prop]])
                                cont += 15;
                            }
                            if (prop == 'Tranentrdetah17') {

                                var contDia = cont / 1440; line1.push([contDia, 4 * item[prop]])
                                cont += 15;
                            }
                            if (prop == 'Tranentrdetah18') {

                                var contDia = cont / 1440; line1.push([contDia, 4 * item[prop]])
                                cont += 15;
                            }
                            if (prop == 'Tranentrdetah19') {

                                var contDia = cont / 1440; line1.push([contDia, 4 * item[prop]])
                                cont += 15;
                            }
                            if (prop == 'Tranentrdetah20') {

                                var contDia = cont / 1440; line1.push([contDia, 4 * item[prop]])
                                cont += 15;
                            }
                            if (prop == 'Tranentrdetah21') {

                                var contDia = cont / 1440; line1.push([contDia, 4 * item[prop]])
                                cont += 15;
                            }
                            if (prop == 'Tranentrdetah22') {

                                var contDia = cont / 1440; line1.push([contDia, 4 * item[prop]])
                                cont += 15;
                            }
                            if (prop == 'Tranentrdetah23') {

                                var contDia = cont / 1440; line1.push([contDia, 4 * item[prop]])
                                cont += 15;
                            }
                            if (prop == 'Tranentrdetah24') {

                                var contDia = cont / 1440; line1.push([contDia, 4 * item[prop]])
                                cont += 15;
                            }
                            if (prop == 'Tranentrdetah25') {

                                var contDia = cont / 1440; line1.push([contDia, 4 * item[prop]])
                                cont += 15;
                            }
                            if (prop == 'Tranentrdetah26') {

                                var contDia = cont / 1440; line1.push([contDia, 4 * item[prop]])
                                cont += 15;
                            }
                            if (prop == 'Tranentrdetah27') {

                                var contDia = cont / 1440; line1.push([contDia, 4 * item[prop]])
                                cont += 15;
                            }
                            if (prop == 'Tranentrdetah28') {

                                var contDia = cont / 1440; line1.push([contDia, 4 * item[prop]])
                                cont += 15;
                            }
                            if (prop == 'Tranentrdetah29') {

                                var contDia = cont / 1440; line1.push([contDia, 4 * item[prop]])
                                cont += 15;
                            }
                            if (prop == 'Tranentrdetah30') {

                                var contDia = cont / 1440; line1.push([contDia, 4 * item[prop]])
                                cont += 15;
                            }
                            if (prop == 'Tranentrdetah31') {

                                var contDia = cont / 1440; line1.push([contDia, 4 * item[prop]])
                                cont += 15;
                            }
                            if (prop == 'Tranentrdetah32') {

                                var contDia = cont / 1440; line1.push([contDia, 4 * item[prop]])
                                cont += 15;
                            }
                            if (prop == 'Tranentrdetah33') {

                                var contDia = cont / 1440; line1.push([contDia, 4 * item[prop]])
                                cont += 15;
                            }
                            if (prop == 'Tranentrdetah34') {

                                var contDia = cont / 1440; line1.push([contDia, 4 * item[prop]])
                                cont += 15;
                            }
                            if (prop == 'Tranentrdetah35') {

                                var contDia = cont / 1440; line1.push([contDia, 4 * item[prop]])
                                cont += 15;
                            }
                            if (prop == 'Tranentrdetah36') {

                                var contDia = cont / 1440; line1.push([contDia, 4 * item[prop]])
                                cont += 15;
                            }
                            if (prop == 'Tranentrdetah37') {

                                var contDia = cont / 1440; line1.push([contDia, 4 * item[prop]])
                                cont += 15;
                            }
                            if (prop == 'Tranentrdetah38') {

                                var contDia = cont / 1440; line1.push([contDia, 4 * item[prop]])
                                cont += 15;
                            }
                            if (prop == 'Tranentrdetah39') {

                                var contDia = cont / 1440; line1.push([contDia, 4 * item[prop]])
                                cont += 15;
                            }
                            if (prop == 'Tranentrdetah40') {

                                var contDia = cont / 1440; line1.push([contDia, 4 * item[prop]])
                                cont += 15;
                            }
                            if (prop == 'Tranentrdetah41') {

                                var contDia = cont / 1440; line1.push([contDia, 4 * item[prop]])
                                cont += 15;
                            }
                            if (prop == 'Tranentrdetah42') {

                                var contDia = cont / 1440; line1.push([contDia, 4 * item[prop]])
                                cont += 15;
                            }
                            if (prop == 'Tranentrdetah43') {

                                var contDia = cont / 1440; line1.push([contDia, 4 * item[prop]])
                                cont += 15;
                            }
                            if (prop == 'Tranentrdetah44') {

                                var contDia = cont / 1440; line1.push([contDia, 4 * item[prop]])
                                cont += 15;
                            }
                            if (prop == 'Tranentrdetah45') {

                                var contDia = cont / 1440; line1.push([contDia, 4 * item[prop]])
                                cont += 15;
                            }
                            if (prop == 'Tranentrdetah46') {

                                var contDia = cont / 1440; line1.push([contDia, 4 * item[prop]])
                                cont += 15;
                            }
                            if (prop == 'Tranentrdetah47') {

                                var contDia = cont / 1440; line1.push([contDia, 4 * item[prop]])
                                cont += 15;
                            }
                            if (prop == 'Tranentrdetah48') {

                                var contDia = cont / 1440; line1.push([contDia, 4 * item[prop]])
                                cont += 15;
                            }
                            if (prop == 'Tranentrdetah49') {

                                var contDia = cont / 1440; line1.push([contDia, 4 * item[prop]])
                                cont += 15;
                            }
                            if (prop == 'Tranentrdetah50') {

                                var contDia = cont / 1440; line1.push([contDia, 4 * item[prop]])
                                cont += 15;
                            }
                            if (prop == 'Tranentrdetah51') {

                                var contDia = cont / 1440; line1.push([contDia, 4 * item[prop]])
                                cont += 15;
                            }
                            if (prop == 'Tranentrdetah52') {

                                var contDia = cont / 1440; line1.push([contDia, 4 * item[prop]])
                                cont += 15;
                            }
                            if (prop == 'Tranentrdetah53') {

                                var contDia = cont / 1440; line1.push([contDia, 4 * item[prop]])
                                cont += 15;
                            }
                            if (prop == 'Tranentrdetah54') {

                                var contDia = cont / 1440; line1.push([contDia, 4 * item[prop]])
                                cont += 15;
                            }
                            if (prop == 'Tranentrdetah55') {

                                var contDia = cont / 1440; line1.push([contDia, 4 * item[prop]])
                                cont += 15;
                            }
                            if (prop == 'Tranentrdetah56') {

                                var contDia = cont / 1440; line1.push([contDia, 4 * item[prop]])
                                cont += 15;
                            }
                            if (prop == 'Tranentrdetah57') {

                                var contDia = cont / 1440; line1.push([contDia, 4 * item[prop]])
                                cont += 15;
                            }
                            if (prop == 'Tranentrdetah58') {

                                var contDia = cont / 1440; line1.push([contDia, 4 * item[prop]])
                                cont += 15;
                            }
                            if (prop == 'Tranentrdetah59') {

                                var contDia = cont / 1440; line1.push([contDia, 4 * item[prop]])
                                cont += 15;
                            }
                            if (prop == 'Tranentrdetah60') {

                                var contDia = cont / 1440; line1.push([contDia, 4 * item[prop]])
                                cont += 15;
                            }
                            if (prop == 'Tranentrdetah61') {

                                var contDia = cont / 1440; line1.push([contDia, 4 * item[prop]])
                                cont += 15;
                            }
                            if (prop == 'Tranentrdetah62') {

                                var contDia = cont / 1440; line1.push([contDia, 4 * item[prop]])
                                cont += 15;
                            }
                            if (prop == 'Tranentrdetah63') {

                                var contDia = cont / 1440; line1.push([contDia, 4 * item[prop]])
                                cont += 15;
                            }
                            if (prop == 'Tranentrdetah64') {

                                var contDia = cont / 1440; line1.push([contDia, 4 * item[prop]])
                                cont += 15;
                            }
                            if (prop == 'Tranentrdetah65') {

                                var contDia = cont / 1440; line1.push([contDia, 4 * item[prop]])
                                cont += 15;
                            }
                            if (prop == 'Tranentrdetah66') {

                                var contDia = cont / 1440; line1.push([contDia, 4 * item[prop]])
                                cont += 15;
                            }
                            if (prop == 'Tranentrdetah67') {

                                var contDia = cont / 1440; line1.push([contDia, 4 * item[prop]])
                                cont += 15;
                            }
                            if (prop == 'Tranentrdetah68') {

                                var contDia = cont / 1440; line1.push([contDia, 4 * item[prop]])
                                cont += 15;
                            }
                            if (prop == 'Tranentrdetah69') {

                                var contDia = cont / 1440; line1.push([contDia, 4 * item[prop]])
                                cont += 15;
                            }
                            if (prop == 'Tranentrdetah70') {

                                var contDia = cont / 1440; line1.push([contDia, 4 * item[prop]])
                                cont += 15;
                            }
                            if (prop == 'Tranentrdetah71') {

                                var contDia = cont / 1440; line1.push([contDia, 4 * item[prop]])
                                cont += 15;
                            }
                            if (prop == 'Tranentrdetah72') {

                                var contDia = cont / 1440; line1.push([contDia, 4 * item[prop]])
                                cont += 15;
                            }
                            if (prop == 'Tranentrdetah73') {

                                var contDia = cont / 1440; line1.push([contDia, 4 * item[prop]])
                                cont += 15;
                            }
                            if (prop == 'Tranentrdetah74') {

                                var contDia = cont / 1440; line1.push([contDia, 4 * item[prop]])
                                cont += 15;
                            }
                            if (prop == 'Tranentrdetah75') {

                                var contDia = cont / 1440; line1.push([contDia, 4 * item[prop]])
                                cont += 15;
                            }
                            if (prop == 'Tranentrdetah76') {

                                var contDia = cont / 1440; line1.push([contDia, 4 * item[prop]])
                                cont += 15;
                            }
                            if (prop == 'Tranentrdetah77') {

                                var contDia = cont / 1440; line1.push([contDia, 4 * item[prop]])
                                cont += 15;
                            }
                            if (prop == 'Tranentrdetah78') {

                                var contDia = cont / 1440; line1.push([contDia, 4 * item[prop]])
                                cont += 15;
                            }
                            if (prop == 'Tranentrdetah79') {

                                var contDia = cont / 1440; line1.push([contDia, 4 * item[prop]])
                                cont += 15;
                            }
                            if (prop == 'Tranentrdetah80') {

                                var contDia = cont / 1440; line1.push([contDia, 4 * item[prop]])
                                cont += 15;
                            }
                            if (prop == 'Tranentrdetah81') {

                                var contDia = cont / 1440; line1.push([contDia, 4 * item[prop]])
                                cont += 15;
                            }
                            if (prop == 'Tranentrdetah82') {

                                var contDia = cont / 1440; line1.push([contDia, 4 * item[prop]])
                                cont += 15;
                            }
                            if (prop == 'Tranentrdetah83') {

                                var contDia = cont / 1440; line1.push([contDia, 4 * item[prop]])
                                cont += 15;
                            }
                            if (prop == 'Tranentrdetah84') {

                                var contDia = cont / 1440; line1.push([contDia, 4 * item[prop]])
                                cont += 15;
                            }
                            if (prop == 'Tranentrdetah85') {

                                var contDia = cont / 1440; line1.push([contDia, 4 * item[prop]])
                                cont += 15;
                            }
                            if (prop == 'Tranentrdetah86') {

                                var contDia = cont / 1440; line1.push([contDia, 4 * item[prop]])
                                cont += 15;
                            }
                            if (prop == 'Tranentrdetah87') {

                                var contDia = cont / 1440; line1.push([contDia, 4 * item[prop]])
                                cont += 15;
                            }
                            if (prop == 'Tranentrdetah88') {

                                var contDia = cont / 1440; line1.push([contDia, 4 * item[prop]])
                                cont += 15;
                            }
                            if (prop == 'Tranentrdetah89') {

                                var contDia = cont / 1440; line1.push([contDia, 4 * item[prop]])
                                cont += 15;
                            }
                            if (prop == 'Tranentrdetah90') {

                                var contDia = cont / 1440; line1.push([contDia, 4 * item[prop]])
                                cont += 15;
                            }
                            if (prop == 'Tranentrdetah91') {

                                var contDia = cont / 1440; line1.push([contDia, 4 * item[prop]])
                                cont += 15;
                            }
                            if (prop == 'Tranentrdetah92') {

                                var contDia = cont / 1440; line1.push([contDia, 4 * item[prop]])
                                cont += 15;
                            }
                            if (prop == 'Tranentrdetah93') {

                                var contDia = cont / 1440; line1.push([contDia, 4 * item[prop]])
                                cont += 15;
                            }
                            if (prop == 'Tranentrdetah94') {

                                var contDia = cont / 1440; line1.push([contDia, 4 * item[prop]])
                                cont += 15;
                            }
                            if (prop == 'Tranentrdetah95') {

                                var contDia = cont / 1440; line1.push([contDia, 4 * item[prop]])
                                cont += 15;
                            }
                            if (prop == 'Tranentrdetah96') {

                                var contDia = cont / 1440; line1.push([contDia, 4 * item[prop]])
                                cont += 15;
                            }


                            //console.log("o." + prop + " = " + 4*item[prop] + " " + prop[prop.length -1]);
                        }
                        //}
                        //line1.push([item.Tranentrdetadia, item.Tranentrdetapromdia])
                    });
                }

                else {
                    $.each(dataER, function (index, item) {
                        for (var prop in item) {

                            if (prop == 'Tranretidetah1') {


                                var contDia = cont / 1440; line1.push([contDia, 4 * item[prop]]);
                                cont += 15;


                            }
                            if (prop == 'Tranretidetah2') {

                                var contDia = cont / 1440; line1.push([contDia, 4 * item[prop]]);
                                cont += 15;

                            }
                            if (prop == 'Tranretidetah3') {

                                var contDia = cont / 1440; line1.push([contDia, 4 * item[prop]]);
                                cont += 15;

                            }
                            if (prop == 'Tranretidetah4') {
                                var contDia = cont / 1440; line1.push([contDia, 4 * item[prop]]);
                                cont += 15;
                            }
                            if (prop == 'Tranretidetah5') {
                                var contDia = cont / 1440; line1.push([contDia, 4 * item[prop]]);
                                cont += 15;
                            }
                            if (prop == 'Tranretidetah6') {
                                var contDia = cont / 1440; line1.push([contDia, 4 * item[prop]]);
                                cont += 15;
                            }
                            if (prop == 'Tranretidetah7') {
                                var contDia = cont / 1440; line1.push([contDia, 4 * item[prop]]);
                                cont += 15;
                            }
                            if (prop == 'Tranretidetah8') {
                                var contDia = cont / 1440; line1.push([contDia, 4 * item[prop]]);
                                cont += 15;
                            }
                            if (prop == 'Tranretidetah9') {
                                var contDia = cont / 1440; line1.push([contDia, 4 * item[prop]]);
                                cont += 15;
                            }

                            if (prop == 'Tranretidetah10') {
                                var contDia = cont / 1440; line1.push([contDia, 4 * item[prop]]);
                                cont += 15;
                            }
                            if (prop == 'Tranretidetah11') {

                                var contDia = cont / 1440; line1.push([contDia, 4 * item[prop]])
                                cont += 15;
                            }
                            if (prop == 'Tranretidetah12') {

                                var contDia = cont / 1440; line1.push([contDia, 4 * item[prop]])
                                cont += 15;
                            }
                            if (prop == 'Tranretidetah13') {

                                var contDia = cont / 1440; line1.push([contDia, 4 * item[prop]])
                                cont += 15;
                            }
                            if (prop == 'Tranretidetah14') {

                                var contDia = cont / 1440; line1.push([contDia, 4 * item[prop]])
                                cont += 15;
                            }
                            if (prop == 'Tranretidetah15') {

                                var contDia = cont / 1440; line1.push([contDia, 4 * item[prop]])
                                cont += 15;
                            }
                            if (prop == 'Tranretidetah16') {

                                var contDia = cont / 1440; line1.push([contDia, 4 * item[prop]])
                                cont += 15;
                            }
                            if (prop == 'Tranretidetah17') {

                                var contDia = cont / 1440; line1.push([contDia, 4 * item[prop]])
                                cont += 15;
                            }
                            if (prop == 'Tranretidetah18') {

                                var contDia = cont / 1440; line1.push([contDia, 4 * item[prop]])
                                cont += 15;
                            }
                            if (prop == 'Tranretidetah19') {

                                var contDia = cont / 1440; line1.push([contDia, 4 * item[prop]])
                                cont += 15;
                            }
                            if (prop == 'Tranretidetah20') {

                                var contDia = cont / 1440; line1.push([contDia, 4 * item[prop]])
                                cont += 15;
                            }
                            if (prop == 'Tranretidetah21') {

                                var contDia = cont / 1440; line1.push([contDia, 4 * item[prop]])
                                cont += 15;
                            }
                            if (prop == 'Tranretidetah22') {

                                var contDia = cont / 1440; line1.push([contDia, 4 * item[prop]])
                                cont += 15;
                            }
                            if (prop == 'Tranretidetah23') {

                                var contDia = cont / 1440; line1.push([contDia, 4 * item[prop]])
                                cont += 15;
                            }
                            if (prop == 'Tranretidetah24') {

                                var contDia = cont / 1440; line1.push([contDia, 4 * item[prop]])
                                cont += 15;
                            }
                            if (prop == 'Tranretidetah25') {

                                var contDia = cont / 1440; line1.push([contDia, 4 * item[prop]])
                                cont += 15;
                            }
                            if (prop == 'Tranretidetah26') {

                                var contDia = cont / 1440; line1.push([contDia, 4 * item[prop]])
                                cont += 15;
                            }
                            if (prop == 'Tranretidetah27') {

                                var contDia = cont / 1440; line1.push([contDia, 4 * item[prop]])
                                cont += 15;
                            }
                            if (prop == 'Tranretidetah28') {

                                var contDia = cont / 1440; line1.push([contDia, 4 * item[prop]])
                                cont += 15;
                            }
                            if (prop == 'Tranretidetah29') {

                                var contDia = cont / 1440; line1.push([contDia, 4 * item[prop]])
                                cont += 15;
                            }
                            if (prop == 'Tranretidetah30') {

                                var contDia = cont / 1440; line1.push([contDia, 4 * item[prop]])
                                cont += 15;
                            }
                            if (prop == 'Tranretidetah31') {

                                var contDia = cont / 1440; line1.push([contDia, 4 * item[prop]])
                                cont += 15;
                            }
                            if (prop == 'Tranretidetah32') {

                                var contDia = cont / 1440; line1.push([contDia, 4 * item[prop]])
                                cont += 15;
                            }
                            if (prop == 'Tranretidetah33') {

                                var contDia = cont / 1440; line1.push([contDia, 4 * item[prop]])
                                cont += 15;
                            }
                            if (prop == 'Tranretidetah34') {

                                var contDia = cont / 1440; line1.push([contDia, 4 * item[prop]])
                                cont += 15;
                            }
                            if (prop == 'Tranretidetah35') {

                                var contDia = cont / 1440; line1.push([contDia, 4 * item[prop]])
                                cont += 15;
                            }
                            if (prop == 'Tranretidetah36') {

                                var contDia = cont / 1440; line1.push([contDia, 4 * item[prop]])
                                cont += 15;
                            }
                            if (prop == 'Tranretidetah37') {

                                var contDia = cont / 1440; line1.push([contDia, 4 * item[prop]])
                                cont += 15;
                            }
                            if (prop == 'Tranretidetah38') {

                                var contDia = cont / 1440; line1.push([contDia, 4 * item[prop]])
                                cont += 15;
                            }
                            if (prop == 'Tranretidetah39') {

                                var contDia = cont / 1440; line1.push([contDia, 4 * item[prop]])
                                cont += 15;
                            }
                            if (prop == 'Tranretidetah40') {

                                var contDia = cont / 1440; line1.push([contDia, 4 * item[prop]])
                                cont += 15;
                            }
                            if (prop == 'Tranretidetah41') {

                                var contDia = cont / 1440; line1.push([contDia, 4 * item[prop]])
                                cont += 15;
                            }
                            if (prop == 'Tranretidetah42') {

                                var contDia = cont / 1440; line1.push([contDia, 4 * item[prop]])
                                cont += 15;
                            }
                            if (prop == 'Tranretidetah43') {

                                var contDia = cont / 1440; line1.push([contDia, 4 * item[prop]])
                                cont += 15;
                            }
                            if (prop == 'Tranretidetah44') {

                                var contDia = cont / 1440; line1.push([contDia, 4 * item[prop]])
                                cont += 15;
                            }
                            if (prop == 'Tranretidetah45') {

                                var contDia = cont / 1440; line1.push([contDia, 4 * item[prop]])
                                cont += 15;
                            }
                            if (prop == 'Tranretidetah46') {

                                var contDia = cont / 1440; line1.push([contDia, 4 * item[prop]])
                                cont += 15;
                            }
                            if (prop == 'Tranretidetah47') {

                                var contDia = cont / 1440; line1.push([contDia, 4 * item[prop]])
                                cont += 15;
                            }
                            if (prop == 'Tranretidetah48') {

                                var contDia = cont / 1440; line1.push([contDia, 4 * item[prop]])
                                cont += 15;
                            }
                            if (prop == 'Tranretidetah49') {

                                var contDia = cont / 1440; line1.push([contDia, 4 * item[prop]])
                                cont += 15;
                            }
                            if (prop == 'Tranretidetah50') {

                                var contDia = cont / 1440; line1.push([contDia, 4 * item[prop]])
                                cont += 15;
                            }
                            if (prop == 'Tranretidetah51') {

                                var contDia = cont / 1440; line1.push([contDia, 4 * item[prop]])
                                cont += 15;
                            }
                            if (prop == 'Tranretidetah52') {

                                var contDia = cont / 1440; line1.push([contDia, 4 * item[prop]])
                                cont += 15;
                            }
                            if (prop == 'Tranretidetah53') {

                                var contDia = cont / 1440; line1.push([contDia, 4 * item[prop]])
                                cont += 15;
                            }
                            if (prop == 'Tranretidetah54') {

                                var contDia = cont / 1440; line1.push([contDia, 4 * item[prop]])
                                cont += 15;
                            }
                            if (prop == 'Tranretidetah55') {

                                var contDia = cont / 1440; line1.push([contDia, 4 * item[prop]])
                                cont += 15;
                            }
                            if (prop == 'Tranretidetah56') {

                                var contDia = cont / 1440; line1.push([contDia, 4 * item[prop]])
                                cont += 15;
                            }
                            if (prop == 'Tranretidetah57') {

                                var contDia = cont / 1440; line1.push([contDia, 4 * item[prop]])
                                cont += 15;
                            }
                            if (prop == 'Tranretidetah58') {

                                var contDia = cont / 1440; line1.push([contDia, 4 * item[prop]])
                                cont += 15;
                            }
                            if (prop == 'Tranretidetah59') {

                                var contDia = cont / 1440; line1.push([contDia, 4 * item[prop]])
                                cont += 15;
                            }
                            if (prop == 'Tranretidetah60') {

                                var contDia = cont / 1440; line1.push([contDia, 4 * item[prop]])
                                cont += 15;
                            }
                            if (prop == 'Tranretidetah61') {

                                var contDia = cont / 1440; line1.push([contDia, 4 * item[prop]])
                                cont += 15;
                            }
                            if (prop == 'Tranretidetah62') {

                                var contDia = cont / 1440; line1.push([contDia, 4 * item[prop]])
                                cont += 15;
                            }
                            if (prop == 'Tranretidetah63') {

                                var contDia = cont / 1440; line1.push([contDia, 4 * item[prop]])
                                cont += 15;
                            }
                            if (prop == 'Tranretidetah64') {

                                var contDia = cont / 1440; line1.push([contDia, 4 * item[prop]])
                                cont += 15;
                            }
                            if (prop == 'Tranretidetah65') {

                                var contDia = cont / 1440; line1.push([contDia, 4 * item[prop]])
                                cont += 15;
                            }
                            if (prop == 'Tranretidetah66') {

                                var contDia = cont / 1440; line1.push([contDia, 4 * item[prop]])
                                cont += 15;
                            }
                            if (prop == 'Tranretidetah67') {

                                var contDia = cont / 1440; line1.push([contDia, 4 * item[prop]])
                                cont += 15;
                            }
                            if (prop == 'Tranretidetah68') {

                                var contDia = cont / 1440; line1.push([contDia, 4 * item[prop]])
                                cont += 15;
                            }
                            if (prop == 'Tranretidetah69') {

                                var contDia = cont / 1440; line1.push([contDia, 4 * item[prop]])
                                cont += 15;
                            }
                            if (prop == 'Tranretidetah70') {

                                var contDia = cont / 1440; line1.push([contDia, 4 * item[prop]])
                                cont += 15;
                            }
                            if (prop == 'Tranretidetah71') {

                                var contDia = cont / 1440; line1.push([contDia, 4 * item[prop]])
                                cont += 15;
                            }
                            if (prop == 'Tranretidetah72') {

                                var contDia = cont / 1440; line1.push([contDia, 4 * item[prop]])
                                cont += 15;
                            }
                            if (prop == 'Tranretidetah73') {

                                var contDia = cont / 1440; line1.push([contDia, 4 * item[prop]])
                                cont += 15;
                            }
                            if (prop == 'Tranretidetah74') {

                                var contDia = cont / 1440; line1.push([contDia, 4 * item[prop]])
                                cont += 15;
                            }
                            if (prop == 'Tranretidetah75') {

                                var contDia = cont / 1440; line1.push([contDia, 4 * item[prop]])
                                cont += 15;
                            }
                            if (prop == 'Tranretidetah76') {

                                var contDia = cont / 1440; line1.push([contDia, 4 * item[prop]])
                                cont += 15;
                            }
                            if (prop == 'Tranretidetah77') {

                                var contDia = cont / 1440; line1.push([contDia, 4 * item[prop]])
                                cont += 15;
                            }
                            if (prop == 'Tranretidetah78') {

                                var contDia = cont / 1440; line1.push([contDia, 4 * item[prop]])
                                cont += 15;
                            }
                            if (prop == 'Tranretidetah79') {

                                var contDia = cont / 1440; line1.push([contDia, 4 * item[prop]])
                                cont += 15;
                            }
                            if (prop == 'Tranretidetah80') {

                                var contDia = cont / 1440; line1.push([contDia, 4 * item[prop]])
                                cont += 15;
                            }
                            if (prop == 'Tranretidetah81') {

                                var contDia = cont / 1440; line1.push([contDia, 4 * item[prop]])
                                cont += 15;
                            }
                            if (prop == 'Tranretidetah82') {

                                var contDia = cont / 1440; line1.push([contDia, 4 * item[prop]])
                                cont += 15;
                            }
                            if (prop == 'Tranretidetah83') {

                                var contDia = cont / 1440; line1.push([contDia, 4 * item[prop]])
                                cont += 15;
                            }
                            if (prop == 'Tranretidetah84') {

                                var contDia = cont / 1440; line1.push([contDia, 4 * item[prop]])
                                cont += 15;
                            }
                            if (prop == 'Tranretidetah85') {

                                var contDia = cont / 1440; line1.push([contDia, 4 * item[prop]])
                                cont += 15;
                            }
                            if (prop == 'Tranretidetah86') {

                                var contDia = cont / 1440; line1.push([contDia, 4 * item[prop]])
                                cont += 15;
                            }
                            if (prop == 'Tranretidetah87') {

                                var contDia = cont / 1440; line1.push([contDia, 4 * item[prop]])
                                cont += 15;
                            }
                            if (prop == 'Tranretidetah88') {

                                var contDia = cont / 1440; line1.push([contDia, 4 * item[prop]])
                                cont += 15;
                            }
                            if (prop == 'Tranretidetah89') {

                                var contDia = cont / 1440; line1.push([contDia, 4 * item[prop]])
                                cont += 15;
                            }
                            if (prop == 'Tranretidetah90') {

                                var contDia = cont / 1440; line1.push([contDia, 4 * item[prop]])
                                cont += 15;
                            }
                            if (prop == 'Tranretidetah91') {

                                var contDia = cont / 1440; line1.push([contDia, 4 * item[prop]])
                                cont += 15;
                            }
                            if (prop == 'Tranretidetah92') {

                                var contDia = cont / 1440; line1.push([contDia, 4 * item[prop]])
                                cont += 15;
                            }
                            if (prop == 'Tranretidetah93') {

                                var contDia = cont / 1440; line1.push([contDia, 4 * item[prop]])
                                cont += 15;
                            }
                            if (prop == 'Tranretidetah94') {

                                var contDia = cont / 1440; line1.push([contDia, 4 * item[prop]])
                                cont += 15;
                            }
                            if (prop == 'Tranretidetah95') {

                                var contDia = cont / 1440; line1.push([contDia, 4 * item[prop]])
                                cont += 15;
                            }
                            if (prop == 'Tranretidetah96') {

                                var contDia = cont / 1440; line1.push([contDia, 4 * item[prop]])
                                cont += 15;
                            }

                            //console.log("o." + prop + " = " + 4*item[prop] + " " + prop[prop.length -1]);
                        }
                    });

                }

                var a = { label: dataCodigo, lineWidth: 0.5, markerOptions: { size: 0.5, style: 'dimaond' }, showMarker: false };

                labels.push(a);

                var cantidadTotal = line1.length - 1536;
                line2 = line1.splice(1536, cantidadTotal);
                series.push(line1);
                seriesB.push(line2);
                console.log(cantidadTotal);
                console.log(line2);

                grafico();
            }


        }

    });
};

grafico = function () {
    if (series.length > 0) {
        $("#grafico").empty();
        var plot1 = $.jqplot('grafico', series,
             {
                 series: labels,
                 legend: {
                     show: true,
                     location: 'ne',  // compass direction, nw, n, ne, e, se, s, sw, w.
                     placement: 'inside'
                 },
                 axes: {
                     xaxis: {
                          tickOptions: { formatString: "%#.2f" },
                         pad:1,
                         min: 1,
                         max: 17,
                         numberTicks: 9
                     },
                     yaxis: {
                         label: 'MW.H',
                         tickOptions: { formatString: "%#.5f" },
                         pad: 0
                     }

                 },
                 highlighter: {
                     show: true,
                     sizeAdjust: 13.5
                 },
                 cursor: {
                     show: true,
                     zoom: true
                 }

             }
             );


        ///////GRAFICO 2

        $("#grafico2").empty();

        var plot2 = $.jqplot('grafico2', seriesB,
            {
                series: labels,


                legend: {
                    show: true,
                    location: 'ne',  // compass direction, nw, n, ne, e, se, s, sw, w.
                    placement: 'inside'
                },
                axes: {
                    xaxis: {
                        label: 'Dia',
                      pad:17,
                        min: 17,
                        max: 33,
                        numberTicks: 9,
                        tickOptions: { formatString: "%#.2f" },
                    },
                    yaxis: {
                        label: 'MW.H',
                        tickOptions: { formatString: "%#.5f" },
                        pad: 0
                    }

                },
                highlighter: {
                    show: true,
                    sizeAdjust: 13.5
                },
                cursor: {
                    show: true,
                    zoom: true
                }
            }
            );

    }
    else {
        $("#grafico").empty();
        $("#grafico2").empty();
    }

    $('#reset').click(function () { plot1.resetZoom(), plot2.resetZoom() });
}

function Del() {


    $(".Del").click(function (e) {
        e.preventDefault();
        if (confirm("Desea Quitar Grafico ?")) {
            id = $(this).attr("id").split("_")[1];


            var index = 0;
            var cont = 0;
            if (series.length > 0) {

                for (var key in labels) {

                    var a = labels[key];

                    if (a.label == (id)) {
                        cont = 1;
                        index = key;
                    }

                }
                if (cont == 1) {

                    series.splice(index, 1);
                    labels.splice(index, 1);
                    seriesB.splice(index, 1);
                    //seriesB.splice(index, 1);
                    console.log(seriesB + ' :numero array serie2  y' + series + 'numero array serie 1');

                    //grafico2();
                    grafico();
                    cont = 0;

                }
                else {
                    alert('No existe');
                }
            }
            else {
                alert('No hay elemntos que borrar');

            }
        };
    });
}

LimpiarGrafico = function () {
    $("#grafico2").empty();
    $("#grafico").empty();

    series.length = 0;
    seriesB.length = 0;
    labels.length = 0;
}
