using System;
using System.Collections.Generic;
using Npgsql;
using System.Collections;
using System.Data;
using DTO.Clases;

namespace DataAccessLayer.Clases
{
    /// <summary>
    /// Representa una clase de tranzacion de Base de Datos de Recargo.
    /// </summary>
    public class DaoRecargo
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
        /// Representa la funcion en PostgreSQL listado_recargo.
        /// </summary>
        private string listadorecargo = "listado_recargo";

        /// <summary>
        /// Representa la funcion en PostgreSQL insertar_recargo.
        /// </summary>
        private string insertarrecargo = "insertar_recargo";

        /// <summary>
        /// Representa la funcion en PostgreSQL listar_producto_recargos.
        /// </summary>
        private string listado_producto_recargo = "listar_producto_recargos";

        /// <summary>
        /// Representa la funcion insertar_recargo.
        /// </summary>
        private string sqlInsertarRecargo = "insertar_recargo";

        /// <summary>
        /// representa la función edita_recargo.
        /// </summary>
        private string sqlEditaRecargo = "edita_recargo";

        /// <summary>
        /// Representa la finción eliminar_recargo.
        /// </summary>
        private string sqlEliminaRecargo = "eliminar_recargo";

        /// <summary>
        /// Representa la funcion existe_recargo.
        /// </summary>
        private string sqlExisteRecargo = "existe_recargo";

        #endregion

        /// <summary>
        /// Inicializa una nueva instancia de la clase DaoRecargo.
        /// </summary>
        public DaoRecargo()
        {
            this.conexion = new Conexion();
        }

        /// <summary>
        /// Insertar recargos.
        /// </summary>
        /// <param name="recargo"></param>
        public void InsertaRecargo(Recargo recargo)
        {
            try
            {
                CargarComandoStoredProcedure(sqlInsertarRecargo);
                comando.Parameters.AddWithValue("valorrecargo", recargo.ValorRecargo);
                conexion.MiConexion.Open();
                comando.ExecuteNonQuery();
                conexion.MiConexion.Close();
                comando.Dispose();
            }
            catch(Exception ex)
            {
                throw new Exception("Error al ingresar el recargo.\n" + ex.Message);
            }
            finally
            {
                conexion.MiConexion.Close();
            }
        }

        /// <summary>
        /// Obtiene el listado de los recargos en una coleccion.
        /// </summary>
        /// <returns></returns>
        public ArrayList ListadoRecargo()
        {
            myArrayList = new ArrayList();
            try
            {
                CargarComandoStoredProcedure(listadorecargo);
                conexion.MiConexion.Open();
                NpgsqlDataReader myReader = comando.ExecuteReader();
                while (myReader.Read())
                {
                    Recargo rec = new Recargo();
                    rec.IdRecargo = myReader.GetInt32(0);
                    rec.ValorRecargo = myReader.GetDouble(1);
                    myArrayList.Add(rec);
                }
                conexion.MiConexion.Close();
                comando.Dispose();
                return myArrayList;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al listar los Recargos. " + ex.Message);
            }
            finally
            {
                conexion.MiConexion.Close();
            }
        }

        /// <summary>
        /// Edita recargo.
        /// </summary>
        /// <param name="recargo"></param>
        public void EditaRecargo(Recargo recargo)
        {
            try
            {
                CargarComandoStoredProcedure(sqlEditaRecargo);
                comando.Parameters.AddWithValue("idrecargo", recargo.IdRecargo);
                comando.Parameters.AddWithValue("valorrecargo", recargo.ValorRecargo);
                conexion.MiConexion.Open();
                comando.ExecuteNonQuery();
                conexion.MiConexion.Close();
                comando.Dispose();
            }
            catch(Exception ex)
            {
                throw new Exception("Error al editar el recargo.\n");
            }
            finally
            {
                conexion.MiConexion.Close();
            }
        }

