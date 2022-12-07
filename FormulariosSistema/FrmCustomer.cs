using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BussinesLayer.Bussines;
using BussinesLayer.Clases;
using Utilities;
using CustomControl;
using System.Threading;
using DTO;
using DTO.Clases;
using DataAccessLayer.Repository;
using DataAccessLayer.DataSets;
using DataAccessLayer.Models;

namespace FormulariosSistema
{
    public partial class FrmCustomer : Form
    {
        /// <summary>
        /// Representa un objeto para mostrar mensajes de error
        /// </summary>
        private ErrorProvider miError = new ErrorProvider();

        /// <summary>
        /// Establece la condicion para guardar
        /// </summary>
        private bool tipoDocumentoMatch = false,
                     cedulaMatch = false,
                     dvMatch = false,
                     nombreMatch = false,
                     codeCityMatch = false,
                     codePostalMatch = false,
                     celularMatch = false,
                     emailMatch = false,
                     direccionMatch = false,
                     tributaryMatch = false,
                     rutMatch = false;

        

        /**

        #region Atributos De Logica de Negocio

        private DTO.Clases.Empresa miEmpresa;

        /// <summary>
        /// Representa la logica de negocios del Cliente
        /// </summary>
        private BussinesCliente miBussinesCliente;
        private BussinesEmpresa miBussinesEmpresa;
        private BussinesRegimen miBussinesRegimen;
        private BussinesDepartamento miBussinesDepartamento;
        

        /// <summary>
        /// Objeto que contiene las listas para cargar los criterios
        /// </summary>
        private CargarCriteriosCliente criterios;

        #endregion

        #region Atributos de Validacion

        

        /// <summary>
        /// Establece la condicion que indica que el formulario de edicion se ha abierto
        /// </summary>
        public static bool edicionOpen = false;

        /// <summary>
        /// Establece la condicion que indica si el usuario presiono el boton salir
        /// </summary>
        private bool salir = false;
 
        #endregion
        
        #region Atributos de Extension de formulario

        /// <summary>
        /// Estabelece el formulario para edicion de datos de un Cliente.
        /// </summary>
        //private frmEditarCliente frmEditar;

        /// <summary>
        /// Establece la condición que indica si se usa el formulario como extención de Factura de venta
        /// </summary>
        public bool FacturaVenta { set; get; }

        public bool Remision = false;

        public bool ConsultaRemision = false;

        public bool SubConsulta { set; get; }

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

        private const string msgCampoVacio = "El Campo {0} es Requerido";

        private const string campoBusqueda = " de Busqueda";

        private const string msnSalir = "¿Desea guardar los cambios?";

        #endregion

        private bool PressBtn { set; get; }

        public bool ConsultaVentaBtn { set; get; }
         
        **/

        private BussinesData BsData;

        private readonly BussinesEmpresa miBussinesEmpresa;

        private readonly BussinesCliente miBussinesCliente;

        private BussinesCiudad miBussinesCiudad;

        private readonly BussinesModel bussinesModel;

        private readonly RepositoryModel repositoryModel;


        private bool Edit { set; get; }

        private Empresa empresa;

        private DataBaseDS.clienteRow customerEdit;

        private CustomerModel customerMEdit;


        private List<IdentifyTax> lstResponsabilityFiscal;

        private List<ResponsabilityFiscal> lstDetailsRUT;


        private DataBaseDS.details_tributary_clientDataTable lstDetailsTributary;

        private DataBaseDS.details_rut_clientDataTable lstDetailsRUT_;

        BindingSource bg;

        BindingSource bgRUT;

        public FrmCustomer()
        {
            InitializeComponent();

            BsData = new BussinesData();
            miBussinesEmpresa = new BussinesEmpresa();
            miBussinesCliente = new BussinesCliente();
            miBussinesCiudad = new BussinesCiudad();
            bussinesModel = new BussinesModel();
            repositoryModel = new RepositoryModel();

            this.Edit = false;
            empresa = miBussinesEmpresa.ObtenerEmpresa();
            lstResponsabilityFiscal = new List<IdentifyTax>();
            lstDetailsRUT = new List<ResponsabilityFiscal>();


            this.cbTipoPersona.DataSource = BsData.TypesPerson();
            this.cbTipoDocumento.DataSource = BsData.IdDocuments();
            this.cbRegimen.DataSource = BsData.FiscalRegimen();
            this.cbTipoVentas.DataSource = miBussinesCliente.Tipos();
            this.cbClasificacionComercial.DataSource = miBussinesCliente.Clasificacion();

            this.cbDepto.DataSource = this.bussinesModel.Departamentos();
            this.cbDepto.SelectedValue = this.empresa.Departamento.IdDepartamento;
            this.cbDepto_SelectionChangeCommitted(this.cbDepto, new EventArgs());
            this.cbCiudad_.SelectedValue = this.empresa.Ciudad.IdCiudad;
            this.cbCodePostal.DataSource = this.bussinesModel.CodePostales();

            lstDetailsTributary = new DataBaseDS.details_tributary_clientDataTable();
            lstDetailsRUT_ = new DataBaseDS.details_rut_clientDataTable();

            bg = new BindingSource();
            bgRUT = new BindingSource();

            
            /*this.ConsultaVenta = false;
            this.ConsultaVentaBtn = false;
            miBussinesEmpresa = new BussinesEmpresa();
            miBussinesCiudad = new BussinesCiudad();
            miBussinesCliente = new BussinesCliente();
            miBussinesDepartamento = new BussinesDepartamento();
            miBussinesRegimen = new BussinesRegimen();

            this.BsCity = new BussinesLayer.Bussines.BussinesCity();

            this.SubConsulta = false;
            this.PressBtn = false;
            try
            {
                miEmpresa = miBussinesEmpresa.ObtenerEmpresa();
            }
            catch (Exception ex)
            {
                CustomControl.OptionPane.MessageError(ex.Message);
            }*/

            
        }

