using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DTO.Clases;
using Npgsql;
using NpgsqlTypes;
using DataAccessLayer.Clases;
using System.Collections;
using System.Data;

namespace DataAccessLayer.Clases
{
    public class DaoFormaPago
    {
        private Conexion conexion;

        private NpgsqlCommand comando;

        private NpgsqlDataAdapter miAdapter;

        private DataTable miDataTable;

        private DaoIngreso miDaoIngreso;

        private string sqlinsertarformapago = "insertar_forma_pago";

        private string sqllistarformapago = "listado_forma_pago";

        private string sqlmodificarformapago = "modifica_forma_pago";

        private string sqleliminaformapago = "elimina_forma_pago";

        private string sqlexisteformapago = "existe_forma_pago";

        private string FormaPagoFacturaVenta = "formas_pago_factura_venta";

        /// <summary>
        /// Representa la función: pagos_a_proveedor.
        /// </summary>
        private string PagosProveedor = "pagos_a_proveedor";

        /// <summary>
        /// Representa la función ingresar_forma_pago_venta.
        /// </summary>
        private string IngresarPago = "ingresar_forma_pago_venta";

        /// <summary>
        /// Representa la función insertar_pago_a_proveedor.
        /// </summary>
        private string IngresarPagoProveedor = "insertar_pago_a_proveedor";

        #region Mensajes

        /// <summary>
        /// Representa el mensaje: Ocurrió un error al consultar las formas de pago.
        /// </summary>
        private string ErrorFormaPago = "Ocurrió un error al consultar las formas de pago.\n";

        /// <summary>
        /// Representa el texto: Ocurrió un error al ingresar el pago al Proveedor.
        /// </summary>
        private string ErrorProveedor = "Ocurrió un error al ingresar el pago al Proveedor.\n";

        #endregion

        /// <summary>
        /// constructor forma pago
        /// </summary>
        public DaoFormaPago()
        {
            conexion = new Conexion();
            miDaoIngreso = new DaoIngreso();
        }

        #region Forma de Pago

        public bool ExisteFormaPago(string nombre)
        {
            try
            {
                CargarComandoStoredProcedure(sqlexisteformapago);
                comando.Parameters.AddWithValue("nombreforma_pago", nombre);
                conexion.MiConexion.Open();
                var resultado = Convert.ToBoolean(comando.ExecuteScalar());
                comando.ExecuteNonQuery();
                conexion.MiConexion.Close();
                comando.Dispose();
                return resultado;
            }
            catch (Exception ex)
            {
                throw new Exception("Forma Pago ya Existe" + ex.Message);
            }
            finally
            {
                conexion.MiConexion.Close();
            }
        }

        public void InsertarFormaPago(FormaPago miformapago)
        {
            try
            {
                CargarComandoStoredProcedure(sqlinsertarformapago);
                comando.Parameters.AddWithValue("nombre", miformapago.NombreFormaPago);
                conexion.MiConexion.Open();
                comando.ExecuteNonQuery();
                conexion.MiConexion.Close();
                comando.Dispose();
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al ingresar la Forma de Pago.\n" + ex.Message);
            }
            finally{ conexion.MiConexion.Close(); }
        }

        public DataTable ListaFormaPago()
        {
            try
            {
                miDataTable = new DataTable();
                CargarAdapterstoredProsedure(sqllistarformapago);
                this.miAdapter.Fill(miDataTable);
                return miDataTable;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al cargar las formas de pago.\n" + ex.Message);
            }
        }

        public DataTable FormasDePagoHabiles()
        {
            try
            {
                var tabla = new DataTable();
                CargarAdapterstoredProsedure("formas_pago_habiles");
                this.miAdapter.Fill(tabla);
                return tabla;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al cargar las formas de pago.\n" + ex.Message);
            }
        }

        public void ModificaFormaPago(FormaPago mipago)
        {
            try
            {
                CargarComandoStoredProcedure(sqlmodificarformapago);
                comando.Parameters.AddWithValue("idforma_pago", mipago.IdFormaPago);
                comando.Parameters.AddWithValue("nombreforma_pago", mipago.NombreFormaPago);
                conexion.MiConexion.Open();
                comando.ExecuteNonQuery();
                conexion.MiConexion.Close();
                comando.Dispose();
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al editar la Forma de Pago.\n" + ex.Message);
            }
            finally { conexion.MiConexion.Close(); }
        }

