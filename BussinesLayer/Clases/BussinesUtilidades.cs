using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccessLayer.Clases;
using DTO.Clases;

namespace BussinesLayer.Clases
{
    public class BussinesUtilidades
    {
        private DaoUtilidades miDaoUtilidades;

        public BussinesUtilidades()
        {
            this.miDaoUtilidades = new DaoUtilidades();
        }

        public List<InventarioFisico> InventariosFisico(string dataBase, DateTime fecha)
        {
            return this.miDaoUtilidades.InventariosFisico(dataBase, fecha);
        }

        public void ActualizarInventarioFisico(List<InventarioFisico> inventarios, string dataBase)
        {
            this.miDaoUtilidades.ActualizarInventarioFisico(inventarios, dataBase);
        }
    }
}