        private void IngresarCliente_Load(object sender, EventArgs e)
        {
            try
            {
                this.cbDetalleTributario.DataSource = this.IdentifyTaxes();
                this.cbInfoTributarioRUT.DataSource = this.BsData.InfoTributary();

                dgvDetallesTributarios.AutoGenerateColumns = false;
                dgvDetallesTributarios.DataSource = bg;

                dgvDetallesRUT.AutoGenerateColumns = false;
                dgvDetallesRUT.DataSource = bgRUT;

                /*
                 * CargarRegimen();
                CargarDepartamentos();
                cbDepartamentos.SelectedValue = miEmpresa.Departamento.IdDepartamento;
                CargarCiudades(miEmpresa.Departamento.IdDepartamento);
                cbCiudad.SelectedValue = miEmpresa.Ciudad.IdCiudad;
                criterios = new CargarCriteriosCliente();
                this.cbCriterio1.DataSource = criterios.lista1;
                this.cbCriterio2.DataSource = criterios.lista2;
                this.dgvListado1.AutoGenerateColumns = false;

                CompletaEventos.Completa += new CompletaEventos.CompletaAccion(CompletaEventos_Completo);
                if (SubConsulta)
                {
                    tcClientes.SelectedIndex = 1;
                    cbCriterio1.SelectedIndex = 1;
                    cbCriterio1_SelectionChangeCommitted(this.cbCriterio1, new EventArgs());
                    this.btnBuscar_Click(this.btnBuscar, new EventArgs());
                }

                if (this.ConsultaVenta)
                {
                    this.cbCriterio1.SelectedValue = 2;
                    this.cbCriterio1_SelectionChangeCommitted(this.cbCriterio1, new EventArgs());
                    if (this.ConsultaVentaBtn)
                    {
                        this.btnBuscar_Click(this.btnBuscar, new EventArgs());
                    }
                    else
                    {
                        this.tsBtnListarTodos_Click(this.tsBtnListarTodos, new EventArgs());

                    }
                    txtNit.Focus();
                    //this.dgvListado1.Focus();

                    
                }
                */


                /**
                this.cbDepto.DataSource = this.BsCity.Departamentos();
                this.cbDepto_SelectionChangeCommitted(this.cbDepto, new EventArgs());
                this.cbCodePostal.DataSource = this.BsCity.CodePostales();

                LoadCustomer();
                */
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
        }


        /**

        private void frmCliente_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData.Equals(Keys.F2))
            {
                this.tsBtnGuardar_Click(this.tsBtnGuardar, new EventArgs());
            }
            else
            {
                if (e.KeyData.Equals(Keys.F12))
                {
                    string rta = CustomControl.OptionPane.OptionBox
                    ("Ingresar contraseña de Administrador .", "Administrador", CustomControl.OptionPane.Icon.LoginAdmin);
                    if (rta.Equals("1002-105-AJUST"))
                    {
                        this.miOption = new OptionPane();
                        this.miOption.FrmProgressBar.barraProgreso.Style = ProgressBarStyle.Marquee;
                        this.miOption.FrmProgressBar.Closed_ = true;
                        this.miOption.ProgressShow("Espere mientras se realizan las operaciones necesarias...",
                            "Operacion en progreso");
                        this.Enabled = false;
                        this.miThread = new Thread(Cargar);
                        this.miThread.Start();
                    }
                }
            }
        }

        private void cbDepartamentos_SelectionChangeCommitted(object sender, EventArgs e)
        {
            int idDepartamento = Convert.ToInt32(this.cbDepartamentos.SelectedValue);
            CargarCiudades(idDepartamento);
        }

        private void tsBtnGuardar_Click(object sender, EventArgs e)
        {
            this.txtNombres.Text = this.txtNombres.Text.ToUpper();
            this.txtDireccion.Text = this.txtDireccion.Text.ToUpper();
            ValidacionGuardar();
            if (cedulaMatch &&
                nombreMatch &&
                telefonoMatch &&
                celularMatch &&
                direccionMatch &&
                emailMatch)
            {
                GuardarCliente();
            }
        }

        private void tsbtnSalir_Click(object sender, EventArgs e)
        {
            DialogResult rta = MessageBox.Show
             (msnSalir, "Cliente", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);
            if (rta == DialogResult.Yes)
            {
                tsBtnGuardar_Click(null, null);
                if (cedulaMatch &&
                nombreMatch &&
                telefonoMatch &&
                celularMatch &&
                direccionMatch &&
                emailMatch)
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
                if(FacturaVenta)
                    CompletaEventos.CapturaEvento(false);
            }
        }

        private void txtNit_Validating(object sender, CancelEventArgs e)
        {
            if (!Validacion.EsVacio(txtNit, miError, msnCedulaReq))
            {
                //cedulaMatch = true;
                if (Validacion.ConFormato
                    (Validacion.TipoValidacion.NumeroGuion, txtNit, miError, msnCedulaFormat))
                {
                    if (ExisteCliente(txtNit.Text))
                    {
                        miError.SetError(txtNit, msnExisteCliente);
                        cedulaMatch = false;
                    }
                    else
                    {
                        miError.SetError(txtNit, null);
                        cedulaMatch = true;
                    }
                }
                else
                    cedulaMatch = false;
            }
            else
                cedulaMatch = false;
        }

        private void txtNombres_Validating(object sender, CancelEventArgs e)
        {
            if (!Validacion.EsVacio(txtNombres, miError, msnNombreReq))
            {
                nombreMatch = true;
                if (Validacion.ConFormato
                    (Validacion.TipoValidacion.Palabras, txtNombres, miError, msnNombreFormat))
                {
                    nombreMatch = true;
                }
                else
                    nombreMatch = false;
            }
            else
                nombreMatch = false;
        }

        private void txtTelefono_Validating(object sender, CancelEventArgs e)
        {
            if (!String.IsNullOrEmpty(txtTelefono.Text))
            {
                if (Validacion.ConFormato
                    (Validacion.TipoValidacion.NumeroEspacionGuion, txtTelefono, miError, msnTelefonoFormat))
                {
                    telefonoMatch = true;
                }
            }
            else
                telefonoMatch = true;
        }

        private void txtCelular_Validating(object sender, CancelEventArgs e)
        {
            if (!Validacion.EsVacio(txtCelular, miError, msnCelularReq))
            {
                celularMatch = true;
                if (Validacion.ConFormato
                    (Validacion.TipoValidacion.NumeroEspacio, txtCelular, miError, msnCelularFormat))
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
            if (!String.IsNullOrEmpty(txtEmail.Text))
            {
                if (Validacion.ConFormato
                    (Validacion.TipoValidacion.Email, txtEmail, miError, msnEmailFormat))
                {
                    emailMatch = true;
                }
                else
                    emailMatch = false;
            }
            else
            {
                miError.SetError(txtEmail, null);
                emailMatch = true;
            }
        }

        private void txtDireccion_Validating(object sender, CancelEventArgs e)
        {
           /* if (!String.IsNullOrEmpty(txtDireccion.Text))
            {
                if (Validacion.ConFormato
                    (Validacion.TipoValidacion.Domicilio, txtDireccion, miError, msnDireccionFormat))
                {
                    direccionMatch = true;
                }
                else
                    direccionMatch = false;
            }
            else
                direccionMatch = true;
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
            try
            {
                DTO.Clases.Cliente cliente = new DTO.Clases.Cliente();
                cliente.NitCliente = txtNit.Text;
                cliente.NombresCliente = txtNombres.Text;
                cliente.IdRegimen = Convert.ToInt32(this.cbRegimen.SelectedValue);
                cliente.TelefonoCliente = txtTelefono.Text;
                cliente.CelularCliente = txtCelular.Text;
                cliente.EmailCliente = txtEmail.Text;
                cliente.DireccionCliente = txtDireccion.Text;
                cliente.IdCiudad = Convert.ToInt32(this.cbCiudad.SelectedValue);
                cliente.IdTipoCliente = Convert.ToInt32(this.cbTipo.SelectedValue);
                cliente.IdClasificacion = Convert.ToInt32(this.cbClasificacion.SelectedValue);

                DialogResult rta = MessageBox.Show("¿Esta seguro(a) de guardar los datos?", "Cliente",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (rta.Equals(DialogResult.Yes))
                {
                    miBussinesCliente.InsertarCliente(cliente);

                    var miBussinesProveedor = new BussinesProveedor();
                    miBussinesProveedor.InsertarProveedor(new DTO.Clases.Proveedor
                    {
                        CodigoInternoProveedor = miBussinesProveedor.ObtenerCodigoConsecutivo(),
                        NitProveedor = this.txtNit.Text,
                        IdRegimen = Convert.ToInt32(this.cbRegimen.SelectedValue),
                        RazonSocialProveedor = this.txtNombres.Text,
                        NombreComercialProveedor  = this.txtNombres.Text,
                        CelularProveedor = this.txtCelular.Text,
                        IdCiudad = Convert.ToInt32(this.cbCiudad.SelectedValue),
                        DireccionProveedor = this.txtDireccion.Text
                    });

                    var miBussinesBenefio = new BussinesBeneficio();
                    miBussinesBenefio.Ingresar(new DTO.Clases.Cliente
                    {
                        IdRegimen = Convert.ToInt32(this.cbRegimen.SelectedValue),
                        NitCliente = this.txtNit.Text,
                        NombresCliente = this.txtNombres.Text,
                        CelularCliente = this.txtCelular.Text,
                        IdCiudad = Convert.ToInt32(this.cbCiudad.SelectedValue),
                        DireccionCliente = this.txtDireccion.Text
                    });

                    CustomControl.OptionPane.MessageInformation("Los datos se almacenaron correctamente.");
                    //MessageBox.Show("Los datos se almacenaron correctamente.", "Cliente");
                    txtNit.Focus();
                    LimpiarCampos();
                    if (FacturaVenta)
                    {
                        CompletaEventos.CapturaEvento(cliente.NitCliente);
                        ///CompletaEventos.CapturaEvento(true);
                        //dgvListado1_CellDoubleClick(dgvListado1, new DataGridViewCellEventArgs(0, 0));
                        salir = true;
                        this.Close();
                    }
                }
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
                cbRegimen.DataSource = miBussinesRegimen.ListadoRegimen();
                cbRegimen.SelectedIndex = 1;
                cbTipo.DataSource = miBussinesCliente.Tipos();
                cbClasificacion.DataSource = miBussinesCliente.Clasificacion();
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
                cbDepartamentos.DataSource = miBussinesDepartamento.ListadoDepartamentos();
                if (cbDepartamentos.Items.Count != 0)
                {
                    int idDepartamento = Convert.ToInt32(cbDepartamentos.SelectedValue);
                    CargarCiudades(idDepartamento);
                }
                else
                {
                    cbCiudad.DataSource = null;
                }
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

        /// <summary>
        /// Limpia los campos del furmulario ingresar cliente
        /// </summary>
        private void LimpiarCampos()
        {
            txtNit.Text = "";
            txtNombres.Text = "";
            txtTelefono.Text = "";
            txtCelular.Text = "";
            txtEmail.Text = "";
            txtDireccion.Text = "";
        }


        private void tsBtnListarTodos_Click(object sender, EventArgs e)
        {
            try
            {
                this.PressBtn = false;
                this.dgvListado1.DataSource = null;
                this.dgvListado1.DataSource = DataTableClientes();
            }
            catch (Exception ex)
            {
                CustomControl.OptionPane.MessageError(ex.Message);
            }
            //this.dgvListado1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            FiltrarCliente();
        }

        private void FiltrarCliente()
        {
            this.PressBtn = true;
            int criterio1 = Convert.ToInt32(this.cbCriterio1.SelectedValue);
            int criterio2 = Convert.ToInt32(this.cbCriterio2.SelectedValue);
            if (this.txtParametro.Text != "")
            {
                if (criterio1 == 1 && criterio2 == 1)  //Consulta por Nit - Que sea Igual.
                {
                    ConsultaClienteNit(txtParametro.Text);
                }
                if (criterio1 == 1 && criterio2 == 2)  //Consulta por Nit - Que contenga
                {
                    FiltrarClientePorCedula(txtParametro.Text);
                }
                if (criterio1 == 2 && criterio2 == 1) //Consulta por Nombre - Que sea igual
                {
                    ConsultaClienteNombre(txtParametro.Text);
                }
                if (criterio1 == 2 && criterio2 == 2)  //Consulta por Nombre - Que contenga
                {
                    FiltrarClientePorNombre(txtParametro.Text);
                }
                /*f(this.dgvListado1.CurrentCell != null)
                    this.dgvListado1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            }
            else
            {
                this.dgvListado1.DataSource = null;
                MessageBox.Show(String.Format(msgCampoVacio, campoBusqueda));
            }
        }

        /// <summary>
        /// Obtiene el listado de clientes en un DataTable
        /// </summary>
        /// <returns></returns>
        private DataTable DataTableClientes()
        {
            try
            {
                return miBussinesCliente.ListadoDeClientes();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
        }

        /// <summary>
        /// Realiza una Consulta de un cliente y carga los datos en el gridView
        /// </summary>
        /// <param name="nit">Nit del cliente a consultar</param>
        private void ConsultaClienteNit(string nit)
        {
            try
            {
                this.dgvListado1.DataSource = null;
                this.dgvListado1.DataSource = miBussinesCliente.ConsultaClienteNit(nit.Trim());
                if (dgvListado1.RowCount == 0)
                    MessageBox.Show
                        ("No se encontraron registros con ese Nit o Cedula.", "Cliente", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// Realiza una consulta de un clinete y carga los datos en el gridView
        /// </summary>
        /// <param name="nombre"></param>
        private void ConsultaClienteNombre(string nombre)
        {
            try
            {
                this.dgvListado1.DataSource = null;
                this.dgvListado1.DataSource = miBussinesCliente.ConsultaClienteNombre(nombre.Trim());
                if(dgvListado1.RowCount == 0)
                    MessageBox.Show
                        ("No se encontraron registros con ese Nombre.", "Cliente", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// Filtra una consulta y carga el DataGridView
        /// </summary>
        /// <param name="cedula">Cedula a buscar</param>
        private void FiltrarClientePorCedula(string cedula) 
        {
            try
            {
                this.dgvListado1.DataSource = null;
                this.dgvListado1.DataSource = miBussinesCliente.FiltroClienteCedula(cedula.Trim());
                if (dgvListado1.RowCount == 0)
                    MessageBox.Show
                            ("No se encontraron registros que coincidan con ese Nit o Cedula.", "Cliente", 
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// Filtra una consulta por nombre Cliente y carga el DataGridView
        /// </summary>
        /// <param name="nombre">Nombre a buscar</param>
        private void FiltrarClientePorNombre(string nombre) 
        {
            try
            {
                this.dgvListado1.DataSource = null;
                this.dgvListado1.DataSource = miBussinesCliente.FiltroClienteNombre(nombre.ToUpper());
                if (dgvListado1.RowCount == 0)
                    MessageBox.Show
                           ("No se encontraron registros que coincidan con ese Nombre.", "Cliente",
                           MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void txtParametro_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter) || e.KeyChar == Convert.ToChar(Keys.Tab))
            {
                FiltrarCliente();
            }
        }

        private void tsbtnEditarCliente_Click(object sender, EventArgs e)
        {
            if (this.dgvListado1.CurrentCell != null && !edicionOpen)
            {
               /* var nit = (string)this.dgvListado1.CurrentRow.Cells[0].Value;
                frmEditar = new frmEditarCliente();
                //frmEditar.MdiParent = this.MdiParent;
                frmEditar.CargarClienteAEditar(nit);
                edicionOpen = true;
                frmEditar.ShowDialog();
            }
        }
        
        private void tsbtnEliminarCliente_Click(object sender, EventArgs e)
        {
            if (this.dgvListado1.CurrentCell != null)
            {
                DialogResult rta = MessageBox.Show
                    ("¿Esta seguro que desea eliminar el registro?", "Cliente", MessageBoxButtons.YesNo,
                      MessageBoxIcon.Question);
                if (rta == DialogResult.Yes)
                {
                    var nit = (string)this.dgvListado1.CurrentRow.Cells[0].Value;
                    try
                    {
                        miBussinesCliente.EliminarCliente(nit);
                        this.dgvListado1.Rows.RemoveAt(this.dgvListado1.CurrentCell.RowIndex);
                        MessageBox.Show("El registro se elimino con exito. ", "Cliente",
                            MessageBoxButtons.OK);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }
            
        }

        private void tsbtnConsultaSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmCliente_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (tcClientes.SelectedIndex == 0 && !salir)
            {
                DialogResult rta = MessageBox.Show
                 (msnSalir, "Cliente", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);
                if (rta == DialogResult.Yes)
                {
                    tsBtnGuardar_Click(null, null);
                    if (cedulaMatch &&
                        nombreMatch &&
                        telefonoMatch &&
                        celularMatch &&
                        direccionMatch &&
                        emailMatch)
                        e.Cancel = false;
                    else
                        e.Cancel = true;
                }
                if (rta == DialogResult.Cancel)
                    e.Cancel = true;
            }
            else
            {
                if (FacturaVenta)
                    CompletaEventos.CapturaEvento(false);
            }
            //if (frmEditar != null)
               // frmEditar.Close();
            if (Remision)
                CompletaEventos.CapturaEventoRemision(false);
            if (Egreso_)
                CompletaEventos.CapturaEventoz(false);
            if (ConsultaVenta)
                CompletaEventos.CapturaEventobo(false);
            if (ConsultaRemision)
                CompletaEventos.CapturaEventoeb(false);
        }

        /// <summary>
        /// Recarga el grid con los datos del clinete recien editado
        /// </summary>
        /// <param name="args"></param>
        void CompletaEventos_Completo(CompletaArgumentosDeEvento args)
        {
            try
            {
                ObjectAbstract obj = (ObjectAbstract)args.MiObjeto;
                if (obj.Id.Equals(232))
                {
                    int index = this.dgvListado1.CurrentRow.Index;
                    if (this.PressBtn)
                    {
                        this.btnBuscar_Click(this.btnBuscar, new EventArgs());
                    }
                    else
                    {
                        this.tsBtnListarTodos_Click(this.tsBtnListarTodos, new EventArgs());
                    }
                    this.dgvListado1.Rows[index].Selected = true;
                    this.dgvListado1.CurrentCell = this.dgvListado1.Rows[index].Cells[1];
                }
                /*string nitEditado = (string)args.MiObjeto;
                ConsultaClienteNit(nitEditado);
            }
            catch { }
        }
        public bool Egreso_ = false;
        private void dgvListado1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (FacturaVenta)
            {
                CompletaEventos.CapturaEvento((string)dgvListado1.CurrentRow.Cells["Column1"].Value);
                //FacturaVenta = false;
                this.Close();
            }
            else
            {
                if (Remision)
                {
                    CompletaEventos.CapturaEventoRemision((string)dgvListado1.CurrentRow.Cells["Column1"].Value);
                    this.Close();
                }
                else
                {
                    if (Egreso_)
                    {
                        CompletaEventos.CapturaEventoz((string)dgvListado1.CurrentRow.Cells["Column1"].Value);
                        this.Close();
                    }
                    else
                    {
                        if (ConsultaVenta)
                        {
                            CompletaEventos.CapturaEventobo(dgvListado1.CurrentRow.Cells["Column1"].Value.ToString());
                            this.Close();
                        }
                        else
                        {
                            if (ConsultaRemision)
                            {
                                CompletaEventos.CapturaEventoeb(dgvListado1.CurrentRow.Cells["Column1"].Value.ToString());
                                this.Close();
                            }
                        }
                    }
                }
            }
        }

        private void cbCriterio1_SelectionChangeCommitted(object sender, EventArgs e)
        {
            var id = Convert.ToInt32(cbCriterio1.SelectedValue);
            if (id.Equals(1))
            {
                cbCriterio2.SelectedValue = 1;
                cbCriterio2.Enabled = false;
            }
            else
            {
                cbCriterio2.SelectedValue = 2;
                cbCriterio2.Enabled = true;
            }
        }

        public bool ConsultaVenta = false;

        private void txtNit_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar.Equals((char)Keys.Enter))
            {
                txtNombres.Focus();
            }
        }

        private void txtNombres_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar.Equals((char)Keys.Enter))
            {
                this.cbRegimen.Focus();
                this.txtNombres.Text = this.txtNombres.Text.ToUpper();
            }
        }

        private void cbTipo_Enter(object sender, EventArgs e)
        {
            cbTipo.DroppedDown = true;
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
                txtEmail.Focus();
            }
        }

        private void txtEmail_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar.Equals((char)Keys.Enter))
            {
                cbDepartamentos.Focus();
            }
        }

        private void cbDepartamentos_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void cbCiudad_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void cbDepartamentos_Enter(object sender, EventArgs e)
        {
            cbDepartamentos.DroppedDown = true;
        }

        private void txtDireccion_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar.Equals((char)Keys.Enter))
            {
                this.txtDireccion.Text = this.txtDireccion.Text.ToUpper();
                this.tsBtnGuardar_Click(this.tsBtnGuardar, new EventArgs());
            }
        }

        private void tsBtnCanjear_Click(object sender, EventArgs e)
        {
            //Puntos
            DataGridViewRow dgRow = this.dgvListado1.CurrentRow;
            if (Convert.ToDouble(dgRow.Cells["Puntos"].Value) > 0)
            {
                /*var frmCanjear = new Administracion.Puntos.FrmCanje();
                frmCanjear.txtNit.Text = dgRow.Cells["Column1"].Value.ToString();
                frmCanjear.txtCliente.Text = dgRow.Cells["Column2"].Value.ToString();
                frmCanjear.txtPuntos.Text = UseObject.InsertSeparatorMil(dgRow.Cells["Puntos"].Value.ToString());
                frmCanjear.ShowDialog();
            }
            else
            {
                OptionPane.MessageInformation("El cliente no tiene puntos para canjear.");
            }
        }



        private Thread miThread;

        private OptionPane miOption;

        private void Cargar()
        {
            try
            {
                this.miBussinesCliente.DepurarCliente();
                if (this.InvokeRequired)
                {
                    this.Invoke(new Action(Finalizar));
                }
            }
            catch (Exception ex)
            {
                if (this.InvokeRequired)
                {
                    this.Invoke(new Action(Finalizar));
                }
                OptionPane.MessageError(ex.Message);
            }
        }

        private void Finalizar()
        {
            try
            {
                miOption.FrmProgressBar.barraProgreso.Style = ProgressBarStyle.Blocks;
                miOption.FrmProgressBar.Closed_ = false;
                miOption.FrmProgressBar.Close();
                this.Enabled = true;
                OptionPane.MessageInformation("La operación se realizó con éxito.");
            }
            catch (Exception ex)
            {
                miOption.FrmProgressBar.barraProgreso.Style = ProgressBarStyle.Blocks;
                miOption.FrmProgressBar.Closed_ = false;
                miOption.FrmProgressBar.Close();
                this.Enabled = true;
                OptionPane.MessageError(ex.Message);
            }
        }

        **/



        private void cbDepto_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (this.cbDepto.Items.Count > 0)
            {
                var items = ((DataRowView)this.cbDepto.SelectedItem).Row["nombre"].ToString().Split('-');
                this.LoadCities(items[1]);
                this.CargarCiudades(Convert.ToInt32(this.cbDepto.SelectedValue));

                this.txtCodeDepto.Text = items[1];

                //this.txtCaja.Text = ((DataRowView)this.cbCaja.SelectedItem).Row["numerocaja"].ToString();
            }
        }



