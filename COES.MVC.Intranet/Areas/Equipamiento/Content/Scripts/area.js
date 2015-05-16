var controlador = siteRoot + 'Equipamiento/';
$(function () {

    $('#cbTipoArea').val($("#idTipoArea").val());
    buscarArea();

    $('#btnBuscar').click(function () {
        //buscarArea();
        document.forms["frmBusqueda"].submit();
    });

    $("#list").jqGrid({
        url: controlador + "area/ListadoAreas",
        width: 700,
        height: 800,
        datatype: 'json',
        mtype: 'GET',
        colNames: ['Código', 'Descripción <br> Ubicación', 'Abreviatura', ''],
        colModel: [
            { name: 'Código ', index: 'Areacodi', width: 120, align: 'left' },
            { name: 'Descripción Ubicación', index: 'Areanomb', width: 200, align: 'left' },
            { name: 'Abreviatura', index: 'Areaabrev', width: 200, align: 'left' },
            { name: '', index: '', width: 180, align: 'left', formatter: AccionFormatter }],
        pager: jQuery('#pager'),
        rowNum: 50,
        rowList: [10, 20, 30, 40, 50],
        onComplete: function () {
        },
        sortname: 'AREANOMB',
        sortorder: "asc",
        viewrecords: true,
        imgpath: 'Content/themes/base/images',
        postData: {
            pTipoArea: function () { return $("#idTipoArea").val(); },
            pNombre: function () { return $("#NombreArea").val(); }
        }
    });

    function AccionFormatter(cellvalue, options, rowObject) {
        var strCarac = "U";
        var strResult = '';
        var ap = String.fromCharCode(39);
        var strResult = '<a href="javascript:Detalle(' + cellvalue + ');">Detalle</a> <a href="javascript:Editar(' + cellvalue + ')">Editar</a>';
        return strResult;
    }
    $("#gbox_list").css("margin-left", "auto");
    $("#gbox_list").css("margin-right", "auto");
    //$(window).resize(function () {
    //    $('#listado').css("width", $('#mainLayout').width() + "px");
    //});
});
function buscarArea() {
    
    //mostrarListado(1);
}

function Detalle(e) {
    window.location.href = controlador + "Area/Detalle?id=" + e;
}
function Editar(e) {
    window.location.href = controlador + "Area/Edit?id=" + e;
}
function Eliminar(e) {
    window.location.href = controlador + "Area/Detalle?idx=" + e;
}


function pintarPaginado() {
    $.ajax({
        type: 'POST',
        url: controlador + "Area/paginado",
        data: $('#frmBusqueda').serialize(),
        success: function (evt) {
            $('#paginado').html(evt);
            
        },
        error: function () {
            alert("Ha ocurrido un error");
        }
    });
}
function mostrarListado(nroPagina) {
    $('#hfNroPagina').val(nroPagina);

    $.ajax({
        type: 'POST',
        url: controlador + "Area/ListarAreas",
        data: $('#frmBusqueda').serialize(),
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