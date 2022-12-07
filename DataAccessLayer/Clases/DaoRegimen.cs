using System;
using System.Collections;
using System.Data;
using Npgsql;
using DTO.Clases;

namespace DataAccessLayer.Clases
{
    public class DaoRegimen
    {
        #region atributos

        private Conexion miConexion;
        private NpgsqlCommand miComando;
        private ArrayList miArrayList;

        private const string sqlListado = "listado_regimen";

        #endregion

        #region Metodos
        /// <summary>
        /// Devuelve un arrayList con el listado de los regimen
        /// </summary>
        /// <returns></returns>
        public ArrayList ListadoRegimen()
        {
            miArrayList = new ArrayList();
            try
            {
                miConexion = new Conexion();
                miComando = new NpgsqlCommand();
                miComando.Connection = miConexion.MiConexion;
                miComando.CommandType = CommandType.StoredProcedure;
                miComando.CommandText = sqlListado;
                miConexion.MiConexion.Open();
                NpgsqlDataReader miReader = miComando.ExecuteReader();
                while (miReader.Read())
                {
                    Regimen regimen = new Regimen();
                    regimen.IdRegimen = miReader.GetInt32(0);
                    regimen.NombreRegimen = miReader.GetString(1);
                    miArrayList.Add(regimen);
                }
                miConexion.MiConexion.Close();
                miComando.Dispose();
                return miArrayList;
            }
            catch (Exception ex)
            {
                throw new Exception("El listado del Regimen no se pudo cargar. " + ex.Message);
            }
            finally
            {
                miConexion.MiConexion.Close();
            }
        }
        #endregion
    }
}