using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DTO.Clases;
using Npgsql;
using System.Data;

namespace DataAccessLayer.Clases
{
    public class DaoPromocion
    {
        /// <summary>
        /// representa una sentencia sql en postgres.
        /// </summary>
        private NpgsqlCommand miComando;

        /// <summary>
        /// Representa un adapter de sqlposgres
        /// </summary>
        private NpgsqlDataAdapter miAdapter;

        /// <summary>
        /// Objeto de conexion a la base de datos postgressql
        /// </summary>
        private Conexion miConexion;

        /// <summary>
        /// Representa una tabla de datos en memoria.
        /// </summary>
        private DataTable miDatatable;

        /// <summary>
        /// Representa una cache de datos en memoria
        /// </summary>
        private DataSet miDataSet;

        /// <summary>
        /// Representa la función insertar_promocion.
        /// </summary>
        private string sqlIngresarPromocion = "insertar_promocion";        

        /// <summary>
        /// Representa la función editar_promocion.
        /// </summary>
        private string sqlEditaPromocion = "editar_promocion";

        /// <summary>
        /// Representa la función eliminar_promocion.
        /// </summary>
        private string sqlEliminaPromocion = "eliminar_promocion";

        /// <summary>
        /// Representa la función listar_promocion_marca_fechas.
        /// </summary>
        private string sqlConsultarPromocionMarcaFecha = "listar_promocion_marca_fechas";

        /// <summary>
        /// Representa la función listar_promocion_categoria_fechas.
        /// </summary>
        private string sqlConsultarPromocionCategoriaFecha = "listar_promocion_categoria_fechas";

        /// <summary>
        /// Representa la función listar_promocion_producto_fechas.
        /// </summary>
        private string sqlConsultarPromocionProductoFechas = "listar_promocion_producto_fechas";

        /// <summary>
        /// Representa la función listar_promocion_marca_fechas.
        /// </summary>
        private string sqlConsultarPromocionMarca = "listar_promocion_marca_fechas";

        /// <summary>
        /// Representa la función listar_promocion_categoria_fechas
        /// </summary>
        private string sqlConsultarPromocionCategoria = "listar_promocion_categoria_fechas";

        /// <summary>
        /// Representa la función listar_promocion_producto_fechas
        /// </summary>
        private string sqlConsultarPromocionProducto = "listar_promocion_producto_fechas";

        /// <summary>
        /// Representa la función listar_promocion_marca_periodos.
        /// </summary>
        private string sqlConsultarPromocionMarcaPeriodo = "listar_promocion_marca_periodos";

        /// <summary>
        /// Representa la función listar_promocion_catrgoria_periodos.
        /// </summary>
        private string sqlConsultarPromocionCategoriaPeriodo = "listar_promocion_catrgoria_periodos";

        /// <summary>
        /// Representa la función listar_promocion_producto_periodos.
        /// </summary>
        private string sqlConsultarPromocionProductoPeriodo = "listar_promocion_producto_periodos";

        /// <summary>
        /// Representa la función listar_promocion_marca_periodos.
        /// </summary>
        private string sqlConsultarPromocionPeriodoMarca = "listar_promocion_marca_periodos";

        /// <summary>
        /// Representa la función listar_promocion_categoria_periodos.
        /// </summary>
        private string sqlConsultarPromocionPeriodoCategoria = "listar_promocion_categoria_periodos";

        /// <summary>
        /// Representa la función listar_promocion_producto_periodos
        /// </summary>
        private string sqlConsultarPromocionPeriodoProducto = "listar_promocion_producto_periodos";

        /// <summary>
        /// Representa la funcion listar_promocion_marca_completo.
        /// </summary>
        private string sqlListaCompletaPromocionMarca = "listar_promocion_marca_completo";

        /// <summary>
        /// Representa la función listar_promocion_categoria_completo.
        /// </summary>
        private string sqlListaCompletaPromocionCategoria = "listar_promocion_categoria_completo";

        /// <summary>
        /// Representa la función listar_promocion_producto_completo.
        /// </summary>
        private string sqlListaCompletaPromocionProducto = "listar_promocion_producto_completo";

        /// <summary>
        /// Representa la función existe_promocion_marca.
        /// </summary>
        private string sqlExistePromocionMarca = "existe_promocion_marca";

        /// <summary>
        /// Representa la función existe_promocion_categoria.
        /// </summary>
        private string sqlExistePromocionCategoria = "existe_promocion_categoria";

        /// <summary>
        /// Representa la funcion existe_promocion_producto.
        /// </summary>
        private string sqlExistePromocionProducto = "existe_promocion_producto";

        public DaoPromocion()
        {
            miConexion = new Conexion();
        }

