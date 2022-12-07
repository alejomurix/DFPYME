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
    public class DaoTrasladoInventario
    {
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

        private DaoCaja miDaoCaja;

        private DaoInventario miDaoInventario;

        private DaoKardex miDaoKardex;

        public DaoTrasladoInventario()
        {
            miConexion = new Conexion();
            miDaoCaja = new DaoCaja();
            miDaoInventario = new DaoInventario();
        }

        public DaoTrasladoInventario(string ipServer)
        {
            miConexion = new Conexion(ipServer, "");
            miDaoCaja = new DaoCaja();
            miDaoInventario = new DaoInventario(ipServer);
            miDaoKardex = new DaoKardex(ipServer);
        }

        public bool TestearConexion(string ipServer)
        {
            try
            {
                miConexion = new Conexion(ipServer, "");
                miConexion.MiConexion.Open();
                miConexion.MiConexion.Close();
                return true;
            }
            catch (Exception)
            {
                return false;
                //throw new Exception("Ocurrió un error al establecer la conexión, verifique la configuración.\n" + ex.Message);
            }
            finally { miConexion.MiConexion.Close(); }
        }

        public void IngresarTraslado(TrasladoInventario traslado, bool salida)
        {
            try
            {
                CargarComando("ingresar_traslado_inventario");
                miComando.Parameters.AddWithValue("", traslado.Tipo);
               // miComando.Parameters.AddWithValue("", traslado.Caja.Id);
                miComando.Parameters.AddWithValue("", traslado.Usuario.Id);
                miComando.Parameters.AddWithValue("", traslado.FechaFactura);
                miComando.Parameters.AddWithValue("", traslado.FechaFactura.TimeOfDay);
                miComando.Parameters.AddWithValue("", traslado.CajaHostOrigen);
                miComando.Parameters.AddWithValue("", traslado.CajaHostDestino);
                miConexion.MiConexion.Open();
                int id = Convert.ToInt32(miComando.ExecuteScalar());
                miConexion.MiConexion.Close();
                miComando.Dispose();

                int idConcepto = 1;
                foreach (var detalle in traslado.Productos)
                {
                    detalle.IdFactura = id;
                    IngresarDetalleTraslado(detalle);

                    miDaoInventario.ActualizarInventario(new Inventario
                    {
                        CodigoProducto = detalle.Codigo,
                        IdMedida = detalle.Producto.IdMedida,
                        IdColor = detalle.Producto.IdColor,
                        Cantidad = detalle.Cantidad
                    } , salida);

                    idConcepto = 22;
                    if (salida)
                    {
                        idConcepto = 23;
                    }
                    miDaoKardex.Insertar(new Kardex
                    {
                        Codigo = detalle.Codigo,
                        IdUsuario = traslado.Usuario.Id,
                        IdConcepto = idConcepto,
                        NoDocumento = id.ToString(),
                        Fecha = traslado.FechaFactura,
                        Cantidad = detalle.Cantidad,
                        Valor = detalle.Costo,
                        Total = Convert.ToInt32(detalle.Costo * detalle.Cantidad)
                    });
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al ingresar el traslado.\n" + ex.Message);
            }
            finally { miConexion.MiConexion.Close(); }
        }

        private void IngresarDetalleTraslado(ProductoFacturaProveedor detalle)
        {
            try
            {
                CargarComando("ingresar_detalle_traslado_inventario");
                miComando.Parameters.AddWithValue("", detalle.IdFactura);
                miComando.Parameters.AddWithValue("", detalle.Codigo);
                miComando.Parameters.AddWithValue("", detalle.Nombre);
                miComando.Parameters.AddWithValue("", detalle.Cantidad);
                miComando.Parameters.AddWithValue("", detalle.Costo);
                miComando.Parameters.AddWithValue("", detalle.Valor);
                miConexion.MiConexion.Open();
                miComando.ExecuteNonQuery();
                miConexion.MiConexion.Close();
                miComando.Dispose();
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al ingresar el detalle del traslado." + ex.Message);
            }
            finally { miConexion.MiConexion.Close(); }
        }

        /*private void IngresarTrasladoDestino(TrasladoInventario traslado)
        {
            try
            {
                var caja = miDaoCaja.CajaId(traslado.Caja.Id);
                var otraConexion = new Conexion(caja.IpServer, "");

            }
            catch (Exception ex)
            { 
                throw new Exception("\nOcurrió un error al ingresar el trasaldo en host de destino.\n" + ex.Message);
            }
        }*/



        // SINCRONIZACION DE PRECIOS, COSTO Y VENTA
        public string SincronizarPrecio()
        {
            string cajaError = "";
            try
            {
                var tProductos = miDaoInventario.ConsultaInventario_();
                var tCajas = miDaoCaja.Cajas();
                foreach (DataRow rCaja in tCajas.Rows)
                {
                    if (rCaja["idcaja"].ToString() != AppConfiguracion.ValorSeccion("id_caja"))
                    {
                        if (TestearConexion(rCaja["ip_host"].ToString()))
                        {
                            foreach (DataRow pRow in tProductos.Rows)
                            {
                                EditarPrecios(rCaja["ip_host"].ToString(), new Producto
                                {
                                    CodigoInternoProducto = pRow["codigo"].ToString(),
                                    UtilidadPorcentualProducto = Convert.ToDouble(pRow["utilidad"]),
                                    ValorVentaProducto = Convert.ToDouble(pRow["precio"]),
                                    ValorCosto = Convert.ToDouble(pRow["valor_mas_iva"]) 
                                });
                            }
                        }
                        else
                        {
                            cajaError += rCaja["numerocaja"].ToString() + "\n";
                        }
                    }
                }
                return cajaError;
            }
            catch (Exception)
            {
                throw new Exception("Ocurrió un error al establecer la conexión, cajas: " + cajaError);
            }
            //finally { this.conexion.MiConexion.Close(); }
        }

        private void EditarPrecios(string ipServer, Producto p)
        {
            try
            {
                string sql =
                "UPDATE producto SET utilidadporcentualproducto = @util, valorventaproducto = @precio, precio_costo = @costo WHERE codigointernoproducto = @codigo;";

                miConexion = new Conexion(ipServer, "");
                
                miComando = new NpgsqlCommand();
                miComando.Connection = miConexion.MiConexion;
                miComando.CommandType = System.Data.CommandType.Text;
                miComando.CommandText = sql;
                miComando.Parameters.AddWithValue("util",   p.UtilidadPorcentualProducto);
                miComando.Parameters.AddWithValue("precio", p.ValorVentaProducto);
                miComando.Parameters.AddWithValue("costo",  p.ValorCosto);
                miComando.Parameters.AddWithValue("codigo", p.CodigoInternoProducto);

                miConexion.MiConexion.Open();
                miComando.ExecuteNonQuery();
                miConexion.MiConexion.Close();
                miComando.Dispose();
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrio un error al editar el producto.\n" + ex.Message);
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