using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DTO.Clases
{
    public class Cliente
    {
        public Cliente()
        {
            this.NitCliente = "";
            this.NitEditado = "";
            this.IdRegimen = 2;
            this.NombresCliente = "";
            this.TelefonoCliente = "";
            this.CelularCliente = "";
            this.EmailCliente = "";
            this.IdCiudad = 0;
            this.DireccionCliente = "";
            this.EstadoCliente = true;
            this.IdTipoCliente = 1;
            this.IdClasificacion = 0;

            Sales = new List<FacturaVenta>();
        }

        public string NitCliente { get; set; }
        public string NitEditado { set; get; }
        public int IdRegimen { get; set; }
        public string NombresCliente { get; set; }
        public string TelefonoCliente { get; set; }
        public string CelularCliente { get; set; }
        public string EmailCliente { get; set; }
        public int IdCiudad { set; get; }
        public string DireccionCliente { get; set; }
        public bool EstadoCliente { get; set; }
        public int IdTipoCliente { set; get; }
        public string DescripcionTipo { set; get; }
        public int IdClasificacion { set; get; }
        public string DescripcionClasifica { set; get; }

        public ICollection<FacturaVenta> Sales { set; get; }


        #region Propiedades de Navegacion

        public int IdDepartamento { set; get; }
        public string Departamento { set; get; }
        public string Ciudad { set; get; }
        public string Regimen { set; get; }

        #endregion
    }
}