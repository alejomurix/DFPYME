using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccessLayer.Clases;
using DTO.Clases;

namespace BussinesLayer.Clases
{
    public class BussinesAplicaDescuento
    {
        private DaoAplicaDescuento miDaoDescuento;

        public BussinesAplicaDescuento()
        {
            this.miDaoDescuento = new DaoAplicaDescuento();
        }

        public DataTable Descuentos(int idGrupo)
        {
            return miDaoDescuento.Descuentos(idGrupo);
        }

        public int Ingresar(AplicaDescuento descuento)
        {
            return miDaoDescuento.Ingresar(descuento);
        }
    }
}