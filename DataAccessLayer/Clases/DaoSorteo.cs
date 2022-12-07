using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DTO.Clases;
using Npgsql;
using System.Data;


namespace DataAccessLayer.Clases
{
      public  class DaoSorteo
    {
          /// <summary>
          /// Representa un adaptador de sentencia sql.
          /// </summary>
          private NpgsqlDataAdapter miAdapter;

          /// <summary>
          /// Representa un objeto de sentencia sql a posgres.
          /// </summary>
          private NpgsqlCommand miComando;

          /// <summary>
          /// Objeto de conexion a la base de datos sqlposgres.
          /// </summary>
          private Conexion miConexion;

          /// <summary>
          /// Representa una tabla de datos en memoria.
          /// </summary>
          private DataTable miDataTable;

          /// <summary>
          /// Representa una cache de datos en memoria
          /// </summary>
          private DataSet miDataSet;

          #region Funciones

          /// <summary>
          /// Representa la funcion insertar sorteo.
          /// </summary>
          public string sqlInsertaSorteo = "insertar_sorteo";

          /// <summary>
          /// Representa la funcion listar_sorteo.
          /// </summary>
          private string sqlListarSorteo = "listar_sorteo_activo";

          /// <summary>
          /// Representa la funcioneditar_sorteo.
          /// </summary>
          private string sqlEditarSrteo = "editar_sorteo";

          /// <summary>
          /// Representa la fincion filtro_sorteo_nombre.
          /// </summary>
          private string sqlListaSorteoNombreSorteo = "filtro_sorteo_nombre";

          /// <summary>
          /// Representa la funcion filtro_sorteo_patrocinador.
          /// </summary>
          private string sqlListaSorteoPatrocinadorSorteo = "filtro_sorteo_patrocinador";

          /// <summary>
          /// Representa la funcion consulta_sorteo_nombre.
          /// </summary>
          private string sqlConsultaNombreSorteo = "consulta_sorteo_nombre";

          /// <summary>
          /// Representa la funcion consulta_sorteo_patrocinador.
          /// </summary>
          private string sqlConsultaPatrocinadorSorteo = "consulta_sorteo_patrocinador";

          /// <summary>
          /// Representa la funcion listar_sorteo_marca_fechas.
          /// </summary>
          private string sqlConsultarSorteoMarcaFechas = "listar_sorteo_marca_fechas";

          /// <summary>
          /// Representa la funcion listar_historial_sorteo_marca_fechas.
          /// </summary>
          private string sqlConsultarHistorialSorteoMarcaFechas = "listar_historial_sorteo_marca_fechas";

          /// <summary>
          /// representa la funcion listar_sorteo_marca_fechas.
          /// </summary>
          private string sqlConsultarSorteoFechasM = "listar_sorteo_marca_fechas";

          /// <summary>
          /// Representa la funcion listar_historial_sorteo_marca_fechas.
          /// </summary>
          private string sqlConsultarHistorialSorteoFechasM = "listar_historial_sorteo_marca_fechas";

          /// <summary>
          /// representa la funcion listar_sorteo_marca_periodo.
          /// </summary>
          private string sqlConsultarSoreteoMarcaPeriodo = "listar_sorteo_marca_periodo";

          /// <summary>
          /// representa la funcion listar_historial_sorteo_marca_periodo.
          /// </summary>
          private string sqlConsultarHistorialMarcaSorteoPeriodo = "listar_historial_sorteo_marca_periodo";

          /// <summary>
          /// Representa la funcion listar_sorteo_marca_periodo.
          /// </summary>
          private string sqlConsultarSorteoPriodosM = "listar_sorteo_marca_periodo";

          /// <summary>
          /// Representa la funcion listar_historial_sorteo_marca_periodo.
          /// </summary>
          private string sqlConsultarHistorialSorteoPeriodo = "listar_historial_sorteo_marca_periodo";

          /// <summary>
          /// Representa la funcion listar_sorteo_categoria_fechas.
          /// </summary>
          private string sqlConsultarSorteoCategoriaFechas = "listar_sorteo_categoria_fechas";

          /// <summary>
          /// Representa la funcion listar_historial_sorteo_categoria_fechas.
          /// </summary>
          private string sqlConsultarHistorialSorteoCategoriaFechas = "listar_historial_sorteo_categoria_fechas";

          /// <summary>
          /// Represnta la funcion listar_sorteo_categoria_fechas.
          /// </summary>
          private string sqlConsultarSorteoCategoria = "listar_sorteo_categoria_fechas";

          /// <summary>
          /// Representa la funcion listar_historial_sorteo_categoria_fechas.
          /// </summary>
          private string sqlConsultarHistorialSorteoCategoria = "listar_historial_sorteo_categoria_fechas";

          /// <summary>
          /// Representa la funcion listar_sorteo_categoria_periodo.
          /// </summary>
          private string sqlConsultarSorteoCategoriaPeriodos = "listar_sorteo_categoria_periodo";

          /// <summary>
          /// Representa la funcion listar_historial_sorteo_categoria_periodo.
          /// </summary>
          private string sqlConsultarHistorialSorteocategoriaPeriodos = "listar_historial_sorteo_categoria_periodo";

          /// <summary>
          /// Representa la funcion listar_sorteo_categoria_periodo.
          /// </summary>
          private string sqlConsultarSorteoCategoriaP = "listar_sorteo_categoria_periodo";

          /// <summary>
          /// Representa la funcion listar_historial_sorteo_categoria_periodo.
          /// </summary>
          private string sqlConsultarHistorialSorteocategoriaP = "listar_historial_sorteo_categoria_periodo";

          /// <summary>
          /// Representa la funcion listar_sorteo_producto_fechas.
          /// </summary>
          private string sqlConsultarSorteoProductofechas = "listar_sorteo_producto_fechas";

          /// <summary>
          /// Representa la funcion listar_historial_sorteo_producto_fechas.
          /// </summary>
          private string sqlConsultarHistorialSorteoproductoFechas = "listar_historial_sorteo_producto_fechas";
          
          /// <summary>
          /// Representa la funcion listar_sorteo_producto_fechas.
          /// </summary>
          private string sqlConsultarSorteoProducto = "listar_sorteo_producto_fechas";

          /// <summary>
          /// Representa la funcion listar_sorteo_producto_fechas.
          /// </summary>
          private string sqlConsultarHistorialSorteoProducto = "listar_historial_sorteo_producto_fechas";

          /// <summary>
          /// representa la funcion listar_sorteo_producto_periodo.
          /// </summary>
          private string sqlConsultarSorteoProductoPeriodos = "listar_sorteo_producto_periodo";

          /// <summary>
          /// Representa la funcion listar_historial_sorteo_producto_periodo.
          /// </summary>
          private string sqlConsultarHistorialSorteoProductoPeriodo = "listar_historial_sorteo_producto_periodo";

          /// <summary>
          /// Representa la funcion listar_sorteo_producto_periodo.
          /// </summary>
          private string sqlConsultarSorteoProductoP = "listar_sorteo_producto_periodo";

          /// <summary>
          /// representa ñla funcion listar_historial_sorteo_producto_periodo.
          /// </summary>
          private string sqlConsultarhistorialSorteoProductoP = "listar_historial_sorteo_producto_periodo";

          /// <summary>
          /// Representa la funcion listar_sorteo_fechas.
          /// </summary>
          private string sqlConsultarSorteofechas = "listar_sorteo_fechas";

          /// <summary>
          /// Representa la funcion listar_historial_sorteo_fechas.
          /// </summary>
          private string sqlConsultarHistorialSorteoFechas = "listar_historial_sorteo_fechas";

          /// <summary>
          /// Representa la funcion listar_sorteo_periodo.
          /// </summary>
          private string sqlConsultarSorteoPeriodos = "listar_sorteo_periodo";

          /// <summary>
          /// Representa la funcion listar_historial_sorteo_periodo.
          /// </summary>
          private string sqlConsultarHistorialSorteoPeriodos = "listar_historial_sorteo_periodo";

          /// <summary>
          /// Representa la funcion listar_sorteo_factura_fechas.
          /// </summary>
          private string sqlConsultarSorteofacturafechas = "listar_sorteo_factura_fechas";

          /// <summary>
          /// Representa la funcion listar_historial_sorteo_factura_fechas.
          /// </summary>
          private string sqlConsultarHistorialSorteoFacturaFechas = "listar_historial_sorteo_factura_fechas";

          /// <summary>
          /// Representa la funcion listar_sorteo_factura_periodo.
          /// </summary>
          private string sqlConsultarSorteoFacturaPeriodo = "listar_sorteo_factura_periodo";

          /// <summary>
          /// Representa la funcion listar_historial_sorteo_factura_periodo.
          /// </summary>
          private string sqlConsultarHistorialSorteofacturaperiodos = "listar_historial_sorteo_factura_periodo";

          /// <summary>
          /// Representa a funcion listar_historial_sorteo_fecha_inicio.
          /// </summary>
          private string sqlListarHistorialFechaInicioFechaSimple = "listar_historial_sorteo_fecha_inicio";

          /// <summary>
          /// Reprsenta la funcion listar_sorteo_fecha.
          /// </summary>
          private string sqlListaSorteoIniciofechaSimple = "listar_sorteo_fecha_inicio";

          /// <summary>
          /// Representa la funcion listar_historial_periodo_fecha_inicio.
          /// </summary>
          private string sqlListarHistorialFechaInicioPeriodosFecha = "listar_historial_periodo_fecha_inicio";


          /// <summary>
          /// Representa la funcion listar_historial_sorteo_fecha_fin.
          /// </summary>
          private string sqllistarHistorialFechaFinfechaSimple = "listar_historial_sorteo_fecha_fin";

          /// <summary>
          /// Representa la funcion listar_sorteo_fecha_fin.
          /// </summary>
          private string sqlListaSorteoFechaFin = "listar_sorteo_fecha_fin";

          /// <summary>
          /// Representa la funcion listar_sorteo_periodo_fecha_inicio.
          /// </summary>
          private string sqlListaSorteoInicioPeriodoFecha = "listar_sorteo_periodo_fecha_inicio";

          /// <summary>
          /// Representa la fincion listar_Tipo_sorteo.
          /// </summary>
          private string sqlListaTipoSorteo = "listar_Tipo_sorteo";

          /// <summary>
          /// representa la funcion listar_periodo_fecha_fin.
          /// </summary>
          private string sqlListaSorteoPeriodoFechaFin = "listar_periodo_fecha_fin";

          /// <summary>
          /// Representa la funcion listar_sorteo_fecha_sorteo.
          /// </summary>
          private string sqlListaSorteoFechaSorteo = "listar_sorteo_fecha_sorteo";

          /// <summary>
          /// Representa la funcion listar_periodo_fecha_sorteo.
          /// </summary>
          private string sqlListaSorteoPeriodoFechaSorteo = "listar_periodo_fecha_sorteo";
         
          /// <summary>
          /// Representa la funcion listar_sorteo_completo. 
          /// </summary>
          private string sqlListaCompletaSorteo = "listar_sorteo_completo";

          /// <summary>
          /// Representa la funcion listar_historial_sorteo_completo.
          /// </summary>
          private string sqlListaSorteoHistorialCompleto = "listar_historial_sorteo_completo";

          /// <summary>
          /// Representa la funcion listar_historial_sorteo.
          /// </summary>
          private string sqlListarHistorialSorteo = "listar_historial_sorteo";

