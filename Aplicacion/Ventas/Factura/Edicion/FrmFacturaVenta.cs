using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BussinesLayer.Clases;
using CustomControl;
using DTO.Clases;
using Utilities;
using RawDataPrint;
using Aplicacion.Compras.IngresarCompra;
using Microsoft.Reporting.WinForms;

namespace Aplicacion.Ventas.Factura.Edicion
{
    public partial class FrmFacturaVenta : Form
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


        private BussinesMarca miBussinesMarca;

        private BussinesPunto miBussinesPunto;

        private BussinesCaracteresEscape miBussinesCaracteresEscape;

        private BussinesBonoRifa miBussinesBonoRifa;


        #endregion

        #region Propiedades

        public bool Remision = false;
    
        public bool PagoFactRemision { set; get; }

        /// <summary>
        /// Representa un objeto para la carga de datos de la Empresa.
        /// </summary>
        private Empresa miEmpresa;

        private bool FacturaPos { set; get; }

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

        private bool Transfer;

        private double DesctoAplica { set; get; }

        private bool GraneroJhonRiosucio { set; get; }

        private bool RedondearPrecio2 { set; get; }


        private BussinesRetencion miBussinesRetencion;

        private BussinesFacturaProveedor miBussinesFacturaProveedor;

        private BussinesConsecutivo miBussinesConsecutivo;

        DTO.Clases.Cliente cliente;

        private RetencionConcepto MiRetencion { set; get; }

        private int IdRubroRetencion;

        private bool AplicaRete = false;

        List<RetencionConcepto> Retenciones { set; get; }

        private bool RequiereCantidad { set; get; }

        public const string SuperUsuario = "SUPER_USUARIO";

        public Usuario Usuario_ { set; get; }

        private const int IdPermisoEditarCantidad = 46;

        private bool PermisoEditarCantidad;

        private const int IdPermisoEditarPrecio = 48;

        private bool PermisoEditarPrecio;

        private const int IdPermisoElimiarProducto = 54;

        private bool PermisoElimiarProducto;


        private ImpuestoBolsa ImpstoBolsa;

        private bool DescuentoMarca;

        private bool ConsecutivoCaja;

        public FrmFacturaVenta()
        {
            InitializeComponent();
            try
            {
                this.Transfer = false;
                this.DesctoAplica = 0.0;
                PagoFactRemision = false;
                Edicion = false;
                miFactura = new FacturaVenta();
                //miBussinesFormaPago = new BussinesFormaPago();
                miBussinesEstado = new BussinesEstado();
                miBussinesEmpresa = new BussinesEmpresa();
                miBussinesFactura = new BussinesFacturaVenta();
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
                miBussinesFacturaProveedor = new BussinesFacturaProveedor();
                miBussinesConsecutivo = new BussinesConsecutivo();

                miBussinesMarca = new BussinesMarca();
                miBussinesPunto = new BussinesPunto();
                miBussinesCaracteresEscape = new BussinesCaracteresEscape();
                miBussinesBonoRifa = new BussinesBonoRifa();

                miCaracteresEscape = miBussinesCaracteresEscape.CaracteresPredeterminados();
                miBono = this.miBussinesBonoRifa.BonoRifa();

                CargarEmpresa();
                miFormasPago = new List<DTO.Clases.FormaPago>();
                FechaHoy = DateTime.Now;
                //FacturaPos = Convert.ToBoolean(AppConfiguracion.ValorSeccion("facturapos"));
                EnableColor = Convert.ToBoolean(AppConfiguracion.ValorSeccion("color"));
                Promedio = Convert.ToBoolean(AppConfiguracion.ValorSeccion("promedio"));
                NumeroDeFacturas = Convert.ToInt32(AppConfiguracion.ValorSeccion("numero"));
                FacturaNegativo = Convert.ToBoolean(AppConfiguracion.ValorSeccion("fact-negativo"));
                IdRubroRetencion = Convert.ToInt32(AppConfiguracion.ValorSeccion("idrubro_v"));

                // Revisar (13/06/2019)
                PagoFactRemision = Convert.ToBoolean(AppConfiguracion.ValorSeccion("pagoFactRemision"));

                MiRetencion = new RetencionConcepto();
                CargarRetencion();

                this.GraneroJhonRiosucio = Convert.ToBoolean(AppConfiguracion.ValorSeccion("graneroJhonRiosucio"));
                this.RedondearPrecio2 = Convert.ToBoolean(AppConfiguracion.ValorSeccion("redondeo_precio_dos"));

                ConsecutivoCaja = Convert.ToBoolean(AppConfiguracion.ValorSeccion("consecutivo_caja"));

                miTallaYcolor = new TallaYcolor();
                MiValidacion = new Validacion();
                miError = new ErrorProvider();
                miToolTip = new ToolTip();
                //Convert.ToBoolean(AppConfiguracion.ValorSeccion("color"));
                miBindingSource = new BindingSource();
                CrearDataTable();

                this.miBussinesMarca = new BussinesMarca();
                this.DescuentoMarca = false;
                if (this.miBussinesMarca.MarcaDescuentos().Rows.Count > 0)
                {
                    this.DescuentoMarca = true;
                }
                //ObtenerNumero();
            }
            catch (Exception ex)
            {
                OptionPane.MessageInformation(ex.Message);
            }
        }

