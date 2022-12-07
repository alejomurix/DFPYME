using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using DTO.Clases;
using DataAccessLayer.Clases;

namespace BussinesLayer.Clases
{
    public class BussinesSaldo
    {
        /// <summary>
        /// Objeto que permite la comunicación a base de datos de saldo.
        /// </summary>
        private DaoSaldo miDaoSaldo;

        /// <summary>
        /// Inicializa una nueva instancia de la clase BussinesSaldo.
        /// </summary>
        public BussinesSaldo()
        {
            this.miDaoSaldo = new DaoSaldo();
        }

        #region Saldo

        //
        /// <summary>
        /// Ingresa un registro de Saldo en la Base de datos.
        /// </summary>
        /// <param name="saldo">Saldo a ingresar.</param>
        public long IngresarSaldo(Saldo saldo)
        {
            return  miDaoSaldo.IngresarSaldo(saldo);
        }

        /// <summary>
        /// Obtiene el resultado de la consulta de los saldos del cliente.
        /// </summary>
        /// <param name="nit">Nit del Cliente a consultar.</param>
        /// <param name="rowBase">Registro base para la consulta.</param>
        /// <param name="rowMax">Cantidad de registros máximos a recuperar.</param>
        /// <returns></returns>
        public DataTable SaldosCliente(string nit, int rowBase, int rowMax)
        {
            return miDaoSaldo.SaldosCliente(nit, rowBase, rowMax);
        }

        /// <summary>
        /// Obtiene el total de registros de la consulta de los saldos del cliente.
        /// </summary>
        /// <param name="nit">Nit del Cliente a consultar.</param>
        /// <returns></returns>
        public long GetRowsSaldosCliente(string nit)
        {
            return miDaoSaldo.GetRowsSaldosCliente(nit);
        }

        public DataSet SaldosDelDia(int idCaja, DateTime fecha)
        {
            return miDaoSaldo.SaldosDelDia(idCaja, fecha);
        }

        public Saldo Saldo(int id)
        {
            return miDaoSaldo.Saldo(id);
        }

        /// <summary>
        /// Obtiene el saldo actual de adelantos del cliente.
        /// </summary>
        /// <param name="nit">Nit del cliente a consultar.</param>
        /// <returns></returns>
        public int SaldoEnAdelantos(string nit)
        {
            try
            {
                return miDaoSaldo.Saldos(nit).Sum(s => s.VSaldo);
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al cargar el saldo de adelantos del Cliente.\n" + ex.Message);
            }
        }

        #endregion

        // Canje Saldo

        public int IngresarCanje(Canje canje)
        {
            return this.miDaoSaldo.IngresarCanje(canje);
        }

        public List<Canje> IngresarCanje(Canje canje, int valor)
        {
            return this.miDaoSaldo.IngresarCanje(canje, valor);
        }

        /// <summary>
        /// Obtiene el resultado de la consulta de las transacciones del cliente.
        /// </summary>
        /// <param name="nit">Nit del Cliente a consultar.</param>
        /// <param name="rowBase">Registro base para la consulta.</param>
        /// <param name="rowMax">Cantidad de registros máximos a recuperar.</param>
        /// <returns></returns>
        public DataTable CanjesCliente(string nit, int rowBase, int rowMax)
        {
            return miDaoSaldo.CanjesCliente(nit, rowBase, rowMax);
        }

        /// <summary>
        /// Obtiene el total de registros de la consulta de las transacciones del cliente.
        /// </summary>
        /// <param name="nit">Nit del Cliente a consultar.</param>
        /// <returns></returns>
        public long GetRowsCanjesCliente(string nit)
        {
            return miDaoSaldo.GetRowsCanjesCliente(nit);
        }

        public DataTable CanjesCliente(int idCaja, DateTime fecha)
        {
            return miDaoSaldo.CanjesCliente(idCaja, fecha);
        }

        public DataSet Canjes(int idCaja, DateTime fecha, bool caja)
        {
            return miDaoSaldo.Canjes(idCaja, fecha, caja);
        }

        public DataTable Canjes(int idAnticipo)
        {
            return this.miDaoSaldo.Canjes(idAnticipo);
        }

