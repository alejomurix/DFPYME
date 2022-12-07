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

namespace Aplicacion.Compras.IngresarCompra.ConsultaRemision
{
    public partial class FrmConsulta : Form
    {
        #region Atributos

        private FacturaProveedor MiFactura { set; get; }

        /// <summary>
        /// Representa un objeto para los datos de criterio de consulta de Factura Proveedor.
        /// </summary>
        private CriterioFacturaProveedor miCriterio;

        /// <summary>
        /// Objeto para la lógica de negocio de Factura de Proveedor.
        /// </summary>
        private BussinesFacturaProveedor miBussinesFactura;

        private BussinesRemision miBussinesRemision;

        /// <summary>
        /// Objeto de lógica de negocio de Usuario.
        /// </summary>
        private BussinesUsuario miBussinesUsuario;

        private BussinesFormaPago miBussinesPago;

        private BussinesDevolucion miBussinesDevolucion;

        private BussinesPuc miBussinesPuc;

        private BussinesKardex miBussinesKardex;

        private BussinesInventario miBussinesInventario;

        private Kardex Kardex { set; get; }

        /// <summary>
        /// Proporciona una interfaz para indicar al usuario el error en algun control.
        /// </summary>
        private ErrorProvider miError;

        #endregion

        #region Utilidades

        /// <summary>
        /// Obtiene o establece el valor que indica si se habilita color o no en el formulario segun la configuración.
        /// </summary>
        private bool EnableColor;

        /// <summary>
        /// Obteien o establece el numero que indica que iteracion se realizo.
        /// </summary>
        private int Iteracion;

        /// <summary>
        /// Obtiene o establece el valor que indica si Chequeo la opcion de facturas anuladas o no.
        /// </summary>
        private bool ActivaChecked { set; get; }

        /// <summary>
        /// Obtiene o establece el valor que indica si se encuentra abierto el Form de Proveedor.
        /// </summary>
        private bool FormProveedor { set; get; }

        /// <summary>
        /// Objeto para hacer uso del Formulario de Proveedor.
        /// </summary>
        Proveedor.frmProveedor formProveedor;

        /// <summary>
        /// Objeto para hacer uso del Formulario de Editar Factura Proveedor.
        /// </summary>
        private FrmModificarCompra frmEditaFactura;

        /// <summary>
        /// Objeto para hacer uso del Formulario de Producto.
        /// </summary>
        FrmAgregarProducto frmProducto;

        /// <summary>
        /// Objeto para hacer uso del Formulario de Editar Registro de Producto.
        /// </summary>
        FrmEditarProducto frmEditaProducto;

        /// <summary>
        /// Obtiene o establece el valor que indica si se realiza la consulta primaria o secundaria.
        /// </summary>
        private bool BtnSearch = true;

        /// <summary>
        /// Indica si solo se realiza una transferencia de datos por consulta.
        /// </summary>
        private bool SearchProveedor = false;

        /// <summary>
        /// Obtiene o establece el valor de Codigo del Producto.
        /// </summary>
        private int CodigoProveedor;

        private string NitProveedor;

        /// <summary>
        /// Obtiene o establece el valor de la fecha inicial de consulta.
        /// </summary>
        private DateTime Fecha1;

        /// <summary>
        /// Obtiene o establece el valor de la fecha secundaria de consulta.
        /// </summary>
        private DateTime Fecha2;

        /// <summary>
        /// Obtiene o establece el valor del registro a segir o registro base.
        /// </summary>
        private int RowFactura;

        /// <summary>
        /// Obtiene o establece el número maximo de registro a cargar.
        /// </summary>
        private int RowMaxFactura;

        /// <summary>
        /// Obtiene o establece el total de registros en la base de datos.
        /// </summary>
        private long TotalRowFactura;

        /// <summary>
        /// Obtiene o establece el número total de paginas que componen la consulta.
        /// </summary>
        private long PaginasFactura;

        /// <summary>
        /// Obtiene o establece el número de la pagina actual.
        /// </summary>
        private int CurrentPageFactura;

        /// <summary>
        /// Representa un objeto para el tratamiento de codigo dinamico del Panel Tributario
        /// </summary>
        private List<PanelTributario> miPanelTributario;

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

        private ToolTip miToolTip;

        #endregion

        #region Mensajes

        /// <summary>
        /// Representa el texto: El campo Codigo es requerido.
        /// </summary>
        private const string CodigoReq = "El campo Codigo es requerido.";

        /// <summary>
        /// Representa el texto: El Codigo que ingreso tiene formato incorrecto.
        /// </summary>
        private const string CodigoFormat = "El Codigo que ingreso tiene formato incorrecto.";

        #endregion

        private int CuentaPuc;

        public FrmConsulta()
        {
            InitializeComponent();
            MiFactura = new FacturaProveedor();
            EnableColor = Convert.ToBoolean(AppConfiguracion.ValorSeccion("color"));
            miCriterio = new CriterioFacturaProveedor();
            miError = new ErrorProvider();
            miToolTip = new ToolTip();
            RowMaxFactura = 5;
            miBussinesFactura = new BussinesFacturaProveedor();
            miBussinesUsuario = new BussinesUsuario();
            miBussinesPago = new BussinesFormaPago();
            miBussinesDevolucion = new BussinesDevolucion();
            miBussinesPuc = new BussinesPuc();
            miBussinesRemision = new BussinesRemision();
            miBussinesKardex = new BussinesKardex();
            miBussinesInventario = new BussinesInventario();
            Kardex = new DTO.Clases.Kardex();
            miPanelTributario = new List<PanelTributario>();
            CuentaPuc = Convert.ToInt32(AppConfiguracion.ValorSeccion("abonocomprafac"));
        }

        private void FrmConsulta_Load(object sender, EventArgs e)
        {
            CompletaEventos.Completa += new CompletaEventos.CompletaAccion(CompletaEventos_Completo);
            CompletaEventos.ComAbonoEgreso += new CompletaEventos.ComAxAbonoEgreso(CompletaEventos_ComAbonoEgreso);
            CompletaEventos.ComAbonoFact += new CompletaEventos.ComAxAbonoFact(CompletaEventos_ComAbonoFact);
            CompletaEventos.ComAbonoRemision += new CompletaEventos.ComAxAbonoRemision(CompletaEventos_ComAbonoRemsion);
            //CompletaEventos_ComAbonoRemsion(CompletaArgumentosDeEventoRemision args)  ComAxAbonoRemision
            cbCriterio1.DataSource = miCriterio.lista1;
            cbCriterio.DataSource = miCriterio.lista;
            cbCriterio2.DataSource = miCriterio.lista2;
            assembly = System.Reflection.Assembly.GetExecutingAssembly();
            CargarRecursos();
        }

        private void FrmConsulta_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData.Equals(Keys.F2))
            {
                tsBtnAbonoGeneral_Click(this.tsBtnAbonoGeneral, new EventArgs());
            }
            else
            {
                if (e.KeyData.Equals(Keys.F3))
                {
                    tsEditarFactura_Click(this.tsEditarFactura, new EventArgs());
                }
                else
                {
                    if (e.KeyData.Equals(Keys.F4))
                    {
                        tsBtnAbono_Click(this.tsBtnAbono, new EventArgs());
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
        }

        private void FrmConsulta_FormClosing(object sender, FormClosingEventArgs e)
        {
            CerrarForms();
        }

        private void tsBtnCopia_Click(object sender, EventArgs e)
        {
            if (dgvFactura.RowCount != 0)
            {
                var registro = dgvFactura.Rows[dgvFactura.CurrentCell.RowIndex];
                if (!miBussinesFactura.EsFacturaVenta(Convert.ToInt32(registro.Cells["Id"].Value)))
                {
                    PrintDocumento(
                        Convert.ToInt32(registro.Cells["Id"].Value),
                        registro.Cells["Numero"].Value.ToString(),
                        Convert.ToInt32(registro.Cells["IdFormaPago"].Value),
                        Convert.ToDateTime(registro.Cells["FechaIngreso"].Value),
                        Convert.ToInt32(registro.Cells["CodigoP"].Value));
                }
                else
                {
                    OptionPane.MessageInformation("Esta función solo aplica a Documento Equivalente.");
                }
            }
            else
            {
                OptionPane.MessageInformation("No hay registros para imprimir.");
            }
        }

        private void tsBtnVerCompras_Click(object sender, EventArgs e)
        {
            var frmCompras = new FrmConsultaCompras();
            frmCompras.MdiParent = this.MdiParent;
            frmCompras.Show();
        }

        private void tsBtnFacturarRemision_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvFactura.RowCount != 0)
                {
                    if (dgvFactura.CurrentRow.Cells["Factura"].Value.ToString().Equals("Remision"))
                    {
                        var frmDatosFactura = new FrmDatosFactura();
                        DialogResult rta = frmDatosFactura.ShowDialog();
                        if (rta.Equals(DialogResult.Yes))
                        {
                            var remision = miBussinesRemision.ConsultaProveedor(
                                Convert.ToInt32(dgvFactura.CurrentRow.Cells["Id"].Value));
                            remision.Numero = MiFactura.Numero;
                            remision.EstadoFactura.Id = MiFactura.EstadoFactura.Id;
                            remision.FechaIngreso = MiFactura.FechaIngreso;
                            remision.FechaLimite = MiFactura.FechaLimite;
                            remision.Caja.Id = MiFactura.Caja.Id;
                            remision.Usuario.Id = MiFactura.Usuario.Id;
                            remision.Facturada = true;
                            miBussinesFactura.IngresarFactura(remision, true, false);
                            miBussinesRemision.FacturarRemisionProveedor(Convert.ToInt32(dgvFactura.CurrentRow.Cells["Id"].Value), true);
                            OptionPane.MessageInformation("La remisión se facturo con exito.");
                            if (BtnSearch)
                            {
                                btnBuscar_Click(null, null);
                            }
                            else
                            {
                                btnBuscar1_Click(null, null);
                            }
                        }
                        /*DialogResult rta = MessageBox.Show("¿Esta seguro(a) de facturar la remisión?", "Remisión de Proveedor",
                            MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (rta.Equals(DialogResult.Yes))
                        {
                            var remision = miBussinesRemision.ConsultaProveedor(
                                Convert.ToInt32(dgvFactura.CurrentRow.Cells["Id"].Value));
                            remision.Facturada = true;
                            miBussinesFactura.IngresarFactura(remision, true, false);
                            miBussinesRemision.FacturarRemisionProveedor(Convert.ToInt32(dgvFactura.CurrentRow.Cells["Id"].Value), true);
                            if (BtnSearch)
                            {
                                btnBuscar_Click(null, null);
                            }
                            else
                            {
                                btnBuscar1_Click(null, null);
                            }
                        }*/
                    }
                    else
                    {
                        OptionPane.MessageInformation("Esta remisión ya se encuentra facturada.");
                    }
                }
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
        }

