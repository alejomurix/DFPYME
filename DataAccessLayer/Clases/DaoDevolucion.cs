using System;
using System.Linq;
using System.Collections.Generic;
using System.Data;
using DTO.Clases;
using Npgsql;

namespace DataAccessLayer.Clases
{
    /// <summary>
    /// Representa una clase de Acceso a datos para Devolucion.
    /// </summary>
    public class DaoDevolucion
    {
        #region Atributos

        /// <summary>
        /// Objeto que me permite a acceder a la conexión a base de datos PostgreSQL.
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

        /// <summary>
        /// Objeto que permite el acceso a la capa de datos de Inventario.
        /// </summary>
        private DaoInventario miDaoInventario;

        private Kardex Kardex { set; get; }

        private DaoKardex miDaoKardex;

        #endregion

        #region Funciones

        //DEVOLUCION VENTA

        /// <summary>
        /// Representa la función: insertar_devolucion_venta
        /// </summary>
        private string IngresarVenta_ = "insertar_devolucion_venta";

        /// <summary>
        /// Representa la función: consulta_devolucion_venta_factura.
        /// </summary>
        private string ConsultaFacturaVenta = "consulta_devolucion_venta_factura";

        /// <summary>
        /// Representa la función: consulta_devolucion_venta_factura_saldo.
        /// </summary>
        private string ConsultaFacturaVentaSaldo = "consulta_devolucion_venta_factura_saldo";

        /// <summary>
        /// Representa la función: consulta_devolucion_venta_cliente.
        /// </summary>
        private string ConsultaCliente_ = "consulta_devolucion_venta_cliente";

        /// <summary>
        /// Representa la función: count_consulta_devolucion_venta_cliente.
        /// </summary>
        private string CountConsultaCliente = "count_consulta_devolucion_venta_cliente";

        /// <summary>
        /// Representa la función: consulta_devolucion_venta_cliente_saldo.
        /// </summary>
        private string ConsultaClienteSaldo = "consulta_devolucion_venta_cliente_saldo";

        /// <summary>
        /// Representa la función: count_consulta_devolucion_venta_cliente_saldo.
        /// </summary>
        private string CountConsultaClienteSaldo = "count_consulta_devolucion_venta_cliente_saldo";

        /// <summary>
        /// Representa la función: consulta_devolucion_venta_cliente_name.
        /// </summary>
        private string ConsultaClienteNa_ = "consulta_devolucion_venta_cliente_name";

        /// <summary>
        /// Representa la función: count_consulta_devolucion_venta_cliente_name.
        /// </summary>
        private string CountConsultaClienteNa_ = "count_consulta_devolucion_venta_cliente_name";

        /// <summary>
        /// Representa la función: consulta_devolucion_venta_cliente_name_saldo.
        /// </summary>
        private string ConsultaClienteNaSaldo = "consulta_devolucion_venta_cliente_name_saldo";

        /// <summary>
        /// Representa la función: count_consulta_devolucion_venta_cliente_name_saldo.
        /// </summary>
        private string CountConsultaClienteNaSaldo = "count_consulta_devolucion_venta_cliente_name_saldo";

        /// <summary>
        /// Representa la función: consulta_devolucion_venta_fecha.
        /// </summary>
        private string ConsultaFecha_ = "consulta_devolucion_venta_fecha";

        /// <summary>
        /// Representa la función: consulta_devolucion_venta_fecha_saldo.
        /// </summary>
        private string ConsultaFechaSaldo = "consulta_devolucion_venta_fecha_saldo";

        //DEVOLUCION REMISION

        /// <summary>
        /// Representa la función: insertar_devolucion_remision.
        /// </summary>
        private string IngresarRemision_ = "insertar_devolucion_remision";

        /// <summary>
        /// Representa la función: devolucion_remision.
        /// </summary>
        private string ConsultaRemision_ = "devolucion_remision";

        #endregion

        #region Mensajes

        /// <summary>
        ///Representa el texto: Ocurrió un error al ingresar la devolución de la venta.
        /// </summary>
        private string ErrorIngresarVenta_ = "Ocurrió un error al ingresar la devolución de la venta.\n";

        /// <summary>
        /// Representa el texto: Ocurrió un error al consultar la devolución de la venta.
        /// </summary>
        private string ErrorConsulta = "Ocurrió un error al consultar la devolución de la venta.\n";

        /// <summary>
        /// Representa el texto: Ocurrió un error al cargar el total de registros.
        /// </summary>
        private string ErrorCount = "Ocurrió un error al cargar el total de registros.\n";

        //Devolución Remisión

        /// <summary>
        /// Representa el texto: Ocurrió un error al consultar la devolución de la Remisión.
        /// </summary>
        private string ErrorConsultaR = "Ocurrió un error al consultar la devolución de la Remisión.\n";

        #endregion

        private DaoIva miDaoIva_;

        /// <summary>
        /// Inicializa una nueva instancia de la clase DaoDevolucion.
        /// </summary>
        public DaoDevolucion()
        {
            this.miConexion = new Conexion();
            miDaoInventario = new DaoInventario();
            miDaoKardex = new DaoKardex();
            Kardex = new Kardex();
            miDaoIva_ = new DaoIva();
        }

        #region Devolucion Venta

        public string GetConsecutivoVenta()
        {
            try
            {
                CargarComando("recuperar_consecutivo");
                miComando.Parameters.AddWithValue("nombre", "DevolucionVenta");
                miConexion.MiConexion.Open();
                var numero = Convert.ToString(miComando.ExecuteScalar());
                miConexion.MiConexion.Close();
                miComando.Dispose();
                return numero;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al obtener el consecutivo.\n" + ex.Message);
            }
            finally { miConexion.MiConexion.Close(); }
        }

        public void ActualizarConsecutivoVenta()
        {
            var consecutivo = GetConsecutivoVenta();
            try
            {
                CargarComando("actualizar_consecutivo");
                miComando.Parameters.AddWithValue("numero", "DevolucionVenta");
                miComando.Parameters.AddWithValue("valor", (consecutivo + 1).ToString());
                miConexion.MiConexion.Open();
                miComando.ExecuteNonQuery();
                miConexion.MiConexion.Close();
                miComando.Dispose();
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al actualizar el consecutivo.\n" + ex.Message);
            }
            finally { miConexion.MiConexion.Close(); }
        }

        /// <summary>
        /// Ingresa una devolución hecha a una Factura de Venta.
        /// </summary>
        /// <param name="devolucion">Devolución a ser ingresada.</param>
        public int IngresarVenta(Devolucion devolucion)
        {
            try
            {
                CargarComando(IngresarVenta_);
                miComando.Parameters.AddWithValue("factura", devolucion.Factura);
                miComando.Parameters.AddWithValue("producto", devolucion.Producto.CodigoProducto);
                miComando.Parameters.AddWithValue("fecha", devolucion.Fecha);
                miComando.Parameters.AddWithValue("valor", devolucion.Valor);
                miComando.Parameters.AddWithValue("iva", devolucion.Iva);
                miComando.Parameters.AddWithValue("medida", devolucion.Producto.IdMedida);
                miComando.Parameters.AddWithValue("color", devolucion.Producto.IdColor);
                miComando.Parameters.AddWithValue("aplicaDesc", devolucion.Descuento);
                miComando.Parameters.AddWithValue("descto", devolucion.Descto);
                //miComando.Parameters.AddWithValue("recargo", devolucion.Recargo);
                miComando.Parameters.AddWithValue("usuario", devolucion.IdUsuario);
                miComando.Parameters.AddWithValue("caja", devolucion.IdCaja);
                miComando.Parameters.AddWithValue("cantidad", devolucion.Cantidad);
                miComando.Parameters.AddWithValue("efectiva", devolucion.Efectiva);
                miConexion.MiConexion.Open();
                var id = Convert.ToInt32(miComando.ExecuteScalar());
                miConexion.MiConexion.Close();
                miComando.Dispose();

                var inventario = devolucion.Producto;
                inventario.Cantidad = devolucion.Cantidad;
                miDaoInventario.ActualizarInventario(inventario, false);
                return id;
            }
            catch (Exception ex)
            {
                throw new Exception(ErrorIngresarVenta_ + ex.Message);
            }
            finally { miConexion.MiConexion.Close(); }
        }

