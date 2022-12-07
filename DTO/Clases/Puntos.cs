using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DTO.Clases
{
   public class Punto
    {
       public int IdPuntos { get; set; }

       public int ValorVentaMinPunto { get; set; }

       public double NumeroPuntos { get; set; }

       public double ValorPunto { get; set; }

       public bool EstadoPunto { get; set; }

       public Punto()
       {
           this.IdPuntos = 0;
           this.ValorVentaMinPunto = 0;
           this.NumeroPuntos = 0;
           this.ValorPunto = 0;
           this.EstadoPunto = false;
       }
    }
}