using System;
using System.Windows.Forms;
using BussinesLayer.Clases;
using Utilities;

namespace Aplicacion.Configuracion.FormaPago
{
    public partial class frmModificaFormaPago : Form
    {
        BussinesFormaPago miBussinesFormaPago;

        public int IdFormaPago { set; get; }

        public frmModificaFormaPago()
        {
            InitializeComponent();
            miBussinesFormaPago = new BussinesFormaPago();
        }

        private void frmModificaFormaPago_Load(object sender, EventArgs e)
        {

        }

        private void frmModificaFormaPago_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData.Equals(Keys.Escape))
            {
                this.Close();
            }
        }

        private void txtNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar.Equals((char)Keys.Enter))
            {
                this.btnOk_Click(this.btnOk, new EventArgs());
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(txtNombre.Text))
            {
                miBussinesFormaPago.ModificarformaPago(new DTO.Clases.FormaPago
                                    {
                                        IdFormaPago = IdFormaPago,
                                        NombreFormaPago = txtNombre.Text
                                    });
                CompletaEventos.CapturaEvento("formaPago");
                this.Close();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}