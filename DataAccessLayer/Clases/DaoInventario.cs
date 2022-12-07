using System;
using System.Collections;
using System.Data;
using System.Linq;
using DataAccessLayer.DataSets;
using DTO.Clases;
using Npgsql;
using Utilities;
using System.Collections.Generic;

namespace DataAccessLayer.Clases
{
    /// <summary>
    /// Representa una clase de tranzacion de Base de Datos de Inventario.
    /// </summary>
    public class DaoInventario
    {
        #region Atributos

        private Producto MiProducto { set; get; }

        /// <summary>
        /// Objeto de conexion a base de datos PostgreSQL.
        /// </summary>
        private Conexion miConexion;

        private DaoConsecutivo miDaoConsecutivo;

        /// <summary>
        /// Representa un objeto de sentencias SQL a PostgreSQL.
        /// </summary>
        private NpgsqlCommand miComando;

        /// <summary>
        /// Objeto adaptador de consultas a base de datos.
        /// </summary>
        private NpgsqlDataAdapter miAdapter;

        private DaoKardex miDaoKardex;

        private Kardex Kardex { set; get; }

        private bool aprox_precio;

        private bool RedondearPrecio2;

        /// <summary>
        /// Representa la funcion comprobar_inventario.
        /// </summary>
        private const string sqlComprobar = "comprobar_inventario";

        /// <summary>
        /// Representa la funcion comprobar_cantidad_inventario.
        /// </summary>
        private const string sqlComprobarCant = "comprobar_cantidad_inventario";

        /// <summary>
        /// Representa la funcion insertar_inventario_fisico.
        /// </summary>
        private const string sqlInsertarFisico = "insertar_inventario_fisico";

        /// <summary>
        /// Representa la funcion insertar_inventario.
        /// </summary>
        private const string sqlInsertar = "insertar_inventario";

        /// <summary>
        /// Representa la funcion producto_marca.
        /// </summary>
        private const string sqlProductoMarca = "producto_marca";

        /// <summary>
        /// Representa la funcion productos_corte.
        /// </summary>
        private const string sqlProductoCorte = "productos_corte";

        /// <summary>
        /// Representa la funcion productoen_resumen_inventario.
        /// </summary>
        private const string sqlProductoHistorial = "productoen_resumen_inventario";

        /// <summary>
        /// Representa la funcion count_productoen_resumen_inventario.
        /// </summary>
        private const string sqlTotalProductoHistorial = "count_productoen_resumen_inventario";

        /// <summary>
        /// Representa la funcion count_producto_corte.
        /// </summary>
        private const string sqlTotalProductoCorte = "count_producto_corte";

        /// <summary>
        /// Representa la funcino count_lista_producto_corte_pendiente.
        /// </summary>
        private const string sqlCountConsultaCorteGeneral = "count_lista_producto_corte_pendiente";

        /// <summary>
        /// Representa la funcion corte_inventario_fisico.
        /// </summary>
        private const string sqlCorteInventarioFisico = "corte_inventario_fisico";

        /// <summary>
        /// Representa la funcion consulta_inventario.
        /// </summary>
        private const string sqlConsultaInventario = "consulta_inventario";

        /// <summary>
        /// Representa la funcion insertar_resumen_inventario.
        /// </summary>
        private const string sqlInsertarResumenInventario = "insertar_resumen_inventario";

        /// <summary>
        /// Representa la funcion get_cantidad_inventario.
        /// </summary>
        private const string sqlCantidadInventario = "get_cantidad_inventario";

        /// <summary>
        /// Representa la funcion editar_inventario.
        /// </summary>
        private const string sqlEditarInventario = "editar_inventario";

        /// <summary>
        /// Representa la funcion editar_inventario_fisico.
        /// </summary>
        private const string sqlEditarInventarioFisico = "editar_inventario_fisico";

        /// <summary>
        /// Representa la funcion : producto_basico_categoria.
        /// </summary>
        private const string sqlProductoCategoria = "producto_basico_categoria";

        /// <summary>
        /// Representa la funcion count_producto_categoria.
        /// </summary>
        private const string sqlTotalRegistrosProducto = "count_producto_categoria";

        /// <summary>
        /// Representa la funcion consulta_inventario_fisico.
        /// </summary>
        private const string sqlConsultaFisico = "consulta_inventario_fisico";

        /// <summary>
        /// Representa la funcion count_corte_inventario.
        /// </summary>
        private const string sqlTotalCorteInventario = "count_corte_inventario";

        /// <summary>
        /// Representa la funcion consulta_inventario_fisico_nocolor.
        /// </summary>
        private const string sqlConsultaInventarioFisicoNoColor = "consulta_inventario_fisico_nocolor";

        /// <summary>
        /// Representa la funcion count_corte_inventario_nocolor.
        /// </summary>
        private const string sqlTotalInventarioFisicoNoColor = "count_corte_inventario_nocolor";

        /// <summary>
        /// Representa la funcion lista_resumen_inventario.
        /// </summary>
        private const string sqlResumenInventario = "lista_resumen_inventario";

        /// <summary>
        /// Representa la funcion : count_resumen_inventario.
        /// </summary>
        private const string sqlTotalResumenInventario = "count_resumen_inventario";

        /// <summary>
        /// Representa la funcion : resumen_inventario_nocolor.
        /// </summary>
        private const string sqlResumenInventarioNoColor = "resumen_inventario_nocolor";

        /// <summary>
        /// Representa la funcion : count_resumen_inventario_nocolor.
        /// </summary>
        private const string sqlTotalResumenInventarioNoColor = "count_resumen_inventario_nocolor";

        /// <summary>
        /// Representa la funcion ultimo_registro_resumen_inventario.
        /// </summary>
        private const string sqlUltimoRegistroInventario = "ultimo_registro_resumen_inventario";

        /// <summary>
        /// Representa la funcion count_ultimo_registro_resumen_inventario.
        /// </summary>
        private const string sqlTotalUltimoRegistroInventario = "count_ultimo_registro_resumen_inventario";

        /// <summary>
        /// Representa la funcion ultimo_registro_resumen_inventario_nocolor.
        /// </summary>
        private const string sqlUltimoRegistroInventarioNoColor = "ultimo_registro_resumen_inventario_nocolor";

        /// <summary>
        /// Representa la funcion resumen_inventario_fecha.
        /// </summary>
        private const string sqlResumenInventarioFecha = "resumen_inventario_fecha";

        /// <summary>
        /// Representa la funcion resumen_inventario_fecha_nocolor.
        /// </summary>
        private const string sqlResumenInventarioFechaNoColor = "resumen_inventario_fecha_nocolor";

        /// <summary>
        /// Representa la funcion count_resumen_inventario_fecha.
        /// </summary>
        private const string sqlTotalResumenInventarioFecha = "count_resumen_inventario_fecha";

        /// <summary>
        /// Representa la funcion resumen_inventario_periodo.
        /// </summary>
        private const string sqlResumenInventarioPeriodo = "resumen_inventario_periodo";

        /// <summary>
        /// Representa la funcion count_resumen_inventario_periodo.
        /// </summary>
        private const string sqlTotalInventarioPeriodo = "count_resumen_inventario_periodo";

        /// <summary>
        /// Representa la funcion resumen_inventario_periodo_nocolor.
        /// </summary>
        private const string sqlInventarioPeriodoNoColor = "resumen_inventario_periodo_nocolor";

        /// <summary>
        /// Representa la funcion count_resumen_inventario_periodo_nocolor.
        /// </summary>
        private const string sqlTotalInventarioPeriodoNoColor = "count_resumen_inventario_periodo_nocolor";

        /// <summary>
        /// Representa la funcion eliminar_inventario.
        /// </summary>
        private const string sqlEliminar = "eliminar_inventario";

        /// <summary>
        /// Representa el texto : Ocurrio un error al comprobar el inventario.
        /// </summary>
        private const string ErrorComprobar = "Ocurrio un error al comprobar el inventario.\n";

        /// <summary>
        /// Representa el texto : Ocurrio un error al ingresar el registro de inventario.
        /// </summary>
        private const string ErrorInsertar = "Ocurrio un error al ingresar el registro de inventario.\n";

        /// <summary>
        /// Represetna la funcion Ocurrio un error al actualizar los datos en inventario.
        /// </summary>
        private const string ErrorActualizar = "Ocurrio un error al actualizar los datos en inventario.\n";

        /// <summary>
        /// Representa el texto : Ocurrio un problema al cargar el registro del producto.
        /// </summary>
        private const string ErrorProducto = "Ocurrio un problema al cargar el registro del producto.\n";

        #endregion

