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
using DataAccessLayer.Generator;
using CustomControl;
using DTO;
using Utilities;
using WSFTechSoapDemo;
using WSFTechSoapPro;
using System.Threading;


namespace FormulariosSistema
{
    public partial class FrmListDE : Form
    {
        /// <summary>
        /// Enviroment productive = true; demo = false.
        /// </summary>
        private bool Productive { set; get; }

        private int IDIndex { set; get; }

        private int IdUser { set; get; }

        private int IdCaja { set; get; }

        private string DefaultValuePayment = "10";  /// 10 : Efectivo
                                                    /// 
        private string DefaultMoneda = "COP";

        private string CodeReteIVA = "05";

        private string TypeInvoice = "INVOIC";

        private int MetPayCredito = 2;

        private int CodeTransferEventPayment = 65412597;

        private string MsnValidate = "";

        private ErrorProvider error;

        private RepositoryDataFiscal repositoryData;

        private RepositoryModel repositoryModel;


        private CustomerModel customerModel;

        ///private DocumentEModel DocumentModel;

        private ElectronicDocument Document;

        private List<ElectronicDocument> Documents;


        private Item TotalInvoice;


        private string XmlBase64;

        private DocumentElectronicLoad DELoad;

        private WSFTechSoap WSFTechSoapDemo;

        private WSFTechSoapDemo.Response.UploadFileResponse Response;

        private WSFTechSoapDemo.Response.DocumentStatusFileResponse ResponseDoc;




        private WSFTechSPro WSFTechSProductive;

        private WSFTechSoapPro.UploadFileResponse ResponsePro;

        private WSFTechSoapPro.DocumentStatusFileResponse ResponseDocPro;


        private Thread NewThread;

        //private List<Item> items;

        private PrintInvoice PrintInvoice;

        private ToolTip toolTip;

