using System;
using System.Collections.Generic;

namespace DTO.Clases
{
    public class Anticipo : Egreso
    {
        public int IdCuenta { set; get; }

        public int IdEgreso { set; get; }

        public bool Pago { set; get; }

        public List<ConceptoEgreso> Conceptos { set; get; }

        //public List<FormaPago> Pagos { set; get; }

        public Anticipo()
            : base()
        {
            this.IdCuenta = 0;
            this.IdEgreso = 0;
            this.Pago = false;
            this.Conceptos = new List<ConceptoEgreso>();
            //this.Pagos = new List<FormaPago>();
        }
    }
}