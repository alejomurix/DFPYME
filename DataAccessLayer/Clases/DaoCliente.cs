using System;
using System.Data;
using System.Linq;
using System.Collections.Generic;
using Npgsql;
using DTO.Clases;
using System.Collections;

namespace DataAccessLayer.Clases
{
    /// <summary>
    /// Representa una clase de Acceso a datos para un Cliente
    /// </summary>
    public class DaoCliente
    {
        #region Atributos Constantes

        /// <summary>
        /// Nombre del Stored Procedure "insertar_cliente".
        /// </summary>
        private const string sqlInsertar = "insertar_cliente";

        /// <summary>
        /// Representa la funcion existe_cliente
        /// </summary>
        private const string sqlExisteCliente = "existe_cliente";

        /// <summary>
        /// Nombre del Stored Procedure "func_listado_cliente", que desencadena una vista.
        /// </summary>
        private const string sqlListar = "func_listado_cliente";

        /// <summary>
        /// Representa la funcion consulta_cliente_cedula
        /// </summary>
        private const string sqlConsultaNit = "consulta_cliente_cedula";

        /// <summary>
        /// Representa la funcion consulta_cliente_nombre
        /// </summary>
        private const string sqlConsultNombre = "consulta_cliente_nombre";

        /// <summary>
        /// Funcion en PostgreSQL que filtra el listado de Clientes segun el parametro nombre o parte de este
        /// </summary>
        private const string funFiltroClienteNombre = 
            "filtro_clientes_nombre";

        /// <summary>
        /// Funcion en PostgreSQL que filtra el listado de Clientes segun el parametro Nit o cedula o parte de este
        /// </summary>
        private const string funFiltroClienteCedula = "filtro_clientes_cedula";

        /// <summary>
        /// Representa la funcion cliente_a_editar en PostgreSQL
        /// </summary>
        private const string sqlClienteAEditar = "cliente_a_editar";

        /// <summary>
        /// Representa la funcion editar_cliente
        /// </summary>
        private const string sqlEditarCliente = "editar_cliente";

        /// <summary>
        /// Representa la funcion eliminar_cliente
        /// </summary>
        private const string sqlEliminarCliente = "eliminar_cliente";

        /// <summary>
        /// Representa la función: print_cliente.
        /// </summary>
        private string PrintCliente_ = "print_cliente";

        /// <summary>
        /// Representa el texto : "Ocurrio un Error al ingresar el cliente. "
        /// </summary>
        private const string errorInsertar = "Ocurrio un Error al ingresar el cliente.\n";

        /// <summary>
        /// Representa el texto: Ocurrio un Error al verificar el Cliente.
        /// </summary>
        private const string msnErrorExiste = "Ocurrio un Error al verificar el Cliente.\n";

        /// <summary>
        /// Representa el texto : Ocurrio un Error al consultar el cliente.
        /// </summary>
        private const string errorConsulta = "Ocurrio un Error al consultar el cliente.\n";

        /// <summary>
        /// Representa el texto : "Ocurrio un Error al obtener la lista de los clientes. "
        /// </summary>
        private const string errorListar = "Ocurrio un Error al obtener la lista de los clientes.\n";

        /// <summary>
        /// Representa el texto: Ocurrio un error al cargar los datos del cliente. "
        /// </summary>
        private const string errorClienteAEditar = "Ocurrio un error al cargar los datos del cliente.\n";

        /// <summary>
        /// Representa el texto: Ocurrio un error al editar los datos del Cliente.
        /// </summary>
        private const string errorEditarCliente = "Ocurrio un error al editar los datos del Cliente.\n";

        /// <summary>
        /// Representa el texto No se puede eliminar el Cliente, ya que tiene registros asociados a él
        /// </summary>
        private const string errorEliminar = "No se puede eliminar el Cliente, ya que tiene registros asociados a él.\n";

        #endregion

        #region Atributos de Trancacion a Base de Datos

        /// <summary>
        /// Representa una conexion al servidor de Base de Datos PostgreSQL.
        /// </summary>
        private Conexion conexion;