        /// <summary>
        /// Inicializa una nueva instancia de la clase Inventario.
        /// </summary>
        public DaoInventario()
        {
            this.MiProducto = new Producto();
            this.miConexion = new Conexion();
            miDaoConsecutivo = new DaoConsecutivo();

            daoProducto = new DaoProducto();
            miDaoKardex = new DaoKardex();
            Kardex = new Kardex();
            try
            {
                this.aprox_precio = Convert.ToBoolean(AppConfiguracion.ValorSeccion("tipo_aprox_precio"));
                this.RedondearPrecio2 = Convert.ToBoolean(AppConfiguracion.ValorSeccion("redondeo_precio_dos"));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public DaoInventario(string ipServer)
        {
            miConexion = new Conexion(ipServer, "");
        }

        /// <summary>
        /// Ingresa un registro del inventario a la base de datos.
        /// </summary>
        /// <param name="inventario"></param>
        public void InsertarInventario(Inventario inventario)
        {
            try
            {
                CargarComandoStoredProcedure(sqlInsertar);
                miComando.Parameters.AddWithValue("producto", inventario.CodigoProducto);
                miComando.Parameters.AddWithValue("medida", inventario.IdMedida);
                miComando.Parameters.AddWithValue("color", inventario.IdColor);
                miComando.Parameters.AddWithValue("cantidad", inventario.Cantidad);
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

        /// <summary>
        /// Ingresa un regsitro del inventario fisico a la base de datos.
        /// </summary>
        /// <param name="inventario">Inventario a ingresar.</param>
        public void InsertarInventarioFisico(InventarioFisico inventario)
        {
            var daoValorMedida = new DaoValorUnidadMedida();
            try
            {
                var tInventario = ConsultarInventarioFisico
                                  (inventario.CodigoProducto, inventario.IdMedida, inventario.IdColor, false);
                if (tInventario.Rows.Count != 0)
                {
                    var iRow = tInventario.AsEnumerable().First();
                    inventario.Cantidad += Convert.ToDouble(iRow["cantidad_inventario_fisico"]);
                    ActualizarInventarioFisico(Convert.ToInt32(iRow["id_inventario_fisico"]), inventario.Cantidad);
                }
                else
                {
                    CargarComandoStoredProcedure(sqlInsertarFisico);
                    miComando.Parameters.AddWithValue("fecha", inventario.Fecha.ToShortDateString());
                    miComando.Parameters.AddWithValue("producto", inventario.CodigoProducto);
                    miComando.Parameters.AddWithValue("medida", inventario.IdMedida);
                    miComando.Parameters.AddWithValue("color", inventario.IdColor);
                    miComando.Parameters.AddWithValue("cantidad", inventario.Cantidad);
                    miComando.Parameters.AddWithValue("corte", inventario.Corte);
                    miComando.Parameters.AddWithValue("numeroCorte", Convert.ToInt32(miDaoConsecutivo.Consecutivo("ConsCorte")));
                    miComando.Parameters.AddWithValue("costo", inventario.Costo);
                    miConexion.MiConexion.Open();
                    miComando.ExecuteNonQuery();
                    miConexion.MiConexion.Close();
                    miComando.Dispose();
                }
               /* CargarComandoStoredProcedure(sqlInsertarFisico);
                miComando.Parameters.AddWithValue("fecha", inventario.Fecha.ToShortDateString());
                miComando.Parameters.AddWithValue("producto", inventario.CodigoProducto);
                miComando.Parameters.AddWithValue("medida", inventario.IdMedida);
                miComando.Parameters.AddWithValue("color", inventario.IdColor);
                miComando.Parameters.AddWithValue("cantidad", inventario.Cantidad);
                miComando.Parameters.AddWithValue("corte", inventario.Corte);
                miConexion.MiConexion.Open();
                miComando.ExecuteNonQuery();
                miConexion.MiConexion.Close();
                miComando.Dispose();*/
            }
            catch (Exception ex)
            {
                throw new Exception(ErrorInsertar + ex.Message);
            }
            finally { miConexion.MiConexion.Close(); }
            Inventario miInventario = new Inventario();
            miInventario.CodigoProducto = inventario.CodigoProducto;
            miInventario.IdMedida = inventario.IdMedida;
            miInventario.IdColor = inventario.IdColor;
            if (!ComprobarInventario(miInventario, true))
            {
                InsertarInventario(miInventario);
            }
            var valorMedida = new ValorUnidadMedida();
            valorMedida.IdValorUnidadMedida = inventario.IdMedida;
            valorMedida.CodigoInternoProducto = inventario.CodigoProducto;
            if (!daoValorMedida.ComprobarMedidaProducto(valorMedida))
            {
                daoValorMedida.InsertarMedidaProducto(valorMedida);
            }
        }

        /// <summary>
        /// Comprueba la existencia de una relacion establecida de un Producto en el inventario.
        /// </summary>
        /// <param name="inventario">Inventario a comprobar.</param>
        /// <returns></returns>
        public bool ComprobarInventario(Inventario inventario, bool color)
        {
            try
            {
                CargarComandoStoredProcedure(sqlComprobar);
                miComando.Parameters.AddWithValue("producto", inventario.CodigoProducto);
                miComando.Parameters.AddWithValue("medida", inventario.IdMedida);
                if (color)
                {
                    miComando.Parameters.AddWithValue("color", inventario.IdColor);
                }
                miConexion.MiConexion.Open();
                var resultado = Convert.ToBoolean(miComando.ExecuteScalar());
                miConexion.MiConexion.Close();
                miComando.Dispose();
                return resultado;
            }
            catch (Exception ex)
            {
                throw new Exception(ErrorComprobar + ex.Message);
            }
            finally { miConexion.MiConexion.Close(); }
        }

        /// <summary>
        /// Comprueba si la relacion de inventario tiene cantidad superior a cero.
        /// </summary>
        /// <param name="inventario">Inventario a consultar.</param>
        /// <returns></returns>
        private bool ComprobarCantidadInventario(Inventario inventario)
        {
            try
            {
                CargarComandoStoredProcedure(sqlComprobarCant);
                miComando.Parameters.AddWithValue("codigo", inventario.CodigoProducto);
                miComando.Parameters.AddWithValue("medida", inventario.IdMedida);
                miComando.Parameters.AddWithValue("color", inventario.IdColor);
                miConexion.MiConexion.Open();
                var resultado = Convert.ToInt32(miComando.ExecuteScalar());
                miConexion.MiConexion.Close();
                miComando.Dispose();
                if (resultado == 0)
                    return true;
                else
                    return false;
            }
            catch (InvalidCastException ex)
            {
                throw new InvalidCastException(ex.Message);
            }
            finally { miConexion.MiConexion.Close(); }
        }

        /// <summary>
        /// Obtiene el listado de los registros de los productos a cruzar en inventario.
        /// </summary>
        /// <param name="registroBase">Registro base para la consulta.</param>
        /// <param name="registrosMaximos">Registros maximos a recuperar.</param>
        /// <returns></returns>
        public DataTable ProductoConCorte(int registroBase, int registrosMaximos)
        {
            var dataSet = new DataSet();
            try
            {
                CargarAdapterStoredProcedure(sqlProductoCorte);
                miAdapter.Fill(dataSet, registroBase, registrosMaximos, "producto_corte");
                return dataSet.Tables[0];
            }
            catch (Exception ex)
            {
                throw new Exception(ErrorProducto + ex.Message);
            }
        }

        /// <summary>
        /// Obtiene el total de registros de los productos a cruzar en inventario.
        /// </summary>
        /// <returns></returns>
        public long GetTotalRowProductoConCorte()
        {
            try
            {
                CargarComandoStoredProcedure(sqlTotalProductoCorte);
                miConexion.MiConexion.Open();
                var rows = Convert.ToInt64(miComando.ExecuteScalar());
                miConexion.MiConexion.Close();
                miComando.Dispose();
                return rows;
            }
            catch (Exception ex)
            {
                throw new Exception(ErrorProducto + ex.Message);
            }
        }

        /// <summary>
        ///  Obtiene el listado de los registros de los productos en inventario.
        /// </summary>
        /// <param name="registroBase">Registro base para la consulta.</param>
        /// <param name="registrosMaximos">Registros maximos a recuperar.</param>
        /// <returns></returns>
        public DataTable ConsultaProductoResumenInventario(int registroBase, int registrosMaximos)
        {
            var dataSet = new DataSet();
            try
            {
                CargarAdapterStoredProcedure(sqlProductoHistorial);
                miAdapter.Fill(dataSet, registroBase, registrosMaximos, "producto_historial");
                return dataSet.Tables[0];
            }
            catch (Exception ex)
            {
                throw new Exception(ErrorProducto + ex.Message);
            }
        }

        /// <summary>
        /// Obtiene el total de registros de los productos en inventario.
        /// </summary>
        /// <returns></returns>
        public long GetRowsConsultaProductoResumenInventario()
        {
            try
            {
                CargarComandoStoredProcedure(sqlTotalProductoHistorial);
                miConexion.MiConexion.Open();
                var rows = Convert.ToInt64(miComando.ExecuteScalar());
                miConexion.MiConexion.Close();
                miComando.Dispose();
                return rows;
            }
            catch (Exception ex)
            {
                throw new Exception(ErrorProducto + ex.Message);
            }
            finally { miConexion.MiConexion.Close(); }
        }

   // Consultas a Corte de Inventario.

        public DataTable Cortes()
        {
            try
            {
                var tabla = new DataTable();
                CargarAdapterStoredProcedure("cortes");
                miAdapter.Fill(tabla);
                return tabla;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al consultar las fechas de Corte.\n" + ex.Message);
            }
        }

        public DataTable TablaCorte()
        {
            try
            {
                var tabla = new DataTable();
                CargarAdapterStoredProcedure("tabla_corte");
                miAdapter.Fill(tabla);
                return tabla;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al consultar las fechas de Corte.\n" + ex.Message);
            }
        }

        /// <summary>
        /// Obtiene el listado de los registros de los productos a cruzar en inventario con sus cifras.
        /// </summary>
        /// <param name="orden">Establece el valor que indica el numero de orden de los registros.</param>
        /// <param name="registroBase">Registro base para la consulta.</param>
        /// <param name="registrosMaximos">Registro base para la consulta.</param>
        /// <returns></returns>
        public DataTable ConsultaCorteGeneral(int orden, int registroBase, int registrosMaximos)
        {
            var tabla = new DataTable();
            var miTabla = TablaInventario();
            try
            {
                switch (orden)
                {
                    case 1:
                        {
                            CargarAdapterStoredProcedure("lista_producto_corte_pendiente_categoria");
                            break;
                        }
                    case 2:
                        {
                            CargarAdapterStoredProcedure("lista_producto_corte_pendiente");
                            break;
                        }
                    case 3:
                        {
                            CargarAdapterStoredProcedure("lista_producto_corte_pendiente_nombre");
                            break;
                        }
                    case 4:
                        {
                            CargarAdapterStoredProcedure("lista_producto_corte_pendiente_nombre_desc");
                            break;
                        }
                }
                miAdapter.Fill(registroBase, registrosMaximos, tabla);
                foreach (DataRow row in tabla.Rows)
                {
                    var row_ = miTabla.NewRow();
                    var codigo = Convert.ToString(row["codigointernoproducto"]);
                    var idMedida = Convert.ToInt32(row["idvalor_unidad_medida"]);
                    var idColor = Convert.ToInt32(row["idcolor"]);
                    var color = new ElColor();
                    color.MapaBits = (string)row["stringcolor"];

                    var inventario = RegistroInventarioFisico(codigo, idMedida, idColor);
                    row_["Fecha"] = inventario.Fecha;

                    row_["Inventario"] = row["cantidad_inventario"];
                    row_["Fisico"] = inventario.Cantidad.ToString();
                    //row_["Diferencia"] = inventario.Cantidad - Convert.ToDouble(row["cantidad_inventario"]);
                    if (Convert.ToDouble(row["cantidad_inventario"]) < 0)
                    {
                        row_["Diferencia"] = inventario.Cantidad + Convert.ToDouble(row["cantidad_inventario"]);
                    }
                    else
                    {
                        row_["Diferencia"] = inventario.Cantidad - Convert.ToDouble(row["cantidad_inventario"]);
                    }

                    MiProducto = daoProducto.ProductoCompleto(codigo);

                    /**
                    double vIva = Math.Round((inventario.Costo * MiProducto.ValorIva / 100), 1);
                    row_["Costo"] = Convert.ToInt32(inventario.Costo + vIva);
                    */

                    row_["Costo"] = Convert.ToInt32(inventario.Costo);

                    row_["Subtotal"] = inventario.Cantidad * Convert.ToInt32(row_["Costo"]);
                    row_["Estado"] = true;

                    /*if (ComprobarRegistroInventarioFisico(codigo, idMedida, idColor))
                    {
                        var inventario = RegistroInventarioFisico(codigo, idMedida, idColor);
                        row_["Fecha"] = inventario.Fecha;
                        row_["Fisico"] = inventario.Cantidad.ToString();
                        row_["Costo"] = inventario.Costo;
                        row_["Subtotal"] = inventario.Cantidad * inventario.Costo;
                        row_["Estado"] = true;
                    }
                    else
                    {
                        row_["Fecha"] = DateTime.Now.ToShortDateString();
                        row_["Estado"] = false;
                    }*/

                    row_["Categoria"] = row["nombrecategoria"];
                    row_["Codigo"] = row["codigointernoproducto"];
                    row_["Nombre"] = row["nombreproducto"];
                    row_["Marca"] = row["nombremarca"];
                    row_["Unidad"] = row["descripcionunidad_medida"];
                    row_["Medida"] = row["descripcionvalor_unidad_medida"];
                    row_["Color"] = color.ImagenBit;
                   /* row_["Inventario"] = "---";
                    row_["Diferencia"] = "---";*/
                    miTabla.Rows.Add(row_);
                }
                return miTabla;
            }
            catch (Exception ex)
            {
                throw new Exception(ErrorProducto + ex.Message);
            }
        }

        /// <summary>
        ///  Obtiene el total de registros de los productos a cruzar en inventario.
        /// </summary>
        /// <returns></returns>
        public long GetRowsConsultaCorteGeneral()
        {
            try
            {
                CargarComandoStoredProcedure(sqlCountConsultaCorteGeneral);
                miConexion.MiConexion.Open();
                var rows = Convert.ToInt64(miComando.ExecuteScalar());
                miConexion.MiConexion.Close();
                miComando.Dispose();
                return rows;
            }
            catch (Exception ex)
            {
                throw new Exception(ErrorProducto + ex.Message);
            }
            finally { miConexion.MiConexion.Close(); }
        }

        public DataTable ConsultaCortePorCategoria(string categoria, int registroBase, int registrosMaximos)
        {
            try
            {
                var tabla = TablaInventario();
                var tablaTemp = new DataTable();
                CargarAdapterStoredProcedure("corte_por_categoria");
                miAdapter.SelectCommand.Parameters.AddWithValue("nombre", categoria);
                miAdapter.Fill(registroBase, registrosMaximos, tablaTemp);
                foreach (DataRow row in tablaTemp.Rows)
                {
                    var row_ = tabla.NewRow();
                    var codigo = Convert.ToString(row["codigointernoproducto"]);
                    var idMedida = Convert.ToInt32(row["idvalor_unidad_medida"]);
                    var idColor = Convert.ToInt32(row["idcolor"]);
                    var color = new ElColor();
                    color.MapaBits = (string)row["stringcolor"];

                    /*tabla.Columns.Add(new DataColumn("Inventario", typeof(double)));
                    tabla.Columns.Add(new DataColumn("Valor", typeof(int)));
                    tabla.Columns.Add(new DataColumn("Fisico", typeof(double)));
                    tabla.Columns.Add(new DataColumn("Diferencia", typeof(double)));*/

                    //  Actualización diferencia de inventario y fisico, cooperativa.  05 / 10 / 200
                    var inventario = RegistroInventarioFisico(codigo, idMedida, idColor);
                    row_["Fecha"] = inventario.Fecha;

                    row_["Inventario"] = row["cantidad_inventario"];
                    row_["Fisico"] = inventario.Cantidad.ToString();

                    if (Convert.ToDouble(row["cantidad_inventario"]) < 0)
                    {
                        row_["Diferencia"] = inventario.Cantidad + Convert.ToDouble(row["cantidad_inventario"]);
                    }
                    else
                    {
                        row_["Diferencia"] = inventario.Cantidad - Convert.ToDouble(row["cantidad_inventario"]);
                    }
                    //row_["Diferencia"] = inventario.Cantidad - Convert.ToDouble(row["cantidad_inventario"]);

                    MiProducto = daoProducto.ProductoCompleto(codigo);

                    /**
                    double vIva = Math.Round((inventario.Costo * MiProducto.ValorIva / 100), 1);
                    row_["Costo"] = Convert.ToInt32(inventario.Costo + vIva);
                    */

                    row_["Costo"] = Convert.ToInt32(inventario.Costo);

                    row_["Subtotal"] = inventario.Cantidad * Convert.ToInt32(row_["Costo"]);
                    row_["Estado"] = true;


                   /* if (ComprobarRegistroInventarioFisico(codigo, idMedida, idColor))
                    {
                        var inventario = RegistroInventarioFisico(codigo, idMedida, idColor);
                        row_["Fecha"] = inventario.Fecha;

                        row_["Inventario"] = row["cantidad_inventario"];
                        row_["Fisico"] = inventario.Cantidad.ToString();
                        row_["Diferencia"] = Convert.ToDouble(row["cantidad_inventario"]) - inventario.Cantidad;

                        MiProducto = daoProducto.ProductoCompleto(codigo);
                        //row_["Costo"] = inventario.Costo;
                        double vIva = Math.Round((inventario.Costo * MiProducto.ValorIva / 100), 1);
                        row_["Costo"] = Convert.ToInt32(inventario.Costo + vIva);
                        //row_["Subtotal"] = inventario.Cantidad * inventario.Costo;
                        row_["Subtotal"] = inventario.Cantidad * Convert.ToInt32(row_["Costo"]);
                        row_["Estado"] = true;
                    }
                    else
                    {
                        row_["Fecha"] = DateTime.Now.ToShortDateString();
                        //row_["Fisico"] = "---";
                        row_["Estado"] = false;
                    }*/
                    row_["Categoria"] = row["nombrecategoria"];
                    row_["Codigo"] = row["codigointernoproducto"];
                    row_["Nombre"] = row["nombreproducto"];
                    row_["Marca"] = row["nombremarca"];
                    row_["Unidad"] = row["descripcionunidad_medida"];
                    row_["Medida"] = row["descripcionvalor_unidad_medida"];
                    row_["Color"] = color.ImagenBit;
                    //row_["Inventario"] = "---";
                    //row_["Diferencia"] = "---";
                    tabla.Rows.Add(row_);
                }
                tablaTemp.Rows.Clear();
                tablaTemp = null;
                return tabla;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al consultar el Corte de Inventario.\n" + ex.Message + "\nProducto relacionado: " + this.CodigoProducto);
            }
        }

        public int GetRowsConsultaCortePorCategoria(string categoria)
        {
            try
            {
                CargarComandoStoredProcedure("count_corte_por_categoria");
                miComando.Parameters.AddWithValue("categoria", categoria);
                miConexion.MiConexion.Open();
                var rows = Convert.ToInt32(miComando.ExecuteScalar());
                miConexion.MiConexion.Close();
                miComando.Dispose();
                return rows;
            }
            catch (Exception ex)
            {
                throw new Exception(ErrorProducto + ex.Message);
            }
            finally { miConexion.MiConexion.Close(); }
        }

        public DataTable ConsultaPorCodigo(string codigo)
        {
            try
            {
                var tabla = new DataTable();
                CargarAdapterStoredProcedure("corte_por_codigo");
                miAdapter.SelectCommand.Parameters.AddWithValue("codigo", codigo);
                miAdapter.Fill(tabla);
                var miTabla = UnionDeTablas(tabla);
                tabla.Rows.Clear();
                tabla = null;
                return miTabla;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al consultar el Corte de Inventario.\n" + ex.Message);
            }
        }

        public DataTable ConsultaPorNombre(string nombre, int registroBase, int registrosMaximos)
        {
            try
            {
                var tabla = new DataTable();
                CargarAdapterStoredProcedure("corte_por_nombre");
                miAdapter.SelectCommand.Parameters.AddWithValue("nombre", nombre);
                miAdapter.Fill(registroBase, registrosMaximos, tabla);
                var miTabla = UnionDeTablas(tabla);
                tabla.Rows.Clear();
                tabla = null;
                return miTabla;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al consultar el Corte de Inventario.\n" + ex.Message);
            }
        }

        public int GetRowsConsultaPorNombre(string nombre)
        {
            try
            {
                CargarComandoStoredProcedure("count_corte_por_nombre");
                miComando.Parameters.AddWithValue("nombre", nombre);
                miConexion.MiConexion.Open();
                var rows = Convert.ToInt32(miComando.ExecuteScalar());
                miConexion.MiConexion.Close();
                miComando.Dispose();
                return rows;
            }
            catch (Exception ex)
            {
                throw new Exception(ErrorProducto + ex.Message);
            }
            finally { miConexion.MiConexion.Close(); }
        }

        public DataTable ConsultaPorCorte(int corte, int registroBase, int registrosMaximos)
        {
            try
            {
                var tabla = new DataTable();
                CargarAdapterStoredProcedure("lista_producto_corte_pendiente_categoria");
                miAdapter.Fill(registroBase, registrosMaximos, tabla);
                var miTabla = UnionDeTablas(tabla, corte);
                tabla.Rows.Clear();
                tabla = null;
                return miTabla;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al consultar el Corte de Inventario.\n" + ex.Message);
            }
        }

        public DataTable ConsultaPorCorte(int orden, int corte, int registroBase, int registrosMaximos)
        {
            try
            {
                //var tabla = ConsultaCorteGeneral(orden, registroBase, registrosMaximos);
                var tabla = new DataTable();
                switch (orden)
                {
                    case 1:
                        {
                            CargarAdapterStoredProcedure("lista_producto_corte_pendiente_categoria");
                            break;
                        }
                    case 2:
                        {
                            CargarAdapterStoredProcedure("lista_producto_corte_pendiente");
                            break;
                        }
                    case 3:
                        {
                            CargarAdapterStoredProcedure("lista_producto_corte_pendiente_nombre");
                            break;
                        }
                    case 4:
                        {
                            CargarAdapterStoredProcedure("lista_producto_corte_pendiente_nombre_desc");
                            break;
                        }
                }
                miAdapter.Fill(registroBase, registrosMaximos, tabla);

                var miTabla = UnionDeTablas(tabla, corte);
                tabla.Rows.Clear();
                tabla = null;
                return miTabla;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al consultar el Corte de Inventario.\n" + ex.Message);
            }
        }

        public DataTable PrintInformeCorte(int orden)
        {
            try
            {
                var tabla = new DataTable();
                switch (orden)
                {
                    case 1:
                        {
                            CargarAdapterStoredProcedure("lista_producto_corte_pendiente_categoria");
                            break;
                        }
                    case 2:
                        {
                            CargarAdapterStoredProcedure("lista_producto_corte_pendiente");
                            break;
                        }
                    case 3:
                        {
                            CargarAdapterStoredProcedure("lista_producto_corte_pendiente_nombre");
                            break;
                        }
                    case 4:
                        {
                            CargarAdapterStoredProcedure("lista_producto_corte_pendiente_nombre_desc");
                            break;
                        }
                }
                miAdapter.Fill(tabla);
                var miTabla = UnionDeTablas(tabla);
                tabla.Rows.Clear();
                tabla = null;
                return miTabla;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al consultar el Corte de Inventario.\n" + ex.Message);
            }
        }

        public DataTable PrintInformeCorte(int orden, int corte)
        {
            try
            {
                var tabla = new DataTable();
                switch (orden)
                {
                    case 1:
                        {
                            CargarAdapterStoredProcedure("lista_producto_corte_pendiente_categoria");
                            break;
                        }
                    case 2:
                        {
                            CargarAdapterStoredProcedure("lista_producto_corte_pendiente");
                            break;
                        }
                    case 3:
                        {
                            CargarAdapterStoredProcedure("lista_producto_corte_pendiente_nombre");
                            break;
                        }
                    case 4:
                        {
                            CargarAdapterStoredProcedure("lista_producto_corte_pendiente_nombre_desc");
                            break;
                        }
                }
                miAdapter.Fill(tabla);
                var miTabla = UnionDeTablas(tabla, corte);
                tabla.Rows.Clear();
                tabla = null;
                return miTabla;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al consultar el Corte de Inventario.\n" + ex.Message);
            }
        }

        private DataTable UnionDeTablas(DataTable tabla)
        {
            try
            {
                var miTabla = TablaInventario();
                foreach (DataRow row in tabla.Rows)
                {
                    var row_ = miTabla.NewRow();
                    var codigo = CodigoProducto = Convert.ToString(row["codigointernoproducto"]);
                    var idMedida = Convert.ToInt32(row["idvalor_unidad_medida"]);
                    var idColor = Convert.ToInt32(row["idcolor"]);
                    var color = new ElColor();
                    color.MapaBits = (string)row["stringcolor"];

                    //  Actualización diferencia de inventario y fisico, cooperativa.  05 / 10 / 2020
                    var inventario = RegistroInventarioFisico(codigo, idMedida, idColor);
                    row_["Fecha"] = inventario.Fecha;

                    row_["Inventario"] = row["cantidad_inventario"];
                    row_["Fisico"] = inventario.Cantidad.ToString();
                    //row_["Diferencia"] = inventario.Cantidad - Convert.ToDouble(row["cantidad_inventario"]);
                    if (Convert.ToDouble(row["cantidad_inventario"]) < 0)
                    {
                        row_["Diferencia"] = inventario.Cantidad + Convert.ToDouble(row["cantidad_inventario"]);
                    }
                    else
                    {
                        row_["Diferencia"] = inventario.Cantidad - Convert.ToDouble(row["cantidad_inventario"]);
                    }

                    MiProducto = daoProducto.ProductoCompleto(codigo);

                    /**double vIva = Math.Round((inventario.Costo * MiProducto.ValorIva / 100), 1);
                    row_["Costo"] = Convert.ToInt32(inventario.Costo + vIva);*/
                    row_["Costo"] = inventario.Costo;

                    row_["Subtotal"] = inventario.Cantidad * Convert.ToInt32(row_["Costo"]);
                    row_["Estado"] = true;

                    /*if (ComprobarRegistroInventarioFisico(codigo, idMedida, idColor))
                    {
                        var inventario = RegistroInventarioFisico(codigo, idMedida, idColor);
                        row_["Fecha"] = inventario.Fecha;
                        row_["Fisico"] = inventario.Cantidad.ToString();
                        //row_["Costo"] = inventario.Costo;
                        MiProducto = daoProducto.ProductoCompleto(codigo);
                        double vIva = Math.Round((inventario.Costo * MiProducto.ValorIva / 100), 1);
                        row_["Costo"] = Convert.ToInt32(inventario.Costo + vIva);
                        //row_["Subtotal"] = inventario.Cantidad * inventario.Costo;
                        row_["Subtotal"] = inventario.Cantidad * Convert.ToInt32(row_["Costo"]);
                        row_["Estado"] = true;
                    }
                    else
                    {
                        row_["Fecha"] = DateTime.Now.ToShortDateString();
                        //row_["Fisico"] = "---";
                        row_["Estado"] = false;
                    }*/
                    row_["Categoria"] = row["nombrecategoria"];
                    row_["Codigo"] = row["codigointernoproducto"];
                    row_["Nombre"] = row["nombreproducto"];
                    row_["Marca"] = row["nombremarca"];
                    row_["Unidad"] = row["descripcionunidad_medida"];
                    row_["Medida"] = row["descripcionvalor_unidad_medida"];
                    row_["Color"] = color.ImagenBit;
                    /*  row_["Inventario"] = "---";
                      row_["Diferencia"] = "---";*/
                    miTabla.Rows.Add(row_);
                }
                return miTabla;
            }
            catch (Exception)
            {
                throw new Exception("Producto relacionado: " + CodigoProducto + "\n");
            }
        }

        // Consulta e impresion de corte de inventario.
        private DataTable UnionDeTablas(DataTable tabla, int numeroCorte)
        {
            try
            {
                var miTabla = TablaInventario();
                foreach (DataRow row in tabla.Rows)
                {
                    var row_ = miTabla.NewRow();
                    var codigo = CodigoProducto = Convert.ToString(row["codigointernoproducto"]);

                    /*if (codigo == "16995")
                    {
                        var j_ = codigo;
                    }

                    if (codigo == "2428")
                    {
                        var j__ = codigo;
                    }*/

                    var idMedida = Convert.ToInt32(row["idvalor_unidad_medida"]);
                    var idColor = Convert.ToInt32(row["idcolor"]);
                    var color = new ElColor();
                    color.MapaBits = (string)row["stringcolor"];

                    //  Actualización diferencia de inventario y fisico, cooperativa.  05 / 10 / 2020
                    //var inventario = RegistroInventarioFisico(codigo, idMedida, idColor, numeroCorte);
                    var inventario = RegistroInventarioFisicoCorte(codigo, idMedida, idColor);
                    row_["Fecha"] = inventario.Fecha;

                    row_["Inventario"] = row["cantidad_inventario"];
                    row_["Fisico"] = inventario.Cantidad.ToString();
                    //row_["Diferencia"] = inventario.Cantidad - Convert.ToDouble(row["cantidad_inventario"]);
                    if (Convert.ToDouble(row["cantidad_inventario"]) < 0)
                    {
                        row_["Diferencia"] = inventario.Cantidad + Convert.ToDouble(row["cantidad_inventario"]);
                    }
                    else
                    {
                        row_["Diferencia"] = inventario.Cantidad - Convert.ToDouble(row["cantidad_inventario"]);
                    }

                    MiProducto = daoProducto.ProductoCompleto(codigo);
                    double vIva = Math.Round((inventario.Costo * MiProducto.ValorIva / 100), 2);
                    row_["Costo"] = Convert.ToInt32(inventario.Costo + vIva);
                    row_["Subtotal"] = inventario.Cantidad * Convert.ToInt32(row_["Costo"]);
                    row_["Estado"] = true;

                    /*if (ComprobarRegistroInventarioFisico(codigo, idMedida, idColor, numeroCorte))
                    {
                        var inventario = RegistroInventarioFisico(codigo, idMedida, idColor, numeroCorte);
                        row_["Fecha"] = inventario.Fecha;
                        row_["Fisico"] = inventario.Cantidad.ToString();
                        //row_["Costo"] = inventario.Costo;
                        MiProducto = daoProducto.ProductoCompleto(codigo);
                        double vIva = Math.Round((inventario.Costo * MiProducto.ValorIva / 100), 2);
                        row_["Costo"] = Convert.ToInt32(inventario.Costo + vIva);
                        //row_["Subtotal"] = inventario.Cantidad * inventario.Costo;
                        row_["Subtotal"] = inventario.Cantidad * Convert.ToInt32(row_["Costo"]);
                        row_["Estado"] = true;
                    }
                    else
                    {//Costo
                        row_["Fecha"] = DateTime.Now.ToShortDateString();
                        //row_["Fisico"] = "---";
                        row_["Estado"] = false;
                    }*/
                    row_["Categoria"] = row["nombrecategoria"];
                    row_["Codigo"] = row["codigointernoproducto"];
                    row_["Nombre"] = row["nombreproducto"];
                    row_["Marca"] = row["nombremarca"];
                    row_["Unidad"] = row["descripcionunidad_medida"];
                    row_["Medida"] = row["descripcionvalor_unidad_medida"];
                    row_["Color"] = color.ImagenBit;
                    /*row_["Inventario"] = "---";
                    row_["Diferencia"] = "---";*/
                    miTabla.Rows.Add(row_);
                }
                return miTabla;
            }
            catch (Exception)
            {
                throw new Exception("Producto relacionado: " + CodigoProducto + "\n");
            }
        }



        /// <summary>
        /// Comprueba la la existencia del registro en Inventario Fisico.
        /// </summary>
        /// <param name="codigo">Codigo del Producto a consultar</param>
        /// <param name="idMedida">Id de la Medida a consultar.</param>
        /// <param name="idColor">Id del color a consultar.</param>
        /// <returns></returns>
        private bool ComprobarRegistroInventarioFisico
            (string codigo, int idMedida, int idColor)
        {
            try
            {
                CargarComandoStoredProcedure("comprobar_registro_inventario_fisico");
                miComando.Parameters.AddWithValue("codigo", codigo);
                miComando.Parameters.AddWithValue("medida", idMedida);
                miComando.Parameters.AddWithValue("color", idColor);
                miConexion.MiConexion.Open();
                var resultado = Convert.ToBoolean(miComando.ExecuteScalar());
                miConexion.MiConexion.Close();
                miComando.Dispose();
                return resultado;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally { miConexion.MiConexion.Close(); }
        }

        private bool ComprobarRegistroInventarioFisico
            (string codigo, int idMedida, int idColor, int numeroCorte)
        {
            try
            {
                CargarComandoStoredProcedure("comprobar_registro_inventario_fisico");
                miComando.Parameters.AddWithValue("codigo", codigo);
                miComando.Parameters.AddWithValue("medida", idMedida);
                miComando.Parameters.AddWithValue("color", idColor);
                miComando.Parameters.AddWithValue("corte", numeroCorte);
                miConexion.MiConexion.Open();
                var resultado = Convert.ToBoolean(miComando.ExecuteScalar());
                miConexion.MiConexion.Close();
                miComando.Dispose();
                return resultado;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally { miConexion.MiConexion.Close(); }
        }

        /// <summary>
        /// Obtiene un registro de Inventario Fisico.
        /// </summary>
        /// <param name="codigo">Codigo del Producto a consultar.</param>
        /// <param name="idMedida">Id de la Medida a consultar.</param>
        /// <param name="idColor">Id del Color a Consultar.</param>
        /// <returns></returns>
        private InventarioFisico RegistroInventarioFisico
            (string codigo, int idMedida, int idColor)
        {
            try
            {
                CargarComandoStoredProcedure("registro_producto_inventario_fisico");
                miComando.Parameters.AddWithValue("codigo", codigo);
                miComando.Parameters.AddWithValue("medida", idMedida);
                miComando.Parameters.AddWithValue("color", idColor);
                miConexion.MiConexion.Open();
                NpgsqlDataReader miReader = miComando.ExecuteReader();
                var inventario = new InventarioFisico();
                while (miReader.Read())
                {
                    inventario.Fecha = miReader.GetDateTime(1);
                    inventario.Cantidad = miReader.GetDouble(5);
                    inventario.Costo = miReader.GetDouble(8);
                }
                miConexion.MiConexion.Close();
                miComando.Dispose();
                return inventario;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally { miConexion.MiConexion.Close(); }
        }

        private InventarioFisico RegistroInventarioFisicoCorte 
            (string codigo, int idMedida, int idColor)
        {
            try
            {
                CargarComandoStoredProcedure("registro_producto_inventario_fisico_corte");
                miComando.Parameters.AddWithValue("codigo", codigo);
                miComando.Parameters.AddWithValue("medida", idMedida);
                miComando.Parameters.AddWithValue("color", idColor);
                miConexion.MiConexion.Open();
                NpgsqlDataReader miReader = miComando.ExecuteReader();
                var inventario = new InventarioFisico();
                while (miReader.Read())
                {
                    inventario.Fecha = miReader.GetDateTime(1);
                    inventario.Cantidad = miReader.GetDouble(5);
                    inventario.Costo = miReader.GetDouble(8);
                }
                miConexion.MiConexion.Close();
                miComando.Dispose();
                return inventario;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally { miConexion.MiConexion.Close(); }
        }

        private InventarioFisico RegistroInventarioFisico
            (string codigo, int idMedida, int idColor, int numeroCorte)
        {
            try
            {
                CargarComandoStoredProcedure("registro_producto_inventario_fisico");
                miComando.Parameters.AddWithValue("codigo", codigo);
                miComando.Parameters.AddWithValue("medida", idMedida);
                miComando.Parameters.AddWithValue("color", idColor);
                miComando.Parameters.AddWithValue("corte", numeroCorte);
                miConexion.MiConexion.Open();
                NpgsqlDataReader miReader = miComando.ExecuteReader();
                var inventario = new InventarioFisico();
                while (miReader.Read())
                {
                    inventario.Fecha = miReader.GetDateTime(1);
                    inventario.Cantidad = miReader.GetDouble(5);
                    inventario.Costo = miReader.GetDouble(8);
                }
                miConexion.MiConexion.Close();
                miComando.Dispose();
                return inventario;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally { miConexion.MiConexion.Close(); }
        }

   // End Consultas a Corte de Inventario.
        //string code = "";
        /// <summary>
        /// Realiza el cruce entre el inventario ingresado y el inventario de sistema.
        /// </summary>
        /// <param name="inventarioSistema">Indica si continua con las cifras de cantidad del sistema.</param>
        /// <param name="fecha">Fecha en que se realiza el cruce</param>
        public void CruzarInventario(bool nivelaCero, bool inventarioSistema, DateTime fecha)
        {
            string code = "";
            try
            {
                
                try
                {
                    var tInventarios = ConsultaInventarioBasic();
                    var tInventarioFisico = CorteInventario();
                    var resumneInv = new ResumenInventario();
                    foreach (DataRow Irow in tInventarios.Rows)
                    {
                        var resumen = new ResumenInventario();
                        resumen.Fecha = fecha;
                        code = resumen.CodigoProducto = Irow["codigointernoproducto"].ToString();

                        /*this.code = resumen.CodigoProducto;
                        if (this.code == "6349")
                        {
                            var j = this.code;
                        }*/

                        resumen.IdMedida = Convert.ToInt32(Irow["idvalor_unidad_medida"]);
                        resumen.IdColor = Convert.ToInt32(Irow["idcolor"]);
                        resumen.Cantidad = Convert.ToDouble(Irow["cantidad_inventario"]);
                        var IQrow = tInventarioFisico.AsEnumerable().
                            Where(d => d.Field<string>("codigointernoproducto").Equals(Irow["codigointernoproducto"].ToString()) &&
                                       d.Field<int>("idvalor_unidad_medida").Equals(Convert.ToInt32(Irow["idvalor_unidad_medida"])) &&
                                       d.Field<int>("idcolor").Equals(Convert.ToInt32(Irow["idcolor"])));
                        double valorIva = 0.0;
                        if (IQrow.ToArray().Length != 0/*inventarioFisico.Rows.Count != 0*/)
                        {
                            var fRow = IQrow.AsEnumerable().First();
                            if (!inventarioSistema)
                            {
                                ActualizarInventario(Convert.ToInt32(Irow["id_inventario"]),
                                                     Convert.ToDouble(fRow["cantidad_inventario_fisico"]));
                            }
                            resumen.CantidadFisico = Convert.ToDouble(fRow["cantidad_inventario_fisico"]);
                            resumen.ValorProducto = Convert.ToInt32(fRow["valorventaproducto"]);
                            //valorIva = Convert.ToDouble(fRow["valoriva"]);
                            ActualizarInventarioFisico(Convert.ToInt32(fRow["id_inventario_fisico"]));
                        }
                        else
                        {
                            if (nivelaCero)
                            {
                                ActualizarInventario(Convert.ToInt32(Irow["id_inventario"]), 0);
                            }
                           /*resumen.ValorProducto = Convert.ToInt32(ConsultarProducto
                                                    (resumen.CodigoProducto).AsEnumerable().First()["valorventaproducto"]);*/
                            resumen.ValorProducto = Convert.ToInt32(daoProducto.PrecioDeCosto(resumen.CodigoProducto));
                        }
                        var cant = resumen.Cantidad;
                        if (resumen.Cantidad < 0)
                        {
                            cant = resumen.Cantidad * -1;
                        }
                        //resumen.CantidadResumen = resumen.CantidadFisico - cant;
                        resumen.CantidadResumen = resumen.CantidadFisico;
                        IngresarResumenInventario(resumen);

                        // Kardex.
                        Kardex.Codigo = resumen.CodigoProducto;
                        Kardex.IdUsuario = Convert.ToInt32(AppConfiguracion.ValorSeccion("id_user"));
                        if (resumen.CantidadResumen < 0)  // Cant Negativa
                        {
                            Kardex.IdConcepto = 13;
                        }
                        else  // Cant Positiva
                        {
                            Kardex.IdConcepto = 4;
                        }
                        Kardex.Fecha = DateTime.Now;
                        Kardex.Cantidad = resumen.CantidadResumen;
                        double iva = Math.Round((resumen.ValorProducto * valorIva / 100), 2);
                        Kardex.Valor = resumen.ValorProducto + Convert.ToInt32(iva);
                        if (Kardex.Cantidad  > 0)
                        {
                            miDaoKardex.Insertar(Kardex);
                        }
                    }
                    CargarComandoStoredProcedure("insertar_corte");
                    miComando.Parameters.AddWithValue("numero", miDaoConsecutivo.Consecutivo("ConsCorte"));
                    miComando.Parameters.AddWithValue("fecha", fecha);
                    miConexion.MiConexion.Open();
                    miComando.ExecuteNonQuery();
                    miConexion.MiConexion.Close();
                    miComando.Dispose();
                    miDaoConsecutivo.ActualizarConsecutivo("ConsCorte");
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message + "\nError en producto con codigo: " + code);
            }
            finally { miConexion.MiConexion.Close(); }
        }

        /// <summary>
        /// Obtiene el listado de los registros de producto por cruzar en inventario.
        /// </summary>
        /// <returns></returns>
        private DataTable CorteInventario()
        {
            var tabla = new DataSets.DsInventarios.view_corte_inventario_fisicoDataTable();
            try
            {
                CargarAdapterStoredProcedure(sqlCorteInventarioFisico);
                miAdapter.Fill(tabla);
                return tabla;
            }
            catch (Exception ex)
            {
                throw new Exception(ErrorProducto + ex.Message);
            }
        }

        /// <summary>
        /// Obtiene el listado de los registros de producto en inventario.
        /// </summary>
        /// <param name="inventario">Inventario a consultar.</param>
        /// <returns></returns>
        private DataTable ConsultaInventario(Inventario inventario)
        {
            var tabla = new DataSets.DsInventarios.view_inventarioDataTable();
            try
            {
                CargarAdapterStoredProcedure(sqlConsultaInventario);
                miAdapter.SelectCommand.Parameters.AddWithValue("codigo", inventario.CodigoProducto);
                miAdapter.SelectCommand.Parameters.AddWithValue("medida", inventario.IdMedida);
                miAdapter.SelectCommand.Parameters.AddWithValue("color", inventario.IdColor);
                miAdapter.Fill(tabla);
                return tabla;
            }
            catch (Exception ex)
            {
                throw new Exception(ErrorProducto + ex.Message);
            }
        }
        
        /// <summary>
        /// Ingresa un registro del resumen de inventario en la base de datos.
        /// </summary>
        /// <param name="inventario">Registro de inventario a ingresar.</param>
        private void IngresarResumenInventario(ResumenInventario inventario)
        {
            try
            {
                var tabla = ResumenInventario
                    (inventario.Fecha, inventario.CodigoProducto, inventario.IdMedida, inventario.IdColor);
                if (tabla.Rows.Count > 0)
                {
                    foreach (DataRow row in tabla.Rows)
                    {
                        EliminarResumenInventario(Convert.ToInt32(row["id_resumen"]));
                    }
                }
                CargarComandoStoredProcedure(sqlInsertarResumenInventario);
                miComando.Parameters.AddWithValue("fecha", inventario.Fecha);
                miComando.Parameters.AddWithValue("producto", inventario.CodigoProducto);
                miComando.Parameters.AddWithValue("medida", inventario.IdMedida);
                miComando.Parameters.AddWithValue("color", inventario.IdColor);
                miComando.Parameters.AddWithValue("cantidad", inventario.Cantidad);
                miComando.Parameters.AddWithValue("fisico", inventario.CantidadFisico);
                miComando.Parameters.AddWithValue("resumen", inventario.CantidadResumen);
                miComando.Parameters.AddWithValue("valor", inventario.ValorProducto);
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

        /// <summary>
        /// Actualiza la cantidad del inventario en la base de datos.
        /// </summary>
        /// <param name="id">Id del registro de inventario a actualziar.</param>
        /// <param name="cantidad">Cantidad a actualizar en inventario.</param>
        private void ActualizarInventario(int id, double cantidad)
        {
            try
            {
                CargarComandoStoredProcedure(sqlEditarInventario);
                miComando.Parameters.AddWithValue("id", id);
                miComando.Parameters.AddWithValue("cantidad", cantidad);
                miConexion.MiConexion.Open();
                miComando.ExecuteNonQuery();
                miConexion.MiConexion.Close();
                miComando.Dispose();
            }
            catch (Exception ex)
            {
                throw new Exception(ErrorActualizar + ex.Message);
            }
            finally { miConexion.MiConexion.Close(); }
        }

        /// <summary>
        /// Actualiza el color del inventario de un producto en la base de datos.
        /// </summary>
        /// <param name="inventario">Inventario a actualizar.</param>
        public void ActualizarInventario(Inventario inventario)
        {
            try
            {
                CargarComandoStoredProcedure(sqlEditarInventario);
                miComando.Parameters.AddWithValue("producto", inventario.CodigoProducto);
                miComando.Parameters.AddWithValue("idMedida", inventario.IdMedida);
                miComando.Parameters.AddWithValue("idColor", inventario.IdColor);
                miComando.Parameters.AddWithValue("idColorN", inventario.Id);
                miConexion.MiConexion.Open();
                miComando.ExecuteNonQuery();
                miConexion.MiConexion.Close();
                miComando.Dispose();
            }
            catch (Exception ex)
            {
                throw new Exception(ErrorActualizar + ex.Message);
            }
            finally { miConexion.MiConexion.Close(); }
        }

        /// <summary>
        /// Actualzia el registro de corte de inventario en true.
        /// </summary>
        /// <param name="id">Id del registro a actualizar.</param>
        private void ActualizarInventarioFisico(int id)
        {
            try
            {
                CargarComandoStoredProcedure(sqlEditarInventarioFisico);
                miComando.Parameters.AddWithValue("id", id);
                miConexion.MiConexion.Open();
                miComando.ExecuteNonQuery();
                miConexion.MiConexion.Close();
                miComando.Dispose();
            }
            catch (Exception ex)
            {
                throw new Exception(ErrorActualizar + ex.Message);
            }
            finally { miConexion.MiConexion.Close(); }
        }

        private void ActualizarInventarioFisico(int id, double cantidad)
        {
            try
            {
                CargarComandoStoredProcedure("editar_inventario_fisico");
                miComando.Parameters.AddWithValue("id", id);
                miComando.Parameters.AddWithValue("cantidad", cantidad);
                miConexion.MiConexion.Open();
                miComando.ExecuteNonQuery();
                miConexion.MiConexion.Close();
                miComando.Dispose();
            }
            catch (Exception ex)
            {
                throw new Exception(ErrorActualizar + ex.Message);
            }
            finally { miConexion.MiConexion.Close(); }
        }

        public void ActualizarMedidaInventario(string codigo, int idMedida)
        {
            try
            {
                string sql = "update inventario set idvalor_unidad_medida = @idMedida where codigointernoproducto = @codigo;";
                CargarComandoText(sql);
                miComando.Parameters.AddWithValue("codigo", codigo);
                miComando.Parameters.AddWithValue("idMedida", idMedida);
                miConexion.MiConexion.Open();
                miComando.ExecuteNonQuery();
                miConexion.MiConexion.Close();
                miComando.Dispose();
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al editar la medida.\n" + ex.Message);
            }
            finally { miConexion.MiConexion.Close(); }
        }

        /// <summary>
        /// Actualiza el inventario con las cantidades fisicas ingresadas y nivelando a cero las no ingresadas
        /// </summary>
        /// <param name="fecha"></param>
        private void ActualizaCeroConInventarioFisico(bool nivel, bool invSistema, DateTime fecha)
        {
            try
            {
                var tInventarios = ConsultaInventarioBasic();
                var tInventarioFisico = CorteInventario();
                var resumneInv = new ResumenInventario();
                foreach (DataRow Irow in tInventarios.Rows)
                {
                    var resumen = new ResumenInventario();
                    resumen.Fecha = fecha;
                    resumen.CodigoProducto = Irow["codigointernoproducto"].ToString();
                    resumen.IdMedida = Convert.ToInt32(Irow["idvalor_unidad_medida"]);
                    resumen.IdColor = Convert.ToInt32(Irow["idcolor"]);
                    resumen.Cantidad = Convert.ToDouble(Irow["cantidad_inventario"]);
                    var IQrow = tInventarioFisico.AsEnumerable().
                        Where(d => d.Field<string>("codigointernoproducto").Equals(Irow["codigointernoproducto"].ToString()) &&
                                   d.Field<int>("idvalor_unidad_medida").Equals(Convert.ToInt32(Irow["idvalor_unidad_medida"])) &&
                                   d.Field<int>("idcolor").Equals(Convert.ToInt32(Irow["idcolor"])));
                    if (IQrow.ToArray().Length != 0/*inventarioFisico.Rows.Count != 0*/)
                    {
                        var fRow = IQrow.AsEnumerable().First();
                        if (!invSistema)
                        {
                            ActualizarInventario(Convert.ToInt32(Irow["id_inventario"]),
                                                 Convert.ToDouble(fRow["cantidad_inventario_fisico"]));
                        }
                        resumen.CantidadFisico = Convert.ToDouble(fRow["cantidad_inventario_fisico"]);
                        resumen.ValorProducto = Convert.ToInt32(fRow["valorventaproducto"]);
                        ActualizarInventarioFisico(Convert.ToInt32(fRow["id_inventario_fisico"]));
                    }
                    else
                    {
                        if (nivel)
                        {
                            ActualizarInventario(Convert.ToInt32(Irow["id_inventario"]), 0);
                        }
                        resumen.ValorProducto = Convert.ToInt32(ConsultarProducto
                                                (resumen.CodigoProducto).AsEnumerable().First()["valorventaproducto"]);
                    }
                    resumen.CantidadResumen = resumen.CantidadFisico - resumen.Cantidad;
                    IngresarResumenInventario(resumen);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Obtiene el registro de producto en cuestion
        /// </summary>
        /// <param name="codigo">Codigo del producto a consultar.</param>
        /// <returns></returns>
        public DataTable ConsultarProducto(string codigo)
        {
            var tabla = new DataTable();
            try
            {
                CargarAdapterStoredProcedure(sqlProductoMarca);
                miAdapter.SelectCommand.Parameters.AddWithValue("codigo", codigo);
                miAdapter.Fill(tabla);
                return tabla;
            }
            catch (Exception ex)
            {
                throw new Exception(ErrorProducto + ex.Message);
            }
        }

        /// <summary>
        /// Obtiene los registro de los productos en una Categoria.
        /// </summary>
        /// <param name="codigo">Codigo de la Categoria.</param>
        /// <param name="registroBase">Registro base para la consulta.</param>
        /// <param name="registrosMaximos">Numero de registros a recuperar.</param>
        /// <returns></returns>
        public DataTable ConsultaProductoPorCategoria
            (string codigo, int registroBase, int registrosMaximos)
        {
            var dataSet = new DataSet();
            try
            {
                CargarAdapterStoredProcedure(sqlProductoCategoria);
                miAdapter.SelectCommand.Parameters.AddWithValue("codigo", codigo);
                miAdapter.Fill
                    (dataSet, registroBase, registrosMaximos, "producto_basico");
                return dataSet.Tables[0];
            }
            catch (Exception ex)
            {
                throw new Exception(ErrorProducto + ex.Message);
            }
        }

        /// <summary>
        /// Obtiene el total de registros de producto en una consulta.
        /// </summary>
        /// <returns></returns>
        public long GetTotalRowProducto(string codigo)
        {
            try
            {
                CargarComandoStoredProcedure(sqlTotalRegistrosProducto);
                miComando.Parameters.AddWithValue("codigo", codigo);
                miConexion.MiConexion.Open();
                var rows = Convert.ToInt64(miComando.ExecuteScalar());
                miConexion.MiConexion.Close();
                miComando.Dispose();
                return rows;
            }
            catch (Exception ex)
            {
                throw new Exception(ErrorProducto + ex.Message);
            }
            finally
            { miConexion.MiConexion.Close(); }
        }

        public DataTable ConsultarInventarioFisico(string codigo, int idMedida, int idColor, bool corte)
        {
            var tabla = new DataTable();
            try
            {
                CargarAdapterStoredProcedure("inventarios_fisico");
                miAdapter.SelectCommand.Parameters.AddWithValue("codigo", codigo);
                miAdapter.SelectCommand.Parameters.AddWithValue("medida", idMedida);
                miAdapter.SelectCommand.Parameters.AddWithValue("color", idColor);
                miAdapter.SelectCommand.Parameters.AddWithValue("corte", corte);
                miAdapter.Fill(tabla);
                return tabla;
            }
            catch (Exception ex)
            {
                throw new Exception(ErrorProducto + ex.Message);
            }
        }

        /// <summary>
        /// Obtiene los registros de producto en inventario fisico.
        /// </summary>
        /// <param name="codigo">Codigo del producto a consultar.</param>
        /// <param name="registroBase">Registros base para la consulta.</param>
        /// <param name="registrosMaximos">Número de registros a recuperar.</param>
        /// <returns></returns>
        public DataTable ConsultarInventarioFisico
            (string codigo, int registroBase, int registrosMaximos)
        {
            var dataSet = new DataSet();
            try
            {
                CargarAdapterStoredProcedure(sqlConsultaFisico);
                miAdapter.SelectCommand.Parameters.AddWithValue("codigo", codigo);
                miAdapter.Fill
                    (dataSet, registroBase, registrosMaximos, "inventario_fisico");
                return dataSet.Tables[0];
            }
            catch (Exception ex)
            {
                throw new Exception(ErrorProducto + ex.Message);
            }
        }

        /// <summary>
        /// Obtiene el total de registro de una consulta de producto en inventario fisico.
        /// </summary>
        /// <param name="codigo">Codigo del Producto a consultar.</param>
        /// <returns></returns>
        public long GetTotalRowCorteInventario(string codigo)
        {
            try
            {
                CargarComandoStoredProcedure(sqlTotalCorteInventario);
                miComando.Parameters.AddWithValue("codigo", codigo);
                miConexion.MiConexion.Open();
                var rows = Convert.ToInt64(miComando.ExecuteScalar());
                miConexion.MiConexion.Close();
                miComando.Dispose();
                return rows;
            }
            catch (Exception ex)
            {
                throw new Exception(ErrorProducto + ex.Message);
            }
            finally
            { miConexion.MiConexion.Close(); }
        }

        /// <summary>
        /// Obtiene los registros de producto en inventario fisico.
        /// </summary>
        /// <param name="codigo">Codigo del producto a consultar.</param>
        /// <param name="registroBase">Registros base para la consulta.</param>
        /// <param name="registrosMaximos">Número de registros a recuperar.</param>
        /// <returns></returns>
        public DataTable ConsultarInventarioFisicoNoColor
            (string codigo, int registroBase, int registrosMaximos)
        {
            var dataSet = new DataSet();
            try
            {
                CargarAdapterStoredProcedure(sqlConsultaInventarioFisicoNoColor);
                miAdapter.SelectCommand.Parameters.AddWithValue("codigo", codigo);
                miAdapter.Fill
                    (dataSet, registroBase, registrosMaximos, "inventario_fisico");
                return dataSet.Tables[0];
            }
            catch (Exception ex)
            {
                throw new Exception(ErrorProducto + ex.Message);
            }
        }

        /// <summary>
        /// Obtiene el total de registro de una consulta de producto en inventario fisico.
        /// </summary>
        /// <param name="codigo">Codigo del Producto a consultar.</param>
        /// <returns></returns>
        public long GetRowsInventarioFisicoNoColor(string codigo)
        {
            try
            {
                CargarComandoStoredProcedure(sqlTotalInventarioFisicoNoColor);
                miComando.Parameters.AddWithValue("codigo", codigo);
                miConexion.MiConexion.Open();
                var rows = Convert.ToInt64(miComando.ExecuteScalar());
                miConexion.MiConexion.Close();
                miComando.Dispose();
                return rows;
            }
            catch (Exception ex)
            {
                throw new Exception(ErrorProducto + ex.Message);
            }
            finally { miConexion.MiConexion.Close(); }
        }

        /*public DataTable ConsultaResumenInventario()
        {
            var tabla = new DataTable();
            try
            {
                CargarAdapterStoredProcedure("resumen_inventario_todo_r");
                miAdapter.Fill(tabla);
                return tabla;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }*/

    // Consulta Resumen de Inventario.

        /// <summary>
        /// Obtiene el listado de los registros de los productos cruzados en inventario con sus cifras.
        /// </summary>
        /// <param name="orden">Establece el valor que indica el numero de orden de los registros.</param>
        /// <param name="registroBase">Registro base para la consulta.</param>
        /// <param name="registrosMaximos">Registro base para la consulta.</param>
        /// <returns></returns>
        public DataTable ConsultaResumenInventario(int orden, int registroBase, int registrosMaximos)
        {
            var dataSet = new DataSet();
            var miTabla = TablaInventario();
            try
            {
                switch (orden)
                {
                    case 1:
                        {
                            CargarAdapterStoredProcedure("lista_producto_resumen_inventario_categoria"); // orden por categoria asc
                            break;
                        }
                    case 2:
                        {
                            CargarAdapterStoredProcedure("lista_producto_resumen_inventario"); // orden por codigo asc
                            break;
                        }
                    case 3:
                        {
                            CargarAdapterStoredProcedure("lista_producto_resumen_inventario_nombre"); // orden por nombre asc
                            break;
                        }
                    case 4:
                        {
                            CargarAdapterStoredProcedure("lista_producto_resumen_inventario_nombre_desc"); // orden por nombre desc
                            break;
                        }
                }
                /*if (orden == 1)
                {
                    
                }
                else
                {
                    if (orden == 2)
                    {
                        CargarAdapterStoredProcedure("lista_producto_resumen_inventario_nombre"); // orden por nombre asc
                    }
                    else
                    {
                        CargarAdapterStoredProcedure("lista_producto_resumen_inventario_nombre_desc"); // orden por nombre desc
                    }
                }*/
                miAdapter.Fill(dataSet, registroBase, registrosMaximos, "inventario");
                miTabla = LoadTable(dataSet.Tables[0]);
                dataSet.Tables[0].Rows.Clear();
                dataSet.Tables.Clear();
                dataSet = null;
                /*foreach (DataRow row in dataSet.Tables[0].Rows)
                {
                    var row_ = miTabla.NewRow();
                    var color = new ElColor();
                    color.MapaBits = (string)row["stringcolor"];
                    row_["Codigo"] = row["codigointernoproducto"];
                    row_["Nombre"] = row["nombreproducto"];
                    row_["Marca"] = row["nombremarca"];
                    row_["Fecha"] = row["fecha_resumen"];
                    row_["Unidad"] = row["descripcionunidad_medida"];
                    row_["Medida"] = row["descripcionvalor_unidad_medida"];
                    row_["Color"] = color.ImagenBit;
                    row_["Inventario"] = row["cantidad_inventario"];
                    row_["Fisico"] = row["cantidad_inventario_fisico"];
                    row_["Diferencia"] = row["cantidad_resumen"];
                    row_["Costo"] = row["valorproducto"];
                    row_["Subtotal"] = row["subtotal"];
                    miTabla.Rows.Add(row_);
                }*/
                return miTabla;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al consultar el Resultado de Inventario.\n" + ex.Message);
            }
        }

        public DataTable ConsultaResumenInventario(int registroBase, int registrosMaximos)
        {
            var tabla = new DataTable();
            var miTabla = TablaInventario();
            try
            {
                CargarAdapterStoredProcedure("resumen_inventario_todo");
                miAdapter.Fill(registroBase, registrosMaximos, tabla);
                foreach (DataRow row in tabla.Rows)
                {
                    var row_ = miTabla.NewRow();
                    var color = new ElColor();
                    color.MapaBits = (string)row["stringcolor"];
                    row_["Codigo"] = row["codigointernoproducto"];
                    row_["Nombre"] = row["nombreproducto"];
                    row_["Marca"] = row["nombremarca"];
                    row_["Fecha"] = row["fecha_resumen"];
                    row_["Unidad"] = row["descripcionunidad_medida"];
                    row_["Medida"] = row["descripcionvalor_unidad_medida"];
                    row_["Color"] = color.ImagenBit;
                    row_["Inventario"] = row["cantidad_inventario"];
                    row_["Fisico"] = row["cantidad_inventario_fisico"];
                    row_["Diferencia"] = row["cantidad_resumen"];
                    miTabla.Rows.Add(row_);
                }
                return miTabla;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al consultar el Resultado de Inventario.\n" + ex.Message);
            }
        }

        /// <summary>
        /// Obtiene el total de registros de Resumen de Inventario.
        /// </summary>
        /// <returns></returns>
        public long GetRowsConsultaResumenInventario()
        {
            try
            {
                CargarComandoStoredProcedure("count_lista_producto_resumen_inventario");
                miConexion.MiConexion.Open();
                var rows = Convert.ToInt64(miComando.ExecuteScalar());
                miConexion.MiConexion.Close();
                miComando.Dispose();
                return rows;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally { miConexion.MiConexion.Close(); }
        }

        public DataTable ConsultaResumenInventario(string codigo )//, int registroBase, int registrosMaximos)
        {
            var tabla = new DataTable();
            //var miTabla = TablaInventario();
            try
            {
                CargarAdapterStoredProcedure("resumen_inventario_todo");
                miAdapter.SelectCommand.Parameters.AddWithValue("codigo", codigo);
                miAdapter.Fill(/*registroBase, registrosMaximos, */tabla);
                return LoadTable(tabla);
                /*foreach (DataRow row in tabla.Rows)
                {
                    var row_ = miTabla.NewRow();
                    var color = new ElColor();
                    color.MapaBits = (string)row["stringcolor"];
                    row_["Codigo"] = row["codigointernoproducto"];
                    row_["Nombre"] = row["nombreproducto"];
                    row_["Marca"] = row["nombremarca"];
                    row_["Fecha"] = row["fecha_resumen"];
                    row_["Unidad"] = row["descripcionunidad_medida"];
                    row_["Medida"] = row["descripcionvalor_unidad_medida"];
                    row_["Color"] = color.ImagenBit;
                    row_["Inventario"] = row["cantidad_inventario"];
                    row_["Fisico"] = row["cantidad_inventario_fisico"];
                    row_["Diferencia"] = row["cantidad_resumen"];
                    miTabla.Rows.Add(row_);
                }
                return miTabla;*/
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al consultar el Resultado de Inventario.\n" + ex.Message);
            }
        }

        public DataTable ConsultaResumenInventarioCategoria(string categoria, int registroBase, int registrosMaximos)
        {
            var tabla = new DataTable();
            try
            {
                CargarAdapterStoredProcedure("resumen_inventario_categoria");
                miAdapter.SelectCommand.Parameters.AddWithValue("categoria", categoria);
                miAdapter.Fill(registroBase, registrosMaximos, tabla);
                var table = LoadTable(tabla);
                tabla.Rows.Clear();
                tabla = null;
                return table;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al consultar el Resultado de Inventario.\n" + ex.Message);
            }
        }

        public int GetRowsConsultaResumenInventarioCategoria(string categoria)
        {
            try
            {
                CargarComandoStoredProcedure("count_resumen_inventario_categoria");
                miComando.Parameters.AddWithValue("categoria", categoria);
                miConexion.MiConexion.Open();
                var rows = Convert.ToInt32(miComando.ExecuteScalar());
                miConexion.MiConexion.Close();
                miComando.Dispose();
                return rows;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally { miConexion.MiConexion.Close(); }
        }

        public DataTable ConsultaResumenInventarioNombre(string nombre, int registroBase, int registrosMaximos)
        {
            var tabla = new DataTable();
            try
            {
                CargarAdapterStoredProcedure("resumen_inventario_nombre");
                miAdapter.SelectCommand.Parameters.AddWithValue("nombre", nombre);
                miAdapter.Fill(registroBase, registrosMaximos, tabla);
                var table = LoadTable(tabla);
                tabla.Rows.Clear();
                tabla = null;
                return table;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al consultar el Resultado de Inventario.\n" + ex.Message);
            }
        }

        public int GetRowsConsultaResumenInventarioNombre(string nombre)
        {
            try
            {
                CargarComandoStoredProcedure("count_resumen_inventario_nombre");
                miComando.Parameters.AddWithValue("nombre", nombre);
                miConexion.MiConexion.Open();
                var rows = Convert.ToInt32(miComando.ExecuteScalar());
                miConexion.MiConexion.Close();
                miComando.Dispose();
                return rows;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally { miConexion.MiConexion.Close(); }
        }



        public DataTable ConsultaResumenInventario(DateTime fecha, int registroBase, int registrosMaximos)
        {
            var tabla = new DataTable();
            try
            {
                CargarAdapterStoredProcedure("resumen_inventario_fecha");
                miAdapter.SelectCommand.Parameters.AddWithValue("fecha", fecha);
                miAdapter.Fill(registroBase, registrosMaximos, tabla);
                var table = LoadTable(tabla);
                tabla.Rows.Clear();
                tabla = null;
                return table;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al consultar el Resultado de Inventario.\n" + ex.Message);
            }
        }

        public int GetRowsConsultaResumenInventario(DateTime fecha)
        {
            try
            {
                CargarComandoStoredProcedure("count_resumen_inventario_fecha");
                miComando.Parameters.AddWithValue("fecha", fecha);
                miConexion.MiConexion.Open();
                var rows = Convert.ToInt32(miComando.ExecuteScalar());
                miConexion.MiConexion.Close();
                miComando.Dispose();
                return rows;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally { miConexion.MiConexion.Close(); }
        }

        public DataTable PrintInformeResumen(int orden)
        {
            var tabla = new DataTable();
            //var miTabla = TablaInventario();
            try
            {
                switch (orden)
                {
                    case 1:
                        {
                            CargarAdapterStoredProcedure("lista_producto_resumen_inventario_categoria"); // orden por categoria asc
                            break;
                        }
                    case 2:
                        {
                            CargarAdapterStoredProcedure("lista_producto_resumen_inventario"); // orden por codigo asc
                            break;
                        }
                    case 3:
                        {
                            CargarAdapterStoredProcedure("lista_producto_resumen_inventario_nombre"); // orden por nombre asc
                            break;
                        }
                    case 4:
                        {
                            CargarAdapterStoredProcedure("lista_producto_resumen_inventario_nombre_desc"); // orden por nombre desc
                            break;
                        }
                }
                miAdapter.Fill(tabla);
                var miTabla = LoadTable(tabla);
                tabla.Rows.Clear();
                tabla = null;
                /*foreach (DataRow row in tabla.Rows)
                {
                    var row_ = miTabla.NewRow();
                    var color = new ElColor();
                    color.MapaBits = (string)row["stringcolor"];
                    row_["Codigo"] = row["codigointernoproducto"];
                    row_["Nombre"] = row["nombreproducto"];
                    row_["Fecha"] = row["fecha_resumen"];
                    row_["Unidad"] = row["descripcionunidad_medida"];
                    row_["Medida"] = row["descripcionvalor_unidad_medida"];
                    row_["Color"] = color.ImagenBit;
                    row_["Inventario"] = row["cantidad_inventario"];
                    row_["Fisico"] = row["cantidad_inventario_fisico"];
                    row_["Diferencia"] = row["cantidad_resumen"];
                    row_["Costo"] = row["valorproducto"];
                    row_["Subtotal"] = row["subtotal"];
                    miTabla.Rows.Add(row_);
                }*/
                return miTabla;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al consultar el Resultado de Inventario.\n" + ex.Message);
            }
        }

        public DataTable PrintInformeResumen(DateTime fecha, int orden)
        {
            var tabla = new DataTable();
            try
            {
                switch (orden)
                {
                    case 1:
                        {
                            CargarAdapterStoredProcedure("lista_producto_resumen_inventario_categoria"); // orden por categoria asc
                            break;
                        }
                    case 2:
                        {
                            CargarAdapterStoredProcedure("lista_producto_resumen_inventario"); // orden por codigo asc
                            break;
                        }
                    case 3:
                        {
                            CargarAdapterStoredProcedure("lista_producto_resumen_inventario_nombre"); // orden por nombre asc
                            break;
                        }
                    case 4:
                        {
                            CargarAdapterStoredProcedure("lista_producto_resumen_inventario_nombre_desc"); // orden por nombre desc
                            break;
                        }
                }
                miAdapter.SelectCommand.Parameters.AddWithValue("fecha", fecha);
                miAdapter.Fill(tabla);
                var miTabla = LoadTable(tabla);
                tabla.Rows.Clear();
                tabla = null;
                return miTabla;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al consultar el Resultado de Inventario.\n" + ex.Message);
            }
        }

        private DataTable LoadTable(DataTable tabla)
        {
            var miTabla = TablaInventario();
            foreach (DataRow row in tabla.Rows)
            {
                var row_ = miTabla.NewRow();
                var color = new ElColor();
                color.MapaBits = (string)row["stringcolor"];
                row_["Categoria"] = row["nombrecategoria"];
                row_["Codigo"] = row["codigointernoproducto"];
                row_["Nombre"] = row["nombreproducto"];
                row_["Marca"] = row["nombremarca"];
                row_["Fecha"] = row["fecha_resumen"];
                row_["Unidad"] = row["descripcionunidad_medida"];
                row_["Medida"] = row["descripcionvalor_unidad_medida"];
                row_["Color"] = color.ImagenBit;
                row_["Inventario"] = row["cantidad_inventario"];
                row_["Fisico"] = row["cantidad_inventario_fisico"];

                //row_["Diferencia"] = row["cantidad_resumen"];
                row_["Diferencia"] = row["diferencia"];

                MiProducto = daoProducto.ProductoCompleto(row["codigointernoproducto"].ToString());

                double vIva = Math.Round((Convert.ToInt32(row["valorproducto"]) * MiProducto.ValorIva / 100), 1);
                row_["Costo"] = Convert.ToInt32(Convert.ToInt32(row["valorproducto"]) + vIva);

                //row_["Costo"] = row["valorproducto"];

                //row_["Subtotal"] = row["subtotal"];
                row_["Subtotal"] = Convert.ToInt32(row_["Costo"]) * Convert.ToDouble(row_["Fisico"]);
                miTabla.Rows.Add(row_);
            }
            return miTabla;
        }


    // End Consulta Resumen de Inventario.

        /// <summary>
        /// Obtiene los registros de una consulta de Resumen de inventario.
        /// </summary>
        /// <param name="codigo">Codigo del producto a consultar.</param>
        /// <param name="registroBase">Registros base para la consulta.</param>
        /// <param name="registrosMaximos">Número de registros a recuperar.</param>
        /// <returns></returns>
        public DataTable ResumenInventarioColor
            (string codigo, int registroBase, int registrosMaximos)
        {
            var dataSet = new DataSet();
            try
            {
                CargarAdapterStoredProcedure(sqlResumenInventario);
                miAdapter.SelectCommand.Parameters.AddWithValue("codigo", codigo);
                miAdapter.Fill
                    (dataSet, registroBase, registrosMaximos, "resumen_inventario");
                return dataSet.Tables[0];
            }
            catch (Exception ex)
            {
                throw new Exception(ErrorProducto + ex.Message);
            }
        }

        /// <summary>
        /// Obtiene el total de registro de una consulta de producto en Resumen de Inventario
        /// </summary>
        /// <param name="codigo">Codigo del Producto a consultar.</param>
        /// <returns></returns>
        public long GetRowsResumenInventarioColor(string codigo)
        {
            try
            {
                CargarComandoStoredProcedure(sqlTotalResumenInventario);
                miComando.Parameters.AddWithValue("codigo", codigo);
                miConexion.MiConexion.Open();
                var rows = Convert.ToInt64(miComando.ExecuteScalar());
                miConexion.MiConexion.Close();
                miComando.Dispose();
                return rows;
            }
            catch (Exception ex)
            {
                throw new Exception(ErrorProducto + ex.Message);
            }
            finally { miConexion.MiConexion.Close(); }
        }

        /// <summary>
        /// Obtiene los registros de una consulta de Resumen de inventario.
        /// </summary>
        /// <param name="codigo">Codigo del producto a consultar.</param>
        /// <param name="registroBase">Registros base para la consulta.</param>
        /// <param name="registrosMaximos">Número de registros a recuperar.</param>
        /// <returns></returns>
        public DataTable ResumenInventarioNoColor
            (string codigo, int registroBase, int registrosMaximos)
        {
            var dataSet = new DataSet();
            try
            {
                CargarAdapterStoredProcedure(sqlResumenInventarioNoColor);
                miAdapter.SelectCommand.Parameters.AddWithValue("codigo", codigo);
                miAdapter.Fill
                    (dataSet, registroBase, registrosMaximos, "resumen_inventario");
                return dataSet.Tables[0];
            }
            catch(Exception ex)
            {
                throw new Exception(ErrorProducto + ex.Message);
            }
        }

        /// <summary>
        /// Obtiene el total de registro de una consulta de producto en Resumen de Inventario
        /// </summary>
        /// <param name="codigo">Codigo del Producto a consultar.</param>
        /// <returns></returns>
        public long GetRowsResumenInventarioNoColor(string codigo)
        {
            try
            {
                CargarComandoStoredProcedure(sqlTotalResumenInventarioNoColor);
                miComando.Parameters.AddWithValue("codigo", codigo);
                miConexion.MiConexion.Open();
                var rows = Convert.ToInt64(miComando.ExecuteScalar());
                miConexion.MiConexion.Close();
                miComando.Dispose();
                return rows;
            }
            catch (Exception ex)
            {
                throw new Exception(ErrorProducto + ex.Message);
            }
            finally { miConexion.MiConexion.Close(); }
        }

        public DataTable ResumenInventario
            (DateTime fecha, string codigo, int idMedida, int idColor)
        {
            var tabla = new DataTable();
            try
            {
                CargarAdapterStoredProcedure("consulta_resumen_inventario");
                miAdapter.SelectCommand.Parameters.AddWithValue("fecha", fecha);
                miAdapter.SelectCommand.Parameters.AddWithValue("codigo", codigo);
                miAdapter.SelectCommand.Parameters.AddWithValue("idMedida", idMedida);
                miAdapter.SelectCommand.Parameters.AddWithValue("idcolor", idColor);
                miAdapter.Fill(tabla);
                return tabla;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Obtiene el ultimo registro del producto en el Resumen de Inventario
        /// </summary>
        /// <param name="codigo">Codigo del producto a consultar.</param>
        /// <param name="color">Indica si la consulta incluye color en el producto.</param>
        /// <param name="registroBase">Registros base para la consulta.</param>
        /// <param name="registrosMaximos">Número de registros a recuperar.</param>
        /// <returns></returns>
        public DataTable UltimoRegistroInventario
            (string codigo, bool color, int registroBase, int registrosMaximos)
        {
            var dataSet = new DataSet();
            try
            {
                if (color)
                    CargarAdapterStoredProcedure(sqlUltimoRegistroInventario);
                else
                    CargarAdapterStoredProcedure(sqlUltimoRegistroInventarioNoColor);
                miAdapter.SelectCommand.Parameters.AddWithValue("codigo", codigo);
                miAdapter.Fill(dataSet, registroBase, registrosMaximos, "resumen_inventario");
                return dataSet.Tables[0];
            }
            catch (Exception ex)
            {
                throw new Exception(ErrorProducto + ex.Message);
            }
        }

        /// <summary>
        /// Obtiene el total de registro de una consulta de producto en Resumen de Inventario
        /// </summary>
        /// <param name="codigo">Codigo del Producto a consultar.</param>
        /// <returns></returns>
        public long GetRowsUltimoRegistroInventario(string codigo)
        {
            try
            {
                CargarComandoStoredProcedure(sqlTotalUltimoRegistroInventario);
                miComando.Parameters.AddWithValue("codigo", codigo);
                miConexion.MiConexion.Open();
                var rows = Convert.ToInt64(miComando.ExecuteScalar());
                miConexion.MiConexion.Close();
                miComando.Dispose();
                return rows;
            }
            catch (Exception ex)
            {
                throw new Exception(ErrorProducto + ex.Message);
            }
        }

        /// <summary>
        /// Obtiene los registros de una consulta por fecha de Resumen de inventario.
        /// </summary>
        /// <param name="codigo">Codigo del producto a consultar.</param>
        /// <param name="fecha">Fecha a la cual se hace referencia.</param>
        /// <param name="color">Indica si la consulta incluye color en el producto.</param>
        /// <param name="registroBase">Registros base para la consulta.</param>
        /// <param name="registrosMaximos">Número de registros a recuperar.</param>
        /// <returns></returns>
        public DataTable ConsultaInventarioFecha
          (string codigo, DateTime fecha, bool color, int registroBase, int registrosMaximos)
        {
            var dataSet = new DataSet();
            try
            {
                if (color)
                    CargarAdapterStoredProcedure(sqlResumenInventarioFecha);
                else
                    CargarAdapterStoredProcedure(sqlResumenInventarioFechaNoColor);
                miAdapter.SelectCommand.Parameters.AddWithValue("codigo", codigo);
                miAdapter.SelectCommand.Parameters.AddWithValue("fecha", fecha);
                miAdapter.Fill(dataSet, registroBase, registrosMaximos, "resumen_inventario");
                return dataSet.Tables[0];
            }
            catch (Exception ex)
            {
                throw new Exception(ErrorProducto + ex.Message);
            }
        }

        /// <summary>
        /// Obtiene el total de registro de una consulta por fecha de producto en Resumen de Inventario.
        /// </summary>
        /// <param name="codigo">Codigo del Producto a consultar.</param>
        /// <param name="fecha">Fecha a la cual se hace referencia.</param>
        /// <returns></returns>
        public long GetRowsConsultaInventarioFecha(string codigo, DateTime fecha)
        {
            try
            {
                CargarComandoStoredProcedure(sqlTotalResumenInventarioFecha);
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
                throw new Exception(ErrorProducto + ex.Message);
            }
            finally { miConexion.MiConexion.Close(); }
        }

        /// <summary>
        /// Obtiene los registros de una consulta por periodo de fecha de Resumen de inventario.
        /// </summary>
        /// <param name="codigo">Codigo del producto a consultar.</param>
        /// <param name="fecha1">Fecha inicial a la cual se hace referencia.</param>
        /// <param name="fecha2">Fecha final a la cual se hace referencia.</param>
        /// <param name="registroBase">Registros base para la consulta.</param>
        /// <param name="registrosMaximos">Número de registros a recuperar.</param>
        /// <returns></returns>
        public DataTable ConsultaInventarioPeriodo
            (string codigo, DateTime fecha1, DateTime fecha2, int registroBase, int registrosMaximos)
        {
            var dataSet = new DataSet();
            try
            {
                CargarAdapterStoredProcedure(sqlResumenInventarioPeriodo);
                miAdapter.SelectCommand.Parameters.AddWithValue("codigo", codigo);
                miAdapter.SelectCommand.Parameters.AddWithValue("fecha1", fecha1);
                miAdapter.SelectCommand.Parameters.AddWithValue("fecha2", fecha2);
                miAdapter.Fill(dataSet, registroBase, registrosMaximos, "resumen_inventario");
                return dataSet.Tables[0];
            }
            catch (Exception ex)
            {
                throw new Exception(ErrorProducto + ex.Message);
            }
        }

        /// <summary>
        /// Obtiene el total de registro de una consulta por periodo de fecha de Resumen de Inventario.
        /// </summary>
        /// <param name="codigo">Codigo del Producto a consultar.</param>
        /// <param name="fecha1">Fecha inicial a la cual se hace referencia.</param>
        /// <param name="fecha2">Fecha final a la cual se hace referencia.</param>
        /// <returns></returns>
        public long GetRowsConsultaInventarioPeriodo(string codigo, DateTime fecha1, DateTime fecha2)
        {
            try
            {
                CargarComandoStoredProcedure(sqlTotalInventarioPeriodo);
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
                throw new Exception(ErrorProducto + ex.Message);
            }
        }

        /// <summary>
        /// Obtiene los registros de una consulta por periodo de fecha de Resumen de inventario sin incluir color.
        /// </summary>
        /// <param name="codigo">Codigo del producto a consultar.</param>
        /// <param name="fecha1">Fecha inicial a la cual se hace referencia.</param>
        /// <param name="fecha2">Fecha final a la cual se hace referencia.</param>
        /// <param name="registroBase">Registros base para la consulta.</param>
        /// <param name="registrosMaximos">Número de registros a recuperar.</param>
        /// <returns></returns>
        public DataTable ConsultaInventarioPeriodoNoColor
            (string codigo, DateTime fecha1, DateTime fecha2, int registroBase, int registrosMaximos)
        {
            var dataSet = new DataSet();
            try
            {
                CargarAdapterStoredProcedure(sqlInventarioPeriodoNoColor);
                miAdapter.SelectCommand.Parameters.AddWithValue("codigo", codigo);
                miAdapter.SelectCommand.Parameters.AddWithValue("fecha1", fecha1);
                miAdapter.SelectCommand.Parameters.AddWithValue("fecha2", fecha2);
                miAdapter.Fill(dataSet, registroBase, registrosMaximos, "resumen_inventario");
                return dataSet.Tables[0];
            }
            catch (Exception ex)
            {
                throw new Exception(ErrorProducto + ex.Message);
            }
        }

        /// <summary>
        /// Obtiene el total de registro de una consulta por periodo de fecha de Resumen de Inventario sin incluir color.
        /// </summary>
        /// <param name="codigo">Codigo del producto a consultar.</param>
        /// <param name="fecha1">Fecha inicial a la cual se hace referencia.</param>
        /// <param name="fecha2">Fecha final a la cual se hace referencia.</param>
        /// <returns></returns>
        public long GetRowsConsultaInventarioPeriodoNoColor(string codigo, DateTime fecha1, DateTime fecha2)
        {
            try
            {
                CargarComandoStoredProcedure(sqlTotalInventarioPeriodoNoColor);
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
                throw new Exception(ErrorProducto + ex.Message);
            }
        }

        /// <summary>
        /// Actualiza la cantidad de un registro en especifico del inventario.
        /// </summary>
        /// <param name="inventario">Inventario a actualizar.</param>
        /// <param name="venta">Indica si es una actualización por venta o no.</param>
        public void ActualizarInventario(Inventario inventario, bool venta)
        {//
            try
            {
                if (!ComprobarInventario(inventario, true) && !venta)
                {
                    InsertarInventario(inventario);
                }
                else
                {
                    var cantidad = CantidadInventario(inventario);
                    CargarComandoStoredProcedure(sqlEditarInventario);
                    miComando.Parameters.AddWithValue("producto", inventario.CodigoProducto);
                    miComando.Parameters.AddWithValue("medida", inventario.IdMedida);
                    miComando.Parameters.AddWithValue("color", inventario.IdColor);
                    if (venta)
                    {
                        cantidad = cantidad - inventario.Cantidad;
                    }
                    else
                    {
                        cantidad = cantidad + inventario.Cantidad;
                    }
                    miComando.Parameters.AddWithValue("cantidad", cantidad);
                    miConexion.MiConexion.Open();
                    miComando.ExecuteNonQuery();
                    miConexion.MiConexion.Close();
                    miComando.Dispose();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ErrorActualizar + ex.Message);
            }
            finally { miConexion.MiConexion.Close(); }
        }

        public void ActualizarCantidadInventario(Inventario inventario)
        {
            try
            {
                CargarComandoStoredProcedure("editar_inventario");
                miComando.Parameters.AddWithValue("producto", inventario.CodigoProducto);
                miComando.Parameters.AddWithValue("medida", inventario.IdMedida);
                miComando.Parameters.AddWithValue("color", inventario.IdColor);
                miComando.Parameters.AddWithValue("cantidad", inventario.Cantidad);
                miConexion.MiConexion.Open();
                miComando.ExecuteNonQuery();
                miConexion.MiConexion.Close();
                miComando.Dispose();
            }
            catch (Exception ex)
            {
                throw new Exception(ErrorActualizar + ex.Message);
            }
            finally { miConexion.MiConexion.Close(); }
        }

        public void ActualizarCantidadProductoPreparado(string codigo, double cantidad, bool venta)
        {
            try
            {
                double cant = 0;
                var insumos = new List<Inventario>();
                string sql = 
                    "SELECT prod_proceso, cantidad FROM producto_fabricado WHERE prod_fabricado = @codigo;";
                CargarComandoText(sql);
                miComando.Parameters.AddWithValue("codigo", codigo);
                miConexion.MiConexion.Open();
                NpgsqlDataReader reader = miComando.ExecuteReader();
                while (reader.Read())
                {
                    var invent = new Inventario();
                    invent.CodigoProducto = reader.GetString(0);
                    invent.Cantidad = reader.GetDouble(1);
                    insumos.Add(invent);
                }
                miConexion.MiConexion.Close();
                miComando.Dispose();

                foreach (var invent_ in insumos)
                {
                    cant = CantidadInventario(invent_.CodigoProducto);
                    if (venta)
                    {
                        cant = cant - Math.Round(invent_.Cantidad * cantidad, 2);
                    }
                    else
                    {
                        cant = cant + Math.Round(invent_.Cantidad * cantidad, 2);
                    }
                    ActualizarCantidad(invent_.CodigoProducto, cant);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ErrorActualizar + ex.Message);
            }
            finally { miConexion.MiConexion.Close(); }
        }

        /// <summary>
        /// Obtiene la cantidad de un registro de Inventario.
        /// </summary>
        /// <param name="inventario">Inventario a consultar.</param>
        /// <returns></returns>
        public double CantidadInventario(Inventario inventario)
        {
            try
            {
                CargarComandoStoredProcedure(sqlCantidadInventario);
                miComando.Parameters.AddWithValue("producto", inventario.CodigoProducto);
                miComando.Parameters.AddWithValue("medida", inventario.IdMedida);
                miComando.Parameters.AddWithValue("color", inventario.IdColor);
                miConexion.MiConexion.Open();
                var rows = Convert.ToDouble(miComando.ExecuteScalar());
                miConexion.MiConexion.Close();
                miComando.Dispose();
                return rows;
            }
            catch (Exception ex)
            {
                throw new Exception(ErrorComprobar + ex.Message);
            }
            finally { miConexion.MiConexion.Close(); }
        }

        public double CantidadInventario(string codigo)
        {
            try
            {
                string sql = 
                    "SELECT cantidad_inventario FROM inventario WHERE codigointernoproducto = @codigo;";
                CargarComandoText(sql);
                miComando.Parameters.AddWithValue("codigo", codigo);
                miConexion.MiConexion.Open();
                var cant = Convert.ToDouble(miComando.ExecuteScalar());
                miConexion.MiConexion.Close();
                miComando.Dispose();
                return cant;
            }
            catch (Exception ex)
            {
                throw new Exception(ErrorComprobar + ex.Message);
            }
            finally { miConexion.MiConexion.Close(); }
        }

        public void ActualizarCantidad(string codigo, double cantidad)
        {
            try
            {
                string sql =
                    "update inventario set cantidad_inventario = @cant where codigointernoproducto = @codigo;";
                CargarComandoText(sql);
                miComando.Parameters.AddWithValue("codigo", codigo);
                miComando.Parameters.AddWithValue("cant", cantidad);
                miConexion.MiConexion.Open();
                miComando.ExecuteNonQuery();
                miConexion.MiConexion.Close();
                miComando.Dispose();
            }
            catch (Exception ex)
            {
                throw new Exception(ErrorComprobar + ex.Message);
            }
            finally { miConexion.MiConexion.Close(); }
        }

        /// <summary>
        /// Elimina un registro del Inventario.
        /// </summary>
        /// <param name="inventario">Inventario a eliminar.</param>
        public bool EliminarInventario(Inventario inventario)
        {
            if (ComprobarCantidadInventario(inventario))
            {
                try
                {
                    CargarComandoStoredProcedure(sqlEliminar);
                    miComando.Parameters.AddWithValue("codigo", inventario.CodigoProducto);
                    miComando.Parameters.AddWithValue("medida", inventario.IdMedida);
                    miComando.Parameters.AddWithValue("color", inventario.IdColor);
                    miConexion.MiConexion.Open();
                    miComando.ExecuteNonQuery();
                    miConexion.MiConexion.Close();
                    miComando.Dispose();
                }
                catch (Exception ex)
                {
                    throw new Exception(ErrorActualizar + ex.Message);
                }
                finally { miConexion.MiConexion.Close(); }
                return true;
            }
            else
            {
                return false;
            }
            
        }

        public void EliminarResumenInventario(int id)
        {
            try
            {
                CargarComandoStoredProcedure("eliminar_resumen_inventario");
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

        public DataTable ListarProductoInventario(string codigo)
        {
            var miTabla = TablaInventario();
            try
            {
                var tabla = new DataTable();
                miTabla.Columns.Add(new DataColumn("IdColor", typeof(int)));
                miTabla.Columns.Add(new DataColumn("IdValorMedida", typeof(int)));

                CargarAdapterStoredProcedure("listar_inventario_producto");
                miAdapter.SelectCommand.Parameters.AddWithValue("codigo", codigo);
                miAdapter.Fill(tabla);

                foreach (DataRow row in tabla.Rows)
                {
                    var row_ = miTabla.NewRow();
                    var color = new ElColor();
                    color.MapaBits = (string)row["color"];
                    row_["Codigo"] = row["codigo"];
                    row_["Nombre"] = row["codigobarras"];
                    row_["Marca"] = row["nombre"];
                    row_["IdColor"] = row["idcolor"];
                    row_["Color"] = color.ImagenBit;
                    row_["Unidad"] = row["unidadmedida"];
                    row_["IdValorMedida"] = row["idvalormedida"];
                    row_["Medida"] = row["valorunidadmedida"];
                    row_["Inventario"] = row["cantidad"];
                    miTabla.Rows.Add(row_);
                }
                return miTabla;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrio un problema al cargar el registro del producto.\n" + ex.Message);
            }
        }



        public DataTable ConsultaInventario() 
        {
            var dataTable = new DataTable();
            try
            {
                CargarAdapterStoredProcedure("listar_inventario_producto");
                miAdapter.Fill(dataTable);
                return dataTable;
            }
            catch (Exception ex)
            {
                throw new Exception(ErrorProducto + ex.Message);
            }
        }

        DaoProducto daoProducto;

        private string CodigoProducto = "";

        public DataTable ConsultaInventario(int rowBase, int rowMax)
        {
            var dataTable = new DataTable();
            var miTabla = TablaInventario();
            try
            {
                CargarAdapterStoredProcedure("listar_inventario_producto");
                miAdapter.Fill(rowBase, rowMax, dataTable);
                foreach (DataRow row in dataTable.Rows)
                {
                    this.CodigoProducto = row["codigo"].ToString();

                    var row_ = miTabla.NewRow();
                    var color = new ElColor();
                    color.MapaBits = (string)row["color"];
                    row_["Marca"] = row["categoria"];
                    row_["Codigo"] = row["codigo"];
                    row_["Nombre"] = row["nombre"];
                    row_["Unidad"] = row["unidadmedida"];
                    row_["Medida"] = row["valorunidadmedida"];
                    row_["Color"] = color.ImagenBit;
                    row_["Inventario"] = row["cantidad"];

                    if (Convert.ToBoolean(AppConfiguracion.ValorSeccion("costoMasIva")))
                    {
                        MiProducto = daoProducto.ProductoCompleto(row["codigo"].ToString());

                        if (MiProducto.CodigoInternoProducto == "16995")
                        {
                            var j_ = MiProducto.CodigoInternoProducto;
                        }

                        if (MiProducto.CodigoInternoProducto == "2428")
                        {
                            var j__ = MiProducto.CodigoInternoProducto;
                        }

                        double vIva = Math.Round((Convert.ToDouble(row["valor"]) * MiProducto.ValorIva / 100), 2);
                        double j = Convert.ToDouble(row["valor"]) + vIva;
                        row_["Valor"] = Convert.ToDouble(row["valor"]) + vIva;
                        var v = row_["Valor"].ToString();
                        /*row_["Valor"] = Convert.ToInt32(Convert.ToInt32(row["valor"]) +
                                        Convert.ToInt32(row["valor"]) * p.ValorIva / 100);*/
                    }
                    else
                    {
                        row_["Valor"] = row["valor"];
                    }
                    row_["Valor"] = Convert.ToDouble(row_["Valor"]) + Convert.ToDouble(row["impoconsumo"]);  // Adición de codigo para sumar el impoconsumo al costo del producto.

                    //ow_["Valor"] = row["valor"];

                    row_["DestoMayor"] = row["descto_mayor"];
                    row_["DestoDistri"] = row["descto_distribuidor"];
                    row_["Desto3"] = row["descto_3"];

                    row_["Venta"] = row["venta"];
                   /* row_["Mayorista"] = UseObject.Aproximar
                        (Convert.ToInt32(row["mayorista"]), Convert.ToBoolean(AppConfiguracion.ValorSeccion("tipo_aprox_precio")));
                    row_["Distribuidor"] = UseObject.Aproximar
                        (Convert.ToInt32(row["distribuidor"]), Convert.ToBoolean(AppConfiguracion.ValorSeccion("tipo_aprox_precio")));*/

                    //row_["Mayorista"] = row["mayorista"];
                    //row_["Distribuidor"] = row["distribuidor"];

                    // Edicion precio producto 18 Feb 2017-

                    if (this.RedondearPrecio2)
                    {
                        row_["Mayorista"] = UseObject.Aproximar(Convert.ToInt32(row["mayorista"]), this.aprox_precio);
                    }
                    else
                    {
                        row_["Mayorista"] = Convert.ToInt32(row["mayorista"]);
                    }
                    
                    //row_["Mayorista"] = UseObject.Aproximar(Convert.ToInt32(row["mayorista"]), this.aprox_precio);
                    row_["Distribuidor"] = UseObject.Aproximar(Convert.ToInt32(row["distribuidor"]), this.aprox_precio);
                    row_["Precio4"] = UseObject.Aproximar(Convert.ToInt32(row["precio_4"]), this.aprox_precio);
                    
                    // End edicion

                     /*Venta", typeof(int)));
            tabla.Columns.Add(new DataColumn("Mayorista", typeof(int)));
                     DestoMayor", typeof(double)));
            tabla.Columns.Add(new DataColumn("DestoDistri", typeof(double)));*/
                    miTabla.Rows.Add(row_);
                }
                dataTable.Clear();
                dataTable.Dispose();
                dataTable = null;
                return miTabla;
            }
            catch (Exception ex)
            {
                throw new Exception(ErrorProducto + "\n" + ex.Message + "\nProducto relacionado: " + this.CodigoProducto);
            }
        }

        public long GetRowsConsultaInventario()
        {
            try
            {
                CargarComandoStoredProcedure("count_listar_inventario_producto");
                miConexion.MiConexion.Open();
                var rows = Convert.ToInt64(miComando.ExecuteScalar());
                miConexion.MiConexion.Close();
                miComando.Dispose();
                return rows;
            }
            catch (Exception ex)
            {
                throw new Exception("" + ex.Message);
            }
            finally { miConexion.MiConexion.Close(); }
        }

        public DataTable ConsultaInventario(string codigo, int rowBase, int rowMax)
        {
            var dataTable = new DataTable();
            var miTabla = TablaInventario();
            try
            {
                CargarAdapterStoredProcedure("listar_inventario_producto");
                miAdapter.SelectCommand.Parameters.AddWithValue("codigo", codigo);
                miAdapter.Fill(rowBase, rowMax, dataTable);
                foreach (DataRow row in dataTable.Rows)
                {
                    this.CodigoProducto = row["codigo"].ToString();

                    var row_ = miTabla.NewRow();
                    var color = new ElColor();
                    color.MapaBits = (string)row["color"];
                    row_["Marca"] = row["categoria"];
                    row_["Codigo"] = row["codigo"];
                    row_["Nombre"] = row["nombre"];
                    row_["Unidad"] = row["unidadmedida"];
                    row_["Medida"] = row["valorunidadmedida"];
                    row_["Color"] = color.ImagenBit;
                    row_["Inventario"] = row["cantidad"];
                    //row_["Valor"] = row["valor"];
                    if (Convert.ToBoolean(AppConfiguracion.ValorSeccion("costoMasIva")))
                    {
                        MiProducto = daoProducto.ProductoCompleto(row["codigo"].ToString());
                        double vIva = Math.Round((Convert.ToDouble(row["valor"]) * MiProducto.ValorIva / 100), 1);
                        row_["Valor"] = Convert.ToDouble(row["valor"]) + vIva;
                        /*row_["Valor"] = Convert.ToInt32(Convert.ToInt32(row["valor"]) +
                                        Convert.ToInt32(row["valor"]) * MiProducto.ValorIva / 100);*/
                    }
                    else
                    {
                        row_["Valor"] = row["valor"];
                    }
                    row_["Valor"] = Convert.ToDouble(row_["Valor"]) + Convert.ToDouble(row["impoconsumo"]);  // Adición de codigo para sumar el impoconsumo al costo del producto.

                    row_["DestoMayor"] = row["descto_mayor"];
                    row_["DestoDistri"] = row["descto_distribuidor"];
                    row_["Desto3"] = row["descto_3"];

                    row_["Venta"] = row["venta"];
                    /*row_["Mayorista"] = UseObject.Aproximar
                        (Convert.ToInt32(row["mayorista"]), Convert.ToBoolean(AppConfiguracion.ValorSeccion("tipo_aprox_precio")));
                    row_["Distribuidor"] = UseObject.Aproximar
                        (Convert.ToInt32(row["distribuidor"]), Convert.ToBoolean(AppConfiguracion.ValorSeccion("tipo_aprox_precio")));*/
                    //var may_ = row["mayorista"].ToString();
                    //row_["Mayorista"] = row["mayorista"];
                    //row_["Distribuidor"] = row["distribuidor"];

                    // Edicion precio producto 18 Feb 2017-

                    if (this.RedondearPrecio2)
                    {
                        row_["Mayorista"] = UseObject.Aproximar(Convert.ToInt32(row["mayorista"]), this.aprox_precio);
                    }
                    else
                    {
                        row_["Mayorista"] = Convert.ToInt32(row["mayorista"]);
                    }
                    //row_["Mayorista"] = Convert.ToInt32(row["mayorista"]);
                    //row_["Mayorista"] = UseObject.Aproximar(Convert.ToInt32(row["mayorista"]), this.aprox_precio);
                    row_["Distribuidor"] = UseObject.Aproximar(Convert.ToInt32(row["distribuidor"]), this.aprox_precio);
                    row_["Precio4"] = UseObject.Aproximar(Convert.ToInt32(row["precio_4"]), this.aprox_precio);

                    // End edicion

                    miTabla.Rows.Add(row_);
                }
                dataTable.Clear();
                dataTable.Dispose();
                dataTable = null;
                return miTabla;
            }
            catch (Exception ex)
            {
                throw new Exception(ErrorProducto + "\n" + ex.Message + "\nProducto relacionado: " + this.CodigoProducto);
            }
        }

        public long GetRowsConsultaInventario(string codigo)
        {
            try
            {
                CargarComandoStoredProcedure("count_listar_inventario_producto");
                miComando.Parameters.AddWithValue("codigo", codigo);
                miConexion.MiConexion.Open();
                var rows = Convert.ToInt64(miComando.ExecuteScalar());
                miConexion.MiConexion.Close();
                miComando.Dispose();
                return rows;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally { miConexion.MiConexion.Close(); }
        }

        public DataTable ConsultaInventarioNombre(string nombre, int rowBase, int rowMax)
        {
            var dataTable = new DataTable();
            var miTabla = TablaInventario();
            try
            {
                //var n = nombre.ToUpper();
                CargarAdapterStoredProcedure("listar_inventario_producto_nombre");
                miAdapter.SelectCommand.Parameters.AddWithValue("nombre", nombre.ToUpper());
                miAdapter.Fill(rowBase, rowMax, dataTable);
                foreach (DataRow row in dataTable.Rows)
                {
                    this.CodigoProducto = row["codigo"].ToString();

                    var row_ = miTabla.NewRow();
                    var color = new ElColor();
                    color.MapaBits = (string)row["color"];
                    row_["Marca"] = row["categoria"];
                    row_["Codigo"] = row["codigo"];
                    row_["Nombre"] = row["nombre"];
                    row_["Unidad"] = row["unidadmedida"];
                    row_["Medida"] = row["valorunidadmedida"];
                    row_["Color"] = color.ImagenBit;
                    row_["Inventario"] = row["cantidad"];
                    //row_["Valor"] = row["valor"];
                    if (Convert.ToBoolean(AppConfiguracion.ValorSeccion("costoMasIva")))
                    {
                        MiProducto = daoProducto.ProductoCompleto(row["codigo"].ToString());
                        row_["Valor"] = Convert.ToInt32(Convert.ToInt32(row["valor"]) +
                                        Convert.ToInt32(row["valor"]) * MiProducto.ValorIva / 100);
                    }
                    else
                    {
                        row_["Valor"] = row["valor"];
                    }
                    row_["Valor"] = Convert.ToDouble(row_["Valor"]) + Convert.ToDouble(row["impoconsumo"]);  // Adición de codigo para sumar el impoconsumo al costo del producto.

                    row_["DestoMayor"] = row["descto_mayor"];
                    row_["DestoDistri"] = row["descto_distribuidor"];
                    row_["Desto3"] = row["descto_3"];

                    row_["Venta"] = row["venta"];
                   /* row_["Mayorista"] = UseObject.Aproximar
                        (Convert.ToInt32(row["mayorista"]), Convert.ToBoolean(AppConfiguracion.ValorSeccion("tipo_aprox_precio")));
                    row_["Distribuidor"] = UseObject.Aproximar
                        (Convert.ToInt32(row["distribuidor"]), Convert.ToBoolean(AppConfiguracion.ValorSeccion("tipo_aprox_precio")));*/
                    //row_["Mayorista"] = row["mayorista"];
                    //row_["Distribuidor"] = row["distribuidor"];

                    // Edicion precio producto 18 Feb 2017-

                    if (this.RedondearPrecio2)
                    {
                        row_["Mayorista"] = UseObject.Aproximar(Convert.ToInt32(row["mayorista"]), this.aprox_precio);
                    }
                    else
                    {
                        row_["Mayorista"] = Convert.ToInt32(row["mayorista"]);
                    }
                    //row_["Mayorista"] = Convert.ToInt32(row["mayorista"]);
                    //row_["Mayorista"] = UseObject.Aproximar(Convert.ToInt32(row["mayorista"]), this.aprox_precio);
                    //row_["Distribuidor"] = UseObject.Aproximar(Convert.ToInt32(row["distribuidor"]), this.aprox_precio);
                   //row_["Precio4"] = UseObject.Aproximar(Convert.ToInt32(row["precio_4"]), this.aprox_precio);

                    row_["Distribuidor"] = Convert.ToInt32(row["distribuidor"]);
                    row_["Precio4"] = Convert.ToInt32(row["precio_4"]);

                    // End edicion

                    miTabla.Rows.Add(row_);
                }
                dataTable.Clear();
                dataTable.Dispose();
                dataTable = null;
                return miTabla;
            }
            catch (Exception ex)
            {
                throw new Exception(ErrorProducto + "\n" + ex.Message + "\nProducto relacionado: " + this.CodigoProducto);
            }
        }

        public long GetRowsConsultaInventarioNombre(string nombre)
        {
            try
            {
                CargarComandoStoredProcedure("count_listar_inventario_producto_nombre");
                miComando.Parameters.AddWithValue("nombre", nombre.ToUpper());
                miConexion.MiConexion.Open();
                var rows = Convert.ToInt64(miComando.ExecuteScalar());
                miConexion.MiConexion.Close();
                miComando.Dispose();
                return rows;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally { miConexion.MiConexion.Close(); }
        }

        public DataTable ConsultaInventarioCategoria(string categoria, int rowBase, int rowMax)
        {
            var dataTable = new DataTable();
            var miTabla = TablaInventario();
            try
            {
                CargarAdapterStoredProcedure("listar_inventario_producto_categoria");
                miAdapter.SelectCommand.Parameters.AddWithValue("categoria", categoria);
                miAdapter.Fill(rowBase, rowMax, dataTable);
                foreach (DataRow row in dataTable.Rows)
                {
                    this.CodigoProducto = row["codigo"].ToString();

                    var row_ = miTabla.NewRow();
                    var color = new ElColor();
                    color.MapaBits = (string)row["color"];
                    row_["Marca"] = row["categoria"];
                    row_["Codigo"] = row["codigo"];
                    row_["Nombre"] = row["nombre"];
                    row_["Unidad"] = row["unidadmedida"];
                    row_["Medida"] = row["valorunidadmedida"];
                    row_["Color"] = color.ImagenBit;
                    row_["Inventario"] = row["cantidad"];
                    //row_["Valor"] = row["valor"];
                    if (Convert.ToBoolean(AppConfiguracion.ValorSeccion("costoMasIva")))
                    {
                        MiProducto = daoProducto.ProductoCompleto(row["codigo"].ToString());
                        row_["Valor"] = Convert.ToInt32(Convert.ToInt32(row["valor"]) +
                                        Convert.ToInt32(row["valor"]) * MiProducto.ValorIva / 100);
                    }
                    else
                    {
                        row_["Valor"] = row["valor"];
                    }
                    row_["Valor"] = Convert.ToDouble(row_["Valor"]) + Convert.ToDouble(row["impoconsumo"]);  // Adición de codigo para sumar el impoconsumo al costo del producto.

                    row_["DestoMayor"] = row["descto_mayor"];
                    row_["DestoDistri"] = row["descto_distribuidor"];
                    row_["Desto3"] = row["descto_3"];

                    row_["Venta"] = row["venta"];
                   /* row_["Mayorista"] = UseObject.Aproximar
                        (Convert.ToInt32(row["mayorista"]), Convert.ToBoolean(AppConfiguracion.ValorSeccion("tipo_aprox_precio")));
                    row_["Distribuidor"] = UseObject.Aproximar
                        (Convert.ToInt32(row["distribuidor"]), Convert.ToBoolean(AppConfiguracion.ValorSeccion("tipo_aprox_precio")));*/
                    //row_["Mayorista"] = row["mayorista"];
                    //row_["Distribuidor"] = row["distribuidor"];

                    // Edicion precio producto 18 Feb 2017-

                    if (this.RedondearPrecio2)
                    {
                        row_["Mayorista"] = UseObject.Aproximar(Convert.ToInt32(row["mayorista"]), this.aprox_precio);
                    }
                    else
                    {
                        row_["Mayorista"] = Convert.ToInt32(row["mayorista"]);
                    }
                    //row_["Mayorista"] = Convert.ToInt32(row["mayorista"]);
//                    row_["Mayorista"] = UseObject.Aproximar(Convert.ToInt32(row["mayorista"]), this.aprox_precio);
                    row_["Distribuidor"] = UseObject.Aproximar(Convert.ToInt32(row["distribuidor"]), this.aprox_precio);
                    row_["Precio4"] = UseObject.Aproximar(Convert.ToInt32(row["precio_4"]), this.aprox_precio);

                    // End edicion

                    miTabla.Rows.Add(row_);
                }
                dataTable.Clear();
                dataTable.Dispose();
                dataTable = null;
                return miTabla;
            }
            catch (Exception ex)
            {
                throw new Exception(ErrorProducto + "\n" + ex.Message + "\nProducto relacionado: " + this.CodigoProducto);
            }
        }

        public long GetRowsConsultaInventarioCategoria(string categoria)
        {
            try
            {
                CargarComandoStoredProcedure("count_listar_inventario_producto_categoria");
                miComando.Parameters.AddWithValue("categoria", categoria);
                miConexion.MiConexion.Open();
                var rows = Convert.ToInt64(miComando.ExecuteScalar());
                miConexion.MiConexion.Close();
                miComando.Dispose();
                return rows;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally { miConexion.MiConexion.Close(); }
        }

        public DataTable ConsultaInventarioBasic()
        {
            var dataTable = new DataTable();
            try
            {
                CargarAdapterStoredProcedure("inventarios");
                miAdapter.Fill(dataTable);
                return dataTable;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al consultar Inventarios." + ex.Message);
            }
        }

        public DataTable InformeInventario()
        {
            var dataTable = new DataTable();
            dataTable.TableName = "Inventario";
            try
            {
                CargarAdapterStoredProcedure("informe_inventario");
                miAdapter.Fill(dataTable);
                return dataTable;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al consultar Inventarios." + ex.Message);
            }
        }

        /// <summary>
        /// Obtiene una DataTable tipado para la vista de Resumen de Inventario.
        /// </summary>
        /// <returns></returns>
        private DataTable TablaInventario()
        {
            var tabla = new DataTable();
            tabla.Columns.Add(new DataColumn("Codigo", typeof(string)));
            tabla.Columns.Add(new DataColumn("Nombre", typeof(string)));
            tabla.Columns.Add(new DataColumn("Marca", typeof(string)));
            tabla.Columns.Add(new DataColumn("Fecha", typeof(DateTime)));
            tabla.Columns.Add(new DataColumn("Unidad", typeof(string)));
            tabla.Columns.Add(new DataColumn("Medida", typeof(string)));
            tabla.Columns.Add(new DataColumn("Color", typeof(System.Drawing.Image)));
            tabla.Columns.Add(new DataColumn("Inventario", typeof(double)));
            tabla.Columns.Add(new DataColumn("Valor", typeof(int)));
            tabla.Columns.Add(new DataColumn("Fisico", typeof(double)));
            tabla.Columns.Add(new DataColumn("Diferencia", typeof(double)));
            tabla.Columns.Add(new DataColumn("Estado", typeof(bool)));

            tabla.Columns.Add(new DataColumn("Categoria", typeof(string)));
            tabla.Columns.Add(new DataColumn("Costo", typeof(double)));
            tabla.Columns.Add(new DataColumn("Subtotal", typeof(double)));

            tabla.Columns.Add(new DataColumn("DestoMayor", typeof(double)));
            tabla.Columns.Add(new DataColumn("DestoDistri", typeof(double)));
            tabla.Columns.Add(new DataColumn("Desto3", typeof(double)));

            tabla.Columns.Add(new DataColumn("Venta", typeof(int)));
            tabla.Columns.Add(new DataColumn("Mayorista", typeof(int)));
            tabla.Columns.Add(new DataColumn("Distribuidor", typeof(int)));
            tabla.Columns.Add(new DataColumn("Precio4", typeof(int)));

            return tabla;
        }

        // Funciones con filtro por tipo inventario de productos, productos fabricados y no fabricados

        public DataTable ConsultaInventario(bool compra, int rowBase, int rowMax, int idTipoInventario, int idTipoInventario2)
        {
            var dataTable = new DataTable();
            var miTabla = TablaInventario();
            try
            {
                if (compra)
                {
                    CargarAdapterStoredProcedure("listar_inventario_producto_diferente");
                }
                else
                {
                    CargarAdapterStoredProcedure("listar_inventario_producto");
                }
                miAdapter.SelectCommand.Parameters.AddWithValue("", idTipoInventario);
                miAdapter.SelectCommand.Parameters.AddWithValue("", idTipoInventario2);
                miAdapter.Fill(rowBase, rowMax, dataTable);
                foreach (DataRow row in dataTable.Rows)
                {
                    this.CodigoProducto = row["codigo"].ToString();

                    var row_ = miTabla.NewRow();
                    var color = new ElColor();
                    color.MapaBits = (string)row["color"];
                    row_["Marca"] = row["categoria"];
                    row_["Codigo"] = row["codigo"];
                    row_["Nombre"] = row["nombre"];
                    row_["Unidad"] = row["unidadmedida"];
                    row_["Medida"] = row["valorunidadmedida"];
                    row_["Color"] = color.ImagenBit;
                    row_["Inventario"] = row["cantidad"];

                    if (Convert.ToBoolean(AppConfiguracion.ValorSeccion("costoMasIva")))
                    {
                        MiProducto = daoProducto.ProductoCompleto(row["codigo"].ToString());

                        if (MiProducto.CodigoInternoProducto == "16995")
                        {
                            var j_ = MiProducto.CodigoInternoProducto;
                        }

                        if (MiProducto.CodigoInternoProducto == "2428")
                        {
                            var j__ = MiProducto.CodigoInternoProducto;
                        }

                        double vIva = Math.Round((Convert.ToDouble(row["valor"]) * MiProducto.ValorIva / 100), 2);
                        double j = Convert.ToDouble(row["valor"]) + vIva;
                        row_["Valor"] = Convert.ToDouble(row["valor"]) + vIva;
                        var v = row_["Valor"].ToString();
                        /*row_["Valor"] = Convert.ToInt32(Convert.ToInt32(row["valor"]) +
                                        Convert.ToInt32(row["valor"]) * p.ValorIva / 100);*/
                    }
                    else
                    {
                        row_["Valor"] = row["valor"];
                    }
                    row_["Valor"] = Convert.ToDouble(row_["Valor"]) + Convert.ToDouble(row["impoconsumo"]);  // Adición de codigo para sumar el impoconsumo al costo del producto.

                    //ow_["Valor"] = row["valor"];

                    row_["DestoMayor"] = row["descto_mayor"];
                    row_["DestoDistri"] = row["descto_distribuidor"];
                    row_["Desto3"] = row["descto_3"];

                    row_["Venta"] = row["venta"];
                    /* row_["Mayorista"] = UseObject.Aproximar
                         (Convert.ToInt32(row["mayorista"]), Convert.ToBoolean(AppConfiguracion.ValorSeccion("tipo_aprox_precio")));
                     row_["Distribuidor"] = UseObject.Aproximar
                         (Convert.ToInt32(row["distribuidor"]), Convert.ToBoolean(AppConfiguracion.ValorSeccion("tipo_aprox_precio")));*/

                    //row_["Mayorista"] = row["mayorista"];
                    //row_["Distribuidor"] = row["distribuidor"];

                    // Edicion precio producto 18 Feb 2017-

                    if (this.RedondearPrecio2)
                    {
                        row_["Mayorista"] = UseObject.Aproximar(Convert.ToInt32(row["mayorista"]), this.aprox_precio);
                    }
                    else
                    {
                        row_["Mayorista"] = Convert.ToInt32(row["mayorista"]);
                    }

                    //row_["Mayorista"] = UseObject.Aproximar(Convert.ToInt32(row["mayorista"]), this.aprox_precio);
                    row_["Distribuidor"] = UseObject.Aproximar(Convert.ToInt32(row["distribuidor"]), this.aprox_precio);
                    row_["Precio4"] = UseObject.Aproximar(Convert.ToInt32(row["precio_4"]), this.aprox_precio);

                    // End edicion

                    /*Venta", typeof(int)));
           tabla.Columns.Add(new DataColumn("Mayorista", typeof(int)));
                    DestoMayor", typeof(double)));
           tabla.Columns.Add(new DataColumn("DestoDistri", typeof(double)));*/
                    miTabla.Rows.Add(row_);
                }
                dataTable.Clear();
                dataTable.Dispose();
                dataTable = null;
                return miTabla;
            }
            catch (Exception ex)
            {
                throw new Exception(ErrorProducto + "\n" + ex.Message + "\nProducto relacionado: " + this.CodigoProducto);
            }
        }

        public long GetRowsConsultaInventario(bool compra, int idTipoInventario, int idTipoInventario2)
        {
            try
            {
                if (compra)
                {
                    CargarComandoStoredProcedure("count_listar_inventario_producto_diferente");
                }
                else
                {
                    CargarComandoStoredProcedure("count_listar_inventario_producto");
                }
                miComando.Parameters.AddWithValue("", idTipoInventario);
                miComando.Parameters.AddWithValue("", idTipoInventario2);
                miConexion.MiConexion.Open();
                var rows = Convert.ToInt64(miComando.ExecuteScalar());
                miConexion.MiConexion.Close();
                miComando.Dispose();
                return rows;
            }
            catch (Exception ex)
            {
                throw new Exception("" + ex.Message);
            }
            finally { miConexion.MiConexion.Close(); }
        }

        public DataTable ConsultaInventario(bool compra, string codigo, int rowBase, int rowMax, int idTipoInventario, int idTipoInventario2)
        {
            var dataTable = new DataTable();
            var miTabla = TablaInventario();
            try
            {
                if (compra)
                {
                    CargarAdapterStoredProcedure("listar_inventario_producto_diferente");
                }
                else
                {
                    CargarAdapterStoredProcedure("listar_inventario_producto");
                }
                miAdapter.SelectCommand.Parameters.AddWithValue("", codigo);
                miAdapter.SelectCommand.Parameters.AddWithValue("", idTipoInventario);
                miAdapter.SelectCommand.Parameters.AddWithValue("", idTipoInventario2);
                miAdapter.Fill(rowBase, rowMax, dataTable);
                foreach (DataRow row in dataTable.Rows)
                {
                    this.CodigoProducto = row["codigo"].ToString();

                    var row_ = miTabla.NewRow();
                    var color = new ElColor();
                    color.MapaBits = (string)row["color"];
                    row_["Marca"] = row["categoria"];
                    row_["Codigo"] = row["codigo"];
                    row_["Nombre"] = row["nombre"];
                    row_["Unidad"] = row["unidadmedida"];
                    row_["Medida"] = row["valorunidadmedida"];
                    row_["Color"] = color.ImagenBit;
                    row_["Inventario"] = row["cantidad"];
                    //row_["Valor"] = row["valor"];
                    if (Convert.ToBoolean(AppConfiguracion.ValorSeccion("costoMasIva")))
                    {
                        MiProducto = daoProducto.ProductoCompleto(row["codigo"].ToString());
                        double vIva = Math.Round((Convert.ToDouble(row["valor"]) * MiProducto.ValorIva / 100), 1);
                        row_["Valor"] = Convert.ToDouble(row["valor"]) + vIva;
                        /*row_["Valor"] = Convert.ToInt32(Convert.ToInt32(row["valor"]) +
                                        Convert.ToInt32(row["valor"]) * MiProducto.ValorIva / 100);*/
                    }
                    else
                    {
                        row_["Valor"] = row["valor"];
                    }
                    row_["Valor"] = Convert.ToDouble(row_["Valor"]) + Convert.ToDouble(row["impoconsumo"]);  // Adición de codigo para sumar el impoconsumo al costo del producto.

                    row_["DestoMayor"] = row["descto_mayor"];
                    row_["DestoDistri"] = row["descto_distribuidor"];
                    row_["Desto3"] = row["descto_3"];

                    row_["Venta"] = row["venta"];
                    /*row_["Mayorista"] = UseObject.Aproximar
                        (Convert.ToInt32(row["mayorista"]), Convert.ToBoolean(AppConfiguracion.ValorSeccion("tipo_aprox_precio")));
                    row_["Distribuidor"] = UseObject.Aproximar
                        (Convert.ToInt32(row["distribuidor"]), Convert.ToBoolean(AppConfiguracion.ValorSeccion("tipo_aprox_precio")));*/
                    //var may_ = row["mayorista"].ToString();
                    //row_["Mayorista"] = row["mayorista"];
                    //row_["Distribuidor"] = row["distribuidor"];

                    // Edicion precio producto 18 Feb 2017-

                    if (this.RedondearPrecio2)
                    {
                        row_["Mayorista"] = UseObject.Aproximar(Convert.ToInt32(row["mayorista"]), this.aprox_precio);
                    }
                    else
                    {
                        row_["Mayorista"] = Convert.ToInt32(row["mayorista"]);
                    }
                    //row_["Mayorista"] = Convert.ToInt32(row["mayorista"]);
                    //row_["Mayorista"] = UseObject.Aproximar(Convert.ToInt32(row["mayorista"]), this.aprox_precio);
                    row_["Distribuidor"] = UseObject.Aproximar(Convert.ToInt32(row["distribuidor"]), this.aprox_precio);
                    row_["Precio4"] = UseObject.Aproximar(Convert.ToInt32(row["precio_4"]), this.aprox_precio);

                    // End edicion

                    miTabla.Rows.Add(row_);
                }
                dataTable.Clear();
                dataTable.Dispose();
                dataTable = null;
                return miTabla;
            }
            catch (Exception ex)
            {
                throw new Exception(ErrorProducto + "\n" + ex.Message + "\nProducto relacionado: " + this.CodigoProducto);
            }
        }

        public long GetRowsConsultaInventario(bool compra, string codigo, int idTipoInventario, int idTipoInventario2)
        {
            try
            {
                if (compra)
                {
                    CargarComandoStoredProcedure("count_listar_inventario_producto_diferente");
                }
                else
                {
                    CargarComandoStoredProcedure("count_listar_inventario_producto");
                }
                miComando.Parameters.AddWithValue("", codigo);
                miComando.Parameters.AddWithValue("", idTipoInventario);
                miComando.Parameters.AddWithValue("", idTipoInventario2);
                miConexion.MiConexion.Open();
                var rows = Convert.ToInt64(miComando.ExecuteScalar());
                miConexion.MiConexion.Close();
                miComando.Dispose();
                return rows;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally { miConexion.MiConexion.Close(); }
        }

        public DataTable ConsultaInventarioNombre(bool compra, string nombre, int rowBase, int rowMax, int idTipoInventario, int idTipoInventario2)
        {
            var dataTable = new DataTable();
            var miTabla = TablaInventario();
            try
            {
                //var n = nombre.ToUpper();
                if (compra)
                {
                    CargarAdapterStoredProcedure("listar_inventario_producto_nombre_diferente");
                }
                else
                {
                    CargarAdapterStoredProcedure("listar_inventario_producto_nombre");
                }
                miAdapter.SelectCommand.Parameters.AddWithValue("", nombre.ToUpper());
                miAdapter.SelectCommand.Parameters.AddWithValue("", idTipoInventario);
                miAdapter.SelectCommand.Parameters.AddWithValue("", idTipoInventario2);
                miAdapter.Fill(rowBase, rowMax, dataTable);
                foreach (DataRow row in dataTable.Rows)
                {
                    this.CodigoProducto = row["codigo"].ToString();

                    var row_ = miTabla.NewRow();
                    var color = new ElColor();
                    color.MapaBits = (string)row["color"];
                    row_["Marca"] = row["categoria"];
                    row_["Codigo"] = row["codigo"];
                    row_["Nombre"] = row["nombre"];
                    row_["Unidad"] = row["unidadmedida"];
                    row_["Medida"] = row["valorunidadmedida"];
                    row_["Color"] = color.ImagenBit;
                    row_["Inventario"] = row["cantidad"];
                    //row_["Valor"] = row["valor"];
                    if (Convert.ToBoolean(AppConfiguracion.ValorSeccion("costoMasIva")))
                    {
                        MiProducto = daoProducto.ProductoCompleto(row["codigo"].ToString());
                        row_["Valor"] = Convert.ToInt32(Convert.ToInt32(row["valor"]) +
                                        Convert.ToInt32(row["valor"]) * MiProducto.ValorIva / 100);
                    }
                    else
                    {
                        row_["Valor"] = row["valor"];
                    }
                    row_["Valor"] = Convert.ToDouble(row_["Valor"]) + Convert.ToDouble(row["impoconsumo"]);  // Adición de codigo para sumar el impoconsumo al costo del producto.

                    row_["DestoMayor"] = row["descto_mayor"];
                    row_["DestoDistri"] = row["descto_distribuidor"];
                    row_["Desto3"] = row["descto_3"];

                    row_["Venta"] = row["venta"];
                    /* row_["Mayorista"] = UseObject.Aproximar
                         (Convert.ToInt32(row["mayorista"]), Convert.ToBoolean(AppConfiguracion.ValorSeccion("tipo_aprox_precio")));
                     row_["Distribuidor"] = UseObject.Aproximar
                         (Convert.ToInt32(row["distribuidor"]), Convert.ToBoolean(AppConfiguracion.ValorSeccion("tipo_aprox_precio")));*/
                    //row_["Mayorista"] = row["mayorista"];
                    //row_["Distribuidor"] = row["distribuidor"];

                    // Edicion precio producto 18 Feb 2017-

                    if (this.RedondearPrecio2)
                    {
                        row_["Mayorista"] = UseObject.Aproximar(Convert.ToInt32(row["mayorista"]), this.aprox_precio);
                    }
                    else
                    {
                        row_["Mayorista"] = Convert.ToInt32(row["mayorista"]);
                    }
                    //row_["Mayorista"] = Convert.ToInt32(row["mayorista"]);
                    //row_["Mayorista"] = UseObject.Aproximar(Convert.ToInt32(row["mayorista"]), this.aprox_precio);
                    //row_["Distribuidor"] = UseObject.Aproximar(Convert.ToInt32(row["distribuidor"]), this.aprox_precio);
                    //row_["Precio4"] = UseObject.Aproximar(Convert.ToInt32(row["precio_4"]), this.aprox_precio);

                    row_["Distribuidor"] = Convert.ToInt32(row["distribuidor"]);
                    row_["Precio4"] = Convert.ToInt32(row["precio_4"]);

                    // End edicion

                    miTabla.Rows.Add(row_);
                }
                dataTable.Clear();
                dataTable.Dispose();
                dataTable = null;
                return miTabla;
            }
            catch (Exception ex)
            {
                throw new Exception(ErrorProducto + "\n" + ex.Message + "\nProducto relacionado: " + this.CodigoProducto);
            }
        }

        public long GetRowsConsultaInventarioNombre(bool compra, string nombre, int idTipoInventario, int idTipoInventario2)
        {
            try
            {
                if (compra)
                {
                    CargarComandoStoredProcedure("count_listar_inventario_producto_nombre_diferente");
                }
                else
                {
                    CargarComandoStoredProcedure("count_listar_inventario_producto_nombre");
                }
                miComando.Parameters.AddWithValue("", nombre.ToUpper());
                miComando.Parameters.AddWithValue("", idTipoInventario);
                miComando.Parameters.AddWithValue("", idTipoInventario2);
                miConexion.MiConexion.Open();
                var rows = Convert.ToInt64(miComando.ExecuteScalar());
                miConexion.MiConexion.Close();
                miComando.Dispose();
                return rows;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally { miConexion.MiConexion.Close(); }
        }

        public DataTable ConsultaInventarioCategoria(bool compra, string categoria, int rowBase, int rowMax, int idTipoInventario, int idTipoInventario2)
        {
            var dataTable = new DataTable();
            var miTabla = TablaInventario();
            try
            {
                if (compra)
                {
                    CargarAdapterStoredProcedure("listar_inventario_producto_categoria_diferente");
                }
                else
                {
                    CargarAdapterStoredProcedure("listar_inventario_producto_categoria");
                }
                miAdapter.SelectCommand.Parameters.AddWithValue("", categoria);
                miAdapter.SelectCommand.Parameters.AddWithValue("", idTipoInventario);
                miAdapter.SelectCommand.Parameters.AddWithValue("", idTipoInventario2);
                miAdapter.Fill(rowBase, rowMax, dataTable);
                foreach (DataRow row in dataTable.Rows)
                {
                    this.CodigoProducto = row["codigo"].ToString();

                    var row_ = miTabla.NewRow();
                    var color = new ElColor();
                    color.MapaBits = (string)row["color"];
                    row_["Marca"] = row["categoria"];
                    row_["Codigo"] = row["codigo"];
                    row_["Nombre"] = row["nombre"];
                    row_["Unidad"] = row["unidadmedida"];
                    row_["Medida"] = row["valorunidadmedida"];
                    row_["Color"] = color.ImagenBit;
                    row_["Inventario"] = row["cantidad"];
                    //row_["Valor"] = row["valor"];
                    if (Convert.ToBoolean(AppConfiguracion.ValorSeccion("costoMasIva")))
                    {
                        MiProducto = daoProducto.ProductoCompleto(row["codigo"].ToString());
                        row_["Valor"] = Convert.ToInt32(Convert.ToInt32(row["valor"]) +
                                        Convert.ToInt32(row["valor"]) * MiProducto.ValorIva / 100);
                    }
                    else
                    {
                        row_["Valor"] = row["valor"];
                    }
                    row_["Valor"] = Convert.ToDouble(row_["Valor"]) + Convert.ToDouble(row["impoconsumo"]);  // Adición de codigo para sumar el impoconsumo al costo del producto.

                    row_["DestoMayor"] = row["descto_mayor"];
                    row_["DestoDistri"] = row["descto_distribuidor"];
                    row_["Desto3"] = row["descto_3"];

                    row_["Venta"] = row["venta"];
                    /* row_["Mayorista"] = UseObject.Aproximar
                         (Convert.ToInt32(row["mayorista"]), Convert.ToBoolean(AppConfiguracion.ValorSeccion("tipo_aprox_precio")));
                     row_["Distribuidor"] = UseObject.Aproximar
                         (Convert.ToInt32(row["distribuidor"]), Convert.ToBoolean(AppConfiguracion.ValorSeccion("tipo_aprox_precio")));*/
                    //row_["Mayorista"] = row["mayorista"];
                    //row_["Distribuidor"] = row["distribuidor"];

                    // Edicion precio producto 18 Feb 2017-

                    if (this.RedondearPrecio2)
                    {
                        row_["Mayorista"] = UseObject.Aproximar(Convert.ToInt32(row["mayorista"]), this.aprox_precio);
                    }
                    else
                    {
                        row_["Mayorista"] = Convert.ToInt32(row["mayorista"]);
                    }
                    //row_["Mayorista"] = Convert.ToInt32(row["mayorista"]);
                    //                    row_["Mayorista"] = UseObject.Aproximar(Convert.ToInt32(row["mayorista"]), this.aprox_precio);
                    row_["Distribuidor"] = UseObject.Aproximar(Convert.ToInt32(row["distribuidor"]), this.aprox_precio);
                    row_["Precio4"] = UseObject.Aproximar(Convert.ToInt32(row["precio_4"]), this.aprox_precio);

                    // End edicion

                    miTabla.Rows.Add(row_);
                }
                dataTable.Clear();
                dataTable.Dispose();
                dataTable = null;
                return miTabla;
            }
            catch (Exception ex)
            {
                throw new Exception(ErrorProducto + "\n" + ex.Message + "\nProducto relacionado: " + this.CodigoProducto);
            }
        }

        public long GetRowsConsultaInventarioCategoria(bool compra, string categoria, int idTipoInventario, int idTipoInventario2)
        {
            try
            {
                if (compra)
                {
                    CargarComandoStoredProcedure("count_listar_inventario_producto_categoria_diferente");
                }
                else
                {
                    CargarComandoStoredProcedure("count_listar_inventario_producto_categoria");
                }
                miComando.Parameters.AddWithValue("", categoria);
                miComando.Parameters.AddWithValue("", idTipoInventario);
                miComando.Parameters.AddWithValue("", idTipoInventario2);
                miConexion.MiConexion.Open();
                var rows = Convert.ToInt64(miComando.ExecuteScalar());
                miConexion.MiConexion.Close();
                miComando.Dispose();
                return rows;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally { miConexion.MiConexion.Close(); }
        }

        // Funciones para impresion

        public DataTable ConsultaInventario(string codigo)
        {
            var dataTable = new DataTable();
            try
            {
                CargarAdapterStoredProcedure("listar_inventario_producto");
                miAdapter.SelectCommand.Parameters.AddWithValue("codigo", codigo);
                miAdapter.Fill(dataTable);
                return dataTable;
            }
            catch (Exception ex)
            {
                throw new Exception(ErrorProducto + ex.Message);
            }
        }

        public DataTable ConsultaInventarioNombre(string nombre)
        {
            var dataTable = new DataTable();
            try
            {
                CargarAdapterStoredProcedure("listar_inventario_producto_nombre");
                miAdapter.SelectCommand.Parameters.AddWithValue("nombre", nombre.ToUpper());
                miAdapter.Fill(dataTable);
                return dataTable;
            }
            catch (Exception ex)
            {
                throw new Exception(ErrorProducto + ex.Message);
            }
        }

        public DataTable ConsultaInventarioCategoria(string categoria)
        {
            var dataTable = new DataTable();
            try
            {
                CargarAdapterStoredProcedure("listar_inventario_producto_categoria");
                miAdapter.SelectCommand.Parameters.AddWithValue("categoria", categoria);
                miAdapter.Fill(dataTable);
                return dataTable;
            }
            catch (Exception ex)
            {
                throw new Exception(ErrorProducto + ex.Message);
            }
        }


        public DataTable ConsultaInventario_()
        {
           // var cod_prod = "";
            var dataTable = new DataTable();
            var miTabla = this.TablaInventario_();
            try
            {
                CargarAdapterStoredProcedure("listar_inventario_producto_");
                miAdapter.Fill(dataTable);
                foreach (DataRow row in dataTable.Rows)
                {
                    this.CodigoProducto = row["codigo"].ToString();
                    /*cod_prod = row["codigo"].ToString();

                    if (cod_prod == "123")
                    {
                        var j = cod_prod;
                    }*/

                    var row_ = miTabla.NewRow();
                    row_["categoria"] = row["categoria"];
                    row_["codigo"] = row["codigo"];
                    row_["nombre"] = row["nombre"];
                    row_["valorunidadmedida"] = row["medida"];
                    row_["cantidad"] = row["cantidad"];

                    if (Convert.ToBoolean(AppConfiguracion.ValorSeccion("costoMasIva")))
                    {
                       // MiProducto = daoProducto.ProductoCompleto(row["codigo"].ToString());

                        //if (MiProducto.CodigoInternoProducto == "16995")
                       // {
                           // var j_ = MiProducto.CodigoInternoProducto;
                       // }

                        /*if (MiProducto.CodigoInternoProducto == "2428")
                        {
                            var j__ = MiProducto.CodigoInternoProducto;
                        }*/

                        double vIva = Math.Round((Convert.ToDouble(row["costo"]) * Convert.ToDouble(row["iva"]) / 100), 2);
                      //  double j = Convert.ToDouble(row["costo"]) + vIva + Convert.ToDouble(row["impoconsumo"]);
                        row_["valor_mas_iva"] = Convert.ToDouble(row["costo"]) + vIva + Convert.ToDouble(row["impoconsumo"]);
                     //   var v = row_["valor_mas_iva"].ToString();
                    }
                    else
                    {
                        row_["valor_mas_iva"] = row["costo"];
                    }
                    row_["subtotal_mas_iva"] = Math.Round(Convert.ToDouble(row["cantidad"]) * Convert.ToInt32(row_["valor_mas_iva"]), 0);

                    row_["utilidad"] = row["utilidad"];
                    row_["precio"] = row["precio"];

                /*    row_["DestoMayor"] = row["descto_mayor"];
                    row_["DestoDistri"] = row["descto_distribuidor"];
                    row_["Desto3"] = row["descto_3"];

                    row_["Venta"] = row["venta"];

                    if (this.RedondearPrecio2)
                    {
                        row_["Mayorista"] = UseObject.Aproximar(Convert.ToInt32(row["mayorista"]), this.aprox_precio);
                    }
                    else
                    {
                        row_["Mayorista"] = Convert.ToInt32(row["mayorista"]);
                    }

                    row_["Distribuidor"] = UseObject.Aproximar(Convert.ToInt32(row["distribuidor"]), this.aprox_precio);
                    row_["Precio4"] = UseObject.Aproximar(Convert.ToInt32(row["precio_4"]), this.aprox_precio);*/
                    miTabla.Rows.Add(row_);
                }
                dataTable.Clear();
                dataTable.Dispose();
                dataTable = null;
                return miTabla;
            }
            catch (Exception ex)
            {
                throw new Exception(ErrorProducto + "\n" + ex.Message + "\nProducto relacionado: " + this.CodigoProducto);
            }
        }

        public DataTable ConsultaInventario_(string codigo)
        {
            var dataTable = new DataTable();
            var miTabla = this.TablaInventario_();
            try
            {
                CargarAdapterStoredProcedure("listar_inventario_producto_");
                this.miAdapter.SelectCommand.Parameters.AddWithValue("", codigo);
                miAdapter.Fill(dataTable);
                foreach (DataRow row in dataTable.Rows)
                {
                    var row_ = miTabla.NewRow();
                    row_["categoria"] = row["categoria"];
                    row_["codigo"] = row["codigo"];
                    row_["nombre"] = row["nombre"];
                    row_["valorunidadmedida"] = row["medida"];
                    row_["cantidad"] = row["cantidad"];

                    if (Convert.ToBoolean(AppConfiguracion.ValorSeccion("costoMasIva")))
                    {
                        // MiProducto = daoProducto.ProductoCompleto(row["codigo"].ToString());

                     /*   if (MiProducto.CodigoInternoProducto == "16995")
                        {
                            var j_ = MiProducto.CodigoInternoProducto;
                        }

                        if (MiProducto.CodigoInternoProducto == "2428")
                        {
                            var j__ = MiProducto.CodigoInternoProducto;
                        }*/

                        double vIva = Math.Round((Convert.ToDouble(row["costo"]) * Convert.ToDouble(row["iva"]) / 100), 2);
                        //double j = Convert.ToDouble(row["costo"]) + vIva;
                        row_["valor_mas_iva"] = Convert.ToDouble(row["costo"]) + vIva + Convert.ToDouble(row["impoconsumo"]);
                        //var v = row_["valor_mas_iva"].ToString();
                    }
                    else
                    {
                        row_["valor_mas_iva"] = row["costo"];
                    }
                    row_["subtotal_mas_iva"] = Math.Round(Convert.ToDouble(row["cantidad"]) * Convert.ToInt32(row_["valor_mas_iva"]), 0);

                    /*    row_["DestoMayor"] = row["descto_mayor"];
                        row_["DestoDistri"] = row["descto_distribuidor"];
                        row_["Desto3"] = row["descto_3"];

                        row_["Venta"] = row["venta"];

                        if (this.RedondearPrecio2)
                        {
                            row_["Mayorista"] = UseObject.Aproximar(Convert.ToInt32(row["mayorista"]), this.aprox_precio);
                        }
                        else
                        {
                            row_["Mayorista"] = Convert.ToInt32(row["mayorista"]);
                        }

                        row_["Distribuidor"] = UseObject.Aproximar(Convert.ToInt32(row["distribuidor"]), this.aprox_precio);
                        row_["Precio4"] = UseObject.Aproximar(Convert.ToInt32(row["precio_4"]), this.aprox_precio);*/
                    miTabla.Rows.Add(row_);
                }
                dataTable.Clear();
                dataTable.Dispose();
                dataTable = null;
                return miTabla;
            }
            catch (Exception ex)
            {
                throw new Exception(ErrorProducto + "\n" + ex.Message + "\nProducto relacionado: " + this.CodigoProducto);
            }
        }

        public DataTable ConsultaInventarioCategoria_(string codCategoria)
        {
            var dataTable = new DataTable();
            var miTabla = this.TablaInventario_();
            try
            {
                CargarAdapterStoredProcedure("listar_inventario_producto_categoria_");
                this.miAdapter.SelectCommand.Parameters.AddWithValue("", codCategoria);
                miAdapter.Fill(dataTable);
                foreach (DataRow row in dataTable.Rows)
                {
                    var row_ = miTabla.NewRow();
                    row_["categoria"] = row["categoria"];
                    row_["codigo"] = row["codigo"];
                    row_["nombre"] = row["nombre"];
                    row_["valorunidadmedida"] = row["medida"];
                    row_["cantidad"] = row["cantidad"];

                    if (Convert.ToBoolean(AppConfiguracion.ValorSeccion("costoMasIva")))
                    {
                        // MiProducto = daoProducto.ProductoCompleto(row["codigo"].ToString());

                       /* if (MiProducto.CodigoInternoProducto == "16995")
                        {
                            var j_ = MiProducto.CodigoInternoProducto;
                        }

                        if (MiProducto.CodigoInternoProducto == "2428")
                        {
                            var j__ = MiProducto.CodigoInternoProducto;
                        }*/

                        double vIva = Math.Round((Convert.ToDouble(row["costo"]) * Convert.ToDouble(row["iva"]) / 100), 2);
                        //double j = Convert.ToDouble(row["costo"]) + vIva;
                        row_["valor_mas_iva"] = Convert.ToDouble(row["costo"]) + vIva + Convert.ToDouble(row["impoconsumo"]);
                        //var v = row_["valor_mas_iva"].ToString();
                    }
                    else
                    {
                        row_["valor_mas_iva"] = row["costo"];
                    }
                    row_["subtotal_mas_iva"] = Math.Round(Convert.ToDouble(row["cantidad"]) * Convert.ToInt32(row_["valor_mas_iva"]), 0);

                    /*    row_["DestoMayor"] = row["descto_mayor"];
                        row_["DestoDistri"] = row["descto_distribuidor"];
                        row_["Desto3"] = row["descto_3"];

                        row_["Venta"] = row["venta"];

                        if (this.RedondearPrecio2)
                        {
                            row_["Mayorista"] = UseObject.Aproximar(Convert.ToInt32(row["mayorista"]), this.aprox_precio);
                        }
                        else
                        {
                            row_["Mayorista"] = Convert.ToInt32(row["mayorista"]);
                        }

                        row_["Distribuidor"] = UseObject.Aproximar(Convert.ToInt32(row["distribuidor"]), this.aprox_precio);
                        row_["Precio4"] = UseObject.Aproximar(Convert.ToInt32(row["precio_4"]), this.aprox_precio);*/
                    miTabla.Rows.Add(row_);
                }
                dataTable.Clear();
                dataTable.Dispose();
                dataTable = null;
                return miTabla;
            }
            catch (Exception ex)
            {
                throw new Exception(ErrorProducto + "\n" + ex.Message + "\nProducto relacionado: " + this.CodigoProducto);
            }
        }

        public DataTable ConsultaInventarioNombre_(string nombre)
        {
            var dataTable = new DataTable();
            var miTabla = this.TablaInventario_();
            try
            {
                CargarAdapterStoredProcedure("listar_inventario_producto_nombre_");
                this.miAdapter.SelectCommand.Parameters.AddWithValue("", nombre);
                miAdapter.Fill(dataTable);
                foreach (DataRow row in dataTable.Rows)
                {
                    var row_ = miTabla.NewRow();
                    row_["categoria"] = row["categoria"];
                    row_["codigo"] = row["codigo"];
                    row_["nombre"] = row["nombre"];
                    row_["valorunidadmedida"] = row["medida"];
                    row_["cantidad"] = row["cantidad"];

                    if (Convert.ToBoolean(AppConfiguracion.ValorSeccion("costoMasIva")))
                    {
                        // MiProducto = daoProducto.ProductoCompleto(row["codigo"].ToString());

                       /* if (MiProducto.CodigoInternoProducto == "16995")
                        {
                            var j_ = MiProducto.CodigoInternoProducto;
                        }

                        if (MiProducto.CodigoInternoProducto == "2428")
                        {
                            var j__ = MiProducto.CodigoInternoProducto;
                        }*/

                        double vIva = Math.Round((Convert.ToDouble(row["costo"]) * Convert.ToDouble(row["iva"]) / 100), 2);
                        //double j = Convert.ToDouble(row["costo"]) + vIva;
                        row_["valor_mas_iva"] = Convert.ToDouble(row["costo"]) + vIva + Convert.ToDouble(row["impoconsumo"]);
                        //var v = row_["valor_mas_iva"].ToString();
                    }
                    else
                    {
                        row_["valor_mas_iva"] = row["costo"];
                    }
                    row_["subtotal_mas_iva"] = Math.Round(Convert.ToDouble(row["cantidad"]) * Convert.ToInt32(row_["valor_mas_iva"]), 0);

                    /*    row_["DestoMayor"] = row["descto_mayor"];
                        row_["DestoDistri"] = row["descto_distribuidor"];
                        row_["Desto3"] = row["descto_3"];

                        row_["Venta"] = row["venta"];

                        if (this.RedondearPrecio2)
                        {
                            row_["Mayorista"] = UseObject.Aproximar(Convert.ToInt32(row["mayorista"]), this.aprox_precio);
                        }
                        else
                        {
                            row_["Mayorista"] = Convert.ToInt32(row["mayorista"]);
                        }

                        row_["Distribuidor"] = UseObject.Aproximar(Convert.ToInt32(row["distribuidor"]), this.aprox_precio);
                        row_["Precio4"] = UseObject.Aproximar(Convert.ToInt32(row["precio_4"]), this.aprox_precio);*/
                    miTabla.Rows.Add(row_);
                }
                dataTable.Clear();
                dataTable.Dispose();
                dataTable = null;
                return miTabla;
            }
            catch (Exception ex)
            {
                throw new Exception(ErrorProducto + "\n" + ex.Message + "\nProducto relacionado: " + this.CodigoProducto);
            }
        }


        public DataTable ConsultaInventarioPreciosVenta()
        {
            // var cod_prod = "";
            var dataTable = new DataTable();
            var miTabla = this.TablaInventario_();
            try
            {
                CargarAdapterStoredProcedure("listar_inventario_producto_");
                miAdapter.Fill(dataTable);
                foreach (DataRow row in dataTable.Rows)
                {
                    this.CodigoProducto = row["codigo"].ToString();
                    /*cod_prod = row["codigo"].ToString();

                    if (cod_prod == "123")
                    {
                        var j = cod_prod;
                    }*/

                    var row_ = miTabla.NewRow();
                    //row_["categoria"] = row["categoria"];
                    row_["codigo"] = row["codigo"];
                    row_["nombre"] = row["nombre"];
                    //row_["valorunidadmedida"] = row["medida"];
                    //row_["cantidad"] = row["cantidad"];

                    if (Convert.ToBoolean(AppConfiguracion.ValorSeccion("costoMasIva")))
                    {
                        // MiProducto = daoProducto.ProductoCompleto(row["codigo"].ToString());

                        //if (MiProducto.CodigoInternoProducto == "16995")
                        // {
                        // var j_ = MiProducto.CodigoInternoProducto;
                        // }

                        /*if (MiProducto.CodigoInternoProducto == "2428")
                        {
                            var j__ = MiProducto.CodigoInternoProducto;
                        }*/

                        double vIva = Math.Round((Convert.ToDouble(row["costo"]) * Convert.ToDouble(row["iva"]) / 100), 2);
                        //  double j = Convert.ToDouble(row["costo"]) + vIva + Convert.ToDouble(row["impoconsumo"]);
                        row_["valor_mas_iva"] = Convert.ToDouble(row["costo"]) + vIva + Convert.ToDouble(row["impoconsumo"]);
                        //   var v = row_["valor_mas_iva"].ToString();
                    }
                    else
                    {
                        row_["valor_mas_iva"] = row["costo"];
                    }
                    row_["subtotal_mas_iva"] = Math.Round(Convert.ToDouble(row["cantidad"]) * Convert.ToInt32(row_["valor_mas_iva"]), 0);

                    /*    row_["DestoMayor"] = row["descto_mayor"];
                        row_["DestoDistri"] = row["descto_distribuidor"];
                        row_["Desto3"] = row["descto_3"];*/

                        row_["Venta"] = row["venta"];

                        if (this.RedondearPrecio2)
                        {
                            row_["Mayorista"] = UseObject.Aproximar(Convert.ToInt32(row["mayorista"]), this.aprox_precio);
                        }
                        else
                        {
                            row_["Mayorista"] = Convert.ToInt32(row["mayorista"]);
                        }

                        row_["Distribuidor"] = UseObject.Aproximar(Convert.ToInt32(row["distribuidor"]), this.aprox_precio);
                        row_["Precio4"] = UseObject.Aproximar(Convert.ToInt32(row["precio_4"]), this.aprox_precio);
                    miTabla.Rows.Add(row_);
                }
                dataTable.Clear();
                dataTable.Dispose();
                dataTable = null;
                return miTabla;
            }
            catch (Exception ex)
            {
                throw new Exception(ErrorProducto + "\n" + ex.Message + "\nProducto relacionado: " + this.CodigoProducto);
            }
        }


        private DataTable TablaInventario_()
        {
            var tabla = new DataTable();
            tabla.Columns.Add(new DataColumn("categoria", typeof(string)));
            tabla.Columns.Add(new DataColumn("codigo", typeof(string)));
            tabla.Columns.Add(new DataColumn("nombre", typeof(string)));
            tabla.Columns.Add(new DataColumn("valorunidadmedida", typeof(string)));
            tabla.Columns.Add(new DataColumn("cantidad", typeof(double)));
            tabla.Columns.Add(new DataColumn("valor_mas_iva", typeof(int)));
            tabla.Columns.Add(new DataColumn("subtotal_mas_iva", typeof(int)));

            tabla.Columns.Add(new DataColumn("utilidad", typeof(double)));
            tabla.Columns.Add(new DataColumn("precio", typeof(int)));
            return tabla;
        }


        public void VerCodigosRepetidosInventario()
        {
            try
            {
                System.Collections.Generic.List<string> codigos = new System.Collections.Generic.List<string>();
                var tabla1 = new DataTable();
                var tabla2 = new DataTable();

                string sql = "select * from inventario;";
                miAdapter = new NpgsqlDataAdapter(sql, miConexion.MiConexion);
                miAdapter.SelectCommand.CommandType = CommandType.Text;
                miAdapter.Fill(tabla1);

                miAdapter = new NpgsqlDataAdapter(sql, miConexion.MiConexion);
                miAdapter.SelectCommand.CommandType = CommandType.Text;
                miAdapter.Fill(tabla2);

                foreach (DataRow row1 in tabla1.Rows)
                {
                    var query = tabla2.AsEnumerable().Where(t => t.Field<string>("codigointernoproducto").Equals(row1["codigointernoproducto"].ToString()));
                    if (query.Count() > 1)
                    {
                        codigos.Add(row1["codigointernoproducto"].ToString());
                    }
                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        public void EditarCantidadInventarioFisico(int id, double cantidad)
        {
            try
            {
                CargarComandoStoredProcedure("editar_cantidad_inventario_fisico");
                miComando.Parameters.AddWithValue("", id);
                miComando.Parameters.AddWithValue("", cantidad);
                miConexion.MiConexion.Open();
                miComando.ExecuteNonQuery();
                miConexion.MiConexion.Close();
                miComando.Dispose();
            }
            catch (Exception ex)
            {
                throw new Exception("" + ex.Message);
            }
            finally { miConexion.MiConexion.Close(); }
        }



        /// <summary>
        /// Inicializa una nueva instancia de NpgsqlCommand de tipo Stored Procedure.
        /// </summary>
        /// <param name="cmd">Comando a ejecutar.</param>
        private void CargarComandoStoredProcedure(string cmd)
        {
            this.miComando = new NpgsqlCommand();
            this.miComando.Connection = this.miConexion.MiConexion;
            this.miComando.CommandType = CommandType.StoredProcedure;
            this.miComando.CommandText = cmd;
        }

        private void CargarComandoText(string cmd)
        {
            this.miComando = new NpgsqlCommand();
            this.miComando.Connection = this.miConexion.MiConexion;
            this.miComando.CommandType = CommandType.Text;
            this.miComando.CommandText = cmd;
        }

        /// <summary>
        /// Inicializa una nueva instancia de NpgsqlDataAdapter de tipo StoredProcedure.
        /// </summary>
        /// <param name="cmd">Comando o Procedimiento a ejecutar.</param>
        private void CargarAdapterStoredProcedure(string cmd)
        {
            miAdapter = new NpgsqlDataAdapter(cmd, miConexion.MiConexion);
            miAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
        }
    }
}