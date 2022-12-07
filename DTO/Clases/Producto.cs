using System;
using System.Collections.Generic;

namespace DTO.Clases
{
    public class PriceProduct
    {
        public double Costo { set; get; }

        public double Util { set; get; }

        public double UtilValue { set; get; }

        public double Suggested { set; get; }

        public double Price { set; get; }

        public static double GetUtil(PriceProduct p)
        {
            return Math.Round(((p.Price - p.Costo) * 100) / p.Costo, 2);
        }

        public static double GetPrice(PriceProduct p)
        {
            return Math.Round((p.Costo * p.Util / 100) + p.Costo, 0);
        }
    }

    /// <summary>
    /// Representa una clase para Producto.
    /// </summary>
    public class Producto
    {
        /// <summary>
        /// Representa el texto: Activo
        /// </summary>
        private const string Activo = "Activo";

        /// <summary>
        /// Representa el texto: Inactivo
        /// </summary>
        private const string Inactivo = "Inactivo";

        /// <summary>
        /// Inicializa una nueva instancia de la clase Producto.
        /// </summary>
        public Producto()
        {
            this.CodigoInternoProducto = "";
            this.CodigoBarrasProducto = "";
            this.Codigo_2 = "";
            this.Codigo_3 = "";
            this.Codigo_4 = "";
            this.Codigo_5 = "";
            this.Codigo_6 = "";
            this.Codigo_7 = "";
            this.ReferenciaProducto = "";
            this.NombreProducto = "";
            this.DescripcionProducto = "";
            this.CodigoCategoria = "";
            this.IdMarca = 0;
            this.IdMedida = 0;
            this.IdColor = 0;
            this.IdTipoInventario = 1;
            this.CodProductoProceso = "";
            this.UtilidadPorcentualProducto = 0;
            this.ValorVentaProducto = 0;
            this.ValorCosto = 0.0;
            this.AplicaPrecioPorcentaje = true;
            this.IdIva = 0;
            this.UnidadVentaProducto = 0;
            this.CantidadMinimaProducto = 0;
            this.CantidadMaximaProducto = 0;
            this.EstadoProducto = true;
            this.CantidadDecimal = false;
            this.DescuentoMayor = 0.0;
            this.DescuentoDistribuidor = 0.0;
            this.DescuentoPrecio4 = 0;
            this.IdIvaTemp = 0;
            this.IvaTemp = 0;
            this.Cantidad = 0;
            this.Utilidad2 = 0;
            this.Utilidad3 = 0;
            this.Impoconsumo = 0;

            this.IdIco = 0;
            this.ValorIco = 0;
            this.AplicaIco = false;
            this.Imprime = false;
            this.AplicaDescto = false;
        }

        #region Atributos Propios

        /// <summary>
        /// Obtiene o estabelce el Codigo del Producto.
        /// </summary>
        public string CodigoInternoProducto { set; get; }

        /// <summary>
        /// Obtiene o estabelce el Codigo de Barras del Producto.
        /// </summary>
        public string CodigoBarrasProducto { set; get; }

        public string Codigo_2 { set; get; }

        public string Codigo_3 { set; get; }

        public string Codigo_4 { set; get; }

        public string Codigo_5 { set; get; }

        public string Codigo_6 { set; get; }

        public string Codigo_7 { set; get; }

        /// <summary>
        /// Obtiene o establece la Referencia del Producto.
        /// </summary>
        public string ReferenciaProducto { set; get; }

        /// <summary>
        /// Obtiene o establece el Nombre del Producto
        /// </summary>
        public string NombreProducto { set; get; }

        /// <summary>
        /// Obtiene o establece la Descripcion del Producto.
        /// </summary>
        public string DescripcionProducto { set; get; }

        /// <summary>
        /// Obtiene o establece el Codigo de la Categoria del Producto.
        /// </summary>
        public string CodigoCategoria { set; get; }

        /// <summary>
        /// Obtiene o establece el id de la marca del Producto.
        /// </summary>
        public int IdMarca { set; get; }

        public int IdTipoInventario { set; get; }

        public string CodProductoProceso { set; get; }

        /// <summary>
        /// Obtiene o establece la utilidad procentual del Producto.
        /// </summary>
        public double UtilidadPorcentualProducto { get; set; }

        /// <summary>
        /// Obtiene o establece el valor de venta del Producto.
        /// </summary>
        public double ValorVentaProducto { get; set; }

        public double ValorCosto { set; get; }

        /// <summary>
        /// Obtiene o establece el valor del descuento.
        /// </summary>
        public double Descuento { set; get; }

        /// <summary>
        /// Obtiene o establece el valor del recargo.
        /// </summary>
        public double Recargo { set; get; }

