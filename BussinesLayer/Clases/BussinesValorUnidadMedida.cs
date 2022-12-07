using System;
using System.Data;
using DataAccessLayer.Clases;
using System.Collections;
using DTO.Clases;
using System.Collections.Generic;

namespace BussinesLayer.Clases
{
    /// <summary>
    /// Representa una clase de logica de negocio para Valores de Unidad de Medida
    /// </summary>
    public class BussinesValorUnidadMedida
    {
        /// <summary>
        /// Objeto de tranzacion a Base de datos de Valor Unidad de Medida
        /// </summary>
        private DaoValorUnidadMedida miDaoValorUnidad;

        /// <summary>
        /// Inicializa una nueva instancia de Bussines Valor Unidad Medida
        /// </summary>
        public BussinesValorUnidadMedida()
        {
            this.miDaoValorUnidad = new DaoValorUnidadMedida();
        }

        /// <summary>
        /// Ingresa un registro de Valor de unidad de medida en la base de datos.
        /// </summary>
        /// <param name="miValorMedida">Valor de Unidad de Medida a ingresar.</param>
        public void InsertarValorUnidadMedida(ValorUnidadMedida miValorMedida)
        {
            miDaoValorUnidad.InsertarValorUnidadMedida(miValorMedida);
        }

        /// <summary>
        /// Ingresa un registro a la relacion de Producto y ValorUnidadMedida.
        /// </summary>
        /// <param name="medida">Medida a ingresar.</param>
        public void InsertarMedidaProducto(ValorUnidadMedida medida)
        {
            miDaoValorUnidad.InsertarMedidaProducto(medida);
        }

        public List<ValorUnidadMedida> UnidadesDeMedida()
        {
            return miDaoValorUnidad.UnidadesDeMedida();
        }

        /// <summary>
        /// Obtiene el  listado de los valores de Unidad de Medida en una coleccion
        /// </summary>
        /// <param name="idunidadmedida">Id de la unidad de medida</param>
        /// <returns></returns>
        public ArrayList ListadoValorUnidadMedida(int idUnidadMedida)
        {
            return miDaoValorUnidad.ListadoValorUnidadMedida(idUnidadMedida);
        }

        /// <summary>
        /// Obtiene el listado de todas las tallas.
        /// </summary>
        /// <returns></returns>
        public DataTable ListadoDeTallas()
        {
            return miDaoValorUnidad.ListadoDeTallas();
        }

        /*public DataTable MedidaProducto(long codigo)
        {
            return miDaoValorUnidad.InsertarMedidaProducto(codigo);
        }*/

        /// <summary>
        /// Obtiene el listado de medidas de un producto.
        /// </summary>
        /// <param name="codigo">Codigo del producto a consultar.</param>
        /// <returns></returns>
        public DataTable MedidasDeProducto(string codigo)
        {
            return miDaoValorUnidad.MedidasDeProducto(codigo);
        }

        /// <summary>
        /// Indica que ul valor unidad de medida existan.
        /// </summary>
        /// <param name="nombre"></param>
        /// <returns></returns>
        public bool ExisteValorUnidadMedida(string nombre)
        {
            return miDaoValorUnidad.ExisteValorUnidadMedida(nombre);
        }

        /// <summary>
        /// Modifica los valores de las unidades de medida
        /// </summary>
        /// <param name="miValorMedida"></param>
        public void ModificaValorUnidadMedida(ValorUnidadMedida miValorMedida)
        {
            miDaoValorUnidad.ModificaValorMdida(miValorMedida);
        }

        /// <summary>
        /// Elimina los valores de las unidades de medida.
        /// </summary>
        /// <param name="id"></param>
        public void EliminarValorMedida(int id)
        {
            miDaoValorUnidad.EliminarValorMedida(id);
        }

        /// <summary>
        /// Elimina el registro de la relacion de Producto y Medida.
        /// </summary>
        /// <param name="codigo">Codigo del Producto.</param>
        /// <param name="id">Id de la Medida.</param>
        public void EliminarProductoMedida(string codigo, int id)
        {
            miDaoValorUnidad.EliminarProductoMedida(codigo, id);
        }
    }
}