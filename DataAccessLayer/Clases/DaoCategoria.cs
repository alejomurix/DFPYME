using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Npgsql;
using NpgsqlTypes;
using DTO.Clases;
using System.Collections;
using Utilities;

namespace DataAccessLayer.Clases
{
    public class DaoCategoria
    {      

        private Conexion conexion;
        private NpgsqlCommand comando;
        private NpgsqlDataAdapter miAdapter;
        private ArrayList myArrayList;

        private string categoria = "Categoria";

        /// <summary>
        /// Representa la funcion insertarcategoria.
        /// </summary>
        private string sqlinsertar = "insertarcategoria";

        /// <summary>
        /// Representa la funcion listar_categoria
        /// </summary>
        private string sqlListado = "listar_categoria";

        /// <summary>
        /// Representa la funcion consultar_categoria_codigo_igual
        /// </summary>
        private string sqlconsultacodigoigual = "consultar_categoria_codigo_igual";

        /// <summary>
        /// Representa la funcion consultar_categoria_nombre_igual.
        /// </summary>
        private string sqlconsultanombreigual = "consultar_categoria_nombre_igual";

        /// <summary>
        /// Representa la funcion filtrar_categoria_codigo_contenga.
        /// </summary>
        private string sqlfiltarcodigocontenga = "filtrar_categoria_codigo_contenga";

        /// <summary>
        /// Representa la funcion filtrar_categoria_nombre_contenga.
        /// </summary>
        private string sqlfiltarnombrecontenga = "filtrar_categoria_nombre_contenga";

        /// <summary>
        /// Representa la función count_filtrar_categoria_nombre_contenga.
        /// </summary>
        private string sqlCountfiltarnombrecontenga = "count_filtrar_categoria_nombre_contenga";

        /// <summary>
        /// Representa la funcion modificar_categoria.
        /// </summary>
        private string sqlmodificar = "modificar_categoria";

        /// <summary>
        /// Representa la funcion eliminar_categoria.
        /// </summary>
        private string sqleliminar = "eliminar_categoria";

        /// <summary>
        /// Representa la funcion existe_categoria.
        /// </summary>
        private string sqlexistecategoria = "existe_categoria";

        /// <summary>
        /// Representa la funcion recuperar_consecutivo.
        /// </summary>
        private string sqlconsecutivo = "recuperar_consecutivo";

        /// <summary>
        /// Representa la funcion actualizar_consecutivo.
        /// </summary>
        private string sqlActualizarConsecutivo = "actualizar_consecutivo";

        private bool TipoAproximacion;

        public DaoCategoria()
        {
            conexion = new Conexion();
            miAdapter = new NpgsqlDataAdapter();
            this.TipoAproximacion = Convert.ToBoolean(AppConfiguracion.ValorSeccion("tipo_aprox_precio"));
        }

        public bool ExisteNombreCategoria(string nombre)
        {
            try
            {
                CargarComandoStoreProsedure("existe_categoria_nombre");
                comando.Parameters.AddWithValue("nombre", nombre);
                conexion.MiConexion.Open();
                var resultado = Convert.ToBoolean(comando.ExecuteScalar());
                conexion.MiConexion.Close();
                comando.Dispose();
                return resultado;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al validar el nombre de la Categoria." + ex.Message);
            }
            finally
            {
                conexion.MiConexion.Close();
            }
        }

        /// <summary>
        /// metodo para insertar categoria
        /// </summary>
        /// <param name="micategoria"></param>
        public void InsertarCategoria(Categoria micategoria)
        {
            try
            {
                CargarComandoStoreProsedure(sqlinsertar);
                comando.Parameters.AddWithValue("codigoCategoria", micategoria.CodigoCategoria);
                comando.Parameters.AddWithValue("nombreCategoria", micategoria.NombreCategoria);
                comando.Parameters.AddWithValue("descripcionCategoria", micategoria.DescripcionCategoria);
                comando.Parameters.AddWithValue("estadoCategoria", micategoria.EstadoCategoria);
                conexion.MiConexion.Open();
                comando.ExecuteNonQuery();
                conexion.MiConexion.Close();
                comando.Dispose();
            }
            catch (Exception ex)
            {
                throw new Exception("error al insertar la categoria" + ex.Message);
            }

            finally { conexion.MiConexion.Close(); }
        }

