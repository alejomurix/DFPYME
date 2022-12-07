using System;
using System.Collections.Generic;

namespace DTO.Clases
{
    public class CuentaPagar
    {
        public int Id { set; get; }

        public int IdCuenta { set; get; }

        public int IdTercero { set; get; }

        public Cliente Tercero { set; get; }

        public int IdTipo { set; get; }

        public int IdTipoEdit { set; get; }

        public string Documento { set; get; }

        public int IdCaja { set; get; }

        public int IdUsuario { set; get; }

        public string Numero { set; get; }

        public DateTime Fecha { set; get; }

        public DateTime FechaDocumento { set; get; }

        public DateTime FechaLimite { set; get; }

        public bool Activo { set; get; }

        public bool Pago { set; get; }

        public List<DetalleCuentaPagar> Detalles { set; get; }

        public List<RetencionConcepto> Retenciones { set; get; }

        public CuentaPagar()
        {
            this.Id = 0;
            this.IdCuenta = 0;
            this.Tercero = new Cliente();
            this.IdTercero = 0;
            this.IdTipo = 0;
            this.IdTipoEdit = 0;
            this.Documento = "";
            this.IdCaja = 0;
            this.IdUsuario = 0;
            this.Numero = "";
            this.Fecha = DateTime.Now;
            this.FechaDocumento = DateTime.Now;
            this.FechaLimite = DateTime.Now;
            this.Activo = true;
            this.Pago = false;
            this.Detalles = new List<DetalleCuentaPagar>();
            this.Retenciones = new List<RetencionConcepto>();
        }
    }

    public class DetalleCuentaPagar
    {
        public int Id { set; get; }

        public int IdCuentaPagar { set; get; }

        public string Concepto { set; get; }

        public double Cantidad { set; get; }

        public int Valor { set; get; }

        public DetalleCuentaPagar()
        {
            this.Id = 0;
            this.IdCuentaPagar = 0;
            this.Concepto = "";
            this.Cantidad = 0;
            this.Valor = 0;
        }
    }

    public class CruceCuentaPagar : FormaPago
    {
        public int IdCuentaPagar { set; get; }

        public string Numero { set; get; }

        public string Concepto { set; get; }

        public int Resta { set; get; }

        public CruceCuentaPagar()
            : base()
        {
            this.IdCuentaPagar = 0;
            this.Numero = "";
            this.Concepto = "";
            this.Resta = 0;
        }
    }
}