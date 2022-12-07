using System;

namespace DTO.Clases
{
    /// <summary>
    /// Representa una clase para el manejo de Valores de Unidades de Medida
    /// </summary>
    public class ValorUnidadMedida : UnidadMedida
    {
        /// <summary>
        /// Inicializa una nueva instancia de la clase ValorUnidadMedida
        /// </summary>
        public ValorUnidadMedida()
        {
            //this.IdUnidadMedida = 0;
            this.IdValorUnidadMedida = 0;
            this.DescripcionValorUnidadMedida = "";
        }

        /// <summary>
        /// Obtiene o Establece el valor para el Id de ValorUnidadMedida
        /// </summary>
        public int IdValorUnidadMedida { get; set; }

        /// <summary>
        /// Obtiene o Establece el valor para el Id de UnidadMedida
        /// </summary>
        //public int IdUnidadMedida { get; set; }

        /// <summary>
        /// Obtiene o Establece el valor para la Descripcion de ValorUnidadMedida
        /// </summary>
        public string DescripcionValorUnidadMedida { get; set; }

        /// <summary>
        /// Obtiene o establece el Codigo del Producto.
        /// </summary>
        public string CodigoInternoProducto { set; get; }
    }
}