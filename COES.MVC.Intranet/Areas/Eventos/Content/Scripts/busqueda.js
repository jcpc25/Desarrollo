var controlador = siteRoot + 'eventos/'

function mostrarAreas()
{
    var idEmpresa = "0";
    if ($('#cbEmpresa').val() != "" && $('#cbEmpresa').val() != "0")
    {
        idEmpresa = $('#cbEmpresa').val();
        $.ajax({
            type: "POST",
            url: controlador + "busqueda/area",
            data: {idEmpresa: idEmpresa },
            success: function (evt) {
                $('#cntArea').html(evt);             
                oTable = $('#tabla').dataTable({
                    "sPaginationType": "full_numbers",
                    "destroy": "true",
                    "bInfo": false,
                    "bLengthChange": false
                });
            },
            error: function (req, status, error) {
                alert("Ha ocurrido un error.");
            }
        });
    }
}

function mostrarEquipos(idArea)
{
    var idEmpresa = "0";
    var idFamilia = "0";
    $('#hfIdArea').val(idArea);

    if ($('#cbEmpresa').val() != "" && $('#cbEmpresa').val() != "0") {
        idEmpresa = $('#cbEmpresa').val();
        $('#hfIdEmpresa').val(idEmpresa);
        if ($('#cbFamilia').val() != "") {
            idFamilia = $('#cbFamilia').val();           
        }
        $('#hfIdFamilia').val(idFamilia);

        pintarPaginado(idEmpresa, idFamilia, idArea);
        pintarBusqueda(1);
    }
    else
    {
        alert("Seleccione empresa");      
    }
}


function pintarPaginado(idEmpresa, idFamilia, idArea)
{
    $.ajax({
        type: "POST",
        url: controlador + "busqueda/paginado",
        data: { idEmpresa: idEmpresa, idFamilia: idFamilia, idArea: idArea, filtro: $('#txtFiltro').val() },
        success: function (evt) {
            $('#cntPaginado').html(evt);
            mostrarPaginado();
        },
        error: function (req, status, error) {
            alert("Ha ocurrido un error.");
        }
    });
}

function pintarBusqueda(nroPagina)
{
    var idArea = "0";
    if ($('#hfIdArea').val() != "")
    {
        idArea = $('#hfIdArea').val();
    }   

    $.ajax({
        type: "POST",
        url: controlador + "busqueda/resultado",
        data: { idEmpresa: $('#hfIdEmpresa').val(), idFamilia: $('#hfIdFamilia').val(), idArea: idArea, filtro: $('#txtFiltro').val(), nroPagina : nroPagina },
        success: function (evt) {
            $('#cntEquipo').html(evt);
        },
        error: function (req, status, error) {
            alert("Ha ocurrido un error.");
        }
    });
}