using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BussinesLayer.Clases;
using Utilities;

namespace Aplicacion.Ventas.Cliente
{
    public partial class frmEditarCliente : Form
    {
        #region Atributos De Logica de Negocio

        /// <summary>
        /// Representa la logica de negocios del Cliente
        /// </summary>
        private BussinesCliente miBussinesCliente;
        private BussinesRegimen miBussinesRegimen;
        private BussinesDepartamento miBussinesDepartamento;
        private BussinesCiudad miBussinesCiudad;

        #endregion

        #region Atributos de Validacion

        /// <summary>
        /// Representa un objeto para mostrar mensajes de error
        /// </summary>
        private ErrorProvider miError = new ErrorProvider();

        /// <summary>
        /// Establece la condicion para guardar
        /// </summary>
        private bool cedulaMatch = false,
                     nombreMatch = false,
                     telefonoMatch = false,
                     celularMatch = false,
                     emailMatch = false,
                     direccionMatch = false;

        /// <summary>
        /// Establece el valor del nit acutal del cliente.
        /// </summary>
        private string nitActual = "";

        /// <summary>
        /// Establece el valor de id del regimen actual
        /// </summary>
        private int idRegimen;

        private int IdTipo;

        private int IdClasificacion;

        /// <summary>
        /// Establece el id de la ciudad actual
        /// </summary>
        private int idCiudad;

        /// <summary>
        /// Establece la condicion que indica si el usuario sale del formulario
        /// </summary>
        private bool salir = false;

        /// <summary>
        /// Establece la condicion que indica si el usuario presiono el boton de salir.
        /// </summary>
        private bool prestBtnSalir = false;
 
        #endregion

        #region Constantes de Mensajes

        /// <summary>
        /// Mensaje que representa campo requerido.
        /// </summary>
        private const string
        msnCedulaReq = "El campo Cedula o Nit es requerido. ",
        msnNombreReq = "El campo Nombre es requerido.",
        msnCelularReq = "El campo Celular es Requerido";

        /// <summary>
        /// Mensaje que representa datos sin formato correcto
        /// </summary>
        private const string
        msnCedulaFormat = "La Cedula o Nit que ingreso tiene formato Incorrecto.",
        msnNombreFormat = "El Nombre que ingreso tiene formato Incorrecto.",
        msnTelefonoFormat = "El numero Telefono que ingreso tiene formato Incorrecto.",
        msnCelularFormat = "El numero de Celular que ingreso tiene formato Incorrecto.",
        msnEmailFormat = "El Email que ingreso tiene formato Incorrecto.",
        msnDireccionFormat = "La Direccion que ingreso tiene formato Incorrecto.";

        private const string msnExisteCliente = "La Cedula o Nit ya existen en la base de datos.";

        #endregion

        public frmEditarCliente()
        {
            InitializeComponent();
            miBussinesCiudad = new BussinesCiudad();
            miBussinesCliente = new BussinesCliente();
            miBussinesDepartamento = new BussinesDepartamento();
            miBussinesRegimen = new BussinesRegimen();
        }

        private void IngresarCliente_Load(object sender, EventArgs e)
        {
            CargarRegimen();
            CargarDepartamentos();
        }

