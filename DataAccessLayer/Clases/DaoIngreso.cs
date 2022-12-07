using System;
using System.Linq;
using System.Data;
using DTO.Clases;
using Npgsql;
using System.Collections.Generic;

namespace DataAccessLayer.Clases
{
    public class DaoIngreso
    {
        /// <summary>
        /// Representa una conexion al servidor de Base de Datos PostgreSQL.
        /// </summary>
        private Conexion miConexion;

        private DaoConsecutivo miDaoConsecutivo;

        /// <summary>
        /// Representa un Comando o StoredProcedure en SQL para ser ejecutado en PostgreSQL.
        /// </summary>
        private NpgsqlCommand miComando;

        /// <summary>
        /// Representa una sentencia adapter en posgres sql.
        /// </summary>
        private NpgsqlDataAdapter miAdapter;

        /// <summary>
        /// Inicializa una nueva instancia de la clase DaoIngreso.
        /// </summary>
        public DaoIngreso()
        {
            this.miConexion = new Conexion();
            miDaoConsecutivo = new DaoConsecutivo();
        }

        public int Ingresar(Ingreso ingreso, bool multiple )
        {
            try
            {
                CargarComando("insertar_ingreso");
                miComando.Parameters.AddWithValue("numero", ingreso.Numero);
                miComando.Parameters.AddWithValue("concepto", ingreso.Concepto);
                miComando.Parameters.AddWithValue("tipo", ingreso.Tipo);
                miComando.Parameters.AddWithValue("relacion", ingreso.Relacion);
                miComando.Parameters.AddWithValue("fecha", ingreso.Fecha);
                miComando.Parameters.AddWithValue("valor", ingreso.Valor);
                miComando.Parameters.AddWithValue("estado", ingreso.Estado);
                miComando.Parameters.AddWithValue("saldo", ingreso.Saldo);
                miComando.Parameters.AddWithValue("cliente", ingreso.NitCliente);
                miComando.Parameters.AddWithValue("idcaja", ingreso.IdCaja);
                miComando.Parameters.AddWithValue("idusuario", ingreso.IdUsuario);
                miConexion.MiConexion.Open();
                var id = Convert.ToInt32(miComando.ExecuteScalar());
                miConexion.MiConexion.Close();
                miComando.Dispose();
                if (!multiple)
                {
                    miDaoConsecutivo.ActualizarConsecutivo("Ingreso");
                }
                foreach (FormaPago pago in ingreso.FormasPago)
                {
                    pago.IdEgreso = id;
                    IngresarFormasPago(pago);
                }
                return id;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al guardar los datos de Ingreso.\n" + ex.Message);
            }
            finally { miConexion.MiConexion.Close(); }
        }

