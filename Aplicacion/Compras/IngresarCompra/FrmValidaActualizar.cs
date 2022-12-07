using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Utilities;

namespace Aplicacion.Compras.IngresarCompra
{
    public partial class FrmValidaActualizar : Form
    {
        public FrmValidaActualizar()
        {
            InitializeComponent();
        }

        private void FrmValidaActualizar_Load(object sender, EventArgs e)
        {

        }

        private void FrmValidaActualizar_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData.Equals(Keys.Escape))
            {
                this.Close();
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (rbtnPorcentaje.Checked)
            {
                CompletaEventos.CapturaEventobo("Porcentaje");
            }
            else
            {
                CompletaEventos.CapturaEventobo("Valor");
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}