        private void cbCity_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (this.cbCity.Items.Count > 0)
            {
                this.txtCodeCity.Text = this.cbCity.SelectedValue.ToString();
            }
        }

        private void cbCodePostal_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (this.cbCodePostal.Items.Count > 0)
            {
                this.txtCodePostal.Text = this.cbCodePostal.SelectedValue.ToString();
            }
        }



        private void LoadCities(string codeDepto)
        {
            try
            {
                this.cbCity.DataSource = this.bussinesModel.Cities(codeDepto);
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
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
                this.cbCiudad_.DataSource = miBussinesCiudad.ListaCiudadPorDepartamento(idDepartamento);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// Detalles tributarios
        /// </summary>
        /// <returns></returns>
        private List<IdentifyTax> IdentifyTaxes()
        {
            var taxes = new List<IdentifyTax>();
            foreach (var tax in this.BsData.IdentifyTaxes().Where(t => t.Estate))
            {
                taxes.Add(new IdentifyTax
                {
                    Code = tax.Code,
                    Name = tax.Name,
                    Descripcion = tax.Code + "_" + tax.Name + "_" + tax.Descripcion
                });
            }
            return taxes;
        }

        


        private void LoadCustomer()
        {
            try
            {
                var city = this.bussinesModel.GetCityByCustomer("98713702");
                this.cbDepto.SelectedValue = city.Departament.ID;
                this.cbDepto_SelectionChangeCommitted(this.cbDepto, new EventArgs());

                this.cbCity.SelectedValue = city.Code;
                this.cbCodePostal.SelectedValue = city.CodePostal;

                this.cbCiudad_.SelectedValue = city.ID;
                this.txtCodeCity.Text = city.Code;
                this.txtCodePostal.Text = city.CodePostal;
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
        }

        private void cbTipoDocumento_SelectionChangeCommitted(object sender, EventArgs e)
        {
           /* if (cbTipoDocumento.SelectedValue.ToString().Equals("31"))
            {
                this.txtDV.Enabled = true;
            }
            else
            {
                this.txtDV.Enabled = false;
            }*/
        }

        
        /*
        private void cbDetalleTributario_SelectedIndexChanged(object sender, EventArgs e)
        {

            
        }

        

        private void cbInfoTributarioRUT_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        */



        private void cbDetalleTributario_SelectionChangeCommitted(object sender, EventArgs e)
        {
            /*
            lstResponsabilityFiscal.Add(new IdentifyTax
            {
                Code = ((IdentifyTax)cbDetalleTributario.SelectedItem).Code,
                Name = ((IdentifyTax)cbDetalleTributario.SelectedItem).Name,
                Descripcion = ((IdentifyTax)cbDetalleTributario.SelectedItem).Descripcion
            });
            bg.DataSource = null;
            bg.DataSource = lstResponsabilityFiscal;*/
            /**lstDetailsTributary.Adddetails_tributary_clientRow(new DataBaseDS.details_tributary_clientRow
            {
                codigo = ((IdentifyTax)cbDetalleTributario.SelectedItem).Code,
                nombre = ((IdentifyTax)cbDetalleTributario.SelectedItem).Name,
                descripcion = ((IdentifyTax)cbDetalleTributario.SelectedItem).Descripcion.Split(' ')[2]
            });*/

            if (!lstDetailsTributary.Rows.Count.Equals(1))
            {
                if (!(lstDetailsTributary.AsEnumerable().Where(t => t.codigo.Equals(((IdentifyTax)cbDetalleTributario.SelectedItem).Code)).Count() > 0))
                {
                    lstDetailsTributary.Adddetails_tributary_clientRow(lstDetailsTributary.Rows.Count + 1, "",
                        ((IdentifyTax)cbDetalleTributario.SelectedItem).Code,
                        ((IdentifyTax)cbDetalleTributario.SelectedItem).Name,
                        ((IdentifyTax)cbDetalleTributario.SelectedItem).Descripcion.Split('_')[2]);
                    bg.DataSource = null;
                    bg.DataSource = lstDetailsTributary;
                }
            }
        }

        private void btnClearDetalleTributario_Click(object sender, EventArgs e)
        {
            this.lstDetailsTributary.Rows.Clear();
            //lstResponsabilityFiscal.Clear();
            //dgvDetallesTributarios.Rows.Clear();
        }

        private void cbInfoTributarioRUT_SelectionChangeCommitted(object sender, EventArgs e)
        {
            /**
            lstDetailsRUT.Add(new ResponsabilityFiscal
            {
                Code = ((DataRowView)this.cbInfoTributarioRUT.SelectedItem).Row["codigo"].ToString(),
                Name = ((DataRowView)this.cbInfoTributarioRUT.SelectedItem).Row["nombre"].ToString(),
                Descripcion = ((DataRowView)this.cbInfoTributarioRUT.SelectedItem).Row["descripcion"].ToString()
            });
            bgRUT.DataSource = null;
            bgRUT.DataSource = lstDetailsRUT;*/
            
           /* lstDetailsRUT_.Adddetails_rut_clientRow(new DataBaseDS.details_rut_clientRow
            {
                codigo = ((DataRowView)this.cbInfoTributarioRUT.SelectedItem).Row["codigo"].ToString(),
                descripcion = ((DataRowView)this.cbInfoTributarioRUT.SelectedItem).Row["descripcion"].ToString()
            });*/

            if (!(this.lstDetailsRUT_.AsEnumerable().Where(r => r.codigo.Equals(((DataRowView)this.cbInfoTributarioRUT.SelectedItem).Row["codigo"].ToString())).Count() > 0))
            {
                lstDetailsRUT_.Adddetails_rut_clientRow(lstDetailsRUT_.Rows.Count + 1, "",
                    ((DataRowView)this.cbInfoTributarioRUT.SelectedItem).Row["codigo"].ToString(),
                    ((DataRowView)this.cbInfoTributarioRUT.SelectedItem).Row["descripcion"].ToString());
                bgRUT.DataSource = null;
                bgRUT.DataSource = lstDetailsRUT_;
            }
        }

        private void btnClearInfoTributarioRUT_Click(object sender, EventArgs e)
        {
            this.lstDetailsRUT_.Rows.Clear();
            //lstDetailsRUT.Clear();
            //dgvDetallesRUT.Rows.Clear();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (ValidarCampos())
                {
                    if(this.Edit) //if (repositoryModel.ExistsCustomer(this.txtNit.Text))
                    {
                        CustomerModel c = new CustomerModel();

                        c.Document = txtNit.Text;
                        customerEdit.type_person = Convert.ToInt32(cbTipoPersona.SelectedValue);
                        customerEdit.type_document = Convert.ToInt32(cbTipoDocumento.SelectedValue);
                        //customerEdit.nitcliente = txtNit.Text;
                        customerEdit.dv = Convert.ToInt32(txtDV.Text);
                        customerEdit.idregimen = Convert.ToInt32(cbRegimen.SelectedValue);
                        customerEdit.idtipo_cliente = Convert.ToInt32(cbTipoVentas.SelectedValue);
                        customerEdit.id_clasificacion = Convert.ToInt32(cbClasificacionComercial.SelectedValue);

                        customerEdit.name = txtName.Text;
                        customerEdit.last_name = txtLastName.Text;

                        customerEdit.nombrescliente = txtRazonSocial.Text;
                        customerEdit.name_comercial = txtNombreComercial.Text;
                        customerEdit.direccioncliente = txtDireccion.Text;

                        customerEdit.celularcliente = customerEdit.telefonocliente = txtCelular.Text;
                        customerEdit.emailcliente = txtEmail.Text;

                        customerEdit.estadocliente = true;
                        customerEdit.is_customer = true;
                        customerEdit.punto = 0;

                        c.City = new City
                        {
                            ID = Convert.ToInt32(cbCiudad_.SelectedValue),
                            Code = txtCodeCity.Text,
                            CodePostal = txtCodePostal.Text
                        };
                        customerEdit.idciudad = c.City.ID;

                        c.DetailsTributary = lstDetailsTributary;
                        c.DetailsRUT = lstDetailsRUT_;

                        repositoryModel.UpdateCustomer(c, customerEdit);
                        this.Edit = false;
                    }
                    else
                    {
                        CustomerModel c = new CustomerModel();

                        customerEdit = c.Customer.NewclienteRow();

                        customerEdit.type_person = Convert.ToInt32(cbTipoPersona.SelectedValue);
                        customerEdit.type_document = Convert.ToInt32(cbTipoDocumento.SelectedValue);
                        customerEdit.nitcliente = txtNit.Text;
                        customerEdit.dv = Convert.ToInt32(txtDV.Text);
                        customerEdit.idregimen = Convert.ToInt32(cbRegimen.SelectedValue);
                        customerEdit.idtipo_cliente = Convert.ToInt32(cbTipoVentas.SelectedValue);
                        customerEdit.id_clasificacion = Convert.ToInt32(cbClasificacionComercial.SelectedValue);
                        customerEdit.id = 0;

                        customerEdit.name = txtName.Text;
                        customerEdit.last_name = txtLastName.Text;

                        customerEdit.nombrescliente = txtRazonSocial.Text;
                        customerEdit.name_comercial = txtNombreComercial.Text;
                        customerEdit.direccioncliente = txtDireccion.Text;

                        customerEdit.celularcliente = customerEdit.telefonocliente = txtCelular.Text;
                        customerEdit.emailcliente = txtEmail.Text;

                        customerEdit.estadocliente = true;
                        customerEdit.is_customer = true;
                        customerEdit.punto = 0;

                        c.City = new City
                        {
                            ID = Convert.ToInt32(cbCiudad_.SelectedValue),
                            Code = txtCodeCity.Text,
                            CodePostal = txtCodePostal.Text
                        };
                        customerEdit.idciudad = c.City.ID;

                        c.Customer.Rows.Add(customerEdit);

                        c.DetailsTributary = lstDetailsTributary;
                        c.DetailsRUT = lstDetailsRUT_;

                        repositoryModel.AddCustomer(c);
                    }
                    FieldsClear();
                    OptionPane.MessageInformation("El cliente se guardó con éxito.");
                }



                /**
                Customer customer = new Customer();
                customer.TypePerson = cbTipoPersona.SelectedValue.ToString();
                customer.TypeIdentify = Convert.ToInt32(cbTipoDocumento.SelectedValue);
                customer.NIT = txtNit.Text;
                customer.DV = Convert.ToInt32(txtDV.Text);
                customer.Regimen = Convert.ToInt32(cbRegimen.SelectedValue);
                customer.TypeSales = Convert.ToInt32(cbTipoVentas.SelectedValue);
                customer.ComercialClasification = Convert.ToInt32(cbClasificacionComercial.SelectedValue);
                customer.RazonSocial = txtRazonSocial.Text;
                customer.Comercial = txtNombreComercial.Text;
                customer.Direccion = txtDireccion.Text;
                customer.City = new City 
                {
                    ID = Convert.ToInt32(cbCiudad_.SelectedValue) ,
                    Code = txtCodeCity.Text,
                    CodePostal = txtCodePostal.Text
                };
                customer.Contact = new Contact
                {
                    Email = txtEmail.Text,
                    Phone = txtCelular.Text
                };
                customer.IdentifyTaxes = lstResponsabilityFiscal;
                customer.ResponsabilitiesRUT = lstDetailsRUT;
                if (bussinesModel.ExistsCustomer(customer.NIT))
                {
                    customerEdit.type_person = Convert.ToInt32(cbTipoPersona.SelectedValue);
                    customerEdit.type_document = Convert.ToInt32(cbTipoDocumento.SelectedValue);
                    customerEdit.nitcliente = txtNit.Text;
                    customerEdit.dv = Convert.ToInt32(txtDV.Text);
                    customerEdit.idregimen = Convert.ToInt32(cbRegimen.SelectedValue);
                    customerEdit.idtipo_cliente = Convert.ToInt32(cbTipoVentas.SelectedValue);
                    customerEdit.id_clasificacion = Convert.ToInt32(cbClasificacionComercial.SelectedValue);
                    customerEdit.nombrescliente = txtRazonSocial.Text;
                    customerEdit.name_comercial = txtNombreComercial.Text;
                    customerEdit.direccioncliente = txtDireccion.Text;

                    this.repositoryModel.UpdateCustomer(this.customerEdit, customer.City);
                }
                else
                {
                    this.bussinesModel.AddCustomer(customer);
                }
                */
                
                
            }
            catch (Exception ex)
            {
                OptionPane.MessageError("Ocurrió un error al guardar el cliente.\n" + ex.Message);
            }
        }

        private bool ValidarCampos()
        {
            if (this.cbTipoDocumento.SelectedIndex == 0)
            {
                this.miError.SetError(this.cbTipoDocumento, "Debe seleccionar una opción.");
                this.tipoDocumentoMatch = false;
            }
            else
            {
                this.miError.SetError(this.cbTipoDocumento, null);
                this.tipoDocumentoMatch = true;
            }

            if (!String.IsNullOrEmpty(this.txtNit.Text))
            {
                if (Validacion.ValidarEntero(this.txtNit.Text))
                {
                    this.miError.SetError(this.txtNit, null);
                    this.cedulaMatch = true;
                }
                else
                {
                    this.miError.SetError(this.txtNit, "El formato es incorrecto.");
                    this.cedulaMatch = false;
                }
            }
            else
            {
                this.miError.SetError(this.txtNit, "El campo es requerido.");
                this.cedulaMatch = false;
            }

            if (!String.IsNullOrEmpty(this.txtDV.Text))
            {
                if (Validacion.ValidarEntero(this.txtDV.Text))
                {
                    this.miError.SetError(this.txtDV, null);
                    this.dvMatch = true;
                }
                else
                {
                    this.miError.SetError(this.txtDV, "El formato es incorrecto.");
                    this.dvMatch = false;
                }
            }
            else
            {
                this.miError.SetError(this.txtDV, "El campo es requerido.");
                this.dvMatch = false;
            }

            if (!String.IsNullOrEmpty(this.txtRazonSocial.Text))
            {
                this.miError.SetError(this.txtRazonSocial, null);
                this.nombreMatch = true;
            }
            else
            {
                this.miError.SetError(this.txtRazonSocial, "El campo es requerido.");
                this.nombreMatch = false;
            }

            if (!String.IsNullOrEmpty(this.txtDireccion.Text))
            {
                this.miError.SetError(this.txtDireccion, null);
                this.direccionMatch = true;
            }
            else
            {
                this.miError.SetError(this.txtDireccion, "El campo es requerido.");
                this.direccionMatch = false;
            }

            if (!String.IsNullOrEmpty(this.txtCodeCity.Text))
            {
                this.miError.SetError(this.txtCodeCity, null);
                this.codeCityMatch = true;
            }
            else
            {
                this.miError.SetError(this.txtCodeCity, "El campo es requerido.");
                this.codeCityMatch = false;
            }

            if (!String.IsNullOrEmpty(this.txtCodePostal.Text))
            {
                this.miError.SetError(this.txtCodePostal, null);
                this.codePostalMatch = true;
            }
            else
            {
                this.miError.SetError(this.txtCodePostal, "El campo es requerido.");
                this.codePostalMatch = false;
            }

            if (!String.IsNullOrEmpty(this.txtEmail.Text))
            {
                this.miError.SetError(this.txtEmail, null);
                this.emailMatch = true;
            }
            else
            {
                this.miError.SetError(this.txtEmail, "El campo es requerido.");
                this.emailMatch = false;
            }

            if (!String.IsNullOrEmpty(this.txtCelular.Text))
            {
                this.miError.SetError(this.txtCelular, null);
                this.celularMatch = true;
            }
            else
            {
                this.miError.SetError(this.txtCelular, "El campo es requerido.");
                this.celularMatch = false;
            }


            if (this.dgvDetallesTributarios.RowCount > 0)
            {
                this.miError.SetError(this.dgvDetallesTributarios, null);
                this.tributaryMatch = true;
            }
            else
            {
                this.miError.SetError(this.dgvDetallesTributarios, "Debe cargar al menos un registro.");
                this.tributaryMatch = false;
            }

            if (this.dgvDetallesRUT.RowCount > 0)
            {
                this.miError.SetError(this.dgvDetallesRUT, null);
                this.rutMatch = true;
            }
            else
            {
                this.miError.SetError(this.dgvDetallesRUT, "Debe cargar al menos un registro.");
                this.rutMatch = false;
            }

            return tipoDocumentoMatch &&
                     cedulaMatch &&
                     dvMatch &&
                     nombreMatch &&
                     codeCityMatch &&
                     codePostalMatch &&
                     celularMatch &&
                     emailMatch &&
                     direccionMatch &&
                     tributaryMatch &&
                     rutMatch;
        }

        private void FieldsClear()
        {
            this.txtNit.Focus();

            this.cbTipoPersona.SelectedIndex = 0;
            this.cbTipoDocumento.SelectedIndex = 0;
            this.txtNit.Text = "";
            this.txtDV.Text = "";
            this.cbRegimen.SelectedIndex = 0;
            this.cbTipoVentas.SelectedIndex = 0;
            this.cbClasificacionComercial.SelectedIndex = 0;

            this.txtName.Text = "";
            this.txtLastName.Text = "";
            this.txtRazonSocial.Text = "";
            this.txtNombreComercial.Text = "";
            this.txtDireccion.Text = "";

            this.cbDepto.SelectedValue = this.empresa.Departamento.IdDepartamento;
            this.cbDepto_SelectionChangeCommitted(this.cbDepto, new EventArgs());
            this.cbCiudad_.SelectedValue = this.empresa.Ciudad.IdCiudad;
            this.cbCity.SelectedIndex = 0;
            this.cbCodePostal.SelectedIndex = 0;

            this.txtCodeDepto.Text = "";
            this.txtCodeCity.Text = "";
            this.txtCodePostal.Text = "";

            this.txtEmail.Text = "";
            this.txtCelular.Text = "";

            this.cbDetalleTributario.SelectedIndex = 0;
            this.cbInfoTributarioRUT.SelectedIndex = 0;

            //lstResponsabilityFiscal.Clear();
            //lstDetailsRUT.Clear();
            lstDetailsTributary.Rows.Clear();
            lstDetailsRUT_.Rows.Clear();

            this.customerEdit = null;
            this.customerMEdit = null;

            ///dgvDetallesTributarios.Rows.Clear();
            ///dgvDetallesRUT.Rows.Clear();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                if (!String.IsNullOrEmpty(this.txtClienteSearch.Text))
                {
                    this.customerMEdit = this.repositoryModel.GetCustomerByNit(this.txtClienteSearch.Text);
                    this.customerEdit = this.customerMEdit.Customer.FirstOrDefault();
                    if (this.customerEdit != null)
                    {
                        cbTipoPersona.SelectedValue = customerEdit.type_person;
                        cbTipoDocumento.SelectedValue = customerEdit.type_document;
                        txtNit.Text = customerEdit.nitcliente;
                        txtDV.Text = customerEdit.dv.ToString();
                        cbRegimen.SelectedValue = customerEdit.idregimen;
                        cbTipoVentas.SelectedValue = customerEdit.idtipo_cliente;
                        cbClasificacionComercial.SelectedValue = customerEdit.id_clasificacion;

                        txtName.Text = customerEdit.name;
                        txtLastName.Text = customerEdit.last_name;

                        txtRazonSocial.Text = customerEdit.nombrescliente;
                        txtNombreComercial.Text = customerEdit.name_comercial;
                        txtDireccion.Text = customerEdit.direccioncliente;

                        cbDepto.SelectedValue = customerMEdit.City.Departament.ID;
                        cbDepto_SelectionChangeCommitted(cbDepto, new EventArgs());
                        cbCiudad_.SelectedValue = customerMEdit.City.ID;
                        cbCity.SelectedValue = customerMEdit.City.Code;

                        cbCodePostal.SelectedValue = customerMEdit.City.CodePostal;

                        txtCodeDepto.Text = customerMEdit.City.Departament.Code;
                        txtCodeCity.Text = customerMEdit.City.Code;
                        txtCodePostal.Text = customerMEdit.City.CodePostal;

                        txtEmail.Text = customerEdit.emailcliente;
                        txtCelular.Text = customerEdit.celularcliente;

                        this.lstDetailsTributary = customerMEdit.DetailsTributary;
                        bg.DataSource = null;
                        bg.DataSource = lstDetailsTributary;

                        this.lstDetailsRUT_ = customerMEdit.DetailsRUT;
                        bgRUT.DataSource = null;
                        bgRUT.DataSource = lstDetailsRUT_;

                        this.txtClienteSearch.Text = "";

                        this.Edit = true;
                    }
                    else
                    {
                        OptionPane.MessageInformation("No existe cliente con ese NIT.");
                    }

                    /**
                    dgvDetallesTributarios.DataSource = customerMEdit.DetailsTributary;
                    dgvDetallesRUT.DataSource = customerMEdit.DetailsRUT;
                    */

                    /**
                    this.customerEdit = this.repositoryModel.GetCustomerByNit(this.txtClienteSearch.Text).FirstOrDefault();
                    var city = this.repositoryModel.GetCityByCustomer(this.txtClienteSearch.Text);
                    cbTipoPersona.SelectedValue = customerEdit.type_person;
                    cbTipoDocumento.SelectedValue = customerEdit.type_document;
                    txtNit.Text = customerEdit.nitcliente;
                    txtDV.Text = customerEdit.dv.ToString();
                    cbRegimen.SelectedValue = customerEdit.idregimen;
                    cbTipoVentas.SelectedValue = customerEdit.idtipo_cliente;
                    cbClasificacionComercial.SelectedValue = customerEdit.id_clasificacion;
                    txtRazonSocial.Text = customerEdit.nombrescliente;
                    txtNombreComercial.Text = customerEdit.name_comercial;
                    txtDireccion.Text = customerEdit.direccioncliente;
                    cbDepto.SelectedValue = city.Departament.ID;
                    cbCiudad_.SelectedValue = city.ID;

                    txtCodeDepto.Text = city.Departament.Code;
                    txtCodeCity.Text = city.Code;
                    txtCodePostal.Text = city.CodePostal;

                    txtEmail.Text = customerEdit.emailcliente;
                    txtCelular.Text = customerEdit.celularcliente;
                    */

                    //dgvDetallesTributarios
                }
                /*var r = new RepositoryModel();
                var c = r.GetCustomerByNit("1054916821").FirstOrDefault();
                c.nombrescliente = "ALEJANDRO MURILLO";
                r.UpdateCustomer(c);*/
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            this.FieldsClear();
            this.Edit = false;
        }

        private void btnListado_Click(object sender, EventArgs e)
        {
            try
            {
                var frmListado = new FrmCustomerList();
                frmListado.MdiParent = this.MdiParent;
                frmListado.Show();
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
        }

        
    }
}