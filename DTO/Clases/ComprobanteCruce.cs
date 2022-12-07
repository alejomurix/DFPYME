using System;
 
namespace DTO.Clases
{
    public class ComprobanteCruce
    {
        public long Id{ set; get; }

        public DateTime Fecha{ set; get; }

        public string NitCliente { set; get; }

        public string Concepto { set; get; }

        public int Valor { set; get; }

        public string Restante { set; get; }

        public int ValorRestante { set; get; }

        public ComprobanteCruce()
        {
            this.Id = 0;
            this.Fecha = DateTime.Now;
            this.NitCliente = "";
            this.Concepto = "";
            this.Restante = "";
            this.ValorRestante = 0;
        }
    }
}