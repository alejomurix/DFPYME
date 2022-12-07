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

namespace Aplicacion.Compras.CuentasPorPagar
{
    public partial class FrmCuentaPagar : Form
    {
        private Empresa MiEmpresa { set; get; }

        private int IdCtaCuentaPagar { set; get; }

        private bool Transfer { set; get; }

        private Cliente Tercero { set; get; }

        private DataTable TConcepto { set; get; }

        private ToolTip miToolTip;

        private int Contador;

        private bool NumeroMatch;

        private bool FechaMatch;

        private bool ConceptoMatch;

        private bool CantidadMatch;

        private bool ValorMatch;

        private BindingSource miBindingSource;

        private ErrorProvider miError;

        private BussinesEmpresa miBussinesEmpresa;

        private BussinesTipoDocumento miBussinesTipoDoc;

        private BussinesConsecutivo miBussinesConsecutivo;

        private BussinesBeneficio miBussinesTercero;

        private BussinesRetencion miBussinesRetencion;


        private BussinesCuentaPagar miBussinesCuentaPagar;

        private bool AplicaRete;

        private int IdRubroRetencion;

        List<RetencionConcepto> Retenciones { set; get; }

        private RetencionConcepto MiRetencion { set; get; }
        
        public FrmCuentaPagar()
        {
            InitializeComponent();
            this.miToolTip = new ToolTip();
            this.Transfer = false;
            this.Contador = 1;
            this.miBindingSource = new BindingSource();
            this.NumeroMatch = false;
            this.FechaMatch = false;
            this.ConceptoMatch = false;
            this.CantidadMatch = false;
            this.ValorMatch = false;
            this.miError = new ErrorProvider();
            this.AplicaRete = false;
            this.MiRetencion = new RetencionConcepto();
            this.IdRubroRetencion = 2;
            CrearDatos();

            miBussinesEmpresa = new BussinesEmpresa();
            miBussinesTipoDoc = new BussinesTipoDocumento();
            miBussinesConsecutivo = new BussinesConsecutivo();
            miBussinesTercero = new BussinesBeneficio();
            miBussinesRetencion = new BussinesRetencion();

            miBussinesCuentaPagar = new BussinesCuentaPagar();

            try
            {
                MiEmpresa = miBussinesEmpresa.ObtenerEmpresa();
                this.IdCtaCuentaPagar = Convert.ToInt32(AppConfiguracion.ValorSeccion("ctaCuentaPagar"));
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
        }

        private void FrmCuentaPagar_Load(object sender, EventArgs e)
        {
            CargarDatos();
            CompletaEventos.Completaz +=
                new CompletaEventos.CompletaAccionz(CompletaEventos_Completaz);
            CompletaEventos.Completabo += new CompletaEventos.CompletaAccionbo(CompletaEventos_Completabo);

            this.dgvConceptos.AutoGenerateColumns = false;
            this.dgvConceptos.DataSource = this.miBindingSource;
        }

        private void FrmCuentaPagar_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData.Equals(Keys.F2))
            {
                this.tsBtnGuardar_Click(this.tsBtnGuardar, new EventArgs());
            }
            else
            {
                if (e.KeyData.Equals(Keys.Escape))
                {
                    this.Close();
                }
            }
        }

