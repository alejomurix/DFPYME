using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DTO.Clases
{
    public class Sorteo
    {

        public int IdSorteo { get; set; }
        public int IdTipoSorteo { get; set; }
        public string NombreTipoSorteo { get; set; }
        public string NombreSorteo { get; set; }
        public DateTime FechaInicioSorteo { get; set; }
        public DateTime FechaFinalSorteo { get; set; }
        public DateTime FechaSorteo { get; set; }
        public string PatrocinadoresSorteo { get; set; }
        public string PremioSorteo { get; set; }
        public double ValorPremio { get; set; }
        public double ValorMinimoCompraSorteo { get; set; }
        public bool EstadoSorteo { get; set; }
        public bool AplicaVenta { get; set; }
        public bool TiqueteMultiple { get; set; }
        public bool AplicaHora { set; get; }
        public DateTime HoraInicio { set; get; }
        public DateTime HoraFin { set; get; }
        public string Concepto { set; get; }


        public List<Marca> Marcas { set; get; }

        public List<Categoria> Categorias { set; get; }

        public List<Producto> Producto { set; get; }


    }
}
