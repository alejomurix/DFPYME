using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DTO.Clases
{
    public class Criterio
    {
        public int Id { set; get; }

        public string Nombre { set; get; }

        public Criterio()
        {
            this.Id = 0;
            this.Nombre = "";
        }
    }
}