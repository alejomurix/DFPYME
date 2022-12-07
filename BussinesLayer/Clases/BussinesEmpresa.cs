using System.Data;
using DataAccessLayer.Clases;
using DTO.Clases;

namespace BussinesLayer.Clases
{
    /// <summary>
    /// Representa una clase de logica de negocio de Empresa.
    /// </summary>
    public class BussinesEmpresa
    {
        /// <summary>
        /// Proporciona acceso a la capa de datos de Empresa.
        /// </summary>
        private DaoEmpresa miDaoEmpresa;

        /// <summary>
        /// Incializa una nueva instancia de la clase BussinesEmpresa.
        /// </summary>
        public BussinesEmpresa()
        {
            this.miDaoEmpresa = new DaoEmpresa();
        }

        /// <summary>
        /// Insertar empresa a la base de datos.
        /// </summary>
        /// <param name="empresa">objeto empresa</param>
        public void InsertarEmpresa(Empresa empresa)
        {
            miDaoEmpresa.InsertarEmpresa(empresa);
        }

        /// <summary>
        /// Ediata empresa;
        /// </summary>
        /// <param name="empresa"></param>
        public void EditaEmpresa(Empresa empresa)
        {
            miDaoEmpresa.EditarEmpresa(empresa);
        }

        /// <summary>
        /// Consulta en la base de datos si existe nit
        /// </summary>
        /// <param name="nit">Nit a consultar</param>
        /// <returns>existe (true) o no existe(false)</returns>
        public bool ExisteNit(string nit)
        {
            return miDaoEmpresa.ExisteNit(nit);
        }

        /// <summary>
        /// Obtiene los datos del registro de la Empresa.
        /// </summary>
        /// <returns></returns>
        public Empresa ObtenerEmpresa()
        {
            return miDaoEmpresa.ObtenerEmpresa();
        }

        /// <summary>
        /// Obtiene los datos de la Empresa para su impresión.
        /// </summary>
        /// <returns></returns>
        public DataSet PrintEmpresa()
        {
            return miDaoEmpresa.PrintEmpresa();
        }
    }
}