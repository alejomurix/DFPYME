using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Npgsql;

namespace DataAccessLayer.Clases
{
    public class DaoConsecutivoInforme
    {
        /// <summary>
        /// Representa el objeto de conexión.
        /// </summary>
        private Conexion miConexion;

        /// <summary>
        /// Representa una sentenca en sql.
        /// </summary>
        private NpgsqlCommand miComando;

        private NpgsqlDataAdapter miAdapter;

        public DaoConsecutivoInforme()
        {
            this.miConexion = new Conexion();
        }

        public long Count(int idCaja)
        {
            try
            {
                CargarComando("count_consecutivo_informe");
                miComando.Parameters.AddWithValue("idcaja", idCaja);
                miConexion.MiConexion.Open();
                var rows = Convert.ToInt64(miComando.ExecuteScalar());
                miConexion.MiConexion.Close();
                miComando.Dispose();
                return rows;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al conteo de los registros.\n" + ex.Message);
            }
            finally { miConexion.MiConexion.Close(); }
        }

        public DateTime MaxFecha(int idCaja)
        {
            try
            {
                CargarComando("max_fecha_consecutivo_informe");
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

        public DataTable ConsultarRegistro(DateTime fecha, int idCaja)
        {
            var tabla = new DataTable();
            try
            {
                CargarAdapter("consecutivos_informe");
                miAdapter.SelectCommand.Parameters.AddWithValue("fecha", fecha);
                miAdapter.SelectCommand.Parameters.AddWithValue("idcaja", idCaja);
                miAdapter.Fill(tabla);
                return tabla;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al consultar el registro del Informe.\n" + ex.Message);
            }
        }

        public long IngresarRegistro(DateTime fecha, int idCaja, int numero)
        {
            try
            {
                CargarComando("insertar_consecutivo_informe");
                miComando.Parameters.AddWithValue("fecha", fecha);
                miComando.Parameters.AddWithValue("idcaja", idCaja);
                miComando.Parameters.AddWithValue("numero", numero);
                miConexion.MiConexion.Open();
                var id = Convert.ToInt64(miComando.ExecuteScalar());
                miConexion.MiConexion.Close();
                miComando.Dispose();
                return id;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al ingresar el regsitro del Informe.\n" + ex.Message);
            }
            finally { miConexion.MiConexion.Close(); }
        }

        // Consecutivo General
        public long CountGeneral()
        {
            try
            {
                CargarComando("count_consecutivo_informe_general");
                miConexion.MiConexion.Open();
                var rows = Convert.ToInt64(miComando.ExecuteScalar());
                miConexion.MiConexion.Close();
                miComando.Dispose();
                return rows;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al conteo de los registros.\n" + ex.Message);
            }
            finally { miConexion.MiConexion.Close(); }
        }

        public DateTime MaxFechaGeneral()
        {
            try
            {
                CargarComando("max_fecha_consecutivo_informe_general");
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

        public DataTable ConsultarRegistroGeneral(DateTime fecha)
        {
            var tabla = new DataTable();
            try
            {
                CargarAdapter("consecutivos_informe_general");
                miAdapter.SelectCommand.Parameters.AddWithValue("fecha", fecha);
                miAdapter.Fill(tabla);
                return tabla;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al consultar el registro del Informe General.\n" + ex.Message);
            }
        }

        public long IngresarRegistroGeneral(DateTime fecha, int numero)
        {
            try
            {
                CargarComando("insertar_consecutivo_informe_general");
                miComando.Parameters.AddWithValue("fecha", fecha);
                miComando.Parameters.AddWithValue("numero", numero);
                miConexion.MiConexion.Open();
                var id = Convert.ToInt64(miComando.ExecuteScalar());
                miConexion.MiConexion.Close();
                miComando.Dispose();
                return id;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al ingresar el regsitro del Informe General.\n" + ex.Message);
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

        public void CargarAdapter(string cmd)
        {
            miAdapter = new NpgsqlDataAdapter(cmd, miConexion.MiConexion);
            miAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
        }
    }
}