        public FrmListDE()
        {
            InitializeComponent();

            try
            {
                this.IDIndex = 0;
                this.Productive = Convert.ToBoolean(AppConfiguracion.ValorSeccion("ws_productive"));
                this.IdCaja = Convert.ToInt32(AppConfiguracion.ValorSeccion("id_caja"));
                this.IdUser = Convert.ToInt32(AppConfiguracion.ValorSeccion("id_user"));

                this.error = new ErrorProvider();
                this.repositoryData = new RepositoryDataFiscal();
                this.repositoryModel = new RepositoryModel();

                this.customerModel = new CustomerModel();
                //this.DocumentModel = new DocumentEModel();
                //this.Document = new ElectronicDocument();
                this.Documents = new List<ElectronicDocument>();

                this.TotalInvoice = new Item();

                this.DELoad = new DocumentElectronicLoad();
                //this.WSFTechSoapDemo = new WSFTechSoap();
                //this.WSFTechSProductive = new WSFTechSPro();

                this.dgvDocuments.AutoGenerateColumns = false;
                this.dgvItems.AutoGenerateColumns = false;
                this.dgvTaxRetenciones.AutoGenerateColumns = false;
                //items = new List<Item>();


                //this.PrintInvoice = new PrintInvoice();

                LoadDatos();

                this.toolTip = new ToolTip();
                this.toolTip.SetToolTip(this.btnGENXML_v1, "Generar xml");
                this.toolTip.SetToolTip(this.btnPayment_v1, "Pagar factura");
                this.toolTip.SetToolTip(this.btnCopy_v1, "Copia de factura");
                this.toolTip.SetToolTip(this.btnDelete_v1, "Eliminar registro");
                this.toolTip.SetToolTip(this.btnFiscal, "Generar Informe Fiscal");
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
        }

        private void FrmListDE_Load(object sender, EventArgs e)
        {
            try
            {
                //this.btnDelete.Visible = true;


                CompletaEventos.Completa += new CompletaEventos.CompletaAccion(CompletaEventos_Completo);

                //this.btnBuscarDocument_Click(this.btnBuscarDocument, new EventArgs());
                this.Documents = this.repositoryModel.Documents();
                if (this.Documents.Count > 0)
                {
                    //this.dgvDocuments.DataSource = null;
                    this.dgvDocuments.DataSource = this.Documents;
                    this.dgvDocuments_CellClick(this.dgvDocuments, null);
                    LoadColorGrid();
                }
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
                
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
        }

        public void LoadColorGrid()
        {
            try
            {
                foreach (DataGridViewRow row in this.dgvDocuments.Rows)
                {
                    if (Convert.ToBoolean(row.Cells["EstadoBool"].Value))
                    {
                        row.DefaultCellStyle.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
                    }
                }
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
        }



        private void txtDocument_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                this.Documents = this.repositoryModel.Documents(this.txtDocument.Text);
                this.dgvDocuments.DataSource = null;
                this.dgvDocuments.DataSource = this.Documents;
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
        }

        private void txtDocument_KeyPress(object sender, KeyPressEventArgs e)
        {
            /*try
            {
                this.Documents = this.repositoryModel.Documents(this.txtDocument.Text);
                this.dgvDocuments.DataSource = null;
                this.dgvDocuments.DataSource = this.Documents;
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }*/
        }

        private void btnBuscarDocument_Click(object sender, EventArgs e)
        {
            try
            {
                if (String.IsNullOrEmpty(this.txtDocument.Text))
                {
                    this.Documents = this.repositoryModel.Documents();
                    //this.dgvDocuments.DataSource = null;
                    //this.dgvDocuments.DataSource = this.Documents;
                }
                else
                {
                    this.Documents = this.repositoryModel.Documents(this.txtDocument.Text);
                    
                }
                //this.btnGENXML.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;

                if (this.Documents.Count > 0)
                {
                    this.dgvDocuments.DataSource = null;
                    this.dgvDocuments.DataSource = this.Documents;
                    //this.dgvDocuments_CellClick(this.dgvDocuments, null);
                    LoadColorGrid();
                    if (this.IDIndex > 0)
                    {
                        /**
                        this.dgvDocuments.Rows[0].Cells["Numero"].Selected = false;
                        this.dgvDocuments.Rows[this.IDIndex].Cells["Numero"].Selected = true;//Numero
                        this.dgvDocuments.CurrentCell = this.dgvDocuments.Rows[this.IDIndex].Cells["Numero"];
                        */
                       // this.dgvDocuments.Refresh();

                       // var dcr = this.dgvDocuments.CurrentRow.Cells["Id"].Value;
                    }
                    this.dgvDocuments_CellClick(this.dgvDocuments, null);
                }
                else
                {
                    OptionPane.MessageInformation("No se encontró registros de la consulta.");
                }
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
        }


        private void btnGENXML_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.dgvDocuments.RowCount > 0)
                {
                    this.IDIndex = this.dgvDocuments.CurrentRow.Index;
                    this.Document = this.Documents.Find(d => d.ID.Equals(Convert.ToInt32(this.dgvDocuments.CurrentRow.Cells["Id"].Value)));

                    if (!String.IsNullOrEmpty(this.Document.NitCliente))
                    {
                        this.Document = this.repositoryModel.GetDocumentData(this.Document, this.Productive);
                        if (this.Document.IdResolucion == 0)
                        {
                            this.Document.Fecha = DateTime.Now;
                            if (!this.Document.MetodoPago.Equals(this.MetPayCredito))  // si es de contado.
                            {
                                this.Document.FechaLimite = this.Document.FechaPago = this.Document.Fecha;
                            }
                            this.Document.Estado = true;
                            this.Document.Numero = this.Document.Resolution.prefijo + this.Document.Resolution.consecutive;
                            //this.Document.IdResolucion = this.Document.Resolution.id;
                            this.Document.NoItems = this.Document.Items.Count;
                            this.Document.Total = this.Document.Items.Sum(s => s.Total);
                            this.Document.Neto = this.Document.Total - Math.Round(this.Document.Retentions.Sum(s => s.Value), 2);
                            //this.TotalInvoice.Retention = Math.Round(this.Document.Retentions.Sum(s => s.Value), 2);


                            //this.repositoryModel.UpdateConsecutiveResolution();
                            //this.repositoryModel.EditElectronicDocumentAll(Document);
                        }
                        if (ValidateElectronicDocument(this.Document))
                        {
                            DialogResult rta = MessageBox.Show("¿Desea generar el documento electrónico?", "Factura electrónica",
                                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                            if (rta.Equals(DialogResult.Yes))
                            {
                                if (this.Document.IdResolucion == 0)
                                {
                                    this.Document.IdResolucion = this.Document.Resolution.id;
                                    this.repositoryModel.UpdateNumberConsecutiveED(this.Document);

                                    /// update stock 
                                    //this.repositoryModel.UpdateStock(this.document.Items);
                                }
                                /*if (!this.Document.Estado)
                                {
                                    this.repositoryModel.UpdateConsecutiveResolution();
                                    this.repositoryModel.EditElectronicDocumentAll(Document);
                                }*/

                                this.cpElements.Enabled = false;
                                this.lblMsnStandBy.Visible = true;

                                // generar XML
                                DELoad.Document = Document;
                                //string xmlBase64 = DELoad.CreateXML();
                                this.XmlBase64 = DELoad.CreateXML(this.Document.Numero);
                                try
                                {
                                    if (this.Productive)
                                    {
                                        this.WSFTechSProductive = new WSFTechSPro();
                                    }
                                    else
                                    {
                                        this.WSFTechSoapDemo = new WSFTechSoap();
                                    }
                                    NewThread = new Thread(UploadIvoice);
                                    NewThread.Start();
                                    NewThread.Join();

                                    if (this.Response != null)
                                    {
                                        if (!String.IsNullOrEmpty(this.Response.TransaccionID)) // se obtubo transanccionID del WS.
                                        {
                                            /// if (this.ValidateTrazability(this.Response.MsgError)) 

                                            this.Document.TransaccionID = this.Response.TransaccionID;
                                            this.repositoryModel.UpdateTransaccionIDDE(this.Document);

                                            NewThread = new Thread(DocumentStatus);
                                            NewThread.Start();
                                            NewThread.Join();

                                            if (this.ResponseDoc != null && this.ResponseDoc.Code.Equals("201"))
                                            {
                                                this.repositoryModel.UpdateStatusSigned(this.Document.ID);

                                                OptionPane.MessageSuccess("El documento electrónico se registró con éxito.\n" +
                                                    this.Response.Success + "\n" +
                                                    this.ResponseDoc.Success);

                                                this.btnBuscarDocument_Click(this.btnBuscarDocument, new EventArgs());
                                                this.IDIndex = 0;
                                            }
                                            else
                                            {
                                                if (this.ResponseDoc != null)
                                                {
                                                    OptionPane.MessageError("Ocurrio un error al firmar la factura electronica.\nCode " +
                                                        this.ResponseDoc.Code + "\nError " + this.ResponseDoc.MsgError);
                                                }
                                                else
                                                {
                                                    OptionPane.MessageError("Ocurrio un error al firmar la factura electronica.\nResponeDOC = null.");
                                                }
                                            }
                                        }
                                        else
                                        {
                                            OptionPane.MessageError("Ocurrio un error al cargar la factura electronica.\nCode " +
                                                this.Response.Code + "\nError " + this.Response.MsgError);
                                            //this.btnBuscarDocument_Click(this.btnBuscarDocument, new EventArgs());
                                            //this.IDIndex = 0;
                                        }

                                    }
                                }
                                catch (System.ServiceModel.EndpointNotFoundException)
                                {
                                    OptionPane.MessageError("No se conectó al servicio web de factura electrónica.");
                                }
                                finally 
                                { 
                                    this.cpElements.Enabled = true; 
                                    this.lblMsnStandBy.Visible = false;

                                    DialogResult r = DialogResult.Yes;
                                    if (Convert.ToBoolean(AppConfiguracion.ValorSeccion("preguntaPrintVenta")))
                                    {
                                        r = MessageBox.Show("¿Desea imprimir la factura?", "Factura electronica",
                                            MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                                    }
                                    if (r.Equals(DialogResult.Yes))
                                    {
                                        PrintInvoice = new PrintInvoice();
                                        try
                                        {
                                            PrintInvoice.Print(this.Document, !String.IsNullOrEmpty(this.Document.TransaccionID));
                                        }
                                        catch (Exception ex) { OptionPane.MessageError(ex.Message); }
                                    }

                                    if (this.Document.Estado &&                                 // Document electronico
                                        this.Document.Tipo.Equals(this.TypeInvoice) &&          // tipo factura electronica
                                        //!this.Document.MetodoPago.Equals(this.MetPayCredito) &&  // metodo de pago contado
                                        !this.Document.Cancelled)                                // no esta cancelada
                                        {
                                            var frmPayment = new FrmPayment();
                                            frmPayment.Document = this.Document;

                                            frmPayment.IdCaja = this.IdCaja;
                                            frmPayment.IdUser = this.IdUser;
                                            frmPayment.IDDE = this.Document.ID;
                                            frmPayment.Total = Math.Round(this.Document.Neto - this.Document.Payment, 2);
                                            frmPayment.ShowDialog();
                                        }
                                }
                            }
                        }
                        else
                        {
                            OptionPane.MessageError(this.MsnValidate);
                        }
                    }
                    else
                    {
                        OptionPane.MessageError("El registro no tiene cliente asociado.");
                    }
                }
                else
                {
                    OptionPane.MessageInformation("No hay registros para generar.");
                }
            }
            catch (Exception ex)
            {
                this.cpElements.Enabled = true;
                this.lblMsnStandBy.Visible = false;
                OptionPane.MessageError(ex.Message);
            }
            finally 
            { 
                this.cpElements.Enabled = true; this.lblMsnStandBy.Visible = false;
                this.btnBuscarDocument_Click(this.btnBuscarDocument, new EventArgs());
                this.IDIndex = 0;
            }
        }

        private void btnGENXML_Click__(object sender, EventArgs e)
        {
            try
            {
                if (this.dgvDocuments.RowCount > 0)
                {
                    this.Document = this.Documents.Find(d => d.ID.Equals(Convert.ToInt32(this.dgvDocuments.CurrentRow.Cells["Id"].Value)));

                    if (!String.IsNullOrEmpty(this.Document.NitCliente))
                    {
                        ///if (String.IsNullOrEmpty(this.Document.TransaccionID))  /// codificar la segunda opcion
                        ///{
                        this.Document = this.repositoryModel.GetDocumentData(this.Document, this.Productive);
                        if (this.Document.IdResolucion == 0)
                        {
                            this.Document.Fecha = DateTime.Now;
                            if (!this.Document.MetodoPago.Equals(this.MetPayCredito))  // si es de contado.
                            {
                                this.Document.FechaLimite = this.Document.FechaPago = this.Document.Fecha;
                            }
                            this.Document.Estado = true;
                            this.Document.Numero = this.Document.Resolution.prefijo + this.Document.Resolution.consecutive;
                            this.Document.IdResolucion = this.Document.Resolution.id;
                            this.Document.NoItems = this.Document.Items.Count;
                            this.Document.Total = this.Document.Items.Sum(s => s.Total);
                        }
                        else
                        {
                            this.Document.Estado = true;
                        }

                        if (ValidateElectronicDocument(this.Document))
                        {
                            DialogResult rta = MessageBox.Show("¿Desea generar el documento electrónico?", "Factura electrónica",
                                            MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                            if (rta.Equals(DialogResult.Yes))
                            {
                                this.cpElements.Enabled = false;
                                this.lblMsnStandBy.Visible = true;

                                // generar XML
                                DELoad.Document = Document;
                                //string xmlBase64 = DELoad.CreateXML();
                                this.XmlBase64 = DELoad.CreateXML(this.Document.Numero);

                                try
                                {
                                    if (!this.Productive)
                                    {
                                        this.WSFTechSoapDemo = new WSFTechSoap();
                                        /// -----------------------------------------------------------------------------------------------------------------
                                        /// ------------------------------------------   Connection to WS demo ----------------------------------------------

                                        /// -----------------------------------------------------------------------------------------------------------------
                                        /// ------------------------------------------ END Connection to WS demo --------------------------------------------

                                    }
                                    else
                                    {
                                        this.WSFTechSProductive = new WSFTechSPro();
                                        /// -----------------------------------------------------------------------------------------------------------------
                                        /// ------------------------------------------   Connection to WS Productive ----------------------------------------


                                        /// -----------------------------------------------------------------------------------------------------------------
                                        /// ------------------------------------------ END Connection to WS Productive --------------------------------------

                                    }
                                    NewThread = new Thread(UploadIvoice);
                                    NewThread.Start();
                                    NewThread.Join();

                                    if (this.Response != null)
                                    {
                                        if (String.IsNullOrEmpty(this.Response.TransaccionID)) // no se obtubo transanccionID del WS.
                                        {
                                            if (this.ValidateTrazability(this.Response.MsgError)) // indica que existe un valor en id_ws_trazabilidad
                                            {
                                                this.repositoryModel.UpdateConsecutiveResolution();
                                                this.repositoryModel.UpdateNumberDocument(this.Document);
                                                this.repositoryModel.UpdateEstadoTrueDocument(this.Document.ID);

                                                this.repositoryModel.EditElectronicDocumentAll(Document);
                                            }

                                            OptionPane.MessageError("Ocurrio un error al cargar la factura electronica.\nCode " +
                                                this.Response.Code + "\nError " + this.Response.MsgError);
                                            this.btnBuscarDocument_Click(this.btnBuscarDocument, new EventArgs());
                                        }
                                        else
                                        {
                                            this.Document.TransaccionID = this.Response.TransaccionID;
                                            //this.repositoryModel.UpdateConsecutiveResolution();
                                            //this.repositoryModel.UpdateNumberDocument(this.Document);
                                            this.repositoryModel.UpdateTransaccionIDDE(this.Document);
                                            this.repositoryModel.UpdateEstadoTrueDocument(this.Document.ID);

                                            NewThread = new Thread(DocumentStatus);
                                            NewThread.Start();
                                            NewThread.Join();

                                            if (this.ResponseDoc != null && this.ResponseDoc.Code.Equals("201"))
                                            {
                                                this.repositoryModel.UpdateStatusSigned(this.Document.ID);
                                                this.Document.IdStatus = 2;
                                                this.repositoryModel.EditElectronicDocumentAll(Document);

                                                OptionPane.MessageSuccess("El documento electrónico se registró con éxito.\n" +
                                                    this.Response.Success + "\n" +
                                                    this.ResponseDoc.Success);

                                                DialogResult r = DialogResult.Yes;
                                                if (Convert.ToBoolean(AppConfiguracion.ValorSeccion("preguntaPrintVenta")))
                                                {
                                                    r = MessageBox.Show("¿Desea imprimir la factura?", "Factura electronica",
                                                        MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                                                }
                                                if (r.Equals(DialogResult.Yes))
                                                {
                                                    PrintInvoice = new PrintInvoice();
                                                    try
                                                    {
                                                        PrintInvoice.Print(this.Document, !String.IsNullOrEmpty(this.Document.TransaccionID));
                                                    }
                                                    catch (Exception ex) { OptionPane.MessageError(ex.Message); }
                                                }

                                                if (this.Document.Estado &&                                 // Document electronico
                                                    this.Document.Tipo.Equals(this.TypeInvoice) &&          // tipo factura electronica
                                                    !this.Document.MetodoPago.Equals(this.MetPayCredito) &&  // metodo de pago contado
                                                    !this.Document.Cancelled)                                // no esta cancelada
                                                {
                                                    var frmPayment = new FrmPayment();
                                                    frmPayment.Document = this.Document;

                                                    frmPayment.IdCaja = this.IdCaja;
                                                    frmPayment.IdUser = this.IdUser;
                                                    frmPayment.IDDE = this.Document.ID;
                                                    frmPayment.Total = Math.Round(this.Document.Neto - this.Document.Payment, 2);
                                                    frmPayment.ShowDialog();
                                                }
                                            }
                                            else
                                            {
                                                if (this.ResponseDoc != null)
                                                {
                                                    OptionPane.MessageError("Ocurrio un error al firmar la factura electronica.\nCode " +
                                                        this.ResponseDoc.Code + "\nError " + this.ResponseDoc.MsgError);
                                                }
                                                else
                                                {
                                                    OptionPane.MessageError("Ocurrio un error al firmar la factura electronica");
                                                }
                                            }
                                        }

                                    }
                                    else
                                    {
                                        OptionPane.MessageError("Ocurrio un error al cargar la factura electronica.\nResponse = null.");
                                        /*if (this.Response != null)
                                        {
                                            OptionPane.MessageError("Ocurrio un error al cargar la factura electronica.\nCode " +
                                                this.Response.Code + "\nError " + this.Response.MsgError);
                                        }
                                        else
                                        {
                                            OptionPane.MessageError("Ocurrio un error al cargar la factura electronica");
                                        }*/
                                    }





                                    /// Add payment to electronic document.
                                    /**if (this.Document.Estado &&                                 // Document electronico
                                        this.Document.Tipo.Equals(this.TypeInvoice) &&          // tipo factura electronica
                                        !this.Document.MetodoPago.Equals(this.MetPayCredito) &&  // metodo de pago contado
                                        !this.Document.Cancelled)                                // no esta cancelada
                                    {
                                        this.repositoryModel.AddPayment(new ElectronicPayment
                                        {
                                            IdDE = this.Document.ID,
                                            IdUser = this.IdUser,
                                            IdCaja = this.IdCaja,
                                            Total = this.Document.Neto,
                                            Date = this.Document.Fecha,
                                            Payments = new List<Payment>
                                            {
                                                new Payment
                                                {
                                                    Code = this.Document.MedioPago,
                                                    Pago = this.Document.Neto,
                                                    Valor = this.Document.Neto
                                                }
                                            }
                                        });
                                        this.repositoryModel.UpdateCancelledDocument(this.Document.ID);
                                    }
                                    */
                                    //this.cpElements.Enabled = true;
                                    //this.lblMsnStandBy.Visible = false;
                                }
                                catch (System.ServiceModel.EndpointNotFoundException)
                                {
                                    OptionPane.MessageError("No se conectó al servicio web de factura electrónica.");
                                }
                                finally { this.cpElements.Enabled = true; this.lblMsnStandBy.Visible = false; }
                            }
                        }
                        else
                        {
                            OptionPane.MessageError(this.MsnValidate);
                        }
                        /*this.btnBuscarDocument_Click(this.btnBuscarDocument, new EventArgs());
                        if (this.Document.Estado &&                                 // Document electronico
                            this.Document.Tipo.Equals(this.TypeInvoice) &&          // tipo factura electronica
                            !this.Document.MetodoPago.Equals(this.MetPayCredito) &&  // metodo de pago contado
                            !this.Document.Cancelled)                                // no esta cancelada
                            {
                                var frmPayment = new FrmPayment();
                                frmPayment.Document = this.Document;

                                frmPayment.IdCaja = this.IdCaja;
                                frmPayment.IdUser = this.IdUser;
                                frmPayment.IDDE = this.Document.ID;
                                frmPayment.Total = Math.Round(this.Document.Neto - this.Document.Payment, 2);
                                frmPayment.ShowDialog();
                            }

                        DialogResult r = DialogResult.Yes;
                        if (Convert.ToBoolean(AppConfiguracion.ValorSeccion("preguntaPrintVenta")))
                        {
                            r = MessageBox.Show("¿Desea imprimir la factura?", "Factura electronica",
                                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        }
                        if (r.Equals(DialogResult.Yes))
                        {
                            PrintInvoice = new PrintInvoice();
                            PrintInvoice.Print(this.Document, !String.IsNullOrEmpty(this.Document.TransaccionID));
                        }*/
                        /**}
                        else
                        {
                            OptionPane.MessageInformation("El documento no se puede generar, verifique su estatus.");
                        }*/
                    }
                    else
                    {
                        OptionPane.MessageError("El registro no tiene cliente asociado.");
                    }
                }
                else
                {
                    OptionPane.MessageInformation("No hay registros para generar.");
                }

            }
            catch (Exception ex)
            {
                this.cpElements.Enabled = true;
                this.lblMsnStandBy.Visible = false;
                OptionPane.MessageError(ex.Message);
            }
            finally { this.cpElements.Enabled = true; this.lblMsnStandBy.Visible = false; }
        }
        
        private void btnGENXML_Click_(object sender, EventArgs e)
        {
            try
            {
                

                if (this.dgvDocuments.RowCount > 0)
                {
                    this.Document = this.Documents.Find(d => d.ID.Equals(Convert.ToInt32(this.dgvDocuments.CurrentRow.Cells["Id"].Value)));

                    if (!String.IsNullOrEmpty(this.Document.NitCliente))
                    {
                        //if (!this.Document.Estado && String.IsNullOrEmpty(this.Document.TransaccionID))
                        if (String.IsNullOrEmpty(this.Document.TransaccionID))  /// codificar la segunda opcion
                        {
                            this.Document = this.repositoryModel.GetDocumentData(this.Document, this.Productive);
                            this.Document.Fecha = DateTime.Now;
                            if (!this.Document.MetodoPago.Equals(this.MetPayCredito))  // si es de contado.
                            {
                                this.Document.FechaLimite = this.Document.FechaPago = this.Document.Fecha;
                            }

                            this.Document.Estado = true;
                            this.Document.Numero = this.Document.Resolution.prefijo + this.Document.Resolution.consecutive;
                            this.Document.IdResolucion = this.Document.Resolution.id;
                            this.Document.NoItems = this.Document.Items.Count;
                            this.Document.Total = this.Document.Items.Sum(s => s.Total);

                            if (ValidateElectronicDocument(this.Document))
                            {
                                DialogResult rta = MessageBox.Show("¿Desea generar el documento electrónico?", "Factura electrónica",
                                                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                                if (rta.Equals(DialogResult.Yes))
                                {
                                    this.cpElements.Enabled = false;

                                    // generar XML
                                    DELoad.Document = Document;
                                    string xmlBase64 = "";
                                    //string xmlBase64 = DELoad.CreateXML();

                                    //this.repositoryModel.UpdateEstadoTrueDocument(this.Document.ID);
                                    //this.repositoryModel.UpdateConsecutiveResolution();

                                    try
                                    {

                                        /// -----------------------------------------------------------------------------------------------------------------
                                        /// ------------------------------------------   Connection to WS demo ----------------------------------------------

                                        if (!this.Productive)
                                        {
                                            //string user = "intredete";
                                            //string password = "5b1b3e2caaab51bb89cbb0d4bbccf385e9d7e6a748c85f6c102de0a4166645da";

                                            /**try
                                            {*/
                                            this.WSFTechSoapDemo = new WSFTechSoap();
                                            WSFTechSoapDemo.Response.UploadFileResponse response =
                                                WSFTechSoapDemo.UploadInvoiceFile(Document.Credential.User, Document.Credential.Password, xmlBase64);
                                            if (response != null)  // 
                                            {
                                                this.repositoryModel.UpdateConsecutiveResolution();
                                                this.repositoryModel.UpdateNumberDocument(this.Document);

                                                if (!String.IsNullOrEmpty(response.TransaccionID))
                                                {
                                                    this.Document.TransaccionID = response.TransaccionID;
                                                    this.repositoryModel.UpdateTransaccionIDDE(this.Document);
                                                    this.repositoryModel.UpdateEstadoTrueDocument(this.Document.ID);

                                                    WSFTechSoapDemo.Response.DocumentStatusFileResponse responseDoc =
                                                        WSFTechSoapDemo.DocumentStatusFile(Document.Credential.User, Document.Credential.Password, response.TransaccionID);
                                                    if (responseDoc.Code.Equals("201"))
                                                    {
                                                        this.repositoryModel.UpdateStatusSigned(this.Document.ID);
                                                        this.Document.IdStatus = 2;

                                                        this.repositoryModel.EditElectronicDocumentAll(Document);

                                                        this.cpElements.Enabled = true;
                                                        OptionPane.MessageSuccess("El documento electrónico se registró con éxito.");

                                                        /**
                                                        if (this.Document.Estado &&                                 // Document electronico
                                                            !this.Document.MetodoPago.Equals(this.MetPayCredito) &&  // metodo de pago contado
                                                            !this.Document.Cancelled &&                             // no esta cancelada
                                                            this.Document.Tipo.Equals(this.TypeInvoice))            // tipo factura electronica
                                                        {
                                                            this.repositoryModel.AddPayment(new ElectronicPayment
                                                            {
                                                                IdDE = this.Document.ID,
                                                                IdUser = this.IdUser,
                                                                IdCaja = this.IdCaja,
                                                                Total = this.Document.Total,
                                                                Date = this.Document.Fecha,
                                                                Payments = new List<Payment>
                                                                {
                                                                    new Payment
                                                                    {
                                                                        Code = this.Document.MedioPago,
                                                                        Pago = this.Document.Total,
                                                                        Valor = this.Document.Total
                                                                    }
                                                                }
                                                            });
                                                            this.repositoryModel.UpdateCancelledDocument(this.Document.ID);
                                                        }
                                                        */
                                                    }
                                                    else
                                                    {
                                                        OptionPane.MessageError("Ocurrio un error al firmar la factura electronica.\nCode " +
                                                            responseDoc.Code + "\nError " + responseDoc.MsgError);
                                                    }
                                                }
                                                else
                                                {
                                                    OptionPane.MessageError("Ocurrio un error al cargar la factura electronica.\nCode " +
                                                        response.Code + "\nError " + response.MsgError);
                                                }
                                            }
                                            else
                                            {
                                                OptionPane.MessageError("Ocurrio un error al cargar la factura electronica.");
                                            }
                                            /**}
                                            catch (System.ServiceModel.EndpointNotFoundException)
                                            {
                                                OptionPane.MessageError("No se conectó al servicio web de factura electrónica.");
                                            }*/
                                            /// -----------------------------------------------------------------------------------------------------------------
                                            /// ------------------------------------------ END Connection to WS demo --------------------------------------------

                                        }
                                        else
                                        {
                                            /// -----------------------------------------------------------------------------------------------------------------
                                            /// ------------------------------------------   Connection to WS Productive ----------------------------------------


                                            //string user = "901466029";
                                            //string password = "605c1ff9e88c7df7206aeb349e1283e42dbbccc068b14f58bbf5461ddb8d6d51";

                                            /**try
                                            {*/
                                            this.WSFTechSProductive = new WSFTechSPro();
                                            WSFTechSoapPro.UploadFileResponse response =
                                                this.WSFTechSProductive.UploadInvoiceFile(Document.Credential.User, Document.Credential.Password, xmlBase64);
                                            if (response != null)  // 
                                            {
                                                this.repositoryModel.UpdateConsecutiveResolution();
                                                this.repositoryModel.UpdateNumberDocument(this.Document);

                                                if (!String.IsNullOrEmpty(response.TransaccionID))
                                                {
                                                    this.Document.TransaccionID = response.TransaccionID;
                                                    this.repositoryModel.UpdateTransaccionIDDE(this.Document);
                                                    this.repositoryModel.UpdateEstadoTrueDocument(this.Document.ID);

                                                    WSFTechSoapPro.DocumentStatusFileResponse responseDoc =
                                                        this.WSFTechSProductive.DocumentStatusFile(Document.Credential.User, Document.Credential.Password, response.TransaccionID);
                                                    if (responseDoc.Code.Equals("201"))
                                                    {
                                                        this.repositoryModel.UpdateStatusSigned(this.Document.ID);
                                                        this.Document.IdStatus = 2;
                                                        this.repositoryModel.EditElectronicDocumentAll(Document);

                                                        this.cpElements.Enabled = true;
                                                        OptionPane.MessageSuccess("El documento electrónico se registró con éxito.");

                                                        /**
                                                        if (this.Document.Estado &&                                 // Document electronico
                                                            !this.Document.MetodoPago.Equals(this.MetPayCredito) &&  // metodo de pago contado
                                                            !this.Document.Cancelled &&                             // no esta cancelada
                                                            this.Document.Tipo.Equals(this.TypeInvoice))            // tipo factura electronica
                                                        {
                                                            this.repositoryModel.AddPayment(new ElectronicPayment
                                                            {
                                                                IdDE = this.Document.ID,
                                                                IdUser = this.IdUser,
                                                                IdCaja = this.IdCaja,
                                                                Total = this.Document.Total,
                                                                Date = this.Document.Fecha,
                                                                Payments = new List<Payment>
                                                                {
                                                                    new Payment
                                                                    {
                                                                        Code = this.Document.MedioPago,
                                                                        Pago = this.Document.Total,
                                                                        Valor = this.Document.Total
                                                                    }
                                                                }
                                                            });
                                                            this.repositoryModel.UpdateCancelledDocument(this.Document.ID);
                                                        }
                                                        */
                                                    }
                                                    else
                                                    {
                                                        OptionPane.MessageError("Ocurrio un error al firmar la factura electronica.\nCode " +
                                                            responseDoc.Code + "\nError " + responseDoc.MsgError);
                                                    }
                                                }
                                                else
                                                {
                                                    OptionPane.MessageError("Ocurrio un error al cargar la factura electronica.\nCode " +
                                                        response.Code + "\nError " + response.MsgError);
                                                }
                                            }
                                            else
                                            {
                                                OptionPane.MessageError("Ocurrio un error al cargar la factura electronica.");
                                            }
                                            /**}
                                            catch (System.ServiceModel.EndpointNotFoundException)
                                            {
                                                OptionPane.MessageError("No se conectó al servicio web de factura electrónica.");
                                            }*/

                                            /// -----------------------------------------------------------------------------------------------------------------
                                            /// ------------------------------------------ END Connection to WS Productive --------------------------------------

                                        }
                                        /// Add payment to electronic document.
                                        if (this.Document.Estado &&                                 // Document electronico
                                            this.Document.Tipo.Equals(this.TypeInvoice) &&          // tipo factura electronica
                                            !this.Document.MetodoPago.Equals(this.MetPayCredito) &&  // metodo de pago contado
                                            !this.Document.Cancelled)                                // no esta cancelada
                                        {
                                            this.repositoryModel.AddPayment(new ElectronicPayment
                                            {
                                                IdDE = this.Document.ID,
                                                IdUser = this.IdUser,
                                                IdCaja = this.IdCaja,
                                                Total = this.Document.Neto,
                                                Date = this.Document.Fecha,
                                                Payments = new List<Payment>
                                                {
                                                    new Payment
                                                    {
                                                        Code = this.Document.MedioPago,
                                                        Pago = this.Document.Neto,
                                                        Valor = this.Document.Neto
                                                    }
                                                }
                                            });
                                            this.repositoryModel.UpdateCancelledDocument(this.Document.ID);
                                        }
                                    }
                                    catch (System.ServiceModel.EndpointNotFoundException)
                                    {
                                        OptionPane.MessageError("No se conectó al servicio web de factura electrónica.");
                                    }
                                }
                            }
                            else
                            {
                                OptionPane.MessageError(this.MsnValidate);
                            }
                            this.btnBuscarDocument_Click(this.btnBuscarDocument, new EventArgs());
                        }
                        else
                        {
                            OptionPane.MessageInformation("El documento no se puede generar, verifique su estatus.");
                        }
                    }
                    else
                    {
                        OptionPane.MessageError("El registro no tiene cliente asociado.");
                    }
                }
                else
                {
                    OptionPane.MessageInformation("No hay registros para generar.");
                }

            }
            catch (Exception ex)
            {
                this.cpElements.Enabled = true;
                OptionPane.MessageError(ex.Message);
            }
            finally { this.cpElements.Enabled = true; }
        }

        private void btnGENXML_Click_old(object sender, EventArgs e)
        {
            try
            {
                // validar grid lleno
                if (!Convert.ToBoolean(this.dgvDocuments.CurrentRow.Cells["EstadoBool"].Value))
                {
                    if (!String.IsNullOrEmpty(this.dgvDocuments.CurrentRow.Cells["NitCliente"].Value.ToString()))
                    {
                        this.Document = new ElectronicDocument();
                        this.Document.ID = Convert.ToInt32(this.dgvDocuments.CurrentRow.Cells["Id"].Value);
                        //this.Document.NitCliente = this.Documents.Where(d => d.ID.Equals(this.Document.ID)).FirstOrDefault().NitCliente;
                        this.Document = this.repositoryModel.GetDocumentData(this.Document, this.Productive);
                        if (ValidateElectronicDocument(this.Document))
                        {
                            DialogResult rta = MessageBox.Show("¿Desea generar el documento electrónico?", "Factura electrónica",
                                            MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                            if (rta.Equals(DialogResult.Yes))
                            {
                                this.cpElements.Enabled = false;
                                /// validaciones

                                /**
                                this.Document = new ElectronicDocument();
                                this.Document.ID = Convert.ToInt32(this.dgvDocuments.CurrentRow.Cells["Id"].Value);
                                this.Document.NitCliente = this.Documents.Where(d => d.ID.Equals(this.Document.ID)).FirstOrDefault().NitCliente;
                                this.Document = this.repositoryModel.GetDocumentData(this.Document);
                                */

                                Document.Estado = true;
                                Document.Numero = Document.Resolution.prefijo + Document.Resolution.consecutive;
                                Document.Fecha = DateTime.Now;
                                Document.IdResolucion = Document.Resolution.id;
                                Document.NoItems = Document.Items.Count;
                                Document.Total = Document.Items.Sum(s => s.Total);

                                // generar XML
                                DocumentElectronicLoad deLoad = new DocumentElectronicLoad();
                                deLoad.Document = Document;
                                //string xmlBase64 = deLoad.CreateXML();

                                /// ------------------------------------------   Connection to WS demo ---------------------------------------------------

                                string user = "intredete";
                                string password = "5b1b3e2caaab51bb89cbb0d4bbccf385e9d7e6a748c85f6c102de0a4166645da";

                                /*
                                WSFTechSoap wsFTech = new WSFTechSoap();
                                WSFTechSoapDemo.Response.UploadFileResponse response = wsFTech.UploadInvoiceFile(user, password, xmlBase64);
                                if (response != null)
                                {
                                    if (!String.IsNullOrEmpty(response.TransaccionID))
                                    {
                                        Document.TransaccionID = response.TransaccionID;
                                        this.repositoryModel.UpdateTransaccionIDDE(this.Document);
                                        this.repositoryModel.UpdateConsecutiveResolution();

                                        /// print data
                                        Console.WriteLine(response.Code);
                                        Console.WriteLine(response.Success);
                                        Console.WriteLine(response.TransaccionID);
                                        Console.WriteLine(response.MsgError);
                                        Console.WriteLine();
                                    }
                                }
                                */

                                //UploadWSFtechDemo(user, password, xmlBase64);

                                /// ------------------------------------------ END Connectino to WS demo ---------------------------------------------------


                                ///UploadWSFtechPro(this.Document.Credential.User, this.Document.Credential.Password, xmlBase64);

                                ///string user = "901466029";
                                ///string password = "605c1ff9e88c7df7206aeb349e1283e42dbbccc068b14f58bbf5461ddb8d6d51";

                                /**this.cpElements.Enabled = true;
                                if (this.Document.Estado &&                                 // Document electronico
                                    !this.Document.MetodoPago.Equals(this.MetPayCredito) &&  // metodo de pago credito
                                    !this.Document.Cancelled &&                             // no esta cancelada
                                    this.Document.Tipo.Equals(this.TypeInvoice))            // tipo factura electronica
                                {
                                    this.repositoryModel.AddPayment(new ElectronicPayment
                                    {
                                        IdDE = this.Document.ID,
                                        IdUser = this.IdUser,
                                        IdCaja = this.IdCaja,
                                        Total = this.Document.Total,
                                        Date = this.Document.Fecha,
                                        Payments = new List<Payment>
                                        {
                                            new Payment
                                            {
                                                Code = this.Document.MedioPago,
                                                Pago = this.Document.Total,
                                                Valor = this.Document.Total
                                            }
                                        }
                                    });
                                    this.repositoryModel.UpdateCancelledDocument(this.Document.ID);
                                    this.btnBuscarDocument_Click(this.btnBuscarDocument, new EventArgs());
                                }
                                */
                            }
                        }
                        else
                        {
                            OptionPane.MessageInformation(MsnValidate);
                        }
                    }
                    else
                    {
                        OptionPane.MessageInformation("El registro no tiene cliente asociado.");
                    }
                }
                else
                {
                    OptionPane.MessageInformation("El registro ya es un Documento Electrónico.");
                }


                /**
                try
                {
                    WSFTechSoap wsFTech = new WSFTechSoap();
                    WSFTechSoapDemo.Response.UploadFileResponse response = wsFTech.UploadInvoiceFile(user, password, xmlBase64);
                    ///response.TransaccionID = "1";
                    if (!String.IsNullOrEmpty(response.TransaccionID))
                    {
                        /// print data
                        Console.WriteLine(response.Code);
                        Console.WriteLine(response.Success);
                        Console.WriteLine(response.TransaccionID);
                        Console.WriteLine(response.MsgError);
                        Console.WriteLine();

                        Document.TransaccionID = response.TransaccionID;
                        ///response.TransaccionID = "";
                        WSFTechSoapDemo.Response.DocumentStatusFileResponse responseDoc =
                            wsFTech.DocumentStatusFile(user, password, response.TransaccionID);

                        /// print data
                        Console.WriteLine(responseDoc.Code);
                        Console.WriteLine(responseDoc.Success);
                        Console.WriteLine(responseDoc.Status);
                        Console.WriteLine(responseDoc.MsgError);
                        Console.WriteLine();

                        /// validations response.Code

                        Document.IdStatus = 2;
                        this.repositoryModel.EditElectronicDocumentAll(Document);
                        this.repositoryModel.UpdateConsecutiveResolution(Document.IdResolucion);
                        this.btnBuscarDocument_Click(this.btnBuscarDocument, new EventArgs());
                        OptionPane.MessageSuccess("El documento electrónico se registró con éxito.");
                    }
                    else
                    {
                        OptionPane.MessageError("Ocurrió un error al cargar el documento electrónico.\nError WSFtech\nCode: " + response.Code + "\nError: " + response.MsgError);
                    }

                }
                catch (System.ServiceModel.EndpointNotFoundException)
                {
                    OptionPane.MessageError("No se conectó al servicio web de factura electrónica.");
                }
                */


                /*
                Console.WriteLine(response.Code);
                Console.WriteLine(response.Success);
                Console.WriteLine(response.TransaccionID);
                Console.WriteLine(response.MsgError);
                Console.WriteLine();
                */

                /*
                WSFTechSoapDemo.Response.DocumentStatusFileResponse responseDoc = wsFTech.DocumentStatusFile(user, password, response.TransaccionID);
                Console.WriteLine(responseDoc.Code);
                Console.WriteLine(responseDoc.Success);
                Console.WriteLine(responseDoc.Status);
                Console.WriteLine(responseDoc.MsgError);
                Console.WriteLine();
                */


                ///this.repositoryModel.GenXML(this.Document);

                /// validacion
                /*if (ValidateData(this.Document))
                {
                    this.repositoryModel.GenXML(this.Document);
                }
                else
                {
                    OptionPane.MessageInformation(MsnValidate);
                }*/

                ///this.repositoryModel.GenXML(id);
                /*
                this.Document = this.repositoryModel.UpdateTaxes(id);
                
                this.Document.ID = id;
                
                var resolution = this.repositoryModel.ResolutionEnd();
                this.Document.Numero = resolution.prefijo + resolution.consecutive;
                this.Document.Fecha = this.Document.FechaLimite = this.Document.FechaPago = DateTime.Now;
                this.Document.IdResolucion = resolution.id;
                */
            }
            catch (Exception ex)
            {
                this.cpElements.Enabled = true;
                OptionPane.MessageError(ex.Message);
            }
        }

        private void UploadIvoice()
        {
            try
            {
                if (!this.Productive)
                {
                    //this.WSFTechSoapDemo = new WSFTechSoap();
                    this.Response = this.WSFTechSoapDemo.UploadInvoiceFile(
                        this.Document.Credential.User, this.Document.Credential.Password, this.XmlBase64);
                }
                else
                {
                    this.ResponsePro = this.WSFTechSProductive.UploadInvoiceFile(
                        this.Document.Credential.User, this.Document.Credential.Password, this.XmlBase64);
                    this.Response = new WSFTechSoapDemo.Response.UploadFileResponse
                    {
                        Code = this.ResponsePro.Code,
                        TransaccionID = this.ResponsePro.TransaccionID,
                        Success = this.ResponsePro.Success,
                        MsgError = this.ResponsePro.MsgError
                    };
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private void DocumentStatus()
        {
            try
            {
                if (!this.Productive)
                {
                    this.ResponseDoc = this.WSFTechSoapDemo.DocumentStatusFile(
                        this.Document.Credential.User, this.Document.Credential.Password, this.Document.TransaccionID);
                }
                else
                {
                    this.ResponseDocPro = this.WSFTechSProductive.DocumentStatusFile(
                        this.Document.Credential.User, this.Document.Credential.Password, this.Document.TransaccionID);
                    this.ResponseDoc = new WSFTechSoapDemo.Response.DocumentStatusFileResponse
                    {
                        Code = this.ResponseDocPro.Code,
                        Status = this.ResponseDocPro.Status,
                        Success = this.ResponseDocPro.Success,
                        MsgError = this.ResponseDocPro.Success
                    };
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        private void btnSigned_Click(object sender, EventArgs e)
        {
            try
            {
                
            }
            catch (Exception ex)
            {
                this.cpElements.Enabled = true;
                OptionPane.MessageError(ex.Message);
            }
            finally { this.cpElements.Enabled = true; }
        }

        private void btnSigned_Click_(object sender, EventArgs e)
        {
            try
            {
                if (this.dgvDocuments.RowCount > 0)
                {
                    this.Document = this.Documents.Find(d => d.ID.Equals(Convert.ToInt32(this.dgvDocuments.CurrentRow.Cells["Id"].Value)));
                    // validation signed

                    if (this.Document.Estado &&
                        this.Document.IdStatus.Equals(1) &&
                        !String.IsNullOrEmpty(this.Document.TransaccionID))
                    {
                        DialogResult rta = MessageBox.Show("¿Desea firmar el documento electrónico?", "Factura electrónica",
                                                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (rta.Equals(DialogResult.Yes))
                        {
                            this.cpElements.Enabled = false;

                            /// -----------------------------------------------------------------------------------------------------------------
                            /// ------------------------------------------   Connection to WS demo ----------------------------------------------

                            string user = "intredete";
                            string password = "5b1b3e2caaab51bb89cbb0d4bbccf385e9d7e6a748c85f6c102de0a4166645da";

                            try
                            {
                                this.WSFTechSoapDemo = new WSFTechSoap();
                                WSFTechSoapDemo.Response.DocumentStatusFileResponse responseDoc =
                                    WSFTechSoapDemo.DocumentStatusFile(user, password, this.Document.TransaccionID);
                                if (responseDoc.Code.Equals("201"))
                                {
                                    this.repositoryModel.UpdateStatusSigned(this.Document.ID);

                                    this.cpElements.Enabled = true;
                                    OptionPane.MessageSuccess("El documento electrónico se firmo con éxito.");
                                }
                            }
                            catch (System.ServiceModel.EndpointNotFoundException)
                            {
                                OptionPane.MessageError("No se conectó al servicio web de factura electrónica.");
                            }

                            /// -----------------------------------------------------------------------------------------------------------------
                            /// ------------------------------------------ END Connection to WS demo --------------------------------------------


                            /// -----------------------------------------------------------------------------------------------------------------
                            /// ------------------------------------------   Connection to WS Productive ----------------------------------------
                            /**
                            string user = "901466029";
                            string password = "605c1ff9e88c7df7206aeb349e1283e42dbbccc068b14f58bbf5461ddb8d6d51";

                            try
                            {
                                this.WSFTechSProductive = new WSFTechSPro();
                                WSFTechSoapPro.DocumentStatusFileResponse responseDoc =
                                    this.WSFTechSProductive.DocumentStatusFile(user, password, this.Document.TransaccionID);
                                if (responseDoc.Code.Equals("201"))
                                {
                                    this.repositoryModel.UpdateStatusSigned(this.Document.ID);

                                    this.cpElements.Enabled = true;
                                    OptionPane.MessageSuccess("El documento electrónico se firmo con éxito.");
                                }
                            }
                            catch (System.ServiceModel.EndpointNotFoundException)
                            {
                                OptionPane.MessageError("No se conectó al servicio web de factura electrónica.");
                            }
                            */

                            /// -----------------------------------------------------------------------------------------------------------------
                            /// ------------------------------------------ END Connection to WS Productive --------------------------------------

                        }
                    }
                    else
                    {
                        OptionPane.MessageInformation("El documento no se puede firmar.");
                    }
                }
                else
                {
                    OptionPane.MessageInformation("No hay documentos para firmar.");
                }
            }
            catch (Exception ex)
            {
                this.cpElements.Enabled = true;
                OptionPane.MessageError(ex.Message);
            }
            finally { this.cpElements.Enabled = true; }
        }

        private void btnPayment_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.dgvDocuments.RowCount > 0)
                {
                    this.Document = this.Documents.Find(d => d.ID.Equals(
                        Convert.ToInt32(this.dgvDocuments.CurrentRow.Cells["Id"].Value)));
                    if (this.Document.Estado &&                                   // Document electronico
                        this.Document.Tipo.Equals(this.TypeInvoice) &&            // tipo factura electronica
                        //this.Document.MetodoPago.Equals(this.MetPayCredito) &&  // metodo de pago credito
                        !this.Document.Cancelled                                  // no esta cancelada
                        )
                    {
                        this.IDIndex = this.dgvDocuments.CurrentRow.Index;

                        var frmPayment = new FrmPayment();
                        frmPayment.Document = this.repositoryModel.GetDocumentCompany(this.Document, this.Productive);

                        frmPayment.IdCaja = this.IdCaja;
                        frmPayment.IdUser = this.IdUser;
                        frmPayment.IDDE = this.Document.ID;
                        frmPayment.Total = Math.Round(this.Document.Neto - this.Document.Payment, 2);
                        frmPayment.ShowDialog();
                    }
                    else
                    {
                        OptionPane.MessageInformation("El documento no se puede pagar.");
                    }
                }
                else
                {
                    OptionPane.MessageInformation("No hay registros para pagar");
                }
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
        }




        public void UploadWSFtechDemo(string user, string password, string xmlBase64)
        {
            try
            {
                WSFTechSoap wsFTech = new WSFTechSoap();
                WSFTechSoapDemo.Response.UploadFileResponse response = wsFTech.UploadInvoiceFile(user, password, xmlBase64);
                //response.TransaccionID = "1";
                if (!String.IsNullOrEmpty(response.TransaccionID))
                {
                    Document.TransaccionID = response.TransaccionID;
                    this.repositoryModel.UpdateTransaccionIDDE(this.Document);
                    this.repositoryModel.UpdateConsecutiveResolution();


                    /// print data
                    Console.WriteLine(response.Code);
                    Console.WriteLine(response.Success);
                    Console.WriteLine(response.TransaccionID);
                    Console.WriteLine(response.MsgError);
                    Console.WriteLine();

                    
                    ///response.TransaccionID = "";
                    WSFTechSoapDemo.Response.DocumentStatusFileResponse responseDoc =
                        wsFTech.DocumentStatusFile(user, password, response.TransaccionID);

                    //this.repositoryModel.UpdateConsecutiveResolution();

                    /// print data
                    Console.WriteLine(responseDoc.Code);
                    Console.WriteLine(responseDoc.Success);
                    Console.WriteLine(responseDoc.Status);
                    Console.WriteLine(responseDoc.MsgError);
                    Console.WriteLine();

                    /// validations response.Code

                    Document.IdStatus = 2;
                    this.repositoryModel.EditElectronicDocumentAll(Document);
                    //this.repositoryModel.UpdateConsecutiveResolution(Document.IdResolucion);
                    //this.btnBuscarDocument_Click(this.btnBuscarDocument, new EventArgs());
                    OptionPane.MessageSuccess("El documento electrónico se registró con éxito.");
                }
                else
                {
                    OptionPane.MessageError("Ocurrió un error al cargar el documento electrónico.\nError WSFtech\nCode: " + response.Code + "\nError: " + response.MsgError);
                }

            }
            catch (System.ServiceModel.EndpointNotFoundException)
            {
                OptionPane.MessageError("No se conectó al servicio web de factura electrónica.");
            }
        }

        public void UploadWSFtechPro(string user, string password, string xmlBase64)
        {
            try
            {
                WSFTechSPro wsFTechPro = new WSFTechSPro();
                WSFTechSoapPro.UploadFileResponse response = wsFTechPro.UploadInvoiceFile(user, password, xmlBase64);


                //WSFTechSoap wsFTech = new WSFTechSoap();
                //WSFTechSoapDemo.Response.UploadFileResponse response = wsFTech.UploadInvoiceFile(user, password, xmlBase64);
                ///response.TransaccionID = "1";
                if (!String.IsNullOrEmpty(response.TransaccionID))
                {
                    Document.TransaccionID = response.TransaccionID;
                    this.repositoryModel.UpdateTransaccionIDDE(this.Document);
                    this.repositoryModel.UpdateConsecutiveResolution();

                    /// print data
                    Console.WriteLine(response.Code);
                    Console.WriteLine(response.Success);
                    Console.WriteLine(response.TransaccionID);
                    Console.WriteLine(response.MsgError);
                    Console.WriteLine();

                    
                    ///response.TransaccionID = "";

                    WSFTechSoapPro.DocumentStatusFileResponse responseDoc = 
                        wsFTechPro.DocumentStatusFile(user, password, response.TransaccionID);

                    

                    /*WSFTechSoapDemo.Response.DocumentStatusFileResponse responseDoc =
                        wsFTech.DocumentStatusFile(user, password, response.TransaccionID);*/

                    /// print data
                    Console.WriteLine(responseDoc.Code);
                    Console.WriteLine(responseDoc.Success);
                    Console.WriteLine(responseDoc.Status);
                    Console.WriteLine(responseDoc.MsgError);
                    Console.WriteLine();

                    /// validations response.Code

                    Document.IdStatus = 2;
                    this.repositoryModel.EditElectronicDocumentAll(Document);
                    //this.repositoryModel.UpdateConsecutiveResolution(Document.IdResolucion);
                    //this.btnBuscarDocument_Click(this.btnBuscarDocument, new EventArgs());
                    OptionPane.MessageSuccess("El documento electrónico se registró con éxito.");
                }
                else
                {
                    OptionPane.MessageError("Ocurrió un error al cargar el documento electrónico.\nError WSFtech\nCode: " + response.Code + "\nError: " + response.MsgError);
                }

            }
            catch (System.ServiceModel.EndpointNotFoundException)
            {
                OptionPane.MessageError("No se conectó al servicio web de factura electrónica.");
            }
        }



        private void btnGenNC_Click(object sender, EventArgs e)
        {

        }

        private void btnCopy_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.dgvDocuments.RowCount > 0)
                {
                    this.Document = this.Documents.Find(d => d.ID.Equals(
                        Convert.ToInt32(this.dgvDocuments.CurrentRow.Cells["Id"].Value)));
                    this.Document = this.repositoryModel.GetDocumentData(this.Document, this.Productive);
                    PrintInvoice = new PrintInvoice();
                    PrintInvoice.Print(this.Document, !String.IsNullOrEmpty(this.Document.TransaccionID));

                }
                else
                {
                    OptionPane.MessageInformation("No hay registros para imprimir.");
                }
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
        }







        private bool ValidateElectronicDocument(ElectronicDocument ed)
        {
            bool valide = true;
            if (ed.Company.Company.nitempresa.Split('-').Count() > 1)
            {
                valide = false;
                MsnValidate += "El nit de la empresa es invalido.\n";
            }
            if (ed.Company.DetailsCIIU.Rows.Count.Equals(0))
            {
                valide = false;
                MsnValidate += "La empresa no tiene actividad económica asociada.\n";
            }
            if (ed.Company.DetailsTributary.Rows.Count.Equals(0))
            {
                valide = false;
                MsnValidate += "La empresa no tiene tributos asociados.\n";
            }
            if (ed.Company.DetailsRUT.Rows.Count.Equals(0))
            {
                valide = false;
                MsnValidate += "La empresa no tiene info complementaria del RUT asociada.\n";
            }
            if (ed.Company.City.Departament.Code.Equals(""))
            {
                valide = false;
                MsnValidate += "La empresa no tiene código del departamento de ubicación.\n";
            }
            if (ed.Company.City.Code.Equals(""))
            {
                valide = false;
                MsnValidate += "La empresa no tiene código de la ciudad de ubicación.\n";
            }
            if (ed.Company.City.CodePostal.Equals(""))
            {
                valide = false;
                MsnValidate += "La empresa no tiene código postal de ubicación.\n";
            }
            if (ed.Company.Company.emailempresa.Equals(""))
            {
                valide = false;
                MsnValidate += "La empresa no tiene email.\n";
            }



            if (ed.Customer.Cliente.nitcliente.Split('-').Count() > 1)
            {
                valide = false;
                MsnValidate += "El documento del cliente es invalido.\n";
            }
            if (ed.Customer.DetailsTributary.Rows.Count.Equals(0))
            {
                valide = false;
                MsnValidate += "El cliente no tiene tributos asociados.\n";
            }
            if (ed.Customer.DetailsRUT.Rows.Count.Equals(0))
            {
                valide = false;
                MsnValidate += "El cliente no tiene info complementaria del RUT asociada.\n";
            }
            if (ed.Customer.City.Departament.Code.Equals(""))
            {
                valide = false;
                MsnValidate += "El cliente no tiene código del departamento de ubicación.\n";
            }
            if (ed.Customer.City.Code.Equals(""))
            {
                valide = false;
                MsnValidate += "El cliente no tiene código de la ciudad de ubicación.\n";
            }
            if (ed.Customer.City.CodePostal.Equals(""))
            {
                valide = false;
                MsnValidate += "El cliente no tiene código postal de ubicación.\n";
            }
            if (ed.Customer.Cliente.emailcliente.Equals(""))
            {
                valide = false;
                MsnValidate += "El cliente no tiene email.\n";
            }

            if (!(ed.Resolution.consecutive <= ed.Resolution.number_end))
            {
                valide = false;
                MsnValidate += "El numero de la resolución ha caducado.\n";
            }
            if (!(ed.Resolution.date_end >= DateTime.Now.Date))
            {
                valide = false;
                MsnValidate += "La fecha de la resolucion ha caducado.\n";
            }

            if (!ed.ValideBaseTaxRetentions(this.CodeReteIVA))
            {
                valide = false;
                MsnValidate += "Verifique los registros de retenciones. \nLas bases no coinciden.";
            }

            if (ed.MetodoPago.Equals(this.MetPayCredito)) // metodo de pago: crédito
            {
                //ed.MedioPago = null;
                if (UseDate.FechaSinHora(ed.FechaPago) <= UseDate.FechaSinHora(DateTime.Now)) /// modificar por validacion de fechas de documentos cuando quedan en stan by 
                {
                    valide = false;
                    MsnValidate += "La fecha de pago debe ser superior a la del documento electronico.";
                }
            }

            return valide;
        }


        void CompletaEventos_Completo(CompletaArgumentosDeEvento args)
        {
            try
            {
                var obj = (ObjectAbstract)args.MiObjeto;
                if (obj.Id.Equals(this.CodeTransferEventPayment))
                {
                    this.btnBuscarDocument_Click(this.btnBuscarDocument, new EventArgs());
                    this.IDIndex = 0;
                }
            }
            catch { }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            string rta_ = CustomControl.OptionPane.OptionBox
                    ("Ingresar contraseña de Administrador .", "Administrador", CustomControl.OptionPane.Icon.LoginAdmin);
            if (rta_.Equals("6821"))
            {
                try
                {
                    if (this.dgvDocuments.RowCount > 0)
                    {
                        this.Document = this.Documents.Find(d => d.ID.Equals(Convert.ToInt32(this.dgvDocuments.CurrentRow.Cells["Id"].Value)));
                        if (!this.Document.Estado)
                        {
                            DialogResult rta = MessageBox.Show("¿Desea elminar el registro?", "Factura electrónica",
                                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                            if (rta.Equals(DialogResult.Yes))
                            {
                                this.repositoryModel.DeleteElectronicDocument(this.Document.ID);
                                OptionPane.MessageInformation("El documento se eliminó con exito.");
                                this.btnBuscarDocument_Click(this.btnBuscarDocument, new EventArgs());
                            }
                        }
                        else
                        {
                            OptionPane.MessageInformation("El documento no se puede eliminar.");
                        }
                    }
                }
                catch (Exception ex)
                {
                    OptionPane.MessageError(ex.Message);
                }
            }
        }

        ElectronicDocument document;

        private void dgvDocuments_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (this.dgvDocuments.RowCount > 0)
            {
                try
                {
                    this.document = this.Documents.Find(d => d.ID.Equals(Convert.ToInt32(this.dgvDocuments.CurrentRow.Cells["Id"].Value)));

                    this.document = this.repositoryModel.GetDocumentData(this.document, this.Productive);
                    this.dgvItems.DataSource = this.document.Items;
                    this.dgvTaxRetenciones.DataSource = this.document.Retentions;

                    this.TotalInvoice.SubTotal = this.document.Items.Sum(s => s.SubTotal);
                    this.TotalInvoice.IVA = Math.Round(this.document.Items.Sum(s => ((s.UnitPrice * s.Quantity) * s.IVA / 100)), 2);
                    this.TotalInvoice.IC = Math.Round(this.document.Items.Sum(s => s.IC * s.Quantity), 2);
                    this.TotalInvoice.Total = this.TotalInvoice.SubTotal + this.TotalInvoice.IVA + this.TotalInvoice.IC;
                    this.TotalInvoice.Retention = Math.Round(this.document.Retentions.Sum(s => s.Value), 2);
                    this.TotalInvoice.Neto = this.TotalInvoice.Total - this.TotalInvoice.Retention;

                    this.txtSubtotal.Text = UseObject.InsertSeparatorMil(this.TotalInvoice.SubTotal.ToString());
                    this.txtIVA.Text = UseObject.InsertSeparatorMil(this.TotalInvoice.IVA.ToString());
                    this.txtIC.Text = UseObject.InsertSeparatorMil(this.TotalInvoice.IC.ToString());
                    this.txtTotalPie.Text = UseObject.InsertSeparatorMil(this.TotalInvoice.Total.ToString());
                    this.txtRetencion.Text = UseObject.InsertSeparatorMil(this.TotalInvoice.Retention.ToString());
                    this.txtNeto.Text = UseObject.InsertSeparatorMil(this.TotalInvoice.Neto.ToString());
                }
                catch (Exception ex)
                {
                    OptionPane.MessageError(ex.Message);
                }
            }
        }

        private void FrmListDE_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F5))
            {
                try
                {
                    /*this.Document = this.Documents.Find(d => d.ID.Equals(Convert.ToInt32(this.dgvDocuments.CurrentRow.Cells["Id"].Value)));
                    this.Document = this.repositoryModel.GetDocumentData(this.Document, this.Productive);
                    PrintInvoice.Print(this.Document);*/
                }
                catch (Exception ex)
                {
                    OptionPane.MessageError(ex.Message);
                }
            }
        }

        private bool ValidateTrazability(string msnError)
        {
            return true;
        }

        private void btnFiscal_Click(object sender, EventArgs e)
        {
            try
            {
                Auxiliares.Form5 form = new Auxiliares.Form5();
                var invos = repositoryModel.InvoiceExport(dtDateBegin.Value, dtDateEnd.Value, 1);
                form.dataGridView1.DataSource = invos;
                //form.dataGridView1.bin;
                form.Show();

                /*
                 * 
                BussinesLayer.Clases.BussinesEmpresa bsEmpresa = new BussinesLayer.Clases.BussinesEmpresa();
                DataSet dsEmpresa = bsEmpresa.PrintEmpresa();

                List<DTO.Clases.Impuesto> taxes = this.repositoryModel.ElectronicFiscal(this.dtDateBegin.Value, this.dtDateEnd.Value);

                IEnumerable<DTO.Clases.Impuesto> ts = from t in taxes orderby t.Tax 
                                                      group t by new
                                                      {
                                                          t.Tarifa
                                                      }
                                                          into taxs 
                                                          select new DTO.Clases.Impuesto
                                                          {
                                                              Tarifa = taxs.Key.Tarifa,
                                                              BaseGravable = taxs.Sum(s => s.BaseGravable),
                                                              ValorIva = taxs.Sum(s => s.ValorIva),
                                                              Impoconsumo = taxs.Sum(s => s.Impoconsumo),
                                                              Neto = taxs.Sum(s => s.GetNeto)
                                                          };
                ///int acumulado = this.repositoryModel.AcumuladoDE(new DateTime(dtDateEnd.Value.Year, dtDateEnd.Value.Month, 1), dtDateEnd.Value);

                InformesForms.FrmReportViewer frmR = new InformesForms.FrmReportViewer();
                frmR.Text = "Fiscal Factura Electronica";

                frmR.reportViewer.LocalReport.ReportPath = AppConfiguracion.ValorSeccion("report") + @"\reports\Informe_Fiscal_Electronic.rdlc";
                //frmR.reportViewer.LocalReport.ReportPath = @"C:\reports\Informe_Fiscal_Electronic.rdlc";
                //frmR.reportViewer.LocalReport.RefreshReport();

                frmR.reportViewer.LocalReport.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource(
                    "DsEmpresa", dsEmpresa.Tables[0]));
                frmR.reportViewer.LocalReport.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource(
                    "ImpuestoIva", ts));

                var pFecha = new Microsoft.Reporting.WinForms.ReportParameter();
                pFecha.Name = "Fecha";
                
                if (UseDate.FechaSinHora(this.dtDateBegin.Value).Equals(UseDate.FechaSinHora(this.dtDateEnd.Value)))
                {
                    pFecha.Values.Add("Fecha: " + this.dtDateBegin.Value.ToShortDateString());
                }
                else
                {
                    pFecha.Values.Add("Período: " + this.dtDateBegin.Value.ToShortDateString() + " a " + this.dtDateEnd.Value.ToShortDateString());
                }
                frmR.reportViewer.LocalReport.SetParameters(pFecha);

                var pRegBegin = new Microsoft.Reporting.WinForms.ReportParameter();
                pRegBegin.Name = "RegInicial";
                pRegBegin.Values.Add(taxes.First().Numero);
                frmR.reportViewer.LocalReport.SetParameters(pRegBegin);

                var pRegEnd = new Microsoft.Reporting.WinForms.ReportParameter();
                pRegEnd.Name = "RegFinal";
                pRegEnd.Values.Add(taxes.Last().Numero);
                frmR.reportViewer.LocalReport.SetParameters(pRegEnd);

                var pRegTotal = new Microsoft.Reporting.WinForms.ReportParameter();
                pRegTotal.Name = "RegTotal";
                var t_ = taxes.GroupBy(t => t.Id).Select(s => s.Key).ToList().Count.ToString();
                pRegTotal.Values.Add(taxes.GroupBy(t => t.Id).Select(s => s.Key).ToList().Count.ToString());
                frmR.reportViewer.LocalReport.SetParameters(pRegTotal);

                var pContado = new Microsoft.Reporting.WinForms.ReportParameter();
                pContado.Name = "Contado";
                var cont = Convert.ToInt32(taxes.Where(t => t.PayMethod.Equals(1)).Sum(s => s.GetNeto));
                pContado.Values.Add(Convert.ToInt32(taxes.Where(t => t.PayMethod.Equals(1)).Sum(s => s.GetNeto)).ToString());
                frmR.reportViewer.LocalReport.SetParameters(pContado);

                var pCredito = new Microsoft.Reporting.WinForms.ReportParameter();
                pCredito.Name = "Credito";
                var cont_ = Convert.ToInt32(taxes.Where(t => t.PayMethod.Equals(2)).Sum(s => s.GetNeto));
                pCredito.Values.Add(Convert.ToInt32(taxes.Where(t => t.PayMethod.Equals(2)).Sum(s => s.GetNeto)).ToString());
                frmR.reportViewer.LocalReport.SetParameters(pCredito);

                var pTotal = new Microsoft.Reporting.WinForms.ReportParameter();
                pTotal.Name = "Total";
                pTotal.Values.Add(Convert.ToInt32(taxes.Sum(s => s.GetNeto)).ToString());
                frmR.reportViewer.LocalReport.SetParameters(pTotal);

                int acumulado = 0;

                var pAcumulado = new Microsoft.Reporting.WinForms.ReportParameter();
                pAcumulado.Name = "Acumulado";
                if (dtDateBegin.Value.Month.Equals(dtDateEnd.Value.Month))
                {
                    acumulado = this.repositoryModel.AcumuladoDE(new DateTime(dtDateEnd.Value.Year, dtDateEnd.Value.Month, 1), dtDateEnd.Value);
                    //pAcumulado.Values.Add(acumulado.ToString());
                }
                pAcumulado.Values.Add(acumulado.ToString());
                frmR.reportViewer.LocalReport.SetParameters(pAcumulado);

                frmR.reportViewer.RefreshReport();
                frmR.ShowDialog();

                */
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
        }

        
    }
}