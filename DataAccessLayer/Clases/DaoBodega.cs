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
    public class DaoBodega
    {
        /// <summary>
        /// Representa un adaptador de sentencia sql.
        /// </summary>
        private NpgsqlDataAdapter miAdapter;

        /// <summary>
        /// representa on objeto de sentencia sql a postgers
        /// </summary>
        private NpgsqlCommand miComando;

        /// <summary>
        /// Objeto de conexion a la base de datos PostgresSQL.
        /// </summary>
        private Conexion miConexion;

        /// <summary>
        /// Representa la función insertar abodega.
        /// </summary>
        private string SqlInseterBodega = "insertar_bodega";
        /// <summary>
        /// Representya la función Listar Bodega.
        /// </summary>
        private string SqlListarBodega = "listar_bodegas";

        /// <summary>
        /// representa la función Listar Bodega por nombre.
        /// </summary>
        private string SqlListarBodegaNombre = "filtro_bodega_nombre";

        /// <summary>
        /// Representa la función Modifica Bodega.
        /// </summary>
        private string SqlModificarBodega = "editar_bodega";

        /// <summary>
        /// Representa la función Eliminar Bodega.
        /// </summary>
        private string SqlEliminarBodega = "eliminar_bodega";
        /// <summary>
        /// representa la funcion Existe bodega.
        /// </summary>
        private string SqlExisteBodega = "existe_bodega";

        /// <summary>
        /// Representa la funcion existe_ubicacion_bodega
        /// </summary>
        private string SqlExisteUbicacionBodega = "existe_ubicacion_bodega";
             
        /// <summary>
        /// 
        /// </summary>
        public DaoBodega()
        {
            this.miConexion = new Conexion();
        }
        
         /// <summary>
        /// Representa el metodo insertarbodega el cual inserta una bodega en la base de datos 
        /// </summary>
        /// <param name="bodega">mibodega</param>
        public void InsertarBodega(Bodega bodega)
        {
            try
            {

                CardaComandoStoreProsedure(SqlInseterBodega);
                miComando.Parameters.AddWithValue("nombrebodega", bodega.NombreBodega);
                miComando.Parameters.AddWithValue("lugarbodega",bodega.LugarBodega);
                miConexion.MiConexion.Open();
                miComando.ExecuteNonQuery();
                miConexion.MiConexion.Close();
                miComando.Dispose();

            }
            catch (Exception ex)
            {
                throw new Exception("Error al insertar bodega" + ex.Message);
            }

            finally 
            {
                miConexion.MiConexion.Close();
            }
        }
     

        /// <summary>
        /// Lista bodega de la base de datos
        /// </summary>
        /// <returns></returns>
        public ArrayList ListarBodegas()
        {
            ArrayList listabodegas = new ArrayList();

            try
            {

                CardaComandoStoreProsedure(SqlListarBodega);
                miConexion.MiConexion.Open();
                NpgsqlDataReader myReader = miComando.ExecuteReader();

                while (myReader.Read())
                {
                    Bodega mibodega = new Bodega();

                    mibodega.IdBodega = myReader.GetInt32(0);
                    mibodega.NombreBodega = myReader.GetString(1);
                    mibodega.LugarBodega = myReader.GetString(2);


                    listabodegas.Add(mibodega);
                }
                miConexion.MiConexion.Close();
                miComando.Dispose();

                return listabodegas;

            }
            catch (Exception ex)
            {

                throw new Exception("No se puede consultar Bodega. " + ex.Message);
            }
        }

        /// <summary>
        /// Lista Bodega por nombre
        /// </summary>
        /// <param name="nombrebodega">parametro enviado</param>
        /// <returns></returns>
        public ArrayList ListarBodegasNombre(string nombrebodega)
        {
            ArrayList listabodegasnombre = new ArrayList();

            try
            {

                CardaComandoStoreProsedure(SqlListarBodegaNombre);
                miComando.Parameters.AddWithValue("nombrebodega", nombrebodega);
                miConexion.MiConexion.Open();
                NpgsqlDataReader myReader = miComando.ExecuteReader();

                while (myReader.Read())
                {
                    Bodega mibodega = new Bodega();

                    mibodega.IdBodega = myReader.GetInt32(0);
                    mibodega.NombreBodega = myReader.GetString(1);
                    mibodega.LugarBodega = myReader.GetString(2);
                    listabodegasnombre.Add(mibodega);
                }
                miConexion.MiConexion.Close();
                miComando.Dispose();
                return listabodegasnombre;

            }
            catch (Exception ex)
            {

                throw new Exception("No se puede consultar bodega" + ex.Message);
            }
        }

       /// <summary>
       /// Edita Bodega 
       /// </summary>
       /// <param name="mibodega"></param>
        public void EditarBodega(Bodega mibodega)
        {
            try
            {

                CardaComandoStoreProsedure(SqlModificarBodega);
                miComando.Parameters.AddWithValue("idbodega", mibodega.IdBodega);
                miComando.Parameters.AddWithValue("nombrebodega", mibodega.NombreBodega);
                miComando.Parameters.AddWithValue("lugarbodega", mibodega.LugarBodega);


                miConexion.MiConexion.Open();
                miComando.ExecuteNonQuery();
                miConexion.MiConexion.Close();
                miComando.Dispose();

            }
            catch (Exception ex)
            {

                throw new Exception("error al editar bodega" + ex.Message);

            }

            finally { miConexion.MiConexion.Close(); }
        }

        /// <summary>
        /// Representa el metodo eliminar_bodega en la base de datos 
        /// </summary>
        /// <param name="idbodega">idbodega</param>
        public void EliminarBodega(int idbodega)
        {
            try
            {

                CardaComandoStoreProsedure(SqlEliminarBodega);
                miComando.Parameters.AddWithValue("idbodega", idbodega);
                miConexion.MiConexion.Open();
                miComando.ExecuteNonQuery();
                miConexion.MiConexion.Close();
                miComando.Dispose();
            }
            catch (Exception ex)
            {

                throw new Exception("No se puede eliminar bodega porque tiene registros asociados a ella"+ex.Message );
            }

        }

        /// <summary>
        /// Indica si la bodega ya existe
        /// </summary>
        /// <param name="nombre">parametro enviado</param>
        /// <returns>true false</returns>
        public bool ExisteBodega(string nombre)
        {
            try
            {
                CardaComandoStoreProsedure(SqlExisteBodega);
                miComando.Parameters.AddWithValue("nombre", nombre);
                miConexion.MiConexion.Open();
                var resultado = Convert.ToBoolean(miComando.ExecuteScalar());
                miConexion.MiConexion.Close();
                miComando.Dispose();
                return resultado;
            }
            catch(Exception ex)
            {
                throw new Exception("La bodega ya existe" + ex.Message);
            }
            finally
            {
                miConexion.MiConexion.Close();
            }
        }

        /// <summary>
        /// Indica si la ubicacion de la bodega ya existe
        /// </summary>
        /// <param name="ubicacion">parametro a buscar</param>
        /// <returns>true false</returns>
        public bool ExisteUbicacion(string ubicacion)
        {
            try 
            {
                CardaComandoStoreProsedure(SqlExisteUbicacionBodega);
                miComando.Parameters.AddWithValue("ubicacion", ubicacion);
                miConexion.MiConexion.Open();
                var resultado = Convert.ToBoolean(miComando.ExecuteScalar());
                miConexion.MiConexion.Close();              
                miComando.Dispose();
                return resultado;
            }
            catch(Exception ex) 
            {
                throw new Exception("La ubicacion de la bodega ya existe" + ex.Message);
            }
            finally 
            {
                miConexion.MiConexion.Close();
            }
        }

        /// <summary>
        /// Inicializa una nueva instancia de NpgsqlCommand de tipo Stored Procedure.
        /// </summary>
        /// <param name="cmd">Comando a ejecutar</param>
        public void CardaComandoStoreProsedure(string cmd)
        {
            miComando = new NpgsqlCommand();
            miComando.Connection = miConexion.MiConexion;
            miComando.CommandType = CommandType.StoredProcedure;
            miComando.CommandText = cmd;

        }

        /// <summary>
        /// Carga adapter store prosedure.
        /// </summary>
        /// <param name="cmd"></param>
        public void CargarAdapterStoteProsedure(string cmd)
        {
            miAdapter=new NpgsqlDataAdapter(cmd,this.miConexion.MiConexion);
            miAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
        }

    }
}
