using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DTO.Clases
{
    public class Promocion
    {
        public int idPromocion { set; get; }
        public int idTipo { set; get; }
        public string NombreTipoPromocion { set; get; }
        public int idDescuento { set; get; }
        public string ValorDescuento { set; get; }
        public DateTime fechaInicio { set; get; }
        public DateTime fechaFin { set; get; }
        public int cantidad { set; get; }

        public int Marca { set; get; }
        public string MarcaValor { set; get; }
        public string Categoria { set; get; }
        public string CategoriaValor { set; get; }
        public string Producto { set; get; }
        public string ProductoValor { set; get; }

    }
}
