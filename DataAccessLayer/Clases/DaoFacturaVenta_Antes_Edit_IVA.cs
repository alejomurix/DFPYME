using System;
using System.Linq;
using System.Data;
using DTO.Clases;
using Npgsql;
using System.Collections;
using System.Collections.Generic;
using Utilities;

namespace DataAccessLayer.Clases
{
    /// <summary>
    /// Representa una clase para la pertinencia de datos de Factura de venta.
    /// </summary>
    public class DaoFacturaVenta
    {
        #region Transacción a base de datos.

        /// <summary>
        /// Representa un objeto con acceso a la conexión de base de datos Postgresql.
        /// </summary>
        private Conexion miConexion;

        /// <summary>
        /// Representa un comando de ejecucion de sentencias SQL a PostgreSQL.
        /// </summary>
        private NpgsqlCommand miComando;

        /// <summary>
        /// Objeto adaptador de consultas SQL a servidor PostgreSQL.
        /// </summary>
        private NpgsqlDataAdapter miAdapter;

        #endregion

        #region Funciones

        /// <summary>
        /// Representa la función recuperar_consecutivo.
        /// </summary>
        private string ObtenerConsicutivo = "recuperar_consecutivo";

        /// <summary>
        /// Representa la función obtener_rango_final.
        /// </summary>
        private string RangoFinal = "obtener_rango_final";

        /// <summary>
        /// Representa la función: obtener_rango_final_credito.
        /// </summary>
        private string RangoFinalCredito = "obtener_rango_final_credito";

        /// <summary>
        /// Representa la función insertar_factura_venta.
        /// </summary>
        private string Ingresar = "insertar_factura_venta";

        /// <summary>
        /// Representa la Función: print_factura_venta.
        /// </summary>
        private string PrintFacturaVenta_ = "print_factura_venta";

        /// <summary>
        /// Representa la función editar_factura_venta.
        /// </summary>
        private string Editar = "editar_factura_venta";

        /// <summary>
        /// Representa la función: editar_cliente_factura_venta.
        /// </summary>
        private string EditarCliente_ = "editar_cliente_factura_venta";

        /// <summary>
        /// Representa la función actualizar_consecutivo.
        /// </summary>
        private string ActualizarConsecutivo_ = "actualizar_consecutivo";

        /// <summary>
        /// Representa la función: consulta_factura_venta_numero.
        /// </summary>
        private string ConsultaNumero_ = "consulta_factura_venta_numero";

        /// <summary>
        /// Representa la función: consulta_factura_venta_estado.
        /// </summary>
        private string ConsultaEstado_ = "consulta_factura_venta_estado";

        /// <summary>
        /// Representa la función: consulta_factura_venta_estado_ingreso.
        /// </summary>
        private string ConsultaEstadoFechaIngreso_ = "consulta_factura_venta_estado_ingreso";

        /// <summary>
        /// Representa la función: consulta_factura_venta_estado_periodo.
        /// </summary>
        private string ConsultaEstadoPeriodoIngreso_ = "consulta_factura_venta_estado_periodo";

        /// <summary>
        /// Representa la función: consulta_factura_todas_cliente.
        /// </summary>
        private string ConsultaPorCliente_ = "consulta_factura_todas_cliente";

        /// <summary>
        /// Representa la función: consulta_factura_estado_y_cliente.
        /// </summary>
        private string ConsultaPorEstadoYcliente_ = "consulta_factura_estado_y_cliente";

        /// <summary>
        /// Representa la función: consulta_factura_todas_cliente_fingreso.
        /// </summary>
        private string ConsultaPorClienteIngreso_ = "consulta_factura_todas_cliente_fingreso";

        /// <summary>
        /// Representa la función: consulta_factura_estado_cliente_fingreso.
        /// </summary>
        private string ConsultaPorEstadoClienteIngreso_ = "consulta_factura_estado_cliente_fingreso";

        /// <summary>
        /// Representa la función: consulta_factura_todas_cliente_periodo.
        /// </summary>
        private string ConsultaPorClientePeriodoIngreso_ = "consulta_factura_todas_cliente_periodo";

        /// <summary>
        /// Representa la función: consulta_factura_estado_cliente_periodo.
        /// </summary>
        private string ConsultaPorEstadoClientePeriodoIngreso_ = "consulta_factura_estado_cliente_periodo";

        /// <summary>
        /// Representa la función: consulta_factura_mora.
        /// </summary>
        private string ConsultaEnMora_ = "consulta_factura_mora";

        /// <summary>
        /// Representa la función: consulta_factura_cliente_mora.
        /// </summary>
        private string ConsultaClienteEnMora_ = "consulta_factura_cliente_mora";

        /// <summary>
        /// Representa la función: consulta_factura_estado_flimite.
        /// </summary>
        private string ConsultaEstadoFechaLimite_ = "consulta_factura_estado_flimite";

        /// <summary>
        /// Representa la función: consulta_factura_estado_periodo.
        /// </summary>
        private string ConsultaCreditoPeriodo_ = "consulta_factura_estado_periodo";

        /// <summary>
        /// Representa la función: consulta_factura_cliente_estado_flimite.
        /// </summary>
        private string ConsultaClienteCreditoLimite_ = "consulta_factura_cliente_estado_flimite";

        /// <summary>
        /// Representa la función: consulta_factura_cliente_estado_periodo.
        /// </summary>
        private string ConsultaClienteCreditoLimitePeriodo_ = "consulta_factura_cliente_estado_periodo";

        /// <summary>
        /// Representa la función: count_consulta_factura_venta_estado.
        /// </summary>
        private string GetRowsConsultaEstado_ = "count_consulta_factura_venta_estado";

        /// <summary>
        /// Representa la función: count_consulta_factura_venta_estado_ingreso.
        /// </summary>
        private string GetRowsConsultaEstadoFechaIngreso_ = "count_consulta_factura_venta_estado_ingreso";

        /// <summary>
        /// Representa la función: count_consulta_factura_venta_estado_periodo.
        /// </summary>
        private string GetRowsConsultaEstadoPeriodoIngreso_ = "count_consulta_factura_venta_estado_periodo";

        /// <summary>
        /// Representa la función: count_consulta_factura_todas_cliente.
        /// </summary>
        private string GetRowsConsultaPorCliente_ = "count_consulta_factura_todas_cliente";

        /// <summary>
        /// Representa la función: count_consulta_factura_estado_y_cliente.
        /// </summary>
        private string GetRowsConsultaPorEstadoYcliente_ = "count_consulta_factura_estado_y_cliente";

        /// <summary>
        /// Representa la función: count_consulta_factura_todas_cliente_fingreso.
        /// </summary>
        private string GetRowsConsultaPorClienteIngreso_ = "count_consulta_factura_todas_cliente_fingreso";

        /// <summary>
        /// Representa la función: count_consulta_factura_todas_cliente_periodo.
        /// </summary>
        private string GetRowsConsultaPorClientePeriodoIngreso_ = "count_consulta_factura_todas_cliente_periodo";

        /// <summary>
        /// Representa la función: count_consulta_factura_estado_cliente_periodo.
        /// </summary>
        private string GetRowsEstadoClientePeriodoIngreso_ = "count_consulta_factura_estado_cliente_periodo";

        /// <summary>
        /// Representa la función: count_consulta_factura_mora.
        /// </summary>
        private string GetRowsConsultaEnMora_ = "count_consulta_factura_mora";

        /// <summary>
        /// Representa la función: count_consulta_factura_cliente_mora.
        /// </summary>
        private string GetRowsConsultaClienteEnMora_ = "count_consulta_factura_cliente_mora";

        /// <summary>
        /// Representa la función: count_consulta_factura_estado_flimite.
        /// </summary>
        private string GetRowsConsultaEstadoFechaLimite_ = "count_consulta_factura_estado_flimite";

        /// <summary>
        /// Representa la función: count_consulta_factura_estado_periodo.
        /// </summary>
        private string GetRowsConsultaCreditoPeriodo_ = "count_consulta_factura_estado_periodo";

        /// <summary>
        /// Representa la función: count_consulta_factura_cliente_estado_flimite.
        /// </summary>
        private string GetRowsConsultaClienteCreditoLimite_ = "count_consulta_factura_cliente_estado_flimite";

        /// <summary>
        /// Representa la función: count_consulta_factura_cliente_estado_periodo.
        /// </summary>
        private string GetRowsConsultaClienteCreditoLimitePeriodo_ =
            "count_consulta_factura_cliente_estado_periodo";

        /// <summary>
        /// Representa la función: anular_factura_venta.
        /// </summary>
        private string AnulaFactura_ = "anular_factura_venta";









        #endregion

        #region Mensajes

        /// <summary>
        /// Representa el texto: Ocurrió un error al obtener el rango de números.
        /// </summary>
        private string ErrorRango = "Ocurrió un error al obtener el rango de números.\n";

        /// <summary>
        /// Representa el texto: Ocurrió un error al obtener el rango de números.
        /// </summary>
        private string ErrorNumero = "Ocurrió un error al obtener el número consecutivo.\n";

        /// <summary>
        /// Representa el texto: Ocurrió un error al ingresar la factura de venta.
        /// </summary>
        private string ErrorIngresar = "Ocurrió un error al ingresar la factura de venta.\n";

        /// <summary>
        /// Representa el texto: Ocurrió un error al editar la factura de venta.
        /// </summary>
        private string ErrorEditar = "Ocurrió un error al editar la factura de venta.\n";

        /// <summary>
        /// Representa el texto: Ocurrió un error al actualizar el consecutivo de la factura.
        /// </summary>
        private string ErrorActualizaConsecutivo = "Ocurrió un error al actualizar el consecutivo de la factura.\n";

        /// <summary>
        /// Representa el texto: Ocurrió un error al consultar la Factura de Venta.
        /// </summary>
        private string ErrorConsulta = "Ocurrió un error al consultar la Factura de Venta.\n";

        /// <summary>
        /// Representa el texto: Ocurrió un error al obtener el número de registros.
        /// </summary>
        private string ErrorGetRows = "Ocurrió un error al obtener el número de registros.\n";

        /// <summary>
        /// Representa el texto: Ocurrió un error al anular la Factura de Venta.
        /// </summary>
        private string ErrorAnular = "Ocurrió un error al anular la Factura de Venta.\n";

        #endregion

        /// <summary>
        /// Inicializa una nueva instancia de la clase DaoFacuraVenta.
        /// </summary>
        public DaoFacturaVenta()
        {
            this.miConexion = new Conexion();
        }

        /// <summary>
        /// Obtiene el Número consecutivo a se asignado en la Factura.
        /// </summary>
        /// <returns></returns>
        public string ObtenerNumero(bool contado)
        {
            try
            {
                CargarComando(ObtenerConsicutivo);
                if (contado)
                {
                    miComando.Parameters.AddWithValue("nombre", "Factura");
                }
                else
                {
                    miComando.Parameters.AddWithValue("nombre", "FacturaCredito");
                }
                miConexion.MiConexion.Open();
                var numero = Convert.ToString(miComando.ExecuteScalar());
                miConexion.MiConexion.Close();
                miComando.Dispose();
                return numero;
            }
            catch (Exception ex)
            {
                throw new Exception(ErrorNumero + ex.Message);
            }
            finally { miConexion.MiConexion.Close(); }
        }

        /// <summary>
        /// Obtiene el número correspondiente al rango final del registro de la Dian.
        /// </summary>
        /// <returns></returns>
        public long ObtenerRangoFinal(bool contado)
        {
            try
            {
                if (contado)
                {
                    CargarComando(RangoFinal);
                }
                else
                {
                    CargarComando(RangoFinalCredito);
                }
                miConexion.MiConexion.Open();
                var numero = Convert.ToInt64(miComando.ExecuteScalar());
                miConexion.MiConexion.Close();
                miComando.Dispose();
                return numero;
            }
            catch (Exception ex)
            {
                throw new Exception(ErrorRango + ex.Message);
            }
            finally { miConexion.MiConexion.Close(); }
        }

