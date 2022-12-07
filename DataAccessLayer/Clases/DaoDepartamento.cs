using System;
using System.Data;
using System.Collections;
using DTO.Clases;
using Npgsql;

namespace DataAccessLayer.Clases
{
    public class DaoDepartamento
    {
        #region Atributos

        //Atributos de clase
        private const string sqlListado = "departamentos_colombia";

        //Atributos de transacion database
        private Conexion miConexion;
        private NpgsqlCommand miComando;
        private Departamento miDepartamento;
        private ArrayList miLista;

        #endregion

        #region Constructores

        public DaoDepartamento()
        {
            //miConexion = new Conexion();
        }

        #endregion

        #region Metodos

        public ArrayList ListadoDepartamentos()
        {
            miLista = new ArrayList();
            try
            {
                miConexion = new Conexion();
                miComando = new NpgsqlCommand();
                miComando.CommandType = CommandType.StoredProcedure;
                miComando.CommandText = sqlListado;
                miComando.Connection = miConexion.MiConexion;
                miConexion.MiConexion.Open();
                NpgsqlDataReader miReader = miComando.ExecuteReader();
                while (miReader.Read())
                {
                    miDepartamento = new Departamento();
                    miDepartamento.IdDepartamento = miReader.GetInt32(0);
                    miDepartamento.NombreDepartamento = miReader.GetString(1);
                    miLista.Add(miDepartamento);
                }
                miConexion.MiConexion.Close();
                miComando.Dispose();
                return miLista;
            }
            catch (Exception ex)
            {
                throw new Exception("No se pudo listar los departamentos. " + ex.Message);
            }
            finally
            {
                miConexion.MiConexion.Close();
            }
        }

        #endregion
    }
}