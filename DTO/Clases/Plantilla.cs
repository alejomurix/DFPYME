using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DTO.Clases
{
    public class Plantilla
    {
        public int Id { set; get; }

        public string Codigo { set; get; }

        public string Concepto { set; get; }

        public List<CuentaPlantilla> Cuentas { set; get; }

        public Plantilla()
        {
            this.Id = 0;
            this.Codigo = "";
            this.Concepto = "";
            this.Cuentas = new List<CuentaPlantilla>();
        }
    }

    public class CuentaPlantilla
    {
        public int Id { set; get; }

        public int IdPlantilla { set; get; }

        public int IdCuenta { set; get; }

        public bool Naturaleza { set; get; }

        public CuentaPlantilla()
        {
            this.Id = 0;
            this.IdPlantilla = 0;
            this.IdCuenta = 0;
            this.Naturaleza = true;
        }
    }

    public class GrupoDescuento
    {
        public int Id { set; get; }

        public int IdDescuento { set; get; }

        public string Codigo { set; get; }

        public List<AplicaDescuento> Descuentos { set; get; }

        public GrupoDescuento()
        {
            this.Id = 0;
            this.IdDescuento = 0;
            this.Codigo = "";
            this.Descuentos = new List<AplicaDescuento>();
        }
    }

    public class AplicaDescuento
    {
        public int Id { set; get; }

        public int IdGrupo { set; get; }

        public string Codigo { set; get; }

        public string Concepto { set; get; }

        public int IdCuenta { set; get; }

        public double Porcentaje { set; get; }

        public double Valor { set; get; }

        public bool Aplica { set; get; }

        public List<GrupoDescuento> Grupos { set; get; }

        public AplicaDescuento()
        {
            this.Id = 0;
            this.IdGrupo = 0;
            this.Codigo = "";
            this.Concepto = "";
            this.IdCuenta = 0;
            this.Porcentaje = 0;
            this.Valor = 0;
            this.Aplica = true;
            this.Grupos = new List<GrupoDescuento>();
        }
    }
}