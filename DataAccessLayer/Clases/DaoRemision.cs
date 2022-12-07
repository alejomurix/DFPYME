using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using DTO.Clases;
using Npgsql;
using DTO.Clases;
using Utilities;

namespace DataAccessLayer.Clases
{
    public class DaoRemision
    {

        #region Acceso a datos

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

        #endregion

        #region Funciones

        /// <summary>
        /// Representa la función recuperar_consecutivo.
        /// </summary>
        private string ObtenerConsecutivo = "recuperar_consecutivo";

        private string ActualizaConsecutivo = "actualizar_consecutivo";

        private string Ingresar_ = "insertar_remision";

        private string PrintRemision_ = "print_remision";

        private string ConsultaNumero_ = "remision_numero";

        private string ConsultaCliente_ = "remision_cliente";  //

        private string CountConsultaCliente = "count_remision_cliente";

        private string ConsultaClienteFac = "remision_cliente_facturada";  //

        private string CountConsultaClienteFac = "count_remision_cliente_facturada";

        private string ConsultaEstadoR = "remision_remision";

        private string CountConsultaEstadoR = "count_remision_remision";

        private string ConsultaEstadoF = "remision_facturada";

        private string CountConsultaEstadoF = "count_remision_facturada";


        //PRODUCTO REMISION:
        private string IngresarProducto_ = "insertar_producto_remision";

        private string PrintProducto_ = "print_producto_remision";

        private string ProductoRemision_ = "producto_remision";

        #endregion

        #region Mensajes

        /// <summary>
        /// Representa el texto: Ocurrió un error al obtener el rango de números.
        /// </summary>
        private string ErrorNumero = "Ocurrió un error al obtener el número consecutivo.\n";

        private string ErrorActNumero = "Ocurrió un error al actualiza el número consecutivo de las remisiones.";

        private string ErrorIngresar = "Ocurrió un error al ingresar la Remisión.\n";

        private string ErrorIngProducto = "Ocurrió un error al ingresar los productos de la remisión.\n";


        private string ErrorConsulta = "Ocurrió un error al obtener la consulta de la Remisión.\n";

        private string ErrorCount = "Ocurrió un error al obtener el total de registros de la consulta.\n";

        private string ErrorProducto = "Ocurrió un error al obtener la consulta de los productos de la remisión.\n";

        #endregion

        private bool RedondearPrecio2;

        private DaoKardex miDaoKardex;

        private Kardex Kardex { set; get; }

        private DaoInventario miDaoInventario;

