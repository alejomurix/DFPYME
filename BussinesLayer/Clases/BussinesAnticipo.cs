using System;
using System.Data;
using DTO.Clases;
using DataAccessLayer.Clases;

namespace BussinesLayer.Clases
{
    public class BussinesAnticipo
    {
        private DaoAnticipo miDaoAnticipo;

        public BussinesAnticipo()
        {
            this.miDaoAnticipo = new DaoAnticipo();
        }

        public void IngresarAnticipoTercero(Anticipo anticipo)
        {
            miDaoAnticipo.IngresarAnticipoTercero(anticipo);
        }

        public DataTable AnticiposATercero(int rowBase, int rowMax)
        {
            return miDaoAnticipo.AnticiposATercero(rowBase, rowMax);
        }

        public long GetRowsAnticiposATercero()
        {
            return miDaoAnticipo.GetRowsAnticiposATercero();
        }

        public DataTable AnticiposSaldo(int rowBase, int rowMax)
        {
            return this.miDaoAnticipo.AnticiposSaldo(rowBase, rowMax);
        }

        public long GetRowsAnticiposSaldo()
        {
            return this.miDaoAnticipo.GetRowsAnticiposSaldo();
        }

        public DataTable AnticiposATercero(DateTime fecha, int rowBase, int rowMax)
        {
            return miDaoAnticipo.AnticiposATercero(fecha, rowBase, rowMax);
        }

        public long GetRowsAnticiposATercero(DateTime fecha)
        {
            return miDaoAnticipo.GetRowsAnticiposATercero(fecha);
        }

        public DataTable AnticiposATercero(DateTime fecha, DateTime fecha2, int rowBase, int rowMax)
        {
            return miDaoAnticipo.AnticiposATercero(fecha, fecha2, rowBase, rowMax);
        }

        public long GetRowsAnticiposATercero(DateTime fecha, DateTime fecha2)
        {
            return miDaoAnticipo.GetRowsAnticiposATercero(fecha, fecha2);
        }


        public DataTable AnticiposATercero(int idTercero, DateTime fecha, int rowBase, int rowMax)
        {
            return miDaoAnticipo.AnticiposATercero(idTercero, fecha, rowBase, rowMax);
        }

        public long GetRowsAnticiposATercero(int idTercero, DateTime fecha)
        {
            return miDaoAnticipo.GetRowsAnticiposATercero(idTercero, fecha);
        }

        public DataTable AnticiposATercero
            (int idTercero, DateTime fecha, DateTime fecha2, int rowBase, int rowMax)
        {
            return miDaoAnticipo.AnticiposATercero
                (idTercero, fecha, fecha2, rowBase, rowMax);
        }

        public long GetRowsAnticiposATercero(int idTercero, DateTime fecha, DateTime fecha2)
        {
            return miDaoAnticipo.GetRowsAnticiposATercero(idTercero, fecha, fecha2);
        }

        public DataTable AnticiposATerceroCuenta
            (int idCuenta, DateTime fecha, int rowBase, int rowMax)
        {
            return miDaoAnticipo.AnticiposATerceroCuenta(idCuenta, fecha, rowBase, rowMax);
        }

        public long GetRowsAnticiposATerceroCuenta(int idTercero, DateTime fecha)
        {
            return miDaoAnticipo.GetRowsAnticiposATerceroCuenta(idTercero, fecha);
        }

        public DataTable AnticiposATerceroCuenta
            (int idCuenta, DateTime fecha, DateTime fecha2, int rowBase, int rowMax)
        {
            return miDaoAnticipo.AnticiposATerceroCuenta
                (idCuenta, fecha, fecha2, rowBase, rowMax);
        }

        public long GetRowsAnticiposATerceroCuenta(int idCuenta, DateTime fecha, DateTime fecha2)
        {
            return miDaoAnticipo.GetRowsAnticiposATerceroCuenta(idCuenta, fecha, fecha2);
        }


        public int SaldoAnticipos()
        {
            return this.miDaoAnticipo.SaldoAnticipos();
        }

        public int SaldoAnticipos(DateTime fecha)
        {
            return this.miDaoAnticipo.SaldoAnticipos(fecha);
        }

