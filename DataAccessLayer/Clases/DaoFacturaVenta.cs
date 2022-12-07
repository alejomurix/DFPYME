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

        private DaoDian miDaoDian;

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
        private string ConsultaEstadoPeriodoIngreso_ = 
            "consulta_factura_venta_estado_periodo";

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

        private DaoKardex miDaoKardex;

        private Kardex Kardex { set; get; }

        private DaoIngreso miDaoIngreso;

        private DataTable tFacturas { set; get; }

        private DataTable tVenta { set; get; }

        private DataTable tFactura { set; get; }

        private bool AproximacionPrecio;

        /// <summary>
        /// Inicializa una nueva instancia de la clase DaoFacuraVenta.
        /// </summary>
        public DaoFacturaVenta()
        {
            try
            {
                this.miConexion = new Conexion();
                miDaoDian = new DaoDian();
                miDaoKardex = new DaoKardex();
                Kardex = new Kardex();
                miDaoIngreso = new DaoIngreso();
                TablasResumen();
                this.AproximacionPrecio = Convert.ToBoolean(AppConfiguracion.ValorSeccion("tipo_aprox_precio"));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Obtiene el Número consecutivo a se asignado en la Factura.
        /// </summary>
        /// <returns></returns>
        public string ObtenerNumero(bool contado, int idRegimen)
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
                if (idRegimen.Equals(1))
                {
                    var serieDian = miDaoDian.SerieDian();
                    try
                    {
                        Convert.ToInt32(serieDian);
                    }
                    catch
                    {
                        numero = serieDian + numero;
                    }
                }
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
        public int IngresarFactura(FacturaVenta factura, bool edicion, bool anutigua, bool consecutivoCaja)
        {
            var miDaoRemision = new DaoRemision();
            var miDaoProductoFactura = new DaoProductoFacturaVenta();
            var miDaoInventario = new DaoInventario();
            var miDaoPago = new DaoFormaPago();
            var miDaoSaldo = new DaoSaldo();
            var miDaoBono = new DaoBono();
            var miDaoRetencion = new DaoRetencion();
            var miDaoCaja = new DaoCaja();
            var miDaoConsecutivo = new DaoConsecutivo();
            var miDaoIcoBolsa = new DaoImpuestoBolsa();

            bool existeProductoFabricado = false;

            try
            {
                

                //miFactura.EstadoFactura.Id = IdEstado;                              // IdEstado = estado el cual se ha seleccionado para la factura
                //miFactura.EstadoFactura.IdEdit = this.Factura.EstadoFactura.Id;     // IdEdit   = estado el cual estaba la factura antes de ser editada.

                ///Edición 02/01/2021 mejoras en la numeracion de la facturacion.
                ///

                Caja miCaja = new Caja();

                if (!consecutivoCaja)  /// numeracion por resolucion general
                {
                    if (edicion)
                    {
                        if ((factura.EstadoFactura.IdEdit.Equals(3) || factura.EstadoFactura.IdEdit.Equals(4)) &&
                            (factura.EstadoFactura.Id.Equals(1) || factura.EstadoFactura.Id.Equals(2)))
                        {
                            var preFijo = miDaoConsecutivo.Consecutivo("FacturaPrefijo");
                            if (preFijo.Equals("0"))
                            {
                                factura.Numero = miDaoConsecutivo.Consecutivo("Factura");
                            }
                            else
                            {
                                //factura.Numero = miDaoConsecutivo.Consecutivo("FacturaPrefijo") + miDaoConsecutivo.Consecutivo("Factura");
                                factura.Numero = preFijo + miDaoConsecutivo.Consecutivo("Factura");
                            }

                            factura.IdResolucionDian = Convert.ToInt32(miDaoConsecutivo.Consecutivo("IdRegistroDian"));
                        }
                    }
                    else
                    {
                        if (factura.EstadoFactura.Id == 1 || factura.EstadoFactura.Id == 2)
                        {
                            var preFijo = miDaoConsecutivo.Consecutivo("FacturaPrefijo");
                            if (preFijo.Equals("0"))
                            {
                                factura.Numero = miDaoConsecutivo.Consecutivo("Factura");
                            }
                            else
                            {
                                //factura.Numero = miDaoConsecutivo.Consecutivo("FacturaPrefijo") + miDaoConsecutivo.Consecutivo("Factura");
                                factura.Numero = preFijo + miDaoConsecutivo.Consecutivo("Factura");
                            }
                            factura.IdResolucionDian = Convert.ToInt32(miDaoConsecutivo.Consecutivo("IdRegistroDian"));
                        }
                        else
                        {
                            if (factura.EstadoFactura.Id == 3)  // Pendiente   FacturaPendiente
                            {
                                factura.Numero = miDaoConsecutivo.Consecutivo("ConsFacturaPendiente") + miDaoConsecutivo.Consecutivo("FacturaPendiente");
                            }
                            else   //  Cotización  Cotizacion
                            {
                                factura.Numero = miDaoConsecutivo.Consecutivo("ConsCotizacion") + miDaoConsecutivo.Consecutivo("Cotizacion");
                            }
                        }
                    }
                }
                else
                {
                    miCaja = miDaoCaja.CajaId(factura.Caja.Id);  /// numeracion por resolucion por caja

                    if (edicion)
                    {
                        if ((factura.EstadoFactura.IdEdit.Equals(3) || factura.EstadoFactura.IdEdit.Equals(4)) &&
                            (factura.EstadoFactura.Id.Equals(1) || factura.EstadoFactura.Id.Equals(2)))
                        {
                            if (miCaja.Prefijo.Equals("0"))
                            {
                                factura.Numero = miCaja.NumeroFactura;
                            }
                            else
                            {
                                factura.Numero = miCaja.Prefijo + miCaja.NumeroFactura;
                            }
                            factura.IdResolucionDian = miCaja.IdDian;
                        }
                    }
                    else
                    {
                        if (factura.EstadoFactura.Id == 1 || factura.EstadoFactura.Id == 2)
                        {
                            if (miCaja.Prefijo.Equals("0"))
                            {
                                factura.Numero = miCaja.NumeroFactura;
                            }
                            else
                            {
                                factura.Numero = miCaja.Prefijo + miCaja.NumeroFactura;
                            }
                            factura.IdResolucionDian = miCaja.IdDian;
                        }
                        else
                        {
                            if (factura.EstadoFactura.Id == 3)  // Pendiente   FacturaPendiente
                            {
                                factura.Numero = miDaoConsecutivo.Consecutivo("ConsFacturaPendiente") + miDaoConsecutivo.Consecutivo("FacturaPendiente");
                            }
                            else   //  Cotización  Cotizacion
                            {
                                factura.Numero = miDaoConsecutivo.Consecutivo("ConsCotizacion") + miDaoConsecutivo.Consecutivo("Cotizacion");
                            }
                        }
                    }
                }


                /*if (edicion)
                {
                    if (factura.EstadoFactura.IdEdit == 3 || factura.EstadoFactura.IdEdit == 4)
                    {
                 *
                 * if (miCaja.Prefijo.Equals("0"))
                    {
                        factura.Numero = miCaja.NumeroFactura;
                    }
                    else
                    {
                        factura.Numero = miCaja.Prefijo + miCaja.NumeroFactura;
                    }
                    factura.IdResolucionDian = miCaja.IdDian;

                        var preFijo = miDaoConsecutivo.Consecutivo("FacturaPrefijo");
                        if (preFijo.Equals("0"))
                        {
                            factura.Numero = miDaoConsecutivo.Consecutivo("Factura");
                        }
                        else
                        {
                            //factura.Numero = miDaoConsecutivo.Consecutivo("FacturaPrefijo") + miDaoConsecutivo.Consecutivo("Factura");
                            factura.Numero = preFijo + miDaoConsecutivo.Consecutivo("Factura");
                        }

                        factura.IdResolucionDian = Convert.ToInt32(miDaoConsecutivo.Consecutivo("IdRegistroDian"));

                    }
                }
                else
                {
                    if (factura.EstadoFactura.Id == 1 || factura.EstadoFactura.Id == 2)
                    {

                        var preFijo = miDaoConsecutivo.Consecutivo("FacturaPrefijo");
                        if (preFijo.Equals("0"))
                        {
                            factura.Numero = miDaoConsecutivo.Consecutivo("Factura");
                        }
                        else
                        {
                            //factura.Numero = miDaoConsecutivo.Consecutivo("FacturaPrefijo") + miDaoConsecutivo.Consecutivo("Factura");
                            factura.Numero = preFijo + miDaoConsecutivo.Consecutivo("Factura");
                        }

                        factura.IdResolucionDian = Convert.ToInt32(miDaoConsecutivo.Consecutivo("IdRegistroDian"));

                    }
                }*/

                //Edición 18/06/2019 mejoras en la numeracion de la facturacion.
                /*if ((!edicion && (factura.EstadoFactura.Id == 1 || factura.EstadoFactura.Id == 2)) ||
                     edicion && (factura.EstadoFactura.IdEdit == 3 || factura.EstadoFactura.IdEdit == 4))
                {
                    // Actualizacion, mejora para adjudicar el numero de la factura.  19 nov. de 2019
                    
                    if (miCaja.Prefijo.Equals("0"))
                    {
                        factura.Numero = miCaja.NumeroFactura;
                    }
                    else
                    {
                        factura.Numero = miCaja.Prefijo + miCaja.NumeroFactura;
                    }
                    factura.IdResolucionDian = miCaja.IdDian;*/
                    

                   /* var preFijo = miDaoConsecutivo.Consecutivo("FacturaPrefijo");
                    if (preFijo.Equals("0"))
                    {
                        factura.Numero = miDaoConsecutivo.Consecutivo("Factura");
                    }
                    else
                    {
                                  //factura.Numero = miDaoConsecutivo.Consecutivo("FacturaPrefijo") + miDaoConsecutivo.Consecutivo("Factura");
                        factura.Numero = preFijo + miDaoConsecutivo.Consecutivo("Factura");
                    }

                    factura.IdResolucionDian = Convert.ToInt32(miDaoConsecutivo.Consecutivo("IdRegistroDian"));
                    */
                //}
                                /*var preFijo = miDaoConsecutivo.Consecutivo("FacturaPrefijo");
                                if (preFijo.Equals("0"))
                                {
                                    factura.Numero = miDaoConsecutivo.Consecutivo("Factura");
                                }
                                else
                                {
                                    factura.Numero = miDaoConsecutivo.Consecutivo("FacturaPrefijo") + miDaoConsecutivo.Consecutivo("Factura");
                                }*/

                                //factura.IdResolucionDian = Convert.ToInt32(miDaoConsecutivo.Consecutivo("IdRegistroDian"));
                if (!anutigua)
                {
                    if (factura.EstadoFactura.Id == 1 || factura.EstadoFactura.Id == 2)
                    {
                        if (!edicion)
                        {
                                            //    miDaoConsecutivo.ActualizarConsecutivo("Factura");
                            if (!consecutivoCaja)
                            {
                                miDaoConsecutivo.ActualizarNumeroFacturaDeVenta("IdRegistroDian", "FacturaPrefijo", "Factura");
                            }
                            else
                            {
                                miDaoCaja.ActualizarConsecutivoFactura(miCaja.Id, miCaja.NumeroFactura);
                            }
                        }
                        if (factura.Pendiente)
                        {
                                            //  miDaoConsecutivo.ActualizarConsecutivo("Factura");
                            if (!consecutivoCaja)
                            {
                                miDaoConsecutivo.ActualizarNumeroFacturaDeVenta("IdRegistroDian", "FacturaPrefijo", "Factura");
                            }
                            else
                            {
                                miDaoCaja.ActualizarConsecutivoFactura(miCaja.Id, miCaja.NumeroFactura);
                            }
                        }
                                            //ActualizarConsecutivo(NumberIncrement(factura.Numero), true);
                    }
                    else
                    {
                        if (!edicion)
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
                }

                // End edición 18/06/2019 mejoras en la numeracion de la facturacion.

                if (edicion)
                {
                    RetirarProductos(factura, miDaoProductoFactura, miDaoInventario);
                    CargarComando(Editar);
                }
                else
                {
                    CargarComando(Ingresar);
                }
                //miComando.Parameters.AddWithValue("numero", factura.Numero);
                if (edicion)
                {
                    miComando.Parameters.AddWithValue("id", factura.Id);
                    //miComando.Parameters.AddWithValue("numeroEdit", factura.NumeroEdit);
                    miComando.Parameters.AddWithValue("numero", factura.Numero);
                }
                else
                {
                    miComando.Parameters.AddWithValue("numero", factura.Numero);
                }
                miComando.Parameters.AddWithValue("cliente", factura.Proveedor.NitProveedor);
                miComando.Parameters.AddWithValue("usuario", factura.Usuario.Id);
                miComando.Parameters.AddWithValue("caja", factura.Caja.Id);
                if (edicion)
                {
                    miComando.Parameters.AddWithValue("estado", factura.EstadoFactura.Id);
                }
                else
                {
                    miComando.Parameters.AddWithValue("estado", factura.EstadoFactura.IdEdit);
                }
                miComando.Parameters.AddWithValue("fecha", factura.FechaIngreso);
                miComando.Parameters.AddWithValue("hora", factura.FechaIngreso.TimeOfDay);
                miComando.Parameters.AddWithValue("descuento", factura.Descuento);
                miComando.Parameters.AddWithValue("limite", factura.FechaLimite);
                miComando.Parameters.AddWithValue("aplicaDescto", factura.AplicaDescuento);
                miComando.Parameters.AddWithValue("estado", factura.Estado);

                if (edicion)
                {
                    if ((factura.EstadoFactura.IdEdit.Equals(3) || factura.EstadoFactura.IdEdit.Equals(4)) &&
                        (factura.EstadoFactura.Id.Equals(1) || factura.EstadoFactura.Id.Equals(2)))
                    {
                        miComando.Parameters.AddWithValue("serie", Convert.ToInt32(miDaoConsecutivo.Consecutivo("Serie")));
                        miComando.Parameters.AddWithValue("idResDian", factura.IdResolucionDian);
                        ///miComando.Parameters.AddWithValue("nameSt", factura.NameStation);
                    }
                    /*if (!(factura.EstadoFactura.Id.Equals(1) || factura.EstadoFactura.Id.Equals(2)))
                    {
                        miComando.Parameters.AddWithValue("serie", Convert.ToInt32(miDaoConsecutivo.Consecutivo("Serie")));
                    }*/
                }
                else
                {
                    miComando.Parameters.AddWithValue("serie", Convert.ToInt32(miDaoConsecutivo.Consecutivo("Serie")));
                    miComando.Parameters.AddWithValue("idResDian", factura.IdResolucionDian);
                    miComando.Parameters.AddWithValue("nameSt", factura.NameStation);
                }

                miConexion.MiConexion.Open();
                var id = 0;
                if (edicion)
                {
                    id = factura.Id;
                    miComando.ExecuteNonQuery();
                }
                else
                {
                    id = Convert.ToInt32(miComando.ExecuteScalar());
                }
                miConexion.MiConexion.Close();
                miComando.Dispose();
                if (edicion)
                {
                    if ((factura.EstadoFactura.IdEdit.Equals(3) || factura.EstadoFactura.IdEdit.Equals(4)) &&
                        (factura.EstadoFactura.Id.Equals(1) || factura.EstadoFactura.Id.Equals(2)))
                    {
                        miDaoConsecutivo.ActualizarConsecutivo("Serie");
                    }
                    /*if (!(factura.EstadoFactura.Id.Equals(1) || factura.EstadoFactura.Id.Equals(2)))
                    {
                        miDaoConsecutivo.ActualizarConsecutivo("Serie");
                    }*/
                }
                else
                {
                    miDaoConsecutivo.ActualizarConsecutivo("Serie");
                }
                if (factura.Remision_)
                {
                    miDaoRemision.RemisionFacturada(Convert.ToInt32(factura.NumeroEdit));
                }

                var productosDB = miDaoProductoFactura.ProductoFacturaVenta(factura.Id);
                double cant = 0;

                foreach (ProductoFacturaProveedor producto in factura.Productos)
                {
                    if (edicion)
                    {
                        producto.IdFactura = factura.Id;
                    }
                    else
                    {
                        producto.IdFactura = id;
                    }
                    if (!producto.Retorno)
                    {
                        producto.Costo = CostoDeProducto(producto.Producto.CodigoInternoProducto, producto.Producto.IdTipoInventario);
                    }
                    if (edicion)
                    {
                        if ((factura.EstadoFactura.Id == 1 && factura.EstadoFactura.IdEdit == 2) || 
                            (factura.EstadoFactura.Id == 2 && factura.EstadoFactura.IdEdit == 2))
                        {
                            var qRow = productosDB.AsEnumerable().Where(p => p.Field<int>("Id") == producto.Id);
                            if (qRow.Count() > 0)
                            {
                                var pRow = qRow.Single();
                                cant = producto.Inventario.Cantidad - Convert.ToDouble(pRow["Cantidad"]);
                                if (cant != 0)  // Se añadio cantidades al registro del producto.
                                {
                                    if (cant < 0)
                                    {
                                        cant = Convert.ToDouble(pRow["Cantidad"]) - producto.Inventario.Cantidad;
                                        miDaoInventario.ActualizarInventario(new Inventario
                                        {
                                            CodigoProducto = producto.Inventario.CodigoProducto,
                                            IdMedida = producto.Inventario.IdMedida,
                                            IdColor = producto.Inventario.IdColor,
                                            Cantidad = cant 
                                        }, false);
                                    }
                                    else
                                    {
                                        miDaoInventario.ActualizarInventario(new Inventario
                                        {
                                            CodigoProducto = producto.Inventario.CodigoProducto,
                                            IdMedida = producto.Inventario.IdMedida,
                                            IdColor = producto.Inventario.IdColor,
                                            Cantidad = cant
                                        }, true);
                                    }

                                   /* miDaoInventario.ActualizarInventario(new Inventario
                                    {
                                        CodigoProducto = producto.Inventario.CodigoProducto,
                                        IdMedida = producto.Inventario.IdMedida,
                                        IdColor = producto.Inventario.IdColor,
                                        Cantidad = (producto.Inventario.Cantidad - Convert.ToDouble(pRow["Cantidad"]))
                                    }, true);*/
                                }
                            }
                        }

                        //if ((pfRow.Inventario.Cantidad - Convert.ToDouble(pRow["Cantidad"])) != 0)
                            //{

                        if (producto.Save)//indica que el registro es nuevo
                        {
                            miDaoProductoFactura.IngresarProductoFactura(producto);
                            if (factura.EstadoFactura.Id != 4)
                            {
                                if (!producto.Retorno)
                                {
                                    miDaoInventario.ActualizarInventario(producto.Inventario, true);
                                }
                            }
                        }
                        else
                        {
                            if (!producto.Retorno)
                            {
                                if ((factura.EstadoFactura.Id == 1 || factura.EstadoFactura.Id == 2) && factura.EstadoFactura.IdEdit > 2)
                                {
                                    //var cant = CantidadProducto(producto.Id);
                                    miDaoInventario.ActualizarInventario(new Inventario
                                    {
                                        CodigoProducto = producto.Inventario.CodigoProducto,
                                        IdMedida = producto.Inventario.IdMedida,
                                        IdColor = producto.Inventario.IdColor,
                                        Cantidad = producto.Inventario.Cantidad
                                    }, true);
                                }

                                miDaoProductoFactura.EditarProductoFactura(producto);

                                /*var cant = CantidadProducto(producto.Id);
                                miDaoInventario.ActualizarInventario(new Inventario
                                {
                                    CodigoProducto = producto.Inventario.CodigoProducto,
                                    IdMedida = producto.Inventario.IdMedida,
                                    IdColor = producto.Inventario.IdColor,
                                    Cantidad = cant
                                }, false);

                                miDaoProductoFactura.EditarProductoFactura(producto);

                                miDaoInventario.ActualizarInventario(new Inventario
                                {
                                    CodigoProducto = producto.Inventario.CodigoProducto,
                                    IdMedida = producto.Inventario.IdMedida,
                                    IdColor = producto.Inventario.IdColor,
                                    Cantidad = producto.Inventario.Cantidad
                                }, true);*/
                            }
                        }
                    }
                    else
                    {
                        miDaoProductoFactura.IngresarProductoFactura(producto);
                        if (factura.EstadoFactura.Id != 4 && factura.EstadoFactura.Id != 3)
                        {
                            if (!factura.Remision_)
                            {
                                if (!producto.Retorno)
                                {
                                    if (producto.Producto.IdTipoInventario != 3)  // IdTipoInventario = 3 : Productos fabricados por la empresa. Descuenta insumos usados.
                                    {
                                        miDaoInventario.ActualizarInventario(producto.Inventario, true);
                                    }
                                    else
                                    {
                                        existeProductoFabricado = true;
                                    }
                                }
                            }
                        }
                    }
                }
                /// Act. codigo 25 feb 2021: update inventario decuerdo a los productos fabricados
                if (existeProductoFabricado)
                {
                    foreach (var product in factura.Productos)
                    {
                        if (!product.Retorno)
                        {
                            if (product.Producto.IdTipoInventario.Equals(3))  // IdTipoInventario = 3 : Productos fabricados por la empresa. Descuenta insumos usados.
                            {
                                miDaoInventario.ActualizarCantidadProductoPreparado(product.Producto.CodigoInternoProducto, product.Inventario.Cantidad, true);
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


                // Edición 18/06/2019  mejoras en numeracion de facturacion
                /*if (!anutigua)
                {
                    if (factura.EstadoFactura.Id == 1 || factura.EstadoFactura.Id == 2)
                    {
                        if (!edicion)
                        {
                        //    miDaoConsecutivo.ActualizarConsecutivo("Factura");
                            miDaoConsecutivo.ActualizarNumeroFacturaDeVenta("IdRegistroDian", "FacturaPrefijo", "Factura");
                        }
                        if (factura.Pendiente)
                        {
                        //    miDaoConsecutivo.ActualizarConsecutivo("Factura");
                            miDaoConsecutivo.ActualizarNumeroFacturaDeVenta("IdRegistroDian", "FacturaPrefijo", "Factura");
                        }
                        //ActualizarConsecutivo(NumberIncrement(factura.Numero), true);
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
                }*/



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
                                    if (edicion)
                                    {
                                        forma.IdFactura = factura.Id;
                                    }
                                    else
                                    {
                                        forma.IdFactura = id;
                                    }
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
                    factura.Retencion.IdFactura = id;
                    if (factura.Retencion.Id.Equals(0))
                    {
                        miDaoRetencion.IngresarFacturaVentaRetencion(factura.Retencion);
                    }
                    else
                    {
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

                // Kardex.
                if (!anutigua && !edicion)
                {
                    if (factura.EstadoFactura.Id.Equals(1) || factura.EstadoFactura.Id.Equals(2))
                    {
                        foreach (ProductoFacturaProveedor producto in factura.Productos)
                        {
                            if (!producto.Retorno)
                            {
                                Kardex.Codigo = producto.Producto.CodigoInternoProducto;
                                Kardex.IdUsuario = factura.Usuario.Id;
                                Kardex.IdConcepto = 10;
                                Kardex.NoDocumento = factura.Numero;
                                Kardex.Fecha = DateTime.Now;
                                Kardex.Cantidad = producto.Inventario.Cantidad;
                                double valorMenosDescto = Math.Round((producto.Producto.ValorVentaProducto -
                                    (producto.Producto.ValorVentaProducto * producto.Producto.Descuento / 100)), 1);
                                double iva = Math.Round(
                                    (valorMenosDescto * producto.Producto.ValorIva / 100), 1);
                                Kardex.Valor = Convert.ToInt32(valorMenosDescto + iva);
                                Kardex.Total = Kardex.Cantidad * Kardex.Valor;
                                miDaoKardex.Insertar(Kardex);
                            }
                        }
                    }
                }

                if (factura.IcoBolsaPlastica.Cantidad > 0)
                {
                    factura.IcoBolsaPlastica.IdFactura = id;
                    miDaoIcoBolsa.Insertar(factura.IcoBolsaPlastica);
                }

                // Acumulado de Ingresos.
                //miDaoIngreso.IngresarAcumulado(factura.Caja.Id, factura.FechaIngreso, ValorFactura(factura.Numero));

                //  Retorno de articulo
                /*var tRetornos = miDaoProductoFactura.RetornosTemporal();
                foreach (DataRow rRow in tRetornos.Rows)
                {
                    var producto = new ProductoFacturaProveedor();
                    producto.NumeroFactura = factura.Numero;
                    producto.Producto.CodigoInternoProducto = rRow["codigo"].ToString();
                    producto.Inventario.IdMedida = Convert.ToInt32(rRow["idmedida"]);
                    producto.Inventario.IdColor = Convert.ToInt32(rRow["idcolor"]);
                    producto.Cantidad = Convert.ToDouble(rRow["cantidad"]);
                    producto.Producto.ValorVentaProducto = Convert.ToDouble(rRow["valor"]);
                    producto.Producto.ValorIva = Convert.ToDouble(rRow["iva"]);
                    miDaoProductoFactura.IngresarRetorno(producto);
                }*/
                //miDaoProductoFactura.EliminarRetornoTemporal();
                return id;
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

        /// Funcion de insertar factura, cuando la autorización de numeración es por cada caja.
        public int IngresarFactura___(FacturaVenta factura, bool edicion, bool anutigua)
        {
            var miDaoRemision = new DaoRemision();
            var miDaoProductoFactura = new DaoProductoFacturaVenta();
            var miDaoInventario = new DaoInventario();
            var miDaoPago = new DaoFormaPago();
            var miDaoSaldo = new DaoSaldo();
            var miDaoBono = new DaoBono();
            var miDaoRetencion = new DaoRetencion();
            var miDaoCaja = new DaoCaja();
            var miDaoConsecutivo = new DaoConsecutivo();
            var miDaoIcoBolsa = new DaoImpuestoBolsa();

            bool existeProductoFabricado = false;

            try
            {
                var miCaja = miDaoCaja.CajaId(factura.Caja.Id);

                //miFactura.EstadoFactura.Id = IdEstado;                              // IdEstado = estado el cual se ha seleccionado para la factura
                //miFactura.EstadoFactura.IdEdit = this.Factura.EstadoFactura.Id;     // IdEdit   = estado el cual estaba la factura antes de ser editada.

                ///Edición 02/01/2021 mejoras en la numeracion de la facturacion.
                /**if (edicion)
                {
                    if ((factura.EstadoFactura.IdEdit.Equals(3) || factura.EstadoFactura.IdEdit.Equals(4)) &&
                        (factura.EstadoFactura.Id.Equals(1) || factura.EstadoFactura.Id.Equals(2)))
                    {
                        var preFijo = miDaoConsecutivo.Consecutivo("FacturaPrefijo");
                        if (preFijo.Equals("0"))
                        {
                            factura.Numero = miDaoConsecutivo.Consecutivo("Factura");
                        }
                        else
                        {
                            //factura.Numero = miDaoConsecutivo.Consecutivo("FacturaPrefijo") + miDaoConsecutivo.Consecutivo("Factura");
                            factura.Numero = preFijo + miDaoConsecutivo.Consecutivo("Factura");
                        }

                        factura.IdResolucionDian = Convert.ToInt32(miDaoConsecutivo.Consecutivo("IdRegistroDian"));
                    }
                }
                else
                {
                    var preFijo = miDaoConsecutivo.Consecutivo("FacturaPrefijo");
                    if (preFijo.Equals("0"))
                    {
                        factura.Numero = miDaoConsecutivo.Consecutivo("Factura");
                    }
                    else
                    {
                        //factura.Numero = miDaoConsecutivo.Consecutivo("FacturaPrefijo") + miDaoConsecutivo.Consecutivo("Factura");
                        factura.Numero = preFijo + miDaoConsecutivo.Consecutivo("Factura");
                    }

                    factura.IdResolucionDian = Convert.ToInt32(miDaoConsecutivo.Consecutivo("IdRegistroDian"));
                }
                */


                if (edicion)
                {
                    if ((factura.EstadoFactura.IdEdit.Equals(3) || factura.EstadoFactura.IdEdit.Equals(4)) &&
                        (factura.EstadoFactura.Id.Equals(1) || factura.EstadoFactura.Id.Equals(2)))
                    {
                        if (miCaja.Prefijo.Equals("0"))
                        {
                            factura.Numero = miCaja.NumeroFactura;
                        }
                        else
                        {
                            factura.Numero = miCaja.Prefijo + miCaja.NumeroFactura;
                        }
                        factura.IdResolucionDian = miCaja.IdDian;
                    }
                }
                else
                {
                    if (factura.EstadoFactura.Id == 1 || factura.EstadoFactura.Id == 2)
                    {
                        if (miCaja.Prefijo.Equals("0"))
                        {
                            factura.Numero = miCaja.NumeroFactura;
                        }
                        else
                        {
                            factura.Numero = miCaja.Prefijo + miCaja.NumeroFactura;
                        }
                        factura.IdResolucionDian = miCaja.IdDian;
                    }
                    else
                    {
                        if (factura.EstadoFactura.Id == 3)  // Pendiente   FacturaPendiente
                        {
                            factura.Numero = miDaoConsecutivo.Consecutivo("ConsFacturaPendiente") + miDaoConsecutivo.Consecutivo("FacturaPendiente");
                        }
                        else   //  Cotización  Cotizacion
                        {
                            factura.Numero = miDaoConsecutivo.Consecutivo("ConsCotizacion") + miDaoConsecutivo.Consecutivo("Cotizacion");
                        }
                    }


                    /*if (miCaja.Prefijo.Equals("0"))
                    {
                        factura.Numero = miCaja.NumeroFactura;
                    }
                    else
                    {
                        factura.Numero = miCaja.Prefijo + miCaja.NumeroFactura;
                    }
                    factura.IdResolucionDian = miCaja.IdDian;*/
                }


                /*if (edicion)
                {
                    if (factura.EstadoFactura.IdEdit == 3 || factura.EstadoFactura.IdEdit == 4)
                    {
                 *
                 * if (miCaja.Prefijo.Equals("0"))
                    {
                        factura.Numero = miCaja.NumeroFactura;
                    }
                    else
                    {
                        factura.Numero = miCaja.Prefijo + miCaja.NumeroFactura;
                    }
                    factura.IdResolucionDian = miCaja.IdDian;

                        var preFijo = miDaoConsecutivo.Consecutivo("FacturaPrefijo");
                        if (preFijo.Equals("0"))
                        {
                            factura.Numero = miDaoConsecutivo.Consecutivo("Factura");
                        }
                        else
                        {
                            //factura.Numero = miDaoConsecutivo.Consecutivo("FacturaPrefijo") + miDaoConsecutivo.Consecutivo("Factura");
                            factura.Numero = preFijo + miDaoConsecutivo.Consecutivo("Factura");
                        }

                        factura.IdResolucionDian = Convert.ToInt32(miDaoConsecutivo.Consecutivo("IdRegistroDian"));

                    }
                }
                else
                {
                    if (factura.EstadoFactura.Id == 1 || factura.EstadoFactura.Id == 2)
                    {

                        var preFijo = miDaoConsecutivo.Consecutivo("FacturaPrefijo");
                        if (preFijo.Equals("0"))
                        {
                            factura.Numero = miDaoConsecutivo.Consecutivo("Factura");
                        }
                        else
                        {
                            //factura.Numero = miDaoConsecutivo.Consecutivo("FacturaPrefijo") + miDaoConsecutivo.Consecutivo("Factura");
                            factura.Numero = preFijo + miDaoConsecutivo.Consecutivo("Factura");
                        }

                        factura.IdResolucionDian = Convert.ToInt32(miDaoConsecutivo.Consecutivo("IdRegistroDian"));

                    }
                }*/

                //Edición 18/06/2019 mejoras en la numeracion de la facturacion.
                /*if ((!edicion && (factura.EstadoFactura.Id == 1 || factura.EstadoFactura.Id == 2)) ||
                     edicion && (factura.EstadoFactura.IdEdit == 3 || factura.EstadoFactura.IdEdit == 4))
                {
                    // Actualizacion, mejora para adjudicar el numero de la factura.  19 nov. de 2019
                    
                    if (miCaja.Prefijo.Equals("0"))
                    {
                        factura.Numero = miCaja.NumeroFactura;
                    }
                    else
                    {
                        factura.Numero = miCaja.Prefijo + miCaja.NumeroFactura;
                    }
                    factura.IdResolucionDian = miCaja.IdDian;*/


                /* var preFijo = miDaoConsecutivo.Consecutivo("FacturaPrefijo");
                 if (preFijo.Equals("0"))
                 {
                     factura.Numero = miDaoConsecutivo.Consecutivo("Factura");
                 }
                 else
                 {
                               //factura.Numero = miDaoConsecutivo.Consecutivo("FacturaPrefijo") + miDaoConsecutivo.Consecutivo("Factura");
                     factura.Numero = preFijo + miDaoConsecutivo.Consecutivo("Factura");
                 }

                 factura.IdResolucionDian = Convert.ToInt32(miDaoConsecutivo.Consecutivo("IdRegistroDian"));
                 */
                //}
                /*var preFijo = miDaoConsecutivo.Consecutivo("FacturaPrefijo");
                if (preFijo.Equals("0"))
                {
                    factura.Numero = miDaoConsecutivo.Consecutivo("Factura");
                }
                else
                {
                    factura.Numero = miDaoConsecutivo.Consecutivo("FacturaPrefijo") + miDaoConsecutivo.Consecutivo("Factura");
                }*/

                //factura.IdResolucionDian = Convert.ToInt32(miDaoConsecutivo.Consecutivo("IdRegistroDian"));
                if (!anutigua)
                {
                    if (factura.EstadoFactura.Id == 1 || factura.EstadoFactura.Id == 2)
                    {
                        if (!edicion)
                        {
                            //    miDaoConsecutivo.ActualizarConsecutivo("Factura");
                            ///miDaoConsecutivo.ActualizarNumeroFacturaDeVenta("IdRegistroDian", "FacturaPrefijo", "Factura");

                            miDaoCaja.ActualizarConsecutivoFactura(miCaja.Id, miCaja.NumeroFactura);
                        }
                        if (factura.Pendiente)
                        {
                            //  miDaoConsecutivo.ActualizarConsecutivo("Factura");
                            ///miDaoConsecutivo.ActualizarNumeroFacturaDeVenta("IdRegistroDian", "FacturaPrefijo", "Factura");

                            miDaoCaja.ActualizarConsecutivoFactura(miCaja.Id, miCaja.NumeroFactura);
                        }
                        //ActualizarConsecutivo(NumberIncrement(factura.Numero), true);
                    }
                    else
                    {
                        if (!edicion)
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
                }

                // End edición 18/06/2019 mejoras en la numeracion de la facturacion.

                if (edicion)
                {
                    RetirarProductos(factura, miDaoProductoFactura, miDaoInventario);
                    CargarComando(Editar);
                }
                else
                {
                    CargarComando(Ingresar);
                }
                //miComando.Parameters.AddWithValue("numero", factura.Numero);
                if (edicion)
                {
                    miComando.Parameters.AddWithValue("id", factura.Id);
                    //miComando.Parameters.AddWithValue("numeroEdit", factura.NumeroEdit);
                    miComando.Parameters.AddWithValue("numero", factura.Numero);
                }
                else
                {
                    miComando.Parameters.AddWithValue("numero", factura.Numero);
                }
                miComando.Parameters.AddWithValue("cliente", factura.Proveedor.NitProveedor);
                miComando.Parameters.AddWithValue("usuario", factura.Usuario.Id);
                miComando.Parameters.AddWithValue("caja", factura.Caja.Id);
                if (edicion)
                {
                    miComando.Parameters.AddWithValue("estado", factura.EstadoFactura.Id);
                }
                else
                {
                    miComando.Parameters.AddWithValue("estado", factura.EstadoFactura.IdEdit);
                }
                miComando.Parameters.AddWithValue("fecha", factura.FechaIngreso);
                miComando.Parameters.AddWithValue("hora", factura.FechaIngreso.TimeOfDay);
                miComando.Parameters.AddWithValue("descuento", factura.Descuento);
                miComando.Parameters.AddWithValue("limite", factura.FechaLimite);
                miComando.Parameters.AddWithValue("aplicaDescto", factura.AplicaDescuento);
                miComando.Parameters.AddWithValue("estado", factura.Estado);
                if (edicion)
                {
                    if ((factura.EstadoFactura.IdEdit.Equals(3) || factura.EstadoFactura.IdEdit.Equals(4)) &&
                        (factura.EstadoFactura.Id.Equals(1) || factura.EstadoFactura.Id.Equals(2)))
                    {
                        miComando.Parameters.AddWithValue("serie", Convert.ToInt32(miDaoConsecutivo.Consecutivo("Serie")));
                        miComando.Parameters.AddWithValue("idResDian", factura.IdResolucionDian);
                    }
                    /*if (!(factura.EstadoFactura.Id.Equals(1) || factura.EstadoFactura.Id.Equals(2)))
                    {
                        miComando.Parameters.AddWithValue("serie", Convert.ToInt32(miDaoConsecutivo.Consecutivo("Serie")));
                    }*/
                }
                else
                {
                    miComando.Parameters.AddWithValue("serie", Convert.ToInt32(miDaoConsecutivo.Consecutivo("Serie")));
                    miComando.Parameters.AddWithValue("idResDian", factura.IdResolucionDian);
                }
                miConexion.MiConexion.Open();
                var id = 0;
                if (edicion)
                {
                    id = factura.Id;
                    miComando.ExecuteNonQuery();
                }
                else
                {
                    id = Convert.ToInt32(miComando.ExecuteScalar());
                }
                miConexion.MiConexion.Close();
                miComando.Dispose();
                if (edicion)
                {
                    if ((factura.EstadoFactura.IdEdit.Equals(3) || factura.EstadoFactura.IdEdit.Equals(4)) &&
                        (factura.EstadoFactura.Id.Equals(1) || factura.EstadoFactura.Id.Equals(2)))
                    {
                        miDaoConsecutivo.ActualizarConsecutivo("Serie");
                    }
                    /*if (!(factura.EstadoFactura.Id.Equals(1) || factura.EstadoFactura.Id.Equals(2)))
                    {
                        miDaoConsecutivo.ActualizarConsecutivo("Serie");
                    }*/
                }
                else
                {
                    miDaoConsecutivo.ActualizarConsecutivo("Serie");
                }
                if (factura.Remision_)
                {
                    miDaoRemision.RemisionFacturada(Convert.ToInt32(factura.NumeroEdit));
                }

                var productosDB = miDaoProductoFactura.ProductoFacturaVenta(factura.Id);
                double cant = 0;

                foreach (ProductoFacturaProveedor producto in factura.Productos)
                {
                    if (edicion)
                    {
                        producto.IdFactura = factura.Id;
                    }
                    else
                    {
                        producto.IdFactura = id;
                    }
                    if (!producto.Retorno)
                    {
                        producto.Costo = CostoDeProducto(producto.Producto.CodigoInternoProducto, producto.Producto.IdTipoInventario);
                    }
                    if (edicion)
                    {
                        if ((factura.EstadoFactura.Id == 1 && factura.EstadoFactura.IdEdit == 2) ||
                            (factura.EstadoFactura.Id == 2 && factura.EstadoFactura.IdEdit == 2))
                        {
                            var qRow = productosDB.AsEnumerable().Where(p => p.Field<int>("Id") == producto.Id);
                            if (qRow.Count() > 0)
                            {
                                var pRow = qRow.Single();
                                cant = producto.Inventario.Cantidad - Convert.ToDouble(pRow["Cantidad"]);
                                if (cant != 0)  // Se añadio cantidades al registro del producto.
                                {
                                    if (cant < 0)
                                    {
                                        cant = Convert.ToDouble(pRow["Cantidad"]) - producto.Inventario.Cantidad;
                                        miDaoInventario.ActualizarInventario(new Inventario
                                        {
                                            CodigoProducto = producto.Inventario.CodigoProducto,
                                            IdMedida = producto.Inventario.IdMedida,
                                            IdColor = producto.Inventario.IdColor,
                                            Cantidad = cant
                                        }, false);
                                    }
                                    else
                                    {
                                        miDaoInventario.ActualizarInventario(new Inventario
                                        {
                                            CodigoProducto = producto.Inventario.CodigoProducto,
                                            IdMedida = producto.Inventario.IdMedida,
                                            IdColor = producto.Inventario.IdColor,
                                            Cantidad = cant
                                        }, true);
                                    }

                                    /* miDaoInventario.ActualizarInventario(new Inventario
                                     {
                                         CodigoProducto = producto.Inventario.CodigoProducto,
                                         IdMedida = producto.Inventario.IdMedida,
                                         IdColor = producto.Inventario.IdColor,
                                         Cantidad = (producto.Inventario.Cantidad - Convert.ToDouble(pRow["Cantidad"]))
                                     }, true);*/
                                }
                            }
                        }

                        //if ((pfRow.Inventario.Cantidad - Convert.ToDouble(pRow["Cantidad"])) != 0)
                        //{

                        if (producto.Save)//indica que el registro es nuevo
                        {
                            miDaoProductoFactura.IngresarProductoFactura(producto);
                            if (factura.EstadoFactura.Id != 4)
                            {
                                if (!producto.Retorno)
                                {
                                    miDaoInventario.ActualizarInventario(producto.Inventario, true);
                                }
                            }
                        }
                        else
                        {
                            if (!producto.Retorno)
                            {
                                if ((factura.EstadoFactura.Id == 1 || factura.EstadoFactura.Id == 2) && factura.EstadoFactura.IdEdit > 2)
                                {
                                    //var cant = CantidadProducto(producto.Id);
                                    miDaoInventario.ActualizarInventario(new Inventario
                                    {
                                        CodigoProducto = producto.Inventario.CodigoProducto,
                                        IdMedida = producto.Inventario.IdMedida,
                                        IdColor = producto.Inventario.IdColor,
                                        Cantidad = producto.Inventario.Cantidad
                                    }, true);
                                }

                                miDaoProductoFactura.EditarProductoFactura(producto);

                                /*var cant = CantidadProducto(producto.Id);
                                miDaoInventario.ActualizarInventario(new Inventario
                                {
                                    CodigoProducto = producto.Inventario.CodigoProducto,
                                    IdMedida = producto.Inventario.IdMedida,
                                    IdColor = producto.Inventario.IdColor,
                                    Cantidad = cant
                                }, false);

                                miDaoProductoFactura.EditarProductoFactura(producto);

                                miDaoInventario.ActualizarInventario(new Inventario
                                {
                                    CodigoProducto = producto.Inventario.CodigoProducto,
                                    IdMedida = producto.Inventario.IdMedida,
                                    IdColor = producto.Inventario.IdColor,
                                    Cantidad = producto.Inventario.Cantidad
                                }, true);*/
                            }
                        }
                    }
                    else
                    {
                        miDaoProductoFactura.IngresarProductoFactura(producto);
                        if (factura.EstadoFactura.Id != 4 && factura.EstadoFactura.Id != 3)
                        {
                            if (!factura.Remision_)
                            {
                                if (!producto.Retorno)
                                {
                                    if (producto.Producto.IdTipoInventario != 3)  // IdTipoInventario = 3 : Productos fabricados por la empresa. Descuenta insumos usados.
                                    {
                                        miDaoInventario.ActualizarInventario(producto.Inventario, true);
                                    }
                                    else
                                    {
                                        existeProductoFabricado = true;
                                    }
                                }
                            }
                        }
                    }
                }
                /// Act. codigo 25 feb 2021: update inventario decuerdo a los productos fabricados
                if (existeProductoFabricado)
                {
                    foreach (var product in factura.Productos)
                    {
                        if (!product.Retorno)
                        {
                            if (product.Producto.IdTipoInventario.Equals(3))  // IdTipoInventario = 3 : Productos fabricados por la empresa. Descuenta insumos usados.
                            {
                                miDaoInventario.ActualizarCantidadProductoPreparado(product.Producto.CodigoInternoProducto, product.Inventario.Cantidad, true);
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
                    if (factura.EstadoFactura.Id == 1/* && !edicion*/
                //)
                /*{
                    ActualizarConsecutivo(NumberIncrement(factura.Numero), true);
                }
            }*/


                // Edición 18/06/2019  mejoras en numeracion de facturacion
                /*if (!anutigua)
                {
                    if (factura.EstadoFactura.Id == 1 || factura.EstadoFactura.Id == 2)
                    {
                        if (!edicion)
                        {
                        //    miDaoConsecutivo.ActualizarConsecutivo("Factura");
                            miDaoConsecutivo.ActualizarNumeroFacturaDeVenta("IdRegistroDian", "FacturaPrefijo", "Factura");
                        }
                        if (factura.Pendiente)
                        {
                        //    miDaoConsecutivo.ActualizarConsecutivo("Factura");
                            miDaoConsecutivo.ActualizarNumeroFacturaDeVenta("IdRegistroDian", "FacturaPrefijo", "Factura");
                        }
                        //ActualizarConsecutivo(NumberIncrement(factura.Numero), true);
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
                }*/



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
                                    if (edicion)
                                    {
                                        forma.IdFactura = factura.Id;
                                    }
                                    else
                                    {
                                        forma.IdFactura = id;
                                    }
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
                    factura.Retencion.IdFactura = id;
                    if (factura.Retencion.Id.Equals(0))
                    {
                        miDaoRetencion.IngresarFacturaVentaRetencion(factura.Retencion);
                    }
                    else
                    {
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

                // Kardex.
                if (!anutigua && !edicion)
                {
                    if (factura.EstadoFactura.Id.Equals(1) || factura.EstadoFactura.Id.Equals(2))
                    {
                        foreach (ProductoFacturaProveedor producto in factura.Productos)
                        {
                            if (!producto.Retorno)
                            {
                                Kardex.Codigo = producto.Producto.CodigoInternoProducto;
                                Kardex.IdUsuario = factura.Usuario.Id;
                                Kardex.IdConcepto = 10;
                                Kardex.NoDocumento = factura.Numero;
                                Kardex.Fecha = DateTime.Now;
                                Kardex.Cantidad = producto.Inventario.Cantidad;
                                double valorMenosDescto = Math.Round((producto.Producto.ValorVentaProducto -
                                    (producto.Producto.ValorVentaProducto * producto.Producto.Descuento / 100)), 1);
                                double iva = Math.Round(
                                    (valorMenosDescto * producto.Producto.ValorIva / 100), 1);
                                Kardex.Valor = Convert.ToInt32(valorMenosDescto + iva);
                                Kardex.Total = Kardex.Cantidad * Kardex.Valor;
                                miDaoKardex.Insertar(Kardex);
                            }
                        }
                    }
                }

                if (factura.IcoBolsaPlastica.Cantidad > 0)
                {
                    factura.IcoBolsaPlastica.IdFactura = id;
                    miDaoIcoBolsa.Insertar(factura.IcoBolsaPlastica);
                }

                // Acumulado de Ingresos.
                //miDaoIngreso.IngresarAcumulado(factura.Caja.Id, factura.FechaIngreso, ValorFactura(factura.Numero));

                //  Retorno de articulo
                /*var tRetornos = miDaoProductoFactura.RetornosTemporal();
                foreach (DataRow rRow in tRetornos.Rows)
                {
                    var producto = new ProductoFacturaProveedor();
                    producto.NumeroFactura = factura.Numero;
                    producto.Producto.CodigoInternoProducto = rRow["codigo"].ToString();
                    producto.Inventario.IdMedida = Convert.ToInt32(rRow["idmedida"]);
                    producto.Inventario.IdColor = Convert.ToInt32(rRow["idcolor"]);
                    producto.Cantidad = Convert.ToDouble(rRow["cantidad"]);
                    producto.Producto.ValorVentaProducto = Convert.ToDouble(rRow["valor"]);
                    producto.Producto.ValorIva = Convert.ToDouble(rRow["iva"]);
                    miDaoProductoFactura.IngresarRetorno(producto);
                }*/
                //miDaoProductoFactura.EliminarRetornoTemporal();
                return id;
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



        public int IngresarFactura_(FacturaVenta factura, bool edicion, bool anutigua)
        {
            var miDaoRemision = new DaoRemision();
            var miDaoProductoFactura = new DaoProductoFacturaVenta();
            var miDaoInventario = new DaoInventario();
            var miDaoPago = new DaoFormaPago();
            var miDaoSaldo = new DaoSaldo();
            var miDaoBono = new DaoBono();
            var miDaoRetencion = new DaoRetencion();
            var miDaoCaja = new DaoCaja();
            var miDaoConsecutivo = new DaoConsecutivo();
            var miDaoIcoBolsa = new DaoImpuestoBolsa();

            try
            {
                var miCaja = miDaoCaja.CajaId(factura.Caja.Id);

                //miFactura.EstadoFactura.Id = IdEstado;                              // IdEstado = estado el cual se ha seleccionado para la factura
                //miFactura.EstadoFactura.IdEdit = this.Factura.EstadoFactura.Id;     // IdEdit   = estado el cual estaba la factura antes de ser editada.

                //Edición 18/06/2019 mejoras en la numeracion de la facturacion.
                if ((!edicion && (factura.EstadoFactura.Id == 1 || factura.EstadoFactura.Id == 2)) ||
                     edicion && (factura.EstadoFactura.IdEdit == 3 || factura.EstadoFactura.IdEdit == 4))
                {
                    // Actualizacion, mejora para adjudicar el numero de la factura.  19 nov. de 2019

                    if (miCaja.Prefijo.Equals("0"))
                    {
                        factura.Numero = miCaja.NumeroFactura;
                    }
                    else
                    {
                        factura.Numero = miCaja.Prefijo + miCaja.NumeroFactura;
                    }
                    factura.IdResolucionDian = miCaja.IdDian;

                    /*  Se comenta ya que se actualiza la forma de adjudicar el numero de factura.  19 nov. de 2019
                     * var preFijo = miDaoConsecutivo.Consecutivo("FacturaPrefijo");
                     if (preFijo.Equals("0"))
                     {
                         factura.Numero = miDaoConsecutivo.Consecutivo("Factura");
                     }
                     else
                     {
                         factura.Numero = miDaoConsecutivo.Consecutivo("FacturaPrefijo") + miDaoConsecutivo.Consecutivo("Factura");
                     }

                     factura.IdResolucionDian = Convert.ToInt32(miDaoConsecutivo.Consecutivo("IdRegistroDian"));*/
                }
                /*var preFijo = miDaoConsecutivo.Consecutivo("FacturaPrefijo");
                if (preFijo.Equals("0"))
                {
                    factura.Numero = miDaoConsecutivo.Consecutivo("Factura");
                }
                else
                {
                    factura.Numero = miDaoConsecutivo.Consecutivo("FacturaPrefijo") + miDaoConsecutivo.Consecutivo("Factura");
                }*/

                //factura.IdResolucionDian = Convert.ToInt32(miDaoConsecutivo.Consecutivo("IdRegistroDian"));
                if (!anutigua)
                {
                    if (factura.EstadoFactura.Id == 1 || factura.EstadoFactura.Id == 2)
                    {
                        if (!edicion)
                        {
                            //    miDaoConsecutivo.ActualizarConsecutivo("Factura");
                            /* Se comenta ya que se actualiza la forma de adjudicar el numero de factura.  19 nov. de 2019
                             * miDaoConsecutivo.ActualizarNumeroFacturaDeVenta("IdRegistroDian", "FacturaPrefijo", "Factura");*/

                            miDaoCaja.ActualizarConsecutivoFactura(miCaja.Id, miCaja.NumeroFactura);
                        }
                        if (factura.Pendiente)
                        {
                            //    miDaoConsecutivo.ActualizarConsecutivo("Factura");
                            /*  Se comenta ya que se actualiza la forma de adjudicar el numero de factura.  19 nov. de 2019
                             * miDaoConsecutivo.ActualizarNumeroFacturaDeVenta("IdRegistroDian", "FacturaPrefijo", "Factura");*/

                            miDaoCaja.ActualizarConsecutivoFactura(miCaja.Id, miCaja.NumeroFactura);
                        }
                        //ActualizarConsecutivo(NumberIncrement(factura.Numero), true);
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

                // End edición 18/06/2019 mejoras en la numeracion de la facturacion.

                if (edicion)
                {
                    RetirarProductos(factura, miDaoProductoFactura, miDaoInventario);
                    CargarComando(Editar);
                }
                else
                {
                    CargarComando(Ingresar);
                }
                //miComando.Parameters.AddWithValue("numero", factura.Numero);
                if (edicion)
                {
                    miComando.Parameters.AddWithValue("id", factura.Id);
                    //miComando.Parameters.AddWithValue("numeroEdit", factura.NumeroEdit);
                    miComando.Parameters.AddWithValue("numero", factura.Numero);
                }
                else
                {
                    miComando.Parameters.AddWithValue("numero", factura.Numero);
                }
                miComando.Parameters.AddWithValue("cliente", factura.Proveedor.NitProveedor);
                miComando.Parameters.AddWithValue("usuario", factura.Usuario.Id);
                miComando.Parameters.AddWithValue("caja", factura.Caja.Id);
                if (edicion)
                {
                    miComando.Parameters.AddWithValue("estado", factura.EstadoFactura.Id);
                }
                else
                {
                    miComando.Parameters.AddWithValue("estado", factura.EstadoFactura.IdEdit);
                }
                miComando.Parameters.AddWithValue("fecha", factura.FechaIngreso);
                miComando.Parameters.AddWithValue("hora", factura.FechaIngreso.TimeOfDay);
                miComando.Parameters.AddWithValue("descuento", factura.Descuento);
                miComando.Parameters.AddWithValue("limite", factura.FechaLimite);
                miComando.Parameters.AddWithValue("aplicaDescto", factura.AplicaDescuento);
                miComando.Parameters.AddWithValue("estado", factura.Estado);
                if (edicion)
                {
                    if ((factura.EstadoFactura.IdEdit.Equals(3) || factura.EstadoFactura.IdEdit.Equals(4)) &&
                        (factura.EstadoFactura.Id.Equals(1) || factura.EstadoFactura.Id.Equals(2)))
                    {
                        miComando.Parameters.AddWithValue("serie", Convert.ToInt32(miDaoConsecutivo.Consecutivo("Serie")));
                        miComando.Parameters.AddWithValue("idResDian", factura.IdResolucionDian);
                    }
                    /*if (!(factura.EstadoFactura.Id.Equals(1) || factura.EstadoFactura.Id.Equals(2)))
                    {
                        miComando.Parameters.AddWithValue("serie", Convert.ToInt32(miDaoConsecutivo.Consecutivo("Serie")));
                    }*/
                }
                else
                {
                    miComando.Parameters.AddWithValue("serie", Convert.ToInt32(miDaoConsecutivo.Consecutivo("Serie")));
                    miComando.Parameters.AddWithValue("idResDian", factura.IdResolucionDian);
                }
                miConexion.MiConexion.Open();
                var id = 0;
                if (edicion)
                {
                    id = factura.Id;
                    miComando.ExecuteNonQuery();
                }
                else
                {
                    id = Convert.ToInt32(miComando.ExecuteScalar());
                }
                miConexion.MiConexion.Close();
                miComando.Dispose();
                if (edicion)
                {
                    if ((factura.EstadoFactura.IdEdit.Equals(3) || factura.EstadoFactura.IdEdit.Equals(4)) &&
                        (factura.EstadoFactura.Id.Equals(1) || factura.EstadoFactura.Id.Equals(2)))
                    {
                        miDaoConsecutivo.ActualizarConsecutivo("Serie");
                    }
                    /*if (!(factura.EstadoFactura.Id.Equals(1) || factura.EstadoFactura.Id.Equals(2)))
                    {
                        miDaoConsecutivo.ActualizarConsecutivo("Serie");
                    }*/
                }
                else
                {
                    miDaoConsecutivo.ActualizarConsecutivo("Serie");
                }
                if (factura.Remision_)
                {
                    miDaoRemision.RemisionFacturada(Convert.ToInt32(factura.NumeroEdit));
                }

                var productosDB = miDaoProductoFactura.ProductoFacturaVenta(factura.Id);
                double cant = 0;

                foreach (ProductoFacturaProveedor producto in factura.Productos)
                {
                    if (edicion)
                    {
                        producto.IdFactura = factura.Id;
                    }
                    else
                    {
                        producto.IdFactura = id;
                    }
                    if (!producto.Retorno)
                    {
                        producto.Costo = CostoDeProducto(producto.Producto.CodigoInternoProducto, producto.Producto.IdTipoInventario);
                    }
                    if (edicion)
                    {
                        if ((factura.EstadoFactura.Id == 1 && factura.EstadoFactura.IdEdit == 2) ||
                            (factura.EstadoFactura.Id == 2 && factura.EstadoFactura.IdEdit == 2))
                        {
                            var qRow = productosDB.AsEnumerable().Where(p => p.Field<int>("Id") == producto.Id);
                            if (qRow.Count() > 0)
                            {
                                var pRow = qRow.Single();
                                cant = producto.Inventario.Cantidad - Convert.ToDouble(pRow["Cantidad"]);
                                if (cant != 0)  // Se añadio cantidades al registro del producto.
                                {
                                    if (cant < 0)
                                    {
                                        cant = Convert.ToDouble(pRow["Cantidad"]) - producto.Inventario.Cantidad;
                                        miDaoInventario.ActualizarInventario(new Inventario
                                        {
                                            CodigoProducto = producto.Inventario.CodigoProducto,
                                            IdMedida = producto.Inventario.IdMedida,
                                            IdColor = producto.Inventario.IdColor,
                                            Cantidad = cant
                                        }, false);
                                    }
                                    else
                                    {
                                        miDaoInventario.ActualizarInventario(new Inventario
                                        {
                                            CodigoProducto = producto.Inventario.CodigoProducto,
                                            IdMedida = producto.Inventario.IdMedida,
                                            IdColor = producto.Inventario.IdColor,
                                            Cantidad = cant
                                        }, true);
                                    }

                                    /* miDaoInventario.ActualizarInventario(new Inventario
                                     {
                                         CodigoProducto = producto.Inventario.CodigoProducto,
                                         IdMedida = producto.Inventario.IdMedida,
                                         IdColor = producto.Inventario.IdColor,
                                         Cantidad = (producto.Inventario.Cantidad - Convert.ToDouble(pRow["Cantidad"]))
                                     }, true);*/
                                }
                            }
                        }

                        //if ((pfRow.Inventario.Cantidad - Convert.ToDouble(pRow["Cantidad"])) != 0)
                        //{

                        if (producto.Save)//indica que el registro es nuevo
                        {
                            miDaoProductoFactura.IngresarProductoFactura(producto);
                            if (factura.EstadoFactura.Id != 4)
                            {
                                if (!producto.Retorno)
                                {
                                    miDaoInventario.ActualizarInventario(producto.Inventario, true);
                                }
                            }
                        }
                        else
                        {
                            if (!producto.Retorno)
                            {
                                if ((factura.EstadoFactura.Id == 1 || factura.EstadoFactura.Id == 2) && factura.EstadoFactura.IdEdit > 2)
                                {
                                    //var cant = CantidadProducto(producto.Id);
                                    miDaoInventario.ActualizarInventario(new Inventario
                                    {
                                        CodigoProducto = producto.Inventario.CodigoProducto,
                                        IdMedida = producto.Inventario.IdMedida,
                                        IdColor = producto.Inventario.IdColor,
                                        Cantidad = producto.Inventario.Cantidad
                                    }, true);
                                }

                                miDaoProductoFactura.EditarProductoFactura(producto);

                                /*var cant = CantidadProducto(producto.Id);
                                miDaoInventario.ActualizarInventario(new Inventario
                                {
                                    CodigoProducto = producto.Inventario.CodigoProducto,
                                    IdMedida = producto.Inventario.IdMedida,
                                    IdColor = producto.Inventario.IdColor,
                                    Cantidad = cant
                                }, false);

                                miDaoProductoFactura.EditarProductoFactura(producto);

                                miDaoInventario.ActualizarInventario(new Inventario
                                {
                                    CodigoProducto = producto.Inventario.CodigoProducto,
                                    IdMedida = producto.Inventario.IdMedida,
                                    IdColor = producto.Inventario.IdColor,
                                    Cantidad = producto.Inventario.Cantidad
                                }, true);*/
                            }
                        }
                    }
                    else
                    {
                        miDaoProductoFactura.IngresarProductoFactura(producto);
                        if (factura.EstadoFactura.Id != 4 && factura.EstadoFactura.Id != 3)
                        {
                            if (!factura.Remision_)
                            {
                                if (!producto.Retorno)
                                {
                                    miDaoInventario.ActualizarInventario(producto.Inventario, true);
                                }
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
                    if (factura.EstadoFactura.Id == 1/* && !edicion*/
                //)
                /*{
                    ActualizarConsecutivo(NumberIncrement(factura.Numero), true);
                }
            }*/


                // Edición 18/06/2019  mejoras en numeracion de facturacion
                /*if (!anutigua)
                {
                    if (factura.EstadoFactura.Id == 1 || factura.EstadoFactura.Id == 2)
                    {
                        if (!edicion)
                        {
                        //    miDaoConsecutivo.ActualizarConsecutivo("Factura");
                            miDaoConsecutivo.ActualizarNumeroFacturaDeVenta("IdRegistroDian", "FacturaPrefijo", "Factura");
                        }
                        if (factura.Pendiente)
                        {
                        //    miDaoConsecutivo.ActualizarConsecutivo("Factura");
                            miDaoConsecutivo.ActualizarNumeroFacturaDeVenta("IdRegistroDian", "FacturaPrefijo", "Factura");
                        }
                        //ActualizarConsecutivo(NumberIncrement(factura.Numero), true);
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
                }*/



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
                                    if (edicion)
                                    {
                                        forma.IdFactura = factura.Id;
                                    }
                                    else
                                    {
                                        forma.IdFactura = id;
                                    }
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
                    if (factura.Retencion.Id.Equals(0))
                    {
                        miDaoRetencion.IngresarFacturaVentaRetencion(factura.Retencion);
                    }
                    else
                    {
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

                // Kardex.
                if (!anutigua && !edicion)
                {
                    if (factura.EstadoFactura.Id.Equals(1) || factura.EstadoFactura.Id.Equals(2))
                    {
                        foreach (ProductoFacturaProveedor producto in factura.Productos)
                        {
                            if (!producto.Retorno)
                            {
                                Kardex.Codigo = producto.Producto.CodigoInternoProducto;
                                Kardex.IdUsuario = factura.Usuario.Id;
                                Kardex.IdConcepto = 10;
                                Kardex.NoDocumento = factura.Numero;
                                Kardex.Fecha = DateTime.Now;
                                Kardex.Cantidad = producto.Inventario.Cantidad;
                                double valorMenosDescto = Math.Round((producto.Producto.ValorVentaProducto -
                                    (producto.Producto.ValorVentaProducto * producto.Producto.Descuento / 100)), 1);
                                double iva = Math.Round(
                                    (valorMenosDescto * producto.Producto.ValorIva / 100), 1);
                                Kardex.Valor = Convert.ToInt32(valorMenosDescto + iva);
                                Kardex.Total = Kardex.Cantidad * Kardex.Valor;
                                miDaoKardex.Insertar(Kardex);
                            }
                        }
                    }
                }

                if (factura.IcoBolsaPlastica.Cantidad > 0)
                {
                    factura.IcoBolsaPlastica.IdFactura = id;
                    miDaoIcoBolsa.Insertar(factura.IcoBolsaPlastica);
                }

                // Acumulado de Ingresos.
                //miDaoIngreso.IngresarAcumulado(factura.Caja.Id, factura.FechaIngreso, ValorFactura(factura.Numero));

                //  Retorno de articulo
                /*var tRetornos = miDaoProductoFactura.RetornosTemporal();
                foreach (DataRow rRow in tRetornos.Rows)
                {
                    var producto = new ProductoFacturaProveedor();
                    producto.NumeroFactura = factura.Numero;
                    producto.Producto.CodigoInternoProducto = rRow["codigo"].ToString();
                    producto.Inventario.IdMedida = Convert.ToInt32(rRow["idmedida"]);
                    producto.Inventario.IdColor = Convert.ToInt32(rRow["idcolor"]);
                    producto.Cantidad = Convert.ToDouble(rRow["cantidad"]);
                    producto.Producto.ValorVentaProducto = Convert.ToDouble(rRow["valor"]);
                    producto.Producto.ValorIva = Convert.ToDouble(rRow["iva"]);
                    miDaoProductoFactura.IngresarRetorno(producto);
                }*/
                //miDaoProductoFactura.EliminarRetornoTemporal();
                return id;
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
                    factura.Id = miReader.GetInt32(11);
                }
                return factura;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al cargar la Factura de Venta.\n" + ex.Message);
            }
            finally { miConexion.MiConexion.Close(); }
        }

        public FacturaVenta FacturaDeVenta(int id)
        {
            try
            {
                CargarComando("facturas_venta");
                miComando.Parameters.AddWithValue("", id);
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
                    factura.FechaFactura = miReader.GetDateTime(6);
                    factura.Descuento = miReader.GetDouble(7);
                    factura.FechaLimite = miReader.GetDateTime(8);
                    factura.AplicaDescuento = miReader.GetBoolean(9);
                    factura.Estado = miReader.GetBoolean(10);
                    factura.Id = miReader.GetInt32(12);
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
                /*miComando.Parameters.AddWithValue("numero", factura.Numero);
                miComando.Parameters.AddWithValue("cliente", factura.Proveedor.NitProveedor);*/
                // NUEVO CODIGO 13-04-2016
                miComando.Parameters.AddWithValue("", factura.Id);
                miComando.Parameters.AddWithValue("", factura.Proveedor.NitProveedor);
                //
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
                //var productos = miDaoProducto.ProductoFacturaVenta(factura.Numero);
                var productos = miDaoProducto.ProductoFacturaVenta(factura.Id);
                foreach (DataRow producto in productos.Rows)
                {
                    var inventario = new Inventario
                    {
                        CodigoProducto = producto["Codigo"].ToString(),
                        IdMedida = Convert.ToInt32(producto["IdMedida"]),
                        IdColor = Convert.ToInt32(producto["IdColor"]),
                        Cantidad = Convert.ToDouble(producto["Cantidad"])
                    };
                    //miDaoInventario.ActualizarInventario(inventario, false);
                    miDaoProducto.ElimnarProductoFacturaVenta(Convert.ToInt32(producto["Id"]));
                }
                foreach (ProductoFacturaProveedor producto in factura.Productos)
                {
                    producto.IdFactura = factura.Id;
                    miDaoProducto.IngresarProductoFactura(producto);
                    //miDaoInventario.ActualizarInventario(producto.Inventario, true);
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
        public void RetirarProductos(FacturaVenta factura, DaoProductoFacturaVenta miDao, DaoInventario daoInventario)
        {
            try
            {
                //var lstID = new List<int>();
                //var productosDB = miDao.ProductoFacturaVenta(factura.NumeroEdit);
                var productosDB = miDao.ProductoFacturaVenta(factura.Id);

                //  Coteja los eliminados
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
                        if (factura.EstadoFactura.Id < 3)
                        {
                            //miDao.ElimnarProductoFacturaVenta(Convert.ToInt32(pRow["Id"]));
                            daoInventario.ActualizarInventario(new Inventario
                            {
                                CodigoProducto = pRow["Codigo"].ToString(),
                                IdMedida = Convert.ToInt32(pRow["IdMedida"]),
                                IdColor = Convert.ToInt32(pRow["IdColor"]),
                                Cantidad = Convert.ToDouble(pRow["Cantidad"])
                            }, false);

                            this.Kardex = new DTO.Clases.Kardex();
                            Kardex.Codigo = pRow["Codigo"].ToString();
                            Kardex.IdUsuario = factura.Usuario.Id;
                            Kardex.IdConcepto = 18;
                            Kardex.NoDocumento = factura.Numero;
                            Kardex.Fecha = DateTime.Now;
                            Kardex.Cantidad = Convert.ToDouble(pRow["Cantidad"]);
                            double valorMenosDescto = Math.Round((Convert.ToDouble(pRow["Valor"]) -
                                (Convert.ToDouble(pRow["Valor"]) * Convert.ToDouble(pRow["Descuento"]) / 100)), 1);
                            double iva = Math.Round(
                                (valorMenosDescto * Convert.ToDouble(pRow["Iva"]) / 100), 1);
                            Kardex.Valor = Convert.ToInt32(valorMenosDescto + iva);
                            Kardex.Total = Kardex.Cantidad * Kardex.Valor;
                            miDaoKardex.Insertar(Kardex);
                        }
                    }
                }
                //productosDB = miDao.ProductoFacturaVenta(factura.NumeroEdit);
                productosDB = miDao.ProductoFacturaVenta(factura.Id);

                if (factura.EstadoFactura.Id < 3)
                {
                    //  Coteja los editados
                    foreach (var pfRow in factura.Productos)
                    {
                        foreach (DataRow pRow in productosDB.Rows)
                        {
                            if (pfRow.Id == Convert.ToInt32(pRow["Id"]))
                            {
                                var c = Convert.ToDouble(pRow["Cantidad"]);
                                if ((pfRow.Inventario.Cantidad - Convert.ToDouble(pRow["Cantidad"])) != 0)
                                {
                                    this.Kardex = new DTO.Clases.Kardex();
                                    Kardex.Codigo = pRow["Codigo"].ToString();
                                    Kardex.IdUsuario = factura.Usuario.Id;
                                    //Kardex.IdConcepto = 18;
                                    Kardex.NoDocumento = factura.Numero;
                                    Kardex.Fecha = DateTime.Now;
                                    Kardex.Cantidad = pfRow.Cantidad - Convert.ToDouble(pRow["Cantidad"]);
                                    if (Kardex.Cantidad < 0)
                                    {
                                        Kardex.Cantidad *= -1;
                                        Kardex.IdConcepto = 18;
                                    }
                                    else
                                    {
                                        Kardex.IdConcepto = 19;
                                    }
                                    //Kardex.Cantidad = Convert.ToDouble(pRow["Cantidad"]);

                                    double valorMenosDescto = Math.Round((Convert.ToDouble(pRow["Valor"]) -
                                        (Convert.ToDouble(pRow["Valor"]) * Convert.ToDouble(pRow["Descuento"]) / 100)), 1);
                                    double iva = Math.Round(
                                        (valorMenosDescto * Convert.ToDouble(pRow["Iva"]) / 100), 1);
                                    Kardex.Valor = Convert.ToInt32(valorMenosDescto + iva);
                                    Kardex.Total = Kardex.Cantidad * Kardex.Valor;
                                    miDaoKardex.Insertar(Kardex);
                                }
                            }
                        }
                    }

                    //  Coteja los añadidos
                    foreach (var pfRow in factura.Productos)
                    {
                        var existe = false;
                        foreach (DataRow pRow in productosDB.Rows)
                        {
                            if (pfRow.Id == Convert.ToInt32(pRow["Id"]))
                            {
                                existe = true;
                            }
                            else
                            {
                                existe = false;
                                break;
                            }
                        }
                        if (!existe) // revisar
                        {
                            // adicion de producto a venta
                            this.Kardex = new DTO.Clases.Kardex();
                            Kardex.Codigo = pfRow.Producto.CodigoInternoProducto;
                            Kardex.IdUsuario = factura.Usuario.Id;
                            Kardex.IdConcepto = 19;
                            Kardex.NoDocumento = factura.Numero;
                            Kardex.Fecha = DateTime.Now;
                            Kardex.Cantidad = pfRow.Inventario.Cantidad;
                            double valorMenosDescto = Math.Round((pfRow.Producto.ValorVentaProducto -
                                (pfRow.Producto.ValorVentaProducto * pfRow.Producto.Descuento / 100)), 1);
                            double iva = Math.Round(
                                (valorMenosDescto * pfRow.Producto.ValorIva / 100), 1);
                            Kardex.Valor = Convert.ToInt32(valorMenosDescto + iva);
                            Kardex.Total = Kardex.Cantidad * Kardex.Valor;
                            miDaoKardex.Insertar(Kardex);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Retira los productos que fueron excluidos de la Factura de Venta.
        /// </summary>
        /// <param name="factura">Factura de Venta a analizar.</param>
        public void RetirarProductos_(FacturaVenta factura, DaoProductoFacturaVenta miDao, DaoInventario daoInventario)
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
                        daoInventario.ActualizarInventario(new Inventario
                        {
                            CodigoProducto = pRow["Codigo"].ToString(),
                            IdMedida = Convert.ToInt32(pRow["IdMedida"]),
                            IdColor = Convert.ToInt32(pRow["IdColor"]),
                            Cantidad = Convert.ToDouble(pRow["Cantidad"])
                        }, false);

                        this.Kardex = new DTO.Clases.Kardex();
                        Kardex.Codigo = pRow["Codigo"].ToString();
                        Kardex.IdUsuario = factura.Usuario.Id;
                        Kardex.IdConcepto = 18;
                        Kardex.NoDocumento = factura.Numero;
                        Kardex.Fecha = DateTime.Now;
                        Kardex.Cantidad = Convert.ToDouble(pRow["Cantidad"]);
                        double valorMenosDescto = Math.Round((Convert.ToDouble(pRow["Valor"]) -
                            (Convert.ToDouble(pRow["Valor"]) * Convert.ToDouble(pRow["Descuento"]) / 100)), 1);
                        double iva = Math.Round(
                            (valorMenosDescto * Convert.ToDouble(pRow["Iva"]) / 100), 1);
                        Kardex.Valor = Convert.ToInt32(valorMenosDescto + iva);
                        Kardex.Total = Kardex.Cantidad * Kardex.Valor;
                        miDaoKardex.Insertar(Kardex);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public double CantidadProducto(int id)
        {
            try
            {
                CargarComando("cantidad_producto_venta");
                miComando.Parameters.AddWithValue("", id);
                miConexion.MiConexion.Open();
                var cant = Convert.ToDouble(miComando.ExecuteScalar());
                miConexion.MiConexion.Close();
                miComando.Dispose();
                return cant;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al consultar la cantidad.\n" + ex.Message);
            }
            finally { miConexion.MiConexion.Close(); }
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

        public DataSet PrintFacturaVenta(int id)
        {
            var dataSet = new DataSet();
            try
            {
                CargarAdapter(PrintFacturaVenta_);
                miAdapter.SelectCommand.Parameters.AddWithValue("id", id);
                miAdapter.Fill(dataSet, "FacturaVenta");
                return dataSet;
            }
            catch (Exception ex)
            {
                throw new Exception(ErrorConsulta + ex.Message);
            }
        }

        public DataTable ConsultaTodas(int rowBase, int rowMax)
        {
            try
            {
                var tabla = new DataTable();
                CargarAdapter("consulta_factura_venta");
                miAdapter.Fill(rowBase, rowMax, tabla);
                return tabla;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al consultar las facturas de venta.\n" + ex.Message);
            }
        }

        public long GetRowsConsultaTodas()
        {
            try
            {
                CargarComando("count_consulta_factura_venta");
                miConexion.MiConexion.Open();
                var rows = Convert.ToInt64(miComando.ExecuteScalar());
                miConexion.MiConexion.Close();
                miComando.Dispose();
                return rows;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al consultar el conteo de facturas.\n" + ex.Message);
            }
            finally { miConexion.MiConexion.Close(); }
        }

        public DataTable ConsultaTodas(DateTime fecha, int rowBase, int rowMax)
        {
            try
            {
                var tabla = new DataTable();
                CargarAdapter("consulta_factura_venta");
                miAdapter.SelectCommand.Parameters.AddWithValue("fecha", fecha);
                miAdapter.Fill(rowBase, rowMax, tabla);
                return tabla;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al consultar las facturas de venta.\n" + ex.Message);
            }
        }

        public long GetRowsConsultaTodas(DateTime fecha)
        {
            try
            {
                CargarComando("count_consulta_factura_venta");
                miComando.Parameters.AddWithValue("fecha", fecha);
                miConexion.MiConexion.Open();
                var rows = Convert.ToInt64(miComando.ExecuteScalar());
                miConexion.MiConexion.Close();
                miComando.Dispose();
                return rows;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al consultar el conteo de facturas.\n" + ex.Message);
            }
            finally { miConexion.MiConexion.Close(); }
        }

        public DataTable ConsultaTodas(DateTime fecha, DateTime fecha2, int rowBase, int rowMax)
        {
            try
            {
                var tabla = new DataTable();
                CargarAdapter("consulta_factura_venta");
                miAdapter.SelectCommand.Parameters.AddWithValue("fecha", fecha);
                miAdapter.SelectCommand.Parameters.AddWithValue("fecha2", fecha2);
                miAdapter.Fill(rowBase, rowMax, tabla);
                return tabla;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al consultar las facturas de venta.\n" + ex.Message);
            }
        }

        public long GetRowsConsultaTodas(DateTime fecha, DateTime fecha2)
        {
            try
            {
                CargarComando("count_consulta_factura_venta");
                miComando.Parameters.AddWithValue("fecha", fecha);
                miComando.Parameters.AddWithValue("fecha2", fecha2);
                miConexion.MiConexion.Open();
                var rows = Convert.ToInt64(miComando.ExecuteScalar());
                miConexion.MiConexion.Close();
                miComando.Dispose();
                return rows;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al consultar el conteo de facturas.\n" + ex.Message);
            }
            finally { miConexion.MiConexion.Close(); }
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
            (int estado, string cliente, DateTime fecha, int rowBase, int rowMax)
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
        /// Obtiene el total de registros de la consulta de Factura de Venta por Cliente 
        /// en un periodo de fechas de ingreso.
        /// </summary>
        /// <param name="cliente">Cliente a consultar factura de venta.</param>
        /// <param name="fecha1">Primer rango de fecha.</param>
        /// <param name="fecha2">Segundo rango de fecha.</param>
        /// <returns></returns>
        public long GetRowsConsultaPorEstadoClienteIngreso(int estado, string cliente, DateTime fecha)
        {
            try
            {
                CargarComando("count_consulta_factura_estado_cliente_fingreso");
                miComando.Parameters.AddWithValue("cliente", estado);
                miComando.Parameters.AddWithValue("cliente", cliente);
                miComando.Parameters.AddWithValue("fecha1", fecha);
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

        public int ValorFactura(string numero)
        {
            return Convert.ToInt32(
                ProductoFacturaVenta(numero, true).AsEnumerable().Sum(s => s.Field<double>("Valor")));
        }

        // EDICION NUEVO CODIGO 30-08-2016

        /// <summary>
        /// Obtiene el saldo pendiente de un cliente por todas sus factura.
        /// </summary>
        /// <param name="idEstado">Estdo de la factura (Crédito).</param>
        /// <param name="nitCliente">Nit del Cliente a consultar.</param>
        /// <returns></returns>
        public int SaldoPorCliente_old(int idEstado, string nitCliente)
        {
            var daoDevolucion = new DaoDevolucion();
            var miDaoRetencion = new DaoRetencion();
            int subTotal = 0;
            int totalFact = 0;
            int retencion = 0;
            int pagosFact = 0;
            int saldoDev = 0;
            int saldo = 0;
            int saldoTotal = 0;
            var factura = ConsultaPorEstadoYcliente(idEstado, nitCliente);
            foreach (DataRow fRow in factura.Rows)
            {
                retencion = 0;
                //var producto = ProductoFacturaVenta(fRow["numero"].ToString(), Convert.ToBoolean(fRow["descto"]));
                var producto = ProductoFacturaVenta(Convert.ToInt32(fRow["id"]), Convert.ToBoolean(fRow["descto"]));
                subTotal = Convert.ToInt32(producto.AsEnumerable().Sum(s => (s.Field<double>("ValorUnitario") * s.Field<double>("Cantidad"))));
                totalFact = Convert.ToInt32(producto.AsEnumerable().Sum(t => t.Field<double>("Valor")));
                var tRetenciones = miDaoRetencion.RetencionesAVenta(fRow["numero"].ToString());
                foreach (DataRow tRow in tRetenciones.Rows)
                {
                    retencion += Convert.ToInt32(subTotal * Convert.ToDouble(tRow["tarifa"]) / 100);
                }
                totalFact -= retencion;

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

        public int SaldoPorCliente(int idEstado, string nitCliente)
        {
            try
            {
                CargarComando("saldo_cliente");
                miComando.Parameters.AddWithValue("", idEstado);
                miComando.Parameters.AddWithValue("", nitCliente);
                miConexion.MiConexion.Open();
                int saldo = Convert.ToInt32(miComando.ExecuteScalar());
                miConexion.MiConexion.Close();
                miComando.Dispose();
                return saldo;
            }
            catch (InvalidCastException) // EDICION 23-01-2017
            {
                return 0;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al cargar el saldo restante.\n" + ex.Message);
            }
            finally { miConexion.MiConexion.Close(); }
        }

        // FIN EDICION 30-08-2016

       /* public List<FacturaVenta> CarteraCliente(int idEstado)
        {
            try
            {
                var cartera = new List<FacturaVenta>();
                CargarComando("cartera_cliente");
                miComando.Parameters.AddWithValue("", idEstado);
                miConexion.MiConexion.Open();
                NpgsqlDataReader reader = miComando.ExecuteReader();
                while (reader.Read())
                {
                    var factura = new FacturaVenta();
                    factura.Proveedor.NitProveedor = reader.GetString(0);
                    factura.Proveedor.NombreProveedor = reader.GetString(1);
                    factura.Id = reader.GetInt32(2);
                    factura.Numero = reader.GetString(3);
                    factura.FechaFactura = reader.GetDateTime(4);
                    factura.FechaLimite = reader.GetDateTime(5);
                    factura.EstadoFactura.Id = reader.GetInt32(6);
                    factura.Valor = Convert.ToInt32(reader.GetDouble(7));
                    factura.Pagos = Convert.ToInt32(reader.GetInt64(8));
                    factura.Saldo = Convert.ToInt32(reader.GetDouble(9));
                    cartera.Add(factura);
                }
                miConexion.MiConexion.Close();
                miComando.Dispose();
                return cartera;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al consultar la cartera de clientes.\n" + ex.Message);
            }
            finally { miConexion.MiConexion.Close(); }
        }*/

        public List<FacturaVenta> CarteraCliente(int idEstado, string nitCliente)
        {
            try
            {
                bool tipoAprox = Convert.ToBoolean(AppConfiguracion.ValorSeccion("tipo_aprox_precio"));
                var miDaoImpBolsa = new DaoImpuestoBolsa();
                var cartera = new List<FacturaVenta>();
                CargarComando("cartera_de_cliente");
                miComando.Parameters.AddWithValue("", idEstado);
                miComando.Parameters.AddWithValue("", nitCliente);
                miConexion.MiConexion.Open();
                NpgsqlDataReader reader = miComando.ExecuteReader();
                while (reader.Read())
                {
                    var factura = new FacturaVenta();
                    factura.Proveedor.NitProveedor = reader.GetString(0);
                    factura.Proveedor.NombreProveedor = reader.GetString(1);
                    factura.Id = reader.GetInt32(2);
                    factura.Numero = reader.GetString(3);
                    factura.FechaFactura = reader.GetDateTime(4);
                    factura.FechaLimite = reader.GetDateTime(5);
                    factura.EstadoFactura.Id = reader.GetInt32(6);
                    var impBolsa = miDaoImpBolsa.ImpuestoBolsaDeVenta(factura.Id);
                    factura.Valor = UseObject.Aproximar(Convert.ToInt32(reader.GetDouble(7)), tipoAprox);
                    factura.Valor += Convert.ToInt32(impBolsa.Cantidad * impBolsa.Valor);
                    factura.Pagos = Convert.ToInt32(reader.GetInt64(8));
                    factura.Saldo = factura.Valor - factura.Pagos;

                    if (factura.Saldo > 0)
                    {
                        cartera.Add(factura);
                    }
                }
                miConexion.MiConexion.Close();
                miComando.Dispose();
                return cartera;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al consultar la cartera de clientes.\n" + ex.Message);
            }
            finally { miConexion.MiConexion.Close(); }
        }

        public List<FacturaVenta> CarteraCliente_(int idEstado, string nitCliente)
        {
            try
            {
                var miDaoImpuesto = new DaoImpuestoBolsa();
                var miDaoRetencion = new DaoRetencion();
                var miDaoDevolucion = new DaoDevolucion();

                double subTotal = 0;
                double valorFactura = 0;
                int retencion = 0;
                ImpuestoBolsa icoBolsa;
                int pagosFactura = 0;

               // bool tipoAprox = Convert.ToBoolean(AppConfiguracion.ValorSeccion("tipo_aprox_precio"));
                var cartera = new List<FacturaVenta>();


                //CargarComando("cartera_de_cliente");
                //miComando.Parameters.AddWithValue("", idEstado);
                //miComando.Parameters.AddWithValue("", nitCliente);

                CargarAdapter("cartera_de_cliente");
                miAdapter.SelectCommand.Parameters.AddWithValue("", idEstado);
                miAdapter.SelectCommand.Parameters.AddWithValue("", nitCliente);
                var tabla = new DataTable();
                miAdapter.Fill(tabla);

                foreach (DataRow row in tabla.Rows)
                {
                    if (row["factura"].ToString().Equals("59511"))
                    {
                        var j = 0;
                    }
                    DataTable tProductos = ProductoFacturaVenta(Convert.ToInt32(row["id"]), true);
                    subTotal = tProductos.AsEnumerable().Sum(t => (t.Field<double>("ValorUnitario") * t.Field<double>("Cantidad")));
                    valorFactura = tProductos.AsEnumerable().Sum(t => t.Field<double>("Valor"));
                    icoBolsa = miDaoImpuesto.ImpuestoBolsaDeVenta(Convert.ToInt32(row["id"]));
                    valorFactura += (icoBolsa.Cantidad * icoBolsa.Valor);
                    retencion = 0;
                    var tReteciones = miDaoRetencion.RetencionesAVenta(row["factura"].ToString());
                    foreach (DataRow rRow in tReteciones.Rows)
                    {
                        retencion += Convert.ToInt32(subTotal * Convert.ToDouble(rRow["tarifa"]) / 100);
                    }
                    valorFactura -= retencion;
                    valorFactura -= Convert.ToInt32(row["saldo_devolucion"]);
                    pagosFactura = Convert.ToInt32(row["abonos"]);
                    //var saldoDevFactura = miDaoDevolucion.SaldoDevolucionVenta(row["factura"].ToString());
                    if ((valorFactura - pagosFactura) > 0)
                    {
                        var factura = new FacturaVenta();
                        factura.Proveedor.NitProveedor = row["cedula"].ToString();
                        factura.Proveedor.NombreProveedor = row["nombre"].ToString();
                        factura.Id = Convert.ToInt32(row["id"]);
                        factura.Numero = row["factura"].ToString();
                        factura.FechaFactura = Convert.ToDateTime(row["fecha"]);
                        factura.FechaLimite = Convert.ToDateTime(row["limite"]);
                        factura.EstadoFactura.Id = Convert.ToInt32(row["idestado"]);
                        factura.Valor = Convert.ToInt32(valorFactura);
                        factura.Pagos = pagosFactura;
                        factura.Saldo = factura.Valor - factura.Pagos;
                        if (factura.Saldo > 0)
                        {
                            cartera.Add(factura);
                        }
                    }
                }


                //miConexion.MiConexion.Open();
                //NpgsqlDataReader reader = miComando.ExecuteReader();
                /*while (reader.Read())
                {
                    var factura = new FacturaVenta();
                    factura.Proveedor.NitProveedor = reader.GetString(0);
                    factura.Proveedor.NombreProveedor = reader.GetString(1);
                    factura.Id = reader.GetInt32(2);
                    factura.Numero = reader.GetString(3);
                    factura.FechaFactura = reader.GetDateTime(4);
                    factura.FechaLimite = reader.GetDateTime(5);
                    factura.EstadoFactura.Id = reader.GetInt32(6);
                    var impBolsa = miDaoImpBolsa.ImpuestoBolsaDeVenta(factura.Id);
                    factura.Valor = UseObject.Aproximar(Convert.ToInt32(reader.GetDouble(7)), tipoAprox);
                    factura.Valor += Convert.ToInt32(impBolsa.Cantidad * impBolsa.Valor);
                    factura.Pagos = Convert.ToInt32(reader.GetInt64(8));
                    factura.Saldo = factura.Valor - factura.Pagos;

                    if (factura.Saldo > 0)
                    {
                        cartera.Add(factura);
                    }
                }*/
                //miConexion.MiConexion.Close();
                //miComando.Dispose();
                return cartera;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al consultar la cartera de clientes.\n" + ex.Message);
            }
            finally { }//miConexion.MiConexion.Close(); }
        }

        public DataTable CarteraDeClientes(int idEstado)
        {
            try
            {
                var tabla = new DataTable();
                CargarAdapter("cartera_cliente");
                miAdapter.SelectCommand.Parameters.AddWithValue("", idEstado);
                miAdapter.Fill(tabla);
                //return CarteraDeClientes(tabla);
                return tabla;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al consultar la cartera de clientes.\n" + ex.Message);
            }
        }

        public DataTable CarteraDeClientes(int idEstado, int rowIndex, int rowMax)
        {
            try
            {
                var tabla = new DataTable();
                CargarAdapter("cartera_cliente");
                miAdapter.SelectCommand.CommandTimeout = 100;
                miAdapter.SelectCommand.Parameters.AddWithValue("", idEstado);
                miAdapter.Fill(rowIndex, rowMax, tabla);
                return tabla;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al consultar la cartera de clientes.\n" + ex.Message);
            }
        }

        public int CountCarteraDeClientes(int idEstado)
        {
            try
            {
                CargarComando("count_cartera_cliente");
                miComando.Parameters.AddWithValue("", idEstado);
                miConexion.MiConexion.Open();
                miComando.CommandTimeout = 100;
                var rows = Convert.ToInt32(miComando.ExecuteScalar());
                miConexion.MiConexion.Close();
                miComando.Dispose();
                return rows;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al consultar el conteo.\n" + ex.Message);
            }
            finally { miConexion.MiConexion.Close(); }
        }




        public DataTable CarteraDeClientes(int idEstado, string nitCliente)
        {
            try
            {
                var tabla = new DataTable();
                CargarAdapter("cartera_cliente");
                miAdapter.SelectCommand.Parameters.AddWithValue("" , idEstado);
                miAdapter.SelectCommand.Parameters.AddWithValue("", nitCliente);
                miAdapter.Fill(tabla);
                return tabla;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al consultar la cartera de clientes.\n" + ex.Message);
            }
        }

        public DataTable ResumenCarteraClientes()
        {
            try
            {
                var tabla = new DataTable();
                CargarAdapter("facturas_venta_total_pagos_resumen");
                int c = this.miConexion.MiConexion.ConnectionTimeout;
                miAdapter.Fill(tabla);
                return tabla;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al consultar la cartera de clientes.\n" + ex.Message);
            }
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
        /*
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
        */
        /*public DataSet TotalFacturasContado(int idCaja, DateTime fecha)
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
        */


        public DataSet TotalFacturasCredito(int idEstado, int idCaja, DateTime fecha, bool caja)
        {
            var miDaoProducto = new DaoProductoFacturaVenta();
            var miDaoImpuestoBolsa = new DaoImpuestoBolsa();

            var dataSet = new DataSet();
            var tabla = new DataTable();
            tabla.TableName = "FacturaCredito";
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
                factura = FacturasDeVenta(idEstado, fecha);
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

                    //var tProducto = ProductoFacturaVenta(fRow["numero"].ToString(), Convert.ToBoolean(fRow["descto"]));
                    var tProducto = ProductoFacturaVenta(Convert.ToInt32(fRow["id"]), Convert.ToBoolean(fRow["descto"]));
                    totalFact = totalFact + Convert.ToDouble(tProducto.AsEnumerable().Sum(t => t.Field<double>("Valor")));

                    var impBolsa = miDaoImpuestoBolsa.ImpuestoBolsaDeVenta(Convert.ToInt32(fRow["id"]));
                    totalFact += (impBolsa.Valor * impBolsa.Cantidad);

                    row["NoFacturaC"] = fRow["numero"];
                    row["NitC"] = fRow["nitcliente"];
                    row["ClienteC"] = fRow["nombrescliente"];
                    row["TotalC"] = Convert.ToInt32(totalFact);
                    tabla.Rows.Add(row);
                }
                IEnumerable<DataRow> query = from data in tabla.AsEnumerable()
                                             orderby data.Field<string>("ClienteC") ascending
                                             select data;

                DataTable tabla_ = new DataTable();
                if (query.ToArray().Length != 0)
                {
                    tabla_ = query.CopyToDataTable<DataRow>();
                }
                tabla_.TableName = "FacturaCredito";
                tabla.Rows.Clear();
                tabla = null;
                query = null;
                dataSet.Tables.Add(tabla_);
                factura.Clear();
                factura = null;
                return dataSet;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public DataSet TotalFacturasCredito(int idEstado, int idCaja, DateTime fecha, DateTime fecha2, bool caja)
        {
            var miDaoProducto = new DaoProductoFacturaVenta();
            var dataSet = new DataSet();
            var tabla = new DataTable();
            tabla.TableName = "FacturaCredito";
            tabla.Columns.Add(new DataColumn("NoFacturaC", typeof(string)));
            tabla.Columns.Add(new DataColumn("NitC", typeof(string)));
            tabla.Columns.Add(new DataColumn("ClienteC", typeof(string)));
            tabla.Columns.Add(new DataColumn("TotalC", typeof(int)));

            var factura = new DataTable();
            if (caja)
            {
                factura = FacturasDeVenta(idEstado, idCaja, fecha, fecha2);
            }
            else
            {
                ///factura = NumeroFacturasCredito(fecha); Organizar.
              //  factura = FacturasDeVenta(idEstado, fecha, fecha2);
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

                    //var tProducto = ProductoFacturaVenta(fRow["numero"].ToString(), Convert.ToBoolean(fRow["descto"]));
                    var tProducto = ProductoFacturaVenta(Convert.ToInt32(fRow["id"]), Convert.ToBoolean(fRow["descto"]));
                    totalFact = totalFact + Convert.ToDouble(tProducto.AsEnumerable().Sum(t => t.Field<double>("Valor")));

                    row["NoFacturaC"] = fRow["numero"];
                    row["NitC"] = fRow["nitcliente"];
                    row["ClienteC"] = fRow["nombrescliente"];
                    row["TotalC"] = Convert.ToInt32(totalFact);
                    tabla.Rows.Add(row);
                }
                IEnumerable<DataRow> query = from data in tabla.AsEnumerable()
                                             orderby data.Field<string>("ClienteC") ascending
                                             select data;

                DataTable tabla_ = new DataTable();
                if (query.ToArray().Length != 0)
                {
                    tabla_ = query.CopyToDataTable<DataRow>();
                }
                tabla_.TableName = "FacturaCredito";
                tabla.Rows.Clear();
                tabla = null;
                query = null;
                dataSet.Tables.Add(tabla_);
                factura.Clear();
                factura = null;
                return dataSet;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }



        public DataTable TotalFacturasCredito(int idEstado, int idCaja, DateTime fecha, DateTime fecha2)
        {
            var miDaoProducto = new DaoProductoFacturaVenta();
            var tabla = new DataTable();
            tabla.TableName = "FacturaCredito";
            tabla.Columns.Add(new DataColumn("NoFacturaC", typeof(string)));
            tabla.Columns.Add(new DataColumn("NitC", typeof(string)));
            tabla.Columns.Add(new DataColumn("ClienteC", typeof(string)));
            tabla.Columns.Add(new DataColumn("TotalC", typeof(int)));
            var factura = FacturasDeVenta(idEstado, idCaja, fecha, fecha2);
            try
            {
                foreach (DataRow fRow in factura.Rows)
                {
                    double totalFact = 0;
                    var row = tabla.NewRow();
                    var tProducto = ProductoFacturaVenta(fRow["numero"].ToString(), Convert.ToBoolean(fRow["descto"]));
                    totalFact = totalFact + Convert.ToDouble(tProducto.AsEnumerable().Sum(t => t.Field<double>("Valor")));

                    row["NoFacturaC"] = fRow["numero"];
                    row["NitC"] = fRow["nitcliente"];
                    row["ClienteC"] = fRow["nombrescliente"];
                    row["TotalC"] = Convert.ToInt32(totalFact);
                    tabla.Rows.Add(row);
                }
                return tabla;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al consultar las facturas de crédito.\n" + ex.Message);
            }
        }

        public DataTable TotalFacturasCreditoHoras(int idEstado, int idCaja, DateTime fecha, DateTime fecha2)
        {
            var miDaoProducto = new DaoProductoFacturaVenta();
            var tabla = new DataTable();
            tabla.TableName = "FacturaCredito";
            tabla.Columns.Add(new DataColumn("NoFacturaC", typeof(string)));
            tabla.Columns.Add(new DataColumn("NitC", typeof(string)));
            tabla.Columns.Add(new DataColumn("ClienteC", typeof(string)));
            tabla.Columns.Add(new DataColumn("TotalC", typeof(int)));
            var factura = FacturasDeVentaHoras(idEstado, idCaja, fecha, fecha2);
            try
            {
                foreach (DataRow fRow in factura.Rows)
                {
                    double totalFact = 0;
                    var row = tabla.NewRow();
                    //Convert.ToInt32(fRow["id"])

                    //var tProducto = ProductoFacturaVenta(fRow["numero"].ToString(), Convert.ToBoolean(fRow["descto"]));
                    var tProducto = ProductoFacturaVenta(Convert.ToInt32(fRow["id"]), Convert.ToBoolean(fRow["descto"]));
                    totalFact = totalFact + Convert.ToDouble(tProducto.AsEnumerable().Sum(t => t.Field<double>("Valor")));

                    row["NoFacturaC"] = fRow["numero"];
                    row["NitC"] = fRow["nitcliente"];
                    row["ClienteC"] = fRow["nombrescliente"];
                    row["TotalC"] = Convert.ToInt32(totalFact);
                    tabla.Rows.Add(row);
                }
                return tabla;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al consultar las facturas de crédito.\n" + ex.Message);
            }
        }

        public double TotalVentas(int idEstado, int idCaja, DateTime fecha, DateTime fecha2)
        {
            try
            {
                CargarComando("total_ventas");
                miComando.Parameters.AddWithValue("", idEstado);
                miComando.Parameters.AddWithValue("", idCaja);
                miComando.Parameters.AddWithValue("", fecha);
                miComando.Parameters.AddWithValue("", fecha2);
                miConexion.MiConexion.Open();
                double total = Convert.ToDouble(miComando.ExecuteScalar());
                miConexion.MiConexion.Close();
                miComando.Dispose();
                return total;
            }
            catch (InvalidCastException)
            {
                return 0;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al consultar el total de ventas..\n" + ex.Message);
            }
            finally { miConexion.MiConexion.Close(); }
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

        public long CountRegistroVentas(int idCaja)
        {
            try
            {
                CargarComando("count_factura_venta");
                miComando.Parameters.AddWithValue("idcaja", idCaja);
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

        public DateTime MinFecha()
        {
            try
            {
                CargarComando("min_fecha_factura_venta");
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

        public DateTime MinFecha(int idCaja)
        {
            try
            {
                CargarComando("min_fecha_factura_venta");
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
                IEnumerable<DataRow> query_ = from data in tabla.AsEnumerable()
                                              orderby data.Field<string>("nombre") ascending
                                              select data;
                DataTable tabla_ = new DataTable();
                if (query_.ToArray().Length != 0)
                {
                    tabla_ = query_.CopyToDataTable<DataRow>();
                }
                tabla_.TableName = "Abono";
                dataSet.Tables.Add(tabla_);
                pagos.Rows.Clear();
                pagos.Clear();
                pagos = null;
                query = null;
                tabla.Rows.Clear();
                tabla = null;
                query_ = null;
                return dataSet;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public DataSet TotalAbonosFecha(DateTime fecha)
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
                var pagos = miDaoPagos.FormasDePagoDeFacturaVenta(fecha);
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
                IEnumerable<DataRow> query_ = from data in tabla.AsEnumerable()
                                              orderby data.Field<string>("nombre") ascending
                                              select data;
                DataTable tabla_ = new DataTable();
                if (query_.ToArray().Length != 0)
                {
                    tabla_ = query_.CopyToDataTable<DataRow>();
                }
                tabla_.TableName = "Abono";
                dataSet.Tables.Add(tabla_);
                pagos.Rows.Clear();
                pagos.Clear();
                pagos = null;
                query = null;
                tabla.Rows.Clear();
                tabla = null;
                query_ = null;
                return dataSet;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
/*
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
        */
        /*public DataTable ListaIvaContado(int idCaja, DateTime fecha, bool caja)
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
        */
       /* public DataSet IvaFacturaCredito(int idCaja, DateTime fecha, bool caja)
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
        */
        public DataTable IvaFacturado(int id, bool descto)
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
                //var tProducto = PrintProductoFacturaVenta(numero, descto);
                var tProducto = PrintProductoFacturaVenta(id, descto);
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
                        rowTemp["Iva"] = tempIva.PorcentajeIva.ToString();  // +"%";
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
            var tmp = tabla;
            try
            {
                var iva = miDaoIva.ListadoIva();
                var factura = NumeroFacturasActivaTodas(idCaja, fecha, caja);
                foreach (DataRow fRow in factura.Rows)
                {
                    var tProducto = ProductoFacturaVenta
                        (Convert.ToInt32(fRow["id"]), Convert.ToBoolean(fRow["aplica_descuento"]));
                    foreach (DataRow pRow in tProducto.Rows)
                    {
                        var tmpRow = tmp.NewRow();
                        tmpRow["Iva"] = pRow["Iva"];
                        tmpRow["SubTotal"] = pRow["Valor"];
                        tmp.Rows.Add(tmpRow);
                    }
                    
                }

                IEnumerable<DataRow> query1 = from d in tabla.AsEnumerable()
                                             select d;
                DataTable tTemp = new DataTable();
                if (query1.ToArray().Length != 0)
                {
                    tTemp = query1.CopyToDataTable<DataRow>();
                }
                tTemp.Rows.Clear();
                tTemp.TableName = "IvaGravado";
                foreach (Iva tempIva in iva)
                {
                    var subTotal = tmp.AsEnumerable().Where(i => i.Field<string>("Iva").
                        Equals(tempIva.PorcentajeIva.ToString() + "%")).Sum(s => s.Field<double>("SubTotal"));
                    if (subTotal != 0)
                    {
                        var rowTemp = tTemp.NewRow();
                        rowTemp["Iva"] = tempIva.PorcentajeIva.ToString() + "%";
                        rowTemp["SubTotal"] = subTotal;
                        rowTemp["Base"] = Convert.ToInt32(subTotal / (1 + (tempIva.PorcentajeIva / 100)));
                        //rowTemp["VIva"] = Convert.ToInt32(Convert.ToInt32(rowTemp["Base"]) * tempIva.PorcentajeIva / 100);
                        rowTemp["VIva"] = Convert.ToInt32(subTotal - Convert.ToInt32(rowTemp["Base"]));
                        tTemp.Rows.Add(rowTemp);
                    }
                }

                dataSet.Tables.Add(tTemp);
                return dataSet;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        
        /*
        public DataTable TotalIvaFacturadoVer(int idCaja, DateTime fecha, bool caja)
        {
            var miDaoIva = new DaoIva();
            var tabla = new DataTable();
            tabla.TableName = "IvaGravado";
            tabla.Columns.Add(new DataColumn("Iva", typeof(string)));
            tabla.Columns.Add(new DataColumn("Base", typeof(double)));
            tabla.Columns.Add(new DataColumn("VIva", typeof(double)));
            tabla.Columns.Add(new DataColumn("SubTotal", typeof(double)));
            var tmp = tabla;
            try
            {
                var iva = miDaoIva.ListadoIva();
                var factura = NumeroFacturasActivaTodas(idCaja, fecha, caja);
                foreach (DataRow fRow in factura.Rows)
                {
                    var tProducto = ProductoFacturaVenta
                        (fRow["numerofactura_venta"].ToString(), Convert.ToBoolean(fRow["aplica_descuento"]));
                    foreach (DataRow pRow in tProducto.Rows)
                    {
                        var tmpRow = tmp.NewRow();
                        tmpRow["Iva"] = pRow["Iva"];
                        tmpRow["SubTotal"] = pRow["Valor"];
                        tmp.Rows.Add(tmpRow);
                    }
                }

                IEnumerable<DataRow> query1 = from d in tabla.AsEnumerable()
                                              select d;
                DataTable tTemp = new DataTable();
                if (query1.ToArray().Length != 0)
                {
                    tTemp = query1.CopyToDataTable<DataRow>();
                }
                tTemp.Rows.Clear();
                tTemp.TableName = "IvaGravado";
                foreach (Iva tempIva in iva)
                {
                    var subTotal = tmp.AsEnumerable().Where(i => i.Field<string>("Iva").
                        Equals(tempIva.PorcentajeIva.ToString() + "%")).Sum(s => s.Field<double>("SubTotal"));
                    if (subTotal != 0)
                    {
                        var rowTemp = tTemp.NewRow();
                        rowTemp["Iva"] = tempIva.PorcentajeIva.ToString() + "%";
                        rowTemp["SubTotal"] = subTotal;
                        rowTemp["Base"] = Convert.ToInt32(subTotal / (1 + (tempIva.PorcentajeIva / 100)));
                        rowTemp["VIva"] = Convert.ToInt32(subTotal - Convert.ToInt32(rowTemp["Base"]));
                        tTemp.Rows.Add(rowTemp);
                    }
                }

                return tTemp;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        */

        // NUEVO CODIGO 02-02-2016

        /*public DataTable TotalIvaFacturado(int idCaja, DateTime fecha)
        {
            try
            {
                var tabla = new DataTable();
                CargarAdapter("ventas");
                miAdapter.SelectCommand.Parameters.AddWithValue("", idCaja);
                miAdapter.SelectCommand.Parameters.AddWithValue("", fecha);
                miAdapter.Fill(tabla);

                var dsIva = new DataSet();
                var tIva = new DataTable();
                tIva.TableName = "IvaGravado";
                tIva.Columns.Add(new DataColumn("Iva", typeof(string)));
                tIva.Columns.Add(new DataColumn("Base", typeof(double)));
                tIva.Columns.Add(new DataColumn("VIva", typeof(double)));
                tIva.Columns.Add(new DataColumn("SubTotal", typeof(double)));

                foreach (DataRow row in tabla.Rows)
                {
                    var iRow = tIva.NewRow();

                    var iva_ = row["valor_iva"].ToString() + "%";
                    var base_ = Convert.ToInt32(Convert.ToInt32(row["total"]) / (1 + (Convert.ToDouble(row["valor_iva"]) / 100)));
                    var vIva_ = Convert.ToInt32(row["total"]) -
                        Convert.ToInt32(Convert.ToInt32(row["total"]) / (1 + (Convert.ToDouble(row["valor_iva"]) / 100)));
                    var total_ = Convert.ToInt32(row["total"]);

                    iRow["Iva"] = row["valor_iva"].ToString() + "%";
                    iRow["Base"] = Convert.ToInt32(Convert.ToInt32(row["total"]) / (1 + (Convert.ToDouble(row["valor_iva"]) / 100)));
                    iRow["VIva"] = Convert.ToInt32(row["total"]) -
                        Convert.ToInt32(Convert.ToInt32(row["total"]) / (1 + (Convert.ToDouble(row["valor_iva"]) / 100)));
                    iRow["SubTotal"] = Convert.ToInt32(row["total"]);
                    tIva.Rows.Add(iRow);
                }
                return tIva;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al cargar el IVA facturado.\n" + ex.Message);
            }
        }
        */

        // 11-04-2016   1. Iva por caja y fecha, impresion media carta y en tirilla.
        public DataTable TotalIvaFacturado2(int idCaja, DateTime fecha)
        {
            try
            {
                var tabla = new DataTable();
                CargarAdapter("ventas2");
                miAdapter.SelectCommand.Parameters.AddWithValue("", idCaja);
                miAdapter.SelectCommand.Parameters.AddWithValue("", fecha);
                miAdapter.Fill(tabla);
                var query = from data in tabla.AsEnumerable()
                            group data by new
                            {
                                caja = data.Field<int>("idcaja"),
                                fecha = data.Field<DateTime>("fecha"),
                                iva = data.Field<double>("valor_iva")
                            }
                                into grupo
                                select new
                                {
                                    caja = grupo.Key.caja,
                                    fecha = grupo.Key.fecha,
                                    iva = grupo.Key.iva,
                                    valor = Convert.ToDouble(grupo.Sum(s => s.Field<decimal>("total")))
                                };
                var tIva = new DataTable();
                tIva.TableName = "IvaGravado";
                tIva.Columns.Add(new DataColumn("Iva", typeof(string)));
                tIva.Columns.Add(new DataColumn("Base", typeof(double)));
                tIva.Columns.Add(new DataColumn("VIva", typeof(double)));
                tIva.Columns.Add(new DataColumn("SubTotal", typeof(double)));
                foreach (var qRow in query)
                {
                    var iRow = tIva.NewRow();
                    iRow["Iva"] = qRow.iva.ToString();// +"%";
                    iRow["Base"] = Convert.ToInt32(qRow.valor / (1 + (qRow.iva / 100)));
                    iRow["VIva"] = Convert.ToInt32(qRow.valor - (qRow.valor / (1 + (qRow.iva / 100))));
                    iRow["SubTotal"] = Convert.ToInt32(qRow.valor);
                    tIva.Rows.Add(iRow);
                }
                /*DataRow iRow_ = tIva.NewRow();
                iRow_["Iva"] = 19;// +"%";
                iRow_["Base"] = 1000;
                iRow_["VIva"] = 1000;
                iRow_["SubTotal"] = 100;
                tIva.Rows.Add(iRow_);

                iRow_ = tIva.NewRow();
                iRow_["Iva"] = 19;// +"%";
                iRow_["Base"] = 1000;
                iRow_["VIva"] = 1000;
                iRow_["SubTotal"] = 100;
                tIva.Rows.Add(iRow_);

                iRow_ = tIva.NewRow();
                iRow_["Iva"] = 19;// +"%";
                iRow_["Base"] = 1000;
                iRow_["VIva"] = 1000;
                iRow_["SubTotal"] = 100;
                tIva.Rows.Add(iRow_);*/
                return tIva;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al cargar el IVA facturado.\n" + ex.Message);
            }
        }

        // FIN NUEVO CODIGO 02-02-2016

        // Actualización comprobante diario fiscal general 23-02-2017

        //  3.  Iva por caja y fecha, impresion en tirilla.
        public DataTable TotalIvaFacturado2(DateTime fecha)
        {
            try
            {
                var tabla = new DataTable();
                CargarAdapter("ventas2");
                miAdapter.SelectCommand.Parameters.AddWithValue("", fecha);
                miAdapter.Fill(tabla);
                var query = from data in tabla.AsEnumerable()
                            group data by new
                            {
                                //caja = data.Field<int>("idcaja"),
                                fecha = data.Field<DateTime>("fecha"),
                                iva = data.Field<double>("valor_iva")
                            }
                                into grupo
                                select new
                                {
                                    //caja = grupo.Key.caja,
                                    fecha = grupo.Key.fecha,
                                    iva = grupo.Key.iva,
                                    valor = Convert.ToDouble(grupo.Sum(s => s.Field<decimal>("total")))
                                };
                var tIva = new DataTable();
                tIva.TableName = "IvaGravado";
                tIva.Columns.Add(new DataColumn("Iva", typeof(string)));
                tIva.Columns.Add(new DataColumn("Base", typeof(double)));
                tIva.Columns.Add(new DataColumn("VIva", typeof(double)));
                tIva.Columns.Add(new DataColumn("SubTotal", typeof(double)));
                foreach (var qRow in query)
                {
                    var iRow = tIva.NewRow();
                    iRow["Iva"] = qRow.iva.ToString();// +"%";
                    iRow["Base"] = Convert.ToInt32(qRow.valor / (1 + (qRow.iva / 100)));
                    iRow["VIva"] = Convert.ToInt32(qRow.valor - (qRow.valor / (1 + (qRow.iva / 100))));
                    iRow["SubTotal"] = Convert.ToInt32(qRow.valor);
                    tIva.Rows.Add(iRow);
                }
                /*var iRow_ = tIva.NewRow();
                iRow_["Iva"] = 19;// +"%";
                iRow_["Base"] = 8403353;
                iRow_["VIva"] = 1596637;
                iRow_["SubTotal"] = 9999990;
                tIva.Rows.Add(iRow_);

                iRow_ = tIva.NewRow();
                iRow_["Iva"] = 19;// +"%";
                iRow_["Base"] = 8761160;
                iRow_["VIva"] = 1664620;
                iRow_["SubTotal"] = 10425780;
                tIva.Rows.Add(iRow_);*/
                return tIva;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al cargar el IVA facturado.\n" + ex.Message);
            }
        }

        //  2.  Iva por fecha, impresion media carta.
        public DataSet TotalIvaFacturado2Ds(DateTime fecha)
        {
            try
            {
                DataSet ds = new DataSet();
                var tabla = new DataTable();
                CargarAdapter("ventas2");
                miAdapter.SelectCommand.Parameters.AddWithValue("", fecha);
                miAdapter.Fill(tabla);
                var query = from data in tabla.AsEnumerable()
                            group data by new
                            {
                                //caja = data.Field<int>("idcaja"),
                                fecha = data.Field<DateTime>("fecha"),
                                iva = data.Field<double>("valor_iva")
                            }
                                into grupo
                                select new
                                {
                                    //caja = grupo.Key.caja,
                                    fecha = grupo.Key.fecha,
                                    iva = grupo.Key.iva,
                                    valor = Convert.ToDouble(grupo.Sum(s => s.Field<decimal>("total")))
                                };
                var tIva = new DataTable();
                tIva.TableName = "IvaGravado";
                tIva.Columns.Add(new DataColumn("Iva", typeof(string)));
                tIva.Columns.Add(new DataColumn("Base", typeof(double)));
                tIva.Columns.Add(new DataColumn("VIva", typeof(double)));
                tIva.Columns.Add(new DataColumn("SubTotal", typeof(double)));
                foreach (var qRow in query)
                {
                    var iRow = tIva.NewRow();
                    iRow["Iva"] = qRow.iva.ToString() + "%";
                    iRow["Base"] = Convert.ToInt32(qRow.valor / (1 + (qRow.iva / 100)));
                    iRow["VIva"] = Convert.ToInt32(qRow.valor - (qRow.valor / (1 + (qRow.iva / 100))));
                    iRow["SubTotal"] = Convert.ToInt32(qRow.valor);
                    tIva.Rows.Add(iRow);
                }
                ds.Tables.Add(tIva);
                return ds;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al cargar el IVA facturado.\n" + ex.Message);
            }
        }

        // Fin Actualización


        //  Funciones de actualización 12/07/2018, Mejora al calculo de Iva.

        public DataTable TotalIvaFacturado(int idCaja, DateTime fecha)
        {
            try
            {
                var tIva = new DataTable();
                tIva.TableName = "IvaGravado";
                tIva.Columns.Add(new DataColumn("Iva", typeof(string)));
                tIva.Columns.Add(new DataColumn("Base", typeof(double)));
                tIva.Columns.Add(new DataColumn("VIva", typeof(double)));
                tIva.Columns.Add(new DataColumn("SubTotal", typeof(double)));

                this.CargarComando("ventas2_");
                this.miComando.Parameters.AddWithValue("", idCaja);
                this.miComando.Parameters.AddWithValue("", fecha);
                this.miConexion.MiConexion.Open();
                NpgsqlDataReader reader = this.miComando.ExecuteReader();
                while (reader.Read())
                {
                    var iRow = tIva.NewRow();
                    iRow["Iva"] = reader.GetDouble(0);
                    iRow["Base"] = reader.GetDouble(1);
                    iRow["VIva"] = reader.GetDouble(2) - reader.GetDouble(1);
                    iRow["SubTotal"] = reader.GetDouble(2);
                    tIva.Rows.Add(iRow);
                }
                return tIva;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al cargar el IVA facturado.\n" + ex.Message);
            }
            finally { this.miConexion.MiConexion.Close(); }
        }

        public DataTable TotalIvaFacturado(DateTime fecha, string exento)
        {
            try
            {
                var tIva = new DataTable();
                tIva.TableName = "IvaGravado";
                tIva.Columns.Add(new DataColumn("Iva", typeof(string)));
                tIva.Columns.Add(new DataColumn("Base", typeof(double)));
                tIva.Columns.Add(new DataColumn("VIva", typeof(double)));
                tIva.Columns.Add(new DataColumn("SubTotal", typeof(double)));

                double ico = this.TotalImpoConsumo(fecha);
                if (ico > 0)
                {
                    var newRow = tIva.NewRow();
                    newRow["Iva"] = exento;
                    newRow["VIva"] = 0;
                    newRow["SubTotal"] = newRow["Base"] = ico;
                    tIva.Rows.Add(newRow);
                }

                this.CargarComando("ventas2_");
                this.miComando.Parameters.AddWithValue("", fecha);
                this.miConexion.MiConexion.Open();
                NpgsqlDataReader reader = this.miComando.ExecuteReader();
                while (reader.Read())
                {
                    var iRow = tIva.NewRow();
                    iRow["Iva"] = reader.GetDouble(0);
                    iRow["Base"] = reader.GetDouble(1);
                    iRow["VIva"] = reader.GetDouble(2) - reader.GetDouble(1);
                    iRow["SubTotal"] = reader.GetDouble(2);
                    tIva.Rows.Add(iRow);
                }
                return tIva;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al cargar el IVA facturado.\n" + ex.Message);
            }
            finally { this.miConexion.MiConexion.Close(); }
        }

        public DataTable TotalIvaFacturadoConExcento(int idCaja, DateTime fecha, string exento)
        {
            try
            {
                var tIva = new DataTable();
                tIva.TableName = "IvaGravado";
                tIva.Columns.Add(new DataColumn("Iva", typeof(string)));
                tIva.Columns.Add(new DataColumn("Base", typeof(double)));
                tIva.Columns.Add(new DataColumn("VIva", typeof(double)));
                tIva.Columns.Add(new DataColumn("SubTotal", typeof(double)));

                double ico = this.TotalImpoConsumo(idCaja, fecha);
                if (ico > 0)
                {
                    var newRow = tIva.NewRow();
                    newRow["Iva"] = exento;
                    newRow["VIva"] = 0;
                    newRow["SubTotal"] = newRow["Base"] = ico;
                    tIva.Rows.Add(newRow);
                }

                this.CargarComando("ventas2_");
                this.miComando.Parameters.AddWithValue("", idCaja);
                this.miComando.Parameters.AddWithValue("", fecha);
                this.miConexion.MiConexion.Open();
                NpgsqlDataReader reader = this.miComando.ExecuteReader();
                while (reader.Read())
                {
                    var iRow = tIva.NewRow();
                    iRow["Iva"] = reader.GetDouble(0);
                    iRow["Base"] = reader.GetDouble(1);
                    iRow["VIva"] = reader.GetDouble(2) - reader.GetDouble(1);
                    iRow["SubTotal"] = reader.GetDouble(2);
                    tIva.Rows.Add(iRow);
                }
                return tIva;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al cargar el IVA facturado.\n" + ex.Message);
            }
            finally { this.miConexion.MiConexion.Close(); }
        }

        //  Fin funciones de actualización 12/07/2018, Mejora al calculo de Iva.

        // Funciones de actualizacion, nuevo informe fiscal con impoconsumo 12/03/2019

        public DataTable TotalIvaFacturado(DateTime fecha, DateTime fecha2)
        {
            try
            {
                var tIva = new DataTable();
                tIva.TableName = "IvaGravado";
                tIva.Columns.Add(new DataColumn("Iva", typeof(string)));
                tIva.Columns.Add(new DataColumn("Base", typeof(double)));
                tIva.Columns.Add(new DataColumn("VIva", typeof(double)));
                tIva.Columns.Add(new DataColumn("SubTotal", typeof(double)));

                var newRow = tIva.NewRow();
                newRow["Iva"] = "EXENTO";
                newRow["VIva"] = 0;
                newRow["SubTotal"] = newRow["Base"] = this.TotalImpoConsumo(fecha, fecha2);
                tIva.Rows.Add(newRow);

                this.CargarComando("ventas2_periodo");
                this.miComando.Parameters.AddWithValue("", fecha);
                this.miComando.Parameters.AddWithValue("", fecha2);
                this.miConexion.MiConexion.Open();
                NpgsqlDataReader reader = this.miComando.ExecuteReader();
                while (reader.Read())
                {
                    var iRow = tIva.NewRow();
                    iRow["Iva"] = reader.GetDouble(0);
                    iRow["Base"] = reader.GetDouble(1);
                    iRow["VIva"] = reader.GetDouble(2) - reader.GetDouble(1);
                    iRow["SubTotal"] = reader.GetDouble(2);
                    tIva.Rows.Add(iRow);
                }
                return tIva;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al cargar el IVA facturado.\n" + ex.Message);
            }
            finally { this.miConexion.MiConexion.Close(); }
        }


        public DataTable TotalIvaFacturado_Datos(DateTime fecha, DateTime fecha2)
        {
            try
            {
                var tIva = new DataTable();
                tIva.TableName = "IvaGravado";
                tIva.Columns.Add(new DataColumn("Fecha", typeof(DateTime)));
                tIva.Columns.Add(new DataColumn("Iva", typeof(string)));
                tIva.Columns.Add(new DataColumn("Base", typeof(double)));
                tIva.Columns.Add(new DataColumn("VIva", typeof(double)));
                tIva.Columns.Add(new DataColumn("SubTotal", typeof(double)));

                var newRow = tIva.NewRow();
                newRow["Fecha"] = fecha.ToShortDateString();
                newRow["Iva"] = "0";
                newRow["VIva"] = 0;
                newRow["SubTotal"] = 0;
                tIva.Rows.Add(newRow);

                /*double ico = this.TotalImpoConsumo(fecha);
                if (ico > 0)
                {
                    var newRow = tIva.NewRow();
                    newRow["Iva"] = "EXEN";
                    newRow["VIva"] = 0;
                    newRow["SubTotal"] = newRow["Base"] = ico;
                    tIva.Rows.Add(newRow);
                }*/

                this.CargarComando("ventas2_");
                this.miComando.Parameters.AddWithValue("", fecha);
                this.miConexion.MiConexion.Open();
                NpgsqlDataReader reader = this.miComando.ExecuteReader();
                while (reader.Read())
                {
                    var iRow = tIva.NewRow();
                    iRow["Iva"] = reader.GetDouble(0);
                    iRow["Base"] = reader.GetDouble(1);
                    iRow["VIva"] = reader.GetDouble(2) - reader.GetDouble(1);
                    iRow["SubTotal"] = reader.GetDouble(2);
                    tIva.Rows.Add(iRow);
                }
                return tIva;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al cargar el IVA facturado.\n" + ex.Message);
            }
            finally { this.miConexion.MiConexion.Close(); }


           /* try
            {
                var tIva = new DataTable();
                tIva.TableName = "IvaGravado";

                tIva.Columns.Add(new DataColumn("Fecha", typeof(DateTime)));
                tIva.Columns.Add(new DataColumn("Iva", typeof(string)));
                tIva.Columns.Add(new DataColumn("Base", typeof(double)));
                tIva.Columns.Add(new DataColumn("VIva", typeof(double)));
                tIva.Columns.Add(new DataColumn("SubTotal", typeof(double)));

                var newRow = tIva.NewRow();
                newRow["Fecha"] = fecha.ToShortDateString();
                newRow["Iva"] = "EXENTO";
                newRow["VIva"] = 0;
                newRow["SubTotal"] = newRow["Base"] = this.TotalImpoConsumo(fecha, fecha2);
                tIva.Rows.Add(newRow);

                this.CargarComando("ventas2_periodo");
                this.miComando.Parameters.AddWithValue("", fecha);
                this.miComando.Parameters.AddWithValue("", fecha2);
                this.miConexion.MiConexion.Open();
                NpgsqlDataReader reader = this.miComando.ExecuteReader();
                while (reader.Read())
                {
                    var iRow = tIva.NewRow();
                    iRow["Iva"] = reader.GetDouble(0);
                    iRow["Base"] = reader.GetDouble(1);
                    iRow["VIva"] = reader.GetDouble(2) - reader.GetDouble(1);
                    iRow["SubTotal"] = reader.GetDouble(2);
                    tIva.Rows.Add(iRow);
                }
                return tIva;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al cargar el IVA facturado.\n" + ex.Message);
            }
            finally { this.miConexion.MiConexion.Close(); }*/
        }

        private double TotalImpoConsumo(int idCaja, DateTime fecha, DateTime fecha2)
        {
            try
            {
                this.CargarComando("total_impoconsumo_periodo");
                this.miComando.Parameters.AddWithValue("", idCaja);
                this.miComando.Parameters.AddWithValue("", fecha);
                this.miComando.Parameters.AddWithValue("", fecha2);
                this.miConexion.MiConexion.Open();
                double total = Convert.ToDouble(this.miComando.ExecuteScalar());
                this.miConexion.MiConexion.Close();
                this.miComando.Dispose();
                return total;
            }
            catch (InvalidCastException)
            {
                return 0;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally { this.miConexion.MiConexion.Close(); }
        }

        private double TotalImpoConsumo(DateTime fecha, DateTime fecha2)
        {
            try
            {
                this.CargarComando("total_impoconsumo_periodo");
                this.miComando.Parameters.AddWithValue("", fecha);
                this.miComando.Parameters.AddWithValue("", fecha2);
                this.miConexion.MiConexion.Open();
                double total = Convert.ToDouble(this.miComando.ExecuteScalar());
                this.miConexion.MiConexion.Close();
                this.miComando.Dispose();
                return total;
            }
            catch (InvalidCastException)
            {
                return 0;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally { this.miConexion.MiConexion.Close(); }
        }

        public double TotalImpoConsumo(DateTime fecha)
        {
            try
            {
                this.CargarComando("total_impoconsumo");
                this.miComando.Parameters.AddWithValue("", fecha);
                this.miConexion.MiConexion.Open();
                double total = Convert.ToDouble(this.miComando.ExecuteScalar());
                this.miConexion.MiConexion.Close();
                this.miComando.Dispose();
                return total;
            }
            catch (InvalidCastException)
            {
                return 0;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally { this.miConexion.MiConexion.Close(); }
        }

        public double TotalImpoConsumo(int idCaja, DateTime fecha2)
        {
            try
            {
                this.CargarComando("total_impoconsumo");
                this.miComando.Parameters.AddWithValue("", idCaja);
                this.miComando.Parameters.AddWithValue("", fecha2);
                this.miConexion.MiConexion.Open();
                double total = Convert.ToDouble(this.miComando.ExecuteScalar());
                this.miConexion.MiConexion.Close();
                this.miComando.Dispose();
                return total;
            }
            catch (InvalidCastException)
            {
                return 0;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally { this.miConexion.MiConexion.Close(); }
        }

        // Fin funciones de actualizacion, nuevo informe fiscal con impoconsumo 12/03/2019


        // Funciones actualización, nuevo calculo de impuestos 09 - 09 -2020        ***

        public List<Impuesto> TotalesImpuesto(int idCaja, DateTime fecha)
        {
            try
            {
                int valor = 0;
                var impuestos = new List<Impuesto>();
                this.CargarComando("consulta_impuestos_iva");
                this.miComando.Parameters.AddWithValue("", idCaja);
                this.miComando.Parameters.AddWithValue("", fecha);
                this.miConexion.MiConexion.Open();
                NpgsqlDataReader reader = this.miComando.ExecuteReader();
                while (reader.Read())
                {
                    var impuesto = new Impuesto();

                    if (!reader.IsDBNull(0))
                    {
                        valor = Convert.ToInt32(reader.GetDecimal(0));
                        if (valor > 0)
                        {
                            impuesto.Tarifa = "0";
                            impuesto.BaseGravable = valor;
                            impuesto.Impoconsumo = Convert.ToInt32(reader.GetDouble(10));
                            impuesto.ValorIva = Convert.ToInt32(reader.GetDecimal(1));
                            impuesto.Neto = impuesto.BaseGravable + impuesto.Impoconsumo + impuesto.ValorIva;
                            impuestos.Add(impuesto);
                        }
                        valor = Convert.ToInt32(reader.GetDecimal(8));
                        if (valor > 0)
                        {
                            impuesto = new Impuesto();
                            impuesto.Tarifa = "1E-07";
                            impuesto.BaseGravable = valor;
                            impuesto.Impoconsumo = 0;
                            impuesto.ValorIva = Convert.ToInt32(reader.GetDecimal(9));
                            impuesto.Neto = impuesto.BaseGravable + impuesto.ValorIva;
                            impuestos.Add(impuesto);
                        }
                        valor = Convert.ToInt32(reader.GetDecimal(2));
                        if (valor > 0)
                        {
                            impuesto = new Impuesto();
                            impuesto.Tarifa = "5";
                            impuesto.BaseGravable = valor;
                            impuesto.Impoconsumo = Convert.ToInt32(reader.GetDouble(4));
                            impuesto.ValorIva = Convert.ToInt32(reader.GetDecimal(3));
                            impuesto.Neto = impuesto.BaseGravable + impuesto.Impoconsumo + impuesto.ValorIva;
                            impuestos.Add(impuesto);
                        }
                        valor = Convert.ToInt32(reader.GetDecimal(5));
                        if (valor > 0)
                        {
                            impuesto = new Impuesto();
                            impuesto.Tarifa = "19";
                            impuesto.BaseGravable = valor;
                            impuesto.Impoconsumo = Convert.ToInt32(reader.GetDouble(7));
                            impuesto.ValorIva = Convert.ToInt32(reader.GetDecimal(6));
                            impuesto.Neto = impuesto.BaseGravable + impuesto.Impoconsumo + impuesto.ValorIva;
                            impuestos.Add(impuesto);
                        }
                    }
                }
                this.miConexion.MiConexion.Close();
                this.miComando.Dispose();
                return impuestos;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally { this.miConexion.MiConexion.Close(); }
        }

        public List<Impuesto> TotalesImpuesto(DateTime fecha)
        {
            try
            {
                int valor = 0;
                var impuestos = new List<Impuesto>();
                this.CargarComando("consulta_impuestos_iva");
                this.miComando.Parameters.AddWithValue("", fecha);
                this.miConexion.MiConexion.Open();
                NpgsqlDataReader reader = this.miComando.ExecuteReader();
                while (reader.Read())
                {
                    var impuesto = new Impuesto();

                    if (!reader.IsDBNull(0))
                    {
                        valor = Convert.ToInt32(reader.GetDecimal(0));
                        if (valor > 0)
                        {
                            impuesto.Tarifa = "0";
                            impuesto.BaseGravable = Convert.ToInt32(reader.GetDecimal(0));
                            impuesto.Impoconsumo = Convert.ToInt32(reader.GetDouble(10));
                            impuesto.ValorIva = Convert.ToInt32(reader.GetDecimal(1));
                            impuesto.Neto = impuesto.BaseGravable + impuesto.Impoconsumo + impuesto.ValorIva;
                            impuestos.Add(impuesto);
                        }

                        valor = Convert.ToInt32(reader.GetDecimal(8));
                        if (valor > 0)
                        {
                            impuesto = new Impuesto();
                            impuesto.Tarifa = "1E-07";
                            impuesto.BaseGravable = Convert.ToInt32(reader.GetDecimal(8));
                            impuesto.Impoconsumo = 0;
                            impuesto.ValorIva = Convert.ToInt32(reader.GetDecimal(9));
                            impuesto.Neto = impuesto.BaseGravable + impuesto.ValorIva;
                            impuestos.Add(impuesto);
                        }

                        valor = Convert.ToInt32(reader.GetDecimal(2));
                        if (valor > 0)
                        {
                            impuesto = new Impuesto();
                            impuesto.Tarifa = "5";
                            impuesto.BaseGravable = Convert.ToInt32(reader.GetDecimal(2));
                            impuesto.Impoconsumo = Convert.ToInt32(reader.GetDouble(4));
                            impuesto.ValorIva = Convert.ToInt32(reader.GetDecimal(3));
                            impuesto.Neto = impuesto.BaseGravable + impuesto.Impoconsumo + impuesto.ValorIva;
                            impuestos.Add(impuesto);
                        }

                        valor = Convert.ToInt32(reader.GetDecimal(5));
                        if (valor > 0)
                        {
                            impuesto = new Impuesto();
                            impuesto.Tarifa = "19";
                            impuesto.BaseGravable = Convert.ToInt32(reader.GetDecimal(5));
                            impuesto.Impoconsumo = Convert.ToInt32(reader.GetDouble(7));
                            impuesto.ValorIva = Convert.ToInt32(reader.GetDecimal(6));
                            impuesto.Neto = impuesto.BaseGravable + impuesto.Impoconsumo + impuesto.ValorIva;
                            impuestos.Add(impuesto);
                        }
                    }
                }
                this.miConexion.MiConexion.Close();
                this.miComando.Dispose();
                return impuestos;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally { this.miConexion.MiConexion.Close(); }
        }

        public List<Impuesto> TotalesImpuesto(DateTime fecha, DateTime fecha2)
        {
            try
            {
                int valor = 0;
                var impuestos = new List<Impuesto>();
                this.CargarComando("consulta_impuestos_iva_periodo");
                this.miComando.Parameters.AddWithValue("", fecha);
                this.miComando.Parameters.AddWithValue("", fecha2);
                this.miConexion.MiConexion.Open();
                NpgsqlDataReader reader = this.miComando.ExecuteReader();
                while (reader.Read())
                {
                    var impuesto = new Impuesto();

                    if (!reader.IsDBNull(0))
                    {
                        valor = Convert.ToInt32(reader.GetDecimal(0));
                        if (valor > 0)
                        {
                            impuesto.Tarifa = "0";
                            impuesto.BaseGravable = Convert.ToInt32(reader.GetDecimal(0));
                            impuesto.Impoconsumo = Convert.ToInt32(reader.GetDouble(10));
                            impuesto.ValorIva = Convert.ToInt32(reader.GetDecimal(1));
                            impuesto.Neto = impuesto.BaseGravable + impuesto.Impoconsumo + impuesto.ValorIva;
                            impuestos.Add(impuesto);
                        }

                        valor = Convert.ToInt32(reader.GetDecimal(8));
                        if (valor > 0)
                        {
                            impuesto = new Impuesto();
                            impuesto.Tarifa = "1E-07";
                            impuesto.BaseGravable = Convert.ToInt32(reader.GetDecimal(8));
                            impuesto.Impoconsumo = 0;
                            impuesto.ValorIva = Convert.ToInt32(reader.GetDecimal(9));
                            impuesto.Neto = impuesto.BaseGravable + impuesto.ValorIva;
                            impuestos.Add(impuesto);
                        }

                        valor = Convert.ToInt32(reader.GetDecimal(2));
                        if (valor > 0)
                        {
                            impuesto = new Impuesto();
                            impuesto.Tarifa = "5";
                            impuesto.BaseGravable = Convert.ToInt32(reader.GetDecimal(2));
                            impuesto.Impoconsumo = Convert.ToInt32(reader.GetDouble(4));
                            impuesto.ValorIva = Convert.ToInt32(reader.GetDecimal(3));
                            impuesto.Neto = impuesto.BaseGravable + impuesto.Impoconsumo + impuesto.ValorIva;
                            impuestos.Add(impuesto);
                        }

                        valor = Convert.ToInt32(reader.GetDecimal(5));
                        if (valor > 0)
                        {
                            impuesto = new Impuesto();
                            impuesto.Tarifa = "19";
                            impuesto.BaseGravable = Convert.ToInt32(reader.GetDecimal(5));
                            impuesto.Impoconsumo = Convert.ToInt32(reader.GetDouble(7));
                            impuesto.ValorIva = Convert.ToInt32(reader.GetDecimal(6));
                            impuesto.Neto = impuesto.BaseGravable + impuesto.Impoconsumo + impuesto.ValorIva;
                            impuestos.Add(impuesto);
                        }
                    }
                }
                this.miConexion.MiConexion.Close();
                this.miComando.Dispose();
                return impuestos;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally { this.miConexion.MiConexion.Close(); }
        }


        /// New query, add id_iva and improve performance                       2022 11 26
        /// 
        public List<Impuesto> TotalesImpuesto(int idCaja, DateTime fecha, DateTime fecha2)
        {
            try
            {
                var impuestos = new List<Impuesto>();
                string caja = "";

                if (idCaja != 0)
                {
                    caja = " factura_venta.idcaja = @caja AND ";
                }

                string sql =
                    @"SELECT 
	                    iva.idiva,
	                    iva.valoriva as tarifa,
	                    iva.conceptoiva, 
	                    mi_round( sum((producto_factura_venta.total - (producto_factura_venta.impoconsumo * 
	                      producto_factura_venta.cantidadproducto_factura_venta)) / (1 + (iva.valoriva / 100))), 0 ) 
	                      AS base_iva ,  
											 
	                    mi_round( sum(((producto_factura_venta.total - (producto_factura_venta.impoconsumo * 
	                      producto_factura_venta.cantidadproducto_factura_venta)) / (1 + (iva.valoriva / 100))) * 
	                      iva.valoriva / 100), 0) 
	                      AS iva  , 
		   
	                    mi_round_trunc(SUM(producto_factura_venta.impoconsumo * 
	                      producto_factura_venta.cantidadproducto_factura_venta) , 0) 
	                      AS ico_base , 
		
	                    sum(producto_factura_venta.total) AS sub_total 
                    FROM 
	                    factura_venta INNER JOIN 
	                    producto_factura_venta 
		                    ON factura_venta.id = producto_factura_venta.id_factura 
	                    INNER JOIN 
	                    iva 
		                    ON producto_factura_venta.id_iva = iva.idiva 
                    WHERE 
	                    factura_venta.estado = true AND 
                        (factura_venta.idestado = 1 OR 
                        factura_venta.idestado = 2) AND " + 
                        caja + @"
                        factura_venta.fecha_factura_venta BETWEEN @fecha AND @fecha2 AND 
                        producto_factura_venta.retorno = FALSE 
                    GROUP BY 
	                    iva.idiva ,
	                    iva.valoriva,
	                    iva.conceptoiva 
                    ORDER BY 
	                    iva.idiva;";
                CargarComandoText(sql);
                miComando.Parameters.AddWithValue("fecha", fecha);
                miComando.Parameters.AddWithValue("fecha2", fecha2);
                if (idCaja != 0)
                {
                    miComando.Parameters.AddWithValue("caja", idCaja);
                }
                miConexion.MiConexion.Open();
                NpgsqlDataReader reader = this.miComando.ExecuteReader();
                while (reader.Read())
                {
                    var impuesto = new Impuesto
                    {
                        Tarifa = reader.GetDouble(1).ToString(),
                        Concepto = reader.GetString(2),
                        BaseGravable = Convert.ToInt32(reader.GetDecimal(3)),
                        ValorIva = Convert.ToInt32(reader.GetDecimal(4)),
                        Impoconsumo = reader.GetDouble(5),
                        Neto = Convert.ToInt32(reader.GetInt64(6))
                    };
                    impuestos.Add(impuesto);
                }
                this.miConexion.MiConexion.Close();
                this.miComando.Dispose();
                return impuestos;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally { this.miConexion.MiConexion.Close(); }
        }

        // Fin Funciones actualización, nuevo calculo de impuestos 09 - 09 -2020    ****


        /*public DataTable ResumenDeUtilidad(DateTime fecha, DateTime fecha2)
        {
            try
            {
                var miDaoProducto = new DaoProducto();
                double costo = 0;
                double valor = 0;
                double vIva = 0;
                var tUtilidad = new DataTable();
                tUtilidad.Columns.Add(new DataColumn("Costo", typeof(int)));
                tUtilidad.Columns.Add(new DataColumn("Venta", typeof(int)));
                tUtilidad.Columns.Add(new DataColumn("Diferencia", typeof(int)));
                var tFacturas = NumeroFacturasActivaTodas(fecha, fecha2);
                foreach (DataRow fRow in tFacturas.Rows)
                {
                    var tProductos = ProductosVendidos(fRow["numerofactura_venta"].ToString());
                    foreach (DataRow pRow in tProductos.Rows)
                    {
                        var row = tUtilidad.NewRow();
                        var pcRow = ProductoCosto(pRow["codigo"].ToString()).AsEnumerable().First();

                        costo = Convert.ToDouble(pcRow["costo"]);
                        row["Costo"] = Convert.ToInt32(Convert.ToDouble(pRow["cantidad"]) *
                            (Convert.ToInt32(costo) + Convert.ToInt32(costo * Convert.ToDouble(pcRow["iva"]) / 100)));
                        var c = row["Costo"].ToString();

                        valor = Math.Round((Convert.ToDouble(pRow["valor"]) -
                            (Convert.ToDouble(pRow["valor"]) * Convert.ToDouble(pRow["descuento"]) / 100)), 1);
                        vIva = Math.Round((valor * Convert.ToDouble(pRow["iva"]) / 100), 1);
                        valor = Convert.ToInt32(valor + vIva);
                        row["Venta"] = Convert.ToInt32(valor * Convert.ToDouble(pRow["cantidad"]));
                        c = row["Venta"].ToString();

                        row["Diferencia"] = Convert.ToInt32(row["Venta"]) - Convert.ToInt32(Convert.ToInt32(row["Costo"]));
                        c = row["Diferencia"].ToString();

                        tUtilidad.Rows.Add(row);
                    }
                }
                IEnumerable<DataRow> query = from data in tUtilidad.AsEnumerable()
                                             select data;
                DataTable tUtilidadFinal = new DataTable();
                if (query.ToArray().Length != 0)
                {
                    tUtilidadFinal = query.CopyToDataTable<DataRow>();
                }
                tUtilidadFinal.Rows.Clear();
                var rowF = tUtilidadFinal.NewRow();
                rowF["Costo"] = tUtilidad.AsEnumerable().Sum(s => s.Field<int>("Costo"));
                rowF["Venta"] = tUtilidad.AsEnumerable().Sum(s => s.Field<int>("Venta"));
                rowF["Diferencia"] = tUtilidad.AsEnumerable().Sum(s => s.Field<int>("Diferencia"));
                tUtilidadFinal.Rows.Add(rowF);
                tUtilidad.Rows.Clear();
                return tUtilidadFinal;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al calcular el resumen de utilidad.\n" + ex.Message);
            }
        }*/

        public DataTable ProductosVendidos(string numero)
        {
            try
            {
                var tabla = new DataTable();
                CargarAdapter("productos_vendidos");
                miAdapter.SelectCommand.Parameters.AddWithValue("numero", numero);
                miAdapter.Fill(tabla);
                return tabla;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al consultar los productos vendidos.\n" + ex.Message);
            }
        }

        public DataTable ProductoCosto(string codigo)
        {
            try
            {
                var tabla = new DataTable();
                CargarAdapter("productos_costo");
                miAdapter.SelectCommand.Parameters.AddWithValue("codigo", codigo);
                miAdapter.Fill(tabla);
                return tabla;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al consultar los productos.\n" + ex.Message);
            }
        }

        public int CostoDeProducto(string codigo, int idTipoInventario)
        {
            try
            {
                int costo = 0;
                if (idTipoInventario.Equals(3))
                {
                    if (ExisteProductoFabricado(codigo))
                    {
                        string sql = "SELECT SUM(producto.precio_costo * producto_fabricado.cantidad) FROM producto, producto_fabricado WHERE " +
                            "producto_fabricado.prod_proceso = producto.codigointernoproducto AND producto_fabricado.prod_fabricado = '" + codigo + "';";
                        miComando = new NpgsqlCommand();
                        miComando.Connection = miConexion.MiConexion;
                        miComando.CommandType = CommandType.Text;
                        miComando.CommandText = sql;
                        miComando.CommandTimeout = 0;
                        miConexion.MiConexion.Open();
                        costo = Convert.ToInt32(miComando.ExecuteScalar());
                        miConexion.MiConexion.Close();
                        miComando.Dispose();
                    }
                    else
                    {
                        var pRow = ProductoCosto(codigo).AsEnumerable().First();
                        costo = Convert.ToInt32(
                            Convert.ToDouble(pRow["costo"]) + Convert.ToDouble(Convert.ToDouble(pRow["costo"]) * Convert.ToDouble(pRow["iva"]) / 100));
                    }
                }
                else
                {
                    var pRow = ProductoCosto(codigo).AsEnumerable().First();
                    costo = Convert.ToInt32(
                        Convert.ToDouble(pRow["costo"]) + Convert.ToDouble(Convert.ToDouble(pRow["costo"]) * Convert.ToDouble(pRow["iva"]) / 100));
                }
                return costo;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al consultar el costo del producto.\n" + ex.Message);
            }
            finally { miConexion.MiConexion.Close(); }
        }

        private bool ExisteProductoFabricado(string codigo)
        {
            try
            {
                CargarComando("existe_producto_fabricado");
                miComando.Parameters.AddWithValue("", codigo);
                miConexion.MiConexion.Open();
                bool resultado = Convert.ToBoolean(miComando.ExecuteScalar());
                miConexion.MiConexion.Close();
                miComando.Dispose();
                return resultado;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al verificar el producto fabricado.\n" + ex.Message);
            }
            finally { miConexion.MiConexion.Close(); }
        }

        public DataSet TotalIvaFacturadoAntes(int idCaja, DateTime fecha, bool caja)
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
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public int Acumulado_(int idCaja, DateTime fecha, DateTime fecha2)
        {
            try
            {
                int acumulado = 0;
                var tabla = new DataTable();
                CargarAdapter("ventas");
                miAdapter.SelectCommand.Parameters.AddWithValue("", idCaja);
                miAdapter.SelectCommand.Parameters.AddWithValue("", fecha);
                miAdapter.SelectCommand.Parameters.AddWithValue("", fecha2);
                miAdapter.Fill(tabla);

                // ACT. 06/07/2018 redondear a la decima (10) los totales de la consulta.

                foreach (DataRow vRow in tabla.Rows)
                {
                    acumulado += UseObject.Aproximar(Convert.ToInt32(vRow["total"]), this.AproximacionPrecio);
                }

                // Fin ACT. 06/07/2018...

                //acumulado = Convert.ToInt32(tabla.AsEnumerable().Sum(s => s.Field<decimal>("total")));

               /* var tFacturas = NumeroFacturasActivaTodas(idCaja, fecha, fecha2);
                foreach (DataRow fRow in tFacturas.Rows)
                {
                    var tProducto = ProductoFacturaVenta
                        (Convert.ToInt32(fRow["id"]), Convert.ToBoolean(fRow["aplica_descuento"]));
                    foreach (DataRow pRow in tProducto.Rows)
                    {
                        acumulado += Convert.ToDouble(pRow["Valor"]);
                    }
                }*/
                return acumulado;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al cargar el acumulado.\n" + ex.Message);
            }
        }

        // this
        public int Acumulado_old(int idCaja, DateTime fecha, DateTime fecha2)
        {   //  Mejoras en funcion acumulado 11/07/2018
            try
            {
                CargarComando("acumulado");
                this.miComando.Parameters.AddWithValue("", idCaja);
                this.miComando.Parameters.AddWithValue("", fecha);
                this.miComando.Parameters.AddWithValue("", fecha2);
                this.miConexion.MiConexion.Open();
                int acumulado = Convert.ToInt32(this.miComando.ExecuteScalar());
                this.miConexion.MiConexion.Close();
                this.miComando.Dispose();
                acumulado += Convert.ToInt32(this.TotalImpoConsumo(idCaja, fecha, fecha2));
                return acumulado;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al cargar el acumulado.\n" + ex.Message);
            }
            finally { this.miConexion.MiConexion.Close(); }
        }

        // this
        public int Acumulado_old(DateTime fecha, DateTime fecha2)
        {   //  Mejoras en funcion acumulado 11/07/2018
            try
            {
                CargarComando("acumulado");
                this.miComando.Parameters.AddWithValue("", fecha);
                this.miComando.Parameters.AddWithValue("", fecha2);
                this.miConexion.MiConexion.Open();
                int acumulado = Convert.ToInt32(this.miComando.ExecuteScalar());
                this.miConexion.MiConexion.Close();
                this.miComando.Dispose();
                acumulado += Convert.ToInt32(this.TotalImpoConsumo(fecha, fecha2));
                return acumulado;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al cargar el acumulado.\n" + ex.Message);
            }
            finally { this.miConexion.MiConexion.Close(); }
        }


        // Funciones actualización, nuevo calculo de impuestos 09 - 09 -2020        ***

        public int Acumulado(int idCaja, DateTime fecha, DateTime fecha2)
        {
            try
            {
                CargarComando("acumulado");
                this.miComando.Parameters.AddWithValue("", idCaja);
                this.miComando.Parameters.AddWithValue("", fecha);
                this.miComando.Parameters.AddWithValue("", fecha2);
                this.miConexion.MiConexion.Open();
                int acumulado = Convert.ToInt32(this.miComando.ExecuteScalar());
                this.miConexion.MiConexion.Close();
                this.miComando.Dispose();
                return acumulado;
            }
            catch (InvalidCastException)
            {
                return 0;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al cargar el acumulado.\n" + ex.Message);
            }
            finally { this.miConexion.MiConexion.Close(); }
        }

        public int Acumulado(DateTime fecha, DateTime fecha2)
        {
            try
            {
                CargarComando("acumulado");
                this.miComando.Parameters.AddWithValue("", fecha);
                this.miComando.Parameters.AddWithValue("", fecha2);
                this.miConexion.MiConexion.Open();
                int acumulado = Convert.ToInt32(this.miComando.ExecuteScalar());
                this.miConexion.MiConexion.Close();
                this.miComando.Dispose();
                return acumulado;
            }
            catch (InvalidCastException)
            {
                return 0;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al cargar el acumulado.\n" + ex.Message);
            }
            finally { this.miConexion.MiConexion.Close(); }
        }

        // Fin Funciones actualización, nuevo calculo de impuestos 09 - 09 -2020    ***


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

       /* public DataTable FacturasDeVentaPeriodo(int idEstado, int idCaja, DateTime fecha, DateTime fecha2)
        {
            var tabla = new DataTable();
            try
            {
                CargarAdapter("facturas_venta");
                miAdapter.SelectCommand.Parameters.AddWithValue("", idEstado);
                miAdapter.SelectCommand.Parameters.AddWithValue("", idCaja);
                miAdapter.SelectCommand.Parameters.AddWithValue("", fecha);
                miAdapter.SelectCommand.Parameters.AddWithValue("", fecha2);
                miAdapter.Fill(tabla);
                return tabla;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al consultar las Facturas de Venta.\n" + ex.Message);
            }
        }*/

        public DataTable FacturasDeVenta(int idEstado, DateTime fecha)
        {
            var tabla = new DataTable();
            try
            {
                CargarAdapter("facturas_venta");
                miAdapter.SelectCommand.Parameters.AddWithValue("estado", idEstado);
                miAdapter.SelectCommand.Parameters.AddWithValue("fecha", fecha);
                miAdapter.Fill(tabla);
                return tabla;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al consultar las Facturas de Venta.\n" + ex.Message);
            }
        }

      /*  public DataTable FacturasDeVenta(int idEstado, DateTime fecha, DateTime fecha2)
        {
            var tabla = new DataTable();
            try
            {
                CargarAdapter("facturas_venta_periodo");
                miAdapter.SelectCommand.Parameters.AddWithValue("", idEstado);
                miAdapter.SelectCommand.Parameters.AddWithValue("", fecha);
                miAdapter.SelectCommand.Parameters.AddWithValue("", fecha2);
                miAdapter.Fill(tabla);
                return tabla;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al consultar las Facturas de Venta.\n" + ex.Message);
            }
        }*/



        public DataTable FacturasDeVenta(int idEstado, int idCaja, DateTime fecha, DateTime fecha2)
        {
            var tabla = new DataTable();
            tabla.Columns.Add(new DataColumn("nitcliente", typeof(string)));
            tabla.Columns.Add(new DataColumn("nombrescliente", typeof(string)));
            tabla.Columns.Add(new DataColumn("numero", typeof(string)));
            tabla.Columns.Add(new DataColumn("idusuario", typeof(int)));
            tabla.Columns.Add(new DataColumn("idcaja", typeof(int)));
            tabla.Columns.Add(new DataColumn("idestado", typeof(int)));
            tabla.Columns.Add(new DataColumn("fecha", typeof(DateTime)));
            tabla.Columns.Add(new DataColumn("hora", typeof(DateTime)));
            tabla.Columns.Add(new DataColumn("descto", typeof(bool)));
            tabla.Columns.Add(new DataColumn("estado", typeof(bool)));
            var tConsultas = ConsultaFacturasDeVenta(idEstado, idCaja, fecha, fecha2);
            var tComplemento = ConsultaFacturasDeVentaComplemento(idEstado, idCaja, fecha, fecha2);
            foreach (DataRow cRow in tConsultas.Rows)
            {
                var row = tabla.NewRow();
                row["nitcliente"] = cRow["nitcliente"];
                row["nombrescliente"] = cRow["nombrescliente"];
                row["numero"] = cRow["numero"];
                row["idusuario"] = cRow["idusuario"];
                row["idcaja"] = cRow["idcaja"];
                row["idestado"] = cRow["idestado"];
                row["fecha"] = cRow["fecha"];
                row["hora"] = cRow["hora"];
                row["descto"] = cRow["descto"];
                row["estado"] = cRow["estado"];
                tabla.Rows.Add(row);
            }
            foreach (DataRow cRow in tComplemento.Rows)
            {
                var row = tabla.NewRow();
                row["nitcliente"] = cRow["nitcliente"];
                row["nombrescliente"] = cRow["nombrescliente"];
                row["numero"] = cRow["numero"];
                row["idusuario"] = cRow["idusuario"];
                row["idcaja"] = cRow["idcaja"];
                row["idestado"] = cRow["idestado"];
                row["fecha"] = cRow["fecha"];
                row["hora"] = cRow["hora"];
                row["descto"] = cRow["descto"];
                row["estado"] = cRow["estado"];
                tabla.Rows.Add(row);
            }
            return tabla;
        }

        private DataTable ConsultaFacturasDeVenta(int idEstado, int idCaja, DateTime fecha, DateTime fecha2)
        {
            var tabla = new DataTable();
            try
            {
                CargarAdapter("facturas_venta");
                miAdapter.SelectCommand.Parameters.AddWithValue("estado", idEstado);
                miAdapter.SelectCommand.Parameters.AddWithValue("caja", idCaja);
                miAdapter.SelectCommand.Parameters.AddWithValue("fecha", fecha);
                miAdapter.SelectCommand.Parameters.AddWithValue("fecha2", fecha2);
                miAdapter.SelectCommand.Parameters.AddWithValue("hora", fecha.TimeOfDay);
                miAdapter.Fill(tabla);
                return tabla;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al consultar las Facturas de Venta.\n" + ex.Message);
            }
        }

        private DataTable ConsultaFacturasDeVentaComplemento(int idEstado, int idCaja, DateTime fecha, DateTime fecha2)
        {
            var tabla = new DataTable();
            try
            {
                CargarAdapter("facturas_venta_complemento");
                miAdapter.SelectCommand.Parameters.AddWithValue("estado", idEstado);
                miAdapter.SelectCommand.Parameters.AddWithValue("caja", idCaja);
                miAdapter.SelectCommand.Parameters.AddWithValue("fecha", fecha);
                miAdapter.SelectCommand.Parameters.AddWithValue("fecha2", fecha2);
                miAdapter.SelectCommand.Parameters.AddWithValue("hora", fecha2.TimeOfDay);
                miAdapter.Fill(tabla);
                return tabla;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al consultar las Facturas de Venta.\n" + ex.Message);
            }
        }

        

        public DataTable FacturasDeVentaHoras(int idEstado, int idCaja, DateTime fecha, DateTime fecha2)
        {
            var tabla = new DataTable();
            try
            {
                CargarAdapter("facturas_venta_horas");
                miAdapter.SelectCommand.Parameters.AddWithValue("", idEstado);
                miAdapter.SelectCommand.Parameters.AddWithValue("", idCaja);
                miAdapter.SelectCommand.Parameters.AddWithValue("", fecha);
                miAdapter.SelectCommand.Parameters.AddWithValue("", fecha2);
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

        public DataTable NumeroFacturasTodas(DateTime fecha, DateTime fecha2)
        {
            var tabla = new DataTable();
            try
            {
                this.CargarAdapter("numero_facturas_todas_periodo");
                this.miAdapter.SelectCommand.Parameters.AddWithValue("", fecha);
                this.miAdapter.SelectCommand.Parameters.AddWithValue("", fecha2);
                this.miAdapter.Fill(tabla);
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

        public DataTable NumeroFacturasActivaTodas(int idCaja, DateTime fecha, DateTime fecha2)
        {
            var tabla = new DataTable();
            try
            {
                CargarAdapter("numero_facturas_activas_todas");
                miAdapter.SelectCommand.Parameters.AddWithValue("caja", idCaja);
                miAdapter.SelectCommand.Parameters.AddWithValue("fecha", fecha);
                miAdapter.SelectCommand.Parameters.AddWithValue("fecha2", fecha2);
                miAdapter.Fill(tabla);
                return tabla;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        // RESUMEN DE VENTAS Y UTILIDAD

        // 1. Todas + Fecha
        public DataTable ConsultaFacturasActivas(DateTime fecha, int rowBase, int rowMax)
        {
            this.tFactura.Rows.Clear();
            try
            {
                CargarAdapter("consulta_factura_venta_activa");
                miAdapter.SelectCommand.Parameters.AddWithValue("fecha", fecha);
                miAdapter.Fill(rowBase, rowMax, this.tFactura);
                return this.tFactura;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public long GetRowsConsultaFacturasActivas(DateTime fecha)
        {
            try
            {
                CargarComando("count_consulta_factura_venta_activa");
                miComando.Parameters.AddWithValue("fecha", fecha);
                miConexion.MiConexion.Open();
                var rows = Convert.ToInt64(miComando.ExecuteScalar());
                miConexion.MiConexion.Close();
                miComando.Dispose();
                return rows;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al consultar el conteo.\n" + ex.Message);
            }
            finally { miConexion.MiConexion.Close(); }
        }

        // 2. Todas + Periodo
        public DataTable ConsultaFacturasActivas
                         (DateTime fecha, DateTime fecha2, int rowBase, int rowMax)
        {
            this.tFactura.Rows.Clear();
            try
            {
                CargarAdapter("consulta_factura_venta_activa");
                miAdapter.SelectCommand.Parameters.AddWithValue("fecha", fecha);
                miAdapter.SelectCommand.Parameters.AddWithValue("fecha2", fecha2);
                miAdapter.Fill(rowBase, rowMax, this.tFactura);
                return this.tFactura;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al consultar las facturas.\n" + ex.Message);
            }
        }

        public long GetRowsConsultaFacturasActivas(DateTime fecha, DateTime fecha2)
        {
            try
            {
                CargarComando("count_consulta_factura_venta_activa");
                miComando.Parameters.AddWithValue("fecha", fecha);
                miComando.Parameters.AddWithValue("fecha2", fecha2);
                miConexion.MiConexion.Open();
                var rows = Convert.ToInt64(miComando.ExecuteScalar());
                miConexion.MiConexion.Close();
                miComando.Dispose();
                return rows;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al consultar el conteo.\n" + ex.Message);
            }
            finally { miConexion.MiConexion.Close(); }
        }

        // 3. Todas + Cliente + Fecha
        public DataTable ConsultaFacturasActivas(string cliente, DateTime fecha, int rowBase, int rowMax)
        {
            this.tFactura.Rows.Clear();
            try
            {
                CargarAdapter("consulta_factura_venta_activa_cliente");
                miAdapter.SelectCommand.Parameters.AddWithValue("cliente", cliente);
                miAdapter.SelectCommand.Parameters.AddWithValue("fecha", fecha);
                miAdapter.Fill(rowBase, rowMax, this.tFactura);
                return this.tFactura;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public long GetRowsConsultaFacturasActivas(string cliente, DateTime fecha)
        {
            try
            {
                CargarComando("count_consulta_factura_venta_activa_cliente");
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
                throw new Exception("Ocurrió un error al consultar el conteo.\n" + ex.Message);
            }
            finally { miConexion.MiConexion.Close(); }
        }

        // 4. Todas + Cliente + Periodo
        public DataTable ConsultaFacturasActivas
            (string cliente, DateTime fecha, DateTime fecha2, int rowBase, int rowMax)
        {
            this.tFactura.Rows.Clear();
            try
            {
                CargarAdapter("consulta_factura_venta_activa_cliente");
                miAdapter.SelectCommand.Parameters.AddWithValue("cliente", cliente);
                miAdapter.SelectCommand.Parameters.AddWithValue("fecha", fecha);
                miAdapter.SelectCommand.Parameters.AddWithValue("fecha2", fecha2);
                miAdapter.Fill(rowBase, rowMax, this.tFactura);
                return this.tFactura;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public long GetRowsConsultaFacturasActivas(string cliente, DateTime fecha, DateTime fecha2)
        {
            try
            {
                CargarComando("count_consulta_factura_venta_activa_cliente");
                miComando.Parameters.AddWithValue("cliente", cliente);
                miComando.Parameters.AddWithValue("fecha", fecha);
                miComando.Parameters.AddWithValue("fecha2", fecha2);
                miConexion.MiConexion.Open();
                var rows = Convert.ToInt64(miComando.ExecuteScalar());
                miConexion.MiConexion.Close();
                miComando.Dispose();
                return rows;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al consultar el conteo.\n" + ex.Message);
            }
            finally { miConexion.MiConexion.Close(); }
        }

        // 5. Canceladas + Fecha
        public DataTable ConsultaFacturasContadoActivas(DateTime fecha, int rowBase, int rowMax)
        {
            this.tFactura.Rows.Clear();
            try
            {
                CargarAdapter("consulta_factura_venta_contado_activa");
                miAdapter.SelectCommand.Parameters.AddWithValue("fecha", fecha);
                miAdapter.Fill(rowBase, rowMax, this.tFactura);
                return this.tFactura;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public long GetRowsConsultaFacturasContadoActivas(DateTime fecha)
        {
            try
            {
                CargarComando("count_consulta_factura_venta_contado_activa");
                miComando.Parameters.AddWithValue("fecha", fecha);
                miConexion.MiConexion.Open();
                var rows = Convert.ToInt64(miComando.ExecuteScalar());
                miConexion.MiConexion.Close();
                miComando.Dispose();
                return rows;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al consultar el conteo.\n" + ex.Message);
            }
            finally { miConexion.MiConexion.Close(); }
        }

        // 6. Canceladas + Periodo
        public DataTable ConsultaFacturasContadoActivas
            (DateTime fecha, DateTime fecha2, int rowBase, int rowMax)
        {
            this.tFactura.Rows.Clear();
            try
            {
                CargarAdapter("consulta_factura_venta_contado_activa");
                miAdapter.SelectCommand.Parameters.AddWithValue("fecha", fecha);
                miAdapter.SelectCommand.Parameters.AddWithValue("fecha2", fecha2);
                miAdapter.Fill(rowBase, rowMax, this.tFactura);
                return this.tFactura;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public long GetRowsConsultaFacturasContadoActivas(DateTime fecha, DateTime fecha2)
        {
            try
            {
                CargarComando("count_consulta_factura_venta_contado_activa");
                miComando.Parameters.AddWithValue("fecha", fecha);
                miComando.Parameters.AddWithValue("fecha2", fecha2);
                miConexion.MiConexion.Open();
                var rows = Convert.ToInt64(miComando.ExecuteScalar());
                miConexion.MiConexion.Close();
                miComando.Dispose();
                return rows;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al consultar el conteo.\n" + ex.Message);
            }
            finally { miConexion.MiConexion.Close(); }
        }

        // 7. Cancelada + Cliente + Fecha
        public DataTable ConsultaFacturasContadoActivas(string cliente, DateTime fecha, int rowBase, int rowMax)
        {
            this.tFactura.Rows.Clear();
            try
            {
                CargarAdapter("consulta_factura_venta_contado_activa_cliente");
                miAdapter.SelectCommand.Parameters.AddWithValue("cliente", cliente);
                miAdapter.SelectCommand.Parameters.AddWithValue("fecha", fecha);
                miAdapter.Fill(rowBase, rowMax, this.tFactura);
                return this.tFactura;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public long GetRowsConsultaFacturasContadoActivas(string cliente, DateTime fecha)
        {
            try
            {
                CargarComando("count_consulta_factura_venta_contado_activa_cliente");
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
                throw new Exception("Ocurrió un error al consultar el conteo.\n" + ex.Message);
            }
            finally { miConexion.MiConexion.Close(); }
        }

        // 8. Cancelada + Cliente + Periodo
        public DataTable ConsultaFacturasContadoActivas
            (string cliente, DateTime fecha, DateTime fecha2, int rowBase, int rowMax)
        {
            this.tFactura.Rows.Clear();
            try
            {
                CargarAdapter("consulta_factura_venta_contado_activa_cliente");
                miAdapter.SelectCommand.Parameters.AddWithValue("cliente", cliente);
                miAdapter.SelectCommand.Parameters.AddWithValue("fecha", fecha);
                miAdapter.SelectCommand.Parameters.AddWithValue("fecha2", fecha2);
                miAdapter.Fill(rowBase, rowMax, this.tFactura);
                return this.tFactura;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public long GetRowsConsultaFacturasContadoActivas(string cliente, DateTime fecha, DateTime fecha2)
        {
            try
            {
                CargarComando("count_consulta_factura_venta_contado_activa_cliente");
                miComando.Parameters.AddWithValue("cliente", cliente);
                miComando.Parameters.AddWithValue("fecha", fecha);
                miComando.Parameters.AddWithValue("fecha2", fecha2);
                miConexion.MiConexion.Open();
                var rows = Convert.ToInt64(miComando.ExecuteScalar());
                miConexion.MiConexion.Close();
                miComando.Dispose();
                return rows;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al consultar el conteo.\n" + ex.Message);
            }
            finally { miConexion.MiConexion.Close(); }
        }

        // 9. Crédito + Fecha
        public DataTable ConsultaFacturasCreditoActivas(DateTime fecha, int rowBase, int rowMax)
        {
            this.tFactura.Rows.Clear();
            try
            {
                CargarAdapter("consulta_factura_venta_credito_activa");
                miAdapter.SelectCommand.Parameters.AddWithValue("fecha", fecha);
                miAdapter.Fill(rowBase, rowMax, this.tFactura);
                return this.tFactura;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public long GetRowsConsultaFacturasCreditoActivas(DateTime fecha)
        {
            try
            {
                CargarComando("count_consulta_factura_venta_credito_activa");
                miComando.Parameters.AddWithValue("fecha", fecha);
                miConexion.MiConexion.Open();
                var rows = Convert.ToInt64(miComando.ExecuteScalar());
                miConexion.MiConexion.Close();
                miComando.Dispose();
                return rows;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al consultar el conteo.\n" + ex.Message);
            }
            finally { miConexion.MiConexion.Close(); }
        }

        // 10. Crédito + Periodo
        public DataTable ConsultaFacturasCreditoActivas
            (DateTime fecha, DateTime fecha2, int rowBase, int rowMax)
        {
            this.tFactura.Rows.Clear();
            try
            {
                CargarAdapter("consulta_factura_venta_credito_activa");
                miAdapter.SelectCommand.Parameters.AddWithValue("fecha", fecha);
                miAdapter.SelectCommand.Parameters.AddWithValue("fecha2", fecha2);
                miAdapter.Fill(rowBase, rowMax, this.tFactura);
                return this.tFactura;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public long GetRowsConsultaFacturasCreditoActivas(DateTime fecha, DateTime fecha2)
        {
            try
            {
                CargarComando("count_consulta_factura_venta_credito_activa");
                miComando.Parameters.AddWithValue("fecha", fecha);
                miComando.Parameters.AddWithValue("fecha2", fecha2);
                miConexion.MiConexion.Open();
                var rows = Convert.ToInt64(miComando.ExecuteScalar());
                miConexion.MiConexion.Close();
                miComando.Dispose();
                return rows;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al consultar el conteo.\n" + ex.Message);
            }
            finally { miConexion.MiConexion.Close(); }
        }

        // 11. Crédito + Cliente + Fecha
        public DataTable ConsultaFacturasCreditoActivas(string cliente, DateTime fecha, int rowBase, int rowMax)
        {
            this.tFactura.Rows.Clear();
            try
            {
                CargarAdapter("consulta_factura_venta_credito_activa_cliente");
                miAdapter.SelectCommand.Parameters.AddWithValue("cliente", cliente);
                miAdapter.SelectCommand.Parameters.AddWithValue("fecha", fecha);
                miAdapter.Fill(rowBase, rowMax, this.tFactura);
                return this.tFactura;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public long GetRowsConsultaFacturasCreditoActivas(string cliente, DateTime fecha)
        {
            try
            {
                CargarComando("count_consulta_factura_venta_credito_activa_cliente");
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
                throw new Exception("Ocurrió un error al consultar el conteo.\n" + ex.Message);
            }
            finally { miConexion.MiConexion.Close(); }
        }

        // 12. Crédito + Cliente + Periodo
        public DataTable ConsultaFacturasCreditoActivas
            (string cliente, DateTime fecha, DateTime fecha2, int rowBase, int rowMax)
        {
            this.tFactura.Rows.Clear();
            try
            {
                CargarAdapter("consulta_factura_venta_credito_activa_cliente");
                miAdapter.SelectCommand.Parameters.AddWithValue("cliente", cliente);
                miAdapter.SelectCommand.Parameters.AddWithValue("fecha", fecha);
                miAdapter.SelectCommand.Parameters.AddWithValue("fecha2", fecha2);
                miAdapter.Fill(rowBase, rowMax, this.tFactura);
                return this.tFactura;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public long GetRowsConsultaFacturasCreditoActivas(string cliente, DateTime fecha, DateTime fecha2)
        {
            try
            {
                CargarComando("count_consulta_factura_venta_credito_activa_cliente");
                miComando.Parameters.AddWithValue("cliente", cliente);
                miComando.Parameters.AddWithValue("fecha", fecha);
                miComando.Parameters.AddWithValue("fecha2", fecha2);
                miConexion.MiConexion.Open();
                var rows = Convert.ToInt64(miComando.ExecuteScalar());
                miConexion.MiConexion.Close();
                miComando.Dispose();
                return rows;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al consultar el conteo.\n" + ex.Message);
            }
            finally { miConexion.MiConexion.Close(); }
        }

        // 13. Anulada + Fecha
        public DataTable ConsultaFacturasAnuladas(DateTime fecha, int rowBase, int rowMax)
        {
            this.tFactura.Rows.Clear();
            try
            {
                CargarAdapter("consulta_factura_venta_anulada");
                miAdapter.SelectCommand.Parameters.AddWithValue("fecha", fecha);
                miAdapter.Fill(rowBase, rowMax, this.tFactura);
                return this.tFactura;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public long GetRowsConsultaFacturasAnuladas(DateTime fecha)
        {
            try
            {
                CargarComando("count_consulta_factura_venta_anulada");
                miComando.Parameters.AddWithValue("fecha", fecha);
                miConexion.MiConexion.Open();
                var rows = Convert.ToInt64(miComando.ExecuteScalar());
                miConexion.MiConexion.Close();
                miComando.Dispose();
                return rows;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al consultar el conteo.\n" + ex.Message);
            }
            finally { miConexion.MiConexion.Close(); }
        }

        // 14. Anulada + Periodo
        public DataTable ConsultaFacturasAnuladas(DateTime fecha, DateTime fecha2, int rowBase, int rowMax)
        {
            this.tFactura.Rows.Clear();
            try
            {
                CargarAdapter("consulta_factura_venta_anulada");
                miAdapter.SelectCommand.Parameters.AddWithValue("fecha", fecha);
                miAdapter.SelectCommand.Parameters.AddWithValue("fecha2", fecha2);
                miAdapter.Fill(rowBase, rowMax, this.tFactura);
                return this.tFactura;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public long GetRowsConsultaFacturasAnuladas(DateTime fecha, DateTime fecha2)
        {
            try
            {
                CargarComando("count_consulta_factura_venta_anulada");
                miComando.Parameters.AddWithValue("fecha", fecha);
                miComando.Parameters.AddWithValue("fecha2", fecha2);
                miConexion.MiConexion.Open();
                var rows = Convert.ToInt64(miComando.ExecuteScalar());
                miConexion.MiConexion.Close();
                miComando.Dispose();
                return rows;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al consultar el conteo.\n" + ex.Message);
            }
            finally { miConexion.MiConexion.Close(); }
        }

        // 15. Anulada + Cliente + Fecha
        public DataTable ConsultaFacturasAnuladas
            (string cliente, DateTime fecha, int rowBase, int rowMax)
        {
            this.tFactura.Rows.Clear();
            try
            {
                CargarAdapter("consulta_factura_venta_anulada_cliente");
                miAdapter.SelectCommand.Parameters.AddWithValue("cliente", cliente);
                miAdapter.SelectCommand.Parameters.AddWithValue("fecha", fecha);
                miAdapter.Fill(rowBase, rowMax, this.tFactura);
                return this.tFactura;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public long GetRowsConsultaFacturasAnuladas(string cliente, DateTime fecha)
        {
            try
            {
                CargarComando("count_consulta_factura_venta_anulada_cliente");
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
                throw new Exception("Ocurrió un error al consultar el conteo.\n" + ex.Message);
            }
            finally { miConexion.MiConexion.Close(); }
        }


        // 16. Anulada + Cliente + Periodo
        public DataTable ConsultaFacturasAnuladas
            (string cliente, DateTime fecha, DateTime fecha2, int rowBase, int rowMax)
        {
            this.tFactura.Rows.Clear();
            try
            {
                CargarAdapter("consulta_factura_venta_anulada_cliente");
                miAdapter.SelectCommand.Parameters.AddWithValue("cliente", cliente);
                miAdapter.SelectCommand.Parameters.AddWithValue("fecha", fecha);
                miAdapter.SelectCommand.Parameters.AddWithValue("fecha2", fecha2);
                miAdapter.Fill(rowBase, rowMax, this.tFactura);
                return this.tFactura;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public long GetRowsConsultaFacturasAnuladas(string cliente, DateTime fecha, DateTime fecha2)
        {
            try
            {
                CargarComando("count_consulta_factura_venta_anulada_cliente");
                miComando.Parameters.AddWithValue("cliente", cliente);
                miComando.Parameters.AddWithValue("fecha", fecha);
                miComando.Parameters.AddWithValue("fecha2", fecha2);
                miConexion.MiConexion.Open();
                var rows = Convert.ToInt64(miComando.ExecuteScalar());
                miConexion.MiConexion.Close();
                miComando.Dispose();
                return rows;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al consultar el conteo.\n" + ex.Message);
            }
            finally { miConexion.MiConexion.Close(); }
        }


        // Funciones de consulta con usuario

        public DataTable ConsultaFacturasActivas(int idUsuario, DateTime fecha, int rowBase, int rowMax)
        {
            this.tFactura.Rows.Clear();
            try
            {
                CargarAdapter("consulta_factura_venta_activa_usuario");
                miAdapter.SelectCommand.Parameters.AddWithValue("", idUsuario);
                miAdapter.SelectCommand.Parameters.AddWithValue("", fecha);
                miAdapter.Fill(rowBase, rowMax, this.tFactura);
                return this.tFactura;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public long GetRowsConsultaFacturasActivas(int idUsuario, DateTime fecha)
        {
            try
            {
                CargarComando("count_consulta_factura_venta_activa_usuario");
                miComando.Parameters.AddWithValue("", idUsuario);
                miComando.Parameters.AddWithValue("", fecha);
                miConexion.MiConexion.Open();
                var rows = Convert.ToInt64(miComando.ExecuteScalar());
                miConexion.MiConexion.Close();
                miComando.Dispose();
                return rows;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al consultar el conteo.\n" + ex.Message);
            }
            finally { miConexion.MiConexion.Close(); }
        }

        public DataTable ConsultaFacturasActivas(int idUsuario, DateTime fecha, DateTime fecha2, int rowBase, int rowMax)
        {
            this.tFactura.Rows.Clear();
            try
            {
                CargarAdapter("consulta_factura_venta_activa_usuario");
                miAdapter.SelectCommand.Parameters.AddWithValue("", idUsuario);
                miAdapter.SelectCommand.Parameters.AddWithValue("", fecha);
                miAdapter.SelectCommand.Parameters.AddWithValue("", fecha2);
                miAdapter.Fill(rowBase, rowMax, this.tFactura);
                return this.tFactura;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public long GetRowsConsultaFacturasActivas(int idUsuario, DateTime fecha, DateTime fecha2)
        {
            try
            {
                CargarComando("count_consulta_factura_venta_activa_usuario");
                miComando.Parameters.AddWithValue("", idUsuario);
                miComando.Parameters.AddWithValue("", fecha);
                miComando.Parameters.AddWithValue("", fecha2);
                miConexion.MiConexion.Open();
                var rows = Convert.ToInt64(miComando.ExecuteScalar());
                miConexion.MiConexion.Close();
                miComando.Dispose();
                return rows;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al consultar el conteo.\n" + ex.Message);
            }
            finally { miConexion.MiConexion.Close(); }
        }


        public DataTable ConsultaFacturasContadoActivas(int idUsuario, DateTime fecha, int rowBase, int rowMax)
        {
            this.tFactura.Rows.Clear();
            try
            {
                CargarAdapter("consulta_factura_venta_contado_activa_usuario");
                miAdapter.SelectCommand.Parameters.AddWithValue("", idUsuario);
                miAdapter.SelectCommand.Parameters.AddWithValue("", fecha);
                miAdapter.Fill(rowBase, rowMax, this.tFactura);
                return this.tFactura;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public long GetRowsConsultaFacturasContadoActivas(int idUsuario, DateTime fecha)
        {
            try
            {
                CargarComando("count_consulta_factura_venta_contado_activa_usuario");
                miComando.Parameters.AddWithValue("", idUsuario);
                miComando.Parameters.AddWithValue("", fecha);
                miConexion.MiConexion.Open();
                var rows = Convert.ToInt64(miComando.ExecuteScalar());
                miConexion.MiConexion.Close();
                miComando.Dispose();
                return rows;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al consultar el conteo.\n" + ex.Message);
            }
            finally { miConexion.MiConexion.Close(); }
        }

        public DataTable ConsultaFacturasContadoActivas(int idUsuario, DateTime fecha, DateTime fecha2, int rowBase, int rowMax)
        {
            this.tFactura.Rows.Clear();
            try
            {
                CargarAdapter("consulta_factura_venta_contado_activa_usuario");
                miAdapter.SelectCommand.Parameters.AddWithValue("", idUsuario);
                miAdapter.SelectCommand.Parameters.AddWithValue("", fecha);
                miAdapter.SelectCommand.Parameters.AddWithValue("", fecha2);
                miAdapter.Fill(rowBase, rowMax, this.tFactura);
                return this.tFactura;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public long GetRowsConsultaFacturasContadoActivas(int idUsuario, DateTime fecha, DateTime fecha2)
        {
            try
            {
                CargarComando("count_consulta_factura_venta_contado_activa_usuario");
                miComando.Parameters.AddWithValue("", idUsuario);
                miComando.Parameters.AddWithValue("", fecha);
                miComando.Parameters.AddWithValue("", fecha2);
                miConexion.MiConexion.Open();
                var rows = Convert.ToInt64(miComando.ExecuteScalar());
                miConexion.MiConexion.Close();
                miComando.Dispose();
                return rows;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al consultar el conteo.\n" + ex.Message);
            }
            finally { miConexion.MiConexion.Close(); }
        }


        public DataTable ConsultaFacturasCreditoActivas(int idUsuario, DateTime fecha, int rowBase, int rowMax)
        {
            this.tFactura.Rows.Clear();
            try
            {
                CargarAdapter("consulta_factura_venta_credito_activa_usuario");
                miAdapter.SelectCommand.Parameters.AddWithValue("", idUsuario);
                miAdapter.SelectCommand.Parameters.AddWithValue("", fecha);
                miAdapter.Fill(rowBase, rowMax, this.tFactura);
                return this.tFactura;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public long GetRowsConsultaFacturasCreditoActivas(int idUsuario, DateTime fecha)
        {
            try
            {
                CargarComando("count_consulta_factura_venta_credito_activa_usuario");
                miComando.Parameters.AddWithValue("", idUsuario);
                miComando.Parameters.AddWithValue("", fecha);
                miConexion.MiConexion.Open();
                var rows = Convert.ToInt64(miComando.ExecuteScalar());
                miConexion.MiConexion.Close();
                miComando.Dispose();
                return rows;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al consultar el conteo.\n" + ex.Message);
            }
            finally { miConexion.MiConexion.Close(); }
        }

        public DataTable ConsultaFacturasCreditoActivas(int idUsuario, DateTime fecha, DateTime fecha2, int rowBase, int rowMax)
        {
            this.tFactura.Rows.Clear();
            try
            {
                CargarAdapter("consulta_factura_venta_credito_activa_usuario");
                miAdapter.SelectCommand.Parameters.AddWithValue("", idUsuario);
                miAdapter.SelectCommand.Parameters.AddWithValue("", fecha);
                miAdapter.SelectCommand.Parameters.AddWithValue("", fecha2);
                miAdapter.Fill(rowBase, rowMax, this.tFactura);
                return this.tFactura;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public long GetRowsConsultaFacturasCreditoActivas(int idUsuario, DateTime fecha, DateTime fecha2)
        {
            try
            {
                CargarComando("count_consulta_factura_venta_credito_activa_usuario");
                miComando.Parameters.AddWithValue("", idUsuario);
                miComando.Parameters.AddWithValue("", fecha);
                miComando.Parameters.AddWithValue("", fecha2);
                miConexion.MiConexion.Open();
                var rows = Convert.ToInt64(miComando.ExecuteScalar());
                miConexion.MiConexion.Close();
                miComando.Dispose();
                return rows;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al consultar el conteo.\n" + ex.Message);
            }
            finally { miConexion.MiConexion.Close(); }
        }


        public DataTable ConsultaFacturasAnuladas(int idUsuario, DateTime fecha, int rowBase, int rowMax)
        {
            this.tFactura.Rows.Clear();
            try
            {
                CargarAdapter("consulta_factura_venta_anulada_usuario");
                miAdapter.SelectCommand.Parameters.AddWithValue("", idUsuario);
                miAdapter.SelectCommand.Parameters.AddWithValue("", fecha);
                miAdapter.Fill(rowBase, rowMax, this.tFactura);
                return this.tFactura;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public long GetRowsConsultaFacturasAnuladas(int idUsuario, DateTime fecha)
        {
            try
            {
                CargarComando("count_consulta_factura_venta_anulada_usuario");
                miComando.Parameters.AddWithValue("", idUsuario);
                miComando.Parameters.AddWithValue("", fecha);
                miConexion.MiConexion.Open();
                var rows = Convert.ToInt64(miComando.ExecuteScalar());
                miConexion.MiConexion.Close();
                miComando.Dispose();
                return rows;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al consultar el conteo.\n" + ex.Message);
            }
            finally { miConexion.MiConexion.Close(); }
        }

        public DataTable ConsultaFacturasAnuladas(int idUsuario, DateTime fecha, DateTime fecha2, int rowBase, int rowMax)
        {
            this.tFactura.Rows.Clear();
            try
            {
                CargarAdapter("consulta_factura_venta_anulada_usuario");
                miAdapter.SelectCommand.Parameters.AddWithValue("", idUsuario);
                miAdapter.SelectCommand.Parameters.AddWithValue("", fecha);
                miAdapter.SelectCommand.Parameters.AddWithValue("", fecha2);
                miAdapter.Fill(rowBase, rowMax, this.tFactura);
                return this.tFactura;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public long GetRowsConsultaFacturasAnuladas(int idUsuario, DateTime fecha, DateTime fecha2)
        {
            try
            {
                CargarComando("count_consulta_factura_venta_anulada_usuario");
                miComando.Parameters.AddWithValue("", idUsuario);
                miComando.Parameters.AddWithValue("", fecha);
                miComando.Parameters.AddWithValue("", fecha2);
                miConexion.MiConexion.Open();
                var rows = Convert.ToInt64(miComando.ExecuteScalar());
                miConexion.MiConexion.Close();
                miComando.Dispose();
                return rows;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al consultar el conteo.\n" + ex.Message);
            }
            finally { miConexion.MiConexion.Close(); }
        }




        // FUNCIONES PARA IMPRESION DEL INFORME.

        // 1. Todas + Fecha
        public DataTable ConsultaFacturasActivas(DateTime fecha)
        {
            this.tFactura.Rows.Clear();
            try
            {
                CargarAdapter("consulta_factura_venta_activa");
                miAdapter.Fill(this.tFactura);
                return this.tFactura;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        // 2. Todas + Periodo
        public DataTable ConsultaFacturasActivas(DateTime fecha, DateTime fecha2)
        {
            this.tFactura.Rows.Clear();
            try
            {
                CargarAdapter("consulta_factura_venta_activa");
                miAdapter.SelectCommand.Parameters.AddWithValue("fecha", fecha);
                miAdapter.SelectCommand.Parameters.AddWithValue("fecha2", fecha2);
                miAdapter.Fill(this.tFactura);
                return this.tFactura;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al consultar las facturas.\n" + ex.Message);
            }
        }

        // 3. Todas + Cliente + Fecha
        public DataTable ConsultaFacturasActivas(string cliente, DateTime fecha)
        {
            this.tFactura.Rows.Clear();
            try
            {
                CargarAdapter("consulta_factura_venta_activa_cliente");
                miAdapter.SelectCommand.Parameters.AddWithValue("cliente", cliente);
                miAdapter.SelectCommand.Parameters.AddWithValue("fecha", fecha);
                miAdapter.Fill(this.tFactura);
                return this.tFactura;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        // 4. Todas + Cliente + Periodo
        public DataTable ConsultaFacturasActivas(string cliente, DateTime fecha, DateTime fecha2)
        {
            this.tFactura.Rows.Clear();
            try
            {
                CargarAdapter("consulta_factura_venta_activa_cliente");
                miAdapter.SelectCommand.Parameters.AddWithValue("cliente", cliente);
                miAdapter.SelectCommand.Parameters.AddWithValue("fecha", fecha);
                miAdapter.SelectCommand.Parameters.AddWithValue("fecha2", fecha2);
                miAdapter.Fill(this.tFactura);
                return this.tFactura;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        // 5. Canceladas + Fecha
        public DataTable ConsultaFacturasContadoActivas(DateTime fecha)
        {
	        this.tFactura.Rows.Clear();
	        try
	        {
		        CargarAdapter("consulta_factura_venta_contado_activa");
		        miAdapter.SelectCommand.Parameters.AddWithValue("fecha", fecha);
		        miAdapter.Fill(this.tFactura);
		        return this.tFactura;
	        }
	        catch (Exception ex)
	        {
		        throw new Exception(ex.Message);
	        }
        }

        // 6. Canceladas + Periodo
        public DataTable ConsultaFacturasContadoActivas(DateTime fecha, DateTime fecha2)
        {
            this.tFactura.Rows.Clear();
            try
            {
                CargarAdapter("consulta_factura_venta_contado_activa");
                miAdapter.SelectCommand.Parameters.AddWithValue("fecha", fecha);
                miAdapter.SelectCommand.Parameters.AddWithValue("fecha2", fecha2);
                miAdapter.Fill(this.tFactura);
                return this.tFactura;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        // 7. Cancelada + Cliente + Fecha
        public DataTable ConsultaFacturasContadoActivas(string cliente, DateTime fecha)
        {
            this.tFactura.Rows.Clear();
            try
            {
                CargarAdapter("consulta_factura_venta_contado_activa_cliente");
                miAdapter.SelectCommand.Parameters.AddWithValue("cliente", cliente);
                miAdapter.SelectCommand.Parameters.AddWithValue("fecha", fecha);
                miAdapter.Fill(this.tFactura);
                return this.tFactura;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        // 8. Cancelada + Cliente + Periodo
        public DataTable ConsultaFacturasContadoActivas(string cliente, DateTime fecha, DateTime fecha2)
        {
            this.tFactura.Rows.Clear();
            try
            {
                CargarAdapter("consulta_factura_venta_contado_activa_cliente");
                miAdapter.SelectCommand.Parameters.AddWithValue("cliente", cliente);
                miAdapter.SelectCommand.Parameters.AddWithValue("fecha", fecha);
                miAdapter.SelectCommand.Parameters.AddWithValue("fecha2", fecha2);
                miAdapter.Fill(this.tFactura);
                return this.tFactura;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        // 9. Crédito + Fecha
        public DataTable ConsultaFacturasCreditoActivas(DateTime fecha)
        {
            this.tFactura.Rows.Clear();
            try
            {
                CargarAdapter("consulta_factura_venta_credito_activa");
                miAdapter.SelectCommand.Parameters.AddWithValue("fecha", fecha);
                miAdapter.Fill(this.tFactura);
                return this.tFactura;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        // 10. Crédito + Periodo
        public DataTable ConsultaFacturasCreditoActivas(DateTime fecha, DateTime fecha2)
        {
	        this.tFactura.Rows.Clear();
	        try
	        {
		        CargarAdapter("consulta_factura_venta_credito_activa");
		        miAdapter.SelectCommand.Parameters.AddWithValue("fecha", fecha);
		        miAdapter.SelectCommand.Parameters.AddWithValue("fecha2", fecha2);
		        miAdapter.Fill(this.tFactura);
		        return this.tFactura;
	        }
	        catch (Exception ex)
	        {
		        throw new Exception(ex.Message);
	        }
        }

        // 11. Crédito + Cliente + Fecha
        public DataTable ConsultaFacturasCreditoActivas(string cliente, DateTime fecha)
        {
            this.tFactura.Rows.Clear();
            try
            {
                CargarAdapter("consulta_factura_venta_credito_activa_cliente");
                miAdapter.SelectCommand.Parameters.AddWithValue("cliente", cliente);
                miAdapter.SelectCommand.Parameters.AddWithValue("fecha", fecha);
                miAdapter.Fill(this.tFactura);
                return this.tFactura;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        // 12. Crédito + Cliente + Periodo
        public DataTable ConsultaFacturasCreditoActivas(string cliente, DateTime fecha, DateTime fecha2)
        {
            this.tFactura.Rows.Clear();
            try
            {
                CargarAdapter("consulta_factura_venta_credito_activa_cliente");
                miAdapter.SelectCommand.Parameters.AddWithValue("cliente", cliente);
                miAdapter.SelectCommand.Parameters.AddWithValue("fecha", fecha);
                miAdapter.SelectCommand.Parameters.AddWithValue("fecha2", fecha2);
                miAdapter.Fill(this.tFactura);
                return this.tFactura;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        // 13. Anulada + Fecha
        public DataTable ConsultaFacturasAnuladas(DateTime fecha)
        {
            this.tFactura.Rows.Clear();
            try
            {
                CargarAdapter("consulta_factura_venta_anulada");
                miAdapter.SelectCommand.Parameters.AddWithValue("fecha", fecha);
                miAdapter.Fill(this.tFactura);
                return this.tFactura;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        // 14. Anulada + Periodo
        public DataTable ConsultaFacturasAnuladas(DateTime fecha, DateTime fecha2)
        {
            this.tFactura.Rows.Clear();
            try
            {
                CargarAdapter("consulta_factura_venta_anulada");
                miAdapter.SelectCommand.Parameters.AddWithValue("fecha", fecha);
                miAdapter.SelectCommand.Parameters.AddWithValue("fecha2", fecha2);
                miAdapter.Fill(this.tFactura);
                return this.tFactura;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        // 15. Anulada + Cliente + Fecha
        public DataTable ConsultaFacturasAnuladas(string cliente, DateTime fecha)
        {
            this.tFactura.Rows.Clear();
            try
            {
                CargarAdapter("consulta_factura_venta_anulada_cliente");
                miAdapter.SelectCommand.Parameters.AddWithValue("cliente", cliente);
                miAdapter.SelectCommand.Parameters.AddWithValue("fecha", fecha);
                miAdapter.Fill(this.tFactura);
                return this.tFactura;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        // 16. Anulada + Cliente + Periodo
        public DataTable ConsultaFacturasAnuladas(string cliente, DateTime fecha, DateTime fecha2)
        {
            this.tFactura.Rows.Clear();
            try
            {
                CargarAdapter("consulta_factura_venta_anulada_cliente");
                miAdapter.SelectCommand.Parameters.AddWithValue("cliente", cliente);
                miAdapter.SelectCommand.Parameters.AddWithValue("fecha", fecha);
                miAdapter.SelectCommand.Parameters.AddWithValue("fecha2", fecha2);
                miAdapter.Fill(this.tFactura);
                return this.tFactura;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }




        // Resumen Tributario de ventas

        // 1.
        public DataTable ResumenDeVentas(DateTime fecha)
        {
            try
            {
                CargarAdapter("consulta_factura_venta_activa");
                miAdapter.SelectCommand.Parameters.AddWithValue("fecha", fecha);
                miAdapter.Fill(tFacturas);
                return CalculoDeVentas(tFacturas);

                /*foreach (DataRow fRow in tFacturas.Rows) // itera las facturas
                {
                    var tProductos = ProductoFacturaVenta(fRow["numero"].ToString(), true);
                    foreach (DataRow pRow in tProductos.Rows) // itera los productos
                    { 
                        //  calculo de ventas
                        var row = tVenta.NewRow();
                        row["Total"] = pRow["Valor"];
                        row["Base"] = Convert.ToInt32(Convert.ToInt32(pRow["Valor"]) /
                            (1 + (UseObject.RemoveCharacter(pRow["Iva"].ToString(), '%') / 100)));
                        row["Iva"] = Convert.ToInt32(row["Total"]) - Convert.ToInt32(row["Base"]);

                        var pcRow = ProductoCosto(pRow["Codigo"].ToString()).AsEnumerable().First();
                        row["IvaC"] = Convert.ToInt32(Convert.ToDouble(pcRow["costo"]) * Convert.ToDouble(pcRow["iva"]) / 100);
                        row["TotalC"] = Convert.ToInt32((Convert.ToDouble(pcRow["costo"]) + Convert.ToInt32(row["IvaC"])) *
                            Convert.ToDouble(pRow["Cantidad"]));
                        row["IvaC"] = Convert.ToInt32(Convert.ToInt32(row["IvaC"]) * Convert.ToDouble(pRow["Cantidad"]));

                        tVenta.Rows.Add(row);
                    }
                }
                tFacturas.Rows.Clear();
                return tVenta;*/
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public DataTable ResumenDeVentas2(DateTime fecha)
        {
            try
            {
                this.tVenta.Rows.Clear();
                var tabla = new DataTable();
                CargarAdapter("resumen_ventas");
                miAdapter.SelectCommand.Parameters.AddWithValue("", fecha);
                miAdapter.Fill(tabla);
                if (tabla.Rows.Count > 0)
                {
                    double costo = tabla.AsEnumerable().Sum(s => s.Field<double>("costo"));
                    double base_costo = tabla.AsEnumerable().Sum(s => s.Field<double>("base_costo"));
                    double base_ = tabla.AsEnumerable().Sum(s => s.Field<double>("base"));
                    double total = tabla.AsEnumerable().Sum(s => s.Field<double>("total"));
                    var row = this.tVenta.NewRow();
                    row["Base"] = base_;
                    row["Iva"] = total - base_;
                    row["Total"] = total;
                    row["IvaC"] = Convert.ToInt32(costo - base_costo);
                    row["TotalC"] = Convert.ToInt32(costo);
                    this.tVenta.Rows.Add(row);
                }
                return this.tVenta;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al consultar el resumen de ventas.\n" + ex.Message);
            }
        }

        // 2.
        public DataTable ResumenDeVentas(DateTime fecha, DateTime fecha2)
        {
            try
            {
                CargarAdapter("consulta_factura_venta_activa");
                miAdapter.SelectCommand.Parameters.AddWithValue("fecha", fecha);
                miAdapter.SelectCommand.Parameters.AddWithValue("fecha2", fecha2);
                miAdapter.Fill(tFacturas);
                return CalculoDeVentas(tFacturas);
                /*foreach (DataRow fRow in tFacturas.Rows)
                {
                    var tProductos = ProductoFacturaVenta(fRow["numero"].ToString(), true);
                    foreach (DataRow pRow in tProductos.Rows)
                    {
                        var row = tVenta.NewRow();
                        row["Total"] = pRow["Valor"];
                        row["Base"] = Convert.ToInt32(Convert.ToInt32(pRow["Valor"]) /
                            (1 + (UseObject.RemoveCharacter(pRow["Iva"].ToString(), '%') / 100)));
                        row["Iva"] = Convert.ToInt32(row["Total"]) - Convert.ToInt32(row["Base"]);

                        var pcRow = ProductoCosto(pRow["Codigo"].ToString()).AsEnumerable().First();
                        row["IvaC"] = Convert.ToInt32(Convert.ToDouble(pcRow["costo"]) * Convert.ToDouble(pcRow["iva"]) / 100);
                        row["TotalC"] = Convert.ToInt32((Convert.ToDouble(pcRow["costo"]) + Convert.ToInt32(row["IvaC"])) *
                            Convert.ToDouble(pRow["Cantidad"]));
                        row["IvaC"] = Convert.ToInt32(Convert.ToInt32(row["IvaC"]) * Convert.ToDouble(pRow["Cantidad"]));

                        tVenta.Rows.Add(row);
                    }
                }
                tFacturas.Rows.Clear();
                return tVenta;*/
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public DataTable ResumenDeVentas2(DateTime fecha, DateTime fecha2)
        {
            try
            {
                this.tVenta.Rows.Clear();
                var tabla = new DataTable();
                CargarAdapter("resumen_ventas");
                miAdapter.SelectCommand.Parameters.AddWithValue("", fecha);
                miAdapter.SelectCommand.Parameters.AddWithValue("", fecha2);
                miAdapter.Fill(tabla);
                if (tabla.Rows.Count > 0)
                {
                    double costo = tabla.AsEnumerable().Sum(s => s.Field<double>("costo"));
                    double base_costo = tabla.AsEnumerable().Sum(s => s.Field<double>("base_costo"));
                    double base_ = tabla.AsEnumerable().Sum(s => s.Field<double>("base"));
                    double total = tabla.AsEnumerable().Sum(s => s.Field<double>("total"));
                    var row = this.tVenta.NewRow();
                    row["Base"] = base_;
                    row["Iva"] = total - base_;
                    row["Total"] = total;
                    row["IvaC"] = Convert.ToInt32(costo - base_costo);
                    row["TotalC"] = Convert.ToInt64(costo); // rev: Convert.ToInt64
                    this.tVenta.Rows.Add(row);
                }
                return this.tVenta;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al consultar el resumen de ventas.\n" + ex.Message);
            }
        }

        // 3
        public DataTable ResumenDeVentas(string cliente, DateTime fecha)
        {
            try
            {
                CargarAdapter("consulta_factura_venta_activa_cliente");
                miAdapter.SelectCommand.Parameters.AddWithValue("cliente", cliente);
                miAdapter.SelectCommand.Parameters.AddWithValue("fecha", fecha);
                miAdapter.Fill(tFacturas);
                return CalculoDeVentas(tFacturas);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public DataTable ResumenDeVentas2(string nit, DateTime fecha)
        {
            try
            {
                this.tVenta.Rows.Clear();
                var tabla = new DataTable();
                CargarAdapter("resumen_ventas_cliente");
                miAdapter.SelectCommand.Parameters.AddWithValue("", nit);
                miAdapter.SelectCommand.Parameters.AddWithValue("", fecha);
                miAdapter.Fill(tabla);
                if (tabla.Rows.Count > 0)
                {
                    double costo = tabla.AsEnumerable().Sum(s => s.Field<double>("costo"));
                    double base_costo = tabla.AsEnumerable().Sum(s => s.Field<double>("base_costo"));
                    double base_ = tabla.AsEnumerable().Sum(s => s.Field<double>("base"));
                    double total = tabla.AsEnumerable().Sum(s => s.Field<double>("total"));
                    var row = this.tVenta.NewRow();
                    row["Base"] = base_;
                    row["Iva"] = total - base_;
                    row["Total"] = total;
                    row["IvaC"] = Convert.ToInt32(costo - base_costo);
                    row["TotalC"] = Convert.ToInt32(costo);
                    this.tVenta.Rows.Add(row);
                }
                return this.tVenta;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al consultar el resumen de ventas.\n" + ex.Message);
            }
        }

        // 4
        public DataTable ResumenDeVentas(string cliente, DateTime fecha, DateTime fecha2)
        {
            try
            {
                CargarAdapter("consulta_factura_venta_activa_cliente");
                miAdapter.SelectCommand.Parameters.AddWithValue("cliente", cliente);
                miAdapter.SelectCommand.Parameters.AddWithValue("fecha", fecha);
                miAdapter.SelectCommand.Parameters.AddWithValue("fecha2", fecha2);
                miAdapter.Fill(tFacturas);
                return CalculoDeVentas(tFacturas);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public DataTable ResumenDeVentas2(string nit, DateTime fecha, DateTime fecha2)
        {
            try
            {
                this.tVenta.Rows.Clear();
                var tabla = new DataTable();
                CargarAdapter("resumen_ventas_cliente");
                miAdapter.SelectCommand.Parameters.AddWithValue("", nit);
                miAdapter.SelectCommand.Parameters.AddWithValue("", fecha);
                miAdapter.SelectCommand.Parameters.AddWithValue("", fecha2);
                miAdapter.Fill(tabla);
                if (tabla.Rows.Count > 0)
                {
                    double costo = tabla.AsEnumerable().Sum(s => s.Field<double>("costo"));
                    double base_costo = tabla.AsEnumerable().Sum(s => s.Field<double>("base_costo"));
                    double base_ = tabla.AsEnumerable().Sum(s => s.Field<double>("base"));
                    double total = tabla.AsEnumerable().Sum(s => s.Field<double>("total"));
                    var row = this.tVenta.NewRow();
                    row["Base"] = base_;
                    row["Iva"] = total - base_;
                    row["Total"] = total;
                    row["IvaC"] = Convert.ToInt32(costo - base_costo);
                    row["TotalC"] = Convert.ToInt32(costo);
                    this.tVenta.Rows.Add(row);
                }
                return this.tVenta;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al consultar el resumen de ventas.\n" + ex.Message);
            }
        }

        // 5.
        public DataTable ResumenDeVentasContado(DateTime fecha)
        {
            try
            {
                CargarAdapter("consulta_factura_venta_contado_activa");
                miAdapter.SelectCommand.Parameters.AddWithValue("fecha", fecha);
                miAdapter.Fill(tFacturas);
                return CalculoDeVentas(tFacturas);
                /*foreach (DataRow fRow in tFacturas.Rows)
                {
                    var tProductos = ProductoFacturaVenta(fRow["numero"].ToString(), true);
                    foreach (DataRow pRow in tProductos.Rows)
                    {
                        var row = tVenta.NewRow();
                        row["Total"] = pRow["Valor"];
                        row["Base"] = Convert.ToInt32(Convert.ToInt32(pRow["Valor"]) /
                            (1 + (UseObject.RemoveCharacter(pRow["Iva"].ToString(), '%') / 100)));
                        row["Iva"] = Convert.ToInt32(row["Total"]) - Convert.ToInt32(row["Base"]);

                        var pcRow = ProductoCosto(pRow["Codigo"].ToString()).AsEnumerable().First();
                        row["IvaC"] = Convert.ToInt32(Convert.ToDouble(pcRow["costo"]) * Convert.ToDouble(pcRow["iva"]) / 100);
                        row["TotalC"] = Convert.ToInt32((Convert.ToDouble(pcRow["costo"]) + Convert.ToInt32(row["IvaC"])) *
                            Convert.ToDouble(pRow["Cantidad"]));
                        row["IvaC"] = Convert.ToInt32(Convert.ToInt32(row["IvaC"]) * Convert.ToDouble(pRow["Cantidad"]));

                        tVenta.Rows.Add(row);
                    }
                }
                tFacturas.Rows.Clear();
                return tVenta;*/
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public DataTable ResumenDeVentasContado2(DateTime fecha)
        {
            try
            {
                this.tVenta.Rows.Clear();
                var tabla = new DataTable();
                CargarAdapter("resumen_ventas_contado");
                miAdapter.SelectCommand.Parameters.AddWithValue("", fecha);
                miAdapter.Fill(tabla);
                if (tabla.Rows.Count > 0)
                {
                    double costo = tabla.AsEnumerable().Sum(s => s.Field<double>("costo"));
                    double base_costo = tabla.AsEnumerable().Sum(s => s.Field<double>("base_costo"));
                    double base_ = tabla.AsEnumerable().Sum(s => s.Field<double>("base"));
                    double total = tabla.AsEnumerable().Sum(s => s.Field<double>("total"));
                    var row = this.tVenta.NewRow();
                    row["Base"] = base_;
                    row["Iva"] = total - base_;
                    row["Total"] = total;
                    row["IvaC"] = Convert.ToInt32(costo - base_costo);
                    row["TotalC"] = Convert.ToInt32(costo);
                    this.tVenta.Rows.Add(row);
                }
                return this.tVenta;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al consultar el resumen de ventas.\n" + ex.Message);
            }
        }

        // 6.
        public DataTable ResumenDeVentasContado(DateTime fecha, DateTime fecha2)
        {
            try
            {
                CargarAdapter("consulta_factura_venta_contado_activa");
                miAdapter.SelectCommand.Parameters.AddWithValue("fecha", fecha);
                miAdapter.SelectCommand.Parameters.AddWithValue("fecha2", fecha2);
                miAdapter.Fill(tFacturas);
                return CalculoDeVentas(tFacturas);
               /* foreach (DataRow fRow in tFacturas.Rows)
                {
                    var tProductos = ProductoFacturaVenta(fRow["numero"].ToString(), true);
                    foreach (DataRow pRow in tProductos.Rows)
                    {
                        var row = tVenta.NewRow();
                        row["Total"] = pRow["Valor"];
                        row["Base"] = Convert.ToInt32(Convert.ToInt32(pRow["Valor"]) /
                            (1 + (UseObject.RemoveCharacter(pRow["Iva"].ToString(), '%') / 100)));
                        row["Iva"] = Convert.ToInt32(row["Total"]) - Convert.ToInt32(row["Base"]);

                        var pcRow = ProductoCosto(pRow["Codigo"].ToString()).AsEnumerable().First();
                        row["IvaC"] = Convert.ToInt32(Convert.ToDouble(pcRow["costo"]) * Convert.ToDouble(pcRow["iva"]) / 100);
                        row["TotalC"] = Convert.ToInt32((Convert.ToDouble(pcRow["costo"]) + Convert.ToInt32(row["IvaC"])) *
                            Convert.ToDouble(pRow["Cantidad"]));
                        row["IvaC"] = Convert.ToInt32(Convert.ToInt32(row["IvaC"]) * Convert.ToDouble(pRow["Cantidad"]));

                        tVenta.Rows.Add(row);
                    }
                }
                tFacturas.Rows.Clear();
                return tVenta;*/
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public DataTable ResumenDeVentasContado2(DateTime fecha, DateTime fecha2)
        {
            try
            {
                this.tVenta.Rows.Clear();
                var tabla = new DataTable();
                CargarAdapter("resumen_ventas_contado");
                miAdapter.SelectCommand.Parameters.AddWithValue("", fecha);
                miAdapter.SelectCommand.Parameters.AddWithValue("", fecha2);
                miAdapter.Fill(tabla);
                if (tabla.Rows.Count > 0)
                {
                    double costo = tabla.AsEnumerable().Sum(s => s.Field<double>("costo"));
                    double base_costo = tabla.AsEnumerable().Sum(s => s.Field<double>("base_costo"));
                    double base_ = tabla.AsEnumerable().Sum(s => s.Field<double>("base"));
                    double total = tabla.AsEnumerable().Sum(s => s.Field<double>("total"));
                    var row = this.tVenta.NewRow();
                    row["Base"] = base_;
                    row["Iva"] = total - base_;
                    row["Total"] = total;
                    row["IvaC"] = Convert.ToInt32(costo - base_costo);
                    row["TotalC"] = Convert.ToInt32(costo);
                    this.tVenta.Rows.Add(row);
                }
                return this.tVenta;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al consultar el resumen de ventas.\n" + ex.Message);
            }
        }

        // 7.
        public DataTable ResumenDeVentasContado(string cliente, DateTime fecha)
        {
            try
            {
                CargarAdapter("consulta_factura_venta_contado_activa_cliente");
                miAdapter.SelectCommand.Parameters.AddWithValue("cliente", cliente);
                miAdapter.SelectCommand.Parameters.AddWithValue("fecha", fecha);
                miAdapter.Fill(tFacturas);
                return CalculoDeVentas(tFacturas);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public DataTable ResumenDeVentasContado2(string nit, DateTime fecha)
        {
            try
            {
                this.tVenta.Rows.Clear();
                var tabla = new DataTable();
                CargarAdapter("resumen_ventas_contado_cliente");
                miAdapter.SelectCommand.Parameters.AddWithValue("", nit);
                miAdapter.SelectCommand.Parameters.AddWithValue("", fecha);
                miAdapter.Fill(tabla);
                if (tabla.Rows.Count > 0)
                {
                    double costo = tabla.AsEnumerable().Sum(s => s.Field<double>("costo"));
                    double base_costo = tabla.AsEnumerable().Sum(s => s.Field<double>("base_costo"));
                    double base_ = tabla.AsEnumerable().Sum(s => s.Field<double>("base"));
                    double total = tabla.AsEnumerable().Sum(s => s.Field<double>("total"));
                    var row = this.tVenta.NewRow();
                    row["Base"] = base_;
                    row["Iva"] = total - base_;
                    row["Total"] = total;
                    row["IvaC"] = Convert.ToInt32(costo - base_costo);
                    row["TotalC"] = Convert.ToInt32(costo);
                    this.tVenta.Rows.Add(row);
                }
                return this.tVenta;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al consultar el resumen de ventas.\n" + ex.Message);
            }
        }

        // 8
        public DataTable ResumenDeVentasContado(string cliente, DateTime fecha, DateTime fecha2)
        {
            try
            {
                CargarAdapter("consulta_factura_venta_contado_activa_cliente");
                miAdapter.SelectCommand.Parameters.AddWithValue("cliente", cliente);
                miAdapter.SelectCommand.Parameters.AddWithValue("fecha", fecha);
                miAdapter.SelectCommand.Parameters.AddWithValue("fecha2", fecha2);
                miAdapter.Fill(tFacturas);
                return CalculoDeVentas(tFacturas);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public DataTable ResumenDeVentasContado2(string nit, DateTime fecha, DateTime fecha2)
        {
            try
            {
                this.tVenta.Rows.Clear();
                var tabla = new DataTable();
                CargarAdapter("resumen_ventas_contado_cliente");
                miAdapter.SelectCommand.Parameters.AddWithValue("", nit);
                miAdapter.SelectCommand.Parameters.AddWithValue("", fecha);
                miAdapter.SelectCommand.Parameters.AddWithValue("", fecha2);
                miAdapter.Fill(tabla);
                if (tabla.Rows.Count > 0)
                {
                    double costo = tabla.AsEnumerable().Sum(s => s.Field<double>("costo"));
                    double base_costo = tabla.AsEnumerable().Sum(s => s.Field<double>("base_costo"));
                    double base_ = tabla.AsEnumerable().Sum(s => s.Field<double>("base"));
                    double total = tabla.AsEnumerable().Sum(s => s.Field<double>("total"));
                    var row = this.tVenta.NewRow();
                    row["Base"] = base_;
                    row["Iva"] = total - base_;
                    row["Total"] = total;
                    row["IvaC"] = Convert.ToInt32(costo - base_costo);
                    row["TotalC"] = Convert.ToInt32(costo);
                    this.tVenta.Rows.Add(row);
                }
                return this.tVenta;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al consultar el resumen de ventas.\n" + ex.Message);
            }
        }

        // 9.
        public DataTable ResumenDeVentasCredito(DateTime fecha)
        {
            try
            {
                CargarAdapter("consulta_factura_venta_credito_activa");
                miAdapter.SelectCommand.Parameters.AddWithValue("fecha", fecha);
                miAdapter.Fill(tFacturas);
                return CalculoDeVentas(tFacturas);
                /*foreach (DataRow fRow in tFacturas.Rows)
                {
                    var tProductos = ProductoFacturaVenta(fRow["numero"].ToString(), true);
                    foreach (DataRow pRow in tProductos.Rows)
                    {
                        var row = tVenta.NewRow();
                        row["Total"] = pRow["Valor"];
                        row["Base"] = Convert.ToInt32(Convert.ToInt32(pRow["Valor"]) /
                            (1 + (UseObject.RemoveCharacter(pRow["Iva"].ToString(), '%') / 100)));
                        row["Iva"] = Convert.ToInt32(row["Total"]) - Convert.ToInt32(row["Base"]);

                        var pcRow = ProductoCosto(pRow["Codigo"].ToString()).AsEnumerable().First();
                        row["IvaC"] = Convert.ToInt32(Convert.ToDouble(pcRow["costo"]) * Convert.ToDouble(pcRow["iva"]) / 100);
                        row["TotalC"] = Convert.ToInt32((Convert.ToDouble(pcRow["costo"]) + Convert.ToInt32(row["IvaC"])) *
                            Convert.ToDouble(pRow["Cantidad"]));
                        row["IvaC"] = Convert.ToInt32(Convert.ToInt32(row["IvaC"]) * Convert.ToDouble(pRow["Cantidad"]));

                        tVenta.Rows.Add(row);
                    }
                }
                tFacturas.Rows.Clear();
                return tVenta;*/
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public DataTable ResumenDeVentasCredito2(DateTime fecha)
        {
            try
            {
                this.tVenta.Rows.Clear();
                var tabla = new DataTable();
                CargarAdapter("resumen_ventas_credito");
                miAdapter.SelectCommand.Parameters.AddWithValue("", fecha);
                miAdapter.Fill(tabla);
                if (tabla.Rows.Count > 0)
                {
                    double costo = tabla.AsEnumerable().Sum(s => s.Field<double>("costo"));
                    double base_costo = tabla.AsEnumerable().Sum(s => s.Field<double>("base_costo"));
                    double base_ = tabla.AsEnumerable().Sum(s => s.Field<double>("base"));
                    double total = tabla.AsEnumerable().Sum(s => s.Field<double>("total"));
                    var row = this.tVenta.NewRow();
                    row["Base"] = base_;
                    row["Iva"] = total - base_;
                    row["Total"] = total;
                    row["IvaC"] = Convert.ToInt32(costo - base_costo);
                    row["TotalC"] = Convert.ToInt32(costo);
                    this.tVenta.Rows.Add(row);
                }
                return this.tVenta;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al consultar el resumen de ventas.\n" + ex.Message);
            }
        }

        // 10.
        public DataTable ResumenDeVentasCredito(DateTime fecha, DateTime fecha2)
        {
            try
            {
                CargarAdapter("consulta_factura_venta_credito_activa");
                miAdapter.SelectCommand.Parameters.AddWithValue("fecha", fecha);
                miAdapter.SelectCommand.Parameters.AddWithValue("fecha2", fecha2);
                miAdapter.Fill(tFacturas);
                return CalculoDeVentas(tFacturas);
               /* foreach (DataRow fRow in tFacturas.Rows)
                {
                    var tProductos = ProductoFacturaVenta(fRow["numero"].ToString(), true);
                    foreach (DataRow pRow in tProductos.Rows)
                    {
                        var row = tVenta.NewRow();
                        row["Total"] = pRow["Valor"];
                        row["Base"] = Convert.ToInt32(Convert.ToInt32(pRow["Valor"]) /
                            (1 + (UseObject.RemoveCharacter(pRow["Iva"].ToString(), '%') / 100)));
                        row["Iva"] = Convert.ToInt32(row["Total"]) - Convert.ToInt32(row["Base"]);

                        var pcRow = ProductoCosto(pRow["Codigo"].ToString()).AsEnumerable().First();
                        row["IvaC"] = Convert.ToInt32(Convert.ToDouble(pcRow["costo"]) * Convert.ToDouble(pcRow["iva"]) / 100);
                        row["TotalC"] = Convert.ToInt32((Convert.ToDouble(pcRow["costo"]) + Convert.ToInt32(row["IvaC"])) *
                            Convert.ToDouble(pRow["Cantidad"]));
                        row["IvaC"] = Convert.ToInt32(Convert.ToInt32(row["IvaC"]) * Convert.ToDouble(pRow["Cantidad"]));

                        tVenta.Rows.Add(row);
                    }
                }
                tFacturas.Rows.Clear();
                return tVenta;*/
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public DataTable ResumenDeVentasCredito2(DateTime fecha, DateTime fecha2)
        {
            try
            {
                this.tVenta.Rows.Clear();
                var tabla = new DataTable();
                CargarAdapter("resumen_ventas_credito");
                miAdapter.SelectCommand.Parameters.AddWithValue("", fecha);
                miAdapter.SelectCommand.Parameters.AddWithValue("", fecha2);
                miAdapter.Fill(tabla);
                if (tabla.Rows.Count > 0)
                {
                    double costo = tabla.AsEnumerable().Sum(s => s.Field<double>("costo"));
                    double base_costo = tabla.AsEnumerable().Sum(s => s.Field<double>("base_costo"));
                    double base_ = tabla.AsEnumerable().Sum(s => s.Field<double>("base"));
                    double total = tabla.AsEnumerable().Sum(s => s.Field<double>("total"));
                    var row = this.tVenta.NewRow();
                    row["Base"] = base_;
                    row["Iva"] = total - base_;
                    row["Total"] = total;
                    row["IvaC"] = Convert.ToInt32(costo - base_costo);
                    row["TotalC"] = Convert.ToInt32(costo);
                    this.tVenta.Rows.Add(row);
                }
                return this.tVenta;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al consultar el resumen de ventas.\n" + ex.Message);
            }
        }

        // 11
        public DataTable ResumenDeVentasCredito(string cliente, DateTime fecha)
        {
            try
            {
                CargarAdapter("consulta_factura_venta_credito_activa_cliente");
                miAdapter.SelectCommand.Parameters.AddWithValue("cliente", cliente);
                miAdapter.SelectCommand.Parameters.AddWithValue("fecha", fecha);
                miAdapter.Fill(tFacturas);
                return CalculoDeVentas(tFacturas);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public DataTable ResumenDeVentasCredito2(string cliente, DateTime fecha)
        {
            try
            {
                this.tVenta.Rows.Clear();
                var tabla = new DataTable();
                CargarAdapter("resumen_ventas_credito_cliente");
                miAdapter.SelectCommand.Parameters.AddWithValue("", cliente);
                miAdapter.SelectCommand.Parameters.AddWithValue("", fecha);
                miAdapter.Fill(tabla);
                if (tabla.Rows.Count > 0)
                {
                    double costo = tabla.AsEnumerable().Sum(s => s.Field<double>("costo"));
                    double base_costo = tabla.AsEnumerable().Sum(s => s.Field<double>("base_costo"));
                    double base_ = tabla.AsEnumerable().Sum(s => s.Field<double>("base"));
                    double total = tabla.AsEnumerable().Sum(s => s.Field<double>("total"));
                    var row = this.tVenta.NewRow();
                    row["Base"] = base_;
                    row["Iva"] = total - base_;
                    row["Total"] = total;
                    row["IvaC"] = Convert.ToInt32(costo - base_costo);
                    row["TotalC"] = Convert.ToInt32(costo);
                    this.tVenta.Rows.Add(row);
                }
                return this.tVenta;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al consultar el resumen de ventas.\n" + ex.Message);
            }
        }

        // 12
        public DataTable ResumenDeVentasCredito(string cliente, DateTime fecha, DateTime fecha2)
        {
            try
            {
                CargarAdapter("consulta_factura_venta_credito_activa_cliente");
                miAdapter.SelectCommand.Parameters.AddWithValue("cliente", cliente);
                miAdapter.SelectCommand.Parameters.AddWithValue("fecha", fecha);
                miAdapter.SelectCommand.Parameters.AddWithValue("fecha2", fecha2);
                miAdapter.Fill(tFacturas);
                return CalculoDeVentas(tFacturas);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public DataTable ResumenDeVentasCredito2(string cliente, DateTime fecha, DateTime fecha2)
        {
            try
            {
                this.tVenta.Rows.Clear();
                var tabla = new DataTable();
                CargarAdapter("resumen_ventas_credito_cliente");
                miAdapter.SelectCommand.Parameters.AddWithValue("", cliente);
                miAdapter.SelectCommand.Parameters.AddWithValue("", fecha);
                miAdapter.SelectCommand.Parameters.AddWithValue("", fecha2);
                miAdapter.Fill(tabla);
                if (tabla.Rows.Count > 0)
                {
                    double costo = tabla.AsEnumerable().Sum(s => s.Field<double>("costo"));
                    double base_costo = tabla.AsEnumerable().Sum(s => s.Field<double>("base_costo"));
                    double base_ = tabla.AsEnumerable().Sum(s => s.Field<double>("base"));
                    double total = tabla.AsEnumerable().Sum(s => s.Field<double>("total"));
                    var row = this.tVenta.NewRow();
                    row["Base"] = base_;
                    row["Iva"] = total - base_;
                    row["Total"] = total;
                    row["IvaC"] = Convert.ToInt32(costo - base_costo);
                    row["TotalC"] = Convert.ToInt32(costo);
                    this.tVenta.Rows.Add(row);
                }
                return this.tVenta;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al consultar el resumen de ventas.\n" + ex.Message);
            }
        }

        // 13
        public DataTable ResumenDeVentasAnulada(DateTime fecha)
        {
            try
            {
                CargarAdapter("consulta_factura_venta_anulada");
                miAdapter.SelectCommand.Parameters.AddWithValue("fecha", fecha);
                miAdapter.Fill(tFacturas);
                return CalculoDeVentas(tFacturas);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public DataTable ResumenDeVentasAnulada2(DateTime fecha)
        {
            try
            {
                this.tVenta.Rows.Clear();
                var tabla = new DataTable();
                CargarAdapter("resumen_ventas_anuladas");
                miAdapter.SelectCommand.Parameters.AddWithValue("", fecha);
                miAdapter.Fill(tabla);
                if (tabla.Rows.Count > 0)
                {
                    double costo = tabla.AsEnumerable().Sum(s => s.Field<double>("costo"));
                    double base_costo = tabla.AsEnumerable().Sum(s => s.Field<double>("base_costo"));
                    double base_ = tabla.AsEnumerable().Sum(s => s.Field<double>("base"));
                    double total = tabla.AsEnumerable().Sum(s => s.Field<double>("total"));
                    var row = this.tVenta.NewRow();
                    row["Base"] = base_;
                    row["Iva"] = total - base_;
                    row["Total"] = total;
                    row["IvaC"] = Convert.ToInt32(costo - base_costo);
                    row["TotalC"] = Convert.ToInt32(costo);
                    this.tVenta.Rows.Add(row);
                }
                return this.tVenta;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al consultar el resumen de ventas.\n" + ex.Message);
            }
        }

        // 14
        public DataTable ResumenDeVentasAnulada(DateTime fecha, DateTime fecha2)
        {
            try
            {
                CargarAdapter("consulta_factura_venta_anulada");
                miAdapter.SelectCommand.Parameters.AddWithValue("fecha", fecha);
                miAdapter.SelectCommand.Parameters.AddWithValue("fecha2", fecha2);
                miAdapter.Fill(tFacturas);
                return CalculoDeVentas(tFacturas);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public DataTable ResumenDeVentasAnulada2(DateTime fecha, DateTime fecha2)
        {
            try
            {
                this.tVenta.Rows.Clear();
                var tabla = new DataTable();
                CargarAdapter("resumen_ventas_anuladas");
                miAdapter.SelectCommand.Parameters.AddWithValue("", fecha);
                miAdapter.SelectCommand.Parameters.AddWithValue("", fecha2);
                miAdapter.Fill(tabla);
                if (tabla.Rows.Count > 0)
                {
                    double costo = tabla.AsEnumerable().Sum(s => s.Field<double>("costo"));
                    double base_costo = tabla.AsEnumerable().Sum(s => s.Field<double>("base_costo"));
                    double base_ = tabla.AsEnumerable().Sum(s => s.Field<double>("base"));
                    double total = tabla.AsEnumerable().Sum(s => s.Field<double>("total"));
                    var row = this.tVenta.NewRow();
                    row["Base"] = base_;
                    row["Iva"] = total - base_;
                    row["Total"] = total;
                    row["IvaC"] = Convert.ToInt32(costo - base_costo);
                    row["TotalC"] = Convert.ToInt32(costo);
                    this.tVenta.Rows.Add(row);
                }
                return this.tVenta;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al consultar el resumen de ventas.\n" + ex.Message);
            }
        }

        // 15
        public DataTable ResumenDeVentasAnulada(string cliente, DateTime fecha)
        {
            try
            {
                CargarAdapter("consulta_factura_venta_anulada_cliente");
                miAdapter.SelectCommand.Parameters.AddWithValue("cliente", cliente);
                miAdapter.SelectCommand.Parameters.AddWithValue("fecha", fecha);
                miAdapter.Fill(tFacturas);
                return CalculoDeVentas(tFacturas);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public DataTable ResumenDeVentasAnulada2(string cliente, DateTime fecha)
        {
            try
            {
                this.tVenta.Rows.Clear();
                var tabla = new DataTable();
                CargarAdapter("resumen_ventas_cliente_anuladas");
                miAdapter.SelectCommand.Parameters.AddWithValue("", cliente);
                miAdapter.SelectCommand.Parameters.AddWithValue("", fecha);
                miAdapter.Fill(tabla);
                if (tabla.Rows.Count > 0)
                {
                    double costo = tabla.AsEnumerable().Sum(s => s.Field<double>("costo"));
                    double base_costo = tabla.AsEnumerable().Sum(s => s.Field<double>("base_costo"));
                    double base_ = tabla.AsEnumerable().Sum(s => s.Field<double>("base"));
                    double total = tabla.AsEnumerable().Sum(s => s.Field<double>("total"));
                    var row = this.tVenta.NewRow();
                    row["Base"] = base_;
                    row["Iva"] = total - base_;
                    row["Total"] = total;
                    row["IvaC"] = Convert.ToInt32(costo - base_costo);
                    row["TotalC"] = Convert.ToInt32(costo);
                    this.tVenta.Rows.Add(row);
                }
                return this.tVenta;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al consultar el resumen de ventas.\n" + ex.Message);
            }
        }

        // 16
        public DataTable ResumenDeVentasAnulada(string cliente, DateTime fecha, DateTime fecha2)
        {
            try
            {
                CargarAdapter("consulta_factura_venta_anulada_cliente");
                miAdapter.SelectCommand.Parameters.AddWithValue("cliente", cliente);
                miAdapter.SelectCommand.Parameters.AddWithValue("fecha", fecha);
                miAdapter.SelectCommand.Parameters.AddWithValue("fecha2", fecha2);
                miAdapter.Fill(tFacturas);
                return CalculoDeVentas(tFacturas);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public DataTable ResumenDeVentasAnulada2(string cliente, DateTime fecha, DateTime fecha2)
        {
            try
            {
                this.tVenta.Rows.Clear();
                var tabla = new DataTable();
                CargarAdapter("resumen_ventas_cliente_anuladas");
                miAdapter.SelectCommand.Parameters.AddWithValue("", cliente);
                miAdapter.SelectCommand.Parameters.AddWithValue("", fecha);
                miAdapter.SelectCommand.Parameters.AddWithValue("", fecha2);
                miAdapter.Fill(tabla);
                if (tabla.Rows.Count > 0)
                {
                    double costo = tabla.AsEnumerable().Sum(s => s.Field<double>("costo"));
                    double base_costo = tabla.AsEnumerable().Sum(s => s.Field<double>("base_costo"));
                    double base_ = tabla.AsEnumerable().Sum(s => s.Field<double>("base"));
                    double total = tabla.AsEnumerable().Sum(s => s.Field<double>("total"));
                    var row = this.tVenta.NewRow();
                    row["Base"] = base_;
                    row["Iva"] = total - base_;
                    row["Total"] = total;
                    row["IvaC"] = Convert.ToInt32(costo - base_costo);
                    row["TotalC"] = Convert.ToInt32(costo);
                    this.tVenta.Rows.Add(row);
                }
                return this.tVenta;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al consultar el resumen de ventas.\n" + ex.Message);
            }
        }


        // Funciones de consulta con usuario

        public DataTable ResumenDeVentas2(int idUsuario, DateTime fecha)
        {
            try
            {
                this.tVenta.Rows.Clear();
                var tabla = new DataTable();
                CargarAdapter("resumen_ventas_usuario");
                miAdapter.SelectCommand.Parameters.AddWithValue("", idUsuario);
                miAdapter.SelectCommand.Parameters.AddWithValue("", fecha);
                miAdapter.Fill(tabla);
                if (tabla.Rows.Count > 0)
                {
                    double costo = tabla.AsEnumerable().Sum(s => s.Field<double>("costo"));
                    double base_costo = tabla.AsEnumerable().Sum(s => s.Field<double>("base_costo"));
                    double base_ = tabla.AsEnumerable().Sum(s => s.Field<double>("base"));
                    double total = tabla.AsEnumerable().Sum(s => s.Field<double>("total"));
                    var row = this.tVenta.NewRow();
                    row["Base"] = base_;
                    row["Iva"] = total - base_;
                    row["Total"] = total;
                    row["IvaC"] = Convert.ToInt32(costo - base_costo);
                    row["TotalC"] = Convert.ToInt32(costo);
                    this.tVenta.Rows.Add(row);
                }
                return this.tVenta;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al consultar el resumen de ventas.\n" + ex.Message);
            }
        }

        public DataTable ResumenDeVentas2(int idUsuario, DateTime fecha, DateTime fecha2)
        {
            try
            {
                this.tVenta.Rows.Clear();
                var tabla = new DataTable();
                CargarAdapter("resumen_ventas_usuario");
                miAdapter.SelectCommand.Parameters.AddWithValue("", idUsuario);
                miAdapter.SelectCommand.Parameters.AddWithValue("", fecha);
                miAdapter.SelectCommand.Parameters.AddWithValue("", fecha2);
                miAdapter.Fill(tabla);
                if (tabla.Rows.Count > 0)
                {
                    double costo = tabla.AsEnumerable().Sum(s => s.Field<double>("costo"));
                    double base_costo = tabla.AsEnumerable().Sum(s => s.Field<double>("base_costo"));
                    double base_ = tabla.AsEnumerable().Sum(s => s.Field<double>("base"));
                    double total = tabla.AsEnumerable().Sum(s => s.Field<double>("total"));
                    var row = this.tVenta.NewRow();
                    row["Base"] = base_;
                    row["Iva"] = total - base_;
                    row["Total"] = total;
                    row["IvaC"] = Convert.ToInt32(costo - base_costo);
                    row["TotalC"] = Convert.ToInt32(costo);
                    this.tVenta.Rows.Add(row);
                }
                return this.tVenta;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al consultar el resumen de ventas.\n" + ex.Message);
            }
        }

        public DataTable ResumenDeVentasContado2(int idUsuario, DateTime fecha)
        {
            try
            {
                this.tVenta.Rows.Clear();
                var tabla = new DataTable();
                CargarAdapter("resumen_ventas_contado_usuario");
                miAdapter.SelectCommand.Parameters.AddWithValue("", idUsuario);
                miAdapter.SelectCommand.Parameters.AddWithValue("", fecha);
                miAdapter.Fill(tabla);
                if (tabla.Rows.Count > 0)
                {
                    double costo = tabla.AsEnumerable().Sum(s => s.Field<double>("costo"));
                    double base_costo = tabla.AsEnumerable().Sum(s => s.Field<double>("base_costo"));
                    double base_ = tabla.AsEnumerable().Sum(s => s.Field<double>("base"));
                    double total = tabla.AsEnumerable().Sum(s => s.Field<double>("total"));
                    var row = this.tVenta.NewRow();
                    row["Base"] = base_;
                    row["Iva"] = total - base_;
                    row["Total"] = total;
                    row["IvaC"] = Convert.ToInt32(costo - base_costo);
                    row["TotalC"] = Convert.ToInt32(costo);
                    this.tVenta.Rows.Add(row);
                }
                return this.tVenta;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al consultar el resumen de ventas.\n" + ex.Message);
            }
        }

        public DataTable ResumenDeVentasContado2(int idUsuario, DateTime fecha, DateTime fecha2)
        {
            try
            {
                this.tVenta.Rows.Clear();
                var tabla = new DataTable();
                CargarAdapter("resumen_ventas_contado_usuario");
                miAdapter.SelectCommand.Parameters.AddWithValue("", idUsuario);
                miAdapter.SelectCommand.Parameters.AddWithValue("", fecha);
                miAdapter.SelectCommand.Parameters.AddWithValue("", fecha2);
                miAdapter.Fill(tabla);
                if (tabla.Rows.Count > 0)
                {
                    double costo = tabla.AsEnumerable().Sum(s => s.Field<double>("costo"));
                    double base_costo = tabla.AsEnumerable().Sum(s => s.Field<double>("base_costo"));
                    double base_ = tabla.AsEnumerable().Sum(s => s.Field<double>("base"));
                    double total = tabla.AsEnumerable().Sum(s => s.Field<double>("total"));
                    var row = this.tVenta.NewRow();
                    row["Base"] = base_;
                    row["Iva"] = total - base_;
                    row["Total"] = total;
                    row["IvaC"] = Convert.ToInt32(costo - base_costo);
                    row["TotalC"] = Convert.ToInt32(costo);
                    this.tVenta.Rows.Add(row);
                }
                return this.tVenta;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al consultar el resumen de ventas.\n" + ex.Message);
            }
        }

        public DataTable ResumenDeVentasCredito2(int idUsuario, DateTime fecha)
        {
            try
            {
                this.tVenta.Rows.Clear();
                var tabla = new DataTable();
                CargarAdapter("resumen_ventas_credito_usuario");
                miAdapter.SelectCommand.Parameters.AddWithValue("", idUsuario);
                miAdapter.SelectCommand.Parameters.AddWithValue("", fecha);
                miAdapter.Fill(tabla);
                if (tabla.Rows.Count > 0)
                {
                    double costo = tabla.AsEnumerable().Sum(s => s.Field<double>("costo"));
                    double base_costo = tabla.AsEnumerable().Sum(s => s.Field<double>("base_costo"));
                    double base_ = tabla.AsEnumerable().Sum(s => s.Field<double>("base"));
                    double total = tabla.AsEnumerable().Sum(s => s.Field<double>("total"));
                    var row = this.tVenta.NewRow();
                    row["Base"] = base_;
                    row["Iva"] = total - base_;
                    row["Total"] = total;
                    row["IvaC"] = Convert.ToInt32(costo - base_costo);
                    row["TotalC"] = Convert.ToInt32(costo);
                    this.tVenta.Rows.Add(row);
                }
                return this.tVenta;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al consultar el resumen de ventas.\n" + ex.Message);
            }
        }

        public DataTable ResumenDeVentasCredito2(int idUsuario, DateTime fecha, DateTime fecha2)
        {
            try
            {
                this.tVenta.Rows.Clear();
                var tabla = new DataTable();
                CargarAdapter("resumen_ventas_credito_usuario");
                miAdapter.SelectCommand.Parameters.AddWithValue("", idUsuario);
                miAdapter.SelectCommand.Parameters.AddWithValue("", fecha);
                miAdapter.SelectCommand.Parameters.AddWithValue("", fecha2);
                miAdapter.Fill(tabla);
                if (tabla.Rows.Count > 0)
                {
                    double costo = tabla.AsEnumerable().Sum(s => s.Field<double>("costo"));
                    double base_costo = tabla.AsEnumerable().Sum(s => s.Field<double>("base_costo"));
                    double base_ = tabla.AsEnumerable().Sum(s => s.Field<double>("base"));
                    double total = tabla.AsEnumerable().Sum(s => s.Field<double>("total"));
                    var row = this.tVenta.NewRow();
                    row["Base"] = base_;
                    row["Iva"] = total - base_;
                    row["Total"] = total;
                    row["IvaC"] = Convert.ToInt32(costo - base_costo);
                    row["TotalC"] = Convert.ToInt32(costo);
                    this.tVenta.Rows.Add(row);
                }
                return this.tVenta;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al consultar el resumen de ventas.\n" + ex.Message);
            }
        }

        public DataTable ResumenDeVentasAnulada2(int idUsuario, DateTime fecha)
        {
            try
            {
                this.tVenta.Rows.Clear();
                var tabla = new DataTable();
                CargarAdapter("resumen_ventas_usuario_anuladas");
                miAdapter.SelectCommand.Parameters.AddWithValue("", idUsuario);
                miAdapter.SelectCommand.Parameters.AddWithValue("", fecha);
                miAdapter.Fill(tabla);
                if (tabla.Rows.Count > 0)
                {
                    double costo = tabla.AsEnumerable().Sum(s => s.Field<double>("costo"));
                    double base_costo = tabla.AsEnumerable().Sum(s => s.Field<double>("base_costo"));
                    double base_ = tabla.AsEnumerable().Sum(s => s.Field<double>("base"));
                    double total = tabla.AsEnumerable().Sum(s => s.Field<double>("total"));
                    var row = this.tVenta.NewRow();
                    row["Base"] = base_;
                    row["Iva"] = total - base_;
                    row["Total"] = total;
                    row["IvaC"] = Convert.ToInt32(costo - base_costo);
                    row["TotalC"] = Convert.ToInt32(costo);
                    this.tVenta.Rows.Add(row);
                }
                return this.tVenta;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al consultar el resumen de ventas.\n" + ex.Message);
            }
        }

        public DataTable ResumenDeVentasAnulada2(int idUsuario, DateTime fecha, DateTime fecha2)
        {
            try
            {
                this.tVenta.Rows.Clear();
                var tabla = new DataTable();
                CargarAdapter("resumen_ventas_usuario_anuladas");
                miAdapter.SelectCommand.Parameters.AddWithValue("", idUsuario);
                miAdapter.SelectCommand.Parameters.AddWithValue("", fecha);
                miAdapter.SelectCommand.Parameters.AddWithValue("", fecha2);
                miAdapter.Fill(tabla);
                if (tabla.Rows.Count > 0)
                {
                    double costo = tabla.AsEnumerable().Sum(s => s.Field<double>("costo"));
                    double base_costo = tabla.AsEnumerable().Sum(s => s.Field<double>("base_costo"));
                    double base_ = tabla.AsEnumerable().Sum(s => s.Field<double>("base"));
                    double total = tabla.AsEnumerable().Sum(s => s.Field<double>("total"));
                    var row = this.tVenta.NewRow();
                    row["Base"] = base_;
                    row["Iva"] = total - base_;
                    row["Total"] = total;
                    row["IvaC"] = Convert.ToInt32(costo - base_costo);
                    row["TotalC"] = Convert.ToInt32(costo);
                    this.tVenta.Rows.Add(row);
                }
                return this.tVenta;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al consultar el resumen de ventas.\n" + ex.Message);
            }
        }





        public DataTable CalculoDeVentas(DataTable tableFacturas)
        {
            this.tVenta.Rows.Clear();
            foreach (DataRow fRow in tableFacturas.Rows) // itera las facturas
            {
                //var tProductos = ProductoFacturaVenta(fRow["numero"].ToString(), true);
                var tProductos = ProductoFacturaVenta(Convert.ToInt32(fRow["id"]), true);
                foreach (DataRow pRow in tProductos.Rows) // itera los productos
                {
                    //  calculo de ventas
                    if (!Convert.ToBoolean(pRow["Retorno"]))
                    {
                        var row = this.tVenta.NewRow();
                        row["Total"] = pRow["Valor"];
                        /*row["Base"] = Convert.ToInt32(Convert.ToInt32(pRow["Valor"]) /
                            (1 + (UseObject.RemoveCharacter(pRow["Iva"].ToString(), '%') / 100)));*/

                        row["Base"] = Math.Round((Convert.ToInt32(pRow["Valor"]) /
                            (1 + (UseObject.RemoveCharacter(pRow["Iva"].ToString(), '%') / 100))), 1);

                        row["Iva"] = Convert.ToDouble(row["Total"]) - Convert.ToDouble(row["Base"]);

                        int base_ = Convert.ToInt32(Convert.ToDouble(pRow["costo"]) /
                            (1 + (UseObject.RemoveCharacter(pRow["Iva"].ToString(), '%') / 100)));

                        row["IvaC"] = Convert.ToInt32(Convert.ToDouble(pRow["costo"]) - base_);

                        row["TotalC"] = Convert.ToInt32(Convert.ToDouble(pRow["costo"]) * Convert.ToDouble(pRow["Cantidad"]));

                        row["IvaC"] = Convert.ToInt32(Convert.ToInt32(row["IvaC"]) * Convert.ToDouble(pRow["Cantidad"]));

                        this.tVenta.Rows.Add(row);
                    }
                }
            }
            tableFacturas.Rows.Clear();
            return this.tVenta;
        }



        public List<ProductoFacturaProveedor> ResumenVentas3(DateTime fecha)
        {
            try
            {
                List<ProductoFacturaProveedor> productos = new List<ProductoFacturaProveedor>();

                string sql = 
             "SELECT id FROM factura_venta WHERE (factura_venta.idestado = 1 OR factura_venta.idestado = 2) AND factura_venta.estado = true AND " +
             "factura_venta.fecha_factura_venta = '" + fecha.ToShortDateString() + "';";
                var tabla = new DataTable();
                miAdapter = new NpgsqlDataAdapter(sql, miConexion.MiConexion);
                miAdapter.SelectCommand.CommandType = CommandType.Text;
                miAdapter.Fill(tabla);

                productos.Add(new ProductoFacturaProveedor
                {
                    Costo = Convert.ToInt32(this.CostoVentaMasIco3(fecha)),
                    Valor = this.CalculoDeVentas2(tabla)
                });

                return productos;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al consultar el resumen de ventas.\n" + ex.Message);
            }
        }

        public List<ProductoFacturaProveedor> ResumenVentas3(DateTime fecha, DateTime fecha2)
        {
            try
            {
                List<ProductoFacturaProveedor> productos = new List<ProductoFacturaProveedor>();

                string sql =
             "SELECT id FROM factura_venta WHERE (factura_venta.idestado = 1 OR factura_venta.idestado = 2) AND factura_venta.estado = true AND " +
             "factura_venta.fecha_factura_venta BETWEEN '" + fecha.ToShortDateString() + "' AND '"+ fecha2.ToShortDateString() +"';";
                var tabla = new DataTable();
                miAdapter = new NpgsqlDataAdapter(sql, miConexion.MiConexion);
                miAdapter.SelectCommand.CommandType = CommandType.Text;
                miAdapter.Fill(tabla);

                productos.Add(new ProductoFacturaProveedor
                {
                    Costo = Convert.ToInt32(this.CostoVentaMasIco3(fecha, fecha2)),
                    Valor = this.CalculoDeVentas2(tabla)
                });

                return productos;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al consultar el resumen de ventas.\n" + ex.Message);
            }
        }

        public List<ProductoFacturaProveedor> ResumenVentas3(string nit, DateTime fecha)
        {
            try
            {
                List<ProductoFacturaProveedor> productos = new List<ProductoFacturaProveedor>();

                string sql =
             "SELECT id FROM factura_venta WHERE (factura_venta.idestado = 1 OR factura_venta.idestado = 2) AND factura_venta.estado = true AND " +
             "factura_venta.nitcliente = '"+ nit +"' AND factura_venta.fecha_factura_venta = '" + fecha.ToShortDateString() + "';";
                var tabla = new DataTable();
                miAdapter = new NpgsqlDataAdapter(sql, miConexion.MiConexion);
                miAdapter.SelectCommand.CommandType = CommandType.Text;
                miAdapter.Fill(tabla);

                productos.Add(new ProductoFacturaProveedor
                {
                    Costo = Convert.ToInt32(this.CostoVentaMasIco3(nit, fecha)),
                    Valor = this.CalculoDeVentas2(tabla)
                });

                return productos;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al consultar el resumen de ventas.\n" + ex.Message);
            }
        }

        public List<ProductoFacturaProveedor> ResumenVentas3(string nit, DateTime fecha, DateTime fecha2)
        {
            try
            {
                List<ProductoFacturaProveedor> productos = new List<ProductoFacturaProveedor>();

                string sql =
             "SELECT id FROM factura_venta WHERE (factura_venta.idestado = 1 OR factura_venta.idestado = 2) AND factura_venta.estado = true AND " +
             "factura_venta.nitcliente = '"+ nit +"' AND factura_venta.fecha_factura_venta BETWEEN '" + fecha.ToShortDateString() + "' AND '" + fecha2.ToShortDateString() + "';";
                var tabla = new DataTable();
                miAdapter = new NpgsqlDataAdapter(sql, miConexion.MiConexion);
                miAdapter.SelectCommand.CommandType = CommandType.Text;
                miAdapter.Fill(tabla);

                productos.Add(new ProductoFacturaProveedor
                {
                    Costo = Convert.ToInt32(this.CostoVentaMasIco3(nit, fecha, fecha2)),
                    Valor = this.CalculoDeVentas2(tabla)
                });

                return productos;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al consultar el resumen de ventas.\n" + ex.Message);
            }
        }

        public List<ProductoFacturaProveedor> ResumenVentas3(int idUsuario, DateTime fecha)
        {
            try
            {
                List<ProductoFacturaProveedor> productos = new List<ProductoFacturaProveedor>();

                string sql =
             "SELECT id FROM factura_venta WHERE (factura_venta.idestado = 1 OR factura_venta.idestado = 2) AND factura_venta.estado = true AND " +
             "factura_venta.idusuario_sistema = " + idUsuario + " AND factura_venta.fecha_factura_venta = '" + fecha.ToShortDateString() + "';";
                var tabla = new DataTable();
                miAdapter = new NpgsqlDataAdapter(sql, miConexion.MiConexion);
                miAdapter.SelectCommand.CommandType = CommandType.Text;
                miAdapter.Fill(tabla);

                productos.Add(new ProductoFacturaProveedor
                {
                    Costo = Convert.ToInt32(this.CostoVentaMasIco3(idUsuario, fecha)),
                    Valor = this.CalculoDeVentas2(tabla)
                });

                return productos;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al consultar el resumen de ventas.\n" + ex.Message);
            }
        }

        public List<ProductoFacturaProveedor> ResumenVentas3(int idUsuario, DateTime fecha, DateTime fecha2)
        {
            try
            {
                List<ProductoFacturaProveedor> productos = new List<ProductoFacturaProveedor>();

                string sql =
             "SELECT id FROM factura_venta WHERE (factura_venta.idestado = 1 OR factura_venta.idestado = 2) AND factura_venta.estado = true AND " +
             "factura_venta.idusuario_sistema = " + idUsuario + " AND factura_venta.fecha_factura_venta BETWEEN '" + fecha.ToShortDateString() + "' AND '" + fecha2.ToShortDateString() + "';";
                var tabla = new DataTable();
                miAdapter = new NpgsqlDataAdapter(sql, miConexion.MiConexion);
                miAdapter.SelectCommand.CommandType = CommandType.Text;
                miAdapter.Fill(tabla);

                productos.Add(new ProductoFacturaProveedor
                {
                    Costo = Convert.ToInt32(this.CostoVentaMasIco3(idUsuario, fecha, fecha2)),
                    Valor = this.CalculoDeVentas2(tabla)
                });

                return productos;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al consultar el resumen de ventas.\n" + ex.Message);
            }
        }


        private int CalculoDeVentas2(DataTable tableFacturas)
        {
            var miDaoImpuesto = new DaoImpuestoBolsa();
            ImpuestoBolsa icoBolsa;

            DataTable tProductos;
            double valorFactura = 0;
            int totalVenta = 0;
            foreach (DataRow fRow in tableFacturas.Rows) // itera las facturas
            {
                valorFactura = 0;
                tProductos = ProductoFacturaVenta(Convert.ToInt32(fRow["id"]), true);
                valorFactura = tProductos.AsEnumerable().Sum(t => t.Field<double>("Valor"));
                icoBolsa = miDaoImpuesto.ImpuestoBolsaDeVenta(Convert.ToInt32(fRow["id"]));
                valorFactura += (icoBolsa.Cantidad * icoBolsa.Valor);
                totalVenta += Convert.ToInt32(valorFactura);
            }
            return totalVenta;

            /*var row = this.tVenta.NewRow();
            row["Total"] = totalVenta;
            this.tVenta.Rows.Add(row);
            tableFacturas.Rows.Clear();
            return this.tVenta;*/
        }



        private double CostoVentaMasIco3(DateTime fecha)
        {
            try
            {
                this.CargarComando("resumen_costo_ico");
                this.miComando.Parameters.AddWithValue("", fecha);
                this.miConexion.MiConexion.Open();
                var costo = Convert.ToDouble(this.miComando.ExecuteScalar());
                this.miConexion.MiConexion.Close();
                this.miComando.Dispose();
                return costo;
            }
            catch (InvalidCastException)
            {
                return 0;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally { this.miConexion.MiConexion.Close(); }
        }

        private double CostoVentaMasIco3(DateTime fecha, DateTime fecha2)
        {
            try
            {
                this.CargarComando("resumen_costo_ico");
                this.miComando.Parameters.AddWithValue("", fecha);
                this.miComando.Parameters.AddWithValue("", fecha2);
                this.miConexion.MiConexion.Open();
                var costo = Convert.ToDouble(this.miComando.ExecuteScalar());
                this.miConexion.MiConexion.Close();
                this.miComando.Dispose();
                return costo;
            }
            catch (InvalidCastException)
            {
                return 0;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally { this.miConexion.MiConexion.Close(); }
        }

        private double CostoVentaMasIco3(string nit, DateTime fecha)
        {
            try
            {
                this.CargarComando("resumen_costo_cliente_ico");
                this.miComando.Parameters.AddWithValue("", nit);
                this.miComando.Parameters.AddWithValue("", fecha);
                this.miConexion.MiConexion.Open();
                var costo = Convert.ToDouble(this.miComando.ExecuteScalar());
                this.miConexion.MiConexion.Close();
                this.miComando.Dispose();
                return costo;
            }
            catch (InvalidCastException)
            {
                return 0;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally { this.miConexion.MiConexion.Close(); }
        }

        private double CostoVentaMasIco3(string nit, DateTime fecha, DateTime fecha2)
        {
            try
            {
                this.CargarComando("resumen_costo_cliente_ico");
                this.miComando.Parameters.AddWithValue("", nit);
                this.miComando.Parameters.AddWithValue("", fecha);
                this.miComando.Parameters.AddWithValue("", fecha2);
                this.miConexion.MiConexion.Open();
                var costo = Convert.ToDouble(this.miComando.ExecuteScalar());
                this.miConexion.MiConexion.Close();
                this.miComando.Dispose();
                return costo;
            }
            catch (InvalidCastException)
            {
                return 0;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally { this.miConexion.MiConexion.Close(); }
        }

        private double CostoVentaMasIco3(int idUsuario, DateTime fecha)
        {
            try
            {
                this.CargarComando("resumen_costo_usuario_ico");
                this.miComando.Parameters.AddWithValue("", idUsuario);
                this.miComando.Parameters.AddWithValue("", fecha);
                this.miConexion.MiConexion.Open();
                var costo = Convert.ToDouble(this.miComando.ExecuteScalar());
                this.miConexion.MiConexion.Close();
                this.miComando.Dispose();
                return costo;
            }
            catch (InvalidCastException)
            {
                return 0;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally { this.miConexion.MiConexion.Close(); }
        }

        private double CostoVentaMasIco3(int idUsuario, DateTime fecha, DateTime fecha2)
        {
            try
            {
                this.CargarComando("resumen_costo_usuario_ico");
                this.miComando.Parameters.AddWithValue("", idUsuario);
                this.miComando.Parameters.AddWithValue("", fecha);
                this.miComando.Parameters.AddWithValue("", fecha2);
                this.miConexion.MiConexion.Open();
                var costo = Convert.ToDouble(this.miComando.ExecuteScalar());
                this.miConexion.MiConexion.Close();
                this.miComando.Dispose();
                return costo;
            }
            catch (InvalidCastException)
            {
                return 0;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally { this.miConexion.MiConexion.Close(); }
        }





        public DataTable ResumenDeVentasCategoria(string codCategoria, DateTime fecha)
        {
            try
            {
                this.tVenta.Rows.Clear();
                var tabla = new DataTable();
                CargarAdapter("resumen_ventas_categoria");
                miAdapter.SelectCommand.Parameters.AddWithValue("", codCategoria);
                miAdapter.SelectCommand.Parameters.AddWithValue("", fecha);
                miAdapter.Fill(tabla);
                if (tabla.Rows.Count > 0)
                {
                    double costo = tabla.AsEnumerable().Sum(s => s.Field<double>("costo"));
                    double base_costo = tabla.AsEnumerable().Sum(s => s.Field<double>("base_costo"));
                    double base_ = tabla.AsEnumerable().Sum(s => s.Field<double>("base"));
                    double total = tabla.AsEnumerable().Sum(s => s.Field<double>("total"));
                    var row = this.tVenta.NewRow();
                    row["Base"] = base_;
                    row["Iva"] = total - base_;
                    row["Total"] = total;
                    row["IvaC"] = Convert.ToInt32(costo - base_costo);
                    row["TotalC"] = Convert.ToInt32(costo);
                    this.tVenta.Rows.Add(row);
                }
                return this.tVenta;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al consultar el resumen de ventas.\n" + ex.Message);
            }
        }

        public DataTable ResumenDeVentasCategoria(string codCategoria, DateTime fecha, DateTime fecha2)
        {
            try
            {
                this.tVenta.Rows.Clear();
                var tabla = new DataTable();
                CargarAdapter("resumen_ventas_categoria");
                miAdapter.SelectCommand.Parameters.AddWithValue("", codCategoria);
                miAdapter.SelectCommand.Parameters.AddWithValue("", fecha);
                miAdapter.SelectCommand.Parameters.AddWithValue("", fecha2);
                miAdapter.Fill(tabla);
                if (tabla.Rows.Count > 0)
                {
                    double costo = tabla.AsEnumerable().Sum(s => s.Field<double>("costo"));
                    double base_costo = tabla.AsEnumerable().Sum(s => s.Field<double>("base_costo"));
                    double base_ = tabla.AsEnumerable().Sum(s => s.Field<double>("base"));
                    double total = tabla.AsEnumerable().Sum(s => s.Field<double>("total"));
                    var row = this.tVenta.NewRow();
                    row["Base"] = base_;
                    row["Iva"] = total - base_;
                    row["Total"] = total;
                    row["IvaC"] = Convert.ToInt32(costo - base_costo);
                    row["TotalC"] = Convert.ToInt32(costo);
                    this.tVenta.Rows.Add(row);
                }
                return this.tVenta;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al consultar el resumen de ventas.\n" + ex.Message);
            }
        }

        /*
         * Codigo anterior
        public DataTable CalculoDeVentas(DataTable tableFacturas)
        {
            this.tVenta.Rows.Clear();
            foreach (DataRow fRow in tableFacturas.Rows) // itera las facturas
            {
                var tProductos = ProductoFacturaVenta(fRow["numero"].ToString(), true);
                foreach (DataRow pRow in tProductos.Rows) // itera los productos
                {
                    //  calculo de ventas
                    var row = this.tVenta.NewRow();
                    row["Total"] = pRow["Valor"];
                    row["Base"] = Convert.ToInt32(Convert.ToInt32(pRow["Valor"]) /
                        (1 + (UseObject.RemoveCharacter(pRow["Iva"].ToString(), '%') / 100)));
                    row["Iva"] = Convert.ToInt32(row["Total"]) - Convert.ToInt32(row["Base"]);

                    //var pcRow = ProductoCosto(pRow["Codigo"].ToString()).AsEnumerable().First();
                    //row["IvaC"] = Convert.ToInt32(Convert.ToDouble(pcRow["costo"]) * Convert.ToDouble(pcRow["iva"]) / 100);
                    //row["TotalC"] = Convert.ToInt32((Convert.ToDouble(pcRow["costo"]) + Convert.ToInt32(row["IvaC"])) *
                        //Convert.ToDouble(pRow["Cantidad"]));
                    int base_ = Convert.ToInt32(Convert.ToDouble(pRow["costo"]) /
                        (1 + (UseObject.RemoveCharacter(pRow["Iva"].ToString(), '%') / 100)));
                    row["IvaC"] = Convert.ToInt32(Convert.ToDouble(pRow["costo"]) - base_);
                    var j = row["IvaC"].ToString();
                    row["TotalC"] = Convert.ToInt32(Convert.ToDouble(pRow["costo"]) * Convert.ToDouble(pRow["Cantidad"]));
                    j = row["TotalC"].ToString();

                    row["IvaC"] = Convert.ToInt32(Convert.ToInt32(row["IvaC"]) * Convert.ToDouble(pRow["Cantidad"]));
                    j = row["IvaC"].ToString();

                    this.tVenta.Rows.Add(row);
                }
            }
            tableFacturas.Rows.Clear();
            return this.tVenta;
        }
        */

/*
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
        */
        public long SaldoDeCliente(string cliente)
        {
            var daoDevolucion = new DaoDevolucion();
            var daoRetencion = new DaoRetencion();
            int totalFact = 0;
            int retencion = 0;
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
                    var tRetenciones = daoRetencion.RetencionesAVenta(fRow["numero"].ToString());
                    retencion = 0;
                    foreach (DataRow rRow in tRetenciones.Rows)
                    {
                        retencion += Convert.ToInt32(totalFact * Convert.ToDouble(rRow["tarifa"]) / 100);
                    }
                    totalFact -= retencion;

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
            var daoRetencion = new DaoRetencion();
            int totalFact = 0;
            int retencion = 0;
            int pagosFact = 0;
            int saldoDev = 0;
            try
            {
                var tFactura = ConsultaPorEstadoYcliente(2, cliente);
                foreach (DataRow fRow in tFactura.Rows)
                {
                    /*var tProducto = ProductoFacturaVenta
                        (fRow["numero"].ToString(), Convert.ToBoolean(fRow["descto"]));*/
                    var tProducto = ProductoFacturaVenta
                        (Convert.ToInt32(fRow["id"]), Convert.ToBoolean(fRow["descto"]));
                    totalFact = Convert.ToInt32(tProducto.AsEnumerable().Sum(t => t.Field<double>("Valor")));
                    var tRetenciones = daoRetencion.RetencionesAVenta(fRow["numero"].ToString());
                    retencion = 0;
                    foreach (DataRow rRow in tRetenciones.Rows)
                    {
                        retencion += Convert.ToInt32(totalFact * Convert.ToDouble(rRow["tarifa"]) / 100);
                    }
                    totalFact -= retencion;

                    //pagosFact = GetTotalFormasDePagoDeFacturaVenta(fRow["numero"].ToString());
                    saldoDev = daoDevolucion.SaldoDevolucionVenta(fRow["numero"].ToString());

                    pagosFact = GetTotalFormasDePagoDeFacturaVenta(Convert.ToInt32(fRow["id"]));
                    //saldoDev = daoDevolucion.SaldoDevolucionVenta(Convert.ToInt32(fRow["id"]));

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

        public DataTable FacturasAnuladas(DateTime fecha)
        {
            var tabla = new DataTable();
            try
            {
                CargarAdapter("facturas_anuladas");
                miAdapter.SelectCommand.Parameters.AddWithValue("fech", fecha);
                miAdapter.Fill(tabla);
                return tabla;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al consultar las facturas anuladas.\n" + ex.Message);
            }
        }

        // Funciones de actualización 23/05/2018

        public List<IvaAnulado> VentasAnuladas(int idCaja, DateTime fecha)
        {
            try
            {
                var anuladas = new List<ProductoFacturaProveedor>();
                this.CargarComando("ventas_anuladas");
                this.miComando.Parameters.AddWithValue("", idCaja);
                this.miComando.Parameters.AddWithValue("", fecha);
                this.miConexion.MiConexion.Open();
                NpgsqlDataReader miReader = this.miComando.ExecuteReader();
                while (miReader.Read())
                {
                    var detalleAnulada = new ProductoFacturaProveedor();
                    detalleAnulada.IdFactura = miReader.GetInt32(0);
                    detalleAnulada.NumeroFactura = miReader.GetString(1);
                    detalleAnulada.Valor = miReader.GetDouble(7);
                    detalleAnulada.Producto.Descuento = miReader.GetDouble(8);
                    detalleAnulada.Producto.ValorIva = miReader.GetDouble(9);
                    detalleAnulada.Cantidad = miReader.GetDouble(10);
                    anuladas.Add(detalleAnulada);
                }
                this.miConexion.MiConexion.Close();
                this.miComando.Dispose();
                return this.DetalleIvaVentasAnuladas(anuladas);
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al consultar el IVA en ventas anuladas.\n" + ex.Message);
            }
            finally { this.miConexion.MiConexion.Close(); }
        }

        public List<IvaAnulado> VentasAnuladas(DateTime fecha)
        {
            try
            {
                var anuladas = new List<ProductoFacturaProveedor>();
                this.CargarComando("ventas_anuladas");
                this.miComando.Parameters.AddWithValue("", fecha);
                this.miConexion.MiConexion.Open();
                NpgsqlDataReader miReader = this.miComando.ExecuteReader();
                while (miReader.Read())
                {
                    var detalleAnulada = new ProductoFacturaProveedor();
                    detalleAnulada.IdFactura = miReader.GetInt32(0);
                    detalleAnulada.NumeroFactura = miReader.GetString(1);
                    detalleAnulada.Valor = miReader.GetDouble(7);
                    detalleAnulada.Producto.Descuento = miReader.GetDouble(8);
                    detalleAnulada.Producto.ValorIva = miReader.GetDouble(9);
                    detalleAnulada.Cantidad = miReader.GetDouble(10);
                    anuladas.Add(detalleAnulada);
                }
                this.miConexion.MiConexion.Close();
                this.miComando.Dispose();
                return this.DetalleIvaVentasAnuladas(anuladas);
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al consultar el IVA en ventas anuladas.\n" + ex.Message);
            }
            finally { this.miConexion.MiConexion.Close(); }
        }

        public List<IvaAnulado> VentasAnuladas(DateTime fecha, DateTime fecha2)
        {
            try
            {
                var anuladas = new List<ProductoFacturaProveedor>();
                this.CargarComando("ventas_anuladas_periodo");
                this.miComando.Parameters.AddWithValue("", fecha);
                this.miComando.Parameters.AddWithValue("", fecha2);
                this.miConexion.MiConexion.Open();
                NpgsqlDataReader miReader = this.miComando.ExecuteReader();
                while (miReader.Read())
                {
                    var detalleAnulada = new ProductoFacturaProveedor();
                    detalleAnulada.IdFactura = miReader.GetInt32(0);
                    detalleAnulada.NumeroFactura = miReader.GetString(1);
                    detalleAnulada.Valor = miReader.GetDouble(7);
                    detalleAnulada.Producto.Descuento = miReader.GetDouble(8);
                    detalleAnulada.Producto.ValorIva = miReader.GetDouble(9);
                    detalleAnulada.Cantidad = miReader.GetDouble(10);
                    anuladas.Add(detalleAnulada);
                }
                this.miConexion.MiConexion.Close();
                this.miComando.Dispose();
                return this.DetalleIvaVentasAnuladas(anuladas);
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al consultar el IVA en ventas anuladas.\n" + ex.Message);
            }
            finally { this.miConexion.MiConexion.Close(); }
        }

        private List<IvaAnulado> DetalleIvaVentasAnuladas(List<ProductoFacturaProveedor> anuladas)
        {
            var ivaAnuladas = new List<IvaAnulado>();
            foreach (var detalle in anuladas)
            {
                var ivaAnulado = new IvaAnulado();
                ivaAnulado.IdDevolucion = detalle.IdFactura;
                ivaAnulado.NoFactura = detalle.NumeroFactura;
                ivaAnulado.PorcentajeIva = detalle.Producto.ValorIva;
                ivaAnulado.BaseI = Math.Round((detalle.Valor - (detalle.Valor * detalle.Producto.Descuento / 100)), 1);
                ivaAnulado.ValorIva = Math.Round((ivaAnulado.BaseI * detalle.Producto.ValorIva / 100), 1);
                ivaAnulado.Total = Convert.ToInt32(
                    Convert.ToInt32(ivaAnulado.BaseI + ivaAnulado.ValorIva) * detalle.Cantidad);
                ivaAnuladas.Add(ivaAnulado);
            }
            var queryFrv = from data in ivaAnuladas
                           group data by new
                           {
                               IdDevolucion = data.IdDevolucion,
                               NoFactura = data.NoFactura,
                               PorcentajeIva = data.PorcentajeIva
                           }
                               into grupo orderby grupo.Key.IdDevolucion ascending, grupo.Key.PorcentajeIva ascending 
                               select new
                               {
                                   NoFactura = grupo.Key.NoFactura,
                                   PorcentajeIva = grupo.Key.PorcentajeIva,
                                   Total = grupo.Sum(s => s.Total)
                               };
            
            var dataIvaAnuladas = new List<IvaAnulado>();
            foreach (var ivaAnulado in queryFrv)
            {
                dataIvaAnuladas.Add(new IvaAnulado
                {
                    NoFactura = ivaAnulado.NoFactura,
                    PorcentajeIva = ivaAnulado.PorcentajeIva,
                    BaseI = Math.Round(ivaAnulado.Total / (1 + (ivaAnulado.PorcentajeIva / 100)), 0),
                    ValorIva = ivaAnulado.Total - Math.Round(ivaAnulado.Total / (1 + (ivaAnulado.PorcentajeIva / 100)), 0),
                    Total = ivaAnulado.Total
                });
            }
            return dataIvaAnuladas;
        }

        // Fin funciones de actualización 23/05/2018

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
            var daoRetencion = new DaoRetencion();
            var daoIngreso = new DaoIngreso();
            try
            {
                facturas = ConsultaActivasPorCliente(cliente);
                var qFactura = from data in facturas.AsEnumerable()
                               orderby data.Field<DateTime>("fecha") ascending,
                                       data.Field<long>("serie") ascending
                               select data;
                foreach (DataRow fRow in qFactura)
                {
                    if (monto > 0)
                    {
                        //var num = fRow["numero"].ToString();
                        //var productos = ProductoFacturaVenta(fRow["numero"].ToString(), Convert.ToBoolean(fRow["descto"]));
                        var productos = ProductoFacturaVenta(Convert.ToInt32(fRow["id"]), Convert.ToBoolean(fRow["descto"]));
                        var subTotal = Convert.ToInt32(productos.AsEnumerable().Sum
                            (s => (s.Field<double>("ValorUnitario") * s.Field<double>("Cantidad"))));
                        var valorFactura = Convert.ToInt32(
                            productos.AsEnumerable().Sum(s => s.Field<double>("Valor")));
                        var tRetenciones = daoRetencion.RetencionesAVenta(fRow["numero"].ToString());
                        var retencion = 0;
                        foreach (DataRow rRow in tRetenciones.Rows)
                        {
                            retencion += Convert.ToInt32(subTotal * Convert.ToDouble(rRow["tarifa"]) / 100);
                        }
                        valorFactura -= retencion;

                        var pPago = GetTotalFormasDePagoDeFacturaVenta(fRow["numero"].ToString());
                        var saldoDev = daoDevolucion.SaldoDevolucionVenta(fRow["numero"].ToString());
                        if (valorFactura > (pPago + saldoDev))
                        {
                            pago.IdFactura = Convert.ToInt32(fRow["id"]);
                            pago.NumeroFactura = fRow["numero"].ToString();
                            if (monto > (valorFactura - (pPago + saldoDev)))
                            {
                                pago.Valor = valorFactura - (pPago + saldoDev);
                                pago.Pago = valorFactura - (pPago + saldoDev);
                                monto -= (valorFactura - (pPago + saldoDev));
                            }
                            else
                            {
                                pago.Valor = monto;
                                pago.Pago = Convert.ToInt32(monto);
                                monto = 0;
                            }
                            arrRelacion.Add(daoPago.IngresarPagoAFactura(pago, true, false));
                            arrFacturas.Add(fRow["numero"].ToString());
                        }
                    }
                    else
                    {
                        break;
                    }
                }
                var f = "";
                foreach (string f_ in arrFacturas)
                {
                    f += f_ + ", ";
                }
                ingreso.Concepto += f;
                ingreso.Saldo = SaldoPorCliente(2, cliente);
               /* foreach (var relacion in arrRelacion)
                {
                    ingreso.Relacion = relacion;
                    daoIngreso.Ingresar(ingreso, true);
                }
                midaoConsecutivo.ActualizarConsecutivo("Ingreso");*/
                //miDaoIngreso.IngresarAcumulado(pago.Caja.Id, pago.Fecha, ingreso.Valor);
                return ingreso.Concepto;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void IngresarPagoGeneral(string nitCliente, FormaPago pago, Ingreso ingreso, List<FacturaVenta> cartera)
        {
            try
            {
                string facturas = "";
                var miDaoPago = new DaoFormaPago();
                var monto = pago.Valor;
                
                foreach (var venta in cartera.OrderBy(c => c.Id))
                {
                    if (monto > 0)
                    {
                        pago.IdFactura = venta.Id;
                        pago.NumeroFactura = venta.Numero;
                        if (monto > venta.Saldo)
                        {
                            pago.Valor = pago.Pago = venta.Saldo;
                            monto -= venta.Saldo;
                            venta.Saldo = 0;
                        }
                        else
                        {
                            pago.Valor = monto;
                            pago.Pago = Convert.ToInt32(monto);
                            monto = 0;
                            venta.Saldo = venta.Saldo - Convert.ToInt32(pago.Valor);
                        }
                        miDaoPago.IngresarPagoAFactura(pago, true, false);
                        facturas += venta.Numero + ", ";
                        ingreso.Concepto += venta.Numero + ", ";
                    }
                    else
                    {
                        break;
                    }
                }
                ingreso.Saldo = cartera.Sum(s => s.Saldo);
                //ingreso.Saldo = CarteraCliente(2, nitCliente).Sum(s => s.Saldo);
                //ingreso.Saldo = SaldoPorCliente(2, nitCliente);
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al realizar el abono al cliente\n" + ex.Message);
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
                row_["Costo"] = Convert.ToInt32(row["costo"]);
                row_["Codigo"] = row["Codigo"];
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

                row_["SubTotal"] = Math.Round(
                    (Convert.ToDouble(row_["ValorUnitario"]) * Convert.ToDouble(row["Cantidad"])), 1);

                row_["Iva"] = row["Iva"].ToString() + "%";

                double vIva = Math.Round(
                    (Convert.ToDouble(row_["ValorMenosDescto"]) * Convert.ToDouble(row["Iva"]) / 100), 1);

                row_["ValorIva"] = vIva;
                row_["TotalMasIva"] = Convert.ToInt32(Convert.ToDouble(row_["ValorMenosDescto"]) + vIva);
                row_["Valor"] = //Convert.ToInt32(
                                Convert.ToInt32(
                                Convert.ToDouble(row_["TotalMasIva"]) * Convert.ToDouble(row["Cantidad"]));
                row_["Retorno"] = row["retorno"];
                miTabla.Rows.Add(row_);
            }
            tabla.Clear();
            tabla = null;
            return miTabla;
        }

        
        public DataTable ProductoFacturaVenta(int idFactura, bool descuento)
        {
            var miDaoProducto = new DaoProductoFacturaVenta();
            var miTabla = CrearDataTable();
            var tabla = miDaoProducto.ProductoFacturaVenta(idFactura);
            foreach (DataRow row in tabla.Rows)
            {
                var row_ = miTabla.NewRow();
                row_["Costo"] = Convert.ToInt32(row["costo"]);
                row_["Codigo"] = row["Codigo"];
                row_["Cantidad"] = row["Cantidad"];
                row_["ValorUnitario"] = row["Valor"];

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

                row_["SubTotal"] = Math.Round(
                    (Convert.ToDouble(row_["ValorUnitario"]) * Convert.ToDouble(row["Cantidad"])), 1);

                row_["Iva"] = row["Iva"].ToString() + "%";

                double vIva = Math.Round(
                    (Convert.ToDouble(row_["ValorMenosDescto"]) * Convert.ToDouble(row["Iva"]) / 100), 1);

                row_["ValorIva"] = vIva;

//                    row_["TotalMasIva"] = Convert.ToInt32(Convert.ToDouble(row_["ValorMenosDescto"]) + vIva);
                // Antes.  30/12/2018
                /*row_["TotalMasIva"] = UseObject.Aproximar(Convert.ToInt32(Convert.ToDouble(row_["ValorMenosDescto"]) + vIva),
                                                          Convert.ToBoolean(AppConfiguracion.ValorSeccion("tipo_aprox_precio")));*/

                //if (Convert.ToDouble(row["Descuento"]) > 0)  // descuento mayor a cero
                //{
                    if (Convert.ToBoolean(AppConfiguracion.ValorSeccion("redondeo_precio_dos")))
                    {
                        row_["TotalMasIva"] = UseObject.Aproximar(
                            Convert.ToInt32(Convert.ToDouble(row_["ValorMenosDescto"]) + vIva) + Convert.ToInt32(row["impoconsumo"]),
                            Convert.ToBoolean(AppConfiguracion.ValorSeccion("tipo_aprox_precio")));
                    }
                    else
                    {
                        row_["TotalMasIva"] = 
                            Convert.ToInt32(Convert.ToDouble(row_["ValorMenosDescto"]) + vIva) + Convert.ToInt32(row["impoconsumo"]);
                    }
                //}
                /*else
                {
                    row_["TotalMasIva"] = UseObject.Aproximar(
                        Convert.ToInt32(Convert.ToDouble(row_["ValorMenosDescto"]) + vIva) + Convert.ToInt32(row["impoconsumo"]), 
                        Convert.ToBoolean(AppConfiguracion.ValorSeccion("tipo_aprox_precio")));
                }*/

                row_["Valor"] = //Convert.ToInt32(
                                Convert.ToInt32(
                                Convert.ToDouble(row_["TotalMasIva"]) * Convert.ToDouble(row["Cantidad"]));
                row_["Retorno"] = row["retorno"];
                miTabla.Rows.Add(row_);
            }
            tabla.Clear();
            tabla = null;
            return miTabla;
        }
        

        public DataTable PrintProductoFacturaVenta(int id, bool descuento)
        {
            // 1. Imprime.
            // 2. Comprobante e Informe.
            var miDaoProducto = new DaoProductoFacturaVenta();
            var miTabla = CrearDataTable();
            var tabla = miDaoProducto.ProductoFacturaVenta(id);
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
            miTabla.Columns.Add(new DataColumn("SubTotal", typeof(double)));
            miTabla.Columns.Add(new DataColumn("Iva", typeof(string)));
            miTabla.Columns.Add(new DataColumn("ValorIva", typeof(double)));
            miTabla.Columns.Add(new DataColumn("TotalMasIva", typeof(double)));
            miTabla.Columns.Add(new DataColumn("Valor", typeof(double)));

            miTabla.Columns.Add(new DataColumn("Costo", typeof(int)));
            miTabla.Columns.Add(new DataColumn("Retorno", typeof(bool)));
            return miTabla;
        }

        private void TablasResumen()
        {
            this.tFactura = new DataTable();
            this.tFacturas = new DataTable();

            this.tVenta = new DataTable();
            tVenta.Columns.Add(new DataColumn("Base", typeof(double)));
            tVenta.Columns.Add(new DataColumn("Iva", typeof(double)));
            tVenta.Columns.Add(new DataColumn("Total", typeof(double)));

            tVenta.Columns.Add(new DataColumn("IvaC", typeof(int)));
            tVenta.Columns.Add(new DataColumn("TotalC", typeof(Int64)));
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

        public int GetTotalFormasDePagoDeFacturaVenta(int idFactura)
        {
            var miDaoFromaPago = new DaoFormaPago();
            var tabla = miDaoFromaPago.FormasDePagoDeFacturaVentaId(idFactura);
            var total = 0;
            foreach (DataRow row in tabla.Rows)
            {
                total = total + Convert.ToInt32(row["Pago"]);
            }
            return total;
        }


        /// <summary>
        /// Anula una Factura de Venta.
        /// </summary>
        /// <param name="numero">Número de la Factura de Venta a anular.</param>
        public void AnularFactura(FacturaVenta factura, bool carga)
        {
            var miDaoProducto = new DaoProductoFacturaVenta();
            var miDaoInventario = new DaoInventario();
            try
            {
                CargarComando(AnulaFactura_);
               // miComando.Parameters.AddWithValue("numero", factura.Numero);   Edicion 01-01-2017
                miComando.Parameters.AddWithValue("", factura.Id);
                miConexion.MiConexion.Open();
                miComando.ExecuteNonQuery();
                miConexion.MiConexion.Close();
                miComando.Dispose();
                IngresarFacturaAnulada(factura);
                //EliminarPago(factura.Numero);   Edicion 01-01-2017
                EliminarPago(factura.Id);
                if (carga)
                {
                    //var productos = miDaoProducto.ProductoFacturaVenta(factura.Numero);   Edicion 01-01-2017
                    var productos = miDaoProducto.ProductoFacturaVenta(factura.Id);
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

        public void IngresarFacturaAnulada(FacturaVenta factura)
        {
            try
            {
                CargarComando("insertar_anulada");
                miComando.Parameters.AddWithValue("idcaja", factura.Caja.Id);
                miComando.Parameters.AddWithValue("idusuario", factura.Usuario.Id);
                miComando.Parameters.AddWithValue("fecha", factura.FechaIngreso);
                miComando.Parameters.AddWithValue("hora", factura.FechaIngreso.TimeOfDay);
                miComando.Parameters.AddWithValue("numero", factura.Numero);
                miComando.Parameters.AddWithValue("cliente", factura.Proveedor.NitProveedor);
                miComando.Parameters.AddWithValue("valor", factura.Valor);
                miComando.Parameters.AddWithValue("id", factura.Id);
                miConexion.MiConexion.Open();
                miComando.ExecuteNonQuery();
                miConexion.MiConexion.Close();
                miComando.Dispose();
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al anular la factura.\n" + ex.Message);
            }
            finally { miConexion.MiConexion.Close(); }
        }

        public void EliminarPago(string numero)
        {
            try
            {
                CargarComando("eliminar_pago_factura_venta");
                miComando.Parameters.AddWithValue("numero", numero);
                miConexion.MiConexion.Open();
                miComando.ExecuteNonQuery();
                miConexion.MiConexion.Close();
                miComando.Dispose();
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al eliminar el pago de la factura.\n" + ex.Message);
            }
            finally { miConexion.MiConexion.Close(); }
        }

        // Edicion 01-01-2017
        public void EliminarPago(int idFactura)
        {
            try
            {
                CargarComando("eliminar_pago_factura_venta");
                miComando.Parameters.AddWithValue("", idFactura);
                miConexion.MiConexion.Open();
                miComando.ExecuteNonQuery();
                miConexion.MiConexion.Close();
                miComando.Dispose();
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al eliminar el pago de la factura.\n" + ex.Message);
            }
            finally { miConexion.MiConexion.Close(); }
        }


        // consultas de productos vendidos por debajo del precio de venta.

        public DataTable VentasDebajoPrecio(DateTime fecha)
        {
            try
            {
                var tabla = new DataTable();
                CargarAdapter("ventas_debajo_precio");
                miAdapter.SelectCommand.Parameters.AddWithValue("", fecha);
                miAdapter.Fill(tabla);
                return UnionVentasDebajoPrecio(tabla);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public DataTable VentasDebajoPrecio(DateTime fecha, DateTime fecha2)
        {
            try
            {
                var tabla = new DataTable();
                CargarAdapter("ventas_debajo_precio");
                miAdapter.SelectCommand.Parameters.AddWithValue("", fecha);
                miAdapter.SelectCommand.Parameters.AddWithValue("", fecha2);
                miAdapter.Fill(tabla);
                return UnionVentasDebajoPrecio(tabla);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        private DataTable UnionVentasDebajoPrecio(DataTable tabla)
        {
            var tData = new DataTable();
            tData.Columns.Add(new DataColumn("fecha", typeof(DateTime)));
            tData.Columns.Add(new DataColumn("numero", typeof(string)));
            tData.Columns.Add(new DataColumn("caja", typeof(int)));
            tData.Columns.Add(new DataColumn("codigo", typeof(string)));
            tData.Columns.Add(new DataColumn("producto", typeof(string)));
            tData.Columns.Add(new DataColumn("cantidad", typeof(double)));
            tData.Columns.Add(new DataColumn("valor", typeof(int)));
            tData.Columns.Add(new DataColumn("venta", typeof(int)));
            tData.Columns.Add(new DataColumn("diferencia", typeof(int)));
            tData.Columns.Add(new DataColumn("total_diferencia", typeof(int)));

            foreach (DataRow row in tabla.Rows)
            {
                var dRow = tData.NewRow();
                dRow["fecha"] = row["fecha"];
                dRow["numero"] = row["numero"];
                dRow["caja"] = row["caja"];
                dRow["codigo"] = row["codigo"];
                dRow["producto"] = row["producto"];
                dRow["cantidad"] = row["cantidad"];
                dRow["valor"] = Convert.ToInt32(row["total_real"]);
                dRow["venta"] = Convert.ToInt32(row["total"]);
                dRow["diferencia"] = Convert.ToInt32(row["total_real"]) - Convert.ToInt32(row["total"]);
                dRow["total_diferencia"] = Convert.ToInt32(Convert.ToInt32(dRow["diferencia"]) * Convert.ToDouble(row["cantidad"]));
                tData.Rows.Add(dRow);
            }

            return tData;
        }

        #region Consulta venta de producto

        public List<int> Anios()
        {
            try
            {
                var anios = new List<int>();
                int minAnio = this.MinFecha().Year;
                int anioActual = DateTime.Now.Year;
                do
                {
                    anios.Add(minAnio);
                    minAnio++;
                }
                while (minAnio <= anioActual);
                return anios;
            }
            catch (Exception ex)
            {
                throw new Exception("" + ex.Message);
            }
        }

        public List<Producto> VentaProductos(DateTime fecha)
        {
            this.CargarComando("consulta_venta_productos");
            this.miComando.Parameters.AddWithValue("", fecha);
            return this.CalculosVentaProductos();
        }

        public List<Producto> VentaProductos(DateTime fecha, int idMarca)
        {
            this.CargarComando("consulta_venta_productos");
            this.miComando.Parameters.AddWithValue("", fecha);
            this.miComando.Parameters.AddWithValue("", idMarca);
            return this.CalculosVentaProductos();
        }

        public List<Producto> VentaProductos(DateTime fecha, string codCategoria, int idMarca)
        {
            this.CargarComando("consulta_venta_productos");
            this.miComando.Parameters.AddWithValue("", fecha);
            this.miComando.Parameters.AddWithValue("", codCategoria);
            this.miComando.Parameters.AddWithValue("", idMarca);
            return this.CalculosVentaProductos();
        }

        public List<Producto> VentaProductos(DateTime fecha, string codCategoria)
        {
            this.CargarComando("consulta_venta_productos");
            this.miComando.Parameters.AddWithValue("", fecha);
            this.miComando.Parameters.AddWithValue("", codCategoria);
            return this.CalculosVentaProductos();
        }

        public List<Producto> VentaProductos(DateTime fecha, DateTime fecha2)
        {
            this.CargarComando("consulta_venta_productos_periodo");
            this.miComando.Parameters.AddWithValue("", fecha);
            this.miComando.Parameters.AddWithValue("", fecha2);
            return this.CalculosVentaProductos();
        }

        public List<Producto> VentaProductos(DateTime fecha, DateTime fecha2, int idMarca)
        {
            this.CargarComando("consulta_venta_productos_periodo");
            this.miComando.Parameters.AddWithValue("", fecha);
            this.miComando.Parameters.AddWithValue("", fecha2);
            this.miComando.Parameters.AddWithValue("", idMarca);
            return this.CalculosVentaProductos();
        }

        public List<Producto> VentaProductos(DateTime fecha, DateTime fecha2, string codCategoria, int idMarca)
        {
            this.CargarComando("consulta_venta_productos_periodo");
            this.miComando.Parameters.AddWithValue("", fecha);
            this.miComando.Parameters.AddWithValue("", fecha2);
            this.miComando.Parameters.AddWithValue("", codCategoria);
            this.miComando.Parameters.AddWithValue("", idMarca);
            return this.CalculosVentaProductos();
        }

        public List<Producto> VentaProductos(DateTime fecha, DateTime fecha2, string codCategoria)
        {
            this.CargarComando("consulta_venta_productos_periodo");
            this.miComando.Parameters.AddWithValue("", fecha);
            this.miComando.Parameters.AddWithValue("", fecha2);
            this.miComando.Parameters.AddWithValue("", codCategoria);
            return this.CalculosVentaProductos();
        }

        private List<Producto> CalculosVentaProductos()
        {
            try
            {
                var productos = new List<Producto>();
                this.miConexion.MiConexion.Open();
                NpgsqlDataReader reader = this.miComando.ExecuteReader();
                while (reader.Read())
                {
                    var producto = new Producto();
                    producto.CodigoInternoProducto = reader.GetString(3);
                    producto.NombreProducto = reader.GetString(4);
                    producto.Cantidad = reader.GetDouble(5);
                    producto.ValorVentaProducto = reader.GetDouble(6);
                    productos.Add(producto);
                }
                this.miConexion.MiConexion.Close();
                this.miComando.Dispose();

                foreach (Producto p in productos)
                {
                    p.ValorCosto = Math.Round(p.ValorVentaProducto / p.Cantidad, 1);
                }
                return productos;

               /* while (reader.Read())
                {
                    var producto = new Producto();
                    producto.CodigoInternoProducto = reader.GetString(0);
                    producto.NombreProducto = reader.GetString(1);
                    producto.Cantidad = reader.GetDouble(2);
                    producto.ValorCosto = reader.GetDouble(3);
                    producto.Descuento = reader.GetDouble(4);
                    producto.ValorIva = reader.GetDouble(5);
                    producto.Impoconsumo = reader.GetDouble(6);
                    productos.Add(producto);
                }
                this.miConexion.MiConexion.Close();
                this.miComando.Dispose();

                foreach (Producto p in productos)
                {
                    p.ValorCosto = Math.Round((p.ValorCosto - (p.ValorCosto * p.Descuento / 100)), 1);
                    p.ValorVentaProducto = Convert.ToInt32(p.Cantidad *
                        UseObject.Aproximar(Convert.ToInt32(
                        p.ValorCosto + Math.Round((p.ValorCosto * p.ValorIva / 100) + p.Impoconsumo, 1)), this.AproximacionPrecio));
                }
                var query = productos
                    .GroupBy(p => new
                    {
                        p.CodigoInternoProducto,
                        p.NombreProducto
                    })
                    .Select(p => new Producto
                    {
                        CodigoInternoProducto = p.Key.CodigoInternoProducto,
                        NombreProducto = p.Key.NombreProducto,
                        Cantidad = p.Sum(p_ => p_.Cantidad),
                        ValorVentaProducto = p.Sum(p_ => p_.ValorVentaProducto),
                        ValorCosto = Convert.ToInt32(p.Sum(p_ => p_.ValorVentaProducto) / p.Sum(p_ => p_.Cantidad))
                    }).ToList();
                return query;*/
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al consultar los productos.\n" + ex.Message);
            }
            finally { this.miConexion.MiConexion.Close(); }
        }

        #endregion

        #region Consulta venta de productos por clasificación de clientes

        // Periodo + Clasificacion
        public DataTable ConsultaVentasClasificacionCliente(DateTime fecha, DateTime fecha2, int idClasificacion)
        {
            try
            {
                var tDatos = new DataTable();
                CargarAdapter("consulta_ventas_productos_cliente_clasificacion");
                miAdapter.SelectCommand.Parameters.AddWithValue("", fecha);
                miAdapter.SelectCommand.Parameters.AddWithValue("", fecha2);
                miAdapter.SelectCommand.Parameters.AddWithValue("", idClasificacion);
                miAdapter.Fill(tDatos);
                return tDatos;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        // Periodo + Clasificacion + Categoria *
        public DataTable ConsultaVentasClasificacionCliente(DateTime fecha, DateTime fecha2, int idClasificacion, string codCategoria)
        {
            try
            {
                var tDatos = new DataTable();
                CargarAdapter("consulta_ventas_productos_cliente_clasificacion");
                miAdapter.SelectCommand.Parameters.AddWithValue("", fecha);
                miAdapter.SelectCommand.Parameters.AddWithValue("", fecha2);
                miAdapter.SelectCommand.Parameters.AddWithValue("", idClasificacion);
                miAdapter.SelectCommand.Parameters.AddWithValue("", codCategoria);
                miAdapter.Fill(tDatos);
                return tDatos;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        // Periodo + Clasificacion + Marca
        public DataTable ConsultaVentasClasificacionCliente(DateTime fecha, DateTime fecha2, int idClasificacion, int idMarca)
        {
            try
            {
                var tDatos = new DataTable();
                CargarAdapter("consulta_ventas_productos_cliente_clasificacion");
                miAdapter.SelectCommand.Parameters.AddWithValue("", fecha);
                miAdapter.SelectCommand.Parameters.AddWithValue("", fecha2);
                miAdapter.SelectCommand.Parameters.AddWithValue("", idClasificacion);
                miAdapter.SelectCommand.Parameters.AddWithValue("", idMarca);
                miAdapter.Fill(tDatos);
                return tDatos;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        // Periodo + Clasificacion + Categoria + Marca
        public DataTable ConsultaVentasClasificacionCliente(DateTime fecha, DateTime fecha2, int idClasificacion, string codCategoria, int idMarca)
        {
            try
            {
                var tDatos = new DataTable();
                CargarAdapter("consulta_ventas_productos_cliente_clasificacion");
                miAdapter.SelectCommand.Parameters.AddWithValue("", fecha);
                miAdapter.SelectCommand.Parameters.AddWithValue("", fecha2);
                miAdapter.SelectCommand.Parameters.AddWithValue("", idClasificacion);
                miAdapter.SelectCommand.Parameters.AddWithValue("", codCategoria);
                miAdapter.SelectCommand.Parameters.AddWithValue("", idMarca);
                miAdapter.Fill(tDatos);
                return tDatos;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        // Periodo + Clasificacion + Producto
        public DataTable ConsultaVentasClasificacionClienteProducto(DateTime fecha, DateTime fecha2, int idClasificacion, string codProducto)
        {
            try
            {
                var tDatos = new DataTable();
                CargarAdapter("consulta_ventas_productos_cliente_clasificacion_producto");
                miAdapter.SelectCommand.Parameters.AddWithValue("", fecha);
                miAdapter.SelectCommand.Parameters.AddWithValue("", fecha2);
                miAdapter.SelectCommand.Parameters.AddWithValue("", idClasificacion);
                miAdapter.SelectCommand.Parameters.AddWithValue("", codProducto);
                miAdapter.Fill(tDatos);
                return tDatos;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        #endregion

        #region Consulta venta de productos por Usuario

        public DataTable ConsultaVentasProductosUsuario(DateTime fecha, DateTime fecha2, int idUsuario)
        {
            try
            {
                var tDatos = new DataTable();
                CargarAdapter("consulta_ventas_productos_usuario");
                miAdapter.SelectCommand.Parameters.AddWithValue("", fecha);
                miAdapter.SelectCommand.Parameters.AddWithValue("", fecha2);
                miAdapter.SelectCommand.Parameters.AddWithValue("", idUsuario);
                miAdapter.Fill(tDatos);
                return tDatos;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public DataTable ConsultaVentasProductosUsuario(DateTime fecha, DateTime fecha2, int idUsuario, string codCategoria)
        {
            try
            {
                var tDatos = new DataTable();
                CargarAdapter("consulta_ventas_productos_usuario");
                miAdapter.SelectCommand.Parameters.AddWithValue("", fecha);
                miAdapter.SelectCommand.Parameters.AddWithValue("", fecha2);
                miAdapter.SelectCommand.Parameters.AddWithValue("", idUsuario);
                miAdapter.SelectCommand.Parameters.AddWithValue("", codCategoria);
                miAdapter.Fill(tDatos);
                return tDatos;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public DataTable ConsultaVentasProductosUsuario(DateTime fecha, DateTime fecha2, int idUsuario, int idMarca)
        {
            try
            {
                var tDatos = new DataTable();
                CargarAdapter("consulta_ventas_productos_usuario");
                miAdapter.SelectCommand.Parameters.AddWithValue("", fecha);
                miAdapter.SelectCommand.Parameters.AddWithValue("", fecha2);
                miAdapter.SelectCommand.Parameters.AddWithValue("", idUsuario);
                miAdapter.SelectCommand.Parameters.AddWithValue("", idMarca);
                miAdapter.Fill(tDatos);
                return tDatos;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public DataTable ConsultaVentasProductosUsuario(DateTime fecha, DateTime fecha2, int idUsuario, string codCategoria, int idMarca)
        {
            try
            {
                var tDatos = new DataTable();
                CargarAdapter("consulta_ventas_productos_usuario");
                miAdapter.SelectCommand.Parameters.AddWithValue("", fecha);
                miAdapter.SelectCommand.Parameters.AddWithValue("", fecha2);
                miAdapter.SelectCommand.Parameters.AddWithValue("", idUsuario);
                miAdapter.SelectCommand.Parameters.AddWithValue("", codCategoria);
                miAdapter.SelectCommand.Parameters.AddWithValue("", idMarca);
                miAdapter.Fill(tDatos);
                return tDatos;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        #endregion 



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

        // Ajustar costo de productos vendidos.
        public void AjustarCosto()
        {
            try
            {
                var tProduVentas = new DataTable();
                string sql =
                "SELECT producto_factura_venta.idproducto_factura_venta AS id, producto_factura_venta.codigointernoproducto " +
                "AS codigo FROM producto_factura_venta;";
                miAdapter = new NpgsqlDataAdapter(sql, miConexion.MiConexion);
                miAdapter.Fill(tProduVentas);
                foreach (DataRow pRow in tProduVentas.Rows)
                {
                    var costo = CostoDeProducto(pRow["codigo"].ToString(), 0);
                    sql = "UPDATE producto_factura_venta SET costo = " + costo + " WHERE idproducto_factura_venta = " + Convert.ToInt32(pRow["id"]) + ";";
                    miConexion.MiConexion.Close();
                    miComando = new NpgsqlCommand();
                    miComando.Connection = miConexion.MiConexion;
                    miComando.CommandType = CommandType.Text;
                    miComando.CommandText = sql;
                    miConexion.MiConexion.Open();
                    miComando.ExecuteNonQuery();
                    miConexion.MiConexion.Close();
                    miComando.Dispose();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void VistaFaltante()
        {
            string vista = "";
            var tabla127 = new DataTable();
            string sql = "SELECT * FROM fun_1172;";
            miAdapter = new NpgsqlDataAdapter(sql, miConexion.MiConexion);
            miAdapter.SelectCommand.CommandType = CommandType.Text;
            miAdapter.Fill(tabla127);

            var tabla128 = new DataTable();
            sql = "SELECT * FROM fun_1176;";
            miAdapter = new NpgsqlDataAdapter(sql, miConexion.MiConexion);
            miAdapter.SelectCommand.CommandType = CommandType.Text;
            miAdapter.Fill(tabla128);

            foreach (DataRow row128 in tabla128.Rows)
            {
                var query = tabla127.AsEnumerable().Where(t => t.Field<string>("nombre").Equals(row128["nombre"].ToString()));
                if (query.ToArray().Length.Equals(0))
                {
                    vista += row128["nombre"].ToString() + " ,";
                }
            }
            var rta = vista;
        }


        // codigo para verificar
        public DataTable PagosDeFactura(int idEstado, DateTime fecha, DateTime fecha2)
        {
            try
            {
                var tPagos = new DataTable();
                tPagos.Columns.Add(new DataColumn("id", typeof(int)));
                tPagos.Columns.Add(new DataColumn("idfactura", typeof(int)));
                tPagos.Columns.Add(new DataColumn("numero", typeof(string)));
                tPagos.Columns.Add(new DataColumn("idusuario", typeof(int)));
                tPagos.Columns.Add(new DataColumn("idcaja", typeof(int)));
                tPagos.Columns.Add(new DataColumn("idturno", typeof(int)));
                tPagos.Columns.Add(new DataColumn("idformap", typeof(int)));
                tPagos.Columns.Add(new DataColumn("fecha", typeof(DateTime)));
                tPagos.Columns.Add(new DataColumn("hora", typeof(DateTime)));
                tPagos.Columns.Add(new DataColumn("valorf", typeof(int)));
                tPagos.Columns.Add(new DataColumn("valorpago", typeof(int)));

                var sql =
                "SELECT factura_forma_pago.idfactura_forma_pago, factura_forma_pago.numerofactura_venta, factura_forma_pago.idusuario, factura_forma_pago.idcaja, " +
                "factura_forma_pago.idforma_pago, factura_forma_pago.fechafactura_forma_pago, factura_forma_pago.hora, factura_forma_pago.valorfactura_forma_pago, " +
                "factura_forma_pago.idturno, factura_forma_pago.valor_pago, factura_forma_pago.id_factura " +
                "FROM factura_forma_pago, factura_venta WHERE " +
                "factura_venta.id = factura_forma_pago.id_factura AND " +
                "factura_venta.idestado = " + idEstado + " AND " +
 "factura_forma_pago.fechafactura_forma_pago BETWEEN '" + fecha.ToShortDateString() + "' AND '" + fecha2.ToShortDateString() + "' ORDER BY id_factura;";
                var tabla = new DataTable();
                miAdapter = new NpgsqlDataAdapter(sql, miConexion.MiConexion);
                miAdapter.SelectCommand.CommandType = CommandType.Text;
                miAdapter.Fill(tabla);

                foreach (DataRow trow in tabla.Rows)
                {
                    sql = "SELECT factura_forma_pago.idfactura_forma_pago, factura_forma_pago.numerofactura_venta, factura_forma_pago.idusuario, " +
      "factura_forma_pago.idcaja, factura_forma_pago.idforma_pago, factura_forma_pago.fechafactura_forma_pago, factura_forma_pago.hora, " +
      "factura_forma_pago.valorfactura_forma_pago, factura_forma_pago.idturno, factura_forma_pago.valor_pago, factura_forma_pago.id_factura " +
    "FROM factura_forma_pago WHERE factura_forma_pago.id_factura = " + Convert.ToInt32(trow["id_factura"]) + ";";
                    var tabla1 = new DataTable();
                    miAdapter = new NpgsqlDataAdapter(sql, miConexion.MiConexion);
                    miAdapter.SelectCommand.CommandType = CommandType.Text;
                    miAdapter.Fill(tabla1);
                    if (tabla1.Rows.Count > 1)
                    {
                        foreach (DataRow trow1 in tabla1.Rows)
                        {
                            var pRow = tPagos.NewRow();
                            pRow["id"] = trow1["idfactura_forma_pago"];
                            pRow["idfactura"] = trow1["id_factura"];
                            pRow["numero"] = trow1["numerofactura_venta"];
                            pRow["idusuario"] = trow1["idusuario"];
                            pRow["idcaja"] = trow1["idcaja"];
                            pRow["idturno"] = trow1["idturno"];
                            pRow["idformap"] = trow1["idforma_pago"];
                            pRow["fecha"] = trow1["fechafactura_forma_pago"];
                            pRow["hora"] = trow1["hora"];
                            pRow["valorf"] = trow1["valorfactura_forma_pago"];
                            pRow["valorpago"] = trow1["valor_pago"];
                            tPagos.Rows.Add(pRow);
                        }
                    }
                }
                return tPagos;
            }
            catch (Exception ex)
            {
                throw new Exception("" + ex.Message);
            }
        }

        public void AjusteVentaIva(int idIva)
        {
            try
            {
                string sql = "SELECT producto.codigointernoproducto AS codigo, producto.valorventaproducto AS venta " +
        "FROM producto, iva WHERE iva.idiva = producto.idiva AND iva.valoriva = 16 ORDER BY producto.nombreproducto ASC;";

                this.miAdapter = new NpgsqlDataAdapter(sql, miConexion.MiConexion);
                this.miAdapter.SelectCommand.CommandType = CommandType.Text;
                var tProductos = new DataTable();
                this.miAdapter.Fill(tProductos);

                foreach (DataRow rProducto in tProductos.Rows)
                {
                    if (rProducto["codigo"].ToString() == "3113")//"3197"
                    {
                        var j = "";
                    }
                    if (rProducto["codigo"].ToString() == "3197")//"3197"
                    {
                        var j_ = "";
                    }
                    int venta = Convert.ToInt32(rProducto["venta"]);
                   // var d = Convert.ToDouble((Convert.ToDouble(venta) * 3) / 100);
                    double aumento = Math.Round(Convert.ToDouble((Convert.ToDouble(venta) * 3) / 100), 1);
                    double ventaNew = Math.Round(Convert.ToDouble(venta + aumento), 0);
                    int ventaNew_ =
                       UseObject.Aproximar(Convert.ToInt32(ventaNew), Convert.ToBoolean(AppConfiguracion.ValorSeccion("tipo_aprox_precio")));

                    sql =
"UPDATE producto SET valorventaproducto = " + ventaNew_ + ", idiva = " + idIva + ", idiva_temp = " + idIva + " WHERE codigointernoproducto = '" + rProducto["codigo"].ToString() + "';";

                    miComando = new NpgsqlCommand();
                    miComando.Connection = miConexion.MiConexion;
                    miComando.CommandType = CommandType.Text;
                    miComando.CommandText = sql;
                    miConexion.MiConexion.Open();
                    miComando.ExecuteNonQuery();
                    miConexion.MiConexion.Close();
                    miComando.Dispose();

                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally { miConexion.MiConexion.Close(); }
        }

        public DataTable Clientes()
        {
            try
            {
                var tdata = new DataTable();
                tdata.Columns.Add(new DataColumn("nitcliente", typeof(string)));

                string sql = "select * from cliente_;";
                var tabla = new DataTable();
                miAdapter = new NpgsqlDataAdapter(sql, miConexion.MiConexion);
                miAdapter.SelectCommand.CommandType = CommandType.Text;
                miAdapter.Fill(tabla);

                foreach (DataRow row in tabla.Rows)
                {
                    sql = "select * from cliente where nitcliente = '" + row["nitcliente"].ToString() + "';";
                    var tabla1 = new DataTable();
                    miAdapter = new NpgsqlDataAdapter(sql, miConexion.MiConexion);
                    miAdapter.SelectCommand.CommandType = CommandType.Text;
                    miAdapter.Fill(tabla1);

                    if (tabla1.Rows.Count > 0)
                    {
                        tdata.Rows.Add(row["nitcliente"].ToString());
                    }

                }
                return tdata;
            }
            catch (Exception ex)
            {
                throw new Exception("" + ex.Message);
            }
        }

        // fin codigo para verificar

        // Codigo para cargar puntos a clientes

        public DataTable CargarPuntos(DateTime fecha, DateTime fecha2)
        {
            try
            {
                var daoProductoVenta = new DaoProductoFacturaVenta();
                var daoCliente = new DaoCliente();
                var daoPunto = new DaoPunto();
                var punto = daoPunto.CargaPunto();
                string sql = 
       "SELECT cliente.nitcliente, cliente.nombrescliente FROM cliente, factura_venta WHERE cliente.nitcliente = factura_venta.nitcliente AND " +
       "cliente.nitcliente != '10' AND cliente.nitcliente != '1000' AND factura_venta.fecha_factura_venta BETWEEN " +
       "'" + fecha.ToShortDateString() + "' AND '" + fecha2.ToShortDateString() + "' " +
       "GROUP BY cliente.nitcliente, cliente.nombrescliente ORDER BY cliente.nombrescliente ASC;";
                var tClientes = new DataTable();
                this.miAdapter = new NpgsqlDataAdapter(sql, this.miConexion.MiConexion);
                this.miAdapter.SelectCommand.CommandType = CommandType.Text;
                this.miAdapter.Fill(tClientes);
                foreach (DataRow cRow in tClientes.Rows)
                {
                    int acumulaPunto = 0;
                    DataTable tVentas = this.ConsultaPorClientePeriodoIngreso(cRow["nitcliente"].ToString(), fecha, fecha2, 0, 100000);
                    foreach (DataRow vRow in tVentas.Rows)
                    {
                        int total = 
                    daoProductoVenta.PrintProducto(Convert.ToInt32(vRow["id"]), true).Tables[0].AsEnumerable().Sum(d => d.Field<int>("Total_"));
                        int puntos = 0;
                        if (total > punto.ValorVentaMinPunto)
                        {
                            puntos = UseObject.RetiraDecima(total / punto.ValorPunto);
                            puntos *= Convert.ToInt32(punto.NumeroPuntos);
                        }
                        acumulaPunto += puntos;
                    }
                    daoCliente.EditarPuntos(cRow["nitcliente"].ToString(), acumulaPunto);
                }
                sql = "SELECT nitcliente, nombrescliente, celularcliente, direccioncliente, punto FROM cliente WHERE " +
                    " cliente.punto != 0 ORDER BY  cliente.nombrescliente ASC;";
                var tClientesPuntos = new DataTable();
                this.miAdapter = new NpgsqlDataAdapter(sql, this.miConexion.MiConexion);
                this.miAdapter.SelectCommand.CommandType = CommandType.Text;
                this.miAdapter.Fill(tClientesPuntos);
                return tClientesPuntos;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        // End Codigo para cargar puntos a clientes


        // Codigo para consultar los numeros repetidos de facturas de venta.

        public DataTable NumerosFacturasRepetidas()
        {
            try
            {
                var tFacts = new DataTable();
                //tFacts.Columns.Add(new DataColumn("ID", typeof(int)));
                tFacts.Columns.Add(new DataColumn("NUMERO", typeof(string)));

                string sql = "select numerofactura_venta from factura_venta;";
                var tAnuladas = new DataTable();
                this.miAdapter = new NpgsqlDataAdapter(sql, miConexion.MiConexion);
                this.miAdapter.SelectCommand.CommandType = CommandType.Text;
                this.miAdapter.Fill(tAnuladas);

                sql = "select id, numerofactura_venta from factura_venta order by id;";
                var tFacturas = new DataTable();
                this.miAdapter = new NpgsqlDataAdapter(sql, miConexion.MiConexion);
                this.miAdapter.SelectCommand.CommandType = CommandType.Text;
                this.miAdapter.Fill(tFacturas);
                foreach (DataRow aFact in tAnuladas.Rows)
                {
                    if (tFacturas.AsEnumerable().
                        Where(f => f.Field<string>("numerofactura_venta").Equals(aFact["numerofactura_venta"].ToString())).Count() > 1)
                    {
                        var row = tFacts.NewRow();
                        row["NUMERO"] = aFact["numerofactura_venta"];
                        tFacts.Rows.Add(row);
                        //Console.WriteLine("SI  " + rFact["numerofactura_venta"].ToString());
                    }
                   /* else
                    {
                        Console.WriteLine("NO  " + rFact["numerofactura_venta"].ToString());
                    }*/
                }
                return tFacts;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        // Funcion auxiliar para tomar el valor del total de ventas, en comp. diario "Todas las cajas"

        public int TotalVenta(DateTime fecha)
        {
            try
            {
                int totalVenta = 0;
                var miDaoImpuesto = new DaoImpuestoBolsa();

                string sql = 
                "SELECT id FROM factura_venta WHERE (idestado = 1 OR idestado = 2) AND estado = TRUE AND fecha_factura_venta = '" + fecha.ToShortDateString() + "';";
                var tFacturas = new DataTable();
                this.miAdapter = new NpgsqlDataAdapter(sql, this.miConexion.MiConexion);
                this.miAdapter.SelectCommand.CommandType = CommandType.Text;
                this.miAdapter.Fill(tFacturas);

                double valorFactura = 0;
                ImpuestoBolsa icoBolsa;
                DataTable tProductos;
                foreach (DataRow tRow in tFacturas.Rows)
                {
                    tProductos = ProductoFacturaVenta(Convert.ToInt32(tRow["id"]), true);
                    valorFactura = tProductos.AsEnumerable().Sum(t => t.Field<double>("Valor"));
                    icoBolsa = miDaoImpuesto.ImpuestoBolsaDeVenta(Convert.ToInt32(tRow["id"]));
                    valorFactura += (icoBolsa.Cantidad * icoBolsa.Valor);

                    totalVenta += Convert.ToInt32(valorFactura);
                }
                return totalVenta;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al calcular el valor total de las ventas.\n" + ex.Message);
            }
        }

        public int TotalVenta(int idCaja, DateTime fecha)
        {
            try
            {
                int totalVenta = 0;
                var miDaoImpuesto = new DaoImpuestoBolsa();

                string sql =
                "SELECT id FROM factura_venta WHERE (idestado = 1 OR idestado = 2) AND estado = TRUE AND idcaja = " + idCaja + 
                " AND fecha_factura_venta = '" + fecha.ToShortDateString() + "';";
                var tFacturas = new DataTable();
                this.miAdapter = new NpgsqlDataAdapter(sql, this.miConexion.MiConexion);
                this.miAdapter.SelectCommand.CommandType = CommandType.Text;
                this.miAdapter.Fill(tFacturas);

                double valorFactura = 0;
                ImpuestoBolsa icoBolsa;
                DataTable tProductos;
                foreach (DataRow tRow in tFacturas.Rows)
                {
                    tProductos = ProductoFacturaVenta(Convert.ToInt32(tRow["id"]), true);
                    valorFactura = tProductos.AsEnumerable().Sum(t => t.Field<double>("Valor"));
                    icoBolsa = miDaoImpuesto.ImpuestoBolsaDeVenta(Convert.ToInt32(tRow["id"]));
                    valorFactura += (icoBolsa.Cantidad * icoBolsa.Valor);

                    totalVenta += Convert.ToInt32(valorFactura);
                }
                return totalVenta;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al calcular el valor total de las ventas.\n" + ex.Message);
            }
        }

        public int VentasCredito(int idEstado, int idCaja, DateTime fecha, DateTime fecha2)
        {
            try
            {
                string sql = "SELECT id FROM view_ventas_horas WHERE idestado = " + idEstado + " AND idcaja = " + idCaja + 
        " AND fecha_completa BETWEEN '" + fecha.ToShortDateString() + " " + fecha.TimeOfDay.ToString() + "' AND '" + fecha2.ToShortDateString() + " " + fecha2.TimeOfDay.ToString() + "';";

                int totalVenta = 0;
                var miDaoImpuesto = new DaoImpuestoBolsa();

                var tFacturas = new DataTable();
                this.miAdapter = new NpgsqlDataAdapter(sql, this.miConexion.MiConexion);
                this.miAdapter.SelectCommand.CommandType = CommandType.Text;
                this.miAdapter.Fill(tFacturas);

                double valorFactura = 0;
                ImpuestoBolsa icoBolsa;
                DataTable tProductos;
                foreach (DataRow tRow in tFacturas.Rows)
                {
                    tProductos = ProductoFacturaVenta(Convert.ToInt32(tRow["id"]), true);
                    valorFactura = tProductos.AsEnumerable().Sum(t => t.Field<double>("Valor"));
                    icoBolsa = miDaoImpuesto.ImpuestoBolsaDeVenta(Convert.ToInt32(tRow["id"]));
                    valorFactura += (icoBolsa.Cantidad * icoBolsa.Valor);

                    totalVenta += Convert.ToInt32(valorFactura);
                }
                return totalVenta;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al calcular el valor total de las ventas.\n" + ex.Message);
            }
        }

        public List<FacturaVenta> Ventas(int idCaja, DateTime fecha, DateTime fecha2)
        {
            try
            {
                List<FacturaVenta> ventas = new List<FacturaVenta>();
                string sql = "SELECT idestado, SUM(total) FROM view_consulta_impuestos WHERE estado = true AND " +
                             "(idestado = 1 OR idestado = 2) AND idcaja = " + idCaja + " AND fecha + hora BETWEEN  " +
                             "'" + fecha.ToShortDateString() + " " + fecha.TimeOfDay.ToString() + "' " +
                             "AND '" + fecha2.ToShortDateString() + " " + fecha2.TimeOfDay.ToString() + "' " +
                             "GROUP BY idestado ";
                miComando = new NpgsqlCommand();
                miComando.Connection = miConexion.MiConexion;
                miComando.CommandType = CommandType.Text;
                miComando.CommandText = sql;
                miComando.CommandTimeout = 0;

                miConexion.MiConexion.Open();
                NpgsqlDataReader reader = miComando.ExecuteReader();
                while (reader.Read())
                {
                    var factura = new FacturaVenta();
                    factura.EstadoFactura.Id = reader.GetInt32(0);
                    factura.Valor = Convert.ToInt32(reader.GetDouble(1));
                    ventas.Add(factura);
                }
                miConexion.MiConexion.Close();
                miComando.Dispose();
                return ventas;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al consultar las ventas.\n" + ex.Message);
            }
            finally { miConexion.MiConexion.Close(); }
        }

        public List<FacturaVenta> POSJoinElectronicInvoices(int idCaja, DateTime fecha, DateTime fecha2)
        {
            try
            {
                List<FacturaVenta> ventas = new List<FacturaVenta>();
                string sql =
                    @"select 
                          t_un.metodo_pago, 
                          sum(t_un.total) 
                        from 
                        (select 
                          idestado as metodo_pago, 
                          sum(total) as total 
                        from 
                          view_consulta_impuestos 
                        where 
                          idcaja = @caja and 
                          fecha + hora between 
                           @beginDate AND @endDate  
                        group by 
                          idestado 
                        union all 
                        select 
                          metodo_pago,
                          sum(neto) 
                        from documento_electronico 
                        where 
                          transaccion_id != '' and 
                          id_caja = @caja and 
                          fecha + hora between 
                           @beginDate AND @endDate
                        group by 
                          metodo_pago) as t_un
                        group by t_un.metodo_pago;";
                miComando = new NpgsqlCommand();
                miComando.Connection = miConexion.MiConexion;
                miComando.CommandType = CommandType.Text;
                miComando.CommandText = sql;
                miComando.Parameters.AddWithValue("caja", idCaja);
                miComando.Parameters.AddWithValue("beginDate", fecha);
                miComando.Parameters.AddWithValue("endDate", fecha2);
                miComando.CommandTimeout = 0;

                miConexion.MiConexion.Open();
                NpgsqlDataReader reader = miComando.ExecuteReader();
                while (reader.Read())
                {
                    var factura = new FacturaVenta();
                    factura.EstadoFactura.Id = reader.GetInt32(0);
                    factura.Valor = Convert.ToInt32(reader.GetDouble(1));
                    ventas.Add(factura);
                }
                miConexion.MiConexion.Close();
                miComando.Dispose();
                return ventas;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al consultar las ventas.\n" + ex.Message);
            }
            finally { miConexion.MiConexion.Close(); }
        }

        /*public int VentasCredito(int idEstado, DateTime fecha, DateTime fecha2)
        {
            try
            {
                string sql = "SELECT id FROM view_ventas_horas WHERE idestado = " + idEstado +
        " AND fecha_completa BETWEEN" + fecha.ToShortDateString() + " " + fecha.TimeOfDay.ToString() + " AND '" + fecha2.ToShortDateString() + " " + fecha2.TimeOfDay.ToString() + "'";

                int totalVenta = 0;
                var miDaoImpuesto = new DaoImpuestoBolsa();

                var tFacturas = new DataTable();
                this.miAdapter = new NpgsqlDataAdapter(sql, this.miConexion.MiConexion);
                this.miAdapter.SelectCommand.CommandType = CommandType.Text;
                this.miAdapter.Fill(tFacturas);

                double valorFactura = 0;
                ImpuestoBolsa icoBolsa;
                DataTable tProductos;
                foreach (DataRow tRow in tFacturas.Rows)
                {
                    tProductos = ProductoFacturaVenta(Convert.ToInt32(tRow["id"]), true);
                    valorFactura = tProductos.AsEnumerable().Sum(t => t.Field<double>("Valor"));
                    icoBolsa = miDaoImpuesto.ImpuestoBolsaDeVenta(Convert.ToInt32(tRow["id"]));
                    valorFactura += (icoBolsa.Cantidad * icoBolsa.Valor);

                    totalVenta += Convert.ToInt32(valorFactura);
                }
                return totalVenta;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al calcular el valor total de las ventas.\n" + ex.Message);
            }
        }

        public int VentasCredito(int idEstado, DateTime fecha)
        {
            try
            {
                string sql = "SELECT id FROM factura_venta WHERE idestado = " + idEstado + " AND fecha_factura_venta = '" + fecha + "';";

                int totalVenta = 0;
                var miDaoImpuesto = new DaoImpuestoBolsa();

                var tFacturas = new DataTable();
                this.miAdapter = new NpgsqlDataAdapter(sql, this.miConexion.MiConexion);
                this.miAdapter.SelectCommand.CommandType = CommandType.Text;
                this.miAdapter.Fill(tFacturas);

                double valorFactura = 0;
                ImpuestoBolsa icoBolsa;
                DataTable tProductos;
                foreach (DataRow tRow in tFacturas.Rows)
                {
                    tProductos = ProductoFacturaVenta(Convert.ToInt32(tRow["id"]), true);
                    valorFactura = tProductos.AsEnumerable().Sum(t => t.Field<double>("Valor"));
                    icoBolsa = miDaoImpuesto.ImpuestoBolsaDeVenta(Convert.ToInt32(tRow["id"]));
                    valorFactura += (icoBolsa.Cantidad * icoBolsa.Valor);

                    totalVenta += Convert.ToInt32(valorFactura);
                }
                return totalVenta;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al calcular el valor total de las ventas.\n" + ex.Message);
            }
        }*/


        // Fin funcion auxiliar para tomar el valor del total de ventas, en comp. diario "Todas las cajas"


        // Codigo para nivelar valores de facturas de venta 16/03/2019

        public DataTable FacturasYpagos_org(int idCaja, DateTime fecha)
        {
            try
            {
                var tDatos = new DataTable();
                tDatos.Columns.Add(new DataColumn("cedula", typeof(string)));
                tDatos.Columns.Add(new DataColumn("cliente", typeof(string)));
                tDatos.Columns.Add(new DataColumn("id", typeof(int)));
                tDatos.Columns.Add(new DataColumn("numero", typeof(string)));
                tDatos.Columns.Add(new DataColumn("forma_p", typeof(string)));
                tDatos.Columns.Add(new DataColumn("fecha", typeof(DateTime)));
                tDatos.Columns.Add(new DataColumn("hora", typeof(DateTime)));
                tDatos.Columns.Add(new DataColumn("caja", typeof(string)));
                tDatos.Columns.Add(new DataColumn("estado", typeof(string)));
                tDatos.Columns.Add(new DataColumn("usuario", typeof(string)));


                tDatos.Columns.Add(new DataColumn("valorf", typeof(int)));
                tDatos.Columns.Add(new DataColumn("valorp", typeof(int)));
                tDatos.Columns.Add(new DataColumn("pagos", typeof(int)));


                var miDaoImpuesto = new DaoImpuestoBolsa();
                var miDaoRetencion = new DaoRetencion();
                var miDaoDevolucion = new DaoDevolucion();

                double valorFactura = 0;
                int pagos = 0;
                int diferencia = 0;
                ImpuestoBolsa icoBolsa;

                int idFactura = 0;
                int idPago = 0;
                int pago = 0;

               /* string sql =
                "SELECT cliente.nitcliente AS cedula, cliente.nombrescliente AS cliente, factura_venta.id, factura_venta.numerofactura_venta AS numero, estado.descripcionestado AS forma_p, " +
                "factura_venta.fecha_factura_venta AS fecha, factura_venta.horafactura_venta AS hora, caja.numerocaja AS caja, factura_venta.estado, usuario_sistema.nombresusuario_sistema AS usuario " +
                "FROM factura_venta, cliente, caja, estado, usuario_sistema WHERE factura_venta.idcaja = caja.idcaja AND cliente.nitcliente = factura_venta.nitcliente AND estado.idestado = factura_venta.idestado AND " +
                "usuario_sistema.idusuario_sistema = factura_venta.idusuario_sistema AND factura_venta.idcaja = " + idCaja + 
                " AND factura_venta.fecha_factura_venta = '" + fecha.ToShortDateString() + "' ORDER BY factura_venta.id ASC;";*/


                string sql =
                "SELECT cliente.nitcliente AS cedula, cliente.nombrescliente AS cliente, factura_venta.id, factura_venta.numerofactura_venta AS numero, estado.descripcionestado AS forma_p, " +
                "factura_venta.fecha_factura_venta AS fecha, factura_venta.horafactura_venta AS hora, caja.numerocaja AS caja, factura_venta.estado, usuario_sistema.nombresusuario_sistema AS usuario " +
                "FROM factura_venta, cliente, caja, estado, usuario_sistema WHERE factura_venta.idcaja = caja.idcaja AND cliente.nitcliente = factura_venta.nitcliente AND estado.idestado = factura_venta.idestado AND " +
                "usuario_sistema.idusuario_sistema = factura_venta.idusuario_sistema " +
                " AND factura_venta.fecha_factura_venta = '" + fecha.ToShortDateString() + "' ORDER BY factura_venta.id ASC;";

                var tFacturas = new DataTable();

                this.miAdapter = new NpgsqlDataAdapter(sql, this.miConexion.MiConexion);
                this.miAdapter.SelectCommand.CommandType = CommandType.Text;
                this.miAdapter.Fill(tFacturas);

                foreach (DataRow tRow in tFacturas.Rows)
                {
                    var dRow = tDatos.NewRow();
                    dRow["cedula"] = tRow["cedula"];
                    dRow["cliente"] = tRow["cliente"];
                    dRow["id"] = tRow["id"];
                    dRow["numero"] = tRow["numero"];
                    dRow["forma_p"] = tRow["forma_p"];
                    dRow["fecha"] = tRow["fecha"];
                    dRow["hora"] = tRow["hora"];
                    dRow["caja"] = tRow["caja"];
                    dRow["estado"] = tRow["estado"];
                    dRow["usuario"] = tRow["usuario"];

                    DataTable tProductos = ProductoFacturaVenta(Convert.ToInt32(tRow["id"]), true);
                    valorFactura = tProductos.AsEnumerable().Sum(t => t.Field<double>("Valor"));
                    icoBolsa = miDaoImpuesto.ImpuestoBolsaDeVenta(Convert.ToInt32(tRow["id"]));
                    valorFactura += (icoBolsa.Cantidad * icoBolsa.Valor);
                    var tPagos = this.PagosFacturas(Convert.ToInt32(tRow["id"]));

                    dRow["valorf"] = valorFactura;
                    if (tPagos.Rows.Count > 0)
                    {
                        dRow["valorp"] = tPagos.AsEnumerable().Sum(s => s.Field<Int64>("valor"));
                        dRow["pagos"] = tPagos.AsEnumerable().Sum(s => s.Field<Int64>("pago"));
                    }
                    tDatos.Rows.Add(dRow);
                }
                return tDatos;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al consultar la cartera de clientes.\n" + ex.Message);
            }
            finally { }
        }

        public DataTable FacturasYpagos()
        {
            try
            {
                var tDatos = new DataTable();
                tDatos.Columns.Add(new DataColumn("cedula", typeof(string)));
                tDatos.Columns.Add(new DataColumn("cliente", typeof(string)));
                tDatos.Columns.Add(new DataColumn("id", typeof(int)));
                tDatos.Columns.Add(new DataColumn("numero", typeof(string)));
                tDatos.Columns.Add(new DataColumn("estado", typeof(string)));
                tDatos.Columns.Add(new DataColumn("fecha", typeof(DateTime)));
                tDatos.Columns.Add(new DataColumn("hora", typeof(DateTime)));
                tDatos.Columns.Add(new DataColumn("valorf", typeof(int)));
                tDatos.Columns.Add(new DataColumn("valorp", typeof(int)));
                tDatos.Columns.Add(new DataColumn("pagos", typeof(int)));


                var miDaoImpuesto = new DaoImpuestoBolsa();
                var miDaoRetencion = new DaoRetencion();
                var miDaoDevolucion = new DaoDevolucion();

                double valorFactura = 0;
                int pagos = 0;
                int diferencia = 0;
                ImpuestoBolsa icoBolsa;

                int idFactura = 0;
                int idPago = 0;
                int pago = 0;

                string sql =
                "SELECT cliente.nitcliente AS cedula, cliente.nombrescliente AS cliente, factura_venta.id, factura_venta.numerofactura_venta AS numero, " +
                "estado.descripcionestado AS estado, factura_venta.fecha_factura_venta AS fecha, factura_venta.horafactura_venta AS hora FROM " +
                "factura_venta, cliente, estado WHERE cliente.nitcliente = factura_venta.nitcliente AND estado.idestado = factura_venta.idestado AND " +
              "factura_venta.estado = true AND estado.idestado = 2 AND factura_venta.fecha_factura_venta >= '2018-06-01'  ORDER BY cliente.nombrescliente ASC, factura_venta.id ASC;";

                var tFacturas = new DataTable();

                this.miAdapter = new NpgsqlDataAdapter(sql, this.miConexion.MiConexion);
                this.miAdapter.SelectCommand.CommandType = CommandType.Text;
                this.miAdapter.Fill(tFacturas);

                foreach (DataRow tRow in tFacturas.Rows)
                {
                    /*var dRow = tDatos.NewRow();
                    dRow["cedula"] = tRow["cedula"];
                    dRow["cliente"] = tRow["cliente"];
                    dRow["id"] = tRow["id"];
                    dRow["numero"] = tRow["numero"];
                    dRow["estado"] = tRow["estado"];
                    dRow["fecha"] = tRow["fecha"];
                    dRow["hora"] = tRow["hora"];

                    DataTable tProductos = ProductoFacturaVenta(Convert.ToInt32(tRow["id"]), true);
                    valorFactura = tProductos.AsEnumerable().Sum(t => t.Field<double>("Valor"));
                    icoBolsa = miDaoImpuesto.ImpuestoBolsaDeVenta(Convert.ToInt32(tRow["id"]));
                    valorFactura += (icoBolsa.Cantidad * icoBolsa.Valor);
                    var tPagos = this.PagosFacturas(Convert.ToInt32(tRow["id"]));

                    dRow["valorf"] = valorFactura;
                    dRow["valorp"] = tPagos.AsEnumerable().Sum(s => s.Field<Int64>("valor"));
                    dRow["pagos"] = tPagos.AsEnumerable().Sum(s => s.Field<Int64>("pago"));
                    tDatos.Rows.Add(dRow);*/
                    idFactura = Convert.ToInt32(tRow["id"]);
                    DataTable tProductos = ProductoFacturaVenta(Convert.ToInt32(tRow["id"]), true);
                    valorFactura = tProductos.AsEnumerable().Sum(t => t.Field<double>("Valor"));
                    icoBolsa = miDaoImpuesto.ImpuestoBolsaDeVenta(Convert.ToInt32(tRow["id"]));
                    valorFactura += (icoBolsa.Cantidad * icoBolsa.Valor);
                    var tPagos = this.PagosFacturas(Convert.ToInt32(tRow["id"]));
                    pagos = Convert.ToInt32(tPagos.AsEnumerable().Sum(s => s.Field<Int64>("valor")));

                    diferencia = Convert.ToInt32(valorFactura) - pagos;
                    if (diferencia != 0)
                    {
                        if (diferencia < 300)
                        {
                            var tPago = this.T_PagosFacturas(idFactura, 450); //valorfactura_forma_pago
                            if (tPago.Rows.Count > 0)
                            {
                                var rowPago = tPago.AsEnumerable().First();
                                if (valorFactura > pagos)
                                {
                                    if (diferencia < 300)
                                    {
                                        diferencia = Convert.ToInt32(valorFactura) - pagos;
                                        pago = Convert.ToInt32(rowPago["valorfactura_forma_pago"]) + diferencia;
                                        this.UpdatePagos(Convert.ToInt32(rowPago["idfactura_forma_pago"]), pago);
                                    }
                                }
                                else
                                {
                                    diferencia = pagos - Convert.ToInt32(valorFactura);
                                    pago = Convert.ToInt32(rowPago["valorfactura_forma_pago"]) - diferencia;
                                    this.UpdatePagos(Convert.ToInt32(rowPago["idfactura_forma_pago"]), pago);
                                    //pagos -= diferencia;
                                }
                            }
                        }
                    }
                }
                return tDatos;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al consultar la cartera de clientes.\n" + ex.Message);
            }
            finally { }
        }

        private DataTable PagosFacturas(int idFactura)
        {
            try
            {
                string sql = "SELECT CASE WHEN SUM(factura_forma_pago.valorfactura_forma_pago) IS NULL THEN 0 " + 
                "ELSE SUM(factura_forma_pago.valorfactura_forma_pago) END AS valor, CASE WHEN SUM(factura_forma_pago.valor_pago) IS NULL THEN 0 " +
                "ELSE SUM(factura_forma_pago.valor_pago) END AS pago " +
                "FROM factura_forma_pago WHERE factura_forma_pago.id_factura = " + idFactura + ";";
                var tabla = new DataTable();

                this.miAdapter = new NpgsqlDataAdapter(sql, this.miConexion.MiConexion);
                this.miAdapter.SelectCommand.CommandType = CommandType.Text;
                this.miAdapter.Fill(tabla);
                return tabla;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private DataTable T_PagosFacturas(int idFactura, int max_value)
        {
            try
            {
                string sql = "SELECT factura_forma_pago.idfactura_forma_pago, factura_forma_pago.valorfactura_forma_pago FROM factura_forma_pago " +
                "WHERE factura_forma_pago.id_factura = " + idFactura + " AND factura_forma_pago.valorfactura_forma_pago > " + max_value + ";";
                var tabla = new DataTable();

                this.miAdapter = new NpgsqlDataAdapter(sql, this.miConexion.MiConexion);
                this.miAdapter.SelectCommand.CommandType = CommandType.Text;
                this.miAdapter.Fill(tabla);
                return tabla;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void UpdatePagos(int idPago, int valor)
        {
            try
            {
                string sql = 
                "UPDATE factura_forma_pago SET valorfactura_forma_pago = " + valor + ", valor_pago = " + valor + " WHERE idfactura_forma_pago = " + idPago + ";";

                miComando = new NpgsqlCommand();
                miComando.Connection = miConexion.MiConexion;
                miComando.CommandType = CommandType.Text;
                miComando.CommandText = sql;
                miConexion.MiConexion.Open();
                miComando.ExecuteNonQuery();
                miConexion.MiConexion.Close();
                miComando.Dispose();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally { this.miConexion.MiConexion.Close(); }
        }

        // Fin Codigo para nivelar valores de facturas de venta 16/03/2019

        // Codigo para revisar valores de saldo en doc. de ingresos de clientes.
        public int SaldoClienteRboIngreso(string nitCliente)
        {
            try
            {
                string sql =
                "SELECT saldo FROM ingreso WHERE id = (SELECT MAX(id) FROM ingreso WHERE nitcliente = '" + nitCliente + "');";

                miComando = new NpgsqlCommand();
                miComando.Connection = miConexion.MiConexion;
                miComando.CommandType = CommandType.Text;
                miComando.CommandText = sql;
                miConexion.MiConexion.Open();
                int saldo = Convert.ToInt32(miComando.ExecuteScalar());
                miConexion.MiConexion.Close();
                miComando.Dispose();

                return saldo;
            }
            catch (InvalidCastException) // EDICION 23-01-2017
            {
                return 0;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al cargar el saldo.\n" + ex.Message);
            }
            finally { this.miConexion.MiConexion.Close(); }
        }


        public DataTable ValoresFacturaVenta(DateTime fecha, DateTime fecha2)
        {
            try
            {
                DataTable tVentas = new DataTable();
                tVentas.Columns.Add("id", typeof(int));
                tVentas.Columns.Add("fecha", typeof(DateTime));
                tVentas.Columns.Add("total", typeof(int));

                string sql =
             "SELECT id, fecha_factura_venta AS fecha FROM factura_venta WHERE (factura_venta.idestado = 1 OR factura_venta.idestado = 2) AND factura_venta.estado = true AND " +
             "factura_venta.fecha_factura_venta BETWEEN '" + fecha.ToShortDateString() + "' AND '" + fecha2.ToShortDateString() + "' ORDER BY id ASC;";
                var tabla = new DataTable();
                miAdapter = new NpgsqlDataAdapter(sql, miConexion.MiConexion);
                miAdapter.SelectCommand.CommandType = CommandType.Text;
                miAdapter.Fill(tabla);

                foreach (DataRow tRow in tabla.Rows)
                {
                    var vRow = tVentas.NewRow();
                    vRow["id"] = tRow["id"];
                    vRow["fecha"] = tRow["fecha"];
                    vRow["total"] = this.CalculoValorVenta(Convert.ToInt32(tRow["id"]));
                    tVentas.Rows.Add(vRow);
                }

                return tVentas;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al consultar el resumen de ventas.\n" + ex.Message);
            }
        }

        private int CalculoValorVenta(int id)
        {
            var miDaoImpuesto = new DaoImpuestoBolsa();
            ImpuestoBolsa icoBolsa;

            DataTable tProductos;
            double valorFactura = 0;
            int totalVenta = 0;
            /*foreach (DataRow fRow in tableFacturas.Rows) // itera las facturas
            {*/
                valorFactura = 0;
                tProductos = ProductoFacturaVenta(id, true);
                valorFactura = tProductos.AsEnumerable().Sum(t => t.Field<double>("Valor"));
                icoBolsa = miDaoImpuesto.ImpuestoBolsaDeVenta(id);
                valorFactura += (icoBolsa.Cantidad * icoBolsa.Valor);
                totalVenta += Convert.ToInt32(valorFactura);
           // }
            return totalVenta;
        }


        public DataTable FacturasDeCartera()
        {
            try
            {
                var tFacturas = new DataTable();
                string sql = 
                "SELECT factura_venta.numerofactura_venta, factura_venta.nitcliente, factura_venta.idusuario_sistema, factura_venta.idcaja, factura_venta.idestado, factura_venta.fecha_factura_venta, " +
                "factura_venta.horafactura_venta, factura_venta.descuentofactura_venta, factura_venta.fechalimitefactura_venta, factura_venta.aplica_descuento, factura_venta.estado, factura_venta.serie, " +
                "factura_venta.id, factura_venta.id_resolucion_dian FROM public.factura_venta_temp, public.factura_venta WHERE factura_venta.numerofactura_venta = factura_venta_temp.numero ORDER BY factura_venta.id ASC;";
                this.miAdapter = new NpgsqlDataAdapter(sql, miConexion.MiConexion);
                this.miAdapter.SelectCommand.CommandType = CommandType.Text;
                this.miAdapter.SelectCommand.CommandTimeout = 0;
                this.miAdapter.Fill(tFactura);
                return tFactura;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public DataTable ProductosFacturasDeCartera()
        {
            try
            {
                var tFacturas = new DataTable();
                string sql =
                "SELECT producto_factura_venta.idproducto_factura_venta, producto_factura_venta.numerofactura_venta, producto_factura_venta.codigointernoproducto, producto_factura_venta.cantidadproducto_factura_venta, " +
                "producto_factura_venta.valorunitarioproducto_factura_venta, producto_factura_venta.idmedida, producto_factura_venta.idcolor, producto_factura_venta.valor_descuento, producto_factura_venta.valor_recargo, " +
                "producto_factura_venta.valor_iva, producto_factura_venta.retorno, producto_factura_venta.valor, producto_factura_venta.costo, producto_factura_venta.id_factura, producto_factura_venta.valor_venta_real, " +
                "producto_factura_venta.impoconsumo FROM public.factura_venta, public.factura_venta_temp, public.producto_factura_venta WHERE factura_venta_temp.numero = factura_venta.numerofactura_venta AND " +
                "producto_factura_venta.id_factura = factura_venta.id;";
                this.miAdapter = new NpgsqlDataAdapter(sql, miConexion.MiConexion);
                this.miAdapter.SelectCommand.CommandType = CommandType.Text;
                this.miAdapter.SelectCommand.CommandTimeout = 0;
                this.miAdapter.Fill(tFacturas);
                return tFacturas;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public DataTable PagosFacturasDeCartera()
        {
            try
            {
                var tFacturas = new DataTable();
                string sql =
                "SELECT factura_forma_pago.idfactura_forma_pago, factura_forma_pago.numerofactura_venta, factura_forma_pago.idusuario, factura_forma_pago.idcaja, factura_forma_pago.idforma_pago, " +
                "factura_forma_pago.fechafactura_forma_pago, factura_forma_pago.hora, factura_forma_pago.valorfactura_forma_pago, factura_forma_pago.idturno, factura_forma_pago.valor_pago, " +
                "factura_forma_pago.id_factura FROM public.factura_venta_temp, public.factura_venta, public.factura_forma_pago WHERE factura_venta_temp.numero = factura_venta.numerofactura_venta AND " +
                "factura_venta.id = factura_forma_pago.id_factura ORDER BY factura_forma_pago.idfactura_forma_pago ASC;";
                this.miAdapter = new NpgsqlDataAdapter(sql, miConexion.MiConexion);
                this.miAdapter.SelectCommand.CommandType = CommandType.Text;
                this.miAdapter.SelectCommand.CommandTimeout = 0;
                this.miAdapter.Fill(tFacturas);
                return tFacturas;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        //*****


        public void AjustarCartera(DataTable cartera)
        {
            try
            {
                var daoPago = new DaoFormaPago();
                int valor = 0;
                foreach (DataRow cRow in cartera.Rows)
                {
                    if (Convert.ToInt32(cRow["Saldo"]) <= 600)
                    {
                        var rowPago = daoPago.FormasDePagoDeFacturaVentaId(Convert.ToInt32(cRow["Id"])).AsEnumerable().Last();
                        valor = Convert.ToInt32(rowPago["Pago"]) + Convert.ToInt32(cRow["Saldo"]);
                        daoPago.EditarValores(Convert.ToInt32(rowPago["Id"]), valor, valor);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

       /* public void ActualizarPagoVenta(int id, int valor)
        {
            try
            {
                string sql = "update factura_forma_pago set valor_pago = " + valor + " where idfactura_forma_pago = " + id + ";";
                miComando = new NpgsqlCommand();
                miComando.Connection = miConexion.MiConexion;
                miComando.CommandType = CommandType.Text;
                miComando.CommandText = sql;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
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
            miComando.CommandTimeout = 0;
        }

        private void CargarComandoText(string cmd)
        {
            miComando = new NpgsqlCommand();
            miComando.Connection = miConexion.MiConexion;
            miComando.CommandType = CommandType.Text;
            miComando.CommandText = cmd;
            miComando.CommandTimeout = 0;
        }

        /// <summary>
        /// Inicializa una nueva instancia de NpgsqlDataAdapter de tipo StoredProcedure.
        /// </summary>
        /// <param name="cmd">Comando a ejecutar.</param>
        private void CargarAdapter(string cmd)
        {
            this.miAdapter = new NpgsqlDataAdapter(cmd, miConexion.MiConexion);
            this.miAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            this.miAdapter.SelectCommand.CommandTimeout = 0;
        }
    }
}