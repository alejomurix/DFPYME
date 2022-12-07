using System;
using System.Collections;
using DTO.Clases;
using DataAccessLayer.Clases;

namespace BussinesLayer.Clases
{
    public class BussinesDepartamento
    {
        private DaoDepartamento miDaoDepartamento = new DaoDepartamento();

        public ArrayList ListadoDepartamentos()
        {
            return miDaoDepartamento.ListadoDepartamentos();
        }
    }
}