        /// <summary>
        /// Insertar promoción.
        /// </summary>
        /// <param name="promocion">objeto promoción a insertar</param>
        public void InsertarPromocion(Promocion promocion)
        {
            var miDaomarca=new DaoMarca();
            var miDaoCategoria=new DaoCategoria();
            var miDaoProducto=new DaoProducto();
            try
            {
                CargarComandoStoreProsedure(sqlIngresarPromocion);
                miComando.Parameters.AddWithValue("idtipoPromocion", promocion.idTipo);
                miComando.Parameters.AddWithValue("iddescuento", promocion.idDescuento);
                miComando.Parameters.AddWithValue("fechaInicio", promocion.fechaInicio);
                miComando.Parameters.AddWithValue("fechaFin", promocion.fechaFin);
                miConexion.MiConexion.Open();
                var id = (int)miComando.ExecuteScalar();
                miConexion.MiConexion.Close();
                miComando.Dispose();
                if (promocion.idTipo == 2)
                {
                    
                        miDaomarca.InsertarpromocionMarca(id,promocion.Marca);
                    
                }
                else
                {
                    if (promocion.idTipo == 3)
                    {
                        
                            miDaoCategoria.InsertarPromocionCategoria(id,promocion.Categoria);
                        
                    }
                    else
                    {
                        if (promocion.idTipo == 4)
                        {
                            
                                miDaoProducto.InsertarProductoPromocion(id, promocion.Producto, promocion.cantidad);
                            
                        }
                    }
                }
            }
            catch(Exception ex)
            {
                throw new Exception("Error al insertar promoción. \n" + ex.Message);
            }
            finally
            {
                miConexion.MiConexion.Close();
            }
        }

        /// <summary>
        /// Editar promoción
        /// </summary>
        /// <param name="promocion">objeto promoción a editar</param>
        public void EditarPromocion(Promocion promocion)
        {
            var miDaoMarca = new DaoMarca();
            var miDaoCategoria = new DaoCategoria();
            var miDaoProducto = new DaoProducto();
            try
            {
                CargarComandoStoreProsedure(sqlEditaPromocion);
                miComando.Parameters.AddWithValue("idPromocion", promocion.idPromocion);
                miComando.Parameters.AddWithValue("idTipo", promocion.idTipo);                
                miComando.Parameters.AddWithValue("idDesciento", promocion.idDescuento);                
                miComando.Parameters.AddWithValue("fechaInicio", promocion.fechaInicio);
                miComando.Parameters.AddWithValue("fechaFin", promocion.fechaFin);
                miConexion.MiConexion.Open();
                miComando.ExecuteNonQuery();
                miConexion.MiConexion.Close();
                miComando.Dispose();
                if (promocion.idTipo == 2)
                {
                    miDaoMarca.EditarPromocionMarca(promocion.idPromocion, promocion.Marca);
                }
                else
                {
                    if (promocion.idTipo == 3)
                    {
                        miDaoCategoria.EditaPromocionCategoria(promocion.idPromocion, promocion.Categoria);
                    }
                    else
                    {
                        miDaoProducto.EditarProductoPromocion(promocion.idPromocion, promocion.Producto, promocion.cantidad);
                    }
                }
                
            }
            catch(Exception ex)
            {
                throw new Exception("Error al modificar la promoción. \n" + ex.Message);
            }
            finally
            {
                miConexion.MiConexion.Close();
            }
        }

        /// <summary>
        /// Elimina promoción
        /// </summary>
        /// <param name="idPromocion">id promoción a eliminar</param>
        public void EliminaPromocion(int idPromocion)
        {
            try
            {
                CargarComandoStoreProsedure(sqlEliminaPromocion);
                miComando.Parameters.AddWithValue("idPromocion", idPromocion);
                miConexion.MiConexion.Open();
                miComando.ExecuteNonQuery();
                miConexion.MiConexion.Close();
                miComando.Dispose();
            }
            catch(Exception ex)
            {
                throw new Exception("Error al eliminar la promoción. \n" + ex.Message);
            }
            finally
            {
                miConexion.MiConexion.Close();
            }
        }

        /// <summary>
        /// Consulta promoción marca fecha
        /// </summary>
        /// <param name="idTipo">id tipo promoción(marca) a consultar</param>
        /// <param name="idMarca">id marca a consultar</param>
        /// <param name="fecha">fecha a consultar</param>
        /// <returns></returns>
        public DataTable ConsultarPromocionMarcaFechas(int idTipo, int idMarca, DateTime fecha)
        {           
            try
            {
                miDatatable = new DataTable();
                CargarAdapterStoreProsedure(sqlConsultarPromocionMarcaFecha);
                miAdapter.SelectCommand.Parameters.AddWithValue("idtipo", idTipo);
                miAdapter.SelectCommand.Parameters.AddWithValue("idMarca", idMarca);
                miAdapter.SelectCommand.Parameters.AddWithValue("fecha", fecha);
                this.miAdapter.Fill(miDatatable);
                return miDatatable;
            }
            catch(Exception ex)
            {
                throw new Exception("Error al consultar las promoción marca. \n" + ex.Message);
            }
        }

