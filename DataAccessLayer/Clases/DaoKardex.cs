using System;
using System.Data;
using System.Linq;
using System.Text;
using DTO.Clases;
using Npgsql;

namespace DataAccessLayer.Clases
{
    public class DaoKardex
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

        public DaoKardex()
        {
            this.miConexion = new Conexion();
        }

        public DaoKardex(string ipServer)
        {
            this.miConexion = new Conexion(ipServer, "");
        }

        public void Insertar(Kardex kardex)
        {
            try
            {
                CargarComando("insertar_kardex");
                miComando.Parameters.AddWithValue("idcompra", kardex.IdCompra);
                miComando.Parameters.AddWithValue("codigo", kardex.Codigo);
                miComando.Parameters.AddWithValue("idusuario", kardex.IdUsuario);
                miComando.Parameters.AddWithValue("idconcepto", kardex.IdConcepto);
                miComando.Parameters.AddWithValue("nodocumento", kardex.NoDocumento);
                miComando.Parameters.AddWithValue("fecha", kardex.Fecha);
                miComando.Parameters.AddWithValue("hora", kardex.Fecha.TimeOfDay);
                miComando.Parameters.AddWithValue("cantidad", kardex.Cantidad);
                miComando.Parameters.AddWithValue("valor", kardex.Valor);
                miComando.Parameters.AddWithValue("total", kardex.Total);
                miConexion.MiConexion.Open();
                miComando.ExecuteNonQuery();
                miConexion.MiConexion.Close();
                miComando.Dispose();
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al ingresar el registro del Kardex.\n" + ex.Message);
            }
            finally { miConexion.MiConexion.Close(); }
        }


        //consulta por fecha y codigo

        public DataTable Kardex
            (DateTime fecha, string codigo, int rowIndex, int rowMax)
        {
            try
            {
                var tabla = new DataTable();
                CargarAdapter("kardex");
                miAdapter.SelectCommand.Parameters.AddWithValue("fecha", fecha);
                miAdapter.SelectCommand.Parameters.AddWithValue("codigo", codigo);
                miAdapter.Fill(rowIndex, rowMax, tabla);
                return PasarDatos(tabla);
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al consultar el Kardex.\n" + ex.Message);
            }
        }

        public long GetsRowsKardex(DateTime fecha, string codigo)
        {
            try
            {
                CargarComando("count_kardex");
                miComando.Parameters.AddWithValue("fecha", fecha);
                miComando.Parameters.AddWithValue("codigo", codigo);
                miConexion.MiConexion.Open();
                var rows = Convert.ToInt64(miComando.ExecuteScalar());
                miConexion.MiConexion.Close();
                miComando.Dispose();
                return rows;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al consultar el conteo del Kardex.\n" + ex.Message);
            }
            finally { miConexion.MiConexion.Close(); }
        }

        //consulta por operacion, fecha y codigo

        public DataTable Kardex
            (int idOperacion, DateTime fecha, string codigo, int rowIndex, int rowMax)
        {
            try
            {
                var tabla = new DataTable();
                CargarAdapter("kardex");
                miAdapter.SelectCommand.Parameters.AddWithValue("idoperacion", idOperacion);
                miAdapter.SelectCommand.Parameters.AddWithValue("fecha", fecha);
                miAdapter.SelectCommand.Parameters.AddWithValue("codigo", codigo);
                miAdapter.Fill(rowIndex, rowMax, tabla);
                return PasarDatos(tabla);
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al consultar el Kardex.\n" + ex.Message);
            }
        }

        public long GetsRowsKardex(int idOperacion, DateTime fecha, string codigo)
        {
            try
            {
                CargarComando("count_kardex");
                miComando.Parameters.AddWithValue("idOperacion", idOperacion);
                miComando.Parameters.AddWithValue("fecha", fecha);
                miComando.Parameters.AddWithValue("codigo", codigo);
                miConexion.MiConexion.Open();
                var rows = Convert.ToInt64(miComando.ExecuteScalar());
                miConexion.MiConexion.Close();
                miComando.Dispose();
                return rows;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al consultar el conteo del Kardex.\n" + ex.Message);
            }
            finally { miConexion.MiConexion.Close(); }
        }

        //consulta por periodo y codigo

