using System;
using System.Collections.Generic;

namespace DTO.Clases
{
    public  class Conversion
    {
        public int Id { set; get; }

        public string CodigoProducto { set; get; }

        public double Cantidad { set; get; }

        public List<DetalleConversion> Detalles { set; get; }

        public Conversion()
        {
            this.Id = 0;
            this.CodigoProducto = "";
            this.Cantidad = 0;
            this.Detalles = new List<DetalleConversion>();
        }
    }
}