using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BussinesLayer.Clases;
using CustomControl;
using Utilities;

namespace Aplicacion.Administracion.Usuario
{
    public partial class FrmLoginPassword : Form
    {
        public int IdPermiso { set; get; }

        public string Usuario_ { set; get; }

        private BussinesUsuario miBussinesUsuario;

        public FrmLoginPassword()
        {
            InitializeComponent();
            this.miBussinesUsuario = new BussinesUsuario();
        }

        private void FrmLoginPassword_Load(object sender, EventArgs e)
        {
        }

        private void FrmLoginPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData.Equals(Keys.Escape))
            {
                this.Close();
            }
        }

        private void password_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar.Equals((char)Keys.Enter))
            {
                this.btnAceptar_Click(this.btnAceptar, new EventArgs());
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.miBussinesUsuario.VerificarUsuario(this.Usuario_, this.txtPassword.Text, this.IdPermiso))
                {
                    CompletaEventos.CapturaEvento(new ObjectAbstract { Id = 45454545 });
                }
                else
                {
                    CompletaEventos.CapturaEvento(new ObjectAbstract { Id = -1 });
                }
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}