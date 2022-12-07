using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using BussinesLayer.Clases;
using CustomControl;
using DTO.Clases;
using Utilities;

namespace Aplicacion.Compras.IngresarCompra
{
    public partial class FrmIngresarCompra : Form
    {
        #region Atributos de Logica de Negocio

        private BussinesConsecutivo miBussinesConsecutivo;

        private BussinesEstado miBussinesEstado;

        /// <summary>
        /// Objeto de logica de negocio de Proveedor.
        /// </summary>
        private BussinesProveedor miBussinesProveedor;

        private Empresa MiEmpresa { set; get; }

        /// <summary>
        /// Objeto para cargar registros Proveedor.
        /// </summary>
        private DTO.Clases.Proveedor MiProveedor;

        /// <summary>
        /// Objeto para cargar los datos de la medida del producto consultado.
        /// </summary>
        private ValorUnidadMedida miMedida;

        private BussinesEmpresa miBussinesEmpresa;

        /// <summary>
        /// Objeto de logica de negocio de Producto.
        /// </summary>
        private BussinesProducto miBussinesProducto;

        /// <summary>
        /// Objeto de logica de negocio de Usuario.
        /// </summary>
        private BussinesUsuario miBussinesUsuario;

        /// <summary>
        /// Objeto de logica de negocio de Factura Proveedor.
        /// </summary>
        private BussinesFacturaProveedor miBussinesFacturaProveedor;

        private BussinesValorUnidadMedida miBussinesMedida;

        private BussinesColor miBussinesColor;

        private BussinesPuc miBussinesPuc;

        private BussinesRetencion miBussinesRetencion;

        #endregion

        #region Propiedades

        private bool EsFactura { set; get; }

        /// <summary>
        /// Representa un objeto para la carga de datos de FacturaProveedor.
        /// </summary>
        private FacturaProveedor miFactura;

        /// <summary>
        /// Obtiene o establece el valor de la fecha en que se ingresa la factura.
        /// </summary>
        private DateTime FechaHoy;

        /// <summary>
        /// Representa el objeto de estructura las Formas de Pago.
        /// </summary>
        private FormaPago miFormaPago;

        /// <summary>
        /// Colección que almacena objetos, en este caso Productos.
        /// </summary>
        private ArrayList ArrayProducto;

        /// <summary>
        /// Objeto para cargar Producto.
        /// </summary>
        private DTO.Clases.Producto MiProducto;

        /// <summary>
        /// Objeto para la carga del talla y color del producto.
        /// </summary>
        private TallaYcolor miTallaYcolor;

        /// <summary>
        /// Obtiene o establece el valor del Consecutivo del número de Lote.
        /// </summary>
        private int LoteConsecutivo;

        /// <summary>
        /// Obtiene o establece el valor del Lote.
        /// </summary>
        private string Lote;

        /// <summary>
        /// Representa una tabla de datos en memoria.
        /// </summary>
        private DataTable miTabla;

        private RetencionConcepto MiRetencion { set; get; }

        private int RowsCosto;

        private bool TipoAproxPrecio;

        private bool _ConsultaInventario;

        private bool AplicaRete;

        private double BaseRete;

        private double TasaRete;

        #endregion

        #region Atributos de Validacion

        /// <summary>
        /// Obtiene o establece el valor que indica si se habilita color o no en el formulario segun la configuración.
        /// </summary>
        private bool EnableColor;

        /// <summary>
        /// Objeto que muestra mensajes de error.
        /// </summary>
        public ErrorProvider MiError;

        /// <summary>
        /// Obtiene o establece el valor que indica si se encuentra abierto el Form de Proveedor.
        /// </summary>
        private bool FormProveedor { set; get; }

        /// <summary>
        /// Obtiene o establece el valor que indica si se encuentra abierto el Form de Producto.
        /// </summary>
        private bool FormProducto = false;

        private bool FormInventario = false;

        /// <summary>
        /// Indica si solo se realiza una transferencia de datos de Proveedor para ingreso de factura.
        /// </summary>
        private bool AddProveedor = false;

        /// <summary>
        /// Indica si solo se realiza una transferencia de datos de Medida y Color para ingreso de factura.
        /// </summary>
        private bool AddColor = false;

        /// <summary>
        /// Lista que acomula el valor del Id del Regimen de cada Proveedor que se carga.
        /// </summary>
        private List<int> IdRegimen;

        /// <summary>
        /// Indica que el Número de la Factura se ingreso correctamente.
        /// </summary>
        private bool NumFacturaMatch = false;

        /// <summary>
        /// Indica que la fecha concuerda con lo requerido.
        /// </summary>
        private bool FechaMatch = true;

        /// <summary>
        /// Indica que el descuento aplicado concuerda con lo requerido.
        /// </summary>
        private bool DescuentoMatch = true;

        private bool AjusteMatch = true;

        /// <summary>
        /// Establece la regla de validacion que indica si se uso el metodo KeyPress del codigo.
        /// </summary>
        private bool KeyProductoPress = false;

        /// <summary>
        /// Indica que se ha cargado la Talla y el Color desde el Boton Agregar Registro.
        /// </summary>
        private bool LoadColorSize = false;

        /// <summary>
        /// Establece la regla de validacion que indica si se uso el metodo KeyPress del Codigo de Proveedor.
        /// </summary>
        private bool KeyProveedorPress = false;

        /// <summary>
        /// Establece la regla de validacion que indica si el campo Cantidad es valido.
        /// </summary>
        private bool CantidadMatch = true;

        /// <summary>
        /// Establece la regla de validacion que indica si el campo Valor es valido.
        /// </summary>
        private bool ValorMatch = true;

        /// <summary>
        /// Establece la regla de validación que indica si el campo Lote es válido.
        /// </summary>
        private bool LoteMatch = true;

        /// <summary>
        /// Establece la condición que indica si se aplica descuento por producto.
        /// </summary>
        private bool DesctoProducto = true;

        /// <summary>
        /// Establece la regla de validación que indica si el campo Descuento por Producto es válido.
        /// </summary>
        private bool DesctoProductoMatch = true;

        /// <summary>
        /// Indica si se quiere ver las medidas en el Grid.
        /// </summary>
        private bool BtnVerMedidaPress = true;

        /// <summary>
        /// Indica que no se quiere ver las medidas en el Grid.
        /// </summary>
        private bool BtnNoVerMedidaPress = true;

        /// <summary>
        /// Indica que se quiere ver el Color en el Grid.
        /// </summary>
        private bool BtnVerColorPress = true;

        /// <summary>
        /// Indica que no se quiere ver el Color en el Grid.
        /// </summary>
        private bool BtnNoVerColorPress = true;

        /// <summary>
        /// Indica que se quiere ver el Lote en el Grid.
        /// </summary>
        private bool BtnVerLotePress = true;

        /// <summary>
        /// Indica que no se quiere ver el Lote en el Grid.
        /// </summary>
        private bool BtnNoVerLotePress = true;

        /// <summary>
        /// Indica si el Producto tiene una sola talla.
        /// </summary>
        private bool SingleSize = false;

        /// <summary>
        /// Indica si el Producto tiene un solo color.
        /// </summary>
        private bool SingleColor = false;

        /// <summary>
        /// Representa el texto: El campo Codigo del Proveedor es requerido.
        /// </summary>
        public string CodigoProveedorReq = "El campo Codigo del Proveedor es requerido.";

        /// <summary>
        /// Representa el texto: El Codigo del Proveedor que ingreso tiene formato incorrecto.
        /// </summary>
        public string CodigoProveedorFormato = "El Codigo del Proveedor que ingreso tiene formato incorrecto.";

        /// <summary>
        /// Representa el texto: El Codigo del Proveedor que ingreso no tiene registros en la base de datos.
        /// </summary>
        public string CodigoProveedorExiste = "El Codigo del Proveedor que ingreso no tiene registros en la base de datos.";

        /// <summary>
        /// Representa el mensaje: El campo Número de Factura es requerido.
        /// </summary>
        public string FacturaReq = "El campo Número de Factura es requerido.";

        /// <summary>
        /// El Número de Factura que ingreso tiene formato incorrecto.
        /// </summary>
        public string FacturaFormato = "El Número de Factura que ingreso tiene formato incorrecto.";

        /// <summary>
        /// Representa el mensaje: La Fecha limite debe ser superior a la de ingreso.
        /// </summary>
        public string ErrorFecha = "La Fecha limite debe ser superior a la de ingreso.";

        /// <summary>
        /// Representa el texto: Debe ingresar el codigo del Proveedor para continuar con el proceso
        /// </summary>
        private const string ProveedorRequerido = "Debe ingresar el codigo del Proveedor para continuar con el proceso.";

        /// <summary>
        /// Representa el texto: El campo Codigo del Articulo es requerido.
        /// </summary>
        private const string CodigoProductoReq = "El campo Codigo del Articulo es requerido.";

        /// <summary>
        /// Representa el texto: El Codigo del Articulo que ingreso tiene formato incorrecto.
        /// </summary>
        private const string CodigoProductoFormato = "El Codigo del Articulo que ingreso tiene formato incorrecto.";

        /// <summary>
        /// Representa el texto: El Codigo del Articulo que ingreso no tiene registros en la base de datos.
        /// </summary>
        private const string CodigoProductoExiste = "El Codigo del Articulo que ingreso no tiene registros en la base de datos.";

        /// <summary>
        /// Representa el texto: El campo Cantidad es requerido.
        /// </summary>
        private const string CantidadReq = "El campo Cantidad es requerido.";

        /// <summary>
        /// Representa el texto: El campo Cantidad tiene formato incorrecto.
        /// </summary>
        private const string CantidadFormato = "El campo Cantidad tiene formato incorrecto.";

        /// <summary>
        /// Representa el texto: El campo Valor Unitario es requerido.
        /// </summary>
        private const string ValorReq = "El campo Valor Unitario es requerido.";

        /// <summary>
        /// Representa el texto: El campo Valor Unitario tiene formato incorrecto. 
        /// </summary>
        private const string ValorFormato = "El campo Valor Unitario tiene formato incorrecto. ";

        /// <summary>
        /// Representa El mensaje. El Número de lote que ingreso tiene formato incorrecto.
        /// </summary>
        private const string LoteFormat = "El Número de lote que ingreso tiene formato incorrecto.";

        #endregion

        #region Utilidades

        /// <summary>
        /// Objeto para hacer uso del Formulario lista de productos.
        /// </summary>
        Inventario.Agrupacion.frmListarProducto listaProducto;

        /// <summary>
        /// Objeto para hacer uso del Formulario de Proveedor.
        /// </summary>
        private Proveedor.frmProveedor formProveedor;

        /// <summary>
        /// Objeto para hacer uso del Formulario de Producto.
        /// </summary>
        Inventario.Producto.FrmIngresarProducto FrmProducto;

        /// <summary>
        /// Representa una pequeña ventana emergente que muestra una breve explicacion de la funcion del control.
        /// </summary>
        private ToolTip miToolTip;

        /// <summary>
        /// Objeto para el acceso al ensamblado de la aplicación.
        /// </summary>
        private System.Reflection.Assembly assembly;

        /// <summary>
        /// Representa el Stream de la Imagen de Medida.
        /// </summary>
        private System.IO.Stream ImgMedidaStream;

        /// <summary>
        /// Representa el Stream de la Imagen de Color.
        /// </summary>
        private System.IO.Stream ImgColorStream;

        /// <summary>
        /// Representa el Stream de la Imagen de Lote.
        /// </summary>
        private System.IO.Stream ImgLoteStream;

        /// <summary>
        /// Representa la ruta del ensamblado de la imagen de color gris de Medida.
        /// </summary>
        private const string ImagenMedida = "Aplicacion.Recursos.Iconos.medidaGris.png";

        /// <summary>
        /// Representa la ruta del ensamblado de la imagen de color gris de Color.
        /// </summary>
        private const string ImagenColor = "Aplicacion.Recursos.Iconos.colorGris.png";

        /// <summary>
        /// Representa la ruta del ensamblado de la imagen de color gris de Lote.
        /// </summary>
        private const string ImagenLote = "Aplicacion.Recursos.Iconos.loteGris.png";

        /// <summary>
        /// Objeto tipo hilo que me premite realiza ejecuciones asincronas y sincrona.
        /// </summary>
        private Thread miThread;

        /// <summary>
        /// Objeto que estructura los datos de un metodo de clase.
        /// </summary>
        private delegate void myDelegate();

        /// <summary>
        /// Objeto que representa el panel de opcion a mostrar.
        /// </summary>
        private OptionPane miOption;

        /// <summary>
        /// Obtiene o establece el valor que indica si el cambio se realizo con exito.
        /// </summary>
        private bool SuccessCambio = false;

        /// <summary>
        /// Obtiene o establece el valor que indica si el guardado se realizo con exito.
        /// </summary>
        private bool SuccessGuardado = false;

        /// <summary>
        /// Representa un objeto para el tratamiento de codigo dinamico del Panel Tributario
        /// </summary>
        private List<PanelTributario> miPanelTributario;

        /// <summary>
        /// Representa una variable para realizar conteo.
        /// </summary>
        private int Contador;

        /// <summary>
        /// Objeto que encapsula el origen de datos del DataGrid de Productos.
        /// </summary>
        private BindingSource miBindingSource;

        #endregion

        private bool CodigoMatch;

        private int IdTipoInventarioProductoNoFabricado = 3;

        private int IdTipoInventarioProductoFabricado = 4;

        public FrmIngresarCompra()
        {
            try
            {
                InitializeComponent();
                CodigoMatch = false;
                IdRubroRetencion = 2;
                EsFactura = true;
                miFactura = new FacturaProveedor();
                miBussinesConsecutivo = new BussinesConsecutivo();
                miBussinesEmpresa = new BussinesEmpresa();
                EnableColor = Convert.ToBoolean(AppConfiguracion.ValorSeccion("color"));
                AplicaRete = false;
                MiRetencion = new RetencionConcepto();
                MiRetencion.Concepto = AppConfiguracion.ValorSeccion("concepto");
                MiRetencion.CifraUVT = Convert.ToDouble(AppConfiguracion.ValorSeccion("uvt"));
                MiRetencion.CifraPesos = Convert.ToInt32(AppConfiguracion.ValorSeccion("pesos"));
                MiRetencion.Tarifa = Convert.ToDouble(AppConfiguracion.ValorSeccion("tasa"));
                RowsCosto = Convert.ToInt32(AppConfiguracion.ValorSeccion("num_promedio"));
                TipoAproxPrecio = Convert.ToBoolean(AppConfiguracion.ValorSeccion("tipo_aprox_precio"));
                _ConsultaInventario = Convert.ToBoolean(AppConfiguracion.ValorSeccion("frm_consulta_inventario"));
                /*BaseRete = Convert.ToInt32(AppConfiguracion.ValorSeccion("base"));
                TasaRete = Convert.ToDouble(AppConfiguracion.ValorSeccion("tasa"));*/
                FechaHoy = DateTime.Today;
                dtpFechaLimite.Value = FechaHoy;
                CargarUsuario();
                IdRegimen = new List<int>();
                miFormaPago = new FormaPago();
                miToolTip = new ToolTip();
                MiError = new ErrorProvider();
                miBussinesEstado = new BussinesEstado();
                miBussinesProveedor = new BussinesProveedor();
                miBussinesProducto = new BussinesProducto();
                miBussinesUsuario = new BussinesUsuario();
                miBussinesFacturaProveedor = new BussinesFacturaProveedor();
                miBussinesMedida = new BussinesValorUnidadMedida();
                miBussinesColor = new BussinesColor();
                miBussinesPuc = new BussinesPuc();
                miBussinesRetencion = new BussinesRetencion();
                miTabla = new DataTable();
                CrearDataTable();
                miTallaYcolor = new TallaYcolor();
                miBindingSource = new BindingSource();
                miPanelTributario = new List<PanelTributario>();
                MiEmpresa = miBussinesEmpresa.ObtenerEmpresa();
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
        }

        private void FrmIngresarCompra_Load(object sender, EventArgs e)
        {
            //lblFechaIngreso.Text = FechaHoy.Day + " de " + UseDate.MesCorto(FechaHoy.Month) + " de " + FechaHoy.Year;
            //cbFormaPago.DataSource = miFormaPago.lista;
            miToolTip.SetToolTip(btnTallaYcolor, "Seleccionar Talla y Color");
            miToolTip.SetToolTip(rbtnDesctoProducto, "Aplicar descuento por Producto.");
            miToolTip.SetToolTip(pbProducto, "Aplicar descuento por Producto.");
            miToolTip.SetToolTip(rbtnDesctoFactura, "Aplicar descuento por Factura.");
            miToolTip.SetToolTip(pbFactura, "Aplicar descuento por Factura.");

            //miToolTip.SetToolTip(btnInfoRete, "Informacion de la retnecion");
            CompletaEventos.Completa += new CompletaEventos.CompletaAccion(CompletaEventos_Completo);
            CompletaEventos.Completam += new CompletaEventos.CompletaAccionm(CompletaEventosm_Completo);
            CompletaEventos.CompletaEditProveedor +=
                new CompletaEventos.CompletaAccionEditProveedor(CompletaEventos_Completo);
            CompletaEventos.CompAxTInvFactProvee +=
                new CompletaEventos.ComAxTransferInvFactProve(CompletaEventos_CompAxTInvFactProvee);
            CompletaEventos.Completabo += new CompletaEventos.CompletaAccionbo(CompletaEventos_Completabo);

            assembly = System.Reflection.Assembly.GetExecutingAssembly();
            CargarRecursos();
            dgvListaArticulos.AutoGenerateColumns = false;
            dgvListaArticulos.DataSource = miBindingSource;
        }

        private void FrmIngresarCompra_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyData)
            {
                case Keys.F2:
                    {
                        this.tsGuardar_Click(this.tsGuardar, new EventArgs());
                        break;
                    }
                case Keys.F3:
                    {
                        this.tsConsultarProducto_Click(this.tsConsultarProducto, new EventArgs());
                        break;
                    }
                 case Keys.F4:
                     {
                         this.tsBtnConsulta_Click(this.tsBtnConsulta, new EventArgs());
                         break;
                     }
                /* case Keys.F5:
                     {
                         txtCodigoArticulo.Focus();
                         break;
                     }
                 case Keys.F6:
                     {
                         this.tsBtnConsulta_Click(this.tsBtnConsulta, new EventArgs());
                         break;
                     }*/
                /* case Keys.F10:
                     {
                         txtUtilidad.Focus();
                         break;
                     }
                 case Keys.F11:
                     {
                         txtPrecioVenta.Focus();
                         break;
                     }*/
                case Keys.F12:
                    {
                        lkbGenerarLote_LinkClicked(null, null);
                        break;
                    }
                case Keys.Escape:
                    {
                        this.Close();
                        break;
                    }
            }
        }

        private void FrmIngresarCompra_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult rta = MessageBox.Show("¿Está seguro(a) de salir?",
                    "Factura proveedor", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (rta.Equals(DialogResult.Yes))
            {
                e.Cancel = false;
            }
            else
            {
                e.Cancel = true;
            }

            /*if (dgvListaArticulos.RowCount != 0)
            {
                DialogResult rta = MessageBox.Show("Está a punto de salir.\n¿Desea guardar los cambios?",
                    "Factura Proveedor", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);
                if (rta.Equals(DialogResult.Yes))
                {
                    e.Cancel = true;
                    tsGuardar_Click(tsGuardar, new EventArgs());
                    CerrarForms();
                    e.Cancel = false;
                }
                else
                {
                    if (rta.Equals(DialogResult.Cancel))
                    {
                        e.Cancel = true;
                    }
                    else
                    {
                        CerrarForms();
                    }
                }
            }
            else
            {
                CerrarForms();
            }*/
        }

        private void tsGuardar_Click(object sender, EventArgs e)
        {
            //var codigoProveedor = ValidarCodigoProveedor();
            //this.txtCodigoProveedor_Validating(this.txtCodigoProveedor, null);
            if (Convert.ToInt32(cbCriterio.SelectedValue).Equals(1)) //código
            {
                if (Validacion.ConFormato
                    (Validacion.TipoValidacion.Numeros, txtCodigoProveedor, MiError, "El código tiene formato incorrecto."))
                {
                    CodigoMatch = true;
                }
                else
                {
                    CodigoMatch = false;
                }
            }
            else    // NIT
            {
                if (Validacion.ConFormato(Validacion.TipoValidacion.NumeroGuion,
                               txtCodigoProveedor, MiError, "El nit que ingreso tiene formato incorrecto."))
                {
                    CodigoMatch = true;
                }
                else
                {
                    CodigoMatch = false;
                }
            }

            txtNumeroFactura_Validating(null, null);
            dtpFechaLimite_Validating(null, null);
            txtDescuento_KeyPress(null, new KeyPressEventArgs((char)Keys.Enter));
            if (txtAjuste.Text.Equals(""))
            {
                txtAjuste.Text = "0";
            }
            if (MiProveedor != null)
            {
                if (miTabla.Rows.Count != 0)
                {
                    if (CodigoMatch && NumFacturaMatch && FechaMatch && DescuentoMatch && AjusteMatch)
                    {
                        DialogResult rta = MessageBox.Show("¿Está seguro(a) de guardar la Factura?", "Factura Proveedor",
                            MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (rta.Equals(DialogResult.Yes))
                        {
                            CargarFactura();
                            KeyProductoPress = true;
                            GuardarFactura();
                            /* miOption = new OptionPane();
                             miOption.FrmProgressBar.barraProgreso.Style = ProgressBarStyle.Marquee;
                             miOption.FrmProgressBar.Closed_ = true;
                             miOption.ProgressShow("Espere mientras se realizan las operaciones necesarias...",
                                 "Operación en progreso");
                             this.Enabled = false;
                             miThread = new Thread(IniciarGuardado);
                             miThread.Start();*/
                        }
                    }
                }
                else
                {
                    OptionPane.MessageError("Debe cargar los Producto a la Factura para guardarla.");
                }
            }
            else
            {
                OptionPane.MessageError("Debe selecionar un Proveedor para la Factura.");
            }
        }

        private void tsConsultarProducto_Click(object sender, EventArgs e)
        {
            if (_ConsultaInventario)
            {
                var formInventario = new Inventario.Consulta.FrmConsultaInventario();
                formInventario.MdiParent = this.MdiParent;
                formInventario.ExtendVenta = true;
                formInventario.IsCompra = true;
                // formInventario.txtCodigoNombre.Text = txtCodigoArticulo.Text;
                FormInventario = true;
                formInventario.Show();
                formInventario.dgvInventario.Focus();
            }
            else
            {
                var formInventario = new Inventario.Consulta.FrmInventario();
                formInventario.MdiParent = this.MdiParent;
                formInventario.ExtendVenta = true;
                formInventario.IsCompra = true;
                formInventario.Show();
                formInventario.dgvInventario.Focus();
            }
        }

        private void tsBtnConsulta_Click(object sender, EventArgs e)
        {
            if (!FormProveedor)
            {
                var formConsulta = new FrmConsulta();
                formConsulta.MdiParent = this.MdiParent;
                FormProveedor = true;
                formConsulta.Show();
            }
        }

        private void tsSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cbCriterio_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtCodigoProveedor.Focus();
        }

