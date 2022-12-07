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
using DTO.Clases;

namespace Aplicacion.Administracion.Usuario
{
    public partial class frmEditaUsuario : Form
    {
        /// <summary>
        /// Atributos del mideolo de negocios.
        /// </summary>
        private BussinesUsuario miBussinesUsuario;

        /// <summary>
        /// Atributos del modelo de negocios.
        /// </summary>
        private BussinesPermiso miBussinesPermiso;

        /// <summary>
        /// Atributos del modelo de negocios.
        /// </summary>
        private BussinesTipoUsuario miBussinesTipoUsuario;

        /// <summary>
        /// Objeto de mensajes de error.
        /// </summary>
        private ErrorProvider mierror;

        /// <summary>
        /// Lista permisos.
        /// </summary>
        private List<Permiso> mipermiso;

        /// <summary>
        /// obtiene o establece los valoresde los campos de la validacion del formulario
        /// </summary>
        private bool nombre,
                     documento,
                     direccion,
                     telefono,
                     usuario,
                     contraseña = false;

        /// <summary>
        /// Indica que su se sali del formulario o guarda va a refrescar el grid de permisos.
        /// </summary>
        public bool recargaSalir { set; get; }

        /// <summary>
        /// Obtiene  el id del usuario.
        /// </summary>
        private int id;

        /// <summary>
        /// Obtiene o establece los datos del usuario a modificar.
        /// </summary>
        public int Documento { set; get; }

        public frmEditaUsuario()
        {
            InitializeComponent();
            miBussinesUsuario = new BussinesUsuario();
            miBussinesPermiso = new BussinesPermiso();
            miBussinesTipoUsuario = new BussinesTipoUsuario();
            mierror = new ErrorProvider();
            mipermiso = new List<Permiso>();

        }

        private void frmEditaUsuario_Load(object sender, EventArgs e)
        {
            CargarComboBox();
            CargarUsuario();
        }

        private void tsbtnGuardar_Click(object sender, EventArgs e)
        {
            cbxCargo.Focus();
            try
            {
                Revalidar();
                if (nombre && documento && telefono && direccion && usuario && contraseña)
                {
                    var usuario_ = new DTO.Clases.Usuario();
                    usuario_.Id = id;
                    usuario_.Nombres = txtNombre.Text;
                    usuario_.Identificacion = Convert.ToInt32(txtDocumeto.Text);
                    usuario_.Telefono = txtTelefono.Text;
                    usuario_.Direccion = txtDireccion.Text;
                    usuario_.Cargo.IdTipo = (int)cbxCargo.SelectedValue;
                    usuario_.Usuario_ = txtUsuario.Text;
                    usuario_.Contrasenia = Encode.Encrypt(txtContraseña.Text);
                    if (rbtnActivo.Checked)
                    {
                        usuario_.Estado = true;
                    }
                    else
                    {
                        usuario_.Estado = false;
                    }
                    CargarPermisos();
                    usuario_.Permisos = mipermiso;
                    miBussinesUsuario.EditaUsuario(usuario_);
                    OptionPane.MessageInformation("El usuario se a editado con exito.");

                    CompletaEventos.CapturaEvento(true);
                }
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
        }

        private void btnDesacer_Click(object sender, EventArgs e)
        {
            btnEditarCargo.Visible = true;
            txtCargoEditar.Visible = true;
        }

        private void btnEditarCargo_Click(object sender, EventArgs e)
        {
            btnDesacer.Visible = true;
            txtCargoEditar.Visible = false;
        }

        private void tsbtnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void lklblMarcartodos_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            foreach (DataGridViewRow row in dgvEditaPermisos.Rows)
            {
                row.Cells["Aplica"].Value = true;
            }
        }

        private void lkDesmarcaraTodos_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            foreach (DataGridViewRow row in dgvEditaPermisos.Rows)
            {
                row.Cells["Aplica"].Value = false;
            }
        }

        private void txtNombre_Validating(object sender, CancelEventArgs e)
        {
            if (!Validacion.EsVacio(txtNombre, mierror, "El campo de nombre es requerido."))
            {
                if (Validacion.ConFormato(Validacion.TipoValidacion.Palabras, txtNombre, mierror, "El campo nombre tiene formato incorrecto."))
                {
                    nombre = true;
                }
                else
                    nombre = false;
            }
            else
                nombre = false;
        }

        private void txtDocumeto_Validating(object sender, CancelEventArgs e)
        {
            var datos = miBussinesUsuario.CargaUsuario(Documento);
            var frmUsuario = new frmUsuarioSistema();
            if (!Validacion.EsVacio(txtDocumeto, mierror, "El campo de documento es requerido."))
            {
                if (Validacion.ConFormato(Validacion.TipoValidacion.Numeros, txtDocumeto, mierror, "El campo del documento tiene formato incorrecto"))
                {
                    if (datos.Identificacion != Convert.ToInt32(txtDocumeto.Text))
                    {
                        if (!frmUsuario.ExisteDocumento(Convert.ToInt32(txtDocumeto.Text)))
                        {
                            mierror.SetError(txtDocumeto, null);
                            documento = true;
                        }
                        else
                        {
                            OptionPane.MessageInformation("Ya existe un usuario con este documento.");
                            mierror.SetError(txtDocumeto, "Ya existe un usuario con este documento.");
                            documento = false;
                        }
                    }
                    else
                        documento = true;
                }
                else
                    documento = false;
            }
            else
                documento = false;
        }

