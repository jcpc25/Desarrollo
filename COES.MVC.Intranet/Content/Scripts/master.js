$(document).ready(function () {

    jQuery('ul.sf-menu').superfish({
        animation: { height: 'show' }
    });
    
    $('#CerrarSesion').click(function () {
        confirmOperacion();
    });

    $('#btnOkCerrarSesion').click(function ()
    {
        $.ajax({
            type: "POST",
            url: siteRoot + "home/CerrarSesion",
            cache: false,
            dataType: 'json',
            success: function (evt) {
                location.href = siteRoot + 'home/login';
            },
            error: function (req, status, error) {
                alert("Ha ocurrido un error.");
            }
        });
    });

    $('#btnCancelCerrarSesion').click(function ()
    {
        $('#confirmarClose').bPopup().close();
    });

    $('#btnOcultarMenu').click(function ()
    {
        if ($('#cntMenu').css("display") == "none") {
            $('#cntMenu').css("display", "block");
        }
        else {
            $('#cntMenu').css("display", "none");
        }
    });

    $('#btnOcultarTitulo').click(function ()
    {
        if ($('#cntTitulo').css("display") == "none") {
            $('#cntTitulo').css("display", "block");
            $('#cntLogo').css("display", "block");
        }
        else {
            $('#cntTitulo').css("display", "none");
            $('#cntLogo').css("display", "none");
        }
    });

    cargarMapa();

});

function confirmOperacion()
{
    $('#confirmarClose').bPopup({
        easing: 'easeOutBack',
        speed: 450,
        transition: 'slideDown'
    });
}

$(document).ajaxStart(function ()
{
    $('#loading').bPopup({
        fadeSpeed: 'fast',
        opacity: 0.4,
        followSpeed: 500,
        modalColor: '#000000',        
        modalClose: false
    });
});

$(document).ajaxStop(function ()
{
    $('#loading').bPopup().close();
});

function cargarMapa()
{
    $.ajax({
        type: 'POST',
        url: siteRoot + "home/mostrarmapa",
        dataType: 'json',      
        cache: false,
        success: function (resultado) {
            $('#mapa').html(resultado);
        }
     });
}

function OpenUrl(enlace, tipo, id, controlador, accion)
{      
    if (tipo == "I")
    {
        $('#divGeneral').css("display", "none");
        $('#frameContenido').attr("src", enlace);
        $('#divTemporal').css("display", 'block');
        $('#frameContenido').load(function () {
            setTimeout(iResize, 2000);
        });

        function iResize() {            
            $('#frameContenido').height($('#frameContenido').contents().find("html").height() + 20);
        }

        $.ajax({
            type: 'POST',
            url: siteRoot + "home/setearopcion",
            dataType: 'json',
            data: {
                idOpcion: id
            },
            cache: false,
            success: function (resultado) {
                cargarMapa();
            }
        });
    }
    if (tipo == "F")
    {
        $.ajax({
            type: 'POST',
            url: siteRoot + "home/setearopcion",
            dataType: 'json',
            data: {
                idOpcion: id
            },
            cache: false,
            success: function (resultado) {
                var enlace = "";
                if (controlador != "" && accion != "") {
                    enlace = siteRoot + controlador + "/" + accion + "/";
                }
                else if (controlador != "" && accion == "") {
                    enlace = siteRoot + controlador + "/";
                }
                else {
                    enlace = siteRoot + "#";
                }
                document.location.href = enlace;
            }
        });        
    }   
}
   
