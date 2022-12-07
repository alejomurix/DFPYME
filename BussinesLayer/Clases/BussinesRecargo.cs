using System;
using System.Collections;
using System.Collections.Generic;
using DataAccessLayer.Clases;
using DTO.Clases;

namespace BussinesLayer.Clases
{
    /// <summary>
    /// Representa una clase de logica de negocio de Recargo.
    /// </summary>
    public class BussinesRecargo
    {
        /// <summary>
        /// Objeto de tranzacion a Base de datos de Recargo.
        /// </summary>
        private DaoRecargo miDaoRecargo;

        /// <summary>
        /// Inicializa una nueva instancia de Bussines Recargo.
        /// </summary>
        public BussinesRecargo()
        {
            this.miDaoRecargo = new DaoRecargo();
        }

        /// <summary>
        /// Insertar recargo.
        /// </summary>
        /// <param name="recargo"></param>
        public void InsertarRcargo(Recargo recargo)
        {
            miDaoRecargo.InsertaRecargo(recargo);
        }

        /// <summary>
        /// Obtiene el listado de los recargos en una coleccion.
        /// </summary>
        /// <returns></returns>
        public ArrayList ListadoRecargo()
        {
            return miDaoRecargo.ListadoRecargo();
        }

        /// <summary>
        /// Edita recargo.
        /// </summary>
        /// <param name="recargo"></param>
        public void EditarRecargo(Recargo recargo)
        {
            miDaoRecargo.EditaRecargo(recargo);
        }

        /// <summary>
        /// Elimina recargo.
        /// </summary>
        /// <param name="idRecargo">id recargo a aliminar</param>
        public void EliminaRecargo(int idRecargo)
        {
            miDaoRecargo.EliminarRecargo(idRecargo);
        }

        /// <summary>
        /// Existe recargo
        /// </summary>
        /// <param name="valorRecargo">valor del recargo a consultar</param>
        /// <returns></returns>
        public bool ExisteRecargo(double valorRecargo)
        {
            return miDaoRecargo.ExisteRecargo(valorRecargo);
        }

        /// <summary>
        /// Obtiene el listado de los recargos segun el producto en una coleccion.
        /// </summary>
        /// <param name="codigo">Codigo del producto</param>
        /// <returns></returns>
        public List<Recargo> ListadoDeRecargo(string codigo)
        {
            return miDaoRecargo.ListadoDeRecargo(codigo);
        }
    }
}