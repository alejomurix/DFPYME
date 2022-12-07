using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Aplicacion.Compras.IngresarCompra;
using BussinesLayer.Clases;
using CustomControl;
using DTO.Clases;
using Microsoft.Reporting.WinForms;
using RawDataPrint;
using Utilities;

namespace Aplicacion.Ventas.Factura
{
    public partial class FrmFacturaPos : Form
    {
        #region Logica de Negocio

        /// <summary>
        /// Objeto que encapsula la lógica de negocio de Forma de Pago.
        /// </summary>
        //private BussinesFormaPago miBussinesFormaPago;
        private BussinesEstado miBussinesEstado;

        /// <summary>
        /// Objeto que encapsula la lógica de negocio de Empresa.
        /// </summary>
        private BussinesEmpresa miBussinesEmpresa;

        /// <summary>
        /// Objeto que encapsula la lógica de negocio de Factura Venta.
        /// </summary>
        private BussinesFacturaVenta miBussinesFactura;

        private BussinesRetencion miBussinesRetencion;

        private BussinesFacturaProveedor miBussinesFacturaProveedor;

        /// <summary>
        /// Objeto que encapsula la lógica de negocio de Cliente.
        /// </summary>
        private BussinesCliente miBussinesCliente;

        /// <summary>
        /// Objeto que encapsula la lógica de negocio de Producto.
        /// </summary>
        private BussinesProducto miBussinesProducto;

        /// <summary>
        /// Objeto que encapsula la lógica de negocio de Valor de Unidad de Medida.
        /// </summary>
        private BussinesValorUnidadMedida miBussinesMedida;

        /// <summary>
        /// Objeto que encapsula la lógica de negocio de Color.
        /// </summary>
        private BussinesColor miBussinesColor;

        /// <summary>
        /// Objeto que encapsula la lógica de negocio de Descuento.
        /// </summary>
        private BussinesDescuento miBussinesDescuento;

        /// <summary>
        /// Objeto que encapsula la lógica de negocio de Recargo.
        /// </summary>
        private BussinesRecargo miBussinesRecargo;

        private BussinesUsuario miBussinesUsuario;

        private BussinesDian miBussinesDian;

        private BussinesBono miBussinesBono;

        private BussinesSaldo miBussinesSaldo;

        private BussinesInventario miBussinesInventario;

        private BussinesConsecutivo miBussinesConsecutivo;

        private BussinesMarca miBussinesMarca;

        private BussinesPunto miBussinesPunto;

        private BussinesCaracteresEscape miBussinesCaracteresEscape;

        private BussinesBonoRifa miBussinesBonoRifa;

        private BussinesImpuestoBolsa miBussinesImpstoBolsa;

        private BussinesFormaPago miBussinesFormaPago;

        #endregion

        #region Propiedades

        /// <summary>
        /// Representa un objeto para la carga de datos de la Empresa.
        /// </summary>
        private Empresa miEmpresa;

        private RetencionConcepto MiRetencion { set; get; }

        public bool FacturaPos { set; get; }

        private bool FacturaNegativo { set; get; }

        /// <summary>
        /// Representa una tabla de datos en memoria.
        /// </summary>
        private DataTable miTabla;

        /// <summary>
        /// Representa un objeto para la carga de datos de Factura de Venta.
        /// </summary>
        private FacturaVenta miFactura;

        public bool Edicion { set; get; }

        public FacturaVenta Factura { set; get; }

        public DataTable Productos { set; get; }




        /// <summary>
        /// Representa un objeto para la carga de datos de Forma Pago.
        /// </summary>
        private List<DTO.Clases.FormaPago> miFormasPago;

        /// <summary>
        /// Obtiene o establece el valor de la fecha en que se ingresa la factura.
        /// </summary>
        private DateTime FechaHoy;

        /// <summary>
        /// Obtiene o establece el Nit del Cliente.
        /// </summary>
        private string NitCliente;

        /// <summary>
        /// Obtiene o establece el valor de Id del criterio de la Forma de Pago.
        /// </summary>
        private int IdEstado = 0;

        /// <summary>
        /// Obtiene o establece el valor de Id del criterio de descuento o recargo.
        /// </summary>
        private int IdDesctoRecgo = 0;

        /// <summary>
        /// Indica si se realiza un promedio de Facturas de Compra o 
        /// se tiene en cuenta la última, true indica promedio.
        /// </summary>
        private bool Promedio;

        /// <summary>
        /// Obtiene o establece el número de Facturas a promediar.
        /// </summary>
        private int NumeroDeFacturas;

        #endregion

        #region Utilidades

        /// <summary>
        /// Representa una pequeña ventana emergente que muestra una breve explicacion de la funcion del control.
        /// </summary>
        private ToolTip miToolTip;

        /// <summary>
        /// Representa un objeto para mostrar mensajes de error
        /// </summary>
        private ErrorProvider miError;

        /// <summary>
        /// Colección que almacena objetos, en este caso Productos.
        /// </summary>
        private ArrayList ArrayProducto;

        /// <summary>
        /// Objeto para cargar Producto.
        /// </summary>
        private DTO.Clases.Producto MiProducto;

        /// <summary>
        /// Objeto para cargar los datos de la medida del producto consultado.
        /// </summary>
        private ValorUnidadMedida miMedida;

        /// <summary>
        /// Objeto para la carga del talla y color del producto.
        /// </summary>
        private TallaYcolor miTallaYcolor;

        /// <summary>
        /// Representa una variable para realizar conteo.
        /// </summary>
        private int Contador = 0;

        /// <summary>
        /// Objeto que encapsula el origen de datos del DataGrid de Productos.
        /// </summary>
        private BindingSource miBindingSource;


        private CaracteresEscape miCaracteresEscape;

        private Bono miBono;

        #endregion

        #region Validación

        /// <summary>
        /// Objeto que permite el acceso a la validación de datos.
        /// </summary>
        Validacion MiValidacion;

        /// <summary>
        /// Indica que se ha cargado la Talla y el Color desde el Boton Agregar Registro.
        /// </summary>
        private bool LoadColorSize = false;

        /// <summary>
        /// Obtiene o establece el valor que indica si se habilita color o no en el formulario segun la configuración.
        /// </summary>
        private bool EnableColor;

        /// <summary>
        /// Indica si el Producto tiene una sola talla.
        /// </summary>
        private bool SingleSize = false;

        /// <summary>
        /// Indica si el Producto tiene un solo color.
        /// </summary>
        private bool SingleColor = false;

        #endregion

        #region Mensajes

        /// <summary>
        /// Representa el texto: El documento del cliente es requerido.
        /// </summary>
        private string ClienteReq = "El documento del cliente es requerido.";

        /// <summary>
        /// Representa el texto: El número de documento que ingreso tiene formato incorrecto.
        /// </summary>
        private string ClienteFormato = "El número de documento que ingreso tiene formato incorrecto.";

        /// <summary>
        /// Representa el texto: El campo Codigo del Articulo es requerido.
        /// </summary>
        private string CodigoProductoReq = "El campo Codigo del Articulo es requerido.";

        /// <summary>
        /// Representa el texto: El Codigo del Articulo que ingreso tiene formato incorrecto.
        /// </summary>
        private string CodigoProductoFormato = "El Codigo del Articulo que ingreso tiene formato incorrecto.";

        /// <summary>
        /// Representa el texto: El Codigo del Articulo que ingreso no tiene registros en la base de datos.
        /// </summary>
        private string CodigoProductoExiste = "El Codigo del Articulo que ingreso no tiene registros en la base de datos.";

        #endregion

        private bool GraneroJhonRiosucio { set; get; }

        private bool Transfer { set; get; }

        private bool TransferIncBolsa;

        private int NumeroPrecio { set; get; }

        private int PrecioAplicar { set; get; }

        private double DesctoAplica { set; get; }

        private bool RequiereCantidad { set; get; }

        public bool CargaCliente { set; get; }

        public bool CodBarrasCantPeso { set; get; }

        private bool RedondearPrecio2 { set; get; }

        private bool FuncionExpulsaCajon { set; get; }

        private bool FuncionImpoBoslaF11 { set; get; }

        private bool CambioUsuario { set; get; }

        private bool _ConsultaInventario { set; get; }

        private string NameStation { set; get; }


        public const string SuperUsuario = "SUPER_USUARIO";

        public Usuario Usuario_ { set; get; }

        private const int IdEditarPrecio = 48;

        private bool EditarPrecioPermiso;

        private const int IdResetVenta = 49;

        private bool ResetVentaPermiso;

        private int IdPendiente = 3;

        private const int IdSeleccionPendiente = 50;

        private bool SeleccionPendiente;

        private int IdCotizacion = 4;

        private const int IdSeleccionCotizacion = 51;

        private bool SeleccionCotizacion;



        private ImpuestoBolsa ImpstoBolsa;

        private bool DescuentoMarca;


        private int IdTipoInventarioProductoNoFabricado = 1;

        private int IdTipoInventarioProductoFabricado = 3;

        // private const int IdRetiro = 51;

        // private bool RetiroPermiso;


        private bool Ticket_;

        private bool DatosCliente;

        private int IDIVAResponsability = 48;

        private bool ConsecutivoCaja;

        public FrmFacturaPos()
        {
            InitializeComponent();
            try
            {
                this.Transfer = false;
                this.TransferIncBolsa = false;
                NumeroPrecio = 1;
                DesctoAplica = 0.0;
                Edicion = false;
                //RequiereCantidad = false;
                IdRubroRetencion = Convert.ToInt32(AppConfiguracion.ValorSeccion("idrubro_v"));
                miFactura = new FacturaVenta();
                MiRetencion = new RetencionConcepto();
                CargarRetencion();
                //miBussinesFormaPago = new BussinesFormaPago();
                miBussinesEstado = new BussinesEstado();
                miBussinesEmpresa = new BussinesEmpresa();
                miBussinesFactura = new BussinesFacturaVenta();
                miBussinesFacturaProveedor = new BussinesFacturaProveedor();
                miBussinesDescuento = new BussinesDescuento();
                miBussinesRecargo = new BussinesRecargo();
                miBussinesCliente = new BussinesCliente();
                miBussinesProducto = new BussinesProducto();
                miBussinesMedida = new BussinesValorUnidadMedida();
                miBussinesColor = new BussinesColor();
                miBussinesUsuario = new BussinesUsuario();
                miBussinesDian = new BussinesDian();
                miBussinesBono = new BussinesBono();
                miBussinesSaldo = new BussinesSaldo();
                miBussinesInventario = new BussinesInventario();
                miBussinesRetencion = new BussinesRetencion();
                miBussinesConsecutivo = new BussinesConsecutivo();
                miBussinesApertura = new BussinesApertura();

                miBussinesPunto = new BussinesPunto();
                miBussinesCaracteresEscape = new BussinesCaracteresEscape();
                miBussinesBonoRifa = new BussinesBonoRifa();

                miBussinesImpstoBolsa = new BussinesImpuestoBolsa();

                miBussinesFormaPago = new BussinesFormaPago();

                miCaracteresEscape = miBussinesCaracteresEscape.CaracteresPredeterminados();
                miBono = this.miBussinesBonoRifa.BonoRifa();

                CargarEmpresa();
                miFormasPago = new List<DTO.Clases.FormaPago>();
                FechaHoy = DateTime.Now;

                FacturaPos = true;//Convert.ToBoolean(AppConfiguracion.ValorSeccion("facturapos"));
                EnableColor = Convert.ToBoolean(AppConfiguracion.ValorSeccion("color"));
                Promedio = Convert.ToBoolean(AppConfiguracion.ValorSeccion("promedio"));
                NumeroDeFacturas = Convert.ToInt32(AppConfiguracion.ValorSeccion("num_promedio"));
                FacturaNegativo = Convert.ToBoolean(AppConfiguracion.ValorSeccion("fact-negativo"));
                this.GraneroJhonRiosucio = Convert.ToBoolean(AppConfiguracion.ValorSeccion("graneroJhonRiosucio"));
                this.CodBarrasCantPeso = Convert.ToBoolean(AppConfiguracion.ValorSeccion("cod_barras_cant_peso"));
                this.RedondearPrecio2 = Convert.ToBoolean(AppConfiguracion.ValorSeccion("redondeo_precio_dos"));
                this.FuncionExpulsaCajon = Convert.ToBoolean(AppConfiguracion.ValorSeccion("activa_funcion_expulsa_cajon"));
                this.FuncionImpoBoslaF11 = Convert.ToBoolean(AppConfiguracion.ValorSeccion("f_11_impsto_bolsa"));
                this.CambioUsuario = Convert.ToBoolean(AppConfiguracion.ValorSeccion("permitir_cambio_usuario"));
                _ConsultaInventario = Convert.ToBoolean(AppConfiguracion.ValorSeccion("frm_consulta_inventario"));

                Ticket_ = Convert.ToBoolean(AppConfiguracion.ValorSeccion("ticket"));
                DatosCliente = Convert.ToBoolean(AppConfiguracion.ValorSeccion("datos_cliente"));//txt_valor_unitario
                txtValorUnitario.Visible = Convert.ToBoolean(AppConfiguracion.ValorSeccion("txt_valor_unitario"));
                NameStation = AppConfiguracion.ValorSeccion("station_name");
                ConsecutivoCaja = Convert.ToBoolean(AppConfiguracion.ValorSeccion("consecutivo_caja"));

                miTallaYcolor = new TallaYcolor();
                MiValidacion = new Validacion();
                miError = new ErrorProvider();
                miToolTip = new ToolTip();

                ImpstoBolsa = miBussinesImpstoBolsa.ImpuestoBolsa(1);
                ImpstoBolsa.Cantidad = 0;

                //Convert.ToBoolean(AppConfiguracion.ValorSeccion("color"));
                miBindingSource = new BindingSource();
                CrearDataTable();

                this.miBussinesMarca = new BussinesMarca();
                this.DescuentoMarca = false;
                if (this.miBussinesMarca.MarcaDescuentos().Rows.Count > 0)
                {
                    this.DescuentoMarca = true;
                }
            }
            catch (Exception ex)
            {
                OptionPane.MessageInformation(ex.Message);
            }

            //ObtenerNumero();
        }

        private void FrmFacturaVenta_Load(object sender, EventArgs e)
        {
            try
            {
                int menosWidth = 60;
                /*this.txtCodigoArticulo.Width -= menosWidth;
                this.lblCantidad.Location =
                    new Point(this.lblCantidad.Location.X - menosWidth, this.lblCantidad.Location.Y);
                this.txtCantidad.Location =
                    new Point(this.txtCantidad.Location.X - menosWidth, this.txtCantidad.Location.Y);
                this.txtValorUnitario.Location =
                    new Point(this.txtValorUnitario.Location.X - menosWidth, this.txtValorUnitario.Location.Y);
                */

                /**
                this.panelProducto.Width -= panelPrecioProducto.Width;
                this.panelPrecioProducto.Location =
                    new Point(this.panelPrecioProducto.Location.X - panelPrecioProducto.Width, this.panelPrecioProducto.Location.Y);

                this.txtTotal.Width -= menosWidth;
                this.gbTotal.Width -= menosWidth;
                this.gbTotal.Location =
                    new Point(this.gbTotal.Location.X - panelPrecioProducto.Width, this.gbTotal.Location.Y);

                this.Valor.Visible = false;
                */
                

                miFactura.Usuario = Administracion.Usuario.FrmIniciarSesion.CargarDatosUsuario(this);

                this.EditarPrecioPermiso = false;
                this.ResetVentaPermiso = false;
                this.SeleccionPendiente = false;
                this.SeleccionCotizacion = false;
                foreach (var ps in Usuario_.Permisos)
                {
                    switch (ps.IdPermiso)
                    {
                        case IdEditarPrecio:
                            {
                                this.EditarPrecioPermiso = true;
                                break;
                            }
                        case IdResetVenta:
                            {
                                this.ResetVentaPermiso = true;
                                break;
                            }
                        case IdSeleccionPendiente:
                            {
                                this.SeleccionPendiente = true;
                                break;
                            }
                        case IdSeleccionCotizacion:
                            {
                                this.SeleccionCotizacion = true;
                                break;
                            }
                    }
                }

                //this.btnCruce.Visible = Convert.ToBoolean(AppConfiguracion.ValorSeccion("update_cruce"));
                //ObtenerNumero();
                NitCliente = txtCliente.Text;
                lblDataFecha.Text = FechaHoy.Day + " de " + UseDate.MesCorto(FechaHoy.Month) + " de " + FechaHoy.Year;
                CargarUtilidades();
                CargarCliente(txtCliente.Text);
                ValidarRetencion();
                CompletaEventos.Completa += new CompletaEventos.CompletaAccion(CompletaEventos_Completo);
                //CompletaEventos.Completam += new CompletaEventos.CompletaAccionm(CompletaEventosm_Completo);
                CompletaEventos.CompletaVenta += new CompletaEventos.CompletaAccionVenta(CompletaEventosVenta_Completo);
                CompletaEventos.CompTProductoFact += new CompletaEventos.ComAxTransferProductFact(CompletaEventos_CompTProductoFact);
                CompletaEventos.Completaz += new CompletaEventos.CompletaAccionz(CompletaEventos_Completaz);
                dgvListaArticulos.AutoGenerateColumns = false;
                dgvListaArticulos.DataSource = miBindingSource;
                //if (FacturaPos)
                //{
                OcultarDescuento();
                //}
                if (Edicion)
                {
                    CargarFacturaEdicion();
                }
                if (CargaCliente)
                {
                    this.txtCliente.Text = "1000";
                    this.txtCliente_KeyPress(this.txtCliente, new KeyPressEventArgs((char)Keys.Enter));
                }
               
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
        }

        private void FrmFacturaVenta_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Shift && e.KeyCode == Keys.F2)
            {
                //OptionPane.MessageInformation("si");
                var frmConversion = new Inventario.Conversion.FrmConversion();
                frmConversion.ShowDialog();
            }
            else
            {
                if (e.Shift && e.KeyCode == Keys.F3)
                {
                    var frmImpuesto = new FrmImpuestoBolsa();
                    this.TransferIncBolsa = true;
                    frmImpuesto.ShowDialog();
                }
                else
                {
                    if (e.Shift && e.KeyCode == Keys.F11)
                    {
                        if (this.FuncionExpulsaCajon)
                        {
                            this.ExpulsarCajonMonedero();
                        }
                    }
                    else
                    {
                        if (e.Shift && e.KeyCode == Keys.F12)
                        {
                            PrintPosCopy(miFactura.Id);
                            //var id_ = miFactura.Id;
                        }
                        else
                        {
                            switch (e.KeyData)
                            {

                                case Keys.F2:
                                    {
                                        var frmPrecio = new EditarPrecio.FrmConsultaPrecio();
                                        frmPrecio.ShowDialog();
                                        //btnBuscarCliente_Click(this.btnBuscarCliente, new EventArgs());
                                        break;
                                    }
                                case Keys.F3:
                                    {
                                        ConsultaInventario();
                                        break;
                                    }
                                case Keys.F4:
                                    {
                                        tsBtnModoCantidad_Click(this.tsBtnModoCantidad, new EventArgs());
                                        break;
                                    }
                                case Keys.F5:
                                    {
                                        //ActivarDescuento();
                                        var frmCanje = new Devolucion.FrmCanjeArticulo();
                                        frmCanje.ShowDialog();
                                        break;
                                    }
                                case Keys.F6:
                                    {
                                        this.tsCambiarPrecio_Click(this.tsCambiarPrecio, new EventArgs());
                                        break;
                                    }
                                case Keys.F7:
                                    {
                                        this.tsBtnFormularioVenta_Click(this.tsBtnFormularioVenta, new EventArgs());
                                        break;
                                    }
                                case Keys.F8:
                                    {
                                        RealizarVenta();
                                        break;
                                    }
                                case Keys.F9:
                                    {
                                        RetiroDeProducto();
                                        break;
                                    }
                                case Keys.F10:
                                    {
                                        this.tsBtnReset_Click(this.tsBtnReset, new EventArgs());
                                        break;
                                    }
                                case Keys.F11:
                                    {
                                        if (this.FuncionImpoBoslaF11)
                                        {
                                            this.ImpstoBolsa.Cantidad++; // ojo revisar que se esta duplicando la cantidad.
                                            this.txtIcoBolsaCant.Text = this.ImpstoBolsa.Cantidad.ToString();
                                            this.txtIcoBolsaUnit.Text = this.ImpstoBolsa.Valor.ToString();
                                            this.txtIcoBolsaTotal.Text = UseObject.InsertSeparatorMil(
                                                (this.ImpstoBolsa.Cantidad * this.ImpstoBolsa.Valor).ToString());
                                            this.CalcularTotal();
                                        }
                                        else
                                        {
                                            if (this.FuncionExpulsaCajon)
                                            {
                                                this.ExpulsarCajonMonedero();
                                            }
                                        }

                                        
                                        /* if (this.FuncionExpulsaCajon)
                                         {
                                             this.ExpulsarCajonMonedero();
                                         }*/
                                        try
                                        {
                                            /*Ticket ticket = new Ticket();
                                            ticket.AddFooterLine(".");
                                            ticket.PrintTicket("IMPREPOS");*/

                                            /*System.Drawing.Printing.PrintDocument pr = new System.Drawing.Printing.PrintDocument();
                                            pr.PrinterSettings = new System.Drawing.Printing.PrinterSettings();
                                            pr.PrinterSettings.PrinterName = "";
                                            RawPrinterHelper.SendStringToPrinter*/
                                        }
                                        catch (Exception ex)
                                        {
                                            OptionPane.MessageError(ex.Message);
                                        }
                                        break;
                                    }
                                case Keys.F12:
                                    {
                                        RetiroDeCaja();
                                        break;
                                    }
                                case Keys.Escape:
                                    {
                                        this.Close();
                                        break;
                                    }
                            }
                        }
                    }
                }
            }
        }