        public void IngresarVenta(FacturaProveedor devolucion)
        {
            var daoConsecutivo = new DaoConsecutivo();
            var daoKardex = new DaoKardex();
            var kardex = new Kardex();

            bool existeProductoFabricado = false;
            try
            {
                CargarComando("ingresar_devolucion_venta");
                miComando.Parameters.AddWithValue("numero", devolucion.Numero);
                miComando.Parameters.AddWithValue("factura", devolucion.NumeroEdit);
                miComando.Parameters.AddWithValue("cliente", devolucion.Proveedor.NitProveedor);
                miComando.Parameters.AddWithValue("fecha", devolucion.FechaIngreso);
                miComando.Parameters.AddWithValue("usuario", devolucion.Usuario.Id);
                miComando.Parameters.AddWithValue("caja", devolucion.Caja.Id);
                miComando.Parameters.AddWithValue("turno", devolucion.Turno.Id);
                miComando.Parameters.AddWithValue("hora", devolucion.FechaIngreso.TimeOfDay);
                miConexion.MiConexion.Open();
                var id = Convert.ToInt32(miComando.ExecuteScalar());
                miConexion.MiConexion.Close();
                miComando.Dispose();
                daoConsecutivo.ActualizarConsecutivo("DevolucionVenta");
                if (devolucion.DevolucionEfectivo > 0)
                {
                    IngresarDevolucionEfectivo(id, devolucion.DevolucionEfectivo);
                }
                foreach (var detalle in devolucion.Productos)
                {
                    detalle.IdFactura = id;
                    IngresarDetalleVenta(detalle);
                    if (detalle.Producto.IdTipoInventario != 3)  // IdTipoInventario = 3 : Productos fabricados por la empresa. Descuenta insumos usados.
                    {
                        miDaoInventario.ActualizarInventario(detalle.Inventario, false);
                    }
                    else
                    {
                        existeProductoFabricado = true;
                    }

                    kardex.Codigo = detalle.Inventario.CodigoProducto;
                    kardex.IdUsuario = devolucion.Usuario.Id;
                    kardex.IdConcepto = 3;
                    kardex.NoDocumento = devolucion.Numero;
                    kardex.Fecha = DateTime.Now;
                    kardex.Cantidad = detalle.Inventario.Cantidad;
                    double iva =
                        Math.Round((detalle.Producto.ValorCosto * detalle.Producto.ValorIva / 100), 2);
                    kardex.Valor = detalle.Producto.ValorCosto + Convert.ToInt32(iva);
                    kardex.Total = kardex.Valor * kardex.Cantidad;
                    //kardex.Valor = detalle.Producto.ValorCosto;
                    daoKardex.Insertar(kardex);
                }
                if (existeProductoFabricado)
                {
                    foreach (var detalle in devolucion.Productos)
                    {
                        if (detalle.Producto.IdTipoInventario.Equals(3))  // IdTipoInventario = 3 : Productos fabricados por la empresa. Descuenta insumos usados.
                        {
                            miDaoInventario.ActualizarCantidadProductoPreparado
                                (detalle.Inventario.CodigoProducto, detalle.Inventario.Cantidad, false);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ErrorIngresarVenta_ + ex.Message);
            }
            finally { miConexion.MiConexion.Close(); }
        }

        public void IngresarDetalleVenta(ProductoFacturaProveedor detalle)
        {
            try
            {
                CargarComando("ingresar_detalle_devolucion_venta");
                miComando.Parameters.AddWithValue("", detalle.IdFactura);
                miComando.Parameters.AddWithValue("", detalle.Inventario.CodigoProducto);
                miComando.Parameters.AddWithValue("", detalle.Inventario.IdMedida);
                miComando.Parameters.AddWithValue("", detalle.Inventario.IdColor);
                miComando.Parameters.AddWithValue("", detalle.Producto.ValorCosto);
                miComando.Parameters.AddWithValue("", detalle.Producto.Descuento);
                miComando.Parameters.AddWithValue("", detalle.Producto.ValorIva);
                miComando.Parameters.AddWithValue("", detalle.Inventario.Cantidad);
                miComando.Parameters.AddWithValue("", detalle.Producto.Impoconsumo);
                miConexion.MiConexion.Open();
                miComando.ExecuteNonQuery();
                miConexion.MiConexion.Close();
                miComando.Dispose();
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al ingresar el detalle de la devolución de venta.\n" + ex.Message);
            }
            finally { miConexion.MiConexion.Close(); }
        }

        public void IngresarConsecutivoVenta(int consecutivo, int idDevolucion)
        {
            try
            {
                CargarComando("insertar_consecutivo_devolucion");
                miComando.Parameters.AddWithValue("numero", consecutivo);
                miComando.Parameters.AddWithValue("idDevolucion", idDevolucion);
                miConexion.MiConexion.Open();
                miComando.ExecuteNonQuery();
                miConexion.MiConexion.Close();
                miComando.Dispose();
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al ingresar los consecutivos de la devolución.\n" + ex.Message);
            }
            finally { miConexion.MiConexion.Close(); }
        }

        private void IngresarDevolucionEfectivo(int idDevolucion, int valor)
        {
            try
            {
                CargarComando("insertar_devolucion_venta_efectivo");
                miComando.Parameters.AddWithValue("", idDevolucion);
                miComando.Parameters.AddWithValue("", valor);
                miConexion.MiConexion.Open();
                miComando.ExecuteNonQuery();
                miConexion.MiConexion.Close();
                miComando.Dispose();
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al ingresar el efectivo de la devolución.\n" + ex.Message);
            }
            finally { miConexion.MiConexion.Close(); }
        }


        public DataTable DevolucionesDeVenta(string numero)
        {
            try
            {
                var tabla = new DataTable();
                CargarAdapter("devoluciones_venta");
                miAdapter.SelectCommand.Parameters.AddWithValue("numero", numero);
                miAdapter.Fill(tabla);
                return tabla;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al consultar la devolución.\n" + ex.Message);
            }
        }

        public DataTable DevolucionesDeVenta(DateTime fecha)
        {
            try
            {
                var tabla = new DataTable();
                CargarAdapter("devoluciones_venta_fecha");
                miAdapter.SelectCommand.Parameters.AddWithValue("fecha", fecha);
                miAdapter.Fill(tabla);
                return tabla;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al consultar la devolución.\n" + ex.Message);
            }
        }

        public long GetRowsDevolucionesDeVenta(DateTime fecha)
        {
            try
            {
                CargarComando("count_devoluciones_venta_fecha");
                miComando.Parameters.AddWithValue("fecha", fecha);
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

        public DataTable DevolucionesDeVenta(DateTime fecha, DateTime fecha2)
        {
            try
            {
                var tabla = new DataTable();
                CargarAdapter("devoluciones_venta_periodo");
                miAdapter.SelectCommand.Parameters.AddWithValue("fecha", fecha);
                miAdapter.SelectCommand.Parameters.AddWithValue("fecha2", fecha2);
                miAdapter.Fill(tabla);
                return tabla;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al consultar la devolución.\n" + ex.Message);
            }
        }

        public long GetRowsDevolucionesDeVenta(DateTime fecha, DateTime fecha2)
        {
            try
            {
                CargarComando("count_devoluciones_venta_periodo");
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
                throw new Exception("Ocurrió un error al cargar el total de registros.\n" + ex.Message);
            }
            finally { miConexion.MiConexion.Close(); }
        }

        public DataTable DevolucionesDeVentaCliente(string cliente)
        {
            try
            {
                var tabla = new DataTable();
                CargarAdapter("devoluciones_venta_cliente");
                miAdapter.SelectCommand.Parameters.AddWithValue("cliente", cliente);
                miAdapter.Fill(tabla);
                return tabla;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al consultar la devolución.\n" + ex.Message);
            }
        }

        public long GetRowsDevolucionesDeVentaCliente(string cliente)
        {
            try
            {
                CargarComando("count_devoluciones_venta_cliente");
                miComando.Parameters.AddWithValue("cliente", cliente);
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


        /* public DataTable DetalleDevolucionVenta(int idDevolucion)
         {
             try
             {
                 var tabla = new DataTable();
                 CargarAdapter("detalle_devolucion_venta");
                 miAdapter.SelectCommand.Parameters.AddWithValue("id", idDevolucion);
                 miAdapter.Fill(tabla);
                 var miTabla = TablaVenta();
                 var valor = 0;
                 var descuento = 0.0;
                 var valorMenosDescto = 0.0;
                 var iva = 0.0;
                 foreach (DataRow row in tabla.Rows)
                 {
                     var row_ = miTabla.NewRow();
                     row_["Id"] = row["id"];
                     row_["Codigo"] = row["codigo"];
                     row_["Producto"] = row["nombreproducto"];
                     row_["Cantidad"] = row["cantidad"];
                     valor = Convert.ToInt32(row["valor"]);
                     descuento = Convert.ToDouble(row["descuento"]);
                     iva = Convert.ToDouble(row["iva"]);
                     valorMenosDescto = valor - (valor * descuento / 100);
                     row_["Valor"] = Convert.ToInt32(valorMenosDescto + (valorMenosDescto * iva / 100));
                     row_[""] = Convert.ToInt32(
                                Convert.ToInt32(row["Valor"]) *
                                Convert.ToDouble(row["Cantidad"]));
                     miTabla.Rows.Add(row_);
                 }
                 tabla.Rows.Clear();
                 tabla = null;
                 return miTabla;
             }
             catch (Exception ex)
             {
                 throw new Exception("Ocurrió un error al consultar los productos de la devolución.\n" + ex.Message);
             }
         }*/

        public Devolucion DevolucionVenta(string numero)
        {
            try
            {
                var devolucion = new Devolucion();
                CargarComando("devolucion_venta");
                miComando.Parameters.AddWithValue("numero", numero);
                miConexion.MiConexion.Open();
                NpgsqlDataReader miReader = miComando.ExecuteReader();
                while (miReader.Read())
                {
                    devolucion.Id = miReader.GetInt32(0);
                    devolucion.Numero = miReader.GetString(1);
                    devolucion.Factura = miReader.GetString(2);
                    devolucion.Cliente = miReader.GetString(3);
                    devolucion.Fecha = miReader.GetDateTime(4);
                    devolucion.IdUsuario = miReader.GetInt32(5);
                    devolucion.IdCaja = miReader.GetInt32(6);
                }
                miConexion.MiConexion.Close();
                miComando.Dispose();
                return devolucion;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al consultar la Devolución.\n" + ex.Message);
            }
            finally { miConexion.MiConexion.Close(); }
        }

        public DataTable DetalleDevolucionVenta(int idDevolucion)
        {
            var tabla = new DataTable();
            tabla.TableName = "Detalle";
            tabla.Columns.Add(new DataColumn("Codigo", typeof(string)));
            tabla.Columns.Add(new DataColumn("Cantidad", typeof(double)));
            tabla.Columns.Add(new DataColumn("Producto", typeof(string)));
            tabla.Columns.Add(new DataColumn("ValorUnit", typeof(int)));
            tabla.Columns.Add(new DataColumn("Valor_", typeof(int)));
            tabla.Columns.Add(new DataColumn("Descuento", typeof(double)));
            tabla.Columns.Add(new DataColumn("ValorDesto", typeof(int)));
            tabla.Columns.Add(new DataColumn("ValorMenosDesto", typeof(int)));
            tabla.Columns.Add(new DataColumn("ValorIva", typeof(double)));
            tabla.Columns.Add(new DataColumn("Total_", typeof(int)));
            try
            {
                var tbTmp = new DataTable();
                CargarAdapter("detalle_devolucion_venta");
                miAdapter.SelectCommand.Parameters.AddWithValue("idDevolucion", idDevolucion);
                miAdapter.Fill(tbTmp);
                foreach (DataRow row in tbTmp.Rows)
                {
                    var row_ = tabla.NewRow();
                    row_["Codigo"] = row["codigo"];
                    row_["Cantidad"] = row["cantidad"];
                    row_["Producto"] = row["nombreproducto"];
                    row_["ValorUnit"] = row["valor"];
                    row_["Descuento"] = row["descuento"];

                    row_["ValorDesto"] = Convert.ToInt32(
                        Convert.ToInt32(row["valor"]) * Convert.ToDouble(row["descuento"]) / 100);

                    //row_["ValorMenosDesto"] = Convert.ToInt32(row_["ValorUnit"]) - Convert.ToInt32(row_["ValorDesto"]);
                    //2
                    row_["ValorMenosDesto"] = Math.Round((Convert.ToDouble(row["valor"]) -
                                (Convert.ToDouble(row["valor"]) * Convert.ToDouble(row["descuento"]) / 100)), 1);

                    double vIva = Math.Round((Convert.ToDouble(row_["ValorMenosDesto"]) * Convert.ToDouble(row["iva"]) / 100), 1);
                    row_["ValorIva"] = vIva; // Math.Round((vIva * Convert.ToDouble(row_["Cantidad"])), 1);
                    row_["Valor_"] = Convert.ToInt32(Convert.ToDouble(row_["ValorMenosDesto"]) + vIva) + Convert.ToInt32(row["impoconsumo"]);
                    row_["Total_"] = Convert.ToInt32(
                                     Convert.ToDouble(row_["Valor_"]) * Convert.ToDouble(row_["Cantidad"]));

                    /* var cal = Convert.ToInt32(row_["ValorMenosDesto"]) * Convert.ToDouble(row["iva"]);
                     row_["ValorIva"] = (cal / 100);// *Convert.ToDouble(row["cantidad"]);

                     var viva = row_["ValorIva"].ToString();
                     row_["Valor_"] = Convert.ToInt32(row_["ValorMenosDesto"]) + Convert.ToInt32(row_["ValorIva"]);
                     viva = row_["Valor_"].ToString();
                     var viva_ = Convert.ToDouble(row_["Cantidad"]);
                     row_["Total_"] = Convert.ToInt32(row_["Valor_"]) * Convert.ToDouble(row_["Cantidad"]);
                     viva = row_["Total_"].ToString();*/
                    tabla.Rows.Add(row_);
                }
                return tabla;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al cargar el detalle de la devolución.\n" + ex.Message);
            }
        }

        public DataTable Devoluciones(int idEstado, int idCaja, DateTime fecha)
        {
            var tabla = new DataTable();
            try
            {
                CargarAdapter("print_devoluciones");
                miAdapter.SelectCommand.Parameters.AddWithValue("estado", idEstado);
                miAdapter.SelectCommand.Parameters.AddWithValue("caja", idCaja);
                miAdapter.SelectCommand.Parameters.AddWithValue("fecha", fecha);

                miAdapter.Fill(tabla);
                var tablaT = new DataTable();
                tablaT.TableName = "Devolucion";
                tablaT.Columns.Add(new DataColumn("NoFactura", typeof(string)));
                tablaT.Columns.Add(new DataColumn("Nit", typeof(string)));
                tablaT.Columns.Add(new DataColumn("Cliente", typeof(string)));
                tablaT.Columns.Add(new DataColumn("Valor", typeof(int)));
                var query = from data in tabla.AsEnumerable()
                            group data by new
                            {
                                NoFactura = data["numero"],
                                Nit = data["nitcliente"],
                                Nombre = data["nombrescliente"]
                            }
                                into grupo
                                select new
                                {
                                    NoFact = grupo.Key,
                                    Nit = grupo.Key,
                                    Nombre = grupo.Key
                                };
                foreach (var factura in query)
                {
                    var datos = tabla.AsEnumerable().
                                Where(d => d.Field<string>("numero").
                                Equals(factura.NoFact.NoFactura.ToString()));
                    var row = tablaT.NewRow();
                    row["NoFactura"] = factura.NoFact.NoFactura;
                    row["Nit"] = factura.Nit.Nit;
                    row["Cliente"] = factura.Nombre.Nombre;
                    var total = 0;
                    foreach (DataRow dRow in datos)
                    {
                        var sTotal = Convert.ToInt32(Convert.ToInt32(dRow["valor"]) -
                           (Convert.ToInt32(dRow["valor"]) * Convert.ToDouble(dRow["descuento"]) / 100));
                        var valor = Convert.ToInt32(sTotal + (sTotal * Convert.ToDouble(dRow["iva"]) / 100));
                        total += Convert.ToInt32(valor * Convert.ToDouble(dRow["cantidad"]));
                    }
                    row["Valor"] = total;
                    tablaT.Rows.Add(row);
                }
                tabla.Rows.Clear();
                tabla.Clear();
                tabla = null;
                return tablaT;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al cargar el total en Devoluciones.\n" + ex.Message);
            }
        }

        public DataTable Devoluciones(int idCaja, DateTime fecha)
        {
            var tabla = new DataTable();
            var daoEstado = new DaoEstado();
            try
            {
                CargarAdapter("saldo_devolucion_venta");
                miAdapter.SelectCommand.Parameters.AddWithValue("caja", idCaja);
                miAdapter.SelectCommand.Parameters.AddWithValue("fecha", fecha);
                miAdapter.Fill(tabla);

                var tablaT = new DataTable();
                tablaT.TableName = "Devolucion";
                tablaT.Columns.Add(new DataColumn("NoFactura", typeof(string)));
                tablaT.Columns.Add(new DataColumn("Nit", typeof(string)));
                tablaT.Columns.Add(new DataColumn("Cliente", typeof(string)));
                tablaT.Columns.Add(new DataColumn("Valor", typeof(int)));
                foreach (DataRow row in tabla.Rows)
                {
                    var row_ = tablaT.NewRow();
                    row_["NoFactura"] = row["numero_factura"];
                    row_["Nit"] = row["nitcliente"];
                    row_["Cliente"] = row["nombrescliente"];
                    row_["Valor"] = row["valor"];
                    tablaT.Rows.Add(row_);
                }
                /* var query = from data in tabla.AsEnumerable()
                             group data by new
                             {
                                 NoFactura = data["numero"],
                                 Pago = data["idestado"],
                                 Nit = data["nitcliente"],
                                 Nombre = data["nombrescliente"]
                             }
                                 into grupo
                                 select new
                                 {
                                     NoFact = grupo.Key,
                                     Pago = grupo.Key,
                                     Nit = grupo.Key,
                                     Nombre = grupo.Key
                                 };
                 foreach (var factura in query)
                 {
                     var datos = tabla.AsEnumerable().
                                 Where(d => d.Field<string>("numero").
                                 Equals(factura.NoFact.NoFactura.ToString()));
                     var row = tablaT.NewRow();
                     row["NoFactura"] = factura.NoFact.NoFactura;
                     row["Pago"] = daoEstado.EstadoById(Convert.ToInt32(factura.Pago.Pago)).Descripcion;
                     row["Nit"] = factura.Nit.Nit;
                     row["Cliente"] = factura.Nombre.Nombre;
                     var total = 0;
                     foreach (DataRow dRow in datos)
                     {
                         var sTotal = Convert.ToInt32(Convert.ToInt32(dRow["valor"]) -
                            (Convert.ToInt32(dRow["valor"]) * Convert.ToDouble(dRow["descuento"]) / 100));
                         var valor = Convert.ToInt32(sTotal + (sTotal * Convert.ToDouble(dRow["iva"]) / 100));
                         total += Convert.ToInt32(valor * Convert.ToDouble(dRow["cantidad"]));
                     }
                     row["Valor"] = total;
                     tablaT.Rows.Add(row);
                 }*/
                tabla.Rows.Clear();
                tabla.Clear();
                tabla = null;
                return tablaT;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al cargar el total en Devoluciones.\n" + ex.Message);
            }
        }

        public DataTable Devoluciones(DateTime fecha)
        {
            var tabla = new DataTable();
            var daoEstado = new DaoEstado();
            try
            {
                CargarAdapter("saldo_devolucion_venta");
                miAdapter.SelectCommand.Parameters.AddWithValue("fecha", fecha);
                miAdapter.Fill(tabla);

                var tablaT = new DataTable();
                tablaT.TableName = "Devolucion";
                tablaT.Columns.Add(new DataColumn("NoFactura", typeof(string)));
                tablaT.Columns.Add(new DataColumn("Nit", typeof(string)));
                tablaT.Columns.Add(new DataColumn("Cliente", typeof(string)));
                tablaT.Columns.Add(new DataColumn("Valor", typeof(int)));
                foreach (DataRow row in tabla.Rows)
                {
                    var row_ = tablaT.NewRow();
                    row_["NoFactura"] = row["numero_factura"];
                    row_["Nit"] = row["nitcliente"];
                    row_["Cliente"] = row["nombrescliente"];
                    row_["Valor"] = row["valor"];
                    tablaT.Rows.Add(row_);
                }
                tabla.Rows.Clear();
                tabla.Clear();
                tabla = null;
                return tablaT;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al cargar el total en Devoluciones.\n" + ex.Message);
            }
        }

        public DataSet IvaDevolucion(int idCaja, DateTime fecha)
        {
            var miDaoIva = new DaoIva();
            var dataSet = new DataSet();
            var tabla = new DataTable();
            tabla.TableName = "IvaDevolucion";
            tabla.Columns.Add(new DataColumn("IvaD", typeof(string)));
            tabla.Columns.Add(new DataColumn("BaseD", typeof(double)));
            tabla.Columns.Add(new DataColumn("VIvaD", typeof(double)));
            tabla.Columns.Add(new DataColumn("SubTotalD", typeof(int)));
            try
            {
                var iva = miDaoIva.ListadoIva();
                var devoluciones = new DataTable();
                CargarAdapter("detalle_devolucion_venta");
                miAdapter.SelectCommand.Parameters.AddWithValue("caja", idCaja);
                miAdapter.SelectCommand.Parameters.AddWithValue("fecha", fecha);
                miAdapter.Fill(devoluciones);
                foreach (Iva dIva in iva)
                {
                    foreach (DataRow dRow in devoluciones.Rows)
                    {
                        if (dIva.PorcentajeIva.Equals(
                            Convert.ToDouble(dRow["iva"])))
                        {
                            var tablaRow = tabla.NewRow();
                            tablaRow["IvaD"] = dRow["iva"].ToString();
                            var descto = Convert.ToDouble(dRow["descuento"]);
                            /*if (Convert.ToBoolean(dRow["aplica_descto"]))
                            {
                                descto = Convert.ToDouble(dRow["descuento"]);
                            }*/

                            /*var sTotal = Convert.ToInt32(dRow["valor"]) -
                                (Convert.ToInt32(dRow["valor"]) * descto / 100);*/
                            var sTotal = Math.Round((Convert.ToDouble(dRow["valor"]) -
                                (Convert.ToDouble(dRow["valor"]) * descto / 100)), 1);

                            double vIva = Math.Round((sTotal * Convert.ToDouble(dRow["iva"]) / 100), 1);

                            /*var valorMasIva = sTotal +
                                Convert.ToInt32(sTotal * Convert.ToDouble(dRow["iva"]) / 100);*/
                            var valorMasIva = Convert.ToInt32(sTotal + vIva);

                            var total = Convert.ToInt32(
                                valorMasIva * Convert.ToDouble(dRow["cantidad"]));


                            tablaRow["BaseD"] = Math.Round(total / (1 + (Convert.ToDouble(dRow["iva"]) / 100)), 1); // decima 2

                            // var basb = Convert.ToDouble(tablaRow["BaseD"]);

                            tablaRow["VIvaD"] = Math.Round((Convert.ToDouble(tablaRow["BaseD"]) *
                                Convert.ToDouble(dRow["iva"]) / 100), 1);

                            //   var viva = Convert.ToDouble(tablaRow["VIvaD"]);

                            tablaRow["SubTotalD"] = Convert.ToDouble(tablaRow["BaseD"]) + Convert.ToDouble(tablaRow["VIvaD"]);


                            /*tablaRow["BaseD"] = sTotal * Convert.ToDouble(dRow["cantidad"]);

                            var b = tablaRow["BaseD"].ToString();

                            tablaRow["VIvaD"] = Convert.ToInt32(
                                       (sTotal * Convert.ToDouble(dRow["ivadevolucion_venta"]) / 100)
                                       * Convert.ToDouble(dRow["cantidad"]));

                            var v = tablaRow["VIvaD"].ToString();

                            tablaRow["SubTotalD"] = Convert.ToInt32(tablaRow["BaseD"]) + Convert.ToInt32(tablaRow["VIvaD"]);

                            var s = tablaRow["SubTotalD"].ToString();*/

                            tabla.Rows.Add(tablaRow);
                        }
                    }
                }
                IEnumerable<DataRow> query = from d in tabla.AsEnumerable()
                                             select d;
                DataTable tablaTmp = new DataTable();
                if (query.ToArray().Length != 0)
                {
                    tablaTmp = query.CopyToDataTable<DataRow>();
                }
                tablaTmp.TableName = "IvaDevolucion";
                tablaTmp.Rows.Clear();
                foreach (Iva tmpIva in iva)
                {
                    var tBase = tabla.AsEnumerable().Where(i => i.Field<string>("IvaD").
                        Equals(tmpIva.PorcentajeIva.ToString())).Sum(s => s.Field<double>("BaseD"));
                    var tIva = tabla.AsEnumerable().Where(i => i.Field<string>("IvaD").
                        Equals(tmpIva.PorcentajeIva.ToString())).Sum(s => s.Field<double>("VIvaD"));
                    var sTotal = tabla.AsEnumerable().Where(i => i.Field<string>("IvaD").
                        Equals(tmpIva.PorcentajeIva.ToString())).Sum(s => s.Field<int>("SubTotalD"));
                    if (tBase != 0)
                    {
                        var rowTmp = tablaTmp.NewRow();
                        rowTmp["IvaD"] = tmpIva.PorcentajeIva.ToString();
                        rowTmp["BaseD"] = tBase;
                        rowTmp["VIvaD"] = tIva;
                        rowTmp["SubTotalD"] = sTotal;
                        tablaTmp.Rows.Add(rowTmp);
                    }
                    //VIvaD
                }
                dataSet.Tables.Add(tablaTmp);
                return dataSet;

            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrio un error al cargar el Iva de Devolución.\n" + ex.Message);
            }
        }

        public DataSet IvaDevolucion(DateTime fecha)
        {
            var miDaoIva = new DaoIva();
            var dataSet = new DataSet();
            var tabla = new DataTable();
            tabla.TableName = "IvaDevolucion";
            tabla.Columns.Add(new DataColumn("IvaD", typeof(string)));
            tabla.Columns.Add(new DataColumn("BaseD", typeof(double)));
            tabla.Columns.Add(new DataColumn("VIvaD", typeof(double)));
            tabla.Columns.Add(new DataColumn("SubTotalD", typeof(int)));
            try
            {
                var iva = miDaoIva.ListadoIva();
                var devoluciones = new DataTable();
                CargarAdapter("detalle_devolucion_venta_fecha");
                miAdapter.SelectCommand.Parameters.AddWithValue("fecha", fecha);
                miAdapter.Fill(devoluciones);
                foreach (Iva dIva in iva)
                {
                    foreach (DataRow dRow in devoluciones.Rows)
                    {
                        if (dIva.PorcentajeIva.Equals(
                            Convert.ToDouble(dRow["iva"])))
                        {
                            var tablaRow = tabla.NewRow();
                            tablaRow["IvaD"] = dRow["iva"].ToString();
                            var descto = Convert.ToDouble(dRow["descuento"]);
                            /*if (Convert.ToBoolean(dRow["aplica_descto"]))
                            {
                                descto = Convert.ToDouble(dRow["descuento"]);
                            }*/

                            /*var sTotal = Convert.ToInt32(dRow["valor"]) -
                                (Convert.ToInt32(dRow["valor"]) * descto / 100);*/
                            var sTotal = Math.Round((Convert.ToDouble(dRow["valor"]) -
                                (Convert.ToDouble(dRow["valor"]) * descto / 100)), 1);

                            double vIva = Math.Round((sTotal * Convert.ToDouble(dRow["iva"]) / 100), 1);

                            /*var valorMasIva = sTotal +
                                Convert.ToInt32(sTotal * Convert.ToDouble(dRow["iva"]) / 100);*/
                            var valorMasIva = Convert.ToInt32(sTotal + vIva);

                            var total = Convert.ToInt32(
                                valorMasIva * Convert.ToDouble(dRow["cantidad"]));


                            tablaRow["BaseD"] = Math.Round(total / (1 + (Convert.ToDouble(dRow["iva"]) / 100)), 1); // decima 2

                            var basb = Convert.ToDouble(tablaRow["BaseD"]);

                            tablaRow["VIvaD"] = Math.Round((Convert.ToDouble(tablaRow["BaseD"]) *
                                Convert.ToDouble(dRow["iva"]) / 100), 1);

                            var viva = Convert.ToDouble(tablaRow["VIvaD"]);

                            tablaRow["SubTotalD"] = Convert.ToDouble(tablaRow["BaseD"]) + Convert.ToDouble(tablaRow["VIvaD"]);


                            /*tablaRow["BaseD"] = sTotal * Convert.ToDouble(dRow["cantidad"]);

                            var b = tablaRow["BaseD"].ToString();

                            tablaRow["VIvaD"] = Convert.ToInt32(
                                       (sTotal * Convert.ToDouble(dRow["ivadevolucion_venta"]) / 100)
                                       * Convert.ToDouble(dRow["cantidad"]));

                            var v = tablaRow["VIvaD"].ToString();

                            tablaRow["SubTotalD"] = Convert.ToInt32(tablaRow["BaseD"]) + Convert.ToInt32(tablaRow["VIvaD"]);

                            var s = tablaRow["SubTotalD"].ToString();*/

                            tabla.Rows.Add(tablaRow);
                        }
                    }
                }
                IEnumerable<DataRow> query = from d in tabla.AsEnumerable()
                                             select d;
                DataTable tablaTmp = new DataTable();
                if (query.ToArray().Length != 0)
                {
                    tablaTmp = query.CopyToDataTable<DataRow>();
                }
                tablaTmp.TableName = "IvaDevolucion";
                tablaTmp.Rows.Clear();
                foreach (Iva tmpIva in iva)
                {
                    var tBase = tabla.AsEnumerable().Where(i => i.Field<string>("IvaD").
                        Equals(tmpIva.PorcentajeIva.ToString())).Sum(s => s.Field<double>("BaseD"));
                    var tIva = tabla.AsEnumerable().Where(i => i.Field<string>("IvaD").
                        Equals(tmpIva.PorcentajeIva.ToString())).Sum(s => s.Field<double>("VIvaD"));
                    var sTotal = tabla.AsEnumerable().Where(i => i.Field<string>("IvaD").
                        Equals(tmpIva.PorcentajeIva.ToString())).Sum(s => s.Field<int>("SubTotalD"));
                    if (tBase != 0)
                    {
                        var rowTmp = tablaTmp.NewRow();
                        rowTmp["IvaD"] = tmpIva.PorcentajeIva.ToString();
                        rowTmp["BaseD"] = tBase;
                        rowTmp["VIvaD"] = tIva;
                        rowTmp["SubTotalD"] = sTotal;
                        tablaTmp.Rows.Add(rowTmp);
                    }
                    //VIvaD
                }
                dataSet.Tables.Add(tablaTmp);
                return dataSet;

            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrio un error al cargar el Iva de Devolución.\n" + ex.Message);
            }
        }

        // Funciones de actualización 23/05/2018

        public List<IvaDevolucion> IvaDevoluciones(int idCaja, DateTime fecha)
        {
            try
            {
                var devoluciones = new List<ProductoFacturaProveedor>();
                this.CargarComando("detalle_devolucion_venta");
                this.miComando.Parameters.AddWithValue("", idCaja);
                this.miComando.Parameters.AddWithValue("", fecha);
                this.miConexion.MiConexion.Open();
                NpgsqlDataReader miReader = this.miComando.ExecuteReader();
                while (miReader.Read())
                {
                    var detalleDevolucion = new ProductoFacturaProveedor();
                    detalleDevolucion.IdFactura = miReader.GetInt32(4);
                    detalleDevolucion.Valor = miReader.GetDouble(9);
                    detalleDevolucion.Producto.Descuento = miReader.GetDouble(10);
                    detalleDevolucion.Producto.ValorIva = miReader.GetDouble(11);
                    detalleDevolucion.Cantidad = miReader.GetDouble(12);
                    detalleDevolucion.NumeroFactura = miReader.GetString(14);
                    devoluciones.Add(detalleDevolucion);
                }
                this.miConexion.MiConexion.Close();
                this.miComando.Dispose();

                return this.DetalleIvaDevolucion(devoluciones);
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al consultar el IVA en devoluciones.\n" + ex.Message);
            }
            finally { this.miConexion.MiConexion.Close(); }
        }

        public List<IvaDevolucion> IvaDevoluciones(DateTime fecha)
        {
            try
            {
                var devoluciones = new List<ProductoFacturaProveedor>();
                this.CargarComando("detalle_devolucion_venta_fecha");
                this.miComando.Parameters.AddWithValue("", fecha);
                this.miConexion.MiConexion.Open();
                NpgsqlDataReader miReader = this.miComando.ExecuteReader();
                while (miReader.Read())
                {
                    var detalleDevolucion = new ProductoFacturaProveedor();
                    detalleDevolucion.IdFactura = miReader.GetInt32(4);
                    detalleDevolucion.Valor = miReader.GetDouble(9);
                    detalleDevolucion.Producto.Descuento = miReader.GetDouble(10);
                    detalleDevolucion.Producto.ValorIva = miReader.GetDouble(11);
                    detalleDevolucion.Cantidad = miReader.GetDouble(12);
                    detalleDevolucion.NumeroFactura = miReader.GetString(14);
                    devoluciones.Add(detalleDevolucion);
                }
                this.miConexion.MiConexion.Close();
                this.miComando.Dispose();

                return this.DetalleIvaDevolucion(devoluciones);
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al consultar el IVA en devoluciones.\n" + ex.Message);
            }
            finally { this.miConexion.MiConexion.Close(); }
        }

        public List<IvaDevolucion> IvaDevoluciones(DateTime fecha, DateTime fecha2)
        {
            try
            {
                var devoluciones = new List<ProductoFacturaProveedor>();
                this.CargarComando("detalle_devolucion_venta_fecha");
                this.miComando.Parameters.AddWithValue("", fecha);
                this.miComando.Parameters.AddWithValue("", fecha2);
                this.miConexion.MiConexion.Open();
                NpgsqlDataReader miReader = this.miComando.ExecuteReader();
                while (miReader.Read())
                {
                    var detalleDevolucion = new ProductoFacturaProveedor();
                    detalleDevolucion.IdFactura = miReader.GetInt32(4);
                    detalleDevolucion.Valor = miReader.GetDouble(9);
                    detalleDevolucion.Producto.Descuento = miReader.GetDouble(10);
                    detalleDevolucion.Producto.ValorIva = miReader.GetDouble(11);
                    detalleDevolucion.Cantidad = miReader.GetDouble(12);
                    detalleDevolucion.NumeroFactura = miReader.GetString(14);
                    devoluciones.Add(detalleDevolucion);
                }
                this.miConexion.MiConexion.Close();
                this.miComando.Dispose();

                return this.DetalleIvaDevolucion(devoluciones);
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al consultar el IVA en devoluciones.\n" + ex.Message);
            }
            finally { this.miConexion.MiConexion.Close(); }
        }

        private List<IvaDevolucion> DetalleIvaDevolucion(List<ProductoFacturaProveedor> devoluciones)
        {
            var ivaDevoluciones = new List<IvaDevolucion>();
            foreach (var detalle in devoluciones)
            {
                var ivaDevolucion = new IvaDevolucion();
                ivaDevolucion.IdDevolucion = detalle.IdFactura;
                ivaDevolucion.NoFactura = detalle.NumeroFactura;
                ivaDevolucion.PorcentajeIva = detalle.Producto.ValorIva;
                ivaDevolucion.BaseI = Math.Round((detalle.Valor - (detalle.Valor * detalle.Producto.Descuento / 100)), 1);
                ivaDevolucion.ValorIva = Math.Round((ivaDevolucion.BaseI * detalle.Producto.ValorIva / 100), 1);
                ivaDevolucion.Total = Convert.ToInt32(
                    Convert.ToInt32(ivaDevolucion.BaseI + ivaDevolucion.ValorIva) * detalle.Cantidad);
                ivaDevoluciones.Add(ivaDevolucion);
            }

            var ivaDevolucionesFrv = ivaDevoluciones.Where(i => i.NoFactura != "");
            var ivaDevolucionesNoFrv = ivaDevoluciones.Where(i => i.NoFactura.Equals(""));

            var queryFrv = from data in ivaDevolucionesFrv
                           group data by new
                           {
                               NoFactura = data.NoFactura,
                               PorcentajeIva = data.PorcentajeIva
                           }
                               into grupo
                               orderby grupo.Key.NoFactura ascending, grupo.Key.PorcentajeIva ascending
                               select new
                               {
                                   NoFactura = grupo.Key.NoFactura,
                                   PorcentajeIva = grupo.Key.PorcentajeIva,
                                   Total = grupo.Sum(s => s.Total)
                               };
            var queryNoFrv = from data in ivaDevolucionesNoFrv
                             group data by new
                             {
                                 NoFactura = data.NoFactura,
                                 PorcentajeIva = data.PorcentajeIva
                             }
                                 into grupo
                                 orderby grupo.Key.NoFactura ascending, grupo.Key.PorcentajeIva ascending
                                 select new
                                 {
                                     NoFactura = grupo.Key.NoFactura,
                                     PorcentajeIva = grupo.Key.PorcentajeIva,
                                     Total = grupo.Sum(s => s.Total)
                                 };
            var dataIvaDevoluciones = new List<IvaDevolucion>();
            foreach (var ivaDevolucion in queryFrv)
            {
                dataIvaDevoluciones.Add(new IvaDevolucion
                {
                    NoFactura = ivaDevolucion.NoFactura,
                    PorcentajeIva = ivaDevolucion.PorcentajeIva,
                    BaseI = Math.Round(ivaDevolucion.Total / (1 + (ivaDevolucion.PorcentajeIva / 100)), 0),
                    ValorIva = ivaDevolucion.Total - Math.Round(ivaDevolucion.Total / (1 + (ivaDevolucion.PorcentajeIva / 100)), 0),
                    Total = ivaDevolucion.Total
                });
            }
            foreach (var ivaDevolucion in queryNoFrv)
            {
                dataIvaDevoluciones.Add(new IvaDevolucion
                {
                    NoFactura = ivaDevolucion.NoFactura,
                    PorcentajeIva = ivaDevolucion.PorcentajeIva,
                    BaseI = Math.Round(ivaDevolucion.Total / (1 + (ivaDevolucion.PorcentajeIva / 100)), 0),
                    ValorIva = ivaDevolucion.Total - Math.Round(ivaDevolucion.Total / (1 + (ivaDevolucion.PorcentajeIva / 100)), 0),
                    Total = ivaDevolucion.Total
                });
            }
            return dataIvaDevoluciones;
        }

        // Fin funciones de actualización 23/05/2018


        public int TotalDevoluciones(DateTime fecha, DateTime fecha2, int idCaja, int idTurno)
        {
            try
            {
                CargarComando("total_devolucion_venta_efectivo");
                miComando.Parameters.AddWithValue("", fecha);
                miComando.Parameters.AddWithValue("", fecha2);
                miComando.Parameters.AddWithValue("", fecha.TimeOfDay);
                miComando.Parameters.AddWithValue("", idCaja);
                miComando.Parameters.AddWithValue("", idTurno);
                miConexion.MiConexion.Open();
                var total = Convert.ToInt32(miComando.ExecuteScalar());
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
                throw new Exception("Ocurrio un error al consultar las devoluciones.\n" + ex.Message);
            }
            finally { miConexion.MiConexion.Close(); }
        }

        public int TotalDevolucionesComplemento(DateTime fecha, DateTime fecha2, int idCaja, int idTurno)
        {
            try
            {
                CargarComando("total_devolucion_venta_efectivo_complemento");
                miComando.Parameters.AddWithValue("", fecha);
                miComando.Parameters.AddWithValue("", fecha2);
                miComando.Parameters.AddWithValue("", fecha2.TimeOfDay);
                miComando.Parameters.AddWithValue("", idCaja);
                miComando.Parameters.AddWithValue("", idTurno);
                miConexion.MiConexion.Open();
                var total = Convert.ToInt32(miComando.ExecuteScalar());
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
                throw new Exception("Ocurrio un error al consultar las devoluciones.\n" + ex.Message);
            }
            finally { miConexion.MiConexion.Close(); }
        }

        public int TotalDevoluciones(DateTime fecha, int idCaja, int idTurno)
        {
            try
            {
                CargarComando("total_devolucion_venta_efectivo");
                miComando.Parameters.AddWithValue("", fecha);
                miComando.Parameters.AddWithValue("", idCaja);
                miComando.Parameters.AddWithValue("", idTurno);
                miConexion.MiConexion.Open();
                var total = Convert.ToInt32(miComando.ExecuteScalar());
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
                throw new Exception("Ocurrio un error al consultar las devoluciones.\n" + ex.Message);
            }
            finally { miConexion.MiConexion.Close(); }
        }

        public int TotalDevolucionesHoras(DateTime fecha, DateTime fecha2, int idCaja, int idTurno)
        {
            try
            {
                CargarComando("total_devolucion_venta_efectivo_horas");
                miComando.Parameters.AddWithValue("", idCaja);
                miComando.Parameters.AddWithValue("", idTurno);
                miComando.Parameters.AddWithValue("", fecha);
                miComando.Parameters.AddWithValue("", fecha2);
                miConexion.MiConexion.Open();
                var total = Convert.ToInt32(miComando.ExecuteScalar());
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
                throw new Exception("Ocurrio un error al consultar las devoluciones.\n" + ex.Message);
            }
            finally { miConexion.MiConexion.Close(); }
        }

        public int TotalDevolucionRemision(int idCaja, DateTime fecha, DateTime fecha2)
        {
            try
            {
                string sql = "select " +
                              "SUM" +
                              "(" +
                              "mi_round_trunc " +
                              "(     " +
                                "devolucion_remision.valor  " +
                                "+ " +
                                "mi_round " +
                                "( " +
                                   "devolucion_remision.valor " +
                                   "* devolucion_remision.iva / 100, 1 " +
                                ")  " +
                                 "* devolucion_remision.cantidad, 0 " +
                              ") " +
                              ") AS total  " +
                            "from  " +
                              "devolucion_remision  " +
                            "where  " +
                            "idcaja = @caja and  " +
                            "fecha + hora between @fecha and @fecha2;";
                CargarComandoText(sql);
                miComando.Parameters.AddWithValue("caja", idCaja);
                miComando.Parameters.AddWithValue("fecha", fecha);
                miComando.Parameters.AddWithValue("fecha2", fecha2);
                miConexion.MiConexion.Open();
                var total = Convert.ToInt32(miComando.ExecuteScalar());
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
                throw new Exception("Ocurrio un error al consultar las devoluciones.\n" + ex.Message);
            }
            finally { miConexion.MiConexion.Close(); }
        }

        /// <summary>
        /// Obtiene la consulta de las devoluciones según el número de la factura.
        /// </summary>
        /// <param name="numero">Número de la factura a consultar.</param>
        /// <returns></returns>
        public DataTable ConsultaFactura(string numero)
        {
            var tablaDb = new DataTable();
            try
            {
                CargarAdapter("consulta_devolucion_venta");
                miAdapter.SelectCommand.Parameters.AddWithValue("numero", numero);
                miAdapter.Fill(tablaDb);
                return tablaDb;// CalculosEnTabla(tablaDb);
            }
            catch (Exception ex)
            {
                throw new Exception(ErrorConsulta + ex.Message);
            }
        }

        /// <summary>
        /// Obtiene la consulta de las devoluciones según una fecha.
        /// </summary>
        /// <param name="fecha">Fecha a la cual se le hace la consulta.</param>
        /// <param name="saldo">Indica si la consulta es a devoluciones con saldo o canceladas.</param>
        /// <returns></returns>
        public DataTable ConsultaFecha(DateTime fecha, bool saldo)
        {
            var tabla = new DataTable();
            try
            {
                if (saldo)
                {
                    CargarAdapter(ConsultaFechaSaldo);
                }
                else
                {
                    CargarAdapter(ConsultaFecha_);
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

        /// <summary>
        /// Obtiene la consulta de las devoluciones según el número de la factura.
        /// </summary>
        /// <param name="numero">Número de la factura a consultar.</param>
        /// <param name="saldo">Indica si la consulta es a devoluciones con saldo o canceladas.</param>
        /// <returns></returns>
        public DataTable ConsultaFactura(string numero, bool saldo)
        {
            var tabla = new DataTable();
            try
            {
                if (saldo)
                {
                    CargarAdapter(ConsultaFacturaVentaSaldo);
                }
                else
                {
                    CargarAdapter(ConsultaFacturaVenta);
                }
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
        /// Obtiene la consulta de las devoluciones según el Nit del cliente.
        /// </summary>
        /// <param name="nit">Nit del cliente a consultar.</param>
        /// <param name="saldo">Indica si la consulta es a devoluciones con saldo o canceladas.</param>
        /// <param name="rowBase">Registro base para la consulta.</param>
        /// <param name="rowMax">Número de registros a recuperar.</param>
        /// <returns></returns>
        public DataTable ConsultaCliente(string nit, bool saldo, int rowBase, int rowMax)
        {
            var tabla = new DataTable();
            try
            {
                if (saldo)
                {
                    CargarAdapter(ConsultaClienteSaldo);
                }
                else
                {
                    CargarAdapter(ConsultaCliente_);
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

        /// <summary>
        /// Obtiene el total de registros de la consulta de las devoluciones según el Nit del cliente.
        /// </summary>
        /// <param name="nit">Nit del cliente a consultar.</param>
        /// <param name="saldo">Indica si la consulta es a devoluciones con saldo o canceladas.</param>
        /// <returns></returns>
        public long GetRowsConsultaCliente(string nit, bool saldo)
        {
            try
            {
                if (saldo)
                {
                    CargarComando(CountConsultaClienteSaldo);
                }
                else
                {
                    CargarComando(CountConsultaCliente);
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

        /// <summary>
        /// Obtiene el total de registros de la consulta de las devoluciones según el nombre del cliente.
        /// </summary>
        /// <param name="nombre">Nombre del cliente a consultar.</param>
        /// <param name="saldo">Indica si la consulta es a devoluciones con saldo o canceladas.</param>
        /// <param name="rowBase">Registro base para la consulta.</param>
        /// <param name="rowMax">Número de registros a recuperar.</param>
        /// <returns></returns>
        public DataTable ConsultaClienteName(string nombre, bool saldo, int rowBase, int rowMax)
        {
            var tabla = new DataTable();
            try
            {
                if (saldo)
                {
                    CargarAdapter(ConsultaClienteNaSaldo);
                }
                else
                {
                    CargarAdapter(ConsultaClienteNa_);
                }
                miAdapter.SelectCommand.Parameters.AddWithValue("nombre", nombre);
                miAdapter.Fill(rowBase, rowMax, tabla);
                return tabla;
            }
            catch (Exception ex)
            {
                throw new Exception(ErrorConsulta + ex.Message);
            }
        }

        /// <summary>
        /// Obtiene el total de registros de la consulta de las devoluciones según el nombre del cliente.
        /// </summary>
        /// <param name="nombre">Nombre del cliente a consultar.</param>
        /// <param name="saldo">Indica si la consulta es a devoluciones con saldo o canceladas.</param>
        /// <returns></returns>
        public long GetRowsConsultaClienteName(string nombre, bool saldo)
        {
            try
            {
                if (saldo)
                {
                    CargarComando(CountConsultaClienteNaSaldo);
                }
                else
                {
                    CargarComando(CountConsultaClienteNa_);
                }
                miComando.Parameters.AddWithValue("nombre", nombre);
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

        private DataTable TablaVenta()
        {
            var tabla = new DataTable();
            tabla.Columns.Add(new DataColumn("Id", typeof(int)));
            tabla.Columns.Add(new DataColumn("Codigo", typeof(string)));
            tabla.Columns.Add(new DataColumn("Producto", typeof(string)));
            tabla.Columns.Add(new DataColumn("Cantidad", typeof(double)));
            tabla.Columns.Add(new DataColumn("Valor", typeof(int)));
            tabla.Columns.Add(new DataColumn("SubTotal", typeof(int)));
            return tabla;
        }

        #endregion

        #region Devolucion Remisión

        public void IngresarRemision(Devolucion devolucion)
        {
            try
            {
                CargarComando(IngresarRemision_);
                miComando.Parameters.AddWithValue("usuario", devolucion.IdUsuario);
                miComando.Parameters.AddWithValue("caja", devolucion.IdCaja);
                miComando.Parameters.AddWithValue("numero", Convert.ToInt32(devolucion.Factura));
                miComando.Parameters.AddWithValue("fecha", devolucion.Fecha);
                miComando.Parameters.AddWithValue("codigo", devolucion.Producto.CodigoProducto);
                miComando.Parameters.AddWithValue("medida", devolucion.Producto.IdMedida);
                miComando.Parameters.AddWithValue("color", devolucion.Producto.IdColor);
                miComando.Parameters.AddWithValue("valor", devolucion.Valor);
                miComando.Parameters.AddWithValue("iva", devolucion.Iva);
                miComando.Parameters.AddWithValue("aplicadescto", devolucion.Descuento);
                miComando.Parameters.AddWithValue("descto", devolucion.Descto);
                miComando.Parameters.AddWithValue("cantidad", devolucion.Cantidad);
                miComando.Parameters.AddWithValue("hora", devolucion.Fecha.TimeOfDay);
                miConexion.MiConexion.Open();
                miComando.ExecuteNonQuery();
                miConexion.MiConexion.Close();
                miComando.Dispose();
                var inventario = devolucion.Producto;
                inventario.Cantidad = devolucion.Cantidad;
                miDaoInventario.ActualizarInventario(inventario, false);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally { miConexion.MiConexion.Close(); }
        }

        /// <summary>
        /// Obtiene el resultado de la consulta de una Devolución de Remisión.
        /// </summary>
        /// <param name="numero">Número de Remisión a consultar.</param>
        /// <returns></returns>
        public DataTable ConsultaRemision(int numero)
        {
            var tablaDB = new DataTable();
            try
            {
                CargarAdapter(ConsultaRemision_);
                miAdapter.SelectCommand.Parameters.AddWithValue("numero", numero);
                miAdapter.Fill(tablaDB);
                return CalculosEnTabla(tablaDB);
            }
            catch (Exception ex)
            {
                throw new Exception(ErrorConsultaR + ex.Message);
            }
        }

        public int SaldoRemision(int numero)
        {
            try
            {
                var tabla = ConsultaRemision(numero);
                return tabla.AsEnumerable().Sum(t => t.Field<int>("total"));
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al consultar el saldo de devolución.\n" + ex.Message);
            }
        }

        private DataTable CalculosEnTabla(DataTable tabla)
        {
            var tabla_ = TablaRemision();
            foreach (DataRow row in tabla.Rows)
            {
                var row_ = tabla_.NewRow();
                row_["id"] = row["id"];
                row_["fecha"] = row["fecha"];
                row_["numero"] = row["numero"];
                row_["nit"] = row["nit"];
                row_["cliente"] = row["cliente"];
                row_["codigo"] = row["codigo"];
                row_["producto"] = row["producto"];
                row_["idmedida"] = row["idmedida"];
                row_["idcolor"] = row["idcolor"];
                row_["cantidad"] = row["cantidad"];
                row_["descuento"] = row["descuento"].ToString() + "%";
                row_["aplica_descto"] = row["aplica_descto"];
                if (Convert.ToBoolean(row["aplica_descto"]))
                {
                    row_["valor"] = Convert.ToInt32(row["valor"]) -
                        (Convert.ToInt32(row["valor"]) * Convert.ToDouble(row["descuento"]) / 100);
                }
                else
                {
                    row_["valor"] = row["valor"];
                }
                row_["iva"] = row["iva"];
                row_["valorIva"] = (Convert.ToInt32(row["valor"]) * Convert.ToDouble(row["iva"]) / 100);
                row_["ValorUnit"] = Convert.ToInt32(row["valor"]) + Convert.ToInt32(row_["valorIva"]);
                row_["total"] = (Convert.ToInt32(row["valor"]) + Convert.ToInt32(row_["valorIva"])) *
                                 Convert.ToInt32(row["cantidad"]);
                tabla_.Rows.Add(row_);
            }
            return tabla_;
        }

        private DataTable TablaRemision()
        {
            var tabla = new DataTable();
            tabla.Columns.Add(new DataColumn("id", typeof(int)));
            tabla.Columns.Add(new DataColumn("fecha", typeof(DateTime)));
            tabla.Columns.Add(new DataColumn("numero", typeof(int)));
            tabla.Columns.Add(new DataColumn("nit", typeof(string)));
            tabla.Columns.Add(new DataColumn("cliente", typeof(string)));
            tabla.Columns.Add(new DataColumn("codigo", typeof(string)));
            tabla.Columns.Add(new DataColumn("producto", typeof(string)));
            tabla.Columns.Add(new DataColumn("idmedida", typeof(int)));
            tabla.Columns.Add(new DataColumn("idcolor", typeof(int)));
            tabla.Columns.Add(new DataColumn("cantidad", typeof(double)));
            tabla.Columns.Add(new DataColumn("valor", typeof(int)));
            tabla.Columns.Add(new DataColumn("iva", typeof(double)));
            tabla.Columns.Add(new DataColumn("aplica_descto", typeof(bool)));
            tabla.Columns.Add(new DataColumn("descuento", typeof(string)));

            tabla.Columns.Add(new DataColumn("efectiva", typeof(bool)));

            //tabla.Columns.Add(new DataColumn("valorMenosDescto", typeof(double)));
            tabla.Columns.Add(new DataColumn("ValorUnit", typeof(int)));
            tabla.Columns.Add(new DataColumn("valorIva", typeof(double)));
            tabla.Columns.Add(new DataColumn("total", typeof(int)));
            return tabla;
        }

        #endregion

        #region Saldos en Devolucion Venta

        public int IngresarSaldoDevolucionVenta
            (string factura, int valor, int idUsuario, int idCaja, DateTime fecha)
        {
            try
            {
                CargarComando("insertar_saldo_devolucion_venta");
                miComando.Parameters.AddWithValue("factura", factura);
                miComando.Parameters.AddWithValue("valor", valor);
                miComando.Parameters.AddWithValue("usuario", idUsuario);
                miComando.Parameters.AddWithValue("caja", idCaja);
                miComando.Parameters.AddWithValue("fecha", fecha);
                miConexion.MiConexion.Open();
                var id = Convert.ToInt32(miComando.ExecuteScalar());
                miConexion.MiConexion.Close();
                miComando.Dispose();
                return id;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al ingresar el saldo de la Devolución\n" + ex.Message);
            }
            finally { miConexion.MiConexion.Close(); }
        }

        public List<Ingreso> IngresarSaldoGeneralDevolucionVenta
            (string cliente, ref int valor, int idUsuario, int idCaja, DateTime fecha)
        {
            var daoFacturaVenta = new DaoFacturaVenta();
            var arrIngreso = new List<Ingreso>();
            try
            {
                var facturas = daoFacturaVenta.ConsultaActivasPorCliente(cliente);
                var qFacturas = from data in facturas.AsEnumerable()
                                orderby data.Field<DateTime>("fecha") ascending
                                select data;
                foreach (DataRow fRow in qFacturas)
                {
                    if (valor > 0)
                    {
                        var productos = daoFacturaVenta.ProductoFacturaVenta(Convert.ToInt32(fRow["id"]), Convert.ToBoolean(fRow["descto"]));
                        var valorFactura = Convert.ToInt32(
                            productos.AsEnumerable().Sum(s => s.Field<double>("Valor")));
                        //var pPago = daoFacturaVenta.GetTotalFormasDePagoDeFacturaVenta(fRow["numero"].ToString());
                        var pPago = daoFacturaVenta.GetTotalFormasDePagoDeFacturaVenta(Convert.ToInt32(fRow["id"]));
                        var saldoDev = SaldoDevolucionVenta(Convert.ToInt32(fRow["id"]));
                        if (valorFactura > (pPago + saldoDev))
                        {
                            if (valor > (valorFactura - (pPago + saldoDev)))
                            {
                                var id =
                                IngresarSaldoDevolucionVenta
                                    (fRow["numero"].ToString(), (valorFactura - (pPago + saldoDev)), idUsuario, idCaja, fecha);
                                arrIngreso.Add(new Ingreso
                                {
                                    Id = id,
                                    Numero = fRow["numero"].ToString(),
                                    Valor = valorFactura - (pPago + saldoDev)
                                });
                                valor -= (valorFactura - (pPago + saldoDev));
                            }
                            else
                            {
                                var id =
                                    IngresarSaldoDevolucionVenta(fRow["numero"].ToString(), valor, idUsuario, idCaja, fecha);
                                arrIngreso.Add(new Ingreso
                                {
                                    Id = id,
                                    Numero = fRow["numero"].ToString(),
                                    Valor = valor
                                });
                                valor = 0;
                            }
                        }
                    }
                }
                return arrIngreso;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al ingresar el Saldo a Devolución.\n" + ex.Message);
            }
        }



        public int SaldoDevolucionVenta(string factura)
        {
            var tabla = new DataTable();
            try
            {
                CargarAdapter("saldos_devolucion_venta");
                miAdapter.SelectCommand.Parameters.AddWithValue("factura", factura);
                miAdapter.Fill(tabla);
                var saldo = 0;
                if (tabla.Rows.Count != 0)
                {
                    saldo = tabla.AsEnumerable().Sum(s => s.Field<int>("valor"));
                }
                return saldo;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrio" + ex.Message);
            }
        }

        public Saldo SaldoDevolucionVenta(string factura, bool data)
        {
            var tabla = new DataTable();
            try
            {
                CargarAdapter("saldos_devolucion_venta");
                miAdapter.SelectCommand.Parameters.AddWithValue("factura", factura);
                miAdapter.Fill(tabla);
                var saldo = new Saldo();
                if (tabla.Rows.Count != 0)
                {
                    var row = (from d in tabla.AsEnumerable()
                               select d).Single();
                    saldo.Id = Convert.ToInt32(row["id"]);
                    saldo.NitCliente = row["numero_factura"].ToString();
                    saldo.Valor = Convert.ToInt32(row["valor"]);
                }
                return saldo;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrio" + ex.Message);
            }
        }

        public DataTable SaldosDeDevolucionVenta(int id)
        {
            var tabla = new DataTable();
            try
            {
                CargarAdapter("saldos_devolucion_venta");
                miAdapter.SelectCommand.Parameters.AddWithValue("id", id);
                miAdapter.Fill(tabla);
                return tabla;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al consultar los Saldos de Devolución.\n" + ex.Message);
            }
        }

        public int SaldoDevolucionVenta(int id)
        {
            var tabla = new DataTable();
            try
            {
                CargarAdapter("saldos_devolucion_venta");
                miAdapter.SelectCommand.Parameters.AddWithValue("", id);
                miAdapter.Fill(tabla);
                var saldo = 0;
                if (tabla.Rows.Count != 0)
                {
                    saldo = tabla.AsEnumerable().Sum(s => s.Field<int>("valor"));
                }
                return saldo;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrio" + ex.Message);
            }
        }

        public DataTable SaldosDeDevolucion(int idCaja, DateTime fecha)
        {
            var tabla = new DataTable();
            try
            {
                CargarAdapter("saldos_por_devolucion");
                miAdapter.SelectCommand.Parameters.AddWithValue("caja", idCaja);
                miAdapter.SelectCommand.Parameters.AddWithValue("fecha", fecha);
                miAdapter.Fill(tabla);
                return tabla;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al consultar los Saldos de Devolución.\n" + ex.Message);
            }
        }

        #endregion

        #region Devolucion Compra

        public int IngresarCompra(FacturaProveedor devolucion)
        {
            var daoConsecutivo = new DaoConsecutivo();
            try
            {
                CargarComando("ingresar_devolucion_proveedor");
                // miComando.Parameters.AddWithValue("idFactura", devolucion.Id);
                miComando.Parameters.AddWithValue("numero", devolucion.Numero);
                miComando.Parameters.AddWithValue("fecha", devolucion.FechaIngreso);
                miComando.Parameters.AddWithValue("idUsuario", devolucion.Usuario.Id);
                miComando.Parameters.AddWithValue("idCaja", devolucion.Caja.Id);
                miComando.Parameters.AddWithValue("proveedor", devolucion.Proveedor.CodigoInternoProveedor);
                miComando.Parameters.AddWithValue("concepto", devolucion.Proveedor.DescripcionProveedor);
                miComando.Parameters.AddWithValue("saldada", devolucion.Estado);
                miComando.Parameters.AddWithValue("idfactura", devolucion.Id);
                miConexion.MiConexion.Open();
                var id = Convert.ToInt32(miComando.ExecuteScalar());
                miConexion.MiConexion.Close();
                miComando.Dispose();
                daoConsecutivo.ActualizarConsecutivo("NotaCredito");
                foreach (var detalle in devolucion.Productos)
                {
                    detalle.IdFactura = id;
                    IngresarDetalleCompra(detalle);
                    miDaoInventario.ActualizarInventario(detalle.Inventario, true);

                    Kardex.Codigo = detalle.Inventario.CodigoProducto;
                    Kardex.IdUsuario = devolucion.Usuario.Id;
                    Kardex.IdConcepto = 12;
                    Kardex.NoDocumento = devolucion.Numero;
                    Kardex.Fecha = DateTime.Now;
                    Kardex.Cantidad = detalle.Inventario.Cantidad;
                    /*double iva = Math.Round(
                        (detalle.Producto.ValorVentaProducto * detalle.Producto.ValorIva / 100), 2);
                    Kardex.Valor = detalle.Producto.ValorVentaProducto + Convert.ToInt32(iva);*/
                    Kardex.Valor = detalle.Producto.ValorVentaProducto;
                    Kardex.Total = Kardex.Cantidad * Kardex.Valor;
                    miDaoKardex.Insertar(Kardex);
                }
                return id;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al ingresar la devolución de compra.\n" + ex.Message);
            }
            finally { miConexion.MiConexion.Close(); }
        }

        public void IngresarDetalleCompra(ProductoFacturaProveedor detalle)
        {
            try
            {
                CargarComando("ingresar_detalle_devolucion_proveedor");
                miComando.Parameters.AddWithValue("idDevolucion", detalle.IdFactura);
                miComando.Parameters.AddWithValue("codigo", detalle.Inventario.CodigoProducto);
                miComando.Parameters.AddWithValue("medida", detalle.Inventario.IdMedida);
                miComando.Parameters.AddWithValue("color", detalle.Inventario.IdColor);
                miComando.Parameters.AddWithValue("valor", detalle.Producto.ValorCosto);
                miComando.Parameters.AddWithValue("descto", detalle.Producto.Descuento);
                miComando.Parameters.AddWithValue("iva", detalle.Producto.ValorIva);
                miComando.Parameters.AddWithValue("cantidad", detalle.Inventario.Cantidad);
                miConexion.MiConexion.Open();
                miComando.ExecuteNonQuery();
                miConexion.MiConexion.Close();
                miComando.Dispose();
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al ingresar el detalle de la devolución de compra.\n" + ex.Message);
            }
            finally { miConexion.MiConexion.Close(); }
        }


        public FacturaProveedor DevolucionesDeCompra(int id)
        {
            try
            {
                var devolucion = new FacturaProveedor();
                CargarComando("devoluciones_proveedor");
                miComando.Parameters.AddWithValue("id", id);
                miConexion.MiConexion.Open();
                NpgsqlDataReader miReader = miComando.ExecuteReader();
                while (miReader.Read())
                {
                    devolucion.Id = miReader.GetInt32(0);
                    devolucion.Numero = miReader.GetString(1);
                    devolucion.FechaIngreso = miReader.GetDateTime(2);
                    devolucion.Usuario.Id = miReader.GetInt32(3);
                    devolucion.Caja.Id = miReader.GetInt32(4);
                    devolucion.Proveedor.CodigoInternoProveedor = miReader.GetInt32(5);
                    devolucion.Proveedor.NitProveedor = miReader.GetString(6);
                    devolucion.Proveedor.RazonSocialProveedor = miReader.GetString(7);
                    devolucion.Proveedor.DescripcionProveedor = miReader.GetString(8);
                }
                miConexion.MiConexion.Close();
                miComando.Dispose();
                return devolucion;

                /** miComando.Parameters.AddWithValue("numero", devolucion.Numero);
                miComando.Parameters.AddWithValue("fecha", devolucion.FechaIngreso);
                miComando.Parameters.AddWithValue("idUsuario", devolucion.Usuario.Id);
                miComando.Parameters.AddWithValue("idCaja", devolucion.Caja.Id);
                miComando.Parameters.AddWithValue("proveedor", devolucion.Proveedor.CodigoInternoProveedor);
                miComando.Parameters.AddWithValue("concepto", devolucion.Proveedor.DescripcionProveedor);*/
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al consultar la devolución.\n" + ex.Message);
            }
            finally { miConexion.MiConexion.Close(); }
        }

        public DataTable DevolucionesDeCompra(string numero)
        {
            try
            {
                var tabla = new DataTable();
                CargarAdapter("devoluciones_proveedor");
                miAdapter.SelectCommand.Parameters.AddWithValue("numero", numero);
                miAdapter.Fill(tabla);
                return tabla;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al consultar la devolución.\n" + ex.Message);
            }
        }

        public DataTable DevolucionesDeCompraProveedor(string proveedor, int rowBase, int rowMax)
        {
            try
            {
                var tabla = new DataTable();
                CargarAdapter("devoluciones_proveedor_proveedor");
                miAdapter.SelectCommand.Parameters.AddWithValue("proveedor", proveedor);
                miAdapter.Fill(rowBase, rowMax, tabla);
                return tabla;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al consultar la devolución.\n" + ex.Message);
            }
        }

        public long GetRowsDevolucionesDeCompraProveedor(string proveedor)
        {
            try
            {
                CargarComando("count_devoluciones_proveedor_proveedor");
                miComando.Parameters.AddWithValue("proveedor", proveedor);
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

        public DataTable DevolucionesDeCompra(DateTime fecha, int rowBase, int rowMax)
        {
            try
            {
                var tabla = new DataTable();
                CargarAdapter("devoluciones_proveedor_fecha");
                miAdapter.SelectCommand.Parameters.AddWithValue("fecha", fecha);
                miAdapter.Fill(rowBase, rowMax, tabla);
                return tabla;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al consultar la devolución.\n" + ex.Message);
            }
        }

        public long GetRowsDevolucionesDeCompra(DateTime fecha)
        {
            try
            {
                CargarComando("count_devoluciones_proveedor_fecha");
                miComando.Parameters.AddWithValue("fecha", fecha);
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

        public DataTable DevolucionesDeCompra(DateTime fecha, DateTime fecha2, int rowBase, int rowMax)
        {
            try
            {
                var tabla = new DataTable();
                CargarAdapter("devoluciones_proveedor_periodo");
                miAdapter.SelectCommand.Parameters.AddWithValue("fecha", fecha);
                miAdapter.SelectCommand.Parameters.AddWithValue("fecha2", fecha2);
                miAdapter.Fill(rowBase, rowMax, tabla);
                return tabla;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al consultar la devolución.\n" + ex.Message);
            }
        }

        public long GetRowsDevolucionesDeCompra(DateTime fecha, DateTime fecha2)
        {
            try
            {
                CargarComando("count_devoluciones_proveedor_periodo");
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
                throw new Exception("Ocurrió un error al cargar el total de registros.\n" + ex.Message);
            }
            finally { miConexion.MiConexion.Close(); }
        }


        public DataTable DetalleDevolucionCompra_(int idDevolucion)
        {
            var tabla = new DataTable();
            tabla.TableName = "Detalle";
            tabla.Columns.Add(new DataColumn("Codigo", typeof(string)));
            tabla.Columns.Add(new DataColumn("Cantidad", typeof(double)));
            tabla.Columns.Add(new DataColumn("Producto", typeof(string)));
            tabla.Columns.Add(new DataColumn("ValorUnit", typeof(int)));
            tabla.Columns.Add(new DataColumn("Valor_", typeof(double)));
            tabla.Columns.Add(new DataColumn("Descuento", typeof(double)));
            tabla.Columns.Add(new DataColumn("ValorDesto", typeof(int)));
            tabla.Columns.Add(new DataColumn("ValorMenosDesto", typeof(double)));
            tabla.Columns.Add(new DataColumn("ValorIva", typeof(int)));
            tabla.Columns.Add(new DataColumn("Total_", typeof(double)));
            try
            {
                var tbTmp = new DataTable();
                CargarAdapter("detalles_devolucion_proveedor");
                miAdapter.SelectCommand.Parameters.AddWithValue("idDevolucion", idDevolucion);
                miAdapter.Fill(tbTmp);
                foreach (DataRow row in tbTmp.Rows)
                {
                    var row_ = tabla.NewRow();
                    row_["Codigo"] = row["codigointernoproducto"];
                    row_["Cantidad"] = row["cantidad"];
                    row_["Producto"] = row["nombreproducto"];
                    row_["ValorUnit"] = row["valor"];
                    row_["Descuento"] = row["descuento"];
                    row_["ValorDesto"] = Convert.ToDouble(
                        Convert.ToInt32(row["valor"]) * Convert.ToDouble(row["descuento"]) / 100);

                    var j = row_["ValorUnit"].ToString();

                    //row_["ValorMenosDesto"] = Convert.ToInt32(row_["ValorUnit"]) - Convert.ToInt32(row_["ValorDesto"]);
                    row_["ValorMenosDesto"] = Convert.ToDouble(Convert.ToInt32(row_["ValorUnit"]) -
                        (Convert.ToInt32(row_["ValorUnit"]) * Convert.ToDouble(row["descuento"]) / 100));

                    j = row_["ValorMenosDesto"].ToString();

                    var cal = Convert.ToInt32(row_["ValorMenosDesto"]) * Convert.ToDouble(row["iva"]);

                    row_["ValorIva"] = (cal / 100);// *Convert.ToDouble(row["cantidad"]);

                    j = row_["ValorIva"].ToString();

                    row_["Valor_"] = Convert.ToDouble((Convert.ToDouble(row_["ValorMenosDesto"]) *
                                     Convert.ToDouble(row["Iva"]) / 100) +
                                     Convert.ToDouble(row_["ValorMenosDesto"]));
                    j = row_["Valor_"].ToString();
                    //row_["Valor_"] = Convert.ToInt32(row_["ValorMenosDesto"]) + Convert.ToInt32(row_["ValorIva"]);

                    row_["Total_"] = Convert.ToDouble(
                        Convert.ToDouble(row_["Valor_"]) * Convert.ToDouble(row_["Cantidad"]));
                    j = row_["Total_"].ToString();
                    //row_["Total_"] = Convert.ToInt32(row_["Valor_"]) * Convert.ToDouble(row_["Cantidad"]);

                    tabla.Rows.Add(row_);
                }
                return tabla;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al cargar el detalle de la devolución.\n" + ex.Message);
            }
        }

        // Edicion mejoras en calculo de valores 07-05-2017
        public DataTable DetalleDevolucionCompra(int idDevolucion)
        {
            var tabla = new DataTable();
            tabla.TableName = "Detalle";
            tabla.Columns.Add(new DataColumn("Codigo", typeof(string)));
            tabla.Columns.Add(new DataColumn("Cantidad", typeof(double)));
            tabla.Columns.Add(new DataColumn("Producto", typeof(string)));
            tabla.Columns.Add(new DataColumn("ValorUnit", typeof(double)));
            tabla.Columns.Add(new DataColumn("Valor_", typeof(double)));
            tabla.Columns.Add(new DataColumn("Descuento", typeof(double)));
            tabla.Columns.Add(new DataColumn("ValorDesto", typeof(double)));
            tabla.Columns.Add(new DataColumn("ValorMenosDesto", typeof(double)));
            tabla.Columns.Add(new DataColumn("ValorIva", typeof(double)));
            tabla.Columns.Add(new DataColumn("Total_", typeof(double)));
            try
            {
                var tbTmp = new DataTable();
                CargarAdapter("detalles_devolucion_proveedor");
                miAdapter.SelectCommand.Parameters.AddWithValue("idDevolucion", idDevolucion);
                miAdapter.Fill(tbTmp);
                foreach (DataRow row in tbTmp.Rows)
                {
                    var row_ = tabla.NewRow();
                    row_["Codigo"] = row["codigointernoproducto"];
                    row_["Cantidad"] = row["cantidad"];
                    row_["Producto"] = row["nombreproducto"];
                    row_["ValorUnit"] = row["valor"];
                    row_["Descuento"] = row["descuento"];
                    row_["ValorDesto"] = Math.Round(Convert.ToDouble(
                        Convert.ToDouble(row["valor"]) * Convert.ToDouble(row["descuento"]) / 100), 2);

                    var j = row_["ValorUnit"].ToString();

                    row_["ValorMenosDesto"] = Math.Round(Convert.ToDouble(Convert.ToDouble(row_["ValorUnit"]) -
                        (Convert.ToDouble(row_["ValorUnit"]) * Convert.ToDouble(row["descuento"]) / 100)), 2);
                    /*row_["ValorMenosDesto"] = Convert.ToDouble(Convert.ToInt32(row_["ValorUnit"]) -
                        (Convert.ToInt32(row_["ValorUnit"]) * Convert.ToDouble(row["descuento"]) / 100));*/

                    j = row_["ValorMenosDesto"].ToString();

                    var cal = Math.Round((Convert.ToDouble(row_["ValorMenosDesto"]) * Convert.ToDouble(row["iva"])), 2);

                    row_["ValorIva"] = Math.Round((cal / 100), 2);// *Convert.ToDouble(row["cantidad"]);

                    j = row_["ValorIva"].ToString();

                    row_["Valor_"] = Math.Round(Convert.ToDouble((Convert.ToDouble(row_["ValorMenosDesto"]) *
                                     Convert.ToDouble(row["Iva"]) / 100) +
                                     Convert.ToDouble(row_["ValorMenosDesto"])), 2);
                    j = row_["Valor_"].ToString();
                    //row_["Valor_"] = Convert.ToInt32(row_["ValorMenosDesto"]) + Convert.ToInt32(row_["ValorIva"]);

                    row_["Total_"] = Math.Round(Convert.ToDouble(
                        Convert.ToDouble(row_["Valor_"]) * Convert.ToDouble(row_["Cantidad"])), 2);

                    j = row_["Total_"].ToString();
                    //row_["Total_"] = Convert.ToInt32(row_["Valor_"]) * Convert.ToDouble(row_["Cantidad"]);

                    tabla.Rows.Add(row_);
                }
                return tabla;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al cargar el detalle de la devolución.\n" + ex.Message);
            }
        }
        // Fin edición


        #endregion

        #region Saldos en Devolucion de Compra

        public bool ExisteSaldoCompra(int codigoProveedor)
        {
            try
            {
                CargarComando("existe_saldo_devolucion_proveedor");
                miComando.Parameters.AddWithValue("", codigoProveedor);
                miConexion.MiConexion.Open();
                var existe = Convert.ToBoolean(miComando.ExecuteScalar());
                miConexion.MiConexion.Close();
                miComando.Dispose();
                return existe;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al verificar el saldo del proveedor.\n" + ex.Message);
            }
            finally { miConexion.MiConexion.Close(); }
        }

        public int SaldoCompra(int codigoProveedor)
        {
            try
            {
                CargarComando("saldo_devolucion_compra");
                miComando.Parameters.AddWithValue("", codigoProveedor);
                miConexion.MiConexion.Open();
                var saldo = Convert.ToInt32(miComando.ExecuteScalar());
                miConexion.MiConexion.Close();
                miComando.Dispose();
                return saldo;
            }
            catch (InvalidCastException)
            {
                return 0;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al verificar el valor del saldo del proveedor.\n" + ex.Message);
            }
            finally { miConexion.MiConexion.Close(); }
        }

        public int IngresarSaldoCompra(Bono saldo)
        {
            try
            {
                CargarComando("ingresar_saldo_devolucion_compra");
                miComando.Parameters.AddWithValue("", saldo.IdUsuario);
                miComando.Parameters.AddWithValue("", saldo.IdCaja);
                miComando.Parameters.AddWithValue("", saldo.Id);
                miComando.Parameters.AddWithValue("", saldo.Fecha);
                miComando.Parameters.AddWithValue("", saldo.Valor);
                miComando.Parameters.AddWithValue("", saldo.IdDevolucion);
                miComando.Parameters.AddWithValue("", saldo.CodProveedor);
                miConexion.MiConexion.Open();
                var id = Convert.ToInt32(miComando.ExecuteScalar());
                miConexion.MiConexion.Close();
                miComando.Dispose();
                return id;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al ingresar el saldo de la Devolución\n" + ex.Message);
            }
            finally { miConexion.MiConexion.Close(); }
        }

        public void EditarSaldoCompra(int codigoProveedor, int valor)
        {
            try
            {
                CargarComando("editar_valor_saldo_devolucion_proveedor");
                miComando.Parameters.AddWithValue("", codigoProveedor);
                miComando.Parameters.AddWithValue("", valor);
                miConexion.MiConexion.Open();
                miComando.ExecuteNonQuery();
                miConexion.MiConexion.Close();
                miComando.Dispose();
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al editar el saldo de devolución de proveedor.\n" + ex.Message);
            }
            finally { miConexion.MiConexion.Close(); }
        }

        public int SaldoDevolucionCompra_(int idFactura)
        {
            try
            {
                CargarComando("devoluciones_proveedor_factura");
                miComando.Parameters.AddWithValue("", idFactura);
                miConexion.MiConexion.Open();
                NpgsqlDataReader reader = miComando.ExecuteReader();
                int id = 0;
                while (reader.Read())
                {
                    id = reader.GetInt32(0);
                }
                miConexion.MiConexion.Close();
                miComando.Dispose();
                var tDetalle = DetalleDevolucionCompra(id);
                return Convert.ToInt32(tDetalle.AsEnumerable().Sum(s => s.Field<double>("Total_")));
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al consultar el saldo de devolución.\n" + ex.Message);
            }
            finally { miConexion.MiConexion.Close(); }
        }




        public int SaldoDevolucionCompra(int idFactura)
        {
            var tabla = new DataTable();
            try
            {
                CargarAdapter("saldos_devolucion_compra");
                miAdapter.SelectCommand.Parameters.AddWithValue("idFactura", idFactura);
                miAdapter.Fill(tabla);
                var saldo = 0;
                if (tabla.Rows.Count != 0)
                {
                    saldo = tabla.AsEnumerable().Sum(s => s.Field<int>("valor"));
                }
                return saldo;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrio" + ex.Message);
            }
        }

        public void SaldarDevolucionCompra(int idDevolucion)
        {
            try
            {
                CargarComando("editar_devolucion_proveedor");
                miComando.Parameters.AddWithValue("iddevolucion", idDevolucion);
                miConexion.MiConexion.Open();
                miComando.ExecuteNonQuery();
                miConexion.MiConexion.Close();
                miComando.Dispose();
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrio un error al saldar la devolución.\n" + ex.Message);
            }
            finally { miConexion.MiConexion.Close(); }
        }

        #endregion


        public DataTable Repetidos()
        {
            try
            {
                DataTable tData = new DataTable();
                tData.Columns.Add(new DataColumn("cod_provee", typeof(string)));
                tData.Columns.Add(new DataColumn("proveedor", typeof(string)));
                tData.Columns.Add(new DataColumn("codigo", typeof(string)));
                tData.Columns.Add(new DataColumn("producto", typeof(string)));
                

                string sql = 
            "SELECT proveedor.codigointernoproveedor AS cod_provee, proveedor.nombrecomercialproveedor AS proveedor, producto.codigointernoproducto AS codigo, producto.nombreproducto AS producto " +
            "FROM proveedor, proveedor_producto, producto WHERE proveedor_producto.codigointernoproveedor = proveedor.codigointernoproveedor AND " + 
            "proveedor_producto.codigointernoproducto = producto.codigointernoproducto GROUP BY proveedor.codigointernoproveedor, proveedor.nombrecomercialproveedor, producto.codigointernoproducto , " +
            "producto.nombreproducto ORDER BY producto.codigointernoproducto;";

                var tProducto = new DataTable();
                this.miAdapter = new NpgsqlDataAdapter(sql, miConexion.MiConexion);
                this.miAdapter.SelectCommand.CommandType = CommandType.Text;
                this.miAdapter.Fill(tProducto);

                var tProducto2 = tProducto;

                foreach (DataRow row in tProducto.Rows)
                {
                    var query = tProducto2.AsEnumerable().Where(p => p.Field<string>("codigo").Equals(row["codigo"].ToString()));
                    if (query.Count() > 1)
                    {
                        var dRow = tData.NewRow();
                        dRow["cod_provee"] = row["cod_provee"];
                        dRow["proveedor"] = row["proveedor"];
                        dRow["codigo"] = row["codigo"];
                        dRow["producto"] = row["producto"];
                        tData.Rows.Add(dRow);
                    }
                }
                return tData;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void LimpiarSpace_ProduDupli()
        {
            try
            {
                var tProd = new DataTable();
                string sql = "SELECT codigointernoproducto, codigobarrasproducto FROM producto;";
                this.miAdapter = new NpgsqlDataAdapter(sql, miConexion.MiConexion);
                this.miAdapter.SelectCommand.CommandType = CommandType.Text;
                this.miAdapter.Fill(tProd);
                string barras = "";
                string new_barras = "";
                foreach (DataRow pRow in tProd.Rows)
                {
                    if (pRow["codigointernoproducto"].ToString().Equals("1000321"))
                    {
                        var j = "";
                    }
                    barras = pRow["codigobarrasproducto"].ToString();
                    new_barras = "";
                    for (int i = 0; i < barras.Length; i++)
                    {
                        if (barras[i].Equals('\''))
                        {
                            var r = barras[i];
                        }
                        if (!barras[i].Equals(' ') && !barras[i].Equals('\''))
                        {
                            new_barras += barras[i];
                        }
                    }
                    ActBarras(pRow["codigointernoproducto"].ToString(), new_barras);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private void ActBarras(string cod, string barras)
        {
            try
            {
                string sql = "UPDATE producto SET codigobarrasproducto = '" + barras + "' WHERE codigointernoproducto = '" + cod + "';";
                miComando = new NpgsqlCommand();
                miComando.Connection = miConexion.MiConexion;
                miComando.CommandType = CommandType.Text;
                miComando.CommandText = sql;
                this.miConexion.MiConexion.Open();
                this.miComando.ExecuteNonQuery();
                this.miConexion.MiConexion.Close();
                this.miComando.Dispose();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally { this.miConexion.MiConexion.Close(); }
        }


        public void EliminarTerceros()
        {

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
            this.miAdapter = new NpgsqlDataAdapter(cmd, miConexion.MiConexion);
            this.miAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
        }
    }
}