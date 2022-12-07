using System;
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
using System.Collections;
using System.Threading;

namespace Aplicacion.Compras.IngresarCompra
{
    public partial class FrmAgregarProducto : Form
    {
        #region Atributos de Logica de Negocio

        /// <summary>
        /// Objeto de logica de negocio de Proveedor.
        /// </summary>
        private BussinesProveedor miBussinesProveedor;

        /// <summary>
        /// Objeto para cargar los datos de la medida del producto consultado.
        /// </summary>
        private ValorUnidadMedida miMedida;

        /// <summary>
        /// Objeto de logica de negocio de Producto.
        /// </summary>
        private BussinesProducto miBussinesProducto;

        private BussinesValorUnidadMedida miBussinesMedida;

        private BussinesColor miBussinesColor;

        /// <summary>
        /// Objeto de logica de negocio de Factura Proveedor.
        /// </summary>
        private BussinesFacturaProveedor miBussinesFacturaProveedor;

        #endregion

        #region Propiedades

        public bool EsFactura { set; get; }

        /// <summary>
        /// Obtiene o establece el Id de la FacturaProveedor.
        /// </summary>
        public int IdFactura { set; get; }

        public string NoFactura { set; get; }

        /// <summary>
        /// Obtiene o establece el valor de la fecha en que se ingresa la factura.
        /// </summary>
        public DateTime FechaFactura { set; get; }

        /// <summary>
        /// Obtiene o establece el valor del Descuento de la Factura.
        /// </summary>
        public double DesctoFactura { set; get; }

        /// <summary>
        /// Obtiene o establece el valor del Codigo del Proveedor de la Factura.
        /// </summary>
        public string CodigoProveedor { set; get; }

        /// <summary>
        /// Obtiene o establece el Regimen del Proveedor de la factura.
        /// </summary>
        private int RegimenProveedor { set; get; }

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
        private bool FormProducto { set; get; }

        /// <summary>
        /// Obtiene o establece el valor que indica si se encuentra abierto el Form de TallaYcolor.
        /// </summary>
        private bool FormTallaYcolor { set; get; }

        /// <summary>
        /// Establece la regla de validacion que indica si se uso el metodo KeyPress del codigo.
        /// </summary>
        private bool KeyProductoPress = false;

        /// <summary>
        /// Indica que se ha cargado la Talla y el Color desde el Boton Agregar Registro.
        /// </summary>
        private bool LoadColorSize = false;

        /// <summary>
        /// Establece la regla de validacion que indica si el campo Cantidad es valido.
        /// </summary>
        private bool CantidadMatch = true;

        /// <summary>
        /// Establece la regla de validacion que indica si el campo Valor es valido.
        /// </summary>
        private bool ValorMatch = true;

        /// <summary>
        /// Establece la regla de validadcion que indica si el campo Lote es valido.
        /// </summary>
        private bool LoteMatch = true;

        /// <summary>
        /// Obtiene o establece el valor que indica si el guardado se realizo con exito.
        /// </summary>
        private bool SuccessGuardado = false;

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
        /// Objeto que estructura los datos de un metodo de clase.
        /// </summary>
        private delegate void myDelegate();

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

        /// <summary>
        /// Objeto tipo hilo que me premite realiza ejecuciones asincronas y sincrona.
        /// </summary>
        private Thread miThread;

        /// <summary>
        /// Objeto que representa el panel de opcion a mostrar.
        /// </summary>
        private OptionPane miOption;

        #endregion

        private int IdTipoInventarioProductoCompra = 1;

        private int IdTipoInventarioProductoInsumo = 2;

        private int IdTipoInventarioProductoNoFabricado = 3;

        private int IdTipoInventarioProductoFabricado = 4;

