using System;
using System.ComponentModel;
using System.Data;
using DataAccessLayer.DataSets;
using DTO.Clases;
using Npgsql;

namespace DataAccessLayer.Clases
{
    /// <summary>
    /// Representa una clase de transferencia a Base de Datos PostgreSQL de un Proveedor
    /// </summary>
    public class DaoProveedor
    {
        #region Atributos de Tranzacion DB

        /// <summary>
        /// Atributo que representa la Conexion a PostgreSQL
        /// </summary>
        private Conexion miConexion;

        /// <summary>
        /// Representa una Sentencia o un Procedimiento Almacenado SQl para ejecutar en PostgreSQL
        /// </summary>
        private NpgsqlCommand miComando;

        private DataTable tableCuenta;

        private DataTable tableContacto;

        private DataTable tableProveedor;

        private DataSet miDataSet;

        /// <summary>
        /// Representa un DataAdapter de multiples comandos: select, insert, update, delete
        /// </summary>
        private NpgsqlDataAdapter miAdapter;

        /// <summary>
        /// Representa un objeto de tranzacion DaoCuenta a PostgreSQL.
        /// </summary>
        private DaoCuenta miDaoCuenta;

        /// <summary>
        /// Representa un objeto de Tranzacion de DaoContactoProveedor a PostgreSQL.
        /// </summary>
        private DaoContactoProveedor miDaoContacto;

        #endregion

        #region Atributos Stored Procedure

        /// <summary>
        /// Representa la función "recuperar_consecutivo".
        /// </summary>
        private const string sqlObtenerConsecutivo = "recuperar_consecutivo";

        /// <summary>
        /// Representa la funcion existe_codigo_proveedor
        /// </summary>
        private const string sqlComprobarCodigo = "existe_codigo_proveedor";

        /// <summary>
        /// Representa la Funcion "acualizar_consecutivo"
        /// </summary>
        private const string sqlActualizaConsecutivo = "actualizar_consecutivo";

        /// <summary>
        /// Representa la Funcion existe_proveedor_codigo.
        /// </summary>
        private const string sqlExisteConCodigo = "existe_proveedor_codigo";

        /// <summary>
        /// Representa la Funcion existe_proveedor_nit.
        /// </summary>
        private const string sqlExisteConNit = "existe_proveedor_nit";

        /// <summary>
        /// Representa la Funcion insertar_proveedor.
        /// </summary>
        private const string sqlInsertarProveedor = "insertar_proveedor";

        /// <summary>
        /// Representa la funcion consulta_proveedor_basico.
        /// </summary>
        private const string sqlConsultaProveedorBasico = "consulta_proveedor_basico";

        /// <summary>
        /// Representa la Funcino listado_proveedor
        /// </summary>
        private const string sqlListarProveedor = "listado_proveedor";

        /// <summary>
        /// Representa la funcion listado_contacto_proveedor, llama a una vista.
        /// </summary>
        private const string sqlListarContacto = "listado_contacto_proveedor";

        /// <summary>
        /// Representa el Procedimiento Almacenado listado_cuenta
        /// </summary>
        private const string sqlListarCuenta = "listado_cuenta";

        /// <summary>
        /// Representa la Funcioin filtro_proveedor_codigo, recibe el parametro CodigoInternoProveedor. 
        /// </summary>
        private const string sqlFiltroCodigo = "filtro_proveedor_codigo";

        /// <summary>
        /// Representa la Funcion filtro_proveedor_nit, recibe el parametro NitProveedor (Nit o Cedula).
        /// </summary>
        private const string sqlFiltroNit = "filtro_proveedor_nit";

        /// <summary>
        /// Representa la Funcion filtro_proveedor_nombre, recibe el paramentro NombreProveedor.
        /// </summary>
        private const string sqlFiltroNombre = "filtro_proveedor_nombre";

        /// <summary>
        /// Representa la funcion consulta_proveedor_codigo, recibe el codigo del proveedor completo.
        /// </summary>
        private const string sqlProveedorCodigo = "consulta_proveedor_codigo";

        /// <summary>
        /// Representa la funcion consulta_proveedor_nit, recibe el nit del proveedor completo
        /// </summary>
        private const string sqlProveedorNit = "consulta_proveedor_nit";

        /// <summary>
        /// Representa la funcion consulta_proveedor_nombre, recibe el nombre del proveedor completo, no distinge entre May y min
        /// </summary>
        private const string sqlProveedorNombre = "consulta_proveedor_nombre";

