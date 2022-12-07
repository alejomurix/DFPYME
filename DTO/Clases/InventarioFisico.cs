using System;

namespace DTO.Clases
{
    /// <summary>
    /// Representa una clase para el manejo del Inventario fisico ingresado.
    /// </summary>
    public class InventarioFisico : Inventario
    {
        /// <summary>
        /// Obtiene o establece la fecha del inventario
        /// </summary>
        public DateTime Fecha { set; get; }

        /// <summary>
        /// Obtiene o establece el valor de la cantidad en inventario fisico.
        /// </summary>
        public double CantidadFisico { set; get; }

        /// <summary>
        /// Obtiene o establece el valor que indica si ya se cruzo el registro en inventario.
        /// </summary>
        public bool Corte { set; get; }

        public int NumeroCorte { set; get; }
        
        /// <summary>
        /// Inicializa una nueva instancia de la clase InventarioFisico.
        /// </summary>
        public InventarioFisico()
        {
            this.Fecha = DateTime.Today;
            this.Cantidad = 0;
            this.Corte = false;
            this.NumeroCorte = 0;
        }
    }
}