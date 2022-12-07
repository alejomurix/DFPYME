using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using Npgsql;
using DTO.Clases;

namespace DataAccessLayer.Clases
{
    public class DaoCompraSimple
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

        private DaoInventario miDaoInventario;

        public DaoCompraSimple()
        {
            this.miConexion = new Conexion();

            this.miDaoInventario = new DaoInventario();
        }

        // ****************************************************************************************
        //      DESCUENTOS

        public DataTable Descuentos()
        {
            try
            {
                var tabla = new DataTable();
                CargarAdapter("descuentos_compra");
                miAdapter.Fill(tabla);
                return tabla;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al consultar los descuentos.\n" + ex.Message);
            }
        }

        // ****************************************************************************************

        // ****************************************************************************************
        //      COMPRA SIMPLE

        public int IngresarCompra(FacturaProveedor factura)
        {
            try
            {
                CargarComando("insertar_compra_simple");
                miComando.Parameters.AddWithValue("", factura.Proveedor.CodigoInternoProveedor);
                miComando.Parameters.AddWithValue("", factura.FechaFactura);
                miComando.Parameters.AddWithValue("", factura.Valor);
                miComando.Parameters.AddWithValue("", factura.ValorReal);
                miConexion.MiConexion.Open();
                var id = Convert.ToInt32(miComando.ExecuteScalar());
                miConexion.MiConexion.Close();
                miComando.Dispose();
                foreach (var producto in factura.Productos)
                {
                    producto.IdFactura = id;
                    IngresarProductoCompra(producto);
                    this.miDaoInventario.ActualizarInventario(producto.Inventario, false);
                }
                foreach (var descuento in factura.Descuentos)
                {
                    descuento.IdFactura = id;
                    IngresarDescuentoCompra(descuento);
                }
                if (factura.FormaPago.Valor != 0)
                {
                    factura.FormaPago.IdFactura = id;
                    IngresarPagoCompra(factura.FormaPago);
                }
                return id;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al ingresar la compra.\n" + ex.Message);
            }
            finally { miConexion.MiConexion.Close(); }
        }

        public FacturaProveedor Compra(int id)
        {
            try
            {
                CargarComando("compra_simple");
                miComando.Parameters.AddWithValue("", id);
                miConexion.MiConexion.Open();
                NpgsqlDataReader reader = miComando.ExecuteReader();
                var compra = new FacturaProveedor();
                while (reader.Read())
                {
                    compra.Id = reader.GetInt32(0);
                    compra.Proveedor.CodigoInternoProveedor = reader.GetInt32(1);
                    compra.FechaFactura = reader.GetDateTime(2);
                    compra.Valor = reader.GetInt32(3);
                    compra.ValorReal = reader.GetInt32(4);
                }
                miConexion.MiConexion.Close();
                miComando.Dispose();
                return compra;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al consultar la compra\n" + ex.Message);
            }
            finally { miConexion.MiConexion.Close(); }
        }




        // TODOS + FECHA
        public DataTable Compras(DateTime fecha, int rowIndex, int rowMax)
        {
            try
            {
                var tabla = new DataTable();
                CargarAdapter("compras_simple_fecha");
                miAdapter.SelectCommand.Parameters.AddWithValue("", fecha);
                miAdapter.Fill(rowIndex, rowMax, tabla);
                return tabla;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al consultar las compras.\n" + ex.Message);
            }
        }

        public long CountCompras(DateTime fecha)
        {
            try
            {
                CargarComando("count_compras_simple_fecha");
                miComando.Parameters.AddWithValue("", fecha);
                miConexion.MiConexion.Open();
                var rows = Convert.ToInt64(miComando.ExecuteScalar());
                miConexion.MiConexion.Close();
                miComando.Dispose();
                return rows;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al cargar el conteo de los registros de compras.\n" + ex.Message);
            }
            finally { miConexion.MiConexion.Close(); }
        }

        // TODOS + PERIODO
        public DataTable Compras(DateTime fecha, DateTime fecha2, int rowIndex, int rowMax)
        {
            try
            {
                var tabla = new DataTable();
                CargarAdapter("compras_simple_periodo");
                miAdapter.SelectCommand.Parameters.AddWithValue("", fecha);
                miAdapter.SelectCommand.Parameters.AddWithValue("", fecha2);
                miAdapter.Fill(rowIndex, rowMax, tabla);
                return tabla;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al consultar las compras.\n" + ex.Message);
            }
        }

