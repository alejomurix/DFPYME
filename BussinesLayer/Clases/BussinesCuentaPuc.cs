using System;
using System.Data;
using DTO.Clases;
using DataAccessLayer.Clases;

namespace BussinesLayer.Clases
{
    public class BussinesCuentaPuc
    {
        private DaoCuentaPuc miDaoCuentaPuc;

        public BussinesCuentaPuc()
        {
            this.miDaoCuentaPuc = new DaoCuentaPuc();
        }

        public int IdSubCuenta(char[] codigo)
        {
            return miDaoCuentaPuc.IdSubCuenta(codigo);
        }

        public bool ValidarSubCuenta(char[] codigo)
        {
            return miDaoCuentaPuc.ValidarSubCuenta(codigo);
        }

        public void IngresarEgresoCuenta(ConceptoEgreso cuenta)
        {
            miDaoCuentaPuc.IngresarEgresoCuenta(cuenta);
        }

        public void EditarEgresoCuenta(ConceptoEgreso cuenta)
        {
            miDaoCuentaPuc.EditarEgresoCuenta(cuenta);
        }

        public void EliminarEgresoCuenta(int id)
        {
            miDaoCuentaPuc.EliminarEgresoCuenta(id);
        }
    }
}