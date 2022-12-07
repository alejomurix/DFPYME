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
    public partial class FrmCompany : Form
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

        /*private bool ciiu1 = false,
                     ciiu2 = false,
                     ciiu3 = false,
                     ciiu4 = false;*/

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

        private readonly BussinesData BsData;

        //private readonly BussinesEmpresa miBussinesEmpresa;

        //private readonly BussinesCliente miBussinesCliente;

        private BussinesCiudad miBussinesCiudad;

        private readonly BussinesModel bussinesModel;

        private readonly RepositoryModel repositoryModel;


        private CompanyModel companyModel;


        //private Empresa empresa;

        //private DataBaseDS.clienteRow customerEdit;

        //private CustomerModel customerMEdit;


        //private List<IdentifyTax> lstResponsabilityFiscal;

        //private List<ResponsabilityFiscal> lstDetailsRUT;


        //private DataBaseDS.details_tributary_clientDataTable lstDetailsTributary;

        //private DataBaseDS.details_rut_clientDataTable lstDetailsRUT_;

        BindingSource bg;

        BindingSource bgRUT;

        public FrmCompany()
        {
            InitializeComponent();
            dgvDetallesTributarios.AutoGenerateColumns = false;
            dgvDetallesRUT.AutoGenerateColumns = false;

            BsData = new BussinesData();
           // miBussinesEmpresa = new BussinesEmpresa();
            //miBussinesCliente = new BussinesCliente();
            miBussinesCiudad = new BussinesCiudad();
            bussinesModel = new BussinesModel();
            repositoryModel = new RepositoryModel();

            

            //empresa = miBussinesEmpresa.ObtenerEmpresa();
            //lstResponsabilityFiscal = new List<IdentifyTax>();
           // lstDetailsRUT = new List<ResponsabilityFiscal>();


            this.cbTipoPersona.DataSource = BsData.TypesPerson();
            this.cbTipoDocumento.DataSource = BsData.IdDocuments();
            this.cbRegimen.DataSource = BsData.FiscalRegimen();
            //this.cbTipoVentas.DataSource = miBussinesCliente.Tipos();
           // this.cbClasificacionComercial.DataSource = miBussinesCliente.Clasificacion();

            this.companyModel = repositoryModel.Company();
            this.cbTipoPersona.SelectedValue = this.companyModel.Company.type_person;
            this.cbTipoDocumento.SelectedValue = this.companyModel.Company.type_document;
            this.txtNit.Text = this.companyModel.Company.nitempresa;
            this.txtDV.Text = this.companyModel.Company.dv.ToString();
            this.cbRegimen.SelectedValue = this.companyModel.Company.idregimen;
            this.txtRazonSocial.Text = this.companyModel.Company.nombrejuridicoempresa;
            this.txtNombreComercial.Text = this.companyModel.Company.nombrecomercialempresa;

            this.txtDireccion.Text = this.companyModel.Company.direccionempresa;

            this.cbDepto.DataSource = this.bussinesModel.Departamentos();
            this.cbDepto.SelectedValue = this.companyModel.City.Departament.ID;
            this.cbDepto_SelectionChangeCommitted(this.cbDepto, new EventArgs());
            this.cbCiudad_.SelectedValue = this.companyModel.City.ID;
            this.cbCity.SelectedValue = this.companyModel.City.Code;

            this.cbCodePostal.DataSource = this.bussinesModel.CodePostales();
            this.cbCodePostal.SelectedValue = this.companyModel.City.CodePostal;

            this.txtCodeDepto.Text = this.companyModel.City.Departament.Code;
            this.txtCodeCity.Text = this.companyModel.City.Code;
            this.txtCodePostal.Text = this.companyModel.City.CodePostal;

            this.txtEmail.Text = this.companyModel.Company.emailempresa;
            this.txtCelular.Text = this.companyModel.Company.celularempresa;

            dgvDetallesTributarios.DataSource = this.companyModel.DetailsTributary;
            dgvDetallesRUT.DataSource = this.companyModel.DetailsRUT;

            var ciiuRow = this.companyModel.DetailsCIIU.ToArray();
            switch (ciiuRow.Length)
            {
                case 1:
                    {
                        this.txtCIIU1.Text = ciiuRow[0].codigo;
                        break;
                    }
                case 2:
                    {

                        this.txtCIIU1.Text = ciiuRow[0].codigo;
                        this.txtCIIU2.Text = ciiuRow[1].codigo;
                        break;
                    }
                case 3:
                    {
                        this.txtCIIU1.Text = ciiuRow[0].codigo;
                        this.txtCIIU2.Text = ciiuRow[1].codigo;
                        this.txtCIIU3.Text = ciiuRow[2].codigo;
                        break;
                    }
                case 4:
                    {
                        this.txtCIIU1.Text = ciiuRow[0].codigo;
                        this.txtCIIU2.Text = ciiuRow[1].codigo;
                        this.txtCIIU3.Text = ciiuRow[2].codigo;
                        this.txtCIIU4.Text = ciiuRow[3].codigo;
                        break;
                    }
                default:
                    {
                        break;
                    }
            }

            //lstDetailsTributary = new DataBaseDS.details_tributary_clientDataTable();
            //lstDetailsRUT_ = new DataBaseDS.details_rut_clientDataTable();

            bg = new BindingSource();
            bgRUT = new BindingSource();

        }

        private void FrmCompany_Load(object sender, EventArgs e)
        {
            try
            {
                this.cbDetalleTributario.DataSource = this.IdentifyTaxes();
                this.cbInfoTributarioRUT.DataSource = this.BsData.InfoTributary();

                ///dgvDetallesTributarios.AutoGenerateColumns = false;
                //dgvDetallesTributarios.DataSource = bg;
                ///dgvDetallesTributarios.DataSource = this.companyModel.DetailsTributary;

                ///dgvDetallesRUT.AutoGenerateColumns = false;
                ///dgvDetallesRUT.DataSource = this.companyModel.DetailsRUT;
                //dgvDetallesRUT.DataSource = bgRUT;


                //dgvDetallesTributarios
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
        }


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
     

        private void cbDetalleTributario_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (!this.companyModel.DetailsTributary.Rows.Count.Equals(1))
            {
                if (!(this.companyModel.DetailsTributary.AsEnumerable().Where(t => t.codigo.Equals(((IdentifyTax)cbDetalleTributario.SelectedItem).Code)).Count() > 0))
                {
                    this.companyModel.DetailsTributary.Adddetails_tributary_empresaRow(
                        this.companyModel.DetailsTributary.Rows.Count + 1,
                        ((IdentifyTax)cbDetalleTributario.SelectedItem).Code,
                        ((IdentifyTax)cbDetalleTributario.SelectedItem).Name,
                        ((IdentifyTax)cbDetalleTributario.SelectedItem).Descripcion.Split('_')[2]);
                }
            }
            //dgvDetallesTributarios.DataSource = companyModel.DetailsTributary;

            /*lstDetailsTributary.Adddetails_tributary_clientRow(lstDetailsTributary.Rows.Count + 1, "",
                ((IdentifyTax)cbDetalleTributario.SelectedItem).Code,
                ((IdentifyTax)cbDetalleTributario.SelectedItem).Name,
                ((IdentifyTax)cbDetalleTributario.SelectedItem).Descripcion.Split('_')[2]);
            bg.DataSource = null;
            bg.DataSource = lstDetailsTributary;*/
        }

        private void btnClearDetalleTributario_Click(object sender, EventArgs e)
        {
            //this.lstDetailsTributary.Rows.Clear();
            this.companyModel.DetailsTributary.Rows.Clear();
        }

        private void cbInfoTributarioRUT_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (!(this.companyModel.DetailsRUT.AsEnumerable().Where(r => r.codigo.Equals(((DataRowView)this.cbInfoTributarioRUT.SelectedItem).Row["codigo"].ToString())).Count() > 0))
            {
                this.companyModel.DetailsRUT.Adddetails_rut_empresaRow(
                    this.companyModel.DetailsRUT.Rows.Count + 1,
                    ((DataRowView)this.cbInfoTributarioRUT.SelectedItem).Row["codigo"].ToString(),
                    ((DataRowView)this.cbInfoTributarioRUT.SelectedItem).Row["descripcion"].ToString());
            }

            /*lstDetailsRUT_.Adddetails_rut_clientRow(
                lstDetailsRUT_.Rows.Count + 1, "",
                ((DataRowView)this.cbInfoTributarioRUT.SelectedItem).Row["codigo"].ToString(),
                ((DataRowView)this.cbInfoTributarioRUT.SelectedItem).Row["descripcion"].ToString());
            bgRUT.DataSource = null;
            bgRUT.DataSource = lstDetailsRUT_;*/
        }

        private void btnClearInfoTributarioRUT_Click(object sender, EventArgs e)
        {
            this.companyModel.DetailsRUT.Rows.Clear();
            //this.lstDetailsRUT_.Rows.Clear();
        }



        private void btnListadoCIIU_Click(object sender, EventArgs e)
        {
            var frmCIIUList = new FrmCIIUList();
            frmCIIUList.MdiParent = this.MdiParent;
            frmCIIUList.Show();
        }


        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                ////ValidarEmptyCIIU();
                //ValidarCIIU();

                if (ValidarCampos() && ValidarEmptyCIIU() && ValidarCIIU())
                {

                    this.companyModel.Company.type_person = Convert.ToInt32(cbTipoPersona.SelectedValue);
                    this.companyModel.Company.type_document = Convert.ToInt32(cbTipoDocumento.SelectedValue);
                    //this.companyModel.Company.nitempresa = txtNit.Text;
                    this.companyModel.NoIdentify = txtNit.Text;
                    this.companyModel.Company.dv = Convert.ToInt32(txtDV.Text);
                    this.companyModel.Company.idregimen = Convert.ToInt32(cbRegimen.SelectedValue);
                    this.companyModel.Company.nombrejuridicoempresa = this.txtRazonSocial.Text;
                    this.companyModel.Company.nombrecomercialempresa = this.txtNombreComercial.Text;
                    this.companyModel.Company.direccionempresa = this.txtDireccion.Text;
                    this.companyModel.Company.idciudad = Convert.ToInt32(cbCiudad_.SelectedValue);
                    this.companyModel.City = new City
                    {
                        ID = Convert.ToInt32(cbCiudad_.SelectedValue),
                        Code = txtCodeCity.Text,
                        CodePostal = txtCodePostal.Text
                    };
                    this.companyModel.Company.emailempresa = this.txtEmail.Text;
                    this.companyModel.Company.celularempresa = this.txtCelular.Text;

                    var rows = this.companyModel.DetailsTributary.Rows;

                    this.companyModel.DetailsCIIU.Clear();
                    if (!String.IsNullOrEmpty(txtCIIU1.Text))
                    {
                        this.companyModel.DetailsCIIU.Addempresa_ciiuRow(this.companyModel.DetailsCIIU.Rows.Count + 1, this.txtCIIU1.Text);
                    }
                    if (!String.IsNullOrEmpty(txtCIIU2.Text))
                    {
                        this.companyModel.DetailsCIIU.Addempresa_ciiuRow(this.companyModel.DetailsCIIU.Rows.Count + 1, this.txtCIIU2.Text);
                    }
                    if (!String.IsNullOrEmpty(txtCIIU3.Text))
                    {
                        this.companyModel.DetailsCIIU.Addempresa_ciiuRow(this.companyModel.DetailsCIIU.Rows.Count + 1, this.txtCIIU3.Text);
                    }
                    if (!String.IsNullOrEmpty(txtCIIU4.Text))
                    {
                        this.companyModel.DetailsCIIU.Addempresa_ciiuRow(this.companyModel.DetailsCIIU.Rows.Count + 1, this.txtCIIU4.Text);
                    }

                    this.repositoryModel.UpdateCompany(this.companyModel);
                    OptionPane.MessageInformation("La información se guardó con éxito.");
                }

                /*
                if (repositoryModel.ExistsCustomer(this.txtNit.Text))
                {
                    CustomerModel c = new CustomerModel();

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
                */


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
                
                //FieldsClear();
                
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

        private bool ValidarEmptyCIIU()
        {
            try
            {
                bool[] result = 
                { 
                    String.IsNullOrEmpty(this.txtCIIU1.Text), 
                    String.IsNullOrEmpty(this.txtCIIU2.Text), 
                    String.IsNullOrEmpty(this.txtCIIU3.Text), 
                    String.IsNullOrEmpty(this.txtCIIU4.Text) 
                };
                if (result.Where(r => !r).Count() > 0)
                {
                    this.miError.SetError(this.txtCIIU4, null);
                    return true;
                }
                else
                {
                    this.miError.SetError(this.txtCIIU4, "Debe agregar al menos un código CIIU.");
                    return false;
                }

            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
                return false;
            }
        }

        private bool ValidarCIIU()
        {
            try
            {
                bool[] result = { true, true, true, true };
                if (!String.IsNullOrEmpty(this.txtCIIU1.Text))
                {
                    result[0] = repositoryModel.ExisteCIIU(this.txtCIIU1.Text);
                }
                if (!String.IsNullOrEmpty(this.txtCIIU2.Text))
                {
                    result[1] = repositoryModel.ExisteCIIU(this.txtCIIU2.Text);
                }
                if (!String.IsNullOrEmpty(this.txtCIIU3.Text))
                {
                    result[2] = repositoryModel.ExisteCIIU(this.txtCIIU3.Text);
                }
                if (!String.IsNullOrEmpty(this.txtCIIU4.Text))
                {
                    result[3] = repositoryModel.ExisteCIIU(this.txtCIIU4.Text);
                }

                if (result.Where(r => !r).Count() > 0)
                {
                    this.miError.SetError(this.txtCIIU4, "Uno de los códigos CIIU no es valido.");
                    return false;
                }
                else
                {
                    this.miError.SetError(this.txtCIIU4, null);
                    return true;
                }
                
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
                return false;
            }
        }

        private void FieldsClear()
        {
            this.txtNit.Focus();

            this.cbTipoPersona.SelectedIndex = 0;
            this.cbTipoDocumento.SelectedIndex = 0;
            this.txtNit.Text = "";
            this.txtDV.Text = "";
            this.cbRegimen.SelectedIndex = 0;
            this.txtRazonSocial.Text = "";
            this.txtNombreComercial.Text = "";
            this.txtDireccion.Text = "";

            this.cbDepto.SelectedValue = this.companyModel.Company.iddepartamento;
            this.cbDepto_SelectionChangeCommitted(this.cbDepto, new EventArgs());
            this.cbCiudad_.SelectedValue = this.companyModel.Company.idciudad;
            this.cbCity.SelectedIndex = 0;
            this.cbCodePostal.SelectedIndex = 0;

            this.txtCodeDepto.Text = "";
            this.txtCodeCity.Text = "";
            this.txtCodePostal.Text = "";

            this.txtEmail.Text = "";
            this.txtCelular.Text = "";

            this.cbDetalleTributario.SelectedIndex = 0;
            this.cbInfoTributarioRUT.SelectedIndex = 0;

            
            //lstDetailsTributary.Rows.Clear();
            //lstDetailsRUT_.Rows.Clear();

        }

        

        

        
    }
}