        /// <summary>
        /// Representa la funcion proveedor_a_editar, recibe el codigo como parametro.
        /// </summary>
        private const string sqlProveedorAEditar = "proveedor_a_editar";

        /// <summary>
        /// Representa la funcion editar_proveedor en PostgreSQL
        /// </summary>
        private const string sqlEditarProveedor = "editar_proveedor";

        /// <summary>
        /// Representa la funcion eliminar_proveedor
        /// </summary>
        private const string sqlEliminarProveedor = "eliminar_proveedor";

        /// <summary>
        /// Representa la funcion insertar_proveedor_producto.
        /// </summary>
        private const string sqlInsertarProductoProveedor = "insertar_proveedor_producto";

        /// <summary>
        /// Representa la funcion comprobar_producto_proveedor.
        /// </summary>
        private const string sqlComprobarProductoProveedor = "comprobar_producto_proveedor";

        #endregion

        #region Atributos constantes

        /// <summary>
        /// Representa la palabra : Proveedor
        /// </summary>
        private const string proveedor = "Proveedor";

        /// <summary>
        /// Representa la palabra : No se logro generar el codigo. 
        /// </summary>
        private const string ErrorConsecutivo = "No se logro generar el codigo.\n";

        /// <summary>
        /// Representa la palabra : No se logro comprobar el Codigo.  
        /// </summary>
        private const string errorExisteCodigo = "No se logro comprobar el Codigo.\n ";

        /// <summary>
        /// Representa la palabra : No se logro comprobar el Nit
        /// </summary>
        private const string errorExisteNit = "No se logro comprobar el Nit.\n ";

        /// <summary>
        /// Representa la palabra : No se logro Actualizar el consecutivo del Proveedor.
        /// </summary>
        private const string erroUpdateConsecutivo = "No se logro Actualizar el consecutivo del Proveedor.\n ";

        /// <summary>
        /// Representa la palabra : No se logro agregar el Proveedor. 
        /// </summary>
        private const string errorInsertarProveedor = "No se logro agregar el Proveedor.\n ";

        /// <summary>
        /// Representa el mensaje Error al cargar la informacion de los Proveedores. 
        /// </summary>
        private const string errorInformacionProveedor = "Error al cargar la informacion de los Proveedores.\n ";

        /// <summary>
        /// Representa el texto: Error al cargar la informacion del Proveedor
        /// </summary>
        private const string errorInformacionProveedor_ = "Error al cargar la informacion del Proveedor.\n";

        /// <summary>
        /// Representa el mensaje Error al intentar acutualizar los datos del Proveedor.  
        /// </summary>
        private const string errorUpdateProveedor = "Error al intentar acutualizar los datos del Proveedor.\n";

        /// <summary>
        /// Representa el mensaje : No se puede eliminar el Proveedor ya que hay registros asociados a Él.
        /// </summary>
        private const string errorEliminar = "No se puede eliminar el Proveedor ya que hay registros asociados a Él.\n";

        /// <summary>
        /// Representa el mensaje: No se logro obtener la lista.
        /// </summary>
        private const string errorListaCodigo = "No se logro obtener la lista.\n",
                             errorListaNit = "No se logro obtener la lista.\n",
                             errorListaNombre = "No se logro obtener la lista.\n",
                             errorListaProveedor = "No se logro obtener la lista.\n";

        /// <summary>
        /// Representa el mensaje: Ocurrio un error al ingresar el Producto del Proveedor.
        /// </summary>
        private const string ErrorInsertarProductoProveedor = "Ocurrio un error al ingresar el Producto del Proveedor.\n";

        /// <summary>
        /// Representa el mensaje: Ocurrion un error al comprobar el Proveedor del Producto.
        /// </summary>
        private const string ErrorComprobarProductoProveedor = "Ocurrion un error al comprobar el Proveedor del Producto.\n";

        #endregion

        #region Constructor

        /// <summary>
        /// Inicializa una nueva instacia de la clase DaoProveedor.
        /// </summary>
        public DaoProveedor() 
        {
            this.miConexion = new Conexion();
            this.miDataSet = null;
        }

        #endregion

        #region Metodos

