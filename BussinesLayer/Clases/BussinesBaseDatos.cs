using System;
using DataAccessLayer.Clases;

namespace BussinesLayer.Clases
{
    /// <summary>
    /// 
    /// </summary>
    public class BussinesBaseDatos
    {
        /// <summary>
        /// Objeto que proporciona acceso al tratamiento oportuno en Base de Datos.
        /// </summary>
        private DaoBaseDatos miDaoBaseDatos;

        /// <summary>
        /// Inicializa una nueva instancia de BussinesBaseDatos.
        /// </summary>
        public BussinesBaseDatos()
        {
            miDaoBaseDatos = new DaoBaseDatos();
        }

        /// <summary>
        /// Realiza un test a la conexión establecida verificando su configuración.
        /// </summary>
        /// <returns></returns>
        public bool TestConexion()
        {
            return miDaoBaseDatos.TestSaveConexion();
        }

        /// <summary>
        /// Crea la Base de datos a partir de la configuración almacenada.
        /// </summary>
        /// <param name="nombre">Nombre al cual se le adjudica la base de datos.</param>
        /// <param name="script">Script que genera los objetos en la base de datos.</param>
        public void CrearDataBase(string nombre, string script)
        {
            miDaoBaseDatos.CrearDataBase(nombre, script);
        }
    }
}