        /// <summary>
        /// Consulta promoción tipo marca fechas
        /// </summary>
        /// <param name="idTipo">id tipo promoción (marca)a consultar</param>
        /// <param name="fecha">fecha a consultar</param>
        /// <param name="registroBase">registro base de la consulta</param>
        /// <param name="registroMaximo">número de registros a recuperar</param>
        /// <returns></returns>
        public DataTable ConsultarPromocionMarcaFechas(int idTipo, DateTime fecha, int registroBase, int registroMaximo)
        {
            miDataSet = new DataSet();
            try
            {
                CargarAdapterStoreProsedure(sqlConsultarPromocionMarca);
                miAdapter.SelectCommand.Parameters.AddWithValue("idtipo", idTipo);
                miAdapter.SelectCommand.Parameters.AddWithValue("fecha", fecha);
                miAdapter.Fill(miDataSet, registroBase, registroMaximo, "promocion");
                return miDataSet.Tables[0];
            }
            catch (Exception ex)
            {
                throw new Exception("Error al consultar promoción marca. \n" + ex.Message);
            }
        }

        /// <summary>
        /// Obtiene el total de los registros de promoción marca fechas.
        /// </summary>
        /// <param name="idTipo">id tipo promoción(marca)a consultar</param>
        /// <param name="fechas">fecha a consultar</param>
        /// <returns></returns>
        public long RowListarPromocionMarca(int idTipo, DateTime fechas)
        {
            try
            {
                CargarComandoStoreProsedure("count_listar_promocion_marca");
                miComando.Parameters.AddWithValue("idtipo", idTipo);
                miComando.Parameters.AddWithValue("fechas", fechas);
                miConexion.MiConexion.Open();
                var rows = Convert.ToInt64(miComando.ExecuteScalar());
                miConexion.MiConexion.Close();
                miComando.Dispose();
                return rows;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocorrio un error al cargar los registros de promoción marca. \n " + ex.Message);
            }
            finally
            {
                miConexion.MiConexion.Close();
            }
        }

        /// <summary>
        /// Consulta promoción marca periodos
        /// </summary>
        /// <param name="idTipo">id tipo promoción a consultar</param>
        /// <param name="idMarca">id marca a consultar</param>
        /// <param name="fecha1">fecha inicio a consultar</param>
        /// <param name="fecha2">fecha fin a consultar</param>
        /// <returns></returns>
        public DataTable ConsultarPromocionMarcaPeriodo(int idTipo, int idMarca, DateTime fecha1, DateTime fecha2, int registroBase,int registroMaximo)
        {
            try
            {

                miDataSet = new DataSet();
                CargarAdapterStoreProsedure(sqlConsultarPromocionMarcaPeriodo);
                miAdapter.SelectCommand.Parameters.AddWithValue("idtipo", idTipo);
                miAdapter.SelectCommand.Parameters.AddWithValue("idmarca", idMarca);
                miAdapter.SelectCommand.Parameters.AddWithValue("fecha1", fecha1);
                miAdapter.SelectCommand.Parameters.AddWithValue("fecha2", fecha2);
                miAdapter.Fill(miDataSet, registroBase, registroMaximo, "promocion");
                return miDataSet.Tables[0];
            }
            catch (Exception ex)
            {
                throw new Exception("Error al consultar promoción marca periodos. \n" + ex.Message);
            }
        }

        /// <summary>
        /// Obtiene el total de los registros de promoción marca fechas
        /// </summary>
        /// <param name="idTipo"> id tipo promoción(marca)a consultar</param>
        /// <param name="idMarca"> id marca a consultar</param>
        /// <param name="fecha1">fecha inicio a consultar</param>
        /// <param name="fecha2">fecha fin a consultar</param>
        /// <returns></returns>
        public long RowListarPromocionMarcaFechas(int idTipo, int idMarca, DateTime fecha1, DateTime fecha2)
        {
            try
            {
                CargarComandoStoreProsedure("count_listar_promocion_marca");
                miComando.Parameters.AddWithValue("idtipo", idTipo);
                miComando.Parameters.AddWithValue("idmarca", idMarca);
                miComando.Parameters.AddWithValue("fecah1", fecha1);
                miComando.Parameters.AddWithValue("fecha2", fecha2);
                miConexion.MiConexion.Open();
                var rows = Convert.ToInt64(miComando.ExecuteScalar());
                miConexion.MiConexion.Close();
                miConexion.MiConexion.Close();
                miComando.Dispose();
                return rows;
            }
            catch(Exception ex)
            {
                throw new Exception("Ocorrio un error al cargar el sorteo marca periodos. \n" + ex.Message);
            }
            finally
            {
                miConexion.MiConexion.Close();
            }
        }