        // Ingreso de Remision de Venta.
        public void IngresoDeRemision(Ingreso ingreso)
        {
            try
            {
                CargarComando("insertar_ingreso_remision");
                miComando.Parameters.AddWithValue("idcaja", ingreso.IdCaja);
                miComando.Parameters.AddWithValue("idusuario", ingreso.IdUsuario);
                miComando.Parameters.AddWithValue("nitcliente", ingreso.NitCliente);
                miComando.Parameters.AddWithValue("numero", ingreso.Numero);
                miComando.Parameters.AddWithValue("concepto", ingreso.Concepto);
                miComando.Parameters.AddWithValue("fecha", ingreso.Fecha);
                miComando.Parameters.AddWithValue("valor", ingreso.Valor);
                miComando.Parameters.AddWithValue("estado", ingreso.Estado);
                miConexion.MiConexion.Open();
                var id = Convert.ToInt32(miComando.ExecuteScalar());
                miConexion.MiConexion.Close();
                miComando.Dispose();
                miDaoConsecutivo.ActualizarConsecutivo("IngresoRemision");
                foreach (FormaPago pago in ingreso.FormasPago)
                {
                    pago.IdEgreso = id;
                    IngresarFormaPagoRemision(pago);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al guardar los datos de Ingreso.\n" + ex.Message);
            }
            finally { miConexion.MiConexion.Close(); }
        }

        public void IngresarFormaPagoRemision(FormaPago pago)
        {
            try
            {
                CargarComando("insertar_ingreso_remision_forma_pago");
                miComando.Parameters.AddWithValue("idingreso", pago.IdEgreso);
                miComando.Parameters.AddWithValue("idformapago", pago.IdFormaPago);
                miComando.Parameters.AddWithValue("valor", pago.Valor);
                miConexion.MiConexion.Open();
                miComando.ExecuteNonQuery();
                miConexion.MiConexion.Close();
                miComando.Dispose();
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al guardar las Formas de Pago del Ingreso.\n" + ex.Message);
            }
            finally { miConexion.MiConexion.Close(); }
        }

        public DataTable IngresosRemision(string numero)
        {
            try
            {
                var tabla = new DataTable();
                CargarAdpter("ingresos_remision");
                miAdapter.SelectCommand.Parameters.AddWithValue("numero", numero);
                miAdapter.Fill(tabla);
                return tabla;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al consultar los Ingresos de Remisión.\n" + ex.Message);
            }
        }

        public DataTable FormasPagoIngresoRemision(int idIngreso)
        {
            try
            {
                var tabla = new DataTable();
                CargarAdpter("formas_pago_ingreso_remision");
                miAdapter.SelectCommand.Parameters.AddWithValue("idingreso", idIngreso);
                miAdapter.Fill(tabla);
                return tabla;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al consultar las formas de pago de Ingresos de Remisión.\n" + ex.Message);
            }
        }

        public DataTable IngresosRemisionHoras(int idEstado, int idcaja, DateTime fecha, DateTime fecha2)
        {
            var tabla = new DataTable();
            try
            {
                CargarAdpter("ingresos_remision_horas");
                miAdapter.SelectCommand.Parameters.AddWithValue("", idEstado);
                miAdapter.SelectCommand.Parameters.AddWithValue("", idcaja);
                miAdapter.SelectCommand.Parameters.AddWithValue("", fecha);
                miAdapter.SelectCommand.Parameters.AddWithValue("", fecha2);
                miAdapter.Fill(tabla);
                return tabla;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al consultar los ingresos.\n" + ex.Message);
            }
        }

        //------------

        public long IngresarRecibo(Ingreso ingreso)  // Que es?
        {
            try
            {
                CargarComando("insertar_recibo_ingreso");
                //miComando.Parameters.AddWithValue("numero", ingreso.Numero);
                miComando.Parameters.AddWithValue("concepto", ingreso.Concepto);
                miComando.Parameters.AddWithValue("tipo", ingreso.Tipo);
                miComando.Parameters.AddWithValue("relacion", ingreso.Relacion);
                miComando.Parameters.AddWithValue("fecha", ingreso.Fecha);
                miComando.Parameters.AddWithValue("valor", ingreso.Valor);
                miComando.Parameters.AddWithValue("estado", ingreso.Estado);
                miConexion.MiConexion.Open();
                var id = Convert.ToInt64(miComando.ExecuteScalar());
                //miComando.ExecuteNonQuery();
                miConexion.MiConexion.Close();
                miComando.Dispose();
                return id;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al guardar los datos del Recibo de Ingreso.\n" + ex.Message);
            }
            finally { miConexion.MiConexion.Close(); }
        }

        public DataTable Ingresos(int rowIndex, int rowMax)
        {
            var tabla = new DataTable();
            try
            {
                CargarAdpter("ingresos_");
                miAdapter.Fill(rowIndex, rowMax, tabla);
                return tabla;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al consultar los ingresos.\n" + ex.Message);
            }
        }

        public long GetRowsIngresos()
        {
            try
            {
                CargarComando("count_ingresos");
                miConexion.MiConexion.Open();
                var rows = Convert.ToInt64(miComando.ExecuteScalar());
                miConexion.MiConexion.Close();
                miComando.Dispose();
                return rows;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al cargar el total de registros.\n" + ex.Message);
            }
            finally { miConexion.MiConexion.Close(); }
        }

        public DataTable Ingresos(string numero)
        {
            var tabla = new DataTable();
            try
            {
                CargarAdpter("ingresos_");
                miAdapter.SelectCommand.Parameters.AddWithValue("numero", numero);
                miAdapter.Fill(tabla);
                return tabla;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al consultar los ingresos.\n" + ex.Message);
            }
        }

        public DataTable IngresosMultiple(string numero)
        {
            var tabla = new DataTable();
            try
            {
                CargarAdpter("ingresos_multiple");
                miAdapter.SelectCommand.Parameters.AddWithValue("numero", numero);
                miAdapter.Fill(tabla);
                return tabla;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al consultar los ingresos.\n" + ex.Message);
            }
        }

        public DataTable Ingresos(DateTime fecha)
        {
            var tabla = new DataTable();
            try
            {
                CargarAdpter("ingresos_fecha_");
                miAdapter.SelectCommand.Parameters.AddWithValue("numero", fecha);
                miAdapter.Fill(tabla);
                return tabla;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al consultar los ingresos.\n" + ex.Message);
            }
        }

        public DataTable Ingresos(DateTime fecha, DateTime fecha2)
        {
            var tabla = new DataTable();
            try
            {
                CargarAdpter("ingresos_");
                miAdapter.SelectCommand.Parameters.AddWithValue("numero", fecha);
                miAdapter.SelectCommand.Parameters.AddWithValue("numero2", fecha2);
                miAdapter.Fill(tabla);
                return tabla;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al consultar los ingresos.\n" + ex.Message);
            }
        }

        public DataTable Ingresos(string nitCliente, DateTime fecha, DateTime fecha2)
        {
            var tabla = new DataTable();
            try
            {
                CargarAdpter("ingresos_fecha_cliente");
                miAdapter.SelectCommand.Parameters.AddWithValue("", nitCliente);
                miAdapter.SelectCommand.Parameters.AddWithValue("", fecha);
                miAdapter.SelectCommand.Parameters.AddWithValue("", fecha2);
                miAdapter.Fill(tabla);
                return tabla;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al consultar los ingresos.\n" + ex.Message);
            }
        }

        public DataTable Ingresos(string numero, int tipo)
        {
            var tabla = new DataTable();
            try
            {
                CargarAdpter("ingresos");
                miAdapter.SelectCommand.Parameters.AddWithValue("numero", numero);
                miAdapter.SelectCommand.Parameters.AddWithValue("tipo", tipo);
                miAdapter.Fill(tabla);
                return tabla;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al consultar los ingresos.\n" + ex.Message);
            }
        }

        public DataTable ClienteConSaldo(string numero, int tipo)
        {
            var tabla = new DataTable();
            try
            {
                var ingresos = Ingresos(numero, tipo);
                if (!ingresos.Rows.Count.Equals(0))
                {
                    var query = (from data in ingresos.AsEnumerable()
                                 select data).First();
                    switch (tipo)
                    {
                        case 1:
                            {
                                CargarAdpter("cliente_con_saldo");
                                break;
                            }
                        case 2:
                            {
                                CargarAdpter("cliente_con_abono_factura");
                                break;
                            }
                        case 3:
                            {
                                CargarAdpter("cliente_con_abono_remision");
                                break;
                            }
                    }
                    miAdapter.SelectCommand.Parameters.AddWithValue("idRelacion", Convert.ToInt32(query["id_relacion"]));
                    miAdapter.Fill(tabla);
                }
                return tabla;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al consultar el cliente.\n" + ex.Message);
            }
        }

        public DataTable PagosAnticipoCliente(string numero, int tipo)
        {
            var tabla = new DataTable();
            try
            {
                var ingresos = Ingresos(numero, tipo);
                if (!ingresos.Rows.Count.Equals(0))
                {
                    var query = (from data in ingresos.AsEnumerable()
                                 select data).Single();
                    CargarAdpter("pagos_saldo_cliente_ingreso");
                    miAdapter.SelectCommand.Parameters.AddWithValue("idRelacion", Convert.ToInt32(query["id_relacion"]));
                    miAdapter.Fill(tabla);
                }
                return tabla;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al consultar los pagos.\n" + ex.Message);
            }
        }

        public DataTable AbonosVenta(string numero, int tipo)
        {
            var tabla = new DataTable();
            tabla.TableName = "Formas";
            tabla.Columns.Add(new DataColumn("IdForma", typeof(int)));
            tabla.Columns.Add(new DataColumn("Nombre", typeof(string)));
            tabla.Columns.Add(new DataColumn("Valor", typeof(int)));
            try
            {
                var ingresos = Ingresos(numero, tipo);
                foreach (DataRow iRow in ingresos.Rows)
                {
                    var temp = new DataTable();
                    if (tipo.Equals(2))
                    {
                        CargarAdpter("factura_forma_pago_ingreso");
                    }
                    else
                    {
                        CargarAdpter("remision_forma_pago_ingreso");
                    }
                    var i = Convert.ToInt32(iRow["id_relacion"]);
                    miAdapter.SelectCommand.Parameters.AddWithValue("id", Convert.ToInt32(iRow["id_relacion"]));
                    miAdapter.Fill(temp);
                    foreach (DataRow pRow in temp.Rows)
                    {
                        var row = tabla.NewRow();
                        row["IdForma"] = pRow["idforma_pago"];
                        //row["Nombre"] = pRow["nombreforma_pago"];
                        if (tipo.Equals(2))
                        {
                            row["Valor"] = pRow["valorfactura_forma_pago"];
                        }
                        else
                        {
                            row["Valor"] = pRow["valor"];
                        }
                        tabla.Rows.Add(row);
                    }
                }
                return tabla;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al consultar los pagos.\n" + ex.Message);
            }
        }

        // CONSULTA INGRESOS A CAJA
        public DataTable Ingresos(DateTime fecha, int idcaja, int idturno)
        {
            var tabla = new DataTable();
            try
            {
                CargarAdpter("ingresos");
                miAdapter.SelectCommand.Parameters.AddWithValue("fecha", fecha);
                miAdapter.SelectCommand.Parameters.AddWithValue("idcaja", idcaja);
                miAdapter.SelectCommand.Parameters.AddWithValue("idturno", idturno);
                miAdapter.Fill(tabla);
                return tabla;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al consultar los ingresos.\n" + ex.Message);
            }
        }

        public DataTable Ingresos(DateTime fecha, DateTime fecha2, int idcaja, int idturno)
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
            tabla.Columns.Add(new DataColumn("idpago", typeof(int)));
            tabla.Columns.Add(new DataColumn("pago", typeof(string)));
            tabla.Columns.Add(new DataColumn("valor", typeof(int)));
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
                row["idpago"] = cRow["idpago"];
                row["pago"] = cRow["pago"];
                row["valor"] = cRow["valor"];
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
                row["idpago"] = comRow["idpago"];
                row["pago"] = comRow["pago"];
                row["valor"] = comRow["valor"];
                tabla.Rows.Add(row);
            }
            return tabla;
            /*var tabla = new DataTable();
            try
            {
                CargarAdpter("ingresos");
                miAdapter.SelectCommand.Parameters.AddWithValue("fecha", fecha);
                miAdapter.SelectCommand.Parameters.AddWithValue("fecha2", fecha2);
                miAdapter.SelectCommand.Parameters.AddWithValue("hora", fecha.TimeOfDay);
                miAdapter.SelectCommand.Parameters.AddWithValue("hora2", fecha2.TimeOfDay);
                miAdapter.SelectCommand.Parameters.AddWithValue("idcaja", idcaja);
                miAdapter.SelectCommand.Parameters.AddWithValue("idturno", idturno);
                miAdapter.Fill(tabla);
                return tabla;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al consultar los ingresos.\n" + ex.Message);
            }*/
            return null;
        }