        public void HabilitaFormaPago(FormaPago pago)
        {
            try
            {
                CargarComandoStoredProcedure(sqlmodificarformapago);
                comando.Parameters.AddWithValue("idforma_pago", pago.IdFormaPago);
                comando.Parameters.AddWithValue("nombreforma_pago", pago.Habilita);
                conexion.MiConexion.Open();
                comando.ExecuteNonQuery();
                conexion.MiConexion.Close();
                comando.Dispose();
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al editar la Forma de Pago.\n" + ex.Message);
            }
            finally { conexion.MiConexion.Close(); }
        }

        public void EliminaFormaPago(int id)
        {
            try
            {
                CargarComandoStoredProcedure(sqleliminaformapago);
                comando.Parameters.AddWithValue("id", id);
                conexion.MiConexion.Open();
                comando.ExecuteNonQuery();
                conexion.MiConexion.Close();
                comando.Dispose();
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrio un error al eliminar la Forma de Pago.\n" + ex.Message);
            }
            finally { conexion.MiConexion.Close(); }
        }

        #endregion

        #region Egreso Forma de Pago

        public void IngresarEgresoPago(FormaPago pago)
        {
            try
            {
                CargarComandoStoredProcedure("insertar_egreso_forma_pago");
                comando.Parameters.AddWithValue("idegreso", pago.Caja.Id);
                comando.Parameters.AddWithValue("idpago", pago.IdFormaPago);
                comando.Parameters.AddWithValue("valor", pago.Valor);
                conexion.MiConexion.Open();
                comando.ExecuteNonQuery();
                conexion.MiConexion.Close();
                comando.Dispose();
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al ingresar el pago del Egreso.\n" + ex.Message);
            }
            finally { conexion.MiConexion.Close(); }
        }

        public void EliminarEgresoPago(int id)
        {
            try
            {
                CargarComandoStoredProcedure("eliminar_pago_egreso");
                comando.Parameters.AddWithValue("id", id);
                conexion.MiConexion.Open();
                comando.ExecuteNonQuery();
                conexion.MiConexion.Close();
                comando.Dispose();
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al eliminar el pago del Egreso.\n" + ex.Message);
            }
            finally { conexion.MiConexion.Close(); }
        }



        #endregion

        #region Egreso Pago Remision Proveedor

        public void IngresarEgresoPagoRemisionProveedor(FormaPago pago)
        {
            try
            {
                CargarComandoStoredProcedure("insertar_egreso_remision_pago");
                comando.Parameters.AddWithValue("idegreso", pago.Caja.Id);
                comando.Parameters.AddWithValue("idpago", pago.IdFormaPago);
                comando.Parameters.AddWithValue("valor", pago.Valor);
                conexion.MiConexion.Open();
                comando.ExecuteNonQuery();
                conexion.MiConexion.Close();
                comando.Dispose();
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al ingresar el pago del Egreso de la Remisión.\n" + ex.Message);
            }
            finally { conexion.MiConexion.Close(); }
        }



        #endregion

        #region Venta Forma de Pago

