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
    public partial class FrmPagosEgreso : Form
    {
        public FrmPagosEgreso()
        {
            InitializeComponent();
        }

        private void FrmPagosEgreso_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData.Equals(Keys.Escape))
            {
                this.Close();
            }
        }
    }
}