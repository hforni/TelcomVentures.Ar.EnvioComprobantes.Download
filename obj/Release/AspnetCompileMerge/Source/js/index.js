var $divError, $divTextoError, $divEspera, $divExito;


function assignHTMLControls()
{
    $divError = $("#divError");
    $divEspera = $("#divEspera");
    $divTextoError = $("#divTextoError");
    $divExito = $("#divExito");
}

$(document).ready(function () {
    assignHTMLControls();
    $divError.hide();
    $divEspera.show();
    $divExito.hide();
    var name = GetParameterValues('Name');
    var id_mail = GetParameterValues('id_mail');
    if (isNullOrEmpty(id_mail))
    {  
        $divTextoError.text("No se proporcionaron los datos necesarios");
        $divError.show();
        $divEspera.hide();
        $divExito.hide();
    }
    else 
    {
        DescargaComprobante(id_mail);
    }
});


function DescargaComprobante(idmail)
{
    mostrarLoader();
   var url = "/Api/Envios?idmail=" + idmail + "&inn=65&emm=56";

    $.ajax({
        type: "GET",
        url: url,        
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: OnSuccess,
        failure: function (response) {
            $divTextoError.text("No se encontro el comprobante solcitado");
            $divError.show();
            ocultarLoader();
            $divExito.hide();
        }
    });
 
       
}

function OnSuccess(response) {
    var link = document.createElement('a');

    switch (response) {
        case "":
            $divTextoError.text("No se encontro el comprobante solcitado");
            $divError.show();
            $divEspera.hide();
            $divExito.hide();
            ocultarLoader();
            break;
        case "err1":
            $divTextoError.text("No se encontro el comprobante solcitado");
            $divError.show();
            $divEspera.hide();
            $divExito.hide();
            ocultarLoader();
            break;
        case "err2":
            $divTextoError.text("No se encontro el comprobante solcitado");
            $divError.show();
            $divEspera.hide();
            $divExito.hide();
            ocultarLoader();
            break;
        case "err3":
            $divTextoError.text("Ocurrio un error al descargar el comprobante");
            $divError.show();
            $divEspera.hide();
            $divExito.hide();
            ocultarLoader();
            break;            
   
        default:
            $divExito.show();
            ocultarLoader();
            $("#myLink").attr("href", response);
            link.href = response;
            link.download = response;
            link.dispatchEvent(new MouseEvent('click'));
    }
    
  
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

function mostrarLoader() {
    $(".main").addClass("blur-custom");
    $("#loader").show();
}

function ocultarLoader() {
    $(".main").removeClass("blur-custom");
    $("#loader").hide();
}
 