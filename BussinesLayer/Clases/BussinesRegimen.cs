using System;
using System.Collections;
using DataAccessLayer.Clases;
using DTO.Clases;

namespace BussinesLayer.Clases
{
    public class BussinesRegimen
    {
        private DaoRegimen miDaoRegimen;

        /// <summary>
        /// evuelve un arrayList con el listado de los regimen
        /// </summary>
        /// <returns></returns>
        public ArrayList ListadoRegimen()
        {
            miDaoRegimen = new DaoRegimen();
            return miDaoRegimen.ListadoRegimen();
        }
    }
}