          /// <summary>
          /// Representa la funcion filtro_historial_sorteo_nombre
          /// </summary>
          private string sqlFiltoHistorialNombreSorteo = "filtro_historial_sorteo_nombre";

          /// <summary>
          /// Representa la funcion filtro_historial_sorteo_patrocinador.
          /// </summary>
          private string sqlFiltroHistorialPatrocinadorsorteo = "filtro_historial_sorteo_patrocinador";

          /// <summary>
          /// Representa la funcion consulta_historial_sorteo_nombre.
          /// </summary>
          private string sqlConsultaHistorialNombreSorteo = "consulta_historial_sorteo_nombre";

          /// <summary>
          /// Representa la funcion consulta_historial_sorteo_patrocinador.
          /// </summary>
          private string sqlConsultaHistorialPatrocinadorSorteo = "consulta_historial_sorteo_patrocinador";

          /// <summary>
          /// Representa la funcion listar_historial_tipo_sorteo.
          /// </summary>
          private string sqlListarHistorialTipoSorteo = "listar_historial_tipo_sorteo";

          /// <summary>
          /// Representa la funcion listar_historial_periodo_fecha_fin.
          /// </summary>
          private string sqlListarHistorialFechaFinPeriodofecha = "listar_historial_periodo_fecha_fin";

          /// <summary>
          /// Representa la funcion listar_historial_sorteo_fecha_sorteo.
          /// </summary>
          private string sqlListarHistorialFechaSorteoFechaSimple = "listar_historial_sorteo_fecha_sorteo";

          /// <summary>
          /// Representa la funcion listar_historial_periodo_fecha_sorteo.
          /// </summary>
          private string sqlListarHistorialFechaSorteoPeriodoFecha = "listar_historial_periodo_fecha_sorteo";

          /// <summary>
          /// Representa la funcion eliminar_marca_sorteo.
          /// </summary>
          private string sqlEliminarMarcaSorteo = "eliminar_marca_sorteo";

          /// <summary>
          /// Representa la funcion eliminar_categoria_sorteo.
          /// </summary>
          private string sqlEliminacategoriaSorteo = "eliminar_categoria_sorteo";

          /// <summary>
          /// Representa la funcion eliminar_producto_categoria.
          /// </summary>
          private string sqlEliminarProductoSorteo = "eliminar_producto_sorteo";

          /// <summary>
          /// Representa la funcion eliminar_sorteo.
          /// </summary>
          private string sqlEliminarSorteo = "eliminar_sorteo";

          /// <summary>
          /// Representa la funcion cliente_ganador_sorteo.
          /// </summary>
          private string sqlClienteGanador = "cliente_ganador_sorteo";

          /// <summary>
          /// Representa la funcion insertar_historial_sorteo.
          /// </summary>
          private string sqlInsertarHistorialSorteo = "insertar_historial_sorteo";

          /// <summary>
          /// Representa la funcion insertar_historial_sorteo_factura.
          /// </summary>
          private string sqlInsertarHistorialfacturaSorteo = "insertar_historial_sorteo_factura";

          /// <summary>
          /// Representa la funcion historial_cliente_ganador_sorteo.
          /// </summary>
          private string sqlHistorialClienteGanador = "historial_cliente_ganador_sorteo";

          /// <summary>
          /// representa la funcion eliminar_sorteo_factura.
          /// </summary>
          private string sqlEliminarFacturaSorteo = "eliminar_sorteo_factura";

          #endregion

          public DaoSorteo()
          {
              this.miConexion=new Conexion();
          }

          #region Metodos

          /// <summary>
          /// Insertar sorteo.
          /// </summary>
          /// <param name="sorteo"></param>
          public void IsartarSorteo(Sorteo sorteo)
          {
              var miDaoMarca = new DaoMarca();
              var miDaoCategoria = new DaoCategoria();
              var miDaoProducto = new DaoProducto();
                   
              try
              {
                  CargaComandoStoreProsedure(sqlInsertaSorteo);
                  miComando.Parameters.AddWithValue("idtipo_sorteo", sorteo.IdTipoSorteo);
                  miComando.Parameters.AddWithValue("nombresorteo", sorteo.NombreSorteo);
                  miComando.Parameters.AddWithValue("fechainiciosorteo", sorteo.FechaInicioSorteo);
                  miComando.Parameters.AddWithValue("fechafinalsorteo", sorteo.FechaFinalSorteo);
                  miComando.Parameters.AddWithValue("fechasorteo", sorteo.FechaSorteo);
                  miComando.Parameters.AddWithValue("patrosinadoressorteo", sorteo.PatrocinadoresSorteo);
                  miComando.Parameters.AddWithValue("premiosorteo", sorteo.PremioSorteo);
                  miComando.Parameters.AddWithValue("valorminimopremiosorpresa", sorteo.ValorMinimoCompraSorteo);
                  miComando.Parameters.AddWithValue("estadosorteo", sorteo.EstadoSorteo);
                  miComando.Parameters.AddWithValue("aplicaventa", sorteo.AplicaVenta);
                  miComando.Parameters.AddWithValue("tipotiquete", sorteo.TiqueteMultiple);
                  miComando.Parameters.AddWithValue("valorpremio", sorteo.ValorPremio);
                  miComando.Parameters.AddWithValue("aplicahora", sorteo.AplicaHora);
                  miComando.Parameters.AddWithValue("horainicio", sorteo.HoraInicio);
                  miComando.Parameters.AddWithValue("horafin", sorteo.HoraFin);
                  miComando.Parameters.AddWithValue("consepto", sorteo.Concepto);

                  miConexion.MiConexion.Open();
                  var id = (int) miComando.ExecuteScalar();
                  miConexion.MiConexion.Close();
                  miComando.Dispose();

                  if (sorteo.IdTipoSorteo == 2)
                  {
                      foreach (Marca idmarca in sorteo.Marcas)
                      {
                          miDaoMarca.InsertaSorteoMarca(id, idmarca.IdMarca, false);
                      }
                  }
                  else
                  {
                      if (sorteo.IdTipoSorteo == 3)
                      {
                          foreach (Categoria idCategoria in sorteo.Categorias)
                          {
                              miDaoCategoria.InsertarSorteoCategoria(id, idCategoria.CodigoCategoria, false);
                          }
                      }
                      else
                      {
                          if (sorteo.IdTipoSorteo == 4)
                          {
                              foreach (Producto producto in sorteo.Producto)
                              {
                                  miDaoProducto.InsertarProductoSorteo(id, producto.CodigoInternoProducto, false);
                              }
                          }                          
                      }
                  }
              }
              catch (Exception ex)
              {
                  throw new Exception("Error al insertar sorteo. \n" + ex.Message);
              }
              finally
              {
                  miConexion.MiConexion.Close();
              }
          }

          /// <summary>
          /// lista sorteo
          /// </summary>
          /// <returns></returns>
          public DataTable ListarSorteo(string estado, int registroBase, int registroMaximo)
          {
              try
              {
                  miDataSet = new DataSet();
                  CargarAdapterStoreProsedure(sqlListarSorteo);
                  miAdapter.SelectCommand.Parameters.AddWithValue("estado", estado);
                  miAdapter.Fill(miDataSet, registroBase, registroMaximo, "sorteo");
                  return miDataSet.Tables[0];
              }
              catch (Exception ex)
              {
                  throw new Exception("Error al listar sorteo. \n" + ex.Message);
              }
              
          }

          /// <summary>
          /// Consultar estado sorteo activo inactivo
          /// </summary>
          /// <param name="estado">activo inactivo</param>
          /// <returns></returns>
          public long RowsListarSorteosActivos
              (string estado)
          {
              try
              {
                  CargaComandoStoreProsedure("count_listar_estado_sorteo");
                  miComando.Parameters.AddWithValue("estado", estado);
                  miConexion.MiConexion.Open();
                  var rows = Convert.ToInt64(miComando.ExecuteScalar());
                  miConexion.MiConexion.Close();
                  miComando.Dispose();
                  return rows;
              }
              catch(Exception ex)
              {
                  throw new Exception("Ocurrio un error al consultar estado sorteo. \n" + ex.Message);
              }
              finally
              {
                  miConexion.MiConexion.Close();
              }
          }

          /// <summary>
          /// Edita sorteo.
          /// </summary>
          /// <param name="sorteo"></param>
          public void Editasorteo(Sorteo sorteo)
          {
              var miDaoMarca = new DaoMarca();
              var miDaoCategoria = new DaoCategoria();
              var miDaoProducto = new DaoProducto();
              try
              {
                  CargaComandoStoreProsedure(sqlEditarSrteo);
                  miComando.Parameters.AddWithValue("idSorteo", sorteo.IdSorteo);
                  miComando.Parameters.AddWithValue("idTipoSorteo", sorteo.IdTipoSorteo);
                  miComando.Parameters.AddWithValue("nombreSorteo", sorteo.NombreSorteo);
                  miComando.Parameters.AddWithValue("fechaInicioSorteo", sorteo.FechaInicioSorteo);
                  miComando.Parameters.AddWithValue("fechaFinSorteo", sorteo.FechaFinalSorteo);
                  miComando.Parameters.AddWithValue("fechaSorteo", sorteo.FechaSorteo);
                  miComando.Parameters.AddWithValue("patrocinadareo", sorteo.PatrocinadoresSorteo);
                  miComando.Parameters.AddWithValue("premio", sorteo.PremioSorteo);
                  miComando.Parameters.AddWithValue("valorMinimoCompra", sorteo.ValorMinimoCompraSorteo);
                  miComando.Parameters.AddWithValue("estado", sorteo.EstadoSorteo);
                  miComando.Parameters.AddWithValue("aplicaVenta", sorteo.AplicaVenta);
                  miComando.Parameters.AddWithValue("tiqueteMultiple", sorteo.TiqueteMultiple);
                  miComando.Parameters.AddWithValue("valorPremio", sorteo.ValorPremio);
                  miComando.Parameters.AddWithValue("aplicaHora", sorteo.AplicaHora);
                  miComando.Parameters.AddWithValue("horaInicio", sorteo.HoraInicio);
                  miComando.Parameters.AddWithValue("horaFin", sorteo.HoraFin);
                  miComando.Parameters.AddWithValue("concepto", sorteo.Concepto);
                  miConexion.MiConexion.Open();
                  miComando.ExecuteNonQuery();
                  miConexion.MiConexion.Close();
                  miComando.Dispose();
                 
              }
              catch (Exception ex)
              {
                  throw new Exception("Error al editar sorteo. \n" + ex.Message);
              }
              finally
              {
                  miConexion.MiConexion.Close();
              }
          }


          /// <summary>
          /// Eliminar sorteo.
          /// </summary>
          /// <param name="idsorteo">id sorteo a eliminar</param>
          public void EliminarSorteo(int idsorteo)
          {
              try
              {
                  CargaComandoStoreProsedure(sqlEliminarSorteo);
                  miComando.Parameters.AddWithValue("idsorteo", idsorteo);
                  miConexion.MiConexion.Open();
                  miComando.ExecuteNonQuery();
                  miConexion.MiConexion.Close();
                  miComando.Dispose();

              }
              catch (Exception ex)
              {
                  throw new Exception("Error al eliminar sorteo. \n" + ex.Message);
              }
              finally
              {
                  miConexion.MiConexion.Close();
              }
          }

