using System;

namespace DTO.Clases
{
    /// <summary>
    /// Representa una clase para Categoria
    /// </summary>
    public class Categoria
    {
        /// <summary>
        /// Inicializa una nueva instancia de la clase Categoria.
        /// </summary>
        public Categoria()
        {
            this.CodigoCategoria = "";
            this.CodigoNuevo = "";
            this.NombreCategoria = "";
            this.DescripcionCategoria = "";
            this.EstadoCategoria = true;
            this.Valor = 0;
        }

        /// <summary>
        /// Obtiene o establece el codigo nuevo de la categoria.
        /// </summary>
        public string CodigoNuevo { get; set; }

        /// <summary>
        /// Obtiene o establece el codigo de la categoria.
        /// </summary>
        public string CodigoCategoria { get; set; }

        /// <summary>
        /// Obtiene o establece el nombre de la categoria.
        /// </summary>
        public string NombreCategoria { get; set; }

        /// <summary>
        /// Obtiene o establece la descripcion de la categoria.
        /// </summary>
        public string DescripcionCategoria { get; set; }

        /// <summary>
        /// Obtiene o establece el estado de la categoria.
        /// </summary>
        public bool EstadoCategoria { get; set; }

        public double Valor { set; get; }

        /// <summary>
        /// Representa el texto : Activo
        /// </summary>
        private string activo = "Activo";

        /// <summary>
        /// Representa el texto Inactivo
        /// </summary>
        private string inactivo = "Inactivo";

        

        /// <summary>
        /// Obtienen el texto correspondiente al estado.
        /// </summary>
        public string TextoEstado
        {
            get
            {
                if (this.EstadoCategoria)
                    return activo;
                else
                    return inactivo;
            }
        }        
    }
}