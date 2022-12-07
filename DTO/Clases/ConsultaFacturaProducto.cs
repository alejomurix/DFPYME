using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DTO.Clases
{
    public class ConsultaFacturaProducto
    {
        public DateTime Fecha { set; get; }

        public string Numero { set; get; }

        public double Cantidad { set; get; }

        public string Producto { set; get; }

        public double Valor { set; get; }

        public double Descuento { set; get; }

        public double Total { set; get; }

        public ConsultaFacturaProducto()
        {
            Fecha = DateTime.Now;
            Numero = "";
            Cantidad = 0;
            Producto = "";
            Valor = 0;
            Descuento = 0;
            Total = 0;
        }
    }

    public class ConsultaComprasCuentas
    {
        public int CodProveedor { set; get; }

        public int Consecutivo { set; get; }

        public string Fecha { set; get; }

        public string ClaseDocumento { set; get; }

        public string SociedadFI { set; get; }

        public string FechaContable { set; get; }

        public string Moneda { set; get; }

        public string Norma { set; get; }

        public string Referencia { set; get; }

        public string Texto { set; get; }

        public string Clave { set; get; }

        public string CuentaTercero { set; get; }

        public string Cuenta{ set; get; }

        public string IndicadorCME { set; get; }

        public int Importe { set; get; }

        public string IndicadorImpuesto { set; get; }

        public string CentroCosto { set; get; }

        public string ViaPago { set; get; }

        public string BloqueoPago { set; get; }

        public ConsultaComprasCuentas()
        {
            this.CodProveedor = 0;
            this.Consecutivo = 0;
            this.Fecha = "";
            this.ClaseDocumento = "";
            this.SociedadFI = "FON1";
            this.FechaContable = "";
            this.Moneda = "COP";
            this.Norma = "";
            this.Referencia = "";
            this.Texto = "";
            this.Clave = "";
            this.CuentaTercero = "";
            this.Cuenta = "";
            this.IndicadorCME = "";
            this.Importe = 0;
            this.IndicadorImpuesto = "";
            this.CentroCosto = "";
            this.ViaPago = "";
            this.BloqueoPago = "";
        }
    }
}