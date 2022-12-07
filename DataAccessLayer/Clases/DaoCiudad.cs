using System;
using System.Data;
using System.Collections;
using DTO.Clases;
using Npgsql;

namespace DataAccessLayer.Clases
{
    public class DaoCiudad
    {
        #region Atributos

        //Func en PostgreSQL que devuelve un listado de las ciudades segun el departamento
        private const string sqlListadoCiudadPorDepartamento = "fun_ciudad_por_departamento";

        //Parametro que recibe la funcion "fun_ciudad_por_departamento"
        private const string parametroIdDepartemento = "idDepartemento";

        private Conexion miConexion;
        private NpgsqlCommand miComando;
        private Ciudad miCiudad;
        private ArrayList MiLista;

        #endregion

        #region Metodos

        public ArrayList ListaCiudadPorDepartamento(int idDepartamento)
        {
            MiLista = new ArrayList();
            try
            {
                miConexion = new Conexion();
                miComando = new NpgsqlCommand();
                miComando.CommandType = CommandType.StoredProcedure;
                miComando.CommandText = sqlListadoCiudadPorDepartamento;
                miComando.Parameters.AddWithValue(parametroIdDepartemento, idDepartamento);
                miComando.Connection = miConexion.MiConexion;
                miConexion.MiConexion.Open();
                NpgsqlDataReader miReader = miComando.ExecuteReader();
                while (miReader.Read())
                {
                    miCiudad = new Ciudad();
                    miCiudad.IdCiudad = miReader.GetInt32(0);
                    miCiudad.NombreCiudad = miReader.GetString(1);
                    MiLista.Add(miCiudad);
                }
                miConexion.MiConexion.Close();
                miComando.Dispose();
                return MiLista;
            }
            catch (Exception ex)
            {
                throw new Exception("No se pudo listar las ciudades. " + ex.Message);
            }
            finally
            {
                miConexion.MiConexion.Close();
            }
        }

        #endregion
    }
}
