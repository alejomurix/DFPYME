using System;
using System.Linq;
using System.Data;
using System.Collections;
using System.Collections.Generic;
using Npgsql;
using NpgsqlTypes;
using DTO.Clases;

namespace DataAccessLayer.Clases
{
    /// <summary>
    /// Representa una clase de transferencia a Base de Datos PostgreSQL de un Producto.
    /// </summary>
    public class DaoProducto
    {
        #region Atributos

        #region Tranzacion a Base de Datos

        /// <summary>
        /// Objeto conexion a base de datos PostgreSQL.
        /// </summary>
        private Conexion conexion;

        /// <summary>
        /// Objeto que ejecuta las sentencias o procedimientos en la base de datos
        /// </summary>
        private NpgsqlCommand comando;

        /// <summary>
        /// Objeto que representa un adaptador de comandos SQl.
        /// </summary>
        private NpgsqlDataAdapter miAdapter;

        /// <summary>
        /// Objeto de Tranzacion a base de datos de Descuento.
        /// </summary>
        private DaoDescuento midaodescuento;

        /// <summary>
        /// Objeto de Tranzacion a base de datos de Recargo.
        /// </summary>
        private DaoRecargo midaorecargo;

        /// <summary>
        /// Objeto de Tranzacion a base de datos de ValorUnidadMedida
        /// </summary>
        private DaoValorUnidadMedida miDaoValor;

        /// <summary>
        /// Objeto de tranzacion a base de datos de MedidaColor.
        /// </summary>
        private DaoInventario miDaoInventario;

        #endregion

        #region Procedimientos o Funciones Almacenadas.

        /// <summary>
        /// Representa la funcion en PostgreSQL recuperar_consecutivo.
        /// </summary>
        private string sqlRecuperarConsecutivo = "recuperar_consecutivo";

        /// <summary>
        /// Representa la Funcion en PostgreSQL existe_codigo_producto.
        /// </summary>
        private string sqlComprobarCodigo = "existe_codigo_producto";

        /// <summary>
        /// Representa la Funcion en PostgreSQL existe_barra_producto.
        /// </summary>
        private string sqlComprobarBarras = "existe_barra_producto";

        /// <summary>
        /// Representa la funcion insertar_producto.
        /// </summary>
        private string SqlInsert = "insertar_producto";

        /// <summary>
        /// Representa la función ultimo_valor_producto.
        /// </summary>
        private string ultimoValor = "ultimo_valor_producto";

        /// <summary>
        /// Representa la función ultimos_valores_producto.
        /// </summary>
        private string UltimosValores = "ultimos_valores_producto";

        #endregion

        #endregion

        #region constantes

        /// <summary>
        /// Representa el texto CodigoProducto.
        /// </summary>
        private string CodigoProducto = "CodigoProducto";

        /// <summary>
        /// Representa el texto BarraProducto.
        /// </summary>
        private string BarraProducto = "BarraProducto";

        /// <summary>
        /// Representa el mensaje: Ocurrio un error al cargar la consulta.
        /// </summary>
        private string ErrorConsulta
        {
            set { ErrorConsulta = "Ocurrio un error al cargar la consulta.\n"; }
            get { return ErrorConsulta; }
        }

        /// <summary>
        /// Representa el mensaje: Ocurrio un error al cargar el total de registros.
        /// </summary>
        private string ErrorCount = "Ocurrio un error al cargar el total de registros.\n";

        /// <summary>
        /// Representa el texto: Ocurrió un error al cargar el precio del Producto.
        /// </summary>
        private string ErrorUltimoPrecio = "Ocurrió un error al cargar el precio del Producto.\n";

        #endregion

        private bool RedondearPrecio2;

        private bool aprox_precio;

        /// <summary>
        /// Inicializa una nueva instancia de la clase DaoProducto.
        /// </summary>
        public DaoProducto()
        {
            this.conexion = new Conexion();
            RedondearPrecio2 = Convert.ToBoolean(Utilities.AppConfiguracion.ValorSeccion("redondeo_precio_dos"));
            aprox_precio = Convert.ToBoolean(Utilities.AppConfiguracion.ValorSeccion("tipo_aprox_precio"));
        }

        /*public DaoProducto(string ipServer)
        {
            this.conexion = new Conexion(ipServer, "");
        }*/

        #region Metodos

        /// <summary>
        /// Obtiene un número disponible del Codigo Interno para registro del Producto
        /// </summary>
        /// <returns></returns>
        public int ObtenerCodigoInterno()
        {
            bool match = true;
            int codigo = 0;
            try
            {
                while (match)
                {
                    codigo = CapturarCodigoInterno();
                    if (ComprobarCodigoInterno(codigo))
                    {
                        ActualizarProductoInterno(codigo);
                        match = true;
                    }
                    else
                        match = false;
                }
                return codigo;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrio un error al generara el codigo para el producto. " + ex.Message);
            }
        }

