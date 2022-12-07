using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BussinesLayer.Clases;
using DTO.Clases;
using Utilities;

namespace Aplicacion.Compras.Proveedor
{
    public partial class frmEditarProveedor : Form
    {
        #region Atributos Logica de negocio

        /// <summary>
        /// Objeto de Logica de Negocio de Proveedor
        /// </summary>
        private BussinesProveedor miBussinesProveedor;

        /// <summary>
        /// Objeto de Logia de Regimen
        /// </summary>
        private BussinesRegimen miBussinesRegimen;

        /// <summary>
        /// Objeto de logica de negocio de Departamentos.
        /// </summary>
        private BussinesDepartamento miBussinesDepartamento;

        /// <summary>
        /// Objeto de Logica de Negocio de Ciudad
        /// </summary>
        private BussinesCiudad miBussinesCiudad;

        /// <summary>
        /// Almacena el id de la ciudad en la edicion.
        /// </summary>
        private int idCiudad;

        /// <summary>
        /// Almacena el id de regimen en la edicion.
        /// </summary>
        private int idRegimen;

        /// <summary>
        /// Establece el valor del codigo del proveedor para validacion
        /// </summary>
        private int codigoUso;

        /// <summary>
        /// Establece el valor del nit del proveedor para validacion
        /// </summary>
        private string nitUso = "";

        /// <summary>
        /// Representa un objeto de tipo Proveedor
        /// </summary>
        private DTO.Clases.Proveedor proveedorEditado;

        #endregion

        #region Atributos de carga y tranferencia de datos

        /// <summary>
        /// Objeto de origen de datos de Contacto.
        /// </summary>
        private BindingList<ContactoDeProveedor> contacto;

        /// <summary>
        /// Objeto de origen de datos de Cuenta.
        /// </summary>
        private BindingList<Cuenta> cuenta;

        #endregion

        #region Atributos de Validacion

        /// <summary>
        /// Objeto de Error para mostra en el formulario.
        /// </summary>
        ErrorProvider miError = new ErrorProvider();

        /// <summary>
        /// Esablece el valor que indica si es una adicion de cuenta bancaria
        /// </summary>
        private bool adicionCuenta = false;

        /// <summary>
        /// Establece el valor que indica si es una  adicion de contacto
        /// </summary>
        private bool adicionContacto = false;

        /// <summary>
        /// Establece el valor del codigo original del proveedor en la base de datos.
        /// </summary>
        private int codigoAcutal = 0;

        /// <summary>
        /// Establece la condicion que indica que el usuario presiono el boton salir.
        /// </summary>
        private bool prestBtnSalir = false;

        /// <summary>
        /// Establece la condicion para Guadar los cambios.
        /// </summary>
        private bool
        codigoMatch = false,
        nitMatch = false,
        razonMatch = false,
        nombreMatch = false,
        descripcionMatch = false,
        indTelMatch = false,
        telefonoMatch = false,
        celularMatch = false,
        indFaxMatch = false,
        faxMatch = false,
        direccionMatch = false,
        emailMatch = false,
        webMatch = false;

        /// <summary>
        /// Representa un mensaje de Campo Requerido o Con formato incorrecto.
        /// </summary>
        private const string msnCodigoReq = "El campo Codigo es Requerido.",

        msnCodigoNoFormato = "El Codigo que ingreso tiene formato incorrecto.",

        msnCodigoExiste = "Ya existe este Codigo Asociado a un Proveedor. ",

        msnNitRequerido = "El campo Nit o Cedula es Requerido.",

        msnNitNoFormato = "El Nit o Cedula que ingreso tiene formato incorrecto.",

        msnNitExiste = "Ya existe este Nit o Cedula Asociado a un proveedor. ",

        msnRazonReq = "El campo Razon Social es requerido.",

        msnRazonNoFormato = "El nombre que ingreso tiene formato Incorrecto.",

        msnComercialFormato = "El nombre que ingreso tiene formato Incorrecto.",

        msnDescripcionFormato = "La descripcion que ingreso tiene formato Incorrecto.",

        msnITelefonoFormato = "El indicativo del telefono tiene formato incorrecto.",

        msnTelefonoReq = "El telefono es requerido.",

        msnTelefonoFormato = "El numero de telefono tiene formato incorrecto.",

        msnCelularRequ = "El campo celular es requerido.",

