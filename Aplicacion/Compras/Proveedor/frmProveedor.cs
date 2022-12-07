using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Aplicacion.Compras.Proveedor;
using DTO.Clases;
using BussinesLayer.Clases;
using Utilities;
using Aplicacion.Configuracion.CuentaBancaria;

namespace Aplicacion.Compras.Proveedor
{
    public partial class frmProveedor : Form
    {
        /// <summary>
        /// Define los atributos de logica necesaria para las tranzaciones de Proveedor
        /// </summary>
        #region Atributos de Logica de Negocio

        private Empresa miEmpresa;

        private DTO.Clases.Proveedor miProveedor;

        private BussinesEmpresa miBussinesEmpresa;
        private BussinesRegimen miBussinesRegimen;
        private BussinesDepartamento miBussinesDepto;
        private BussinesCiudad miBussinesCiudad;
        private BussinesProveedor miBussinesProveedor;
        private BussinesBeneficio miBussinesBenefio;

        private CargarCriterioProveedor miCriterio;

        #endregion

        #region Crear Proveedor

        #region Atributos de extend Forms

        private frmCuentaBancaria formCuentaBanco;
        private ContactoProveedor.frmContactoProveedor formVendedor;
        private frmEditarProveedor editar;

        #endregion

        #region Atributos de Transferencia y Carga de Datos

        private TransferenciaCuenta miTransferenciaCuenta;
        private TransferenciaVendedor miTransferenciaVendedor;
        private BindingList<Cuenta> listaCuenta = new BindingList<Cuenta>();
        private BindingList<ContactoDeProveedor> listaVendedor = new BindingList<ContactoDeProveedor>();

        private DataSet miDataSet;

        private BindingSource proveedor = new BindingSource();
        private BindingSource contacto = new BindingSource();
        private BindingSource cuenta = new BindingSource();

        #endregion
        
        #region Atributos de Validacion

        public bool Extension = false;
        private bool Guardar = false,
        codigoMath = false,
        nitMath = false,
        razonMath = false,
        nombreMath = true,
        descripcionMath = true,
        indTelefonoMath = false,
        telefonoMath = false,
        celularMath = false,
        indFaxMath = false,
        faxMath = false,
        direccionMath = false,
        emailMath = false,
        webMath = false;

        private bool existeCodigo = false;
        private bool existeNit = false;

        /// <summary>
        /// Representa un objeto para mensajes de error en los formularios.
        /// </summary>
        private ErrorProvider miError = new ErrorProvider();

        /// <summary>
        /// Representa un objeto para validacion de datos.
        /// </summary>
        private Validacion miValidacion = new Validacion();

        /// <summary>
        /// Establece el valor que indica que el usuario presiono el boton Salir
        /// </summary>
        private bool salir = false;

        /// <summary>
        /// Obtiene o establece la condición que indica si se trata de una edición en otro from.
        /// </summary>
        public bool Edit = false;

        #region Atributos constantes

        /// <summary>
        /// Representa un mensaje de Campo Requerido o Incorrecto.
        /// </summary>
        private const string codigoRequerido = "El campo Codigo es Requerido.",

        codigoIncorrecto = "El Codigo tiene formato Incorrecto.",

        nitRequerido = "El campo Nit o Cedula es Requerido.",

        nitIncorrecto = "El Nit o Cedula tiene formato Incorrecto.",

        nombreRequerido = "El campo Nombre es Requerido.",

        nombreIncorrecto = "El Nombre tiene formato Incorrecto.",

        razonRequerida = "El campo Razon Social es Requerido.",

        razonIncorrecto = "La Razon Social tiene formato Incorrecto.",

        nComercialIncorrecto = "El nombre Comercial tiene formato Incorrecto.",

        descripcionIncorrecto = "La descripcion tiene formato Incorrecto.",

        telefonoIncorrecto = "El telefono tiene formato Incorrecto.",

        telefonoRequerido = "Debe ingresar un Numero de Telefono.",

        celularRequerido = "El campo Celular es Requerido.",

        celularIncorrecto = "El Celular tiene Formato Incorrecto.",

        faxIncorrecto = "El número de Fax tiene formato Incorrecto.",

        faxRequerido = "El numero de Fax es Requerido.",

        direccionRequerida = "El campo Direccion es Requerido.",

        direccionIncorrecta = "La Direccion tiene formato Incorrecto.",

        emailIncorrecto = "El Email tiene formato Incorrecto.",

        webIncorrecto = "La Pagina Web tiene formato Incorrecto.",
        
        noRegistros = "No hay registros para editar.";

        private const string msnSalir = "¿Desea guardar los cambios?";

        #endregion

        #endregion

        #region Consturctor

        public frmProveedor()
        {
            InitializeComponent();
            miBussinesEmpresa = new BussinesEmpresa();
            try
            {
                miEmpresa = miBussinesEmpresa.ObtenerEmpresa();
            }
            catch (Exception ex)
            {
                CustomControl.OptionPane.MessageError(ex.Message);
            }
        }

        #endregion

        #region Metodos de Eventos

        private void frmCrearProveedor_Load(object sender, EventArgs e)
        {
            this.btnActualizar.Visible = Convert.ToBoolean(AppConfiguracion.ValorSeccion("proveedor_beneficio"));

            CargarRegimen();

            CargarDepartamentos();

            this.miCriterio = new CargarCriterioProveedor();

            cbCriterio1.DataSource = miCriterio.Lista1;
            cbCriterio2.DataSource = miCriterio.Lista2;

            this.dgvDatosBancario.AutoGenerateColumns = false;
           //this.dgvDatosBancario.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

            this.dgvDatosVendedor.AutoGenerateColumns = false;
           // this.dgvDatosVendedor.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

            this.dgvListadoProveedor.AutoGenerateColumns = false;
            //this.dgvListadoProveedor.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

            proveedor.DataMember = "view_lista_proveedor";

            this.bnVendedor.BindingSource = contacto;

            this.bnCtaBanco.BindingSource = cuenta;

            CompletaEventos.Completa += new CompletaEventos.CompletaAccion(CompletaEventos_Completo);
        }