        /// <summary>
        /// Obtiene un número disponible para el codigo consecutivo del registro del Proveedor.
        /// </summary>
        /// <returns></returns>
        public int CargarCodigoConsecutivo() 
        {
            bool match = true;
            int codigo = 0;
            try
            {
                while (match)
                {
                    codigo = ObtenerCodigoConsecutivo();
                    if (ComprobarCodigoConsecutivo(codigo))
                    {
                        ActualizarConsecutivo(codigo);
                        match = true;
                    }
                    else
                        match = false;
                }
                return codigo;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrio un error al generar el codigo. \n" + ex.Message);
            }
        }
        
        /// <summary>
        /// Obtiene el número consecutivo del registro del Proveedor.
        /// </summary>
        /// <returns></returns>
        private int ObtenerCodigoConsecutivo()
        {
            int numero = 0;
            try
            {
                CargarComandoStoredProcedure(sqlObtenerConsecutivo);
                this.miComando.Parameters.AddWithValue("nombre", proveedor);
                this.miConexion.MiConexion.Open();
                numero = Convert.ToInt32(this.miComando.ExecuteScalar());
                this.miConexion.MiConexion.Close();
                this.miComando.Dispose();
                return numero;
            }
            catch (Exception ex)
            {
                throw new Exception(ErrorConsecutivo + ex.Message);
            }
            finally
            {
                miConexion.MiConexion.Close();
            }
        }

        /// <summary>
        /// Comprueba si el codigo existe en un registro de proveedor.
        /// </summary>
        /// <param name="codigo">Codigo a comprobar.</param>
        /// <returns></returns>
        private bool ComprobarCodigoConsecutivo(int codigo) 
        {
            try
            {
                CargarComandoStoredProcedure(sqlComprobarCodigo);
                miComando.Parameters.AddWithValue("codigo", codigo);
                miConexion.MiConexion.Open();
                var resultado = Convert.ToBoolean(miComando.ExecuteScalar());
                miConexion.MiConexion.Close();
                miComando.Dispose();
                return resultado;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                miConexion.MiConexion.Close();
            }
        }
        
        /// <summary>
        /// Actualiza el consecutivo del Proveedor de 1 en 1.
        /// </summary>
        /// <param name="consecutivo">Consecutivo a ingresar</param>
        private void ActualizarConsecutivo(int consecutivo) 
        {
            try
            {
                var numero = consecutivo + 1;
                CargarComandoStoredProcedure(sqlActualizaConsecutivo);
                miComando.Parameters.AddWithValue("conceptoconsecutivo", proveedor);
                miComando.Parameters.AddWithValue("numeroconsecutivo", numero.ToString());
                miConexion.MiConexion.Open();
                miComando.ExecuteNonQuery();
                miConexion.MiConexion.Close();
                miComando.Dispose();
            }
            catch (Exception ex)
            {
                throw new Exception(erroUpdateConsecutivo + ex.Message);
            }
            finally
            {
                miConexion.MiConexion.Close();
            }
        }

        /// <summary>
        /// Verifica si existe el codigo del Proveedor en la base de datos.
        /// </summary>
        /// <param name="codigo">Codigo a verificar.</param>
        /// <returns></returns>
        public bool ExisteProveedorConCodigo(int codigo)
        {
            try
            {
                CargarComandoStoredProcedure(sqlExisteConCodigo);
                miComando.Parameters.AddWithValue("codigoInterno", codigo);
                miConexion.MiConexion.Open();
                var resultado = Convert.ToBoolean(miComando.ExecuteScalar());
                miConexion.MiConexion.Close();
                miComando.Dispose();
                return resultado;
            }
            catch (Exception ex)
            {
                throw new Exception(errorExisteCodigo + ex.Message);
            }
            finally
            {
                miConexion.MiConexion.Close();
            }
        }

        /// <summary>
        /// Verifica si existe el Nit del Proveedor en la base de datos.
        /// </summary>
        /// <param name="nit">Nit a verificar.</param>
        /// <returns></returns>
        public bool ExisteProveedorConNit(string nit)
        {
            try
            {
                CargarComandoStoredProcedure(sqlExisteConNit);
                miComando.Parameters.AddWithValue("nitProveedor", nit);
                miConexion.MiConexion.Open();
                var resultado = Convert.ToBoolean(miComando.ExecuteScalar());
                miConexion.MiConexion.Close();
                miComando.Dispose();
                return resultado;
            }
            catch (Exception ex)
            {
                throw new Exception(errorExisteNit + ex.Message);
            }
            finally
            {
                miConexion.MiConexion.Close();
            }
        }