        public FrmAgregarProducto()
        {
            InitializeComponent();
            Kardex = new Kardex();
            EsFactura = true;
            EnableColor = Convert.ToBoolean(AppConfiguracion.ValorSeccion("color"));
            miToolTip = new ToolTip();
            MiError = new ErrorProvider();
            miBussinesProveedor = new BussinesProveedor();
            miBussinesProducto = new BussinesProducto();
            miBussinesMedida = new BussinesValorUnidadMedida();
            miBussinesColor = new BussinesColor();
            miBussinesFacturaProveedor = new BussinesFacturaProveedor();
            miBussinesKardex = new BussinesKardex();
            miTabla = new DataTable();
            CrearDataTable();
            miTallaYcolor = new TallaYcolor();
            miBindingSource = new BindingSource();
            miPanelTributario = new List<PanelTributario>();
        }

        private void FrmAgregarProducto_Load(object sender, EventArgs e)
        {
            miToolTip.SetToolTip(btnTallaYcolor, "Seleccionar Talla y Color");
            CompletaEventos.Completa += new CompletaEventos.CompletaAccion(CompletaEventos_Completo);
            CompletaEventos.CompletaEditProveedor += 
                new CompletaEventos.CompletaAccionEditProveedor(CompletaEventos_Completo);
            CompletaEventos.CompAxTInvFactProvee +=
                new CompletaEventos.ComAxTransferInvFactProve(CompletaEventos_CompAxTInvFactProvee);
            assembly = System.Reflection.Assembly.GetExecutingAssembly();
            CargarRecursos();
            dgvListaArticulos.AutoGenerateColumns = false;
            dgvListaArticulos.DataSource = miBindingSource;
        }