        private void txtCodigoProveedor_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (e.KeyChar == (char)Keys.Enter)
                {
                    txtCodigoProveedor_Validating(this.txtCodigoProveedor, new CancelEventArgs(false));
                    //cbRemision.Focus();
                    /*if (ValidarCodigoProveedor())
                    {
                        var codigo = Convert.ToInt32(txtCodigoProveedor.Text);
                        if (miBussinesProveedor.ExisteProveedorConCodigo(codigo))
                        {
                            if (MiProveedor != null)
                            {
                                DialogResult rta = MessageBox.Show("¿Está seguro de querer cambiar el Proveedor?",
                                    "Información", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                                if (rta == DialogResult.Yes)
                                {
                                    MiProveedor = miBussinesProveedor.ConsultarPrveedorBasico(codigo);
                                    KeyProveedorPress = true;
                                    //txtNumeroFactura.Focus();
                                    cbRemision.Focus();
                                    miOption = new OptionPane();
                                    miOption.FrmProgressBar.barraProgreso.Style = ProgressBarStyle.Marquee;
                                    miOption.FrmProgressBar.Closed_ = true;
                                    miOption.ProgressShow("Espere mientras se realizan las operaciones necesarias...",
                                        "Operacion en progreso");
                                    this.Enabled = false;
                                    miThread = new Thread(new ThreadStart(IniciarCambio));
                                    miThread.Start();
                                }
                                else
                                {
                                    txtCodigoProveedor.Text = MiProveedor.CodigoInternoProveedor.ToString();
                                }
                            }
                            else
                            {
                                MiProveedor = miBussinesProveedor.ConsultarPrveedorBasico(codigo);
                                IdRegimen.Add(MiProveedor.IdRegimen);
                                txtNombreProveedor.Text = MiProveedor.CodigoInternoProveedor + " - NIT: " + MiProveedor.NitProveedor
                                    + " - " + MiProveedor.RazonSocialProveedor;
                                MiError.SetError(txtCodigoProveedor, null);
                                KeyProveedorPress = true;
                                //txtNumeroFactura.Focus();
                                ValidarRetencion();
                                cbRemision.Focus();
                            }
                        }
                        else
                        {
                            DialogResult rta = MessageBox.Show("El Proveedor no existe. ¿Desea crearlo?", "Factura Proveedor",
                                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                            if (rta.Equals(DialogResult.Yes))
                            {
                                if (!FormProveedor)
                                {
                                    //txtCodigoProveedor.Focus();
                                    KeyProveedorPress = true;
                                    formProveedor = new Proveedor.frmProveedor();
                                    formProveedor.txtCodigoInterno.Text = txtCodigoProveedor.Text;

                                    formProveedor.Extension = true;
                                    FormProveedor = true;
                                    formProveedor.MdiParent = this.MdiParent;
                                    formProveedor.Show();
                                    formProveedor.txtNitCedula.Focus();
                                    //txtCodigoProveedor.Focus();
                                }
                            }
                            /*OptionPane.MessageInformation(CodigoProveedorExiste);
                            MiError.SetError(txtCodigoProveedor, CodigoProveedorExiste);
                            txtCodigoProveedor.Focus();//
                        }
                    }
                    else
                    {
                        //txtCodigoProveedor.Focus();
                    }*/
                }
                else
                {
                    //KeyProveedorPress = false;
                }
            }
            catch (Exception ex)
            { OptionPane.MessageError(ex.Message); }
        }

        private void txtCodigoProveedor_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                /* if (!KeyProveedorPress)
                 {*/
                //if (ValidarCodigoProveedor())
                //{
                if (Convert.ToInt32(cbCriterio.SelectedValue).Equals(1)) //código
                {
                    if (Validacion.ConFormato
                        (Validacion.TipoValidacion.Numeros, txtCodigoProveedor, MiError, "El código tiene formato incorrecto."))
                    {
                        CodigoMatch = true;
                        CargarProveedorCodigo(txtCodigoProveedor.Text);
                    }
                    else
                    {
                        CodigoMatch = false;
                    }
                }
                else    // NIT
                {
                    if (Validacion.ConFormato(Validacion.TipoValidacion.NumeroGuion,
                                   txtCodigoProveedor, MiError, "El nit que ingreso tiene formato incorrecto."))
                    {
                        CodigoMatch = true;
                        CargarProveedorNit(txtCodigoProveedor.Text);
                    }
                    else
                    {
                        CodigoMatch = false;
                    }
                }


                // var codigo = Convert.ToInt32(txtCodigoProveedor.Text);
                /*if (miBussinesProveedor.ExisteProveedorConNit(txtCodigoProveedor.Text))
                {
                    if (MiProveedor != null)
                    {
                        DialogResult rta = MessageBox.Show("¿Esta seguro que quiere cambiar el Proveedor de la Factura?",
                            "Información", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                        if (rta == DialogResult.Yes)
                        {
                            MiProveedor = miBussinesProveedor.ConsultarPrveedorBasico(txtCodigoProveedor.Text);
                            KeyProveedorPress = true;
                            //txtNumeroFactura.Focus();
                            cbRemision.Focus();
                            miOption = new OptionPane();
                            miOption.FrmProgressBar.barraProgreso.Style = ProgressBarStyle.Marquee;
                            miOption.FrmProgressBar.Closed_ = true;
                            miOption.ProgressShow("Espere mientras se realizan las operaciones necesarias...",
                                "Operacion en progreso");
                            this.Enabled = false;
                            miThread = new Thread(new ThreadStart(IniciarCambio));
                            miThread.Start();
                        }
                        else
                        {
                            txtCodigoProveedor.Text = MiProveedor.CodigoInternoProveedor.ToString();
                        }
                    }
                    else
                    {
                        MiProveedor = miBussinesProveedor.ConsultarPrveedorBasico(txtCodigoProveedor.Text);
                        IdRegimen.Add(MiProveedor.IdRegimen);
                        txtNombreProveedor.Text = MiProveedor.CodigoInternoProveedor + " - NIT: " + MiProveedor.NitProveedor
                                + " - " + MiProveedor.RazonSocialProveedor;
                        MiError.SetError(txtCodigoProveedor, null);
                        KeyProveedorPress = true;
                        //txtNumeroFactura.Focus();
                        ValidarRetencion();
                        cbRemision.Focus();
                    }
                }
                else
                {
                    DialogResult rta = MessageBox.Show("El Proveedor no existe. ¿Desea crearlo?", "Factura Proveedor",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (rta.Equals(DialogResult.Yes))
                    {
                        if (!FormProveedor)
                        {
                            KeyProveedorPress = true;
                            formProveedor = new Proveedor.frmProveedor();
                            formProveedor.txtCodigoInterno.Text = txtCodigoProveedor.Text;
                            formProveedor.Extension = true;
                            FormProveedor = true;
                            formProveedor.MdiParent = this.MdiParent;
                            formProveedor.Show();
                            formProveedor.txtNitCedula.Focus();
                            //txtCodigoProveedor.Focus();
                        }
                    }
                    //OptionPane.MessageInformation(CodigoProveedorExiste);
                    //MiError.SetError(txtCodigoProveedor, CodigoProveedorExiste);
                    //txtCodigoProveedor.Focus();
                }
                */

                //}
                // }
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
        }

        private void btnBuscarProveedor_Click(object sender, EventArgs e)
        {
            if (!FormProveedor)
            {
                formProveedor = new Proveedor.frmProveedor();
                formProveedor.Extension = true;
                formProveedor.tcProveedor.SelectTab(1);
                FormProveedor = true;
                formProveedor.MdiParent = this.MdiParent;
                formProveedor.Show();
                AddProveedor = true;
            }
        }

        private void cbRemision_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (Convert.ToInt32(cbRemision.SelectedValue).Equals(1))
            {
                EsFactura = true;
                lblNumeroFactura.Text = "Número de Factura";
                txtNumeroFactura.ReadOnly = false;
                txtNumeroFactura.Text = "";
                chkIva.Checked = false;
                chkIva.Enabled = true;
            }
            else
            {
                if (Convert.ToInt32(cbRemision.SelectedValue).Equals(2))
                {
                    EsFactura = false;
                    lblNumeroFactura.Text = "Número de Remisión";
                    txtNumeroFactura.ReadOnly = false;
                    txtNumeroFactura.Text = "";
                    chkIva.Checked = false;
                    chkIva.Enabled = true;
                }
                else
                {
                    try
                    {
                        EsFactura = true;
                        lblNumeroFactura.Text = "Número de Documento";
                        txtNumeroFactura.ReadOnly = true;
                        txtNumeroFactura.Text = miBussinesConsecutivo.Consecutivo("Documento"); //AppConfiguracion.ValorSeccion("documento");
                        //chkIva.Checked = true;
                        //chkIva.Enabled = false;
                    }
                    catch (Exception ex)
                    {
                        OptionPane.MessageError(ex.Message);
                    }
                }
            }
        }

        private void cbRemision_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar.Equals((char)Keys.Enter))
            {
                txtNumeroFactura.Focus();
            }
        }

        private void txtNumeroFactura_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                cbFormaPago.Focus();
            }
        }

        private void txtNumeroFactura_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                if (!Validacion.EsVacio(txtNumeroFactura, MiError, FacturaReq))
                {
                    if (MiProveedor != null)
                    {
                        if (miBussinesFacturaProveedor.ExisteNumeroFactura(MiProveedor.CodigoInternoProveedor, txtNumeroFactura.Text))
                        {
                            MiError.SetError(txtNumeroFactura, "EL numero de factura ya existe en las compras de proveedor.");
                            NumFacturaMatch = false;
                        }
                        else
                        {
                            MiError.SetError(txtNumeroFactura, "");
                            NumFacturaMatch = true;
                        }
                    }
                    else
                    {
                        NumFacturaMatch = false;
                    }
                }
                else
                {
                    NumFacturaMatch = false;
                }
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
        }

        private void cbFormaPago_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                dtpFechaLimite.Focus();
            }
        }

        private void cbFormaPago_SelectionChangeCommitted(object sender, EventArgs e)
        {
            dtpFechaLimite.Value = FechaHoy;
        }

        private void dtpFechaLimite_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                txtCodigoArticulo.Focus();
            }
        }

        private void dtpFechaLimite_Validating(object sender, CancelEventArgs e)
        {
            var id = (int)cbFormaPago.SelectedValue;
            if (id == 2)
            {
                if (dtpFechaLimite.Value <= this.dtpFecha.Value)
                {
                    MiError.SetError(dtpFechaLimite, ErrorFecha);
                    FechaMatch = false;
                }
                else
                {
                    MiError.SetError(dtpFechaLimite, null);
                    FechaMatch = true;
                }
            }
            else
            {
                MiError.SetError(dtpFechaLimite, null);
                FechaMatch = true;
            }
        }

        private void rbtnDesctoProducto_Click(object sender, EventArgs e)
        {
            if (dgvListaArticulos.RowCount != 0 && !DesctoProducto)
            {
                DialogResult rta = MessageBox.Show("¿Está seguro que quiere aplicar Descuento por Producto?",
                    "Factura Proveedor", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (rta.Equals(DialogResult.Yes))
                {
                    txtDescuentoFactura.Enabled = false;
                    txtDescuentoProducto.Enabled = true;
                    DesctoProducto = true;
                    txtDescuento.Text = "0";
                    txtDescuentoProducto.Text = "0";
                    txtDescuentoFactura.Text = "0";
                    CambiarDescuento();
                    OptionPane.MessageInformation("Debe editar el descuento de cada registro de Producto de la Factura.");
                }
                else
                {
                    rbtnDesctoFactura.Checked = true;
                    txtDescuentoFactura.Enabled = true;
                    txtDescuentoProducto.Enabled = false;
                }
            }
            else
            {
                DesctoProducto = true;
                txtDescuentoFactura.Enabled = false;
                txtDescuentoProducto.Enabled = true;
                txtDescuento.Text = "0";
                txtDescuentoProducto.Text = "0";
                txtDescuentoFactura.Text = "0";
            }
        }

        private void rbtnDesctoFactura_Click(object sender, EventArgs e)
        {
            if (dgvListaArticulos.RowCount != 0 && DesctoProducto)
            {
                DialogResult rta = MessageBox.Show("¿Está seguro que quiere aplicar Descuento por Factura?",
                    "Factura Proveedor", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (rta.Equals(DialogResult.Yes))
                {
                    txtDescuentoFactura.Enabled = true;
                    txtDescuentoProducto.Enabled = false;
                    DesctoProducto = false;
                    txtDescuentoFactura.Focus();
                }
                else
                {
                    rbtnDesctoProducto.Checked = true;
                    txtDescuentoFactura.Enabled = false;
                    txtDescuentoProducto.Enabled = true;
                }
            }
            else
            {
                DesctoProducto = false;
                txtDescuentoFactura.Enabled = true;
                txtDescuentoProducto.Enabled = false;
                txtDescuento.Text = "0";
                txtDescuentoProducto.Text = "0";
            }
        }

        private void txtDescuentoFactura_Click(object sender, EventArgs e)
        {
            txtDescuentoFactura.SelectAll();
        }

        private void txtDescuentoFactura_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                if (!String.IsNullOrEmpty(txtDescuentoFactura.Text))
                {
                    //if (Validacion.ConFormato(Validacion.TipoValidacion.NumerosYPunto, txtDescuentoFactura,
                    //    MiError, "El valor del Descuento que ingreso tiene formato incorrecto."))
                    if (ValidarDouble(this.txtDescuentoFactura.Text))
                    {
                        if (Convert.ToDouble(txtDescuentoFactura.Text.Replace('.', ',')) > 100)
                        {
                            MiError.SetError(txtDescuentoFactura, "El porcentaje de descuento no puede ser superior al 100%.");
                            //DescuentoMatch = false;
                            DesctoProductoMatch = false;
                        }
                        else
                        {
                            MiError.SetError(txtDescuentoFactura, null);
                            //DescuentoMatch = true;
                            DesctoProductoMatch = true;
                            if (dgvListaArticulos.RowCount != 0)
                            {
                                CambiarDescuento();
                            }
                        }
                    }
                    else
                    {
                        MiError.SetError(txtDescuentoFactura, "El valor es incorrecto.");
                        DesctoProductoMatch = false;
                    }
                }
                else
                {
                    txtDescuentoFactura.Text = "0";
                    //DescuentoMatch = true;
                    DesctoProductoMatch = true;
                }
                /*if (!String.IsNullOrEmpty(txtDescuentoFactura.Text))
                {
                    if (Validacion.ConFormato(Validacion.TipoValidacion.NumerosYPunto, txtDescuentoFactura,
                        MiError, "El valor del Descuento que ingreso tiene formato incorrecto."))
                    {
                        if (Convert.ToDouble(txtDescuentoFactura.Text.Replace('.', ',')) > 100)
                        {
                            MiError.SetError(txtDescuentoFactura, "El porcentaje de descuento no puede ser superior al 100%.");
                            DescuentoMatch = false;
                        }
                        else
                        {
                            MiError.SetError(txtDescuentoFactura, null);
                            DescuentoMatch = true;
                            if (dgvListaArticulos.RowCount != 0)
                            {
                                CambiarDescuento();
                            }
                        }
                    }
                }
                else
                {
                    txtDescuentoFactura.Text = "0";
                    DescuentoMatch = true;
                }*/
            }
        }

        private void txtDescuentoFactura_Validating(object sender, CancelEventArgs e)
        {
            txtDescuentoFactura_KeyPress(null, new KeyPressEventArgs((char)Keys.Enter));
        }

        private void txtCodigoArticulo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                if (MiProveedor != null)
                {
                    if (!String.IsNullOrEmpty(this.txtCodigoArticulo.Text))
                    {
                        if (CodigoOrString(txtCodigoArticulo.Text))
                        {
                            if (ValidarCodigo() || ValidarCodigoBarras())
                            {
                                if (ExisteProducto(txtCodigoArticulo.Text))
                                {
                                    MiError.SetError(txtCodigoProveedor, null);
                                    CargarProducto(txtCodigoArticulo.Text);
                                    MiError.SetError(txtCodigoArticulo, null);
                                    KeyProductoPress = true;
                                    txtCantidad.Focus();
                                }
                                else
                                {
                                    //MiError.SetError(txtCodigoProveedor, ProveedorRequerido);
                                    //OptionPane.MessageInformation(CodigoProductoExiste);
                                    MiError.SetError(txtCodigoArticulo, CodigoProductoExiste);
                                    txtCodigoArticulo.Focus();
                                }
                            }
                            else
                            {
                                txtCodigoArticulo.Focus();
                            }
                        }
                        else
                        {
                            if (!FormInventario)
                            {
                                if (_ConsultaInventario)
                                {
                                    var formInventario = new Inventario.Consulta.FrmConsultaInventario();
                                    formInventario.MdiParent = this.MdiParent;
                                    formInventario.ExtendVenta = true;
                                    formInventario.IsCompra = true;

                                    formInventario.IdTipoInventarioNoFabricado = IdTipoInventarioProductoNoFabricado;
                                    formInventario.IdTipoInventarioFabricado = IdTipoInventarioProductoFabricado;

                                    formInventario.txtCodigoNombre.Text = txtCodigoArticulo.Text;
                                    FormInventario = true;
                                    formInventario.Show();
                                    formInventario.dgvInventario.Focus();
                                }
                                else
                                {
                                    var formInventario = new Inventario.Consulta.FrmInventario();
                                    formInventario.MdiParent = this.MdiParent;
                                    formInventario.ExtendVenta = true;
                                    formInventario.IsCompra = true;

                                    formInventario.txtCodigoNombre.Text = txtCodigoArticulo.Text;
                                    FormInventario = true;
                                    formInventario.Show();
                                    formInventario.dgvInventario.Focus();
                                }
                            }
                        }
                    }
                }
                else
                {
                    MiError.SetError(txtCodigoProveedor, ProveedorRequerido);
                    //OptionPane.MessageInformation(ProveedorRequerido);
                    KeyProductoPress = true;
                    txtCodigoProveedor.Focus();
                    txtCodigoArticulo.Text = "";
                }
            }
            else
            {
                KeyProductoPress = false;
            }
        }

        private void txtCodigoArticulo_Validating(object sender, CancelEventArgs e)
        {
            /*if (!KeyProductoPress)
            {
                if (MiProveedor != null)
                {
                    if (ValidarCodigo() || ValidarCodigoBarras())
                    {
                        if (ExisteProducto(txtCodigoArticulo.Text))
                        {
                            CargarProducto(txtCodigoArticulo.Text);
                            MiError.SetError(txtCodigoArticulo, null);
                            txtCantidad.Focus();
                        }
                        else
                        {
                            OptionPane.MessageError(CodigoProductoExiste);
                            MiError.SetError(txtCodigoArticulo, CodigoProductoExiste);
                            txtCodigoArticulo.Focus();
                        }
                    }
                    else
                    {
                        txtCodigoArticulo.Focus();
                    }
                }
                else
                {
                    OptionPane.MessageInformation(ProveedorRequerido);
                    txtCodigoProveedor.Focus();
                    txtCodigoArticulo.Text = "";
                }
            }*/
        }

        private void btnBuscarArticulo_Click(object sender, EventArgs e)
        {
            if (!FormInventario)
            {
                var formInventario = new Inventario.Consulta.FrmConsultaInventario();
                formInventario.MdiParent = this.MdiParent;
                formInventario.ExtendVenta = true;
                formInventario.IsCompra = true;
                formInventario.txtCodigoNombre.Text = txtCodigoArticulo.Text;
                FormInventario = true;
                formInventario.Show();
                formInventario.dgvInventario.Focus();
            }
            /*if (!FormProducto)
            {
                FrmProducto = new Inventario.Producto.FrmIngresarProducto();
                FrmProducto.MdiParent = this.MdiParent;
                FrmProducto.Extencion = true;
                FrmProducto.Edit = true;
                FormProducto = true;
                FrmProducto.tabControlProducto.SelectTab(1);
                FrmProducto.Show();
            }*/
        }

        private void txtCantidad_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                txtValorUnitario.Focus();
            }
        }

        private void txtCantidad_Validating(object sender, CancelEventArgs e)
        {
            if (!Validacion.EsVacio(txtCantidad, MiError, CantidadReq))
            {
                if (Validacion.ConFormato(Validacion.TipoValidacion.NumerosYPunto,
                    txtCantidad, MiError, CantidadFormato))
                {
                    CantidadMatch = true;
                }
                else
                    CantidadMatch = false;
            }
            else
                CantidadMatch = false;
        }

        private void txtValorUnitario_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                if (txtDescuentoProducto.Enabled)
                {
                    txtDescuentoProducto.Focus();
                }
                else
                {
                    txtLote.Focus();
                }
            }
        }

        private void txtValorUnitario_Validating(object sender, CancelEventArgs e)
        {
            if (!Validacion.EsVacio(txtValorUnitario, MiError, ValorFormato))
            {
                if (Validacion.ConFormato(Validacion.TipoValidacion.NumerosYPunto,
                    txtValorUnitario, MiError, ValorFormato))
                {
                    ValorMatch = true;
                }
                else
                    ValorMatch = true;
            }
            else
                ValorMatch = false;
        }

        private void txtDescuentoProducto_Click(object sender, EventArgs e)
        {
            txtDescuentoProducto.SelectAll();
        }

        private void txtDescuentoProducto_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                if (!String.IsNullOrEmpty(txtDescuentoProducto.Text))
                {
                    if (Validacion.ConFormato(Validacion.TipoValidacion.NumerosYPunto, txtDescuentoProducto,
                        MiError, "El valor del Descuento que ingreso tiene formato incorrecto."))
                    {

                        if (Convert.ToDouble(txtDescuentoProducto.Text.Replace('.', ',')) > 100)
                        {
                            MiError.SetError(txtDescuentoProducto, "El porcentaje de descuento no puede ser superior al 100%.");
                            DesctoProductoMatch = false;
                        }
                        else
                        {
                            MiError.SetError(txtDescuentoProducto, null);
                            DesctoProductoMatch = true;
                            txtLote.Focus();
                        }
                    }
                }
                else
                {
                    txtDescuentoProducto.Text = "0";
                    DesctoProductoMatch = true;
                    txtLote.Focus();
                }
            }
        }

        private void txtDescuentoProducto_Validating(object sender, CancelEventArgs e)
        {
            txtDescuentoProducto_KeyPress(null, new KeyPressEventArgs((char)Keys.Enter));
        }

        private void txtLote_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                if (btnTallaYcolor.Enabled)
                {
                    btnTallaYcolor.Focus();
                }
                else
                {
                    btnAgregar.Focus();
                }
            }
        }

        private void txtLote_Validating(object sender, CancelEventArgs e)
        {
            if (!String.IsNullOrEmpty(txtLote.Text))
            {
                if (Validacion.ConFormato(Validacion.TipoValidacion.LetrasGuionNumeros,
                    txtLote, MiError, LoteFormat))
                {
                    LoteMatch = true;
                }
                else
                    LoteMatch = false;
            }
            else
                LoteMatch = true;
        }

        private void lkbGenerarLote_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            txtLote.Text = LoteConsecutivo.ToString();
            txtLote_KeyPress(txtLote, new KeyPressEventArgs((char)Keys.Enter));
        }

        private void btnTallaYcolor_Click(object sender, EventArgs e)
        {
            if (!FormProveedor)
            {
                if (MiProducto != null)
                {
                    if (MiProducto.AplicaTalla || MiProducto.AplicaColor)
                    {
                        FormProveedor = true;
                        listaProducto = new Inventario.Agrupacion.frmListarProducto();
                        listaProducto.MdiParent = this.MdiParent;
                        listaProducto.CargarProducto(MiProducto.CodigoInternoProducto);
                        AddColor = true;
                        listaProducto.Show();
                    }
                }
                else
                {
                    OptionPane.MessageInformation("Debe selecciona un Articulo primero.");
                }
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            txtCantidad_Validating(null, null);
            txtValorUnitario_Validating(null, null);
            txtLote_Validating(null, null);
            if (ArrayProducto != null && CantidadMatch && ValorMatch && LoteMatch && DesctoProductoMatch)
            {
                if (!String.IsNullOrEmpty(txtLote.Text))
                {
                    Lote = txtLote.Text;
                }
                else
                {
                    Lote = MiProducto.CodigoInternoProducto + "-" + CambiarSeparadorFecha(FechaHoy.ToShortDateString());
                }
                if ((MiProducto.AplicaTalla && miTallaYcolor.IdTalla == 0) ||
                   (MiProducto.AplicaColor && miTallaYcolor.IdColor == 0))
                {
                    LoadColorSize = true;
                    btnTallaYcolor_Click(this.btnTallaYcolor, null);
                    return;
                }
                else
                {
                    LoadColorSize = false;
                    EstructurarConsulta2();
                }
            }
        }

        private void btnInfoCosto_MouseMove(object sender, MouseEventArgs e)
        {
            PanelRegistro.Visible = true;
        }

        private void btnInfoCosto_MouseLeave(object sender, EventArgs e)
        {
            PanelRegistro.Visible = false;
        }

        Validacion validacion = new Validacion();
        private bool UtilidadMatch = false;
        private bool PrecioMatch = false;

        private void txtUtilidad_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                var utilidad = txtUtilidad.Text.Replace(',', '.');
                if (String.IsNullOrEmpty(utilidad))
                {
                    utilidad = "0";
                }
                if (!String.IsNullOrEmpty(utilidad))/*txtUtilidad.Text))*/
                {
                    if (validacion.ValidarNumeroDecima(utilidad))
                    {
                        MiError.SetError(txtUtilidad, null);
                        UtilidadMatch = true;
                        var producto = miBussinesProducto.ProductoCompleto
                                    (dgvListaArticulos.CurrentRow.Cells["Codigo"].Value.ToString());
                        var precioUtil = 0.0;
                        var precioSug = 0;
                        var costo = UseObject.RemoveSeparatorMil(txtCosto.Text);
                        
                        /*if (MiEmpresa.Regimen.IdRegimen.Equals(1))//  Regimen   (Comun)                                                          (1)
                        {
                            if (Convert.ToBoolean(AppConfiguracion.ValorSeccion("costoIva")))//  Precio de Costo                                   (2)
                            {
                                valorCosto = Convert.ToInt32((valorCosto / (1 + (producto.ValorIva / 100))));
                            }
                        }
                        else
                        {
                            if (!Convert.ToBoolean(AppConfiguracion.ValorSeccion("costoIva")))//  Precio de Costo                                   (2)
                            {
                                valorCosto = Convert.ToInt32(valorCosto + (valorCosto * producto.ValorIva / 100));
                            }
                        }*/

                        if (MiEmpresa.Regimen.IdRegimen.Equals(1))//  Regimen   (Comun)                                                          (1)
                        {
                            //costo = Convert.ToInt32(UseObject.RemoveSeparatorMil(txtCosto.Text) / (1 + (producto.ValorIva / 100)));
                            if (Convert.ToBoolean(AppConfiguracion.ValorSeccion("costoIva")))//  Precio de Costo                                   (2)
                            {
                                costo = Convert.ToInt32((costo / (1 + (producto.ValorIva / 100))));
                            }
                        }
                        else
                        {
                           // costo = Convert.ToInt32(UseObject.RemoveSeparatorMil(txtCosto.Text));
                            if (!Convert.ToBoolean(AppConfiguracion.ValorSeccion("costoIva")))//  Precio de Costo                                   (2)
                            {
                                costo = Convert.ToInt32(costo + (costo * producto.ValorIva / 100));
                            }
                        }

                        if (!Convert.ToBoolean(AppConfiguracion.ValorSeccion("utilidad_mas_iva")))   // Utilidad antes de IVA.                       (3)
                        {
                            if (Convert.ToBoolean(AppConfiguracion.ValorSeccion("calculo_util_multiplica"))) // Incremento de Utilidad         (4)
                            {
                                precioUtil = costo + (costo * Convert.ToDouble(utilidad.Replace('.', ',')) / 100);
                            }
                            else
                            {
                                precioUtil = costo / ((100 - Convert.ToDouble(utilidad.Replace('.', ','))) / 100);
                            }
                            if (MiEmpresa.Regimen.IdRegimen.Equals(1))//  Regimen                                                                (1)
                            {
                                precioSug = Convert.ToInt32(precioUtil + (precioUtil * producto.ValorIva / 100));
                            }
                            else
                            {
                                precioSug = Convert.ToInt32(precioUtil);
                            }
                        }
                        else   // Utilidad despues de IVA. 
                        {
                            if (MiEmpresa.Regimen.IdRegimen.Equals(1))//  Regimen                                                                (1)
                            {
                                precioUtil = costo + (costo * producto.ValorIva / 100);
                            }
                            else
                            {
                                precioUtil = costo;
                            }
                            if (Convert.ToBoolean(AppConfiguracion.ValorSeccion("calculo_util_multiplica"))) // Incremento de Utilidad         (4)
                            {
                                precioSug = Convert.ToInt32(
                                            precioUtil + (precioUtil * Convert.ToDouble(utilidad.Replace('.', ',')) / 100));
                            }
                            else
                            {
                                precioSug = Convert.ToInt32(
                                            precioUtil / ((100 - Convert.ToDouble(utilidad.Replace('.', ','))) / 100));
                            }
                        }

                        txtPrecioSugerido.Text = UseObject.InsertSeparatorMil(Convert.ToInt32(precioSug).ToString());
                        txtPrecioAprox.Text = UseObject.Aproximar(precioSug,
                                                        Convert.ToBoolean(AppConfiguracion.ValorSeccion("tipo_aprox_precio"))).ToString();

                        //costo = Convert.ToInt32((Convert.ToInt32(costo) / (1 + (valorIva / 100)))).ToString();

                        /*if (Convert.ToBoolean(AppConfiguracion.ValorSeccion("calculo_util_multiplica")))
                        {
                            precioUtil = UseObject.RemoveSeparatorMil(txtCosto.Text) +
                                         (UseObject.RemoveSeparatorMil(txtCosto.Text) * Convert.ToDouble(utilidad.Replace('.', ',')) / 100);
                        }
                        else
                        {
                            precioUtil = UseObject.RemoveSeparatorMil(txtCosto.Text) / ((100 -
                                                    Convert.ToDouble(utilidad.Replace('.', ','))) / 100);
                        }

                        var precioSug = Convert.ToInt32(precioUtil + (precioUtil * producto.ValorIva / 100));

                        txtPrecioSugerido.Text = UseObject.InsertSeparatorMil(Convert.ToInt32(precioSug).ToString());

                        char[] precioChar = precioSug.ToString().ToCharArray();
                        var precioAprox = 0;

                        if (TipoAproxPrecio) //Aprox centena
                        {
                            var digito = Convert.ToInt32(precioChar[precioChar.Length - 2].ToString()
                                                        + precioChar[precioChar.Length - 1].ToString());
                            if (digito > 50)
                            {
                                precioAprox = precioSug + (100 - digito);
                            }
                            else
                            {
                                precioAprox = precioSug - digito;
                            }
                        }
                        else  //aprox decena
                        {
                            if (Convert.ToInt32(precioChar[precioChar.Length - 1].ToString()) > 5)
                            {
                                precioAprox = precioSug + (10 - Convert.ToInt32(precioChar[precioChar.Length - 1].ToString()));
                            }
                            else
                            {
                                precioAprox = precioSug - Convert.ToInt32(precioChar[precioChar.Length - 1].ToString());
                            }
                        }
                        txtPrecioAprox.Text = UseObject.InsertSeparatorMil(precioAprox.ToString());*/
                    }
                    else
                    {
                        MiError.SetError(txtUtilidad, "El valor que ingreso es incorrecto.\n");
                        UtilidadMatch = false;
                    }
                }
                else
                {
                    txtPrecioSugerido.Text = txtCosto.Text;
                }
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
        }

        private void txtPrecioVenta_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                var venta = UseObject.RemoveSeparatorMil(txtPrecioVenta.Text).ToString();
                if (String.IsNullOrEmpty(venta))
                {
                    venta = "0";
                }
                else
                {
                    if (validacion.ValidarNumeroInt(venta))
                    {
                        MiError.SetError(txtPrecioVenta, null);
                        PrecioMatch = true;
                        var producto = miBussinesProducto.ProductoCompleto
                            (dgvListaArticulos.CurrentRow.Cells["Codigo"].Value.ToString());

                        var valorVenta = Convert.ToInt32(venta);
                        var valorCosto = Convert.ToInt32(UseObject.RemoveSeparatorMil(txtCosto.Text));
                        var util = 0.0;

                        if (MiEmpresa.Regimen.IdRegimen.Equals(1))//  Regimen   (Comun)                                                          (1)
                        {
                            if (Convert.ToBoolean(AppConfiguracion.ValorSeccion("costoIva")))//  Precio de Costo                                   (2)
                            {
                                valorCosto = Convert.ToInt32((valorCosto / (1 + (producto.ValorIva / 100))));
                            }
                        }
                        else
                        {
                            if (!Convert.ToBoolean(AppConfiguracion.ValorSeccion("costoIva")))//  Precio de Costo                                   (2)
                            {
                                valorCosto = Convert.ToInt32(valorCosto + (valorCosto * producto.ValorIva / 100));
                            }
                        }

                        if (!Convert.ToBoolean(AppConfiguracion.ValorSeccion("utilidad_mas_iva")))   // Utilidad antes de IVA.                       (3)
                        {
                            // Retiro el IVA del precio de venta.
                            if (MiEmpresa.Regimen.IdRegimen.Equals(1))//  Regimen   (Comun)                                                          (1)
                            {
                                valorVenta = Convert.ToInt32((valorVenta / (1 + (producto.ValorIva / 100))));
                            }
                        }
                        else     // Utilidad despues de IVA.
                        {
                            if (MiEmpresa.Regimen.IdRegimen.Equals(1))//  Regimen   (Comun)                                                          (1)
                            {
                                valorCosto = Convert.ToInt32((valorCosto / (1 + (producto.ValorIva / 100))));
                            }
                        }

                        // Incremento de la Utilidad.
                        if (Convert.ToBoolean(AppConfiguracion.ValorSeccion("calculo_util_multiplica"))) // Incremento de Utilidad         (4)
                        {
                            // Costo x Util
                            util = Math.Round(Convert.ToDouble(((valorVenta - valorCosto) * 100) / valorCosto), 3);
                        }
                        else
                        {
                            var div = Math.Round(Convert.ToDouble(valorCosto) / Convert.ToDouble(valorVenta), 3);
                            util = 100 - (div * 100);
                        }

                        txtUtilidad.Text = Math.Round(util, 1).ToString();
                        txtPrecioVenta.Text = UseObject.InsertSeparatorMil(venta);
                        txtPrecioSugerido.Text = txtPrecioVenta.Text;
                        txtPrecioAprox.Text = UseObject.InsertSeparatorMil(
                            UseObject.Aproximar(Convert.ToInt32(venta),
                            Convert.ToBoolean(AppConfiguracion.ValorSeccion("tipo_aprox_precio"))).ToString());


                        /*txtPrecioVenta.Text = UseObject.InsertSeparatorMil(venta);
                        txtPrecioSugerido.Text = txtPrecioVenta.Text;
                        txtPrecioAprox.Text = UseObject.InsertSeparatorMil(precioAprox.ToString());*/

                        //var precioVenta = Convert.ToInt32(/*UseObject.RemoveSeparatorMil(*/venta)/*)*/;
                        /*var precioCosto = Convert.ToInt32(UseObject.RemoveSeparatorMil(txtCosto.Text));
                        var pVentaNoIva = Convert.ToInt32(precioVenta / (1 + (producto.ValorIva / 100)));

                        var utili = 0.0;
                        if (Convert.ToBoolean(AppConfiguracion.ValorSeccion("calculo_util_multiplica"))) //multiplica la utilidad
                        {
                            utili = Math.Round(Convert.ToDouble(((pVentaNoIva - precioCosto) * 100) / precioCosto), 2);
                        }
                        else  //divide la utilidad
                        {
                            var div = Math.Round(Convert.ToDouble(precioCosto) / Convert.ToDouble(pVentaNoIva), 2);
                            utili = 100 - (div * 100);
                        }
                        //utili = Math.Round(Convert.ToDouble(((pVentaNoIva - precioCosto) * 100) / precioCosto), 2);
                        txtUtilidad.Text = utili.ToString();

                        // txtPrecioSugerido.Text = txtPrecioVenta.Text;

                        var precioSug = Convert.ToInt32(venta);
                        char[] precioChar = precioSug.ToString().ToCharArray();
                        var precioAprox = 0;

                        if (precioChar.Length > 1)
                        {
                            if (TipoAproxPrecio) //Aprox centena
                            {
                                var digito = Convert.ToInt32(precioChar[precioChar.Length - 2].ToString()
                                                            + precioChar[precioChar.Length - 1].ToString());
                                if (digito > 50)
                                {
                                    precioAprox = precioSug + (100 - digito);
                                }
                                else
                                {
                                    precioAprox = precioSug - digito;
                                }
                            }
                            else  //aprox decena
                            {
                                if (Convert.ToInt32(precioChar[precioChar.Length - 1].ToString()) > 5)
                                {
                                    precioAprox = precioSug + (10 - Convert.ToInt32(precioChar[precioChar.Length - 1].ToString()));
                                }
                                else
                                {
                                    precioAprox = precioSug - Convert.ToInt32(precioChar[precioChar.Length - 1].ToString());
                                }
                            }
                        }
                        txtPrecioVenta.Text = UseObject.InsertSeparatorMil(venta);
                        txtPrecioSugerido.Text = txtPrecioVenta.Text;
                        txtPrecioAprox.Text = UseObject.InsertSeparatorMil(precioAprox.ToString());
                        */


                        /*var precioUtil = UseObject.RemoveSeparatorMil(txtCosto.Text) +
                                         (UseObject.RemoveSeparatorMil(txtCosto.Text) * Convert.ToDouble(txtUtilidad.Text.Replace('.', ',')) / 100);
                        var precioSug = precioUtil + (precioUtil * producto.ValorIva / 100);
                        txtPrecioSugerido.Text = UseObject.InsertSeparatorMil(Convert.ToInt32(precioSug).ToString());*/
                    }
                    else
                    {
                        MiError.SetError(txtPrecioVenta, "El valor que ingreso es incorrecto.");
                        PrecioMatch = false;
                    }
                }
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
        }

        private void txtPrecioVenta_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar.Equals((char)Keys.Enter))
            {
                txtPrecioVenta_KeyUp(this.txtPrecioVenta, null);
                btnActualizar.Focus();
            }
        }

        private int CostoProducto { set; get; }
        private bool AplicaPorcentaje { set; get; }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            if (dgvListaArticulos.RowCount != 0)
            {
                txtUtilidad_KeyUp(this.txtUtilidad, null);
                if (String.IsNullOrEmpty(txtPrecioVenta.Text))
                {
                    MiError.SetError(txtPrecioVenta, "El campo es requerido.");
                    PrecioMatch = false;
                }
                else
                {
                    MiError.SetError(txtPrecioVenta, null);
                    if (validacion.ValidarNumeroInt(UseObject.RemoveSeparatorMil(txtPrecioVenta.Text).ToString()))
                    {
                        MiError.SetError(txtPrecioVenta, null);
                        PrecioMatch = true;
                    }
                    else
                    {
                        MiError.SetError(txtPrecioVenta, "El valor que ingreso es invalido.");
                        PrecioMatch = false;
                    }
                }

                if (UtilidadMatch && PrecioMatch)
                {
                    var utilSave = UseObject.RemoveSeparatorMil(lblVUtilidad.Text);
                    var precioVentaSave = Convert.ToInt32(UseObject.RemoveSeparatorMil(lblValorVenta.Text));
                    DialogResult rta;
                    if (Convert.ToBoolean(AppConfiguracion.ValorSeccion("pregunta_act_util")))
                    {
                        rta = MessageBox.Show("¿Está seguro(a) de actualizar la utilidad?", "Ingresar Compra",
                                   MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (rta.Equals(DialogResult.Yes))
                        {
                            utilSave = Convert.ToDouble(txtUtilidad.Text.Replace('.', ','));
                        }
                    }
                    else
                    {
                        utilSave = Convert.ToDouble(txtUtilidad.Text.Replace('.', ','));
                    }
                    if (Convert.ToBoolean(AppConfiguracion.ValorSeccion("pregunta_act_pventa")))
                    {
                        rta = MessageBox.Show("¿Está seguro(a) de actualizar el precio de venta?", "Ingresar Compra",
                                   MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (rta.Equals(DialogResult.Yes))
                        {
                            precioVentaSave = Convert.ToInt32(UseObject.RemoveSeparatorMil(txtPrecioVenta.Text));
                        }
                    }
                    else
                    {
                        precioVentaSave = Convert.ToInt32(UseObject.RemoveSeparatorMil(txtPrecioVenta.Text));
                    }
                    double iva = Convert.ToDouble(UseObject.RemoveCharacter(this.dgvListaArticulos.CurrentRow.Cells["Iva"].Value.ToString(), '%'));
                    int costo = 0;
                    if (Convert.ToBoolean(AppConfiguracion.ValorSeccion("costoIva")))//  Precio de Costo                                   
                    {
                        costo = Convert.ToInt32(
                        Convert.ToInt32(UseObject.RemoveSeparatorMil(txtCosto.Text)) / (1 + (iva / 100)));
                    }
                    else
                    {
                        costo = Convert.ToInt32(Convert.ToInt32(UseObject.RemoveSeparatorMil(txtCosto.Text)));
                    }

                    try
                    {
                        miBussinesProducto.EditarUtilidadVenta
                            (dgvListaArticulos.CurrentRow.Cells["Codigo"].Value.ToString(),
                            utilSave,
                            precioVentaSave,
                            costo);//Convert.ToInt32(UseObject.RemoveSeparatorMil(txtCosto.Text)));
                        OptionPane.MessageInformation("La información del producto se ha almacenado correctamente.");
                        txtCodigoArticulo.Focus();
                    }
                    catch (Exception ex)
                    {
                        OptionPane.MessageError(ex.Message);
                    }
                    /* DialogResult rta = MessageBox.Show("¿Está seguro(a) de actualizar el precio?", "Ingresar Compra",
                     MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                     if (rta.Equals(DialogResult.Yes))
                     {
                         try
                         {
                             miBussinesProducto.EditarUtilidadVenta
                                 (dgvListaArticulos.CurrentRow.Cells["Codigo"].Value.ToString(),
                                 Convert.ToDouble(txtUtilidad.Text.Replace('.', ',')),
                                 Convert.ToInt32(UseObject.RemoveSeparatorMil(txtPrecioVenta.Text)),
                                 Convert.ToInt32(UseObject.RemoveSeparatorMil(txtCosto.Text)));
                             OptionPane.MessageInformation("La información del producto se ha almacenado correctamente.");
                             txtCodigoArticulo.Focus();
                         }
                         catch (Exception ex)
                         {
                             OptionPane.MessageError(ex.Message);
                         }
                     }*/
                }
            }
            else
            {
                OptionPane.MessageInformation("Debe cargar algun registro para actualizar.");
            }
        }

        private void dgvListaArticulos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dgvListaArticulos.RowCount != 0)
                {

                    /*

                    var tRegistro = new DataTable();
                    tRegistro.Columns.Add(new DataColumn("Fecha", typeof(DateTime)));
                    tRegistro.Columns.Add(new DataColumn("Codigo", typeof(string)));
                    tRegistro.Columns.Add(new DataColumn("Cantidad", typeof(double)));
                    tRegistro.Columns.Add(new DataColumn("Valor", typeof(int)));
                    tRegistro.Columns.Add(new DataColumn("Total", typeof(int)));

                    var registro = dgvListaArticulos.Rows[dgvListaArticulos.CurrentCell.RowIndex];
                    var inventario = new DTO.Clases.Inventario
                    {
                        CodigoProducto = registro.Cells["Codigo"].Value.ToString(),
                        IdMedida = Convert.ToInt32(registro.Cells["IdMedida"].Value),
                        IdColor = Convert.ToInt32(registro.Cells["IdColor"].Value),
                        Cantidad = Convert.ToInt32(registro.Cells["Cantidad"].Value)
                    };
                    IEnumerable<DataRow> row = miTabla.AsEnumerable().
                                            Where(p => p.Field<string>("Codigo").Equals(inventario.CodigoProducto)
                                                    && p.Field<int>("IdMedida").Equals(inventario.IdMedida)
                                                    && p.Field<int>("IdColor").Equals(inventario.IdColor));
                    var countRows = row.ToArray().Length;
                    if (countRows < RowsCosto)  //  RowGrid  < RowConfig
                    {
                        inventario.Cantidad = RowsCosto - countRows;
                    }
                    else
                    {
                        inventario.Cantidad = 0;
                        if (!countRows.Equals(RowsCosto)) // RowGrid  > RowConfig
                        {
                            row = from data in miTabla.AsEnumerable().
                                                         OrderByDescending(p => p.Field<int>("Id")).Take(RowsCosto)
                                  where data.Field<string>("Codigo").Equals(inventario.CodigoProducto) &&
                                        data.Field<int>("IdMedida").Equals(inventario.IdMedida) &&
                                        data.Field<int>("IdColor").Equals(inventario.IdColor)
                                  select data;
                        }
                    }
                    //countRows = row.ToArray().Length;
                    //inventario.Cantidad = 0;//RowsCosto - countRows;

                    var tProductos = miBussinesFacturaProveedor.ProductosDeFactura(inventario);
                    var cant = 0.0;
                    var total = 0;
                    foreach (DataRow tRow in row)
                    {
                        cant += Convert.ToDouble(tRow["Cantidad"]);
                        //if (Convert.ToBoolean(AppConfiguracion.ValorSeccion("costoMasIva")))   // Utilidad despues de IVA

                        if (Convert.ToBoolean(AppConfiguracion.ValorSeccion("costoIva")))
                        {
                            total += Convert.ToInt32(tRow["Valor"]);
                        }
                        else    // Utilidad antes de IVA
                        {
                            total += Convert.ToInt32(tRow["ValorMenosDescto"]);
                            total = Convert.ToInt32(total * cant);
                        }

                        //total += Convert.ToInt32(tRow["ValorMenosDescto"]);    //Valor
                        var row_ = tRegistro.NewRow();
                        row_["Fecha"] = FechaHoy;
                        row_["Codigo"] = tRow["Codigo"].ToString();
                        row_["Cantidad"] = Convert.ToDouble(tRow["Cantidad"]);//
                        row_["Valor"] = Convert.ToInt32(tRow["TotalMasIva"]);
                        row_["Total"] = Convert.ToInt32(
                                        Convert.ToDouble(tRow["Cantidad"]) * Convert.ToInt32(tRow["TotalMasIva"]));
                        tRegistro.Rows.Add(row_);
                    }
                    foreach (DataRow tRow in tProductos.Rows)
                    {
                        cant += Convert.ToDouble(tRow["cantidad"]);
                        var vUnit = Convert.ToInt32(tRow["valor"]) -
                            (Convert.ToInt32(tRow["valor"]) * Convert.ToInt32(tRow["descuento"]) / 100);

                        if (Convert.ToBoolean(AppConfiguracion.ValorSeccion("costoIva")))
                        {
                            total += Convert.ToInt32(
                            (vUnit + Convert.ToInt32(vUnit * Convert.ToDouble(tRow["iva"]) / 100)) * Convert.ToDouble(tRow["cantidad"]));
                        }
                        else
                        {
                            total += Convert.ToInt32(vUnit * Convert.ToDouble(tRow["cantidad"]));
                        }

                      //  if (Convert.ToBoolean(AppConfiguracion.ValorSeccion("utilidad_mas_iva")))   // Utilidad despues de IVA
                      //  {
                      //      total += Convert.ToInt32(
                      //      (vUnit + Convert.ToInt32(vUnit * Convert.ToDouble(tRow["iva"]) / 100)) * Convert.ToDouble(tRow["cantidad"]));
                       // }
                       // else
                       // {
                       //     total += Convert.ToInt32(vUnit * Convert.ToDouble(tRow["cantidad"]));
                       // }
                       //  total += Convert.ToInt32(
                       //      (vUnit + Convert.ToInt32(vUnit * Convert.ToDouble(tRow["iva"]) / 100)) * Convert.ToDouble(tRow["cantidad"]));

                        var row_ = tRegistro.NewRow();
                        row_["Fecha"] = Convert.ToDateTime(tRow["fecha"]);
                        row_["Codigo"] = tRow["codigo"].ToString();
                        row_["Cantidad"] = Convert.ToDouble(tRow["cantidad"]);
                        row_["Valor"] = vUnit + Convert.ToInt32(vUnit * Convert.ToDouble(tRow["iva"]) / 100);
                        row_["Total"] = Convert.ToInt32(
                                        Convert.ToInt32(row_["Valor"]) * Convert.ToDouble(tRow["cantidad"]));
                        tRegistro.Rows.Add(row_);
                    }
                    dgRegistros.DataSource = tRegistro;


                    var producto = miBussinesProducto.ProductoCompleto(inventario.CodigoProducto);*/

                    var registro = dgvListaArticulos.Rows[dgvListaArticulos.CurrentCell.RowIndex]; 
                    var producto = miBussinesProducto.ProductoCompleto(registro.Cells["Codigo"].Value.ToString());

                    var costoProducto_ = miBussinesProducto.PrecioDeCosto(producto.CodigoInternoProducto);
                    if (Convert.ToBoolean(AppConfiguracion.ValorSeccion("costoIva")))
                    {
                        lblValorCostoAsig.Text = UseObject.InsertSeparatorMil(
                            Convert.ToInt32(costoProducto_ + (costoProducto_ * producto.ValorIva / 100)).ToString());
                    }
                    else
                    {
                        lblValorCostoAsig.Text = UseObject.InsertSeparatorMil(costoProducto_.ToString());
                    }


                    //txtCosto.Text = UseObject.InsertSeparatorMil((Convert.ToInt32(total / cant)).ToString()); // Here
                    txtCosto.Text = UseObject.InsertSeparatorMil(Convert.ToInt32(registro.Cells["TotalMasIva"].Value).ToString()); //TotalMasIva
                    txtUtilidad.Text = producto.UtilidadPorcentualProducto.ToString();

                    var precioSug = 0;
                    var precioUtil = 0.0;
                    var costo = Convert.ToInt32(UseObject.RemoveSeparatorMil(txtCosto.Text));
                    if (MiEmpresa.Regimen.IdRegimen.Equals(1))
                    {
                        if (Convert.ToBoolean(AppConfiguracion.ValorSeccion("costoIva")))//  Precio de Costo                                   (2)
                        {
                            costo = Convert.ToInt32((Convert.ToInt32(costo) / (1 + (producto.ValorIva / 100))));
                        }
                    }
                    else
                    {
                        if (!Convert.ToBoolean(AppConfiguracion.ValorSeccion("costoIva")))//  Precio de Costo                                   (2)
                        {
                            costo = Convert.ToInt32(Convert.ToInt32(costo) + (Convert.ToInt32(costo) * producto.ValorIva / 100));
                        }
                    }


                    
                    /* if (chkIva.Checked)
                     {
                         if (MiEmpresa.Regimen.IdRegimen.Equals(1))
                         {
                             costo = Convert.ToInt32(UseObject.RemoveSeparatorMil(txtCosto.Text) / (1 + (producto.ValorIva / 100)));
                         }
                         else
                         {
                             costo = Convert.ToInt32(UseObject.RemoveSeparatorMil(txtCosto.Text));
                         }
                     }
                     else
                     {
                         costo = Convert.ToInt32(UseObject.RemoveSeparatorMil(txtCosto.Text));
                     }*/

                    if (!Convert.ToBoolean(AppConfiguracion.ValorSeccion("utilidad_mas_iva")))   // Utilidad antes de IVA.                       (3)
                    {
                        if (Convert.ToBoolean(AppConfiguracion.ValorSeccion("calculo_util_multiplica"))) // Incremento de Utilidad         (4)
                        {
                            precioUtil = costo + (costo * producto.UtilidadPorcentualProducto / 100);
                        }
                        else
                        {
                            var UtilComplemento = 100.0 - UseObject.RemoveSeparatorMil(txtUtilidad.Text);
                            precioUtil = costo / (UtilComplemento / 100);
                            //precioSug = Convert.ToInt32(precioUtil + (precioUtil * producto.ValorIva / 100));
                        }
                        if (MiEmpresa.Regimen.IdRegimen.Equals(1))//  Regimen                                                                (1)
                        {
                            precioSug = Convert.ToInt32(precioUtil + (precioUtil * producto.ValorIva / 100));
                        }
                        else
                        {
                            precioSug = Convert.ToInt32(precioUtil);
                        }
                    }
                    else  // Utilidad despues de IVA.
                    {
                        if (MiEmpresa.Regimen.IdRegimen.Equals(1))//  Regimen                                                                (1)
                        {
                            precioUtil = costo + (costo * producto.ValorIva / 100);
                        }
                        else
                        {
                            precioUtil = costo;
                        }
                        if (Convert.ToBoolean(AppConfiguracion.ValorSeccion("calculo_util_multiplica"))) // Incremento de Utilidad         (4)
                        {
                            //precioUtil = costo + (costo * producto.UtilidadPorcentualProducto / 100);
                            precioSug = Convert.ToInt32(precioUtil + (precioUtil * producto.UtilidadPorcentualProducto / 100));
                        }
                        else
                        {
                            var UtilComplemento = 100.0 - UseObject.RemoveSeparatorMil(txtUtilidad.Text);
                            precioSug = Convert.ToInt32(precioUtil / (UtilComplemento / 100));
                            //precioUtil = costo / (UtilComplemento / 100);
                        }
                    }
                    txtPrecioSugerido.Text = UseObject.InsertSeparatorMil(precioSug.ToString());
                    precioSug = UseObject.Aproximar(precioSug, Convert.ToBoolean(AppConfiguracion.ValorSeccion("tipo_aprox_precio")));

                    txtPrecioAprox.Text = UseObject.InsertSeparatorMil(precioSug.ToString());
                    txtPrecioVenta.Text = UseObject.InsertSeparatorMil(producto.ValorVentaProducto.ToString());

                    lblValorCosto.Text = lblValorCostoAsig.Text;
                    lblVUtilidad.Text = producto.UtilidadPorcentualProducto.ToString();
                    lblValorSugerido.Text = txtPrecioSugerido.Text;
                    lblValorAprox.Text = txtPrecioAprox.Text;
                    lblValorVenta.Text = UseObject.InsertSeparatorMil(producto.ValorVentaProducto.ToString());

                    /*txtPrecioAprox.Text = UseObject.InsertSeparatorMil(precioAprox.ToString());
                txtPrecioVenta.Text = UseObject.InsertSeparatorMil(producto.ValorVentaProducto.ToString());

                lblValorCosto.Text = lblValorCostoAsig.Text;
                lblVUtilidad.Text = producto.UtilidadPorcentualProducto.ToString();
                lblValorSugerido.Text = txtPrecioSugerido.Text;
                lblValorAprox.Text = txtPrecioAprox.Text;
                lblValorVenta.Text = UseObject.InsertSeparatorMil(producto.ValorVentaProducto.ToString())*/
                    /*if (Convert.ToBoolean(AppConfiguracion.ValorSeccion("calculo_util_multiplica"))) // mutliplica
                    {
                        var precioUtil = UseObject.RemoveSeparatorMil(txtCosto.Text) +
                                     (UseObject.RemoveSeparatorMil(txtCosto.Text) * producto.UtilidadPorcentualProducto / 100);
                        precioSug = Convert.ToInt32(precioUtil + (precioUtil * producto.ValorIva / 100));
                    }
                    else  // divide
                    {
                        var UtilComplemento = 100.0 - UseObject.RemoveSeparatorMil(txtUtilidad.Text);
                        var precioUtil = UseObject.RemoveSeparatorMil(txtCosto.Text) / (UtilComplemento / 100);
                        precioSug = Convert.ToInt32(precioUtil + (precioUtil * producto.ValorIva / 100));
                    }
                    //if (MiEmpresa.RecaudaIVA)
                    //{
                    //    precioSug = Convert.ToInt32(precioSug + (precioSug * producto.ValorIva / 100));
                    //}
                    txtPrecioSugerido.Text = UseObject.InsertSeparatorMil(precioSug.ToString());

                    char[] precioChar = precioSug.ToString().ToCharArray();
                    var precioAprox = 0;

                    if (TipoAproxPrecio) //Aprox centena
                    {
                        var digito = Convert.ToInt32(precioChar[precioChar.Length - 2].ToString()
                                                    + precioChar[precioChar.Length - 1].ToString());
                        if (digito > 50)
                        {
                            precioAprox = precioSug + (100 - digito);
                        }
                        else
                        {
                            precioAprox = precioSug - digito;
                        }
                    }
                    else  //aprox decena
                    {
                        if (Convert.ToInt32(precioChar[precioChar.Length - 1].ToString()) > 5)
                        {
                            precioAprox = precioSug + (10 - Convert.ToInt32(precioChar[precioChar.Length - 1].ToString()));
                        }
                        else
                        {
                            precioAprox = precioSug - Convert.ToInt32(precioChar[precioChar.Length - 1].ToString());
                        }
                    }
                    txtPrecioAprox.Text = UseObject.InsertSeparatorMil(precioAprox.ToString());
                    txtPrecioVenta.Text = UseObject.InsertSeparatorMil(producto.ValorVentaProducto.ToString());

                    lblValorCosto.Text = lblValorCostoAsig.Text;
                    lblVUtilidad.Text = producto.UtilidadPorcentualProducto.ToString();
                    lblValorSugerido.Text = txtPrecioSugerido.Text;
                    lblValorAprox.Text = txtPrecioAprox.Text;
                    lblValorVenta.Text = UseObject.InsertSeparatorMil(producto.ValorVentaProducto.ToString());*/
                }
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
        }

        private void tsVerMedida_Click(object sender, EventArgs e)
        {
            if (BtnVerMedidaPress)
            {
                tsVerMedida.Image = new Bitmap(ImgMedidaStream);
                tsVerMedida.Text = "No Ver Unidad de Medida";
                BtnNoVerMedidaPress = true;
                BtnVerMedidaPress = false;
                dgvListaArticulos.Columns["Unidad"].Visible = true;
                dgvListaArticulos.Columns["Medida"].Visible = true;
                dgvListaArticulos.Columns["Articulo"].Width -= Unidad.Width;
                dgvListaArticulos.Columns["Articulo"].Width -= Medida.Width;
            }
            else
            {
                if (BtnNoVerMedidaPress)
                {
                    tsVerMedida.Image = ((Image)(miResources.GetObject("tsVerMedida.Image")));
                    tsVerMedida.Text = "Ver Unidad de Medida";
                    BtnNoVerMedidaPress = false;
                    BtnVerMedidaPress = true;
                    dgvListaArticulos.Columns["Unidad"].Visible = false;
                    dgvListaArticulos.Columns["Medida"].Visible = false;
                    dgvListaArticulos.Columns["Articulo"].Width += Unidad.Width;
                    dgvListaArticulos.Columns["Articulo"].Width += Medida.Width;
                }
            }
        }

        private void tsVerColor_Click(object sender, EventArgs e)
        {
            if (BtnVerColorPress)
            {
                tsVerColor.Image = new Bitmap(ImgColorStream);
                tsVerColor.Text = "No ver Color";
                BtnNoVerColorPress = true;
                BtnVerColorPress = false;
                dgvListaArticulos.Columns["Color"].Visible = true;
                dgvListaArticulos.Columns["Articulo"].Width -= Color.Width;
            }
            else
            {
                if (BtnNoVerColorPress)
                {
                    tsVerColor.Image = ((Image)(miResources.GetObject("tsVerColor.Image")));
                    tsVerColor.Text = "Ver Color";
                    BtnNoVerColorPress = false;
                    BtnVerColorPress = true;
                    dgvListaArticulos.Columns["Color"].Visible = false;
                    dgvListaArticulos.Columns["Articulo"].Width += Color.Width;
                }
            }
        }

        private void tsVerLote_Click(object sender, EventArgs e)
        {
            if (BtnVerLotePress)
            {
                tsVerLote.Image = new Bitmap(ImgLoteStream);
                tsVerLote.Text = "No Ver Lote";
                BtnNoVerLotePress = true;
                BtnVerLotePress = false;
                dgvListaArticulos.Columns["CLote"].Visible = true;
                dgvListaArticulos.Columns["Articulo"].Width -= CLote.Width;
            }
            else
            {
                if (BtnNoVerLotePress)
                {
                    tsVerLote.Image = ((Image)(miResources.GetObject("tsVerLote.Image")));
                    BtnNoVerLotePress = false;
                    BtnVerLotePress = true;
                    dgvListaArticulos.Columns["CLote"].Visible = false;
                    dgvListaArticulos.Columns["Articulo"].Width += CLote.Width;
                }
            }
        }

        private void tsEditar_Click(object sender, EventArgs e)
        {
            if (dgvListaArticulos.RowCount != 0)
            {
                DialogResult rta = MessageBox.Show("¿Esta seguro de editar el registro?", "Factura Proveedor",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (rta.Equals(DialogResult.Yes))
                {
                    int id = (int)dgvListaArticulos.CurrentRow.Cells["Id"].Value;
                    var row = (from registro in miTabla.AsEnumerable()
                               where registro.Field<int>("Id") == id
                               select registro);
                    DataRow edit = null;
                    foreach (DataRow r in row)
                    {
                        edit = r;
                    }
                    txtCodigoArticulo.Text = edit["Codigo"].ToString();
                    txtCodigoArticulo_KeyPress(null, new KeyPressEventArgs((char)Keys.Enter));
                    miTallaYcolor.IdTalla = (int)edit["IdMedida"];
                    miTallaYcolor.Talla = edit["Medida"].ToString();
                    miTallaYcolor.IdColor = (int)edit["IdColor"];
                    try
                    {
                        miTallaYcolor.Color = (Image)edit["Color"];
                    }
                    catch
                    {
                        miTallaYcolor.Color = null;
                    }
                    txtCantidad.Text = edit["Cantidad"].ToString().Replace(',', '.');
                    txtValorUnitario.Text = edit["ValorUnitario"].ToString().Replace(',', '.');
                    txtLote.Text = edit["Lote"].ToString();
                    if (rbtnDesctoProducto.Checked)
                    {
                        txtDescuentoProducto.Text =
                            UseObject.RemoveCharacter(edit["Descuento"].ToString(), '%').ToString();
                    }
                    if (MiProveedor.IdRegimen == 1)
                    {
                        var total_ = Math.Round(
                                     edit.Field<double>("ValorMenosDescto") *
                                     Convert.ToDouble(edit["Cantidad"]), 0);
                        var iva_ = UseObject.RemoveCharacter(edit.Field<string>("Iva"), '%');
                        var panelSearch = (from data in miPanelTributario
                                           where data.Iva == iva_
                                           select data).ToList();
                        panelSearch[0].TxtGravado.Text = UseObject.InsertSeparatorMil(
                            (UseObject.RemoveSeparatorMil(panelSearch[0].TxtGravado.Text) - total_).ToString());

                        var ji = Math.Round((iva_ * total_ / 100), 0);
                        panelSearch[0].TxtTotalIva.Text = UseObject.InsertSeparatorMil(
                            (UseObject.RemoveSeparatorMil(panelSearch[0].TxtTotalIva.Text) -
                             Math.Round((iva_ * total_ / 100), 0)).ToString());

                        //var i = Math.Pow((iva_ * total_ / 100), 2);

                        txtIva.Text = UseObject.InsertSeparatorMil(
                        (UseObject.RemoveSeparatorMil(txtIva.Text) - Math.Round((iva_ * total_ / 100), 0)).ToString());
                        MiValorIVA -= Math.Round((iva_ * total_ / 100), 0);
                    }
                    var s = edit.Field<double>("ValorUnitario") * Convert.ToDouble(edit["Cantidad"]);
                    txtSubTotal.Text = UseObject.InsertSeparatorMil
                            (
                              (UseObject.RemoveSeparatorMil(txtSubTotal.Text) -
                               Math.Round(edit.Field<double>("ValorUnitario") * Convert.ToDouble(edit["Cantidad"]), 0))
                              .ToString()
                            );

                    var v_unit = Convert.ToDecimal(edit["ValorUnitario"]);
                    var v_descto = Convert.ToDecimal(edit["ValorMenosDescto"]);
                    var cantida = Convert.ToDecimal(edit["Cantidad"]);

                    txtDescuento.Text = UseObject.InsertSeparatorMil
                        (Convert.ToInt32(Convert.ToDecimal(txtDescuento.Text) -
                          ((Convert.ToDecimal(edit["ValorUnitario"]) - Convert.ToDecimal(edit["ValorMenosDescto"])) *
                            Convert.ToDecimal(edit["Cantidad"]))).ToString()
                        );

                    txtTotal.Text = UseObject.InsertSeparatorMil(
                        ((UseObject.RemoveSeparatorMil(txtSubTotal.Text) -
                         UseObject.RemoveSeparatorMil(txtDescuento.Text)) +
                         UseObject.RemoveSeparatorMil(txtIva.Text)).ToString());

                    miTabla.Rows.Remove(edit);
                    if (miTabla.Rows.Count != 0)
                    {
                        RecargarGridview();
                    }
                    else
                    {
                        dgvListaArticulos.Rows.RemoveAt(dgvListaArticulos.CurrentCell.RowIndex);
                    }
                    if (dgvListaArticulos.RowCount != 0)
                    {
                        dgvListaArticulos_CellClick(this.dgvListaArticulos, null);
                    }
                    else
                    {
                        MiValorIVA = 0.0;
                        txtCosto.Text = "";
                        txtUtilidad.Text = "";
                        txtPrecioSugerido.Text = "";
                        txtPrecioAprox.Text = "";
                        txtPrecioVenta.Text = "";
                        lblValorCostoAsig.Text = "0";
                        lblValorCosto.Text = "0";
                        lblVUtilidad.Text = "0";
                        lblValorSugerido.Text = "0";
                        lblValorAprox.Text = "0";
                        lblValorVenta.Text = "0";
                        while (dgRegistros.RowCount != 0)
                        {
                            dgRegistros.Rows.RemoveAt(0);
                        }
                    }
                }
            }
            else
            {
                OptionPane.MessageInformation("No hay registros para editar.");
            }
        }

        private void tsEliminar_Click(object sender, EventArgs e)
        {
            if (dgvListaArticulos.RowCount != 0)
            {
                string rta = OptionPane.OptionBox("Ingrese contraseña de Administrador.",
                    "Administrador", OptionPane.Icon.LoginAdmin);
                if (!rta.Equals("false"))
                {
                    if (miBussinesUsuario.VerificarUsuarioAdmin(Encode.Encrypt(rta)))
                    {
                        int id = (int)dgvListaArticulos.CurrentRow.Cells["Id"].Value;
                        var row = (from registro in miTabla.AsEnumerable()
                                   where registro.Field<int>("Id") == id
                                   select registro);
                        DataRow delet = null;
                        foreach (DataRow r in row)
                        {
                            delet = r;
                        }
                        var total_ = 0.0;
                        var iva_ = 0.0;
                        if (MiProveedor.IdRegimen == 1)
                        {
                            /*var d = delet.Field<double>("ValorMenosDescto");
                            var c = Convert.ToDouble(delet["Cantidad"]);*/

                            total_ = Math.Round(
                                     (delet.Field<double>("ValorMenosDescto") *
                                     Convert.ToDouble(delet["Cantidad"])), 0);
                            iva_ = UseObject.RemoveCharacter(delet.Field<string>("Iva"), '%');
                            var panelSearch = (from data in miPanelTributario
                                               where data.Iva == iva_
                                               select data).ToList();
                            panelSearch[0].TxtGravado.Text = UseObject.InsertSeparatorMil(
                                (UseObject.RemoveSeparatorMil(panelSearch[0].TxtGravado.Text) - total_).ToString());
                            panelSearch[0].TxtTotalIva.Text = UseObject.InsertSeparatorMil(
                                (UseObject.RemoveSeparatorMil(panelSearch[0].TxtTotalIva.Text) -
                                  Math.Round((iva_ * total_ / 100), 0)).ToString());
                            // var con = Convert.ToDouble((iva_ * total_ / 100));
                            txtIva.Text = UseObject.InsertSeparatorMil(
                            (UseObject.RemoveSeparatorMil(txtIva.Text) - Math.Round((iva_ * total_ / 100), 0)).ToString());
                            MiValorIVA -= Math.Round((iva_ * total_ / 100), 0);
                        }
                        /*txtSubTotal.Text = UseObject.InsertSeparatorMil
                            (Convert.ToInt32
                              (UseObject.RemoveSeparatorMil(txtSubTotal.Text) -
                              delet.Field<double>("ValorUnitario") * Convert.ToDouble(delet["Cantidad"]))
                              .ToString()
                            );

                        txtDescuento.Text = UseObject.InsertSeparatorMil
                            (Convert.ToInt32
                              (UseObject.RemoveSeparatorMil(txtDescuento.Text) -
                               ((delet.Field<double>("ValorUnitario") - delet.Field<double>("ValorMenosDescto")) *
                                 Convert.ToDouble(delet["Cantidad"]))).ToString()
                            );

                        txtTotal.Text = UseObject.InsertSeparatorMil(
                            Convert.ToInt32
                            ((UseObject.RemoveSeparatorMil(txtSubTotal.Text) -
                             UseObject.RemoveSeparatorMil(txtDescuento.Text)) +
                             UseObject.RemoveSeparatorMil(txtIva.Text)).ToString());*/
                        miTabla.Rows.Remove(delet);

                        this.ValidarRetencion();
                        this.CalcularTotales();

                        if (miTabla.Rows.Count != 0)
                        {
                            RecargarGridview();
                        }
                        else
                        {
                            dgvListaArticulos.Rows.RemoveAt(dgvListaArticulos.CurrentCell.RowIndex);
                        }
                        if (dgvListaArticulos.RowCount != 0)
                        {
                            dgvListaArticulos_CellClick(this.dgvListaArticulos, null);
                        }
                        else
                        {
                            MiValorIVA = 0.0;
                            txtCosto.Text = "";
                            txtUtilidad.Text = "";
                            txtPrecioSugerido.Text = "";
                            txtPrecioAprox.Text = "";
                            txtPrecioVenta.Text = "";
                            lblValorCostoAsig.Text = "0";
                            lblValorCosto.Text = "0";
                            lblVUtilidad.Text = "0";
                            lblValorSugerido.Text = "0";
                            lblValorAprox.Text = "0";
                            lblValorVenta.Text = "0";
                            while (dgRegistros.RowCount != 0)
                            {
                                dgRegistros.Rows.RemoveAt(0);
                            }
                            txtSubTotal.Text = "0";
                            txtDescuento.Text = "0";
                            txtRetencion.Text = "0";
                            txtIva.Text = "0";
                            txtTotal.Text = "0";
                        }
                    }
                }
                else
                {
                    OptionPane.MessageError("La contraseña es incorrecta.");
                }
            }
            else
            {
                OptionPane.MessageInformation("No hay registros para eliminar.");
            }
        }

        private void btnCambiarRetencion_Click(object sender, EventArgs e)
        {
            var frmReteCompra = new Egreso.FrmAplicaRetencion();
            frmReteCompra.AplicaCompra = true;
            frmReteCompra.IdTipoBeneficio = MiProveedor.IdRegimen;
            frmReteCompra.IdTipoEmpresa = MiEmpresa.Regimen.IdRegimen;
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
                    if (UseObject.RemoveSeparatorMil(txtSubTotal.Text) > query.CifraPesos)
                    {
                        txtRetencion.Text = UseObject.InsertSeparatorMil((Convert.ToInt32
                                (UseObject.RemoveSeparatorMil(txtSubTotal.Text) * query.Tarifa / 100)).ToString());
                    }
                    else
                    {
                        txtRetencion.Text = "0";
                    }
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
                }
            }
            txtTotal.Text = UseObject.InsertSeparatorMil(
                            Convert.ToInt64
                        ((UseObject.RemoveSeparatorMil(txtSubTotal.Text) -
                            UseObject.RemoveSeparatorMil(txtDescuento.Text) -
                            UseObject.RemoveSeparatorMil(txtRetencion.Text)) +
                            UseObject.RemoveSeparatorMil(txtIva.Text)).ToString());
        }

        private void txtAjuste_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                var ajuste = txtAjuste.Text;
                if (String.IsNullOrEmpty(ajuste))
                {
                    ajuste = "0";
                }
                else
                {
                    /*if (Validacion.ConFormato(Validacion.TipoValidacion.NumerosYPunto,
                                            txtAjuste, MiError, "El valor que ingreso es incorrecto."))*/
                    if (ValidarNumero(txtAjuste.Text))
                    {
                        MiError.SetError(txtAjuste, null);
                        var total = UseObject.InsertSeparatorMil(
                            Convert.ToInt64
                            ((UseObject.RemoveSeparatorMil(txtSubTotal.Text) -
                              UseObject.RemoveSeparatorMil(txtDescuento.Text) -
                              UseObject.RemoveSeparatorMil(txtRetencion.Text)) +
                              UseObject.RemoveSeparatorMil(txtIva.Text)).ToString());
                        txtTotal.Text = UseObject.InsertSeparatorMil(
                                        (Convert.ToDouble(total) + Convert.ToDouble(ajuste.Replace('.', ','))).ToString());
                        AjusteMatch = true;
                    }
                    else
                    {
                        MiError.SetError(txtAjuste, "El valor que ingreso es incorrecto.");
                        AjusteMatch = false;
                    }
                }

                /*var total = UseObject.InsertSeparatorMil(
                            Convert.ToInt64
                            ((UseObject.RemoveSeparatorMil(txtSubTotal.Text) -
                              UseObject.RemoveSeparatorMil(txtDescuento.Text) -
                              UseObject.RemoveSeparatorMil(txtRetencion.Text)) +
                              UseObject.RemoveSeparatorMil(txtIva.Text)).ToString());
                txtTotal.Text = UseObject.InsertSeparatorMil(
                                (Convert.ToDouble(total) + Convert.ToDouble(ajuste.Replace('.', ','))).ToString());*/
            }
            catch (Exception ex)
            {
                MiError.SetError(txtAjuste, ex.Message);
            }
        }

        private void txtDescuento_Click(object sender, EventArgs e)
        {
            txtDescuento.SelectAll();
        }

        private void txtDescuento_KeyPress(object sender, KeyPressEventArgs e)
        {
            /*if (e.KeyChar == (char)Keys.Enter)
            {
                if (!String.IsNullOrEmpty(txtDescuento.Text))
                {
                    txtDescuento.Text = UseObject.RemoveSeparatorMil(txtDescuento.Text).ToString();
                    if (Validacion.ConFormato(Validacion.TipoValidacion.Numeros,
                        txtDescuento, MiError, "El valor del Descuento que ingreso tiene formato incorrecto."))
                    {
                        if (Convert.ToDouble(txtDescuento.Text) <
                            UseObject.RemoveSeparatorMil(txtSubTotal.Text))
                        {
                            txtTotal.Text = UseObject.InsertSeparatorMil(
                                ((UseObject.RemoveSeparatorMil(txtSubTotal.Text) - Convert.ToDouble(txtDescuento.Text)) +
                                 UseObject.RemoveSeparatorMil(txtIva.Text)).ToString());
                            txtDescuento.Text = UseObject.InsertSeparatorMil(txtDescuento.Text);
                            MiError.SetError(txtDescuento, "");
                            DescuentoMatch = true;
                        }
                        else
                        {
                            MiError.SetError(txtDescuento, "El valor del descuento debe ser menor al valor del Subtotal.");
                            DescuentoMatch = false;
                        }
                    }
                }
                else
                {
                    txtDescuento.Text = "0";
                }
            }*/
        }

        private void txtDescuento_Validating(object sender, CancelEventArgs e)
        {
            txtDescuento_KeyPress(null, new KeyPressEventArgs((char)Keys.Enter));
        }

        private bool ValidarDouble(string numero)
        {
            try
            {
                Convert.ToDouble(numero);
                return true;
            }
            catch (FormatException)
            {
                return false;
            }
        }

        /// <summary>
        /// Carga los datos del usuario en el texto del formulario.
        /// </summary>
        private void CargarUsuario()
        {
            miFactura.Usuario = Administracion.Usuario.FrmIniciarSesion.CargarDatosUsuario(this);
        }

        /// <summary>
        /// Crea las respectivas columnas del DataTable miTabla.
        /// </summary>
        private void CrearDataTable()
        {
            miTabla.Columns.Add(new DataColumn("Id", typeof(int)));
            miTabla.Columns.Add(new DataColumn("Codigo", typeof(string)));
            miTabla.Columns.Add(new DataColumn("Producto", typeof(string)));
            miTabla.Columns.Add(new DataColumn("Cantidad", typeof(double)));
            miTabla.Columns.Add(new DataColumn("ValorUnitario", typeof(double)));
            miTabla.Columns.Add(new DataColumn("Descuento", typeof(string)));
            miTabla.Columns.Add(new DataColumn("ValorMenosDescto", typeof(double)));
            miTabla.Columns.Add(new DataColumn("Iva", typeof(string)));
            miTabla.Columns.Add(new DataColumn("TotalMasIva", typeof(double)));
            miTabla.Columns.Add(new DataColumn("Valor", typeof(double)));

            miTabla.Columns.Add(new DataColumn("IdTipoInventario", typeof(int)));
            miTabla.Columns.Add(new DataColumn("Presentacion", typeof(int)));
            miTabla.Columns.Add(new DataColumn("Unidad", typeof(string)));
            miTabla.Columns.Add(new DataColumn("IdMedida", typeof(int)));
            miTabla.Columns.Add(new DataColumn("Medida", typeof(string)));
            miTabla.Columns.Add(new DataColumn("IdColor", typeof(int)));
            miTabla.Columns.Add(new DataColumn("Color", typeof(Image)));
            miTabla.Columns.Add(new DataColumn("Lote", typeof(string)));

            miTabla.Columns.Add(new DataColumn("Valor_", typeof(int)));
            miTabla.Columns.Add(new DataColumn("Total_", typeof(int)));
            miTabla.Columns.Add(new DataColumn("Sub_Total", typeof(int)));
            miTabla.Columns.Add(new DataColumn("Descto_", typeof(int)));
            miTabla.Columns.Add(new DataColumn("vIva_", typeof(double)));
        }

        /// <summary>
        /// Carga los recursos del ensamblado usados en el formulario.
        /// </summary>
        private void CargarRecursos()
        {
            tsVerColor.Enabled = EnableColor;
            try
            {
                ImgMedidaStream = assembly.GetManifestResourceStream(ImagenMedida);
                ImgColorStream = assembly.GetManifestResourceStream(ImagenColor);
                ImgLoteStream = assembly.GetManifestResourceStream(ImagenLote);
            }
            catch
            {
                OptionPane.MessageError("Ocurrio un error al cargar los recursos.");
            }

            try
            {
                cbFormaPago.DataSource = miBussinesEstado.Lista();
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }

            try
            {
                LoteConsecutivo = Convert.ToInt32(miBussinesFacturaProveedor.ObtenerNumeroLote());
            }
            catch (Exception ex)
            {
                OptionPane.MessageError("Ocurrio un error al cargar el consecutivo del Lote.\n" + ex.Message);
            }

            var lst = new List<Inventario.Producto.Criterio>();
            lst.Add(new Inventario.Producto.Criterio
            {
                Id = 1,
                Nombre = "Código"
            });
            lst.Add(new Inventario.Producto.Criterio
            {
                Id = 2,
                Nombre = "NIT"
            });
            cbCriterio.DataSource = lst;

            lst = new List<Inventario.Producto.Criterio>();
            lst.Add(new Inventario.Producto.Criterio
            {
                Id = 1,
                Nombre = "Factura"
            });
            lst.Add(new Inventario.Producto.Criterio
            {
                Id = 2,
                Nombre = "Remisión"
            });
            lst.Add(new Inventario.Producto.Criterio
            {
                Id = 3,
                Nombre = "Documento Equivalente"
            });
            cbRemision.DataSource = lst;

            try
            {
                if (!Convert.ToBoolean(AppConfiguracion.ValorSeccion("cargaProveedorCompra")))
                {
                    cbCriterio.SelectedValue = 2;
                }
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
        }

        /// <summary>
        /// Carga los datos del requeridos para almacenar la Factura.
        /// </summary>
        private void CargarFactura()
        {
            try
            {
                if (UseObject.RemoveSeparatorMil(txtRetencion.Text).Equals(0))
                {
                    AplicaRete = false;
                }
                miFactura.Proveedor.CodigoInternoProveedor = MiProveedor.CodigoInternoProveedor;
                miFactura.EstadoFactura.Id = Convert.ToInt32(cbFormaPago.SelectedValue);
                miFactura.Caja.Id = Convert.ToInt32(AppConfiguracion.ValorSeccion("id_caja"));
                miFactura.Usuario.Id = Convert.ToInt32(AppConfiguracion.ValorSeccion("id_user"));
                miFactura.Tipo = Convert.ToInt32(cbRemision.SelectedValue);
                if (Convert.ToInt32(cbRemision.SelectedValue).Equals(3))
                {
                    miFactura.Numero = miBussinesConsecutivo.Consecutivo("Documento");
                }
                else
                {
                    miFactura.Numero = txtNumeroFactura.Text;
                }
                miFactura.FechaFactura = dtpFecha.Value;
                miFactura.FechaLimite = dtpFechaLimite.Value;
                miFactura.FechaIngreso = FechaHoy;

                if (UseObject.RemoveSeparatorMil(this.txtRetencion.Text) > 0)
                {
                    miFactura.Retencion = MiRetencion;
                }
                if (Convert.ToInt32(cbRemision.SelectedValue).Equals(3))
                {
                    miFactura.EsFactura = false;
                }
                else
                {
                    miFactura.EsFactura = true;
                }
                if (rbtnDesctoFactura.Checked)
                {
                    miFactura.Descuento = Convert.ToDouble(txtDescuentoFactura.Text);
                }
                miFactura.Ajuste = Convert.ToDouble(txtAjuste.Text.Replace('.', ','));
                List<ProductoFacturaProveedor> productos = new List<ProductoFacturaProveedor>();
                foreach (DataRow row in miTabla.Rows)
                {
                    var producto = new ProductoFacturaProveedor();
                    producto.Producto.CodigoInternoProducto = row["Codigo"].ToString();
                    producto.Cantidad = Convert.ToDouble(row["Cantidad"]);

                    if (MiProveedor.IdRegimen == 1)  //Regimen Comun
                    {
                        producto.Producto.ValorCosto = Convert.ToDouble(Convert.ToInt32(row["ValorMenosDescto"]));
                    }
                    else
                    {
                        double valorIva = ((Producto)this.miBussinesProducto.ProductoBasico(producto.Producto.CodigoInternoProducto)[0]).ValorIva;
                        producto.Producto.ValorCosto = Convert.ToInt32(Convert.ToInt32(row["ValorMenosDescto"]) / (1 + (valorIva / 100)));
                    }

                    //producto.Producto.ValorCosto = Convert.ToDouble(Convert.ToInt32(row["ValorMenosDescto"]));
                    producto.Producto.ValorVentaProducto = Convert.ToDouble(row["ValorUnitario"]);
                    producto.Producto.ValorIva = UseObject.RemoveCharacter(row["Iva"].ToString(), '%');
                    producto.Producto.Descuento = UseObject.RemoveCharacter(row["Descuento"].ToString(), '%');

                    producto.Producto.IdTipoInventario = Convert.ToInt32(row["IdTipoInventario"]);
                    producto.Producto.UnidadVentaProducto = Convert.ToInt32(row["Presentacion"]);

                    producto.Lote.CodigoProducto = row["Codigo"].ToString();
                    producto.Lote.Numero = row["Lote"].ToString();
                    producto.Lote.Fecha = FechaHoy;
                    producto.Inventario.CodigoProducto = row["Codigo"].ToString();
                    producto.Inventario.IdMedida = Convert.ToInt32(row["IdMedida"]);
                    producto.Inventario.IdColor = Convert.ToInt32(row["IdColor"]);
                    producto.Inventario.Cantidad = Convert.ToDouble(row["Cantidad"]);
                    productos.Add(producto);
                }
                miFactura.Productos = productos;
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
        }

        /// <summary>
        /// Despliega el proceso del hilo (Thread) para el guardado de la Factura.
        /// </summary>
        private void IniciarGuardado()
        {
            GuardarFactura();
        }

        /// <summary>
        /// Realiza los procedimientos necesarios para el guardado de la Factura.
        /// </summary>
        private void GuardarFactura()
        {
            try
            {
                //var j = AplicaRete;
                miFactura.Id = miBussinesFacturaProveedor.IngresarFactura(miFactura, EsFactura, AplicaRete);
                miBussinesFacturaProveedor.ActualizarLote(LoteConsecutivo - 1);
                FinishProcessGuardado();
                /*SuccessGuardado = true;
                if (this.InvokeRequired)
                    this.Invoke(new Action(FinishProcessGuardado));*/
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
                /*SuccessGuardado = false;
                if (this.InvokeRequired)
                    this.Invoke(new Action(FinishProcessGuardado));*/
            }
        }

        /// <summary>
        /// Finaliza las funciones del proceso de guardado de la Factura.
        /// </summary>
        private void FinishProcessGuardado()
        {
            if (Convert.ToBoolean(AppConfiguracion.ValorSeccion("print_termal_80mm")))
            {
                FrmPrint frmPrint = new FrmPrint();
                frmPrint.StringCaption = "Compra a Proveedor";
                frmPrint.StringMessage = "Impresión de la compra";
                DialogResult rta = frmPrint.ShowDialog();

                if (rta.Equals(DialogResult.Yes))
                {
                    PrintDocumento(false);
                }
                else
                {
                    if (rta.Equals(DialogResult.No))
                    {
                        PrintDocumento(true);
                    }
                }
            }
            else
            {
                DialogResult rta = MessageBox.Show("¿Desea imprimir la compra?", "Factura compra",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (rta.Equals(DialogResult.Yes))
                {
                    PrintPos50mm();
                }
            }
            LimpiarFormulario();
        }

        /// <summary>
        /// Valida el texto ingresado como codigo del Proveedor.
        /// </summary>
        /// <returns></returns>
        public bool ValidarCodigoProveedor()
        {
            bool resultado = false;
            if (!Validacion.EsVacio(txtCodigoProveedor, MiError, CodigoProveedorReq))
            {
                if (Validacion.ConFormato(Validacion.TipoValidacion.NumeroGuion,
                    txtCodigoProveedor, MiError, CodigoProveedorFormato))
                {
                    resultado = true;
                }
            }
            return resultado;
        }

        private void CargarProveedorCodigo(string codigo)
        {
            var code = Convert.ToInt32(codigo);
            if (miBussinesProveedor.ExisteProveedorConCodigo(code))
            {
                if (MiProveedor != null)
                {
                    DialogResult rta = MessageBox.Show("¿Esta seguro que quiere cambiar el Proveedor de la Factura?",
                        "Información", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                    if (rta == DialogResult.Yes)
                    {
                        MiProveedor = miBussinesProveedor.ConsultarPrveedorBasico(code);
                        KeyProveedorPress = true;
                        cbRemision.Focus();
                        miOption = new OptionPane();
                        miOption.FrmProgressBar.barraProgreso.Style = ProgressBarStyle.Marquee;
                        miOption.FrmProgressBar.Closed_ = true;
                        miOption.ProgressShow("Espere mientras se realizan las operaciones necesarias...",
                            "Operacion en progreso");
                        this.Enabled = false;
                        miThread = new Thread(new ThreadStart(IniciarCambio));
                        miThread.Start();
                    }
                    else
                    {
                        txtCodigoProveedor.Text = MiProveedor.CodigoInternoProveedor.ToString();
                    }
                }
                else
                {
                    MiProveedor = miBussinesProveedor.ConsultarPrveedorBasico(code);
                    IdRegimen.Add(MiProveedor.IdRegimen);
                    txtNombreProveedor.Text = MiProveedor.CodigoInternoProveedor + " - NIT: " + MiProveedor.NitProveedor
                            + " - " + MiProveedor.RazonSocialProveedor;
                    if (MiProveedor.IdRegimen.Equals(1))
                    {
                        chkIva.Enabled = true;
                    }
                    else
                    {
                        chkIva.Checked = false;
                        chkIva.Enabled = false;
                    }
                    MiError.SetError(txtCodigoProveedor, null);
                    KeyProveedorPress = true;
                    ValidarRetencion();
                    cbRemision.Focus();
                }
            }
            else
            {
                DialogResult rta = MessageBox.Show("El Proveedor no existe. ¿Desea crearlo?", "Factura Proveedor",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (rta.Equals(DialogResult.Yes))
                {
                    if (!FormProveedor)
                    {
                        KeyProveedorPress = true;
                        formProveedor = new Proveedor.frmProveedor();
                        formProveedor.txtCodigoInterno.Text = codigo;
                        formProveedor.Extension = true;
                        FormProveedor = true;
                        formProveedor.MdiParent = this.MdiParent;
                        formProveedor.Show();
                        formProveedor.txtNitCedula.Focus();
                    }
                }
            }
        }

        private void CargarProveedorNit(string nit)
        {
            if (miBussinesProveedor.ExisteProveedorConNit(nit))
            {
                if (MiProveedor != null)
                {
                    DialogResult rta = MessageBox.Show("¿Esta seguro que quiere cambiar el Proveedor de la Factura?",
                        "Información", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                    if (rta == DialogResult.Yes)
                    {
                        MiProveedor = miBussinesProveedor.ConsultarPrveedorBasico(nit);
                        KeyProveedorPress = true;
                        cbRemision.Focus();
                        miOption = new OptionPane();
                        miOption.FrmProgressBar.barraProgreso.Style = ProgressBarStyle.Marquee;
                        miOption.FrmProgressBar.Closed_ = true;
                        miOption.ProgressShow("Espere mientras se realizan las operaciones necesarias...",
                            "Operacion en progreso");
                        this.Enabled = false;
                        miThread = new Thread(new ThreadStart(IniciarCambio));
                        miThread.Start();
                    }
                    else
                    {
                        txtCodigoProveedor.Text = MiProveedor.CodigoInternoProveedor.ToString();
                    }
                }
                else
                {
                    MiProveedor = miBussinesProveedor.ConsultarPrveedorBasico(nit);
                    IdRegimen.Add(MiProveedor.IdRegimen);
                    txtNombreProveedor.Text = MiProveedor.CodigoInternoProveedor + " - NIT: " + MiProveedor.NitProveedor
                            + " - " + MiProveedor.RazonSocialProveedor;
                    if (MiProveedor.IdRegimen.Equals(1))
                    {
                        chkIva.Enabled = true;
                    }
                    else
                    {
                        chkIva.Checked = false;
                        chkIva.Enabled = false;
                    }
                    MiError.SetError(txtCodigoProveedor, null);
                    KeyProveedorPress = true;
                    ValidarRetencion();
                    cbRemision.Focus();
                }
            }
            else
            {
                DialogResult rta = MessageBox.Show("El Proveedor no existe. ¿Desea crearlo?", "Factura Proveedor",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (rta.Equals(DialogResult.Yes))
                {
                    if (!FormProveedor)
                    {
                        KeyProveedorPress = true;
                        formProveedor = new Proveedor.frmProveedor();
                        formProveedor.txtNitCedula.Text = nit;
                        formProveedor.Extension = true;
                        FormProveedor = true;
                        formProveedor.MdiParent = this.MdiParent;
                        formProveedor.Show();
                        formProveedor.txtCodigoInterno.Focus();
                    }
                }
            }
        }

        /// <summary>
        /// Despliega el proceso del hilo (Thread) para el cambio del Proveedor.
        /// </summary>
        private void IniciarCambio()
        {
            myDelegate delInstance = new myDelegate(CambiarProveedor);
            this.Invoke(delInstance);
        }

        /// <summary>
        /// Realiza los procedimientos necesarios para el Cambio de proveedor de la Factura.
        /// </summary>
        private void CambiarProveedor()
        {
            try
            {
                IdRegimen.Add(MiProveedor.IdRegimen);
                txtNombreProveedor.Text = MiProveedor.CodigoInternoProveedor + " - NIT: " + MiProveedor.NitProveedor
                                    + " - " + MiProveedor.RazonSocialProveedor;
                if (MiProveedor.IdRegimen.Equals(1))
                {
                    chkIva.Enabled = true;
                }
                else
                {
                    chkIva.Checked = false;
                    chkIva.Enabled = false;
                }
                MiError.SetError(txtCodigoProveedor, null);
                var penUltimo = IdRegimen[IdRegimen.Count - 2];
                var ultimo = IdRegimen[IdRegimen.Count - 1];
                if (ultimo != penUltimo)
                {
                    if (dgvListaArticulos.RowCount != 0)
                    {
                        var copyMiTabla = miTabla.Copy();
                        while (miTabla.Rows.Count != 0)
                        {
                            miTabla.Rows.Clear();
                        }
                        foreach (DataRow row in copyMiTabla.Rows)
                        {
                            var row_ = miTabla.NewRow();
                            var producto = miBussinesProducto.ProductoBasico(row["Codigo"].ToString());
                            row_["Id"] = Contador++;
                            row_["Codigo"] = row["Codigo"];
                            row_["Producto"] = row["Producto"];
                            row_["Cantidad"] = row["Cantidad"];
                            row_["ValorUnitario"] = row["ValorUnitario"];
                            row_["Descuento"] = row["Descuento"];
                            row_["Descto_"] = row["Descto_"];
                            row_["ValorMenosDescto"] = row["ValorMenosDescto"];
                            //row_["Valor"] = row["Valor"];
                            row_["Unidad"] = row["Unidad"];
                            row_["IdMedida"] = row["IdMedida"];
                            row_["Medida"] = row["Medida"];
                            row_["IdColor"] = row["IdColor"];
                            row_["Color"] = row["Color"];
                            row_["Lote"] = row["Lote"];
                            if (MiProveedor.IdRegimen == 1)
                            {
                                row_["Iva"] = ((Producto)producto[0]).ValorIva + "%";
                                InformacionTributaria(UseObject.RemoveCharacter(row_["Iva"].ToString(), '%'),
                                     row_["Cantidad"].ToString(), (string)row_["ValorMenosDescto"].ToString());
                            }
                            else
                            {
                                row_["Iva"] = 0 + "%";
                            }
                            row_["TotalMasIva"] = Convert.ToDouble(
                                                  ((Convert.ToDouble(row_["ValorMenosDescto"]) *
                                                  UseObject.RemoveCharacter(row_["Iva"].ToString(), '%') / 100)) +
                                                  Convert.ToDouble(row_["ValorMenosDescto"]));
                            row_["Valor"] = Math.Round(
                                (Convert.ToDouble(row_["TotalMasIva"]) * Convert.ToDouble(row_["Cantidad"])), 0);
                            row_["Valor_"] = Convert.ToDouble(row_["ValorUnitario"]) +
                                (Convert.ToDouble(row_["ValorUnitario"]) * UseObject.RemoveCharacter(row_["Iva"].ToString(), '%') / 100);
                            var valorMenDescto = Convert.ToInt32(Convert.ToDouble(row["ValorUnitario"]) - 
                                (Convert.ToDouble(row["ValorUnitario"]) * UseObject.RemoveCharacter(row["Descuento"].ToString(), '%') / 100));
                            row_["Total_"] = (valorMenDescto + (valorMenDescto * UseObject.RemoveCharacter(row_["Iva"].ToString(), '%') / 100))
                                * Convert.ToDouble(row["Cantidad"]);
                            row_["Sub_Total"] = Convert.ToDouble(row["ValorUnitario"]) * Convert.ToDouble(row["Cantidad"]);
                            row_["vIva_"] = ((Convert.ToDouble(row["ValorMenosDescto"]) * UseObject.RemoveCharacter(row_["Iva"].ToString(), '%') / 100))
                                * Convert.ToDouble(row["Cantidad"]);

                            miTabla.Rows.Add(row_);
                        }
                        this.ValidarRetencion();
                        this.CalcularTotales();
                        this.RecargarGridview();

                        /*
                        RecargarGridview();
                        if (MiProveedor.IdRegimen == 1)
                        {
                            var totalIva_ = 0;
                            foreach (PanelTributario panelT in miPanelTributario)
                            {
                                totalIva_ = totalIva_ + Convert.ToInt32(UseObject.RemoveSeparatorMil(panelT.TxtTotalIva.Text));
                            }
                            txtIva.Text = totalIva_.ToString();
                        }
                        else
                        {
                            foreach (PanelTributario panel in miPanelTributario)
                            {
                                panelTributario.Controls.Remove(panel.PanelIva);
                                panelTributario.Controls.Remove(panel.TxtGravado);
                                panelTributario.Controls.Remove(panel.TxtTotalIva);
                            }
                            miPanelTributario.Clear();
                            txtIva.Text = "0";
                        }
                        ValidarRetencion();
                        RecargarRetencion();

                        txtTotal.Text = UseObject.InsertSeparatorMil(
                                          ((Convert.ToInt32(UseObject.RemoveSeparatorMil(txtSubTotal.Text)) -
                                          Convert.ToInt32(UseObject.RemoveSeparatorMil(txtRetencion.Text)) -
                                          Convert.ToInt32(UseObject.RemoveSeparatorMil(txtDescuento.Text))) +
                                          Convert.ToInt32(txtIva.Text)).ToString());
                        */
                    }
                }
                SuccessCambio = true;
                FinishProcessCambio();
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
                SuccessCambio = false;
                FinishProcessCambio();
            }
        }

        /// <summary>
        /// Finaliza las funciones del proceso de Cambio de Proveedor.
        /// </summary>
        private void FinishProcessCambio()
        {
            miOption.FrmProgressBar.barraProgreso.Style = ProgressBarStyle.Blocks;
            miOption.FrmProgressBar.Closed_ = false;
            miOption.FrmProgressBar.Close();
            this.Enabled = true;
            if (SuccessCambio)
            {
                ValidarRetencion();
                RecargarRetencion();
                OptionPane.MessageSuccess("Las operaciones se realizaron correctamente.");
            }
        }

        private bool ValidarNumero(string numero)
        {
            try
            {
                Convert.ToDouble(numero);
                return true;
            }
            catch (FormatException)
            {
                return false;
            }
        }

        /// <summary>
        /// Completa la secuencia de datos de un formulario de extención.
        /// </summary>
        /// <param name="args">Objeto que encapsula la información del formulario.</param>
        void CompletaEventos_Completo(CompletaArgumentosDeEventoEditProveedor args)
        {
            try
            {
                FormProducto = Convert.ToBoolean(args.MiObjeto);
            }
            catch { }
        }

        /// <summary>
        /// Completa la secuencia de datos de un formulario de estención.
        /// </summary>
        /// <param name="args">Objeto que encapsula la información del formulario.</param>
        void CompletaEventos_Completo(CompletaArgumentosDeEvento args)
        {
            try
            {
                if (AddColor)
                {
                    miTallaYcolor = (TallaYcolor)args.MiObjeto;
                    btnAgregar.Focus();
                    if (LoadColorSize)
                    {
                        btnAgregar_Click(this.btnAgregar, null);
                    }
                    AddColor = false;
                }
            }
            catch { }
            try
            {
                if (AddProveedor)
                {
                    var proveedor_ = (DTO.Clases.Proveedor)args.MiObjeto;
                    if (Convert.ToInt32(cbCriterio.SelectedValue).Equals(1))
                    {
                        txtCodigoProveedor.Text = proveedor_.CodigoInternoProveedor.ToString();
                    }
                    else
                    {
                        txtCodigoProveedor.Text = proveedor_.NitProveedor;
                    }

                    txtCodigoProveedor_KeyPress(null, new KeyPressEventArgs((char)Keys.Enter));
                    FormProveedor = false;
                    AddProveedor = false;
                }
            }
            catch { }

            try
            {
                FormProveedor = Convert.ToBoolean(args.MiObjeto);
            }
            catch { }

            try
            {
                var egreso = (DTO.Clases.Egreso)args.MiObjeto;
                //if (Convert.ToInt32(args.MiObjeto) == 10)
                if (EsFactura)
                {
                    if (Convert.ToInt32(cbRemision.SelectedValue).Equals(3))
                    {
                        DialogResult rta = MessageBox.Show("¿Desea visualizar la impresión del Documento Equivalente?", "Factura Proveedor",
                            MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                        if (rta.Equals(DialogResult.Yes))
                        {
                            PrintDocumento(true);
                        }
                        else
                        {
                            if (rta.Equals(DialogResult.No))
                            {
                                PrintDocumento(false);
                            }
                        }
                        if (Convert.ToInt32(txtNumeroFactura.Text) < 99)
                        {
                            AppConfiguracion.SaveConfiguration
                                ("documento", IncrementaConsecutivo(txtNumeroFactura.Text));
                        }
                        else
                        {
                            AppConfiguracion.SaveConfiguration
                                ("documento", (Convert.ToInt32(txtNumeroFactura.Text) + 1).ToString());
                        }
                    }
                    PrintEgreso(egreso);
                }
                LimpiarFormulario();
            }
            catch { }
        }

        void CompletaEventos_CompAxTInvFactProvee(CompletaTransInvFactProvee args)
        {
            try
            {
                var producto = (DTO.Clases.Producto)args.MiObjeto;
                txtCodigoArticulo.Text = producto.CodigoInternoProducto;
                txtCodigoArticulo_KeyPress(this.txtCodigoArticulo, new KeyPressEventArgs((char)Keys.Enter));
            }
            catch { }

            try
            {
                FormInventario = Convert.ToBoolean(args.MiObjeto);
            }
            catch { }
        }

        /// <summary>
        /// Completa la secuencia de datos de un formulario de estencion.
        /// </summary>
        /// <param name="args">Objeto que encapsula la información del formulario.</param>
        void CompletaEventosm_Completo(CompletaArgumentosDeEventom args)
        {
            try
            {
                var producto = (DTO.Clases.Producto)args.MiMarca;
                txtCodigoArticulo.Text = producto.CodigoInternoProducto;
                txtCodigoArticulo_KeyPress(null, new KeyPressEventArgs((char)Keys.Enter));
            }
            catch { }
        }

        List<RetencionConcepto> Retenciones { set; get; }

        void CompletaEventos_Completabo(CompletaArgumentosDeEventobo args)
        {
            try
            {
                Retenciones = Retenciones = (List<RetencionConcepto>)args.MiBodegabo;
            }
            catch { }

            try
            {
                if (args.MiBodegabo.ToString().Equals("Porcentaje"))
                {
                    AplicaPorcentaje = true;
                }
                else
                {
                    AplicaPorcentaje = false;
                }

                CostoProducto = Convert.ToInt32(args.MiBodegabo);
            }
            catch { }
        }

        /// <summary>
        /// Verifica si el texto ingresado equivale a un número o palabra. Retorna true si es un número.
        /// </summary>
        /// <returns></returns>
        private bool CodigoOrString(string codigo)
        {
            try
            {
                Convert.ToInt64(codigo);
                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Valida el texto ingresado como codigo del producto.
        /// </summary>
        /// <returns></returns>
        private bool ValidarCodigo()
        {
            bool resultado = false;
            if (!Validacion.EsVacio(txtCodigoArticulo, MiError, CodigoProductoReq))
            {
                if (Validacion.ConFormato(
                    Validacion.TipoValidacion.LetrasGuionNumeros, txtCodigoArticulo, MiError, CodigoProductoFormato))
                {
                    resultado = true;
                }
            }
            return resultado;
        }

        /// <summary>
        /// Valida el texto ingresado como codigo de barras del producto.
        /// </summary>
        /// <returns></returns>
        private bool ValidarCodigoBarras()
        {
            bool resultado = false;
            if (!Validacion.EsVacio(txtCodigoArticulo, MiError, CodigoProductoReq))
            {
                if (Validacion.ConFormato(
                    Validacion.TipoValidacion.Numeros, txtCodigoArticulo, MiError, CodigoProductoFormato))
                {
                    resultado = true;
                }
            }
            return resultado;
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
        /// <param name="codigo">Codigo del Producto a cargar.</param>
        private void CargarProducto(string codigo)
        {
            try
            {
                ArrayProducto = miBussinesProducto.ProductoBasico(codigo);
                MiProducto = (DTO.Clases.Producto)ArrayProducto[0];

                if (!(MiProducto.IdTipoInventario.Equals(IdTipoInventarioProductoNoFabricado) ||
                    MiProducto.IdTipoInventario.Equals(IdTipoInventarioProductoFabricado)))
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
                            miTallaYcolor.IdTalla = Convert.ToInt32(q["idvalor_unidad_medida"]);
                            miTallaYcolor.Talla = q["descripcionvalor_unidad_medida"].ToString();
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
                            if (tablaColor.Rows.Count.Equals(1))
                            {
                                var c = (from d in tablaColor.AsEnumerable()
                                         select d).Single();
                                miTallaYcolor.IdColor = Convert.ToInt32(c["idcolor"]);
                                miTallaYcolor.Color = (Image)c["ImagenBit"];
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
                    //txtCosto.Text = miBussinesProducto.PrecioDeCosto(MiProducto.CodigoInternoProducto).ToString();
                    if (!SingleSize || !SingleColor)
                    {
                        btnTallaYcolor.Enabled = true;
                    }
                    else
                    {
                        btnTallaYcolor.Enabled = false;
                    }

                }
                else
                {
                    OptionPane.MessageInformation("Este producto no se puede comprar.");
                }
                /* if (!MiProducto.AplicaTalla && !MiProducto.AplicaColor)
                 {
                     btnTallaYcolor.Enabled = false;
                 }
                 else
                 {
                     //if (!SingleSize || !SingleColor)
                     //{
                         btnTallaYcolor.Enabled = true;
                     //}
                 }*/
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
        }

        private void IniciarCambioDescuento()
        {
        }

        private void CambiarDescuento()//revisar...
        {
            var table = miTabla.Copy();
            miTabla.Clear();
            Contador = 0;
            txtSubTotal.Text = "0";
            txtDescuento.Text = "0";
            txtIva.Text = "0";
            txtTotal.Text = "0";
            foreach (PanelTributario panel in miPanelTributario)
            {
                panelTributario.Controls.Remove(panel.PanelIva);
                panelTributario.Controls.Remove(panel.TxtGravado);
                panelTributario.Controls.Remove(panel.TxtTotalIva);
            }
            miPanelTributario.Clear();
            foreach (DataRow row in table.Rows)
            {
                MiProducto = new Producto();
                MiProducto.CodigoInternoProducto = row["Codigo"].ToString();
                MiProducto.NombreProducto = row["Producto"].ToString();
                txtCantidad.Text = row["Cantidad"].ToString();
                txtValorUnitario.Text = row["ValorUnitario"].ToString();
                //MiProducto.IdIva = Convert.ToInt32(row["IdIva"]);
                MiProducto.ValorIva = UseObject.RemoveCharacter(row["Iva"].ToString(), '%');
                if (row["Unidad"].ToString().Equals("Talla"))
                {
                    MiProducto.AplicaTalla = true;
                    miTallaYcolor.IdTalla = Convert.ToInt32(row["IdMedida"]);
                    miTallaYcolor.Talla = row["Medida"].ToString();
                }
                else
                {
                    MiProducto.AplicaTalla = false;
                    miMedida.DescripcionUnidadMedida = row["Unidad"].ToString();
                    miMedida.IdValorUnidadMedida = Convert.ToInt32(row["IdMedida"]);
                    miMedida.DescripcionValorUnidadMedida = row["Medida"].ToString();
                }
                if (Convert.ToInt32(row["IdColor"]).Equals(0))
                {
                    MiProducto.AplicaColor = false;
                }
                else
                {
                    MiProducto.AplicaColor = true;
                    miTallaYcolor.IdColor = Convert.ToInt32(row["IdColor"]);
                    miTallaYcolor.Color = (Image)row["Color"];
                }
                Lote = row["Lote"].ToString();
                /*if (DesctoProducto)
                {
                    txtDescuentoProducto.Text = UseObject.RemoveCharacter(row["Descuento"].ToString(), '%').ToString();
                }*/
                /*else//es pasable....
                {
                    txtDescuentoProducto.Text = txtDescuentoFactura.Text;
                }*/
                EstructurarConsulta2();
            }
        }

        private void FinishCambioDescuento()
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="fecha"></param>
        /// <returns></returns>
        private string CambiarSeparadorFecha(string fecha)
        {
            var miFecha = fecha.Split('/');
            string fechaResult = miFecha[0] + miFecha[1] + miFecha[2];
            return fechaResult;
        }

        /// <summary>
        /// Estructura la informacion en la tabla de memora para ser visualizada.
        /// </summary>
        private void EstructurarConsulta()
        {
            Contador++;
            if (ArrayProducto.Count > 0)
            {
                DataRow row = miTabla.NewRow();
                row["Id"] = Contador;
                row["Codigo"] = MiProducto.CodigoInternoProducto;
                row["Producto"] = MiProducto.NombreProducto;
                txtCantidad.Text = txtCantidad.Text.Replace('.', ',');
                txtValorUnitario.Text = txtValorUnitario.Text.Replace('.', ',');
                row["Cantidad"] = Convert.ToDouble(txtCantidad.Text);
                if (chkIva.Checked)
                {
                    row["ValorUnitario"] = Math.Round(Convert.ToDouble(
                        Convert.ToDouble(txtValorUnitario.Text) / (1 + (MiProducto.ValorIva / 100))), 0);
                }
                else
                {
                    row["ValorUnitario"] = Convert.ToDouble(txtValorUnitario.Text);
                }
                var data = row["ValorUnitario"].ToString();

                if (rbtnDesctoProducto.Checked)
                {
                    row["Descuento"] = txtDescuentoProducto.Text + "%";
                }
                else
                {
                    row["Descuento"] = txtDescuentoFactura.Text + "%";
                }
                row["Descto_"] = Math.Round(
                    ((Convert.ToDouble(row["ValorUnitario"]) * UseObject.RemoveCharacter(row["Descuento"].ToString(), '%') / 100) *
                      Convert.ToDouble(row["Cantidad"])), 2);
                data = Math.Round(
                       (Convert.ToDouble(row["ValorUnitario"]) * UseObject.RemoveCharacter(row["Descuento"].ToString(), '%') / 100), 2).ToString();
                data = row["Descto_"].ToString();

                row["ValorMenosDescto"] = Math.Round((Convert.ToDouble(row["ValorUnitario"]) -
                    (Convert.ToDouble(row["ValorUnitario"]) * UseObject.RemoveCharacter(row["Descuento"].ToString(), '%') / 100)), 2);
                data = row["ValorMenosDescto"].ToString();

                //row["IdIva"] = MiProducto.IdIva;
                row["Iva"] = MiProducto.ValorIva.ToString() + "%";
                if (MiProveedor.IdRegimen == 1)  //Regimen Comun
                {
                    InformacionTributaria(MiProducto.ValorIva, txtCantidad.Text, row["ValorMenosDescto"].ToString());
                }
              /*  if (MiProveedor.IdRegimen == 1)  //Regimen Comun
                {
                    row["Iva"] = MiProducto.ValorIva.ToString() + "%";
                    InformacionTributaria(MiProducto.ValorIva, txtCantidad.Text, row["ValorMenosDescto"].ToString());
                }
                else
                {
                    row["Iva"] = 0 + "%";
                }*/
                row["vIva_"] = Math.Round((Convert.ToDouble(row["ValorMenosDescto"]) *
                    UseObject.RemoveCharacter(row["Iva"].ToString(), '%') / 100), 2);
                data = row["vIva_"].ToString();

                row["TotalMasIva"] = Convert.ToDouble(row["ValorMenosDescto"]) + Convert.ToDouble(row["vIva_"]);
                data = row["TotalMasIva"].ToString();

                row["vIva_"] = Math.Round(((Convert.ToDouble(row["ValorMenosDescto"]) *
                                UseObject.RemoveCharacter(row["Iva"].ToString(), '%') / 100) *
                                Convert.ToDouble(row["Cantidad"])), 2);
                data = row["vIva_"].ToString();

                row["Valor"] = Math.Round(
                    (Convert.ToDouble(row["TotalMasIva"]) * Convert.ToDouble(row["Cantidad"])), 2);
                data = row["Valor"].ToString();

                if (MiProducto.AplicaTalla)
                {
                    row["Unidad"] = "Talla";
                    row["IdMedida"] = miTallaYcolor.IdTalla;
                    row["Medida"] = miTallaYcolor.Talla;
                }
                else
                {
                    row["Unidad"] = miMedida.DescripcionUnidadMedida;
                    row["IdMedida"] = miMedida.IdValorUnidadMedida;
                    row["Medida"] = miMedida.DescripcionValorUnidadMedida;
                }
                if (MiProducto.AplicaColor)
                {
                    row["IdColor"] = miTallaYcolor.IdColor;
                    row["Color"] = miTallaYcolor.Color;
                }
                else
                {
                    row["IdColor"] = 0;
                    row["Color"] = null;
                }
                row["Lote"] = Lote;

                row["Valor_"] = Convert.ToDouble(row["ValorUnitario"]) +
                    (Convert.ToDouble(row["ValorUnitario"]) * UseObject.RemoveCharacter(row["Iva"].ToString(), '%') / 100);

                var valorMenDescto = Convert.ToInt32(Convert.ToDouble(row["ValorUnitario"]) -
                    (Convert.ToDouble(row["ValorUnitario"]) * UseObject.RemoveCharacter(row["Descuento"].ToString(), '%') / 100));

                row["Total_"] = (valorMenDescto + (valorMenDescto * UseObject.RemoveCharacter(row["Iva"].ToString(), '%') / 100))
                    * Convert.ToDouble(row["Cantidad"]);

                row["Sub_Total"] = Convert.ToDouble(row["ValorUnitario"]) * Convert.ToDouble(row["Cantidad"]);

                row["vIva_"] = ((Convert.ToDouble(row["ValorMenosDescto"]) * UseObject.RemoveCharacter(row["Iva"].ToString(), '%') / 100))
                    * Convert.ToDouble(row["Cantidad"]);

                txtSubTotal.Text = UseObject.InsertSeparatorMil(
                                   Math.Round(
                                   Convert.ToDouble
                                   (UseObject.RemoveSeparatorMil(txtSubTotal.Text) +
                                    (Convert.ToDouble(row["ValorUnitario"]) * Convert.ToDouble(row["Cantidad"]))
                                   ), 0).ToString());

                txtDescuento.Text = UseObject.InsertSeparatorMil(Convert.ToInt32(
                    UseObject.RemoveSeparatorMil(txtDescuento.Text) + Convert.ToDouble(row["Descto_"])).ToString());

                RecargarRetencion();

                txtIva.Text = UseObject.InsertSeparatorMil(Convert.ToInt32(
                    UseObject.RemoveSeparatorMil(txtIva.Text) + Convert.ToDouble(row["vIva_"])).ToString());

                txtTotal.Text = UseObject.InsertSeparatorMil(
                                 Convert.ToInt64
                                ((UseObject.RemoveSeparatorMil(txtSubTotal.Text) -
                                  UseObject.RemoveSeparatorMil(txtDescuento.Text) -
                                  UseObject.RemoveSeparatorMil(txtRetencion.Text)) +
                                  UseObject.RemoveSeparatorMil(txtIva.Text)).ToString());

                miTabla.Rows.Add(row);
                RecargarGridview();
                ActualizarLote();
                LimpiarCampos();
                dgvListaArticulos_CellClick(this.dgvListaArticulos, null);



                /*DataRow row = miTabla.NewRow();
                row["Id"] = Contador;
                row["Codigo"] = MiProducto.CodigoInternoProducto;
                row["Producto"] = MiProducto.NombreProducto;
                txtCantidad.Text = txtCantidad.Text.Replace('.', ',');
                txtValorUnitario.Text = txtValorUnitario.Text.Replace('.', ',');
                row["Cantidad"] = Convert.ToDouble(txtCantidad.Text);
                var cantidad = row["Cantidad"].ToString();
                if (chkIva.Checked)
                {
                    row["ValorUnitario"] =
                        Math.Round(
                        Convert.ToDouble(
                        Convert.ToDouble(txtValorUnitario.Text) / (1 + (MiProducto.ValorIva / 100))),
                        2);
                }
                else
                {
                    row["ValorUnitario"] = Math.Round(
                        Convert.ToDouble(txtValorUnitario.Text), 2);
                }
                var j = Convert.ToDouble(row["ValorUnitario"]);
                //row["ValorUnitario"] = txtValorUnitario.Text;
                if (rbtnDesctoProducto.Checked)
                {
                    row["Descuento"] = txtDescuentoProducto.Text + "%";
                }
                else
                {
                    row["Descuento"] = txtDescuentoFactura.Text + "%";
                }
                var v_desct = Math.Round(
                     Convert.ToDouble(Convert.ToDouble(row["ValorUnitario"]) -
                    (Convert.ToDouble(row["ValorUnitario"]) * UseObject.RemoveCharacter(row["Descuento"].ToString(), '%') / 100)), 2);

                var des = UseObject.RemoveCharacter(row["Descuento"].ToString(), '%');

                row["ValorMenosDescto"] = //Math.Round(
                     Convert.ToDouble(Convert.ToDouble(row["ValorUnitario"]) -
                    (Convert.ToDouble(row["ValorUnitario"]) * UseObject.RemoveCharacter(row["Descuento"].ToString(), '%') / 100));//, 2);

                var val_des = row["ValorMenosDescto"].ToString();
                if (MiProveedor.IdRegimen == 1)  //Regimen Comun
                {
                    row["Iva"] = MiProducto.ValorIva.ToString() + "%";
                    InformacionTributaria(MiProducto.ValorIva, txtCantidad.Text, row["ValorMenosDescto"].ToString());
                }
                else
                {
                    row["Iva"] = 0 + "%";
                }

                row["TotalMasIva"] = Convert.ToInt32(
                                      ((Convert.ToDouble(row["ValorMenosDescto"]) *
                                      UseObject.RemoveCharacter(row["Iva"].ToString(), '%') / 100)) +
                                      Convert.ToDouble(row["ValorMenosDescto"]));
                var totalMasIVa = row["TotalMasIva"].ToString();

                row["Valor"] = Math.Round(
                               Convert.ToDouble(row["TotalMasIva"]) *
                               Convert.ToDouble(txtCantidad.Text), 0);
                var valor = row["Valor"].ToString();

                if (MiProducto.AplicaTalla)
                {
                    row["Unidad"] = "Talla";
                    row["IdMedida"] = miTallaYcolor.IdTalla;
                    row["Medida"] = miTallaYcolor.Talla;
                }
                else
                {
                    row["Unidad"] = miMedida.DescripcionUnidadMedida;
                    row["IdMedida"] = miMedida.IdValorUnidadMedida;
                    row["Medida"] = miMedida.DescripcionValorUnidadMedida;
                }
                if (MiProducto.AplicaColor)
                {
                    row["IdColor"] = miTallaYcolor.IdColor;
                    row["Color"] = miTallaYcolor.Color;
                }
                else
                {
                    row["IdColor"] = 0;
                    row["Color"] = null;
                }
                row["Lote"] = Lote;

                row["Valor_"] = Convert.ToDouble(row["ValorUnitario"]) +
                    (Convert.ToDouble(row["ValorUnitario"]) * UseObject.RemoveCharacter(row["Iva"].ToString(), '%') / 100);
                var valor_ = row["Valor_"].ToString();

                var valorMenDescto = Convert.ToInt32(Convert.ToDouble(row["ValorUnitario"]) -
                    (Convert.ToDouble(row["ValorUnitario"]) * UseObject.RemoveCharacter(row["Descuento"].ToString(), '%') / 100));

                row["Total_"] = (valorMenDescto + (valorMenDescto * UseObject.RemoveCharacter(row["Iva"].ToString(), '%') / 100))
                    * Convert.ToDouble(row["Cantidad"]);
                var total_ = row["Total_"].ToString();

                row["Sub_Total"] = Convert.ToDouble(row["ValorUnitario"]) * Convert.ToDouble(row["Cantidad"]);
                var sub_total = row["Sub_Total"].ToString();


                row["Descto_"] = (Convert.ToDouble(row["ValorUnitario"]) * UseObject.RemoveCharacter(row["Descuento"].ToString(), '%') / 100)
                    * Convert.ToDouble(row["Cantidad"]);
                var descto_ = row["Descto_"].ToString();

                var vunit = Convert.ToDouble(row["ValorUnitario"]);
                var cant = Convert.ToDouble(row["Cantidad"]);
                row["vIva_"] = ((Convert.ToDouble(row["ValorMenosDescto"]) * UseObject.RemoveCharacter(row["Iva"].ToString(), '%') / 100))
                    * Convert.ToDouble(row["Cantidad"]);
                var valorIva = row["vIva_"].ToString();

                txtSubTotal.Text = UseObject.InsertSeparatorMil(
                                   Math.Round(
                                   Convert.ToDouble
                                   (UseObject.RemoveSeparatorMil(txtSubTotal.Text) +
                                    (Convert.ToDouble(row["ValorUnitario"]) * Convert.ToDouble(txtCantidad.Text))
                                   ), 0).ToString());

                RecargarRetencion();

                txtDescuento.Text = UseObject.InsertSeparatorMil
                    (Convert.ToInt32
                     (Convert.ToDecimal(UseObject.RemoveSeparatorMil(txtDescuento.Text)) +
                     (Convert.ToDecimal(row["ValorUnitario"]) - Convert.ToDecimal(row["ValorMenosDescto"])) *
                      Convert.ToDecimal(row["Cantidad"])).ToString()
                    );
                valorIva = row["vIva_"].ToString();
                MiValorIVA += Convert.ToDouble(row["vIva_"]);
                txtIva.Text = UseObject.InsertSeparatorMil(Convert.ToInt32(MiValorIVA).ToString());

                txtTotal.Text = UseObject.InsertSeparatorMil(
                                 Convert.ToInt64
                                ((UseObject.RemoveSeparatorMil(txtSubTotal.Text) -
                                  UseObject.RemoveSeparatorMil(txtDescuento.Text) -
                                  UseObject.RemoveSeparatorMil(txtRetencion.Text)) +
                                  UseObject.RemoveSeparatorMil(txtIva.Text)).ToString());

                miTabla.Rows.Add(row);
                RecargarGridview();
                ActualizarLote();
                LimpiarCampos();
                dgvListaArticulos_CellClick(this.dgvListaArticulos, null);*/
            }
        }

        private void EstructurarConsulta2()
        {
            Contador++;
            if (ArrayProducto.Count > 0)
            {
                DataRow row = miTabla.NewRow();
                row["Id"] = Contador;
                row["Codigo"] = MiProducto.CodigoInternoProducto;
                row["Producto"] = MiProducto.NombreProducto;
                txtCantidad.Text = txtCantidad.Text.Replace('.', ',');
                txtValorUnitario.Text = txtValorUnitario.Text.Replace('.', ',');
                row["Cantidad"] = Convert.ToDouble(txtCantidad.Text);
                if (chkIva.Checked)
                {
                    row["ValorUnitario"] = Math.Round(Convert.ToDouble(
                        Convert.ToDouble(txtValorUnitario.Text) / (1 + (MiProducto.ValorIva / 100))), 2); // Change
                }
                else
                {
                    row["ValorUnitario"] = Convert.ToDouble(txtValorUnitario.Text);
                }
                var data = row["ValorUnitario"].ToString();

                if (rbtnDesctoProducto.Checked)
                {
                    row["Descuento"] = txtDescuentoProducto.Text + "%";
                }
                else
                {
                    row["Descuento"] = txtDescuentoFactura.Text + "%";
                }
                row["Descto_"] = Math.Round(
                    ((Convert.ToDouble(row["ValorUnitario"]) * UseObject.RemoveCharacter(row["Descuento"].ToString(), '%') / 100) *
                      Convert.ToDouble(row["Cantidad"])), 2);
                data = Math.Round(
                       (Convert.ToDouble(row["ValorUnitario"]) * UseObject.RemoveCharacter(row["Descuento"].ToString(), '%') / 100), 2).ToString();
                data = row["Descto_"].ToString();

                row["ValorMenosDescto"] = Math.Round((Convert.ToDouble(row["ValorUnitario"]) -
                    (Convert.ToDouble(row["ValorUnitario"]) * UseObject.RemoveCharacter(row["Descuento"].ToString(), '%') / 100)), 2);
                data = row["ValorMenosDescto"].ToString();

                //row["IdIva"] = MiProducto.IdIva;
               /* row["Iva"] = MiProducto.ValorIva.ToString() + "%";
                if (MiProveedor.IdRegimen == 1)  //Regimen Comun
                {
                    InformacionTributaria(MiProducto.ValorIva, txtCantidad.Text, row["ValorMenosDescto"].ToString());
                }*/
                if (MiProveedor.IdRegimen == 1)  //Regimen Comun
                {
                    row["Iva"] = MiProducto.ValorIva.ToString() + "%";
                    InformacionTributaria(MiProducto.ValorIva, txtCantidad.Text, row["ValorMenosDescto"].ToString());
                }
                else
                {
                    row["Iva"] = 0 + "%";
                }
                row["vIva_"] = Math.Round((Convert.ToDouble(row["ValorMenosDescto"]) *
                    UseObject.RemoveCharacter(row["Iva"].ToString(), '%') / 100), 2);
                data = row["vIva_"].ToString();

                row["TotalMasIva"] = Convert.ToDouble(row["ValorMenosDescto"]) + Convert.ToDouble(row["vIva_"]);
                data = row["TotalMasIva"].ToString();

                row["vIva_"] = Math.Round(((Convert.ToDouble(row["ValorMenosDescto"]) *
                                UseObject.RemoveCharacter(row["Iva"].ToString(), '%') / 100) *
                                Convert.ToDouble(row["Cantidad"])), 2);
                data = row["vIva_"].ToString();

                row["Valor"] = Math.Round(
                    (Convert.ToDouble(row["TotalMasIva"]) * Convert.ToDouble(row["Cantidad"])), 0);  // Change
                data = row["Valor"].ToString();

                row["IdTipoInventario"] = MiProducto.IdTipoInventario;
                row["Presentacion"] = MiProducto.UnidadVentaProducto;

                if (MiProducto.AplicaTalla)
                {
                    row["Unidad"] = "Talla";
                    row["IdMedida"] = miTallaYcolor.IdTalla;
                    row["Medida"] = miTallaYcolor.Talla;
                }
                else
                {
                    row["Unidad"] = miMedida.DescripcionUnidadMedida;
                    row["IdMedida"] = miMedida.IdValorUnidadMedida;
                    row["Medida"] = miMedida.DescripcionValorUnidadMedida;
                }
                if (MiProducto.AplicaColor)
                {
                    row["IdColor"] = miTallaYcolor.IdColor;
                    row["Color"] = miTallaYcolor.Color;
                }
                else
                {
                    row["IdColor"] = 0;
                    row["Color"] = null;
                }
                row["Lote"] = Lote;

                row["Valor_"] = Convert.ToDouble(row["ValorUnitario"]) +
                    (Convert.ToDouble(row["ValorUnitario"]) * UseObject.RemoveCharacter(row["Iva"].ToString(), '%') / 100);

                var valorMenDescto = Convert.ToInt32(Convert.ToDouble(row["ValorUnitario"]) -
                    (Convert.ToDouble(row["ValorUnitario"]) * UseObject.RemoveCharacter(row["Descuento"].ToString(), '%') / 100));

                row["Total_"] = (valorMenDescto + (valorMenDescto * UseObject.RemoveCharacter(row["Iva"].ToString(), '%') / 100))
                    * Convert.ToDouble(row["Cantidad"]);

                row["Sub_Total"] = Convert.ToDouble(row["ValorUnitario"]) * Convert.ToDouble(row["Cantidad"]);

                row["vIva_"] = ((Convert.ToDouble(row["ValorMenosDescto"]) * UseObject.RemoveCharacter(row["Iva"].ToString(), '%') / 100))
                    * Convert.ToDouble(row["Cantidad"]);

               /* txtSubTotal.Text = UseObject.InsertSeparatorMil(
                                   Math.Round(
                                   Convert.ToDouble
                                   (UseObject.RemoveSeparatorMil(txtSubTotal.Text) +
                                    (Convert.ToDouble(row["ValorUnitario"]) * Convert.ToDouble(row["Cantidad"]))
                                   ), 0).ToString());

                txtDescuento.Text = UseObject.InsertSeparatorMil(Convert.ToInt32(
                    UseObject.RemoveSeparatorMil(txtDescuento.Text) + Convert.ToDouble(row["Descto_"])).ToString());

                RecargarRetencion();

                txtIva.Text = UseObject.InsertSeparatorMil(Convert.ToInt32(
                    UseObject.RemoveSeparatorMil(txtIva.Text) + Convert.ToDouble(row["vIva_"])).ToString());

                txtTotal.Text = UseObject.InsertSeparatorMil(
                                 Convert.ToInt64
                                ((UseObject.RemoveSeparatorMil(txtSubTotal.Text) -
                                  UseObject.RemoveSeparatorMil(txtDescuento.Text) -
                                  UseObject.RemoveSeparatorMil(txtRetencion.Text)) +
                                  UseObject.RemoveSeparatorMil(txtIva.Text)).ToString());*/
                
                miTabla.Rows.Add(row);

                this.CalcularTotales();

                RecargarGridview();
                ActualizarLote();
                LimpiarCampos();
                dgvListaArticulos_CellClick(this.dgvListaArticulos, null);
            }
        }
        double MiValorIVA = 0.0;


        /// <summary>
        /// Carga y muestra la informacion tributaria del producto solicitado.
        /// </summary>
        /// <param name="iva">Iva a cargar del producto solicitado.</param>
        /// <param name="cantidad">Cantidad a cargar del Producto solicitado.</param>
        /// <param name="valorUnit">Valor unitario del Producto solicitado.</param>
        private void InformacionTributaria(double iva, string cantidad, string valorUnit)
        {
            try
            {
                var PanelName = "panelIva" + iva.ToString();
                var existe = 0;
                foreach (PanelTributario p in miPanelTributario)
                {
                    if (p.PanelIva.Name.Equals(PanelName))
                    {
                        var ivaGravado = UseObject.RemoveSeparatorMil(p.TxtGravado.Text);
                        p.TxtGravado.Text = UseObject.InsertSeparatorMil(
                                             Math.Round
                                            (ivaGravado + (Convert.ToDouble(cantidad) *
                                             Convert.ToDouble(valorUnit)), 0).ToString());

                        p.TxtTotalIva.Text = UseObject.InsertSeparatorMil(
                            UseObject.AproximacionDian(
                            Math.Round(
                            Convert.ToDouble
                            (p.Iva * UseObject.RemoveSeparatorMil(p.TxtGravado.Text) / 100), 0)).ToString());

                        existe = 2;
                        break;
                    }
                    else
                    {
                        existe = 1;
                    }
                }
                if (existe == 0)      ///No existe ningun panel.
                {
                    CargarDatosTributarios(iva, cantidad, valorUnit, true, 0);
                }
                else
                {
                    if (existe == 1)  ///No existe el panel buscado.
                    {
                        var panel_ = miPanelTributario[miPanelTributario.Count - 1];
                        CargarDatosTributarios(iva, cantidad, valorUnit, false,
                            panel_.PanelIva.Location.X);

                        if (panel_.PanelIva.Location.X >= 279)
                        {
                            panelTributario.AutoScroll = true;
                            if (panelTributario.AutoScrollMargin.Width < 10 ||
                                panelTributario.AutoScrollMargin.Height < 10)
                            {
                                panelTributario.SetAutoScrollMargin(10, 0);
                            }
                        }
                    }
                }
            }
            catch
            {
            }
        }

        /// <summary>
        /// Carga los datos tributarios en los paneles y textos especificados.
        /// </summary>
        /// <param name="iva">Iva del producto a cargar.</param>
        /// <param name="cantidad"></param>
        /// <param name="valorUnit"></param>
        /// <param name="first">Indica si es el primer panel de la lista.</param>
        /// <param name="location_x">Posicion en pixeles del ultimo panel cargado.</param>
        private void CargarDatosTributarios
            (double iva, string cantidad, string valorUnit, bool first, int location_x)
        {
            var classMiPanelTributario = new PanelTributario();

            var miPanel = CrearPanel(iva, first, location_x);
            panelTributario.Controls.Add(miPanel);

            var lstTexBox = CrearTexbox(iva, first, location_x);

            ///txtGravado
            lstTexBox[0].Text = UseObject.InsertSeparatorMil(
                                 Math.Round
                                (Convert.ToDouble(cantidad) *
                                 Convert.ToDouble(valorUnit), 0).ToString());

            ///txtTotaliva
            lstTexBox[1].Text = UseObject.InsertSeparatorMil(
                UseObject.AproximacionDian(
                Math.Round(
                Convert.ToDouble
                ((iva * Convert.ToDouble(lstTexBox[0].Text)) / 100), 0)).ToString());

            panelTributario.Controls.Add(lstTexBox[0]);
            panelTributario.Controls.Add(lstTexBox[1]);

            classMiPanelTributario.Iva = iva;
            classMiPanelTributario.PanelIva = miPanel;
            classMiPanelTributario.TxtGravado = lstTexBox[0];
            classMiPanelTributario.TxtTotalIva = lstTexBox[1];
            miPanelTributario.Add(classMiPanelTributario);
        }

        /// <summary>
        /// Crea y carga un panel en el fomulario.
        /// </summary>
        /// <param name="iva">Iva del producto solicitado.</param>
        /// <param name="first">Indica si es el primer panel de la lista.</param>
        /// <param name="location_x">Posicion en pixeles del ultimo panel cargado.</param>
        /// <returns></returns>
        private Panel CrearPanel(double iva, bool first, int location_x)
        {
            var panel = new Panel();
            panel.BackColor = SystemColors.ControlLight;
            panel.BorderStyle = BorderStyle.FixedSingle;
            panel.Size = new Size(100, 25);
            panel.Name = "panelIva" + iva.ToString();
            panel.Controls.Add(CrearLabel(iva));
            if (first)
            {
                panel.Location = new Point(81, 8);
            }
            else
            {
                panel.Location = new Point(location_x + 99, 8);
            }
            return panel;
        }

        /// <summary>
        /// Crea una Etiqueta de texto (Label).
        /// </summary>
        /// <param name="iva">Iva del producto solicitado.</param>
        /// <returns></returns>
        private Label CrearLabel(double iva)
        {
            var lbl = new Label();
            lbl.AutoSize = true;
            lbl.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Bold,
                GraphicsUnit.Point, ((byte)(0)));
            lbl.Location = new Point(34, 4);
            lbl.Name = "lblIva" + iva.ToString();
            lbl.Size = new Size(29, 16);
            lbl.TabIndex = 0;
            lbl.Text = iva.ToString() + "%";
            return lbl;
        }

        /// <summary>
        /// Obtiene una lista de TextBox.
        /// </summary>
        /// <param name="iva">Iva del producto solicitado.</param>
        /// <param name="first">Indica si es el primer panel de la lista.</param>
        /// <param name="location_x">Posicion en pixeles del ultimo panel cargado.</param>
        /// <returns></returns>
        private List<TextBox> CrearTexbox(double iva, bool first, int location_x)
        {
            var txtGravado = NewTexbox();
            txtGravado.Name = "txtIvaGravado" + iva.ToString();
            var txtTotalIva = NewTexbox();
            txtTotalIva.Name = "txtTotalIva" + iva.ToString();
            if (first)
            {
                txtGravado.Location = new Point(81, 32);
                txtTotalIva.Location = new Point(81, 53);
            }
            else
            {
                txtGravado.Location = new Point(location_x + 99, 32);
                txtTotalIva.Location = new Point(location_x + 99, 53);
            }
            var lista = new List<TextBox>();
            lista.Add(txtGravado);
            lista.Add(txtTotalIva);
            return lista;
        }

        /// <summary>
        /// Obtiene un nuevo TextBox.
        /// </summary>
        /// <returns></returns>
        private TextBox NewTexbox()
        {
            var texbox = new TextBox();
            texbox.BackColor = SystemColors.Window;
            texbox.BorderStyle = BorderStyle.FixedSingle;
            texbox.ReadOnly = true;
            texbox.TextAlign = HorizontalAlignment.Right;
            texbox.Size = new System.Drawing.Size(100, 22);
            return texbox;
        }

        private void CalcularTotales()
        {
            this.txtSubTotal.Text = UseObject.InsertSeparatorMil(Convert.ToInt32(
                this.miTabla.AsEnumerable().Sum(s => (s.Field<double>("ValorUnitario") * s.Field<double>("Cantidad")))).ToString());

            int descto = 0;
            foreach (DataRow tRow in this.miTabla.Rows)
            {
                descto += Convert.ToInt32(tRow["Descto_"]);
            }
            this.txtDescuento.Text = UseObject.InsertSeparatorMil(descto.ToString());

            this.RecargarRetencion();

            this.txtIva.Text = UseObject.InsertSeparatorMil(Convert.ToInt32(
                this.miTabla.AsEnumerable().Sum(s => s.Field<double>("vIva_"))).ToString());

            this.txtTotal.Text = UseObject.InsertSeparatorMil(Convert.ToInt32(
                (UseObject.RemoveSeparatorMil(this.txtSubTotal.Text) -
                 UseObject.RemoveSeparatorMil(this.txtDescuento.Text) -
                 UseObject.RemoveSeparatorMil(this.txtRetencion.Text)) +
                 UseObject.RemoveSeparatorMil(this.txtIva.Text) +
                 UseObject.RemoveSeparatorMil(this.txtAjuste.Text)).ToString());
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

        /// <summary>
        /// Actualiza el registro del Lote generado y utilizado en un Producto.
        /// </summary>
        private void ActualizarLote()
        {
            if (LoteConsecutivo.ToString() == Lote)
            {
                LoteConsecutivo++;
            }
        }

        /// <summary>
        /// Limpia los campos de Producto del Formulario.
        /// </summary>
        private void LimpiarCampos()
        {
            this.txtCodigoArticulo.Focus();
            this.txtCodigoArticulo.Text = "";
            this.txtCantidad.Text = "";
            this.txtValorUnitario.Text = "";
            this.txtDescuentoProducto.Text = "0";
            lblDatosProducto.Text = "";
            txtLote.Text = "";
            Lote = "";
            MiProducto = null;
            miTallaYcolor.IdColor = 0;
            miTallaYcolor.IdTalla = 0;
            miTallaYcolor.Talla = "";
            miTallaYcolor.Color = null;
        }

        /// <summary>
        /// Limpia todos los campos y controles del formulario.
        /// </summary>
        private void LimpiarFormulario()
        {
            MiValorIVA = 0.0;
            txtCodigoProveedor.Text = "";
            txtNombreProveedor.Text = "";
            cbRemision.SelectedValue = 1;
            cbRemision_SelectionChangeCommitted(this.cbRemision, new EventArgs());
            cbFormaPago.SelectedValue = 1;
            cbFormaPago_SelectionChangeCommitted(this.cbFormaPago, new EventArgs());
            txtNumeroFactura.Text = "";
            dtpFechaLimite.Value = FechaHoy;
            while (miTabla.Rows.Count != 0)
            {
                miTabla.Rows.Clear();
            }
            while (dgvListaArticulos.RowCount != 0)
            {
                dgvListaArticulos.Rows.RemoveAt(0);
            }
            foreach (PanelTributario panel in miPanelTributario)
            {
                panelTributario.Controls.Remove(panel.PanelIva);
                panelTributario.Controls.Remove(panel.TxtGravado);
                panelTributario.Controls.Remove(panel.TxtTotalIva);
            }
            miPanelTributario.Clear();
            txtSubTotal.Text = "0";
            txtDescuento.Text = "0";
            txtRetencion.Text = "0";
            txtIva.Text = "0";
            txtTotal.Text = "0";
            txtAjuste.Text = "0";
            MiProveedor = null;
            txtCodigoProveedor.Focus();
            MiError.SetError(txtCodigoArticulo, null);
            MiError.SetError(txtDescuento, null);
            AplicaRete = false;
            lblTasaRetencion.Text = "0%";
            btnInfoRete.Enabled = false;
            miToolTip.SetToolTip(btnInfoRete, "");
            btnCambiarRetencion.Enabled = false;
            MiRetencion.Concepto = AppConfiguracion.ValorSeccion("concepto");
            MiRetencion.CifraUVT = Convert.ToDouble(AppConfiguracion.ValorSeccion("uvt"));
            MiRetencion.CifraPesos = Convert.ToInt32(AppConfiguracion.ValorSeccion("pesos"));
            MiRetencion.Tarifa = Convert.ToDouble(AppConfiguracion.ValorSeccion("tasa"));
            txtCosto.Text = "";
            txtUtilidad.Text = "";
            txtPrecioSugerido.Text = "";
            txtPrecioAprox.Text = "";
            txtPrecioVenta.Text = "";
            lblValorCostoAsig.Text = "0";
            lblValorCosto.Text = "0";
            lblVUtilidad.Text = "0";
            lblValorSugerido.Text = "0";
            lblValorAprox.Text = "0";
            lblValorVenta.Text = "0";
            while (dgRegistros.RowCount != 0)
            {
                dgRegistros.Rows.RemoveAt(0);
            }
        }

        private void PrintDocumento(bool view)
        {
            try
            {
                var frmPrintDocument = new FrmPrintFactura();
                frmPrintDocument.Tipo = miFactura.Tipo;
                frmPrintDocument.numero = miFactura.Numero;
                if (miFactura.EstadoFactura.Id.Equals(1))
                {
                    frmPrintDocument.Pago = "Contado";
                }
                else
                {
                    frmPrintDocument.Pago = "Crédito";
                }
                frmPrintDocument.Fecha = miFactura.FechaFactura;
                frmPrintDocument.Limite = miFactura.FechaLimite;
                var proveedor = miBussinesProveedor.ProveedorAEditar(MiProveedor.CodigoInternoProveedor);
                frmPrintDocument.Proveedor = proveedor.RazonSocialProveedor;
                frmPrintDocument.Nit = proveedor.NitProveedor;
                frmPrintDocument.Telefono = proveedor.CelularProveedor;
                frmPrintDocument.Direccion = proveedor.DireccionProveedor + " " + proveedor.Ciudad +
                                             " " + proveedor.Departamento;
                miTabla.TableName = "Detalle";
                frmPrintDocument.DsDetalle = miTabla;
                frmPrintDocument.Retencion = Convert.ToInt32(UseObject.RemoveSeparatorMil(this.txtRetencion.Text));
                
                if (view)
                {
                    frmPrintDocument.ShowDialog();
                }
                else
                {
                    var no = Convert.ToInt32(AppConfiguracion.ValorSeccion("copyCompra"));
                    Imprimir print = new Imprimir();
                    for (int i = 1; i <= no; i++)
                    {
                        print.Report = frmPrintDocument.CargarDatos();
                        print.Print(Imprimir.TamanioPapel.MediaCarta);
                        frmPrintDocument.ResetRepor();
                    }
                }
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
        }

        private void PrintEgreso(DTO.Clases.Egreso egreso)
        {
            DialogResult rta = MessageBox.Show("¿Desea imprimir el Comprobante de Egreso?", "Factura Proveedor",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rta.Equals(DialogResult.Yes))
            {
                var tabla = new DataTable();
                tabla.TableName = "CuentaPuc";
                tabla.Columns.Add(new DataColumn("Codigo", typeof(int)));
                tabla.Columns.Add(new DataColumn("Concepto", typeof(string)));
                tabla.Columns.Add(new DataColumn("Valor", typeof(int)));
                foreach (var cuenta in egreso.Cuentas)
                {
                    var row = tabla.NewRow();
                    row["Codigo"] = miBussinesPuc.GetSubCuenta(cuenta.IdCuenta);
                    row["Concepto"] = cuenta.Nombre;
                    row["Valor"] = Convert.ToInt32(cuenta.Numero);
                    tabla.Rows.Add(row);
                }
                var printEgreso = new Egreso.FrmPrintComprobante();
                printEgreso.MdiParent = this.MdiParent;
                printEgreso.Numero = egreso.Numero;
                printEgreso.Fecha = egreso.Fecha;
                printEgreso.Remite = MiProveedor.RazonSocialProveedor + "  CC o NIT: " + MiProveedor.NitProveedor;
                printEgreso.Cuentas = tabla;
                printEgreso.Cheque = egreso.Pagos.Where(p => p.IdFormaPago == 2).Sum(s => s.Valor).ToString();
                printEgreso.Efectivo = egreso.Pagos.Where(p => p.IdFormaPago == 1).Sum(s => s.Valor).ToString();
                //printEgreso.Cheque = egreso.Pagos.Single(p => p.IdFormaPago == 2).Valor.ToString();
                //printEgreso.Efectivo = egreso.Pagos.Single(p => p.IdFormaPago == 1).Valor.ToString();
                printEgreso.Show();
            }
        }

        private void PrintPos50mm()
        {
            try
            {
                int maxCharacters = 27;

                var empresaRow = this.miBussinesEmpresa.PrintEmpresa().Tables[0].AsEnumerable().First();
                var proveedor = miBussinesProveedor.ProveedorAEditar(MiProveedor.CodigoInternoProveedor);

                Ticket miTicket = new Ticket();
                miTicket.UseItem = false;
                miTicket.Printer80mm = false;

                //miTicket.AddHeaderLine(empresaRow["Nombre"].ToString().ToUpper());
                //miTicket.AddHeaderLine(empresaRow["Juridico"].ToString().ToUpper());
                foreach (var datos in UseObject.StringBuilderDataCenter(empresaRow["Juridico"].ToString().ToUpper(), maxCharacters))
                {
                    miTicket.AddHeaderLine(datos);
                }
                foreach (var datos in UseObject.StringBuilderDataCenter(empresaRow["Nit"].ToString().ToUpper(), maxCharacters))
                {
                    miTicket.AddHeaderLine(datos);
                }
                //miTicket.AddHeaderLine(empresaRow["Nit"].ToString().ToUpper());
                miTicket.AddHeaderLine(empresaRow["direccion_"].ToString().ToUpper());
                miTicket.AddHeaderLine(empresaRow["ciudad"].ToString().ToUpper() + " " +
                    empresaRow["departamento"].ToString().ToUpper());

                if (!String.IsNullOrEmpty(empresaRow["Telefono"].ToString()) && !empresaRow["Telefono"].ToString().Equals("0"))
                {
                    miTicket.AddHeaderLine(empresaRow["Telefono"].ToString().ToUpper());
                }
                if (!String.IsNullOrEmpty(empresaRow["celularempresa"].ToString()) && !empresaRow["celularempresa"].ToString().Equals("0"))
                {
                    miTicket.AddHeaderLine(empresaRow["celularempresa"].ToString().ToUpper());
                }

                miTicket.AddHeaderLine("---------------------------");
                miTicket.AddHeaderLine("Factura compra " + miFactura.Numero);
                string estado = "";
                if (miFactura.EstadoFactura.Id.Equals(1))
                {
                    estado = "Contado";
                }
                else
                {
                   estado = "Crédito";
                }
                miTicket.AddHeaderLine("Fecha: " + miFactura.FechaFactura.ToShortDateString() + " " + estado);
                miTicket.AddHeaderLine("");
                //miTicket.AddHeaderLine("---------------------------");
                miTicket.AddHeaderLine("-------- PROVEEDOR --------");
                miTicket.AddHeaderLine(proveedor.RazonSocialProveedor);
                miTicket.AddHeaderLine(proveedor.NitProveedor);
                miTicket.AddHeaderLine("---------------------------");
                miTicket.AddHeaderLine("ARTICULO CANT. V UND. TOTAL");
                miTicket.AddHeaderLine("---------------------------");
                string product = "", cant = "", valor = "", total = "";
                foreach (DataRow pRow in miTabla.Rows)
                {
                    product = pRow["Producto"].ToString();
                    if (product.Length > maxCharacters)
                    {
                        product = product.Substring(0, maxCharacters);
                    }
                    miTicket.AddHeaderLine(product);

                    cant = UseObject.InsertSeparatorMil(pRow["Cantidad"].ToString());
                    valor = UseObject.InsertSeparatorMil(pRow["TotalMasIva"].ToString());
                    total = UseObject.InsertSeparatorMil(pRow["Valor"].ToString());

                    miTicket.AddHeaderLine(UseObject.FuncionEspacio(7 - cant.Length) + cant +
                            UseObject.FuncionEspacio(10 - valor.Length) + valor +
                            UseObject.FuncionEspacio(10 - total.Length) + total);
                }
                miTicket.AddHeaderLine("");
                miTicket.AddHeaderLine("---------------------------");
                miTicket.AddHeaderLine("Subtotal:   " + txtSubTotal.Text);
                miTicket.AddHeaderLine("Iva :       " + txtIva.Text);
                miTicket.AddHeaderLine("Total:      " + txtTotal.Text);
                miTicket.AddHeaderLine("");
                miTicket.AddHeaderLine("");
                miTicket.PrintTicket("");
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
        }

        /// <summary>
        /// Cierra los Formulario que hayan sido creados como extensión de éste.
        /// </summary>
        private void CerrarForms()
        {
            if (formProveedor != null)
            {
                formProveedor.Close();
            }
            if (FrmProducto != null)
            {
                FrmProducto.Close();
            }
            if (listaProducto != null)
            {
                listaProducto.Close();
            }
        }

        private void ValidarRetencion()
        {
            try
            {
                if (miBussinesRetencion.RetencionesAplicadasACompra
                    (MiEmpresa.Regimen.IdRegimen, MiProveedor.IdRegimen, IdRubroRetencion).Rows.Count != 0)
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
                int valorBase = Convert.ToInt32(
                    UseObject.RemoveSeparatorMil(txtSubTotal.Text) - UseObject.RemoveSeparatorMil(txtDescuento.Text));
                if (valorBase > MiRetencion.CifraPesos)
                {
                    txtRetencion.Text = UseObject.InsertSeparatorMil(
                        (Convert.ToInt32(valorBase * MiRetencion.Tarifa / 100)).ToString());
                }
                else
                {
                    txtRetencion.Text = "0";
                }
            }
            else
            {
                txtRetencion.Text = "0";
                /* MiRetencion.Tarifa = 0.0;
                 MiRetencion.CifraPesos = 0;
                 MiRetencion.CifraUVT = 0;
                 MiRetencion.Concepto = "";
                 //MiRetencion.CifraPesos = 0.0;
                 txtRetencion.Text = "0";*/
            }
        }

        public string IncrementaConsecutivo(string numero)
        {
            var num = "";
            if (Convert.ToInt32(numero) >= 10)
            {
                num += "0" + (Convert.ToInt32(numero) + 1).ToString();
            }
            else
            {
                num += "00" + (Convert.ToInt32(numero) + 1).ToString();
            }
            return num;
        }

        private int IdRubroRetencion { set; get; }
    }

    /// <summary>
    /// Representa una clase para la estructura de un panel de informacion tributaria.
    /// </summary>
    internal class PanelTributario
    {
        /// <summary>
        /// Obtiene o establece el Iva a calcular.
        /// </summary>
        public double Iva { set; get; }

        /// <summary>
        /// Obtiene o establece el Pane utilizado para el titulo del Iva cargado.
        /// </summary>
        public Panel PanelIva { set; get; }

        /// <summary>
        /// Obtiene o establece el Texbox utilizado para el grabado del Iva.
        /// </summary>
        public TextBox TxtGravado { set; get; }

        /// <summary>
        /// Obtiene o establece el Texbox utilizado para el total del Iva.
        /// </summary>
        public TextBox TxtTotalIva { set; get; }

        /// <summary>
        /// Inicializa una nueva instancia de la clase PanelTributario.
        /// </summary>
        public PanelTributario()
        {
            this.PanelIva = null;
            this.TxtGravado = null;
            this.TxtTotalIva = null;
        }
    }

    /// <summary>
    /// Representa una clase para la estructura de listado de Formas de Pago.
    /// </summary>
    internal class FormaPago
    {
        /// <summary>
        /// Obtiene o establece la lista de Formas de Pago.
        /// </summary>
        public List<Inventario.Producto.Criterio> lista { set; get; }

        /// <summary>
        /// Inicializa una nueva instancia de la clase FormaPago.
        /// </summary>
        public FormaPago()
        {
            lista = new List<Inventario.Producto.Criterio>();
            lista.Add(new Inventario.Producto.Criterio
            {
                Id = 1,
                Nombre = "Contado"
            });
            lista.Add(new Inventario.Producto.Criterio
            {
                Id = 2,
                Nombre = "Crédito"
            });
        }
    }
}