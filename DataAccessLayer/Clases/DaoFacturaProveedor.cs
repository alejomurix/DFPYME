using System;
using System.Linq;
using System.Data;
using DTO.Clases;
using Npgsql;
using System.Collections.Generic;

namespace DataAccessLayer.Clases
{
    /// <summary>
    /// Representa una clase para la tranzacion a base de datos de Facturas de Proveedor.
    /// </summary>
    public class DaoFacturaProveedor
    {
        #region Tranzación a base de datos

        /// <summary>
        /// Proporciona acceso a la conexion a base de datos PostgreSQL.
        /// </summary>
        private Conexion miConexion;

        /// <summary>
        /// Representa un comando de ejecucion de sentencias SQL a PostgreSQL.
        /// </summary>
        private NpgsqlCommand miComando;

        /// <summary>
        /// Representa un adaptador de comandos SQL a PostgreSQL.
        /// </summary>
        private NpgsqlDataAdapter miAdapter;

        private DaoRetencion miDaoRetencion;

        #endregion

        #region Funciones

        /// <summary>
        /// Representa la funcion recuperar_consecutivo.
        /// </summary>
        private const string ObtenerConsecutivo = "recuperar_consecutivo";

        /// <summary>
        /// Representa la funcion actualizar_consecutivo.
        /// </summary>
        private const string ActualizarConsecutivo = "actualizar_consecutivo";

        /// <summary>
        /// Representa la funcion insertar_factura_proveedor.
        /// </summary>
        private const string sqlInsertar = "insertar_factura_proveedor";

        /// <summary>
        /// Representa la función editar_factura_proveedor.
        /// </summary>
        private const string sqlEditar = "editar_factura_proveedor";

        /// <summary>
        /// Representa la función consulta_factura_proveedor.
        /// </summary>
        private const string sqlConsultaFactura = "consulta_factura_proveedor";

        /// <summary>
        /// Representa la función consulta_factura_proveedor_codigo.
        /// </summary>
        private const string sqlConsultaFacturaNumero =
            "consulta_factura_proveedor_codigo";

        /// <summary>
        /// Representa la funcion: count_consulta_factura_proveedor_codigo.
        /// </summary>
        private const string sqlCountFacturaNumero = "count_consulta_factura_proveedor_codigo";

        /// <summary>
        /// Representa la función consulta_factura_proveedor_fecha.
        /// </summary>
        private const string sqlConsultaFacturaFecha = "consulta_factura_proveedor_fecha";

        /// <summary>
        /// Representa la funcion count_consulta_factura_proveedor_fecha.
        /// </summary>
        private const string sqlCountFacturaFecha =
            "count_consulta_factura_proveedor_fecha";

        /// <summary>
        /// Representa la funcion consulta_factura_proveedor_periodo.
        /// </summary>
        private const string sqlConsultaFacturaPeriodo = "consulta_factura_proveedor_periodo";//

        /// <summary>
        /// Representa la funcion count_consulta_factura_proveedor_periodo.
        /// </summary>
        private const string sqlCountFacturaPeriodo = "count_consulta_factura_proveedor_periodo";

        /// <summary>
        /// Representa la función consulta_producto_factura_proveedor.
        /// </summary>
        private const string sqlConsultaProductoFactura = "consulta_producto_factura_proveedor";

        /// <summary>
        /// Representa la función consulta_factura_proveedor_codigo_activa.
        /// </summary>
        private const string sqlConsultaFacturaNumeroActiva =
            "consulta_factura_proveedor_codigo_activa";

        /// <summary>
        /// Representa la función count_consulta_factura_proveedor_codigo_activa.
        /// </summary>
        private const string sqlCountFacturaNumeroActiva = "count_consulta_factura_proveedor_codigo_activa";

        /// <summary>
        /// Representa la función consulta_factura_proveedor_fecha_activa.
        /// </summary>
        private const string sqlConsultaFacturaFechaActiva =
            "consulta_factura_proveedor_fecha_activa";

        /// <summary>
        /// Representa la función count_consulta_factura_proveedor_fecha_activa.
        /// </summary>
        private const string sqlCountFacturaFechaActiva = "count_consulta_factura_proveedor_fecha_activa";

        /// <summary>
        /// Representa la función consulta_factura_proveedor_periodo_activa.
        /// </summary>
        private const string sqlConsultaFacturaPeriodoActiva =
            "consulta_factura_proveedor_periodo_activa";

        /// <summary>
        /// Representa la función count_consulta_factura_proveedor_periodo_activa.
        /// </summary>
        private const string sqlCountFacturaPeriodoActiva = "count_consulta_factura_proveedor_periodo_activa";

        #endregion

        #region Mensajes

        /// <summary>
        /// Representa el texto: Ocurrio un error al actualizar el Lote.
        /// </summary>
        private const string EActualizaConsecutivo = "Ocurrio un error al actualizar el Lote.\n";

        /// <summary>
        /// Representa el texto: Ocurrio un error al obtener el númeor de Lote.
        /// </summary>
        private const string EObtenerConsecutivo = "Ocurrio un error al obtener el númeor de Lote.\n";

        /// <summary>
        /// Representa el texto: Ocurrion un error al ingresar la Facutar del Proveedor..
        /// </summary>
        private const string EIngresarFactura = "Ocurrio un error al ingresar la Facutar del Proveedor.\n";

        /// <summary>
        /// Representa el texto: Ocurrio un error al consultar la Factura del Proveedor.
        /// </summary>
        private const string EConsultaFacturaProveedor = "Ocurrio un error al consultar la Factura del Proveedor.\n";

        /// <summary>
        /// Representa el mensaje: Ocurrio un error al cargar el conteo total de registros.
        /// </summary>
        private const string ECountRows = "Ocurrio un error al cargar el conteo total de registros.\n";

        /// <summary>
        /// Ocurrio un error al cargar los Productos de la Factura.
        /// </summary>
        private const string EConsultaProductoFactura = "Ocurrio un error al cargar los Productos de la Factura.\n";

        /// <summary>
        /// Represent el texto: Ocurrio un error al editar los datos de la Factura de Proveedor.
        /// </summary>
        private const string EEditarFactura = "Ocurrio un error al editar los datos de la Factura de Proveedor.\n";

        #endregion

        /// <summary>
        /// Inicializa una nueva instancia de la clase DaoFacturaProveedor.
        /// </summary>
        public DaoFacturaProveedor()
        {
            this.miConexion = new Conexion();
            this.miDaoRetencion = new DaoRetencion();
        }

        /// <summary>
        /// Obtiene el consecutivo del número del Lote.
        /// </summary>
        /// <returns></returns>
        public string ObtenerNumeroLote()
        {
            try
            {
                CargarComando(ObtenerConsecutivo);
                miComando.Parameters.AddWithValue("cocepto", "Lote");
                miConexion.MiConexion.Open();
                var numeroLote = Convert.ToString(miComando.ExecuteScalar());
                miConexion.MiConexion.Close();
                miComando.Dispose();
                return numeroLote;
            }
            catch (Exception ex)
            {
                throw new Exception(EObtenerConsecutivo + ex.Message);
            }
            finally { miConexion.MiConexion.Close(); }
        }

        /// <summary>
        /// Actualiza el registro consecutivo del lote.
        /// </summary>
        /// <param name="lote">Número de lote a actualizar.</param>
        public void ActualizarLote(int lote)
        {
            var numero = lote + 1;
            try
            {
                CargarComando(ActualizarConsecutivo);
                miComando.Parameters.AddWithValue("concepto", "Lote");
                miComando.Parameters.AddWithValue("numero", numero.ToString());
                miConexion.MiConexion.Open();
                miComando.ExecuteNonQuery();
                miConexion.MiConexion.Close();
                miComando.Dispose();
            }
            catch (Exception ex)
            {
                throw new Exception(EActualizaConsecutivo + ex.Message);
            }
            finally { miConexion.MiConexion.Close(); }
        }

        /// <summary>
        /// Ingresa toda la información necesaria del registro de Factura de Proveedor.
        /// </summary>
        /// <param name="miFactura">Factura a ingresar.</param>
        public int IngresarFactura(FacturaProveedor miFactura, bool esFactura, bool retencion)
        {
            var existeInsumo = false;

            var miDaoConsecutivo = new DaoConsecutivo();
            var miDaoProducto = new DaoProducto();
            var miDaoFacturaProducto = new DaoProductoFacturaProveedor();
            var miDaoProveedor = new DaoProveedor();
            var miDaoInventario = new DaoInventario();
            var miDaoLote = new DaoLote();
            var miDaoRetencion = new DaoRetencion();
            var miDaoKardex = new DaoKardex();
            var kardex = new Kardex();
            try
            {
                if (esFactura)
                {
                    CargarComando(sqlInsertar);
                }
                else
                {
                    CargarComando("insertar_remision_proveedor");
                }
                miComando.Parameters.AddWithValue("proveedor", miFactura.Proveedor.CodigoInternoProveedor);
                miComando.Parameters.AddWithValue("pago", miFactura.EstadoFactura.Id);
                miComando.Parameters.AddWithValue("caja", miFactura.Caja.Id);
                miComando.Parameters.AddWithValue("usuario", miFactura.Usuario.Id);
                miComando.Parameters.AddWithValue("numero", miFactura.Numero);
                miComando.Parameters.AddWithValue("limite", miFactura.FechaLimite);
                miComando.Parameters.AddWithValue("fecha", miFactura.FechaIngreso);
                miComando.Parameters.AddWithValue("estado", miFactura.Estado);
                miComando.Parameters.AddWithValue("descuento", miFactura.Descuento);
                if (esFactura)
                {
                    miComando.Parameters.AddWithValue("esfactura", miFactura.EsFactura);
                }
                miComando.Parameters.AddWithValue("ajuste", miFactura.Ajuste);
                if (!esFactura)
                {
                    miComando.Parameters.AddWithValue("ajuste", miFactura.Facturada);
                }
                miComando.Parameters.AddWithValue("fecha_factura", miFactura.FechaFactura);
                if (esFactura)
                {
                    miComando.Parameters.AddWithValue("nota", miFactura.Nota);
                }
                miConexion.MiConexion.Open();
                var id = Convert.ToInt32(miComando.ExecuteScalar());
                miConexion.MiConexion.Close();
                miComando.Dispose();
                if (!miFactura.EsFactura)
                {
                    miDaoConsecutivo.ActualizarConsecutivo("Documento");
                }
                foreach (var productos in miFactura.Productos)
                {
                    productos.IdFactura = id;
                    if (productos.Lote.Id.Equals(0))
                    {
                        productos.Lote.Id = miDaoLote.IngresarLote(productos.Lote);
                    }
                    miDaoFacturaProducto.IngresarProductoFacturaProveedor(productos, esFactura);
                    miDaoProveedor.IngresarProductoDeProveedor
                        (miFactura.Proveedor.CodigoInternoProveedor, productos.Producto.CodigoInternoProducto);
                    if (!miFactura.Facturada)
                    {
                        if (productos.Producto.IdTipoInventario.Equals(1))
                        {
                            miDaoInventario.ActualizarInventario(productos.Inventario, false);
                        }
                        else
                        {
                            if (productos.Producto.IdTipoInventario.Equals(2))
                            {
                                existeInsumo = true;
                            }
                        }

                        /*if (!productos.Producto.IdTipoInventario.Equals(2))  // tipo inventario 2 : Insumos o mat. primas  
                        {
                            miDaoInventario.ActualizarInventario(productos.Inventario, false);
                        }
                        else
                        {
                            existeInsumo = true;
                        }*/

                        /// Revisar codigo de actualizacion de costo por uso de preingreso e ingreso de compra. 21-12-2021
                        /**
                        miDaoProducto.EditarPrecioDeCosto
                            (productos.Producto.CodigoInternoProducto, productos.ValorReal, productos.ImpoConsumo);
                        */

                        
                        miDaoProducto.EditarPrecioDeCosto
                            (productos.Producto.CodigoInternoProducto, productos.Producto.ValorCosto, productos.ImpoConsumo);
                        
                        /*miDaoProducto.EditarPrecioDeCosto
                            (productos.Producto.CodigoInternoProducto, (productos.Producto.ValorCosto + productos.ImpoConsumo));*/
                    }
                    kardex.IdCompra = id;
                    kardex.Codigo = productos.Producto.CodigoInternoProducto;
                    kardex.IdUsuario = miFactura.Usuario.Id;
                    if (esFactura)
                    {
                        kardex.IdConcepto = 1;
                    }
                    else
                    {
                        kardex.IdConcepto = 2;
                    }
                    kardex.NoDocumento = miFactura.Numero;
                    kardex.Fecha = DateTime.Now;
                    kardex.Cantidad = productos.Inventario.Cantidad;
                    double iva =
                        Math.Round((productos.Producto.ValorCosto * productos.Producto.ValorIva / 100), 2);
                    kardex.Valor = productos.Producto.ValorCosto + Convert.ToInt32(iva);
                    kardex.Total = kardex.Valor * kardex.Cantidad;
                    //kardex.Valor = productos.Producto.ValorCosto;
                    miDaoKardex.Insertar(kardex);
                }
                if (retencion && esFactura)
                {
                    miFactura.Retencion.Retencion.Id = id;
                    miDaoRetencion.IngresarFacturaRetencion(miFactura.Retencion);
                }

                if (existeInsumo)
                {
                    ProductosProceso(miFactura.Productos, miDaoProducto, miDaoInventario);
                }

                return id;
            }
            catch (Exception ex)
            {
                throw new Exception(EIngresarFactura + ex.Message);
            }
            finally { miConexion.MiConexion.Close(); }
        }