          /// <summary>
          /// lista los sorteos por nombre.
          /// </summary>
          /// <param name="nombre"></param>
          /// <returns></returns>
          public DataTable ListaSorteoNombre(string nombre, bool historial)
          {
              try
              {
                  miDataTable = new DataTable();
                  if (historial)
                  {
                      CargarAdapterStoreProsedure(sqlFiltoHistorialNombreSorteo);
                  }
                  else
                  {
                      CargarAdapterStoreProsedure(sqlListaSorteoNombreSorteo);
                  }
                  miAdapter.SelectCommand.Parameters.AddWithValue("nombre", nombre);
                  miAdapter.Fill(miDataTable);
                  return miDataTable;
              }
              catch (Exception ex)
              {
                  throw new Exception("Error al consultar los sorteos por nombre. \n" + ex.Message);
              }
              
          }

          /// <summary>
          /// filatra patrocinador de sorteo.
          /// </summary>
          /// <param name="patrocinador"></param>
          /// <returns></returns>
          public DataTable ListaSorteoPatrocinador(string patrocinador, bool historial)
          {
              try
              {
                  miDataTable = new DataTable();
                  if (historial)
                  {
                      CargarAdapterStoreProsedure(sqlFiltroHistorialPatrocinadorsorteo);
                  }
                  else
                  {
                      CargarAdapterStoreProsedure(sqlListaSorteoPatrocinadorSorteo);
                  }
                  miAdapter.SelectCommand.Parameters.AddWithValue("patrocinador", patrocinador);
                  miAdapter.Fill(miDataTable);
                  return miDataTable;
              }
              catch(Exception ex)
              {
                  throw new Exception("Error al consultar sorteos por patrosinador. \n" + ex.Message);
              }
          }

          /// <summary>
          /// Consulta nombre de el sorteo
          /// </summary>
          /// <param name="nombre"></param>
          /// <returns></returns>
          public DataTable ConsultaNombreSorteo(string nombre , bool historial)
          {
              try
              {
                  miDataTable = new DataTable();
                  if (historial)
                  {
                      CargarAdapterStoreProsedure(sqlConsultaHistorialNombreSorteo);
                  }
                  else
                  {
                      CargarAdapterStoreProsedure(sqlConsultaNombreSorteo);
                  }
                  miAdapter.SelectCommand.Parameters.AddWithValue("Nombre", nombre);
                  miAdapter.Fill(miDataTable);
                  return miDataTable;
              }
              catch(Exception ex)
              {
                  throw new Exception("Error al consultar los sorteos por nombre. \n" + ex.Message);
              }

          }

          /// <summary>
          /// Consulta patrocinador de el sorteo
          /// </summary>
          /// <param name="patrocinador"></param>
          /// <returns></returns>
          public DataTable ConsultaPatrocinadorSorteo(string patrocinador, bool historial)
          {
              try
              {
                  miDataTable = new DataTable();
                  if (historial)
                  {
                      CargarAdapterStoreProsedure(sqlConsultaHistorialPatrocinadorSorteo);
                  }
                  else
                  {
                      CargarAdapterStoreProsedure(sqlConsultaPatrocinadorSorteo);
                  }
                  miAdapter.SelectCommand.Parameters.AddWithValue("patrocinador", patrocinador);
                  miAdapter.Fill(miDataTable);
                  return miDataTable;
              }
              catch(Exception ex)
              {
                  throw new Exception("Error al consultar los sorteos por patrocinador. \n" + ex.Message);
              }

          }

          /// <summary>
          /// Consulta sorteo marca fechas
          /// </summary>
          /// <param name="idTipo">id tipo</param>
          /// <param name="idMarca">id marca</param>
          /// <param name="fechas">fecha</param>
          /// <param name="historial">determina el tipo de consulta</param>
          /// <returns></returns>
          public DataTable ConsultarSorteoMarcaFechas
              (int idTipo, int idMarca, DateTime fechas, bool historial)
          {
              try
              {
                  miDataTable = new DataTable();
                  if (historial)
                  {
                      CargarAdapterStoreProsedure(sqlConsultarHistorialSorteoMarcaFechas);
                  }
                  else
                  {
                      CargarAdapterStoreProsedure(sqlConsultarSorteoMarcaFechas);
                  }
                  miAdapter.SelectCommand.Parameters.AddWithValue("idtipo", idTipo);
                  miAdapter.SelectCommand.Parameters.AddWithValue("marca", idMarca);
                  miAdapter.SelectCommand.Parameters.AddWithValue("fechas", fechas);
                  miAdapter.Fill(miDataTable);
                  return miDataTable;
              }
               catch(Exception ex)
              {
                  throw new Exception("Error al consultar las marcas de el sorteo. \n"+ex.Message);
              }
          }

          /// <summary>
          /// Consulta sorteo tipo marca fechas
          /// </summary>
          /// <param name="idTipo">id tipo</param>
          /// <param name="fecha">fecha</param>
          /// <param name="historial">determina el tipo de consulta</param>
          /// <param name="registroBase">registro base de la consulta</param>
          /// <param name="registroMaximo">numero de registros a recuperar</param>
          /// <returns></returns>
          public DataTable ConsultarSorteoMarcaFechas
              (int idTipo, DateTime fecha, bool historial, int registroBase, int registroMaximo)
          {
              try
              {
                   miDataSet = new DataSet();
                  if (historial)
                  {
                      CargarAdapterStoreProsedure(sqlConsultarHistorialSorteoFechasM);
                  }
                  else
                  {
                      CargarAdapterStoreProsedure(sqlConsultarSorteoFechasM);
                  }
                  miAdapter.SelectCommand.Parameters.AddWithValue("idtipo", idTipo);
                  miAdapter.SelectCommand.Parameters.AddWithValue("fecha", fecha);
                  miAdapter.Fill(miDataSet, registroBase, registroMaximo, "sorteo");
                  return miDataSet.Tables[0];
              }
              catch (Exception ex)
              {
                  throw new Exception("Error al consultar las marcas de sorteo. \n"+ex.Message);
              }
          }

          /// <summary>
          /// Obtiene el total de los registros de sorteo tipo marca fecha
          /// </summary>
          /// <param name="idTipo">id tipo</param>
          /// <param name="fecha">fecha</param>
          /// <param name="historial">determina el tipo de consulta</param>
          /// <returns></returns>
          public long RowListarSorteoMarcaFechas
              (int idTipo, DateTime fecha, bool historial)
          {
              try
              {
                  if (historial)
                  {
                      CargaComandoStoreProsedure("count_listar_historial_sorteo_marca");
                  }
                  else
                  {
                      CargaComandoStoreProsedure("count_listar_sorteo_marca");
                  }
                  miComando.Parameters.AddWithValue("idtipo", idTipo);
                  miComando.Parameters.AddWithValue("fecha", fecha);
                  miConexion.MiConexion.Open();
                  var rows = Convert.ToInt64(miComando.ExecuteScalar());
                  miConexion.MiConexion.Close();
                  miComando.Dispose();
                  return rows;
              }
              catch (Exception ex)
              {
                  throw new Exception("Ocurrio un error al cargar los registros de sorteo marca. \n" + ex.Message);
              }
              finally
              {
                  miConexion.MiConexion.Close();
              }
          }

          /// <summary>
          /// Consulta sorteo marca periodos
          /// </summary>
          /// <param name="idTipo">id tipo</param>
          /// <param name="idmarca">id marca</param>
          /// <param name="fecha1">fecha1</param>
          /// <param name="fecha2">fehca2</param>
          /// <param name="historial">determina el estado de la consulta</param>
          /// <returns></returns>
          public DataTable ConsultarSorteoMarcaPeriodo
              (int idTipo, int idmarca, DateTime fecha1, DateTime fecha2, bool historial, int registroBase, int registroMaximo)
          {
              try
              {
                 miDataSet=new DataSet();
                  if(historial)
                  {
                      CargarAdapterStoreProsedure(sqlConsultarHistorialMarcaSorteoPeriodo);
                  }
                  else
                  {
                      CargarAdapterStoreProsedure(sqlConsultarSoreteoMarcaPeriodo);
                  }
                  miAdapter.SelectCommand.Parameters.AddWithValue("idtipo",idTipo);
                  miAdapter.SelectCommand.Parameters.AddWithValue("idmarca",idmarca);
                  miAdapter.SelectCommand.Parameters.AddWithValue("fecha1",fecha1);
                  miAdapter.SelectCommand.Parameters.AddWithValue("fecha2",fecha2);
                  miAdapter.Fill(miDataSet,registroBase,registroMaximo,"sorteo");
                  return miDataSet.Tables[0];
              }
              catch(Exception ex)
              {
                  throw new Exception("Error al consultar sorteo marca. \n" + ex.Message);
              }
          }

          /// <summary>
          /// Obtiene el total de los registros de sorteo marca periodos
          /// </summary>
          /// <param name="idTipo">id tipo</param>
          /// <param name="idMarca">id marca</param>
          /// <param name="fecha1">fecha1</param>
          /// <param name="fecha2">fecha2</param>
          /// <param name="historial">determina el valor de la consulta</param>
          /// <returns></returns>
          public long RowListarSorteoMarca
              (int idTipo,int idMarca,DateTime fecha1, DateTime fecha2,bool historial)
          {
              try
              {
                  if (historial)
                  {
                      CargaComandoStoreProsedure("count_listar_historial_sorteo_marca");
                  }
                  else
                  {
                      CargaComandoStoreProsedure("count_listar_sorteo_marca");
                  }
                  miComando.Parameters.AddWithValue("idtipo", idTipo);
                  miComando.Parameters.AddWithValue("idmarca", idMarca);
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
                  throw new Exception("Ocurrio un error al consultar sorteo marca. \n" + ex.Message);
              }
              finally
              {
                  miConexion.MiConexion.Close();
              }
          }

          /// <summary>
          /// Consulta sorteo tipo marca periodo.
          /// </summary>
          /// <param name="idTipo">id tipo</param>
          /// <param name="fecha1">fecha1</param>
          /// <param name="fecha2">fecha2</param>
          /// <param name="historial">determina la condicion de la busqueda</param>
          /// <param name="registroBase">registro base de consulta</param>
          /// <param name="registroMaximo">numero de registros a recuperar</param>
          /// <returns></returns>
          public DataTable ConsultarSorteoMarcaPeriodo
              (int idTipo, DateTime fecha1, DateTime fecha2, bool historial, int registroBase, int registroMaximo)
          {
              try
              {
                  miDataSet = new DataSet();
                  if(historial)
                  {
                      CargarAdapterStoreProsedure(sqlConsultarHistorialSorteoPeriodo);
                  }
                  else
                  {
                      CargarAdapterStoreProsedure(sqlConsultarSorteoPriodosM);
                  }
                  miAdapter.SelectCommand.Parameters.AddWithValue("idtipo", idTipo);
                  miAdapter.SelectCommand.Parameters.AddWithValue("fecha1", fecha1);
                  miAdapter.SelectCommand.Parameters.AddWithValue("fecha2", fecha2);
                  miAdapter.Fill(miDataSet,registroBase,registroMaximo,"sorteo");
                  return miDataSet.Tables[0];
              }
              catch(Exception ex)
              {
                  throw new Exception("Error al consultar las marcas de sorteo. \n" + ex.Message);
              }

          }

