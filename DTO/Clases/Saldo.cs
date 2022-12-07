using System;

namespace DTO.Clases
{
    public class Saldo
    {
        public int Id { set; get; }

        public string Numero { set; get; }

        public string NitCliente { set; get; }

        public int IdUsuario { set; get; }

        public int IdCaja { set; get; }

        public DateTime Fecha { set; get; }

        public int Valor { set; get; }

        public int VSaldo { set; get; }

        public bool Estado { set; get; }

        public Ingreso Ingreso { set; get; }

        public System.Collections.Generic.List<FormaPago> FormasPago { set; get; }

        public Saldo()
        {
            this.Id = 0;
            this.Numero = "";
            this.NitCliente = "";
            this.IdUsuario = 0;
            this.IdCaja = 0;
            this.Fecha = DateTime.Today;
            this.Valor = 0;
            this.VSaldo = 0;
            this.Estado = true;
            this.Ingreso = new Ingreso();
            this.FormasPago = new System.Collections.Generic.List<FormaPago>();
        }
    }
}