        /// <summary>
        /// Inserta un Proveedor en la Base de Batos PostgreSQL.
        /// </summary>
        /// <param name="proveedor">Proveedor a Insertar.</param>
        public void InsertarProveedor(Proveedor proveedor)
        {
            miDaoCuenta = new DaoCuenta();
            miDaoContacto = new DaoContactoProveedor();
            try
            {
                if (!ExisteProveedorConNit(proveedor.NitProveedor))
                {
                    CargarComandoStoredProcedure(sqlInsertarProveedor);
                    miComando.Parameters.AddWithValue("codigo", proveedor.CodigoInternoProveedor);
                    miComando.Parameters.AddWithValue("nit", proveedor.NitProveedor);
                    miComando.Parameters.AddWithValue("regimen", proveedor.IdRegimen);
                    miComando.Parameters.AddWithValue("razon", proveedor.RazonSocialProveedor);
                    miComando.Parameters.AddWithValue("nombreComercio", proveedor.NombreComercialProveedor);
                    miComando.Parameters.AddWithValue("descripcion", proveedor.DescripcionProveedor);
                    miComando.Parameters.AddWithValue("direccion", proveedor.DireccionProveedor);
                    miComando.Parameters.AddWithValue("ciudad", proveedor.IdCiudad);
                    miComando.Parameters.AddWithValue("telefono", proveedor.TelefonoProveedor);
                    miComando.Parameters.AddWithValue("celular", proveedor.CelularProveedor);
                    miComando.Parameters.AddWithValue("fax", proveedor.FaxProveedor);
                    miComando.Parameters.AddWithValue("email", proveedor.EmailProveedor);
                    miComando.Parameters.AddWithValue("web", proveedor.WebProveedor);
                    miComando.Parameters.AddWithValue("estado", proveedor.EstadoProveedor);
                    miConexion.MiConexion.Open();
                    miComando.ExecuteNonQuery();
                    foreach (Cuenta cuenta in proveedor.ListadoCuenta)
                    {
                        cuenta.CodigoInternoProveedor = proveedor.CodigoInternoProveedor;
                        miDaoCuenta.InsertarCuenta(cuenta);
                    }
                    foreach (ContactoDeProveedor contacto in proveedor.ListadoContactoProveedor)
                    {
                        contacto.CodigoInternoProveedor = proveedor.CodigoInternoProveedor;
                        miDaoContacto.InsertarContactoProveedor(contacto);
                    }
                    miConexion.MiConexion.Close();
                    miComando.Dispose();
                    var consecutivo = ObtenerCodigoConsecutivo();
                    if (proveedor.CodigoInternoProveedor == consecutivo)
                    {
                        ActualizarConsecutivo(consecutivo);
                    }
                }
            }
            catch(Exception ex)
            {
                throw new Exception(errorInsertarProveedor + ex.Message);
            }
        }

        /// <summary>
        /// Obtiene los datos basicos de un registro de Proveedor.
        /// </summary>
        /// <param name="codigo">Codigo del Proveedor a consultar.</param>
        /// <returns></returns>
        public Proveedor ConsultarPrveedorBasico(int codigo)
        {
            try
            {
                CargarComandoStoredProcedure(sqlConsultaProveedorBasico);
                miComando.Parameters.AddWithValue("codigo", codigo);
                var proveedor = new Proveedor();
                miConexion.MiConexion.Open();
                NpgsqlDataReader miReader = miComando.ExecuteReader();
                while (miReader.Read())
                {
                    proveedor.CodigoInternoProveedor = miReader.GetInt32(0);
                    proveedor.NitProveedor = miReader.GetString(1);
                    proveedor.IdRegimen = miReader.GetInt32(2);
                    proveedor.RazonSocialProveedor = miReader.GetString(3);
                }
                miConexion.MiConexion.Close();
                miComando.Dispose();
                return proveedor;
            }
            catch (Exception ex)
            {
                throw new Exception(errorInformacionProveedor_ + ex.Message);
            }
            finally { miConexion.MiConexion.Close(); }
        }

