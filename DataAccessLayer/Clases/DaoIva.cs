using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Npgsql;
using NpgsqlTypes;
using DTO.Clases;
using System.Data;
using System.Collections;

namespace DataAccessLayer.Clases
{
    /// <summary>
    /// Representa una clase de transacciones DB de Iva
    /// </summary>
    public class DaoIva
    {
        /// <summary>
        /// Objeto de conexion a base de datos PostgreSQL
        /// </summary>
        private Conexion conexion;

        /// <summary>
        /// Representa un objeto de sentencias SQL a PostgreSQL
        /// </summary>
        private NpgsqlCommand comando;

        /// <summary>
        /// Objeto que implementa una coleccion
        /// </summary>
        private ArrayList myArrayList;

        /// <summary>
        /// Representa la funcion listado_iva
        /// </summary>
        private string sqlListado = "listado_iva";

        /// <summary>
        /// Representa la funcion eliminar_iva.
        /// </summary>
        private string sqlEliminarIva = "eliminar_iva";

        /// <summary>
        /// Inserta iva.
        /// </summary>
        private string sqlInsertaIva = "insertar_iva";

        /// <summary>
        /// Edita iva
        /// </summary>
        private string sqlEditaIva = "edita_iva";

        /// <summary>
        /// Existe iva
        /// </summary>
        private string sqlExisteIva = "existe_iva";

        /// <summary>
        /// Inicializa una nueva instacia de la clase DaoIva
        /// </summary>
        public DaoIva()
        {
            this.conexion = new Conexion();
        }

        /// <summary>
        /// INgresar iva.
        /// </summary>
        /// <param name="iva">Objeto iva</param>
        public void InsertaIva(Iva iva)
        {
            try
            {
                CargarComandoStoreProsedure(sqlInsertaIva);
                comando.Parameters.AddWithValue("iva", iva.PorcentajeIva);
                comando.Parameters.AddWithValue("Concepto", iva.ConceptoIva);
                conexion.MiConexion.Open();
                comando.ExecuteNonQuery();
                conexion.MiConexion.Close();
                comando.Dispose();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al guardar iva. \n" + ex.Message);
            }
            finally
            {
                conexion.MiConexion.Close();
            }
        }

        /// <summary>
        /// Obtiene el  listado de Iva en una coleccion
        /// </summary>
        /// <returns></returns>
        public ArrayList ListadoIva()
        {
            myArrayList = new ArrayList();

            try
            {
                CargarComandoStoreProsedure(sqlListado);
                conexion.MiConexion.Open();
                NpgsqlDataReader myReader = comando.ExecuteReader();

                while (myReader.Read())
                {
                    Iva iva = new Iva();
                    iva.IdIva = myReader.GetInt32(0);
                    iva.PorcentajeIva = myReader.GetDouble(1);
                    iva.ConceptoIva = myReader.GetDouble(1) + " - " + myReader.GetString(2);
                    myArrayList.Add(iva);
                }

                conexion.MiConexion.Close();
                comando.Dispose();
                return myArrayList;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrio un error al listar los datos de Iva. \n" + ex.Message);
            }
            finally
            {
                conexion.MiConexion.Close();
            }
        }

        public Iva Iva(int id)
        {
            try
            {
                var iva = new Iva();
                CargarComandoStoreProsedure("iva");
                comando.Parameters.AddWithValue("", id);
                conexion.MiConexion.Open();
                NpgsqlDataReader reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    iva.IdIva = reader.GetInt32(0);
                    iva.PorcentajeIva = reader.GetDouble(1);
                    iva.ConceptoIva = reader.GetString(2);
                }
                conexion.MiConexion.Close();
                comando.Dispose();
                return iva;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al consultar el Iva.\n" + ex.Message);
            }
            finally { conexion.MiConexion.Close(); }
        }

        /// <summary>
        /// Eliminar iva
        /// </summary>
        /// <param name="idIva"> id del iva a eliminar</param>
        public void EliminarIva(int idIva)
        {
            try
            {
                CargarComandoStoreProsedure(sqlEliminarIva);
                comando.Parameters.AddWithValue("idiva", idIva);
                conexion.MiConexion.Open();
                comando.ExecuteNonQuery();
                conexion.MiConexion.Close();
                comando.Dispose();
            }
            catch(Exception ex) 
            {
                throw new Exception("Error al eliminar el iva. \n" + ex.Message);
            }
            finally 
            {
                conexion.MiConexion.Close();
            }
        }

        /// <summary>
        /// Edita iva 
        /// </summary>
        /// <param name="iva"> objeto iva</param>
        public void EditaIva(Iva iva)
        {
            try
            {
                CargarComandoStoreProsedure(sqlEditaIva);
                comando.Parameters.AddWithValue("idiva", iva.IdIva);
                comando.Parameters.AddWithValue("iva", iva.PorcentajeIva);
                comando.Parameters.AddWithValue("Concepto", iva.ConceptoIva);
                conexion.MiConexion.Open();
                comando.ExecuteNonQuery();
                conexion.MiConexion.Close();
                comando.Dispose();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al editar iva. \n" + ex.Message);
            }
            finally
            {
                conexion.MiConexion.Close();
            }
        }

        /// <summary>
        /// Consulta si existe IVA
        /// </summary>
        /// <param name="valorIva">Valor a consultar</param>
        /// <returns></returns>
        public bool ExisteIva(double valorIva)
        {
            try
            {
                CargarComandoStoreProsedure(sqlExisteIva);
                comando.Parameters.AddWithValue("valoriva", valorIva);
                conexion.MiConexion.Open();
                var resultado = Convert.ToBoolean(comando.ExecuteScalar());
                conexion.MiConexion.Close();
                comando.Dispose();
                return resultado;
            }
            catch(Exception ex) 
            {
                throw new Exception("Error al aser la consulta. \n" + ex.Message);
            }
        }

        /// <summary>
        /// Inicializa una nueva instncia de NpgsqlCommand de tipo StorePrecedure.
        /// </summary>
        /// <param name="cmd"></param>
        private void CargarComandoStoreProsedure(string cmd)
        {
            comando = new NpgsqlCommand();
            comando.Connection = conexion.MiConexion;
            comando.CommandType = CommandType.StoredProcedure;
            comando.CommandText = cmd;
        }
    }
}