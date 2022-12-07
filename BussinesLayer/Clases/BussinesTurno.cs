using System;
using System.Data;
using DataAccessLayer.Clases;
using DTO.Clases;

namespace BussinesLayer.Clases
{
    public class BussinesTurno
    {
        private DaoTurno miDaoTurno;

        public BussinesTurno()
        {
            this.miDaoTurno = new DaoTurno();
        }

        public void Ingresar(Turno turno)
        {
            miDaoTurno.Ingresar(turno);
        }

        public Turno TurnoId(int id)
        {
            return miDaoTurno.TurnoId(id);
        }

        public Turno Turno(int numero)
        {
            return miDaoTurno.Turno(numero);
        }

        public DataTable Turnos()
        {
            return miDaoTurno.Turnos();
        }

        // FechaTurno
        public void IngresarFechaTurno(DateTime fecha, int idCaja, int idTurno)
        {
            miDaoTurno.IngresarFechaTurno(fecha, idCaja, idTurno);
        }

        public DataTable FechasTurno(DateTime fecha)
        {
            return miDaoTurno.FechasTurno(fecha);
        }
    }
}