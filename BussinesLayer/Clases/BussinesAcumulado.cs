using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccessLayer.Clases;

namespace BussinesLayer.Clases
{
    public class BussinesAcumulado
    {
        private DaoAcumulado miDaoAcumulado;

        public BussinesAcumulado()
        {
            this.miDaoAcumulado = new DaoAcumulado();
        }

        public void Ingresar(DateTime fecha, int valor)
        {
            miDaoAcumulado.Ingresar(fecha, valor);
        }

        public long CountAcumulado()
        {
            return miDaoAcumulado.CountAcumulado();
        }

        public DataTable Acumulados(DateTime fecha)
        {
            return miDaoAcumulado.Acumulados(fecha);
        }

        public DateTime MaxFecha()
        {
            return miDaoAcumulado.MaxFecha();
        }

        // ACUMULADO POR CAJA
        public void IngresarCaja(DateTime fecha, int idCaja, int valor)
        {
            miDaoAcumulado.IngresarCaja(fecha, idCaja, valor);
        }

        public long CountAcumuladoCaja(int idCaja)
        {
            return miDaoAcumulado.CountAcumuladoCaja(idCaja);
        }

        public DataTable AcumuladosCaja(DateTime fecha, int idCaja)
        {
            return miDaoAcumulado.AcumuladosCaja(fecha, idCaja);
        }

        public DateTime MaxFechaCaja(int idCaja)
        {
            return miDaoAcumulado.MaxFechaCaja(idCaja);
        }
    }
}