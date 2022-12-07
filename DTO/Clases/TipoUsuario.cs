using System.Collections.Generic;

namespace DTO.Clases
{
    /// <summary>
    /// Representa una clase para los datos de los Tipo de Usuario.
    /// </summary>
    public class TipoUsuario
    {
        /// <summary>
        /// Obtiene o establece el Id del Tipo de Usuario.
        /// </summary>
        public int IdTipo { set; get; }

        /// <summary>
        /// Obtiene o establece la Descripcion del Tipo de Usuario.
        /// </summary>
        public string Descripcion { set; get; }
    }
}