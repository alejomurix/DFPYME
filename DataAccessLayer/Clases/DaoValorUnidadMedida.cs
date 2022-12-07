using System;
using System.Collections;
using Npgsql;
using System.Data;
using DTO.Clases;
using System.Collections.Generic;

namespace DataAccessLayer.Clases
{
    /// <summary>
    /// Representa una clase de tranzacion de Base de Datos de Valores de Unidad de Medida.
    /// </summary>
    public class DaoValorUnidadMedida
    {
        /// <summary>
        /// Objeto de conexion a base de datos PostgreSQL
        /// </summary>
        private Conexion miConexion;

        /// <summary>
        /// Representa un objeto de sentencias SQL a PostgreSQL
        /// </summary>
        private NpgsqlCommand miComando;

        /// <summary>
        /// Objeto que representa un adaptador de comandos SQl.
        /// </summary>
        NpgsqlDataAdapter adapter;

        /// <summary>
        /// Objeto que implementa una coleccion
        /// </summary>
        private ArrayList miArrayList;

        /// <summary>
        /// Representa la funcion listado_valor_unidad_medida.
        /// </summary>
        private string sqlListado = "listado_valor_unidad_medida";

        /// <summary>
        /// representa la funcion insertar insertar_valor_unidad_medida.
        /// </summary>
        private string sqlInsetarValorUnidadMedida = "insertar_valor_unidad_medida";

        /// <summary>
        /// Representa la funcion insertar_producto_medida.
        /// </summary>
        private string sqlInsertarMedidaProducto = "insertar_producto_medida";

        /// <summary>
        /// Representa la funcion existe valor unidad de medida
        /// </summary>
        private string sqlExisteValorUnidadMedida = "existe_valor_unidad_medida";

        /// <summary>
        /// Representa la funcion comprobar_producto_medida.
        /// </summary>
        private string sqlComprobarProductoMedida = "comprobar_producto_medida";

        /// <summary>
        /// Representa la funcion consulta_medida_producto.
        /// </summary>
        private string sqlMedidaDeProducto = "consulta_medida_producto";

        /// <summary>
        /// Representa la funcion modifica_valor_unidad_medida;
        /// </summary>
        private string sqlModificarValorMedida = "modifica_valor_unidad_medida";

        /// <summary>
        /// Representa la funcion eliminar_valor_unidad_medida.
        /// </summary>
        private string sqlEliminarValorMedida = "eliminar_valor_unidad_medida";

        /// <summary>
        /// Representa la funcion listado_tallas.
        /// </summary>
        private string sqlListadoTallas = "listado_tallas";

        /// <summary>
        /// Inicializa una nueva instacia de la clase ValorDaoUnidadMedida
        /// </summary>
        public DaoValorUnidadMedida()
        {
            this.miConexion = new Conexion();
        }

        /// <summary>
        /// indica existe valor unidad medida
        /// </summary>
        /// <param name="nombre"></param>
        /// <returns></returns>
        public bool ExisteValorUnidadMedida(string nombre)
        {
            try
            {
                CargarComandoStoredProcedure(sqlExisteValorUnidadMedida);
                miComando.Parameters.AddWithValue("descripcionvalor_unidad_medida", nombre);
                miConexion.MiConexion.Open();
                var resultado = Convert.ToBoolean(miComando.ExecuteScalar());
                miComando.ExecuteNonQuery();
                miConexion.MiConexion.Close();
                miComando.Dispose();
                return resultado;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);

            }
            finally
            {
                miConexion.MiConexion.Close();
            }
        }

