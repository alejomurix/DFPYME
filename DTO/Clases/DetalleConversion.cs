using System;

namespace DTO.Clases
{
    public class DetalleConversion
    {
        public int Id { set; get; }

        public int IdConversion { set; get; }

        public string CodigoProducto { set; get; }

        public double Cantidad { set; get; }

        public DetalleConversion()
        {
            this.Id = 0;
            this.IdConversion = 0;
            this.CodigoProducto = "";
            this.Cantidad = 0;
        }
    }
}