        /// <summary>
        /// Consulta promoción tipo marca periodo
        /// </summary>
        /// <param name="idTipo">id tipo promoción(marca)a consultar</param>
        /// <param name="fecha1">fecha inicio a consultar</param>
        /// <param name="fecha2">fecha fin a consultar</param>
        /// <param name="registroBase">registro base de la consulta</param>
        /// <param name="registroMaximo">número de registros a recuperar</param>
        /// <returns></returns>
        public DataTable ConsultarPromocionMarcaPeriodo(int idTipo, DateTime fecha1, DateTime fecha2, int registroBase, int registroMaximo)
        {
            miDataSet= new DataSet();
            try
            {
                CargarAdapterStoreProsedure(sqlConsultarPromocionPeriodoMarca);
                miAdapter.SelectCommand.Parameters.AddWithValue("idtipo", idTipo);
                miAdapter.SelectCommand.Parameters.AddWithValue("fecha1", fecha1);
                miAdapter.SelectCommand.Parameters.AddWithValue("fecha2", fecha2);
                miAdapter.Fill(miDataSet, registroBase, registroMaximo, "promocion");
                return miDataSet.Tables[0];
            }
            catch (Exception ex)
            {
                throw new Exception("Error al consultar promoción marca periodo. \n" + ex.Message);
            }
        }


        /// <summary>
        /// Obtiene el total de los registros de promoción marca periodos.
        /// </summary>
        /// <param name="idTipo">id tipo promoción(marca)a consultar</param>
        /// <param name="fecha1">fecha inicio a consultar</param>
        /// <param name="fecha2">fecha fin a consultar</param>
        /// <returns></returns>
        public long RowListarPromocionMarca(int idTipo, DateTime fecha1, DateTime fecha2)
        {
            try
            {
                CargarComandoStoreProsedure("count_listar_promocion_marca");
                miComando.Parameters.AddWithValue("idtipo", idTipo);
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
                throw new Exception("Ocurrio un error al cargar promoción marca periodos. \n" + ex.Message);

            }
            finally
            {
                miConexion.MiConexion.Close();
            }
        }

        /// <summary>
        /// Consulta promoción categoría fecha
        /// </summary>
        /// <param name="idTipo">id tipo promoción(categoría)a consultar</param>
        /// <param name="CodigoCategoria">código categoría a consultar</param>
        /// <param name="fecha">fecha a consultar</param>
        /// <returns></returns>
        public DataTable ConsultarPromocionCategoriaFechas(int idTipo, string CodigoCategoria, DateTime fecha)
        {
            try
            {
                miDatatable = new DataTable();
                CargarAdapterStoreProsedure(sqlConsultarPromocionCategoriaFecha);
                miAdapter.SelectCommand.Parameters.AddWithValue("idtipopromocion", idTipo);
                miAdapter.SelectCommand.Parameters.AddWithValue("CodigoCategoria", CodigoCategoria);
                miAdapter.SelectCommand.Parameters.AddWithValue("fecha", fecha);
                miAdapter.Fill(miDatatable);
                return miDatatable;
            }
            catch(Exception ex)
            {
                throw new Exception("Error al consultar promoción categoría. \n"+ex.Message);
            }
        }

        /// <summary>
        /// Consultar promoción tipo categoría fechas
        /// </summary>
        /// <param name="idTipo">id tipo promoción(categoría) a consultar</param>
        /// <param name="fecha">fecha a consultar</param>
        /// <param name="registroBase">registro base  de la consulta</param>
        /// <param name="registroMaximo">número de registros a recuperar</param>
        /// <returns></returns>
        public DataTable ConsultarPromocionCategoriaFechas(int idTipo, DateTime fecha, int registroBase, int registroMaximo)
        {
            miDataSet = new DataSet();
            try
            {
                CargarAdapterStoreProsedure(sqlConsultarPromocionCategoria);
                miAdapter.SelectCommand.Parameters.AddWithValue("idtipo", idTipo);
                miAdapter.SelectCommand.Parameters.AddWithValue("fecha", fecha);
                miAdapter.Fill(miDataSet, registroBase, registroMaximo, "promocion");
                return miDataSet.Tables[0];
            }
            catch (Exception ex)
            {
                throw new Exception("Error al consultar promoción categoría. \n" + ex.Message);
            }
        }

        /// <summary>
        /// Obtiene el total de los registros de promoción categoría fechas.
        /// </summary>
        /// <param name="idTipo">id tipo promoción(categoría) a consultar</param>
        /// <param name="fechas">fecha a consultar</param>
        /// <returns></returns>
        public long RowListarPromocionCategoria(int idTipo, DateTime fechas)
        {
            try
            {
                CargarComandoStoreProsedure("count_listar_promocion_categoria");
                miComando.Parameters.AddWithValue("idtipo", idTipo);
                miComando.Parameters.AddWithValue("fechas", fechas);
                miConexion.MiConexion.Open();
                var rows = Convert.ToInt64(miComando.ExecuteScalar());
                miConexion.MiConexion.Close();
                miComando.Dispose();
                return rows;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrio un error al cargar promoción Categoría. \n" + ex.Message);
            }
            finally
            {
                miConexion.MiConexion.Close();
            }
        }