          /// <summary>
          /// Obtiene el total de los registros de sorteo larca periodo
          /// </summary>
          /// <param name="idTipo">id tipo</param>
          /// <param name="fecha1">fecha1</param>
          /// <param name="fecha2">fecha2</param>
          /// <param name="historial">deermina  el valor de la busqueda</param>
          /// <returns></returns>
          /// 
          public long RowListarSorteoMarcaPeriodo
              (int idTipo, DateTime fecha1, DateTime fecha2 , bool historial)
          {
              try
              {
                  if (historial)
                  {
                      CargaComandoStoreProsedure("count_listar_historial_sorteo_marca_periodos");                     
                  }
                  else
                  {
                      CargaComandoStoreProsedure("count_listar_sorteo_marca");
                  }
                  miComando.Parameters.AddWithValue("idTipo", idTipo);
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
                  throw new Exception("Ocurrio un error al cargar sorteo marca. \n" + ex.Message);
              }
              finally
              { }
          }

          /// <summary>
          /// consulta sorteo categoria fechas
          /// </summary>
          /// <param name="idTipo">id tipo</param>
          /// <param name="codigoCategoria">codigo categoria</param>
          /// <param name="fechas">fechas</param>
          /// <param name="historial">determina el estado de la consulta</param>
          /// <returns></returns>
          public DataTable ConsultarSorteoCategoriaFechas
              (int idTipo, string codigoCategoria, DateTime fechas, bool historial)
          {
              try
              {
                  miDataTable = new DataTable();
                  if(historial)
                  {
                      CargarAdapterStoreProsedure(sqlConsultarHistorialSorteoCategoriaFechas);
                  }
                  else
                  {                    
                      CargarAdapterStoreProsedure(sqlConsultarSorteoCategoriaFechas);
                  }
                  miAdapter.SelectCommand.Parameters.AddWithValue("idtipo", idTipo);
                  miAdapter.SelectCommand.Parameters.AddWithValue("codigocategoria", codigoCategoria);
                  miAdapter.SelectCommand.Parameters.AddWithValue("fechas", fechas);
                  miAdapter.Fill(miDataTable);
                  return miDataTable;
              }
              catch(Exception ex)
              {
                  throw new Exception("Error al consultar sorteo categorias. \n" + ex.Message);
              }
          }

          /// <summary>
          /// Consulta sorteo tipo categoria fechas.
          /// </summary>
          /// <param name="idTipo">id tipo</param>
          /// <param name="fechas">fecha</param>
          /// <param name="historial">determina el estado de la busqueda</param>
          /// <param name="registroBase">registro base de la busqueda</param>
          /// <param name="registroMaximo">numero de registros a recuperar</param>
          /// <returns></returns>
          public DataTable ConsultarSorteoCategoriaFechas
              (int idTipo, DateTime fechas, bool historial, int registroBase, int registroMaximo)
          {
              try
              {
                  miDataSet = new DataSet();
                  if (historial)
                  {
                      CargarAdapterStoreProsedure(sqlConsultarHistorialSorteoCategoria);
                  }
                  else
                  {
                      CargarAdapterStoreProsedure(sqlConsultarSorteoCategoria);
                  }
                  miAdapter.SelectCommand.Parameters.AddWithValue("idTipo",idTipo);
                  miAdapter.SelectCommand.Parameters.AddWithValue("fecha",fechas);
                  miAdapter.Fill(miDataSet,registroBase,registroMaximo,"sorteo");
                  return miDataSet.Tables[0];
              }
              catch(Exception ex)
              {
                  throw new Exception ("Error al consultar sorteo categoria. \n"+ex.Message);
              }
          }

          /// <summary>
          /// Obtiene el total de los registros de sarteo categoria fechas.
          /// </summary>
          /// <param name="idTipo">id tipo</param>
          /// <param name="fechas">fechas</param>
          /// <param name="historial">determina el estado de la consulta</param>
          /// <returns></returns>
          public long RowListarSorteoCategoriaFechas
              (int idTipo, DateTime fechas,bool historial)
          {
              try
              {
                  if(historial)
                  {
                      CargaComandoStoreProsedure("count_listar_historial_sorteo_categoria");
                  }
                  else
                  {
                      CargaComandoStoreProsedure("count_listar_sorteo_categoria");
                  }
                  miComando.Parameters.AddWithValue("idtipo",idTipo);
                  miComando.Parameters.AddWithValue("fehas",fechas);
                  miConexion.MiConexion.Open();
                  var rows=Convert.ToInt64(miComando.ExecuteScalar());
                  miConexion.MiConexion.Close();
                  miComando.Dispose();
                  return rows;
              }
              catch(Exception ex)
              {
                  throw new Exception("Ocurrio un error al cargar sorteo categoria. \n"+ex.Message);
              }
               finally
              {
                  miConexion.MiConexion.Close();
              }
          }

          /// <summary>
          /// Consulta sorteo categoria periodos
          /// </summary>
          /// <param name="idTipo">id tipo</param>
          /// <param name="codigoCategoria">codigo categoria</param>
          /// <param name="fecha1">fecha1</param>
          /// <param name="fecha2">fecha2</param>
          /// <param name="historial">determina el estado de la consulta</param>
          /// <returns></returns>
          public DataTable ConsultarSorteoCategoriaPeriodos
              (int idTipo,string codigoCategoria, DateTime fecha1,DateTime fecha2,bool historial, int registroBase, int registroMaximo)
          {
              try
              {
                  miDataSet = new DataSet();
                  if(historial)
                  {
                      CargarAdapterStoreProsedure(sqlConsultarHistorialSorteocategoriaPeriodos);
                  }
                  else
                  {
                      CargarAdapterStoreProsedure(sqlConsultarSorteoCategoriaPeriodos);
                  }
                  miAdapter.SelectCommand.Parameters.AddWithValue("idtipo", idTipo);
                  miAdapter.SelectCommand.Parameters.AddWithValue("codigocategoria", codigoCategoria);
                  miAdapter.SelectCommand.Parameters.AddWithValue("fecha1", fecha1);
                  miAdapter.SelectCommand.Parameters.AddWithValue("fecha2", fecha2);
                  miAdapter.Fill(miDataSet,registroBase,registroMaximo,"sorteo");
                  return miDataSet.Tables[0];
              }
              catch(Exception ex)
              {
                  throw new Exception("Error al consultar sorteo categoria. \n" + ex.Message);
              }
          }

          /// <summary>
          /// Obtiene el total de los registros de sorteo catgoria periodos
          /// </summary>
          /// <param name="idTipo">id tipo</param>
          /// <param name="codigoCategoria">codigo categoria</param>
          /// <param name="fecha1">fecha1</param>
          /// <param name="fecha2">fecha2</param>
          /// <param name="historial">determina en valor de la consulta</param>
          /// <returns></returns>
          public long RowListarSorteoCategoria
              (int idTipo, string codigoCategoria, DateTime fecha1, DateTime fecha2, bool historial)
          {
              try
              {
                  if (historial)
                  {
                      CargaComandoStoreProsedure("count_listar_historial_sorteo_categoria");
                  }
                  else
                  {
                      CargaComandoStoreProsedure("count_listar_sorteo_categoria");
                  }
                  miComando.Parameters.AddWithValue("idtipo", idTipo);
                  miComando.Parameters.AddWithValue("codigocategoria", codigoCategoria);
                  miComando.Parameters.AddWithValue("fechas1", fecha1);
                  miComando.Parameters.AddWithValue("fecha2", fecha2);
                  miConexion.MiConexion.Open();
                  var rows = Convert.ToInt64(miComando.ExecuteScalar());
                  miConexion.MiConexion.Close();
                  miComando.Dispose();
                  return rows;
              }
              catch(Exception ex)
              {
                  throw new Exception("Ocurrio un error al cargar sorteo categoria. \n" + ex.Message);
              }
              finally
              {
                  miConexion.MiConexion.Close();
              }
          }

          /// <summary>
          /// Consulta sorteo tipo categoria periodos
          /// </summary>
          /// <param name="idTipo">id tipo</param>
          /// <param name="fecha1">fecha1</param>
          /// <param name="fecha2">fecha2</param>
          /// <param name="historial">detarmina el estado de la consulta</param>
          /// <param name="regirstroBase">registro base de la consulta</param>
          /// <param name="registroMaximo">numero de registros a recuperar</param>
          /// <returns></returns>
          public DataTable ConsultarSorteoCategoriaPeriodos
              (int idTipo, DateTime fecha1, DateTime fecha2, bool historial, int regirstroBase, int registroMaximo)
          {
              try
              {
                  miDataSet = new DataSet();
                  if (historial)
                  {
                      CargarAdapterStoreProsedure(sqlConsultarHistorialSorteocategoriaP);
                  }
                  else
                  {
                      CargarAdapterStoreProsedure(sqlConsultarSorteoCategoriaP);
                  }
                  miAdapter.SelectCommand.Parameters.AddWithValue("idtipo", idTipo);
                  miAdapter.SelectCommand.Parameters.AddWithValue("fecha1", fecha1);
                  miAdapter.SelectCommand.Parameters.AddWithValue("fecha2", fecha2);
                  miAdapter.Fill(miDataSet, regirstroBase, registroMaximo, "sorteo");
                  return miDataSet.Tables[0];
              }
              catch(Exception  ex)
              {
                  throw new Exception("Error al consultar sorteo categoria. \n" + ex.Message);
              }
          }

          /// <summary>
          /// Obtiene el total de los registros de sorteo categoria periodo.
          /// </summary>
          /// <param name="idTipo">id tipo</param>
          /// <param name="fecha1">fecha1</param>
          /// <param name="fecha2">fecha2</param>
          /// <param name="historial">determina el estado de la consulta</param>
          /// <returns></returns>
          public long RowListarSorteocategoriaPeriodos
              (int idTipo, DateTime fecha1, DateTime fecha2, bool historial)
          {
              try
              {
                  if (historial)
                  {
                      CargaComandoStoreProsedure("count_listar_historial_sorteo_categoria_periodos");
                  }
                  else
                  {
                      CargaComandoStoreProsedure("count_listar_sorteo_categoria");
                  }
                  miComando.Parameters.AddWithValue("idtipo", idTipo);
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
                  throw new Exception("Ocurrio un error al cargar sorteo categoria. \n" + ex.Message);
              }
              finally
              { }
          }

          /// <summary>
          /// Consulta sorteo producto fechas
          /// </summary>
          /// <param name="idTipo">id tipo</param>
          /// <param name="codigoInternoProducto">codigo internu producto</param>
          /// <param name="fecha">fechas</param>
          /// <param name="historial">determina el estado de la consulta</param>
          /// <returns></returns>
          public DataTable ConsultarSorteoProductoFechas
              (int idTipo, string codigoInternoProducto, DateTime fecha, bool historial)
          {
              try
              {
                  miDataTable = new DataTable();
                  if (historial)
                  {
                      CargarAdapterStoreProsedure(sqlConsultarHistorialSorteoproductoFechas);
                  }
                  else
                  {
                      CargarAdapterStoreProsedure(sqlConsultarSorteoProductofechas);
                  }
                  miAdapter.SelectCommand.Parameters.AddWithValue("idtipo", idTipo);
                  miAdapter.SelectCommand.Parameters.AddWithValue("codigointernoproducto", codigoInternoProducto);
                  miAdapter.SelectCommand.Parameters.AddWithValue("fechas", fecha);
                  miAdapter.Fill(miDataTable);
                  return miDataTable;
              }
              catch(Exception ex)
              {
                  throw new Exception("Error al consultar sorteo producto. \n" + ex.Message);
              }
          }

