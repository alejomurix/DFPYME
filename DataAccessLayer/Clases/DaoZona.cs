using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Npgsql;
using DTO.Clases;
using System.Data;
using System.Collections;

namespace DataAccessLayer.Clases
{
    public class DaoZona
    {
        /// <summary>
        /// Representa un adaptador de sentencia sql.
        /// </summary>
        private NpgsqlDataAdapter miAdapter;

        /// <summary>
        /// Objeto de conexion a la base de datos postgresSQL
        /// </summary>
        private Conexion miConexion;

        /// <summary>
        /// Representa un objeto de sentencia sql postgres.
        /// </summary>
        private NpgsqlCommand miComando;

        /// <summary>
        /// carga los valores de capacidad de la zona.
        /// </summary>
        private DataTable midatatable;

        /// <summary>
        /// Reprenta la funcion insertar zona.
        /// </summary>
        private string sqlInsertarZona = "insertar_zona";

        /// <summary>
        /// Representa la funcion listar_zonas.
        /// </summary>
        private string sqlListarZona = "listar_zonas";

        /// <summary>
        /// Representa la funcion filtro_zona_nombre.
        /// </summary>
        private string sqlListarZonaNombre = "filtro_zona_nombre";

        /// <summary>
        /// Representa la funcion filtro_zona_capacidad.
        /// </summary>
        private string sqlListarCapacidadZona = "filtro_zona_capacidad";

        /// <summary>
        /// Representa la funcion cargar listar_zona_idzona_completa.
        /// </summary>
        private string sqlCargarzona = "listar_zona_idzona_completa";

        /// <summary>
        /// Representa la funcion
        /// </summary>
        private string sqlEditaZona = "editar_zona";

        /// <summary>
        /// Representa la funcion eliminar zona.
        /// </summary>
        private string sqlEliminarZoan = "eliminar_zona";


        /// <summary>
        /// 
        /// </summary>
        public DaoZona()
        {
            this.miConexion = new Conexion();
        }

      

        /// <summary>
        /// Metodo insertar zona
        /// </summary>
        /// <param name="mizona"></param>
        public void InsertarZona(Zona mizona)
        {
            try
            {
                CargaComandoStoreProsedure(sqlInsertarZona);        
                miComando.Parameters.AddWithValue("idbodega", mizona.IdBodega);
                miComando.Parameters.AddWithValue("capacidad", mizona.Capacidad);             
                miComando.Parameters.AddWithValue("numerozona", mizona.NumeroZona);
                miComando.Parameters.AddWithValue("nombrezona", mizona.NombreZona);
                miComando.Parameters.AddWithValue("disponiblezona", mizona.DisponibleZona);
                miConexion.MiConexion.Open();
                miComando.ExecuteNonQuery();
                miConexion.MiConexion.Close();
                miComando.Dispose();

            }
            catch (Exception ex)
            {

                throw new Exception("Error al insertar zona" + ex.Message);

            }

            finally 
            { 
                miConexion.MiConexion.Close(); 
            }
        }


        /// <summary>
        /// Representa el metodo listar_zonas en la base de datos  
        /// </summary>
        /// <returns>listazonas</returns>

        public ArrayList ListarZonas()
        {

            ArrayList listazonas = new ArrayList();

            try
            {

                CargaComandoStoreProsedure(sqlListarZona);
                miConexion.MiConexion.Open();
                NpgsqlDataReader myReader = miComando.ExecuteReader();

                while (myReader.Read())
                {
                    Zona mizona = new Zona();

                    mizona.IdZona = myReader.GetInt32(0);
                    mizona.NombreZona = myReader.GetString(1);
                    mizona.NumeroZona = myReader.GetInt32(2);
                    mizona.Capacidad = myReader.GetString(3);
                    mizona.DisponibleZona = myReader.GetBoolean(4);
                    mizona.NombreBodega = myReader.GetString(5);
                    mizona.LugarBodega = myReader.GetString(6);

                    listazonas.Add(mizona);
                }
                miConexion.MiConexion.Close();
                miComando.Dispose();
                return listazonas;

            }
            catch (Exception ex)
            {

                throw new Exception("No se puede listar Zona. " + ex.Message);
            }
            finally
            {
                miConexion.MiConexion.Close();
            }
        }


        /// <summary>
        /// Representa el procedimiento filtro_zona_nombre en la base de datos  
        /// </summary>
        /// <param name="nombre">parametro Enviado</param>
        /// <returns></returns>
        public ArrayList ListarZonasNombre(string nombre)
        {
            ArrayList listazonasnombre = new ArrayList();

            try
            {

                CargaComandoStoreProsedure(sqlListarZonaNombre);
                miComando.Parameters.AddWithValue("nombre", nombre);
                miConexion.MiConexion.Open();
                NpgsqlDataReader myReader = miComando.ExecuteReader();

                while (myReader.Read())
                {
                    Zona mizona = new Zona();

                    mizona.IdZona = myReader.GetInt32(0);
                    mizona.NombreZona = myReader.GetString(1);
                    mizona.NumeroZona = myReader.GetInt32(2);
                    mizona.Capacidad = myReader.GetString(3);
                    mizona.DisponibleZona = myReader.GetBoolean(4);
                    mizona.NombreBodega = myReader.GetString(5);
                    mizona.LugarBodega = myReader.GetString(6);

                    listazonasnombre.Add(mizona);
                }
                miConexion.MiConexion.Close();
                miComando.Dispose();
                return listazonasnombre;

            }
            catch (Exception ex)
            {

                throw new Exception("No se puede consultar zona" + ex.Message);
            }
            finally
            {
                miConexion.MiConexion.Close();
            }
        }

