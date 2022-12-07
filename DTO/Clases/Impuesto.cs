using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DTO.Clases
{
    public class Impuesto
    {
        public int Id { set; get; }

        public string Numero { set; get; }

        public int PayMethod { set; get; }

        public string Tarifa { set; get; }

        public string Concepto { set; get; }

        private double tax;

        public double Tax 
        { 
            set 
            { 
                tax = value; 
                Tarifa = tax.ToString(); 
            }
            get { return tax; }
        }

        public double BaseGravable { set; get; }

        public double Impoconsumo { set; get; }

        public double ValorIva { set; get; }

        public double Neto { set; get; }

        public double Total { set; get; }

        public Impuesto()
        {
            Id = 0;
            Numero = "";
            PayMethod = 0;
            Tarifa = "";
            BaseGravable = 0;
            Impoconsumo = 0;
            ValorIva = 0;
            Neto = 0;
            Total = 0; 
        }

        public double GetNeto
        {
            get
            {
                return this.BaseGravable + this.Impoconsumo + this.ValorIva;
            }
        }
    }
}