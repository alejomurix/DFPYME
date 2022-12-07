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
using Microsoft.Reporting.WinForms;

namespace Aplicacion.Compras.Devolucion
{
    public partial class FrmDevolucionCompra : Form
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

        private BussinesProveedor miBussinesProveedor;

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

        private BussinesFacturaProveedor miBussinessFactura;

        private BussinesRetencion miBussinesRetencion;

        private BussinesFormaPago miBussinesPago;

        

        private BussinesConsecutivo miBussinesConsecutivo;

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
        /// Obtiene o establece la colección de datos de los productos incluidos en la factura.
        /// </summary>
        private List<DetalleProducto> Detalle { set; get; }

        /// <summary>
        /// Obtiene o establece la colección de datos de los productos incluidos en la devolución a la factura actual.
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

        public FrmDevolucionCompra()
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
            miBussinesProveedor = new BussinesProveedor();
            miBussinesDescto = new BussinesDescuento();
            miBussinesFactura = new BussinesFacturaVenta();
            miBussinessFactura = new BussinesFacturaProveedor();
            miBussinesRetencion = new BussinesRetencion();
            miBussinesConsecutivo = new BussinesConsecutivo();
            miBussinesMedida = new BussinesValorUnidadMedida();
            miBussinesProducto = new BussinesProducto();
            miTallaYcolor = new TallaYcolor();
            miBussinesColor = new BussinesColor();
            miBussinesDevolucion = new BussinesDevolucion();
            miBussinesPago = new BussinesFormaPago();
            miBussinesBono = new BussinesBono();
            CargarEmpresa();
        }

        private void FrmDevolucion_Load(object sender, EventArgs e)
        {
            this.tsBtnCambiarPrecio.Image = ((Image)(miResources.GetObject("tsCambiarPrecio.Image")));
            CompletaEventos.Completam +=
                new CompletaEventos.CompletaAccionm(CompletaEventosm_Completo);
            CompletaEventos.Completa += new CompletaEventos.CompletaAccion(CompletaEventos_Completo);
            CompletaEventos.Completabo += new CompletaEventos.CompletaAccionbo(CompletaEventosbo_Completo);
            CompletaEventos.CompTProductoFact += new CompletaEventos.ComAxTransferProductFact(CompletaEventos_CompTProductoFact);
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
                            this.tsConsultarProducto_Click(this.tsConsultarProducto, new EventArgs());
                            break;
                        }
                case Keys.F4:
                    {
                        this.tsBtnCambiarPrecio_Click(this.tsBtnCambiarPrecio, new EventArgs());
                        break;
                    }
                case Keys.F5:
                    {
                        this.tsBtnRetiro_Click(this.tsBtnRetiro, new EventArgs());
                        break;
                    }
                case Keys.F6:
                    {
                        this.tsBtnReset_Click(this.tsBtnReset, new EventArgs());
                        break;
                    }
                case Keys.Escape:
                    {
                        this.Close();
                        break;
                    }
            }
        }

        private void FrmDevolucion_FormClosing(object sender, FormClosingEventArgs e)
        {

        }

        private void tsBtnBuscarProducto_Click(object sender, EventArgs e)
        {
            /*if (!FormExtend)
            {
                var frmProducto = new Inventario.Producto.FrmIngresarProducto();
                frmProducto.Extencion = true;
                frmProducto.Devolucion = true;
                frmProducto.tabControlProducto.SelectedIndex = 1;
                frmProducto.MdiParent = this.MdiParent;
                FormExtend = true;
                frmProducto.Show();
            }*/
        }

        private void tsConsultarProducto_Click(object sender, EventArgs e)
        {
            var formInventario = new Inventario.Consulta.FrmConsultaInventario();
            formInventario.MdiParent = this.MdiParent;
            formInventario.ExtendVenta = true;
            //formInventario.txtCodigoNombre.Text = txtCodigoArticulo.Text;
            FormExtend = true;
            formInventario.Show();
            formInventario.dgvInventario.Focus();
            formInventario.ColorearGrid();
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
            miError.SetError(txtCantidad, null);
            miError.SetError(txtCodigoArticulo, null);
            if (dgvListaArticulos.RowCount != 0)
            {
                DialogResult rta = MessageBox.Show("¿Está seguro(a) de realizar la devolución?", "Devolución",
                            MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (rta.Equals(DialogResult.Yes))
                {
                    var devolucion = new FacturaProveedor();
                    devolucion.Id = this.Factura.Id;
                    devolucion.Numero = miBussinesConsecutivo.Consecutivo("NotaCredito");
                    devolucion.Proveedor.CodigoInternoProveedor = Factura.Proveedor.CodigoInternoProveedor;
                    devolucion.Proveedor.NitProveedor = Factura.Proveedor.NitProveedor;
                    devolucion.Proveedor.RazonSocialProveedor = Factura.Proveedor.RazonSocialProveedor;
                    if (txtConcepto.Text.Equals(""))
                    {
                        if (txtNumeroFactura.Text.Equals(""))
                        {
                            devolucion.Proveedor.DescripcionProveedor =
                            "Devolución a Proveedor : " + Factura.Proveedor.RazonSocialProveedor;
                        }
                        else
                        {
                            devolucion.Proveedor.DescripcionProveedor =
                            "Devolución a Factura Proveedor No. " + txtNumeroFactura.Text;
                        }
                    }
                    else
                    {
                        devolucion.Proveedor.DescripcionProveedor = txtConcepto.Text;
                    }
                    //devolucion.NumeroEdit = "Devolución de Factura Proveedor No. " + txtNumeroFactura.Text;
                    devolucion.FechaIngreso = dtpFecha.Value;
                    devolucion.Usuario.Id = IdUsuario;
                    devolucion.Caja.Id = IdCaja;
                    devolucion.Estado = false;
                    foreach (DataRow row in miTabla.Rows)
                    {
                        var detalle = new ProductoFacturaProveedor();
                        detalle.Inventario.CodigoProducto = row["Codigo"].ToString();
                        detalle.Inventario.IdMedida = Convert.ToInt32(row["IdMedida"]);
                        detalle.Inventario.IdColor = Convert.ToInt32(row["IdColor"]);
                        detalle.Producto.NombreProducto = row["Articulo"].ToString();
                        detalle.Producto.ValorCosto = Convert.ToDouble(row["ValorUnitario"]);
                        detalle.Producto.Descuento = UseObject.RemoveCharacter(row["Descuento"].ToString(), '%');
                        detalle.Producto.ValorIva = UseObject.RemoveCharacter(row["Iva"].ToString(), '%');
                        detalle.Inventario.Cantidad = Convert.ToDouble(row["Cantidad"]);
                        detalle.Producto.ValorVentaProducto = Convert.ToInt32(row["TotalMasIva"]);
                        //detalle.Producto.ValorVentaProducto = Convert.ToInt32(row["Valor"]);

                        devolucion.Productos.Add(detalle);
                    }
                    try
                    {
                        devolucion.Id = miBussinesDevolucion.IngresarCompra(devolucion);
                        int valorSaldo = Convert.ToInt32(this.miTabla.AsEnumerable().Sum(s => s.Field<double>("Valor")));
                        /*txtTotal.Text = UseObject.InsertSeparatorMil
                            (
                               Convert.ToInt32(
                               miTabla.AsEnumerable().Sum(s => s.Field<double>("Valor"))
                               ).ToString()
                            );*/
                        if (this.miBussinesDevolucion.ExisteSaldoCompra(Factura.Proveedor.CodigoInternoProveedor))
                        {
                            this.miBussinesDevolucion.EditarSaldoCompra(Factura.Proveedor.CodigoInternoProveedor,
                                (valorSaldo + this.miBussinesDevolucion.SaldoCompra(Factura.Proveedor.CodigoInternoProveedor)));
                        }
                        else
                        {
                            this.miBussinesDevolucion.IngresarSaldoCompra(new Bono
                            {
                                IdUsuario = IdUsuario,
                                IdCaja = IdCaja,
                                Id = Factura.Id,
                                Fecha = dtpFecha.Value,
                                Valor = valorSaldo,
                                IdDevolucion = devolucion.Id,
                                CodProveedor = Factura.Proveedor.CodigoInternoProveedor
                            });
                        }

                      //  if (txtNumeroFactura.Text != "") // Incluye factura
                       // {


                            /*var valor = ValorFactura(Factura.Id);
                            var pago = miBussinesPago.PagosAProveedor(Factura.Id) +
                                miBussinesDevolucion.SaldoDevolucionCompra(Factura.Id);
                            
                            
                            /*
                            if (valor > pago)  // Se debe factura
                            {
                                if (Convert.ToInt32(miTabla.AsEnumerable().
                                      Sum(s => s.Field<double>("Valor"))) > (valor - pago)) //devolucion mayor que debe a factura
                                {
                                    valorSaldo = valor - pago;
                                }
                                else  // devolucion menor o igual que debe a factura
                                {
                                    valorSaldo = Convert.ToInt32(miTabla.AsEnumerable().
                                      Sum(s => s.Field<double>("Valor")));
                                    //devolucion saldada
                                    miBussinesDevolucion.SaldarDevolucionCompra(devolucion.Id);
                                }
                                miBussinesDevolucion.IngresarSaldoCompra(new Bono
                                {
                                    IdUsuario = IdUsuario,
                                    IdCaja = IdCaja,
                                    Id = Factura.Id,
                                    Fecha = dtpFecha.Value,
                                    Valor = valorSaldo,
                                    IdDevolucion = devolucion.Id
                                });
                            }*/
                           // else  // factura saldada
                          //  {

                         //   }
                            
                       // }
                            /*miBussinesDevolucion.IngresarSaldoCompra(new Bono
                                                                     {
                                                                         IdUsuario = IdUsuario,
                                                                         IdCaja = IdCaja,
                                                                         Id = Factura.Id,
                                                                         Fecha = dtpFecha.Value,
                                                                         Valor = Convert.ToInt32(
                                                                         miTabla.AsEnumerable().
                                                                         Sum(s => s.Field<double>("Valor")))
                                                                     });*/
                        OptionPane.MessageInformation("La devolucón se ingreso con exito.");
                        /*rta = MessageBox.Show("¿Desea imprimir la Nota Crédito?", "Devolución Proveedor",
                            MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (rta.Equals(DialogResult.Yes))
                        {*/
                            if (Convert.ToBoolean(AppConfiguracion.ValorSeccion("printNotaCredito")))
                            {
                                rta = MessageBox.Show("¿Desea imprimir la Nota Crédito?", "Devolución Proveedor",
                                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                                if (rta.Equals(DialogResult.Yes))
                                {
                                    PrintDevolucionPos(devolucion);
                                }
                            }
                            else
                            {
                                PrintComprobanteDevolucion(devolucion);
                            }
                        //}
                        //PrintComprobanteDevolucion(devolucion);
                        LimpiarCamposNewDevolucion();
                    }
                    catch (Exception ex)
                    {
                        OptionPane.MessageError(ex.Message);
                    }
                }
            }
            else
            {
                OptionPane.MessageInformation("La devolución no presenta artículos.");
            }
        }

        private void tsBtnReset_Click(object sender, EventArgs e)
        {
            DialogResult rta = MessageBox.Show("¿Está seguro(a) de reiniciar la devolución?", "Devolucón Proveedor",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rta.Equals(DialogResult.Yes))
            {
                LimpiarCamposNewDevolucion();
                /*while (dgvListaArticulos.RowCount != 0)
                {
                    dgvListaArticulos.Rows.RemoveAt(0);
                }
                miTabla.Rows.Clear();
                txtCodigoProveedor.Enabled = true;
                btnBuscarProveedor.Enabled = true;
                txtNombreProveedor.Text = "";
                txtNumeroFactura.Enabled = true;
                txtNumeroFactura.Text = "";
                txtConcepto.Enabled = true;
                txtConcepto.Text = "";
                Factura = null;
                txtTotal.Text = "0";
                lblDatosProducto.Text = "";*/
            }
        }

        private void tsBtnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtCodigoProveedor_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar.Equals((char)Keys.Enter))
            {
                try
                {
                    if (!String.IsNullOrEmpty(txtCodigoProveedor.Text))
                    {
                        if (Convert.ToInt32(cbCriterio.SelectedValue).Equals(1)) //código
                        {
                            if (Validacion.ConFormato
                                (Validacion.TipoValidacion.Numeros, txtCodigoProveedor, miError, "El código tiene formato incorrecto."))
                            {
                                CargarProveedorCodigo(txtCodigoProveedor.Text);
                                txtNumeroFactura.Focus();
                            }
                        }
                        else    // NIT
                        {
                            if (Validacion.ConFormato(Validacion.TipoValidacion.NumeroGuion,
                                           txtCodigoProveedor, miError, "El nit que ingreso tiene formato incorrecto."))
                            {
                                CargarProveedorNit(txtCodigoProveedor.Text);
                                txtNumeroFactura.Focus();
                            }
                        }
                    }
                    else
                    {
                        txtNumeroFactura.Focus();
                    }
                }
                catch (Exception ex)
                {
                    OptionPane.MessageError(ex.Message);
                }
            }
        }

        private void btnBuscarProveedor_Click(object sender, EventArgs e)
        {
            if (!FormExtend)
            {
                var formProveedor = new Proveedor.frmProveedor();
                formProveedor.Extension = true;
                formProveedor.tcProveedor.SelectTab(1);
                FormExtend = true;
                //formProveedor.MdiParent = this.MdiParent;
                formProveedor.ShowDialog();
            }
        }

        private void txtNumeroFactura_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar.Equals((char)Keys.Enter))
            {
                if (!String.IsNullOrEmpty(txtNumeroFactura.Text))
                {
                    if (Validacion.ConFormato
                        (Validacion.TipoValidacion.LetrasGuionNumeros, txtNumeroFactura, miError, FacturaFormat))
                    {
                        if (CargarFactura(txtNumeroFactura.Text))
                        {
                            miError.SetError(txtNumeroFactura, null);
                            /*txtConcepto.Text = "";
                            txtConcepto.Enabled = false;
                            txtCantidad.Focus();
                            txtCantidad.SelectAll();*/
                            txtConcepto.Focus();
                           // txtCantidad.SelectAll();
                        }
                        else
                        {
                            /*miError.SetError(txtNumeroFactura, FacturaLoad);
                            txtNumeroFactura.Focus();*/
                            txtNumeroFactura.Focus();
                        }
                    }
                }
                else
                {
                    txtConcepto.Focus();
                }
                //umeroFactura_Validating(this.txtNumeroFactura, new CancelEventArgs(false));
            }
        }

        private void txtNumeroFactura_Validating(object sender, CancelEventArgs e)
        {
            /*if (!Validacion.EsVacio(txtNumeroFactura, miError, ""))
            {
                if (Validacion.ConFormato
                    (Validacion.TipoValidacion.LetrasGuionNumeros, txtNumeroFactura, miError, FacturaFormat))
                {
                    if (CargarFactura(txtNumeroFactura.Text))
                    {
                        miError.SetError(txtNumeroFactura, null);
                        txtCantidad.Focus();
                        txtCantidad.SelectAll();
                        //dtpFecha.Focus();
                    }
                    else
                    {
                        miError.SetError(txtNumeroFactura, FacturaLoad);
                        txtNumeroFactura.Focus();
                    }
                }
                else
                {
                    //txtNumeroFactura.Focus();
                }
            }
            else
            {
                //txtNumeroFactura.Focus();
            }*/
        }

        private void txtConcepto_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar.Equals((char)Keys.Enter))
            {
                txtCantidad.Focus();
                txtCantidad.SelectAll();
            }
        }

        private void btnFactura_Click(object sender, EventArgs e)
        {
            if (!FormExtend)
            {
                var frmConsulta = new Ventas.Factura.FrmConsulta();
                frmConsulta.Extend = true;
                frmConsulta.MdiParent = this.MdiParent;
                FormExtend = true;
                frmConsulta.Show();
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
                txtCantidad.Text = txtCantidad.Text.Replace(',', '.');
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
                if (!String.IsNullOrEmpty(this.txtCodigoArticulo.Text))
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
                                        txtDescuento.Focus();
                                        txtDescuento.SelectAll();
                                        //Validacion...
                                    }
                                }
                                else
                                {
                                    txtDescuento.Focus();
                                    txtDescuento.SelectAll();
                                    //validar producto de factura.
                                }
                                if (!btnTallaYcolor.Enabled)
                                {
                                    txtDescuento.Focus();
                                    txtDescuento.SelectAll();
                                    /*var detalle = CargarDetalle();
                                    if (Detalle.Count > 0)
                                    {
                                        txtDescuento.Text = Detalle.Where(d => d.Codigo.Equals(detalle.Codigo) &&
                                                                               d.Medida.Equals(detalle.Medida) &&
                                                                               d.Color.Equals(detalle.Color)).
                                                                    First().Descto.ToString();
                                    }
                                    else
                                    {
                                        txtDescuento.Text = "0";
                                    }
                                    txtDescuento.SelectAll();*/
                                }
                            }
                        }
                        else
                        {
                            OptionPane.MessageInformation("El Producto no esta registrado en la base de datos.");
                            miError.SetError(txtCodigoArticulo, "El Producto no esta registrado en la base de datos.");
                        }
                    }
                    else
                    {
                        if (!FormExtend)
                        {
                            var formInventario = new Inventario.Consulta.FrmConsultaInventario();
                            formInventario.MdiParent = this.MdiParent;
                            formInventario.ExtendVenta = true;
                            formInventario.txtCodigoNombre.Text = txtCodigoArticulo.Text;
                            FormExtend = true;
                            formInventario.Show();
                            formInventario.dgvInventario.Focus();
                            formInventario.ColorearGrid();
                        }
                    }
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

        private void txtDescuento_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar.Equals((char)Keys.Enter))
            {
                if (String.IsNullOrEmpty(txtDescuento.Text))
                {
                    txtDescuento.Text = "0";
                }
                //EstructurarConsulta();
                if (Validacion.ConFormato(Validacion.TipoValidacion.NumerosYPunto, txtDescuento,
                    miError, "El valor del descuento es incorrecto."))
                {
                    if (txtNumeroFactura.Text.Equals(""))
                    {
                        if (Factura != null)
                        {
                            EstructurarConsultaSinFactura();
                        }
                        else
                        {
                            miError.SetError(txtCodigoProveedor, "La devolución requere al menos del Proveedor.");
                        }
                    }
                    else
                    {
                        EstructurarConsulta();
                    }
                }
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
                lblDatoFecha.Text = dtpFecha.Value.ToShortDateString();

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

        private void CargarProveedorCodigo(string codigo)
        {
            var code = Convert.ToInt32(codigo);
            if (miBussinesProveedor.ExisteProveedorConCodigo(code))
            {
                miError.SetError(txtCodigoProveedor, null);
                if (Factura == null)
                {
                    Factura = new FacturaVenta();
                }
                Factura.Proveedor = miBussinesProveedor.ConsultarPrveedorBasico(code);
                txtNombreProveedor.Text = Factura.Proveedor.CodigoInternoProveedor + " - NIT: " + Factura.Proveedor.NitProveedor
                            + " - " + Factura.Proveedor.RazonSocialProveedor;
                txtCodigoProveedor.Text = "";
            }
            else
            {
                miError.SetError(txtCodigoProveedor, "El código de proveedor que ingreso no existe.");
            }
        }

        private void CargarProveedorNit(string nit)
        {
            if (miBussinesProveedor.ExisteProveedorConNit(nit))
            {
                miError.SetError(txtCodigoProveedor, null);
                if (Factura == null)
                {
                    Factura = new FacturaVenta();
                }
                Factura.Proveedor = miBussinesProveedor.ConsultarPrveedorBasico(nit);
                txtNombreProveedor.Text = Factura.Proveedor.CodigoInternoProveedor + " - NIT: " + Factura.Proveedor.NitProveedor
                            + " - " + Factura.Proveedor.RazonSocialProveedor;
                txtCodigoProveedor.Text = "";
            }
            else
            {
                miError.SetError(txtCodigoProveedor, "El código de proveedor que ingreso no existe.");
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

            try
            {
                FormExtend = Convert.ToBoolean(args.MiObjeto);
            }
            catch { }

            try
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
                GuardaSeguimientoBono(GuardarBono(nitC, false), false, "");
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

            try
            {
                FormExtend = Convert.ToBoolean(args.MiObjeto);
            }
            catch { }
        }

        /// <summary>
        /// Cargar los datos de la Factura en memoria.
        /// </summary>
        /// <param name="numero"></param>
        private bool CargarFactura(string numero)
        {
            try
            {
                var tabla = miBussinessFactura.ConsultaFacturaProveedor(numero, true);
                if (tabla.Rows.Count != 0)
                {
                    var qRow = (from data in tabla.AsEnumerable()
                                select data).First();

                    if (Factura != null)
                    {
                        if (Factura.Proveedor.CodigoInternoProveedor.Equals(Convert.ToInt32(qRow["Codigo"])))
                        {
                            miError.SetError(txtNumeroFactura, null);
                            Factura.Id = Convert.ToInt32(qRow["Id"]);
                            Factura.Numero = numero;
                            Factura.EstadoFactura.Id = Convert.ToInt32(qRow["IdEstado"]);
                            Factura.Proveedor.CodigoInternoProveedor = Convert.ToInt32(qRow["Codigo"]);
                            Detalle = miBussinessFactura.Detalles(Factura.Id);
                            tabla.Clear();
                            tabla = null;
                            return true;
                        }
                        else
                        {
                            miError.SetError(txtNumeroFactura, "El número de factura no pertenece al proveedor.");
                            return false;
                        }
                    }
                    else
                    {
                        Factura = new FacturaVenta();
                        Factura.Id = Convert.ToInt32(qRow["Id"]);
                        Factura.Numero = numero;
                        Factura.Proveedor.IdRegimen = Convert.ToInt32(qRow["regimen"]);
                        Factura.Proveedor.NitProveedor = qRow["Nit"].ToString();
                        Factura.Proveedor.CodigoInternoProveedor = Convert.ToInt32(qRow["Codigo"]);
                        Factura.EstadoFactura.Id = Convert.ToInt32(qRow["IdEstado"]);
                        Detalle = miBussinessFactura.Detalles(Factura.Id);
                        txtCodigoProveedor.Text = qRow["Codigo"].ToString();
                        txtCodigoProveedor_KeyPress(this.txtCodigoProveedor, new KeyPressEventArgs((char)Keys.Enter));
                        tabla.Clear();
                        tabla = null;
                        return true;
                    }


                    /*  Factura = new FacturaVenta();
                      Factura.Id = Convert.ToInt32(qRow["Id"]);
                      Factura.Numero = numero;
                      Factura.Proveedor.IdRegimen = Convert.ToInt32(qRow["regimen"]);
                      Factura.Proveedor.NitProveedor = qRow["Nit"].ToString();
                      Factura.EstadoFactura.Id = Convert.ToInt32(qRow["IdEstado"]);
                      Detalle = miBussinessFactura.Detalles(Factura.Id);
                      tabla.Clear();
                      tabla = null;
                      return true;*/
                }
                else
                {
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
        public bool ProductoDeFactura(int idFactura, DetalleProducto dProducto)
        {
            try
            {
                return miBussinessFactura.ProductoDeFactura(idFactura, dProducto);
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
                MiProducto.ValorCosto = miBussinesProducto.PrecioDeCosto(MiProducto.CodigoInternoProducto);
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

        private DetalleProducto CargarDetalle()
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
                if (Factura == null)
                {
                    miError.SetError(txtNumeroFactura, "Debe cargar primero una Factura");
                    //return null;
                }
                else
                {
                    miError.SetError(txtNumeroFactura, null);
                    //  return detalle;
                }
            }
            return detalle;
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
                if (Factura == null)
                {
                    miError.SetError(txtNumeroFactura, "Debe cargar primero una Factura");
                    return;
                }
                else
                {
                    miError.SetError(txtNumeroFactura, null);
                }

                if (ProductoDeFactura(Factura.Id, detalle))
                {
                    detalle.Cantidad = Convert.ToDouble(txtCantidad.Text);
                    if (CantidadDeProducto(detalle))
                    {
                        /* if (!ProductoDevuelto(detalle))
                         {
                             if (!ProductoRepeat(detalle))
                             {*/
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
                        //MiProducto.ValorVentaProducto
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
                        row["Cantidad"] = Convert.ToDouble(txtCantidad.Text);
                        //row["ValorUnitario"] = Convert.ToInt32(MiProducto.ValorVentaProducto / (1 + (MiProducto.ValorIva / 100)));
                        row["ValorUnitario"] = Detalle.Where(d => d.Codigo.Equals(detalle.Codigo) &&
                                                                  d.Medida.Equals(detalle.Medida) &&
                                                                  d.Color.Equals(detalle.Color)).
                                                       First().ValorUnitario;

                        var vun = row["ValorUnitario"].ToString();

                        /*if (cbDescuentoProducto.Enabled)
                        {
                            row["Descuento"] =
                                    ((DTO.Clases.Descuento)cbDescuentoProducto.SelectedItem).ValorDescuento.ToString() + "%";
                        }
                        else
                        {
                            row["Descuento"] = "0%";
                        }*/
                        row["Descuento"] = txtDescuento.Text + "%";

                        // Edición 07-05-2017
                        row["ValorMenosDescto"] = Math.Round((Convert.ToDouble(Convert.ToDouble(row["ValorUnitario"]) -
                                (Convert.ToDouble(row["ValorUnitario"]) * UseObject.RemoveCharacter(row["Descuento"].ToString(), '%') / 100))), 2);
                        // Fin edición
                       /* row["ValorMenosDescto"] = Convert.ToDouble(Convert.ToInt32(row["ValorUnitario"]) -
                                (Convert.ToInt32(row["ValorUnitario"]) * UseObject.RemoveCharacter(row["Descuento"].ToString(), '%') / 100));*/

                        var val_des = row["ValorMenosDescto"].ToString();

                        if (Factura.Proveedor.IdRegimen.Equals(1))  //Comun
                        {
                            row["Iva"] = MiProducto.ValorIva.ToString() + "%";
                        }
                        else
                        {
                            row["Iva"] = 0 + "%";
                        }
                        /*if (miEmpresa.Regimen.IdRegimen == 1)  //Comun
                        {
                            row["Iva"] = MiProducto.ValorIva.ToString() + "%";
                        }
                        else
                        {
                            row["Iva"] = 0 + "%";
                        }*/
                        var j = Convert.ToDouble(Convert.ToDouble(row["ValorMenosDescto"]) *
                                                 UseObject.RemoveCharacter(row["Iva"].ToString(), '%') / 100);
                        row["TotalMasIva"] = Math.Round((
                                              Convert.ToDouble((Convert.ToDouble(row["ValorMenosDescto"]) *
                                              UseObject.RemoveCharacter(row["Iva"].ToString(), '%') / 100) +
                                              Convert.ToDouble(row["ValorMenosDescto"]))), 2);

                        var totalmasiva = row["TotalMasIva"].ToString();

                        row["Valor"] = Math.Round((
                                       Convert.ToDouble(row["TotalMasIva"]) /*Convert.ToDouble(row["TotalMasIva"])*/ *
                                       Convert.ToDouble(row["Cantidad"])), 2);

                        var val = row["Valor"].ToString();

                        miTabla.Rows.Add(row);

                        //  var v = miTabla.AsEnumerable().Sum(s => s.Field<double>("Valor"));

                        txtTotal.Text = UseObject.InsertSeparatorMil
                            (
                               Convert.ToInt32(
                               miTabla.AsEnumerable().Sum(s => s.Field<double>("Valor"))
                               ).ToString()
                            );
                        RecargarGridview();
                        LimpiarCampos();
                        btnTallaYcolor.Enabled = false;
                        txtCodigoProveedor.Enabled = false;
                        btnBuscarProveedor.Enabled = false;
                        txtNumeroFactura.Enabled = false;
                        txtConcepto.Enabled = false;
                        /*}
                        else
                        {
                            OptionPane.MessageInformation("Ha llegado al límite de la cantidad de este producto en la factura.");
                            miError.SetError(txtCodigoArticulo, "Ha llegado al límite de la cantidad de este producto en la factura.");
                        }
                    }
                    else
                    {
                        OptionPane.MessageInformation("Ha llegado al límite de la cantidad de este producto en la Factura.");
                        miError.SetError(txtCodigoArticulo, "Ha llegado al límite de la cantidad de este producto en la Factura.");
                        txtCodigoArticulo.Focus();
                    }*/
                        //
                    }
                    else
                    {
                        OptionPane.MessageInformation("Ha llegado al límite de la cantidad de este producto en la Factura.");
                        miError.SetError(txtCodigoArticulo, "Ha llegado al límite de la cantidad de este producto en la Factura.");
                        txtCodigoArticulo.Focus();
                    }
                }
                else
                {
                    OptionPane.MessageInformation("El producto que ingreso no pertenece a esta Factura.");
                    miError.SetError(txtCodigoArticulo, "El producto que ingreso no pertenece a esta Factura.");
                }
            }
            else
            {
                OptionPane.MessageError("Debe cargar primero un artículo.");
                miError.SetError(txtCodigoArticulo, "Debe cargar primero un artículo.");
                txtCodigoArticulo.Focus();
            }
        }

        private void EstructurarConsultaSinFactura()
        {
            if (MiProducto != null)
            {
                miError.SetError(txtCodigoArticulo, null);
                Contador++;
                var row = miTabla.NewRow();
                if (MiProducto.AplicaTalla)
                {
                    row["Unidad"] = "Talla";
                    row["IdMedida"] = miTallaYcolor.IdTalla;
                    row["Medida"] = miTallaYcolor.Talla;
                }
                else
                {
                    row["Unidad"] = MiMedida.DescripcionUnidadMedida;
                    row["IdMedida"] = MiMedida.IdValorUnidadMedida;
                    row["Medida"] = MiMedida.DescripcionValorUnidadMedida;
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

                row["Id"] = Contador;
                row["Codigo"] = MiProducto.CodigoInternoProducto;
                row["Articulo"] = MiProducto.NombreProducto;
                row["Cantidad"] = Convert.ToDouble(txtCantidad.Text.Replace('.', ','));
                row["ValorUnitario"] = MiProducto.ValorCosto;

                row["Descuento"] = txtDescuento.Text + "%";

                // Edición 07-05-2017
                row["ValorMenosDescto"] = Math.Round((Convert.ToDouble(Convert.ToDouble(row["ValorUnitario"]) -
                        (Convert.ToDouble(row["ValorUnitario"]) * UseObject.RemoveCharacter(row["Descuento"].ToString(), '%') / 100))), 2);
                // Fin edición
                /*row["ValorMenosDescto"] = Convert.ToDouble(Convert.ToInt32(row["ValorUnitario"]) -
                        (Convert.ToInt32(row["ValorUnitario"]) * UseObject.RemoveCharacter(row["Descuento"].ToString(), '%') / 100));*/
                row["Iva"] = MiProducto.ValorIva.ToString() + "%";

                row["TotalMasIva"] = Math.Round(
                                      Convert.ToDouble((Convert.ToDouble(row["ValorMenosDescto"]) *
                                      UseObject.RemoveCharacter(row["Iva"].ToString(), '%') / 100) +
                                      Convert.ToDouble(row["ValorMenosDescto"])), 2);

                row["Valor"] = Math.Round((
                               Convert.ToDouble(row["TotalMasIva"]) * 
                               Convert.ToDouble(row["Cantidad"])), 2);

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
                txtCodigoProveedor.Enabled = false;
                btnBuscarProveedor.Enabled = false;
                txtNumeroFactura.Enabled = false;
                txtConcepto.Enabled = false;
            }
            else
            {
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
        private void ActualizarInformacion_(int rowIndex, string valor, bool iva_)
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

            miTabla.Rows[index]["TotalMasIva"] = Convert.ToDouble(
                (Convert.ToDouble(miTabla.Rows[index]["ValorMenosDescto"]) *
                UseObject.RemoveCharacter(miTabla.Rows[index]["Iva"].ToString(), '%') / 100) +
                Convert.ToDouble(miTabla.Rows[index]["ValorMenosDescto"]));

            miTabla.Rows[index]["Valor"] = Convert.ToDouble(
                Convert.ToDouble(miTabla.Rows[index]["TotalMasIva"]) *
                Convert.ToDouble(miTabla.Rows[index]["Cantidad"]));

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

        // Edicion 07-05-2017 - mejoras por calculo de datos.
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
                miTabla.Rows[index]["ValorUnitario"] = Math.Round(Convert.ToDouble(Convert.ToDouble(valor) /
                    ((UseObject.RemoveCharacter(miTabla.Rows[index]["Iva"].ToString(), '%') / 100) + 1)), 2);
            }
            else
            {
                miTabla.Rows[index]["ValorUnitario"] = Convert.ToDouble(valor);
            }

            miTabla.Rows[index]["ValorMenosDescto"] = Math.Round(
                Convert.ToDouble(Convert.ToDouble(miTabla.Rows[index]["ValorUnitario"]) -
                (Convert.ToDouble(miTabla.Rows[index]["ValorUnitario"]) *
                UseObject.RemoveCharacter(miTabla.Rows[index]["Descuento"].ToString(), '%') / 100)), 2);

            miTabla.Rows[index]["TotalMasIva"] = Math.Round(Convert.ToDouble(
                (Convert.ToDouble(miTabla.Rows[index]["ValorMenosDescto"]) *
                UseObject.RemoveCharacter(miTabla.Rows[index]["Iva"].ToString(), '%') / 100) +
                Convert.ToDouble(miTabla.Rows[index]["ValorMenosDescto"])), 2);

            miTabla.Rows[index]["Valor"] = Math.Round(Convert.ToDouble(
                Convert.ToDouble(miTabla.Rows[index]["TotalMasIva"]) *
                Convert.ToDouble(miTabla.Rows[index]["Cantidad"])), 2);

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
        // Fin edición 

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
            this.txtCantidad.Focus();
            //this.txtCodigoArticulo.Focus();
            this.txtCodigoArticulo.Text = "";
            txtCantidad.Text = "1";
            MiProducto = null;
            miTallaYcolor.IdTalla = 0;
            miTallaYcolor.IdColor = 0;
            miTallaYcolor.Talla = "";
            miTallaYcolor.Color = null;
            btnTallaYcolor.Enabled = false;
            txtDescuento.Text = "0";
        }

        /// <summary>
        /// Limpia todos los campos del Formulario para disponer una nueva Devolución.
        /// </summary>
        private void LimpiarCamposNewDevolucion()
        {
            //txtNumeroFactura.Focus();
            LimpiarCampos();
            txtNumeroFactura.Enabled = true;
            //txtNumeroFactura.Focus();
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
            txtCodigoProveedor.Enabled = true;
            txtCodigoProveedor.Focus();
            btnBuscarProveedor.Enabled = true;
            txtNombreProveedor.Text = "";
            txtConcepto.Enabled = true;
            txtConcepto.Text = "";
        }

        private int ValorFactura(int id)
        {
            try
            {
                var tProductos = miBussinessFactura.ConsultaProductoFacturaProveedor(id);
                var tRetenciones = miBussinesRetencion.RetencionesACompra(id);
                var subTotal = Convert.ToInt32(
                    tProductos.AsEnumerable().Sum(s => (s.Field<double>("Valor") * s.Field<double>("Cantidad"))));
                int descto = 0;
                int iva = 0;
                foreach (DataRow row in tProductos.Rows)
                {
                    descto += Convert.ToInt32((Convert.ToDouble(row["Valor"]) *
                                UseObject.RemoveCharacter(row["Descuento"].ToString(), '%') / 100) *
                                Convert.ToDouble(row["Cantidad"]));
                    iva += Convert.ToInt32(row["ValorIva"]);
                }
                int retencion = 0;
                foreach (DataRow rRow in tRetenciones.Rows)
                {
                    retencion += Convert.ToInt32(subTotal * Convert.ToDouble(rRow["tarifa"]) / 100);
                }
                subTotal -= descto;
                subTotal += iva;
                subTotal += Convert.ToInt32(miBussinessFactura.ConsultaAjuste(id));
                subTotal += retencion;
                return subTotal;
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
                return 0;
            }
        }

        /// <summary>
        /// Cargar y guarda la información del bono generado al Cliente.
        /// </summary>
        /// <param name="cliente">Nit o C.C. del cliente a guardar en el bono.</param>
        private Bono GuardarBono(string cliente, bool canje)
        {
            var bono = new Bono();
            bono.IdCaja = Convert.ToInt32(AppConfiguracion.ValorSeccion("id_caja"));
            bono.IdUsuario = Convert.ToInt32(AppConfiguracion.ValorSeccion("id_user"));
            bono.Cliente = cliente;
            bono.Factura = Factura.Numero;
            bono.Fecha = DateTime.Today;
            bono.Valor = Convert.ToInt32
                         (
                           miTabla.AsEnumerable().Sum(s => s.Field<double>("Valor"))
                         );
            bono.Canje = canje;
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

        private Bono GuardarBono(string cliente, int valor, bool canje)
        {
            var bono = new Bono();
            bono.IdCaja = Convert.ToInt32(AppConfiguracion.ValorSeccion("id_caja"));
            bono.IdUsuario = Convert.ToInt32(AppConfiguracion.ValorSeccion("id_user"));
            bono.Cliente = cliente;
            bono.Factura = Factura.Numero;
            bono.Fecha = DateTime.Today;
            bono.Valor = valor;
            bono.Canje = canje;
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

        private void PrintEgreso(DTO.Clases.Egreso egreso, string beneficio)
        {
            var miBussinesPuc = new BussinesPuc();
            /*DialogResult rta = MessageBox.Show("¿Desea imprimir el Comprobante de Egreso?", "Factura Proveedor",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rta.Equals(DialogResult.Yes))
            {*/
            try
            {
                var bussinesBeneficio = new BussinesBeneficio();
                var b = bussinesBeneficio.BeneficiariosNit(beneficio);
                var miBeneficio = new DTO.Clases.Cliente();
                if (b.Rows.Count != 0)
                {
                    var bRow = b.Rows[0];
                    miBeneficio.NitCliente = bRow["nit"].ToString();
                    miBeneficio.NombresCliente = bRow["nombre"].ToString();
                }

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
                var printEgreso = new Compras.Egreso.FrmPrintComprobante();
                //printEgreso.MdiParent = this.MdiParent;
                printEgreso.Numero = egreso.Numero;
                printEgreso.Fecha = egreso.Fecha;
                printEgreso.Remite = miBeneficio.NombresCliente + "  CC o NIT : " +
                                     miBeneficio.NitCliente;
                printEgreso.Cuentas = tabla;
                printEgreso.Cheque = egreso.Pagos.Where(p => p.IdFormaPago == 2).Sum(s => s.Valor).ToString();
                printEgreso.Efectivo = egreso.Pagos.Where(p => p.IdFormaPago == 1).Sum(s => s.Valor).ToString();
                printEgreso.ShowDialog();
                //}
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
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


        /// <summary>
        /// Guarda la información correspondiente a un seguimiento  del bono.
        /// </summary>
        /// <param name="bono">Datos del Seguimiento del bono a ingresar.</param>
        private void GuardaSeguimientoBono(Bono bono, bool saldo, string numero)
        {
            try
            {
                if (!saldo)
                {
                    bono.Valor = 0;
                }
                miBussinesBono.IngresarSeguimiento(bono, numero);
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
        }

        /// <summary>
        /// Edita el cliente relacionado en la factura de venta.
        /// </summary>
        /// <param name="factura">Datos de la factura de venta a editar.</param>
        private void EditarClienteFactura(FacturaVenta factura)
        {
            try
            {
                miBussinesFactura.EditarCliente(factura);
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
        }

        /*private int DescontarAFactura
            (string numero, int valor, int abonos, int salDev, ref int valorDev)
        {
            miBussinesDevolucion.IngresarSaldoDevolucionVenta(numero, valor);
            /*var saldoAdevol = 0;
            if (valorDev < (valor - (abonos + salDev)))
            {
                miBussinesDevolucion.IngresarSaldoDevolucionVenta(numero, valorDev);
                saldoAdevol = valorDev;
            }
            else
            {
                miBussinesDevolucion.IngresarSaldoDevolucionVenta(numero, valor - (abonos + salDev));
                saldoAdevol = valor - (abonos + salDev);
            }
            valorDev = valorDev - (valor - (abonos + salDev));
            return saldoAdevol;
        }*/

        private DTO.Clases.Ingreso GenerarNotaCredito //Bono a Cliente
            (string numero, string cliente, DateTime fecha, int valorDev)
        {
            var b = GuardarBono(cliente, valorDev, false);
            GuardaSeguimientoBono(b, false, numero);
            var ingreso = new DTO.Clases.Ingreso();
            ingreso.Fecha = fecha;
            ingreso.Numero = b.Id.ToString();
            ingreso.Concepto = "Saldo por devoluciones.";
            ingreso.Valor = valorDev;
            //valorDev = 0;
            /*var bussinesCliente = new BussinesCliente();
            var cliente_ = bussinesCliente.ClienteAEditar(cliente);
            
            valorDev = 0;*/

            return ingreso;

            //genera documento nota credito
        }

        private Ingreso GenerarIngreso
            (string noFactura, DateTime fecha, int valor)
        {
            var numero = AppConfiguracion.ValorSeccion("ingreso");
            var ingreso = new Ingreso
            {
                Numero = numero,
                Concepto = "Abono con Devolución a Factura No. " + noFactura,
                Tipo = 4,
                Fecha = fecha,
                Valor = valor,
                Relacion = miBussinesDevolucion.IngresarSaldoDevolucionVenta(noFactura, valor, IdUsuario, IdCaja, fecha)//(noFactura, valor)
            };
            /*var bussinesIngreso = new BussinesIngreso();
            bussinesIngreso.Ingresar(ingreso);
            if (Convert.ToInt32(numero) < 99)
            {
                AppConfiguracion.SaveConfiguration
                    ("ingreso", IncrementaConsecutivo(numero));
            }
            else
            {
                AppConfiguracion.SaveConfiguration
                    ("ingreso", (Convert.ToInt32(numero) + 1).ToString());
            }*/
            return ingreso;
        }

        private Ingreso GenerarIngreso(List<Ingreso> ingresos, DateTime fecha)
        {
            var bussinesIngreso = new BussinesIngreso();
            var facts = "";
            var numero = AppConfiguracion.ValorSeccion("ingreso");
            foreach (var ing in ingresos)
            {
                facts = facts + ", " + ing.Numero;
            }
            var ingreso = new Ingreso
            {
                Numero = numero,
                Concepto = "Abonos con Devolución a Facturas No. " + facts,
                Tipo = 4,
                Fecha = fecha,
                Valor = ingresos.Sum(s => s.Valor)
            };

            foreach (var ing in ingresos)
            {
                ingreso.Relacion = ing.Id;
                bussinesIngreso.Ingresar(ingreso, false);
            }
            if (Convert.ToInt32(numero) < 99)
            {
                AppConfiguracion.SaveConfiguration
                    ("ingreso", IncrementaConsecutivo(numero));
            }
            else
            {
                AppConfiguracion.SaveConfiguration
                    ("ingreso", (Convert.ToInt32(numero) + 1).ToString());
            }
            return ingreso;
        }

        private DTO.Clases.Egreso ReintegroEfectivo
            (string cliente, int valorDev)
        {
            //genera comprobante de egreso
            var egreso = new DTO.Clases.Egreso();
            var bussinesBeneficio = new BussinesBeneficio();
            var b = bussinesBeneficio.BeneficiariosNit(cliente);
            var miBeneficio = new DTO.Clases.Cliente();
            if (b.Rows.Count != 0)
            {
                var bRow = b.Rows[0];
                egreso.TipoBeneficiario = Convert.ToInt32(bRow["id"]);

                miBeneficio.NitCliente = bRow["nit"].ToString();
                miBeneficio.NombresCliente = bRow["nombre"].ToString();
            }
            else
            {
                var bussinesCliente = new BussinesCliente();
                var cliente_ = bussinesCliente.ClienteAEditar(cliente);
                bussinesBeneficio.Ingresar(cliente_);
                b = bussinesBeneficio.BeneficiariosNit(cliente_.NitCliente);
                var bRow = b.Rows[0];
                egreso.TipoBeneficiario = Convert.ToInt32(bRow["id"]);

                miBeneficio.NitCliente = bRow["nit"].ToString();
                miBeneficio.NombresCliente = bRow["nombre"].ToString();
                cliente_ = null;
                bussinesCliente = null;
            }
            b.Rows.Clear();
            b.Clear();
            b = null;
            bussinesBeneficio = null;

            egreso.IdCaja = Convert.ToInt32(AppConfiguracion.ValorSeccion("id_caja"));
            egreso.IdUsuario = Convert.ToInt32(AppConfiguracion.ValorSeccion("id_user"));
            egreso.Numero = AppConfiguracion.ValorSeccion("numero-e");
            egreso.Fecha = DateTime.Now;
            egreso.Total = valorDev;
            egreso.Estado = true;
            egreso.Pagos.Add(new DTO.Clases.FormaPago
            {
                IdFormaPago = 1,
                Valor = egreso.Total
            });
            egreso.Cuentas.Add(new ConceptoEgreso
            {
                IdCuenta = Convert.ToInt32(AppConfiguracion.ValorSeccion("devolucioncliente")),
                Id = Convert.ToInt32(AppConfiguracion.ValorSeccion("ctadevolucioncliente")),
                Nombre = "Devoluciones de Cliente.",
                Numero = egreso.Total.ToString()
            });
            var bussinesEgreso = new BussinesEgreso();
            bussinesEgreso.IngresarEgreso(egreso);
            if (Convert.ToInt32(egreso.Numero) < 99)
            {
                AppConfiguracion.SaveConfiguration
                    ("numero-e", IncrementaConsecutivo(egreso.Numero));
            }
            else
            {
                AppConfiguracion.SaveConfiguration
                    ("numero-e", (Convert.ToInt32(egreso.Numero) + 1).ToString());
            }

            //valorDev = 0;
            return egreso;
        }

        private List<Ingreso> AbonoGeneralAcliente(string cliente, ref int valorDev, DateTime fecha)
        {
            return miBussinesDevolucion.IngresarSaldoGeneralDevolucionVenta
                                (cliente, ref valorDev, IdUsuario, IdCaja, fecha);
        }

        private void PrintNotaCredito(Ingreso ingreso, string cliente)
        {
            try
            {
                /* var printCompIng = new Cliente.FrmPrintAnticipo();
                 printCompIng.Numero = ingreso.Numero;
                 printCompIng.Fecha = ingreso.Fecha;
                 var bussinesCliente = new BussinesCliente();
                 var cliente_ = bussinesCliente.ClienteAEditar(cliente);
                 printCompIng.Nit = cliente_.NitCliente;
                 printCompIng.Cliente = cliente_.NombresCliente;
                 printCompIng.Direccion = cliente_.DireccionCliente + "  " +
                     cliente_.Ciudad + "  " + cliente_.Departamento;
                 printCompIng.Concepto = ingreso.Concepto;
                 printCompIng.Valor = ingreso.Valor.ToString();


                 printCompIng.AplicaPago = false;
                 printCompIng.TipoRecibo = 3;
                 //printCompIng.ReportPath = @"C:\reports\NotaCredito.rdlc";
                 printCompIng.ReportPath = AppConfiguracion.ValorSeccion("report") + @"\reports\NotaCredito.rdlc";

                 printCompIng.ShowDialog();*/
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
        }

        private void PrintIngreso
            (Ingreso ingreso, DTO.Clases.FormaPago pago, string cliente)
        {
            /*var printComprobante = new Cliente.FrmPrintAnticipo();
            printComprobante.Fecha = ingreso.Fecha;
            var bussinesCliente = new BussinesCliente();
            var miCliente = bussinesCliente.ClienteAEditar(cliente);
            printComprobante.Cliente = miCliente.NombresCliente;
            printComprobante.Nit = miCliente.NitCliente;
            printComprobante.Direccion =
                miCliente.DireccionCliente + "  " + miCliente.Ciudad + "  " + miCliente.Departamento;
            printComprobante.Valor = pago.Valor.ToString();
            printComprobante.Efectivo = pago.Valor.ToString();
            printComprobante.Cheque = "0";
            printComprobante.Numero = ingreso.Numero;
            printComprobante.Concepto = ingreso.Concepto;
            printComprobante.ShowDialog();*/
        }

        private void PrintEstadoCartera
            (DateTime fecha, string nitCliente, DataTable cartera, DataTable transacion)
        {
            try
            {
                /*var frmPrintCartera = new Cliente.Cartera.FrmPrintCartera();
                frmPrintCartera.Fecha = fecha;
                frmPrintCartera.NitCliente = nitCliente;
                var bCliente = new BussinesCliente();
                var c = bCliente.ClienteAEditar(nitCliente);
                frmPrintCartera.Cliente = c.NombresCliente;
                frmPrintCartera.DsCartera = cartera;
                frmPrintCartera.DsTransaccion = transacion;
                frmPrintCartera.TotalCartera = miBussinesFactura.SaldoPorCliente(2, Factura.Proveedor.NitProveedor);
                frmPrintCartera.ShowDialog();*/
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
        }

        private void PrintComprobanteDevolucion(FacturaProveedor devolucion)
        {
            //string numero, string noFact, int total, string cliente, int credito, int valDev, int reintegro
            //var dsEmpresa = new DataSet();
            try
            {
                /*DialogResult rta = MessageBox.Show("¿Desea visualizar la impresión de la Nota Crédito?", "Devolución Proveedor",
                                        MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);*/

                FrmPrint frmPrint_ = new FrmPrint();
                frmPrint_.StringCaption = "Devolución Proveedor";
                frmPrint_.StringMessage = "Impresión de la Nota Crédito a Proveedor";
                DialogResult rta = frmPrint_.ShowDialog();

                if (!rta.Equals(DialogResult.Cancel))
                {
                    var dsEmpresa = miBussinesEmpresa.PrintEmpresa();
                    var dsDetalle = DsDetalle();

                    var frmPrint = new FrmPrintDevolucion();

                    frmPrint.RptvFactura.LocalReport.DataSources.Clear();
                    frmPrint.RptvFactura.LocalReport.Dispose();
                    frmPrint.RptvFactura.Reset();

                    frmPrint.RptvFactura.LocalReport.DataSources.Add(
                       new ReportDataSource("DsDetalle", dsDetalle));
                    frmPrint.RptvFactura.LocalReport.DataSources.Add(
                        new ReportDataSource("DsEmpresa", dsEmpresa.Tables["Empresa"]));

                    frmPrint.RptvFactura.LocalReport.ReportPath =
                        AppConfiguracion.ValorSeccion("report") + @"\reports\ComprobanteDevolucionCompra.rdlc";
                    //frmPrint.RptvFactura.LocalReport.ReportPath =
//@"C:\Users\alejoQ2009\Documents\Visual Studio 2010\Projects\Edicion\DFPYME\Aplicacion\Informes\ComprobanteDevolucionCompra.rdlc";

                    Label NoFactura = new Label();
                    NoFactura.AutoSize = true;
                    NoFactura.Font = new System.Drawing.Font
                        ("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                    NoFactura.Text = devolucion.Numero;

                    var pNoFact = new ReportParameter();
                    pNoFact.Name = "No";
                    pNoFact.Values.Add(NoFactura.Text);
                    frmPrint.RptvFactura.LocalReport.SetParameters(pNoFact);

                    var pFecha = new ReportParameter();
                    pFecha.Name = "Fecha";
                    pFecha.Values.Add(devolucion.FechaIngreso.ToShortDateString());
                    frmPrint.RptvFactura.LocalReport.SetParameters(pFecha);

                    var pConcepto = new ReportParameter();
                    pConcepto.Name = "Concepto";
                    pConcepto.Values.Add(devolucion.Proveedor.DescripcionProveedor);
                    frmPrint.RptvFactura.LocalReport.SetParameters(pConcepto);

                    var pNit = new ReportParameter();
                    pNit.Name = "Nit";
                    pNit.Values.Add(devolucion.Proveedor.NitProveedor);
                    frmPrint.RptvFactura.LocalReport.SetParameters(pNit);

                    var pProveedor = new ReportParameter();
                    pProveedor.Name = "Proveedor";
                    pProveedor.Values.Add(devolucion.Proveedor.RazonSocialProveedor);
                    frmPrint.RptvFactura.LocalReport.SetParameters(pProveedor);

                    var pSubTotal = new ReportParameter();
                    pSubTotal.Name = "SubTotal";
                    pSubTotal.Values.Add(SubTotal().ToString());
                    frmPrint.RptvFactura.LocalReport.SetParameters(pSubTotal);

                    var pDescuento = new ReportParameter();
                    pDescuento.Name = "Descuento";
                    pDescuento.Values.Add(ValorDescuento().ToString());
                    frmPrint.RptvFactura.LocalReport.SetParameters(pDescuento);

                    var pIva = new ReportParameter();
                    pIva.Name = "Iva";
                    pIva.Values.Add(ValorIva().ToString());
                    frmPrint.RptvFactura.LocalReport.SetParameters(pIva);

                    var pTotal = new ReportParameter();
                    pTotal.Name = "Total";
                    pTotal.Values.Add(((SubTotal() - ValorDescuento()) + ValorIva()).ToString());
                    frmPrint.RptvFactura.LocalReport.SetParameters(pTotal);

                    frmPrint.RptvFactura.RefreshReport();

                    if (rta.Equals(DialogResult.No))
                    {
                        frmPrint.ShowDialog();
                    }
                    else
                    {
                        Imprimir print = new Imprimir();
                        print.Report = frmPrint.RptvFactura.LocalReport;
                        print.Print(Imprimir.TamanioPapel.MediaCarta);
                        frmPrint.RptvFactura.Reset();
                    }
                }

                /*dsDetalle = DsDetalle();
                dsEmpresa = miBussinesEmpresa.PrintEmpresa();
                var tUser = miBussinesUsuario.ConsultaUsuario
                    (Convert.ToInt32(AppConfiguracion.ValorSeccion("id_user")));
                if(tUser.Rows.Count != 0)
                {
                    var query = (from d in tUser.AsEnumerable()
                                 select d).Single();
                    usuario = query["nombre"].ToString();
                }
                dsCliente = miBussinesCliente.PrintCliente(cliente);

                var frmPrint = new FrmPrintFactura();

                frmPrint.RptvFactura.LocalReport.DataSources.Clear();
                frmPrint.RptvFactura.LocalReport.Dispose();
                frmPrint.RptvFactura.Reset();

                frmPrint.RptvFactura.LocalReport.DataSources.Add(
                   new ReportDataSource("DsDetalle", dsDetalle));
                frmPrint.RptvFactura.LocalReport.DataSources.Add(
                    new ReportDataSource("DsEmpresa", dsEmpresa.Tables["Empresa"]));
                frmPrint.RptvFactura.LocalReport.DataSources.Add(
                    new ReportDataSource("DsCliente", dsCliente.Tables["Cliente"]));

                //frmPrint.RptvFactura.LocalReport.ReportPath = @"C:\reports\ComprobanteDevolucion.rdlc";
                frmPrint.RptvFactura.LocalReport.ReportPath = AppConfiguracion.ValorSeccion("report") + @"\reports\ComprobanteDevolucion.rdlc";
                //frmPrint.RptvFactura.LocalReport.ReportPath = @"C:\reports\RptFacturaVenta.rdlc";

                Label NoFactura = new Label();
                NoFactura.AutoSize = true;
                NoFactura.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                NoFactura.Text = numero;

                var pNoFact = new ReportParameter();
                pNoFact.Name = "NoFact";
                pNoFact.Values.Add(noFact);
                frmPrint.RptvFactura.LocalReport.SetParameters(pNoFact);

                var pTotal = new ReportParameter();
                pTotal.Name = "Total";
                pTotal.Values.Add(SubTotal().ToString());//total.ToString());
                frmPrint.RptvFactura.LocalReport.SetParameters(pTotal);

                var Fact = new ReportParameter();
                Fact.Name = "Fact";
                Fact.Values.Add(NoFactura.Text);
                frmPrint.RptvFactura.LocalReport.SetParameters(Fact);

                var pFecha = new ReportParameter();
                pFecha.Name = "Fecha";
                pFecha.Values.Add(dtpFecha.Value.ToShortDateString());
                frmPrint.RptvFactura.LocalReport.SetParameters(pFecha);

                var pCredito = new ReportParameter();
                pCredito.Name = "Credito";
                pCredito.Values.Add(ValorDescuento().ToString());//credito.ToString());
                frmPrint.RptvFactura.LocalReport.SetParameters(pCredito);

                var pValDev = new ReportParameter();
                pValDev.Name = "ValDev";
                pValDev.Values.Add(ValorIva().ToString());//valDev.ToString());
                frmPrint.RptvFactura.LocalReport.SetParameters(pValDev);

                var pReint = new ReportParameter();
                pReint.Name = "Reintegro";
                pReint.Values.Add(((SubTotal() - ValorDescuento()) + ValorIva()).ToString());//reintegro.ToString());
                frmPrint.RptvFactura.LocalReport.SetParameters(pReint);

                var pUser = new ReportParameter();
                pUser.Name = "User";
                pUser.Values.Add(usuario.ToString());
                frmPrint.RptvFactura.LocalReport.SetParameters(pUser);

                frmPrint.RptvFactura.RefreshReport();
                frmPrint.ShowDialog();*/
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
        }

        private void PrintDevolucionPos(FacturaProveedor devolucion)
        {
            try
            {
                var empresaRow = miBussinesEmpresa.PrintEmpresa().
                                 Tables[0].AsEnumerable().First();

                Ticket ticket = new Ticket();

                ticket.AddHeaderLine(empresaRow["Nombre"].ToString().ToUpper());
                ticket.AddHeaderLine(empresaRow["Juridico"].ToString());
                ticket.AddHeaderLine("NIT " + UseObject.InsertSeparatorMilMasDigito(empresaRow["Nit"].ToString()));
                ticket.AddHeaderLine(empresaRow["Direccion"].ToString());
                ticket.AddHeaderLine("Tels. " + empresaRow["Telefono"].ToString());
                ticket.AddHeaderLine("===================================");
                ticket.AddHeaderLine("NOTA CRÉDITO PROVEEDOR No " + devolucion.Numero);
                ticket.AddHeaderLine("Fecha : " + devolucion.FechaIngreso.ToShortDateString());
                ticket.AddHeaderLine("===================================");
                ticket.AddHeaderLine("Proveedor :" + devolucion.Proveedor.RazonSocialProveedor);
                ticket.AddHeaderLine("Nit       :" + devolucion.Proveedor.NitProveedor);
                ticket.AddHeaderLine("===================================");
                ticket.AddHeaderLine("");
                ticket.AddHeaderLine(devolucion.Proveedor.DescripcionProveedor);
                ticket.AddHeaderLine("===================================");

                ticket.AddHeaderLine("");
                foreach (var detalle in devolucion.Productos)
                {
                    ticket.AddItem(detalle.Inventario.Cantidad.ToString(),
                                   detalle.Producto.NombreProducto,
                                   UseObject.InsertSeparatorMil(detalle.Producto.ValorVentaProducto.ToString()));
                }
               // var s_ = devolucion.Productos.Sum(s => s.Producto.ValorCosto);
                ticket.AddTotal("TOTAL : ", UseObject.InsertSeparatorMil(
                        devolucion.Productos.Sum(s => s.Producto.ValorVentaProducto).ToString()));

                ticket.AddFooterLine("===================================");
                ticket.AddFooterLine(".");
                ticket.AddFooterLine(".");
                ticket.AddFooterLine("Firma:");
                ticket.AddFooterLine("-----------------------------------");
                ticket.AddFooterLine("C.C. o NIT:");
                ticket.AddFooterLine("-----------------------------------");
                ticket.AddFooterLine("Fecha:");
                ticket.AddFooterLine("-----------------------------------");
                ticket.AddFooterLine(".");
                ticket.AddFooterLine("Software: Digital Fact Pyme");
                ticket.AddFooterLine("Soluciones Tecnológicas A&C.");
                //ticket.AddFooterLine("Cel. 3128068807");
                ticket.AddFooterLine(".");

                ticket.PrintTicket("IMPREPOS");
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
        }

        private DataTable DsDetalle()
        {
            var tabla = new DataTable();
            tabla.TableName = "Detalle";
            tabla.Columns.Add(new DataColumn("Codigo", typeof(string)));
            tabla.Columns.Add(new DataColumn("Cantidad", typeof(double)));
            tabla.Columns.Add(new DataColumn("Producto", typeof(string)));
            tabla.Columns.Add(new DataColumn("Valor_", typeof(int)));
            tabla.Columns.Add(new DataColumn("Descuento", typeof(double)));
            tabla.Columns.Add(new DataColumn("Total_", typeof(int)));
            foreach (DataRow tRow in miTabla.Rows)
            {
                var row = tabla.NewRow();
                row["Codigo"] = tRow["Codigo"];
                row["Cantidad"] = tRow["Cantidad"];
                row["Producto"] = tRow["Articulo"];
                row["Valor_"] = tRow["TotalMasIva"];
                row["Descuento"] = UseObject.RemoveCharacter(tRow["Descuento"].ToString(), '%');
                row["Total_"] = tRow["Valor"];
                tabla.Rows.Add(row);
            }
            return tabla;
        }

        private int SubTotal()
        {
            int sTotal = 0;
            foreach (DataRow tRow in miTabla.Rows)
            {
                sTotal += Convert.ToInt32(Convert.ToDouble(tRow["ValorUnitario"]) * Convert.ToDouble(tRow["Cantidad"]));
            }
            return sTotal;
        }

        private int ValorDescuento()
        {
            int descto = 0;
            foreach (DataRow tRow in miTabla.Rows)
            {
                descto += Convert.ToInt32((Convert.ToInt32(tRow["ValorUnitario"]) - Convert.ToDouble(tRow["ValorMenosDescto"]))
                          * Convert.ToDouble(tRow["Cantidad"]));
            }
            return descto;
        }

        private int ValorIva()
        {
            int vIva = 0;
            foreach (DataRow tRow in miTabla.Rows)
            {
                vIva += Convert.ToInt32((Convert.ToDouble(tRow["TotalMasIva"]) - Convert.ToDouble(tRow["ValorMenosDescto"]))
                        * Convert.ToDouble(tRow["Cantidad"]));
                //TotalMasIva
            }
            return vIva;
        }
    }
}