        /// <summary>
        /// Obtiene los datos basicos de un registro de Proveedor.
        /// </summary>
        /// <param name="nit">NIT del Proveedor a consultar.</param>
        /// <returns></returns>
        public Proveedor ConsultarPrveedorBasico(string nit)
        {
            try
            {
                CargarComandoStoredProcedure(sqlConsultaProveedorBasico);
                miComando.Parameters.AddWithValue("nit", nit);
                var proveedor = new Proveedor();
                miConexion.MiConexion.Open();
                NpgsqlDataReader miReader = miComando.ExecuteReader();
                while (miReader.Read())
                {
                    proveedor.CodigoInternoProveedor = miReader.GetInt32(0);
                    proveedor.NitProveedor = miReader.GetString(1);
                    proveedor.IdRegimen = miReader.GetInt32(2);
                    proveedor.RazonSocialProveedor = miReader.GetString(3);
                }
                miConexion.MiConexion.Close();
                miComando.Dispose();
                return proveedor;
            }
            catch (Exception ex)
            {
                throw new Exception(errorInformacionProveedor_ + ex.Message);
            }
            finally { miConexion.MiConexion.Close(); }
        }

        /// <summary>
        /// Obtiene el registro del Proveedor segun el codigo.
        /// </summary>
        /// <param name="codigo">Codigo del Proveedor a consultar.</param>
        /// <returns></returns>
        public DataSet ConsultaProveedorCodigo(int codigo)
        {
            CargarDataSetTyped(sqlProveedorCodigo, true, codigo);
            return miDataSet;
        }

        /// <summary>
        /// Obtiene el listado de los Proveedores segun el codigo o parte de este.
        /// </summary>
        /// <param name="codigo">Codigo a buscar.</param>
        /// <returns></returns>
        public DataSet FiltroProveedorCodigo(int codigo)
        {
            CargarDataSetTyped(sqlFiltroCodigo, true, codigo);
            return miDataSet;
        }

        /// <summary>
        /// obtiene el registro del Proveedor segun el nit.
        /// </summary>
        /// <param name="nit">Nit a consultar.</param>
        /// <returns></returns>
        public DataSet ConsultaProveedorNit(string nit)
        {
            CargarDataSetTyped(sqlProveedorNit, true, nit);
            return miDataSet;
        }

        /// <summary>
        /// Obtiene el listado de los Proveedores segun el Nit o parte de este.
        /// </summary>
        /// <param name="codigo">Nit o Cedula a buscar.</param>
        /// <returns></returns>
        public DataSet FiltroProveedorNit(string nit)
        {
            CargarDataSetTyped(sqlFiltroNit, true, nit);
            return miDataSet;
        }

        /// <summary>
        /// Obtiene el registro del Proveedor segun el nombre, no distinge de mayscular ni minusculas.
        /// </summary>
        /// <param name="nombre">Nombre a consultar.</param>
        /// <returns></returns>
        public DataSet ConsultaProveedorNombre(string nombre)
        {
            CargarDataSetTyped(sqlProveedorNombre, true, nombre);
            return miDataSet;
        }

        /// <summary>
        /// Obtiene el listado de los Proveedores segun el Nombre o parte de este.
        /// </summary>
        /// <param name="codigo">Nombre a buscar</param>
        /// <returns></returns>
        public DataSet FiltroProveedorNombre(string nombre)
        {
            CargarDataSetTyped(sqlFiltroNombre, true, nombre);
            return miDataSet;
        }

        /// <summary>
        /// Obtiene un DataSet Tipado con las tablas proveedor, cuenta , contacto_proveedor
        /// </summary>
        /// <returns></returns>
        public DataSet ObtenerDataSetType()
        {
            CargarDataSetTyped(sqlListarProveedor, false , null);
            return miDataSet;
        }

        public DataTable Proveedores()
        {
            try
            {
                var tabla = new DataTable();
                CargarAdapterStoredProcedure(sqlListarProveedor);
                miAdapter.Fill(tabla);
                return tabla;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al consultar los Proveedores.\n" + ex.Message);
            }
        }

        public DataTable Proveedores(int codigo)
        {
            try
            {
                var tabla = new DataTable();
                CargarAdapterStoredProcedure(sqlListarProveedor);
                miAdapter.SelectCommand.Parameters.AddWithValue("id", codigo);
                miAdapter.Fill(tabla);
                return tabla;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al consultar los Proveedores.\n" + ex.Message);
            }
        }

