using System;
using System.Data;
using DataAccessLayer.Clases;
using DTO.Clases;

namespace BussinesLayer.Clases
{
    public class BussinesCierre
    {
        private DaoCierre miDaoCierre;

        public BussinesCierre()
        {
            this.miDaoCierre = new DaoCierre();
        }

        public void Ingresar(Cierre cierre)
        {
            miDaoCierre.Ingresar(cierre);
        }

        public void IngresarValor(FormaPago valor)
        {
            this.miDaoCierre.IngresarValor(valor);
        }

        public Cierre Cierre(int idApertura)
        {
            return miDaoCierre.Cierre(idApertura);
        }

        public int TotalCierre(int idApertura)
        {
            return miDaoCierre.TotalCierre(idApertura);
        }

        public DataTable Tcierres(int idApertura)
        {
            return this.miDaoCierre.Tcierres(idApertura);
        }

        public DataTable Print(DateTime fecha, int idCaja, int idTurno)
        {
            return miDaoCierre.Print(fecha, idCaja, idTurno);
        }

        public DataTable Print(int idApertura)
        {
            return miDaoCierre.Print(idApertura);
        }


        public void EliminarPagosCierre(int idCierre)
        {
            this.miDaoCierre.EliminarPagosCierre(idCierre);
        }

       /* public void EditarPagosCierre(int id, int valor)
        {
            this.miDaoCierre.EditarPagosCierre(id, valor);
        }*/
    }
}