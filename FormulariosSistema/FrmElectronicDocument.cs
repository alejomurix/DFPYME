using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DataAccessLayer.Repository;
using DataAccessLayer.Models;
using CustomControl;
using DTO;
using Utilities;


namespace FormulariosSistema
{
    public partial class FrmElectronicDocument : Form
    {
        private string TypeEnviroment;

        private string DefaultValuePayment = "10";  /// 10 : Efectivo
                                                    /// 
        private string DefaultMoneda = "COP";

        private string DefaultCodeStandard = "999";

        private string CodeReteIVA = "05";

        private string CodeReteICA = "07";

        private int TransferValueQuantity = 987654;

        private int TransferValuePrice = 654987;

        private ErrorProvider error;

        private RepositoryDataFiscal repositoryData;

        private RepositoryModel repositoryModel;


        private CustomerModel customerModel;

        ///private DocumentEModel DocumentModel;

        private ElectronicDocument Document;

        private Item item;

        private Item TotalInvoice;

        private int IdCaja;


        private bool RequiereCantidad;


        //private List<Item> items;

        public FrmElectronicDocument()
        {
            InitializeComponent();
            this.dgvListItems.Size = new Size(this.dgvListItems.Size.Width, 290);

            try
            {
                this.error = new ErrorProvider();
                this.repositoryData = new RepositoryDataFiscal();
                this.repositoryModel = new RepositoryModel();

                this.customerModel = new CustomerModel();
                //this.DocumentModel = new DocumentEModel();
                this.Document = new ElectronicDocument();

                this.TotalInvoice = new Item();

                this.dgvListItems.AutoGenerateColumns = false;
                this.dgvItems.AutoGenerateColumns = false;
                this.dgvTaxRetenciones.AutoGenerateColumns = false;
                //items = new List<Item>();

                this.TypeEnviroment = Convert.ToString(AppConfiguracion.ValorSeccion("type_enviroment"));
                this.IdCaja = Convert.ToInt32(AppConfiguracion.ValorSeccion("id_caja"));
                RequiereCantidad = Convert.ToBoolean(AppConfiguracion.ValorSeccion("reqCantidad"));


                LoadDatos();
                /**
                this.cbTypeDocument.DataSource = this.repositoryData.TypesElectronicDocument();
                this.cbTypeDocument_SelectionChangeCommitted(this.cbTypeDocument, new EventArgs());
                this.cbMetodoPago.DataSource = this.repositoryData.MetodoPago();
                this.cbMedioPago.DataSource = this.repositoryData.MedioPago();
                this.cbMedioPago.SelectedValue = this.DefaultValuePayment;
                */
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
        }

        private void FrmElectronicDocument_Load(object sender, EventArgs e)
        {
            try
            {
                //this.dgvListItems.Hide();
                this.dgvListItems.Visible = false;
                this.txtProductCode.Focus();
                CompletaEventos.Completa += new CompletaEventos.CompletaAccion(CompletaEventos_Completo);
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
        }


        public void LoadDatos()
        {
            try
            {
                this.cbTypeDocument.DataSource = this.repositoryData.TypesElectronicDocument();
                this.cbTypeDocument_SelectionChangeCommitted(this.cbTypeDocument, new EventArgs());
                this.cbMetodoPago.DataSource = this.repositoryData.MetodoPago();
                this.cbMedioPago.DataSource = this.repositoryData.MedioPago();
                this.cbMedioPago.SelectedValue = this.DefaultValuePayment;

                this.cbRetencion.DataSource = this.TaxRetencion();
                this.cbRetencion_SelectionChangeCommitted(this.cbRetencion, new EventArgs());

                this.txtProductCode.Focus();
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
        }

        public void LoadDocument(int id)
        {
            try
            {

            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
        }

        private void FrmElectronicDocument_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.F2:
                    {
                        //this.btnNew_Click(this.btnNew, new EventArgs());
                        break;
                    }
                case Keys.F3:
                    {
                        this.dgvListItems.Visible = true;
                        break;
                    }
                case Keys.F4:
                    {
                        this.btnQuantity_Click(this.btnQuantity, new EventArgs());
                        break;
                    }
                case Keys.F6:
                    {
                        this.btnPrice_Click(this.btnPrice, new EventArgs());
                        break;
                    }
                case Keys.F7:
                    {
                        this.btnDelete_Click(this.btnDelete, new EventArgs());
                        break;
                    }
                case Keys.F8:
                    {
                        this.btnSave_Click(this.btnSave, new EventArgs());
                        break;
                    }
                case Keys.Escape:
                    {
                        this.dgvListItems.Hide();
                        this.txtProductCode.Focus();
                        break;
                    }
            }
        }

        private void FrmElectronicDocument_FormClosing(object sender, FormClosingEventArgs e)
        {
            /*if (this.dgvItems.RowCount > 0 && !String.IsNullOrEmpty(this.txtNit.Text))
            {
                
            }*/
            DialogResult rta = MessageBox.Show("¿Está seguro(a) de salir?", "Documento Electronico",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (rta.Equals(DialogResult.Yes))
            {
                e.Cancel = false;
            }
        }


        private void txtCliente_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar.Equals((char)Keys.Enter))
            {
                try
                {
                    
                    // validar campo vacio
                    
                    if (!String.IsNullOrEmpty(this.txtCliente.Text))
                    {
                        error.SetError(this.txtNit, null);

                        this.customerModel = this.repositoryModel.GetCustomerByNit(this.txtCliente.Text);
                        //var customer = this.customerModel.Customer.FirstOrDefault();
                        // validar email
                        this.txtNit.Text = this.customerModel.Cliente.nitcliente;
                        this.txtNameCliente.Text = this.customerModel.Cliente.nombrescliente;
                        this.txtEmail.Text = this.customerModel.Cliente.emailcliente;
                        this.txtCliente.Text = "";
                    }
                    
                }
                catch (Exception ex)
                {
                    OptionPane.MessageError(ex.Message);
                }
            }
           // this.listBox1.Location = new Point(70, 115);
            //this.lblCantidad.Location =
                   //new Point(this.lblCantidad.Location.X - menosWidth, this.lblCantidad.Location.Y);
            /*this.listBox1.Height = 295;
            this.listBox1.Width = 400;
            this.listBox1.Visible = true;*/
        }

        private void btnCustomerList_Click(object sender, EventArgs e)
        {
            var frmCustomerList = new FrmCustomerList();
            frmCustomerList.Show();
        }

        private void cbTypeDocument_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                this.cbTypeInvoic.DataSource = 
                    this.repositoryData.TypesElectronicInvoic(this.cbTypeDocument.SelectedValue.ToString());
                this.cbTypeOp.DataSource =
                    this.repositoryData.TypesOperation(this.cbTypeDocument.SelectedValue.ToString());
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
        }

