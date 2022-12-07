using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Aplicacion.Compras.IngresarCompra.Saldos
{
    public partial class FrmSaldoProveedor : Form
    {
        public FrmSaldoProveedor()
        {
            InitializeComponent();
        }

        private void FrmSaldoProveedor_Load(object sender, EventArgs e)
        {

        }

        private void FrmSaldoProveedor_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Escape)
                this.Close();
        }
    }
}