        private void FrmFacturaVenta_Load(object sender, EventArgs e)
        {
            try
            {
                var vis = cbRecargoProducto.Visible;
                var ovis = cbDescuentoProducto.Visible;
                //ObtenerNumero();
                this.tsCambiarPrecio.Image = ((System.Drawing.Image)(miResources.GetObject("tsCambiarPrecio.Image")));
                NitCliente = txtCliente.Text;
                lblDataFecha.Text = FechaHoy.Day + " de " + UseDate.MesCorto(FechaHoy.Month) + " de " + FechaHoy.Year;
                CargarUtilidades();
                //ValidarRetencion();
                CompletaEventos.Completa += new CompletaEventos.CompletaAccion(CompletaEventos_Completo);
                CompletaEventos.CompletaEditProveedor +=
                    new CompletaEventos.CompletaAccionEditProveedor(CompletaEventosEditFactura_Completo);
                CompletaEventos.Completaz += new CompletaEventos.CompletaAccionz(CompletaEventos_Completaz);
                CompletaEventos.CompTProductoFact +=
                    new CompletaEventos.ComAxTransferProductFact(CompletaEventos_CompTProductoFact);
                dgvListaArticulos.AutoGenerateColumns = false;
                dgvListaArticulos.DataSource = miBindingSource;
                if (Edicion)
                {
                    CargarFacturaEdicion();
                }

                miFactura.Usuario = Administracion.Usuario.FrmIniciarSesion.CargarDatosUsuario(this);

                this.PermisoEditarCantidad = false;
                this.PermisoEditarPrecio = false;
                this.PermisoElimiarProducto = false;
                foreach (var ps in Usuario_.Permisos)
                {
                    switch (ps.IdPermiso)
                    {
                        case IdPermisoEditarCantidad:
                            {
                                this.PermisoEditarCantidad = true;
                                break;
                            }
                        case IdPermisoEditarPrecio:
                            {
                                this.PermisoEditarPrecio = true;
                                break;
                            }
                        case IdPermisoElimiarProducto:
                            {
                                this.PermisoElimiarProducto = true;
                                break;
                            }
                    }
                }
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
            //  var f = miFactura;
        }

        private void FrmFacturaVenta_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyData)
            {
                case Keys.F2:
                    {
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
                        tsBtnModCantidad_Click(this.tsBtnModCantidad, new EventArgs());
                        break;
                    }
                case Keys.F5:
                    {
                        ActivarDescuento();
                        break;
                    }
                case Keys.F6:
                    {
                        this.tsCambiarPrecio_Click(this.tsCambiarPrecio, new EventArgs());
                        break;
                    }
                case Keys.F7:
                    {
                        if (dgvListaArticulos.RowCount != 0)
                        {
                            Cantidad.ReadOnly = false;
                            txtCodigoArticulo.Focus();
                            dgvListaArticulos.Focus();
                            dgvListaArticulos.EditMode = DataGridViewEditMode.EditOnEnter;
                            dgvListaArticulos.BeginEdit(true);
                        }
                        else
                        {
                            OptionPane.MessageInformation("No hay registros para editar.");
                        }
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
                        //this.tsBtnReset_Click(this.tsBtnReset, new EventArgs());
                        break;
                    }
                case Keys.Escape:
                    {
                        this.Close();
                        break;
                    }
            }
            /*
            if (e.KeyData == Keys.F5)
            {
                if (dgvListaArticulos.RowCount != 0)
                {
                    dgvListaArticulos.Focus();
                    dgvListaArticulos.EditMode = DataGridViewEditMode.EditOnEnter;
                    dgvListaArticulos.BeginEdit(true);
                }
                else
                {
                    OptionPane.MessageInformation("No hay registros para editar.");
                }
            }
            else
            {
                if (e.KeyData == Keys.F6)
                {
                    //Venta = true;
                    RealizarVenta();
                }
                else
                {
                        if (e.KeyData == Keys.F4)
                        {
                            if (!ExtendForms)
                            {
                                //derechos de administrador.
                                var formProducto = new Inventario.Producto.FrmIngresarProducto();
                                formProducto.MdiParent = this.MdiParent;
                                formProducto.Extencion = true;
                                formProducto.Fact = true;
                                formProducto.Edit = true;
                                formProducto.tabControlProducto.SelectedIndex = 1;
                                ExtendForms = true;
                                formProducto.Show();
                            }
                        }
                        else
                        {
                            if (e.KeyData == Keys.Escape)
                            {
                                this.Close();
                            }
                            else
                            {
                                if (e.KeyData == Keys.F7)
                                {
                                    RetiroDeProducto();
                                }
                                else
                                {
                                    if (e.KeyData == Keys.F3)
                                    {
                                       // tsBtnInventario_Click(this.tsBtnInventario, new EventArgs());
                                    }
                                }
                            }
                        }
                    //}
                }
            }*/
        }

        private void FrmFacturaVenta_FormClosing(object sender, FormClosingEventArgs e)
        {
            CompletaEventos.CapEvenAbonoFact(false);
        }
        private bool contado = true;
        private void tsCbContado_SelectedIndexChanged(object sender, EventArgs e)
        {
            IdEstado = Convert.ToInt32(((DataRowView)cbContado.SelectedItem)["idestado"]);
            switch (IdEstado)
            {
                case 1:
                    {
                        lblInfoEstado.Text = "Factura de Contado.";
                        contado = true;
                        lblFecha.Text = "Fecha";
                        lblDataFecha.Visible = true;
                        dtpFechaLimite.Value = DateTime.Today;
                        dtpFechaLimite.Visible = false;
                        break;
                    }
                case 2:
                    {
                        lblInfoEstado.Text = "Factura a Crédito.";
                        contado = true;
                        lblFecha.Text = "Fecha Limte";
                        lblDataFecha.Visible = false;
                        dtpFechaLimite.Visible = true;
                        break;
                    }
                case 3:
                    {
                        if (Factura.EstadoFactura.Id.Equals(3))
                        {
                            lblInfoEstado.Text = "FR Pendiente No " + Factura.Numero;
                        }
                        else
                        {
                            lblInfoEstado.Text = "Factura Pendiente";
                        }
                        contado = true;
                        lblFecha.Text = "Fecha";
                        lblDataFecha.Visible = true;
                        dtpFechaLimite.Value = DateTime.Today;
                        dtpFechaLimite.Visible = false;
                        break;
                    }
                case 4:
                    {
                        if (Factura.EstadoFactura.Id.Equals(4))
                        {
                            lblInfoEstado.Text = "Cotización No " + Factura.Numero;
                        }
                        else
                        {
                            lblInfoEstado.Text = "Cotización";
                        }
                        contado = true;
                        lblFecha.Text = "Fecha";
                        lblDataFecha.Visible = true;
                        dtpFechaLimite.Value = DateTime.Today;
                        dtpFechaLimite.Visible = false;
                        break;
                    }
            }

            //if (dgvListaArticulos.RowCount == 0)
            //{
            /*IdEstado = Convert.ToInt32(((DataRowView)cbContado.SelectedItem)["idestado"]);
            if (IdEstado != 2)
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
                    lblInfoEstado.Text = "Factura Pendiente.";
                }
            }
            else   //Credito
            {
                lblInfoEstado.Text = "Factura a Crédito.";
                contado = true;
                lblFecha.Text = "Fecha Limte";
                lblDataFecha.Visible = false;
                dtpFechaLimite.Visible = true;
            }
            if (!Edicion)
            {
                //ObtenerNumero();
            }*/
            /*}
            else
            {
                if (MsnEstado)
                {
                    OptionPane.MessageInformation
                            ("Este cambio no se puede realizar debido a que hay registros en la factura.");
                    MsnEstado = false;
                }
                tsCbContado.ComboBox.SelectedValue = IdEstado;
            }
            MsnEstado = true;*/
        }

        private void tsCbDesctoRecargo_SelectedIndexChanged(object sender, EventArgs e)
        {
            /*if (dgvListaArticulos.RowCount == 0)
            {
                IdDesctoRecgo = ((Inventario.Producto.Criterio)cbDesctoRecargo.SelectedItem).Id;
                if (IdDesctoRecgo == 1)
                {
                    lblDescuentoFactura.Text = "Descto/Fact";
                    lblDesctoProducto.Text = "Descto%";
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
                    cbDescuentoProducto.Visible = true;
                    cbRecargoProducto.Visible = false;
                    rbtnDesctoFactura.Enabled = true;
                    rbtnDesctoProducto.Enabled = true;
                    txtDescuentoFactura.Enabled = true;
                }
                else
                {
                    if (IdDesctoRecgo == 2)
                    {
                        lblDescuentoFactura.Text = "Recargo/Fact";
                        lblDesctoProducto.Text = "Recargo%";
                        miToolTip.SetToolTip(rbtnDesctoProducto, "Aplicar recargo por Producto.");
                        miToolTip.SetToolTip(pbProducto, "Aplicar recargo por Producto.");
                        miToolTip.SetToolTip(rbtnDesctoFactura, "Aplicar recargo por Factura.");
                        miToolTip.SetToolTip(pbFactura, "Aplicar recargo por Factura.");
                        dgvListaArticulos.Columns["ValorMenosDescto"].Width = ValorMenosDescto.Width + 1;
                        dgvListaArticulos.Columns["Descuento"].HeaderText = "Recgo";
                        dgvListaArticulos.Columns["ValorMenosDescto"].HeaderText = "Valor + Recgo";
                        cbDescuentoProducto.Visible = false;
                        cbRecargoProducto.Visible = true;
                        rbtnDesctoFactura.Enabled = true;
                        rbtnDesctoProducto.Enabled = true;
                        txtDescuentoFactura.Enabled = true;
                    }
                    else
                    {
                        rbtnDesctoFactura.Enabled = false;
                        rbtnDesctoProducto.Enabled = false;
                        txtDescuentoFactura.Enabled = false;
                    }
                }
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
            }*/
            MsnDescto = true;
        }

        private void tsBtnModCantidad_Click(object sender, EventArgs e)
        {
            if (this.dgvListaArticulos.RowCount != 0)
            {
                if (this.PermisoEditarCantidad)
                {
                    this.dgvListaArticulos.EditMode = DataGridViewEditMode.EditOnEnter;
                    this.dgvListaArticulos.BeginEdit(true);
                    this.dgvListaArticulos.Columns["Cantidad"].ReadOnly = false;
                    this.dgvListaArticulos.Columns["TotalMasIva"].ReadOnly = true;
                    this.txtCodigoArticulo.Focus();
                    this.dgvListaArticulos.Focus();
                    
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
                                    if (userTemp.Permisos.Where(ps => ps.IdPermiso.Equals(IdPermisoEditarCantidad)).Count() > 0)
                                    {
                                        this.dgvListaArticulos.Columns["Cantidad"].ReadOnly = false;
                                        this.dgvListaArticulos.Columns["TotalMasIva"].ReadOnly = true;
                                        this.txtCodigoArticulo.Focus();
                                        this.dgvListaArticulos.Focus();
                                        this.dgvListaArticulos.EditMode = DataGridViewEditMode.EditOnEnter;
                                        this.dgvListaArticulos.BeginEdit(true);
                                        admin = true;
                                    }
                                    else
                                    {
                                        MessageBox.Show("El usuario no tiene permisos para esta acción.", "Edición de venta",
                                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                                        admin = false;
                                    }
                                }
                                else
                                {
                                    MessageBox.Show
                                        ("Usuario o contraseña incorrecta.", "Edición de venta", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void tsCambiarPrecio_Click(object sender, EventArgs e)
        {
            if (dgvListaArticulos.RowCount != 0)
            {
                if (this.PermisoEditarPrecio)
                {
                    this.dgvListaArticulos.EditMode = DataGridViewEditMode.EditOnEnter;
                    this.dgvListaArticulos.BeginEdit(true);
                    this.dgvListaArticulos.Columns["Cantidad"].ReadOnly = true;
                    this.dgvListaArticulos.Columns["TotalMasIva"].ReadOnly = false;
                    this.txtCodigoArticulo.Focus();
                    this.dgvListaArticulos.Focus();
                    
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
                                    if (userTemp.Permisos.Where(ps => ps.IdPermiso.Equals(IdPermisoEditarPrecio)).Count() > 0)
                                    {
                                        this.dgvListaArticulos.Columns["Cantidad"].ReadOnly = true;
                                        this.dgvListaArticulos.Columns["TotalMasIva"].ReadOnly = false;
                                        this.txtCodigoArticulo.Focus();
                                        this.dgvListaArticulos.Focus();
                                        this.dgvListaArticulos.EditMode = DataGridViewEditMode.EditOnEnter;
                                        this.dgvListaArticulos.BeginEdit(true);
                                        admin = true;
                                    }
                                    else
                                    {
                                        MessageBox.Show("El usuario no tiene permisos para esta acción.", "Edición de venta",
                                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                                        admin = false;
                                    }
                                }
                                else
                                {
                                    MessageBox.Show
                                        ("Usuario o contraseña incorrecta.", "Edición de venta", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void tsRealizarVenta_Click(object sender, EventArgs e)
        {
            RealizarVenta();
        }

        private void tsBtnRetiro_Click(object sender, EventArgs e)
        {
            if (dgvListaArticulos.RowCount != 0)
            {
                DialogResult rta_ = MessageBox.Show("¿Esta seguro(a) de eliminar el producto?", "Factura venta",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (rta_.Equals(DialogResult.Yes))
                {
                    if (this.PermisoElimiarProducto)
                    {
                        RetiroDeProducto();
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
                                        if (userTemp.Permisos.Where(ps => ps.IdPermiso.Equals(IdPermisoElimiarProducto)).Count() > 0)
                                        {
                                            admin = true;
                                            RetiroDeProducto();
                                        }
                                        else
                                        {
                                            MessageBox.Show("El usuario no tiene permisos para esta acción.", "Edición de venta",
                                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                                            admin = false;
                                        }
                                    }
                                    else
                                    {
                                        MessageBox.Show
                                            ("Usuario o contraseña incorrecta.", "Edición de venta", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            }
            else
            {
                OptionPane.MessageInformation("No hay productos para eliminar.");
            }
            // RetiroDeProducto();
        }

        private void tsBtnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private bool MsnDescto = true;
        private void txtCliente_KeyPress(object sender, KeyPressEventArgs e)
        {
            //try
            //{
            if (e.KeyChar == (char)Keys.Enter)
            {
                if (ValidarCodigoCliente())
                {
                    if (ExisteCliente())
                    {
                        try
                        {
                            var cliente = miBussinesCliente.ClienteAEditar(txtCliente.Text);
                            txtNombreCliente.Text = cliente.NitCliente + " - " + cliente.NombresCliente;
                            NitCliente = cliente.NitCliente;
                            txtCodigoArticulo.Focus();
                            cliente = null;
                        }
                        catch (Exception ex)
                        {
                            OptionPane.MessageError(ex.Message);
                        }
                    }
                    else
                    {
                        DialogResult rta = MessageBox.Show("El cliente que ingreso no existe.\n¿Desea Crearlo?",
                            "Factura Venta", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                        if (rta.Equals(DialogResult.Yes))
                        {
                            var frmCliente = new Cliente.frmCliente();
                            frmCliente.txtNit.Text = txtCliente.Text;
                            frmCliente.Show();
                        }
                    }
                }
            }
            //}
            //catch (Exception ex)
            //{
            //    OptionPane.MessageError(ex.Message);
            //}
        }

        private void txtCliente_Validating(object sender, CancelEventArgs e)
        {
            txtCliente_KeyPress(txtCliente, new KeyPressEventArgs((char)Keys.Enter));
        }
        private bool ExtendForms = false;
        private void btnBuscarCliente_Click(object sender, EventArgs e)
        {
            if (!ExtendForms)
            {
                var frmCliente = new Cliente.frmCliente();
                frmCliente.MdiParent = this.MdiParent;
                frmCliente.tcClientes.SelectedIndex = 1;
                frmCliente.FacturaVenta = true;
                ClienteMatch = true;
                ExtendForms = true;
                frmCliente.Show();
                frmCliente.txtNit.Focus();
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
                    miError.SetError(txtCantidad, null);
                    if (MiProducto != null)
                    {
                        CargarColorOconsulta();
                    }
                    else
                    {
                        txtCodigoArticulo.Focus();
                    }
                }
                else
                {
                    miError.SetError(txtCantidad, "La cantidad que ingreso tiene formato incorrecto.");
                    txtCantidad.Focus();
                }
                /*if (String.IsNullOrEmpty(txtCantidad.Text))
                {
                    txtCantidad.Text = "1";
                    txtCodigoArticulo.Focus();
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
        }

        private void txtCodigoArticulo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                if (!String.IsNullOrEmpty(this.txtCodigoArticulo.Text))
                {
                    if (CodigoOrString())
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
                        /*if (ExisteProducto(txtCodigoArticulo.Text))
                        {
                            CargarProducto();
                            CargarDescuentosORecargos();
                            if (cbDescuentoProducto.Enabled)
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
                                        if (!SingleSize || !SingleColor)
                                        {
                                            btnTallaYcolor_Click(this.btnTallaYcolor, new EventArgs());
                                        }
                                        else
                                        {
                                            EstructurarConsulta();
                                            return;
                                        }
                                        //btnTallaYcolor.Focus();
                                    }
                                }
                            }
                            if(!cbDescuentoProducto.Enabled && !cbRecargoProducto.Enabled && !btnTallaYcolor.Enabled)
                            {
                                EstructurarConsulta();
                            }
                        }*/
                    }
                    else
                    {
                        if (!ExtendForms)
                        {
                            //derechos de administrador.
                            var formInventario = new Inventario.Consulta.FrmConsultaInventario();
                            formInventario.MdiParent = this.MdiParent;
                            formInventario.ExtendVenta = true;
                            formInventario.txtCodigoNombre.Text = txtCodigoArticulo.Text;
                            ExtendForms = true;
                            this.Transfer = true;
                            formInventario.Show();
                            formInventario.dgvInventario.Focus();
                            formInventario.ColorearGrid();
                        }
                    }
                }
            }
        }

        private void txtCodigoArticulo_Validating(object sender, CancelEventArgs e)
        {

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
                    FrmTallaColor.AplicaTalla = MiProducto.AplicaTalla;
                    FrmTallaColor.AplicaColor = MiProducto.AplicaColor;
                    FrmTallaColor.CodigoProducto = MiProducto.CodigoInternoProducto;
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
                OptionPane.MessageInformation("Debe selecciona un Articulo primero.");
            }
        }

        private void dgvListaArticulos_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            //if (!Convert.ToBoolean(this.dgvListaArticulos.Rows[rowIndex].Cells["Retorno"].Value))

            if ((e.ColumnIndex.Equals(12) && !TotalMasIva.ReadOnly) || (e.ColumnIndex.Equals(7) && !Cantidad.ReadOnly)) // valor venta.
            {
               // OptionPane.MessageInformation("Entra !");
            }

            /*if (Convert.ToBoolean(this.dgvListaArticulos.CurrentRow.Cells["Retorno"].Value))
            {
                this.dgvListaArticulos.Columns["Cantidad"].ReadOnly = true;
                this.dgvListaArticulos.Columns["TotalMasIva"].ReadOnly = true;
            }*/

            if (!Convert.ToBoolean(this.dgvListaArticulos.CurrentRow.Cells["Retorno"].Value))
            {
                if (e.ColumnIndex.Equals(12) && !TotalMasIva.ReadOnly) // valor venta.
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
                            ActualizarInformacion(e.RowIndex, num.ToString());
                            this.dgvListaArticulos.Columns["Cantidad"].ReadOnly = true;
                            this.dgvListaArticulos.Columns["TotalMasIva"].ReadOnly = true;
                            this.dgvListaArticulos.EditMode = DataGridViewEditMode.EditProgrammatically;
                            this.dgvListaArticulos.BeginEdit(false);
                            return;
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
                                ActualizarInformacionCantidadNew(e.RowIndex, num.ToString());
                                this.dgvListaArticulos.Columns["Cantidad"].ReadOnly = true;
                                this.dgvListaArticulos.Columns["TotalMasIva"].ReadOnly = true;
                                this.dgvListaArticulos.EditMode = DataGridViewEditMode.EditProgrammatically;
                                this.dgvListaArticulos.BeginEdit(false);
                                return;
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
            else
            {
                this.RecargarGridview();
                this.ColorearGrid();
                //this.dgvListaArticulos.Columns["Cantidad"].ReadOnly = true;
                //this.dgvListaArticulos.Columns["TotalMasIva"].ReadOnly = true;
            }



            //ActualizarInformacion(e.ColumnIndex, e.RowIndex, e.FormattedValue.ToString());
            /*if (e.ColumnIndex == 8)
            {
                var canti = Cantidad.Index;
                var vi = Valor.Index;
                if (!String.IsNullOrEmpty(e.FormattedValue.ToString()))
                {
                    if (!MiValidacion.ValidarNumeroInt(e.FormattedValue.ToString()))
                    {
                        OptionPane.MessageError("El número que ingreso es incorrecto.");
                        e.Cancel = true;
                    }
                    else
                    {
                        ActualizarInformacion(e.ColumnIndex, e.RowIndex, e.FormattedValue.ToString());
                        return;
                    }
                }
                else
                {
                    OptionPane.MessageError("Debe ingresar un valor.");
                    e.Cancel = true;
                }
            }*/
        }

        //metodos...

        /// <summary>
        /// Carga los valores de las utilizados en el Formulario de Factura de Venta.
        /// </summary>
        private void CargarUtilidades()
        {
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
                ///this.cbContado.DataSource = this.miBussinesEstado.ListaExcluyente(3, 4);
                DataTable tEstadoFactura = new DataTable();
                switch (this.Factura.EstadoFactura.Id)
                {
                    case 1:
                        {
                            tEstadoFactura = this.miBussinesEstado.ListaExcluyente(2, 3, 4);
                            break;
                        }
                    case 2:
                        {
                            tEstadoFactura = this.miBussinesEstado.ListaExcluyente(1, 3, 4);
                            break;
                        }
                    case 3:
                        {
                            tEstadoFactura = this.miBussinesEstado.ListaExcluyente(4);
                            break;
                        }
                    case 4:
                        {
                            tEstadoFactura = this.miBussinesEstado.ListaExcluyente(3);
                            break;
                        }
                }
                this.cbContado.DataSource = tEstadoFactura;
                //var sele = this.cbContado.SelectedValue;

                //var tabla = miBussinesEstado.Lista();
                //cbContado.DataSource = tabla;

                /*DataTable tCopy = new DataTable();
                if (Remision)
                {
                    IEnumerable<DataRow> query = from data in tabla.AsEnumerable()
                                                 where data.Field<int>("idestado") == 1 ||
                                                       data.Field<int>("idestado") == 2 ||
                                                       data.Field<int>("idestado") == 3
                                                 select data;
                    tCopy = query.CopyToDataTable<DataRow>();
                }
                else
                {
                    if (this.Factura.EstadoFactura.Id.Equals(1) || this.Factura.EstadoFactura.Id.Equals(2))
                    {
                        IEnumerable<DataRow> query = from data in tabla.AsEnumerable()
                                                     where data.Field<int>("idestado") == 1 ||
                                                           data.Field<int>("idestado") == 2
                                                     select data;
                        tCopy = query.CopyToDataTable<DataRow>();
                    }
                    else
                    {
                        IEnumerable<DataRow> query = from data in tabla.AsEnumerable()
                                                     where data.Field<int>("idestado") == 1 ||
                                                           data.Field<int>("idestado") == 2 ||
                                                           data.Field<int>("idestado") == 3
                                                     select data;
                        tCopy = query.CopyToDataTable<DataRow>();
                    }
                }

                tabla.Rows.Clear();
                tabla.Columns.Clear();
                tabla = null;
                cbContado.DataSource = tCopy;*/

                RequiereCantidad = Convert.ToBoolean(AppConfiguracion.ValorSeccion("reqCantidad"));
                
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }

            miToolTip.SetToolTip(btnTallaYcolor, "Seleccionar Talla y Color");
            miToolTip.SetToolTip(rbtnDesctoProducto, "Aplicar descuento por Producto.");
            miToolTip.SetToolTip(pbProducto, "Aplicar descuento por Producto.");
            miToolTip.SetToolTip(rbtnDesctoFactura, "Aplicar descuento por Factura.");
            miToolTip.SetToolTip(pbFactura, "Aplicar descuento por Factura.");
        }

        private void CargarCliente(string nit)
        {
            try
            {
                cliente = miBussinesCliente.ClienteAEditar(txtCliente.Text);
                txtNombreCliente.Text = cliente.NitCliente + " - " + cliente.NombresCliente;
                NitCliente = cliente.NitCliente;
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
        }

        private bool ValidarCantidad(string cant)
        {
            try
            {
                Convert.ToDouble(cant);
                return true;
            }
            catch (FormatException)
            {
                return false;
            }
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

        private void ConsultaInventario()
        {
            var formInventario = new Inventario.Consulta.FrmConsultaInventario();
            formInventario.MdiParent = this.MdiParent;
            formInventario.ExtendVenta = true;
            // formInventario.txtCodigoNombre.Text = txtCodigoArticulo.Text;
            ExtendForms = true;
            formInventario.Show();
            formInventario.dgvInventario.Focus();
            formInventario.ColorearGrid();
            /*if (!ExtendForms)
            {
                var frmInventario = new Inventario.Consulta.FrmConsultaInventario();
                frmInventario.ExtendVenta = true;
                frmInventario.MdiParent = this.MdiParent;
                ExtendForms = true;
                frmInventario.Show();
                frmInventario.txtCodigoNombre.Focus();
            }*/
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
                var numeroBD = miBussinesFactura.ObtenerNumero(contado, miEmpresa.Regimen.IdRegimen);
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
                numeroBD = null;
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
            miTabla.Columns.Add(new DataColumn("Cantidad", typeof(double)));
            miTabla.Columns.Add(new DataColumn("ValorUnitario", typeof(int)));
            miTabla.Columns.Add(new DataColumn("Descuento", typeof(string)));
            miTabla.Columns.Add(new DataColumn("ValorMenosDescto", typeof(double)));
            miTabla.Columns.Add(new DataColumn("Iva", typeof(string)));
            miTabla.Columns.Add(new DataColumn("TotalMasIva", typeof(double)));
            miTabla.Columns.Add(new DataColumn("Valor", typeof(double)));
            miTabla.Columns.Add(new DataColumn("Unidad", typeof(string)));
            miTabla.Columns.Add(new DataColumn("IdMedida", typeof(int)));
            miTabla.Columns.Add(new DataColumn("Medida", typeof(string)));
            miTabla.Columns.Add(new DataColumn("IdMarca", typeof(int)));
            miTabla.Columns.Add(new DataColumn("IdColor", typeof(int)));
            miTabla.Columns.Add(new DataColumn("Color", typeof(Image)));
            miTabla.Columns.Add(new DataColumn("Save", typeof(bool)));

            miTabla.Columns.Add(new DataColumn("ValorReal", typeof(double)));
            miTabla.Columns.Add(new DataColumn("Retorno", typeof(bool)));
            miTabla.Columns.Add(new DataColumn("Ico", typeof(double)));

            miTabla.Columns.Add(new DataColumn("ValorIva", typeof(double)));

            miTabla.Columns.Add(new DataColumn("IdIva", typeof(int)));
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
            try
            {
                Convert.ToInt64(txtCodigoArticulo.Text);
                return true;
            }
            catch
            {
                return false;
            }
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
                lblDatosProducto.Text = MiProducto.NombreProducto + "  --  " + MiProducto.NombreMarca;
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
                }
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
            return resultado;

            /*
            try
            {
                ArrayProducto = miBussinesProducto.ProductoBasico(txtCodigoArticulo.Text);
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
                lblDatosProducto.Text = MiProducto.NombreProducto + "  --  " + MiProducto.NombreMarca;
                if (!MiProducto.AplicaTalla && !MiProducto.AplicaColor)
                {
                    btnTallaYcolor.Enabled = false;
                }
                else
                {
                    btnTallaYcolor.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }*/
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
                            miBussinesDescuento.ListadoDescuento(MiProducto.CodigoInternoProducto);
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
                            miBussinesRecargo.ListadoDeRecargo(MiProducto.CodigoInternoProducto);
                    }
                    catch (Exception ex)
                    {
                        OptionPane.MessageError(ex.Message);
                    }
                }
            }
        }
        private bool Venta = false;
        /// <summary>
        /// Completa la secuencia de datos de un formulario de estención.
        /// </summary>
        /// <param name="args">Objeto que encapsula la información del formulario.</param>
        void CompletaEventos_Completo(CompletaArgumentosDeEvento args)
        {
            try
            {
                miTallaYcolor = (TallaYcolor)args.MiObjeto;
                //if (LoadColorSize)
                //{
                //btnAgregar_Click(this.btnAgregar, null);
                EstructurarConsulta();
                //}
            }
            catch { }

            try
            {
                //var j = Edicion;
                if (Venta)
                {
                    var obj = (ObjectAbstract)args.MiObjeto;
                    if (obj.Id.Equals(10000096))
                    {
                        miFormasPago = (List<DTO.Clases.FormaPago>)obj.Objeto;
                        if (Convert.ToBoolean(AppConfiguracion.ValorSeccion("printEditFrv")))
                        {
                            CargarYguardarFacturaPos();
                        }
                        else
                        {
                            CargarYguardarFacturaDespues();
                        }
                        Venta = false;
                    }
                    /* miFormasPago = (List<DTO.Clases.FormaPago>)args.MiObjeto;
                     //    CargarYguardarFactura();
                     //Convert.ToBoolean(args.MiObjeto);
                     //RealizarVenta();
                     if (Convert.ToBoolean(AppConfiguracion.ValorSeccion("printEditFrv")))
                     {
                         CargarYguardarFacturaPos();
                     }
                     else
                     {
                         CargarYguardarFacturaDespues();
                     }
                     Venta = false;*/
                }
            }
            catch { }

            try
            {
                ExtendForms = (bool)args.MiObjeto;
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
            catch { }

            try
            {
                txtCliente.Text = (string)args.MiObjeto;
                txtCliente_KeyPress(this.txtCliente, new KeyPressEventArgs((char)Keys.Enter));
            }
            catch { }
        }

        void CompletaEventosEditFactura_Completo(CompletaArgumentosDeEventoEditProveedor args)
        {
            try
            {
                var producto = (Producto)args.MiObjeto;
                txtCodigoArticulo.Text = producto.CodigoInternoProducto;
                txtCodigoArticulo_KeyPress(this.txtCodigoArticulo, new KeyPressEventArgs((char)Keys.Enter));
            }
            catch { }

            try
            {
                ExtendForms = Convert.ToBoolean(args.MiObjeto);
            }
            catch { }
        }

        void CompletaEventos_Completaz(CompletaArgumentosDeEventoz args)
        {
            try
            {
                Retenciones = Retenciones = (List<RetencionConcepto>)args.MiZona;
            }
            catch { }
        }

        void CompletaEventos_CompTProductoFact(CompletaTransferProductFact args)
        {
            try
            {
                // Edicion 14-01-2017
                if (this.Transfer)
                {
                    var producto = (Producto)args.MiObjeto;
                    txtCodigoArticulo.Text = producto.CodigoInternoProducto;
                    DesctoAplica = producto.Descuento;
                    txtCodigoArticulo_KeyPress(this.txtCodigoArticulo, new KeyPressEventArgs((char)Keys.Enter));
                    this.Transfer = false;
                }

                /* var producto = (Producto)args.MiObjeto;
                 txtCodigoArticulo.Text = producto.CodigoInternoProducto;
                 txtCodigoArticulo_KeyPress(this.txtCodigoArticulo, new KeyPressEventArgs((char)Keys.Enter));*/
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
            row["Retorno"] = false;
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
            if (!IdEstado.Equals(4))
            {
                try
                {
                    if (!FacturaNegativo)
                    {
                        inventario.Cantidad = miBussinesInventario.CantidadInventario(inventario);
                        if (inventario.Cantidad.Equals(0))
                        {
                            OptionPane.MessageError
                                ("El artículo no se puede Facturar ya que su inventario se encuentra en cero.");
                            return;
                        }
                        else
                        {
                            var cantFactura = miTabla.AsEnumerable().
                                Where(p => p.Field<string>("Codigo").Equals(inventario.CodigoProducto)
                                        && p.Field<int>("IdMedida").Equals(inventario.IdMedida)
                                        && p.Field<int>("IdColor").Equals(inventario.IdColor)
                                        && p.Field<bool>("Save")).Sum
                                        (s => Convert.ToDouble(s.Field<string>("Cantidad")));
                            cantFactura += Convert.ToDouble(txtCantidad.Text);
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
            var valorUnitario = 0.0;
            if (!Convert.ToBoolean(AppConfiguracion.ValorSeccion("promedio"))) //Precio asignado
            {
                valorUnitario = MiProducto.ValorVentaProducto;
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
            // Antes...
            /* if (MiProducto.AplicaPrecioPorcentaje)
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
            row["Cantidad"] = txtCantidad.Text.Replace('.', ',');

            row["IdIva"] = this.MiProducto.IdIva;

            //row["ValorUnitario"] = MiProducto.ValorVentaProducto;

            // 14-04-2016
            if (miEmpresa.Regimen.IdRegimen == 1)  //Comun
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

            /* if (Convert.ToBoolean(AppConfiguracion.ValorSeccion("precio_venta_iva"))) // Precios incluye IVA
             {
                 //var valor = Math.Round((valorUnitario / (1 + (MiProducto.ValorIva / 100))), 1);
                 row["ValorUnitario"] = Math.Round((valorUnitario / (1 + (MiProducto.ValorIva / 100))), 1); //Convert.ToInt32(valorUnitario / (1 + (MiProducto.ValorIva / 100)));
                 //var j = Convert.ToInt32(valorUnitario / (1 + (MiProducto.ValorIva / 100)));
                 //    var j = row["ValorUnitario"].ToString();
             }
             else
             {
                 row["ValorUnitario"] = valorUnitario;
             }*/

            var j_ = row["ValorUnitario"].ToString();

            row["ValorReal"] = row["ValorUnitario"];

            j_ = row["ValorReal"].ToString();

            /*  if (IdDesctoRecgo == 1)
              {
                  if (rbtnDesctoProducto.Checked)
                  {
                      row["Descuento"] =
                          ((DTO.Clases.Descuento)cbDescuentoProducto.SelectedItem).ValorDescuento.ToString() + "%";
                  }
                  else
                  {
                      row["Descuento"] = txtDescuentoFactura.Text + "%";
                  }
                  row["ValorMenosDescto"] = Convert.ToDouble(Convert.ToInt32(row["ValorUnitario"]) -
                      (Convert.ToInt32(row["ValorUnitario"]) * UseObject.RemoveCharacter(row["Descuento"].ToString(), '%') / 100));
              }
              else
              {
                  if (rbtnDesctoProducto.Checked)
                  {
                      row["Descuento"] =
                          ((DTO.Clases.Recargo)cbRecargoProducto.SelectedItem).ValorRecargo.ToString() + "%";
                  }
                  else
                  {
                      row["Descuento"] = txtDescuentoFactura.Text + "%";
                  }
                  row["ValorMenosDescto"] = Convert.ToDouble(Convert.ToInt32(row["ValorUnitario"]) +
                       (Convert.ToInt32(row["ValorUnitario"]) * UseObject.RemoveCharacter(row["Descuento"].ToString(), '%') / 100));
              }*/

            if (DesctoAplica > 0)
            {
                row["Descuento"] = DesctoAplica.ToString() + "%";
                row["ValorMenosDescto"] = Math.Round((Convert.ToDouble(row["ValorUnitario"]) -
                    (Convert.ToDouble(row["ValorUnitario"]) * UseObject.RemoveCharacter(row["Descuento"].ToString(), '%') / 100)), 1);
                /* row["ValorMenosDescto"] = Convert.ToInt32(Convert.ToInt32(row["ValorUnitario"]) -
                         (Convert.ToInt32(row["ValorUnitario"]) * UseObject.RemoveCharacter(row["Descuento"].ToString(), '%') / 100));*/

                j_ = row["ValorMenosDescto"].ToString();
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

                j_ = row["ValorMenosDescto"].ToString();
            }

            if (miEmpresa.Regimen.IdRegimen == 1)  //Comun
            {
                row["Iva"] = MiProducto.ValorIva.ToString() + "%";
            }
            else
            {
                row["Iva"] = 0 + "%";
            }

            // ****** Edicion *******
            double vIva = Math.Round(
                    (Convert.ToDouble(row["ValorMenosDescto"]) *
                      UseObject.RemoveCharacter(row["Iva"].ToString(), '%') / 100), 1);
            //int AvIva = UseObject.AproximacionDian(vIva);

            row["ValorIva"] = vIva;

            row["Ico"] = MiProducto.Impoconsumo;

            var vUnitario = Convert.ToInt32(Convert.ToDouble(row["ValorMenosDescto"]) + vIva) + Convert.ToInt32(MiProducto.Impoconsumo);
            // **** End Edicion ******
            if (this.RedondearPrecio2)
            {
                row["TotalMasIva"] =
                    UseObject.Aproximar(vUnitario, Convert.ToBoolean(AppConfiguracion.ValorSeccion("tipo_aprox_precio")));
            }
            else
            {
                row["TotalMasIva"] = vUnitario;
            }
            /*row["TotalMasIva"] = (Convert.ToDouble(row["ValorMenosDescto"]) *
                                  UseObject.RemoveCharacter(row["Iva"].ToString(), '%') / 100) +
                                  Convert.ToDouble(row["ValorMenosDescto"]);*/
            row["Valor"] = Convert.ToInt32(
                           Convert.ToDouble(row["TotalMasIva"]) *
                           Convert.ToDouble(row["Cantidad"]));//txtCantidad.Text);

            miTabla.Rows.Add(row);
            txtTotal.Text = UseObject.InsertSeparatorMil
                (
                   Convert.ToInt32(
                   miTabla.AsEnumerable().Sum(s => s.Field<double>("Valor"))
                   ).ToString()
                );
            RecargarRetencion();
            RecargarGridview();
            ColorearGrid();
            LimpiarCampos();
            LoadColorSize = false;
            btnTallaYcolor.Enabled = false;
            DesctoAplica = 0.0;
        }

        /// <summary>
        /// Recarga el DataGridView Productos segun los datos en el DataTable miTable.
        /// </summary>
        private void RecargarGridview()
        {
            try
            {
                if (miTabla.Rows.Count != 0)
                {
                    IEnumerable<DataRow> query = from datos in miTabla.AsEnumerable()
                                                 orderby datos.Field<int>("Id") descending
                                                 select datos;

                    DataTable copy = query.CopyToDataTable<DataRow>();
                    miBindingSource.DataSource = copy;
                }
            }
            catch (Exception ex) { }
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
            lblDatosProducto.Text = "";
            MiProducto = null;
            miTallaYcolor.IdColor = 0;
            miTallaYcolor.IdTalla = 0;
            miTallaYcolor.Talla = "";
            miTallaYcolor.Color = null;
        }

        /// <summary>
        /// Actualiza la información de la factura cuando se realiza un cambio en ella.
        /// </summary>
        /// <param name="rowIndex">Índex del registro de la lista a modificar.</param>
        /// <param name="valor">Valor a modificar en el registro seleccionado.</param>
        private void ActualizarInformacion(int dataIndex, int rowIndex, string valor)
        {
            bool acept = false;
            if (!String.IsNullOrEmpty(valor))
            {
                if (dataIndex.Equals(7))//cantidad
                {
                    if (!MiValidacion.ValidarNumeroDecima(valor))
                    {
                        OptionPane.MessageError("El número que ingreso es incorrecto.");
                        acept = false;
                    }
                    else
                    {
                        acept = true;
                    }
                }
                else //valor
                {
                    if (dataIndex.Equals(8))
                    {
                        if (!MiValidacion.ValidarNumeroInt(valor))
                        {
                            OptionPane.MessageError("El número que ingreso es incorrecto.");
                            acept = false;
                        }
                        else
                        {
                            acept = true;
                        }
                    }
                }
            }
            else
            {
                OptionPane.MessageError("Debe ingresar un valor.");
                acept = false;
            }
            if (acept)
            {
                var id = Convert.ToInt32(dgvListaArticulos.Rows[rowIndex].Cells["Id"].Value);
                var query = (from datos in miTabla.AsEnumerable()
                             where datos.Field<int>("Id") == id
                             select datos).Single();
                var index = miTabla.Rows.IndexOf(query);

                if (dataIndex.Equals(7))//cantidad
                {
                    miTabla.Rows[index]["Cantidad"] = valor.Replace('.', ','); ;
                }
                else
                {
                    miTabla.Rows[index]["ValorUnitario"] = Math.Round((Convert.ToInt32(valor) /
                        ((UseObject.RemoveCharacter(miTabla.Rows[index]["Iva"].ToString(), '%') / 100) + 1)), 1);
                }
                /*Convert.ToInt32(Convert.ToInt32(valor) /
                ((UseObject.RemoveCharacter(miTabla.Rows[index]["Iva"].ToString(), '%') / 100) + 1));*/

                miTabla.Rows[index]["ValorMenosDescto"] =
                    Convert.ToDouble(Convert.ToInt32(miTabla.Rows[index]["ValorUnitario"]) +
                    (Convert.ToInt32(miTabla.Rows[index]["ValorUnitario"]) *
                    UseObject.RemoveCharacter(miTabla.Rows[index]["Descuento"].ToString(), '%') / 100));

                double vIva = Math.Round((
                              Convert.ToDouble(miTabla.Rows[index]["ValorMenosDescto"]) *
                              UseObject.RemoveCharacter(miTabla.Rows[index]["Iva"].ToString(), '%') / 100), 1);
                int aVIva = UseObject.AproximacionDian(vIva);

                var totalMasIva = Convert.ToInt32(miTabla.Rows[index]["ValorMenosDescto"]) + aVIva;

                miTabla.Rows[index]["TotalMasIva"] = UseObject.Aproximar(totalMasIva, Convert.ToBoolean(AppConfiguracion.ValorSeccion("tipo_aprox_precio")));
                /*miTabla.Rows[index]["TotalMasIva"] =
                    (Convert.ToDouble(miTabla.Rows[index]["ValorMenosDescto"]) *
                    UseObject.RemoveCharacter(miTabla.Rows[index]["Iva"].ToString(), '%') / 100) +
                    Convert.ToDouble(miTabla.Rows[index]["ValorMenosDescto"]);*/

                miTabla.Rows[index]["Valor"] =
                    Convert.ToDouble(miTabla.Rows[index]["TotalMasIva"]) *
                    Convert.ToDouble(miTabla.Rows[index]["Cantidad"]);

                RecargarGridview();
                txtTotal.Text = UseObject.InsertSeparatorMil
                    (
                       Convert.ToInt32(
                       miTabla.AsEnumerable().Sum(s => s.Field<double>("Valor"))
                       ).ToString()
                    );
                RecargarRetencion();
                ColorearGrid();
                dgvListaArticulos.Focus();
                txtCodigoArticulo.Focus();
                Cantidad.ReadOnly = true;
                Valor.ReadOnly = true;
            }
        }

        private void ActualizarInformacion(int rowIndex, string valor)
        {
            var id = Convert.ToInt32(dgvListaArticulos.Rows[rowIndex].Cells["Id"].Value);
            var query = (from datos in miTabla.AsEnumerable()
                         where datos.Field<int>("Id") == id
                         select datos).Single();
            var index = miTabla.Rows.IndexOf(query);

            //  realizar resta del impoconsumo... al valor
            //int ico = Convert.ToInt32(miTabla.Rows[index]["Ico"]);
            valor = (Convert.ToInt32(valor) - Convert.ToInt32(miTabla.Rows[index]["Ico"])).ToString();

            miTabla.Rows[index]["ValorUnitario"] = Math.Round((Convert.ToInt32(valor) /
                ((UseObject.RemoveCharacter(miTabla.Rows[index]["Iva"].ToString(), '%') / 100) + 1)), 1);
            var vunit = miTabla.Rows[index]["ValorUnitario"].ToString();

            miTabla.Rows[index]["Descuento"] = "0%";

            miTabla.Rows[index]["ValorMenosDescto"] =
                Convert.ToDouble(Convert.ToDouble(miTabla.Rows[index]["ValorUnitario"]) +
                (Convert.ToInt32(miTabla.Rows[index]["ValorUnitario"]) *
                UseObject.RemoveCharacter(miTabla.Rows[index]["Descuento"].ToString(), '%') / 100));

            double vIva = Math.Round((
                          Convert.ToDouble(miTabla.Rows[index]["ValorMenosDescto"]) *
                          UseObject.RemoveCharacter(miTabla.Rows[index]["Iva"].ToString(), '%') / 100), 1);

            var totalMasIva = Convert.ToInt32(Convert.ToDouble(miTabla.Rows[index]["ValorMenosDescto"]) + vIva) + Convert.ToInt32(miTabla.Rows[index]["Ico"]);

            miTabla.Rows[index]["TotalMasIva"] = totalMasIva;

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
            ColorearGrid();
            dgvListaArticulos.Focus();
            txtCodigoArticulo.Focus();
        }

        private void ActualizarInformacionCantidad(int rowIndex, string valor)
        {
            var id = Convert.ToInt32(dgvListaArticulos.Rows[rowIndex].Cells["Id"].Value);
            var query = (from datos in miTabla.AsEnumerable()
                         where datos.Field<int>("Id") == id
                         select datos).Single();
            var index = miTabla.Rows.IndexOf(query);

            miTabla.Rows[index]["Cantidad"] = valor.Replace('.', ',');

            //miTabla.Rows[index]["Descuento"] = "0%";

            miTabla.Rows[index]["ValorMenosDescto"] =
                Convert.ToDouble(Convert.ToDouble(miTabla.Rows[index]["ValorUnitario"]) -
                (Convert.ToInt32(miTabla.Rows[index]["ValorUnitario"]) *
                UseObject.RemoveCharacter(miTabla.Rows[index]["Descuento"].ToString(), '%') / 100));

            double vIva = Math.Round((
                          Convert.ToDouble(miTabla.Rows[index]["ValorMenosDescto"]) *
                          UseObject.RemoveCharacter(miTabla.Rows[index]["Iva"].ToString(), '%') / 100), 1);

            var totalMasIva = Convert.ToInt32(Convert.ToDouble(miTabla.Rows[index]["ValorMenosDescto"]) + vIva);

            miTabla.Rows[index]["TotalMasIva"] = totalMasIva;

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
            ColorearGrid();
            dgvListaArticulos.Focus();
            txtCodigoArticulo.Focus();
        }

        // Edicion 13-01-2017
        private void ActualizarInformacionCantidadNew(int rowIndex, string valor)
        {
            var id = Convert.ToInt32(dgvListaArticulos.Rows[rowIndex].Cells["Id"].Value);
            var query = (from datos in miTabla.AsEnumerable()
                         where datos.Field<int>("Id") == id
                         select datos).Single();
            var index = miTabla.Rows.IndexOf(query);

            /*miTabla.Rows[index]["ValorUnitario"] = Math.Round((Convert.ToInt32(valor) /
                ((UseObject.RemoveCharacter(miTabla.Rows[index]["Iva"].ToString(), '%') / 100) + 1)), 1);
            var vunit = miTabla.Rows[index]["ValorUnitario"].ToString();*/

            //      if (!Convert.ToBoolean(this.dgvListaArticulos.Rows[rowIndex].Cells["Retorno"].Value))
            //     {
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

       /* if (v_des > 0)
        {
            miTabla.Rows[index]["TotalMasIva"] =
                UseObject.Aproximar(totalMasIva, Convert.ToBoolean(AppConfiguracion.ValorSeccion("tipo_aprox_precio")));
        }
        else
        {
            miTabla.Rows[index]["TotalMasIva"] = totalMasIva;
        }*/

            // End edición    

            var tmasiva = miTabla.Rows[index]["TotalMasIva"].ToString();

            miTabla.Rows[index]["Valor"] =
                Convert.ToDouble(miTabla.Rows[index]["TotalMasIva"]) *
                Convert.ToDouble(miTabla.Rows[index]["Cantidad"]);
            var v = miTabla.Rows[index]["Valor"].ToString();

            RecargarGridview();
            //ColorearGrid();
            txtTotal.Text = UseObject.InsertSeparatorMil
                (
                   Convert.ToInt32(
                   miTabla.AsEnumerable().Sum(s => s.Field<double>("Valor"))
                   ).ToString()
                );
            RecargarRetencion();
            ColorearGrid();
            dgvListaArticulos.Focus();
            txtCodigoArticulo.Focus();
            /* }
             else
             {
                 RecargarRetencion();
                 RecargarGridview();
                // ColorearGrid();
                 dgvListaArticulos.Focus();
                 txtCodigoArticulo.Focus();
             }*/
        }



        private void RealizarVenta()
        {
            if (dgvListaArticulos.RowCount != 0)
            {
                if (IdEstado == 1)
                {
                    if (!ExtendForms)
                    {
                        if (Factura.EstadoFactura.Id.Equals(1))
                        {
                            DialogResult rta = MessageBox.Show("¿Esta seguro(a) de guardar los cambios?", "Factura Venta",
                                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                            if (rta.Equals(DialogResult.Yes))
                            {
                                if (Convert.ToBoolean(AppConfiguracion.ValorSeccion("printEditFrv")))
                                {
                                    CargarYguardarFacturaPos();
                                }
                                else
                                {
                                    CargarYguardarFacturaDespues();
                                }
                            }
                        }
                        else
                        {
                            Venta = true;
                            var frmCancelarVenta = new Factura.Edicion.FrmCancelarVenta();

                            var cant = miTabla.AsEnumerable().Sum(s => Convert.ToDouble(s.Field<string>("Cantidad")));
                            var v_iva = miTabla.AsEnumerable().Sum(s => s.Field<double>("ValorIva"));

                            /*var suma_ = miTabla.AsEnumerable().Sum(s => (s.Field<double>("ValorIva") * Convert.ToDouble(s.Field<string>("Cantidad"))));
                            var suma_2 = Convert.ToInt32(miTabla.AsEnumerable().Sum(s => (s.Field<double>("ValorIva") * Convert.ToDouble(s.Field<string>("Cantidad")))));
                            var suma_3 = UseObject.InsertSeparatorMil(
                                Convert.ToInt32(miTabla.AsEnumerable().Sum(s => (s.Field<double>("ValorIva") * Convert.ToDouble(s.Field<string>("Cantidad"))))).ToString());*/

                            frmCancelarVenta.txtIva.Text = UseObject.InsertSeparatorMil(
                                Convert.ToInt32(miTabla.AsEnumerable().Sum(s => (s.Field<double>("ValorIva") * Convert.ToDouble(s.Field<string>("Cantidad"))))).ToString());

                            frmCancelarVenta.txtBase.Text = UseObject.InsertSeparatorMil((UseObject.RemoveSeparatorMil(txtTotalMenosRete.Text) -
                                UseObject.RemoveSeparatorMil(frmCancelarVenta.txtIva.Text)).ToString());

                            frmCancelarVenta.txtTotal.Text = txtTotalMenosRete.Text;
                            frmCancelarVenta.EsVenta = true;
                            frmCancelarVenta.ShowDialog();
                        }
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
                            if (IdEstado.Equals(3))
                            {
                                msn = "¿Esta seguro(a) de guardar los cambios?";
                            }
                            else
                            {
                                msn = "¿Esta seguro(a) de querer hacer la venta?";
                            }
                        }
                        else
                        {
                            msn = "¿Esta seguro de querer hacer la cotización?";
                        }
                        DialogResult rta = MessageBox.Show(msn, "Factura Venta",
                            MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (rta.Equals(DialogResult.Yes))
                        {
                            if (Convert.ToBoolean(AppConfiguracion.ValorSeccion("printEditFrv")))
                            {
                                CargarYguardarFacturaPos();
                            }
                            else
                            {
                                CargarYguardarFacturaDespues();
                            }
                        }
                    }
                }
            }
            else
            {
                OptionPane.MessageInformation("Debe cargar al menos un producto para realizar la venta.");
            }

            // Codigo anterior...
            /*if (dgvListaArticulos.RowCount != 0)
            {
                if (IdEstado == 1)
                {
                    if (!ExtendForms)
                    {
                        if (NitCliente.Equals("1000"))
                        {
                            Venta = true;
                            var frmCancelarVenta = new FrmCancelarVenta();
                            frmCancelarVenta.txtTotal.Text = txtTotal.Text;
                            frmCancelarVenta.MdiParent = this.MdiParent;
                            frmCancelarVenta.Show();
                        }
                        else
                        {
                            try
                            {
                                var adelantos = miBussinesSaldo.SaldoEnAdelantos(NitCliente);
                                var bonos = miBussinesBono.SaldoEnBonos(NitCliente);
                                Venta = true;
                                var frmCancelaVenta = new FrmCancelarVentaSaldo();
                                frmCancelaVenta.txtTotal.Text = txtTotal.Text;
                                frmCancelaVenta.txtAdelantoC.Text = UseObject.InsertSeparatorMil(adelantos.ToString());
                                frmCancelaVenta.txtBonoC.Text = UseObject.InsertSeparatorMil(bonos.ToString());
                                frmCancelaVenta.MdiParent = this.MdiParent;
                                frmCancelaVenta.Show();
                            }
                            catch (Exception ex)
                            {
                                OptionPane.MessageError(ex.Message);
                            }
                        }
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
                            if (IdEstado.Equals(3))
                            {
                                msn = "¿Esta seguro de guardar los cambios?";
                            }
                            else
                            {
                                msn = "¿Esta seguro de querer hacer la venta?";
                            }
                        }
                        else
                        {
                            msn = "¿Esta seguro de querer hacer la cotización?";
                        }
                        DialogResult rta = MessageBox.Show(msn, "Factura Venta",
                            MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (rta.Equals(DialogResult.Yes))
                        {
                            //CargarYguardarFactura();

                            if (Convert.ToBoolean(AppConfiguracion.ValorSeccion("printEditFrv")))
                            {
                                CargarYguardarFacturaPos();
                            }
                            else
                            {
                                CargarYguardarFacturaDespues();
                            }
                        }
                    }
                }
            }
            else
            {
                OptionPane.MessageInformation("Debe cargar al menos un producto para realizar la venta.");
            }*/
            /*if (dgvListaArticulos.RowCount != 0)
            {
                if (IdEstado == 1)
                {

                    Venta = true;
                    var frmCancelarVenta = new FrmCancelarVenta();
                    frmCancelarVenta.txtTotal.Text = txtTotal.Text;
                    frmCancelarVenta.MdiParent = this.MdiParent;
                    frmCancelarVenta.Show();
                }
                else
                {
                    CargarYguardarFactura();
                }
            }
            else
            {
                OptionPane.MessageInformation("Debe cargar al menos un producto para realizar la venta.");
            }*/
        }

        private int MaxArticulosPrint { get { return 12; } }
        private List<PrintFactura> Facturas { set; get; }
        private bool ClienteMatch = true;

        private void CargarYguardarFactura()
        {
            if (Convert.ToInt32(cbContado.SelectedValue).Equals(3))
            {
                if (NitCliente.Equals("1"))
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

                if (ClienteMatch)
                {
                    int iteracion = dgvListaArticulos.RowCount / MaxArticulosPrint;
                    if (dgvListaArticulos.RowCount % MaxArticulosPrint != 0)
                    {
                        iteracion++;
                    }
                    var save = false;
                    for (int i = 1; i <= iteracion; i++)
                    {
                        miFactura.Proveedor.NitProveedor = NitCliente;
                        miFactura.Numero = miFactura.NumeroEdit;

                        List<ProductoFacturaProveedor> productos = new List<ProductoFacturaProveedor>();
                        List<DataRow> miRows = new List<DataRow>();
                        var cont = 0;
                        foreach (DataRow row in miTabla.Rows)
                        {
                            cont++;
                            var producto = new ProductoFacturaProveedor();
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
                            {
                                break;
                            }
                        }
                        miFactura.Productos = productos;
                        try
                        {
                            miBussinesFactura.EditarFactura(miFactura);
                            save = true;
                        }
                        catch (Exception ex)
                        {
                            OptionPane.MessageError(ex.Message);
                            save = false;
                            break;
                        }
                        /*foreach (DataRow miRow in miRows)
                        {
                            miTabla.Rows.Remove(miRow);
                        }*/
                    }
                    if (save)
                    {
                        OptionPane.MessageSuccess("La venta se guardó con éxito!");
                    }
                    //void CompletaEventos_ComAbonoFact(CompArgAbonoFact args)
                    CompletaEventos.CapEvenAbonoFact(false);
                }
            }
            else
            {
                //var j = Remision;
                dtpFechaLimite_Validating(this.dtpFechaLimite, new CancelEventArgs(false));
                if (IdEstado != 1)
                {
                    if (NitCliente.Equals("1"))
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
                    if (dgvListaArticulos.RowCount % MaxArticulosPrint != 0)
                    {
                        iteracion++;
                    }
                    Facturas = new List<PrintFactura>();
                    for (int i = 1; i <= iteracion; i++)
                    {
                        /*if (!Edicion)
                        {
                            ObtenerNumero();
                        }
                        var contado_ = true;*/
                        if (IdEstado != 3)  //Contado o Crédito
                        {
                            if (Remision)
                            {
                                ObtenerNumero();
                            }
                            else
                            {
                                miFactura.Numero = Factura.Numero;
                                miFactura.NumeroEdit = Factura.Numero;
                            }
                            //contado_ = false;
                        }
                        else   //Pendiente
                        {
                            miFactura.Numero = ObtenerNumeroTemp();
                        }
                        /* Facturas.Add(new PrintFactura
                         {
                             Numero = miFactura.Numero,
                             Descuento = miFactura.AplicaDescuento,
                             Cliente = NitCliente,
                             Contado = contado
                         });*/
                        FechaHoy = DateTime.Now;
                        miFactura.Proveedor.NitProveedor = NitCliente;
                        miFactura.Caja.Id = 1;
                        miFactura.EstadoFactura.Id = IdEstado;
                        miFactura.FormasDePago = miFormasPago;
                        miFactura.FechaIngreso = FechaHoy;
                        miFactura.FechaLimite = dtpFechaLimite.Value;
                        if (AplicaRete)
                        {
                            miFactura.Retencion = MiRetencion;
                        }
                        else
                        {
                            miFactura.Retencion = null;
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
                        List<ProductoFacturaProveedor> productos = new List<ProductoFacturaProveedor>();
                        List<DataRow> miRows = new List<DataRow>();
                        var cont = 0;
                        foreach (DataRow row in miTabla.Rows)
                        {
                            cont++;
                            var producto = new ProductoFacturaProveedor();
                            producto.Save = Convert.ToBoolean(row["Save"]);
                            if (!producto.Save)
                            {
                                producto.Id = (int)row["Id"];
                            }
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
                            {
                                break;
                            }
                        }
                        miFactura.Productos = productos;
                        try
                        {
                            miFactura.Id = miBussinesFactura.IngresarFactura(miFactura, Edicion, false, ConsecutivoCaja); //OJO EDITAR ANTIGUA
                            if (IdEstado == 3)
                            {
                                ActualizaNumeroTemp();
                            }
                        }
                        catch (Exception ex)
                        {
                            OptionPane.MessageError(ex.Message);
                            break;
                        }
                        Facturas.Add(new PrintFactura
                        {
                            Id = miFactura.Id,
                            Numero = miFactura.Numero,
                            Descuento = miFactura.AplicaDescuento,
                            Cliente = NitCliente,
                            Contado = contado
                        });
                        foreach (DataRow miRow in miRows)
                        {
                            miTabla.Rows.Remove(miRow);
                        }
                        if (Edicion)
                            Edicion = false;
                    }
                    if (IdEstado != 3)
                    {
                        OptionPane.MessageSuccess("La venta se realizó con éxito!");
                        DialogResult rta = MessageBox.Show("¿Desea imprimir la Factura de Venta?", "Factura Venta",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (rta.Equals(DialogResult.Yes))
                        {
                            foreach (PrintFactura p in Facturas)
                            {
                                //Print(p.Numero, p.Descuento, p.Cliente, p.Contado, IdEstado);
                                Print(p.Id, p.Numero, p.Descuento, p.Cliente, p.Contado, IdEstado, true);
                            }
                        }

                    }
                    else
                    {
                        OptionPane.MessageSuccess("La venta se guardó con éxito!");
                    }
                    CompletaEventos.CapturaEventoz(true);
                    CompletaEventos.CapEvenAbonoFact(false);
                    //LimpiarCamposNewFactura();
                    this.Close();
                    //ObtenerNumero();
                }
            }



            ///////
            /*
            dtpFechaLimite_Validating(this.dtpFechaLimite, new CancelEventArgs(false));
            if (LimiteMatch)
            {
                if (Edicion)
                {
                    miFactura.Numero = lblNoFactura.Text;
                }
                FechaHoy = DateTime.Now;
                miFactura.Proveedor.NitProveedor = NitCliente;
                miFactura.Caja.Id = 1;
                miFactura.EstadoFactura.Id = IdEstado;
                miFactura.FormasDePago = miFormasPago;
                miFactura.FechaIngreso = FechaHoy;
                miFactura.FechaLimite = dtpFechaLimite.Value;
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
                List<ProductoFacturaProveedor> productos = new List<ProductoFacturaProveedor>();
                foreach (DataRow row in miTabla.Rows)
                {
                    var producto = new ProductoFacturaProveedor();
                    producto.Save = Convert.ToBoolean(row["Save"]);
                    producto.NumeroFactura = miFactura.Numero;
                    producto.Producto.CodigoInternoProducto = row["Codigo"].ToString();
                    producto.Cantidad = Convert.ToInt32(row["Cantidad"]);
                    producto.Producto.ValorVentaProducto = Convert.ToInt32(row["ValorUnitario"]);
                    producto.Inventario.CodigoProducto = row["Codigo"].ToString();
                    producto.Inventario.IdMedida = Convert.ToInt32(row["IdMedida"]);
                    producto.Inventario.IdColor = Convert.ToInt32(row["IdColor"]);
                    producto.Inventario.Cantidad = Convert.ToInt32(row["Cantidad"]);
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
                    miBussinesFactura.IngresarFactura(miFactura, Edicion);
                    if (IdEstado != 3)
                    {
                        OptionPane.MessageSuccess("La venta se realizó con éxito!");
                        DialogResult rta = MessageBox.Show("¿Desea imprimir la Factura de Venta?", "Factura Venta",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (rta.Equals(DialogResult.Yes))
                        {
                            Print();
                        }
                    }
                    else
                    {
                        OptionPane.MessageSuccess("La venta se guardó con éxito!");
                    }
                    LimpiarCamposNewFactura();
                    ObtenerNumero();
                }
                catch (Exception ex)
                {
                    OptionPane.MessageError(ex.Message);
                }
            }*/
        }

        // Funcional
        private void CargarYguardarFacturaDespues()
        {
            try
            {
                if (Convert.ToInt32(cbContado.SelectedValue).Equals(3))
                {
                    if (NitCliente.Equals(""))
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
                    if (ClienteMatch)
                    {
                        miFactura.Proveedor.NitProveedor = NitCliente;
                        miFactura.Numero = miFactura.NumeroEdit;
                        List<ProductoFacturaProveedor> productos =
                                            new List<ProductoFacturaProveedor>();
                        foreach (DataRow row in miTabla.Rows)
                        {
                            var producto = new ProductoFacturaProveedor();
                            producto.Save = Convert.ToBoolean(row["Save"]);
                            if (!producto.Save)
                            {
                                producto.Id = (int)row["Id"];
                            }
                            producto.NumeroFactura = miFactura.Numero;
                            producto.Producto.CodigoInternoProducto = row["Codigo"].ToString();
                            producto.Cantidad = Convert.ToDouble(row["Cantidad"]);
                            producto.Producto.ValorVentaProducto = Convert.ToDouble(row["ValorUnitario"]);
                            producto.ImpoConsumo = Convert.ToDouble(row["Ico"]);
                            producto.Inventario.CodigoProducto = row["Codigo"].ToString();
                            producto.Inventario.IdMedida = Convert.ToInt32(row["IdMedida"]);
                            producto.Inventario.IdColor = Convert.ToInt32(row["IdColor"]);
                            producto.Inventario.Cantidad = Convert.ToDouble(row["Cantidad"]);
                            producto.ValorReal = Convert.ToDouble(row["ValorReal"]);
                            producto.Producto.IdIva = Convert.ToInt32(row["IdIva"]);
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
                        miFactura.Productos = productos;
                        try
                        {
                            miBussinesFactura.EditarFactura(miFactura);
                            OptionPane.MessageSuccess("La venta se guardó con éxito!");
                        }
                        catch (Exception ex)
                        {
                            OptionPane.MessageError(ex.Message);
                        }
                        CompletaEventos.CapEvenAbonoFact(false);
                    }
                }
                else
                {
                    dtpFechaLimite_Validating(this.dtpFechaLimite, new CancelEventArgs(false));
                    if (IdEstado != 1)
                    {
                        if (NitCliente.Equals(""))
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
                        if (IdEstado != 3)
                        {
                            if (Remision)
                            {
                                ObtenerNumero();
                            }
                            else
                            {
                                miFactura.Numero = Factura.Numero;
                                miFactura.NumeroEdit = Factura.Numero;
                            }
                        }
                        else
                        {
                            miFactura.Numero = ObtenerNumeroTemp();
                        }
                        //FechaHoy = DateTime.Now;
                        miFactura.Proveedor.NitProveedor = NitCliente;
                        miFactura.Caja.Id = Convert.ToInt32(AppConfiguracion.ValorSeccion("id_caja"));
                        //miFactura.EstadoFactura.Id = IdEstado;
                        if (Remision && this.Factura.EstadoFactura.Id != 3)
                        {
                            miFactura.EstadoFactura.Id = IdEstado;
                            miFactura.EstadoFactura.IdEdit = IdEstado;
                        }
                        else
                        {
                            miFactura.EstadoFactura.Id = IdEstado;
                            miFactura.EstadoFactura.IdEdit = this.Factura.EstadoFactura.Id;
                        }
                        if (Remision && this.Factura.EstadoFactura.Id == 1)
                        {
                            miFormasPago = new List<DTO.Clases.FormaPago> 
                            { 
                                new DTO.Clases.FormaPago 
                                { 
                                    IdEgreso = Convert.ToInt32(AppConfiguracion.ValorSeccion("idturno")), 
                                    IdFormaPago = 1, 
                                    Valor = Convert.ToInt32(UseObject.RemoveSeparatorMil(this.txtTotal.Text)), 
                                    Pago = Convert.ToInt32(UseObject.RemoveSeparatorMil(this.txtTotal.Text)) 
                                } 
                            };
                        }
                        miFactura.FormasDePago = miFormasPago;

                        if (Remision)
                        {
                            miFactura.FechaIngreso = DateTime.Now;
                            miFactura.FechaLimite = dtpFechaLimite.Value;
                        }
                        else
                        {
                            if ((this.miFactura.EstadoFactura.IdEdit.Equals(3) || this.miFactura.EstadoFactura.IdEdit.Equals(4)) &&
                                (this.miFactura.EstadoFactura.Id.Equals(1) || this.miFactura.EstadoFactura.Id.Equals(2)))
                            {
                                miFactura.FechaIngreso = DateTime.Now;
                                miFactura.FechaLimite = dtpFechaLimite.Value;
                            }
                            else
                            {
                                miFactura.FechaIngreso = UseDate.UnionFechaYHora(this.Factura.FechaIngreso, this.Factura.FechaIngreso);
                                miFactura.FechaLimite = this.Factura.FechaLimite;
                            }
                        }

                        /* if (!(this.Factura.EstadoFactura.Id.Equals(1) || this.Factura.EstadoFactura.Id.Equals(2)))
                         {
                             miFactura.FechaIngreso = DateTime.Now;
                             miFactura.FechaLimite = dtpFechaLimite.Value;
                         }
                         else
                         {
                             miFactura.FechaIngreso = UseDate.UnionFechaYHora(this.Factura.FechaIngreso, this.Factura.FechaIngreso);
                             miFactura.FechaLimite = this.Factura.FechaLimite;
                         }*/

                        if (AplicaRete)
                        {
                            miFactura.Retencion = MiRetencion;
                        }
                        else
                        {
                            miFactura.Retencion = null;
                        }
                        List<ProductoFacturaProveedor> productos =
                                            new List<ProductoFacturaProveedor>();
                        foreach (DataRow row in miTabla.Rows)
                        {
                            var producto = new ProductoFacturaProveedor();
                            producto.Save = Convert.ToBoolean(row["Save"]);
                            if (!producto.Save)
                            {
                                producto.Id = (int)row["Id"];
                            }
                            producto.NumeroFactura = miFactura.Numero;
                            producto.Producto.CodigoInternoProducto = row["Codigo"].ToString();
                            producto.Cantidad = Convert.ToDouble(row["Cantidad"]);
                            producto.Producto.ValorVentaProducto = Convert.ToDouble(row["ValorUnitario"]);
                            producto.ImpoConsumo = Convert.ToDouble(row["Ico"]);
                            producto.Inventario.CodigoProducto = row["Codigo"].ToString();
                            producto.Inventario.IdMedida = Convert.ToInt32(row["IdMedida"]);
                            producto.Inventario.IdColor = Convert.ToInt32(row["IdColor"]);
                            producto.Inventario.Cantidad = Convert.ToDouble(row["Cantidad"]);
                            producto.ValorReal = Convert.ToDouble(row["ValorReal"]);
                            producto.Producto.IdIva = Convert.ToInt32(row["IdIva"]);
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
                        miFactura.Productos = productos;
                        try
                        {
                            /*if (Remision && this.Factura.EstadoFactura.Id == 1)
                            {
                                miFactura.FormasDePago = new List<DTO.Clases.FormaPago> 
                                { 
                                    new DTO.Clases.FormaPago 
                                    { 
                                        IdFormaPago = 1, 
                                        Valor = Convert.ToInt32(UseObject.RemoveSeparatorMil(this.txtTotal.Text)) 
                                    } 
                                };
                            }*/
                            //miFactura.FormasDePago = miFormasPago;

                            miBussinesFactura.IngresarFactura(miFactura, Edicion, false, ConsecutivoCaja);
                            OptionPane.MessageSuccess("La venta se realizó con éxito!");

                            FrmPrint frmPrint = new FrmPrint();
                            frmPrint.StringCaption = "Factura Venta";
                            frmPrint.StringMessage = "Impresión de la Factura de Venta";
                            DialogResult rta = frmPrint.ShowDialog();
                            /*DialogResult rta = MessageBox.Show("¿Desea visualizar la impresión de la Factura de Venta?", "Factura Venta",
                                                     MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);*/
                            if (rta.Equals(DialogResult.Yes))
                            {
                                Print(miFactura.Id, miFactura.Numero, miFactura.AplicaDescuento, miFactura.Proveedor.NitProveedor,
                                    contado, miFactura.EstadoFactura.Id, false);
                            }
                            else
                            {
                                if (rta.Equals(DialogResult.No))
                                {
                                    Print(miFactura.Id, miFactura.Numero, miFactura.AplicaDescuento, miFactura.Proveedor.NitProveedor,
                                    contado, miFactura.EstadoFactura.Id, true);
                                }
                            }

                            /*DialogResult rta = MessageBox.Show("¿Desea imprimir la Factura de Venta?", "Factura Venta",
                                                     MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                            if (rta.Equals(DialogResult.Yes))
                            {
                                Print(miFactura.Numero, miFactura.AplicaDescuento, miFactura.Proveedor.NitProveedor,
                                    contado, miFactura.EstadoFactura.Id, true);
                            }*/

                            /* if (IdEstado.Equals(2))
                             {
                                 rta = MessageBox.Show("¿Desea realizar algun abono?", "Factura de Venta",
                                     MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                                 if (rta.Equals(DialogResult.Yes))
                                 {
                                     var frmCancelarVenta = new Abonos.FrmCancelarVenta();
                                     frmCancelarVenta.IdFactura = miFactura.Id;
                                     frmCancelarVenta.NumeroFactura = miFactura.Numero;
                                     frmCancelarVenta.NitCliente = miFactura.Proveedor.NitProveedor;
                                     frmCancelarVenta.Abono = true;
                                     frmCancelarVenta.EsVenta = true;
                                     frmCancelarVenta.txtTotal.Text = txtTotalMenosRete.Text;//txtTotal.Text;
                                     frmCancelarVenta.ShowDialog();
                                 }
                             }*/
                            CompletaEventos.CapturaEventoz(true);
                            CompletaEventos.CapEvenAbonoFact(112);
                            this.Close();
                            //LimpiarCamposNewFactura();
                        }
                        catch (Exception ex)
                        {
                            OptionPane.MessageError(ex.Message);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
        }

        private void CargarYguardarFacturaPos()
        {
            if (Convert.ToInt32(cbContado.SelectedValue).Equals(3))
            {
                if (NitCliente.Equals(""))
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
                if (ClienteMatch)
                {
                    miFactura.Proveedor.NitProveedor = NitCliente;
                    miFactura.Numero = miFactura.NumeroEdit;
                    List<ProductoFacturaProveedor> productos =
                                        new List<ProductoFacturaProveedor>();
                    foreach (DataRow row in miTabla.Rows)
                    {
                        var producto = new ProductoFacturaProveedor();
                        producto.Save = Convert.ToBoolean(row["Save"]);
                        if (!producto.Save)
                        {
                            producto.Id = (int)row["Id"];
                        }
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
                        producto.ValorReal = Convert.ToDouble(row["ValorReal"]);
                        producto.Producto.IdIva = Convert.ToInt32(row["IdIva"]);
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
                    miFactura.Productos = productos;
                    try
                    {
                        miBussinesFactura.EditarFactura(miFactura);
                        OptionPane.MessageSuccess("La venta se guardó con éxito!");
                    }
                    catch (Exception ex)
                    {
                        OptionPane.MessageError(ex.Message);
                    }
                    CompletaEventos.CapEvenAbonoFact(false);
                }
            }
            else
            {
                dtpFechaLimite_Validating(this.dtpFechaLimite, new CancelEventArgs(false));
                if (IdEstado != 1)
                {
                    if (NitCliente.Equals(""))
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
                    if (IdEstado != 3)
                    {
                        if (Remision)
                        {
                            ObtenerNumero();
                        }
                        else
                        {
                            miFactura.Numero = Factura.Numero;
                            miFactura.NumeroEdit = Factura.Numero;
                        }
                    }
                    else
                    {
                        miFactura.Numero = ObtenerNumeroTemp();
                    }
                    //FechaHoy = DateTime.Now;
                    miFactura.Proveedor.NitProveedor = NitCliente;
                    miFactura.Caja.Id = Convert.ToInt32(AppConfiguracion.ValorSeccion("id_caja"));
                    /* miFactura.EstadoFactura.Id = IdEstado;
                     miFactura.EstadoFactura.IdEdit = this.Factura.EstadoFactura.Id;*/
                    //miFactura.EstadoFactura.Id = IdEstado;
                    if (Remision && this.Factura.EstadoFactura.Id != 3)
                    {
                        miFactura.EstadoFactura.Id = IdEstado;
                        miFactura.EstadoFactura.IdEdit = IdEstado;
                    }
                    else
                    {
                        miFactura.EstadoFactura.Id = IdEstado;                              // IdEstado = estado el cual se ha seleccionado para la factura
                        miFactura.EstadoFactura.IdEdit = this.Factura.EstadoFactura.Id;     // IdEdit   = estado el cual estaba la factura antes de ser editada.
                    }

                    if (Remision && this.Factura.EstadoFactura.Id == 1)
                    {
                        miFormasPago = new List<DTO.Clases.FormaPago> 
                            { 
                                new DTO.Clases.FormaPago 
                                { 
                                    IdEgreso = Convert.ToInt32(AppConfiguracion.ValorSeccion("idturno")), 
                                    IdFormaPago = 1, 
                                    Valor = Convert.ToInt32(UseObject.RemoveSeparatorMil(this.txtTotal.Text)), 
                                    Pago = Convert.ToInt32(UseObject.RemoveSeparatorMil(this.txtTotal.Text)) 
                                } 
                            };
                    }

                    miFactura.FormasDePago = miFormasPago;

                    if (Remision)
                    {
                        miFactura.FechaIngreso = DateTime.Now;
                        miFactura.FechaLimite = dtpFechaLimite.Value;
                    }
                    else
                    {
                        if ((this.miFactura.EstadoFactura.IdEdit.Equals(3) || this.miFactura.EstadoFactura.IdEdit.Equals(4)) &&
                            (this.miFactura.EstadoFactura.Id.Equals(1) || this.miFactura.EstadoFactura.Id.Equals(2)))
                        {
                            miFactura.FechaIngreso = DateTime.Now;
                            miFactura.FechaLimite = dtpFechaLimite.Value;
                        }
                        else
                        {
                            miFactura.FechaIngreso = UseDate.UnionFechaYHora(this.Factura.FechaIngreso, this.Factura.FechaIngreso);
                            miFactura.FechaLimite = this.Factura.FechaLimite;
                        }
                    }
                    /*if (!(this.Factura.EstadoFactura.Id.Equals(1) || this.Factura.EstadoFactura.Id.Equals(2)))
                    {
                        miFactura.FechaIngreso = DateTime.Now;
                        miFactura.FechaLimite = dtpFechaLimite.Value;
                    }
                    else
                    {
                        miFactura.FechaIngreso = UseDate.UnionFechaYHora(this.Factura.FechaIngreso, this.Factura.FechaIngreso);
                        miFactura.FechaLimite = this.Factura.FechaLimite;
                    }*/
                    //miFactura.FechaIngreso = FechaHoy;
                    //miFactura.FechaLimite = dtpFechaLimite.Value;

                    if (AplicaRete)
                    {
                        miFactura.Retencion = MiRetencion;
                    }
                    else
                    {
                        miFactura.Retencion = null;
                    }
                    List<ProductoFacturaProveedor> productos =
                                        new List<ProductoFacturaProveedor>();
                    foreach (DataRow row in miTabla.Rows)
                    {
                        var producto = new ProductoFacturaProveedor();
                        producto.Save = Convert.ToBoolean(row["Save"]);
                        if (!producto.Save)
                        {
                            producto.Id = (int)row["Id"];
                        }
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
                        producto.ValorReal = Convert.ToDouble(row["ValorReal"]);
                        producto.Retorno = Convert.ToBoolean(row["Retorno"]);
                        producto.Producto.IdIva = Convert.ToInt32(row["IdIva"]);
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
                    miFactura.Productos = productos;
                    try
                    {
                        miFactura.Id = miBussinesFactura.IngresarFactura(miFactura, Edicion, false, ConsecutivoCaja);
                        Punto punto = new Punto();
                        double[] data = new double[2];
                        if ((this.miFactura.EstadoFactura.IdEdit.Equals(3) || this.miFactura.EstadoFactura.IdEdit.Equals(4)) &&
                            (this.miFactura.EstadoFactura.Id.Equals(1) || this.miFactura.EstadoFactura.Id.Equals(2)))          // validación que indica que pasa
                        {
                            if (this.miFactura.Proveedor.NitProveedor != "1000" &&
                                this.miFactura.Proveedor.NitProveedor != "10")
                            {
                                punto = this.miBussinesPunto.CargarPunto();
                                if (punto.EstadoPunto)
                                {
                                    data = CargarPuntos(punto, miFactura.Proveedor.NitProveedor, miFactura.Id, miFactura.AplicaDescuento);
                                }
                            }
                            PrintPos(this.miFactura.Id, this.miFactura.AplicaDescuento, this.miFactura.Proveedor.NitProveedor, this.contado,
                                this.miFactura.EstadoFactura.Id, Convert.ToInt32(miFormasPago.Sum(d => d.Pago)), punto.EstadoPunto, data);

                            if (this.miBono.Canje)
                            {
                                int numeroBonos = UseObject.RetiraDecima(this.ValorPorMarcas() / this.miBono.Valor);
                                for (int i = 1; i <= numeroBonos; i++)
                                {
                                    this.PrintBonoRifa(this.miBono, this.miFactura.Proveedor.NitProveedor, this.miFactura.Numero);
                                }
                            }
                        }
                        else
                        {
                            this.DescuentoMarca = false;
                            PrintPos(this.miFactura.Id, this.miFactura.AplicaDescuento, this.miFactura.Proveedor.NitProveedor, this.contado,
                                this.miFactura.EstadoFactura.Id, Convert.ToInt32(miFormasPago.Sum(d => d.Pago)), punto.EstadoPunto, data);
                        }
                        // (int id, bool descto, string cliente, bool contado, int idEstado, int pago, bool puntos, double[] data)
                        


                       /* OptionPane.MessageSuccess("La venta se realizó con éxito!");
                        DialogResult rta = MessageBox.Show("¿Desea imprimir la Factura de Venta?", "Factura Venta",
                                                 MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (rta.Equals(DialogResult.Yes))
                        {
                            PrintPos(miFactura.Id, miFactura.Numero, miFactura.AplicaDescuento,
                                     miFactura.Proveedor.NitProveedor, contado,
                                     miFactura.EstadoFactura.Id, Convert.ToInt32(miFormasPago.Sum(d => d.Pago)));
                        }*/
                        /* if (IdEstado.Equals(2))
                         {
                             rta = MessageBox.Show("¿Desea realizar algun abono?", "Factura de Venta",
                                 MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                             if (rta.Equals(DialogResult.Yes))
                             {
                                 var frmCancelarVenta = new Abonos.FrmCancelarVenta();
                                 frmCancelarVenta.IdFactura = miFactura.Id;
                                 frmCancelarVenta.NumeroFactura = miFactura.Numero;
                                 frmCancelarVenta.NitCliente = miFactura.Proveedor.NitProveedor;
                                 frmCancelarVenta.Abono = true;
                                 frmCancelarVenta.EsVenta = true;
                                 frmCancelarVenta.txtTotal.Text = txtTotal.Text;
                                 frmCancelarVenta.ShowDialog();

                                 /*var frmCancelarVenta = new Abonos.FrmCancelarVenta();
                                 frmCancelarVenta.IdFactura = miFactura.Id;
                                 frmCancelarVenta.NumeroFactura = miFactura.Numero;
                                 frmCancelarVenta.NitCliente = miFactura.Proveedor.NitProveedor;
                                 frmCancelarVenta.Abono = true;
                                 frmCancelarVenta.EsVenta = true;
                                 frmCancelarVenta.txtTotal.Text = txtTotalMenosRete.Text;//txtTotal.Text;
                                 frmCancelarVenta.ShowDialog();*/
                        //}
                        // }
                        CompletaEventos.CapturaEventoz(true);
                        CompletaEventos.CapEvenAbonoFact(112);
                        this.Close();
                        //LimpiarCamposNewFactura();
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


        /*private void CargarYguardarFacturaPos()
        {
            {
                dtpFechaLimite_Validating(this.dtpFechaLimite, new CancelEventArgs(false));
                if (IdEstado != 1)
                {
                    if (NitCliente.Equals(""))
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
                    miFactura.Proveedor.NitProveedor = NitCliente;
                    miFactura.Caja.Id = 1;
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
                        miBussinesFactura.IngresarFactura(miFactura, Edicion, false);
                        
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
                                PrintPos(miFactura.Numero, miFactura.AplicaDescuento,
                                         miFactura.Proveedor.NitProveedor, contado,
                                         miFactura.EstadoFactura.Id, Convert.ToInt32(miFormasPago.Sum(d => d.Valor)));
                            }
                        }
                        if (IdEstado != 1)
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
                    }
                    catch (Exception ex)
                    {
                        OptionPane.MessageError(ex.Message);
                    }
                }
            }
        }*/

        private void LimpiarCamposNewFactura()
        {
            while (dgvListaArticulos.RowCount != 0)
            {
                dgvListaArticulos.Rows.RemoveAt(0);
            }
            txtCantidad.Text = "1";
            txtTotal.Text = "0";
            //  tsCbContado.ComboBox.SelectedIndex = 0;
            // tsCbDesctoRecargo.ComboBox.SelectedIndex = 0;
            miTabla.Clear();
            txtCodigoArticulo.Focus();
        }

        public void CargarFacturaEdicion()
        {
            this.miFactura.Id = this.Factura.Id;
            gbInfo.Visible = true;
            lblInfo.Visible = true;
            /* if (Factura.EstadoFactura.Id < 3)
             {
                 if (Remision)
                 {
                     if (PagoFactRemision)
                     {
                         Factura.FechaIngreso = DateTime.Now;
                         Factura.FechaLimite = DateTime.Now;
                         cbContado.SelectedValue = 1;
                     }
                     else
                     {
                         cbContado.SelectedValue = 2;
                     }
                 }
                 else
                 {
                     cbContado.SelectedValue = Factura.EstadoFactura.Id;
                 }
             }
             tsCbContado_SelectedIndexChanged(null, null);*/
            if (Factura.AplicaDescuento)
            {
                cbDesctoRecargo.SelectedValue = 1;
            }
            else
            {
                cbDesctoRecargo.SelectedValue = 2;
            }
            tsCbDesctoRecargo_SelectedIndexChanged(this.cbDesctoRecargo, new EventArgs());
            dtpFechaLimite.Value = Factura.FechaLimite;
            NitCliente = Factura.Proveedor.NitProveedor;
            txtCliente.Text = Factura.Proveedor.NitProveedor;
            txtNombreCliente.Text = Factura.Proveedor.NombreProveedor;
            cliente = miBussinesCliente.ClienteAEditar(Factura.Proveedor.NitProveedor);
            miFactura.NumeroEdit = Factura.Numero;
            //FechaHoy = Factura.FechaIngreso;
            FechaHoy = DateTime.Now;
            lblDataFecha.Text = FechaHoy.Day + " de " + UseDate.MesCorto(FechaHoy.Month) + " de " + FechaHoy.Year;
            if (Factura.Remision_)
            {
                miFactura.Remision_ = Factura.Remision_;
            }
            miFactura.Pendiente = Factura.Pendiente;
            miTabla = Productos;
            //miBindingSource.DataSource = Productos;
            RecargarGridview();
            txtTotal.Text = UseObject.InsertSeparatorMil
                (
                   Convert.ToInt32(
                   miTabla.AsEnumerable().Sum(s => s.Field<double>("Valor"))
                   ).ToString()
                );
            ColorearGrid();
            //Productos.Clear();
            //Productos = null;
            try
            {
                //cbContado.DataSource = miBussinesEstado.Lista();
                /*var tabla = miBussinesEstado.Lista();
                IEnumerable<DataRow> query = from data in tabla.AsEnumerable()
                                             where data.Field<int>("idestado") == 1 ||
                                                   data.Field<int>("idestado") == 2 ||
                                                   data.Field<int>("idestado") == 3
                                             select data;
                cbContado.DataSource = query.CopyToDataTable<DataRow>();*/
                if (Factura.EstadoFactura.Id < 3)
                {
                    if (Remision)
                    {
                        if (PagoFactRemision)
                        {
                            Factura.FechaIngreso = DateTime.Now;
                            Factura.FechaLimite = DateTime.Now;
                            cbContado.SelectedValue = 1;
                        }
                        else
                        {
                            cbContado.SelectedValue = 2;
                        }
                    }
                    else
                    {
                        cbContado.SelectedValue = Factura.EstadoFactura.Id;
                    }
                }
                else
                {
                    cbContado.SelectedValue = Factura.EstadoFactura.Id;
                }
                tsCbContado_SelectedIndexChanged(null, null);
                switch (Factura.EstadoFactura.Id)
                {
                    case 3:
                        {
                            lblInfoEstado.Text = "FR Pendiente No " + Factura.Numero;
                            break;
                        }
                    case 4:
                        {
                            lblInfoEstado.Text = "Cotización No " + Factura.Numero;
                            break;
                        }
                }
                /*var tabla = miBussinesEstado.Lista();
                if (Factura.EstadoFactura.Id.Equals(3))
                {
                    IEnumerable<DataRow> query = from data in tabla.AsEnumerable()
                                                 where data.Field<int>("idestado") == 1 ||
                                                       data.Field<int>("idestado") == 2 ||
                                                       data.Field<int>("idestado") == 3
                                                 select data;
                    cbContado.DataSource = query.CopyToDataTable<DataRow>();
                }*/
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
            try
            {
                //var retenciones = miBussinesRetencion.RetencionesAVenta(Factura.Numero);
                var retenciones = miBussinesRetencion.RetencionesAVenta(Factura.Id);
                if (retenciones.Rows.Count != 0)
                {
                    AplicaRete = true;
                    btnInfoRete.Enabled = true;
                    btnCambiarRetencion.Enabled = true;

                    var row = retenciones.AsEnumerable().First();
                    MiRetencion.Id = Convert.ToInt32(row["id"]);
                    MiRetencion.Concepto = row["concepto"].ToString();
                    MiRetencion.CifraUVT = Convert.ToDouble(row["cifra_uvt"]);
                    MiRetencion.CifraPesos = Convert.ToDouble(row["cifra_pesos"]);
                    MiRetencion.Tarifa = Convert.ToDouble(row["tarifa"]);

                    //var tasa = Convert.ToDouble(retenciones.AsEnumerable().Single()["tarifa"]);
                    var totalFact = Convert.ToInt32
                                   (miTabla.AsEnumerable().Sum(t => (t.Field<double>("Valor"))));
                    txtRetencion.Text = UseObject.InsertSeparatorMil
                            (Convert.ToInt32(totalFact * MiRetencion.Tarifa / 100).ToString());
                    lblTasaRetencion.Text = MiRetencion.Tarifa.ToString() + "%";
                    miToolTip.SetToolTip(btnInfoRete,
                                         MiRetencion.Concepto + " - " +
                                         MiRetencion.Tarifa.ToString() + "%");
                    txtTotalMenosRete.Text = UseObject.InsertSeparatorMil((
                        UseObject.RemoveSeparatorMil(txtTotal.Text) - UseObject.RemoveSeparatorMil(txtRetencion.Text)).ToString());
                }
                else
                {
                    AplicaRete = false;
                }
                RecargarRetencion();
                /*
                 * MiRetencion.Concepto = AppConfiguracion.ValorSeccion("concepto_v");
                MiRetencion.CifraUVT = Convert.ToDouble(AppConfiguracion.ValorSeccion("uvt_v"));
                MiRetencion.CifraPesos = Convert.ToInt32(AppConfiguracion.ValorSeccion("pesos_v"));
                MiRetencion.Tarifa = Convert.ToDouble(AppConfiguracion.ValorSeccion("tasa_v"));
                 */
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
        }

        private void Print
            (int id, string numero, bool descto, string cliente, bool contado, int idEstado, bool view)
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
                dsDetalle = miBussinesFactura.PrintProducto(id, descto);
                dsEmpresa = miBussinesEmpresa.PrintEmpresa();
                dsFactura = miBussinesFactura.PrintFacturaVenta(id);
                dsUsuario = miBussinesUsuario.PrintUsuario(id);
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
                //frmPrint.MdiParent = this.MdiParent;

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

                //frmPrint.RptvFactura.LocalReport.ReportPath = @"c:\reports\FacturaVenta.rdlc";
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
                    pResDian.Values.Add(dsDian.Tables["TDian"].AsEnumerable().First()["print_dian"].ToString());
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

        /*private void Print(string numero, bool descto, string cliente, bool contado, int idEstado)
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
                dsDetalle = miBussinesFactura.PrintProducto(numero, descto);
                dsEmpresa = miBussinesEmpresa.PrintEmpresa();
                dsFactura = miBussinesFactura.PrintFacturaVenta(numero);
                dsUsuario = miBussinesUsuario.PrintUsuario(numero);
                dsCliente = miBussinesCliente.PrintCliente(cliente);
                if (contado)
                {
                    dsDian = miBussinesDian.Print(true);
                }
                else
                {
                    dsDian = miBussinesDian.Print(false);
                }

                var frmPrint = new FrmPrintFactura();
                //frmPrint.MdiParent = this.MdiParent;

                frmPrint.RptvFactura.LocalReport.DataSources.Clear();
                frmPrint.RptvFactura.LocalReport.Dispose();
                frmPrint.RptvFactura.Reset();

                frmPrint.RptvFactura.LocalReport.DataSources.Add(
                    new ReportDataSource("DsDian", dsDian.Tables["TDian"]));
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

                //frmPrint.RptvFactura.LocalReport.ReportPath = @"..\..\Ventas\Reportes\RptFacturaVenta.rdlc";
                //frmPrint.RptvFactura.LocalReport.ReportPath = @"C:\reports\RptFacturaVenta.rdlc";
                frmPrint.RptvFactura.LocalReport.ReportPath = AppConfiguracion.ValorSeccion("report") + @"\reports\RptFacturaVenta_vc.rdlc";

                Label NoFactura = new Label();
                NoFactura.AutoSize = true;
                NoFactura.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                NoFactura.Text = numero;

                var Fact = new ReportParameter();
                Fact.Name = "Fact";
                if (idEstado != 3)
                {
                    Fact.Values.Add("FACTURA DE VENTA No.  " + NoFactura.Text);
                }
                else
                {
                    Fact.Values.Add("COTIZACIÓN");
                }
                frmPrint.RptvFactura.LocalReport.SetParameters(Fact);

                var pago = new ReportParameter();
                pago.Name = "pago";
                if (contado)
                {
                    pago.Values.Add("Contado");
                }
                else
                {
                    pago.Values.Add("Crédito");
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
        }*/

        private void PrintPos
            (int id, string numero, bool descto, string cliente, bool contado, int idEstado, int pago)
        {
            try
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
                var dianRow = miBussinesDian.ConsultaDian().AsEnumerable().First();

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
                        //No = "";
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
                var k = "Cajero(a)  :  " + usuarioRow["Nombre"].ToString();
                ticket.AddHeaderLine("===================================");
                ticket.AddHeaderLine("CLIENTE : " + clienteRow["Nombre"].ToString());
                var l = "CLIENTE : " + clienteRow["Nombre"].ToString();
                ticket.AddHeaderLine("NIT     : " + UseObject.InsertSeparatorMilMasDigito(clienteRow["Nit"].ToString()));
                ticket.AddHeaderLine("===================================");
                ticket.AddHeaderLine("");
                ticket.AddHeaderLine("");

                ticket.AddHeaderLine("COD.  DESCRIP.  CANT.  VENTA  TOTAL");
                ticket.AddHeaderLine("___________________________________");
                ticket.AddHeaderLine("");
                foreach (DataRow dRow in tDetalle.Rows)
                {
                    string product = dRow["Producto"].ToString();
                    if (product.Length > 30)
                    {
                        product = product.Substring(0, 30);
                    }
                    ticket.AddHeaderLine(dRow["Codigo"].ToString() + " " + product);
                    ticket.AddHeaderLine("              " + dRow["Cantidad"].ToString() + " x " + UseObject.InsertSeparatorMil(dRow["Valor_"].ToString()) +
                                         "  " + UseObject.InsertSeparatorMil(dRow["Total_"].ToString()));
                }
                ticket.AddHeaderLine("");
                ticket.AddHeaderLine("===================================");
                ticket.AddHeaderLine("");
                var total = tDetalle.AsEnumerable().Sum(d => d.Field<int>("Total_"));

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
                    }
                }
                ticket.AddHeaderLine("");
                if (Convert.ToInt32(empresaRow["idregimen"]).Equals(1))
                {
                    if (idEstado.Equals(1) || idEstado.Equals(2))
                    {
                        ticket.AddHeaderLine("Res DIAN : " + dianRow["Resolucion"].ToString() + " "
                                             + Convert.ToDateTime(dianRow["Fecha"]).ToShortDateString());
                        ticket.AddHeaderLine("Habilita : " + dianRow["Desde"].ToString() + " Hasta " + dianRow["Hasta"].ToString());
                    }
                }
                ticket.AddHeaderLine("-----------------------------------");
                ticket.AddHeaderLine("Software: Digital Fact Pyme");
                ticket.AddHeaderLine("Soluciones Tecnológicas A&C.");
                ticket.AddHeaderLine("solucionestecnologicasayc@gmail.com");
                ticket.AddHeaderLine("");
                ticket.AddHeaderLine("*GRACIAS POR SER NUESTROS CLIENTES*");
                ticket.AddHeaderLine("");
                ticket.AddHeaderLine("");

                ticket.PrintTicket("IMPREPOS");

                /*ticket.AddHeaderLine(empresaRow["Nombre"].ToString().ToUpper());
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
                var k = "Cajero(a)  :  " + usuarioRow["Nombre"].ToString();
                ticket.AddHeaderLine("===================================");
                ticket.AddHeaderLine("CLIENTE : " + clienteRow["Nombre"].ToString());
                var l = "CLIENTE : " + clienteRow["Nombre"].ToString();
                ticket.AddHeaderLine("NIT     : " + UseObject.InsertSeparatorMilMasDigito(clienteRow["Nit"].ToString()));
                var m = "NIT     : " + UseObject.InsertSeparatorMilMasDigito(clienteRow["Nit"].ToString());

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
                var total = tDetalle.AsEnumerable().Sum(d => d.Field<int>("Total_"));

                ticket.AddTotal("TOTAL     : ", UseObject.InsertSeparatorMil(total.ToString()));
                if (idEstado.Equals(1))
                {
                    ticket.AddTotal("EFECTIVO  : ", UseObject.InsertSeparatorMil(pago.ToString()));
                    ticket.AddTotal("CAMBIO    : ", UseObject.InsertSeparatorMil((pago - total).ToString()));
                }
                else
                {
                    ticket.AddTotal("EFECTIVO  : ", "0");
                    ticket.AddTotal("CAMBIO    : ", "0");
                }

                ticket.AddHeaderLine("===================================");  // Revisar

                if (Convert.ToInt32(empresaRow["idregimen"]).Equals(1))
                {
                    if (idEstado.Equals(1) || idEstado.Equals(2))
                    {
                        ticket.AddFooterLine("-------Discriminación de IVA-------");
                        ticket.AddFooterLine("GRAVADO    BASE      IVA      TOTAL");

                        foreach (DataRow iRow in tIva.Rows)
                        {
                            ticket.AddFooterLine(" " + iRow["Iva"].ToString() +
                                                 "    " + UseObject.InsertSeparatorMil(Convert.ToInt32(iRow["Base"]).ToString()) +
                                                 "    " + UseObject.InsertSeparatorMil(Convert.ToInt32(iRow["VIva"]).ToString()) +
                                                 "    " + UseObject.InsertSeparatorMil(Convert.ToInt32(iRow["SubTotal"]).ToString()));
                        }
                    }
                }

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
                ticket.AddFooterLine("Software: Digital Fact Pyme");
                ticket.AddFooterLine("Soluciones Tecnológicas A&C.");
                ticket.AddHeaderLine("solucionestecnologicasayc@gmail.com");
                ticket.AddFooterLine(".");
                ticket.AddFooterLine("*GRACIAS POR SER NUESTROS CLIENTES*");
                ticket.AddFooterLine(".");
                ticket.AddFooterLine(".");

                ticket.PrintTicket("IMPREPOS");*/
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
        }

        private void PrintPos
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
                    printTicket.clienteRow = this.miBussinesCliente.ConsultaClienteNit(cliente).AsEnumerable().First();

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
                    printTicket.impuesto = miBussinesIcoBolsas.ImpuestoBolsaDeVenta(id);
                   // printTicket.dianRow = this.miBussinesDian.DianRow();
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
                RawPrinterHelper.SendStringToPrinter("IMPREPOS", caracteres);
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
                if (UseDate.FechaSinHora(this.Factura.FechaLimite).Equals(UseDate.FechaSinHora(this.dtpFechaLimite.Value)))
                {
                    LimiteMatch = true;
                }
                else
                {
                    if (UseDate.FechaSinHora(dtpFechaLimite.Value) > UseDate.FechaSinHora(Factura.FechaIngreso)) //UseDate.FechaSinHora(FechaHoy))
                    {
                        LimiteMatch = true;
                    }
                    else
                    {
                        LimiteMatch = false;
                        OptionPane.MessageError("La fecha limite debe ser superior a la de hoy.");
                        miError.SetError(dtpFechaLimite, "La fecha limite debe ser superior a la de hoy.");
                    }
                }
                /*  if (UseDate.FechaSinHora(dtpFechaLimite.Value) > UseDate.FechaSinHora(Factura.FechaIngreso)) //UseDate.FechaSinHora(FechaHoy))
                  {
                      LimiteMatch = true;
                  }
                  else
                  {
                      LimiteMatch = false;
                      OptionPane.MessageError("La fecha limite debe ser superior a la de hoy.");
                      miError.SetError(dtpFechaLimite, "La fecha limite debe ser superior a la de hoy.");
                  }*/
            }
            else
            {
                dtpFechaLimite.Value = DateTime.Today;
                LimiteMatch = true;
            }
        }
        private bool LimiteMatch = false;

        private void RetiroDeProducto()
        {
            int id = (int)this.dgvListaArticulos.CurrentRow.Cells["Id"].Value;
            var row = (from registro in miTabla.AsEnumerable()
                       where registro.Field<int>("Id") == id
                       select registro).Single();
            miTabla.Rows.Remove(row);
            if (miTabla.Rows.Count != 0)
            {
                RecargarGridview();
                ColorearGrid();
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
            dgvListaArticulos.Focus();
            txtCodigoArticulo.Focus();
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
                var query = Retenciones.First();
                MiRetencion.Tarifa = query.Tarifa;
                MiRetencion.CifraPesos = query.CifraPesos;
                MiRetencion.CifraUVT = query.CifraUVT;
                MiRetencion.Concepto = query.Concepto;
                lblTasaRetencion.Text = query.Tarifa.ToString() + "%";
                miToolTip.SetToolTip(btnInfoRete, query.Concepto);
                AplicaRete = true;
                btnInfoRete.Enabled = true;
                miToolTip.SetToolTip(btnInfoRete, MiRetencion.Concepto);
                RecargarRetencion();
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
                    RecargarRetencion();
                }
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
                }
                else
                {
                    txtRetencion.Text = "0";
                }
            }
            else
            {
                txtRetencion.Text = "0";
            }
            txtTotalMenosRete.Text = UseObject.InsertSeparatorMil(
                        (UseObject.RemoveSeparatorMil(txtTotal.Text) - UseObject.RemoveSeparatorMil(txtRetencion.Text)).ToString());
            MiRetencion.Valor = UseObject.RemoveSeparatorMil(this.txtRetencion.Text);
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
    }

    /// <summary>
    /// Muestra los datos en una cuadricula personalizada y mejorada.
    /// </summary>
    internal class DataGridViewPlus : DataGridView
    {
        /// <summary>
        /// Procesa teclas, como TAB, ESCAPE, ENTRAR, y las teclas de dirección, usadas para
        /// controlar cuadros de diálogo.
        /// </summary>
        /// <param name="keyData">Combinación bit a bit de valores de System.Windows.Form.Keys que representan
        ///  a las teclas que se van a procesar.</param>
        /// <returns></returns>
        protected override bool ProcessDialogKey(Keys keyData)
        {
            if (keyData == Keys.Enter)
            {
                SendKeys.Send("{TAB}");
                return true;
            }
            else
            {
                return base.ProcessDialogKey(keyData);
            }
        }
    }

    internal class PrintFactura
    {
        public int Id { set; get; }

        public string Numero { set; get; }

        public bool Descuento { set; get; }

        public string Cliente { set; get; }

        public bool Contado { set; get; }
    }
}