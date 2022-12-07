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

namespace Aplicacion.Ventas.Remisiones
{
    public partial class FrmRemision : Form
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

        private BussinesRemision miBussinesRemision;

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

        private BussinesInventario miBussinesInventario;

        private BussinesMarca miBussinesMarca;

        private BussinesPunto miBussinesPunto;

        private BussinesCaracteresEscape miBussinesCaracteresEscape;

        private BussinesBonoRifa miBussinesBonoRifa;

        #endregion

        #region Propiedades

        /// <summary>
        /// Representa un objeto para la carga de datos de la Empresa.
        /// </summary>
        private Empresa miEmpresa;

        private DTO.Clases.Cliente cliente;

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



        private BussinesFacturaProveedor miBussinesFacturaProveedor;

        private bool GraneroJhonRiosucio { set; get; }

        private double DesctoAplica { set; get; }

        private bool RequiereCantidad { set; get; }

        public bool CargaCliente { set; get; }

        public bool CodBarrasCantPeso { set; get; }

        private bool RedondearPrecio2 { set; get; }

        private bool FuncionExpulsaCajon { set; get; }

        public Usuario Usuario_ { set; get; }

        private bool _ConsultaInventario { set; get; }

        private const int IdPermisoEditarPrecio = 48;

        private bool PermisoEditarPrecio;

        private bool DescuentoMarca;

        private bool Ticket_;

