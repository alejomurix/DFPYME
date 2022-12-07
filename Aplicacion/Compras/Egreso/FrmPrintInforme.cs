using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Aplicacion.Compras.Egreso
{
    public partial class FrmPrintInforme : Form
    {
        public FrmPrintInforme()
        {
            InitializeComponent();
        }

        private void FrmPrintInforme_Load(object sender, EventArgs e)
        {

            this.rpvEgresos.RefreshReport();
        }

        private void FrmPrintInforme_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.rpvEgresos.Reset();
        }
    }
}