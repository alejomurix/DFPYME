using System;
using System.Configuration;

namespace Utilities
{
    /// <summary>
    /// Representa una clase para la administracion de la configuracion.
    /// </summary>
    public class AppConfiguracion
    {
        /// <summary>
        /// Objeto que representa el archivo de configuracio de la aplicacion.
        /// </summary>
        private static Configuration configuration = 
            ConfigurationManager.OpenExeConfiguration(System.Windows.Forms.Application.ExecutablePath);

        private Configuration configuration_ =
            ConfigurationManager.OpenExeConfiguration(System.Windows.Forms.Application.ExecutablePath);

        /// <summary>
        /// Obtiene el valor de una llave del archivo de configuracion.
        /// </summary>
        /// <param name="key">Llave a ubicar.</param>
        /// <returns></returns>
        public static string ValorSeccion(string key)
        {
            var seccion = configuration.AppSettings;
            return seccion.Settings[key].Value.ToString();
        }

        public string SectionValue(string key_)
        {
            var seccion = configuration.AppSettings;
            string section = seccion.Settings[key_].Value.ToString();
            return section;
        }

        /// <summary>
        /// Guarda los valores de configuracion en el archivo de la aplicacion.
        /// </summary>
        /// <param name="key">Llave de la configuracion.</param>
        /// <param name="value">Valor a guardar en la llave de configuracion.</param>
        public static void SaveConfiguration(string key, string value)
        {
            var seccion = configuration.AppSettings;
            seccion.Settings[key].Value = value;
            configuration.Save();
        }
    }
}