        msnCelularFormato = "El numero de celular tiene formato incorrecto.",

        msnIFaxFormato = "El indicativo del fax tiene formato incorrecto",

        msnFaxRequerido = "El campo fax es requerido.",

        msnFaxFormato = "El numero de fax tiene formato incorrecto.",

        msnDireccionRequerida = "El campo direccion es requerido.",

        msnDireccionFormato = "La direccion que ingreso tiene formato incorrecto.",

        msnEmailFormato = "El email que ingreso tiene formato incorrecto.",

        msnWebFormato = "La pagina web que ingreso tiene formato incorrecto.";

        #endregion

        public frmEditarProveedor()
        {
            InitializeComponent();
        }

        private void frmEditarProveedor_Load(object sender, EventArgs e)
        {
            CargarRegimen();
            CargarDepartamentos();
                        
            this.dgvEditarCuentas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

            this.dgvEditarVendedor.AutoGenerateColumns = false;
            //this.dgvEditarVendedor.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

            CompletaEventos.Completa += new CompletaEventos.CompletaAccion(CompletaEventos_Completo);
        }

        private void frmEditarProveedor_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData.Equals(Keys.F2))
            {
                this.tsbtnEdicionGuardar_Click(this.tsbtnEdicionGuardar, new EventArgs());
            }
            else
            {
                if(e.KeyData.Equals(Keys.F3))
                {
                    this.lklblEditGenerar_LinkClicked(this.lklblEditGenerar, null);
                }
            }
        }

        /// <summary>
        /// Carga toda la Infomacion de un Proveedor en los campos correspondientes.
        /// </summary>
        /// <param name="codigo">Codigo del proveedor a cargar.</param>
        public void CargarProveedorAEditar(int codigo)
        {
            try
            {
                miBussinesProveedor = new BussinesProveedor();
                var miProveedor = miBussinesProveedor.ProveedorAEditar(codigo);
                txtEditarCodigo.Text = Convert.ToString(miProveedor.CodigoInternoProveedor);
                codigoAcutal = miProveedor.CodigoInternoProveedor;
                codigoUso = miProveedor.CodigoInternoProveedor;
                txtEditarNit.Text = miProveedor.NitProveedor;
                nitUso = miProveedor.NitProveedor;
                idRegimen = miProveedor.IdRegimen;
                txtEditarRegimen.Text = miProveedor.Regimen;
                txtEditarRazon.Text = miProveedor.RazonSocialProveedor;
                txtEditarNombreCom.Text = miProveedor.NombreComercialProveedor;
                txtEditarDescripcion.Text = miProveedor.DescripcionProveedor;
                txtEditarIndicativoTel.Text = miProveedor.IndicativoTelefono;
                txtEditarTelefono.Text = miProveedor.TelefonoProveedor;
                txtEditarCelular.Text = miProveedor.CelularProveedor;
                txtEditarIndicativoFax.Text = miProveedor.IndicativoFax;
                txtEditarNumeroFax.Text = miProveedor.FaxProveedor;
                txtEditarDireccion.Text = miProveedor.DireccionProveedor;
                txtEditarDepartamento.Text = miProveedor.Departamento;
                idCiudad = miProveedor.IdCiudad;
                txtEditarCiudad.Text = miProveedor.Ciudad;
                txtEditarEmail.Text = miProveedor.EmailProveedor;
                txtEditarPaginaWeb.Text = miProveedor.WebProveedor;
                if (miProveedor.EstadoProveedor)
                {
                    txtEditarEstado.Text = "Activo";
                    this.rbtnAlta.Checked = true;
                }
                else
                {
                    txtEditarEstado.Text = "Inactivo";
                    this.rbtnBaja.Checked = true;
                }
                if (miProveedor.IdDepartamento != 0)
                {
                    CargarCiudad(miProveedor.IdDepartamento);
                }
                this.cuenta = miProveedor.ListadoCuenta;
                this.dgvEditarCuentas.DataSource = this.cuenta;

                this.contacto = miProveedor.ListadoContactoProveedor;
                this.dgvEditarVendedor.DataSource = contacto;

                if (this.dgvEditarCuentas.RowCount == 0)
                    HabilitarEditarEliminar(false);
                if (this.dgvEditarVendedor.RowCount == 0)
                    HabilitarEditarEliminarContacto(false);

                AcomodarGridViewCuenta();
                AcomodoarGridViewContacto();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void lklblEditGenerar_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                miBussinesProveedor = new BussinesProveedor();
                txtEditarCodigo.Text = Convert.ToString(miBussinesProveedor.ObtenerCodigoConsecutivo());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message , "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEditarRegimen_Click(object sender, EventArgs e)
        {
            this.txtEditarRegimen.Visible = false;
            this.cbEditarRegimen.Location = new System.Drawing.Point(666, 25);
            this.cbEditarRegimen.Visible = true;
            this.btnEditarRegimen.Visible = false;
        }

        private void cbEditarRegimen_SelectionChangeCommitted(object sender, EventArgs e)
        {
            idRegimen = Convert.ToInt32(this.cbEditarRegimen.SelectedValue);
        }

        private void btnEditarDepartamento_Click(object sender, EventArgs e)
        {
            this.txtEditarDepartamento.Visible = false;
            this.cbEditarDepartamento.Visible = true;
            this.btnEditarDepartamento.Visible = false;

            this.txtEditarCiudad.Visible = false;
            this.cbEditarCiudad.Visible = true;
            this.btnEditarCiudad.Visible = false;
        }

        private void cbEditarDepartamento_SelectionChangeCommitted(object sender, EventArgs e)
        {
            int idDepartamento = Convert.ToInt32( this.cbEditarDepartamento.SelectedValue );
            CargarCiudad(idDepartamento);
        }

        private void btnEditarCiudad_Click(object sender, EventArgs e)
        {
            this.txtEditarCiudad.Visible = false;
            this.cbEditarCiudad.Visible = true;
            this.btnEditarCiudad.Visible = false;
        }

        private void cbEditarCiudad_SelectionChangeCommitted(object sender, EventArgs e)
        {
            idCiudad = Convert.ToInt32(this.cbEditarCiudad.SelectedValue);
        }

        private void btnAgregarInformacionBancaria_Click(object sender, EventArgs e)
        {
            Configuracion.CuentaBancaria.frmCuentaBancaria frmCuenta =
                new Configuracion.CuentaBancaria.frmCuentaBancaria();
            frmCuenta.edicion = true;
            adicionCuenta = true;
            frmCuenta.idCuenta = 0;
            frmCuenta.Show();
        }

        private void btnEditarCuenta_Click(object sender, EventArgs e)
        {
            DataGridViewRow r =
                this.dgvEditarCuentas.Rows[this.dgvEditarCuentas.CurrentCell.RowIndex];

            Configuracion.CuentaBancaria.frmCuentaBancaria frmCuenta =
                new Configuracion.CuentaBancaria.frmCuentaBancaria();

            frmCuenta.idCuenta = Convert.ToInt32(r.Cells["Column10"].Value);
            frmCuenta.idTipoCuenta = Convert.ToInt32(r.Cells["Column12"].Value);
            frmCuenta.TxtEditarTipoCuenta.Text = Convert.ToString(r.Cells["Column2"].Value);
            var numero = Convert.ToString(r.Cells["Column1"].Value);
            frmCuenta.txtNumeroCuenta.Text = numero;
            frmCuenta.numeroCuenta = numero;
            frmCuenta.txtTitularCuenta.Text = Convert.ToString(r.Cells["Column3"].Value);
            frmCuenta.txtBanco.Text = Convert.ToString(r.Cells["Column4"].Value);

            frmCuenta.TxtEditarTipoCuenta.Visible = true;
            frmCuenta.CbTipoCuenta.Visible = false;
            frmCuenta.btnEditarTipoCuenta.Visible = true;
            frmCuenta.edicion = true;
            adicionCuenta = false;
            frmCuenta.Show();
        }

        private void btnEliminarCuenta_Click(object sender, EventArgs e)
        {
            DialogResult rta = MessageBox.Show
              ("¿Realmente desea eliminar el registro?", "Proveedor",
              MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (rta == DialogResult.Yes)
            {
                this.dgvEditarCuentas.BeginEdit(true);
                this.dgvEditarCuentas.Rows.RemoveAt(this.dgvEditarCuentas.CurrentCell.RowIndex);
                if (this.dgvEditarCuentas.CurrentCell == null)
                {
                    HabilitarEditarEliminar(false);
                }
                this.dgvEditarCuentas.EditMode = DataGridViewEditMode.EditProgrammatically;
            }
        }

        private void btnAgregarInformacionVendedor_Click(object sender, EventArgs e)
        {
            ContactoProveedor.frmContactoProveedor frmContacto =
                new ContactoProveedor.frmContactoProveedor();
            frmContacto.BtnExtAceptar.Visible = true;
            frmContacto.BtnExtCancelar.Visible = true;
            frmContacto.TsMenuContato.Visible = false;
            frmContacto.idContacto = 0;
            frmContacto.edicion = true;
            adicionContacto = true;
            frmContacto.Show();
        }

        private void btnEditarVendedor_Click(object sender, EventArgs e)
        {
            DataGridViewRow r =
                this.dgvEditarVendedor.Rows[this.dgvEditarVendedor.CurrentCell.RowIndex];
            ContactoProveedor.frmContactoProveedor frmContacto =
                new ContactoProveedor.frmContactoProveedor();
            frmContacto.idContacto = Convert.ToInt32(r.Cells[0].Value);
            var cedula = Convert.ToInt32(r.Cells[1].Value); ;
            frmContacto.txtCedula.Text = Convert.ToString(cedula);
            frmContacto.cedulaContacto = cedula;
            frmContacto.txtNombres.Text = Convert.ToString(r.Cells[2].Value);
            frmContacto.txtTelefono.Text = Convert.ToString(r.Cells[3].Value);
            frmContacto.txtCelular.Text = Convert.ToString(r.Cells[4].Value);
            frmContacto.txtEmail.Text = Convert.ToString(r.Cells[5].Value);
            frmContacto.txtEditarEstado.Text = Convert.ToString(r.Cells[6].Value);
            if (frmContacto.txtEditarEstado.Text.Equals("Activo"))
            {
                frmContacto.rbtnAlta.Checked = true;
            }
            else
            {
                frmContacto.rbtnBaja.Checked = true;
            }

            frmContacto.BtnExtAceptar.Visible = true;
            frmContacto.BtnExtAceptar.Location = new Point(41, 318);
            frmContacto.BtnExtCancelar.Visible = true;
            frmContacto.BtnExtCancelar.Location = new Point(152, 318);
            frmContacto.panelEditarEstado.Visible = true;
            frmContacto.TsMenuContato.Visible = false;
            frmContacto.edicion = true;
            adicionContacto = false;
            frmContacto.Show();

            //MessageBox.Show(Convert.ToString(frmContacto.idContacto));
        }

        private void btnEliminarVendedor_Click(object sender, EventArgs e)
        {
            DialogResult rta = MessageBox.Show
              ("¿Realmente desea eliminar el registro?", "Proveedor",
               MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (rta == DialogResult.Yes)
            {
                this.dgvEditarVendedor.BeginEdit(true);
                this.dgvEditarVendedor.Rows.RemoveAt(this.dgvEditarVendedor.CurrentCell.RowIndex);
                if (this.dgvEditarVendedor.CurrentCell == null)
                {
                    HabilitarEditarEliminarContacto(false);
                }
                this.dgvEditarVendedor.EditMode = DataGridViewEditMode.EditProgrammatically;
            }
        }

        private void tsbtnEdicionGuardar_Click(object sender, EventArgs e)
        {
            ValidacionParaGuardar();
            if (codigoMatch &&
                nitMatch &&
                razonMatch &&
                nombreMatch &&
                descripcionMatch &&
                indTelMatch &&
                telefonoMatch &&
                celularMatch &&
                indFaxMatch &&
                faxMatch &&
                direccionMatch &&
                emailMatch &&
                webMatch)
            {
                CargarProveedorAEditar();
                try
                {
                    miBussinesProveedor = new BussinesProveedor();
                    miBussinesProveedor.EditarProveedor(this.proveedorEditado);
                    MessageBox.Show("Los cambio se guardaron con exito.");
                    CompletaEventos.CapturaEvento("Edicion");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void tsBtnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult rta = MessageBox.Show
              ("¿Desea guardar los cambios?","Proveedor",MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information);
            if (rta == DialogResult.Yes)
            {
                tsbtnEdicionGuardar_Click(null, null);
                if (codigoMatch &&
                nitMatch &&
                razonMatch &&
                nombreMatch &&
                descripcionMatch &&
                indTelMatch &&
                telefonoMatch &&
                celularMatch &&
                indFaxMatch &&
                faxMatch &&
                direccionMatch &&
                emailMatch &&
                webMatch)
                {
                    prestBtnSalir = true;
                    this.Close();
                }
                else
                    prestBtnSalir = false;
            }
            if (rta == DialogResult.No)
            {
                prestBtnSalir = true;
                this.Close();
            }
        }

        private void frmEditarProveedor_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!prestBtnSalir)
            {
                DialogResult rta = MessageBox.Show
                   ("¿Desea guardar los cambios?", "Proveedor", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information);
                if (rta == DialogResult.Yes)
                {
                    tsbtnEdicionGuardar_Click(null, null);
                    if (codigoMatch &&
                        nitMatch &&
                        razonMatch &&
                        nombreMatch &&
                        descripcionMatch &&
                        indTelMatch &&
                        telefonoMatch &&
                        celularMatch &&
                        indFaxMatch &&
                        faxMatch &&
                        direccionMatch &&
                        emailMatch &&
                        webMatch)
                        e.Cancel = false;
                    else
                        e.Cancel = true;
                }
                if (rta == DialogResult.No)
                    e.Cancel = false;
                if (rta == DialogResult.Cancel)
                    e.Cancel = true;
            }
        }
        
        /// <summary>
        /// Cargar el ComboBox cbEditarRegimen con el listado de Regimen.
        /// </summary>
        private void CargarRegimen()
        {
            try
            {
                miBussinesRegimen = new BussinesRegimen();
                this.cbEditarRegimen.DataSource = miBussinesRegimen.ListadoRegimen();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message , "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Carga el ComboBox cbEditarDepartamento con el listado de los Departamentos
        /// </summary>
        private void CargarDepartamentos()
        {
            try
            {
                miBussinesDepartamento = new BussinesDepartamento();
                this.cbEditarDepartamento.DataSource = miBussinesDepartamento.ListadoDepartamentos();
                if (cbEditarDepartamento.Items.Count != 0)
                {
                    int idDepartamento = Convert.ToInt32(this.cbEditarDepartamento.SelectedValue);
                    CargarCiudad(idDepartamento);
                }
                else
                {
                    this.cbEditarCiudad.DataSource = null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Carga el ComboBox cbEditarCiudad con el listado de las ciudades segun el departemento.
        /// </summary>
        /// <param name="idDepartamento"></param>
        private void CargarCiudad(int idDepartamento)
        {
            try
            {
                miBussinesCiudad = new BussinesCiudad();
                cbEditarCiudad.DataSource = miBussinesCiudad.ListaCiudadPorDepartamento(idDepartamento);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message , "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Acomoda las culumnas necesaria dl datagridview de cuentas
        /// </summary>
        private void AcomodarGridViewCuenta()
        {
            this.dgvEditarCuentas.Columns.Remove("CodigoInternoProveedor");
            this.dgvEditarCuentas.Columns.Remove("NitEmpresa");

            //this.dgvEditarCuentas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvEditarCuentas.AutoGenerateColumns = false;
        }

        /// <summary>
        /// Acomoda las culumnas necesarias del datagridview de contactos.
        /// </summary>
        private void AcomodoarGridViewContacto()
        {
            this.dgvEditarVendedor.Columns["IdContacto"].Visible = false;
            this.dgvEditarVendedor.Columns.Remove("CodigoInternoProveedor");
            this.dgvEditarVendedor.Columns.Remove("EstadoContacto");

            this.dgvEditarVendedor.AutoGenerateColumns = false;
            this.dgvEditarVendedor.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        }

        /// <summary>
        /// Establece el estado de edicion o eliminacion de los botones de cuenta.
        /// </summary>
        /// <param name="estado"></param>
        private void HabilitarEditarEliminar(bool estado)
        {
            this.btnEditarCuenta.Enabled = estado;
            this.btnEliminarCuenta.Enabled = estado;
        }

        /// <summary>
        /// Establece el estado de edicion o eliminacion de los botones de cuenta.
        /// </summary>
        /// <param name="estado"></param>
        private void HabilitarEditarEliminarContacto(bool estado)
        {
            this.btnEditarVendedor.Enabled = estado;
            this.btnEliminarVendedor.Enabled = estado;
        }

        private void txtEditarCodigo_Validating(object sender, CancelEventArgs e)
        {
            if (!Validacion.EsVacio(txtEditarCodigo, miError, msnCodigoReq))
            {
                if (Validacion.ConFormato(Validacion.TipoValidacion.Numeros, txtEditarCodigo, miError, msnCodigoNoFormato))
                {
                    codigoMatch = true;
                    var codigoTemp = Convert.ToInt32(txtEditarCodigo.Text);
                    if (ExisteCodigo(codigoTemp) && codigoTemp != codigoUso )
                    {
                        miError.SetError(txtEditarCodigo, msnCodigoExiste);
                        codigoMatch = false;
                    }
                    else
                    {
                        miError.SetError(txtEditarCodigo, null);
                        codigoMatch = true;
                    }                        
                }
                else
                    codigoMatch = false;
            }
            else
                codigoMatch = false;
        }

        private void txtEditarNit_Validating(object sender, CancelEventArgs e)
        {
            if (!Validacion.EsVacio(txtEditarNit, miError, msnNitRequerido))
            {
                if (Validacion.ConFormato(Validacion.TipoValidacion.NumeroGuion, txtEditarNit, miError, msnNitNoFormato))
                {
                    //nitMatch = true;
                    if (ExisteNit(txtEditarNit.Text) && nitUso != txtEditarNit.Text)
                    {
                        miError.SetError(txtEditarNit, msnNitExiste);
                        nitMatch = false;
                    }
                    else
                    {
                        miError.SetError(txtEditarNit, null);
                        nitMatch = true;
                    }
                }
                else
                    nitMatch = false;
            }
            else
                nitMatch = false;
        }

        private void txtEditarRazon_Validating(object sender, CancelEventArgs e)
        {
            if (!Validacion.EsVacio(txtEditarRazon, miError, msnRazonReq))
            {
                //guardar = true;
                if (Validacion.ConFormato
                    (Validacion.TipoValidacion.PalabrasNumeroCaracter, txtEditarRazon, miError, msnRazonNoFormato))
                {
                    razonMatch = true;
                }
                else
                    razonMatch = false;
            }
            else
                razonMatch = false;
        }

        private void txtEditarNombreCom_Validating(object sender, CancelEventArgs e)
        {
            if (!String.IsNullOrEmpty(txtEditarNombreCom.Text))
            {
                if (Validacion.ConFormato
                    (Validacion.TipoValidacion.PalabrasNumeroCaracter, txtEditarNombreCom, miError, msnComercialFormato))
                {
                    nombreMatch = true;
                }
                else
                    nombreMatch = false;
            }
            else
            {
                miError.SetError(txtEditarNombreCom, null);
                nombreMatch = true;
            }
        }

        private void txtEditarDescripcion_Validating(object sender, CancelEventArgs e)
        {
            if (!String.IsNullOrEmpty(txtEditarDescripcion.Text))
            {
                if (Validacion.ConFormato
                    (Validacion.TipoValidacion.PalabrasNumeroCaracter, txtEditarDescripcion, miError, msnDescripcionFormato))
                {
                    descripcionMatch = true;
                }
                else
                    descripcionMatch = false;
            }
            else
            {
                miError.SetError(txtEditarDescripcion, null);
                descripcionMatch = true;
            }
        }

        private void txtEditarIndicativoTel_Validating(object sender, CancelEventArgs e)
        {
            if (!String.IsNullOrEmpty(txtEditarIndicativoTel.Text))
            {
                if (Validacion.ConFormato
                    (Validacion.TipoValidacion.Numeros, txtEditarIndicativoTel, miError, msnITelefonoFormato))
                {
                    indTelMatch = true;
                }
                else
                    indTelMatch = false;
            }
            else
            {
                miError.SetError(txtEditarIndicativoTel, null);
                indTelMatch = true;
            }
        }

        private void txtEditarTelefono_Validating(object sender, CancelEventArgs e)
        {
            if (!String.IsNullOrEmpty(txtEditarTelefono.Text))
            {
                if (Validacion.ConFormato
                    (Validacion.TipoValidacion.NumeroEspacionGuion, txtEditarTelefono, miError, msnTelefonoFormato))
                {
                    telefonoMatch = true;
                }
                else
                    telefonoMatch = false;
            }
            else
            {
                if (!String.IsNullOrEmpty(txtEditarIndicativoTel.Text))
                {
                    miError.SetError(txtEditarTelefono, msnTelefonoReq);
                    telefonoMatch = false;
                }
                else
                {
                    miError.SetError(txtEditarTelefono, null);
                    telefonoMatch = true;
                }
            }
        }

        private void txtEditarCelular_Validating(object sender, CancelEventArgs e)
        {
            if (!Validacion.EsVacio(txtEditarCelular, miError, msnCelularRequ))
            {
                if (Validacion.ConFormato
                    (Validacion.TipoValidacion.NumeroEspacio, txtEditarCelular, miError, msnCelularFormato))
                {
                    celularMatch = true;
                }
                else
                    celularMatch = false;
            }
            else
                celularMatch = false;
        }

        private void txtEditarIndicativoFax_Validating(object sender, CancelEventArgs e)
        {
            if (!String.IsNullOrEmpty(txtEditarIndicativoFax.Text))
            {
                if (Validacion.ConFormato
                    (Validacion.TipoValidacion.Numeros, txtEditarIndicativoFax, miError, msnIFaxFormato))
                {
                    indFaxMatch = true;
                }
                else
                    indFaxMatch = false;
            }
            else
            {
                miError.SetError(txtEditarIndicativoFax, null);
                indFaxMatch = true;
            }
        }

        private void txtEditarNumeroFax_Validating(object sender, CancelEventArgs e)
        {
            if (!String.IsNullOrEmpty(txtEditarNumeroFax.Text))
            {
                if (Validacion.ConFormato
                    (Validacion.TipoValidacion.NumeroEspacionGuion, txtEditarNumeroFax, miError, msnFaxFormato))
                {
                    faxMatch = true;
                }
                else
                    faxMatch = false;
            }
            else
            {
                if (!String.IsNullOrEmpty(txtEditarIndicativoFax.Text))
                {
                    miError.SetError(txtEditarNumeroFax, msnFaxRequerido);
                    faxMatch = false;
                }
                else
                {
                    miError.SetError(txtEditarNumeroFax, null);
                    faxMatch = true;
                }
            }
        }

        private void txtEditarDireccion_Validating(object sender, CancelEventArgs e)
        {
            if (!Validacion.EsVacio(txtEditarDireccion, miError, msnDireccionRequerida))
            {
                if (Validacion.ConFormato
                    (Validacion.TipoValidacion.Domicilio, txtEditarDireccion, miError, msnDireccionFormato))
                {
                    direccionMatch = true;
                }
                else
                    direccionMatch = false;
            }
            else
                direccionMatch = false;
        }

        private void txtEditarEmail_Validating(object sender, CancelEventArgs e)
        {
            if (!String.IsNullOrEmpty(txtEditarEmail.Text))
            {
                if (Validacion.ConFormato
                  (Validacion.TipoValidacion.Email, txtEditarEmail, miError, msnEmailFormato))
                {
                    emailMatch = true;
                }
                else
                {
                    emailMatch = false;
                }
            }
            else
            {
                miError.SetError(txtEditarEmail, null);
                emailMatch = true;
            }
        }

        private void txtEditarPaginaWeb_Validating(object sender, CancelEventArgs e)
        {
            if (!String.IsNullOrEmpty(txtEditarPaginaWeb.Text))
            {
                if (Validacion.ConFormato
                  (Validacion.TipoValidacion.Url, txtEditarPaginaWeb, miError, msnWebFormato))
                {
                    webMatch = true;
                }
                else
                    webMatch = false;
            }
            else
            {
                miError.SetError(txtEditarPaginaWeb, null);
                webMatch = true;
            }
        }

        /// <summary>
        /// Valida de nuevo todos los campos
        /// </summary>
        private void ValidacionParaGuardar()
        {
            txtEditarCodigo_Validating(null, null);
            txtEditarNit_Validating(null, null);
            txtEditarRazon_Validating(null, null);
            txtEditarNombreCom_Validating(null, null);
            txtEditarDescripcion_Validating(null, null);
            txtEditarIndicativoTel_Validating(null, null);
            txtEditarTelefono_Validating(null, null);
            txtEditarCelular_Validating(null, null);
            txtEditarIndicativoFax_Validating(null, null);
            txtEditarNumeroFax_Validating(null, null);
            txtEditarDireccion_Validating(null, null);
            txtEditarEmail_Validating(null, null);
            txtEditarPaginaWeb_Validating(null, null);
        }
        /// <summary>
        /// Verifica si existe el codigo del proveedor en la base de datos.
        /// </summary>
        /// <param name="codigo"></param>
        /// <returns></returns>
        private bool ExisteCodigo(int codigo)
        {
            try
            {
                miBussinesProveedor = new BussinesProveedor();
                return miBussinesProveedor.ExisteProveedorConCodigo(codigo);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }

        /// <summary>
        /// Verifica si existe el Nit del Proveedor en la base de datos.
        /// </summary>
        /// <param name="codigo">Nit a Verificar.</param>
        /// <returns></returns>
        private bool ExisteNit(string nit)
        {
            try
            {
                miBussinesProveedor = new BussinesProveedor();
                return miBussinesProveedor.ExisteProveedorConNit(nit);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }

        /// <summary>
        /// Carga la informacion del proveedor al objeto proveedorEditado
        /// </summary>
        private void CargarProveedorAEditar()
        {
            this.proveedorEditado = new DTO.Clases.Proveedor();
            this.proveedorEditado.CodigoInternoProveedor = codigoAcutal;
            this.proveedorEditado.CodigoEditadoProveedor = Convert.ToInt32(txtEditarCodigo.Text);
            this.proveedorEditado.NitProveedor = txtEditarNit.Text;
            this.proveedorEditado.IdRegimen = idRegimen;
            this.proveedorEditado.RazonSocialProveedor = txtEditarRazon.Text;
            this.proveedorEditado.NombreComercialProveedor = txtEditarNombreCom.Text;
            this.proveedorEditado.DescripcionProveedor = txtEditarDescripcion.Text;
            this.proveedorEditado.TelefonoProveedor = txtEditarIndicativoTel.Text + txtEditarTelefono.Text;
            this.proveedorEditado.CelularProveedor = txtEditarCelular.Text;
            this.proveedorEditado.FaxProveedor = txtEditarIndicativoFax.Text + txtEditarNumeroFax.Text;
            this.proveedorEditado.DireccionProveedor = txtEditarDireccion.Text;
            this.proveedorEditado.IdCiudad = idCiudad;
            this.proveedorEditado.EmailProveedor = txtEditarEmail.Text;
            this.proveedorEditado.WebProveedor = txtEditarPaginaWeb.Text;
            if (rbtnBaja.Checked)
                this.proveedorEditado.EstadoProveedor = false;
            foreach (Cuenta c in cuenta)
            {
                c.CodigoInternoProveedor = Convert.ToInt32(txtEditarCodigo.Text);
            }
            foreach (ContactoDeProveedor cont in contacto)
            {
                cont.CodigoInternoProveedor = Convert.ToInt32(txtEditarCodigo.Text);
            }
            this.proveedorEditado.ListadoCuenta = cuenta;
            this.proveedorEditado.ListadoContactoProveedor = contacto;
        }

        /// <summary>
        /// Completa los eventos relacionados a una tranferencia de datos desde otros formularios.
        /// </summary>
        /// <param name="args"></param>
        void CompletaEventos_Completo(CompletaArgumentosDeEvento args)
        {
            try
            {
                Cuenta miCuenta = (Cuenta)args.MiObjeto;
                if (!adicionCuenta)
                {
                    btnEliminarCuenta_Click(null, null);
                }
                this.dgvEditarCuentas.DataSource = null;
                cuenta.Add(miCuenta);
                this.dgvEditarCuentas.DataSource = cuenta;
                if (this.dgvEditarCuentas.CurrentCell == null)
                    HabilitarEditarEliminar(false);
                else
                    HabilitarEditarEliminar(true);
                AcomodarGridViewCuenta();
            }
            catch{}

            try
            {
                ContactoDeProveedor contactoEditado = (ContactoDeProveedor)args.MiObjeto;
                if (!adicionContacto)
                {
                    btnEliminarVendedor_Click(null, null);
                }
                this.dgvEditarVendedor.DataSource = null;
                contacto.Add(contactoEditado);
                this.dgvEditarVendedor.DataSource = contacto;
                if (this.dgvEditarVendedor.CurrentCell == null)
                {
                    HabilitarEditarEliminarContacto(false);
                }
                else
                {
                    HabilitarEditarEliminarContacto(true);
                }
                AcomodoarGridViewContacto();
            }
            catch { }
        }
    }
}