        private DataTable Consulta(DateTime fecha, DateTime fecha2, int idcaja, int idturno)
        {
            var tabla = new DataTable();
            try
            {
                CargarAdpter("ingresos");
                miAdapter.SelectCommand.Parameters.AddWithValue("fecha", fecha);
                miAdapter.SelectCommand.Parameters.AddWithValue("fecha2", fecha2);
                miAdapter.SelectCommand.Parameters.AddWithValue("hora", fecha.TimeOfDay);
                miAdapter.SelectCommand.Parameters.AddWithValue("idcaja", idcaja);
                miAdapter.SelectCommand.Parameters.AddWithValue("idturno", idturno);
                miAdapter.Fill(tabla);
                return tabla;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al consultar los ingresos.\n" + ex.Message);
            }
        }

        private DataTable Complemento(DateTime fecha, DateTime fecha2, int idcaja, int idturno)
        {
            var tabla = new DataTable();
            try
            {
                CargarAdpter("ingresos_complemento");
                miAdapter.SelectCommand.Parameters.AddWithValue("fecha", fecha);
                miAdapter.SelectCommand.Parameters.AddWithValue("fecha2", fecha2);
                miAdapter.SelectCommand.Parameters.AddWithValue("hora2", fecha2.TimeOfDay);
                miAdapter.SelectCommand.Parameters.AddWithValue("idcaja", idcaja);
                miAdapter.SelectCommand.Parameters.AddWithValue("idturno", idturno);
                miAdapter.Fill(tabla);
                return tabla;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al consultar los ingresos.\n" + ex.Message);
            }
        }

