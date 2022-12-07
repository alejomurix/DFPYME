using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BussinesLayer.Clases;
using CustomControl;

namespace Aplicacion.Compras.Pago
{
    public partial class FrmPagosFactura : Form
    {

        public int IdFactura { set; get; }

        private BussinesFormaPago miBussinesPago;

        public FrmPagosFactura()
        {
            InitializeComponent();
            this.miBussinesPago = new BussinesFormaPago();
        }

        private void FrmPagosFactura_Load(object sender, EventArgs e)
        {
            try
            {
                this.dgvPagos.AutoGenerateColumns = false;
                this.dgvPagos.DataSource = miBussinesPago.PagosFacturaProveedor(this.IdFactura);
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
        }

        private void FrmPagosFactura_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData.Equals(Keys.Escape))
            {
                this.Close();
            }
        }
    }
}