        private void FrmAgregarProducto_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData.Equals(Keys.F2))
            {
                this.tsGuardar_Click(this.tsGuardar, new EventArgs());
            }
            else
            {
                if (e.KeyData == Keys.F12)
                {
                    lkbGenerarLote_LinkClicked(null, null);
                }
                else
                {
                    if (e.KeyData.Equals(Keys.Escape))
                    {
                        this.Close();
                    }
                }
            }
        }

        private void FrmAgregarProducto_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (dgvListaArticulos.RowCount != 0)
            {
                DialogResult rta = MessageBox.Show("¿Desea guardar los cambios?",
                "Agregar Producto", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information);
                if (rta.Equals(DialogResult.Yes))
                {
                    tsGuardar_Click(null, null);
                    e.Cancel = false;
                    CompletaEventos.CapturaEvento(false);
                }
                else
                {
                    if (rta.Equals(DialogResult.No))
                    {
                        e.Cancel = false;
                        CompletaEventos.CapturaEvento(false);
                    }
                    else
                    {
                        e.Cancel = true;
                    }
                }
            }
            else
            {
                e.Cancel = false;
                CompletaEventos.CapturaEvento(false);
            }
        }

        private void tsGuardar_Click(object sender, EventArgs e)
        {
            if (miTabla.Rows.Count != 0)
            {
                Guardar();
               /* miOption = new OptionPane();
                miOption.FrmProgressBar.barraProgreso.Style = ProgressBarStyle.Marquee;
                miOption.FrmProgressBar.Closed_ = true;
                miOption.ProgressShow("Espere mientras se realizan las operaciones necesarias...",
                    "Operacion en progreso");
                this.Enabled = false;
                miThread = new Thread(IniciarGuardado);
                miThread.Start();*/
                //OptionPane.MessageInformation("Los datos se han almacenado con éxito.");
                CompletaEventos.CapturaEvento("1");
            }
            else
            {
                OptionPane.MessageInformation("No hay registros para guardar.");
            }
        }

        private void tsSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtCodigoArticulo_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (e.KeyChar == (char)Keys.Enter)
                {
                    if (CodigoOrString(txtCodigoArticulo.Text))
                    {
                        if (ValidarCodigo() || ValidarCodigoBarras())
                        {
                            if (ExisteProducto(txtCodigoArticulo.Text))
                            {
                                CargarProducto(txtCodigoArticulo.Text);
                                MiError.SetError(txtCodigoArticulo, null);
                                KeyProductoPress = true;
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
                        var formInventario = new Inventario.Consulta.FrmConsultaInventario();
                        formInventario.MdiParent = this.MdiParent;
                        formInventario.ExtendVenta = true;
                        formInventario.IsCompra = true;
                        formInventario.txtCodigoNombre.Text = txtCodigoArticulo.Text;
                       // FormInventario = true;
                        formInventario.Show();
                        formInventario.dgvInventario.Focus();
                    }
                }
                else
                {
                    KeyProductoPress = false;
                }
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
        }

        private void txtCodigoArticulo_Validating(object sender, CancelEventArgs e)
        {
            /*if (!KeyProductoPress)
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
            }*/
        }

        private void btnBuscarArticulo_Click(object sender, EventArgs e)
        {
            if (!FormProducto)
            {
                var FrmProducto = new Inventario.Producto.FrmIngresarProducto();
                FrmProducto.MdiParent = this.MdiParent;
                FrmProducto.Extencion = true;
                FrmProducto.Edit = true;
                FrmProducto.tabControlProducto.SelectTab(1);
                FormProducto = true;
                FrmProducto.Show();
            }
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
                txtCantidad.Text = txtCantidad.Text.Replace(',', '.');
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
                txtValorUnitario.Text = txtValorUnitario.Text.Replace(',', '.');
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
                    txtDescuentoProducto.Text = txtDescuentoProducto.Text.Replace(',', '.');
                    if (Validacion.ConFormato(Validacion.TipoValidacion.NumerosYPunto, txtDescuentoProducto,
                        MiError, "El valor del Descuento que ingreso tiene formato incorrecto."))
                    {
                        txtDescuentoProducto.Text = txtDescuentoProducto.Text.Replace('.', ',');
                        if (Convert.ToDouble(txtDescuentoProducto.Text) > 100)
                        {
                            MiError.SetError(txtDescuentoProducto, "El porcentaje de descuento no puede ser superior al 100%.");
                            //DesctoProductoMatch = false;
                        }
                        else
                        {
                            MiError.SetError(txtDescuentoProducto, null);
                            //DesctoProductoMatch = true;
                            txtLote.Focus();
                        }
                    }
                }
                else
                {
                    txtDescuentoProducto.Text = "0";
                    //DesctoProductoMatch = true;
                    txtLote.Focus();
                }
            }
        }

        private void txtDescuentoProducto_Validating(object sender, CancelEventArgs e)
        {
            txtDescuentoProducto_KeyPress(txtDescuentoProducto, new KeyPressEventArgs((char)Keys.Enter));
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
            if (!FormTallaYcolor)
            {
                if (MiProducto != null)
                {
                    if (MiProducto.AplicaTalla || MiProducto.AplicaColor)
                    {
                        Inventario.Agrupacion.frmListarProducto listaProducto =
                            new Inventario.Agrupacion.frmListarProducto();
                        listaProducto.MdiParent = this.MdiParent;
                        listaProducto.CargarProducto(MiProducto.CodigoInternoProducto);
                        listaProducto.Show();
                    }
                }
                else
                {
                    OptionPane.MessageInformation("Debe selecciona un Articulo primero.");
                }
                FormTallaYcolor = true;
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            txtCantidad_Validating(null, null);
            txtValorUnitario_Validating(null, null);
            txtLote_Validating(null, null);
            if (ArrayProducto != null && CantidadMatch && ValorMatch && LoteMatch)
            {
                if (!String.IsNullOrEmpty(txtLote.Text))
                {
                    Lote = txtLote.Text;
                }
                else
                {
                    Lote = MiProducto.CodigoInternoProducto + "-" + CambiarSeparadorFecha(FechaFactura.ToShortDateString());
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
                    EstructurarConsulta();
                }
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
                    txtCantidad.Text = edit["Cantidad"].ToString().Replace(',', '.'); ;
                    txtValorUnitario.Text = edit["ValorUnitario"].ToString().Replace(',', '.'); ;
                    txtLote.Text = edit["Lote"].ToString();
                    if (RegimenProveedor == 1)
                    {
                        var total_ = Math.Round(
                                     Convert.ToDouble(edit["ValorMenosDescto"]) * 
                                     Convert.ToDouble(edit["Cantidad"]), 0);
                        var iva_ = UseObject.RemoveCharacter(edit["Iva"].ToString(), '%');

                        var panelSearch = (from data in miPanelTributario
                                           where data.Iva == iva_
                                           select data).ToList();
                        panelSearch[0].TxtGravado.Text = UseObject.InsertSeparatorMil(
                            (UseObject.RemoveSeparatorMil(panelSearch[0].TxtGravado.Text) - total_).ToString());
                        panelSearch[0].TxtTotalIva.Text = UseObject.InsertSeparatorMil(
                            (UseObject.RemoveSeparatorMil(panelSearch[0].TxtTotalIva.Text) -
                             Math.Round( (iva_ * total_ / 100), 0) ).ToString());

                        txtIva.Text = UseObject.InsertSeparatorMil(
                        (UseObject.RemoveSeparatorMil(txtIva.Text) - Math.Round( (iva_ * total_ / 100), 0 )).ToString());
                    }
                    txtSubTotal.Text = UseObject.InsertSeparatorMil
                            (
                              (UseObject.RemoveSeparatorMil(txtSubTotal.Text) -
                               Math.Round( edit.Field<double>("ValorUnitario") * Convert.ToDouble(edit["Cantidad"]) ,0 ) )
                               .ToString()
                            );

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
                DialogResult rta = MessageBox.Show("¿Esta seguro de eliminar el registro?", "Factura Proveedor",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (rta.Equals(DialogResult.Yes))
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
                    if (RegimenProveedor == 1)
                    {
                        var total_ = Math.Round(
                                     Convert.ToDouble(delet["ValorMenosDescto"]) *
                                     Convert.ToInt32(delet["Cantidad"]), 0);
                        var iva_ = UseObject.RemoveCharacter(delet.Field<string>("Iva"), '%');
                        var panelSearch = (from data in miPanelTributario
                                           where data.Iva == iva_
                                           select data).ToList();
                        panelSearch[0].TxtGravado.Text = UseObject.InsertSeparatorMil(
                                (UseObject.RemoveSeparatorMil(panelSearch[0].TxtGravado.Text) - total_).ToString());
                        panelSearch[0].TxtTotalIva.Text = UseObject.InsertSeparatorMil(
                                (UseObject.RemoveSeparatorMil(panelSearch[0].TxtTotalIva.Text) -
                                 Math.Round( (iva_ * total_ / 100), 0) ).ToString());
                        txtIva.Text = UseObject.InsertSeparatorMil(
                            (UseObject.RemoveSeparatorMil(txtIva.Text) - Math.Round( (iva_ * total_ / 100), 0)).ToString());
                    }
                    txtSubTotal.Text = UseObject.InsertSeparatorMil
                            (Convert.ToInt32
                              (UseObject.RemoveSeparatorMil(txtSubTotal.Text) -
                              delet.Field<double>("ValorUnitario") * Convert.ToInt32(delet["Cantidad"]))
                              .ToString()
                            );

                    txtDescuento.Text = UseObject.InsertSeparatorMil
                        (Convert.ToInt32
                          (Convert.ToDecimal(txtDescuento.Text) -
                           ((Convert.ToDecimal(delet["ValorUnitario"]) - Convert.ToDecimal(delet["ValorMenosDescto"])) *
                             Convert.ToDecimal(delet["Cantidad"]))).ToString()
                        );

                    txtTotal.Text = UseObject.InsertSeparatorMil(
                        Convert.ToInt32
                        ((UseObject.RemoveSeparatorMil(txtSubTotal.Text) -
                         UseObject.RemoveSeparatorMil(txtDescuento.Text)) +
                         UseObject.RemoveSeparatorMil(txtIva.Text)).ToString());
                    miTabla.Rows.Remove(delet);
                    if (miTabla.Rows.Count != 0)
                    {
                        RecargarGridview();
                    }
                    else
                    {
                        dgvListaArticulos.Rows.RemoveAt(dgvListaArticulos.CurrentCell.RowIndex);
                    }
                }
            }
            else
            {
                OptionPane.MessageInformation("No hay registros para eliminar.");
            }
        }

        /// <summary>
        /// Crea las respectivas columnas del DataTable miTabla.
        /// </summary>
        private void CrearDataTable()
        {
            miTabla.Columns.Add(new DataColumn("Id", typeof(int)));
            miTabla.Columns.Add(new DataColumn("Codigo", typeof(string)));
            miTabla.Columns.Add(new DataColumn("Articulo", typeof(string)));
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
                RegimenProveedor = miBussinesProveedor.ConsultarPrveedorBasico
                    (Convert.ToInt32(CodigoProveedor)).IdRegimen;
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
            if (!DesctoFactura.Equals(0))
            {
                txtDescuentoProducto.Enabled = false;
                txtDescuentoProducto.Text = DesctoFactura.ToString();
            }
        }

        private BussinesKardex miBussinesKardex;

        private Kardex Kardex { set; get; }

        /// <summary>
        /// Almacena el registro del Producto en una Factura de Proveedor.
        /// </summary>
        /// <param name="producto">Registro del Producto a almacenar.</param>
        private void GuardarProducto(ProductoFacturaProveedor producto)
        {
            var miBussinesLote = new BussinesLote();
            var miBussinesInventario = new BussinesInventario();
            try
            {
                producto.Lote.Id = miBussinesLote.IngresarLote(producto.Lote);
                miBussinesFacturaProveedor.IngresarProductoFacturaProveedor(producto, EsFactura);
                miBussinesProveedor.IngresarProductoDeProveedor
                    (Convert.ToInt32(CodigoProveedor), producto.Producto.CodigoInternoProducto);

                if (producto.Producto.IdTipoInventario.Equals(IdTipoInventarioProductoCompra))
                {
                    miBussinesInventario.ActualizarInventario(producto.Inventario, false);
                }
                else
                {
                    if (producto.Producto.IdTipoInventario.Equals(IdTipoInventarioProductoInsumo))
                    {
                        var p = miBussinesProducto.ProductoProcesoPresentacion(producto.Producto.CodigoInternoProducto);
                        p.Cantidad = p.Cantidad + (Math.Round(producto.Inventario.Cantidad * producto.Producto.UnidadVentaProducto, 2));
                        miBussinesInventario.ActualizarCantidad(p.CodigoInternoProducto, p.Cantidad);
                    }
                }

                Kardex.Codigo = producto.Producto.CodigoInternoProducto;
                Kardex.IdUsuario = Convert.ToInt32(AppConfiguracion.ValorSeccion("id_user"));
                if (EsFactura)
                {
                    Kardex.IdConcepto = 5;
                }
                else
                {
                    Kardex.IdConcepto = 6;
                }
                Kardex.NoDocumento = NoFactura;
                Kardex.Fecha = DateTime.Now;
                Kardex.Cantidad = producto.Inventario.Cantidad;
                double iva = Math.Round(
                    (producto.Producto.ValorVentaProducto * producto.Producto.ValorIva / 100), 2);
                Kardex.Valor = producto.Producto.ValorVentaProducto + Convert.ToInt32(iva);
                Kardex.Total = Kardex.Cantidad * Kardex.Valor;
                miBussinesKardex.Insertar(Kardex);
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
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
        /// Indica si el Producto tiene una sola talla.
        /// </summary>
        private bool SingleSize = false;

        /// <summary>
        /// Indica si el Producto tiene un solo color.
        /// </summary>
        private bool SingleColor = false;

        /// <summary>
        /// Carga en memoria los datos del Producto consultado según  su código.
        /// </summary>
        /// <param name="codigo">Código del Producto a cargar.</param>
        private void CargarProducto(string codigo)
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

            //antes
            /*try
            {
                ArrayProducto = miBussinesProducto.ProductoBasico(codigo);
                MiProducto = (DTO.Clases.Producto)ArrayProducto[0];
                if (!MiProducto.AplicaTalla)
                {
                    miMedida = (ValorUnidadMedida)ArrayProducto[1];
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
        /// Completa la secuencia de datos de un formulario de extención.
        /// </summary>
        /// <param name="args">Objeto que encapsula la información del formulario.</param>
        void CompletaEventos_Completo(CompletaArgumentosDeEventoEditProveedor args)
        {
            try
            {
                var producto = (DTO.Clases.Producto)args.MiObjeto;
                txtCodigoArticulo.Text = producto.CodigoInternoProducto;
                txtCodigoArticulo_KeyPress(null, new KeyPressEventArgs((char)Keys.Enter));
            }
            catch { }

            try
            {
                FormProducto = Convert.ToBoolean(args.MiObjeto);
            }
            catch { }
        }

        /// <summary>
        /// Completa la secuencia de datos de un formulario de extención.
        /// </summary>
        /// <param name="args">Objeto que encapsula la información del formulario.</param>
        void CompletaEventos_Completo(CompletaArgumentosDeEvento args)
        {
            try
            {
                miTallaYcolor = (TallaYcolor)args.MiObjeto;
                if (LoadColorSize)
                {
                    btnAgregar_Click(this.btnAgregar, null);
                }
                btnAgregar.Focus();
            }
            catch { }

            try
            {
                FormTallaYcolor = Convert.ToBoolean(args.MiObjeto);//revisar.
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

        public bool IncluyeIva = false;

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
                row["Articulo"] = MiProducto.NombreProducto;
                txtCantidad.Text = txtCantidad.Text.Replace('.', ',');
                txtValorUnitario.Text = txtValorUnitario.Text.Replace('.', ',');
                row["Cantidad"] = Convert.ToDouble(txtCantidad.Text); //txtCantidad.Text.Replace('.', ',');

                if (chkIva.Checked)
                {
                    row["ValorUnitario"] = Math.Round(Convert.ToDouble(Convert.ToDouble(txtValorUnitario.Text) /
                        (1 + (MiProducto.ValorIva / 100))), 2);
                    var v = Convert.ToDouble(row["ValorUnitario"]);
                }
                else
                {
                    row["ValorUnitario"] = Math.Round(
                        Convert.ToDouble(txtValorUnitario.Text), 2);
                }

               /* if (IncluyeIva)
                {
                    row["ValorUnitario"] = Math.Round(
                        Convert.ToDouble(Convert.ToDouble(txtValorUnitario.Text) /
                        (1 + (MiProducto.ValorIva / 100))), 2);
                    var v = Convert.ToDouble(row["ValorUnitario"]);
                }
                else
                {
                    row["ValorUnitario"] = Math.Round(
                        Convert.ToDouble(txtValorUnitario.Text), 2);
                }*/


                //row["ValorUnitario"] = txtValorUnitario.Text.Replace('.', ',');
                row["Descuento"] = txtDescuentoProducto.Text + "%";
                row["ValorMenosDescto"] = Math.Round(
                                          Convert.ToDouble(Convert.ToDouble(row["ValorUnitario"]) -
                                          (Convert.ToDouble(row["ValorUnitario"]) * 
                                          UseObject.RemoveCharacter(row["Descuento"].ToString(), '%') / 100)), 2);
                if (RegimenProveedor == 1)  //Regimen Comun
                {
                    row["Iva"] = MiProducto.ValorIva.ToString() + "%";
                    InformacionTributaria(MiProducto.ValorIva, txtCantidad.Text, row["ValorMenosDescto"].ToString());
                }
                else
                {
                    row["Iva"] = 0 + "%";
                }
                row["TotalMasIva"] = Convert.ToInt32(
                                      (Convert.ToDouble(row["ValorMenosDescto"]) *
                                      UseObject.RemoveCharacter(row["Iva"].ToString(), '%') / 100) +
                                      Convert.ToDouble(row["ValorMenosDescto"]));

                row["Valor"] = Math.Round( Convert.ToDouble(row["TotalMasIva"]) *
                               Convert.ToDouble(txtCantidad.Text), 0 );

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

                txtSubTotal.Text = UseObject.InsertSeparatorMil(
                                   Math.Round( (UseObject.RemoveSeparatorMil(txtSubTotal.Text) +
                                    Convert.ToDouble(row["ValorUnitario"]) * Convert.ToDouble(txtCantidad.Text)
                                   ), 0).ToString());
                txtDescuento.Text = UseObject.InsertSeparatorMil
                    (Convert.ToInt32
                     (Convert.ToDecimal(UseObject.RemoveSeparatorMil(txtDescuento.Text)) +
                     (Convert.ToDecimal(row["ValorUnitario"]) - Convert.ToDecimal(row["ValorMenosDescto"])) *
                      Convert.ToDecimal(row["Cantidad"])).ToString()
                    );
                var totalIva_ = 0.0;
                foreach (PanelTributario panelT in miPanelTributario)
                {
                    totalIva_ = totalIva_ + Convert.ToDouble(panelT.TxtTotalIva.Text);
                }
                txtIva.Text = UseObject.InsertSeparatorMil(totalIva_.ToString());
                txtTotal.Text = UseObject.InsertSeparatorMil(
                                Convert.ToInt32((UseObject.RemoveSeparatorMil(txtSubTotal.Text) -
                                UseObject.RemoveSeparatorMil(txtDescuento.Text)) +
                                totalIva_).ToString());
                miTabla.Rows.Add(row);
                RecargarGridview();
                ActualizarLote();
                LimpiarCampos();
            }
        }

        /// <summary>
        /// Carga y muestra la informacion tributaria del producto solicitado.
        /// </summary>
        /// <param name="iva">Iva a cargar del producto solicitado.</param>
        /// <param name="cantidad"></param>
        /// <param name="valorUnit"></param>
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
                            Math.Round(
                            Convert.ToDouble
                            (p.Iva * UseObject.RemoveSeparatorMil(p.TxtGravado.Text) / 100), 0).ToString());
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
                                Math.Round(Convert.ToDouble(cantidad) *
                                Convert.ToDouble(valorUnit) , 0).ToString());
            ///txtTotaliva
            lstTexBox[1].Text = UseObject.InsertSeparatorMil(Math.Round(
                                ((iva * Convert.ToDouble(lstTexBox[0].Text)) / 100), 0).ToString());
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
        /// Despliega el proceso del hilo (Thread) para el guardado de los Productos.
        /// </summary>
        private void IniciarGuardado()
        {
            GuardarProducto();
        }

        private void Guardar()
        {
            try
            {
                foreach (DataRow row in miTabla.Rows)
                {
                    var p = new ProductoFacturaProveedor();
                    p.IdFactura = IdFactura;
                    p.Producto.CodigoInternoProducto = row["Codigo"].ToString();
                    p.Cantidad = Convert.ToInt32(row["Cantidad"]);
                    p.Producto.ValorVentaProducto = Convert.ToInt32(row["ValorUnitario"]);
                    p.Producto.ValorIva = UseObject.RemoveCharacter(row["Iva"].ToString(), '%');
                    p.Producto.Descuento = UseObject.RemoveCharacter(row["Descuento"].ToString(), '%');
                    p.Producto.IdTipoInventario = Convert.ToInt32(row["IdTipoInventario"]);
                    p.Producto.UnidadVentaProducto = Convert.ToInt32(row["Presentacion"]);
                    p.Lote.CodigoProducto = p.Producto.CodigoInternoProducto;
                    p.Lote.Numero = row["Lote"].ToString();
                    p.Lote.Fecha = FechaFactura;
                    p.Inventario.CodigoProducto = p.Producto.CodigoInternoProducto;
                    p.Inventario.IdMedida = Convert.ToInt32(row["IdMedida"]);
                    p.Inventario.IdColor = Convert.ToInt32(row["IdColor"]);
                    p.Inventario.Cantidad = Convert.ToInt32(row["Cantidad"]);
                    GuardarProducto(p);
                }
                ActualizarLoteDataBase();
                OptionPane.MessageSuccess("Las operaciones se realizaron correctamente.");
                LimpiarFormulario();
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
        }

        /// <summary>
        /// Realiza los procedimientos necesarios para el guardado de los Productos.
        /// </summary>
        private void GuardarProducto()
        {
            try
            {
                foreach (DataRow row in miTabla.Rows)
                {
                    var p = new ProductoFacturaProveedor();
                    p.IdFactura = IdFactura;
                    p.Producto.CodigoInternoProducto = row["Codigo"].ToString();
                    p.Cantidad = Convert.ToInt32(row["Cantidad"]);
                    p.Producto.ValorVentaProducto = Convert.ToInt32(row["ValorUnitario"]);
                    p.Producto.ValorIva = UseObject.RemoveCharacter(row["Iva"].ToString(), '%');
                    p.Producto.Descuento = UseObject.RemoveCharacter(row["Descuento"].ToString(), '%');
                    p.Lote.CodigoProducto = p.Producto.CodigoInternoProducto;
                    p.Lote.Numero = row["Lote"].ToString();
                    p.Lote.Fecha = FechaFactura;
                    p.Inventario.CodigoProducto = p.Producto.CodigoInternoProducto;
                    p.Inventario.IdMedida = Convert.ToInt32(row["IdMedida"]);
                    p.Inventario.IdColor = Convert.ToInt32(row["IdColor"]);
                    p.Inventario.Cantidad = Convert.ToInt32(row["Cantidad"]);
                    GuardarProducto(p);
                }
                ActualizarLoteDataBase();
                SuccessGuardado = true;
                if (this.InvokeRequired)
                    this.Invoke(new Action(FinishProcessGuardado));
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
                SuccessGuardado = false;
                if (this.InvokeRequired)
                    this.Invoke(new Action(FinishProcessGuardado));
            }
        }

        /// <summary>
        /// Finaliza las funciones del proceso de guardado de los Productos.
        /// </summary>
        private void FinishProcessGuardado()
        {
            miOption.FrmProgressBar.barraProgreso.Style = ProgressBarStyle.Blocks;
            miOption.FrmProgressBar.Closed_ = false;
            miOption.FrmProgressBar.Close();
            this.Enabled = true;
            if (SuccessGuardado)
            {
                OptionPane.MessageSuccess("Las operaciones se realizaron correctamente.");
                LimpiarFormulario();
            }
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
        /// Actualiza el valor del consecutivo de Lote en la Base de Datos.
        /// </summary>
        private void ActualizarLoteDataBase()
        {
            try
            {
                miBussinesFacturaProveedor.ActualizarLote(LoteConsecutivo - 1);
            }
            catch (Exception ex)
            {
                OptionPane.MessageError("Ocurrió un error al actualizar el consecutivo del Lote.\n" + ex.Message);
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
            txtDescuentoProducto.Text = "0";
            txtSubTotal.Text = "0";
            txtDescuento.Text = "0";
            txtIva.Text = "0";
            txtTotal.Text = "0";
        }
    }
}