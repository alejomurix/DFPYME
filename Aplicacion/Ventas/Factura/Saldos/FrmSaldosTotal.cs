using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Aplicacion.Ventas.Factura.Saldos
{
    public partial class FrmSaldosTotal : Form
    {
        public FrmSaldosTotal()
        {
            InitializeComponent();
        }

        private void FrmSaldosTotal_Load(object sender, EventArgs e)
        {

        }

        private void FrmSaldosTotal_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Escape)
            {
                this.Close();
            }
        }
    }
}