        /// <summary>
        /// Representa un Comando o StoredProcedure en SQL para ser ejecutado en PostgreSQL.
        /// </summary>
        private NpgsqlCommand miComando;

        /// <summary>
        /// Representa un DataAdapter de multiples comandos: select, insert, update, delete
        /// </summary>
        private NpgsqlDataAdapter miAdapter;

        /// <summary>
        /// Representa un objeto tipo cliente
        /// </summary>
        //private Cliente miCliente;

        #endregion

        #region Atributos de Datos

        /// <summary>
        /// Representa una tabla de datos en memoria
        /// </summary>
        private DataTable miDataTable;

        #endregion

        #region Atributos de Colecion tipicas y genericas

        #endregion

        /// <summary>
        /// Inicializa una nueva instancia de DaoCliente
        /// </summary>
        public DaoCliente()
        {
            conexion = new Conexion();
        }

        #region Metodos

        // temporal
        public DataTable Tipos()
        {
            try
            {
                var tabla = new DataTable();
                CargarDataAdapterStoredProcedure("tipos_cliente");
                miAdapter.Fill(tabla);
                return tabla;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al consultar los tipos.\n" + ex.Message);
            }
        }

        public DataTable Clasificacion()
        {
            try
            {
                var tabla = new DataTable();
                CargarDataAdapterStoredProcedure("clasificacion_cliente");
                miAdapter.Fill(tabla);
                return tabla;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al consultar la clasificación.\n" + ex.Message);
            }
        }

        //

        /// <summary>
        /// Verifica si un cliente existe en la base de datos.
        /// </summary>
        /// <param name="nit">Nit del Cliente</param>
        /// <returns></returns>
        public bool ExisteCliente(string nit)
        {
            bool resultado = false;
            try
            {
                CargarComandoStoredProcedure(sqlExisteCliente);
                miComando.Parameters.AddWithValue("nit", nit);
                conexion.MiConexion.Open();
                resultado = Convert.ToBoolean(miComando.ExecuteScalar());
                conexion.MiConexion.Close();
                miComando.Dispose();
                return resultado;
            }
            catch (Exception ex)
            {
                throw new Exception(msnErrorExiste + ex.Message);
            }
            finally
            {
                conexion.MiConexion.Close();
            }
        }
        
        ///<summary>
        /// Metodo para insertar un nuevo cliente
        ///</summary>
        ///<param name="cliente">Recibe un objeto tipo Cliente</param>
        public void InsertarCliente(Cliente cliente)
        {
            try
            {
                if (!ExisteCliente(cliente.NitCliente))
                {
                    CargarComandoStoredProcedure(sqlInsertar);
                    miComando.Parameters.AddWithValue("", cliente.NitCliente);
                    miComando.Parameters.AddWithValue("", cliente.IdRegimen);
                    miComando.Parameters.AddWithValue("", cliente.NombresCliente);
                    miComando.Parameters.AddWithValue("", cliente.TelefonoCliente);
                    miComando.Parameters.AddWithValue("", cliente.CelularCliente);
                    miComando.Parameters.AddWithValue("", cliente.EmailCliente);
                    miComando.Parameters.AddWithValue("", cliente.IdCiudad);
                    miComando.Parameters.AddWithValue("", cliente.DireccionCliente);
                    miComando.Parameters.AddWithValue("", cliente.EstadoCliente);
                    miComando.Parameters.AddWithValue("", cliente.IdTipoCliente);
                    miComando.Parameters.AddWithValue("", cliente.IdClasificacion);

                    conexion.MiConexion.Open();
                    miComando.ExecuteNonQuery();
                    conexion.MiConexion.Close();
                }
            }
            catch (Exception ex)
            {
                throw new Exception( errorInsertar + ex.Message );
            }
            finally
            {
                conexion.MiConexion.Close();
            }
        }

