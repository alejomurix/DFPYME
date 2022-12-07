using System;
using System.Collections;
using DTO.Clases;
using DataAccessLayer.Clases;

namespace BussinesLayer.Clases
{
    public class BussinesCiudad
    {
        private DaoCiudad miDaoCiudad = new DaoCiudad();

        public ArrayList ListaCiudadPorDepartamento(int idDepartamento)
        {
            return miDaoCiudad.ListaCiudadPorDepartamento(idDepartamento);
        }
    }
}