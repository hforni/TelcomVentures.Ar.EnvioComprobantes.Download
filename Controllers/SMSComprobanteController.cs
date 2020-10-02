using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace TelcomVentures.Ar.EnvioComprobantes.Download.Controllers
{
    public class SMSComprobanteController : ApiController
    {

        public IHttpActionResult Get(string param)
        {
            string urlDescarga = string.Empty;
            Configuracion.ConfigManager oConf = new Configuracion.ConfigManager();
            WsGeneracionComprobantes.WSGeneracionComprobantes wsg = new WsGeneracionComprobantes.WSGeneracionComprobantes();
            string nombreArchivo = wsg.SGenerarComprobanteruta(param, oConf.GetValue("RutaComprobantes").ToString());
            if (nombreArchivo == "No se encontraron Datos")
            {             
                urlDescarga = "err2";
            }
            else
            {                
                urlDescarga = oConf.GetValue("UrlComprobantes").ToString() + nombreArchivo;
            }
            return this.Json(urlDescarga);
        }
           
                  
                
         

       
    }
}
