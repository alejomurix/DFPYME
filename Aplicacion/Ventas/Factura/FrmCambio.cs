using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Aplicacion.Ventas.Factura
{
    public partial class FrmCambio : Form
    {
        public FrmCambio()
        {
            InitializeComponent();
        }

        private void FrmCambio_Load(object sender, EventArgs e)
        {

        }

        private void FrmCambio_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData.Equals(Keys.Escape))
            {
                this.Close();
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
