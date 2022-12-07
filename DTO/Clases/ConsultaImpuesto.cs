using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DTO.Clases
{
    public class ConsultaImpuesto
    {
        public string NitTercero { set; get; }

        public string Tercero { set; get; }

        public string Numero { set; get; }

        public DateTime Fecha { set; get; }

        public double Base0 { set; get; }

        public double Iva0 { set; get; }

        public double Costo0 { set; get; }

        public double Base5 { set; get; }

        public double Iva5 { set; get; }

        public double IcoBase5 { set; get; }

        public double Costo5 { set; get; }

        public double Base19 { set; get; }

        public double Iva19 { set; get; }

        public double IcoBase19 { set; get; }

        public double Costo19 { set; get; }

        public double Base1E { set; get; }

        public double Iva1E { set; get; }

        public double Costo1E { set; get; }

        public double IncBolsa { set; get; }

        public double Retencion { set; get; }

        public double Total { set; get; }

        public double Descuento { set; get; }

        public double CostoVenta { set; get; }

        public ConsultaImpuesto()
        {
            NitTercero = "";
            Tercero = "";
            Numero = "";
            Fecha = new DateTime();
            Base0 = 0;
            Iva0 = 0;
            Costo0 = 0;
            Base5 = 0;
            Iva5 = 0;
            IcoBase5 = 0;
            Costo5 = 0;
            Base19 = 0;
            Iva19 = 0;
            IcoBase19 = 0;
            Costo19 = 0;
            Base1E = 0;
            Iva1E = 0;
            Costo1E = 0;
            IncBolsa = 0;
            Retencion = 0;
            Total = 0;
            Descuento = 0;
            CostoVenta = 0;
        }
    }
}