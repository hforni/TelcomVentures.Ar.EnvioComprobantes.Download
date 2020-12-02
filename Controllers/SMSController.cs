using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using TelcomVentures.Ar.EnvioComprobantes.Download.DTOs;
using TelcomVentures.Ar.EnvioComprobantes.Download.RESTClient;
using TelcomVentures.AR.Logueo;

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
            string tipoTexto = idComprobanteDesencriptado.Substring(idComprobanteDesencriptado.LastIndexOf("TEXTO"));
            idComprobanteDesencriptado = idComprobanteDesencriptado.Substring(0, idComprobanteDesencriptado.IndexOf("TEXTO"));
            smsDTO.IdComprobante = idComprobanteDesencriptado;

            string template = tipoTexto.Substring(tipoTexto.Length - 1);
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

        public IHttpActionResult Post(string idComprobante)
        {
            string abonado = string.Empty;
            string mail = string.Empty;
            string nombre = string.Empty;
            string mensaje = string.Empty;
            try
            {
                Configuracion.ConfigManager oConf = new Configuracion.ConfigManager();
                EnviosDTO _envios = new EnviosDTO();
                string url = "/api/envios/GetbyNumfac?numfac=" + idComprobante;
                var ws = new RestClient("ComprobantesApi");
                var token = oConf.GetValue("ComprobanteApiToken");
                var ret = ws.ConsumeAsync<IEnumerable<EnviosDTO>>(url, token).Result;
                if (ret != null)
                {
                    if (ret.Count() > 0)
                    {
                        foreach (EnviosDTO envios in ret)
                        {
                            mail = envios.Mail;
                            abonado = envios.NroAbonado;
                            nombre = envios.NroAbonado;
                        }
                        mensaje = "<br>El cliente solicita adherirse a factura electronica por SMS.<br><br>abonado: " + abonado + "<br>nombre: " + nombre + "<br>mail: " + mail;
                        string mailDestino = oConf.GetValue("DestinatarioSolicitudFacturaElectronicaSMS");
                        SendMail("solicitud de adhesion a factura electronica", mailDestino, "web Antina", mensaje);
                    }
                }
                return this.Json("OK");
            }
            catch (Exception ex)
            {
                Logger.Logueo("Error en adhesion factura electronica " + idComprobante + " " + ex.Message, Level.ErrorLog);
                return this.Json("Error");
            }
            
        }
    
        private static bool SendMail(string sSubject, string sDestinationEmail, string sDestinationName, string mensaje)
        {
            try
            {
                Configuracion.ConfigManager oConf = new Configuracion.ConfigManager();
                string host = oConf.GetValue("smtp");
                string smtp = oConf.GetValue("smtpusername");
                string password = oConf.GetValue("smtppassword");
                string senderEmail = oConf.GetValue("mailRemitenteVerFactura");
                int smtpTimeout = int.Parse(oConf.GetValue("SmtpTimeout"));

                System.Net.NetworkCredential credentials = new System.Net.NetworkCredential();
                credentials.UserName = smtp;
                credentials.Password = password;
                System.Net.Mail.MailAddress destination = new System.Net.Mail.MailAddress(sDestinationEmail, sDestinationName);
                System.Net.Mail.MailAddress sender = new System.Net.Mail.MailAddress(senderEmail, "Atención al cliente");
                System.Net.Mail.MailMessage message = new System.Net.Mail.MailMessage();

                message.Subject = sSubject;
                message.IsBodyHtml = true;
                message.From = sender;
                message.Body = mensaje;

                message.IsBodyHtml = true;
                message.To.Add(destination);
                System.Net.Mail.SmtpClient client = new System.Net.Mail.SmtpClient();
                client.Host = host;
                client.EnableSsl = false;
                client.Timeout = (int)smtpTimeout;
                client.Credentials = credentials;
                client.Send(message);

                return true;
            }
            catch (Exception ex)
            {
                Logger.Logueo("Error en mail comprobante " + ex.Message, Level.ErrorLog);
                return false;
            }
        }

    }
}
