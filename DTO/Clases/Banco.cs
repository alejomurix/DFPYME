using System;

namespace DTO.Clases
{
    public class Banco
    {
        public int Id { set; get; }

        public int IdTipo { set; get; }

        public SubCuentaPuc Cuenta { set; get; }

        public string Numero { set; get; }

        public string Entidad { set; get; }

        public string Titular { set; get; }

        public string Sucursal { set; get; }

        public string Direccion { set; get; }

        public Banco()
        {
            this.Id = 0;
            this.IdTipo = 0;
            this.Cuenta = new SubCuentaPuc();
            this.Numero = "";
            this.Entidad = "";
            this.Titular = "";
            this.Sucursal = "";
            this.Direccion = "";
        }
    }
}