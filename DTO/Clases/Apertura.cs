using System;
using System.Collections.Generic;

namespace DTO.Clases
{
    public class Apertura
    {
        public int Id { set; get; }

        public DateTime Fecha { set; get; }

        public Caja Caja { set; get; }

        public Turno Turno { set; get; }

        public Usuario Usuario { set; get; }

        public int Valor { set; get; }

        public int Cierre { set; get; }

        public Apertura()
        {
            this.Id = 0;
            this.Fecha = DateTime.Today;
            this.Caja = new Caja();
            this.Turno = new Turno();
            this.Usuario = new Usuario();
        }
    }

    public class Cierre : Apertura
    {
        public int IdApertura { set; get; }

        public List<FormaPago> Valores { set; get; }

        public Cierre()
            : base()
        {
            this.IdApertura = 0;
            this.Valores = new List<FormaPago>();
        }
    }

    public class Retiro : Cierre
    {
        public Retiro() : base() { }
    }

    // Posible eliminacion de esta clase...
    public class Arqueo : Apertura
    {
        public int Tarjeta { set; get; }

        public Arqueo(): base()
        {
            this.Tarjeta = 0;
        }
    }
}