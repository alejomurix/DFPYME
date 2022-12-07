using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DTO.Clases;
using Utilities;
using CustomControl;
using BussinesLayer.Clases;

namespace Aplicacion.Administracion.Usuario
{
    public partial class FrmIniciarSesion : Form
    {
        public static DTO.Clases.Usuario miUsuario;

        private BussinesUsuario miUsuario_;

        /// <summary>
        /// Objeto de mensajes de error.
        /// </summary>
        private ErrorProvider miError;

        /// <summary>
        /// Obtiene o establece el valor de la validación en el formulario.
        /// </summary>
        private bool usuario,
                     contrasena = false;

        public FrmIniciarSesion()
        {
            InitializeComponent();
            miUsuario_ = new BussinesUsuario();
        }

        private void FrmIniciarSesion_Load(object sender, EventArgs e)
        {
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            Revalidar();
            if (usuario && contrasena)
            {
                var usuario_ = new frmUsuarioSistema();
                if (usuario_.ExisteUsuario(txtUsuario.Text))
                {
                    if (ExisteusuarioActivo(txtUsuario.Text))
                    {
                        if (ExistePasswordUsuario(txtUsuario.Text))
                        {

                        }
                    }
                }
                else
                {
                    OptionPane.MessageInformation("El usuario no existe.");
                }
            }
        }            
        

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtUsuario_Validating(object sender, CancelEventArgs e)
        {
            if (!Validacion.EsVacio(txtUsuario, miError, "El campo de usuario es requerido."))
            {
                //  if (Validacion.ConFormato(Validacion.TipoValidacion.Password, txtUsuario, miError, "El campo de usuario tiene formato incorrecto."))
                //{
                usuario = true;
                //}
                //else
                //  usuario = false;
            }
            else
                usuario = false;
        }

        private void txtContraseña_Validating(object sender, CancelEventArgs e)
        {
            if (!Validacion.EsVacio(txtContraseña, miError, "El campo de contraseña es requerido."))
            {
               // if (Validacion.ConFormato(Validacion.TipoValidacion.Password, txtContraseña, miError, "El campo de contraseña tiene formato incorrecto."))
                //{
                    contrasena = true;
                //}
                //else
                  //  contrasena = false;
            }
            else
                contrasena = false;
        }



        /// <summary>
        /// Cargar los datos del usuario en el texto del formulario.
        /// </summary>
        /// <param name="form">Formulario al cual se le quiere cargar los datos.</param>
        /// <returns></returns>
        public static DTO.Clases.Usuario CargarDatosUsuario(Form form)
        {
            //para programar.
            miUsuario = new DTO.Clases.Usuario();
            miUsuario.Id = Convert.ToInt32(AppConfiguracion.ValorSeccion("id_user"));
           /* miUsuario.Identificacion = 1054;
            miUsuario.Nombres = "Alejandro";*/
            /*form.Text += "  ---  Usuario : " + Administracion.Usuario.FrmIniciarSesion.miUsuario.Identificacion +
                         "  --  " + Administracion.Usuario.FrmIniciarSesion.miUsuario.Nombres;*/
            return miUsuario;
        }

        /// <summary>
        /// Ravalido los campos en el formulario.
        /// </summary>
        private void Revalidar()
        {
            txtContraseña_Validating(null, null);
            txtUsuario_Validating(null, null);
        }

        /// <summary>
        /// Consulta si el usuario esta activo dentro de la base de datos.
        /// </summary>
        /// <param name="usuario">usuario a consultar</param>
        /// <returns></returns>
        private bool ExisteusuarioActivo(string usuario)
        {
            try
            {
                var existeUsuario = miUsuario_.ExisteUsuarioActivo(usuario);
                if (existeUsuario)
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
        /// Consulta en la base de datos si existe ul usuario con la contraseña ingresada.
        /// </summary>
        /// <param name="usuario">usuario a consultar</param>
        /// <returns></returns>
        private bool ExistePasswordUsuario(string usuario)
        {
            try
            {
                var pass = miUsuario_.ExisteUsuarioPassword(usuario);
                if (pass == Encode.Encrypt(txtContraseña.Text))
                {
                    return true;
                }
                else
                {
                    OptionPane.MessageInformation("El usuario o la contraseña son incorrectos.");
                    return false;
                }
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
                return false;
            }
        }
       
    }
}