using System.Collections.Generic;
namespace DTO.Clases
{
    public class Usuario : TipoUsuario
    {
        /// <summary>
        /// Obtiene o establece el Id del Usuario.
        /// </summary>
        public int Id { set; get; }

        /// <summary>
        /// Obtiene o establece el número de identificacion del Usuario.
        /// </summary>
        public int Identificacion { set; get; }

        /// <summary>
        /// Obtiene o establece los nombres del Usuario.
        /// </summary>
        public string Nombres { set; get; }

        /// <summary>
        /// Obtiene o establece el número telefonico del Usuario.
        /// </summary>
        public string Telefono { set; get; }     

        /// <summary>
        /// Obtiene o establece el nombre de usuario del Usuario.
        /// </summary>
        public string Usuario_ { set; get; }

        /// <summary>
        /// Obtiene o establece la contraseña del Usuario.
        /// </summary>
        public string Contrasenia { set; get; }

        /// <summary>
        /// Obtiene o establece el estado del Usuario.
        /// </summary>
        public bool Estado { set; get; }

        /// <summary>
        /// Obtiene o establece la dirección de usuario
        /// </summary>
        public string Direccion { set; get; }

        public TipoUsuario Cargo { set; get; }

        /// <summary>
        /// Obtiene o establece el listado de permisos que puede adquirir un usuario.
        /// </summary>
        public List<Permiso> Permisos { set; get; }

        public Permiso Permiso { set; get; }

        /// <summary>
        /// Inicializa una nueva instancia de la clase Usuario.
        /// </summary>
        public Usuario()
        {
            this.Id = 0;
            this.Identificacion = 0;
            this.Nombres = "";
            this.Telefono = "";
            this.Usuario_ = "";
            this.Contrasenia = "";
            this.Direccion = "";
            this.Estado = true;
            this.Cargo = new TipoUsuario();
            this.Permisos = new List<Permiso>();
            this.Permiso = new Permiso();
        }
    }
}