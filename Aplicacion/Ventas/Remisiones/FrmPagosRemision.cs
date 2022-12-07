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

namespace Aplicacion.Ventas.Remisiones
{
    public partial class FrmPagosRemision : Form
    {
        public int NumeroRemision { set; get; }

        private BussinesFormaPago miBussinesPago;

        public FrmPagosRemision()
        {
            InitializeComponent();
            NumeroRemision = 0;
            this.miBussinesPago = new BussinesFormaPago();
        }

        private void FrmPagosRemision_Load(object sender, EventArgs e)
        {
            try
            {
                this.dgvPagos.AutoGenerateColumns = false;
                this.dgvPagos.DataSource = miBussinesPago.PagosARemisionVentaId(this.NumeroRemision);
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
        }

        private void FrmPagosRemision_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData.Equals(Keys.Escape))
            {
                this.Close();
            }
        }
    }
}