        /// <summary>
        /// metodo para listar categoria
        /// </summary>
        /// <returns>listado categoria</returns>
        public DataTable ListadoCategoria(int registroBase, int registroMaximo)
        {
            var dataset = new DataSet();          
          
            try
            {
                CargarAdapterStoredProcedure(sqlListado);
                miAdapter.Fill(dataset, registroBase, registroMaximo, "Categoria");
                 return dataset.Tables[0];
             
            }
            catch (Exception ex)
            {
                throw new Exception("error al listar categoria" + ex.Message);
            }
            finally
            {
                conexion.MiConexion.Close();
            }
        }

        public DataTable ListadoCategoria()
        {
            var tabla = new DataTable();
            try
            {
                CargarAdapterStoredProcedure(sqlListado);
                miAdapter.Fill(tabla);
                return tabla;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al consultar las Categorias.\n" + ex.Message);
            }
            finally { conexion.MiConexion.Close(); }
        }

        /// <summary>
        /// Obtiene el total de los registroa de categoria.
        /// </summary>
        /// <returns></returns>
        public long RowListarcategoria()
        {
            try
            {
                CargarComandoStoreProsedure("count_listar_categoria");
                conexion.MiConexion.Open();
                var row = Convert.ToInt64(comando.ExecuteScalar());
                conexion.MiConexion.Close();
                comando.Dispose();
                return row;
            }
            catch(Exception ex)
            {
                throw new Exception("Ocurrio un error al cargar el total de los registros de categoria" + ex.Message);
            }
            finally
            {
                conexion.MiConexion.Close();
            }
        }

        /// <summary>
        /// Obtiene elcodigo interno de categoria
        /// </summary>
        /// <returns></returns>
        public int ObtenerCodigoCategoria()
        {
            bool match = true;
            int codigo = 0;
            try
            {
                while (match)
                {
                    codigo =CapturaCodigoInterno();
                    if (ExisteCategoria(codigo.ToString()))
                    {
                        ActualizaCodigoInterno(codigo);
                        match = true;
                    }
                    else
                        match = false;
                }
                return codigo;
            }
            catch(Exception ex)
            {
                throw new Exception("Error al generar codigo de categoria."+ex.Message);
            }
        }

        /// <summary>
        /// Captura el codigo interno de categoria.
        /// </summary>
        /// <returns></returns>
        private int CapturaCodigoInterno()
        {
            try
            {
                CargarComandoStoreProsedure(sqlconsecutivo);
                comando.Parameters.AddWithValue("Concepto",categoria);
                conexion.MiConexion.Open();
                var codigo = Convert.ToInt32(comando.ExecuteScalar());
                conexion.MiConexion.Close();
                comando.Dispose();
                return codigo;
            }
            catch(Exception ex)
            {
                throw new Exception("Error al recuperar el concecutivo de categoria"+ex.Message);
            }
            finally
            {
                conexion.MiConexion.Close();
            }
        }

        /// <summary>
        /// Actualizo el codigointerno de categoria.
        /// </summary>
        /// <param name="codigoCategoria"></param>
        private void ActualizaCodigoInterno(int codigoCategoria)
        {           
            var numero = codigoCategoria + 1;
            try
            {
                CargarComandoStoreProsedure(sqlActualizarConsecutivo);
                comando.Parameters.AddWithValue("concepto",categoria);
                comando.Parameters.AddWithValue("nombre", numero.ToString());
                conexion.MiConexion.Open();
                comando.ExecuteNonQuery();
                conexion.MiConexion.Close();
                comando.Dispose();
            }
            catch(Exception ex)
            {
                throw new Exception("Error al actualizar codigo de categoria" + ex.Message);
            }
            finally
            {
                conexion.MiConexion.Close();
            }
        }

