
namespace DTO.Clases
{
    public class ClasePuc
    {
        public int Id { set; get; }

        public string Numero { set; get; }

        public string Nombre { set; get; }

        public ClasePuc()
        {
            this.Id = 0;
            this.Numero = "";
            this.Nombre = "";
        }
    }

    public class GrupoPuc : ClasePuc
    {
        public int IdClase { set; get; }

        public GrupoPuc() : base()
        {
            this.IdClase = 0;
        }
    }

    public class CuentaPuc : ClasePuc
    {
        public int IdGrupo { set; get; }

        public CuentaPuc()
            : base()
        {
            this.IdGrupo = 0;
        }
    }

    public class SubCuentaPuc : ClasePuc
    {
        public int IdCuenta { set; get; }

        public string Concepto { set; get; }

        public bool Estado { set; get; }

        public SubCuentaPuc()
            : base()
        {
            this.Id = 0;
            this.Concepto = "";
            this.Estado = false;
        }
    }

    public class CuentaAuxiliar : SubCuentaPuc
    {
        public int IdNaturaleza { set; get; }

        public string Naturaleza { set; get; }

        public CuentaAuxiliar()
            : base() 
        {
            this.IdNaturaleza = 0;
            this.Naturaleza = "";
        }
    }
}