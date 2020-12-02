using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using TelcomVentures.Ar.EnvioComprobantes.Download.DTOs;
using TelcomVentures.Ar.EnvioComprobantes.Download.RESTClient;
using TelcomVentures.AR.Logueo;

namespace TelcomVentures.Ar.EnvioComprobantes.Download.Controllers
{
    public class ChatBotController : ApiController
    {
        public IHttpActionResult Get(string param)
        {
            TelnetData.Crypto tn = new TelnetData.Crypto();

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