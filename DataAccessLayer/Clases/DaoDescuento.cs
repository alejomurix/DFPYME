using System;
using Npgsql;
using System.Data;
using System.Collections;
using System.Collections.Generic;
using DTO.Clases;

namespace DataAccessLayer.Clases
{
    /// <summary>
    /// Representa una clase de tranzacion de Base de Datos de Descuento.
    /// </summary>
    public class DaoDescuento
    {
        #region Atributos

        /// <summary>
        /// Objeto de conexion a base de datos PostgreSQL.
        /// </summary>
        private Conexion conexion;

        /// <summary>
        /// Representa un objeto de sentencias SQL a PostgreSQL.
        /// </summary>
        private NpgsqlCommand comando;

        /// <summary>
        /// Objeto que implementa una coleccion.
        /// </summary>
        private ArrayList myArrayList;

        /// <summary>
        /// Representa la funcion listado_descuento.
        /// </summary>
        private string listadodescuento = "listado_descuento";

        /// <summary>
        /// Representa la funcion insertar_descuento.
        /// </summary>
        private string insertarDescuento = "insertar_descuento";

        /// <summary>
        /// Representa la funcion listar_producto_descuentos.
        /// </summary>
        private string listado_producto_descuento = "listar_producto_descuentos";

        /// <summary>
        /// Representa la funcion insertar_descuento.
        /// </summary>
        private string sqlInsrtarDescuento = "insertar_descuento";

        /// <summary>
        /// Representa la función edita_descuento.
        /// </summary>
        private string sqlEditaDescuento = "edita_descuento";

        /// <summary>
        /// Representa la funcion eliminar_descuento.
        /// </summary>
        private string sqlEliminarDescuento = "eliminar_descuento";

        /// <summary>
        /// Representa la función existe_descunto.
        /// </summary>
        private string sqlExisteDescuento = "existe_descunto";

        #endregion

        /// <summary>
        /// Inicializa una nueva instancia de la clase DaoDescuento.
        /// </summary>
        public DaoDescuento()
        {
            this.conexion = new Conexion();
        }

        /// <summary>
        /// Insertar descuento. 
        /// </summary>
        /// <param name="descuento"></param>
        public void InsertaDescuento(Descuento descuento)
        {
            try
            {
                CargarComandoStoredProcedure(sqlInsrtarDescuento);
                comando.Parameters.AddWithValue("valordescuento", descuento.ValorDescuento);
                conexion.MiConexion.Open();
                comando.ExecuteNonQuery();
                conexion.MiConexion.Close();
                comando.Dispose();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al ingresar el descuento." + ex.Message);
            }
            finally
            {
                conexion.MiConexion.Close();
            }
        }

        /// <summary>
        /// Obtiene el  listado de los Descuentos.
        /// </summary>
        /// <returns></returns>
        public ArrayList ListadoDescuento()
        {
            myArrayList = new ArrayList();
            try
            {
                CargarComandoStoredProcedure(listadodescuento);
                conexion.MiConexion.Open();
                NpgsqlDataReader myReader = comando.ExecuteReader();
                while (myReader.Read())
                {
                    Descuento desc = new Descuento();
                    desc.IdDescuento = myReader.GetInt32(0);
                    desc.ValorDescuento = myReader.GetDouble(1);
                    myArrayList.Add(desc);
                }
                conexion.MiConexion.Close();
                comando.Dispose();
                return myArrayList;

            }
            catch (Exception ex)
            {
                throw new Exception("Error al listar descuento. " + ex.Message);
            }
            finally
            {
                conexion.MiConexion.Close();
            }
        }

        /// <summary>
        /// Editar descuento.
        /// </summary>
        /// <param name="elDescuento"></param>
        public void EditaDescuento(Descuento elDescuento)
        {
            try
            {
                CargarComandoStoredProcedure(sqlEditaDescuento);
                comando.Parameters.AddWithValue("idDescuento", elDescuento.IdDescuento);
                comando.Parameters.AddWithValue("valordescuento", elDescuento.ValorDescuento);
                conexion.MiConexion.Open();
                comando.ExecuteNonQuery();
                conexion.MiConexion.Close();
                comando.Dispose();
            }
            catch(Exception ex)
            {
                throw new Exception("Error al editar el descuento." + ex.Message);
            }
        }

