using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DTO.Clases;
using DataAccessLayer.Clases;

namespace BussinesLayer.Clases
{
    public class BussinesPlantilla
    {
        private DaoPlantilla miDaoPlantilla;

        public BussinesPlantilla()
        {
            this.miDaoPlantilla = new DaoPlantilla();
        }

        public void IngresarPlantilla(Plantilla plantilla)
        {
            miDaoPlantilla.IngresarPlantilla(plantilla);
        }

        public DataTable Plantillas()
        {
            return miDaoPlantilla.Plantillas();
        }
    }
}