        public DataTable IngresosHoras(DateTime fecha, DateTime fecha2, int idcaja, int idturno)
        {
            var tabla = new DataTable();
            try
            {
                CargarAdpter("ingresos_horas");
                miAdapter.SelectCommand.Parameters.AddWithValue("", idcaja);
                miAdapter.SelectCommand.Parameters.AddWithValue("", idturno);
                miAdapter.SelectCommand.Parameters.AddWithValue("", fecha);
                miAdapter.SelectCommand.Parameters.AddWithValue("", fecha2);   
                miAdapter.Fill(tabla);
                return tabla;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al consultar los ingresos.\n" + ex.Message);
            }
        }

        public DataTable PrintIngresos(DateTime fecha, int idcaja, int idTurno)
        {
            var tabla = new DataTable();
            try
            {
                CargarAdpter("print_ingresos");
                miAdapter.SelectCommand.Parameters.AddWithValue("fecha", fecha);
                miAdapter.SelectCommand.Parameters.AddWithValue("idcaja", idcaja);
                miAdapter.SelectCommand.Parameters.AddWithValue("idTurno", idTurno);
                miAdapter.Fill(tabla);
                return tabla;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al consultar los ingresos.\n" + ex.Message);
            }
        }

        public DataTable PrintIngresos(DateTime fecha, DateTime fecha2, int idcaja, int idturno)
        {
            var tabla = new DataTable();
            tabla.Columns.Add(new DataColumn("fecha", typeof(DateTime)));
            tabla.Columns.Add(new DataColumn("hora", typeof(DateTime)));
            tabla.Columns.Add(new DataColumn("idcaja", typeof(int)));
            tabla.Columns.Add(new DataColumn("idturno", typeof(int)));
            tabla.Columns.Add(new DataColumn("idpago", typeof(int)));
            tabla.Columns.Add(new DataColumn("pago", typeof(string)));
            tabla.Columns.Add(new DataColumn("valor", typeof(int)));
            var tConsulta = ConsultaPrintIngresos(fecha, fecha2, idcaja, idturno);
            var tComplemento = ConsultaPrintIngresosComplemento(fecha, fecha2, idcaja, idturno);
            foreach (DataRow cRow in tConsulta.Rows)
            {
                var row = tabla.NewRow();
                row["fecha"] = cRow["fecha"];
                row["hora"] = cRow["hora"];
                row["idcaja"] = cRow["idcaja"];
                row["idturno"] = cRow["idturno"];
                row["idpago"] = cRow["idpago"];
                row["pago"] = cRow["pago"];
                row["valor"] = cRow["valor"];
                tabla.Rows.Add(row);
            }
            foreach (DataRow cRow in tComplemento.Rows)
            {
                var row = tabla.NewRow();
                row["fecha"] = cRow["fecha"];
                row["hora"] = cRow["hora"];
                row["idcaja"] = cRow["idcaja"];
                row["idturno"] = cRow["idturno"];
                row["idpago"] = cRow["idpago"];
                row["pago"] = cRow["pago"];
                row["valor"] = cRow["valor"];
                tabla.Rows.Add(row);
            }
            return tabla;
        }