        public int IngresarPagoAFactura(FormaPago pago, bool venta, bool unit)
        {
            var miDaoConsecutivo = new DaoConsecutivo();
            var miDaoFacturaVenta = new DaoFacturaVenta();
            //pago.Valor = miDaoFacturaVenta.ValorFactura(pago.NumeroFactura);
            try
            {
                if (venta)
                {
                    CargarComandoStoredProcedure(IngresarPago);
                }
                comando.Parameters.AddWithValue("factura", pago.NumeroFactura);
                comando.Parameters.AddWithValue("forma", pago.IdFormaPago);
                comando.Parameters.AddWithValue("usuario", pago.Usuario.Id);
                comando.Parameters.AddWithValue("caja", pago.Caja.Id);
                comando.Parameters.AddWithValue("fecha", pago.Fecha);
                comando.Parameters.AddWithValue("hora", pago.Fecha.TimeOfDay);
                comando.Parameters.AddWithValue("valor", pago.Valor);
                comando.Parameters.AddWithValue("turno", pago.IdEgreso);
                comando.Parameters.AddWithValue("pago", pago.Pago);
                comando.Parameters.AddWithValue("idfactura", pago.IdFactura);
                conexion.MiConexion.Open();
                var id = Convert.ToInt32(comando.ExecuteScalar());
                conexion.MiConexion.Close();
                comando.Dispose();
                if (unit)
                {
                    miDaoConsecutivo.ActualizarConsecutivo("Ingreso");
                }
                miDaoIngreso.IngresarAcumulado(pago.Caja.Id, pago.Fecha, Convert.ToInt32(pago.Valor));
                /*if (venta)
                {
                    if (pos)
                    {
                        miDaoConsecutivo.ActualizarConsecutivo("Ingreso");
                    }
                }*/
                return id;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally { conexion.MiConexion.Close(); }
        }

        /// <summary>
        /// Obtiene el listado de las formas de pago de una Factura de Venta.
        /// </summary>
        /// <param name="numero">Número de la factura de venta.</param>
        /// <returns></returns>
        public DataTable FormasDePagoDeFacturaVenta()
        {
            var tabla = new DataTable();
            try
            {
                CargarAdapterstoredProsedure("formas_pago_factura_venta");
                miAdapter.Fill(tabla);
                return tabla;
            }
            catch (Exception ex)
            {
                throw new Exception(ErrorFormaPago + ex.Message);
            }
        }

        public DataTable FormasDePagoDeFacturaVenta(int id)
        {
            var tabla = new DataTable();
            try
            {
                CargarAdapterstoredProsedure("formas_pago_factura_venta");
                miAdapter.SelectCommand.Parameters.AddWithValue("id", id);
                miAdapter.Fill(tabla);
                return tabla;
            }
            catch (Exception ex)
            {
                throw new Exception(ErrorFormaPago + ex.Message);
            }
        }

        /// <summary>
        /// Obtiene el listado de las formas de pago de una Factura de Venta.
        /// </summary>
        /// <param name="numero">Número de la factura de venta.</param>
        /// <returns></returns>
        public DataTable FormasDePagoDeFacturaVenta(string numero)
        {
            var tabla = new DataTable();
            try
            {
                //formas_pago_factura_venta
                CargarAdapterstoredProsedure(FormaPagoFacturaVenta);
                miAdapter.SelectCommand.Parameters.AddWithValue("numero", numero);
                miAdapter.Fill(tabla);
                return tabla;
            }
            catch (Exception ex)
            {
                throw new Exception(ErrorFormaPago + ex.Message);
            }
        }

        public DataTable FormasDePagoDeFacturaVentaId(int idFactura)
        {
            var tabla = new DataTable();
            try
            {
                CargarAdapterstoredProsedure("formas_pago_factura_venta_idfactura");
                miAdapter.SelectCommand.Parameters.AddWithValue("idfactura", idFactura);
                miAdapter.Fill(tabla);
                return tabla;
            }
            catch (Exception ex)
            {
                throw new Exception(ErrorFormaPago + ex.Message);
            }
        }

        public DataTable FormasDePagoDeFacturaVenta(int idCaja, DateTime fecha)
        {
            var tabla = new DataTable();
            try
            {
                CargarAdapterstoredProsedure("print_abonos_venta");
                miAdapter.SelectCommand.Parameters.AddWithValue("caja", idCaja);
                miAdapter.SelectCommand.Parameters.AddWithValue("fecha", fecha);
                miAdapter.Fill(tabla);
                return tabla;
            }
            catch (Exception ex)
            {
                throw new Exception(ErrorFormaPago + ex.Message);
            }
        }

        public DataTable FormasDePagoDeFacturaVenta(DateTime fecha)
        {
            var tabla = new DataTable();
            try
            {
                CargarAdapterstoredProsedure("print_abonos_venta");
                miAdapter.SelectCommand.Parameters.AddWithValue("fecha", fecha);
                miAdapter.Fill(tabla);
                return tabla;
            }
            catch (Exception ex)
            {
                throw new Exception(ErrorFormaPago + ex.Message);
            }
        }

        public void EditarValores(int id, int valor, int pago)
        {
            try
            {
                string sql = "UPDATE factura_forma_pago SET valorfactura_forma_pago = " + valor + ", valor_pago = " + pago +
                    " WHERE idfactura_forma_pago = " + id + ";";
                comando = new NpgsqlCommand();
                comando.Connection = conexion.MiConexion;
                comando.CommandText = sql;
                comando.CommandType = CommandType.Text;
                conexion.MiConexion.Open();
                comando.ExecuteNonQuery();
                conexion.MiConexion.Close();
                comando.Dispose();
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error.\n" + ex.Message);
            }
            finally { conexion.MiConexion.Close(); }
        }

       /* public void EditarValorPago(int id, int pago)
        {
            try
            {
                CargarComandoStoredProcedure("editar_valor_pago");
                comando.Parameters.AddWithValue("id", id);
                comando.Parameters.AddWithValue("valor", pago);
                conexion.MiConexion.Open();
                comando.ExecuteNonQuery();
                conexion.MiConexion.Close();
                comando.Dispose();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally { conexion.MiConexion.Close(); }
        }*/

       /* public void EditarValorPagado(int id, int pago)
        {
            try
            {
                CargarComandoStoredProcedure("editar_valor_pagado");
                comando.Parameters.AddWithValue("id", id);
                comando.Parameters.AddWithValue("valor", pago);
                conexion.MiConexion.Open();
                comando.ExecuteNonQuery();
                conexion.MiConexion.Close();
                comando.Dispose();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally { conexion.MiConexion.Close(); }
        }*/

        #endregion

        #region Compra Forma de Pago

        /// <summary>
        /// Ingresa los datos del pago o abono realizado a un proveedor.
        /// </summary>
        /// <param name="pago">Pago a realizar.</param>
        public int IngresaPagoAProveedor(FormaPago pago, bool esFactura)
        {
            try
            {
                if (esFactura)
                {
                    CargarComandoStoredProcedure(IngresarPagoProveedor);
                }
                else
                {
                    CargarComandoStoredProcedure("insertar_pago_remision_proveedor");
                }
                comando.Parameters.AddWithValue("factura", Convert.ToInt32(pago.NumeroFactura));
                comando.Parameters.AddWithValue("usuario", pago.Usuario.Id);
                comando.Parameters.AddWithValue("caja", pago.Caja.Id);
                comando.Parameters.AddWithValue("forma", pago.IdFormaPago);
                comando.Parameters.AddWithValue("fecha", pago.Fecha);
                comando.Parameters.AddWithValue("hora", pago.Fecha.TimeOfDay);
                comando.Parameters.AddWithValue("valor", pago.Valor);
                conexion.MiConexion.Open();
                var id = Convert.ToInt32(comando.ExecuteScalar());
                conexion.MiConexion.Close();
                comando.Dispose();
                return id;
            }
            catch (Exception ex)
            {
                throw new Exception(ErrorProveedor + ex.Message);
            }
            finally { conexion.MiConexion.Close(); }
        }

        // Funciones relacion egreso_pago
        public void IngresarEgresoPago(int idEgreso, int idPago)
        {
            try
            {
                CargarComandoStoredProcedure("insertar_egreso_pago");
                comando.Parameters.AddWithValue("idegreso", idEgreso);
                comando.Parameters.AddWithValue("idpago", idPago);
                conexion.MiConexion.Open();
                comando.ExecuteNonQuery();
                conexion.MiConexion.Close();
                comando.Dispose();
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al ingresar la relación del pago y egreso.\n" + ex.Message);
            }
            finally { conexion.MiConexion.Close(); }
        }

        public DataTable EgresosPagos(int idEgreso)
        {
            try
            {
                var tabla = new DataTable();
                CargarAdapterstoredProsedure("egresos_pagos");
                miAdapter.SelectCommand.Parameters.AddWithValue("idegreso", idEgreso);
                miAdapter.Fill(tabla);
                return tabla; 
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al consultar la relacion de egresos y pagos.\n" + ex.Message); 
            }
        }

        public void EliminarEgresoPagos(int idEgreso)
        {
            try
            {
                CargarComandoStoredProcedure("eliminar_egreso_pago");
                comando.Parameters.AddWithValue("idegreso", idEgreso);
                conexion.MiConexion.Open();
                comando.ExecuteNonQuery();
                conexion.MiConexion.Close();
                comando.Dispose();
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al eliminar la relación del pago y egreso.\n" + ex.Message);
            }
            finally { conexion.MiConexion.Close(); }
        }

        //**********************************************************

        /// <summary>
        /// Obtiene los datos de los pagos o abono realizados a una factura de Proveedor.
        /// </summary>
        /// <param name="idFactura">Id de la factura a consultar pagos.</param>
        /// <returns></returns>
        public DataTable PagosAProveedor(int idFactura)
        {
            var tabla = new DataTable();
            try
            {
                CargarAdapterstoredProsedure(PagosProveedor);
                miAdapter.SelectCommand.Parameters.AddWithValue("id", idFactura);
                miAdapter.Fill(tabla);
                return tabla;
            }
            catch (Exception ex)
            {
                throw new Exception(ErrorFormaPago + ex.Message);
            }
        }

        public DataTable PagosFacturaProveedor(int idFactura)
        {
            var tabla = new DataTable();
            try
            {
                CargarAdapterstoredProsedure("pagos_factura_proveedor");
                miAdapter.SelectCommand.Parameters.AddWithValue("", idFactura);
                miAdapter.Fill(tabla);
                return tabla;
            }
            catch (Exception ex)
            {
                throw new Exception(ErrorFormaPago + ex.Message);
            }
        }

        public void EditarPagoDeCompra(int id, int valor)
        {
            try
            {
                var sql = 
                "UPDATE pago_factura_proveedor SET valorpago_factura_proveedor = " + valor + " WHERE idpago_factura_proveedor = " + id + ";";
                comando = new NpgsqlCommand();
                comando.Connection = conexion.MiConexion;
                comando.CommandType = CommandType.Text;
                comando.CommandText = sql;
                conexion.MiConexion.Open();
                comando.ExecuteNonQuery();
                conexion.MiConexion.Close();
                comando.Dispose();
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al editar el pago.\n" + ex.Message);
            }
            finally { conexion.MiConexion.Close(); }
        }

        public void EliminarPagoDeCompra(int id)
        {
            try
            {
                var sql =
                "DELETE FROM pago_factura_proveedor WHERE idpago_factura_proveedor = " + id + ";";
                comando = new NpgsqlCommand();
                comando.Connection = conexion.MiConexion;
                comando.CommandType = CommandType.Text;
                comando.CommandText = sql;
                conexion.MiConexion.Open();
                comando.ExecuteNonQuery();
                conexion.MiConexion.Close();
                comando.Dispose();
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al eliminar el pago.\n" + ex.Message);
            }
            finally { conexion.MiConexion.Close(); }
        }

        #endregion

        #region Remision Forma de Pago

        public int IngresarPagoRemision(FormaPago fPago)
        {
            var miDaoConsecutivo = new DaoConsecutivo();
            try
            {
                CargarComandoStoredProcedure("insertar_remision_forma_pago");
                comando.Parameters.AddWithValue("", Convert.ToInt32(fPago.NumeroFactura));
                comando.Parameters.AddWithValue("", fPago.Usuario.Id);
                comando.Parameters.AddWithValue("", fPago.Caja.Id);
                comando.Parameters.AddWithValue("", fPago.IdFormaPago);
                comando.Parameters.AddWithValue("", fPago.Fecha);
                comando.Parameters.AddWithValue("", fPago.Fecha.TimeOfDay);
                comando.Parameters.AddWithValue("", fPago.Valor);
                comando.Parameters.AddWithValue("", fPago.Pago);
                conexion.MiConexion.Open();
                var id = Convert.ToInt32(comando.ExecuteScalar());
                //comando.ExecuteNonQuery();
                conexion.MiConexion.Close();
                comando.Dispose();
                //miDaoConsecutivo.ActualizarConsecutivo("IngresoRemision");
                return id;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al ingresa el pago de la Remisión.\n" + ex.Message);
            }
            finally { conexion.MiConexion.Close(); }
        }

        public DataTable FormasDePagoRemision(int numero)
        {
            var tabla = new DataTable();
            try
            {
                CargarAdapterstoredProsedure("formas_pago_remision");
                miAdapter.SelectCommand.Parameters.AddWithValue("numero", numero);
                miAdapter.Fill(tabla);
                return tabla;
            }
            catch (Exception ex)
            {
                throw new Exception(ErrorFormaPago + ex.Message);
            }
        }

        public DataTable FormasDePagoRemisionId(int id)
        {
            var tabla = new DataTable();
            try
            {
                CargarAdapterstoredProsedure("formas_pago_remision_id");
                miAdapter.SelectCommand.Parameters.AddWithValue("numero", id);
                miAdapter.Fill(tabla);
                return tabla;
            }
            catch (Exception ex)
            {
                throw new Exception(ErrorFormaPago + ex.Message);
            }
        }

        public DataTable PagosARemisionVentaId(int numeroRemision)
        {
            var tabla = new DataTable();
            try
            {
                CargarAdapterstoredProsedure("formas_pago_remision_venta");
                miAdapter.SelectCommand.Parameters.AddWithValue("", numeroRemision);
                miAdapter.Fill(tabla);
                return tabla;
            }
            catch (Exception ex)
            {
                throw new Exception(ErrorFormaPago + ex.Message);
            }
        }

        #endregion

        //Remision proveedor

        //pagos_remision_proveedor
        public DataTable PagosRemisionProveedor(int idRemision)
        {
            try
            {
                var tabla = new DataTable();
                CargarAdapterstoredProsedure("pagos_remision_proveedor");
                miAdapter.SelectCommand.Parameters.AddWithValue("idRemision", idRemision);
                miAdapter.Fill(tabla);
                return tabla;
            }
            catch (Exception ex)
            {
                throw new Exception("" + ex.Message);
            }
        }

        private void CargarComandoStoredProcedure(string cmd)
        {
            comando = new NpgsqlCommand();
            comando.Connection = conexion.MiConexion;
            comando.CommandText = cmd;
            comando.CommandType = CommandType.StoredProcedure;
        }

        private void CargarAdapterstoredProsedure(string cmd)
        {
            this.miAdapter = new NpgsqlDataAdapter(cmd, this.conexion.MiConexion);
            this.miAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
        }
    }
}