        /// <summary>
        /// Ingresa el registro de una Factura a base de datos.
        /// </summary>
        /// <param name="factura">Factura a ingresar.</param>
        /// <param name="edicion">Indica si la factura proviene de una edición de la misma.</param>
        public void IngresarFactura(FacturaVenta factura, bool edicion, bool anutigua)
        {
            var miDaoRemision = new DaoRemision();
            var miDaoProductoFactura = new DaoProductoFacturaVenta();
            var miDaoInventario = new DaoInventario();
            var miDaoPago = new DaoFormaPago();
            var miDaoSaldo = new DaoSaldo();
            var miDaoBono = new DaoBono();
            var miDaoRetencion = new DaoRetencion();
            var miDaoConsecutivo = new DaoConsecutivo();
            try
            {
                if (edicion)
                {
                    RetirarProductos(factura, miDaoProductoFactura);
                    CargarComando(Editar);
                }
                else
                {
                    CargarComando(Ingresar);
                }
                //miComando.Parameters.AddWithValue("numero", factura.Numero);
                if (edicion)
                {
                    miComando.Parameters.AddWithValue("numeroEdit", factura.NumeroEdit);
                    miComando.Parameters.AddWithValue("numero", factura.Numero);
                }
                else
                {
                    miComando.Parameters.AddWithValue("numero", factura.Numero);
                }
                miComando.Parameters.AddWithValue("cliente", factura.Proveedor.NitProveedor);
                miComando.Parameters.AddWithValue("usuario", factura.Usuario.Id);
                miComando.Parameters.AddWithValue("caja", factura.Caja.Id);
                miComando.Parameters.AddWithValue("estado", factura.EstadoFactura.Id);
                miComando.Parameters.AddWithValue("fecha", factura.FechaIngreso);
                miComando.Parameters.AddWithValue("hora", factura.FechaIngreso.TimeOfDay);
                miComando.Parameters.AddWithValue("descuento", factura.Descuento);
                miComando.Parameters.AddWithValue("limite", factura.FechaLimite);
                miComando.Parameters.AddWithValue("aplicaDescto", factura.AplicaDescuento);
                miComando.Parameters.AddWithValue("estado", factura.Estado);
               // if (!edicion)
               // {
                    miComando.Parameters.AddWithValue("serie", Convert.ToInt32(miDaoConsecutivo.Consecutivo("Serie")));
               //}
                miConexion.MiConexion.Open();
                miComando.ExecuteNonQuery();
                miConexion.MiConexion.Close();
                miComando.Dispose();
                miDaoConsecutivo.ActualizarConsecutivo("Serie");
                if (factura.Remision_)
                {
                    miDaoRemision.RemisionFacturada(Convert.ToInt32(factura.NumeroEdit));
                }
                foreach (ProductoFacturaProveedor producto in factura.Productos)
                {
                    if (edicion)
                    {
                        if (producto.Save)//indica que el registro es nuevo
                        {
                            miDaoProductoFactura.IngresarProductoFactura(producto);
                            if (factura.EstadoFactura.Id != 4)
                            {
                                miDaoInventario.ActualizarInventario(producto.Inventario, true);
                            }
                        }
                        else
                        {
                            miDaoProductoFactura.EditarProductoFactura(producto);
                        }
                    }
                    else
                    {
                        miDaoProductoFactura.IngresarProductoFactura(producto);
                        if (factura.EstadoFactura.Id != 4)
                        {
                            if (!factura.Remision_)
                            {
                                miDaoInventario.ActualizarInventario(producto.Inventario, true);
                            }
                        }
                    }
                }
                ///validar que consecutivo actualizo si contado o credito.
                /*if (factura.EstadoFactura.Id == 2)  //credito
                {
                    ActualizarConsecutivo(NumberIncrement(factura.Numero), false);
                    //ActualizarConsecutivo(NumberIncrement(factura.Numero), true);
                }
                else         //contado
                {
                    if (factura.EstadoFactura.Id == 1/* && !edicion*///)
                    /*{
                        ActualizarConsecutivo(NumberIncrement(factura.Numero), true);
                    }
                }*/

                if (!anutigua)
                {
                    if (factura.EstadoFactura.Id == 1 || factura.EstadoFactura.Id == 2)
                    {
                        ActualizarConsecutivo(NumberIncrement(factura.Numero), true);
                    }
                    else
                    {
                        if (factura.EstadoFactura.Id.Equals(3))
                        {
                            miDaoConsecutivo.ActualizarConsecutivo("FacturaPendiente");
                        }
                        else
                        {
                            miDaoConsecutivo.ActualizarConsecutivo("Cotizacion");
                        }
                    }
                }
               // else
               /* {
                    if (Convert.ToInt32(AppConfiguracion.ValorSeccion("factantigua")) < 99)
                    {
                        AppConfiguracion.SaveConfiguration
                            ("factantigua", IncrementaConsecutivo(AppConfiguracion.ValorSeccion("factantigua")));
                    }
                    else
                    {
                        AppConfiguracion.SaveConfiguration
                            ("factantigua", (Convert.ToInt32(AppConfiguracion.ValorSeccion("factantigua")) + 1).ToString());
                    }
                    //AppConfiguracion.ValorSeccion("factantigua");
                }*/
                foreach (FormaPago forma in factura.FormasDePago)
                {
                    if (forma.Valor != 0)
                    {
                        switch (forma.IdFormaPago)
                        {
                            case 5:
                                {
                                    var canje = new Canje();
                                    canje.NitCliente = factura.Proveedor.NitProveedor;
                                    canje.IdUsuario = factura.Usuario.Id;
                                    canje.IdCaja = factura.Caja.Id;
                                    canje.Fecha = DateTime.Now;
                                    canje.Concepto = "Fac # " + factura.Numero;
                                    canje.Valor = Convert.ToInt32(forma.Valor);
                                    canje.Estado = false;
                                    miDaoSaldo.IngresarCanje(canje);
                                    break;
                                }
                            case 6:
                                {
                                    miDaoBono.IngresarSeguimiento
                                    (factura.Proveedor.NitProveedor, Convert.ToInt32(forma.Valor), 
                                     factura.Caja.Id, factura.Usuario.Id, factura.Numero);
                                    break;
                                }
                            default:
                                {
                                    forma.Fecha = factura.FechaIngreso;
                                    forma.NumeroFactura = factura.Numero;
                                    forma.Usuario.Id = factura.Usuario.Id;
                                    forma.Caja.Id = factura.Caja.Id;
                                    miDaoPago.IngresarPagoAFactura(forma, true, false);
                                    break;
                                }
                        }
                        /*if (forma.IdFormaPago.Equals(5) || forma.IdFormaPago.Equals(6))
                        {
                            
                        }
                        else
                        {
                            forma.Fecha = factura.FechaIngreso;
                            forma.NumeroFactura = factura.Numero;
                            forma.Usuario.Id = factura.Usuario.Id;
                            forma.Caja.Id = factura.Caja.Id;
                            miDaoPago.IngresarPagoAFactura(forma, true);
                        }*/
                    }
                }
                if (factura.Retencion != null)
                {
                    factura.Retencion.Retencion.Rubro = factura.Numero;
                    if (!edicion)
                    {
                        miDaoRetencion.IngresarFacturaVentaRetencion(factura.Retencion);
                    }
                    else
                    {
                        miDaoRetencion.EditarFacturaVentaRetencion(factura.Retencion);
                    }
                }
            }
            catch (Exception ex)
            {
                if (edicion)
                {
                    throw new Exception(ErrorEditar + ex.Message);
                }
                else
                {
                    throw new Exception(ErrorIngresar + ex.Message);
                }
            }
            finally { miConexion.MiConexion.Close(); }
        }

        public string IncrementaConsecutivo(string numero)
        {
            var num = "";
            if (Convert.ToInt32(numero) >= 10)
            {
                num += "0" + (Convert.ToInt32(numero) + 1).ToString();
            }
            else
            {
                num += "00" + (Convert.ToInt32(numero) + 1).ToString();
            }
            return num;
        }

        public FacturaVenta FacturaDeVenta(string numero)
        {
            try
            {
                CargarComando("facturas_venta");
                miComando.Parameters.AddWithValue("numero", numero);
                miConexion.MiConexion.Open();
                NpgsqlDataReader miReader = miComando.ExecuteReader();
                var factura = new FacturaVenta();
                while (miReader.Read())
                {
                    factura.Numero = miReader.GetString(0);
                    factura.Proveedor.NitProveedor = miReader.GetString(1);
                    factura.Usuario.Id = miReader.GetInt32(2);
                    factura.Caja.Id = miReader.GetInt32(3);
                    factura.EstadoFactura.Id = miReader.GetInt32(4);
                    factura.FechaIngreso = miReader.GetDateTime(5);
                    //factura.Hora;
                    factura.Descuento = miReader.GetDouble(7);
                    factura.FechaLimite = miReader.GetDateTime(8);
                    factura.AplicaDescuento = miReader.GetBoolean(9);
                    factura.Estado = miReader.GetBoolean(10);
                }
                return factura;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al cargar la Factura de Venta.\n" + ex.Message);
            }
            finally { miConexion.MiConexion.Close(); }
        }

        /// <summary>
        /// Edita el cliente relacionado en la factura de venta.
        /// </summary>
        /// <param name="factura">Datos de la factura de venta a editar.</param>
        public void EditarCliente(FacturaVenta factura)
        {
            try
            {
                CargarComando(EditarCliente_);
                miComando.Parameters.AddWithValue("numero", factura.Numero);
                miComando.Parameters.AddWithValue("cliente", factura.Proveedor.NitProveedor);
                miConexion.MiConexion.Open();
                miComando.ExecuteNonQuery();
                miConexion.MiConexion.Close();
                miComando.Dispose();
            }
            catch (Exception ex)
            {
                throw new Exception(ErrorEditar + ex.Message);
            }
            finally { miConexion.MiConexion.Close(); }
        }

