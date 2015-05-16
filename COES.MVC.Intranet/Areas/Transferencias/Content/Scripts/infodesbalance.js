var infodesbalance = "infodesbalance/";
var controler = siteRoot + "transferencias/" + infodesbalance;


//Funciones de busqueda
$(document).ready(function () {

    $('#btnMostrar').click(function () {
        buscar();
    });

   

});

function buscar() {
    if ($("#PERICODI option:selected").val() == "") {
        alert("Seleccione un Periodo");
    }
    else { 
  
    $.ajax({
        type: 'POST',
        url: controler + "lista",
        data: {  periodo: $("#PERICODI option:selected").val() },
        success: function (evt) {
            $('#listado').html(evt);
            oTable = $('#tabla').dataTable({
                "sPaginationType": "full_numbers",
                "destroy": "true"
            });

           
        },
        error: function () {
            alert("Lo sentimos, se ha producido un error");
        }
    });


    }

};