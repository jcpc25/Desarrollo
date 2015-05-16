$(document).ready(function () {
    $('#CerrarSesion').click(function () {
        confirmOperacion();
    });

    $('#btnOkCerrarSesion').click(function () {
        $.ajax({
            type: "POST",
            url: url + "/home/CerrarSesion",
            cache: false,
            dataType: 'json',
            success: function (evt) {
                location.href = url + '/home/login';
            },
            error: function (req, status, error) {
                alert("Ha ocurrido un error.");
            }
        });
    });

    $('#btnCancelCerrarSesion').click(function () {
        $('#confirmarClose').bPopup().close();
    });
});

function confirmOperacion() {
    $('#confirmarClose').bPopup({
        easing: 'easeOutBack',
        speed: 450,
        transition: 'slideDown'
    });
}


$(document).ajaxStart(function () {
    $("#loading").show();
   
});

$(document).ajaxStop(function () {
    $("#loading").hide();
   
});

function OpenUrl(enlace, tipo, id, controlador, accion) {

    if (tipo == "F") {
        $.ajax({
            type: 'POST',
            url: url + "/home/setearopcion",
            dataType: 'json',
            data: {
                idOpcion: id
            },
            cache: false,
            success: function (resultado) {
                if (resultado == 1) {
                    if (controlador != "" && accion != "") {
                        location.href = url + "/" + controlador + "/" + accion + "/";
                    }
                    else if (controlador != "" && accion == "") {
                        location.href = url + "/" + controlador + "/";
                    }
                    else {
                        location.href = "#";
                    }
                }
            }
        });

    }
    else if (tipo == "I") {
        $('#divGeneral').css("display", "none");
        $('#frameContenido').attr("src", enlace);
        $('#divTemporal').css("display", 'block');
        $('iframe').load(function () {
            setTimeout(iResize, 100);
        });

        function iResize() {
            $('#frameContenido').height($('#frameContenido').contents().find("html").height() + 20);
        }
    }
    else {
        location.href = enlace;
    }
}