        public void EditarFactura(FacturaVenta factura)
        {
            try
            {
                var miDaoProducto = new DaoProductoFacturaVenta();
                var miDaoInventario = new DaoInventario();
                EditarCliente(factura);
                var productos = miDaoProducto.ProductoFacturaVenta(factura.Numero);
                foreach (DataRow producto in productos.Rows)
                {
                    var inventario = new Inventario
                    {
                        CodigoProducto = producto["Codigo"].ToString(),
                        IdMedida = Convert.ToInt32(producto["IdMedida"]),
                        IdColor = Convert.ToInt32(producto["IdColor"]),
                        Cantidad = Convert.ToDouble(producto["Cantidad"])
                    };
                    miDaoInventario.ActualizarInventario(inventario, false);
                    miDaoProducto.ElimnarProductoFacturaVenta(Convert.ToInt32(producto["Id"]));
                }
                foreach (ProductoFacturaProveedor producto in factura.Productos)
                {
                    miDaoProducto.IngresarProductoFactura(producto);
                    miDaoInventario.ActualizarInventario(producto.Inventario, true);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("ocurrió un error al editar los datos.\n" + ex.Message);
            }
            finally { miConexion.MiConexion.Close(); }
        }

        /// <summary>
        /// Retira los productos que fueron excluidos de la Factura de Venta.
        /// </summary>
        /// <param name="factura">Factura de Venta a analizar.</param>
        public void RetirarProductos(FacturaVenta factura, DaoProductoFacturaVenta miDao)
        {
            try
            {
                //var lstID = new List<int>();
                var productosDB = miDao.ProductoFacturaVenta(factura.NumeroEdit);
                foreach (DataRow pRow in productosDB.Rows)
                {
                    var existe = false;
                    foreach (var pfRow in factura.Productos)
                    {
                        if (pfRow.Id == Convert.ToInt32(pRow["Id"]))
                        {
                            existe = true;
                            break;
                        }
                        else
                        {
                            existe = false;
                        }
                    }
                    if (!existe)
                    {
                        miDao.ElimnarProductoFacturaVenta(Convert.ToInt32(pRow["Id"]));
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Incrementa en una unidad un número determinado.
        /// </summary>
        /// <param name="numero">Número a incrementar.</param>
        /// <returns></returns>
        private string NumberIncrement(string numero)
        {
            long num = 0;
            try
            {
                num = Convert.ToInt64(numero);
                num++;
                numero = Utilities.UseObject.CerosToLeft(numero) + num.ToString();
            }
            catch
            {
                var n = numero.Split('-');
                num = Convert.ToInt64(n[1]);
                num++;
                numero = n[0] + '-' + Utilities.UseObject.CerosToLeft(numero) +
                         num.ToString();
                n = null;
            }
            return numero;
        }

        /// <summary>
        /// Actualiza el registro del consecutivo de Factura de Venta.
        /// </summary>
        /// <param name="numero">Número a ingresar en la actualización del registro.</param>
        /// <param name="contado">Indica si se trata de un registro de Factura de contado o no.</param>
        public void ActualizarConsecutivo(string numero, bool contado)
        {
            try
            {
                CargarComando(ActualizarConsecutivo_);
                if (contado)
                {
                    miComando.Parameters.AddWithValue("concepto", "Factura");
                }
                else
                {
                    miComando.Parameters.AddWithValue("concepto", "FacturaCredito");
                }
                miComando.Parameters.AddWithValue("numero", numero);
                miConexion.MiConexion.Open();
                miComando.ExecuteNonQuery();
                miConexion.MiConexion.Close();
                miComando.Dispose();
            }
            catch (Exception ex)
            {
                throw new Exception(ErrorActualizaConsecutivo + ex.Message);
            }
            finally { miConexion.MiConexion.Close(); }
        }

        /// <summary>
        /// Obtiene los datos de la factura de venta para su impresión.
        /// </summary>
        /// <param name="numero">Número de la factura de venta.</param>
        /// <returns></returns>
        public DataSet PrintFacturaVenta(string numero)
        {
            var dataSet = new DataSet();
            try
            {
                CargarAdapter(PrintFacturaVenta_);
                miAdapter.SelectCommand.Parameters.AddWithValue("numero", numero);
                miAdapter.Fill(dataSet, "FacturaVenta");
                return dataSet;
            }
            catch (Exception ex)
            {
                throw new Exception(ErrorConsulta + ex.Message);
            }
        }

        /// <summary>
        /// Obtiene el resultado de la consulta de Factura de Venta por número.
        /// </summary>
        /// <param name="numero">Número de la Factura a consultar.</param>
        /// <returns></returns>
        public DataTable ConsultaNumero(string numero)
        {
            var tabla = new DataTable();
            try
            {
                CargarAdapter(ConsultaNumero_);
                miAdapter.SelectCommand.Parameters.AddWithValue("numero", numero);
                miAdapter.Fill(tabla);
                return tabla;
            }
            catch (Exception ex)
            {
                throw new Exception(ErrorConsulta + ex.Message);
            }
        }

        /// <summary>
        /// Obtiene el resultado de la consulta de Factura de Venta por Estado de la Factura.
        /// </summary>
        /// <param name="estado">Estado de la factura a consultar.</param>
        /// <param name="rowBase">Registro base para la consulta.</param>
        /// <param name="rowMax">Número de registros a recuperar.</param>
        /// <returns></returns>
        public DataTable ConsultaEstado(int estado, int rowBase, int rowMax)
        {
            var dataSet = new DataSet();
            try
            {
                CargarAdapter(ConsultaEstado_);
                miAdapter.SelectCommand.Parameters.AddWithValue("estado", estado);
                miAdapter.Fill(dataSet, rowBase, rowMax, "factura");
                return dataSet.Tables[0];
            }
            catch (Exception ex)
            {
                throw new Exception(ErrorConsulta + ex.Message);
            }
        }

        /// <summary>
        /// Obtiene el resultado de la consulta de Factura de Venta por Estado de la Factura.
        /// </summary>
        /// <param name="estado">Estado de la factura a consultar.</param>
        /// <returns></returns>
        public DataTable ConsultaEstado(int estado)
        {
            var tabla = new DataTable();
            try
            {
                CargarAdapter("consulta_factura_venta_activa_estado");
                miAdapter.SelectCommand.Parameters.AddWithValue("estado", estado);
                miAdapter.Fill(tabla);
                return tabla;
            }
            catch (Exception ex)
            {
                throw new Exception(ErrorConsulta + ex.Message);
            }
        }

        /// <summary>
        /// Obtiene el total de registros de resultado de la consulta de Factura de Venta 
        /// por Estado de la Factura.
        /// </summary>
        /// <param name="estado">Estado de la factura a consultar.</param>
        /// <returns></returns>
        public long GetRowsConsultaEstado(int estado)
        {
            try
            {
                CargarComando(GetRowsConsultaEstado_);
                miComando.Parameters.AddWithValue("estado", estado);
                miConexion.MiConexion.Open();
                var rows = Convert.ToInt64(miComando.ExecuteScalar());
                miConexion.MiConexion.Close();
                miComando.Dispose();
                return rows;
            }
            catch (Exception ex)
            {
                throw new Exception(ErrorGetRows + ex.Message);
            }
            finally { miConexion.MiConexion.Close(); }
        }

        /// <summary>
        /// Obtiene el resultado de la consulta de Factura de Venta por Estado de la Factura 
        /// y fecha de ingreso de la misma.
        /// </summary>
        /// <param name="estado">Estado de la factura a consultar.</param>
        /// <param name="fecha">Fecha de ingreso a consultar la factura.</param>
        /// <param name="rowBase">Registro base para la consulta.</param>
        /// <param name="rowMax">Número de registros a recuperar.</param>
        /// <returns></returns>
        public DataTable ConsultaEstadoFechaIngreso
            (int estado, DateTime fecha, int rowBase, int rowMax)
        {
            var dataSet = new DataSet();
            try
            {
                CargarAdapter(ConsultaEstadoFechaIngreso_);
                miAdapter.SelectCommand.Parameters.AddWithValue("estado", estado);
                miAdapter.SelectCommand.Parameters.AddWithValue("fecha", fecha);
                miAdapter.Fill(dataSet, rowBase, rowMax, "factura");
                return dataSet.Tables[0];
            }
            catch (Exception ex)
            {
                throw new Exception(ErrorConsulta + ex.Message);
            }
        }

        /// <summary>
        /// Obtiene el total de registros de la consulta de Factura de Venta por Estado de la Factura 
        /// y fecha de ingreso de la misma.
        /// </summary>
        /// <param name="estado">Estado de la factura a consultar.</param>
        /// <param name="fecha">Fecha de ingreso a consultar la factura.</param>
        /// <returns></returns>
        public long GetRowsConsultaEstadoFechaIngreso(int estado, DateTime fecha)
        {
            try
            {
                CargarComando(GetRowsConsultaEstadoFechaIngreso_);
                miComando.Parameters.AddWithValue("estado", estado);
                miComando.Parameters.AddWithValue("fecha", fecha);
                miConexion.MiConexion.Open();
                var rows = Convert.ToInt64(miComando.ExecuteScalar());
                miConexion.MiConexion.Close();
                miComando.Dispose();
                return rows;
            }
            catch (Exception ex)
            {
                throw new Exception(ErrorGetRows + ex.Message);
            }
            finally { miConexion.MiConexion.Close(); }
        }

        /// <summary>
        /// Obtiene el resultado de la consulta de Factura de Venta por Estado de la Factura 
        /// y un periodo de fechas para la consulta en la fecha de ingreso.
        /// </summary>
        /// <param name="estado">Estado de la factura a consultar.</param>
        /// <param name="fecha1">Primer rango de fecha.</param>
        /// <param name="fecha2">Segundo rango de fecha.</param>
        /// <param name="rowBase">Registro base para la consulta.</param>
        /// <param name="rowMax">Número de registros a recuperar.</param>
        /// <returns></returns>
        public DataTable ConsultaEstadoPeriodoIngreso
            (int estado, DateTime fecha1, DateTime fecha2, int rowBase, int rowMax)
        {
            var dataSet = new DataSet();
            try
            {
                CargarAdapter(ConsultaEstadoPeriodoIngreso_);
                miAdapter.SelectCommand.Parameters.AddWithValue("estado", estado);
                miAdapter.SelectCommand.Parameters.AddWithValue("fecha1", fecha1);
                miAdapter.SelectCommand.Parameters.AddWithValue("fecha2", fecha2);
                miAdapter.Fill(dataSet, rowBase, rowMax, "factura");
                return dataSet.Tables[0];
            }
            catch (Exception ex)
            {
                throw new Exception(ErrorConsulta + ex.Message);
            }
        }

        public DataTable ConsultaEstadoPeriodoIngreso
                         (int estado, DateTime fecha1, DateTime fecha2)
        {
            var tabla = new DataTable();
            try
            {
                CargarAdapter(ConsultaEstadoPeriodoIngreso_);
                miAdapter.SelectCommand.Parameters.AddWithValue("estado", estado);
                miAdapter.SelectCommand.Parameters.AddWithValue("fecha1", fecha1);
                miAdapter.SelectCommand.Parameters.AddWithValue("fecha2", fecha2);
                miAdapter.Fill(tabla);
                return tabla;
            }
            catch (Exception ex)
            {
                throw new Exception(ErrorConsulta + ex.Message);
            }
        }

        /// <summary>
        /// Obtiene el total de registros de la consulta de Factura de Venta por Estado de la Factura 
        /// y un periodo de fechas para la consulta en la fecha de ingreso.
        /// </summary>
        /// <param name="estado">Estado de la factura a consultar.</param>
        /// <param name="fecha1">Primer rango de fecha.</param>
        /// <param name="fecha2">Segundo rango de fecha.</param>
        /// <returns></returns>
        public long GetRowsConsultaEstadoPeriodoIngreso
            (int estado, DateTime fecha1, DateTime fecha2)
        {
            try
            {
                CargarComando(GetRowsConsultaEstadoPeriodoIngreso_);
                miComando.Parameters.AddWithValue("estado", estado);
                miComando.Parameters.AddWithValue("fecha1", fecha1);
                miComando.Parameters.AddWithValue("fecha2", fecha2);
                miConexion.MiConexion.Open();
                var rows = Convert.ToInt64(miComando.ExecuteScalar());
                miConexion.MiConexion.Close();
                miComando.Dispose();
                return rows;
            }
            catch (Exception ex)
            {
                throw new Exception(ErrorGetRows + ex.Message);
            }
            finally { miConexion.MiConexion.Close(); }
        }

        /// <summary>
        /// Obtiene el resultado de la consulta de Factura de Venta por Cliente 
        /// relacionado con la misma.
        /// </summary>
        /// <param name="cliente">Cliente a consultar factura de venta.</param>
        /// <param name="rowBase">Registro base para la consulta.</param>
        /// <param name="rowMax">Número de registros a recuperar.</param>
        /// <returns></returns>
        public DataTable ConsultaPorCliente(string cliente, int rowBase, int rowMax)
        {
            var dataSet = new DataSet();
            try
            {
                CargarAdapter(ConsultaPorCliente_);
                miAdapter.SelectCommand.Parameters.AddWithValue("cliente", cliente);
                miAdapter.Fill(dataSet, rowBase, rowMax, "factura");
                return dataSet.Tables[0];
            }
            catch (Exception ex)
            {
                throw new Exception(ErrorConsulta + ex.Message);
            }
        }

        public DataTable ConsultaActivasPorCliente(string cliente)
        {
            var tabla = new DataTable();
            try
            {
                CargarAdapter("facturas_activa_cliente");
                miAdapter.SelectCommand.Parameters.AddWithValue("cliente", cliente);
                miAdapter.Fill(tabla);
                return tabla;
            }
            catch (Exception ex)
            {
                throw new Exception(ErrorConsulta + ex.Message);
            }
        }

        /// <summary>
        /// Obtiene el total de registros de la consulta de de Factura de Venta por Cliente 
        /// relacionado con la misma.
        /// </summary>
        /// <param name="cliente">Cliente a consultar factura de venta.</param>
        /// <returns></returns>
        public long GetRowsConsultaPorCliente(string cliente)
        {
            try
            {
                CargarComando(GetRowsConsultaPorCliente_);
                miComando.Parameters.AddWithValue("cliente", cliente);
                miConexion.MiConexion.Open();
                var rows = Convert.ToInt64(miComando.ExecuteScalar());
                miConexion.MiConexion.Close();
                miComando.Dispose();
                return rows;
            }
            catch (Exception ex)
            {
                throw new Exception(ErrorGetRows + ex.Message);
            }
            finally { miConexion.MiConexion.Close(); }
        }

        /// <summary>
        /// Obtiene el resultado de la consulta de Factura de Venta por estado y Cliente.
        /// </summary>
        /// <param name="estado">Estado de la factura a consultar.</param>
        /// <param name="cliente">Cliente a consultar factura de venta.</param>
        /// <param name="rowBase">Registro base para la consulta.</param>
        /// <param name="rowMax">Número de registros a recuperar.</param>
        /// <returns></returns>
        public DataTable ConsultaPorEstadoYcliente
            (int estado, string cliente, int rowBase, int rowMax)
        {
            var dataSet = new DataSet();
            try
            {
                CargarAdapter(ConsultaPorEstadoYcliente_);
                miAdapter.SelectCommand.Parameters.AddWithValue("estado", estado);
                miAdapter.SelectCommand.Parameters.AddWithValue("cliente", cliente);
                miAdapter.Fill(dataSet, rowBase, rowMax, "factura");
                return dataSet.Tables[0];
            }
            catch (Exception ex)
            {
                throw new Exception(ErrorConsulta + ex.Message);
            }
        }

       /* public DataTable ConsultaPorEstadoYcliente(int estado, string cliente)
        {
            try
            {
                var tabla = new DataTable();
                CargarAdapter(ConsultaPorEstadoYcliente_);
                miAdapter.SelectCommand.Parameters.AddWithValue("estado", estado);
                miAdapter.SelectCommand.Parameters.AddWithValue("cliente", cliente);
                miAdapter.Fill(tabla);
                return tabla;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al consultar los clientes." + ex.Message);
            }
        }*/

        /// <summary>
        /// Obtiene el total de registros de la consulta de Factura de Venta por estado y Cliente.
        /// </summary>
        /// <param name="estado">Estado de la factura a consultar.</param>
        /// <param name="cliente">Cliente a consultar factura de venta.</param>
        /// <returns></returns>
        public long GetRowsConsultaPorEstadoYcliente(int estado, string cliente)
        {
            try
            {
                CargarComando(GetRowsConsultaPorEstadoYcliente_);
                miComando.Parameters.AddWithValue("estado", estado);
                miComando.Parameters.AddWithValue("cliente", cliente);
                miConexion.MiConexion.Open();
                var rows = Convert.ToInt64(miComando.ExecuteScalar());
                miConexion.MiConexion.Close();
                miComando.Dispose();
                return rows;
            }
            catch (Exception ex)
            {
                throw new Exception(ErrorGetRows + ex.Message);
            }
            finally { miConexion.MiConexion.Close(); }
        }

        /// <summary>
        /// Obtiene el resultado de la consulta de Factura de Venta por estado y Cliente.
        /// </summary>
        /// <param name="estado">Estado de la factura a consultar.</param>
        /// <param name="cliente">Cliente a consultar factura de venta.</param>
        /// <returns></returns>
        public DataTable ConsultaPorEstadoYcliente(int estado, string cliente)
        {
            var tabla = new DataTable();
            try
            {
                CargarAdapter(ConsultaPorEstadoYcliente_);
                miAdapter.SelectCommand.Parameters.AddWithValue("estado", estado);
                miAdapter.SelectCommand.Parameters.AddWithValue("cliente", cliente);
                miAdapter.Fill(tabla);
                return tabla;
            }
            catch (Exception ex)
            {
                throw new Exception(ErrorConsulta + ex.Message);
            }
        }

        /// <summary>
        /// Obtiene el resultado de la consulta de Factura de Venta por Cliente 
        /// y fecha de ingreso de la misma.
        /// </summary>
        /// <param name="cliente">Cliente a consultar factura de venta.</param>
        /// <param name="fecha">Fecha de ingreso a consultar la factura.</param>
        /// <param name="rowBase">Registro base para la consulta.</param>
        /// <param name="rowMax">Número de registros a recuperar.</param>
        /// <returns></returns>
        public DataTable ConsultaPorClienteIngreso
            (string cliente, DateTime fecha, int rowBase, int rowMax)
        {
            var dataSet = new DataSet();
            try
            {
                CargarAdapter(ConsultaPorClienteIngreso_);
                miAdapter.SelectCommand.Parameters.AddWithValue("cliente", cliente);
                miAdapter.SelectCommand.Parameters.AddWithValue("fecha", fecha);
                miAdapter.Fill(dataSet, rowBase, rowMax, "factura");
                return dataSet.Tables[0];
            }
            catch (Exception ex)
            {
                throw new Exception(ErrorConsulta + ex.Message);
            }
        }

        /// <summary>
        /// Obtiene el total de registros de la consulta de Factura de Venta por Cliente 
        /// y fecha de ingreso de la misma.
        /// </summary>
        /// <param name="cliente">Cliente a consultar factura de venta.</param>
        /// <param name="fecha">Fecha de ingreso a consultar la factura.</param>
        /// <returns></returns>
        public long GetRowsConsultaPorClienteIngreso(string cliente, DateTime fecha)
        {
            try
            {
                CargarComando(GetRowsConsultaPorClienteIngreso_);
                miComando.Parameters.AddWithValue("cliente", cliente);
                miComando.Parameters.AddWithValue("fecha", fecha);
                miConexion.MiConexion.Open();
                var rows = Convert.ToInt64(miComando.ExecuteScalar());
                miConexion.MiConexion.Close();
                miComando.Dispose();
                return rows;
            }
            catch (Exception ex)
            {
                throw new Exception(ErrorGetRows + ex.Message);
            }
            finally { miConexion.MiConexion.Close(); }
        }

        /// <summary>
        /// Obtiene el resultado de la consulta de Factura de Venta por Estado, 
        /// Cliente y fecha de ingreso.
        /// </summary>
        /// <param name="estado">Estado de la factura a consultar.</param>
        /// <param name="cliente">Cliente a consultar factura de venta.</param>
        /// <param name="fecha">Fecha de ingreso a consultar la factura.</param>
        /// <returns></returns>
        public DataTable ConsultaPorEstadoClienteIngreso
            (int estado, string cliente, DateTime fecha)
        {
            var dataTable = new DataTable();
            try
            {
                CargarAdapter(ConsultaPorEstadoClienteIngreso_);
                miAdapter.SelectCommand.Parameters.AddWithValue("estado", estado);
                miAdapter.SelectCommand.Parameters.AddWithValue("cliente", cliente);
                miAdapter.SelectCommand.Parameters.AddWithValue("fecha", fecha);
                miAdapter.Fill(dataTable);
                return dataTable;
            }
            catch (Exception ex)
            {
                throw new Exception(ErrorConsulta + ex.Message);
            }
        }

        /// <summary>
        /// Obtiene el resultado de la consulta de Factura de Venta por Cliente 
        /// en un periodo de fechas de ingreso.
        /// </summary>
        /// <param name="cliente">Cliente a consultar factura de venta.</param>
        /// <param name="fecha1">Primer rango de fecha.</param>
        /// <param name="fecha2">Segundo rango de fecha.</param>
        /// <param name="rowBase">Registro base para la consulta.</param>
        /// <param name="rowMax">Número de registros a recuperar.</param>
        /// <returns></returns>
        public DataTable ConsultaPorClientePeriodoIngreso
            (string cliente, DateTime fecha1, DateTime fecha2, int rowBase, int rowMax)
        {
            var dataSet = new DataSet();
            try
            {
                CargarAdapter(ConsultaPorClientePeriodoIngreso_);
                miAdapter.SelectCommand.Parameters.AddWithValue("cliente", cliente);
                miAdapter.SelectCommand.Parameters.AddWithValue("fecha1", fecha1);
                miAdapter.SelectCommand.Parameters.AddWithValue("fecha2", fecha2);
                miAdapter.Fill(dataSet, rowBase, rowMax, "factura");
                return dataSet.Tables[0];
            }
            catch (Exception ex)
            {
                throw new Exception(ErrorConsulta + ex.Message);
            }
        }

        /// <summary>
        /// Obtiene el total de registros de la consulta de Factura de Venta por Cliente 
        /// en un periodo de fechas de ingreso.
        /// </summary>
        /// <param name="cliente">Cliente a consultar factura de venta.</param>
        /// <param name="fecha1">Primer rango de fecha.</param>
        /// <param name="fecha2">Segundo rango de fecha.</param>
        /// <returns></returns>
        public long GetRowsConsultaPorClientePeriodoIngreso
            (string cliente, DateTime fecha1, DateTime fecha2)
        {
            try
            {
                CargarComando(GetRowsConsultaPorClientePeriodoIngreso_);
                miComando.Parameters.AddWithValue("cliente", cliente);
                miComando.Parameters.AddWithValue("fecha1", fecha1);
                miComando.Parameters.AddWithValue("fecha2", fecha2);
                miConexion.MiConexion.Open();
                var rows = Convert.ToInt64(miComando.ExecuteScalar());
                miConexion.MiConexion.Close();
                miComando.Dispose();
                return rows;
            }
            catch (Exception ex)
            {
                throw new Exception(ErrorGetRows + ex.Message);
            }
            finally { miConexion.MiConexion.Close(); }
        }

        /// <summary>
        /// Obtiene el resultado de la consulta de Factura de Venta por Estado, 
        /// Cliente y un periodo entre fechas de ingreso.
        /// </summary>
        /// <param name="estado">Estado de la factura a consultar.</param>
        /// <param name="cliente">Cliente a consultar factura de venta.</param>
        /// <param name="fecha1">Primer rango de fecha.</param>
        /// <param name="fecha2">Segundo rango de fecha.</param>
        /// <param name="rowBase">Registro base para la consulta.</param>
        /// <param name="rowMax">Número de registros a recuperar.</param>
        /// <returns></returns>
        public DataTable ConsultaPorEstadoClientePeriodoIngreso
            (int estado, string cliente, DateTime fecha1, DateTime fecha2, int rowBase, int rowMax)
        {
            var dataSet = new DataSet();
            try
            {
                CargarAdapter
                    (ConsultaPorEstadoClientePeriodoIngreso_);
                miAdapter.SelectCommand.Parameters.AddWithValue("estado", estado);
                miAdapter.SelectCommand.Parameters.AddWithValue("cliente", cliente);
                miAdapter.SelectCommand.Parameters.AddWithValue("fecha1", fecha1);
                miAdapter.SelectCommand.Parameters.AddWithValue("fecha2", fecha2);
                miAdapter.Fill(dataSet, rowBase, rowMax, "factura");
                return dataSet.Tables[0];
            }
            catch (Exception ex)
            {
                throw new Exception(ErrorConsulta + ex.Message);
            }
        }

        /// <summary>
        /// Obtiene el total de registros de la consulta de Factura de Venta por Estado, 
        /// Cliente y un periodo entre fechas de ingreso.
        /// </summary>
        /// <param name="estado">Estado de la factura a consultar.</param>
        /// <param name="cliente">Cliente a consultar factura de venta.</param>
        /// <param name="fecha1">Primer rango de fecha.</param>
        /// <param name="fecha2">Segundo rango de fecha.</param>
        /// <returns></returns>
        public long GetRowsEstadoClientePeriodoIngreso
            (int estado, string cliente, DateTime fecha1, DateTime fecha2)
        {
            try
            {
                CargarComando(GetRowsEstadoClientePeriodoIngreso_);
                miComando.Parameters.AddWithValue("estado", estado);
                miComando.Parameters.AddWithValue("cliente", cliente);
                miComando.Parameters.AddWithValue("fecha1", fecha1);
                miComando.Parameters.AddWithValue("fecha2", fecha2);
                miConexion.MiConexion.Open();
                var rows = Convert.ToInt64(miComando.ExecuteScalar());
                miConexion.MiConexion.Close();
                miComando.Dispose();
                return rows;
            }
            catch (Exception ex)
            {
                throw new Exception(ErrorGetRows + ex.Message);
            }
            finally { miConexion.MiConexion.Close(); }
        }

        /// <summary>
        /// Obtiene el resultado de la consulta de las Facturas de Venta 
        /// que se encuentran en mora hasta la fecha actual.
        /// </summary>
        /// <param name="estado">Estado (Crédito) de la factura a consultar.</param>
        /// <param name="fecha">Fecha actual de la consulta.</param>
        /// <param name="rowBase">Registro base para la consulta.</param>
        /// <param name="rowMax">Número de registros a recuperar.</param>
        /// <returns></returns>
        public DataTable ConsultaEnMora
            (int estado, DateTime fecha, int rowBase, int rowMax)
        {
            var dataSet = new DataSet();
            try
            {
                CargarAdapter(ConsultaEnMora_);
                miAdapter.SelectCommand.Parameters.AddWithValue("estado", estado);
                miAdapter.SelectCommand.Parameters.AddWithValue("fecha", fecha);
                miAdapter.Fill(dataSet, rowBase, rowMax, "factura");
                return dataSet.Tables[0];
            }
            catch (Exception ex)
            {
                throw new Exception(ErrorConsulta + ex.Message);
            }
        }

        /// <summary>
        /// Obtiene el total de registros de la consulta de Facturas de Venta 
        /// que se encuentran en mora hasta la fecha actual.
        /// </summary>
        /// <param name="estado">Estado (Crédito) de la factura a consultar.</param>
        /// <param name="fecha">Fecha actual de la consulta.</param>
        /// <returns></returns>
        public long GetRowsConsultaEnMora(int estado, DateTime fecha)
        {
            try
            {
                CargarComando(GetRowsConsultaEnMora_);
                miComando.Parameters.AddWithValue("estado", estado);
                miComando.Parameters.AddWithValue("fecha", fecha);
                miConexion.MiConexion.Open();
                var rows = Convert.ToInt64(miComando.ExecuteScalar());
                miConexion.MiConexion.Close();
                miComando.Dispose();
                return rows;
            }
            catch (Exception ex)
            {
                throw new Exception(ErrorGetRows + ex.Message);
            }
            finally { miConexion.MiConexion.Close(); }
        }

        /// <summary>
        /// Obtiene el resultado de la consulta de las Facturas de Venta 
        /// de un Cliente que se encuentran en mora hasta la fecha actual.
        /// </summary>
        /// <param name="cliente">Cliente a consultar factura de venta.</param>
        /// <param name="estado">Estado (Crédito) de la factura a consultar.</param>
        /// <param name="fecha">Fecha actual de la consulta.</param>
        /// <param name="rowBase">Registro base para la consulta.</param>
        /// <param name="rowMax">Número de registros a recuperar.</param>
        /// <returns></returns>
        public DataTable ConsultaClienteEnMora
            (string cliente, int estado, DateTime fecha, int rowBase, int rowMax)
        {
            var dataSet = new DataSet();
            try
            {
                CargarAdapter(ConsultaClienteEnMora_);
                miAdapter.SelectCommand.Parameters.AddWithValue("cliente", cliente);
                miAdapter.SelectCommand.Parameters.AddWithValue("estado", estado);
                miAdapter.SelectCommand.Parameters.AddWithValue("fecha", fecha);
                miAdapter.Fill(dataSet, rowBase, rowMax, "factura");
                return dataSet.Tables[0];
            }
            catch (Exception ex)
            {
                throw new Exception(ErrorConsulta + ex.Message);
            }
        }

        /// <summary>
        /// Obtiene el total de registros de la consulta de las Facturas de Venta 
        /// de un Cliente que se encuentran en mora hasta la fecha actual.
        /// </summary>
        /// <param name="cliente">Cliente a consultar factura de venta.</param>
        /// <param name="estado">Estado (Crédito) de la factura a consultar.</param>
        /// <param name="fecha">Fecha actual de la consulta.</param>
        /// <returns></returns>
        public long GetRowsConsultaClienteEnMora
            (string cliente, int estado, DateTime fecha)
        {
            try
            {
                CargarComando(GetRowsConsultaClienteEnMora_);
                miComando.Parameters.AddWithValue("cliente", cliente);
                miComando.Parameters.AddWithValue("estado", estado);
                miComando.Parameters.AddWithValue("fecha", fecha);
                miConexion.MiConexion.Open();
                var rows = Convert.ToInt64(miComando.ExecuteScalar());
                miConexion.MiConexion.Close();
                miComando.Dispose();
                return rows;
            }
            catch (Exception ex)
            {
                throw new Exception(ErrorGetRows + ex.Message);
            }
            finally { miConexion.MiConexion.Close(); }
        }

        /// <summary>
        /// Obtiene el resultado de la consulta de las Facturas de Venta 
        /// con un tope en la fecha límite.
        /// </summary>
        /// <param name="estado">Estado (Crédito) de la factura a consultar.</param>
        /// <param name="fecha">Fecha límite hasta donde se quiere consultar.</param>
        /// <param name="rowBase">Registro base para la consulta.</param>
        /// <param name="rowMax">Número de registros a recuperar.</param>
        /// <returns></returns>
        public DataTable ConsultaEstadoFechaLimite
                         (int estado, DateTime fecha, int rowBase, int rowMax)
        {
            var dataSet = new DataSet();
            try
            {
                CargarAdapter(ConsultaEstadoFechaLimite_);
                miAdapter.SelectCommand.Parameters.AddWithValue("estado", estado);
                miAdapter.SelectCommand.Parameters.AddWithValue("fecha", fecha);
                miAdapter.Fill(dataSet, rowBase, rowMax, "factura");
                return dataSet.Tables[0];
            }
            catch (Exception ex)
            {
                throw new Exception(ErrorConsulta + ex.Message);
            }
        }

        /// <summary>
        /// Obtiene el total de registros de la consulta de las Facturas de Venta 
        /// con un tope en la fecha límite.
        /// </summary>
        /// <param name="estado">Estado (Crédito) de la factura a consultar.</param>
        /// <param name="fecha">Fecha límite hasta donde se quiere consultar.</param>
        /// <returns></returns>
        public long GetRowsConsultaEstadoFechaLimite(int estado, DateTime fecha)
        {
            try
            {
                CargarComando(GetRowsConsultaEstadoFechaLimite_);
                miComando.Parameters.AddWithValue("estado", estado);
                miComando.Parameters.AddWithValue("fecha", fecha);
                miConexion.MiConexion.Open();
                var rows = Convert.ToInt64(miComando.ExecuteScalar());
                miConexion.MiConexion.Close();
                miComando.Dispose();
                return rows;
            }
            catch (Exception ex)
            {
                throw new Exception(ErrorGetRows + ex.Message);
            }
            finally { miConexion.MiConexion.Close(); }
        }

        /// <summary>
        /// Obtiene el resultado de la consulta de las Facturas de Venta 
        /// en crédito en un periodo de fechas.
        /// </summary>
        /// <param name="estado">Estado (Crédito) de la factura a consultar.</param>
        /// <param name="fecha1">Primer rango de fecha.</param>
        /// <param name="fecha2">Segundo rango de fecha.</param>
        /// <param name="rowBase">Registro base para la consulta.</param>
        /// <param name="rowMax">Número de registros a recuperar.</param>
        /// <returns></returns>
        public DataTable ConsultaCreditoPeriodo
            (int estado, DateTime fecha1, DateTime fecha2, int rowBase, int rowMax)
        {
            var dataSet = new DataSet();
            try
            {
                CargarAdapter(ConsultaCreditoPeriodo_);
                miAdapter.SelectCommand.Parameters.AddWithValue("estado", estado);
                miAdapter.SelectCommand.Parameters.AddWithValue("fecha1", fecha1);
                miAdapter.SelectCommand.Parameters.AddWithValue("fecha2", fecha2);
                miAdapter.Fill(dataSet, rowBase, rowMax, "factura");
                return dataSet.Tables[0];
            }
            catch (Exception ex)
            {
                throw new Exception(ErrorConsulta + ex.Message);
            }
        }

        /// <summary>
        /// Obtiene el total de registros de la consulta de las Facturas de Venta 
        /// en crédito en un periodo de fechas.
        /// </summary>
        /// <param name="estado">Estado (Crédito) de la factura a consultar.</param>
        /// <param name="fecha1">Primer rango de fecha.</param>
        /// <param name="fecha2">Segundo rango de fecha.</param>
        /// <returns></returns>
        public long GetRowsConsultaCreditoPeriodo(int estado, DateTime fecha1, DateTime fecha2)
        {
            try
            {
                CargarComando(GetRowsConsultaCreditoPeriodo_);
                miComando.Parameters.AddWithValue("estado", estado);
                miComando.Parameters.AddWithValue("fecha1", fecha1);
                miComando.Parameters.AddWithValue("fecha2", fecha2);
                miConexion.MiConexion.Open();
                var rows = Convert.ToInt64(miComando.ExecuteScalar());
                miConexion.MiConexion.Close();
                miComando.Dispose();
                return rows;
            }
            catch (Exception ex)
            {
                throw new Exception(ErrorGetRows + ex.Message);
            }
            finally { miConexion.MiConexion.Close(); }
        }

        /// <summary>
        /// Obtiene el resultado de la consulta de las Facturas de Venta 
        /// en Crédito de un Cliente.
        /// </summary>
        /// <param name="cliente">Cliente a consultar factura de venta.</param>
        /// <param name="estado">Estado (Crédito) de la factura a consultar.</param>
        /// <param name="fecha">Fecha límite hasta donde se quiere consultar.</param>
        /// <param name="rowBase">Registro base para la consulta.</param>
        /// <param name="rowMax">Número de registros a recuperar.</param>
        /// <returns></returns>
        public DataTable ConsultaClienteCreditoLimite
            (string cliente, int estado, DateTime fecha, int rowBase, int rowMax)
        {
            var dataSet = new DataSet();
            try
            {
                CargarAdapter(ConsultaClienteCreditoLimite_);
                miAdapter.SelectCommand.Parameters.AddWithValue("cliente", cliente);
                miAdapter.SelectCommand.Parameters.AddWithValue("estado", estado);
                miAdapter.SelectCommand.Parameters.AddWithValue("fecha", fecha);
                miAdapter.Fill(dataSet, rowBase, rowMax, "factura");
                return dataSet.Tables[0];
            }
            catch (Exception ex)
            {
                throw new Exception(ErrorConsulta + ex.Message);
            }
        }

        /// <summary>
        /// Obtiene el total de registros de la consulta de las Facturas de Venta 
        /// en Crédito de un Cliente.
        /// </summary>
        /// <param name="cliente">Cliente a consultar factura de venta.</param>
        /// <param name="estado">Estado (Crédito) de la factura a consultar.</param>
        /// <param name="fecha">Fecha límite hasta donde se quiere consultar.</param>
        /// <returns></returns>
        public long GetRowsConsultaClienteCreditoLimite(string cliente, int estado, DateTime fecha)
        {
            try
            {
                CargarComando(GetRowsConsultaClienteCreditoLimite_);
                miComando.Parameters.AddWithValue("cliente", cliente);
                miComando.Parameters.AddWithValue("estado", estado);
                miComando.Parameters.AddWithValue("fecha", fecha);
                miConexion.MiConexion.Open();
                var rows = Convert.ToInt64(miComando.ExecuteScalar());
                miConexion.MiConexion.Close();
                miComando.Dispose();
                return rows;
            }
            catch (Exception ex)
            {
                throw new Exception(ErrorGetRows + ex.Message);
            }
            finally { miConexion.MiConexion.Close(); }
        }

        /// <summary>
        /// Obtiene el resultado de la consulta de las Facturas de Venta 
        /// en Crédito de un Cliente en un periodo determinado.
        /// </summary>
        /// <param name="cliente">Cliente a consultar factura de venta.</param>
        /// <param name="estado">Estado (Crédito) de la factura a consultar.</param>
        /// <param name="fecha1">Primer rango de fecha.</param>
        /// <param name="fecha2">Segundo rango de fecha.</param>
        /// <param name="rowBase">Registro base para la consulta.</param>
        /// <param name="rowMax">Número de registros a recuperar.</param>
        /// <returns></returns>
        public DataTable ConsultaClienteCreditoLimitePeriodo
            (string cliente, int estado, DateTime fecha1, DateTime fecha2, int rowBase, int rowMax)
        {
            var dataSet = new DataSet();
            try
            {
                CargarAdapter(ConsultaClienteCreditoLimitePeriodo_);
                miAdapter.SelectCommand.Parameters.AddWithValue("cliente", cliente);
                miAdapter.SelectCommand.Parameters.AddWithValue("estado", estado);
                miAdapter.SelectCommand.Parameters.AddWithValue("fecha1", fecha1);
                miAdapter.SelectCommand.Parameters.AddWithValue("fecha2", fecha2);
                miAdapter.Fill(dataSet, rowBase, rowMax, "factura");
                return dataSet.Tables[0];
            }
            catch (Exception ex)
            {
                throw new Exception(ErrorConsulta + ex.Message);
            }
        }

        /// <summary>
        /// Obtiene el total de registros de la consulta de las Facturas de Venta 
        /// en Crédito de un Cliente en un periodo determinado.
        /// </summary>
        /// <param name="cliente">Cliente a consultar factura de venta.</param>
        /// <param name="estado">Estado (Crédito) de la factura a consultar.</param>
        /// <param name="fecha1">Primer rango de fecha.</param>
        /// <param name="fecha2">Segundo rango de fecha.</param>
        /// <returns></returns>
        public long GetRowsConsultaClienteCreditoLimitePeriodo
            (string cliente, int estado, DateTime fecha1, DateTime fecha2)
        {
            try
            {
                CargarComando(GetRowsConsultaClienteCreditoLimitePeriodo_);
                miComando.Parameters.AddWithValue("cliente", cliente);
                miComando.Parameters.AddWithValue("estado", estado);
                miComando.Parameters.AddWithValue("fecha1", fecha1);
                miComando.Parameters.AddWithValue("fecha2", fecha2);
                miConexion.MiConexion.Open();
                var rows = Convert.ToInt64(miComando.ExecuteScalar());
                miConexion.MiConexion.Close();
                miComando.Dispose();
                return rows;
            }
            catch (Exception ex)
            {
                throw new Exception(ErrorGetRows + ex.Message);
            }
            finally { miConexion.MiConexion.Close(); }
        }

        public DataTable ClienteDeFacutura(string numero)
        {
            var tabla = new DataTable();
            try
            {
                CargarAdapter("cliente_de_facutura");
                miAdapter.SelectCommand.Parameters.AddWithValue("numero", numero);
                miAdapter.Fill(tabla);
                return tabla;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al consultar el cliente.\n" + ex.Message);
            }
        }

        /// <summary>
        /// Obtiene el saldo pendiente de un cliente por todas sus factura.
        /// </summary>
        /// <param name="idEstado">Estdo de la factura (Crédito).</param>
        /// <param name="nitCliente">Nit del Cliente a consultar.</param>
        /// <returns></returns>
        public int SaldoPorCliente(int idEstado, string nitCliente)
        {
            var daoDevolucion = new DaoDevolucion();
            int totalFact = 0;
            int pagosFact = 0;
            int saldoDev = 0;
            int saldo = 0;
            int saldoTotal = 0;
            var factura = ConsultaPorEstadoYcliente(idEstado, nitCliente);
            foreach (DataRow fRow in factura.Rows)
            {
                var producto = ProductoFacturaVenta(fRow["numero"].ToString(), Convert.ToBoolean(fRow["descto"]));
                totalFact = Convert.ToInt32(producto.AsEnumerable().Sum(t => t.Field<double>("Valor")));
                pagosFact = GetTotalFormasDePagoDeFacturaVenta(fRow["numero"].ToString());
                saldoDev = daoDevolucion.SaldoDevolucionVenta(fRow["numero"].ToString());
                if (totalFact > (pagosFact + saldoDev))
                {
                    saldo = totalFact - (pagosFact + saldoDev);
                    //}
                    saldoTotal = saldoTotal + saldo;
                }
                //saldo = 0;
            }
            return saldoTotal;
        }

        /// <summary>
        /// Obtiene el saldo pendiente de todas las facturas a crédito.
        /// </summary>
        /// <param name="idEstado">Estado de la factura (Crédito).</param>
        /// <returns></returns>
        public int SaldoTotalCredito(int idEstado)
        {
            int totalFact = 0;
            int pagosFact = 0;
            int saldo = 0;
            int saldoTotal = 0;
            var factura = ConsultaEstado(idEstado);
            foreach (DataRow fRow in factura.Rows)
            {
                var producto = ProductoFacturaVenta(fRow["numero"].ToString(), Convert.ToBoolean(fRow["descto"]));
                totalFact = Convert.ToInt32(producto.AsEnumerable().Sum(t => t.Field<double>("Valor")));
                pagosFact = GetTotalFormasDePagoDeFacturaVenta(fRow["numero"].ToString());
                saldo = totalFact - pagosFact;
                saldoTotal = saldoTotal + saldo;
            }
            return saldoTotal;
        }

        public DataSet TotalFacturasContado(DateTime fecha)
        {
            var dataSet = new DataSet();
            var tabla = new DataTable();
            tabla.TableName = "Factura";
            tabla.Columns.Add(new DataColumn("Total", typeof(int)));
            int totalFact = 0;
            var factura = NumeroFacturasContado(fecha);
            try
            {
                foreach (DataRow fRow in factura.Rows)
                {
                    var producto = ProductoFacturaVenta(fRow["numerofactura_venta"].ToString(), Convert.ToBoolean(fRow["aplica_descuento"]));
                    totalFact = totalFact + Convert.ToInt32(producto.AsEnumerable().Sum(t => t.Field<double>("Valor")));
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            var row = tabla.NewRow();
            row["Total"] = totalFact;
            tabla.Rows.Add(row);
            dataSet.Tables.Add(tabla);
            factura.Clear();
            factura = null;
            return dataSet;
        }

        public DataSet TotalFacturasContado(int idCaja, DateTime fecha)
        {
           // var daoSaldo = new DaoSaldo();
            var dataSet = new DataSet();
            var tabla = new DataTable();
            tabla.TableName = "Factura";
            tabla.Columns.Add(new DataColumn("Total", typeof(int)));
            int totalFact = 0;
            var factura = NumeroFacturasContado(idCaja, fecha);
            //abonos*
            //adelantos
            //var saldos = daoSaldo.SaldosDelDia(idCaja, fecha);
            try
            {
                foreach (DataRow fRow in factura.Rows)
                {
                    var producto = ProductoFacturaVenta(fRow["numerofactura_venta"].ToString(), Convert.ToBoolean(fRow["aplica_descuento"]));
                    totalFact = totalFact + Convert.ToInt32(producto.AsEnumerable().Sum(t => t.Field<double>("Valor")));
                }
                //totalFact += TotalAbonos(idCaja, fecha);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            var row = tabla.NewRow();
            row["Total"] = totalFact;
            tabla.Rows.Add(row);
            dataSet.Tables.Add(tabla);
            factura.Clear();
            factura = null;
            return dataSet;
        }

        public DataSet TotalFacturasCredito(int idEstado, int idCaja, DateTime fecha, bool caja)
        {
            var miDaoProducto = new DaoProductoFacturaVenta();
            var dataSet = new DataSet();
            var tabla = new DataTable();
            tabla.TableName = "FacturaCredito";
            //tabla.Columns.Add(new DataColumn("TotalCredito", typeof(int)));
            tabla.Columns.Add(new DataColumn("NoFacturaC", typeof(string)));
            tabla.Columns.Add(new DataColumn("NitC", typeof(string)));
            tabla.Columns.Add(new DataColumn("ClienteC", typeof(string)));
            tabla.Columns.Add(new DataColumn("TotalC", typeof(int)));
            
            var factura = new DataTable();
            if (caja)
            {
                factura = FacturasDeVenta(idEstado, idCaja, fecha);
            }
            else
            {
                ///factura = NumeroFacturasCredito(fecha); Organizar.
            }
            try
            {
                foreach (DataRow fRow in factura.Rows)
                {
                    double totalFact = 0;
                    var row = tabla.NewRow();

                    /*
                     var tProducto = PrintProductoFacturaVenta
                        (fRow["numerofactura_venta"].ToString(), Convert.ToBoolean(fRow["aplica_descuento"]));
                     */

                    //var tProducto = miDaoProducto.PrintProducto(fRow["numero"].ToString(), Convert.ToBoolean(fRow["descto"]));
                    //totalFact = totalFact + Convert.ToDouble(tProducto.Tables[0].AsEnumerable().Sum(t => t.Field<int>("Total_")));

                    //var tProducto = PrintProductoFacturaVenta(fRow["numero"].ToString(), Convert.ToBoolean(fRow["descto"]));
                    //ProductoFacturaVenta
                    var tProducto = ProductoFacturaVenta(fRow["numero"].ToString(), Convert.ToBoolean(fRow["descto"]));
                    totalFact = totalFact + Convert.ToDouble(tProducto.AsEnumerable().Sum(t => t.Field<double>("Valor")));

                    row["NoFacturaC"] = fRow["numero"];
                    row["NitC"] = fRow["nitcliente"];
                    row["ClienteC"] = fRow["nombrescliente"];
                    row["TotalC"] = Convert.ToInt32(totalFact);
                    tabla.Rows.Add(row);
                }
            }//Total_
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            dataSet.Tables.Add(tabla);
            factura.Clear();
            factura = null;
            return dataSet;
        }

        public long CountRegistroVentas()
        {
            try
            {
                CargarComando("count_factura_venta");
                miConexion.MiConexion.Open();
                var count = Convert.ToInt64(miComando.ExecuteScalar());
                miConexion.MiConexion.Close();
                miComando.Dispose();
                return count;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error en el conteo de registros de venta.\n" + ex.Message);
            }
        }

        public DataTable RegistroVentas(int idCaja, DateTime fecha, bool caja)
        {
            try
            {
                var tRegistro = new DataTable();
                tRegistro = NumeroFacturasTodas(idCaja, fecha, caja);
                return tRegistro;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al cargar los registros de venta.\n" + ex.Message);
            }
        }

        public DataTable SerieNumeroFacturas(int idCaja, DateTime fecha, bool caja)
        {
            try
            {
                CargarComando("count_factura_venta");
                miConexion.MiConexion.Open();
                var count = Convert.ToInt64(miComando.ExecuteScalar());
                miConexion.MiConexion.Close();
                miComando.Dispose();
                var tFacturas = new DataTable();
                bool find = false;
                var miFecha = fecha;
                if (count > 0)
                {
                    while (!find)
                    {
                        tFacturas = NumeroFacturasTodas(idCaja, miFecha, caja);
                        if (tFacturas.Rows.Count != 0)
                        {
                            find = true;
                        }
                        else
                        {
                            miFecha = miFecha.AddDays(-1);
                        }
                    }
                }
                return tFacturas;
                /*var tabla = new DataTable();
                tabla.Columns.Add(new DataColumn("Serie", typeof(string)));
                bool find = false;
                var miFecha = fecha;
                if (count > 0)
                {
                    while (!find)
                    {
                        var facturas = NumeroFacturasTodas(idCaja, miFecha, caja);
                        if (facturas.Rows.Count != 0)
                        {
                            var query = from data in facturas.AsEnumerable()
                                        orderby data.Field<DateTime>("horafactura_venta")
                                        select data;
                            if (miFecha < fecha)
                            {
                                var query_ = query.AsEnumerable().
                                    Where(p => p.Field<DateTime>("horafactura_venta").Equals(
                                    query.AsEnumerable().Max(m => m.Field<DateTime>("horafactura_venta")))).Single();
                                tabla.Columns.Add(new DataColumn("Use", typeof(char)));
                                var row_ = tabla.NewRow();
                                row_["Serie"] = query_["numerofactura_venta"];
                                tabla.Rows.Add(row_);
                            }
                            else
                            {
                                foreach (DataRow row in query)
                                {
                                    var row_ = tabla.NewRow();
                                    row_["Serie"] = row["numerofactura_venta"];
                                    tabla.Rows.Add(row_);
                                }
                            }
                            find = true;
                        }
                        else
                        {
                            miFecha = miFecha.AddDays(-1);
                        }
                    }
                }
                return tabla;*/
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al consultar la serie de consecutivos de las Facturas.\n" + ex.Message);
            }
            finally { miConexion.MiConexion.Close(); }
        }

        public DataSet TotalAbonos(DateTime fecha)
        {
            var miDaoPagos = new DaoFormaPago();
            var totalAbono = 0;
            try
            {
                var pagos = miDaoPagos.FormasDePagoDeFacturaVenta();
                foreach (DataRow pRow in pagos.Rows)
                {
                    var credito = FacturaCredito(pRow["Factura"].ToString());
                    //var f = Convert.ToDateTime(pRow["Fecha"]);
                    if (credito &&
                        Utilities.UseDate.FechaSinHora(fecha).
                        Equals(Utilities.UseDate.FechaSinHora(Convert.ToDateTime(pRow["Fecha"]))))
                    {
                        totalAbono = totalAbono + Convert.ToInt32(pRow["Valor"]);
                    }
                }
                var dataSet = new DataSet();
                var tabla = new DataTable();
                tabla.TableName = "Abono";
                tabla.Columns.Add(new DataColumn("ATotal", typeof(int)));
                var row = tabla.NewRow();
                row["ATotal"] = totalAbono;
                tabla.Rows.Add(row);
                dataSet.Tables.Add(tabla);
                return dataSet;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public DataSet TotalAbonos(int idCaja, DateTime fecha)
        {
            var miDaoPagos = new DaoFormaPago();
            try
            {
                var dataSet = new DataSet();
                var tabla = new DataTable();
                tabla.TableName = "Abono";
                tabla.Columns.Add(new DataColumn("numero", typeof(string)));
                tabla.Columns.Add(new DataColumn("nit", typeof(string)));
                tabla.Columns.Add(new DataColumn("nombre", typeof(string)));
                tabla.Columns.Add(new DataColumn("valor", typeof(long)));
                var pagos = miDaoPagos.FormasDePagoDeFacturaVenta(idCaja, fecha);
                var query = from data in pagos.AsEnumerable()
                            where data.Field<int>("estado").Equals(2)
                            select data;
                //tabla = query.CopyToDataTable<DataRow>();
                foreach (DataRow row in query)
                {
                    var row_ = tabla.NewRow();
                    row_["numero"] = row["numero"];
                    row_["nit"] = row["nit"];
                    row_["nombre"] = row["nombre"];
                    row_["valor"] = row["valor"];
                    tabla.Rows.Add(row_);
                }
                dataSet.Tables.Add(tabla);
                pagos.Rows.Clear();
                pagos.Clear();
                pagos = null;
                query = null;
                return dataSet;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public DataSet IvaFacturaContado(int idCaja, DateTime fecha, bool caja)
        {
            var miDaoIva = new DaoIva();
            var dataSet = new DataSet();
            var tabla = new DataTable();
            tabla.TableName = "IvaGravado";
            tabla.Columns.Add(new DataColumn("Iva", typeof(string)));
            tabla.Columns.Add(new DataColumn("Base", typeof(double)));
            tabla.Columns.Add(new DataColumn("VIva", typeof(double)));
            tabla.Columns.Add(new DataColumn("SubTotal", typeof(double)));
            try
            {
                var iva = miDaoIva.ListadoIva();
                var factura = new DataTable();
                if (caja)
                {
                    factura = NumeroFacturasContado(idCaja, fecha);
                }
                else
                {
                    factura = NumeroFacturasContado(fecha);
                }
                foreach (DataRow fRow in factura.Rows)
                {
                    var producto = PrintProductoFacturaVenta
                        (fRow["numerofactura_venta"].ToString(), Convert.ToBoolean(fRow["aplica_descuento"]));
                    foreach (Iva cIva in iva)
                    {
                        foreach (DataRow pRow in producto.Rows)
                        {
                            if (cIva.PorcentajeIva ==
                                Utilities.UseObject.RemoveCharacter(pRow["Iva"].ToString(), '%'))
                            {
                                var tablaRow = tabla.NewRow();
                                tablaRow["Iva"] = pRow["Iva"];

                                tablaRow["Base"] = Convert.ToDouble(
                                    Convert.ToDouble(pRow["ValorMenosDescto"]) *
                                    Convert.ToDouble(pRow["Cantidad"]));
                                var v = tablaRow["Base"].ToString();

                                tablaRow["VIva"] = Convert.ToDouble(
                                    Convert.ToDouble(pRow["ValorIva"]) *
                                    Convert.ToDouble(pRow["Cantidad"]));
                                v = tablaRow["VIva"].ToString();

                                tablaRow["SubTotal"] = Convert.ToDouble(tablaRow["Base"]) + 
                                                       Convert.ToDouble(tablaRow["VIva"]);
                                v = tablaRow["SubTotal"].ToString();

                                tabla.Rows.Add(tablaRow);
                            }
                        }
                    }
                }
                IEnumerable<DataRow> query = from d in tabla.AsEnumerable()
                                             select d;
                DataTable tablaTemp = new DataTable();
                if (query.ToArray().Length != 0)
                {
                    tablaTemp = query.CopyToDataTable<DataRow>();
                }
                tablaTemp.TableName = "IvaGravado";
                tablaTemp.Rows.Clear();
                foreach (Iva tempIva in iva)
                {
                    var tBase = tabla.AsEnumerable().Where(i => i.Field<string>("Iva").
                        Equals(tempIva.PorcentajeIva.ToString() + "%")).Sum(s => s.Field<double>("Base"));
                    var tIva = tabla.AsEnumerable().Where(i => i.Field<string>("Iva").
                        Equals(tempIva.PorcentajeIva.ToString() + "%")).Sum(s => s.Field<double>("VIva"));
                    var sTotal = tabla.AsEnumerable().Where(i => i.Field<string>("Iva").
                        Equals(tempIva.PorcentajeIva.ToString() + "%")).Sum(s => s.Field<double>("SubTotal"));
                    if (tBase != 0)
                    {
                        var rowTemp = tablaTemp.NewRow();
                        rowTemp["Iva"] = tempIva.PorcentajeIva.ToString() + "%";
                        rowTemp["Base"] = tBase;
                        rowTemp["VIva"] = tIva;
                        rowTemp["SubTotal"] = sTotal;
                        tablaTemp.Rows.Add(rowTemp);
                    }
                }
                dataSet.Tables.Add(tablaTemp);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return dataSet;
        }

        public DataTable ListaIvaContado(int idCaja, DateTime fecha, bool caja)
        {
            var miDaoIva = new DaoIva();
            var tabla = new DataTable();
            tabla.TableName = "IvaGravado";
            tabla.Columns.Add(new DataColumn("Iva", typeof(string)));
            tabla.Columns.Add(new DataColumn("Base", typeof(double)));
            tabla.Columns.Add(new DataColumn("VIva", typeof(double)));
            tabla.Columns.Add(new DataColumn("SubTotal", typeof(double)));
            try
            {
                var iva = miDaoIva.ListadoIva();
                var factura = new DataTable();
                if (caja)
                {
                    factura = NumeroFacturasContado(idCaja, fecha);
                }
                else
                {
                    factura = NumeroFacturasContado(fecha);
                }
                foreach (DataRow fRow in factura.Rows)
                {
                    var producto = PrintProductoFacturaVenta
                        (fRow["numerofactura_venta"].ToString(), Convert.ToBoolean(fRow["aplica_descuento"]));
                    foreach (Iva cIva in iva)
                    {
                        foreach (DataRow pRow in producto.Rows)
                        {
                            if (cIva.PorcentajeIva ==
                                Utilities.UseObject.RemoveCharacter(pRow["Iva"].ToString(), '%'))
                            {
                                var tablaRow = tabla.NewRow();
                                tablaRow["Iva"] = pRow["Iva"];

                                tablaRow["Base"] = Convert.ToDouble(
                                    Convert.ToDouble(pRow["ValorMenosDescto"]) *
                                    Convert.ToDouble(pRow["Cantidad"]));
                                var v = tablaRow["Base"].ToString();

                                tablaRow["VIva"] = Convert.ToDouble(
                                    Convert.ToDouble(pRow["ValorIva"]) *
                                    Convert.ToDouble(pRow["Cantidad"]));
                                v = tablaRow["VIva"].ToString();

                                tablaRow["SubTotal"] = Convert.ToDouble(tablaRow["Base"]) +
                                                       Convert.ToDouble(tablaRow["VIva"]);
                                v = tablaRow["SubTotal"].ToString();

                                tabla.Rows.Add(tablaRow);
                            }
                        }
                    }
                }
                return tabla;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public DataSet IvaFacturaCredito(int idCaja, DateTime fecha, bool caja)
        {
            var miDaoIva = new DaoIva();
            var dataSet = new DataSet();
            var tabla = new DataTable();
            tabla.TableName = "IvaGravadoC";
            tabla.Columns.Add(new DataColumn("IvaC", typeof(string)));
            tabla.Columns.Add(new DataColumn("BaseC", typeof(int)));
            tabla.Columns.Add(new DataColumn("VIvaC", typeof(double)));
            tabla.Columns.Add(new DataColumn("SubTotalC", typeof(double)));
            try
            {
                var iva = miDaoIva.ListadoIva();
                var factura = new DataTable();
                if (caja)
                {
                    factura = NumeroFacturasCredito(idCaja, fecha);
                }
                else
                {
                    factura = NumeroFacturasCredito(fecha);
                }
                foreach (DataRow fRow in factura.Rows)
                {
                    var producto = PrintProductoFacturaVenta
                        (fRow["numerofactura_venta"].ToString(), Convert.ToBoolean(fRow["aplica_descuento"]));
                    foreach (Iva cIva in iva)
                    {
                        foreach (DataRow pRow in producto.Rows)
                        {
                            if (cIva.PorcentajeIva ==
                                Utilities.UseObject.RemoveCharacter(pRow["Iva"].ToString(), '%'))
                            {
                                var tablaRow = tabla.NewRow();
                                tablaRow["IvaC"] = pRow["Iva"];

                                tablaRow["BaseC"] = Convert.ToDouble(
                                    Convert.ToDouble(pRow["ValorMenosDescto"]) *
                                    Convert.ToDouble(pRow["Cantidad"]));

                                tablaRow["VIvaC"] = Convert.ToDouble(
                                    Convert.ToDouble(pRow["ValorIva"]) *
                                    Convert.ToDouble(pRow["Cantidad"]));


                                tablaRow["SubTotalC"] = Convert.ToDouble(tablaRow["BaseC"]) +
                                                       Convert.ToDouble(tablaRow["VIvaC"]);

                                tabla.Rows.Add(tablaRow);
                            }
                        }
                    }
                }
                IEnumerable<DataRow> query = from d in tabla.AsEnumerable()
                                             select d;
                DataTable tablaTemp = new DataTable();
                if (query.ToArray().Length != 0)
                {
                    tablaTemp = query.CopyToDataTable<DataRow>();
                }
                tablaTemp.TableName = "IvaGravadoC";
                tablaTemp.Rows.Clear();
                foreach (Iva tempIva in iva)
                {
                    var tBase = tabla.AsEnumerable().Where(i => i.Field<string>("IvaC").
                        Equals(tempIva.PorcentajeIva.ToString() + "%")).Sum(s => s.Field<int>("BaseC"));
                    var tIva = tabla.AsEnumerable().Where(i => i.Field<string>("IvaC").
                        Equals(tempIva.PorcentajeIva.ToString() + "%")).Sum(s => s.Field<double>("VIvaC"));
                    var sTotal = tabla.AsEnumerable().Where(i => i.Field<string>("IvaC").
                        Equals(tempIva.PorcentajeIva.ToString() + "%")).Sum(s => s.Field<double>("SubTotalC"));
                    if (tBase != 0)
                    {
                        var rowTemp = tablaTemp.NewRow();
                        rowTemp["IvaC"] = tempIva.PorcentajeIva.ToString() + "%";
                        rowTemp["BaseC"] = tBase;
                        rowTemp["VIvaC"] = tIva;
                        rowTemp["SubTotalC"] = sTotal;
                        tablaTemp.Rows.Add(rowTemp);
                    }
                }
                dataSet.Tables.Add(tablaTemp);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return dataSet;
        }

        public DataTable IvaFacturado(string numero, bool descto)
        {
            var miDaoIva = new DaoIva();
            var tabla = new DataTable();
            tabla.TableName = "IvaGravado";
            tabla.Columns.Add(new DataColumn("Iva", typeof(string)));
            tabla.Columns.Add(new DataColumn("Base", typeof(int)));
            tabla.Columns.Add(new DataColumn("VIva", typeof(double)));
            tabla.Columns.Add(new DataColumn("SubTotal", typeof(double)));
            try
            {
                var iva = miDaoIva.ListadoIva();
                var tProducto = PrintProductoFacturaVenta(numero, descto);
                foreach (Iva cIva in iva)
                {
                    foreach (DataRow pRow in tProducto.Rows)
                    {
                        if (cIva.PorcentajeIva ==
                            Utilities.UseObject.RemoveCharacter(pRow["Iva"].ToString(), '%'))
                        {
                            var tablaRow = tabla.NewRow();
                            tablaRow["Iva"] = pRow["Iva"];

                            tablaRow["Base"] = Convert.ToDouble(
                                Convert.ToDouble(pRow["ValorMenosDescto"]) *
                                Convert.ToDouble(pRow["Cantidad"]));

                            tablaRow["VIva"] = Convert.ToDouble(
                                Convert.ToDouble(pRow["ValorIva"]) *
                                Convert.ToDouble(pRow["Cantidad"]));

                            tablaRow["SubTotal"] = Convert.ToDouble(tablaRow["Base"]) +
                                                   Convert.ToDouble(tablaRow["VIva"]);

                            tabla.Rows.Add(tablaRow);
                        }
                    }
                }
                IEnumerable<DataRow> query = from d in tabla.AsEnumerable()
                                             select d;
                DataTable tablaTemp = new DataTable();
                if (query.ToArray().Length != 0)
                {
                    tablaTemp = query.CopyToDataTable<DataRow>();
                }
                tablaTemp.TableName = "IvaGravado";
                tablaTemp.Rows.Clear();
                foreach (Iva tempIva in iva)
                {
                    var tBase = tabla.AsEnumerable().Where(i => i.Field<string>("Iva").
                        Equals(tempIva.PorcentajeIva.ToString() + "%")).Sum(s => s.Field<int>("Base"));
                    var tIva = tabla.AsEnumerable().Where(i => i.Field<string>("Iva").
                        Equals(tempIva.PorcentajeIva.ToString() + "%")).Sum(s => s.Field<double>("VIva"));
                    var sTotal = tabla.AsEnumerable().Where(i => i.Field<string>("Iva").
                        Equals(tempIva.PorcentajeIva.ToString() + "%")).Sum(s => s.Field<double>("SubTotal"));
                    if (tBase != 0)
                    {
                        var rowTemp = tablaTemp.NewRow();
                        rowTemp["Iva"] = tempIva.PorcentajeIva.ToString() + "%";
                        rowTemp["Base"] = tBase;
                        rowTemp["VIva"] = tIva;
                        rowTemp["SubTotal"] = sTotal;
                        tablaTemp.Rows.Add(rowTemp);
                    }
                }
                return tablaTemp;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public DataSet TotalIvaFacturado(int idCaja, DateTime fecha, bool caja)
        {
            var miDaoIva = new DaoIva();
            var dataSet = new DataSet();
            var tabla = new DataTable();
            tabla.TableName = "IvaGravado";
            tabla.Columns.Add(new DataColumn("Iva", typeof(string)));
            tabla.Columns.Add(new DataColumn("Base", typeof(double)));
            tabla.Columns.Add(new DataColumn("VIva", typeof(double)));
            tabla.Columns.Add(new DataColumn("SubTotal", typeof(double)));
            try
            {
                var iva = miDaoIva.ListadoIva();
                var factura = NumeroFacturasActivaTodas(idCaja, fecha, caja);
                foreach (DataRow fRow in factura.Rows)
                {
                    var tProducto = ProductoFacturaVenta
                        (fRow["numerofactura_venta"].ToString(), Convert.ToBoolean(fRow["aplica_descuento"]));

                    /*var tProducto = PrintProductoFacturaVenta
                        (fRow["numerofactura_venta"].ToString(), Convert.ToBoolean(fRow["aplica_descuento"]));*/
                    foreach (Iva cIva in iva)
                    {
                        foreach (DataRow pRow in tProducto.Rows)
                        {
                            if (cIva.PorcentajeIva ==
                                Utilities.UseObject.RemoveCharacter(pRow["Iva"].ToString(), '%'))
                            {
                                var tablaRow = tabla.NewRow();
                                tablaRow["Iva"] = pRow["Iva"];

                                /*tablaRow["Base"] = Convert.ToDouble(
                                    Convert.ToDouble(pRow["ValorMenosDescto"]) *
                                    Convert.ToDouble(pRow["Cantidad"]));

                                tablaRow["VIva"] = Convert.ToDouble(
                                    Convert.ToDouble(pRow["ValorIva"]) *
                                    Convert.ToDouble(pRow["Cantidad"]));*/

                                tablaRow["Base"] = Math.Round((
                                    Convert.ToDouble(pRow["ValorMenosDescto"]) *
                                    Convert.ToDouble(pRow["Cantidad"])), 3);

                                tablaRow["VIva"] = Math.Round((
                                    Convert.ToDouble(pRow["ValorIva"]) *
                                    Convert.ToDouble(pRow["Cantidad"])), 3);

                                tablaRow["SubTotal"] = Convert.ToDouble(tablaRow["Base"]) +
                                                       Convert.ToDouble(tablaRow["VIva"]);

                                tabla.Rows.Add(tablaRow);
                            }
                        }
                    }
                }
                IEnumerable<DataRow> query = from d in tabla.AsEnumerable()
                                             select d;
                DataTable tablaTemp = new DataTable();
                if (query.ToArray().Length != 0)
                {
                    tablaTemp = query.CopyToDataTable<DataRow>();
                }
                tablaTemp.TableName = "IvaGravado";
                tablaTemp.Rows.Clear();
                foreach (Iva tempIva in iva)
                {
                    var tBase = tabla.AsEnumerable().Where(i => i.Field<string>("Iva").
                        Equals(tempIva.PorcentajeIva.ToString() + "%")).Sum(s => s.Field<double>("Base"));
                    var tIva = tabla.AsEnumerable().Where(i => i.Field<string>("Iva").
                        Equals(tempIva.PorcentajeIva.ToString() + "%")).Sum(s => s.Field<double>("VIva"));
                    var sTotal = tabla.AsEnumerable().Where(i => i.Field<string>("Iva").
                        Equals(tempIva.PorcentajeIva.ToString() + "%")).Sum(s => s.Field<double>("SubTotal"));
                    if (tBase != 0)
                    {
                        var rowTemp = tablaTemp.NewRow();
                        rowTemp["Iva"] = tempIva.PorcentajeIva.ToString() + "%";
                        rowTemp["Base"] = tBase;
                        rowTemp["VIva"] = tIva;
                        rowTemp["SubTotal"] = sTotal;
                        tablaTemp.Rows.Add(rowTemp);
                    }
                }

                dataSet.Tables.Add(tablaTemp);
                return dataSet;

                // Antes...
               /* var iva = miDaoIva.ListadoIva();
                var factura = new DataTable();
                factura = NumeroFacturasActivaTodas(idCaja, fecha, caja);
                foreach (DataRow fRow in factura.Rows)
                {
                    var producto = PrintProductoFacturaVenta
                        (fRow["numerofactura_venta"].ToString(), Convert.ToBoolean(fRow["aplica_descuento"]));
                    foreach (Iva cIva in iva)
                    {
                        foreach (DataRow pRow in producto.Rows)
                        {
                            if (cIva.PorcentajeIva ==
                                Utilities.UseObject.RemoveCharacter(pRow["Iva"].ToString(), '%'))
                            {
                                var tablaRow = tabla.NewRow();
                                tablaRow["Iva"] = pRow["Iva"];

                                tablaRow["Base"] = Convert.ToDouble(
                                    Convert.ToDouble(pRow["ValorMenosDescto"]) *
                                    Convert.ToDouble(pRow["Cantidad"]));
                                var v = tablaRow["Base"].ToString();

                              //  /*tablaRow["VIva"] = Convert.ToDouble(
                              //      Convert.ToDouble(pRow["ValorIva"]) *
                               //     Convert.ToDouble(pRow["Cantidad"]));
                                

                            //    tablaRow["SubTotal"] = Convert.ToDouble(tablaRow["Base"]) +
                             //                          Convert.ToDouble(tablaRow["VIva"]);
                               

                                tabla.Rows.Add(tablaRow);
                            }
                        }
                    }
                }
                IEnumerable<DataRow> query = from d in tabla.AsEnumerable()
                                             select d;
                DataTable tablaTemp = new DataTable();
                if (query.ToArray().Length != 0)
                {
                    tablaTemp = query.CopyToDataTable<DataRow>();
                }
                tablaTemp.TableName = "IvaGravado";
                tablaTemp.Rows.Clear();
                foreach (Iva tempIva in iva)
                {
                    var tBase = tabla.AsEnumerable().Where(i => i.Field<string>("Iva").
                        Equals(tempIva.PorcentajeIva.ToString() + "%")).Sum(s => s.Field<int>("Base"));
                 //   var tIva = tabla.AsEnumerable().Where(i => i.Field<string>("Iva").
                 //      Equals(tempIva.PorcentajeIva.ToString() + "%")).Sum(s => s.Field<double>("VIva"));
                 ///   var sTotal = tabla.AsEnumerable().Where(i => i.Field<string>("Iva").
                //        Equals(tempIva.PorcentajeIva.ToString() + "%")).Sum(s => s.Field<double>("SubTotal"));
                    if (tBase != 0)
                    {
                        var rowTemp = tablaTemp.NewRow();
                        rowTemp["Iva"] = tempIva.PorcentajeIva.ToString() + "%";
                        rowTemp["Base"] = tBase;
                     //   rowTemp["VIva"] = tIva;
                    //    rowTemp["SubTotal"] = sTotal;
                        tablaTemp.Rows.Add(rowTemp);
                    }
                }
                IEnumerable<DataRow> query1 = from d in tabla.AsEnumerable()
                                             select d;
                DataTable tablaTemp1 = new DataTable();
                if (query1.ToArray().Length != 0)
                {
                    tablaTemp1 = query1.CopyToDataTable<DataRow>();
                }
                tablaTemp1.TableName = "IvaGravado";
                tablaTemp1.Rows.Clear();
                foreach (DataRow iRow in tablaTemp.Rows)
                {
                    var tmpRow1 = tablaTemp1.NewRow();
                    tmpRow1["Iva"] = iRow["Iva"];
                    tmpRow1["Base"] = iRow["Base"];
                    tmpRow1["VIva"] = Convert.ToDouble(iRow["Base"]) * UseObject.RemoveCharacter(iRow["Iva"].ToString(), '%') / 100;
                    tmpRow1["SubTotal"] = Convert.ToDouble(iRow["Base"]) +
                        Convert.ToInt32(Convert.ToDouble(iRow["Base"]) * UseObject.RemoveCharacter(iRow["Iva"].ToString(), '%') / 100);
                    tablaTemp1.Rows.Add(tmpRow1);
                }

                dataSet.Tables.Add(tablaTemp1);*/
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
           // return dataSet;
        }

        // Metodo TotalIvaFacturado() antes de la edición.
        /*
         public DataSet TotalIvaFacturado(int idCaja, DateTime fecha, bool caja)
        {
            var miDaoIva = new DaoIva();
            var dataSet = new DataSet();
            var tabla = new DataTable();
            tabla.TableName = "IvaGravado";
            tabla.Columns.Add(new DataColumn("Iva", typeof(string)));
            tabla.Columns.Add(new DataColumn("Base", typeof(double)));
            tabla.Columns.Add(new DataColumn("VIva", typeof(double)));
            tabla.Columns.Add(new DataColumn("SubTotal", typeof(double)));
            try
            {
                var iva = miDaoIva.ListadoIva();
                var factura = new DataTable();
                factura = NumeroFacturasActivaTodas(idCaja, fecha, caja);
                foreach (DataRow fRow in factura.Rows)
                {
                    var producto = PrintProductoFacturaVenta
                        (fRow["numerofactura_venta"].ToString(), Convert.ToBoolean(fRow["aplica_descuento"]));
                    foreach (Iva cIva in iva)
                    {
                        foreach (DataRow pRow in producto.Rows)
                        {
                            if (cIva.PorcentajeIva ==
                                Utilities.UseObject.RemoveCharacter(pRow["Iva"].ToString(), '%'))
                            {
                                var tablaRow = tabla.NewRow();
                                tablaRow["Iva"] = pRow["Iva"];

                                tablaRow["Base"] = Convert.ToDouble(
                                    Convert.ToDouble(pRow["ValorMenosDescto"]) *
                                    Convert.ToDouble(pRow["Cantidad"]));
                                var v = tablaRow["Base"].ToString();

                                tablaRow["VIva"] = Convert.ToDouble(
                                    Convert.ToDouble(pRow["ValorIva"]) *
                                    Convert.ToDouble(pRow["Cantidad"]));
                                v = tablaRow["VIva"].ToString();

                                tablaRow["SubTotal"] = Convert.ToDouble(tablaRow["Base"]) +
                                                       Convert.ToDouble(tablaRow["VIva"]);
                                v = tablaRow["SubTotal"].ToString();

                                tabla.Rows.Add(tablaRow);
                            }
                        }
                    }
                }
                IEnumerable<DataRow> query = from d in tabla.AsEnumerable()
                                             select d;
                DataTable tablaTemp = new DataTable();
                if (query.ToArray().Length != 0)
                {
                    tablaTemp = query.CopyToDataTable<DataRow>();
                }
                tablaTemp.TableName = "IvaGravado";
                tablaTemp.Rows.Clear();
                foreach (Iva tempIva in iva)
                {
                    var tBase = tabla.AsEnumerable().Where(i => i.Field<string>("Iva").
                        Equals(tempIva.PorcentajeIva.ToString() + "%")).Sum(s => s.Field<double>("Base"));
                    var tIva = tabla.AsEnumerable().Where(i => i.Field<string>("Iva").
                        Equals(tempIva.PorcentajeIva.ToString() + "%")).Sum(s => s.Field<double>("VIva"));
                    var sTotal = tabla.AsEnumerable().Where(i => i.Field<string>("Iva").
                        Equals(tempIva.PorcentajeIva.ToString() + "%")).Sum(s => s.Field<double>("SubTotal"));
                    if (tBase != 0)
                    {
                        var rowTemp = tablaTemp.NewRow();
                        rowTemp["Iva"] = tempIva.PorcentajeIva.ToString() + "%";
                        rowTemp["Base"] = tBase;
                        rowTemp["VIva"] = tIva;
                        rowTemp["SubTotal"] = sTotal;
                        tablaTemp.Rows.Add(rowTemp);
                    }
                }
                dataSet.Tables.Add(tablaTemp);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return dataSet;
        }
         */

        public DataTable FacturasDeVenta(int idEstado, int idCaja, DateTime fecha)
        {
            var tabla = new DataTable();
            try
            {
                CargarAdapter("facturas_venta");
                miAdapter.SelectCommand.Parameters.AddWithValue("estado", idEstado);
                miAdapter.SelectCommand.Parameters.AddWithValue("caja", idCaja);
                miAdapter.SelectCommand.Parameters.AddWithValue("fecha", fecha);
                miAdapter.Fill(tabla);
                return tabla;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al consultar las Facturas de Venta.\n" + ex.Message);
            }
        }

        public DataTable NumeroFacturasTodas(int idCaja, DateTime fecha, bool caja)
        {
            var tabla = new DataTable();
            try
            {
                CargarAdapter("numero_facturas_todas");
                if (caja)
                {
                    miAdapter.SelectCommand.Parameters.AddWithValue("caja", idCaja);
                }
                miAdapter.SelectCommand.Parameters.AddWithValue("fecha", fecha);
                miAdapter.Fill(tabla);
                return tabla;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public DataTable NumeroFacturasActivaTodas(int idCaja, DateTime fecha, bool caja)
        {
            var tabla = new DataTable();
            try
            {
                CargarAdapter("numero_facturas_activas_todas");
                if (caja)
                {
                    miAdapter.SelectCommand.Parameters.AddWithValue("caja", idCaja);
                }
                miAdapter.SelectCommand.Parameters.AddWithValue("fecha", fecha);
                miAdapter.Fill(tabla);
                return tabla;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public DataTable NumeroFacturasContado(DateTime fecha)
        {
            var tabla = new DataTable();
            try
            {
                CargarAdapter("numero_facturas_contado");
                miAdapter.SelectCommand.Parameters.AddWithValue("fecha", fecha);
                miAdapter.Fill(tabla);
                return tabla;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public DataTable NumeroFacturasContado(int idCaja, DateTime fecha)
        {
            var tabla = new DataTable();
            try
            {
                CargarAdapter("numero_facturas_contado");
                miAdapter.SelectCommand.Parameters.AddWithValue("caja", idCaja);
                miAdapter.SelectCommand.Parameters.AddWithValue("fecha", fecha);
                miAdapter.Fill(tabla);
                return tabla;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public DataTable NumeroFacturasCredito(DateTime fecha)
        {
            var tabla = new DataTable();
            try
            {
                CargarAdapter("numero_facturas_credito");
                miAdapter.SelectCommand.Parameters.AddWithValue("fecha", fecha);
                miAdapter.Fill(tabla);
                return tabla;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public DataTable NumeroFacturasCredito(int idCaja, DateTime fecha)
        {
            var tabla = new DataTable();
            try
            {
                CargarAdapter("numero_facturas_credito");
                miAdapter.SelectCommand.Parameters.AddWithValue("caja", idCaja);
                miAdapter.SelectCommand.Parameters.AddWithValue("fecha", fecha);
                miAdapter.Fill(tabla);
                return tabla;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public long SaldoDeCliente(string cliente)
        {
            var daoDevolucion = new DaoDevolucion();
            int totalFact = 0;
            int pagosFact = 0;
            int saldoDev = 0;
            int saldo = 0;
            long saldoTotal = 0;
            try
            {
                var facturas = ConsultaActivasPorCliente(cliente);
                foreach (DataRow fRow in facturas.Rows)
                {
                    var productos = ProductoFacturaVenta(fRow["numero"].ToString(), Convert.ToBoolean(fRow["descto"]));
                    totalFact = Convert.ToInt32(productos.AsEnumerable().Sum(s => s.Field<double>("Valor")));
                    pagosFact = GetTotalFormasDePagoDeFacturaVenta(fRow["numero"].ToString());
                    saldoDev = daoDevolucion.SaldoDevolucionVenta(fRow["numero"].ToString());
                    if (totalFact > (pagosFact + saldoDev))
                    {
                        saldo = totalFact - (pagosFact + saldoDev);
                        //}
                        saldoTotal = saldoTotal + saldo;
                    }
                    /*saldo = totalFact - (pagosFact + saldoDev);
                    saldoTotal = saldoTotal + saldo;*/
                }
                return saldoTotal;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un errora al consultar el saldo del Cliente.\n" + ex.Message);
            }
        }

        public DataTable DatosSaldoDeCliente
            (string cliente, bool cartera, List<Ingreso> transacciones)
        {
            var tabla = new DataTable();
            if (cartera)
            {
                tabla.TableName = "Cartera";
            }
            else
            {
                tabla.TableName = "Transaccion";
            }
            tabla.Columns.Add(new DataColumn("Factura", typeof(string)));
            tabla.Columns.Add(new DataColumn("Saldo", typeof(int)));
            tabla.Columns.Add(new DataColumn("Valor", typeof(int)));
            tabla.Columns.Add(new DataColumn("Credito", typeof(int)));
            var daoDevolucion = new DaoDevolucion();
            int totalFact = 0;
            int pagosFact = 0;
            int saldoDev = 0;
            try
            {
                var tFactura = ConsultaPorEstadoYcliente(2, cliente);
                foreach (DataRow fRow in tFactura.Rows)
                {
                    var tProducto = ProductoFacturaVenta
                        (fRow["numero"].ToString(), Convert.ToBoolean(fRow["descto"]));
                    totalFact = Convert.ToInt32(tProducto.AsEnumerable().Sum(t => t.Field<double>("Valor")));
                    pagosFact = GetTotalFormasDePagoDeFacturaVenta(fRow["numero"].ToString());
                    saldoDev = daoDevolucion.SaldoDevolucionVenta(fRow["numero"].ToString());
                    if (cartera)
                    {
                        if (totalFact > (pagosFact + saldoDev))
                        {
                            var row = tabla.NewRow();
                            row["Factura"] = fRow["numero"].ToString();
                            row["Valor"] = totalFact;
                            row["Credito"] = totalFact - (pagosFact + saldoDev);
                            tabla.Rows.Add(row);
                        }
                    }
                    else
                    {
                        foreach (var transacion in transacciones)
                        {
                            if (fRow["numero"].ToString().Equals(transacion.Numero))
                            {
                                var row = tabla.NewRow();
                                row["Factura"] = fRow["numero"].ToString();
                                row["Saldo"] = (totalFact - (pagosFact + saldoDev)) + transacion.Valor;
                                row["Valor"] = transacion.Valor;
                                row["Credito"] = totalFact - (pagosFact + saldoDev);
                                tabla.Rows.Add(row);
                            }
                        }
                    }
                }
                return tabla;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al consultar el saldo del cliente.\n" + ex.Message);
            }
        }

        public DataTable FacturasAnuladas(int idCaja, DateTime fecha)
        {
            var tabla = new DataTable();
            try
            {
                CargarAdapter("facturas_anuladas");
                miAdapter.SelectCommand.Parameters.AddWithValue("caja", idCaja);
                miAdapter.SelectCommand.Parameters.AddWithValue("fech", fecha);
                miAdapter.Fill(tabla);
                return tabla;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al consultar las facturas anuladas.\n" + ex.Message);
            }
        }

        public string IngresarPagoGeneral(string cliente, FormaPago pago, Ingreso ingreso)
        {
            var midaoConsecutivo = new DaoConsecutivo();
            ingreso.Valor = Convert.ToInt32(pago.Valor);
            var monto = pago.Valor;
            var arrFacturas = new List<string>();
            var arrRelacion = new List<int>();
            var facturas = new DataTable();
            var daoDevolucion = new DaoDevolucion();
            var daoPago = new DaoFormaPago();
            var daoIngreso = new DaoIngreso();
            try
            {
                facturas = ConsultaActivasPorCliente(cliente);
                var qFactura = from data in facturas.AsEnumerable()
                               orderby data.Field<DateTime>("fecha") ascending
                               select data;
                foreach (DataRow fRow in qFactura)
                {
                    if (monto > 0)
                    {
                        var productos = ProductoFacturaVenta(fRow["numero"].ToString(), Convert.ToBoolean(fRow["descto"]));
                        var valorFactura = Convert.ToInt32(
                            productos.AsEnumerable().Sum(s => s.Field<double>("Valor")));
                        var pPago = GetTotalFormasDePagoDeFacturaVenta(fRow["numero"].ToString());
                        var saldoDev = daoDevolucion.SaldoDevolucionVenta(fRow["numero"].ToString());
                        if (valorFactura > (pPago + saldoDev))
                        {
                            pago.NumeroFactura = fRow["numero"].ToString();
                            if (monto > (valorFactura - (pPago + saldoDev)))
                            {
                                pago.Valor = valorFactura - (pPago + saldoDev);
                                monto -= (valorFactura - (pPago + saldoDev));
                            }
                            else
                            {
                                pago.Valor = monto;
                                monto = 0;
                            }
                            arrRelacion.Add(daoPago.IngresarPagoAFactura(pago, true, false));
                            arrFacturas.Add(fRow["numero"].ToString());
                        }
                    }
                }
                var f = "";
                foreach (string f_ in arrFacturas)
                {
                    f += f_ + ", ";
                }
                ingreso.Concepto += f;
                ingreso.Saldo = SaldoPorCliente(2, cliente);
                foreach (var relacion in arrRelacion)
                {
                    ingreso.Relacion = relacion;
                    daoIngreso.Ingresar(ingreso, true);
                }
                midaoConsecutivo.ActualizarConsecutivo("Ingreso");
                return ingreso.Concepto;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Obtiene el resultado de la consulta de los productos de una Factura de Venta.
        /// </summary>
        /// <param name="numero">Número de la Factura de Venta.</param>
        /// <param name="descuento">Indica si la factura aplica descuento o no (Recargo)</param>
        /// <returns></returns>
        public DataTable ProductoFacturaVenta(string numero, bool descuento)
        {
            var miDaoProducto = new DaoProductoFacturaVenta();
            var miTabla = CrearDataTable();
            var tabla = miDaoProducto.ProductoFacturaVenta(numero);
            foreach (DataRow row in tabla.Rows)
            {
                var row_ = miTabla.NewRow();
                row_["Cantidad"] = row["Cantidad"];
                row_["ValorUnitario"] = row["Valor"];


               /* if (descuento)
                {
                    row_["Descuento"] = row["Descuento"].ToString() + "%";
                    row_["ValorMenosDescto"] = Convert.ToDouble(row["Valor"]) -
                        (Convert.ToDouble(row["Valor"]) * Convert.ToDouble(row["Descuento"]) / 100);
                }
                else
                {
                    row_["Descuento"] = row["Recargo"].ToString() + "%";
                    row_["ValorMenosDescto"] = Convert.ToDouble(row["Valor"]) +
                        (Convert.ToDouble(row["Valor"]) * Convert.ToDouble(row["Recargo"]) / 100);
                }
                row_["Iva"] = row["Iva"].ToString() + "%";
                row_["ValorIva"] = Convert.ToInt32(
                        Convert.ToDouble(row_["ValorMenosDescto"]) * Convert.ToDouble(row["Iva"]) / 100);
                row_["TotalMasIva"] = Convert.ToInt32(
                            Convert.ToDouble(row_["ValorMenosDescto"]) +
                            (Convert.ToDouble(row_["ValorMenosDescto"]) * Convert.ToDouble(row["Iva"]) / 100));
                row_["Valor"] = Convert.ToInt32(
                                Convert.ToDouble(row_["TotalMasIva"]) * 
                                Convert.ToDouble(row["Cantidad"]));
                miTabla.Rows.Add(row_);*/

                if (descuento)
                {
                    row_["Descuento"] = row["Descuento"].ToString() + "%";
                    row_["ValorMenosDescto"] = Math.Round(
                         (Convert.ToDouble(row["Valor"]) -
                         (Convert.ToDouble(row["Valor"]) * Convert.ToDouble(row["Descuento"]) / 100)), 1);
                }
                else
                {
                    row_["Descuento"] = row["Recargo"].ToString() + "%";
                    row_["ValorMenosDescto"] = Math.Round(
                         (Convert.ToDouble(row["Valor"]) +
                         (Convert.ToDouble(row["Valor"]) * Convert.ToDouble(row["Recargo"]) / 100)), 1);
                }

                row_["Iva"] = row["Iva"].ToString() + "%";

                double vIva = Math.Round(
                    (Convert.ToDouble(row_["ValorMenosDescto"]) * Convert.ToDouble(row["Iva"]) / 100), 1);

                row_["ValorIva"] = vIva;
                row_["TotalMasIva"] = Convert.ToInt32(Convert.ToDouble(row_["ValorMenosDescto"]) + vIva);
                row_["Valor"] = //Convert.ToInt32(
                                Convert.ToInt32(
                                Convert.ToDouble(row_["TotalMasIva"]) * Convert.ToDouble(row["Cantidad"]));

                miTabla.Rows.Add(row_);

            }
            tabla.Clear();
            tabla = null;
            return miTabla;
        }

        public DataTable PrintProductoFacturaVenta(string numero, bool descuento)
        {
            // 1. Imprime.
            // 2. Comprobante e Informe.
            var miDaoProducto = new DaoProductoFacturaVenta();
            var miTabla = CrearDataTable();
            var tabla = miDaoProducto.ProductoFacturaVenta(numero);
            foreach (DataRow row in tabla.Rows)
            {
                var row_ = miTabla.NewRow();
                row_["Cantidad"] = row["Cantidad"];
                row_["ValorUnitario"] = row["Valor"];
                //var v = row_["ValorUnitario"].ToString();
               // v = row["Valor"].ToString();
                if (descuento)
                {
                    row_["Descuento"] = row["Descuento"].ToString() + "%";
                    row_["ValorMenosDescto"] = Convert.ToDouble(row["Valor"]) -
                        (Convert.ToDouble(row["Valor"]) * Convert.ToDouble(row["Descuento"]) / 100);
                }
                else
                {
                    row_["Descuento"] = row["Recargo"].ToString() + "%";
                    row_["ValorMenosDescto"] = Convert.ToDouble(row["Valor"]) +
                        (Convert.ToDouble(row["Valor"]) * Convert.ToDouble(row["Recargo"]) / 100);
                }
               /* v = row_["ValorMenosDescto"].ToString();

                var baset = Convert.ToDouble(row_["ValorMenosDescto"]) * Convert.ToDouble(row_["Cantidad"]);*/

                row_["Iva"] = row["Iva"].ToString() + "%";

                double vIva = Math.Round(
                    (Convert.ToDouble(row_["ValorMenosDescto"]) * Convert.ToDouble(row["Iva"]) / 100), 3);
                //int AproxVIva = UseObject.AproximacionDian(vIva);

                row_["ValorIva"] = vIva;// AproxVIva;
                //v = row_["ValorIva"].ToString();

                row_["TotalMasIva"] = Convert.ToDouble(row_["ValorMenosDescto"]) + vIva;//AproxVIva;
               // v = row_["TotalMasIva"].ToString();

                row_["Valor"] = Math.Round( Convert.ToDouble(
                                Convert.ToDouble(row_["TotalMasIva"]) *
                                Convert.ToDouble(row["Cantidad"])), 0);
              //  v = row_["Valor"].ToString();
                miTabla.Rows.Add(row_);
            }
            tabla.Clear();
            tabla = null;
            return miTabla;
        }

        private bool FacturaCredito(string numero)
        {
            try
            {
                var factura = PrintFacturaVenta(numero).Tables[0];
                var qRow = (from datos in factura.AsEnumerable()
                            select datos).Single();
                if (Convert.ToInt32(qRow["Estado"]) == 2)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

       /*/ public bool FacturaEfectivo(string numero)
        {
            var daoPago = new DaoFormaPago();
            try
            {
                var pago = daoPago.FormasDePagoDeFacturaVenta(numero);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }*/

        /// <summary>
        /// Crea las respectivas columnas del DataTable para ProductoFacturaVenta.
        /// </summary>
        private DataTable CrearDataTable()
        {
            var miTabla = new DataTable();

            miTabla.Columns.Add(new DataColumn("Id", typeof(int)));
            miTabla.Columns.Add(new DataColumn("Codigo", typeof(string)));
            miTabla.Columns.Add(new DataColumn("Articulo", typeof(string)));
            miTabla.Columns.Add(new DataColumn("Unidad", typeof(string)));
            miTabla.Columns.Add(new DataColumn("IdMedida", typeof(int)));
            miTabla.Columns.Add(new DataColumn("Medida", typeof(string)));
            miTabla.Columns.Add(new DataColumn("IdColor", typeof(int)));
            miTabla.Columns.Add(new DataColumn("Color", typeof(System.Drawing.Image)));

            miTabla.Columns.Add(new DataColumn("Cantidad", typeof(double)));
            miTabla.Columns.Add(new DataColumn("ValorUnitario", typeof(double)));
            miTabla.Columns.Add(new DataColumn("Descuento", typeof(string)));
            miTabla.Columns.Add(new DataColumn("ValorMenosDescto", typeof(double)));
            miTabla.Columns.Add(new DataColumn("Iva", typeof(string)));
            miTabla.Columns.Add(new DataColumn("ValorIva", typeof(double)));
            miTabla.Columns.Add(new DataColumn("TotalMasIva", typeof(double)));
            miTabla.Columns.Add(new DataColumn("Valor", typeof(double)));
            return miTabla;
        }

        /// <summary>
        /// Obtiene el valor total de los pagos a una Factura de Venta.
        /// </summary>
        /// <param name="numero">Número de la factura de venta.</param>
        /// <returns></returns>
        public int GetTotalFormasDePagoDeFacturaVenta(string numero)
        {
            var miDaoFromaPago = new DaoFormaPago();
            var tabla = miDaoFromaPago.FormasDePagoDeFacturaVenta(numero);
            var total = 0;
            foreach (DataRow row in tabla.Rows)
            {
                total = total + Convert.ToInt32(row["Valor"]);
            }
            return total;
        }


        /// <summary>
        /// Anula una Factura de Venta.
        /// </summary>
        /// <param name="numero">Número de la Factura de Venta a anular.</param>
        public void AnularFactura(string numero, bool carga)
        {
            var miDaoProducto = new DaoProductoFacturaVenta();
            var miDaoInventario = new DaoInventario();
            try
            {
                CargarComando(AnulaFactura_);
                miComando.Parameters.AddWithValue("numero", numero);
                miConexion.MiConexion.Open();
                miComando.ExecuteNonQuery();
                miConexion.MiConexion.Close();
                miComando.Dispose();
                if (carga)
                {
                    var productos = miDaoProducto.ProductoFacturaVenta(numero);
                    foreach (DataRow row in productos.Rows)
                    {
                        miDaoInventario.ActualizarInventario(
                            new Inventario
                            {
                                CodigoProducto = row["Codigo"].ToString(),
                                IdMedida = Convert.ToInt32(row["IdMedida"]),
                                IdColor = Convert.ToInt32(row["IdColor"]),
                                Cantidad = Convert.ToDouble(row["Cantidad"])
                            },
                            false);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally { miConexion.MiConexion.Close(); }
        }


        /*public DataTable ConsultaEstadoFechaIngreso
            (int estado, DateTime fecha, int rowBase, int rowMax)
        {
            var dataSet = new DataSet();
            try
            {
                CargarAdapter(ConsultaEstadoFechaIngreso_);
            }
            catch (Exception ex)
            {
                throw new Exception(ErrorConsulta + ex.Message);
            }
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
        /// Inicializa una nueva instancia de NpgsqlDataAdapter de tipo StoredProcedure.
        /// </summary>
        /// <param name="cmd">Comando a ejecutar.</param>
        private void CargarAdapter(string cmd)
        {
            this.miAdapter = new NpgsqlDataAdapter(cmd, miConexion.MiConexion);
            this.miAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
        }
    }
}