        private void tsBtnGuardar_Click(object sender, EventArgs e)
        {
            if (this.dgvConceptos.RowCount != 0)
            {
                this.txtNumero_Validating(this.txtNumero, null);
                this.dtpLimite_Validating(this.dtpLimite, null);
                if (this.Tercero != null)
                {
                    if (this.NumeroMatch && this.FechaMatch)
                    {
                        this.miError.SetError(this.txtConcepto, null);
                        this.miError.SetError(this.txtValor, null);
                        DialogResult rta = MessageBox.Show
                            ("¿Está seguro de generar el Documento", "Cuenta por Pagar",
                             MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (rta.Equals(DialogResult.Yes))
                        {
                            try
                            {
                                CuentaPagar cuenta = new CuentaPagar();
                                cuenta.IdCuenta = Convert.ToInt32(cbCuentas.SelectedValue);
                                cuenta.IdTercero = this.Tercero.IdCiudad;
                                cuenta.IdTipo = Convert.ToInt32(cbDocumento.SelectedValue);
                                cuenta.IdCaja = Convert.ToInt32(AppConfiguracion.ValorSeccion("id_caja"));
                                cuenta.IdUsuario = Convert.ToInt32(AppConfiguracion.ValorSeccion("id_user"));
                                if (Convert.ToInt32(cbDocumento.SelectedValue).Equals(3)) // Documento Equivalente.
                                {
                                    cuenta.Numero = miBussinesConsecutivo.Consecutivo("Documento");
                                }
                                else // Factura y Remisión.
                                {
                                    cuenta.Numero = txtNumero.Text;
                                }
                                cuenta.Fecha = DateTime.Now;
                                cuenta.FechaDocumento = dtpFecha.Value;
                                cuenta.FechaLimite = dtpLimite.Value;
                                cuenta.Detalles = Detalles();
                                cuenta.Retenciones.Add(MiRetencion);
                                cuenta.Id = miBussinesCuentaPagar.Ingresar(cuenta);
                                OptionPane.MessageInformation("Los datos se almacenarón con exito.");
                                if (Convert.ToInt32(cbDocumento.SelectedValue).Equals(3)) // Documento Equivalente.
                                {
                                    miBussinesConsecutivo.ActualizarConsecutivo("Documento");
                                }
                                if (cuenta.IdTipo.Equals(3))
                                {
                                    PrintDocumento(cuenta);
                                }

                                txtNit.Focus();
                                miError.SetError(txtConcepto, null);
                                miError.SetError(txtCantidad, null);
                                miError.SetError(txtValor, null);
                                this.Tercero = null;
                                this.txtTercero.Text = "";
                                this.cbDocumento.SelectedIndex = 0;
                                this.cbDocumento_SelectionChangeCommitted(this.cbDocumento, new EventArgs());
                                this.txtNumero.Text = "";
                                this.dtpFecha.Value = DateTime.Now;
                                this.dtpFecha.Value = DateTime.Now;
                                this.txtConcepto.Text = "";
                                this.txtCantidad.Text = "";
                                this.txtValor.Text = "";
                                while (this.dgvConceptos.RowCount != 0)
                                {
                                    this.dgvConceptos.Rows.RemoveAt(0);
                                }
                                TConcepto.Rows.Clear();
                                this.txtSubTotal.Text = "";
                                this.txtRetencion.Text = "";
                                this.txtTotal.Text = "";
                                if (this.Retenciones != null)
                                {
                                    this.Retenciones.Clear();
                                }
                                this.MiRetencion = new RetencionConcepto();
                                this.Contador = 0;
                                this.lblTasaRetencion.Text = "0%";
                                this.btnInfoRete.Enabled = false;
                                this.btnCambiarRetencion.Enabled = false;
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
                    OptionPane.MessageInformation("Debe ingresar un Tercero.");
                }
            }
            else
            {
                OptionPane.MessageInformation("Debe cargar al menos un concepto");
            }
        }

        private void tsBtnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtNit_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar.Equals((char)Keys.Enter))
            {
                try
                {
                    var tTercero = miBussinesTercero.BeneficiariosNit(txtNit.Text);
                    if (tTercero.Rows.Count.Equals(0))
                    {
                        DialogResult rta = MessageBox.Show("El Tercero no existe. \n¿Desea Crearlo?", "Anticipos y Préstamos",
                            MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (rta.Equals(DialogResult.Yes))
                        {
                            var frmBeneficia = new Beneficiario.FrmBeneficio();
                            frmBeneficia.txtId.Text = txtNit.Text;
                            frmBeneficia.Add = true;
                            Transfer = true;
                            frmBeneficia.ShowDialog();
                        }
                    }
                    else
                    {
                        var query = (from data in tTercero.AsEnumerable()
                                     select data).First();
                        this.Tercero = new Cliente
                        {
                            IdCiudad = Convert.ToInt32(query["id"]),
                            IdRegimen = Convert.ToInt32(query["idregimen"]),
                            NitCliente = query["nit"].ToString(),
                            NombresCliente = query["nombre"].ToString(),
                            CelularCliente = query["telefono"].ToString()
                        };
                        txtTercero.Text = "NIT o CC: " + Tercero.NitCliente + " - " + Tercero.NombresCliente;
                        txtNit.Text = "";
                        ValidarRetencion();
                        cbCuentas.Focus();
                    }
                }
                catch (Exception ex)
                {
                    OptionPane.MessageError(ex.Message);
                }
            }
        }

        private void btnBuscarTercero_Click(object sender, EventArgs e)
        {
            var frmBeneficio = new Beneficiario.FrmBeneficio();
            frmBeneficio.tcBeneficio.SelectTab(1);
            this.Transfer = true;
            miError.SetError(txtConcepto, null);
            miError.SetError(txtCantidad, null);
            miError.SetError(txtValor, null);
            frmBeneficio.ShowDialog();
        }

        private void cbDocumento_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToInt32(cbDocumento.SelectedValue).Equals(3)) // Documento Equivalente.
                {
                    txtNumero.ReadOnly = true;
                    txtNumero.Text = miBussinesConsecutivo.Consecutivo("Documento");
                }
                else // Factura y Remisión.
                {
                    txtNumero.ReadOnly = false;
                    txtNumero.Text = "";
                }
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
        }

        private void txtNumero_Validating(object sender, CancelEventArgs e)
        {
            if (!Convert.ToInt32(cbDocumento.SelectedValue).Equals(3)) // Documento Equivalente.
            {
                if (String.IsNullOrEmpty(this.txtNumero.Text))
                {
                    this.miError.SetError(this.txtNumero, "El campo Número es requerido.");
                    this.NumeroMatch = false;
                }
                else
                {
                    this.miError.SetError(this.txtNumero, null);
                    this.NumeroMatch = true;
                }
            }
            else
            {
                this.NumeroMatch = true;
            }
        }

        private void dtpLimite_Validating(object sender, CancelEventArgs e)
        {
            if (dtpLimite.Value > dtpFecha.Value && dtpLimite.Value > DateTime.Now)
            {
                this.miError.SetError(this.dtpLimite, null);
                this.FechaMatch = true;
            }
            else
            {
                this.miError.SetError(this.dtpLimite, "La fecha limite debe ser superior.");
                this.FechaMatch = false;
            }
        }

        private void txtConcepto_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar.Equals((char)Keys.Enter))
            {
                this.txtConcepto.Text = this.txtConcepto.Text.ToUpper();
                this.txtCantidad.Focus();
            }
        }

        private void txtConcepto_Validating(object sender, CancelEventArgs e)
        {
            if (!String.IsNullOrEmpty(txtConcepto.Text))
            {
                miError.SetError(txtConcepto, null);
                this.ConceptoMatch = true;
            }
            else
            {
                miError.SetError(txtConcepto, "El campo Concepto es requerido.");
                this.ConceptoMatch = false;
            }
        }

        private void txtCantidad_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar.Equals((char)Keys.Enter))
            {
                this.txtValor.Focus();
            }
        }

        private void txtCantidad_Validating(object sender, CancelEventArgs e)
        {
            if (!String.IsNullOrEmpty(txtCantidad.Text))
            {
                if (Validacion.ConFormato
                    (Validacion.TipoValidacion.NumerosYPunto, txtCantidad, miError, "El valor es incorrecto."))
                {
                    this.CantidadMatch = true;
                    miError.SetError(txtCantidad, null);
                }
                else
                {
                    this.CantidadMatch = false;
                }
            }
            else
            {
                miError.SetError(txtCantidad, "El campo Cantidad es requerido.");
                this.CantidadMatch = false;
            }
        }

        private void txtValor_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar.Equals((char)Keys.Enter))
            {
                this.btnAgregar.Focus();
                this.btnAgregar_Click(this.btnAgregar, new EventArgs());
            }
        }

        private void txtValor_Validating(object sender, CancelEventArgs e)
        {
            if (!String.IsNullOrEmpty(txtValor.Text))
            {
                if (Validacion.ConFormato
                    (Validacion.TipoValidacion.Numeros, txtValor, miError, "El valor es incorrecto."))
                {
                    this.ValorMatch = true;
                    miError.SetError(txtValor, null);
                }
                else
                {
                    this.ValorMatch = false;
                }
            }
            else
            {
                miError.SetError(txtValor, "El campo Valor es requerido.");
                this.ValorMatch = false;
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            this.txtConcepto_Validating(this.txtConcepto, null);
            this.txtCantidad_Validating(this.txtCantidad, null);
            this.txtValor_Validating(this.txtValor, null);
            if (ConceptoMatch && CantidadMatch && ValorMatch)
            {
                try
                {
                    var row = TConcepto.NewRow();
                    row["Id"] = Contador;
                    row["Producto"] = txtConcepto.Text;
                    row["Cantidad"] = Convert.ToDouble(txtCantidad.Text.Replace('.', ','));
                    row["Valor_"] = Convert.ToInt32(txtValor.Text);
                    TConcepto.Rows.Add(row);
                    this.Contador++;
                    RecargarGridView();
                    RecargarRetencion();
                    txtConcepto.Focus();
                    txtConcepto.Text = "";
                    txtCantidad.Text = "";
                    txtValor.Text = "";
                }
                catch (Exception ex)
                {
                    OptionPane.MessageError(ex.Message);
                }
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (this.dgvConceptos.RowCount != 0)
            {
                DialogResult rta = MessageBox.Show("¿Está seguro(a) de retirar el registro?", "Cuentas por Pagar",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (rta.Equals(DialogResult.Yes))
                {
                    try
                    {
                        var id = Convert.ToInt32(dgvConceptos.CurrentRow.Cells["Id"].Value);
                        var row = (from data in TConcepto.AsEnumerable()
                                   where data.Field<int>("Id").Equals(id)
                                   select data).First();
                        TConcepto.Rows.Remove(row);
                        if (TConcepto.Rows.Count != 0)
                        {
                            RecargarGridView();
                        }
                        else
                        {
                            this.dgvConceptos.Rows.RemoveAt(
                                this.dgvConceptos.CurrentCell.RowIndex);
                           // txtTotal.Text = "0";
                        }
                        txtSubTotal.Text = UseObject.InsertSeparatorMil(
                               TConcepto.AsEnumerable().Sum(s => s.Field<int>("Valor_")).ToString());
                        RecargarRetencion();
                        txtTotal.Text = UseObject.InsertSeparatorMil((UseObject.RemoveSeparatorMil(txtSubTotal.Text) -
                        UseObject.RemoveSeparatorMil(txtRetencion.Text)).ToString());
                        miError.SetError(txtConcepto, null);
                        miError.SetError(txtCantidad, null);
                        miError.SetError(txtValor, null);
                    }
                    catch (Exception ex)
                    {
                        OptionPane.MessageError(ex.Message);
                    }
                }
            }
            else
            {
                OptionPane.MessageInformation("No hay registro para retirar.");
            }
        }

        private void btnCambiarRetencion_Click(object sender, EventArgs e)
        {
            if (this.Tercero != null)
            {
                if (AplicaRete)
                {
                    miError.SetError(txtConcepto, null);
                    miError.SetError(txtCantidad, null);
                    miError.SetError(txtValor, null);
                    var frmReteCompra = new Egreso.FrmAplicaRetencion();
                    frmReteCompra.AplicaCompra = true;
                    frmReteCompra.IdTipoBeneficio = this.Tercero.IdRegimen;
                    frmReteCompra.IdTipoEmpresa = this.MiEmpresa.Regimen.IdRegimen;
                    DialogResult rta = frmReteCompra.ShowDialog();
                    if (rta.Equals(DialogResult.Yes))
                    {
                        if (this.Retenciones.Count != 0)
                        {
                            var query = this.Retenciones.First();
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
                    txtTotal.Text = UseObject.InsertSeparatorMil(Convert.ToInt32(
                        UseObject.RemoveSeparatorMil(txtSubTotal.Text) - UseObject.RemoveSeparatorMil(txtRetencion.Text)).ToString());
                }
                else
                {
                    OptionPane.MessageInformation("No hay retenciones aplciadas para el Tercero.");
                }
            }
            else
            {
                OptionPane.MessageInformation("Debe cargar un Tercero para aplicar retenciones.");
            }
        }

        private void CrearDatos()
        {
            TConcepto = new DataTable();
            TConcepto.Columns.Add(new DataColumn("Id", typeof(int)));
            TConcepto.Columns.Add(new DataColumn("Producto", typeof(string)));
            TConcepto.Columns.Add(new DataColumn("Cantidad", typeof(double)));
            TConcepto.Columns.Add(new DataColumn("Valor_", typeof(int)));
        }

        private void CargarDatos()
        {
            try
            {
                cbDocumento.DataSource = miBussinesTipoDoc.Lista();

                var lst = new List<Inventario.Producto.Criterio>();
                lst.Add(new Inventario.Producto.Criterio
                {
                    Id = this.IdCtaCuentaPagar,
                    Nombre = "CUENTAS POR PAGAR",
                });
                cbCuentas.DataSource = lst;
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
        }

        void CompletaEventos_Completaz(CompletaArgumentosDeEventoz args)
        {
            try
            {
                if (Transfer)
                {
                    txtNit.Text = ((Cliente)args.MiZona).NitCliente;
                    txtNit_KeyPress(this.txtNit, new KeyPressEventArgs((char)Keys.Enter));
                    Transfer = false;
                    cbCuentas.Focus();
                }
            }
            catch { }
        }

        void CompletaEventos_Completabo(CompletaArgumentosDeEventobo args)
        {
            try
            {
                Retenciones = (List<RetencionConcepto>)args.MiBodegabo;
            }
            catch { }
        }

        private void ValidarRetencion()
        {
            try
            {
                if (miBussinesRetencion.RetencionesAplicadasACompra
                    (MiEmpresa.Regimen.IdRegimen, Tercero.IdRegimen, IdRubroRetencion).Rows.Count != 0)
                {
                    this.AplicaRete = true;
                    btnInfoRete.Enabled = true;
                    btnCambiarRetencion.Enabled = true;
                }
                else
                {
                    this.AplicaRete = false;
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
                if (UseObject.RemoveSeparatorMil(txtSubTotal.Text) > MiRetencion.CifraPesos)
                {
                    txtRetencion.Text = UseObject.InsertSeparatorMil((Convert.ToInt32
                                (UseObject.RemoveSeparatorMil(txtSubTotal.Text) * MiRetencion.Tarifa / 100)).ToString());
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
            txtTotal.Text = UseObject.InsertSeparatorMil((UseObject.RemoveSeparatorMil(txtSubTotal.Text) -
                    UseObject.RemoveSeparatorMil(txtRetencion.Text)).ToString());
        }

        private void RecargarGridView()
        {
            IEnumerable<DataRow> query = from data in TConcepto.AsEnumerable()
                                         orderby data.Field<int>("Id") ascending
                                         select data;
            miBindingSource.DataSource = query.CopyToDataTable<DataRow>();
            txtSubTotal.Text = UseObject.InsertSeparatorMil(
                TConcepto.AsEnumerable().Sum(s => s.Field<int>("Valor_")).ToString());
        }

        private List<DetalleCuentaPagar> Detalles()
        {
            var detalles = new List<DetalleCuentaPagar>();
            foreach (DataRow row in TConcepto.Rows)
            {
                detalles.Add(new DetalleCuentaPagar
                {
                    Concepto = row["Producto"].ToString(),
                    Cantidad = Convert.ToDouble(row["Cantidad"]),
                    Valor = Convert.ToInt32(row["Valor_"])
                });
            }
            return detalles;
        }

        private void PrintDocumento(CuentaPagar cuenta)
        {
            try
            {
                FrmPrint frmPrint = new FrmPrint();
                frmPrint.StringCaption = "Cuenta por Pagar";
                frmPrint.StringMessage = "Impresión del Documento Equivalente";
                DialogResult rta = frmPrint.ShowDialog();
                if (!rta.Equals(DialogResult.Cancel))
                {
                    var frmPrintDocument = new IngresarCompra.FrmPrintFactura();
                    frmPrintDocument.Tipo = 3;
                    frmPrintDocument.numero = cuenta.Numero;
                    frmPrintDocument.Pago = "Crédito";
                    frmPrintDocument.Fecha = cuenta.Fecha;
                    frmPrintDocument.Limite = cuenta.FechaLimite;
                    frmPrintDocument.Proveedor = this.Tercero.NombresCliente;
                    frmPrintDocument.Nit = this.Tercero.NitCliente;
                    if (this.Tercero.CelularCliente.Equals(""))
                    {
                        frmPrintDocument.Telefono = "  ";
                    }
                    else
                    {
                        frmPrintDocument.Telefono = this.Tercero.CelularCliente;
                    }
                    frmPrintDocument.Direccion = " ";
                    frmPrintDocument.ReportPath = AppConfiguracion.ValorSeccion("report") + @"\reports\DocumentoEquivalenteConcepto.rdlc";
                    frmPrintDocument.DsDetalle = TConcepto;
                    var tRetenciones = miBussinesCuentaPagar.Retenciones(cuenta.Id);
                    var total = TConcepto.AsEnumerable().Sum(s => s.Field<int>("Valor_"));
                    var retencion = 0;
                    foreach (DataRow rRow in tRetenciones.Rows)
                    {
                        retencion += Convert.ToInt32(total * Convert.ToDouble(rRow["tarifa"]) / 100);
                    }
                    frmPrintDocument.Retencion = retencion;

                    if (rta.Equals(DialogResult.Yes))
                    {
                        Imprimir print = new Imprimir();
                        print.Report = frmPrintDocument.CargarDatos();
                        print.Print(Imprimir.TamanioPapel.MediaCarta);
                        frmPrintDocument.ResetRepor();
                    }
                    else
                    {
                        frmPrintDocument.ShowDialog();
                    }
                }
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
        }
    }
}