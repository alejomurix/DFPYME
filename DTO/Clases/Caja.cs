using System;
namespace DTO.Clases
{
    /// <summary>
    /// Representa una clase para la estructura de datos de Caja.
    /// </summary>
    public class Caja
    {
        /// <summary>
        /// Obtiene o etablece el valor del Id de la Caja.
        /// </summary>
        public int Id { set; get; }

        /// <summary>
        /// Obtiene o establece el valor del número de la Caja.
        /// </summary>
        public int Numero { set; get; }

        /// <summary>
        /// Obtiene o establece el estado de la Caja.
        /// </summary>
        public bool Estado { set; get; }

        public int Consecutivo { set; get; }

        public int ConsecutigoGeneral { set; get; }

        public string SeriePrinter { set; get; }

        public string Prefijo { set; get; }

        public string NumeroFactura { set; get; }

        public int IdDian { set; get; }

        public string IpServer { set; get; }

        /// <summary>
        /// Inicializa una nueva instancia de la clase Caja.
        /// </summary>
        public Caja()
        {
            this.Id = 0;
            this.Numero = 0;
            this.Estado = true;
            this.Consecutivo = 1;
            this.ConsecutigoGeneral = 1;
            this.SeriePrinter = "";

            this.Prefijo = "";
            this.NumeroFactura = "";
            this.IdDian = 0;
            this.IpServer = "";
        }
    }

    public class Turno
    {
        public int Id { set; get; }

        public int Numero { set; get; }

        public Turno()
        {
            this.Id = 0;
            this.Numero = 0;
        }
    }

    public class FechaTurno : Turno
    {
        public DateTime Fecha { set; get; }

        public FechaTurno()
            : base()
        {
            this.Fecha = new DateTime();
        }
    }
}