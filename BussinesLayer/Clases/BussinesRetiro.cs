using System;
using System.Data;
using DataAccessLayer.Clases;
using DTO.Clases;

namespace BussinesLayer.Clases
{
    public class BussinesRetiro
    {
        private DaoRetiro miDaoRetiro;

        public BussinesRetiro()
        {
            this.miDaoRetiro = new DaoRetiro();
        }

        public int Ingresar(Retiro retiro)
        {
            return miDaoRetiro.Ingresar(retiro);
        }

        public DataTable Retiros(DateTime fecha, int idcaja, int idturno)
        {
            return miDaoRetiro.Retiros(fecha, idcaja, idturno);
        }

        public DataTable Retiros(DateTime fecha, DateTime fecha2, int idcaja, int idturno)
        {
            return miDaoRetiro.Retiros(fecha, fecha2, idcaja, idturno);
        }

        public DataTable Retiros(DateTime fecha, int idcaja)  // print_retiros
        {
            return miDaoRetiro.Retiros(fecha, idcaja);
        }

        public DataTable RetirosHoras(DateTime fecha, DateTime fecha2, int idcaja, int idturno)
        {
            return miDaoRetiro.RetirosHoras(fecha, fecha2, idcaja, idturno);
        }

        public DataTable PagosRetiro(int idRetiro)
        {
            return miDaoRetiro.PagosRetiro(idRetiro);
        }

        public DataTable PrintRetiros(DateTime fecha, int idCaja, int idTurno)
        {
            return miDaoRetiro.PrintRetiros(fecha, idCaja, idTurno);
        }

        public DataTable PrintRetiros(DateTime fecha, DateTime fecha2, int idCaja, int idTurno)
        {
            return miDaoRetiro.PrintRetiros(fecha, fecha2, idCaja, idTurno);
        }

        public DataTable PrintRetirosHoras(DateTime fecha, DateTime fecha2, int idCaja, int idTurno)
        {
            return miDaoRetiro.PrintRetirosHoras(fecha, fecha2, idCaja, idTurno);
        }

        public void EditarRetiro(int id, int valor)
        {
            this.miDaoRetiro.EditarRetiro(id, valor);
        }
    }
}