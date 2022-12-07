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
        private string DefaultValuePayment = "10";  /// 10 : Efectivo
                                                    /// 
        private string DefaultMoneda = "COP";

        private string DefaultCodeStandard = "999";

        private int TransferValueQuantity = 987654;

        private int TransferValuePrice = 654987;

        private ErrorProvider error;

        private RepositoryDataFiscal repositoryData;

        private RepositoryModel repositoryModel;


        private CustomerModel customerModel;

        ///private DocumentEModel DocumentModel;

        private ElectronicDocument Document;


        //private List<Item> items;

        public FrmElectronicDocument()
        {
            InitializeComponent();

            try
            {
                this.error = new ErrorProvider();
                this.repositoryData = new RepositoryDataFiscal();
                this.repositoryModel = new RepositoryModel();

                this.customerModel = new CustomerModel();
                //this.DocumentModel = new DocumentEModel();
                this.Document = new ElectronicDocument();

                this.dgvItems.AutoGenerateColumns = false;
                //items = new List<Item>();




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
                        this.btnNew_Click(this.btnNew, new EventArgs());
                        break;
                    }
                case Keys.F3:
                    {
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
                    Item item = this.repositoryModel.GetItem(this.txtProductCode.Text);

                    if (!item.Code.Equals(""))
                    {
                        this.txtProduct.Text = item.Description;
                        this.txtPrice.Text = UseObject.InsertSeparatorMil(Convert.ToInt32(item.Neto).ToString());

                        //item.ID = this.Document.Items.Count + 1;
                        item.Quantity = Convert.ToDouble(this.txtCantidad.Text);
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
                        this.txtProductCode.Text = "";
                    }
                    else
                    {
                        OptionPane.MessageInformation("El código no existe.");
                    }
                    


                    //if(this.Document.Items.Count.Equals(0) &&  



                    /*
                    var item = this.repositoryModel.GetItem_(this.txtProductCode.Text);
                    item.id = this.DocumentModel.ItemDocument.Count + 1;
                    item.cantidad = Convert.ToDouble(this.txtCantidad.Text);
                    item.precio_unitario = item.neto - item.ic;
                    item.precio_unitario /= Math.Round(1 + (item.iva / 100), 2);
                    item.total = Math.Round(item.neto * item.cantidad, 2);
                    this.DocumentModel.ItemDocument.Rows.Add(item);
                    //this.DocumentModel.ItemDocument.Additem_documento_electronicoRow(item);
                    this.dgvItems.DataSource = null;
                    this.dgvItems.DataSource = this.DocumentModel.ItemDocument;
                    */

                    /*
                    Item item = this.repositoryModel.GetItem(this.txtProductCode.Text);
                    item.ID = this.items.Count + 1;
                    item.Quantity = Convert.ToDecimal(this.txtCantidad.Text);
                    item.SubTotal = item.UnitPrice * item.Quantity;

                    item.Neto = Math.Round((Convert.ToDouble(item.UnitPrice) * (1 + (item.IVA / 100))), 2)
                        + item.IC;
                    item.Total = item.Neto * Convert.ToDouble(item.Quantity);
                    items.Add(item);

                    this.dgvItems.DataSource = null;
                    this.dgvItems.DataSource = items;
                    */
                }
                catch (Exception ex)
                {
                    OptionPane.MessageError(ex.Message);
                }
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
            this.Document.TipoAmbiente = "2";
            this.Document.VUBL = "UBL 2.1";
            this.Document.VDIAN = "DIAN 2.1";
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
                            this.txtNoDE.Text = this.Document.Numero;

                            this.txtCliente.Text = this.Document.NitCliente;
                            this.txtCliente_KeyPress(this.txtCliente, new KeyPressEventArgs((char)Keys.Enter));
                            LoadGridView();
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
            this.txtTotal.Text = UseObject.InsertSeparatorMil(
                Math.Round(this.Document.Items.Sum(s => s.Total), 0).ToString());

            this.dgvItems.DataSource = null;
            this.dgvItems.DataSource = this.Document.Items;
            this.dgvItems.FirstDisplayedCell =
                this.dgvItems.Rows[this.dgvItems.Rows.Count - 1].Cells[1];
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            LoadDatos();
            this.dtFechaLimite.Value = DateTime.Now;
            this.txtNit.Text = "";
            this.txtNameCliente.Text = "";
            this.txtEmail.Text = "";
            this.txtNota.Text = "";
            this.txtProduct.Text = "";
            this.txtCantidad.Text = "1";
            this.dgvItems.DataSource = null;
            this.txtTotal.Text = "0";
            this.txtNoDocument.Text = "";
            this.txtNoDE.Text = "";

            this.txtProductCode.Focus();

            this.customerModel = new CustomerModel();
            this.Document = new ElectronicDocument();

        }

        private void btnQuantity_Click(object sender, EventArgs e)
        {
            
            var frmDEOption = new FrmDEOption();
            frmDEOption.Extend = true;
            frmDEOption.TransferValue = this.TransferValueQuantity;
            frmDEOption.txtValue.Text = this.Document.Items.Where(i => i.ID.Equals
                        (Convert.ToInt32(this.dgvItems.CurrentRow.Cells["Id"].Value))).First().Quantity.ToString();
            frmDEOption.ShowDialog();
        }

        private void btnPrice_Click(object sender, EventArgs e)
        {
            var frmDEOption = new FrmDEOption();
            frmDEOption.Extend = true;
            frmDEOption.TransferValue = this.TransferValuePrice;
            frmDEOption.txtValue.Text = Convert.ToInt32(this.Document.Items.Where(i => i.ID.Equals
                        (Convert.ToInt32(this.dgvItems.CurrentRow.Cells["Id"].Value))).First().Neto).ToString();
            frmDEOption.ShowDialog();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (!String.IsNullOrEmpty(this.txtNit.Text))
                {
                    if (this.Document.Items.Count > 0)
                    {
                        error.SetError(this.txtNit, null);

                        this.Document.NitCliente = this.txtNit.Text;
                        this.Document.Tipo = this.cbTypeDocument.SelectedValue.ToString();
                        this.Document.TipoFactura = this.cbTypeInvoic.SelectedValue.ToString();
                        this.Document.TipoOperacion = this.cbTypeOp.SelectedValue.ToString();
                        this.Document.Total = this.Document.Items.Sum(s => s.Total);
                        //this.Document.IdResolucion = 1;
                        this.Document.MetodoPago = Convert.ToInt32(this.cbMetodoPago.SelectedValue);
                        this.Document.MedioPago = this.cbMedioPago.SelectedValue.ToString();

                        this.repositoryModel.EditElectronicDocument(this.Document);
                        OptionPane.MessageInformation("El documento se guardó con exito.");
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
                        item.Quantity = Convert.ToDouble(obj.Objeto);
                        item.SubTotal = item.UnitPrice * item.Quantity;
                        item.Neto = Math.Round((Convert.ToDouble(item.UnitPrice) * (1 + (item.IVA / 100))), 2)
                        + item.IC;
                        item.Total = Math.Round(item.Neto * item.Quantity, 2);
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
                        item.Neto = Convert.ToDouble(obj.Objeto);
                        item.UnitPrice = item.Neto - item.IC;
                        item.UnitPrice = Math.Round(item.UnitPrice / (1 + (item.IVA / 100)), 2);

                        item.SubTotal = item.UnitPrice * item.Quantity;
                        item.Neto = Math.Round((Convert.ToDouble(item.UnitPrice) * (1 + (item.IVA / 100))), 2)
                        + item.IC;
                        item.Total = Math.Round(item.Neto * item.Quantity, 2);
                        //item.Total = Math.Round(item.Neto * item.Quantity, 2);
                    }
                    LoadGridView();
                }
                /*
                item.Neto = item.UnitPrice;
                item.UnitPrice -= item.IC;
                item.UnitPrice = Math.Round(item.UnitPrice / (1 + (item.IVA / 100)), 2);
                */
            }
            catch { }
        }
    }
}