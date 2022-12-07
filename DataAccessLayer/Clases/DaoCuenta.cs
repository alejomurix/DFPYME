using System;
using System.ComponentModel;
using System.Data;
using DTO.Clases;
using Npgsql;

namespace DataAccessLayer.Clases
{
    /// <summary>
    /// Representa una clase de tranzaciones a base de datos PosgreSQL de Cuenta
    /// </summary>
    public class DaoCuenta
    {
        #region Atributos de Tranzacion a base de datos

        /// <summary>
        /// Representa un objeto de conexion a PostgreSQL
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

        #endregion

        #region Atributos que representan procedimientos almacenados

        /// <summary>
        /// Representa el Procedimiento Almacenado "insertar_cuenta" en PostgreSQL para insertar una cuenta.
        /// </summary>
        private const string sqlInsertar = "insertar_cuenta";

        /// <summary>
        /// Representa el Procedimiento Almacenado "existe_cuenta" en PostgreSQL para verificar si existe una cuenta.
        /// </summary>
        private const string sqlExiste = "existe_cuenta";

        /// <summary>
        /// Representa el Procedimiento Almacenado listado_cuenta
        /// </summary>
        private const string sqlListadoCuenta = "listado_cuenta";

        /// <summary>
        /// Representa la funcion listado_cuenta_proveedor_codigo, recibe un codigo como parametro
        /// </summary>
        private const string sqlListadoCuentaProveedor = "listado_cuenta_proveedor_codigo";

        /// <summary>
        /// Representa la funcion editar_cuenta en PostgerSQL
        /// </summary>
        private const string sqlEditarCuenta = "editar_cuenta";

        /// <summary>
        /// Representa la funcion listado_cuenta_empresa,recibe el Nit de la empresa como parametro.
        /// </summary>
        private const string sqlListadoCuentaEmpresa = "listado_cuenta_empresa";

        /// <summary>
        /// Representa la función eliminar_cuenta_empresa
        /// </summary>
        private const string sqlEliminarCunta = "eliminar_cuenta_empresa";

        #endregion

        #region Atributos que representa mensajes

        private const string errorVerificarCuenta = "No se logro verificar la cuenta. ";

        private const string errorInsertarCuenta = "No se logro ingresar la cuenta. ";

        private const string errorlistadoCuenta = "No se logro obtener el listado de las cuentas. ";

        private const string errorEditarCuenta = "No se logro actualizar la cuenta. ";

        #endregion

        #region Constructor

        /// <summary>
        /// Inicializa una nueva instancia de DaoCuenta.
        /// </summary>
        public DaoCuenta() { }

        #endregion

        #region Metodos

        /// <summary>
        /// Verifica si una cuenta existe en la base de datos
        /// </summary>
        /// <param name="cuenta">Numero de cuenta a verificar</param>
        /// <returns></returns>
        public bool ExisteCuenta(string cuenta)
        {
            try
            {
                miConexion = new Conexion();
                CargarComandoStoredProcedure(sqlExiste);
                miComando.Parameters.AddWithValue("numeroCuenta" , cuenta);
                miConexion.MiConexion.Open();
                var resultado = Convert.ToBoolean(miComando.ExecuteScalar());
                miConexion.MiConexion.Close();
                miComando.Dispose();
                return resultado;
            }
            catch (Exception ex)
            {
                throw new Exception(errorVerificarCuenta + ex.Message);
            }
            finally
            {
                miConexion.MiConexion.Close();
            }
        }

        /// <summary>
        /// Ingresa una cuenta a la base de datos.
        /// </summary>
        /// <param name="cuenta">Cuenta a ingresar.</param>
        public void InsertarCuenta(Cuenta cuenta)
        {
            try
            {
                miConexion = new Conexion();
                CargarComandoStoredProcedure(sqlInsertar);
                miComando.Parameters.AddWithValue("tipoCuenta", cuenta.IdTipoCuenta);
                miComando.Parameters.AddWithValue("codigoProveedor", cuenta.CodigoInternoProveedor);
                miComando.Parameters.AddWithValue("nitEmpresa", cuenta.NitEmpresa);
                miComando.Parameters.AddWithValue("banco", cuenta.BancoCuenta);
                miComando.Parameters.AddWithValue("numero", cuenta.NumeroCuenta);
                miComando.Parameters.AddWithValue("titular", cuenta.TitularCuenta);
                miConexion.MiConexion.Open();
                miComando.ExecuteNonQuery();
                miConexion.MiConexion.Close();
                miComando.Dispose();
            }
            catch (Exception ex)
            {
                throw new Exception(errorInsertarCuenta + ex.Message);
            }
            finally
            {
                miConexion.MiConexion.Close();
            }
        }

        /// <summary>
        /// Obtiene el listado de Cuenta en un DataTable.
        /// </summary>
        /// <returns></returns>
       /* public DataTable ListadoCuentas()
        {
            try
            {
                miConexion = new Conexion();
                miDataTable = new DataTable();
                CargarAdapterStoredProcedure(sqlListadoCuenta);
                this.miAdapter.Fill(miDataTable);
                return miDataTable;
            }
            catch (Exception ex)
            {
                throw new Exception(errorlistadoCuenta + ex.Message);
            }
        }*/

