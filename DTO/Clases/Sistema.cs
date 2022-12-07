using System;

namespace DTO.Clases
{
    public class Sistema
    {
        public int Id { set; get; }

        public string Nombre { set; get; }

        public string Fabricante { set; get; }

        public string Version { set; get; }

        public DateTime Fecha { set; get; }

        public string Derecho { set; get; }

        public string Licencia { set; get; }

        public Sistema()
        {
            this.Id = 0;
            this.Nombre = "";
            this.Fabricante = "";
            this.Version = "";
            this.Fecha = DateTime.Now;
            this.Derecho = "";
            this.Licencia = "";
        }
    }
}