        public DataTable Kardex
            (DateTime fecha, DateTime fecha2, string codigo, int rowIndex, int rowMax)
        {
            try
            {
                var tabla = new DataTable();
                CargarAdapter("kardex_periodo");
                miAdapter.SelectCommand.Parameters.AddWithValue("fecha", fecha);
                miAdapter.SelectCommand.Parameters.AddWithValue("fecha2", fecha2);
                miAdapter.SelectCommand.Parameters.AddWithValue("codigo", codigo);
                miAdapter.Fill(rowIndex, rowMax, tabla);
                return PasarDatos(tabla);
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al consultar el Kardex.\n" + ex.Message);
            }
        }

        public long GetsRowsKardex(DateTime fecha, DateTime fecha2, string codigo)
        {
            try
            {
                CargarComando("count_kardex_periodo");
                miComando.Parameters.AddWithValue("fecha", fecha);
                miComando.Parameters.AddWithValue("fecha2", fecha2);
                miComando.Parameters.AddWithValue("codigo", codigo);
                miConexion.MiConexion.Open();
                var rows = Convert.ToInt64(miComando.ExecuteScalar());
                miConexion.MiConexion.Close();
                miComando.Dispose();
                return rows;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al consultar el conteo del Kardex.\n" + ex.Message);
            }
            finally { miConexion.MiConexion.Close(); }
        }

        //consulta por operacion, periodo y codigo

        public DataTable Kardex
            (int idOperacion, DateTime fecha, DateTime fecha2, string codigo, int rowIndex, int rowMax)
        {
            try
            {
                var tabla = new DataTable();
                CargarAdapter("kardex");
                miAdapter.SelectCommand.Parameters.AddWithValue("idOperacion", idOperacion);
                miAdapter.SelectCommand.Parameters.AddWithValue("fecha", fecha);
                miAdapter.SelectCommand.Parameters.AddWithValue("fecha2", fecha2);
                miAdapter.SelectCommand.Parameters.AddWithValue("codigo", codigo);
                miAdapter.Fill(rowIndex, rowMax, tabla);
                return PasarDatos(tabla);
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al consultar el Kardex.\n" + ex.Message);
            }
        }

        public long GetsRowsKardex(int idOperacion, DateTime fecha, DateTime fecha2, string codigo)
        {
            try
            {
                CargarComando("count_kardex");
                miComando.Parameters.AddWithValue("idOperacion", idOperacion);
                miComando.Parameters.AddWithValue("fecha", fecha);
                miComando.Parameters.AddWithValue("fecha2", fecha2);
                miComando.Parameters.AddWithValue("codigo", codigo);
                miConexion.MiConexion.Open();
                var rows = Convert.ToInt64(miComando.ExecuteScalar());
                miConexion.MiConexion.Close();
                miComando.Dispose();
                return rows;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al consultar el conteo del Kardex.\n" + ex.Message);
            }
            finally { miConexion.MiConexion.Close(); }
        }

        // Resumen Kardex
        public DataTable Resumen(int idOperacion, DateTime fecha, string codigo)
        {
            try
            {
                var tabla = new DataTable();
                CargarAdapter("resumen_kardex");
                miAdapter.SelectCommand.Parameters.AddWithValue("idOperacion", idOperacion);
                miAdapter.SelectCommand.Parameters.AddWithValue("fecha", fecha);
                miAdapter.SelectCommand.Parameters.AddWithValue("codigo", codigo);
                miAdapter.Fill(tabla);
                var tKardex = Tabla();
                var color = new ElColor();
                foreach (DataRow row in tabla.Rows)
                {
                    var kRow = tKardex.NewRow();
                    kRow["IdConcepto"] = row["idconcepto"];
                    kRow["Concepto"] = row["concepto"];
                    color.MapaBits = row["imagen"].ToString();
                    kRow["Imagen"] = color.ImagenBit;
                    kRow["Cantidad"] = row["cantidad"];
                    var c = row["cantidad"].ToString();
                    c = row["valor"].ToString();
                    kRow["Valor"] = Convert.ToInt32(Convert.ToDouble(row["total"]) / Convert.ToDouble(row["cantidad"]));
                    c = kRow["Valor"].ToString();
                    tKardex.Rows.Add(kRow);
                }
                return tKardex;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al consultar el resumen del kardex.\n" + ex.Message);
            }
        }

