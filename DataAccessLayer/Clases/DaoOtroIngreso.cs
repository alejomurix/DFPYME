using System;
using System.Linq;
using System.Data;
using DTO.Clases;
using Npgsql;

namespace DataAccessLayer.Clases
{
    public class DaoOtroIngreso
    {
        /// <summary>
        /// Representa una conexion al servidor de Base de Datos PostgreSQL.
        /// </summary>
        private Conexion miConexion;

        /// <summary>
        /// Representa un Comando o StoredProcedure en SQL para ser ejecutado en PostgreSQL.
        /// </summary>
        private NpgsqlCommand miComando;

        /// <summary>
        /// Representa una sentencia adapter en posgres sql.
        /// </summary>
        private NpgsqlDataAdapter miAdapter;

        private DaoConsecutivo miDaoConsecutivo;

        public DaoOtroIngreso()
        {
            this.miConexion = new Conexion();
            miDaoConsecutivo = new DaoConsecutivo();
        }

        // Otro Ingreso

        public int AlmacenarIngreso(OtroIngreso ingreso)
        {
            try
            {
                CargarComando("insertar_otro_ingreso");
                miComando.Parameters.AddWithValue("numero", ingreso.Numero);
                miComando.Parameters.AddWithValue("id_beneficio", ingreso.Tipo);
                miComando.Parameters.AddWithValue("caja", ingreso.IdCaja);
                miComando.Parameters.AddWithValue("usuario", ingreso.IdUsuario);
                miComando.Parameters.AddWithValue("fecha", ingreso.Fecha);
                miComando.Parameters.AddWithValue("valor", ingreso.Valor);
                miComando.Parameters.AddWithValue("estado", ingreso.Estado);
                miConexion.MiConexion.Open();
                var id = Convert.ToInt32(miComando.ExecuteScalar());
                miConexion.MiConexion.Close();
                miComando.Dispose();
                foreach (var concepto in ingreso.Conceptos)
                {
                    concepto.IdIngreso = id;
                    AlmacenarConceptoIngreso(concepto);
                }
                foreach (var pago in ingreso.FormasPago)
                {
                    pago.IdEgreso = id;
                    IngresarFormaPago(pago);
                }
                miDaoConsecutivo.ActualizarConsecutivo("ReciboCaja");
                return id;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al guardar los datos del Ingreso.\n" + ex.Message);
            }
            finally { miConexion.MiConexion.Close(); }
        }

        public OtroIngreso Ingreso(string numero)
        {
            try
            {
                var ingreso = new OtroIngreso();
                CargarComando("otros_ingresos");
                miComando.Parameters.AddWithValue("numero", numero);
                miConexion.MiConexion.Open();
                NpgsqlDataReader miReader = miComando.ExecuteReader();
                while (miReader.Read())
                {
                    ingreso.Id = miReader.GetInt32(0);
                    ingreso.Numero = miReader.GetString(1);
                    ingreso.Relacion = miReader.GetInt32(2);
                    ingreso.IdCaja = miReader.GetInt32(3);
                    ingreso.IdUsuario = miReader.GetInt32(4);
                    ingreso.Fecha = miReader.GetDateTime(5);
                    ingreso.Valor = Convert.ToInt32(miReader.GetDouble(6));
                    if (miReader.GetString(7).Equals("OK"))
                    {
                        ingreso.Estado = true;
                    }
                    else
                    {
                        ingreso.Estado = false;
                    }
                }
                miConexion.MiConexion.Close();
                miComando.Dispose();
                return ingreso;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al consultar el Recibo de Caja.\n" + ex.Message);
            }
            finally { miConexion.MiConexion.Close(); }
        }

        public DataTable Ingresos(int rowBase, int rowMax)
        {
            try
            {
                var tabla = new DataTable();
                CargarAdpter("otros_ingresos");
                miAdapter.Fill(rowBase, rowMax, tabla);
                return tabla;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al consultar los Ingresos.\n" + ex.Message);
            }
        }

        public long GetRowsIngresos()
        {
            try
            {
                CargarComando("count_otro_ingreso");
                miConexion.MiConexion.Open();
                var id = Convert.ToInt64(miComando.ExecuteScalar());
                miConexion.MiConexion.Close();
                miComando.Dispose();
                return id;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al consultar el total de registros.\n" + ex.Message);
            }
            finally { miConexion.MiConexion.Close(); }
        }