        public DataTable Proveedores(string nit)
        {
            try
            {
                var tabla = new DataTable();
                CargarAdapterStoredProcedure(sqlListarProveedor);
                miAdapter.SelectCommand.Parameters.AddWithValue("id", nit);
                miAdapter.Fill(tabla);
                return tabla;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al consultar los Proveedores.\n" + ex.Message);
            }
        }

        /// <summary>
        /// Carga una nueva instancia del DataSet Typed DsProveedor con las tablas proveedor, cuenta, contacto.
        /// </summary>
        /// <param name="cmdProveedor">Query a ejeuctar en Proveedor.</param>
        /// <param name="tipo">Indica si se reciben o no paramentros.</param>
        /// <param name="parameter">Paramentro a asignar.</param>
        public void CargarDataSetTyped(string cmdProveedor, bool tipo, object parameter)
        {
            try
            {
                this.miDataSet = new DsProveedor();
                this.miDataSet.EnforceConstraints = false;

                this.tableProveedor = miDataSet.Tables["view_lista_proveedor"];
                this.tableContacto = miDataSet.Tables["view_contacto_proveedor"];
                this.tableCuenta = miDataSet.Tables["view_listado_cuenta"];

                if (tipo)
                {
                    CargarAdapterStoredProcedure(cmdProveedor);
                    miAdapter.SelectCommand.Parameters.AddWithValue("parameter", parameter);
                }
                else
                    CargarAdapterStoredProcedure(cmdProveedor);

                miAdapter.Fill(tableProveedor);

                CargarAdapterStoredProcedure(sqlListarContacto);
                miAdapter.Fill(tableContacto);

                CargarAdapterStoredProcedure(sqlListarCuenta);
                miAdapter.Fill(tableCuenta);

                miAdapter.Fill(miDataSet);
            }
            catch (Exception ex)
            {
                throw new Exception(errorInformacionProveedor + ex.Message);
            }
        }

        /// <summary>
        /// Obtiene el registro completo de un Proveedor con sus cuentas y contactos.
        /// </summary>
        /// <param name="codigo">Codigo del proveedor a seleccionar</param>
        /// <returns></returns>
        public Proveedor ProveedorAEditar(int codigo)
        {
            Proveedor miProveedor = null;
            miDaoContacto = new DaoContactoProveedor();
            miDaoCuenta = new DaoCuenta();
            try
            {
                CargarComandoStoredProcedure(sqlProveedorAEditar);
                miComando.Parameters.AddWithValue("codigo", codigo);
                miConexion.MiConexion.Open();
                NpgsqlDataReader miReader = miComando.ExecuteReader();
                while (miReader.Read())
                {
                    miProveedor = new Proveedor();
                    miProveedor.CodigoInternoProveedor = miReader.GetInt32(0);
                    miProveedor.NitProveedor = miReader.GetString(1);
                    miProveedor.IdRegimen = miReader.GetInt32(2);
                    miProveedor.Regimen = miReader.GetString(3);
                    miProveedor.RazonSocialProveedor = miReader.GetString(4);
                    miProveedor.NombreComercialProveedor = miReader.GetString(5);
                    miProveedor.DescripcionProveedor = miReader.GetString(6);
                    miProveedor.DireccionProveedor = miReader.GetString(7);
                    miProveedor.IdCiudad = miReader.GetInt32(8);
                    miProveedor.Ciudad = miReader.GetString(9);
                    miProveedor.Departamento = miReader.GetString(10);
                    miProveedor.IdDepartamento = miReader.GetInt32(11);
                    miProveedor.TelefonoProveedor = miReader.GetString(12);
                    miProveedor.CelularProveedor = miReader.GetString(13);
                    miProveedor.FaxProveedor = miReader.GetString(14);
                    miProveedor.EmailProveedor = miReader.GetString(15);
                    miProveedor.WebProveedor = miReader.GetString(16);
                    miProveedor.EstadoProveedor = miReader.GetBoolean(17);
                }
                miConexion.MiConexion.Close();
                miComando.Dispose();
                miProveedor.ListadoContactoProveedor = miDaoContacto.ListaContactos(codigo);
                miProveedor.ListadoCuenta = miDaoCuenta.ListaCueta(codigo);
                return miProveedor;
            }
            catch (Exception ex)
            {
                throw new Exception(errorInformacionProveedor + ex.Message);
            }
            finally
            {
                miConexion.MiConexion.Close();
            }
        }