        public DataTable Resumen(int idOperacion, DateTime fecha, DateTime fecha2, string codigo)
        {
            try
            {
                var tabla = new DataTable();
                CargarAdapter("resumen_kardex");
                miAdapter.SelectCommand.Parameters.AddWithValue("idOperacion", idOperacion);
                miAdapter.SelectCommand.Parameters.AddWithValue("fecha", fecha);
                miAdapter.SelectCommand.Parameters.AddWithValue("fecha2", fecha2);
                miAdapter.SelectCommand.Parameters.AddWithValue("codigo", codigo);
                miAdapter.Fill(tabla);
                var tKardex = Tabla();
                var color = new ElColor();
                foreach (DataRow row in tabla.Rows)
                {
                    var kRow = tKardex.NewRow();
                    kRow["IdConcepto"] = row["idconcepto"];
                    kRow["Concepto"] = row["concepto"];
                    color.MapaBits = row["imagen"].ToString();
                    kRow["Imagen"] = color.ImagenBit;
                    kRow["Cantidad"] = row["cantidad"];
                   // var c = row["cantidad"].ToString();
                   // c = row["valor"].ToString();
                    if (Convert.ToDouble(row["cantidad"]) > 0)
                    {
                        kRow["Valor"] = Convert.ToInt32(Convert.ToDouble(row["total"]) / Convert.ToDouble(row["cantidad"]));
                    }
                    else
                    {
                        kRow["Valor"] = 0;
                    }
                  //  c = kRow["Valor"].ToString();
                    tKardex.Rows.Add(kRow);
                }
                return tKardex;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al consultar el resumen del kardex.\n" + ex.Message);
            }
        }

        private DataTable PasarDatos(DataTable tabla)
        {
            var tKardex = Tabla();
            var color = new ElColor();
            foreach (DataRow row in tabla.Rows)
            {
                var kRow = tKardex.NewRow();
                kRow["NoDocumento"] = row["nodocumento"];
                kRow["Fecha"] = row["fecha"];
                kRow["Hora"] = row["hora"];
                kRow["IdConcepto"] = row["idconcepto"];
                kRow["Concepto"] = row["concepto"];
                color.MapaBits = row["imagen"].ToString();
                kRow["Imagen"] = color.ImagenBit;
                kRow["Cantidad"] = row["cantidad"];
                kRow["Valor"] = row["valor"];
                kRow["Usuario"] = row["usuario"];
                tKardex.Rows.Add(kRow);
            }
            return tKardex;
        }

        private DataTable Tabla()
        {
            var tabla = new DataTable();
            tabla.Columns.Add(new DataColumn("NoDocumento", typeof(string)));
            tabla.Columns.Add(new DataColumn("Fecha", typeof(DateTime)));
            tabla.Columns.Add(new DataColumn("Hora", typeof(DateTime)));
            tabla.Columns.Add(new DataColumn("IdConcepto" , typeof(int)));
            tabla.Columns.Add(new DataColumn("Concepto", typeof(string)));
            tabla.Columns.Add(new DataColumn("Imagen", typeof(System.Drawing.Image)));
            tabla.Columns.Add(new DataColumn("Cantidad", typeof(double)));
            tabla.Columns.Add(new DataColumn("Valor", typeof(double)));
            tabla.Columns.Add(new DataColumn("Total", typeof(double)));
            tabla.Columns.Add(new DataColumn("Usuario", typeof(string)));
            return tabla;
        }

        // Consultas de impresion
        public DataTable Kardex(DateTime fecha, string codigo)
        {
            try
            {
                var tabla = new DataTable();
                CargarAdapter("kardex");
                miAdapter.SelectCommand.Parameters.AddWithValue("", fecha);
                miAdapter.SelectCommand.Parameters.AddWithValue("", codigo);
                miAdapter.Fill(tabla);
                return tabla;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al consultar el Kardex.\n" + ex.Message);
            }
        }

        public DataTable Kardex(int idOperacion, DateTime fecha, string codigo)
        {
            try
            {
                var tabla = new DataTable();
                CargarAdapter("kardex");
                miAdapter.SelectCommand.Parameters.AddWithValue("", idOperacion);
                miAdapter.SelectCommand.Parameters.AddWithValue("", fecha);
                miAdapter.SelectCommand.Parameters.AddWithValue("", codigo);
                miAdapter.Fill(tabla);
                return tabla;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al consultar el Kardex.\n" + ex.Message);
            }
        }

        public DataTable Kardex(DateTime fecha, DateTime fecha2, string codigo)
        {
            try
            {
                var tabla = new DataTable();
                CargarAdapter("kardex_periodo");
                miAdapter.SelectCommand.Parameters.AddWithValue("fecha", fecha);
                miAdapter.SelectCommand.Parameters.AddWithValue("fecha2", fecha2);
                miAdapter.SelectCommand.Parameters.AddWithValue("codigo", codigo);
                miAdapter.Fill(tabla);
                return tabla;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al consultar el Kardex.\n" + ex.Message);
            }
        }