        private void tsBtnDescargar_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.dgvFactura.RowCount != 0)
                {
                    if (this.dgvFactura.CurrentRow.Cells["Factura"].Value.ToString().Equals("Remision"))
                    {
                        DialogResult rta = MessageBox.Show("¿Esta seguro(a) de descargar de inventario la remisión?", "Remisión",
                            MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (rta.Equals(DialogResult.Yes))
                        {
                            foreach (DataRow pRow in this.miBussinesRemision.ConsultaProductoProveedor(
                                Convert.ToInt32(this.dgvFactura.CurrentRow.Cells["id"].Value)).Rows)
                            {
                                var inventario = new DTO.Clases.Inventario();
                                inventario.CodigoProducto = pRow["Codigo"].ToString();
                                inventario.IdMedida = Convert.ToInt32(pRow["IdMedida"]);
                                inventario.IdColor = Convert.ToInt32(pRow["IdColor"]);
                                inventario.Cantidad =
                                   this.miBussinesInventario.CantidadInventario(inventario) - Convert.ToDouble(pRow["Cantidad"]);
                                this.miBussinesInventario.ActualizarCantidadInventario(inventario);
                            }
                            miBussinesRemision.FacturarRemisionProveedor(
                                Convert.ToInt32(this.dgvFactura.CurrentRow.Cells["Id"].Value), true);
                            OptionPane.MessageInformation("La remisión se descargo con exito.");
                            if (BtnSearch)
                            {
                                btnBuscar_Click(null, null);
                            }
                            else
                            {
                                btnBuscar1_Click(null, null);
                            }
                        }
                    }
                    else
                    {
                        OptionPane.MessageInformation("La remisión ya se encuentra descargada.");
                    }
                }
                else
                {
                    OptionPane.MessageInformation("No hay remisiones para descargar.");
                }
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
        }

        private void tsBtnAbonoGeneral_Click(object sender, EventArgs e)
        {
            if (dgvFactura.RowCount != 0)
            {
                //CodigoP
                if (!FormProveedor)
                {
                    try
                    {
                        var total = SaldoAproveedor(dgvFactura.CurrentRow.Cells["Nit"].Value.ToString());
                        var frmAbono = new PagoGeneral.FrmAbonoCompra();
                       // frmAbono.MdiParent = this.MdiParent;
                        frmAbono.EsFactura = true;
                        frmAbono.CodigoProveedor = Convert.ToInt32(dgvFactura.CurrentRow.Cells["CodigoP"].Value);
                        frmAbono.IdFactura = (int)dgvFactura.CurrentRow.Cells["Id"].Value;
                        frmAbono.txtProveedor.Text = dgvFactura.CurrentRow.Cells["Proveedor"].Value.ToString();
                        frmAbono.NitProveedor = (string)dgvFactura.CurrentRow.Cells["Nit"].Value;
                        frmAbono.txtSaldo.Text = UseObject.InsertSeparatorMil(total.ToString());
                        FormProveedor = true;
                        frmAbono.ShowDialog();
                    }
                    catch (Exception ex)
                    {
                        OptionPane.MessageError(ex.Message);
                    }
                }
            }
            else
            {
                OptionPane.MessageInformation("Debe seleccionar primero un Proveedor.");
            }
        }

        private void tsSalir_Click(object sender, EventArgs e)
        {
           // CompletaEventos.CapturaEvento(false);
            this.Close();
        }

        private void cbCriterio_SelectedValueChanged(object sender, EventArgs e)
        {
            var criterio = Convert.ToInt32(cbCriterio.SelectedValue);
            if (criterio == 1)
            {
                cbCriterioProveedor.Enabled = false;
                StatusFactura.Enabled = true;
                txtCodigo.Enabled = true;
                //btnBuscarCodigo.Enabled = false;
                chkAnulada.Enabled = true;
                cbCriterio1.Enabled = true;
                cbCriterio2.Enabled = true;
                dtpFecha1.Enabled = true;
                dtpFecha2.Enabled = true;
                btnBuscar1.Enabled = true;

                btnBuscarCodigo.Enabled = false;
                cbCriterio1.SelectedIndex = 0;
                cbCriterio1_SelectionChangeCommitted(null, null);
            }
            else
            {
                if (criterio == 2)
                {
                    cbCriterioProveedor.Enabled = true;
                    StatusFactura.Enabled = true;
                    txtCodigo.Enabled = true;
                    //btnBuscarCodigo.Enabled = false;
                    chkAnulada.Enabled = true;
                    cbCriterio1.Enabled = true;
                    //cbCriterio2.Enabled = true;
                    //dtpFecha1.Enabled = true;
                    //dtpFecha2.Enabled = true;
                    //btnBuscar1.Enabled = true;

                    btnBuscarCodigo.Enabled = true;
                }
                else
                {
                    btnBuscar.Enabled = true;

                    txtCodigo.Enabled = false;
                    btnBuscarCodigo.Enabled = false;
                    chkAnulada.Enabled = false;
                    cbCriterio1.Enabled = false;
                    cbCriterio2.Enabled = false;
                    dtpFecha1.Enabled = false;
                    dtpFecha2.Enabled = false;
                    btnBuscar1.Enabled = false;
                }
            }
        }

        private void txtCodigo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                btnBuscar_Click(null, null);
            }
        }

        private void btnBuscarCodigo_Click(object sender, EventArgs e)
        {
            if (!FormProveedor)
            {
                formProveedor = new Proveedor.frmProveedor();
                formProveedor.MdiParent = this.MdiParent;
                formProveedor.Extension = true;
                formProveedor.tcProveedor.SelectTab(1);
                FormProveedor = true;
                formProveedor.Show();
                SearchProveedor = true;
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            var id = Convert.ToInt32(cbCriterio.SelectedValue);
            if (id != 3)
            {
                if (!Validacion.EsVacio(txtCodigo, miError, CodigoReq))
                {
                    if (id == 1)
                    {
                        //if (Validacion.ConFormato(Validacion.TipoValidacion.NumeroGuion,
                        //    txtCodigo, miError, CodigoFormat))
                       // {
                            ConsultaFacturaPorNumero(txtCodigo.Text);
                       // }
                    }
                    else
                    {
                        if (id == 2)
                        {
                            if (Convert.ToInt32(cbCriterioProveedor.SelectedValue).Equals(1))
                            {
                                if (Validacion.ConFormato(Validacion.TipoValidacion.Numeros,
                                    txtCodigo, miError, CodigoFormat))
                                {
                                    ConsultaFacturaPorProveedor(Convert.ToInt32(txtCodigo.Text));
                                }
                            }
                            else
                            {
                                ConsultaFacturaPorProveedor(txtCodigo.Text);
                            }
                        }
                    }
                }
            }
            else
            {
                ConsultaCreditoSaldo();
            }
            BtnSearch = true;
            dgvFactura_CellClick(null, null);
            ColorFacturaAnulada();
        }

        private void cbCriterio1_SelectionChangeCommitted(object sender, EventArgs e)
        {
            var criterio1 = Convert.ToInt32(cbCriterio1.SelectedValue);
            if (criterio1 == 1)
            {
                cbCriterio2.Enabled = false;
                dtpFecha1.Enabled = false;
                dtpFecha2.Enabled = false;
                btnBuscar1.Enabled = false;
                btnBuscar.Enabled = true;
            }
            else
            {
                cbCriterio2.Enabled = true;
                dtpFecha1.Enabled = true;
                btnBuscar1.Enabled = true;
                btnBuscar.Enabled = false;
                cbCriterio.SelectedIndex = 1;
            }
        }

        private void cbCriterio2_SelectionChangeCommitted(object sender, EventArgs e)
        {
            var criterio2 = Convert.ToInt32(cbCriterio2.SelectedValue);
            if (criterio2 == 1)
            {
                dtpFecha2.Enabled = false;
            }
            else
            {
                dtpFecha2.Enabled = true;
            }
        }

        private void btnBuscar1_Click(object sender, EventArgs e)
        {
            var criterio1 = Convert.ToInt32(cbCriterio1.SelectedValue);
            var criterio2 = Convert.ToInt32(cbCriterio2.SelectedValue);
            if (criterio1 == 2)
            {
                if (String.IsNullOrEmpty(txtCodigo.Text))
                {
                    if (criterio2 == 1)  //Factura por fecha
                    {
                        ConsultaFacturaFecha();
                    }
                    else                //Factura por periodo
                    {
                        InvertirFechas();
                        ConsultaFacturaPeriodo();
                    }
                }
                else
                {
                    if (Convert.ToInt32(cbCriterioProveedor.SelectedValue).Equals(1)) // Código del proveedor
                    {
                        if (Validacion.ConFormato(Validacion.TipoValidacion.Numeros,
                                   txtCodigo, miError, CodigoFormat))
                        {
                            if (criterio2 == 1)  //Factura por proveedor y fecha
                            {
                                // consulta codigo proveedor con fecha
                                ConsultaConProveedorFecha(Convert.ToInt32(txtCodigo.Text), dtpFecha1.Value);
                            }
                            else                //Factura por proveedor y periodo
                            {
                                InvertirFechas();
                                // consulta codigo proveedor con perido
                                ConsultaConProveedorFecha(Convert.ToInt32(txtCodigo.Text), dtpFecha1.Value, dtpFecha2.Value);
                            }
                        }
                    }
                    else  // Nit del Proveedor
                    {
                        if (criterio2 == 1)  //Factura por proveedor y fecha
                        {
                            // consulta nit proveedor con fecha
                            ConsultaConProveedorFecha(txtCodigo.Text, dtpFecha1.Value);

                        }
                        else                //Factura por proveedor y periodo
                        {
                            InvertirFechas();
                            // consulta nit proveedor con perido
                            ConsultaConProveedorFecha(txtCodigo.Text, dtpFecha1.Value, dtpFecha2.Value);

                        }
                    }
                }
                BtnSearch = false;
                dgvFactura_CellClick(null, null);
            }
        }

        private void dgvFactura_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvFactura.RowCount != 0)
            {
                var miBussinesRetencion = new BussinesRetencion();
                var id = (int)dgvFactura.CurrentRow.Cells["Id"].Value;
                var idPago = (int)dgvFactura.CurrentRow.Cells["IdFormaPago"].Value;
                try
                {
                    dgvListaArticulos.AutoGenerateColumns = false;
                    var tabla = miBussinesRemision.ConsultaProductoProveedor(id);
                    CalcularTotales(tabla);
                   /* var retenciones = miBussinesRetencion.RetencionesACompra(id);
                    txtIva.Text = "0";
                    CalcularTotales(tabla, retenciones);*/
                    //if (idPago == 2)
                    //{
                    // PagosAFactura(id);
                    //}
                    dgvListaArticulos.DataSource = tabla;
                }
                catch (Exception ex)
                {
                    OptionPane.MessageError(ex.Message);
                }
            }
            else
            {
                txtSubTotal.Text = "0";
                txtDescuento.Text = "0";
                txtIva.Text = "0";
                txtAjuste.Text = "0";
                txtTotal.Text = "0";
                txtRetencion.Text = "0";
                txtSaldoDevolucion.Text = "0";
                txtTotalPago.Text = "0";
                txtAbono.Text = "0";
                txtResta.Text = "0";
            }
        }

        private void btnInicio_Click(object sender, EventArgs e)
        {
            if (CurrentPageFactura > 1)
            {
                var paginaActual = CurrentPageFactura;
                for (int i = paginaActual; i > 1; i--)
                {
                    RowFactura = RowFactura - RowMaxFactura;
                    CurrentPageFactura--;
                }
                try
                {
                    switch (Iteracion)
                    {
                        case 1:
                            {
                                dgvFactura.DataSource = miBussinesRemision.ConsultaProveedor(CodigoProveedor, RowFactura, RowMaxFactura);
                                break;
                            }
                        case 9:
                            {
                                dgvFactura.DataSource = miBussinesRemision.ConsultaProveedorNit(NitProveedor, RowFactura, RowMaxFactura);
                                break;
                            }
                        case 2:
                            {
                                dgvFactura.DataSource = miBussinesRemision.ConsultaProveedor(Fecha1, RowFactura, RowMaxFactura);
                                break;
                            }
                        case 3:
                            {
                                dgvFactura.DataSource = miBussinesRemision.ConsultaProveedor(Fecha1, Fecha2, RowFactura, RowMaxFactura);
                                break;
                            }
                        case 4:
                            {
                                dgvFactura.DataSource = miBussinesRemision.ConsultaProveedor(CodigoProveedor, Fecha1, Fecha2, RowFactura, RowMaxFactura);
                                break;
                            }
                        case 5:
                            {
                                dgvFactura.DataSource =
                                    miBussinesRemision.ConsultaProveedor(CodigoProveedor, Fecha1, RowFactura, RowMaxFactura);
                                break;
                            }
                        case 6:
                            {
                                dgvFactura.DataSource =
                                    miBussinesRemision.ConsultaProveedor(CodigoProveedor, Fecha1, Fecha2, RowFactura, RowMaxFactura);
                                break;
                            }
                        case 7:
                            {
                                dgvFactura.DataSource =
                                    miBussinesRemision.ConsultaProveedor(NitProveedor, Fecha1, RowFactura, RowMaxFactura);
                                break;
                            }
                        case 8:
                            {
                                dgvFactura.DataSource =
                                    miBussinesRemision.ConsultaProveedor(NitProveedor, Fecha1, Fecha2, RowFactura, RowMaxFactura);
                                break;
                            }

                        /*case 1:
                            {
                                dgvFactura.DataSource = miBussinesFactura.ConsultaFacturaProveedor
                                                   (CodigoProveedor, ActivaChecked, RowFactura, RowMaxFactura);
                                break;
                            }
                        case 2:
                            {
                                dgvFactura.DataSource = miBussinesFactura.ConsultaFacturaProveedor
                                                          (Fecha1, ActivaChecked, RowFactura, RowMaxFactura);
                                break;
                            }
                        case 3:
                            {
                                dgvFactura.DataSource = miBussinesFactura.ConsultaFacturaProveedor
                                                            (Fecha1, Fecha2, ActivaChecked, RowFactura, RowMaxFactura);
                                break;
                            }
                        case 4:
                            {
                                dgvFactura.DataSource = miBussinesFactura.ConsultaFacturaProveedor
                                                              (CodigoProveedor, Fecha1, Fecha2, ActivaChecked, RowFactura, RowMaxFactura);
                                break;
                            }
                        case 5:
                            {
                                dgvFactura.DataSource =
                                    miBussinesRemision.ConsultaProveedor(CodigoProveedor, Fecha1, RowFactura, RowMaxFactura);
                                break;
                            }
                        case 6:
                            {
                                dgvFactura.DataSource =
                                    miBussinesRemision.ConsultaProveedor(CodigoProveedor, Fecha1, Fecha2, RowFactura, RowMaxFactura);
                                break;
                            }
                        case 7:
                            {
                                dgvFactura.DataSource =
                                    miBussinesRemision.ConsultaProveedor(NitProveedor, Fecha1, RowFactura, RowMaxFactura);
                                break;
                            }
                        case 8:
                            {
                                dgvFactura.DataSource =
                                    miBussinesRemision.ConsultaProveedor(NitProveedor, Fecha1, Fecha2, RowFactura, RowMaxFactura);
                                break;
                            }*/
                    }



                    /*if (Iteracion == 1)
                    {
                        dgvFactura.DataSource = miBussinesFactura.ConsultaFacturaProveedor
                                                   (CodigoProveedor, ActivaChecked, RowFactura, RowMaxFactura);
                    }
                    else
                    {
                        if (Iteracion == 2)
                        {
                            dgvFactura.DataSource = miBussinesFactura.ConsultaFacturaProveedor
                                                         (Fecha1, ActivaChecked, RowFactura, RowMaxFactura);
                        }
                        else
                        {
                            if (Iteracion == 3)
                            {
                                dgvFactura.DataSource = miBussinesFactura.ConsultaFacturaProveedor
                                                           (Fecha1, Fecha2, ActivaChecked, RowFactura, RowMaxFactura);
                            }
                            else
                            {
                                dgvFactura.DataSource = miBussinesFactura.ConsultaFacturaProveedor
                                                              (CodigoProveedor, Fecha1, Fecha2, ActivaChecked, RowFactura, RowMaxFactura);
                            }
                        }
                    }*/
                    lblStatusFactura.Text = CurrentPageFactura + " / " + PaginasFactura;
                    ColorFacturaAnulada();
                    dgvFactura_CellClick(null, null);
                }
                catch (Exception ex)
                {
                    OptionPane.MessageError(ex.Message);
                }
            }
        }

        private void btnAnterior_Click(object sender, EventArgs e)
        {
            if (CurrentPageFactura > 1)
            {
                RowFactura = RowFactura - RowMaxFactura;
                if (RowFactura <= 0)
                    RowFactura = 0;
                try
                {
                    switch (Iteracion)
                    {
                        case 1:
                            {
                                dgvFactura.DataSource = miBussinesRemision.ConsultaProveedor(CodigoProveedor, RowFactura, RowMaxFactura);
                                break;
                            }
                        case 9:
                            {
                                dgvFactura.DataSource = miBussinesRemision.ConsultaProveedorNit(NitProveedor, RowFactura, RowMaxFactura);
                                break;
                            }
                        case 2:
                            {
                                dgvFactura.DataSource = miBussinesRemision.ConsultaProveedor(Fecha1, RowFactura, RowMaxFactura);
                                break;
                            }
                        case 3:
                            {
                                dgvFactura.DataSource = miBussinesRemision.ConsultaProveedor(Fecha1, Fecha2, RowFactura, RowMaxFactura);
                                break;
                            }
                        case 4:
                            {
                                dgvFactura.DataSource = miBussinesRemision.ConsultaProveedor(CodigoProveedor, Fecha1, Fecha2, RowFactura, RowMaxFactura);
                                break;
                            }
                        case 5:
                            {
                                dgvFactura.DataSource =
                                    miBussinesRemision.ConsultaProveedor(CodigoProveedor, Fecha1, RowFactura, RowMaxFactura);
                                break;
                            }
                        case 6:
                            {
                                dgvFactura.DataSource =
                                    miBussinesRemision.ConsultaProveedor(CodigoProveedor, Fecha1, Fecha2, RowFactura, RowMaxFactura);
                                break;
                            }
                        case 7:
                            {
                                dgvFactura.DataSource =
                                    miBussinesRemision.ConsultaProveedor(NitProveedor, Fecha1, RowFactura, RowMaxFactura);
                                break;
                            }
                        case 8:
                            {
                                dgvFactura.DataSource =
                                    miBussinesRemision.ConsultaProveedor(NitProveedor, Fecha1, Fecha2, RowFactura, RowMaxFactura);
                                break;
                            }

                        /*case 1:
                            {
                                dgvFactura.DataSource = miBussinesFactura.ConsultaFacturaProveedor
                                                   (CodigoProveedor, ActivaChecked, RowFactura, RowMaxFactura);
                                break;
                            }
                        case 2:
                            {
                                dgvFactura.DataSource = miBussinesFactura.ConsultaFacturaProveedor
                                                          (Fecha1, ActivaChecked, RowFactura, RowMaxFactura);
                                break;
                            }
                        case 3:
                            {
                                dgvFactura.DataSource = miBussinesFactura.ConsultaFacturaProveedor
                                                            (Fecha1, Fecha2, ActivaChecked, RowFactura, RowMaxFactura);
                                break;
                            }
                        case 4:
                            {
                                dgvFactura.DataSource = miBussinesFactura.ConsultaFacturaProveedor
                                                              (CodigoProveedor, Fecha1, Fecha2, ActivaChecked, RowFactura, RowMaxFactura);
                                break;
                            }
                        case 5:
                            {
                                dgvFactura.DataSource =
                                    miBussinesRemision.ConsultaProveedor(CodigoProveedor, Fecha1, RowFactura, RowMaxFactura);
                                break;
                            }
                        case 6:
                            {
                                dgvFactura.DataSource =
                                    miBussinesRemision.ConsultaProveedor(CodigoProveedor, Fecha1, Fecha2, RowFactura, RowMaxFactura);
                                break;
                            }
                        case 7:
                            {
                                dgvFactura.DataSource =
                                    miBussinesRemision.ConsultaProveedor(NitProveedor, Fecha1, RowFactura, RowMaxFactura);
                                break;
                            }
                        case 8:
                            {
                                dgvFactura.DataSource =
                                    miBussinesRemision.ConsultaProveedor(NitProveedor, Fecha1, Fecha2, RowFactura, RowMaxFactura);
                                break;
                            }*/
                    }


                    /*if (Iteracion == 1)
                    {
                        dgvFactura.DataSource = miBussinesFactura.ConsultaFacturaProveedor
                                                   (CodigoProveedor, ActivaChecked, RowFactura, RowMaxFactura);
                    }
                    else
                    {
                        if (Iteracion == 2)
                        {
                            dgvFactura.DataSource = miBussinesFactura.ConsultaFacturaProveedor
                                                          (Fecha1, ActivaChecked, RowFactura, RowMaxFactura);
                        }
                        else
                        {
                            if (Iteracion == 3)
                            {
                                dgvFactura.DataSource = miBussinesFactura.ConsultaFacturaProveedor
                                                            (Fecha1, Fecha2, ActivaChecked, RowFactura, RowMaxFactura);
                            }
                            else
                            {
                                dgvFactura.DataSource = miBussinesFactura.ConsultaFacturaProveedor
                                                              (CodigoProveedor, Fecha1, Fecha2, ActivaChecked, RowFactura, RowMaxFactura);
                            }
                        }
                    }*/
                    CurrentPageFactura--;
                    lblStatusFactura.Text = CurrentPageFactura + " / " + PaginasFactura;
                    ColorFacturaAnulada();
                    dgvFactura_CellClick(null, null);
                }
                catch (Exception ex)
                {
                    OptionPane.MessageError(ex.Message);
                }
            }
        }

        private void btnSiguiente_Click(object sender, EventArgs e)
        {
            if (CurrentPageFactura < PaginasFactura)
            {
                RowFactura = RowFactura + RowMaxFactura;
                try
                {
                    switch (Iteracion)
                    {
                        case 1:
                            {
                                dgvFactura.DataSource = miBussinesRemision.ConsultaProveedor(CodigoProveedor, RowFactura, RowMaxFactura);
                                break;
                            }
                        case 9:
                            {
                                dgvFactura.DataSource = miBussinesRemision.ConsultaProveedorNit(NitProveedor, RowFactura, RowMaxFactura);
                                break;
                            }
                        case 2:
                            {
                                dgvFactura.DataSource = miBussinesRemision.ConsultaProveedor(Fecha1, RowFactura, RowMaxFactura);
                                break;
                            }
                        case 3:
                            {
                                dgvFactura.DataSource = miBussinesRemision.ConsultaProveedor(Fecha1, Fecha2, RowFactura, RowMaxFactura);
                                break;
                            }
                        case 4:
                            {
                                dgvFactura.DataSource = miBussinesRemision.ConsultaProveedor(CodigoProveedor, Fecha1, Fecha2, RowFactura, RowMaxFactura);
                                break;
                            }
                        case 5:
                            {
                                dgvFactura.DataSource = 
                                    miBussinesRemision.ConsultaProveedor(CodigoProveedor, Fecha1, RowFactura, RowMaxFactura);
                                break;
                            }
                        case 6:
                            {
                                dgvFactura.DataSource =
                                    miBussinesRemision.ConsultaProveedor(CodigoProveedor, Fecha1, Fecha2, RowFactura, RowMaxFactura);
                                break;
                            }
                        case 7:
                            {
                                dgvFactura.DataSource =
                                    miBussinesRemision.ConsultaProveedor(NitProveedor, Fecha1, RowFactura, RowMaxFactura);
                                break;
                            }
                        case 8:
                            {
                                dgvFactura.DataSource =
                                    miBussinesRemision.ConsultaProveedor(NitProveedor, Fecha1, Fecha2, RowFactura, RowMaxFactura);
                                break;
                            }
                    }
                    CurrentPageFactura++;
                    lblStatusFactura.Text = CurrentPageFactura + " / " + PaginasFactura;
                    ColorFacturaAnulada();
                    dgvFactura_CellClick(null, null);
                }
                catch (Exception ex)
                {
                    OptionPane.MessageError(ex.Message);
                }
            }
        }

        private void btnFin_Click(object sender, EventArgs e)
        {
            if (CurrentPageFactura < PaginasFactura)
            {
                var paginaActual = CurrentPageFactura;
                for (int i = paginaActual; i < PaginasFactura; i++)
                {
                    RowFactura = RowFactura + RowMaxFactura;
                    CurrentPageFactura++;
                }
                try
                {
                    switch (Iteracion)
                    {
                        case 1:
                            {
                                dgvFactura.DataSource = miBussinesRemision.ConsultaProveedor(CodigoProveedor, RowFactura, RowMaxFactura);
                                break;
                            }
                        case 9:
                            {
                                dgvFactura.DataSource = miBussinesRemision.ConsultaProveedorNit(NitProveedor, RowFactura, RowMaxFactura);
                                break;
                            }
                        case 2:
                            {
                                dgvFactura.DataSource = miBussinesRemision.ConsultaProveedor(Fecha1, RowFactura, RowMaxFactura);
                                break;
                            }
                        case 3:
                            {
                                dgvFactura.DataSource = miBussinesRemision.ConsultaProveedor(Fecha1, Fecha2, RowFactura, RowMaxFactura);
                                break;
                            }
                        case 4:
                            {
                                dgvFactura.DataSource = miBussinesRemision.ConsultaProveedor(CodigoProveedor, Fecha1, Fecha2, RowFactura, RowMaxFactura);
                                break;
                            }
                        case 5:
                            {
                                dgvFactura.DataSource =
                                    miBussinesRemision.ConsultaProveedor(CodigoProveedor, Fecha1, RowFactura, RowMaxFactura);
                                break;
                            }
                        case 6:
                            {
                                dgvFactura.DataSource =
                                    miBussinesRemision.ConsultaProveedor(CodigoProveedor, Fecha1, Fecha2, RowFactura, RowMaxFactura);
                                break;
                            }
                        case 7:
                            {
                                dgvFactura.DataSource =
                                    miBussinesRemision.ConsultaProveedor(NitProveedor, Fecha1, RowFactura, RowMaxFactura);
                                break;
                            }
                        case 8:
                            {
                                dgvFactura.DataSource =
                                    miBussinesRemision.ConsultaProveedor(NitProveedor, Fecha1, Fecha2, RowFactura, RowMaxFactura);
                                break;
                            }

                        /*case 1:
                            {
                                dgvFactura.DataSource = miBussinesFactura.ConsultaFacturaProveedor
                                                   (CodigoProveedor, ActivaChecked, RowFactura, RowMaxFactura);
                                break;
                            }
                        case 2:
                            {
                                dgvFactura.DataSource = miBussinesFactura.ConsultaFacturaProveedor
                                                          (Fecha1, ActivaChecked, RowFactura, RowMaxFactura);
                                break;
                            }
                        case 3:
                            {
                                dgvFactura.DataSource = miBussinesFactura.ConsultaFacturaProveedor
                                                            (Fecha1, Fecha2, ActivaChecked, RowFactura, RowMaxFactura);
                                break;
                            }
                        case 4:
                            {
                                dgvFactura.DataSource = miBussinesFactura.ConsultaFacturaProveedor
                                                              (CodigoProveedor, Fecha1, Fecha2, ActivaChecked, RowFactura, RowMaxFactura);
                                break;
                            }
                        case 5:
                            {
                                dgvFactura.DataSource =
                                    miBussinesRemision.ConsultaProveedor(CodigoProveedor, Fecha1, RowFactura, RowMaxFactura);
                                break;
                            }
                        case 6:
                            {
                                dgvFactura.DataSource =
                                    miBussinesRemision.ConsultaProveedor(CodigoProveedor, Fecha1, Fecha2, RowFactura, RowMaxFactura);
                                break;
                            }
                        case 7:
                            {
                                dgvFactura.DataSource =
                                    miBussinesRemision.ConsultaProveedor(NitProveedor, Fecha1, RowFactura, RowMaxFactura);
                                break;
                            }
                        case 8:
                            {
                                dgvFactura.DataSource =
                                    miBussinesRemision.ConsultaProveedor(NitProveedor, Fecha1, Fecha2, RowFactura, RowMaxFactura);
                                break;
                            }*/
                    }




                    /*if (Iteracion == 1)
                    {
                        dgvFactura.DataSource = miBussinesFactura.ConsultaFacturaProveedor
                                                   (CodigoProveedor, ActivaChecked, RowFactura, RowMaxFactura);
                    }
                    else
                    {
                        if (Iteracion == 2)
                        {
                            dgvFactura.DataSource = miBussinesFactura.ConsultaFacturaProveedor
                                                         (Fecha1, ActivaChecked, RowFactura, RowMaxFactura);
                        }
                        else
                        {
                            if (Iteracion == 3)
                            {
                                dgvFactura.DataSource = miBussinesFactura.ConsultaFacturaProveedor
                                                             (Fecha1, Fecha2, ActivaChecked, RowFactura, RowMaxFactura);
                            }
                            else
                            {
                                dgvFactura.DataSource = miBussinesFactura.ConsultaFacturaProveedor
                                                              (CodigoProveedor, Fecha1, Fecha2, ActivaChecked, RowFactura, RowMaxFactura);
                            }
                        }
                    }*/
                    lblStatusFactura.Text = CurrentPageFactura + " / " + PaginasFactura;
                    ColorFacturaAnulada();
                    dgvFactura_CellClick(null, null);
                }
                catch (Exception ex)
                {
                    OptionPane.MessageError(ex.Message);
                }
            }
        }

        private void tsEditarFactura_Click(object sender, EventArgs e)
        {
            if (dgvFactura.RowCount != 0)
            {
                if (!FormProveedor)
                {
                    frmEditaFactura = new FrmModificarCompra();
                   // frmEditaFactura.MdiParent = this.MdiParent;
                    frmEditaFactura.MiFacturaProveedor = GetFacturaProveedor();
                    FormProveedor = true;
                    if (frmEditaFactura.MiFacturaProveedor != null)
                    {
                        frmEditaFactura.ShowDialog();
                    }
                }
            }
            else
            {
                OptionPane.MessageInformation("No hay registros para editar.");
            }
        }

        private void tsBtnAbono_Click(object sender, EventArgs e)
        {
            if (dgvFactura.RowCount != 0)
            {
                /*var idBase = AppConfiguracion.ValorSeccion("id_base");
                if (!String.IsNullOrEmpty(idBase))
                {*/
                    if (!txtResta.Text.Equals("0"))
                    {
                       /* var frmAbonoVenta = new Ventas.Factura.FrmDinamicCancelar();
                        frmAbonoVenta.txtTotal.Text = txtTotal.Text;
                        frmAbonoVenta.Abono = true;
                        frmAbonoVenta.ShowDialog();*/
                        if (!FormProveedor)
                        {
                            var frmAbono = new Pago.FrmAbonoCompra();
                            //frmAbono.MdiParent = this.MdiParent;
                            frmAbono.EsFactura = false;
                            frmAbono.IdFactura = (int)dgvFactura.CurrentRow.Cells["Id"].Value;
                            frmAbono.NumeroFactura = (string)dgvFactura.CurrentRow.Cells["Numero"].Value;
                            frmAbono.NitProveedor = (string)dgvFactura.CurrentRow.Cells["Nit"].Value;
                            frmAbono.txtTotal.Text = txtResta.Text;//txtTotal.Text;//txtResta.Text;
                            frmAbono.ShowDialog();
                        }
                    }
                    else
                    {
                        OptionPane.MessageInformation("Esta Factura no presenta saldo.");
                    }
                /*}
                else
                {
                    OptionPane.MessageInformation
                    ("Debe realizar apertura de caja para ingresar un abono a Factura Proveedor.");
                }*/
            }
            else
            {
                OptionPane.MessageInformation("Debe seleccionar una factura para Abonar.");
            }
        }

        private void tsBtnSaldoProveedor_Click(object sender, EventArgs e)
        {
            //if (dgvFactura.RowCount != 0)
           // {
                //if (Convert.ToInt32(dgvFactura.CurrentRow.Cells["IdFormaPago"].Value) == 2)
                //{
                    try
                    {
                        /*var total = miBussinesFactura.SaldoAProveedor
                            (dgvFactura.CurrentRow.Cells["Nit"].Value.ToString());
                        var frmSaldo = new Saldos.FrmSaldoProveedor();
                        //frmSaldo.MdiParent = this.MdiParent;
                        frmSaldo.txtProveedor.Text = dgvFactura.CurrentRow.Cells["Proveedor"].Value.ToString();
                        frmSaldo.txtNit.Text = dgvFactura.CurrentRow.Cells["Nit"].Value.ToString();
                        frmSaldo.txtSaldo.Text = UseObject.InsertSeparatorMil(total.ToString());
                        frmSaldo.ShowDialog();*/
                         string rta = CustomControl.OptionPane.OptionBox
                        ("Ingresar clave .", "Clave", CustomControl.OptionPane.Icon.LoginAdmin);
                         if (rta.Equals("cambio2014"))
                         {
                             var frmAjusteCompra = new Compras.Cartera.FrmCompras();
                             frmAjusteCompra.MdiParent = this.MdiParent;
                             frmAjusteCompra.Show();
                         }
                    }
                    catch (Exception ex)
                    {
                        OptionPane.MessageError(ex.Message);
                    }
                //}
          /*  }
            else
            {
                OptionPane.MessageInformation("Debe seleccionar primero un Proveedor.");
            }*/
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            /*if (dgvFactura.RowCount != 0)
            {*/
                /*if (Convert.ToInt32(dgvFactura.CurrentRow.Cells["IdFormaPago"].Value) == 2)
                {*/
                    try
                    {
                        var total = miBussinesFactura.SaldoTotalCredito();
                        var frmSaldo = new Saldos.FrmSaldoTotal();
                       // frmSaldo.MdiParent = this.MdiParent;
                        frmSaldo.txtSaldo.Text = UseObject.InsertSeparatorMil(total.ToString());
                        frmSaldo.ShowDialog();
                        /*MessageBox.Show("TOTAL SALDO FACTURAS A CRÉDITO:\n"
                                      + "SALDO: $\t" + UseObject.InsertSeparatorMil(total.ToString()),
                                        "Saldo Factura Proveedor",
                                       MessageBoxButtons.OK, MessageBoxIcon.Information);*/
                    }
                    catch (Exception ex)
                    {
                        OptionPane.MessageError(ex.Message);
                    }
                //}
            //}
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

        private void tsAgregar_Click(object sender, EventArgs e)
        {
            if (dgvFactura.RowCount != 0)
            {
                if (!FormProveedor)
                {
                    frmProducto = new FrmAgregarProducto();
                    frmProducto.EsFactura = false;
                    frmProducto.NoFactura = dgvFactura.CurrentRow.Cells["Numero"].Value.ToString();
                    frmProducto.IdFactura = (int)dgvFactura.CurrentRow.Cells["Id"].Value;
                    frmProducto.CodigoProveedor = dgvFactura.CurrentRow.Cells["CodigoP"].Value.ToString();
                    frmProducto.FechaFactura = (DateTime)dgvFactura.CurrentRow.Cells["FechaIngreso"].Value;
                    frmProducto.DesctoFactura = (double)dgvFactura.CurrentRow.Cells["Descuento"].Value;
                    FormProveedor = true;
                    frmProducto.ShowDialog();
                }
            }
            else
            {
                OptionPane.MessageInformation("Debe seleccionar una Factura.");
            }
        }

        private void tsEditar_Click(object sender, EventArgs e)
        {
            var miBussinesProveedor = new BussinesProveedor();
            if (dgvListaArticulos.RowCount != 0)
            {
                if (!FormProveedor)
                {
                    var proveedor = miBussinesProveedor.ConsultarPrveedorBasico(
                                    dgvFactura.CurrentRow.Cells["Nit"].Value.ToString());

                    frmEditaProducto = new FrmEditarProducto();
                    frmEditaProducto.EsFactura = false;
                    frmEditaProducto.NoFactura = dgvFactura.CurrentRow.Cells["Numero"].Value.ToString();
                    frmEditaProducto.IdRegimen = proveedor.IdRegimen;
                    //frmEditaProducto.MdiParent = this.MdiParent;
                    var row = dgvListaArticulos.Rows[dgvListaArticulos.CurrentCell.RowIndex];
                    frmEditaProducto.ProductoFactura = GetProductoFactura();
                    frmEditaProducto.ImageColor = (Image)row.Cells["Color"].Value;
                    frmEditaProducto.DesctoFactura = (double)dgvFactura.CurrentRow.Cells["Descuento"].Value;
                    FormProveedor = true;
                    frmEditaProducto.ShowDialog();
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
                    try
                    {
                        if (miBussinesUsuario.VerificarUsuarioAdmin(Encode.Encrypt(rta)))
                        {
                            int id = (int)dgvListaArticulos.CurrentRow.Cells["Id_"].Value;
                            miBussinesRemision.EliminarProductoRemisionProveedor(id);
                            
                            var row = dgvListaArticulos.CurrentRow;
                            Kardex.Codigo = row.Cells["Codigo"].Value.ToString();
                            Kardex.IdUsuario = Convert.ToInt32(AppConfiguracion.ValorSeccion("id_user"));
                            Kardex.IdConcepto = 17;
                            Kardex.NoDocumento = dgvFactura.CurrentRow.Cells["Numero"].Value.ToString();
                            Kardex.Fecha = DateTime.Now;
                            Kardex.Cantidad = Convert.ToDouble(row.Cells["Cantidad"].Value);
                            Kardex.Valor = Convert.ToInt32(row.Cells["TotalMasIva"].Value);
                            Kardex.Total = Kardex.Cantidad * Kardex.Valor;
                            miBussinesKardex.Insertar(Kardex);

                            dgvFactura_CellClick(null, null);
                        }
                        else
                        {
                            OptionPane.MessageInformation("La contraseña es incorrecta.");
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
                OptionPane.MessageInformation("No hay registros para eliminar.");
            }
        }

        /// <summary>
        /// Completa la secuencia de datos de un formulario de estencion.
        /// </summary>
        /// <param name="args">Objeto que encapsula la información del formulario.</param>
        void CompletaEventos_Completo(CompletaArgumentosDeEvento args)
        {
            try
            {
                if (SearchProveedor)
                {
                    var proveedor = (DTO.Clases.Proveedor)args.MiObjeto;
                    txtCodigo.Text = proveedor.CodigoInternoProveedor.ToString();
                    SearchProveedor = false;
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
                if (Convert.ToInt32(args.MiObjeto).Equals(1))
                {
                    if (BtnSearch)
                    {
                        btnBuscar_Click(null, null);
                    }
                    else
                    {
                        btnBuscar1_Click(null, null);
                    }
                    dgvFactura_CellClick(null, null);
                }
                else
                {
                    if (Convert.ToInt32(args.MiObjeto).Equals(2))
                    {
                        if (dgvFactura.RowCount != 0)
                        {
                            dgvFactura_CellClick(this.dgvFactura,
                                new DataGridViewCellEventArgs(dgvFactura.CurrentCell.ColumnIndex, dgvFactura.CurrentCell.RowIndex));
                        }
                    }
                    else
                    {
                        if (Convert.ToInt32(args.MiObjeto).Equals(3))
                        {
                            this.FormProveedor = false;
                        }
                    }
                }
            }
            catch { }

            /*try
            {
                var miEgreso = (MiEgreso)args.MiObjeto;
                PrintEgreso(miEgreso.Egreso);
            }
            catch { }*/
        }
        // CompletaEventos.CapEvenAbonoRemision

        void CompletaEventos_ComAbonoRemsion(CompArgAbonoRemision args)
        {
            try
            {
                var egreso = (DTO.Clases.Egreso)args.MiObjeto;
                if (!Convert.ToBoolean(AppConfiguracion.ValorSeccion("printEgreso")))
                {
                    PrintEgreso(egreso);
                }

                if (dgvFactura.RowCount != 0)
                {
                    dgvFactura_CellClick(this.dgvFactura,
                        new DataGridViewCellEventArgs(dgvFactura.CurrentCell.ColumnIndex, dgvFactura.CurrentCell.RowIndex));
                }
            }
            catch { }
        }

        void CompletaEventos_ComAbonoEgreso(CompletaAbonoEgreso args)
        {
            try
            {
                var egreso = (DTO.Clases.Egreso)args.MiObjeto;
                if (Convert.ToBoolean(AppConfiguracion.ValorSeccion("printEgreso")))
                {
                   // PrintEgresoPos(egreso);
                }
                else
                {
                    PrintEgreso(egreso);
                }
                
                if (dgvFactura.RowCount != 0)
                {
                    dgvFactura_CellClick(this.dgvFactura,
                        new DataGridViewCellEventArgs(dgvFactura.CurrentCell.ColumnIndex, dgvFactura.CurrentCell.RowIndex));
                }
            }
            catch { }
        }

        //CompletaEventos.CapEvenAbonoFact(Formas);
        void CompletaEventos_ComAbonoFact(CompArgAbonoFact args)
        {
            try
            {
                MiFactura = (FacturaProveedor)args.MiObjeto;
            }
            catch { }
        }

        /// <summary>
        /// Carga el GridView con el resultado de la consulta de Factura por número.
        /// </summary>
        /// <param name="numero">Número de la Factura a consultar.</param>
        private void ConsultaFacturaPorNumero(string numero)
        {
            try
            {
                dgvFactura.AutoGenerateColumns = false;
                //dgvFactura.DataSource = miBussinesFactura.ConsultaFacturaProveedor(numero, chkAnulada.Checked);
                dgvFactura.DataSource = miBussinesRemision.ConsultaProveedor(numero);
                if (dgvFactura.RowCount == 0)
                {
                    LimpiarGridProducto();
                    OptionPane.MessageInformation("No se encontrarón registros con ese Número Factura.");
                }
                else
                {
                    lblStatusFactura.Text = "1 / 1";
                }
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
        }

        /// <summary>
        /// Carga el GridView con el resultado de la consulta de Factura por Codigo del Proveedor.
        /// </summary>
        /// <param name="codigo">Codigo del Proveedor a consultar.</param>
        private void ConsultaFacturaPorProveedor(int codigo)
        {
            RowFactura = 0;
            CurrentPageFactura = 1;
            Iteracion = 1;
            CodigoProveedor = codigo;
            ActivaChecked = chkAnulada.Checked;
            try
            {
                dgvFactura.AutoGenerateColumns = false;
                    dgvFactura.DataSource = 
                        miBussinesRemision.ConsultaProveedor(codigo, RowFactura, RowMaxFactura);
                if (dgvFactura.RowCount == 0)
                {
                    LimpiarGridProducto();
                    OptionPane.MessageInformation("No se encontrarón registros con ese Código de Proveedor.");
                }
                TotalRowFactura = miBussinesRemision.CountConsultaProveedor(codigo);
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
            CalcularPaginas();
        }

        private void ConsultaFacturaPorProveedor(string nit)
        {
            RowFactura = 0;
            CurrentPageFactura = 1;
            Iteracion = 9;
            NitProveedor = nit;
            ActivaChecked = chkAnulada.Checked;
            try
            {
                dgvFactura.AutoGenerateColumns = false;
                dgvFactura.DataSource = 
                    miBussinesRemision.ConsultaProveedorNit(nit, RowFactura, RowMaxFactura);
                if (dgvFactura.RowCount == 0)
                {
                    LimpiarGridProducto();
                    OptionPane.MessageInformation("No se encontrarón registros con ese Código de Proveedor.");
                }
                TotalRowFactura = miBussinesRemision.CountConsultaProveedor(nit);
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
            CalcularPaginas();
        }

        /// <summary>
        /// Carga el GridView con el resultado de la consulta de Factura por fecha de ingreso.
        /// </summary>
        private void ConsultaFacturaFecha()
        {
            RowFactura = 0;
            CurrentPageFactura = 1;
            Iteracion = 2;
            Fecha1 = dtpFecha1.Value;
            ActivaChecked = chkAnulada.Checked;
            try
            {
                dgvFactura.AutoGenerateColumns = false;
                dgvFactura.DataSource = miBussinesRemision.ConsultaProveedor(Fecha1, RowFactura, RowMaxFactura);
                if (dgvFactura.RowCount == 0)
                {
                    LimpiarGridProducto();
                    OptionPane.MessageInformation("No se encontrarón registros con esa fecha.");
                }
                TotalRowFactura = miBussinesRemision.CountConsultaProveedor(Fecha1);
                    //miBussinesFactura.GetRowsConsultaFacturaProveedor(Fecha1, ActivaChecked);
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
            CalcularPaginas();
        }

        /// <summary>
        /// Carga el GridView con el resultado de la consulta de Factura por fecha de ingreso por periodo.
        /// </summary>
        private void ConsultaFacturaPeriodo()
        {
            RowFactura = 0;
            CurrentPageFactura = 1;
            Iteracion = 3;
            Fecha1 = dtpFecha1.Value;
            Fecha2 = dtpFecha2.Value;
            ActivaChecked = chkAnulada.Checked;
            try
            {
                dgvFactura.AutoGenerateColumns = false;
                dgvFactura.DataSource = miBussinesRemision.ConsultaProveedor(Fecha1, Fecha2, RowFactura, RowMaxFactura);
                if (dgvFactura.RowCount == 0)
                {
                    LimpiarGridProducto();
                    OptionPane.MessageInformation("No se encontrarón registros entre esas fechas.");
                }
                TotalRowFactura = miBussinesRemision.CountConsultaProveedor(Fecha1, Fecha2);
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
            CalcularPaginas();
        }

        /// <summary>
        /// Carga el GridView con el resultado de la consulta de Factura por proveedor y fecha de ingreso por periodo.
        /// </summary>
        private void ConsultaFacturaPeriodoProveedor()
        {
            RowFactura = 0;
            CurrentPageFactura = 1;
            Iteracion = 4;
            CodigoProveedor = Convert.ToInt32(txtCodigo.Text);
            Fecha1 = dtpFecha1.Value;
            Fecha2 = dtpFecha2.Value;
            ActivaChecked = chkAnulada.Checked;
            try
            {
                dgvFactura.AutoGenerateColumns = false;
                dgvFactura.DataSource = miBussinesRemision.ConsultaProveedor(CodigoProveedor, Fecha1, Fecha2, RowFactura, RowMaxFactura);
                if (dgvFactura.RowCount == 0)
                {
                    LimpiarGridProducto();
                    OptionPane.MessageInformation("No se encontrarón registros con ese Código de Proveedor en esas fechas.");
                }
                TotalRowFactura = miBussinesRemision.CountConsultaProveedor(CodigoProveedor, Fecha1, Fecha2);
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
            CalcularPaginas();
        }

        private void ConsultaConProveedorFecha(int codigo, DateTime fecha)
        {
            RowFactura = 0;
            CurrentPageFactura = 1;
            Iteracion = 5;
            CodigoProveedor = codigo;
            Fecha1 = fecha;
            try
            {
                dgvFactura.AutoGenerateColumns = false;
                dgvFactura.DataSource = miBussinesRemision.ConsultaProveedor(codigo, fecha, RowFactura, RowMaxFactura);
                if (dgvFactura.RowCount == 0)
                {
                    LimpiarGridProducto();
                    OptionPane.MessageInformation("No se encontrarón registros con ese proveedor y esa fecha.");
                }
                TotalRowFactura = miBussinesRemision.CountConsultaProveedor(codigo, fecha);
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
            CalcularPaginas();
        }

        private void ConsultaConProveedorFecha(int codigo, DateTime fecha, DateTime fecha2)
        {
            RowFactura = 0;
            CurrentPageFactura = 1;
            Iteracion = 6;
            CodigoProveedor = codigo;
            Fecha1 = fecha;
            Fecha2 = fecha2;
            try
            {
                dgvFactura.AutoGenerateColumns = false;
                dgvFactura.DataSource = 
                    miBussinesRemision.ConsultaProveedor(codigo, fecha, fecha2, RowFactura, RowMaxFactura);
                if (dgvFactura.RowCount == 0)
                {
                    LimpiarGridProducto();
                    OptionPane.MessageInformation("No se encontrarón registros con ese proveedor y esa fecha.");
                }
                TotalRowFactura = miBussinesRemision.CountConsultaProveedor(codigo, fecha, fecha2);
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
            CalcularPaginas();
        }

        private void ConsultaConProveedorFecha(string nit, DateTime fecha)
        {
            RowFactura = 0;
            CurrentPageFactura = 1;
            Iteracion = 7;
            NitProveedor = nit;
            Fecha1 = fecha;
            
            try
            {
                dgvFactura.AutoGenerateColumns = false;
                dgvFactura.DataSource =
                    miBussinesRemision.ConsultaProveedor(nit, fecha, RowFactura, RowMaxFactura);
                if (dgvFactura.RowCount == 0)
                {
                    LimpiarGridProducto();
                    OptionPane.MessageInformation("No se encontrarón registros con ese proveedor y esa fecha.");
                }
                TotalRowFactura = miBussinesRemision.CountConsultaProveedor(nit, fecha);
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
            CalcularPaginas();
        }

        private void ConsultaConProveedorFecha(string nit, DateTime fecha, DateTime fecha2)
        {
            RowFactura = 0;
            CurrentPageFactura = 1;
            Iteracion = 8;
            NitProveedor = nit;
            Fecha1 = fecha;
            Fecha2 = fecha2;
            try
            {
                dgvFactura.AutoGenerateColumns = false;
                dgvFactura.DataSource =
                    miBussinesRemision.ConsultaProveedor(nit, fecha, fecha2, RowFactura, RowMaxFactura);
                if (dgvFactura.RowCount == 0)
                {
                    LimpiarGridProducto();
                    OptionPane.MessageInformation("No se encontrarón registros con ese proveedor y en ese periodo de Fechas.");
                }
                TotalRowFactura = miBussinesRemision.CountConsultaProveedor(nit, fecha, fecha2);
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
            CalcularPaginas();
        }

        //*********************************************************************

        /// <summary>
        /// Carga el GridView con el resultado de la consulta de Factura por Provedor y fecha de ingreso.
        /// </summary>
        /*private void ConsultaFacturaFechaProveedor()
        {
            CodigoProveedor = Convert.ToInt32(txtCodigo.Text);
            Fecha1 = dtpFecha1.Value;
            ActivaChecked = chkAnulada.Checked;
            try
            {
                dgvFactura.AutoGenerateColumns = false;
                dgvFactura.DataSource = miBussinesFactura.ConsultaFacturaProveedor
                    (CodigoProveedor, Fecha1, ActivaChecked);
                if (dgvFactura.RowCount == 0)
                {
                    LimpiarGridProducto();
                    OptionPane.MessageInformation("No se encontrarón registros con ese Código de Proveedor en esa fecha.");
                }
                else
                {
                    lblStatusFactura.Text = "1 / 1";
                }
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
            //lblStatusPaginaProducto.Text = 0 + " / " + 0;
        }*/

        

        private void ConsultaCreditoSaldo()
        {
            StatusFactura.Enabled = false;
            try
            {
                dgvFactura.DataSource = miBussinesFactura.ConsultaFacturasConSaldo();
                if (dgvFactura.RowCount.Equals(0))
                {
                    OptionPane.MessageInformation("No se encontrarón Facturas a Crédito con saldo.");
                }
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
        }

        //**********************************************************************

        /// <summary>
        /// Calcula y muestra el número de paginas devueltas en la consulta.
        /// </summary>
        private void CalcularPaginas()
        {
            PaginasFactura = TotalRowFactura / RowMaxFactura;
            if (TotalRowFactura % RowMaxFactura != 0)
                PaginasFactura++;
            if (CurrentPageFactura > PaginasFactura)
                CurrentPageFactura = 0;
            lblStatusFactura.Text = CurrentPageFactura + " / " + PaginasFactura;
        }

        /// <summary>
        /// Inverte el valor de las fechas en caso de que la primera sea mayor a la segunda.
        /// </summary>
        private void InvertirFechas()
        {
            if (dtpFecha1.Value > dtpFecha2.Value)
            {
                var temp = dtpFecha1.Value;
                dtpFecha1.Value = dtpFecha2.Value;
                dtpFecha2.Value = temp;
            }
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
                cbCriterioProveedor.DataSource = lst;
            }
            catch
            {
                OptionPane.MessageError("Ocurrio un error al cargar los recursos.");
            }
        }

        /// <summary>
        /// Muestra los registros de Factura anulada resaltados de color gris.
        /// </summary>
        private void ColorFacturaAnulada()
        {
            foreach (DataGridViewRow row in dgvFactura.Rows)
            {
                if (row.Cells["Estado"].Value.ToString().Equals("Anulada"))
                {
                    row.DefaultCellStyle.BackColor = System.Drawing.Color.Silver;
                }
            }
        }

        /// <summary>
        /// Consulta y calcula los totales correspondientes a la factura.
        /// </summary>
        /// <param name="tabla">Tabla que almacena los registros de articulos de la factura.</param>
        private void CalcularTotales(DataTable tabla)
        {
            try
            {
                foreach (PanelTributario panel in miPanelTributario)
                {
                    panelTributario.Controls.Remove(panel.PanelIva);
                    panelTributario.Controls.Remove(panel.TxtGravado);
                    panelTributario.Controls.Remove(panel.TxtTotalIva);
                }
                miPanelTributario.Clear();
                foreach (DataRow row in tabla.Rows)
                {
                    var valor = Convert.ToDouble(row["Valor"]) -
                        (Convert.ToDouble(row["Valor"]) * UseObject.RemoveCharacter(row["Descuento"].ToString(), '%') / 100);
                    InformacionTributaria
                        (UseObject.RemoveCharacter(row["Iva"].ToString(), '%'), row["Cantidad"].ToString(), valor.ToString());
                }
                txtSubTotal.Text = UseObject.InsertSeparatorMil
                    (Convert.ToInt32
                      (tabla.AsEnumerable().Sum(s => (s.Field<int>("Valor") * s.Field<double>("Cantidad")))).ToString()
                    );

                int valorDescuento = 0;
                foreach (DataRow row in tabla.Rows)
                {
                    valorDescuento += Convert.ToInt32((Convert.ToDouble(row["Valor"]) *
                                                       UseObject.RemoveCharacter(row["Descuento"].ToString(), '%') / 100) *
                                                       Convert.ToDouble(row["Cantidad"]));
                    /*valorDescuento += Convert.ToInt32((Convert.ToDecimal(row["Valor"]) - Convert.ToDecimal(row["ValorMenosDescto"])) *
                                                       Convert.ToDecimal(row["Cantidad"]));*/
                }

                /*var descuento = Convert.ToDouble
                      (tabla.AsEnumerable()
                       .Sum(d => ((d.Field<int>("Valor") - d.Field<double>("ValorMenosDescto")) *
                                   d.Field<double>("Cantidad"))));*/
                txtDescuento.Text = UseObject.InsertSeparatorMil(valorDescuento.ToString());

                /*txtDescuento.Text = UseObject.InsertSeparatorMil
                    (Convert.ToInt32
                      (tabla.AsEnumerable()
                       .Sum(d => ((d.Field<int>("Valor") *
                                   UseObject.RemoveCharacter(d["Descuento"].ToString(), '%') / 100) *
                                   d.Field<double>("Cantidad"))))
                      .ToString()
                    );*/

                /*txtIva.Text = UseObject.InsertSeparatorMil
                    (Convert.ToInt32
                      (tabla.AsEnumerable().Sum(i => i.Field<double>("ValorIva") )).ToString()
                    );*/
                txtIva.Text = "0";
                foreach (DataRow ivaRow in tabla.Rows)
                {
                    txtIva.Text = UseObject.InsertSeparatorMil(Convert.ToInt32(
                        UseObject.RemoveSeparatorMil(txtIva.Text) + Convert.ToDouble(ivaRow["ValorIva"])).ToString());
                }


                var ajuste = Convert.ToDouble(dgvFactura.CurrentRow.Cells["Ajuste"].Value);
                txtAjuste.Text = ajuste.ToString();

                txtTotal.Text = UseObject.InsertSeparatorMil((
                                          (UseObject.RemoveSeparatorMil(txtSubTotal.Text) -
                                           UseObject.RemoveSeparatorMil(txtDescuento.Text)) +
                                           UseObject.RemoveSeparatorMil(txtIva.Text) +
                                           ajuste).ToString());
               /* var total_ = Convert.ToInt32
                      (tabla.AsEnumerable().Sum(t => (t.Field<double>("Total"))));
                var ajuste = Convert.ToInt32(dgvFactura.CurrentRow.Cells["Ajuste"].Value);

                txtTotal.Text = UseObject.InsertSeparatorMil((total_ + ajuste).ToString());*/
                    /*(Convert.ToInt32
                      (tabla.AsEnumerable().Sum(t => (t.Field<double>("Total")))).ToString()
                    );*/




                /*if (retenciones.Rows.Count != 0)
                {
                    var tasa = Convert.ToInt32(retenciones.AsEnumerable().Single()["tarifa"]);
                    miToolTip.SetToolTip(btnInfoRete,
                                         retenciones.AsEnumerable().Single()["concepto"].ToString());
                    var totalFact = Convert.ToInt32
                                    (tabla.AsEnumerable().Sum(t => (t.Field<double>("Total"))));
                    txtRetencion.Text = UseObject.InsertSeparatorMil
                            (Convert.ToInt32(totalFact * tasa / 100).ToString());
                }
                else
                {
                    miToolTip.SetToolTip(btnInfoRete, "");
                    txtRetencion.Text = "0";
                }*/

                var saldoDev = miBussinesDevolucion.SaldoDevolucionCompra
                                            (Convert.ToInt32(dgvFactura.CurrentRow.Cells["Id"].Value));
                txtSaldoDevolucion.Text = UseObject.InsertSeparatorMil(saldoDev.ToString());

                txtTotalPago.Text = UseObject.InsertSeparatorMil((UseObject.RemoveSeparatorMil(txtTotal.Text) -
                                                                  UseObject.RemoveSeparatorMil(txtRetencion.Text) -
                                                                  saldoDev
                                                                 ).ToString());

                // Relación de pagos
                var total = miBussinesPago.TotalPagosRemisionProveedor(Convert.ToInt32(dgvFactura.CurrentRow.Cells["Id"].Value));
                if (total >= UseObject.RemoveSeparatorMil(txtTotalPago.Text))
                {
                    txtAbono.Text = UseObject.InsertSeparatorMil(total.ToString());
                    txtResta.Text = "0";
                }
                else
                {
                    txtAbono.Text = UseObject.InsertSeparatorMil(total.ToString());
                    txtResta.Text = UseObject.InsertSeparatorMil(
                        (UseObject.RemoveSeparatorMil(txtTotalPago.Text) - total).ToString());
                }
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
        }

        private void PagosAFactura(int idFactura)
        {
            try
            {
                var total = miBussinesPago.PagosAProveedor(idFactura);
                if (total > UseObject.RemoveSeparatorMil(txtTotal.Text))
                {
                    txtAbono.Text = txtTotal.Text;
                    txtResta.Text = "0";
                }
                else
                {
                    txtAbono.Text = UseObject.InsertSeparatorMil(total.ToString());
                    txtResta.Text = UseObject.InsertSeparatorMil(
                        (UseObject.RemoveSeparatorMil(txtTotal.Text) - total).ToString());
                }
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
        }

        private double SaldoAproveedor(string nit)
        {
            try
            {
                int saldoTotal = 0;
                var facturas = miBussinesFactura.FacturasDeProveedor(nit);
                foreach (DataRow fRow in facturas.Rows)
                {
                    var productos = miBussinesFactura.ConsultaProductoFacturaProveedor(Convert.ToInt32(fRow["Id"]));
                    var subTotal = Convert.ToInt32
                                      (productos.AsEnumerable().Sum(s => (s.Field<int>("Valor") * s.Field<double>("Cantidad"))));
                    int valorDescuento = 0;
                    foreach (DataRow row in productos.Rows)
                    {
                        valorDescuento += Convert.ToInt32((Convert.ToDouble(row["Valor"]) *
                                                           UseObject.RemoveCharacter(row["Descuento"].ToString(), '%') / 100) *
                                                           Convert.ToDouble(row["Cantidad"]));
                    }
                    int valorIva = 0;
                    foreach (DataRow ivaRow in productos.Rows)
                    {
                        valorIva = Convert.ToInt32(
                                    valorIva + Convert.ToDouble(ivaRow["ValorIva"]));
                    }
                    var ajuste = Convert.ToInt32(fRow["valor_ajuste"]);
                    var total = (subTotal - valorDescuento) + valorIva + ajuste;
                    var pagos = miBussinesFactura.PagosAProveedor(Convert.ToInt32(fRow["Id"]));
                    var saldo = total - pagos;
                    saldoTotal = saldoTotal + saldo;
                }
                return saldoTotal;
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
                return 0.0;
            }
        }

        private void RealizarAbono(List<DTO.Clases.FormaPago> pagos)
        {
            var miBussinesRetencion = new BussinesRetencion();
            var miBussinesBeneficio = new BussinesBeneficio();
            var miBussinesEgreso = new BussinesEgreso();
            try
            {
                var idFactura = Convert.ToInt32(dgvFactura.CurrentRow.Cells["Id"].Value);
                var tRete = miBussinesRetencion.RetencionesACompra(idFactura);
                var NumeroFactura = dgvFactura.CurrentRow.Cells["Numero"].Value.ToString();
                var tasaRete = 0.0;
                var conceptoRete = "";
                var AplicaRete = false;
                if (tRete.Rows.Count != 0)
                {
                    tasaRete = Convert.ToDouble(tRete.AsEnumerable().Single()["tarifa"]);
                    conceptoRete = tRete.AsEnumerable().Single()["concepto"].ToString();
                    AplicaRete = true;
                }
                var egreso = new DTO.Clases.Egreso();
                egreso.IdCaja = Convert.ToInt32(AppConfiguracion.ValorSeccion("id_caja"));
                egreso.IdUsuario = Convert.ToInt32(AppConfiguracion.ValorSeccion("id_user"));
                egreso.Numero = AppConfiguracion.ValorSeccion("numero-e");
                egreso.Fecha = DateTime.Now;
                var b = miBussinesBeneficio.BeneficiariosNit
                                            (dgvFactura.CurrentRow.Cells["Nit"].Value.ToString());
                var bRow = b.Rows[0];
                egreso.TipoBeneficiario = Convert.ToInt32(bRow["id"]);
                var Total = 0;
                if (AplicaRete)
                {
                    Total = Convert.ToInt32(pagos.Sum(s => s.Valor));//Convert.ToInt32(UseObject.RemoveSeparatorMil(txtAbono.Text));
                    egreso.Total = Total - Convert.ToInt32(Total * tasaRete / 100);
                }
                else
                {
                    egreso.Total = Convert.ToInt32(pagos.Sum(s => s.Valor)); //Convert.ToInt32(UseObject.RemoveSeparatorMil(txtAbono.Text));
                }
                egreso.Estado = true;
                foreach (var pago in pagos)
                {
                    if (pago.Valor != 0)
                    {
                        egreso.Pagos.Add(pago);
                    }
                }
                var concepto = "";
                if (miBussinesFactura.EsFacturaVenta(idFactura))
                {
                    concepto = "Pago Factura Proveedor Número ";
                }
                else
                {
                    concepto = "Pago a Documento Equivalente Número ";
                }
                if (AplicaRete)
                {
                    egreso.Cuentas.Add(new ConceptoEgreso
                    {
                        IdCuenta = CuentaPuc,
                        Id = Convert.ToInt32(AppConfiguracion.ValorSeccion("ctacomprafac")),
                        Nombre = concepto + NumeroFactura,
                        Numero = Total.ToString()
                    });

                    egreso.Cuentas.Add(new ConceptoEgreso
                    {
                        IdCuenta = CuentaPuc,
                        Id = Convert.ToInt32(AppConfiguracion.ValorSeccion("ctacomprafac")),
                        Nombre = conceptoRete,
                        Numero = Convert.ToInt32((Total * tasaRete / 100) * -1).ToString()
                    });
                }
                else
                {
                    egreso.Cuentas.Add(new ConceptoEgreso
                    {
                        IdCuenta = CuentaPuc,
                        Id = Convert.ToInt32(AppConfiguracion.ValorSeccion("ctaabonocomprafac")),
                        Nombre = "Abono a Factura Proveedor Número " + NumeroFactura,
                        Numero = egreso.Total.ToString()
                    });
                }
                foreach (var pago in pagos)
                {
                    if (pago.Valor != 0)
                    {
                        pago.NumeroFactura = idFactura.ToString();
                        pago.Usuario.Id = Convert.ToInt32(AppConfiguracion.ValorSeccion("id_user"));
                        pago.Caja.Id = Convert.ToInt32(AppConfiguracion.ValorSeccion("id_caja"));
                        pago.Fecha = DateTime.Now;

                        miBussinesPago.IngresaPagoAProveedor(pago, true);
                    }
                }
                miBussinesEgreso.IngresarEgreso(egreso);
                if (Convert.ToInt32(egreso.Numero) < 99)
                {
                    AppConfiguracion.SaveConfiguration
                        ("numero-e", UseObject.IncrementaConsecutivo(egreso.Numero));
                }
                else
                {
                    AppConfiguracion.SaveConfiguration
                        ("numero-e", (Convert.ToInt32(egreso.Numero) + 1).ToString());
                }
                OptionPane.MessageInformation("El abono se realizó correctamente.");
                // Print Comprobantes...
                PrintEgreso(egreso);
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
                var miBussinesFormaPago = new BussinesFormaPago();
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
                //printEgreso.MdiParent = this.MdiParent;
                printEgreso.ReportPath = AppConfiguracion.ValorSeccion("report") + @"\reports\PagoRemisionCompra.rdlc";
                printEgreso.Numero = egreso.Numero;
                printEgreso.Fecha = egreso.Fecha;
                printEgreso.Remite = dgvFactura.CurrentRow.Cells["Proveedor"].Value.ToString() + "  CC o NIT: " +
                                     dgvFactura.CurrentRow.Cells["Nit"].Value.ToString();
                var nit = dgvFactura.CurrentRow.Cells["Nit"].Value.ToString();
                var name = dgvFactura.CurrentRow.Cells["Proveedor"].Value.ToString();
                printEgreso.Cuentas = tabla;
               // printEgreso.DsFormas = miBussinesFormaPago.ListFormas(egreso.Pagos);

                printEgreso.Cheque = egreso.Pagos.Where(p => p.IdFormaPago == 2).Sum(s => s.Valor).ToString();
                printEgreso.Efectivo = egreso.Pagos.Where(p => p.IdFormaPago == 1).Sum(s => s.Valor).ToString();
                printEgreso.Transaccion = egreso.Pagos.Where(p => p.IdFormaPago == 4).Sum(s => s.Valor).ToString();
                /*printEgreso.Cheque = egreso.Pagos.Single(p => p.IdFormaPago == 2).Valor.ToString();
                printEgreso.Efectivo = egreso.Pagos.Single(p => p.IdFormaPago == 1).Valor.ToString();*/
                printEgreso.ShowDialog();
            }
        }

        private void PrintEgresoPos(DTO.Clases.Egreso egreso)
        {
            try
            {
                DialogResult rta = MessageBox.Show("¿Desea imprimir el Comprobante de Egreso?", "Factura Proveedor",
                                   MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (rta.Equals(DialogResult.Yes))
                {
                    var miBussinesCaja = new BussinesCaja();
                    var miBussinesEmpresa = new BussinesEmpresa();
                    var miBussinesBeneficia = new BussinesBeneficio();

                    var empresaRow = miBussinesEmpresa.PrintEmpresa().
                                 Tables[0].AsEnumerable().First();
                    var caja = miBussinesCaja.CajaId(egreso.IdCaja);
                    var usuario = miBussinesUsuario.ConsultaUsuario(egreso.IdUsuario).AsEnumerable().First();
                    var beneficio = miBussinesBeneficia.BeneficiarioId(egreso.TipoBeneficiario);

                    Ticket ticket = new Ticket();

                    ticket.AddHeaderLine(empresaRow["Nombre"].ToString().ToUpper());
                    ticket.AddHeaderLine(empresaRow["Juridico"].ToString());
                    ticket.AddHeaderLine("NIT " + UseObject.InsertSeparatorMilMasDigito(empresaRow["Nit"].ToString()));
                    ticket.AddHeaderLine(empresaRow["Direccion"].ToString());
                    ticket.AddHeaderLine("Tels. " + empresaRow["Telefono"].ToString());
                    ticket.AddHeaderLine("Fecha : " + egreso.Fecha.ToShortDateString() +
                                     "    Caja : " + caja.Numero.ToString());
                    ticket.AddHeaderLine("Cajero(a)  :  " + usuario["nombre"].ToString());
                    ticket.AddHeaderLine("===================================");
                    ticket.AddHeaderLine("COMPROBANTE EGRESO DE REMISIÓN Nro " + egreso.Numero);
                    ticket.AddHeaderLine("===================================");
                    ticket.AddHeaderLine("Remite a : " + beneficio.NombresCliente.ToUpper());
                    ticket.AddHeaderLine("NIT: " + UseObject.InsertSeparatorMilMasDigito(beneficio.NitCliente));
                    ticket.AddHeaderLine("===================================");
                    foreach (var cuenta in egreso.Cuentas)
                    {
                        ticket.AddItem("",
                                       cuenta.Nombre,
                                       UseObject.InsertSeparatorMil(cuenta.Numero));
                    }

                    var sTotal = 0;
                    var retencion = 0;
                    var qConcepto = egreso.Cuentas.Where(d => d.IdCuenta != 0);
                    var qRetenciones = egreso.Cuentas.Where(d => d.IdCuenta.Equals(0));
                    if (qConcepto.ToArray().Length != 0)
                    {
                        sTotal = qConcepto.Sum(d => Convert.ToInt32(d.Numero));
                    }
                    if (qRetenciones.ToArray().Length != 0)
                    {
                        retencion = qRetenciones.Sum(d => Convert.ToInt32(d.Numero));
                    }
                    ticket.AddTotal("SUBTOTAL     : ", UseObject.InsertSeparatorMil(sTotal.ToString()));
                    ticket.AddTotal("RETENCIONES  : ", UseObject.InsertSeparatorMil(retencion.ToString()));
                    ticket.AddTotal("TOTAL        : ", UseObject.InsertSeparatorMil((sTotal + retencion).ToString()));
                    ticket.AddTotal("", "");

                    var pEfectivo = egreso.Pagos.Where(d => d.IdFormaPago.Equals(1));
                    var pCheque = egreso.Pagos.Where(d => d.IdFormaPago.Equals(2));
                    if (pEfectivo.ToArray().Length != 0)
                    {
                        ticket.AddTotal("EFECTIVO  : ", UseObject.InsertSeparatorMil(pEfectivo.Sum(d => d.Valor).ToString()));
                    }
                    else
                    {
                        ticket.AddTotal("EFECTIVO  : ", "0");
                    }
                    if (pCheque.ToArray().Length != 0)
                    {
                        ticket.AddTotal("CHEQUE    : ", UseObject.InsertSeparatorMil(pCheque.Sum(d => d.Valor).ToString()));
                    }
                    else
                    {
                        ticket.AddTotal("CHEQUE    : ", "0");
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
                    
                }
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
        }

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
                                            (ivaGravado + (Convert.ToDouble(cantidad) *
                                            Convert.ToDouble(valorUnit))).ToString());
                        p.TxtTotalIva.Text = UseObject.InsertSeparatorMil(
                            (p.Iva * UseObject.RemoveSeparatorMil(p.TxtGravado.Text) / 100).ToString());
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
                                (Convert.ToDouble(cantidad) *
                                Convert.ToDouble(valorUnit)).ToString());

            ///txtTotaliva
            lstTexBox[1].Text = UseObject.InsertSeparatorMil(
                ((iva * Convert.ToDouble(lstTexBox[0].Text)) / 100).ToString());

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
        /// Limpia los registro del DataGrid de Producto.
        /// </summary>
        private void LimpiarGridProducto()
        {
            while (dgvListaArticulos.RowCount != 0)
            {
                dgvListaArticulos.Rows.RemoveAt(0);
            }
        }

        /// <summary>
        /// Obtiene el registro de Factura Proveedor seleccionado del Grid.
        /// </summary>
        /// <returns></returns>
        private FacturaProveedor GetFacturaProveedor()
        {
            try
            {
                var factura = new FacturaProveedor();
                var registro = dgvFactura.Rows[dgvFactura.CurrentCell.RowIndex];
                var facturaProveedor = miBussinesRemision.ConsultaProveedor(Convert.ToInt32(registro.Cells["Id"].Value));
                var usuarioRow = miBussinesUsuario.ConsultaUsuario(facturaProveedor.Usuario.Id).AsEnumerable().First();
                factura.Usuario.Id = facturaProveedor.Usuario.Id;
                factura.Usuario.Identificacion = Convert.ToInt32(usuarioRow["documento"]);
                factura.Usuario.Nombres = usuarioRow["nombre"].ToString();
                //var j = miBussinesFactura.
                factura.Id = Convert.ToInt32(registro.Cells["Id"].Value);
                factura.Numero = registro.Cells["Numero"].Value.ToString();
                factura.Proveedor.CodigoInternoProveedor = Convert.ToInt32(registro.Cells["CodigoP"].Value);
                factura.Proveedor.NitProveedor = registro.Cells["Nit"].Value.ToString();
                factura.Proveedor.NombreProveedor = registro.Cells["Proveedor"].Value.ToString();
                factura.EstadoFactura.Id = Convert.ToInt32(registro.Cells["IdFormaPago"].Value);
                factura.EstadoFactura.Descripcion = registro.Cells["FormaPago"].Value.ToString();
                factura.FechaIngreso = Convert.ToDateTime(registro.Cells["FechaIngreso"].Value);
                factura.FechaLimite = Convert.ToDateTime(registro.Cells["FechaLimite"].Value);
                factura.Descuento = Convert.ToDouble(registro.Cells["Descuento"].Value);
                factura.Ajuste = facturaProveedor.Ajuste;
                factura.Facturada = facturaProveedor.Facturada;
                factura.FechaFactura = facturaProveedor.FechaFactura;
                if (Convert.ToBoolean(registro.Cells["Estado"].Value))
                {
                    factura.Estado = true;
                }
                else
                {
                    factura.Estado = false;
                }
                return factura;
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
                return null;
            }
        }

        /// <summary>
        /// Obtiene un el registro del producto seleccionado en el Grid.
        /// </summary>
        /// <returns></returns>
        private ProductoFacturaProveedor GetProductoFactura()
        {
            var row = dgvListaArticulos.Rows[dgvListaArticulos.CurrentCell.RowIndex];
            var producto = new ProductoFacturaProveedor();
            producto.Id = (int)row.Cells["Id_"].Value;
            producto.IdFactura = (int)dgvFactura.CurrentRow.Cells["Id"].Value;
            producto.Producto.CodigoInternoProducto = (string)row.Cells["Codigo"].Value;
            producto.Inventario.IdMedida = (int)row.Cells["IdMedida"].Value;
            producto.Producto.ValorUnidadMedida = (string)row.Cells["Medida"].Value;
            producto.Inventario.IdColor = (int)row.Cells["IdColor"].Value;
            producto.Cantidad = (double)row.Cells["Cantidad"].Value;
            producto.Producto.ValorVentaProducto = (int)row.Cells["Valor"].Value;
            producto.Lote.Id = (int)row.Cells["IdLote"].Value;
            producto.Lote.Numero = (string)row.Cells["CLote"].Value;
            producto.Lote.Fecha = (DateTime)dgvFactura.CurrentRow.Cells["FechaIngreso"].Value;
            producto.Producto.ValorIva = UseObject.RemoveCharacter(row.Cells["Iva"].Value.ToString(), '%');
            producto.Producto.Descuento = UseObject.RemoveCharacter(row.Cells["DesctoProducto"].Value.ToString(), '%');
            return producto;
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
            if (frmEditaFactura != null)
            {
                frmEditaFactura.Close();
            }
            if (frmProducto != null)
            {
                frmProducto.Close();
            }
            if (frmEditaProducto != null)
            {
                frmEditaProducto.Close();
            }
            CompletaEventos.CapturaEvento(false);
        }

        private void PrintDocumento(int id, string numero, int idPago, DateTime fecha, int codProveedor)
        {
            try
            {
                var miBussinesProveedor = new BussinesProveedor();
                var frmPrintDocument = new FrmPrintFactura();
                frmPrintDocument.numero = numero;
                if (idPago.Equals(1))
                {
                    frmPrintDocument.Pago = "Contado";
                }
                else
                {
                    frmPrintDocument.Pago = "Crédito";
                }
                frmPrintDocument.Fecha = fecha;
                var proveedor = miBussinesProveedor.ProveedorAEditar(codProveedor);
                frmPrintDocument.Proveedor = proveedor.RazonSocialProveedor;
                frmPrintDocument.Nit = proveedor.NitProveedor;
                frmPrintDocument.Telefono = proveedor.CelularProveedor;
                frmPrintDocument.Direccion = proveedor.DireccionProveedor + " " + proveedor.Ciudad +
                                             " " + proveedor.Departamento;
                frmPrintDocument.DsDetalle = miBussinesFactura.PrintDetalleFactura(id);
                frmPrintDocument.ShowDialog();
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
        }
    }

    internal class MiEgreso
    {
        public string Egreso { set; get; }
    }

    /// <summary>
    /// Representa un clase para la estructura de criterios de consulta de factura proveedor.
    /// </summary>
    internal class CriterioFacturaProveedor
    {
        /// <summary>
        /// Obtiene o estable el primer listado de criterio de factura proveedor.
        /// </summary>
        public List<Inventario.Producto.Criterio> lista { set; get; }

        /// <summary>
        /// Obtiene o estable el segundo listado de criterio de factura proveedor.
        /// </summary>
        public List<Inventario.Producto.Criterio> lista1 { set; get; }

        /// <summary>
        /// Obtiene o estable el tercer listado de criterio de factura proveedor.
        /// </summary>
        public List<Inventario.Producto.Criterio> lista2 { set; get; }

        /// <summary>
        /// Inicializa una nueva instancia de la clase CriterioFacturaProveedor.
        /// </summary>
        public CriterioFacturaProveedor()
        {
            lista = new List<Inventario.Producto.Criterio>();
            lista.Add(new Inventario.Producto.Criterio
            {
                Id = 1,
                Nombre = "Número"
            });
            lista.Add(new Inventario.Producto.Criterio
            {
                Id = 2,
                Nombre = "Proveedor"
            });

           /* lista.Add(new Inventario.Producto.Criterio
            {
                Id = 3,
                Nombre = "Crédito con saldo"
            });*/

            lista1 = new List<Inventario.Producto.Criterio>();
            lista1.Add(new Inventario.Producto.Criterio
            {
                Id = 1,
                Nombre = " "
            });
            lista1.Add(new Inventario.Producto.Criterio
            {
                Id = 2,
                Nombre = "Fecha Ingreso"
            });

            lista2 = new List<Inventario.Producto.Criterio>();
            lista2.Add(new Inventario.Producto.Criterio
            {
                Id = 1,
                Nombre = "Fecha Simple"
            });
            lista2.Add(new Inventario.Producto.Criterio
            {
                Id = 2,
                Nombre = "Periodo de Fecha"
            });
        }
    }
}