          /// <summary>
          /// consulta sorteo tipo producto fechas
          /// </summary>
          /// <param name="idTipo">id tipo</param>
          /// <param name="fechas">fechas</param>
          /// <param name="historial">historial</param>
          /// <param name="registroBase">registro base de la consulta</param>
          /// <param name="regirtoMaximo">numero de registros a recuperar</param>
          /// <returns></returns>
          public DataTable ConsultarSorteoProductoFechas
              (int idTipo, DateTime fechas, bool historial, int registroBase, int regirtoMaximo)
          {
              try
              {
                  miDataSet=new DataSet();
                  if (historial)
                  {
                      CargarAdapterStoreProsedure(sqlConsultarHistorialSorteoProducto);
                  }
                  else
                  {
                      CargarAdapterStoreProsedure(sqlConsultarSorteoProducto);
                  }
                  miAdapter.SelectCommand.Parameters.AddWithValue("idtipo", idTipo);
                  miAdapter.SelectCommand.Parameters.AddWithValue("fechas", fechas);
                  miAdapter.Fill(miDataSet, registroBase, regirtoMaximo, "sorteo");
                  return miDataSet.Tables[0];
              }
              catch(Exception ex)
              {
                  throw new Exception("Error al consultar sorteo producto. \n" + ex.Message);
              }
          }

          /// <summary>
          /// Obtiene el total de la consulta sorteo producto fechas
          /// </summary>
          /// <param name="idTipo">id tipo</param>
          /// <param name="fechas">fechas</param>
          /// <param name="historial">determina el valor de la consulta</param>
          /// <returns></returns>
          public long RowListarSorteoProductoFechas
              (int idTipo, DateTime fechas, bool historial)
          {
              try
              {
                  if (historial)
                  {
                      CargaComandoStoreProsedure("count_listar_historial_sorteo_producto");
                  }
                  else
                  {
                      CargaComandoStoreProsedure("count_listar_sorteo_producto");
                  }
                  miComando.Parameters.AddWithValue("idtipo", idTipo);
                  miComando.Parameters.AddWithValue("fehcas", fechas);
                  miConexion.MiConexion.Open();
                  var rows = Convert.ToInt64(miComando.ExecuteScalar());
                  miConexion.MiConexion.Close();
                  miComando.Dispose();
                  return rows;
              }
              catch (Exception ex)
              {
                  throw new Exception("Ocurrio un error al cargar sorteo producto. \n" + ex.Message);
              }
              finally
              {
                  miConexion.MiConexion.Close();
              }
          }

           /// <summary>
          /// Consulta sorteo producto periodo
          /// </summary>
          /// <param name="idTipo">id tipo</param>
          /// <param name="codigoInternoProducto">codigo interno producto</param>
          /// <param name="fecah1">fecha1</param>
          /// <param name="fecha2">fecha2</param>
          /// <param name="historial">determina el estado de la consulta</param>
          /// <returns></returns>
          public DataTable ConsultarSorteoProductoPeriodos
              (int idTipo, string codigoInternoProducto, DateTime fecah1, DateTime fecha2, bool historial,int registroBase, int RegistroMaximo)
          {
              try
              {
                  miDataSet = new DataSet();
                  if (historial)
                  {
                      CargarAdapterStoreProsedure(sqlConsultarHistorialSorteoProductoPeriodo);
                  }
                  else
                  {
                      CargarAdapterStoreProsedure(sqlConsultarSorteoProductoPeriodos);
                  }
                  miAdapter.SelectCommand.Parameters.AddWithValue("idtipo", idTipo);
                  miAdapter.SelectCommand.Parameters.AddWithValue("codigoInternoProducto", codigoInternoProducto);
                  miAdapter.SelectCommand.Parameters.AddWithValue("fecha1", fecah1);
                  miAdapter.SelectCommand.Parameters.AddWithValue("fecha2", fecha2);
                  miAdapter.Fill(miDataSet,registroBase,RegistroMaximo,"sorteo");
                  return miDataSet.Tables[0];
              }
              catch(Exception ex)
              {
                  throw new Exception("Error al consultar sorteo producto. \n" + ex.Message);
              }
          }

          /// <summary>
          /// Obtiene el total de los registros de sorteo producto periodos
          /// </summary>
          /// <param name="idTipo">id tipo</param>
          /// <param name="codigoInternoProducto">codigo interno producto </param>
          /// <param name="fecha1">fecha1</param>
          /// <param name="fecha2">fecha2</param>
          /// <param name="historial">determina el valor de la consulta</param>
          /// <returns></returns>
          public long RowListarSorteoProducto
              (int idTipo, string codigoInternoProducto, DateTime fecha1, DateTime fecha2, bool historial)
          {
              try
              {
                  if (historial)
                  {
                      CargaComandoStoreProsedure("count_listar_historial_sorteo_producto");
                  }
                  else
                  {
                      CargaComandoStoreProsedure("count_listar_sorteo_producto");
                  }
                  miComando.Parameters.AddWithValue("idtipo", idTipo);
                  miComando.Parameters.AddWithValue("codigointernoproducto", codigoInternoProducto);
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
                  throw new Exception("Ocurrio un error al consultar sorteo producto. \n" + ex.Message);
              }
              finally
              { }
          }

          /// <summary>
          /// Consulta sorteo tipo producto periodo
          /// </summary>
          /// <param name="idTipo">id tipo</param>
          /// <param name="fecha1">fecha1</param>
          /// <param name="fecha2">fecha2</param>
          /// <param name="historial">determina el valor de la consulta</param>
          /// <param name="registroBase">registron base de la consulta</param>
          /// <param name="registroMaximo">numero de registros a recuperar</param>
          /// <returns></returns>
          public DataTable ConsultarSorteoProductoPeriodos
              (int idTipo, DateTime fecha1, DateTime fecha2, bool historial, int registroBase, int registroMaximo)
          {
              try
              {
                  miDataSet = new DataSet();
                  if (historial)
                  {
                      CargarAdapterStoreProsedure(sqlConsultarhistorialSorteoProductoP);
                  }
                  else
                  {
                      CargarAdapterStoreProsedure(sqlConsultarSorteoProductoP);
                  }
                  miAdapter.SelectCommand.Parameters.AddWithValue("idtipo", idTipo);
                  miAdapter.SelectCommand.Parameters.AddWithValue("fecha1", fecha1);
                  miAdapter.SelectCommand.Parameters.AddWithValue("fecha2", fecha2);
                  miAdapter.Fill(miDataSet, registroBase, registroMaximo, "sorteo");
                  return miDataSet.Tables[0];
              }
              catch(Exception ex)
              {
                  throw new Exception("Error al consultar sorteo producto. \n" + ex.Message);
              }
          }

          /// <summary>
          /// Obtiene el total de los registros de sorteo productis periodo
          /// </summary>
          /// <param name="idTipo">id tipo</param>
          /// <param name="fecha1">fecha1</param>
          /// <param name="fecha2">fecha2</param>
          /// <param name="historial">determina el estado de la consulta</param>
          /// <returns></returns>
          public long RowListarSorteoProductoPeriodos
              (int idTipo, DateTime fecha1, DateTime fecha2, bool historial)
          {
              try
              {
                  if (historial)
                  {
                      CargaComandoStoreProsedure("count_listar_historial_sorteo_producto_periodos");
                  }
                  else
                  {
                      CargaComandoStoreProsedure("count_listar_sorteo_producto");
                  }
                  miComando.Parameters.AddWithValue("idtipo", idTipo);
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
                  throw new Exception("Ocurrio un error al cargar sorteo producto. \n"+ex.Message);
              }
              finally
              { }
          }

          /// <summary>
          /// Consulta sorteo tipo factura fechas.
          /// </summary>
          /// <param name="idTipo">id tipo</param>
          /// <param name="fechas">fechas</param>
          /// <param name="historial">Determina el valor de la consulta</param>
          /// <returns></returns>
          public DataTable ConsultarSorteoFacturaFechas
              (int idTipo, DateTime fechas, bool historial)
          {
              try
              {
                  miDataTable = new DataTable();
                  if (historial)
                  {
                      CargarAdapterStoreProsedure(sqlConsultarHistorialSorteoFacturaFechas);
                  }
                  else
                  {
                      CargarAdapterStoreProsedure(sqlConsultarSorteofacturafechas);
                  }
                  miAdapter.SelectCommand.Parameters.AddWithValue("idtipo", idTipo);
                  miAdapter.SelectCommand.Parameters.AddWithValue("fechas", fechas);
                  miAdapter.Fill(miDataTable);
                  return miDataTable;
              }
              catch(Exception ex)
              {
                  throw new Exception("Error al consultar sorteo por factura. \n" + ex.Message);
              }
             
          }

          /// <summary>
          /// Consulta sorteo tipo factura periodos.
          /// </summary>
          /// <param name="idTipo">id tipo</param>
          /// <param name="fecha1">fecha1</param>
          /// <param name="fecha2">fecah2</param>
          /// <param name="historial">determina el valor de la consulta</param>
          /// <param name="registroBase">registrao base de la consulta</param>
          /// <param name="regirstroMaximo">numero de registros a recuperar</param>
          /// <returns></returns>
          public DataTable ConsultarSorteoFacturaPeriodos
              (int idTipo, DateTime fecha1, DateTime fecha2, bool historial, int registroBase, int regirstroMaximo)
          {
              try
              {
                  miDataSet = new DataSet();
                  if (historial)
                  {
                      CargarAdapterStoreProsedure(sqlConsultarHistorialSorteofacturaperiodos);
                  }
                  else
                  {
                      CargarAdapterStoreProsedure(sqlConsultarSorteoFacturaPeriodo);
                  }
                  miAdapter.SelectCommand.Parameters.AddWithValue("idtipo", idTipo);
                  miAdapter.SelectCommand.Parameters.AddWithValue("fecha1", fecha1);
                  miAdapter.SelectCommand.Parameters.AddWithValue("fecha2", fecha2);
                  miAdapter.Fill(miDataSet, registroBase, regirstroMaximo, "sorteo");
                  return miDataSet.Tables[0];
              }
              catch(Exception ex)
              {
                  throw new Exception("Error al consultar sorteo factura. \n" + ex.Message);
              }
          }

          /// <summary>
          /// Consulta sorteo tipo factura periodos
          /// </summary>
          /// <param name="idTipo">id tipo</param>
          /// <param name="fecha1">fecha1</param>
          /// <param name="fecha2">fecha2</param>
          /// <param name="historial">determina el valor de la consulta</param>
          /// <returns></returns>
          public long RowListarSorteoFacturaPeriodo
              (int idTipo, DateTime fecha1, DateTime fecha2, bool historial)
          {
              try
              {
                  if (historial)
                  {
                      CargaComandoStoreProsedure("count_listar_historial_sorteo_factura_periodos");
                  }
                  else
                  {
                      CargaComandoStoreProsedure("count_listar_sorteo_factura");
                  }
                  miComando.Parameters.AddWithValue("idTipo", idTipo);
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
                  throw new Exception("Ocurrio un error al consultar sorteo factura. \n" + ex.Message);
              }
              finally
              {
                  miConexion.MiConexion.Close();
              }
          }

