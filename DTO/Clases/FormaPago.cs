using System;

namespace DTO.Clases
{
    /// <summary>
    /// Representa una clase para los datos de Forma de Pago.
    /// </summary>
    public class FormaPago
    {
        public int Id { set; get; }

        public int IdFactura { set; get; }

        /// <summary>
        /// Obtiene o establece el Id de la Forma de Pago
        /// </summary>
        public int IdFormaPago { set; get; }

        /// <summary>
        /// Obtiene o establece el Nombre descriptivo de la Forma de Pago
        /// </summary>
        public string NombreFormaPago { set; get; }

        public bool Habilita { set; get; }

        /// <summary>
        /// Obtiene o establece el Número de la Factura.
        /// </summary>
        public string NumeroFactura { set; get; }

        /// <summary>
        /// Obtiene o establece el la fecha en que se realizó el pago.
        /// </summary>
        public System.DateTime Fecha { set; get; }

        /// <summary>
        /// Obtiene o establece la Caja que realiza el pago.
        /// </summary>
        public Caja Caja { set; get; }

        /// <summary>
        /// Obtiene o establece el Usuario que realiza el pago.
        /// </summary>
        public Usuario Usuario { set; get; }

        /// <summary>
        /// Obtiene o establece el Valor del monto del pago.
        /// </summary>
        public double Valor { set; get; }

        public long Pago { set; get; }

        public int IdEgreso { set; get; }

        /// <summary>
        /// Inicializa una nueva instancia de la clase FormaPago.
        /// </summary>
        public FormaPago()
        {
            this.Id = 0;
            this.IdFactura = 0;
            this.IdFormaPago = 0;
            this.NombreFormaPago = "";
            this.Habilita = true;
            this.NumeroFactura = "";
            this.Fecha = new System.DateTime();
            this.Caja = new Caja();
            this.Usuario = new Usuario();
            this.Valor = 0;
            this.IdEgreso = 0;
            this.Pago = 0;
        }

        int IdCash = 1;

        int IdTransfer = 3;

        int IdCard = 4;

        public void LoadPayMents(System.Collections.Generic.List<FormaPago> payments,
            int idPayment, long cash, double transfer, double card, double total)
        {

        }

        public void LoadPayMents(int idPayment, long cash, double transfer, double card, double total)
        {
            FormaPago f = new FormaPago();
            if (cash > 0)
            {
                f.Valor = f.Pago = cash;

                f.IdFormaPago = idPayment;
                if (idPayment.Equals(this.IdTransfer) || idPayment.Equals(this.IdCard))
                {
                    if (!(cash <= total))
                    {
                        f.Valor = total;
                    }
                    /*if (cash <= total)
                    {
                        f.Valor = cash;
                    }
                    else
                    {
                        f.Valor = total;
                    }*/
                }
                else
                {
                    if (idPayment.Equals(this.IdCash))
                    {
                        if (!(cash <= (total - transfer - card)))
                        {
                            f.Valor = (total - transfer - card);
                        }
                    }
                }
            }
        }
    }
}