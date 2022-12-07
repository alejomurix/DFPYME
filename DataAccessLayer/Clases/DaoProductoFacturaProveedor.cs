using System;
using System.Data;
using DTO.Clases;
using Npgsql;

namespace DataAccessLayer.Clases
{
    /// <summary>
    /// 
    /// </summary>
    public class DaoProductoFacturaProveedor
    {
        private int IdTipoInventarioInsumo { set; get; }

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
        /// Representa un adaptador de comandos SQL a PostgreSQL.
        /// </summary>
        private NpgsqlDataAdapter miAdapter;

        private DaoInventario miDaoInventario;

        #endregion

        #region Funciones

        /// <summary>
        /// Representa la funcion: insertar_producto_factura_proveedor.
        /// </summary>
        private const string InsertarProductoFactura = "insertar_producto_factura_proveedor";

        /// <summary>
        /// Representa la función editar_producto_factura_proveedor.
        /// </summary>
        private const string EditarProductoFactura = "editar_producto_factura_proveedor";

        /// <summary>
        /// Representa la Función eliminar_producto_factura_proveedor.
        /// </summary>
        private const string EliminarProductoFactura = "eliminar_producto_factura_proveedor";

        #endregion

        #region Mensajes

        /// <summary>
        /// Representa el texto: Ocurrió un error al ingresar el registro del Producto.
        /// </summary>
        private const string ErrorInsertar = "Ocurrió un error al ingresar el registro del Producto.\n";

        /// <summary>
        /// Representa el texto: Ocurrió un error al editar los datos del Producto.
        /// </summary>
        private const string ErrorEditar = "Ocurrió un error al editar los datos del Producto.\n";

        /// <summary>
        /// Ocurrió un error al eliminar el registro de Producto.
        /// </summary>
        private const string ErrorEliminar = "Ocurrió un error al eliminar el registro de Producto.\n";

        #endregion

        /// <summary>
        /// 
        /// </summary>
        public DaoProductoFacturaProveedor()
        {
            this.IdTipoInventarioInsumo = 2;
            this.miConexion = new Conexion();
            miDaoInventario = new DaoInventario();
        }

        public bool ExisteNumeroFactura(int codProveedor, string numero)
        {
            try
            {
                this.CargarComando("existe_factura_proveedor");
                this.miComando.Parameters.AddWithValue("", codProveedor);
                this.miComando.Parameters.AddWithValue("", numero);
                this.miConexion.MiConexion.Open();
                var existe = Convert.ToBoolean(this.miComando.ExecuteScalar());
                this.miConexion.MiConexion.Close();
                this.miComando.Dispose();
                return existe;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al verificar la factura de compra.\n" + ex.Message);
            }
            finally { this.miConexion.MiConexion.Close(); }
        }

        /// <summary>
        /// Ingresa un registro de ProductoFacturaProveedor estableciendo la relacion necesaria.
        /// </summary>
        /// <param name="productos">Registro de ProductoFacturaProveedor a ingresar.</param>
        public void IngresarProductoFacturaProveedor(ProductoFacturaProveedor productos, bool esFactura)
        {
            try
            {
                if (esFactura)
                {
                    CargarComando(InsertarProductoFactura);
                }
                else
                {
                    CargarComando("insertar_producto_remision_proveedor");
                }
                miComando.Parameters.AddWithValue("factura", productos.IdFactura);
                miComando.Parameters.AddWithValue("producto", productos.Producto.CodigoInternoProducto);
                miComando.Parameters.AddWithValue("medida", productos.Inventario.IdMedida);
                miComando.Parameters.AddWithValue("color", productos.Inventario.IdColor);
                miComando.Parameters.AddWithValue("lote", productos.Lote.Id);
                miComando.Parameters.AddWithValue("cantidad", productos.Cantidad);
                miComando.Parameters.AddWithValue("valor", productos.Producto.ValorVentaProducto);
                miComando.Parameters.AddWithValue("iva", productos.Producto.ValorIva);
                miComando.Parameters.AddWithValue("descuento", productos.Producto.Descuento);
                if (esFactura)
                {
                    miComando.Parameters.AddWithValue("impoconsumo", productos.ImpoConsumo);
                }
                miConexion.MiConexion.Open();
                miComando.ExecuteNonQuery();
                miConexion.MiConexion.Close();
                miComando.Dispose();
            }
            catch (Exception ex)
            {
                throw new Exception(ErrorInsertar + ex.Message);
            }
            finally { miConexion.MiConexion.Close(); }
        }