        public DataTable Ingresos(string numero)
        {
            try
            {
                var tabla = new DataTable();
                CargarAdpter("otros_ingresos");
                miAdapter.SelectCommand.Parameters.AddWithValue("numero", numero);
                miAdapter.Fill(tabla);
                return tabla;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al consultar los Ingresos.\n" + ex.Message);
            }
        }

        public DataTable Ingresos(DateTime fecha, int rowBase, int rowMax)
        {
            try
            {
                var tabla = new DataTable();
                CargarAdpter("otros_ingresos_fecha");
                miAdapter.SelectCommand.Parameters.AddWithValue("fecha", fecha);
                miAdapter.Fill(rowBase, rowMax, tabla);
                return tabla;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al consultar los Ingresos.\n" + ex.Message);
            }
        }

        public long GetRowsIngresos(DateTime fecha)
        {
            try
            {
                CargarComando("count_otro_ingreso_fecha");
                miComando.Parameters.AddWithValue("fecha", fecha);
                miConexion.MiConexion.Open();
                var id = Convert.ToInt64(miComando.ExecuteScalar());
                miConexion.MiConexion.Close();
                miComando.Dispose();
                return id;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al consultar el total de registros.\n" + ex.Message);
            }
            finally { miConexion.MiConexion.Close(); }
        }

        public DataTable Ingresos(DateTime fecha, DateTime fecha2, int rowBase, int rowMax)
        {
            try
            {
                var tabla = new DataTable();
                CargarAdpter("otros_ingresos_periodo");
                miAdapter.SelectCommand.Parameters.AddWithValue("fecha", fecha);
                miAdapter.SelectCommand.Parameters.AddWithValue("fecha2", fecha2);
                miAdapter.Fill(rowBase, rowMax, tabla);
                return tabla;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al consultar los Ingresos.\n" + ex.Message);
            }
        }

        public long GetRowsIngresos(DateTime fecha, DateTime fecha2)
        {
            try
            {
                CargarComando("count_otro_ingreso_periodo");
                miComando.Parameters.AddWithValue("fecha", fecha);
                miComando.Parameters.AddWithValue("fecha2", fecha2);
                miConexion.MiConexion.Open();
                var id = Convert.ToInt64(miComando.ExecuteScalar());
                miConexion.MiConexion.Close();
                miComando.Dispose();
                return id;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al consultar el total de registros.\n" + ex.Message);
            }
            finally { miConexion.MiConexion.Close(); }
        }

        public void AnularIngreso(int idIngreso)
        {
            try
            {
                CargarComando("anular_otro_ingreso");
                miComando.Parameters.Add("id", idIngreso);
                miConexion.MiConexion.Open();
                miComando.ExecuteNonQuery();
                miConexion.MiConexion.Close();
                miComando.Dispose();
            }
            catch (Exception ex)
            {
                throw new Exception("" + ex.Message);
            }
            finally { miConexion.MiConexion.Close(); }
        }

        // Concepto Otro Ingreso

