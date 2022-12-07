using System;
using System.ComponentModel;
using System.Data;
using DTO.Clases;
using Npgsql;

namespace DataAccessLayer.Clases
{
    /// <summary>
    /// Representa una clase de tranzaciones a Base de Datos PostgreSQL.
    /// </summary>
    public class DaoContactoProveedor
    {
        #region Atributos

        /// <summary>
        /// Representa un objeto de conexion a PostgreSQL.
        /// </summary>
        private Conexion miConexion;

        /// <summary>
        /// Representa un objeto de sentecias o procedimientos almacenados SQL en PostgreSQL
        /// </summary>
        private NpgsqlCommand miComando;

        /// <summary>
        /// Representa un Adapter para sentencias sql
        /// </summary>
        private NpgsqlDataAdapter miAdapter;

        /// <summary>
        /// Representa la funcion existe_contacto_proveedor
        /// </summary>
        private const string sqlExisteContacto = "existe_contacto_proveedor";

        /// <summary>
        /// Representa la funcion insertar_contacto_proveedor
        /// </summary>
        private const string sqlInsertarContacto = "insertar_contacto_proveedor";

        /// <summary>
        /// Representa la funcion listado_contacto_proveedor, llama a una vista.
        /// </summary>
        private const string sqlListadoContacto = "listado_contacto_proveedor";

        /// <summary>
        /// Representa la funcion editar_contacto.
        /// </summary>
        private const string sqlEditarContacto = "editar_contacto";

        /// <summary>
        /// Representa la funcion listado_contacto_proveedor_codigo, recibe un codigo como parametro.
        /// </summary>
        private const string sqlListaContactoProveedor = "listado_contacto_proveedor_codigo";


        private const string errorVerificarContacto = "No se logro verificar el Contacto del Proveedor. ";

        private const string errorInsertarContacto = "No se logro Agregar el Contato del Proveedor. ";

        private const string errorListadoContacto = "No se logro obtener el listado de los Contacto del Proveedor";

        private const string errorEditarContacto = "No se logro editar el contacto: ";

        #endregion

        /// <summary>
        /// Inicializa una nueva instacia de DaoContactoProveedor.
        /// </summary>
        public DaoContactoProveedor() { }

        #region Metodos

        /// <summary>
        /// Verifica si un Contacto de un proveedor existe en la base de datos
        /// </summary>
        /// <param name="cedula">Cedula de contacto a verificar.</param>
        /// <returns></returns>
        public bool ExisteContacto(int cedula)
        {
            try
            {
                miConexion = new Conexion();
                CargarComandoStoredProcedure(sqlExisteContacto);
                miComando.Parameters.AddWithValue("cedula", cedula);
                miConexion.MiConexion.Open();
                var resultado = Convert.ToBoolean(miComando.ExecuteScalar());
                miConexion.MiConexion.Close();
                miComando.Dispose();
                return resultado;
            }
            catch (Exception ex)
            {
                throw new Exception(errorVerificarContacto + ex.Message);
            }
            finally
            {
                miConexion.MiConexion.Close();
            }
        }

        /// <summary>
        /// Ingresa un Contacto de Proveedor a la base de datos.
        /// </summary>
        /// <param name="contacto">Contacto a ingresar.</param>
        public void InsertarContactoProveedor(ContactoDeProveedor contacto)
        {
            try
            {
                miConexion = new Conexion();
                CargarComandoStoredProcedure(sqlInsertarContacto);
                miComando.Parameters.AddWithValue("codigoProveedor", contacto.CodigoInternoProveedor);
                miComando.Parameters.AddWithValue("cedula", contacto.CedulaContacto);
                miComando.Parameters.AddWithValue("nombre", contacto.NombreContacto);
                miComando.Parameters.AddWithValue("telefono", contacto.TelefonoContacto);
                miComando.Parameters.AddWithValue("celular", contacto.CelularContacto);
                miComando.Parameters.AddWithValue("email", contacto.EmailContacto);
                miComando.Parameters.AddWithValue("estado", contacto.EstadoContacto);
                miConexion.MiConexion.Open();
                miComando.ExecuteNonQuery();
                miConexion.MiConexion.Close();
                miComando.Dispose();
            }
            catch (Exception ex)
            {
                throw new Exception(errorInsertarContacto + ex.Message);
            }
            finally
            {
                miConexion.MiConexion.Close();
            }
        }

