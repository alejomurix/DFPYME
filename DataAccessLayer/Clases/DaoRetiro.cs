using System;
using System.Data;
using System.Linq;
using System.Text;
using DTO.Clases;
using Npgsql;

namespace DataAccessLayer.Clases
{
    public class DaoRetiro
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

        private DaoIngreso miDaoIngreso;

        public DaoRetiro()
        {
            this.miConexion = new Conexion();
            miDaoIngreso = new DaoIngreso();
        }

        public int Ingresar(Retiro retiro)
        {
            try
            {
                CargarComando("insertar_retiro");
                miComando.Parameters.AddWithValue("fecha", retiro.Fecha);
                miComando.Parameters.AddWithValue("hora", retiro.Fecha.TimeOfDay);
                miComando.Parameters.AddWithValue("caja", retiro.Caja.Id);
                miComando.Parameters.AddWithValue("turno", retiro.Turno.Id);
                miComando.Parameters.AddWithValue("usuario", retiro.Usuario.Id);
                miConexion.MiConexion.Open();
                var id = Convert.ToInt32(miComando.ExecuteScalar());
                miConexion.MiConexion.Close();
                miComando.Dispose();
                foreach (FormaPago valor in retiro.Valores)
                {
                    valor.IdEgreso = id;
                    IngresarValor(valor);
                }
                return id;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al registrar el retiro.\n" + ex.Message);
            }
            finally { miConexion.MiConexion.Close(); }
        }