        public int MaxCodigo()
        {
            try
            {
                CargarComando("max_codigo_concepto_rbo_caja");
                miConexion.MiConexion.Open();
                var max = Convert.ToInt32(miComando.ExecuteScalar());
                miConexion.MiConexion.Close();
                miComando.Dispose();
                return max;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally { miConexion.MiConexion.Close(); }
        }

        public void AlmacenarConcepto(ConceptoOtroIngreso concepto)
        {
            try
            {
                CargarComando("insertar_concepto_otro_ingreso");
                miComando.Parameters.AddWithValue("codigo", concepto.Codigo);
                miComando.Parameters.AddWithValue("nombre", concepto.Nombre);
                miConexion.MiConexion.Open();
                miComando.ExecuteNonQuery();
                miConexion.MiConexion.Close();
                miComando.Dispose();
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al guardar los datos del Concepto.\n" + ex.Message);
            }
            finally { miConexion.MiConexion.Close(); }
        }

        public ConceptoOtroIngreso Concepto(int codigo)
        {
            try
            {
                CargarComando("concepto_otro_ingreso");
                miComando.Parameters.AddWithValue("codigo", codigo);
                miConexion.MiConexion.Open();
                var concepto = new ConceptoOtroIngreso();
                NpgsqlDataReader miReader = miComando.ExecuteReader();
                while (miReader.Read())
                {
                    concepto.Codigo = miReader.GetInt32(0);
                    concepto.Nombre = miReader.GetString(1);
                }
                miConexion.MiConexion.Close();
                miComando.Dispose();
                return concepto;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al guardar los datos del Ingreso.\n" + ex.Message);
            }
            finally { miConexion.MiConexion.Close(); }
        }

        public DataTable Conceptos(int codigo)
        {
            try
            {
                var tabla = new DataTable();
                CargarAdpter("concepto_otro_ingreso");
                miAdapter.SelectCommand.Parameters.AddWithValue("codigo", codigo);
                miAdapter.Fill(tabla);
                return tabla;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al consultar los Conceptos de Ingreso.\n" + ex.Message);
            }
        }

        public DataTable Conceptos(string nombre)
        {
            try
            {
                var tabla = new DataTable();
                CargarAdpter("concepto_otro_ingreso");
                miAdapter.SelectCommand.Parameters.AddWithValue("nombre", nombre);
                miAdapter.Fill(tabla);
                return tabla;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al consultar los Conceptos de Ingreso.\n" + ex.Message);
            }
        }

        public void AlmacenarConceptoIngreso(ConceptoOtroIngreso concepto)
        {
            try
            {
                CargarComando("insertar_concepto_ingreso");
                miComando.Parameters.AddWithValue("", concepto.IdIngreso);
                miComando.Parameters.AddWithValue("", concepto.Codigo);
                miComando.Parameters.AddWithValue("", concepto.Valor);
                miComando.Parameters.AddWithValue("" , concepto.Nombre);
                miConexion.MiConexion.Open();
                miComando.ExecuteNonQuery();
                miConexion.MiConexion.Close();
                miComando.Dispose();
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al guardar el Concepto del Ingreso.\n" + ex.Message);
            }
            finally { miConexion.MiConexion.Close(); }
        }

        // Concepto Ingreso (relacion)

        public DataTable ConceptosDeIngreso(int id)
        {
            try
            {
                var tabla = new DataTable();
                CargarAdpter("conceptos_de_ingreso");
                miAdapter.SelectCommand.Parameters.AddWithValue("id", id);
                miAdapter.Fill(tabla);
                return tabla;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al consultar los Conceptos de Ingreso.\n" + ex.Message);
            }
        }

        // Forma de pago de otro ingreso.
        public void IngresarFormaPago(FormaPago pago)
        {
            try
            {
                CargarComando("insertar_pago_otro_ingreso");
                miComando.Parameters.AddWithValue("idIngreso", pago.IdEgreso);
                miComando.Parameters.AddWithValue("idFormaPago", pago.IdFormaPago);
                miComando.Parameters.AddWithValue("valor", pago.Valor);
                miConexion.MiConexion.Open();
                miComando.ExecuteNonQuery();
                miConexion.MiConexion.Close();
                miComando.Dispose();
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al ingresar las formas de pago.\n" + ex.Message);
            }
            finally { miConexion.MiConexion.Close(); }
        }

        public DataTable FormasDePago(int idIngreso)
        {
            try
            {
                var tabla = new DataTable();
                CargarAdpter("pagos_otro_ingreso");
                miAdapter.SelectCommand.Parameters.AddWithValue("idingreso", idIngreso);
                miAdapter.Fill(tabla);
                return tabla;
            }
            catch (Exception ex)
            {
                throw new Exception("" + ex.Message);
            }
        }

        /// <summary>
        /// Inicializa una nueva instancia de NpgsqlCommand, tipo Stored Procedure
        /// </summary>
        /// <param name="cmd">Stored Procedure a ejecutar</param>
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
        public void CargarAdpter(string cmd)
        {
            miAdapter = new NpgsqlDataAdapter(cmd, miConexion.MiConexion);
            miAdapter.SelectCommand.CommandType = System.Data.CommandType.StoredProcedure;
        }
    }
}