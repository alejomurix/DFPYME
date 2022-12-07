using System;
using DataAccessLayer.Clases;
using System.Collections;
using DTO.Clases;
using System.Data;

namespace BussinesLayer.Clases
{
    /// <summary>
    /// Representa una clase de logica de negocio de Unidad de Medida.
    /// </summary>
    public class BussinesUnidadMedida
    {
        /// <summary>
        /// Objeto de tranzacion a Base de datos de Unidad de Medida
        /// </summary>
        private DaoUnidadMedida miDaoUnidad;

        /// <summary>
        /// Inicializa una nueva instancia de Bussines Valor Unidad Medida
        /// </summary>
        public BussinesUnidadMedida()
        {
            this.miDaoUnidad = new DaoUnidadMedida();
        }

        /// <summary>
        /// Obtiene el  listado de Unidad de Medida en una coleccion
        /// </summary>
        /// <returns></returns>
        public ArrayList ListadoUnidadMedida()
        {
            return miDaoUnidad.ListadoUnidadMedida();
        }

        /// <summary>
        /// Obtiene el  listado de Unidad de Medida en una coleccion sin talla.
        /// </summary>
        /// <returns></returns>
        public ArrayList ListadoUnidadMedidaNoTalla()
        {
            return miDaoUnidad.ListadoUnidadMedidaNoTalla();
        }

        /// <summary>
        /// inserta unidad de medida
        /// </summary>
        /// <param name="unidadMedida"></param>
        public void InsertarUnidadMedida(UnidadMedida unidadMedida)
        {
            miDaoUnidad.InsertarUnidadMedida(unidadMedida);
        }

        /// <summary>
        /// Indica Existe unidad de medida
        /// </summary>
        /// <param name="nombre">parametro a ingresar</param>
        /// <returns>false true</returns>
        public bool ExisteUnidadMedida(string nombre)
        {
            return miDaoUnidad.ExisteUnidadMedida(nombre);
        }

        /// <summary>
        /// Lista unidades de medida.
        /// </summary>
        /// <returns></returns>
        public DataSet ListadoCompleto()
        {
            return miDaoUnidad.ListadoCompleto();
        }
        
        /// <summary>
        /// Modifica las unidad es de medida.
        /// </summary>
        /// <param name="miunidadmedida"></param>
        public void ModificarUnidadMedida(UnidadMedida miunidadmedida)
        {
            miDaoUnidad.ModificarUnidadMedida(miunidadmedida);
        }

        /// <summary>
        /// Elimino unidad de medida 
        /// </summary>
        /// <param name="id">parametro a eliminar</param>
        public void EliminarUnidadMedida(int id)
        {
            miDaoUnidad.EliminarUnidadMedida(id);
        }
    }
}