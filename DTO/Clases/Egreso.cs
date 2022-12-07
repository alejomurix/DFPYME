using System;

namespace DTO.Clases
{
    /// <summary>
    /// Representa una clase para los datos de los Egresos.
    /// </summary>
    public class Egreso
    {
        /*public int Id { set; get; }

        /// <summary>
        /// Obtiene o establece el Id de la BaseCaja de este día.
        /// </summary>
        public int IdBaseCaja { set; get; }

        /// <summary>
        /// Obtiene o establece el Id de la Forma de Pago del Egreso.
        /// </summary>
        public int IdPago { set; get; }

        /// <summary>
        /// Obtiene o establece el Número del Egreso.
        /// </summary>
        public string Numero { set; get; }

        /// <summary>
        /// Obtiene o establece la hora en que se realizó el Egreso.
        /// </summary>
        public DateTime Hora { set; get; }

        /// <summary>
        /// Obtiene o establece el Concepto por el cual se genera el Egreso.
        /// </summary>
        public string Concepto { set; get; }

        /// <summary>
        /// Obtiene o establece el Valor del Egreso.
        /// </summary>
        public int Valor { set; get; }

        /// <summary>
        /// Indica si el Egreso se realizo por Caja Registradora o no.
        /// </summary>
        public bool Registradora { set; get; }*/

        public int Id { set; get; }

        public int IdCaja { set; get; }

        public int IdUsuario { set; get; }

        public string Numero { set; get; }

        public DateTime Fecha { set; get; }

        public int Total { set; get; }

        public int TipoBeneficiario { set; get; }

        public string Beneficiario { set; get; }

        public bool Estado { set; get; }

        public System.Collections.Generic.List<FormaPago> Pagos { set; get; }

        public System.Collections.Generic.List<ConceptoEgreso> Cuentas { set; get; }

        /// <summary>
        /// Inicializa una nueva instancia de la clase Egreso.
        /// </summary>
        public Egreso()
        {
            this.Id = 0;
            this.IdCaja = 0;
            this.IdUsuario = 0;
            this.Numero = "";
            this.Fecha = DateTime.Now;
            this.Total = 0;
            this.TipoBeneficiario = 0;
            this.Beneficiario = "";
            this.Estado = true;
            this.Pagos = new System.Collections.Generic.List<FormaPago>();
            this.Cuentas = new System.Collections.Generic.List<ConceptoEgreso>();
            /*this.IdBaseCaja = 0;
            this.IdPago = 0;
            this.Numero = "";
            this.Hora = new DateTime();
            this.Concepto = "";
            this.Valor = 0;
            this.Registradora = true;*/
        }
    }

    /*public class SubCuentaPuc
    {
        public int Id { set; get; }

        public int IdEgreso { set; get; }

        public int Codigo { set; get; }

        public int Cuenta { set; get; }

        public string Descripcion { set; get; }

        public int Valor { set; get; }

        public SubCuentaPuc()
        {
            this.Codigo = 0;
            this.IdEgreso = 0;
            this.Descripcion = "";
            this.Valor = 0;
        }
    }*/
}