        public int SaldoAnticipos(DateTime fecha, DateTime fecha2)
        {
            return this.miDaoAnticipo.SaldoAnticipos(fecha, fecha2);
        }

        public int SaldoAnticipos(int idTercero, DateTime fecha)
        {
            return this.miDaoAnticipo.SaldoAnticipos(idTercero, fecha);
        }

        public int SaldoAnticipos(int idTercero, DateTime fecha, DateTime fecha2)
        {
            return this.miDaoAnticipo.SaldoAnticipos(idTercero, fecha, fecha2);
        }



        /// <summary>
        /// Consulta los prestamos/anticipos de un Tercero y que aun no se han saldado.
        /// </summary>
        /// <param name="idCuenta">Id de la cuenta a consultar.</param>
        /// <param name="idTercero">Id del tercero a consultar.</param>
        /// <returns></returns>
        public DataTable AnticiposATerceroNoPagos(int idCuenta, int idTercero)
        {
            return miDaoAnticipo.AnticiposATerceroNoPagos(idCuenta, idTercero);
        }

        public DataTable AnticiposATerceroNoPagos(string nit)
        {
            return this.miDaoAnticipo.AnticiposATerceroNoPagos(nit);
        }

        // Funciones para la impresion del informe
        public DataTable AnticiposATercero()
        {
            return miDaoAnticipo.AnticiposATercero();
        }

        public DataTable AnticiposATercero(bool abonoMasCruce)
        {
            return miDaoAnticipo.AnticiposATercero(abonoMasCruce);
        }
        //
        public DataTable AnticiposATercero(DateTime fecha, bool abonoMasCruce)
        {
            return miDaoAnticipo.AnticiposATercero(fecha, abonoMasCruce);
        }

        public DataTable AnticiposATercero(DateTime fecha, DateTime fecha2, bool abonoMasCruce)
        {
            return miDaoAnticipo.AnticiposATercero(fecha, fecha2, abonoMasCruce);
        }

        public DataTable AnticiposATercero_(int idTercero, DateTime fecha, bool abonoMasCruce)
        {
            return miDaoAnticipo.AnticiposATercero_(idTercero, fecha, abonoMasCruce);
        }

        public DataTable AnticiposATercero_(int idTercero, DateTime fecha, DateTime fecha2, bool abonoMasCruce)
        {
            return miDaoAnticipo.AnticiposATercero_(idTercero, fecha, fecha2, abonoMasCruce);
        }

        public DataTable AnticiposATercero(int idCuenta, DateTime fecha, bool abonoMasCruce)
        {
            return miDaoAnticipo.AnticiposATercero(idCuenta, fecha, abonoMasCruce);
        }

        public DataTable AnticiposATercero
            (int idCuenta, DateTime fecha, DateTime fecha2, bool abonoMasCruce)
        {
            return miDaoAnticipo.AnticiposATercero(idCuenta, fecha, fecha2, abonoMasCruce);
        }

        public void AnularAnticipo(int idAnticipo)
        {
            miDaoAnticipo.AnularAnticipo(idAnticipo);
        }


        // Formas de Pago de Préstamos y Anticipos.
        public DataTable PagosAnticiposTercero(int idAnticipo)
        {
            return miDaoAnticipo.PagosAnticiposTercero(idAnticipo);
        }

        // Pagos de Préstamos y Anticipo.
        public int IngresarPagoAnticipo(PagoAnticipo pago)
        {
            return miDaoAnticipo.IngresarPagoAnticipo(pago);
        }

        public void IngresarCruceAnticipo(int idCuenta, int idTercero, CruceCuentaPagar cruce)
        {
            miDaoAnticipo.IngresarCruceAnticipo(idCuenta, idTercero, cruce);
        }

        public void IngresarCruceAnticipo(string nit, CruceCuentaPagar cruce)
        {
            this.miDaoAnticipo.IngresarCruceAnticipo(nit, cruce);
        }

        public DataTable PagosAnticipo(int idAnticipo)
        {
            return miDaoAnticipo.PagosAnticipo(idAnticipo);
        }
    }
}