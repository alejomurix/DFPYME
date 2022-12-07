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
using CustomControl;
using System.Threading;

namespace Aplicacion.Ventas.Cliente
{
    public partial class frmCliente : Form
    {
        #region Atributos De Logica de Negocio

        private DTO.Clases.Empresa miEmpresa;

        /// <summary>
        /// Representa la logica de negocios del Cliente
        /// </summary>
        private BussinesCliente miBussinesCliente;
        private BussinesEmpresa miBussinesEmpresa;
        private BussinesRegimen miBussinesRegimen;
        private BussinesDepartamento miBussinesDepartamento;
        private BussinesCiudad miBussinesCiudad;

        /// <summary>
        /// Objeto que contiene las listas para cargar los criterios
        /// </summary>
        private CargarCriteriosCliente criterios;

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
                     direccionMatch = true;

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
        private frmEditarCliente frmEditar;

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

        public frmCliente()
        {
            InitializeComponent();
            this.ConsultaVenta = false;
            this.ConsultaVentaBtn = false;
            miBussinesEmpresa = new BussinesEmpresa();
            miBussinesCiudad = new BussinesCiudad();
            miBussinesCliente = new BussinesCliente();
            miBussinesDepartamento = new BussinesDepartamento();
            miBussinesRegimen = new BussinesRegimen();
            this.SubConsulta = false;
            this.PressBtn = false;
            try
            {
                miEmpresa = miBussinesEmpresa.ObtenerEmpresa();
            }
            catch (Exception ex)
            {
                CustomControl.OptionPane.MessageError(ex.Message);
            }
        }

        private void IngresarCliente_Load(object sender, EventArgs e)
        {
            try
            {
                CargarRegimen();
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

                    //this.tcClientes.TabPages[0].Hide(); 
                    //tcClientes.Visible = false;
                }
                
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
            if (Convert.ToBoolean(AppConfiguracion.ValorSeccion("electronic_invoice"))) // true; habilita menu fact. electronica.
            {
                //this.tcClientes.TabPages.Remove(this.tpIngresarCliente);
            }
        }

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
                direccionMatch = true;*/
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
        /// Cargar las ciudades segun el id del Departamento.
        /// </summary>
        /// <param name="idDepartamento"></param>
        private void CargarCiudades(int idDepartamento)
        {
            try
            {
                cbCiudad.DataSource = miBussinesCiudad.ListaCiudadPorDepartamento(idDepartamento);
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
                    this.dgvListado1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;*/
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
                var nit = (string)this.dgvListado1.CurrentRow.Cells[0].Value;
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
            /*
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
             */

            if (FacturaVenta)
                CompletaEventos.CapturaEvento(false);


            if (frmEditar != null)
                frmEditar.Close();
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
                ConsultaClienteNit(nitEditado);*/
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
                var frmCanjear = new Administracion.Puntos.FrmCanje();
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
    }

    internal class CargarCriteriosCliente 
    {
        public List<CriterioCliente1> lista1;
        public List<CriterioClietne2> lista2;

        public CargarCriteriosCliente()
        {
            lista1 = new List<CriterioCliente1>();
            lista1.Add(new CriterioCliente1
                       {
                           Id = 1,
                           Nombre = "Por Cedula"
                       });
            lista1.Add(new CriterioCliente1
                       {
                            Id = 2,
                            Nombre = "Por Nombre"
                       });

            lista2 = new List<CriterioClietne2>();
            lista2.Add(new CriterioClietne2
                       {
                           Id = 1,
                           Nombre = "Que sea Igual"
                       });
            lista2.Add(new CriterioClietne2
                       {
                           Id = 2,
                           Nombre = "Que contenga"
                       });
        }
    }

    internal class CriterioCliente1 
    {
        public int Id { set; get; }
        public string Nombre { set; get; }
    }

    internal class CriterioClietne2 
    {
        public int Id { set; get; }
        public String Nombre { set; get; }
    }
}