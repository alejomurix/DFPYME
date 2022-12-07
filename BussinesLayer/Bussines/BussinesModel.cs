using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DTO;
using DTO.Clases;
using DataAccessLayer.Repository;
using DataAccessLayer.Models;

namespace BussinesLayer.Bussines
{
    public class BussinesModel
    {
        private RepositoryModel repositoryModel;

        public BussinesModel()
        {
            this.repositoryModel = new RepositoryModel();
        }

        public DataTable Departamentos()
        {
            return this.repositoryModel.Departamentos();
        }

        public DataTable Cities(string codeDepto)
        {
            return this.repositoryModel.Cities(codeDepto);
        }

        public DataTable CodePostales()
        {
            return this.repositoryModel.CodePostales();
        }

        public City GetCityByCustomer(string nit)
        {
            return this.repositoryModel.GetCityByCustomer(nit);
        }


        public bool ExistsCustomer(string nit)
        {
            return this.repositoryModel.ExistsCustomer(nit);
        }

        public void AddCustomer(Customer customer)
        {
            this.repositoryModel.AddCustomer(customer);
        }
    }
}