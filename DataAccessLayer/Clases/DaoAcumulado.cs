using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Npgsql;

namespace DataAccessLayer.Clases
{
    public class DaoAcumulado
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

        public DaoAcumulado()
        {
            this.miConexion = new Conexion();
        }

        public void Ingresar(DateTime fecha, int valor)
        {
            try
            {
                CargarComando("insertar_acomulado_general");
                miComando.Parameters.AddWithValue("fecha", fecha);
                miComando.Parameters.AddWithValue("valor", valor);
                miConexion.MiConexion.Open();
                miComando.ExecuteNonQuery();
                miConexion.MiConexion.Close();
                miComando.Dispose();
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al ingresar el Acumulado.\n" + ex.Message);
            }
            finally { miConexion.MiConexion.Close(); }
        }

        public long CountAcumulado()
        {
            try
            {
                CargarComando("count_acomulado_general");
                miConexion.MiConexion.Open();
                var count = Convert.ToInt64(miComando.ExecuteScalar());
                miConexion.MiConexion.Close();
                miComando.Dispose();
                return count;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al cargar el conteo,\n" + ex.Message);
            }
            finally { miConexion.MiConexion.Close(); }
        }

        public DataTable Acumulados(DateTime fecha)
        {
            var tabla = new DataTable();
            try
            {
                CargarAdapter("acomulados_general");
                miAdapter.SelectCommand.Parameters.AddWithValue("fecha", fecha);
                miAdapter.Fill(tabla);
                return tabla;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al consultar los Acumulados.\n" + ex.Message);
            }
        }

        public DateTime MaxFecha()
        {
            try
            {
                CargarComando("max_fecha_acumulado_general");
                miConexion.MiConexion.Open();
                var fecha = Convert.ToDateTime(miComando.ExecuteScalar());
                miConexion.MiConexion.Close();
                miComando.Dispose();
                return fecha;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al consultar la fecha.\n" + ex.Message);
            }
            finally { miConexion.MiConexion.Close(); }
        }

        // ACUMULADO POR CAJA
        public void IngresarCaja(DateTime fecha, int idCaja, int valor)
        {
            try
            {
                CargarComando("insertar_acomulado");
                miComando.Parameters.AddWithValue("fecha", fecha);
                miComando.Parameters.AddWithValue("valor", valor);
                miComando.Parameters.AddWithValue("idcaja", idCaja);
                miConexion.MiConexion.Open();
                miComando.ExecuteNonQuery();
                miConexion.MiConexion.Close();
                miComando.Dispose();
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al ingresar el Acumulado.\n" + ex.Message);
            }
            finally { miConexion.MiConexion.Close(); }
        }

        public long CountAcumuladoCaja(int idCaja)
        {
            try
            {
                CargarComando("count_acomulado");
                miComando.Parameters.AddWithValue("idcaja", idCaja);
                miConexion.MiConexion.Open();
                var count = Convert.ToInt64(miComando.ExecuteScalar());
                miConexion.MiConexion.Close();
                miComando.Dispose();
                return count;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al cargar el conteo,\n" + ex.Message);
            }
            finally { miConexion.MiConexion.Close(); }
        }

        public DataTable AcumuladosCaja(DateTime fecha, int idCaja)
        {
            var tabla = new DataTable();
            try
            {
                CargarAdapter("acomulados");
                miAdapter.SelectCommand.Parameters.AddWithValue("fecha", fecha);
                miAdapter.SelectCommand.Parameters.AddWithValue("idcaja", idCaja);
                miAdapter.Fill(tabla);
                return tabla;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al consultar los Acumulados.\n" + ex.Message);
            }
        }

        public DateTime MaxFechaCaja(int idCaja)
        {
            try
            {
                CargarComando("max_fecha_acumulado");
                miComando.Parameters.AddWithValue("idcaja", idCaja);
                miConexion.MiConexion.Open();
                var fecha = Convert.ToDateTime(miComando.ExecuteScalar());
                miConexion.MiConexion.Close();
                miComando.Dispose();
                return fecha;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al consultar la fecha.\n" + ex.Message);
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