        /// <summary>
        /// Metodo listar zona categoria.
        /// </summary>
        /// <param name="capacidad"></param>
        /// <returns></returns>
        public DataTable ListaCapacidad(string capacidad)
        {
            try
            {
                midatatable = new DataTable();
                CargarAdapterStoreProsedure(sqlListarCapacidadZona);
                miAdapter.SelectCommand.Parameters.AddWithValue("capacidad", capacidad);
                this.miAdapter.Fill(midatatable);
                return midatatable;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        /// <summary>
        /// Representa el procedimiento editarzona en la base de datos  
        /// </summary>
        /// <param name="mizona">mizona</param>
        public void EditarZona(Zona mizona)
        {
            try
            {

                CargaComandoStoreProsedure(sqlEditaZona);
                miComando.Parameters.AddWithValue("idzona", mizona.IdZona);
                miComando.Parameters.AddWithValue("idbodega", mizona.IdBodega);
                miComando.Parameters.AddWithValue("capacidad", mizona.Capacidad);
                miComando.Parameters.AddWithValue("numerozona",mizona.NumeroZona);
                miComando.Parameters.AddWithValue("nombrezona",mizona.NombreZona);
                miComando.Parameters.AddWithValue("disponiblezona",mizona.DisponibleZona);
                miConexion.MiConexion.Open();
                miComando.ExecuteNonQuery();
                miConexion.MiConexion.Close();
                miComando.Dispose();

            }
            catch (Exception ex)
            {

                throw new Exception("Error al editar zona" + ex.Message);

            }

            finally { miConexion.MiConexion.Close(); }
        }

        /// <summary>
        /// Representa el metodo listar_zona_idzona_completa en la base de datos, el cual muestra toda
        /// la informacion de una zona ingresando su id
        /// </summary>
        /// <param name="IdZona">IdZona</param>
        /// <returns>mizona</returns>
        public Zona ListarZonaCompletoIdZona(int IdZona)
        {
            Zona mizona = new Zona();
            try
            {
                CargaComandoStoreProsedure(sqlCargarzona);
                miComando.Parameters.AddWithValue("idzona", IdZona);
                miConexion.MiConexion.Open();
                NpgsqlDataReader myReader = miComando.ExecuteReader();

                while (myReader.Read())
                {

                    mizona.IdZona = myReader.GetInt32(0);
                    mizona.NumeroZona = myReader.GetInt32(1);
                    mizona.NombreZona = myReader.GetString(2);                   
                    mizona.Capacidad = myReader.GetString(3);
                    mizona.DisponibleZona = myReader.GetBoolean(4);
                    mizona.IdBodega = myReader.GetInt32(5);
                    mizona.NombreBodega = myReader.GetString(6);
                    mizona.LugarBodega = myReader.GetString(7);
                    
                   
                   
            }
                miConexion.MiConexion.Close();
                miComando.Dispose();
                return mizona;

            }
            catch (Exception ex)
            {

                throw new Exception("No se puede consultar zona" + ex.Message);
            }
            finally
            {
                miConexion.MiConexion.Close();
            }
        }
                
        /// <summary>
        /// Representa el procedimiento eliminar_zona en la base de datos 
/// </summary>
        /// <param name="idzona">idzona</param>
        public void EliminarZona(int idzona)
        {
            try
            {
                CargaComandoStoreProsedure(sqlEliminarZoan);
                miComando.Parameters.AddWithValue("idzona", idzona);
                miConexion.MiConexion.Open();
                miComando.ExecuteNonQuery();
                miConexion.MiConexion.Close();
                miComando.Dispose();
            }
            catch (Exception ex)
            {
                throw new Exception("No se puede eliminar zona porque existen registros asociados a ella" + ex.Message);
            }
            finally
            {
                miConexion.MiConexion.Close();
            }
        }

        /// <summary>
        /// Refresca grid 
        /// </summary>
        /// <param name="id">parametro enviado</param>
        /// <returns></returns>
        public ArrayList ListarZonas(int id)
        {
            ArrayList listazonas = new ArrayList();

            try
            {

                CargaComandoStoreProsedure(sqlListarZona);
                miComando.Parameters.AddWithValue("id", id);
                miConexion.MiConexion.Open();
                NpgsqlDataReader myReader = miComando.ExecuteReader();

                while (myReader.Read())
                {
                    Zona mizona = new Zona();

                    mizona.IdZona = myReader.GetInt32(0);
                    mizona.NombreZona = myReader.GetString(1);
                    mizona.NumeroZona = myReader.GetInt32(2);
                    mizona.Capacidad = myReader.GetString(3);
                    mizona.DisponibleZona = myReader.GetBoolean(4);
                    mizona.NombreBodega = myReader.GetString(5);
                    mizona.LugarBodega = myReader.GetString(6);

                    listazonas.Add(mizona);
                }
                miConexion.MiConexion.Close();
                miComando.Dispose();
                return listazonas;

            }
            catch (Exception ex)
            {

                throw new Exception("No se puede listar Zona. " + ex.Message);
            }
            finally
            {
                miConexion.MiConexion.Close();
            }
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

        /// <summary>
        /// Carga adapter store prosedure.
        /// </summary>
        /// <param name="cmd"></param>
        public void CargarAdapterStoreProsedure(string cmd)
        {
            miAdapter = new NpgsqlDataAdapter(cmd, this.miConexion.MiConexion);
            miAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
        }

    }
}
