using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccessLayer.DataSets;
using DTO;

namespace DataAccessLayer.Models
{
    public class CustomerModel
    {
        public string Document { set; get; }

        public DataBaseDS.clienteDataTable Customer { set; get; }

        public City City { set; get; }

        public DataBaseDS.details_tributary_clientDataTable DetailsTributary { set; get; }

        public DataBaseDS.details_rut_clientDataTable DetailsRUT { set; get; }

        public DataBaseDS.clienteRow Cliente { set; get; }

        public CustomerModel()
        {
            this.Document = "";
            this.Customer = new DataBaseDS.clienteDataTable();
            this.City = new City();
            this.DetailsTributary = new DataBaseDS.details_tributary_clientDataTable();
            this.DetailsRUT = new DataBaseDS.details_rut_clientDataTable();
        }
    }

    public class CompanyModel
    {
        public string NoIdentify { set; get; }

        public DataBaseDS.empresaRow Company { set; get; }

        public City City { set; get; }

        public DataBaseDS.details_tributary_empresaDataTable DetailsTributary { set; get; }

        public DataBaseDS.details_rut_empresaDataTable DetailsRUT { set; get; }

        public DataBaseDS.empresa_ciiuDataTable DetailsCIIU { set; get; }

        public CompanyModel()
        {
            this.City = new City();
            this.DetailsTributary = new DataBaseDS.details_tributary_empresaDataTable();
            this.DetailsRUT = new DataBaseDS.details_rut_empresaDataTable();
            this.DetailsCIIU = new DataBaseDS.empresa_ciiuDataTable();
        }
    }

    /*
    public class DocumentEModel
    {
        public DataBaseDS.documento_electronicoDataTable Document { set; get; }

        public DataBaseDS.item_documento_electronicoDataTable ItemDocument { set; get; }

        public DataBaseDS.item_impuestoDataTable ItemImpuesto { set; get; }


        public DataBaseDS.item_documento_electronicoRow Item { set; get; }

        public DocumentEModel()
        {
            this.Document = new DataBaseDS.documento_electronicoDataTable();
            this.ItemDocument = new DataBaseDS.item_documento_electronicoDataTable();
        }
    }
    */
}
