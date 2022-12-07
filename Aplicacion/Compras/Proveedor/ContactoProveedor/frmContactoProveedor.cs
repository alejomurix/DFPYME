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
using DTO.Clases;

namespace Aplicacion.Compras.Proveedor.ContactoProveedor
{
    public partial class frmContactoProveedor : Form
    {
        /// <summary>
        /// Representa un objeto de logica de negocio de Contacto.
        /// </summary>
        private BussinesContactoProveedor miBussinesContacto;

        /// <summary>
        /// Representa un objeto para mostrar errores.
        /// </summary>
        private ErrorProvider miError = new ErrorProvider();

        /// <summary>
        /// Representa un objeto para validacion de datos.
        /// </summary>
        private Validacion miValidacion = new Validacion();

        /// <summary>
        /// Establece la condicion para transferir los datos.
        /// </summary>
        private bool aceptar = false;

        /// <summary>
        /// Establece la condicion de existencia de un contacto.
        /// </summary>
        private bool existe = false;

        /// <summary>
        /// Establece el varlor que indica que el formulario se usara para editar datos.
        /// </summary>
        public bool edicion = false;

        private bool cedulaMatch = false,
                     nombreMatch = false,
                     telefonoMatch = false,
                     celularMatch = false,
                     emailMatch = false;

        /// <summary>
        /// Establece el valor de id del contacto a editar.
        /// </summary>
        public int idContacto;

        /// <summary>
        /// Establece en numero de cedula de contacto para validaciones.
        /// </summary>
        public int cedulaContacto;

        #region Mensajes de Validacion

        private const string cedulaRequerida = "El campo Cedula es requerido.";
        private const string nombreRequerido = "El campo Nombre es requerido.";
        private const string celularRequerido = "El campo Celular es requerido.";

        private const string cedulaFormato = "La Cedula solo debe contener digitos numericos.";
        private const string nombreFormato = "El Nombre solo debe contener letras del alfabeto.";
        private const string telefonoFormato = "El numero de telefono que ingreso tiene formato incorrecto.";
        private const string celularFormato = "El numero de celular que ingreso tiene formato incorrecto.";
        private const string emailFormato = "El formato del Email es incorrecto.";

        private const string errorExiste = "El contacto ya existe en la Base de Datos.";

        private const string exito = "Los datos del vendedor se cargaron con exito. \nDesea ingresar otro?";
        private const string caption = "Datos Correctos";

        #endregion

        public frmContactoProveedor()
        {
            InitializeComponent();
        }

        private void frmContactoProveedor_Load(object sender, EventArgs e) { }

        #region Metodos de Validacion

        private void txtCedula_Validating(object sender, CancelEventArgs e)
        {
            //Valida que el campo no este vacio.
            if (String.IsNullOrEmpty(txtCedula.Text))
            {
                MostrarError(txtCedula, cedulaRequerida);
                cedulaMatch = false;
            }
            else
            {
                QuitarError(txtCedula);
                //Valida formato de cedula correcto.
                if (!miValidacion.ValidarNumeroInt(txtCedula.Text))
                {
                    MostrarError(txtCedula, cedulaFormato);
                    cedulaMatch = false;
                }
                else 
                {
                    cedulaMatch = true;
                    QuitarError(txtCedula);
                    //Valida que el contacto existe o no el en la base de datos.
                    var cedula = Convert.ToInt32(txtCedula.Text);
                    if ( ExisteContacto(cedula) && !cedulaContacto.Equals(cedula) )
                    {
                        MostrarError(txtCedula, errorExiste);
                        existe = true;
                    }
                    else
                    {
                        QuitarError(txtCedula);
                        existe = false;
                    }
                } 
            }
        }

        private void txtNombres_Validating(object sender, CancelEventArgs e)
        {
            //Valida campo vacio
            if (String.IsNullOrEmpty(txtNombres.Text))
            {
                MostrarError(txtNombres, nombreRequerido);
                nombreMatch = false;
            }
            else
            {
                QuitarError(txtNombres);
                nombreMatch = true;
                //Valida formato campo de texto nombre
                if (!miValidacion.ValidarPalabraCompuesta(txtNombres.Text))
                {
                    MostrarError(txtNombres, nombreFormato);
                    nombreMatch = false;
                }
                else 
                { 
                    QuitarError(txtNombres);
                    nombreMatch = true;
                }
            }
        }

        private void txtTelefono_Validating(object sender, CancelEventArgs e)
        {
            //valida formato de telefono
            if (!String.IsNullOrEmpty(txtTelefono.Text))
            {
                if (!miValidacion.ValidarTelefonoFijo(txtTelefono.Text))
                {
                    MostrarError(txtTelefono, telefonoFormato);
                    telefonoMatch = false;
                }
                else
                {
                    QuitarError(txtTelefono);
                    telefonoMatch = true;
                }
            }
            else
                telefonoMatch = true;
        }

