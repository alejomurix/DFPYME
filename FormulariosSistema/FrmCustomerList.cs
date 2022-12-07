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

namespace FormulariosSistema
{
    public partial class FrmCustomerList : Form
    {
        private RepositoryModel repositoryModel;

        public FrmCustomerList()
        {
            try
            {
                InitializeComponent();
                this.repositoryModel = new RepositoryModel();
                this.dgvClientes.DataSource = this.repositoryModel.Customers();
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
        }

        private void FrmCustomerList_Load(object sender, EventArgs e)
        {
            try
            {
                
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }

        }

        private void txtNit_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar.Equals((char)Keys.Enter))
            {
                this.btnBuscar_Click(this.btnBuscar, new EventArgs());
            }
        }

        private void txtRazonSocial_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar.Equals((char)Keys.Enter))
            {
                this.btnBuscar_Click(this.btnBuscar, new EventArgs());
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                if (String.IsNullOrEmpty(this.txtNit.Text))
                {
                    // consulta por nombre
                    this.dgvClientes.DataSource = this.repositoryModel.CustomerByName(this.txtRazonSocial.Text);
                }
                else
                {
                    this.dgvClientes.DataSource = this.repositoryModel.CustomerByDocument(this.txtNit.Text);
                    this.txtNit.Text = "";
                }
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
        }

        

        /*
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

        

        private readonly BussinesData BsData;

        private readonly BussinesEmpresa miBussinesEmpresa;

        private readonly BussinesCliente miBussinesCliente;

        private BussinesCiudad miBussinesCiudad;

        private readonly BussinesModel bussinesModel;


        private Empresa empresa;


        private List<IdentifyTax> lstResponsabilityFiscal;

        private List<ResponsabilityFiscal> lstDetailsRUT;

        BindingSource bg;

        BindingSource bgRUT;

        public FrmCustomerList()
        {
            InitializeComponent();

            BsData = new BussinesData();
            miBussinesEmpresa = new BussinesEmpresa();
            miBussinesCliente = new BussinesCliente();
            miBussinesCiudad = new BussinesCiudad();
            bussinesModel = new BussinesModel();

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

            bg = new BindingSource();
            bgRUT = new BindingSource();

            
        

            
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
                    Name = tax.Code + "-" + tax.Name + " " + tax.Descripcion
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
           
        }

       


        private void cbDetalleTributario_SelectionChangeCommitted(object sender, EventArgs e)
        {
            lstResponsabilityFiscal.Add(new IdentifyTax
            {
                Code = ((IdentifyTax)cbDetalleTributario.SelectedItem).Code,
                Name = ((IdentifyTax)cbDetalleTributario.SelectedItem).Name
            });
            bg.DataSource = null;
            bg.DataSource = lstResponsabilityFiscal;
        }

        private void btnClearDetalleTributario_Click(object sender, EventArgs e)
        {
            lstResponsabilityFiscal.Clear();
            dgvDetallesTributarios.Rows.Clear();
        }

        private void cbInfoTributarioRUT_SelectionChangeCommitted(object sender, EventArgs e)
        {
            lstDetailsRUT.Add(new ResponsabilityFiscal
            {
                Code = ((DataRowView)this.cbInfoTributarioRUT.SelectedItem).Row["codigo"].ToString(),
                Name = ((DataRowView)this.cbInfoTributarioRUT.SelectedItem).Row["descripcion"].ToString()
            });
            bgRUT.DataSource = null;
            bgRUT.DataSource = lstDetailsRUT;
        }

        private void btnClearInfoTributarioRUT_Click(object sender, EventArgs e)
        {
            lstDetailsRUT.Clear();
            dgvDetallesRUT.Rows.Clear();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
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

                }
                else
                {
                    this.bussinesModel.AddCustomer(customer);
                }
                
                FieldsClear();
                OptionPane.MessageInformation("El cliente se guardó con exitó.");
            }
            catch (Exception ex)
            {
                OptionPane.MessageError("Ocurrió un error al guardar el cliente.\n" + ex.Message);
            }
        }

        private void FieldsClear()
        {
            this.cbTipoPersona.SelectedIndex = 0;
            this.cbTipoDocumento.SelectedIndex = 0;
            this.txtNit.Text = "";
            this.txtDV.Text = "";
            this.cbRegimen.SelectedIndex = 0;
            this.cbTipoVentas.SelectedIndex = 0;
            this.cbClasificacionComercial.SelectedIndex = 0;
            this.txtRazonSocial.Text = "";
            this.txtNombreComercial.Text = "";
            this.txtDireccion.Text = "";

            this.cbDepto.SelectedValue = this.empresa.Departamento.IdDepartamento;
            this.cbDepto_SelectionChangeCommitted(this.cbDepto, new EventArgs());
            this.cbCiudad_.SelectedValue = this.empresa.Ciudad.IdCiudad;

            this.txtEmail.Text = "";
            this.txtCelular.Text = "";
            lstResponsabilityFiscal.Clear();
            lstDetailsRUT.Clear();
            dgvDetallesTributarios.Rows.Clear();
            dgvDetallesRUT.Rows.Clear();
        }

        */
    }
}