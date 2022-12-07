using System;
using System.Collections.Generic;
namespace DTO.Clases
{
    public class Ingreso
    {
        public int Id { set; get; }

        public int IdCaja { set; get; }

        public int IdUsuario { set; get; }

        public string NitCliente { set; get; }

        public string Numero { set; get; }

        public string Concepto { set; get; }

        public int Tipo { set; get; }

        public int Relacion { set; get; }

        public DateTime Fecha { set; get; }

        public int Valor { set; get; }

        public bool Estado { set; get; }

        public int Saldo { set; get; }

        public List<FormaPago> FormasPago { set; get; }

        public Ingreso()
        {
            this.Id = 0;
            this.IdCaja = 0;
            this.IdUsuario = 0;
            this.NitCliente = "";
            this.Numero = "";
            this.Concepto = "";
            this.Tipo = 1;
            this.Relacion = 0;
            this.Fecha = new DateTime();
            this.Valor = 0;
            this.Estado = true;
            this.Saldo = 0;
            this.FormasPago = new List<FormaPago>();
        }
    }

    public class OtroIngreso : Ingreso
    {
        public System.Collections.Generic.List<ConceptoOtroIngreso> Conceptos { set; get; }

        public OtroIngreso()
            : base()
        {
            this.Conceptos = new System.Collections.Generic.List<ConceptoOtroIngreso>();
        }
    }

    public class ConceptoOtroIngreso
    {
        public int Id { set; get; }

        public int IdIngreso { set; get; }

        public int Codigo { set; get; }

        public string Nombre { set; get; }

        public double Valor { set; get; }

        public ConceptoOtroIngreso()
        {
            this.Id = 0;
            this.IdIngreso = 0;
            this.Codigo = 0;
            this.Nombre = "";
            this.Valor = 0;
        }
    }
}