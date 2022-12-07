using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Aplicacion.Clases;
using BussinesLayer.Clases;
using Utilities;
using CustomControl;
using DTO.Clases;

namespace Aplicacion.Administracion.Usuario
{
    public partial class FrmAcceso : Form
    {
        private BussinesUsuario miBussinesUsuario;

        private ErrorProvider miError;

        private bool usuarioMatch;

        private bool passwordMatch;

        public FrmAcceso()
        {
            InitializeComponent();
            this.miBussinesUsuario = new BussinesUsuario();
            this.miError = new ErrorProvider();
            this.usuarioMatch = false;
            this.passwordMatch = false;
        }

        private void FrmAcceso_Load(object sender, EventArgs e)
        {

        }

        private void txtUsuario_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar.Equals((char)Keys.Enter))
            {
                if (String.IsNullOrEmpty(this.txtUsuario.Text))
                {
                    this.miError.SetError(this.txtUsuario, "El campo no debe ser vacio.");
                    this.usuarioMatch = false;
                }
                else
                {
                    this.miError.SetError(this.txtUsuario, null);
                    this.usuarioMatch = true;
                    this.txtPassword.Focus();
                }
            }
        }

        private void txtUsuario_Validating(object sender, CancelEventArgs e)
        {
            if (String.IsNullOrEmpty(this.txtUsuario.Text))
            {
                this.miError.SetError(this.txtUsuario, "El campo no debe ser vacio.");
                this.usuarioMatch = false;
            }
            else
            {
                this.miError.SetError(this.txtUsuario, null);
                this.usuarioMatch = true;
            }
        }

        private void txtPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar.Equals((char)Keys.Enter))
            {
                if (String.IsNullOrEmpty(this.txtPassword.Text))
                {
                    this.miError.SetError(this.txtPassword, "El campo no debe ser vacio.");
                    this.passwordMatch = false;
                }
                else
                {
                    this.miError.SetError(this.txtPassword, null);
                    this.passwordMatch = true;
                    this.btnAceptar_Click(this.btnAceptar, new EventArgs());
                }
            }
        }

        private void txtPassword_Validating(object sender, CancelEventArgs e)
        {
            if (String.IsNullOrEmpty(this.txtPassword.Text))
            {
                this.miError.SetError(this.txtPassword, "El campo no debe ser vacio.");
                this.passwordMatch = false;
            }
            else
            {
                this.miError.SetError(this.txtPassword, null);
                this.passwordMatch = true;
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.usuarioMatch && this.passwordMatch)
                {
                    var usuario = this.miBussinesUsuario.Usuario_(
                        new DTO.Clases.Usuario { Usuario_ = this.txtUsuario.Text, Contrasenia = Encode.Encrypt(this.txtPassword.Text) });
                    if (usuario.Id != 0)
                    {
                        var frmPrincipal_ = (Principal.frmPrincipal)this.MdiParent;
                        frmPrincipal_.HabilitarMenu(usuario);
                        AppConfiguracion.SaveConfiguration("id_user", usuario.Id.ToString());
                        this.Close();
                    }
                    else
                    {
                        this.lblNoLogin.Visible = true;
                        this.txtUsuario.Focus();
                        this.txtUsuario.Text = "";
                        this.txtPassword.Text = "";
                    }
                }
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
        }
        
    }
}