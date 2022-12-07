using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DTO.Clases
{
    public  class TrasladoInventario : FacturaVenta
    {
        public int IdTipoDestino { set; get; }

        public string CajaHostOrigen { set; get; }

        public string CajaHostDestino { set; get; }

        public TrasladoInventario()
        {
            IdTipoDestino = 0;
            CajaHostDestino = "";
            CajaHostOrigen = "";
        }
    }
}