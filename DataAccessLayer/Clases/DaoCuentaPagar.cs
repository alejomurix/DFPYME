using System;
using System.Linq;
using System.Collections.Generic;
using System.Data;
using DTO.Clases;
using Npgsql;

namespace DataAccessLayer.Clases
{
    public class DaoCuentaPagar
    {
        private DaoConsecutivo miDaoConsecutivo;

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

        public DaoCuentaPagar()
        {
            this.miConexion = new Conexion();
            this.miDaoConsecutivo = new DaoConsecutivo();
        }

        public int Ingresar(CuentaPagar cuenta)
        {
            try
            {
                CargarComando("insertar_cuenta_pagar");
                miComando.Parameters.AddWithValue("idcuenta", cuenta.IdCuenta);
                miComando.Parameters.AddWithValue("idtercero", cuenta.IdTercero);
                miComando.Parameters.AddWithValue("idtipo", cuenta.IdTipo);
                miComando.Parameters.AddWithValue("idcaja", cuenta.IdCaja);
                miComando.Parameters.AddWithValue("idusuario", cuenta.IdUsuario);
                miComando.Parameters.AddWithValue("numero", cuenta.Numero);
                miComando.Parameters.AddWithValue("fecha", cuenta.Fecha);
                miComando.Parameters.AddWithValue("fechadocumento", cuenta.FechaDocumento);
                miComando.Parameters.AddWithValue("fechalimite", cuenta.FechaLimite);
                miComando.Parameters.AddWithValue("activo", cuenta.Activo);
                miComando.Parameters.AddWithValue("pago", cuenta.Pago);
                miConexion.MiConexion.Open();
                var id = Convert.ToInt32(miComando.ExecuteScalar());
                miConexion.MiConexion.Close();
                miComando.Dispose();
                foreach (DetalleCuentaPagar detalle in cuenta.Detalles)
                {
                    detalle.IdCuentaPagar = Convert.ToInt32(id);
                    IngresarDetalle(detalle);
                }
                foreach (RetencionConcepto retencion in cuenta.Retenciones)
                {
                    if (retencion.Tarifa != 0)
                    {
                        retencion.Id = Convert.ToInt32(id);
                        IngresarRetencion(retencion);
                    }
                }
                return id;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al ingresar la Cuenta por Pagar.\n" + ex.Message);
            }
            finally { miConexion.MiConexion.Close(); }
        }

        // Detalle de Cuenta por Pagar
        public void IngresarDetalle(DetalleCuentaPagar detalle)
        {
            try
            {
                CargarComando("insertar_detalle_cuenta_pagar");
                miComando.Parameters.AddWithValue("idcuentapago", detalle.IdCuentaPagar);
                miComando.Parameters.AddWithValue("concepto", detalle.Concepto);
                miComando.Parameters.AddWithValue("cantidad", detalle.Cantidad);
                miComando.Parameters.AddWithValue("valor", detalle.Valor);
                miConexion.MiConexion.Open();
                miComando.ExecuteNonQuery();
                miConexion.MiConexion.Close();
                miComando.Dispose();
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al ingresar el Detalle.\n" + ex.Message);
            }
            finally { miConexion.MiConexion.Close(); }
        }

        // Retencion de Cuenta por Pagar
        public void IngresarRetencion(RetencionConcepto retencion)
        {
            try
            {
                CargarComando("insertar_cuenta_pagar_retencion");
                miComando.Parameters.AddWithValue("idcuentapago", retencion.Id);
                miComando.Parameters.AddWithValue("concepto", retencion.Concepto);
                miComando.Parameters.AddWithValue("cifraUvt", retencion.CifraUVT);
                miComando.Parameters.AddWithValue("cifrapesos", retencion.CifraPesos);
                miComando.Parameters.AddWithValue("tarifa", retencion.Tarifa);
                miConexion.MiConexion.Open();
                miComando.ExecuteNonQuery();
                miConexion.MiConexion.Close();
                miComando.Dispose();
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al ingresar la Retención.\n" + ex.Message);
            }
            finally { miConexion.MiConexion.Close(); }
        }