        /// <summary>
        /// Elimina recargos.
        /// </summary>
        /// <param name="idrecargo">id recargo a eliminar</param>
        public void EliminarRecargo(int idrecargo)
        {
            try
            {
                CargarComandoStoredProcedure(sqlEliminaRecargo);
                comando.Parameters.AddWithValue("idrecargo", idrecargo);
                conexion.MiConexion.Open();
                comando.ExecuteNonQuery();
                conexion.MiConexion.Close();
                comando.Dispose();
            }
            catch(Exception ex)
            {
                throw new Exception("Error al eliminar el recargo.\n" + ex.Message);
            }
        }

        /// <summary>
        /// Existe recargo en la base de datos.
        /// </summary>
        /// <param name="valorRecargo">valor del recargo a consultar</param>
        /// <returns></returns>
        public bool ExisteRecargo(double valorRecargo)
        {
            try
            {
                CargarComandoStoredProcedure(sqlExisteRecargo);
                comando.Parameters.AddWithValue("valorrecargo", valorRecargo);
                conexion.MiConexion.Open();
                var resultado = Convert.ToBoolean(comando.ExecuteScalar());
                conexion.MiConexion.Close();
                comando.Dispose();
                return resultado;
            }
            catch(Exception ex)
            {
                throw new Exception("Error al consultar recargo."+ex.Message);
            }
            finally
            {
                conexion.MiConexion.Close();
            }
        }

        /// <summary>
        /// Agrega un registro de la relacion Recargo y Producto en la base de datos.
        /// </summary>
        /// <param name="miRecargo">Recargo a ingresar.</param>
        public void InsertarRecargo(Recargo miRecargo)
        {
            try
            {
                CargarComandoStoredProcedure(insertarrecargo);
                comando.Parameters.AddWithValue("idrecargo", miRecargo.IdRecargo);
                comando.Parameters.AddWithValue("codigointernoproducto", miRecargo.CodigoInternoProducto);
                conexion.MiConexion.Open();
                comando.ExecuteNonQuery();
                conexion.MiConexion.Close();
                comando.Dispose();
            }
            catch (Exception ex)
            {
                throw new Exception("error al insertar recargo" + ex.Message);
            }
            finally { conexion.MiConexion.Close(); }
        }

        /// <summary>
        /// Obtiene el listado de los recargos segun el producto en una coleccion.
        /// </summary>
        /// <param name="codigo">Codigo del producto</param>
        /// <returns></returns>
        public List<Recargo> ListadoDeRecargo(string codigo)
        {
            List<Recargo> myList = new List<Recargo>();
            try
            {
                CargarComandoStoredProcedure(listado_producto_recargo);
                comando.Parameters.AddWithValue("codigo", codigo);
                conexion.MiConexion.Open();
                NpgsqlDataReader myReader = comando.ExecuteReader();
                while (myReader.Read())
                {
                    Recargo rec = new Recargo();
                    rec.IdRecargo = myReader.GetInt32(0);
                    rec.ValorRecargo = myReader.GetDouble(1);
                    myList.Add(rec);
                }
                conexion.MiConexion.Close();
                comando.Dispose();
                return myList;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al listar los Recargos. " + ex.Message);
            }
            finally
            {
                conexion.MiConexion.Close();
            }
        }

        /// <summary>
        /// Elimina la relacion de Recargos con algun Producto.
        /// </summary>
        /// <param name="id">Id del Recargo.</param>
        /// <param name="codigo">Codigo del Producto.</param>
        public void EliminarRecargo(int id, string codigo)
        {
            try
            {
                CargarComandoStoredProcedure("eliminar_producto_recargo");
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
        /// Inicializa una nueva instancia de NpgsqlCommand de tipo StoredProcedure
        /// </summary>
        /// <param name="cmd"></param>
        private void CargarComandoStoredProcedure(string cmd)
        {
            comando = new NpgsqlCommand();
            comando.Connection = conexion.MiConexion;
            comando.CommandType = CommandType.StoredProcedure;
            comando.CommandText = cmd;
        }
    }
}