        /// <summary>
        /// metodo listado categoria por codigo
        /// </summary>
        /// <returns></returns>
        public ArrayList FiltrarCategoriaCodigoContenga(string codigoCategoria)
        {
            myArrayList = new ArrayList();
            try
            {
                CargarComandoStoreProsedure(sqlfiltarcodigocontenga);
                comando.Parameters.AddWithValue("codigo", codigoCategoria);
                conexion.MiConexion.Open();
                NpgsqlDataReader myreader = comando.ExecuteReader();

                while (myreader.Read())
                {
                    Categoria filtrarCategoriaCodigocontenga = new Categoria();

                    filtrarCategoriaCodigocontenga.CodigoCategoria = myreader.GetString(0);
                    filtrarCategoriaCodigocontenga.NombreCategoria = myreader.GetString(1);
                    filtrarCategoriaCodigocontenga.DescripcionCategoria = myreader.GetString(2);
                    filtrarCategoriaCodigocontenga.EstadoCategoria = myreader.GetBoolean(3);
                    myArrayList.Add(filtrarCategoriaCodigocontenga);
                }
                conexion.MiConexion.Close();
                comando.Dispose();
                return myArrayList;
            }
            catch (Exception ex)
            {
                throw new Exception("no existe categoria" + ex.Message);
            }
            finally
            {
                conexion.MiConexion.Close();
            }
        }

        /// <summary>
        /// Obtiene el resultado de la consulta de Categoría por Nombre.
        /// </summary>
        /// <param name="nombreCategoria">Nombre o parte de este de la Categoría.</param>
        /// <param name="registroBase">Registro base para la consulta.</param>
        /// <param name="registroMaximo">Registro máximos recuperados en la consulta.</param>
        /// <returns></returns>
        public DataTable FiltroCategoriaNombreContenga
            (string nombreCategoria, int registroBase, int registroMaximo)
        {
            var dataSet = new DataSet();
            try
            {
                CargarAdapterStoredProcedure(sqlfiltarnombrecontenga);
                miAdapter.SelectCommand.Parameters.AddWithValue("nombre", nombreCategoria);
                miAdapter.Fill(dataSet, registroBase, registroMaximo, "categoria");
                return dataSet.Tables[0];
            }
            catch (Exception ex)
            {
                throw new Exception("categoria no existe" + ex.Message);
            }
        }

        public DataTable ConsultaPorNombre(string nombre)
        {
            try
            {
                var tabla = new DataTable();
                CargarAdapterStoredProcedure(sqlfiltarnombrecontenga);
                miAdapter.SelectCommand.Parameters.AddWithValue("nombre", nombre);
                miAdapter.Fill(tabla);
                return tabla;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al consultar las Categorias.\n" + ex.Message);
            }
        }

        /// <summary>
        /// Obtiene el total de registros de una consulta por Nombre de Categoría.
        /// </summary>
        /// <param name="nombre">Nombre o parte de este de la Categoría.</param>
        /// <returns></returns>
        public long RowFiltroCategoriaNombreContenga(string nombre)
        {
            try
            {
                CargarComandoStoreProsedure(sqlCountfiltarnombrecontenga);
                comando.Parameters.AddWithValue("nombre", nombre);
                conexion.MiConexion.Open();
                var rows = Convert.ToInt64(comando.ExecuteScalar());
                conexion.MiConexion.Close();
                comando.Dispose();
                return rows;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al cargar los registros.\n" + ex.Message);
            }
            finally { conexion.MiConexion.Close(); }
        }

        /// <summary>
        /// consulta categoria si el codigo es igual
        /// </summary>
        /// <param name="codigocategoria"></param>
        /// <returns></returns>
        public ArrayList ConsultaCategoriaCodigoIgual(string codigocategoria)
        {
            myArrayList = new ArrayList();
            {
                try
                {
                    CargarComandoStoreProsedure(sqlconsultacodigoigual);
                    comando.Parameters.AddWithValue("codigo", codigocategoria);
                    conexion.MiConexion.Open();
                    NpgsqlDataReader myreader = comando.ExecuteReader();

                    while (myreader.Read())
                    {
                        Categoria consultacategoriacodigoigual = new Categoria();

                        consultacategoriacodigoigual.CodigoCategoria = myreader.GetString(0);
                        consultacategoriacodigoigual.NombreCategoria = myreader.GetString(1);
                        consultacategoriacodigoigual.DescripcionCategoria = myreader.GetString(2);
                        consultacategoriacodigoigual.EstadoCategoria = myreader.GetBoolean(3);
                        myArrayList.Add(consultacategoriacodigoigual);
                    }
                    conexion.MiConexion.Close();
                    comando.Dispose();
                    return myArrayList;
                }
                catch (Exception ex)
                {
                    throw new Exception("no se encontro la categoria" + ex.Message);
                }
            }
        }

