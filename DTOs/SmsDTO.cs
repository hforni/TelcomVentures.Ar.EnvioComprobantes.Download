using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TelcomVentures.Ar.EnvioComprobantes.Download.DTOs
{
    public class SmsDTO
    {
        public string IdComprobante { get; set; }
        public string Template { get; set; }
    }
}