        /// <summary>
        /// Obtiene el listado de los Contactos de un Proveedor en un BindingSource
        /// </summary>
        /// <param name="codigo">Codigo del proveedor de los contactos.</param>
        /// <returns></returns>
        public BindingList<ContactoDeProveedor> ListaContactos(int codigo)
        {
            BindingList<ContactoDeProveedor> lista = new BindingList<ContactoDeProveedor>();
            try
            {
                miConexion = new Conexion();
                CargarComandoStoredProcedure(sqlListaContactoProveedor);
                miComando.Parameters.AddWithValue("codigo", codigo);
                miConexion.MiConexion.Open();
                NpgsqlDataReader miReader = miComando.ExecuteReader();
                while (miReader.Read())
                {
                    ContactoDeProveedor miContacto = new ContactoDeProveedor();
                    miContacto.IdContacto = miReader.GetInt32(0);
                    miContacto.CodigoInternoProveedor = miReader.GetInt32(1);
                    miContacto.CedulaContacto = miReader.GetInt32(2);
                    miContacto.NombreContacto = miReader.GetString(3);
                    miContacto.TelefonoContacto = miReader.GetString(4);
                    miContacto.CelularContacto = miReader.GetString(5);
                    miContacto.EmailContacto = miReader.GetString(6);
                    miContacto.TextoEstado = miReader.GetString(7);
                    lista.Add(miContacto);
                }
                miConexion.MiConexion.Close();
                miComando.Dispose();
                return lista;
            }
            catch (Exception ex)
            {
                throw new Exception(errorListadoContacto + ex.Message);
            }
            finally
            {
                miConexion.MiConexion.Close();
            }
        }

        /// <summary>
        /// Edita los datos de un Contacto de Proveedor
        /// </summary>
        /// <param name="contacto"></param>
        internal void EditarContacto(ContactoDeProveedor contacto)
        {
            try
            {
                miConexion = new Conexion();
                CargarComandoStoredProcedure(sqlEditarContacto);
                miComando.Parameters.AddWithValue("id", contacto.IdContacto);
                miComando.Parameters.AddWithValue("codigo", contacto.CodigoInternoProveedor);
                miComando.Parameters.AddWithValue("cedula", contacto.CedulaContacto);
                miComando.Parameters.AddWithValue("nombre", contacto.NombreContacto);
                miComando.Parameters.AddWithValue("telefono", contacto.TelefonoContacto);
                miComando.Parameters.AddWithValue("celular", contacto.CelularContacto);
                miComando.Parameters.AddWithValue("email", contacto.EmailContacto);
                miComando.Parameters.AddWithValue("estado", contacto.EstadoContacto);
                miConexion.MiConexion.Open();
                miComando.ExecuteNonQuery();
                miConexion.MiConexion.Close();
                miComando.Dispose();
            }
            catch (Exception ex)
            {
                throw new Exception(errorEditarContacto + contacto.NombreContacto + ".  " + ex.Message);
            }
        }

        /// <summary>
        /// Obtiene el listado de los Contactos de un Proveedor en un DataTable.
        /// </summary>
        /// <returns></returns>
        /*public DataTable ListadoContactoProveedor()
        {
            try
            {
                miConexion = new Conexion();
                miDataTable = new DataTable();
                CargarAdapterStoredProcedure(sqlListadoContacto);
                this.miAdapter.Fill(miDataTable);
                return miDataTable;
            }
            catch (Exception ex)
            {
                throw new Exception(errorListadoContacto + ex.Message);
            }
        }*/

        /// <summary>
        /// Inicializa una nueva instancia de NpgsqlCommand de tipo StoredProcedure.
        /// </summary>
        /// <param name="cmd">StoredProcedure a ejecutar.</param>
        private void CargarComandoStoredProcedure(string cmd)
        {
            miComando = new NpgsqlCommand();
            miComando.Connection = miConexion.MiConexion;
            miComando.CommandType = CommandType.StoredProcedure;
            miComando.CommandText = cmd;
        }

        /// <summary>
        /// Inicializa una nueva instacia del Adapter de tipo stored procedure
        /// </summary>
        /// <param name="cmd">Sentencia sql a ejecutar</param>
        private void CargarAdapterStoredProcedure(string cmd)
        {
            this.miAdapter = new NpgsqlDataAdapter(cmd, miConexion.MiConexion);
            this.miAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
        }

        #endregion

    }
}