        private DataTable ConsultaPrintIngresos(DateTime fecha, DateTime fecha2, int idcaja, int idturno)
        {
            var tabla = new DataTable();
            try
            {
                CargarAdpter("print_ingresos");
                miAdapter.SelectCommand.Parameters.AddWithValue("fecha", fecha);
                miAdapter.SelectCommand.Parameters.AddWithValue("fecha2", fecha2);
                miAdapter.SelectCommand.Parameters.AddWithValue("hora", fecha.TimeOfDay);
                miAdapter.SelectCommand.Parameters.AddWithValue("idcaja", idcaja);
                miAdapter.SelectCommand.Parameters.AddWithValue("idturno", idturno);
                miAdapter.Fill(tabla);
                return tabla;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al consultar los ingresos.\n" + ex.Message);
            }
        }

        private DataTable ConsultaPrintIngresosComplemento(DateTime fecha, DateTime fecha2, int idcaja, int idturno)
        {
            var tabla = new DataTable();
            try
            {
                CargarAdpter("print_ingresos_complemento");
                miAdapter.SelectCommand.Parameters.AddWithValue("fecha", fecha);
                miAdapter.SelectCommand.Parameters.AddWithValue("fecha2", fecha2);
                miAdapter.SelectCommand.Parameters.AddWithValue("hora", fecha2.TimeOfDay);
                miAdapter.SelectCommand.Parameters.AddWithValue("idcaja", idcaja);
                miAdapter.SelectCommand.Parameters.AddWithValue("idturno", idturno);
                miAdapter.Fill(tabla);
                return tabla;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al consultar los ingresos.\n" + ex.Message);
            }
        }

        public DataTable PrintIngresosHoras(DateTime fecha, DateTime fecha2, int idcaja, int idturno)
        {
            var tabla = new DataTable();
            try
            {
                CargarAdpter("print_ingresos_horas");
                miAdapter.SelectCommand.Parameters.AddWithValue("", idcaja);
                miAdapter.SelectCommand.Parameters.AddWithValue("", idturno);
                miAdapter.SelectCommand.Parameters.AddWithValue("", fecha);
                miAdapter.SelectCommand.Parameters.AddWithValue("", fecha2);
                miAdapter.Fill(tabla);
                return tabla;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al consultar los ingresos.\n" + ex.Message);
            }
        }