        private void cbMetodoPago_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (Convert.ToInt32(this.cbMetodoPago.SelectedValue).Equals(2))
            {
                this.dtFechaLimite.Enabled = true;
            }
            else
            {
                this.dtFechaLimite.Enabled = false;
            }
        }

        private void txtProductCode_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar.Equals((char)Keys.Enter))
            {
                try
                {
                    if (CodigoOrString(this.txtProductCode.Text))
                    {
                        //item = this.repositoryModel.GetItem(this.txtProductCode.Text);
                        if (this.dgvListItems.Visible)
                        {
                            this.dgvListItems.DataSource = null;
                            this.dgvListItems.DataSource = this.repositoryModel.Productos(this.txtProductCode.Text);
                        }
                        else
                        {
                            this.ValidateDEEdit();
                            this.LoadItem(this.txtProductCode.Text, 0);
                        }

                        /*
                        if (!item.Code.Equals(""))
                        {
                            this.txtProduct.Text = item.Description;
                            this.txtPrice.Text = UseObject.InsertSeparatorMil(Convert.ToInt32(item.Neto).ToString());

                            if (this.RequiereCantidad)
                            {
                                this.txtCantidad.Focus();
                            }
                            else
                            {
                                if (!String.IsNullOrEmpty(this.txtCantidad.Text))
                                {
                                    error.SetError(this.txtCantidad, null);
                                    this.LoadItemDE();
                                }
                                else
                                {
                                    error.SetError(this.txtCantidad, "La cantidad no debe ser vacio.");
                                }
                            }

                        }
                        else
                        {
                            OptionPane.MessageInformation("El código no existe.");
                        }
                        */
                    }
                    else
                    {
                        //this.dgvListItems.Show();
                        this.dgvListItems.Visible = true;
                        this.dgvListItems.DataSource = this.repositoryModel.Productos(this.txtProductCode.Text.Split(' '));
                        
                    }


                    /*
                    item = this.repositoryModel.GetItem(this.txtProductCode.Text);

                    if (!item.Code.Equals(""))
                    {
                        this.txtProduct.Text = item.Description;
                        this.txtPrice.Text = UseObject.InsertSeparatorMil(Convert.ToInt32(item.Neto).ToString());

                        if (this.RequiereCantidad)
                        {
                            this.txtCantidad.Focus();
                        }
                        else
                        {
                            if (!String.IsNullOrEmpty(this.txtCantidad.Text))
                            {
                                error.SetError(this.txtCantidad, null);
                                this.LoadItemDE();
                            }
                            else
                            {
                                error.SetError(this.txtCantidad, "La cantidad no debe ser vacio.");
                            }
                        }

                    }
                    else
                    {
                        OptionPane.MessageInformation("El código no existe.");
                    }
                    */

                }
                catch (Exception ex)
                {
                    OptionPane.MessageError(ex.Message);
                }

                /*
                        //item.ID = this.Document.Items.Count + 1;
                        item.Quantity = Convert.ToDouble(this.txtCantidad.Text.Replace('.', ','));
                        item.SubTotal = item.UnitPrice * item.Quantity;

                        item.Neto = Math.Round((Convert.ToDouble(item.UnitPrice) * (1 + (item.IVA / 100))), 2)
                            + item.IC;
                        item.Total = Math.Round(item.Neto * item.Quantity, 2);

                        if (item.TypeStandar.CodeStandard.Equals(this.DefaultCodeStandard))
                        {
                            item.TypeStandar.CodeItem = item.Code;
                        }

                        if (this.Document.ID.Equals(0))
                        {
                            //insert doc
                            this.DataDocument();
                            this.Document = this.repositoryModel.AddElectronicDocument(this.Document);
                            this.txtNoDE.Text = this.Document.Numero;
                            item.IDDE = this.Document.ID;
                            item.ID = this.repositoryModel.AddItem(item);
                            this.Document.Items.Add(item);
                        }
                        else
                        {
                            item.IDDE = this.Document.ID;
                            item.ID = this.repositoryModel.AddItem(item);
                            this.Document.Items.Add(item);
                        }

                        LoadGridView();
                        this.txtCantidad.Text = "1";
                        this.txtProductCode.Focus();
                        this.txtProductCode.Text = "";
                        */
            }
           /* else
            {
                try
                {
                    this.dgvListItems.Show();
                    var bProduct = new BussinesLayer.Clases.BussinesProducto();
                    this.dgvListItems.DataSource = bProduct.Productos(this.txtProductCode.Text.Split(' '));
                }catch{}
            }*/
        }

        private void txtProductCode_KeyPress_(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar.Equals((char)Keys.Enter))
            {
                try
                {
                    if (CodigoOrString(this.txtProductCode.Text))
                    {
                        if (this.dgvListItems.Visible)
                        {
                            this.dgvListItems.DataSource = this.repositoryModel.Productos(this.txtProductCode.Text);
                        }
                        else
                        {
                            LoadItem(this.txtProductCode.Text, 0);
                        }

                        /**item = this.repositoryModel.GetItem(this.txtProductCode.Text);
                        
                        if (!item.Code.Equals(""))
                        {
                            this.txtProduct.Text = item.Description;
                            this.txtPrice.Text = UseObject.InsertSeparatorMil(Convert.ToInt32(item.Neto).ToString());

                            if (this.RequiereCantidad)
                            {
                                this.txtCantidad.Focus();
                            }
                            else
                            {
                                if (!String.IsNullOrEmpty(this.txtCantidad.Text))
                                {
                                    error.SetError(this.txtCantidad, null);
                                    this.LoadItemDE();
                                }
                                else
                                {
                                    error.SetError(this.txtCantidad, "La cantidad no debe ser vacio.");
                                }
                            }

                        }
                        else
                        {
                            OptionPane.MessageInformation("El código no existe.");
                        }
                        */
                    }
                    else
                    {
                        
                        this.dgvListItems.DataSource = this.repositoryModel.Productos(this.txtProductCode.Text.Split(' '));
                        //this.dgvListItems.Show();
                        this.dgvListItems.Visible = true;
                    }


                    /*
                    item = this.repositoryModel.GetItem(this.txtProductCode.Text);

                    if (!item.Code.Equals(""))
                    {
                        this.txtProduct.Text = item.Description;
                        this.txtPrice.Text = UseObject.InsertSeparatorMil(Convert.ToInt32(item.Neto).ToString());

                        if (this.RequiereCantidad)
                        {
                            this.txtCantidad.Focus();
                        }
                        else
                        {
                            if (!String.IsNullOrEmpty(this.txtCantidad.Text))
                            {
                                error.SetError(this.txtCantidad, null);
                                this.LoadItemDE();
                            }
                            else
                            {
                                error.SetError(this.txtCantidad, "La cantidad no debe ser vacio.");
                            }
                        }

                    }
                    else
                    {
                        OptionPane.MessageInformation("El código no existe.");
                    }
                    */

                }
                catch (Exception ex)
                {
                    OptionPane.MessageError(ex.Message);
                }

                /*
                        //item.ID = this.Document.Items.Count + 1;
                        item.Quantity = Convert.ToDouble(this.txtCantidad.Text.Replace('.', ','));
                        item.SubTotal = item.UnitPrice * item.Quantity;

                        item.Neto = Math.Round((Convert.ToDouble(item.UnitPrice) * (1 + (item.IVA / 100))), 2)
                            + item.IC;
                        item.Total = Math.Round(item.Neto * item.Quantity, 2);

                        if (item.TypeStandar.CodeStandard.Equals(this.DefaultCodeStandard))
                        {
                            item.TypeStandar.CodeItem = item.Code;
                        }

                        if (this.Document.ID.Equals(0))
                        {
                            //insert doc
                            this.DataDocument();
                            this.Document = this.repositoryModel.AddElectronicDocument(this.Document);
                            this.txtNoDE.Text = this.Document.Numero;
                            item.IDDE = this.Document.ID;
                            item.ID = this.repositoryModel.AddItem(item);
                            this.Document.Items.Add(item);
                        }
                        else
                        {
                            item.IDDE = this.Document.ID;
                            item.ID = this.repositoryModel.AddItem(item);
                            this.Document.Items.Add(item);
                        }

                        LoadGridView();
                        this.txtCantidad.Text = "1";
                        this.txtProductCode.Focus();
                        this.txtProductCode.Text = "";
                        */
            }
            /* else
             {
                 try
                 {
                     this.dgvListItems.Show();
                     var bProduct = new BussinesLayer.Clases.BussinesProducto();
                     this.dgvListItems.DataSource = bProduct.Productos(this.txtProductCode.Text.Split(' '));
                 }catch{}
             }*/
        }

        private void txtCantidad_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (e.KeyChar.Equals((char)Keys.Enter))
                {

                    if (!String.IsNullOrEmpty(this.txtCantidad.Text))
                    {
                        error.SetError(this.txtCantidad, null);
                        if (this.item != null && !String.IsNullOrEmpty(this.item.Code))
                        {
                            this.LoadItemDE();
                        }
                        else
                        {
                            this.txtProductCode.Focus();
                        }

                        /*if (this.item == null)
                        {
                            this.txtProductCode.Focus();
                        }
                        else
                        {
                            this.LoadItemDE();
                        }*/
                    }
                    else
                    {
                        error.SetError(this.txtCantidad, "La cantidad no debe ser vacio.");
                    }
                }
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }

            /*
            if (!String.IsNullOrEmpty(this.txtCantidad.Text))
            {
                error.SetError(this.txtCantidad, null);
                this.LoadItemDE();
            }
            else
            {
                error.SetError(this.txtCantidad, "La cantidad no debe ser vacio.");
            }*/
        }


        private void LoadItem(string code, double price)
        {
            try
            {
                item = this.repositoryModel.GetItem(code);
                if (!item.Code.Equals(""))
                {
                    // calculo base del producto
                    
                    if (price > 0)
                    {
                        item.Neto = price;
                    }
                    else
                    {
                        if (this.customerModel.Cliente != null)
                        {
                            switch (this.customerModel.Cliente.idtipo_cliente)
                            {
                                case 2:
                                    {
                                        item.Neto = item.Price2;
                                        break;
                                    }
                                case 3:
                                    {
                                        item.Neto = item.Price3;
                                        break;
                                    }
                                case 4:
                                    {
                                        item.Neto = item.Price4;
                                        break;
                                    }
                            }
                        }
                    }
                    

                    /*
                    if (price.Equals(0) && this.customerModel.Cliente != null)
                    {
                        switch (this.customerModel.Cliente.idtipo_cliente)
                        {
                            case 2:
                                {
                                    item.Neto = item.Price2;
                                    break;
                                }
                            case 3:
                                {
                                    item.Neto = item.Price3;
                                    break;
                                }
                            case 4:
                                {
                                    item.Neto = item.Price4;
                                    break;
                                }
                        }
                    }
                    else
                    {
                        item.Neto = price;
                    }
                    */

                    item.UnitPrice = item.Neto - item.IC;
                    item.UnitPrice = Math.Round(item.UnitPrice / (1 + (item.IVA / 100)), 2);

                    this.txtProduct.Text = item.Description;
                    this.txtPrice.Text = UseObject.InsertSeparatorMil(Convert.ToInt32(item.Neto).ToString());

                    if (this.RequiereCantidad)
                    {
                        this.txtCantidad.Focus();
                    }
                    else
                    {
                        if (!String.IsNullOrEmpty(this.txtCantidad.Text))
                        {
                            error.SetError(this.txtCantidad, null);
                            this.LoadItemDE();
                        }
                        else
                        {
                            error.SetError(this.txtCantidad, "La cantidad no debe ser vacio.");
                        }
                    }
                }
                else
                {
                    OptionPane.MessageInformation("El código no existe.");
                }
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
        }

        private void LoadItemDE()
        {
            if (ValidateDouble(this.txtCantidad.Text))
            {
                error.SetError(this.txtCantidad, null);

                /// validacion item duplicado
                if (this.Document.Items.Exists(i => i.Code.Equals(item.Code) && i.UnitPrice.Equals(item.UnitPrice)))
                {
                    foreach (Item item in this.Document.Items.Where(i => i.Code.Equals(item.Code)))
                    {
                        item.Quantity += Convert.ToDouble(this.txtCantidad.Text.Replace('.', ','));
                        item.SubTotal = item.UnitPrice * item.Quantity;
                        item.Total = Math.Round(item.Neto * item.Quantity, 2);
                        UpdateQuantityOrPrice(item);
                    }
                }
                else
                {
                    item.Quantity = Convert.ToDouble(this.txtCantidad.Text.Replace('.', ','));
                    item.SubTotal = item.UnitPrice * item.Quantity;

                    item.Neto = Math.Round((Convert.ToDouble(item.UnitPrice) * (1 + (item.IVA / 100))), 3)
                        + item.IC;
                    item.Total = Math.Round(item.Neto * item.Quantity, 3);

                    if (item.TypeStandar.CodeStandard.Equals(this.DefaultCodeStandard))
                    {
                        item.TypeStandar.CodeItem = item.Code;
                    }

                    if (this.Document.ID.Equals(0))
                    {
                        //insert doc
                        this.DataDocument();
                        this.Document = this.repositoryModel.AddElectronicDocument(this.Document);
                        this.txtNoDE.Text = this.Document.Numero;
                        item.IDDE = this.Document.ID;
                        item.ID = this.repositoryModel.AddItem(item);
                        this.Document.Items.Add(item);
                    }
                    else
                    {
                        item.IDDE = this.Document.ID;
                        item.ID = this.repositoryModel.AddItem(item);
                        this.Document.Items.Add(item);
                    }
                }

                LoadGridView();
                this.txtCantidad.Text = "1";
                this.txtProductCode.Focus();
                this.txtProductCode.Text = "";
                item = null;
            }
            else
            {
                error.SetError(this.txtCantidad, "La cantidad es incorrecta.");
            }
        }

        private void LoadItemDE_(string code, double price)
        {
            item = this.repositoryModel.GetItem(code); //this.txtProductCode.Text

            if (ValidateDouble(this.txtCantidad.Text))
            {
                error.SetError(this.txtCantidad, null);

                /// validacion item duplicado
                if (this.Document.Items.Exists(i => i.Code.Equals(item.Code) && i.UnitPrice.Equals(item.UnitPrice)))
                {
                    foreach (Item it in this.Document.Items.Where(i => i.Code.Equals(item.Code)))
                    {
                        it.Quantity += Convert.ToDouble(this.txtCantidad.Text.Replace('.', ','));
                        it.SubTotal = it.UnitPrice * it.Quantity;
                        it.Total = Math.Round(it.Neto * it.Quantity, 2);
                        UpdateQuantityOrPrice(it);
                    }
                }
                else
                {
                    item.Quantity = Convert.ToDouble(this.txtCantidad.Text.Replace('.', ','));
                    item.SubTotal = item.UnitPrice * item.Quantity;

                    item.Neto = Math.Round((Convert.ToDouble(item.UnitPrice) * (1 + (item.IVA / 100))), 2)
                        + item.IC;
                    item.Total = Math.Round(item.Neto * item.Quantity, 2);

                    if (item.TypeStandar.CodeStandard.Equals(this.DefaultCodeStandard))
                    {
                        item.TypeStandar.CodeItem = item.Code;
                    }

                    if (this.Document.ID.Equals(0))
                    {
                        //insert doc
                        this.DataDocument();
                        this.Document = this.repositoryModel.AddElectronicDocument(this.Document);
                        this.txtNoDE.Text = this.Document.Numero;
                        item.IDDE = this.Document.ID;
                        item.ID = this.repositoryModel.AddItem(item);
                        this.Document.Items.Add(item);
                    }
                    else
                    {
                        item.IDDE = this.Document.ID;
                        item.ID = this.repositoryModel.AddItem(item);
                        this.Document.Items.Add(item);
                    }
                }

                LoadGridView();
                this.txtCantidad.Text = "1";
                this.txtProductCode.Focus();
                this.txtProductCode.Text = "";
                item = null;
            }
            else
            {
                error.SetError(this.txtCantidad, "La cantidad es incorrecta.");
            }
        }




        private void DataDocument()
        {
            if (!String.IsNullOrEmpty(this.txtNit.Text))
            {
                this.Document.NitCliente = this.txtNit.Text;
            }
            this.Document.Tipo = this.cbTypeDocument.SelectedValue.ToString();
            this.Document.TipoFactura = this.cbTypeInvoic.SelectedValue.ToString();
            this.Document.TipoOperacion = this.cbTypeOp.SelectedValue.ToString();
            //this.Document.TipoAmbiente = this.cbti
            //this.Document.Numero = "3";
            this.Document.Moneda = this.DefaultMoneda;
            //this.Document.IdResolucion = 1;
            this.Document.MetodoPago = Convert.ToInt32(this.cbMetodoPago.SelectedValue);
            this.Document.MedioPago = this.cbMedioPago.SelectedValue.ToString();
            this.Document.TipoAmbiente = this.TypeEnviroment;
            this.Document.VUBL = "UBL 2.1";
            this.Document.VDIAN = "DIAN 2.1";
            this.Document.IdCaja = this.IdCaja;
        }

        private void txtNoDocument_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar.Equals((char)Keys.Enter))
            {
                this.btnBuscarDocument_Click(this.btnBuscarDocument, new EventArgs());
            }
        }

        private void btnBuscarDocument_Click(object sender, EventArgs e)
        {
            try
            {
                if (!String.IsNullOrEmpty(this.txtNoDocument.Text))
                {
                    if (!this.repositoryModel.GetDocumentEstate(this.txtNoDocument.Text)) // false: documento temporal; true fact electronica
                    {
                        this.Document = this.repositoryModel.GetDocument(this.txtNoDocument.Text); /// validaciones

                        this.customerModel = null;
                        this.txtNit.Text = "";
                        this.txtNameCliente.Text = "";
                        this.txtEmail.Text = "";

                        if (!String.IsNullOrEmpty(this.Document.Numero))
                        {
                            this.cbTypeDocument.SelectedValue = this.Document.Tipo;
                            this.cbTypeInvoic.SelectedValue = this.Document.TipoFactura;
                            this.cbTypeOp.SelectedValue = this.Document.TipoOperacion;
                            this.cbMetodoPago.SelectedValue = this.Document.MetodoPago;
                            this.cbMedioPago.SelectedValue = this.Document.MedioPago;
                            this.dtFechaLimite.Value = this.Document.FechaPago;
                            if (this.Document.MetodoPago.Equals(2))
                            {
                                this.dtFechaLimite.Enabled = true;
                            }
                            this.txtNoDE.Text = this.Document.Numero;

                            this.txtCliente.Text = this.Document.NitCliente;
                            this.txtCliente_KeyPress(this.txtCliente, new KeyPressEventArgs((char)Keys.Enter));
                            LoadGridView();
                            this.dgvTaxRetenciones.DataSource = this.Document.Retentions;
                            this.txtNoDocument.Text = "";
                        }
                        else
                        {
                            OptionPane.MessageInformation("El número de documento  no existe.");
                        }
                    }
                    else
                    {
                        OptionPane.MessageInformation("El número de documento no se puede editar.");
                    }
                }
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
        }

        private void LoadGridView()
        {
            this.TotalInvoice.SubTotal = this.Document.Items.Sum(s => s.SubTotal);
            this.TotalInvoice.IVA = Math.Round(this.Document.Items.Sum(s => ((s.UnitPrice * s.Quantity) * s.IVA / 100)), 2);
            this.TotalInvoice.IC = Math.Round(this.Document.Items.Sum(s => s.IC * s.Quantity), 2);
            this.TotalInvoice.Total = this.TotalInvoice.SubTotal + this.TotalInvoice.IVA + this.TotalInvoice.IC;
                //Math.Round(this.Document.Items.Sum(s => s.Total), 2);
            this.TotalInvoice.Retention = Math.Round(this.Document.Retentions.Sum(s => s.Value), 2);
            this.TotalInvoice.Neto = this.TotalInvoice.Total - this.TotalInvoice.Retention;

            this.txtSubtotal.Text = UseObject.InsertSeparatorMil(this.TotalInvoice.SubTotal.ToString());
            this.txtIVA.Text = UseObject.InsertSeparatorMil(this.TotalInvoice.IVA.ToString());
            this.txtIC.Text = UseObject.InsertSeparatorMil(this.TotalInvoice.IC.ToString());
            this.txtTotalPie.Text = UseObject.InsertSeparatorMil(this.TotalInvoice.Total.ToString());
            this.txtRetencion.Text = UseObject.InsertSeparatorMil(this.TotalInvoice.Retention.ToString());
            this.txtNeto.Text = UseObject.InsertSeparatorMil(this.TotalInvoice.Neto.ToString());

            /*
            this.txtTotal.Text = UseObject.InsertSeparatorMil(
                Math.Round(this.Document.Items.Sum(s => s.Total), 2).ToString());
            */
            this.txtTotal.Text = UseObject.InsertSeparatorMil(this.TotalInvoice.Total.ToString());
            

            this.dgvItems.DataSource = null;
            this.dgvItems.DataSource = this.Document.Items.OrderBy(o => o.ID).ToList();
            if (dgvItems.RowCount > 0)
            {
                this.dgvItems.FirstDisplayedCell =
                    this.dgvItems.Rows[this.dgvItems.Rows.Count - 1].Cells[0];
            }
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            LoadDatos();
            this.dtFechaLimite.Value = DateTime.Now;
            this.dtFechaLimite.Enabled = false;
            this.txtNit.Text = "";
            this.txtNameCliente.Text = "";
            this.txtEmail.Text = "";
            this.txtNota.Text = "";
            this.txtProduct.Text = "";
            this.txtPrice.Text = "";
            this.txtCantidad.Text = "1";
            this.dgvItems.DataSource = null;
            this.dgvTaxRetenciones.DataSource = null;
            this.txtTotal.Text = "0";
            this.txtNoDocument.Text = "";
            this.txtNoDE.Text = "";

            this.txtSubtotal.Text = "0";
            this.txtIVA.Text = "0";
            this.txtIC.Text = "0";
            this.txtTotalPie.Text = "0";
            this.txtRetencion.Text = "0";
            this.txtNeto.Text = "0";

            this.txtProductCode.Focus();

            this.customerModel = new CustomerModel();
            this.Document = new ElectronicDocument();

        }

        private void btnQuantity_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.Document.Items.Count > 0)
                {
                    var frmDEOption = new FrmDEOption();
                    frmDEOption.Extend = true;
                    frmDEOption.TransferValue = this.TransferValueQuantity;
                    frmDEOption.txtValue.Text = Convert.ToDouble(this.Document.Items.Where(i => i.ID.Equals
                                (Convert.ToInt32(this.dgvItems.CurrentRow.Cells["Id"].Value))).First().Quantity).ToString();
                    frmDEOption.ShowDialog();
                    this.txtProductCode.Focus();
                }
                else
                {
                    OptionPane.MessageInformation("No hay articulos para editar.");
                }
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
        }

        private void btnPrice_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.Document.Items.Count > 0)
                {
                    var frmDEOption = new FrmDEOption();
                    frmDEOption.Extend = true;
                    frmDEOption.TransferValue = this.TransferValuePrice;
                    frmDEOption.txtValue.Text = Convert.ToInt32(this.Document.Items.Where(i => i.ID.Equals
                                (Convert.ToInt32(this.dgvItems.CurrentRow.Cells["Id"].Value))).First().Neto).ToString();
                    frmDEOption.ShowDialog();
                    this.txtProductCode.Focus();
                }
                else
                {
                    OptionPane.MessageInformation("No hay articulos para editar.");
                }
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.Document.Items.Count > 0)
                {
                    DialogResult rta = MessageBox.Show("¿Está seguro(a) de retirar el producto?", "Documento Electronico",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (rta.Equals(DialogResult.Yes))
                    {
                        var id = Convert.ToInt32(this.dgvItems.CurrentRow.Cells["Id"].Value);
                        this.repositoryModel.DeleteItemDE(id);
                        this.Document.Items.Remove(this.Document.Items.Where(i => i.ID.Equals(id)).First());
                        this.txtProductCode.Focus();
                        this.LoadGridView();
                    }
                }
                else
                {
                    OptionPane.MessageInformation("No hay articulos para eliminar.");
                }
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (!String.IsNullOrEmpty(this.txtNit.Text))
                {
                    if (this.Document.Items.Count > 0)
                    {
                        if (this.ValidateDEEdit())
                        {

                            if (Convert.ToInt32(this.cbMetodoPago.SelectedValue).Equals(1))  /// metodo pago contado
                            {
                                if (this.Document.ValideBaseTaxRetentions(this.CodeReteIVA))
                                {
                                    error.SetError(this.txtNit, null);
                                    this.SaveDocument();
                                    this.txtProductCode.Focus();
                                    /*
                                    this.Document.NitCliente = this.txtNit.Text;
                                    this.Document.Tipo = this.cbTypeDocument.SelectedValue.ToString();
                                    this.Document.TipoFactura = this.cbTypeInvoic.SelectedValue.ToString();
                                    this.Document.TipoOperacion = this.cbTypeOp.SelectedValue.ToString();
                                    this.Document.Total = this.TotalInvoice.Total; // this.Document.Items.Sum(s => s.Total);
                                    this.Document.Fecha = DateTime.Now;
                                    //this.Document.IdResolucion = 1;
                                    this.Document.MetodoPago = Convert.ToInt32(this.cbMetodoPago.SelectedValue);
                                    this.Document.MedioPago = this.cbMedioPago.SelectedValue.ToString();
                                    this.Document.FechaLimite = this.Document.FechaPago = this.dtFechaLimite.Value;

                                    this.repositoryModel.EditElectronicDocument(this.Document);
                                    */

                                    OptionPane.MessageInformation("El documento se guardó con exito.");
                                }
                                else
                                {
                                    OptionPane.MessageWarning("Verifique los registros de retenciones. \nLas bases no coinciden.");
                                }
                            }
                            else
                            {
                                if (UseDate.FechaSinHora(this.dtFechaLimite.Value) > UseDate.FechaSinHora(DateTime.Now))
                                {
                                    this.SaveDocument();
                                    this.txtProductCode.Focus();
                                    OptionPane.MessageInformation("El documento se guardó con exito.");
                                }
                                else
                                {
                                    OptionPane.MessageWarning("La fecha de pago debe ser superior a la fecha de hoy..");
                                }
                            }

                        }
                    }
                    else
                    {
                        OptionPane.MessageInformation("Debe cargar al menos un producto.");
                    }
                }
                else
                {
                    error.SetError(this.txtNit, "Debe cargar un cliente.");
                }
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
        }

        private void SaveDocument()
        {
            this.Document.NitCliente = this.txtNit.Text;
            this.Document.Tipo = this.cbTypeDocument.SelectedValue.ToString();
            this.Document.TipoFactura = this.cbTypeInvoic.SelectedValue.ToString();
            this.Document.TipoOperacion = this.cbTypeOp.SelectedValue.ToString();
            this.Document.Total = this.TotalInvoice.Total; // this.Document.Items.Sum(s => s.Total);
            this.Document.Neto = this.TotalInvoice.Neto;
            
            //this.Document.Fecha = DateTime.Now;
            //this.Document.IdResolucion = 1;
            this.Document.MetodoPago = Convert.ToInt32(this.cbMetodoPago.SelectedValue);
            this.Document.MedioPago = this.cbMedioPago.SelectedValue.ToString();
            this.Document.FechaLimite = this.Document.FechaPago = this.dtFechaLimite.Value;

            this.repositoryModel.EditElectronicDocument(this.Document);
        }

        private void btnSaveNew_Click(object sender, EventArgs e)
        {
            this.btnSave_Click(this.btnSave, new EventArgs());
            if (!String.IsNullOrEmpty(this.txtNit.Text))
            {
                if (this.Document.Items.Count > 0)
                {
                    this.btnNew_Click(this.btnNew, new EventArgs());
                }
                else
                {
                    OptionPane.MessageInformation("Debe cargar al menos un producto.");
                }
            }
            else
            {
                error.SetError(this.txtNit, "Debe cargar un cliente.");
            }
            //this.btnNew_Click(this.btnNew, new EventArgs());
        }


        void CompletaEventos_Completo(CompletaArgumentosDeEvento args)
        {
            try
            {
                var obj = (ObjectAbstract)args.MiObjeto;
                if (obj.Id.Equals(this.TransferValueQuantity))
                {
                    foreach (Item item in this.Document.Items.Where(i => i.ID.Equals
                        (Convert.ToInt32(this.dgvItems.CurrentRow.Cells["Id"].Value))))
                    {
                        item.Quantity = Convert.ToDouble(obj.Objeto.ToString().Replace('.', ','));
                        item.SubTotal = item.UnitPrice * item.Quantity;
                        item.Neto = Math.Round((Convert.ToDouble(item.UnitPrice) * (1 + (item.IVA / 100))), 2)
                        + item.IC;
                        item.Total = Math.Round(item.Neto * item.Quantity, 2);

                        UpdateQuantityOrPrice(item);
                    }
                    
                    LoadGridView();
                    
                    /*
                    int id = Convert.ToInt32(this.dgvItems.CurrentRow.Cells["Id"].Value);
                    Item item = this.Document.Items.Where(i => i.ID.Equals(id)).First();
                    item.Quantity = Convert.ToDouble(obj.Objeto);
                    //item.Quantity = Convert.ToDouble(this.txtCantidad.Text);
                    item.SubTotal = item.UnitPrice * item.Quantity;

                    item.Neto = Math.Round((Convert.ToDouble(item.UnitPrice) * (1 + (item.IVA / 100))), 2)
                        + item.IC;
                    item.Total = Math.Round(item.Neto * item.Quantity, 2);
                    //this.Document.Items.up
                    */
                }
                if (obj.Id.Equals(this.TransferValuePrice))
                {
                    foreach (Item item in this.Document.Items.Where(i => i.ID.Equals
                        (Convert.ToInt32(this.dgvItems.CurrentRow.Cells["Id"].Value))))
                    {
                        item.Neto = Convert.ToDouble(obj.Objeto.ToString().Replace('.', ','));
                        item.UnitPrice = item.Neto - item.IC;
                        item.UnitPrice = Math.Round(item.UnitPrice / (1 + (item.IVA / 100)), 2);

                        item.SubTotal = item.UnitPrice * item.Quantity;
                        item.Neto = Math.Round((Convert.ToDouble(item.UnitPrice) * (1 + (item.IVA / 100))), 2)
                        + item.IC;
                        item.Total = Math.Round(item.Neto * item.Quantity, 2);
                        //item.Total = Math.Round(item.Neto * item.Quantity, 2);

                        UpdateQuantityOrPrice(item);
                    }
                    
                    LoadGridView();
                    
                }
            }
            catch { }
        }

        private void UpdateQuantityOrPrice(Item item)
        {
            try
            {
                this.repositoryModel.UpdateQuantityOrPrice(item);
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
        }

        private List<IdentifyTax> TaxRetencion()
        {
            var taxes = new List<IdentifyTax>();
            foreach (var tax in this.repositoryData.IdentifyTaxes().Where(t => t.IsTax))
            {
                taxes.Add(new IdentifyTax
                {
                    Code = tax.Code,
                    Name = tax.Name,
                    Descripcion = tax.Code + " " + tax.Name 
                });
            }
            return taxes;
        }


        /// <summary>
        /// Return true if is number.
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        private bool CodigoOrString(string code)
        {
            var num = true;
            try
            {
                Convert.ToInt64(code);
            }
            catch (FormatException)
            {
                num = false;
            }
            catch (OverflowException)
            {
                num = true;
            }
            return num;

        }

        private bool ValidateDouble(string val)
        {
            var pass = false;
            try
            {
                Convert.ToDouble(val);
                pass = true;
            }
            catch (FormatException)
            {
                pass = false;
            }
            try
            {
                Convert.ToInt32(Convert.ToDouble(val));
                pass = true;
            }
            catch (OverflowException)
            {
                pass = false;
            }
            catch (FormatException)
            {
                pass = false;
            }
            return pass;
        }

        private void cbRetencion_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                if (this.cbRetencion.SelectedValue.ToString().Equals(this.CodeReteICA))
                {
                    this.cbTarifas.Visible = false;
                    this.txtTarifa.Visible = true;
                }
                else
                {
                    this.cbTarifas.Visible = true;
                    this.txtTarifa.Visible = false;

                    this.cbTarifas.DataSource = this.repositoryData.TarifasTax(
                        this.cbRetencion.SelectedValue.ToString());
                }
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
        }

        private void btnAddTaxRete_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.dgvItems.RowCount > 0)
                {
                    // validaciones

                    if (this.Document.Retentions.Where(r => r.ID.Equals(this.cbRetencion.SelectedValue.ToString())).Count().Equals(0))
                    {
                        if (this.cbRetencion.SelectedValue.ToString().Equals(this.CodeReteICA))
                        {
                            if (!String.IsNullOrEmpty(this.txtTarifa.Text))
                            {
                                error.SetError(this.txtTarifa, null);
                                if (ValidateDouble(this.txtTarifa.Text))
                                {
                                    error.SetError(this.txtTarifa, null);
                                    AddTaxRetention();
                                }
                                else
                                {
                                    error.SetError(this.txtTarifa, "El valor de la tarifa es invalido.");
                                }
                            }
                            else
                            {
                                error.SetError(this.txtTarifa, "La tarifa no debe ser vacio.");
                            }
                        }
                        else
                        {
                            AddTaxRetention();
                        }
                    }
                    else
                    {
                        OptionPane.MessageInformation("El codigo de retencion ya esta cargado");
                    }
                }
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
        }

        private void AddTaxRetention()
        {
            Tax tax = new Tax();

            //tax = (Tax)this.cbRetencion.SelectedItem;

            tax.IDItem = this.Document.ID;
            tax.State = true;
            tax.ID = this.cbRetencion.SelectedValue.ToString();
            tax.Description = ((IdentifyTax)this.cbRetencion.SelectedItem).Descripcion;
            if (tax.ID.Equals(this.CodeReteICA))
            {
                tax.Tarifa = Convert.ToDouble(this.txtTarifa.Text.Replace('.', ','));
            }
            else
            {
                tax.Tarifa = Convert.ToDouble(this.cbTarifas.SelectedValue);
            }
            if (tax.ID.Equals(this.CodeReteIVA))
            {
                tax.Base = Math.Round(this.Document.Items.Sum(s => ((s.UnitPrice * s.Quantity) * s.IVA / 100)), 2);
            }
            else
            {
                tax.Base = this.Document.Items.Sum(s => s.SubTotal);
            }
            tax.Value = Math.Round(tax.Base * tax.Tarifa / 100, 2);

            this.Document.Retentions.Add(this.repositoryModel.AddTaxElectronicInvoice(tax));

            this.dgvTaxRetenciones.DataSource = null;
            this.dgvTaxRetenciones.DataSource = this.Document.Retentions;

            LoadRetention();

            this.txtTarifa.Text = "";
        }

        /*
        private void cbTarifas_KeyPress(object sender, KeyPressEventArgs e)
        {
            //this.cbTarifas.Size = new Size(427, 196);
        }

        private void cbTarifas_SelectionChangeCommitted(object sender, EventArgs e)
        {
            //this.cbTarifas.Location = new Point(230, 18);
            //this.cbTarifas.Size = new Size(196, 24);
        }

        private void cbTarifas_MouseClick(object sender, MouseEventArgs e)
        {
            //this.cbTarifas.Location = new Point(8, 18);
            //this.cbTarifas.Size = new Size(418, 24);
        }
        */

        private void btnDeleteRetention_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.dgvTaxRetenciones.RowCount > 0)
                {
                    /*DialogResult rta = MessageBox.Show("¿Está seguro(a) de eliminar la retención?", "Documento Electronico",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (rta.Equals(DialogResult.Yes))
                    {*/
                        this.repositoryModel.DeleteTaxElectronicDocument(Convert.ToInt32(this.dgvTaxRetenciones.CurrentRow.Cells["IDI"].Value));
                        this.Document.Retentions.Remove(this.Document.Retentions.
                            Where(r => r.IDI.Equals(Convert.ToInt32(this.dgvTaxRetenciones.CurrentRow.Cells["IDI"].Value))).First());

                        this.dgvTaxRetenciones.DataSource = null;
                        this.dgvTaxRetenciones.DataSource = this.Document.Retentions;
                        LoadRetention();

                    //}
                }
                else
                {
                    OptionPane.MessageInformation("No hay retenciones para eliminar.");
                }
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
        }

        public void LoadRetention()
        {
            this.TotalInvoice.Retention = Math.Round(this.Document.Retentions.Sum(s => s.Value), 2);
            this.TotalInvoice.Neto = this.TotalInvoice.Total - this.TotalInvoice.Retention;

            this.txtRetencion.Text = UseObject.InsertSeparatorMil(this.TotalInvoice.Retention.ToString());
            this.txtNeto.Text = UseObject.InsertSeparatorMil(this.TotalInvoice.Neto.ToString());
        }

        private void dgvListItems_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            /*if (this.dgvListItems.RowCount > 0)
            {
                this.txtProductCode.Text = this.dgvListItems.CurrentRow.Cells["ItemCodigo"].Value.ToString();
                this.txtProductCode_KeyPress(this.txtProductCode, new KeyPressEventArgs((char)Keys.Enter));
                this.dgvListItems.Hide();
            }*/
        }

        private void dgvListItems_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (this.dgvListItems.RowCount > 0)
            {
                switch (e.KeyChar)
                {
                    case (char)Keys.D1:
                        {
                            this.LoadItem(this.dgvListItems.CurrentRow.Cells["ItemCodigo"].Value.ToString(),
                                Convert.ToDouble(this.dgvListItems.CurrentRow.Cells["Precio"].Value));
                            //this.dgvListItems.Hide();
                            this.dgvListItems.Visible = false;
                            break;
                        }
                    case (char)Keys.D2:
                        {
                            this.LoadItem(this.dgvListItems.CurrentRow.Cells["ItemCodigo"].Value.ToString(),
                                Convert.ToDouble(this.dgvListItems.CurrentRow.Cells["Precio2"].Value));
                            //this.dgvListItems.Hide();
                            this.dgvListItems.Visible = false;
                            break;
                        }
                    case (char)Keys.D3:
                        {
                            this.LoadItem(this.dgvListItems.CurrentRow.Cells["ItemCodigo"].Value.ToString(),
                                Convert.ToDouble(this.dgvListItems.CurrentRow.Cells["Precio3"].Value));
                            //this.dgvListItems.Hide();
                            this.dgvListItems.Visible = false;
                            break;
                        }
                    case (char)Keys.D4:
                        {
                            this.LoadItem(this.dgvListItems.CurrentRow.Cells["ItemCodigo"].Value.ToString(),
                                Convert.ToDouble(this.dgvListItems.CurrentRow.Cells["Precio4"].Value));
                            //this.dgvListItems.Hide();
                            this.dgvListItems.Visible = false;
                            break;
                        }
                }
            }
        }



        private bool ValidateDEEdit()
        {
            bool valide = true;
            try
            {
                if (this.Document != null)
                {
                    if (this.Document.ID > 0)
                    {
                        var DE = this.repositoryModel.GetDocument(this.Document.ID);
                        if (!String.IsNullOrEmpty(DE.TransaccionID))
                        {
                            OptionPane.MessageWarning("Se encontro un registro temporal, se limpara el formulario");
                            this.btnNew_Click(this.btnNew, new EventArgs());
                            valide = false;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                valide = false;
                OptionPane.MessageError(ex.Message);
            }
            return valide;
        }
    }
}