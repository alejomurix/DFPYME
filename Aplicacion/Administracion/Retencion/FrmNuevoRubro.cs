using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BussinesLayer.Clases;
using Utilities;
using CustomControl;

namespace Aplicacion.Administracion.Retencion
{
    public partial class FrmNuevoRubro : Form
    {
        private BussinesRetencion miBussinesRetencion;

        public FrmNuevoRubro()
        {
            InitializeComponent();
            miBussinesRetencion = new BussinesRetencion();
        }

        private void FrmNuevoRubro_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData.Equals(Keys.Escape))
            {
                this.Close();
            }
        }

        private void txtRubro_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar.Equals((char)Keys.Enter))
            {
                this.btnOk_Click(this.btnOk, new EventArgs());
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtRubro.Text != "")
                {
                    miBussinesRetencion.IngresarRubro(txtRubro.Text);
                    CompletaEventos.CapturaEventoz(10);
                    this.Close();
                }
                else
                {
                    OptionPane.MessageInformation("El campo es requerido.");
                }
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}