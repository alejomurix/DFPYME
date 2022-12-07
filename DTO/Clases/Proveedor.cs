using System;
using System.ComponentModel;

namespace DTO.Clases
{
    /// <summary>
    /// Representa una clase para Proveedor.
    /// </summary>
    public class Proveedor
    {
        /// <summary>
        /// Inicializa una nueva instancia de Proveedor.
        /// </summary>
        public Proveedor()
        {
            this.CodigoInternoProveedor = 0;
            this.NitProveedor = "";
            this.IdRegimen = 0;
            this.NombreProveedor = "";
            this.RazonSocialProveedor = "";
            this.NombreComercialProveedor = "";
            this.DescripcionProveedor = "";
            this.IdCiudad = 0;
            this.DireccionProveedor = "";
            this.TelefonoProveedor = "";
            this.CelularProveedor = "";
            this.FaxProveedor="";
            this.EmailProveedor="";
            this.WebProveedor="";
            this.EstadoProveedor = true;
            this.ListadoCuenta = new BindingList<Cuenta>();
            this.ListadoContactoProveedor = new BindingList<ContactoDeProveedor>();
        }

        public int CodigoInternoProveedor { get; set; }
        public int CodigoEditadoProveedor { set; get; }
        public string NitProveedor { get; set; }
        public int IdRegimen { get; set; }
        public string Regimen { set; get; }
        public string NombreProveedor { get; set; }
        public string RazonSocialProveedor { set; get; }
        public string NombreComercialProveedor { set; get; }
        public string DescripcionProveedor { get; set; }
        public int IdCiudad { get; set; }
        public string Ciudad { set; get; }
        public int IdDepartamento { set; get; }
        public string Departamento { set; get; }
        public string DireccionProveedor { get; set; }
        public string IndicativoTelefono 
        {
            get
            {
                string indicativo = "";
                if (!String.IsNullOrEmpty(this.TelefonoProveedor) &&
                    this.TelefonoProveedor.Length > 6)
                {
                    char[] c = this.TelefonoProveedor.ToCharArray();
                    indicativo = c[0] + "" + c[1];
                    string telefono = "";
                    for (int i = 2; i < c.Length; i++)
                    {
                        telefono += c[i];
                    }
                    this.TelefonoProveedor = telefono;

                }
                return indicativo;
            }
        }
        public string TelefonoProveedor { set; get; }
        public string CelularProveedor { get; set; }
        public string IndicativoFax
        {
            get
            {
                string indicativo = "";
                if (!String.IsNullOrEmpty(this.FaxProveedor) &&
                    this.FaxProveedor.Length > 6)
                {
                    char[] c = this.FaxProveedor.ToCharArray();
                    indicativo = c[0] + "" + c[1];
                    string fax = "";
                    for (int i = 2; i < c.Length; i++)
                    {
                        fax += c[i];
                    }
                    this.FaxProveedor = fax;
                }
                return indicativo;
            }
        }
        public string FaxProveedor { get; set; }
        public string EmailProveedor { get; set; }
        public string WebProveedor { set; get; }
        /// <summary>
        /// Obtiene o Establece el estado del Proveedor. Por defecto es true
        /// </summary>
        public bool EstadoProveedor { get; set; }
        
        public BindingList<Cuenta> ListadoCuenta { set; get; }

        public BindingList<ContactoDeProveedor> ListadoContactoProveedor { set; get; }

    }
}