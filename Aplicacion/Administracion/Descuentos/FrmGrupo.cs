using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Utilities;

namespace Aplicacion.Administracion.Descuentos
{
    public partial class FrmGrupo : Form
    {
        private ErrorProvider miError;

        public FrmGrupo()
        {
            InitializeComponent();
            miError = new ErrorProvider();
        }

        private void FrmGrupo_Load(object sender, EventArgs e)
        {

        }

        private void FrmGrupo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData.Equals(Keys.Escape))
            {
                this.Close();
            }
        }

        private void txtGrupo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar.Equals((char)Keys.Enter))
            {
                this.btnAceptar_Click(this.btnAceptar, new EventArgs());
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(this.txtGrupo.Text))
            {
                this.miError.SetError(this.txtGrupo, null);
                CompletaEventos.CapturaEvento(new ObjectAbstract
                {
                    Id = 230,
                    Objeto = this.txtGrupo.Text.ToUpper()
                });
                this.Close();
            }
            else
            {
                this.miError.SetError(this.txtGrupo, "El campo es requerido.");
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
