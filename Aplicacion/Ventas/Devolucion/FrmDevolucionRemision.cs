using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Utilities;
using CustomControl;
using BussinesLayer.Clases;
using DTO.Clases;
using Aplicacion.Compras.IngresarCompra;

namespace Aplicacion.Ventas.Devolucion
{
    public partial class FrmDevolucionRemision : Form
    {
        #region Atributos

        /// <summary>
        /// Representa un objeto para la carga de datos de la Empresa.
        /// </summary>
        private Empresa miEmpresa;

        /// <summary>
        /// Objeto para acceder a los datos de Factura de Venta.
        /// </summary>
        private FacturaVenta Factura { set; get; }

        /// <summary>
        /// Obtiene o establece el valor del Id del usuario que tiene la sesión actual.
        /// </summary>
        private int IdUsuario { set; get; }

        /// <summary>
        /// Obtiene o establece el valor del Id de la caja que usa el equipo.
        /// </summary>
        private int IdCaja { set; get; }

        /// <summary>
        /// Representa una tabla de datos en memoria.
        /// </summary>
        private DataTable miTabla;

        /// <summary>
        /// Colección que almacena objetos, en este caso Productos.
        /// </summary>
        private ArrayList ArrayProducto { set; get; }

        /// <summary>
        /// Objeto para cargar Producto.
        /// </summary>
        private Producto MiProducto { set; get; }

        /// <summary>
        /// Objeto para cargar los datos de la medida del producto consultado.
        /// </summary>
        private ValorUnidadMedida MiMedida { set; get; }

        /// <summary>
        /// Objeto para la carga del talla y color del producto.
        /// </summary>
        private TallaYcolor miTallaYcolor;

        /// <summary>
        /// Obtiene o establece el número de Facturas a promediar.
        /// </summary>
        private int NumeroDeFacturas;

        /// <summary>
        /// Indica si se realiza un promedio de Facturas de Compra o 
        /// se tiene en cuenta la última, true indica promedio.
        /// </summary>
        private bool Promedio;

        #endregion

        #region Lógica de Negocio

        /// <summary>
        /// Objeto que encapsula la lógica de negocio de Empresa.
        /// </summary>
        private BussinesEmpresa miBussinesEmpresa;

        /// <summary>
        /// Objeto que encapsula la lógica de negocio de Descuento.
        /// </summary>
        private BussinesDescuento miBussinesDescto;

        /// <summary>
        /// Objeto que encapsula la lógica de negocio de Producto.
        /// </summary>
        private BussinesProducto miBussinesProducto;

        /// <summary>
        /// Objeto que encapsula la lógica de negocio de Factura Venta.
        /// </summary>
        private BussinesFacturaVenta miBussinesFactura;

        private BussinesRemision miBussinesRemision;

        /// <summary>
        /// Objeto que encapsula la lógica de negocio de las Unidades de Medida.
        /// </summary>
        private BussinesValorUnidadMedida miBussinesMedida;

        /// <summary>
        /// Objeto que encapsula la lógica de negocio de Color.
        /// </summary>
        private BussinesColor miBussinesColor;

        /// <summary>
        /// Objeto que encapsula la lógica de negocio de Devolución.
        /// </summary>
        private BussinesDevolucion miBussinesDevolucion;

        /// <summary>
        /// Objeto que encapsula la lógica de negocio de Bono.
        /// </summary>
        private BussinesBono miBussinesBono;

        private BussinesCliente miBussinesCliente;

        #endregion

        #region Valición

        /// <summary>
        /// Objeto que permite acceder a la validación de datos.
        /// </summary>
        private Validacion MiValidacion;

        /// <summary>
        /// Representa un objeto para asociar mensajes de error en el formulario.
        /// </summary>
        private ErrorProvider miError;

        /// <summary>
        /// Obtiene o establece el valor que indica si se habilita color o no en el formulario segun la configuración.
        /// </summary>
        private bool EnableColor;

        /// <summary>
        /// Indica que se ha cargado la Talla y el Color desde el Boton Agregar Registro.
        /// </summary>
        private bool LoadColorSize = false;

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
        /// Representa el texto: El número de Factura es requerido.
        /// </summary>
        string FacturaReq = "El número de Factura es requerido.";

        /// <summary>
        /// Representa el texto: El número de Factura que ingreso es invalido.
        /// </summary>
        string FacturaFormat = "El número de Factura que ingreso es invalido.";

        /// <summary>
        /// Representa el texto: La Factura que ingreso no existe o ocurrió un error al cargarla.
        /// </summary>
        string FacturaLoad = "La Factura que ingreso no existe o ocurrió un error al cargarla.";

        #endregion

        #region Utilidades

        /// <summary>
        /// Objeto para mostrar ventanas emergentes en diferentes controles.
        /// </summary>
        private ToolTip miToolTip;

        /// <summary>
        /// Establece la condición que indica si se ha abierto otro Formulario de extensión.
        /// </summary>
        private bool FormExtend = false;

        /// <summary>
        /// Obtiene o establece la colección de datos de los productos incluidos en la Remisión.
        /// </summary>
        private List<DetalleProducto> Detalle { set; get; }

        /// <summary>
        /// Obtiene o establece la colección de datos de los productos incluidos en la devolución a la remisión actual.
        /// </summary>
        private List<DetalleProducto> Devoluciones { set; get; }