        // Consultar de cuentas por pagar.
        public DataTable CuentasPorPagar(int rowBase, int rowMax)
        {
            try
            {
                var tabla = new DataTable();
                CargarAdapter("cuentas_por_pagar");
                miAdapter.Fill(rowBase, rowMax, tabla);
                return tabla;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al consultar las Cuentas por Pagar.\n" + ex.Message);
            }
        }

        public long GetRowsCuentasPorPagar()
        {
            try
            {
                CargarComando("count_cuentas_por_pagar");
                miConexion.MiConexion.Open();
                var id = Convert.ToInt64(miComando.ExecuteScalar());
                miConexion.MiConexion.Close();
                miComando.Dispose();
                return id;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al cargar el total de registros.\n" + ex.Message);
            }
            finally { miConexion.MiConexion.Close(); }
        }

        public DataTable CuentasPorPagar(string tercero, int rowBase, int rowMax)
        {
            try
            {
                var tabla = new DataTable();
                CargarAdapter("cuentas_por_pagar");
                miAdapter.SelectCommand.Parameters.AddWithValue("tercero", tercero);
                miAdapter.Fill(rowBase, rowMax, tabla);
                return tabla;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al consultar las Cuentas por Pagar.\n" + ex.Message);
            }
        }

        public long GetRowsCuentasPorPagar(string tercero)
        {
            try
            {
                CargarComando("count_cuentas_por_pagar");
                miComando.Parameters.AddWithValue("tercero", tercero);
                miConexion.MiConexion.Open();
                var id = Convert.ToInt64(miComando.ExecuteScalar());
                miConexion.MiConexion.Close();
                miComando.Dispose();
                return id;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al cargar el total de registros.\n" + ex.Message);
            }
            finally { miConexion.MiConexion.Close(); }
        }

        public DataTable CuentasPorPagar(DateTime fecha, int rowBase, int rowMax)
        {
            try
            {
                var tabla = new DataTable();
                CargarAdapter("cuentas_por_pagar_fecha");
                miAdapter.SelectCommand.Parameters.AddWithValue("fecha", fecha);
                miAdapter.Fill(rowBase, rowMax, tabla);
                return tabla;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al consultar las Cuentas por Pagar.\n" + ex.Message);
            }
        }

        public long GetRowsCuentasPorPagar(DateTime fecha)
        {
            try
            {
                CargarComando("count_cuentas_por_pagar_fecha");
                miComando.Parameters.AddWithValue("fecha", fecha);
                miConexion.MiConexion.Open();
                var id = Convert.ToInt64(miComando.ExecuteScalar());
                miConexion.MiConexion.Close();
                miComando.Dispose();
                return id;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al cargar el total de registros.\n" + ex.Message);
            }
            finally { miConexion.MiConexion.Close(); }
        }

        public DataTable CuentasPorPagar(DateTime fecha, DateTime fecha2, int rowBase, int rowMax)
        {
            try
            {
                var tabla = new DataTable();
                CargarAdapter("cuentas_por_pagar_periodo");
                miAdapter.SelectCommand.Parameters.AddWithValue("fecha", fecha);
                miAdapter.SelectCommand.Parameters.AddWithValue("fecha2", fecha2);
                miAdapter.Fill(rowBase, rowMax, tabla);
                return tabla;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al consultar las Cuentas por Pagar.\n" + ex.Message);
            }
        }

        public long GetRowsCuentasPorPagar(DateTime fecha, DateTime fecha2)
        {
            try
            {
                CargarComando("count_cuentas_por_pagar_periodo");
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
                throw new Exception("Ocurrió un error al cargar el total de registros.\n" + ex.Message);
            }
            finally { miConexion.MiConexion.Close(); }
        }

        public DataTable CuentasPorPagar(string tercero, DateTime fecha, int rowBase, int rowMax)
        {
            try
            {
                var tabla = new DataTable();
                CargarAdapter("cuentas_por_pagar");
                miAdapter.SelectCommand.Parameters.AddWithValue("tercero", tercero);
                miAdapter.SelectCommand.Parameters.AddWithValue("fecha", fecha);
                miAdapter.Fill(rowBase, rowMax, tabla);
                return tabla;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al consultar las Cuentas por Pagar.\n" + ex.Message);
            }
        }

