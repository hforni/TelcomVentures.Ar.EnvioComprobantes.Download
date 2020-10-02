using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TelcomVentures.Ar.EnvioComprobantes.Download.DTOs
{
    public class EnviosDTO
    {
        public string NroAbonado { get; set; }
        public string Nombre { get; set; }
        public string Mail { get; set; }
        public string Numfac { get; set; }
        public string Periodo { get; set; }
        public string MailId { get; set; }
        public DateTime FechaAlta { get; set; }
        public DateTime FechaEmision { get; set; }
        public DateTime FechaVencimiento { get; set; }
        public string TipoCate { get; set; }
        public string Estado { get; set; }
        public string Enviado { get; set; }
        public DateTime FechaEnvio { get; set; }
        public string LogEnvio { get; set; }
        public DateTime FechaBounce { get; set; }
        public string MensajeBounce { get; set; }
        public DateTime FechaEnvioReintento { get; set; }
        public string MailIdReintento { get; set; }
        public DateTime FechaBounceReintento { get; set; }
        public string MensajeBounceReintento { get; set; }
        public DateTime FechaCierre { get; set; }
        public string Reporte { get; set; }
        public string Contacto { get; set; }
        public string Reproceso { get; set; }
        public string Servicio { get; set; }
        public string Template { get; set; }
        public int cant_leidos { get; set; }
        public int cant_descargas { get; set; }
        public string GuidProceso { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreatedUser { get; set; }
        public DateTime LastEditedDate { get; set; }
        public string LastEditedUser { get; set; }
        public bool Enabled { get; set; }
        public int Id { get; set; }
    }
}