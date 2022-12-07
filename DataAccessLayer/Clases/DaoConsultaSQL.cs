using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using Npgsql;
using DTO.Clases;
using Utilities;

namespace DataAccessLayer.Clases
{
    public class DaoConsultaSQL
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

        public DaoConsultaSQL()
        {
            this.miConexion = new Conexion();
        }

        public void NuevaConexion()
        {
            try
            {
                miConexion = new Conexion();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public DataTable Consulta(string sql)
        {
            try
            {
                var tabla = new DataTable();
                miAdapter = new NpgsqlDataAdapter(sql, miConexion.MiConexion);
                miAdapter.SelectCommand.CommandType = CommandType.Text;
                miAdapter.Fill(tabla);
                return tabla;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        public DataTable IvaEnVentas(DateTime fecha, DateTime fecha2)
        {
            try
            {
                string sql = "SELECT fecha, iva, mi_round((SUM(total) / (1 + (iva / 100))), 0) AS base, SUM(total) - mi_round((SUM(total) / (1 + (iva / 100))), 0) AS valor_iva, " +
                   " SUM(total) AS total FROM view_resumen_facturas_venta_  " +
                   "WHERE (idestado = 1 OR idestado = 2) AND estado = TRUE AND fecha BETWEEN '" + fecha.ToShortDateString() + "' AND '" + fecha2.ToShortDateString() + "' " +
                   "GROUP BY fecha, iva ORDER BY fecha ASC, iva ASC; ";
                var tabla = new DataTable();
                miAdapter = new NpgsqlDataAdapter(sql, miConexion.MiConexion);
                miAdapter.SelectCommand.CommandType = CommandType.Text;
                miAdapter.SelectCommand.CommandTimeout = 0;
                //miComando.CommandTimeout = 0;
                miAdapter.Fill(tabla);
                return tabla;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public DataTable IvaEnDevoluciones(DateTime fecha, DateTime fecha2)
        {
            try
            {
                string sql = "SELECT fecha, iva, mi_round(SUM(valor * cantidad), 0) AS base, mi_round((mi_round(SUM(valor * cantidad), 1) * iva / 100), 0) AS valor_iva, mi_round(SUM(valor * cantidad), 0) + " +
                   "mi_round((mi_round(SUM(valor * cantidad), 1) * iva / 100), 0) AS total FROM view_detalle_devolucion_venta " +
                   "WHERE fecha BETWEEN '" + fecha.ToShortDateString() + "' AND '" + fecha2.ToShortDateString() + "' GROUP BY fecha, iva ORDER BY fecha ASC, iva ASC; ";
                var tabla = new DataTable();
                miAdapter = new NpgsqlDataAdapter(sql, miConexion.MiConexion);
                miAdapter.SelectCommand.CommandType = CommandType.Text;
                miAdapter.SelectCommand.CommandTimeout = 0;
                miAdapter.Fill(tabla);
                return tabla;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        public DataTable IvaDeCosto(string codigos, DateTime fecha, DateTime fecha2)
        {
            try
            {
                string sql = "SELECT factura_venta.fecha_factura_venta AS fecha, producto_factura_venta.valor_iva AS iva,  mi_round((mi_round(SUM(producto_factura_venta.costo * " +
                  "producto_factura_venta.cantidadproducto_factura_venta), 0) / (1 + (producto_factura_venta.valor_iva / 100))), 0) AS base_costo, mi_round(SUM(producto_factura_venta.costo * " +
                  "producto_factura_venta.cantidadproducto_factura_venta), 0) - mi_round((mi_round(SUM(producto_factura_venta.costo * producto_factura_venta.cantidadproducto_factura_venta), 0) / " +
                  "(1 + (producto_factura_venta.valor_iva / 100))), 0)  AS costo_iva, mi_round(SUM(producto_factura_venta.costo * producto_factura_venta.cantidadproducto_factura_venta), 0) AS costo_total " +
                  "FROM factura_venta, producto_factura_venta WHERE factura_venta.id = producto_factura_venta.id_factura AND factura_venta.fecha_factura_venta BETWEEN " +
                  "'" + fecha.ToShortDateString() + "' AND '" + fecha2.ToShortDateString() + "' AND " +
                  "(factura_venta.idestado = 1 OR factura_venta.idestado = 2) AND factura_venta.estado = TRUE AND producto_factura_venta.retorno = FALSE " + codigos + " GROUP BY  " +
                  " factura_venta.fecha_factura_venta, producto_factura_venta.valor_iva ORDER BY factura_venta.fecha_factura_venta ASC, producto_factura_venta.valor_iva ASC;";
                var tabla = new DataTable();
                miAdapter = new NpgsqlDataAdapter(sql, miConexion.MiConexion);
                miAdapter.SelectCommand.CommandType = CommandType.Text;
                miAdapter.SelectCommand.CommandTimeout = 0;
                miAdapter.Fill(tabla);
                return tabla;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        public DataTable IvaVentaParaCosto(string codigos, DateTime fecha, DateTime fecha2)
        {
            try
            {
                string sql = "SELECT factura_venta.fecha_factura_venta AS fecha, producto_factura_venta.valor_iva, mi_round(SUM(producto_factura_venta.valorunitarioproducto_factura_venta * " +
                  "producto_factura_venta.cantidadproducto_factura_venta), 0) AS venta FROM factura_venta, producto_factura_venta WHERE factura_venta.id = producto_factura_venta.id_factura AND " +
                  "factura_venta.fecha_factura_venta BETWEEN '" + fecha.ToShortDateString() + "' AND '" + fecha2.ToShortDateString() + "' AND (factura_venta.idestado = 1 OR factura_venta.idestado = 2) AND " +
                  "factura_venta.estado = TRUE AND producto_factura_venta.retorno = FALSE " + codigos + " GROUP BY factura_venta.fecha_factura_venta, producto_factura_venta.valor_iva ORDER BY " +
                  "factura_venta.fecha_factura_venta ASC, producto_factura_venta.valor_iva ASC;";
                var tabla = new DataTable();
                miAdapter = new NpgsqlDataAdapter(sql, miConexion.MiConexion);
                miAdapter.SelectCommand.CommandType = CommandType.Text;
                miAdapter.SelectCommand.CommandTimeout = 0;
                miAdapter.Fill(tabla);
                return tabla;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }





        public void ActualizarTotalProductoVenta(DateTime fecha, DateTime fecha2)
        {
            try
            {
                bool redondearPrecio = Convert.ToBoolean(AppConfiguracion.ValorSeccion("redondeo_precio_dos"));
                bool tipoAproxPrecio = Convert.ToBoolean(AppConfiguracion.ValorSeccion("tipo_aprox_precio"));

                List<ProductoFacturaProveedor> productos = new List<ProductoFacturaProveedor>();
                string sql = "SELECT producto_factura_venta.idproducto_factura_venta, producto_factura_venta.cantidadproducto_factura_venta, producto_factura_venta.valorunitarioproducto_factura_venta, " +
                "producto_factura_venta.valor_descuento, producto_factura_venta.valor_iva, producto_factura_venta.impoconsumo, producto_factura_venta.total FROM factura_venta, producto_factura_venta WHERE " +
                "factura_venta.id = producto_factura_venta.id_factura AND factura_venta.estado = true AND (factura_venta.idestado = 1 OR factura_venta.idestado = 2) AND " +
                "factura_venta.fecha_factura_venta between '" + fecha.ToShortDateString() + "' and '" + fecha2.ToShortDateString() + "';";

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
                    p.Cantidad = reader.GetDouble(1);
                    p.Valor = reader.GetDouble(2);
                    p.Producto.Descuento = reader.GetDouble(3);
                    p.Valor_Iva = reader.GetDouble(4);
                    p.ImpoConsumo = reader.GetDouble(5);
                    p.Total = reader.GetInt32(6);
                    productos.Add(p);
                }
                miConexion.MiConexion.Close();
                miComando.Dispose();

                foreach (var p in productos)
                {
                    if (p.Producto.Descuento > 0)
                    {
                        p.Valor = Math.Round((p.Valor - (p.Valor * p.Producto.Descuento / 100)), 1);
                    }
                    p.ValorReal = Math.Round((p.Valor * p.Valor_Iva / 100), 1);

                    if (redondearPrecio)
                    {
                        p.Valor = UseObject.Aproximar(Convert.ToInt32(p.Valor + p.ValorReal + p.ImpoConsumo), tipoAproxPrecio);
                    }
                    else
                    {
                        p.Valor = Math.Round((p.Valor + p.ValorReal + p.ImpoConsumo), 0);
                    }

                    p.Total = Convert.ToInt32(p.Valor * p.Cantidad);
                    ActualizarTotal(p.Id, p.Total);

                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally { miConexion.MiConexion.Close(); }
        }

        private void ActualizarTotal(int id, int total)
        {
            try
            {
                string sql = "update producto_factura_venta set total = " + total + " where idproducto_factura_venta = " + id + ";";

                miComando = new NpgsqlCommand();
                miComando.Connection = miConexion.MiConexion;
                miComando.CommandType = CommandType.Text;
                miComando.CommandText = sql;
                miComando.CommandTimeout = 0;
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


        public void InflarValorBaseVenta()
        {
            try
            {
                var fechas = new List<FacturaVenta>
                { 
                    new FacturaVenta { Id = 1, FechaFactura = new DateTime(2020, 1, 31) },
                    new FacturaVenta { Id = 2, FechaFactura = new DateTime(2020, 2, 29) },
                    new FacturaVenta { Id = 3, FechaFactura = new DateTime(2020, 3, 31) },
                    new FacturaVenta { Id = 4, FechaFactura = new DateTime(2020, 4, 30) }
                };

                // var matriz = Valores();
                foreach (var m in Valores())
                {
                    foreach (var fecha in fechas.Where(f => f.Id.Equals(m.IdFactura)))
                    {
                        /* if (m.Valor_Iva.Equals(0) && (fecha.FechaFactura.Month.Equals(1) || fecha.FechaFactura.Month.Equals(4)))
                         {
                             var j = 0;
                         }*/

                        var prodFactura = FacturaIva(fecha.FechaFactura, m.Valor_Iva);
                        if (m.Valor_Iva.Equals(5))
                        {
                            prodFactura.Producto.CodigoInternoProducto = "1000002";
                        }
                        else
                        {
                            if (m.Valor_Iva.Equals(19))
                            {
                                prodFactura.Producto.CodigoInternoProducto = "1000001";
                            }
                            else
                            {
                                prodFactura.Producto.CodigoInternoProducto = "1000000";
                            }
                        }
                        prodFactura.Valor *= prodFactura.Cantidad;
                        prodFactura.Valor += m.Valor;
                        prodFactura.Costo = Convert.ToInt32((prodFactura.Valor + (prodFactura.Valor * m.Valor_Iva / 100)) * 0.9);

                        //  ACTUALIZO EL VALOR DE BASE.
                        FacturaEditar(prodFactura);

                        if (m.Valor_Iva.Equals(0))
                        {
                            fecha.FechaFactura = fecha.FechaFactura.AddDays(-1);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private void FacturaEditar(ProductoFacturaProveedor p)
        {
            try
            {
                string sql = "UPDATE producto_factura_venta SET codigointernoproducto = '" + p.Producto.CodigoInternoProducto + "' , " +
                " valorunitarioproducto_factura_venta = @valor, costo = @costo, valor_venta_real = @valor_r , cantidadproducto_factura_venta = 1 " +
                "WHERE idproducto_factura_venta = " + p.Id + ";";

                miComando = new NpgsqlCommand();
                miComando.Connection = miConexion.MiConexion;
                miComando.CommandType = CommandType.Text;
                miComando.CommandText = sql;
                miComando.Parameters.AddWithValue("valor", p.Valor);
                miComando.Parameters.AddWithValue("costo", p.Costo);
                miComando.Parameters.AddWithValue("valor_r", p.Valor);
                miComando.CommandTimeout = 0;
                miConexion.MiConexion.Open();

                miComando.ExecuteNonQuery();

                miConexion.MiConexion.Close();
                miComando.Dispose();


                /*var listado = new List<ProductoFacturaProveedor>();
                string sql = "";

                miComando = new NpgsqlCommand();
                miComando.Connection = miConexion.MiConexion;
                miComando.CommandType = CommandType.Text;
                miComando.CommandText = sql;
                miComando.CommandTimeout = 0;
                miConexion.MiConexion.Open();
                NpgsqlDataReader reader = miComando.ExecuteReader();
                while (reader.Read())
                {
                    var factura = new ProductoFacturaProveedor();
                    factura.Id = reader.GetInt32(0);
                    factura.Valor_Iva = reader.GetDouble(1);
                    factura.Cantidad = Convert.ToDouble(reader.GetInt64(2);
                    listado.Add(factura);
                }
                miConexion.MiConexion.Close();
                miComando.Dispose();*/
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally { miConexion.MiConexion.Close(); }
        }

        private ProductoFacturaProveedor FacturaIva(DateTime fecha, double iva)
        {
            try
            {
                var p = new ProductoFacturaProveedor();
                var listado = new List<ProductoFacturaProveedor>();
                string sql = "SELECT factura_venta.id, producto_factura_venta.valor_iva , COUNT(producto_factura_venta.idproducto_factura_venta) AS conteo " +
                "FROM factura_venta, producto_factura_venta WHERE factura_venta.id = producto_factura_venta.id_factura AND factura_venta.idestado = 1 AND " +
                "factura_venta.estado = TRUE AND producto_factura_venta.retorno = FALSE AND producto_factura_venta.valor_iva = " + iva + " AND " +
                "factura_venta.fecha_factura_venta = '" + fecha.ToShortDateString() + "' GROUP BY factura_venta.id, producto_factura_venta.valor_iva " +
                "ORDER BY factura_venta.id DESC;";

                miComando = new NpgsqlCommand();
                miComando.Connection = miConexion.MiConexion;
                miComando.CommandType = CommandType.Text;
                miComando.CommandText = sql;
                miComando.CommandTimeout = 0;
                miConexion.MiConexion.Open();
                NpgsqlDataReader reader = miComando.ExecuteReader();
                while (reader.Read())
                {
                    var factura = new ProductoFacturaProveedor();
                    factura.Id = reader.GetInt32(0);
                    factura.Valor_Iva = reader.GetDouble(1);
                    factura.Cantidad = Convert.ToDouble(reader.GetInt64(2));
                    listado.Add(factura);
                }
                miConexion.MiConexion.Close();
                miComando.Dispose();

                foreach (var fact in listado)
                {
                    if (CountRowFactura(fact.Id).Equals(1))
                    {
                        p = Producto(fact.Id);
                        break;
                    }
                }

                return p;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally { miConexion.MiConexion.Close(); }
        }

        private int CountRowFactura(int id)
        {
            try
            {
                var listado = new List<ProductoFacturaProveedor>();
                string sql = "SELECT count(*) FROM producto_factura_venta WHERE producto_factura_venta.id_factura = " + id + ";";

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
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally { miConexion.MiConexion.Close(); }
        }

        private ProductoFacturaProveedor Producto(int idFactura)
        {
            try
            {
                var listado = new List<ProductoFacturaProveedor>();
                string sql = "SELECT * FROM producto_factura_venta WHERE id_factura = " + idFactura + ";";

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
                    p.Cantidad = reader.GetDouble(3);
                    p.Valor = reader.GetDouble(4);
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

        // EL CENTRAL
        private List<ProductoFacturaProveedor> Valores()
        {
            return new
            List<ProductoFacturaProveedor>
            {
                // Id = identificador consecutivo
                // IdFactura = identificador de mes 1 : enero, 2 : febrero ...
                new ProductoFacturaProveedor { Id = 1, IdFactura = 1, Valor_Iva = 5, Valor = 1448750, Retorno = false }, 
                new ProductoFacturaProveedor { Id = 2, IdFactura = 1, Valor_Iva = 19, Valor = 1440000, Retorno = false }, 

                new ProductoFacturaProveedor { Id = 3, IdFactura = 1, Valor_Iva = 5, Valor = 1450000, Retorno = false }, 
                new ProductoFacturaProveedor { Id = 4, IdFactura = 1, Valor_Iva = 19, Valor = 1445000, Retorno = false }, 

                new ProductoFacturaProveedor { Id = 5, IdFactura = 1, Valor_Iva = 5, Valor = 1440000, Retorno = false }, 
                new ProductoFacturaProveedor { Id = 6, IdFactura = 1, Valor_Iva = 19, Valor = 1438750, Retorno = false }, 

                new ProductoFacturaProveedor { Id = 7, IdFactura = 1, Valor_Iva = 5, Valor = 1456250, Retorno = false }, 
                new ProductoFacturaProveedor { Id = 8, IdFactura = 1, Valor_Iva = 19, Valor = 1441250, Retorno = false }, 
           //*****************************************                                                          **********************
                new ProductoFacturaProveedor { Id = 9, IdFactura = 2, Valor_Iva = 5, Valor = 1436250, Retorno = false }, 
                new ProductoFacturaProveedor { Id = 10, IdFactura = 2, Valor_Iva = 19, Valor = 1435000, Retorno = false }, 

                new ProductoFacturaProveedor { Id = 11, IdFactura = 2, Valor_Iva = 5, Valor = 1430000, Retorno = false }, 
                new ProductoFacturaProveedor { Id = 12, IdFactura = 2, Valor_Iva = 19, Valor = 1430000, Retorno = false }, 

                new ProductoFacturaProveedor { Id = 13, IdFactura = 2, Valor_Iva = 5, Valor = 1440000, Retorno = false }, 
                new ProductoFacturaProveedor { Id = 14, IdFactura = 2, Valor_Iva = 19, Valor = 1437000, Retorno = false }, 

                new ProductoFacturaProveedor { Id = 15, IdFactura = 2, Valor_Iva = 5, Valor = 1438750, Retorno = false }, 
                new ProductoFacturaProveedor { Id = 16, IdFactura = 2, Valor_Iva = 19, Valor = 1434000, Retorno = false }, 
            //*****************************************                                                          **********************
                new ProductoFacturaProveedor { Id = 17, IdFactura = 3, Valor_Iva = 5, Valor = 1438000, Retorno = false }, 
                new ProductoFacturaProveedor { Id = 18, IdFactura = 3, Valor_Iva = 19, Valor = 1440000, Retorno = false }, 

                new ProductoFacturaProveedor { Id = 19, IdFactura = 3, Valor_Iva = 5, Valor = 1435000, Retorno = false }, 
                new ProductoFacturaProveedor { Id = 20, IdFactura = 3, Valor_Iva = 19, Valor = 1437000, Retorno = false }, 

                new ProductoFacturaProveedor { Id = 21, IdFactura = 3, Valor_Iva = 5, Valor = 1440000, Retorno = false }, 
                new ProductoFacturaProveedor { Id = 22, IdFactura = 3, Valor_Iva = 19, Valor = 1439250, Retorno = false }, 

                new ProductoFacturaProveedor { Id = 23, IdFactura = 3, Valor_Iva = 5, Valor = 1439000, Retorno = false }, 
                new ProductoFacturaProveedor { Id = 24, IdFactura = 3, Valor_Iva = 19, Valor = 1438750, Retorno = false }, 
            //*****************************************                                                          **********************
                new ProductoFacturaProveedor { Id = 25, IdFactura = 4, Valor_Iva = 5, Valor = 1427000, Retorno = false }, 
                new ProductoFacturaProveedor { Id = 26, IdFactura = 4, Valor_Iva = 19, Valor = 1440000, Retorno = false }, 

                new ProductoFacturaProveedor { Id = 27, IdFactura = 4, Valor_Iva = 5, Valor = 1430000, Retorno = false }, 
                new ProductoFacturaProveedor { Id = 28, IdFactura = 4, Valor_Iva = 19, Valor = 1435000, Retorno = false }, 

                new ProductoFacturaProveedor { Id = 29, IdFactura = 4, Valor_Iva = 5, Valor = 1425000, Retorno = false }, 
                new ProductoFacturaProveedor { Id = 30, IdFactura = 4, Valor_Iva = 19, Valor = 1433000, Retorno = false }, 

                new ProductoFacturaProveedor { Id = 31, IdFactura = 4, Valor_Iva = 5, Valor = 1426000, Retorno = false }, 
                new ProductoFacturaProveedor { Id = 32, IdFactura = 4, Valor_Iva = 19, Valor = 1436000, Retorno = false }, 
            };
        }

        // LA CAMPIÑA
        private List<ProductoFacturaProveedor> Valores_()
        {
            return new
            List<ProductoFacturaProveedor>
            {
                // Id = identificador consecutivo
                // IdFactura = identificador de mes 1 : enero, 2 : febrero ...
                new ProductoFacturaProveedor { Id = 1, IdFactura = 1, Valor_Iva = 19, Valor = 4480000, Retorno = false }, 
                new ProductoFacturaProveedor { Id = 2, IdFactura = 1, Valor_Iva = 5, Valor = 2781250, Retorno = false }, 
                new ProductoFacturaProveedor { Id = 3, IdFactura = 1, Valor_Iva = 0, Valor = 5780000, Retorno = false }, 

                new ProductoFacturaProveedor { Id = 4, IdFactura = 1, Valor_Iva = 19, Valor = 4530000, Retorno = false }, 
                new ProductoFacturaProveedor { Id = 5, IdFactura = 1, Valor_Iva = 5, Valor = 2823750, Retorno = false }, 
                new ProductoFacturaProveedor { Id = 6, IdFactura = 1, Valor_Iva = 0, Valor = 5802500, Retorno = false }, 

                new ProductoFacturaProveedor { Id = 7, IdFactura = 1, Valor_Iva = 19, Valor = 4610000, Retorno = false }, 
                new ProductoFacturaProveedor { Id = 8, IdFactura = 1, Valor_Iva = 5, Valor = 2745000, Retorno = false }, 
                new ProductoFacturaProveedor { Id = 9, IdFactura = 1, Valor_Iva = 0, Valor = 5795000, Retorno = false }, 

                new ProductoFacturaProveedor { Id = 10, IdFactura = 1, Valor_Iva = 19, Valor = 4480000, Retorno = false }, 
                new ProductoFacturaProveedor { Id = 11, IdFactura = 1, Valor_Iva = 5, Valor = 2775000, Retorno = false }, 
                new ProductoFacturaProveedor { Id = 12, IdFactura = 1, Valor_Iva = 0, Valor = 5832500, Retorno = false }, 
           //*****************************************                                                          **********************
                new ProductoFacturaProveedor { Id = 13, IdFactura = 2, Valor_Iva = 19, Valor = 4668750, Retorno = false }, 
                new ProductoFacturaProveedor { Id = 14, IdFactura = 2, Valor_Iva = 5, Valor = 2745000, Retorno = false }, 
                new ProductoFacturaProveedor { Id = 15, IdFactura = 2, Valor_Iva = 0, Valor = 5912500, Retorno = false }, 

                new ProductoFacturaProveedor { Id = 16, IdFactura = 2, Valor_Iva = 19, Valor = 4496250, Retorno = false }, 
                new ProductoFacturaProveedor { Id = 17, IdFactura = 2, Valor_Iva = 5, Valor = 2630000, Retorno = false }, 
                new ProductoFacturaProveedor { Id = 18, IdFactura = 2, Valor_Iva = 0, Valor = 5915000, Retorno = false }, 

                new ProductoFacturaProveedor { Id = 19, IdFactura = 2, Valor_Iva = 19, Valor = 4370000, Retorno = false }, 
                new ProductoFacturaProveedor { Id = 20, IdFactura = 2, Valor_Iva = 5, Valor = 2765000, Retorno = false }, 
                new ProductoFacturaProveedor { Id = 21, IdFactura = 2, Valor_Iva = 0, Valor = 5895000, Retorno = false }, 

                new ProductoFacturaProveedor { Id = 22, IdFactura = 2, Valor_Iva = 19, Valor = 4450000, Retorno = false }, 
                new ProductoFacturaProveedor { Id = 23, IdFactura = 2, Valor_Iva = 5, Valor = 2840000, Retorno = false }, 
                new ProductoFacturaProveedor { Id = 24, IdFactura = 2, Valor_Iva = 0, Valor = 5927500, Retorno = false }, 
            //*****************************************                                                          **********************
                new ProductoFacturaProveedor { Id = 25, IdFactura = 3, Valor_Iva = 19, Valor = 4270000, Retorno = false }, 
                new ProductoFacturaProveedor { Id = 26, IdFactura = 3, Valor_Iva = 5, Valor = 2810000, Retorno = false }, 
                new ProductoFacturaProveedor { Id = 27, IdFactura = 3, Valor_Iva = 0, Valor = 6095000, Retorno = false }, 

                new ProductoFacturaProveedor { Id = 28, IdFactura = 3, Valor_Iva = 19, Valor = 4155000, Retorno = false }, 
                new ProductoFacturaProveedor { Id = 29, IdFactura = 3, Valor_Iva = 5, Valor = 2948000, Retorno = false }, 
                new ProductoFacturaProveedor { Id = 30, IdFactura = 3, Valor_Iva = 0, Valor = 6025000, Retorno = false }, 

                new ProductoFacturaProveedor { Id = 31, IdFactura = 3, Valor_Iva = 19, Valor = 4245000, Retorno = false }, 
                new ProductoFacturaProveedor { Id = 32, IdFactura = 3, Valor_Iva = 5, Valor = 2905000, Retorno = false }, 
                new ProductoFacturaProveedor { Id = 33, IdFactura = 3, Valor_Iva = 0, Valor = 6000000, Retorno = false }, 

                new ProductoFacturaProveedor { Id = 34, IdFactura = 3, Valor_Iva = 19, Valor = 4310000, Retorno = false }, 
                new ProductoFacturaProveedor { Id = 35, IdFactura = 3, Valor_Iva = 5, Valor = 2957000, Retorno = false }, 
                new ProductoFacturaProveedor { Id = 36, IdFactura = 3, Valor_Iva = 0, Valor = 6040000, Retorno = false }, 
            //*****************************************                                                          **********************
                new ProductoFacturaProveedor { Id = 37, IdFactura = 4, Valor_Iva = 19, Valor = 4436250, Retorno = false }, 
                new ProductoFacturaProveedor { Id = 38, IdFactura = 4, Valor_Iva = 5, Valor = 2818750, Retorno = false }, 
                new ProductoFacturaProveedor { Id = 39, IdFactura = 4, Valor_Iva = 0, Valor = 5989000, Retorno = false }, 

                new ProductoFacturaProveedor { Id = 40, IdFactura = 4, Valor_Iva = 19, Valor = 4483750, Retorno = false }, 
                new ProductoFacturaProveedor { Id = 41, IdFactura = 4, Valor_Iva = 5, Valor = 2745000, Retorno = false }, 
                new ProductoFacturaProveedor { Id = 42, IdFactura = 4, Valor_Iva = 0, Valor = 5995000, Retorno = false }, 

                new ProductoFacturaProveedor { Id = 43, IdFactura = 4, Valor_Iva = 19, Valor = 4465000, Retorno = false }, 
                new ProductoFacturaProveedor { Id = 44, IdFactura = 4, Valor_Iva = 5, Valor = 2775000, Retorno = false },
                new ProductoFacturaProveedor { Id = 45, IdFactura = 4, Valor_Iva = 0, Valor = 6005000, Retorno = false }, 

                new ProductoFacturaProveedor { Id = 46, IdFactura = 4, Valor_Iva = 19, Valor = 4550000, Retorno = false }, 
                new ProductoFacturaProveedor { Id = 47, IdFactura = 4, Valor_Iva = 5, Valor = 2936250, Retorno = false }, 
                new ProductoFacturaProveedor { Id = 48, IdFactura = 4, Valor_Iva = 0, Valor = 5991000, Retorno = false }, 
            };
        }


        private void AjustarVentasBD()
        {
            try
            {

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private void AjusteProductosProveedores()
        {
            try
            {
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        public void ExecuteNonQuery(string query)
        {
            try
            {
                miComando = new NpgsqlCommand();
                miComando.Connection = miConexion.MiConexion;
                miComando.CommandType = CommandType.Text;
                miComando.CommandText = query;
                miComando.CommandTimeout = 0;
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

        public DataTable ConsultaIvaCategorias(DateTime fecha, DateTime fecha2, string[] filtro)
        {
            try
            {
                var wFiltro = filtro.Where(f => !f.Equals(""));
                var last_ = wFiltro.Last();
                string strFiltro = "(";
                foreach (var f in wFiltro)
                {
                    strFiltro += "producto.nombreproducto ILIKE '%" + f + "%'";
                    if (!(f.Equals(last_)))
                    {
                        strFiltro += " OR ";
                    }
                }
                strFiltro += ")";


               /* string strFiltro = "(";
                foreach (var f in filtro)
                {
                    if (!f.Equals(""))
                    {
                        strFiltro += "producto.nombreproducto ILIKE '%" + f + "%' OR ";
                    }
                }
                strFiltro += ")";*/

                string sql = "SELECT producto_factura_venta.valor_iva AS iva, sum(mi_round((producto_factura_venta.cantidadproducto_factura_venta * " +
                    "producto_factura_venta.valorunitarioproducto_factura_venta), 1)) AS base_iva , (sum(mi_round((producto_factura_venta.cantidadproducto_factura_venta * " + 
                    "producto_factura_venta.valorunitarioproducto_factura_venta), 1)))  * (producto_factura_venta.valor_iva / 100) AS v_iva , sum(mi_round((producto_factura_venta.cantidadproducto_factura_venta * " +
                    "producto_factura_venta.valorunitarioproducto_factura_venta), 1)) + (sum(mi_round((producto_factura_venta.cantidadproducto_factura_venta * producto_factura_venta.valorunitarioproducto_factura_venta), 1))) " +
                    "* (producto_factura_venta.valor_iva / 100) AS total FROM factura_venta, producto_factura_venta, producto WHERE factura_venta.id = producto_factura_venta.id_factura AND " +
                    "producto.codigointernoproducto = producto_factura_venta.codigointernoproducto AND (factura_venta.idestado = 1 OR factura_venta.idestado = 2) AND " +
                    "factura_venta.estado = TRUE AND producto_factura_venta.retorno = FALSE AND factura_venta.fecha_factura_venta BETWEEN '" + fecha.ToShortDateString() +"' AND '" + fecha2.ToShortDateString() + "' AND ";
                sql += strFiltro;
                sql += " GROUP BY producto_factura_venta.valor_iva ORDER BY producto_factura_venta.valor_iva;";
                var tabla = new DataTable();
                miAdapter = new NpgsqlDataAdapter(sql, miConexion.MiConexion);
                miAdapter.SelectCommand.CommandType = CommandType.Text;
                miAdapter.SelectCommand.CommandTimeout = 0;
                miAdapter.Fill(tabla);
                return tabla;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public DataTable ConsultaIvaCategoriasFiltroCat(DateTime fecha, DateTime fecha2, string[] filtro)
        {
            try
            {
                var wFiltro = filtro.Where(f => !f.Equals(""));
                var last_ = wFiltro.Last();
                string strFiltro = "(";
                foreach (var f in wFiltro)
                {
                    strFiltro += "producto.codigocategoria = '" + f + "'";
                    if (!(f.Equals(last_)))
                    {
                        strFiltro += " OR ";
                    }
                }
                strFiltro += ")";

                string sql = "SELECT producto_factura_venta.valor_iva AS iva, sum(mi_round((producto_factura_venta.cantidadproducto_factura_venta * " +
                    "producto_factura_venta.valorunitarioproducto_factura_venta), 1)) AS base_iva , (sum(mi_round((producto_factura_venta.cantidadproducto_factura_venta * " +
                    "producto_factura_venta.valorunitarioproducto_factura_venta), 1)))  * (producto_factura_venta.valor_iva / 100) AS v_iva , sum(mi_round((producto_factura_venta.cantidadproducto_factura_venta * " +
                    "producto_factura_venta.valorunitarioproducto_factura_venta), 1)) + (sum(mi_round((producto_factura_venta.cantidadproducto_factura_venta * producto_factura_venta.valorunitarioproducto_factura_venta), 1))) " +
                    "* (producto_factura_venta.valor_iva / 100) AS total FROM factura_venta, producto_factura_venta, producto WHERE factura_venta.id = producto_factura_venta.id_factura AND " +
                    "producto.codigointernoproducto = producto_factura_venta.codigointernoproducto AND (factura_venta.idestado = 1 OR factura_venta.idestado = 2) AND " +
                    "factura_venta.estado = TRUE AND producto_factura_venta.retorno = FALSE AND factura_venta.fecha_factura_venta BETWEEN '" + fecha.ToShortDateString() + "' AND '" + fecha2.ToShortDateString() + "' AND ";                
                sql += strFiltro;
                sql += " GROUP BY producto_factura_venta.valor_iva ORDER BY producto_factura_venta.valor_iva;";
                var tabla = new DataTable();
                miAdapter = new NpgsqlDataAdapter(sql, miConexion.MiConexion);
                miAdapter.SelectCommand.CommandType = CommandType.Text;
                miAdapter.SelectCommand.CommandTimeout = 0;
                miAdapter.Fill(tabla);
                return tabla;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        DaoProducto daoProducto = new DaoProducto();
        public void AjustarCodigosBarrasInterno()
        {
            try
            {
                List<Producto> productos = new List<Producto>();
                List<Producto> productosDup = new List<Producto>();
                string sql = 
                    "SELECT codigointernoproducto as codigo, codigobarrasproducto as barras FROM producto;";
                miComando = new NpgsqlCommand();
                miComando.Connection = miConexion.MiConexion;
                miComando.CommandType = CommandType.Text;
                miComando.CommandText = sql;
                miConexion.MiConexion.Open();
                NpgsqlDataReader reader = miComando.ExecuteReader();
                while (reader.Read())
                {
                    productos.Add(new Producto
                    {
                        CodigoInternoProducto = reader.GetString(0),
                        CodigoBarrasProducto = reader.GetString(1)
                    });
                }
                miConexion.MiConexion.Close();
                miComando.Dispose();

                //int count = 0;
                foreach (Producto p in productos)
                {
                    foreach (Producto p_ in productos.Where(ps => ps.CodigoInternoProducto.Equals(p.CodigoBarrasProducto)))
                    {
                        productosDup.Add(p_);
                    }
                }
                foreach (Producto p in productosDup)
                {
                    p.CodigoInternoEditado = daoProducto.ObtenerCodigoInterno().ToString();
                    sql = "update producto set codigointernoproducto = @codeEdit where codigointernoproducto = @code;";
                    miComando = new NpgsqlCommand();
                    miComando.Connection = miConexion.MiConexion;
                    miComando.CommandType = CommandType.Text;
                    miComando.CommandText = sql;
                    miComando.Parameters.AddWithValue("codeEdit", p.CodigoInternoEditado);
                    miComando.Parameters.AddWithValue("code", p.CodigoInternoProducto);
                    miConexion.MiConexion.Open();
                    miComando.ExecuteNonQuery();
                    miConexion.MiConexion.Close();
                    miComando.Dispose();
                    daoProducto.ActualizarProductoInterno(Convert.ToInt32(p.CodigoInternoEditado));
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally { miConexion.MiConexion.Close(); }
        }

        public void ProductAjust()
        {
            try
            {
                string sql = "select * from producto_;";
                CargarAdapter(sql);
                DataTable tProduct_ = new DataTable();
                miAdapter.Fill(tProduct_);


                DataTable tProduct = new DataTable();
                CargarAdapter("select * from producto;");
                miAdapter.Fill(tProduct);

                foreach (DataRow p_ in tProduct_.Rows)
                {
                    var result = tProduct.AsEnumerable().
                        Where(p => p.Field<string>("codigointernoproducto").Equals(p_["codigointernoproducto"].ToString()));
                    if (result.Count() > 0)
                    {
                        // existe, edit precio
                        sql = "UPDATE producto SET  valorventaproducto = @valor WHERE codigointernoproducto = @code;";
                        CargarComando(sql);
                        miComando.Parameters.AddWithValue("code", result.First()["codigointernoproducto"].ToString());
                        miComando.Parameters.AddWithValue("valor", result.First()["valorventaproducto"].ToString());
                        miConexion.MiConexion.Open();
                        miComando.ExecuteNonQuery();
                        miConexion.MiConexion.Close();
                        miComando.Dispose();
                    }
                    else
                    {
                        // no existe, insert
                        sql = "INSERT INTO producto VALUES (@codigo, @barras, @refe, @nombre, @desc, @cate, @idmarca, " + 
                        "@util, @venta, @porcen, @idiva, @unidad, @cantmin, @cantmaxi, @estado, @talla, @color, @decimal, @costo, " +
                        "@descto_mayor, @descto_distribuidor, @idiva_temp, @utilidad_2, @utilidad_3, " +
                        "@codigo_2, @codigo_3, @codigo_4, @codigo_5, @codigo_6, @codigo_7, @descto_3, " +
                        "@impoconsumo, @inicial);";
                        CargarComando(sql);
                        miComando.Parameters.AddWithValue("codigo", p_["codigointernoproducto"].ToString());
                        miComando.Parameters.AddWithValue("barras", p_["codigobarrasproducto"].ToString());
                        miComando.Parameters.AddWithValue("refe", p_["referenciaproducto"].ToString());
                        miComando.Parameters.AddWithValue("nombre", p_["nombreproducto"].ToString());
                        miComando.Parameters.AddWithValue("desc", p_["descripcionproducto"].ToString());
                        miComando.Parameters.AddWithValue("cate", "451");
                        miComando.Parameters.AddWithValue("idmarca", 1003191);
                        miComando.Parameters.AddWithValue("util", p_["utilidadporcentualproducto"]);
                        miComando.Parameters.AddWithValue("venta", p_["valorventaproducto"]);
                        miComando.Parameters.AddWithValue("porcen", p_["aplicaprecioporcentaje"]);
                        miComando.Parameters.AddWithValue("idiva", p_["idiva"]);
                        miComando.Parameters.AddWithValue("unidad", p_["unidadventaproducto"]);
                        miComando.Parameters.AddWithValue("cantmin", p_["cantidadminimaproducto"]);
                        miComando.Parameters.AddWithValue("cantmaxi", p_["cantidadmaximaproducto"]);
                        miComando.Parameters.AddWithValue("estado", p_["estadoproducto"]);
                        miComando.Parameters.AddWithValue("talla", p_["aplicatalla"]);
                        miComando.Parameters.AddWithValue("color", p_["aplicacolor"]);
                        miComando.Parameters.AddWithValue("decimal", p_["cantidad_decimal"]);
                        miComando.Parameters.AddWithValue("costo", p_["precio_costo"]);
                        miComando.Parameters.AddWithValue("descto_mayor", p_["descto_mayor"]);
                        miComando.Parameters.AddWithValue("descto_distribuidor", p_["descto_distribuidor"]);
                        miComando.Parameters.AddWithValue("idiva_temp", p_["idiva_temp"]);
                        miComando.Parameters.AddWithValue("utilidad_2", p_["utilidad_2"]);
                        miComando.Parameters.AddWithValue("utilidad_3", p_["utilidad_3"]);
                        miComando.Parameters.AddWithValue("codigo_2", p_["codigo_2"].ToString());
                        miComando.Parameters.AddWithValue("codigo_3", p_["codigo_3"].ToString());
                        miComando.Parameters.AddWithValue("codigo_4", p_["codigo_4"].ToString());
                        miComando.Parameters.AddWithValue("codigo_5", p_["codigo_5"].ToString());
                        miComando.Parameters.AddWithValue("codigo_6", p_["codigo_6"].ToString());
                        miComando.Parameters.AddWithValue("codigo_7", p_["codigo_7"].ToString());
                        miComando.Parameters.AddWithValue("descto_3", p_["descto_3"].ToString());
                        miComando.Parameters.AddWithValue("impoconsumo", p_["impoconsumo"]);
                        miComando.Parameters.AddWithValue("inicial", false);
                        miConexion.MiConexion.Open();
                        miComando.ExecuteNonQuery();
                        miConexion.MiConexion.Close();
                        miComando.Dispose();

                        sql = "INSERT INTO inventario(codigointernoproducto, idvalor_unidad_medida, idcolor, cantidad_inventario) " +
                            "VALUES (@codigo, @medida, @color, @cant);";
                        CargarComando(sql);
                        miComando.Parameters.AddWithValue("codigo", p_["codigointernoproducto"].ToString());
                        miComando.Parameters.AddWithValue("medida", 3);
                        miComando.Parameters.AddWithValue("color", 0);
                        miComando.Parameters.AddWithValue("cant", 0);
                        miConexion.MiConexion.Open();
                        miComando.ExecuteNonQuery();
                        miConexion.MiConexion.Close();
                        miComando.Dispose();

                        sql = "INSERT INTO producto_medida(codigointernoproducto, idvalor_unidad_medida) " +
                            "VALUES (@codigo, @medida);";
                        CargarComando(sql);
                        miComando.Parameters.AddWithValue("codigo", p_["codigointernoproducto"].ToString());
                        miComando.Parameters.AddWithValue("medida", 3);
                        miConexion.MiConexion.Open();
                        miComando.ExecuteNonQuery();
                        miConexion.MiConexion.Close();
                        miComando.Dispose();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void InsertInventario()
        {
        }

        public void InsertProductProveedor()
        {
        }

        private void CargarComando(string cmd)
        {
            miComando = new NpgsqlCommand();
            miComando.Connection = miConexion.MiConexion;
            miComando.CommandType = CommandType.Text;
            miComando.CommandText = cmd;
        }

        private void CargarAdapter(string cmd)
        {
            miAdapter = new NpgsqlDataAdapter(cmd, miConexion.MiConexion);
            miAdapter.SelectCommand.CommandType = CommandType.Text;
        }
    }
}