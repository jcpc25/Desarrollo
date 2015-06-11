var controlador = siteRoot + 'hidrologia/'
$(function () {
    $('#cbRecurso').multipleSelect({
        width: '222px',
        filter: true
    });

    $('#btnBuscar').click(function () {
        buscarRecursosCuenca();
    });



    $(window).resize(function () {
        $('#listado').css("width", $('#mainLayout').width() + "px");
    });
});

function buscarRecursosCuenca() {
    //pintarPaginado();
    mostrarListado(1);
}

function mostrarListado(nroPaginas) {
    var ncuenca = $('#cbCuenca').val();
    var recurso = $('#cbRecurso').multipleSelect('getSelects');
    if (recurso == "[object Object]") recurso = "-1";
    if (recurso == "") recurso = "-1";

    
    $('#hfRecurso').val(recurso);
    $.ajax({
        type: 'POST',
        url: controlador + "Topologia/lista",
        data: {
            cuenca: ncuenca,
            recursos: $('#hfRecurso').val(),
            nroPagina: nroPaginas,
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
