using System;
using System.Collections.Generic;

namespace DTO.Clases
{
    public class PagoAnticipo
    {
        public int IdAnticipo { set; get; }

        public int IdConcepto { set; get; }

        public int Tipo { set; get; }

        public string NoDocumento { set; get; }

        public string Concepto { set; get; }

        public int Valor { set; get; }

        public DateTime Fecha { set; get; }

        public List<FormaPago> Pagos { set; get; }

        public PagoAnticipo()
        {
            this.IdAnticipo = 0;
            this.IdConcepto = 0;
            this.Tipo = 0;
            this.NoDocumento = "";
            this.Concepto = "";
            this.Valor = 0;
            this.Fecha = DateTime.Now;
            this.Pagos = new List<FormaPago>();
        }
    }
}