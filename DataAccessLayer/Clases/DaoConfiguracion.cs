using System.Data;
using DTO.Clases;
using Npgsql;
using System;

namespace DataAccessLayer.Clases
{
    public class DaoConfiguracion
    {
        /// <summary>
        /// Representa el objeto de conexión.
        /// </summary>
        private Conexion miConexion;

        /// <summary>
        /// Representa una sentenca en sql.
        /// </summary>
        private NpgsqlCommand miComando;

        /// <summary>
        /// Representa una sentencia adapter en posgres sql.
        /// </summary>
        private NpgsqlDataAdapter miAdapter;

        public DaoConfiguracion()
        {
            this.miConexion = new Conexion();
        }

        public Configuracion Configuracion(int codigo)
        {
            try
            {
                var configuracion = new Configuracion();
                CargarComando("consulta_configuracion");
                miComando.Parameters.AddWithValue("codigo", codigo);
                miConexion.MiConexion.Open();
                NpgsqlDataReader reader = miComando.ExecuteReader();
                while (reader.Read())
                {
                    configuracion.Id = reader.GetInt32(0);
                    configuracion.Codigo = reader.GetInt32(1);
                    configuracion.Descripcion = reader.GetString(2);
                    configuracion.Valor = reader.GetString(3);
                }
                miConexion.MiConexion.Close();
                miComando.Dispose();
                return configuracion;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al consultar la configuración.\n" + ex.Message);
            }
            finally { miConexion.MiConexion.Close(); }
        }

        public void Editar(Configuracion configuracion)
        {
            try
            {
                CargarComando("editar_configuracion");
                miComando.Parameters.AddWithValue("codigo", configuracion.Codigo);
                miComando.Parameters.AddWithValue("valor", configuracion.Valor);
                miConexion.MiConexion.Open();
                miComando.ExecuteNonQuery();
                miConexion.MiConexion.Close();
                miComando.Dispose();
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al editar la configuración.\n" + ex.Message);
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
        /// Inicializa una nueva instancia de NpgsqlDataAdapter de tipo Stored Procedure.
        /// </summary>
        /// <param name="cmd">Sentencia a ejecutar.</param>
        private void CargarAdapter(string cmd)
        {
            miAdapter = new NpgsqlDataAdapter(cmd, miConexion.MiConexion);
            miAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
        }
    }
}