        public void IngresarValor(FormaPago valor)
        {
            try
            {
                CargarComando("insertar_retiro_forma_pago");
                miComando.Parameters.AddWithValue("idretiro", valor.IdEgreso);
                miComando.Parameters.AddWithValue("idpago", valor.IdFormaPago);
                miComando.Parameters.AddWithValue("valor", valor.Valor);
                miComando.Parameters.AddWithValue("concepto", valor.NumeroFactura);
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

        public DataTable Retiros(DateTime fecha, int idcaja, int idturno)
        {
            try
            {
                var tabla = new DataTable();
                CargarAdapter("retiros");
                miAdapter.SelectCommand.Parameters.AddWithValue("fecha", fecha);
                miAdapter.SelectCommand.Parameters.AddWithValue("caja", idcaja);
                miAdapter.SelectCommand.Parameters.AddWithValue("turno", idturno);
                miAdapter.Fill(tabla);
                return tabla;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al consultar los retiros.\n" + ex.Message);
            }
        }

        public DataTable Retiros(DateTime fecha, DateTime fecha2, int idcaja, int idturno)
        {
            try
            {
                var tabla = new DataTable();
                tabla.Columns.Add(new DataColumn("id", typeof(int)));
                tabla.Columns.Add(new DataColumn("fecha", typeof(DateTime)));
                tabla.Columns.Add(new DataColumn("hora", typeof(DateTime)));
                tabla.Columns.Add(new DataColumn("idcaja", typeof(int)));
                tabla.Columns.Add(new DataColumn("nocaja", typeof(int)));
                tabla.Columns.Add(new DataColumn("idturno", typeof(int)));
                tabla.Columns.Add(new DataColumn("noturno", typeof(int)));
                tabla.Columns.Add(new DataColumn("idusuario", typeof(int)));
                tabla.Columns.Add(new DataColumn("usuario", typeof(string)));
                var tConsulta = Consulta(fecha, fecha2, idcaja, idturno);
                var tComplemento = Complemento(fecha, fecha2, idcaja, idturno);
                foreach (DataRow cRow in tConsulta.Rows)
                {
                    var row = tabla.NewRow();
                    row["id"] = cRow["id"];
                    row["fecha"] = cRow["fecha"];
                    row["hora"] = cRow["hora"];
                    row["idcaja"] = cRow["idcaja"];
                    row["nocaja"] = cRow["nocaja"];
                    row["idturno"] = cRow["idturno"];
                    row["noturno"] = cRow["noturno"];
                    row["idusuario"] = cRow["idusuario"];
                    row["usuario"] = cRow["usuario"];
                    tabla.Rows.Add(row);
                }
                foreach (DataRow comRow in tComplemento.Rows)
                {
                    var row = tabla.NewRow();
                    row["id"] = comRow["id"];
                    row["fecha"] = comRow["fecha"];
                    row["hora"] = comRow["hora"];
                    row["idcaja"] = comRow["idcaja"];
                    row["nocaja"] = comRow["nocaja"];
                    row["idturno"] = comRow["idturno"];
                    row["noturno"] = comRow["noturno"];
                    row["idusuario"] = comRow["idusuario"];
                    row["usuario"] = comRow["usuario"];
                    tabla.Rows.Add(row);
                }
                return tabla;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al consultar los retiros.\n" + ex.Message);
            }
        }

        private DataTable Consulta(DateTime fecha, DateTime fecha2, int idcaja, int idturno)
        {
            try
            {
                var tabla = new DataTable();
                CargarAdapter("retiros");
                miAdapter.SelectCommand.Parameters.AddWithValue("fecha", fecha);
                miAdapter.SelectCommand.Parameters.AddWithValue("fecha2", fecha2);
                miAdapter.SelectCommand.Parameters.AddWithValue("hora", fecha.TimeOfDay);
                miAdapter.SelectCommand.Parameters.AddWithValue("caja", idcaja);
                miAdapter.SelectCommand.Parameters.AddWithValue("turno", idturno);
                miAdapter.Fill(tabla);
                return tabla;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al consultar los retiros.\n" + ex.Message);
            }
        }

        private DataTable Complemento(DateTime fecha, DateTime fecha2, int idcaja, int idturno)
        {
            try
            {
                var tabla = new DataTable();
                CargarAdapter("retiros_complemento");
                miAdapter.SelectCommand.Parameters.AddWithValue("fecha", fecha);
                miAdapter.SelectCommand.Parameters.AddWithValue("fecha2", fecha2);
                miAdapter.SelectCommand.Parameters.AddWithValue("hora2", fecha2.TimeOfDay);
                miAdapter.SelectCommand.Parameters.AddWithValue("caja", idcaja);
                miAdapter.SelectCommand.Parameters.AddWithValue("turno", idturno);
                miAdapter.Fill(tabla);
                return tabla;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al consultar los retiros.\n" + ex.Message);
            }
        }

        public DataTable RetirosHoras(DateTime fecha, DateTime fecha2, int idcaja, int idturno)
        {
            try
            {
                var tabla = new DataTable();
                CargarAdapter("retiros_horas");
                miAdapter.SelectCommand.Parameters.AddWithValue("", idcaja);
                miAdapter.SelectCommand.Parameters.AddWithValue("", idturno);
                miAdapter.SelectCommand.Parameters.AddWithValue("", fecha);
                miAdapter.SelectCommand.Parameters.AddWithValue("", fecha2);
                miAdapter.Fill(tabla);
                return tabla;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al consultar los retiros.\n" + ex.Message);
            }
        }

        public DataTable PagosRetiro(int idRetiro)
        {
            try
            {
                var tabla = new DataTable();
                CargarAdapter("pagos_retiro");
                miAdapter.SelectCommand.Parameters.AddWithValue("idretiro", idRetiro);
                miAdapter.Fill(tabla);
                return tabla;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al consultar los pagos de los retiros.\n" + ex.Message);
            }
        }

        public DataTable Retiros(DateTime fecha, int idcaja)  // print_retiros
        {
            try
            {
                var tabla = new DataTable();
                CargarAdapter("retiros");
                miAdapter.SelectCommand.Parameters.AddWithValue("fecha", fecha);
                miAdapter.SelectCommand.Parameters.AddWithValue("caja", idcaja);
                miAdapter.Fill(tabla);
                return tabla;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al consultar los retiros.\n" + ex.Message);
            }
        }

        public DataTable PrintRetiros(DateTime fecha, int idCaja, int idTurno)
        {
            try
            {
                var tabla = new DataTable();
                CargarAdapter("print_retiros");
                miAdapter.SelectCommand.Parameters.AddWithValue("fecha", fecha);
                miAdapter.SelectCommand.Parameters.AddWithValue("caja", idCaja);
                miAdapter.SelectCommand.Parameters.AddWithValue("turno", idTurno);
                miAdapter.Fill(tabla);
                return tabla;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al consultar los retiros.\n" + ex.Message);
            }
        }

        public DataTable PrintRetiros(DateTime fecha, DateTime fecha2, int idCaja, int idTurno)
        {
            try
            {
                var tabla = new DataTable();
                tabla.Columns.Add(new DataColumn("id", typeof(int)));
                tabla.Columns.Add(new DataColumn("fecha", typeof(DateTime)));
                tabla.Columns.Add(new DataColumn("hora", typeof(DateTime)));
                tabla.Columns.Add(new DataColumn("idcaja", typeof(int)));
                tabla.Columns.Add(new DataColumn("idturno", typeof(int)));
                tabla.Columns.Add(new DataColumn("concepto", typeof(string)));
                tabla.Columns.Add(new DataColumn("idpago", typeof(int)));
                tabla.Columns.Add(new DataColumn("pago", typeof(string)));
                tabla.Columns.Add(new DataColumn("valor", typeof(int)));
                var tConsulta = PrintRetirosConsulta(fecha, fecha2, idCaja, idTurno);
                var tComplemento = PrintRetirosConsultaComplemento(fecha, fecha2, idCaja, idTurno);
                foreach (DataRow cRow in tConsulta.Rows)
                {
                    var row = tabla.NewRow();
                    row["id"] = cRow["id"];
                    row["fecha"] = cRow["fecha"];
                    row["hora"] = cRow["hora"];
                    row["idcaja"] = cRow["idcaja"];
                    row["idturno"] = cRow["idturno"];
                    row["concepto"] = cRow["concepto"];
                    row["idpago"] = cRow["idpago"];
                    row["pago"] = cRow["pago"];
                    row["valor"] = cRow["valor"];
                    tabla.Rows.Add(row);
                }
                foreach (DataRow cRow in tComplemento.Rows)
                {
                    var row = tabla.NewRow();
                    row["id"] = cRow["id"];
                    row["fecha"] = cRow["fecha"];
                    row["hora"] = cRow["hora"];
                    row["idcaja"] = cRow["idcaja"];
                    row["idturno"] = cRow["idturno"];
                    row["concepto"] = cRow["concepto"];
                    row["idpago"] = cRow["idpago"];
                    row["pago"] = cRow["pago"];
                    row["valor"] = cRow["valor"];
                    tabla.Rows.Add(row);
                }
                return tabla;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al consultar los retiros.\n" + ex.Message);
            }
        }

        private DataTable PrintRetirosConsulta(DateTime fecha, DateTime fecha2, int idCaja, int idTurno)
        {
            try
            {
                var tabla = new DataTable();
                CargarAdapter("print_retiros");
                miAdapter.SelectCommand.Parameters.AddWithValue("fecha", fecha);
                miAdapter.SelectCommand.Parameters.AddWithValue("fecha2", fecha2);
                miAdapter.SelectCommand.Parameters.AddWithValue("hora", fecha.TimeOfDay);
                miAdapter.SelectCommand.Parameters.AddWithValue("caja", idCaja);
                miAdapter.SelectCommand.Parameters.AddWithValue("turno", idTurno);
                miAdapter.Fill(tabla);
                return tabla;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al consultar los retiros.\n" + ex.Message);
            }
        }

        private DataTable PrintRetirosConsultaComplemento(DateTime fecha, DateTime fecha2, int idCaja, int idTurno)
        {
            try
            {
                var tabla = new DataTable();
                CargarAdapter("print_retiros_complemento");
                miAdapter.SelectCommand.Parameters.AddWithValue("fecha", fecha);
                miAdapter.SelectCommand.Parameters.AddWithValue("fecha2", fecha2);
                miAdapter.SelectCommand.Parameters.AddWithValue("hora", fecha2.TimeOfDay);
                miAdapter.SelectCommand.Parameters.AddWithValue("caja", idCaja);
                miAdapter.SelectCommand.Parameters.AddWithValue("turno", idTurno);
                miAdapter.Fill(tabla);
                return tabla;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al consultar los retiros.\n" + ex.Message);
            }
        }

        public DataTable PrintRetirosHoras(DateTime fecha, DateTime fecha2, int idCaja, int idTurno)
        {
            try
            {
                var tabla = new DataTable();
                CargarAdapter("print_retiros_horas");
                miAdapter.SelectCommand.Parameters.AddWithValue("", idCaja);
                miAdapter.SelectCommand.Parameters.AddWithValue("", idTurno);
                miAdapter.SelectCommand.Parameters.AddWithValue("", fecha);
                miAdapter.SelectCommand.Parameters.AddWithValue("", fecha2);
                miAdapter.Fill(tabla);
                return tabla;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al consultar los retiros.\n" + ex.Message);
            }
        }

        public void EditarRetiro(int id, int valor)
        {
            try
            {
                CargarComando("editar_valor_retiro");
                miComando.Parameters.AddWithValue("", id);
                miComando.Parameters.AddWithValue("", valor);
                miConexion.MiConexion.Open();
                miComando.ExecuteNonQuery();
                miConexion.MiConexion.Close();
                miComando.Dispose();
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al editar el retiro.\n" + ex.Message);
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