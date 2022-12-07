using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DTO.Clases
{
    public class Canje : Saldo
    {
        public int IdSaldo { set; get; }

        public string Concepto { set; get; }

        public double PuntosAntes { set; get; }

        public double Puntos { set; get; }

        public double Valor_ { set; get; }

        public Canje() :
            base()
        {
            this.IdSaldo = 0;
            this.Concepto = "";
        }
    }
}