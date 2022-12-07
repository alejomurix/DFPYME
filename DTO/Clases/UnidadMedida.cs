using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DTO.Clases
{
    /// <summary>
    /// Representa una clase para Unidades de Medida
    /// </summary>
    public class UnidadMedida
    {
        /// <summary>
        /// Inicializa una nueva instancia de unidad de medida.
        /// </summary>
        public UnidadMedida()
        {
            this.IdUnidadMedida = 0;
            this.DescripcionUnidadMedida = "";
        }

        /// <summary>
        /// Obtiene o estabelce el valor del Id de Unidad de Medida
        /// </summary>
        public int IdUnidadMedida { get; set; }

        /// <summary>
        /// Obtiene o estabelce el valor de la Descripcion de Unidad de Medida
        /// </summary>
        public string DescripcionUnidadMedida { get; set; }

        /// <summary>
        /// Obtinene o establece la coleccion de registros de los valores de Unidad de Medida.
        /// </summary>
        public List<ValorUnidadMedida> ListaValoresUnidaMedida { set; get; }
    }
}
