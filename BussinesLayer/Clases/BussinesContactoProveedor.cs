using System;
using System.Data;
using DTO.Clases;
using DataAccessLayer.Clases;

namespace BussinesLayer.Clases
{
    /// <summary>
    /// Representa una clase de logica de Negocio de un Contacto de Proveedor.
    /// </summary>
    public class BussinesContactoProveedor
    {
        /// <summary>
        /// Representa un objeto de tranzacion a base de datos.
        /// </summary>
        private DaoContactoProveedor miDaoContactoProveedor;

        /// <summary>
        /// Inicializa una nueva instancia de BussinesContactoProveedor
        /// </summary>
        public BussinesContactoProveedor() { }

        /// <summary>
        /// Verifica si un Contacto de un proveedor existe en la base de datos
        /// </summary>
        /// <param name="cedula">Cedula de contacto a verificar.</param>
        /// <returns></returns>
        public bool ExisteContacto(int cedula)
        {
            miDaoContactoProveedor = new DaoContactoProveedor();
            return miDaoContactoProveedor.ExisteContacto(cedula);
        }

        /// <summary>
        /// Ingresa un Contacto de Proveedor a la base de datos.
        /// </summary>
        /// <param name="contacto">Contacto a ingresar.</param>
        public void InsertarContacto(ContactoDeProveedor contacto)
        {
            miDaoContactoProveedor = new DaoContactoProveedor();
            miDaoContactoProveedor.InsertarContactoProveedor(contacto);
        }

        /// <summary>
        /// Obtiene el listado de los Contactos de un Proveedor en un DataTable.
        /// </summary>
        /// <returns></returns>
        /*public DataTable ListadoContactoProveedor()
        {
            miDaoContactoProveedor = new DaoContactoProveedor();
            return miDaoContactoProveedor.ListadoContactoProveedor();
        }*/
    }
}