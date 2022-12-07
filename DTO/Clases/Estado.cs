namespace DTO.Clases
{
    /// <summary>
    /// Representa una clase para la estructura de datos de atributos de Estado.
    /// </summary>
    public class Estado
    {
        /// <summary>
        /// Obtiene o etablece el valor del Id del Estado.
        /// </summary>
        public int Id { get; set; }

        public int IdEdit { set; get; }

        /// <summary>
        /// Obtiene o establece la descripción del Estado.
        /// </summary>
        public string Descripcion { get; set; }

        /// <summary>
        /// Inicializa una nueva instancia de la clase Estado.
        /// </summary>
        public Estado()
        {
            this.Id = 0;
            this.IdEdit = 0;
            this.Descripcion = "";
        }
    }
}