using System;
using System.Data;
using DTO.Clases;
using Npgsql;

namespace DataAccessLayer.Clases
{
    /// <summary>
    /// Representa una clase para la tranzación a base de datos de Lote.
    /// </summary>
    public class DaoLote
    {
        #region Tranzación a base de datos.

        /// <summary>
        /// Proporciona acceso a la conexion de base de datos PostgreSQL.
        /// </summary>
        private Conexion miConexion;

        /// <summary>
        /// Representa un comando de ejecución de sentencias SQL a PostgreSQL.
        /// </summary>
        private NpgsqlCommand miComando;

        #endregion

        #region Funciones

        /// <summary>
        /// Representa la función insertar_lote.
        /// </summary>
        private const string sqlInsertar = "insertar_lote";

        #endregion

        #region Mensajes

        /// <summary>
        /// Ocurrio un error al ingresar el Lote.
        /// </summary>
        private const string ErrorInsertar = "Ocurrio un error al ingresar el Lote.\n";

        #endregion

        /// <summary>
        /// Inicializa una nueva instancia de la clase DaoLote.
        /// </summary>
        public DaoLote()
        {
            this.miConexion = new Conexion();
        }

        /// <summary>
        /// Ingresa un registro de Lote a base de datos.
        /// </summary>
        /// <param name="lote">Lote a ingresar.</param>
        public int IngresarLote(Lote lote)
        {
            try
            {
                CargarComando(sqlInsertar);
                miComando.Parameters.AddWithValue("zona", lote.IdZona);
                miComando.Parameters.AddWithValue("producto", lote.CodigoProducto);
                miComando.Parameters.AddWithValue("numero", lote.Numero);
                miComando.Parameters.AddWithValue("fecha", lote.Fecha);
                miConexion.MiConexion.Open();
                var id = Convert.ToInt32(miComando.ExecuteScalar());
                miConexion.MiConexion.Close();
                miComando.Dispose();
                return id;
            }
            catch (Exception ex)
            {
                throw new Exception(ErrorInsertar + ex.Message);
            }
            finally { miConexion.MiConexion.Close(); }
        }

        /// <summary>
        /// Inicializa una nueva instancia de NpgsqlCommand de tipo StoredProcedure.
        /// </summary>
        /// <param name="cmd">Comando a ejecutar.</param>
        private void CargarComando(string cmd)
        {
            miComando = new NpgsqlCommand();
            miComando.Connection = miConexion.MiConexion;
            miComando.CommandType = CommandType.StoredProcedure;
            miComando.CommandText = cmd;
        }
    }
}