using System;
using System.Collections.Generic;
using DataAccessLayer.Clases;
using System.Collections;
using DTO.Clases;

namespace BussinesLayer.Clases
{
    /// <summary>
    /// Representa una clase de logica de negocio de Descuento.
    /// </summary>
    public class BussinesDescuento
    {
        /// <summary>
        /// Objeto de tranzacion a Base de datos de Descuento.
        /// </summary>
        private DaoDescuento miDaoDescuento;

        /// <summary>
        /// Inicializa una nueva instancia de Bussines Descuento.
        /// </summary>
        public BussinesDescuento()
        {
            this.miDaoDescuento = new DaoDescuento();
        }

        /// <summary>
        /// Inserta descuento.
        /// </summary>
        /// <param name="descuento"></param>
        public void InsertaDescuento(Descuento descuento)
        {
            miDaoDescuento.InsertaDescuento(descuento);
        }

        /// <summary>
        /// Edita descuento.
        /// </summary>
        /// <param name="elDescuento"></param>
        public void EditaDescuento(Descuento elDescuento)
        {
            miDaoDescuento.EditaDescuento(elDescuento);
        }

        /// <summary>
        /// Eliminar descuento
        /// </summary>
        /// <param name="idDescuento">id descuento a eliminar.</param>
        public void Eliminardescuento(int idDescuento)
        {
            miDaoDescuento.EliminaDescuento(idDescuento);
        }

        /// <summary>
        /// Existe descuento
        /// </summary>
        /// <param name="valorDescuento">valor del descuento a consultar</param>
        /// <returns></returns>
        public bool ExisteDescuento(double valorDescuento)
        {
            return miDaoDescuento.ExisteDescuento(valorDescuento);
        }

        /// <summary>
        /// Obtiene el  listado de los Descuentos.
        /// </summary>
        /// <returns></returns>
        public ArrayList ListadoDescuento()
        {
            return miDaoDescuento.ListadoDescuento();
        }

        /// <summary>
        /// Inserta un registro de Descuento a la base de datos
        /// </summary>
        /// <param name="midescuento">Descuento a ingresar</param>
        public void InsertarDescuento(Descuento descuento)
        {
            miDaoDescuento.InsertarDescuento(descuento);
        }

        /// <summary>
        /// Obtinene una lista de Descuentos segun el producto.
        /// </summary>
        /// <param name="codigo">Codigo del producto</param>
        /// <returns></returns>
        public List<Descuento> ListadoDescuento(string codigo)
        {
            return miDaoDescuento.ListadoDeDescuento(codigo);
        }
    }
}