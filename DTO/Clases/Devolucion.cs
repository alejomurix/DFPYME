using System;

namespace DTO.Clases
{
    public class Devolucion
    {
        public int Id { set; get; }

        public string Factura { set; get; }

        public DateTime Fecha { set; get; }

        public double Cantidad { set; get; }

        public int Valor { set; get; }

        public double Iva { set; get; }

        public Inventario Producto { set; get; }

        public bool Descuento { set; get; }

        public double Descto { set; get; }

        //public double Recargo { set; get; }

        public int IdUsuario { set; get; }

        public int IdCaja { set; get; }

        public bool Efectiva { set; get; }

        public string Numero { set; get; }

        public string Cliente { set; get; }

        /// <summary>
        /// Inicializa una nueva instancia de la clase Devolucion.
        /// </summary>
        public Devolucion()
        {
            this.Id = 0;
            this.Factura = "";
            this.Fecha = DateTime.Today;
            this.Cantidad = 0.0;
            this.Valor = 0;
            this.Iva = 0.0;
            this.Producto = new Inventario();
            this.Descuento = false;
            this.Descto = 0.0;
            //this.Recargo = 0.0;
            this.IdUsuario = 0;
            this.IdCaja = 0;
            this.Efectiva = true;
            this.Numero = "";
            this.Cliente = "";
        }

    }
}