        private void lkbGenerar_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                miBussinesProveedor = new BussinesProveedor();
                txtCodigoInterno.Text = Convert.ToString(
                    miBussinesProveedor.ObtenerCodigoConsecutivo() );
                txtNitCedula.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message , "Error", MessageBoxButtons.OK , MessageBoxIcon.Error);
            }
        }

        private void cbDepartamento_SelectionChangeCommitted(object sender, EventArgs e)
        {
            int idDepartamento = Convert.ToInt32(this.cbDepartamento.SelectedValue);
            CargarCiudad(idDepartamento);
        }

        private void btnAgregarInformacionBancaria_Click(object sender, EventArgs e)
        {
            formCuentaBanco = new frmCuentaBancaria();
            formCuentaBanco.MdiParent = this.MdiParent;
            formCuentaBanco.Show();
        }

        private void btnEliminarCuenta_Click(object sender, EventArgs e)
        {
            this.dgvDatosBancario.BeginEdit(true);
            this.dgvDatosBancario.Rows.RemoveAt(this.dgvDatosBancario.CurrentCell.RowIndex);
            if (this.dgvDatosBancario.CurrentCell == null)
            {
                this.btnEliminarCuenta.Enabled = false;
            }
            this.dgvDatosBancario.EditMode = DataGridViewEditMode.EditProgrammatically;
        }

        private void btnAgregarInformacionVendedor_Click(object sender, EventArgs e)
        {
            formVendedor = new ContactoProveedor.frmContactoProveedor();
            formVendedor.MdiParent = this.MdiParent;
            formVendedor.BtnExtAceptar.Visible = true;
            formVendedor.BtnExtCancelar.Visible = true;
            formVendedor.TsMenuContato.Visible = false;
            formVendedor.Show();
        }

        private void btnEliminarVendedor_Click(object sender, EventArgs e)
        {
            this.dgvDatosVendedor.BeginEdit(true);
            this.dgvDatosVendedor.Rows.RemoveAt(this.dgvDatosVendedor.CurrentCell.RowIndex);
            if (this.dgvDatosVendedor.CurrentCell == null)
            {
                this.btnEliminarVendedor.Enabled = false;
            }
            this.dgvDatosVendedor.EditMode = DataGridViewEditMode.EditProgrammatically;
        }

        private void tsbtnGuardar_Click(object sender, EventArgs e)
        {
            ValidacionParaGuardar();
            if (codigoMath && 
                !existeCodigo && 
                !existeNit &&
                nitMath &&
                razonMath &&
                nombreMath &&
                descripcionMath &&
                indTelefonoMath &&
                telefonoMath &&
                celularMath &&
                indFaxMath &&
                faxMath &&
                direccionMath &&
                emailMath &&
                webMath)
            {
                CargarProveedor();
                try
                {
                    miBussinesProveedor = new BussinesProveedor();
                    miBussinesProveedor.InsertarProveedor(miProveedor);

                    /**
                    var miBussinesCliente = new BussinesCliente();
                    miBussinesCliente.InsertarCliente(new Cliente
                    {
                        IdRegimen = miProveedor.IdRegimen,
                        NitCliente = miProveedor.NitProveedor,
                        NombresCliente = miProveedor.RazonSocialProveedor,
                        CelularCliente = miProveedor.CelularProveedor,
                        IdCiudad = Convert.ToInt32(this.cbCiudad.SelectedValue),
                        DireccionCliente = this.txtDireccion.Text
                    });
                    */

                    miBussinesBenefio = new BussinesBeneficio();
                    miBussinesBenefio.Ingresar(new Cliente
                    {
                        IdRegimen = miProveedor.IdRegimen,
                        NitCliente = miProveedor.NitProveedor,
                        NombresCliente = miProveedor.RazonSocialProveedor,
                        CelularCliente = miProveedor.CelularProveedor,
                        IdCiudad = Convert.ToInt32(this.cbCiudad.SelectedValue),
                        DireccionCliente = this.txtDireccion.Text
                    });
                    
                    MessageBox.Show
                        ("La información ha sido guardada.", "Proveedor", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LimpiarCampos();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }            
        }

        private void tsbtnLimpiarCampos_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
        }

        private void tsbtnSalir_Click(object sender, EventArgs e)
        {
            DialogResult rta = MessageBox.Show
                (msnSalir, "Proveedor", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);
            if (rta == DialogResult.Yes)
            {
                tsbtnGuardar_Click(null, null);
                if (codigoMath &&
                    !existeCodigo &&
                    !existeNit &&
                    nitMath &&
                    razonMath &&
                    nombreMath &&
                    descripcionMath &&
                    indTelefonoMath &&
                    telefonoMath &&
                    celularMath &&
                    indFaxMath &&
                    faxMath &&
                    direccionMath &&
                    emailMath &&
                    webMath)
                {
                    salir = true;
                    this.Close();
                }
                else
                    salir = false;
            }
            if (rta == DialogResult.No)
            {
                salir = true;
                this.Close();
            }
        }

        void CompletaEventos_Completo(CompletaArgumentosDeEvento args)
        {
            try
            {
                miTransferenciaCuenta = (TransferenciaCuenta)args.MiObjeto;
                Cuenta c = new Cuenta();
                //c.CodigoInternoProveedor = Convert.ToInt32( txtCodigoInterno.Text );
                c.IdTipoCuenta = miTransferenciaCuenta.IdTipoCuenta;
                c.TipoCuenta = miTransferenciaCuenta.TipoCuenta;
                c.NumeroCuenta = miTransferenciaCuenta.NumeroCuenta;
                c.TitularCuenta = miTransferenciaCuenta.TitularCuenta;
                c.BancoCuenta = miTransferenciaCuenta.NombreBanco;
                listaCuenta.Add(c);
                this.dgvDatosBancario.DataSource = null;
                this.dgvDatosBancario.DataSource = listaCuenta;
                this.btnEliminarCuenta.Enabled = true;
            }
            catch { }

            try
            {
                miTransferenciaVendedor = (TransferenciaVendedor)args.MiObjeto;
                ContactoDeProveedor vendedor = new ContactoDeProveedor();
                //vendedor.CodigoInternoProveedor = Convert.ToInt32( txtCodigoInterno.Text );
                vendedor.CedulaContacto = miTransferenciaVendedor.CedulaContacto;
                vendedor.NombreContacto = miTransferenciaVendedor.NombreContacto;
                vendedor.TelefonoContacto = miTransferenciaVendedor.TelefonoContacto;
                vendedor.CelularContacto = miTransferenciaVendedor.CelularContacto;
                vendedor.EmailContacto = miTransferenciaVendedor.EmailContacto;
                listaVendedor.Add(vendedor);
                this.dgvDatosVendedor.DataSource = null;
                this.dgvDatosVendedor.DataSource = listaVendedor;
                this.btnEliminarVendedor.Enabled = true;
            }
            catch { }

            try
            {
                string edicion = (string)args.MiObjeto;
                if (edicion.Equals("Edicion"))
                    tsbtnListarTodos_Click(null, null);
            }
            catch { }

        }

        #endregion

        #region Metodos de Form_Load

        /// <summary>
        /// Carga un ComboBox con el listado del Regimen
        /// </summary>
        private void CargarRegimen()
        {
            try
            {
                miBussinesRegimen = new BussinesRegimen();
                this.cbRegimen.DataSource = miBussinesRegimen.ListadoRegimen();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void CargarDepartamentos()
        {
            try
            {
                miBussinesDepto = new BussinesDepartamento();
                cbDepartamento.DataSource = miBussinesDepto.ListadoDepartamentos();
                cbDepartamento.SelectedValue = miEmpresa.Departamento.IdDepartamento;
                if (cbDepartamento.Items.Count != 0)
                {
                    int idDepartamento = Convert.ToInt32(this.cbDepartamento.SelectedValue);
                    CargarCiudad(idDepartamento);
                }
                else
                {
                    cbCiudad.DataSource = null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show( ex.Message );
            }
        }

        private void CargarCiudad( int idDepartamento )
        {
            try
            {
                miBussinesCiudad = new BussinesCiudad();
                cbCiudad.DataSource = miBussinesCiudad.ListaCiudadPorDepartamento(idDepartamento);
                cbCiudad.SelectedValue = miEmpresa.Ciudad.IdCiudad;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        #endregion

        #region Metodos de Validacion de Formulario

        private void txtCodigoInterno_Validating(object sender, CancelEventArgs e)
        {
            if (!EsVacio(txtCodigoInterno, codigoRequerido))
            {
                //codigoMath = true;

                if (ConFormato(Validacion.TipoValidacion.Numeros, txtCodigoInterno, codigoIncorrecto))
                {
                    codigoMath = true;
                    if (ExisteCodigo(Convert.ToInt32(txtCodigoInterno.Text)))
                    {
                        miError.SetError(txtCodigoInterno, "Ya existe este Codigo Asociado a un Proveedor. ");
                        existeCodigo = true;
                    }
                    else
                    {
                        miError.SetError(txtCodigoInterno, null);
                        existeCodigo = false;
                    }
                }
                else
                {
                    codigoMath = false;
                }
            }
            else
                codigoMath = false;
        }

        private void txtNitCedula_Validating(object sender, CancelEventArgs e)
        {
            if (!EsVacio(txtNitCedula, nitRequerido))
            {
                nitMath = true;

                if (ConFormato(Validacion.TipoValidacion.NumeroGuion, txtNitCedula, nitIncorrecto))
                {
                    nitMath = true;

                    if (ExisteNit(txtNitCedula.Text))
                    {
                        miError.SetError(txtNitCedula, "Ya existe este Nit o Cedula Asociado a un proveedor. ");
                        existeNit = true;
                    }
                    else
                    {
                        miError.SetError(txtNitCedula, null);
                        existeNit = false;
                    }
                }
                else
                {
                    nitMath = false;
                }
            }
            else
                nitMath = false;
        }

        private void txtRazonSocial_Validating(object sender, CancelEventArgs e)
        {
            if (!EsVacio(txtRazonSocial, razonRequerida))
            {
                razonMath = true;

                /*if (ConFormato(Validacion.TipoValidacion.PalabrasNumeroCaracter, txtRazonSocial, razonIncorrecto))
                {
                    this.txtRazonSocial.Text = this.txtRazonSocial.Text.ToUpper();
                    razonMath = true;
                }
                else
                {
                    razonMath = false;
                }*/
            }
            else
                razonMath = false;
        }

        private void txtNombreComercial_Validating(object sender, CancelEventArgs e)
        {
           /* if (!String.IsNullOrEmpty(txtNombreComercial.Text))
            {
                if (ConFormato(Validacion.TipoValidacion.PalabrasNumeroCaracter, txtNombreComercial, nComercialIncorrecto))
                {
                    this.txtNombreComercial.Text = this.txtNombreComercial.Text.ToUpper();
                    nombreMath = true;
                }
                else
                {
                    nombreMath = false;
                }
            }
            else
            {
                miError.SetError(txtNombreComercial, null);
                nombreMath = true;
            }*/
        }

        private void txtDescripcion_Validating(object sender, CancelEventArgs e)
        {
          /*  if (!String.IsNullOrEmpty(txtDescripcion.Text))
            {
                if (ConFormato(Validacion.TipoValidacion.PalabrasNumeroCaracter, txtDescripcion, descripcionIncorrecto))
                {
                    descripcionMath = true;
                }
                else
                {
                    descripcionMath = false;
                }
            }
            else
            {
                miError.SetError(txtDescripcion, null);
                descripcionMath = true;
            }*/
            
        }

        private void txtIndicativoTel_Validating(object sender, CancelEventArgs e)
        {
            if (!String.IsNullOrEmpty(txtIndicativoTel.Text))
            {
                if (ConFormato(Validacion.TipoValidacion.Numeros, txtIndicativoTel, telefonoIncorrecto))
                {
                    indTelefonoMath = true;
                }
                else
                {
                    indTelefonoMath = false;
                }
            }
            else
            {
                miError.SetError(txtIndicativoTel, null);
                indTelefonoMath = true;
            }
        }

        private void txtTelefono_Validating(object sender, CancelEventArgs e)
        {
            if (!String.IsNullOrEmpty(txtTelefono.Text))
            {
                if (ConFormato(Validacion.TipoValidacion.NumeroEspacionGuion, txtTelefono, telefonoIncorrecto))
                {
                    telefonoMath = true;
                }
                else
                {
                    telefonoMath = false;
                }
            }
            else
            {
                if (!String.IsNullOrEmpty(txtIndicativoTel.Text))
                {
                    miError.SetError(txtTelefono, telefonoRequerido);
                    telefonoMath = false;
                }
                else
                {
                    miError.SetError(txtTelefono, null);
                    telefonoMath = true;
                }
            }
        }

        private void txtCelular_Validating(object sender, CancelEventArgs e)
        {
            if (!EsVacio(txtCelular, celularRequerido))
            {
                celularMath = true;

                if (ConFormato(Validacion.TipoValidacion.NumeroEspacio, txtCelular, celularIncorrecto))
                {
                    celularMath = true;
                }
                else
                {
                    celularMath = false;
                }
            }
            else
                celularMath = false;
        }

        private void txtIndicativoFax_Validating(object sender, CancelEventArgs e)
        {
            if (!String.IsNullOrEmpty(txtIndicativoFax.Text))
            {
                if (ConFormato(Validacion.TipoValidacion.Numeros, txtIndicativoFax, faxIncorrecto))
                {
                    indFaxMath = true;
                }
                else
                {
                    indFaxMath = false;
                }
            }
            else
            {
                miError.SetError(txtIndicativoFax, null);
                indFaxMath = true;
            }
        }

        private void txtNumeroFax_Validating(object sender, CancelEventArgs e)
        {
                if (!String.IsNullOrEmpty(txtNumeroFax.Text))
                {
                    if (ConFormato(Validacion.TipoValidacion.NumeroEspacionGuion, txtNumeroFax, faxIncorrecto))
                    {
                        faxMath = true;
                    }
                    else
                    {
                        faxMath = false;
                    }
                }
                else
                {
                    if (!String.IsNullOrEmpty(txtIndicativoFax.Text))
                    {
                        miError.SetError(txtNumeroFax, faxRequerido);
                        faxMath = false;
                    }
                    else
                    {
                        
                            miError.SetError(txtNumeroFax, null);
                            faxMath = true;
                        
                    }
                }
        }

        private void txtDireccion_Validating(object sender, CancelEventArgs e)
        {
            if (!EsVacio(txtDireccion, direccionRequerida))
            {
                direccionMath = true;

                /*if (ConFormato(Validacion.TipoValidacion.Domicilio, txtDireccion, direccionIncorrecta))
                {
                    this.txtDireccion.Text = this.txtDireccion.Text.ToUpper();
                    direccionMath = true;
                }
                else
                {
                    direccionMath = false;
                }*/
            }
            else
                direccionMath = false;
        }

        private void txtEmail_Validating(object sender, CancelEventArgs e)
        {
            if (!String.IsNullOrEmpty(txtEmail.Text))
            {
                if (ConFormato(Validacion.TipoValidacion.Email, txtEmail, emailIncorrecto))
                {
                    emailMath = true;
                }
                else
                {
                    emailMath = false;
                }
            }
            else
            {
                miError.SetError(txtEmail, null);
                emailMath = true;
            }
        }

        private void txtPaginaWeb_Validating(object sender, CancelEventArgs e)
        {
            if (!String.IsNullOrEmpty(txtPaginaWeb.Text))
            {
                if (ConFormato(Validacion.TipoValidacion.Url, txtPaginaWeb, webIncorrecto))
                {
                    webMath = true;
                }
                else
                {
                    webMath = false;
                }
            }
            else
            {
                miError.SetError(txtPaginaWeb, null);
                webMath = true;
            }
        }

        /// <summary>
        /// Valida si el texto del control es vacio y muestra el mensaje de error. Devuleve True si el texto es vacio.
        /// </summary>
        /// <param name="control">Control a validar.</param>
        /// <param name="texto">Texto del mensaje</param>
        /// <returns></returns>
        private bool EsVacio(Control control, string texto)
        {
            if (String.IsNullOrEmpty(control.Text))  //Devuelve true si es vacia
            {
                miError.SetError(control, texto);
                return true;
            }
            else
            {
                miError.SetError(control, null);
                return false;
            }
        }

        /// <summary>
        /// Valida el formato de la cadena de texto, devuelve true si el formato es correcto.
        /// </summary>
        /// <param name="tipoValidacion">Tipo de validacion a realizar.</param>
        /// <param name="control">Control a validar.</param>
        /// <param name="mensaje">Mensaje que se mostrar si hay error.</param>
        /// <returns>Retorna true si el formato es correcto.</returns>
        private bool ConFormato(Validacion.TipoValidacion tipoValidacion, Control control, string mensaje)
        {
            bool resultado = false;
            switch (tipoValidacion)
            {
                case Validacion.TipoValidacion.Numeros:
                    {
                        resultado = miValidacion.ValidarNumeroInt(control.Text);
                        break;
                    }
                case Validacion.TipoValidacion.NumeroGuion:
                    {
                        resultado = miValidacion.ValidarCuentaBancaria(control.Text);
                        break;
                    }
                case Validacion.TipoValidacion.NumeroEspacio:
                    {
                        resultado = miValidacion.ValidarNumeroCelular(control.Text);
                        break;
                    }
                case Validacion.TipoValidacion.NumeroEspacionGuion:
                    {
                        resultado = miValidacion.ValidarTelefonoFijo(control.Text);
                        break;
                    }
                case Validacion.TipoValidacion.Palabra:
                    {
                        resultado = miValidacion.ValidarPalabra(control.Text);
                        break;
                    }
                case Validacion.TipoValidacion.Palabras:
                    {
                        resultado = miValidacion.ValidarPalabraCompuesta(control.Text);
                        break;
                    }
                case Validacion.TipoValidacion.Email:
                    {
                        resultado = miValidacion.ValidarEmail(control.Text);
                        break;
                    }
                case Validacion.TipoValidacion.PalabrasNumeroCaracter:
                    {
                        resultado = miValidacion.ValidarPalabrasConCarater(control.Text);
                        break;
                    }
                case Validacion.TipoValidacion.Domicilio:
                    {
                        resultado = miValidacion.ValidarDireccionDomicilio(control.Text);
                        break;
                    }
                case Validacion.TipoValidacion.Url:
                    {
                        resultado = miValidacion.ValidarUrl(control.Text);
                        break;
                    }

                default:
                    {
                        miError.SetError(control, null);
                        break;
                    }
            }
            if (!resultado)
            {
                miError.SetError(control, mensaje);
            }
            else
            {
                miError.SetError(control, null);
            }
            return resultado;
        }

        /// <summary>
        /// Valida de nuevo todos los campos antes de guardar los datos.
        /// </summary>
        private void ValidacionParaGuardar()
        {
            txtCodigoInterno_Validating(null, null);
            txtNitCedula_Validating(null, null);
            txtRazonSocial_Validating(null, null);
            txtNombreComercial_Validating(null, null);
            txtDescripcion_Validating(null, null);
            txtIndicativoTel_Validating(null, null);
            txtTelefono_Validating(null, null);
            txtCelular_Validating(null, null);
            txtIndicativoFax_Validating(null, null);
            txtNumeroFax_Validating(null, null);
            txtDireccion_Validating(null, null);
            txtEmail_Validating(null, null);
            txtPaginaWeb_Validating(null, null);
        }

        /// <summary>
        /// Verifica si existe el codigo del Proveedor en la base de datos.
        /// </summary>
        /// <param name="codigo">Codigo a Verificar.</param>
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
        /// Limpia todos los datos de los controles en el formulario Crear Proveedor.
        /// </summary>
        private void LimpiarCampos()
        {
            this.txtCodigoInterno.Focus();
            this.txtCodigoInterno.Text = "";
            this.txtNitCedula.Text = "";
            this.txtRazonSocial.Text = "";
            this.txtNombreComercial.Text = "";
            this.txtDescripcion.Text = "";
            this.txtIndicativoTel.Text = "";
            this.txtTelefono.Text = "";
            this.txtIndicativoFax.Text = "";
            this.txtNumeroFax.Text = "";
            this.txtCelular.Text = "";
            this.txtDireccion.Text = "";
            this.txtEmail.Text = "";
            this.txtPaginaWeb.Text = "";
            this.dgvDatosBancario.DataSource = null;
            this.dgvDatosVendedor.DataSource = null;
        }

        /// <summary>
        /// Carga la informacion del Formulario a un Objeto miProveedor
        /// </summary>
        private void CargarProveedor()
        {
            miProveedor = new DTO.Clases.Proveedor();
            miProveedor.CodigoInternoProveedor = Convert.ToInt32( txtCodigoInterno.Text );
            miProveedor.NitProveedor = txtNitCedula.Text;
            miProveedor.IdRegimen = Convert.ToInt32( cbRegimen.SelectedValue );
            miProveedor.RazonSocialProveedor = txtRazonSocial.Text.ToUpper();
            miProveedor.NombreComercialProveedor = txtNombreComercial.Text.ToUpper();
            miProveedor.DescripcionProveedor = txtDescripcion.Text;
            miProveedor.TelefonoProveedor = txtIndicativoTel.Text + txtTelefono.Text;
            miProveedor.CelularProveedor = txtCelular.Text;
            miProveedor.FaxProveedor = txtIndicativoFax.Text + txtNumeroFax.Text;
            miProveedor.DireccionProveedor = txtDireccion.Text.ToUpper();
            miProveedor.IdCiudad = Convert.ToInt32( cbCiudad.SelectedValue );
            miProveedor.EmailProveedor = txtEmail.Text;
            miProveedor.WebProveedor = txtPaginaWeb.Text;
            miProveedor.ListadoCuenta = listaCuenta;
            miProveedor.ListadoContactoProveedor = listaVendedor;           
        }

        #endregion

        #endregion

        #region Metodos Consulta Proveedor

        /// <summary>
        /// Acciones que ejecuta el Boton toolstrp Listar Todos
        /// </summary>
        private void tsbtnListarTodos_Click(object sender, EventArgs e)
        {
            this.miDataSet = null;
            miBussinesProveedor = new BussinesProveedor();
            try
            {
                miDataSet = miBussinesProveedor.CargarInformacionProveedor(BussinesProveedor.Filtro.Completo, 0, null);
                EstablecerMiembros();
                CargarDataBindings();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            MostrarProveedorInActivo();
        }

        /// <summary>
        /// Carga el origen de datos en los TextBox, Se deben haber establecido los Miembros "EstablecerMiembros()"
        /// </summary>
        private void CargarDataBindings()
        {
            this.txtCedulaVendedor.DataBindings.Clear();
            this.txtNombreVendedor.DataBindings.Clear();
            this.txtCelularVendedor.DataBindings.Clear();
            this.txtEmailVendedor.DataBindings.Clear();
            this.txtEstadoVendedor.DataBindings.Clear();

            this.txtCedulaVendedor.DataBindings.Add("Text", contacto, "Cedula");
            this.txtNombreVendedor.DataBindings.Add("Text", contacto, "Nombres");
            this.txtCelularVendedor.DataBindings.Add("Text", contacto, "Celular");
            this.txtEmailVendedor.DataBindings.Add("Text", contacto, "Email");
            this.txtEstadoVendedor.DataBindings.Add("Text", contacto, "Estado");

            this.txtNumeroCta.DataBindings.Clear();
            this.txtTitularCta.DataBindings.Clear();
            this.txtTipoCta.DataBindings.Clear();
            this.txtBancoCta.DataBindings.Clear();

            this.txtNumeroCta.DataBindings.Add("Text", cuenta, "Numero");
            this.txtTitularCta.DataBindings.Add("Text", cuenta, "Titular");
            this.txtTipoCta.DataBindings.Add("Text", cuenta, "Tipo Cuenta");
            this.txtBancoCta.DataBindings.Add("Text", cuenta, "Banco");
        }
        public bool Egreso_ = false;
        private void dgvListadoProveedor_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (Extension)
            {
                DataGridViewRow registro =
                    this.dgvListadoProveedor.Rows[this.dgvListadoProveedor.CurrentCell.RowIndex];
                DTO.Clases.Proveedor miProveedor = new DTO.Clases.Proveedor();
                miProveedor.CodigoInternoProveedor = Convert.ToInt32(registro.Cells[0].Value);
                miProveedor.NitProveedor = registro.Cells["Column11"].Value.ToString();
                miProveedor.NombreProveedor = Convert.ToString(registro.Cells[3].Value);
                if (Edit)
                {
                    CompletaEventos.CapturaEventoEditProveedor(miProveedor);
                }
                else
                {
                    CompletaEventos.CapturaEvento(miProveedor);
                }
                if (Egreso_)
                {
                    CompletaEventos.CapturaEventom(registro.Cells["Column11"].Value.ToString());
                }
                //Extension = false;
                this.Close();
            }
        }

        private void btnConsulta_Click(object sender, EventArgs e)
        {
            FiltrarProveedor();
        }

        private void txtConsulta_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter) || e.KeyChar == Convert.ToChar(Keys.Tab))
            {
                FiltrarProveedor();
            }
        }

        /// <summary>
        /// Establece las relaciones y los miembros de los origenes de datos, La variable miDataSet debe haber sido cargada.
        /// </summary>
        private void EstablecerMiembros()
        {
            this.proveedor.DataSource = miDataSet;

            this.contacto.DataMember = "fk_proveedor_contacto";
            this.contacto.DataSource = this.proveedor;

            this.cuenta.DataMember = "fk_proveedor_cuenta";
            this.cuenta.DataSource = this.proveedor;

            this.dgvListadoProveedor.DataSource = null;
            this.dgvListadoProveedor.DataSource = proveedor;
        }

        /// <summary>
        /// Filtar la consulta a un proveedor segun el criterio.
        /// </summary>
        private void FiltrarProveedor()
        {
            int criterio1 = Convert.ToInt32(this.cbCriterio1.SelectedValue);
            int criterio2 = Convert.ToInt32(this.cbCriterio2.SelectedValue);

            if (txtConsulta.Text != "")
            {
                if (criterio1 == 1 && criterio2 == 1)  //Consulta por Codigo - Que sea Igual.
                {
                    try
                    {
                        var codigo = Convert.ToInt32(txtConsulta.Text);
                        ConsultaProveedorCodigo(codigo);
                    }
                    catch (FormatException)
                    {
                        MessageBox.Show
                        ("El Codigo debe ser un numero, sin espacios, ni comas, ni puntos, ni letras. ", 
                        "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                if (criterio1 == 1 && criterio2 == 2) //Consulta por codigo - Que contenga
                {
                    try
                    {
                        var codigo = Convert.ToInt32(txtConsulta.Text);
                        FiltrarProveedorCodigo(codigo);
                    }
                    catch (FormatException)
                    {
                        MessageBox.Show
                            ("El Codigo debe ser un numero, sin espacios, ni comas, ni puntos, ni letras. ", 
                            "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                if (criterio1 == 2 && criterio2 == 1) //Por Nit o Cedula - Que sea igual
                {
                    ConsultaProveedorNit(txtConsulta.Text);
                }
                if (criterio1 == 2 && criterio2 == 2) //Por nit o cedula - Que contenga
                {
                    FiltrarProveedorNit(txtConsulta.Text);
                }
                if (criterio1 == 3 && criterio2 == 1) //Por nombre - Que sea igual
                {
                    ConsultaProveedorNombre(txtConsulta.Text);
                } 
                if (criterio1 == 3 && criterio2 == 2) // Por nombre - que contenga.
                {
                    FiltrarProveedorNombre(txtConsulta.Text);
                }
            }
            else
                MessageBox.Show("Debe Ingresar un criterio de busqueda. ", "Busqueda", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        /// <summary>
        /// Realiza la consulta de un proveedor segun el codigo.
        /// </summary>
        /// <param name="codigo"></param>
        private void ConsultaProveedorCodigo(int codigo)
        {
            miDataSet = null;
            try
            {
                miBussinesProveedor = new BussinesProveedor();
                miDataSet = miBussinesProveedor.CargarInformacionProveedor(BussinesProveedor.Filtro.CodigoCompleto, codigo, null);
                EstablecerMiembros();
                CargarDataBindings();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            if(!(this.dgvListadoProveedor.RowCount > 0))
                MessageBox.Show("No se encontraro registros con ese Codigo. ", "Busqueda", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }

        /// <summary>
        /// Filtra la consulta de un proveedor por codigo
        /// </summary>
        /// <param name="codigo"></param>
        private void FiltrarProveedorCodigo(int codigo)
        {
            miDataSet = null;
            try
            {
                miBussinesProveedor = new BussinesProveedor();
                miDataSet = miBussinesProveedor.CargarInformacionProveedor(BussinesProveedor.Filtro.Codigo, codigo, null);
                EstablecerMiembros();
                CargarDataBindings();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            if (!(this.dgvListadoProveedor.RowCount > 0))
                MessageBox.Show("No se encontraro registros con ese Codigo. " , "Busqueda" , MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }

        /// <summary>
        /// Realiza la consulta de un proveedor segun el nit
        /// </summary>
        /// <param name="nit"></param>
        private void ConsultaProveedorNit(string nit)
        {
            miDataSet = null;
            try
            {
                miBussinesProveedor = new BussinesProveedor();
                miDataSet = miBussinesProveedor.CargarInformacionProveedor(BussinesProveedor.Filtro.NitCompleto, 0, nit.Trim());
                EstablecerMiembros();
                CargarDataBindings();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            if (!(this.dgvListadoProveedor.RowCount > 0))
                MessageBox.Show
                ("No se encontro registros con ese Nit o Cedula. ", "Busqueda", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }

        /// <summary>
        /// Filtra la consulta de un proveedor por Nit o Cedula.
        /// </summary>
        /// <param name="nit"></param>
        private void FiltrarProveedorNit(string nit)
        {
            miDataSet = null;
            try
            {
                miBussinesProveedor = new BussinesProveedor();
                this.miDataSet = miBussinesProveedor.CargarInformacionProveedor(BussinesProveedor.Filtro.Nit, 0 , nit.Trim());
                EstablecerMiembros();
                CargarDataBindings();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            if (!(this.dgvListadoProveedor.RowCount > 0))
                MessageBox.Show
                ("No se encontro registros con ese Nit o Cedula. " , "Busqueda" , MessageBoxButtons.OK , MessageBoxIcon.Asterisk);
        }

        /// <summary>
        /// Realiza la consulta de un proveedor segun su nombre.
        /// </summary>
        /// <param name="nombre"></param>
        private void ConsultaProveedorNombre(string nombre)
        {
            miDataSet = null;
            try
            {
                miBussinesProveedor = new BussinesProveedor();
                miDataSet = miBussinesProveedor.CargarInformacionProveedor
                    (BussinesProveedor.Filtro.NombreCompleto, 0, nombre.Trim());
                EstablecerMiembros();
                CargarDataBindings();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            if (!(this.dgvListadoProveedor.RowCount > 0))
                MessageBox.Show("No se encontro registros con ese Nombre", "Busqueda", 
                    MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }

        /// <summary>
        /// Filtra la consulta de un proveedor por Nombre
        /// </summary>
        /// <param name="nombre"></param>
        private void FiltrarProveedorNombre(string nombre)
        {
            miDataSet = null;
            try
            {
                miBussinesProveedor = new BussinesProveedor();
                miDataSet = miBussinesProveedor.CargarInformacionProveedor(BussinesProveedor.Filtro.Nombre, 0, nombre.Trim());
                EstablecerMiembros();
                CargarDataBindings();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            if (!(this.dgvListadoProveedor.RowCount > 0))
                MessageBox.Show("No se encontro registros con ese Nombre", "Busqueda", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }

        /// <summary>
        /// Pinta de color rojo la fuente del registro en el DataGridView de un proveedor Inactivo o dado de baja.
        /// </summary>
        private void MostrarProveedorInActivo()
        {
            foreach (DataGridViewRow row in this.dgvListadoProveedor.Rows)
            {
                if (!Convert.ToBoolean(row.Cells[8].Value))
                {
                    row.DefaultCellStyle.ForeColor = Color.Red;
                }
            }
        }

        #endregion

        private void tsbtnEditarProveedor_Click(object sender, EventArgs e)
        {
            if (this.dgvListadoProveedor.CurrentCell != null)
            {
                var codigo = (int)this.dgvListadoProveedor.CurrentRow.Cells[0].Value;
                editar = new frmEditarProveedor();
                editar.MdiParent = this.MdiParent;
                editar.CargarProveedorAEditar(codigo);
                editar.Show();
            }
        }

        private void tsbtnEliminar_Click(object sender, EventArgs e)
        {
            if (this.dgvListadoProveedor.CurrentCell != null)
            {
                DialogResult rta = MessageBox.Show
                  ("¿Esta seguro que desea eliminar el registro?", "Proveedor",
                   MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (rta == DialogResult.Yes)
                {
                    var codigo = (int)this.dgvListadoProveedor.CurrentRow.Cells[0].Value;
                    try
                    {
                        miBussinesProveedor.EliminarProveedor(codigo);
                        MessageBox.Show("El registro se elimino con exito. ", "Proveedor");
                        this.dgvListadoProveedor.Rows.RemoveAt(this.dgvListadoProveedor.CurrentCell.RowIndex);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }            
        }

        private void frmProveedor_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F2))
            {
                this.tsbtnGuardar_Click(this.tsbtnGuardar, new EventArgs());
            }
            else
            {
                if (e.KeyCode.Equals(Keys.F3))
                {
                    this.lkbGenerar_LinkClicked(this.lkbGenerar, null);
                }
            }
        }

        private void frmProveedor_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (tcProveedor.SelectedIndex == 0 && !salir)
            {
                DialogResult rta = MessageBox.Show
                    (msnSalir, "Proveedor", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);
                if (rta == DialogResult.Yes)
                {
                    tsbtnGuardar_Click(null, null);
                    if (codigoMath &&
                        !existeCodigo &&
                        !existeNit &&
                        nitMath &&
                        razonMath &&
                        nombreMath &&
                        descripcionMath &&
                        indTelefonoMath &&
                        telefonoMath &&
                        celularMath &&
                        indFaxMath &&
                        faxMath &&
                        direccionMath &&
                        emailMath &&
                        webMath)
                    {
                        e.Cancel = false;
                    }
                    else
                        e.Cancel = true;
                }
                if (rta == DialogResult.Cancel)
                    e.Cancel = true;
            }
            if (formVendedor != null) { formVendedor.Close(); }
            if (formCuentaBanco != null) { formCuentaBanco.Close(); }
            if (editar != null) { editar.Close(); }
            if (Extension)
                CompletaEventos.CapturaEvento(false);
            if (Egreso_)
            {
                CompletaEventos.CapturaEventom(false);
            }
        }

        private void tsbtnConsultaSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cbCriterio1_SelectionChangeCommitted(object sender, EventArgs e)
        {
            var id = Convert.ToInt32(cbCriterio1.SelectedValue);
            switch (id)
            {
                case 1:
                    {
                        cbCriterio2.SelectedValue = 1;
                        cbCriterio2.Enabled = false;
                        break;
                    }
                case 2:
                    {
                        cbCriterio2.SelectedValue = 1;
                        cbCriterio2.Enabled = false;
                        break;
                    }
                case 3:
                    {
                        cbCriterio2.SelectedValue = 2;
                        cbCriterio2.Enabled = true;
                        break;
                    }
            }
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            try
            {
                miBussinesProveedor = new BussinesProveedor();
                miBussinesProveedor.ActualizarBeneficiario();
                CustomControl.OptionPane.MessageInformation("Los proveedores se han actualizado como beneficiarios.");
                this.btnActualizar.Visible = false;
                AppConfiguracion.SaveConfiguration("proveedor_beneficio", "false");
            }
            catch (Exception ex)
            {
                CustomControl.OptionPane.MessageError(ex.Message);
            }
        }

        private void txtCodigoInterno_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar.Equals((char)Keys.Enter))
            {
                txtNitCedula.Focus();
            }
        }

        private void txtNitCedula_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar.Equals((char)Keys.Enter))
            {
                cbRegimen.Focus();
            }
        }

        private void cbRegimen_Enter(object sender, EventArgs e)
        {
            cbRegimen.DroppedDown = true;
        }

        private void cbRegimen_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar.Equals((char)Keys.Enter))
            {
                txtRazonSocial.Focus();
            }
        }

        private void txtRazonSocial_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar.Equals((char)Keys.Enter))
            {
                txtNombreComercial.Focus();
            }
        }

        private void txtNombreComercial_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar.Equals((char)Keys.Enter))
            {
                txtDescripcion.Focus();
            }
        }

        private void txtDescripcion_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar.Equals((char)Keys.Enter))
            {
                txtIndicativoTel.Focus();
            }
        }

        private void txtIndicativoTel_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar.Equals((char)Keys.Enter))
            {
                txtTelefono.Focus();
            }
        }

        private void txtTelefono_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar.Equals((char)Keys.Enter))
            {
                txtCelular.Focus();
            }
        }

        private void txtCelular_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar.Equals((char)Keys.Enter))
            {
                txtIndicativoFax.Focus();
            }
        }

        private void txtIndicativoFax_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar.Equals((char)Keys.Enter))
            {
                txtNumeroFax.Focus();
            }
        }

        private void txtNumeroFax_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar.Equals((char)Keys.Enter))
            {
                txtDireccion.Focus();
            }
        }

        private void txtDireccion_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar.Equals((char)Keys.Enter))
            {
                cbDepartamento.Focus();
            }
        }

        private void cbDepartamento_Enter(object sender, EventArgs e)
        {
            this.cbDepartamento.DroppedDown = true;
        }

        private void cbDepartamento_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar.Equals((char)Keys.Enter))
            {
                cbCiudad.Focus();
            }
        }

        private void cbCiudad_Enter(object sender, EventArgs e)
        {
            cbCiudad.DroppedDown = true;
        }

        private void cbCiudad_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar.Equals((char)Keys.Enter))
            {
                txtEmail.Focus();
            }
        }

        private void txtEmail_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar.Equals((char)Keys.Enter))
            {
                txtPaginaWeb.Focus();
            }
        }

    }

    public class CargarCriterioProveedor
    {
        public List<CriterioProveedor1> Lista1;
        public List<CriterioProveedor2> Lista2;

        public CargarCriterioProveedor()
        {
            this.Lista1 = new List<CriterioProveedor1>();
            this.Lista1.Add(new CriterioProveedor1
                       {
                           Id1 = 1,
                           Nombre1 = "Por Codigo"
                       });
            this.Lista1.Add(new CriterioProveedor1
                       {
                           Id1 = 2,
                           Nombre1 = "Por Nit o Cedula"
                       });
            this.Lista1.Add(new CriterioProveedor1
                       {
                           Id1 = 3,
                           Nombre1 = "Por Nombre"
                       });

            this.Lista2 = new List<CriterioProveedor2>();
            this.Lista2.Add(new CriterioProveedor2
                       {
                           Id2 = 1,
                           Nombre2 = "Que sea Igual"
                       });
            this.Lista2.Add(new CriterioProveedor2
                       {
                           Id2 = 2,
                           Nombre2 = "Que Contenga"
                       });
        }
    }
    public class CriterioProveedor1 
    {
        public int Id1 { set; get; }
        public string Nombre1 { set; get; }
    }
    public class CriterioProveedor2 
    {
        public int Id2 { set; get; }
        public string Nombre2 { set; get; }
    }
}