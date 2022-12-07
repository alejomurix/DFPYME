using System.Data;
using DTO.Clases;
using Npgsql;
using System;

namespace DataAccessLayer.Clases
{
    public class DaoTurno
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

        public DaoTurno()
        {
            this.miConexion = new Conexion();
        }

        public void Ingresar(Turno turno)
        {
            try
            {
                CargarComando("insertar_turno");
                miComando.Parameters.AddWithValue("numero", turno.Numero);
                miConexion.MiConexion.Open();
                miComando.ExecuteNonQuery();
                miConexion.MiConexion.Close();
                miComando.Dispose();
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al ingresar el turno.\n" + ex.Message);
            }
            finally { miConexion.MiConexion.Close(); }
        }

        public Turno TurnoId(int id)
        {
            try
            {
                CargarComando("turnos_id");
                miComando.Parameters.AddWithValue("id", id);
                var turno = new Turno();
                miConexion.MiConexion.Open();
                NpgsqlDataReader miReader = miComando.ExecuteReader();
                while (miReader.Read())
                {
                    turno.Id = miReader.GetInt32(0);
                    turno.Numero = miReader.GetInt32(1);
                }
                miConexion.MiConexion.Close();
                miComando.Dispose();
                return turno;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrio un error al cargar los turnos.\n" + ex.Message);
            }
            finally { miConexion.MiConexion.Close(); }
        }

        public Turno Turno(int numero)
        {
            try
            {
                CargarComando("turnos");
                miComando.Parameters.AddWithValue("numero", numero);
                var turno = new Turno();
                miConexion.MiConexion.Open();
                NpgsqlDataReader miReader = miComando.ExecuteReader();
                while (miReader.Read())
                {
                    turno.Id = miReader.GetInt32(0);
                    turno.Numero = miReader.GetInt32(1);
                }
                miConexion.MiConexion.Close();
                miComando.Dispose();
                return turno;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrio un error al cargar los turnos.\n" + ex.Message);
            }
            finally { miConexion.MiConexion.Close(); }
        }

        public DataTable Turnos()
        {
            try
            {
                var tabla = new DataTable();
                CargarAdapter("turnos");
                miAdapter.Fill(tabla);
                return tabla;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrio un error al cargar los turnos.\n" + ex.Message);
            }
        }



        // FechaTurno
        public void IngresarFechaTurno(DateTime fecha, int idCaja, int idTurno)
        {
            try
            {
                CargarComando("insertar_fecha_turno");
                miComando.Parameters.AddWithValue("fecha", fecha);
                miComando.Parameters.AddWithValue("idcaja", idCaja);
                miComando.Parameters.AddWithValue("idTurno", idTurno);
                miConexion.MiConexion.Open();
                miComando.ExecuteNonQuery();
                miConexion.MiConexion.Close();
                miComando.Dispose();
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al insertar la fecha y turno.\n" + ex.Message);
            }
            finally { miConexion.MiConexion.Close(); }
        }

        public DataTable FechasTurno(DateTime fecha)
        {
            try
            {
                var tabla = new DataTable();
                CargarAdapter("fechas_turno");
                miAdapter.SelectCommand.Parameters.AddWithValue("fecha", fecha);
                miAdapter.Fill(tabla);
                return tabla;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrio un error al cargar las fechas y turnos.\n" + ex.Message);
            }
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