        public long GetRowsCuentasPorPagar(string tercero, DateTime fecha)
        {
            try
            {
                CargarComando("count_cuentas_por_pagar");
                miComando.Parameters.AddWithValue("tercero", tercero);
                miComando.Parameters.AddWithValue("fecha", fecha);
                miConexion.MiConexion.Open();
                var id = Convert.ToInt64(miComando.ExecuteScalar());
                miConexion.MiConexion.Close();
                miComando.Dispose();
                return id;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al cargar el total de registros.\n" + ex.Message);
            }
            finally { miConexion.MiConexion.Close(); }
        }

        public DataTable CuentasPorPagar
            (string tercero, DateTime fecha, DateTime fecha2, int rowBase, int rowMax)
        {
            try
            {
                var tabla = new DataTable();
                CargarAdapter("cuentas_por_pagar");
                miAdapter.SelectCommand.Parameters.AddWithValue("tercero", tercero);
                miAdapter.SelectCommand.Parameters.AddWithValue("fecha", fecha);
                miAdapter.SelectCommand.Parameters.AddWithValue("fecha2", fecha2);
                miAdapter.Fill(rowBase, rowMax, tabla);
                return tabla;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al consultar las Cuentas por Pagar.\n" + ex.Message);
            }
        }

        public long GetRowsCuentasPorPagar(string tercero, DateTime fecha, DateTime fecha2)
        {
            try
            {
                CargarComando("count_cuentas_por_pagar");
                miComando.Parameters.AddWithValue("tercero", tercero);
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
                throw new Exception("Ocurrió un error al cargar el total de registros.\n" + ex.Message);
            }
            finally { miConexion.MiConexion.Close(); }
        }

        public DataTable CuentasPorPagarNoSaldadas(int idTercero)
        {
            try
            {
                var tabla = new DataTable();
                CargarAdapter("cuentas_pagar_no_pagas");
                miAdapter.SelectCommand.Parameters.AddWithValue("idtercero", idTercero);
                miAdapter.Fill(tabla);
                return tabla;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al consultar las Cuentas por Pagar.\n" + ex.Message);
            }
        }

