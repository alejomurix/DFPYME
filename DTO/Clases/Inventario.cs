using System;

namespace DTO.Clases
{
    /// <summary>
    /// Representa una clase para el manejo del Inventario.
    /// </summary>
    public class Inventario
    {
        /// <summary>
        /// Obtiene o establece el Id del Inventario.
        /// </summary>
        public int Id { set; get; }

        /// <summary>
        /// Obtiene o establece el Codigo del producto en Inventario.
        /// </summary>
        public string CodigoProducto { set; get; }

        /// <summary>
        /// Obtiene o establece el Id de la medida en Inventario.
        /// </summary>
        public int IdMedida { set; get; }

        /// <summary>
        /// Obtiene o establece el Id del color en Inventario.
        /// </summary>
        public int IdColor { set; get; }

        /// <summary>
        /// Obtiene o establece la Cantidad en el inventario.
        /// </summary>
        public double Cantidad { set; get; }

        public double Costo { set; get; }

        /// <summary>
        /// Inicializa una nueva instancia de la clase Inventario.
        /// </summary>
        public Inventario()
        {
            this.Id = 0;
            this.CodigoProducto = "";
            this.IdMedida = 0;
            this.IdColor = 0;
            this.Cantidad = 0.0;
            this.Costo = 0.0;
        }
    }

    public class Corte
    {
        public int Numero { set; get; }

        public DateTime Fecha { set; get; }

        public Corte()
        {
            this.Numero = 0;
            this.Fecha = DateTime.Now;
        }
    }
}