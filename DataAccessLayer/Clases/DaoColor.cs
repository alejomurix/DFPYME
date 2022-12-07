using System;
using System.Collections.Generic;
using System.Data;
using DTO.Clases;
using Npgsql;

namespace DataAccessLayer.Clases
{
    /// <summary>
    /// Representa una clase para la tranzacion a base de datos de Color
    /// </summary>
    public class DaoColor
    {
        /// <summary>
        /// Objeto de conexion a base de datos postgreSQL. 
        /// </summary>
        private Conexion miConexion;

        /// <summary>
        /// Representa un Comando en SQL para ser ejecutado en PostgreSQL.
        /// </summary>
        private NpgsqlCommand miComando;

        /// <summary>
        /// Objeto adaptador de consultas a base de datos.
        /// </summary>
        private NpgsqlDataAdapter miAdapter;

        /// <summary>
        /// Representa la funcion existe_color.
        /// </summary>
        private const string sqlExiste = "existe_color";

        /// <summary>
        /// Representa la funcion insertar_color.
        /// </summary>
        private const string sqlInsertar = "insertar_color";

        /// <summary>
        /// Representa la funcion listado_color.
        /// </summary>
        private const string sqlListado = "listado_color";

        /// <summary>
        /// Representa la función color_de_producto.
        /// </summary>
        private const string ColorProducto = "color_de_producto";


        /// <summary>
        /// Representa el texto: Ocurrio un error mientras se verificaba el color.
        /// </summary>
        private const string errorExiste = "Ocurrio un error mientras se verificaba el color.  ";

        /// <summary>
        /// Representa el texto: Ocurrio un error al ingresar el color.
        /// </summary>
        private const string errorInsertar = "Ocurrio un error al ingresar el color.  ";

        /// <summary>
        /// Representa el texto: Ocurrion un error al obtene el listado de los colores.
        /// </summary>
        private const string errorListado = "Ocurrion un error al obtene el listado de los colores.  ";

        /// <summary>
        /// Inicializa una nueva instancia de la clase DaoColor.
        /// </summary>
        public DaoColor()
        {
            miConexion = new Conexion();
        }

        /// <summary>
        /// Verifica si un color existe en la base de datos.
        /// </summary>
        /// <param name="color">String del color a verificar.</param>
        /// <returns></returns>
        public bool ExisteColor(string color)
        {
            bool resultado = false;
            try
            {
                CargarComandoStoredProcedure(sqlExiste);
                miComando.Parameters.AddWithValue("stringColor", color);
                miConexion.MiConexion.Open();
                resultado = Convert.ToBoolean(miComando.ExecuteScalar());
                miConexion.MiConexion.Close();
                miComando.Dispose();
                return resultado;
            }
            catch (Exception ex)
            {
                throw new Exception(errorExiste + ex.Message);
            }
            finally
            {
                miConexion.MiConexion.Close();
            }
        }
        
        /// <summary>
        /// Ingresa un registro de ElColor en la base de datos y retorna el Id generado.
        /// </summary>
        /// <param name="color">Color a ingresar.</param>
        /// <returns></returns>
        public int InsertarColor(ElColor color)
        {
            int id = 0;
            try
            {
                CargarComandoStoredProcedure(sqlInsertar);
                miComando.Parameters.AddWithValue("stringColor", color.MapaBits);
                miConexion.MiConexion.Open();
                id = Convert.ToInt32(miComando.ExecuteScalar());
                miConexion.MiConexion.Close();
                miComando.Dispose();
                return id;
            }
            catch (Exception ex)
            {
                throw new Exception(errorInsertar + ex.Message);
            }
            finally { miConexion.MiConexion.Close(); }
        }

        /// <summary>
        /// Obtiene el listado de los colores de la base de datos.
        /// </summary>
        /// <returns></returns>
        public List<ElColor> ListadoDeColores()
        {
            List<ElColor> lista = new List<ElColor>();
            try
            {
                CargarComandoStoredProcedure(sqlListado);
                miConexion.MiConexion.Open();
                NpgsqlDataReader miReader = miComando.ExecuteReader();
                while (miReader.Read())
                {
                    ElColor color = new ElColor();
                    color.IdColor = miReader.GetInt32(0);
                    color.MapaBits = miReader.GetString(1);
                    lista.Add(color);
                }
                miConexion.MiConexion.Close();
                miComando.Dispose();
                return lista;
            }
            catch (Exception ex)
            {
                throw new Exception(errorListado + ex.Message);
            }
            finally { miConexion.MiConexion.Close(); }
        }

        /// <summary>
        /// Obtiene el listado de colores relacionados a un Producto.
        /// </summary>
        /// <param name="codigo">Código del Producto a consultar.</param>
        /// <param name="idMedida">Id de la medida del Producto.</param>
        /// <returns></returns>
        public DataTable ColoresDeProducto(string codigo, int idMedida)
        {
            var tabla = new DataTable();
            try
            {
                CargarAdapterStoredProcedure(ColorProducto);
                miAdapter.SelectCommand.Parameters.AddWithValue("codigo", codigo);
                miAdapter.SelectCommand.Parameters.AddWithValue("medida", idMedida);
                miAdapter.Fill(tabla);
                return tabla;
            }
            catch (Exception ex)
            {
                throw new Exception(errorListado + ex.Message);
            }
        }

        /// <summary>
        /// Inicializa una nueva instancia de comando, tipo Stored Procedure.
        /// </summary>
        /// <param name="cmd">Sentencia a ejecutar.</param>
        private void CargarComandoStoredProcedure(string cmd)
        {
            this.miComando = new NpgsqlCommand();
            this.miComando.Connection = this.miConexion.MiConexion;
            this.miComando.CommandType = System.Data.CommandType.StoredProcedure;
            this.miComando.CommandText = cmd;
        }

        /// <summary>
        /// Inicializa una nueva instancia de NpgsqlDataAdapter de tipo StoredProcedure.
        /// </summary>
        /// <param name="cmd">Sentencia a SQL a ejecutar.</param>
        private void CargarAdapterStoredProcedure(string cmd)
        {
            miAdapter = new NpgsqlDataAdapter(cmd, miConexion.MiConexion);
            miAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
        }
    }
}