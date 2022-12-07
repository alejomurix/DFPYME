using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using Npgsql;

namespace DataAccessLayer.Clases
{
    /// <summary>
    /// Representa una clase para la pertinencia de datos de Estado.
    /// </summary>
    public class DaoEstado
    {
        #region Transacción a base de datos.

        /// <summary>
        /// Representa un objeto con acceso a la conexión de base de datos Postgresql.
        /// </summary>
        private Conexion miConexion;

        /// <summary>
        /// Representa un comando de ejecucion de sentencias SQL a PostgreSQL.
        /// </summary>
        private NpgsqlCommand miComando;

        /// <summary>
        /// Representa un comando de ejecucion de sentencias SQL a PostgreSQL.
        /// </summary>
        private NpgsqlDataAdapter miAdapter;

        #endregion

        #region Funciones

        /// <summary>
        /// Representa la función listado_estado.
        /// </summary>
        private string Listado = "listado_estado";

        #endregion

        #region Mensajes

        /// <summary>
        /// Representa el texto: Ocurrió un error al cargar el listado de Estado.
        /// </summary>
        private string ErrorLista = "Ocurrió un error al cargar el listado de Estado.\n";

        #endregion

        /// <summary>
        /// Inicializa una nueva instancia de la clase DaoEstado.
        /// </summary>
        public DaoEstado()
        {
            this.miConexion = new Conexion();
        }

        /// <summary>
        /// Obtiene un listado de los registros de Estado.
        /// </summary>
        /// <returns></returns>
        public DataTable Lista()
        {
            var tabla = new DataTable();
            try
            {
                CargarAdapter(Listado);
                miAdapter.Fill(tabla);
                return tabla;
            }
            catch (Exception ex)
            {
                throw new Exception(ErrorLista + ex.Message);
            }
        }

        public DataTable ListaExcluyente(int id)
        {
            var tabla = new DataTable();
            try
            {
                this.CargarAdapter("listado_estado_excluyente");
                this.miAdapter.SelectCommand.Parameters.AddWithValue("", id);
                this.miAdapter.Fill(tabla);
                return tabla;
            }
            catch (Exception ex)
            {
                throw new Exception(ErrorLista + ex.Message);
            }
        }

        public DataTable ListaExcluyente(int id, int id2)
        {
            var tabla = new DataTable();
            try
            {
                this.CargarAdapter("listado_estado_excluyente");
                this.miAdapter.SelectCommand.Parameters.AddWithValue("", id);
                this.miAdapter.SelectCommand.Parameters.AddWithValue("", id2);
                this.miAdapter.Fill(tabla);
                return tabla;
            }
            catch (Exception ex)
            {
                throw new Exception(ErrorLista + ex.Message);
            }
        }

        public DataTable ListaExcluyente(int id, int id2, int id3)
        {
            var tabla = new DataTable();
            try
            {
                this.CargarAdapter("listado_estado_excluyente");
                this.miAdapter.SelectCommand.Parameters.AddWithValue("", id);
                this.miAdapter.SelectCommand.Parameters.AddWithValue("", id2);
                this.miAdapter.SelectCommand.Parameters.AddWithValue("", id3);
                this.miAdapter.Fill(tabla);
                return tabla;
            }
            catch (Exception ex)
            {
                throw new Exception(ErrorLista + ex.Message);
            }
        }


        public DTO.Clases.Estado EstadoById(int id)
        {
            try
            {
                CargarComando("estado_by_id");
                miComando.Parameters.AddWithValue("id", id);
                miConexion.MiConexion.Open();
                NpgsqlDataReader reader = miComando.ExecuteReader();
                var estado = new DTO.Clases.Estado();
                while (reader.Read())
                {
                    estado.Id = reader.GetInt32(0);
                    estado.Descripcion = reader.GetString(1);
                }
                miConexion.MiConexion.Close();
                miComando.Dispose();
                return estado;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al consultar el estado.\n" + ex.Message);
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

        /// <summary>
        /// Inicializa una nueva instancia de NpgsqlDataAdapter de tipo StoredProcedure.
        /// </summary>
        /// <param name="cmd">Comando a ejecutar.</param>
        private void CargarAdapter(string cmd)
        {
            miAdapter = new NpgsqlDataAdapter(cmd, this.miConexion.MiConexion);
            miAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
        }
    }
}