        public long CountCompras(DateTime fecha, DateTime fecha2)
        {
            try
            {
                CargarComando("count_compras_simple_periodo");
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
                throw new Exception("Ocurrió un error al cargar el conteo de los registros de compras.\n" + ex.Message);
            }
            finally { miConexion.MiConexion.Close(); }
        }

        // PROVEEDOR
        public DataTable Compras(int codProveedor, int rowIndex, int rowMax)
        {
            try
            {
                var tabla = new DataTable();
                CargarAdapter("compras_simple");
                miAdapter.SelectCommand.Parameters.AddWithValue("", codProveedor);
                miAdapter.Fill(rowIndex, rowMax, tabla);
                return tabla;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al consultar las compras.\n" + ex.Message);
            }
        }

        public long CountCompras(int codProveedor)
        {
            try
            {
                CargarComando("count_compras_simple");
                miComando.Parameters.AddWithValue("", codProveedor);
                miConexion.MiConexion.Open();
                var rows = Convert.ToInt64(miComando.ExecuteScalar());
                miConexion.MiConexion.Close();
                miComando.Dispose();
                return rows;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al cargar el conteo de los registros de compras..\n" + ex.Message);
            }
            finally { miConexion.MiConexion.Close(); }
        }

        // PROVEEDOR + FECHA
        public DataTable Compras(int codProveedor, DateTime fecha, int rowIndex, int rowMax)
        {
            try
            {
                var tabla = new DataTable();
                CargarAdapter("compras_simple");
                miAdapter.SelectCommand.Parameters.AddWithValue("", codProveedor);
                miAdapter.SelectCommand.Parameters.AddWithValue("", fecha);
                miAdapter.Fill(rowIndex, rowMax, tabla);
                return tabla;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al consultar las compras.\n" + ex.Message);
            }
        }

        public long CountCompras(int codProveedor, DateTime fecha)
        {
            try
            {
                CargarComando("count_compras_simple");
                miComando.Parameters.AddWithValue("", codProveedor);
                miComando.Parameters.AddWithValue("", fecha);
                miConexion.MiConexion.Open();
                var rows = Convert.ToInt64(miComando.ExecuteScalar());
                miConexion.MiConexion.Close();
                miComando.Dispose();
                return rows;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al cargar el conteo de los registros de compras..\n" + ex.Message);
            }
            finally { miConexion.MiConexion.Close(); }
        }

        // PROVEEDOR + PERIODO
        public DataTable Compras(int codProveedor, DateTime fecha, DateTime fecha2, int rowIndex, int rowMax)
        {
            try
            {
                var tabla = new DataTable();
                CargarAdapter("compras_simple");
                miAdapter.SelectCommand.Parameters.AddWithValue("", codProveedor);
                miAdapter.SelectCommand.Parameters.AddWithValue("", fecha);
                miAdapter.SelectCommand.Parameters.AddWithValue("", fecha2);
                miAdapter.Fill(rowIndex, rowMax, tabla);
                return tabla;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al consultar las compras.\n" + ex.Message);
            }
        }

        public long CountCompras(int codProveedor, DateTime fecha, DateTime fecha2)
        {
            try
            {
                CargarComando("count_compras_simple");
                miComando.Parameters.AddWithValue("", codProveedor);
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
                throw new Exception("Ocurrió un error al cargar el conteo de los registros de compras..\n" + ex.Message);
            }
            finally { miConexion.MiConexion.Close(); }
        }


        public DataTable Compras(DateTime fecha)
        {
            try
            {
                var tabla = new DataTable();
                CargarAdapter("compras_simple_fecha");
                miAdapter.SelectCommand.Parameters.AddWithValue("", fecha);
                miAdapter.Fill(tabla);
                return tabla;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al consultar las compras.\n" + ex.Message);
            }
        }

        public DataTable Compras(DateTime fecha, DateTime fecha2)
        {
            try
            {
                var tabla = new DataTable();
                CargarAdapter("compras_simple_periodo");
                miAdapter.SelectCommand.Parameters.AddWithValue("", fecha);
                miAdapter.SelectCommand.Parameters.AddWithValue("", fecha2);
                miAdapter.Fill(tabla);
                return tabla;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al consultar las compras.\n" + ex.Message);
            }
        }

        public DataTable Compras(int codProveedor)
        {
            try
            {
                var tabla = new DataTable();
                CargarAdapter("compras_simple");
                miAdapter.SelectCommand.Parameters.AddWithValue("", codProveedor);
                miAdapter.Fill(tabla);
                return tabla;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al consultar las compras.\n" + ex.Message);
            }
        }

