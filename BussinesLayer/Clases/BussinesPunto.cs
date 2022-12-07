using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DTO.Clases;
using DataAccessLayer.Clases;

namespace BussinesLayer.Clases
{
    public class BussinesPunto
    {
        private DaoPunto miDaoPunto;

        public BussinesPunto()
        {
            this.miDaoPunto = new DaoPunto();
        }

        public Punto CargarPunto()
        {
            return miDaoPunto.CargaPunto();
        }

        public void ModificaPunto(Punto punto)
        {
            this.miDaoPunto.ModificaPunto(punto);
        }
    }
}