        /// <summary>
        /// Obtiene el listado de los clientes en un DataTable
        /// </summary>
        /// <returns></returns>
        public DataTable ListadoDeClientes()
        {
            try
            {
                CargarDataAdapterStoredProcedure(sqlListar);
                this.miAdapter.Fill(miDataTable);
                return miDataTable;
            }
            catch (Exception ex)
            {
                throw new Exception( errorListar + ex.Message );
            }
        }

        public DataTable ListadoDeClientesCredito()
        {
            try
            {
                CargarDataAdapterStoredProcedure("func_listado_cliente_credito");
                this.miAdapter.Fill(miDataTable);
                return miDataTable;
            }
            catch (Exception ex)
            {
                throw new Exception(errorListar + ex.Message);
            }
        }

        /// <summary>
        /// Obtiene el resultado de la consulta de un Cliente por su Nit
        /// </summary>
        /// <param name="nit">Nit del Cliente a consultar</param>
        /// <returns></returns>
        public DataTable ConsultaClienteNit(string nit)
        {
            try
            {
                CargarDataAdapterStoredProcedure(sqlConsultaNit);
                this.miAdapter.SelectCommand.Parameters.AddWithValue("nit", nit);
                this.miAdapter.Fill(miDataTable);
                return miDataTable;
            }
            catch (Exception ex)
            {
                throw new Exception(errorConsulta + ex.Message);
            }
        }

        /// <summary>
        /// Obtiene el resultado de la consulta de un Cliente por su Nombre
        /// </summary>
        /// <param name="nombre">Nombre del cliente a consultar</param>
        /// <returns></returns>
        public DataTable ConsultaClienteNombre(string nombre)
        {
            try
            {
                CargarDataAdapterStoredProcedure(sqlConsultNombre);
                this.miAdapter.SelectCommand.Parameters.AddWithValue("nombre", nombre);
                this.miAdapter.Fill(miDataTable);
                return miDataTable;
            }
            catch (Exception ex)
            {
                throw new Exception(errorConsulta + ex.Message);
            }
        }

        /// <summary>
        /// Crea un DataTable con la lista de los clientes segun el criterio enviado.
        /// </summary>
        /// <param name="nombre">Nombre o parte del nombre a ser buscado</param>
        /// <returns></returns>
        public DataTable FiltroClienteNombre(string nombre)
        {
            try
            {
                CargarDataAdapterStoredProcedure(funFiltroClienteNombre);
                this.miAdapter.SelectCommand.Parameters.AddWithValue("nombreCliente", nombre);
                this.miAdapter.Fill(miDataTable);
                return miDataTable;
            }
            catch (Exception ex)
            {
                throw new Exception( errorListar + ex.Message );
            }
        }

        /// <summary>
        /// Crea un DataTable con la lista de los clientes segun el criterio enviado.
        /// </summary>
        /// <param name="cedula">Nit o Cedula o parte de esta para ser buscada</param>
        /// <returns></returns>
        public DataTable FiltroClienteCedula( string cedula ) 
        {
            try
            {
                CargarDataAdapterStoredProcedure(funFiltroClienteCedula);
                this.miAdapter.SelectCommand.Parameters.AddWithValue("nitCliente", cedula);
                this.miAdapter.Fill(miDataTable);
                return miDataTable;
            }
            catch (Exception ex)
            {
                throw new Exception(errorInsertar + ex.Message);
            }
        }