        /// <summary>
        /// Obtiene un número disponible del Codigo de Barras para registro del Producto
        /// </summary>
        /// <returns></returns>
        public string ObtenerCodigoBarras()
        {
            bool match = true;
            string codigo = "";
            try
            {
                while (match)
                {
                    codigo = CapturarCodigoBarras();
                    if (ComprobarCodigoBarras(codigo))
                    {
                        ActualizarProductoBarras(codigo);
                        match = true;
                    }
                    else
                        match = false;
                }
                return codigo;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Obtiene el codigo interno consecutivo del registro del Producto.
        /// </summary>
        /// <returns></returns>
        private int CapturarCodigoInterno()
        {
            try
            {
                CargarComandoStoredProcedure(sqlRecuperarConsecutivo);
                comando.Parameters.AddWithValue("concepto", CodigoProducto);
                conexion.MiConexion.Open();
                var codigo = Convert.ToInt32(comando.ExecuteScalar());
                conexion.MiConexion.Close();
                comando.Dispose();
                return codigo;
            }
            catch (Exception ex)
            {
                throw new Exception("No se puede generar codigo interno" + ex.Message);
            }
            finally { conexion.MiConexion.Close(); }
        }

        /// <summary>
        /// Comprueba si el codigo existe en un registro de Producto.
        /// </summary>
        /// <param name="codigo">Codigo a comprbar.</param>
        /// <returns></returns>
        public bool ComprobarCodigoInterno(object codigo)
        {
            try
            {
                CargarComandoStoredProcedure(sqlComprobarCodigo);
                comando.Parameters.AddWithValue("codigo", Convert.ToString(codigo));
                conexion.MiConexion.Open();
                var resultado = Convert.ToBoolean(comando.ExecuteScalar());
                conexion.MiConexion.Close();
                comando.Dispose();
                return resultado;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                conexion.MiConexion.Close();
            }
        }

        public bool ExisteCodigo(string codigo)
        {
            try
            {
                this.CargarComandoStoredProcedure("existe_codigo");
                this.comando.Parameters.AddWithValue("", codigo);
                this.conexion.MiConexion.Open();
                var existe = Convert.ToBoolean(this.comando.ExecuteScalar());
                this.conexion.MiConexion.Close();
                this.comando.Dispose();
                return existe;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al verificar el codigo.\n" + ex.Message);
            }
            finally { this.conexion.MiConexion.Close(); }
        }

        /// <summary>
        /// Actualiza el registro consecutivo del codigo interno de producto de 1 en 1.
        /// </summary>
        /// <param name="productocodinterno">Codigo a ingresar</param>
        public void ActualizarProductoInterno(int productocodinterno)
        {
            var numero = productocodinterno + 1;
            try
            {
                CargarComandoStoredProcedure("actualizar_consecutivo");
                comando.Parameters.AddWithValue("concepto", CodigoProducto);
                comando.Parameters.AddWithValue("numero", numero.ToString());
                conexion.MiConexion.Open();
                comando.ExecuteNonQuery();
                conexion.MiConexion.Close();
                comando.Dispose();
            }
            catch (Exception ex)
            {
                throw new Exception("No se puede actualizar codigo interno. " + ex.Message);
            }
            finally { conexion.MiConexion.Close(); }
        }

        /// <summary>
        /// Obtiene el codigo de barras consecutivo del registro del Producto.
        /// </summary>
        /// <returns></returns>
        private string CapturarCodigoBarras()
        {
            try
            {
                CargarComandoStoredProcedure("recuperar_consecutivo");
                comando.Parameters.AddWithValue("concepto", BarraProducto);
                conexion.MiConexion.Open();
                var numero = Convert.ToString(comando.ExecuteScalar());
                conexion.MiConexion.Close();
                comando.Dispose();
                return numero;
            }
            catch (Exception ex)
            {
                throw new Exception("No se puede generar codigo de barras. " + ex.Message);
            }
            finally { conexion.MiConexion.Close(); }
        }

        /// <summary>
        /// Comprueba si el codigo existe en un registro de Producto.
        /// </summary>
        /// <param name="codigo">Codigo a comprbar.</param>
        /// <returns></returns>
        public bool ComprobarCodigoBarras(string codigo)
        {
            try
            {
                CargarComandoStoredProcedure(sqlComprobarBarras);
                comando.Parameters.AddWithValue("codigo", codigo);
                conexion.MiConexion.Open();
                var resultado = Convert.ToBoolean(comando.ExecuteScalar());
                conexion.MiConexion.Close();
                comando.Dispose();
                return resultado;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                conexion.MiConexion.Close();
            }
        }

        /// <summary>
        /// Actualiza el registro consecutivo del codigo de barras del producto de 1 en 1.
        /// </summary>
        /// <param name="productobarras">Codigo a ingresar</param>
        public void ActualizarProductoBarras(string productobarras)
        {
            var numero = Convert.ToInt64(productobarras) + 1;
            try
            {
                CargarComandoStoredProcedure("actualizar_consecutivo");
                comando.Parameters.AddWithValue("concepto", BarraProducto);
                comando.Parameters.AddWithValue("numero", numero.ToString());
                conexion.MiConexion.Open();
                comando.ExecuteNonQuery();
                conexion.MiConexion.Close();
                comando.Dispose();
            }
            catch (Exception ex)
            {
                throw new Exception("No se puede actualizar codigo barras. " + ex.Message);
            }
            finally { conexion.MiConexion.Close(); }
        }

        public DataTable Ico()
        {
            try
            {
                var tICO = new DataTable();
                string sql = "select * from ico_consumo order by id_ico;";
                CargarAdapter(sql);
                miAdapter.Fill(tICO);
                return tICO;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al cargar los valores de ICO." + ex.Message);
            }
        }

        /// <summary>
        /// Inserta un registro de Producto en la base de datos.
        /// </summary>
        /// <param name="producto">Producto a ingresar</param>
        public void InsertarProducto(Producto producto)
        {
            midaodescuento = new DaoDescuento();
            midaorecargo = new DaoRecargo();
            miDaoValor = new DaoValorUnidadMedida();
            miDaoInventario = new DaoInventario();
            try
            {
                CargarComandoStoredProcedure(SqlInsert);
                comando.Parameters.AddWithValue("CodigoInterno", producto.CodigoInternoProducto);
                comando.Parameters.AddWithValue("CodigoBarras", producto.CodigoBarrasProducto);
                comando.Parameters.AddWithValue("referencia", producto.ReferenciaProducto);
                comando.Parameters.AddWithValue("nombre", producto.NombreProducto);
                comando.Parameters.AddWithValue("descripcion", producto.DescripcionProducto);
                comando.Parameters.AddWithValue("categoria", producto.CodigoCategoria);
                comando.Parameters.AddWithValue("marca", producto.IdMarca);
                comando.Parameters.AddWithValue("utilidad", producto.UtilidadPorcentualProducto);
                comando.Parameters.AddWithValue("valorVenta", producto.ValorVentaProducto);
                comando.Parameters.AddWithValue("aplicaPrecio", producto.AplicaPrecioPorcentaje);
                comando.Parameters.AddWithValue("iva", producto.IdIva);
                comando.Parameters.AddWithValue("unidadVenta", producto.UnidadVentaProducto);
                comando.Parameters.AddWithValue("minima", producto.CantidadMinimaProducto);
                comando.Parameters.AddWithValue("maxima", producto.CantidadMaximaProducto);
                comando.Parameters.AddWithValue("estado", producto.EstadoProducto);
                comando.Parameters.AddWithValue("talla", producto.AplicaTalla);
                comando.Parameters.AddWithValue("color", producto.AplicaColor);
                comando.Parameters.AddWithValue("cantdecimal", producto.CantidadDecimal);
                comando.Parameters.AddWithValue("costo", producto.ValorCosto);
                comando.Parameters.AddWithValue("destoMayor", producto.DescuentoMayor);
                comando.Parameters.AddWithValue("destoDistribuidor", producto.DescuentoDistribuidor);
                comando.Parameters.AddWithValue("idivatemp", producto.IdIvaTemp);
                comando.Parameters.AddWithValue("", producto.Utilidad2);
                comando.Parameters.AddWithValue("", producto.Utilidad3);
                comando.Parameters.AddWithValue("", producto.Codigo_2);
                comando.Parameters.AddWithValue("", producto.Codigo_3);
                comando.Parameters.AddWithValue("", producto.Codigo_4);
                comando.Parameters.AddWithValue("", producto.Codigo_5);
                comando.Parameters.AddWithValue("", producto.Codigo_6);
                comando.Parameters.AddWithValue("", producto.Codigo_7);
                comando.Parameters.AddWithValue("", producto.DescuentoPrecio4);
                comando.Parameters.AddWithValue("", producto.Impoconsumo);
                comando.Parameters.AddWithValue("", producto.IdTipoInventario);

                comando.Parameters.AddWithValue("", producto.IdIco);
                comando.Parameters.AddWithValue("", producto.AplicaIco);
                comando.Parameters.AddWithValue("", producto.Imprime);
                comando.Parameters.AddWithValue("", producto.AplicaDescto);
                conexion.MiConexion.Open();
                comando.ExecuteNonQuery();
                conexion.MiConexion.Close();
                comando.Dispose();

                string numero = CapturarCodigoBarras();
                if (numero == producto.CodigoBarrasProducto)
                {
                    ActualizarProductoBarras(numero);
                }
                int numero2 = CapturarCodigoInterno();
                if (numero2 == Convert.ToInt32(producto.CodigoInternoProducto))
                {
                    ActualizarProductoInterno(numero2);
                }

                /*foreach (Descuento d in producto.Descuentos)
                {
                    d.CodigoInternoProducto = producto.CodigoInternoProducto;
                    midaodescuento.InsertarDescuento(d);
                }

                foreach (Recargo r in producto.Recargos)
                {
                    r.CodigoInternoProducto = producto.CodigoInternoProducto;
                    midaorecargo.InsertarRecargo(r);
                }*/

                foreach (ValorUnidadMedida medida in producto.Medidas)
                {
                    medida.CodigoInternoProducto = producto.CodigoInternoProducto;
                    miDaoValor.InsertarMedidaProducto(medida);
                }

                foreach (Inventario inventario in producto.Inventarios)
                {
                    inventario.CodigoProducto = producto.CodigoInternoProducto;
                    miDaoInventario.InsertarInventario(inventario);
                }

                if (producto.IdTipoInventario.Equals(2) && !String.IsNullOrEmpty(producto.CodProductoProceso))
                {
                    InsertarProductoProceso(producto.CodigoInternoProducto, producto.CodProductoProceso);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrio un Error al insertar Producto.\n" + ex.Message);
            }
            finally
            {
                conexion.MiConexion.Close();
            }
        }

        /// <summary>
        /// Obtiene el valor que indica si el Producto aplica talla o no.
        /// </summary>
        /// <param name="codigo">Codigo del Producto a consultar.</param>
        /// <returns></returns>
        public bool ProductoConTalla(string codigo)
        {
            try
            {
                CargarComandoStoredProcedure("producto_con_talla");
                comando.Parameters.AddWithValue("codigo", codigo);
                conexion.MiConexion.Open();
                var resultado = Convert.ToBoolean(comando.ExecuteScalar());
                conexion.MiConexion.Close();
                comando.Dispose();
                return resultado;
            }
            catch (Exception ex)
            {
                throw new Exception(ErrorConsulta + ex.Message);
            }
            finally { conexion.MiConexion.Close(); }
            //producto_con_talla('525')
        }

        public void InsertarProductoProceso(string codProducto, string codProductoProceso)
        {
            try
            {
                CargarComandoStoredProcedure("insertar_producto_proceso");
                comando.Parameters.AddWithValue("", codProducto);
                comando.Parameters.AddWithValue("", codProductoProceso);
                conexion.MiConexion.Open();
                comando.ExecuteNonQuery();
                conexion.MiConexion.Close();
                comando.Dispose();
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al ingresar el producto insumo relacionado.\n" + ex.Message);
            }
            finally { conexion.MiConexion.Close(); }
        }

        public DataTable Productos()
        {
            try
            {
                var tabla = new DataTable();
                tabla.Columns.Add(new DataColumn("Id", typeof(int)));
                tabla.Columns.Add(new DataColumn("Codigo", typeof(string)));
                tabla.Columns.Add(new DataColumn("Producto", typeof(string)));
                tabla.Columns.Add(new DataColumn("Precio", typeof(int)));
                //tabla.Columns.Add(new DataColumn("Cantidad", typeof(double)));
                tabla.Columns.Add(new DataColumn("Kilogramo", typeof(double)));
                tabla.Columns.Add(new DataColumn("Arroba", typeof(double)));
                tabla.Columns.Add(new DataColumn("Valor", typeof(int)));

                var tabla_ = new DataTable();
                CargarAdapterStoredProcedure("listar_productos");
                miAdapter.Fill(tabla_);

                var id = 1;
                foreach (DataRow row in tabla_.Rows)
                {
                    var tRow = tabla.NewRow();
                    tRow["Id"] = id;
                    tRow["Codigo"] = row["CodigoInternoProducto"];
                    tRow["Producto"] = row["NombreProducto"];
                    tRow["Precio"] = row["precio_costo"];
                    //tRow["Cantidad"] = 0;
                    tRow["Kilogramo"] = 0;
                    tRow["Arroba"] = 0;

                    tRow["Valor"] = 0;
                    tabla.Rows.Add(tRow);
                    id++;
                }

                return tabla;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al listar los productos.\n" + ex.Message);
            }
        }

        /// <summary>
        /// Obtiene el listado de los productos.
        /// </summary>
        /// <param name="registroBase">Registro base para la consulta.</param>
        /// <param name="registrosMaximos">Número de registros a recuperar.</param>
        /// <returns></returns>
        public DataTable ListarProductos(int registroBase, int registrosMaximos)
        {
            var dataSet = new DataSet();
            try
            {
                CargarAdapterStoredProcedure("listar_productos");
                miAdapter.Fill(dataSet, registroBase, registrosMaximos, "producto");
                return dataSet.Tables[0];
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrio un error al cargar la lista de los productos.\n" + ex.Message);
            }
        }

        /// <summary>
        /// Obtiene el total de registros de los productos.
        /// </summary>
        /// <returns></returns>
        public long RowsListarProductos()
        {
            try
            {
                CargarComandoStoredProcedure("count_listar_productos");
                conexion.MiConexion.Open();
                var rows = Convert.ToInt64(comando.ExecuteScalar());
                conexion.MiConexion.Close();
                comando.Dispose();
                return rows;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrio un error al cargar el total de registros de productos.\n" + ex.Message);
            }
            finally { conexion.MiConexion.Close(); }
        }

        /// <summary>
        /// Obtiene el listado de la consulta un una coleccion.
        /// </summary>
        /// <param name="codigo">Codigo Interno del Producto a buscar</param>
        /// <returns></returns>
        public DataTable ConsultaPorCodigo(string codigo)
        {
            var tabla = new DataTable();
            try
            {
                //CargarAdapterStoredProcedure("listar_productos_codigo");
                CargarAdapterStoredProcedure("listar_productos_codigo_codigos"); // 18/07/2017 EDICIÓN, CODIGOS (6) EN PRODUCTO
                miAdapter.SelectCommand.Parameters.AddWithValue("codigo", codigo);
                miAdapter.Fill(tabla);
                return tabla;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrio un error al cargar la consulta.\n" + ex.Message);
            }
        }

        /// <summary>
        /// Obtiene el listado de la consulta un una coleccion. 
        /// </summary>
        /// <param name="nombre">Nombre del Producto a consultar.</param>
        /// <returns>listaproductosnombre</returns>
        public DataTable ConsultaPorNombre(string nombre)
        {
            var tabla = new DataTable();
            try
            {
                CargarAdapterStoredProcedure("consulta_productos_nombre");
                miAdapter.SelectCommand.Parameters.AddWithValue("nombre", nombre);
                miAdapter.Fill(tabla);
                return tabla;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrio un error al cargar la consulta. " + ex.Message);
            }
        }

        /// <summary>
        /// Obtiene el listado de la consulta un una coleccion en base a parte del nombre.
        /// </summary>
        /// <param name="nombre">Nombre o parte de este a consultar.</param>
        /// <param name="registroBase">Registro base para la consulta.</param>
        /// <param name="registrosMaximos">Número de registros a recuperar.</param>
        /// <returns></returns>
        public DataTable FiltroNombre
            (string nombre, int registroBase, int registrosMaximos)
        {
            var dataSet = new DataSet();
            try
            {
                CargarAdapterStoredProcedure("filtro_productos_nombre");
                miAdapter.SelectCommand.Parameters.AddWithValue("nombre", nombre.ToUpper());
                miAdapter.Fill(dataSet, registroBase, registrosMaximos, "producto");
                return dataSet.Tables[0];
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrio un error al cargar la consulta.\n" + ex.Message);
            }
        }

        /// <summary>
        /// Obtiene el total de registros de una consulta por nombre de producto.
        /// </summary>
        /// <param name="nombre">Nombre del producto o parte de este.</param>
        /// <returns></returns>
        public long RowsFiltroNombre(string nombre)
        {
            try
            {
                CargarComandoStoredProcedure("count_filtro_productos_nombre");
                comando.Parameters.AddWithValue("nombre", nombre.ToUpper());
                conexion.MiConexion.Open();
                var rows = Convert.ToInt64(comando.ExecuteScalar());
                conexion.MiConexion.Close();
                comando.Dispose();
                return rows;
            }
            catch (Exception ex)
            {
                throw new Exception
                    ("Ocurrio un error al cargar el total de registros de productos.\n" + ex.Message);
            }
            finally { conexion.MiConexion.Close(); }
        }

        /// <summary>
        /// Obtiene el listado de productos segun el codigo de la catagoria.
        /// </summary>
        /// <param name="codigo">Codigo de la categoria.</param>
        /// <param name="registroBase">Registro base para la consulta.</param>
        /// <param name="registrosMaximos">Número de registros a recuperar.</param>
        /// <returns></returns>
        public DataTable ConsultaPorCodigoCategoria
            (string codigo, int registroBase, int registrosMaximos)
        {
            var dataSet = new DataSet();
            try
            {
                CargarAdapterStoredProcedure("listar_productos_codigo_categoria");
                miAdapter.SelectCommand.Parameters.AddWithValue("codigo", codigo);
                miAdapter.Fill(dataSet, registroBase, registrosMaximos, "producto");
                return dataSet.Tables[0];
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrio un error al cargar la consulta.\n" + ex.Message);
            }
        }

        /// <summary>
        /// Obtiene el total de registros de una consulta de Producto por codigo de categoria.
        /// </summary>
        /// <param name="codigo">Codigo de la categoria.</param>
        /// <returns></returns>
        public long RowsConsultaPorCodigoCategoria(string codigo)
        {
            try
            {
                CargarComandoStoredProcedure
                    ("count_listar_productos_codigo_categoria");
                comando.Parameters.AddWithValue("codigo", codigo);
                conexion.MiConexion.Open();
                var rows = Convert.ToInt64(comando.ExecuteScalar());
                conexion.MiConexion.Close();
                comando.Dispose();
                return rows;
            }
            catch (Exception ex)
            {
                throw new Exception
                    ("Ocurrio un error al cargar el total de registros de productos.\n" + ex.Message);
            }
            finally { conexion.MiConexion.Close(); }
        }

        /// <summary>
        /// Obtiene el listado de productos segun el nombre de la categoria.
        /// </summary>
        /// <param name="nombre">Nombre de la categoria o parte de este.</param>
        /// <param name="registroBase">Registro base para la consulta.</param>
        /// <param name="registrosMaximos">Número de registros a recuperar.</param>
        /// <param name="filtro">Indica si es una consulta de filtrado o no.</param>
        /// <returns></returns>
        public DataTable ConsultaPorNombreCategoria
            (string nombre, int registroBase, int registrosMaximos, bool filtro)
        {
            var dataSet = new DataSet();
            try
            {
                if (filtro)
                    CargarAdapterStoredProcedure("filtro_productos_categoria");
                else
                    CargarAdapterStoredProcedure("consulta_productos_categoria");
                miAdapter.SelectCommand.Parameters.AddWithValue("codigo", nombre);
                miAdapter.Fill(dataSet, registroBase, registrosMaximos, "producto");
                return dataSet.Tables[0];
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrio un error al cargar la consulta.\n" + ex.Message);
            }
        }

        /// <summary>
        /// Obtiene el total de registros de una consulta de Producto por nombre de categoria.
        /// </summary>
        /// <param name="nombre">Nombre de la categoria o parte de este.</param>
        /// <param name="filtro">Indica si es una consulta de filtrado o no.</param>
        /// <returns></returns>
        public long RowsConsultaPorNombreCategoria(string nombre, bool filtro)
        {
            try
            {
                if (filtro)
                    CargarComandoStoredProcedure("count_filtro_productos_categoria");
                else
                    CargarComandoStoredProcedure("count_consulta_productos_categoria");
                comando.Parameters.AddWithValue("nombre", nombre);
                conexion.MiConexion.Open();
                var rows = Convert.ToInt64(comando.ExecuteScalar());
                conexion.MiConexion.Close();
                comando.Dispose();
                return rows;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrio un error al cargar el total de registros de productos.\n" + ex.Message);
            }
            finally { conexion.MiConexion.Close(); }
        }

        /// <summary>
        /// Obtiene el listado de productos segun la referencia.
        /// </summary>
        /// <param name="referencia">Referencia o parte de esta a consultar.</param>
        /// <param name="registroBase">Registro base para la consulta.</param>
        /// <param name="registrosMaximos">Número de registros a recuperar.</param>
        /// <param name="color">Indica si la consulta incluye color o no.</param>
        /// <returns></returns>
        public DataTable ConsultaProductoPorReferencia
            (string referencia, int registroBase, int registrosMaximos, bool color)
        {
            var dataSet = new DataSet();
            try
            {
                if (color)
                    CargarAdapterStoredProcedure("productos_combinar_referencia");
                else
                    CargarAdapterStoredProcedure("productos_combinar_referencia_nocolor");
                miAdapter.SelectCommand.Parameters.AddWithValue("referencia", referencia);
                miAdapter.Fill(dataSet, registroBase, registrosMaximos, "producto");
                return dataSet.Tables[0];
            }
            catch (Exception ex)
            {
                throw new Exception(ErrorConsulta + ex.Message);
            }
        }

        /// <summary>
        /// Obtiene el total de registros de una consulta de Producto por Referencia.
        /// </summary>
        /// <param name="referencia">Referencia o parte de esta a consultar.</param>
        /// <param name="color">Indica si la consulta incluye color o no.</param>
        /// <returns></returns>
        public long RowsConsultaProductoPorReferencia(string referencia, bool color)
        {
            try
            {
                if (color)
                {
                    CargarComandoStoredProcedure("count_productos_combinar_referencia");
                }
                else
                {
                    CargarComandoStoredProcedure
                        ("count_productos_combinar_referencia_nocolor");
                }
                comando.Parameters.AddWithValue("referencia", referencia);
                conexion.MiConexion.Open();
                var rows = Convert.ToInt64(comando.ExecuteScalar());
                conexion.MiConexion.Close();
                comando.Dispose();
                return rows;
            }
            catch (Exception ex)
            {
                throw new Exception(ErrorCount + ex.Message);
            }
        }

        /// <summary>
        /// Obtiene el listado de productos segun el codigo o el nombre y la referencia.
        /// </summary>
        /// <param name="codigo">Codigo del producto a consultar.</param>
        /// <param name="nombre">Nombre o parte de este del producto a consultar.</param>
        /// <param name="referencia">Referencia o parte de esta a consultar.</param>
        /// <param name="code">Indica si se consulta por Codigo del producto o no.</param>
        /// <param name="color">Indica si la consulta incluye color o no.</param>
        /// <param name="registroBase">Registro base para la consulta.</param>
        /// <param name="registrosMaximos">Número de registros a recuperar.</param>
        /// <returns></returns>
        public DataTable ConsultaProductoConReferencia
            (string codigo, string nombre, string referencia, bool code, bool color,
             int registroBase, int registrosMaximos)
        {
            var dataSet = new DataSet();
            try
            {
                if (code)
                {
                    if (color)
                    {
                        CargarAdapterStoredProcedure("producto_con_referencia_ycolor");
                        miAdapter.SelectCommand.Parameters.AddWithValue("codigo", codigo);
                        miAdapter.SelectCommand.Parameters.AddWithValue("referencia", referencia);
                    }
                    else
                    {
                        CargarAdapterStoredProcedure("producto_con_referencia");
                        miAdapter.SelectCommand.Parameters.AddWithValue("codigo", codigo);
                        miAdapter.SelectCommand.Parameters.AddWithValue("referencia", referencia);
                    }
                }
                else
                {
                    if (color)
                    {
                        CargarAdapterStoredProcedure("producto_name_con_referencia_ycolor");
                        miAdapter.SelectCommand.Parameters.AddWithValue("nombre", nombre);
                        miAdapter.SelectCommand.Parameters.AddWithValue("referencia", referencia);
                    }
                    else
                    {
                        CargarAdapterStoredProcedure("producto_name_con_referencia");
                        miAdapter.SelectCommand.Parameters.AddWithValue("nombre", nombre);
                        miAdapter.SelectCommand.Parameters.AddWithValue("referencia", referencia);
                    }
                }
                miAdapter.Fill(dataSet, registroBase, registrosMaximos, "producto");
                return dataSet.Tables[0];
            }
            catch (Exception ex)
            {
                throw new Exception(ErrorConsulta + ex.Message);
            }
        }

        /// <summary>
        /// Obtiene el total de registros de una consulta segun el codigo o el nombre y la referencia.
        /// </summary>
        /// <param name="codigo">Codigo del producto a consultar.</param>
        /// <param name="nombre">Nombre o parte de este del producto a consultar.</param>
        /// <param name="referencia">Referencia o parte de esta a consultar.</param>
        /// <param name="code">Indica si se consulta por Codigo del producto o no.</param>
        /// <param name="color">Indica si la consulta incluye color o no.</param>
        /// <returns></returns>
        public long RowsConsultaProductoConReferencia
            (string codigo, string nombre, string referencia, bool code, bool color)
        {
            try
            {
                if (code)
                {
                    if (color)
                    {
                        CargarComandoStoredProcedure("count_producto_con_referencia_ycolor");
                        comando.Parameters.AddWithValue("codigo", codigo);
                        comando.Parameters.AddWithValue("referencia", referencia);
                    }
                    else
                    {
                        CargarComandoStoredProcedure("count_producto_con_referencia");
                        comando.Parameters.AddWithValue("codigo", codigo);
                        comando.Parameters.AddWithValue("referencia", referencia);
                    }
                }
                else
                {
                    if (color)
                    {
                        CargarComandoStoredProcedure("count_producto_name_con_referencia_ycolor");
                        comando.Parameters.AddWithValue("nombre", nombre);
                        comando.Parameters.AddWithValue("referencia", referencia);
                    }
                    else
                    {
                        CargarComandoStoredProcedure("count_producto_name_con_referencia");
                        comando.Parameters.AddWithValue("nombre", nombre);
                        comando.Parameters.AddWithValue("referencia", referencia);
                    }
                }
                conexion.MiConexion.Open();
                var rows = Convert.ToInt64(comando.ExecuteScalar());
                conexion.MiConexion.Close();
                comando.Dispose();
                return rows;
            }
            catch (Exception ex)
            {
                throw new Exception(ErrorCount + ex.Message);
            }
            finally { conexion.MiConexion.Close(); }
        }

        /// <summary>
        /// Obtiene el listado de productos segun la marca.
        /// </summary>
        /// <param name="codigo">Codigo del producto a consultar.</param>
        /// <param name="nombre">Nombre o parte de este del producto a consultar.</param>
        /// <param name="marca">Marca o parte de esta a consultar.</param>
        /// <param name="talla">Talla o parte de esta a consultar.</param>
        /// <param name="size">Indica si la consulta incluye talla o no.</param>
        /// <param name="product">Indica si la consulta incluye Producto o no.</param>
        /// <param name="code">Indica si se consulta por Codigo del producto o no.</param>
        /// <param name="color">Indica si la consulta incluye color o no.</param>
        /// <param name="registroBase">Registro base para la consulta.</param>
        /// <param name="registrosMaximos">Número de registros a recuperar.</param>
        /// <returns></returns>
        public DataTable ConsultaProductoPorMarca
            (string codigo, string nombre, string marca, string talla, bool size,
             bool product, bool code, bool color, int registroBase, int registrosMaximos)
        {
            var dataSet = new DataSet();
            try
            {
                if (!product)//Marca sola.
                {
                    if (!size && !color)//Consulta marca sin talla y sin color.
                    {
                        CargarAdapterStoredProcedure("productos_marca_nocolor");
                        miAdapter.SelectCommand.Parameters.AddWithValue("marca", marca);
                    }
                    else
                    {
                        if (size && !color)//Consulta marca con talla y sin color
                        {
                            CargarAdapterStoredProcedure("producto_marca_medida");
                            miAdapter.SelectCommand.Parameters.AddWithValue("marca", marca);
                            miAdapter.SelectCommand.Parameters.AddWithValue("talla", talla);
                        }
                        else
                        {
                            if (size && color)//Consulta marca con talla y con color.
                            {
                                CargarAdapterStoredProcedure("producto_marca_medida_ycolor");
                                miAdapter.SelectCommand.Parameters.AddWithValue("marca", marca);
                                miAdapter.SelectCommand.Parameters.AddWithValue("talla", talla);
                            }
                            else//Consulta marca sin talla y con color
                            {
                                CargarAdapterStoredProcedure("productos_marca_ycolor");
                                miAdapter.SelectCommand.Parameters.AddWithValue("marca", marca);
                            }
                        }
                    }
                }
                else //Marca con producto.
                {
                    if (code)//consulta por codigo de producto.
                    {
                        if (!size && !color)//Consulta marca sin talla y sin color.
                        {
                            CargarAdapterStoredProcedure("producto_con_marca_nocolor");
                            miAdapter.SelectCommand.Parameters.AddWithValue("codigo", codigo);
                            miAdapter.SelectCommand.Parameters.AddWithValue("marca", marca);
                        }
                        else
                        {
                            if (size && !color)//Consulta marca con talla y sin color
                            {
                                CargarAdapterStoredProcedure("producto_code_marca_medida");
                                miAdapter.SelectCommand.Parameters.AddWithValue("codigo", codigo);
                                miAdapter.SelectCommand.Parameters.AddWithValue("marca", marca);
                                miAdapter.SelectCommand.Parameters.AddWithValue("talla", talla);
                            }
                            else
                            {
                                if (size && color)//Consulta marca con talla y con color.
                                {
                                    CargarAdapterStoredProcedure("producto_code_marca_medida_ycolor");
                                    miAdapter.SelectCommand.Parameters.AddWithValue("codigo", codigo);
                                    miAdapter.SelectCommand.Parameters.AddWithValue("marca", marca);
                                    miAdapter.SelectCommand.Parameters.AddWithValue("talla", talla);
                                }
                                else//Consulta marca sin talla y con color
                                {
                                    CargarAdapterStoredProcedure("producto_con_marca_ycolor");
                                    miAdapter.SelectCommand.Parameters.AddWithValue("codigo", codigo);
                                    miAdapter.SelectCommand.Parameters.AddWithValue("marca", marca);
                                }
                            }
                        }
                    }
                    else//consulta por nombre de producto.
                    {
                        if (!size && !color)//Consulta marca sin talla y sin color.
                        {
                            CargarAdapterStoredProcedure("producto_name_con_marca_nocolor");
                            miAdapter.SelectCommand.Parameters.AddWithValue("nombre", nombre);
                            miAdapter.SelectCommand.Parameters.AddWithValue("marca", marca);
                        }
                        else
                        {
                            if (size && !color)//Consulta marca con talla y sin color
                            {
                                CargarAdapterStoredProcedure("producto_name_marca_medida");
                                miAdapter.SelectCommand.Parameters.AddWithValue("nombre", nombre);
                                miAdapter.SelectCommand.Parameters.AddWithValue("marca", marca);
                                miAdapter.SelectCommand.Parameters.AddWithValue("talla", talla);
                            }
                            else
                            {
                                if (size && color)//Consulta marca con talla y con color.
                                {
                                    CargarAdapterStoredProcedure("producto_name_marca_medida_ycolor");
                                    miAdapter.SelectCommand.Parameters.AddWithValue("nombre", nombre);
                                    miAdapter.SelectCommand.Parameters.AddWithValue("marca", marca);
                                    miAdapter.SelectCommand.Parameters.AddWithValue("talla", talla);
                                }
                                else//Consulta marca sin talla y con color
                                {
                                    CargarAdapterStoredProcedure("producto_name_con_marca_ycolor");
                                    miAdapter.SelectCommand.Parameters.AddWithValue("nombre", nombre);
                                    miAdapter.SelectCommand.Parameters.AddWithValue("marca", marca);
                                }
                            }
                        }
                    }
                }
                miAdapter.Fill(dataSet, registroBase, registrosMaximos, "producto");
                return dataSet.Tables[0];
            }
            catch (Exception ex)
            {
                throw new Exception(ErrorConsulta + ex.Message);
            }
        }

        /// <summary>
        /// Obtiene el total de registros de una consulta segun el codigo o el nombre y la marca.
        /// </summary>
        /// <param name="codigo">Codigo del producto a consultar.</param>
        /// <param name="nombre">Nombre o parte de este del producto a consultar.</param>
        /// <param name="marca">Marca o parte de esta a consultar.</param>
        /// <param name="talla">Talla o parte de esta a consultar.</param>
        /// <param name="size">Indica si la consulta incluye talla o no.</param>
        /// <param name="product">Indica si la consulta incluye Producto o no.</param>
        /// <param name="code">Indica si se consulta por Codigo del producto o no.</param>
        /// <param name="color">Indica si la consulta incluye color o no.</param>
        /// <returns></returns>
        public long RowsConsultaProductoPorMarca
            (string codigo, string nombre, string marca, string talla, bool size,
             bool product, bool code, bool color)
        {
            try
            {
                if (!product)//Marca sola.
                {
                    if (!size && !color)//Consulta marca sin talla y sin color.
                    {
                        CargarComandoStoredProcedure("count_productos_marca_nocolor");
                        comando.Parameters.AddWithValue("marca", marca);
                    }
                    else
                    {
                        if (size && !color)//Consulta marca con talla y sin color
                        {
                            CargarComandoStoredProcedure("count_producto_marca_medida");
                            comando.Parameters.AddWithValue("marca", marca);
                            comando.Parameters.AddWithValue("talla", talla);
                        }
                        else
                        {
                            if (size && color)//Consulta marca con talla y con color.
                            {
                                CargarComandoStoredProcedure("count_producto_marca_medida_ycolor");
                                comando.Parameters.AddWithValue("marca", marca);
                                comando.Parameters.AddWithValue("talla", talla);
                            }
                            else//Consulta marca sin talla y con color
                            {
                                CargarComandoStoredProcedure("count_productos_marca_ycolor");
                                comando.Parameters.AddWithValue("marca", marca);
                            }
                        }
                    }
                }
                else //Marca con producto.
                {
                    if (code)//consulta por codigo de producto.
                    {
                        if (!size && !color)//Consulta marca sin talla y sin color.
                        {
                            CargarComandoStoredProcedure("count_producto_con_marca_nocolor");
                            comando.Parameters.AddWithValue("codigo", codigo);
                            comando.Parameters.AddWithValue("marca", marca);
                        }
                        else
                        {
                            if (size && !color)//Consulta marca con talla y sin color
                            {
                                CargarComandoStoredProcedure("count_producto_code_marca_medida");
                                comando.Parameters.AddWithValue("codigo", codigo);
                                comando.Parameters.AddWithValue("marca", marca);
                                comando.Parameters.AddWithValue("talla", talla);
                            }
                            else
                            {
                                if (size && color)//Consulta marca con talla y con color.
                                {
                                    CargarComandoStoredProcedure("count_producto_code_marca_medida_ycolor");
                                    comando.Parameters.AddWithValue("codigo", codigo);
                                    comando.Parameters.AddWithValue("marca", marca);
                                    comando.Parameters.AddWithValue("talla", talla);
                                }
                                else//Consulta marca sin talla y con color
                                {
                                    CargarComandoStoredProcedure("count_producto_con_marca_ycolor");
                                    comando.Parameters.AddWithValue("codigo", codigo);
                                    comando.Parameters.AddWithValue("marca", marca);
                                }
                            }
                        }
                    }
                    else//consulta por nombre de producto.
                    {
                        if (!size && !color)//Consulta marca sin talla y sin color.
                        {
                            CargarComandoStoredProcedure("count_producto_name_con_marca_nocolor");
                            comando.Parameters.AddWithValue("nombre", nombre);
                            comando.Parameters.AddWithValue("marca", marca);
                        }
                        else
                        {
                            if (size && !color)//Consulta marca con talla y sin color
                            {
                                CargarComandoStoredProcedure("count_producto_name_marca_medida");
                                comando.Parameters.AddWithValue("nombre", nombre);
                                comando.Parameters.AddWithValue("marca", marca);
                                comando.Parameters.AddWithValue("talla", talla);
                            }
                            else
                            {
                                if (size && color)//Consulta marca con talla y con color.
                                {
                                    CargarComandoStoredProcedure("count_producto_name_marca_medida_ycolor");
                                    comando.Parameters.AddWithValue("nombre", nombre);
                                    comando.Parameters.AddWithValue("marca", marca);
                                    comando.Parameters.AddWithValue("talla", talla);
                                }
                                else//Consulta marca sin talla y con color
                                {
                                    CargarComandoStoredProcedure("count_producto_name_con_marca_ycolor");
                                    comando.Parameters.AddWithValue("nombre", nombre);
                                    comando.Parameters.AddWithValue("marca", marca);
                                }
                            }
                        }
                    }
                }
                conexion.MiConexion.Open();
                var rows = Convert.ToInt64(comando.ExecuteScalar());
                conexion.MiConexion.Close();
                comando.Dispose();
                return rows;
            }
            catch (Exception ex)
            {
                throw new Exception(ErrorCount + ex.Message);
            }
            finally { conexion.MiConexion.Close(); }
        }

        /// <summary>
        /// Obtiene el listado de productos segun la talla.
        /// </summary>
        /// <param name="codigo">Codigo del producto a consultar.</param>
        /// <param name="nombre">Nombre o parte de este del producto a consultar.</param>
        /// <param name="talla">Talla o parte de esta a consultar.</param>
        /// <param name="product">Indica si la consulta incluye Producto o no.</param>
        /// <param name="code">Indica si se consulta por Codigo del producto o no.</param>
        /// <param name="color">Indica si la consulta incluye color o no.</param>
        /// <param name="registroBase">Registro base para la consulta.</param>
        /// <param name="registrosMaximos">Número de registros a recuperar.</param>
        /// <returns></returns>
        public DataTable ConsultaProductoPorTalla(string codigo, string nombre, string talla,
            bool product, bool code, bool color, int registroBase, int registrosMaximos)
        {
            var dataSet = new DataSet();
            try
            {
                if (product)
                {
                    if (code)
                    {
                        if (color)
                        {
                            CargarAdapterStoredProcedure("producto_con_medida_ycolor");
                            miAdapter.SelectCommand.Parameters.AddWithValue("codigo", codigo);
                            miAdapter.SelectCommand.Parameters.AddWithValue("talla", talla);
                        }
                        else
                        {
                            CargarAdapterStoredProcedure("producto_con_medida");
                            miAdapter.SelectCommand.Parameters.AddWithValue("codigo", codigo);
                            miAdapter.SelectCommand.Parameters.AddWithValue("talla", talla);
                        }
                    }
                    else
                    {
                        if (color)
                        {
                            CargarAdapterStoredProcedure("producto_name_con_medida_ycolor");
                            miAdapter.SelectCommand.Parameters.AddWithValue("nombre", nombre);
                            miAdapter.SelectCommand.Parameters.AddWithValue("talla", talla);
                        }
                        else
                        {
                            CargarAdapterStoredProcedure("producto_name_con_medida");
                            miAdapter.SelectCommand.Parameters.AddWithValue("nombre", nombre);
                            miAdapter.SelectCommand.Parameters.AddWithValue("talla", talla);
                        }
                    }
                }
                else//talla sola
                {
                    if (color)//con color
                    {
                        CargarAdapterStoredProcedure("producto_medida_ycolor");
                        miAdapter.SelectCommand.Parameters.AddWithValue("talla", talla);
                    }
                    else//sin color
                    {
                        CargarAdapterStoredProcedure("producto_medida");
                        miAdapter.SelectCommand.Parameters.AddWithValue("talla", talla);
                    }
                }
                miAdapter.Fill(dataSet, registroBase, registrosMaximos, "producto");
                return dataSet.Tables[0];
            }
            catch (Exception ex)
            {
                throw new Exception(ErrorConsulta + ex.Message);
            }
        }

        /// <summary>
        /// Obtiene el total de registros de una consulta segun el codigo o el nombre y la talla.
        /// </summary>
        /// <param name="codigo">Codigo del producto a consultar.</param>
        /// <param name="nombre">Nombre o parte de este del producto a consultar.</param>
        /// <param name="talla">Talla o parte de esta a consultar.</param>
        /// <param name="product">Indica si la consulta incluye Producto o no.</param>
        /// <param name="code">Indica si se consulta por Codigo del producto o no.</param>
        /// <param name="color">Indica si la consulta incluye color o no.</param>
        /// <returns></returns>
        public long RowsConsultaProductoPorTalla(string codigo, string nombre, string talla,
            bool product, bool code, bool color)
        {
            try
            {
                if (product)
                {
                    if (code)
                    {
                        if (color)
                        {
                            CargarComandoStoredProcedure("count_producto_con_medida_ycolor");
                            comando.Parameters.AddWithValue("codigo", codigo);
                            comando.Parameters.AddWithValue("talla", talla);
                        }
                        else
                        {
                            CargarComandoStoredProcedure("count_producto_con_medida");
                            comando.Parameters.AddWithValue("codigo", codigo);
                            comando.Parameters.AddWithValue("talla", talla);
                        }
                    }
                    else
                    {
                        if (color)
                        {
                            CargarComandoStoredProcedure("count_producto_name_con_medida_ycolor");
                            comando.Parameters.AddWithValue("nombre", nombre);
                            comando.Parameters.AddWithValue("talla", talla);
                        }
                        else
                        {
                            CargarComandoStoredProcedure("count_producto_name_con_medida");
                            comando.Parameters.AddWithValue("nombre", nombre);
                            comando.Parameters.AddWithValue("talla", talla);
                        }
                    }
                }
                else//talla sola
                {
                    if (color)//con color
                    {
                        CargarComandoStoredProcedure("count_producto_medida_ycolor");
                        comando.Parameters.AddWithValue("talla", talla);
                    }
                    else//sin color
                    {
                        CargarComandoStoredProcedure("count_producto_medida");
                        comando.Parameters.AddWithValue("talla", talla);
                    }
                }
                conexion.MiConexion.Open();
                var rows = Convert.ToInt64(comando.ExecuteScalar());
                conexion.MiConexion.Close();
                comando.Dispose();
                return rows;
            }
            catch (Exception ex)
            {
                throw new Exception(ErrorCount + ex.Message);
            }
            finally { conexion.MiConexion.Close(); }
        }

        /// <summary>
        /// Obtiene el registro completo de los datos de un Producto.
        /// </summary>
        /// <param name="codigo">Codigo Interno del producto a consultar.</param>
        /// <returns></returns>
        public Producto ProductoCompleto(string codigo)
        {
            var producto = new Producto();
            var descuento = new DaoDescuento();
            var recargo = new DaoRecargo();
            try
            {
                CargarComandoStoredProcedure("consulta_producto_completo");
                comando.Parameters.AddWithValue("codigo", codigo);
                conexion.MiConexion.Open();
                NpgsqlDataReader miReader = comando.ExecuteReader();
                while (miReader.Read())
                {
                    producto.CodigoInternoProducto = miReader.GetString(0);
                    producto.CodigoBarrasProducto = miReader.GetString(1);
                    producto.ReferenciaProducto = miReader.GetString(2);
                    producto.NombreProducto = miReader.GetString(3);
                    producto.DescripcionProducto = miReader.GetString(4);
                    producto.CodigoCategoria = miReader.GetString(5);
                    producto.NombreCategoria = miReader.GetString(6);
                    producto.IdMarca = miReader.GetInt32(7);
                    producto.NombreMarca = miReader.GetString(8);
                    producto.UtilidadPorcentualProducto = miReader.GetDouble(9);
                    producto.ValorVentaProducto = miReader.GetInt32(10);
                    producto.AplicaPrecioPorcentaje = miReader.GetBoolean(11);
                    producto.IdIva = miReader.GetInt32(12);
                    producto.ValorIva = miReader.GetDouble(13);
                    producto.ValorIvaAnterior = miReader.GetDouble(13);
                    producto.UnidadVentaProducto = miReader.GetInt32(14);
                    producto.CantidadMinimaProducto = miReader.GetInt32(15);
                    producto.CantidadMaximaProducto = miReader.GetInt32(16);
                    producto.EstadoProducto = miReader.GetBoolean(17);
                    producto.AplicaTalla = miReader.GetBoolean(18);
                    producto.AplicaColor = miReader.GetBoolean(19);
                    producto.CantidadDecimal = miReader.GetBoolean(20);
                    //producto.ValorCosto = Convert.ToInt32(miReader.GetDouble(21));
                    producto.ValorCosto = miReader.GetDouble(21);       // Nuevo cod. 06-02-2019
                    producto.DescuentoMayor = miReader.GetDouble(22);
                    producto.DescuentoDistribuidor = miReader.GetDouble(23);
                    producto.Utilidad2 = miReader.GetDouble(24);
                    producto.Utilidad3 = miReader.GetDouble(25);
                    producto.Codigo_2 = miReader.GetString(26);
                    producto.Codigo_3 = miReader.GetString(27);
                    producto.Codigo_4 = miReader.GetString(28);
                    producto.Codigo_5 = miReader.GetString(29);
                    producto.Codigo_6 = miReader.GetString(30);
                    producto.Codigo_7 = miReader.GetString(31);
                    producto.DescuentoPrecio4 = miReader.GetDouble(32);
                    producto.Impoconsumo = miReader.GetDouble(33);
                    producto.IdTipoInventario = miReader.GetInt32(34);
                    producto.IdIco = Convert.ToInt32(miReader.GetInt64(36));
                    producto.ValorIco = miReader.GetDouble(37);
                    producto.AplicaIco = miReader.GetBoolean(38);
                    producto.Imprime = miReader.GetBoolean(39);
                    producto.AplicaDescto = miReader.GetBoolean(40);
                }
                conexion.MiConexion.Close();
                comando.Dispose();
                producto.Descuentos = descuento.ListadoDeDescuento(codigo);
                producto.Recargos = recargo.ListadoDeRecargo(codigo);
                producto.CodProductoProceso = CodigoProductoProceso(producto.CodigoInternoProducto);
                return producto;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrio un error al cargar los datos del Producto.\n" + ex.Message);
            }
            finally { conexion.MiConexion.Close(); }
        }

        public string CodigoProductoProceso(string codProductoInsumo)
        {
            try
            {
                string sql = "select cod_producto_proceso from producto_proceso where cod_producto_insumo = '" + codProductoInsumo + "';";
                comando = new NpgsqlCommand();
                comando.Connection = conexion.MiConexion;
                comando.CommandType = System.Data.CommandType.Text;
                comando.CommandText = sql;
                conexion.MiConexion.Open();
                string codigo = Convert.ToString(comando.ExecuteScalar());
                conexion.MiConexion.Close();
                comando.Dispose();
                return codigo;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al consultar el producto materia prima.\n" + ex.Message);
            }
            finally { conexion.MiConexion.Close(); }
        }

        public Producto ProductoProcesoPresentacion(string codProductoInsumo)
        {
            try
            {
                var p = new Producto();
                string sql = "SELECT producto.codigointernoproducto, producto.unidadventaproducto, producto_proceso.cod_producto_proceso, inventario.cantidad_inventario FROM " +
                       "producto, producto_proceso, inventario WHERE producto.codigointernoproducto = producto_proceso.cod_producto_insumo AND " +
                       "producto_proceso.cod_producto_proceso = inventario.codigointernoproducto AND producto_proceso.cod_producto_insumo = '" + codProductoInsumo + "';";
                comando = new NpgsqlCommand();
                comando.Connection = conexion.MiConexion;
                comando.CommandType = System.Data.CommandType.Text;
                comando.CommandText = sql;
                conexion.MiConexion.Open();
                NpgsqlDataReader reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    p.CodigoInternoProducto = reader.GetString(2);
                    p.UnidadVentaProducto = reader.GetInt32(1);
                    p.Cantidad = reader.GetDouble(3);
                }
                conexion.MiConexion.Close();
                comando.Dispose();
                return p;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al consultar el producto materia prima.\n" + ex.Message);
            }
            finally { conexion.MiConexion.Close(); }
        }

        /// <summary>
        /// Obtiene ul listado de los registros de medida de los productos.
        /// </summary>
        /// <param name="codigo">Codigo del producto a consultar.</param>
        /// <returns></returns>
        public DataTable ProductoConMedida(string codigo)
        {
            var tabla = new DataTable();
            try
            {
                CargarAdapterStoredProcedure("producto_con_medida");
                miAdapter.SelectCommand.Parameters.AddWithValue("codigo", codigo);
                miAdapter.Fill(tabla);
                return tabla;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrio un error al cargar la(s) medida(s) del Producto.\n" + ex.Message);
            }
        }

        /// <summary>
        /// Obtiene el listado de colores de un producto segun su medida.
        /// </summary>
        /// <param name="codigo">Codigo del producto a consultar.</param>
        /// <param name="idMedida">Id de la medida del Producto.</param>
        /// <returns></returns>
        public DataTable ProductoConMedidaYcolor(string codigo, int idMedida)
        {
            var table = new DataTable();
            try
            {
                CargarAdapterStoredProcedure("color_producto_con_medida");
                miAdapter.SelectCommand.Parameters.AddWithValue("codigo", codigo);
                miAdapter.SelectCommand.Parameters.AddWithValue("medida", idMedida);
                miAdapter.Fill(table);
                return table;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrio un error al cargar los colores del Producto.\n" + ex.Message);
            }
        }

        public double PrecioDeCosto(string codigo)
        {
            try
            {
                CargarComandoStoredProcedure("costo_producto");
                comando.Parameters.AddWithValue("codigo", codigo);
                conexion.MiConexion.Open();
                var scalar = comando.ExecuteScalar();
                var costo = 0.0;
                if (scalar != DBNull.Value)
                {
                    costo = Convert.ToDouble(comando.ExecuteScalar());
                }
                conexion.MiConexion.Close();
                comando.Dispose();
                return costo;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrio un error al cargar los datos del Producto.\n" + ex.Message);
            }
            finally { conexion.MiConexion.Close(); }
        }

        public double PrecioDeCostoMasIva(string codigo)
        {
            try
            {
                CargarComandoStoredProcedure("costo_producto_con_iva");
                comando.Parameters.AddWithValue("codigo", codigo);
                conexion.MiConexion.Open();
                var scalar = comando.ExecuteScalar();
                var costo = 0.0;
                if (scalar != DBNull.Value)
                {
                    costo = Convert.ToDouble(comando.ExecuteScalar());
                }
                conexion.MiConexion.Close();
                comando.Dispose();
                return costo;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrio un error al cargar los datos del Producto.\n" + ex.Message);
            }
            finally { conexion.MiConexion.Close(); }
        }

        public DataTable ImprimirProductos(bool addIva)
        {
            string code = "";
            try
            {
                
                bool RedondearPrecio2 = Convert.ToBoolean(Utilities.AppConfiguracion.ValorSeccion("redondeo_precio_dos"));
                bool aprox_precio = Convert.ToBoolean(Utilities.AppConfiguracion.ValorSeccion("tipo_aprox_precio"));

                var tablaTmp = new DataTable();
                var tabla = new DataTable();
                tabla.Columns.Add("Codigo", typeof(string));
                tabla.Columns.Add("Nombre", typeof(string));
                tabla.Columns.Add("Iva", typeof(string));
                tabla.Columns.Add("Costo", typeof(int));
                tabla.Columns.Add("Ico", typeof(double));
                tabla.Columns.Add("PrecioVenta", typeof(int));
                tabla.Columns.Add("PrecioPorMayor", typeof(int));
                tabla.Columns.Add("marca", typeof(string));
                CargarAdapterStoredProcedure("imprimir_productos");  // OJO
                miAdapter.Fill(tablaTmp);
                foreach (DataRow row in tablaTmp.Rows)
                {
                    var row_ = tabla.NewRow();
                    code = row["codigo"].ToString();
                    row_["Codigo"] = row["codigo"];
                    row_["Nombre"] = row["nombre"];
                    row_["Iva"] = row["iva"] + "%";
                    row_["Costo"] = row["costo"];
                    row_["Ico"] = row["impoconsumo"];
                    /*if (addIva)
                    {
                        row_["Costo"] = Convert.ToInt32(Convert.ToInt32(row["costo"]) +
                            (Convert.ToInt32(row["costo"]) * Convert.ToDouble(row["iva"]) / 100));
                    }
                    else
                    {
                        row_["Costo"] = row["costo"];
                    }*/
                    row_["PrecioVenta"] = row["venta"];
                    if (RedondearPrecio2)
                    {
                        row_["PrecioPorMayor"] = Utilities.UseObject.Aproximar(Convert.ToInt32(row["precio_mayor"]), this.aprox_precio);
                    }
                    else
                    {
                        row_["PrecioPorMayor"] = row["precio_mayor"];
                    }
                    row_["marca"] = row["nombremarca"];
                    tabla.Rows.Add(row_);
                }
                tablaTmp.Rows.Clear();
                tablaTmp = null;
                return tabla;
            }
            catch (Exception ex)
            {
                var j = code;
                throw new Exception("Ocurrió un error al consultar los productos.\n" + ex.Message);
            }
        }

        public void EditarPrecioDeVenta(string codigo, int venta, double util)
        {
            try
            {
                CargarComandoStoredProcedure("editar_precio_venta");
                comando.Parameters.AddWithValue("", codigo);
                comando.Parameters.AddWithValue("", venta);
                comando.Parameters.AddWithValue("", util);
                conexion.MiConexion.Open();
                var count = this.comando.ExecuteScalar();
                //comando.ExecuteNonQuery();
                conexion.MiConexion.Close();
                comando.Dispose();
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al editar los datos de precio de venta de producto.\n" + ex.Message);
            }
            finally { conexion.MiConexion.Close(); }
        }

        public void EditarPrecioDeCosto(string codigo, double costo, double impoconsumo)
        {
            try
            {
                CargarComandoStoredProcedure("editar_precio_costo");
                comando.Parameters.AddWithValue("", codigo);
                comando.Parameters.AddWithValue("", costo);
                comando.Parameters.AddWithValue("", impoconsumo);
                conexion.MiConexion.Open();
                comando.ExecuteNonQuery();
                conexion.MiConexion.Close();
                comando.Dispose();
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al editar los datos de costo de producto.\n" + ex.Message);
            }
            finally { conexion.MiConexion.Close(); }
        }

        public void EditarCosto(string codigo, double costo)
        {
            try
            {
                string sql =
                    "update producto set precio_costo = @costo where codigointernoproducto = @codigo;";
                comando = new NpgsqlCommand();
                comando.Connection = conexion.MiConexion;
                comando.CommandType = System.Data.CommandType.Text;
                comando.CommandText = sql;
                comando.Parameters.AddWithValue("codigo", codigo);
                comando.Parameters.AddWithValue("costo", costo);
                conexion.MiConexion.Open();
                comando.ExecuteNonQuery();
                conexion.MiConexion.Close();
                comando.Dispose();
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al editar el costo.\n" + ex.Message);
            }
            finally { conexion.MiConexion.Close(); }
        }

        public void EditarUtilidadVenta
            (string codigo, double util, int valorVenta, double costo)
        {
            try
            {
                CargarComandoStoredProcedure("editar_utilidad_venta");
                comando.Parameters.AddWithValue("codigo", codigo);
                comando.Parameters.AddWithValue("utilidad", util);
                comando.Parameters.AddWithValue("valorVenta", valorVenta);
                comando.Parameters.AddWithValue("costo", costo);
                conexion.MiConexion.Open();
                comando.ExecuteNonQuery();
                conexion.MiConexion.Close();
                comando.Dispose();
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al editar los datos de utilidad en venta.\n" + ex.Message);
            }
            finally { conexion.MiConexion.Close(); }
        }

        public void EditarIva(string codigo, int idIva)
        {
            try
            {
                CargarComandoStoredProcedure("editar_iva");
                comando.Parameters.AddWithValue("codigo", codigo);
                comando.Parameters.AddWithValue("idIva", idIva);
                conexion.MiConexion.Open();
                comando.ExecuteNonQuery();
                conexion.MiConexion.Close();
                comando.Dispose();
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al editar los datos del Iva.\n" + ex.Message);
            }
            finally { conexion.MiConexion.Close(); }
        }

        public void EditarDescuentos(string codigo, double desctoMayor, double desctoDistribuidor)
        {
            try
            {
                CargarComandoStoredProcedure("editar_descuentos");
                comando.Parameters.AddWithValue("codigo", codigo);
                comando.Parameters.AddWithValue("desctoMayor", desctoMayor);
                comando.Parameters.AddWithValue("desctoDistri", desctoDistribuidor);
                conexion.MiConexion.Open();
                comando.ExecuteNonQuery();
                conexion.MiConexion.Close();
                comando.Dispose();
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al editar los datos de los descuentos.\n" + ex.Message);
            }
            finally { conexion.MiConexion.Close(); }
        }

        // Edicion de formulario de "Edicion de precio de producto."
        public void EditarPrecios(Producto p)
        {
            try
            {
                CargarComandoStoredProcedure("editar_precios_producto");
                comando.Parameters.AddWithValue("", p.CodigoInternoProducto);
                comando.Parameters.AddWithValue("", p.UtilidadPorcentualProducto);
                comando.Parameters.AddWithValue("", p.ValorVentaProducto);
                comando.Parameters.AddWithValue("", p.IdIva);
                comando.Parameters.AddWithValue("", p.IdIvaTemp);
                comando.Parameters.AddWithValue("", p.ValorCosto);
                comando.Parameters.AddWithValue("", p.DescuentoMayor);
                comando.Parameters.AddWithValue("", p.DescuentoDistribuidor);
                comando.Parameters.AddWithValue("", p.DescuentoPrecio4);
                comando.Parameters.AddWithValue("", p.Utilidad2);
                comando.Parameters.AddWithValue("", p.Utilidad3);
                comando.Parameters.AddWithValue("", p.Impoconsumo);
                conexion.MiConexion.Open();
                comando.ExecuteNonQuery();
                conexion.MiConexion.Close();
                comando.Dispose();
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al editar el precio." + ex.Message);
            }
            finally { this.conexion.MiConexion.Close(); }
        }

        //

        /// <summary>
        /// Obtiene el último valor ingresado en factura de un Producto
        /// </summary>
        /// <param name="inventario">Inventario del producto a consultar.</param>
        /// <returns></returns>
        public int UltimoValorProducto(Inventario inventario)
        {
            try
            {
                CargarComandoStoredProcedure(ultimoValor);
                comando.Parameters.AddWithValue("codigo", inventario.CodigoProducto);
                comando.Parameters.AddWithValue("medida", inventario.IdMedida);
                comando.Parameters.AddWithValue("color", inventario.IdColor);
                conexion.MiConexion.Open();
                var valor = Convert.ToInt32(comando.ExecuteScalar());
                conexion.MiConexion.Close();
                comando.Dispose();
                return valor;
            }
            catch (Exception ex)
            {
                throw new Exception(ErrorUltimoPrecio + ex.Message);
            }
            finally { conexion.MiConexion.Close(); }
        }

        /// <summary>
        /// Obtiene un promedio de los valores de Producto segun facturas de proveedor.
        /// </summary>
        /// <param name="inventario">Inventario de Producto a consultar.</param>
        /// <returns></returns>
        public int PromedioValorProducto(Inventario inventario)
        {
            int promedio = 0;
            try
            {
                CargarComandoStoredProcedure(UltimosValores);
                comando.Parameters.AddWithValue("codigo", inventario.CodigoProducto);
                comando.Parameters.AddWithValue("medida", inventario.IdMedida);
                comando.Parameters.AddWithValue("color", inventario.IdColor);
                comando.Parameters.AddWithValue("limite", inventario.Cantidad);
                conexion.MiConexion.Open();
                NpgsqlDataReader miReader = comando.ExecuteReader();
                var contador = 0;
                while (miReader.Read())
                {
                    promedio += miReader.GetInt32(0);
                    contador++;
                }
                promedio = promedio / contador;
                conexion.MiConexion.Close();
                comando.Dispose();
                return promedio;
            }
            catch (Exception ex)
            {
                throw new Exception(ErrorUltimoPrecio + ex.Message);
            }
            finally 
            { 
                conexion.MiConexion.Close();
                promedio = 0;
            }
        }

        /// <summary>
        /// Edita los datos de un registro de Producto.
        /// </summary>
        /// <param name="producto">Producto a editar.</param>
        public void EditarProducto(Producto producto)
        {
            var daoDescuento = new DaoDescuento();
            var daoRecargo = new DaoRecargo();
            miDaoValor = new DaoValorUnidadMedida();
            miDaoInventario = new DaoInventario();

            try
            {
                CargarComandoStoredProcedure("editar_producto");
                comando.Parameters.AddWithValue("codigoo", producto.CodigoInternoProducto);
                comando.Parameters.AddWithValue("codigoEditado", producto.CodigoInternoEditado);
                comando.Parameters.AddWithValue("barras", producto.CodigoBarrasProducto);
                comando.Parameters.AddWithValue("referencia", producto.ReferenciaProducto);
                comando.Parameters.AddWithValue("nombre", producto.NombreProducto);
                comando.Parameters.AddWithValue("descripcion", producto.DescripcionProducto);
                comando.Parameters.AddWithValue("categoria", producto.CodigoCategoria);
                comando.Parameters.AddWithValue("idMarca", producto.IdMarca);
                comando.Parameters.AddWithValue("utilidad", producto.UtilidadPorcentualProducto);
                comando.Parameters.AddWithValue("valor", producto.ValorVentaProducto);
                comando.Parameters.AddWithValue("aplicaPorcentaje", producto.AplicaPrecioPorcentaje);
                comando.Parameters.AddWithValue("idIva", producto.IdIva);
                comando.Parameters.AddWithValue("unidadVenta", producto.UnidadVentaProducto);
                comando.Parameters.AddWithValue("minima", producto.CantidadMinimaProducto);
                comando.Parameters.AddWithValue("maxima", producto.CantidadMaximaProducto);
                comando.Parameters.AddWithValue("estado", producto.EstadoProducto);
                comando.Parameters.AddWithValue("talla", producto.AplicaTalla);
                comando.Parameters.AddWithValue("color", producto.AplicaColor);
                comando.Parameters.AddWithValue("cantdecimal", producto.CantidadDecimal);
                comando.Parameters.AddWithValue("valorcosto", producto.ValorCosto);
                comando.Parameters.AddWithValue("destoMayor", producto.DescuentoMayor);
                comando.Parameters.AddWithValue("destoDistribuidor", producto.DescuentoDistribuidor);
                comando.Parameters.AddWithValue("iva_temp", producto.IdIvaTemp);
                comando.Parameters.AddWithValue("", producto.Codigo_2);
                comando.Parameters.AddWithValue("", producto.Codigo_3);
                comando.Parameters.AddWithValue("", producto.Codigo_4);
                comando.Parameters.AddWithValue("", producto.Codigo_5);
                comando.Parameters.AddWithValue("", producto.Codigo_6);
                comando.Parameters.AddWithValue("", producto.Codigo_7);
                comando.Parameters.AddWithValue("", producto.IdTipoInventario);

                comando.Parameters.AddWithValue("", producto.IdIco);
                comando.Parameters.AddWithValue("", producto.AplicaIco);
                comando.Parameters.AddWithValue("", producto.Imprime);
                comando.Parameters.AddWithValue("", producto.AplicaDescto);
                conexion.MiConexion.Open();
                comando.ExecuteNonQuery();
                conexion.MiConexion.Close();
                comando.Dispose();

                miDaoValor.EditarMedidaProducto(producto.CodigoInternoEditado, producto.IdMedida);
                miDaoInventario.ActualizarMedidaInventario(producto.CodigoInternoEditado, producto.IdMedida);
                if (ExisteProductoProceso(producto.CodigoInternoEditado))
                {
                    EditarProductoProceso(producto.CodigoInternoEditado, producto.CodProductoProceso);
                }
                else
                {
                    InsertarProductoProceso(producto.CodigoInternoEditado, producto.CodProductoProceso);
                }

                var descuentos = daoDescuento.ListadoDeDescuento(producto.CodigoInternoEditado);
                var recargos = daoRecargo.ListadoDeRecargo(producto.CodigoInternoEditado);
                ///Elimina relaciones de Descuento y Recargo que ya no existen.
                foreach (Descuento d in descuentos)
                {
                    var noExiste = true;
                    foreach (Descuento d1 in producto.Descuentos)
                    {
                        if (d.IdDescuento == d1.IdDescuento)
                        {
                            noExiste = false;
                            break;
                        }
                        else
                        {
                            noExiste = true;
                        }
                    }
                    if (noExiste)
                    {
                        daoDescuento.EliminarDescuento(d.IdDescuento, producto.CodigoInternoEditado);
                    }
                }
                foreach (Recargo r in recargos)
                {
                    var noExiste = true;
                    foreach (Recargo r1 in producto.Recargos)
                    {
                        if (r.IdRecargo == r1.IdRecargo)
                        {
                            noExiste = false;
                            break;
                        }
                        else
                        {
                            noExiste = true;
                        }
                    }
                    if (noExiste)
                    {
                        daoRecargo.EliminarRecargo(r.IdRecargo, producto.CodigoInternoEditado);
                    }
                }

                ///Ingresa relaciones de Descuento y Recargo que ha sido añadidas.
                foreach (Descuento des in producto.Descuentos)
                {
                    var existe = true;
                    foreach (Descuento des1 in descuentos)
                    {
                        if (des.IdDescuento == des1.IdDescuento)
                        {
                            existe = false;
                            break;
                        }
                        else
                        {
                            existe = true;
                        }
                    }
                    if (existe)
                    {
                        des.CodigoInternoProducto = producto.CodigoInternoEditado;
                        daoDescuento.InsertarDescuento(des);
                    }
                }
                foreach (Recargo rec in producto.Recargos)
                {
                    var existe = true;
                    foreach (Recargo rec1 in recargos)
                    {
                        if (rec.IdRecargo == rec1.IdRecargo)
                        {
                            existe = false;
                            break;
                        }
                        else
                        {
                            existe = true;
                        }
                    }
                    if (existe)
                    {
                        rec.CodigoInternoProducto = producto.CodigoInternoEditado;
                        daoRecargo.InsertarRecargo(rec);
                    }
                }

                //EditarInical(producto.CodigoInternoEditado);
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrio un error al editar los datos del Producto.\n" + ex.Message);
            }
            finally { conexion.MiConexion.Close(); }
        }

        private bool ExisteProductoProceso(string codProductoInsumo)
        {
            try
            {
                CargarComandoStoredProcedure("existe_producto_proceso");
                comando.Parameters.AddWithValue("", codProductoInsumo);
                conexion.MiConexion.Open();
                var existe = Convert.ToBoolean(comando.ExecuteScalar());
                conexion.MiConexion.Close();
                comando.Dispose();
                return existe;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al verificar el producto insumo.\n" + ex.Message);
            }
            finally { conexion.MiConexion.Close(); }
        }

        private void EditarProductoProceso(string codProductoInsumo, string codProductoProceso)
        {
            try
            {
                string sql = 
                    "update producto_proceso set cod_producto_proceso = '" + codProductoProceso + "' where cod_producto_insumo = '" + codProductoInsumo + "'; ";
                comando = new NpgsqlCommand();
                comando.Connection = conexion.MiConexion;
                comando.CommandType = System.Data.CommandType.Text;
                comando.CommandText = sql;
                conexion.MiConexion.Open();
                comando.ExecuteNonQuery();
                conexion.MiConexion.Close();
                comando.Dispose();
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al editar el producto en proceso.\n" + ex.Message);
            }
            finally { conexion.MiConexion.Close(); }
        }

        /// <summary>
        /// Elimina el registro de Producto de la base de datos.
        /// </summary>
        /// <param name="codigo">Codigo Interno del Producto a eliminar.</param>
        public void EliminarProducto(string codigo)
        {
            try
            {
                CargarComandoStoredProcedure("eliminar_producto");
                comando.Parameters.AddWithValue("codigo", codigo);
                conexion.MiConexion.Open();
                comando.ExecuteNonQuery();
                conexion.MiConexion.Close();
                comando.Dispose();
            }
            catch (Exception)
            {
                throw new Exception("No se puede eliminar el Producto porque aun se encuentra en Inventario.");
            }
            finally { conexion.MiConexion.Close(); }
        }

        /// <summary>
        /// Obtiene los datos basicos de un producto.
        /// </summary>
        /// <param name="codigo">Codigo a consultar.</param>
        /// <returns></returns>
        public ArrayList ProductoBasico(string codigo)
        {
            ArrayList lista = new ArrayList();
            ValorUnidadMedida lista1 = new ValorUnidadMedida();
            try
            {
                //CargarComandoStoredProcedure("producto_basico");
                CargarComandoStoredProcedure("producto_basico_codigos"); // 18/07/2017 EDICIÓN, CODIGOS (6) EN PRODUCTO
                comando.Parameters.AddWithValue("codigo", codigo);
                Producto producto = new Producto();
                conexion.MiConexion.Open();
                NpgsqlDataReader miReader = comando.ExecuteReader();
                while (miReader.Read())
                {
                    producto = new Producto();
                    producto.CodigoInternoProducto = miReader.GetString(0);
                    producto.CodigoBarrasProducto = miReader.GetString(1);
                    producto.NombreProducto = miReader.GetString(2);
                    producto.NombreMarca = miReader.GetString(3);
                    producto.AplicaTalla = miReader.GetBoolean(4);
                    producto.AplicaColor = miReader.GetBoolean(5);
                    producto.ValorIva = miReader.GetDouble(7);
                    producto.ValorIvaAnterior = miReader.GetDouble(7);
                    producto.AplicaPrecioPorcentaje = miReader.GetBoolean(8);
                    producto.ValorVentaProducto = miReader.GetInt32(9);
                    producto.UtilidadPorcentualProducto = miReader.GetDouble(10);
                    producto.CantidadDecimal = miReader.GetBoolean(11);
                    producto.DescuentoMayor = miReader.GetDouble(12);
                    producto.DescuentoDistribuidor = miReader.GetDouble(13);
                    producto.IdIvaTemp = miReader.GetInt32(14);
                    producto.ValorCosto = miReader.GetDouble(15);
                    producto.IdMarca = miReader.GetInt32(22);
                    producto.DescuentoPrecio4 = miReader.GetDouble(23);
                    producto.Impoconsumo = miReader.GetDouble(24);
                    producto.UnidadVentaProducto = miReader.GetInt32(25);
                    producto.IdTipoInventario = miReader.GetInt32(26);
                    producto.IdIva = miReader.GetInt32(27);
                    lista.Add(producto);
                }
                conexion.MiConexion.Close();
                comando.Dispose();
                if (producto.CodigoInternoProducto != "")
                {
                    if (!producto.AplicaTalla)
                    {
                        lista1 = ProductoMedida(producto.CodigoInternoProducto);
                        lista.Add(lista1);
                    }
                }
                return lista;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrio un Error al cargar el Producto\n" + ex.Message);
            }
            finally { conexion.MiConexion.Close(); }
        }

        /// <summary>
        /// Obtiene la unidad de medida del Producto.
        /// </summary>
        /// <param name="codigo">Codigo del Producto a consultar.</param>
        /// <returns></returns>
        public ValorUnidadMedida ProductoMedida(string codigo)
        {
            ValorUnidadMedida medida = new ValorUnidadMedida();
            try
            {
                CargarComandoStoredProcedure("producto_medida_codigo");
                comando.Parameters.AddWithValue("codigo", codigo);
                conexion.MiConexion.Open();
                NpgsqlDataReader miReader = comando.ExecuteReader();
                while (miReader.Read())
                {
                    medida.DescripcionUnidadMedida = miReader.GetString(1);
                    medida.IdValorUnidadMedida = miReader.GetInt32(2);
                    medida.DescripcionValorUnidadMedida = miReader.GetString(3);
                }
                conexion.MiConexion.Close();
                comando.Dispose();
                return medida;
            }
            catch (Exception)
            {
                throw new Exception();
            }
            finally { conexion.MiConexion.Close(); }
        }

        /// <summary>
        /// Carga y relaciona producto a sorteo.
        /// </summary>
        /// <param name="idSorteo"></param>
        /// <param name="codigoInternoProducto"></param>
        public void InsertarProductoSorteo(int idSorteo, string codigoInternoProducto, bool historial)
        {
            try
            {
                if (historial)
                {
                    CargarComandoStoredProcedure("insertar_historial_sorteo_producto");
                }
                else
                {
                    CargarComandoStoredProcedure("insertar_sorteo_producto");
                }
                comando.Parameters.AddWithValue("idSorteo", idSorteo);
                comando.Parameters.AddWithValue("codigoInternoProducto",codigoInternoProducto);
                conexion.MiConexion.Open();
                comando.ExecuteNonQuery();
                conexion.MiConexion.Close();
                comando.Dispose();
            }
            catch(Exception ex) 
            {
                throw new Exception("Error al insertar el producto" + ex.Message);
            }
            finally 
            {
                conexion.MiConexion.Close();
            }
        }

        /// <summary>
        /// Consulta producto por codigo interno y por codigo de barras
        /// </summary>
        /// <param name="codigo"></param>
        /// <returns></returns>
          public Producto ConsultaProductoSimple(string codigo)
          {
              try
              {
                  CargarComandoStoredProcedure("consulta_producto_simple");
                  comando.Parameters.AddWithValue("codigoproducto", codigo);
                  conexion.MiConexion.Open();
                  NpgsqlDataReader reader = comando.ExecuteReader();
                  var producto = new Producto();
                  while (reader.Read())
                  {
                      producto.CodigoInternoProducto = reader.GetString(0);
                      producto.NombreProducto = reader.GetString(1);                      
                  }
                  conexion.MiConexion.Close();
                  comando.Dispose();

                  return producto;
              }
              catch (Exception ex)
              {
                  throw new Exception("Error al consultar los productos" + ex.Message);
              }
              finally
              {
                  conexion.MiConexion.Close();
              }
          }

        /// <summary>
        /// Listo categorias de sorteo.
        /// </summary>
        /// <param name="idsorteo"></param>
        /// <returns></returns>
          public List<Producto> CargaProductoSorteo(int idsorteo ,bool historial)
          {
              List<Producto> ListaProductoSarteo = new List<Producto>();
              try
              {
                  if (historial)
                  {
                      CargarComandoStoredProcedure("historial_sorteo_producto");
                  }
                  else
                  {
                      CargarComandoStoredProcedure("sorteo_producto");
                  }
                  comando.Parameters.AddWithValue("idSorteo", idsorteo);
                  conexion.MiConexion.Open();
                  NpgsqlDataReader myreader = comando.ExecuteReader();
                  while (myreader.Read())
                  {
                      Producto miproducto = new Producto();
                      miproducto.CodigoInternoProducto = myreader.GetString(0);
                      miproducto.NombreProducto = myreader.GetString(3);
                      ListaProductoSarteo.Add(miproducto);
                  }
                  conexion.MiConexion.Close();               
                  comando.Dispose();
                  return ListaProductoSarteo;
              }
              catch(Exception ex)
              {
                  throw new Exception("No se pudo listar las categorias" + ex.Message);
              }
              finally
              {
                  conexion.MiConexion.Close();
              }
          }

        /// <summary>
        /// insertar producto a promocion.
        /// </summary>
        /// <param name="idPromocion"></param>
        /// <param name="codigoInternoproducto"></param>
        /// <param name="cantidadProducto"></param>
          public void InsertarProductoPromocion(int idPromocion, string codigoInternoproducto, int cantidadProducto)
          {
              try
              {
                  CargarComandoStoredProcedure("insertar_promocion_producto");
                  comando.Parameters.AddWithValue("idpromocion", idPromocion);
                  comando.Parameters.AddWithValue("codigoInternoProducto", codigoInternoproducto);
                  comando.Parameters.AddWithValue("cantidadpruducto", cantidadProducto);
                  conexion.MiConexion.Open();
                  comando.ExecuteNonQuery();
                  conexion.MiConexion.Close();
                  comando.Dispose();
              }
              catch(Exception ex)
              {
                  throw new Exception("Error al insertar producto a promocion" + ex.Message);
              }
              finally
              {
                  conexion.MiConexion.Close();
              }
          }

        /// <summary>
        /// Edita producto de promocion
        /// </summary>
        /// <param name="idPromocion">id promocion</param>
        /// <param name="codigoInternoproducto">codigoInternnoproducto</param>
        /// <param name="cantidadProducto">cantidad</param>
        public void EditarProductoPromocion(int idPromocion, string codigoInternoproducto, int cantidadProducto)
        {
            try
            {
                CargarComandoStoredProcedure("edita_promocion_Producto");
                comando.Parameters.AddWithValue("idpromocion", idPromocion);
                comando.Parameters.AddWithValue("codigoproducto", codigoInternoproducto);
                comando.Parameters.AddWithValue("cantidad", cantidadProducto);
                conexion.MiConexion.Open();
                comando.ExecuteNonQuery();
                conexion.MiConexion.Close();
                comando.Dispose();
            }
            catch(Exception ex)
            {
                throw new Exception("Error al editar el producto" + ex.Message);
            }
            finally
            {
                conexion.MiConexion.Close();
            }
        }

        // Descuentos por marca 01/03/2018

        public void IngresarValorDeProducto()
        {
            try
            {
                this.CargarComandoStoredProcedure("ingresar_producto_valor");
                this.conexion.MiConexion.Open();
                this.comando.ExecuteNonQuery();
                this.conexion.MiConexion.Close();
                this.comando.Dispose();
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al cargar los valores de los productos.\n" + ex.Message);
            }
            finally { this.conexion.MiConexion.Close(); }
        }

        public int CountValorDeProducto()
        {
            try
            {
                this.CargarComandoStoredProcedure("count_producto_valor");
                this.conexion.MiConexion.Open();
                int count = Convert.ToInt32(this.comando.ExecuteScalar());
                this.conexion.MiConexion.Close();
                this.comando.Dispose();
                return count;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al consultar el conteo de los precios de productos.\n" + ex.Message);
            }
            finally { this.conexion.MiConexion.Close(); }
        }

        public void IngresarValorDeProducto(int idMarca)
        {
            try
            {
                this.CargarComandoStoredProcedure("ingresar_producto_valor");
                this.comando.Parameters.AddWithValue("", idMarca);
                this.conexion.MiConexion.Open();
                this.comando.ExecuteNonQuery();
                this.conexion.MiConexion.Close();
                this.comando.Dispose();
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al cargar los valores de los productos.\n" + ex.Message);
            }
            finally { this.conexion.MiConexion.Close(); }
        }

        public int ValorDeProducto(string codigo)
        {
            try
            {
                CargarComandoStoredProcedure("valor_de_producto");
                this.comando.Parameters.AddWithValue("", codigo);
                this.conexion.MiConexion.Open();
                object objData = this.comando.ExecuteScalar();
                int valor = 0;
                if (!(objData is DBNull))
                {
                    valor = Convert.ToInt32(objData);
                }
                this.conexion.MiConexion.Close();
                this.comando.Dispose();
                return valor;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al consultar el precio del producto.\n" + ex.Message);
            }
            finally { this.conexion.MiConexion.Close(); }
        }

        public Marca DescuentoPrecio(string codigo)
        {
            try
            {
                CargarComandoStoredProcedure("marca_descuento_valor");
                this.comando.Parameters.AddWithValue("", codigo);
                this.conexion.MiConexion.Open();
                NpgsqlDataReader reader = this.comando.ExecuteReader();
                var m = new Marca();
                while (reader.Read())
                {
                    m.Precio = reader.GetInt32(2);
                    m.Descuento = reader.GetDouble(3);
                    m.Valor = reader.GetInt32(4);
                }
                this.conexion.MiConexion.Close();
                this.comando.Dispose();
                return m;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al consultar el precio del producto.\n" + ex.Message);
            }
            finally { this.conexion.MiConexion.Close(); }
        }

        public void RestablecerValor(int idMarca)
        {
            try
            {
                CargarComandoStoredProcedure("restablecer_valor_producto");
                this.comando.Parameters.AddWithValue("", idMarca);
                this.conexion.MiConexion.Open();
                this.comando.ExecuteNonQuery();
                this.conexion.MiConexion.Close();
                this.comando.Dispose();
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al restablecer el valor del producto.\n" + ex.Message);
            }
            finally { this.conexion.MiConexion.Close(); }
        }

        public void EliminarValorDeProducto()
        {
            try
            {
                this.CargarComandoStoredProcedure("eliminar_producto_valor");
                this.conexion.MiConexion.Open();
                this.comando.ExecuteNonQuery();
                this.conexion.MiConexion.Close();
                this.comando.Dispose();
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al eliminar los valores de los productos.\n" + ex.Message);
            }
            finally { this.conexion.MiConexion.Close(); }
        }

        public void EliminarValorDeProducto(int idMarca)
        {
            try
            {
                this.CargarComandoStoredProcedure("eliminar_producto_valor");
                this.comando.Parameters.AddWithValue("", idMarca);
                this.conexion.MiConexion.Open();
                this.comando.ExecuteNonQuery();
                this.conexion.MiConexion.Close();
                this.comando.Dispose();
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al eliminar los valores de los productos.\n" + ex.Message);
            }
            finally { this.conexion.MiConexion.Close(); }
        }

        /*public void ReiniciarSecuenciaProductoValor()
        {
            try
            {
                this.CargarComandoStoredProcedure("reiniciar_secuencia_producto_valor");
                this.conexion.MiConexion.Open();
                this.comando.ExecuteNonQuery();
                this.conexion.MiConexion.Close();
                this.comando.Dispose();
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al reiniciar la secuencia de los registros de precio de productos.\n" + ex.Message);
            }
            finally { this.conexion.MiConexion.Close(); }
        }*/

        // Fin Descuentos por marca 01/03/2018



        // Metodo para buscar replicas entre Codigo Interno y Codigo de Barras en producto.
        public DataTable Replicas(bool codigo)
        {
            try
            {
                var daoConsecutivo = new DaoConsecutivo();
                var tabla = new DataTable();
                string sql = "SELECT codigointernoproducto AS codigo, codigobarrasproducto AS barra, nombreproducto AS nombre FROM producto;";
                miAdapter = new NpgsqlDataAdapter(sql, conexion.MiConexion);
                miAdapter.SelectCommand.CommandType = CommandType.Text;
                miAdapter.Fill(tabla);
                var tablaReplica = new DataTable();
                tablaReplica.Columns.Add(new DataColumn("Numero", typeof(int)));
                tablaReplica.Columns.Add(new DataColumn("Codigo", typeof(string)));
                tablaReplica.Columns.Add(new DataColumn("Cod Barras", typeof(string)));
                tablaReplica.Columns.Add(new DataColumn("Nombre", typeof(string)));
                int contador = 0;
                string criterio = "";
                if (codigo)
                {
                    criterio = "codigo";
                }
                else
                {
                    criterio = "barra";
                }
                foreach (DataRow tRow in tabla.Rows)
                {
                    var query = from data in tabla.AsEnumerable()
                                where data.Field<string>(criterio).Equals(tRow["barra"].ToString())
                                select data;
                    if (query.ToArray().Length > 1)
                    {
                        foreach (DataRow qRow in query)
                        {
                            contador++;
                            var repRow = tablaReplica.NewRow();
                            repRow["Numero"] = contador;
                            repRow["Codigo"] = qRow["codigo"].ToString();
                            repRow["Cod Barras"] = qRow["barra"].ToString();
                            repRow["Nombre"] = qRow["nombre"].ToString();

                            tablaReplica.Rows.Add(repRow);
                        }
                    }
                }
                return tablaReplica;
            }
            catch (Exception ex)
            {
                throw new Exception("OCURRIÓ UN ERROR.\n" + ex.Message);
            }
        }

        public DataTable ReplicasEnFactura()
        {
            try
            {
                var tVentas = new DataTable();
                string sql = "SELECT producto_factura_venta.codigointernoproducto AS codigo FROM producto_factura_venta;";
                miAdapter = new NpgsqlDataAdapter(sql, conexion.MiConexion);
                miAdapter.SelectCommand.CommandType = CommandType.Text;
                miAdapter.Fill(tVentas);

                var tReplicas = Replicas(false);
                var tabla = new DataTable();
                tabla.Columns.Add(new DataColumn("Numero", typeof(int)));
                tabla.Columns.Add(new DataColumn("Codigo", typeof(string)));
                tabla.Columns.Add(new DataColumn("Cod Barras", typeof(string)));
                tabla.Columns.Add(new DataColumn("Nombre", typeof(string)));
                int contador = 0;
                foreach (DataRow rRow in tReplicas.Rows)
                {
                    var query = from data in tVentas.AsEnumerable()
                                where data.Field<string>("codigo").Equals(rRow["Codigo"].ToString())
                                select data;
                    if (query.ToArray().Length > 0)
                    {
                        contador++;
                        var row = tabla.NewRow();
                        row["Numero"] = contador;
                        row["Codigo"] = rRow["Codigo"].ToString();
                        row["Cod Barras"] = rRow["Cod Barras"].ToString();
                        row["Nombre"] = rRow["Nombre"].ToString();
                        tabla.Rows.Add(row);
                    }
                }
                return tabla;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void AjustarReplicas(bool codigo)
        {
            try
            {
                var tabla = new DataTable();
                string sql = "SELECT codigointernoproducto AS codigo, codigobarrasproducto AS barra FROM producto;";
                miAdapter = new NpgsqlDataAdapter(sql, conexion.MiConexion);
                miAdapter.SelectCommand.CommandType = CommandType.Text;
                miAdapter.Fill(tabla);
                var tablaReplica = new DataTable();
                tablaReplica.Columns.Add(new DataColumn("Codigo", typeof(string)));
                string criterio = "";
                if (codigo)
                {
                    criterio = "codigo";
                }
                else
                {
                    criterio = "barra";
                }
                foreach (DataRow tRow in tabla.Rows)
                {
                    var query = from data in tabla.AsEnumerable()
                                where data.Field<string>(criterio).Equals(tRow["barra"].ToString())
                                select data;
                    if (query.ToArray().Length > 1)
                    {
                        var barra = ObtenerCodigoBarras();
                        comando = new NpgsqlCommand();
                        comando.Connection = conexion.MiConexion;
                        comando.CommandType = CommandType.Text;
                        comando.CommandText =
                        "UPDATE producto SET codigobarrasproducto = '" + barra + "' WHERE codigointernoproducto = '" + tRow["codigo"].ToString() + "';";
                        conexion.MiConexion.Open();
                        comando.ExecuteNonQuery();
                        conexion.MiConexion.Close();
                        comando.Dispose();
                        ActualizarProductoBarras(barra);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("OCURRIÓ UN ERROR.\n" + ex.Message);
            }
        }

        public void AjustarBarrasVacia()
        {
            try
            {
                //var daoConsecutivo = new DaoConsecutivo();
                var tabla = new DataTable();
                string sql = 
                "SELECT codigointernoproducto AS codigo, codigobarrasproducto AS barra FROM producto WHERE codigobarrasproducto = '';";
                miAdapter = new NpgsqlDataAdapter(sql, conexion.MiConexion);
                miAdapter.SelectCommand.CommandType = CommandType.Text;
                miAdapter.Fill(tabla);
                
                foreach (DataRow row in tabla.Rows)
                {
                    var barra = ObtenerCodigoBarras();
                    comando = new NpgsqlCommand();
                    comando.Connection = conexion.MiConexion;
                    comando.CommandType = CommandType.Text;
                    comando.CommandText =
                    "UPDATE producto SET codigobarrasproducto = '" + barra + "' WHERE codigointernoproducto = '" + row["codigo"].ToString() + "';";
                    conexion.MiConexion.Open();
                    comando.ExecuteNonQuery();
                    conexion.MiConexion.Close();
                    comando.Dispose();
                    ActualizarProductoBarras(barra);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        public void EliminarProductosNoNecesarios()
        {
            try
            {
                string sql = "SELECT codigointernoproducto FROM producto;";
                this.comando = new NpgsqlCommand();
                this.comando.Connection = this.conexion.MiConexion;
                this.comando.CommandType = CommandType.Text;
                this.comando.CommandText = sql;
                this.conexion.MiConexion.Open();
                List<Producto> productos = new List<Producto>();
                NpgsqlDataReader reader = this.comando.ExecuteReader();
                while (reader.Read())
                {
                    productos.Add(new Producto { CodigoInternoProducto = reader.GetString(0) });
                }
                this.comando.Dispose();
                this.conexion.MiConexion.Close();

                foreach (var p in productos)
                {
                    this.DeleteProducts(p.CodigoInternoProducto);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("" + ex.Message);
            }
            finally { this.conexion.MiConexion.Close(); }
        }

        private void DeleteProducts(string codigo)
        {
            try
            {
                string sql = "DELETE FROM producto WHERE codigointernoproducto = '" + codigo + "';";
                this.comando = new NpgsqlCommand();
                this.comando.Connection = this.conexion.MiConexion;
                this.comando.CommandType = CommandType.Text;
                this.comando.CommandText = sql;
                this.conexion.MiConexion.Open();
                this.comando.ExecuteNonQuery();
                this.comando.Dispose();
                this.conexion.MiConexion.Close();
            }
            catch { }
            finally
            {
                this.comando.Dispose();
                this.conexion.MiConexion.Close();
            }
        }


        // Consultas a producto mejoradas - Form nuevo - ilike multiples  Date: 22-05-2021 "ALMACEN REPUESTOS CARROS-TORNILLOS"

        public List<Producto> Productos(string[] filtros)
        {
            try
            {
                /*codigointernoproducto, 
                               codigobarrasproducto, 
                               nombreproducto,  
                               referenciaproducto, 
                               descripcionproducto,  
                               nombremarca,  
                               nombrecategoria, 
                               valorventaproducto, 
                               cantidad_inventario,  
                               precio_costo,  
                               mi_round(precio_costo + (precio_costo * valoriva / 100), 0) AS costo_iva,
                               valoriva, 
                               utilidadporcentualproducto, 
                               estadoproducto*/


                /* "codigointernoproducto, " +
                    "codigobarrasproducto,  " +
                    "nombreproducto,  " +
                    "referenciaproducto,  " +
                    "descripcionproducto,  " +
                    "nombremarca,  " +
                    "nombrecategoria, " + 
                    "valorventaproducto,  " +
                    "view_inventario_producto.descto_mayor, " +
                    "view_inventario_producto.mayorista, " +
                    "cantidad_inventario,  " +
                    "precio_costo,  " +
                    "mi_round(precio_costo + (precio_costo * valoriva / 100), 0) AS costo_iva, " + 
                    "valoriva,  " + 
                    "utilidadporcentualproducto, " +
                    "estadoproducto " + */


                /**
                string sql = "SELECT " +
                              "codigointernoproducto, " +
                              "codigobarrasproducto, " +
                              "nombre, " +
                              "referenciaproducto, " +
                              "descripcionproducto, " +
                              "nombremarca, " +
                              "nombrecategoria, " +
                              "valorventaproducto, " +
                              "descto_mayor, " +

                              "mi_round_trunc((valorventaproducto - mi_round(impoconsumo, 0) - " + 
                                 "mi_round((valorventaproducto - mi_round(impoconsumo, 0)) * descto_mayor / 100, 1)), 0) + " + 
                                 "mi_round(impoconsumo, 0) AS mayorista, " + 

                              "cantidad_inventario, " +
                              "precio_costo, " +
                              "mi_round(precio_costo + (precio_costo * valoriva / 100), 0) AS costo_iva," +
                              "valoriva, " +
                              "utilidadporcentualproducto, " +
                              "estadoproducto " + 
                             "FROM  " +
                               "view_producto_completo_  " +
                             "WHERE " +
                             "estadoproducto = true AND ";
                */
                string sql =
                    @"SELECT 
                          codigointernoproducto, 
                          codigobarrasproducto, 
                          nombre, 
                          referenciaproducto, 
                          descripcionproducto, 
                          nombremarca, 
                          nombrecategoria, 
                          valorventaproducto, 
                          descto_mayor, 

                          mi_round_trunc((valorventaproducto - mi_round(impoconsumo, 0) -  
	                         mi_round((valorventaproducto - mi_round(impoconsumo, 0)) * descto_mayor / 100, 1)), 0) +  
	                         mi_round(impoconsumo, 0) AS mayorista,  

                          cantidad_inventario, 
                          precio_costo, 
                          mi_round(precio_costo + (precio_costo * valoriva / 100), 0) AS costo_iva,
                          valoriva, 
                          utilidadporcentualproducto, 
                          estadoproducto , 

                            mi_round_trunc((valorventaproducto - mi_round(impoconsumo, 0) -  
	                         mi_round((valorventaproducto - mi_round(impoconsumo, 0)) * descto_distribuidor / 100, 1)), 0) +  
	                         mi_round(impoconsumo, 0) AS precio3,  
	 
                          mi_round_trunc((valorventaproducto - mi_round(impoconsumo, 0) -  
	                         mi_round((valorventaproducto - mi_round(impoconsumo, 0)) * descto_3 / 100, 1)), 0) +  
	                         mi_round(impoconsumo, 0) AS precio4 
                         FROM  
                           view_producto_completo_  
                         WHERE 
                            estadoproducto = true AND ( ";

                string strFiltro_Code = "(",
                       strFiltroName = "(";
                foreach (var f in filtros)
                {
                    strFiltro_Code += "codigobarrasproducto || ' ' || descripcionproducto ILIKE '%" + f + "%' ";
                    strFiltroName += "nombre ILIKE '%" + f + "%' ";
                    //strFiltroRef += "view_producto_completo.referenciaproducto ILIKE '%" + f + "%' ";
                    if (!(f.Equals(filtros.Last())))
                    {
                        strFiltro_Code += " AND ";
                        strFiltroName += " AND ";
                        //strFiltroRef += " OR ";
                    }
                }
                strFiltro_Code += ")";
                strFiltroName += ")";
                //strFiltroRef += ")";
                sql += strFiltro_Code + " OR " + strFiltroName +
                       " ) ORDER BY nombre ASC;";
                var productos = new List<Producto>();
                Producto p;
                LoadCommandTypeText(sql);
                conexion.MiConexion.Open();
                NpgsqlDataReader reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    p = new Producto();
                    p.CodigoInternoProducto = reader.GetString(0);
                    p.CodigoBarrasProducto = reader.GetString(1);
                    p.NombreProducto = reader.GetString(2);
                    p.ReferenciaProducto = reader.GetString(3);
                    p.DescripcionProducto = reader.GetString(4);
                    p.NombreMarca = reader.GetString(5);
                    p.NombreCategoria = reader.GetString(6);
                    p.ValorVentaProducto = reader.GetInt32(7);
                    p.Utilidad2 = reader.GetDouble(8);
                    p.DescuentoMayor = reader.GetDouble(9);
                    p.Price3 = reader.GetDouble(16);
                    p.Price4 = reader.GetDouble(17);
                    if (RedondearPrecio2)
                    {
                        p.DescuentoMayor = Utilities.UseObject.Aproximar(Convert.ToInt32(p.DescuentoMayor), aprox_precio);
                        p.Price3 = Utilities.UseObject.Aproximar(Convert.ToInt32(p.Price3), aprox_precio);
                        p.Price4 = Utilities.UseObject.Aproximar(Convert.ToInt32(p.Price4), aprox_precio);
                    }
                    p.Cantidad = reader.GetDouble(10);
                    p.ValorCosto = Convert.ToDouble(reader.GetDecimal(12)); // Costo + iva
                    p.ValorIva = reader.GetDouble(13);
                    p.UtilidadPorcentualProducto = reader.GetDouble(14);
                    p.EstadoProducto = reader.GetBoolean(15);

                    productos.Add(p);
                }
                conexion.MiConexion.Close();
                comando.Dispose();
                /* while (miReader.Read())
                 {
                     producto = new Producto();
                     producto.CodigoInternoProducto = miReader.GetString(0);
                     producto.CodigoBarrasProducto = miReader.GetString(1);
                     producto.NombreProducto = miReader.GetString(2);
                     producto.NombreMarca = miReader.GetString(3);
                     producto.AplicaTalla = miReader.GetBoolean(4);
                     producto.AplicaColor = miReader.GetBoolean(5);
                     producto.ValorIva = miReader.GetDouble(7);
                     producto.ValorIvaAnterior = miReader.GetDouble(7);
                     producto.AplicaPrecioPorcentaje = miReader.GetBoolean(8);
                     producto.ValorVentaProducto = miReader.GetInt32(9);
                     producto.UtilidadPorcentualProducto = miReader.GetDouble(10);
                     producto.CantidadDecimal = miReader.GetBoolean(11);
                     producto.DescuentoMayor = miReader.GetDouble(12);
                     producto.DescuentoDistribuidor = miReader.GetDouble(13);
                     producto.IdIvaTemp = miReader.GetInt32(14);
                     producto.ValorCosto = miReader.GetDouble(15);
                     producto.IdMarca = miReader.GetInt32(22);
                     producto.DescuentoPrecio4 = miReader.GetDouble(23);
                     producto.Impoconsumo = miReader.GetDouble(24);
                     producto.UnidadVentaProducto = miReader.GetInt32(25);
                     producto.IdTipoInventario = miReader.GetInt32(26);
                     lista.Add(producto);
                 }*/

                /*LoadAdapterTypeText(sql);
                DataTable myTable = new DataTable();
                miAdapter.Fill(myTable);
                return myTable;*/
                return productos;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrio un error al consultar los productos\n" + ex.Message);
            }
            finally { conexion.MiConexion.Close(); }
        }

        public void EditPrice(string codigo, int price)
        {
            try
            {
                string sql = "update producto set valorventaproducto = @price where codigointernoproducto = @code;";
                LoadCommandTypeText(sql);
                comando.Parameters.AddWithValue("code", codigo);
                comando.Parameters.AddWithValue("price", price);
                conexion.MiConexion.Open();
                comando.ExecuteNonQuery();
                conexion.MiConexion.Close();
                comando.Dispose();
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrio un error al editar el precio.\n" + ex.Message);
            }
            finally { conexion.MiConexion.Close(); }
        }

        // End Date: 22-05-2021


        /// <summary>
        /// Inicializa una nueva instancia de NpgsqlCommand de tipo Stored Procedure.
        /// </summary>
        /// <param name="cmd">Sentencia a ejecutar.</param>
        private void CargarComandoStoredProcedure(string cmd)
        {
            comando = new NpgsqlCommand();
            comando.Connection = conexion.MiConexion;
            comando.CommandType = System.Data.CommandType.StoredProcedure;
            comando.CommandText = cmd;
        }

        private void CargarAdapter(string cmd)
        {
            miAdapter = new NpgsqlDataAdapter(cmd, conexion.MiConexion);
            miAdapter.SelectCommand.CommandType = System.Data.CommandType.Text;
        }

        /// <summary>
        /// Inicializa una nueva instancia de NpgsqlDataAdapter de tipo Stored Procedure.
        /// </summary>
        /// <param name="cmd">Sentencia a ejecutar.</param>
        private void CargarAdapterStoredProcedure(string cmd)
        {
            miAdapter = new NpgsqlDataAdapter(cmd, conexion.MiConexion);
            miAdapter.SelectCommand.CommandType = System.Data.CommandType.StoredProcedure;
        }


        private void LoadCommandTypeText(string cmd)
        {
            comando = new NpgsqlCommand();
            comando.Connection = conexion.MiConexion;
            comando.CommandType = System.Data.CommandType.Text;
            comando.CommandText = cmd;
        }

        private void LoadAdapterTypeText(string cmd)
        {
            miAdapter = new NpgsqlDataAdapter(cmd, conexion.MiConexion);
            miAdapter.SelectCommand.CommandType = System.Data.CommandType.Text;
        }

        #endregion

        public DataTable CuentasContables()
        {
            try
            {
                var tabla = new DataTable();
                tabla.Columns.Add(new DataColumn("numero", typeof(string)));
                tabla.Columns.Add(new DataColumn("descripcion", typeof(string)));
                DataRow nRow = tabla.NewRow();
                nRow["numero"] = "Seleccione una cuenta";
                nRow["descripcion"] = "Seleccione una cuenta";
                tabla.Rows.Add(nRow);
                CargarComandoStoredProcedure("cuentas_contables");
                conexion.MiConexion.Open();
                NpgsqlDataReader reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    nRow = tabla.NewRow();
                    nRow["numero"] = reader.GetString(1);
                    nRow["descripcion"] = reader.GetString(2);
                    tabla.Rows.Add(nRow);
                }
                conexion.MiConexion.Close();
                comando.Dispose();
                return tabla;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al cargar las cuentas contables.\n" + ex.Message);
            }
        }

        public DataTable TiposInventario()
        {
            try
            {
                var tabla = new DataTable();
                CargarAdapterStoredProcedure("tipos_inventario");
                miAdapter.Fill(tabla);
                return tabla;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al cargar los tipos de inventario.\n" + ex.Message);
            }
        }

        public DataTable ProductosProceso(int idTipoInventario)
        {
            try
            {
                var tabla = new DataTable();
                tabla.Columns.Add(new DataColumn("codigo", typeof(string)));
                tabla.Columns.Add(new DataColumn("producto", typeof(string)));
                DataRow nRow = tabla.NewRow();
                nRow["codigo"] = "";
                nRow["producto"] = "Seleccione un producto";
                tabla.Rows.Add(nRow);

                CargarComandoStoredProcedure("productos_tipo_inventario");
                comando.Parameters.AddWithValue("", idTipoInventario);
                conexion.MiConexion.Open();
                NpgsqlDataReader reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    nRow = tabla.NewRow();
                    nRow["codigo"] = reader.GetString(0);
                    nRow["producto"] = reader.GetString(1);
                    tabla.Rows.Add(nRow);
                }
                conexion.MiConexion.Close();
                comando.Dispose();
                return tabla;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al cargar los productos en proceso.\n" + ex.Message);
            }
            finally { conexion.MiConexion.Close(); }
        }

        public DataTable UnidadDeMedida(string name)
        {
            try
            {
                string sql = 
                    "select idvalor_unidad_medida as id, descripcionvalor_unidad_medida || '- ' ||codigo as descripcion " +
                    "from valor_unidad_medida where descripcionvalor_unidad_medida ilike '" + name + "%' order by descripcionvalor_unidad_medida ";
                var tMedida = new DataTable();
                CargarAdapter(sql);
                miAdapter.Fill(tMedida);
                return tMedida;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al cargar los productos en proceso.\n" + ex.Message);
            }
        }

        public DataTable UnidadDeMedida()
        {
            try
            {
                string sql =
                    "select idvalor_unidad_medida as id, descripcionvalor_unidad_medida || '- ' ||codigo as descripcion " +
                    "from valor_unidad_medida order by descripcionvalor_unidad_medida ";
                var tMedida = new DataTable();
                CargarAdapter(sql);
                miAdapter.Fill(tMedida);
                return tMedida;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al cargar los productos en proceso.\n" + ex.Message);
            }
        }

       /* public string CodigoProductoProceso(string codProductoInsumo)
        {
            try
            {
                string sql =
                    "select cod_producto_proceso from producto_proceso where cod_producto_insumo = '" + codProductoInsumo + "';";
                comando = new NpgsqlCommand();
                comando.Connection = conexion.MiConexion;
                comando.CommandType = System.Data.CommandType.Text;
                comando.CommandText = sql;
                conexion.MiConexion.Open();
                string codigo = Convert.ToString(comando.ExecuteScalar());
                conexion.MiConexion.Close();
                comando.Dispose();
                return codigo;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al consultar el producto en proceso.\n" + ex.Message);
            }
            finally
            {
                conexion.MiConexion.Close();
            }
        }*/

        public DataTable ProductosAll()
        {
            try
            {
                string sql =
        "SELECT producto.codigointernoproducto AS codigo, producto.precio_costo AS costo, producto.utilidadporcentualproducto AS util, producto.valorventaproducto AS venta, " +
        "iva.valoriva AS iva, producto.descto_mayor AS descto1, producto.descto_distribuidor AS descto2 FROM public.producto, public.iva " +
        "WHERE iva.idiva = producto.idiva ORDER BY producto.nombreproducto ASC;";
                miAdapter = new NpgsqlDataAdapter(sql, conexion.MiConexion);
                miAdapter.SelectCommand.CommandType = System.Data.CommandType.Text;

                DataTable table = new DataTable();
                miAdapter.Fill(table);
                return table;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void EditarUtilidad2_3(string codigo, double util2, double util3)
        {
            try
            {
                string sql =
"UPDATE producto SET utilidad_2 = " + util2.ToString().Replace(',', '.') + ", utilidad_3 = " + util3.ToString().Replace(',', '.') + " WHERE codigointernoproducto = '" + codigo + "' ;";
                comando = new NpgsqlCommand();
                comando.Connection = conexion.MiConexion;
                comando.CommandType = System.Data.CommandType.Text;
                comando.CommandText = sql;

                conexion.MiConexion.Open();
                comando.ExecuteNonQuery();
                conexion.MiConexion.Close();
                comando.Dispose();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally { conexion.MiConexion.Close(); }
        }

        public void EditarUtilidad_2_3(string codigo, int venta, double util, double util2, double util3)
        {
            try
            {
                string sql =
"UPDATE producto SET valorventaproducto = " + venta + ", utilidadporcentualproducto = " + util + ", utilidad_2 = " + util2 + ", utilidad_3 = " + util3 + " WHERE codigointernoproducto = '" + codigo + "' ;";
                comando = new NpgsqlCommand();
                comando.Connection = conexion.MiConexion;
                comando.CommandType = System.Data.CommandType.Text;
                comando.CommandText = sql;

                conexion.MiConexion.Open();
                comando.ExecuteNonQuery();
                conexion.MiConexion.Close();
                comando.Dispose();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally { conexion.MiConexion.Close(); }
        }

        public void EditarInical(string codigo)
        {
            try
            {
                string sql =
                "UPDATE producto SET inicial = TRUE WHERE codigointernoproducto = '" + codigo + "' ;";
                comando = new NpgsqlCommand();
                comando.Connection = conexion.MiConexion;
                comando.CommandType = System.Data.CommandType.Text;
                comando.CommandText = sql;

                conexion.MiConexion.Open();
                comando.ExecuteNonQuery();
                conexion.MiConexion.Close();
                comando.Dispose();
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrio un error al editar el producto.\n" + ex.Message);
            }
            finally { conexion.MiConexion.Close(); }
        }

        public void NewConection()
        {
            try
            {
                conexion = new Conexion();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}