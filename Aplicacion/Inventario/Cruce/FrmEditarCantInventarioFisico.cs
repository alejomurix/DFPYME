using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BussinesLayer.Clases;

namespace Aplicacion.Inventario.Cruce
{
    public partial class FrmEditarCantInventarioFisico : Form
    {
        public int Id { set; get; }

        private BussinesInventario miBussinesInventario;

        public FrmEditarCantInventarioFisico()
        {
            InitializeComponent();
            miBussinesInventario = new BussinesInventario();
        }

        private void FrmEditarCantInventarioFisico_Load(object sender, EventArgs e)
        {

        }

        private void FrmEditarCantInventarioFisico_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData.Equals(Keys.Escape))
            {
                this.Close();
            }
        }

        private void txtCantidad_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar.Equals((char)Keys.Enter))
            {
                this.btnAceptar_Click(this.btnAceptar, null);
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult rta = MessageBox.Show("¿Esta seguro de que quiere editar la cantidad?", "Inventario",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (rta == DialogResult.Yes)
                {
                    miBussinesInventario.EditarCantidadInventarioFisico(this.Id, Convert.ToDouble(txtCantidad.Text.Replace('.', ',')));
                    CustomControl.OptionPane.MessageInformation("La cantidad ha sido editada con exito.");
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                CustomControl.OptionPane.MessageError(ex.Message);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}