        /// <summary>
        /// consulta categoria si nombre son iguales
        /// </summary>
        /// <param name="nombrecategoria"></param>
        /// <returns></returns>
        public ArrayList ConsultaCategoriaNombreIgual(string nombrecategoria)
        {
            myArrayList = new ArrayList();
            {
                try
                {
                    CargarComandoStoreProsedure(sqlconsultanombreigual);
                    comando.Parameters.AddWithValue("nombre", nombrecategoria);
                    conexion.MiConexion.Open();
                    NpgsqlDataReader myreader = comando.ExecuteReader();

                    while (myreader.Read())
                    {
                        Categoria ConsultaCategoriaNombreIgual = new Categoria();

                        ConsultaCategoriaNombreIgual.CodigoCategoria = myreader.GetString(0);
                        ConsultaCategoriaNombreIgual.NombreCategoria = myreader.GetString(1);
                        ConsultaCategoriaNombreIgual.DescripcionCategoria = myreader.GetString(2);
                        ConsultaCategoriaNombreIgual.EstadoCategoria = myreader.GetBoolean(3);
                        myArrayList.Add(ConsultaCategoriaNombreIgual);
                    }
                    conexion.MiConexion.Close();
                    comando.Dispose();
                    return myArrayList;
                }
                catch (Exception ex)
                {
                    throw new Exception("no se a encontrado la categoria" + ex.Message);
                }
            }
        }

