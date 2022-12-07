using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Utilities;
using BussinesLayer.Clases;
using CustomControl;

namespace Aplicacion.Administracion.Usuario
{
    public partial class frmEditarUsuarioPropio : Form
    {
        /// <summary>
        /// Atributos del modelo de negocios.
        /// </summary>
        private BussinesUsuario miBussinesUsiario;

        /// <summary>
        /// Objeto de mensajerias de error
        /// </summary>
        private ErrorProvider miError;       

        /// <summary>
        /// Obtiene o establece el valor del Id del Usuario.
        /// </summary>
        private int idUsuario;

        /// <summary>
        /// Obtiene o establece el valor des documento del usuario logueado.
        /// </summary>
        private int Documento;

        /// <summary>
        /// Obtiene o establece la condición de la validación.
        /// </summary>
        private bool telefono,
                     dirección,
                     usuario = false;

        public frmEditarUsuarioPropio()
        {
            InitializeComponent();
            Documento = Convert.ToInt32(AppConfiguracion.ValorSeccion("documento"));
            miBussinesUsiario = new BussinesUsuario();
            miError = new ErrorProvider();          
        }

        private void frmEditarUsuarioPropio_Load(object sender, EventArgs e)
        {
            CargarUsuarioPropio();
        }

        private void tsbtnGuardar_Click(object sender, EventArgs e)
        {
            Revalidar();
            if (telefono && dirección && usuario)
            {
                miBussinesUsiario.EditaUsuarioPropio(idUsuario, txtDireccion.Text, txtTelefono.Text, txtUsuario.Text);
                OptionPane.MessageInformation("El usuario se a editado exitosamente.");
            }
        }

        private void tsbtnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void lklblCambiarContrasena_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmEditaContrasena micontrasena = new frmEditaContrasena();
            micontrasena.Id=idUsuario;
            micontrasena.Show();
        }

        private void txtDireccion_Validating(object sender, CancelEventArgs e)
        {
            if (!Validacion.EsVacio(txtDireccion, miError, "el campo de dirección es requerido."))
            {
                if (Validacion.ConFormato(Validacion.TipoValidacion.Domicilio, txtDireccion, miError, "El campo de direccion tiene formato incorrecto."))
                {
                    dirección = true;
                }
                else
                    dirección = false;
            }
            else
                dirección = false;
        }

        private void txtTelefono_Validating(object sender, CancelEventArgs e)
        {
            if (!Validacion.EsVacio(txtTelefono, miError, "El campo de telefono es requerido."))
            {
                if (Validacion.ConFormato(Validacion.TipoValidacion.Numeros, txtTelefono, miError, "El campo de telefono tiene formato incorrecto."))
                {
                    telefono = true;
                }
                else
                    telefono = false;
            }
            else
                telefono = false;
        }

        private void txtUsuario_Validating(object sender, CancelEventArgs e)
        {
            if (!Validacion.EsVacio(txtUsuario, miError, "El campo de usuario es requerido."))
            {
               // if (Validacion.ConFormato(Validacion.TipoValidacion.Password, txtUsuario, miError, "El campo de usuario es requerido."))
                //{
                var frmusuario = new frmUsuarioSistema();
                var usuario_ = miBussinesUsiario.CargaUsuario(Documento);
                if (usuario_.Usuario_ != txtUsuario.Text)
                {
                    if (!frmusuario.ExisteUsuario(txtUsuario.Text))
                    {
                        miError.SetError(txtUsuario, null);
                        usuario = true;
                    }
                    else
                    {
                        OptionPane.MessageInformation("El usuario ya existe.");
                        miError.SetError(txtUsuario, "El usuario ya existe.");
                        usuario = false;
                    }
                }
                else
                    usuario = true;
                //}
                //else
                  //  usuario = false;
            }
            else
                usuario = false;
        }

        /// <summary>
        /// Carga el usuario
        /// </summary>
        private void CargarUsuarioPropio()
        {
            try
            {
                var usuario = miBussinesUsiario.CargaUsuario(Documento);
                idUsuario = usuario.Id;
                txtNombre.Text = usuario.Nombres;
                txtDocumento.Text = Convert.ToString(usuario.Identificacion);
                txtTelefono.Text = usuario.Telefono;
                txtDireccion.Text = usuario.Direccion;
                txtCargo.Text = usuario.Cargo.Descripcion;
                txtUsuario.Text = usuario.Usuario_;
                if (usuario.Estado == true)
                {
                    lblEstado.Text = "Activo";
                    lblEstado.ForeColor = Color.Green;
                }
                else
                {
                    if (usuario.Estado == false)
                    {
                        lblEstado.Text = "Inactivo";
                        lblEstado.ForeColor = Color.Red;
                    }
                }
            }
            catch(Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
        }

       /// <summary>
       /// Revalida los campos de el formulario
       /// </summary> 
        private void Revalidar()
        {
            txtDireccion_Validating(null, null);
            txtTelefono_Validating(null, null);
            txtUsuario_Validating(null, null);
        }
        
           
    }
}
