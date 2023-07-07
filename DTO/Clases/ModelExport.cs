using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DTO.Clases
{
    public class ElectronicExport
    {
        public int IEMP { set; get; }
        public DateTime FSOPORT { set; get; }
        public int ITDSOP { set; get; }
        public string INUMSOP { set; get; }
        public int ICuenta { set; get; }
        public int ICCSUBCC { set; get; }
        public string TDETALLE { set; get; }
        public double MDEBITO { set; get; }
        public double MCREDITO { set; get; }
        public double MVRBASE { set; get; }
        public string INIT { set; get; }
        public string INITCXX { set; get; }
        public DateTime FPAGOCXX { set; get; }
    }

    public class CuentaContable
    {
        public int Numero;
        public string Descripcion;
        public bool Debito;
        public bool BaseTax;
        public double Tarifa;
    }

    public class ResumenElectronic
    {
        public DateTime Fecha;
        public string Numero;
        public string Cliente;
        public double BaseVal;
        public double IC;
        public double IVA;
        public double Total;
    }
}
