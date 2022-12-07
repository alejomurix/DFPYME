using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccessLayer.Clases;
using DTO.Clases;

namespace BussinesLayer.Clases
{
    public class BussinesComprobanteCruce
    {
        private DaoComprobanteCruce miDaoCruce;

        public BussinesComprobanteCruce()
        {
            this.miDaoCruce = new DaoComprobanteCruce();
        }

        public long Ingresar(ComprobanteCruce cruce)
        {
            return miDaoCruce.Ingresar(cruce);
        }

        public long IngresarReciboRetiro(ComprobanteCruce cruce)
        {
            return miDaoCruce.IngresarReciboRetiro(cruce);
        }
    }
}