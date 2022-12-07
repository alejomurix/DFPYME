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

namespace Aplicacion.Ventas.Devolucion.Anterior
{
    public partial class FrmDevolucionVenta : Form
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

        private string nitC { set; get; }

        private int DevolucionEfectivo { set; get; }

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

        private BussinesConsecutivo miBussinesConsecutivos;

        private BussinesRetiro miBussinesRetiro;

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

        private bool AproxPrecio;

        private bool RedondearPrecio2;

        public Usuario Usuario_ { set; get; }

        private int IdTipoInventarioProductoNoFabricado = 1;

        private int IdTipoInventarioProductoFabricado = 3;

        public FrmDevolucionVenta()
        {
            InitializeComponent();
            this.DevolucionEfectivo = 0;
            nitC = "";
            try
            {
                EnableColor = Convert.ToBoolean(AppConfiguracion.ValorSeccion("color"));
                Promedio = Convert.ToBoolean(AppConfiguracion.ValorSeccion("promedio"));
                NumeroDeFacturas = Convert.ToInt32(AppConfiguracion.ValorSeccion("numero"));
                IdUsuario = Convert.ToInt32(AppConfiguracion.ValorSeccion("id_user"));
                IdCaja = Convert.ToInt32(AppConfiguracion.ValorSeccion("id_caja"));

                this.AproxPrecio = Convert.ToBoolean(AppConfiguracion.ValorSeccion("tipo_aprox_precio"));
                this.RedondearPrecio2 = Convert.ToBoolean(AppConfiguracion.ValorSeccion("redondeo_precio_dos"));
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
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
            miBussinesMedida = new BussinesValorUnidadMedida();
            miBussinesProducto = new BussinesProducto();
            miTallaYcolor = new TallaYcolor();
            miBussinesColor = new BussinesColor();
            miBussinesDevolucion = new BussinesDevolucion();
            miBussinesBono = new BussinesBono();
            miBussinesConsecutivos = new BussinesConsecutivo();
            miBussinesRetiro = new BussinesRetiro();
            CargarEmpresa();
        }

        private void FrmDevolucion_Load(object sender, EventArgs e)
        {
            this.tsBtnCambiarPrecio.Image = ((Image)(miResources.GetObject("tsCambiarPrecio.Image")));
            CompletaEventos.Completam +=
                new CompletaEventos.CompletaAccionm(CompletaEventosm_Completo);
            CompletaEventos.Completa += new CompletaEventos.CompletaAccion(CompletaEventos_Completo);
            CompletaEventos.Completabo += new CompletaEventos.CompletaAccionbo(CompletaEventosbo_Completo);
            CompletaEventos.Completaeb += new CompletaEventos.CompletaAccioneb(CompletaEventos_Completaeb);
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

        private void tsBtnGuardar_Click(object sender, EventArgs e)
        {
            if (dgvListaArticulos.RowCount != 0)
            {
                if (Factura != null)
                {
                    DevolucionConFactura();
                }
                else
                {
                    DevolucionSinFactura();
                }
            }
            else
            {
                OptionPane.MessageInformation("La devolución no presenta artículos.");
            }
        }

        private void tsConsultarProducto_Click(object sender, EventArgs e)
        {
            var formInventario = new Inventario.Consulta.FrmConsultaInventario();
            // formInventario.MdiParent = this.MdiParent;
            formInventario.ExtendVenta = true;
            //formInventario.txtCodigoNombre.Text = txtCodigoArticulo.Text;
            formInventario.ShowDialog();
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

        private void tsBtnReset_Click(object sender, EventArgs e)
        {

        }

        private void tsBtnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
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

        private void DevolucionConFactura()
        {
            List<object> comprobantes = new List<object>();
            miError.SetError(txtCantidad, null);
            miError.SetError(txtCodigoArticulo, null);
            var miBussinesEgreso = new BussinesEgreso();
            if (dgvListaArticulos.RowCount != 0)
            {
                DialogResult rta = MessageBox.Show("¿Está seguro(a) de realizar la devolución?", "Devolución",
                            MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (rta.Equals(DialogResult.Yes))
                {
                    try
                    {
                        /*foreach (DataRow row in miTabla.Rows)
                        {
                            var devolucion = new DTO.Clases.Devolucion();
                            devolucion.Factura = Factura.Numero;
                            devolucion.Producto.CodigoProducto = row["Codigo"].ToString();
                            devolucion.Fecha = DateTime.Today;
                            devolucion.Valor = Convert.ToInt32(row["ValorUnitario"]);
                            devolucion.Cantidad = Convert.ToDouble(row["Cantidad"]);
                            devolucion.Iva = UseObject.RemoveCharacter(row["Iva"].ToString(), '%');//Convert.ToDouble(row["Iva"]);
                            devolucion.Producto.IdMedida = Convert.ToInt32(row["IdMedida"]);
                            devolucion.Producto.IdColor = Convert.ToInt32(row["IdColor"]);
                            devolucion.Descuento = Factura.AplicaDescuento;
                            devolucion.Descto = UseObject.RemoveCharacter(row["Descuento"].ToString(), '%'); //Convert.ToDouble(row["Descuento"]);
                            devolucion.IdUsuario = IdUsuario;
                            devolucion.IdCaja = IdCaja;
                            miBussinesDevolucion.IngresarVenta(devolucion);
                        }*/
                        //var productos_ = miBussinesFactura.ProductoFacturaVenta(Factura.Numero, Factura.AplicaDescuento);
                        var productos_ = miBussinesFactura.ProductoFacturaVenta(Factura.Id, Factura.AplicaDescuento);
                        var totalFacturaR = Convert.ToInt32(productos_.AsEnumerable().Sum(s => s.Field<double>("Valor")));

                        var bussinesPago_ = new BussinesFormaPago();
                        //var pagosR = bussinesPago_.GetTotalFormasDePagoDeFacturaVenta(Factura.Numero);
                        var pagosR = bussinesPago_.GetTotalPagoDeFacturaVentaId(Factura.Id);

                        //var saldoDevR = miBussinesDevolucion.SaldoDevolucionVenta(Factura.Numero);
                        var saldoDevR = miBussinesDevolucion.SaldoDevolucionVenta(Factura.Id);

                        var valorDevolucion = Convert.ToInt32
                                          (
                                            miTabla.AsEnumerable().Sum(s => s.Field<double>("Valor"))
                                          );
                        while (valorDevolucion != 0)
                        {
                            //var productos = miBussinesFactura.ProductoFacturaVenta(Factura.Numero, Factura.AplicaDescuento);
                            var productos = miBussinesFactura.ProductoFacturaVenta(Factura.Id, Factura.AplicaDescuento);
                            var totalFactura = Convert.ToInt32(productos.AsEnumerable().Sum(s => s.Field<double>("Valor")));

                            var bussinesPago = new BussinesFormaPago();
                            var pagos = bussinesPago.GetTotalFormasDePagoDeFacturaVenta(Factura.Numero);

                            var saldoDev = miBussinesDevolucion.SaldoDevolucionVenta(Factura.Numero);

                            var frmResumenDev = new FrmDatosDevolucion();
                            var contado = true;
                            var saldoCliente = miBussinesFactura.SaldoPorCliente(2, Factura.Proveedor.NitProveedor);

                            if (Factura.EstadoFactura.Id.Equals(1) ||
                                (totalFactura <= (pagos + saldoDev)))//contado o credito pagado
                            {
                                if (saldoCliente == 0)
                                {
                                    frmResumenDev.gbDesctoGlobal.Enabled = false;
                                }
                                frmResumenDev.gbAbonoFact.Enabled = false;
                                contado = true;
                            }
                            else//credito y pendiente
                            {
                                frmResumenDev.gbCobro.Enabled = false;
                                frmResumenDev.gbDesctoGlobal.Enabled = false;
                                frmResumenDev.gbSaldoCliente.Enabled = false;
                                contado = false;
                            }
                            if (Factura.EstadoFactura.Id.Equals(1))
                            {
                                frmResumenDev.txtPago.Text = "CONTADO";
                            }
                            else
                            {
                                frmResumenDev.txtPago.Text = "CRÉDITO";
                            }
                            frmResumenDev.txtNoFactura.Text = Factura.Numero;
                            frmResumenDev.txtTotal.Text = UseObject.InsertSeparatorMil(totalFactura.ToString());
                            if (Factura.EstadoFactura.Id.Equals(1))
                            {
                                frmResumenDev.txtAbonos.Text = UseObject.InsertSeparatorMil(totalFactura.ToString());
                            }
                            else
                            {
                                frmResumenDev.txtAbonos.Text = UseObject.InsertSeparatorMil(pagos.ToString());
                            }
                            frmResumenDev.txtDevoluciones.Text = UseObject.InsertSeparatorMil(saldoDev.ToString());
                            if (UseObject.RemoveSeparatorMil(frmResumenDev.txtTotal.Text) <=
                                (UseObject.RemoveSeparatorMil(frmResumenDev.txtAbonos.Text) +
                                    UseObject.RemoveSeparatorMil(frmResumenDev.txtDevoluciones.Text)))
                            {
                                frmResumenDev.txtResta.Text = "0";
                            }
                            else
                            {
                                frmResumenDev.txtResta.Text = UseObject.InsertSeparatorMil(
                                    (UseObject.RemoveSeparatorMil(frmResumenDev.txtTotal.Text) -
                                        (UseObject.RemoveSeparatorMil(frmResumenDev.txtAbonos.Text) +
                                            UseObject.RemoveSeparatorMil(frmResumenDev.txtDevoluciones.Text))).
                                     ToString());
                            }
                            frmResumenDev.txtTotalDevolucion.Text = UseObject.InsertSeparatorMil(valorDevolucion.ToString());
                            if (Factura.EstadoFactura.Id.Equals(1))
                            {
                                frmResumenDev.txtReintegro.Text = "0";
                            }
                            else
                            {
                                if ((valorDevolucion - (totalFactura - (pagos + saldoDev))) > 0)
                                {
                                    frmResumenDev.txtReintegro.Text =
                                        UseObject.InsertSeparatorMil((valorDevolucion -
                                                                     (totalFactura - (pagos + saldoDev))).ToString());
                                }
                                else
                                {
                                    frmResumenDev.txtReintegro.Text = "0";
                                }
                            }

                            rta = frmResumenDev.ShowDialog();

                            if (rta.Equals(DialogResult.Yes)) //Descuento a Factura.
                            {
                                //Descuento a factura actual
                                var dtCartera = miBussinesFactura.DatosSaldoDeCliente
                                    (Factura.Proveedor.NitProveedor, true, new List<Ingreso>());
                                var saldoAdevol = 0;
                                if (valorDevolucion < (totalFactura - (pagos + saldoDev)))
                                {
                                    //miBussinesDevolucion.IngresarSaldoDevolucionVenta(Factura.Numero, valorDevolucion);
                                    saldoAdevol = valorDevolucion;
                                    valorDevolucion = 0;
                                }
                                else
                                {
                                    //miBussinesDevolucion.IngresarSaldoDevolucionVenta(Factura.Numero, totalFactura - (pagos + saldoDev));
                                    saldoAdevol = totalFactura - (pagos + saldoDev);
                                    valorDevolucion = valorDevolucion - (totalFactura - (pagos + saldoDev));
                                }
                                //PrintEgreso(ReintegroEfectivo(Factura.Proveedor.NitProveedor, saldoAdevol), Factura.Proveedor.NitProveedor);
                                /*PrintIngreso(GenerarIngreso(Factura.Numero, dtpFecha.Value, saldoAdevol),
                                             new DTO.Clases.FormaPago { IdFormaPago = 1, Valor = saldoAdevol },
                                             Factura.Proveedor.NitProveedor);*/
                                GenerarIngreso(Factura.Numero, dtpFecha.Value, saldoAdevol);
                                var dtTransacion = miBussinesFactura.DatosSaldoDeCliente
                                    (Factura.Proveedor.NitProveedor, false,
                                       new List<Ingreso>
                                       {
                                           new Ingreso
                                               {
                                                   Numero = Factura.Numero,
                                                   Relacion = totalFactura - (pagos + saldoDev),
                                                   Valor = saldoAdevol,
                                               }
                                       });

                                if (Convert.ToBoolean(AppConfiguracion.ValorSeccion("printCarteraCliente")))
                                {
                                    PrintEstadoCarteraPos
                                    (dtpFecha.Value, Factura.Proveedor.NitProveedor, dtCartera, dtTransacion);
                                }
                                else
                                {
                                    PrintEstadoCartera
                                    (dtpFecha.Value, Factura.Proveedor.NitProveedor, dtCartera, dtTransacion);
                                }

                            }
                            else
                            {
                                if (rta.Equals(DialogResult.No)) //Nota Crédito. cambio a Comprobante de saldo
                                {
                                    /*PrintEgreso(
                                        ReintegroEfectivo(Factura.Proveedor.NitProveedor, valorDevolucion), 
                                        Factura.Proveedor.NitProveedor);*/

                                    var miIngreso = GenerarSaldoCliente(
                                        Factura.Numero, Factura.Proveedor.NitProveedor, dtpFecha.Value, valorDevolucion);
                                    if (Convert.ToBoolean(AppConfiguracion.ValorSeccion("printNotaCreCliente")))
                                    {
                                        PrintSaldoClientePos(miIngreso, Factura.Proveedor.NitProveedor);
                                    }
                                    else
                                    {
                                        PrintSaldoCliente(miIngreso, Factura.Proveedor.NitProveedor);
                                    }

                                    /*PrintSaldoCliente(
                                    GenerarSaldoCliente(
                                        Factura.Numero, Factura.Proveedor.NitProveedor, dtpFecha.Value, valorDevolucion),
                                        Factura.Proveedor.NitProveedor);*/

                                    //*****************
                                    var egreso = ReintegroEfectivo(Factura.Proveedor.NitProveedor, valorDevolucion);
                                    if (Convert.ToBoolean(AppConfiguracion.ValorSeccion("printEgresoDevVenta")))
                                    {
                                        PrintEgresoPos(egreso.Numero, miBussinesEgreso.EgresoPuc(egreso.Id));
                                    }
                                    else
                                    {
                                        PrintEgreso(egreso, Factura.Proveedor.NitProveedor);
                                    }
                                    /*PrintEgreso(
                                        ReintegroEfectivo(Factura.Proveedor.NitProveedor, valorDevolucion),
                                        Factura.Proveedor.NitProveedor);*/
                                    valorDevolucion = 0;
                                }
                                else
                                {
                                    if (rta.Equals(DialogResult.Retry)) //Devolución de Dinero.
                                    {
                                        var egreso = ReintegroEfectivo(Factura.Proveedor.NitProveedor, valorDevolucion);
                                        if (Convert.ToBoolean(AppConfiguracion.ValorSeccion("printEgresoDevVenta")))
                                        {
                                            PrintEgresoPos(egreso.Numero, miBussinesEgreso.EgresoPuc(egreso.Id));
                                        }
                                        else
                                        {
                                            PrintEgreso(egreso, Factura.Proveedor.NitProveedor);
                                        }
                                        /*var retiro = new DTO.Clases.Retiro();
                                        retiro.Fecha = DateTime.Now;
                                        retiro.Caja.Id = Convert.ToInt32(AppConfiguracion.ValorSeccion("id_caja"));
                                        retiro.Turno.Id = Convert.ToInt32(AppConfiguracion.ValorSeccion("idturno"));
                                        retiro.Usuario.Id = Convert.ToInt32(AppConfiguracion.ValorSeccion("id_user"));
                                        retiro.Valores.Add(new DTO.Clases.FormaPago
                                        {
                                            IdFormaPago = 1,
                                            NombreFormaPago = "EFECTIVO",
                                            NumeroFactura = "DEVOLUCIÓN A CLIENTE",
                                            Valor = valorDevolucion
                                        });
                                        miBussinesRetiro.Ingresar(retiro);
                                        PrintRetiroPos(retiro);*/
                                        /*PrintEgreso(
                                            ReintegroEfectivo(Factura.Proveedor.NitProveedor, valorDevolucion),
                                            Factura.Proveedor.NitProveedor);*/
                                        valorDevolucion = 0;
                                    }
                                    else
                                    {
                                        if (rta.Equals(DialogResult.Ignore)) //Descto a Saldo del Cliente.
                                        {
                                            var dtCartera = miBussinesFactura.DatosSaldoDeCliente
                                                    (Factura.Proveedor.NitProveedor, true, new List<Ingreso>());
                                            var valorIng = valorDevolucion;
                                            var lstFacturas = AbonoGeneralAcliente(Factura.Proveedor.NitProveedor, ref valorDevolucion, dtpFecha.Value);
                                            //PrintEgreso( ReintegroEfectivo(Factura.Proveedor.NitProveedor, va

                                            var egreso = ReintegroEfectivo(Factura.Proveedor.NitProveedor, valorIng - valorDevolucion);
                                            if (Convert.ToBoolean(AppConfiguracion.ValorSeccion("printEgresoDevVenta")))
                                            {
                                                PrintEgresoPos(egreso.Numero, miBussinesEgreso.EgresoPuc(egreso.Id));
                                            }
                                            else
                                            {
                                                PrintEgreso(egreso, Factura.Proveedor.NitProveedor);
                                            }

                                            //printIngreso
                                            var ingreso = GenerarIngreso(lstFacturas, dtpFecha.Value);
                                            if (Convert.ToBoolean(AppConfiguracion.ValorSeccion("printIngreso")))
                                            {
                                                PrintIngresoPos(ingreso.Numero);
                                            }
                                            else
                                            {
                                                PrintIngreso(ingreso,
                                                             new DTO.Clases.FormaPago { IdFormaPago = 1, Valor = (valorIng - valorDevolucion) },
                                                             Factura.Proveedor.NitProveedor);
                                            }
                                            /* PrintIngreso(GenerarIngreso(lstFacturas, dtpFecha.Value),
                                                           new DTO.Clases.FormaPago { IdFormaPago = 1, Valor = (valorIng - valorDevolucion) },
                                                           Factura.Proveedor.NitProveedor);*/

                                            var dtTransacion = miBussinesFactura.DatosSaldoDeCliente
                                                                (Factura.Proveedor.NitProveedor, false, lstFacturas);

                                            if (Convert.ToBoolean(AppConfiguracion.ValorSeccion("printCarteraCliente")))
                                            {
                                                PrintEstadoCarteraPos
                                                (dtpFecha.Value, Factura.Proveedor.NitProveedor, dtCartera, dtTransacion);
                                            }
                                            else
                                            {
                                                PrintEstadoCartera
                                                (dtpFecha.Value, Factura.Proveedor.NitProveedor, dtCartera, dtTransacion);
                                            }
                                            /*PrintEstadoCartera
                                                    (dtpFecha.Value, Factura.Proveedor.NitProveedor, dtCartera, dtTransacion);*/
                                            //estado de cartera
                                        }
                                        else
                                        {
                                            if (rta.Equals(DialogResult.Cancel))
                                            {
                                                valorDevolucion = 0;
                                            }
                                        }
                                    }
                                }
                            }
                        }
                        //generar comp de devol
                        if (!rta.Equals(DialogResult.Cancel))
                        {
                            var devolucion = new FacturaProveedor();
                            devolucion.Numero = miBussinesConsecutivos.Consecutivo("DevolucionVenta");
                            devolucion.NumeroEdit = txtNumeroFactura.Text;
                            if (Factura != null)
                            {
                                devolucion.Proveedor.NitProveedor = Factura.Proveedor.NitProveedor;
                            }
                            else
                            {
                                devolucion.Proveedor.NitProveedor = "1000";
                            }
                            devolucion.FechaIngreso = dtpFecha.Value;
                            devolucion.Usuario.Id = IdUsuario;
                            devolucion.Caja.Id = IdCaja;
                            devolucion.Turno.Id = Convert.ToInt32(AppConfiguracion.ValorSeccion("idturno"));
                            devolucion.DevolucionEfectivo = this.DevolucionEfectivo;
                            foreach (DataRow row in miTabla.Rows)
                            {
                                var detalle = new ProductoFacturaProveedor();
                                detalle.Inventario.CodigoProducto = row["Codigo"].ToString();
                                detalle.Inventario.IdMedida = Convert.ToInt32(row["IdMedida"]);
                                detalle.Inventario.IdColor = Convert.ToInt32(row["IdColor"]);
                                detalle.Producto.IdTipoInventario = Convert.ToInt32(row["IdTipoInventario"]);
                                detalle.Producto.ValorCosto = Convert.ToDouble(row["ValorUnitario"]);
                                detalle.Producto.Descuento = UseObject.RemoveCharacter(row["Descuento"].ToString(), '%');
                                detalle.Producto.ValorIva = UseObject.RemoveCharacter(row["Iva"].ToString(), '%');
                                detalle.Producto.Impoconsumo = Convert.ToDouble(row["Impoconsumo"]);
                                detalle.Inventario.Cantidad = Convert.ToDouble(row["Cantidad"]);
                                devolucion.Productos.Add(detalle);
                            }
                            miBussinesDevolucion.IngresarVenta(devolucion);
                            /*var lstId = new List<int>();
                            foreach (DataRow row in miTabla.Rows)
                            {
                                var devolucion = new DTO.Clases.Devolucion();
                                devolucion.Factura = Factura.Numero;
                                devolucion.Producto.CodigoProducto = row["Codigo"].ToString();
                                devolucion.Fecha = DateTime.Today;
                                devolucion.Valor = Convert.ToInt32(row["ValorUnitario"]);
                                devolucion.Cantidad = Convert.ToDouble(row["Cantidad"]);
                                devolucion.Iva = UseObject.RemoveCharacter(row["Iva"].ToString(), '%');//Convert.ToDouble(row["Iva"]);
                                devolucion.Producto.IdMedida = Convert.ToInt32(row["IdMedida"]);
                                devolucion.Producto.IdColor = Convert.ToInt32(row["IdColor"]);
                                devolucion.Descuento = Factura.AplicaDescuento;
                                devolucion.Descto = UseObject.RemoveCharacter(row["Descuento"].ToString(), '%'); //Convert.ToDouble(row["Descuento"]);
                                devolucion.IdUsuario = IdUsuario;
                                devolucion.IdCaja = IdCaja;
                                lstId.Add(miBussinesDevolucion.IngresarVenta(devolucion));
                                
                            }
                            var consecutivo = miBussinesDevolucion.GetConsecutivoVenta();
                            foreach (int id in lstId)
                            {
                                miBussinesDevolucion.IngresarConsecutivoVenta(consecutivo, id);
                            }*/
                            // miBussinesDevolucion.ActualizarConsecutivoVenta();
                            OptionPane.MessageInformation("La devolución se realizó correctamente.");
                            var reintegro = 0;
                            if (totalFacturaR > (pagosR + saldoDevR))
                            {
                                reintegro = Convert.ToInt32
                                            (
                                            miTabla.AsEnumerable().Sum(s => s.Field<double>("Valor"))
                                            ) -
                                            (totalFacturaR - (pagosR + saldoDevR));
                            }
                            else
                            {
                                reintegro = Convert.ToInt32
                                            (
                                            miTabla.AsEnumerable().Sum(s => s.Field<double>("Valor"))
                                            );
                            }
                            var credito = totalFacturaR - (pagosR + saldoDevR);
                            if (credito < 0)
                            {
                                credito = 0;
                            }

                            if (Convert.ToBoolean(AppConfiguracion.ValorSeccion("printCompDevolVenta")))
                            {
                                PrintComprobanteDevolucionPos(devolucion.Numero);
                            }
                            else
                            {
                                PrintComprobanteDevolucion(devolucion.Numero);
                            }

                            //PrintComprobanteDevolucion(devolucion.Numero);
                            /* PrintComprobanteDevolucion(consecutivo.ToString(),
                                                        Factura.Numero,
                                                        totalFacturaR,
                                                        Factura.Proveedor.NitProveedor,
                                                        credito,
                                                        Convert.ToInt32
                                                         (
                                                         miTabla.AsEnumerable().Sum(s => s.Field<double>("Valor"))
                                                         ),
                                                         reintegro);*/


                            /* if (rta.Equals(DialogResult.No) || rta.Equals(DialogResult.Ignore))
                             //if (!rta.Equals(DialogResult.Retry) )//&& !rta.Equals(DialogResult.Yes))
                             {
                                 PrintEgreso(ReintegroEfectivo(Factura.Proveedor.NitProveedor,
                                                               Convert.ToInt32
                                                                 (
                                                                 miTabla.AsEnumerable().Sum(s => s.Field<double>("Valor"))
                                                                 )),
                                             Factura.Proveedor.NitProveedor);
                             }*/
                            LimpiarCamposNewDevolucion();
                        }
                    }
                    catch (Exception ex)
                    {
                        OptionPane.MessageError(ex.Message);
                    }
                }
            }
            else
            {
                OptionPane.MessageInformation("No hay registro de productos para devolver.");
            }
        }

        private void DevolucionSinFactura()
        {
            try
            {
                var valorDevolucion = Convert.ToInt32
                                          (
                                            miTabla.AsEnumerable().Sum(s => s.Field<double>("Valor"))
                                          );
                var frmDevolucionEgreso = new FrmDevolucionEgreso();
                frmDevolucionEgreso.txtTotalDevolucion.Text = UseObject.InsertSeparatorMil(valorDevolucion.ToString());
                DialogResult rta = frmDevolucionEgreso.ShowDialog();
                ///var j = 1;
                while (rta.Equals(DialogResult.Yes) && nitC.Equals(""))
                {
                    rta = frmDevolucionEgreso.ShowDialog();
                }
                if (!rta.Equals(DialogResult.Cancel))
                {
                    var devolucion = new FacturaProveedor();
                    devolucion.Numero = miBussinesConsecutivos.Consecutivo("DevolucionVenta");
                    devolucion.NumeroEdit = txtNumeroFactura.Text;
                    if (Factura != null)
                    {
                        devolucion.Proveedor.NitProveedor = Factura.Proveedor.NitProveedor;
                    }
                    else
                    {
                        devolucion.Proveedor.NitProveedor = "1000";
                    }
                    devolucion.FechaIngreso = dtpFecha.Value;
                    devolucion.Usuario.Id = IdUsuario;
                    devolucion.Caja.Id = IdCaja;
                    devolucion.Turno.Id = Convert.ToInt32(AppConfiguracion.ValorSeccion("idturno"));
                    devolucion.DevolucionEfectivo = valorDevolucion;
                    foreach (DataRow row in miTabla.Rows)
                    {
                        var detalle = new ProductoFacturaProveedor();
                        detalle.Inventario.CodigoProducto = row["Codigo"].ToString();
                        detalle.Inventario.IdMedida = Convert.ToInt32(row["IdMedida"]);
                        detalle.Inventario.IdColor = Convert.ToInt32(row["IdColor"]);
                        detalle.Producto.IdTipoInventario = Convert.ToInt32(row["IdTipoInventario"]);
                        detalle.Producto.ValorCosto = Convert.ToDouble(row["ValorUnitario"]);
                        detalle.Producto.Descuento = UseObject.RemoveCharacter(row["Descuento"].ToString(), '%');
                        detalle.Producto.ValorIva = UseObject.RemoveCharacter(row["Iva"].ToString(), '%');
                        detalle.Inventario.Cantidad = Convert.ToDouble(row["Cantidad"]);
                        detalle.Producto.Impoconsumo = Convert.ToDouble(row["Impoconsumo"]);
                        devolucion.Productos.Add(detalle);
                    }
                    miBussinesDevolucion.IngresarVenta(devolucion);
                    nitC = "";
                    OptionPane.MessageInformation("La devolución se realizó correctamente.");

                    if (Convert.ToBoolean(AppConfiguracion.ValorSeccion("printCompDevolVenta")))
                    {
                        PrintComprobanteDevolucionPos(devolucion.Numero);
                    }
                    else
                    {
                        PrintComprobanteDevolucion(devolucion.Numero);
                    }
                    LimpiarCamposNewDevolucion();
                }

                /*if (rta.Equals(DialogResult.Yes))
                {

                }*/
                /*
                // this line of limit
                //
                //
                //
                var valorDevolucion = Convert.ToInt32
                                          (
                                            miTabla.AsEnumerable().Sum(s => s.Field<double>("Valor"))
                                          );
                
                //valorDevolucion = 0;
                var devolucion = new FacturaProveedor();
                devolucion.Numero = miBussinesConsecutivos.Consecutivo("DevolucionVenta");
                devolucion.NumeroEdit = txtNumeroFactura.Text;
                if (Factura != null)
                {
                    devolucion.Proveedor.NitProveedor = Factura.Proveedor.NitProveedor;
                }
                else
                {
                    devolucion.Proveedor.NitProveedor = "1000";
                }
                devolucion.FechaIngreso = dtpFecha.Value;
                devolucion.Usuario.Id = IdUsuario;
                devolucion.Caja.Id = IdCaja;
                foreach (DataRow row in miTabla.Rows)
                {
                    var detalle = new ProductoFacturaProveedor();
                    detalle.Inventario.CodigoProducto = row["Codigo"].ToString();
                    detalle.Inventario.IdMedida = Convert.ToInt32(row["IdMedida"]);
                    detalle.Inventario.IdColor = Convert.ToInt32(row["IdColor"]);
                    detalle.Producto.ValorCosto = Convert.ToInt32(row["ValorUnitario"]);
                    detalle.Producto.Descuento = UseObject.RemoveCharacter(row["Descuento"].ToString(), '%');
                    detalle.Producto.ValorIva = UseObject.RemoveCharacter(row["Iva"].ToString(), '%');
                    detalle.Inventario.Cantidad = Convert.ToDouble(row["Cantidad"]);
                    devolucion.Productos.Add(detalle);
                }
                miBussinesDevolucion.IngresarVenta(devolucion);
                nitC = "";
                OptionPane.MessageInformation("La devolución se realizó correctamente.");

                if (Convert.ToBoolean(AppConfiguracion.ValorSeccion("printCompDevolVenta")))
                {
                    PrintComprobanteDevolucionPos(devolucion.Numero);
                }
                else
                {
                    PrintComprobanteDevolucion(devolucion.Numero);
                }

                var frmDevolucionEgreso = new FrmDevolucionEgreso();
                frmDevolucionEgreso.txtTotalDevolucion.Text = UseObject.InsertSeparatorMil(valorDevolucion.ToString());
                frmDevolucionEgreso.ShowDialog();*/
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
        }

        // Metodo de guardado anterior.
        /*private void tsBtnGuardar_Click(object sender, EventArgs e)
        {
            List<object> comprobantes = new List<object>();
            miError.SetError(txtCantidad, null);
            miError.SetError(txtCodigoArticulo, null);
            if (dgvListaArticulos.RowCount != 0)
            {
                DialogResult rta = MessageBox.Show("¿Está seguro(a) de realizar la devolución?", "Devolución",
                            MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (rta.Equals(DialogResult.Yes))
                {
                    try
                    {
                        /*foreach (DataRow row in miTabla.Rows)
                        {
                            var devolucion = new DTO.Clases.Devolucion();
                            devolucion.Factura = Factura.Numero;
                            devolucion.Producto.CodigoProducto = row["Codigo"].ToString();
                            devolucion.Fecha = DateTime.Today;
                            devolucion.Valor = Convert.ToInt32(row["ValorUnitario"]);
                            devolucion.Cantidad = Convert.ToDouble(row["Cantidad"]);
                            devolucion.Iva = UseObject.RemoveCharacter(row["Iva"].ToString(), '%');//Convert.ToDouble(row["Iva"]);
                            devolucion.Producto.IdMedida = Convert.ToInt32(row["IdMedida"]);
                            devolucion.Producto.IdColor = Convert.ToInt32(row["IdColor"]);
                            devolucion.Descuento = Factura.AplicaDescuento;
                            devolucion.Descto = UseObject.RemoveCharacter(row["Descuento"].ToString(), '%'); //Convert.ToDouble(row["Descuento"]);
                            devolucion.IdUsuario = IdUsuario;
                            devolucion.IdCaja = IdCaja;
                            miBussinesDevolucion.IngresarVenta(devolucion);
                        }
                        var productos_ = miBussinesFactura.ProductoFacturaVenta(Factura.Numero, Factura.AplicaDescuento);
                        var totalFacturaR = Convert.ToInt32(productos_.AsEnumerable().Sum(s => s.Field<double>("Valor")));

                        var bussinesPago_ = new BussinesFormaPago();
                        var pagosR = bussinesPago_.GetTotalFormasDePagoDeFacturaVenta(Factura.Numero);

                        var saldoDevR = miBussinesDevolucion.SaldoDevolucionVenta(Factura.Numero);

                        var valorDevolucion = Convert.ToInt32
                                          (
                                            miTabla.AsEnumerable().Sum(s => s.Field<double>("Valor"))
                                          );
                        while (valorDevolucion != 0)
                        {
                            var productos = miBussinesFactura.ProductoFacturaVenta(Factura.Numero, Factura.AplicaDescuento);
                            var totalFactura = Convert.ToInt32(productos.AsEnumerable().Sum(s => s.Field<double>("Valor")));

                            var bussinesPago = new BussinesFormaPago();
                            var pagos = bussinesPago.GetTotalFormasDePagoDeFacturaVenta(Factura.Numero);

                            var saldoDev = miBussinesDevolucion.SaldoDevolucionVenta(Factura.Numero);

                            var frmResumenDev = new FrmDatosDevolucion();
                            var contado = true;
                            var saldoCliente = miBussinesFactura.SaldoPorCliente(2, Factura.Proveedor.NitProveedor);

                            if (Factura.EstadoFactura.Id.Equals(1) ||
                                (totalFactura <= (pagos + saldoDev)))//contado o credito pagado
                            {
                                if (saldoCliente == 0)
                                {
                                    frmResumenDev.gbDesctoGlobal.Enabled = false;
                                }
                                frmResumenDev.gbAbonoFact.Enabled = false;
                                contado = true;
                            }
                            else//credito y pendiente
                            {
                                frmResumenDev.gbCobro.Enabled = false;
                                frmResumenDev.gbDesctoGlobal.Enabled = false;
                                frmResumenDev.gbSaldoCliente.Enabled = false;
                                contado = false;
                            }
                            if (Factura.EstadoFactura.Id.Equals(1))
                            {
                                frmResumenDev.txtPago.Text = "CONTADO";
                            }
                            else
                            {
                                frmResumenDev.txtPago.Text = "CRÉDITO";
                            }
                            frmResumenDev.txtNoFactura.Text = Factura.Numero;
                            frmResumenDev.txtTotal.Text = UseObject.InsertSeparatorMil(totalFactura.ToString());
                            if (Factura.EstadoFactura.Id.Equals(1))
                            {
                                frmResumenDev.txtAbonos.Text = UseObject.InsertSeparatorMil(totalFactura.ToString());
                            }
                            else
                            {
                                frmResumenDev.txtAbonos.Text = UseObject.InsertSeparatorMil(pagos.ToString());
                            }
                            frmResumenDev.txtDevoluciones.Text = UseObject.InsertSeparatorMil(saldoDev.ToString());
                            if (UseObject.RemoveSeparatorMil(frmResumenDev.txtTotal.Text) <=
                                (UseObject.RemoveSeparatorMil(frmResumenDev.txtAbonos.Text) +
                                    UseObject.RemoveSeparatorMil(frmResumenDev.txtDevoluciones.Text)))
                            {
                                frmResumenDev.txtResta.Text = "0";
                            }
                            else
                            {
                                frmResumenDev.txtResta.Text = UseObject.InsertSeparatorMil(
                                    (UseObject.RemoveSeparatorMil(frmResumenDev.txtTotal.Text) -
                                        (UseObject.RemoveSeparatorMil(frmResumenDev.txtAbonos.Text) +
                                            UseObject.RemoveSeparatorMil(frmResumenDev.txtDevoluciones.Text))).
                                     ToString());
                            }
                            frmResumenDev.txtTotalDevolucion.Text = UseObject.InsertSeparatorMil(valorDevolucion.ToString());
                            if (Factura.EstadoFactura.Id.Equals(1))
                            {
                                frmResumenDev.txtReintegro.Text = "0";
                            }
                            else
                            {
                                if ((valorDevolucion - (totalFactura - (pagos + saldoDev))) > 0)
                                {
                                    frmResumenDev.txtReintegro.Text =
                                        UseObject.InsertSeparatorMil((valorDevolucion -
                                                                     (totalFactura - (pagos + saldoDev))).ToString());
                                }
                                else
                                {
                                    frmResumenDev.txtReintegro.Text = "0";
                                }
                            }

                            rta = frmResumenDev.ShowDialog();

                            if (rta.Equals(DialogResult.Yes)) //Descuento a Factura.
                            {
                                //Descuento a factura actual
                                var dtCartera = miBussinesFactura.DatosSaldoDeCliente
                                    (Factura.Proveedor.NitProveedor, true, new List<Ingreso>());
                                var saldoAdevol = 0;
                                if (valorDevolucion < (totalFactura - (pagos + saldoDev)))
                                {
                                    //miBussinesDevolucion.IngresarSaldoDevolucionVenta(Factura.Numero, valorDevolucion);
                                    saldoAdevol = valorDevolucion;
                                    valorDevolucion = 0;
                                }
                                else
                                {
                                    //miBussinesDevolucion.IngresarSaldoDevolucionVenta(Factura.Numero, totalFactura - (pagos + saldoDev));
                                    saldoAdevol = totalFactura - (pagos + saldoDev);
                                    valorDevolucion = valorDevolucion - (totalFactura - (pagos + saldoDev));
                                }
                                GenerarIngreso(Factura.Numero, dtpFecha.Value, saldoAdevol);
                                var dtTransacion = miBussinesFactura.DatosSaldoDeCliente
                                    (Factura.Proveedor.NitProveedor, false,
                                       new List<Ingreso>
                                       {
                                           new Ingreso
                                               {
                                                   Numero = Factura.Numero,
                                                   Relacion = totalFactura - (pagos + saldoDev),
                                                   Valor = saldoAdevol,
                                               }
                                       });
                                PrintEstadoCartera
                                    (dtpFecha.Value, Factura.Proveedor.NitProveedor, dtCartera, dtTransacion);
                            }
                            else
                            {
                                if (rta.Equals(DialogResult.No)) //Nota Crédito. cambio a Comprobante de saldo
                                {
                                    PrintSaldoCliente(
                                    GenerarSaldoCliente(
                                        Factura.Numero, Factura.Proveedor.NitProveedor, dtpFecha.Value, valorDevolucion),
                                        Factura.Proveedor.NitProveedor);
                                    valorDevolucion = 0;
                                }
                                else
                                {
                                    if (rta.Equals(DialogResult.Retry)) //Devolución de Dinero.
                                    {
                                        PrintEgreso(
                                            ReintegroEfectivo(Factura.Proveedor.NitProveedor, valorDevolucion),
                                            Factura.Proveedor.NitProveedor);
                                        valorDevolucion = 0;
                                    }
                                    else
                                    {
                                        if (rta.Equals(DialogResult.Ignore)) //Descto a Saldo del Cliente.
                                        {
                                            var dtCartera = miBussinesFactura.DatosSaldoDeCliente
                                                    (Factura.Proveedor.NitProveedor, true, new List<Ingreso>());
                                            var valorIng = valorDevolucion;
                                            var lstFacturas = AbonoGeneralAcliente(Factura.Proveedor.NitProveedor, ref valorDevolucion, dtpFecha.Value);
                                            //PrintEgreso( ReintegroEfectivo(Factura.Proveedor.NitProveedor, va
                                            PrintEgreso(ReintegroEfectivo(Factura.Proveedor.NitProveedor, valorIng - valorDevolucion),
                                                         Factura.Proveedor.NitProveedor);
                                            PrintIngreso(GenerarIngreso(lstFacturas, dtpFecha.Value),
                                                          new DTO.Clases.FormaPago { IdFormaPago = 1, Valor = (valorIng - valorDevolucion) },
                                                          Factura.Proveedor.NitProveedor);

                                            var dtTransacion = miBussinesFactura.DatosSaldoDeCliente
                                                                (Factura.Proveedor.NitProveedor, false, lstFacturas);
                                            PrintEstadoCartera
                                                    (dtpFecha.Value, Factura.Proveedor.NitProveedor, dtCartera, dtTransacion);
                                            //estado de cartera
                                        }
                                        else
                                        {
                                            if (rta.Equals(DialogResult.Cancel))
                                            {
                                                valorDevolucion = 0;
                                            }
                                        }
                                    }
                                }
                            }
                        }
                        //generar comp de devol
                        if (!rta.Equals(DialogResult.Cancel))
                        {
                            var devolucion = new FacturaProveedor();
                            devolucion.Numero = miBussinesConsecutivos.Consecutivo("DevolucionVenta");
                            devolucion.NumeroEdit = txtNumeroFactura.Text;
                            if (Factura != null)
                            {
                                devolucion.Proveedor.NitProveedor = Factura.Proveedor.NitProveedor;
                            }
                            else
                            {
                                devolucion.Proveedor.NitProveedor = "1000";
                            }
                            devolucion.FechaIngreso = dtpFecha.Value;
                            devolucion.Usuario.Id = IdUsuario;
                            devolucion.Caja.Id = IdCaja;
                            foreach (DataRow row in miTabla.Rows)
                            {
                                var detalle = new ProductoFacturaProveedor();
                                detalle.Inventario.CodigoProducto = row["Codigo"].ToString();
                                detalle.Inventario.IdMedida = Convert.ToInt32(row["IdMedida"]);
                                detalle.Inventario.IdColor = Convert.ToInt32(row["IdColor"]);
                                detalle.Producto.ValorCosto = Convert.ToInt32(row["ValorUnitario"]);
                                detalle.Producto.Descuento = UseObject.RemoveCharacter(row["Descuento"].ToString(), '%');
                                detalle.Producto.ValorIva = UseObject.RemoveCharacter(row["Iva"].ToString(), '%');
                                detalle.Inventario.Cantidad = Convert.ToDouble(row["Cantidad"]);
                                devolucion.Productos.Add(detalle);
                            }
                            miBussinesDevolucion.IngresarVenta(devolucion);
                            var lstId = new List<int>();
                            foreach (DataRow row in miTabla.Rows)
                            {
                                var devolucion = new DTO.Clases.Devolucion();
                                devolucion.Factura = Factura.Numero;
                                devolucion.Producto.CodigoProducto = row["Codigo"].ToString();
                                devolucion.Fecha = DateTime.Today;
                                devolucion.Valor = Convert.ToInt32(row["ValorUnitario"]);
                                devolucion.Cantidad = Convert.ToDouble(row["Cantidad"]);
                                devolucion.Iva = UseObject.RemoveCharacter(row["Iva"].ToString(), '%');//Convert.ToDouble(row["Iva"]);
                                devolucion.Producto.IdMedida = Convert.ToInt32(row["IdMedida"]);
                                devolucion.Producto.IdColor = Convert.ToInt32(row["IdColor"]);
                                devolucion.Descuento = Factura.AplicaDescuento;
                                devolucion.Descto = UseObject.RemoveCharacter(row["Descuento"].ToString(), '%'); //Convert.ToDouble(row["Descuento"]);
                                devolucion.IdUsuario = IdUsuario;
                                devolucion.IdCaja = IdCaja;
                                lstId.Add(miBussinesDevolucion.IngresarVenta(devolucion));
                                
                            }
                            var consecutivo = miBussinesDevolucion.GetConsecutivoVenta();
                            foreach (int id in lstId)
                            {
                                miBussinesDevolucion.IngresarConsecutivoVenta(consecutivo, id);
                            }
                           // miBussinesDevolucion.ActualizarConsecutivoVenta();
                            OptionPane.MessageInformation("La devolución se realizó correctamente.");
                            var reintegro = 0;
                            if (totalFacturaR > (pagosR + saldoDevR))
                            {
                                reintegro = Convert.ToInt32
                                            (
                                            miTabla.AsEnumerable().Sum(s => s.Field<double>("Valor"))
                                            ) -
                                            (totalFacturaR - (pagosR + saldoDevR));
                            }
                            else
                            {
                                reintegro = Convert.ToInt32
                                            (
                                            miTabla.AsEnumerable().Sum(s => s.Field<double>("Valor"))
                                            );
                            }
                            var credito = totalFacturaR - (pagosR + saldoDevR);
                            if (credito < 0)
                            {
                                credito = 0;
                            }

                            PrintComprobanteDevolucion(devolucion.Numero);
                            PrintComprobanteDevolucion(consecutivo.ToString(),
                                                       Factura.Numero,
                                                       totalFacturaR,
                                                       Factura.Proveedor.NitProveedor,
                                                       credito,
                                                       Convert.ToInt32
                                                        (
                                                        miTabla.AsEnumerable().Sum(s => s.Field<double>("Valor"))
                                                        ),
                                                        reintegro);


                            if(rta.Equals(DialogResult.No) || rta.Equals(DialogResult.Ignore))
                            //if (!rta.Equals(DialogResult.Retry) )//&& !rta.Equals(DialogResult.Yes))
                            {
                                PrintEgreso(ReintegroEfectivo(Factura.Proveedor.NitProveedor,
                                                              Convert.ToInt32
                                                                (
                                                                miTabla.AsEnumerable().Sum(s => s.Field<double>("Valor"))
                                                                )),
                                            Factura.Proveedor.NitProveedor);
                            }
                            LimpiarCamposNewDevolucion();
                        }
                    }
                    catch (Exception ex)
                    {
                        OptionPane.MessageError(ex.Message);
                    }
                }
            }
            else
            {
                OptionPane.MessageInformation("No hay registro de productos para devolver.");
            }
        }
        */

        

        private void txtNumeroFactura_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar.Equals((char)Keys.Enter))
            {
                // txtNumeroFactura_Validating(this.txtNumeroFactura, new CancelEventArgs(false));
                if (!String.IsNullOrEmpty(txtNumeroFactura.Text))
                {
                    if (Validacion.ConFormato
                         (Validacion.TipoValidacion.LetrasGuionNumeros, txtNumeroFactura, miError, FacturaFormat))
                    {
                        if (CargarFactura(txtNumeroFactura.Text))
                        {
                            miError.SetError(txtNumeroFactura, null);
                            txtCantidad.Focus();
                        }
                    }
                    else
                    {
                        miError.SetError(txtNumeroFactura, FacturaLoad);
                        txtNumeroFactura.Focus();
                    }
                }
                else
                {
                    txtCantidad.Focus();
                }
            }
        }

        private void txtNumeroFactura_Validating(object sender, CancelEventArgs e)
        {
            //if (!Validacion.EsVacio(txtNumeroFactura, miError, ""))
            // {
            /* if (Validacion.ConFormato
                 (Validacion.TipoValidacion.LetrasGuionNumeros, txtNumeroFactura, miError, FacturaFormat))
             {*/
            /*  if (CargarFactura(txtNumeroFactura.Text))
              {
                  miError.SetError(txtNumeroFactura, null);
                  txtCantidad.Focus();
              }
              else
              {
                  miError.SetError(txtNumeroFactura, FacturaLoad);
                  txtNumeroFactura.Focus();
              }*/
            /* }
             else
             {
                 //txtNumeroFactura.Focus();
             }*/
            /*}
            else
            {
                txtCantidad.Focus();
            }*/
        }

        private void btnFactura_Click(object sender, EventArgs e)
        {
            if (!FormExtend)
            {
                var frmConsulta = new Factura.FrmConsulta();
                frmConsulta.Usuario_ = this.Usuario_;
                frmConsulta.Extend = true;
                //frmConsulta.MdiParent = this.MdiParent;
                FormExtend = true;
                frmConsulta.ShowDialog();
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
                                        //Validacion...

                                        txtDescuento.Focus();
                                        txtDescuento.SelectAll();
                                    }
                                }
                                else
                                {
                                    //validar producto de factura.
                                    txtDescuento.Focus();
                                    txtDescuento.SelectAll();
                                }

                                if (!btnTallaYcolor.Enabled)
                                {
                                    txtDescuento.Focus();
                                    txtDescuento.SelectAll();
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
                        var formInventario = new Inventario.Consulta.FrmConsultaInventario();
                        // formInventario.MdiParent = this.MdiParent;
                        formInventario.ExtendVenta = true;
                        formInventario.txtCodigoNombre.Text = txtCodigoArticulo.Text;
                        formInventario.ShowDialog();
                        formInventario.dgvInventario.Focus();
                        formInventario.ColorearGrid();
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
                //EstructurarConsultaSinFactura();
                if (txtNumeroFactura.Text.Equals(""))
                {
                    EstructurarConsultaSinFactura();
                }
                else
                {
                    EstructurarConsultaConFactura();
                }
            }
        }

        private void cbDescuentoProducto_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar.Equals((char)Keys.Enter))
            {
                EstructurarConsultaConFactura();
            }
        }

