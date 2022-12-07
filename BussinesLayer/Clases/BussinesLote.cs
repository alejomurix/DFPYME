using System;
using DataAccessLayer.Clases;
using DTO.Clases;

namespace BussinesLayer.Clases
{
    /// <summary>
    /// Representa una clase para el manejo de la logica de negocio de Lote.
    /// </summary>
    public class BussinesLote
    {
        /// <summary>
        /// Represent un objeto con acceso a base de datos de Lote.
        /// </summary>
        private DaoLote miDaoLote;

        /// <summary>
        /// Inicializa una nueva instancia de la clase BussinesLote.
        /// </summary>
        public BussinesLote()
        {
            miDaoLote = new DaoLote();
        }

        /// <summary>
        /// Ingresa un registro de Lote a base de datos.
        /// </summary>
        /// <param name="lote">Lote a ingresar.</param>
        public int IngresarLote(Lote lote)
        {
            return miDaoLote.IngresarLote(lote);
        }
    }
}