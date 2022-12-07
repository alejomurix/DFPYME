using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DTO.Clases
{
    public class Item
    {
        public int Id { set; get; }

        public string Codigo { set; get; }

        public string Nombre { set; get; }

        public int IdMedida { set; get; }

        public int IdColor { set; get; }

        public int IdLote { set; get; }

        public double Cantidad { set; get; }

        public double Costo { set; get; }

        public double Descuento { set; get; }

        public double Descuento2 { set; get; }

        public double IVA { set; get; }

        public double CostoMenosD1 { set; get; }

        public double ValorD2 { set; get; }

        public double ValorIVA { set; get; }

        public double ValorUnitario { set; get; }

        public double Impoconsumo { set; get; }

        public double Precio { set; get; }

        public double Total { set; get; }

        public Item()
        {
            Codigo = "";
            Nombre = "";
            Cantidad = 0;
            Costo = 0;
            Descuento = 0;
            Descuento2 = 0;
            IVA = 0;
            CostoMenosD1 = 0;
            ValorD2 = 0;
            ValorIVA = 0;
            ValorUnitario = 0;
            Impoconsumo = 0;
            Precio = 0;
            Total = 0;
        }
    }
}