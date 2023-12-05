using System;

namespace DTO.Clases
{
    public class Dian
    {
        public Dian()
        {
            this.NumeroResolucion = 0;
            this.FechaExpedicion = DateTime.Today;
            //this.Vigencia = DateTime.Today;
            this.SerieInicial = "";
            this.RangoInicial = 0;
            this.SerieFinal = "";
            this.RangoFinal = 0;
            Consecutivo = 0;
            this.TextoInicial = "";
            this.TextoFinal = "";
            this.VigenciaMes = 0;
            IdCaja = 0;
        }

        public int Id { set; get; }

        /// <summary>
        /// Obtiene o establece el valor de el numero de la resolución.
        /// </summary>
        public Int64 NumeroResolucion { set; get; }

        /// <summary>
        /// Obtiene o establece el valor de la fecha de expedicion.
        /// </summary>
        public DateTime FechaExpedicion { set; get; }

        /// <summary>
        /// Obtiene o establece el valor de la serie inicial.
        /// </summary>
        public string SerieInicial { set; get; }

        /// <summary>
        /// Obtiene o establece el valor de el rango inicial.
        /// </summary>
        public Int64 RangoInicial { set; get; }

        /// <summary>
        /// Obtiene o establece el valor de la serie final.
        /// </summary>
        public string SerieFinal { set; get; }

        /// <summary>
        /// Obtiene o establece el valor de el rango final.
        /// </summary>
        public Int64 RangoFinal { set; get; }

        public int Consecutivo { set; get; }

        public int IdModalidad { set; get; }

        public DateTime Vigencia
        {
            get
            {
                return FechaExpedicion.AddMonths(VigenciaMes);
            }
            set { }
        }

        public string TextoInicial { set; get; }

        public string TextoFinal { set; get; }

        public int VigenciaMes { set; get; }

        public int IdCaja { set; get; }

        public bool Update { set; get; }
    }
}