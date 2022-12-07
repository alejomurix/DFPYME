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
    public partial class FrmActualizarCosto : Form
    {
        public FrmActualizarCosto()
        {
            InitializeComponent();
        }

        private void FrmActualizarCosto_Load(object sender, EventArgs e)
        {

        }

        private void FrmActualizarCosto_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData.Equals(Keys.Escape))
            {
                this.Close();
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (rbtnActual.Checked)
            {
                CompletaEventos.CapturaEventobo(Convert.ToInt32(UseObject.RemoveSeparatorMil(txtActual.Text)));
            }
            else
            {
                if (rbtnUltimo.Checked)
                {
                    CompletaEventos.CapturaEventobo(Convert.ToInt32(UseObject.RemoveSeparatorMil(txtUltimo.Text)));
                }
                else
                {
                    CompletaEventos.CapturaEventobo(Convert.ToInt32(UseObject.RemoveSeparatorMil(txtPromedio.Text)));
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}