using System;
using System.Collections.Generic;

namespace DTO.Clases
{
    /// <summary>
    /// Representa una clase para los datos de Factura de Proveedor.
    /// </summary>
    public class FacturaProveedor : ICloneable
    {
        public virtual object Clone() { return this.MemberwiseClone(); }

        /// <summary>
        /// Obtiene o establece el valor del Id unico de la factura.
        /// </summary>
        public int Id { set; get; }

        /// <summary>
        /// Obtiene o establece el Proveedor de la factura.
        /// </summary>
        public Proveedor Proveedor { set; get; }

        /// <summary>
        /// Obtiene o la forma de pago de la factura.
        /// </summary>
        public FormaPago FormaPago { set; get; }

        /// <summary>
        /// Obtiene o establece el valor de la Caja de la Factura.
        /// </summary>
        public Caja Caja { set; get; }

        public Turno Turno { set; get; }

        /// <summary>
        /// Obtiene o establece el valor del estado de la Factura.
        /// </summary>
        public Estado EstadoFactura { set; get; }

        /// <summary>
        /// Indica si es Factura, Remisión o Documento Equivalente.
        /// </summary>
        public int Tipo { set; get; }

        /// <summary>
        /// Obtiene o establece el Usuario que ingreso la factura.
        /// </summary>
        public Usuario Usuario { set; get; }

        public int Consecutivo { set; get; }

        /// <summary>
        /// Obtiene o establece el valor del número de la factura.
        /// </summary>
        public string Numero { set; get; }

        /// <summary>
        /// Obtiene o establece el valor del número editado de la factura.
        /// </summary>
        public string NumeroEdit { set; get; }

        public DateTime FechaFactura { set; get; }

        /// <summary>
        /// Obtiene o establece el valor de la fecha de ingreso de la factura.
        /// </summary>
        public DateTime FechaIngreso { set; get; }

        /// <summary>
        /// Obtiene o establece el valor de la fecha limipte de pago de la factura.
        /// </summary>
        public DateTime FechaLimite { set; get; }

        /// <summary>
        /// Obtiene o establece el valor del descuento de la Factura Proveedor.
        /// </summary>
        public double Descuento { set; get; }

        public List<Descuento> Descuentos { set; get; }

        /// <summary>
        /// Obtiene o establece el estado de la Factura
        /// </summary>
        public bool Estado { set; get; }

        public bool EsFactura { set; get; }

        public bool Facturada { set; get; }

        public double Ajuste { set; get; }

        /// <summary>
        /// Obtiene o establece el listdo de productos
        /// </summary>
        public List<ProductoFacturaProveedor> Productos { set; get; }

        public RetencionConcepto Retencion { set; get; }

        /// <summary>
        /// Inicializa una nueva instancia de la clase FacturaProveedor.
        /// </summary>
        public FacturaProveedor()
        {
            this.Id = 0;
            this.Proveedor = new Proveedor();
            this.FormaPago = new FormaPago();
            this.EstadoFactura = new Estado();
            this.Caja = new Caja();
            this.Turno = new Turno();
            this.Usuario = new Usuario();
            this.Consecutivo = 0;
            this.Numero = "";
            this.NumeroEdit = "";
            this.FechaFactura = DateTime.Today;
            this.FechaIngreso = DateTime.Today;
            this.FechaLimite = DateTime.Today;
            this.Descuento = 0.0;
            this.Estado = true;
            this.EsFactura = true;
            this.Ajuste = 0;
            this.Facturada = false;
            this.Productos = new List<ProductoFacturaProveedor>();
            Retencion = new RetencionConcepto();
            this.Descuentos = new List<Descuento>();

            //
            this.DevolucionEfectivo = 0;
            this.Pagos = 0;
            this.Saldo = 0;
            this.Valor = 0;
            this.ValorReal = 0;
            this.Nota = "";
        }

        //
        public int DevolucionEfectivo { set; get; }

        public int Pagos { set; get; }

        public int Saldo { set; get; }

        public int Valor { set; get; }

        public int ValorReal { set; get; }

        public string Nota { set; get; }

        public bool Cancel { set; get; }
    }
}