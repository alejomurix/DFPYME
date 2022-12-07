using System;
using System.Data;
using System.Linq;
using System.Text;
using DTO.Clases;
using Npgsql;
using Utilities;

namespace DataAccessLayer.Clases
{
    public class DaoCierre
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

        public DaoCierre()
        {
            this.miConexion = new Conexion();
        }

        public void Ingresar(Cierre cierre)
        {
            try
            {
                CargarComando("insertar_cierre");
                miComando.Parameters.AddWithValue("idapertura", cierre.IdApertura);
                miComando.Parameters.AddWithValue("fecha", cierre.Fecha);
                miComando.Parameters.AddWithValue("hora", cierre.Fecha.TimeOfDay);
                miComando.Parameters.AddWithValue("caja", cierre.Caja.Id);
                miComando.Parameters.AddWithValue("turno", cierre.Turno.Id);
                miComando.Parameters.AddWithValue("usuario", cierre.Usuario.Id);
                miConexion.MiConexion.Open();
                var id = Convert.ToInt32(miComando.ExecuteScalar());
                miConexion.MiConexion.Close();
                miComando.Dispose();
                if (cierre.Valores.Sum(s => s.Valor) > 0)
                {
                    foreach (FormaPago valor in cierre.Valores)
                    {
                        if (valor.Valor > 0)
                        {
                            valor.IdEgreso = id;
                            this.IngresarValor(valor);
                        }
                    }
                }
                else
                {
                    for (int i = 0; i <= 0; i++)
                    {
                        var valor = cierre.Valores[i];
                        valor.IdEgreso = id;
                        this.IngresarValor(valor);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al ingresar el cierre.\n" + ex.Message);
            }
            finally { miConexion.MiConexion.Close(); }
        }

        public void IngresarValor(FormaPago valor)
        {
            try
            {
                CargarComando("insertar_cierre_forma_pago");
                miComando.Parameters.AddWithValue("idcierre", valor.IdEgreso);
                miComando.Parameters.AddWithValue("idpago", valor.IdFormaPago);
                miComando.Parameters.AddWithValue("valor", valor.Valor);
                miConexion.MiConexion.Open();
                miComando.ExecuteNonQuery();
                miConexion.MiConexion.Close();
                miComando.Dispose();
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al ingresar el valor.\n" + ex.Message);
            }
            finally { miConexion.MiConexion.Close(); }
        }

        public Cierre Cierre(int idApertura)
        {
            try
            {
                var cierre = new Cierre();
                CargarComando("cierre");
                miComando.Parameters.AddWithValue("", idApertura);
                miConexion.MiConexion.Open();
                NpgsqlDataReader miReader = miComando.ExecuteReader();
                while (miReader.Read())
                {
                    cierre.Id = miReader.GetInt32(0);
                    cierre.IdApertura = miReader.GetInt32(1);
                    cierre.Fecha = UseDate.UnionFechaYHora(miReader.GetDateTime(2), miReader.GetDateTime(3));
                    cierre.Caja.Id = miReader.GetInt32(4);
                    cierre.Turno.Id = miReader.GetInt32(5);
                    //cierre.Usuario.Id = miReader.GetInt32(6);
                    cierre.Valor = Convert.ToInt32(miReader.GetInt64(7));
                }
                miConexion.MiConexion.Close();
                miComando.Dispose();
                return cierre;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al consultar el cierre.\n" + ex.Message);
            }
            finally { miConexion.MiConexion.Close(); }
        }

        public int TotalCierre(int idApertura)
        {
            try
            {
                int total = 0;
                var cierre = new Cierre();
                CargarComando("print_cierre");
                miComando.Parameters.AddWithValue("", idApertura);
                miConexion.MiConexion.Open();
                NpgsqlDataReader miReader = miComando.ExecuteReader();
                while (miReader.Read())
                {
                    total += miReader.GetInt32(7);
                }
                miConexion.MiConexion.Close();
                miComando.Dispose();
                return total;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al consultar el cierre.\n" + ex.Message);
            }
            finally { miConexion.MiConexion.Close(); }
        }

        public DataTable Tcierres(int idApertura)
        {
            try
            {
                var tabla = new DataTable();
                CargarAdapter("formas_pago_cierre");
                miAdapter.SelectCommand.Parameters.AddWithValue("", idApertura);
                miAdapter.Fill(tabla);
                return tabla;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al consultar las formas de pago del cierre.\n" + ex.Message);
            }
        }


        public DataTable Print(DateTime fecha, int idCaja, int idTurno)
        {
            try
            {
                var tabla = new DataTable();
                CargarAdapter("print_cierre");
                miAdapter.SelectCommand.Parameters.AddWithValue("fecha", fecha);
                miAdapter.SelectCommand.Parameters.AddWithValue("idcaja", idCaja);
                miAdapter.SelectCommand.Parameters.AddWithValue("idturno", idTurno);
                miAdapter.Fill(tabla);
                return tabla;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al consultar el cierre.\n" + ex.Message);
            }
        }

        public DataTable Print(int idApertura)
        {
            try
            {
                var tabla = new DataTable();
                CargarAdapter("print_cierre");
                miAdapter.SelectCommand.Parameters.AddWithValue("fecha", idApertura);
                miAdapter.Fill(tabla);
                return tabla;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al consultar el cierre.\n" + ex.Message);
            }
        }

        public void EliminarPagosCierre(int idCierre)
        {
            try
            {
                CargarComando("eliminar_forma_pago_cierre");
                miComando.Parameters.AddWithValue("", idCierre);
                miConexion.MiConexion.Open();
                miComando.ExecuteNonQuery();
                miConexion.MiConexion.Close();
                miComando.Dispose();
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al editar el cierre.\n" + ex.Message);
            }
            finally { miConexion.MiConexion.Close(); }
        }

        /*public void EditarPagosCierre(int id, int valor)
        {
            try
            {
                CargarComando("editar_valor_cierre");
                miComando.Parameters.AddWithValue("", id);
                miComando.Parameters.AddWithValue("", valor);
                miConexion.MiConexion.Open();
                miComando.ExecuteNonQuery();
                miConexion.MiConexion.Close();
                miComando.Dispose();
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al editar el cierre.\n" + ex.Message);
            }
            finally { miConexion.MiConexion.Close(); }
        }*/

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