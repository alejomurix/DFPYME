using System;

namespace DTO.Clases
{
    /// <summary>
    /// Representa una clase para Marcas.
    /// </summary>
    public class Marca
    {
        /// <summary>
        /// Inicializa una nueva instancia de la clase Marca.
        /// </summary>
        public Marca()
        {
            this.IdMarca = 0;
            this.NombreMarca = "";
            this.Descuento = 0;
            this.Precio = 0;
            this.Valor = 0;
        }

        /// <summary>
        /// Obtiene o establece el Id de la Marca.
        /// </summary>
        public int IdMarca { get; set; }

        /// <summary>
        /// Obtiene o establece el Nombre de la Marca.
        /// </summary>
        public string NombreMarca { get; set; }

        public double Descuento { set; get; }

        public int Precio { set; get; }

        public int Valor { set; get; }
    }
}