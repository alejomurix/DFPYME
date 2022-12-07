using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Npgsql;
using DTO.Clases;
using System.Collections;
using System.Data;


namespace DataAccessLayer.Clases
{
    public class Dao_Unidad_Medida
    {
        private Conexion miConexion = new Conexion();
        private NpgsqlCommand miComando;
        private ArrayList miArrayList;
        private string sqlListado = "listado_unidad_medida";
        

        public ArrayList ListadoUnidadMedida()
        {
            miArrayList = new ArrayList();
            try
            {
                miComando = new NpgsqlCommand();
                miComando.Connection = miConexion.MiConexion;
                miComando.CommandType = CommandType.StoredProcedure;
                miComando.CommandText = sqlListado;
                miConexion.MiConexion.Open();
                NpgsqlDataReader miReader = miComando.ExecuteReader();
                while (miReader.Read())
                {
                    Unidad_Medida unidad = new Unidad_Medida();
                    unidad.Id_Unidad_Medida = miReader.GetInt32(0);
                    unidad.Descripcion_Unidad_Medida = miReader.GetString(1);
                    miArrayList.Add(unidad);
                }
                miConexion.MiConexion.Close();
                miComando.Dispose();
                return miArrayList;
            }
            catch (Exception ex)
            {
                throw new Exception("El listado de unidades no se pudo cargar. " + ex.Message);
            }
            finally
            {
                miConexion.MiConexion.Close();
            }
        }
        


    }
}
