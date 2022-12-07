using System;
using System.Collections.Generic;
using System.Data;
using DataAccessLayer.Clases;
using DTO.Clases;

namespace BussinesLayer.Clases
{
    public class BussinesBeneficio
    {
        private DaoBeneficio miDaoBeneficio;

        public BussinesBeneficio()
        {
            this.miDaoBeneficio = new DaoBeneficio();
        }

        public void Ingresar(Cliente beneficio)
        {
            miDaoBeneficio.Ingresar(beneficio);
        }

        public bool Existe(string nit)
        {
            return miDaoBeneficio.Existe(nit);
        }

        public Cliente BeneficiarioId(int id)
        {
            return miDaoBeneficio.BeneficiarioId(id);
        }

        public Cliente BeneficiarioNit(string nit)
        {
            return miDaoBeneficio.BeneficiarioNit(nit);
        }

        public DataTable BeneficiariosNit(string nit)
        {
            return miDaoBeneficio.BeneficiariosNit(nit);
        }

        public DataTable BeneficiariosNombre(string nombre)
        {
            return miDaoBeneficio.BeneficiariosNombre(nombre);
        }

        public DataTable BeneficiariosT(string criterio)
        {
            return this.miDaoBeneficio.BeneficiariosT(criterio);
        }

        public List<Cliente> Beneficiarios(string criterio)
        {
            return this.miDaoBeneficio.Beneficiarios(criterio);
        }

        public void EditarBeneficiario(Cliente beneficiario)
        {
            miDaoBeneficio.EditarBeneficiario(beneficiario);
        }
    }
}