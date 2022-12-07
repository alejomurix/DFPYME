using System;
using System.Data;
using DTO.Clases;
using DataAccessLayer.Clases;

namespace BussinesLayer.Clases
{
    /// <summary>
    /// Representa una clase de logica de negocios de un Proveedor.
    /// </summary>
    public class BussinesProveedor
    {
        #region Atributos
        /// <summary>
        /// Representa un objeto de transeferecia a Base de Datos de Proveedor
        /// </summary>
        private DaoProveedor miDaoProveedor;

        /// <summary>
        /// Establece el tipo de Filtro que se debe de aplicar.
        /// </summary>
        public enum Filtro
        {
            /// <summary>
            /// Indica que la informacion debe ser completa
            /// </summary>
            Completo,

            /// <summary>
            /// Indica que la consulta se realiza con el codigo completo
            /// </summary>
            CodigoCompleto,

            /// <summary>
            /// Indica que la consulta se raliza con el nit completo
            /// </summary>
            NitCompleto,

            /// <summary>
            /// Indica que la consulta se raliza con el nombre Completo
            /// </summary>
            NombreCompleto,

            /// <summary>
            /// Indica que se aplica un filtro por codigo de Proveedor
            /// </summary>
            Codigo,

            /// <summary>
            /// Indica que se aplica un filtro por nit o cedula de Proveedor
            /// </summary>
            Nit,

            /// <summary>
            /// Indica que se aplica un filtro por nombre de proveedor
            /// </summary>
            Nombre
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Inicializa una nueva Instancia de la clase BussinesProveedor
        /// </summary>
        public BussinesProveedor() 
        {

            miDaoProveedor = new DaoProveedor();
        }

        #endregion

        #region Metodos

        /// <summary>
        /// Obtiene el número consecutivo del registro del Proveedor.
        /// </summary>
        /// <returns></returns>
        public int ObtenerCodigoConsecutivo()
        {
            return miDaoProveedor.CargarCodigoConsecutivo();
        }

        /// <summary>
        /// Verifica si existe el codigo del Proveedor en la base de datos.
        /// </summary>
        /// <param name="codigo">Codigo a verificar.</param>
        /// <returns></returns>
        public bool ExisteProveedorConCodigo(int codigo)
        {
            return miDaoProveedor.ExisteProveedorConCodigo(codigo);
        }

        /// <summary>
        /// Verifica si existe el Nit del Proveedor en la base de datos.
        /// </summary>
        /// <param name="nit">Nit a verificar.</param>
        /// <returns></returns>
        public bool ExisteProveedorConNit(string nit)
        {
            return miDaoProveedor.ExisteProveedorConNit(nit);
        }

        /// <summary>
        /// Inserta un Proveedor en la Base de Batos PostgreSQL
        /// </summary>
        /// <param name="proveedor">Proveedor a Insertar.</param>
        public void InsertarProveedor(Proveedor proveedor)
        {
            miDaoProveedor.InsertarProveedor(proveedor);
        }

        /// <summary>
        /// Ingresa un registro en la relacion de Proveedor con Producto.
        /// </summary>
        /// <param name="proveedor">Codigo del Proveedor a ingresar.</param>
        /// <param name="producto">Codigo del Producto a ingresar.</param>
        public void IngresarProductoDeProveedor(int proveedor, string producto)
        {
            miDaoProveedor.IngresarProductoDeProveedor(proveedor, producto);
        }

        /// <summary>
        /// Obtiene los datos basicos de un registro de Proveedor.
        /// </summary>
        /// <param name="codigo">Codigo del Proveedor a consultar.</param>
        /// <returns></returns>
        public Proveedor ConsultarPrveedorBasico(int codigo)
        {
            return miDaoProveedor.ConsultarPrveedorBasico(codigo);
        }

        /// <summary>
        /// Obtiene los datos basicos de un registro de Proveedor.
        /// </summary>
        /// <param name="nit">NIT del Proveedor a consultar.</param>
        /// <returns></returns>
        public Proveedor ConsultarPrveedorBasico(string nit)
        {
            return miDaoProveedor.ConsultarPrveedorBasico(nit);
        }

        /// <summary>
        /// Obtiene un DataSet semiTipado con las tablas proveedro, cuenta , contacto_proveedor
        /// </summary>
        /// <returns></returns>
        public DataSet ObtenerDataSetType()
        {
            return miDaoProveedor.ObtenerDataSetType();
        }

        public DataTable Proveedores()
        {
            return miDaoProveedor.Proveedores();
        }

        public DataTable Proveedores(int codigo)
        {
            return miDaoProveedor.Proveedores(codigo);
        }

        public DataTable Proveedores(string nit)
        {
            return miDaoProveedor.Proveedores(nit);
        }

       /* public Proveedor ProveedorAEditar(string nit)
        {
            return miDaoProveedor.ProveedorAEditar(nit);
        }*/

        /// <summary>
        /// Cargar la informacion de los Proveedores, contactos y cuentas bancarias en un DataSet
        /// </summary>
        /// <param name="filtro">Tipo de Filtro a aplicar.</param>
        /// <param name="codigo">Codigo a buscar.</param>
        /// <param name="nitOnombre">Nit o Nombre a Buscar.</param>
        /// <returns></returns>
        public DataSet CargarInformacionProveedor(BussinesProveedor.Filtro filtro , int codigo, string nitOnombre) 
        {
            DataSet ds = null;
            
            switch (filtro)
            {
                case Filtro.Completo:
                    {
                        ds = miDaoProveedor.ObtenerDataSetType();
                        break;
                    }
                case Filtro.CodigoCompleto:
                    {
                        ds = miDaoProveedor.ConsultaProveedorCodigo(codigo);
                        break;
                    }
                case Filtro.NitCompleto:
                    {
                        ds = miDaoProveedor.ConsultaProveedorNit(nitOnombre);
                        break;
                    }
                case Filtro.NombreCompleto:
                    {
                        ds = miDaoProveedor.ConsultaProveedorNombre(nitOnombre);
                        break;
                    }
                case Filtro.Codigo:
                    {
                        ds = miDaoProveedor.FiltroProveedorCodigo(codigo);
                        break;
                    }
                case Filtro.Nit:
                    {
                        ds = miDaoProveedor.FiltroProveedorNit(nitOnombre);
                        break;
                    }
                case Filtro.Nombre:
                    {
                        ds = miDaoProveedor.FiltroProveedorNombre(nitOnombre);
                        break;
                    }
            }
            return ds;
        }

        /// <summary>
        /// Obtiene el registro completo de un Proveedor con sus cuentas y contactos.
        /// </summary>
        /// <param name="codigo">Codigo del proveedor a seleccionar</param>
        /// <returns></returns>
        public Proveedor ProveedorAEditar(int codigo)
        {
            return miDaoProveedor.ProveedorAEditar(codigo);
        }

        /// <summary>
        /// Edita los datos de un Proveedor
        /// </summary>
        /// <param name="proveedor">Proveedor a editar</param>
        public void EditarProveedor(Proveedor proveedor)
        {
            miDaoProveedor.EditarProveedor(proveedor);
        }

        /// <summary>
        /// Elimina el registro del Proveedor en la base de datos.
        /// </summary>
        /// <param name="codigo">Codigo del Proveedor a Eliminar</param>
        public void EliminarProveedor(int codigo)
        {
            miDaoProveedor.EliminarProveedor(codigo);
        }

        public void ActualizarBeneficiario()
        {
            miDaoProveedor.ActualizarBeneficiario();
        }

        #endregion
    }
}