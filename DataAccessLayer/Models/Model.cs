using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccessLayer.DataSets;

namespace DataAccessLayer.Models
{
    public class EnvironmentDE 
    {
        public string UBL { set; get; }

        public string DIAN { set; get; }

        public string Target { set; get; } 
    }

    public class IEntity
    {
        public int ID { set; get; }

        public string Code { set; get; }

        public string Name { set; get; }
    }

    public class Country : IEntity
    {
        public Country()
        {
            Code = "CO";
            Name = "COLOMBIA";
        }
    }

    public class Departament : IEntity
    {
        public Country Country
        {
            private set { }

            get { return new Country(); }
        }
    }

    public class City : IEntity
    {
        public string CodePostal { set; get; }

        public Departament Departament { set; get; }

        public City()
        {
            this.CodePostal = "";
        }
    }

    public class ResponsabilityFiscal : IEntity 
    {
        public string Descripcion { set; get; }
    }

    /// <summary>
    /// Impuestos registrados en la Factura Electrónica
    /// </summary>
    public class IdentifyTax : IEntity 
    {
        public string Descripcion { set; get; }

        public bool IsTax { get; set; }

        public bool Percent { get; set; }

        public bool Estate { get; set; }

        public string GetIsTax
        {
            get
            {
                if (this.IsTax)
                {
                    return "true";
                }
                else
                {
                    return "false";
                }
            }
        }
    }



    public class Contact
    {
        public int IDType { set; get; } // 1 Persona; 2 Despacho; 3 Contab; 4 Ventas

        public string Name { set; get; }

        public string Phone { set; get; }

        public string Email { set; get; }

        public Contact()
        {
            this.IDType = 1;
        }
    }

    public class ThirdParties // Terceros
    {
        public string TypePerson { set; get; } // 1: Juridica, 2: Natural

        public int TypeIdentify { set; get; } // 31: NIT, 13: Cedula Ciudadania

        public string NIT { set; get; }

        public int DV { set; get; }

        public int Regimen { set; get; } // 48: Responsable IVA,  49: No Responsable IVA

        public string RazonSocial { set; get; }

        public string Comercial { set; get; }

        public City City { set; get; }

        public string Direccion { set; get; }

        public string InfoTributary { set; get; }

        public string CIIU { set; get; }

        public string Matricula { set; get; } //Número de matrícula mercantil (Identificador de sucursal: Punto de facturación)

        public Contact Contact { set; get; }

        public List<IdentifyTax> IdentifyTaxes { set; get; }

        public List<ResponsabilityFiscal> ResponsabilitiesRUT { set; get; }
    }

    public class Emisor : ThirdParties { }

    public class Customer : ThirdParties 
    {
        public int TypeSales { set; get; }

        public int ComercialClasification { set; get; }
    }



    public class CredentialWebService
    {
        public bool Productive { set; get; }

        public string User { set; get; }

        public string Password { set; get; }
    }

    public class NumberResolution
    {
        public int Id { set; get; }

        public string Number { set; get; }

        public DateTime DateBegin { set; get; }

        public int Vigency { set; get; }

        public DateTime DateEnd { set; get; }

        public string Prefijo { set; get; }

        public int NumberBegin { set; get; }

        public int NumberEnd { set; get; }

        public int Consecutive { set; get; }
    }

    public class ElectronicDocument
    {
        public int ID { set; get; }

        public string NitCliente { set; get; }

        public bool Estado { set; get; }

        public string Tipo { set; get; }

        public string TipoFactura { set; get; }

        public string TipoOperacion { set; get; }

        public string TipoAmbiente { set; get; }

        public int IdStatus { set; get; }

        public string Status { set; get; }

        public string Numero { set; get; }

        public DateTime Fecha { set; get; }

        public DateTime FechaLimite { set; get; }

        public int NoItems { set; get; }

        public string Moneda { set; get; }

        public int IdResolucion { set; get; }

        public int MetodoPago { set; get; }

        public string MetPago { set; get; }

        public string MedioPago { set; get; }

        public DateTime FechaPago { set; get; }

        public string VUBL { set; get; }

        public string VDIAN { set; get; }

        public double Total { set; get; }

        public double Neto { set; get; }

        public string Estate
        {
            get
            {
                if (this.Estado)
                {
                    return "DOC. ELEC.";
                }
                else
                {
                    return "TEMP";
                }
            }
        }

        public string TransaccionID { set; get; }

        public CompanyModel Company { set; get; }

        //public Customer Customer { set; get; }

        public CustomerModel Customer { set; get; }

        public string NameCustomer { set; get; }


