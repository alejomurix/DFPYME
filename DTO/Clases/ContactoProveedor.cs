using System;

namespace DTO.Clases
{
    /// <summary>
    /// Representa una clase para Contactos de los Proveedores
    /// </summary>
    public class ContactoDeProveedor
    {
        /// <summary>
        /// Inicializa una nueva Instancia de ContactoDeProveedor
        /// </summary>
        public ContactoDeProveedor()
        {
            this.IdContacto = 0;
            this.CodigoInternoProveedor = 0;
            this.CedulaContacto = 0;
            this.NombreContacto = "";
            this.TelefonoContacto = "";
            this.CelularContacto = "";
            this.EmailContacto = "";
            this.EstadoContacto = true;
        }

        public int IdContacto { set; get; }
        public int CodigoInternoProveedor { set; get; }
        public int CedulaContacto { set; get; }
        public string NombreContacto { set; get; }
        public string TelefonoContacto { set; get; }
        public string CelularContacto { set; get; }
        public string EmailContacto { set; get; }
        /// <summary>
        /// Obtiene o Establece el estado del contacto de proveedor. Por defecto es true.
        /// </summary>
        public bool EstadoContacto { set; get; }

        public string TextoEstado { set; get; }
    }
}