        /// <summary>
        /// Obtiene el registro completo de un Cliente
        /// </summary>
        /// <param name="nit">Nit del Cliente a editar</param>
        /// <returns></returns>
        public Cliente ClienteAEditar(string nit)
        {
            Cliente cliente = new Cliente();
            try
            {
                CargarComandoStoredProcedure(sqlClienteAEditar);
                miComando.Parameters.AddWithValue("nit", nit);
                conexion.MiConexion.Open();
                NpgsqlDataReader miReader = miComando.ExecuteReader();
                while (miReader.Read())
                {
                    cliente.NitCliente = miReader.GetString(0);
                    cliente.IdRegimen = miReader.GetInt32(1);
                    cliente.Regimen = miReader.GetString(2);
                    cliente.NombresCliente = miReader.GetString(3);
                    cliente.TelefonoCliente = miReader.GetString(4);
                    cliente.CelularCliente = miReader.GetString(5);
                    cliente.EmailCliente = miReader.GetString(6);
                    cliente.IdCiudad = miReader.GetInt32(7);
                    cliente.Ciudad = miReader.GetString(8);
                    cliente.IdDepartamento = miReader.GetInt32(9);
                    cliente.Departamento = miReader.GetString(10);
                    cliente.DireccionCliente = miReader.GetString(11);
                    cliente.EstadoCliente = miReader.GetBoolean(12);
                    cliente.IdTipoCliente = miReader.GetInt32(13);
                    cliente.DescripcionTipo = miReader.GetString(14);
                    cliente.IdClasificacion = miReader.GetInt32(15);
                    cliente.DescripcionClasifica = miReader.GetString(16);
                }
                conexion.MiConexion.Close();
                miComando.Dispose();
                return cliente;
            }
            catch (Exception ex)
            {
                throw new Exception(errorClienteAEditar + ex.Message);
            }
        }

        /// <summary>
        /// Edita los datos de un cliente
        /// </summary>
        /// <param name="cliente">Cliente a editar</param>
        public void EditarCliente(Cliente cliente)
        {
            try
            {
                CargarComandoStoredProcedure(sqlEditarCliente);
                miComando.Parameters.AddWithValue("", cliente.NitCliente);               
                miComando.Parameters.AddWithValue("", cliente.NitEditado);        
                miComando.Parameters.AddWithValue("", cliente.IdRegimen);          
                miComando.Parameters.AddWithValue("", cliente.NombresCliente);        
                miComando.Parameters.AddWithValue("", cliente.TelefonoCliente);     
                miComando.Parameters.AddWithValue("", cliente.CelularCliente);       
                miComando.Parameters.AddWithValue("", cliente.EmailCliente);           
                miComando.Parameters.AddWithValue("", cliente.IdCiudad);            
                miComando.Parameters.AddWithValue("", cliente.DireccionCliente);   
                miComando.Parameters.AddWithValue("", cliente.EstadoCliente);
                miComando.Parameters.AddWithValue("", cliente.IdTipoCliente);
                miComando.Parameters.AddWithValue("", cliente.IdClasificacion);
                conexion.MiConexion.Open();
                miComando.ExecuteNonQuery();
                conexion.MiConexion.Close();
                miComando.Dispose();
            }
            catch (Exception ex)
            {
                throw new Exception(errorEditarCliente + ex.Message);
            }
        }

        /// <summary>
        /// Elimina el registro de un cliente de la base de datos
        /// </summary>
        /// <param name="nit">Nit del clinete a eliminar</param>
        public void EliminarCliente(string nit)
        {
            try
            {
                CargarComandoStoredProcedure(sqlEliminarCliente);
                miComando.Parameters.AddWithValue("nit", nit);
                conexion.MiConexion.Open();
                miComando.ExecuteNonQuery();
                conexion.MiConexion.Close();
                miComando.Dispose();
            }
            catch (Exception ex)
            {
                throw new Exception(errorEliminar + ex.Message);
            }

        }

        /// <summary>
        /// Obtiene los datos del Cliente de la factura de venta para su impresión.
        /// </summary>
        /// <param name="nit">Nit del cliente de la Factura.</param>
        /// <returns></returns>
        public DataSet PrintCliente(string nit)
        {
            var dataSet = new DataSet();
            try
            {
                CargarDataAdapterStoredProcedure(PrintCliente_);
                miAdapter.SelectCommand.Parameters.AddWithValue("nit", nit);
                miAdapter.Fill(dataSet, "Cliente");
                return dataSet;
            }
            catch (Exception ex)
            {
                throw new Exception(errorConsulta + ex.Message);
            }
        }

        // Puntos de cliente

