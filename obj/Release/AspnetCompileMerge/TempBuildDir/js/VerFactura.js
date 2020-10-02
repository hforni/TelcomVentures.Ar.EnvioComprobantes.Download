var $divError,  $divEspera, $divExito;

function BajarFactura() {
    // var param = getParameterByName('param');    
    mostrarLoader();
    var url = "/Api/SMSComprobante?param=" + window.param;
    $.ajax({
        type: "GET",
        url: url,
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: OnSuccessDescarga,
        failure: function (response)
        {           
            $divError.show();
            ocultarLoader();
            $divExito.hide();
        }
    });  
}

function OnSuccessDescarga(response) {
    var link = document.createElement('a');
    if (response.d == "http://facturas.antina.com.ar/files/No se encontraron Datos") {
        $("#DivError").text("Ocurrio un error!");
    }
    else {
        link.href = response;
        link.download = response;
        link.dispatchEvent(new MouseEvent('click'));
    }

}


function getParameterByName(name) {
    var regexS = "[\\?&]" + name + "=([^&#]*)",
        regex = new RegExp(regexS),
        results = regex.exec(window.location.search);
    if (results == null) {
        return "";
    } else {
        return decodeURIComponent(results[1].replace(/\+/g, " "));
    }
}


function isEmpty(val) {
    return (val === undefined || val == null || val.length <= 0) ? true : false;
}

function AdherirmeFactura()
{
    alert(window.param);
}


function assignHTMLControls() {
    $divError = $("#divError");
    $divExito = $("#divExito");
}

$(document).ready(function () {
    assignHTMLControls();
    $divError.hide();
    $divExito.hide();
    ocultarLoader();
    var idComprobante = GetParameterValues('param');
    if (isNullOrEmpty(idComprobante))
    {       
        $divError.show();
        $divExito.hide();
    }
    else
    {
        ArmaTelmplate(idComprobante);
    }
});

function mostrarLoader() {
    $(".main").addClass("blur-custom");
    $("#loader").show();
}

function ocultarLoader() {
    $(".main").removeClass("blur-custom");
    $("#loader").hide();
}

function GetParameterValues(param) {
    var url = window.location.href.slice(window.location.href.indexOf('?') + 1).split('&');
    for (var i = 0; i < url.length; i++) {
        var urlparam = url[i].split('=');
        if (urlparam[0] == param) {
            return urlparam[1];
        }
    }
}


function isNullOrEmpty(str) {
    var returnValue = false;
    if (!str
        || str == null
        || str === 'null'
        || str === ''
        || str === '{}'
        || str === 'undefined'
        || str.length === 0) {
        returnValue = true;
    }
    return returnValue;
}

function ArmaTelmplate(idComprobante)
{
    $divError.hide(); 
    mostrarLoader();
    var url = "/Api/SMS?param=" + idComprobante;

    $.ajax({
        type: "GET",
        url: url,
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: OnSuccess,
        failure: function (response) {           
            $divError.show();
            ocultarLoader();
            $divExito.hide();
        }
    });

    function OnSuccess(response)
    {   
        if (response.IdComprobante == "0")
        {
            $divExito.hide();
            $divError.show();  
        }
        else
        {
            $divExito.show();
            $divError.hide();   
            $divExito.html(response.Template);
            window.param = response.IdComprobante;
        }
        ocultarLoader();
    }

 
}
