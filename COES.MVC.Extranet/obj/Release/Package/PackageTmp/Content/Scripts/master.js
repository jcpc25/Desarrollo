$(document).ready(function () {
      
});

function confirmOperacion() {
    $('#confirmarClose').bPopup({
        easing: 'easeOutBack',
        speed: 450,
        transition: 'slideDown'
    });
}

$(document).ajaxStart(function () {
    $('#loading').bPopup({
        fadeSpeed: 'fast',
        opacity: 0.4,
        followSpeed: 500, 
        modalColor: '#000000'
    });
});

$(document).ajaxStop(function () {    
    $('#loading').bPopup().close();
});

function OpenUrl(enlace, tipo, id, controlador, accion) {
    if (tipo == "F") {
        $.ajax({
            type: 'POST',
            url: siteRoot + "home/setearopcion",
            dataType: 'json',
            data: {
                idOpcion: id
            },
            cache: false,
            success: function (resultado) {
                if (resultado != "-1") {

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
    else if (tipo == "W") {
        if (id == 302)
        {
            var user = $('#hfUserLogin').val();
            var nuevaurl = "http://coesextranet.azurewebsites.net?user=" + user;
            window.open(nuevaurl, '_blank');
        }
        else if (id == 303)
        {
            var user = $('#hfUserLogin').val();
            var nuevaurl = "http://coesextranet.azurewebsites.net/home/consulta?user=" + user;
            window.open(nuevaurl, '_blank');
        }
        else if (id == 300)
        {
            var user = $('#hfUserEncrypted').val();
            var nuevaurl = "http://www.coes.org.pe/appMedidores/?user=" + user;
            window.open(nuevaurl, '_blank');
        }
        else
        {            
            location.href = initialURL + "/" + enlace;
        }                
    }
    else if (tipo == "E") {
        window.open(enlace, '_blank');
    }

}