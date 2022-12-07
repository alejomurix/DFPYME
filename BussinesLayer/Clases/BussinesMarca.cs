using System;
using System.Data;
using System.Collections;
using System.Collections.Generic;
using DTO.Clases;
using DataAccessLayer.Clases;

namespace BussinesLayer.Clases
{
    /// <summary>
    /// Representa una clase para la logica de negocio de Marca.
    /// </summary>
    public class BussinesMarca
    {
        /// <summary>
        /// Objeto de tranzacion a Base de datos de Marca.
        /// </summary>
        private DaoMarca miDaoMarca;

        /// <summary>
        /// Inicializa una nueva instancia de la clase BussinesMarca.
        /// </summary>
        public BussinesMarca()
        {
            this.miDaoMarca = new DaoMarca();
        }

        public bool Existe(string nombre)
        {
            return miDaoMarca.ExisteMarca(nombre);
        }

        public int UltimoId()
        {
            return miDaoMarca.UltimoId();
        }

        /// <summary>
        /// Ingresa una marca a la base de datos si esta no exite, Devuelve true si la insercion se realizo.
        /// </summary>
        /// <param name="mimarca">Marca a ingresar.</param>
        /// <returns></returns>
        public bool InsertarMarca(Marca mimarca)
        {
            if (!miDaoMarca.ExisteMarca(mimarca.NombreMarca))
            {
                miDaoMarca.InsertarMarca(mimarca);
                return true;
            }
            else
                return false;
        }

        /// <summary>
        /// Obtiene el listado de las marcas en una coleccion.
        /// </summary>
        /// <returns></returns>
        public ArrayList ListarMarcas()
        {
            return miDaoMarca.ListarMarcas();
        }

        public Marca Marca(int codigo)
        {
            return miDaoMarca.Marca(codigo);
        }

        /// <summary>
        /// Edita el registro de una marca en la base de datos, Devuelve true si la insercion se realizo.
        /// </summary>
        /// <param name="mimarca">Marca a editar.</param>
        public bool EditarMarca(Marca mimarca)
        {
            if (!miDaoMarca.ExisteMarca(mimarca.NombreMarca))
            {
                miDaoMarca.EditarMarca(mimarca);
                return true;
            }
            else
                return false;
        }

        /// <summary>
        /// Eliminar el registro de una Marca en la base de datos.
        /// </summary>
        /// <param name="idmarca">Id de la marca a eliminar.</param>
        public void EliminarMarca(int idmarca)
        {
            miDaoMarca.EliminarMarca(idmarca);
        }

        /// <summary>
        /// Obtiene el listado de las marcas segun el nombre o parte de este.
        /// </summary>
        /// <param name="nombremarca">Nombre a consultar.</param>
        public ArrayList ListaMarcasNombre(string nombre)
        {
            return miDaoMarca.ListarMarcasNombre(nombre);
        }

        // Descuentos por marca 01/03/2108

        public int CountDescuentoMarca()
        {
            return this.miDaoMarca.CountDescuentoMarca();
        }

        public void IngresarDescuento(Marca marca)
        {
            this.miDaoMarca.IngresarDescuento(marca);
        }

        public DataTable MarcaDescuentos()
        {
            return this.miDaoMarca.MarcaDescuentos();
        }

        public void AplicarDescuentoMarca(Marca marca)
        {
            this.miDaoMarca.AplicarDescuentoMarca(marca);
        }

       /* public void RestablecerValor(int idMarca)
        {
            this.miDaoMarca.RestablecerValor(idMarca);
        }*/

        /*public void EliminarDescuento()
        {
            this.miDaoMarca.EliminarDescuento();
        }*/

        public void EliminarDescuento(int id)
        {
            this.miDaoMarca.EliminarDescuento(id);
        }

        public void ReiniciarSecuenciaDescuento()
        {
            this.miDaoMarca.ReiniciarSecuenciaDescuento();
        }


        // Fin Descuentos por marca 01/03/2108




        public void Ajustar()
        {
            miDaoMarca.Ajustar();
        }
    }
}