       /* public Proveedor ProveedorAEditar(string nit)
        {
            Proveedor miProveedor = new Proveedor();
            try
            {
                CargarComandoStoredProcedure(sqlProveedorAEditar);
                miComando.Parameters.AddWithValue("", nit);
                miConexion.MiConexion.Open();
                NpgsqlDataReader miReader = miComando.ExecuteReader();
                while (miReader.Read())
                {
                    miProveedor = new Proveedor();
                    miProveedor.CodigoInternoProveedor = miReader.GetInt32(0);
                    miProveedor.NitProveedor = miReader.GetString(1);
                    miProveedor.IdRegimen = miReader.GetInt32(2);
                    miProveedor.Regimen = miReader.GetString(3);
                    miProveedor.RazonSocialProveedor = miReader.GetString(4);
                    miProveedor.NombreComercialProveedor = miReader.GetString(5);
                    miProveedor.DescripcionProveedor = miReader.GetString(6);
                    miProveedor.DireccionProveedor = miReader.GetString(7);
                    miProveedor.IdCiudad = miReader.GetInt32(8);
                    miProveedor.Ciudad = miReader.GetString(9);
                    miProveedor.Departamento = miReader.GetString(10);
                    miProveedor.IdDepartamento = miReader.GetInt32(11);
                    miProveedor.TelefonoProveedor = miReader.GetString(12);
                    miProveedor.CelularProveedor = miReader.GetString(13);
                    miProveedor.FaxProveedor = miReader.GetString(14);
                    miProveedor.EmailProveedor = miReader.GetString(15);
                    miProveedor.WebProveedor = miReader.GetString(16);
                    miProveedor.EstadoProveedor = miReader.GetBoolean(17);
                }
                miConexion.MiConexion.Close();
                miComando.Dispose();
                return miProveedor;
            }
            catch (Exception ex)
            {
                throw new Exception(errorInformacionProveedor + ex.Message);
            }
            finally
            {
                miConexion.MiConexion.Close();
            }
        }*/

