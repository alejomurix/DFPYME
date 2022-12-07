using System;
using System.Collections;
using DataAccessLayer.Clases;
using DTO.Clases;

namespace BussinesLayer.Clases
{
    /// <summary>
    /// Representa una clase de logica de negocio para Iva
    /// </summary>
    public class BussinesIva
    {
        /// <summary>
        /// Objeto de tranzacion a Base de datos de Iva
        /// </summary>
        private DaoIva miDaoIva;

        /// <summary>
        /// Inicializa una nueva instancia de Bussines Iva
        /// </summary>
        public BussinesIva()
        {
            this.miDaoIva = new DaoIva();
        }

        /// <summary>
        /// Ingresa iva.
        /// </summary>
        /// <param name="iva"></param>
        public void IngresarIva(Iva iva)
        {
            miDaoIva.InsertaIva(iva);
        }

        /// <summary>
        /// Obtiene el  listado de Iva en una coleccion
        /// </summary>
        /// <returns></returns>
        public ArrayList ListadoIva()
        {
            return miDaoIva.ListadoIva();
        }

        public Iva Iva(int id)
        {
            return this.miDaoIva.Iva(id);
        }

        /// <summary>
        /// Elimina iva
        /// </summary>
        /// <param name="idIva">id iva a eliminar</param>
        public void EliminarIva(int idIva)
        {
            miDaoIva.EliminarIva(idIva);
        }

        /// <summary>
        /// Edita iva
        /// </summary>
        /// <param name="iva"></param>
        public void EditaIva(Iva iva)
        {
            miDaoIva.EditaIva(iva);
        }

        /// <summary>
        /// Existe iva.
        /// </summary>
        /// <param name="valorIva">valor de iva a comparar</param>
        public bool ExisteIva(double valorIva)
        {
           return miDaoIva.ExisteIva(valorIva);
        }
    }
}