        /// <summary>
        /// Consulta promoción categoría periodo
        /// </summary>
        /// <param name="idTipo">id tipo promoción(categoría)a consultar</param>
        /// <param name="codigoCategoria">código categoría a consultar</param>
        /// <param name="fecha1">fecha inicio a consultar</param>
        /// <param name="fecha2">fecha fin a consultar</param>
        /// <returns></returns>
        public DataTable ConsultarPromocionCategoriaPeriodo(int idTipo, string codigoCategoria, DateTime fecha1, DateTime fecha2, int registroBase,int registroMaximo)
        {
            try
            {
                miDataSet = new DataSet();
                CargarAdapterStoreProsedure(sqlConsultarPromocionCategoriaPeriodo);
                miAdapter.SelectCommand.Parameters.AddWithValue("idtipo", idTipo);
                miAdapter.SelectCommand.Parameters.AddWithValue("codigoCategoria", codigoCategoria);
                miAdapter.SelectCommand.Parameters.AddWithValue("fecha1", fecha1);
                miAdapter.SelectCommand.Parameters.AddWithValue("fecha2", fecha2);
                miAdapter.Fill(miDataSet,registroBase,registroMaximo,"Promocion");
                return miDataSet.Tables[0];
            }
            catch (Exception ex)
            {
                throw new Exception("Error al consultar promoción categoría periodo. \n" + ex.Message);
            }
        }

        /// <summary>
        /// Obtiene el total de los registros de promoción categoría fechas
        /// </summary>
        /// <param name="idTipo">id tipo promoción(categoría)a consultar</param>
        /// <param name="codigocategoria">código categoría a consultar</param>
        /// <param name="fecha1"> fecha inicio a consultar</param>
        /// <param name="fecha2"> fecha fin a consultar</param>
        /// <returns></returns>
        public long RowListarPromocionCategoriafechas(int idTipo, string codigocategoria, DateTime fecha1, DateTime fecha2)
        {
            try
            {
                CargarComandoStoreProsedure("count_listar_promocion_categoria");
                miComando.Parameters.AddWithValue("idtipo", idTipo);
                miComando.Parameters.AddWithValue("codigocategoria", codigocategoria);
                miComando.Parameters.AddWithValue("fecha1", fecha1);
                miComando.Parameters.AddWithValue("fecha2", fecha2);
                miConexion.MiConexion.Open();
                var rows = Convert.ToInt64(miComando.ExecuteScalar());
                miConexion.MiConexion.Close();
                miComando.Dispose();
                return rows;
            }
            catch(Exception ex)
            {
                throw new Exception("Ocurrio un error al consultar promoción categoría fechas. \n" + ex.Message);
            }
            finally
            { }
        }

        /// <summary>
        /// Consultar promoción tipo categoría periodos
        /// </summary>
        /// <param name="idTipo">id tipo promoción (categoría)a consultar</param>
        /// <param name="fecha1">fecha inicio a consultar</param>
        /// <param name="fecha2">fecha fin a consultar</param>
        /// <param name="registroBase">registro base de la consulta</param>
        /// <param name="registroMaximo">número de registro a recuperar</param>
        /// <returns></returns>
        public DataTable ConsultarPromocionCategoriaPeriodo(int idTipo, DateTime fecha1, DateTime fecha2, int registroBase, int registroMaximo)
        {
            var dataset = new DataSet();
            try
            {
                CargarAdapterStoreProsedure(sqlConsultarPromocionPeriodoCategoria);
                miAdapter.SelectCommand.Parameters.AddWithValue("idTipo", idTipo);
                miAdapter.SelectCommand.Parameters.AddWithValue("fecha1", fecha1);
                miAdapter.SelectCommand.Parameters.AddWithValue("fecha2", fecha2);
                miAdapter.Fill(dataset, registroBase, registroMaximo, "promocion");
                return dataset.Tables[0];
            }
            catch (Exception ex)
            {
                throw new Exception("Error al consultar promoción categoría periodo. \n" + ex.Message);
            }
        }

        /// <summary>
        /// Obtiene el total de los registros de promoción categoría Periodo.
        /// </summary>
        /// <param name="idTipo">id tipo promoción(categoría)a consultar</param>
        /// <param name="fecha1">fecha inicio a consultar</param>
        /// <param name="fecha2">fecha fin a consultar</param>
        /// <returns></returns>
        public long RowListarPromocionCategoria(int idTipo, DateTime fecha1, DateTime fecha2)
        {
            try
            {
                CargarComandoStoreProsedure("count_listar_promocion_categoria");
                miComando.Parameters.AddWithValue("idtipo", idTipo);
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
                throw new Exception("Ocurrio un error al listar promoción categoría periodo. \n"+ex.Message);

            }
            finally
            {
                miConexion.MiConexion.Close();
            }
        }

