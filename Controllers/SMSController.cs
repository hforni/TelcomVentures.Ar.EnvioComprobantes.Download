using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TelcomVentures.Ar.EnvioComprobantes.Download.DTOs;
using TelcomVentures.AR.Logueo;
using TelnetData;

namespace TelcomVentures.Ar.EnvioComprobantes.Download.Controllers
{
    public class SMSController : ApiController
    {
        public IHttpActionResult Get(string param)
        {
            TelnetData.Crypto tn = new TelnetData.Crypto();
            NegocioSQL.Facturacion facturacion = new NegocioSQL.Facturacion();
            SmsDTO smsDTO = new SmsDTO();
            try
            { 
            string idComprobanteDesencriptado = tn.Decrypt(param.Replace("SLASH", "/").Replace("PLUS", "+"), "Un5e_223f12").Trim();
            string TipoTexto = idComprobanteDesencriptado.Substring(idComprobanteDesencriptado.LastIndexOf("TEXTO"));
            idComprobanteDesencriptado = idComprobanteDesencriptado.Substring(0, idComprobanteDesencriptado.IndexOf("TEXTO"));
            smsDTO.IdComprobante = idComprobanteDesencriptado;

            string template = TipoTexto.Substring(TipoTexto.Length - 1);
            string descripcion = facturacion.GetTemplateSmsbyTemplate(template);


            smsDTO.Template = descripcion;
            }
            catch (Exception ex)
            {
                Logger.Logueo("SMS Error en el proceso " + param + " " + ex.Message, Level.ErrorLog);
                smsDTO.IdComprobante = "0";

            }
            return this.Json(smsDTO);
        }
    }
}
