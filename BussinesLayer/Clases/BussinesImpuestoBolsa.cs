using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccessLayer.Clases;
using DTO.Clases;

namespace BussinesLayer.Clases
{
    public class BussinesImpuestoBolsa
    {
        private DaoImpuestoBolsa miDaoImpuestoBolsa;

        public BussinesImpuestoBolsa()
        {
            this.miDaoImpuestoBolsa = new DaoImpuestoBolsa();
        }

        public ImpuestoBolsa ImpuestoBolsa(int id)
        {
            return this.miDaoImpuestoBolsa.ImpuestoBolsa(id);
        }

        public ImpuestoBolsa ImpuestoBolsaDeVenta(int idFactura)
        {
            return this.miDaoImpuestoBolsa.ImpuestoBolsaDeVenta(idFactura);
        }

        // caja y fecha
        public ImpuestoBolsa ImpuestoBolsaDeVenta(int idCaja, DateTime fecha)
        {
            return this.miDaoImpuestoBolsa.ImpuestoBolsaDeVenta(idCaja, fecha);
        }

        // fecha
        public ImpuestoBolsa ImpuestoBolsaDeVenta(DateTime fecha)
        {
            return this.miDaoImpuestoBolsa.ImpuestoBolsaDeVenta(fecha);
        }

        public ImpuestoBolsa ImpuestoBolsaDeVenta(DateTime fecha, DateTime fecha2)
        {
            return this.miDaoImpuestoBolsa.ImpuestoBolsaDeVenta(fecha, fecha2);
        }
    }
}