using System;
using System.Data;
using DataAccessLayer.Clases;
using DTO.Clases;

namespace BussinesLayer.Clases
{
    public class BussinesBonoRifa
    {
        private DaoBonoRifa miDaoBonoRifa;

        public BussinesBonoRifa()
        {
            this.miDaoBonoRifa = new DaoBonoRifa();
        }

        public void Ingresar(Bono bono)
        {
            this.miDaoBonoRifa.Ingresar(bono);
        }

        public DataTable BonosRifa()
        {
            return this.miDaoBonoRifa.BonosRifa();
        }

        public void EditarEstado(bool estado)
        {
            this.miDaoBonoRifa.EditarEstado(estado);
        }

        public Bono BonoRifa()
        {
            return this.miDaoBonoRifa.BonoRifa();
        }

        public void Eliminar(int id)
        {
            this.miDaoBonoRifa.Eliminar(id);
        }



        public void IngresarMarcaDeBono(int idSorteo, int idMarca)
        {
            this.miDaoBonoRifa.IngresarMarcaDeBono(idSorteo, idMarca);
        }

        public DataTable MarcasDeBono(int idBono)
        {
            return this.miDaoBonoRifa.MarcasDeBono(idBono);
        }

        public void EliminarMarcaDeBono(int id)
        {
            this.miDaoBonoRifa.EliminarMarcaDeBono(id);
        }
    }
}