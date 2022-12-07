using System;
using System.Data;
using DataAccessLayer.Clases;
using DTO.Clases;

namespace BussinesLayer.Clases
{
    public class BussinesBono
    {
        /// <summary>
        /// Objeto que proporciona acceso a la capa de datos de Bono.
        /// </summary>
        private DaoBono miDaoBono;

        /// <summary>
        /// Inicializa una nueva instancia de la clase BussinesBono.
        /// </summary>
        public BussinesBono()
        {
            this.miDaoBono = new DaoBono();
        }

        //BONO

        /// <summary>
        /// Ingresa los datos de Bono a la base de datos.
        /// </summary>
        /// <param name="bono">Bono a ser ingresado.</param>
        public int Ingresar(Bono bono)
        {
            return miDaoBono.Ingresar(bono);
        }

        /// <summary>
        /// Obtiene el resultado de la consulta de Bono.
        /// </summary>
        /// <param name="cliente">Cliente a consultar bono.</param>
        /// <param name="canjeables">Indica si se consulta todos los bonos o solo los canjeables.</param>
        /// <param name="rowBase">Registro base para la consulta.</param>
        /// <param name="rowMax">Registros maximos a recuperar.</param>
        /// <returns></returns>
        public DataTable Bonos(string cliente, bool canjeables, int rowBase, int rowMax)
        {
            return miDaoBono.Bonos(cliente, canjeables, rowBase, rowMax);
        }

        /// <summary>
        /// Obtiene el total de registros del resultado de la consulta de Bono.
        /// </summary>
        /// <param name="cliente">Cliente a consultar bono.</param>
        /// <param name="canjeables">Indica si se consulta todos los bonos o solo los canjeables.</param>
        /// <returns></returns>
        public long GetRowsBonos(string cliente, bool canjeables)
        {
            return miDaoBono.GetRowsBonos(cliente, canjeables);
        }

        public DataTable Bonos(int idCaja, DateTime fecha)
        {
            return miDaoBono.Bonos(idCaja, fecha);
        }

        public Bono NotaCredito(int id)
        {
            return miDaoBono.NotaCredito(id);
        }

        /// <summary>
        /// Obtiene el total del saldo de Bonos de un Cliente.
        /// </summary>
        /// <param name="cliente">Cliente a consultar saldo.</param>
        /// <returns></returns>
        public long SaldoEnBonos(string cliente)
        {
            return miDaoBono.SaldoEnBonos(cliente);
        }

        /// <summary>
        /// Edita el Bono de manera que este pasa a estar canjeado.
        /// </summary>
        /// <param name="idBono">Id del Bono editar o canjear.</param>
        public void CanjeBono(int idBono)
        {
            miDaoBono.CanjeBono(idBono);
        }

        //SEGUIMIENTO BONO

        /// <summary>
        /// Ingresa los datos de Seguimiento de Bono en la base de datos.
        /// </summary>
        /// <param name="bono">Datos del Seguimiento de Bono a ingresar.</param>
        public void IngresarSeguimiento(Bono bono, string noFactura)
        {
            miDaoBono.IngresarSeguimiento(bono, noFactura);
        }

        /// <summary>
        /// Ingresa los datos de Seguimiento de Bono teniendo empezando por el bono con menor saldo.
        /// </summary>
        /// <param name="cliente">Cliente al cual pertenece el bono.</param>
        /// <param name="valor">Valor del seguimiento del bono.</param>
        public void IngresarSeguimiento(string cliente, int valor, int idCaja, int idUser, string noFactura)
        {
            miDaoBono.IngresarSeguimiento(cliente, valor, idCaja, idUser, noFactura);
        }

        /// <summary>
        /// Obtiene el resultado de la consulta de los canjes hechos a un bono.
        /// </summary>
        /// <param name="bono">Id del Bono a consultar.</param>
        /// <returns></returns>
        public DataTable Seguimientos(int bono)
        {
            return miDaoBono.Seguimientos(bono);
        }

        public DataSet Seguimientos(int idCaja, DateTime fecha, bool caja)
        {
            return miDaoBono.Seguimientos(idCaja, fecha, caja);
        }

        public DataTable SeguimientosDeBonoCliente(int idCaja, DateTime fecha)
        {
            return miDaoBono.SeguimientosDeBonoCliente(idCaja, fecha);
        }
    }
}