        /// <summary>
        /// Eliminar descuento.
        /// </summary>
        /// <param name="idDescuento">id descuento a eliminar</param>
        public void EliminaDescuento(int idDescuento)
        {
            try
            {
                CargarComandoStoredProcedure(sqlEliminarDescuento);
                comando.Parameters.AddWithValue("iddescuento", idDescuento);
                conexion.MiConexion.Open();
                comando.ExecuteNonQuery();
                conexion.MiConexion.Close();
                comando.Dispose();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al eliminar descuento." + ex.Message);
            }
            finally
            {
                conexion.MiConexion.Close();
            }
        }

        /// <summary>
        /// Existe descuento
        /// </summary>
        /// <param name="valorDescuento">valor del descuento a consultar</param>
        /// <returns></returns>
        public bool ExisteDescuento(double valorDescuento)
        {
            try
            {
                CargarComandoStoredProcedure(sqlExisteDescuento);
                comando.Parameters.AddWithValue("valordescuento", valorDescuento);
                conexion.MiConexion.Open();
                var resultado = Convert.ToBoolean(comando.ExecuteScalar());
                conexion.MiConexion.Close();
                comando.Dispose();
                return resultado;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al consultar descuento."+ex.Message);
            }
            finally
            {
                conexion.MiConexion.Close();
            }
        }

        /// <summary>
        /// Inserta un registro en la relacion de Descuento y Producto en la base de datos.
        /// </summary>
        /// <param name="midescuento">Descuento a ingresar</param>
        public void InsertarDescuento(Descuento midescuento)
        {
            try
            {
                CargarComandoStoredProcedure(insertarDescuento);
                comando.Parameters.AddWithValue("iddescuento", midescuento.IdDescuento);
                comando.Parameters.AddWithValue("codigointernoproducto", midescuento.CodigoInternoProducto);
                conexion.MiConexion.Open();
                comando.ExecuteNonQuery();
                conexion.MiConexion.Close();
                comando.Dispose();
            }
            catch (Exception ex)
            {
                throw new Exception("error al insertar descuento" + ex.Message);
            }
            finally { conexion.MiConexion.Close(); }
        }

        /// <summary>
        /// Obtinene una lista de Descuentos segun el producto.
        /// </summary>
        /// <param name="codigo">Codigo del producto</param>
        /// <returns></returns>
        public List<Descuento> ListadoDeDescuento(string codigo)
        {
            List<Descuento> myList = new List<Descuento>();
            try
            {
                CargarComandoStoredProcedure(listado_producto_descuento);
                comando.Parameters.AddWithValue("codigo", codigo);
                conexion.MiConexion.Open();
                NpgsqlDataReader myReader = comando.ExecuteReader();
                while (myReader.Read())
                {
                    Descuento desc = new Descuento();
                    desc.IdDescuento = myReader.GetInt32(0);
                    desc.ValorDescuento = myReader.GetDouble(1);
                    myList.Add(desc);
                }
                conexion.MiConexion.Close();
                comando.Dispose();
                return myList;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al listar descuento. " + ex.Message);
            }
            finally
            {
                conexion.MiConexion.Close();
            }
        }

        /// <summary>
        /// Elimina la relacion de Descuentos con algun Producto.
        /// </summary>
        /// <param name="id">Id del Descuento.</param>
        /// <param name="codigo">Codigo del Producto.</param>
        public void EliminarDescuento(int id, string codigo)
        {
            try
            {
                CargarComandoStoredProcedure("eliminar_producto_descuento");
                comando.Parameters.AddWithValue("id", id);
                comando.Parameters.AddWithValue("codigo", codigo);
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

        /// <summary>
        /// Inicializa una nueva instancia de NpgsqlCommand de tipo StoredProcedure.
        /// </summary>
        /// <param name="cmd">Comando a ejecutar</param>
        private void CargarComandoStoredProcedure(string cmd)
        {
            comando = new NpgsqlCommand();
            comando.Connection = conexion.MiConexion;
            comando.CommandType = CommandType.StoredProcedure;
            comando.CommandText = cmd;
        }
    }
}