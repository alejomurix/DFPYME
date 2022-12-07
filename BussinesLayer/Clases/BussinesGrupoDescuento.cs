using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccessLayer.Clases;
using DTO.Clases;

namespace BussinesLayer.Clases
{
    public class BussinesGrupoDescuento
    {
        private DaoGrupoDescuento miDaoGrupo;

        public BussinesGrupoDescuento()
        {
            this.miDaoGrupo = new DaoGrupoDescuento();
        }

        public void Ingresar(GrupoDescuento grupo)
        {
            miDaoGrupo.Ingresar(grupo);
        }

        public DataTable Grupos()
        {
            return miDaoGrupo.Grupos();
        }
    }
}