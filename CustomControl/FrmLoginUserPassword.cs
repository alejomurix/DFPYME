using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CustomControl
{
    public partial class FrmLoginUserPassword : Form
    {
        private ErrorProvider miError;

        private bool Aceptado;

        public FrmLoginUserPassword()
        {
            InitializeComponent();
            this.miError = new ErrorProvider();
            this.Aceptado = false;
        }

        private void frmPassword_Load(object sender, EventArgs e)
        {
            this.txtUsuario.Focus();
        }

        private void frmPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData.Equals(Keys.Escape))
            {
                this.txtUsuario.Focus();
                this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
                this.Close();
            }
        }

        private void txtUsuario_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar.Equals((char)Keys.Enter))
            {
                this.txtPassword.Focus();
            }
        }

        private void txtUsuario_Validating(object sender, CancelEventArgs e)
        {
            if (String.IsNullOrEmpty(this.txtUsuario.Text))
            {
                this.miError.SetError(this.txtUsuario, "El campo es requerido.");
                this.Aceptado = false;
            }
            else
            {
                this.miError.SetError(this.txtUsuario, null);
                this.Aceptado = true;
            }
        }

        private void txtPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar.Equals((char)Keys.Enter))
            {
                this.OK_Click(this.OK, new EventArgs());
            }
        }

        private void txtPassword_Validating(object sender, CancelEventArgs e)
        {
            if (String.IsNullOrEmpty(this.txtPassword.Text))
            {
                this.miError.SetError(this.txtPassword, "El campo es requerido.");
                this.Aceptado = false;
            }
            else
            {
                this.miError.SetError(this.txtPassword, null);
                this.Aceptado = true;
            }
        }

        private void OK_Click(object sender, EventArgs e)
        {
            this.txtUsuario_Validating(this.txtUsuario, null);
            this.txtPassword_Validating(this.txtPassword, null);
            if (this.Aceptado)
            {
                this.txtUsuario.Focus();
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
                this.Close();
            }
        }
    }
}