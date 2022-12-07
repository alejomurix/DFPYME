using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccessLayer.Clases;

namespace BussinesLayer.Clases
{
    public class BussinesConsecutivo
    {
        private DaoConsecutivo miDaoConsecutivo;

        public BussinesConsecutivo()
        {
            this.miDaoConsecutivo = new DaoConsecutivo();
        }

        public string Consecutivo(string nombre)
        {
            return miDaoConsecutivo.Consecutivo(nombre);
        }

        public void ActualizarConsecutivo(string nombre)
        {
            miDaoConsecutivo.ActualizarConsecutivo(nombre);
        }
    }
}