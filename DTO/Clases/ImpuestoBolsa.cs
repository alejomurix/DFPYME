using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DTO.Clases
{
    public class ImpuestoBolsa
    {
        public int Id { set; get; }

        public int IdFactura { set; get; }

        public double Cantidad { set; get; }

        public double Valor { set; get; }

        public ImpuestoBolsa()
        {
            this.Id = 0;
            this.IdFactura = 0;
            this.Cantidad = 0;
            this.Valor = 0;
        }
    }
}