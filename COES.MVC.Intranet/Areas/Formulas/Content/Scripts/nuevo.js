var controlador = siteRoot + 'formulas/configuracion/'

$(function () {   

    $('#cbFuente').val($('#hfFuente').val());

    $('#cbFuente').change(function () {
        cargarFuente();
    });

    $('#cbOrigen').change(function () {
        mostrarOrigen($('#cbOrigen').val());
    });
    
    $('#btnGrabar').click(function () {
        grabar();
    });

    $('#btnNuevo').click(function () {
        document.location.href = controlador + "nuevo";
    });

    $('#btnAddEdit').click(function () {
        cargarFuenteEdicion();
    });

    $('#btnCancelar').click(function () {
        cancelar();
    });   

});

cargarFuente = function () {
    var count = 0;
    $('#tbItems>tbody tr').each(function (i) {       
        count++;
    });

    if (count == 0) {
        $('#hfFuente').val($('#cbFuente').val());
        $('option', '#cbEmpresa').remove();
        $('option', '#cbPunto').remove();
        $('option', '#cbSubEstacion').remove();

        var fuente = $('#cbFuente').val();
        if (fuente == "E") {
            $('#formulaSCADA').css('display', 'block');
        }
        else {
            $('#formulaSCADA').css('display', 'none');
            mostrarOrigen("D");
        }
    }
    else
    {
        mostrarMensaje('No puede cambiar la fuente.');
        $('#cbFuente').val($('#hfFuente').val());
    }
}

cargarFuenteEdicion = function ()
{
    var fuente = $('#cbFuente').val();
    if (fuente == "E") {
        $('#formulaSCADA').css('display', 'block');
    }
    else {
        $('#formulaSCADA').css('display', 'none');
        mostrarOrigen("D");
    }
}

mostrarOrigen = function (indicador) {
    $.ajax({
        type: "POST",
        url: controlador + "selector",
        data: { indicador: indicador },
        success: function (evt) {
            $('#selector').html(evt);
            $('#hfOrigen').val(indicador);            
        },
        error: function () {
            mostrarError();
        }
    });
}

addPunto = function () {
    var punto = $('#cbPunto').val();    
    if (punto != "") {
        var descripcion = $('#cbPunto option:selected').text();
        var origen = $('#hfOrigen').val();

        var textoOrigen = "";

        if (origen == "M") textoOrigen = "Ejecutado";
        if (origen == "S") textoOrigen = "SCADA";
        if (origen == "D") textoOrigen = "Demanda barras";
        
        var longitud = $('#tbItems> tbody tr').length + 1;

        $('#tbItems> tbody').append(
            '<tr>' +
            '    <td>' +
            '        <input type="hidden" id="thfOrigen" value="' + origen + '"/>' +           
            '        <input type="text" style="width:50px" value="1" onkeydown="mover(event, this)" onkeypress="return validarNumero(this,event)" id="constante' + longitud + '" />' +
            '   </td>' +
            '   <td>' + textoOrigen +'</td>' +
            '   <td>' +
            '        <span>' + descripcion + '</span>' +
            '        <input type="hidden" id="thfPunto" value="' + punto + '" />' +           
            '   </td>' +
            '   <td>' +
            '        <span onClick="$(this).parent().parent().remove();" style="cursor:pointer">Quitar</span>' +
            '   </td>' +
            '</tr>' 
        );
    }
    else {
        mostrarMensaje('Seleccione punto.');        
    }
};