        /// <summary>
        /// Comprueba la existencia de una relacion establecida de un Producto y ValorUnidadMedida.
        /// </summary>
        /// <param name="valorMedida">Valor de Unidad de Medida a comprobar.</param>
        /// <returns></returns>
        public bool ComprobarMedidaProducto(ValorUnidadMedida valorMedida)
        {
            try
            {
                CargarComandoStoredProcedure(sqlComprobarProductoMedida);
                miComando.Parameters.AddWithValue("medida", valorMedida.IdValorUnidadMedida);
                miComando.Parameters.AddWithValue("producto", valorMedida.CodigoInternoProducto);
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
        /// Ingresa un registro de Valor de unidad de medida en la base de datos.
        /// </summary>
        /// <param name="miValorMedida">Valor de Unidad de Medida a ingresar.</param>
        public void InsertarValorUnidadMedida(ValorUnidadMedida miValorMedida)
        {
            try
            {
                CargarComandoStoredProcedure(sqlInsetarValorUnidadMedida);
                miComando.Parameters.AddWithValue("id_unidad_medida", miValorMedida.IdUnidadMedida);
                miComando.Parameters.AddWithValue("descripcion", miValorMedida.DescripcionValorUnidadMedida);
                miConexion.MiConexion.Open();
                miComando.ExecuteNonQuery();
                miConexion.MiConexion.Close();
                miComando.Dispose();
            }
            catch (Exception ex)
            {
                throw new Exception("no se pudo guardar el valor unidad medida" + ex.Message);
            }
            finally
            {
                miConexion.MiConexion.Close();
            }
        }

        /// <summary>
        /// Ingresa un registro a la relacion de Producto y ValorUnidadMedida.
        /// </summary>
        /// <param name="medida">Medida a ingresar.</param>
        public void InsertarMedidaProducto(ValorUnidadMedida medida)
        {
            try
            {
                CargarComandoStoredProcedure(sqlInsertarMedidaProducto);
                miComando.Parameters.AddWithValue("producto", medida.CodigoInternoProducto);
                miComando.Parameters.AddWithValue("idMedida", medida.IdValorUnidadMedida);
                miConexion.MiConexion.Open();
                miComando.ExecuteNonQuery();
                miConexion.MiConexion.Close();
                miComando.Dispose();
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrio un error al ingresar la medida del producto. " + ex.Message);
            }
            finally
            {
                miConexion.MiConexion.Close();
            }
        }

        public List<ValorUnidadMedida> UnidadesDeMedida()
        {
            try
            {
                var medidas = new List<ValorUnidadMedida>();
                CargarComandoStoredProcedure("unidades_de_medida");
                miConexion.MiConexion.Open();
                NpgsqlDataReader reader = miComando.ExecuteReader();
                while (reader.Read())
                {
                    var medida = new ValorUnidadMedida();
                    medida.IdUnidadMedida = reader.GetInt32(0);
                    medida.DescripcionUnidadMedida = reader.GetString(2);
                    medidas.Add(medida);
                }
                miConexion.MiConexion.Close();
                miComando.Dispose();
                return medidas;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al consultar las medidas.\n" + ex.Message);
            }
            finally { miConexion.MiConexion.Close(); }
        }

        /// <summary>
        /// Obtiene el  listado de los valores de Unidad de Medida en una coleccion
        /// </summary>
        /// <param name="idunidadmedida">Id de la unidad de medida</param>
        /// <returns></returns>
        public ArrayList ListadoValorUnidadMedida(int idunidadmedida)
        {
            miArrayList = new ArrayList();
            CargarComandoStoredProcedure(sqlListado);
            miComando.Parameters.AddWithValue("idunidadmedida", idunidadmedida);
            miConexion.MiConexion.Open();
            NpgsqlDataReader miReader = miComando.ExecuteReader();
            try
            {
                while (miReader.Read())
                {
                    ValorUnidadMedida unidad = new ValorUnidadMedida();
                    unidad.IdValorUnidadMedida = miReader.GetInt32(0);
                    unidad.DescripcionValorUnidadMedida = miReader.GetString(2);
                    miArrayList.Add(unidad);
                }
                miConexion.MiConexion.Close();
                miComando.Dispose();
                return miArrayList;
            }
            catch (Exception ex)
            {
                throw new Exception("El listado de valores unidad medida no se pudo cargar. " + ex.Message);
            }
            finally
            {
                miConexion.MiConexion.Close();
            }

        }

        /// <summary>
        /// Obtiene el listado de medidas de un producto.
        /// </summary>
        /// <param name="codigo">Codigo del producto a consultar.</param>
        /// <returns></returns>
        public DataTable MedidasDeProducto(string codigo)
        {
            var tabla = new DataTable();
            try
            {
                CargarAdapaterStoredProcedure(sqlMedidaDeProducto);
                adapter.SelectCommand.Parameters.AddWithValue("codigo", codigo);
                adapter.Fill(tabla);
                return tabla;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al cargar las tallas.\n" + ex.Message);
            }
        }

        /// <summary>
        /// Obtiene el listado de todas las tallas.
        /// </summary>
        /// <returns></returns>
        public DataTable ListadoDeTallas()
        {
            DataTable talla = new DataTable();
            CargarAdapaterStoredProcedure(sqlListadoTallas);
            try
            {
                adapter.Fill(talla);
            }
            catch (Exception)
            {
                throw new Exception("Ocurrio un error al cargar las tallas. ");
            }
            return talla;
        }

        /// <summary>
        /// Metodo para modificar valores de unidades de medida.
        /// </summary>
        /// <param name="miValorMedida"></param>
        public void ModificaValorMdida(ValorUnidadMedida miValorMedida)
        {
            try
            {
                CargarComandoStoredProcedure(sqlModificarValorMedida);
                miComando.Parameters.AddWithValue("idValor_Medida", miValorMedida.IdValorUnidadMedida);
                miComando.Parameters.AddWithValue("descripcionvalor_medida", miValorMedida.DescripcionValorUnidadMedida);
                miConexion.MiConexion.Open();
                miComando.ExecuteNonQuery();
                miConexion.MiConexion.Close();
                miComando.Dispose();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al modificar el valor de la unidad de medida" + ex.Message);
            }
            finally
            {
                miConexion.MiConexion.Close();
            }
        }

        public void EditarMedidaProducto(string codigo, int idMedida)
        {
            try
            {
                string sql = "update producto_medida set idvalor_unidad_medida = @idMedida where codigointernoproducto = @codigo;";
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
        /// Metodo eliminar valores de las unidades de medida. 
        /// </summary>
        /// <param name="id"></param>
        public void EliminarValorMedida(int id)
        {
            try
            {
                CargarComandoStoredProcedure(sqlEliminarValorMedida);
                miComando.Parameters.AddWithValue("idvalorUnidad_medida", id);
                miConexion.MiConexion.Open();
                miComando.ExecuteNonQuery();
                miConexion.MiConexion.Close();
                miComando.Dispose();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al eliminar los valores" + ex.Message);
            }
            finally
            {
                miConexion.MiConexion.Close();
            }
        }

        /// <summary>
        /// Elimina el registro de la relacion de Producto y Medida.
        /// </summary>
        /// <param name="codigo">Codigo del Producto.</param>
        /// <param name="id">Id de la Medida.</param>
        public void EliminarProductoMedida(string codigo, int id)
        {
            try
            {
                CargarComandoStoredProcedure("eliminar_producto_medida");
                miComando.Parameters.AddWithValue("codigo", codigo);
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
        /// Inicializa una nueva instancia de NpgsqlCommand de tipo Stored Procedure.
        /// </summary>
        /// <param name="cmd">Comando a ejecutar.</param>
        private void CargarComandoStoredProcedure(string cmd)
        {
            miComando = new NpgsqlCommand();
            miComando.Connection = miConexion.MiConexion;
            miComando.CommandType = CommandType.StoredProcedure;
            miComando.CommandText = cmd;
        }

        private void CargarComandoText(string cmd)
        {
            miComando = new NpgsqlCommand();
            miComando.Connection = miConexion.MiConexion;
            miComando.CommandType = CommandType.Text;
            miComando.CommandText = cmd;
        }

        /// <summary>
        /// Inicializa una nueva instancia de NpgsqlDataAdapter de tipo Stored Procedure.
        /// </summary>
        /// <param name="cmd">Sentencia a ejecutar.</param>
        private void CargarAdapaterStoredProcedure(string cmd)
        {
            adapter = new NpgsqlDataAdapter(cmd, miConexion.MiConexion);
            adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
        }
    }
}