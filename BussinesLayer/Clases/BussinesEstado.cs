using System.Data;
using DataAccessLayer.Clases;

namespace BussinesLayer.Clases
{
    /// <summary>
    /// Representa una clase para la logica de negocio de Estado.
    /// </summary>
    public class BussinesEstado
    {
        /// <summary>
        /// 
        /// </summary>
        private DaoEstado miDaoEstado;

        /// <summary>
        /// Inicializa una nueva instancia de la clase BussinesEstado.
        /// </summary>
        public BussinesEstado()
        {
            this.miDaoEstado = new DaoEstado();
        }

        /// <summary>
        /// Obtiene un listado de los registros de Estado.
        /// </summary>
        /// <returns></returns>
        public DataTable Lista()
        {
            return miDaoEstado.Lista();
        }

        public DataTable ListaExcluyente(int id)
        {
            return this.miDaoEstado.ListaExcluyente(id);
        }

        public DataTable ListaExcluyente(int id, int id2)
        {
            return this.miDaoEstado.ListaExcluyente(id, id2);
        }

        public DataTable ListaExcluyente(int id, int id2, int id3)
        {
            return this.miDaoEstado.ListaExcluyente(id, id2, id3);
        }

        public DTO.Clases.Estado EstadoById(int id)
        {
            return miDaoEstado.EstadoById(id);
        }
    }
}