        /// <summary>
        /// Edita los datos de un Proveedor
        /// </summary>
        /// <param name="proveedor">Proveedor a Editar</param>
        public void EditarProveedor(Proveedor proveedor)
        {
            miDaoCuenta = new DaoCuenta();
            miDaoContacto = new DaoContactoProveedor();
            try
            {
                CargarComandoStoredProcedure(sqlEditarProveedor);
                miComando.Parameters.AddWithValue("codigo", proveedor.CodigoInternoProveedor);
                miComando.Parameters.AddWithValue("codigoEditado", proveedor.CodigoEditadoProveedor);
                miComando.Parameters.AddWithValue("nit", proveedor.NitProveedor);
                miComando.Parameters.AddWithValue("regimen", proveedor.IdRegimen);
                miComando.Parameters.AddWithValue("razon", proveedor.RazonSocialProveedor);
                miComando.Parameters.AddWithValue("nombre", proveedor.NombreComercialProveedor);
                miComando.Parameters.AddWithValue("descripcion", proveedor.DescripcionProveedor);
                miComando.Parameters.AddWithValue("direccion", proveedor.DireccionProveedor);
                miComando.Parameters.AddWithValue("ciudad", proveedor.IdCiudad);
                miComando.Parameters.AddWithValue("telefono", proveedor.TelefonoProveedor);
                miComando.Parameters.AddWithValue("celular", proveedor.CelularProveedor);
                miComando.Parameters.AddWithValue("fax", proveedor.FaxProveedor);
                miComando.Parameters.AddWithValue("email", proveedor.EmailProveedor);
                miComando.Parameters.AddWithValue("web", proveedor.WebProveedor);
                miComando.Parameters.AddWithValue("estado", proveedor.EstadoProveedor);
                miConexion.MiConexion.Open();
                miComando.ExecuteNonQuery();
                miConexion.MiConexion.Close();
                miComando.Dispose();
                foreach (Cuenta miCuenta in proveedor.ListadoCuenta)
                {
                    if (miCuenta.IdCuenta != 0)
                        miDaoCuenta.EditarCuenta(miCuenta);
                    else
                        miDaoCuenta.InsertarCuenta(miCuenta);
                }
                foreach (ContactoDeProveedor contacto in proveedor.ListadoContactoProveedor)
                {
                    if (contacto.IdContacto != 0)
                        miDaoContacto.EditarContacto(contacto);
                    else
                        miDaoContacto.InsertarContactoProveedor(contacto);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(errorUpdateProveedor + ex.Message);
            }
        }

        /// <summary>
        /// Elimina el registro de un Proveedor en la base de datos.
        /// </summary>
        /// <param name="codigo">Codigo del proveedor</param>
        public void EliminarProveedor(int codigo)
        {
            try
            {
                CargarComandoStoredProcedure(sqlEliminarProveedor);
                miComando.Parameters.AddWithValue("codigo", codigo);
                miConexion.MiConexion.Open();
                miComando.ExecuteNonQuery();
                miConexion.MiConexion.Close();
                miComando.Dispose();
            }
            catch (Exception ex)
            {
                throw new Exception(errorEliminar + ex.Message);
            }
            finally
            {
                miConexion.MiConexion.Close();
            }
        }

        /// <summary>
        /// Ingresa un registro en la relacion de Proveedor con Producto.
        /// </summary>
        /// <param name="proveedor">Codigo del Proveedor a ingresar.</param>
        /// <param name="producto">Codigo del Producto a ingresar.</param>
        public void IngresarProductoDeProveedor(int proveedor, string producto)
        {
            if (!ComprobarProductoDeProveedor(proveedor, producto))
            {
                try
                {
                    CargarComandoStoredProcedure(sqlInsertarProductoProveedor);
                    miComando.Parameters.AddWithValue("proveedor", proveedor);
                    miComando.Parameters.AddWithValue("producto", producto);
                    miConexion.MiConexion.Open();
                    miComando.ExecuteNonQuery();
                    miConexion.MiConexion.Close();
                    miComando.Dispose();
                }
                catch (Exception ex)
                {
                    throw new Exception(ErrorInsertarProductoProveedor + ex.Message);
                }
                finally { miConexion.MiConexion.Close(); }
            }
        }

        /// <summary>
        /// Comprueba la existencia de una relacion entre un Proveedor y un Producto
        /// </summary>
        /// <param name="proveedor">Codigo del Proveedor a consultar.</param>
        /// <param name="producto">Codigo del Producto a consultar.</param>
        /// <returns></returns>
        private bool ComprobarProductoDeProveedor(int proveedor, string producto)
        {
            var resultado = false;
            try
            {
                CargarComandoStoredProcedure(sqlComprobarProductoProveedor);
                miComando.Parameters.AddWithValue("proveedor", proveedor);
                miComando.Parameters.AddWithValue("producto", producto);
                miConexion.MiConexion.Open();
                resultado = Convert.ToBoolean(miComando.ExecuteScalar());
                miConexion.MiConexion.Close();
                miComando.Dispose();
                return resultado;
            }
            catch (Exception ex)
            {
                throw new Exception(ErrorComprobarProductoProveedor + ex.Message);
            }
            finally { miConexion.MiConexion.Close(); }
        }

        public void ActualizarBeneficiario()
        {
            var daoBeneficio = new DaoBeneficio();
            try
            {
                var proveedores = ObtenerDataSetType();
                foreach (DataRow row in proveedores.Tables["view_lista_proveedor"].Rows)
                {
                    var tabla = daoBeneficio.BeneficiariosNit(row["Nit"].ToString());
                    if (tabla.Rows.Count.Equals(0))
                    {
                        daoBeneficio.Ingresar(new Cliente
                        {
                            NitCliente = row["Nit"].ToString(),
                            NombresCliente = row["Nombre"].ToString(),
                            CelularCliente = row["Telefono"].ToString()
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Inicializa una nueva instancia de comando, tipo Stored Procedure.
        /// </summary>
        /// <param name="cmd">Sentencia a ejecutar.</param>
        private void CargarComandoStoredProcedure(string cmd)
        {
            this.miComando = new NpgsqlCommand();
            this.miComando.Connection = this.miConexion.MiConexion;
            this.miComando.CommandType = CommandType.StoredProcedure;
            this.miComando.CommandText = cmd;
        }

        /// <summary>
        /// Inicializa una nueva instancia del DataAdapter, tipo Stored Procedure.
        /// </summary>
        /// <param name="cmd">Stored Procedure a ejecutar</param>
        private void CargarAdapterStoredProcedure( string cmd )
        {
            this.miAdapter = new NpgsqlDataAdapter( cmd , this.miConexion.MiConexion );
            this.miAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
        }

        #endregion
    }
}