        ///public NumberResolution Resolution { set; get; }

        public DataBaseDS.resolucion_electronicaRow Resolution { set; get; }

        //public Payment MetPayment { set; get; }

        public List<Item> Items { set; get; }

        public List<Tax> Retentions { set; get; }

        public double Payment { set; get; }

        public bool Cancelled { set; get; }

        public int IdCaja { set; get; }


        public CredentialWebService Credential { set; get; }



        public ElectronicDocument()
        {
            this.ID = 0;
            this.Numero = "";
            this.NitCliente = "";
            this.Estado = false;
            this.IdStatus = 1;
            this.Status = "";

            this.FechaLimite = this.FechaPago = this.Fecha = DateTime.Now;
            this.NoItems = 0;

            this.IdResolucion = 0;

            this.Items = new List<Item>();
            this.Retentions = new List<Tax>();
            this.Total = 0;
            this.Neto = 0;
        }

        public bool ValideBaseTaxRetentions(string CodeReteIVA)
        {
            bool valide = true;
            foreach (Tax tax in this.Retentions)
            {
                if (tax.ID.Equals(CodeReteIVA))
                {
                    if (!tax.Base.Equals(
                        Math.Round(this.Items.Sum(s => ((s.UnitPrice * s.Quantity) * s.IVA / 100)), 2)))
                    {
                        valide = false;
                        break;
                    }
                }
                else
                {
                    if(!tax.Base.Equals(this.Items.Sum(s => s.SubTotal)))
                    {
                        valide = false;
                        break;
                    }
                }
            }
            return valide;
        }
    }

    public class Item
    {
        public int ID { set; get; }

        public int IDDE { set; get; }

        public int Numero { set; get; }

        public string Code { set; get; }

        public string UnitMedida { set; get; }

        public string Description { set; get; }

        public double Quantity { set; get; }

        public double Costo { set; get; }

        public double IVA { set; get; }

        public double IC { set; get; } // impuesto deptal al consumo

        public double INC { set; get; } // impuesto al consumo(venta)   

        public double Retention { set; get; }

        public double UnitPrice { set; get; }

        public double SubTotal { set; get; }

        public double Neto { set; get; }

        public double Total { set; get; }

        public double Price2 { set; get; }

        public double Price3 { set; get; }

        public double Price4 { set; get; }




        //public decimal VBase { set; get; }

        //public decimal Total_ { set; get; }

        public TypeStandar TypeStandar { set; get; }

        //public Discount Discount { set; get; }

        public List<Tax> Taxes { set; get; }

        //public TotalTax TotalTax { set; get; }

        public Item()
        {
            this.TypeStandar = new TypeStandar();
            this.Taxes = new List<Tax>();
        }
    }

    public class TypeStandar
    {
        public string CodeItem { set; get; }

        public string CodeStandard { set; get; }
    }

    public class Percent
    {
        public bool State { set; get; }

        public string ID { set; get; }

        public double Base { set; get; }

        public double Tarifa { set; get; }

        public double Value { set; get; }

        public bool Nominal { set; get; }

        public double Quantity { set; get; }

        public string UnitMedida { set; get; }
    }

    public class Timbre
    {
        public bool State { set; get; }

        public decimal Value { set; get; }

        public List<Tax> Taxes { set; get; }
    }

    public class Discount : Percent { }

    public class Tax : Percent 
    {
        public int IDI { set; get; }

        public int IDItem { set; get; }

        public string Description { set; get; }

        public Tax()
        {
            this.IDI = 0;
            this.UnitMedida = "";
            this.Description = "";
        }
    }

    public class ElectronicPayment
    {
        public int Id { set; get; }

        public int IdDE { set; get; }

        public int IdCaja { set; get; }

        public int IdUser { set; get; }

        public DateTime Date { set; get; }

        public double Total { set; get; }

        public double Change { set; get; }

        public List<Payment> Payments { set; get; }

        public ElectronicPayment()
        {
            this.Payments = new List<Payment>();
        }
    }

    public class Payment
    {
        /// <summary>
        /// Código correspondiente al medio de pago.
        /// </summary>
        public string Code { set; get; }

        /// <summary>
        /// valor del monto pagado equivalente al valor de la factura.
        /// </summary>
        public double Valor { set; get; }

        /// <summary>
        /// Monto del medio de pago utilizado.
        /// </summary>
        public double Pago { set; get; }
    }

    //public class TotalTax : Timbre { }

    /*public class Payment
    {
        public string CodMeans { set; get; }

        public int IDMethod { set; get; }

        public string Date { set; get; }
    }*/

}