        /// <summary>
        /// Consulta promoción producto fecha
        /// </summary>
        /// <param name="idTipo">id tipo promoción(producto)a consultar</param>
        /// <param name="codigoInternoProducto">código interno producto a consultar</param>
        /// <param name="fecha">fecha a consultar</param>
        /// <returns></returns>
        public DataTable ConsultarPromocionProductoFechas(int idTipo, string codigoInternoProducto, DateTime fecha)
        {
            try
            {
                miDatatable = new DataTable();
                CargarAdapterStoreProsedure(sqlConsultarPromocionProductoFechas);
                miAdapter.SelectCommand.Parameters.AddWithValue("idtipo", idTipo);
                miAdapter.SelectCommand.Parameters.AddWithValue("codigointernoproducto", codigoInternoProducto);
                miAdapter.SelectCommand.Parameters.AddWithValue("fecha", fecha);
                miAdapter.Fill(miDatatable);
                return miDatatable;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al consultar promoción producto por fechas. \n" + ex.Message);
            }
        }

        /// <summary>
        /// Consultar promoción tipo producto fechas
        /// </summary>
        /// <param name="idTipo">id tipo promoción(producto)a consultar</param>
        /// <param name="fecha">fecha a consultar</param>
        /// <param name="registroBase">registro base de la consulta</param>
        /// <param name="registroMaximo">número de registros a consultar</param>
        /// <returns></returns>
        public DataTable ConsultarPromocionProductoFechas(int idTipo, DateTime fecha, int registroBase, int registroMaximo)
        {
            miDataSet = new DataSet();
            try
            {

                CargarAdapterStoreProsedure(sqlConsultarPromocionProducto);
                miAdapter.SelectCommand.Parameters.AddWithValue("idtipo", idTipo);
                miAdapter.SelectCommand.Parameters.AddWithValue("fecha", fecha);
                miAdapter.Fill(miDataSet, registroBase, registroMaximo, "promocion");
                return miDataSet.Tables[0];
            }
            catch (Exception ex)
            {
                throw new Exception("Error al consultar promoción producto. \n" + ex.Message);
            }
        }

        /// <summary>
        /// Obtiene el total de los registros
        /// </summary>
        /// <param name="idTipo">id tipo promoción(producto)a consultar</param>
        /// <param name="fechas">fecha a consultar</param>
        /// <returns></returns>
        public long RowListarPromocionProducto(int idTipo, DateTime fechas)
        {
            try
            {
                CargarComandoStoreProsedure("count_listar_promocion_producto");
                miComando.Parameters.AddWithValue("idtipo", idTipo);
                miComando.Parameters.AddWithValue("fechas", fechas);
                miConexion.MiConexion.Open();
                var rows = Convert.ToInt64(miComando.ExecuteScalar());
                miConexion.MiConexion.Close();
                miComando.Dispose();
                return rows;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrio un error al cargar promoción. \n"+ex.Message);
            }
            finally
            {
                miConexion.MiConexion.Close();
            }
        }

        /// <summary>
        /// Consulta promoción producto periodo
        /// </summary>
        /// <param name="idTipo">id tipo promoción(producto)a consultar</param>
        /// <param name="codigoInternoProducto">código interno producto a consultar</param>
        /// <param name="fecha1">fecha inicio a consultar</param>
        /// <param name="fecha2">fecha fin a consultar</param>
        /// <returns></returns>
        public DataTable ConsultarPromocionProductoPeriodo
            (int idTipo, string codigoInternoProducto, DateTime fecha1, DateTime fecha2,int registroBase,int registroMaximo)
        {
            try
            {
                miDataSet = new DataSet();
                CargarAdapterStoreProsedure(sqlConsultarPromocionProductoPeriodo);
                miAdapter.SelectCommand.Parameters.AddWithValue("idtipo", idTipo);
                miAdapter.SelectCommand.Parameters.AddWithValue("codigoInternoProducto", codigoInternoProducto);
                miAdapter.SelectCommand.Parameters.AddWithValue("fecha1", fecha1);
                miAdapter.SelectCommand.Parameters.AddWithValue("fecha2", fecha2);
                miAdapter.Fill(miDataSet, registroBase, registroMaximo, "promocion");
                return miDataSet.Tables[0];
            }
            catch (Exception ex)
            {
                throw new Exception("Error al consultar promoción producto periodo. \n" + ex.Message);
            }
        }


        /// <summary>
        /// Obtiene el total de los registros de promoción producto fechas
        /// </summary>
        /// <param name="idTipo">id tipo promoción(producto)a consultar</param>
        /// <param name="CodigoInternoProducto"> código interno producto a consultar</param>
        /// <param name="fecah1">fecha inicio a consultar</param>
        /// <param name="fecha2">fecha fin a consultar</param>
        /// <returns></returns>
        public long RowListarPromocionProductoFechas
            (int idTipo, string CodigoInternoProducto, DateTime fecah1, DateTime fecha2)
        {
            try
            {
                CargarComandoStoreProsedure("count_listar_promocion_producto");
                miComando.Parameters.AddWithValue("idtipo", idTipo);
                miComando.Parameters.AddWithValue("codigointernoproducto", CodigoInternoProducto);
                miComando.Parameters.AddWithValue("fecha1", fecah1);
                miComando.Parameters.AddWithValue("fecah2", fecha2);
                miConexion.MiConexion.Open();
                var rows = Convert.ToInt64(miComando.ExecuteScalar());
                miConexion.MiConexion.Close();
                miComando.Dispose();
                return rows;
            }
            catch(Exception ex)
            {
                throw new Exception("Ocurrio un error al consultar promoción producto fechas. \n" + ex.Message);
            }
            finally
            {
                miConexion.MiConexion.Close();
            }
        }