        public DataTable Kardex(int idOperacion, DateTime fecha, DateTime fecha2, string codigo)
        {
            try
            {
                var tabla = new DataTable();
                CargarAdapter("kardex");
                miAdapter.SelectCommand.Parameters.AddWithValue("", idOperacion);
                miAdapter.SelectCommand.Parameters.AddWithValue("", fecha);
                miAdapter.SelectCommand.Parameters.AddWithValue("", fecha2);
                miAdapter.SelectCommand.Parameters.AddWithValue("", codigo);
                miAdapter.Fill(tabla);
                return tabla;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al consultar el Kardex.\n" + ex.Message);
            }
        }



        public DataTable ConstruccionInventario(DateTime fecha, DateTime fecha2)
        {
            try
            {
                DataTable tProductos = new DataTable();
                this.CargarAdapter("listar_productos");
                this.miAdapter.Fill(tProductos);
                return this.ConstruccionInventario(tProductos, fecha, fecha2);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public DataTable ConstruccionInventarioProducto(string codigo, DateTime fecha, DateTime fecha2)
        {
            try
            {
                DataTable tProductos = new DataTable();
                this.CargarAdapter("listar_productos_codigo_codigos");
                this.miAdapter.SelectCommand.Parameters.AddWithValue("", codigo);
                this.miAdapter.Fill(tProductos);
                return this.ConstruccionInventario(tProductos, fecha, fecha2);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public DataTable ConstruccionInventarioCategoria(string codigoC, DateTime fecha, DateTime fecha2)
        {
            try
            {
                DataTable tProductos = new DataTable();
                this.CargarAdapter("listar_productos_codigo_categoria");
                this.miAdapter.SelectCommand.Parameters.AddWithValue("", codigoC);
                this.miAdapter.Fill(tProductos);
                return this.ConstruccionInventario(tProductos, fecha, fecha2);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private DataTable ConstruccionInventario(DataTable tDatos, DateTime fecha, DateTime fecha2)
        {
            DataTable tInvetarios = new DataTable();
            tInvetarios.Columns.Add(new DataColumn("categoria", typeof(string)));
            tInvetarios.Columns.Add(new DataColumn("codigo", typeof(string)));
            tInvetarios.Columns.Add(new DataColumn("producto", typeof(string)));
            tInvetarios.Columns.Add(new DataColumn("compra", typeof(double)));
            tInvetarios.Columns.Add(new DataColumn("devolventa", typeof(double)));
            tInvetarios.Columns.Add(new DataColumn("venta", typeof(double)));
            tInvetarios.Columns.Add(new DataColumn("devolcompra", typeof(double)));
            tInvetarios.Columns.Add(new DataColumn("inventario_cal", typeof(double)));
            tInvetarios.Columns.Add(new DataColumn("inventario", typeof(double)));

            double compra = 0;
            double devolVenta = 0;
            double venta = 0;
            double devolCompra = 0;
            
            foreach (DataRow dRow in tDatos.Rows)
            {
                compra = this.CantidadCompra(dRow["CodigoInternoProducto"].ToString(), fecha, fecha2);                   // suma
                devolVenta = this.CantidadDevolucionVentas(dRow["CodigoInternoProducto"].ToString(), fecha, fecha2);    // suma
                venta = this.CantidadVentas(dRow["CodigoInternoProducto"].ToString(), fecha, fecha2);                    // resta
                devolCompra = this.CantidadDevolucionCompra(dRow["CodigoInternoProducto"].ToString(), fecha, fecha2);   // resta

                var iRow = tInvetarios.NewRow();
                iRow["categoria"] = dRow["NombreCategoria"];
                iRow["codigo"] = dRow["CodigoInternoProducto"];
                iRow["producto"] = dRow["NombreProducto"];
                iRow["compra"] = compra;            // suma
                iRow["devolventa"] = devolVenta;        // suma
                iRow["venta"] = venta;            // resta
                iRow["devolcompra"] = devolCompra;      // resta
                iRow["inventario_cal"] = (compra + devolVenta) - (venta + devolCompra);
                iRow["inventario"] = this.CantidadInventario(dRow["CodigoInternoProducto"].ToString());
                tInvetarios.Rows.Add(iRow);
            }
            return tInvetarios;
        }

        private double CantidadCompra(string codigo, DateTime fecha, DateTime fecha2)
        {
            try
            {
                string sql = 
                "SELECT SUM(producto_factura_proveedor.cantidadproducto_factura_proveedor) FROM factura_proveedor, producto_factura_proveedor, proveedor, producto WHERE " +
                "producto_factura_proveedor.numeroconsecutivofactura_proveedor = factura_proveedor.numeroconsecutivofactura_proveedor AND " +
                "producto_factura_proveedor.codigointernoproducto = producto.codigointernoproducto AND proveedor.codigointernoproveedor = factura_proveedor.codigointernoproveedor AND " +
                "producto.codigointernoproducto = '" + codigo + "' AND factura_proveedor.fecha_factura BETWEEN '" + fecha.ToShortDateString() + "' AND '" + fecha2.ToShortDateString() + "';";
                this.miComando = new NpgsqlCommand();
                this.miComando.Connection = this.miConexion.MiConexion;
                this.miComando.CommandType = CommandType.Text;
                this.miComando.CommandText = sql;
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
                throw new Exception(ex.Message);
            }
            finally { this.miConexion.MiConexion.Close(); }
        }

        private double CantidadDevolucionCompra(string codigo, DateTime fecha, DateTime fecha2)
        {
            try
            {
                string sql = "SELECT SUM(detalle_devolucion_proveedor.cantidad) FROM devolucion_proveedor, detalle_devolucion_proveedor WHERE " +
                "devolucion_proveedor.id = detalle_devolucion_proveedor.id_devolucion_proveedor AND detalle_devolucion_proveedor.codigo = '" + codigo + "' AND " + 
                "devolucion_proveedor.fecha BETWEEN '" + fecha.ToShortDateString() + "' AND '" + fecha2.ToShortDateString() + "';";
                this.miComando = new NpgsqlCommand();
                this.miComando.Connection = this.miConexion.MiConexion;
                this.miComando.CommandType = CommandType.Text;
                this.miComando.CommandText = sql;
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
                throw new Exception(ex.Message);
            }
            finally { this.miConexion.MiConexion.Close(); }
        }

        private double CantidadVentas(string codigo, DateTime fecha, DateTime fecha2)
        {
            try
            {
                string sql = "SELECT SUM(producto_factura_venta.cantidadproducto_factura_venta) FROM factura_venta, producto_factura_venta WHERE " + 
                "factura_venta.id = producto_factura_venta.id_factura AND factura_venta.estado = true AND producto_factura_venta.retorno = false AND " +
                "producto_factura_venta.codigointernoproducto = '" + codigo + "' AND factura_venta.fecha_factura_venta BETWEEN '" + fecha.ToShortDateString() + "' AND '" + fecha2.ToShortDateString() + "';";
                this.miComando = new NpgsqlCommand();
                this.miComando.Connection = this.miConexion.MiConexion;
                this.miComando.CommandType = CommandType.Text;
                this.miComando.CommandText = sql;
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
                throw new Exception(ex.Message);
            }
            finally { this.miConexion.MiConexion.Close(); }
        }

        private double CantidadDevolucionVentas(string codigo, DateTime fecha, DateTime fecha2)
        {
            try
            {
                string sql = "SELECT SUM(detalle_devolucion_venta.cantidad) FROM devolucion_venta, detalle_devolucion_venta WHERE  " + 
                "devolucion_venta.id = detalle_devolucion_venta.id_devolucion_venta AND detalle_devolucion_venta.codigo = '" + codigo + "' AND " +
                "devolucion_venta.fecha BETWEEN '" + fecha.ToShortDateString() + "' AND '" + fecha2.ToShortDateString() + "';";
                this.miComando = new NpgsqlCommand();
                this.miComando.Connection = this.miConexion.MiConexion;
                this.miComando.CommandType = CommandType.Text;
                this.miComando.CommandText = sql;
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
                throw new Exception(ex.Message);
            }
            finally { this.miConexion.MiConexion.Close(); }
        }

        private double CantidadInventario(string codigo)
        {
            try
            {
                string sql = "SELECT inventario.cantidad_inventario FROM inventario WHERE inventario.codigointernoproducto = '" + codigo + "';";
                this.miComando = new NpgsqlCommand();
                this.miComando.Connection = this.miConexion.MiConexion;
                this.miComando.CommandType = CommandType.Text;
                this.miComando.CommandText = sql;
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
                throw new Exception(ex.Message);
            }
            finally { this.miConexion.MiConexion.Close(); }
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