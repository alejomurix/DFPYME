using System;
using DataAccessLayer.Clases;
using DTO.Clases;

namespace BussinesLayer.Clases
{
    public class BussinesConfiguracion
    {
        private DaoConfiguracion miDaoConfiguracion;

        public BussinesConfiguracion()
        {
            this.miDaoConfiguracion = new DaoConfiguracion();
        }

        public Configuracion Configuracion(int codigo)
        {
            return miDaoConfiguracion.Configuracion(codigo);
        }

        public void Editar(Configuracion configuracion)
        {
            miDaoConfiguracion.Editar(configuracion);
        }
    }
}