          /// <summary>
          /// Consulta sorteo por fechas
          /// </summary>
          /// <param name="fechas">fechas</param>
          /// <param name="historial">determina el valor de la consulta</param>
          /// <returns></returns>
          public DataTable ConsultarSorteoFechas
              (DateTime fechas, bool historial, int registroBase, int registroMaximo)
          {
              try
              {
                  miDataSet=new DataSet();
                  if (historial)
                  {
                      CargarAdapterStoreProsedure(sqlConsultarHistorialSorteoFechas);
                  }
                  else
                  {
                      CargarAdapterStoreProsedure(sqlConsultarSorteofechas);
                  }
                  miAdapter.SelectCommand.Parameters.AddWithValue("fechas", fechas);
                  miAdapter.Fill(miDataSet,registroBase,registroMaximo,"sorteo");
                  return miDataSet.Tables[0];
              }
              catch(Exception ex)
              {
                  throw new Exception ("Error al consultar sorteo fechas. \n"+ex.Message);
              }
              
          }

          /// <summary>
          /// Obtiene el total de los registros de sorteo fechas
          /// </summary>
          /// <param name="fechas">fechas</param>
          /// <param name="historial">determina el valor de la consulta</param>
          /// <returns></returns>
          public long RowListarSorteoFechas
              (DateTime fechas, bool historial)
          {
              try
              {
                  if (historial)
                  {
                      CargaComandoStoreProsedure("count_listar_historial_sorteo_fechas");
                  }
                  else
                  {
                      CargaComandoStoreProsedure("count_listar_sorteo_fechas");
                  }
                  miComando.Parameters.AddWithValue("fecha",fechas);
                  miConexion.MiConexion.Open();
                  var rows=Convert.ToInt64(miComando.ExecuteScalar());
                  miConexion.MiConexion.Close();
                  miComando.Dispose();
                  return rows;
              }
              catch(Exception ex)
              {
                  throw new Exception ("Ocurrio un error al cargar sorteo fechas. \n"+ex.Message);
              }
          }

          /// <summary>
          /// Consulta sorteo periodos
          /// </summary>
          /// <param name="fecha1">fecha1</param>
          /// <param name="fecha2">fecha2</param>
          /// <param name="historial">detrmina el valor de la consulta</param>
          /// <param name="registroBase">registro base de la consulta</param>
          /// <param name="registroMaximo">numero de registros a recuperar</param>
          /// <returns></returns>
          public DataTable ConsultarSorteoPeriodos
              (DateTime fecha1, DateTime fecha2, bool historial, int registroBase, int registroMaximo)
          {
              try
              {
                  miDataSet = new DataSet();
                  if (historial)
                  {
                      CargarAdapterStoreProsedure(sqlConsultarHistorialSorteoPeriodos);
                  }
                  else
                  {
                      CargarAdapterStoreProsedure(sqlConsultarSorteoPeriodos);
                  }
                  miAdapter.SelectCommand.Parameters.AddWithValue("fecha1", fecha1);
                  miAdapter.SelectCommand.Parameters.AddWithValue("fecha2", fecha2);
                  miAdapter.Fill(miDataSet, registroBase, registroMaximo, "sorteo");
                  return miDataSet.Tables[0];
              }
              catch(Exception ex)
              {
                  throw new Exception("Error al consultar sorteo periodos. \n" + ex.Message);
              }
          }

          /// <summary>
          /// Obtiene el total de los registros de sorteo periodos,
          /// </summary>
          /// <param name="fecha1">fecha1</param>
          /// <param name="fecha2">fecha2</param>
          /// <param name="historial">determina el valor de la consulta</param>
          /// <returns></returns>
          public long RowListarSorteoPeriodo
              (DateTime fecha1, DateTime fecha2, bool historial)
          {
              try
              {
                  if (historial)
                  {
                      CargaComandoStoreProsedure("count_listar_historial_sorteo_periodos");
                  }
                  else
                  {
                      CargaComandoStoreProsedure("count_listar_sorteo_periodo");
                  }
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
                  throw new Exception("Ocurrio un error al cargar sorteo periodos. \n" + ex.Message);
              }
              finally
              { }
          }

          /// <summary>
          /// Lista sorteo fecha inicio por fecha simple.
          /// </summary>
          /// <param name="fecha"></param>
          /// <returns></returns>
          public DataTable ConsultaSorteoFechaInicioFechas
              (DateTime fecha, bool historial)
          {
              try
              {
                  miDataTable = new DataTable();
                  if (historial)
                  {
                      CargarAdapterStoreProsedure(sqlListarHistorialFechaInicioFechaSimple);
                  }
                  else
                  {
                      CargarAdapterStoreProsedure(sqlListaSorteoIniciofechaSimple);
                  }
                  miAdapter.SelectCommand.Parameters.AddWithValue("fecha", fecha);
                  miAdapter.Fill(miDataTable);
                  return miDataTable;
              }
              catch(Exception ex)
              {
                  throw new Exception("Error al listar fecha. \n" + ex.Message);
              }
          }

          /// <summary>
          /// consulta sorteo inicializacion de sorteo
          /// </summary>
          /// <param name="fecha">fecha1</param>
          /// <param name="fecha2">fecha2</param>
          /// <param name="historial">determina el valor de la consulta</param>
          /// <param name="registroBase">registro base de la consulta</param>
          /// <param name="registroMaximo">numero de registros a recuperar</param>
          /// <returns></returns>
          public DataTable ConsultaSorteoFechaInicioPeriodo
              (DateTime fecha, DateTime fecha2, bool historial, int registroBase, int registroMaximo)
          {
              try
              {
                  miDataSet = new DataSet();
                  if (historial)
                  {
                      CargarAdapterStoreProsedure(sqlListarHistorialFechaInicioPeriodosFecha);
                  }
                  else
                  {
                      CargarAdapterStoreProsedure(sqlListaSorteoInicioPeriodoFecha);
                  }
                  miAdapter.SelectCommand.Parameters.AddWithValue("fechainicio", fecha);
                  miAdapter.SelectCommand.Parameters.AddWithValue("fechafin", fecha2);
                  miAdapter.Fill(miDataSet,registroBase,registroMaximo,"sorteo");
                  return miDataSet.Tables[0];
              }
              catch (Exception ex)
              {
                  throw new Exception("Error al listar periodos de fechas.\n"+ex.Message);
              }
          }

          /// <summary>
          /// Obtiene el total de los registros de inicializacion de sorteos periodos.
          /// </summary>
          /// <param name="historial">determina el valor de la consulta</param>
          /// <param name="fecha1">fecha1</param>
          /// <param name="fecha2">fecha2</param>
          /// <returns></returns>
          public long RowListarFechaInicioPeriodos
              ( DateTime fecha1, DateTime fecha2,bool historial)
          {
              try
              {
                  if (historial)
                  {
                      CargaComandoStoreProsedure("count_listar_historial_sorteo_fecha_inicio_periodo");
                  }
                  else
                  {
                      CargaComandoStoreProsedure("count_listar_sorteo_fecha_inicio_periodo");
                  }
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
                  throw new Exception("Ocurrio un error al consultar inicializacion de sorteo. \n" + ex.Message);
              }
              finally
              {
                  miConexion.MiConexion.Close();
              }
          }

          /// <summary>
          /// lista fecha simple de sorteo fecha fin.
          /// </summary>
          /// <param name="fecha">fehas</param>
          /// <returns></returns>
          public DataTable ConsultaSorteoFechaFinFechas
              (DateTime fecha, bool historial)
          {
              try
              {
                  miDataTable = new DataTable();
                  if (historial)
                  {
                      CargarAdapterStoreProsedure(sqllistarHistorialFechaFinfechaSimple);
                  }
                  else
                  {
                      CargarAdapterStoreProsedure(sqlListaSorteoFechaFin);
                  }
                  miAdapter.SelectCommand.Parameters.AddWithValue("fechafin", fecha);
                  miAdapter.Fill(miDataTable);
                  return miDataTable;
              }
              catch (Exception ex)
              {
                  throw new Exception("Error al listar fechas. \n"+ex.Message);
              }
          }

          /// <summary>
          /// Consulta finalizacion de sorteo periodos
          /// </summary>
          /// <param name="fecha1">fecha1</param>
          /// <param name="fecha2">fecha2</param>
          /// <param name="historial">determina el valor de la consulta</param>
          /// <param name="registroBase">Registro base de la consulta</param>
          /// <param name="registroMaximo">numero de registros a recuperar</param>
          /// <returns></returns>
          public DataTable ConsultaSorteoFechaFinPeriodo
              (DateTime fecha1, DateTime fecha2, bool historial, int registroBase,int registroMaximo)
          {
              try
              {
                  miDataSet = new DataSet();
                  if (historial)
                  {
                      CargarAdapterStoreProsedure(sqlListarHistorialFechaFinPeriodofecha);
                  }
                  else
                  {
                      CargarAdapterStoreProsedure(sqlListaSorteoPeriodoFechaFin);
                  }
                  miAdapter.SelectCommand.Parameters.AddWithValue("fechainicio", fecha1);
                  miAdapter.SelectCommand.Parameters.AddWithValue("fechafin", fecha2);
                  miAdapter.Fill(miDataSet,registroBase,registroMaximo,"sorteo");
                  return miDataSet.Tables[0];
              }
              catch (Exception ex)
              {
                  throw new Exception("Error al listar periodos de fechas. \n"+ex.Message);
              }
          }

          /// <summary>
          /// Obtiene el total de los registros de finalizacion de sorteos periodos
          /// </summary>
          /// <param name="historial">determina el valor de la consulta</param>
          /// <param name="fecha1">fecha1</param>
          /// <param name="fecha2">fecha2</param>
          /// <returns></returns>
          public long RowListarFechaFinPeriodos
              (bool historial, DateTime fecha1, DateTime fecha2)
          {
              try
              {
                  if (historial)
                  {
                      CargaComandoStoreProsedure("count_listar_historial_sorteo_fecha_fin_periodo");
                  }
                  else
                  {
                      CargaComandoStoreProsedure("count_listar_sorteo_fecha_fin_periodo");
                  }
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
                  throw new Exception("Ocurrio un error al cargar  finalizacion de sorteos. \n" + ex.Message);
              }
              finally
              {
                  miConexion.MiConexion.Close();
              }
          }

          /// <summary>
          /// Lista sorteo por fecha simple fecha de sorteo.
          /// </summary>
          /// <param name="fecha"></param>
          /// <returns></returns>
          public DataTable ConsultaSorteoFechaSorteoFechas
              (DateTime fecha, bool historial)
          {
              try
              {
                  miDataTable = new DataTable();
                  if (historial)
                  {
                      CargarAdapterStoreProsedure(sqlListarHistorialFechaSorteoFechaSimple);
                  }
                  else
                  {
                      CargarAdapterStoreProsedure(sqlListaSorteoFechaSorteo);
                  }
                  miAdapter.SelectCommand.Parameters.AddWithValue("fechasorteo", fecha);
                  miAdapter.Fill(miDataTable);
                  return miDataTable;
              }
              catch (Exception ex)
              {
                  throw new Exception("Error al consultar sorteo pofechas. \n"+ex.Message);
              }

          }

