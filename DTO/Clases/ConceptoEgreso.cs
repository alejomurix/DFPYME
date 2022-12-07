using System;

namespace DTO.Clases
{
    public class ConceptoEgreso : SubCuentaPuc
    {
        public double Tarifa { set; get; }

        public ConceptoEgreso()
            : base()
        {
            this.Tarifa = 0.0;
        }
    }
}