using System;
using System.Data;
using DataAccessLayer.Clases;
using DTO.Clases;

namespace BussinesLayer.Clases
{
    public class BussinesApertura
    {
        private DaoApertura miDaoApertura;

        public BussinesApertura()
        {
            this.miDaoApertura = new DaoApertura();
        }

        public int Ingresar(Apertura apertura)
        {
            return miDaoApertura.Ingresar(apertura);
        }

     /*   public long CountApertura(DateTime fecha, int idCaja, int idTurno)
        {
            return miDaoApertura.CountApertura(fecha, idCaja, idTurno);
        }*/

        public Apertura Apertura(int id)
        {
            return this.miDaoApertura.Apertura(id);
        }

        public Apertura Apertura(DateTime fecha, int idcaja)
        {
            return miDaoApertura.Apertura(fecha, idcaja);
        }

        public Apertura AperturaAnterior(DateTime fecha, int idcaja)
        {
            return miDaoApertura.AperturaAnterior(fecha, idcaja);
        }

        public Apertura Apertura(DateTime fecha, int idcaja, int idturno)
        {
            return miDaoApertura.Apertura(fecha, idcaja, idturno);
        }

        public DataTable Aperturas(int idCaja, int idTurno)
        {
            return this.miDaoApertura.Aperturas(idCaja, idTurno);
        }


        // Registros de apertura
        /// <summary>
        /// 
        /// </summary>
        /// <param name="numero">Número que representa el ID de la apertura.</param>
        /// <returns></returns>
        public int IngresarRegistroApertura(int idCaja, int numero)
        {
            return miDaoApertura.IngresarRegistroApertura(idCaja, numero);
        }

        public DataTable RegistrosApertura(int idCaja)
        {
            return miDaoApertura.RegistrosApertura(idCaja);
        }

        public Apertura RegistroApertura(int idCaja)
        {
            return miDaoApertura.RegistroApertura(idCaja);
        }

        public void EditarApertura(int id, int valor)
        {
            this.miDaoApertura.EditarApertura(id, valor);
        }

        public void EliminarRegistroApertura(int idCaja)
        {
            miDaoApertura.EliminarRegistroApertura(idCaja);
        }

        /*
        public Apertura Caja(int id)
        {
            return new Apertura();// miDaoApertura.Caja(id);
        }

        public DataTable Listado(int rowBase, int rowMax)
        {
            return miDaoApertura.Listado(rowBase, rowMax);
        }

        public long GetRowsListado()
        {
            return miDaoApertura.GetRowsListado();
        }

        public DataTable Listado(DateTime fecha, int rowBase, int rowMax)
        {
            return miDaoApertura.Listado(fecha, rowBase, rowMax);
        }

        public long GetRowsListado(DateTime fecha)
        {
            return miDaoApertura.GetRowsListado(fecha);
        }

        public void Edita(Apertura baseCaja)
        {
           // miDaoApertura.Edita(baseCaja);
        }

        public DataSet Print(int idCaja, DateTime fecha)
        {
            return new DataSet();// miDaoApertura.Print(idCaja, fecha);
        }
        */
    }
}