using System;

namespace DTO.Clases
{
    /// <summary>
    /// Representa una clase para los datos de Lote.
    /// </summary>
    public class Lote
    {
        /// <summary>
        /// Obtiene o establece el Id unico del Lote.
        /// </summary>
        public int Id { set; get; }

        /// <summary>
        /// Obtiene o establece el Id de la zona de ubicacion del lote.
        /// </summary>
        public int IdZona { set; get; }

        /// <summary>
        /// Obtiene o establece el codigo del producto al cual pertenece el lote.
        /// </summary>
        public string CodigoProducto { set; get; }

        /// <summary>
        /// Obtiene o establece el número asignado al lote.
        /// </summary>
        public string Numero { set; get; }

        /// <summary>
        /// Obtiene o establece la fecha del Lote.
        /// </summary>
        public DateTime Fecha { set; get; }

        /// <summary>
        /// Inicializa una nueva instancia de la clase Lote.
        /// </summary>
        public Lote()
        {
            this.Id = 0;
            this.IdZona = 0;
            this.CodigoProducto = "";
            this.Numero = "";
            this.Fecha = DateTime.Today;
        }
    }
}