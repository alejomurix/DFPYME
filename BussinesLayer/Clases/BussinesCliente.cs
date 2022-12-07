using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DTO.Clases;
using DataAccessLayer.Clases;
using System.Collections;

namespace BussinesLayer.Clases
{
    public class BussinesCliente
    {
        #region Atributos

        /// <summary>
        /// Atributo tipo DaoCliente.
        /// </summary>
        private DaoCliente miDaoCliente;

        #endregion

        public BussinesCliente()
        {
            miDaoCliente = new DaoCliente();
        }

        #region Metodos

        // temporal
        public DataTable Tipos()
        {
            return miDaoCliente.Tipos();
        }

        public DataTable Clasificacion()
        {
            return this.miDaoCliente.Clasificacion();
        }
        //

        /// <summary>
        /// Verifica si un cliente existe en la base de datos.
        /// </summary>
        /// <param name="nit">Nit del Cliente</param>
        /// <returns></returns>
        public bool ExisteCliente(string nit)
        {
            return miDaoCliente.ExisteCliente(nit);
        }

        ///<summary>
        /// Metodo para insertar un nuevo cliente
        ///</summary>
        ///<param name="cliente">Recibe un objeto tipo Cliente</param>
        public void InsertarCliente(Cliente cliente) 
        {
            miDaoCliente.InsertarCliente(cliente);
        }

        /// <summary>
        /// Obtiene el listado de los clientes en un DataTable
        /// </summary>
        public DataTable ListadoDeClientes()
        {
            return miDaoCliente.ListadoDeClientes();
        }

        /// <summary>
        /// Realiza una Consulta de un cliente y retorna el registro en un DataTable
        /// </summary>
        /// <param name="nit">Nit del cliente a consultar</param>
        public DataTable ConsultaClienteNit(string nit)
        {
            return miDaoCliente.ConsultaClienteNit(nit);
        }

        /// <summary>
        /// Realiza una Consulta de un cliente y retorna el registro en un DataTable
        /// </summary>
        /// <param name="nombre">Nombre del cliente a consultar</param>
        /// <returns></returns>
        public DataTable ConsultaClienteNombre(string nombre)
        {
            return miDaoCliente.ConsultaClienteNombre(nombre);
        }

        /// <summary>
        /// Crea un DataTable con la lista de los clientes segun el criterio enviado.
        /// </summary>
        /// <param name="nombre">Nombre o parte del nombre a ser buscado</param>
        /// <returns></returns>
        public DataTable FiltroClienteNombre(string nombre) 
        {
            return miDaoCliente.FiltroClienteNombre(nombre);
        }

        /// <summary>
        /// Crea un DataTable con la lista de los clientes segun el criterio enviado.
        /// </summary>
        /// <param name="cedula">Nit o Cedula o parte de esta para ser buscada</param>
        /// <returns></returns>
        public DataTable FiltroClienteCedula(string cedula)
        {
            return miDaoCliente.FiltroClienteCedula( cedula );
        }

        /// <summary>
        /// Obtiene el registro completo de un Cliente
        /// </summary>
        /// <param name="nit">Nit del Cliente a editar</param>
        /// <returns></returns>
        public Cliente ClienteAEditar(string nit)
        {
            return miDaoCliente.ClienteAEditar(nit);
        }

        /// <summary>
        /// Edita los datos de un cliente.
        /// </summary>
        /// <param name="cliente">Cliente a editar</param>
        public void EditarCliente(Cliente cliente)
        {
            miDaoCliente.EditarCliente(cliente);
        }

        /// <summary>
        /// Elimina el registro de un cliente de la base de datos
        /// </summary>
        /// <param name="nit">Nit del clinete a eliminar</param>
        public void EliminarCliente(string nit)
        {
            miDaoCliente.EliminarCliente(nit);
        }

        /// <summary>
        /// Obtiene los datos del Cliente de la factura de venta para su impresión.
        /// </summary>
        /// <param name="nit">Nit del cliente de la Factura.</param>
        /// <returns></returns>
        public DataSet PrintCliente(string nit)
        {
            return miDaoCliente.PrintCliente(nit);
        }

        // Puntos de cliente

        public double Puntos(string nitCliente)
        {
            return this.miDaoCliente.Puntos(nitCliente);
        }

        public void EditarPuntos(string nitCliente, double puntos)
        {
            this.miDaoCliente.EditarPuntos(nitCliente, puntos);
        }

        public void InsertarCanje(Canje canje)
        {
            this.miDaoCliente.InsertarCanje(canje);
        }

        // Fin Puntos de cliente


        //REGION SALDOS DE CLIENTE.

        /*public void IngresarSaldo(Saldo saldo)
        {
            miDaoCliente.IngresarSaldo(saldo);
        }*/

        /*public DataTable Saldos(string nit, int rowBase, int rowMax)
        {
            return null;// miDaoCliente.Saldos(nit, rowBase, rowMax);
        }*/

        #endregion


        public void DepurarCliente()
        {
            this.miDaoCliente.DepurarCliente();
        }

    }
}