        private void txtCelular_Validating(object sender, CancelEventArgs e)
        {
            //valida campo vacio
            if (String.IsNullOrEmpty(txtCelular.Text))
            {
                MostrarError(txtCelular, celularRequerido);
                celularMatch = false;
            }
            else
            {
                celularMatch = true;
                QuitarError(txtCelular);
                //Validar formato de celular
                if (!miValidacion.ValidarNumeroCelular(txtCelular.Text))
                {
                    MostrarError(txtCelular, celularFormato);
                    celularMatch = false;
                }
                else 
                { 
                    QuitarError(txtCelular);
                    celularMatch = true;
                }
            }
        }

        private void txtEmail_Validating(object sender, CancelEventArgs e)
        {
            if (!String.IsNullOrEmpty(txtEmail.Text))
            {
                //valida formato de email
                if (!miValidacion.ValidarEmail(txtEmail.Text))
                {
                    MostrarError(txtEmail, emailFormato);
                    emailMatch = false;
                }
                else
                {
                    QuitarError(txtEmail);
                    emailMatch = true;
                }
            }
            else
                emailMatch = true;
        }

        #endregion

        private void btnExtAceptar_Click(object sender, EventArgs e)
        {
            ValidacionParaAceptar();
            if (aceptar &&
                cedulaMatch &&
                nombreMatch &&
                telefonoMatch &&
                celularMatch &&
                emailMatch
                && !existe && !edicion)
            {
                TransferenciaVendedor miVendedor = TransferenciaVendedor.Instancia();
                miVendedor.CedulaContacto = Convert.ToInt32(txtCedula.Text);
                miVendedor.NombreContacto = txtNombres.Text;
                miVendedor.TelefonoContacto = txtTelefono.Text;
                miVendedor.CelularContacto = txtCelular.Text;
                miVendedor.EmailContacto = txtEmail.Text;
                CompletaEventos.CapturaEvento(miVendedor);
                DialogResult boton = MessageBox.Show(exito, caption , MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (boton == DialogResult.No)
                {
                    LimpiarCampos();
                    this.Close();
                }
                LimpiarCampos();
            }
            if (aceptar &&
                cedulaMatch &&
                nombreMatch &&
                telefonoMatch &&
                celularMatch &&
                emailMatch
                && edicion && !existe)
            {
                ContactoDeProveedor contatoEdicion = new ContactoDeProveedor();
                contatoEdicion.IdContacto = idContacto;
                contatoEdicion.CedulaContacto = Convert.ToInt32(txtCedula.Text);
                contatoEdicion.NombreContacto = txtNombres.Text;
                contatoEdicion.TelefonoContacto = txtTelefono.Text;
                contatoEdicion.CelularContacto = txtCelular.Text;
                contatoEdicion.EmailContacto = txtEmail.Text;
                if (rbtnBaja.Checked)
                {
                    contatoEdicion.EstadoContacto = false;
                    contatoEdicion.TextoEstado = "Inactivo";
                }
                else
                    contatoEdicion.TextoEstado = "Activo";
                CompletaEventos.CapturaEvento(contatoEdicion);
                MessageBox.Show("La Edicion se realizon con exito. \nLa ventana se cerrara. ",
                    "Edicion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
        }

        private void btnExtCancelar_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
            this.Close();
            CompletaEventos.CapturaEvento(true);
        }

        /// <summary>
        /// Limpia todos los campos de texto del formulario.
        /// </summary>
        private void LimpiarCampos()
        {
            this.txtCedula.Text = "";
            this.txtNombres.Text = "";
            this.txtTelefono.Text = "";
            this.txtCelular.Text = "";
            this.txtEmail.Text = "";

        }

        /// <summary>
        /// Muestra el mensaje de error en el campo y establece aceptar en false;
        /// </summary>
        /// <param name="control">Control a mostrar error</param>
        /// <param name="mensaje">Mensaje de error a mostrar</param>
        private void MostrarError(Control control, string mensaje)
        {
            miError.SetError(control, mensaje);
            aceptar = false;
        }

        /// <summary>
        /// Quita el error del control asignado y establece aceptar en true.
        /// </summary>
        /// <param name="control">Control a quitar error</param>
        private void QuitarError(Control control)
        {
            miError.SetError(control , null);
            aceptar = true;
        }

        /// <summary>
        /// Verifica si un contacto de proveedor existe en la base de datos.
        /// </summary>
        /// <param name="cedula"></param>
        /// <returns></returns>
        private bool ExisteContacto(int cedula)
        {
            miBussinesContacto = new BussinesContactoProveedor();
            try
            {
                return miBussinesContacto.ExisteContacto(cedula);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message , "", MessageBoxButtons.OK,MessageBoxIcon.Error);
                return false;
            }
        }

        /// <summary>
        /// Valida de nuevo los campos
        /// </summary>
        private void ValidacionParaAceptar()
        {
            txtCedula_Validating(null, null);
            txtNombres_Validating(null, null);
            txtTelefono_Validating(null, null);
            txtCelular_Validating(null, null);
            txtEmail_Validating(null, null);
        }
    }
}