        private void dgvListaArticulos_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            /*if (e.ColumnIndex.Equals(12) && !TotalMasIva.ReadOnly) // valor venta
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
                        var num = Convert.ToDouble(e.FormattedValue.ToString());
                        ActualizarInformacionNew(e.RowIndex, num.ToString(), iva_);
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
                            ActualizarInformacionCantidadNew(e.RowIndex, num.ToString());
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
            }*/




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
                        rta = MessageBox.Show("¿El valor que ingreso incluye IMPOCONSUMO?", "Devolución",
                            MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        var ico = false;
                        if (rta.Equals(DialogResult.Yes))
                        {
                            ico = true;
                        }
                        else
                        {
                            ico = false;
                        }
                        //ActualizarInformacion(e.RowIndex, e.FormattedValue.ToString(), iva_);
                        ActualizarInformacion(e.RowIndex, e.FormattedValue.ToString(), iva_, ico);
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
            lblDataFecha.Text = dtpFecha.Value.ToLongDateString();
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
            miTabla.Columns.Add(new DataColumn("ValorUnitario", typeof(double)));
            miTabla.Columns.Add(new DataColumn("Descuento", typeof(string)));
            miTabla.Columns.Add(new DataColumn("ValorMenosDescto", typeof(double)));
            miTabla.Columns.Add(new DataColumn("Iva", typeof(string)));
            miTabla.Columns.Add(new DataColumn("TotalMasIva", typeof(double)));
            miTabla.Columns.Add(new DataColumn("Impoconsumo", typeof(double)));

            miTabla.Columns.Add(new DataColumn("Valor", typeof(double)));
            miTabla.Columns.Add(new DataColumn("Unidad", typeof(string)));
            miTabla.Columns.Add(new DataColumn("IdMedida", typeof(int)));
            miTabla.Columns.Add(new DataColumn("Medida", typeof(string)));
            miTabla.Columns.Add(new DataColumn("IdColor", typeof(int)));
            miTabla.Columns.Add(new DataColumn("Color", typeof(Image)));

            miTabla.Columns.Add(new DataColumn("IdTipoInventario", typeof(int)));
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
                txtDescuento.Focus();
                txtDescuento.SelectAll();
                /* if (cbDescuentoProducto.Enabled)
                 {
                     cbDescuentoProducto.Focus();
                 }
                 else
                 {
                     EstructurarConsultaConFactura();
                 }*/
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
                var n = args.MiBodegabo.ToString();
                GuardaSeguimientoBono(GuardarBono(n, false), false, "");
                Factura.Proveedor.NitProveedor = n;
                EditarClienteFactura(Factura);
                OptionPane.MessageInformation("El saldo se guardó con éxito, y está a favor del cliente seleccionado.");
                LimpiarCamposNewDevolucion();
            }
            catch { }
        }

        void CompletaEventos_Completaeb(CompletaArgumentosDeEventoeb args)
        {
            try
            {
                var cliente = (DTO.Clases.Cliente)args.MiBodegaeb;
                nitC = cliente.NitCliente;
                /*var valorDevolucion = Convert.ToInt32
                                          (
                                            miTabla.AsEnumerable().Sum(s => s.Field<double>("Valor"))
                                          );
                PrintEgreso(ReintegroEfectivo(cliente.NitCliente, valorDevolucion), cliente.NitCliente);*/
                //LimpiarCamposNewDevolucion();
            }
            catch
            {
                try
                {
                    /*var num = Convert.ToInt32(args.MiBodegaeb);
                    if (num.Equals(2001))
                    {
                        LimpiarCamposNewDevolucion();
                    }*/
                }
                catch { }
            }
        }

        void CompletaEventos_CompTProductoFact(CompletaTransferProductFact args)
        {
            try
            {
                var producto = (Producto)args.MiObjeto;
                txtCodigoArticulo.Text = producto.CodigoInternoProducto;
                //DesctoAplica = producto.Descuento;
                txtCodigoArticulo_KeyPress(this.txtCodigoArticulo, new KeyPressEventArgs((char)Keys.Enter));
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
                var tabla = miBussinesFactura.ConsultaNumero(numero);
                if (tabla.Rows.Count != 0)
                {
                    var qRow = (from data in tabla.AsEnumerable()
                                select data).Single();
                    Factura = new FacturaVenta();
                    Factura.Id = Convert.ToInt32(qRow["id"]);
                    Factura.Numero = numero;
                    Factura.AplicaDescuento = Convert.ToBoolean(qRow["descto"]);
                    Factura.Proveedor.NitProveedor = qRow["nit"].ToString();
                    Factura.EstadoFactura.Id = Convert.ToInt32(qRow["idestado"]);
                    //var j = qRow["idestado"].ToString();
                    if (Convert.ToBoolean(qRow["descto"]))
                    {
                        cbDescuentoProducto.Enabled = true;
                    }
                    else
                    {
                        cbDescuentoProducto.Enabled = false;
                    }
                    Detalle = miBussinesFactura.Detalles(Factura.Id);
                    Devoluciones = miBussinesDevolucion.DevolucionesVenta(numero);
                    tabla.Clear();
                    tabla = null;
                    return true;
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
                return miBussinesFactura.ProductoDeFactura(idFactura, dProducto);
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
                if (MiProducto.IdTipoInventario.Equals(IdTipoInventarioProductoNoFabricado) ||
                    MiProducto.IdTipoInventario.Equals(IdTipoInventarioProductoFabricado))
                {
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
                    }
                }
                else
                {
                    OptionPane.MessageInformation("Este producto no se puede devolver.");
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
        private void EstructurarConsultaConFactura()
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
                        if (!ProductoDevuelto(detalle))
                        {
                            if (!ProductoRepeat(detalle))
                            {
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

                                row["IdTipoInventario"] = MiProducto.IdTipoInventario;

                                row["Id"] = Contador;
                                row["Codigo"] = MiProducto.CodigoInternoProducto;
                                row["Articulo"] = MiProducto.NombreProducto;
                                row["Cantidad"] = Convert.ToDouble(txtCantidad.Text);
                                //row["ValorUnitario"] = Convert.ToInt32(MiProducto.ValorVentaProducto / (1 + (MiProducto.ValorIva / 100)));
                                //2
                                //row["ValorUnitario"] = Math.Round((MiProducto.ValorVentaProducto / (1 + (MiProducto.ValorIva / 100))), 1);
                                if (miEmpresa.Regimen.IdRegimen.Equals(1))
                                {
                                    if (Convert.ToBoolean(AppConfiguracion.ValorSeccion("precio_venta_iva"))) // Precios incluye IVA
                                    {
                                        row["ValorUnitario"] = Math.Round(((MiProducto.ValorVentaProducto - Convert.ToInt32(MiProducto.Impoconsumo)) / (1 + (MiProducto.ValorIva / 100))), 1);
                                    }
                                    else
                                    {
                                        row["ValorUnitario"] = MiProducto.ValorVentaProducto - Convert.ToInt32(MiProducto.Impoconsumo);
                                        //row["ValorUnitario"] = MiProducto.ValorVentaProducto;
                                    }
                                }
                                else
                                {
                                    row["ValorUnitario"] = MiProducto.ValorVentaProducto - Convert.ToInt32(MiProducto.Impoconsumo);
                                }

                                var vun = row["ValorUnitario"].ToString();

                                row["Descuento"] = txtDescuento.Text + "%";
                                /*if (cbDescuentoProducto.Enabled)
                                {
                                    row["Descuento"] = txtDescuento.Text + "%";
                                }
                                else
                                {
                                    row["Descuento"] = "0%";
                                }*/
                                /*row["ValorMenosDescto"] = Convert.ToDouble(Convert.ToInt32(row["ValorUnitario"]) -
                                        (Convert.ToInt32(row["ValorUnitario"]) * UseObject.RemoveCharacter(row["Descuento"].ToString(), '%') / 100));*/
                                //2
                                row["ValorMenosDescto"] = Math.Round((Convert.ToDouble(row["ValorUnitario"]) -
                                    (Convert.ToDouble(row["ValorUnitario"]) * UseObject.RemoveCharacter(row["Descuento"].ToString(), '%') / 100)), 1);

                                var val_des = row["ValorMenosDescto"].ToString();

                                if (miEmpresa.Regimen.IdRegimen == 1)  //Comun
                                {
                                    row["Iva"] = MiProducto.ValorIva.ToString() + "%";
                                }
                                else
                                {
                                    row["Iva"] = 0 + "%";
                                }
                                /*row["TotalMasIva"] =
                                                      Convert.ToInt32((Convert.ToDouble(row["ValorMenosDescto"]) *
                                                      UseObject.RemoveCharacter(row["Iva"].ToString(), '%') / 100) +
                                                      Convert.ToDouble(row["ValorMenosDescto"]));

                                var totalmasiva = row["TotalMasIva"].ToString();*/
                                //2
                                double vIva = Math.Round((Convert.ToDouble(row["ValorMenosDescto"]) *
                                                          UseObject.RemoveCharacter(row["Iva"].ToString(), '%') / 100), 1);

                                var vUnitario = Convert.ToInt32(Convert.ToDouble(row["ValorMenosDescto"]) + vIva) + Convert.ToInt32(MiProducto.Impoconsumo);

                                // Edición precio producto  18 Feb 2017
                                //row["TotalMasIva"] = vUnitario;

                                if (this.RedondearPrecio2)
                                {
                                    row["TotalMasIva"] = UseObject.Aproximar(vUnitario, this.AproxPrecio);
                                }
                                else
                                {
                                    row["TotalMasIva"] = vUnitario;
                                }

                                // End edición

                                row["Impoconsumo"] = MiProducto.Impoconsumo;

                                row["Valor"] = Convert.ToInt32(
                                               Convert.ToDouble(row["TotalMasIva"]) /*Convert.ToDouble(row["TotalMasIva"])*/ *
                                               Convert.ToDouble(row["Cantidad"]));

                                var val = row["Valor"].ToString();

                                miTabla.Rows.Add(row);

                                var v = miTabla.AsEnumerable().Sum(s => s.Field<double>("Valor"));

                                txtTotal.Text = UseObject.InsertSeparatorMil
                                    (
                                       Convert.ToInt32(
                                       miTabla.AsEnumerable().Sum(s => s.Field<double>("Valor"))
                                       ).ToString()
                                    );
                                RecargarGridview();
                                LimpiarCampos();
                                btnTallaYcolor.Enabled = false;
                            }
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
                        }
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
            txtNumeroFactura.Enabled = false;
        }

        private void EstructurarConsultaSinFactura()
        {
            if (MiProducto != null)
            {
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

                row["IdTipoInventario"] = MiProducto.IdTipoInventario;

                row["Id"] = Contador;
                row["Codigo"] = MiProducto.CodigoInternoProducto;
                row["Articulo"] = MiProducto.NombreProducto;
                row["Cantidad"] = Convert.ToDouble(txtCantidad.Text.Replace('.', ','));

                if (miEmpresa.Regimen.IdRegimen.Equals(1))
                {
                    if (Convert.ToBoolean(AppConfiguracion.ValorSeccion("precio_venta_iva"))) // Precios incluye IVA
                    {
                        row["ValorUnitario"] = Math.Round(((MiProducto.ValorVentaProducto - Convert.ToInt32(MiProducto.Impoconsumo)) / (1 + (MiProducto.ValorIva / 100))), 1);
                    }
                    else
                    {
                        row["ValorUnitario"] = MiProducto.ValorVentaProducto - Convert.ToInt32(MiProducto.Impoconsumo);
                    }
                }
                else
                {
                    row["ValorUnitario"] = MiProducto.ValorVentaProducto - Convert.ToInt32(MiProducto.Impoconsumo);
                }
                //row["ValorUnitario"] = Convert.ToInt32(MiProducto.ValorVentaProducto / (1 + (MiProducto.ValorIva / 100)));

                var vun = row["ValorUnitario"].ToString();

                row["Descuento"] = txtDescuento.Text + "%";
                //var d = UseObject.RemoveCharacter(row["Descuento"].ToString(), '%');

                row["ValorMenosDescto"] = Convert.ToDouble(Convert.ToInt32(row["ValorUnitario"]) -
                        (Convert.ToInt32(row["ValorUnitario"]) * UseObject.RemoveCharacter(row["Descuento"].ToString(), '%') / 100));

                var val_des = row["ValorMenosDescto"].ToString();

                if (miEmpresa.Regimen.IdRegimen == 1)  //Comun
                {
                    row["Iva"] = MiProducto.ValorIva.ToString() + "%";
                }
                else
                {
                    row["Iva"] = 0 + "%";
                }

                // Edición precio producto  18 Feb 2017

               /* row["TotalMasIva"] =
                                      Convert.ToInt32((Convert.ToDouble(row["ValorMenosDescto"]) *
                                      UseObject.RemoveCharacter(row["Iva"].ToString(), '%') / 100) +
                                      Convert.ToDouble(row["ValorMenosDescto"]));*/
                /*int totalMasIva = Convert.ToInt32((Convert.ToDouble(row["ValorMenosDescto"]) *
                                  UseObject.RemoveCharacter(row["Iva"].ToString(), '%') / 100) +
                                  Convert.ToDouble(row["ValorMenosDescto"]));*/

                double vIva = Math.Round((Convert.ToDouble(row["ValorMenosDescto"]) *
                                          UseObject.RemoveCharacter(row["Iva"].ToString(), '%') / 100), 1);
                var vUnitario = Convert.ToInt32(Convert.ToDouble(row["ValorMenosDescto"]) + vIva) + Convert.ToInt32(MiProducto.Impoconsumo);

                if (this.RedondearPrecio2)
                {
                    row["TotalMasIva"] = UseObject.Aproximar(vUnitario, this.AproxPrecio);
                }
                else
                {
                    row["TotalMasIva"] = vUnitario;
                }

                row["Impoconsumo"] = MiProducto.Impoconsumo;

                // End edición

                //var totalmasiva = row["TotalMasIva"].ToString();

                row["Valor"] = Convert.ToInt32(
                               Convert.ToInt32(row["TotalMasIva"]) /*Convert.ToDouble(row["TotalMasIva"])*/ *
                               Convert.ToDouble(row["Cantidad"]));

                var val = row["Valor"].ToString();

                miTabla.Rows.Add(row);

                var v = miTabla.AsEnumerable().Sum(s => s.Field<double>("Valor"));

                txtTotal.Text = UseObject.InsertSeparatorMil
                    (
                       Convert.ToInt32(
                       miTabla.AsEnumerable().Sum(s => s.Field<double>("Valor"))
                       ).ToString()
                    );
                RecargarGridview();
                LimpiarCampos();
                btnTallaYcolor.Enabled = false;
            }
            else
            {
                OptionPane.MessageError("Debe cargar primero un artículo.");
                miError.SetError(txtCodigoArticulo, "Debe cargar primero un artículo.");
                txtCodigoArticulo.Focus();
            }
            txtNumeroFactura.Enabled = false;
        }

        /// <summary>
        /// Actualiza la información de la devolución cuando se realiza un cambio.
        /// </summary>
        /// <param name="rowIndex">Índex del registro de la lista a modificar.</param>
        /// <param name="valor">Valor a modificar en el registro seleccionado.</param>
        /// <param name="iva_">Condición que indica que el valor contiene o no el IVA.</param>
        private void ActualizarInformacion(int rowIndex, string valor, bool iva_)
        {
            //valor = valor.Replace('.', ',');
            var id = Convert.ToInt32(dgvListaArticulos.Rows[rowIndex].Cells["Id"].Value);
            var query = (from datos in miTabla.AsEnumerable()
                         where datos.Field<int>("Id") == id
                         select datos).Single();
            var index = miTabla.Rows.IndexOf(query);

            //MiProducto.Impoconsumo = Convert.ToDouble(miTabla.Rows[index]["Impoconsumo"]);

            ProductoFacturaProveedor miProducto = new ProductoFacturaProveedor();
            miProducto.ImpoConsumo = Convert.ToInt32(miTabla.Rows[index]["Impoconsumo"]);
            miProducto.Valor = Convert.ToDouble(valor.Replace('.', ',')) - miProducto.ImpoConsumo;
            //miProducto.Producto.Descuento = UseObject.RemoveCharacter(miTabla.Rows[index]["Descuento"].ToString(), '%');
            miProducto.Producto.ValorIva = UseObject.RemoveCharacter(miTabla.Rows[index]["Iva"].ToString(), '%');
            if (iva_)
            {
                miProducto.ValorReal = Math.Round((miProducto.Valor / ((miProducto.Producto.ValorIva / 100) + 1)), 1);
            }
            else
            {
                miProducto.ValorReal = miProducto.Valor;
            }
            miProducto.Valor_Iva = Math.Round((miProducto.ValorReal * miProducto.Producto.ValorIva / 100), 1);
            if (this.RedondearPrecio2)
            {
                miProducto.Producto.ValorVentaProducto = 
                    UseObject.Aproximar(Convert.ToInt32(miProducto.ValorReal + miProducto.Valor_Iva), this.AproxPrecio);
            }
            else
            {
                miProducto.Producto.ValorVentaProducto = Convert.ToInt32(miProducto.ValorReal + miProducto.Valor_Iva);
            }

            miProducto.Valor = Math.Round((miProducto.Producto.ValorVentaProducto / ((miProducto.Producto.ValorIva / 100) + 1)), 1);

            miTabla.Rows[index]["ValorMenosDescto"] = miTabla.Rows[index]["ValorUnitario"] = miProducto.Valor;
            double vIva = Math.Round((miProducto.Valor * miProducto.Producto.ValorIva / 100), 1);
            miTabla.Rows[index]["TotalMasIva"] = miProducto.Producto.ValorVentaProducto + miProducto.ImpoConsumo;
            miTabla.Rows[index]["Valor"] = Convert.ToInt32((miProducto.Producto.ValorVentaProducto + miProducto.ImpoConsumo) *
                Convert.ToDouble(miTabla.Rows[index]["Cantidad"]));

            //
            /*double porcentajeIva = UseObject.RemoveCharacter(miTabla.Rows[index]["Iva"].ToString(), '%');
            if (iva_)
            {
                miTabla.Rows[index]["ValorUnitario"] = Math.Round(Convert.ToInt32(valor) /
                    ((UseObject.RemoveCharacter(miTabla.Rows[index]["Iva"].ToString(), '%') / 100) + 1));
            }
            else
            {
                miTabla.Rows[index]["ValorUnitario"] = Convert.ToInt32(Convert.ToDouble(valor));
            }
            miTabla.Rows[index]["ValorMenosDescto"] = Math.Round(
                (Convert.ToDouble(miTabla.Rows[index]["ValorUnitario"]) -
                (Convert.ToDouble(miTabla.Rows[index]["ValorUnitario"]) *
                UseObject.RemoveCharacter(miTabla.Rows[index]["Descuento"].ToString(), '%') / 100)), 1);
            vIva = Math.Round((Convert.ToDouble(miTabla.Rows[index]["ValorMenosDescto"]) *
                                     UseObject.RemoveCharacter(miTabla.Rows[index]["Iva"].ToString(), '%') / 100), 1);
            var vUnitario = Convert.ToInt32(Convert.ToDouble(miTabla.Rows[index]["ValorMenosDescto"]) + vIva);

            miTabla.Rows[index]["TotalMasIva"] =
                UseObject.Aproximar(vUnitario, Convert.ToBoolean(AppConfiguracion.ValorSeccion("tipo_aprox_precio")));

            miTabla.Rows[index]["Valor"] = Convert.ToInt32(
                Convert.ToDouble(miTabla.Rows[index]["TotalMasIva"]) *
                Convert.ToDouble(miTabla.Rows[index]["Cantidad"]));*/

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

        // Funcional
        private void ActualizarInformacion(int rowIndex, string valor, bool iva_, bool ico)
        {
            //valor = valor.Replace('.', ',');
            var id = Convert.ToInt32(dgvListaArticulos.Rows[rowIndex].Cells["Id"].Value);
            var query = (from datos in miTabla.AsEnumerable()
                         where datos.Field<int>("Id") == id
                         select datos).Single();
            var index = miTabla.Rows.IndexOf(query);

            //MiProducto.Impoconsumo = Convert.ToDouble(miTabla.Rows[index]["Impoconsumo"]);

            ProductoFacturaProveedor miProducto = new ProductoFacturaProveedor();
            miProducto.ImpoConsumo = Convert.ToInt32(miTabla.Rows[index]["Impoconsumo"]);

            if (ico)
            {
                miProducto.Valor = Convert.ToDouble(valor.Replace('.', ',')) - miProducto.ImpoConsumo;
            }
            else
            {
                miProducto.Valor = Convert.ToDouble(valor.Replace('.', ','));
            }

            //miProducto.Valor = Convert.ToDouble(valor.Replace('.', ',')) - miProducto.ImpoConsumo;

            //miProducto.Producto.Descuento = UseObject.RemoveCharacter(miTabla.Rows[index]["Descuento"].ToString(), '%');
            miProducto.Producto.ValorIva = UseObject.RemoveCharacter(miTabla.Rows[index]["Iva"].ToString(), '%');
            if (iva_)
            {
                miProducto.ValorReal = Math.Round((miProducto.Valor / ((miProducto.Producto.ValorIva / 100) + 1)), 1);
            }
            else
            {
                miProducto.ValorReal = miProducto.Valor;
            }
            miProducto.Valor_Iva = Math.Round((miProducto.ValorReal * miProducto.Producto.ValorIva / 100), 1);
            if (this.RedondearPrecio2)
            {
                miProducto.Producto.ValorVentaProducto =
                    UseObject.Aproximar(Convert.ToInt32(miProducto.ValorReal + miProducto.Valor_Iva), this.AproxPrecio);
            }
            else
            {
                miProducto.Producto.ValorVentaProducto = Convert.ToInt32(miProducto.ValorReal + miProducto.Valor_Iva);
            }

            miProducto.Valor = Math.Round((miProducto.Producto.ValorVentaProducto / ((miProducto.Producto.ValorIva / 100) + 1)), 1);

            miTabla.Rows[index]["ValorMenosDescto"] = miTabla.Rows[index]["ValorUnitario"] = miProducto.Valor;
            double vIva = Math.Round((miProducto.Valor * miProducto.Producto.ValorIva / 100), 1);
            miTabla.Rows[index]["TotalMasIva"] = miProducto.Producto.ValorVentaProducto + miProducto.ImpoConsumo;
            miTabla.Rows[index]["Valor"] = Convert.ToInt32((miProducto.Producto.ValorVentaProducto + miProducto.ImpoConsumo) *
                Convert.ToDouble(miTabla.Rows[index]["Cantidad"]));

            //
            /*double porcentajeIva = UseObject.RemoveCharacter(miTabla.Rows[index]["Iva"].ToString(), '%');
            if (iva_)
            {
                miTabla.Rows[index]["ValorUnitario"] = Math.Round(Convert.ToInt32(valor) /
                    ((UseObject.RemoveCharacter(miTabla.Rows[index]["Iva"].ToString(), '%') / 100) + 1));
            }
            else
            {
                miTabla.Rows[index]["ValorUnitario"] = Convert.ToInt32(Convert.ToDouble(valor));
            }
            miTabla.Rows[index]["ValorMenosDescto"] = Math.Round(
                (Convert.ToDouble(miTabla.Rows[index]["ValorUnitario"]) -
                (Convert.ToDouble(miTabla.Rows[index]["ValorUnitario"]) *
                UseObject.RemoveCharacter(miTabla.Rows[index]["Descuento"].ToString(), '%') / 100)), 1);
            vIva = Math.Round((Convert.ToDouble(miTabla.Rows[index]["ValorMenosDescto"]) *
                                     UseObject.RemoveCharacter(miTabla.Rows[index]["Iva"].ToString(), '%') / 100), 1);
            var vUnitario = Convert.ToInt32(Convert.ToDouble(miTabla.Rows[index]["ValorMenosDescto"]) + vIva);

            miTabla.Rows[index]["TotalMasIva"] =
                UseObject.Aproximar(vUnitario, Convert.ToBoolean(AppConfiguracion.ValorSeccion("tipo_aprox_precio")));

            miTabla.Rows[index]["Valor"] = Convert.ToInt32(
                Convert.ToDouble(miTabla.Rows[index]["TotalMasIva"]) *
                Convert.ToDouble(miTabla.Rows[index]["Cantidad"]));*/

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

        private void ActualizarInformacion_old(int rowIndex, string valor, bool iva_)
        {
            valor = valor.Replace('.', ',');
            var id = Convert.ToInt32(dgvListaArticulos.Rows[rowIndex].Cells["Id"].Value);
            var query = (from datos in miTabla.AsEnumerable()
                         where datos.Field<int>("Id") == id
                         select datos).Single();
            var index = miTabla.Rows.IndexOf(query);
            if (iva_)
            {
                /*miTabla.Rows[index]["ValorUnitario"] = Convert.ToInt32(Convert.ToDouble(valor) /
                    ((UseObject.RemoveCharacter(miTabla.Rows[index]["Iva"].ToString(), '%') / 100) + 1));*/
                //2
                miTabla.Rows[index]["ValorUnitario"] = Math.Round(Convert.ToInt32(valor) /
                    ((UseObject.RemoveCharacter(miTabla.Rows[index]["Iva"].ToString(), '%') / 100) + 1));
            }
            else
            {
                miTabla.Rows[index]["ValorUnitario"] = Convert.ToInt32(Convert.ToDouble(valor));
            }
            /*var valorIva = UseObject.AproximacionDian((
                           Convert.ToDouble(miTabla.Rows[index]["ValorUnitario"]) *
                           UseObject.RemoveCharacter(miTabla.Rows[index]["Iva"].ToString(), '%') / 100));
            //2
            var valorIva2 =  Convert.ToDouble(miTabla.Rows[index]["ValorUnitario"]) *
                             UseObject.RemoveCharacter(miTabla.Rows[index]["Iva"].ToString(), '%') / 100;*/
            //var valorIvaApx = UseObject.AproximacionDian(valorIva);va

            miTabla.Rows[index]["ValorMenosDescto"] = Math.Round(
                (Convert.ToDouble(miTabla.Rows[index]["ValorUnitario"]) -
                (Convert.ToDouble(miTabla.Rows[index]["ValorUnitario"]) *
                UseObject.RemoveCharacter(miTabla.Rows[index]["Descuento"].ToString(), '%') / 100)), 1);

            //miTabla.Rows[index]["TotalMasIva"] = Convert.ToInt32(Convert.ToDouble(miTabla.Rows[index]["ValorMenosDescto"]) + valorIva2);
            //2
            /* miTabla.Rows[index]["TotalMasIva"] = Convert.ToDouble(miTabla.Rows[index]["ValorUnitario"]) +
                                                  (Convert.ToDouble(miTabla.Rows[index]["ValorUnitario"]) *
                                                  UseObject.RemoveCharacter(miTabla.Rows[index]["Iva"].ToString(), '%') / 100);*/
            //3
            double vIva = Math.Round((Convert.ToDouble(miTabla.Rows[index]["ValorMenosDescto"]) *
                                     UseObject.RemoveCharacter(miTabla.Rows[index]["Iva"].ToString(), '%') / 100), 1);
            var vUnitario = Convert.ToInt32(Convert.ToDouble(miTabla.Rows[index]["ValorMenosDescto"]) + vIva);

            // Edición precio producto  18 Feb 2017
            //miTabla.Rows[index]["TotalMasIva"] = vUnitario;

            miTabla.Rows[index]["TotalMasIva"] =
                UseObject.Aproximar(vUnitario, Convert.ToBoolean(AppConfiguracion.ValorSeccion("tipo_aprox_precio")));

            // End edición

            miTabla.Rows[index]["Valor"] = Convert.ToInt32(
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
        
        private void ActualizarInformacionNew(int rowIndex, string valor, bool iva_)
        {
            var id = Convert.ToInt32(dgvListaArticulos.Rows[rowIndex].Cells["Id"].Value);
            var query = (from datos in miTabla.AsEnumerable()
                         where datos.Field<int>("Id") == id
                         select datos).Single();
            var index = miTabla.Rows.IndexOf(query);

            if (iva_)
            {
                miTabla.Rows[index]["ValorUnitario"] = Math.Round(Convert.ToInt32(valor) /
                    ((UseObject.RemoveCharacter(miTabla.Rows[index]["Iva"].ToString(), '%') / 100) + 1));
            }
            else
            {
                miTabla.Rows[index]["ValorUnitario"] = Convert.ToInt32(Convert.ToDouble(valor));
            }

            miTabla.Rows[index]["ValorUnitario"] = Math.Round((Convert.ToInt32(valor) /
                    ((UseObject.RemoveCharacter(miTabla.Rows[index]["Iva"].ToString(), '%') / 100) + 1)), 1);

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

               /* RecargarGridview();
                txtTotal.Text = UseObject.InsertSeparatorMil
                    (
                       Convert.ToInt32(
                       miTabla.AsEnumerable().Sum(s => s.Field<double>("Valor"))
                       ).ToString()
                    );
                RecargarRetencion();
                ColorearGrid();

                dgvListaArticulos.Focus();
                txtCodigoArticulo.Focus();*/

                RecargarGridview();
                txtTotal.Text = UseObject.InsertSeparatorMil
                    (
                        Convert.ToInt32(
                        miTabla.AsEnumerable().Sum(s => s.Field<double>("Valor"))
                        ).ToString()
                    );
                dgvListaArticulos.Focus();
                txtCodigoArticulo.Focus();

           /* }
            else
            {
                RecargarRetencion();
                RecargarGridview();
                ColorearGrid();
                dgvListaArticulos.Focus();
                txtCodigoArticulo.Focus();
            }*/
        }
    
        private void ActualizarInformacionCantidadNew(int rowIndex, string valor)
        {
            var id = Convert.ToInt32(dgvListaArticulos.Rows[rowIndex].Cells["Id"].Value);
            var query = (from datos in miTabla.AsEnumerable()
                         where datos.Field<int>("Id") == id
                         select datos).Single();
            var index = miTabla.Rows.IndexOf(query);

          //  if (!Convert.ToBoolean(this.dgvListaArticulos.Rows[rowIndex].Cells["Retorno"].Value))
            //{
                miTabla.Rows[index]["Cantidad"] = valor.Replace('.', ',');

                var d = miTabla.Rows[index]["ValorUnitario"].ToString();

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
              //  ColorearGrid();
                txtTotal.Text = UseObject.InsertSeparatorMil
                    (
                       Convert.ToInt32(
                       miTabla.AsEnumerable().Sum(s => s.Field<double>("Valor"))
                       ).ToString()
                    );
             //   RecargarRetencion();
                dgvListaArticulos.Focus();
                txtCodigoArticulo.Focus();
           /* }
            else
            {
                RecargarRetencion();
                RecargarGridview();
                ColorearGrid();
                dgvListaArticulos.Focus();
                txtCodigoArticulo.Focus();
            }*/
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
            txtDescuento.Text = "0";
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
            this.DevolucionEfectivo = 0;
            LimpiarCampos();
            txtNumeroFactura.Enabled = true;
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
            bono.Numero = miBussinesConsecutivos.Consecutivo("Bono");
            bono.Concepto = "Saldo por devoluciones.";
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

        private DTO.Clases.Ingreso GenerarSaldoCliente //Bono a Cliente  (Saldo a cliente)  GenerarNotaCredito
            (string numero, string cliente, DateTime fecha, int valorDev)
        {
            var b = GuardarBono(cliente, valorDev, false);
            GuardaSeguimientoBono(b, false, numero);
            var ingreso = new DTO.Clases.Ingreso();
            ingreso.IdUsuario = b.IdUsuario;
            ingreso.IdCaja = b.IdCaja;
            ingreso.Fecha = fecha;
            ingreso.Numero = b.Numero;
            ingreso.Concepto = b.Concepto;
            ingreso.Valor = valorDev;
            return ingreso;
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
            var numero = miBussinesConsecutivos.Consecutivo("Ingreso");

            foreach (var ing in ingresos)
            {
                facts = facts + ", " + ing.Numero;
            }
            var ingreso = new Ingreso
            {
                Numero = numero,
                Concepto = "Abonos con Devolución a Facturas No. " + facts,
                Tipo = 4,  //1,
                Fecha = fecha,
                Valor = ingresos.Sum(s => s.Valor)
            };
            ingreso.NitCliente = Factura.Proveedor.NitProveedor;
            ingreso.Saldo = miBussinesFactura.SaldoPorCliente(2, Factura.Proveedor.NitProveedor);
            ingreso.IdCaja = IdCaja;
            ingreso.IdUsuario = IdUsuario;

            foreach (var ing in ingresos)
            {
                ingreso.Relacion = ing.Id;
                bussinesIngreso.Ingresar(ingreso, false);
            }
            /*if (Convert.ToInt32(numero) < 99)
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
            egreso.Numero = miBussinesConsecutivos.Consecutivo("Egreso");
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
                IdCuenta = Convert.ToInt32(AppConfiguracion.ValorSeccion("ctaEgreso")),
                Id = Convert.ToInt32(AppConfiguracion.ValorSeccion("ctaEgreso")),
                Nombre = "Devoluciones de Cliente.",
                Numero = egreso.Total.ToString()
            });
            var bussinesEgreso = new BussinesEgreso();
            egreso.Id = bussinesEgreso.IngresarEgreso(egreso);
            /*  if (Convert.ToInt32(egreso.Numero) < 99)
              {
                  AppConfiguracion.SaveConfiguration
                      ("numero-e", IncrementaConsecutivo(egreso.Numero));
              }
              else
              {
                  AppConfiguracion.SaveConfiguration
                      ("numero-e", (Convert.ToInt32(egreso.Numero) + 1).ToString());
              }*/

            //valorDev = 0;
            this.DevolucionEfectivo += valorDev;
            return egreso;
        }

        private List<Ingreso> AbonoGeneralAcliente(string cliente, ref int valorDev, DateTime fecha)
        {
            return miBussinesDevolucion.IngresarSaldoGeneralDevolucionVenta
                                (cliente, ref valorDev, IdUsuario, IdCaja, fecha);
        }

        private void PrintSaldoCliente(Ingreso ingreso, string cliente)  //PrintNotaCredito
        {
           /* DialogResult rta = MessageBox.Show("¿Desea visualizar la impresión de la nota crédito a cliente?", "Devolución Venta",
                MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);*/
            FrmPrint frmPrint = new FrmPrint();
            frmPrint.StringCaption = "Devolución Venta";
            frmPrint.StringMessage = "Impresión de la Nota Credito a Cliente";
            DialogResult rta = frmPrint.ShowDialog();

            if (!rta.Equals(DialogResult.Cancel))
            {
                try
                {
                    var printCompIng = new Cliente.FrmPrintAnticipo();
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
                    printCompIng.ReportPath = AppConfiguracion.ValorSeccion("report") + @"\reports\ComprobanteSaldo.rdlc";

                    if (rta.Equals(DialogResult.No))
                    {
                        printCompIng.ShowDialog();
                    }
                    else
                    {
                        Imprimir print = new Imprimir();
                        print.Report = printCompIng.CargarDatos();
                        print.Print(Imprimir.TamanioPapel.MediaCarta);
                        printCompIng.ResetReport();
                    }
                }
                catch (Exception ex)
                {
                    OptionPane.MessageError(ex.Message);
                }
            }
        }

        private void PrintSaldoClientePos(Ingreso ingreso, string cliente)
        {
            DialogResult rta = MessageBox.Show("¿Desea imprimir la nota crédito a cliente?", "Devolución Venta",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rta.Equals(DialogResult.Yes))
            {
                try
                {
                    int MaxCharacters = 35;

                    var miBussinesEmpresa = new BussinesEmpresa();
                    var miBussinesCaja = new BussinesCaja();
                    var miBussinesUsuario = new BussinesUsuario();
                    var miBussinesCliente = new BussinesCliente();

                    var empresaRow = miBussinesEmpresa.PrintEmpresa().
                                     Tables[0].AsEnumerable().First();
                    var caja = miBussinesCaja.CajaId(ingreso.IdCaja);
                    var ususarioRow = miBussinesUsuario.ConsultaUsuario(ingreso.IdUsuario).AsEnumerable().First();
                    var clienteDB = miBussinesCliente.ClienteAEditar(cliente);

                    Ticket ticket = new Ticket();

                    foreach (var datos_ in UseObject.StringBuilderDataCenter(empresaRow["Nombre"].ToString().ToUpper(), MaxCharacters))
                    {
                        ticket.AddHeaderLine(datos_);
                    }
                    foreach (var datos_ in UseObject.StringBuilderDataCenter(empresaRow["Juridico"].ToString().ToUpper(), MaxCharacters))
                    {
                        ticket.AddHeaderLine(datos_);
                    }
                    //ticket.AddHeaderLine(empresaRow["Nombre"].ToString().ToUpper());
                    //ticket.AddHeaderLine(empresaRow["Juridico"].ToString());
                    ticket.AddHeaderLine("NIT " + UseObject.InsertSeparatorMilMasDigito(empresaRow["Nit"].ToString()));

                    foreach (var datos_ in UseObject.StringBuilderDataIzquierda(empresaRow["Direccion"].ToString().ToUpper(), MaxCharacters))
                    {
                        ticket.AddHeaderLine(datos_);
                    }
                    //ticket.AddHeaderLine(empresaRow["Direccion"].ToString());
                    ticket.AddHeaderLine("Tels. " + empresaRow["Telefono"].ToString());
                    ticket.AddHeaderLine("Fecha   : " + ingreso.Fecha.ToShortDateString());
                    ticket.AddHeaderLine("Caja No : " + caja.Numero.ToString());
                    ticket.AddHeaderLine("Cajero(a)  :  " + ususarioRow["nombre"].ToString());
                    ticket.AddHeaderLine("===================================");
                    //ticket.AddHeaderLine("COMPROBANTE DE SALDO Nro " + ingreso.Numero);
                    ticket.AddHeaderLine("NOTA CRÉDITO A CLIENTE No " + ingreso.Numero);
                    ticket.AddHeaderLine("===================================");

                    foreach (var datos_ in UseObject.StringBuilderDataIzquierda("Recibido de : " + clienteDB.NombresCliente.ToUpper(), MaxCharacters))
                    {
                        ticket.AddHeaderLine(datos_);
                    }
                    //ticket.AddHeaderLine("Recibido de : " + clienteDB.NombresCliente);
                    ticket.AddHeaderLine("NIT o C.C.  : " + UseObject.InsertSeparatorMilMasDigito(clienteDB.NitCliente));
                    ticket.AddHeaderLine("===================================");

                    int maxCharacters_18 = 18;
                    int maxCharacters_15 = 15;
                    List<string> datos = new List<string>();
                    string valor = UseObject.InsertSeparatorMil(ingreso.Valor.ToString());
                    datos = UseObject.StringBuilderDataIzquierda(ingreso.Concepto, maxCharacters_18);
                    for (int i = 0; i < datos.Count; i++)
                    {
                        if (i == datos.Count - 1)
                        {
                            ticket.AddHeaderLine(datos[i] + UseObject.FuncionEspacio(maxCharacters_18 - datos[i].Length) + "  " +
                                UseObject.FuncionEspacio(maxCharacters_15 - valor.Length) + valor);
                        }
                        else
                        {
                            ticket.AddHeaderLine(datos[i]);
                        }
                    }

                    ticket.AddHeaderLine("===================================");
                    ticket.AddHeaderLine("");
                    ticket.AddHeaderLine("");
                    ticket.AddHeaderLine("Firma:");
                    ticket.AddHeaderLine("-----------------------------------");
                    ticket.AddHeaderLine("C.C. o NIT:");
                    ticket.AddHeaderLine("-----------------------------------");
                    ticket.AddHeaderLine("Fecha:");
                    ticket.AddHeaderLine("-----------------------------------");
                    ticket.AddHeaderLine("");
                    ticket.AddHeaderLine("Software: DFPYME");
                    ticket.AddHeaderLine("");

                    ticket.PrintTicket("");
                }
                catch (Exception ex)
                {
                    OptionPane.MessageError(ex.Message);
                }
            }
        }

        private void PrintIngreso
            (Ingreso ingreso, DTO.Clases.FormaPago pago, string cliente)
        {
            /*DialogResult rta = MessageBox.Show("¿Desea visualizar la impresión del comprobante de ingreso?", "Devolución Venta",
                MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);*/
            FrmPrint frmPrint = new FrmPrint();
            frmPrint.StringCaption = "Devolución Venta";
            frmPrint.StringMessage = "Impresión del Comprobante de Ingreso";
            DialogResult rta = frmPrint.ShowDialog();

            if (!rta.Equals(DialogResult.Cancel))
            {
                try
                {
                    var printComprobante = new Cliente.FrmPrintAnticipo();
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

                    if (rta.Equals(DialogResult.No))
                    {
                        printComprobante.ShowDialog();
                    }
                    else
                    {
                        Imprimir print = new Imprimir();
                        print.Report = printComprobante.CargarDatos();
                        print.Print(Imprimir.TamanioPapel.MediaCarta);
                        printComprobante.ResetReport();
                    }
                }
                catch (Exception ex)
                {
                    OptionPane.MessageError(ex.Message);
                }
            }
        }

        private void PrintIngresoPos(string numero)
        {
            DialogResult rta = MessageBox.Show("¿Desea imprimir el comprobante de ingreso?", "Devolución Venta",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rta.Equals(DialogResult.Yes))
            {
                try
                {
                    int MaxCharacters = 35;

                    var miBussinesEmpresa = new BussinesEmpresa();
                    var miBussinesIngreso = new BussinesIngreso();
                    var miBussinesUsuario = new BussinesUsuario();
                    var miBussinesFactura = new BussinesFacturaVenta();

                    var empresaRow = miBussinesEmpresa.PrintEmpresa().
                                     Tables[0].AsEnumerable().First();
                    var ingresoRow = miBussinesIngreso.Ingresos(numero).AsEnumerable().First();

                    var tIngresos = miBussinesIngreso.IngresosMultiple(numero);
                    var tPagos = miBussinesIngreso.PagosIngreso(Convert.ToInt32(ingresoRow["tipo"]), tIngresos.Rows);
                    var query = from item in tPagos.AsEnumerable()
                                group item by item["NoCaja"].ToString()
                                    into g
                                    select g;
                    var noCaja = "";
                    if (query.ToArray().Length != 0)
                    {
                        noCaja = query.First().Key;
                    }
                    var usuario = "";
                    var queryUser = from item in tPagos.AsEnumerable()
                                    group item by item["IdUser"].ToString()
                                        into g
                                        select g;
                    if (queryUser.ToArray().Length != 0)
                    {
                        usuario = queryUser.First().Key;
                    }
                    usuario = miBussinesUsuario.ConsultaUsuario(Convert.ToInt32(usuario)).
                                                AsEnumerable().First()["nombre"].ToString();
                    var queryFactura = from item in tPagos.AsEnumerable()
                                       group item by item["NoFactura"].ToString()
                                           into g
                                           select g;
                    DataRow clienteRow = null;
                    if (queryFactura.ToArray().Length != 0)
                    {
                        clienteRow = miBussinesFactura.ClienteDeFacutura(queryFactura.First().Key).AsEnumerable().First();
                    }

                    Ticket ticket = new Ticket();
                    ticket.UseItem = false;

                    foreach (var datos_ in UseObject.StringBuilderDataCenter(empresaRow["Nombre"].ToString().ToUpper(), MaxCharacters))
                    {
                        ticket.AddHeaderLine(datos_);
                    }
                    foreach (var datos_ in UseObject.StringBuilderDataCenter(empresaRow["Juridico"].ToString().ToUpper(), MaxCharacters))
                    {
                        ticket.AddHeaderLine(datos_);
                    }

                    //ticket.AddHeaderLine(empresaRow["Nombre"].ToString().ToUpper());
                    //ticket.AddHeaderLine(empresaRow["Juridico"].ToString());
                    ticket.AddHeaderLine("NIT " + UseObject.InsertSeparatorMilMasDigito(empresaRow["Nit"].ToString()));

                    foreach (var datos_ in UseObject.StringBuilderDataIzquierda(empresaRow["Direccion"].ToString().ToUpper(), MaxCharacters))
                    {
                        ticket.AddHeaderLine(datos_);
                    }
                    //ticket.AddHeaderLine(empresaRow["Direccion"].ToString());
                    ticket.AddHeaderLine("Tels. " + empresaRow["Telefono"].ToString());
                    ticket.AddHeaderLine("Fecha : " + Convert.ToDateTime(ingresoRow["fecha"]).ToShortDateString() +
                                         "    Caja : " + noCaja);
                    ticket.AddHeaderLine("Cajero(a)  :  " + usuario);
                    ticket.AddHeaderLine("===================================");
                    ticket.AddHeaderLine("COMPROBANTE DE INGRESO Nro " + numero);
                    ticket.AddHeaderLine("===================================");

                    foreach (var datos_ in UseObject.StringBuilderDataIzquierda("Recibido de : " + clienteRow["nombrescliente"].ToString().ToUpper(), MaxCharacters))
                    {
                        ticket.AddHeaderLine(datos_);
                    }
                    //ticket.AddHeaderLine("Recibido de : " + clienteRow["nombrescliente"].ToString());
                    ticket.AddHeaderLine("NIT o C.C.  : " + UseObject.InsertSeparatorMilMasDigito(clienteRow["nitcliente"].ToString()));
                    ticket.AddHeaderLine("===================================");
                    ticket.AddHeaderLine("");
                    ticket.AddHeaderLine("      CONCEPTO               VALOR ");
                    ticket.AddHeaderLine("");
                    int maxCharacters_18 = 18;
                    int maxCharacters_15 = 15;
                    string valor = "";
                    List<string> datos = new List<string>();
                    valor = UseObject.InsertSeparatorMil(ingresoRow["valor"].ToString());
                    datos = UseObject.StringBuilderDataIzquierda(ingresoRow["concepto"].ToString(), maxCharacters_18);
                    for (int i = 0; i < datos.Count; i++)
                    {
                        if (i == datos.Count - 1)
                        {
                            ticket.AddHeaderLine(datos[i] + UseObject.FuncionEspacio(maxCharacters_18 - datos[i].Length) + "  " +
                                UseObject.FuncionEspacio(maxCharacters_15 - valor.Length) + valor);
                        }
                        else
                        {
                            ticket.AddHeaderLine(datos[i]);
                        }
                    }


                   /* ticket.AddItem("",
                                   ingresoRow["concepto"].ToString(),
                                   UseObject.InsertSeparatorMil(ingresoRow["valor"].ToString()));*/


                    ticket.AddHeaderLine("            TOTAL :" + UseObject.StringBuilderDetalleTotal(
                        UseObject.InsertSeparatorMil(ingresoRow["valor"].ToString())));
                    //ticket.AddTotal("TOTAL ", UseObject.InsertSeparatorMil(ingresoRow["valor"].ToString()));

                    ticket.AddHeaderLine("");
                    IEnumerable<IGrouping<string, DataRow>> queryPago = from item in tPagos.AsEnumerable()
                                                                        group item by item["FormaPago"].ToString()
                                                                            into g
                                                                            select g;
                    var tPagosGroup = PagosGroup(queryPago);
                    foreach (DataRow pRow in tPagosGroup.Rows)
                    {
                        foreach (var datos_ in UseObject.StringBuilderDetalleValor(pRow["FormaPago"].ToString(),
                            UseObject.InsertSeparatorMil(pRow["Valor"].ToString()), MaxCharacters))
                        {
                            ticket.AddHeaderLine(datos_);
                        }
                        /*ticket.AddTotal(pRow["FormaPago"].ToString(),
                                        UseObject.InsertSeparatorMil(pRow["Valor"].ToString()));*/
                    }
                    ticket.AddHeaderLine("===================================");
                    ticket.AddHeaderLine("");
                    ticket.AddHeaderLine("");
                    ticket.AddHeaderLine("Firma:");
                    ticket.AddHeaderLine("-----------------------------------");
                    ticket.AddHeaderLine("C.C. o NIT:");
                    ticket.AddHeaderLine("-----------------------------------");
                    ticket.AddHeaderLine("Fecha:");
                    ticket.AddHeaderLine("-----------------------------------");
                    ticket.AddHeaderLine("");
                    ticket.AddHeaderLine("Software: DFPYME");
                    ticket.AddHeaderLine("");

                    ticket.PrintTicket("");
                }
                catch (Exception ex)
                {
                    OptionPane.MessageError("Ocurrió un error al imprimir el comprobante.\n" + ex.Message);
                }
            }
        }

        private DataTable PagosGroup(IEnumerable<IGrouping<string, DataRow>> dataRows)
        {
            var tabla = new DataTable();
            tabla.Columns.Add(new DataColumn("FormaPago", typeof(string)));
            tabla.Columns.Add(new DataColumn("Valor", typeof(int)));
            foreach (IGrouping<string, DataRow> item in dataRows)
            {
                DataRow r = tabla.NewRow();
                r["FormaPago"] = item.Key;
                r["Valor"] = item.Sum<DataRow>(d => Convert.ToInt32(d["Valor"]));
                tabla.Rows.Add(r);
            }
            return tabla;
        }

        private void PrintEgreso(DTO.Clases.Egreso egreso, string beneficio)
        {
            /*DialogResult rta = MessageBox.Show("¿Desea visualizar la impresión del comprobante de egreso?", "Devolución Venta",
                MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);*/
            FrmPrint frmPrint = new FrmPrint();
            frmPrint.StringCaption = "Devolución Venta";
            frmPrint.StringMessage = "Impresión del Comprobante de Egreso";
            DialogResult rta = frmPrint.ShowDialog();

            if (!rta.Equals(DialogResult.Cancel))
            {
                var miBussinesPuc = new BussinesPuc();
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
                    printEgreso.Numero = egreso.Numero;
                    printEgreso.Fecha = egreso.Fecha;
                    printEgreso.Remite = miBeneficio.NombresCliente + "  CC o NIT : " +
                                         miBeneficio.NitCliente;
                    printEgreso.Cuentas = tabla;
                    printEgreso.Cheque = egreso.Pagos.Where(p => p.IdFormaPago == 2).Sum(s => s.Valor).ToString();
                    printEgreso.Efectivo = egreso.Pagos.Where(p => p.IdFormaPago == 1).Sum(s => s.Valor).ToString();
                    printEgreso.Transaccion = egreso.Pagos.Where(p => p.IdFormaPago == 4).Sum(s => s.Valor).ToString();

                    if (rta.Equals(DialogResult.No))
                    {
                        printEgreso.ShowDialog();
                    }
                    else
                    {
                        Imprimir print = new Imprimir();
                        print.Report = printEgreso.CargarDatos();
                        print.Print(Imprimir.TamanioPapel.MediaCarta);
                        printEgreso.ResetReport();
                    }
                }
                catch (Exception ex)
                {
                    OptionPane.MessageError(ex.Message);
                }
            }
        }

        private void PrintEgresoPos(string numero, DataTable items)
        {
            DialogResult rta = MessageBox.Show("¿Desea imprimir el comprobante de egreso?", "Devolución Venta",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rta.Equals(DialogResult.Yes))
            {
                try
                {
                    int MaxCharacters = 35;

                    var miBussinesEmpresa = new BussinesEmpresa();
                    var miBussinesEgreso = new BussinesEgreso();
                    var miBussinesUsuario = new BussinesUsuario();
                    var miBussinesCaja = new BussinesCaja();
                    var miBussinesBeneficia = new BussinesBeneficio();

                    var empresaRow = miBussinesEmpresa.PrintEmpresa().
                                     Tables[0].AsEnumerable().First();
                    var egreso = miBussinesEgreso.EgresoNumero(numero);
                    egreso.Pagos = miBussinesEgreso.PagosEgreso(egreso.Id);
                    var caja = miBussinesCaja.CajaId(egreso.IdCaja);
                    var usuario = miBussinesUsuario.ConsultaUsuario(egreso.IdUsuario).AsEnumerable().First();
                    var beneficio = miBussinesBeneficia.BeneficiarioId(egreso.TipoBeneficiario);


                    Ticket ticket = new Ticket();
                    ticket.UseItem = false;

                    foreach (var datos_ in UseObject.StringBuilderDataCenter(empresaRow["Nombre"].ToString().ToUpper(), MaxCharacters))
                    {
                        ticket.AddHeaderLine(datos_);
                    }
                    foreach (var datos_ in UseObject.StringBuilderDataCenter(empresaRow["Juridico"].ToString().ToUpper(), MaxCharacters))
                    {
                        ticket.AddHeaderLine(datos_);
                    }
                    //ticket.AddHeaderLine(empresaRow["Nombre"].ToString().ToUpper());
                    //ticket.AddHeaderLine(empresaRow["Juridico"].ToString());
                    ticket.AddHeaderLine("NIT " + UseObject.InsertSeparatorMilMasDigito(empresaRow["Nit"].ToString()));

                    foreach (var datos_ in UseObject.StringBuilderDataIzquierda(empresaRow["Direccion"].ToString().ToUpper(), MaxCharacters))
                    {
                        ticket.AddHeaderLine(datos_);
                    }
                    //ticket.AddHeaderLine(empresaRow["Nombre"].ToString().ToUpper());
                    //ticket.AddHeaderLine(empresaRow["Juridico"].ToString());
                    ticket.AddHeaderLine("NIT " + UseObject.InsertSeparatorMilMasDigito(empresaRow["Nit"].ToString()));

                    foreach (var datos_ in UseObject.StringBuilderDataIzquierda(empresaRow["Direccion"].ToString().ToUpper(), MaxCharacters))
                    {
                        ticket.AddHeaderLine(datos_);
                    }
                    //ticket.AddHeaderLine(empresaRow["Direccion"].ToString());
                    ticket.AddHeaderLine("Tels. " + empresaRow["Telefono"].ToString());
                    ticket.AddHeaderLine("Fecha : " + egreso.Fecha.ToShortDateString() +
                                     "    Caja : " + caja.Numero.ToString());
                    ticket.AddHeaderLine("Cajero(a)  :  " + usuario["nombre"].ToString());
                    ticket.AddHeaderLine("===================================");
                    
                        ticket.AddHeaderLine("COMPROBANTE DE EGRESO Nro " + egreso.Numero);
                    ticket.AddHeaderLine("===================================");

                    foreach (var datos_ in UseObject.StringBuilderDataIzquierda("Remite a : " + beneficio.NombresCliente.ToUpper(), MaxCharacters))
                    {
                        ticket.AddHeaderLine(datos_);
                    }
                    //ticket.AddHeaderLine("Remite a : " + beneficio.NombresCliente.ToUpper());
                    ticket.AddHeaderLine("NIT: " + UseObject.InsertSeparatorMilMasDigito(beneficio.NitCliente));
                    ticket.AddHeaderLine("===================================");
                    ticket.AddHeaderLine("");
                    ticket.AddHeaderLine("      CONCEPTO               VALOR ");
                    ticket.AddHeaderLine("");
                    int maxCharacters_18 = 18;
                    int maxCharacters_15 = 15;
                    string valor = "";
                    List<string> datos = new List<string>();
                    foreach (DataRow cuenta in items.Rows)
                    {
                        valor = UseObject.InsertSeparatorMil(cuenta["Valor"].ToString());
                        datos = UseObject.StringBuilderDataIzquierda(cuenta["Concepto"].ToString(), maxCharacters_18);
                        for (int i = 0; i < datos.Count; i++)
                        {
                            if (i == datos.Count - 1)
                            {
                                ticket.AddHeaderLine(datos[i] + UseObject.FuncionEspacio(maxCharacters_18 - datos[i].Length) + "  " +
                                    UseObject.FuncionEspacio(maxCharacters_15 - valor.Length) + valor);
                            }
                            else
                            {
                                ticket.AddHeaderLine(datos[i]);
                            }
                        }
                    }

                    /*foreach (var cuenta in egreso.Cuentas)
                    {
                        valor = UseObject.InsertSeparatorMil(cuenta.Numero);
                        datos = UseObject.StringBuilderDataIzquierda(cuenta.Nombre, maxCharacters_18);
                        for (int i = 0; i < datos.Count; i++)
                        {
                            if (i == datos.Count - 1)
                            {
                                ticket.AddHeaderLine(datos[i] + UseObject.FuncionEspacio(maxCharacters_18 - datos[i].Length) + "  " +
                                    UseObject.FuncionEspacio(maxCharacters_15 - valor.Length) + valor);
                            }
                            else
                            {
                                ticket.AddHeaderLine(datos[i]);
                            }
                        }
                    }*/
                    ticket.AddHeaderLine("");
                    ticket.AddHeaderLine("===================================");
                    ticket.AddHeaderLine("");
                   /* var sTotal = 0;
                    var retencion = 0;

                    //var qConcepto = egreso.Cuentas.Where(d => d.IdCuenta != 0);
                    //var qRetenciones = egreso.Cuentas.Where(d => d.IdCuenta.Equals(0));

                    var qConcepto = items.AsEnumerable().Where(d => d.Field<int>("IdCuenta") != 0);
                    var qRetenciones = items.AsEnumerable().Where(d => d.Field<int>("IdCuenta") == 0);
                    if (qConcepto.ToArray().Length != 0)
                    {
                        //sTotal = qConcepto.Sum(d => Convert.ToInt32(d.Numero));
                        sTotal = Convert.ToInt32(qConcepto.Sum(d => d.Field<int>("Valor")));
                    }
                    if (qRetenciones.ToArray().Length != 0)
                    {
                        //retencion = qRetenciones.Sum(d => Convert.ToInt32(d.Numero));
                        retencion = Convert.ToInt32(qRetenciones.Sum(d => d.Field<int>("Valor")));
                    }
                    ticket.AddHeaderLine("         SUBTOTAL :" + UseObject.StringBuilderDetalleTotal(
                        UseObject.InsertSeparatorMil(sTotal.ToString())));
                    ticket.AddHeaderLine("      RETENCIONES :" + UseObject.StringBuilderDetalleTotal(
                        UseObject.InsertSeparatorMil(retencion.ToString())));*/
                    ticket.AddHeaderLine("            TOTAL :" + UseObject.StringBuilderDetalleTotal(
                        UseObject.InsertSeparatorMil((items.AsEnumerable().Sum(s => s.Field<int>("valor"))).ToString())));
                    ticket.AddHeaderLine("");
                    var pEfectivo = egreso.Pagos.Where(d => d.IdFormaPago.Equals(1));
                    var pCheque = egreso.Pagos.Where(d => d.IdFormaPago.Equals(2));
                    var pTransaccion = egreso.Pagos.Where(d => d.IdFormaPago.Equals(4));

                    if (pEfectivo.ToArray().Length != 0)
                    {
                        //ticket.AddTotal("EFECTIVO  : ", UseObject.InsertSeparatorMil(pEfectivo.Sum(d => d.Valor).ToString()));
                        ticket.AddHeaderLine("         EFECTIVO :" + UseObject.StringBuilderDetalleTotal(
                        UseObject.InsertSeparatorMil(pEfectivo.Sum(d => d.Valor).ToString())));
                    }
                    if (pCheque.ToArray().Length != 0)
                    {
                        //ticket.AddTotal("CHEQUE    : ", UseObject.InsertSeparatorMil(pCheque.Sum(d => d.Valor).ToString()));
                        ticket.AddHeaderLine("           CHEQUE :" + UseObject.StringBuilderDetalleTotal(
                        UseObject.InsertSeparatorMil(pCheque.Sum(d => d.Valor).ToString())));
                    }
                    if (pTransaccion.ToArray().Length != 0)
                    {
                        //ticket.AddTotal("TRANSACCIÓN :", UseObject.InsertSeparatorMil(pTransaccion.Sum(d => d.Valor).ToString()));
                        ticket.AddHeaderLine("      TRANSACCIÓN :" + UseObject.StringBuilderDetalleTotal(
                        UseObject.InsertSeparatorMil(pTransaccion.Sum(d => d.Valor).ToString())));
                    }
                    ticket.AddHeaderLine("");
                    ticket.AddHeaderLine("===================================");
                    ticket.AddHeaderLine("");
                    ticket.AddHeaderLine("");
                    ticket.AddHeaderLine("___________________________________");
                    ticket.AddHeaderLine("Aprobado:");
                    ticket.AddHeaderLine("");
                    ticket.AddHeaderLine("___________________________________");
                    ticket.AddHeaderLine("Beneficiario");
                    ticket.AddHeaderLine("");
                    ticket.AddHeaderLine("");
                    ticket.AddHeaderLine("Software: DFPYME");
                    ticket.AddHeaderLine("");
                    ticket.PrintTicket("");



                    /*
                    Ticket ticket = new Ticket();

                    ticket.AddHeaderLine(empresaRow["Nombre"].ToString().ToUpper());
                    ticket.AddHeaderLine(empresaRow["Juridico"].ToString());
                    ticket.AddHeaderLine("NIT " + UseObject.InsertSeparatorMilMasDigito(empresaRow["Nit"].ToString()));
                    ticket.AddHeaderLine(empresaRow["Direccion"].ToString());
                    ticket.AddHeaderLine("Tels. " + empresaRow["Telefono"].ToString());
                    ticket.AddHeaderLine("Fecha : " + egreso.Fecha.ToShortDateString() +
                                         "    Caja " + caja.Numero.ToString());
                    ticket.AddHeaderLine("Cajero(a)  :  " + usuario["nombre"].ToString());
                    ticket.AddHeaderLine("===================================");
                    ticket.AddHeaderLine("COMPROBANTE DE EGRESO Nro " + egreso.Numero);
                    ticket.AddHeaderLine("===================================");
                    ticket.AddHeaderLine("Remite a : " + beneficio.NombresCliente.ToUpper());
                    ticket.AddHeaderLine("NIT: " + UseObject.InsertSeparatorMilMasDigito(beneficio.NitCliente));
                    ticket.AddHeaderLine("===================================");
                    foreach (DataRow row in items.Rows)
                    {
                        ticket.AddItem("",
                                       row["Concepto"].ToString(),
                                       UseObject.InsertSeparatorMil(row["Valor"].ToString()));
                    }

                    var sTotal = 0;
                    var retencion = 0;
                    var qConceptos = items.AsEnumerable().Where(d => d.Field<int>("valor") > 0);
                    var qRetenciones = items.AsEnumerable().Where(d => d.Field<int>("valor") < 0);
                    if (qConceptos.ToArray().Length != 0)
                    {
                        sTotal = qConceptos.Sum(d => d.Field<int>("Valor"));
                    }
                    if (qRetenciones.ToArray().Length != 0)
                    {
                        retencion = qRetenciones.Sum(d => d.Field<int>("Valor"));
                    }
                    ticket.AddTotal("SUBTOTAL     : ", UseObject.InsertSeparatorMil(sTotal.ToString()));
                    ticket.AddTotal("RETENCIONES  : ", UseObject.InsertSeparatorMil(retencion.ToString()));
                    ticket.AddTotal("TOTAL        : ", UseObject.InsertSeparatorMil((sTotal + retencion).ToString()));
                    ticket.AddTotal("", "");
                    ticket.AddTotal("", "");

                    ticket.AddTotal("FORMAS DE PAGO", "");
                    ticket.AddTotal("", "");
                    var pEfectivo = egreso.Pagos.Where(d => d.IdFormaPago.Equals(1));
                    var pCheque = egreso.Pagos.Where(d => d.IdFormaPago.Equals(2));
                    var pTransaccion = egreso.Pagos.Where(d => d.IdFormaPago.Equals(4));
                    if (pEfectivo.ToArray().Length != 0)
                    {
                        ticket.AddTotal("EFECTIVO  : ", UseObject.InsertSeparatorMil(pEfectivo.Sum(d => d.Valor).ToString()));
                    }
                    if (pCheque.ToArray().Length != 0)
                    {
                        ticket.AddTotal("CHEQUE    : ", UseObject.InsertSeparatorMil(pCheque.Sum(d => d.Valor).ToString()));
                    }
                    if (pTransaccion.ToArray().Length != 0)
                    {
                        ticket.AddTotal("TRANSACCIÓN :", UseObject.InsertSeparatorMil(pTransaccion.Sum(d => d.Valor).ToString()));
                    }

                    ticket.AddFooterLine("===================================");
                    ticket.AddFooterLine(".");
                    ticket.AddFooterLine(".");
                    ticket.AddFooterLine("___________________________________");
                    ticket.AddFooterLine("Aprobado:");
                    ticket.AddFooterLine(".");
                    ticket.AddFooterLine("___________________________________");
                    ticket.AddFooterLine("Beneficiario");
                    ticket.AddFooterLine(".");
                    ticket.AddFooterLine(".");

                    ticket.AddFooterLine("Software: Digital Fact Pyme");
                    ticket.AddFooterLine("Soluciones Tecnológicas A&C.");
                    ticket.AddFooterLine("Cel. 3128068807");
                    ticket.AddFooterLine(".");

                    ticket.PrintTicket("IMPREPOS");
                    */
                }
                catch (Exception ex)
                {
                    OptionPane.MessageError("Ocurrió un error al imprimir el Egreso.\n" + ex.Message);
                }
            }
        }

        private void PrintEstadoCartera
            (DateTime fecha, string nitCliente, DataTable cartera, DataTable transacion)
        {
            /*DialogResult rta = MessageBox.Show("¿Desea visualizar la impresión del estado de cartera del cliente?", "Devolución Venta",
                MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);*/
            FrmPrint frmPrint = new FrmPrint();
            frmPrint.StringCaption = "Devolución Venta";
            frmPrint.StringMessage = "Impresión del estado de cartera del cliente";
            DialogResult rta = frmPrint.ShowDialog();

            if (!rta.Equals(DialogResult.Cancel))
            {
                try
                {
                    var frmPrintCartera = new Cliente.Cartera.FrmPrintCartera();
                    frmPrintCartera.Fecha = fecha;
                    frmPrintCartera.NitCliente = nitCliente;
                    var bCliente = new BussinesCliente();
                    var c = bCliente.ClienteAEditar(nitCliente);
                    frmPrintCartera.Cliente = c.NombresCliente;
                    frmPrintCartera.DsCartera = cartera;
                    frmPrintCartera.DsTransaccion = transacion;
                    frmPrintCartera.TotalCartera = miBussinesFactura.SaldoPorCliente(2, Factura.Proveedor.NitProveedor);

                    if (rta.Equals(DialogResult.No))
                    {
                        frmPrintCartera.ShowDialog();
                    }
                    else
                    {
                        if (rta.Equals(DialogResult.Yes))
                        {
                            Imprimir print = new Imprimir();
                            //print.Carta = true;
                            print.Report = frmPrintCartera.CargarDatos();
                            print.Print(Imprimir.TamanioPapel.Carta);
                            frmPrintCartera.ResetReport();
                        }
                    }
                }
                catch (Exception ex)
                {
                    OptionPane.MessageError(ex.Message);
                }
            }
        }

        private void PrintEstadoCarteraPos
            (DateTime fecha, string nitCliente, DataTable cartera, DataTable transacion)
        {
            DialogResult rta = MessageBox.Show("¿Desea imprimir el estado de cartera del cliente?", "Devolución Venta",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rta.Equals(DialogResult.Yes))
            {
                try
                {
                    var miBussinesCliente = new BussinesCliente();

                    var empresaRow = miBussinesEmpresa.PrintEmpresa().
                                     Tables[0].AsEnumerable().First();

                    var cliente = miBussinesCliente.ClienteAEditar(nitCliente);

                    Ticket ticket = new Ticket();

                    ticket.AddHeaderLine(empresaRow["Nombre"].ToString().ToUpper());
                    ticket.AddHeaderLine(empresaRow["Juridico"].ToString());
                    ticket.AddHeaderLine("NIT " + UseObject.InsertSeparatorMilMasDigito(empresaRow["Nit"].ToString()));
                    ticket.AddHeaderLine(empresaRow["Direccion"].ToString());
                    ticket.AddHeaderLine("Tels. " + empresaRow["Telefono"].ToString());
                    ticket.AddHeaderLine("Fecha : " + fecha.ToShortDateString());
                    ticket.AddHeaderLine("===================================");
                    ticket.AddHeaderLine("RESUMEN DE CARTERA");
                    ticket.AddHeaderLine("===================================");
                    ticket.AddHeaderLine("CLIENTE : " + cliente.NombresCliente);
                    ticket.AddHeaderLine("CC o NIT: " + cliente.NitCliente);
                    ticket.AddHeaderLine("===================================");
                    ticket.AddHeaderLine("Facturas afectadas : ");
                    ticket.AddHeaderLine(" ");
                    foreach (DataRow dTransaccion in transacion.Rows)
                    {
                        ticket.AddHeaderLine("No Factura : " + dTransaccion["Factura"].ToString());
                        ticket.AddHeaderLine("Debe       : " + UseObject.InsertSeparatorMil(
                                                               dTransaccion["Saldo"].ToString()));
                        ticket.AddHeaderLine("Abono Devol: " + UseObject.InsertSeparatorMil(
                                                               dTransaccion["Valor"].ToString()));
                        ticket.AddHeaderLine("Resta      : " + UseObject.InsertSeparatorMil(
                                                               dTransaccion["Credito"].ToString()));
                        ticket.AddHeaderLine(" ");
                    }
                    ticket.AddHeaderLine("TOTAL CARTERA : " + UseObject.InsertSeparatorMil(
                                          miBussinesFactura.SaldoPorCliente(2, Factura.Proveedor.NitProveedor).ToString()));
                    ticket.AddHeaderLine(" ");
                    ticket.AddHeaderLine(" ");
                    ticket.AddHeaderLine("===================================");
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
                    ticket.AddFooterLine("Cel. 3128068807");
                    ticket.AddFooterLine(".");

                    ticket.PrintTicket("IMPREPOS");
                }
                catch (Exception ex)
                {
                    OptionPane.MessageError(ex.Message);
                }
            }
        }

        private void PrintComprobanteDevolucion
            (string numero, string noFact, int total, string cliente, int credito, int valDev, int reintegro)
        {
            var miBussinesUsuario = new BussinesUsuario();
            var miBussinesCliente = new BussinesCliente();
            var usuario = "";
            var dsDetalle = new DataTable();
            var dsEmpresa = new DataSet();
            var dsCliente = new DataSet();
            try
            {
                dsDetalle = DsDetalle();
                dsEmpresa = miBussinesEmpresa.PrintEmpresa();
                var tUser = miBussinesUsuario.ConsultaUsuario
                    (Convert.ToInt32(AppConfiguracion.ValorSeccion("id_user")));
                if (tUser.Rows.Count != 0)
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
                frmPrint.ShowDialog();
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
        }

        private void PrintComprobanteDevolucion(string numero)
        {
            /*DialogResult rta = MessageBox.Show("¿Desea visualizar la impresión del comprobante de devolución?", "Devolución Venta",
                MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);*/
            FrmPrint frmPrint_ = new FrmPrint();
            frmPrint_.StringCaption = "Devolución Venta";
            frmPrint_.StringMessage = "Impresión del Comprobante de Devolución";
            DialogResult rta = frmPrint_.ShowDialog();

            if (!rta.Equals(DialogResult.Cancel))
            {
                var usuario = "";
                var miBussinesUsuario = new BussinesUsuario();
                var miBussinesCliente = new BussinesCliente();
                var dsEmpresa = new DataSet();
                var dsDetalle = new DataTable();
                var dsCliente = new DataSet();
                try
                {
                    dsEmpresa = miBussinesEmpresa.PrintEmpresa();
                    var devolucion = miBussinesDevolucion.DevolucionVenta(numero);
                    var dtUsuario = miBussinesUsuario.ConsultaUsuario(devolucion.IdUsuario);
                    if (dtUsuario.Rows.Count != 0)
                    {
                        var query = (from d in dtUsuario.AsEnumerable()
                                     select d).Single();
                        usuario = query["nombre"].ToString();
                    }

                    dsCliente = miBussinesCliente.PrintCliente(devolucion.Cliente);
                    dsDetalle = miBussinesDevolucion.DetalleDevolucionVenta(devolucion.Id);

                    var frmPrint = new FrmPrintFactura();

                    frmPrint.RptvFactura.LocalReport.DataSources.Clear();
                    frmPrint.RptvFactura.LocalReport.Dispose();
                    frmPrint.RptvFactura.Reset();

                    frmPrint.RptvFactura.LocalReport.DataSources.Add(
                            new ReportDataSource("DsEmpresa", dsEmpresa.Tables["Empresa"]));
                    frmPrint.RptvFactura.LocalReport.DataSources.Add(
                            new ReportDataSource("DsCliente", dsCliente.Tables["Cliente"]));
                    frmPrint.RptvFactura.LocalReport.DataSources.Add(
                            new ReportDataSource("DsDetalle", dsDetalle));

                    frmPrint.RptvFactura.LocalReport.ReportPath = 
                        AppConfiguracion.ValorSeccion("report") + @"\reports\ComprobanteDevolucion.rdlc";

                    Label NoFactura = new Label();
                    NoFactura.AutoSize = true;
                    NoFactura.Font = new System.Drawing.Font
                        ("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                    NoFactura.Text = numero;

                    var Fact = new ReportParameter();
                    Fact.Name = "No";
                    Fact.Values.Add(devolucion.Numero);
                    frmPrint.RptvFactura.LocalReport.SetParameters(Fact);

                    var pNoFact = new ReportParameter();
                    pNoFact.Name = "NoFact";
                    if (devolucion.Factura.Equals(""))
                    {
                        pNoFact.Values.Add(" ");
                    }
                    else
                    {
                        pNoFact.Values.Add("Devolución a Factura No. " + devolucion.Factura);
                    }
                    frmPrint.RptvFactura.LocalReport.SetParameters(pNoFact);

                    var pFecha = new ReportParameter();
                    pFecha.Name = "Fecha";
                    pFecha.Values.Add(devolucion.Fecha.ToShortDateString());
                    frmPrint.RptvFactura.LocalReport.SetParameters(pFecha);

                    var pSubTotal = new ReportParameter();
                    pSubTotal.Name = "SubTotal";
                    var d_ = dsDetalle.AsEnumerable().Sum(d => d.Field<int>("ValorUnit") *
                                                                  d.Field<double>("Cantidad"));
              
                    pSubTotal.Values.Add(Convert.ToInt32(d_).ToString());//(dsDetalle.AsEnumerable().Sum(d => d.Field<int>("ValorUnit") *
                                                                 // d.Field<double>("Cantidad")).ToString());
                    frmPrint.RptvFactura.LocalReport.SetParameters(pSubTotal);

                    var pDescto = new ReportParameter();
                    pDescto.Name = "Descto";
                    pDescto.Values.Add(dsDetalle.AsEnumerable().Sum(d => d.Field<int>("ValorDesto")).ToString());
                    frmPrint.RptvFactura.LocalReport.SetParameters(pDescto);

                    var d1 = dsDetalle.AsEnumerable().Sum(d => d.Field<int>("ValorIva") *
                                                                 d.Field<double>("Cantidad"));

                    var pIva = new ReportParameter();
                    pIva.Name = "Iva";
                    pIva.Values.Add(Convert.ToInt32(d1).ToString());
                    frmPrint.RptvFactura.LocalReport.SetParameters(pIva);

                    var pTotal = new ReportParameter();
                    pTotal.Name = "Total";
                    pTotal.Values.Add(dsDetalle.AsEnumerable().Sum(d => d.Field<int>("Total_")).ToString());
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
                catch (Exception ex)
                {
                    OptionPane.MessageError(ex.Message);
                }
            }
        }

        private void PrintComprobanteDevolucionPos(string numero)
        {
            DialogResult rta = MessageBox.Show("¿Desea imprimir el comprobante de devolución?", "Devolución Venta",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rta.Equals(DialogResult.Yes))
            {
                try
                {
                    var miBussinesUsuario = new BussinesUsuario();
                    var miBussinesCaja = new BussinesCaja();
                    var miBussinesCliente = new BussinesCliente();

                    var devolucion = miBussinesDevolucion.DevolucionVenta(numero);
                    var caja = miBussinesCaja.CajaId(devolucion.IdCaja);

                    PrintTicket printTicket = new PrintTicket();
                    printTicket.UseItem = false;
                    //printTicket.EsFactura = true;
                    //printTicket.Copia = false;

                    printTicket.empresaRow = this.miBussinesEmpresa.PrintEmpresa().Tables[0].AsEnumerable().First();

                    printTicket.Numero = devolucion.Numero;
                    printTicket.Fecha = devolucion.Fecha;
                    printTicket.NoCaja = caja.Numero.ToString();
                    printTicket.Usuario = miBussinesUsuario.ConsultaUsuario(devolucion.IdUsuario).AsEnumerable().First()["nombre"].ToString();
                    printTicket.Cliente = miBussinesCliente.ClienteAEditar(devolucion.Cliente);
                    printTicket.tDetalle = miBussinesDevolucion.DetalleDevolucionVenta(devolucion.Id);

                    printTicket.ImprimirDevolucionVenta();


                   /* var empresaRow = miBussinesEmpresa.PrintEmpresa().
                                     Tables[0].AsEnumerable().First();
                    
                    var usuarioName = miBussinesUsuario.ConsultaUsuario(devolucion.IdUsuario)
                                                .AsEnumerable().First()["nombre"].ToString();
                    
                    var cliente = miBussinesCliente.ClienteAEditar(devolucion.Cliente);
                    var Detalle = miBussinesDevolucion.DetalleDevolucionVenta(devolucion.Id);

                    Ticket ticket = new Ticket();

                    ticket.AddHeaderLine(empresaRow["Nombre"].ToString().ToUpper());
                    ticket.AddHeaderLine(empresaRow["Juridico"].ToString());
                    ticket.AddHeaderLine("NIT " + UseObject.InsertSeparatorMilMasDigito(empresaRow["Nit"].ToString()));
                    ticket.AddHeaderLine(empresaRow["Direccion"].ToString());
                    ticket.AddHeaderLine("Tels. " + empresaRow["Telefono"].ToString());
                    ticket.AddHeaderLine("COMPROBANTE DE DEVOLUCIÓN No " + devolucion.Numero);
                    ticket.AddHeaderLine("Fecha : " + devolucion.Fecha.ToShortDateString());
                    ticket.AddHeaderLine("Caja  : " + caja.Numero);
                    ticket.AddHeaderLine("Cajero(a) : " + usuarioName);
                    ticket.AddHeaderLine("===================================");
                    ticket.AddHeaderLine("CLIENTE : " + cliente.NombresCliente);
                    ticket.AddHeaderLine("CC o NIT: " + cliente.NitCliente);
                    ticket.AddHeaderLine("===================================");

                    foreach (DataRow dRow in Detalle.Rows)
                    {
                        ticket.AddItem(dRow["Cantidad"].ToString(),
                                       dRow["Producto"].ToString(),
                                       UseObject.InsertSeparatorMil(dRow["Total_"].ToString()));
                        var n = dRow["Cantidad"].ToString();
                        var o = dRow["Producto"].ToString();
                        var p = UseObject.InsertSeparatorMil(dRow["Total_"].ToString());
                    }
                    ticket.AddTotal("TOTAL : ", UseObject.InsertSeparatorMil(
                        Detalle.AsEnumerable().Sum(s => s.Field<int>("Total_")).ToString()));

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
                    ticket.AddFooterLine("Cel. 3128068807");
                    ticket.AddFooterLine(".");

                    ticket.PrintTicket("IMPREPOS");*/
                }
                catch (Exception ex)
                {
                    OptionPane.MessageError(ex.Message);
                }
            }
        }

        private void PrintRetiroPos(DTO.Clases.Retiro retiro)
        {
            try
            {
                DialogResult rta = MessageBox.Show("¿Desea imprimir el comprobante de retiro?", "Devolución venta",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (rta.Equals(DialogResult.Yes))
                {
                    var miBussinesEmpresa = new BussinesEmpresa();
                    var miBussinesUsuario = new BussinesUsuario();
                    var miBussinesCaja = new BussinesCaja();
                    var miBussinesTurno = new BussinesTurno();

                    DataRow empresaRow = miBussinesEmpresa.PrintEmpresa().
                            Tables[0].AsEnumerable().First();

                    var usuarioRow = miBussinesUsuario.ConsultaUsuario(retiro.Usuario.Id).
                                                                   AsEnumerable().First();
                    Ticket ticket = new Ticket();
                    ticket.UseItem = false;

                    ticket.AddHeaderLine(empresaRow["Nombre"].ToString().ToUpper());
                    ticket.AddHeaderLine(empresaRow["Juridico"].ToString());
                    ticket.AddHeaderLine("NIT " + UseObject.InsertSeparatorMilMasDigito(empresaRow["Nit"].ToString()));
                    ticket.AddHeaderLine("Régimen: " + empresaRow["Regimen"].ToString());
                    ticket.AddHeaderLine(empresaRow["Direccion"].ToString());
                    ticket.AddHeaderLine("");
                    ticket.AddHeaderLine("RECIBO DE RETIRO");
                    ticket.AddHeaderLine("");
                    ticket.AddHeaderLine("Fecha   : " + retiro.Fecha.ToShortDateString());
                    ticket.AddHeaderLine("Hora    : " + retiro.Fecha.ToShortTimeString());
                    ticket.AddHeaderLine("Usuario : " + usuarioRow["nombre"].ToString());
                    ticket.AddHeaderLine("Caja    : " + miBussinesCaja.CajaId(retiro.Caja.Id).Numero.ToString());
                    ticket.AddHeaderLine("Turno   : " + miBussinesTurno.TurnoId(retiro.Turno.Id).Numero.ToString());
                    ticket.AddHeaderLine("");
                    ticket.AddHeaderLine("");
                    foreach (var pago in retiro.Valores)
                    {
                        ticket.AddHeaderLine("Concepto : " + pago.NumeroFactura);
                        ticket.AddHeaderLine(pago.NombreFormaPago + " : " +
                            UseObject.InsertSeparatorMil(pago.Valor.ToString()));
                    }
                    ticket.AddHeaderLine("");
                    ticket.AddHeaderLine("");
                    ticket.AddHeaderLine("Frima:");
                    ticket.AddHeaderLine("");
                    ticket.AddHeaderLine("-----------------------------------");
                    ticket.PrintTicket("IMPREPOS");
                }
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
                sTotal += Convert.ToInt32(Convert.ToInt32(tRow["ValorUnitario"]) * Convert.ToDouble(tRow["Cantidad"]));
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
                vIva += Convert.ToInt32((Convert.ToInt32(tRow["TotalMasIva"]) - Convert.ToDouble(tRow["ValorMenosDescto"]))
                        * Convert.ToDouble(tRow["Cantidad"]));
                //TotalMasIva
            }
            return vIva;
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
                dgvListaArticulos.Columns["Cantidad"].ReadOnly = true;
                dgvListaArticulos.Columns["TotalMasIva"].ReadOnly = false;
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
    }
}