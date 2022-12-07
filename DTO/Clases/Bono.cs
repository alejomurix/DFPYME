using System;
using System.Collections.Generic;

namespace DTO.Clases
{
    public class Bono
    {
        public int Id { set; get; }

        public int IdDevolucion { set; get; }

        public int IdCaja { set; get; }

        public int IdUsuario { set; get; }

        public string Numero { set; get; }

        public int CodProveedor { set; get; }

        public string Cliente { set; get; }

        public string Factura { set; get; }

        public DateTime Fecha { set; get; }

        public string Concepto { set; get; }

        public int Valor { set; get; }

        public bool Canje { set; get; }

        public List<int> IdMarcas { set; get; }

        public Bono()
        {
            this.Id = 0;
            this.IdDevolucion = 0;
            this.IdCaja = 0;
            this.IdUsuario = 0;
            this.Numero = "";
            this.CodProveedor = 0;
            this.Cliente = "";
            this.Factura = "";
            this.Fecha = DateTime.Today;
            this.Concepto = "";
            this.Valor = 0;
            this.Canje = false;
            this.IdMarcas = new List<int>();
        }
    }
}