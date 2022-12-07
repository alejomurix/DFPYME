using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Utilities;
using CustomControl;
using BussinesLayer.Clases;

namespace Aplicacion.Administracion.Usuario
{
    public partial class frmEditaContrasena : Form
    {
        /// <summary>
        /// Atributos del modelo de negocios
        /// </summary>
        private BussinesUsuario miBussinesUsuario;

        /// <summary>
        /// Objeto de mensajes de error.
        /// </summary>
        private ErrorProvider miError;

        /// <summary>
        /// Obtiene o establece el valor del documento
        /// </summary>
        public int Id { set; get; }

        /// <summary>
        /// Obtiene o establece el valor de la validación
        /// </summary>
        public bool contrasena,
                    nuevaContrasena,
                    confirmarContrasena=false;

        public frmEditaContrasena()
        {
            InitializeComponent();
            miBussinesUsuario = new BussinesUsuario();
            miError = new ErrorProvider();
        }

        private void frmEditaContrasena_Load(object sender, EventArgs e)
        {

        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            Revalidar();
            if (contrasena && nuevaContrasena && confirmarContrasena)
            {
                if (ContrasenaCorrecta())
                {
                    miBussinesUsuario.EditaContrasena(Id,Encode.Encrypt( txtConfirmarContrasenia.Text));
                    OptionPane.MessageInformation("Se a editado la contraseña exitosamente.");
                    miError.SetError(txtContrasenaActual,null);
                    txtContrasenaActual.Text = "";
                    txtNuevaContrasena.Text = "";
                    txtConfirmarContrasenia.Text = "";
                    this.Close();
                }
                else
                {
                    OptionPane.MessageInformation("La contraseña ingresada no es correcta.");
                    miError.SetError(txtContrasenaActual, "La contraseña ingresada no es correcta.");
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtContrasenaActual_Validating(object sender, CancelEventArgs e)
        {
            if (!Validacion.EsVacio(txtContrasenaActual, miError, "El campo de contraseña es requerido."))
            {
               // if(Validacion.ConFormato(Validacion.TipoValidacion.Password,txtContrasenaActual,miError,"El campo de contraseña tiene formato incorrecto"))
                //{
                    contrasena=true;
                //}
            //    else
              //      contrasena=false;
            }
            else
                contrasena = false;
        }

        private void txtNuevaContraseña_Validating(object sender, CancelEventArgs e)
        {
            if(!Validacion.EsVacio(txtNuevaContrasena,miError,"El campo de nueva contraseña."))
            {
              //  if(Validacion.ConFormato(Validacion.TipoValidacion.Password,txtNuevaContrasena,miError,"El campo de nuevo contraseña es requerido."))
                //{
                    nuevaContrasena=true;
                //}
                //else
                  //  nuevaContrasena=false;
            }
            else
           nuevaContrasena=false;
            
        }

        private void txtNuevaContrasenia_Validating(object sender, CancelEventArgs e)
        {
            if (!Validacion.EsVacio(txtConfirmarContrasenia, miError, "El campo de confirmar contraseña es requerido."))
            {
               // if (Validacion.ConFormato(Validacion.TipoValidacion.Password, txtConfirmarContrasenia, miError, "El campo de confirmar contraseña tiene formato incorrecto."))
                //{
                    if (txtNuevaContrasena.Text == txtConfirmarContrasenia.Text)
                    {
                        confirmarContrasena = true;
                        miError.SetError(txtConfirmarContrasenia, null);
                    }
                    else
                    {
                        OptionPane.MessageInformation("La contraseña ingresada no es igual.");
                        miError.SetError(txtConfirmarContrasenia, "La contraseña ingresada no es igual.");
                        confirmarContrasena=false;
                    }
                //}
                //else
                  //  confirmarContrasena = false;
            }
            else
                confirmarContrasena = false;
        }

        /// <summary>
        /// Consulta que la contraseña ingresada sea la misma que en la base de datos.
        /// </summary>
        /// <returns></returns>
        private bool ContrasenaCorrecta()
        {
            try
            {
                var existeUsuario = miBussinesUsuario.ExisteContasena(Id);
                if (txtContrasenaActual.Text.Equals(Encode.Decrypt(existeUsuario)))
                {
                    return true;
                }
                else
                    return false;
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
                return false;
            }
        }

        /// <summary>
        /// Revalida los campos de el formulario.
        /// </summary>
        private void Revalidar()
        {
            txtContrasenaActual_Validating(null,null);
            txtNuevaContrasenia_Validating(null, null);
            txtNuevaContraseña_Validating(null, null);
        }
    }
}