        /// <summary>
        /// Representa una variable para realizar conteo.
        /// </summary>
        private int Contador = 0;

        /// <summary>
        /// Objeto que encapsula el origen de datos del DataGrid de Productos.
        /// </summary>
        private BindingSource miBindingSource;

        #endregion

        public FrmDevolucionRemision()
        {
            InitializeComponent();
            EnableColor = Convert.ToBoolean(AppConfiguracion.ValorSeccion("color"));
            Promedio = Convert.ToBoolean(AppConfiguracion.ValorSeccion("promedio"));
            NumeroDeFacturas = Convert.ToInt32(AppConfiguracion.ValorSeccion("numero"));
            IdUsuario = Convert.ToInt32(AppConfiguracion.ValorSeccion("id_user"));
            IdCaja = Convert.ToInt32(AppConfiguracion.ValorSeccion("id_caja"));
            MiValidacion = new Validacion();
            Detalle = new List<DetalleProducto>();
            Devoluciones = new List<DetalleProducto>();
            miBindingSource = new BindingSource();
            CrearDataTable();
            miToolTip = new ToolTip();
            miError = new ErrorProvider();
            miBussinesEmpresa = new BussinesEmpresa();
            miBussinesDescto = new BussinesDescuento();
            miBussinesFactura = new BussinesFacturaVenta();
            miBussinesRemision = new BussinesRemision();
            miBussinesMedida = new BussinesValorUnidadMedida();
            miBussinesProducto = new BussinesProducto();
            miTallaYcolor = new TallaYcolor();
            miBussinesColor = new BussinesColor();
            miBussinesDevolucion = new BussinesDevolucion();
            miBussinesBono = new BussinesBono();
            miBussinesCliente = new BussinesCliente();
            CargarEmpresa();

            Factura = new FacturaVenta();
            Factura.Numero = "0";
            Factura.AplicaDescuento = false;
        }

        private void FrmDevolucion_Load(object sender, EventArgs e)
        {
            this.tsBtnCambiarPrecio.Image = ((Image)(miResources.GetObject("tsCambiarPrecio.Image")));
            CompletaEventos.Completam +=
                new CompletaEventos.CompletaAccionm(CompletaEventosm_Completo);
            CompletaEventos.Completa += new CompletaEventos.CompletaAccion(CompletaEventos_Completo);
            CompletaEventos.Completabo += new CompletaEventos.CompletaAccionbo(CompletaEventosbo_Completo);
            CompletaEventos.CompTProductoFact += 
                new CompletaEventos.ComAxTransferProductFact(CompletaEventos_CompTProductoFact);
            CargarUtilidades();
            dgvListaArticulos.AutoGenerateColumns = false;
            dgvListaArticulos.DataSource = miBindingSource;
        }