        private void frmEditarCliente_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!prestBtnSalir)
            {
                DialogResult rta = MessageBox.Show
                  ("¿Desea guardar los cambios?", "Salir", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);
                if (rta == DialogResult.Yes)
                {
                    salir = true;
                    tsBtnGuardar_Click(null, null);
                    if (cedulaMatch &&
                        nombreMatch &&
                        telefonoMatch &&
                        celularMatch &&
                        direccionMatch &&
                        emailMatch)
                    {
                        e.Cancel = false;
                    }
                    else
                        e.Cancel = true;
                }
                if (rta == DialogResult.No)
                    e.Cancel = false;
                if (rta == DialogResult.Cancel)
                    e.Cancel = true;
            }
            frmCliente.edicionOpen = false;
        }

        private void frmEditarCliente_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData.Equals(Keys.F2))
            {
                this.tsBtnGuardar_Click(this.tsBtnEdicionGuardar, new EventArgs());
            }
        }

        private void cbEditarRegimen_SelectionChangeCommitted(object sender, EventArgs e)
        {
            idRegimen = Convert.ToInt32(cbEditarRegimen.SelectedValue);
        }

        private void cbDepartamentos_SelectionChangeCommitted(object sender, EventArgs e)
        {
            int idDepartamento = Convert.ToInt32(this.cbEditarDepartamentos.SelectedValue);
            CargarCiudades(idDepartamento);
        }

        private void cbEditarCiudad_SelectionChangeCommitted(object sender, EventArgs e)
        {
            idCiudad = Convert.ToInt32(cbEditarCiudad.SelectedValue);
        }

        private void tsBtnGuardar_Click(object sender, EventArgs e)
        {
            ValidacionGuardar();
            if (cedulaMatch &&
                nombreMatch &&
                telefonoMatch &&
                celularMatch &&
                direccionMatch &&
                emailMatch)
            {
                GuardarCliente();
                CompletaEventos.CapturaEvento(new ObjectAbstract
                {
                    Id = 232
                });
                if (!salir)
                {
                    DialogResult rta =
                        MessageBox.Show
                        ("Los datos se almacenaron correctamente. \nDesea cerrar la ventana?",
                        "Edicion",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Information);

                    if (rta == DialogResult.Yes)
                    {
                        //frmCliente.edicionOpen = false;
                        prestBtnSalir = true;
                        this.Close();
                    }
                }
            }
            else
                salir = false;
        }

        private void tsbtnEdicionSalir_Click(object sender, EventArgs e)
        {
            DialogResult rta = MessageBox.Show
               ("¿Desea guardar los cambios?" , "Edición", MessageBoxButtons.YesNoCancel, 
                                 MessageBoxIcon.Information);
            if (rta == DialogResult.Yes)
            {
                salir = true;
                tsBtnGuardar_Click(null, null);
                if (cedulaMatch &&
                    nombreMatch &&
                    telefonoMatch &&
                    celularMatch &&
                    direccionMatch &&
                    emailMatch)
                {
                    prestBtnSalir = true;
                    this.Close();
                }
                else
                    prestBtnSalir = false;
            }
            if (rta == DialogResult.No)
            {
                frmCliente.edicionOpen = false;
                prestBtnSalir = true;
                this.Close();
            }
        }

        private void txtEditarNit_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar.Equals((char)Keys.Enter))
            {
                this.txtEditarNombres.Focus();
            }
        }

        private void txtNit_Validating(object sender, CancelEventArgs e)
        {
            if (!Validacion.EsVacio(txtEditarNit, miError, msnCedulaReq))
            {
                cedulaMatch = true;
                if (Validacion.ConFormato
                    (Validacion.TipoValidacion.NumeroGuion, txtEditarNit, miError, msnCedulaFormat))
                {
                    if (ExisteCliente(txtEditarNit.Text) && nitActual != txtEditarNit.Text)
                    {
                        miError.SetError(txtEditarNit, msnExisteCliente);
                        cedulaMatch = false;
                    }
                    else
                    {
                        miError.SetError(txtEditarNit, null);
                        cedulaMatch = true;
                    }
                }
                else
                    cedulaMatch = false;
            }
            else
                cedulaMatch = false;
        }

        private void txtEditarNombres_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar.Equals((char)Keys.Enter))
            {
                this.txtEditarTelefono.Focus();
            }
        }

        private void txtNombres_Validating(object sender, CancelEventArgs e)
        {
            if (!Validacion.EsVacio(txtEditarNombres, miError, msnNombreReq))
            {
                nombreMatch = true;
                if (Validacion.ConFormato
                    (Validacion.TipoValidacion.Palabras, txtEditarNombres, miError, msnNombreFormat))
                {
                    nombreMatch = true;
                    this.txtEditarNombres.Text = this.txtEditarNombres.Text.ToUpper();
                }
                else
                    nombreMatch = false;
            }
            else
                nombreMatch = false;
        }

        private void txtEditarTelefono_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar.Equals((char)Keys.Enter))
            {
                this.txtEditarCelular.Focus();
            }
        }

        private void txtTelefono_Validating(object sender, CancelEventArgs e)
        {
            if (!String.IsNullOrEmpty(txtEditarTelefono.Text))
            {
                if (Validacion.ConFormato
                    (Validacion.TipoValidacion.NumeroEspacionGuion, txtEditarTelefono, miError, msnTelefonoFormat))
                {
                    telefonoMatch = true;
                }
            }
            else
                telefonoMatch = true;
        }

        private void txtEditarCelular_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar.Equals((char)Keys.Enter))
            {
                this.txtEditarEmail.Focus();
            }
        }

        private void txtCelular_Validating(object sender, CancelEventArgs e)
        {
            if (!Validacion.EsVacio(txtEditarCelular, miError, msnCelularReq))
            {
                celularMatch = true;
                if (Validacion.ConFormato
                    (Validacion.TipoValidacion.NumeroEspacio, txtEditarCelular, miError, msnCelularFormat))
                {
                    celularMatch = true;
                }
                else
                    celularMatch = false;
            }
            else
                celularMatch = false;
        }

        private void txtEmail_Validating(object sender, CancelEventArgs e)
        {
            if (!String.IsNullOrEmpty(txtEditarEmail.Text))
            {
                if (Validacion.ConFormato
                    (Validacion.TipoValidacion.Email, txtEditarEmail, miError, msnEmailFormat))
                {
                    emailMatch = true;
                }
                else
                    emailMatch = false;
            }
            else
                emailMatch = true;
        }

        private void txtEditarEmail_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar.Equals((char)Keys.Enter))
            {
                this.txtEditarDireccion.Focus();
            }
        }

        private void txtDireccion_Validating(object sender, CancelEventArgs e)
        {
            if (!String.IsNullOrEmpty(txtEditarDireccion.Text))
            {
                if (Validacion.ConFormato
                    (Validacion.TipoValidacion.Domicilio, txtEditarDireccion, miError, msnDireccionFormat))
                {
                    direccionMatch = true;
                    this.txtEditarDireccion.Text = this.txtEditarDireccion.Text.ToUpper();
                }
                else
                    direccionMatch = false;
            }
            else
                direccionMatch = true;
        }

        private void btnEditarRegimen_Click(object sender, EventArgs e)
        {
            this.cbEditarRegimen.Visible = true;
            this.txtEdicionRegimen.Visible = false;
            this.btnEditarRegimen.Visible = false;
            cbEditarRegimen_SelectionChangeCommitted(null, null);
        }

        private void btnEditarTipo_Click(object sender, EventArgs e)
        {
            this.cbEditarTipo.Visible = true;
            this.txtDescripcionTipo.Visible = false;
            btnEditarTipo.Visible = false;
        }

        private void btnEditarClasificacion_Click(object sender, EventArgs e)
        {
            cbClasificacion.Visible = true;
            txtClasificacion.Visible = false;
            btnEditarClasificacion.Visible = false;
        }

        private void btnEditarDepartamento_Click(object sender, EventArgs e)
        {
            this.cbEditarDepartamentos.Visible = true;
            txtEdicionDepartamento.Visible = false;
            this.btnEditarDepartamento.Visible = false;
            btnEditarCiudad_Click(null, null);
        }

        private void btnEditarCiudad_Click(object sender, EventArgs e)
        {
            this.cbEditarCiudad.Visible = true;
            this.txtEdicionCiudad.Visible = false;
            this.btnEditarCiudad.Visible = false;
        }

        private void txtEditarDireccion_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar.Equals((char)Keys.Enter))
            {
                this.tsBtnGuardar_Click(this.tsBtnEdicionGuardar, new EventArgs());
            }
        }

        /// <summary>
        /// Carga los datos de un cliente en el formulario de edicion
        /// </summary>
        /// <param name="nit">Nit del cliente a editar</param>
        public void CargarClienteAEditar(string nit)
        {
            try
            {
                var miCliente = miBussinesCliente.ClienteAEditar(nit);
                txtEditarNit.Text = miCliente.NitCliente;
                nitActual = miCliente.NitCliente;
                txtEditarNombres.Text = miCliente.NombresCliente;
                idRegimen = miCliente.IdRegimen;
                txtEdicionRegimen.Text = miCliente.Regimen;
                IdTipo = miCliente.IdTipoCliente;
                txtDescripcionTipo.Text = miCliente.DescripcionTipo;
                IdClasificacion = miCliente.IdClasificacion;
                txtClasificacion.Text = miCliente.DescripcionClasifica; 
                txtEditarTelefono.Text = miCliente.TelefonoCliente;
                txtEditarCelular.Text = miCliente.CelularCliente;
                txtEditarEmail.Text = miCliente.EmailCliente;
                txtEdicionDepartamento.Text = miCliente.Departamento;
                idCiudad = miCliente.IdCiudad;
                txtEdicionCiudad.Text = miCliente.Ciudad;
                txtEditarDireccion.Text = miCliente.DireccionCliente;
                if (miCliente.IdDepartamento != 0)
                {
                    CargarCiudades(miCliente.IdDepartamento);
                }
                if (miCliente.EstadoCliente)
                {
                    txtEdicionEstado.Text = "Activo";
                    rbtnEdicionAlta.Checked = true;
                }
                else
                {
                    txtEdicionEstado.Text = "Inactivo";
                    rbtnEdicionBaja.Checked = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// Valida de nuevo todos los campos del formulario
        /// </summary>
        private void ValidacionGuardar()
        {
            txtNit_Validating(null, null);
            txtNombres_Validating(null, null);
            txtTelefono_Validating(null, null);
            txtCelular_Validating(null, null);
            txtEmail_Validating(null, null);
            txtDireccion_Validating(null, null);
        }

        /// <summary>
        /// Carga un objeto Cliente con los datos del formulario y lo guarda en la base de datos.
        /// </summary>
        private void GuardarCliente()
        {
            DTO.Clases.Cliente cliente = new DTO.Clases.Cliente();
            cliente.NitCliente = nitActual;
            cliente.NitEditado = txtEditarNit.Text;
            cliente.NombresCliente = txtEditarNombres.Text;
            cliente.IdRegimen = idRegimen;
            cliente.IdTipoCliente = Convert.ToInt32(cbEditarTipo.SelectedValue);
            cliente.IdClasificacion = Convert.ToInt32(cbClasificacion.SelectedValue);
            cliente.TelefonoCliente = txtEditarTelefono.Text;
            cliente.CelularCliente = txtEditarCelular.Text;
            cliente.EmailCliente = txtEditarEmail.Text;
            cliente.DireccionCliente = txtEditarDireccion.Text;
            cliente.IdCiudad = idCiudad;
            if (rbtnEdicionBaja.Checked)
                cliente.EstadoCliente = false;
            try
            {
                miBussinesCliente.EditarCliente(cliente);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// Carga la lista de Regimen
        /// </summary>
        private void CargarRegimen()
        {
            try
            {
                cbEditarRegimen.DataSource = miBussinesRegimen.ListadoRegimen();
                cbEditarRegimen.SelectedValue = idRegimen;

                cbEditarTipo.DataSource = miBussinesCliente.Tipos();
                cbEditarTipo.SelectedValue = IdTipo;

                cbClasificacion.DataSource = miBussinesCliente.Clasificacion();
                cbClasificacion.SelectedValue = IdClasificacion;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// Cargar los departamentos de Colombia
        /// </summary>
        private void CargarDepartamentos()
        {

            try
            {
                cbEditarDepartamentos.DataSource = miBussinesDepartamento.ListadoDepartamentos();
                if (cbEditarDepartamentos.Items.Count != 0)
                {
                    int idDepartamento = Convert.ToInt32(cbEditarDepartamentos.SelectedValue);
                    CargarCiudades(idDepartamento);
                }
                else
                {
                    cbEditarCiudad.DataSource = null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// Cargar las ciudades segun el id del Departamento.
        /// </summary>
        /// <param name="idDepartamento"></param>
        private void CargarCiudades(int idDepartamento)
        {
            try
            {
                cbEditarCiudad.DataSource = miBussinesCiudad.ListaCiudadPorDepartamento(idDepartamento);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// Verifica si el cliente existe en la base de datos.
        /// </summary>
        /// <param name="nit"></param>
        /// <returns></returns>
        private bool ExisteCliente(string nit)
        {
            try
            {
                return miBussinesCliente.ExisteCliente(nit);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }

        
    }
}