grabar = function () {

    var items = "";
    var count = 0;
    var countArea = 0;   
    var fuente = $('#cbFuente').val();

    $('#tbItems>tbody tr').each(function (i) {        
        $text = $(this).find('input:text');
        $origen = $(this).find('#thfOrigen');
        $punto = $(this).find('#thfPunto');              

        var indicador = "";

        if ($origen.val() == "M" || $origen.val() == "D"){
            indicador = "S";
        }
        if ($origen.val() == "S") {
            indicador = "D";
        }

        var constante = (count > 0) ? "+" : "";
        items = items + constante + $text.val() + indicador + $punto.val();
        count++;
    });

    var roles = "";
    $('#tablaArea input:checked').each(function () {
        roles = roles + $(this).val() + ",";
        countArea++;
    });

    if (count > 0) {
        if (countArea > 0) {     
            var subEstacion = $('#txtSubestacion').val();
            var area = $('#txtArea').val();

            if (subEstacion != "" && area != "") {
                $.ajax({
                    type: 'POST',
                    url: controlador + 'grabar',
                    data: {
                        idFormula: $('#hfIdFormula').val(), fuente: fuente, subEstacion: subEstacion,
                        area: area, roles: roles, items: items
                    },
                    dataType: 'json',
                    cache: false,
                    success: function (resultado) {
                        if (resultado > 0) {
                            editarRegistro(resultado);
                        }
                        else {
                            mostrarError();
                        }
                    },
                    error: function () {
                        mostrarError();
                    }
                });
            }
            else {
                mostrarMensaje("Ingrese la subestación y el área.");
            }
        }
        else {
            mostrarMensaje('Seleccione la(s) área(s).');
        }
    }
    else {
        mostrarMensaje('Agregue items a la fórmula.');
    }   
}

cargarPuntos = function(){       

    if ($('#cbEmpresa').val() != "" && $('#cbSubEstacion').val()!="") {
        $.ajax({
            type: 'POST',
            url: controlador + 'cargarpuntos',
            dataType: 'json',
            data: { idEmpresa: $('#cbEmpresa').val(), idSubEstacion: $('#cbSubEstacion').val() },
            cache: false,
            success: function (aData) {
                $('#cbPunto').get(0).options.length = 0;
                $('#cbPunto').get(0).options[0] = new Option("--SELECCIONE--", "");
                $.each(aData, function (i, item) {
                    $('#cbPunto').get(0).options[$('#cbPunto').get(0).options.length] = new Option(item.Text, item.Value);
                });
            },
            error: function () {
                mostrarError();
            }
        });
    }
    else
    {
        $('option', '#cbPunto').remove();     
    }
}


cargarSubEstacion = function () {
    if ($('#cbEmpresa').val() != "") {
        $.ajax({
            type: 'POST',
            url: controlador + 'cargarsubestacion',
            dataType: 'json',
            data: { idEmpresa: $('#cbEmpresa').val() },
            cache: false,
            success: function (aData) {
                $('#cbSubEstacion').get(0).options.length = 0;
                $('#cbSubEstacion').get(0).options[0] = new Option("--SELECCIONE--", "");
                $.each(aData, function (i, item) {
                    $('#cbSubEstacion').get(0).options[$('#cbSubEstacion').get(0).options.length] = new Option(item.Text, item.Value);
                });
            },
            error: function () {
                mostrarError();
            }
        });
    }
    else {
        $('option', '#cbPunto').remove();
        $('option', '#cbSubEstacion').remove();
    }
}


editarRegistro = function (id)
{
    document.location.href = controlador + "nuevo?id=" + id + "&edit=S";
}

cancelar = function()
{
    document.location.href = controlador + "index";
}

mover = function (e, control)
{
    var str = control.id;
    var indice = str.replace('constante', '');

    if (e.which == '13') {
        var id = '';
        if (indice != '48') {
            id = '#constante' + (parseInt(indice) + 1);
        }
    }
    if (e.which == '40') {
        if (indice != '48') {
            $('#constante' + (parseInt(indice) + 1)).focus();

        }
    }
    if (e.which == '38') {
        if (indice != '1') {
            $('#constante' + (parseInt(indice) - 1)).focus();            
        }
    }
}

mostrarError = function ()
{
    alert('Ha ocurrido un error.');
}

mostrarMensaje = function (mensaje)
{
    alert(mensaje);
}

validarNumero = function (item, evt) {
    evt = (evt) ? evt : window.event;
    var charCode = (evt.which) ? evt.which : evt.keyCode;

    if (charCode == 46) {
        var regex = new RegExp(/\./g)
        var count = $(item).val().match(regex).length;
        if (count > 1) {
            return false;
        }
    }
    
    if (charCode == 45) {
        var regex = new RegExp(/\-/g)
        var count = $(item).val().match(regex).length;
        if (count > 0) {
            return false;
        }
    }   

    if (charCode > 31 && charCode != 45 && (charCode < 48 || charCode > 57)) {
        return false;
    }

    return true;
}