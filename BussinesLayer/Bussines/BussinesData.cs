using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using DataAccessLayer.Repository;
using DTO;
using DataAccessLayer.Models;

namespace BussinesLayer.Bussines
{
    public class BussinesData
    {
        public RepositoryDataFiscal repositoryData;

        public BussinesData()
        {
            this.repositoryData = new RepositoryDataFiscal();
        }

        public DataTable TypesPerson()
        {
            return this.repositoryData.TypesPerson();
        }

        public DataTable IdDocuments()
        {
            return this.repositoryData.IdDocuments();
        }

        public DataTable FiscalRegimen()
        {
            return this.repositoryData.FiscalRegimen();
        }

        public DataTable InfoTributary()
        {
            return this.repositoryData.InfoTributary();
        }

        public List<IdentifyTax> IdentifyTaxes()
        {
            return this.repositoryData.IdentifyTaxes();
        }
    }
}