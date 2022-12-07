using System;
using DTO.Clases;
using DataAccessLayer.Clases;

namespace BussinesLayer.Clases
{
    public class BussinesSistema
    {
        private DaoSistema miDaoSistema;

        public BussinesSistema()
        {
            this.miDaoSistema = new DaoSistema();
        }

        public Sistema Sistema()
        {
            return miDaoSistema.Sistema();
        }
    }
}