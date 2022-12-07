using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using DTO.Clases;
using Npgsql;
using Utilities;

namespace DataAccessLayer.Clases
{
    public class DaoProductoFacturaVenta
    {
        #region Tranzación a base de datos.

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

        #endregion

        #region Funciones

        /// <summary>
        /// Representa la función insertar_producto_factura_venta.
        /// </summary>
        private string Ingresar = "insertar_producto_factura_venta";

        /// <summary>
        /// Representa la función: consulta_producto_factura_venta.
        /// </summary>
        private string ProductoFacturaVenta_ = "consulta_producto_factura_venta";

        /// <summary>
        /// Representa la función: print_producto_factura_venta.
        /// </summary>
        private string PrintProducto_ = "print_producto_factura_venta";

        /// <summary>
        /// Representa la función: editar_producto_factura_venta.
        /// </summary>
        private string Editar = "editar_producto_factura_venta";

        /// <summary>
        /// Representa la función: get_cantidad_producto_factura_venta.
        /// </summary>
        //private string GetCantidad = "get_cantidad_producto_factura_venta";

        #endregion

        #region Mensajes

        /// <summary>
        /// Representa el texto: Ocurrió un error al ingresar el registro del producto.
        /// </summary>
        private string ErrorIngresar = "Ocurrió un error al ingresar el registro del producto.\n";

        /// <summary>
        /// Representa el mensaje: Ocurrió un error al consultar los productos de la Factura.
        /// </summary>
        private string ErrorConsulta = "Ocurrió un error al consultar los productos de la Factura.\n";

        /// <summary>
        /// Representa el mensaje: Ocurrió un error al consultar los productos de la Factura.
        /// </summary>
        private string ErroConsulta = "Ocurrió un error al consultar los productos de la Factura.\n";

        /// <summary>
        /// Representa el texto: Ocurrió un error al editar el registro del producto.
        /// </summary>
        private string ErrorEditar = "Ocurrió un error al editar el registro del producto.\n";

        /// <summary>
        /// Representa el texto: Ocurrió un error al consultar la cantidad del producto en el registro.
        /// </summary>
        //private string ErrorCantidad = "Ocurrió un error al consultar la cantidad del producto en el registro.\n";

        #endregion

        private bool RedondearPrecio2;

