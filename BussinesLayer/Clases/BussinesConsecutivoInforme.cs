using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccessLayer.Clases;

namespace BussinesLayer.Clases
{
    public class BussinesConsecutivoInforme
    {
        private DaoConsecutivoInforme miDaoInforme;

        public BussinesConsecutivoInforme()
        {
            miDaoInforme = new DaoConsecutivoInforme();
        }

        public long Count(int idCaja)
        {
            return miDaoInforme.Count(idCaja);
        }

        public DateTime MaxFecha(int idCaja)
        {
            return miDaoInforme.MaxFecha(idCaja);
        }

        public DataTable ConsultarRegistro(DateTime fecha, int idCaja)
        {
            return miDaoInforme.ConsultarRegistro(fecha, idCaja);
        }

        public long IngresarRegistro(DateTime fecha, int idCaja, int numero)
        {
            return miDaoInforme.IngresarRegistro(fecha, idCaja, numero);
        }

        // Consecutivo General
        public long CountGeneral()
        {
            return miDaoInforme.CountGeneral();
        }

        public DateTime MaxFechaGeneral()
        {
            return miDaoInforme.MaxFechaGeneral();
        }

        public DataTable ConsultarRegistroGeneral(DateTime fecha)
        {
            return miDaoInforme.ConsultarRegistroGeneral(fecha);
        }

        public long IngresarRegistroGeneral(DateTime fecha, int numero)
        {
            return miDaoInforme.IngresarRegistroGeneral(fecha,  numero);
        }
    }
}