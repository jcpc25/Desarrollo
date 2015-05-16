$(function () {

    $('#txtFechaInicio').Zebra_DatePicker({               
    });

    $('#txtFechaHasta').Zebra_DatePicker({
    });

    $('#tab-container').easytabs({
        animate: false
    });
});

abrirPopup = function ()
{
    $('#popupUnidad').bPopup({
        easing: 'easeOutBack',
        speed: 450,
        transition: 'slideDown'
    });
}