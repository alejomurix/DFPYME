using System.ComponentModel;
namespace DTO.Clases
{
    public class Empresa
    {
        public string NitEmpresa { set; get; }
        public string NitEditado { set; get; }
        public Regimen Regimen { set; get; }
        public string NombreComercialEmpresa { set; get; }
        public string NombreJuridicoEmpresa { set; get; }
        public string TelefonoEmpresa { get; set; }
        public string CelularEmpresa { get; set; }
        public string FaxEmpresa { get; set; }
        public string EmailEmpresa { get; set; }
        public string PagWebEmpresa { get; set; }
        public Departamento Departamento { set; get; }
        public Ciudad Ciudad { set; get; }
        public string RepresentanteLegalEmpresa { get; set; }
        public string DireccionEmpresa { get; set; }
        public bool EstadoEmpresa { get; set; }
        public bool RecaudaIVA { set; get; }
        public int CentroCosto { get; set; }
        public string Descripcion { get; set; }
        public BindingList<Cuenta> cuenta { get; set; }

        public Empresa()
        {
            this.Regimen = new Regimen();
            this.Departamento = new Departamento();
            this.Ciudad = new Ciudad();
            this.cuenta = new BindingList<Cuenta>();
            this.NitEmpresa = "";
            this.NombreComercialEmpresa = "";
            this.NombreJuridicoEmpresa = "";
            this.TelefonoEmpresa = "";
            this.CelularEmpresa = "";
            this.FaxEmpresa = "";
            this.EmailEmpresa = "";
            this.PagWebEmpresa = "";
            this.RepresentanteLegalEmpresa = "";
            this.DireccionEmpresa = "";
            this.Descripcion = "";
            this.RecaudaIVA = false;
        }
    }
}