        private void txtTelefono_Validating(object sender, CancelEventArgs e)
        {
            if (!Validacion.EsVacio(txtTelefono, mierror, "El campo de telefono es requerido."))
            {
                if (Validacion.ConFormato(Validacion.TipoValidacion.Numeros, txtTelefono, mierror, "El campo de teléfono tiene formato incorrecto."))
                {
                    telefono = true;
                }
                else
                    telefono = false;
            }
            else
                telefono = false;
        }

        private void txtDireccion_Validating(object sender, CancelEventArgs e)
        {
            if (!Validacion.EsVacio(txtDireccion, mierror, "El campo de direccion es requerido."))
            {
                if (Validacion.ConFormato(Validacion.TipoValidacion.Domicilio, txtDireccion, mierror, "El campo de dirección tiene formato incorrecto."))
                {
                    direccion = true;
                }
                else
                    direccion = false;
            }
            else
                direccion = false;
        }

        private void txtUsuario_Validating(object sender, CancelEventArgs e)
        {
            var datos = miBussinesUsuario.CargaUsuario(Documento);
            var frmUsuario = new frmUsuarioSistema();
            if (!Validacion.EsVacio(txtUsuario, mierror, "El campo de usuario es requerido."))
            {
               // if (Validacion.ConFormato(Validacion.TipoValidacion.Password, txtUsuario, mierror, "El campo de usuario tiene formato incorrecto."))
                //{
                    if (datos.Usuario_ != txtUsuario.Text)
                    {
                        if (!frmUsuario.ExisteUsuario(txtUsuario.Text))
                        {
                            mierror.SetError(txtUsuario, null);
                            usuario = true;
                        }
                        else
                        {
                            OptionPane.MessageInformation("El usuario ya xiste.");
                            mierror.SetError(txtUsuario, "El usuario ya xiste.");
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

        private void txtContraseña_Validating(object sender, CancelEventArgs e)
        {
            if (!Validacion.EsVacio(txtContraseña, mierror, "El campo de contraseña es requerido."))
            {
                //if (Validacion.ConFormato(Validacion.TipoValidacion.Password, txtContraseña, mierror, "El campo de contraseña tiene formato Incorrecto."))
                //{
                contraseña = true;
                //   }
                //else
                //  contraseña = false;
            }
            else
                contraseña = false;
        }

        private void chbxMostrarContraseña_Click(object sender, EventArgs e)
        {
            if (chbxMostrarContraseña.Checked)
            {
                txtContraseña.UseSystemPasswordChar = false;
            }
            else
            {
                txtContraseña.UseSystemPasswordChar = true;
            }
        }

        /// <summary>
        /// Carga el formulario con el usuario a modificar.
        /// </summary>
        public void CargarUsuario()
        {
            try
            {
                var datos = miBussinesUsuario.CargaUsuario(Documento);
                id = datos.Id;
                txtNombre.Text = datos.Nombres;
                txtDocumeto.Text = Convert.ToString(datos.Identificacion);
                txtTelefono.Text = datos.Telefono;
                txtDireccion.Text = datos.Direccion;
                cbxCargo.SelectedValue = datos.Cargo.IdTipo;
                txtCargoEditar.Text = datos.Cargo.Descripcion;
                txtUsuario.Text = datos.Usuario_;
                txtContraseña.Text = Encode.Decrypt(datos.Contrasenia);
                if (datos.Estado)
                {
                    rbtnActivo.Checked = true;
                }
                else
                {
                    rbtnInactivo.Checked = true;
                }
                dgvEditaPermisos.DataSource = miBussinesPermiso.ListarPermiso();
                foreach (DataGridViewRow GridRow in dgvEditaPermisos.Rows)
                {
                    foreach (DTO.Clases.Permiso p in datos.Permisos)
                    {
                        if (Convert.ToInt32(GridRow.Cells["IdPermiso"].Value) == p.IdPermiso)
                        {
                            GridRow.Cells["Aplica"].Value = true;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
        }

        /// <summary>
        /// Carga el comboBox con los cargos.
        /// </summary>
        private void CargarComboBox()
        {
            try
            {
                cbxCargo.DataSource = miBussinesTipoUsuario.ListarCargo();
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
        }

        private void Revalidar()
        {
            txtContraseña_Validating(null, null);
            txtDireccion_Validating(null, null);
            txtDocumeto_Validating(null, null);
            txtNombre_Validating(null, null);
            txtTelefono_Validating(null, null);
            txtUsuario_Validating(null, null);
        }

        /// <summary>
        /// Carga los permisos del usuario
        /// </summary>
        private void CargarPermisos()
        {
            foreach (DataGridViewRow chk in dgvEditaPermisos.Rows)
            {
                try
                {
                    if (chk.Cells["Aplica"].Value != null)
                    {
                        if (Convert.ToBoolean(chk.Cells["Aplica"].Value))
                        {
                            var chec = (bool)chk.Cells["Aplica"].Value;
                            var p = new Permiso();
                            p.IdPermiso = (int)chk.Cells["IdPermiso"].Value;
                            mipermiso.Add(p);
                        }
                    }
                }
                catch
                { }
            }
        }
    }
}
