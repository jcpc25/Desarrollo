var controlador = siteRoot + 'hidrologia/'
$(function () {

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
    $.ajax({
        type: 'POST',
        url: controlador + "Topologia/lista",
        data: {
            cuenca: ncuenca,
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