        public DataTable Compras(int codProveedor, DateTime fecha)
        {
            try
            {
                var tabla = new DataTable();
                CargarAdapter("compras_simple");
                miAdapter.SelectCommand.Parameters.AddWithValue("", codProveedor);
                miAdapter.SelectCommand.Parameters.AddWithValue("", fecha);
                miAdapter.Fill(tabla);
                return tabla;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al consultar las compras.\n" + ex.Message);
            }
        }

        public DataTable Compras(int codProveedor, DateTime fecha, DateTime fecha2)
        {
            try
            {
                var tabla = new DataTable();
                CargarAdapter("compras_simple");
                miAdapter.SelectCommand.Parameters.AddWithValue("", codProveedor);
                miAdapter.SelectCommand.Parameters.AddWithValue("", fecha);
                miAdapter.SelectCommand.Parameters.AddWithValue("", fecha2);
                miAdapter.Fill(tabla);
                return tabla;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al consultar las compras.\n" + ex.Message);
            }
        }



        public DataTable ResumenCompra(DateTime fecha)
        {
            try
            {
                var tabla = new DataTable();
                CargarAdapter("resumen_compra_simple");
                miAdapter.SelectCommand.Parameters.AddWithValue("", fecha);
                miAdapter.Fill(tabla);
                return tabla;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al consultar el resumen de compras.\n" + ex.Message);
            }
        }

        public DataTable ResumenCompra(DateTime fecha, DateTime fecha2)
        {
            try
            {
                var tabla = new DataTable();
                CargarAdapter("resumen_compra_simple_periodo");
                miAdapter.SelectCommand.Parameters.AddWithValue("", fecha);
                miAdapter.SelectCommand.Parameters.AddWithValue("", fecha2);
                miAdapter.Fill(tabla);
                return tabla;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al consultar el resumen de compras.\n" + ex.Message);
            }
        }

        public DataTable ResumenCompra(int codProveedor, DateTime fecha)
        {
            try
            {
                var tabla = new DataTable();
                CargarAdapter("resumen_compra_simple");
                miAdapter.SelectCommand.Parameters.AddWithValue("", codProveedor);
                miAdapter.SelectCommand.Parameters.AddWithValue("", fecha);
                miAdapter.Fill(tabla);
                return tabla;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al consultar el resumen de compras.\n" + ex.Message);
            }
        }

        public DataTable ResumenCompra(int codProveedor, DateTime fecha, DateTime fecha2)
        {
            try
            {
                var tabla = new DataTable();
                CargarAdapter("resumen_compra_simple");
                miAdapter.SelectCommand.Parameters.AddWithValue("", codProveedor);
                miAdapter.SelectCommand.Parameters.AddWithValue("", fecha);
                miAdapter.SelectCommand.Parameters.AddWithValue("", fecha2);
                miAdapter.Fill(tabla);
                return tabla;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al consultar el resumen de compras.\n" + ex.Message);
            }
        }




        public List<FacturaProveedor> Cartera(int codProveedor)
        {
            try
            {
                var cartera = new List<FacturaProveedor>();
                CargarComando("cartera_compra_simple");
                miComando.Parameters.AddWithValue("", codProveedor);
                miConexion.MiConexion.Open();
                NpgsqlDataReader reader = miComando.ExecuteReader();
                while (reader.Read())
                {
                    var factura = new FacturaProveedor();
                    factura.Proveedor.CodigoInternoProveedor = reader.GetInt32(0);
                    factura.Proveedor.NitProveedor = reader.GetString(1);
                    factura.Proveedor.NombreProveedor = reader.GetString(2);
                    factura.Id = reader.GetInt32(3);
                    factura.FechaFactura = reader.GetDateTime(4);

                    factura.Valor = reader.GetInt32(7);
                    factura.Pagos = Convert.ToInt32(reader.GetInt64(8));
                    factura.Saldo = Convert.ToInt32(reader.GetInt64(9));
                    cartera.Add(factura);
                }
                miConexion.MiConexion.Close();
                miComando.Dispose();
                return cartera;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al cargar la cartera del proveedor." + ex.Message);
            }
            finally { miConexion.MiConexion.Close(); }
        }