        public double Puntos(string nitCliente)
        {
            try
            {
                this.CargarComandoStoredProcedure("punto_de_cliente");
                this.miComando.Parameters.AddWithValue("", nitCliente);
                this.conexion.MiConexion.Open();
                double p = Convert.ToDouble(this.miComando.ExecuteScalar());
                this.conexion.MiConexion.Close();
                this.miComando.Dispose();
                return p;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al consultar los puntos del cliente.\n" + ex.Message);
            }
            finally { this.conexion.MiConexion.Close(); }
        }

        public void EditarPuntos(string nitCliente, double puntos)
        {
            try
            {
                this.CargarComandoStoredProcedure("editar_punto_cliente");
                this.miComando.Parameters.AddWithValue("", nitCliente);
                this.miComando.Parameters.AddWithValue("", puntos);
                this.conexion.MiConexion.Open();
                this.miComando.ExecuteNonQuery();
                this.conexion.MiConexion.Close();
                this.miComando.Dispose();
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al editar los puntos del cliente.\n" + ex.Message);
            }
            finally { this.conexion.MiConexion.Close(); }
        }

        public void InsertarCanje(Canje canje)
        {
            try
            {
                this.CargarComandoStoredProcedure("insertar_canje_puntos");
                this.miComando.Parameters.AddWithValue("", canje.NitCliente);
                this.miComando.Parameters.AddWithValue("", canje.Fecha);
                this.miComando.Parameters.AddWithValue("", canje.Concepto);
                this.miComando.Parameters.AddWithValue("", canje.PuntosAntes);
                this.miComando.Parameters.AddWithValue("", canje.Puntos);
                this.miComando.Parameters.AddWithValue("", canje.Valor_);
                this.conexion.MiConexion.Open();
                this.miComando.ExecuteNonQuery();
                this.conexion.MiConexion.Close();
                this.miComando.Dispose();
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al ingresar el canje.\n" + ex.Message);
            }
            finally { this.conexion.MiConexion.Close(); }
        }

        // Fin Puntos de cliente

        //REGION SALDOS DE CLIENTE.



        public void DepurarCliente()
        {
            try
            {
                foreach (DataRow cRow in ListadoDeClientes().Rows)
                {
                    DeleteClientes(cRow["nitcliente"].ToString());
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private void DeleteClientes(string nit)
        {
            try
            {
                string sql = "delete from cliente where nitcliente = '" + nit + "';";
                this.miComando = new NpgsqlCommand();
                this.miComando.Connection = this.conexion.MiConexion;
                this.miComando.CommandType = CommandType.Text;
                this.miComando.CommandText = sql;
                this.conexion.MiConexion.Open();
                this.miComando.ExecuteNonQuery();
                this.miComando.Dispose();
                this.conexion.MiConexion.Close();
            }
            catch { }
            finally
            {
                this.miComando.Dispose();
                this.conexion.MiConexion.Close();
            }
        }

        

        

        /*public void EditarUltimoSaldo(int id)
        {
            try
            {
                CargarComandoStoredProcedure("editar_solo_saldo_cliente");
                miComando.Parameters.AddWithValue("id", id);
                conexion.MiConexion.Open();
                miComando.ExecuteNonQuery();
                conexion.MiConexion.Close();
                miComando.Dispose();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally { conexion.MiConexion.Close(); }
        }*/

        /// <summary>
        /// Inicializa una nueva instancia del comando, tipo Stored Procedure
        /// </summary>
        /// <param name="cmd">Stored Procedure a ejecutar</param>
        private void CargarComandoStoredProcedure(string cmd)
        {
            miComando = new NpgsqlCommand();
            miComando.Connection = conexion.MiConexion;
            miComando.CommandType = CommandType.StoredProcedure;
            miComando.CommandText = cmd;
        }

        /// <summary>
        /// Inicializa una nueva instancia del DataAdapter, tipo Stored Procedure
        /// </summary>
        /// <param name="cmd">Stored Procedure a ejecutar</param>
        private void CargarDataAdapterStoredProcedure(string cmd)
        {
            miDataTable = new DataTable();
            this.miAdapter = new NpgsqlDataAdapter(cmd, this.conexion.MiConexion);
            this.miAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
        }

        #endregion
    }
}