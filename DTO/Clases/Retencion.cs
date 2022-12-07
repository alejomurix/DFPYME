using System;
using System.Collections.Generic;

namespace DTO.Clases
{
    public class Retencion
    {
        public int Id { set; get; }

        public string Rubro { set; get; }

        public List<RetencionConcepto> Conceptos { set; get; }

        public Retencion()
        {
            this.Id = 0;
            this.Rubro = "";
            this.Conceptos = new List<RetencionConcepto>();
        }
    }

    public class RetencionConcepto
    {
        public int Id { set; get; }

        public int IdFactura { set; get; }

        public Retencion Retencion { set; get; }

        public int IdCuentaPuc { set; get; }

        public string Concepto { set; get; }

        public double CifraUVT { set; get; }

        public double CifraPesos { set; get; }

        public double Tarifa { set; get; }

        public double Valor { set; get; }

        public RetencionConcepto()
        {
            this.Id = 0;
            this.IdFactura = 0;
            this.Retencion = new Retencion();
            this.IdCuentaPuc = 0;
            this.Concepto = "";
            this.CifraUVT = 0.0;
            this.CifraPesos = 0.0;
            this.Tarifa = 0.0;
            this.Valor = 0;
        }
    }
}