        /// <summary>
        /// metodo modificar categoria
        /// </summary>
        /// <param name="categoria"></param>
        public void ModificarCategoria(Categoria categoria)
        {
            try
            {
                CargarComandoStoreProsedure(sqlmodificar);
                comando.Parameters.AddWithValue("codigocategoria", categoria.CodigoCategoria);
                comando.Parameters.AddWithValue("codigonuevo", categoria.CodigoNuevo);
                comando.Parameters.AddWithValue("nombrecategoria", categoria.NombreCategoria);
                comando.Parameters.AddWithValue("descripcioncategoria", categoria.DescripcionCategoria);
                comando.Parameters.AddWithValue("estado", categoria.EstadoCategoria);
                conexion.MiConexion.Open();
                comando.ExecuteNonQuery();
                conexion.MiConexion.Close();
                comando.Dispose();
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
        ///metodo eliminar categoria
        /// </summary>
        /// <param name="micategoria"></param>
        public void EliminarCategoria(string codigo)
        {
            try
            {
                CargarComandoStoreProsedure(sqleliminar);
                comando.Parameters.AddWithValue("codigocategoria", codigo);
                conexion.MiConexion.Open();
                comando.ExecuteNonQuery();
                conexion.MiConexion.Close();
                comando.Dispose();
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
        /// metodo para comprobar si el codigo si existe
        /// </summary>
        /// <param name="codigo">parametro codigo</param>
        /// <returns>tru o false</returns>
        public bool ExisteCategoria(string codigo)
        {
            try
            {
                CargarComandoStoreProsedure(sqlexistecategoria);
                comando.Connection = conexion.MiConexion;
                comando.Parameters.AddWithValue("codigocategoria", codigo);
                conexion.MiConexion.Open();
                var resultado = Convert.ToBoolean(comando.ExecuteScalar());

                conexion.MiConexion.Close();
                comando.Dispose();
                return resultado;
            }
            catch (Exception ex)
            {
                throw new Exception("la categoria ya existe" + ex.Message);
            }
            finally
            {
                conexion.MiConexion.Close();
            }
        }

        /// <summary>
        ///  Inserto las categoria selecionadas el sorteo.
        /// </summary>
        /// <param name="idsorteo"></param>
        /// <param name="idcategoria"></param>
        public void InsertarSorteoCategoria(int idsorteo, string idcategoria, bool historial)
        {
            try
            {
                if (historial)
                {
                    CargarComandoStoreProsedure("insertar_historial_sorteo_categoria");
                }
                else
                {
                    CargarComandoStoreProsedure("insertar_sorteo_categoria");
                }
                comando.Parameters.AddWithValue("idsorteo", idsorteo);
                comando.Parameters.AddWithValue("idcategoria", idcategoria);
                conexion.MiConexion.Open();
                comando.ExecuteNonQuery();
                conexion.MiConexion.Close();
                comando.Dispose();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al insertar las categorias"+ex.Message);
            }
            finally
            {
                conexion.MiConexion.Close();
            }
        }

        /// <summary>
        /// lista categorias del sorteo.
        /// </summary>
        /// <param name="idsorteo"></param>
        /// <returns></returns>
        public List<Categoria> CargarCategoriaSorteo(int idsorteo, bool historial)
        {
            List<Categoria> listaCategoriaSorteo = new List<Categoria>();

            try
            {
                if (historial)
                {
                    CargarComandoStoreProsedure("historial_sorteo_categoria");
                }
                else
                {
                    CargarComandoStoreProsedure("sorteo_categoria");
                }
                comando.Parameters.AddWithValue("idsorteo",idsorteo);
                conexion.MiConexion.Open();
                NpgsqlDataReader myReader = comando.ExecuteReader();
                while (myReader.Read())
                {
                    Categoria miCategoria = new Categoria();
                    miCategoria.CodigoCategoria = myReader.GetString(0);
                    miCategoria.NombreCategoria = myReader.GetString(1);
                    listaCategoriaSorteo.Add(miCategoria);
                }
                conexion.MiConexion.Close();
                comando.Dispose();
                return listaCategoriaSorteo;
            }
            catch (Exception ex)
            {
                throw new Exception("No se pudo listar las categorias" + ex.Message);
            }
            finally
            {
                conexion.MiConexion.Close();
            }
        }

        /// <summary>
        /// Insertar categoria a promocion.
        /// </summary>
        /// <param name="idPromocion"></param>
        /// <param name="codigoCategoria"></param>
        public void InsertarPromocionCategoria(int idPromocion, string codigoCategoria)
        {
            try
            {
                CargarComandoStoreProsedure("insertar_promocion_categoria");
                comando.Parameters.AddWithValue("idPromocion", idPromocion);
                comando.Parameters.AddWithValue("idcategoria", codigoCategoria);
                conexion.MiConexion.Open();
                comando.ExecuteNonQuery();
                conexion.MiConexion.Close();
                comando.Dispose();
            }
            catch(Exception ex)
            {
                throw new Exception("Error al ingresar categoria a promocion." + ex.Message);
            }
            finally
            {
                conexion.MiConexion.Close();
            }
        }

        /// <summary>
        /// Edita promocion categoria
        /// </summary>
        /// <param name="idPromocion">id promocion</param>
        /// <param name="codigoCategoria">codigo categoria </param>
        public void EditaPromocionCategoria(int idPromocion, string codigoCategoria)
        {
            try
            {
                CargarComandoStoreProsedure("edita_promocion_categoria");
                comando.Parameters.AddWithValue("idpromocion", idPromocion);
                comando.Parameters.AddWithValue("codigocategoria", codigoCategoria);
                conexion.MiConexion.Open();
                comando.ExecuteNonQuery();
                conexion.MiConexion.Close();
                comando.Dispose();
            }
            catch(Exception ex)
            {
                throw new Exception("Error al editar la categoria." + ex.Message);
            }
            finally
            {
                conexion.MiConexion.Close();
            }
        }

        public List<Categoria> ResumenVentasTodasCategorias(List<Categoria> categorias, DateTime fecha, DateTime fecha2, bool fecha_)
        {
            var categorias_ = new List<Categoria>();
            if (fecha_)  // Fecha simple
            {
                foreach (var categoria in categorias)
                {
                    if (categoria.CodigoCategoria != "")
                    {
                        categorias_.AddRange(VentasTodasCategorias(categoria, fecha));
                    }
                }
                categorias_.AddRange(
                    VentasTodasCategoriasDiferentes
                            (((Categoria)categorias[0]).CodigoCategoria, ((Categoria)categorias[1]).CodigoCategoria, fecha));
            }
            else  //  Periodo de fecha
            {
                foreach (var categoria in categorias)
                {
                    if (categoria.CodigoCategoria != "")
                    {
                        categorias_.AddRange(VentasTodasCategorias(categoria, fecha, fecha2));
                    }
                }
                categorias_.AddRange(
                    VentasTodasCategoriasDiferentes
                            (((Categoria)categorias[0]).CodigoCategoria, ((Categoria)categorias[1]).CodigoCategoria, fecha, fecha2));
            }
            var query = from data in categorias_
                        group data by new
                        {
                            Codigo = data.CodigoCategoria,
                            Nombre = data.NombreCategoria
                        }
                            into grupo
                            select new
                            {
                                Codigo = grupo.Key.Codigo,
                                Nombre = grupo.Key.Nombre,
                                Valor = grupo.Sum(s => s.Valor)
                            };
            var listCategorias = new List<Categoria>();
            foreach (var cat in query)
            {
                listCategorias.Add(new Categoria
                {
                    CodigoCategoria = cat.Codigo,
                    NombreCategoria = cat.Nombre,
                    Valor = cat.Valor
                });
            }
            return listCategorias;
        }

        private List<Categoria> VentasTodasCategorias(Categoria categoria, DateTime fecha)
        {
            try
            {
                var categorias = new List<Categoria>();
                CargarComandoStoreProsedure("ventas_categorias");
                this.comando.Parameters.AddWithValue("", categoria.CodigoCategoria);
                this.comando.Parameters.AddWithValue("", fecha);
                this.conexion.MiConexion.Open();
                NpgsqlDataReader reader = this.comando.ExecuteReader();
                while (reader.Read())
                {
                    categorias.Add(new Categoria
                    {
                        CodigoCategoria = reader.GetString(1),
                        NombreCategoria = categoria.NombreCategoria,
                        Valor = UseObject.Aproximar(Convert.ToInt32(reader.GetDecimal(2)), TipoAproximacion)
                    });
                }
                this.conexion.MiConexion.Close();
                this.comando.Dispose();
                return categorias;
            }
            catch (Exception ex)
            {
                throw new Exception
                    ("Ocurrió un error al consultar las ventas de la categoria, COD: " + categoria.CodigoCategoria + ".\n" + ex.Message);
            }
            finally { this.conexion.MiConexion.Close(); }
        }

        private List<Categoria> VentasTodasCategorias(Categoria categoria, DateTime fecha, DateTime fecha2)
        {
            try
            {
                var categorias = new List<Categoria>();
                CargarComandoStoreProsedure("ventas_categorias");
                this.comando.Parameters.AddWithValue("", categoria.CodigoCategoria);
                this.comando.Parameters.AddWithValue("", fecha);
                this.comando.Parameters.AddWithValue("", fecha2);
                this.conexion.MiConexion.Open();
                NpgsqlDataReader reader = this.comando.ExecuteReader();
                while (reader.Read())
                {
                    categorias.Add(new Categoria
                    {
                        CodigoCategoria = reader.GetString(1),
                        NombreCategoria = categoria.NombreCategoria,
                        Valor = UseObject.Aproximar(Convert.ToInt32(reader.GetDecimal(2)), TipoAproximacion)
                    });
                }
                this.conexion.MiConexion.Close();
                this.comando.Dispose();
                return categorias;
            }
            catch (Exception ex)
            {
                throw new Exception
                    ("Ocurrió un error al consultar las ventas de la categoria, COD: " + categoria.CodigoCategoria + ".\n" + ex.Message);
            }
            finally { this.conexion.MiConexion.Close(); }
        }

        private List<Categoria> VentasTodasCategoriasDiferentes(string codCategoria, string codCategoria2, DateTime fecha)
        {
            try
            {
                var categorias = new List<Categoria>();
                CargarComandoStoreProsedure("ventas_categorias_diferentes");
                this.comando.Parameters.AddWithValue("", codCategoria);
                this.comando.Parameters.AddWithValue("", codCategoria2);
                this.comando.Parameters.AddWithValue("", fecha);
                this.conexion.MiConexion.Open();
                NpgsqlDataReader reader = this.comando.ExecuteReader();
                while (reader.Read())
                {
                    categorias.Add(new Categoria
                    {
                        NombreCategoria = "DEMAS",
                        Valor = UseObject.Aproximar(Convert.ToInt32(reader.GetDecimal(2)), TipoAproximacion)
                    });
                }
                this.conexion.MiConexion.Close();
                this.comando.Dispose();
                return categorias;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al consultar las ventas de la categoria, COD: " + codCategoria + ".\n" + ex.Message);
            }
            finally { this.conexion.MiConexion.Close(); }
        }

        private List<Categoria> VentasTodasCategoriasDiferentes(string codCategoria, string codCategoria2, DateTime fecha, DateTime fecha2)
        {
            try
            {
                var categorias = new List<Categoria>();
                CargarComandoStoreProsedure("ventas_categorias_diferentes");
                this.comando.Parameters.AddWithValue("", codCategoria);
                this.comando.Parameters.AddWithValue("", codCategoria2);
                this.comando.Parameters.AddWithValue("", fecha);
                this.comando.Parameters.AddWithValue("", fecha2);
                this.conexion.MiConexion.Open();
                NpgsqlDataReader reader = this.comando.ExecuteReader();
                while (reader.Read())
                {
                    categorias.Add(new Categoria
                    {
                        NombreCategoria = "DEMAS",
                        Valor = UseObject.Aproximar(Convert.ToInt32(reader.GetDecimal(2)), TipoAproximacion)
                    });
                }
                this.conexion.MiConexion.Close();
                this.comando.Dispose();
                return categorias;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al consultar las ventas de la categoria, COD: " + codCategoria + ".\n" + ex.Message);
            }
            finally { this.conexion.MiConexion.Close(); }
        }

        public Categoria CategoriaData(Categoria categoria, DateTime fecha)
        {
            try
            {
                var categorias = new List<Categoria>();
                CargarComandoStoreProsedure("remisiones_categorias");
                this.comando.Parameters.AddWithValue("", categoria.CodigoCategoria);
                this.comando.Parameters.AddWithValue("", fecha);
                this.conexion.MiConexion.Open();
                NpgsqlDataReader reader = this.comando.ExecuteReader();
                while (reader.Read())
                {
                    categorias.Add(new Categoria
                    {
                        Valor = UseObject.Aproximar(Convert.ToInt32(reader.GetDecimal(2)), TipoAproximacion)
                    });
                }
                this.conexion.MiConexion.Close();
                this.comando.Dispose();
                categoria.Valor = categorias.Sum(s => s.Valor);
                return categoria;
            }
            catch (Exception ex)
            {
                throw new Exception
                    ("Ocurrió un error al consultar las ventas de la categoria.\n" + ex.Message);
            }
            finally { this.conexion.MiConexion.Close(); }
        }

        public Categoria CategoriaData(Categoria categoria, DateTime fecha, DateTime fecha2)
        {
            try
            {
                var categorias = new List<Categoria>();
                CargarComandoStoreProsedure("remisiones_categorias");
                this.comando.Parameters.AddWithValue("", categoria.CodigoCategoria);
                this.comando.Parameters.AddWithValue("", fecha);
                this.comando.Parameters.AddWithValue("", fecha2);
                this.conexion.MiConexion.Open();
                NpgsqlDataReader reader = this.comando.ExecuteReader();
                while (reader.Read())
                {
                    categorias.Add(new Categoria
                    {
                        Valor = UseObject.Aproximar(Convert.ToInt32(reader.GetDecimal(2)), TipoAproximacion)
                    });
                }
                this.conexion.MiConexion.Close();
                categoria.Valor = categorias.Sum(s => s.Valor);
                return categoria;
            }
            catch (Exception ex)
            {
                throw new Exception
                    ("Ocurrió un error al consultar las ventas de la categoria.\n" + ex.Message);
            }
            finally { this.conexion.MiConexion.Close(); }
        }

        public void AjustarCodigosCategoria()
        {
            try
            {
                var tCategorias = new DataTable();
                string sql = "SELECT codigocategoria FROM categoria ORDER BY nombrecategoria ASC;";
                miAdapter = new NpgsqlDataAdapter(sql, conexion.MiConexion);
                miAdapter.SelectCommand.CommandType = CommandType.Text;
                miAdapter.Fill(tCategorias);
                var cont = 1;
                comando = new NpgsqlCommand();
                foreach (DataRow cRow in tCategorias.Rows)
                {
                    sql = "UPDATE categoria SET codigocategoria = '" + cont.ToString() + "A' " +
                        "WHERE codigocategoria = '" + cRow["codigocategoria"].ToString() + "'";
                    comando.Connection = conexion.MiConexion;
                    comando.CommandType = CommandType.Text;
                    comando.CommandText = sql;
                    conexion.MiConexion.Open();
                    comando.ExecuteNonQuery();
                    conexion.MiConexion.Close();
                    cont++;
                }
                comando.Dispose();
                AjustarCodigosCategoria2();
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error.\n" + ex.Message);
            }
            finally { conexion.MiConexion.Close(); }
        }

        public void AjustarCodigosCategoria2()
        {
            try
            {
                var tCategorias = new DataTable();
                string sql = "SELECT codigocategoria FROM categoria ORDER BY nombrecategoria ASC;";
                miAdapter = new NpgsqlDataAdapter(sql, conexion.MiConexion);
                miAdapter.SelectCommand.CommandType = CommandType.Text;
                miAdapter.Fill(tCategorias);
                var cont = 1;
                comando = new NpgsqlCommand();
                foreach (DataRow cRow in tCategorias.Rows)
                {
                    sql = "UPDATE categoria SET codigocategoria = '" + cont.ToString() + "' " +
                        "WHERE codigocategoria = '" + cRow["codigocategoria"].ToString() + "'";
                    comando.Connection = conexion.MiConexion;
                    comando.CommandType = CommandType.Text;
                    comando.CommandText = sql;
                    conexion.MiConexion.Open();
                    comando.ExecuteNonQuery();
                    conexion.MiConexion.Close();
                    cont++;
                }
                comando.Dispose();
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error.\n" + ex.Message);
            }
            finally { conexion.MiConexion.Close(); }
        }

        // Ajustes de IVA en Categoria.

        public void CambiarIva(string codCategoria, int idIva)
        {
            try
            {
                CargarComandoStoreProsedure("editra_iva_categoria");
                comando.Parameters.AddWithValue("", codCategoria);
                comando.Parameters.AddWithValue("", idIva);
                conexion.MiConexion.Open();
                comando.ExecuteNonQuery();
                conexion.MiConexion.Close();
                comando.Dispose();
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al cambiar el IVA de la categoría.\n" + ex.Message);
            }
            finally { conexion.MiConexion.Close(); }
        }

        public void RestablecerIva(string codCategoria)
        {
            try
            {
                CargarComandoStoreProsedure("restablecer_iva_categoria");
                comando.Parameters.AddWithValue("", codCategoria);
                conexion.MiConexion.Open();
                comando.ExecuteNonQuery();
                conexion.MiConexion.Close();
                comando.Dispose();
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al restablecer el IVA de la categoría.\n" + ex.Message);
            }
            finally { conexion.MiConexion.Close(); }
        }

        /// <summary>
        /// Inicializa una nueva instancia de NpgsqlCommand de tipo StoredProcedure.
        /// </summary>
        /// <param name="cmd"></param>
        private void CargarComandoStoreProsedure(string cmd)
        {           
            comando = new NpgsqlCommand();
            comando.Connection = conexion.MiConexion;
            comando.CommandType = CommandType.StoredProcedure;
            comando.CommandText = cmd;
            comando.CommandTimeout = 0;
        }

        /// <summary>
        /// Inicializa una nueva instancia de NpgsqlDataAdapter de tipo Stored Procedure.
        /// </summary>
        /// <param name="cmd">Sentencia a ejecutar.</param>
        private void CargarAdapterStoredProcedure(string cmd)
        {
            miAdapter = new NpgsqlDataAdapter(cmd, conexion.MiConexion);
            miAdapter.SelectCommand.CommandType = System.Data.CommandType.StoredProcedure;
            miAdapter.SelectCommand.CommandTimeout = 0;
        }
    }
}