        public Canje Canje(int id)
        {
            return this.miDaoSaldo.Canje(id);
        }

        // END CANJE SALDO

        public DataTable Anticipos(int rowIndex, int rowMax)
        {
            return this.miDaoSaldo.Anticipos(rowIndex, rowMax);
        }

        public int GetRowsAnticipos()
        {
            return this.miDaoSaldo.GetRowsAnticipos();
        }

        public DataTable Anticipos(DateTime fecha, int rowIndex, int rowMax)
        {
            return this.miDaoSaldo.Anticipos(fecha, rowIndex, rowMax);
        }

        public int GetRowsAnticipos(DateTime fecha)
        {
            return this.miDaoSaldo.GetRowsAnticipos(fecha);
        }

        public DataTable Anticipos(DateTime fecha, DateTime fecha2, int rowIndex, int rowMax)
        {
            return this.miDaoSaldo.Anticipos(fecha, fecha2, rowIndex, rowMax);
        }

        public int GetRowsAnticipos(DateTime fecha, DateTime fecha2)
        {
            return this.miDaoSaldo.GetRowsAnticipos(fecha, fecha2);
        }

        public DataTable Anticipos(string nit, DateTime fecha, int rowIndex, int rowMax)
        {
            return this.miDaoSaldo.Anticipos(nit, fecha, rowIndex, rowMax);
        }

        public int GetRowsAnticipos(string nit, DateTime fecha)
        {
            return this.miDaoSaldo.GetRowsAnticipos(nit, fecha);
        }

        public DataTable Anticipos(string nit, DateTime fecha, DateTime fecha2, int rowIndex, int rowMax)
        {
            return this.miDaoSaldo.Anticipos(nit, fecha, fecha2, rowIndex, rowMax);
        }

        public int GetRowsAnticipos(string nit, DateTime fecha, DateTime fecha2)
        {
            return this.miDaoSaldo.GetRowsAnticipos(nit, fecha, fecha2);
        }

        public DataTable AnticiposSaldo(int rowIndex, int rowMax)
        {
            return this.miDaoSaldo.AnticiposSaldo(rowIndex, rowMax);
        }

        public int GetRowsAnticiposSaldo()
        {
            return this.miDaoSaldo.GetRowsAnticiposSaldo();
        }


        public DataTable AnticiposSaldo()
        {
            return this.miDaoSaldo.AnticiposSaldo();
        }

        public DataTable AnticiposSaldo(DateTime fecha)
        {
            return this.miDaoSaldo.AnticiposSaldo(fecha);
        }

        public DataTable AnticiposSaldo(DateTime fecha, DateTime fecha2)
        {
            return this.miDaoSaldo.AnticiposSaldo(fecha, fecha2);
        }

        public DataTable AnticiposSaldo(string nit, DateTime fecha)
        {
            return this.miDaoSaldo.AnticiposSaldo(nit, fecha);
        }

        public DataTable AnticiposSaldo(string nit, DateTime fecha, DateTime fecha2)
        {
            return this.miDaoSaldo.AnticiposSaldo(nit, fecha, fecha2);
        }

        public int TotalAnticiposSaldo()
        {
            return this.miDaoSaldo.TotalAnticiposSaldo();
        }

        public int TotalAnticiposSaldo(DateTime fecha)
        {
            return this.miDaoSaldo.TotalAnticiposSaldo(fecha);
        }

        public int TotalAnticiposSaldo(DateTime fecha, DateTime fecha2)
        {
            return this.miDaoSaldo.TotalAnticiposSaldo(fecha, fecha2);
        }

        public int TotalAnticiposSaldo(string nit, DateTime fecha)
        {
            return this.miDaoSaldo.TotalAnticiposSaldo(nit, fecha);
        }

        public int TotalAnticiposSaldo(string nit, DateTime fecha, DateTime fecha2)
        {
            return this.miDaoSaldo.TotalAnticiposSaldo(nit, fecha, fecha2);
        }


        public void AnularSaldo(int id)
        {
            this.miDaoSaldo.AnularSaldo(id);
        }
    }
}