        /// <summary>
        /// Inicializa una nueva instancia de la clase DaoProductoFacturaVenta
        /// </summary>
        public DaoProductoFacturaVenta()
        {
            miConexion = new Conexion();
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
        /// Ingresa un registro de Producto en su relación con la Factura de Venta.
        /// </summary>
        /// <param name="producto">Registro del Producto a ingresar.</param>
        public void IngresarProductoFactura(ProductoFacturaProveedor producto)
        {
            try
            {
                CargarComando(Ingresar);
                miComando.Parameters.AddWithValue("factura", producto.NumeroFactura);
                miComando.Parameters.AddWithValue("producto", producto.Producto.CodigoInternoProducto);
                miComando.Parameters.AddWithValue("cantidad", producto.Cantidad);
                miComando.Parameters.AddWithValue("valor", producto.Producto.ValorVentaProducto);
                miComando.Parameters.AddWithValue("medida", producto.Inventario.IdMedida);
                miComando.Parameters.AddWithValue("color", producto.Inventario.IdColor);
                miComando.Parameters.AddWithValue("descuento", producto.Producto.Descuento);
                miComando.Parameters.AddWithValue("recargo", producto.Producto.Recargo);
                miComando.Parameters.AddWithValue("iva", producto.Producto.ValorIva);
                miComando.Parameters.AddWithValue("retorno", producto.Retorno);
                miComando.Parameters.AddWithValue("valor", producto.Valor);
                miComando.Parameters.AddWithValue("costo", producto.Costo);
                miComando.Parameters.AddWithValue("id_factura", producto.IdFactura);
                miComando.Parameters.AddWithValue("valor_real", producto.ValorReal);
                miComando.Parameters.AddWithValue("ico", producto.ImpoConsumo);
                miComando.Parameters.AddWithValue("total", producto.Total);
                miComando.Parameters.AddWithValue("id_iva", producto.Producto.IdIva);
                miConexion.MiConexion.Open();
                miComando.ExecuteNonQuery();
                miConexion.MiConexion.Close();
                miComando.Dispose();
            }
            catch (Exception ex)
            {
                throw new Exception(ErrorIngresar + ex.Message);
            }
            finally { miConexion.MiConexion.Close(); }
        }

        /// <summary>
        /// Obtiene el resultado de la consulta de los productos de una Factura de Venta.
        /// </summary>
        /// <param name="numero">Número de la Factura de Venta.</param>
        /// <returns></returns>
        public DataTable ProductoFacturaVenta(string numero)
        {
            var tabla = new DataTable();
            try
            {
                CargarAdapter(ProductoFacturaVenta_);
                miAdapter.SelectCommand.Parameters.AddWithValue("numero", numero);
                miAdapter.Fill(tabla);
                return tabla;
            }
            catch (Exception ex)
            {
                throw new Exception(ErroConsulta + ex.Message);
            }
        }

        public DataTable ProductoFacturaVenta(int idFactura)
        {
            var tabla = new DataTable();
            try
            {
                CargarAdapter(ProductoFacturaVenta_);
                miAdapter.SelectCommand.Parameters.AddWithValue("", idFactura);
                miAdapter.Fill(tabla);
                return tabla;
            }
            catch (Exception ex)
            {
                throw new Exception(ErroConsulta + ex.Message);
            }
        }

        /// <summary>
        /// Obtiene los datos de los productos en una factura de venta para su impresión.
        /// </summary>
        /// <param name="numero">Número de la factura de venta.</param>
        /// <param name="descuento">Indica si el producto aplica descuento o no (recargo).</param>
        /// <returns></returns>
        public DataSet PrintProducto(int id, bool descuento)
        {
            var dataSet = new DataSet();
            var tablaDB = new DataTable();
            var miTabla = CrearTabla();
            miTabla.TableName = "Detalle";
            try
            {
                CargarAdapter(PrintProducto_);
                miAdapter.SelectCommand.Parameters.AddWithValue("id", id);
                miAdapter.Fill(tablaDB);
                foreach (DataRow row in tablaDB.Rows)
                {
                    if (!Convert.ToBoolean(row["retorno"]))
                    {
                        var miRow = miTabla.NewRow();
                        miRow["Codigo"] = row["Codigo"];
                        miRow["Cantidad"] = row["Cantidad"];

                        if (row["Producto"].ToString().Length > 60)
                        {
                            miRow["Producto"] = row["Producto"].ToString().Substring(0, 60);
                        }
                        else
                        {
                            miRow["Producto"] = row["Producto"];
                        }

                        if (!descuento)
                        {
                            miRow["Valor"] = Math.Round((
                                Convert.ToDouble(row["Valor"]) +
                                Convert.ToDouble(Convert.ToDouble(row["Valor"]) * Convert.ToDouble(row["Recargo"]) / 100)), 1);
                        }
                        else
                        {
                            miRow["Valor"] = row["Valor"];
                        }
                        var v = miRow["Valor"].ToString();
                        double vIva = Math.Round((Convert.ToDouble(miRow["Valor"]) * Convert.ToDouble(row["Iva"]) / 100), 1);
                        miRow["ValorMasIva"] = Convert.ToInt32(Convert.ToDouble(miRow["Valor"]) + vIva);

                        v = miRow["ValorMasIva"].ToString();

                        miRow["Ico"] = Convert.ToInt32(row["impoconsumo"]);
                        v = miRow["Ico"].ToString();
                        int valorMasIco = Convert.ToInt32(miRow["ValorMasIva"]) + Convert.ToInt32(row["impoconsumo"]);
                        int valorMenosDescto_ = Convert.ToInt32(valorMasIco - (valorMasIco * Convert.ToDouble(row["Descuento"]) / 100));

                        v = miRow["ValorMasIva"].ToString();  // Para que se usa este ValorMasIva sumado sin restar el descuento

                        miRow["Descuento"] = row["Descuento"];//%
                        miRow["Iva"] = row["Iva"];
                        //miRow["Descto"] = Convert.ToInt32(row["Descto"]);  AJUSTE POR DESCTO 29/07/2018
                        miRow["Descto"] = Math.Round(Convert.ToDouble(row["Descto"]), 1);

                        v = miRow["Descuento"].ToString();
                        v = miRow["Descto"].ToString();

                        double valorMenosDescto = Convert.ToDouble(row["Valor"]) - Convert.ToDouble(miRow["Descto"]);

                        double iva = Math.Round(
                                    (valorMenosDescto * Convert.ToDouble(row["Iva"]) / 100), 1);

                        if (this.RedondearPrecio2)
                        {
                            miRow["Valor_"] = UseObject.Aproximar(Convert.ToInt32(valorMenosDescto + iva + Convert.ToInt32(row["impoconsumo"])),
                                Convert.ToBoolean(AppConfiguracion.ValorSeccion("tipo_aprox_precio")));
                        }
                        else
                        {
                            miRow["Valor_"] = Convert.ToInt32(valorMenosDescto + iva + Convert.ToInt32(row["impoconsumo"]));
                        }
                        v = miRow["Valor_"].ToString();
                        /*  edicion impoconsumo no
                        if (this.RedondearPrecio2)
                        {
                            if (Convert.ToDouble(row["impoconsumo"]) > 0)
                            {
                                miRow["Valor_"] = UseObject.Aproximar(valorMenosDescto_, Convert.ToBoolean(AppConfiguracion.ValorSeccion("tipo_aprox_precio")));
                            }
                            else
                            {
                                miRow["Valor_"] = UseObject.Aproximar(Convert.ToInt32(valorMenosDescto + iva + Convert.ToDouble(row["impoconsumo"])),
                                    Convert.ToBoolean(AppConfiguracion.ValorSeccion("tipo_aprox_precio")));
                            }
                        }
                        else
                        {
                            if (Convert.ToDouble(row["impoconsumo"]) > 0)
                            {
                                miRow["Valor_"] = valorMenosDescto_;
                            }
                            else
                            {
                                miRow["Valor_"] = Convert.ToInt32(valorMenosDescto + iva + Convert.ToDouble(row["impoconsumo"]));
                            }
                        }*/
                        //****//

                        
                        // Edición ajuste redondeo de TotalMasIva  16-04-2017
                        //miRow["Valor_"] = UseObject.Aproximar(Convert.ToInt32(valorMenosDescto + iva),
                                                             // Convert.ToBoolean(AppConfiguracion.ValorSeccion("tipo_aprox_precio")));  ojo para editar cuando se raliza la funcionalidad 

                        /*  Codigo antes del ajuste redondeo de TotalMasIva 16-04-2017*/
                        //miRow["Valor_"] = Convert.ToInt32(valorMenosDescto + iva);
                       /**** Codigo antes del ajuste redondeo de TotalMasIva 16-04-2017   */

                        //despues
                        // miRow["Valor_"] = Convert.ToInt32(Convert.ToDouble(row["Valor"]) + iva);

                        //  

                        v = miRow["Valor_"].ToString();

                        miRow["Sub_Total"] = Convert.ToInt32(
                                   Convert.ToDouble(row["Valor"]) * Convert.ToDouble(row["Cantidad"]));
                        v = miRow["Sub_Total"].ToString();

                        miRow["Descto_"] = Convert.ToInt32(
                                   Convert.ToDouble(miRow["Descto"]) * Convert.ToDouble(row["Cantidad"]));

                        v = miRow["Descto_"].ToString();

                        miRow["vIva_"] = Convert.ToDouble(iva * Convert.ToDouble(row["Cantidad"]));

                        v = miRow["vIva_"].ToString();

                        miRow["Total_"] = Convert.ToInt32(Convert.ToInt32(miRow["Valor_"]) * Convert.ToDouble(row["Cantidad"]));

                        v = miRow["Total_"].ToString();

                        miTabla.Rows.Add(miRow);
                    }
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

        /// <summary>
        /// Edita los datos del registro de ProductoFacturaVenta.
        /// </summary>
        /// <param name="producto">Registro del Producto a editar.</param>
        public void EditarProductoFactura(ProductoFacturaProveedor producto)
        {
            try
            {
                CargarComando(Editar);
                miComando.Parameters.AddWithValue("id", producto.Id);
                miComando.Parameters.AddWithValue("numero", producto.NumeroFactura);
                miComando.Parameters.AddWithValue("producto", producto.Producto.CodigoInternoProducto);
                miComando.Parameters.AddWithValue("cantidad", producto.Cantidad);
                miComando.Parameters.AddWithValue("valor", producto.Producto.ValorVentaProducto);
                miComando.Parameters.AddWithValue("idMedida", producto.Inventario.IdMedida);
                miComando.Parameters.AddWithValue("idColor", producto.Inventario.IdColor);
                miComando.Parameters.AddWithValue("descto", producto.Producto.Descuento);
                miComando.Parameters.AddWithValue("recargo", producto.Producto.Recargo);
                miComando.Parameters.AddWithValue("iva", producto.Producto.ValorIva);
                miComando.Parameters.AddWithValue("valor_real", producto.ValorReal);
                miComando.Parameters.AddWithValue("total", producto.Total);
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
            /*var miDaoInventario = new DaoInventario();
            var cant = GetCantidadProductoFactura(producto.Id);
            if (cant != producto.Cantidad)
            {
                var inventario = new Inventario();
                inventario.CodigoProducto = producto.Producto.CodigoInternoProducto;
                inventario.IdMedida = producto.Inventario.IdMedida;
                inventario.IdColor = producto.Inventario.IdColor;
                if (cant > producto.Cantidad)  //disminuyo la cantidad del producto
                {
                    inventario.Cantidad = cant - producto.Cantidad;

                }
                else  //aumento la cantidad del producto
                {
                }
            }*/
        }

        public void ElimnarProductoFacturaVenta(int id)
        {
            try
            {
                CargarComando("eliminar_producto_factura_venta");
                miComando.Parameters.AddWithValue("id", id);
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

        /// <summary>
        /// Obtiene la cantidad del producto en el registro de la relación con factura venta.
        /// </summary>
        /// <param name="id">Id del registro del producto.</param>
        /// <returns></returns>
       /*private int GetCantidadProductoFactura(int id)
        {
            try
            {
                CargarComando(GetCantidad);
                miComando.Parameters.AddWithValue("id", id);
                miConexion.MiConexion.Open();
                var cant = Convert.ToInt32(miComando.ExecuteScalar());
                miConexion.MiConexion.Close();
                miComando.Dispose();
                return cant;
            }
            catch (Exception ex)
            {
                throw new Exception(ErrorCantidad + ex.Message);
            }
            finally { miConexion.MiConexion.Close(); }
        }*/

        /// <summary>
        /// Obtiene un tabla de memora con las columnas usadas en los datos de 
        /// impresión del producto de fatura de venta.
        /// </summary>
        /// <returns></returns>
        public DataTable CrearTabla()
        {
            var tabla = new DataTable();
            tabla.Columns.Add(new DataColumn("Codigo", typeof(string)));
            tabla.Columns.Add(new DataColumn("Cantidad", typeof(double)));
            tabla.Columns.Add(new DataColumn("Producto", typeof(string)));
            tabla.Columns.Add(new DataColumn("Valor", typeof(double)));
            tabla.Columns.Add(new DataColumn("Descuento", typeof(double)));
            //tabla.Columns.Add(new DataColumn("Descto", typeof(int)));
            tabla.Columns.Add(new DataColumn("Descto", typeof(double)));
            tabla.Columns.Add(new DataColumn("Iva", typeof(double)));
            tabla.Columns.Add(new DataColumn("SubTotal", typeof(int)));
            tabla.Columns.Add(new DataColumn("Total", typeof(int)));

            tabla.Columns.Add(new DataColumn("Valor_", typeof(double)));
            tabla.Columns.Add(new DataColumn("Sub_Total", typeof(double)));
            tabla.Columns.Add(new DataColumn("Descto_", typeof(int)));
            tabla.Columns.Add(new DataColumn("vIva_", typeof(double)));

            tabla.Columns.Add(new DataColumn("Total_", typeof(int)));
            tabla.Columns.Add(new DataColumn("ValorMasIva", typeof(int)));

            tabla.Columns.Add(new DataColumn("Ico", typeof(double)));
            return tabla;
        }

        // Retorno de articulos.

        public void IngresarRetorno(ProductoFacturaProveedor producto)
        {
            try
            {
                CargarComando("insertar_retorno");
                miComando.Parameters.AddWithValue("nofactura", producto.NumeroFactura);
                miComando.Parameters.AddWithValue("codigo", producto.Producto.CodigoInternoProducto);
                miComando.Parameters.AddWithValue("medida", producto.Inventario.IdMedida);
                miComando.Parameters.AddWithValue("color", producto.Inventario.IdColor);
                miComando.Parameters.AddWithValue("cantidad", producto.Cantidad);
                miComando.Parameters.AddWithValue("valor", producto.Producto.ValorVentaProducto);
                miComando.Parameters.AddWithValue("iva", producto.Producto.ValorIva);
                miConexion.MiConexion.Open();
                miComando.ExecuteNonQuery();
                miConexion.MiConexion.Close();
                miComando.Dispose();
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al ingresar el retorno.\n" + ex.Message);
            }
            finally { miConexion.MiConexion.Close(); }
        }

        // Retorno temporal de articulos.

        public void IngresarRetornoTemporal(ProductoFacturaProveedor producto)
        {
            try
            {
                CargarComando("insertar_retorno_temp");
                miComando.Parameters.AddWithValue("codigo", producto.Producto.CodigoInternoProducto);
                miComando.Parameters.AddWithValue("medida", producto.Inventario.IdMedida);
                miComando.Parameters.AddWithValue("color", producto.Inventario.IdColor);
                miComando.Parameters.AddWithValue("cantidad", producto.Cantidad);
                miComando.Parameters.AddWithValue("valor", producto.Producto.ValorVentaProducto);
                miComando.Parameters.AddWithValue("iva", producto.Producto.ValorIva);
                miConexion.MiConexion.Open();
                miComando.ExecuteNonQuery();
                miConexion.MiConexion.Close();
                miComando.Dispose();
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al ingresar el retorno.\n" + ex.Message);
            }
            finally { miConexion.MiConexion.Close(); }
        }

        public DataTable RetornosTemporal()
        {
            try
            {
                var tabla = new DataTable();
                CargarAdapter("retornos_temporales");
                miAdapter.Fill(tabla);
                return tabla;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al cargar los registros de retorno.\n" + ex.Message);
            }
        }

        public void EliminarRetornoTemporal()
        {
            try
            {
                CargarComando("eliminar_retorno_temp");
                miConexion.MiConexion.Open();
                miComando.ExecuteNonQuery();
                miConexion.MiConexion.Close();
                miComando.Dispose();
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al limpiar los registros de retorno.\n" + ex.Message);
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