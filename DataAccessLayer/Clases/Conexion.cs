using System;
using System.Configuration;
using Npgsql;
using Utilities;

namespace DataAccessLayer.Clases
{
    /// <summary>
    /// Esta clase representa una conexion a PostgreSQL
    /// </summary>
    public class Conexion
    {
        /// <summary>
        /// Obtiene y establece una conexion al servidor PostgreSQL
        /// </summary>
        public NpgsqlConnection MiConexion { set; get; }

        /// <summary>
        /// Inicializa una nueva instacion de Conexion
        /// </summary>
        public Conexion()
        {
            var servidor = AppConfiguracion.ValorSeccion("server");
            var port = AppConfiguracion.ValorSeccion("port");
            var user = AppConfiguracion.ValorSeccion("user");
            var db = AppConfiguracion.ValorSeccion("dataBase");
            var password = AppConfiguracion.ValorSeccion("password");
            this.MiConexion = new NpgsqlConnection
                ("Server=" + servidor + "; " +
                 "Port=" + port + "; " +
                 "UserId=" + user + "; " +
                 "Password=" + password + "; " +
                 "DataBase=" + db + "; ");
        }

        public Conexion(string server, string dataBase)
        {
            //var servidor = AppConfiguracion.ValorSeccion("server");
            var port = AppConfiguracion.ValorSeccion("port");
            var user = AppConfiguracion.ValorSeccion("user");
            var db = AppConfiguracion.ValorSeccion("dataBase");
            var password = AppConfiguracion.ValorSeccion("password");

            this.MiConexion = new NpgsqlConnection
                ("Server=" + server + "; " +
                 "Port=" + port + "; " +
                 "UserId=" + user + "; " +
                 "Password=" + password + "; " +
                 "DataBase=" + db + "; ");
        }

        public Conexion(string dataBase)
        {
            var servidor = AppConfiguracion.ValorSeccion("server");
            var port = AppConfiguracion.ValorSeccion("port");
            var user = AppConfiguracion.ValorSeccion("user");
            
            var password = AppConfiguracion.ValorSeccion("password");
            this.MiConexion = new NpgsqlConnection
                ("Server=" + servidor + "; " +
                 "Port=" + port + "; " +
                 "UserId=" + user + "; " +
                 "Password=" + password + "; " +
                 "DataBase=" + dataBase + "; ");
        }

        public Conexion(bool obj)
        {
            AppConfiguracion ap = new AppConfiguracion();
            var servidor = ap.SectionValue("server");
            var port = ap.SectionValue("port");
            var user = ap.SectionValue("user");
            var db = ap.SectionValue("dataBase");
            var password = ap.SectionValue("password");
            this.MiConexion = new NpgsqlConnection
                ("Server=" + servidor + "; " +
                 "Port=" + port + "; " +
                 "UserId=" + user + "; " +
                 "Password=" + password + "; " +
                 "DataBase=" + db + "; ");
        }

        /// <summary>
        /// Obtiene la cadena de conexión sin incluir el nombre de la base de datos.
        /// </summary>
        /// <returns></returns>
        public string GetPartialStringConnection()
        {
            var servidor = AppConfiguracion.ValorSeccion("server");
            var port = AppConfiguracion.ValorSeccion("port");
            var user = AppConfiguracion.ValorSeccion("user");
            var password = AppConfiguracion.ValorSeccion("password");
            return
                "Server=" + servidor + "; " +
                "Port=" + port + "; " +
                "UserId=" + user + "; " +
                "Password=" + password + "; ";
        }
    }
}