        public void EditarCuentaPagar(int idCuentaPagar)
        {
            try
            {
                var sTotal = Detalles(idCuentaPagar).AsEnumerable().Sum(s => s.Field<int>("valor"));
                var retencion = 0;
                var tRetenciones = Retenciones(idCuentaPagar);
                if (tRetenciones.Rows.Count != 0)
                {
                    retencion = 
                        Convert.ToInt32(sTotal * Convert.ToDouble(tRetenciones.AsEnumerable().First()["tarifa"]) / 100);
                }
                var total = sTotal - retencion;
                var tPagosCruces = AbonosCuentasPorPagar(idCuentaPagar).AsEnumerable().Sum(s => s.Field<int>("valor")) +
                                   CrucesCuentasPorPagar(idCuentaPagar).AsEnumerable().Sum(s => s.Field<int>("valor"));
                if (total.Equals(tPagosCruces))
                {
                    CargarComando("editar_cuenta_pagar");
                    miComando.Parameters.AddWithValue("idCuenta", idCuentaPagar);
                    miConexion.MiConexion.Open();
                    miComando.ExecuteNonQuery();
                    miConexion.MiConexion.Close();
                    miComando.Dispose();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al editar La Cuenta por Pagar.\n" + ex.Message);
            }
            finally { miConexion.MiConexion.Close(); }
        }

        public void EditarCuentaPagar(CuentaPagar cuenta)
        {
            try
            {
                CargarComando("editar_cuenta_pagar");
                miComando.Parameters.AddWithValue("id", cuenta.Id);
                miComando.Parameters.AddWithValue("idtercero", cuenta.IdTercero);
                miComando.Parameters.AddWithValue("idtipo", cuenta.IdTipoEdit);
                miComando.Parameters.AddWithValue("numero", cuenta.Numero);
                miComando.Parameters.AddWithValue("fecha", cuenta.Fecha);
                miComando.Parameters.AddWithValue("fechaDocumento", cuenta.FechaDocumento);
                miComando.Parameters.AddWithValue("limite", cuenta.FechaLimite);
                miComando.Parameters.AddWithValue("activo", cuenta.Activo);
                miComando.Parameters.AddWithValue("pago", cuenta.Pago);
                miConexion.MiConexion.Open();
                miComando.ExecuteNonQuery();
                miConexion.MiConexion.Close();
                miComando.Dispose();
                foreach (RetencionConcepto retencion in cuenta.Retenciones)
                {
                    if (retencion.Id.Equals(0))
                    {
                        retencion.Id = cuenta.Id;
                        IngresarRetencion(retencion);
                    }
                    else
                    {
                        EditarRetencion(retencion);
                    }
                }
                if (cuenta.IdTipoEdit.Equals(3) && cuenta.IdTipoEdit != cuenta.IdTipo)
                {
                    miDaoConsecutivo.ActualizarConsecutivo("Documento");
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al editar la Cuenta por Pagar.\n" + ex.Message);
            }
            finally { miConexion.MiConexion.Close(); }
        }

        public void EditarCuentaPagarAnular(int idCuentaPagar)
        {
            try
            {
                CargarComando("editar_cuenta_pagar_anular");
                miComando.Parameters.AddWithValue("idCuenta", idCuentaPagar);
                miConexion.MiConexion.Open();
                miComando.ExecuteNonQuery();
                miConexion.MiConexion.Close();
                miComando.Dispose();
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al anular La Cuenta por Pagar.\n" + ex.Message);
            }
            finally { miConexion.MiConexion.Close(); }
        }

        public void EditarRetencion(RetencionConcepto retencion)
        {
            try
            {
                CargarComando("editar_retencion_cuenta_pagar");
                miComando.Parameters.AddWithValue("id", retencion.Id);
                miComando.Parameters.AddWithValue("concepto", retencion.Concepto);
                miComando.Parameters.AddWithValue("cifraUvt", retencion.CifraUVT);
                miComando.Parameters.AddWithValue("cifraPesos", retencion.CifraPesos);
                miComando.Parameters.AddWithValue("tarifa", retencion.Tarifa);
                miConexion.MiConexion.Open();
                miComando.ExecuteNonQuery();
                miConexion.MiConexion.Close();
                miComando.Dispose();
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al editar la Retención de la Cuenta.\n" + ex.Message);
            }
            finally { miConexion.MiConexion.Close(); }
        }

        // Consulta de Detalles de Cuenta por Pagar.
        public DataTable Detalles(int idCuenta)
        {
            try
            {
                var tabla = new DataTable();
                CargarAdapter("detalles_cuenta_por_pagar");
                miAdapter.SelectCommand.Parameters.AddWithValue("idcuenta", idCuenta);
                miAdapter.Fill(tabla);
                return tabla;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al consultar los Conceptos.\n" + ex.Message);
            }
        }

        public void EliminarDetalle(int idDetalle)
        {
            try
            {
                CargarComando("eliminar_detalle_cuenta_pagar");
                miComando.Parameters.AddWithValue("id", idDetalle);
                miConexion.MiConexion.Open();
                miComando.ExecuteNonQuery();
                miConexion.MiConexion.Close();
                miComando.Dispose();
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un problema al eliminar el Concepto." + ex.Message);
            }
            finally { miConexion.MiConexion.Close(); }
        }

        // Consulta Retenciones de Cuenta por Pagar.
        public DataTable Retenciones(int idCuenta)
        {
            try
            {
                var tabla = new DataTable();
                CargarAdapter("retenciones_cuenta_por_pagar");
                miAdapter.SelectCommand.Parameters.AddWithValue("idcuenta", idCuenta);
                miAdapter.Fill(tabla);
                return tabla;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al consultar las Retenciones.\n" + ex.Message);
            }
        }


        // Funciones para la impresion de informes.
        public DataTable CuentasPorPagar()
        {
            try
            {
                var tabla = new DataTable();
                CargarAdapter("cuentas_por_pagar_saldo");
                miAdapter.Fill(tabla);
                return UnionDatos(tabla);
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al consultar las Cuentas por Pagar.\n" + ex.Message);
            }
        }

        public DataTable CuentasPorPagar(string tercero)
        {
            try
            {
                var tabla = new DataTable();
                CargarAdapter("cuentas_por_pagar_saldo");
                miAdapter.SelectCommand.Parameters.AddWithValue("tercero", tercero);
                miAdapter.Fill(tabla);
                return UnionDatos(tabla);
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al consultar las Cuentas por Pagar.\n" + ex.Message);
            }
        }

        public DataTable CuentasPorPagar(DateTime fecha)
        {
            try
            {
                var tabla = new DataTable();
                CargarAdapter("cuentas_por_pagar_fecha_saldo");
                miAdapter.SelectCommand.Parameters.AddWithValue("fecha", fecha);
                miAdapter.Fill(tabla);
                return UnionDatos(tabla);
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al consultar las Cuentas por Pagar.\n" + ex.Message);
            }
        }

        public DataTable CuentasPorPagar(DateTime fecha, DateTime fecha2)
        {
            try
            {
                var tabla = new DataTable();
                CargarAdapter("cuentas_por_pagar_periodo_saldo");
                miAdapter.SelectCommand.Parameters.AddWithValue("fecha", fecha);
                miAdapter.SelectCommand.Parameters.AddWithValue("fecha2", fecha2);
                miAdapter.Fill(tabla);
                return UnionDatos(tabla);
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al consultar las Cuentas por Pagar.\n" + ex.Message);
            }
        }

        public DataTable CuentasPorPagar(string tercero, DateTime fecha)
        {
            try
            {
                var tabla = new DataTable();
                CargarAdapter("cuentas_por_pagar_saldo");
                miAdapter.SelectCommand.Parameters.AddWithValue("tercero", tercero);
                miAdapter.SelectCommand.Parameters.AddWithValue("fecha", fecha);
                miAdapter.Fill(tabla);
                return UnionDatos(tabla);
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al consultar las Cuentas por Pagar.\n" + ex.Message);
            }
        }

        public DataTable CuentasPorPagar(string tercero, DateTime fecha, DateTime fecha2)
        {
            try
            {
                var tabla = new DataTable();
                CargarAdapter("cuentas_por_pagar_saldo");
                miAdapter.SelectCommand.Parameters.AddWithValue("tercero", tercero);
                miAdapter.SelectCommand.Parameters.AddWithValue("fecha", fecha);
                miAdapter.SelectCommand.Parameters.AddWithValue("fecha2", fecha2);
                miAdapter.Fill(tabla);
                return UnionDatos(tabla);
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al consultar las Cuentas por Pagar.\n" + ex.Message);
            }
        }

        private DataTable UnionDatos(DataTable tabla)
        {
            var tCuenta = new DataTable();
            tCuenta.Columns.Add(new DataColumn("Nit", typeof(string)));
            tCuenta.Columns.Add(new DataColumn("Tercero", typeof(string)));
            tCuenta.Columns.Add(new DataColumn("Documento", typeof(string)));
            tCuenta.Columns.Add(new DataColumn("Numero", typeof(string)));
            tCuenta.Columns.Add(new DataColumn("Fecha", typeof(DateTime)));
            tCuenta.Columns.Add(new DataColumn("Limite", typeof(DateTime)));
            tCuenta.Columns.Add(new DataColumn("Valor", typeof(int)));
            tCuenta.Columns.Add(new DataColumn("Abono", typeof(int)));
            tCuenta.Columns.Add(new DataColumn("Saldo", typeof(int)));

            int valor = 0;
            int retencion = 0;
            foreach (DataRow row in tabla.Rows)
            {
                var cRow = tCuenta.NewRow();
                cRow["Nit"] = row["nit"];
                cRow["Tercero"] = row["tercero"];
                cRow["Documento"] = row["documento"];
                cRow["Numero"] = row["numero"];
                cRow["Fecha"] = row["fecha_documento"];
                cRow["Limite"] = row["fecha_limite"];

                valor = Detalles(Convert.ToInt32(row["idcuenta"])).AsEnumerable().Sum(s => s.Field<int>("Valor"));
                var tRetenciones = Retenciones(Convert.ToInt32(row["idcuenta"]));
                if (tRetenciones.Rows.Count != 0)
                {
                    retencion = Convert.ToInt32(valor * Convert.ToDouble(tRetenciones.AsEnumerable().First()["tarifa"]) / 100);
                }
                else
                {
                    retencion = 0;
                }
                valor -= retencion;
                cRow["Valor"] = valor;
                cRow["Abono"] = AbonosCuentasPorPagar(Convert.ToInt32(row["idcuenta"])).AsEnumerable().Sum(s => s.Field<int>("valor")) +
                                CrucesCuentasPorPagar(Convert.ToInt32(row["idcuenta"])).AsEnumerable().Sum(s => s.Field<int>("valor"));
                cRow["Saldo"] = Convert.ToInt32(cRow["Valor"]) - Convert.ToInt32(cRow["Abono"]);
                tCuenta.Rows.Add(cRow);
            }
            tabla.Rows.Clear();
            tabla = null;
            return tCuenta;
        }


        /// 
        /// Abonos a Cuentas por Pagar
        ///
        public void IngresarAbonoCuentaPorPagar(FormaPago pago)
        {
            try
            {
                CargarComando("insertar_pago_cuenta_pagar");
                miComando.Parameters.AddWithValue("idcuenta", pago.Id);
                miComando.Parameters.AddWithValue("idcaja", pago.Caja.Id);
                miComando.Parameters.AddWithValue("idusuario", pago.Usuario.Id);
                miComando.Parameters.AddWithValue("idforma", pago.IdFormaPago);
                miComando.Parameters.AddWithValue("fecha", pago.Fecha);
                miComando.Parameters.AddWithValue("hora", pago.Fecha.TimeOfDay);
                miComando.Parameters.AddWithValue("valor", pago.Valor);
                miConexion.MiConexion.Open();
                miComando.ExecuteNonQuery();
                miConexion.MiConexion.Close();
                miComando.Dispose();
                EditarCuentaPagar(pago.Id);
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al ingresar el abono a la cuenta.\n" + ex.Message);
            }
            finally { miConexion.MiConexion.Close(); }
        }

        public DataTable AbonosCuentasPorPagar(int idCuenta)
        {
            try
            {
                var tabla = new DataTable();
                CargarAdapter("pagos_cuenta_por_pagar");
                miAdapter.SelectCommand.Parameters.AddWithValue("idcuenta", idCuenta);
                miAdapter.Fill(tabla);
                return tabla;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al consultar los abonos a la Cuenta por Pagar.\n" + ex.Message);
            }
        }

        /// 
        /// Cruces a Cuentas por Pagar
        ///
        public void IngresarCruceCuentaPorPagar(CruceCuentaPagar pago)
        {
            try
            {
                CargarComando("insertar_cruce_cuenta_pagar");
                miComando.Parameters.AddWithValue("idcuenta", pago.IdCuentaPagar);
                miComando.Parameters.AddWithValue("idcaja", pago.Caja.Id);
                miComando.Parameters.AddWithValue("idusuario", pago.Usuario.Id);
                miComando.Parameters.AddWithValue("numero", pago.Numero);
                miComando.Parameters.AddWithValue("fecha", pago.Fecha);
                miComando.Parameters.AddWithValue("hora", pago.Fecha.TimeOfDay);
                miComando.Parameters.AddWithValue("concepto", pago.Concepto);
                miComando.Parameters.AddWithValue("valor", pago.Valor);
                miComando.Parameters.AddWithValue("resta", pago.Resta);
                miConexion.MiConexion.Open();
                miComando.ExecuteNonQuery();
                miConexion.MiConexion.Close();
                miComando.Dispose();
                miDaoConsecutivo.ActualizarConsecutivo("CruceCuentaPagar");
                EditarCuentaPagar(pago.IdCuentaPagar);
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al ingresar el cruce a la cuenta.\n" + ex.Message);
            }
            finally { miConexion.MiConexion.Close(); }
        }

        public DataTable CrucesCuentasPorPagar(int idCuenta)
        {
            try
            {
                var tabla = new DataTable();
                CargarAdapter("cruces_cuenta_por_pagar");
                miAdapter.SelectCommand.Parameters.AddWithValue("idcuenta", idCuenta);
                miAdapter.Fill(tabla);
                return tabla;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al consultar los cruces a la Cuenta por Pagar.\n" + ex.Message);
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