        /// <summary>
        /// Consulta promoción tipo producto periodos
        /// </summary>
        /// <param name="idTipo">id tipo promoción(producto) a consultar </param>
        /// <param name="fecha1">fecha inicio a consultar</param>
        /// <param name="fecha2">fecha fin a consultar</param>
        /// <param name="registroBase">registro base de la consulta</param>
        /// <param name="registroMaximo">número de registros a recuperar</param>
        /// <returns></returns>
        public DataTable ConsultarPromocionProductoPeriodo
            (int idTipo, DateTime fecha1, DateTime fecha2, int registroBase, int registroMaximo)
        {
            var dataset = new DataSet();
            try
            {
                CargarAdapterStoreProsedure(sqlConsultarPromocionPeriodoProducto);
                miAdapter.SelectCommand.Parameters.AddWithValue("idTipo", idTipo);
                miAdapter.SelectCommand.Parameters.AddWithValue("fecha1", fecha1);
                miAdapter.SelectCommand.Parameters.AddWithValue("fecha2", fecha2);
                miAdapter.Fill(dataset, registroBase, registroMaximo, "promocion");
                return dataset.Tables[0];
            }
            catch (Exception ex)
            {
                throw new Exception("Error al consultar promoción producto periodo. \n" + ex.Message);
            }
        }

        /// <summary>
        /// Obtiene el total de los registros de promoción producto periodos.
        /// </summary>
        /// <param name="idTipo">id tipo promoción(producto)a consultar</param>
        /// <param name="fecha1">fecha inicio a consultar</param>
        /// <param name="fecha2">fecha fin a consultar</param>
        /// <returns></returns>
        public long RowListarPromocionProducto
            (int idTipo, DateTime fecha1, DateTime fecha2)
        {
            try
            {
                CargarComandoStoreProsedure("count_listar_promocion_producto");
                miComando.Parameters.AddWithValue("idtipo", idTipo);
                miComando.Parameters.AddWithValue("feha1", fecha1);
                miComando.Parameters.AddWithValue("fecha2", fecha2);
                miConexion.MiConexion.Open();
                var rows = Convert.ToInt64(miComando.ExecuteScalar());
                miConexion.MiConexion.Close();
                miComando.Dispose();
                return rows;
            }
            catch(Exception ex)
            {
                throw new Exception("Ocurrio un error al listar promoción producto periodos. \n" + ex.Message);
            }
            finally
            {
                miConexion.MiConexion.Close();
            }
        }

        /// <summary>
        /// Carga promocion
        /// </summary>
        /// <param name="idPromocion">id promocion</param>
        /// <param name="idTipo">id tipo</param>
        /// <returns></returns>
        public Promocion CargarPromocion
            (int idPromocion, int idTipo)
        {
            Promocion miPromocion = new Promocion();
            try
            {
                if (idTipo == 2)
                {
                    CargarComandoStoreProsedure(sqlListaCompletaPromocionMarca);
                }
                else
                {
                    if (idTipo == 3)
                    {
                        CargarComandoStoreProsedure(sqlListaCompletaPromocionCategoria);
                    }
                    else
                    {

                        CargarComandoStoreProsedure(sqlListaCompletaPromocionProducto);
                    }
                }
                miComando.Parameters.AddWithValue("idPromocion", idPromocion);
                miConexion.MiConexion.Open();
                NpgsqlDataReader myreader = miComando.ExecuteReader();
                while (myreader.Read())
                {
                    miPromocion.idPromocion = myreader.GetInt32(0);
                    miPromocion.idTipo = myreader.GetInt32(1);
                    miPromocion.NombreTipoPromocion = myreader.GetString(2);

                    if (idTipo == 2)
                    {
                        miPromocion.Marca = myreader.GetInt32(3);
                        miPromocion.MarcaValor = myreader.GetString(4);
                        miPromocion.idDescuento = myreader.GetInt32(5);
                        miPromocion.ValorDescuento = myreader.GetInt32(6).ToString();
                        miPromocion.fechaInicio = myreader.GetDateTime(7);
                        miPromocion.fechaFin = myreader.GetDateTime(8);
                    }
                    else
                    {
                        if (idTipo == 3)
                        {
                            miPromocion.Categoria = myreader.GetString(3);
                            miPromocion.CategoriaValor = myreader.GetString(4);
                            miPromocion.idDescuento = myreader.GetInt32(5);
                            miPromocion.ValorDescuento = myreader.GetInt32(6).ToString();
                            miPromocion.fechaInicio = myreader.GetDateTime(7);
                            miPromocion.fechaFin = myreader.GetDateTime(8);
                        }
                        else
                        {
                            miPromocion.Producto = myreader.GetString(3);
                            miPromocion.Producto = myreader.GetString(4);
                            miPromocion.cantidad = myreader.GetInt32(5);
                            miPromocion.idDescuento = myreader.GetInt32(6);
                            miPromocion.ValorDescuento = myreader.GetInt32(7).ToString();
                            miPromocion.fechaInicio = myreader.GetDateTime(8);
                            miPromocion.fechaFin = myreader.GetDateTime(9);
                        }
                    }  
                }
                miConexion.MiConexion.Close();
                miComando.Dispose();
                return miPromocion;

            }
            catch (Exception ex)
            {
                throw new Exception("Error al cargar promocion. \n" + ex.Message);
            }
            finally
            {
                miConexion.MiConexion.Close();
            }
        }


