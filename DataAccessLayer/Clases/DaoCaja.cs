using System.Data;
using DTO.Clases;
using Npgsql;
using System;
using Utilities;

namespace DataAccessLayer.Clases
{
    public class DaoCaja
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

        private DaoConsecutivo miDaoConsecutivos;

        public DaoCaja()
        {
            this.miConexion = new Conexion();
            miDaoConsecutivos = new DaoConsecutivo();
        }

        public void Ingresar(Caja caja)
        {
            try
            {
                CargarComando("insertar_caja");
                miComando.Parameters.AddWithValue("numero", caja.Numero);
                miComando.Parameters.AddWithValue("estado", caja.Estado);
                miComando.Parameters.AddWithValue("consecutivo", caja.Consecutivo);
                miConexion.MiConexion.Open();
                miComando.ExecuteNonQuery();
                miConexion.MiConexion.Close();
                miComando.Dispose();
                miDaoConsecutivos.ActualizarConsecutivo("Caja");
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al ingresar la caja.\n" + ex.Message);
            }
            finally { miConexion.MiConexion.Close(); }
        }

        public Caja CajaId(int id)
        {
            try
            {
                CargarComando("cajas_id");
                miComando.Parameters.AddWithValue("id", id);
                miConexion.MiConexion.Open();
                NpgsqlDataReader reader = miComando.ExecuteReader();
                var caja = new Caja();
                while (reader.Read())
                {
                    caja.Id = reader.GetInt32(0);
                    caja.Numero = reader.GetInt32(1);
                    caja.SeriePrinter = reader.GetString(4);
                    caja.Prefijo = reader.GetString(5);
                    caja.NumeroFactura = Convert.ToString(reader.GetInt32(6));
                    caja.IdDian = reader.GetInt32(7);
                    caja.IpServer = reader.GetString(8);
                }
                miConexion.MiConexion.Close();
                miComando.Dispose();
                return caja;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al consultar la caja.\n" + ex.Message);
            }
            finally { miConexion.MiConexion.Close(); }
        }

        public Caja CajaNumero(int numero)
        {
            try
            {
                CargarComando("cajas_numero");
                miComando.Parameters.AddWithValue("id", numero);
                miConexion.MiConexion.Open();
                NpgsqlDataReader reader = miComando.ExecuteReader();
                var caja = new Caja();
                while (reader.Read())
                {
                    caja.Id = reader.GetInt32(0);
                    caja.Numero = reader.GetInt32(1);
                }
                miConexion.MiConexion.Close();
                miComando.Dispose();
                return caja;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al consultar la caja.\n" + ex.Message);
            }
            finally { miConexion.MiConexion.Close(); }
        }

        public DataTable Cajas()
        {
            var tabla = new DataTable();
            try
            {
                CargarAdapter("cajas");
                miAdapter.Fill(tabla);
                return tabla;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al cargar el listado de Cajas.\n" + ex.Message);
            }
        }

        public void ReservarCaja(int id)
        {
            try
            {
                CargarComando("reservar_caja");
                miComando.Parameters.AddWithValue("id", id);
                miConexion.MiConexion.Open();
                miComando.ExecuteNonQuery();
                miConexion.MiConexion.Close();
                miComando.Dispose();
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al reservar la caja.\n" + ex.Message);
            }
            finally { miConexion.MiConexion.Close(); }
        }

        public int Consecutivo(int id)
        {
            try
            {
                CargarComando("consecutivo_caja");
                miComando.Parameters.AddWithValue("id", id);
                miConexion.MiConexion.Open();
                var num = Convert.ToInt32(miComando.ExecuteScalar());
                miConexion.MiConexion.Close();
                miComando.Dispose();
                return num;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al consultar el consecutivo de la caja.\n" + ex.Message);
            }
            finally { miConexion.MiConexion.Close(); }
        }

        public void ActualizarConsecutivo(int id)
        {
            try
            {
                var num = Consecutivo(id);
                CargarComando("actualizar_consecutivo_caja");
                miComando.Parameters.AddWithValue("id", id);
                miComando.Parameters.AddWithValue("numero", num + 1);
                miConexion.MiConexion.Open();
                miComando.ExecuteNonQuery();
                miConexion.MiConexion.Close();
                miComando.Dispose();
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al actualizar el consecutivo de la caja.\n" + ex.Message);
            }
            finally { miConexion.MiConexion.Close(); }
        }

        public int NumeroFactura(int idCaja)
        {
            try
            {
                string sql = "select numero_factura from caja where idcaja = " + idCaja + ";";
                miComando = new NpgsqlCommand();
                miComando.Connection = miConexion.MiConexion;
                miComando.CommandType = CommandType.Text;
                miComando.CommandText = sql;
                this.miConexion.MiConexion.Open();
                int num = Convert.ToInt32(miComando.ExecuteScalar());
                this.miConexion.MiConexion.Close();
                return num;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally { miConexion.MiConexion.Close(); }
        }

        public string PrefijoFactura(int idCaja)
        {
            try
            {
                string sql = "select prefijo_numeracion from caja where idcaja = " + idCaja + ";";
                miComando = new NpgsqlCommand();
                miComando.Connection = miConexion.MiConexion;
                miComando.CommandType = CommandType.Text;
                miComando.CommandText = sql;
                this.miConexion.MiConexion.Open();
                string num = Convert.ToString(miComando.ExecuteScalar());
                this.miConexion.MiConexion.Close();
                return num;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally { miConexion.MiConexion.Close(); }
        }

        public void ActualizarConsecutivoFactura(int idCaja, string numeroActual)
        {
            try
            {
                var num = UseObject.SoloNumberIncrement(numeroActual);

                string sql = "update caja set numero_factura = " + Convert.ToInt32(num) + " where idcaja = " + idCaja + ";";

                miComando = new NpgsqlCommand();
                miComando.Connection = miConexion.MiConexion;
                miComando.CommandType = CommandType.Text;
                miComando.CommandText = sql;
                this.miConexion.MiConexion.Open();
                miComando.ExecuteNonQuery();
                //string prefNum = Convert.ToString(miComando.ExecuteScalar());
                this.miConexion.MiConexion.Close();

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally { this.miConexion.MiConexion.Close(); }
        }

        // Consecutivo General
        public int ConsecutivoGeneral()
        {
            return Convert.ToInt32(miDaoConsecutivos.Consecutivo("InformeGeneral"));
        }

        public void ActualizarConsecutivoGeneral()
        {
            miDaoConsecutivos.ActualizarConsecutivo("InformeGeneral");
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