        /// <summary>
        /// Obtiene el listado de las Cuentas de un Proveedor en un BindingSource
        /// </summary>
        /// <param name="codigo">Codigo del proveedor de las cuentas.</param>
        /// <returns></returns>
        public BindingList<Cuenta> ListaCueta(int codigo)
        {
            BindingList<Cuenta> lista = new BindingList<Cuenta>();
            try
            {
                miConexion = new Conexion();
                CargarComandoStoredProcedure(sqlListadoCuentaProveedor);
                miComando.Parameters.AddWithValue("codigo", codigo);
                miConexion.MiConexion.Open();
                NpgsqlDataReader miReader = miComando.ExecuteReader();
                while (miReader.Read())
                {
                    Cuenta miCuenta = new Cuenta();
                    miCuenta.IdCuenta = miReader.GetInt32(0);
                    miCuenta.CodigoInternoProveedor = miReader.GetInt32(1);
                    miCuenta.NitEmpresa = miReader.GetString(2);
                    miCuenta.NumeroCuenta = miReader.GetString(3);
                    miCuenta.IdTipoCuenta = miReader.GetInt32(4);
                    miCuenta.TipoCuenta = miReader.GetString(5);
                    miCuenta.TitularCuenta = miReader.GetString(6);
                    miCuenta.BancoCuenta = miReader.GetString(7);
                    lista.Add(miCuenta);
                }
                miConexion.MiConexion.Close();
                miComando.Dispose();
                return lista;
            }
            catch (Exception ex)
            {
                throw new Exception(errorlistadoCuenta + ex.Message);
            }
            finally
            {
                miConexion.MiConexion.Close();
            }
        }

        /// <summary>
        /// Lista cuentas de empresa 
        /// </summary>
        /// <param name="nit">nit a consulatr</param>
        /// <returns></returns>
        public BindingList<Cuenta> ListaCuetaEmpresa(string nit)
        {
            BindingList<Cuenta> lista = new BindingList<Cuenta>();
            try
            {
                miConexion = new Conexion();
                CargarComandoStoredProcedure(sqlListadoCuentaEmpresa);
                miComando.Parameters.AddWithValue("codigo", nit);
                miConexion.MiConexion.Open();
                NpgsqlDataReader miReader = miComando.ExecuteReader();
                while (miReader.Read())
                {
                    Cuenta miCuenta = new Cuenta();
                    miCuenta.IdCuenta = miReader.GetInt32(0);
                    miCuenta.CodigoInternoProveedor = miReader.GetInt32(1);
                    miCuenta.NitEmpresa = miReader.GetString(2);
                    miCuenta.NumeroCuenta = miReader.GetString(3);
                    miCuenta.IdTipoCuenta = miReader.GetInt32(4);
                    miCuenta.TipoCuenta = miReader.GetString(5);
                    miCuenta.TitularCuenta = miReader.GetString(6);
                    miCuenta.BancoCuenta = miReader.GetString(7);
                    lista.Add(miCuenta);
                }
                miConexion.MiConexion.Close();
                miComando.Dispose();
                return lista;
            }
            catch (Exception ex)
            {
                throw new Exception(errorlistadoCuenta + ex.Message);
            }
            finally
            {
                miConexion.MiConexion.Close();
            }
        }

        /// <summary>
        /// Edita los datos de una cuenta de proveedor
        /// </summary>
        /// <param name="miCuenta">Cuenta a editar</param>
        public void EditarCuenta(Cuenta miCuenta)
        {
            try
            {
                miConexion = new Conexion();
                CargarComandoStoredProcedure(sqlEditarCuenta);
                miComando.Parameters.AddWithValue("id", miCuenta.IdCuenta);
                miComando.Parameters.AddWithValue("tipoCuenta", miCuenta.IdTipoCuenta);
                miComando.Parameters.AddWithValue("codigo", miCuenta.CodigoInternoProveedor);
                miComando.Parameters.AddWithValue("nit", miCuenta.NitEmpresa);
                miComando.Parameters.AddWithValue("banco", miCuenta.BancoCuenta);
                miComando.Parameters.AddWithValue("numero", miCuenta.NumeroCuenta);
                miComando.Parameters.AddWithValue("titular", miCuenta.TitularCuenta);
                miConexion.MiConexion.Open();
                miComando.ExecuteNonQuery();
                miConexion.MiConexion.Close();
                miComando.Dispose();
            }
            catch (Exception ex)
            {
                throw new Exception(errorEditarCuenta + miCuenta.NumeroCuenta + " " + ex.Message);
            }
        }

        /// <summary>
        /// Eliminar cuenta.
        /// </summary>
        /// <param name="idCuenta">id cuenta a editar</param>
        public void EliminaCuenta(int idCuenta)
        {
            try
            {
                miConexion = new Conexion();
                CargarComandoStoredProcedure(sqlEliminarCunta);
                miComando.Parameters.AddWithValue("idcuenta", idCuenta);
                miConexion.MiConexion.Open();
                miComando.ExecuteNonQuery();
                miConexion.MiConexion.Close();
                miComando.Dispose();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al eliminar la cuemta." + ex.Message);
            }
            finally { miConexion.MiConexion.Close(); }
        }

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
            this.miAdapter = new NpgsqlDataAdapter(cmd, this.miConexion.MiConexion);
            this.miAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
        }

        #endregion
    }
}