using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DTO.Clases
{
    public class Zona
    {
        public int IdZona { get; set; }
        public string Capacidad { get; set;}
        public int IdBodega { get; set; }
       // public int IdBodegaEditado { get; set; }
      //  public int IdCapacidad { get; set; }
        public int NumeroZona { get; set; }
        public string NombreZona { get; set; }
        public bool DisponibleZona { get; set; }
       // public int IdZonaEditado { set; get; }
        private const string Activo = "Disponible";
        private const string Inactivo = "No Disponible";
        public string TextoDisponibleZona
        {
            get
            {
                if (this.DisponibleZona)
                {
                    return Activo;

                }
                else
                    return Inactivo;

            }


        }

        #region Atributos de navegacion

        public string ValorCapacidad { get; set; }
        public string NombreBodega { get; set; }
        public string LugarBodega { get; set; }


        #endregion

    }
}