        public int AjustarCompraPagos(int id)
        {
            try
            {
                int diferecia = 0;
                int totalProductos = ProductosDeCompra(id).AsEnumerable().Sum(s => s.Field<int>("total"));
                int totalDesctos = Descuentos(id).AsEnumerable().Sum(s => s.Field<int>("valor"));
                int totalCompra = totalProductos - totalDesctos;
                var pagos = Pagos(id);
                EditarValorCompra(id, totalProductos);
                if (totalCompra < pagos.Sum(s => s.Valor))
                {
                    diferecia = Convert.ToInt32(pagos.Sum(s => s.Valor)) - totalCompra;
                    AjustarPagos(id, totalCompra, pagos);
                }
                return diferecia;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al ajustar la compra.\n" + ex.Message);
            }
        }

        public void EditarValorCompra(int id, int valor)
        {
            try
            {
                CargarComando("editar_total_compra_simple");
                miComando.Parameters.AddWithValue("", id);
                miComando.Parameters.AddWithValue("", valor);
                miConexion.MiConexion.Open();
                miComando.ExecuteNonQuery();
                miConexion.MiConexion.Close();
                miComando.Dispose();
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al editar la compra.\n" + ex.Message);
            }
            finally { miConexion.MiConexion.Close(); }
        }


        // ****************************************************************************************

        // ****************************************************************************************
        //      PRODUCTO COMPRA SIMPLE

