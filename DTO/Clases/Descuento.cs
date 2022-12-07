using System;
using System.Linq;
using System.Text;

namespace DTO.Clases
{
    /// <summary>
    /// Representa una clase para Descuento.
    /// </summary>
    public class Descuento
    {
        /// <summary>
        /// Inicializa una nueva instancia de la clase Descuento.
        /// </summary>
        public Descuento()
        {
            this.IdDescuento = 0;
            this.ValorDescuento = 0;
            this.CodigoInternoProducto = "";
            this.IdFactura = 0;
        }

        /// <summary>
        /// Obtiene o Establece el valor del Id del Descuento.
        /// </summary>
        public int IdDescuento { get; set; }

        /// <summary>
        /// Obtiene o Establece el valor del Descuento.
        /// </summary>
        public double ValorDescuento { get; set; }

        /// <summary>
        /// Obtiene o Establece le valor del Codigo Interno del Producto.
        /// </summary>
        public string CodigoInternoProducto { get; set; }

        public int IdFactura { set; get; }
    }
}