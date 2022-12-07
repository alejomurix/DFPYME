using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using DataAccessLayer.Clases;

namespace BussinesLayer.Clases
{
    public class BussinesTipoDocumento
    {
        private DaoTipoDocumento miDaoTipoDocumento;

        public BussinesTipoDocumento()
        {
            this.miDaoTipoDocumento = new DaoTipoDocumento();
        }

        public DataTable Lista()
        {
            return miDaoTipoDocumento.Lista();
        }
    }
}