using System;
using System.Data;
using DTO.Clases;
using Npgsql;

namespace DataAccessLayer.Clases
{
    public class DaoSistema
    {
        /// <summary>
        /// Representa el objeto de conexión.
        /// </summary>
        private Conexion miConexion;

        /// <summary>
        /// Representa una sentenca en sql.
        /// </summary>
        private NpgsqlCommand miComando;

        public DaoSistema()
        {
            this.miConexion = new Conexion();
        }

        public Sistema Sistema()
        {
            try
            {
                var sistema = new Sistema();
                CargarComando("sistema");
                miConexion.MiConexion.Open();
                NpgsqlDataReader miReader = miComando.ExecuteReader();
                while (miReader.Read())
                {
                    sistema.Id = miReader.GetInt32(0);
                    sistema.Nombre = miReader.GetString(1);
                    sistema.Fabricante = miReader.GetString(2);
                    sistema.Version = miReader.GetString(3);
                    sistema.Fecha = miReader.GetDateTime(4);
                    sistema.Derecho = miReader.GetString(5);
                    sistema.Licencia = miReader.GetString(6);
                }
                miConexion.MiConexion.Close();
                miComando.Dispose();
                return sistema;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al cargar los datos de información del sistema.\n" + ex.Message);
            }
            finally { miConexion.MiConexion.Close(); }
        }

        /// <summary>
        /// Inicializa una nueva instancia de NpgsqlCommand de tipo StoredProcedure.
        /// </summary>
        /// <param name="cmd">Comando a ejecutar.</param>
        private void CargarComando(string cmd)
        {
            miComando = new NpgsqlCommand();
            miComando.Connection = miConexion.MiConexion;
            miComando.CommandType = CommandType.StoredProcedure;
            miComando.CommandText = cmd;
        }
    }
}