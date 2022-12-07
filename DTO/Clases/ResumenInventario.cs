using System;

namespace DTO.Clases
{
    /// <summary>
    /// Representa una clase para el manejo de los resultado de Inventario
    /// </summary>
    public class ResumenInventario : InventarioFisico
    {
        /// <summary>
        /// Obtiene o establece la cantidad diferida entre inventario.
        /// </summary>
        public double CantidadResumen { set; get; }

        /// <summary>
        /// Obtiene o establece el valor del producto en el inventario.
        /// </summary>
        public int ValorProducto { set; get; }

        /// <summary>
        /// Inicializa una nueva instancia de la clase ResumenInventario.
        /// </summary>
        public ResumenInventario()
        {
            this.CantidadResumen = 0.0;
        }
    }
}