        /// <summary>
        /// Existe Promoción marca
        /// </summary>
        /// <param name="codigo">código marca a consultar</param>
        /// <param name="fecha1">fecha inicio a consultar</param>
        /// <param name="fecha2">fecha fin a consultar</param>
        /// <returns></returns>
        public bool ExistePromocionMarca
            (int codigo, DateTime fecha1, DateTime fecha2)
        {
            try
            {
                CargarComandoStoreProsedure(sqlExistePromocionMarca);
                miComando.Parameters.AddWithValue("codigo", codigo);
                miComando.Parameters.AddWithValue("fecha1", fecha1);
                miComando.Parameters.AddWithValue("fecha2", fecha2);
                miConexion.MiConexion.Open();
                var resultado = Convert.ToBoolean(miComando.ExecuteScalar());
                miConexion.MiConexion.Close();
                miComando.Dispose();
                return resultado;
            }
            catch(Exception ex)
            {
                throw new Exception("Error al ingresar el registro. \n" + ex.Message);
            }
            finally
            {
                miConexion.MiConexion.Close();
            }
        }

        /// <summary>
        /// Existe promoción categoría
        /// </summary>
        /// <param name="codigo">código categoría a consultar</param>
        /// <param name="fecha1">fecha inicio a consultar</param>
        /// <param name="fecha2">fecha fin a consultar</param>
        /// <returns></returns>
        public bool ExistePromocionCategoria
            (string codigo, DateTime fecha1, DateTime fecha2)
        {
            try
            {
                CargarComandoStoreProsedure(sqlExistePromocionCategoria);
                miComando.Parameters.AddWithValue("codigo", codigo);
                miComando.Parameters.AddWithValue("fecha1", fecha1);
                miComando.Parameters.AddWithValue("fecha2", fecha2);
                miConexion.MiConexion.Open();
                var resultado = Convert.ToBoolean(miComando.ExecuteScalar());
                miConexion.MiConexion.Close();
                miComando.Dispose();
                return resultado;
            }
            catch(Exception ex)
            {
                throw new Exception("Error al ingresar el registro. \n" + ex.Message);
            }
            finally
            {
                miConexion.MiConexion.Close();
            }
        }

        /// <summary>
        /// Existe promoción producto
        /// </summary>
        /// <param name="codigo">código producto a consultar</param>
        /// <param name="fecha1">fecha inicio a consultar</param>
        /// <param name="fecha2">fecha fin a consultar</param>
        /// <returns></returns>
        public bool ExistePromocionProducto
            (string codigo, DateTime fecha1, DateTime fecha2)
        {
            try
            {
                CargarComandoStoreProsedure(sqlExistePromocionProducto);
                miComando.Parameters.AddWithValue("codigo",codigo);
                miComando.Parameters.AddWithValue("fecha1", fecha1);
                miComando.Parameters.AddWithValue("fecha2", fecha2);
                miConexion.MiConexion.Open();
                var resultado = Convert.ToBoolean(miComando.ExecuteScalar());
                miConexion.MiConexion.Close();
                miComando.Dispose();
                return resultado;
            }
            catch(Exception ex)
            {
                throw new Exception("Error al ingresar el registro. \n" + ex.Message);
            }
            finally
            { }
        }

        /// <summary>
        ///  Inicializa una nueva instancia de NpgsqlCommand de tipo Stored Procederé.
        /// </summary>
        /// <param name="cmd"></param>
        private void CargarComandoStoreProsedure(string cmd)
        {
            miComando = new NpgsqlCommand();
            miComando.Connection=miConexion.MiConexion;
            miComando.CommandType = CommandType.StoredProcedure;
            miComando.CommandText = cmd;
        }

        /// <summary>
        /// Cargar adapter store procedure.
        /// </summary>
        /// <param name="cmd"></param>
        public void CargarAdapterStoreProsedure(string cmd)
        {
            miAdapter = new NpgsqlDataAdapter(cmd, this.miConexion.MiConexion);
            miAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
        }

    }
}