          /// <summary>
          /// lista periodos de fechas por sorteo.
          /// </summary>
          /// <param name="fecha"></param>
          /// <param name="fecha2"></param>
          /// <returns></returns>
          public DataTable ConsultaSorteoFechaSorteoperiodos
              (DateTime fecha, DateTime fecha2, bool historial, int registroBase,int registroMaximo)
          {
              try
              {
                  miDataSet = new DataSet();
                  if (historial)
                  {
                      CargarAdapterStoreProsedure(sqlListarHistorialFechaSorteoPeriodoFecha);
                  }
                  else
                  {
                      CargarAdapterStoreProsedure(sqlListaSorteoPeriodoFechaSorteo);
                  }
                  miAdapter.SelectCommand.Parameters.AddWithValue("fecha", fecha);
                  miAdapter.SelectCommand.Parameters.AddWithValue("fecha2", fecha2);
                  miAdapter.Fill(miDataSet,registroBase,registroMaximo,"sorteo");
                  return miDataSet.Tables[0];
              }
              catch (Exception ex)
              {
                  throw new Exception("Error al consultar sorte por fechas de periodos. \n"+ex.Message);
              }
          }

          /// <summary>
          /// Obtiene el total de lor registros de fechas sorteo periodos
          /// </summary>
          /// <param name="historial">determina el valor  de la consulta</param>
          /// <param name="fecha1">fecha1</param>
          /// <param name="fecha2">fecha2</param>
          /// <returns></returns>
          public long RowListarFechaSorteoPeriodo
              (bool historial, DateTime fecha1, DateTime fecha2)
          {
              try
              {
                  if (historial)
                  {
                      CargaComandoStoreProsedure("count_listar_historial_sorteo_fecha_sorteo_periodo");
                  }
                  else
                  {
                      CargaComandoStoreProsedure("count_listar_sorteo_fecha_sorteo_periodo");
                  }
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
                  throw new Exception("Ocurrio un error al consultar fechas sorteo. \n" + ex.Message);
              }
              finally
              {
                  miConexion.MiConexion.Close();
              }
          }

          /// <summary>
          /// lista el historial de sorteo
          /// </summary>
          /// <returns></returns>
          public DataTable ListarHistorialSorteo(int registroBase, int registroMaximo)
          {
              try
              {
                  miDataSet = new DataSet();
                  CargarAdapterStoreProsedure(sqlListarHistorialSorteo);
                  miAdapter.Fill(miDataSet, registroBase, registroMaximo, "sorteo");
                  return miDataSet.Tables[0];

              }
              catch(Exception ex)
              {
                  throw new Exception("Error al listar el historial de sorteo. \n"+ex.Message);
              }
          }

          /// <summary>
          /// Obtiene el total de los registros de historial sorteo
          /// </summary>
          /// <returns></returns>
          public long RowListarHistorialSorteo()
          {
              try
              {
                  CargaComandoStoreProsedure("count_listar_historial_sorteo");
                  miConexion.MiConexion.Open();
                  var rows = Convert.ToInt64(miComando.ExecuteScalar());
                  miConexion.MiConexion.Close();
                  miComando.Dispose();
                  return rows;
              }
              catch(Exception ex)
              {
                  throw new Exception("Ocurrio un error al consultar historial de sorteos.\n" + ex.Message);
              }
              finally
              {
                  miConexion.MiConexion.Close();
              }
          }

          /// <summary>
          /// Existe sorteo marca
          /// </summary>
          /// <param name="codigo">codigo marca</param>
          /// <param name="fecha1">fecha1</param>
          /// <param name="fecha2">fecha2</param>
          /// <returns></returns>
          public bool ExisteSorteoMarca(int codigo, DateTime fecha1, DateTime fecha2)
          {
              try
              {                
                  CargaComandoStoreProsedure("existe_sorteo_marca");     
                  miComando.Parameters.AddWithValue("codigo", codigo);
                  miComando.Parameters.AddWithValue("fecha1", fecha1);
                  miComando.Parameters.AddWithValue("fecha2", fecha2);
                  miConexion.MiConexion.Open();
                  var resultado = Convert.ToBoolean(miComando.ExecuteScalar());
                  miConexion.MiConexion.Close();
                  miComando.Dispose();
                  return resultado;
              }
              catch (Exception ex)
              {
                  throw new Exception("Error al consultar el registro. \n" + ex.Message);
              }
              finally
              {
                  miConexion.MiConexion.Close();
              }
          }

          /// <summary>
          /// Existe sorteo categoria
          /// </summary>
          /// <param name="codigo">codigo categoria</param>
          /// <param name="fecha1">fecha1</param>
          /// <param name="fecha2">fecha2</param>
          /// <returns></returns>
          public bool ExisteSorteoCategoria(string codigo, DateTime fecha1, DateTime fecha2)
          {
              try
              {
                  CargaComandoStoreProsedure("existe_sorteo_categoria");
                  miComando.Parameters.AddWithValue("codigo", codigo);
                  miComando.Parameters.AddWithValue("fecha1", fecha1);
                  miComando.Parameters.AddWithValue("fecha2", fecha2);
                  miConexion.MiConexion.Open();
                  var resultado = Convert.ToBoolean(miComando.ExecuteScalar());
                  miConexion.MiConexion.Close();
                  miComando.Dispose();
                  return resultado;
              }
              catch (Exception ex)
              {
                  throw new Exception("Error al consultar  el  registro. \n" + ex.Message);
              }
              finally
              {
                  miConexion.MiConexion.Close();
              }
          }

          /// <summary>
          /// Existe sorteo producto
          /// </summary>
          /// <param name="codigo">codigo producto</param>
          /// <param name="fecha1">fecha1</param>
          /// <param name="fecha2">fecha2</param>
          /// <returns></returns>
          public bool ExisteSorteoProducto(string codigo, DateTime fecha1, DateTime fecha2)
          {
              try
              {
                  CargaComandoStoreProsedure("existe_sorteo_producto");
                  miComando.Parameters.AddWithValue("codigo",codigo);
                  miComando.Parameters.AddWithValue("fecha1",fecha1);
                  miComando.Parameters.AddWithValue("fecha2",fecha2);
                  miConexion.MiConexion.Open();
                  var resultado=Convert.ToBoolean(miComando.ExecuteScalar());
                  miConexion.MiConexion.Close();
                  miComando.Dispose();
                  return resultado;
              }
              catch(Exception ex)
              {
                  throw new Exception ("Error al consultar el registro. \n"+ex.Message);
              }
              finally
              {
                  miConexion.MiConexion.Close();
              }
          }

          /// <summary>
          /// Existe sorteo factura
          /// </summary>
          /// <param name="idTipo">idtipo</param>
          /// <param name="fecha1">fecha1</param>
          /// <param name="fecha2">fecha2</param>
          /// <returns></returns>
          public bool ExisteSorteoFactura(int idTipo,DateTime fecha1, DateTime fecha2)
          {
              try
              {
                  CargaComandoStoreProsedure("existe_sorteo_factura");
                  miComando.Parameters.AddWithValue("idtipo", idTipo);
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
                  throw new Exception("Error al consultar el registro. \n" + ex.Message);
              }
              finally
              {
                  miConexion.MiConexion.Close();
              }
          }
          

          /// <summary>
          ///lista de la base de datos, el cual muestra toda la informacion de un sorteo mediante su id
          /// </summary>
          /// <param name="idSorteo"></param>
          /// <returns></returns>
          public Sorteo CargarSorteo(int idSorteo, bool historial)
          {
              var miDaoMarca = new DaoMarca();
              var miDaoCategoria=new DaoCategoria();
              var miDaoProducto=new DaoProducto();
              Sorteo misorteo = new Sorteo();
              try
              {
                  if (historial)
                  {
                      CargaComandoStoreProsedure(sqlListaSorteoHistorialCompleto);
                  }
                  else
                  {
                      CargaComandoStoreProsedure(sqlListaCompletaSorteo);
                  }
                  miComando.Parameters.AddWithValue("idsorteo", idSorteo);
                  miConexion.MiConexion.Open();

                  NpgsqlDataReader myReader = miComando.ExecuteReader();

                  while (myReader.Read())
                  {
                      misorteo.IdTipoSorteo = myReader.GetInt32(0);
                      misorteo.NombreTipoSorteo = myReader.GetString(1);
                      misorteo.IdSorteo = myReader.GetInt32(2);                                       
                      misorteo.NombreSorteo = myReader.GetString(3);
                      misorteo.FechaInicioSorteo = myReader.GetDateTime(4);
                      misorteo.FechaFinalSorteo = myReader.GetDateTime(5);
                      misorteo.FechaSorteo = myReader.GetDateTime(6);
                      misorteo.PatrocinadoresSorteo = myReader.GetString(7);
                      misorteo.PremioSorteo = myReader.GetString(8);
                      misorteo.ValorMinimoCompraSorteo = myReader.GetDouble(9);
                      var textoEstado =myReader.GetString(10);
                      if (textoEstado == "Activo")
                      {
                          misorteo.EstadoSorteo = true;
                      }
                      else
                      {
                          textoEstado ="Inactivo";
                          misorteo.EstadoSorteo = false;
                      }
                      misorteo.AplicaVenta = myReader.GetBoolean(11);
                      misorteo.TiqueteMultiple = myReader.GetBoolean(12);
                      misorteo.ValorPremio = myReader.GetDouble(13);
                      misorteo.AplicaHora = myReader.GetBoolean(14);
                      misorteo.HoraInicio = myReader.GetDateTime(15);
                      misorteo.HoraFin = myReader.GetDateTime(16);
                      misorteo.Concepto = myReader.GetString(17);


                      
                  }
                  if (misorteo.IdTipoSorteo == 2)
                  {
                      if (historial)
                      {
                          misorteo.Marcas = miDaoMarca.CargarMarcasSorteo(idSorteo, true);
                      }
                      else
                      {
                          misorteo.Marcas = miDaoMarca.CargarMarcasSorteo(idSorteo, false);
                      }
                  }
                  else
                  {
                      if (misorteo.IdTipoSorteo == 3)
                      {
                          if (historial)
                          {
                              misorteo.Categorias = miDaoCategoria.CargarCategoriaSorteo(idSorteo, true);
                          }
                          else
                          {
                              misorteo.Categorias = miDaoCategoria.CargarCategoriaSorteo(idSorteo, false);
                          }
                      }
                      else
                      {
                          if (misorteo.IdTipoSorteo == 4)
                          {
                              if (historial)
                              {
                                  misorteo.Producto = miDaoProducto.CargaProductoSorteo(idSorteo, false);
                              }
                              else
                              {
                                  misorteo.Producto = miDaoProducto.CargaProductoSorteo(idSorteo, false);
                              }
                          }
                      }
                  }

                  miConexion.MiConexion.Close();
                  miComando.Dispose();
                  return misorteo;
              }
              catch (Exception ex)
              {
                  throw new Exception("No se pudo consultar el sorteo. \n" + ex.Message);
              }
              finally
              {
                  miConexion.MiConexion.Close();
              }
          }

          /// <summary>
          /// elimina la marca de el sorteo.
          /// </summary>
          /// <param name="idmarca"> idmarca a eliminar</param>
          /// <param name="idMiSorteoOriginal">idsorteo a eliminar</param>
          public void EliminaSorteoMarca(int idMiSorteoOriginal , int idmarca )
          {
              try
              {
                  CargaComandoStoreProsedure(sqlEliminarMarcaSorteo);
                  miComando.Parameters.AddWithValue("idsorteo", idMiSorteoOriginal);
                  miComando.Parameters.AddWithValue("idmarca", idmarca);
                  miConexion.MiConexion.Open();
                  miComando.ExecuteNonQuery();
                  miConexion.MiConexion.Close();
                  miComando.Dispose();
              }
              catch (Exception ex)
              {
                  throw new Exception("Error al eliminar la marca de el sorteo. \n" + ex.Message);
              }
              finally
              {
                  miConexion.MiConexion.Close();
              }

          }

