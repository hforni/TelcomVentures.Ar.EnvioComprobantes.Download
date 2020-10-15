using Configuracion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TelcomVentures.Ar.EnvioComprobantes.Download.DTOs;
using TelcomVentures.Ar.EnvioComprobantes.Download.RESTClient;
using TelcomVentures.AR.Logueo;

namespace TelcomVentures.Ar.EnvioComprobantes.Download.descarga
{
    public class EnviosController : ApiController
    {


        public IHttpActionResult Get(string idmail, string inn, string emm)
        {
            string cate = string.Empty;
            string numfac = string.Empty;
            string abonado = string.Empty;
            string urlDescarga = string.Empty;
            Configuracion.ConfigManager oConf = new Configuracion.ConfigManager();
            EnviosDTO _envios = new EnviosDTO();
            string url = "/api/envios/GetbyMailid?mailid=" + idmail;
            var ws = new RestClient("ComprobantesApi");
            var token = oConf.GetValue("ComprobanteApiToken");
            try
            {
                var ret = ws.ConsumeAsync<IEnumerable<EnviosDTO>>($"/api/envios/GetbyMailid?mailid=" + idmail, token).Result;
                if (ret != null)
                {
                    if (ret.Count() > 0)
                    {

                        foreach (EnviosDTO envios in ret)
                        {
                            numfac = envios.Numfac;
                            abonado = envios.NroAbonado;
                            cate = envios.TipoCate;
                        }
                        WsGeneracionComprobantes.WSGeneracionComprobantes wsg = new WsGeneracionComprobantes.WSGeneracionComprobantes();
                        string nombreArchivo = wsg.SGenerarComprobanteruta(numfac, oConf.GetValue("RutaComprobantes").ToString());
                        if (nombreArchivo == "No se encontraron Datos")
                        {
                            Logger.Logueo("No se pudo generar el comprobante idmail: " + idmail + " comprobante: " + numfac + " abonado: " + abonado + " cate: " + cate, Level.ErrorLog);
                            urlDescarga = "err2";
                        }
                        else
                        {
                            Logger.Logueo("Comprobante generado idmail: " + idmail + " comprobante: " + numfac + " abonado: " + abonado + " cate: " + cate, Level.InformacionLog);
                            urlDescarga = oConf.GetValue("UrlComprobantes").ToString() + nombreArchivo;
                            foreach (EnviosDTO envio in ret)
                            {
                                envio.LastEditedDate = System.DateTime.Now; ;
                                envio.LastEditedUser = "descarga";
                                envio.cant_descargas = envio.cant_descargas + 1;
                                this.UpdateEnvio(envio);
                            }
                        }
                    }
                    else
                    {
                        Logger.Logueo("No se econtro el envio " + idmail, Level.ErrorLog);
                        urlDescarga = "err1";
                    }
                }
                else
                {
                    Logger.Logueo("No se econtrol el envio " + idmail, Level.ErrorLog);
                }
                return this.Json(urlDescarga);
            }
            catch (Exception ex)
            {
                Logger.Logueo("Error en el proceso " + idmail + " " + ex.Message, Level.ErrorLog);
                urlDescarga = "err3";
                return this.Json(urlDescarga);
            }
        }

        private void UpdateEnvio(EnviosDTO envio)
        {
            Configuracion.ConfigManager oConf = new Configuracion.ConfigManager();
            string url = "/api/envios/" + envio.Id.ToString();
            var ws = new RestClient("ComprobantesApi");
            var token = oConf.GetValue("ComprobanteApiToken");
            var jsonString = Newtonsoft.Json.JsonConvert.SerializeObject(envio);
            var ret = ws.ConsumeAsync<List<EnviosDTO>>(url, HttpMethod.Put, jsonString, token).Result;
        }

    }
}
