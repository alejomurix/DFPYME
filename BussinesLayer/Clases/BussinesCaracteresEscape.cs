using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DTO.Clases;
using DataAccessLayer.Clases;

namespace BussinesLayer.Clases
{
    public class BussinesCaracteresEscape
    {
        private DaoCaracteresEscape miDaoCaracteresEscape;

        public BussinesCaracteresEscape()
        {
            this.miDaoCaracteresEscape = new DaoCaracteresEscape();
        }

        public CaracteresEscape CaracteresPredeterminados()
        {
            return this.miDaoCaracteresEscape.CaracteresPredeterminados();
        }
    }
}