using System;

namespace DTO.Clases
{
    public class Kardex
    {
        public int Id { set; get; }

        public int IdCompra { set; get; }

        public string Codigo { set; get; }

        public int IdUsuario { set; get; }

        public int IdConcepto { set; get; }

        public string NoDocumento { set; get; }

        public DateTime Fecha { set; get; }

        public double Cantidad { set; get; }

        public double Valor { set; get; }

        public double Total { set; get; }

        public Kardex()
        {
            this.Id = 0;
            this.IdCompra = 0;
            this.Codigo = "";
            this.IdUsuario = 0;
            this.IdConcepto = 0;
            this.NoDocumento = "";
            this.Fecha = DateTime.Now;
            this.Cantidad = 0.0;
            this.Valor = 0.0;
        }
    }
}