        public FrmRemision()
        {
            InitializeComponent();
            try
            {
                Edicion = false;
                DesctoAplica = 0.0;
                miFactura = new FacturaVenta();
                cliente = new DTO.Clases.Cliente();
                //miBussinesFormaPago = new BussinesFormaPago();
                miBussinesEstado = new BussinesEstado();
                miBussinesEmpresa = new BussinesEmpresa();
                miBussinesFactura = new BussinesFacturaVenta();
                miBussinesRemision = new BussinesRemision();
                miBussinesDescuento = new BussinesDescuento();
                miBussinesRecargo = new BussinesRecargo();
                miBussinesCliente = new BussinesCliente();
                miBussinesProducto = new BussinesProducto();
                miBussinesMedida = new BussinesValorUnidadMedida();
                miBussinesColor = new BussinesColor();
                miBussinesUsuario = new BussinesUsuario();
                miBussinesDian = new BussinesDian();
                miBussinesInventario = new BussinesInventario();
                miBussinesFacturaProveedor = new BussinesFacturaProveedor();
                miBussinesPunto = new BussinesPunto();
                miBussinesCaracteresEscape = new BussinesCaracteresEscape();
                miBussinesBonoRifa = new BussinesBonoRifa();

                miCaracteresEscape = miBussinesCaracteresEscape.CaracteresPredeterminados();
                miBono = this.miBussinesBonoRifa.BonoRifa();

                CargarEmpresa();
                miFormasPago = new List<DTO.Clases.FormaPago>();
                FechaHoy = DateTime.Now;
                FacturaPos = false;// Convert.ToBoolean(AppConfiguracion.ValorSeccion("facturapos"));
                EnableColor = Convert.ToBoolean(AppConfiguracion.ValorSeccion("color"));
                Promedio = Convert.ToBoolean(AppConfiguracion.ValorSeccion("promedio"));
                NumeroDeFacturas = Convert.ToInt32(AppConfiguracion.ValorSeccion("numero"));
                FacturaNegativo = Convert.ToBoolean(AppConfiguracion.ValorSeccion("fact-negativo"));
                this.GraneroJhonRiosucio = Convert.ToBoolean(AppConfiguracion.ValorSeccion("graneroJhonRiosucio"));
                this.CodBarrasCantPeso = Convert.ToBoolean(AppConfiguracion.ValorSeccion("cod_barras_cant_peso"));
                this.RedondearPrecio2 = Convert.ToBoolean(AppConfiguracion.ValorSeccion("redondeo_precio_dos"));
                this.FuncionExpulsaCajon = Convert.ToBoolean(AppConfiguracion.ValorSeccion("activa_funcion_expulsa_cajon"));
                _ConsultaInventario = Convert.ToBoolean(AppConfiguracion.ValorSeccion("frm_consulta_inventario"));
                Ticket_ = Convert.ToBoolean(AppConfiguracion.ValorSeccion("ticket"));

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
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
            /* try
             {
                 CargaCliente = Convert.ToBoolean(AppConfiguracion.ValorSeccion("cargarCliente"));
             }
             catch (Exception ex)
             {
                 OptionPane.MessageError(ex.Message);
             }*/
            //ObtenerNumero();
        }

        private void FrmFacturaVenta_Load(object sender, EventArgs e)
        {
            miFactura.Usuario = Administracion.Usuario.FrmIniciarSesion.CargarDatosUsuario(this);

            this.PermisoEditarPrecio = false;
            foreach (var ps in Usuario_.Permisos)
            {
                switch (ps.IdPermiso)
                {
                    case IdPermisoEditarPrecio:
                        {
                            this.PermisoEditarPrecio = true;
                            break;
                        }
                }
            }

            lblDataFecha.Text = FechaHoy.Day + " de " + UseDate.MesCorto(FechaHoy.Month) + " de " + FechaHoy.Year;
            CargarUtilidades();
            CompletaEventos.CompletaRemision +=
                new CompletaEventos.CompletaAccionRemision(CompletaEventosRemision_Completo);
            CompletaEventos.Completa += new CompletaEventos.CompletaAccion(CompletaEventos_Completo);
            CompletaEventos.Completaem += new CompletaEventos.CompletaAccionem(CompletaEventos_Completaem);
            CompletaEventos.Completam += new CompletaEventos.CompletaAccionm(CompletaEventosm_Completo);
            dgvListaArticulos.AutoGenerateColumns = false;
            dgvListaArticulos.DataSource = miBindingSource;
            if (CargaCliente)
            {
                this.txtCliente.Text = "1000";
                this.txtCliente_KeyPress(this.txtCliente, new KeyPressEventArgs((char)Keys.Enter));
            }
            
        }

        private void FrmFacturaVenta_KeyDown(object sender, KeyEventArgs e)
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
                        if (this.FuncionExpulsaCajon)
                        {
                            this.ExpulsarCajonMonedero();
                        }
                        break;
                    }
                case Keys.Escape:
                    {
                        this.Close();
                        break;
                    }
            }
        }

        private void FrmFacturaVenta_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult rta = MessageBox.Show("Está a punto de salir.\n¿Desea guardar los cambios?", "Remisión de Venta",
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
            }
        }
        private bool contado = true;

        //private bool MsnEstado = true;
        //private bool ClienteKeyPress = false;
        /*private void tsCbDesctoRecargo_SelectedIndexChanged(object sender, EventArgs e)
        {
            rbtnDesctoFactura.Checked = true;
            if (dgvListaArticulos.RowCount == 0)
            {
                IdDesctoRecgo = ((Inventario.Producto.Criterio)cbDesctoRecargo.SelectedItem).Id;
                if (IdDesctoRecgo == 1)
                {
                    lblDescuentoFactura.Text = "Descto/Rem";
                    lblDesctoProducto.Text = "Descto%";
                    miToolTip.SetToolTip(rbtnDesctoProducto, "Aplicar descuento por Producto.");
                    miToolTip.SetToolTip(pbProducto, "Aplicar descuento por Producto.");
                    miToolTip.SetToolTip(rbtnDesctoFactura, "Aplicar descuento por Remisión.");
                    miToolTip.SetToolTip(pbFactura, "Aplicar descuento por Remisión.");
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
                        lblDescuentoFactura.Text = "Recargo/Rem";
                        lblDesctoProducto.Text = "Recargo%";
                        miToolTip.SetToolTip(rbtnDesctoProducto, "Aplicar recargo por Producto.");
                        miToolTip.SetToolTip(pbProducto, "Aplicar recargo por Producto.");
                        miToolTip.SetToolTip(rbtnDesctoFactura, "Aplicar recargo por Remisión.");
                        miToolTip.SetToolTip(pbFactura, "Aplicar recargo por Remisión.");
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
                //CargarDescuentosORecargos();
            }
            else
            {
                if (MsnDescto)
                {
                    OptionPane.MessageInformation
                            ("Este cambio no se puede realizar debido a que hay registros en la Remisión.");
                    MsnDescto = false;
                }
                cbDesctoRecargo.SelectedValue = IdDesctoRecgo;
            }
            MsnDescto = true;
        }*/

        /*private void tsBtnInventario_Click(object sender, EventArgs e)
        {
            var frmInventario = new Inventario.Consulta.FrmConsultaInventario();
            frmInventario.MdiParent = this.MdiParent;
            frmInventario.Show();
        }*/

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
            /*txtCantidad.Focus();
            txtCantidad.SelectAll();*/
        }

        private void tsCambiarPrecio_Click(object sender, EventArgs e)
        {
            if (dgvListaArticulos.RowCount != 0)
            {
                if (this.PermisoEditarPrecio)
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
                                    if (userTemp.Permisos.Where(ps => ps.IdPermiso.Equals(IdPermisoEditarPrecio)).Count() > 0)
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
                                        MessageBox.Show("El usuario no tiene permisos para esta acción.", "Remisión de venta",
                                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                                        admin = false;
                                    }
                                }
                                else
                                {
                                    MessageBox.Show
                                        ("Usuario o contraseña incorrecta.", "Remisión de venta", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            RetiroDeProducto();
        }

        private void tsBtnReset_Click(object sender, EventArgs e)
        {
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
                 }
                 else
                 {
                     MessageBox.Show("La contraseña es Incorrecta.", "Factura Venta",
                             MessageBoxButtons.OK, MessageBoxIcon.Error);
                 }
             }*/
            DialogResult rta = MessageBox.Show("¿Está seguro(a) de reiniciar la remisión?", "Remisión de Venta",
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (rta.Equals(DialogResult.Yes))
            {
                ResetFactura();
            }
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
                //ClienteMatch = true;
                //txtCliente.Focus();
                if (ValidarCodigoCliente())
                {
                    if (ExisteCliente())
                    {
                        try
                        {
                            cliente = miBussinesCliente.ClienteAEditar(txtCliente.Text);
                            txtNombreCliente.Text = cliente.NitCliente + " - " + cliente.NombresCliente;
                            NitCliente = cliente.NitCliente;
                            txtCodigoArticulo.Focus();
                            //cliente = null;
                            ClienteMatch = true;
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
            //}
            //catch (Exception ex)
            //{
            //    OptionPane.MessageError(ex.Message);
            //}
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
           /// if (!ExtendForms)
           /// {
                var frmCliente = new Cliente.frmCliente();
                //frmCliente.MdiParent = this.MdiParent;
                frmCliente.tcClientes.SelectedIndex = 1;
                frmCliente.Remision = true;
                //ClienteMatch = true;
              ///  ExtendForms = true;
                frmCliente.ShowDialog();
                frmCliente.txtNit.Focus();
          ///  }
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

        private void txtCantidad_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
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
                        txtCantidad.Focus();
                    }
                }
            }
        }

        private void txtCodigoArticulo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                if (CodigoOrString())
                {
                    if (Convert.ToInt64(this.txtCodigoArticulo.Text) < 0)
                    {
                        if (this.CodigoValido((Convert.ToInt64(this.txtCodigoArticulo.Text) * -1).ToString(), 13))
                        {
                            //String[] subString = UseObject.MiSubString(this.txtCodigoArticulo.Text, 3, 7);
                            //this.txtCantidad.Text = subString[1];
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
                                //CargarDescuentosORecargos();
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
                                            }
                                            //btnTallaYcolor.Focus();
                                        }
                                    }
                                }
                                if (!cbDescuentoProducto.Enabled && !cbRecargoProducto.Enabled && !btnTallaYcolor.Enabled)
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
                                    }
                                    //FrmFacturaVenta_KeyDown(this, new KeyEventArgs(Keys.F12));
                                }
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
                                    formProducto.Remision = true;
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
                        var formInventario = new Inventario.Consulta.FrmConsultaInventario();
                        formInventario.MdiParent = this.MdiParent;
                        formInventario.ExtendVenta = true;
                        formInventario.IsVenta = false;
                        formInventario.txtCodigoNombre.Text = txtCodigoArticulo.Text;
                        ExtendForms = true;
                        formInventario.Show();
                        formInventario.dgvInventario.Focus();
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
                    FrmTallaColor.MdiParent = this.MdiParent;
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
            if (e.ColumnIndex.Equals(12) && !TotalMasIva.ReadOnly) // valor venta
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
                        var num = Convert.ToDouble(e.FormattedValue.ToString());
                        ActualizarInformacion(e.RowIndex, num.ToString());//e.FormattedValue.ToString());
                        dgvListaArticulos.Columns["TotalMasIva"].ReadOnly = true;
                        dgvListaArticulos.EditMode = DataGridViewEditMode.EditProgrammatically;
                        dgvListaArticulos.BeginEdit(false);
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
                            //var num = Convert.ToDouble(e.FormattedValue.ToString());
                            //ActualizarInformacionCantidad(e.RowIndex, num.ToString());//e.FormattedValue.ToString());
                            ActualizarInformacionCantidad(e.RowIndex, e.FormattedValue.ToString());
                            dgvListaArticulos.EditMode = DataGridViewEditMode.EditProgrammatically;
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

            /* if (e.ColumnIndex == 8)
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
                         ActualizarInformacion(e.RowIndex, e.FormattedValue.ToString());
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
            /*tsCbDesctoRecargo.ComboBox.DataSource = lst;
            tsCbDesctoRecargo.ComboBox.DisplayMember = "Nombre";
            tsCbDesctoRecargo.ComboBox.ValueMember = "Id";*/
            cbDesctoRecargo.DataSource = lst;

            cbDesctoRecargo.DataSource = lst;
            try
            {
                var tabla = miBussinesEstado.Lista();
                IEnumerable<DataRow> query = from data in tabla.AsEnumerable()
                                             where
                                             data.Field<int>("idestado").Equals(1) ||
                                             data.Field<int>("idestado").Equals(2)
                                             select data;
                DataTable tCopy = query.CopyToDataTable<DataRow>();
                tabla.Rows.Clear();
                tabla.Columns.Clear();
                tabla.Clear();
                tabla = null;
                cbContado.DataSource = tCopy;
                IdEstado = Convert.ToInt32(cbContado.SelectedValue);
                RequiereCantidad = Convert.ToBoolean(AppConfiguracion.ValorSeccion("reqCantidad"));
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }


            miToolTip.SetToolTip(btnBuscarCliente, "Buscar Cliente [F3]");
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

        /// <summary>
        /// Obtiene el Número consecutivo a ser asignado en la Factura.
        /// </summary>
        /// <returns></returns>
        private void ObtenerNumero()
        {
            try
            {
                miFactura.Numero = miBussinesRemision.ObtenerNumero();
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

            miTabla.Columns.Add(new DataColumn("Ico", typeof(int)));
            miTabla.Columns.Add(new DataColumn("Costo", typeof(double)));
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
                var valorVenta = MiProducto.ValorVentaProducto - Convert.ToInt32(this.MiProducto.Impoconsumo);
                if (DesctoAplica > 0)
                {
                    valorVenta = Convert.ToInt32(Math.Round((valorVenta - (valorVenta * DesctoAplica / 100)), 1));
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
                    valorVenta = Convert.ToInt32(Math.Round((valorVenta - (valorVenta * descto / 100)), 1)); 
                    /*valorVenta = Convert.ToInt32(Math.Round((MiProducto.ValorVentaProducto -
                        (MiProducto.ValorVentaProducto * descto / 100)), 1));*/
                }
                valorVenta += Convert.ToInt32(this.MiProducto.Impoconsumo);
                if (this.RedondearPrecio2)
                {
                    lblPrecioProducto.Text = "v/u  " + UseObject.InsertSeparatorMil(
                    UseObject.Aproximar(Convert.ToInt32(valorVenta), Convert.ToBoolean(AppConfiguracion.ValorSeccion("tipo_aprox_precio"))).ToString());
                }
                else
                {
                    lblPrecioProducto.Text = "v/u  " + UseObject.InsertSeparatorMil(valorVenta.ToString());
                }

                //lblPrecioProducto.Text = "v/u  " + UseObject.InsertSeparatorMil(valorVenta.ToString());
                //lblPrecioProducto.Text = "v/u  " + UseObject.InsertSeparatorMil(MiProducto.ValorVentaProducto.ToString());
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

        private bool CargarProducto(string codigo)
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
                //lblPrecioProducto.Text = "v/u  " + UseObject.InsertSeparatorMil(valorVenta.ToString());
                //UseObject.Aproximar(vUnitario, Convert.ToBoolean(AppConfiguracion.ValorSeccion("tipo_aprox_precio")));
                lblPrecioProducto.Text = "v/u  " + UseObject.InsertSeparatorMil(
                    UseObject.Aproximar(Convert.ToInt32(valorVenta), Convert.ToBoolean(AppConfiguracion.ValorSeccion("tipo_aprox_precio"))).ToString());
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
        public bool Venta = false;
        /// <summary>
        /// Completa la secuencia de datos de un formulario de estención.
        /// </summary>
        /// <param name="args">Objeto que encapsula la información del formulario.</param>
        void CompletaEventos_Completo(CompletaArgumentosDeEvento args)
        {
            try
            {
                miTallaYcolor = (TallaYcolor)args.MiObjeto;
                EstructurarConsulta();
            }
            catch { }

            try
            {
                if ((bool)args.MiObjeto)
                {
                    txtCliente_KeyPress(this.txtCliente, new KeyPressEventArgs((char)Keys.Enter));
                }
            }
            catch { }

            try
            {
                ExtendForms = (bool)args.MiObjeto;
            }
            catch { }

            /*try
            {
                if (Venta)
                {
                    miFormasPago = (List<DTO.Clases.FormaPago>)args.MiObjeto;
                    CargarYguardarFactura();
                    Venta = false;
                }
            }
            catch { }*/

            /*try
            {
                ExtendForms = Convert.ToBoolean(args.MiObjeto);
                /*if (Convert.ToBoolean(args.MiObjeto))
                {
                    txtCliente_KeyPress(this.txtCliente, new KeyPressEventArgs((char)Keys.Enter));
                }
                else
                {
                    ClienteMatch = false;
                    //txtCliente.Focus();
                    txtCodigoArticulo.Focus();
                }
                ExtendForms = false;
            }
            catch { }*/

            /* try
             {
                 txtCliente.Text = (string)args.MiObjeto;
                 txtCliente_KeyPress(this.txtCliente, new KeyPressEventArgs((char)Keys.Enter));
             }
             catch { }*/


        }

        void CompletaEventosm_Completo(CompletaArgumentosDeEventom args)
        {
            try
            {
                var producto = (Producto)args.MiMarca;
                txtCodigoArticulo.Text = producto.CodigoInternoProducto;
                DesctoAplica = producto.Descuento;
                txtCodigoArticulo_KeyPress(this.txtCodigoArticulo, new KeyPressEventArgs((char)Keys.Enter));
            }
            catch { }
        }

        void CompletaEventosRemision_Completo(CompletaArgumentosDeEventoRemision args)
        {
            try
            {
                txtCliente.Text = (string)args.MiObjeto;
                txtCliente_KeyPress(this.txtCliente, new KeyPressEventArgs((char)Keys.Enter));
            }
            catch { }

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

        void CompletaEventos_Completaem(CompletaArgumentosDeEventoem args)
        {
            try
            {
                if (Venta)
                {
                    miFormasPago = (List<DTO.Clases.FormaPago>)args.MiMarcaed;
                    if (FacturaPos)
                    {
                        CargarYguardarFacturaPos();
                    }
                    else
                    {
                        CargarYguardarFacturaDespues();
                    }
                    Venta = false;
                }
            }
            catch { }

            try
            {
                ExtendForms = Convert.ToBoolean(args.MiMarcaed);
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
        /// Estructura la información en la tabla de memoria para ser visualizada.  (antes: 11/09/2018)
        /// </summary>
        private void EstructurarConsulta_()
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
            if (!IdEstado.Equals(4))
            {
                try
                {
                    inventario.Cantidad = miBussinesInventario.CantidadInventario(inventario);
                    /*if (inventario.Cantidad.Equals(0))
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
                                    && p.Field<int>("IdColor").Equals(inventario.IdColor)).Sum
                                    (s => Convert.ToDouble(s.Field<string>("Cantidad")));
                        cantFactura += Convert.ToDouble(txtCantidad.Text);
                        if (!FacturaNegativo && (inventario.Cantidad < cantFactura))
                        {
                            OptionPane.MessageError
                                ("El artículo no se puede Facturar ya que la(s) cantidad(es) exceden el inventario.");
                            return;
                        }
                    }*/
                    /*inventario.Cantidad = miBussinesInventario.CantidadInventario(inventario);
                    if (!FacturaNegativo && inventario.Cantidad.Equals(0))
                    {
                        OptionPane.MessageError("El artículo no se puede Facturar ya que su inventario se encuentra en cero.");
                        return;
                    }*/
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
                if (chkAlCosto.Checked)
                {
                    valorUnitario = MiProducto.ValorCosto;
                }
                else
                {
                    valorUnitario = MiProducto.ValorVentaProducto;
                }
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

            row["Id"] = Contador;
            row["Codigo"] = MiProducto.CodigoInternoProducto;
            row["Articulo"] = MiProducto.NombreProducto;
            row["Cantidad"] = Convert.ToDouble(this.txtCantidad.Text.Replace('.', ',')).ToString().Replace('.', ',');
            //row["Cantidad"] = txtCantidad.Text.Replace('.', ',');

            if (chkAlCosto.Checked)
            {
                row["ValorUnitario"] = valorUnitario;
            }
            else
            {
                if (miEmpresa.Regimen.IdRegimen == 1)  //Comun
                {
                    if (Convert.ToBoolean(AppConfiguracion.ValorSeccion("precio_venta_iva"))) // Precios incluye IVA
                    {
                        row["ValorUnitario"] = Math.Round((valorUnitario / (1 + (MiProducto.ValorIva / 100))), 1);
                        var j = row["ValorUnitario"].ToString();
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
            }

            if (DesctoAplica > 0)
            {
                row["Descuento"] = DesctoAplica.ToString() + "%";
                row["ValorMenosDescto"] = Convert.ToInt32(Convert.ToDouble(row["ValorUnitario"]) -
                    (Convert.ToDouble(row["ValorUnitario"]) * UseObject.RemoveCharacter(row["Descuento"].ToString(), '%') / 100));
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
                /*if (IdDesctoRecgo == 1)
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
                    row["ValorMenosDescto"] = Convert.ToInt32(Convert.ToInt32(row["ValorUnitario"]) -
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
                    row["ValorMenosDescto"] = Convert.ToInt32(Convert.ToInt32(row["ValorUnitario"]) +
                         (Convert.ToInt32(row["ValorUnitario"]) * UseObject.RemoveCharacter(row["Descuento"].ToString(), '%') / 100));
                }*/
            }

            if (miEmpresa.Regimen.IdRegimen == 1)  //Comun
            {
                row["Iva"] = MiProducto.ValorIva.ToString() + "%";
            }
            else
            {
                row["Iva"] = 0 + "%";
            }

            double vIva = Math.Round(
                    (Convert.ToDouble(row["ValorMenosDescto"]) *
                      UseObject.RemoveCharacter(row["Iva"].ToString(), '%') / 100), 1);

            //int AvIva = UseObject.AproximacionDian(vIva);
            //var vUnitario = Convert.ToInt32(row["ValorMenosDescto"]) + AvIva;

            var vUnitario = Convert.ToInt32(Convert.ToDouble(row["ValorMenosDescto"]) + vIva);

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

            //row["TotalMasIva"] = UseObject.Aproximar(vUnitario, Convert.ToBoolean(AppConfiguracion.ValorSeccion("tipo_aprox_precio")));

            /*row["TotalMasIva"] = Convert.ToInt32(
                                 (Convert.ToDouble(row["ValorMenosDescto"]) *
                                  UseObject.RemoveCharacter(row["Iva"].ToString(), '%') / 100) +
                                  Convert.ToDouble(row["ValorMenosDescto"]));*/
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
            txtDescuentoFactura.Enabled = false;
            RecargarGridview();
            LimpiarCampos();
            LoadColorSize = false;
            btnTallaYcolor.Enabled = false;
            DesctoAplica = 0.0;
        }

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
            if (!IdEstado.Equals(4))
            {
                try
                {
                    inventario.Cantidad = miBussinesInventario.CantidadInventario(inventario);
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
                if (chkAlCosto.Checked)
                {
                    valorUnitario = MiProducto.ValorCosto;
                }
                else
                {
                    valorUnitario = MiProducto.ValorVentaProducto;
                }
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

            valorUnitario -= Convert.ToInt32(this.MiProducto.Impoconsumo);

            row["Id"] = Contador;
            row["Codigo"] = MiProducto.CodigoInternoProducto;
            row["Articulo"] = MiProducto.NombreProducto;
            row["Cantidad"] = Convert.ToDouble(this.txtCantidad.Text.Replace('.', ',')).ToString().Replace('.', ',');
            row["Costo"] = Math.Round(MiProducto.ValorCosto + (MiProducto.ValorCosto * MiProducto.ValorIva / 100), 2);

            if (chkAlCosto.Checked)
            {
                row["ValorUnitario"] = valorUnitario;
            }
            else
            {
                if (miEmpresa.Regimen.IdRegimen == 1)  //Comun
                {
                    if (Convert.ToBoolean(AppConfiguracion.ValorSeccion("precio_venta_iva"))) // Precios incluye IVA
                    {
                        row["ValorUnitario"] = Math.Round((valorUnitario / (1 + (MiProducto.ValorIva / 100))), 1);
                        var j = row["ValorUnitario"].ToString();
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
            }
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
            }
            else
            {
                if (DesctoAplica > 0)
                {
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
                }
            }
            row["ValorMenosDescto"] = Math.Round((Convert.ToDouble(row["ValorUnitario"]) -
                    (Convert.ToDouble(row["ValorUnitario"]) * UseObject.RemoveCharacter(row["Descuento"].ToString(), '%') / 100)), 1);

            /*
            if (DesctoAplica > 0)
            {
                row["Descuento"] = DesctoAplica.ToString() + "%";
                row["ValorMenosDescto"] = Convert.ToInt32(Convert.ToDouble(row["ValorUnitario"]) -
                    (Convert.ToDouble(row["ValorUnitario"]) * UseObject.RemoveCharacter(row["Descuento"].ToString(), '%') / 100));
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
            }
            */
            row["Ico"] = MiProducto.Impoconsumo;

            if (miEmpresa.Regimen.IdRegimen == 1)  //Comun
            {
                row["Iva"] = MiProducto.ValorIva.ToString() + "%";
            }
            else
            {
                row["Iva"] = 0 + "%";
            }

            double vIva = Math.Round(
                    (Convert.ToDouble(row["ValorMenosDescto"]) *
                      UseObject.RemoveCharacter(row["Iva"].ToString(), '%') / 100), 1);

            //var vUnitario = Convert.ToInt32(Convert.ToDouble(row["ValorMenosDescto"]) + vIva);
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
            txtDescuentoFactura.Enabled = false;
            RecargarGridview();
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
            IEnumerable<DataRow> query = from datos in miTabla.AsEnumerable()
                                         orderby datos.Field<int>("Id") descending
                                         select datos;
            DataTable copy = query.CopyToDataTable<DataRow>();
            miBindingSource.DataSource = copy;
        }

        private void ConsultaInventario()
        {
            if (!ExtendForms)
            {
                if (_ConsultaInventario)
                {
                    var frmInventario = new Inventario.Consulta.FrmConsultaInventario();
                    frmInventario.ExtendVenta = true;
                    frmInventario.IsVenta = false;
                    frmInventario.Consulta = false;
                    frmInventario.ExtendForms_ = true;
                    frmInventario.MdiParent = this.MdiParent;
                    ExtendForms = true;
                    frmInventario.Show();
                    frmInventario.txtCodigoNombre.Focus();
                }
                else
                {
                    var frmInventario = new Inventario.Consulta.FrmInventario();
                    frmInventario.ExtendVenta = true;
                    frmInventario.IsVenta = false;

                    frmInventario.MdiParent = this.MdiParent;
                    ExtendForms = true;
                    frmInventario.Show();
                    frmInventario.txtCodigoNombre.Focus();
                }
            }
        }

        private void ActivarDescuento()
        {
            this.cbDesctoRecargo.SelectedValue = 1;
            this.cbDesctoRecargo_SelectionChangeCommitted(null, new EventArgs());
            var id = ((Inventario.Producto.Criterio)cbDesctoRecargo.SelectedItem).Id;
            if (id.Equals(1))
            {
                this.rbtnDesctoProducto.Checked = true;
                this.rbtnDesctoProducto_Click(this.rbtnDesctoProducto, new EventArgs());
                txtCodigoArticulo.Focus();
            }
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
        private void ActualizarInformacion(int rowIndex, string valor)
        {
            var id = Convert.ToInt32(dgvListaArticulos.Rows[rowIndex].Cells["Id"].Value);
            var query = (from datos in miTabla.AsEnumerable()
                         where datos.Field<int>("Id") == id
                         select datos).Single();
            var index = miTabla.Rows.IndexOf(query);

            miTabla.Rows[index]["ValorUnitario"] = Math.Round(((Convert.ToInt32(valor) - Convert.ToInt32(miTabla.Rows[index]["Ico"])) /
                ((UseObject.RemoveCharacter(miTabla.Rows[index]["Iva"].ToString(), '%') / 100) + 1)), 1);
            var vunit = miTabla.Rows[index]["ValorUnitario"].ToString();

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
            //RecargarRetencion();
            dgvListaArticulos.Focus();
            txtCodigoArticulo.Focus();


            /* var id = Convert.ToInt32(dgvListaArticulos.Rows[rowIndex].Cells["Id"].Value);
             var query = (from datos in miTabla.AsEnumerable()
                          where datos.Field<int>("Id") == id
                          select datos).Single();
             var index = miTabla.Rows.IndexOf(query);

             miTabla.Rows[index]["ValorUnitario"] = Math.Round((Convert.ToInt32(valor) /
                 ((UseObject.RemoveCharacter(miTabla.Rows[index]["Iva"].ToString(), '%') / 100) + 1)), 1);

             miTabla.Rows[index]["ValorMenosDescto"] =
                 Convert.ToDouble(Convert.ToInt32(miTabla.Rows[index]["ValorUnitario"]) +
                 (Convert.ToInt32(miTabla.Rows[index]["ValorUnitario"]) *
                 UseObject.RemoveCharacter(miTabla.Rows[index]["Descuento"].ToString(), '%') / 100));

             double vIva = Math.Round((
                           Convert.ToDouble(miTabla.Rows[index]["ValorMenosDescto"]) *
                           UseObject.RemoveCharacter(miTabla.Rows[index]["Iva"].ToString(), '%') / 100), 1);
             int aVIva = UseObject.AproximacionDian(vIva);

             var totalMasIva = Convert.ToInt32(miTabla.Rows[index]["ValorMenosDescto"]) + aVIva;

             miTabla.Rows[index]["TotalMasIva"] = totalMasIva;

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
             dgvListaArticulos.Focus();
             txtCodigoArticulo.Focus();*/
        }

        private void ActualizarInformacionCantidad_(int rowIndex, string valor)
        {
            var id = Convert.ToInt32(dgvListaArticulos.Rows[rowIndex].Cells["Id"].Value);
            var query = (from datos in miTabla.AsEnumerable()
                         where datos.Field<int>("Id") == id
                         select datos).Single();
            var index = miTabla.Rows.IndexOf(query);

            /*miTabla.Rows[index]["ValorUnitario"] = Math.Round((Convert.ToInt32(valor) /
                ((UseObject.RemoveCharacter(miTabla.Rows[index]["Iva"].ToString(), '%') / 100) + 1)), 1);
            var vunit = miTabla.Rows[index]["ValorUnitario"].ToString();*/
            miTabla.Rows[index]["Cantidad"] = valor.Replace('.', ',');

            //miTabla.Rows[index]["Descuento"] = "0%";

            var d = miTabla.Rows[index]["ValorUnitario"].ToString();

            /* miTabla.Rows[index]["ValorMenosDescto"] =
                 Convert.ToDouble(Convert.ToDouble(miTabla.Rows[index]["ValorUnitario"]) +
                 (Convert.ToInt32(miTabla.Rows[index]["ValorUnitario"]) *
                 UseObject.RemoveCharacter(miTabla.Rows[index]["Descuento"].ToString(), '%') / 100));*/

            var v_des = miTabla.Rows[index]["ValorMenosDescto"].ToString();

            double vIva = Math.Round((
                          Convert.ToDouble(miTabla.Rows[index]["ValorMenosDescto"]) *
                          UseObject.RemoveCharacter(miTabla.Rows[index]["Iva"].ToString(), '%') / 100), 1);

            var totalMasIva = Convert.ToInt32(Convert.ToDouble(miTabla.Rows[index]["ValorMenosDescto"]) + vIva);

            /*//miTabla.Rows[index]["TotalMasIva"] = totalMasIva;  // edicion no redondeo
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
            }*/
            // Edicion no redondeo

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
            //RecargarRetencion();
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

            miTabla.Rows[index]["Valor"] =
                Convert.ToDouble(miTabla.Rows[index]["TotalMasIva"]) *
                Convert.ToDouble(miTabla.Rows[index]["Cantidad"]);
            //var v = miTabla.Rows[index]["Valor"].ToString();

            RecargarGridview();
            txtTotal.Text = UseObject.InsertSeparatorMil
                (
                   Convert.ToInt32(
                   miTabla.AsEnumerable().Sum(s => s.Field<double>("Valor"))
                   ).ToString()
                );
            //RecargarRetencion();
            dgvListaArticulos.Focus();
            txtCodigoArticulo.Focus();
        }

        private void RealizarVenta_()
        {
            if (dgvListaArticulos.RowCount != 0)
            {
                if (String.IsNullOrEmpty(txtCliente.Text))
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
                dtpFechaLimite_Validating(this.dtpFechaLimite, new CancelEventArgs(false));
                if (ClienteMatch && LimiteMatch)
                {
                    /*DialogResult rta = MessageBox.Show("¿Esta seguro de querer hacer la Remisión?", "Remisión",
                            MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (rta.Equals(DialogResult.Yes))
                    {*/
                    if (IdEstado.Equals(1))
                    {
                        if (!ExtendForms)
                        {
                            var frmCancel = new Factura.FrmCancelarVenta();
                            // frmCancel.MdiParent = this.MdiParent;
                            frmCancel.txtTotal.Text = txtTotal.Text;
                            frmCancel.EsVenta = false;
                            ExtendForms = true;
                            Venta = true;
                            frmCancel.ShowDialog();
                        }
                    }
                    else
                    {
                        if (FacturaPos)
                        {
                            CargarYguardarFacturaPos();
                        }
                        else
                        {
                            CargarYguardarFacturaDespues();
                        }
                    }
                    //}
                }
            }
            else
            {
                OptionPane.MessageInformation("Debe cargar al menos un producto para realizar la Remisión.");
            }
        }

        private void RealizarVenta()
        {
            if (dgvListaArticulos.RowCount != 0)
            {
                if (String.IsNullOrEmpty(txtCliente.Text))
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
                dtpFechaLimite_Validating(this.dtpFechaLimite, new CancelEventArgs(false));
                if (ClienteMatch && LimiteMatch)
                {
                    if (IdEstado.Equals(1))
                    {
                        DialogResult rta_ = DialogResult.Yes;
                        if (this.miBono.Canje)
                        {
                            if (UseObject.RetiraDecima(UseObject.RemoveSeparatorMil(this.txtTotal.Text) / this.miBono.Valor) > 0)
                            {
                                if (this.txtCliente.Text == "1000" || this.txtCliente.Text == "10")
                                {
                                    rta_ = MessageBox.Show("¿Desea generar la remisión sin cliente?", "Remisión venta",
                                        MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                                }
                            }
                        }
                        if (rta_.Equals(DialogResult.Yes))
                        {
                            ///if (!ExtendForms)
                            ///{
                                var frmCancel = new Factura.FrmCancelarVenta();
                                frmCancel.txtTotal.Text = txtTotal.Text;
                                frmCancel.EsVenta = false;
                               /// ExtendForms = true;
                                Venta = true;
                                frmCancel.ShowDialog();
                                txtCodigoArticulo.Focus();
                           /// }
                        }
                        else
                        {
                            this.txtCliente.Focus();
                        }
                    }
                    else
                    {
                        if (FacturaPos)
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
            else
            {
                OptionPane.MessageInformation("Debe cargar al menos un producto para realizar la Remisión.");
            }
        }

        private void RetiroDeProducto()
        {
            if (dgvListaArticulos.RowCount != 0)
            {
                DialogResult rta = MessageBox.Show("¿Está seguro(a) de retirar el producto?", "Remisión de Venta",
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (rta.Equals(DialogResult.Yes))
                {
                    int id = (int)this.dgvListaArticulos.CurrentRow.Cells["Id"].Value;
                    var row = (from registro in miTabla.AsEnumerable()
                               where registro.Field<int>("Id") == id
                               select registro).Single();
                    miTabla.Rows.Remove(row);
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
                }
                /*string rta = CustomControl.OptionPane.OptionBox
                    ("Ingresar contraseña de Administrador .", "Administrador", CustomControl.OptionPane.Icon.LoginAdmin);
                if (!rta.Equals("false"))
                {
                    if (miBussinesUsuario.VerificarUsuarioAdmin(Encode.Encrypt(rta)))
                    {
                        int id = (int)this.dgvListaArticulos.CurrentRow.Cells["Id"].Value;
                        var row = (from registro in miTabla.AsEnumerable()
                                   where registro.Field<int>("Id") == id
                                   select registro).Single();
                        miTabla.Rows.Remove(row);
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
                    }
                    else
                    {
                        MessageBox.Show("La contraseña es Incorrecta.", "Factura Venta",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }*/
            }
        }

        private void ResetFactura()
        {
            // codigo anterior...
            /* miTabla.Rows.Clear();
             while (dgvListaArticulos.RowCount != 0)
             {
                 dgvListaArticulos.Rows.RemoveAt(0);
             }*/
            //tsCbContado.ComboBox.SelectedIndex = 0;
            //tsCbDesctoRecargo.ComboBox.SelectedIndex = 0;
            //txtCliente.Text = "";
            //txtNombreCliente.Text = "";
            //NitCliente = "";
            //txtCliente_KeyPress(this.txtCliente, new KeyPressEventArgs((char)Keys.Enter));
            /*dtpFechaLimite.Value = DateTime.Now;
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
            lblDatosProducto.Text = "";*/

            // Edición 09/02/2018
            miTabla.Rows.Clear();
            while (dgvListaArticulos.RowCount != 0)
            {
                dgvListaArticulos.Rows.RemoveAt(0);
            }
            cbContado.SelectedIndex = 0;
            this.cbContado_SelectionChangeCommitted(this.cbContado, new EventArgs());
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
            lblDatosProducto.Text = "";
            lblPrecioProducto.Text = "";
            DesctoAplica = 0;
        }

        private int MaxArticulosPrint { get { return 12; } }
        private List<PrintFactura> Facturas { set; get; }
        private bool ClienteMatch = false;

        private void CargarYguardarFactura()
        {
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
                //if (IdEstado == 1 || IdEstado == 2)  //Contado o Crédito
                //{
                ObtenerNumero();
                //contado_ = false;
                //}
                /*else   //Pendiente
                {
                    miFactura.Numero = ObtenerNumeroTemp();
                }*/
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
                miFactura.Caja.Id = 1;
                miFactura.EstadoFactura.Id = IdEstado;
                miFactura.FormasDePago = miFormasPago;
                miFactura.FechaIngreso = FechaHoy;
                miFactura.FechaLimite = dtpFechaLimite.Value;
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
                    //producto.Save = Convert.ToBoolean(row["Save"]);
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
                try
                {
                    miBussinesRemision.Ingresar(miFactura);
                    /*if (IdEstado == 3 || IdEstado == 4)
                    {
                        ActualizaNumeroTemp();
                    }*/
                }
                catch (Exception ex)
                {
                    OptionPane.MessageError(ex.Message);
                    break;
                }
                foreach (DataRow miRow in miRows)
                {
                    miTabla.Rows.Remove(miRow);
                }
            }
            OptionPane.MessageSuccess("La Remisión se guardó con éxito.");
            DialogResult rta = MessageBox.Show("¿Desea imprimir la Remisión?", "Remisión",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rta.Equals(DialogResult.Yes))
            {
                foreach (PrintFactura p in Facturas)
                {
                    Print(p.Numero, p.Descuento, p.Cliente, p.Contado, true);
                }
            }
            /*DialogResult rta = MessageBox.Show("¿Desea visualizar la impresión de la Remisión?", "Remisión",
                    MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
            if (rta.Equals(DialogResult.Yes))
            {
                foreach (PrintFactura p in Facturas)
                {
                    Print(p.Numero, p.Descuento, p.Cliente, p.Contado, true);
                }
            }
            else
            {
                if (rta.Equals(DialogResult.No))
                {
                    foreach (PrintFactura p in Facturas)
                    {
                        Print(p.Numero, p.Descuento, p.Cliente, p.Contado, false);
                    }
                }
            }*/
            LimpiarCamposNewFactura();
        }

        // funcional
        private void CargarYguardarFacturaDespues()
        {
            ObtenerNumero();
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
            miFactura.Proveedor.NitProveedor = NitCliente;
            miFactura.Caja.Id = Convert.ToInt32(AppConfiguracion.ValorSeccion("id_caja"));
            miFactura.EstadoFactura.Id = IdEstado;
            miFactura.FormasDePago = miFormasPago;
            miFactura.FechaIngreso = DateTime.Now;
            miFactura.FechaLimite = dtpFechaLimite.Value;
            List<ProductoFacturaProveedor> productos = new List<ProductoFacturaProveedor>();
            foreach (DataRow row in miTabla.Rows)
            {
                var producto = new ProductoFacturaProveedor();
                producto.NumeroFactura = miFactura.Numero;
                producto.Producto.CodigoInternoProducto = row["Codigo"].ToString();
                producto.Cantidad = Convert.ToDouble(row["Cantidad"]);
                producto.Producto.ValorVentaProducto = Convert.ToInt32(row["ValorUnitario"]);
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
                miBussinesRemision.Ingresar(miFactura);
                OptionPane.MessageSuccess("La Remisión se guardó con éxito.");

                /*DialogResult rta = MessageBox.Show("¿Desea visualizar la impresión de la Remisión?", "Remisión",
                                                   MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);*/
                FrmPrint frmPrint = new FrmPrint();
                frmPrint.StringCaption = "Remisión Venta";
                frmPrint.StringMessage = "Impresión de la Remisión Venta";
                DialogResult rta = frmPrint.ShowDialog();

                if (rta.Equals(DialogResult.Yes))
                {
                    Print(miFactura.Numero, miFactura.AplicaDescuento,
                          miFactura.Proveedor.NitProveedor, contado, false);
                }
                else
                {
                    if (rta.Equals(DialogResult.No))
                    {
                        Print(miFactura.Numero, miFactura.AplicaDescuento,
                          miFactura.Proveedor.NitProveedor, contado, true);
                    }
                }

                /*DialogResult rta = MessageBox.Show("¿Desea imprimir la Remisión?", "Remisión",
                                                   MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (rta.Equals(DialogResult.Yes))
                {
                    Print(miFactura.Numero, miFactura.AplicaDescuento,
                          miFactura.Proveedor.NitProveedor, contado, true);
                }*/

                LimpiarCamposNewFactura();
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
        }

        // funcional
        private void CargarYguardarFacturaPos()
        {
            ObtenerNumero();
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
            miFactura.Proveedor.NitProveedor = NitCliente;
            miFactura.Caja.Id = Convert.ToInt32(AppConfiguracion.ValorSeccion("id_caja"));
            miFactura.EstadoFactura.Id = IdEstado;
            miFactura.FormasDePago = miFormasPago;
            miFactura.FechaIngreso = DateTime.Now;
            miFactura.FechaLimite = dtpFechaLimite.Value;
            List<ProductoFacturaProveedor> productos = new List<ProductoFacturaProveedor>();
            foreach (DataRow row in miTabla.Rows)
            {
                var producto = new ProductoFacturaProveedor();
                producto.NumeroFactura = miFactura.Numero;
                producto.Producto.CodigoInternoProducto = row["Codigo"].ToString();
                producto.Cantidad = Convert.ToDouble(row["Cantidad"]);
                producto.Producto.ValorVentaProducto = Convert.ToDouble(row["ValorUnitario"]);
                producto.Inventario.CodigoProducto = row["Codigo"].ToString();
                producto.Inventario.IdMedida = Convert.ToInt32(row["IdMedida"]);
                producto.Inventario.IdColor = Convert.ToInt32(row["IdColor"]);
                producto.Producto.IdMarca = Convert.ToInt32(row["IdMarca"]);
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
                producto.ImpoConsumo = Convert.ToDouble(row["Ico"]);
                producto.Total = Convert.ToInt32(row["Valor"]);
                producto.Costo = Convert.ToInt32(row["Costo"]);
                productos.Add(producto);
            }
            miFactura.Productos = productos;
            try
            {
                miBussinesRemision.Ingresar(miFactura);

                Punto punto = new Punto();
                double[] data = new double[2];
                if (this.miFactura.Proveedor.NitProveedor != "1000" &&
                    this.miFactura.Proveedor.NitProveedor != "10")
                {
                    punto = this.miBussinesPunto.CargarPunto();
                    if (punto.EstadoPunto)
                    {
                        data = CargarPuntos(punto, miFactura.Proveedor.NitProveedor, miFactura.Numero, miFactura.AplicaDescuento);
                    }
                }
                /*OptionPane.MessageSuccess("La Remisión se guardó con éxito.");
                DialogResult rta = MessageBox.Show("¿Desea imprimir la Remisión?", "Remisión",
                                                   MessageBoxButtons.YesNo, MessageBoxIcon.Question);*/
                //if (rta.Equals(DialogResult.Yes))
                //{

                if (Ticket_)
                {
                    PrintPos(miFactura.Numero, miFactura.Proveedor.NitProveedor,
                        miFactura.AplicaDescuento, Convert.ToInt32(miFormasPago.Sum(d => d.Pago)), punto.EstadoPunto, data);
                }
                else
                {
                    FrmPrint_ frmPrint = new FrmPrint_();
                    frmPrint.StringCaption = "Remisión Venta";
                    frmPrint.StringMessage = "Impresión de la Remisión Venta";
                    DialogResult rta = frmPrint.ShowDialog();

                    if (rta.Equals(DialogResult.Yes))
                    {
                        Print(miFactura.Numero, miFactura.AplicaDescuento,
                              miFactura.Proveedor.NitProveedor, contado, false);
                    }
                    else
                    {
                        if (rta.Equals(DialogResult.No))
                        {
                            Print(miFactura.Numero, miFactura.AplicaDescuento,
                              miFactura.Proveedor.NitProveedor, contado, true);
                        }
                    }
                }

                if (this.miBono.Canje)
                {
                    int numeroBonos = UseObject.RetiraDecima(this.ValorPorMarcas() / this.miBono.Valor);
                    for (int i = 1; i <= numeroBonos; i++)
                    {
                        this.PrintBonoRifa(this.miBono, this.miFactura.Proveedor.NitProveedor, this.miFactura.Numero);
                    }
                }

                if (miFactura.EstadoFactura.Id.Equals(1))
                {
                    var frmCambio = new Factura.FrmCambio();
                    frmCambio.txtTotal.Text = this.txtTotal.Text;
                    frmCambio.txtEfectivo.Text = UseObject.InsertSeparatorMil(
                        Convert.ToInt32(miFormasPago.Sum(d => d.Pago)).ToString());
                    frmCambio.txtCambio.Text = UseObject.InsertSeparatorMil((
                        UseObject.RemoveSeparatorMil(frmCambio.txtEfectivo.Text) - UseObject.RemoveSeparatorMil(frmCambio.txtTotal.Text)).ToString());
                    frmCambio.ShowDialog();
                }
                //}
                LimpiarCamposNewFactura();
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
        }

        private double[] CargarPuntos(Punto punto, string nitCliente, string numero, bool descto)
        {
            double[] data = new double[2];
            try
            {
                int total =
                    this.miBussinesRemision.PrintProducto(Convert.ToInt32(numero), descto).Tables[0].AsEnumerable().Sum(d => d.Field<int>("Total_"));
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
                    var productos = this.miFactura.Productos.Where(p_ => p_.Producto.IdMarca.Equals(idMarca));
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
            while (dgvListaArticulos.RowCount != 0)
            {
                dgvListaArticulos.Rows.RemoveAt(0);
            }
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

            miFormasPago.Clear();
            txtCantidad.Text = "1";
            lblDatosProducto.Text = "";
            lblPrecioProducto.Text = "";
            txtTotal.Text = "0";
            txtDescuentoFactura.Text = "0";
            rbtnDesctoFactura.Checked = true;
            cbContado.SelectedIndex = 0;
            cbDesctoRecargo.SelectedIndex = 0;
            cbContado_SelectionChangeCommitted(null, null);
            cbDescuentoProducto.Enabled = false;
            cbRecargoProducto.Enabled = false;
            lblDescuentoFactura.Text = "Descto/Fact";
            lblDesctoProducto.Text = "Descto%";
            miTabla.Clear();
            txtCodigoArticulo.Focus();
        }

        private void CargarFacturaEdicion()
        {
            //tsCbContado.ComboBox.SelectedValue = Factura.EstadoFactura.Id;
            if (Factura.AplicaDescuento)
            {
                //tsCbDesctoRecargo.ComboBox.SelectedValue = 1;
            }
            else
            {
                // tsCbDesctoRecargo.ComboBox.SelectedValue = 2;
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

        private void Print
            (string numero, bool descto, string cliente, bool contado, bool view)
        {
            var dsDetalle = new DataSet();
            var dsEmpresa = new DataSet();
            var dsFactura = new DataSet();
            var dsUsuario = new DataSet();
            var dsCliente = new DataSet();
            var dsDian = new DataSet();
            try
            {
                dsDetalle = miBussinesRemision.PrintProducto(Convert.ToInt32(numero), descto);
                dsEmpresa = miBussinesEmpresa.PrintEmpresa();
                dsFactura = miBussinesRemision.PrintRemision(numero);
                dsUsuario = miBussinesUsuario.PrintUsuarioRemision(Convert.ToInt32(numero));
                dsCliente = miBussinesCliente.PrintCliente(cliente);

                var frmPrint = new Factura.FrmPrintFactura();
                frmPrint.Text = "Imprimir Remisión";
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

                frmPrint.RptvFactura.LocalReport.ReportPath = AppConfiguracion.ValorSeccion("report") + @"\reports\RptRemision.rdlc";
                ///frmPrint.RptvFactura.LocalReport.ReportPath = @"C:\reports\RptRemision.rdlc";

                Label NoFactura = new Label();
                NoFactura.AutoSize = true;
                NoFactura.Font = new
                 System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                NoFactura.Text = numero;

                var Fact = new ReportParameter();
                Fact.Name = "Fact";
                Fact.Values.Add("REMISIÓN No.  " + NoFactura.Text);
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

        private void PrintPos(string numero, string cliente, bool descto, int pago)
        {
            try
            {
                DialogResult rta = DialogResult.Yes;
                if (Convert.ToBoolean(AppConfiguracion.ValorSeccion("preguntaPrintVenta")))
                {
                    rta = MessageBox.Show("¿Desea imprimir la remisión?", "Remisión venta",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                }
                if (rta.Equals(DialogResult.Yes))
                {
                    var empresaRow = miBussinesEmpresa.PrintEmpresa().
                                     Tables[0].AsEnumerable().First();
                    var remisionRow = miBussinesRemision.PrintRemision(numero).
                                             Tables[0].AsEnumerable().First();
                    var usuarioRow = miBussinesUsuario.PrintUsuarioRemision(Convert.ToInt32(numero)).
                                                                    Tables[0].AsEnumerable().First();
                    var clienteRow = miBussinesCliente.PrintCliente(cliente).
                                                Tables[0].AsEnumerable().First();
                    var tDetalle = miBussinesRemision.PrintProducto(Convert.ToInt32(numero), descto).Tables[0];

                    Ticket ticket = new Ticket();
                    ticket.UseItem = false;

                    ticket.AddHeaderLine(empresaRow["Nombre"].ToString().ToUpper());
                    ticket.AddHeaderLine(empresaRow["Juridico"].ToString());
                    ticket.AddHeaderLine("NIT " + UseObject.InsertSeparatorMilMasDigito(empresaRow["Nit"].ToString()));
                    ticket.AddHeaderLine(empresaRow["Direccion"].ToString());
                    ticket.AddHeaderLine("Tels. " + empresaRow["Telefono"].ToString());
                    ticket.AddHeaderLine("REGIMEN " + UseObject.Split(empresaRow["Regimen"].ToString(), 5) +
                                         "      REMISIÓN");
                    ticket.AddHeaderLine("Fecha : " + Convert.ToDateTime(remisionRow["Fecha"]).ToShortDateString() +
                                         " Nro " + numero);
                    ticket.AddHeaderLine("Hora  : " + Convert.ToDateTime(remisionRow["Hora"]).ToShortTimeString() +
                                         " Caja  : " + remisionRow["NoCaja"].ToString());

                    if (!Convert.ToInt32(remisionRow["IdEstado"]).Equals(1))  // Estado : Crédito
                    {
                        ticket.AddHeaderLine(remisionRow["Estado"].ToString().ToUpper() + "  Fecha Limite : " +
                                         Convert.ToDateTime(remisionRow["FechaLimite"]).ToShortDateString());
                    }
                    ticket.AddHeaderLine("Cajero(a)  :  " + usuarioRow["Nombre"].ToString());
                    ticket.AddHeaderLine("===================================");
                    ticket.AddHeaderLine("CLIENTE : " + clienteRow["Nombre"].ToString());
                    ticket.AddHeaderLine("NIT     : " + UseObject.InsertSeparatorMilMasDigito(clienteRow["Nit"].ToString()));
                    ticket.AddHeaderLine("===================================");
                    ticket.AddHeaderLine("");

                    if (this.GraneroJhonRiosucio)
                    {
                        this.PrintDetail(tDetalle, ticket);
                    }
                    else
                    {
                        ticket.AddHeaderLine("COD.  DESCRIP.  CANT.  VENTA  TOTAL");
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
                    }

                    ticket.AddHeaderLine("");
                    ticket.AddHeaderLine("===================================");
                    ticket.AddHeaderLine("");

                    var total = tDetalle.AsEnumerable().Sum(d => d.Field<int>("Total_"));
                    ticket.AddHeaderLine("TOTAL     : " + UseObject.InsertSeparatorMil(total.ToString()));
                    if (Convert.ToInt32(remisionRow["IdEstado"]).Equals(1))
                    {
                        ticket.AddHeaderLine("EFECTIVO  : " + UseObject.InsertSeparatorMil(pago.ToString()));
                        ticket.AddHeaderLine("CAMBIO    : " + UseObject.InsertSeparatorMil((pago - total).ToString()));
                    }
                    else
                    {
                        if (Convert.ToInt32(remisionRow["IdEstado"]).Equals(2))
                        {
                            ticket.AddHeaderLine("EFECTIVO  : " + "0");
                            ticket.AddHeaderLine("CAMBIO    : " + "0");
                        }
                    }
                    ticket.AddHeaderLine("-----------------------------------");
                    ticket.AddHeaderLine("Software: DFPyme");
                    ticket.AddHeaderLine("");
                    ticket.AddHeaderLine("*GRACIAS POR SER NUESTROS CLIENTES*");
                    ticket.AddHeaderLine("");
                    ticket.AddHeaderLine("");

                    ticket.PrintTicket("IMPREPOS");

                    /*ticket.AddTotal("TOTAL     : ", UseObject.InsertSeparatorMil(total.ToString()));
                    if (Convert.ToInt32(remisionRow["IdEstado"]).Equals(1))
                    {
                        ticket.AddTotal("EFECTIVO  : ", UseObject.InsertSeparatorMil(pago.ToString()));
                        ticket.AddTotal("CAMBIO    : ", UseObject.InsertSeparatorMil((pago - total).ToString()));
                        var q = "CAMBIO    : " + UseObject.InsertSeparatorMil((pago - total).ToString());
                    }
                    else
                    {
                        ticket.AddTotal("EFECTIVO  : ", "0");
                        ticket.AddTotal("CAMBIO    : ", "0");
                    }
                    ticket.AddHeaderLine("===================================");  // Revisar
                    ticket.AddFooterLine(".");
                    ticket.AddFooterLine(".");
                    ticket.AddFooterLine("Software: DFPyme");
                    ticket.AddFooterLine(".");
                    ticket.AddFooterLine("*GRACIAS POR SER NUESTROS CLIENTES*");
                    ticket.AddFooterLine(".");
                    ticket.AddFooterLine(".");

                    ticket.PrintTicket("IMPREPOS");*/
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

        // Incluye puntos
        private void PrintPos(string numero, string cliente, bool descto, int pago, bool puntos, double[] data)
        {
            try
            {
                DialogResult rta = DialogResult.Yes;
                if (Convert.ToBoolean(AppConfiguracion.ValorSeccion("preguntaPrintVenta")))
                {
                    rta = MessageBox.Show("¿Desea imprimir la remisión?", "Remisión venta",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                }
                if (rta.Equals(DialogResult.Yes))
                {
                    var remisionRow = this.miBussinesRemision.PrintRemision(numero).Tables[0].AsEnumerable().First();

                    PrintTicket printTicket = new PrintTicket();
                    printTicket.UseItem = false;
                    printTicket.Detail = this.GraneroJhonRiosucio;
                    printTicket.EsFactura = false;
                    printTicket.Copia = false;
                    printTicket.Puntos = puntos;
                    printTicket.DescuentoMarca = this.DescuentoMarca;

                    printTicket.empresaRow = this.miBussinesEmpresa.PrintEmpresa().Tables[0].AsEnumerable().First();

                    printTicket.IdEstado = Convert.ToInt32(remisionRow["IdEstado"]);
                    printTicket.Numero = numero;
                    printTicket.Fecha = Convert.ToDateTime(remisionRow["Fecha"]);
                    printTicket.Hora = Convert.ToDateTime(remisionRow["Hora"]);
                    printTicket.Limite = Convert.ToDateTime(remisionRow["FechaLimite"]);
                    printTicket.Usuario = this.miBussinesUsuario.PrintUsuarioRemision(
                        Convert.ToInt32(numero)).Tables[0].AsEnumerable().First()["Nombre"].ToString();
                    printTicket.NoCaja = remisionRow["NoCaja"].ToString();
                    printTicket.clienteRow = this.miBussinesCliente.ConsultaClienteNit(cliente).AsEnumerable().First();

                    printTicket.tDetalle = this.miBussinesRemision.PrintProducto(Convert.ToInt32(numero), descto).Tables[0];
                    printTicket.Pago = pago;

                    if (cliente != "10" && cliente != "1000")
                    {
                        //printTicket.Puntos = true;
                        printTicket.DataPuntos = data;
                    }
                    var lstProducto = new List<ProductoFacturaProveedor>();
                    /*foreach (DataRow dRow in printTicket.tDetalle.Rows)
                    {
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
                    // printTicket.Puntos = puntos;
                    //printTicket.DataPuntos = data;

                    printTicket.Ahorro = Convert.ToInt32(lstProducto.Sum(s => s.Valor * s.Cantidad)) -
                                            printTicket.tDetalle.AsEnumerable().Sum(d => d.Field<int>("Total_"));

                    printTicket.ImprimirRemisionVenta();

                    /*
                    var empresaRow = miBussinesEmpresa.PrintEmpresa().
                                     Tables[0].AsEnumerable().First();
                    var remisionRow = miBussinesRemision.PrintRemision(numero).
                                             Tables[0].AsEnumerable().First();
                    var usuarioRow = miBussinesUsuario.PrintUsuarioRemision(Convert.ToInt32(numero)).
                                                                    Tables[0].AsEnumerable().First();
                    var clienteRow = miBussinesCliente.PrintCliente(cliente).
                                                Tables[0].AsEnumerable().First();
                    var tDetalle = miBussinesRemision.PrintProducto(Convert.ToInt32(numero), descto).Tables[0];

                    /*
                    Ticket ticket = new Ticket();
                    ticket.UseItem = false;

                    ticket.AddHeaderLine(empresaRow["Nombre"].ToString().ToUpper());
                    ticket.AddHeaderLine(empresaRow["Juridico"].ToString());
                    ticket.AddHeaderLine("NIT " + UseObject.InsertSeparatorMilMasDigito(empresaRow["Nit"].ToString()));
                    ticket.AddHeaderLine(empresaRow["Direccion"].ToString());
                    ticket.AddHeaderLine("Tels. " + empresaRow["Telefono"].ToString());


                    ticket.AddHeaderLine("REGIMEN " + UseObject.Split(empresaRow["Regimen"].ToString(), 5) +
                                         "      REMISIÓN");
                    ticket.AddHeaderLine("Fecha : " + Convert.ToDateTime(remisionRow["Fecha"]).ToShortDateString() +
                                         " Nro " + numero);
                    ticket.AddHeaderLine("Hora  : " + Convert.ToDateTime(remisionRow["Hora"]).ToShortTimeString() +
                                         " Caja  : " + remisionRow["NoCaja"].ToString());

                    if (!Convert.ToInt32(remisionRow["IdEstado"]).Equals(1))  // Estado : Crédito
                    {
                        ticket.AddHeaderLine(remisionRow["Estado"].ToString().ToUpper() + "  Fecha Limite : " +
                                         Convert.ToDateTime(remisionRow["FechaLimite"]).ToShortDateString());
                    }
                    ticket.AddHeaderLine("Cajero(a)  :  " + usuarioRow["Nombre"].ToString());
                    ticket.AddHeaderLine("===================================");
                    ticket.AddHeaderLine("CLIENTE : " + clienteRow["Nombre"].ToString());
                    ticket.AddHeaderLine("NIT     : " + UseObject.InsertSeparatorMilMasDigito(clienteRow["Nit"].ToString()));
                    ticket.AddHeaderLine("===================================");
                    ticket.AddHeaderLine("");

                    var lstProducto = new List<ProductoFacturaProveedor>();
                    if (this.GraneroJhonRiosucio)
                    {
                        this.PrintDetail(tDetalle, ticket);
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

                    ticket.AddHeaderLine("");
                    ticket.AddHeaderLine("===================================");
                    ticket.AddHeaderLine("");

                    var total = tDetalle.AsEnumerable().Sum(d => d.Field<int>("Total_"));
                    ticket.AddHeaderLine("TOTAL     : " + UseObject.InsertSeparatorMil(total.ToString()));
                    if (Convert.ToInt32(remisionRow["IdEstado"]).Equals(1))
                    {
                        ticket.AddHeaderLine("EFECTIVO  : " + UseObject.InsertSeparatorMil(pago.ToString()));
                        ticket.AddHeaderLine("CAMBIO    : " + UseObject.InsertSeparatorMil((pago - total).ToString()));
                    }
                    else
                    {
                        if (Convert.ToInt32(remisionRow["IdEstado"]).Equals(2))
                        {
                            ticket.AddHeaderLine("EFECTIVO  : " + "0");
                            ticket.AddHeaderLine("CAMBIO    : " + "0");
                        }
                    }
                    if (puntos)
                    {
                        ticket.AddHeaderLine("-----------------------------------");
                        ticket.AddHeaderLine("");
                        ticket.AddHeaderLine("Puntos:              " + data[0].ToString());
                        ticket.AddHeaderLine("Puntos acumulados:   " + data[1].ToString());
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
                    ticket.AddHeaderLine("-----------------------------------");
                    ticket.AddHeaderLine("Software: DFPyme");
                    ticket.AddHeaderLine("");
                    ticket.AddHeaderLine("*GRACIAS POR SER NUESTROS CLIENTES*");
                    ticket.AddHeaderLine("");
                    ticket.AddHeaderLine("");

                    ticket.PrintTicket("IMPREPOS");
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

        private void PrintDetail(DataTable tDetalle, Ticket ticket)
        {
            //ticket.AddHeaderLine("CANT  DESCRIPCION           IMPORTE");
            ticket.AddHeaderLine("CANT  DESCRIPCION             TOTAL");
            ticket.AddHeaderLine("");
            foreach (DataRow dRow in tDetalle.Rows)
            {
                /* lstProducto.Add(new ProductoFacturaProveedor
                 {
                     Cantidad = Convert.ToDouble(dRow["Cantidad"]),
                     Valor = this.miBussinesProducto.ValorDeProducto(dRow["Codigo"].ToString())
                 });*/
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
                dtpFechaLimite.Value = DateTime.Today;
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

        private void cbContado_SelectionChangeCommitted(object sender, EventArgs e)
        {
            IdEstado = Convert.ToInt32(((DataRowView)cbContado.SelectedItem)["idestado"]);
            if (IdEstado != 2)
            {
                contado = true;
                lblFecha.Text = "Fecha";
                lblDataFecha.Visible = true;
                dtpFechaLimite.Value = DateTime.Today;
                dtpFechaLimite.Visible = false;
                if (IdEstado == 1)
                {
                    lblInfoEstado.Text = "Remisión de Contado.";
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
            }
            else   //Credito
            {
                lblInfoEstado.Text = "Remisión a Crédito.";
                contado = false;
                lblFecha.Text = "Fecha Limte";
                lblDataFecha.Visible = false;
                dtpFechaLimite.Visible = true;
            }
        }

        private void cbDesctoRecargo_SelectionChangeCommitted(object sender, EventArgs e)
        {
            rbtnDesctoFactura.Checked = true;
            if (dgvListaArticulos.RowCount == 0)
            {
                IdDesctoRecgo = ((Inventario.Producto.Criterio)cbDesctoRecargo.SelectedItem).Id;
                if (IdDesctoRecgo == 1)
                {
                    lblDescuentoFactura.Text = "Descto/Rem";
                    lblDesctoProducto.Text = "Descto%";
                    miToolTip.SetToolTip(rbtnDesctoProducto, "Aplicar descuento por Producto.");
                    miToolTip.SetToolTip(pbProducto, "Aplicar descuento por Producto.");
                    miToolTip.SetToolTip(rbtnDesctoFactura, "Aplicar descuento por Remisión.");
                    miToolTip.SetToolTip(pbFactura, "Aplicar descuento por Remisión.");
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
                        lblDescuentoFactura.Text = "Recargo/Rem";
                        lblDesctoProducto.Text = "Recargo%";
                        miToolTip.SetToolTip(rbtnDesctoProducto, "Aplicar recargo por Producto.");
                        miToolTip.SetToolTip(pbProducto, "Aplicar recargo por Producto.");
                        miToolTip.SetToolTip(rbtnDesctoFactura, "Aplicar recargo por Remisión.");
                        miToolTip.SetToolTip(pbFactura, "Aplicar recargo por Remisión.");
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
                //CargarDescuentosORecargos();
            }
            else
            {
                if (MsnDescto)
                {
                    OptionPane.MessageInformation
                            ("Este cambio no se puede realizar debido a que hay registros en la Remisión.");
                    MsnDescto = false;
                }
                cbDesctoRecargo.SelectedValue = IdDesctoRecgo;
            }
            MsnDescto = true;
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
        public string Numero { set; get; }

        public bool Descuento { set; get; }

        public string Cliente { set; get; }

        public bool Contado { set; get; }
    }
}