        public DataTable ProductosDeFactura(Inventario inventario)
        {
            var tabla = new DataTable();
            try
            {
                CargarAdapter("registros_compra_producto");
                miAdapter.SelectCommand.Parameters.AddWithValue("codigo", inventario.CodigoProducto);
                miAdapter.SelectCommand.Parameters.AddWithValue("medida", inventario.IdMedida);
                miAdapter.SelectCommand.Parameters.AddWithValue("color", inventario.IdColor);
                miAdapter.SelectCommand.Parameters.AddWithValue("limite", Convert.ToInt32(inventario.Cantidad));
                miAdapter.Fill(tabla);
                return tabla;
            }
            catch (Exception ex)
            {
                throw new Exception
                    ("Ocurrió un error al consultar los registros de compra del producto.\n" + ex.Message);
            }
        }

        /// <summary>
        /// Edita los datos de un registro de ProductoFacturaProveedor en base de datos.
        /// </summary>
        /// <param name="producto">Registro de ProductoFacturaProveedor a editar.</param>
        public void EditarProductoFacturaProveedor(ProductoFacturaProveedor producto)
        {
            try
            {
                CargarComando(EditarProductoFactura);
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
            catch (Exception ex)
            {
                throw new Exception(ErrorEditar + ex.Message);
            }
            finally { miConexion.MiConexion.Close(); }
        }

        public void EditarProductoFacturaProveedor(ProductoFacturaProveedor producto, bool actInventario)
        {
            try
            {
                var daoProducto = new DaoProducto();
                CargarComando(EditarProductoFactura);
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
                //if (producto.Producto.IdTipoInventario.Equals(this.IdTipoInventarioInsumo))
                
                if (actInventario)
                {
                    if (!producto.Producto.IdTipoInventario.Equals(this.IdTipoInventarioInsumo))
                    {
                        miDaoInventario.ActualizarInventario(new Inventario
                        {
                            CodigoProducto = producto.Producto.CodigoInternoProducto,
                            IdMedida = producto.Inventario.IdMedida,
                            IdColor = producto.Inventario.IdColor,
                            Cantidad = producto.Inventario.Cantidad // Cantidad Actual
                        }, true);
                        miDaoInventario.ActualizarInventario(new Inventario
                        {
                            CodigoProducto = producto.Producto.CodigoInternoProducto,
                            IdMedida = producto.Inventario.IdMedida,
                            IdColor = producto.Inventario.IdColor,
                            Cantidad = producto.Cantidad           // Cantidad Editada
                        }, false);
                    }
                    else
                    {
                        var p = daoProducto.ProductoProcesoPresentacion(producto.Producto.CodigoInternoProducto);
                        double cantDiferencia = (producto.Inventario.Cantidad - producto.Cantidad) * p.UnidadVentaProducto;
                        p.Cantidad = p.Cantidad - cantDiferencia;
                        miDaoInventario.ActualizarCantidad(p.CodigoInternoProducto, p.Cantidad);

                        /*if (cantDiferencia < 0) // es negativo; se suma
                        {

                        }*/
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ErrorEditar + ex.Message);
            }
            finally { miConexion.MiConexion.Close(); }
        }

        /// <summary>
        /// Elimina un registro de Producto de Factura Proveedor.
        /// </summary>
        /// <param name="id">Id del registro del Producto a eliminar.</param>
        public void EliminarProductoFacturaProveedor(int id)
        {
            try
            {
                CargarComando(EliminarProductoFactura);
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
            miAdapter = new NpgsqlDataAdapter(cmd, miConexion.MiConexion);
            miAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
        }
    }
}