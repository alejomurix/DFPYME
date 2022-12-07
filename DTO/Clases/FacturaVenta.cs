using System.Collections.Generic;

namespace DTO.Clases
{
    /// <summary>
    /// Representa una clase para la estructura de datos de Factura de Venta.
    /// </summary>
    public class FacturaVenta : FacturaProveedor
    {
        public ImpuestoBolsa IcoBolsaPlastica { set; get; }

        /// <summary>
        /// Obtiene o establece el valor del número de la factura de venta.
        /// </summary>
        //public string Numero { set; get; }

        /// <summary>
        /// Obtiene o establece el listado de las Formas de Pago de la Factura.
        /// </summary>
        public List<FormaPago> FormasDePago { set; get; }

        /// <summary>
        /// Obtiene o establece el valor de la Caja de la Factura.
        /// </summary>
        //public Caja Caja { set; get; }

        /// <summary>
        /// Obtiene o establece el valor del estado de la Factura.
        /// </summary>
        //public Estado EstadoFactura { set; get; }

        /// <summary>
        /// Indica si la Factura aplica descuento o de lo contrario aplicaría
        /// recargo.
        /// </summary>
        public bool AplicaDescuento { set; get; }

        /// <summary>
        /// Obtiene o establece el valor del recargo de la factura.
        /// </summary>
        public double Recargo { set; get; }

        public bool Remision_ { set; get; }

        public double Total { set; get; }

        public int Valor { set; get; }

        public bool Pendiente { set; get; }

        public int IdResolucionDian { set; get; }

        public string NameStation { set; get; }

        /// <summary>
        /// Inicializa una nueva instancia de la clase FacturaProveedor.
        /// </summary>
        public FacturaVenta() :base()
        {
            this.IcoBolsaPlastica = new ImpuestoBolsa();
            this.FormasDePago = new List<FormaPago>();
            this.Caja = new Caja();
            this.EstadoFactura = new Estado();
            this.AplicaDescuento = true;
            this.Recargo = 0.0;
            this.Remision_ = false;
            this.Valor = 0;
            this.Pendiente = false;
            this.IdResolucionDian = 0;
            this.NameStation = "";
        }
    }
}