using System;
namespace DTO.Clases
{
    public class Configuracion
    {
        public int Id { set; get; }

        public int Codigo { set; get; }

        public string Descripcion { set; get; }

        public string Valor { set; get; }

        public Configuracion()
        {
            this.Id = 0;
            this.Codigo = 0;
            this.Descripcion = "";
            this.Valor = "0";
        }
    }
}