        private void FrmFacturaVenta_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.dgvListaArticulos.RowCount != 0)  // Grid con articulo
            {
                OptionPane.MessageInformation("No se puede cerrar el formulario, ya que tiene productos cargados.");
                e.Cancel = true;
            }
            else  // Grid Vacio
            {
                DialogResult rta = MessageBox.Show("¿Está seguro(a) de querer salir?", "Factura Venta",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (rta.Equals(DialogResult.Yes))
                {
                    e.Cancel = false;
                }
                else
                {
                    e.Cancel = true;
                }
            }
            /*DialogResult rta = MessageBox.Show("Está a punto de salir.\n¿Desea guardar los cambios?", "Factura Venta",
                MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);
            if (rta.Equals(DialogResult.Yes))
            {
                e.Cancel = true;
                this.FrmFacturaVenta_KeyDown(this, new KeyEventArgs(Keys.F6));
            }
            else
            {
                if (rta.Equals(DialogResult.Cancel))
                {
                    e.Cancel = true;
                }
                else
                {
                    if (rta.Equals(DialogResult.No))
                    {
                        ResetFactura();
                        //this.Dispose();
                    }
                }
            }*/
        }
        private bool contado = true;
        private void tsCbContado_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (IdEstado.Equals(4) && dgvListaArticulos.RowCount > 0)
            {
                OptionPane.MessageInformation("Debe eliminar todos los Artículos del la factura para cambiar el tipo.");
                cbContado.SelectedValue = 4;
            }
            else
            {
                IdEstado = Convert.ToInt32(((DataRowView)cbContado.SelectedItem)["idestado"]);
                if (IdEstado != 2)//contado
                {
                    contado = true;
                    lblFecha.Text = "Fecha";
                    lblDataFecha.Visible = true;
                    dtpFechaLimite.Value = DateTime.Today;
                    dtpFechaLimite.Visible = false;
                    if (IdEstado == 1)
                    {
                        lblInfoEstado.Text = "Factura a Contado.";
                    }
                    else
                    {
                        if (IdEstado == 3)
                        {
                            lblInfoEstado.Text = "Factura Pendiente.";
                        }
                        else
                        {
                            lblInfoEstado.Text = "Cotización.";

                        }
                    }
                    if (chkAntigua.Checked)
                    {
                        lblDataFecha.Visible = false;
                        dtpFechaLimite.Visible = true;
                        lblFechaLimite.Visible = true;
                        dtpLimite.Visible = true;
                    }
                    else
                    {
                        lblDataFecha.Visible = true;
                        dtpFechaLimite.Visible = false;
                        lblFechaLimite.Visible = false;
                        dtpLimite.Visible = false;
                    }
                }
                else   //Credito
                {
                    lblInfoEstado.Text = "Factura a Crédito.";
                    contado = true;
                    lblFecha.Text = "Limite";
                    lblDataFecha.Visible = false;
                    dtpFechaLimite.Visible = true;
                    if (chkAntigua.Checked)
                    {
                        lblFecha.Text = "Fecha";
                        lblFechaLimite.Visible = true;
                        dtpLimite.Visible = true;
                    }
                    else
                    {
                        lblFechaLimite.Visible = false;
                        dtpLimite.Visible = false;
                    }
                }
            }
        }

        private void tsCbDesctoRecargo_SelectedIndexChanged(object sender, EventArgs e)
        {
            rbtnDesctoFactura.Checked = true;
            if (dgvListaArticulos.RowCount == 0)
            {
                IdDesctoRecgo = ((Inventario.Producto.Criterio)cbDesctoRecargo.SelectedItem).Id;
                if (IdDesctoRecgo == 1 || IdDesctoRecgo == 0)
                {
                    lblDescuentoFactura.Text = "Descto/Fact";
                    //lblDesctoProducto.Text = "Descto%";
                    miToolTip.SetToolTip(rbtnDesctoProducto, "Aplicar descuento por Producto.");
                    miToolTip.SetToolTip(pbProducto, "Aplicar descuento por Producto.");
                    miToolTip.SetToolTip(rbtnDesctoFactura, "Aplicar descuento por Factura.");
                    miToolTip.SetToolTip(pbFactura, "Aplicar descuento por Factura.");
                    if (cbRecargoProducto.Visible)
                    {
                        dgvListaArticulos.Columns["ValorMenosDescto"].Width = ValorMenosDescto.Width - 1;
                    }
                    dgvListaArticulos.Columns["Descuento"].HeaderText = "Descto";
                    dgvListaArticulos.Columns["ValorMenosDescto"].HeaderText = "Valor - Descto";
                    //cbDescuentoProducto.Visible = true;
                    //  cbRecargoProducto.Visible = false;
                    rbtnDesctoFactura.Enabled = true;
                    rbtnDesctoProducto.Enabled = true;
                    txtDescuentoFactura.Enabled = true;
                }
                else
                {
                    if (IdDesctoRecgo == 2)
                    {
                        lblDescuentoFactura.Text = "Recargo/Fact";
                        ///lblDesctoProducto.Text = "Recargo%";
                        miToolTip.SetToolTip(rbtnDesctoProducto, "Aplicar recargo por Producto.");
                        miToolTip.SetToolTip(pbProducto, "Aplicar recargo por Producto.");
                        miToolTip.SetToolTip(rbtnDesctoFactura, "Aplicar recargo por Factura.");
                        miToolTip.SetToolTip(pbFactura, "Aplicar recargo por Factura.");
                        dgvListaArticulos.Columns["ValorMenosDescto"].Width = ValorMenosDescto.Width + 1;
                        dgvListaArticulos.Columns["Descuento"].HeaderText = "Recgo";
                        dgvListaArticulos.Columns["ValorMenosDescto"].HeaderText = "Valor + Recgo";
                        //cbDescuentoProducto.Visible = false;
                        //cbRecargoProducto.Visible = true;
                        rbtnDesctoFactura.Enabled = true;
                        rbtnDesctoProducto.Enabled = true;
                        txtDescuentoFactura.Enabled = true;
                    }
                    /*else
                    {
                        rbtnDesctoFactura.Enabled = false;
                        rbtnDesctoProducto.Enabled = false;
                        txtDescuentoFactura.Enabled = false;
                    }*/
                }
                if (IdDesctoRecgo.Equals(0))
                {
                    rbtnDesctoFactura.Enabled = false;
                    rbtnDesctoProducto.Enabled = false;
                    txtDescuentoFactura.Enabled = false;
                }
                //CargarDescuentosORecargos();
            }
            else
            {
                if (MsnDescto)
                {
                    OptionPane.MessageInformation
                            ("Este cambio no se puede realizar debido a que hay registros en la factura.");
                    MsnDescto = false;
                }
                cbDesctoRecargo.SelectedValue = IdDesctoRecgo;
            }
            MsnDescto = true;
        }

        private void tsBtnModoCantidad_Click(object sender, EventArgs e)
        {
            if (dgvListaArticulos.RowCount != 0)
            {
                dgvListaArticulos.Columns["Cantidad"].ReadOnly = false;
                dgvListaArticulos.Columns["TotalMasIva"].ReadOnly = true;
                txtCodigoArticulo.Focus();
                dgvListaArticulos.Focus();
                dgvListaArticulos.EditMode = DataGridViewEditMode.EditOnEnter;
                dgvListaArticulos.BeginEdit(true);
            }
            else
            {
                OptionPane.MessageInformation("No hay registros para editar.");
            }
        }

        private void tsCambiarPrecio_Click(object sender, EventArgs e)
        {
            if (dgvListaArticulos.RowCount != 0)
            {
                if (this.EditarPrecioPermiso)
                {
                    dgvListaArticulos.Columns["Cantidad"].ReadOnly = true;
                    dgvListaArticulos.Columns["TotalMasIva"].ReadOnly = false;
                    txtCodigoArticulo.Focus();
                    dgvListaArticulos.Focus();
                    dgvListaArticulos.EditMode = DataGridViewEditMode.EditOnEnter;
                    dgvListaArticulos.BeginEdit(true);
                }
                else
                {
                    var admin = false;
                    while (!admin)
                    {
                        string rta = CustomControl.OptionPane.LoginUserPassword();
                        if (!rta.Equals("false"))
                        {
                            try
                            {
                                // validar usuario y contraseña incorrectos - si existe o no.
                                // validar si el usuario tiene permisos o no
                                // si tiene permisos continua el proceso.
                                string[] data = rta.Split('&');
                                var userTemp =
                                    this.miBussinesUsuario.Usuario_(new Usuario { Usuario_ = data[0], Contrasenia = Encode.Encrypt(data[1]) });
                                if (userTemp.Id != 0)
                                {
                                    if (userTemp.Permisos.Where(ps => ps.IdPermiso.Equals(IdEditarPrecio)).Count() > 0)
                                    {
                                        dgvListaArticulos.Columns["Cantidad"].ReadOnly = true;
                                        dgvListaArticulos.Columns["TotalMasIva"].ReadOnly = false;
                                        txtCodigoArticulo.Focus();
                                        dgvListaArticulos.Focus();
                                        dgvListaArticulos.EditMode = DataGridViewEditMode.EditOnEnter;
                                        dgvListaArticulos.BeginEdit(true);
                                        admin = true;
                                    }
                                    else
                                    {
                                        MessageBox.Show("El usuario no tiene permisos para esta acción.", "Factura venta",
                                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                                        admin = false;
                                    }
                                }
                                else
                                {
                                    MessageBox.Show
                                        ("Usuario o contraseña incorrecta.", "Factura venta", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    admin = false;
                                }
                            }
                            catch (Exception ex)
                            {
                                OptionPane.MessageError(ex.Message);
                                admin = false;
                            }
                        }
                        else
                        {
                            admin = true;
                        }
                    }
                }
            }
            else
            {
                OptionPane.MessageInformation("No hay registros para editar.");
            }
        }

        private void tsBtnDevolucion_Click(object sender, EventArgs e)
        {
            var frmCanje = new Devolucion.FrmCanjeArticulo();
            frmCanje.ShowDialog();
        }

        private void tsBtnFormularioVenta_Click(object sender, EventArgs e)
        {
            var frmVenta = new FrmFacturaVenta();
            frmVenta.Usuario_ = this.Usuario_;
            frmVenta.FacturaPos = true;
            frmVenta.CargaCliente = this.CargaCliente;
            frmVenta.ShowDialog();
        }

        private void tsRealizarVenta_Click(object sender, EventArgs e)
        {
            RealizarVenta();
        }

        private void tsBtnRetiro_Click(object sender, EventArgs e)
        {
            RetiroDeProducto();
        }

        private void tsBtnReset_Click(object sender, EventArgs e)
        {
            if (this.ResetVentaPermiso)
            {
                DialogResult rta = MessageBox.Show("¿Está seguro(a) de reiniciar la venta?", "Factura de Venta",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (rta.Equals(DialogResult.Yes))
                {
                    ResetFactura();
                }
            }
            else
            {
                var admin = false;
                while (!admin)
                {
                    string rta = CustomControl.OptionPane.LoginUserPassword();
                    if (!rta.Equals("false"))
                    {
                        try
                        {
                            string[] data = rta.Split('&');
                            var userTemp =
                                this.miBussinesUsuario.Usuario_
                                (new Usuario { Usuario_ = data[0], Contrasenia = Encode.Encrypt(data[1]) });
                            if (userTemp.Id != 0)
                            {
                                if (userTemp.Permisos.Where(ps => ps.IdPermiso.Equals(IdResetVenta)).Count() > 0)
                                {
                                    DialogResult rta_ = MessageBox.Show("¿Está seguro(a) de reiniciar la venta?", "Factura de Venta",
                                        MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                                    if (rta_.Equals(DialogResult.Yes))
                                    {
                                        ResetFactura();
                                        admin = true;
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("El usuario no tiene permisos para esta acción.", "Factura venta",
                                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    admin = false;
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            OptionPane.MessageError(ex.Message);
                            admin = false;
                        }
                    }
                    else
                    {
                        admin = true;
                    }
                }
            }


            /*DialogResult rta = MessageBox.Show("¿Está seguro(a) de reiniciar la venta?", "Factura de Venta",
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (rta.Equals(DialogResult.Yes))
            {
                ResetFactura();
            }*/

            /* string rta = CustomControl.OptionPane.OptionBox
                 ("Ingresar contraseña de Administrador .", "Administrador", CustomControl.OptionPane.Icon.LoginAdmin);
             if (!rta.Equals("false"))
             {
                 var admin = false;
                 try
                 {
                     admin = miBussinesUsuario.VerificarUsuarioAdmin(Encode.Encrypt(rta));
                 }
                 catch (Exception ex)
                 {
                     OptionPane.MessageError(ex.Message);
                     admin = false;
                 }
                 if (admin)
                 {
                     ResetFactura();
                     try
                     {
                         //miBussinesFactura.EliminarRetornoTemporal();
                     }
                     catch (Exception ex)
                     {
                         OptionPane.MessageError(ex.Message);
                     }
                 }
                 else
                 {
                     MessageBox.Show("La contraseña es Incorrecta.", "Factura Venta",
                             MessageBoxButtons.OK, MessageBoxIcon.Error);
                 }
             }*/
            /*DialogResult rta = MessageBox.Show("¿Está seguro(a) de reiniciar la venta?", "Factura Venta",
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (rta.Equals(DialogResult.Yes))
            {
                ResetFactura();
            }*/
        }

        private void tsBtnSalida_Click(object sender, EventArgs e)
        {
            RetiroDeCaja();
        }

        private void tsBtnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
            //printForm1.Print();
        }

        private bool MsnDescto = true;
        private void txtCliente_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                if (ValidarCodigoCliente())
                {
                    if (ExisteCliente())
                    {
                        /*try
                        {*/
                        /*cliente = miBussinesCliente.ClienteAEditar(txtCliente.Text);
                        txtNombreCliente.Text = cliente.NitCliente + " - " + cliente.NombresCliente;
                        NitCliente = cliente.NitCliente;*/
                        CargarCliente(txtCliente.Text);
                        ValidarRetencion();
                        RecargarRetencion();
                        txtCodigoArticulo.Focus();
                        ClienteMatch = true;

                        /*}
                        catch (Exception ex)
                        {
                            OptionPane.MessageError(ex.Message);
                        }*/
                    }
                    else
                    {
                        DialogResult rta = MessageBox.Show("El cliente que ingreso no existe.\n¿Desea Crearlo?",
                            "Factura Venta", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                        if (rta.Equals(DialogResult.Yes))
                        {
                            //txtCodigoArticulo.Focus();
                            if (!ExtendForms)
                            {
                                var frmCliente = new Cliente.frmCliente();
                                frmCliente.MdiParent = this.MdiParent;
                                frmCliente.FacturaVenta = true;
                                frmCliente.txtNit.Text = txtCliente.Text;
                                ClienteMatch = true;
                                frmCliente.Show();
                                ExtendForms = true;
                                frmCliente.txtNombres.Focus();
                            }
                        }
                    }
                }
            }
            else
            {
            }
        }

        private void txtCliente_Validating(object sender, CancelEventArgs e)
        {
            if (!ClienteMatch)
            {
                //ClienteMatch = true;
                txtCliente_KeyPress(txtCliente, new KeyPressEventArgs((char)Keys.Enter));
            }
        }
        private bool ExtendForms = false;
        private void btnBuscarCliente_Click(object sender, EventArgs e)
        {
            if (!ExtendForms)
            {
                var frmCliente = new Cliente.frmCliente();
                //frmCliente.MdiParent = this.MdiParent;
                frmCliente.tcClientes.SelectedIndex = 1;
                frmCliente.FacturaVenta = true;
                ClienteMatch = true;
                ExtendForms = true;
                
                frmCliente.ShowDialog();
                frmCliente.txtNit.Focus();
                this.txtCodigoArticulo.Focus();
            }
        }

        private void rbtnDesctoProducto_Click(object sender, EventArgs e)
        {
            if (dgvListaArticulos.RowCount == 0)
            {
                if (IdDesctoRecgo == 1)
                {
                    txtDescuentoFactura.Enabled = false;
                    cbDescuentoProducto.Enabled = true;
                    cbRecargoProducto.Enabled = false;
                }
                else
                {
                    txtDescuentoFactura.Enabled = false;
                    cbDescuentoProducto.Enabled = false;
                    cbRecargoProducto.Enabled = true;
                }
                CargarDescuentosORecargos();
            }
            else
            {
                rbtnDesctoFactura.Checked = true;
                OptionPane.MessageInformation
                            ("Este cambio no se puede realizar debido a que hay registros en la factura.");
            }
        }

        private void rbtnDesctoFactura_Click(object sender, EventArgs e)
        {
            if (dgvListaArticulos.RowCount == 0)
            {
                if (IdDesctoRecgo == 1)
                {
                    txtDescuentoFactura.Enabled = true;
                    cbDescuentoProducto.Enabled = false;
                    cbRecargoProducto.Enabled = false;
                }
                else
                {
                    txtDescuentoFactura.Enabled = true;
                    cbDescuentoProducto.Enabled = false;
                    cbRecargoProducto.Enabled = false;
                }
            }
            else
            {
                rbtnDesctoProducto.Checked = true;
                OptionPane.MessageInformation
                            ("Este cambio no se puede realizar debido a que hay registros en la factura.");
            }
        }

        private void txtCodigoArticulo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                if (!String.IsNullOrEmpty(this.txtCodigoArticulo.Text))
                {
                    if (this.CodigoOrString())
                    {
                        if (Convert.ToInt64(this.txtCodigoArticulo.Text) < 0)
                        {
                            if (this.CodigoValido((Convert.ToInt64(this.txtCodigoArticulo.Text) * -1).ToString(), 13))
                            {
                                String[] subString = new string[2];
                                if (this.CodBarrasCantPeso)
                                {
                                    subString = UseObject.MiSubString(this.txtCodigoArticulo.Text, 3, 7);
                                    this.txtCantidad.Text = subString[1];
                                }
                                else
                                {
                                    subString = UseObject.MiSubStringPrice(this.txtCodigoArticulo.Text, 1, 7);
                                }
                                if (this.ExisteProducto(subString[0]))
                                {
                                    if (this.CodBarrasCantPeso)
                                    {
                                        if (this.CargarProducto(subString[0]))
                                        {
                                            if (this.RequiereCantidad)
                                            {
                                                this.txtCantidad.Focus();
                                            }
                                            else
                                            {
                                                this.CargarColorOconsulta();
                                            }
                                        }
                                    }
                                    else
                                    {
                                        if (this.CargarProducto(subString[0], Convert.ToInt32(subString[1])))
                                        {
                                            if (this.RequiereCantidad)
                                            {
                                                this.txtCantidad.Focus();
                                            }
                                            else
                                            {
                                                this.CargarColorOconsulta();
                                            }
                                        }
                                    }
                                }
                                else
                                {
                                    OptionPane.MessageInformation("El producto no existe.");
                                }
                            }
                            else
                            {
                                OptionPane.MessageInformation("El código no es valido.");
                            }
                        }
                        else
                        {
                            if (ExisteProducto(txtCodigoArticulo.Text))
                            {
                                if (CargarProducto())
                                {
                                    if (RequiereCantidad)
                                    {
                                        txtCantidad.Focus();
                                    }
                                    else
                                    {
                                        CargarColorOconsulta();
                                    }


                                    //CargarDescuentosORecargos();
                                    /* if (cbDescuentoProducto.Enabled)
                                     {
                                         cbDescuentoProducto.Focus();
                                     }
                                     else
                                     {
                                         if (cbRecargoProducto.Enabled)
                                         {
                                             cbRecargoProducto.Focus();
                                         }
                                         else
                                         {
                                             if (MiProducto.AplicaTalla || MiProducto.AplicaColor)
                                             {
                                                 if (RequiereCantidad)
                                                 {
                                                     txtCantidad.Focus();
                                                     txtCantidad.SelectAll();
                                                     return;
                                                 }
                                                 else
                                                 {
                                                     if (!SingleSize || !SingleColor)
                                                     {
                                                         btnTallaYcolor_Click(this.btnTallaYcolor, new EventArgs());
                                                     }
                                                     else
                                                     {
                                                         EstructurarConsulta();
                                                         return;
                                                     }
                                                 }*/

                                    // Codificación anterior...
                                    /*if (!SingleSize || !SingleColor)
                                    {
                                        btnTallaYcolor_Click(this.btnTallaYcolor, new EventArgs());
                                    }
                                    else
                                    {
                                        EstructurarConsulta();
                                        return;
                                    }*/
                                    //btnTallaYcolor.Focus();



                                    //}
                                    // }
                                    //}
                                    /*if (!cbDescuentoProducto.Enabled && !cbRecargoProducto.Enabled && !btnTallaYcolor.Enabled)
                                    {
                                        if (RequiereCantidad)
                                        {
                                            txtCantidad.Focus();
                                            txtCantidad.SelectAll();
                                            return;
                                        }
                                        else
                                        {
                                            EstructurarConsulta();
                                        }*/
                                    //FrmFacturaVenta_KeyDown(this, new KeyEventArgs(Keys.F12));
                                    //}
                                    /* if (MiProducto.AplicaTalla || MiProducto.AplicaColor)
                                     {
                                         if ((MiProducto.AplicaTalla && miTallaYcolor.IdTalla == 0) ||
                                             (MiProducto.AplicaColor && miTallaYcolor.IdColor == 0))
                                         {
                                             LoadColorSize = true;
                                             btnTallaYcolor_Click(this.btnTallaYcolor, new EventArgs());
                                             return;
                                         }
                                         else
                                         {
                                             LoadColorSize = false;
                                             EstructurarConsulta();
                                         }
                                     }*/
                                    //EstructurarConsulta();
                                }
                            }
                            else
                            {
                                DialogResult rta = MessageBox.Show("El Producto no existe.\n¿Desea Crearlo?",
                                        "Factura Venta", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                                if (rta.Equals(DialogResult.Yes))
                                {
                                    if (!ExtendForms)
                                    {
                                        //derechos de administrador.
                                        var formProducto = new Inventario.Producto.FrmIngresarProducto();
                                        formProducto.MdiParent = this.MdiParent;
                                        formProducto.Extencion = true;
                                        formProducto.Fact = true;
                                        ExtendForms = true;
                                        formProducto.Show();
                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        if (!ExtendForms)
                        {
                            //derechos de administrador.
                            /*var formProducto = new Inventario.Producto.FrmIngresarProducto();
                            formProducto.MdiParent = this.MdiParent;
                            formProducto.Extencion = true;
                            formProducto.Fact = true;
                            formProducto.tabControlProducto.SelectedIndex = 1;
                            formProducto.txtConsulta.Text = txtCodigoArticulo.Text;
                            formProducto.SearchFactura = true;
                            ExtendForms = true;
                            formProducto.Show();*/
                            if (_ConsultaInventario)
                            {
                                var formInventario = new Inventario.Consulta.FrmConsultaInventario();
                                formInventario.MdiParent = this.MdiParent;
                                formInventario.ExtendVenta = true;
                                formInventario.ExtendForms_ = true;

                                formInventario.IdTipoInventarioNoFabricado = IdTipoInventarioProductoNoFabricado;
                                formInventario.IdTipoInventarioFabricado = IdTipoInventarioProductoFabricado;

                                formInventario.txtCodigoNombre.Text = txtCodigoArticulo.Text;
                                ExtendForms = true;
                                this.Transfer = true;
                                formInventario.Show();
                                formInventario.dgvInventario.Focus();
                                formInventario.ColorearGrid();
                            }
                            else
                            {
                                var formInventario = new Inventario.Consulta.FrmInventario();
                                formInventario.MdiParent = this.MdiParent;
                                formInventario.ExtendVenta = true;
                                formInventario.ExtendForms_ = true;
                                formInventario.txtCodigoNombre.Text = txtCodigoArticulo.Text;
                                ExtendForms = true;
                                Transfer = true;
                                formInventario.Show();
                                formInventario.ColorearGrid();
                            }
                        }
                    }
                }
            }
        }

        private void txtCantidad_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                if (String.IsNullOrEmpty(txtCantidad.Text))
                {
                    txtCantidad.Text = "1";
                }
                if (ValidarCantidad(txtCantidad.Text))
                {
                    //var cant_ = Convert.ToDouble(txtCantidad.Text);
                    if (!Convert.ToDouble(txtCantidad.Text).Equals(0))
                    {
                        miError.SetError(txtCantidad, null);

                        if (txtValorUnitario.Visible)
                        {
                            if (MiProducto != null)
                            {
                                txtValorUnitario.Focus();
                            }
                            else
                            {
                                txtCodigoArticulo.Focus();
                            }
                        }
                        else
                        {
                            if (MiProducto != null)
                            {
                                CargarColorOconsulta();
                            }
                            else
                            {
                                txtCodigoArticulo.Focus();
                            }
                        }

                        
                        /*if (MiProducto != null)
                        {
                            CargarColorOconsulta();
                        }
                        else
                        {
                            txtCodigoArticulo.Focus();
                        }
                        */
                    }
                    else
                    {
                        miError.SetError(txtCantidad, "La cantidad debe ser diferente de cero.");
                        txtCantidad.Focus();
                    }
                }
                else
                {
                    miError.SetError(txtCantidad, "La cantidad que ingreso tiene formato incorrecto.");
                    txtCantidad.Focus();
                }


                /* 
                 if (String.IsNullOrEmpty(txtCantidad.Text))
                 {
                     txtCantidad.Text = "1";
                     if (RequiereCantidad)
                     {
                         if (MiProducto != null)
                         {
                             CargarColorOconsulta();
                             txtCodigoArticulo.Focus();
                         }
                         else
                         {
                             txtCodigoArticulo.Focus();
                         }
                     }
                     else
                     {
                         txtCodigoArticulo.Focus();
                     }
                     //txtCodigoArticulo.Focus();
                 }
                 else
                 {
                     /*if (Validacion.ConFormato
                         (Validacion.TipoValidacion.NumerosYPunto, txtCantidad, miError, "La cantidad que ingreso tiene formato incorrecto."))*/
                /*if(ValidarCantidad(txtCantidad.Text))
                {
                    miError.SetError(txtCantidad, null);
                    if (Convert.ToDouble(txtCantidad.Text).Equals(0))
                    {
                        txtCantidad.Text = "1";
                    }
                    if (RequiereCantidad)
                    {
                        if (MiProducto != null)
                        {
                            if (cbDescuentoProducto.Visible || cbRecargoProducto.Visible)
                            {
                            }
                            else
                            {
                            }
                            CargarColorOconsulta();
                            txtCodigoArticulo.Focus();
                        }
                        else
                        {
                            txtCodigoArticulo.Focus();
                        }
                    }
                    else
                    {
                        txtCodigoArticulo.Focus();
                    }
                    //txtCodigoArticulo.Focus();
                }
                else
                {
                    miError.SetError(txtCantidad, "La cantidad que ingreso tiene formato incorrecto.");
                    txtCantidad.Focus();
                }
            }
            */
            }
        }

        private void txtCantidad_Validating(object sender, CancelEventArgs e)
        {
            /*if (String.IsNullOrEmpty(txtCantidad.Text))
            {
                txtCantidad.Text = "1";
            }
            else
            {
                if (Validacion.ConFormato
                        (Validacion.TipoValidacion.NumerosYPunto, txtCantidad, miError, "La cantidad que ingreso tiene formato incorrecto."))
                {
                    if (Convert.ToDouble(txtCantidad.Text).Equals(0))
                    {
                        txtCantidad.Text = "1";
                    }
                    txtCodigoArticulo.Focus();
                }
                else
                {
                    txtCantidad.Focus();
                }
            }*/
        }

        private void txtCodigoArticulo_Validating(object sender, CancelEventArgs e)
        {

        }

        private void txtValorUnitario_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                if (String.IsNullOrEmpty(txtValorUnitario.Text))
                {
                    txtValorUnitario.Text = "0";
                }

                if (ValidarCantidad(UseObject.RemoveSeparatorMil(txtValorUnitario.Text).ToString()))
                {
                    if (!UseObject.RemoveSeparatorMil(txtValorUnitario.Text).Equals(0))
                    {
                        miError.SetError(txtValorUnitario, null);
                        if (MiProducto != null)
                        {
                            CargarColorOconsulta();
                        }
                        else
                        {
                            txtCodigoArticulo.Focus();
                        }



                        /*
                        if (txtValorUnitario.Visible)
                        {
                            if (MiProducto != null)
                            {
                                txtValorUnitario.Focus();
                            }
                            else
                            {
                                txtCodigoArticulo.Focus();
                            }
                        }
                        else
                        {
                            if (MiProducto != null)
                            {
                                CargarColorOconsulta();
                            }
                            else
                            {
                                txtCodigoArticulo.Focus();
                            }
                        }
                        */
                    }
                    else
                    {
                        miError.SetError(txtCantidad, "El valor unitario debe ser diferente de cero.");
                        txtCantidad.Focus();
                    }
                }
                else
                {
                    miError.SetError(txtCantidad, "El valor unitario que ingreso tiene formato incorrecto.");
                    txtCantidad.Focus();
                }
            }
        }


        private void cbDescuentoProducto_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                if (MiProducto.AplicaTalla || MiProducto.AplicaColor)
                {
                    if ((MiProducto.AplicaTalla && miTallaYcolor.IdTalla == 0) ||
                        (MiProducto.AplicaColor && miTallaYcolor.IdColor == 0))
                    {
                        LoadColorSize = true;
                        btnTallaYcolor_Click(this.btnTallaYcolor, new EventArgs());
                        return;
                    }
                    else
                    {
                        LoadColorSize = false;
                        EstructurarConsulta();
                    }
                }
                else
                {
                    EstructurarConsulta();
                }
            }
        }

        private void cbRecargoProducto_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                if (MiProducto.AplicaTalla || MiProducto.AplicaColor)
                {
                    if ((MiProducto.AplicaTalla && miTallaYcolor.IdTalla == 0) ||
                        (MiProducto.AplicaColor && miTallaYcolor.IdColor == 0))
                    {
                        LoadColorSize = true;
                        btnTallaYcolor_Click(this.btnTallaYcolor, new EventArgs());
                        return;
                    }
                    else
                    {
                        LoadColorSize = false;
                        EstructurarConsulta();
                    }
                }
                else
                {
                    EstructurarConsulta();
                }
            }
        }

        private void btnTallaYcolor_Click(object sender, EventArgs e)
        {
            if (MiProducto != null)
            {
                if (MiProducto.AplicaTalla || MiProducto.AplicaColor)
                {
                    var FrmTallaColor = new frmMedidaColor();
                    FrmTallaColor.MdiParent = this.MdiParent;
                    FrmTallaColor.AplicaTalla = MiProducto.AplicaTalla;
                    FrmTallaColor.AplicaColor = MiProducto.AplicaColor;
                    FrmTallaColor.CodigoProducto = MiProducto.CodigoInternoProducto;
                    FrmTallaColor.Venta_ = true;
                    if (MiProducto.AplicaColor && !MiProducto.AplicaTalla)
                    {
                        FrmTallaColor.IdMedida_ = miMedida.IdValorUnidadMedida;
                    }
                    if (EnableColor && MiProducto.AplicaColor)
                    {
                        FrmTallaColor.Show();
                    }
                    else
                    {
                        if (MiProducto.AplicaTalla)
                        {
                            FrmTallaColor.AplicaColor = false;
                            FrmTallaColor.Show();
                        }
                    }
                }
            }
            else
            {
                OptionPane.MessageInformation("Debe seleccionar un Articulo primero.");
            }
        }

        private void chkFacturaPos_Click(object sender, EventArgs e)
        {
            if (chkFacturaPos.Checked)
            {
                FacturaPos = true;
                AppConfiguracion.SaveConfiguration("facturapos", "true");
            }
            else
            {
                AppConfiguracion.SaveConfiguration("facturapos", "false");
                FacturaPos = false;
            }
        }

        private void dgvListaArticulos_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (e.ColumnIndex.Equals(12) && !TotalMasIva.ReadOnly) // valor venta
            {
                if (!String.IsNullOrEmpty(e.FormattedValue.ToString()))
                {
                    if (!MiValidacion.ValidarNumeroInt(e.FormattedValue.ToString()))
                    {
                        OptionPane.MessageError("El número que ingreso es incorrecto.");
                        e.Cancel = true;
                    }
                    else
                    {
                        var num = Convert.ToDouble(e.FormattedValue.ToString());
                        //var gRow = this.dgvListaArticulos.Rows[e.RowIndex];
                        //  if (!Convert.ToBoolean(gRow.Cells["Retorno"].Value))
                        //  {
                        ActualizarInformacion(e.RowIndex, num.ToString());//e.FormattedValue.ToString());
                        dgvListaArticulos.Columns["TotalMasIva"].ReadOnly = true;
                        dgvListaArticulos.EditMode = DataGridViewEditMode.EditProgrammatically;
                        dgvListaArticulos.BeginEdit(false);
                        /*dgvListaArticulos.Columns["Cantidad"].ReadOnly = true;
                dgvListaArticulos.Columns["TotalMasIva"].ReadOnly = false;
                txtCodigoArticulo.Focus();
                dgvListaArticulos.Focus();
                dgvListaArticulos.EditMode = DataGridViewEditMode.EditOnEnter;
                dgvListaArticulos.BeginEdit(true);*/
                        return;
                        //}
                    }
                }
                else
                {
                    OptionPane.MessageError("Debe ingresar un valor.");
                    e.Cancel = true;
                }
            }
            else
            {
                if (e.ColumnIndex.Equals(7) && !Cantidad.ReadOnly) // cantidad
                {
                    if (!String.IsNullOrEmpty(e.FormattedValue.ToString()))
                    {
                        if (!MiValidacion.ValidarNumeroDecima(e.FormattedValue.ToString()))
                        {
                            OptionPane.MessageError("El número que ingreso es incorrecto.");
                            e.Cancel = true;
                        }
                        else
                        {
                            var num = Convert.ToDouble(e.FormattedValue.ToString().Replace('.', ','));
                            //ActualizarInformacionCantidad(e.RowIndex, num.ToString());
                            if (num.Equals(0))
                            {
                                OptionPane.MessageError("La cantidad debe ser diferente de cero.");
                                e.Cancel = true;
                            }
                            else
                            {
                                ActualizarInformacionCantidadNew(e.RowIndex, num.ToString());
                                dgvListaArticulos.Columns["Cantidad"].ReadOnly = true;
                                dgvListaArticulos.EditMode = DataGridViewEditMode.EditProgrammatically;
                                dgvListaArticulos.BeginEdit(false);
                                return;
                            }
                        }
                    }
                    else
                    {
                        OptionPane.MessageError("Debe ingresar un valor.");
                        e.Cancel = true;
                    }
                }
            }
        }

        private void btnCambiarRetencion_Click(object sender, EventArgs e)
        {
            var frmReteCompra = new Compras.Egreso.FrmAplicaRetencion();
            frmReteCompra.AplicaVenta = true;
            frmReteCompra.IdTipoBeneficio = cliente.IdRegimen;
            frmReteCompra.IdTipoEmpresa = miEmpresa.Regimen.IdRegimen;
            DialogResult rta = frmReteCompra.ShowDialog();
            if (rta.Equals(DialogResult.Yes))
            {
                if (Retenciones.Count != 0)
                {
                    var query = Retenciones.First();
                    MiRetencion.Tarifa = query.Tarifa;
                    MiRetencion.CifraPesos = query.CifraPesos;
                    MiRetencion.CifraUVT = query.CifraUVT;
                    MiRetencion.Concepto = query.Concepto;
                    lblTasaRetencion.Text = query.Tarifa.ToString() + "%";
                    miToolTip.SetToolTip(btnInfoRete, query.Concepto);
                    AplicaRete = true;
                    RecargarRetencion();
                    this.CalcularTotal();
                }
            }
            else
            {
                if (rta.Equals(DialogResult.No))
                {
                    MiRetencion.Tarifa = 0;
                    MiRetencion.CifraPesos = 0;
                    MiRetencion.CifraUVT = 0;
                    MiRetencion.Concepto = "";
                    lblTasaRetencion.Text = MiRetencion.Tarifa.ToString() + "%";
                    miToolTip.SetToolTip(btnInfoRete, MiRetencion.Concepto);
                    txtRetencion.Text = "0";
                    AplicaRete = false;
                    RecargarRetencion();
                    this.CalcularTotal();

                }
            }
        }

        //metodos...

        /// <summary>
        /// Carga los valores de las utilizados en el Formulario de Factura de Venta.
        /// </summary>
        private void CargarUtilidades()
        {
            /*txtCliente.Text = "1000";
            txtCliente_KeyPress(this.txtCliente, new KeyPressEventArgs((char)Keys.Enter));*/
            var lst = new List<Inventario.Producto.Criterio>();
            lst.Add(new Inventario.Producto.Criterio
            {
                Id = 0,
                Nombre = "[Seleccione]"
            });
            lst.Add(new Inventario.Producto.Criterio
            {
                Id = 1,
                Nombre = "Descuento"
            });
            lst.Add(new Inventario.Producto.Criterio
            {
                Id = 2,
                Nombre = "Recargo"
            });
            //tsCbDesctoRecargo.ComboBox.DataSource = lst;
            //tsCbDesctoRecargo.ComboBox.DisplayMember = "Nombre";
            //tsCbDesctoRecargo.ComboBox.ValueMember = "Id";

            cbDesctoRecargo.DataSource = lst;
            try
            {
                //tsCbContado.ComboBox.DisplayMember = "descripcionestado";
                //tsCbContado.ComboBox.ValueMember = "idestado";
                //tsCbContado.ComboBox.DataSource = miBussinesEstado.Lista();

                if (this.SeleccionPendiente && this.SeleccionCotizacion)
                {
                    this.cbContado.DataSource = this.miBussinesEstado.Lista();
                }
                else
                {
                    if (this.SeleccionPendiente)
                    {
                        this.cbContado.DataSource = this.miBussinesEstado.ListaExcluyente(this.IdPendiente);
                    }
                    else
                    {
                        if (this.SeleccionCotizacion)
                        {
                            this.cbContado.DataSource = this.miBussinesEstado.ListaExcluyente(this.IdCotizacion);
                        }
                        else
                        {
                            this.cbContado.DataSource = this.miBussinesEstado.ListaExcluyente(this.IdPendiente, this.IdCotizacion);
                        }
                    }
                }

                IdEstado = Convert.ToInt32(cbContado.SelectedValue);
                if (Convert.ToBoolean(AppConfiguracion.ValorSeccion("facturapos")))
                {
                    chkFacturaPos.Checked = true;
                }
                else
                {
                    chkFacturaPos.Checked = false;
                }

                RequiereCantidad = Convert.ToBoolean(AppConfiguracion.ValorSeccion("reqCantidad"));
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }

            miToolTip.SetToolTip(btnBuscarCliente, "Buscar Cliente [F2]");
            miToolTip.SetToolTip(txtCodigoArticulo, "Buscar Producto [F4]");

            miToolTip.SetToolTip(btnTallaYcolor, "Seleccionar Talla y Color");
            miToolTip.SetToolTip(rbtnDesctoProducto, "Aplicar descuento por Producto.");
            miToolTip.SetToolTip(pbProducto, "Aplicar descuento por Producto.");
            miToolTip.SetToolTip(rbtnDesctoFactura, "Aplicar descuento por Factura.");
            miToolTip.SetToolTip(pbFactura, "Aplicar descuento por Factura.");
        }

        /// <summary>
        /// Carga en memoria los datos de la Empresa.
        /// </summary>
        private void CargarEmpresa()
        {
            try
            {
                miEmpresa = miBussinesEmpresa.ObtenerEmpresa();
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
        }

        private void CargarRetencion()
        {
            try
            {
                MiRetencion.Concepto = AppConfiguracion.ValorSeccion("concepto_v");
                MiRetencion.CifraUVT = Convert.ToDouble(AppConfiguracion.ValorSeccion("uvt_v"));
                MiRetencion.CifraPesos = Convert.ToInt32(AppConfiguracion.ValorSeccion("pesos_v"));
                MiRetencion.Tarifa = Convert.ToDouble(AppConfiguracion.ValorSeccion("tasa_v"));
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
        }

        private int IdRubroRetencion;

        private bool AplicaRete = false;

        DTO.Clases.Cliente cliente;

        private void CargarCliente(string nit)
        {
            try
            {
                cliente = miBussinesCliente.ClienteAEditar(txtCliente.Text);
                txtNombreCliente.Text = cliente.NitCliente + " - " + cliente.NombresCliente;
                txtTipoCliente.Text = "Cliente " + cliente.DescripcionTipo;
                NitCliente = cliente.NitCliente;
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
        }

        private bool ValidarCantidad(string cant)
        {
            var pass = false;
            try
            {
                Convert.ToDouble(cant);
                pass = true;
            }
            catch (FormatException)
            {
                pass = false;
            }
            try
            {
                Convert.ToInt32(Convert.ToDouble(cant));
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

        private void ValidarRetencion()
        {
            try
            {
                if (miBussinesRetencion.RetencionesAplicadasAVenta
                    (miEmpresa.Regimen.IdRegimen, cliente.IdRegimen, IdRubroRetencion).Rows.Count != 0)
                {
                    AplicaRete = true;
                    //lblTasaRetencion.Text = TasaRete.ToString() + "%";
                    lblTasaRetencion.Text = MiRetencion.Tarifa.ToString() + "%";
                    btnInfoRete.Enabled = true;
                    miToolTip.SetToolTip(btnInfoRete, MiRetencion.Concepto);
                    btnCambiarRetencion.Enabled = true;
                }
                else
                {
                    AplicaRete = false;
                    lblTasaRetencion.Text = "0%";
                    btnInfoRete.Enabled = false;
                    miToolTip.SetToolTip(btnInfoRete, "");
                    btnCambiarRetencion.Enabled = false;
                    //txtRetencion.Text = "0";
                }
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
        }

        private void RecargarRetencion()
        {
            if (AplicaRete)
            {
                if (UseObject.RemoveSeparatorMil(txtTotal.Text) > MiRetencion.CifraPesos)
                {
                    var total = Convert.ToInt32(this.miTabla.AsEnumerable().Sum(s => s.Field<double>("ValorUnitario") *
                        Convert.ToDouble(s.Field<string>("Cantidad"))));
                    txtRetencion.Text = UseObject.InsertSeparatorMil((Convert.ToInt32(total * MiRetencion.Tarifa / 100)).ToString());

                    /*txtRetencion.Text = UseObject.InsertSeparatorMil((Convert.ToInt32
                                (UseObject.RemoveSeparatorMil(txtTotal.Text) * MiRetencion.Tarifa / 100)).ToString());*/

                    /*miTabla.Columns.Add(new DataColumn("Cantidad", typeof(string)));
            miTabla.Columns.Add(new DataColumn("ValorUnitario", typeof(double)));*/
                }
                else
                {
                    txtRetencion.Text = "0";
                }
            }
            else
            {
                /*MiRetencion.Tarifa = 0.0;
                MiRetencion.CifraPesos = 0;
                MiRetencion.CifraUVT = 0;
                MiRetencion.Concepto = "";*/
                //MiRetencion.CifraPesos = 0.0;
                txtRetencion.Text = "0";
            }
            MiRetencion.Valor = UseObject.RemoveSeparatorMil(this.txtRetencion.Text);
            //this.CalcularTotal();
            /*txtTotalMenosRete.Text = UseObject.InsertSeparatorMil(
                        (UseObject.RemoveSeparatorMil(txtTotal.Text) - UseObject.RemoveSeparatorMil(txtRetencion.Text)).ToString());*/
            /*this.txtTotalMenosRete.Text = UseObject.InsertSeparatorMil(((UseObject.RemoveSeparatorMil(this.txtTotal.Text) +
                        UseObject.RemoveSeparatorMil(this.txtIcoBolsaTotal.Text)) - UseObject.RemoveSeparatorMil(this.txtRetencion.Text)).ToString());*/
        }

        private void ConsultaInventario()
        {
            if (!ExtendForms)
            {
                if (_ConsultaInventario)
                {
                    var frmInventario = new Inventario.Consulta.FrmConsultaInventario();
                    frmInventario.ExtendVenta = true;
                    frmInventario.Consulta = false;
                    frmInventario.ExtendForms_ = true;

                    frmInventario.IdTipoInventarioNoFabricado = IdTipoInventarioProductoNoFabricado;
                    frmInventario.IdTipoInventarioFabricado = IdTipoInventarioProductoFabricado;

                    frmInventario.MdiParent = this.MdiParent;
                    ExtendForms = true;
                    this.Transfer = true;
                    frmInventario.Show();
                    frmInventario.txtCodigoNombre.Focus();
                }
                else
                {
                    var frmInventario = new Inventario.Consulta.FrmInventario();
                    frmInventario.ExtendVenta = true;

                    frmInventario.MdiParent = this.MdiParent;
                    ExtendForms = true;
                    this.Transfer = true;
                    frmInventario.Show();
                    frmInventario.txtCodigoNombre.Focus();
                }
            }
        }

        private void ActivarDescuento()
        {
            this.cbDesctoRecargo.SelectedValue = 1;
            this.tsCbDesctoRecargo_SelectedIndexChanged(null, new EventArgs());
            var id = ((Inventario.Producto.Criterio)cbDesctoRecargo.SelectedItem).Id;
            if (id.Equals(1))
            {
                this.rbtnDesctoProducto.Checked = true;
                this.rbtnDesctoProducto_Click(this.rbtnDesctoProducto, new EventArgs());
                txtCodigoArticulo.Focus();
            }
        }

        /// <summary>
        /// Obtiene el Número consecutivo a ser asignado en la Factura.
        /// </summary>
        /// <returns></returns>
        private void ObtenerNumero()
        {
            try
            {
                // Cambiar la forma en como valida la advertencia de numeracion. ACT 19/06/2019
                Int64 numeracionRest = this.miBussinesDian.NumeracionRestante("IdRegistroDian", "Factura");
                int cantidadNumeracion = Convert.ToInt32(AppConfiguracion.ValorSeccion("numero_restantes_alert"));
                if (numeracionRest <= cantidadNumeracion)
                {
                    MessageBox.Show("Le restan " + numeracionRest + " números de facturas para finalizar la resolución actual.",
                            "Factura Venta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

                /*var numeroBD = miBussinesFactura.ObtenerNumero(contado, miEmpresa.Regimen.IdRegimen);
                if (miEmpresa.Regimen.IdRegimen.Equals(1))
                {
                    long numero = 0;
                    numero = Convert.ToInt64(miBussinesConsecutivo.Consecutivo("Factura"));
                    if (numero > miBussinesFactura.ObtenerRangoFinal(contado))
                    {
                        MessageBox.Show("El número de la factura exede numero de registro asignado por la DIAN.",
                            "Factura Venta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                lblNoFactura.Text = numeroBD;
                miFactura.Numero = numeroBD;
                numeroBD = null;*/
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
        }

        /// <summary>
        /// Obtiene un Número consecutivo temporal para ser asignado en la Factura.
        /// </summary>
        /// <returns></returns>
        private string ObtenerNumeroTemp()
        {
            return
            AppConfiguracion.ValorSeccion("const") + AppConfiguracion.ValorSeccion("numero");
        }

        /// <summary>
        /// Incrementa en una unidad el número designado como consecutivo temporal.
        /// </summary>
        private void ActualizaNumeroTemp()
        {
            var numero = Convert.ToInt64(AppConfiguracion.ValorSeccion("numero"));
            numero++;
            AppConfiguracion.SaveConfiguration("numero", numero.ToString());
        }

        /// <summary>
        /// Crea las respectivas columnas del DataTable miTabla.
        /// </summary>
        private void CrearDataTable()
        {
            miTabla = new DataTable();
            miTabla.Columns.Add(new DataColumn("Id", typeof(int)));
            miTabla.Columns.Add(new DataColumn("Codigo", typeof(string)));
            miTabla.Columns.Add(new DataColumn("Articulo", typeof(string)));
            miTabla.Columns.Add(new DataColumn("Cantidad", typeof(string)));
            miTabla.Columns.Add(new DataColumn("ValorUnitario", typeof(double)));
            miTabla.Columns.Add(new DataColumn("Descuento", typeof(string)));
            miTabla.Columns.Add(new DataColumn("ValorMenosDescto", typeof(double)));
            miTabla.Columns.Add(new DataColumn("Iva", typeof(string)));
            miTabla.Columns.Add(new DataColumn("TotalMasIva", typeof(double)));
            miTabla.Columns.Add(new DataColumn("Valor", typeof(double)));
            miTabla.Columns.Add(new DataColumn("Unidad", typeof(string)));
            miTabla.Columns.Add(new DataColumn("IdMedida", typeof(int)));
            miTabla.Columns.Add(new DataColumn("Medida", typeof(string)));
            miTabla.Columns.Add(new DataColumn("IdColor", typeof(int)));
            miTabla.Columns.Add(new DataColumn("IdMarca", typeof(int)));
            miTabla.Columns.Add(new DataColumn("Color", typeof(Image)));
            miTabla.Columns.Add(new DataColumn("Save", typeof(bool)));

            miTabla.Columns.Add(new DataColumn("Retorno", typeof(bool)));
            miTabla.Columns.Add(new DataColumn("Valor_", typeof(double)));
            miTabla.Columns.Add(new DataColumn("Ico", typeof(double)));

            miTabla.Columns.Add(new DataColumn("ValorIva", typeof(double)));

            miTabla.Columns.Add(new DataColumn("IdTipoInventario", typeof(int)));
            miTabla.Columns.Add(new DataColumn("IdIva", typeof(int)));
            //miTabla.Columns.Add(new DataColumn("ValorReal", typeof(double)));
        }

        /// <summary>
        /// Valida que el documento del cliente ingresado no sea vacío y tenga formato correcto.
        /// </summary>
        /// <returns></returns>
        private bool ValidarCodigoCliente()
        {
            if (!Validacion.EsVacio(txtCliente, miError, ClienteReq))
            {
                if (Validacion.ConFormato(Validacion.TipoValidacion.NumeroGuion, txtCliente,
                    miError, ClienteFormato))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Valida se el cliente ingresado existe en base de datos.
        /// </summary>
        /// <returns></returns>
        private bool ExisteCliente()
        {
            try
            {
                return miBussinesCliente.ExisteCliente(txtCliente.Text);
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
                return false;
            }
        }

        /// <summary>
        /// Verifica si el texto ingresado equivale a un número o palabra. Retorna true si es un número.
        /// </summary>
        /// <returns></returns>
        private bool CodigoOrString()
        {
            var num = true;
            try
            {
                Convert.ToInt64(txtCodigoArticulo.Text);
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

            /*try
            {
                Convert.ToInt64(txtCodigoArticulo.Text);
                return true;
            }
            catch(Exception ex)
            {
                try
                {
                    var j = (OverflowException)ex.InnerException;
                    return true;
                }
                catch 
                {
                    return false;
                }
            }*/
        }

        private bool CodigoValido(string codigo, int tamanio)
        {
            var valido = true;
            if (codigo.Length < tamanio)
            {
                valido = false;
            }
            return valido;
        }


        /// <summary>
        /// Valida si codigo ingresado existe en la base de datos.
        /// </summary>
        /// <param name="codigo">Codigo a verificar.</param>
        /// <returns></returns>
        private bool ExisteProducto(string codigo)
        {
            try
            {
                var barras = miBussinesProducto.ExisteCodigoBarras(codigo);
                var code = miBussinesProducto.ExisteCodigo(codigo);
                if (barras || code)
                    return true;
                else
                    return false;
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
                return false;
            }
        }

        /// <summary>
        /// Carga en memoria los datos del Producto consultado segun su codigo.
        /// </summary>
        private bool CargarProducto()
        {
            var resultado = false;
            try
            {
                ArrayProducto = miBussinesProducto.ProductoBasico(txtCodigoArticulo.Text);
                MiProducto = (Producto)ArrayProducto[0];

                if (MiProducto.IdTipoInventario.Equals(IdTipoInventarioProductoNoFabricado) ||
                    MiProducto.IdTipoInventario.Equals(IdTipoInventarioProductoFabricado))
                {

                    var tabla = miBussinesMedida.MedidasDeProducto(MiProducto.CodigoInternoProducto);
                    if (!MiProducto.AplicaTalla)
                    {
                        miMedida = (ValorUnidadMedida)ArrayProducto[1];
                        SingleSize = true;
                    }
                    else
                    {

                        if (tabla.Rows.Count == 1)
                        {
                            var q = (from d in tabla.AsEnumerable()
                                     select d).Single();
                            //miMedida.IdValorUnidadMedida = Convert.ToInt32(q["idvalor_unidad_medida"]);
                            miTallaYcolor.IdTalla = Convert.ToInt32(q["idvalor_unidad_medida"]);
                            q = null;
                            SingleSize = true;
                        }
                        else
                        {
                            SingleSize = false;
                        }
                        //tabla.Clear();
                        //tabla = null;
                    }
                    if (MiProducto.AplicaColor)
                    {
                        if (tabla.Rows.Count == 1)
                        {
                            var q = (from d in tabla.AsEnumerable()
                                     select d).Single();
                            var tablaColor = miBussinesColor.ColoresDeProducto
                                (MiProducto.CodigoInternoProducto, Convert.ToInt32(q["idvalor_unidad_medida"]));
                            if (tablaColor.Rows.Count == 1)
                            {
                                var c = (from d in tablaColor.AsEnumerable()
                                         select d).Single();
                                miTallaYcolor.IdColor = Convert.ToInt32(c["idcolor"]);
                                SingleColor = true;
                            }
                            else
                            {
                                SingleColor = false;
                            }
                        }
                        else
                        {
                            SingleColor = false;
                        }
                    }
                    else
                    {
                        SingleColor = true;
                    }
                    lblDatosProducto.Text = MiProducto.CodigoInternoProducto + " - " + MiProducto.NombreProducto;
                    var valorVenta = MiProducto.ValorVentaProducto - Convert.ToInt32(MiProducto.Impoconsumo); // nuevo: Convert.ToInt32(MiProducto.Impoconsumo)
                    if (DesctoAplica > 0)
                    {

                        valorVenta = Convert.ToInt32(valorVenta - Math.Round((valorVenta * DesctoAplica / 100), 1)); // edición por impoconsumo
                        /*valorVenta = Convert.ToInt32(Math.Round((MiProducto.ValorVentaProducto -
                            (MiProducto.ValorVentaProducto * DesctoAplica / 100)), 1));*/
                    }
                    else
                    {
                        double descto = 0.0;
                        switch (cliente.IdTipoCliente)
                        {
                            case 2: // cliente mayorista
                                {
                                    if (Convert.ToBoolean(AppConfiguracion.ValorSeccion("permitirDesctoMayor")))
                                    {
                                        descto = MiProducto.DescuentoMayor;
                                    }
                                    break;
                                }
                            case 3: // cliente distribuidor
                                {
                                    descto = MiProducto.DescuentoDistribuidor;
                                    break;
                                }
                        }
                        valorVenta = Convert.ToInt32(valorVenta - Math.Round((valorVenta * descto / 100), 1));   // edición por impoconsumo
                        /*valorVenta = Convert.ToInt32(Math.Round((MiProducto.ValorVentaProducto -
                            (MiProducto.ValorVentaProducto * descto / 100)), 1));*/
                    }
                    valorVenta += Convert.ToInt32(this.MiProducto.Impoconsumo);
                    if (this.RedondearPrecio2)
                    {
                        txtValorUnitario.Text = UseObject.InsertSeparatorMil(
                        UseObject.Aproximar(Convert.ToInt32(valorVenta), Convert.ToBoolean(AppConfiguracion.ValorSeccion("tipo_aprox_precio"))).ToString());

                        lblPrecioProducto.Text = "v/u  " + txtValorUnitario.Text;
                    }
                    else
                    {
                        txtValorUnitario.Text = UseObject.InsertSeparatorMil(valorVenta.ToString());
                        lblPrecioProducto.Text = "v/u  " + txtValorUnitario.Text;
                    }

                    //UseObject.Aproximar(vUnitario, Convert.ToBoolean(AppConfiguracion.ValorSeccion("tipo_aprox_precio")));
                    //lblPrecioProducto.Text = "v/u  " + UseObject.InsertSeparatorMil(
                    // UseObject.Aproximar(Convert.ToInt32(valorVenta), Convert.ToBoolean(AppConfiguracion.ValorSeccion("tipo_aprox_precio"))).ToString());
                    if (!MiProducto.AplicaTalla && !MiProducto.AplicaColor)
                    {
                        btnTallaYcolor.Enabled = false;
                    }
                    else
                    {
                        btnTallaYcolor.Enabled = true;
                    }
                    txtCantidad.Text = txtCantidad.Text.Replace('.', ',');
                    if (!MiProducto.CantidadDecimal)
                    {
                        try
                        {
                            if (!String.IsNullOrEmpty(txtCantidad.Text))
                            {
                                Convert.ToInt32(txtCantidad.Text);
                                miError.SetError(txtCantidad, null);
                                resultado = true;
                            }
                            else
                            {
                            }
                            /*Convert.ToInt32(txtCantidad.Text);
                            miError.SetError(txtCantidad, null);
                            resultado = true;*/

                            //EstructurarConsulta();
                        }
                        catch
                        {
                            //OptionPane.MessageError("Este Producto no admite cantidad en decimal.");
                            miError.SetError(txtCantidad, "Este Producto no admite cantidad en decimal.");
                            txtCantidad.Focus();
                            txtCantidad.SelectAll();
                            resultado = false;
                        }
                    }
                    else
                    {
                        miError.SetError(txtCantidad, null);
                        resultado = true;
                        //EstructurarConsulta();
                    }
                }
                else
                {
                    OptionPane.MessageInformation("Este producto no se puede facturar.");
                }
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
            return resultado;
        }

        private bool CargarProducto(string codigo)
        {
            var resultado = false;
            try
            {
                ArrayProducto = miBussinesProducto.ProductoBasico(codigo);
                MiProducto = (Producto)ArrayProducto[0];

                if (MiProducto.IdTipoInventario.Equals(IdTipoInventarioProductoNoFabricado) ||
                    MiProducto.IdTipoInventario.Equals(IdTipoInventarioProductoFabricado))
                {
                    var tabla = miBussinesMedida.MedidasDeProducto(MiProducto.CodigoInternoProducto);
                    if (!MiProducto.AplicaTalla)
                    {
                        miMedida = (ValorUnidadMedida)ArrayProducto[1];
                        SingleSize = true;
                    }
                    else
                    {

                        if (tabla.Rows.Count == 1)
                        {
                            var q = (from d in tabla.AsEnumerable()
                                     select d).Single();
                            //miMedida.IdValorUnidadMedida = Convert.ToInt32(q["idvalor_unidad_medida"]);
                            miTallaYcolor.IdTalla = Convert.ToInt32(q["idvalor_unidad_medida"]);
                            q = null;
                            SingleSize = true;
                        }
                        else
                        {
                            SingleSize = false;
                        }
                        //tabla.Clear();
                        //tabla = null;
                    }
                    if (MiProducto.AplicaColor)
                    {
                        if (tabla.Rows.Count == 1)
                        {
                            var q = (from d in tabla.AsEnumerable()
                                     select d).Single();
                            var tablaColor = miBussinesColor.ColoresDeProducto
                                (MiProducto.CodigoInternoProducto, Convert.ToInt32(q["idvalor_unidad_medida"]));
                            if (tablaColor.Rows.Count == 1)
                            {
                                var c = (from d in tablaColor.AsEnumerable()
                                         select d).Single();
                                miTallaYcolor.IdColor = Convert.ToInt32(c["idcolor"]);
                                SingleColor = true;
                            }
                            else
                            {
                                SingleColor = false;
                            }
                        }
                        else
                        {
                            SingleColor = false;
                        }
                    }
                    else
                    {
                        SingleColor = true;
                    }
                    lblDatosProducto.Text = MiProducto.CodigoInternoProducto + " - " + MiProducto.NombreProducto;
                    var valorVenta = MiProducto.ValorVentaProducto;
                    if (DesctoAplica > 0)
                    {
                        valorVenta = Convert.ToInt32(Math.Round((MiProducto.ValorVentaProducto -
                            (MiProducto.ValorVentaProducto * DesctoAplica / 100)), 1));
                    }
                    else
                    {
                        double descto = 0.0;
                        switch (cliente.IdTipoCliente)
                        {
                            case 2: // cliente mayorista
                                {
                                    if (Convert.ToBoolean(AppConfiguracion.ValorSeccion("permitirDesctoMayor")))
                                    {
                                        descto = MiProducto.DescuentoMayor;
                                    }
                                    break;
                                }
                            case 3: // cliente distribuidor
                                {
                                    descto = MiProducto.DescuentoDistribuidor;
                                    break;
                                }
                        }
                        valorVenta = Convert.ToInt32(Math.Round((MiProducto.ValorVentaProducto -
                            (MiProducto.ValorVentaProducto * descto / 100)), 1));
                    }
                    lblPrecioProducto.Text = "v/u  " + UseObject.InsertSeparatorMil(valorVenta.ToString());
                    //UseObject.Aproximar(vUnitario, Convert.ToBoolean(AppConfiguracion.ValorSeccion("tipo_aprox_precio")));
                    /*lblPrecioProducto.Text = "v/u  " + UseObject.InsertSeparatorMil(
                        UseObject.Aproximar(Convert.ToInt32(valorVenta), Convert.ToBoolean(AppConfiguracion.ValorSeccion("tipo_aprox_precio"))).ToString());*/
                    if (!MiProducto.AplicaTalla && !MiProducto.AplicaColor)
                    {
                        btnTallaYcolor.Enabled = false;
                    }
                    else
                    {
                        btnTallaYcolor.Enabled = true;
                    }
                    txtCantidad.Text = txtCantidad.Text.Replace('.', ',');
                    if (!MiProducto.CantidadDecimal)
                    {
                        try
                        {
                            if (!String.IsNullOrEmpty(txtCantidad.Text))
                            {
                                Convert.ToInt32(txtCantidad.Text);
                                miError.SetError(txtCantidad, null);
                                resultado = true;
                            }
                            else
                            {
                            }
                            /*Convert.ToInt32(txtCantidad.Text);
                            miError.SetError(txtCantidad, null);
                            resultado = true;*/

                            //EstructurarConsulta();
                        }
                        catch
                        {
                            OptionPane.MessageError("Este Producto no admite cantidad en decimal.");
                            miError.SetError(txtCantidad, "Este Producto no admite cantidad en decimal.");
                            txtCantidad.Focus();
                            txtCantidad.SelectAll();
                            resultado = false;
                        }
                    }
                    else
                    {
                        miError.SetError(txtCantidad, null);
                        resultado = true;
                        //EstructurarConsulta();
                    }
                }
                else
                {
                    OptionPane.MessageInformation("Este producto no se puede facturar.");
                }
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
            return resultado;
        }

        private bool CargarProducto(string codigo, int precio)
        {
            var resultado = false;
            try
            {
                ArrayProducto = miBussinesProducto.ProductoBasico(codigo);
                MiProducto = (Producto)ArrayProducto[0];
                var tabla = miBussinesMedida.MedidasDeProducto(MiProducto.CodigoInternoProducto);
                if (!MiProducto.AplicaTalla)
                {
                    miMedida = (ValorUnidadMedida)ArrayProducto[1];
                    SingleSize = true;
                }
                else
                {

                    if (tabla.Rows.Count == 1)
                    {
                        var q = (from d in tabla.AsEnumerable()
                                 select d).Single();
                        //miMedida.IdValorUnidadMedida = Convert.ToInt32(q["idvalor_unidad_medida"]);
                        miTallaYcolor.IdTalla = Convert.ToInt32(q["idvalor_unidad_medida"]);
                        q = null;
                        SingleSize = true;
                    }
                    else
                    {
                        SingleSize = false;
                    }
                    //tabla.Clear();
                    //tabla = null;
                }
                if (MiProducto.AplicaColor)
                {
                    if (tabla.Rows.Count == 1)
                    {
                        var q = (from d in tabla.AsEnumerable()
                                 select d).Single();
                        var tablaColor = miBussinesColor.ColoresDeProducto
                            (MiProducto.CodigoInternoProducto, Convert.ToInt32(q["idvalor_unidad_medida"]));
                        if (tablaColor.Rows.Count == 1)
                        {
                            var c = (from d in tablaColor.AsEnumerable()
                                     select d).Single();
                            miTallaYcolor.IdColor = Convert.ToInt32(c["idcolor"]);
                            SingleColor = true;
                        }
                        else
                        {
                            SingleColor = false;
                        }
                    }
                    else
                    {
                        SingleColor = false;
                    }
                }
                else
                {
                    SingleColor = true;
                }
                lblDatosProducto.Text = MiProducto.CodigoInternoProducto + " - " + MiProducto.NombreProducto;
                var valorVenta = MiProducto.ValorVentaProducto = precio;
                if (DesctoAplica > 0)
                {
                    valorVenta = Convert.ToInt32(Math.Round((MiProducto.ValorVentaProducto -
                        (MiProducto.ValorVentaProducto * DesctoAplica / 100)), 1));
                }
                else
                {
                    double descto = 0.0;
                    switch (cliente.IdTipoCliente)
                    {
                        case 2: // cliente mayorista
                            {
                                if (Convert.ToBoolean(AppConfiguracion.ValorSeccion("permitirDesctoMayor")))
                                {
                                    descto = MiProducto.DescuentoMayor;
                                }
                                break;
                            }
                        case 3: // cliente distribuidor
                            {
                                descto = MiProducto.DescuentoDistribuidor;
                                break;
                            }
                    }
                    valorVenta = Convert.ToInt32(Math.Round((MiProducto.ValorVentaProducto -
                        (MiProducto.ValorVentaProducto * descto / 100)), 1));
                }
                lblPrecioProducto.Text = "v/u  " + UseObject.InsertSeparatorMil(valorVenta.ToString());
                //UseObject.Aproximar(vUnitario, Convert.ToBoolean(AppConfiguracion.ValorSeccion("tipo_aprox_precio")));
                /*lblPrecioProducto.Text = "v/u  " + UseObject.InsertSeparatorMil(
                    UseObject.Aproximar(Convert.ToInt32(valorVenta), Convert.ToBoolean(AppConfiguracion.ValorSeccion("tipo_aprox_precio"))).ToString());*/
                if (!MiProducto.AplicaTalla && !MiProducto.AplicaColor)
                {
                    btnTallaYcolor.Enabled = false;
                }
                else
                {
                    btnTallaYcolor.Enabled = true;
                }
                txtCantidad.Text = txtCantidad.Text.Replace('.', ',');
                if (!MiProducto.CantidadDecimal)
                {
                    try
                    {
                        if (!String.IsNullOrEmpty(txtCantidad.Text))
                        {
                            Convert.ToInt32(txtCantidad.Text);
                            miError.SetError(txtCantidad, null);
                            resultado = true;
                        }
                        else
                        {
                        }
                        /*Convert.ToInt32(txtCantidad.Text);
                        miError.SetError(txtCantidad, null);
                        resultado = true;*/

                        //EstructurarConsulta();
                    }
                    catch
                    {
                        OptionPane.MessageError("Este Producto no admite cantidad en decimal.");
                        miError.SetError(txtCantidad, "Este Producto no admite cantidad en decimal.");
                        txtCantidad.Focus();
                        txtCantidad.SelectAll();
                        resultado = false;
                    }
                }
                else
                {
                    miError.SetError(txtCantidad, null);
                    resultado = true;
                    //EstructurarConsulta();
                }
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
            return resultado;
        }

        /// <summary>
        /// Carga el listado de los descuentos relacionados a un Producto.
        /// </summary>
        private void CargarDescuentosORecargos()
        {
            if (IdDesctoRecgo == 1) ///Descuento a factura
            {
                if (rbtnDesctoProducto.Checked)
                {
                    try
                    {
                        cbDescuentoProducto.DataSource =
                            miBussinesDescuento.ListadoDescuento();//ListadoDescuento(MiProducto.CodigoInternoProducto);
                    }
                    catch (Exception ex)
                    {
                        OptionPane.MessageError(ex.Message);
                    }
                }
            }
            else                   ///Recargo a factura
            {
                if (rbtnDesctoProducto.Checked)
                {
                    try
                    {
                        cbRecargoProducto.DataSource =
                            miBussinesRecargo.ListadoRecargo();//ListadoDeRecargo(MiProducto.CodigoInternoProducto);
                    }
                    catch (Exception ex)
                    {
                        OptionPane.MessageError(ex.Message);
                    }
                }
            }
        }

        private void ExpulsarCajonMonedero()
        {
            try
            {
                string caracteres = "";
                switch (this.miCaracteresEscape.Numero)
                {
                    case 3:
                        {
                            caracteres = Convert.ToString((char)Convert.ToInt32(this.miCaracteresEscape.Caracter_1)) +
                                         Convert.ToString((char)Convert.ToInt32(this.miCaracteresEscape.Caracter_2)) +
                                         Convert.ToString((char)Convert.ToInt32(this.miCaracteresEscape.Caracter_3));
                            break;
                        }
                    case 4:
                        {
                            caracteres = Convert.ToString((char)Convert.ToInt32(this.miCaracteresEscape.Caracter_1)) +
                                         Convert.ToString((char)Convert.ToInt32(this.miCaracteresEscape.Caracter_2)) +
                                         Convert.ToString((char)Convert.ToInt32(this.miCaracteresEscape.Caracter_3)) +
                                         Convert.ToString((char)Convert.ToInt32(this.miCaracteresEscape.Caracter_4));
                            break;
                        }
                    case 5:
                        {
                            caracteres = Convert.ToString((char)Convert.ToInt32(this.miCaracteresEscape.Caracter_1)) +
                                         Convert.ToString((char)Convert.ToInt32(this.miCaracteresEscape.Caracter_2)) +
                                         Convert.ToString((char)Convert.ToInt32(this.miCaracteresEscape.Caracter_3)) +
                                         Convert.ToString((char)Convert.ToInt32(this.miCaracteresEscape.Caracter_4)) +
                                         Convert.ToString((char)Convert.ToInt32(this.miCaracteresEscape.Caracter_5));
                            break;
                        }
                    case 6:
                        {
                            caracteres = Convert.ToString((char)Convert.ToInt32(this.miCaracteresEscape.Caracter_1)) +
                                         Convert.ToString((char)Convert.ToInt32(this.miCaracteresEscape.Caracter_2)) +
                                         Convert.ToString((char)Convert.ToInt32(this.miCaracteresEscape.Caracter_3)) +
                                         Convert.ToString((char)Convert.ToInt32(this.miCaracteresEscape.Caracter_4)) +
                                         Convert.ToString((char)Convert.ToInt32(this.miCaracteresEscape.Caracter_5)) +
                                         Convert.ToString((char)Convert.ToInt32(this.miCaracteresEscape.Caracter_6));
                            break;
                        }
                }
                RawPrinterHelper.SendStringToPrinter(AppConfiguracion.ValorSeccion("impresora"), caracteres);
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
        }


        private bool Venta = false;
        /// <summary>
        /// Completa la secuencia de datos de un formulario de estención.
        /// </summary>
        /// <param name="args">Objeto que encapsula la información del formulario.</param>
        void CompletaEventos_Completo(CompletaArgumentosDeEvento args)
        {
            /*try
            {
                miTallaYcolor = (TallaYcolor)args.MiObjeto;
                EstructurarConsulta();
            }
            catch { }*/

            try
            {
                if (Venta)
                {
                    var obj = (ObjectAbstract)args.MiObjeto;
                    if (obj.Id.Equals(10095))
                    {
                        miFormasPago = (List<DTO.Clases.FormaPago>)obj.Objeto;
                        CargarYguardarFacturaPos();
                    }
                    //miFormasPago = (List<DTO.Clases.FormaPago>)args.MiObjeto;

                    /*if (FacturaPos)
                    {
                        
                        CargarYguardarFacturaPos();
                    }
                    else
                    {
                        CargarYguardarFactura_();
                    }*/

                    Venta = false;
                }
            }
            catch { }

            try
            {
                ExtendForms = (bool)args.MiObjeto;
                this.Transfer = (bool)args.MiObjeto;
                if (ExtendForms)
                {
                    
                    txtCliente_KeyPress(this.txtCliente, new KeyPressEventArgs((char)Keys.Enter));
                }
                /*else
                {
                    ClienteMatch = false;
                    //txtCliente.Focus();
                    txtCodigoArticulo.Focus();
                }
                ExtendForms = false;*/
            }
            catch {   }

            try
            {
                if (this.ExtendForms)
                {
                    txtCliente.Text = (string)args.MiObjeto;
                    txtCliente_KeyPress(this.txtCliente, new KeyPressEventArgs((char)Keys.Enter));
                }
            }
            catch { }

            try
            {
                if (this.TransferIncBolsa)
                {
                    var obj = (ObjectAbstract)args.MiObjeto;
                    if (obj.Id == 88997766)
                    {
                        this.ImpstoBolsa = (ImpuestoBolsa)obj.Objeto;
                        this.txtIcoBolsaCant.Text = this.ImpstoBolsa.Cantidad.ToString();
                        this.txtIcoBolsaUnit.Text = this.ImpstoBolsa.Valor.ToString();
                        this.txtIcoBolsaTotal.Text = UseObject.InsertSeparatorMil(
                            (this.ImpstoBolsa.Cantidad * this.ImpstoBolsa.Valor).ToString());
                        this.CalcularTotal();
                        /*this.txtTotalMenosRete.Text = UseObject.InsertSeparatorMil(((UseObject.RemoveSeparatorMil(this.txtTotal.Text) +
                            UseObject.RemoveSeparatorMil(this.txtIcoBolsaTotal.Text)) - UseObject.RemoveSeparatorMil(this.txtRetencion.Text)).ToString());*/
                    }
                    this.TransferIncBolsa = false;
                }
            }
            catch { }
        }

        void CompletaEventosVenta_Completo(CompletaArgumentosDeEventoVenta args)
        {
            try
            {
                miTallaYcolor = (TallaYcolor)args.objeto;
                EstructurarConsulta();
            }
            catch { }
        }

        /*void CompletaEventosm_Completo(CompletaArgumentosDeEventom args)
        {
            try
            {
                var producto = (Producto)args.MiMarca;
                txtCodigoArticulo.Text = producto.CodigoInternoProducto;
                txtCodigoArticulo_KeyPress(this.txtCodigoArticulo, new KeyPressEventArgs((char)Keys.Enter));
            }
            catch { }
        }*/

        void CompletaEventos_CompTProductoFact(CompletaTransferProductFact args)
        {
            try
            {
                if (Transfer)
                {
                    DesctoAplica = 0;
                    var producto = (Producto)args.MiObjeto;
                    txtCodigoArticulo.Text = producto.CodigoInternoProducto;
                    DesctoAplica = producto.Descuento;
                    /* NumeroPrecio = producto.IdIva;
                     PrecioAplicar = Convert.ToInt32(producto.ValorVentaProducto);*/
                    txtCodigoArticulo_KeyPress(this.txtCodigoArticulo, new KeyPressEventArgs((char)Keys.Enter));
                    if (_ConsultaInventario)
                    {
                        Transfer = false;
                    }
                }
            }
            catch { }
        }

        List<RetencionConcepto> Retenciones { set; get; }

        void CompletaEventos_Completaz(CompletaArgumentosDeEventoz args)
        {
            try
            {
                Retenciones = Retenciones = (List<RetencionConcepto>)args.MiZona;
            }
            catch { }
        }

        private void CargarColorOconsulta()
        {
            if (MiProducto.AplicaTalla || MiProducto.AplicaColor)
            {
                if (!SingleSize || !SingleColor)
                {
                    btnTallaYcolor_Click(this.btnTallaYcolor, new EventArgs());
                }
                else
                {
                    EstructurarConsulta();
                }
            }
            else
            {
                EstructurarConsulta();
            }
        }

        /// <summary>
        /// Estructura la información en la tabla de memoria para ser visualizada.
        /// </summary>
        private void EstructurarConsulta()
        {
            var inventario = new DTO.Clases.Inventario();
            inventario.CodigoProducto = MiProducto.CodigoInternoProducto;
            Contador++;
            var row = miTabla.NewRow();
            row["Save"] = true;
            if (MiProducto.AplicaTalla)
            {
                inventario.IdMedida = miTallaYcolor.IdTalla;
                row["Unidad"] = "Talla";
                row["IdMedida"] = miTallaYcolor.IdTalla;
                row["Medida"] = miTallaYcolor.Talla;
            }
            else
            {
                inventario.IdMedida = miMedida.IdValorUnidadMedida;
                row["Unidad"] = miMedida.DescripcionUnidadMedida;
                row["IdMedida"] = miMedida.IdValorUnidadMedida;
                row["Medida"] = miMedida.DescripcionValorUnidadMedida;
            }
            if (MiProducto.AplicaColor)
            {
                inventario.IdColor = miTallaYcolor.IdColor;
                row["IdColor"] = miTallaYcolor.IdColor;
                row["Color"] = miTallaYcolor.Color;
            }
            else
            {
                row["IdColor"] = 0;
                row["Color"] = null;
            }
            row["IdMarca"] = this.MiProducto.IdMarca;
            row["IdTipoInventario"] = this.MiProducto.IdTipoInventario;
            row["IdIva"] = this.MiProducto.IdIva;
            if (!IdEstado.Equals(4))
            {
                try
                {
                    if (!FacturaNegativo)
                    {
                        inventario.Cantidad = miBussinesInventario.CantidadInventario(inventario);
                        if (inventario.Cantidad.Equals(0))
                        {
                            OptionPane.MessageError("El artículo no se puede Facturar ya que su inventario se encuentra en cero.");
                            return;
                        }
                        else
                        {
                            var cantFactura = miTabla.AsEnumerable().
                                Where(p => p.Field<string>("Codigo").Equals(inventario.CodigoProducto)
                                        && p.Field<int>("IdMedida").Equals(inventario.IdMedida)
                                        && p.Field<int>("IdColor").Equals(inventario.IdColor)).Sum
                                        (s => Convert.ToDouble(s.Field<string>("Cantidad")));
                            cantFactura += Convert.ToDouble(this.txtCantidad.Text.Replace('.', ','));
                            if (/*!FacturaNegativo && */(inventario.Cantidad < cantFactura))
                            {
                                OptionPane.MessageError
                                    ("El artículo no se puede Facturar ya que la(s) cantidad(es) exceden el inventario.");
                                return;
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    try
                    {
                        var j = (FormatException)ex.InnerException;
                    }
                    catch
                    {
                        OptionPane.MessageError(ex.Message);
                    }
                }
            }
            var valorUnitario = MiProducto.ValorVentaProducto;
            if (txtValorUnitario.Visible)
            {
                valorUnitario = UseObject.RemoveSeparatorMil(txtValorUnitario.Text);
            }

            if (!Convert.ToBoolean(AppConfiguracion.ValorSeccion("promedio"))) //Precio asignado
            {
                /* if (NumeroPrecio.Equals(1))
                 {*/
                //valorUnitario = MiProducto.ValorVentaProducto;
                //}
                /* else
                 {
                     valorUnitario = PrecioAplicar;
                 }*/
            }
            else  // Precio Promedio
            {
                inventario.Cantidad = Convert.ToInt32(AppConfiguracion.ValorSeccion("num_promedio"));
                var tProductos = miBussinesFacturaProveedor.ProductosDeFactura(inventario);
                var costo = 0;
                if (tProductos.Rows.Count != 0)
                {
                    var cant = 0.0;
                    var total = 0;
                    foreach (DataRow tRow in tProductos.Rows)
                    {
                        cant += Convert.ToDouble(tRow["cantidad"]);

                        var vUnit = Convert.ToInt32(tRow["valor"]) -
                            (Convert.ToInt32(tRow["valor"]) * Convert.ToInt32(tRow["descuento"]) / 100);
                        total += Convert.ToInt32(
                            (vUnit + Convert.ToInt32(vUnit * Convert.ToDouble(tRow["iva"]) / 100)) * Convert.ToDouble(tRow["cantidad"]));
                    }
                    costo = Convert.ToInt32(total / cant);
                }
                else
                {
                    costo = Convert.ToInt32(miBussinesProducto.PrecioDeCosto(MiProducto.CodigoInternoProducto));
                }

                if (Convert.ToBoolean(AppConfiguracion.ValorSeccion("calculo_util_multiplica")))  //Multiplica la utilidad
                {
                    /*costo*/
                    valorUnitario = Convert.ToInt32(costo + (costo * MiProducto.UtilidadPorcentualProducto / 100));
                }
                else  //  Divide la utilidad
                {
                    valorUnitario = Convert.ToInt32(costo / ((100 - MiProducto.UtilidadPorcentualProducto) / 100));
                }
            }
            // Antes
            /*if (MiProducto.AplicaPrecioPorcentaje)
            {
                try
                {
                    inventario.Cantidad = NumeroDeFacturas;
                    if (Promedio)
                    {
                        MiProducto.ValorVentaProducto = miBussinesProducto.PromedioValorProducto(inventario);
                    }
                    else
                    {
                        MiProducto.ValorVentaProducto = miBussinesProducto.UltimoValorProducto(inventario);
                    }
                }
                catch (Exception ex)
                {
                    OptionPane.MessageError(ex.Message);
                }
            }*/

            valorUnitario -= Convert.ToInt32(this.MiProducto.Impoconsumo);

            row["Id"] = Contador;
            row["Codigo"] = MiProducto.CodigoInternoProducto;
            row["Articulo"] = MiProducto.NombreProducto;
            row["Cantidad"] = Convert.ToDouble(this.txtCantidad.Text.Replace('.', ',')).ToString().Replace('.', ',');
            //row["Cantidad"] = txtCantidad.Text.Replace('.', ',');

            if (miEmpresa.Regimen.IdRegimen == 1)// this.IDIVAResponsability)  //Comun
            {
                if (Convert.ToBoolean(AppConfiguracion.ValorSeccion("precio_venta_iva"))) // Precios incluye IVA
                {
                    row["ValorUnitario"] = Math.Round((valorUnitario / (1 + (MiProducto.ValorIva / 100))), 1);
                }
                else
                {
                    row["ValorUnitario"] = valorUnitario;
                }
            }
            else
            {
                row["ValorUnitario"] = valorUnitario;
            }
            //var vunit = row["ValorUnitario"].ToString();

            //  Edición descarte de error en descuento mal asignado - validación para evitarlo - 06-05-2017
            row["Descuento"] = "0%";
            if (this.cliente.IdTipoCliente != 1)
            {
                switch (cliente.IdTipoCliente)
                {
                    case 2: // cliente mayorista
                        {
                            if (Convert.ToBoolean(AppConfiguracion.ValorSeccion("permitirDesctoMayor")))
                            {
                                row["Descuento"] = MiProducto.DescuentoMayor.ToString() + "%";
                                DesctoAplica = MiProducto.DescuentoMayor;
                            }
                            break;
                        }
                    case 3: // cliente distribuidor
                        {
                            if (Convert.ToBoolean(AppConfiguracion.ValorSeccion("permitirDesctoDistrib")))
                            {
                                row["Descuento"] = MiProducto.DescuentoDistribuidor.ToString() + "%";
                                DesctoAplica = MiProducto.DescuentoDistribuidor;
                            }
                            break;
                        }
                }
                /* row["ValorMenosDescto"] = Math.Round((Convert.ToDouble(row["ValorUnitario"]) -
                     (Convert.ToDouble(row["ValorUnitario"]) * UseObject.RemoveCharacter(row["Descuento"].ToString(), '%') / 100)), 1);*/
            }
            else
            {
                if (DesctoAplica > 0)
                {
                    // Ajuste para evitar descuento no convenido. 19-11-2017
                    if (Convert.ToBoolean(AppConfiguracion.ValorSeccion("permitirDesctoMayor")))
                    {
                        if (this.DesctoAplica == this.MiProducto.DescuentoMayor)
                        {
                            row["Descuento"] = this.MiProducto.DescuentoMayor.ToString() + "%";
                        }
                    }
                    if (Convert.ToBoolean(AppConfiguracion.ValorSeccion("permitirDesctoDistrib")))
                    {
                        if (this.DesctoAplica == this.MiProducto.DescuentoDistribuidor)
                        {
                            row["Descuento"] = this.MiProducto.DescuentoDistribuidor.ToString() + "%";
                        }
                    }

                    if (this.DesctoAplica == this.MiProducto.DescuentoPrecio4)
                    {
                        row["Descuento"] = this.MiProducto.DescuentoPrecio4.ToString() + "%";
                    }
                    // Fin ajuste


                    //row["Descuento"] = DesctoAplica.ToString() + "%";
                    /* row["ValorMenosDescto"] = Math.Round((Convert.ToDouble(row["ValorUnitario"]) -
                         (Convert.ToDouble(row["ValorUnitario"]) * UseObject.RemoveCharacter(row["Descuento"].ToString(), '%') / 100)), 1);*/
                }
            }

            row["ValorMenosDescto"] = Math.Round((Convert.ToDouble(row["ValorUnitario"]) -
                    (Convert.ToDouble(row["ValorUnitario"]) * UseObject.RemoveCharacter(row["Descuento"].ToString(), '%') / 100)), 1);

            var j_ = row["ValorMenosDescto"].ToString();

           /* if (this.MiProducto.Impoconsumo > 0)
            {
                double ventaMasIco = valorUnitario + this.MiProducto.Impoconsumo;
                double ventaMasIcoMenosDescto_ = Math.Round((ventaMasIco -
                    (ventaMasIco * UseObject.RemoveCharacter(row["Descuento"].ToString(), '%') / 100)), 1);
                ventaMasIcoMenosDescto_ -= this.MiProducto.Impoconsumo;

                if (miEmpresa.Regimen.IdRegimen == 1)  //Comun
                {
                    if (Convert.ToBoolean(AppConfiguracion.ValorSeccion("precio_venta_iva"))) // Precios incluye IVA
                    {
                        row["ValorMenosDescto"] = Math.Round((ventaMasIcoMenosDescto_ / (1 + (MiProducto.ValorIva / 100))), 1);
                    }
                    else
                    {
                        row["ValorMenosDescto"] = ventaMasIcoMenosDescto_;
                    }
                }
                else
                {
                    row["ValorMenosDescto"] = ventaMasIcoMenosDescto_;
                }
            }
            else
            {
                row["ValorMenosDescto"] = Math.Round((Convert.ToDouble(row["ValorUnitario"]) -
                    (Convert.ToDouble(row["ValorUnitario"]) * UseObject.RemoveCharacter(row["Descuento"].ToString(), '%') / 100)), 1);
            }*/

            // fin edicion por impoconsumo.

            /*if (DesctoAplica > 0)
            {
                row["Descuento"] = DesctoAplica.ToString() + "%";
                row["ValorMenosDescto"] = Math.Round((Convert.ToDouble(row["ValorUnitario"]) -
                    (Convert.ToDouble(row["ValorUnitario"]) * UseObject.RemoveCharacter(row["Descuento"].ToString(), '%') / 100)), 1);
                 //row["ValorMenosDescto"] = Convert.ToInt32(Convert.ToInt32(row["ValorUnitario"]) -
                   //      (Convert.ToInt32(row["ValorUnitario"]) * UseObject.RemoveCharacter(row["Descuento"].ToString(), '%') / 100));
            }
            else
            {
                row["Descuento"] = "0%";
                switch (cliente.IdTipoCliente)
                {
                    case 2: // cliente mayorista
                        {
                            if (Convert.ToBoolean(AppConfiguracion.ValorSeccion("permitirDesctoMayor")))
                            {
                                row["Descuento"] = MiProducto.DescuentoMayor.ToString() + "%";
                            }
                            break;
                        }
                    case 3: // cliente distribuidor
                        {
                            if (Convert.ToBoolean(AppConfiguracion.ValorSeccion("permitirDesctoDistrib")))
                            {
                                row["Descuento"] = MiProducto.DescuentoDistribuidor.ToString() + "%";
                            }
                            break;
                        }
                }
                row["ValorMenosDescto"] = Math.Round((Convert.ToDouble(row["ValorUnitario"]) -
                    (Convert.ToDouble(row["ValorUnitario"]) * UseObject.RemoveCharacter(row["Descuento"].ToString(), '%') / 100)), 1);
            }*/

            //  Fin Edición - 06-05-2017

            //var d = row["ValorMenosDescto"].ToString();

            row["Valor_"] = row["ValorMenosDescto"];
            row["Retorno"] = false;
            row["Ico"] = MiProducto.Impoconsumo;
            if (miEmpresa.Regimen.IdRegimen == 1)// this.IDIVAResponsability)  //Comun
            {
                row["Iva"] = MiProducto.ValorIva.ToString() + "%";
            }
            else
            {
                row["Iva"] = 0 + "%";
            }
            //(costo, Convert.ToBoolean(AppConfiguracion.ValorSeccion("calculo_util_multiplica")));
            // Calculo de IVA
            double vIva = Math.Round(
                    (Convert.ToDouble(row["ValorMenosDescto"]) *
                      UseObject.RemoveCharacter(row["Iva"].ToString(), '%') / 100), 1);

            row["ValorIva"] = vIva;

            /*int AvIva = UseObject.AproximacionDian(vIva);
            var vUnitario = Convert.ToInt32(row["ValorMenosDescto"]) + AvIva;*/

            var vUnitario = Convert.ToInt32(Convert.ToDouble(row["ValorMenosDescto"]) + vIva) + Convert.ToInt32(this.MiProducto.Impoconsumo);

            // Edicion precio producto 30 Julio de 2018

            if (DesctoAplica > 0)
            {
                if (this.RedondearPrecio2)
                {
                    row["TotalMasIva"] =
                        UseObject.Aproximar(vUnitario, Convert.ToBoolean(AppConfiguracion.ValorSeccion("tipo_aprox_precio")));
                }
                else
                {
                    row["TotalMasIva"] = vUnitario;
                }
            }
            else
            {
                row["TotalMasIva"] = vUnitario;
            }

            // Fin edicion precio producto 30 Julio de 2018



            // Edición precio producto  18 Feb 2017

            //row["TotalMasIva"] = vUnitario;

            //if (DesctoAplica > 0)
            //{
            /*row["TotalMasIva"] =
                UseObject.Aproximar(vUnitario, Convert.ToBoolean(AppConfiguracion.ValorSeccion("tipo_aprox_precio")));*/
            //}
            //else
            // {
            //    row["TotalMasIva"] = vUnitario;
            // }

            // End edición
            row["Valor"] = Convert.ToInt64(
                           Convert.ToDouble(row["TotalMasIva"]) *
                           Convert.ToDouble(row["Cantidad"]));//txtCantidad.Text);

            miTabla.Rows.Add(row);
            txtTotal.Text = UseObject.InsertSeparatorMil
                (
                   Convert.ToInt64(
                   miTabla.AsEnumerable().Sum(s => s.Field<double>("Valor"))
                   ).ToString()
                );
            RecargarRetencion();
            txtDescuentoFactura.Enabled = false;
            RecargarGridview();
            ColorearGrid();
            CalcularTotal();
            LimpiarCampos();
            LoadColorSize = false;
            btnTallaYcolor.Enabled = false;
            NumeroPrecio = 1;
            DesctoAplica = 0.0;
        }



        /// <summary>
        /// Recarga el DataGridView Productos segun los datos en el DataTable miTable.
        /// </summary>
        private void RecargarGridview()
        {
            IEnumerable<DataRow> query = from datos in miTabla.AsEnumerable()
                                         orderby datos.Field<int>("Id") descending
                                         select datos;
            DataTable copy = query.CopyToDataTable<DataRow>();
            miBindingSource.DataSource = copy;
        }

        private void CalcularTotal()
        {
            this.txtTotal.Text = UseObject.InsertSeparatorMil
                (
                   Convert.ToInt64(
                   this.miTabla.AsEnumerable().Sum(s => s.Field<double>("Valor"))
                   ).ToString()
                );
            this.txtSubtotal.Text = this.txtTotal.Text;
            this.txtTotal.Text = UseObject.InsertSeparatorMil(((UseObject.RemoveSeparatorMil(this.txtSubtotal.Text) +
                        UseObject.RemoveSeparatorMil(this.txtIcoBolsaTotal.Text)) - UseObject.RemoveSeparatorMil(this.txtRetencion.Text)).ToString());
        }

        /// <summary>
        /// Limpia los campos de Producto del Formulario.
        /// </summary>
        private void LimpiarCampos()
        {
            this.txtCodigoArticulo.Focus();
            this.txtCodigoArticulo.Text = "";
            txtCantidad.Text = "1";

            if (cbDescuentoProducto.Enabled)
            {
                cbDescuentoProducto.SelectedIndex = 0;
            }
            if (cbRecargoProducto.Enabled)
            {
                cbRecargoProducto.SelectedIndex = 0;
            }
            //cbDescuentoProducto.DataSource = null;
            //cbRecargoProducto.DataSource = null;
            //lblDatosProducto.Text = "";
            txtValorUnitario.Text = "0";
            MiProducto = null;
            miTallaYcolor.IdColor = 0;
            miTallaYcolor.IdTalla = 0;
            miTallaYcolor.Talla = "";
            miTallaYcolor.Color = null;
            DesctoAplica = 0;
        }

        /// <summary>
        /// Actualiza la información de la factura cuando se realiza un cambio en ella.
        /// </summary>
        /// <param name="rowIndex">Índex del registro de la lista a modificar.</param>
        /// <param name="valor">Valor a modificar en el registro seleccionado.</param>
        private void ActualizarInformacion(int rowIndex, string valor)
        {
            //var gRow = this.dgvListaArticulos.Rows[e.RowIndex];
            //  if (!Convert.ToBoolean(gRow.Cells["Retorno"].Value))
            //  {

            var id = Convert.ToInt32(dgvListaArticulos.Rows[rowIndex].Cells["Id"].Value);
            var query = (from datos in miTabla.AsEnumerable()
                         where datos.Field<int>("Id") == id
                         select datos).Single();
            var index = miTabla.Rows.IndexOf(query);

            if (!Convert.ToBoolean(this.dgvListaArticulos.Rows[rowIndex].Cells["Retorno"].Value))
            {
                miTabla.Rows[index]["ValorUnitario"] = Math.Round(((Convert.ToInt32(valor) - Convert.ToInt32(miTabla.Rows[index]["Ico"])) /
                    ((UseObject.RemoveCharacter(miTabla.Rows[index]["Iva"].ToString(), '%') / 100) + 1)), 1);
                //}


                //  var vunit = miTabla.Rows[index]["ValorUnitario"].ToString();

                miTabla.Rows[index]["Descuento"] = "0%";

                var d = miTabla.Rows[index]["ValorUnitario"].ToString();

                miTabla.Rows[index]["ValorMenosDescto"] =
                    Convert.ToDouble(Convert.ToDouble(miTabla.Rows[index]["ValorUnitario"]) +
                    (Convert.ToInt32(miTabla.Rows[index]["ValorUnitario"]) *
                    UseObject.RemoveCharacter(miTabla.Rows[index]["Descuento"].ToString(), '%') / 100));

                var v_des = miTabla.Rows[index]["ValorMenosDescto"].ToString();

                double vIva = Math.Round((
                              Convert.ToDouble(miTabla.Rows[index]["ValorMenosDescto"]) *
                              UseObject.RemoveCharacter(miTabla.Rows[index]["Iva"].ToString(), '%') / 100), 1);
                //int aVIva = UseObject.AproximacionDian(vIva);

                var totalMasIva = Convert.ToInt32(Convert.ToDouble(miTabla.Rows[index]["ValorMenosDescto"]) + vIva + Convert.ToInt32(miTabla.Rows[index]["Ico"]));

                miTabla.Rows[index]["TotalMasIva"] = totalMasIva;
                //miTabla.Rows[index]["TotalMasIva"] = UseObject.Aproximar(totalMasIva, Convert.ToBoolean(AppConfiguracion.ValorSeccion("tipo_aprox_precio")));

                //Convert.ToDouble(miTabla.Rows[index]["ValorMenosDescto"]) + aVIva;
                var tmasiva = miTabla.Rows[index]["TotalMasIva"].ToString();

                /*miTabla.Rows[index]["TotalMasIva"] =
                    (Convert.ToDouble(miTabla.Rows[index]["ValorMenosDescto"]) *
                    UseObject.RemoveCharacter(miTabla.Rows[index]["Iva"].ToString(), '%') / 100) +
                    Convert.ToDouble(miTabla.Rows[index]["ValorMenosDescto"]);*/

                miTabla.Rows[index]["Valor"] =
                    Convert.ToDouble(miTabla.Rows[index]["TotalMasIva"]) *
                    Convert.ToDouble(miTabla.Rows[index]["Cantidad"]);
                var v = miTabla.Rows[index]["Valor"].ToString();

                RecargarGridview();
                txtTotal.Text = UseObject.InsertSeparatorMil
                    (
                       Convert.ToInt32(
                       miTabla.AsEnumerable().Sum(s => s.Field<double>("Valor"))
                       ).ToString()
                    );
                RecargarRetencion();
                this.CalcularTotal();
                ColorearGrid();

                dgvListaArticulos.Focus();
                txtCodigoArticulo.Focus();

            }
            else
            {
                RecargarRetencion();
                RecargarGridview();
                this.CalcularTotal();
                ColorearGrid();
                dgvListaArticulos.Focus();
                txtCodigoArticulo.Focus();
            }
        }

        private void ActualizarInformacionCantidad(int rowIndex, string valor)
        {
            var id = Convert.ToInt32(dgvListaArticulos.Rows[rowIndex].Cells["Id"].Value);
            var query = (from datos in miTabla.AsEnumerable()
                         where datos.Field<int>("Id") == id
                         select datos).Single();
            var index = miTabla.Rows.IndexOf(query);

            /*miTabla.Rows[index]["ValorUnitario"] = Math.Round((Convert.ToInt32(valor) /
                ((UseObject.RemoveCharacter(miTabla.Rows[index]["Iva"].ToString(), '%') / 100) + 1)), 1);
            var vunit = miTabla.Rows[index]["ValorUnitario"].ToString();*/

            if (!Convert.ToBoolean(this.dgvListaArticulos.Rows[rowIndex].Cells["Retorno"].Value))
            {
                miTabla.Rows[index]["Cantidad"] = valor.Replace('.', ',');

                miTabla.Rows[index]["Descuento"] = "0%";

                var d = miTabla.Rows[index]["ValorUnitario"].ToString();

                miTabla.Rows[index]["ValorMenosDescto"] =
                    Convert.ToDouble(Convert.ToDouble(miTabla.Rows[index]["ValorUnitario"]) +
                    (Convert.ToInt32(miTabla.Rows[index]["ValorUnitario"]) *
                    UseObject.RemoveCharacter(miTabla.Rows[index]["Descuento"].ToString(), '%') / 100));

                var v_des = miTabla.Rows[index]["ValorMenosDescto"].ToString();

                double vIva = Math.Round((
                              Convert.ToDouble(miTabla.Rows[index]["ValorMenosDescto"]) *
                              UseObject.RemoveCharacter(miTabla.Rows[index]["Iva"].ToString(), '%') / 100), 1);

                var totalMasIva = Convert.ToInt32(Convert.ToDouble(miTabla.Rows[index]["ValorMenosDescto"]) + vIva);

                miTabla.Rows[index]["TotalMasIva"] = totalMasIva;
                var tmasiva = miTabla.Rows[index]["TotalMasIva"].ToString();

                miTabla.Rows[index]["Valor"] =
                    Convert.ToDouble(miTabla.Rows[index]["TotalMasIva"]) *
                    Convert.ToDouble(miTabla.Rows[index]["Cantidad"]);
                var v = miTabla.Rows[index]["Valor"].ToString();

                RecargarGridview();
                ColorearGrid();
                txtTotal.Text = UseObject.InsertSeparatorMil
                    (
                       Convert.ToInt32(
                       miTabla.AsEnumerable().Sum(s => s.Field<double>("Valor"))
                       ).ToString()
                    );
                RecargarRetencion();
                dgvListaArticulos.Focus();
                txtCodigoArticulo.Focus();
            }
            else
            {
                RecargarRetencion();
                RecargarGridview();
                ColorearGrid();
                dgvListaArticulos.Focus();
                txtCodigoArticulo.Focus();
            }
        }

        // Edicion 13-01-2017
        private void ActualizarInformacionCantidadNew_(int rowIndex, string valor)
        {
            var id = Convert.ToInt32(dgvListaArticulos.Rows[rowIndex].Cells["Id"].Value);
            var query = (from datos in miTabla.AsEnumerable()
                         where datos.Field<int>("Id") == id
                         select datos).Single();
            var index = miTabla.Rows.IndexOf(query);

            var tMasIva = miTabla.Rows[index]["TotalMasIva"].ToString();

            /*miTabla.Rows[index]["ValorUnitario"] = Math.Round((Convert.ToInt32(valor) /
                ((UseObject.RemoveCharacter(miTabla.Rows[index]["Iva"].ToString(), '%') / 100) + 1)), 1);
            var vunit = miTabla.Rows[index]["ValorUnitario"].ToString();*/

            if (!Convert.ToBoolean(this.dgvListaArticulos.Rows[rowIndex].Cells["Retorno"].Value))
            {
                miTabla.Rows[index]["Cantidad"] = valor.Replace('.', ',');

                //miTabla.Rows[index]["Descuento"] = "0%";

                var d = miTabla.Rows[index]["ValorUnitario"].ToString();

                /*  miTabla.Rows[index]["ValorMenosDescto"] =
                      Convert.ToDouble(Convert.ToDouble(miTabla.Rows[index]["ValorUnitario"]) +
                      (Convert.ToInt32(miTabla.Rows[index]["ValorUnitario"]) *
                      UseObject.RemoveCharacter(miTabla.Rows[index]["Descuento"].ToString(), '%') / 100));*/

                var v_des = Convert.ToDouble(miTabla.Rows[index]["ValorMenosDescto"]);

                double vIva = Math.Round((
                              Convert.ToDouble(miTabla.Rows[index]["ValorMenosDescto"]) *
                              UseObject.RemoveCharacter(miTabla.Rows[index]["Iva"].ToString(), '%') / 100), 1);

                var totalMasIva = Convert.ToInt32(Convert.ToDouble(miTabla.Rows[index]["ValorMenosDescto"]) + vIva);

                // Edición precio producto  18 Feb 2017

                //miTabla.Rows[index]["TotalMasIva"] = totalMasIva;

                //miTabla.Rows[index]["TotalMasIva"] = totalMasIva;  // edicion no redondeo
                if (v_des > 0)
                {
                    if (this.RedondearPrecio2)
                    {
                        miTabla.Rows[index]["TotalMasIva"] =
                            UseObject.Aproximar(totalMasIva, Convert.ToBoolean(AppConfiguracion.ValorSeccion("tipo_aprox_precio")));
                    }
                    else
                    {
                        miTabla.Rows[index]["TotalMasIva"] = totalMasIva;
                    }
                }
                else
                {
                    miTabla.Rows[index]["TotalMasIva"] = totalMasIva;
                }
                // Edicion no redondeo

                // End edición
                var tmasiva = miTabla.Rows[index]["TotalMasIva"].ToString();

                miTabla.Rows[index]["Valor"] =
                    Convert.ToDouble(miTabla.Rows[index]["TotalMasIva"]) *
                    Convert.ToDouble(miTabla.Rows[index]["Cantidad"]);
                var v = miTabla.Rows[index]["Valor"].ToString();

                RecargarGridview();
                ColorearGrid();
                txtTotal.Text = UseObject.InsertSeparatorMil
                    (
                       Convert.ToInt32(
                       miTabla.AsEnumerable().Sum(s => s.Field<double>("Valor"))
                       ).ToString()
                    );
                RecargarRetencion();
                this.CalcularTotal();
                dgvListaArticulos.Focus();
                txtCodigoArticulo.Focus();
            }
            else
            {
                RecargarRetencion();
                RecargarGridview();
                this.CalcularTotal();
                ColorearGrid();
                dgvListaArticulos.Focus();
                txtCodigoArticulo.Focus();
            }
        }

        private void ActualizarInformacionCantidadNew(int rowIndex, string valor)
        {
            var id = Convert.ToInt32(dgvListaArticulos.Rows[rowIndex].Cells["Id"].Value);
            var query = (from datos in miTabla.AsEnumerable()
                         where datos.Field<int>("Id") == id
                         select datos).Single();
            var index = miTabla.Rows.IndexOf(query);

            if (!Convert.ToBoolean(this.dgvListaArticulos.Rows[rowIndex].Cells["Retorno"].Value))
            {
                this.miTabla.Rows[index]["Cantidad"] = valor.Replace('.', ',');

                this.miTabla.Rows[index]["Valor"] =
                    Convert.ToDouble(this.miTabla.Rows[index]["TotalMasIva"]) *
                    Convert.ToDouble(this.miTabla.Rows[index]["Cantidad"]);
                //var v = miTabla.Rows[index]["Valor"].ToString();

                this.RecargarGridview();
                this.ColorearGrid();
                this.txtTotal.Text = UseObject.InsertSeparatorMil
                    (
                       Convert.ToInt32(
                       this.miTabla.AsEnumerable().Sum(s => s.Field<double>("Valor"))
                       ).ToString()
                    );
                this.RecargarRetencion();
                this.CalcularTotal();
                this.dgvListaArticulos.Focus();
                this.txtCodigoArticulo.Focus();
            }
            else
            {
                this.RecargarRetencion();
                this.RecargarGridview();
                this.CalcularTotal();
                this.ColorearGrid();
                this.dgvListaArticulos.Focus();
                this.txtCodigoArticulo.Focus();
            }
        }

        /*
        private void ActualizarInformacionInversa(int rowIndex, string valor)
        {
            var id = Convert.ToInt32(dgvListaArticulos.Rows[rowIndex].Cells["Id"].Value);
            var query = (from datos in miTabla.AsEnumerable()
                         where datos.Field<int>("Id") == id
                         select datos).Single();
            var index = miTabla.Rows.IndexOf(query);

            miTabla.Rows[index]["ValorUnitario"] = Math.Round((Convert.ToInt32(valor) /
                ((UseObject.RemoveCharacter(miTabla.Rows[index]["Iva"].ToString(), '%') / 100) + 1)), 1);

            //var d = miTabla.Rows[index]["ValorUnitario"].ToString();

            miTabla.Rows[index]["ValorMenosDescto"] =
                Convert.ToDouble(Convert.ToDouble(miTabla.Rows[index]["ValorUnitario"]) +
                (Convert.ToInt32(miTabla.Rows[index]["ValorUnitario"]) *
                UseObject.RemoveCharacter(miTabla.Rows[index]["Descuento"].ToString(), '%') / 100));

            var v_des = miTabla.Rows[index]["ValorMenosDescto"].ToString();

            double vIva = Math.Round((
                          Convert.ToDouble(miTabla.Rows[index]["ValorMenosDescto"]) *
                          UseObject.RemoveCharacter(miTabla.Rows[index]["Iva"].ToString(), '%') / 100), 1);
            int aVIva = UseObject.AproximacionDian(vIva);

            var totalMasIva = Convert.ToInt32(miTabla.Rows[index]["ValorMenosDescto"]) + aVIva;

            miTabla.Rows[index]["TotalMasIva"] = totalMasIva;
            //miTabla.Rows[index]["TotalMasIva"] = UseObject.Aproximar(totalMasIva, Convert.ToBoolean(AppConfiguracion.ValorSeccion("tipo_aprox_precio")));

            //Convert.ToDouble(miTabla.Rows[index]["ValorMenosDescto"]) + aVIva;
            var tmasiva = miTabla.Rows[index]["TotalMasIva"].ToString();

            miTabla.Rows[index]["Valor"] =
                Convert.ToDouble(miTabla.Rows[index]["TotalMasIva"]) *
                Convert.ToDouble(miTabla.Rows[index]["Cantidad"]);
            var v = miTabla.Rows[index]["Valor"].ToString();

            RecargarGridview();
            txtTotal.Text = UseObject.InsertSeparatorMil
                (
                   Convert.ToInt32(
                   miTabla.AsEnumerable().Sum(s => s.Field<double>("Valor"))
                   ).ToString()
                );
            RecargarRetencion();
            dgvListaArticulos.Focus();
            txtCodigoArticulo.Focus();
        }
        */

        private void RealizarVenta_()
        {
            if (dgvListaArticulos.RowCount != 0)
            {
                if (RegistroHabil())
                {
                    if (IdEstado == 1)
                    {
                        /*if (!ExtendForms)
                        {*/
                        /* if (NitCliente.Equals("1000"))
                         {*/
                        /*Venta = true;
                        var frmCancelarVenta = new FrmDinamicCancelar();
                        frmCancelarVenta.txtTotal.Text = txtTotalMenosRete.Text;
                        frmCancelarVenta.ShowDialog();*/

                        if (Convert.ToBoolean(AppConfiguracion.ValorSeccion("btq")))
                        {
                            //var frmCancelarVenta = new FrmCancelarVenta();
                            var frmCancelarVenta = new FrmCancelarVenta2();
                            frmCancelarVenta.FacturaPos = true;
                            frmCancelarVenta.txtTotal.Text = this.txtTotal.Text; //txtTotalMenosRete.Text;//txtTotal.Text;
                            frmCancelarVenta.EsVenta = true;
                            Venta = true;
                            frmCancelarVenta.ShowDialog();
                        }
                        else
                        {
                            var frmCancelarVenta = new FrmCancelarVenta();
                            frmCancelarVenta.FacturaPos = true;
                            //var frmCancelarVenta = new FrmCancelarVenta2();
                            frmCancelarVenta.txtTotal.Text = this.txtTotal.Text; //txtTotalMenosRete.Text;//txtTotal.Text;
                            frmCancelarVenta.EsVenta = true;
                            Venta = true;
                            frmCancelarVenta.ShowDialog();
                        }
                        this.Transfer = true;
                        /*  var frmCancelarVenta = new FrmCancelarVenta();
                          //var frmCancelarVenta = new FrmCancelarVenta2();
                          frmCancelarVenta.txtTotal.Text = txtTotalMenosRete.Text;//txtTotal.Text;
                          frmCancelarVenta.EsVenta = true;
                          Venta = true;
                          frmCancelarVenta.ShowDialog();*/


                        /*try
                        {
                            var adelantos = miBussinesSaldo.SaldoEnAdelantos(NitCliente);
                            var bonos = miBussinesBono.SaldoEnBonos(NitCliente);
                            Venta = true;
                            var frmCancelaVenta = new FrmCancelarVentaSaldo();
                            frmCancelaVenta.txtTotal.Text = txtTotalMenosRete.Text;//txtTotal.Text;
                            frmCancelaVenta.txtAdelantoC.Text = UseObject.InsertSeparatorMil(adelantos.ToString());
                            frmCancelaVenta.txtBonoC.Text = UseObject.InsertSeparatorMil(bonos.ToString());
                            //frmCancelaVenta.MdiParent = this.MdiParent;
                            frmCancelaVenta.ShowDialog();
                        }
                        catch (Exception ex)
                        {
                            OptionPane.MessageError(ex.Message);
                        }*/

                        /*}
                        else
                        {*/
                        /* try
                         {
                             var adelantos = miBussinesSaldo.SaldoEnAdelantos(NitCliente);
                             var bonos = miBussinesBono.SaldoEnBonos(NitCliente);
                             Venta = true;
                             var frmCancelaVenta = new FrmCancelarVentaSaldo();
                             frmCancelaVenta.txtTotal.Text = txtTotalMenosRete.Text;//txtTotal.Text;
                             frmCancelaVenta.txtAdelantoC.Text = UseObject.InsertSeparatorMil(adelantos.ToString());
                             frmCancelaVenta.txtBonoC.Text = UseObject.InsertSeparatorMil(bonos.ToString());
                             frmCancelaVenta.MdiParent = this.MdiParent;
                             frmCancelaVenta.Show();
                         }
                         catch (Exception ex)
                         {
                             OptionPane.MessageError(ex.Message);
                         }*/
                        //}

                        //}
                    }
                    else
                    {
                        txtCliente_KeyPress(this.txtCliente, new KeyPressEventArgs((char)Keys.Enter));
                        if (ClienteMatch)
                        {
                            var msn = "";
                            if (IdEstado != 4)
                            {
                                msn = "¿Esta seguro de querer hacer la venta?";
                            }
                            else
                            {
                                msn = "¿Esta seguro de querer hacer la cotización?";
                            }
                            DialogResult rta = MessageBox.Show(msn, "Factura Venta",
                                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                            if (rta.Equals(DialogResult.Yes))
                            {
                                if (FacturaPos)
                                {
                                    CargarYguardarFacturaPos();
                                }
                                else
                                {
                                    CargarYguardarFactura_();
                                }
                            }
                        }
                    }
                }
                else
                {
                    OptionPane.MessageInformation("Debe cargar al menos un producto sin retorno.");
                }
            }
            else
            {
                OptionPane.MessageInformation("Debe cargar al menos un producto para realizar la venta.");
            }
        }

        bool usuarioIdentificado = false;

        private void RealizarVenta()
        {
            try
            {
                if (dgvListaArticulos.RowCount != 0 && UseObject.RemoveSeparatorMil(txtTotal.Text) > 0)
                {
                    if (RegistroHabil())
                    {
                        /// Codigo para la identificación del usuario.
                        if (CambioUsuario)
                        {
                            string rtaUser = "";
                            usuarioIdentificado = false;
                            while (!usuarioIdentificado)
                            {
                                rtaUser = OptionPane.OptionBox("Ingrese código de usuario", "Factura de venta", OptionPane.Icon.LoginAdmin);
                                if (rtaUser.Equals("false"))
                                {
                                    break;
                                }
                                else
                                {
                                    if (!String.IsNullOrEmpty(rtaUser))
                                    {
                                        usuarioIdentificado = miBussinesUsuario.ExisteDocumento(Convert.ToInt32(rtaUser));
                                        if (usuarioIdentificado)
                                        {
                                            Usuario_ = miBussinesUsuario.Usuario_(Convert.ToInt32(rtaUser));

                                            VentaContadoCredito();

                                            /// Codigo para recargar permisos de usuario
                                            AppConfiguracion.SaveConfiguration("id_user", Usuario_.Id.ToString());
                                            var frmPrincipal_ = (Principal.frmPrincipal)this.MdiParent;
                                            frmPrincipal_.InhabilitarMenu();
                                            frmPrincipal_.HabilitarMenu(Usuario_);

                                            this.EditarPrecioPermiso = false;
                                            this.ResetVentaPermiso = false;
                                            this.SeleccionPendiente = false;
                                            this.SeleccionCotizacion = false;
                                            foreach (var ps in Usuario_.Permisos)
                                            {
                                                switch (ps.IdPermiso)
                                                {
                                                    case IdEditarPrecio:
                                                        {
                                                            this.EditarPrecioPermiso = true;
                                                            break;
                                                        }
                                                    case IdResetVenta:
                                                        {
                                                            this.ResetVentaPermiso = true;
                                                            break;
                                                        }
                                                    case IdSeleccionPendiente:
                                                        {
                                                            this.SeleccionPendiente = true;
                                                            break;
                                                        }
                                                    case IdSeleccionCotizacion:
                                                        {
                                                            this.SeleccionCotizacion = true;
                                                            break;
                                                        }
                                                }
                                            }
                                            CargarUtilidades();
                                        }
                                    }
                                }
                            }
                        }
                        else
                        {
                            VentaContadoCredito();
                        }
                        /*string rtaUser = "";
                        usuarioIdentificado = false;
                        while (!usuarioIdentificado)
                        {
                            rtaUser = OptionPane.OptionBox("Ingrese código de usuario", "Factura de venta", OptionPane.Icon.LoginAdmin);
                            if (rtaUser.Equals("false"))
                            {
                                break;
                            }
                            else
                            {
                                usuarioIdentificado = miBussinesUsuario.ExisteDocumento(Convert.ToInt32(rtaUser));
                                if (usuarioIdentificado)
                                {
                                    Usuario_ = miBussinesUsuario.Usuario_(Convert.ToInt32(rtaUser));*/

                                    /**
                                    if (IdEstado == 1)
                                    {
                                        DialogResult rta_ = DialogResult.Yes;
                                        if (this.miBono.Canje)
                                        {
                                            //int v = UseObject.RetiraDecima(UseObject.RemoveSeparatorMil(this.txtTotal.Text) / this.miBono.Valor);
                                            if (UseObject.RetiraDecima(UseObject.RemoveSeparatorMil(this.txtTotal.Text) / this.miBono.Valor) > 0)
                                            {
                                                if (this.txtCliente.Text == "1000" || this.txtCliente.Text == "10")
                                                {
                                                    rta_ = MessageBox.Show("¿Desea generar la factura sin cliente?", "Factura venta",
                                                        MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                                                }
                                            }
                                        }

                                        if (rta_.Equals(DialogResult.Yes))
                                        {
                                            if (Convert.ToBoolean(AppConfiguracion.ValorSeccion("btq")))
                                            {
                                                var frmCancelarVenta = new FrmCancelarVenta2();
                                                frmCancelarVenta.FacturaPos = true;
                                                frmCancelarVenta.txtTotal.Text = this.txtTotal.Text;
                                                frmCancelarVenta.EsVenta = true;
                                                Venta = true;
                                                frmCancelarVenta.ShowDialog();
                                            }
                                            else
                                            {
                                                var frmCancelarVenta = new FrmCancelarVenta();
                                                frmCancelarVenta.FacturaPos = true;

                                                frmCancelarVenta.txtIva.Text = UseObject.InsertSeparatorMil(Convert.ToInt32(miTabla.AsEnumerable().
                                                    Sum(s => (s.Field<double>("ValorIva") * Convert.ToDouble(s.Field<string>("Cantidad"))))).ToString());


                                                frmCancelarVenta.txtBase.Text = UseObject.InsertSeparatorMil((UseObject.RemoveSeparatorMil(txtTotal.Text) -
                                                    UseObject.RemoveSeparatorMil(frmCancelarVenta.txtIva.Text)).ToString());

                                                frmCancelarVenta.txtTotal.Text = this.txtTotal.Text;
                                                frmCancelarVenta.EsVenta = true;
                                                Venta = true;
                                                frmCancelarVenta.ShowDialog();
                                            }
                                            this.Transfer = true;
                                        }
                                        else
                                        {
                                            this.txtCliente.Focus();
                                        }
                                    }
                                    else
                                    {
                                        txtCliente_KeyPress(this.txtCliente, new KeyPressEventArgs((char)Keys.Enter));
                                        if (ClienteMatch)
                                        {
                                            var msn = "";
                                            if (IdEstado != 4)
                                            {
                                                msn = "¿Esta seguro de querer hacer la venta?";
                                            }
                                            else
                                            {
                                                msn = "¿Esta seguro de querer hacer la cotización?";
                                            }
                                            DialogResult rta = MessageBox.Show(msn, "Factura Venta",
                                                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                                            if (rta.Equals(DialogResult.Yes))
                                            {
                                                if (FacturaPos)
                                                {
                                                    CargarYguardarFacturaPos();
                                                }
                                                else
                                                {
                                                    CargarYguardarFactura_();
                                                }
                                            }
                                        }
                                    }*/

                                    /// Codigo para recargar permisos de usuario
                                    /*AppConfiguracion.SaveConfiguration("id_user", Usuario_.Id.ToString()); 
                                    var frmPrincipal_ = (Principal.frmPrincipal)this.MdiParent;
                                    frmPrincipal_.InhabilitarMenu();
                                    frmPrincipal_.HabilitarMenu(Usuario_);
                                    foreach (var ps in Usuario_.Permisos)
                                    {
                                        switch (ps.IdPermiso)
                                        {
                                            case IdEditarPrecio:
                                                {
                                                    this.EditarPrecioPermiso = true;
                                                    break;
                                                }
                                            case IdResetVenta:
                                                {
                                                    this.ResetVentaPermiso = true;
                                                    break;
                                                }
                                            case IdSeleccionPendiente:
                                                {
                                                    this.SeleccionPendiente = true;
                                                    break;
                                                }
                                            case IdSeleccionCotizacion:
                                                {
                                                    this.SeleccionCotizacion = true;
                                                    break;
                                                }
                                        }
                                    }

                                }
                            }
                        }*/

                        /**
                        if (IdEstado == 1)
                        {
                            DialogResult rta_ = DialogResult.Yes;
                            if (this.miBono.Canje)
                            {
                                //int v = UseObject.RetiraDecima(UseObject.RemoveSeparatorMil(this.txtTotal.Text) / this.miBono.Valor);
                                if (UseObject.RetiraDecima(UseObject.RemoveSeparatorMil(this.txtTotal.Text) / this.miBono.Valor) > 0)
                                {
                                    if (this.txtCliente.Text == "1000" || this.txtCliente.Text == "10")
                                    {
                                        rta_ = MessageBox.Show("¿Desea generar la factura sin cliente?", "Factura venta",
                                            MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                                    }
                                }
                            }

                            if (rta_.Equals(DialogResult.Yes))
                            {
                                if (Convert.ToBoolean(AppConfiguracion.ValorSeccion("btq")))
                                {
                                    var frmCancelarVenta = new FrmCancelarVenta2();
                                    frmCancelarVenta.FacturaPos = true;
                                    frmCancelarVenta.txtTotal.Text = this.txtTotal.Text;
                                    frmCancelarVenta.EsVenta = true;
                                    Venta = true;
                                    frmCancelarVenta.ShowDialog();
                                }
                                else
                                {
                                    var frmCancelarVenta = new FrmCancelarVenta();
                                    frmCancelarVenta.FacturaPos = true;

                                    frmCancelarVenta.txtIva.Text = UseObject.InsertSeparatorMil(Convert.ToInt32(miTabla.AsEnumerable().
                                        Sum(s => (s.Field<double>("ValorIva") * Convert.ToDouble(s.Field<string>("Cantidad"))))).ToString());


                                    frmCancelarVenta.txtBase.Text = UseObject.InsertSeparatorMil((UseObject.RemoveSeparatorMil(txtTotal.Text) - 
                                        UseObject.RemoveSeparatorMil(frmCancelarVenta.txtIva.Text)).ToString());

                                    frmCancelarVenta.txtTotal.Text = this.txtTotal.Text;
                                    frmCancelarVenta.EsVenta = true;
                                    Venta = true;
                                    frmCancelarVenta.ShowDialog();
                                }
                                this.Transfer = true;
                            }
                            else
                            {
                                this.txtCliente.Focus();
                            }
                        }
                        else
                        {
                            txtCliente_KeyPress(this.txtCliente, new KeyPressEventArgs((char)Keys.Enter));
                            if (ClienteMatch)
                            {
                                var msn = "";
                                if (IdEstado != 4)
                                {
                                    msn = "¿Esta seguro de querer hacer la venta?";
                                }
                                else
                                {
                                    msn = "¿Esta seguro de querer hacer la cotización?";
                                }
                                DialogResult rta = MessageBox.Show(msn, "Factura Venta",
                                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                                if (rta.Equals(DialogResult.Yes))
                                {
                                    if (FacturaPos)
                                    {
                                        CargarYguardarFacturaPos();
                                    }
                                    else
                                    {
                                        CargarYguardarFactura_();
                                    }
                                }
                            }
                        }
                        */

                    }
                    else
                    {
                        OptionPane.MessageInformation("Debe cargar al menos un producto sin retorno.");
                    }
                }
                else
                {
                    OptionPane.MessageInformation("Debe cargar al menos un producto para realizar la venta.");
                }
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
        }

        private bool RegistroHabil()
        {
            bool existe = false;
            foreach (DataGridViewRow gRow in this.dgvListaArticulos.Rows)
            {
                if (!Convert.ToBoolean(gRow.Cells["Retorno"].Value))
                {
                    existe = true;
                }
            }
            return existe;
        }

        private void VentaContadoCredito()
        {
            if (IdEstado == 1)
            {
                DialogResult rta_ = DialogResult.Yes;
                if (this.miBono.Canje)
                {
                    //int v = UseObject.RetiraDecima(UseObject.RemoveSeparatorMil(this.txtTotal.Text) / this.miBono.Valor);
                    if (UseObject.RetiraDecima(UseObject.RemoveSeparatorMil(this.txtTotal.Text) / this.miBono.Valor) > 0)
                    {
                        if (this.txtCliente.Text == "1000" || this.txtCliente.Text == "10")
                        {
                            rta_ = MessageBox.Show("¿Desea generar la factura sin cliente?", "Factura venta",
                                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        }
                    }
                }

                if (rta_.Equals(DialogResult.Yes))
                {
                    if (Convert.ToBoolean(AppConfiguracion.ValorSeccion("btq")))
                    {
                        var frmCancelarVenta = new FrmCancelarVenta2();
                        frmCancelarVenta.FacturaPos = true;
                        frmCancelarVenta.txtTotal.Text = this.txtTotal.Text;
                        frmCancelarVenta.EsVenta = true;
                        Venta = true;
                        frmCancelarVenta.ShowDialog();
                    }
                    else
                    {
                        var frmCancelarVenta = new FrmCancelarVenta();
                        frmCancelarVenta.FacturaPos = true;

                        frmCancelarVenta.txtIva.Text = UseObject.InsertSeparatorMil(Convert.ToInt32(miTabla.AsEnumerable().
                            Sum(s => (s.Field<double>("ValorIva") * Convert.ToDouble(s.Field<string>("Cantidad"))))).ToString());


                        frmCancelarVenta.txtBase.Text = UseObject.InsertSeparatorMil((UseObject.RemoveSeparatorMil(txtTotal.Text) -
                            UseObject.RemoveSeparatorMil(frmCancelarVenta.txtIva.Text)).ToString());

                        frmCancelarVenta.txtTotal.Text = this.txtTotal.Text;
                        frmCancelarVenta.EsVenta = true;
                        Venta = true;
                        frmCancelarVenta.ShowDialog();
                    }
                    this.Transfer = true;
                }
                else
                {
                    this.txtCliente.Focus();
                }
            }
            else
            {
                txtCliente_KeyPress(this.txtCliente, new KeyPressEventArgs((char)Keys.Enter));
                if (ClienteMatch)
                {
                    var msn = "";
                    if (IdEstado != 4)
                    {
                        msn = "¿Esta seguro de querer hacer la venta?";
                    }
                    else
                    {
                        msn = "¿Esta seguro de querer hacer la cotización?";
                    }
                    DialogResult rta = MessageBox.Show(msn, "Factura Venta",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (rta.Equals(DialogResult.Yes))
                    {
                        if (FacturaPos)
                        {
                            CargarYguardarFacturaPos();
                        }
                        else
                        {
                            CargarYguardarFactura_();
                        }
                    }
                }
            }
        }

        private void RetiroDeProducto()
        {
            if (dgvListaArticulos.RowCount != 0)
            {
                /* string rta = CustomControl.OptionPane.OptionBox
                     ("Ingresar contraseña de Administrador .", "Administrador", CustomControl.OptionPane.Icon.LoginAdmin);
                 if (!rta.Equals("false"))
                 {*/
                /* var admin = false;
                 try
                 {
                     admin = miBussinesUsuario.VerificarUsuarioAdmin(Encode.Encrypt(rta));
                 }
                 catch (Exception ex)
                 {
                     OptionPane.MessageError(ex.Message);
                     admin = false;
                 }
                 if (admin)
                 {*/
                DialogResult rta = MessageBox.Show("¿Está seguro(a) de retirar el producto?", "Factura venta",
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (rta.Equals(DialogResult.Yes))
                {

                    try
                    {
                        int id = (int)this.dgvListaArticulos.CurrentRow.Cells["Id"].Value;
                        var row = (from registro in miTabla.AsEnumerable()
                                   where registro.Field<int>("Id") == id
                                   select registro).Single();
                        row["Retorno"] = true;
                        row["Ico"] = 0;
                        row["Valor_"] = row["ValorUnitario"];
                        row["Valor"] = 0;
                        if (miTabla.Rows.Count != 0)
                        {
                            RecargarGridview();
                        }
                        else
                        {
                            this.dgvListaArticulos.Rows.RemoveAt(this.dgvListaArticulos.CurrentCell.RowIndex);
                        }
                        txtTotal.Text = UseObject.InsertSeparatorMil
                                (
                                   Convert.ToInt32(
                                   miTabla.AsEnumerable().Sum(s => s.Field<double>("Valor"))
                                   ).ToString()
                                );
                        RecargarRetencion();
                        CalcularTotal();
                        ColorearGrid();
                        this.txtCodigoArticulo.Focus();
                        //miBussinesFactura.IngresarRetornoTemporal(producto);
                    }
                    catch (Exception ex)
                    {
                        OptionPane.MessageError(ex.Message);
                    }
                }

                /*}
                else
                {
                    MessageBox.Show("La contraseña es Incorrecta.", "Factura Venta",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }*/
                //}
            }
        }

        private void ResetFactura()
        {
            miTabla.Rows.Clear();
            while (dgvListaArticulos.RowCount != 0)
            {
                dgvListaArticulos.Rows.RemoveAt(0);
            }
            cbContado.SelectedIndex = 0;
            this.tsCbContado_SelectedIndexChanged(this.cbContado, new EventArgs());
            cbDesctoRecargo.SelectedIndex = 0;
            txtCliente.Text = "1000";
            txtCliente_KeyPress(this.txtCliente, new KeyPressEventArgs((char)Keys.Enter));
            dtpFechaLimite.Value = DateTime.Now;
            rbtnDesctoFactura.Checked = true;
            rbtnDesctoFactura_Click(this.rbtnDesctoFactura, new EventArgs());
            txtDescuentoFactura.Enabled = true;
            txtCantidad.Text = "1";
            txtCodigoArticulo.Text = "";
            try
            {
                cbDescuentoProducto.SelectedIndex = 0;
                cbRecargoProducto.SelectedIndex = 0;
            }
            catch { }
            btnTallaYcolor.Enabled = false;
            txtTotal.Text = "0";
            txtTotalMenosRete.Text = "";
            lblDatosProducto.Text = "";
            lblPrecioProducto.Text = "";
            txtValorUnitario.Text = "0";
            DesctoAplica = 0;
            this.btnBorrarImpstoBolsas_Click(this.btnBorrarImpstoBolsas, new EventArgs());
            this.MiRetencion = new RetencionConcepto();
            this.CargarRetencion();
            this.CalcularTotal();
        }

        private BussinesApertura miBussinesApertura;

        private void RetiroDeCaja()
        {
            if (miBussinesApertura.RegistrosApertura(Convert.ToInt32(AppConfiguracion.ValorSeccion("id_caja"))).Rows.Count.Equals(0)) //if (String.IsNullOrEmpty(AppConfiguracion.ValorSeccion("id_apertura")))
            {
                OptionPane.MessageError("Se requiere apertura de caja para esta función.");
            }
            else
            {
                var frmRetiro = new Retiro.FrmRetiroDinero();
                frmRetiro.ShowDialog();

                /* if (this.RetiroPermiso)
                 {
                     var frmRetiro = new Retiro.FrmRetiroDinero();
                     frmRetiro.ShowDialog();
                 }
                 else
                 {
                     var admin = false;
                     while (!admin)
                     {
                         string rta = CustomControl.OptionPane.OptionBox
                         ("Ingresar contraseña de Administrador.", "Administrador", CustomControl.OptionPane.Icon.LoginAdmin);
                         if (!rta.Equals("false"))
                         {
                             try
                             {
                                 //admin = miBussinesUsuario.VerificarUsuarioAdmin(Encode.Encrypt(rta));
                                 admin = this.miBussinesUsuario.VerificarUsuario(SuperUsuario, Encode.Encrypt(rta), IdRetiro);
                             }
                             catch (Exception ex)
                             {
                                 OptionPane.MessageError(ex.Message);
                                 admin = false;
                             }
                             if (admin)
                             {
                                 var frmRetiro = new Retiro.FrmRetiroDinero();
                                 frmRetiro.ShowDialog();
                             }
                             else
                             {
                                 MessageBox.Show("La contraseña es Incorrecta.", "Factura venta",
                                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                             }
                         }
                         else
                         {
                             admin = true;
                         }
                     }*/
                /*string rta = CustomControl.OptionPane.OptionBox
                    ("Ingresar contraseña de Administrador.", "Administrador", CustomControl.OptionPane.Icon.LoginAdmin);
                if (!rta.Equals("false"))
                {
                    try
                    {
                        admin = miBussinesUsuario.VerificarUsuarioAdmin(Encode.Encrypt(rta));
                    }
                    catch (Exception ex)
                    {
                        OptionPane.MessageError(ex.Message);
                        admin = false;
                    }
                    if (admin)
                    {
                        var frmRetiro = new Retiro.FrmRetiroDinero();
                        frmRetiro.ShowDialog();
                    }
                    else
                    {
                        MessageBox.Show("La contraseña es Incorrecta.", "Factura Venta",
                               MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }*/
                //OptionPane.MessageInformation("No tiene permisos para esta acción.");
                //}
                /* string rta = CustomControl.OptionPane.OptionBox
                         ("Ingresar contraseña de Administrador .", "Administrador", CustomControl.OptionPane.Icon.LoginAdmin);
                 if (!rta.Equals("false"))
                 {
                     var admin = false;
                     try
                     {
                         admin = miBussinesUsuario.VerificarUsuarioAdmin(Encode.Encrypt(rta));
                     }
                     catch (Exception ex)
                     {
                         OptionPane.MessageError(ex.Message);
                         admin = false;
                     }
                     if (admin)
                     {
                         var frmRetiro = new Retiro.FrmRetiroDinero();
                         frmRetiro.ShowDialog();
                     }
                     else
                     {
                         MessageBox.Show("La contraseña es Incorrecta.", "Factura Venta",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                     }
                 }*/
            }
        }

        private int MaxArticulosPrint { get { return 12; } }
        private List<PrintFactura> Facturas { set; get; }
        private bool ClienteMatch = false;

        private void CargarYguardarFacturaAntes()
        {
            if (dgvListaArticulos.RowCount > 0)
            {
                dtpFechaLimite_Validating(this.dtpFechaLimite, new CancelEventArgs(false));
                /* if (UseObject.RemoveSeparatorMil(txtRetencion.Text).Equals(0))
                 {
                     AplicaRete = false;
                 }*/
                if (IdEstado != 1)
                {
                    if (NitCliente.Equals("") || NitCliente.Equals("1000"))
                    {
                        OptionPane.MessageError("Por favor ingrese un cliente.");
                        miError.SetError(txtCliente, "Por favor ingrese un cliente.");
                        ClienteMatch = false;
                    }
                    else
                    {
                        miError.SetError(txtCliente, "");
                        ClienteMatch = true;
                    }
                }
                else
                {
                    miError.SetError(txtCliente, "");
                    ClienteMatch = true;
                }
                if (ClienteMatch && LimiteMatch)
                {
                    /*if (Edicion)
                    {
                        miFactura.Numero = lblNoFactura.Text;
                    }*/
                    int iteracion = dgvListaArticulos.RowCount / MaxArticulosPrint;
                    if (dgvListaArticulos.RowCount != 0)
                    {
                        if (dgvListaArticulos.RowCount % MaxArticulosPrint != 0)
                        {
                            iteracion++;
                        }
                    }
                    else
                    {
                        iteracion++;
                    }
                    Facturas = new List<PrintFactura>();
                    for (int i = 1; i <= iteracion; i++)
                    {
                        try
                        {
                            /*if (!Edicion)
                            {
                                ObtenerNumero();
                            }
                            var contado_ = true;*/
                            /* if (IdEstado == 1 || IdEstado == 2)  //Contado o Crédito
                             {
                                 if (chkAntigua.Checked)
                                 {
                                     miFactura.Numero = AppConfiguracion.ValorSeccion("cfactantigua") +
                                                        AppConfiguracion.ValorSeccion("factantigua");
                                 }
                                 else
                                 {
                                     ObtenerNumero();
                                 }
                                 //contado_ = false;
                             }
                             else   //Pendiente
                             {
                                 miFactura.Numero = ObtenerNumeroTemp();
                             }*/

                            switch (IdEstado)
                            {
                                case 1:
                                    {
                                        ObtenerNumero();
                                        break;
                                    }
                                case 2:
                                    {
                                        ObtenerNumero();
                                        break;
                                    }
                                case 3:
                                    {
                                        miFactura.Numero = miBussinesConsecutivo.Consecutivo("ConsFacturaPendiente") +
                                                           miBussinesConsecutivo.Consecutivo("FacturaPendiente");
                                        break;
                                    }
                                case 4:
                                    {
                                        miFactura.Numero = miBussinesConsecutivo.Consecutivo("ConsCotizacion") +
                                                           miBussinesConsecutivo.Consecutivo("Cotizacion");
                                        break;
                                    }
                            }

                            if (IdDesctoRecgo == 1)
                            {
                                if (rbtnDesctoFactura.Checked)
                                {
                                    miFactura.Descuento = Convert.ToDouble(txtDescuentoFactura.Text);
                                }
                            }
                            else
                            {
                                if (IdDesctoRecgo == 2)
                                {
                                    miFactura.AplicaDescuento = false;
                                    miFactura.Recargo = Convert.ToDouble(txtDescuentoFactura.Text);
                                }
                            }
                            Facturas.Add(new PrintFactura
                            {
                                Numero = miFactura.Numero,
                                Descuento = miFactura.AplicaDescuento,
                                Cliente = NitCliente,
                                Contado = contado
                            });
                            FechaHoy = DateTime.Now;
                            miFactura.Proveedor.NitProveedor = NitCliente;
                            miFactura.Caja.Id = Convert.ToInt32(AppConfiguracion.ValorSeccion("id_caja"));
                            miFactura.EstadoFactura.Id = IdEstado;
                            miFactura.FormasDePago = miFormasPago;
                            if (AplicaRete)
                            {
                                miFactura.Retencion = MiRetencion;
                            }
                            else
                            {
                                miFactura.Retencion = null;
                            }
                            if (chkAntigua.Checked)
                            {
                                miFactura.FechaIngreso = dtpFechaLimite.Value;
                                miFactura.FechaLimite = dtpLimite.Value;
                            }
                            else
                            {
                                miFactura.FechaIngreso = FechaHoy;
                                miFactura.FechaLimite = dtpFechaLimite.Value;
                            }
                            /*if (IdDesctoRecgo == 1)
                            {
                                if (rbtnDesctoFactura.Checked)
                                {
                                    miFactura.Descuento = Convert.ToDouble(txtDescuentoFactura.Text);
                                }
                            }
                            else
                            {
                                if (IdDesctoRecgo == 2)
                                {
                                    miFactura.AplicaDescuento = false;
                                    miFactura.Recargo = Convert.ToDouble(txtDescuentoFactura.Text);
                                }
                            }*/
                            List<ProductoFacturaProveedor> productos = new List<ProductoFacturaProveedor>();
                            List<DataRow> miRows = new List<DataRow>();
                            var cont = 0;
                            foreach (DataRow row in miTabla.Rows)
                            {
                                cont++;
                                var producto = new ProductoFacturaProveedor();
                                producto.Save = Convert.ToBoolean(row["Save"]);
                                producto.NumeroFactura = miFactura.Numero;
                                producto.Producto.CodigoInternoProducto = row["Codigo"].ToString();
                                producto.Cantidad = Convert.ToDouble(row["Cantidad"]);
                                producto.Producto.ValorVentaProducto = Convert.ToDouble(row["ValorUnitario"]);
                                producto.Inventario.CodigoProducto = row["Codigo"].ToString();
                                producto.Inventario.IdMedida = Convert.ToInt32(row["IdMedida"]);
                                producto.Inventario.IdColor = Convert.ToInt32(row["IdColor"]);
                                producto.Inventario.Cantidad = Convert.ToDouble(row["Cantidad"]);
                                if (miFactura.AplicaDescuento)
                                {
                                    producto.Producto.Descuento =
                                        UseObject.RemoveCharacter(row["Descuento"].ToString(), '%');
                                }
                                else
                                {
                                    producto.Producto.Recargo =
                                        UseObject.RemoveCharacter(row["Descuento"].ToString(), '%');
                                }
                                producto.Producto.ValorIva =
                                    UseObject.RemoveCharacter(row["Iva"].ToString(), '%');
                                productos.Add(producto);
                                miRows.Add(row);
                                if (cont == MaxArticulosPrint)
                                    break;
                            }
                            miFactura.Productos = productos;
                            //try
                            //{
                            miBussinesFactura.IngresarFactura(miFactura, Edicion, chkAntigua.Checked, ConsecutivoCaja);
                            /* if (IdEstado == 3 || IdEstado == 4)
                             {
                                 ActualizaNumeroTemp();
                             }*/
                            //}
                            /*catch (Exception ex)
                            {
                                OptionPane.MessageError(ex.Message);
                                break;
                            }*/
                            foreach (DataRow miRow in miRows)
                            {
                                miTabla.Rows.Remove(miRow);
                            }
                        }
                        catch (Exception ex)
                        {
                            OptionPane.MessageError(ex.Message);
                            break;
                        }
                    }
                    /*if (IdEstado != 3)
                    {*/
                    var msn = "";
                    if (IdEstado != 4)
                    {
                        msn = "La venta se realizó con éxito!";
                    }
                    else
                    {
                        msn = "La cotización se guardó con éxito!";
                    }
                    OptionPane.MessageSuccess(msn);
                    if (IdEstado != 3)
                    {
                        if (IdEstado != 4)
                        {
                            msn = "¿Desea imprimir la Factura de Venta?";
                        }
                        else
                        {
                            msn = "¿Desea imprimir la Cotización?";
                        }
                        DialogResult rta = MessageBox.Show(msn, "Factura Venta",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (rta.Equals(DialogResult.Yes))
                        {
                            foreach (PrintFactura p in Facturas)
                            {
                                //Print(p.Numero, p.Descuento, p.Cliente, p.Contado, IdEstado);
                            }
                        }
                    }
                    if (miFactura.EstadoFactura.Id.Equals(1))
                    {
                        var pagos = miFormasPago.Where(p => p.IdFormaPago.Equals(5));
                        var pago = new DTO.Clases.FormaPago();//Anticipo
                        if (pagos.ToArray().Length != 0)
                        {
                            pago = miFormasPago.Where(p => p.IdFormaPago.Equals(5)).First();
                        }
                        if (pago.Valor != 0)
                        {
                            try
                            {
                                var bussinesCruce = new BussinesComprobanteCruce();
                                var miCruce = new ComprobanteCruce();
                                miCruce.Fecha = DateTime.Now;
                                miCruce.NitCliente = Facturas.First().Cliente;
                                miCruce.Concepto = "Cruce de Anticipo a Factura de Venta No. " + Facturas.First().Numero;
                                miCruce.Valor = Convert.ToInt32(pago.Valor);
                                miCruce.Restante = "Anticipo Restante : ";
                                miCruce.ValorRestante = miBussinesSaldo.SaldoEnAdelantos(miCruce.NitCliente);
                                miCruce.Id = bussinesCruce.Ingresar(miCruce);
                                PrintComprobanteCruce(miCruce);
                            }
                            catch (Exception ex)
                            {
                                OptionPane.MessageError(ex.Message);
                            }
                        }
                        pago = new DTO.Clases.FormaPago();
                        pagos = miFormasPago.Where(p => p.IdFormaPago.Equals(6));//saldo
                        if (pagos.ToArray().Length != 0)
                        {
                            pago = miFormasPago.Where(p => p.IdFormaPago.Equals(6)).First();
                        }
                        if (pago.Valor != 0)
                        {
                            var bussinesCruce = new BussinesComprobanteCruce();
                            var miCruce = new ComprobanteCruce();
                            miCruce.Fecha = DateTime.Now;
                            miCruce.NitCliente = Facturas.First().Cliente;
                            miCruce.Concepto = "Cruce de Saldo a Factura de Venta No. " + Facturas.First().Numero;
                            miCruce.Valor = Convert.ToInt32(pago.Valor);
                            miCruce.Restante = "Saldo Restante : ";
                            miCruce.ValorRestante = Convert.ToInt32(miBussinesBono.SaldoEnBonos(miCruce.NitCliente));//(miCruce.NitCliente);
                            miCruce.Id = bussinesCruce.Ingresar(miCruce);
                            PrintComprobanteCruce(miCruce);
                        }
                    }
                    /*}
                    else.
                    {
                        OptionPane.MessageSuccess("La venta se guardó con éxito!");
                    }*/
                    if (IdEstado.Equals(2))
                    {
                        DialogResult rta = MessageBox.Show("¿Desea realizar algun abono?", "Factura de Venta",
                            MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (rta.Equals(DialogResult.Yes))
                        {
                            var frmCancelarVenta = new Abonos.FrmCancelarVenta();
                            frmCancelarVenta.NumeroFactura = miFactura.Numero;
                            frmCancelarVenta.Abono = true;
                            frmCancelarVenta.EsVenta = true;
                            frmCancelarVenta.txtTotal.Text = txtTotal.Text;
                            frmCancelarVenta.ShowDialog();
                        }
                    }
                    LimpiarCamposNewFactura();
                    //PrintPos();
                    //ObtenerNumero();


                }
            }
        }

        private void CargarYguardarFactura()
        {
            if (dgvListaArticulos.RowCount > 0)
            {
                dtpFechaLimite_Validating(this.dtpFechaLimite, new CancelEventArgs(false));
                /* if (UseObject.RemoveSeparatorMil(txtRetencion.Text).Equals(0))
                 {
                     AplicaRete = false;
                 }*/
                if (IdEstado != 1)
                {
                    if (NitCliente.Equals("") || NitCliente.Equals("1000"))
                    {
                        OptionPane.MessageError("Por favor ingrese un cliente.");
                        miError.SetError(txtCliente, "Por favor ingrese un cliente.");
                        ClienteMatch = false;
                    }
                    else
                    {
                        miError.SetError(txtCliente, "");
                        ClienteMatch = true;
                    }
                }
                else
                {
                    miError.SetError(txtCliente, "");
                    ClienteMatch = true;
                }
                if (ClienteMatch && LimiteMatch)
                {
                    /*if (Edicion)
                    {
                        miFactura.Numero = lblNoFactura.Text;
                    }*/
                    int iteracion = dgvListaArticulos.RowCount / MaxArticulosPrint;
                    if (dgvListaArticulos.RowCount != 0)
                    {
                        if (dgvListaArticulos.RowCount % MaxArticulosPrint != 0)
                        {
                            iteracion++;
                        }
                    }
                    else
                    {
                        iteracion++;
                    }
                    Facturas = new List<PrintFactura>();
                    for (int i = 1; i <= iteracion; i++)
                    {
                        try
                        {
                            /*if (!Edicion)
                            {
                                ObtenerNumero();
                            }
                            var contado_ = true;*/
                            /* if (IdEstado == 1 || IdEstado == 2)  //Contado o Crédito
                             {
                                 if (chkAntigua.Checked)
                                 {
                                     miFactura.Numero = AppConfiguracion.ValorSeccion("cfactantigua") +
                                                        AppConfiguracion.ValorSeccion("factantigua");
                                 }
                                 else
                                 {
                                     ObtenerNumero();
                                 }
                                 //contado_ = false;
                             }
                             else   //Pendiente
                             {
                                 miFactura.Numero = ObtenerNumeroTemp();
                             }*/

                            switch (IdEstado)
                            {
                                case 1:
                                    {
                                        ObtenerNumero();
                                        break;
                                    }
                                case 2:
                                    {
                                        ObtenerNumero();
                                        break;
                                    }
                                case 3:
                                    {
                                        miFactura.Numero = miBussinesConsecutivo.Consecutivo("ConsFacturaPendiente") +
                                                           miBussinesConsecutivo.Consecutivo("FacturaPendiente");
                                        break;
                                    }
                                case 4:
                                    {
                                        miFactura.Numero = miBussinesConsecutivo.Consecutivo("ConsCotizacion") +
                                                           miBussinesConsecutivo.Consecutivo("Cotizacion");
                                        break;
                                    }
                            }

                            if (IdDesctoRecgo == 1)
                            {
                                if (rbtnDesctoFactura.Checked)
                                {
                                    miFactura.Descuento = Convert.ToDouble(txtDescuentoFactura.Text);
                                }
                            }
                            else
                            {
                                if (IdDesctoRecgo == 2)
                                {
                                    miFactura.AplicaDescuento = false;
                                    miFactura.Recargo = Convert.ToDouble(txtDescuentoFactura.Text);
                                }
                            }
                            Facturas.Add(new PrintFactura
                            {
                                Numero = miFactura.Numero,
                                Descuento = miFactura.AplicaDescuento,
                                Cliente = NitCliente,
                                Contado = contado
                            });
                            FechaHoy = DateTime.Now;
                            miFactura.Proveedor.NitProveedor = NitCliente;
                            miFactura.Caja.Id = Convert.ToInt32(AppConfiguracion.ValorSeccion("id_caja"));
                            miFactura.EstadoFactura.Id = IdEstado;
                            miFactura.FormasDePago = miFormasPago;
                            if (AplicaRete)
                            {
                                miFactura.Retencion = MiRetencion;
                            }
                            else
                            {
                                miFactura.Retencion = null;
                            }
                            if (chkAntigua.Checked)
                            {
                                miFactura.FechaIngreso = dtpFechaLimite.Value;
                                miFactura.FechaLimite = dtpLimite.Value;
                            }
                            else
                            {
                                miFactura.FechaIngreso = FechaHoy;
                                miFactura.FechaLimite = dtpFechaLimite.Value;
                            }
                            /*if (IdDesctoRecgo == 1)
                            {
                                if (rbtnDesctoFactura.Checked)
                                {
                                    miFactura.Descuento = Convert.ToDouble(txtDescuentoFactura.Text);
                                }
                            }
                            else
                            {
                                if (IdDesctoRecgo == 2)
                                {
                                    miFactura.AplicaDescuento = false;
                                    miFactura.Recargo = Convert.ToDouble(txtDescuentoFactura.Text);
                                }
                            }*/
                            List<ProductoFacturaProveedor> productos = new List<ProductoFacturaProveedor>();
                            List<DataRow> miRows = new List<DataRow>();
                            var cont = 0;
                            foreach (DataRow row in miTabla.Rows)
                            {
                                cont++;
                                var producto = new ProductoFacturaProveedor();
                                producto.Save = Convert.ToBoolean(row["Save"]);
                                producto.NumeroFactura = miFactura.Numero;
                                producto.Producto.CodigoInternoProducto = row["Codigo"].ToString();
                                producto.Cantidad = Convert.ToDouble(row["Cantidad"]);
                                producto.Producto.ValorVentaProducto = Convert.ToDouble(row["ValorUnitario"]);
                                producto.Inventario.CodigoProducto = row["Codigo"].ToString();
                                producto.Inventario.IdMedida = Convert.ToInt32(row["IdMedida"]);
                                producto.Inventario.IdColor = Convert.ToInt32(row["IdColor"]);
                                producto.Inventario.Cantidad = Convert.ToDouble(row["Cantidad"]);
                                if (miFactura.AplicaDescuento)
                                {
                                    producto.Producto.Descuento =
                                        UseObject.RemoveCharacter(row["Descuento"].ToString(), '%');
                                }
                                else
                                {
                                    producto.Producto.Recargo =
                                        UseObject.RemoveCharacter(row["Descuento"].ToString(), '%');
                                }
                                producto.Producto.ValorIva =
                                    UseObject.RemoveCharacter(row["Iva"].ToString(), '%');
                                productos.Add(producto);
                                miRows.Add(row);
                                if (cont == MaxArticulosPrint)
                                    break;
                            }
                            miFactura.Productos = productos;
                            //try
                            //{
                            miBussinesFactura.IngresarFactura(miFactura, Edicion, chkAntigua.Checked, ConsecutivoCaja);
                            /* if (IdEstado == 3 || IdEstado == 4)
                             {
                                 ActualizaNumeroTemp();
                             }*/
                            //}
                            /*catch (Exception ex)
                            {
                                OptionPane.MessageError(ex.Message);
                                break;
                            }*/
                            foreach (DataRow miRow in miRows)
                            {
                                miTabla.Rows.Remove(miRow);
                            }
                        }
                        catch (Exception ex)
                        {
                            OptionPane.MessageError(ex.Message);
                            break;
                        }
                    }
                    /*if (IdEstado != 3)
                    {*/
                    var msn = "";
                    if (IdEstado != 4)
                    {
                        msn = "La venta se realizó con éxito!";
                    }
                    else
                    {
                        msn = "La cotización se guardó con éxito!";
                    }
                    OptionPane.MessageSuccess(msn);
                    if (IdEstado != 3)
                    {
                        if (IdEstado != 4)
                        {
                            msn = "¿Desea imprimir la Factura de Venta?";
                        }
                        else
                        {
                            msn = "¿Desea imprimir la Cotización?";
                        }
                        DialogResult rta = MessageBox.Show(msn, "Factura Venta",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (rta.Equals(DialogResult.Yes))
                        {
                            foreach (PrintFactura p in Facturas)
                            {
                                //Print(p.Numero, p.Descuento, p.Cliente, p.Contado, IdEstado);
                            }
                        }
                    }
                    if (miFactura.EstadoFactura.Id.Equals(1))
                    {
                        var pagos = miFormasPago.Where(p => p.IdFormaPago.Equals(5));
                        var pago = new DTO.Clases.FormaPago();//Anticipo
                        if (pagos.ToArray().Length != 0)
                        {
                            pago = miFormasPago.Where(p => p.IdFormaPago.Equals(5)).First();
                        }
                        if (pago.Valor != 0)
                        {
                            try
                            {
                                var bussinesCruce = new BussinesComprobanteCruce();
                                var miCruce = new ComprobanteCruce();
                                miCruce.Fecha = DateTime.Now;
                                miCruce.NitCliente = Facturas.First().Cliente;
                                miCruce.Concepto = "Cruce de Anticipo a Factura de Venta No. " + Facturas.First().Numero;
                                miCruce.Valor = Convert.ToInt32(pago.Valor);
                                miCruce.Restante = "Anticipo Restante : ";
                                miCruce.ValorRestante = miBussinesSaldo.SaldoEnAdelantos(miCruce.NitCliente);
                                miCruce.Id = bussinesCruce.Ingresar(miCruce);
                                PrintComprobanteCruce(miCruce);
                            }
                            catch (Exception ex)
                            {
                                OptionPane.MessageError(ex.Message);
                            }
                        }
                        pago = new DTO.Clases.FormaPago();
                        pagos = miFormasPago.Where(p => p.IdFormaPago.Equals(6));//saldo
                        if (pagos.ToArray().Length != 0)
                        {
                            pago = miFormasPago.Where(p => p.IdFormaPago.Equals(6)).First();
                        }
                        if (pago.Valor != 0)
                        {
                            var bussinesCruce = new BussinesComprobanteCruce();
                            var miCruce = new ComprobanteCruce();
                            miCruce.Fecha = DateTime.Now;
                            miCruce.NitCliente = Facturas.First().Cliente;
                            miCruce.Concepto = "Cruce de Saldo a Factura de Venta No. " + Facturas.First().Numero;
                            miCruce.Valor = Convert.ToInt32(pago.Valor);
                            miCruce.Restante = "Saldo Restante : ";
                            miCruce.ValorRestante = Convert.ToInt32(miBussinesBono.SaldoEnBonos(miCruce.NitCliente));//(miCruce.NitCliente);
                            miCruce.Id = bussinesCruce.Ingresar(miCruce);
                            PrintComprobanteCruce(miCruce);
                        }
                    }
                    /*}
                    else.
                    {
                        OptionPane.MessageSuccess("La venta se guardó con éxito!");
                    }*/
                    if (IdEstado.Equals(2))
                    {
                        DialogResult rta = MessageBox.Show("¿Desea realizar algun abono?", "Factura de Venta",
                            MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (rta.Equals(DialogResult.Yes))
                        {
                            var frmCancelarVenta = new Abonos.FrmCancelarVenta();
                            frmCancelarVenta.NumeroFactura = miFactura.Numero;
                            frmCancelarVenta.Abono = true;
                            frmCancelarVenta.EsVenta = true;
                            frmCancelarVenta.txtTotal.Text = txtTotal.Text;
                            frmCancelarVenta.ShowDialog();
                        }
                    }
                    LimpiarCamposNewFactura();
                    //PrintPos();
                    //ObtenerNumero();


                }
            }
        }

        // Funcional
        private void CargarYguardarFactura_()
        {
            if (dgvListaArticulos.RowCount > 0)
            {
                dtpFechaLimite_Validating(this.dtpFechaLimite, new CancelEventArgs(false));
                if (IdEstado != 1)
                {
                    if (NitCliente.Equals("") || NitCliente.Equals("1000"))
                    {
                        OptionPane.MessageError("Por favor ingrese un cliente.");
                        miError.SetError(txtCliente, "Por favor ingrese un cliente.");
                        ClienteMatch = false;
                    }
                    else
                    {
                        miError.SetError(txtCliente, "");
                        ClienteMatch = true;
                    }
                }
                else
                {
                    miError.SetError(txtCliente, "");
                    ClienteMatch = true;
                }
                if (ClienteMatch && LimiteMatch)
                {
                    switch (IdEstado)
                    {
                        case 1:
                            {
                                ObtenerNumero();
                                break;
                            }
                        case 2:
                            {
                                ObtenerNumero();
                                break;
                            }
                        case 3:
                            {
                                miFactura.Numero = miBussinesConsecutivo.Consecutivo("ConsFacturaPendiente") +
                                                   miBussinesConsecutivo.Consecutivo("FacturaPendiente");
                                break;
                            }
                        case 4:
                            {
                                miFactura.Numero = miBussinesConsecutivo.Consecutivo("ConsCotizacion") +
                                                   miBussinesConsecutivo.Consecutivo("Cotizacion");
                                break;
                            }
                    }

                    if (IdDesctoRecgo == 1)
                    {
                        if (rbtnDesctoFactura.Checked)
                        {
                            miFactura.Descuento = Convert.ToDouble(txtDescuentoFactura.Text);
                        }
                    }
                    else
                    {
                        if (IdDesctoRecgo == 2)
                        {
                            miFactura.AplicaDescuento = false;
                            miFactura.Recargo = Convert.ToDouble(txtDescuentoFactura.Text);
                        }
                    }
                    FechaHoy = DateTime.Now;
                    miFactura.Usuario = Usuario_;
                    miFactura.Proveedor.NitProveedor = NitCliente;
                    miFactura.Caja.Id = Convert.ToInt32(AppConfiguracion.ValorSeccion("id_caja"));
                    miFactura.EstadoFactura.IdEdit = miFactura.EstadoFactura.Id = IdEstado;
                    miFactura.FormasDePago = miFormasPago;
                    //miFactura.Remision_ = true;
                    if (AplicaRete)
                    {
                        miFactura.Retencion = MiRetencion;
                    }
                    else
                    {
                        miFactura.Retencion = null;
                    }
                    if (chkAntigua.Checked)
                    {
                        miFactura.FechaIngreso = dtpFechaLimite.Value;
                        miFactura.FechaLimite = dtpLimite.Value;
                    }
                    else
                    {
                        miFactura.FechaIngreso = FechaHoy;
                        miFactura.FechaLimite = dtpFechaLimite.Value;
                    }
                    List<ProductoFacturaProveedor> productos =
                        new List<ProductoFacturaProveedor>();
                    var cont = 0;
                    foreach (DataRow row in miTabla.Rows)
                    {
                        cont++;
                        var producto = new ProductoFacturaProveedor();
                        producto.Save = Convert.ToBoolean(row["Save"]);
                        producto.NumeroFactura = miFactura.Numero;
                        producto.Producto.CodigoInternoProducto = row["Codigo"].ToString();
                        producto.Cantidad = Convert.ToDouble(row["Cantidad"]);
                        producto.Producto.ValorVentaProducto = Convert.ToDouble(row["ValorUnitario"]);
                        producto.Inventario.CodigoProducto = row["Codigo"].ToString();
                        producto.Inventario.IdMedida = Convert.ToInt32(row["IdMedida"]);
                        producto.Inventario.IdColor = Convert.ToInt32(row["IdColor"]);
                        producto.Inventario.Cantidad = Convert.ToDouble(row["Cantidad"]);
                        producto.Retorno = Convert.ToBoolean(row["Retorno"]);
                        producto.ValorReal = Convert.ToDouble(row["Valor_"]);
                        if (producto.Retorno)
                        {
                            producto.Producto.ValorVentaProducto = 0;
                            producto.Valor = Convert.ToDouble(row["Valor_"]);
                        }
                        if (miFactura.AplicaDescuento)
                        {
                            producto.Producto.Descuento =
                                UseObject.RemoveCharacter(row["Descuento"].ToString(), '%');
                        }
                        else
                        {
                            producto.Producto.Recargo =
                                UseObject.RemoveCharacter(row["Descuento"].ToString(), '%');
                        }
                        producto.Producto.ValorIva =
                            UseObject.RemoveCharacter(row["Iva"].ToString(), '%');
                        productos.Add(producto);
                    }
                    miFactura.Productos = productos;
                    try
                    {
                        miBussinesFactura.IngresarFactura(miFactura, Edicion, chkAntigua.Checked, ConsecutivoCaja);
                        var msn = "";
                        if (IdEstado != 4)
                        {
                            msn = "La venta se realizó con éxito!";
                        }
                        else
                        {
                            msn = "La cotización se guardó con éxito!";
                        }
                        OptionPane.MessageSuccess(msn);
                        if (IdEstado != 3)
                        {
                            if (IdEstado != 4)
                            {
                                msn = "Impresión de la Factura de Venta";
                                //msn = "¿Desea imprimir la Factura de Venta?";
                            }
                            else
                            {
                                msn = "Impresión de la Cotización";
                                //msn = "¿Desea imprimir la Cotización?";
                            }
                            FrmPrint frmPrint = new FrmPrint();
                            frmPrint.StringCaption = "Factura Venta";
                            frmPrint.StringMessage = msn;
                            DialogResult rta = frmPrint.ShowDialog();

                            /*DialogResult rta = MessageBox.Show(msn, "Factura Venta",
                            MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);*/

                            if (rta.Equals(DialogResult.Yes))
                            {
                                /*PrintDespues(miFactura.Numero, miFactura.AplicaDescuento,
                                             miFactura.Proveedor.NitProveedor, contado, 
                                             miFactura.EstadoFactura.Id, false);*/
                            }
                            else
                            {
                                if (rta.Equals(DialogResult.No))
                                {
                                    /*PrintDespues(miFactura.Numero, miFactura.AplicaDescuento,
                                             miFactura.Proveedor.NitProveedor, contado,
                                             miFactura.EstadoFactura.Id, true);*/
                                }
                            }
                            /*if (rta.Equals(DialogResult.Yes))
                            {
                                PrintDespues(miFactura.Numero, miFactura.AplicaDescuento,
                                             miFactura.Proveedor.NitProveedor, contado,
                                             miFactura.EstadoFactura.Id, true);
                            }*/

                        }
                        if (IdEstado.Equals(2))
                        {
                            DialogResult rta = MessageBox.Show("¿Desea realizar algun abono?", "Factura de Venta",
                                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                            if (rta.Equals(DialogResult.Yes))
                            {
                                if (Convert.ToBoolean(AppConfiguracion.ValorSeccion("btq")))
                                {
                                    // var frmCancelarVenta = new Abonos.FrmCancelarVenta();
                                    var frmCancelarVenta = new Abonos.FrmCancelarVenta2();
                                    frmCancelarVenta.NumeroFactura = miFactura.Numero;
                                    frmCancelarVenta.NitCliente = miFactura.Proveedor.NitProveedor;
                                    frmCancelarVenta.Abono = true;
                                    frmCancelarVenta.EsVenta = true;
                                    frmCancelarVenta.txtTotal.Text = this.txtTotal.Text; //txtTotalMenosRete.Text;//txtTotal.Text;
                                    frmCancelarVenta.ShowDialog();
                                }
                                else
                                {
                                    var frmCancelarVenta = new Abonos.FrmCancelarVenta();
                                    //var frmCancelarVenta = new Abonos.FrmCancelarVenta2();
                                    frmCancelarVenta.NumeroFactura = miFactura.Numero;
                                    frmCancelarVenta.NitCliente = miFactura.Proveedor.NitProveedor;
                                    frmCancelarVenta.Abono = true;
                                    frmCancelarVenta.EsVenta = true;
                                    frmCancelarVenta.txtTotal.Text = this.txtTotal.Text; //txtTotalMenosRete.Text;//txtTotal.Text;
                                    frmCancelarVenta.ShowDialog();
                                }


                                /*  var frmCancelarVenta = new Abonos.FrmCancelarVenta();
                                  //var frmCancelarVenta = new Abonos.FrmCancelarVenta2();
                                  frmCancelarVenta.NumeroFactura = miFactura.Numero;
                                  frmCancelarVenta.NitCliente = miFactura.Proveedor.NitProveedor;
                                  frmCancelarVenta.Abono = true;
                                  frmCancelarVenta.EsVenta = true;
                                  frmCancelarVenta.txtTotal.Text = txtTotal.Text;
                                  frmCancelarVenta.ShowDialog();*/
                            }
                        }
                        LimpiarCamposNewFactura();
                    }
                    catch (Exception ex)
                    {
                        OptionPane.MessageError(ex.Message);
                    }
                }
            }
        }

        // Funcional
        private void CargarYguardarFacturaPos()
        {
            if (dgvListaArticulos.RowCount > 0)
            {
                dtpFechaLimite_Validating(this.dtpFechaLimite, new CancelEventArgs(false));
                if (IdEstado != 1)
                {
                    if (NitCliente.Equals("") || NitCliente.Equals("1000"))
                    {
                        OptionPane.MessageError("Por favor ingrese un cliente.");
                        miError.SetError(txtCliente, "Por favor ingrese un cliente.");
                        ClienteMatch = false;
                    }
                    else
                    {
                        miError.SetError(txtCliente, "");
                        ClienteMatch = true;
                    }
                }
                else
                {
                    miError.SetError(txtCliente, "");
                    ClienteMatch = true;
                }
                if (ClienteMatch && LimiteMatch)
                {
                    switch (IdEstado)
                    {
                        case 1:
                            {
                                ObtenerNumero();
                                break;
                            }
                        case 2:
                            {
                                ObtenerNumero();
                                break;
                            }
                        case 3:
                            {
                                miFactura.Numero = miBussinesConsecutivo.Consecutivo("ConsFacturaPendiente") +
                                                   miBussinesConsecutivo.Consecutivo("FacturaPendiente");
                                break;
                            }
                        case 4:
                            {
                                miFactura.Numero = miBussinesConsecutivo.Consecutivo("ConsCotizacion") +
                                                   miBussinesConsecutivo.Consecutivo("Cotizacion");
                                break;
                            }
                    }

                    if (IdDesctoRecgo == 1)
                    {
                        if (rbtnDesctoFactura.Checked)
                        {
                            miFactura.Descuento = Convert.ToDouble(txtDescuentoFactura.Text);
                        }
                    }
                    else
                    {
                        if (IdDesctoRecgo == 2)
                        {
                            miFactura.AplicaDescuento = false;
                            miFactura.Recargo = Convert.ToDouble(txtDescuentoFactura.Text);
                        }
                    }
                    FechaHoy = DateTime.Now;
                    miFactura.Usuario = Usuario_;
                    miFactura.Proveedor.NitProveedor = NitCliente;
                    miFactura.Caja.Id = Convert.ToInt32(AppConfiguracion.ValorSeccion("id_caja"));
                    miFactura.NameStation = this.NameStation;
                    miFactura.EstadoFactura.IdEdit = miFactura.EstadoFactura.Id = IdEstado;
                    miFactura.FormasDePago = miFormasPago;
                    // miFactura.Remision_ = true;
                    if (AplicaRete)
                    {
                        miFactura.Retencion = MiRetencion;
                    }
                    else
                    {
                        miFactura.Retencion = null;
                    }
                    if (chkAntigua.Checked)
                    {
                        miFactura.FechaIngreso = dtpFechaLimite.Value;
                        miFactura.FechaLimite = dtpLimite.Value;
                    }
                    else
                    {
                        miFactura.FechaIngreso = FechaHoy;
                        miFactura.FechaLimite = dtpFechaLimite.Value;
                    }
                    if (this.ImpstoBolsa != null)
                    {
                        if (this.ImpstoBolsa.Cantidad > 0)
                        {
                            miFactura.IcoBolsaPlastica = this.ImpstoBolsa;
                        }
                    }

                    List<ProductoFacturaProveedor> productos = new List<ProductoFacturaProveedor>();
                    var cont = 0;
                    foreach (DataRow row in miTabla.Rows)
                    {
                        cont++;
                        var producto = new ProductoFacturaProveedor();
                        producto.Save = Convert.ToBoolean(row["Save"]);
                        producto.NumeroFactura = miFactura.Numero;
                        producto.Producto.CodigoInternoProducto = row["Codigo"].ToString();
                        producto.Cantidad = Convert.ToDouble(row["Cantidad"]);
                        producto.Producto.ValorVentaProducto = Convert.ToDouble(row["ValorUnitario"]);
                        producto.ImpoConsumo = Convert.ToDouble(row["Ico"]);
                        producto.Inventario.CodigoProducto = row["Codigo"].ToString();
                        producto.Inventario.IdMedida = Convert.ToInt32(row["IdMedida"]);
                        producto.Inventario.IdColor = Convert.ToInt32(row["IdColor"]);
                        producto.Producto.IdMarca = Convert.ToInt32(row["IdMarca"]);
                        producto.Inventario.Cantidad = Convert.ToDouble(row["Cantidad"]);
                        producto.Retorno = Convert.ToBoolean(row["Retorno"]);
                        producto.ValorReal = Convert.ToDouble(row["Valor_"]);
                        producto.Producto.IdTipoInventario = Convert.ToInt32(row["IdTipoInventario"]);
                        producto.Producto.IdIva = Convert.ToInt32(row["IdIva"]);
                        if (producto.Retorno)
                        {
                            producto.Producto.ValorVentaProducto = 0;
                            producto.Valor = Convert.ToDouble(row["Valor_"]);
                        }
                        if (miFactura.AplicaDescuento)
                        {
                            producto.Producto.Descuento =
                                UseObject.RemoveCharacter(row["Descuento"].ToString(), '%');
                        }
                        else
                        {
                            producto.Producto.Recargo =
                                UseObject.RemoveCharacter(row["Descuento"].ToString(), '%');
                        }
                        producto.Producto.ValorIva =
                            UseObject.RemoveCharacter(row["Iva"].ToString(), '%');
                        producto.Total = Convert.ToInt32(row["Valor"]);
                        productos.Add(producto);
                    }
                    this.miFactura.Productos = productos;
                    try
                    {
                        miFactura.Id = miBussinesFactura.IngresarFactura(miFactura, Edicion, chkAntigua.Checked, ConsecutivoCaja);

                        Punto punto = new Punto();
                        double[] data = new double[2];
                        if (this.miFactura.Proveedor.NitProveedor != "1000" &&
                            this.miFactura.Proveedor.NitProveedor != "10")
                        {
                            punto = this.miBussinesPunto.CargarPunto();
                            if (punto.EstadoPunto)
                            {
                                data = CargarPuntos(punto, miFactura.Proveedor.NitProveedor, miFactura.Id, miFactura.AplicaDescuento);
                            }
                        }

                        if (Ticket_)
                        {
                            if (Convert.ToBoolean(AppConfiguracion.ValorSeccion("print_termal_80mm")))
                            {
                                PrintPos(miFactura.Id, miFactura.AplicaDescuento,
                                     miFactura.Proveedor.NitProveedor, contado,
                                     miFactura.EstadoFactura.Id, Convert.ToInt32(miFormasPago.Sum(d => d.Pago)),
                                     punto.EstadoPunto, data);
                            }
                            else
                            {
                                PrintPos50mm(miFactura.Id, miFactura.AplicaDescuento, miFactura.EstadoFactura.Id,
                                    miFactura.Proveedor.NitProveedor, Convert.ToInt32(miFormasPago.Sum(s => s.Pago)));
                            }
                            if (this.miFormasPago.Where(p => p.IdFormaPago.Equals(4)).Count() > 0)
                            {
                                PrintTicket printTicket = new PrintTicket();
                                printTicket.UseItem = false;
                                printTicket.empresaRow = this.miBussinesEmpresa.PrintEmpresa().Tables[0].AsEnumerable().First();
                                miFactura.Total = UseObject.RemoveSeparatorMil(this.txtTotal.Text);
                                printTicket.PrintPayments(miFactura);
                            }
                        }
                        else
                        {
                            FrmPrint_ frmPrint = new FrmPrint_();
                            frmPrint.StringCaption = "Factura Venta";
                            frmPrint.StringMessage = "Impresión de factura";
                            DialogResult rta = frmPrint.ShowDialog();


                            if (rta.Equals(DialogResult.Yes))
                            {
                                PrintDespues(miFactura.Id, miFactura.Numero, miFactura.AplicaDescuento,
                                             miFactura.Proveedor.NitProveedor, contado,
                                             miFactura.EstadoFactura.Id, false);
                            }
                            else
                            {
                                if (rta.Equals(DialogResult.No))
                                {
                                    PrintDespues(miFactura.Id, miFactura.Numero, miFactura.AplicaDescuento,
                                             miFactura.Proveedor.NitProveedor, contado,
                                             miFactura.EstadoFactura.Id, true);
                                }
                            }
                        }

                        if (miFactura.EstadoFactura.Id.Equals(1) || miFactura.EstadoFactura.Id.Equals(2))
                        {
                            if (this.miBono.Canje)
                            {
                                int numeroBonos = UseObject.RetiraDecima(this.ValorPorMarcas() / this.miBono.Valor);
                                for (int i = 1; i <= numeroBonos; i++)
                                {
                                    this.PrintBonoRifa(this.miBono, this.miFactura.Proveedor.NitProveedor, this.miFactura.Numero);
                                }
                            }
                        }

                        if (miFactura.EstadoFactura.Id.Equals(1))
                        {
                            var frmCambio = new FrmCambio();
                            frmCambio.txtTotal.Text = this.txtTotal.Text; //this.txtTotalMenosRete.Text;
                            frmCambio.txtEfectivo.Text = UseObject.InsertSeparatorMil(
                                Convert.ToInt32(miFormasPago.Sum(d => d.Pago)).ToString());
                            frmCambio.txtCambio.Text = UseObject.InsertSeparatorMil((
                                UseObject.RemoveSeparatorMil(frmCambio.txtEfectivo.Text) - UseObject.RemoveSeparatorMil(frmCambio.txtTotal.Text)).ToString());
                            frmCambio.ShowDialog();
                        }


                        /* if (IdEstado == 3 || IdEstado == 4)
                         {
                             ActualizaNumeroTemp();
                         }*/
                        /* var msn = "";
                         if (IdEstado != 4)
                         {
                             msn = "La venta se realizó con éxito!";
                         }
                         else
                         {
                             msn = "La cotización se guardó con éxito!";
                         }
                         OptionPane.MessageSuccess(msn);
                         if (IdEstado != 3)
                         {
                             if (IdEstado != 4)
                             {
                                 msn = "¿Desea imprimir la Factura de Venta?";
                             }
                             else
                             {
                                 msn = "¿Desea imprimir la Cotización?";
                             }
                             DialogResult rta = MessageBox.Show(msn, "Factura Venta",
                             MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                             if (rta.Equals(DialogResult.Yes))
                             {
                                 PrintPos(miFactura.Numero, miFactura.AplicaDescuento,
                                          miFactura.Proveedor.NitProveedor, contado,
                                          miFactura.EstadoFactura.Id, Convert.ToInt32(miFormasPago.Sum(d => d.Pago)));
                             }
                         }*/

                        /*
                        if (IdEstado.Equals(2))
                        {
                            DialogResult rta = MessageBox.Show("¿Desea realizar algun abono?", "Factura de Venta",
                                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                            if (rta.Equals(DialogResult.Yes))
                            {
                                if (Convert.ToBoolean(AppConfiguracion.ValorSeccion("btq")))
                                {
                                    // var frmCancelarVenta = new Abonos.FrmCancelarVenta();
                                    var frmCancelarVenta = new Abonos.FrmCancelarVenta2();
                                    frmCancelarVenta.IdFactura = miFactura.Id;
                                    frmCancelarVenta.NumeroFactura = miFactura.Numero;
                                    frmCancelarVenta.NitCliente = miFactura.Proveedor.NitProveedor;
                                    frmCancelarVenta.Abono = true;
                                    frmCancelarVenta.EsVenta = true;
                                    frmCancelarVenta.txtTotal.Text = this.txtTotal.Text; //txtTotalMenosRete.Text;//txtTotal.Text;
                                    frmCancelarVenta.ShowDialog();
                                }
                                else
                                {
                                    var frmCancelarVenta = new Abonos.FrmCancelarVenta();
                                    //var frmCancelarVenta = new Abonos.FrmCancelarVenta2();
                                    frmCancelarVenta.IdFactura = miFactura.Id;
                                    frmCancelarVenta.NumeroFactura = miFactura.Numero;
                                    frmCancelarVenta.NitCliente = miFactura.Proveedor.NitProveedor;
                                    frmCancelarVenta.Abono = true;
                                    frmCancelarVenta.EsVenta = true;
                                    frmCancelarVenta.txtTotal.Text = this.txtTotal.Text; //txtTotalMenosRete.Text;//txtTotal.Text;
                                    frmCancelarVenta.ShowDialog();
                                }

                            }
                        }*/


                        LimpiarCamposNewFactura();
                    }
                    catch (Exception ex)
                    {
                        OptionPane.MessageError(ex.Message);
                    }
                }
            }
        }

        private double[] CargarPuntos(Punto punto, string nitCliente, int id, bool descto)
        {
            double[] data = new double[2];
            try
            {
                int total =
                    this.miBussinesFactura.PrintProducto(id, descto).Tables[0].AsEnumerable().Sum(d => d.Field<int>("Total_"));
                double p = this.miBussinesCliente.Puntos(nitCliente);
                int puntos = 0;
                if (punto.ValorVentaMinPunto > 0 && total > punto.ValorVentaMinPunto)
                {
                    //puntos = Convert.ToInt32(total / punto.ValorPunto);
                    puntos = UseObject.RetiraDecima(total / punto.ValorPunto);
                    puntos *= Convert.ToInt32(punto.NumeroPuntos);
                    p += puntos;
                    this.miBussinesCliente.EditarPuntos(nitCliente, p);
                    data[0] = puntos;
                    data[1] = p;
                }
                else
                {
                    data[0] = 0;
                    data[1] = p;
                }
            }
            catch (Exception ex)
            {
                data[0] = 0;
                data[1] = 0;
                OptionPane.MessageError(ex.Message);
            }
            return data;
        }

        private int ValorPorMarcas()
        {
            int valor = 0;
            try
            {
                foreach (int idMarca in this.miBono.IdMarcas)
                {
                    var productos = this.miFactura.Productos.Where(p_ => p_.Retorno.Equals(false) && p_.Producto.IdMarca.Equals(idMarca));
                    valor += productos.Sum(s => s.Total);
                }
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
            return valor;
        }

        private void LimpiarCamposNewFactura()
        {
            try
            {
                while (dgvListaArticulos.RowCount != 0)
                {
                    dgvListaArticulos.Rows.RemoveAt(0);
                }
                miFormasPago.Clear();

                if (CargaCliente)
                {
                    txtCliente.Text = "1000";
                    txtCliente_KeyPress(this.txtCliente, new KeyPressEventArgs((char)Keys.Enter));
                    txtCodigoArticulo.Focus();
                }
                else
                {
                    NitCliente = "";
                    txtCliente.Text = NitCliente;
                    txtNombreCliente.Text = "";
                    txtCliente.Focus();
                }
                /* NitCliente = "";
                 txtCliente.Text = NitCliente;
                 txtNombreCliente.Text = "";
                 txtCliente.Focus();*/
                //txtCliente_KeyPress(this.txtCliente, new KeyPressEventArgs((char)Keys.Enter));

                this.txtCantidad.Text = "1";
                this.txtTotal.Text = "0";
                this.txtSubtotal.Text = "0";
                this.txtTotalMenosRete.Text = "0";
                txtDescuentoFactura.Text = "0";
                rbtnDesctoFactura.Checked = true;
                cbContado.SelectedIndex = 0;
                //cbDesctoRecargo.SelectedIndex = 0;
                //cbDescuentoProducto.Enabled = false;
                // cbRecargoProducto.Enabled = false;
                tsCbContado_SelectedIndexChanged(this.cbContado, new EventArgs());
                tsCbDesctoRecargo_SelectedIndexChanged(null, null);
                lblDescuentoFactura.Text = "Descto/Fact";
                //lblDesctoProducto.Text = "Descto%";
                lblDatosProducto.Text = "";
                lblPrecioProducto.Text = "";
                txtValorUnitario.Text = "0";
                DesctoAplica = 0;
                this.txtIcoBolsaCant.Text = "0";
                this.txtIcoBolsaTotal.Text = "0";
                this.txtIcoBolsaUnit.Text = "0";
                miTabla.Clear();
                ImpstoBolsa = miBussinesImpstoBolsa.ImpuestoBolsa(1);
                ImpstoBolsa.Cantidad = 0;
                this.miFactura.IcoBolsaPlastica = new ImpuestoBolsa();
                CargarRetencion();
                ValidarRetencion();
                RecargarRetencion();
            } catch { }
        }

        private void CargarFacturaEdicion()
        {
            cbContado.SelectedValue = Factura.EstadoFactura.Id;
            if (Factura.AplicaDescuento)
            {
                cbDesctoRecargo.SelectedValue = 1;
            }
            else
            {
                cbDesctoRecargo.SelectedValue = 2;
            }
            NitCliente = Factura.Proveedor.NitProveedor;
            txtCliente.Text = Factura.Proveedor.NitProveedor;
            txtNombreCliente.Text = Factura.Proveedor.NombreProveedor;
            //txtCliente_KeyPress(this.txtCliente, new KeyPressEventArgs((char)Keys.Enter));
            //lblNoFactura.Text = Factura.Numero;
            miFactura.NumeroEdit = Factura.Numero;
            FechaHoy = Factura.FechaIngreso;
            lblDataFecha.Text = FechaHoy.Day + " de " + UseDate.MesCorto(FechaHoy.Month) + " de " + FechaHoy.Year;
            miTabla = Productos;
            //miBindingSource.DataSource = Productos;
            RecargarGridview();
            txtTotal.Text = UseObject.InsertSeparatorMil
                (
                   Convert.ToInt32(
                   miTabla.AsEnumerable().Sum(s => s.Field<double>("Valor"))
                   ).ToString()
                );
            
            //Productos.Clear();
            //Productos = null;
        }

        /*
        private void Print(string numero, bool descto, string cliente, bool contado, int idEstado)
        {
            var miBussinesRetencion = new BussinesRetencion();
            var dsDetalle = new DataSet();
            var dsEmpresa = new DataSet();
            var dsFactura = new DataSet();
            var dsUsuario = new DataSet();
            var dsCliente = new DataSet();
            var dsDian = new DataSet();
            try
            {
                var empresa = miBussinesEmpresa.ObtenerEmpresa();
                dsDetalle = miBussinesFactura.PrintProducto(numero, descto);
                dsEmpresa = miBussinesEmpresa.PrintEmpresa();
                dsFactura = miBussinesFactura.PrintFacturaVenta(numero);
                dsUsuario = miBussinesUsuario.PrintUsuario(numero);
                dsCliente = miBussinesCliente.PrintCliente(cliente);
                if (idEstado.Equals(4))
                {
                    dsDian = miBussinesDian.PrintVoid();
                    //print_dian
                }
                else
                {
                    if (contado)
                    {
                        dsDian = miBussinesDian.Print(true);
                    }
                    else
                    {
                        dsDian = miBussinesDian.Print(false);
                    }
                }

                var frmPrint = new FrmPrintFactura();

                frmPrint.RptvFactura.LocalReport.DataSources.Clear();
                frmPrint.RptvFactura.LocalReport.Dispose();
                frmPrint.RptvFactura.Reset();

                frmPrint.RptvFactura.LocalReport.DataSources.Add(
                   new ReportDataSource("DsDetalle", dsDetalle.Tables["Detalle"]));
                frmPrint.RptvFactura.LocalReport.DataSources.Add(
                    new ReportDataSource("DsEmpresa", dsEmpresa.Tables["Empresa"]));
                frmPrint.RptvFactura.LocalReport.DataSources.Add(
                    new ReportDataSource("DsFacturaVenta", dsFactura.Tables["FacturaVenta"]));
                frmPrint.RptvFactura.LocalReport.DataSources.Add(
                    new ReportDataSource("DsUsuario", dsUsuario.Tables["Usuario"]));
                frmPrint.RptvFactura.LocalReport.DataSources.Add(
                    new ReportDataSource("DsCliente", dsCliente.Tables["Cliente"]));

                //frmPrint.RptvFactura.LocalReport.ReportPath = AppConfiguracion.ValorSeccion("report") + @"\reports\RptFacturaVenta_vc.rdlc";
                frmPrint.RptvFactura.LocalReport.ReportPath = AppConfiguracion.ValorSeccion("report") + @"\reports\FacturaVenta.rdlc";

                Label NoFactura = new Label();
                NoFactura.AutoSize = true;
                NoFactura.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                NoFactura.Text = numero;

                var Fact = new ReportParameter();
                Fact.Name = "Fact";

                var pResDian = new ReportParameter();
                pResDian.Name = "ResDian";
                if (idEstado == 1 || IdEstado == 2)
                {
                    Fact.Values.Add("FACTURA DE VENTA No.  " + NoFactura.Text);
                }
                else
                {
                    if (IdEstado == 4)
                    {
                        Fact.Values.Add("COTIZACIÓN No. " + numero);
                    }
                }
                if (empresa.Regimen.IdRegimen.Equals(1))
                {
                    pResDian.Values.Add(dsDian.Tables["TDian"].AsEnumerable().Last()["print_dian"].ToString());
                }
                else
                {
                    pResDian.Values.Add(" ");
                }
                frmPrint.RptvFactura.LocalReport.SetParameters(Fact);
                frmPrint.RptvFactura.LocalReport.SetParameters(pResDian);

                var pago = new ReportParameter();
                pago.Name = "pago";
                if (idEstado.Equals(1) || idEstado.Equals(4))
                {
                    pago.Values.Add("Contado");
                }
                else
                {
                    if (idEstado == 2)
                    {
                        pago.Values.Add("Crédito");
                    }
                }
                frmPrint.RptvFactura.LocalReport.SetParameters(pago);

                var totalRete = miBussinesRetencion.ValorRetencionAventa(numero, descto);
                var tReteParam = new ReportParameter();
                tReteParam.Name = "Retencion";
                tReteParam.Values.Add(totalRete.ToString());
                frmPrint.RptvFactura.LocalReport.SetParameters(tReteParam);

                frmPrint.RptvFactura.RefreshReport();
                frmPrint.ShowDialog();

            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
        }
        */

        /*
        private void PrintDespues
            (string numero, bool descto, string cliente, bool contado, int idEstado, bool view)
        {
            var miBussinesRetencion = new BussinesRetencion();
            var dsDetalle = new DataSet();
            var dsEmpresa = new DataSet();
            var dsFactura = new DataSet();
            var dsUsuario = new DataSet();
            var dsCliente = new DataSet();
            //var dsDian = new DataSet();
            try
            {
                var empresa = miBussinesEmpresa.ObtenerEmpresa();
                dsDetalle = miBussinesFactura.PrintProducto(numero, descto);
                dsEmpresa = miBussinesEmpresa.PrintEmpresa();
                dsFactura = miBussinesFactura.PrintFacturaVenta(numero);
                dsUsuario = miBussinesUsuario.PrintUsuario(numero);
                dsCliente = miBussinesCliente.PrintCliente(cliente);
                var dianRow = miBussinesDian.ConsultaDian().AsEnumerable().Last();
               

                var frmPrint = new FrmPrintFactura();

                frmPrint.RptvFactura.LocalReport.DataSources.Clear();
                frmPrint.RptvFactura.LocalReport.Dispose();
                frmPrint.RptvFactura.Reset();

                frmPrint.RptvFactura.LocalReport.DataSources.Add(
                   new ReportDataSource("DsDetalle", dsDetalle.Tables["Detalle"]));
                frmPrint.RptvFactura.LocalReport.DataSources.Add(
                    new ReportDataSource("DsEmpresa", dsEmpresa.Tables["Empresa"]));
                frmPrint.RptvFactura.LocalReport.DataSources.Add(
                    new ReportDataSource("DsFacturaVenta", dsFactura.Tables["FacturaVenta"]));
                frmPrint.RptvFactura.LocalReport.DataSources.Add(
                    new ReportDataSource("DsUsuario", dsUsuario.Tables["Usuario"]));
                frmPrint.RptvFactura.LocalReport.DataSources.Add(
                    new ReportDataSource("DsCliente", dsCliente.Tables["Cliente"]));

                if (empresa.Regimen.IdRegimen.Equals(1))
                {
                    frmPrint.RptvFactura.LocalReport.ReportPath = AppConfiguracion.ValorSeccion("report") + @"\reports\FacturaVenta.rdlc";
                }
                else
                {
                    frmPrint.RptvFactura.LocalReport.ReportPath = AppConfiguracion.ValorSeccion("report") + @"\reports\FacturaVentaSimplificado.rdlc";
                }
                //frmPrint.RptvFactura.LocalReport.ReportPath = AppConfiguracion.ValorSeccion("report") + @"\reports\RptFacturaVenta_vc.rdlc";

                Label NoFactura = new Label();
                NoFactura.AutoSize = true;
                NoFactura.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                NoFactura.Text = numero;

                var Fact = new ReportParameter();
                Fact.Name = "Fact";

                var pResDian = new ReportParameter();
                pResDian.Name = "ResDian";
                if (idEstado == 1 || IdEstado == 2)
                {
                    Fact.Values.Add("FACTURA DE VENTA No.  " + NoFactura.Text);
                }
                else
                {
                    if (IdEstado == 4)
                    {
                        Fact.Values.Add("COTIZACIÓN No. " + numero);
                    }
                }
                if (empresa.Regimen.IdRegimen.Equals(1))
                {
                    //pResDian.Values.Add(dsDian.Tables["TDian"].AsEnumerable().First()["print_dian"].ToString());
                    pResDian.Values.Add("Resolución DIAN No. " + dianRow["Resolucion"].ToString() + " de " +
                        Convert.ToDateTime(dianRow["Fecha"]).ToShortDateString() + " del " + dianRow["Desde"].ToString() + " al " +
                        dianRow["Hasta"].ToString() + " autoriza.");
                }
                else
                {
                    pResDian.Values.Add(" ");
                }
                frmPrint.RptvFactura.LocalReport.SetParameters(Fact);
                frmPrint.RptvFactura.LocalReport.SetParameters(pResDian);

                var pago = new ReportParameter();
                pago.Name = "pago";
                if (idEstado.Equals(1) || idEstado.Equals(4))
                {
                    pago.Values.Add("Contado");
                }
                else
                {
                    if (idEstado == 2)
                    {
                        pago.Values.Add("Crédito");
                    }
                }
                frmPrint.RptvFactura.LocalReport.SetParameters(pago);

                var totalRete = miBussinesRetencion.ValorRetencionAventa(numero, descto);
                var tReteParam = new ReportParameter();
                tReteParam.Name = "Retencion";
                tReteParam.Values.Add(totalRete.ToString());
                frmPrint.RptvFactura.LocalReport.SetParameters(tReteParam);

                frmPrint.RptvFactura.RefreshReport();

                if (view)
                {
                    frmPrint.ShowDialog();
                }
                else
                {
                    Imprimir print = new Imprimir();
                    print.Report = frmPrint.RptvFactura.LocalReport;
                    print.Print(Imprimir.TamanioPapel.MediaCarta);
                    frmPrint.ResetReport();
                }
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
        }
        */

        private void PrintPos
            (int id, bool descto, string cliente, bool contado, int idEstado, int pago)
        {
            try
            {
                var miBussinesIcoBolsas = new BussinesImpuestoBolsa();
                DialogResult rta = DialogResult.Yes;
                if (Convert.ToBoolean(AppConfiguracion.ValorSeccion("preguntaPrintVenta")))
                {
                    rta = MessageBox.Show("¿Desea imprimir la factura?", "Factura venta",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                }
                if (rta.Equals(DialogResult.Yes))
                {

                    var empresaRow = miBussinesEmpresa.PrintEmpresa().
                                     Tables[0].AsEnumerable().First();
                    /* var facturaRow = miBussinesFactura.PrintFacturaVenta(numero).
                                                 Tables[0].AsEnumerable().First();*/
                    var facturaRow = miBussinesFactura.PrintFacturaVenta(id).
                                                Tables[0].AsEnumerable().First();
                    var usuarioRow = miBussinesUsuario.PrintUsuarioVenta(id).
                                           Tables[0].AsEnumerable().First();
                    var clienteRow = miBussinesCliente.PrintCliente(cliente).
                                            Tables[0].AsEnumerable().First();
                    //                var tDetalle = miBussinesFactura.PrintProducto(numero, descto).Tables[0];
                    var tDetalle = miBussinesFactura.PrintProducto(id, descto).Tables[0];
                    var tIva = miBussinesFactura.IvaFacturado(id, descto);
                    var dianRow = miBussinesDian.ConsultaDian().AsEnumerable().Last();
                    var impuesto = miBussinesIcoBolsas.ImpuestoBolsaDeVenta(id);



                    var tipoDoc = "";
                    var No = "";
                    if (idEstado == 1 || idEstado == 2)
                    {
                        tipoDoc = "FACTURA DE VENTA";
                        No = facturaRow["Numero"].ToString();
                    }
                    else
                    {
                        if (idEstado == 4)
                        {
                            tipoDoc = "COTIZACIÓN";
                            No = facturaRow["Numero"].ToString();
                        }
                    }

                    Ticket ticket = new Ticket();
                    ticket.UseItem = false;

                    //test

                    /* var a = empresaRow["Nombre"].ToString().ToUpper();
                     var b = empresaRow["Juridico"].ToString();
                     var c = "NIT " + UseObject.InsertSeparatorMilMasDigito(empresaRow["Nit"].ToString());
                     var d1 = empresaRow["Direccion"].ToString();
                     var e = "Tels. " + empresaRow["Telefono"].ToString();
                     var f = "REGIMEN " + UseObject.Split(empresaRow["Regimen"].ToString(), 5) +
                                          "      " + tipoDoc;
                     var g = "Fecha : " + Convert.ToDateTime(facturaRow["Fecha"]).ToShortDateString() +
                                          " Nro " + No;

                     var hora = Convert.ToDateTime(facturaRow["Hora"]);

                     var h = "Hora  : " + Convert.ToDateTime(facturaRow["Hora"]).ToShortTimeString() +
                                          " Caja " + facturaRow["Caja"].ToString();*/

                    // end test


                    ticket.AddHeaderLine(empresaRow["Nombre"].ToString().ToUpper());
                    ticket.AddHeaderLine(empresaRow["Juridico"].ToString());
                    ticket.AddHeaderLine("NIT " + UseObject.InsertSeparatorMilMasDigito(empresaRow["Nit"].ToString()));
                    ticket.AddHeaderLine(empresaRow["Direccion"].ToString());
                    ticket.AddHeaderLine("Tels. " + empresaRow["Telefono"].ToString());
                    ticket.AddHeaderLine("REGIMEN " + empresaRow["Regimen"].ToString());
                    ticket.AddHeaderLine(tipoDoc + " Nro. " + No);
                    ticket.AddHeaderLine("Fecha : " + Convert.ToDateTime(facturaRow["Fecha"]).ToShortDateString());
                    ticket.AddHeaderLine("Hora  : " + Convert.ToDateTime(facturaRow["Hora"]).ToShortTimeString() +
                                         " Caja " + facturaRow["Caja"].ToString());
                    if (idEstado.Equals(1)) // Contado
                    {
                        var i = "CONTADO  Fecha Limite : " + Convert.ToDateTime(facturaRow["FechaLimite"]).ToShortDateString();//FechaLimite
                        ticket.AddHeaderLine("CONTADO  Fecha Limite : " + Convert.ToDateTime(facturaRow["FechaLimite"]).ToShortDateString());//FechaLimite
                    }
                    else
                    {
                        if (idEstado.Equals(2))  // Credito
                        {
                            ticket.AddHeaderLine("CRÉDITO  Fecha Limite : " + Convert.ToDateTime(facturaRow["FechaLimite"]).ToShortDateString());
                            var j = "CRÉDITO  Fecha Limite : " + Convert.ToDateTime(facturaRow["FechaLimite"]).ToShortDateString();
                        }
                    }
                    ticket.AddHeaderLine("Cajero(a)  :  " + usuarioRow["Nombre"].ToString());
                    //var k = "Cajero(a)  :  " + usuarioRow["Nombre"].ToString();
                    ticket.AddHeaderLine("===================================");
                    ticket.AddHeaderLine("CLIENTE : " + clienteRow["Nombre"].ToString());
                    //var l = "CLIENTE : " + clienteRow["Nombre"].ToString();
                    ticket.AddHeaderLine("NIT     : " + UseObject.InsertSeparatorMilMasDigito(clienteRow["Nit"].ToString()));
                    ticket.AddHeaderLine("===================================");
                    ticket.AddHeaderLine("");
                    //ticket.AddHeaderLine("");

                    ticket.AddHeaderLine("COD.  DESCRIP.  CANT.  VENTA  TOTAL");
                    //ticket.AddHeaderLine("CANT  DESCRIPCION           IMPORTE");
                    // ticket.AddHeaderLine("___________________________________");
                    ticket.AddHeaderLine("");

                    var lstProducto = new List<ProductoFacturaProveedor>();
                    foreach (DataRow dRow in tDetalle.Rows)
                    {
                        lstProducto.Add(new ProductoFacturaProveedor
                        {
                            Cantidad = Convert.ToDouble(dRow["Cantidad"]),
                            Valor = this.miBussinesProducto.ValorDeProducto(dRow["Codigo"].ToString())
                        });

                        string product = dRow["Producto"].ToString();
                        if (product.Length > 30)
                        {
                            product = product.Substring(0, 30);
                        }
                        ticket.AddHeaderLine(dRow["Codigo"].ToString() + " " + product);
                        ticket.AddHeaderLine("              " + dRow["Cantidad"].ToString() + " x " + UseObject.InsertSeparatorMil(dRow["Valor_"].ToString()) +
                                             "  " + UseObject.InsertSeparatorMil(dRow["Total_"].ToString()));

                        /*var line = dRow["Cantidad"].ToString() + " x " + UseObject.InsertSeparatorMil(dRow["Valor_"].ToString()) +
                                            "  " + UseObject.InsertSeparatorMil(dRow["Total_"].ToString());*/

                        /*string product = dRow["Producto"].ToString();
                        string product_2 = "";
                        if (product.Length > 20)
                        {
                            product = product.Substring(0, 20);
                            product_2 = dRow["Producto"].ToString().Substring(20, 40);
                        }
                        var space_cant = "";
                        switch (dRow["Cantidad"].ToString().Length)
                        {
                            case 1:
                                {
                                    space_cant = "     ";
                                    break;
                                }
                            case 2:
                                {
                                    space_cant = "    ";
                                    break;
                                }
                            case 3:
                                {
                                    space_cant = "   ";
                                    break;
                                }
                            case 4:
                                {
                                    space_cant = "  ";
                                    break;
                                }
                            case 5:
                                {
                                    space_cant = " ";
                                    break;
                                }
                        }
                        var space_total = "";
                        switch (UseObject.InsertSeparatorMil(dRow["Total_"].ToString()).Length)
                        {
                            case 3:
                                {
                                    space_total = "      ";
                                    break;
                                }
                            case 5:
                                {
                                    space_total = "    ";
                                    break;
                                }
                            case 6:
                                {
                                    space_total = "   ";
                                    break;
                                }
                            case 7:
                                {
                                    space_total = "  ";
                                    break;
                                }
                        }

                        ticket.AddHeaderLine("      COD:" + dRow["Codigo"].ToString() + " v/u " + UseObject.InsertSeparatorMil(dRow["Valor_"].ToString()));
                        var line = "      COD:" + dRow["Codigo"].ToString() + " v/u " + UseObject.InsertSeparatorMil(dRow["Valor_"].ToString());
                        if (UseObject.InsertSeparatorMil(dRow["Total_"].ToString()).Length > 9 && product_2.Length > 18)
                        {
                            product_2 = product_2.Substring(0, 16);
                            var space_3 = "";
                            for (int i = (product_2.Length + UseObject.InsertSeparatorMil(dRow["Total_"].ToString()).Length); i < 29; i++)
                            {
                                space_3 += " ";
                            }

                            ticket.AddHeaderLine(dRow["Cantidad"].ToString() + space_cant + product);
                            line = dRow["Cantidad"].ToString() + space_cant + product;
                            ticket.AddHeaderLine("      " + product_2 + space_3 + UseObject.InsertSeparatorMil(dRow["Total_"].ToString()));
                            line = "      " + product_2 + space_3 + UseObject.InsertSeparatorMil(dRow["Total_"].ToString());
                        }
                        else
                        {
                            ticket.AddHeaderLine(dRow["Cantidad"].ToString() + space_cant + product + space_total +
                                UseObject.InsertSeparatorMil(dRow["Total_"].ToString()));
                            line = dRow["Cantidad"].ToString() + space_cant + product + space_total +
                                UseObject.InsertSeparatorMil(dRow["Total_"].ToString());
                            if (product_2 != "")
                            {
                                ticket.AddHeaderLine("      " + product_2);
                                line = "      " + product_2;
                            }
                        }*/

                        //ticket.AddHeaderLine("");
                    }

                    ticket.AddHeaderLine("");
                    ticket.AddHeaderLine("===================================");
                    ticket.AddHeaderLine("");
                    var total = tDetalle.AsEnumerable().Sum(d => d.Field<int>("Total_")) + (impuesto.Cantidad * impuesto.Valor);

                    ticket.AddHeaderLine("TOTAL     : " + UseObject.InsertSeparatorMil(total.ToString()));
                    if (idEstado.Equals(1))
                    {
                        ticket.AddHeaderLine("EFECTIVO  : " + UseObject.InsertSeparatorMil(pago.ToString()));
                        ticket.AddHeaderLine("CAMBIO    : " + UseObject.InsertSeparatorMil((pago - total).ToString()));
                    }
                    else
                    {
                        if (idEstado.Equals(2))
                        {
                            ticket.AddHeaderLine("EFECTIVO  : " + "0");
                            ticket.AddHeaderLine("CAMBIO    : " + "0");
                        }
                    }
                    /* int ahorro = Convert.ToInt32(lstProducto.Sum(s => s.Valor * s.Cantidad)) - 
                         tDetalle.AsEnumerable().Sum(d => d.Field<int>("Total_"));
                     ticket.AddHeaderLine("");
                     ticket.AddHeaderLine("");
                     ticket.AddHeaderLine("Su ahorro fue de:  " + UseObject.InsertSeparatorMil(ahorro.ToString()));
                     ticket.AddHeaderLine("");
                     ticket.AddHeaderLine("");*/
                    if (Convert.ToInt32(empresaRow["idregimen"]).Equals(1))
                    {
                        if (idEstado.Equals(1) || idEstado.Equals(2))
                        {
                            ticket.AddHeaderLine("-------Discriminación de IVA-------");
                            ticket.AddHeaderLine("");
                            ticket.AddHeaderLine("GRAVADO        BASE        IVA");
                            ticket.AddHeaderLine("");

                            foreach (DataRow iRow in tIva.Rows)
                            {
                                ticket.AddHeaderLine(iRow["Iva"].ToString() + "           " +
                                                     UseObject.InsertSeparatorMil(Convert.ToInt32(iRow["Base"]).ToString()) + "     " +
                                                     UseObject.InsertSeparatorMil(Convert.ToInt32(iRow["VIva"]).ToString()));
                                ticket.AddHeaderLine("-----------------------------------");
                            }
                            ticket.AddHeaderLine("");
                            ticket.AddHeaderLine("------INC. de bolsas plásticas-----");
                            ticket.AddHeaderLine("CANT.   IMP. UNITARIO    IMP. TOTAL");
                            if ((impuesto.Cantidad * impuesto.Valor) < 100) // total 2 cifras
                            {
                                ticket.AddHeaderLine("   " + impuesto.Cantidad.ToString() +
                                                     "              " + impuesto.Valor.ToString() +
                                                     "            " + (impuesto.Cantidad * impuesto.Valor).ToString());
                            }
                            else   ///  total de 3 cifras
                            {
                                //ticket.AddHeaderLine("CANT.   IMP. UNITARIO    IMP. TOTAL");
                                ticket.AddHeaderLine("  " + impuesto.Cantidad.ToString() +
                                                     "              " + impuesto.Valor.ToString() +
                                                     "           " + (impuesto.Cantidad * impuesto.Valor).ToString());
                            }
                        }
                    }
                    ticket.AddHeaderLine("-----------------------------------");
                    ticket.AddHeaderLine("");
                    if (Convert.ToInt32(empresaRow["idregimen"]).Equals(1))
                    {
                        if (idEstado.Equals(1) || idEstado.Equals(2))
                        {
                            ticket.AddHeaderLine(dianRow["TxtInicial"].ToString() + dianRow["Resolucion"].ToString());
                            ticket.AddHeaderLine("de " + Convert.ToDateTime(dianRow["Fecha"]).ToShortDateString());
                            ticket.AddHeaderLine(dianRow["TxtFinal"].ToString() + " del " + dianRow["Desde"].ToString() + " al " + dianRow["Hasta"].ToString() + ".");

                            /*string test = dianRow["TxtInicial"].ToString() + dianRow["Resolucion"].ToString();
                            test = "de " + Convert.ToDateTime(dianRow["Fecha"]).ToShortDateString();
                            test = dianRow["TxtFinal"].ToString() + " del " + dianRow["Desde"].ToString() + " al " + dianRow["Hasta"].ToString() + ".";
                            */
                        }
                        /*if (idEstado.Equals(1) || idEstado.Equals(2))
                        {
                            ticket.AddHeaderLine("Res DIAN : " + dianRow["Resolucion"].ToString() + " "
                                                 + Convert.ToDateTime(dianRow["Fecha"]).ToShortDateString());
                            ticket.AddHeaderLine("Habilita : " + dianRow["Desde"].ToString() + " Hasta " + dianRow["Hasta"].ToString());
                        }*/
                    }
                    ticket.AddHeaderLine("-----------------------------------");
                    ticket.AddHeaderLine("Software: DFPyme");
                    //ticket.AddHeaderLine("Soluciones Tecnológicas A&C.");
                    //ticket.AddHeaderLine("solucionestecnologicasayc@gmail.com");
                    ticket.AddHeaderLine("");
                    ticket.AddHeaderLine("*GRACIAS POR SER NUESTROS CLIENTES*");
                    ticket.AddHeaderLine("");
                    ticket.AddHeaderLine("");

                    ticket.PrintTicket("IMPREPOS");
                }
                else
                {
                    this.ExpulsarCajonMonedero();
                    try
                    {
                        /*Ticket ticket = new Ticket();
                        ticket.AddFooterLine(".");
                        ticket.PrintTicket("IMPREPOS");*/
                    }
                    catch (Exception ex)
                    {
                        OptionPane.MessageError(ex.Message);
                    }
                }
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
        }

        // Incluye puntos
        private void PrintPos_
            (int id, bool descto, string cliente, bool contado, int idEstado, int pago, bool puntos, double[] data)
        {
            try
            {
                var miBussinesIcoBolsas = new BussinesImpuestoBolsa();
                DialogResult rta = DialogResult.Yes;
                if (Convert.ToBoolean(AppConfiguracion.ValorSeccion("preguntaPrintVenta")))
                {
                    rta = MessageBox.Show("¿Desea imprimir la factura?", "Factura venta",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                }
                if (rta.Equals(DialogResult.Yes))
                {

                    var empresaRow = miBussinesEmpresa.PrintEmpresa().
                                     Tables[0].AsEnumerable().First();
                    var facturaRow = miBussinesFactura.PrintFacturaVenta(id).
                                                Tables[0].AsEnumerable().First();
                    var usuarioRow = miBussinesUsuario.PrintUsuarioVenta(id).
                                           Tables[0].AsEnumerable().First();
                    var clienteRow = miBussinesCliente.PrintCliente(cliente).
                                            Tables[0].AsEnumerable().First();
                    var tDetalle = miBussinesFactura.PrintProducto(id, descto).Tables[0];
                    //var tIva = miBussinesFactura.IvaFacturado(id, descto);
                    var detalleIva = this.miBussinesFactura.IvaFacturado(id);
                    var dianRow = miBussinesDian.ConsultaDian().AsEnumerable().Last();
                    var impuesto = miBussinesIcoBolsas.ImpuestoBolsaDeVenta(id);



                    var tipoDoc = "";
                    var No = "";
                    if (idEstado == 1 || idEstado == 2)
                    {
                        tipoDoc = "FACTURA DE VENTA";
                        No = facturaRow["Numero"].ToString();
                    }
                    else
                    {
                        if (idEstado == 4)
                        {
                            tipoDoc = "COTIZACIÓN";
                            No = facturaRow["Numero"].ToString();
                        }
                    }

                    Ticket ticket = new Ticket();
                    ticket.UseItem = false;

                    ticket.AddHeaderLine(empresaRow["Nombre"].ToString().ToUpper());
                    ticket.AddHeaderLine(empresaRow["Juridico"].ToString());
                    ticket.AddHeaderLine("NIT " + UseObject.InsertSeparatorMilMasDigito(empresaRow["Nit"].ToString()));
                    ticket.AddHeaderLine(empresaRow["Direccion"].ToString());
                    ticket.AddHeaderLine("Tels. " + empresaRow["Telefono"].ToString());
                    ticket.AddHeaderLine("REGIMEN " + empresaRow["Regimen"].ToString());
                    ticket.AddHeaderLine(tipoDoc + " Nro. " + No);
                    ticket.AddHeaderLine("Fecha : " + Convert.ToDateTime(facturaRow["Fecha"]).ToShortDateString());
                    ticket.AddHeaderLine("Hora  : " + Convert.ToDateTime(facturaRow["Hora"]).ToShortTimeString() +
                                         " Caja " + facturaRow["Caja"].ToString());
                    if (idEstado.Equals(1)) // Contado
                    {
                        //var i = "CONTADO  Fecha Limite : " + Convert.ToDateTime(facturaRow["FechaLimite"]).ToShortDateString();//FechaLimite
                        //ticket.AddHeaderLine("CONTADO  Fecha : " + Convert.ToDateTime(facturaRow["FechaLimite"]).ToShortDateString());//FechaLimite
                    }
                    else
                    {
                        if (idEstado.Equals(2))  // Credito
                        {
                            ticket.AddHeaderLine("CRÉDITO  Fecha Limite : " + Convert.ToDateTime(facturaRow["FechaLimite"]).ToShortDateString());
                            // var j = "CRÉDITO  Fecha Limite : " + Convert.ToDateTime(facturaRow["FechaLimite"]).ToShortDateString();
                        }
                    }
                    ticket.AddHeaderLine("Cajero(a)  :  " + usuarioRow["Nombre"].ToString());
                    ticket.AddHeaderLine("-----------------------------------");
                    ticket.AddHeaderLine("CLIENTE : " + clienteRow["Nombre"].ToString());
                    ticket.AddHeaderLine("NIT     : " + UseObject.InsertSeparatorMilMasDigito(clienteRow["Nit"].ToString()));
                    ticket.AddHeaderLine("-----------------------------------");
                    ticket.AddHeaderLine("");

                    var lstProducto = new List<ProductoFacturaProveedor>();
                    if (this.GraneroJhonRiosucio)
                    {
                        this.PrintDetail(tDetalle, ticket, lstProducto);
                    }
                    else
                    {
                        ticket.AddHeaderLine("COD.  DESCRIP.  CANT.  VENTA  TOTAL");
                        ticket.AddHeaderLine("");
                        foreach (DataRow dRow in tDetalle.Rows)
                        {
                            if (this.DescuentoMarca)
                            {
                                lstProducto.Add(new ProductoFacturaProveedor
                                {
                                    Cantidad = Convert.ToDouble(dRow["Cantidad"]),
                                    Valor = this.miBussinesProducto.ValorDeProducto(dRow["Codigo"].ToString())
                                });
                            }
                            string product = dRow["Producto"].ToString();
                            if (product.Length > 30)
                            {
                                product = product.Substring(0, 30);
                            }
                            ticket.AddHeaderLine(dRow["Codigo"].ToString() + " " + product);
                            ticket.AddHeaderLine("              " + dRow["Cantidad"].ToString() + " x " + UseObject.InsertSeparatorMil(dRow["Valor_"].ToString()) +
                                                 "  " + UseObject.InsertSeparatorMil(dRow["Total_"].ToString()));
                        }
                    }
                    //var t__ = lstProducto;

                    ticket.AddHeaderLine("");
                    ticket.AddHeaderLine("-----------------------------------");
                    ticket.AddHeaderLine("");
                    var total = tDetalle.AsEnumerable().Sum(d => d.Field<int>("Total_")) + (impuesto.Cantidad * impuesto.Valor);

                    ticket.AddHeaderLine("TOTAL     : " + UseObject.InsertSeparatorMil(total.ToString()));
                    if (idEstado.Equals(1))
                    {
                        ticket.AddHeaderLine("EFECTIVO  : " + UseObject.InsertSeparatorMil(pago.ToString()));
                        ticket.AddHeaderLine("CAMBIO    : " + UseObject.InsertSeparatorMil((pago - total).ToString()));
                    }
                    else
                    {
                        if (idEstado.Equals(2))
                        {
                            ticket.AddHeaderLine("EFECTIVO  : " + "0");
                            ticket.AddHeaderLine("CAMBIO    : " + "0");
                        }
                    }
                    ticket.AddHeaderLine("");
                    if (puntos)
                    {
                        ticket.AddHeaderLine("-----------------------------------");
                        ticket.AddHeaderLine("");
                        ticket.AddHeaderLine("Puntos de la venta:   " + data[0].ToString());
                        ticket.AddHeaderLine("Puntos acumulados:    " + data[1].ToString());
                        ticket.AddHeaderLine("");
                    }
                    if (this.DescuentoMarca)
                    {
                        int ahorro = Convert.ToInt32(lstProducto.Sum(s => s.Valor * s.Cantidad)) -
                            tDetalle.AsEnumerable().Sum(d => d.Field<int>("Total_"));
                        if (ahorro > 0)
                        {
                            ticket.AddHeaderLine("");
                            ticket.AddHeaderLine("Su ahorro fue de:  $" + UseObject.InsertSeparatorMil(ahorro.ToString()));
                            ticket.AddHeaderLine("");
                            ticket.AddHeaderLine("");
                        }
                    }
                    string total_ = "";
                    string baseIva_ = "";
                    string valorIva_ = "";
                    if (Convert.ToInt32(empresaRow["idregimen"]).Equals(1))
                    {
                        if (idEstado.Equals(1) || idEstado.Equals(2))
                        {
                            ticket.AddHeaderLine("----------[ DETALLE IVA ]----------");
                            ticket.AddHeaderLine("GRAVADO   VENTA      BASE      IVA ");
                            foreach (var iva_ in detalleIva)
                            {
                                total_ = UseObject.InsertSeparatorMil(iva_.Total.ToString());
                                baseIva_ = UseObject.InsertSeparatorMil(iva_.BaseI.ToString());
                                valorIva_ = UseObject.InsertSeparatorMil(iva_.ValorIva.ToString());
                                if (total_.Length >= 10)
                                {
                                    if (iva_.PorcentajeIva.ToString().Length == 1)
                                    {
                                        ticket.AddHeaderLine("  " + iva_.PorcentajeIva + "%");
                                    }
                                    else
                                    {
                                        ticket.AddHeaderLine(" " + iva_.PorcentajeIva + "%");
                                    }
                                }
                                ticket.AddHeaderLine(UseObject.StringBuilderDetalleIva(iva_.PorcentajeIva, total_, baseIva_, valorIva_));
                            }

                            /*foreach (DataRow vRow in tIva.Rows)
                            {
                                total_ = UseObject.InsertSeparatorMil(Convert.ToInt32(vRow["SubTotal"]).ToString());
                                baseIva_ = UseObject.InsertSeparatorMil(Convert.ToInt32(vRow["Base"]).ToString());
                                valorIva_ = UseObject.InsertSeparatorMil(Convert.ToInt32(vRow["VIva"]).ToString());
                                if (total_.Length >= 10)
                                {
                                    if (vRow["Iva"].ToString().Length == 1)
                                    {
                                        ticket.AddHeaderLine("  " + vRow["Iva"].ToString() + "%");
                                    }
                                    else
                                    {
                                        ticket.AddHeaderLine(" " + vRow["Iva"].ToString() + "%");
                                    }
                                }
                                ticket.AddHeaderLine(UseObject.StringBuilderDetalleIva(Convert.ToDouble(vRow["Iva"]), total_, baseIva_, valorIva_));
                            }*/
                            /*ticket.AddHeaderLine("-------Discriminación de IVA-------");
                            ticket.AddHeaderLine("");
                            ticket.AddHeaderLine("GRAVADO        BASE        IVA");
                            ticket.AddHeaderLine("");

                            foreach (DataRow iRow in tIva.Rows)
                            {
                                ticket.AddHeaderLine(iRow["Iva"].ToString() + "           " +
                                                     UseObject.InsertSeparatorMil(Convert.ToInt32(iRow["Base"]).ToString()) + "     " +
                                                     UseObject.InsertSeparatorMil(Convert.ToInt32(iRow["VIva"]).ToString()));
                                ticket.AddHeaderLine("-----------------------------------");
                            }*/
                            ticket.AddHeaderLine("");
                            ticket.AddHeaderLine("-----[ INC. BOLSAS PLÁSTICAS ]-----");
                            ticket.AddHeaderLine("IMP. UNITARIO     CANT.       TOTAL");
                            ticket.AddHeaderLine(UseObject.StringBuilderDetalleINCBP(impuesto.Valor.ToString(),
                                UseObject.InsertSeparatorMil(impuesto.Cantidad.ToString()),
                                UseObject.InsertSeparatorMil((impuesto.Valor * impuesto.Cantidad).ToString())));

                            /* ticket.AddHeaderLine("------INC. de bolsas plásticas-----");
                             ticket.AddHeaderLine("CANT.   IMP. UNITARIO    IMP. TOTAL");
                             if ((impuesto.Cantidad * impuesto.Valor) < 100) // total 2 cifras
                             {
                                 ticket.AddHeaderLine("   " + impuesto.Cantidad.ToString() +
                                                      "              " + impuesto.Valor.ToString() +
                                                      "            " + (impuesto.Cantidad * impuesto.Valor).ToString());
                             }
                             else   ///  total de 3 cifras
                             {
                                 ticket.AddHeaderLine("  " + impuesto.Cantidad.ToString() +
                                                      "              " + impuesto.Valor.ToString() +
                                                      "           " + (impuesto.Cantidad * impuesto.Valor).ToString());
                             }*/
                        }
                    }
                    ticket.AddHeaderLine("-----------------------------------");
                    ticket.AddHeaderLine("");
                    if (Convert.ToInt32(empresaRow["idregimen"]).Equals(1))
                    {
                        if (idEstado.Equals(1) || idEstado.Equals(2))
                        {
                            ticket.AddHeaderLine(dianRow["TxtInicial"].ToString() + dianRow["Resolucion"].ToString());
                            ticket.AddHeaderLine("de " + Convert.ToDateTime(dianRow["Fecha"]).ToShortDateString());
                            ticket.AddHeaderLine(dianRow["TxtFinal"].ToString() + " del " + dianRow["Desde"].ToString() + " al " + dianRow["Hasta"].ToString() + ".");
                        }
                    }
                    ticket.AddHeaderLine("-----------------------------------");
                    ticket.AddHeaderLine("Software: DFPyme");
                    ticket.AddHeaderLine("");
                    ticket.AddHeaderLine("*GRACIAS POR SER NUESTROS CLIENTES*");
                    ticket.AddHeaderLine("");

                    ticket.PrintTicket("IMPREPOS");
                    //ticket.PrintTicket("Microsoft XPS Document Writer");
                }
                else
                {
                    this.ExpulsarCajonMonedero();
                }
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
        }

        //Funcional
        private void PrintPos
            (int id, bool descto, string cliente, bool contado, int idEstado, int pago, bool puntos, double[] data)
        {
            try
            {
                //var miBussinesIcoBolsas = new BussinesImpuestoBolsa();

                DialogResult rta = DialogResult.Yes;
                if (Convert.ToBoolean(AppConfiguracion.ValorSeccion("preguntaPrintVenta")))
                {
                    rta = MessageBox.Show("¿Desea imprimir la factura?", "Factura venta",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                }

                if (rta.Equals(DialogResult.Yes))
                {
                    var facturaRow = miBussinesFactura.PrintFacturaVenta(id).Tables[0].AsEnumerable().First();

                    PrintTicket printTicket = new PrintTicket();
                    printTicket.UseItem = false;
                    printTicket.Detail = this.GraneroJhonRiosucio;
                    printTicket.EsFactura = true;
                    printTicket.Copia = false;
                    printTicket.Puntos = puntos;
                    printTicket.DescuentoMarca = this.DescuentoMarca;

                    printTicket.empresaRow = this.miBussinesEmpresa.PrintEmpresa().Tables[0].AsEnumerable().First();

                    printTicket.IdEstado = idEstado;
                    printTicket.Numero = facturaRow["Numero"].ToString();
                    printTicket.Fecha = Convert.ToDateTime(facturaRow["Fecha"]);
                    printTicket.Hora = Convert.ToDateTime(facturaRow["Hora"]);
                    printTicket.Limite = Convert.ToDateTime(facturaRow["FechaLimite"]);

                    printTicket.Usuario = this.miBussinesUsuario.PrintUsuarioVenta(id).Tables[0].AsEnumerable().First()["Nombre"].ToString();

                    printTicket.NoCaja = facturaRow["Caja"].ToString();
                    printTicket.Station = facturaRow["estacion"].ToString();

                    printTicket.clienteRow = this.miBussinesCliente.ConsultaClienteNit(cliente).AsEnumerable().First();
                    printTicket.DatosCliente = this.DatosCliente;

                    printTicket.tDetalle = this.miBussinesFactura.PrintProducto(id, descto).Tables[0];
                    printTicket.Pago = pago;

                    if (cliente != "10" && cliente != "1000")
                    {
                        //printTicket.Puntos = true;
                        printTicket.DataPuntos = data;
                    }
                    var lstProducto = new List<ProductoFacturaProveedor>();
                    /*foreach (DataRow dRow in printTicket.tDetalle.Rows)
                    {
                        //var c = dRow["Cantidad"].ToString();
                        //c = dRow["Cantidad"].ToString().Replace('.', ',');
                        if (this.DescuentoMarca)
                        {
                            lstProducto.Add(new ProductoFacturaProveedor
                            {
                                Cantidad = Convert.ToDouble(dRow["Cantidad"]),
                                Valor = this.miBussinesProducto.ValorDeProducto(dRow["Codigo"].ToString())
                            });
                        }
                    }*/
                    if (this.DescuentoMarca)
                    {
                        int precio2 = 0;
                        foreach (DataRow dRow in printTicket.tDetalle.Rows)
                        {
                            var p = this.miBussinesProducto.DescuentoPrecio(dRow["Codigo"].ToString());
                            precio2 = p.Precio;
                            if (Convert.ToDouble(dRow["Descuento"]) > 0)  // Aplica descuento al por mayor.
                            {
                                precio2 = Convert.ToInt32(p.Precio - (p.Precio * Convert.ToDouble(dRow["Descuento"]) / 100));
                                if (this.RedondearPrecio2)
                                {
                                    precio2 = UseObject.Aproximar(precio2, Convert.ToBoolean(AppConfiguracion.ValorSeccion("tipo_aprox_precio")));
                                }
                            }
                            lstProducto.Add(new ProductoFacturaProveedor
                            {
                                Cantidad = Convert.ToDouble(dRow["Cantidad"]),
                                Valor = precio2
                            });
                        }
                    }

                    //var t = printTicket.tDetalle.AsEnumerable().Sum(d => d.Field<int>("Total_"));
                    printTicket.Ahorro = Convert.ToInt32(lstProducto.Sum(s => s.Valor * s.Cantidad)) -
                        printTicket.tDetalle.AsEnumerable().Sum(d => d.Field<int>("Total_"));

                    printTicket.DetalleIva = this.miBussinesFactura.IvaFacturado(id);
                    printTicket.impuesto = miBussinesImpstoBolsa.ImpuestoBolsaDeVenta(id);
                    //printTicket.dianRow = this.miBussinesDian.DianRow();
                    printTicket.DianReg = this.miBussinesDian.ConsultaDian(Convert.ToInt32(facturaRow["id_resolucion_dian"]));
                    printTicket.ImprimirVenta();

                    /*
                    var empresaRow = miBussinesEmpresa.PrintEmpresa().
                                     Tables[0].AsEnumerable().First();
                    var facturaRow = miBussinesFactura.PrintFacturaVenta(id).
                                                Tables[0].AsEnumerable().First();
                    var usuarioRow = miBussinesUsuario.PrintUsuarioVenta(id).
                                           Tables[0].AsEnumerable().First();
                    var clienteRow = miBussinesCliente.PrintCliente(cliente).
                                            Tables[0].AsEnumerable().First();
                    var tDetalle = miBussinesFactura.PrintProducto(id, descto).Tables[0];
                    var detalleIva = this.miBussinesFactura.IvaFacturado(id);
                    var dianRow = miBussinesDian.ConsultaDian().AsEnumerable().Last();
                    var impuesto = miBussinesIcoBolsas.ImpuestoBolsaDeVenta(id);

                    var tipoDoc = "";
                    var No = "";
                    if (idEstado == 1 || idEstado == 2)
                    {
                        tipoDoc = "FACTURA DE VENTA";
                        No = facturaRow["Numero"].ToString();
                    }
                    else
                    {
                        if (idEstado == 4)
                        {
                            tipoDoc = "COTIZACIÓN";
                            No = facturaRow["Numero"].ToString();
                        }
                    }

                    Ticket ticket = new Ticket();
                    ticket.UseItem = false;
                    int maxCharacters = 35;

                    foreach (var datos in UseObject.StringBuilderDataCenter(empresaRow["Nombre"].ToString().ToUpper(), maxCharacters))
                    {
                        ticket.AddHeaderLine(datos);
                    }
                    foreach (var datos in UseObject.StringBuilderDataCenter(empresaRow["Juridico"].ToString(), maxCharacters))
                    {
                        ticket.AddHeaderLine(datos);
                    }
                    foreach (var datos in UseObject.StringBuilderDataCenter(
                        "NIT " + UseObject.InsertSeparatorMilMasDigito(empresaRow["Nit"].ToString()), maxCharacters))
                    {
                        ticket.AddHeaderLine(datos);
                    }
                    foreach (var datos in UseObject.StringBuilderDataCenter(empresaRow["Direccion"].ToString(), maxCharacters))
                    {
                        ticket.AddHeaderLine(datos);
                    }
                    foreach (var datos in UseObject.StringBuilderDataCenter(empresaRow["Telefono"].ToString(), maxCharacters))
                    {
                        ticket.AddHeaderLine(datos);
                    }
                    string regimen_ = "";
                    if (Convert.ToInt32(empresaRow["idregimen"]).Equals(1))   //  COMÚN
                    {
                        ticket.AddHeaderLine("RÉGIMEN " + empresaRow["Regimen"].ToString() + "      " + tipoDoc);
                    }
                    else     // SIMPLIFICADO
                    {
                        regimen_ = empresaRow["Regimen"].ToString().Substring(0, 7);
                        ticket.AddHeaderLine("RÉGIMEN " + regimen_ + "   " + tipoDoc);
                    }
                    ticket.AddHeaderLine
                        ("Fecha : " + Convert.ToDateTime(facturaRow["Fecha"]).ToShortDateString() + " Nro " + No);
                    if (idEstado.Equals(2))  // Credito
                    {
                        ticket.AddHeaderLine("CRÉDITO Fecha Limite : " + Convert.ToDateTime(facturaRow["FechaLimite"]).ToShortDateString());
                    }
                    ticket.AddHeaderLine
                        ("Hora  : " + Convert.ToDateTime(facturaRow["Hora"]).TimeOfDay.Hours + ":" + Convert.ToDateTime(facturaRow["Hora"]).TimeOfDay.Minutes +
                         "  Cajero: " + usuarioRow["Nombre"].ToString().Substring(0, 12));
                    ticket.AddHeaderLine("Caja  : " + facturaRow["Caja"].ToString());

                    ticket.AddHeaderLine("-----------------------------------");
                    ticket.AddHeaderLine("CLIENTE : " + clienteRow["Nombre"].ToString());
                    ticket.AddHeaderLine("NIT     : " + UseObject.InsertSeparatorMilMasDigito(clienteRow["Nit"].ToString()));
                    ticket.AddHeaderLine("-----------------------------------");
                    ticket.AddHeaderLine("");

                    string cant = "";
                    string venta = "";
                    string total_ = "";
                    var lstProducto = new List<ProductoFacturaProveedor>();
                    if (this.GraneroJhonRiosucio)
                    {
                        this.PrintDetail(tDetalle, ticket, lstProducto);
                    }
                    else
                    {
                        ticket.AddHeaderLine("DESCRIP.  CANT.    VENTA      TOTAL");
                        ticket.AddHeaderLine("");
                        foreach (DataRow dRow in tDetalle.Rows)
                        {
                            if (this.DescuentoMarca)
                            {
                                lstProducto.Add(new ProductoFacturaProveedor
                                {
                                    Cantidad = Convert.ToDouble(dRow["Cantidad"]),
                                    Valor = this.miBussinesProducto.ValorDeProducto(dRow["Codigo"].ToString())
                                });
                            }
                            string product = dRow["Producto"].ToString();
                            if (product.Length > 30)
                            {
                                product = product.Substring(0, 30);
                            }
                            ticket.AddHeaderLine(dRow["Codigo"].ToString() + " " + product);
                            cant = UseObject.InsertSeparatorMil(dRow["Cantidad"].ToString());
                            venta = UseObject.InsertSeparatorMil(dRow["Valor_"].ToString());
                            total_ = UseObject.InsertSeparatorMil(dRow["Total_"].ToString());
                            ticket.AddHeaderLine(UseObject.StringBuilderDetalleProducto(cant, venta, total_));
                        }
                    }
                    ticket.AddHeaderLine("");
                    ticket.AddHeaderLine("-----------------------------------");
                    ticket.AddHeaderLine("");

                    var total = tDetalle.AsEnumerable().Sum(d => d.Field<int>("Total_")) + (impuesto.Cantidad * impuesto.Valor);
                    total_ = UseObject.InsertSeparatorMil(total.ToString());
                    string efectivo = UseObject.InsertSeparatorMil(pago.ToString());
                    string cambio = UseObject.InsertSeparatorMil((pago - total).ToString());
                    if (idEstado.Equals(2))
                    {
                        efectivo = "0";
                        cambio = "0";
                    }
                    int valorIva = Convert.ToInt32(detalleIva.Sum(s => s.ValorIva));
                    ticket.AddHeaderLine("         SUBTOTAL :" + UseObject.StringBuilderDetalleTotal
                                                                (UseObject.InsertSeparatorMil((total - valorIva).ToString())));
                    ticket.AddHeaderLine("              IVA :" + UseObject.StringBuilderDetalleTotal
                                                                (UseObject.InsertSeparatorMil(valorIva.ToString())));
                    ticket.AddHeaderLine("       TOTAL NETO :" + UseObject.StringBuilderDetalleTotal(total_));
                    ticket.AddHeaderLine("");
                    ticket.AddHeaderLine("         EFECTIVO :" + UseObject.StringBuilderDetalleTotal(efectivo));
                    ticket.AddHeaderLine("           CAMBIO :" + UseObject.StringBuilderDetalleTotal(cambio));
                    ticket.AddHeaderLine("");
                    if (puntos)
                    {
                        ticket.AddHeaderLine("-----------------------------------");
                        ticket.AddHeaderLine("");
                        ticket.AddHeaderLine("Puntos de la venta: " + data[0].ToString());
                        ticket.AddHeaderLine("Puntos acumulados:  " + data[1].ToString());
                        ticket.AddHeaderLine("");
                    }
                    if (this.DescuentoMarca)
                    {
                        int ahorro = Convert.ToInt32(lstProducto.Sum(s => s.Valor * s.Cantidad)) -
                            tDetalle.AsEnumerable().Sum(d => d.Field<int>("Total_"));
                        if (ahorro > 0)
                        {
                            ticket.AddHeaderLine("");
                            ticket.AddHeaderLine("Su ahorro fue de:  $" + UseObject.InsertSeparatorMil(ahorro.ToString()));
                            ticket.AddHeaderLine("");
                            ticket.AddHeaderLine("");
                        }
                    }
                    total_ = "";
                    string baseIva_ = "";
                    string valorIva_ = "";
                    if (Convert.ToInt32(empresaRow["idregimen"]).Equals(1))
                    {
                        if (idEstado.Equals(1) || idEstado.Equals(2))
                        {
                            ticket.AddHeaderLine("----------[ DETALLE IVA ]----------");
                            ticket.AddHeaderLine("GRAVADO   VENTA      BASE      IVA ");
                            foreach (var iva_ in detalleIva)
                            {
                                total_ = UseObject.InsertSeparatorMil(iva_.Total.ToString());
                                baseIva_ = UseObject.InsertSeparatorMil(iva_.BaseI.ToString());
                                valorIva_ = UseObject.InsertSeparatorMil(iva_.ValorIva.ToString());
                                if (total_.Length >= 10)
                                {
                                    if (iva_.PorcentajeIva.ToString().Length == 1)
                                    {
                                        ticket.AddHeaderLine("  " + iva_.PorcentajeIva + "%");
                                    }
                                    else
                                    {
                                        ticket.AddHeaderLine(" " + iva_.PorcentajeIva + "%");
                                    }
                                }
                                ticket.AddHeaderLine(UseObject.StringBuilderDetalleIva(iva_.PorcentajeIva, total_, baseIva_, valorIva_));
                            }
                            ticket.AddHeaderLine("");
                            ticket.AddHeaderLine("-----[ INC. BOLSAS PLÁSTICAS ]-----");
                            ticket.AddHeaderLine("IMP. UNITARIO     CANT.       TOTAL");
                            ticket.AddHeaderLine(UseObject.StringBuilderDetalleINCBP(impuesto.Valor.ToString(),
                                UseObject.InsertSeparatorMil(impuesto.Cantidad.ToString()),
                                UseObject.InsertSeparatorMil((impuesto.Valor * impuesto.Cantidad).ToString())));
                        }
                    }
                    ticket.AddHeaderLine("-----------------------------------");

                    //**
                    ticket.AddHeaderLine("");
                    if (Convert.ToInt32(empresaRow["idregimen"]).Equals(1))
                    {
                        if (idEstado.Equals(1) || idEstado.Equals(2))
                        {
                            foreach (var stringDian in UseObject.StringBuilderDetalleDIAN
                                (dianRow["TxtInicial"].ToString() + dianRow["Resolucion"].ToString(), maxCharacters))
                            {
                                ticket.AddHeaderLine(stringDian);
                            }
                            ticket.AddHeaderLine("de " + Convert.ToDateTime(dianRow["Fecha"]).ToShortDateString());
                            foreach (var stringDian in UseObject.StringBuilderDetalleDIAN
                                (dianRow["TxtFinal"].ToString() + " del " + dianRow["Desde"].ToString() + " al " + dianRow["Hasta"].ToString() + ".", maxCharacters))
                            {
                                ticket.AddHeaderLine(stringDian);
                            }
                        }
                    }
                    ticket.AddHeaderLine("-----------------------------------");
                    ticket.AddHeaderLine("SOFTWARE  DFPYME");
                    ticket.AddHeaderLine("");
                    ticket.AddHeaderLine("*GRACIAS POR SER NUESTROS CLIENTES*");
                    ticket.AddHeaderLine("");
                    ticket.PrintTicket("Microsoft XPS Document Writer");
                    //ticket.PrintTicket("IMPREPOS");
                    */
                }
                else
                {
                    this.ExpulsarCajonMonedero();
                }
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
        }


        //Funcional
        private void PrintPos50mm(int id, bool descto, int idEstado, string cliente, int pago)
        {
            try
            {
                int maxCharacters = 27;
                //var miBussinesIcoBolsas = new BussinesImpuestoBolsa();

                DialogResult rta = DialogResult.Yes;
                if (Convert.ToBoolean(AppConfiguracion.ValorSeccion("preguntaPrintVenta")))
                {
                    rta = MessageBox.Show("¿Desea imprimir la factura?", "Factura venta",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                }

                if (rta.Equals(DialogResult.Yes))
                {
                    var empresaRow = this.miBussinesEmpresa.PrintEmpresa().Tables[0].AsEnumerable().First();
                    var facturaRow = miBussinesFactura.PrintFacturaVenta(id).Tables[0].AsEnumerable().First();
                    var tProductos = this.miBussinesFactura.PrintProducto(id, descto).Tables[0];
                    DataRow rowCliente = this.miBussinesCliente.ConsultaClienteNit(cliente).AsEnumerable().First();
                    //printTicket.clienteRow = this.miBussinesCliente.ConsultaClienteNit(cliente).AsEnumerable().First();


                    Ticket miTicket = new Ticket();
                    miTicket.UseItem = false;
                    miTicket.Printer80mm = false;

                    miTicket.AddHeaderLine(empresaRow["Nombre"].ToString().ToUpper());
                    miTicket.AddHeaderLine(empresaRow["Juridico"].ToString().ToUpper());
                    miTicket.AddHeaderLine(empresaRow["Nit"].ToString().ToUpper());
                    miTicket.AddHeaderLine(empresaRow["direccion_"].ToString().ToUpper());
                    miTicket.AddHeaderLine(empresaRow["ciudad"].ToString().ToUpper() + " " + 
                        empresaRow["departamento"].ToString().ToUpper());
                    miTicket.AddHeaderLine(empresaRow["celularempresa"].ToString().ToUpper());
                    
                    miTicket.AddHeaderLine("---------------------------");
                    miTicket.AddHeaderLine("Ticket Venta No. " + facturaRow["Numero"].ToString());
                    DateTime hora =  Convert.ToDateTime(facturaRow["Hora"]);
                    miTicket.AddHeaderLine("Fecha: " + Convert.ToDateTime(facturaRow["Fecha"]).ToShortDateString() + " " + 
                        hora.TimeOfDay.Hours + ":" + hora.TimeOfDay.Minutes.ToString());
                    if (idEstado.Equals(2))  // Credito
                    {
                        miTicket.AddHeaderLine("CRÉDITO");
                    }
                    miTicket.AddHeaderLine("---------------------------");
                    miTicket.AddHeaderLine(rowCliente["nombrescliente"].ToString());
                    miTicket.AddHeaderLine(rowCliente["nitcliente"].ToString());
                    miTicket.AddHeaderLine("---------------------------");
                    miTicket.AddHeaderLine("ARTICULO CANT. V UND. TOTAL");
                    miTicket.AddHeaderLine("---------------------------");
                    string product = "", cant = "", venta = "", total = "";
                    foreach (DataRow pRow in tProductos.Rows)
                    {
                        product = pRow["Producto"].ToString();
                        if (product.Length > maxCharacters)
                        {
                            product = product.Substring(0, maxCharacters);
                        }
                        miTicket.AddHeaderLine(product);

                        cant = UseObject.InsertSeparatorMil(pRow["Cantidad"].ToString());
                        venta = UseObject.InsertSeparatorMil(pRow["Valor_"].ToString());
                        total = UseObject.InsertSeparatorMil(pRow["Total_"].ToString());

                        miTicket.AddHeaderLine(UseObject.FuncionEspacio(7 - cant.Length) + cant +
                            UseObject.FuncionEspacio(10 - venta.Length) + venta + 
                            UseObject.FuncionEspacio(10 - total.Length) + total);
                    }    
                    miTicket.AddHeaderLine("");
                    miTicket.AddHeaderLine("");
                    miTicket.AddHeaderLine("---------------------------");
                    miTicket.AddHeaderLine("TOTAL: $          " + UseObject.InsertSeparatorMil(tProductos.AsEnumerable().Sum(s => s.Field<int>("Total_")).ToString()));
                    miTicket.AddHeaderLine("---------------------------");
                    if (idEstado.Equals(1))  // Contado
                    {
                        miTicket.AddHeaderLine("Efectivo: $       " + UseObject.InsertSeparatorMil(pago.ToString()));
                        miTicket.AddHeaderLine("Cambio  : $       " + UseObject.InsertSeparatorMil((pago - tProductos.AsEnumerable().Sum(s => s.Field<int>("Total_"))).ToString()));
                    }
                    miTicket.AddHeaderLine("");
                    miTicket.AddHeaderLine("Atendido por: " + this.miBussinesUsuario.PrintUsuarioVenta(id).Tables[0].AsEnumerable().First()["Nombre"].ToString().Substring(0, 13));
                    miTicket.AddHeaderLine("");

                    miTicket.PrintTicket("");

                }
                else
                {
                    this.ExpulsarCajonMonedero();
                }
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
        }


        private void PrintPosCopy(int idFactura)
        {
            try
            {
                var facturaRow = miBussinesFactura.PrintFacturaVenta(idFactura).Tables[0].AsEnumerable().First();

                PrintTicket printTicket = new PrintTicket();
                printTicket.UseItem = false;
                printTicket.Detail = this.GraneroJhonRiosucio;
                printTicket.EsFactura = true;
                printTicket.Copia = true;

                printTicket.empresaRow = this.miBussinesEmpresa.PrintEmpresa().Tables[0].AsEnumerable().First();

                printTicket.IdEstado = Convert.ToInt32(facturaRow["Estado"]);
                printTicket.Numero = facturaRow["Numero"].ToString();
                printTicket.Fecha = Convert.ToDateTime(facturaRow["Fecha"]);
                printTicket.Hora = Convert.ToDateTime(facturaRow["Hora"]);
                printTicket.Limite = Convert.ToDateTime(facturaRow["FechaLimite"]);

                printTicket.Usuario = this.miBussinesUsuario.PrintUsuarioVenta(idFactura).Tables[0].AsEnumerable().First()["Nombre"].ToString();

                printTicket.NoCaja = facturaRow["Caja"].ToString();
                printTicket.clienteRow = this.miBussinesCliente.ConsultaClienteNit(facturaRow["nitcliente"].ToString()).AsEnumerable().First();

                printTicket.tDetalle = this.miBussinesFactura.PrintProducto(idFactura, false).Tables[0];

                if (facturaRow["nitcliente"].ToString() != "10" && facturaRow["nitcliente"].ToString() != "1000")
                {
                    printTicket.Puntos = true;
                    printTicket.DataPuntos = new double[] { Convert.ToDouble(printTicket.clienteRow["punto"]) };
                }
                printTicket.Pago = miBussinesFormaPago.GetTotalPagoDeFacturaVentaId(idFactura);
                printTicket.DetalleIva = this.miBussinesFactura.IvaFacturado(idFactura);
                printTicket.impuesto = this.miBussinesImpstoBolsa.ImpuestoBolsaDeVenta(idFactura);
                //printTicket.dianRow = this.miBussinesDian.DianRow();
                printTicket.DianReg = this.miBussinesDian.ConsultaDian(Convert.ToInt32(facturaRow["id_resolucion_dian"]));
                printTicket.ImprimirVenta();
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
        }

        private void PrintDetail(DataTable tDetalle, Ticket ticket, List<ProductoFacturaProveedor> lstProducto)
        {
            //ticket.AddHeaderLine("CANT  DESCRIPCION           IMPORTE");
            ticket.AddHeaderLine("CANT  DESCRIPCION             TOTAL");
            ticket.AddHeaderLine("");
            foreach (DataRow dRow in tDetalle.Rows)
            {
                if (this.DescuentoMarca)
                {
                    lstProducto.Add(new ProductoFacturaProveedor
                    {
                        Cantidad = Convert.ToDouble(dRow["Cantidad"]),
                        Valor = this.miBussinesProducto.ValorDeProducto(dRow["Codigo"].ToString())
                    });
                }
                string product = dRow["Producto"].ToString();
                string product_2 = "";
                if (product.Length > 19)
                {
                    product = product.Substring(0, 19);
                    product_2 = dRow["Producto"].ToString().Substring(19);
                }
                var space_cant = "";
                switch (dRow["Cantidad"].ToString().Length)
                {
                    case 1:
                        {
                            space_cant = "     ";
                            break;
                        }
                    case 2:
                        {
                            space_cant = "    ";
                            break;
                        }
                    case 3:
                        {
                            space_cant = "   ";
                            break;
                        }
                    case 4:
                        {
                            space_cant = "  ";
                            break;
                        }
                    case 5:
                        {
                            space_cant = " ";
                            break;
                        }
                }
                var space_total = "";
                switch (UseObject.InsertSeparatorMil(dRow["Total_"].ToString()).Length)
                {
                    case 3:
                        {
                            space_total = "      ";
                            break;
                        }
                    case 5:
                        {
                            space_total = "    ";
                            break;
                        }
                    case 6:
                        {
                            space_total = "   ";
                            break;
                        }
                    case 7:
                        {
                            space_total = "  ";
                            break;
                        }
                    case 9:
                        {
                            space_total = " ";
                            break;
                        }
                }
                ticket.AddHeaderLine("      COD:" + dRow["Codigo"].ToString() + " v/u " + UseObject.InsertSeparatorMil(dRow["Valor_"].ToString()));
                var line = "      COD:" + dRow["Codigo"].ToString() + " v/u " + UseObject.InsertSeparatorMil(dRow["Valor_"].ToString());
                if (UseObject.InsertSeparatorMil(dRow["Total_"].ToString()).Length > 9 && product_2.Length > 18)
                {
                    product_2 = product_2.Substring(0, 16);
                    var space_3 = "";
                    for (int i = (product_2.Length + UseObject.InsertSeparatorMil(dRow["Total_"].ToString()).Length); i < 29; i++)
                    {
                        space_3 += " ";
                    }

                    ticket.AddHeaderLine(dRow["Cantidad"].ToString() + space_cant + product);
                    line = dRow["Cantidad"].ToString() + space_cant + product;
                    ticket.AddHeaderLine("      " + product_2 + space_3 + UseObject.InsertSeparatorMil(dRow["Total_"].ToString()));
                    line = "      " + product_2 + space_3 + UseObject.InsertSeparatorMil(dRow["Total_"].ToString());
                }
                else
                {
                    ticket.AddHeaderLine(dRow["Cantidad"].ToString() + space_cant + product + space_total +
                        UseObject.InsertSeparatorMil(dRow["Total_"].ToString()));
                    line = dRow["Cantidad"].ToString() + space_cant + product + space_total +
                        UseObject.InsertSeparatorMil(dRow["Total_"].ToString());
                    if (product_2 != "")
                    {
                        ticket.AddHeaderLine("      " + product_2);
                        line = "      " + product_2;
                    }
                }
                ticket.AddHeaderLine("");
            }
        }

        private void PrintBonoRifa(Bono bono, string cliente, string numero)
        {
            try
            {
                PrintTicket printTicket = new PrintTicket();
                printTicket.UseItem = false;
                printTicket.empresaRow = this.miBussinesEmpresa.PrintEmpresa().Tables[0].AsEnumerable().First();
                printTicket.Bono = bono;
                if (cliente == "1000" || cliente == "10")
                {
                    printTicket.Cliente = new DTO.Clases.Cliente();
                }
                else
                {
                    printTicket.Cliente = this.miBussinesCliente.ClienteAEditar(cliente);
                }
                printTicket.Numero = numero;
                printTicket.ImprimirBonoRifa();
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
        }

        /*
        private void PrintPos
            (string numero, int id, bool descto, string cliente, bool contado, int idEstado, int pago)
        {
            try
            {
                var miBussinesIcoBolsas = new BussinesImpuestoBolsa();
                DialogResult rta = DialogResult.Yes;
                if (Convert.ToBoolean(AppConfiguracion.ValorSeccion("preguntaPrintVenta")))
                {
                    rta = MessageBox.Show("¿Desea imprimir la factura?", "Factura venta",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                }
                if (rta.Equals(DialogResult.Yes))
                {
                    var empresaRow = miBussinesEmpresa.PrintEmpresa().
                                     Tables[0].AsEnumerable().First();
                    var facturaRow = miBussinesFactura.PrintFacturaVenta(id).
                                                Tables[0].AsEnumerable().First();
                    var usuarioRow = miBussinesUsuario.PrintUsuarioVenta(id).
                                           Tables[0].AsEnumerable().First();
                    var clienteRow = miBussinesCliente.PrintCliente(cliente).
                                            Tables[0].AsEnumerable().First();
                    var tDetalle = miBussinesFactura.PrintProducto(id, descto).Tables[0];
                    var tIva = miBussinesFactura.IvaFacturado(id, descto);
                    var dianRow = miBussinesDian.ConsultaDian().AsEnumerable().Last();
                    var impuesto = miBussinesIcoBolsas.ImpuestoBolsaDeVenta(id);

                    var tipoDoc = "";
                    var No = "";
                    if (idEstado == 1 || idEstado == 2)
                    {
                        tipoDoc = "FACTURA DE VENTA";
                        No = facturaRow["Numero"].ToString();
                    }
                    else
                    {
                        if (idEstado == 4)
                        {
                            tipoDoc = "COTIZACIÓN";
                            No = facturaRow["Numero"].ToString();
                        }
                    }

                    Ticket ticket = new Ticket();
                    ticket.UseItem = false;

                    ticket.AddHeaderLine(empresaRow["Nombre"].ToString().ToUpper());
                    ticket.AddHeaderLine(empresaRow["Juridico"].ToString());
                    ticket.AddHeaderLine("NIT " + UseObject.InsertSeparatorMilMasDigito(empresaRow["Nit"].ToString()));
                    ticket.AddHeaderLine(empresaRow["Direccion"].ToString());
                    ticket.AddHeaderLine("Tels. " + empresaRow["Telefono"].ToString());
                    ticket.AddHeaderLine("REGIMEN " + empresaRow["Regimen"].ToString());
                    ticket.AddHeaderLine(tipoDoc + " Nro. " + No);
                    ticket.AddHeaderLine("Fecha : " + Convert.ToDateTime(facturaRow["Fecha"]).ToShortDateString());
                    ticket.AddHeaderLine("Hora  : " + Convert.ToDateTime(facturaRow["Hora"]).ToShortTimeString() +
                                         " Caja " + facturaRow["Caja"].ToString());
                    if (idEstado.Equals(1)) // Contado
                    {
                        //var i = "CONTADO  Fecha Limite : " + Convert.ToDateTime(facturaRow["FechaLimite"]).ToShortDateString();//FechaLimite
                        ticket.AddHeaderLine("CONTADO  Fecha Limite : " + Convert.ToDateTime(facturaRow["FechaLimite"]).ToShortDateString());//FechaLimite
                    }
                    else
                    {
                        if (idEstado.Equals(2))  // Credito
                        {
                            ticket.AddHeaderLine("CRÉDITO  Fecha Limite : " + Convert.ToDateTime(facturaRow["FechaLimite"]).ToShortDateString());
                            //var j = "CRÉDITO  Fecha Limite : " + Convert.ToDateTime(facturaRow["FechaLimite"]).ToShortDateString();
                        }
                    }
                    ticket.AddHeaderLine("Cajero(a)  :  " + usuarioRow["Nombre"].ToString());
                    //var k = "Cajero(a)  :  " + usuarioRow["Nombre"].ToString();
                    ticket.AddHeaderLine("===================================");
                    ticket.AddHeaderLine("CLIENTE : " + clienteRow["Nombre"].ToString());
                    //var l = "CLIENTE : " + clienteRow["Nombre"].ToString();
                    ticket.AddHeaderLine("NIT     : " + UseObject.InsertSeparatorMilMasDigito(clienteRow["Nit"].ToString()));
                    //var m = "NIT     : " + UseObject.InsertSeparatorMilMasDigito(clienteRow["Nit"].ToString());

                    foreach (DataRow dRow in tDetalle.Rows)
                    {
                        ticket.AddItem("",
                                       "COD:" + dRow["Codigo"].ToString() +
                                       " v/u " + UseObject.InsertSeparatorMil(dRow["Valor_"].ToString()).ToString(),
                                       "");
                        ticket.AddItem(dRow["Cantidad"].ToString(),
                                       dRow["Producto"].ToString(),
                                       UseObject.InsertSeparatorMil(dRow["Total_"].ToString()));
                        ticket.AddItem("", "", "");

                    }
                    var total = tDetalle.AsEnumerable().Sum(d => d.Field<int>("Total_")) + (impuesto.Cantidad * impuesto.Valor);

                    ticket.AddTotal("TOTAL     : ", UseObject.InsertSeparatorMil(total.ToString()));
                    if (idEstado.Equals(1))
                    {
                        ticket.AddTotal("EFECTIVO  : ", UseObject.InsertSeparatorMil(pago.ToString()));
                        ticket.AddTotal("CAMBIO    : ", UseObject.InsertSeparatorMil((pago - total).ToString()));
                    }
                    else
                    {
                        if (idEstado.Equals(2))
                        {
                            ticket.AddTotal("EFECTIVO  : ", "0");
                            ticket.AddTotal("CAMBIO    : ", "0");
                        }
                    }
                    ticket.AddHeaderLine("==================================="); // Revisar
                    if (Convert.ToInt32(empresaRow["idregimen"]).Equals(1))
                    {
                        if (idEstado.Equals(1) || idEstado.Equals(2))
                        {
                            ticket.AddFooterLine("-------Discriminación de IVA-------");
                            ticket.AddFooterLine(".");
                            ticket.AddHeaderLine("GRAVADO         BASE         IVA");
                            ticket.AddFooterLine(".");

                            foreach (DataRow iRow in tIva.Rows)
                            {
                                ticket.AddFooterLine("  " + iRow["Iva"].ToString() +
                                                 "   " + UseObject.InsertSeparatorMil(Convert.ToInt32(iRow["Base"]).ToString()) +
                                                 "        " + UseObject.InsertSeparatorMil(Convert.ToInt32(iRow["VIva"]).ToString()));
                                ticket.AddFooterLine("-----------------------------------");
                            }
                            ticket.AddFooterLine(".");
                            ticket.AddFooterLine("------INC. de bolsas plásticas----");
                            ticket.AddFooterLine("CANT.   IMP. UNITARIO   IMP. TOTAL");
                            if ((impuesto.Cantidad * impuesto.Valor) < 100) // total 2 cifras
                            {
                                ticket.AddFooterLine("   " + impuesto.Cantidad.ToString() +
                                                     "              " + impuesto.Valor.ToString() +
                                                     "            " + (impuesto.Cantidad * impuesto.Valor).ToString());
                            }
                            else   ///  total de 3 cifras
                            {
                                ticket.AddFooterLine("CANT.   IMP. UNITARIO    IMP. TOTAL");
                                ticket.AddFooterLine("  " + impuesto.Cantidad.ToString() +
                                                     "              " + impuesto.Valor.ToString() +
                                                     "           " + (impuesto.Cantidad * impuesto.Valor).ToString());
                            }
                        }
                    }
                    ticket.AddFooterLine("-----------------------------------");
                    ticket.AddFooterLine(".");
                    ticket.AddFooterLine(".");
                    ticket.AddFooterLine("-----------------------------------");
                    ticket.AddFooterLine(".");
                    ticket.AddFooterLine(".");
                    if (Convert.ToInt32(empresaRow["idregimen"]).Equals(1))
                    {
                        if (idEstado.Equals(1) || idEstado.Equals(2))
                        {
                            ticket.AddFooterLine("Res DIAN : " + dianRow["Resolucion"].ToString() + " "
                                                 + Convert.ToDateTime(dianRow["Fecha"]).ToShortDateString());
                            ticket.AddFooterLine("Habilita : " + dianRow["Desde"].ToString() + " Hasta " + dianRow["Hasta"].ToString());
                        }
                    }
                    ticket.AddFooterLine("-----------------------------------");
                    ticket.AddFooterLine("Software: DFPyme");
                    ticket.AddFooterLine(".");
                    ticket.AddFooterLine("*GRACIAS POR SER NUESTROS CLIENTES*");
                    ticket.AddFooterLine(".");
                    ticket.AddFooterLine(".");

                    ticket.PrintTicket("IMPREPOS");
                }
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
        }
        */

        private void PrintComprobanteCruce(ComprobanteCruce cruce)
        {
            try
            {
                var print = new FrmComprobanteCruce();
                var cliente = miBussinesCliente.ClienteAEditar(cruce.NitCliente);
                print.Numero = cruce.Id.ToString();
                print.Fecha = cruce.Fecha;
                print.Nit = cliente.NitCliente;
                print.Cliente = cliente.NombresCliente;
                print.Direccion = cliente.DireccionCliente + " " + cliente.Ciudad + " " + cliente.Departamento;
                print.Concepto = cruce.Concepto;
                print.Valor = cruce.Valor.ToString();
                print.Restante = cruce.Restante;
                print.VRestante = cruce.ValorRestante;
                print.ShowDialog();
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
        }


        private void PrintDespues
            (int id, string numero, bool descto, string cliente, bool contado, int idEstado, bool view)
        {
            var miBussinesRetencion = new BussinesRetencion();
            var dsDetalle = new DataSet();
            var dsEmpresa = new DataSet();
            var dsFactura = new DataSet();
            var dsUsuario = new DataSet();
            var dsCliente = new DataSet();
            //var dsDian = new DataSet();
            try
            {
                var empresa = miBussinesEmpresa.ObtenerEmpresa();
                dsDetalle = miBussinesFactura.PrintProducto(id, descto);
                dsEmpresa = miBussinesEmpresa.PrintEmpresa();
                dsFactura = miBussinesFactura.PrintFacturaVenta(id);
                dsUsuario = miBussinesUsuario.PrintUsuarioVenta(id);
                dsCliente = miBussinesCliente.PrintCliente(cliente);
                //var dianRow = miBussinesDian.ConsultaDian().AsEnumerable().Last();
                var dian = miBussinesDian.ConsultaDian(Convert.ToInt32(dsFactura.Tables["FacturaVenta"].AsEnumerable().First()["id_resolucion_dian"]));

                var DetalleIva = this.miBussinesFactura.IvaFacturado(id);

                var frmPrint = new FrmPrintFactura();

                frmPrint.RptvFactura.LocalReport.DataSources.Clear();
                frmPrint.RptvFactura.LocalReport.Dispose();
                frmPrint.RptvFactura.Reset();

                frmPrint.RptvFactura.LocalReport.DataSources.Add(
                   new ReportDataSource("DsDetalle", dsDetalle.Tables["Detalle"]));
                frmPrint.RptvFactura.LocalReport.DataSources.Add(
                    new ReportDataSource("DsEmpresa", dsEmpresa.Tables["Empresa"]));
                frmPrint.RptvFactura.LocalReport.DataSources.Add(
                    new ReportDataSource("DsFacturaVenta", dsFactura.Tables["FacturaVenta"]));
                frmPrint.RptvFactura.LocalReport.DataSources.Add(
                    new ReportDataSource("DsUsuario", dsUsuario.Tables["Usuario"]));
                frmPrint.RptvFactura.LocalReport.DataSources.Add(
                    new ReportDataSource("DsCliente", dsCliente.Tables["Cliente"]));

                if (empresa.Regimen.IdRegimen.Equals(1))
                {
                    frmPrint.RptvFactura.LocalReport.ReportPath = AppConfiguracion.ValorSeccion("report") + @"\reports\FacturaVenta_carta_act.rdlc";

                    ///frmPrint.RptvFactura.LocalReport.ReportPath = AppConfiguracion.ValorSeccion("report") + @"\reports\FacturaVenta.rdlc";
                    ///frmPrint.RptvFactura.LocalReport.ReportPath = @"C:\reports\FacturaVenta_carta_act.rdlc";
                }
                else
                {
                    frmPrint.RptvFactura.LocalReport.ReportPath = AppConfiguracion.ValorSeccion("report") + @"\reports\FacturaVentaSimplificado.rdlc";
                    ///frmPrint.RptvFactura.LocalReport.ReportPath = @"C:\reports\FacturaVentaSimplificado.rdlc";
                }
                //frmPrint.RptvFactura.LocalReport.ReportPath = AppConfiguracion.ValorSeccion("report") + @"\reports\RptFacturaVenta_vc.rdlc";

                Label NoFactura = new Label();
                NoFactura.AutoSize = true;
                NoFactura.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                NoFactura.Text = numero;

                var Fact = new ReportParameter();
                Fact.Name = "Fact";

                var pResDian = new ReportParameter();
                pResDian.Name = "ResDian";
                if (idEstado == 1 || IdEstado == 2)
                {
                    Fact.Values.Add("FACTURA DE VENTA No.  " + NoFactura.Text);
                }
                else
                {
                    if (IdEstado == 4)
                    {
                        Fact.Values.Add("COTIZACIÓN No. " + numero);
                    }
                }
                if (empresa.Regimen.IdRegimen.Equals(1))
                {
                    pResDian.Values.Add(
                        "AUTORIZACIÓN NUMERACIÓN DE FACTURACIÓN " + dian.NumeroResolucion +
                        " DE " + dian.FechaExpedicion.ToShortDateString() +
                        " AUTORIZA DESDE " + dian.SerieInicial + dian.RangoInicial +
                        " HASTA " + dian.SerieInicial + dian.RangoFinal +
                        " VIGENCIA " + dian.VigenciaMes +
                        " MESES.");

                    /**
                    pResDian.Values.Add(dianRow["TxtInicial"].ToString() + dianRow["Resolucion"].ToString() + " de " +
                        Convert.ToDateTime(dianRow["Fecha"]).ToShortDateString() +
                        " del " + dianRow["Desde"].ToString() + " al " + dianRow["Hasta"].ToString() + " " + dianRow["TxtFinal"].ToString() + ".");
                    */
                }
                else
                {
                    pResDian.Values.Add(" ");
                }
                frmPrint.RptvFactura.LocalReport.SetParameters(Fact);
                frmPrint.RptvFactura.LocalReport.SetParameters(pResDian);

                var pago = new ReportParameter();
                pago.Name = "pago";
                if (idEstado.Equals(1) || idEstado.Equals(4))
                {
                    pago.Values.Add("Contado");
                }
                else
                {
                    if (idEstado == 2)
                    {
                        pago.Values.Add("Crédito");
                    }
                }
                frmPrint.RptvFactura.LocalReport.SetParameters(pago);

                var subTotalParam = new ReportParameter();
                subTotalParam.Name = "subTotal";
                subTotalParam.Values.Add(DetalleIva.Sum(s => s.BaseI).ToString());
                frmPrint.RptvFactura.LocalReport.SetParameters(subTotalParam);

                var desctoParam = new ReportParameter();
                desctoParam.Name = "descto";
                desctoParam.Values.Add(Convert.ToInt32(dsDetalle.Tables["Detalle"].AsEnumerable().Sum(s => s.Field<int>("Descto_"))).ToString());
                frmPrint.RptvFactura.LocalReport.SetParameters(desctoParam);

                var ivaParam = new ReportParameter();
                ivaParam.Name = "iva";
                ivaParam.Values.Add(DetalleIva.Sum(s => s.ValorIva).ToString());
                frmPrint.RptvFactura.LocalReport.SetParameters(ivaParam);

                var totalRete = miBussinesRetencion.ValorRetencionAventa(numero, id, descto);
                var tReteParam = new ReportParameter();
                tReteParam.Name = "Retencion";
                tReteParam.Values.Add(totalRete.ToString());
                frmPrint.RptvFactura.LocalReport.SetParameters(tReteParam);

                var totalParam = new ReportParameter();
                totalParam.Name = "total";
                totalParam.Values.Add(DetalleIva.Sum(s => s.Total).ToString());
                frmPrint.RptvFactura.LocalReport.SetParameters(totalParam);

                frmPrint.RptvFactura.RefreshReport();

                if (view)
                {
                    frmPrint.ShowDialog();
                }
                else
                {
                    Imprimir print = new Imprimir();
                    print.Report = frmPrint.RptvFactura.LocalReport;
                    print.Print(Imprimir.TamanioPapel.MediaCarta);
                    frmPrint.ResetReport();
                }
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
        }



        private void dtpFechaLimite_Validating(object sender, CancelEventArgs e)
        {
            if (IdEstado == 2)
            {
                if (!chkAntigua.Checked)
                {
                    if (UseDate.FechaSinHora(dtpFechaLimite.Value) > UseDate.FechaSinHora(FechaHoy))
                    {
                        LimiteMatch = true;
                        miError.SetError(dtpFechaLimite, null);
                    }
                    else
                    {
                        LimiteMatch = false;
                        OptionPane.MessageError("La fecha limite debe ser superior a la de hoy.");
                        miError.SetError(dtpFechaLimite, "La fecha limite debe ser superior a la de hoy.");
                    }
                }
                else
                {
                    LimiteMatch = true;
                }
            }
            else
            {
                //dtpFechaLimite.Value = DateTime.Today;
                LimiteMatch = true;
                miError.SetError(dtpFechaLimite, null);
            }
        }
        private bool LimiteMatch = false;

        private void dtpFechaLimite_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                txtCodigoArticulo.Focus();
            }
        }

        private void txtDescuentoFactura_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                if (!String.IsNullOrEmpty(txtDescuentoFactura.Text))
                {
                    txtDescuentoFactura.Text = txtDescuentoFactura.Text.Replace('.', ',');
                    try
                    {
                        Convert.ToDouble(txtDescuentoFactura.Text);
                        miError.SetError(txtDescuentoFactura, null);
                        txtCodigoArticulo.Focus();
                    }
                    catch
                    {
                        OptionPane.MessageError("El valor que ingreso es inválido.");
                        miError.SetError(txtDescuentoFactura, "El valor que ingreso es inválido.");
                        txtDescuentoFactura.Focus();
                    }
                }
                else
                {
                    txtDescuentoFactura.Text = "0";
                }
            }
        }

        private void txtDescuentoFactura_Validating(object sender, CancelEventArgs e)
        {
            txtDescuentoFactura_KeyPress(this.txtDescuentoFactura, new KeyPressEventArgs((char)Keys.Enter));
        }


        private void chkAntigua_Click(object sender, EventArgs e)
        {
            //IdEstado = Convert.ToInt32(((DataRowView)cbContado.SelectedItem)["idestado"]);
            if (IdEstado != 2)//contado
            {
                if (chkAntigua.Checked)
                {
                    lblDataFecha.Visible = false;
                    dtpFechaLimite.Visible = true;
                    lblFechaLimite.Visible = true;
                    dtpLimite.Visible = true;
                }
                else
                {
                    lblDataFecha.Visible = true;
                    dtpFechaLimite.Visible = false;
                    lblFechaLimite.Visible = false;
                    dtpLimite.Visible = false;
                }
            }
            else//credito
            {
                if (chkAntigua.Checked)
                {
                    lblFecha.Text = "Fecha";
                    lblFechaLimite.Visible = true;
                    dtpLimite.Visible = true;
                }
                else
                {
                    lblFecha.Text = "Limite";
                    lblFechaLimite.Visible = false;
                    dtpLimite.Visible = false;
                }
            }
        }
        bool First = true;
        private void btnCruce_Click(object sender, EventArgs e)
        {

        }

        private void OcultarDescuento()
        {
            cbDesctoRecargo.Visible = false;
            rbtnDesctoProducto.Visible = false;
            pbProducto.Visible = false;
            rbtnDesctoFactura.Visible = false;
            pbFactura.Visible = false;
            lblDescuentoFactura.Visible = false;
            txtDescuentoFactura.Visible = false;
            //lblDesctoProducto.Visible = false;
            cbRecargoProducto.Visible = false;
            cbDescuentoProducto.Visible = false;
            //btnTallaYcolor.Visible = false;
        }

        private void MostrarDescuento()
        {
            cbDesctoRecargo.Visible = true;
            rbtnDesctoProducto.Visible = true;
            pbProducto.Visible = true;
            rbtnDesctoFactura.Visible = true;
            pbFactura.Visible = true;
            lblDescuentoFactura.Visible = true;
            txtDescuentoFactura.Visible = true;
            //lblDesctoProducto.Visible = true;
            cbRecargoProducto.Visible = true;
            cbDescuentoProducto.Visible = true;
        }

        private void ColorearGrid()
        {
            foreach (DataGridViewRow row in this.dgvListaArticulos.Rows)
            {
                if (Convert.ToBoolean(row.Cells["Retorno"].Value))
                {
                    row.DefaultCellStyle.BackColor = System.Drawing.Color.Cyan;
                }
            }
        }

        private void btnBorrarImpstoBolsas_Click(object sender, EventArgs e)
        {
            try
            {
                this.txtIcoBolsaCant.Text = "0";
                this.txtIcoBolsaTotal.Text = "0";
                this.txtIcoBolsaUnit.Text = "0";
                ImpstoBolsa = miBussinesImpstoBolsa.ImpuestoBolsa(1);
                ImpstoBolsa.Cantidad = 0;
                this.CalcularTotal();
            }
            catch { }
            /*this.txtTotalMenosRete.Text = UseObject.InsertSeparatorMil(((UseObject.RemoveSeparatorMil(this.txtTotal.Text) +
              UseObject.RemoveSeparatorMil(this.txtIcoBolsaTotal.Text)) - UseObject.RemoveSeparatorMil(this.txtRetencion.Text)).ToString());*/
        }

        


    }
}