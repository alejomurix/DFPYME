namespace DTO.Clases
{
    /// <summary>
    /// Representa una clase para los datos de Permisos en usuario.
    /// </summary>
    public class Permiso
    {
        /// <summary>
        /// Obtiene o establece el Id del Permiso.
        /// </summary>
        public int IdPermiso { set; get; }

        /// <summary>
        /// Obtiene o establece la Descripcion del Permiso.
        /// </summary>
        public string Descripcion { set; get; }

        public Permiso()
        {
            this.IdPermiso = 0;
            this.Descripcion = "";
        }
    }
}