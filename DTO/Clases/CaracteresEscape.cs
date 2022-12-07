using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DTO.Clases
{
    public class CaracteresEscape
    {
        public int Id { set; get; }

        public bool Predeterminado { set; get; }

        public int Numero { set; get; }

        public string Caracter_1 { set; get; }

        public string Caracter_2 { set; get; }

        public string Caracter_3 { set; get; }

        public string Caracter_4 { set; get; }

        public string Caracter_5 { set; get; }

        public string Caracter_6 { set; get; }

        public CaracteresEscape()
        {
            this.Id = 0;
            this.Predeterminado = false;
            this.Caracter_1 = "";
            this.Caracter_2 = "";
            this.Caracter_3 = "";
            this.Caracter_4 = "";
            this.Caracter_5 = "";
            this.Caracter_6 = "";
        }
    }
}