        private void ProductosProceso(List<ProductoFacturaProveedor> productos, DaoProducto miDaoProducto, DaoInventario miDaoInventario)
        {
            try
            {
                double costo = 0;
                var productosProceso = new List<ProductoFacturaProveedor>();
                foreach (var p in productos)
                {
                    if (p.Producto.IdTipoInventario.Equals(2))  // tipo inventario 2 : Insumos o mat. primas  
                    {
                        var product = new ProductoFacturaProveedor();
                        product.Codigo = miDaoProducto.CodigoProductoProceso(p.Producto.CodigoInternoProducto);
                        product.Cantidad = Convert.ToInt32(p.Producto.UnidadVentaProducto * p.Cantidad);
                        product.Costo = Convert.ToInt32(p.Producto.ValorCosto * p.Cantidad);

                        product.Inventario.IdMedida = p.Inventario.IdMedida;
                        product.Inventario.IdColor = p.Inventario.IdColor;

                        productosProceso.Add(product);
                    }
                }
                if (productosProceso.Count > 0)
                {
                    var result = from item in productosProceso
                                 group item by new
                                 {
                                     item.Codigo,
                                     item.Inventario.IdMedida,
                                     item.Inventario.IdColor,
                                     //item.Cantidad,
                                     //item.Costo
                                 }
                                     into it
                                     select new
                                     {
                                         it.Key.Codigo,
                                         it.Key.IdMedida,
                                         it.Key.IdColor,
                                         Cantidad = it.Sum(s => s.Cantidad),
                                         Costo = it.Sum(s => s.Costo)
                                     };
                    foreach (var r in result)
                    {
                        // Actualiza inventario
                        if (r.Codigo != "")
                        {
                            miDaoInventario.ActualizarInventario(
                                new Inventario
                                {
                                    CodigoProducto = r.Codigo,
                                    IdMedida = r.IdMedida,
                                    IdColor = r.IdColor,
                                    Cantidad = r.Cantidad
                                }, false);

                            // Actualiza costo
                            costo = miDaoProducto.PrecioDeCosto(r.Codigo);
                            costo += Math.Round((r.Costo / r.Cantidad), 2);
                            costo = Math.Round((costo / 2), 2);
                            miDaoProducto.EditarCosto(r.Codigo, costo);
                        }

                        // Kardex ?
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al cargar los productos en proceso.\n" + ex.Message);
            }
        }

        public bool EsFacturaVenta(int idFactura)
        {
            try
            {
                CargarComando("es_factura_venta");
                miComando.Parameters.AddWithValue("id", idFactura);
                miConexion.MiConexion.Open();
                var esFactura = Convert.ToBoolean(miComando.ExecuteScalar());
                miConexion.MiConexion.Close();
                miComando.Dispose();
                return esFactura;
            }
            catch (Exception ex)
            {
                throw new Exception(EConsultaFacturaProveedor + ex.Message);
            }
            finally { miConexion.MiConexion.Close(); }
        }

        /// <summary>
        /// Obtiene los registros de la consulta de una Factura de Proveedor.
        /// </summary>
        /// <param name="id">Número de identificación unico de la Factura.</param>
        /// <returns></returns>
        public FacturaProveedor ConsultaFacturaProveedor(int id)
        {
            var factura = new FacturaProveedor();
            try
            {
                CargarComando(sqlConsultaFactura);
                miComando.Parameters.AddWithValue("id", id);
                miConexion.MiConexion.Open();
                NpgsqlDataReader miReader = miComando.ExecuteReader();
                while (miReader.Read())
                {
                    factura.Id = miReader.GetInt32(0);
                    factura.Proveedor.CodigoInternoProveedor = miReader.GetInt32(1);
                    factura.EstadoFactura.Id = miReader.GetInt32(2);
                    factura.Caja.Id = miReader.GetInt32(3);
                    factura.Usuario.Id = miReader.GetInt32(4);
                    factura.Numero = miReader.GetString(5);
                    factura.FechaLimite = miReader.GetDateTime(6);
                    factura.FechaIngreso = miReader.GetDateTime(7);
                    factura.Estado = miReader.GetBoolean(8);
                    factura.Descuento = miReader.GetDouble(9);
                    factura.Ajuste = miReader.GetDouble(12);
                    factura.FechaFactura = miReader.GetDateTime(13);
                }
                miConexion.MiConexion.Close();
                miComando.Dispose();
                return factura;
            }
            catch (Exception ex)
            {
                throw new Exception(EConsultaFacturaProveedor + ex.Message);
            }
            finally { miConexion.MiConexion.Close(); }
        }

        public DataTable FacturaProveedorEstado(string nit)
        {
            var tabla = new DataTable();
            try
            {
                CargarAdapter("consulta_factura_proveedor");
                miAdapter.SelectCommand.Parameters.AddWithValue("nit", nit);
                miAdapter.Fill(tabla);
                return tabla;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public DataTable FacturaProveedorTodas(string nit)
        {
            var tabla = new DataTable();
            try
            {
                CargarAdapter("consulta_factura_proveedor_todas");
                miAdapter.SelectCommand.Parameters.AddWithValue("nit", nit);
                miAdapter.Fill(tabla);
                return tabla;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public DataTable FacturaProveedorEstado()
        {
            var tabla = new DataTable();
            try
            {
                CargarAdapter("consulta_factura_proveedor");
                miAdapter.Fill(tabla);
                return tabla;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public DataTable Consulta(int registroBase, int registroMax)
        {
            var tabla = new DataTable();
            try
            {
                CargarAdapter("consulta_factura_proveedor_todas");
                miAdapter.Fill(registroBase, registroMax, tabla);
                return tabla;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al consultar las facturas de proveedor.\n" + ex.Message);
            }
        }

        public long GetRowsConsulta()
        {
            try
            {
                CargarComando("count_consulta_factura_proveedor_todas");
                miConexion.MiConexion.Open();
                var rows = Convert.ToInt64(miComando.ExecuteScalar());
                miConexion.MiConexion.Close();
                miComando.Dispose();
                return rows;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al cargar el conteo de los registros.\n" + ex.Message);
            }
            finally { miConexion.MiConexion.Close(); }
        }

        /// <summary>
        /// Obtiene los registros de la consulta de una Factura de Proveedor.
        /// </summary>
        /// <param name="numero">Número de la Factura a consultar.</param>
        /// <param name="activa">Indica si solo se recupera registros activos.</param>
        /// <returns></returns>
        public DataTable ConsultaFacturaProveedor(string numero, bool activa)
        {
            var tabla = new DataTable();
            try
            {
                if (!activa)
                {
                    CargarAdapter(sqlConsultaFacturaNumeroActiva);
                }
                else
                {
                    CargarAdapter(sqlConsultaFacturaNumero);
                }
                miAdapter.SelectCommand.Parameters.AddWithValue("numero", numero);
                miAdapter.Fill(tabla);
                return tabla;
            }
            catch (Exception ex)
            {
                throw new Exception(EConsultaFacturaProveedor + ex.Message);
            }
        }

        /// <summary>
        /// Obtiene los registros de la consulta de una Factura de Proveedor.
        /// </summary>
        /// <param name="codigo">Codigo del Proveedor a consultar.</param>
        /// <param name="activa">Indica si solo se recupera registros activos.</param>
        /// <param name="registroBase">Registro base para la consulta.</param>
        /// <param name="registroMax">Número de registros a recuperar.</param>
        /// <returns></returns>
        public DataTable ConsultaFacturaProveedor(int codigo, bool activa, int registroBase, int registroMax)
        {
            var dataSet = new DataSet();
            try
            {
                if (!activa)
                {
                    CargarAdapter(sqlConsultaFacturaNumeroActiva);
                }
                else
                {
                    CargarAdapter(sqlConsultaFacturaNumero);
                }
                miAdapter.SelectCommand.Parameters.AddWithValue("codigo", codigo);
                miAdapter.Fill(dataSet, registroBase, registroMax, "factura");
                return dataSet.Tables[0];
            }
            catch (Exception ex)
            {
                throw new Exception(EConsultaFacturaProveedor + ex.Message);
            }
        }

        public DataTable ConsultaFacturaProveedor(int codigo, bool activa)
        {
            var tabla = new DataTable();
            try
            {
                if (!activa)
                {
                    CargarAdapter(sqlConsultaFacturaNumeroActiva);
                }
                else
                {
                    CargarAdapter(sqlConsultaFacturaNumero);
                }
                miAdapter.SelectCommand.Parameters.AddWithValue("codigo", codigo);
                miAdapter.Fill(tabla);
                return tabla;
            }
            catch (Exception ex)
            {
                throw new Exception(EConsultaFacturaProveedor + ex.Message);
            }
        }

        /// <summary>
        /// Obtiene el total de registros de una consulta de Factura de Proveedor.
        /// </summary>
        /// <param name="codigo">Codigo del Proveedor a consultar.</param>
        /// <param name="activa">Indica si solo se recupera registros activos.</param>
        /// <returns></returns>
        public long GetRowsConsultaFacturaProveedor(int codigo, bool activa)
        {
            try
            {
                if (!activa)
                {
                    CargarComando(sqlCountFacturaNumeroActiva);
                }
                else
                {
                    CargarComando(sqlCountFacturaNumero);
                }
                miComando.Parameters.AddWithValue("codigo", codigo);
                miConexion.MiConexion.Open();
                var rows = Convert.ToInt64(miComando.ExecuteScalar());
                miConexion.MiConexion.Close();
                miComando.Dispose();
                return rows;
            }
            catch (Exception ex)
            {
                throw new Exception(ECountRows + ex.Message);
            }
            finally { miConexion.MiConexion.Close(); }
        }

        /// <summary>
        /// Obtiene los registros de la consulta de una Factura de Proveedor.
        /// </summary>
        /// <param name="fecha">Fecha con la cual se compara la fecha con la que ingreso la Factura.</param>
        /// <param name="activa">Indica si solo se recupera registros activos.</param>
        /// <param name="registroBase">Registro base para la consulta.</param>
        /// <param name="registroMax">Número de registros a recuperar.</param>
        /// <returns></returns>
        public DataTable ConsultaFacturaProveedor
            (DateTime fecha, bool activa, int registroBase, int registroMax)
        {
            var dataSet = new DataSet();
            try
            {
                if (!activa)
                {
                    CargarAdapter(sqlConsultaFacturaFechaActiva);
                }
                else
                {
                    CargarAdapter(sqlConsultaFacturaFecha);
                }
                miAdapter.SelectCommand.Parameters.AddWithValue("fecha", fecha);
                miAdapter.Fill(dataSet, registroBase, registroMax, "factura");
                return dataSet.Tables[0];
            }
            catch (Exception ex)
            {
                throw new Exception(EConsultaFacturaProveedor + ex.Message);
            }
        }

        /// <summary>
        /// Obtiene el total de registros de una consulta de Factura de Proveedor.
        /// </summary>
        /// <param name="fecha">Fecha con la cual se compara la fecha con la que ingreso la Factura.</param>
        /// <param name="activa">Indica si solo se recupera registros activos.</param>
        /// <returns></returns>
        public long GetRowsConsultaFacturaProveedor(DateTime fecha, bool activa)
        {
            try
            {
                if (!activa)
                {
                    CargarComando(sqlCountFacturaFechaActiva);
                }
                else
                {
                    CargarComando(sqlCountFacturaFecha);
                }
                miComando.Parameters.AddWithValue("fecha", fecha);
                miConexion.MiConexion.Open();
                var rows = Convert.ToInt64(miComando.ExecuteScalar());
                miConexion.MiConexion.Close();
                miComando.Dispose();
                return rows;
            }
            catch (Exception ex)
            {
                throw new Exception(ECountRows + ex.Message);
            }
            finally { miConexion.MiConexion.Close(); }
        }

        /// <summary>
        /// Obtiene los registros de la consulta de una Factura de Proveedor.
        /// </summary>
        /// <param name="codigo">Codigo del Proveedor a consultar.</param>
        /// <param name="fecha">Fecha con la cual se compara la fecha con la que ingreso la Factura.</param>
        /// <param name="activa">Indica si solo se recupera registros activos.</param>
        /// <returns></returns>
        public DataTable ConsultaFacturaProveedor(int codigo, DateTime fecha, bool activa)
        {
            var tabla = new DataTable();
            try
            {
                if (!activa)
                {
                    CargarAdapter(sqlConsultaFacturaFechaActiva);
                }
                else
                {
                    CargarAdapter(sqlConsultaFacturaFecha);
                }
                miAdapter.SelectCommand.Parameters.AddWithValue("codigo", codigo);
                miAdapter.SelectCommand.Parameters.AddWithValue("fecha", fecha);
                miAdapter.Fill(tabla);
                return tabla;
            }
            catch (Exception ex)
            {
                throw new Exception(EConsultaFacturaProveedor + ex.Message);
            }
        }

        /// <summary>
        /// Obtiene los registros de la consulta de una Factura de Proveedor.
        /// </summary>
        /// <param name="fecha1">Primer fecha que proporciona el periodo.</param>
        /// <param name="fecha2">Segunda fecha que proporciona el periodo.</param>
        /// <param name="activa">Indica si solo se recupera registros activos.</param>
        /// <param name="registroBase">Registro base para la consulta.</param>
        /// <param name="registroMax">Número de registros a recuperar.</param>
        /// <returns></returns>
        public DataTable ConsultaFacturaProveedor
            (DateTime fecha1, DateTime fecha2, bool activa, int registroBase, int registroMax)
        {
            var dataSet = new DataSet();
            try
            {
                if (!activa)
                {
                    CargarAdapter(sqlConsultaFacturaPeriodoActiva);
                }
                else
                {
                    CargarAdapter(sqlConsultaFacturaPeriodo);
                }
                miAdapter.SelectCommand.Parameters.AddWithValue("fecha1", fecha1);
                miAdapter.SelectCommand.Parameters.AddWithValue("fecha2", fecha2);
                miAdapter.Fill(dataSet, registroBase, registroMax, "factura");
                return dataSet.Tables[0];
            }
            catch (Exception ex)
            {
                throw new Exception(EConsultaFacturaProveedor + ex.Message);
            }
        }

        /// <summary>
        /// Obtiene el total de registros de una consulta de Factura de Proveedor.
        /// </summary>
        /// <param name="fecha1">Primer fecha que proporciona el periodo.</param>
        /// <param name="fecha2">Segunda fecha que proporciona el periodo.</param>
        /// <param name="activa">Indica si solo se recupera registros activos.</param>
        /// <returns></returns>
        public long GetRowsConsultaFacturaProveedor(DateTime fecha1, DateTime fecha2, bool activa)
        {
            try
            {
                if (!activa)
                {
                    CargarComando(sqlCountFacturaPeriodoActiva);
                }
                else
                {
                    CargarComando(sqlCountFacturaPeriodo);
                }
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
                throw new Exception(ECountRows + ex.Message);
            }
            finally { miConexion.MiConexion.Close(); }
        }

        /// <summary>
        /// Obtiene los registros de la consulta de una Factura de Proveedor.
        /// </summary>
        /// <param name="codigo">Codigo del Proveedor a consultar.</param>
        /// <param name="fecha1">Primer fecha que proporciona el periodo.</param>
        /// <param name="fecha2">Segunda fecha que proporciona el periodo.</param>
        /// <param name="activa">Indica si solo se recupera registros activos.</param>
        /// <param name="registroBase">Registro base para la consulta.</param>
        /// <param name="registroMax">Número de registros a recuperar.</param>
        /// <returns></returns>
        public DataTable ConsultaFacturaProveedor
            (int codigo, DateTime fecha1, DateTime fecha2, bool activa, int registroBase, int registroMax)
        {
            var dataSet = new DataSet();
            try
            {
                if (!activa)
                {
                    CargarAdapter(sqlConsultaFacturaPeriodoActiva);
                }
                else
                {
                    CargarAdapter(sqlConsultaFacturaPeriodo);
                }
                miAdapter.SelectCommand.Parameters.AddWithValue("codigo", codigo);
                miAdapter.SelectCommand.Parameters.AddWithValue("fecha1", fecha1);
                miAdapter.SelectCommand.Parameters.AddWithValue("fecha2", fecha2);
                miAdapter.Fill(dataSet, registroBase, registroMax, "factura");
                return dataSet.Tables[0];
            }
            catch (Exception ex)
            {
                throw new Exception(EConsultaFacturaProveedor + ex.Message);
            }
        }

        public DataTable ConsultaFacturaProveedor
            (int codigo, DateTime fecha1, DateTime fecha2)
        {
            var tabla = new DataTable();
            try
            {
                CargarAdapter(sqlConsultaFacturaPeriodoActiva);
                miAdapter.SelectCommand.Parameters.AddWithValue("codigo", codigo);
                miAdapter.SelectCommand.Parameters.AddWithValue("fecha1", fecha1);
                miAdapter.SelectCommand.Parameters.AddWithValue("fecha2", fecha2);
                miAdapter.Fill(tabla);
                return tabla;
            }
            catch (Exception ex)
            {
                throw new Exception(EConsultaFacturaProveedor + ex.Message);
            }
        }

        /// <summary>
        /// Obtiene el total de registros de una consulta de Factura de Proveedor.
        /// </summary>
        /// <param name="codigo">Codigo del Proveedor a consultar.</param>
        /// <param name="fecha1">Primer fecha que proporciona el periodo.</param>
        /// <param name="fecha2">Segunda fecha que proporciona el periodo.</param>
        /// <param name="activa">Indica si solo se recupera registros activos.</param>
        /// <returns></returns>
        public long GetRowsConsultaFacturaProveedor
            (int codigo, DateTime fecha1, DateTime fecha2, bool activa)
        {
            try
            {
                if (!activa)
                {
                    CargarComando(sqlCountFacturaPeriodoActiva);
                }
                else
                {
                    CargarComando(sqlCountFacturaPeriodo);
                }
                miComando.Parameters.AddWithValue("codigo", codigo);
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
                throw new Exception(ECountRows + ex.Message);
            }
            finally { miConexion.MiConexion.Close(); }
        }

        public DataTable ConsultaFacturasConSaldo()
        {
            DataTable tabla = new DataTable();
            try
            {
                var factura = new DataTable();
                CargarAdapter("consulta_factura_proveedor_credito");
                miAdapter.Fill(factura);
                var query = from data in factura.AsEnumerable()
                            select data;
                if (query.ToArray().Length != 0)
                {
                    tabla = query.CopyToDataTable<DataRow>();
                }
                tabla.Rows.Clear();
                foreach (DataRow fRow in factura.Rows)
                {
                    var valor = GetValorFactura(Convert.ToInt32(fRow["Id"]));
                    var tRetenciones = miDaoRetencion.RetencionesACompra(Convert.ToInt32(fRow["Id"]));
                    var retencion = 0;
                    foreach (DataRow rRow in tRetenciones.Rows)
                    {
                        retencion += Convert.ToInt32(valor * Convert.ToDouble(rRow["tarifa"]) / 100);
                    }
                    valor -= retencion;
                    var pagos = PagosAProveedor(Convert.ToInt32(fRow["Id"]));
                    if (Convert.ToDouble(pagos) < valor)
                    {
                        var row_ = tabla.NewRow();
                        row_[0] = fRow[0];
                        row_[1] = fRow[1];
                        row_[2] = fRow[2];
                        row_[3] = fRow[3];
                        row_[4] = fRow[4];
                        row_[5] = fRow[5];
                        row_[6] = fRow[6];
                        row_[7] = fRow[7];
                        row_[8] = fRow[8];
                        row_[9] = fRow[9];
                        row_[10] = fRow[10];
                        row_[11] = fRow[11];
                        row_[12] = fRow[12];
                        row_[13] = fRow[13];
                        tabla.Rows.Add(row_);
                        /*var row_ = tabla.NewRow();
                        row_ = fRow.;
                        tabla.Rows.Add(row_);*/
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return tabla;
        }

        public double GetValorFactura(int id)
        {
            var miTabla = CrearDataTable();
            var tabla = ConsultaProductoFacturaProveedor(id);
            foreach (DataRow row in tabla.Rows)
            {
                var row_ = miTabla.NewRow();
                row_["Iva"] = row["Iva"].ToString() + "%";
                row_["Valor"] = row["Valor"];
                row_["Descuento"] = row["Descuento"].ToString() + "%";
                row_["ValorMenosDescto"] = Convert.ToDouble(row["Valor"]) -
                              (Convert.ToDouble(row["Valor"]) * Convert.ToDouble(row["Descuento"]) / 100);
                row_["ValorIva"] = Convert.ToDouble(row_["ValorMenosDescto"]) * Convert.ToDouble(row["Iva"]) / 100;
                row_["TotalMasIva"] = Convert.ToDouble(row_["ValorMenosDescto"]) + Convert.ToDouble(row_["ValorIva"]);
                row_["Total"] = Convert.ToDouble(row_["TotalMasIva"]) * Convert.ToDouble(row["Cantidad"]);
                miTabla.Rows.Add(row_);
            }
            var suma = miTabla.AsEnumerable().Sum(s => s.Field<double>("Total"));
            tabla.Clear();
            tabla = null;
            miTabla.Clear();
            miTabla = null;
            return suma;
        }

        public double ConsultaAjuste(int id)
        {
            try
            {
                CargarComando("consulta_ajuste_compra");
                miComando.Parameters.AddWithValue("id", id);
                miConexion.MiConexion.Open();
                var rows = Convert.ToDouble(miComando.ExecuteScalar());
                miConexion.MiConexion.Close();
                miComando.Dispose();
                return rows;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al cargar el ajuste.\n" + ex.Message);
            }
            finally { miConexion.MiConexion.Close(); }
        }

        public DataTable ComprasAproveedor(DateTime fecha, DateTime fecha1)
        {
            var miDaoProveedor = new DaoProveedor();
            var tCompra = new DataTable();
            tCompra.Columns.Add(new DataColumn("Nit", typeof(string)));
            tCompra.Columns.Add(new DataColumn("Nombre", typeof(string)));
            tCompra.Columns.Add(new DataColumn("Cant", typeof(double)));
            try
            {
                var proveedores = miDaoProveedor.ObtenerDataSetType();
                foreach (DataRow pRow in proveedores.Tables["view_lista_proveedor"].Rows)
                {
                    var tRow = tCompra.NewRow();
                    tRow["Nit"] = pRow["Nit"].ToString();
                    tRow["Nombre"] = pRow["Nombre"].ToString();
                    var cant = 0.0;
                    var facturas = ConsultaFacturaProveedor(Convert.ToInt32(pRow["Codigo"]), fecha, fecha1);
                    foreach (DataRow fRow in facturas.Rows)
                    {
                        var productos = ConsultaProductos(Convert.ToInt32(fRow["Id"]));
                        cant += productos.AsEnumerable().Sum(s => s.Field<double>("Cantidad"));
                    }
                    tRow["Cant"] = cant;
                    tCompra.Rows.Add(tRow);
                }
                return tCompra;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al consultar las compras.\n" + ex.Message);
            }
        }

        // Ajuste a preingreso
        public double CantidadProductoCompra(string codigo)
        {
            try
            {
                CargarComando("cantidad_ultima_compra_proveedor");
                this.miComando.Parameters.AddWithValue("", codigo);
                this.miConexion.MiConexion.Open();
                double cant = Convert.ToDouble(this.miComando.ExecuteScalar());
                this.miConexion.MiConexion.Close();
                this.miComando.Dispose();
                return cant;
            }
            catch (InvalidCastException)
            {
                return 0;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al consultar la cantidad existente del en la compra." + ex.Message);
            }
            finally { this.miConexion.MiConexion.Close(); }
        }

        public ProductoFacturaProveedor UltimoRegistroCompra(string codigo)
        {
            ProductoFacturaProveedor producto = new ProductoFacturaProveedor();
            try
            {
                CargarComando("registro_ultima_compra_proveedor");
                miComando.Parameters.AddWithValue("", codigo);
                miConexion.MiConexion.Open();
                NpgsqlDataReader reader = miComando.ExecuteReader();
                //var b = reader.IsDBNull(0);
                while (reader.Read())
                {
                    producto.Cantidad = reader.GetDouble(6);
                    producto.Valor = reader.GetDouble(7);
                    producto.Producto.ValorIva = reader.GetDouble(8);
                }
                miConexion.MiConexion.Close();
                miComando.Dispose();
                return producto;
            }
            catch (InvalidCastException)
            {
                return producto;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al consultar el ultimo registro de compra.\n" + ex.Message);
            }
            finally { miConexion.MiConexion.Close(); }
        }

        /// <summary>
        /// Obtiene los registros de los producto relacionado a una Factura de Proveedor.
        /// </summary>
        /// <param name="id">Id de la Factura consultada.</param>
        /// <returns></returns>
        public DataTable ConsultaProductoFacturaProveedor(int id)//Toca pasalo...
        {
            var tabla = new DataTable();
            try
            {
                CargarAdapter(sqlConsultaProductoFactura);
                miAdapter.SelectCommand.Parameters.AddWithValue("id", id);
                miAdapter.Fill(tabla);
                return tabla;
            }
            catch (Exception ex)
            {
                throw new Exception(EConsultaProductoFactura + ex.Message);
            }
        }

        /// <summary>
        /// Edita los datos de un registro de FacturaProveedor en base de datos.
        /// </summary>
        /// <param name="factura">Registro de FacturaProveedor a editar.</param>
        public void EditarFacturaProveedor(FacturaProveedor factura)
        {
            var miDaoProveedor = new DaoProveedor();
            var miDaoProducto = new DaoProducto();
            var miDaoFacturaProducto = new DaoProductoFacturaProveedor();
            var miDaoInventario = new DaoInventario();
            var miDaoRetencion = new DaoRetencion();
            try
            {
                var tempFactura = ConsultaFacturaProveedor(factura.Id);
                var proveedorActual = miDaoProveedor.ConsultarPrveedorBasico
                    (tempFactura.Proveedor.CodigoInternoProveedor);
                var proveedorNew = miDaoProveedor.ConsultarPrveedorBasico
                    (factura.Proveedor.CodigoInternoProveedor);
                var productos = ConsultaProductoFacturaProveedor(factura.Id);
                if (factura.Proveedor.CodigoInternoProveedor != tempFactura.Proveedor.CodigoInternoProveedor)
                {
                    if (proveedorActual.IdRegimen != proveedorNew.IdRegimen)
                    {

                        ProductoFacturaProveedor miProducto;
                        if (proveedorNew.IdRegimen == 1)
                        {
                            foreach (DataRow row in productos.Rows)
                            {
                                var producto = miDaoProducto.ProductoBasico(row["Codigo"].ToString());
                                miProducto = new ProductoFacturaProveedor();
                                miProducto.Id = Convert.ToInt32(row["Id"]);
                                miProducto.IdFactura = Convert.ToInt32(row["Numero"]);
                                miProducto.Producto.CodigoInternoProducto = row["Codigo"].ToString();
                                miProducto.Inventario.IdMedida = Convert.ToInt32(row["IdMedida"]);
                                miProducto.Inventario.IdColor = Convert.ToInt32(row["IdColor"]);
                                miProducto.Lote.Id = Convert.ToInt32(row["IdLote"]);
                                miProducto.Cantidad = Convert.ToDouble(row["Cantidad"]);
                                miProducto.Producto.ValorVentaProducto = Convert.ToInt32(row["Valor"]);
                                miProducto.Producto.ValorIva = ((Producto)producto[0]).ValorIva;
                                miProducto.Producto.Descuento = Convert.ToDouble(row["Descuento"]);
                                miDaoFacturaProducto.EditarProductoFacturaProveedor(miProducto);
                            }
                        }
                        else
                        {
                            foreach (DataRow row in productos.Rows)
                            {
                                miProducto = new ProductoFacturaProveedor();
                                miProducto.Id = Convert.ToInt32(row["Id"]);
                                miProducto.IdFactura = Convert.ToInt32(row["Numero"]);
                                miProducto.Producto.CodigoInternoProducto = row["Codigo"].ToString();
                                miProducto.Inventario.IdMedida = Convert.ToInt32(row["IdMedida"]);
                                miProducto.Inventario.IdColor = Convert.ToInt32(row["IdColor"]);
                                miProducto.Lote.Id = Convert.ToInt32(row["IdLote"]);
                                miProducto.Cantidad = Convert.ToDouble(row["Cantidad"]);
                                miProducto.Producto.ValorVentaProducto = Convert.ToInt32(row["Valor"]);
                                miProducto.Producto.ValorIva = 0;
                                miProducto.Producto.Descuento = Convert.ToDouble(row["Descuento"]);
                                miDaoFacturaProducto.EditarProductoFacturaProveedor(miProducto);
                            }
                        }
                    }
                }
                if (factura.Descuento != tempFactura.Descuento)
                {
                    // var productos = ConsultaProductoFacturaProveedor(factura.Id);
                    foreach (DataRow row in productos.Rows)
                    {
                        var producto = new ProductoFacturaProveedor();
                        producto.Id = Convert.ToInt32(row["Id"]);
                        producto.IdFactura = Convert.ToInt32(row["Numero"]);
                        producto.Producto.CodigoInternoProducto = row["Codigo"].ToString();
                        producto.Inventario.IdMedida = Convert.ToInt32(row["IdMedida"]);
                        producto.Inventario.IdColor = Convert.ToInt32(row["IdColor"]);
                        producto.Lote.Id = Convert.ToInt32(row["IdLote"]);
                        producto.Cantidad = Convert.ToDouble(row["Cantidad"]);
                        producto.Producto.ValorVentaProducto = Convert.ToInt32(row["Valor"]);
                        producto.Producto.ValorIva = Convert.ToDouble(row["Iva"]);
                        producto.Producto.Descuento = factura.Descuento;
                        miDaoFacturaProducto.EditarProductoFacturaProveedor(producto);
                    }
                }
                if (factura.Estado != tempFactura.Estado)
                {
                    foreach (DataRow row in productos.Rows)
                    {
                        var inventario = new Inventario();
                        inventario.CodigoProducto = row["Codigo"].ToString();
                        inventario.IdMedida = Convert.ToInt32(row["IdMedida"]);
                        inventario.IdColor = Convert.ToInt32(row["IdColor"]);
                        inventario.Cantidad = Convert.ToDouble(row["Cantidad"]);
                        if (factura.Estado)
                        {
                            miDaoInventario.ActualizarInventario(inventario, false);
                        }
                        else
                        {
                            miDaoInventario.ActualizarInventario(inventario, true);
                        }
                    }
                }
                CargarComando(sqlEditar);
                miComando.Parameters.AddWithValue("id", factura.Id);
                miComando.Parameters.AddWithValue("producto", factura.Proveedor.CodigoInternoProveedor);
                miComando.Parameters.AddWithValue("formaPago", factura.EstadoFactura.Id);
                miComando.Parameters.AddWithValue("numero", factura.Numero);
                miComando.Parameters.AddWithValue("limite", factura.FechaLimite);
                miComando.Parameters.AddWithValue("ingreso", factura.FechaIngreso);
                miComando.Parameters.AddWithValue("estado", factura.Estado);
                miComando.Parameters.AddWithValue("descuento", factura.Descuento);
                miComando.Parameters.AddWithValue("ajuste", factura.Ajuste);
                miComando.Parameters.AddWithValue("fecha_factura", factura.FechaFactura);
                miConexion.MiConexion.Open();
                miComando.ExecuteNonQuery();
                miConexion.MiConexion.Close();
                miComando.Dispose();
                factura.Retencion.IdCuentaPuc = factura.Id;
                if (factura.Retencion.Id.Equals(0))
                {
                    factura.Retencion.Retencion.Id = factura.Id;
                    miDaoRetencion.IngresarFacturaRetencion(factura.Retencion);
                }
                else
                {
                    miDaoRetencion.EdtarRetencionDeCompra(factura.Retencion);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(EEditarFactura + ex.Message);
            }
            finally { miConexion.MiConexion.Close(); }
        }

        public double SaldoAProveedor(string nit)
        {
            double totalFact = 0;
            int pagosFact = 0;
            double saldo = 0;
            double saldoTotal = 0;

            var daoProveedor = new DaoProveedor();
            var p = daoProveedor.ConsultaProveedorNit(nit);
            var tablaProveedor = p.Tables["view_lista_proveedor"];
            string codigo = "0";
            if (tablaProveedor.Rows.Count != 0)
            {
                var pRow = tablaProveedor.Rows[0];
                codigo = pRow["Codigo"].ToString();
            }
            var proveedor = ConsultaFacturaProveedor(Convert.ToInt32(codigo), true);// FacturaProveedorEstado(nit);
            daoProveedor = null;
            p = null;
            tablaProveedor = null;

            /* foreach (DataRow fRow in proveedor.Rows)
             {
                 var producto = ConsultaProductoFacturaProveedor(Convert.ToInt32(fRow["Id"]));
                 foreach (DataRow rProducto in producto.Rows)
                 {
                     var valor_desto = Math.Round((Convert.ToDouble(rProducto["Valor"]) -
                     (Convert.ToDouble(rProducto["Valor"]) * Convert.ToDouble(rProducto["Descuento"]) / 100)), 2);

                 }
             }*/

            /*foreach (DataRow fRow in proveedor.Rows)
            {
                var producto = ConsultaProductos(Convert.ToInt32(fRow["Id"]));
                totalFact = Convert.ToInt32(producto.AsEnumerable().Sum(t => t.Field<double>("Total")));
                totalFact += Convert.ToDouble(fRow["valor_ajuste"]);
                pagosFact = PagosAProveedor(Convert.ToInt32(fRow["Id"]));
                saldo = totalFact - Convert.ToDouble(pagosFact);
                saldoTotal = saldoTotal + saldo;
            }*/
            return saldoTotal;
        }

        public DataTable FacturasDeProveedor(string nit) // en uso
        {
            try
            {
                var daoProveedor = new DaoProveedor();
                var p = daoProveedor.ConsultaProveedorNit(nit);
                var tablaProveedor = p.Tables["view_lista_proveedor"];
                string codigo = "0";
                if (tablaProveedor.Rows.Count != 0)
                {
                    var pRow = tablaProveedor.Rows[0];
                    codigo = pRow["Codigo"].ToString();
                }
                return ConsultaFacturaProveedor(Convert.ToInt32(codigo), true);
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al consultar las facturas del proveedor.\n" + ex.Message);
            }
        }

        public DataTable FacturasDeProveedor_(string nit) // en uso
        {
            try
            {
                var daoProveedor = new DaoProveedor();
                var p = daoProveedor.ConsultaProveedorNit(nit);
                var tablaProveedor = p.Tables["view_lista_proveedor"];
                string codigo = "0";
                if (tablaProveedor.Rows.Count != 0)
                {
                    var pRow = tablaProveedor.Rows[0];
                    codigo = pRow["Codigo"].ToString();
                }
                return ConsultaFacturaProveedor(Convert.ToInt32(codigo), false);
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al consultar las facturas del proveedor.\n" + ex.Message);
            }
        }

        public int SaldoTotalCredito()
        {
            int totalFact = 0;
            int pagosFact = 0;
            int saldo = 0;
            int saldoTotal = 0;
            var proveedor = FacturaProveedorEstado();
            foreach (DataRow fRow in proveedor.Rows)
            {
                var producto = ConsultaProductos(Convert.ToInt32(fRow["Id"]));
                totalFact = Convert.ToInt32(producto.AsEnumerable().Sum(t => t.Field<double>("Total")));
                pagosFact = PagosAProveedor(Convert.ToInt32(fRow["Id"]));
                saldo = totalFact - pagosFact;
                saldoTotal = saldoTotal + saldo;
            }
            return saldoTotal;
        }

        /// <summary>
        /// Obtiene los registros de los producto relacionado a una Factura de Proveedor.
        /// </summary>
        /// <param name="id">Id de la Factura consultada.</param>
        /// <returns></returns>
        public DataTable ConsultaProductos(int id)
        {
            var miTabla = CrearDataTable();
            var tabla = ConsultaProductoFacturaProveedor(id);
            foreach (DataRow row in tabla.Rows)
            {
                var row_ = miTabla.NewRow();
                row_["Cantidad"] = row["Cantidad"];
                row_["Iva"] = row["Iva"].ToString() + "%";
                row_["Valor"] = row["Valor"];
                row_["Descuento"] = row["Descuento"].ToString() + "%";
                row_["ValorMenosDescto"] = Convert.ToDouble(row["Valor"]) -
                              (Convert.ToDouble(row["Valor"]) * Convert.ToDouble(row["Descuento"]) / 100);
                row_["ValorIva"] = Convert.ToDouble(row_["ValorMenosDescto"]) * Convert.ToDouble(row["Iva"]) / 100;
                row_["TotalMasIva"] = Convert.ToDouble(row_["ValorMenosDescto"]) + Convert.ToDouble(row_["ValorIva"]);
                row_["Total"] = Convert.ToDouble(row_["TotalMasIva"]) * Convert.ToDouble(row["Cantidad"]);
                miTabla.Rows.Add(row_);
            }
            tabla.Clear();
            tabla = null;
            return miTabla;
        }

        /// <summary>
        /// Obtiene el valor total de los pagos o abono realizados a una factura de Proveedor.
        /// </summary>
        /// <param name="idFactura">Id de la factura a consultar pagos.</param>
        /// <returns></returns>
        public int PagosAProveedor(int idFactura)
        {
            var miDaoFromaPago = new DaoFormaPago();
            var tabla = miDaoFromaPago.PagosAProveedor(idFactura);
            var total = 0;
            foreach (DataRow row in tabla.Rows)
            {
                total = total + Convert.ToInt32(row["valorpago_factura_proveedor"]);
            }
            return total;
        }

        private List<int> ArrayFacturas { set; get; }

        private List<int> ArrayIds { set; get; }

        //puede devolver una coleccion con las facturas afectadas.
        public string IngresarPagoGeneral(int codigoProveedor, FormaPago fPago, bool esFactura)
        {
            var monto = fPago.Valor;
            var arrFacturas = new List<string>();
            var arrIntFact = new List<int>();
            var facturas = new DataTable();
            var daoPago = new DaoFormaPago();
            //var daoRetencion = new DaoRetencion();
            this.ArrayIds = new List<int>();
            try
            {
                CargarAdapter("facturas_proveedor_pendientes");
                miAdapter.SelectCommand.Parameters.AddWithValue("codigo", codigoProveedor);
                miAdapter.Fill(facturas);
                var qFacturas = from data in facturas.AsEnumerable()
                                orderby data.Field<DateTime>("fechaingresofactura_proveedor") ascending,
                                        data.Field<int>("numeroconsecutivofactura_proveedor") ascending
                                select data;

                int subTotal = 0;
                int valorDescto = 0;
                int impoConsumo = 0;
                int valorIva = 0;
                //int ajuste = 0;
                int total = 0;
                int totalRetencion = 0;
                foreach (DataRow fRow in qFacturas)
                {
                    subTotal = 0;
                    valorDescto = 0;
                    impoConsumo = 0;
                    valorIva = 0;
                    //ajuste = 0;
                    total = 0;
                    totalRetencion = 0;
                    if (monto > 0)
                    {
                        int idF = Convert.ToInt32(fRow["numeroconsecutivofactura_proveedor"]);
                        string no = fRow["numerofactura_proveedor"].ToString();
                        var pagos = daoPago.PagosAProveedor(Convert.ToInt32(fRow["numeroconsecutivofactura_proveedor"]));
                        var pPago = 0;
                        if (pagos.Rows.Count != 0)
                        {
                            pPago = Convert.ToInt32(pagos.AsEnumerable().Sum(s => s.Field<double>("valorpago_factura_proveedor")));
                        }

                        /*var productos = ConsultaProductos(Convert.ToInt32(fRow["numeroconsecutivofactura_proveedor"]));

                        var valorFacturaInt = Convert.ToInt32(
                            productos.AsEnumerable().Sum(s => s.Field<double>("Total")));

                        var valorFactura = Convert.ToDouble(valorFacturaInt) + Convert.ToDouble(fRow["valor_ajuste"]);*/

                    // Edicion 30/05/2018: mejora la presición del calculo de los totales, consulta, cartera, abono general.

                        var productos = this.ProductosDeCompra(Convert.ToInt32(fRow["numeroconsecutivofactura_proveedor"]));
                        subTotal = Convert.ToInt32(productos.Sum(s => (s.Producto.ValorCosto * s.Inventario.Cantidad)));
                        foreach (var p_ in productos)
                        {
                            valorDescto += Convert.ToInt32((p_.Producto.ValorCosto * p_.Producto.Descuento / 100) * p_.Inventario.Cantidad);
                            //valorIva = Convert.ToInt32(valorIva + p_.Valor_Iva);
                        }
                        impoConsumo = Convert.ToInt32(productos.Sum(s => (s.ImpoConsumo * s.Inventario.Cantidad)));
                        valorIva = Convert.ToInt32(productos.Sum(s => s.Valor_Iva));
                        var tRetenciones = this.miDaoRetencion.RetencionesACompra(Convert.ToInt32(fRow["numeroconsecutivofactura_proveedor"]));
                        foreach (DataRow rRow in tRetenciones.Rows)
                        {
                            totalRetencion += Convert.ToInt32((subTotal - valorDescto) * Convert.ToDouble(rRow["tarifa"]) / 100);
                        }
                        total = ((subTotal - valorDescto) + impoConsumo + valorIva + Convert.ToInt32(fRow["valor_ajuste"])) - totalRetencion;

                        /*
                        double valorFactura = ValorFactura(Convert.ToInt32(fRow["numeroconsecutivofactura_proveedor"]));
                        double subTotal = valorFactura - ValorIvaFactura(Convert.ToInt32(fRow["numeroconsecutivofactura_proveedor"]));
                        valorFactura += Convert.ToDouble(fRow["valor_ajuste"]);

                        var tRetenciones = daoRetencion.RetencionesACompra(Convert.ToInt32(fRow["numeroconsecutivofactura_proveedor"]));
                        int totalRetencion = 0;
                        foreach (DataRow rRow in tRetenciones.Rows)
                        {
                            totalRetencion += Convert.ToInt32(subTotal * Convert.ToDouble(rRow["tarifa"]) / 100);
                        }
                        valorFactura -= totalRetencion;
                        */

                    // Fin Edicion 30/05/2018

                        if (total > pPago) //if (valorFactura > pPago) //factura con saldo
                        {
                            fPago.NumeroFactura = fRow["numeroconsecutivofactura_proveedor"].ToString();
                            if (monto > (total - pPago))  // if (monto > (valorFactura - pPago))
                            {
                                fPago.Valor = total - Convert.ToDouble(pPago); //fPago.Valor = valorFactura - Convert.ToDouble(pPago);
                                monto -= total - Convert.ToDouble(pPago);  //monto -= valorFactura - Convert.ToDouble(pPago);
                            }
                            else
                            {
                                fPago.Valor = monto;
                                monto = 0;
                            }
                            ArrayIds.Add(daoPago.IngresaPagoAProveedor(fPago, esFactura));
                            arrFacturas.Add(fRow["numerofactura_proveedor"].ToString());
                            arrIntFact.Add(Convert.ToInt32(fRow["numeroconsecutivofactura_proveedor"]));
                        }
                    }
                }
                var f = "";
                foreach (string f_ in arrFacturas)
                {
                    f += f_ + ", ";
                }
                this.ArrayFacturas = arrIntFact;
                return f;//arrFacturas;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al ingresar el abono." + ex.Message);
            }
        }

        public List<int> GetArrayFacturas()
        {
            return this.ArrayFacturas;
        }

        public List<int> GetArrayIds()
        {
            return this.ArrayIds;
        }

        private int ValorFactura(int idFactura)
        {
            try
            {
                var total = 0;
                var tProductos = CrearDataTable();
                var productos = ConsultaProductoFacturaProveedor(idFactura);
                foreach (DataRow pRow in productos.Rows)
                {
                    var row_ = tProductos.NewRow();
                    row_["Valor"] = pRow["Valor"];
                    row_["Cantidad"] = pRow["Cantidad"];
                    row_["Descuento"] = pRow["Descuento"].ToString();
                    row_["ValorMenosDescto"] = Math.Round((Convert.ToDouble(pRow["Valor"]) -
                        (Convert.ToDouble(pRow["Valor"]) * Convert.ToDouble(pRow["Descuento"]) / 100)), 2);
                    row_["ValorIva"] = Math.Round((Convert.ToDouble(row_["ValorMenosDescto"]) * Convert.ToDouble(pRow["Iva"])), 2);
                    row_["TotalMasIva"] = Convert.ToDouble(row_["ValorMenosDescto"]) + Convert.ToDouble(row_["ValorIva"]);
                    row_["ValorIva"] = Math.Round(((Convert.ToDouble(row_["ValorMenosDescto"]) *
                                                     Convert.ToDouble(pRow["Iva"]) / 100) *
                                                     Convert.ToDouble(pRow["Cantidad"])), 2);
                    row_["Total"] = Math.Round((Convert.ToDouble(row_["TotalMasIva"]) * Convert.ToDouble(pRow["Cantidad"])), 2);
                    tProductos.Rows.Add(row_);
                }
                var subTotal = Convert.ToInt32(tProductos.AsEnumerable().Sum(s => s.Field<int>("Valor") * s.Field<double>("Cantidad")));
                int valorDescto = 0;
                foreach (DataRow row in tProductos.Rows)
                {
                    valorDescto += Convert.ToInt32((Convert.ToDouble(row["Valor"]) *
                                                    Convert.ToDouble(row["Descuento"]) / 100) *
                                                    Convert.ToDouble(row["Cantidad"]));
                }
                int valorIva = 0;
                foreach (DataRow row in tProductos.Rows)
                {
                    valorIva = Convert.ToInt32(valorIva + Convert.ToInt32(row["ValorIva"]));
                }
                total = (subTotal - valorDescto) + valorIva;
                return total;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al calcular el total.\n" + ex.Message);
            }
        }

        private int ValorIvaFactura(int idFactura)
        {
            try
            {
                //var total = 0;
                var tProductos = CrearDataTable();
                var productos = ConsultaProductoFacturaProveedor(idFactura);
                foreach (DataRow pRow in productos.Rows)
                {
                    var row_ = tProductos.NewRow();
                    row_["Valor"] = pRow["Valor"];
                    row_["Cantidad"] = pRow["Cantidad"];
                    row_["Descuento"] = pRow["Descuento"].ToString();
                    row_["ValorMenosDescto"] = Math.Round((Convert.ToDouble(pRow["Valor"]) -
                        (Convert.ToDouble(pRow["Valor"]) * Convert.ToDouble(pRow["Descuento"]) / 100)), 2);
                    row_["ValorIva"] = Math.Round((Convert.ToDouble(row_["ValorMenosDescto"]) * Convert.ToDouble(pRow["Iva"])), 2);
                    row_["TotalMasIva"] = Convert.ToDouble(row_["ValorMenosDescto"]) + Convert.ToDouble(row_["ValorIva"]);
                    row_["ValorIva"] = Math.Round(((Convert.ToDouble(row_["ValorMenosDescto"]) *
                                                     Convert.ToDouble(pRow["Iva"]) / 100) *
                                                     Convert.ToDouble(pRow["Cantidad"])), 2);
                    row_["Total"] = Math.Round((Convert.ToDouble(row_["TotalMasIva"]) * Convert.ToDouble(pRow["Cantidad"])), 2);
                    tProductos.Rows.Add(row_);
                }
                var subTotal = Convert.ToInt32(tProductos.AsEnumerable().Sum(s => s.Field<int>("Valor") * s.Field<double>("Cantidad")));
                int valorDescto = 0;
                foreach (DataRow row in tProductos.Rows)
                {
                    valorDescto += Convert.ToInt32((Convert.ToDouble(row["Valor"]) *
                                                    Convert.ToDouble(row["Descuento"]) / 100) *
                                                    Convert.ToDouble(row["Cantidad"]));
                }
                int valorIva = 0;
                foreach (DataRow row in tProductos.Rows)
                {
                    valorIva = Convert.ToInt32(valorIva + Convert.ToInt32(row["ValorIva"]));
                }
                //total = (subTotal - valorDescto) + valorIva;
                return valorIva;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al calcular el Iva.\n" + ex.Message);
            }
        }

        private List<ProductoFacturaProveedor> ProductosDeCompra(int idCompra)
        {
            try
            {
                var productos = new List<ProductoFacturaProveedor>();
                DataTable tProductos = this.ConsultaProductoFacturaProveedor(idCompra);
                foreach (DataRow pRow in tProductos.Rows)
                {
                    var p = new ProductoFacturaProveedor();
                    p.Producto.ValorCosto = Convert.ToDouble(pRow["Valor"]);
                    p.Producto.Descuento = Convert.ToDouble(pRow["Descuento"]);
                    p.Producto.ValorIva = Convert.ToDouble(pRow["Iva"]);
                    p.Inventario.Cantidad = Convert.ToDouble(pRow["Cantidad"]);
                    p.ImpoConsumo = Convert.ToDouble(pRow["impoconsumo"]);
                    
                    // ValorMenosDescto
                    p.Valor = Math.Round((p.Producto.ValorCosto - (p.Producto.ValorCosto * p.Producto.Descuento / 100)), 2);

                    // ValorIva
                    p.Valor_Iva = Math.Round(((p.Valor * p.Producto.ValorIva / 100) * p.Inventario.Cantidad), 2);

                    productos.Add(p);
                }
                return productos;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al consultar los productos de la compra.\n" + ex.Message);
            }
        }

        /// <summary>
        /// Crea las respectivas columnas del DataTable para ProductoFacturaProveedor.
        /// </summary>
        private DataTable CrearDataTable()
        {
            var miTabla = new DataTable();
            miTabla.Columns.Add(new DataColumn("Cantidad", typeof(double)));
            miTabla.Columns.Add(new DataColumn("Iva", typeof(string)));
            miTabla.Columns.Add(new DataColumn("Valor", typeof(int)));
            miTabla.Columns.Add(new DataColumn("Total", typeof(double)));
            miTabla.Columns.Add(new DataColumn("ValorIva", typeof(double)));
            miTabla.Columns.Add(new DataColumn("TotalMasIva", typeof(double)));
            miTabla.Columns.Add(new DataColumn("Descuento", typeof(string)));
            miTabla.Columns.Add(new DataColumn("ValorMenosDescto", typeof(double)));
            return miTabla;
        }


        // Compra temporal
        public double CantidadProductoCompraTemporal(string codigo)
        {
            try
            {
                CargarComando("cantidad_producto_factura_proveedor_temp");
                this.miComando.Parameters.AddWithValue("", codigo);
                this.miConexion.MiConexion.Open();
                double cant = Convert.ToDouble(this.miComando.ExecuteScalar());
                this.miConexion.MiConexion.Close();
                this.miComando.Dispose();
                return cant;
            }
            catch (InvalidCastException)
            {
                return 0;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al consultar la cantidad existente del en la compra." + ex.Message);
            }
            finally { this.miConexion.MiConexion.Close(); }
        }

        public void IngresarCompraTemporal(FacturaProveedor compra)
        {
            try
            {
                CargarComando("insertar_factura_proveedor_temp");
                miComando.Parameters.AddWithValue("", compra.Proveedor.CodigoInternoProveedor);
                miComando.Parameters.AddWithValue("", compra.Numero);
                miComando.Parameters.AddWithValue("", compra.FechaIngreso);
                miConexion.MiConexion.Open();
                var id = Convert.ToInt32(miComando.ExecuteScalar());
                miConexion.MiConexion.Close();
                miComando.Dispose();
                foreach (ProductoFacturaProveedor producto in compra.Productos)
                {
                    producto.IdFactura = id;
                    IngresarProductoTemporal(producto);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al ingresar la compra.\n" + ex.Message);
            }
            finally { miConexion.MiConexion.Close(); }
        }

        public void IngresarProductoTemporal(ProductoFacturaProveedor producto)
        {
            try
            {
                var miDaoLote = new DaoLote();
                CargarComando("insertar_producto_factura_proveedor_temp");
                miComando.Parameters.AddWithValue("", producto.IdFactura);
                miComando.Parameters.AddWithValue("", producto.Producto.CodigoInternoProducto);
                miComando.Parameters.AddWithValue("", producto.Inventario.IdMedida);
                miComando.Parameters.AddWithValue("", producto.Inventario.IdColor);
                miComando.Parameters.AddWithValue("", miDaoLote.IngresarLote(producto.Lote));
                miComando.Parameters.AddWithValue("", producto.Cantidad);
                miComando.Parameters.AddWithValue("", producto.Producto.ValorCosto);
                miComando.Parameters.AddWithValue("", producto.Producto.ValorIva);
                miComando.Parameters.AddWithValue("", producto.Producto.Descuento);
                miComando.Parameters.AddWithValue("", producto.Producto.DescuentoMayor);
                miConexion.MiConexion.Open();
                miComando.ExecuteNonQuery();
                miConexion.MiConexion.Close();
                miComando.Dispose();
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al ingresar el producto de la compra.\n" + ex.Message);
            }
            finally { miConexion.MiConexion.Close(); }
        }

        public DataTable ComprasTemporales()
        {
            try
            {
                var tabla = new DataTable();
                CargarAdapter("facturas_proveedor_temp");
                miAdapter.Fill(tabla);
                return tabla;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al consultar las compras.\n" + ex.Message);
            }
        }

        public FacturaProveedor Compra(int id)
        {
            try
            {
                var compra = new FacturaProveedor();
                CargarComando("facturas_proveedor_temp");
                miComando.Parameters.AddWithValue("", id);
                miConexion.MiConexion.Open();
                NpgsqlDataReader reader = miComando.ExecuteReader();
                while (reader.Read())
                {
                    compra.Id = reader.GetInt32(0);
                    compra.Proveedor.CodigoInternoProveedor = reader.GetInt32(1);
                    compra.Proveedor.NitProveedor = reader.GetString(2);
                    compra.Proveedor.NombreProveedor = reader.GetString(3);
                    compra.Numero = reader.GetString(4);
                    compra.FechaIngreso = reader.GetDateTime(5);
                }
                miConexion.MiConexion.Close();
                miComando.Dispose();
                return compra;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al consultar la compra.\n" + ex.Message);
            }
            finally { miConexion.MiConexion.Close(); }
        }

        public DataTable ProductosCompra(int idCompra)
        {
            try
            {
                var tProductos = new DataTable();
                tProductos.Columns.Add(new DataColumn("Id", typeof(int)));
                tProductos.Columns.Add(new DataColumn("Codigo", typeof(string)));
                tProductos.Columns.Add(new DataColumn("Articulo", typeof(string)));
                tProductos.Columns.Add(new DataColumn("IdMedida", typeof(int)));
                tProductos.Columns.Add(new DataColumn("IdColor", typeof(int)));
                tProductos.Columns.Add(new DataColumn("IdLote", typeof(int)));
                tProductos.Columns.Add(new DataColumn("Cantidad", typeof(double)));
                tProductos.Columns.Add(new DataColumn("Valor", typeof(double)));
                tProductos.Columns.Add(new DataColumn("ValorMasIva", typeof(double)));
                tProductos.Columns.Add(new DataColumn("Iva", typeof(double)));
                tProductos.Columns.Add(new DataColumn("VIva", typeof(double)));
                tProductos.Columns.Add(new DataColumn("Impoconsumo", typeof(double)));
                tProductos.Columns.Add(new DataColumn("ValorUnitario", typeof(double)));
                tProductos.Columns.Add(new DataColumn("Total", typeof(double)));
                tProductos.Columns.Add(new DataColumn("Descuento", typeof(double)));
                tProductos.Columns.Add(new DataColumn("Venta", typeof(int)));
                tProductos.Columns.Add(new DataColumn("ActVenta", typeof(int)));

                var tabla = new DataTable();
                CargarAdapter("productos_factura_proveedor_temp");
                miAdapter.SelectCommand.Parameters.AddWithValue("", idCompra);
                miAdapter.Fill(tabla);
                foreach (DataRow row in tabla.Rows)
                {
                    var row_ = tProductos.NewRow();
                    row_["Id"] = row["id"];
                    row_["Codigo"] = row["codigo_producto"];
                    row_["Articulo"] = row["Nombre"];
                    row_["IdMedida"] = row["idmedida"];
                    row_["IdColor"] = row["idcolor"];
                    row_["IdLote"] = row["idlote"];
                    row_["Cantidad"] = row["cantidad"];
                    row_["Valor"] = row["valor"];
                    double iva = Math.Round((Convert.ToDouble(row["valor"]) * Convert.ToDouble(row["iva"]) / 100), 2);
                    row_["VIva"] = iva;

                    row_["Impoconsumo"] = this.Impoconsumo(row["codigo_producto"].ToString()); // temporal, lo ideal es que se almacene en producto_compra_temp

                    row_["ValorUnitario"] = row_["ValorMasIva"] = Math.Round((Convert.ToDouble(row["valor"]) + iva), 2) + Convert.ToDouble(row_["Impoconsumo"]);
                    row_["Iva"] = row["iva"];
                    //row_["Impoconsumo"] = 0;
                    

                    row_["Total"] = Math.Round((Convert.ToDouble(row_["ValorMasIva"]) * Convert.ToDouble(row["cantidad"])), 2);
                    row_["Descuento"] = row["descuento"];
                    row_["Venta"] = row["venta"];
                    row_["ActVenta"] = 0;
                    tProductos.Rows.Add(row_);
                }
                return tProductos;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al consultar las compras.\n" + ex.Message);
            }
        }

        public List<Item> ItemsCompra(int idCompra)
        {
            try
            {
                List<Item> items = new List<Item>();
                CargarComando("productos_factura_proveedor_temp");
                miComando.Parameters.AddWithValue("", idCompra);
                miConexion.MiConexion.Open();
                NpgsqlDataReader reader = miComando.ExecuteReader();
                while (reader.Read())
                {
                    var item = new Item();
                    items.Add(new Item
                    {
                        Id = reader.GetInt32(0),
                        Codigo = reader.GetString(2),
                        Nombre = reader.GetString(3),
                        IdMedida = reader.GetInt32(4),
                        IdColor = reader.GetInt32(5),
                        IdLote = reader.GetInt32(6),
                        Cantidad = reader.GetDouble(7),
                        Costo = reader.GetDouble(8),
                        IVA = reader.GetDouble(9),
                        Descuento = reader.GetDouble(10),
                        Descuento2 = reader.GetDouble(13),
                        Impoconsumo = reader.GetDouble(14)
                    });
                }
                miConexion.MiConexion.Close();
                miComando.Dispose();
                foreach (var item in items)
                {
                    item.CostoMenosD1 = Math.Round(item.Costo - (item.Costo * item.Descuento / 100), 2);
                    item.ValorD2 = Math.Round(item.CostoMenosD1 * item.Descuento2 / 100, 2);
                    item.ValorIVA = Math.Round(item.CostoMenosD1 * item.IVA / 100, 2);
                    item.ValorUnitario = item.CostoMenosD1 + item.ValorIVA + item.Impoconsumo;
                    item.Precio = item.ValorUnitario - item.ValorD2;
                    item.Total = Math.Round(item.Precio * item.Cantidad, 2);
                }
                return items;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al consultar los items de la compra.\n" + ex.Message);
            }
            finally { miConexion.MiConexion.Close(); }
        }

        public void EditCantidad(int id, double cantidad)
        {
            try
            {
                string sql = "update producto_factura_proveedor_temp set cantidad = @cant where id = @id;";
                CargarComandoText(sql);
                miComando.Parameters.AddWithValue("id", id);
                miComando.Parameters.AddWithValue("cant", cantidad);
                miConexion.MiConexion.Open();
                miComando.ExecuteNonQuery();
                miConexion.MiConexion.Close();
                miComando.Dispose();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally { miConexion.MiConexion.Close(); }
        }

        public void EditCosto(int id, double costo)
        {
            try
            {
                string sql = "update producto_factura_proveedor_temp set valor = @costo where id = @id;";
                CargarComandoText(sql);
                miComando.Parameters.AddWithValue("id", id);
                miComando.Parameters.AddWithValue("costo", costo);
                miConexion.MiConexion.Open();
                miComando.ExecuteNonQuery();
                miConexion.MiConexion.Close();
                miComando.Dispose();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally { miConexion.MiConexion.Close(); }
        }

        public void EditD1(int id, double d1)
        {
            try
            {
                string sql = "update producto_factura_proveedor_temp set descuento = @descto where id = @id;";
                CargarComandoText(sql);
                miComando.Parameters.AddWithValue("id", id);
                miComando.Parameters.AddWithValue("descto", d1);
                miConexion.MiConexion.Open();
                miComando.ExecuteNonQuery();
                miConexion.MiConexion.Close();
                miComando.Dispose();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally { miConexion.MiConexion.Close(); }
        }

        public void EditD2(int id, double d2)
        {
            try
            {
                string sql = "update producto_factura_proveedor_temp set descuento_2 = @descto where id = @id;";
                CargarComandoText(sql);
                miComando.Parameters.AddWithValue("id", id);
                miComando.Parameters.AddWithValue("descto", d2);
                miConexion.MiConexion.Open();
                miComando.ExecuteNonQuery();
                miConexion.MiConexion.Close();
                miComando.Dispose();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally { miConexion.MiConexion.Close(); }
        }

        public void EditImpoconsumo(string codigo, double ico)
        {
            try
            {
                string sql = "update producto set impoconsumo = @ico where codigointernoproducto = @codigo;";
                CargarComandoText(sql);
                miComando.Parameters.AddWithValue("codigo", codigo);
                miComando.Parameters.AddWithValue("ico", ico);
                miConexion.MiConexion.Open();
                miComando.ExecuteNonQuery();
                miConexion.MiConexion.Close();
                miComando.Dispose();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally { miConexion.MiConexion.Close(); }
        }

        public void DeleteItem(int id)
        {
            try
            {
                string sql = "delete from producto_factura_proveedor_temp where id = @id;";
                CargarComandoText(sql);
                miComando.Parameters.AddWithValue("id", id);
                miConexion.MiConexion.Open();
                miComando.ExecuteNonQuery();
                miConexion.MiConexion.Close();
                miComando.Dispose();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally { miConexion.MiConexion.Close(); }
        }


        public void EliminarCompraTemporal(int id)
        {
            try
            {
                CargarComando("eliminar_productos_temporal");
                miComando.Parameters.AddWithValue("", id);
                miConexion.MiConexion.Open();
                miComando.ExecuteNonQuery();
                miConexion.MiConexion.Close();
                miComando.Dispose();

                CargarComando("eliminar_compra_temporal");
                miComando.Parameters.AddWithValue("", id);
                miConexion.MiConexion.Open();
                miComando.ExecuteNonQuery();
                miConexion.MiConexion.Close();
                miComando.Dispose();
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al eliminar la compra.\n" + ex.Message);
            }
            finally { miConexion.MiConexion.Close(); }
        }

        public void EliminarProductoTemporal(int id)
        {
            try
            {
                CargarComando("eliminar_producto_temporal");
                miComando.Parameters.AddWithValue("", id);
                miConexion.MiConexion.Open();
                miComando.ExecuteNonQuery();
                miConexion.MiConexion.Close();
                miComando.Dispose();
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al eliminar el producto.\n" + ex.Message);
            }
            finally { miConexion.MiConexion.Close(); }
        }

        //
        private double Impoconsumo(string codigo)
        {
            try
            {
                this.miComando = new NpgsqlCommand();
                this.miComando.Connection = miConexion.MiConexion;
                this.miComando.CommandType = CommandType.Text;
                this.miComando.CommandText = "SELECT impoconsumo FROM producto WHERE codigointernoproducto = '" + codigo + "';";
                this.miConexion.MiConexion.Open();
                double impoconsumo_ = Convert.ToDouble(this.miComando.ExecuteScalar());
                this.miConexion.MiConexion.Close();
                this.miComando.Dispose();
                return impoconsumo_;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally { this.miConexion.MiConexion.Close(); }
        }


        public DataTable TableCompras()
        {
            try
            {
                var tData = new DataTable();
                tData.Columns.Add("proveedor", typeof(string));
                tData.Columns.Add("id", typeof(int));
                tData.Columns.Add("numero", typeof(string));
                tData.Columns.Add("fecha", typeof(DateTime));
                tData.Columns.Add("estado", typeof(bool));
                tData.Columns.Add("ajuste", typeof(double));
                tData.Columns.Add("total", typeof(int));
                tData.Columns.Add("pagos", typeof(int));

                string sql =
                "SELECT " +
                "proveedor.razonsocialproveedor AS proveedor,  " +
                "factura_proveedor.numeroconsecutivofactura_proveedor AS id,  " +
                "factura_proveedor.numerofactura_proveedor AS numero,  " +
                "factura_proveedor.fechaingresofactura_proveedor AS fecha,  " +
                "factura_proveedor.estadofactura_proveedor AS estado,  " +
                "factura_proveedor.valor_ajuste AS ajuste " +
                "FROM  " +
                "factura_proveedor,  " +
                "proveedor " +
                "WHERE  " +
                "proveedor.codigointernoproveedor = factura_proveedor.codigointernoproveedor AND " +
                "factura_proveedor.codigointernoproveedor = 361 " +
                "ORDER BY " +
                "factura_proveedor.fechaingresofactura_proveedor ASC;";

                var tCompras = new DataTable();
                this.miAdapter = new NpgsqlDataAdapter(sql, miConexion.MiConexion);
                this.miAdapter.SelectCommand.CommandType = CommandType.Text;
                this.miAdapter.Fill(tCompras);

                foreach (DataRow cRow in tCompras.Rows)
                {
                    var tdRow = tData.NewRow();
                    tdRow["proveedor"] = cRow["proveedor"];
                    tdRow["id"] = cRow["id"];
                    tdRow["numero"] = cRow["numero"];
                    tdRow["fecha"] = cRow["fecha"];
                    tdRow["estado"] = cRow["estado"];
                    tdRow["ajuste"] = cRow["ajuste"];

                    sql =
                    "SELECT " +
                    "valoringresoproducto_factura_proveedor AS valor, " +
                    "descuento, " +
                    "ivaproducto_factura_proveedor AS iva, " +
                    "impoconsumo, " +
                    "cantidadproducto_factura_proveedor AS cantidad " +
                    "FROM " +
                    "producto_factura_proveedor " +
                    "WHERE " +
                    "numeroconsecutivofactura_proveedor = " + Convert.ToInt32(cRow["id"]) +
                    " ORDER BY " +
                    "idproducto_factura_proveedor ASC;";

                    var tDetalle = new DataTable();
                    this.miAdapter = new NpgsqlDataAdapter(sql, miConexion.MiConexion);
                    this.miAdapter.SelectCommand.CommandType = CommandType.Text;
                    this.miAdapter.Fill(tDetalle);

                    double valorIva = 0;
                    double subTotal = 0;
                    List<double> totales = new List<double>();
                    foreach (DataRow dRow in tDetalle.Rows)
                    {
                        valorIva = Math.Round((Convert.ToDouble(dRow["valor"]) * Convert.ToDouble(dRow["iva"]) / 100), 2);
                        subTotal = Math.Round((Convert.ToDouble(dRow["valor"]) + valorIva), 2);
                        totales.Add(Math.Round((subTotal * Convert.ToDouble(dRow["cantidad"])), 2));
                    }
                    tdRow["total"] = Convert.ToInt32(totales.Sum()) + Convert.ToDouble(cRow["ajuste"]);

                    sql = "SELECT " +
                           "CASE  " +
                             "WHEN SUM(valorpago_factura_proveedor) IS NULL THEN 0  " +
                             "ELSE SUM(valorpago_factura_proveedor)  " +
                          "END AS pago  " +
                         "FROM  " +
                          "pago_factura_proveedor " +
                         "WHERE  " +
                          "numeroconsecutivofactura_proveedor = " + Convert.ToInt32(cRow["id"]) + ";";
                    this.miComando = new NpgsqlCommand();
                    this.miComando.Connection = this.miConexion.MiConexion;
                    this.miComando.CommandType = CommandType.Text;
                    this.miComando.CommandText = sql;
                    this.miConexion.MiConexion.Open();
                    tdRow["pagos"] = Convert.ToDouble(this.miComando.ExecuteScalar());
                    this.miConexion.MiConexion.Close();
                    this.miComando.Dispose();

                    tData.Rows.Add(tdRow);
                }
                return tData;
            }
            catch (Exception ex)
            {
                throw new Exception("" + ex.Message);
            }
        }

        public DataTable ComprasDeProveedor(int codProveedor)
        {
            try
            {
                string sql =
                "SELECT " +
                "proveedor.razonsocialproveedor AS proveedor,  " +
                "factura_proveedor.numeroconsecutivofactura_proveedor AS id,  " +
                "factura_proveedor.numerofactura_proveedor AS numero,  " +
                "factura_proveedor.fechaingresofactura_proveedor AS fecha,  " +
                "factura_proveedor.estadofactura_proveedor AS estado,  " +
                "factura_proveedor.valor_ajuste AS ajuste " +
                "FROM  " +
                "factura_proveedor,  " +
                "proveedor " +
                "WHERE  " +
                "proveedor.codigointernoproveedor = factura_proveedor.codigointernoproveedor AND " +
                "factura_proveedor.codigointernoproveedor = " + codProveedor +
                " ORDER BY " +
                "factura_proveedor.fechaingresofactura_proveedor ASC;";

                var tCompras = new DataTable();
                this.miAdapter = new NpgsqlDataAdapter(sql, miConexion.MiConexion);
                this.miAdapter.SelectCommand.CommandType = CommandType.Text;
                this.miAdapter.Fill(tCompras);

                return tCompras;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public double PagosAcompras(int idCompra)
        {
            try
            {
                string 
                sql = "SELECT " +
                      "CASE  " +
                      "WHEN SUM(valorpago_factura_proveedor) IS NULL THEN 0  " +
                      "ELSE SUM(valorpago_factura_proveedor)  " +
                      "END AS pago  " +
                      "FROM  " +
                      "pago_factura_proveedor " +
                      "WHERE  " +
                      "numeroconsecutivofactura_proveedor = " + idCompra + ";";
                this.miComando = new NpgsqlCommand();
                this.miComando.Connection = this.miConexion.MiConexion;
                this.miComando.CommandType = CommandType.Text;
                this.miComando.CommandText = sql;
                this.miConexion.MiConexion.Open();
                double pagos = Convert.ToDouble(this.miComando.ExecuteScalar());
                this.miConexion.MiConexion.Close();
                this.miComando.Dispose();
                return pagos;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        public void AjustarComprasAndPagos(int maxValor)
        {
            try
            {
                /*var tData = new DataTable();
                tData.Columns.Add("proveedor", typeof(string));
                tData.Columns.Add("id", typeof(int));
                tData.Columns.Add("numero", typeof(string));
                tData.Columns.Add("fecha", typeof(DateTime));
                tData.Columns.Add("estado", typeof(bool));
                tData.Columns.Add("ajuste", typeof(double));
                tData.Columns.Add("total", typeof(int));
                tData.Columns.Add("pagos", typeof(int));*/

                var miDaoPago = new DaoFormaPago();
                var tPagos = new DataTable();

                int subTotal = 0;
                int valorDescto = 0;
                int impoConsumo = 0;
                int valorIva = 0;
                int totalRetecion = 0;
                int ajuste = 0;
                int total = 0;
                int pago = 0;
                int dif = 0;
                int difPositiva = 0;

                int pagoTemp = 0;

                foreach (DataRow provRow in this.ProveedoresDeCompras().Rows)
                {
                    var tCompras = this.ComprasDeProveedor(Convert.ToInt32(provRow["codigointernoproveedor"]));
                    foreach (DataRow cRow in tCompras.Rows)
                    {
                        subTotal = 0;
                        valorDescto = 0;
                        impoConsumo = 0;
                        valorIva = 0;
                        totalRetecion = 0;
                        total = 0;
                        pago = 0;
                        dif = 0;
                        difPositiva = 0;

                        pagoTemp = 0;

                        var productos = this.ProductosDeCompra(Convert.ToInt32(cRow["id"]));
                        subTotal = Convert.ToInt32(productos.Sum(s => (s.Producto.ValorCosto * s.Inventario.Cantidad)));
                        foreach (var p_ in productos)
                        {
                            valorDescto += Convert.ToInt32((p_.Producto.ValorCosto * p_.Producto.Descuento / 100) * p_.Inventario.Cantidad);
                        }
                        impoConsumo = Convert.ToInt32(productos.Sum(s => (s.ImpoConsumo * s.Inventario.Cantidad)));
                        valorIva = Convert.ToInt32(productos.Sum(s => s.Valor_Iva));
                        foreach (DataRow rRow in this.miDaoRetencion.RetencionesACompra(Convert.ToInt32(cRow["id"])).Rows)
                        {
                            totalRetecion += Convert.ToInt32((subTotal - valorDescto) * Convert.ToDouble(rRow["tarifa"]) / 100);
                        }
                        ajuste = Convert.ToInt32(cRow["ajuste"]);
                        total = ((subTotal - valorDescto) + impoConsumo + valorIva + ajuste) - totalRetecion;

                        tPagos = miDaoPago.PagosAProveedor(Convert.ToInt32(cRow["id"]));
                        if (tPagos.Rows.Count != 0)
                        {
                            pago = Convert.ToInt32(tPagos.AsEnumerable().Sum(s => s.Field<double>("valorpago_factura_proveedor")));
                        }

                        /*var tdRow = tData.NewRow();
                        tdRow["proveedor"] = cRow["proveedor"];
                        tdRow["id"] = cRow["id"];
                        tdRow["numero"] = cRow["numero"];
                        tdRow["fecha"] = cRow["fecha"];
                        tdRow["estado"] = cRow["estado"];
                        tdRow["ajuste"] = cRow["ajuste"];
                        tdRow["total"] = total;
                        tdRow["pagos"] = pago;
                        tData.Rows.Add(tdRow);*/

                        var codProvee = provRow["codigointernoproveedor"].ToString();
                        var provee = provRow["razonsocialproveedor"].ToString();
                        var noFrv = cRow["numero"].ToString();

                        dif = total - pago;
                        if (dif != 0)
                        {
                            if (dif < 0)
                            {
                                difPositiva = dif * (-1);
                            }
                            else
                            {
                                difPositiva = dif;
                            }
                            if (difPositiva < maxValor)
                            {
                                if (tPagos.Rows.Count != 0)
                                {
                                    DataRow pagoRow = tPagos.AsEnumerable().First();
                                    pagoTemp = Convert.ToInt32(pagoRow["valorpago_factura_proveedor"]);
                                    pagoTemp += dif;
                                    miDaoPago.EditarPagoDeCompra(Convert.ToInt32(pagoRow["idpago_factura_proveedor"]), pagoTemp);
                                }
                            }
                        }
                    }
                }
                //return tData;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }



        public DataTable ProveedoresDeCompras()
        {
            try
            {
                string sql =
                "SELECT proveedor.codigointernoproveedor, proveedor.nitproveedor, proveedor.razonsocialproveedor " +
                "FROM proveedor, factura_proveedor WHERE proveedor.codigointernoproveedor = factura_proveedor.codigointernoproveedor " +
                "GROUP BY proveedor.codigointernoproveedor, proveedor.nitproveedor, proveedor.razonsocialproveedor ORDER BY " +
                "proveedor.razonsocialproveedor ASC;";
                var tProveedores = new DataTable();
                this.miAdapter = new NpgsqlDataAdapter(sql, miConexion.MiConexion);
                this.miAdapter.SelectCommand.CommandType = CommandType.Text;
                this.miAdapter.Fill(tProveedores);
                return tProveedores;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private void EditarAjuste(int idCompra, int ajuste)
        {
            try
            {

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void AjustarPreciosDeProductos()
        {
            try
            {
                var daoEmpresa = new DaoEmpresa();
                var empresa_ = daoEmpresa.ObtenerEmpresa();

                var UtilidadAntesIva = Convert.ToBoolean(Utilities.AppConfiguracion.ValorSeccion("utilidad_mas_iva"));
                var CalculoUtilMultiplicado = Convert.ToBoolean(Utilities.AppConfiguracion.ValorSeccion("calculo_util_multiplica"));

                bool RedondearPrecio2 = Convert.ToBoolean(Utilities.AppConfiguracion.ValorSeccion("redondeo_precio_dos"));
                bool AproxPrecio = Convert.ToBoolean(Utilities.AppConfiguracion.ValorSeccion("tipo_aprox_precio"));

                string sql =
                "SELECT producto.codigointernoproducto AS codigo, producto.precio_costo AS costo, iva.valoriva AS iva, producto.valorventaproducto AS venta, " +
                "producto.impoconsumo, producto.descto_mayor, producto.descto_distribuidor, producto.descto_3 FROM producto, iva " +
                "WHERE iva.idiva = producto.idiva AND producto.impoconsumo > 0;";
                this.miAdapter = new NpgsqlDataAdapter(sql, miConexion.MiConexion);
                this.miAdapter.SelectCommand.CommandType = CommandType.Text;
                var tProductos = new DataTable();
                this.miAdapter.Fill(tProductos);

                double costo = 0;

                double iva = 0;

                double ventaNoIco = 0;

                double precio2 = 0;
                double precio3 = 0;
                double precio4 = 0;

                double descto2 = 0, descto3 = 0, descto4 = 0;

                double util2 = 0, util3 = 0, util4 = 0;

                foreach (DataRow pRow in tProductos.Rows)
                {
                    costo = Convert.ToDouble(pRow["costo"]);
                    iva = Convert.ToDouble(pRow["iva"]);
                    ventaNoIco = Convert.ToInt32(pRow["venta"]) - Convert.ToInt32(pRow["impoconsumo"]);



                    precio2 = // precio establecido por el usuario
                    Convert.ToInt32(Convert.ToInt32(pRow["venta"]) - (Convert.ToInt32(pRow["venta"]) * Convert.ToDouble(pRow["descto_mayor"]) / 100));
                    if (RedondearPrecio2)
                    {
                        precio2 = Utilities.UseObject.Aproximar(Convert.ToInt32(precio2), AproxPrecio);
                    }
                    precio2 -= Convert.ToInt32(pRow["impoconsumo"]);
                    descto2 = Math.Round((((ventaNoIco - precio2) / ventaNoIco) * 100), 3);

                    //calculo de la utilidad
                    precio2 = Convert.ToInt32(precio2 / (1 + (iva / 100)));
                    util2 = Math.Round((100 - ((costo / precio2) * 100)), 1);


                    precio3 = // precio establecido por el usuario
                    Convert.ToInt32(Convert.ToInt32(pRow["venta"]) - (Convert.ToInt32(pRow["venta"]) * Convert.ToDouble(pRow["descto_distribuidor"]) / 100));
                    if (RedondearPrecio2)
                    {
                        precio3 = Utilities.UseObject.Aproximar(Convert.ToInt32(precio3), AproxPrecio);
                    }
                    precio3 -= Convert.ToInt32(pRow["impoconsumo"]);
                    descto3 = Math.Round((((ventaNoIco - precio3) / ventaNoIco) * 100), 3);

                    //calculo de la utilidad
                    precio3 = Convert.ToInt32(precio3 / (1 + (iva / 100)));
                    util3 = Math.Round((100 - ((costo / precio3) * 100)), 1);


                    precio4 = // precio establecido por el usuario
                    Convert.ToInt32(Convert.ToInt32(pRow["venta"]) - (Convert.ToInt32(pRow["venta"]) * Convert.ToDouble(pRow["descto_3"]) / 100));
                    if (RedondearPrecio2)
                    {
                        precio4 = Utilities.UseObject.Aproximar(Convert.ToInt32(precio4), AproxPrecio);
                    }
                    precio4 -= Convert.ToInt32(pRow["impoconsumo"]);
                    descto4 = Math.Round((((ventaNoIco - precio4) / ventaNoIco) * 100), 3);

                    //calculo de la utilidad
                    precio4 = Convert.ToInt32(precio4 / (1 + (iva / 100)));
                    util4 = Math.Round((100 - ((costo / precio4) * 100)), 1);

                    var r = pRow["codigo"].ToString();

                    sql = "UPDATE producto SET " +
                            " descto_mayor = @descto2, " +
                            " descto_distribuidor = @descto3, " +
                            " utilidad_2 = @util2, " +
                            " utilidad_3 = @util3,  " +
                            " descto_3 = @descto4 " +
                          " WHERE codigointernoproducto = @codigo;";

                    this.miComando = new NpgsqlCommand();
                    this.miComando.Connection = miConexion.MiConexion;
                    this.miComando.CommandType = CommandType.Text;
                    this.miComando.CommandText = sql;

                    this.miComando.Parameters.AddWithValue("descto2", descto2);
                    this.miComando.Parameters.AddWithValue("descto3", descto3);
                    this.miComando.Parameters.AddWithValue("util2", util2);
                    this.miComando.Parameters.AddWithValue("util3", util3);
                    this.miComando.Parameters.AddWithValue("descto4", descto4);
                    this.miComando.Parameters.AddWithValue("codigo", pRow["codigo"].ToString());

                    this.miConexion.MiConexion.Open();
                    this.miComando.ExecuteNonQuery();
                    this.miConexion.MiConexion.Close();
                    this.miComando.Dispose();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
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

        private void CargarComandoText(string cmd)
        {
            miComando = new NpgsqlCommand();
            miComando.Connection = miConexion.MiConexion;
            miComando.CommandType = CommandType.Text;
            miComando.CommandText = cmd;
        }

        /// <summary>
        /// Inicializa una nueva instancia de NpgsqlDataAdapter de tipo StoredProcedure.
        /// </summary>
        /// <param name="cmd">Comando a ejecutar.</param>
        private void CargarAdapter(string cmd)
        {
            miAdapter = new NpgsqlDataAdapter(cmd, miConexion.MiConexion);
            miAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
        }
    }
}