        private void FrmDevolucion_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyData)
            {
                case Keys.F2:
                    {
                        this.tsBtnGuardar_Click(this.tsBtnGuardar, new EventArgs());
                        break;
                    }
                case Keys.F3:
                    {
                        this.tsBtnCambiarPrecio_Click(this.tsBtnCambiarPrecio, new EventArgs());
                        break;
                    }
                case Keys.F4:
                    {
                        this.tsBtnRetiro_Click(this.tsBtnRetiro, new EventArgs());
                        break;
                    }
                case Keys.F5:
                    {
                        this.tsBtnResetear_Click(this.tsBtnResetear, new EventArgs());
                        break;
                    }
                case Keys.Escape:
                    {
                        this.tsBtnSalir_Click(this.tsBtnSalir, new EventArgs());
                        break;
                    }
            }
        }

        private void FrmDevolucion_FormClosing(object sender, FormClosingEventArgs e)
        {

        }

        private void tsBtnBuscarProducto_Click(object sender, EventArgs e)
        {
            if (!FormExtend)
            {
                var frmProducto = new Inventario.Producto.FrmIngresarProducto();
                frmProducto.Extencion = true;
                frmProducto.Devolucion = true;
                frmProducto.tabControlProducto.SelectedIndex = 1;
                frmProducto.MdiParent = this.MdiParent;
                FormExtend = true;
                frmProducto.Show();
            }
        }

        private void tsBtnCambiarPrecio_Click(object sender, EventArgs e)
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

        private void tsBtnRetiro_Click(object sender, EventArgs e)
        {
            if (dgvListaArticulos.RowCount != 0)
            {
                //pass admin?
                var id = (int)dgvListaArticulos.CurrentRow.Cells["Id"].Value;
                var row = (from data in miTabla.AsEnumerable()
                           where data.Field<int>("Id") == id
                           select data).Single();
                var find = Devoluciones.First
                    (d => d.Codigo == row["Codigo"].ToString()
                       && d.Medida == Convert.ToInt32(row["IdMedida"])
                       && d.Color == Convert.ToInt32(row["IdColor"])
                       && d.Cantidad == Convert.ToDouble(row["Cantidad"])
                    );
                Devoluciones.Remove(find);
                miTabla.Rows.Remove(row);
                if (miTabla.Rows.Count != 0)
                {
                    RecargarGridview();
                }
                else
                {
                    dgvListaArticulos.Rows.RemoveAt(dgvListaArticulos.CurrentCell.RowIndex);
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
                OptionPane.MessageInformation("No hay registro para retirar.");
            }
        }

        private void tsBtnGuardar_Click(object sender, EventArgs e)
        {
            DialogResult rta = MessageBox.Show("¿Está seguro(a) de guardar la devolución?", "Devolución",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rta.Equals(DialogResult.Yes))
            {
                miError.SetError(txtCantidad, null);
                miError.SetError(txtCodigoArticulo, null);
                try
                {
                    foreach (DataRow row in miTabla.Rows)
                    {
                        var devolucion = new DTO.Clases.Devolucion();
                        devolucion.Factura = Factura.Numero;
                        devolucion.Producto.CodigoProducto = row["Codigo"].ToString();
                        devolucion.Fecha = DateTime.Now;
                        var i = devolucion.Fecha.TimeOfDay;
                        devolucion.Valor = Convert.ToInt32(row["ValorUnitario"]);
                        devolucion.Cantidad = Convert.ToDouble(row["Cantidad"]);
                        devolucion.Iva = UseObject.RemoveCharacter(row["Iva"].ToString(), '%');//Convert.ToDouble(row["Iva"]);
                        devolucion.Producto.IdMedida = Convert.ToInt32(row["IdMedida"]);
                        devolucion.Producto.IdColor = Convert.ToInt32(row["IdColor"]);
                        devolucion.Descuento = Factura.AplicaDescuento;
                        devolucion.Descto = UseObject.RemoveCharacter(row["Descuento"].ToString(), '%'); //Convert.ToDouble(row["Descuento"]);
                        devolucion.IdUsuario = IdUsuario;
                        devolucion.IdCaja = IdCaja;
                        miBussinesDevolucion.IngresarRemision(devolucion);
                    }
                    /*var saldo = new Saldo();
                    saldo.NitCliente = Factura.Proveedor.NitProveedor;
                    saldo.IdUsuario = IdUsuario;
                    saldo.IdCaja = IdCaja;
                    saldo.Fecha = DateTime.Today;
                    saldo.Valor = Convert.ToInt32(UseObject.RemoveSeparatorMil(txtTotal.Text));
                    saldo.VSaldo = 0;
                    saldo.Estado = false;
                    miBussinesCliente.IngresarSaldo(saldo);*/
                    OptionPane.MessageInformation("La devolución se guardó con éxito.");
                    /*rta = MessageBox.Show("¿Quiere hacer efectiva la devolución?\nDe lo contrario generara un saldo al cliente.",
                        "Devolución", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (rta.Equals(DialogResult.Yes))//cobra la totalidad de la devolución
                    {
                        GuardaSeguimientoBono(GuardarBono(Factura.Proveedor.NitProveedor));
                        OptionPane.MessageInformation("La devolución se hizo efectiva correctamente.");
                        LimpiarCamposNewDevolucion();
                    }
                    else//no se cobra y genera saldo, Cliente requerido
                    {
                        if (!Factura.Proveedor.NitProveedor.Equals("1000"))//sin cliente general(guarda saldo)
                        {
                            GuardarBono(Factura.Proveedor.NitProveedor);
                            OptionPane.MessageInformation("El saldo se guardó con éxito, y está a favor del cliente de la factura.");
                            LimpiarCamposNewDevolucion();
                        }
                        else//con cliente general(ingresa cliente, edita fact y gurda saldo)
                        {
                            OptionPane.MessageInformation("No se puede ingresar un saldo con el Cliente General.\nPor favor ingrese un cliente valido.");
                            //var frmCliente = new Cliente.FrmClienteBasico();
                            //frmCliente.MdiParent = this.MdiParent;
                            //frmCliente.Show();
                        }
                    }*/
                    LimpiarCamposNewDevolucion();
                }
                catch (Exception ex)
                {
                    OptionPane.MessageError(ex.Message);
                }
            }
        }

        private void tsBtnResetear_Click(object sender, EventArgs e)
        {
            DialogResult rta = MessageBox.Show("¿Está seguro(a) de reiniciar la devolución?", "Devolución de Remisión",
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (rta.Equals(DialogResult.Yes))
            {
                ResetRemision();
            }
        }

        private void tsBtnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtNumeroFactura_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar.Equals((char)Keys.Enter))
            {
                //txtNumeroFactura_Validating(this.txtNumeroFactura, new CancelEventArgs(false));
            }
        }

        private void txtNumeroFactura_Validating(object sender, CancelEventArgs e)
        {
            /*if (!Validacion.EsVacio(txtNumeroFactura, miError, "El campo Número de Remisión es requerido."))
            {
                if (Validacion.ConFormato
                    (Validacion.TipoValidacion.LetrasGuionNumeros, txtNumeroFactura, miError, FacturaFormat))
                {
                    /*if (CargarFactura(Convert.ToInt32(txtNumeroFactura.Text)))
                    {
                        miError.SetError(txtNumeroFactura, null);
                        dtpFecha.Focus();
                    }
                    else
                    {
                        //miError.SetError(txtNumeroFactura, FacturaLoad);
                        txtNumeroFactura.Focus();
                    }
                }
                else
                {
                    txtNumeroFactura.Focus();
                }
            }
            else
            {
                txtNumeroFactura.Focus();
            }*/
        }

        private void btnFactura_Click(object sender, EventArgs e)
        {
            if (!FormExtend)
            {
                //var frmConsulta = new Factura.FrmConsulta();
                //frmConsulta.Extend = true;
                //frmConsulta.MdiParent = this.MdiParent;
                //FormExtend = true;
                //frmConsulta.Show();
            }
        }

        private void dtpFecha_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar.Equals((char)Keys.Enter))
            {
                txtCantidad.Focus();
            }
        }

        //


        private void txtCantidad_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar.Equals((char)Keys.Enter))
            {
                txtCodigoArticulo.Focus();
            }
        }

        private void txtCantidad_Validating(object sender, CancelEventArgs e)
        {
            if (String.IsNullOrEmpty(txtCantidad.Text))
            {
                txtCantidad.Text = "1";
                txtCodigoArticulo.Focus();
            }
            else
            {
                if (Validacion.ConFormato
                    (Validacion.TipoValidacion.NumerosYPunto, txtCantidad, miError, "La cantidad que ingreso tiene formato incorrecto."))
                {
                    txtCodigoArticulo.Focus();
                }
                else
                {
                    txtCantidad.Focus();
                }
            }
        }

        private void txtCodigoArticulo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar.Equals((char)Keys.Enter))
            {
                if (CodigoOrString())
                {
                    if (ExisteProducto(txtCodigoArticulo.Text))
                    {
                        if (CargarProducto(txtCodigoArticulo.Text))
                        {
                            if (MiProducto.AplicaTalla || MiProducto.AplicaColor)
                            {
                                if (!SingleSize || !SingleColor)
                                {
                                    btnTallaYcolor_Click(this.btnTallaYcolor, new EventArgs());
                                }
                                else
                                {
                                    //Validacion...
                                    if (cbDescuentoProducto.Enabled)
                                    {
                                        cbDescuentoProducto.Focus();
                                    }
                                    else
                                    {
                                        EstructurarConsulta();  //aqui VOY
                                        return;
                                    }
                                }
                            }
                            else
                            {
                                //validar producto de factura.
                                if (cbDescuentoProducto.Enabled)
                                {
                                    cbDescuentoProducto.Focus();
                                }
                            }

                            if (!cbDescuentoProducto.Enabled && !btnTallaYcolor.Enabled)
                            {
                                EstructurarConsulta();
                            }
                        }
                    }
                    else
                    {
                        OptionPane.MessageInformation("El Producto no esta registrado en la base de datos.");
                        miError.SetError(txtCodigoArticulo, "El Producto no esta registrado en la base de datos.");
                        /* if (String.IsNullOrEmpty(txtCodigoArticulo.Text))
                         {
                             OptionPane.MessageInformation("El campo del código del artículo no debe ir vacío.");
                             miError.SetError(txtCodigoArticulo, "El campo del código del artículo no debe ir vacío.");
                         }
                         else
                         {
                             OptionPane.MessageInformation("El Producto no esta registrado en la base de datos.");
                             miError.SetError(txtCodigoArticulo, "El Producto no esta registrado en la base de datos.");
                         }*/
                    }
                }
                else
                {
                    var formInventario = new Inventario.Consulta.FrmConsultaInventario();
                    formInventario.ExtendVenta = true;
                    formInventario.txtCodigoNombre.Text = txtCodigoArticulo.Text;
                    formInventario.ShowDialog();
                    formInventario.dgvInventario.Focus();
                    formInventario.ColorearGrid();
                }
            }
        }

        private void btnTallaYcolor_Click(object sender, EventArgs e)
        {
            if (MiProducto != null)
            {
                if (MiProducto.AplicaTalla || MiProducto.AplicaColor)
                {
                    var frmTallayColor = new frmMedidaColor();
                    frmTallayColor.MdiParent = this.MdiParent;
                    frmTallayColor.AplicaTalla = MiProducto.AplicaTalla;
                    frmTallayColor.AplicaColor = MiProducto.AplicaColor;
                    frmTallayColor.CodigoProducto = MiProducto.CodigoInternoProducto;
                    if (MiProducto.AplicaColor && !MiProducto.AplicaTalla)
                    {
                        frmTallayColor.IdMedida_ = MiMedida.IdValorUnidadMedida;
                    }
                    if (EnableColor && MiProducto.AplicaColor)
                    {
                        frmTallayColor.Show();
                    }
                    else
                    {
                        if (MiProducto.AplicaTalla)
                        {
                            frmTallayColor.AplicaColor = false;
                            frmTallayColor.Show();
                        }
                    }
                }
            }
            else
            {
                OptionPane.MessageInformation("Debe selecciona un Articulo primero.");
            }
        }

        private void cbDescuentoProducto_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar.Equals((char)Keys.Enter))
            {
                EstructurarConsulta();
            }
        }

        private void dgvListaArticulos_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (e.ColumnIndex == 8)
            {
                if (!String.IsNullOrEmpty(e.FormattedValue.ToString()))
                {
                    if (MiValidacion.ValidarNumeroDecima(e.FormattedValue.ToString()))
                    {
                        DialogResult rta = MessageBox.Show("¿El valor que ingreso incluye el IVA?", "Devolución",
                            MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        var iva_ = false;
                        if (rta.Equals(DialogResult.Yes))
                        {
                            iva_ = true;
                        }
                        else
                        {
                            iva_ = false;
                        }
                        ActualizarInformacion(e.RowIndex, e.FormattedValue.ToString(), iva_);
                        return;
                    }
                    else
                    {
                        OptionPane.MessageError("El número que ingreso es incorrecto.");
                        e.Cancel = true;
                    }
                }
                else
                {
                    OptionPane.MessageError("Debe ingresar un valor.");
                    e.Cancel = true;
                }
            }
        }

        /// <summary>
        /// Carga los datos o elementos necesarios para el inicio del formulario.
        /// </summary>
        private void CargarUtilidades()
        {
            miToolTip.SetToolTip(btnFactura, "Buscar Factura [F3]");
            try
            {
                cbDescuentoProducto.DataSource = miBussinesDescto.ListadoDescuento();
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
            miTabla.Columns.Add(new DataColumn("IdColor", typeof(int)));
            miTabla.Columns.Add(new DataColumn("Color", typeof(Image)));
        }

        /// <summary>
        /// Completa la transferencia de datos por parte de otros formularios.
        /// </summary>
        /// <param name="args"></param>
        void CompletaEventosm_Completo(CompletaArgumentosDeEventom args)
        {
            try
            {
                txtNumeroFactura.Text = (string)args.MiMarca;
                txtNumeroFactura_KeyPress
                    (this.txtNumeroFactura, new KeyPressEventArgs((char)Keys.Enter));
            }
            catch { }

            try
            {
                txtCodigoArticulo.Text = ((Producto)args.MiMarca).CodigoInternoProducto;
                txtCodigoArticulo_KeyPress(this.txtCodigoArticulo, new KeyPressEventArgs((char)Keys.Enter));
            }
            catch { }

            try
            {
                FormExtend = Convert.ToBoolean(args.MiMarca);
            }
            catch { }
        }

        /// <summary>
        /// Completa la transferencia de datos por parte de otros formularios.
        /// </summary>
        /// <param name="args"></param>
        void CompletaEventos_Completo(CompletaArgumentosDeEvento args)
        {
            try
            {
                miTallaYcolor = (TallaYcolor)args.MiObjeto;
                if (cbDescuentoProducto.Enabled)
                {
                    cbDescuentoProducto.Focus();
                }
                else
                {
                    EstructurarConsulta();
                }
                //EstructurarConsulta();
            }
            catch { }
        }

        /// <summary>
        /// Completa la transferencia de datos por parte de otros formularios.
        /// </summary>
        /// <param name="args"></param>
        void CompletaEventosbo_Completo(CompletaArgumentosDeEventobo args)
        {
            try
            {
                var nitC = args.MiBodegabo.ToString();
                //GuardarBono(nitC);
                Factura.Proveedor.NitProveedor = nitC;
                EditarClienteFactura(Factura);
                OptionPane.MessageInformation("El saldo se guardó con éxito, y está a favor del cliente seleccionado.");
                LimpiarCamposNewDevolucion();
            }
            catch { }
        }

        void CompletaEventos_CompTProductoFact(CompletaTransferProductFact args)
        {
            try
            {
                var producto = (Producto)args.MiObjeto;
                txtCodigoArticulo.Text = producto.CodigoInternoProducto;
                txtCodigoArticulo_KeyPress(this.txtCodigoArticulo, new KeyPressEventArgs((char)Keys.Enter));
            }
            catch { }
        }

        /// <summary>
        /// Cargar los datos de la Factura en memoria.
        /// </summary>
        /// <param name="numero"></param>
        private bool CargarFactura(int numero)
        {
            try
            {
                //tabla = miBussinesFactura.ConsultaNumero(numero);
                var tabla = miBussinesRemision.ConsultaNumero(numero);
                if (tabla.Rows.Count != 0)
                {
                    var qRow = (from data in tabla.AsEnumerable()
                                select data).Single();
                    if (!qRow["estado"].ToString().Equals("Facturada"))
                    {
                        Factura = new FacturaVenta();
                        Factura.Numero = numero.ToString();
                        Factura.AplicaDescuento = Convert.ToBoolean(qRow["aplica_descuento"]);
                        Factura.Proveedor.NitProveedor = qRow["nitcliente"].ToString();
                        if (Convert.ToBoolean(qRow["aplica_descuento"]))
                        {
                            cbDescuentoProducto.Enabled = true;
                        }
                        else
                        {
                            cbDescuentoProducto.Enabled = false;
                        }
                        Detalle = miBussinesRemision.Detalles(numero, Factura.AplicaDescuento);
                        Devoluciones = miBussinesDevolucion.DevolucionesRemision(numero);
                        tabla.Clear();
                        tabla = null;
                        txtNumeroFactura.Enabled = false;
                        btnFactura.Enabled = false;
                        return true;
                    }
                    else
                    {
                        OptionPane.MessageError("A esta Remisión no se le pueden hacer devoluciones, porque esta Facturada.");
                        miError.SetError(txtNumeroFactura,
                            "A esta Remisión no se le pueden hacer devoluciones, porque esta Facturada.");
                        return false;
                    }
                }
                else
                {
                    miError.SetError(txtNumeroFactura, "El número de remisión que ingresó no se encuentra registrado.");
                    return false;
                }
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
                return false;
            }
        }

        //puede haber codigo mas antes

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
        /// Comprueba si en la factura se encuentra un producto determinado.
        /// </summary>
        /// <param name="factura">Factura de la cual se hace la consulta.</param>
        /// <param name="dProducto">Producto a buscar en la Factura.</param>
        /// <returns></returns>
        public bool ProductoDeFactura(FacturaVenta factura, DetalleProducto dProducto)
        {
            try
            {
                return miBussinesRemision.ProductoDeRemision(factura, dProducto);
                //return miBussinesFactura.ProductoDeFactura(factura, dProducto);
            }
            catch (Exception ex)
            {
                OptionPane.MessageError
                    ("Ocurrió un error al comprobar el producto en la Factura.\n" + ex.Message);
                return false;
            }
        }

        public bool CantidadDeProducto(DetalleProducto dProducto)
        {
            var resultado = false;
            var dtRow = from data in Detalle
                        where data.Codigo == dProducto.Codigo
                           && data.Medida == dProducto.Medida
                           && data.Color == dProducto.Color
                        select data;
            var dtCant = dtRow.Sum(s => s.Cantidad);
            if (dtCant >= dProducto.Cantidad)
            {
                resultado = true;
            }
            else
            {
                resultado = false;
            }
            return resultado;
        }

        public bool ProductoDevuelto(DetalleProducto dProducto)
        {
            var resultado = true;
            var dvRow = from data in Devoluciones
                        where data.Codigo == dProducto.Codigo
                        && data.Medida == dProducto.Medida
                        && data.Color == dProducto.Color
                        select data;
            if (dvRow.ToArray().Length != 0)
            {
                var dvCant = dvRow.Sum(s => s.Cantidad);
                var dtRow = from data in Detalle
                            where data.Codigo == dProducto.Codigo
                            && data.Medida == dProducto.Medida
                            && data.Color == dProducto.Color
                            select data;
                var dtCant = dtRow.Sum(s => s.Cantidad);
                if ((dtCant - dvCant) >= dProducto.Cantidad)
                {
                    resultado = false;
                }
                else
                {
                    resultado = true;
                }
                /*if (dvCant < dtCant)
                {
                    resultado = false;
                }
                else
                {
                    resultado = true;
                }*/
            }
            else
            {
                resultado = false;
            }
            return resultado;
        }

        /// <summary>
        /// Valida que el ingreso de un producto no supere en cantidad al mismo en la factura.
        /// </summary>
        /// <param name="dProducto">Detalle del producto a consultar.</param>
        /// <returns></returns>
        public bool ProductoRepeat(DetalleProducto dProducto)
        {
            var resultado = true;
            var gRow = (from data in miTabla.AsEnumerable()
                        where data.Field<string>("Codigo") == dProducto.Codigo
                        && data.Field<int>("IdMedida") == dProducto.Medida
                        && data.Field<int>("IdColor") == dProducto.Color
                        select data);
            if (gRow.ToArray().Length != 0)//Consulta con datos.
            {
                var gCant = gRow.Sum(s => s.Field<double>("Cantidad"));
                var dRow = from data in Detalle
                           where data.Codigo == dProducto.Codigo
                              && data.Medida == dProducto.Medida
                              && data.Color == dProducto.Color
                           select data;
                var dCant = dRow.Sum(s => s.Cantidad);
                if (gCant < dCant)
                {
                    resultado = false;
                }
                else
                {
                    resultado = true;
                }
            }
            else
            {
                resultado = false;
            }
            return resultado;
        }

        /// <summary>
        /// Carga los datos del producto en la tabla de memoria.
        /// </summary>
        /// <param name="producto">Producto a cargar.</param>
        /// <returns></returns>
        public bool CargarProducto(string producto)
        {
            var resultado = false;
            var idMedidaTemp = 0;
            try
            {
                ArrayProducto = miBussinesProducto.ProductoBasico(producto);
                MiProducto = (Producto)ArrayProducto[0];
                var tabla = miBussinesMedida.MedidasDeProducto(MiProducto.CodigoInternoProducto);
                if (!MiProducto.AplicaTalla)  //No aplica talla.
                {
                    MiMedida = (ValorUnidadMedida)ArrayProducto[1];
                    idMedidaTemp = MiMedida.IdValorUnidadMedida;
                    SingleSize = true;
                }
                else   //Si aplica talla.
                {
                    if (tabla.Rows.Count == 1)
                    {
                        var qRow = (from data in tabla.AsEnumerable()
                                    select data).Single();
                        miTallaYcolor.IdTalla = Convert.ToInt32(qRow["idvalor_unidad_medida"]);
                        idMedidaTemp = miTallaYcolor.IdTalla;
                        qRow = null;
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
                        var tablaColor = miBussinesColor.ColoresDeProducto
                            (MiProducto.CodigoInternoProducto, idMedidaTemp);
                        if (tablaColor.Rows.Count == 1)
                        {
                            var cRow = (from data in tablaColor.AsEnumerable()
                                        select data).Single();
                            miTallaYcolor.IdColor = Convert.ToInt32(cRow["idcolor"]);
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
                        Convert.ToInt32(txtCantidad.Text);
                        miError.SetError(txtCantidad, null);
                        resultado = true;
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
                resultado = false;
                OptionPane.MessageError(ex.Message);
            }
            return resultado;
        }

        /// <summary>
        /// Estructura la información en la tabla de memoria para ser visualizada.
        /// </summary>
        private void EstructurarConsulta()
        {
            var detalle = new DetalleProducto();
            if (MiProducto != null)
            {
                detalle.Codigo = MiProducto.CodigoInternoProducto;
                if (MiProducto.AplicaTalla)
                {
                    detalle.Medida = miTallaYcolor.IdTalla;
                }
                else
                {
                    detalle.Medida = MiMedida.IdValorUnidadMedida;
                }
                if (MiProducto.AplicaColor)
                {
                    detalle.Color = miTallaYcolor.IdColor;
                }
                /**
                if (ProductoDeFactura(Factura, detalle))
                {
                    detalle.Cantidad = Convert.ToDouble(txtCantidad.Text);
                    if (CantidadDeProducto(detalle))
                    {
                        if (!ProductoDevuelto(detalle))
                        {
                            if (!ProductoRepeat(detalle))
                            {
                            */
                                Devoluciones.Add(detalle);
                                miError.SetError(txtCodigoArticulo, null);
                                var inventario = new DTO.Clases.Inventario();
                                inventario.CodigoProducto = MiProducto.CodigoInternoProducto;
                                Contador++;
                                var row = miTabla.NewRow();
                                if (MiProducto.AplicaTalla)
                                {
                                    inventario.IdMedida = miTallaYcolor.IdTalla;
                                    row["Unidad"] = "Talla";
                                    row["IdMedida"] = miTallaYcolor.IdTalla;
                                    row["Medida"] = miTallaYcolor.Talla;
                                }
                                else
                                {
                                    inventario.IdMedida = MiMedida.IdValorUnidadMedida;
                                    row["Unidad"] = MiMedida.DescripcionUnidadMedida;
                                    row["IdMedida"] = MiMedida.IdValorUnidadMedida;
                                    row["Medida"] = MiMedida.DescripcionValorUnidadMedida;
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
                                if (MiProducto.AplicaPrecioPorcentaje)
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
                                }

                                row["Id"] = Contador;
                                row["Codigo"] = MiProducto.CodigoInternoProducto;
                                row["Articulo"] = MiProducto.NombreProducto;
                                row["Cantidad"] = Convert.ToDouble(txtCantidad.Text);
                                row["ValorUnitario"] = Convert.ToInt32(MiProducto.ValorVentaProducto / (1 + (MiProducto.ValorIva / 100)));

                                if (cbDescuentoProducto.Enabled)
                                {
                                    row["Descuento"] =
                                            ((DTO.Clases.Descuento)cbDescuentoProducto.SelectedItem).ValorDescuento.ToString() + "%";
                                }
                                else
                                {
                                    row["Descuento"] = "0%";
                                }
                                row["ValorMenosDescto"] = Convert.ToDouble(Convert.ToInt32(row["ValorUnitario"]) -
                                        (Convert.ToInt32(row["ValorUnitario"]) * UseObject.RemoveCharacter(row["Descuento"].ToString(), '%') / 100));

                                if (miEmpresa.Regimen.IdRegimen == 1)  //Comun
                                {
                                    row["Iva"] = MiProducto.ValorIva.ToString() + "%";
                                }
                                else
                                {
                                    row["Iva"] = 0 + "%";
                                }
                                row["TotalMasIva"] = (Convert.ToDouble(row["ValorMenosDescto"]) *
                                                      UseObject.RemoveCharacter(row["Iva"].ToString(), '%') / 100) +
                                                      Convert.ToDouble(row["ValorMenosDescto"]);
                                row["Valor"] = Convert.ToDouble(row["TotalMasIva"]) *
                                               Convert.ToDouble(row["Cantidad"]);

                                miTabla.Rows.Add(row);
                                txtTotal.Text = UseObject.InsertSeparatorMil
                                    (
                                       Convert.ToInt32(
                                       miTabla.AsEnumerable().Sum(s => s.Field<double>("Valor"))
                                       ).ToString()
                                    );
                                RecargarGridview();
                                LimpiarCampos();
                                btnTallaYcolor.Enabled = false;
                            /**
                            }
                            else
                            {
                                OptionPane.MessageInformation("Ha llegado al límite de la cantidad de este producto en la Remisión.");
                                miError.SetError(txtCodigoArticulo, "Ha llegado al límite de la cantidad de este producto en la Remisión.");
                                txtCodigoArticulo.Focus();
                            }
                        }
                        else
                        {
                            OptionPane.MessageInformation("Ha llegado al límite de la cantidad de este producto en la Remisión.");
                            miError.SetError(txtCodigoArticulo, "Ha llegado al límite de la cantidad de este producto en la Remisión.");
                            txtCodigoArticulo.Focus();
                        }
                    }
                    else
                    {
                        OptionPane.MessageInformation("Ha llegado al límite de la cantidad de este producto en la Remisión.");
                        miError.SetError(txtCodigoArticulo, "Ha llegado al límite de la cantidad de este producto en la Remisión.");
                        txtCodigoArticulo.Focus();
                    }
                    
                }
                else
                {
                    OptionPane.MessageInformation("El producto que ingreso no pertenece a esta Remisión.");
                    miError.SetError(txtCodigoArticulo, "El producto que ingreso no pertenece a esta Remisión.");
                    txtCodigoArticulo.Focus();
                }
                */
            }
            else
            {
                OptionPane.MessageError("Debe cargar primero un artículo.");
                miError.SetError(txtCodigoArticulo, "Debe cargar primero un artículo.");
                txtCodigoArticulo.Focus();
            }
        }

        /// <summary>
        /// Actualiza la información de la devolución cuando se realiza un cambio.
        /// </summary>
        /// <param name="rowIndex">Índex del registro de la lista a modificar.</param>
        /// <param name="valor">Valor a modificar en el registro seleccionado.</param>
        /// <param name="iva_">Condición que indica que el valor contiene o no el IVA.</param>
        private void ActualizarInformacion(int rowIndex, string valor, bool iva_)
        {
            valor = valor.Replace('.', ',');
            var id = Convert.ToInt32(dgvListaArticulos.Rows[rowIndex].Cells["Id"].Value);
            var query = (from datos in miTabla.AsEnumerable()
                         where datos.Field<int>("Id") == id
                         select datos).Single();
            var index = miTabla.Rows.IndexOf(query);
            if (iva_)
            {
                miTabla.Rows[index]["ValorUnitario"] = Convert.ToInt32(Convert.ToDouble(valor) /
                    ((UseObject.RemoveCharacter(miTabla.Rows[index]["Iva"].ToString(), '%') / 100) + 1));
            }
            else
            {
                miTabla.Rows[index]["ValorUnitario"] = Convert.ToInt32(Convert.ToDouble(valor));
            }

            miTabla.Rows[index]["ValorMenosDescto"] =
                Convert.ToDouble(Convert.ToInt32(miTabla.Rows[index]["ValorUnitario"]) -
                (Convert.ToInt32(miTabla.Rows[index]["ValorUnitario"]) *
                UseObject.RemoveCharacter(miTabla.Rows[index]["Descuento"].ToString(), '%') / 100));

            miTabla.Rows[index]["TotalMasIva"] =
                (Convert.ToDouble(miTabla.Rows[index]["ValorMenosDescto"]) *
                UseObject.RemoveCharacter(miTabla.Rows[index]["Iva"].ToString(), '%') / 100) +
                Convert.ToDouble(miTabla.Rows[index]["ValorMenosDescto"]);

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
            txtCodigoArticulo.Focus();
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
        /// Limpia los campos de Producto del Formulario.
        /// </summary>
        private void LimpiarCampos()
        {
            this.txtCodigoArticulo.Focus();
            this.txtCodigoArticulo.Text = "";
            txtCantidad.Text = "1";
            MiProducto = null;
            miTallaYcolor.IdTalla = 0;
            miTallaYcolor.IdColor = 0;
            miTallaYcolor.Talla = "";
            miTallaYcolor.Color = null;
            btnTallaYcolor.Enabled = false;
        }

        /// <summary>
        /// Limpia todos los campos del Formulario para disponer una nueva Devolución.
        /// </summary>
        private void LimpiarCamposNewDevolucion()
        {
            //txtNumeroFactura.Focus();
            LimpiarCampos();
            txtNumeroFactura.Enabled = true;
            btnFactura.Enabled = true;
            txtNumeroFactura.Focus();
            txtNumeroFactura.Text = "";
            dtpFecha.Value = DateTime.Today;
            lblDatosProducto.Text = "";
            txtTotal.Text = "0";
            Factura = null;
            miTabla.Rows.Clear();
            while (dgvListaArticulos.RowCount != 0)
            {
                dgvListaArticulos.Rows.RemoveAt(0);
            }
            cbDescuentoProducto.Enabled = false;
            Detalle.Clear();
            Devoluciones.Clear();
        }

        private void ResetRemision()
        {
            txtNumeroFactura.Enabled = true;
            txtNumeroFactura.Focus();
            txtNumeroFactura.Text = "";
            btnFactura.Enabled = true;
            dtpFecha.Value = DateTime.Today;
            txtCantidad.Text = "1";
            txtCodigoArticulo.Text = "";
            cbDescuentoProducto.SelectedIndex = 0;
            cbDescuentoProducto.Enabled = false;
            btnTallaYcolor.Enabled = false;
            lblDatosProducto.Text = "";
            miTabla.Rows.Clear();
            while (dgvListaArticulos.RowCount != 0)
            {
                dgvListaArticulos.Rows.RemoveAt(0);
            }
            txtTotal.Text = "0";
        }
        /*
                /// <summary>
                /// Cargar y guarda la información del bono generado al Cliente.
                /// </summary>
                /// <param name="cliente">Nit o C.C. del cliente a guardar en el bono.</param>
                private Bono GuardarBono(string cliente)
                {
                    var bono = new Bono();
                    bono.Cliente = cliente;
                    bono.Factura = Factura.Numero;
                    bono.Fecha = DateTime.Today;
                    bono.Valor = Convert.ToInt32
                                 (
                                   miTabla.AsEnumerable().Sum(s => s.Field<double>("Valor"))
                                 );
                    try
                    {
                        bono.Id = miBussinesBono.Ingresar(bono);
                    }
                    catch (Exception ex)
                    {
                        OptionPane.MessageError(ex.Message);
                    }
                    return bono;
                }

                /// <summary>
                /// Guarda la información correspondiente a un seguimiento  del bono.
                /// </summary>
                /// <param name="bono">Datos del Seguimiento del bono a ingresar.</param>
                private void GuardaSeguimientoBono(Bono bono)
                {
                    try
                    {
                        miBussinesBono.IngresarSeguimiento(bono);
                    }
                    catch (Exception ex)
                    {
                        OptionPane.MessageError(ex.Message);
                    }
                }*/

        /// <summary>
        /// Edita el cliente relacionado en la factura de venta.
        /// </summary>
        /// <param name="factura">Datos de la factura de venta a editar.</param>
        private void EditarClienteFactura(FacturaVenta factura)
        {
            try
            {
                //miBussinesFactura.EditarCliente(factura);
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
        }
    }
}