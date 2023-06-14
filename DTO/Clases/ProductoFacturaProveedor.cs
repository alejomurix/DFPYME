using System;

namespace DTO.Clases
{
    /// <summary>
    /// Representa una clase para los datos de los Productos en la Factura de Proveedor.
    /// </summary>
    public class ProductoFacturaProveedor : ICloneable
    {
        public virtual object Clone() { return this.MemberwiseClone(); }

        /// <summary>
        /// Obtiene o establece el valor del Id unico de la relacion.
        /// </summary>
        public int Id { set; get; }

        /// <summary>
        /// Obtiene o establece el Numero de identificación unico de la Factura.
        /// </summary>
        public int IdFactura { set; get; }

        public string Codigo { set; get; }

        public string Nombre { set; get; }

        /// <summary>
        /// Obtiene o establece el valor del número de la factura de venta.
        /// </summary>
        public string NumeroFactura { set; get; }

        /// <summary>
        /// Obtiene o establece el Producto que carga en la relacion.
        /// </summary>
        public Producto Producto { set; get; }

        /// <summary>
        /// Obtiene o establece la cantidad del Producto cargado.
        /// </summary>
        public double Cantidad { set; get; }

        /// <summary>
        /// Obtiene o establece el lote del Producto cargado.
        /// </summary>
        public Lote Lote { set; get; }

        /// <summary>
        /// Obtiene o establece el Inventario del Producto cargado.
        /// </summary>
        public Inventario Inventario { set; get; }

        /// <summary>
        /// Establece la condición que indica si el registro se debe almacenar.
        /// </summary>
        public bool Save { set; get; }

        public bool Retorno { set; get; }

        public double Valor { set; get; }

        public int Costo { set; get; }

        public double ValorReal { set; get; }

        public double Price { set; get; }

        public double TotalPrice { set; get; }

        public double ImpoConsumo { set; get; }

        public double Valor_Iva { set; get; }

        public int Total { set; get; }

        public string CodeStandard { set; get; }

        /// <summary>
        /// Inicializa una nueva instancia de la clase ProductoFacturaProveedor.
        /// </summary>
        public ProductoFacturaProveedor()
        {
            this.Id = 0;
            this.IdFactura = 0;
            this.NumeroFactura = "";
            this.Codigo = "";
            this.Nombre = "";
            this.Producto = new Producto();
            this.Cantidad = 0;
            this.Lote = new Lote();
            this.Inventario = new Inventario();
            this.Retorno = false;
            this.Valor = 0;
            this.Costo = 0;
            this.ValorReal = 0;
            this.ImpoConsumo = 0;
            this.Valor_Iva = 0;
        }
    }
}