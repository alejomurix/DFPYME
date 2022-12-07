using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DTO.Clases;
using DataAccessLayer.Clases;
using System.Data;

namespace BussinesLayer.Clases
{
     public  class BussinesTipoSorteo
    {
        private DaoTipoSorteo miDaotipoSorteo = new DaoTipoSorteo();

        public DataTable ListaTipoSorteo()
        {
            return miDaotipoSorteo.ListaTipoSorteo();
        }

        public DataTable ListaTipoPromocion()
        {
            return miDaotipoSorteo.ListaTipoPromocion();
        }
    }
}