        public void IngresarProductoCompra(ProductoFacturaProveedor producto)
        {
            try
            {
                CargarComando("insertar_producto_compra_simple");
                miComando.Parameters.AddWithValue("", producto.IdFactura);
                miComando.Parameters.AddWithValue("", producto.Producto.CodigoInternoProducto);
                miComando.Parameters.AddWithValue("", producto.Cantidad);
                miComando.Parameters.AddWithValue("", producto.Valor);
                miComando.Parameters.AddWithValue("", producto.ValorReal);
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



        public DataTable ProductosDeCompra(int idCompra)
        {
            try
            {
                var tabla = new DataTable();
                CargarAdapter("productos_compra_simple");
                miAdapter.SelectCommand.Parameters.AddWithValue("", idCompra);
                miAdapter.Fill(tabla);
                return tabla;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al consultar los productos de la compra.\n" + ex.Message);
            }
        }


        public void EditarProducto(ProductoFacturaProveedor producto, bool suma)
        {
            try
            {
                CargarComando("editar_producto_compra_simple");
                miComando.Parameters.AddWithValue("", producto.Id);
                miComando.Parameters.AddWithValue("", producto.Cantidad);
                miComando.Parameters.AddWithValue("", producto.Costo);
                miComando.Parameters.AddWithValue("", producto.Valor);
                miConexion.MiConexion.Open();
                miComando.ExecuteNonQuery();
                miConexion.MiConexion.Close();
                miComando.Dispose();
                if (producto.Inventario.CodigoProducto != "")
                {
                    this.miDaoInventario.ActualizarInventario(producto.Inventario, suma);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al editar el producto de la compra.\n" + ex.Message);
            }
            finally { this.miConexion.MiConexion.Close(); }
        }


        public void EliminarProducto(int id)
        {
            try
            {
                CargarComando("eliminar_producto_compra_simple");
                miComando.Parameters.AddWithValue("", id);
                miConexion.MiConexion.Open();
                miComando.ExecuteNonQuery();
                miConexion.MiConexion.Close();
                miComando.Dispose();
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al eliminar el producto de la compra.\n" + ex.Message);
            }
            finally { this.miConexion.MiConexion.Close(); }
        }

        // ****************************************************************************************

        // ****************************************************************************************
        //      DESCUENTO COMPRA SIMPLE

        public void IngresarDescuentoCompra(Descuento descuento)
        {
            try
            {
                CargarComando("insertar_descuento_compra_simple");
                miComando.Parameters.AddWithValue("", descuento.IdFactura);
                miComando.Parameters.AddWithValue("", descuento.IdDescuento);
                miComando.Parameters.AddWithValue("", descuento.ValorDescuento);
                miConexion.MiConexion.Open();
                miComando.ExecuteNonQuery();
                miConexion.MiConexion.Close();
                miComando.Dispose();
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al ingresar el descuento de la compra.\n" + ex.Message);
            }
            finally { miConexion.MiConexion.Close(); }
        }


        public DataTable Descuentos(int idCompra)
        {
            try
            {
                var tabla = new DataTable();
                CargarAdapter("descuentos_compra");
                miAdapter.SelectCommand.Parameters.AddWithValue("", idCompra);
                miAdapter.Fill(tabla);
                return tabla;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al consultar las compras.\n" + ex.Message);
            }
        }


        public DataTable ResumenDescuentos(DateTime fecha)
        {
            try
            {
                var tabla = new DataTable();
                CargarAdapter("resumen_descuentos_compra_simple");
                miAdapter.SelectCommand.Parameters.AddWithValue("", fecha);
                miAdapter.Fill(tabla);
                return tabla;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al consultar el resumen de descuentos.\n" + ex.Message);
            }
        }

        public DataTable ResumenDescuentos(DateTime fecha, DateTime fecha2)
        {
            try
            {
                var tabla = new DataTable();
                CargarAdapter("resumen_descuentos_compra_simple_periodo");
                miAdapter.SelectCommand.Parameters.AddWithValue("", fecha);
                miAdapter.SelectCommand.Parameters.AddWithValue("", fecha2);
                miAdapter.Fill(tabla);
                return tabla;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al consultar el resumen de descuentos.\n" + ex.Message);
            }
        }

        public DataTable ResumenDescuentos(int codProveedor, DateTime fecha)
        {
            try
            {
                var tabla = new DataTable();
                CargarAdapter("resumen_descuentos_compra_simple");
                miAdapter.SelectCommand.Parameters.AddWithValue("", codProveedor);
                miAdapter.SelectCommand.Parameters.AddWithValue("", fecha);
                miAdapter.Fill(tabla);
                return tabla;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al consultar el resumen de descuentos.\n" + ex.Message);
            }
        }

        public DataTable ResumenDescuentos(int codProveedor, DateTime fecha, DateTime fecha2)
        {
            try
            {
                var tabla = new DataTable();
                CargarAdapter("resumen_descuentos_compra_simple");
                miAdapter.SelectCommand.Parameters.AddWithValue("", codProveedor);
                miAdapter.SelectCommand.Parameters.AddWithValue("", fecha);
                miAdapter.SelectCommand.Parameters.AddWithValue("", fecha2);
                miAdapter.Fill(tabla);
                return tabla;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al consultar el resumen de descuentos.\n" + ex.Message);
            }
        }

        public void EditarDescuento(int id, int valor)
        {
            try
            {
                CargarComando("editar_descuento_compra_simple");
                miComando.Parameters.AddWithValue("", id);
                miComando.Parameters.AddWithValue("", valor);
                miConexion.MiConexion.Open();
                miComando.ExecuteNonQuery();
                miConexion.MiConexion.Close();
                miComando.Dispose();
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al editar el descuento de la compra.\n" + ex.Message);
            }
            finally { miConexion.MiConexion.Close(); }
        }


        public void EliminarDescuento(int id)
        {
            try
            {
                CargarComando("eliminar_descuento_compra_simple");
                miComando.Parameters.AddWithValue("", id);
                miConexion.MiConexion.Open();
                miComando.ExecuteNonQuery();
                miConexion.MiConexion.Close();
                miComando.Dispose();
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al eliminar el descuento de la compra.\n" + ex.Message);
            }
            finally { this.miConexion.MiConexion.Close(); }
        }

        // ****************************************************************************************

        // ****************************************************************************************
        //      PAGO COMPRA SIMPLE

        public void IngresarPagoCompra(FormaPago pago)
        {
            try
            {
                CargarComando("insertar_pago_compra_simple");
                miComando.Parameters.AddWithValue("", pago.IdFactura);
                miComando.Parameters.AddWithValue("", pago.Fecha);
                miComando.Parameters.AddWithValue("", pago.Valor);
                miConexion.MiConexion.Open();
                miComando.ExecuteNonQuery();
                miConexion.MiConexion.Close();
                miComando.Dispose();
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al ingresar el pago de la compra.\n" + ex.Message);
            }
            finally { miConexion.MiConexion.Close(); }
        }


        public string IngresarPagoGeneral(int codProveedor, int valor, List<FacturaProveedor> cartera)
        {
            try
            {
                string factura = "";
                var monto = valor;
                foreach (var compra in cartera)
                {
                    if (monto > 0)
                    {
                        var pago = new FormaPago();
                        pago.IdFactura = compra.Id;
                        pago.Fecha = DateTime.Now;

                        if (monto > compra.Saldo)
                        {
                            pago.Valor = compra.Saldo;
                            monto -= compra.Saldo;
                        }
                        else
                        {
                            pago.Valor = monto;
                            monto = 0;
                        }
                        IngresarPagoCompra(pago);
                        factura += compra.Id + ", ";
                    }
                    else
                    {
                        break;
                    }
                }
                return factura;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al ingresar el pago al proveedor." + ex.Message);
            }
        }



        public int ResumenPago(DateTime fecha)
        {
            try
            {
                CargarComando("resumen_pagos_compra_simple");
                miComando.Parameters.AddWithValue("", fecha);
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
                throw new Exception("Ocurrió un error al consultar los pagos de las compras.\n" + ex.Message);
            }
            finally { miConexion.MiConexion.Close(); }
        }

        public int ResumenPago(DateTime fecha, DateTime fecha2)
        {
            try
            {
                CargarComando("resumen_pagos_compra_simple_periodo");
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
                throw new Exception("Ocurrió un error al consultar los pagos de las compras.\n" + ex.Message);
            }
            finally { miConexion.MiConexion.Close(); }
        }

        public int ResumenPago(int codProveedor, DateTime fecha)
        {
            try
            {
                CargarComando("resumen_pagos_compra_simple");
                miComando.Parameters.AddWithValue("", codProveedor);
                miComando.Parameters.AddWithValue("", fecha);
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
                throw new Exception("Ocurrió un error al consultar los pagos de las compras.\n" + ex.Message);
            }
            finally { miConexion.MiConexion.Close(); }
        }

        public int ResumenPago(int codProveedor, DateTime fecha, DateTime fecha2)
        {
            try
            {
                CargarComando("resumen_pagos_compra_simple");
                miComando.Parameters.AddWithValue("", codProveedor);
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
                throw new Exception("Ocurrió un error al consultar los pagos de las compras.\n" + ex.Message);
            }
            finally { miConexion.MiConexion.Close(); }
        }


        public List<FormaPago> Pagos(int idCompra)
        {
            try
            {
                var pagos = new List<FormaPago>();
                CargarComando("pagos_compra_simple");
                miComando.Parameters.AddWithValue("", idCompra);
                miConexion.MiConexion.Open();
                NpgsqlDataReader reader = miComando.ExecuteReader();
                while (reader.Read())
                {
                    var pago = new FormaPago();
                    pago.Id = reader.GetInt32(0);
                    pago.IdFactura = reader.GetInt32(1);
                    pago.Fecha = reader.GetDateTime(2);
                    pago.Valor = reader.GetInt32(3);
                    pagos.Add(pago);
                }
                miConexion.MiConexion.Close();
                miComando.Dispose();
                return pagos;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al consultar los pagos de la compra.\n" + ex.Message);
            }
            finally { miConexion.MiConexion.Close(); }
        }

        public void AjustarPagos(int idCompra, int valor, List<FormaPago> pagos)
        {
            try
            {
                EliminarPagosCompra(idCompra);
                //var query = pagos.OrderByDescending(s => s.Id);
                var monto = valor;
                foreach (var pago in pagos)
                {
                    if (monto > 0)
                    {
                        pago.IdFactura = idCompra;
                        if (monto > pago.Valor)
                        {
                            monto -= Convert.ToInt32(pago.Valor);
                        }
                        else
                        {
                            pago.Valor = monto;
                            monto = 0;
                        }
                        IngresarPagoCompra(pago);
                    }
                    else
                    {
                        break;
                    }
                }
                
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al ajustar los pagos de la compra.\n" + ex.Message);
            }
        }

        public void EditarPago(int id, int valor)
        {
            try
            {
                CargarComando("editar_valor_pago_compra");
                miComando.Parameters.AddWithValue("", id);
                miComando.Parameters.AddWithValue("", valor);
                miConexion.MiConexion.Open();
                miComando.ExecuteNonQuery();
                miConexion.MiConexion.Close();
                miComando.Dispose();
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al editar el pago de la compra\n" + ex.Message);
            }
            finally { miConexion.MiConexion.Close(); }
        }

        public void EliminarPagosCompra(int idCompra)
        {
            try
            {
                CargarComando("eliminar_pagos_compra");
                miComando.Parameters.AddWithValue("", idCompra);
                miConexion.MiConexion.Open();
                miComando.ExecuteNonQuery();
                miConexion.MiConexion.Close();
                miComando.Dispose();
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al eliminar los pagos de la compra.\n" + ex.Message);
            }
            finally { miConexion.MiConexion.Close(); }
        }

        // ****************************************************************************************

        

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