        /// <summary>
        /// Obtiene o establece el listado de Descuentos del Producto.
        /// </summary>
        public List<Descuento> Descuentos { set; get; }

        /// <summary>
        /// Obtiene o establece el listado de Recargos del Producto.
        /// </summary>
        public List<Recargo> Recargos { set; get; }

        /// <summary>
        /// Obtiene o establece si indica que el precio se basa en porcentaje de ganancia. Por defecto es true.
        /// </summary>
        public bool AplicaPrecioPorcentaje { set; get; }

        /// <summary>
        /// Obtiene o establece el Id del valor del Iva del Producto.
        /// </summary>
        public int IdIva { get; set; }

        /// <summary>
        /// Obtiene o establece el Id de la medida.
        /// </summary>
        public int IdMedida { set; get; }

        public int IdColor { set; get; }

        /// <summary>
        /// Obtiene o Establece el listado de Medidas del Producto.
        /// </summary>
        public List<ValorUnidadMedida> Medidas { set; get; }

        /// <summary>
        /// Obtiene o establece la lista de inventario de producto.
        /// </summary>
        public List<Inventario> Inventarios { set; get; }

        /// <summary>
        /// Obtiene o establece la unidad de venta del Producto.
        /// </summary>
        public int UnidadVentaProducto { set; get; }

        /// <summary>
        /// Obtiene o establece la cantidad minima que debe haber en inventario del Producto.
        /// </summary>
        public int CantidadMinimaProducto { get; set; }

        /// <summary>
        /// Obtiene o establece la cantidad maxima que debe haber en inventario del Producto.
        /// </summary>
        public int CantidadMaximaProducto { get; set; }

        /// <summary>
        /// Obtiene o establece el Estado del Producto. Por defecto es true.
        /// </summary>
        public bool EstadoProducto { get; set; }

        /// <summary>
        /// Obtiene o establece si el producto aplica medida en Talla.
        /// </summary>
        public bool AplicaTalla { set; get; }

        /// <summary>
        /// Obtiene o establece si el producto aplica color.
        /// </summary>
        public bool AplicaColor { set; get; }

        public bool CantidadDecimal { set; get; }

        public double DescuentoMayor { set; get; }

        public double DescuentoDistribuidor { set; get; }

        public double DescuentoPrecio4 { set; get; }

        public int IdIvaTemp { set; get; }

        public double IvaTemp { set; get; }

        public double Cantidad { set; get; }

        public double Utilidad2 { set; get; }

        public double Utilidad3 { set; get; }

        public double Impoconsumo { set; get; }

        public int IdIco { set; get; }

        public double ValorIco { set; get; }

        public bool AplicaIco { set; get; }

        public bool Imprime { set; get; }

        public bool AplicaDescto { set; get; }

        #endregion

        public double Price3 { set; get; }

        public double Price4 { set; get; }

        #region Atributos de Presentacion y Edicion

        /// <summary>
        /// Obtiene o establece la descripcion del Estado del producto.
        /// </summary>
        public string TextoEstado
        {
            get
            {
                if (this.EstadoProducto)
                {
                    return Activo;

                }
                else
                    return Inactivo;
            }
        }

        /// <summary>
        /// Obtiene o establece el Nombre de la categoria del producto.
        /// </summary>
        public string NombreCategoria { get; set; }

        /// <summary>
        /// Obtiene o establece la unida de medida del producto.
        /// </summary>
        public string UnidadMedida { get; set; }

        /// <summary>
        /// Obtiene o establece el Iva del producto.
        /// </summary>
        public double ValorIva { get; set; }

        public double ValorIvaAnterior { set; get; }

        /// <summary>
        /// Obtiene o establece el nombre de la marca del producto.
        /// </summary>
        public string NombreMarca { get; set; }

        /// <summary>
        /// Obtiene o establece valor de la unidad de medida del producto.
        /// </summary>
        public string ValorUnidadMedida { set; get; }

        /// <summary>
        /// Obtiene o Establece el codigo editado.
        /// </summary>
        public string CodigoInternoEditado { set; get; }  

        #endregion

        public string AplicaIcoToString
        {
            get
            {
                if (this.AplicaIco)
                {
                    return "Si";
                }
                else
                {
                    return "No";
                }
            }
        }

        public string ImprimeToString
        {
            get
            {
                if (this.Imprime)
                {
                    return "Si";
                }
                else
                {
                    return "No";
                }
            }
        }

        public string AplicaDesctoToString
        {
            get
            {
                if (this.AplicaDescto)
                {
                    return "Si";
                }
                else
                {
                    return "No";
                }
            }
        }
    }
}