        /// <summary>
        /// Inicializa una nueva instancia de la clase DaoRemision.
        /// </summary>
        public DaoRemision()
        {
            this.miConexion = new Conexion();
            miDaoKardex = new DaoKardex();
            miDaoProducto = new DaoProducto();
            miDaoInventario = new DaoInventario();
            Kardex = new Kardex();
            try
            {
                this.RedondearPrecio2 = Convert.ToBoolean(AppConfiguracion.ValorSeccion("redondeo_precio_dos"));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Obtiene el Número consecutivo a se asignado en la Remisión.
        /// </summary>
        /// <returns></returns>
        public string ObtenerNumero()
        {
            try
            {
                CargarComando(ObtenerConsecutivo);
                miComando.Parameters.AddWithValue("nombre", "Remision");
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

        public void ActualizarConsecutivo(string numero)
        {
            try
            {
                var numeroEdit = Convert.ToInt32(numero) + 1;
                CargarComando(ActualizaConsecutivo);
                miComando.Parameters.AddWithValue("concepto", "Remision");
                miComando.Parameters.AddWithValue("numero", numeroEdit.ToString());
                miConexion.MiConexion.Open();
                miComando.ExecuteNonQuery();
                miConexion.MiConexion.Close();
                miComando.Dispose();
            }
            catch (Exception ex)
            {
                throw new Exception(ErrorActNumero + ex.Message);
            }
            finally { miConexion.MiConexion.Close(); }
        }

        public void Ingresar(FacturaVenta remision)
        {
            var miDaoInventario = new DaoInventario();
            var miDaoPago = new DaoFormaPago();
            try
            {
                CargarComando(Ingresar_);
                miComando.Parameters.AddWithValue("numero", Convert.ToInt32(remision.Numero));
                miComando.Parameters.AddWithValue("cliente", remision.Proveedor.NitProveedor);
                miComando.Parameters.AddWithValue("usuario", remision.Usuario.Id);
                miComando.Parameters.AddWithValue("caja", remision.Caja.Id);
                miComando.Parameters.AddWithValue("fecha", remision.FechaIngreso);
                miComando.Parameters.AddWithValue("hora", remision.FechaIngreso.TimeOfDay);
                miComando.Parameters.AddWithValue("descuento", remision.Descuento);
                miComando.Parameters.AddWithValue("limite", remision.FechaLimite);
                miComando.Parameters.AddWithValue("aplica", remision.AplicaDescuento);
                miComando.Parameters.AddWithValue("estado", remision.Estado);
                miComando.Parameters.AddWithValue("idestado", remision.EstadoFactura.Id);
                miComando.Parameters.AddWithValue("anulada", false);
                miConexion.MiConexion.Open();
                miComando.ExecuteNonQuery();
                miConexion.MiConexion.Close();
                miComando.Dispose();
                ActualizarConsecutivo(remision.Numero);
                foreach (ProductoFacturaProveedor producto in remision.Productos)
                {
                    IngresarProducto(producto);
                    miDaoInventario.ActualizarInventario(producto.Inventario, true);
                    

                    // Kardex
                    Kardex.Codigo = producto.Producto.CodigoInternoProducto;
                    Kardex.IdUsuario = remision.Usuario.Id;
                    Kardex.IdConcepto = 11;
                    Kardex.NoDocumento = remision.Numero;
                    Kardex.Fecha = DateTime.Now;
                    Kardex.Cantidad = producto.Cantidad;
                    double valorMenosDesto = Math.Round((producto.Producto.ValorVentaProducto -
                        (producto.Producto.ValorVentaProducto * producto.Producto.Descuento / 100)), 1);
                    double iva = Math.Round((valorMenosDesto * producto.Producto.ValorIva / 100), 1);
                    Kardex.Valor = Convert.ToInt32(valorMenosDesto + iva);
                    miDaoKardex.Insertar(Kardex);
                }
                foreach (FormaPago pago in remision.FormasDePago)
                {
                    if (!pago.Valor.Equals(0))
                    {
                        pago.NumeroFactura = remision.Numero;
                        pago.Fecha = remision.FechaIngreso;
                        pago.Usuario.Id = remision.Usuario.Id;
                        pago.Caja.Id = remision.Caja.Id;
                        miDaoPago.IngresarPagoRemision(pago);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ErrorIngresar + ex.Message);
            }
            finally { miConexion.MiConexion.Close(); }
        }

        public DataSet PrintRemision(string numero)
        {
            var dataSet = new DataSet();
            try
            {
                CargarAdapter(PrintRemision_);
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
        /// Obtiene el resultado de la consulta de Remisión por número.
        /// </summary>
        /// <param name="numero">Número de la Remisión a consultar.</param>
        /// <returns></returns>
        public DataTable ConsultaNumero(int numero)
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

        public DataTable ConsultaCliente(string nit)
        {
            var tabla = new DataTable();
            try
            {
                CargarAdapter("remision_cliente_credito_no_anuladas");
                miAdapter.SelectCommand.Parameters.AddWithValue("nit", nit);
                miAdapter.Fill(tabla);
                return tabla;
            }
            catch (Exception ex)
            {
                throw new Exception(ErrorConsulta + ex.Message);
            }
        }

        public DataTable ConsultaCliente(string nit, bool remision)
        {
            var tabla = new DataTable();
            try
            {
                if (remision)
                {
                    CargarAdapter(ConsultaCliente_);
                }
                else
                {
                    CargarAdapter(ConsultaClienteFac);
                }
                miAdapter.SelectCommand.Parameters.AddWithValue("nit", nit);
                miAdapter.Fill(tabla);
                return tabla;
            }
            catch (Exception ex)
            {
                throw new Exception(ErrorConsulta + ex.Message);
            }
        }

        public DataTable ConsultaCliente(string nit, bool remision, int rowBase, int rowMax)
        {
            var tabla = new DataTable();
            try
            {
                if (remision)
                {
                    CargarAdapter(ConsultaCliente_);
                }
                else
                {
                    CargarAdapter(ConsultaClienteFac);
                }
                miAdapter.SelectCommand.Parameters.AddWithValue("nit", nit);
                miAdapter.Fill(rowBase, rowMax, tabla);
                return tabla;
            }
            catch (Exception ex)
            {
                throw new Exception(ErrorConsulta + ex.Message);
            }
        }

        public long GetRowsConsultaCliente(string nit, bool remision)
        {
            try
            {
                if (remision)
                {
                    CargarComando(CountConsultaCliente);
                }
                else
                {
                    CargarComando(CountConsultaClienteFac);
                }
                miComando.Parameters.AddWithValue("nit", nit);
                miConexion.MiConexion.Open();
                var rows = Convert.ToInt64(miComando.ExecuteScalar());
                miConexion.MiConexion.Close();
                miComando.Dispose();
                return rows;
            }
            catch (Exception ex)
            {
                throw new Exception(ErrorCount + ex.Message);
            }
            finally { miConexion.MiConexion.Close(); }
        }

        public DataTable ConsultaEstado(bool remision, int rowBase, int rowMax)
        {
            var tabla = new DataTable();
            try
            {
                if (remision)
                {
                    CargarAdapter(ConsultaEstadoR);
                }
                else
                {
                    CargarAdapter(ConsultaEstadoF);
                }
                miAdapter.Fill(rowBase, rowMax, tabla);
                return tabla;
            }
            catch (Exception ex)
            {
                throw new Exception(ErrorConsulta + ex.Message);
            }
        }

        public long GetRowsConsultaEstado(bool remision)
        {
            try
            {
                if (remision)
                {
                    CargarComando(CountConsultaEstadoR);
                }
                else
                {
                    CargarComando(CountConsultaEstadoF);
                }
                miConexion.MiConexion.Open();
                var rows = Convert.ToInt64(miComando.ExecuteScalar());
                miConexion.MiConexion.Close();
                miComando.Dispose();
                return rows;
            }
            catch (Exception ex)
            {
                throw new Exception(ErrorCount + ex.Message);
            }
            finally { miConexion.MiConexion.Close(); }
        }

        public DataTable ConsultaCliente(string nit, bool remision, DateTime fecha)
        {
            var tabla = new DataTable();
            try
            {
                if (remision)
                {
                    CargarAdapter(ConsultaCliente_);
                }
                else
                {
                    CargarAdapter(ConsultaClienteFac);
                }
                miAdapter.SelectCommand.Parameters.AddWithValue("nit", nit);
                miAdapter.SelectCommand.Parameters.AddWithValue("fecha", fecha);
                miAdapter.Fill(tabla);
                return tabla;
            }
            catch (Exception ex)
            {
                throw new Exception(ErrorConsulta + ex.Message);
            }
        }

        public DataTable ConsultaEstado(bool remision, DateTime fecha)
        {
            var tabla = new DataTable();
            try
            {
                if (remision)
                {
                    CargarAdapter(ConsultaEstadoR);
                }
                else
                {
                    CargarAdapter(ConsultaEstadoF);
                }
                miAdapter.SelectCommand.Parameters.AddWithValue("fecha", fecha);
                miAdapter.Fill(tabla);
                return tabla;
            }
            catch (Exception ex)
            {
                throw new Exception(ErrorConsulta + ex.Message);
            }
        }

        public DataTable ConsultaCliente
            (string nit, bool remision, DateTime fecha, DateTime fecha1, int rowBase, int rowMax)
        {
            var tabla = new DataTable();
            try
            {
                if (remision)
                {
                    CargarAdapter(ConsultaCliente_);
                }
                else
                {
                    CargarAdapter(ConsultaClienteFac);
                }
                miAdapter.SelectCommand.Parameters.AddWithValue("nit", nit);
                miAdapter.SelectCommand.Parameters.AddWithValue("fecha", fecha);
                miAdapter.SelectCommand.Parameters.AddWithValue("fecha1", fecha1);
                miAdapter.Fill(rowBase, rowMax, tabla);
                return tabla;
            }
            catch (Exception ex)
            {
                throw new Exception(ErrorConsulta + ex.Message);
            }
        }

        public long GetRowsConsultaCliente
            (string nit, bool remision, DateTime fecha, DateTime fecha1)
        {
            try
            {
                if (remision)
                {
                    CargarComando(CountConsultaCliente);
                }
                else
                {
                    CargarComando(CountConsultaClienteFac);
                }
                miComando.Parameters.AddWithValue("nit", nit);
                miComando.Parameters.AddWithValue("fecha", fecha);
                miComando.Parameters.AddWithValue("fecha1", fecha1);
                miConexion.MiConexion.Open();
                var rows = Convert.ToInt64(miComando.ExecuteScalar());
                miConexion.MiConexion.Close();
                miComando.Dispose();
                return rows;
            }
            catch (Exception ex)
            {
                throw new Exception(ErrorCount + ex.Message);
            }
            finally { miConexion.MiConexion.Close(); }
        }

        public DataTable consultaEstado
            (bool remision, DateTime fecha, DateTime fecha1, int rowBase, int rowMax)
        {
            var tabla = new DataTable();
            try
            {
                if (remision)
                {
                    CargarAdapter(ConsultaEstadoR);
                }
                else
                {
                    CargarAdapter(ConsultaEstadoF);
                }
                miAdapter.SelectCommand.Parameters.AddWithValue("fecha", fecha);
                miAdapter.SelectCommand.Parameters.AddWithValue("fecha1", fecha1);
                miAdapter.Fill(rowBase, rowMax, tabla);
                return tabla;
            }
            catch (Exception ex)
            {
                throw new Exception(ErrorConsulta + ex.Message);
            }
        }

        public long GetRowsConsultaEstado(bool remision, DateTime fecha, DateTime fecha1)
        {
            try
            {
                if (remision)
                {
                    CargarComando(CountConsultaEstadoR);
                }
                else
                {
                    CargarComando(CountConsultaEstadoF);
                }
                miComando.Parameters.AddWithValue("fecha", fecha);
                miComando.Parameters.AddWithValue("fecha1", fecha1);
                miConexion.MiConexion.Open();
                var rows = Convert.ToInt64(miComando.ExecuteScalar());
                miConexion.MiConexion.Close();
                miComando.Dispose();
                return rows;
            }
            catch (Exception ex)
            {
                throw new Exception(ErrorCount + ex.Message);
            }
            finally { miConexion.MiConexion.Close(); }
        }


        public bool RemisionAnulada(int numero)
        {
            try
            {
                CargarComando("remision_anulada");
                miComando.Parameters.AddWithValue("numero", numero);
                miConexion.MiConexion.Open();
                var anulada = Convert.ToBoolean(miComando.ExecuteScalar());
                miConexion.MiConexion.Close();
                miComando.Dispose();
                return anulada;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al consultar el estado de la remisión.\n" + ex.Message);
            }
            finally { miConexion.MiConexion.Close(); }
        }

        public void AnularRemision(int numero, bool carga)
        {
            try
            {
                CargarComando("anular_remision");
                miComando.Parameters.AddWithValue("numero", numero);
                miConexion.MiConexion.Open();
                miComando.ExecuteNonQuery();
                miConexion.MiConexion.Close();
                miComando.Dispose();
                if (carga)
                {
                    var productos = ProductoRemision(numero);
                    var miDaoInventario = new DaoInventario();
                    foreach (DataRow row in productos.Rows)
                    {
                        miDaoInventario.ActualizarInventario(
                        new Inventario
                        {
                            CodigoProducto = row["codigo"].ToString(),
                            IdMedida = Convert.ToInt32(row["idmedida"]),
                            IdColor = Convert.ToInt32(row["idcolor"]),
                            Cantidad = Convert.ToDouble(row["cantidad"])
                        },
                        false);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrio un error al anular la remisión.\n" + ex.Message);
            }
            finally { miConexion.MiConexion.Close(); }
        }

        public void RemisionFacturada(int numero)
        {
            try
            {
                CargarComando("editar_remision_facturada");
                miComando.Parameters.AddWithValue("numero", numero);
                miConexion.MiConexion.Open();
                miComando.ExecuteNonQuery();
                miConexion.MiConexion.Close();
                miComando.Dispose();
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al editar la Remisión Facturada.\n" + ex.Message);
            }
            finally { miConexion.MiConexion.Close(); }
        }

       /* public long SaldoDeCliente(string cliente)
        {
            int totalFact = 0;
            int pagosFact = 0;
            int saldo = 0;
            long saldoTotal = 0;
            try
            {
                var remisiones = ConsultaCliente(cliente, true);
                foreach (DataRow rRow in remisiones.Rows)
                {
                    var productos = ProductoRemision(Convert.ToInt32(rRow["numero"]));

                }
                return saldoTotal;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al consultar el saldo del Cliente.\n" + ex.Message);
            }
        }*/

        public DataTable FormasPago(int numero)
        {
            var tabla = new DataTable();
            try
            {
                CargarAdapter("pagos_a_remision");
                miAdapter.SelectCommand.Parameters.AddWithValue("numero", numero);
                miAdapter.Fill(tabla);
                return tabla;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al consultar los Pagos.\n" + ex.Message);
            }
        }

        public DataTable ClienteDeRemsion(int numero)
        {
            var tabla = new DataTable();
            try
            {
                CargarAdapter("cliente_de_remision");
                miAdapter.SelectCommand.Parameters.AddWithValue("numero", numero);
                miAdapter.Fill(tabla);
                return tabla;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al consultar el cliente.\n" + ex.Message);
            }
        }


        // Resumen de ventas de remisiones

        public void NewConection()
        {
            try
            {
                miConexion = new Conexion();
                miDaoProducto.NewConection();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public DataTable ResumenIvaCompras(DateTime fecha, DateTime fecha2)
        {
            try
            {
                var tIva = new DataTable();
                CargarAdapter("resumen_remision_compras");
                miAdapter.SelectCommand.Parameters.AddWithValue("", fecha);
                miAdapter.SelectCommand.Parameters.AddWithValue("", fecha2);
                miAdapter.Fill(tIva);
                return tIva;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public DataTable ResumenIvaVentas(DateTime fecha, DateTime fecha2)
        {
            try
            {
                var tIva = new DataTable();
                CargarAdapter("resumen_remision_ventas");
                miAdapter.SelectCommand.Parameters.AddWithValue("", fecha);
                miAdapter.SelectCommand.Parameters.AddWithValue("", fecha2);
                miAdapter.Fill(tIva);
                return tIva;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<Impuesto> ResumenDevolucion(DateTime fecha, DateTime fecha2)
        {
            try
            {
                List<Impuesto> impuestos = new List<Impuesto>();
                string sql = "select  " +
                                "iva ,  " +
                                "SUM  " +
                                "(  " +
                                "mi_round_trunc   " +
                                "(       " +
                                "devolucion_remision.valor +   " +
                                "mi_round   " +
                                "(   " +
                                "    devolucion_remision.valor   " +
                                "    * devolucion_remision.iva / 100, 1   " +
                                ")    " +
                                "    * devolucion_remision.cantidad, 0   " +
                                ")   " +
                                ") AS total    " +
                             "from    " +
                                "devolucion_remision    " +
                             "where    " +
                                "fecha between @fecha and @fecha2  " +
                             "group by  " +
                                "iva;";
                CargarComandoText(sql);
                miComando.Parameters.AddWithValue("fecha", fecha);
                miComando.Parameters.AddWithValue("fecha2", fecha2);
                miConexion.MiConexion.Open();
                NpgsqlDataReader reader = miComando.ExecuteReader();
                while (reader.Read())
                {
                    impuestos.Add(new Impuesto
                    {
                        Tarifa = reader.GetDouble(0).ToString(),
                        Total = Convert.ToInt32(reader.GetDouble(1))
                    });
                }
                miConexion.MiConexion.Close();
                miComando.Dispose();
                foreach (Impuesto i in impuestos)
                {
                    i.BaseGravable = Convert.ToInt32(i.Total / (1 + (Convert.ToDouble(i.Tarifa) / 100)));
                    i.ValorIva = i.Total - i.BaseGravable;
                }
                return impuestos;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally { miConexion.MiConexion.Close(); }
        }

        public double TotalCostoVenta(DateTime fecha, DateTime fecha2)
        {
            try
            {
                double costo = 0 , cost = 0;
                var productos = CodigosProductos(fecha, fecha2);
                foreach (var p in productos)
                {
                    cost = 0;
                    //cost = TotalCostoVenta(fecha, fecha, p.Producto.CodigoInternoProducto);
                   // if (cost.Equals(0))
                   // {
                        costo += miDaoProducto.PrecioDeCostoMasIva(p.Producto.CodigoInternoProducto) * p.Cantidad;
                    /*}
                    else
                    {
                        costo += cost;
                    }*/
                }
                return costo;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /*private double CostoProducto(DateTime fecha, DateTime fecha2, string codigo)
        {

        }*/

        private DaoProducto miDaoProducto;
        private double TotalCostoVenta(DateTime fecha, DateTime fecha2, string codigo)
        {
            try
            {
                
                string sql =
                "SELECT MAX(producto_factura_venta.costo) AS costo FROM factura_venta, producto_factura_venta WHERE factura_venta.id = producto_factura_venta.id_factura AND " +
                "producto_factura_venta.codigointernoproducto = '" + codigo + "' AND factura_venta.fecha_factura_venta BETWEEN " +
                "'" + fecha.ToShortDateString() + "' AND '" + fecha2.ToShortDateString() + "';";
                miComando = new NpgsqlCommand();
                miComando.Connection = miConexion.MiConexion;
                miComando.CommandType = CommandType.Text;
                miComando.CommandText = sql;
                miComando.CommandTimeout = 0;
                miConexion.MiConexion.Open();
                double costo = Convert.ToInt32(miComando.ExecuteScalar());
                miConexion.MiConexion.Close();
                miComando.Dispose();
                return costo;
            }
            catch (InvalidCastException)
            {
                Console.WriteLine(codigo);
                return 0;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally { miConexion.MiConexion.Close(); }
        }

        private List<ProductoFacturaProveedor> CodigosProductos(DateTime fecha, DateTime fecha2)
        {
            try
            {
                var productos = new List<ProductoFacturaProveedor>();
                CargarComando("productos_cantidad_remision_venta");
                miComando.Parameters.AddWithValue("", fecha);
                miComando.Parameters.AddWithValue("", fecha2);
                miConexion.MiConexion.Open();
                NpgsqlDataReader reader = miComando.ExecuteReader();
                while (reader.Read())
                {
                    var p = new ProductoFacturaProveedor();
                    p.Producto.CodigoInternoProducto = reader.GetString(0);
                    p.Cantidad = reader.GetDouble(1);
                    productos.Add(p);
                }
                miConexion.MiConexion.Close();
                miComando.Dispose();
                return productos;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally { miConexion.MiConexion.Close(); }
        }


        #region ProductoRemision

        public void IngresarProducto(ProductoFacturaProveedor producto)
        {
            try
            {
                CargarComando(IngresarProducto_);
                miComando.Parameters.AddWithValue("numero", producto.NumeroFactura);
                miComando.Parameters.AddWithValue("codigo", producto.Producto.CodigoInternoProducto);
                miComando.Parameters.AddWithValue("cantidad", producto.Cantidad);
                miComando.Parameters.AddWithValue("valor", producto.Producto.ValorVentaProducto);
                miComando.Parameters.AddWithValue("medida", producto.Inventario.IdMedida);
                miComando.Parameters.AddWithValue("color", producto.Inventario.IdColor);
                miComando.Parameters.AddWithValue("descto", producto.Producto.Descuento);
                miComando.Parameters.AddWithValue("recargo", producto.Producto.Recargo);
                miComando.Parameters.AddWithValue("iva", producto.Producto.ValorIva);
                miComando.Parameters.AddWithValue("impoconsumo", producto.ImpoConsumo);
                miComando.Parameters.AddWithValue("costo", producto.Costo);
                miConexion.MiConexion.Open();
                miComando.ExecuteNonQuery();
                miConexion.MiConexion.Close();
                miComando.Dispose();
            }
            catch (Exception ex)
            {
                throw new Exception(ErrorIngProducto + ex.Message);
            }
            finally { miConexion.MiConexion.Close(); }
        }

        public DataSet PrintProducto(int numero, bool descuento)
        {
            var dataSet = new DataSet();
            var tablaDB = new DataTable();
            var miTabla = CrearTabla();
            miTabla.TableName = "Detalle";
            try
            {
                CargarAdapter(PrintProducto_);
                miAdapter.SelectCommand.Parameters.AddWithValue("numero", numero);
                miAdapter.Fill(tablaDB);
                foreach (DataRow row in tablaDB.Rows)
                {
                    var row_ = miTabla.NewRow();
                    row_["Codigo"] = row["Codigo"];
                    row_["Cantidad"] = row["Cantidad"];
                    row_["Producto"] = row["Producto"];
                    if (!descuento)
                    {
                        row["Valor"] = Math.Round((
                           Convert.ToDouble(row["Valor"]) +
                           Convert.ToDouble(Convert.ToDouble(row["Valor"]) * Convert.ToDouble(row["Recargo"]) / 100)), 1);
                        
                        /*row["Valor"] = Convert.ToInt32(row["Valor"]) +
                               Convert.ToInt32(Convert.ToInt32(row["Valor"]) * Convert.ToDouble(row["Recargo"]) / 100);*/
                    }
                    else
                    {
                        row_["Valor"] = row["Valor"];
                    }
                    var v = row["Valor"].ToString();
                    double valorIva = Math.Round((Convert.ToDouble(row["Valor"]) * Convert.ToDouble(row["Iva"]) / 100), 1);
                    row_["ValorMasIva"] = Convert.ToInt32(Convert.ToDouble(row["Valor"]) + valorIva);
                    v = row_["ValorMasIva"].ToString();

                    row_["Descuento"] = row["Descuento"];//%
                    row_["Descto"] = Math.Round(Convert.ToDouble(row["Descto"]), 1);

                    v = row_["Descuento"].ToString();
                    v = row_["Descto"].ToString();

                    var valorMenosDescto = Convert.ToDouble(row["Valor"]) - Convert.ToDouble(row_["Descto"]);

                    /*var vIva = Convert.ToInt32(
                        valorMenosDescto * Convert.ToDouble(row["Iva"]) / 100);*/
                    double vIva = Math.Round(
                                (valorMenosDescto * Convert.ToDouble(row["Iva"]) / 100), 1);

                    //antes
                    //row_["Valor_"] = Convert.ToInt32(Convert.ToDouble(row["Valor"]) + vIva);//Convert.ToInt32(row["Valor"]) + vIva;
                    //despues
                    if (this.RedondearPrecio2)
                    {
                        row_["Valor_"] = UseObject.Aproximar(Convert.ToInt32(valorMenosDescto + vIva + Convert.ToInt32(row["impoconsumo"])),
                                Convert.ToBoolean(AppConfiguracion.ValorSeccion("tipo_aprox_precio")));
                    }
                    else
                    {
                        row_["Valor_"] = Convert.ToInt32(valorMenosDescto + vIva + Convert.ToInt32(row["impoconsumo"]));
                    }

                    v = row_["Valor_"].ToString();

                    //antes
                    /*row_["Sub_Total"] = Convert.ToInt32(
                        Convert.ToDouble(row["Valor"]) * Convert.ToDouble(row["Cantidad"]));*/
                    row_["Sub_Total"] = Convert.ToInt32(
                        Convert.ToDouble(row_["ValorMasIva"]) * Convert.ToDouble(row["Cantidad"]));

                    v = row_["Sub_Total"].ToString();

                    row_["Descto_"] = Convert.ToInt32(
                        Convert.ToInt32(row["Descto"]) * Convert.ToDouble(row["Cantidad"]));

                    v = row_["Descto_"].ToString();

                    row_["vIva_"] = Convert.ToDouble(vIva * Convert.ToDouble(row["Cantidad"]));

                    v = row_["vIva_"].ToString();

                    row_["Total_"] = Convert.ToInt32(Convert.ToInt32(row_["Valor_"]) * Convert.ToDouble(row["Cantidad"]));
                    /*row_["Total_"] = Convert.ToInt32(
                        ((Convert.ToInt32(row["Valor"]) - Convert.ToInt32(row["Descto"])) + vIva) * Convert.ToDouble(row["Cantidad"]));*/

                    v = row_["Total_"].ToString();

                    miTabla.Rows.Add(row_);
                }
                dataSet.Tables.Add(miTabla);
                tablaDB.Clear();
                tablaDB.Dispose();
                tablaDB = null;
                return dataSet;
            }
            catch (Exception ex)
            {
                throw new Exception(ErrorConsulta + ex.Message);
            }
        }

        public DataTable ProductoRemision(int numero)
        {
            var tabla = new DataTable();
            var miTabla = CrearTabla();
            try
            {
                CargarAdapter(ProductoRemision_);
                miAdapter.SelectCommand.Parameters.AddWithValue("numero", numero);
                miAdapter.Fill(tabla);
                return tabla;
            }
            catch (Exception ex)
            {
                throw new Exception(ErrorProducto + ex.Message);
            }
        }

        public DataTable CalculosProductoRemision(int numero, bool descuento)
        {
            var tabla = new DataTable();
            var miTabla = CrearTabla();
            try
            {
                CargarAdapter(ProductoRemision_);
                miAdapter.SelectCommand.Parameters.AddWithValue("numero", numero);
                miAdapter.Fill(tabla);

                //ORGANIZAR LOS DATOS

                foreach (DataRow row in tabla.Rows)
                {
                    var row_ = miTabla.NewRow();
                    row_["Cantidad"] = row["cantidad"];
                    row_["ValorUnitario"] = row["valor"];
                    if (descuento)
                    {
                        row_["Descuento"] = row["descto"].ToString() + "%";
                        row_["ValorMenosDescto"] = Convert.ToDouble(row["valor"]) -
                            (Convert.ToDouble(row["valor"]) * Convert.ToDouble(row["descto"]) / 100);
                    }
                    else
                    {
                        row_["Descuento"] = row["recargo"].ToString() + "%";
                        row_["ValorMenosDescto"] = Convert.ToDouble(row["valor"]) +
                            (Convert.ToDouble(row["valor"]) * Convert.ToDouble(row["recargo"]) / 100);
                    }
                    row_["Iva"] = row["iva"].ToString() + "%";
                    row_["ValorIva"] = Convert.ToDouble(row_["ValorMenosDescto"]) * Convert.ToDouble(row["iva"]) / 100;
                    row_["TotalMasIva"] = Convert.ToDouble(row_["ValorMenosDescto"]) +
                        (Convert.ToDouble(row_["ValorMenosDescto"]) * Convert.ToDouble(row["iva"]) / 100);
                    row_["Valor"] = Convert.ToDouble(row_["TotalMasIva"]) * Convert.ToDouble(row["cantidad"]);
                    miTabla.Rows.Add(row_);
                }

                //

                return miTabla;
            }
            catch (Exception ex)
            {
                throw new Exception(ErrorProducto + ex.Message);
            }
        }

        /// <summary>
        /// Obtiene un tabla de memora con las columnas usadas en los datos de 
        /// impresión del producto de fatura de venta.
        /// </summary>
        /// <returns></returns>
        private DataTable CrearTabla()
        {
            var tabla = new DataTable();
            tabla.Columns.Add(new DataColumn("Codigo", typeof(string)));
            tabla.Columns.Add(new DataColumn("Cantidad", typeof(double)));
            tabla.Columns.Add(new DataColumn("Producto", typeof(string)));
            tabla.Columns.Add(new DataColumn("Valor", typeof(double)));
            tabla.Columns.Add(new DataColumn("Descuento", typeof(double)));
            tabla.Columns.Add(new DataColumn("Descto", typeof(int)));
            tabla.Columns.Add(new DataColumn("Iva", typeof(double)));
            tabla.Columns.Add(new DataColumn("SubTotal", typeof(int)));
            tabla.Columns.Add(new DataColumn("Total", typeof(int)));

            tabla.Columns.Add(new DataColumn("Id", typeof(int)));
            tabla.Columns.Add(new DataColumn("ValorMenosDescto", typeof(double)));
            tabla.Columns.Add(new DataColumn("ValorIva", typeof(double)));

            tabla.Columns.Add(new DataColumn("Valor_", typeof(double)));
            tabla.Columns.Add(new DataColumn("Sub_Total", typeof(double)));
            tabla.Columns.Add(new DataColumn("Descto_", typeof(int)));
            tabla.Columns.Add(new DataColumn("vIva_", typeof(double)));

            tabla.Columns.Add(new DataColumn("Total_", typeof(int)));
            tabla.Columns.Add(new DataColumn("ValorMasIva", typeof(int)));

            //miTabla.Columns.Add(new DataColumn("TotalMasIva", typeof(double)));subTotal
            //miTabla.Columns.Add(new DataColumn("Valor", typeof(double)));total
            return tabla;
        }

        #endregion


        // Remision Proveedor

        public FacturaProveedor ConsultaProveedor(int id)
        {
            var factura = new FacturaProveedor();
            try
            {
                CargarComando("consulta_remision");
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
                    factura.Ajuste = miReader.GetDouble(10);
                    factura.Facturada = miReader.GetBoolean(11);
                    factura.FechaFactura = miReader.GetDateTime(12);
                }
                miConexion.MiConexion.Close();
                miComando.Dispose();
                factura.Productos = ProductosRemisionProveedor(id);
                return factura;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al cargar la Remisión.\n" + ex.Message);
            }
            finally { miConexion.MiConexion.Close(); }
        }

        public DataTable ConsultaProveedor(string numero)
        {
            var tabla = new DataTable();
            try
            {
                CargarAdapter("consulta_remision_proveedor");
                miAdapter.SelectCommand.Parameters.AddWithValue("numero", numero);
                miAdapter.Fill(tabla);
                return tabla;
            }
            catch (Exception ex)
            {
                throw new Exception(ErrorConsulta + ex.Message);
            }
        }

        public DataTable ConsultaProveedorNit(string nit, int rowBase, int rowMax)
        {
            var tabla = new DataTable();
            try
            {
                CargarAdapter("consulta_remision_proveedor_nit");
                miAdapter.SelectCommand.Parameters.AddWithValue("nit", nit);
                miAdapter.Fill(rowBase, rowMax, tabla);
                return tabla;
            }
            catch (Exception ex)
            {
                throw new Exception(ErrorConsulta + ex.Message);
            }
        }

        public long CountConsultaProveedor(string nit)
        {
            try
            {
                CargarComando("count_consulta_remision_proveedor_nit");
                miComando.Parameters.AddWithValue("nit", nit);
                miConexion.MiConexion.Open();
                var rows = Convert.ToInt64(miComando.ExecuteScalar());
                miConexion.MiConexion.Close();
                miComando.Dispose();
                return rows;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al cargar el conteo de las Remisiones.\n" + ex.Message);
            }
            finally { miConexion.MiConexion.Close(); }
        }

        public DataTable ConsultaProveedor(int codigo, int rowBase, int rowMax)
        {
            var tabla = new DataTable();
            try
            {
                CargarAdapter("consulta_remision_proveedor");
                miAdapter.SelectCommand.Parameters.AddWithValue("codigo", codigo);
                miAdapter.Fill(rowBase, rowMax, tabla);
                return tabla;
            }
            catch (Exception ex)
            {
                throw new Exception(ErrorConsulta + ex.Message);
            }
        }

        public long CountConsultaProveedor(int codigo)
        {
            try
            {
                CargarComando("count_consulta_remision_proveedor");
                miComando.Parameters.AddWithValue("codigo", codigo);
                miConexion.MiConexion.Open();
                var rows = Convert.ToInt64(miComando.ExecuteScalar());
                miConexion.MiConexion.Close();
                miComando.Dispose();
                return rows;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al cargar el conteo de las Remisiones.\n" + ex.Message);
            }
            finally { miConexion.MiConexion.Close(); }
        }

        public DataTable ConsultaRemisionProveedor(int codigo)
        {
            var tabla = new DataTable();
            try
            {
                CargarAdapter("remision_proveedor_credito_no_anuladas");
                miAdapter.SelectCommand.Parameters.AddWithValue("codigo", codigo);
                miAdapter.Fill(tabla);
                return tabla;
            }
            catch (Exception ex)
            {
                throw new Exception(ErrorConsulta + ex.Message);
            }
        }

        public DataTable ConsultaRemisionProveedor(string nit)
        {
            var tabla = new DataTable();
            try
            {
                CargarAdapter("remision_proveedor_credito_no_anuladas");
                miAdapter.SelectCommand.Parameters.AddWithValue("nit", nit);
                miAdapter.Fill(tabla);
                return tabla;
            }
            catch (Exception ex)
            {
                throw new Exception(ErrorConsulta + ex.Message);
            }
        }

        public DataTable ConsultaProveedor(DateTime fecha, int rowBase, int rowMax)
        {
            var tabla = new DataTable();
            try
            {
                CargarAdapter("consulta_remision_proveedor_fecha");
                miAdapter.SelectCommand.Parameters.AddWithValue("fecha", fecha);
                miAdapter.Fill(rowBase, rowMax, tabla);
                return tabla;
            }
            catch (Exception ex)
            {
                throw new Exception(ErrorConsulta + ex.Message);
            }
        }

        public long CountConsultaProveedor(DateTime fecha)
        {
            try
            {
                CargarComando("count_consulta_remision_proveedor_fecha");
                miComando.Parameters.AddWithValue("fecha", fecha);
                miConexion.MiConexion.Open();
                var rows = Convert.ToInt64(miComando.ExecuteScalar());
                miConexion.MiConexion.Close();
                miComando.Dispose();
                return rows;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al cargar el conteo de las Remisiones.\n" + ex.Message);
            }
            finally { miConexion.MiConexion.Close(); }
        }

        public DataTable ConsultaProveedor(DateTime fecha, DateTime fecha2, int rowBase, int rowMax)
        {
            var tabla = new DataTable();
            try
            {
                CargarAdapter("consulta_remision_proveedor_periodo");
                miAdapter.SelectCommand.Parameters.AddWithValue("fecha", fecha);
                miAdapter.SelectCommand.Parameters.AddWithValue("fecha2", fecha2);
                miAdapter.Fill(rowBase, rowMax, tabla);
                return tabla;
            }
            catch (Exception ex)
            {
                throw new Exception(ErrorConsulta + ex.Message);
            }
        }

        public long CountConsultaProveedor(DateTime fecha, DateTime fecha2)
        {
            try
            {
                CargarComando("count_consulta_remision_proveedor_periodo");
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
                throw new Exception("Ocurrió un error al cargar el conteo de las Remisiones.\n" + ex.Message);
            }
            finally { miConexion.MiConexion.Close(); }
        }

        public DataTable ConsultaProveedor(int codigo, DateTime fecha, int rowBase, int rowMax)
        {
            var tabla = new DataTable();
            try
            {
                CargarAdapter("consulta_remision_proveedor");
                miAdapter.SelectCommand.Parameters.AddWithValue("codigo", codigo);
                miAdapter.SelectCommand.Parameters.AddWithValue("fecha2", fecha);
                miAdapter.Fill(rowBase, rowMax, tabla);
                return tabla;
            }
            catch (Exception ex)
            {
                throw new Exception(ErrorConsulta + ex.Message);
            }
        }

        public long CountConsultaProveedor(int codigo, DateTime fecha)
        {
            try
            {
                CargarComando("count_consulta_remision_proveedor");
                miComando.Parameters.AddWithValue("codigo", codigo);
                miComando.Parameters.AddWithValue("fecha", fecha);
                miConexion.MiConexion.Open();
                var rows = Convert.ToInt64(miComando.ExecuteScalar());
                miConexion.MiConexion.Close();
                miComando.Dispose();
                return rows;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al cargar el conteo de las Remisiones.\n" + ex.Message);
            }
            finally { miConexion.MiConexion.Close(); }
        }

        public DataTable ConsultaProveedor
            (int codigo, DateTime fecha, DateTime fecha2, int rowBase, int rowMax)
        {
            var tabla = new DataTable();
            try
            {
                CargarAdapter("consulta_remision_proveedor");
                miAdapter.SelectCommand.Parameters.AddWithValue("codigo", codigo);
                miAdapter.SelectCommand.Parameters.AddWithValue("fecha", fecha);
                miAdapter.SelectCommand.Parameters.AddWithValue("fecha2", fecha2);
                miAdapter.Fill(rowBase, rowMax, tabla);
                return tabla;
            }
            catch (Exception ex)
            {
                throw new Exception(ErrorConsulta + ex.Message);
            }
        }

        public long CountConsultaProveedor(int codigo, DateTime fecha, DateTime fecha2)
        {
            try
            {
                CargarComando("count_consulta_remision_proveedor");
                miComando.Parameters.AddWithValue("codigo", codigo);
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
                throw new Exception("Ocurrió un error al cargar el conteo de las Remisiones.\n" + ex.Message);
            }
            finally { miConexion.MiConexion.Close(); }
        }

        public DataTable ConsultaProveedor
            (string nit, DateTime fecha, int rowBase, int rowMax)
        {
            var tabla = new DataTable();
            try
            {
                CargarAdapter("consulta_remision_proveedor");
                miAdapter.SelectCommand.Parameters.AddWithValue("nit", nit);
                miAdapter.SelectCommand.Parameters.AddWithValue("fecha", fecha);
                miAdapter.Fill(rowBase, rowMax, tabla);
                return tabla;
            }
            catch (Exception ex)
            {
                throw new Exception(ErrorConsulta + ex.Message);
            }
        }

        public long CountConsultaProveedor(string nit, DateTime fecha)
        {
            try
            {
                CargarComando("count_consulta_remision_proveedor");
                miComando.Parameters.AddWithValue("nit", nit);
                miComando.Parameters.AddWithValue("fecha", fecha);
                miConexion.MiConexion.Open();
                var rows = Convert.ToInt64(miComando.ExecuteScalar());
                miConexion.MiConexion.Close();
                miComando.Dispose();
                return rows;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al cargar el conteo de las Remisiones.\n" + ex.Message);
            }
            finally { miConexion.MiConexion.Close(); }
        }

        public DataTable ConsultaProveedor
            (string nit, DateTime fecha, DateTime fecha2, int rowBase, int rowMax)
        {
            var tabla = new DataTable();
            try
            {
                CargarAdapter("consulta_remision_proveedor");
                miAdapter.SelectCommand.Parameters.AddWithValue("nit", nit);
                miAdapter.SelectCommand.Parameters.AddWithValue("fecha", fecha);
                miAdapter.SelectCommand.Parameters.AddWithValue("fecha2", fecha2);
                miAdapter.Fill(rowBase, rowMax, tabla);
                return tabla;
            }
            catch (Exception ex)
            {
                throw new Exception(ErrorConsulta + ex.Message);
            }
        }

        public long CountConsultaProveedor(string nit, DateTime fecha, DateTime fecha2)
        {
            try
            {
                CargarComando("count_consulta_remision_proveedor");
                miComando.Parameters.AddWithValue("nit", nit);
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
                throw new Exception("Ocurrió un error al cargar el conteo de las Remisiones.\n" + ex.Message);
            }
            finally { miConexion.MiConexion.Close(); }
        }



        public void EditarRemisionProveedor(FacturaProveedor remision)
        {
            try
            {
                CargarComando("edita_remision_proveedor");
                miComando.Parameters.AddWithValue("id", remision.Id);
                miComando.Parameters.AddWithValue("codigo", remision.Proveedor.CodigoInternoProveedor);
                miComando.Parameters.AddWithValue("idpago", remision.EstadoFactura.Id);
                miComando.Parameters.AddWithValue("idusuario", remision.Usuario.Id);
                miComando.Parameters.AddWithValue("numero", remision.Numero);
                miComando.Parameters.AddWithValue("limite", remision.FechaLimite);
                miComando.Parameters.AddWithValue("ingreso", remision.FechaIngreso);
                miComando.Parameters.AddWithValue("estado", remision.Estado);
                miComando.Parameters.AddWithValue("descuento", remision.Descuento);
                miComando.Parameters.AddWithValue("ajuste", remision.Ajuste);
                miComando.Parameters.AddWithValue("fecha_remision", remision.FechaFactura);
                miConexion.MiConexion.Open();
                miComando.ExecuteNonQuery();
                miConexion.MiConexion.Close();
                miComando.Dispose();

                if (!remision.Estado)
                {
                    foreach (var producto in ProductosRemisionProveedor(remision.Id))
                    {
                        miDaoInventario.ActualizarInventario(new Inventario
                        {
                            CodigoProducto = producto.Producto.CodigoInternoProducto,
                            IdMedida = producto.Inventario.IdMedida,
                            IdColor = producto.Inventario.IdColor,
                            Cantidad = producto.Cantidad
                        }, true);
                    }
                }


                //var miDaoInventario = new DaoInventario();

                


            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrio un error al editar la remisión.\n" + ex.Message);
            }
            finally { miConexion.MiConexion.Close(); }
        }

        public void FacturarRemisionProveedor(int id, bool facturada)
        {
            try
            {
                CargarComando("facturar_remision_proveedor");
                miComando.Parameters.AddWithValue("id", id);
                miComando.Parameters.AddWithValue("facturada", facturada);
                miConexion.MiConexion.Open();
                miComando.ExecuteNonQuery();
                miConexion.MiConexion.Close();
                miComando.Dispose();
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al editar la remisión.\n" + ex.Message);
            }
            finally { miConexion.MiConexion.Close(); }
        }

        //Producto remsion

        public DataTable ConsultaProductoProveedor(int id)
        {
            var tabla = new DataTable();
            try
            {
                CargarAdapter("consulta_producto_remision_proveedor");
                miAdapter.SelectCommand.Parameters.AddWithValue("id", id);
                miAdapter.Fill(tabla);
                return tabla;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al consultar los articulos de la remisión.\n" + ex.Message);
            }
        }

        public List<ProductoFacturaProveedor> ProductosRemisionProveedor(int idRemision)
        {
            var productos = new List<ProductoFacturaProveedor>();
            try
            {
                CargarComando("consulta_producto_remision_proveedor");
                miComando.Parameters.AddWithValue("idRemision", idRemision);
                miConexion.MiConexion.Open();
                NpgsqlDataReader miReader = miComando.ExecuteReader();
                while (miReader.Read())
                {
                    var producto = new ProductoFacturaProveedor();
                    producto.Id = miReader.GetInt32(0);
                    producto.IdFactura = miReader.GetInt32(1);
                    producto.Producto.CodigoInternoProducto = miReader.GetString(2);
                    producto.Inventario.IdMedida = miReader.GetInt32(6);
                    producto.Inventario.IdColor = miReader.GetInt32(8);
                    producto.Lote.Id = miReader.GetInt32(10);
                    producto.Cantidad = miReader.GetDouble(4);
                    producto.Producto.ValorVentaProducto = miReader.GetDouble(12);
                    producto.Producto.ValorIva = miReader.GetDouble(13);
                    producto.Producto.Descuento = miReader.GetDouble(14);
                    productos.Add(producto);
                }
                miConexion.MiConexion.Close();
                miComando.Dispose();
                return productos;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al cargar los productos de la remisión\n" + ex.Message);
            }
            finally { miConexion.MiConexion.Close(); }
        }

        //editar_producto_remision_proveedor

        public void EditarProductoRemisionProveedor(ProductoFacturaProveedor producto)
        {
            try
            {
                CargarComando("editar_producto_remision_proveedor");
                if (producto.Lote.Id == 0)
                {
                    var daoLote = new DaoLote();
                    producto.Lote.Id = daoLote.IngresarLote(producto.Lote);
                }
                miComando.Parameters.AddWithValue("id", producto.Id);
                miComando.Parameters.AddWithValue("factura", producto.IdFactura);
                miComando.Parameters.AddWithValue("producto", producto.Producto.CodigoInternoProducto);
                miComando.Parameters.AddWithValue("medida", producto.Inventario.IdMedida);
                miComando.Parameters.AddWithValue("color", producto.Inventario.IdColor);
                miComando.Parameters.AddWithValue("lote", producto.Lote.Id);
                miComando.Parameters.AddWithValue("cantidad", producto.Cantidad);
                miComando.Parameters.AddWithValue("valor", producto.Producto.ValorVentaProducto);
                miComando.Parameters.AddWithValue("iva", producto.Producto.ValorIva);
                miComando.Parameters.AddWithValue("descuento", producto.Producto.Descuento);
                miConexion.MiConexion.Open();
                miComando.ExecuteNonQuery();
                miConexion.MiConexion.Close();
                miComando.Dispose();
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al editar el producto de la remisión.\n" + ex.Message);
            }
            finally { miConexion.MiConexion.Close(); }
        }

        public void EditarProductoRemisionProveedor(ProductoFacturaProveedor producto, bool actInventario)
        {
            try
            {
                //var miDaoInventario = new DaoInventario();
                CargarComando("editar_producto_remision_proveedor");
                if (producto.Lote.Id == 0)
                {
                    var daoLote = new DaoLote();
                    producto.Lote.Id = daoLote.IngresarLote(producto.Lote);
                }
                miComando.Parameters.AddWithValue("id", producto.Id);
                miComando.Parameters.AddWithValue("factura", producto.IdFactura);
                miComando.Parameters.AddWithValue("producto", producto.Producto.CodigoInternoProducto);
                miComando.Parameters.AddWithValue("medida", producto.Inventario.IdMedida);
                miComando.Parameters.AddWithValue("color", producto.Inventario.IdColor);
                miComando.Parameters.AddWithValue("lote", producto.Lote.Id);
                miComando.Parameters.AddWithValue("cantidad", producto.Cantidad);
                miComando.Parameters.AddWithValue("valor", producto.Producto.ValorVentaProducto);
                miComando.Parameters.AddWithValue("iva", producto.Producto.ValorIva);
                miComando.Parameters.AddWithValue("descuento", producto.Producto.Descuento);
                miConexion.MiConexion.Open();
                miComando.ExecuteNonQuery();
                miConexion.MiConexion.Close();
                miComando.Dispose();

                if (actInventario)
                {
                    miDaoInventario.ActualizarInventario(new Inventario
                    {
                        CodigoProducto = producto.Producto.CodigoInternoProducto,
                        IdMedida = producto.Inventario.IdMedida,
                        IdColor = producto.Inventario.IdColor,
                        Cantidad = producto.Inventario.Cantidad
                    }, true);
                    miDaoInventario.ActualizarInventario(new Inventario
                    {
                        CodigoProducto = producto.Producto.CodigoInternoProducto,
                        IdMedida = producto.Inventario.IdMedida,
                        IdColor = producto.Inventario.IdColor,
                        Cantidad = producto.Cantidad
                    }, false);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al editar el producto de la remisión.\n" + ex.Message);
            }
            finally { miConexion.MiConexion.Close(); }
        }

        public void EliminarProductoRemisionProveedor(int id)
        {
            try
            {
                CargarComando("eliminar_producto_remision_proveedor");
                miComando.Parameters.AddWithValue("id", id);
                miConexion.MiConexion.Open();
                miComando.ExecuteNonQuery();
                miConexion.MiConexion.Close();
                miComando.Dispose();
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al eliminar el producto de la remisión\n" + ex.Message);
            }
            finally { miConexion.MiConexion.Close(); }
        }

        // End Remision Proveedor


        //  Funciones para el ajuste de valores de IVA




        public void AjusteIvaVenta(DateTime fechaStop, DateTime fechaMonto, int monto)
        {
            //var monto = 0;
            try
            {
                //var fechasFacturas = FechasValores(fecha, fecha);

                FechasyTotalesVentas();
                FechasDeIva0();

                int cont = 0;

                foreach (var factura in FechasTotalesVentas)
                {

                    if (factura.FechaFactura != fechaStop)
                    {

                        var productosVenta19 = ProductosDeVenta(factura.FechaFactura);
                        /*var query = from item in productosVenta19
                                    //where item.Valor_Iva == 19
                                    group item by item.IdFactura into p
                                    orderby p.Key
                                    select new ProductoFacturaProveedor()
                                    {
                                        IdFactura = p.Key,
                                        Cantidad = p.Count()
                                    };*/

                        var queryMejor = from items in productosVenta19
                                         where items.Valor_Iva == 19
                                         group items by items.IdFactura into p_
                                         orderby p_.Key
                                         select new ProductoFacturaProveedor()
                                         {
                                             IdFactura = p_.Key,
                                             Cantidad =
                                             productosVenta19.Where(miP => miP.IdFactura.Equals(p_.Key)).Count()
                                         };


                        int count0 = 0, count5;         // Si al menos existe un registro de iva 0 o 5 no se edita ningun registro.
                        double ico = 0, icoSuma = 0;
                        foreach (var result in queryMejor)
                        {
                            ico = 0;
                            icoSuma = 0;
                            if (result.Cantidad > 1)
                            {
                                count0 = productosVenta19.Where(p => p.IdFactura.Equals(result.IdFactura) && p.Valor_Iva.Equals(0)).Count();
                                count5 = productosVenta19.Where(p => p.IdFactura.Equals(result.IdFactura) && p.Valor_Iva.Equals(5)).Count();
                                if (count0 != 0 || count5 != 0)         // Al menos tiene un registro de iva 0 o 5
                                {
                                    // eliminar registros de iva 19
                                    foreach (var rows19 in productosVenta19.Where(p => p.IdFactura.Equals(result.IdFactura) && p.Valor_Iva.Equals(19)))
                                    {
                                        /*var p = RegistroProductoVenta(rows19.Id);
                                        Console.WriteLine("1 Delete: " + rows19.Id + "  " + p.Valor_Iva);*/
                                        ico = ValidarImpoconsumo(rows19.Id);
                                        if (ico != 0)
                                        {
                                            icoSuma += ico;
                                        }
                                        DeleteProductoVenta(rows19.Id);
                                    }
                                    // ***  ojo actualizacion de impoconsumo - icoSuma
                                    if (icoSuma != 0)
                                    {
                                        ActualizarImpoconsumo(factura.FechaFactura, icoSuma);
                                    }
                                }
                                else
                                {
                                    // Tomo el primer ID del registro producto venta
                                    // Elimino los demas registros menos el que tome al inicio
                                    // Edito los valores del Id del registro que tome. cod_producto, cant, valor,

                                    var QidsFact = productosVenta19.Where(p => p.IdFactura.Equals(result.IdFactura));
                                    int idNoDelet = QidsFact.First().Id;
                                    foreach (var id_p in QidsFact)
                                    {
                                        if (id_p.Id != idNoDelet)
                                        {
                                            ico = ValidarImpoconsumo(id_p.Id);
                                            if (ico != 0)
                                            {
                                                icoSuma += ico;
                                            }

                                            // Elimino el registro
                                            DeleteProductoVenta(id_p.Id);

                                            /*var p = RegistroProductoVenta(id_p.Id);
                                            Console.WriteLine("2 Delete: " + id_p.Id + "  " + p.Valor_Iva);*/
                                        }
                                        // ***  ojo actualizacion de impoconsumo - icoSuma
                                        if (icoSuma != 0)
                                        {
                                            ActualizarImpoconsumo(factura.FechaFactura, icoSuma);
                                        }
                                    }
                                    var productEdit = RegProductoEdit0(factura.FechaFactura);

                                    //  **  ojo validacion de impoconsumo en row19, si tiene hay que salvarlo
                                    ico = ValidarImpoconsumo(idNoDelet);
                                    if (ico != 0)
                                    {
                                        ActualizarImpoconsumo(factura.FechaFactura, ico);
                                    }

                                    UpdateRegProductoIva0(idNoDelet, productEdit.Producto.CodigoInternoProducto, productEdit.Cantidad, productEdit.Valor, productEdit.Costo);
                                       //var QidsFirst = QidsFact.First();
                                    /*var p_ = RegistroProductoVenta(idNoDelet);
                                    Console.WriteLine("1 Update: " + p_.Id + "  " + p_.Valor_Iva);*/
                                    cont++;
                                }
                                /*var QidsFact = productosVenta19.Where(p => p.IdFactura.Equals(result.IdFactura));
                                int idNoDelet = QidsFact.First().IdFactura;*/

                            }
                            else
                            {
                                var productEdit = RegProductoEdit0(factura.FechaFactura);
                                foreach (var product_ in ProductosDeVentaIvaTodos(result.IdFactura))
                                {
                                    //  **  ojo validacion de impoconsumo en row19, si tiene hay que salvarlo
                                    ico = ValidarImpoconsumo(product_.Id);
                                    if (ico != 0)
                                    {
                                        ActualizarImpoconsumo(factura.FechaFactura, ico);
                                    }

                                    UpdateRegProductoIva0(product_.Id, productEdit.Producto.CodigoInternoProducto, productEdit.Cantidad, productEdit.Valor, productEdit.Costo);
                                    /*var p_ = RegistroProductoVenta(product_.Id);
                                    Console.WriteLine("2 Update: " + p_.Id + "  " + p_.Valor_Iva);*/
                                    cont++;
                                }
                            }

                            //  Validación para monto
                            
                            /**if (monto != 0)
                            {
                                if (factura.FechaFactura == fechaMonto)
                                {
                                    if (TotalIva19(factura.FechaFactura) < monto)
                                    {
                                        break;
                                    }
                                }
                            }*/

                            /*
                            if (cont == 20)
                            {
                                var c = cont;
                            }
                            if (cont == 40)
                            {
                                var c = cont;
                            }
                            if (cont == 60)
                            {
                                var c = cont;
                            }
                            if (cont == 80)
                            {
                                var c = cont;
                            }
                            if (cont == 100)
                            {
                                var c = cont;
                            }
                            if (cont == 120)
                            {
                                var c = cont;
                            }

                            if (cont == 150)
                            {
                                var c = cont;
                            }
                            if (cont == 170)
                            {
                                var c = cont;
                            }
                            if (cont == 190)
                            {
                                var c = cont;
                            }
                            if (cont == 210)
                            {
                                var c = cont;
                            }

                            if (cont == 230)
                            {
                                var c = cont;
                            }
                            if (cont == 250)
                            {
                                var c = cont;
                            }*/
                        }

                        //fecha = fecha.AddDays(1);

                    }  //  fin if
                    else
                    {
                        break;
                    }

                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

       /* public void AjusteIvaVenta(DateTime fecha, DateTime fecha2, int monto)
        {
            //var monto = 0;
            try
            {
                //var fechasFacturas = FechasValores(fecha, fecha);

                int cont = 0;

                while (fecha != fecha2)
                {

                    var productosVenta19 = ProductosDeVenta(fecha);
                    var query = from item in productosVenta19
                                where item.Valor_Iva == 19
                                group item by item.IdFactura into p
                                orderby p.Key
                                select new ProductoFacturaProveedor()
                                {
                                    IdFactura = p.Key,
                                    Cantidad = p.Count()
                                };
                    int count0 = 0, count5;         // Si al menos existe un registro de iva 0 o 5 no se edita ningun registro.
                    foreach (var result in query)
                    {

                        if (result.Cantidad > 1)
                        {
                            count0 = productosVenta19.Where(p => p.IdFactura.Equals(result.IdFactura) && p.Valor_Iva.Equals(0)).Count();
                            count5 = productosVenta19.Where(p => p.IdFactura.Equals(result.IdFactura) && p.Valor_Iva.Equals(5)).Count();
                            if (count0 != 0 || count5 != 0)         // Al menos tiene un registro de iva 0 o 5
                            {
                                // eliminar registros de iva 19
                                foreach (var rows19 in productosVenta19.Where(p => p.IdFactura.Equals(result.IdFactura) && p.Valor_Iva.Equals(19)))
                                {
                                    DeleteProductoVenta(rows19.Id);
                                }
                            }
                            else
                            {
                                // Tomo el primer ID del registro producto venta
                                // Elimino los demas registros meno el que tome al inicio
                                // Edito los valores del Id del registro que tome. cod_producto, cant, valor,

                                var QidsFact = productosVenta19.Where(p => p.IdFactura.Equals(result.IdFactura));
                                int idNoDelet = QidsFact.First().Id;
                                foreach (var id_p in QidsFact)
                                {
                                    if (id_p.Id != idNoDelet)
                                    {
                                        // Elimino el registro
                                        DeleteProductoVenta(id_p.Id);
                                    }
                                }
                                var productEdit = RegProductoEdit0(fecha);
                                UpdateRegProductoIva0(idNoDelet, productEdit.Producto.CodigoInternoProducto, productEdit.Cantidad, productEdit.Valor);
                                cont++;
                            }
                            //var QidsFact = productosVenta19.Where(p => p.IdFactura.Equals(result.IdFactura));
                            //int idNoDelet = QidsFact.First().IdFactura;

                        }
                        else
                        {
                            var productEdit = RegProductoEdit0(fecha);
                            foreach (var product_ in ProductosDeVentaIvaTodos(result.IdFactura))
                            {
                                UpdateRegProductoIva0(product_.Id, productEdit.Producto.CodigoInternoProducto, productEdit.Cantidad, productEdit.Valor);
                                cont++;
                            }
                        }

                        //  Validación para monto
                        if (monto != 0)
                        {
                            if (TotalIva19(fecha) < monto)
                            {
                                break;
                            }
                        }

                    }

                    fecha = fecha.AddDays(1);

                }  //  fin while

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }*/

        public void AjusteIvaVenta_old(DateTime fecha, DateTime fecha2, int monto)
        {
            //var monto = 0;
            try
            {
                //var fechasFacturas = FechasValores(fecha, fecha);

                int cont = 0;
                var productosVenta19 = ProductosDeVenta(fecha);
                var query = from item in productosVenta19 
                            where item.Valor_Iva == 19 
                            group item by item.IdFactura into p orderby p.Key 
                            select new ProductoFacturaProveedor()
                            {
                                IdFactura = p.Key,
                                Cantidad = p.Count()
                            };
                int count0 = 0, count5;         // Si al menos existe un registro de iva 0 o 5 no se edita ningun registro.
                foreach (var result in query)
                {

                    if (result.Cantidad > 1)
                    {
                        count0 = productosVenta19.Where(p => p.IdFactura.Equals(result.IdFactura) && p.Valor_Iva.Equals(0)).Count();
                        count5 = productosVenta19.Where(p => p.IdFactura.Equals(result.IdFactura) && p.Valor_Iva.Equals(5)).Count();
                        if (count0 != 0 || count5 != 0)         // Al menos tiene un registro de iva 0 o 5
                        {
                            // eliminar registros de iva 19
                            foreach (var rows19 in productosVenta19.Where(p => p.IdFactura.Equals(result.IdFactura) && p.Valor_Iva.Equals(19)))
                            {
                                DeleteProductoVenta(rows19.Id);
                            }
                        }
                        else
                        {
                            // Tomo el primer ID del registro producto venta
                            // Elimino los demas registros meno el que tome al inicio
                            // Edito los valores del Id del registro que tome. cod_producto, cant, valor,

                            var QidsFact = productosVenta19.Where(p => p.IdFactura.Equals(result.IdFactura));
                            int idNoDelet = QidsFact.First().Id;
                            foreach (var id_p in QidsFact)
                            {
                                if (id_p.Id != idNoDelet)
                                {
                                    // Elimino el registro
                                    DeleteProductoVenta(id_p.Id);
                                }
                            }
                            var productEdit = RegProductoEdit0(fecha);
                            UpdateRegProductoIva0(idNoDelet, productEdit.Producto.CodigoInternoProducto, productEdit.Cantidad, productEdit.Valor, productEdit.Costo);
                            cont++;
                        }
                        /*var QidsFact = productosVenta19.Where(p => p.IdFactura.Equals(result.IdFactura));
                        int idNoDelet = QidsFact.First().IdFactura;*/

                    }
                    else
                    {
                        var productEdit = RegProductoEdit0(fecha);
                        foreach (var product_ in ProductosDeVentaIvaTodos(result.IdFactura))
                        {
                            UpdateRegProductoIva0(product_.Id, productEdit.Producto.CodigoInternoProducto, productEdit.Cantidad, productEdit.Valor, productEdit.Costo);
                            cont++;
                        }
                    }

                    //  Validación para monto
                    if (monto != 0)
                    {
                        if (TotalIva19(fecha) < monto)
                        {
                            break;
                        }
                    }


                    if (cont == 20)
                    {
                        var c = cont;
                    }
                    if (cont == 40)
                    {
                        var c = cont;
                    }
                    if (cont == 60)
                    {
                        var c = cont;
                    }
                    if (cont == 80)
                    {
                        var c = cont;
                    }
                    if (cont == 100)
                    {
                        var c = cont;
                    }
                    if (cont == 120)
                    {
                        var c = cont;
                    }

                    if (cont == 150)
                    {
                        var c = cont;
                    }
                    if (cont == 170)
                    {
                        var c = cont;
                    }
                    if (cont == 190)
                    {
                        var c = cont;
                    }
                    if (cont == 210)
                    {
                        var c = cont;
                    }

                    if (cont == 230)
                    {
                        var c = cont;
                    }
                    if (cont == 250)
                    {
                        var c = cont;
                    }
                }



                /*foreach (var p in productosVenta19)
                {
                    var productEdit = RegProductoEdit0(fecha);
                    UpdateRegProductoIva0(p.Id, productEdit.Cantidad, productEdit.Valor);
                    cont++;

                    if (cont == 20)
                    {
                        var c = cont;
                    }
                    if (cont == 40)
                    {
                        var c = cont;
                    }
                    if (cont == 60)
                    {
                        var c = cont;
                    }
                    if (cont == 80)
                    {
                        var c = cont;
                    }
                    if (cont == 100)
                    {
                        var c = cont;
                    }
                    if (cont == 120)
                    {
                        var c = cont;
                    }

                    if (cont == 150)
                    {
                        var c = cont;
                    }
                    if (cont == 170)
                    {
                        var c = cont;
                    }
                    if (cont == 190)
                    {
                        var c = cont;
                    }
                    if (cont == 210)
                    {
                        var c = cont;
                    }

                    if (cont == 230)
                    {
                        var c = cont;
                    }
                    if (cont == 250)
                    {
                        var c = cont;
                    }
                }*/
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private ProductoFacturaProveedor RegistroProductoVenta(int id)
        {
            try
            {
                string sql = "SELECT producto_factura_venta.idproducto_factura_venta , producto_factura_venta.id_factura, producto_factura_venta.cantidadproducto_factura_venta , " +
                  "producto_factura_venta.valorunitarioproducto_factura_venta , producto_factura_venta.valor_iva FROM producto_factura_venta WHERE " +
                  "producto_factura_venta.idproducto_factura_venta = " + id + ";";
                miComando = new NpgsqlCommand();
                miComando.Connection = miConexion.MiConexion;
                miComando.CommandType = CommandType.Text;
                miComando.CommandText = sql;
                miComando.CommandTimeout = 0;
                miConexion.MiConexion.Open();
                NpgsqlDataReader reader = miComando.ExecuteReader();
                var p = new ProductoFacturaProveedor();
                while (reader.Read())
                {
                    p.Id = reader.GetInt32(0);
                    p.IdFactura = reader.GetInt32(1);
                    p.Cantidad = reader.GetDouble(2); 
                    p.Valor = reader.GetDouble(3);
                    p.Valor_Iva = reader.GetDouble(4);
                }
                miConexion.MiConexion.Close();
                miComando.Dispose();
                return p;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally { miConexion.MiConexion.Close(); }
        }




        private List<FacturaVenta> FechasTotalesVentas = new List<DTO.Clases.FacturaVenta>();

        private List<FacturaVenta> FechasIva0 = new List<DTO.Clases.FacturaVenta>();

        // Conjunto de valores y fechas a recorrer
        public void FechasyTotalesVentas(DateTime fecha, DateTime fecha2)
        {
            try
            {
                string sql = "SELECT factura_venta.fecha_factura_venta AS fecha, mi_round(SUM(producto_factura_venta.cantidadproducto_factura_venta * " +
                   "producto_factura_venta.valorunitarioproducto_factura_venta), 1) AS base_ FROM factura_venta, producto_factura_venta " +
                   "WHERE factura_venta.nitcliente = '1000' AND factura_venta.id = producto_factura_venta.id_factura AND " +
                   "factura_venta.fecha_factura_venta BETWEEN '" + fecha.ToShortDateString() + "' AND '" + fecha2.ToShortDateString() + "' AND " +
                   "factura_venta.idestado = 1 AND factura_venta.estado = true AND producto_factura_venta.valor_iva = 19 AND producto_factura_venta.retorno = false " +
                   "GROUP BY factura_venta.fecha_factura_venta ORDER BY mi_round(SUM(producto_factura_venta.cantidadproducto_factura_venta * " +
                   "producto_factura_venta.valorunitarioproducto_factura_venta), 1) DESC ";

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
                    factura.FechaFactura = reader.GetDateTime(0);
                    factura.Ajuste = Convert.ToDouble(reader.GetDecimal(1));
                    FechasTotalesVentas.Add(factura);
                }
                miConexion.MiConexion.Close();
                miComando.Dispose();
                //return FechasTotalesVentas;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally { miConexion.MiConexion.Close(); }
        }

        public void FechasyTotalesVentas()
        {
            FechasTotalesVentas.Add(new FacturaVenta { FechaFactura = new DateTime(2020, 5, 25), Ajuste = 332688 });
            FechasTotalesVentas.Add(new FacturaVenta { FechaFactura = new DateTime(2020, 5, 26), Ajuste = 437729 });
            FechasTotalesVentas.Add(new FacturaVenta { FechaFactura = new DateTime(2020, 5, 12), Ajuste = 332688 });
            FechasTotalesVentas.Add(new FacturaVenta { FechaFactura = new DateTime(2020, 5, 19), Ajuste = 332688 });
            FechasTotalesVentas.Add(new FacturaVenta { FechaFactura = new DateTime(2020, 5, 21), Ajuste = 332688 });
            FechasTotalesVentas.Add(new FacturaVenta { FechaFactura = new DateTime(2020, 5, 27), Ajuste = 332688 });

        }

        public void FechasDeIva0()
        {
            FechasIva0.Add(new FacturaVenta { FechaFactura = new DateTime(2020, 5, 25), Ajuste = 332688 });
            FechasIva0.Add(new FacturaVenta { FechaFactura = new DateTime(2020, 5, 26), Ajuste = 437729 });
            FechasIva0.Add(new FacturaVenta { FechaFactura = new DateTime(2020, 5, 12), Ajuste = 332688 });
            FechasIva0.Add(new FacturaVenta { FechaFactura = new DateTime(2020, 5, 19), Ajuste = 332688 });
            FechasIva0.Add(new FacturaVenta { FechaFactura = new DateTime(2020, 5, 21), Ajuste = 332688 });
            FechasIva0.Add(new FacturaVenta { FechaFactura = new DateTime(2020, 5, 21), Ajuste = 332688 });
            FechasIva0.Add(new FacturaVenta { FechaFactura = new DateTime(2020, 5, 27), Ajuste = 332688 });

            FechasIva0.Add(new FacturaVenta { FechaFactura = new DateTime(2020, 5, 18), Ajuste = 332688 });
            FechasIva0.Add(new FacturaVenta { FechaFactura = new DateTime(2020, 5, 20), Ajuste = 437729 });
            FechasIva0.Add(new FacturaVenta { FechaFactura = new DateTime(2020, 5, 22), Ajuste = 332688 });
            FechasIva0.Add(new FacturaVenta { FechaFactura = new DateTime(2020, 5, 13), Ajuste = 332688 });
            FechasIva0.Add(new FacturaVenta { FechaFactura = new DateTime(2020, 5, 11), Ajuste = 332688 });
            FechasIva0.Add(new FacturaVenta { FechaFactura = new DateTime(2020, 5, 15), Ajuste = 332688 });
            FechasIva0.Add(new FacturaVenta { FechaFactura = new DateTime(2020, 5, 14), Ajuste = 332688 });

        }


        public void FechasyTotalesVentasJunio()
        {
            FechasTotalesVentas.Add(new FacturaVenta { FechaFactura = new DateTime(2020, 6, 23), Ajuste = 332688 });
            FechasTotalesVentas.Add(new FacturaVenta { FechaFactura = new DateTime(2020, 6, 24), Ajuste = 437729 });
            FechasTotalesVentas.Add(new FacturaVenta { FechaFactura = new DateTime(2020, 6, 15), Ajuste = 332688 });
            FechasTotalesVentas.Add(new FacturaVenta { FechaFactura = new DateTime(2020, 6, 18), Ajuste = 332688 });
            FechasTotalesVentas.Add(new FacturaVenta { FechaFactura = new DateTime(2020, 6, 22), Ajuste = 332688 });
            FechasTotalesVentas.Add(new FacturaVenta { FechaFactura = new DateTime(2020, 6, 25), Ajuste = 332688 });
            FechasTotalesVentas.Add(new FacturaVenta { FechaFactura = new DateTime(2020, 6, 29), Ajuste = 332688 });
        }

        public void FechasDeIva0Junio()
        {
            FechasIva0.Add(new FacturaVenta { FechaFactura = new DateTime(2020, 6, 23), Ajuste = 332688 });
            FechasIva0.Add(new FacturaVenta { FechaFactura = new DateTime(2020, 6, 24), Ajuste = 437729 });
            FechasIva0.Add(new FacturaVenta { FechaFactura = new DateTime(2020, 6, 15), Ajuste = 332688 });
            FechasIva0.Add(new FacturaVenta { FechaFactura = new DateTime(2020, 6, 18), Ajuste = 332688 });
            FechasIva0.Add(new FacturaVenta { FechaFactura = new DateTime(2020, 6, 22), Ajuste = 332688 });
            FechasIva0.Add(new FacturaVenta { FechaFactura = new DateTime(2020, 6, 25), Ajuste = 332688 });
            FechasIva0.Add(new FacturaVenta { FechaFactura = new DateTime(2020, 6, 29), Ajuste = 332688 });

            FechasIva0.Add(new FacturaVenta { FechaFactura = new DateTime(2020, 6, 9), Ajuste = 332688 });
            FechasIva0.Add(new FacturaVenta { FechaFactura = new DateTime(2020, 6, 8), Ajuste = 437729 });
            FechasIva0.Add(new FacturaVenta { FechaFactura = new DateTime(2020, 6, 12), Ajuste = 332688 });
            FechasIva0.Add(new FacturaVenta { FechaFactura = new DateTime(2020, 6, 10), Ajuste = 332688 });
            FechasIva0.Add(new FacturaVenta { FechaFactura = new DateTime(2020, 6, 30), Ajuste = 332688 });
            FechasIva0.Add(new FacturaVenta { FechaFactura = new DateTime(2020, 6, 16), Ajuste = 332688 });
            FechasIva0.Add(new FacturaVenta { FechaFactura = new DateTime(2020, 6, 4), Ajuste = 332688 });
        }


        public void FechasyTotalesVentasJulio()
        {
            FechasTotalesVentas.Add(new FacturaVenta { FechaFactura = new DateTime(2020, 7, 22), Ajuste = 332688 });
            FechasTotalesVentas.Add(new FacturaVenta { FechaFactura = new DateTime(2020, 7, 10), Ajuste = 437729 });
            FechasTotalesVentas.Add(new FacturaVenta { FechaFactura = new DateTime(2020, 7, 16), Ajuste = 332688 });
            FechasTotalesVentas.Add(new FacturaVenta { FechaFactura = new DateTime(2020, 7, 21), Ajuste = 332688 });
            FechasTotalesVentas.Add(new FacturaVenta { FechaFactura = new DateTime(2020, 7, 28), Ajuste = 332688 });
            FechasTotalesVentas.Add(new FacturaVenta { FechaFactura = new DateTime(2020, 7, 24), Ajuste = 332688 });
            FechasTotalesVentas.Add(new FacturaVenta { FechaFactura = new DateTime(2020, 7, 9), Ajuste = 332688 });
        }

        public void FechasDeIva0Julio()
        {
            FechasIva0.Add(new FacturaVenta { FechaFactura = new DateTime(2020, 7, 22), Ajuste = 332688 });
            FechasIva0.Add(new FacturaVenta { FechaFactura = new DateTime(2020, 7, 10), Ajuste = 437729 });
            FechasIva0.Add(new FacturaVenta { FechaFactura = new DateTime(2020, 7, 16), Ajuste = 332688 });
            FechasIva0.Add(new FacturaVenta { FechaFactura = new DateTime(2020, 7, 21), Ajuste = 332688 });
            FechasIva0.Add(new FacturaVenta { FechaFactura = new DateTime(2020, 7, 28), Ajuste = 332688 });
            FechasIva0.Add(new FacturaVenta { FechaFactura = new DateTime(2020, 7, 24), Ajuste = 332688 });
            FechasIva0.Add(new FacturaVenta { FechaFactura = new DateTime(2020, 7, 9), Ajuste = 332688 });

            FechasIva0.Add(new FacturaVenta { FechaFactura = new DateTime(2020, 7, 2), Ajuste = 332688 });
            FechasIva0.Add(new FacturaVenta { FechaFactura = new DateTime(2020, 7, 6), Ajuste = 437729 });
            FechasIva0.Add(new FacturaVenta { FechaFactura = new DateTime(2020, 7, 23), Ajuste = 332688 });
            FechasIva0.Add(new FacturaVenta { FechaFactura = new DateTime(2020, 7, 15), Ajuste = 332688 });
            FechasIva0.Add(new FacturaVenta { FechaFactura = new DateTime(2020, 7, 31), Ajuste = 332688 });
            FechasIva0.Add(new FacturaVenta { FechaFactura = new DateTime(2020, 7, 29), Ajuste = 332688 });
            FechasIva0.Add(new FacturaVenta { FechaFactura = new DateTime(2020, 7, 30), Ajuste = 332688 });
        }


        public void FechasyTotalesVentasAgosto()
        {
            FechasTotalesVentas.Add(new FacturaVenta { FechaFactura = new DateTime(2020, 8, 14), Ajuste = 332688 });
            FechasTotalesVentas.Add(new FacturaVenta { FechaFactura = new DateTime(2020, 8, 26), Ajuste = 437729 });
            FechasTotalesVentas.Add(new FacturaVenta { FechaFactura = new DateTime(2020, 8, 17), Ajuste = 332688 });
            FechasTotalesVentas.Add(new FacturaVenta { FechaFactura = new DateTime(2020, 8, 18), Ajuste = 332688 });
            FechasTotalesVentas.Add(new FacturaVenta { FechaFactura = new DateTime(2020, 8, 13), Ajuste = 332688 });
            FechasTotalesVentas.Add(new FacturaVenta { FechaFactura = new DateTime(2020, 8, 3), Ajuste = 332688 });
            FechasTotalesVentas.Add(new FacturaVenta { FechaFactura = new DateTime(2020, 8, 7), Ajuste = 332688 });
            FechasTotalesVentas.Add(new FacturaVenta { FechaFactura = new DateTime(2020, 8, 24), Ajuste = 332688 });
            FechasTotalesVentas.Add(new FacturaVenta { FechaFactura = new DateTime(2020, 8, 31), Ajuste = 332688 });
            FechasTotalesVentas.Add(new FacturaVenta { FechaFactura = new DateTime(2020, 8, 19), Ajuste = 332688 });
        }

        public void FechasDeIva0Agosto()
        {
            FechasIva0.Add(new FacturaVenta { FechaFactura = new DateTime(2020, 8, 14), Ajuste = 332688 });
            FechasIva0.Add(new FacturaVenta { FechaFactura = new DateTime(2020, 8, 26), Ajuste = 437729 });
            FechasIva0.Add(new FacturaVenta { FechaFactura = new DateTime(2020, 8, 17), Ajuste = 332688 });
            FechasIva0.Add(new FacturaVenta { FechaFactura = new DateTime(2020, 8, 18), Ajuste = 332688 });
            FechasIva0.Add(new FacturaVenta { FechaFactura = new DateTime(2020, 8, 13), Ajuste = 332688 });
            FechasIva0.Add(new FacturaVenta { FechaFactura = new DateTime(2020, 8, 3), Ajuste = 332688 });
            FechasIva0.Add(new FacturaVenta { FechaFactura = new DateTime(2020, 8, 7), Ajuste = 332688 });
            FechasIva0.Add(new FacturaVenta { FechaFactura = new DateTime(2020, 8, 24), Ajuste = 332688 });
            FechasIva0.Add(new FacturaVenta { FechaFactura = new DateTime(2020, 8, 31), Ajuste = 332688 });
            FechasIva0.Add(new FacturaVenta { FechaFactura = new DateTime(2020, 8, 19), Ajuste = 332688 });

            FechasIva0.Add(new FacturaVenta { FechaFactura = new DateTime(2020, 8, 10), Ajuste = 332688 });
            FechasIva0.Add(new FacturaVenta { FechaFactura = new DateTime(2020, 8, 6), Ajuste = 437729 });
            FechasIva0.Add(new FacturaVenta { FechaFactura = new DateTime(2020, 8, 5), Ajuste = 332688 });
            FechasIva0.Add(new FacturaVenta { FechaFactura = new DateTime(2020, 8, 22), Ajuste = 332688 });
            FechasIva0.Add(new FacturaVenta { FechaFactura = new DateTime(2020, 8, 15), Ajuste = 332688 });
            FechasIva0.Add(new FacturaVenta { FechaFactura = new DateTime(2020, 8, 12), Ajuste = 332688 });
            FechasIva0.Add(new FacturaVenta { FechaFactura = new DateTime(2020, 8, 29), Ajuste = 332688 });
        }


        public List<ProductoFacturaProveedor> ProductosDeVenta(DateTime fecha)
        {
            try
            {
                var productosVenta = new List<ProductoFacturaProveedor>();

                /* SQL cuando se filtra por iva tambien...
                 * string sql = "SELECT producto_factura_venta.idproducto_factura_venta, producto_factura_venta.id_factura, producto_factura_venta.cantidadproducto_factura_venta, " +
                "producto_factura_venta.valorunitarioproducto_factura_venta FROM factura_venta, producto_factura_venta WHERE factura_venta.id = producto_factura_venta.id_factura AND " +
                "factura_venta.nitcliente = '1000' AND factura_venta.fecha_factura_venta = '" + fecha.ToShortDateString() + "' AND factura_venta.idestado = 1 AND " +
                "factura_venta.estado = true AND producto_factura_venta.valor_iva = " + iva + " AND producto_factura_venta.retorno = false ORDER BY factura_venta.id ASC;";*/

                string sql = "SELECT producto_factura_venta.idproducto_factura_venta, producto_factura_venta.id_factura, producto_factura_venta.cantidadproducto_factura_venta, " +
                   "producto_factura_venta.valorunitarioproducto_factura_venta, producto_factura_venta.valor_iva FROM factura_venta, producto_factura_venta " +
                   "WHERE factura_venta.id = producto_factura_venta.id_factura AND factura_venta.nitcliente = '1000' AND " +
                   "factura_venta.fecha_factura_venta = '" + fecha.ToShortDateString() + "' AND factura_venta.idestado = 1 AND factura_venta.estado = true AND  " +
                   "producto_factura_venta.retorno = false AND producto_factura_venta.impoconsumo = 0  ORDER BY factura_venta.id ASC;";
                
                miComando = new NpgsqlCommand();
                miComando.Connection = miConexion.MiConexion;
                miComando.CommandType = CommandType.Text;
                miComando.CommandText = sql;
                miComando.CommandTimeout = 0;
                miConexion.MiConexion.Open();
                NpgsqlDataReader reader = miComando.ExecuteReader();
                while (reader.Read())
                {
                    var p = new ProductoFacturaProveedor();
                    p.Id = reader.GetInt32(0);
                    p.IdFactura = reader.GetInt32(1);
                    p.Cantidad = reader.GetDouble(2);
                    p.Valor = reader.GetDouble(3);
                    p.Valor_Iva = reader.GetDouble(4);
                    productosVenta.Add(p);
                }
                miConexion.MiConexion.Close();
                miComando.Dispose();
                return productosVenta;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally { miConexion.MiConexion.Close(); }
        }




        public ProductoFacturaProveedor RegProductoEdit0(DateTime fecha)
        {
            try
            {
                ProductoFacturaProveedor productEdit = new ProductoFacturaProveedor();
                
                //foreach (var fechaTotalVenta in FechasTotalesVentas)
                foreach (var fechaTotalVenta in FechasIva0)
                {
                    if (fechaTotalVenta.FechaFactura != fecha)
                    {
                        if (ExisteRegistro0(fechaTotalVenta.FechaFactura))
                        {
                            double cant_edit_0 = 0;
                            double cant_div = 0;

                            List<ProductoFacturaProveedor> products = new List<DTO.Clases.ProductoFacturaProveedor>();

                            var idsFacturas = IdsFacturasVenta(fechaTotalVenta.FechaFactura, 0);
                            foreach (int id in idsFacturas)
                            {
                                products = ProductosDeVenta(id);
                                foreach (var p in products)
                                {
                                    /* if (p.IdFactura == 141403)
                                     {
                                         var c = p.Cantidad;
                                     }*/
                                    productEdit.Id = p.Id;
                                    productEdit.IdFactura = p.IdFactura;
                                    productEdit.Producto.CodigoInternoProducto = p.Producto.CodigoInternoProducto;
                                    productEdit.Valor = p.Valor;
                                    productEdit.Producto.CantidadDecimal = p.Producto.CantidadDecimal;
                                    productEdit.Costo = p.Costo;

                                    if (p.Producto.CantidadDecimal)                 // cantidad puede ser decimal
                                    {
                                        if (p.Cantidad >= 2)        // cantidad mayor e igual a 2
                                        {
                                            cant_edit_0 = p.Cantidad - 0.4;
                                            productEdit.Cantidad = 0.4;
                                            // update producto_venta cantidad = cant_edit_0
                                            UpdateRegProductoIva0(p.Id, cant_edit_0);
                                            break;
                                        }
                                        else                      /// cantidad menor a 2
                                        {
                                            if (p.Cantidad >= 0.8)
                                            {
                                                if (p.Cantidad >= 0.8 && p.Cantidad < 1.2)  // divide entre 2
                                                {
                                                    cant_div = Math.Round((p.Cantidad / 2), 3);
                                                }
                                                else
                                                {
                                                    if (p.Cantidad >= 1.2 && p.Cantidad < 1.6)   // divide entre 3
                                                    {
                                                        cant_div = Math.Round((p.Cantidad / 3), 3);
                                                    }
                                                    else
                                                    {
                                                        if (p.Cantidad >= 1.6 && p.Cantidad < 2)  // divide entre 4
                                                        {
                                                            cant_div = Math.Round((p.Cantidad / 4), 3);
                                                        }
                                                    }
                                                }
                                                productEdit.Cantidad = cant_div;
                                                // update producto_venta cantidad = (p.Cantidad - cant_div)
                                                UpdateRegProductoIva0(p.Id, (p.Cantidad - cant_div));
                                                break;
                                            }
                                        }
                                    }
                                    else                      // cantidad no puede ser decimal
                                    {
                                        if (p.Cantidad > 1)
                                        {
                                            cant_edit_0 = p.Cantidad - 1;
                                            productEdit.Cantidad = 1;
                                            // update producto_venta cantidad = cant_edit_0;
                                            UpdateRegProductoIva0(p.Id, cant_edit_0);
                                            break;
                                        }
                                    }

                                }
                                if (productEdit.Cantidad != 0)
                                {
                                    break;
                                }
                            }
                        }
                        if (productEdit.Cantidad != 0)
                        {
                            break;
                        }
                    }

                }

                return productEdit;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        private bool ExisteRegistro0(DateTime fecha)
        {
            if (CountCantDecimal(fecha) > 0 || CountCantNoDecimal(fecha) > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private int CountCantDecimal(DateTime fecha)
        {
            try
            {
                string sql = "SELECT COUNT(factura_venta.id) FROM factura_venta, producto_factura_venta, producto  WHERE factura_venta.id = producto_factura_venta.id_factura AND " +
                   "producto.codigointernoproducto = producto_factura_venta.codigointernoproducto AND factura_venta.nitcliente = '1000' AND " +
                   "factura_venta.fecha_factura_venta = '" + fecha.ToShortDateString() + "' AND factura_venta.idestado = 1 AND factura_venta.estado = true AND producto_factura_venta.valor_iva = 0 AND  " +
                   "producto_factura_venta.retorno = false AND producto_factura_venta.cantidadproducto_factura_venta > 0.8 AND producto.cantidad_decimal = TRUE;";
                miComando = new NpgsqlCommand();
                miComando.Connection = miConexion.MiConexion;
                miComando.CommandType = CommandType.Text;
                miComando.CommandText = sql;
                miComando.CommandTimeout = 0;
                miConexion.MiConexion.Open();
                int count = Convert.ToInt32(miComando.ExecuteScalar());
                miConexion.MiConexion.Close();
                miComando.Dispose();
                return count;
            }
            catch (InvalidCastException)
            {
                return 0;
            }
            finally { miConexion.MiConexion.Close(); }
        }

        private int CountCantNoDecimal(DateTime fecha)
        {
            try
            {
                string sql = "SELECT COUNT(factura_venta.id) FROM factura_venta, producto_factura_venta, producto WHERE factura_venta.id = producto_factura_venta.id_factura AND " +
                  "producto.codigointernoproducto = producto_factura_venta.codigointernoproducto AND  factura_venta.nitcliente = '1000' AND " +
                  "factura_venta.fecha_factura_venta = '" + fecha.ToShortDateString() + "' AND factura_venta.idestado = 1 AND factura_venta.estado = true AND " +
                  "producto_factura_venta.valor_iva = 0 AND producto_factura_venta.retorno = false AND producto_factura_venta.cantidadproducto_factura_venta > 1 " +
                  "AND producto.cantidad_decimal = FALSE;";
                miComando = new NpgsqlCommand();
                miComando.Connection = miConexion.MiConexion;
                miComando.CommandType = CommandType.Text;
                miComando.CommandText = sql;
                miComando.CommandTimeout = 0;
                miConexion.MiConexion.Open();
                int count = Convert.ToInt32(miComando.ExecuteScalar());
                miConexion.MiConexion.Close();
                miComando.Dispose();
                return count;
            }
            catch (InvalidCastException)
            {
                return 0;
            }
            finally { miConexion.MiConexion.Close(); }
        }

        public List<ProductoFacturaProveedor> CantidadesProductosVenta(DateTime fecha, int iva)
        {
            try
            {
                var productosVenta = new List<ProductoFacturaProveedor>();
                string sql = "SELECT factura_venta.id AS id_factura, COUNT(producto_factura_venta.idproducto_factura_venta) AS num_productos , " +
                "SUM(producto_factura_venta.cantidadproducto_factura_venta) AS cantidad FROM factura_venta, producto_factura_venta WHERE factura_venta.id = producto_factura_venta.id_factura AND " +
                "factura_venta.nitcliente = '1000' AND factura_venta.fecha_factura_venta = '" + fecha.ToShortDateString() + "' AND factura_venta.idestado = 1 AND " +
                "factura_venta.estado = true AND producto_factura_venta.valor_iva = " + iva + " AND  producto_factura_venta.retorno = false GROUP BY factura_venta.id ORDER BY " +
                " factura_venta.id ASC;";
                miComando = new NpgsqlCommand();
                miComando.Connection = miConexion.MiConexion;
                miComando.CommandType = CommandType.Text;
                miComando.CommandText = sql;
                miComando.CommandTimeout = 0;
                miConexion.MiConexion.Open();
                NpgsqlDataReader reader = miComando.ExecuteReader();
                while (reader.Read())
                {
                    var p = new ProductoFacturaProveedor();
                    p.IdFactura = reader.GetInt32(0);
                    p.Valor = reader.GetDouble(1);      // num_productos
                    p.Cantidad = reader.GetDouble(2);   // cantidad
                    productosVenta.Add(p);
                }
                miConexion.MiConexion.Close();
                miComando.Dispose();
                return productosVenta;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally { miConexion.MiConexion.Close(); }
        }


        private List<int> IdsFacturasVenta(DateTime fecha, int iva)
        {
            try
            {
                var ids = new List<int>();

                foreach (var id in IdFactDecimal(fecha))
                {
                    ids.Add(id);
                }

                foreach (var id in IdFactNoDecimal(fecha))
                {
                    ids.Add(id);
                }

                /*string sql = "SELECT factura_venta.id FROM factura_venta, producto_factura_venta WHERE factura_venta.id = producto_factura_venta.id_factura AND factura_venta.nitcliente = '1000' AND " + 
                "factura_venta.fecha_factura_venta = '" + fecha.ToShortDateString() + "' AND factura_venta.idestado = 1 AND factura_venta.estado = true AND producto_factura_venta.valor_iva = " + iva + " AND  " +
                "producto_factura_venta.retorno = false GROUP BY factura_venta.id ORDER BY factura_venta.id ASC;";
                miComando = new NpgsqlCommand();
                miComando.Connection = miConexion.MiConexion;
                miComando.CommandType = CommandType.Text;
                miComando.CommandText = sql;
                miComando.CommandTimeout = 0;
                miConexion.MiConexion.Open();
                NpgsqlDataReader reader = miComando.ExecuteReader();
                while (reader.Read())
                {
                    ids.Add(reader.GetInt32(0));
                }

                miConexion.MiConexion.Close();
                miComando.Dispose();*/
                return ids;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally { miConexion.MiConexion.Close(); }
        }


        private List<int> IdsFacturasVenta_old(DateTime fecha, int iva)
        {
            try
            {
                var ids = new List<int>();
                string sql = "SELECT factura_venta.id FROM factura_venta, producto_factura_venta WHERE factura_venta.id = producto_factura_venta.id_factura AND factura_venta.nitcliente = '1000' AND " +
                "factura_venta.fecha_factura_venta = '" + fecha.ToShortDateString() + "' AND factura_venta.idestado = 1 AND factura_venta.estado = true AND producto_factura_venta.valor_iva = " + iva + " AND  " +
                "producto_factura_venta.retorno = false GROUP BY factura_venta.id ORDER BY factura_venta.id ASC;";
                miComando = new NpgsqlCommand();
                miComando.Connection = miConexion.MiConexion;
                miComando.CommandType = CommandType.Text;
                miComando.CommandText = sql;
                miComando.CommandTimeout = 0;
                miConexion.MiConexion.Open();
                NpgsqlDataReader reader = miComando.ExecuteReader();
                while (reader.Read())
                {
                    ids.Add(reader.GetInt32(0));
                }

                miConexion.MiConexion.Close();
                miComando.Dispose();
                return ids;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally { miConexion.MiConexion.Close(); }
        }

        private List<ProductoFacturaProveedor> ProductosDeVenta(int idFactura)
        {
            try
            {
                var productosVenta = new List<ProductoFacturaProveedor>();
                /*string sql = "SELECT * FROM producto_factura_venta WHERE producto_factura_venta.id_factura = " + idFactura + 
                    " AND producto_factura_venta.valor_iva = 0 AND producto_factura_venta.retorno = false;";*/
                string sql = "SELECT producto_factura_venta.idproducto_factura_venta, producto_factura_venta.id_factura, producto_factura_venta.codigointernoproducto, " +
                  "producto_factura_venta.cantidadproducto_factura_venta, producto_factura_venta.valorunitarioproducto_factura_venta, producto.cantidad_decimal, producto_factura_venta.costo  " +
                  "FROM producto, producto_factura_venta WHERE producto.codigointernoproducto = producto_factura_venta.codigointernoproducto AND producto_factura_venta.id_factura = " + idFactura + " AND producto_factura_venta.valor_iva = 0 AND " +
                  "producto_factura_venta.retorno = false;";
                miComando = new NpgsqlCommand();
                miComando.Connection = miConexion.MiConexion;
                miComando.CommandType = CommandType.Text;
                miComando.CommandText = sql;
                miComando.CommandTimeout = 0;
                miConexion.MiConexion.Open();
                NpgsqlDataReader reader = miComando.ExecuteReader();
                while (reader.Read())
                {
                    var p = new ProductoFacturaProveedor();
                    p.Id = reader.GetInt32(0);
                    p.IdFactura = reader.GetInt32(1);
                    p.Producto.CodigoInternoProducto = reader.GetString(2);
                    p.Cantidad = reader.GetDouble(3);
                    p.Valor = reader.GetDouble(4);
                    p.Producto.CantidadDecimal = reader.GetBoolean(5);
                    p.Costo = Convert.ToInt32(reader.GetDouble(6));
                    productosVenta.Add(p);
                }

                miConexion.MiConexion.Close();
                miComando.Dispose();
                return productosVenta;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally { miConexion.MiConexion.Close(); }
        }

        private List<ProductoFacturaProveedor> ProductosDeVentaIvaTodos(int idFactura)
        {
            try
            {
                var productosVenta = new List<ProductoFacturaProveedor>();
                /*string sql = "SELECT * FROM producto_factura_venta WHERE producto_factura_venta.id_factura = " + idFactura + 
                    " AND producto_factura_venta.valor_iva = 0 AND producto_factura_venta.retorno = false;";*/
                string sql = "SELECT producto_factura_venta.idproducto_factura_venta, producto_factura_venta.id_factura, producto_factura_venta.codigointernoproducto, " +
                  "producto_factura_venta.cantidadproducto_factura_venta, producto_factura_venta.valorunitarioproducto_factura_venta, producto.cantidad_decimal FROM producto, producto_factura_venta WHERE " +
                  "producto.codigointernoproducto = producto_factura_venta.codigointernoproducto AND producto_factura_venta.id_factura = " + idFactura + " AND producto_factura_venta.retorno = false;";
                miComando = new NpgsqlCommand();
                miComando.Connection = miConexion.MiConexion;
                miComando.CommandType = CommandType.Text;
                miComando.CommandText = sql;
                miComando.CommandTimeout = 0;
                miConexion.MiConexion.Open();
                NpgsqlDataReader reader = miComando.ExecuteReader();
                while (reader.Read())
                {
                    var p = new ProductoFacturaProveedor();
                    p.Id = reader.GetInt32(0);
                    p.IdFactura = reader.GetInt32(1);
                    p.Producto.CodigoInternoProducto = reader.GetString(2);
                    p.Cantidad = reader.GetDouble(3);
                    p.Valor = reader.GetDouble(4);
                    p.Producto.CantidadDecimal = reader.GetBoolean(5);
                    productosVenta.Add(p);
                }

                miConexion.MiConexion.Close();
                miComando.Dispose();
                return productosVenta;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally { miConexion.MiConexion.Close(); }
        }

        // Validacion impoconsumo
        private double ValidarImpoconsumo(int id)
        {
            try
            {
                string sql = 
                  "SELECT mi_round((impoconsumo * cantidadproducto_factura_venta), 1) as ico FROM producto_factura_venta WHERE idproducto_factura_venta = @id;";
                miComando = new NpgsqlCommand();
                miComando.Connection = miConexion.MiConexion;
                miComando.CommandType = CommandType.Text;
                miComando.CommandText = sql;
                miComando.Parameters.AddWithValue("id", id);
                miConexion.MiConexion.Open();
                double ico = Convert.ToDouble(miComando.ExecuteScalar());
                miConexion.MiConexion.Close();
                return ico;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally { miConexion.MiConexion.Close(); }
        }

        private void ActualizarImpoconsumo(DateTime fecha, double ico)
        {
            try
            {
                string sql = "SELECT MIN(producto_factura_venta.idproducto_factura_venta) FROM factura_venta, producto_factura_venta  WHERE  " + 
                  "factura_venta.id = producto_factura_venta.id_factura AND factura_venta.nitcliente = '1000' AND " + 
                  "factura_venta.fecha_factura_venta = '" + fecha.ToShortDateString() + "' AND factura_venta.idestado = 1 AND factura_venta.estado = true AND " +
                  "producto_factura_venta.valor_iva = 5 AND producto_factura_venta.retorno = false AND producto_factura_venta.impoconsumo = 0 AND producto_factura_venta.cantidadproducto_factura_venta = 1; ";
                miComando = new NpgsqlCommand();
                miComando.Connection = miConexion.MiConexion;
                miComando.CommandType = CommandType.Text;
                miComando.CommandText = sql;
                miConexion.MiConexion.Open();
                int id = Convert.ToInt32(miComando.ExecuteScalar());
                miConexion.MiConexion.Close();

                sql = "UPDATE producto_factura_venta SET impoconsumo = @ico WHERE idproducto_factura_venta = " + id + ";";
                miComando = new NpgsqlCommand();
                miComando.Connection = miConexion.MiConexion;
                miComando.CommandType = CommandType.Text;
                miComando.CommandText = sql;
                miComando.Parameters.AddWithValue("ico", ico);
                miConexion.MiConexion.Open();
                miComando.ExecuteNonQuery();
                miConexion.MiConexion.Close();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally { miConexion.MiConexion.Close(); }
        }



        private void UpdateRegProductoIva0(int id, double cant)
        {
            try
            {
                string sql = "update producto_factura_venta set cantidadproducto_factura_venta = @cant where idproducto_factura_venta = " + id + ";";
                miComando = new NpgsqlCommand();
                miComando.Connection = miConexion.MiConexion;
                miComando.CommandType = CommandType.Text;
                miComando.CommandText = sql;
                miComando.Parameters.AddWithValue("cant", cant);
                miConexion.MiConexion.Open();
                miComando.ExecuteNonQuery();
                miConexion.MiConexion.Close();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally { miConexion.MiConexion.Close(); }
        }

        private void UpdateRegProductoIva0(int id, string codigo, double cant, double valor, int costo)
        {
            try
            {
                string sql = "update producto_factura_venta set codigointernoproducto = '" + codigo + "', cantidadproducto_factura_venta = @cant" + 
                    ", valorunitarioproducto_factura_venta = @valor, valor_iva = 0, costo = @costo where idproducto_factura_venta = " + id + ";";
                miComando = new NpgsqlCommand();
                miComando.Connection = miConexion.MiConexion;
                miComando.CommandType = CommandType.Text;
                miComando.CommandText = sql;
                miComando.Parameters.AddWithValue("cant", cant);
                miComando.Parameters.AddWithValue("valor", valor);
                miComando.Parameters.AddWithValue("costo", costo);
                miConexion.MiConexion.Open();
                miComando.ExecuteNonQuery();
                miConexion.MiConexion.Close();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally { miConexion.MiConexion.Close(); }
        }


        private void DeleteProductoVenta(int id)
        {
            try
            {
                string sql = "delete from producto_factura_venta where idproducto_factura_venta = @id;";
                miComando = new NpgsqlCommand();
                miComando.Connection = miConexion.MiConexion;
                miComando.CommandType = CommandType.Text;
                miComando.CommandText = sql;
                miComando.Parameters.AddWithValue("id", id);
                miConexion.MiConexion.Open();
                miComando.ExecuteNonQuery();
                miConexion.MiConexion.Close();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally { miConexion.MiConexion.Close(); }
        }

        //private void EditarRegistro(int id


        private double TotalIva19(DateTime fecha)
        {
            try
            {
                string sql = "SELECT mi_round(SUM(producto_factura_venta.cantidadproducto_factura_venta * producto_factura_venta.valorunitarioproducto_factura_venta), 1) " +
                   "FROM factura_venta, producto_factura_venta WHERE factura_venta.nitcliente = '1000' AND factura_venta.id = producto_factura_venta.id_factura AND " +
                   "factura_venta.fecha_factura_venta = '" + fecha.ToShortDateString() + "' AND factura_venta.idestado = 1 AND " +
                   "factura_venta.estado = true AND producto_factura_venta.valor_iva = 19 AND producto_factura_venta.retorno = false GROUP BY " +
                   "factura_venta.fecha_factura_venta;";
                miComando = new NpgsqlCommand();
                miComando.Connection = miConexion.MiConexion;
                miComando.CommandType = CommandType.Text;
                miComando.CommandText = sql;
                miComando.CommandTimeout = 0;
                miConexion.MiConexion.Open();
                double valor = Convert.ToDouble(miComando.ExecuteScalar());
                miConexion.MiConexion.Close();
                miComando.Dispose();
                return valor;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally { miConexion.MiConexion.Close(); }
        }



        private List<int> IdFactDecimal(DateTime fecha)
        {
            try
            {
                var ids = new List<int>();

                string sql = "SELECT factura_venta.id FROM factura_venta, producto_factura_venta, producto  WHERE factura_venta.id = producto_factura_venta.id_factura AND " +
                   "producto.codigointernoproducto = producto_factura_venta.codigointernoproducto AND factura_venta.nitcliente = '1000' AND " +
                   "factura_venta.fecha_factura_venta = '" + fecha.ToShortDateString() + "' AND factura_venta.idestado = 1 AND factura_venta.estado = true AND " +
                   "producto_factura_venta.valor_iva = 0 AND producto_factura_venta.retorno = false AND producto_factura_venta.cantidadproducto_factura_venta > 0.8 " +
                   "AND producto.cantidad_decimal = TRUE ORDER BY factura_venta.id ASC;";
                miComando = new NpgsqlCommand();
                miComando.Connection = miConexion.MiConexion;
                miComando.CommandType = CommandType.Text;
                miComando.CommandText = sql;
                miComando.CommandTimeout = 0;
                miConexion.MiConexion.Open();
                NpgsqlDataReader reader = miComando.ExecuteReader();
                while (reader.Read())
                {
                    ids.Add(reader.GetInt32(0));
                }
                miConexion.MiConexion.Close();
                miComando.Dispose();
                return ids;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally { miConexion.MiConexion.Close(); }
        }

        private List<int> IdFactNoDecimal(DateTime fecha)
        {
            try
            {
                var ids = new List<int>();

                string sql = "SELECT factura_venta.id FROM factura_venta, producto_factura_venta, producto WHERE factura_venta.id = producto_factura_venta.id_factura AND " +
                   "producto.codigointernoproducto = producto_factura_venta.codigointernoproducto AND factura_venta.nitcliente = '1000' AND " +
                   "factura_venta.fecha_factura_venta = '" + fecha.ToShortDateString() + "' AND factura_venta.idestado = 1 AND factura_venta.estado = true AND " +
                   "producto_factura_venta.valor_iva = 0 AND producto_factura_venta.retorno = false AND producto_factura_venta.cantidadproducto_factura_venta > 1 " +
                   "AND producto.cantidad_decimal = FALSE  ORDER BY factura_venta.id ASC;";
                miComando = new NpgsqlCommand();
                miComando.Connection = miConexion.MiConexion;
                miComando.CommandType = CommandType.Text;
                miComando.CommandText = sql;
                miComando.CommandTimeout = 0;
                miConexion.MiConexion.Open();
                NpgsqlDataReader reader = miComando.ExecuteReader();
                while (reader.Read())
                {
                    ids.Add(reader.GetInt32(0));
                }
                miConexion.MiConexion.Close();
                miComando.Dispose();
                return ids;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally { miConexion.MiConexion.Close(); }
        }


        //  Fin funciones para el ajuste de valores de IVA


        public void AjusteDeInventario()
        {
            try
            {
                string sql = "SELECT * FROM inventario_fisico_temp;";
                miAdapter = new NpgsqlDataAdapter(sql, miConexion.MiConexion);
                miAdapter.SelectCommand.CommandType = CommandType.Text;
                var tablaInveTem = new DataTable();
                miAdapter.Fill(tablaInveTem);

                foreach (DataRow inTrow in tablaInveTem.Rows)
                {
                    var regInvent = RegistroInventarioFisico(inTrow["codigo"].ToString());
                    if (regInvent.Cantidad != 0)
                    {
                        // actualizar cantidad sumando la del temporal con la del fisico
                        UpdateInventarioFisico(regInvent.Id, (Convert.ToDouble(inTrow["cantidad"]) + regInvent.Cantidad));
                    }
                    else
                    {
                        // insertar registro de inventario temp al inventario fisico
                        var invent = new InventarioFisico();
                        invent.Fecha = Convert.ToDateTime(inTrow["fecha"]);
                        invent.CodigoProducto = inTrow["codigo"].ToString();
                        invent.IdMedida = Convert.ToInt32(inTrow["idvalor_unidad_medida"]);
                        invent.IdColor = Convert.ToInt32(inTrow["idcolor"]);
                        invent.Cantidad = Convert.ToDouble(inTrow["cantidad"]);
                        invent.Corte = Convert.ToBoolean(inTrow["corte"]);
                        invent.NumeroCorte = Convert.ToInt32(inTrow["numero_corte"]);
                        invent.Costo = Convert.ToDouble(inTrow["costo"]);

                        InsertarInventarioFisico(invent);
                    }
                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally { miConexion.MiConexion.Close(); }
        }

        public InventarioFisico RegistroInventarioFisico(string codigo)
        {
            try
            {
                string sql = 
                    "select * from inventario_fisico where fecha_inventario_fisico >= '2020-01-05' AND codigointernoproducto = '" + codigo + "';";
                miComando = new NpgsqlCommand();
                miComando.Connection = miConexion.MiConexion;
                miComando.CommandType = CommandType.Text;
                miComando.CommandText = sql;
                miComando.CommandTimeout = 0;
                miConexion.MiConexion.Open();
                NpgsqlDataReader reader = miComando.ExecuteReader();
                InventarioFisico inve = new InventarioFisico();
                while (reader.Read())
                {
                    inve.Id = reader.GetInt32(0);
                    inve.Cantidad = reader.GetDouble(5);
                }
                miComando.Dispose();
                miConexion.MiConexion.Close();
                return inve;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally { miConexion.MiConexion.Close(); }
        }

        public void UpdateInventarioFisico(int id, double cantidad)
        {
            try
            {
                string sql = "update inventario_fisico set cantidad_inventario_fisico = @cant where id_inventario_fisico = " + id + ";";
                miComando = new NpgsqlCommand();
                miComando.Connection = miConexion.MiConexion;
                miComando.CommandType = CommandType.Text;
                miComando.CommandText = sql;
                miComando.Parameters.AddWithValue("cant", cantidad);
                miComando.CommandTimeout = 0;
                miConexion.MiConexion.Open();
                miComando.ExecuteNonQuery();
                miComando.Dispose();
                miConexion.MiConexion.Close();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally { miConexion.MiConexion.Close(); }
        }

        public void InsertarInventarioFisico(InventarioFisico invent)
        {
            try
            {
                string sql = "insert into inventario_fisico(fecha_inventario_fisico, codigointernoproducto, idvalor_unidad_medida, " +
                  "idcolor, cantidad_inventario_fisico, corte_inventario_fisico, numero_corte, costo) values('" + invent.Fecha.ToShortDateString()+ "', '"+
                  invent.CodigoProducto + "', " + invent.IdMedida + ", " + invent.IdColor + ", @cant, " + invent.Corte + ", " + invent.NumeroCorte + ", @costo);";
                miComando = new NpgsqlCommand();
                miComando.Connection = miConexion.MiConexion;
                miComando.CommandType = CommandType.Text;
                miComando.CommandText = sql;
               /* miComando.Parameters.AddWithValue("fecha", invent.Fecha);
                miComando.Parameters.AddWithValue("codigo", invent.CodigoProducto);
                miComando.Parameters.AddWithValue("idmedida", invent.IdMedida);
                miComando.Parameters.AddWithValue("idcolor", invent.IdColor);*/

                miComando.Parameters.AddWithValue("cant", invent.Cantidad);

                //miComando.Parameters.AddWithValue("corte", invent.Corte);

                miComando.Parameters.AddWithValue("costo", invent.Costo);
                miComando.CommandTimeout = 0;
                miConexion.MiConexion.Open();
                miComando.ExecuteNonQuery();
                miComando.Dispose();
                miConexion.MiConexion.Close();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally { miConexion.MiConexion.Close(); }
        }


        //  Funciones para reporte diario de ventas por remision

        public List<FacturaVenta> VentasRemision(DateTime fecha)
        {
            try
            {
                var remisiones = new List<FacturaVenta>();
                CargarComando("ventas_remision");
                miComando.Parameters.AddWithValue("", fecha);
                miConexion.MiConexion.Open();
                NpgsqlDataReader reader = miComando.ExecuteReader();
                while (reader.Read())
                {
                    var f = new FacturaVenta();
                    //f.Numero = reader.GetString(0);
                    f.FechaFactura = reader.GetDateTime(1);
                    f.Valor = Convert.ToInt32(reader.GetDouble(2));
                    remisiones.Add(f);
                }
                miConexion.MiConexion.Close();
                miComando.Dispose();
                return remisiones;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally { miConexion.MiConexion.Close(); }
        }

        // Funciones para reporte diario de ventas por remision


        private void CargarComandoText(string cmd)
        {
            miComando = new NpgsqlCommand();
            miComando.Connection = miConexion.MiConexion;
            miComando.CommandType = CommandType.Text;
            miComando.CommandText = cmd;
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