using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccessLayer.Clases;
using System.Collections;

namespace BussinesLayer.Clases
{
    public class Bussines_Unidad_Medida
    {
        private Dao_Unidad_Medida miDaoUnidad = new Dao_Unidad_Medida();

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public ArrayList ListadoUnidadMedida()
        {
            return miDaoUnidad.ListadoUnidadMedida();
        }


    }
}
