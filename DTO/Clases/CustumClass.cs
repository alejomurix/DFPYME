using System;

namespace DTO.Clases
{
    public class CustumClass
    {
        public System.Data.DataRow Row { set; get; }

        public System.Data.DataTable TCajas { set; get; }

        public System.Data.DataTable TIngresos { set; get; }

        public System.Data.DataTable TRetiros { set; get; }

        public Apertura Apertura { set; get; }

        public CustumClass()
        {
            this.TCajas = new System.Data.DataTable();
            this.TIngresos = new System.Data.DataTable();
            this.TRetiros = new System.Data.DataTable();
            this.Apertura = new Apertura();
        }
    }
}