          /// <summary>
          /// Elimina la categoria de el sorteo.
          /// </summary>
          /// <param name="idMiSorteoOriginal">id del sorteo a eliminar</param>
          /// <param name="codigoCategoria">id de la categoria a eliminar</param>
          public void EliminaSorteoCategoria(int idMiSorteoOriginal, string codigoCategoria)
          {
              try 
              {
                  CargaComandoStoreProsedure(sqlEliminacategoriaSorteo);
                  miComando.Parameters.AddWithValue("idSorteo", idMiSorteoOriginal);
                  miComando.Parameters.AddWithValue("codigoCategoria", codigoCategoria);             
                  miConexion.MiConexion.Open();
                  miComando.ExecuteNonQuery();
                  miConexion.MiConexion.Close();
                  miComando.Dispose();
              }
              catch(Exception ex)
              {
                  throw new Exception("Error al eliminar la categoria de el sorteo. \n" + ex.Message);
              }
              finally
              {
                  miConexion.MiConexion.Close();
              }
          }

          /// <summary>
          /// Elimina el Producto de el sorteo.
          /// </summary>
          /// <param name="idSorteoOriginal"></param>
          /// <param name="codigointernoproducto"></param>
          public void EliminaSorteoProducto(int idSorteoOriginal, string codigointernoproducto)
          {
              try
              {
                  CargaComandoStoreProsedure(sqlEliminarProductoSorteo);
                  miComando.Parameters.AddWithValue("idSorteo", idSorteoOriginal);
                  miComando.Parameters.AddWithValue("idProducto", codigointernoproducto);
                  miConexion.MiConexion.Open();
                  miComando.ExecuteNonQuery();
                  miConexion.MiConexion.Close();
              }
              catch (Exception ex)
              {
                  throw new Exception("Error al eliminar producto del sorteo. \n" + ex.Message);
              }
              finally
              {
                  miConexion.MiConexion.Close();
              }
          }

          /// <summary>
          /// Inserta cliente a sorteo
          /// </summary>
          /// <param name="idSorteoOriginal">id sorteo</param>
          /// <param name="codigoFacturavanta">codigo factura</param>
          /// <returns></returns>
          public Cliente ClienteGanadorSorteo(int idSorteoOriginal, int codigoFacturavanta)
          {
              Cliente miClienteGanador = new Cliente();
              try
              {
                  CargaComandoStoreProsedure(sqlClienteGanador);
                  miComando.Parameters.AddWithValue("idSorteo", idSorteoOriginal);
                  miComando.Parameters.AddWithValue("codigoFacturaVenta", codigoFacturavanta);
                  miConexion.MiConexion.Open();

                  NpgsqlDataReader myReader = miComando.ExecuteReader();
                  while(myReader.Read())
                  {
                      miClienteGanador.NitCliente=myReader.GetString(0);
                      miClienteGanador.NombresCliente = myReader.GetString(2);
                      miClienteGanador.TelefonoCliente = myReader.GetString(3);
                      miClienteGanador.CelularCliente = myReader.GetString(4);
                  }
                  miConexion.MiConexion.Close();
                  miComando.Dispose();
                  return miClienteGanador;
              }
              catch(Exception ex)
              {
                  throw new Exception("Error al insertar cliente ganador. \n" + ex.Message);
              }
              finally
              {
                  miConexion.MiConexion.Close();
              }
          }

          /// <summary>
          /// Inserta historial de sorteo.
          /// </summary>
          /// <param name="historialSorteo"></param>
          /// <returns></returns>
          private int InsertarHistorialSosteo(Sorteo historialSorteo)
          {
              var miDaoSorteo = new DaoSorteo();
              var miDaoCategoria = new DaoCategoria();
              var miDaoMarca = new DaoMarca();
              var midaoProducto=new DaoProducto();
              try 
              {
                  CargaComandoStoreProsedure(sqlInsertarHistorialSorteo);
                  miComando.Parameters.AddWithValue("idTipoSorteoHistorial", historialSorteo.IdTipoSorteo);
                  miComando.Parameters.AddWithValue("nombreSorteoHistorial", historialSorteo.NombreSorteo);
                  miComando.Parameters.AddWithValue("fechaInicioSorteoHistorial", historialSorteo.FechaInicioSorteo);
                  miComando.Parameters.AddWithValue("fechaFinSorteoHistorial", historialSorteo.FechaFinalSorteo);
                  miComando.Parameters.AddWithValue("fechaSorteoHistorial", historialSorteo.FechaSorteo);
                  miComando.Parameters.AddWithValue("patrocinadorSorteoHistorial", historialSorteo.PatrocinadoresSorteo);
                  miComando.Parameters.AddWithValue("premioSorteoHistorial", historialSorteo.PremioSorteo);
                  miComando.Parameters.AddWithValue("valorMinimoCompraHistorial", historialSorteo.ValorMinimoCompraSorteo);
                  miComando.Parameters.AddWithValue("estadoSorteoHistorial", historialSorteo.EstadoSorteo);
                  miComando.Parameters.AddWithValue("aplicaventaSorteoHistorial", historialSorteo.AplicaVenta);
                  miComando.Parameters.AddWithValue("tiqueteMultiplesorteoHistorial", historialSorteo.TiqueteMultiple);
                  miComando.Parameters.AddWithValue("valorPremioSorteoHistorial", historialSorteo.ValorPremio);
                  miComando.Parameters.AddWithValue("aplicaHoraSorteoHistorial", historialSorteo.AplicaHora);
                  miComando.Parameters.AddWithValue("horainicioSorteoHistorial", historialSorteo.HoraInicio);
                  miComando.Parameters.AddWithValue("horaFinSorteoHistorial", historialSorteo.HoraFin);
                  miComando.Parameters.AddWithValue("cosceptoSorteoHistorial", historialSorteo.Concepto);
                  miConexion.MiConexion.Open();
                  var idh = (int) miComando.ExecuteScalar();
                  miConexion.MiConexion.Close();
                  miComando.Dispose();

                  if(historialSorteo.IdTipoSorteo==2)
                  {
                      foreach(Marca miMarca in historialSorteo.Marcas)
                      {
                          miDaoMarca.InsertaSorteoMarca(idh, miMarca.IdMarca, true);
                      }                     
                  }
                  else
                  {
                      if (historialSorteo.IdTipoSorteo == 3)
                      {
                          foreach (Categoria miCategoria in historialSorteo.Categorias)
                          {
                              miDaoCategoria.InsertarSorteoCategoria(idh, miCategoria.CodigoCategoria, true);
                          }
                      }
                      else
                      {                          
                              foreach (Producto miProducto in historialSorteo.Producto)
                              {
                                  midaoProducto.InsertarProductoSorteo(idh, miProducto.CodigoInternoProducto, true);
                              }
                                                  
                      }
                  }
                  return idh;
              }
                  
              catch(Exception ex) 
              {
                  throw new Exception("Error al insertar sorteo a historial sorteo. \n" + ex.Message);
              }
              finally 
              {
                  miConexion.MiConexion.Close();
              }
          }

          /// <summary>
          /// Inserta historial sorteo factura
          /// </summary>
          /// <param name="idHistorialSorteo"></param>
          /// <param name="codigoFacturaVenta"></param>
          private void InsertaHistorialSorteoFactura (int idHistorialSorteo, string codigoFacturaVenta)
          {
              try
              {
                  CargaComandoStoreProsedure(sqlInsertarHistorialfacturaSorteo);
                  miComando.Parameters.AddWithValue("idHistorialSorteo", idHistorialSorteo);
                  miComando.Parameters.AddWithValue("codigoFacturaventa", codigoFacturaVenta);
                  miConexion.MiConexion.Open();
                  miComando.ExecuteNonQuery();
                  miConexion.MiConexion.Close();
              }
              catch(Exception ex)
              {
                  throw new Exception("Error al insertar factura al historial. \n" + ex.Message);
              }
              finally
              {
                  miConexion.MiConexion.Close();
              }

          }

          /// <summary>
          /// Elimina la relacionsorteo factura.
          /// </summary>
          /// <param name="idSorteo"></param>
          private void EliminarSorteoFactura(int idSorteo)
          {
              try
              {
                  CargaComandoStoreProsedure(sqlEliminarFacturaSorteo);
                  miComando.Parameters.AddWithValue("idSorteo", idSorteo);
                  miConexion.MiConexion.Open();
                  miComando.ExecuteNonQuery();
                  miConexion.MiConexion.Close();
                  miComando.Dispose();
              }
              catch (Exception ex)
              {
                  throw new Exception("Error al eliminar factura. \n" + ex.Message);
              }
              finally
              {
                  miConexion.MiConexion.Close();
              }
          }

          /// <summary>
          /// Insertar ganador
          /// </summary>
          /// <param name="idSorteo">id sorteo</param>
          /// <param name="codigoFacturaVenta">numero de la factura</param>
          public void IngresarGanador(int idSorteo, string codigoFacturaVenta)
          {
              try
              {
                  var misorteo = CargarSorteo(idSorteo, false);
                  misorteo.EstadoSorteo = false;
                  var id = InsertarHistorialSosteo(misorteo);
                  InsertaHistorialSorteoFactura(id, codigoFacturaVenta);
                  Editasorteo(misorteo);
                  EliminarSorteoFactura(misorteo.IdSorteo);
              }
              catch
              { }

          }

          /// <summary>
          /// Lista clinte ganador en historial sorteo.
          /// </summary>
          /// <param name="idSorteo"></param>
          /// <returns></returns>
          public Cliente HistorialClienteGanador(int idSorteo)
          {
              var micliente = new Cliente();
              try
              {
                  CargaComandoStoreProsedure(sqlHistorialClienteGanador);
                  miComando.Parameters.AddWithValue("idSorteo", idSorteo);
                  miConexion.MiConexion.Open();

                  NpgsqlDataReader myReader = miComando.ExecuteReader();
                  while (myReader.Read())
                  {
                      micliente.NitCliente = myReader.GetString(0);
                      micliente.IdCiudad = myReader.GetInt32(1);
                      micliente.NombresCliente=myReader.GetString(2);
                      micliente.TelefonoCliente = myReader.GetString(4);
                      micliente.CelularCliente=myReader.GetString(3);                     
                     
                  }
                  miConexion.MiConexion.Close();
                  miComando.Dispose();
                  return micliente;
              }
              catch(Exception ex)
              {
                  throw new Exception("Error al listar el cliente ganador. \n"+ex.Message);
              }
              finally
              {
                  miConexion.MiConexion.Close();
              }
          }

          /// <summary>
          /// Carga adapter store prosedure.
          /// </summary>
          /// <param name="cmd"></param>
          public void CargarAdapterStoreProsedure(string cmd)
          {
              miAdapter=new NpgsqlDataAdapter(cmd,this.miConexion.MiConexion);
              miAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
          }

          /// <summary>
          ///  Inicializa una nueva instancia de NpgsqlCommand de tipo Stored Procedure.
          /// </summary>
          /// <param name="cmd"></param>
          public void CargaComandoStoreProsedure(string cmd)
          {
              miComando = new NpgsqlCommand();
              miComando.Connection = miConexion.MiConexion;
              miComando.CommandType = CommandType.StoredProcedure;
              miComando.CommandText = cmd;
          }

          #endregion
    }
}