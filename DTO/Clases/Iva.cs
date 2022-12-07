using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DTO.Clases
{
    /// <summary>
    /// Representa una clase para el manejo de Iva
    /// </summary>
    public class Iva
    {
        /// <summary>
        /// Inicializa una nueva instancia de la clase Iva
        /// </summary>
        public Iva()
        {
            this.IdIva = 0;
            this.PorcentajeIva = 0;
            this.ConceptoIva = "";
            this.BaseI = 0;
            this.ValorIva = 0;
            this.Total = 0;
            this.TotalSinIco = 0;
        }

        /// <summary>
        /// Obtiene o Establece el valor del Id del Iva
        /// </summary>
        public int IdIva { get; set; }

        /// <summary>
        /// Obtiene o Establece el valor del Procentaje del Iva
        /// </summary>
        public double PorcentajeIva { get; set; }

        /// <summary>
        /// Obtiene o Establece el valor del Conepto del Iva
        /// </summary>
        public string ConceptoIva { get; set; }

        public double BaseI { set; get; }

        public double ValorIva { set; get; }

        public double Total { set; get; }

        public double TotalSinIco { set; get; }
    }

    public class IvaDevolucion : Iva
    {
        public int IdDevolucion { set; get; }

        public string NoFactura { set; get; }

        public IvaDevolucion()
            : base()
        {
            this.IdDevolucion = 0;
            this.NoFactura = "";
        }
    }

    public class IvaAnulado : IvaDevolucion 
    {
        public IvaAnulado() : base() { }
    } 
}