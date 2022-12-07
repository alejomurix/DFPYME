using System;

namespace DTO.Clases
{
    /// <summary>
    /// Representa una clase para los Recargos.
    /// </summary>
    public class Recargo
    {
        /// <summary>
        /// Inicializa una nueva instancia de la clase Recargo.
        /// </summary>
        public Recargo()
        {
            this.IdRecargo = 0;
            this.ValorRecargo = 0;
            this.CodigoInternoProducto = "";
        }

        /// <summary>
        /// Obtiene o Establece el Id del Recargo.
        /// </summary>
        public int IdRecargo { get; set; }

        /// <summary>
        /// Obtiene o Establece el Valor del Recargo.
        /// </summary>
        public double ValorRecargo { get; set; }

        /// <summary>
        /// Obtiene o Establece el Codigo interno del producto.
        /// </summary>
        public string CodigoInternoProducto { get; set; }
    }
}