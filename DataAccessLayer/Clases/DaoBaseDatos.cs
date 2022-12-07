using System;
using Npgsql;

namespace DataAccessLayer.Clases
{
    /// <summary>
    /// Representa una clase para el tratamiento oportuno en Base de Datos.
    /// </summary>
    public class DaoBaseDatos
    {
        /// <summary>
        /// Objeto que establece la conexión a base de datos PostgreSQL.
        /// </summary>
        private Conexion miConexion;

        /// <summary>
        /// Representa un comando de ejecución de sentencias SQL a base de datos PostgreSQL.
        /// </summary>
        private NpgsqlCommand miComando;

        /// <summary>
        /// Representa el texto CREATE DATABASE .
        /// </summary>
        private const string sqlCrearDatabase = "CREATE DATABASE ";

        /// <summary>
        /// Representa el texto: Falló la autenticación al servidor de Base de datos.
        /// </summary>
        private const string FalloConection = "Falló la autenticación al servidor de Base de datos.";

        /// <summary>
        ///Representa el texto: Ocurrió un error al crear la base de datos.
        /// </summary>
        private const string ErrorCreateDB = "Ocurrió un error al crear la base de datos.\n";

        /// <summary>
        /// Representa el texto: Ocurrió un error al cargar el Script en Base de datos.
        /// </summary>
        private const string ErrorScript = "Ocurrió un error al cargar el Script en Base de datos.\n";

        /// <summary>
        /// Inicializa una nueva instancia de DaoBaseDatos.
        /// </summary>
        public DaoBaseDatos()
        {
        }

        /// <summary>
        /// Realiza un test a la conexión establecida verificando su configuración.
        /// </summary>
        /// <returns></returns>
        public bool TestSaveConexion()
        {
            try
            {
                miConexion = new Conexion();
                miConexion.MiConexion.ConnectionString = miConexion.GetPartialStringConnection();
                miConexion.MiConexion.Open();
                miConexion.MiConexion.Close();
                return true;
            }
            catch
            {
                throw new Exception(FalloConection);
            }
            finally { miConexion.MiConexion.Close(); }
        }

        /// <summary>
        /// Valida si la base de datos configurada existe en el servidor.
        /// </summary>
        /// <returns></returns>
        private bool ExisteDataBase()
        {
            if (TestSaveConexion())
            {
                try
                {
                    miConexion = new Conexion();
                    miConexion.MiConexion.Open();
                    miConexion.MiConexion.Close();
                    return true;
                }
                catch
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Crea la Base de datos a partir de la configuración almacenada.
        /// </summary>
        /// <param name="nombre">Nombre al cual se le adjudica la base de datos.</param>
        /// <param name="script">Script que genera los objetos en la base de datos.</param>
        public void CrearDataBase(string nombre, string script)
        {
            if (!ExisteDataBase())
            {
                try
                {
                    string query = sqlCrearDatabase + nombre;
                    CargarComando(query);
                    miConexion.MiConexion.ConnectionString = miConexion.GetPartialStringConnection();
                    miConexion.MiConexion.Open();
                    miComando.ExecuteNonQuery();
                    miConexion.MiConexion.Close();
                    miComando.Dispose();
                    CargarScriptDataBase(script);
                }
                catch (Exception ex)
                {
                    throw new Exception(ErrorCreateDB + ex.Message);
                }
                finally { miConexion.MiConexion.Close(); }
            }
        }

        /// <summary>
        /// Cargar los datos del Script en la base de datos configurada.
        /// </summary>
        /// <param name="script">Script a ejecutar en la Base de datos.</param>
        private void CargarScriptDataBase(string script)
        {
            try
            {
                miConexion = new Conexion();
                CargarComando(script);
                miConexion.MiConexion.Open();
                miComando.ExecuteNonQuery();
                miConexion.MiConexion.Close();
                miComando.Dispose();
            }
            catch (Exception ex)
            {
                throw new Exception(ErrorScript + ex.Message);
            }
            finally { miConexion.MiConexion.Close(); }
        }

        /// <summary>
        /// Inicializa una nueva instancia del comando de tipo Text.
        /// </summary>
        /// <param name="cmd">Comando a ejecutar.</param>
        private void CargarComando(string cmd)
        {
            miComando = new NpgsqlCommand();
            miComando.CommandType = System.Data.CommandType.Text;
            miComando.Connection = miConexion.MiConexion;
            miComando.CommandText = cmd;
        }
    }
}