        // ACUMULADO DE INGRESOS
        public void IngresarAcumulado(int idCaja, DateTime fecha, int valor)
        {
            try
            {
                var acumulado = AcumuladoIngresos(idCaja, fecha);
                if (acumulado > 0)
                {
                    //editar_acumulado_ingresos
                    CargarComando("editar_acumulado_ingresos");
                    miComando.Parameters.AddWithValue("idCaja", idCaja);
                    miComando.Parameters.AddWithValue("fecha", fecha);
                    miComando.Parameters.AddWithValue("valor", valor + acumulado);
                    miConexion.MiConexion.Open();
                    miComando.ExecuteNonQuery();
                    miConexion.MiConexion.Close();
                    miComando.Dispose();
                }
                else // Acumulado con valor cero. No hay conslta
                {
                    CargarComando("insertar_acomulado_ingresos");
                    miComando.Parameters.AddWithValue("idCaja", idCaja);
                    miComando.Parameters.AddWithValue("fecha", fecha);
                    miComando.Parameters.AddWithValue("valor", valor);
                    miConexion.MiConexion.Open();
                    miComando.ExecuteNonQuery();
                    miConexion.MiConexion.Close();
                    miComando.Dispose();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrio un error al ingresar el acumulado de ingresos." + ex.Message);
            }
            finally { miConexion.MiConexion.Close(); }
        }

        public int AcumuladoIngresos(int idCaja, DateTime fecha)
        {
            try
            {
                var tabla = new DataTable();
                CargarAdpter("acomulado_ingresos");
                miAdapter.SelectCommand.Parameters.AddWithValue("idcaja", idCaja);
                miAdapter.SelectCommand.Parameters.AddWithValue("fecha", fecha);
                miAdapter.Fill(tabla);
                return tabla.AsEnumerable().Sum(s => s.Field<int>("valor"));
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al consultar el acumulado de ingresos." + ex.Message);
            }
        }

        public long SumaAcumuladoIngresos(int idCaja, DateTime fecha)
        {
            try
            {
                var fechaTmp = fecha;
                int days = 0;
                if (!fecha.Day.Equals(1)) // fecha diferente a 1
                {
                    days = fecha.Day - 1;
                    fechaTmp = fechaTmp.AddDays((days * -1));
                }
                CargarComando("suma_acumulado_ingresos");
                miComando.Parameters.AddWithValue("idcaja", idCaja);
                miComando.Parameters.AddWithValue("fecha1", fechaTmp);
                miComando.Parameters.AddWithValue("fecha", fecha);
                miConexion.MiConexion.Open();
                long sum = Convert.ToInt64(miComando.ExecuteScalar());
                miConexion.MiConexion.Close();
                miComando.Dispose();
                return sum;
            }
            catch (InvalidCastException)
            {
                return 0;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al consultar el Acumulado de Ingresos.\n" + ex.Message);
            }
            finally { miConexion.MiConexion.Close(); }
        }

        public void DisminuirAcumuladoIngresos(int idCaja, DateTime fecha, int valor)
        {
            try
            {
                var acumulado = AcumuladoIngresos(idCaja, fecha);

            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al disminuir el acumulado de ingresos.\n" + ex.Message);
            }
            finally { miConexion.MiConexion.Close(); }
        }

        // Formas de pago de Ingreso.
        public void IngresarFormasPago(FormaPago pago)
        {
            try
            {
                CargarComando("insertar_ingreso_forma_pago");
                miComando.Parameters.AddWithValue("idingreso", pago.IdEgreso);
                miComando.Parameters.AddWithValue("idpago", pago.IdFormaPago);
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

        public DataTable FormasPagoIngresoVenta(int idIngreso)
        {
            try
            {
                var tabla = new DataTable();
                CargarAdpter("formas_pago_ingreso_venta");
                miAdapter.SelectCommand.Parameters.AddWithValue("idingreso", idIngreso);
                miAdapter.Fill(tabla);
                return tabla;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al consultar las Formas de pago del Ingreso.\n" + ex.Message);
            }
        }

        /// Ingresos por factura electronica
        public double TotalPayment(int idCaja, DateTime beginDate, DateTime endDate)
        {
            try
            {
                
                string sql = @"SELECT 
                                case when sum(valor) is null then 0 
                                else sum(valor) end  
                                FROM documento_electronico_payment WHERE  
                                id_caja = @caja AND 
                                fecha + hora BETWEEN @beginDate AND @endDate;";
                CargarComandoText(sql);
                miComando.Parameters.AddWithValue("caja", idCaja);
                miComando.Parameters.AddWithValue("beginDate", beginDate);
                miComando.Parameters.AddWithValue("endDate", endDate);
                miConexion.MiConexion.Open();
                double total = Convert.ToDouble(miComando.ExecuteScalar());
                miConexion.MiConexion.Close();
                miComando.Dispose();
                return total;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally { miConexion.MiConexion.Close(); }
        }

        public List<FormaPago> Payments(int idCaja, DateTime beginDate, DateTime endDate)
        {
            try
            {
                List<FormaPago> payments = new List<FormaPago>();
                string sql = @"select 
                                  code_payment,
                                  case when sum(valor) is null then 0 
                                  else sum(valor) end as valor 
                                from
                                  documento_electronico_payment 
                                where 
                                  id_caja = @caja and 
                                  fecha + hora BETWEEN 
                                    @beginDate AND @endDate 
                                group by 
                                  code_payment;";
                CargarComandoText(sql);
                miComando.Parameters.AddWithValue("caja", idCaja);
                miComando.Parameters.AddWithValue("beginDate", beginDate);
                miComando.Parameters.AddWithValue("endDate", endDate);
                miConexion.MiConexion.Open();
                NpgsqlDataReader reader = miComando.ExecuteReader();
                while (reader.Read())
                {
                    payments.Add(new FormaPago 
                    {
                        NombreFormaPago = reader.GetString(0),
                        Valor = reader.GetDouble(1)
                    });
                }
                miConexion.MiConexion.Close();
                miComando.Dispose();
                return payments;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally { miConexion.MiConexion.Close(); }
        }

        // Metodo a parte.
        public void ActualizarNit()
        {
            try
            {
                var tablaIngresos = new DataTable();
                string sql = "SELECT ingreso.id, ingreso.tipo, ingreso.id_relacion FROM ingreso ORDER BY ingreso.id ASC;";
                miAdapter = new NpgsqlDataAdapter(sql, miConexion.MiConexion);
                miAdapter.SelectCommand.CommandType = CommandType.Text;
                miAdapter.Fill(tablaIngresos);
                miComando = new NpgsqlCommand();
                miComando.Connection = miConexion.MiConexion;
                miComando.CommandType = CommandType.Text;
                foreach (DataRow iRow in tablaIngresos.Rows)
                {
                    switch (Convert.ToInt32(iRow["tipo"]))
                    {
                        case 1:
                            {
                                sql = "SELECT saldo_cliente.nitcliente FROM saldo_cliente WHERE saldo_cliente.id = " + Convert.ToInt32(iRow["id_relacion"]) + ";";
                                break;
                            }
                        case 2:
                            {
                                sql = "SELECT factura_venta.nitcliente FROM factura_venta, factura_forma_pago WHERE " +
                                    "factura_forma_pago.numerofactura_venta = factura_venta.numerofactura_venta AND " +
                                    "factura_forma_pago.idfactura_forma_pago = " + Convert.ToInt32(iRow["id_relacion"]) + ";";
                                break;
                            }
                        case 3:
                            {
                                sql = "SELECT remision.nitcliente FROM remision, remision_forma_pago WHERE " +
                                "remision.numero = remision_forma_pago.numero_remision AND remision_forma_pago.id = " + Convert.ToInt32(iRow["id_relacion"]) + ";";
                                break;
                            }
                    }
                    miConexion.MiConexion.Open();
                    miComando.CommandText = sql;
                    var nit = Convert.ToString(miComando.ExecuteScalar());
                    sql = "UPDATE ingreso SET nitcliente = '" + nit + "' WHERE id = " + Convert.ToInt32(iRow["id"]) + ";";
                    miComando.CommandText = sql;
                    miComando.ExecuteNonQuery();
                    //miComando.Dispose();
                    miConexion.MiConexion.Close();
                }
                miComando.Dispose();
                TrasladarIngresosRemision();
                ActualizarFormasDePago();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally { miConexion.MiConexion.Close(); }
        }

        public void ActualizarFormasDePago()
        {
            try
            {
                var tablaIngresos = new DataTable();
                string sql = "SELECT ingreso.id, ingreso.tipo, ingreso.id_relacion, ingreso.valor FROM ingreso ORDER BY ingreso.id ASC;";
                miAdapter = new NpgsqlDataAdapter(sql, miConexion.MiConexion);
                miAdapter.SelectCommand.CommandType = CommandType.Text;
                miAdapter.Fill(tablaIngresos);
                miComando = new NpgsqlCommand();
                miComando.Connection = miConexion.MiConexion;
                miComando.CommandType = CommandType.Text;
                foreach (DataRow iRow in tablaIngresos.Rows)
                {
                    sql = "INSERT INTO ingreso_forma_pago(idingreso, idformapago, valor)" +
                           "VALUES (" + Convert.ToInt32(iRow["id"]) + ", 1, " + Convert.ToInt32(iRow["valor"]) + ");";
                    miConexion.MiConexion.Open();
                    miComando.CommandText = sql;
                    miComando.ExecuteNonQuery();
                    miConexion.MiConexion.Close();
                }
                miComando.Dispose();
                /*foreach (DataRow iRow in tablaIngresos.Rows)
                {
                    string nameForma = "";
                    string nameValor = "";
                    switch (Convert.ToInt32(iRow["tipo"]))
                    {
                        case 1: // Anticipo cliente
                            {
                                sql = "SELECT saldo_cliente_forma_pago.id_forma_pago, saldo_cliente_forma_pago.valor FROM " +
                                      "saldo_cliente_forma_pago WHERE saldo_cliente_forma_pago.id_saldo_cliente = " + Convert.ToInt32(iRow["id_relacion"]) + ";";
                                nameForma = "id_forma_pago";
                                nameValor = "valor";
                                break;
                            }
                        case 2: // Abono a Factura venta
                            {
                                sql = "SELECT factura_forma_pago.idforma_pago, factura_forma_pago.valor_pago FROM " +
                                      "factura_forma_pago WHERE factura_forma_pago.idfactura_forma_pago = " + Convert.ToInt32(iRow["id_relacion"]) + ";";
                                nameForma = "idforma_pago";
                                nameValor = "valor_pago";
                                break;
                            }
                        case 3: // Abono a remision
                            {
                                sql =
                                "SELECT remision_forma_pago.idforma_pago, remision_forma_pago.valor FROM remision_forma_pago WHERE remision_forma_pago.id = " + Convert.ToInt32(iRow["id_relacion"]) + ";";
                                nameForma = "idforma_pago";
                                nameValor = "valor";
                                break;
                            }
                    }
                    var tabla = new DataTable();
                    miAdapter = new NpgsqlDataAdapter(sql, miConexion.MiConexion);
                    miAdapter.SelectCommand.CommandType = CommandType.Text;
                    miAdapter.Fill(tabla);
                    foreach (DataRow tRow in tabla.Rows)
                    {
                        sql = "INSERT INTO ingreso_forma_pago(idingreso, idformapago, valor)" +
                        "VALUES (" + Convert.ToInt32(iRow["id"]) + ", " + Convert.ToInt32(tRow[nameForma]) + ", " + Convert.ToInt32(tRow[nameValor]) + ");";
                        miConexion.MiConexion.Open();
                        miComando.CommandText = sql;
                        miComando.ExecuteNonQuery();
                        miConexion.MiConexion.Close();
                    }
                }*/
                miComando.Dispose();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally { miConexion.MiConexion.Close(); }
        }

        public DataTable EliminarReplicas()
        {
            try
            {
                var tabla = new DataTable();
                tabla.Columns.Add(new DataColumn("Numero", typeof(string)));
                var tablaIngresos = new DataTable();
                string sql = "SELECT ingreso.id, ingreso.numero FROM ingreso ORDER BY ingreso.id ASC;";
                miAdapter = new NpgsqlDataAdapter(sql, miConexion.MiConexion);
                miAdapter.SelectCommand.CommandType = CommandType.Text;
                miAdapter.Fill(tablaIngresos);
                miComando = new NpgsqlCommand();
                miComando.Connection = miConexion.MiConexion;
                miComando.CommandType = CommandType.Text;
                foreach (DataRow iRow in tablaIngresos.Rows)
                {
                    var query = tablaIngresos.AsEnumerable().Where(t => t.Field<string>("numero").Equals(iRow["numero"].ToString()));
                    if (query.ToArray().Length > 1)
                    {
                        var tRow = tabla.NewRow();
                        tRow["Numero"] = iRow["numero"].ToString();
                        tabla.Rows.Add(tRow);
                    }
                    /*var num = iRow["numero"].ToString();
                    var query = tablaIngresos.AsEnumerable().Where(t => t.Field<string>("numero").Equals(iRow["numero"].ToString()));
                    var l = query.ToArray().Length;
                    if (query.ToArray().Length > 1)
                    {
                        numeros.Add(num);
                    }*/
                }
                miComando.Dispose();
                //return numeros;
                return tabla;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally { miConexion.MiConexion.Close(); }
        }

        public DataTable VerIngresosRemision()
        {
            try
            {
                var tabla = new DataTable();
                tabla.Columns.Add(new DataColumn("Numero", typeof(string)));

                var tablaIngresos = new DataTable();
                string sql = "SELECT * FROM ingreso ORDER BY ingreso.id ASC;";
                miAdapter = new NpgsqlDataAdapter(sql, miConexion.MiConexion);
                miAdapter.SelectCommand.CommandType = CommandType.Text;
                miAdapter.Fill(tablaIngresos);
                foreach (DataRow iRow in tablaIngresos.Rows)
                {
                    var num = iRow["numero"].ToString();
                    if (TieneCaracter(iRow["numero"].ToString(), 'I'))
                    {
                        var tRow = tabla.NewRow();
                        tRow["Numero"] = iRow["numero"].ToString();
                        tabla.Rows.Add(tRow);
                    }
                }
                return tabla;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void TrasladarIngresosRemision()
        {
            try
            {
                var tablaIngresos = new DataTable();
                string sql = "SELECT * FROM ingreso ORDER BY ingreso.id ASC;";
                miAdapter = new NpgsqlDataAdapter(sql, miConexion.MiConexion);
                miAdapter.SelectCommand.CommandType = CommandType.Text;
                miAdapter.Fill(tablaIngresos);
                
                foreach (DataRow iRow in tablaIngresos.Rows)
                {
                    /*var remision = false;
                    try
                    {
                        Convert.ToInt32(iRow["numero"]);
                        remision = false;
                    }
                    catch (FormatException)
                    {
                        remision = true;
                    }*/
                    var num = iRow["numero"].ToString();
                    if (TieneCaracter(iRow["numero"].ToString(), 'I'))
                    {
                        var ingreso = new Ingreso();
                        ingreso.IdCaja = Convert.ToInt32(iRow["idcaja"]);
                        ingreso.IdUsuario = Convert.ToInt32(iRow["idusuario"]);
                        ingreso.NitCliente = iRow["nitcliente"].ToString();
                        ingreso.Numero = Utilities.UseObject.RemoveCharacterString(iRow["numero"].ToString(), 'I').ToString();
                        ingreso.Concepto = iRow["concepto"].ToString();
                        ingreso.Fecha = Convert.ToDateTime(iRow["fecha"]);
                        ingreso.Valor = Convert.ToInt32(iRow["valor"]);
                        // forma pago
                        /*foreach (DataRow pRow in FormasPagoIngresoVenta(Convert.ToInt32(iRow["id"])).Rows)
                        {
                            ingreso.FormasPago.Add(new FormaPago
                            {
                                IdFormaPago = Convert.ToInt32(pRow["idforma_pago"]),
                                Valor = Convert.ToInt32(pRow["valor"])
                            });
                        }*/
                        ingreso.FormasPago.Add(new FormaPago
                        {
                            IdFormaPago = 1,
                            Valor = Convert.ToInt32(iRow["valor"])
                        });
                        IngresoDeRemision(ingreso);
                        sql = "DELETE FROM ingreso WHERE id = " + Convert.ToInt32(iRow["id"]) + ";";
                        miComando = new NpgsqlCommand();
                        miComando.Connection = miConexion.MiConexion;
                        miComando.CommandType = CommandType.Text;
                        miConexion.MiConexion.Open();
                        miComando.CommandText = sql;
                        miComando.ExecuteNonQuery();
                        miConexion.MiConexion.Close();
                    }
                }
                miComando.Dispose();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally { miConexion.MiConexion.Close(); }
        }

        private bool TieneCaracter(string cadena, char caracter)
        {
            char[] charCadena = cadena.ToCharArray();
            bool existe = false;
            for(int i = 0; i < charCadena.Length; i++)
            {
                if (charCadena[i].Equals('I'))
                {
                    existe = true;
                    break;
                }
            }
            return existe;
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

        private void CargarComandoText(string cmd)
        {
            miComando = new NpgsqlCommand();
            miComando.Connection = miConexion.MiConexion;
            miComando.CommandType = CommandType.Text;
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