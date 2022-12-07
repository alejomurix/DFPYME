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
using Utilities;
using DTO.Clases;
using Microsoft.Reporting.WinForms;

namespace Aplicacion.Compras.CuentasPorPagar
{
    public partial class FrmConsulta : Form
    {
        private int IdCuentaAnticipo;

        private int IdCuentaPrestamo;

        private ToolTip miToolTip;

        private bool TipoPago { set; get; }

        private bool Transfer { set; get; }

        private bool BtnSearch { set; get; }

        private RetencionConcepto Retencion { set; get; }

        /// <summary>
        /// Obteien o establece el numero que indica que iteracion se realizo.
        /// </summary>
        private int Iteracion;

        /// <summary>
        /// Obtiene o establece el valor del registro a segir o registro base.
        /// </summary>
        private int RowCuenta;

        /// <summary>
        /// Obtiene o establece el número maximo de registro a cargar.
        /// </summary>
        private int RowMaxCuenta;

        /// <summary>
        /// Obtiene o establece el total de registros en la base de datos.
        /// </summary>
        private long TotalRowCuenta;

        /// <summary>
        /// Obtiene o establece el número total de paginas que componen la consulta.
        /// </summary>
        private long PaginasCuenta;

        /// <summary>
        /// Obtiene o establece el número de la pagina actual.
        /// </summary>
        private int CurrentPageCuenta;

        private string NitTercero;

        private DateTime FechaActual;

        private DateTime FechaActual2;


        private ErrorProvider miError;

        private BussinesUsuario miBussinesUsuario;

        private BussinesCuentaPagar miBussinesCuentaPagar;

        private BussinesAnticipo miBussinesAnticipo;

        private BussinesConsecutivo miBussinesConsecutivo;

        private BussinesEgreso miBussinesEgreso;

        private BussinesBeneficio miBussinesTercero;

        public FrmConsulta()
        {
            InitializeComponent();
            this.TipoPago = false;
            this.Transfer = false;
            this.BtnSearch = false;
            //this.IdCuentaAnticipo = 3;
            //this.IdCuentaPrestamo = 4;
            this.miToolTip = new ToolTip();
            this.Retencion = new RetencionConcepto();
            this.RowMaxCuenta = 8;
            this.miError = new ErrorProvider();
            this.miBussinesUsuario = new BussinesUsuario();
            this.miBussinesCuentaPagar = new BussinesCuentaPagar();
            this.miBussinesAnticipo = new BussinesAnticipo();
            this.miBussinesConsecutivo = new BussinesConsecutivo();
            this.miBussinesEgreso = new BussinesEgreso();
            this.miBussinesTercero = new BussinesBeneficio();
            try
            {
                this.IdCuentaAnticipo = Convert.ToInt32(AppConfiguracion.ValorSeccion("ctaAnticipo"));
                this.IdCuentaPrestamo = Convert.ToInt32(AppConfiguracion.ValorSeccion("ctaPrestamo"));
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
        }

        private void FrmConsulta_Load(object sender, EventArgs e)
        {
            CargarDatos();
            CompletaEventos.Completaz +=
                new CompletaEventos.CompletaAccionz(CompletaEventos_Completaz);
            CompletaEventos.Completa += new CompletaEventos.CompletaAccion(CompletaEventos_Completa);
        }

        private void tsBtnTodos_Click(object sender, EventArgs e)
        {
            try
            {
                this.Iteracion = 1;
                this.BtnSearch = false;
                this.RowCuenta = 0;
                this.CurrentPageCuenta = 1;
                this.dgvFactura.AutoGenerateColumns = false;
                this.dgvFactura.DataSource = 
                    miBussinesCuentaPagar.CuentasPorPagar(RowCuenta, RowMaxCuenta);
                this.TotalRowCuenta = miBussinesCuentaPagar.GetRowsCuentasPorPagar();
                CalcularPaginas();
                ColorearPagadas();
                this.dgvFactura_CellClick(this.dgvFactura, null);
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
        }

        private void tsBtnImprimir_Click(object sender, EventArgs e)
        {
            try
            {
                var tabla = new DataTable();
                if (Iteracion != 0)
                {
                    switch (Iteracion)
                    {
                        case 1:
                            {
                                tabla = miBussinesCuentaPagar.CuentasPorPagar();
                                break;
                            }
                        case 2:
                            {
                                tabla = miBussinesCuentaPagar.CuentasPorPagar(this.NitTercero);
                                break;
                            }
                        case 3:
                            {
                                tabla = miBussinesCuentaPagar.CuentasPorPagar(this.FechaActual);
                                break;
                            }
                        case 4:
                            {
                                tabla = miBussinesCuentaPagar.CuentasPorPagar(this.FechaActual, this.FechaActual2);
                                break;
                            }
                        case 5:
                            {
                                tabla = miBussinesCuentaPagar.CuentasPorPagar(this.NitTercero, this.FechaActual);
                                break;
                            }
                        case 6:
                            {
                                tabla = miBussinesCuentaPagar.CuentasPorPagar(this.NitTercero, this.FechaActual, this.FechaActual2);
                                break;
                            }
                    }
                    var miBussinesEmpresa = new BussinesEmpresa();
                    var frmPrint = new Egreso.FrmPrintInforme();

                    frmPrint.rpvEgresos.LocalReport.DataSources.Clear();
                    frmPrint.rpvEgresos.LocalReport.Dispose();
                    frmPrint.rpvEgresos.Reset();

                    frmPrint.rpvEgresos.LocalReport.DataSources.Add(
                    new ReportDataSource("DsEmpresa",
                        miBussinesEmpresa.PrintEmpresa().Tables[0]));
                    frmPrint.rpvEgresos.LocalReport.DataSources.Add(
                    new ReportDataSource("DsCuentaPorPagar", tabla));

                    frmPrint.rpvEgresos.LocalReport.ReportPath =
                        AppConfiguracion.ValorSeccion("report") + @"\reports\InformeDeCuentasPorPagar.rdlc";

                    var pFecha = new ReportParameter();
                    pFecha.Name = "Consulta";
                    if (this.Iteracion.Equals(1))
                    {
                        pFecha.Values.Add("Fecha: " + DateTime.Now.ToShortDateString());
                    }
                    else
                    {
                        if (Convert.ToInt32(this.cbFecha.SelectedValue).Equals(1))
                        {
                            pFecha.Values.Add("Fecha: " + this.FechaActual.ToShortDateString());
                        }
                        else
                        {
                            pFecha.Values.Add("Periodo: " + this.FechaActual.ToShortDateString() + " a " + this.FechaActual2.ToShortDateString());
                        }
                    }
                    frmPrint.rpvEgresos.LocalReport.SetParameters(pFecha);

                    frmPrint.rpvEgresos.RefreshReport();
                    frmPrint.ShowDialog();
                }
                else
                {
                    OptionPane.MessageInformation("No hay consulta para imprimir.");
                }
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
        }

        private void tsBtnAbono_Click(object sender, EventArgs e)
        {
            if (this.dgvFactura.RowCount != 0)
            {
                if (!txtResta.Text.Equals("0"))
                {
                    if (Convert.ToBoolean(this.dgvFactura.CurrentRow.Cells["Estado"].Value))
                    {
                        var frmAbono = new FrmPago();
                        frmAbono.txtTotal.Text = txtResta.Text;
                        frmAbono.txtAnticipos.Text = UseObject.InsertSeparatorMil(Anticipos
                            (this.IdCuentaAnticipo, Convert.ToInt32(this.dgvFactura.CurrentRow.Cells["IdTercero"].Value)).ToString());
                        frmAbono.txtPrestamos.Text = UseObject.InsertSeparatorMil(Anticipos
                            (this.IdCuentaPrestamo, Convert.ToInt32(this.dgvFactura.CurrentRow.Cells["IdTercero"].Value)).ToString());
                        this.Transfer = true;
                        this.TipoPago = false;
                        frmAbono.ShowDialog();
                    }
                    else
                    {
                        OptionPane.MessageInformation("La Cuenta por Pagar se encuentra anulada.");
                    }
                }
                else
                {
                    OptionPane.MessageInformation("La Cuenta por Pagar se encuentra saldada.");
                }
            }
            else
            {
                OptionPane.MessageInformation("No hay registros para pagar.");
            }
        }

       /* private void tsBtnAbonoGeneral_Click(object sender, EventArgs e)
        {
            if (this.dgvFactura.RowCount != 0)
            {
                if (!txtResta.Text.Equals("0"))
                {
                    var frmAbono = new FrmPago();
                    frmAbono.txtTotal.Text = txtResta.Text;
                    frmAbono.txtAnticipos.Text = UseObject.InsertSeparatorMil(Anticipos
                        (this.IdCuentaAnticipo, Convert.ToInt32(this.dgvFactura.CurrentRow.Cells["IdTercero"].Value)).ToString());
                    frmAbono.txtPrestamos.Text = UseObject.InsertSeparatorMil(Anticipos
                        (this.IdCuentaPrestamo, Convert.ToInt32(this.dgvFactura.CurrentRow.Cells["IdTercero"].Value)).ToString());
                    this.Transfer = true;
                    this.TipoPago = true;
                    frmAbono.ShowDialog();
                }
                else
                {
                    OptionPane.MessageInformation("La Cuenta por Pagar se encuentra saldada.");
                }
            }
            else
            {
                OptionPane.MessageInformation("No hay registros para pagar.");
            }
        }*/

        private void tsBtnAnular_Click(object sender, EventArgs e)
        {
            if (this.dgvFactura.RowCount != 0)
            {
                if (Convert.ToBoolean(this.dgvFactura.CurrentRow.Cells["Estado"].Value))
                {
                    if (this.txtAbonos.Text.Equals("0") && this.txtCruces.Text.Equals("0"))
                    {
                        DialogResult rta = MessageBox.Show("¿Esta seguro(a) de querer anular la cuenta?", "Consultas de cuentas por pagar",
                            MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (rta.Equals(DialogResult.Yes))
                        {
                            try
                            {
                                miBussinesCuentaPagar.EditarCuentaPagarAnular
                                    (Convert.ToInt32(this.dgvFactura.CurrentRow.Cells["IdCuenta"].Value));
                                if (this.BtnSearch)
                                {
                                    this.btnBuscar_Click(this.btnBuscar, new EventArgs());
                                }
                                else
                                {
                                    this.tsBtnTodos_Click(this.tsBtnTodos, new EventArgs()); 
                                }
                                OptionPane.MessageInformation("La cuenta se anulo con exito.");
                            }
                            catch (Exception ex)
                            {
                                OptionPane.MessageError(ex.Message);
                            }
                        }
                    }
                    else
                    {
                        OptionPane.MessageInformation("No se puede anular la cuenta por pagar.");
                    }
                }
                else
                {
                    OptionPane.MessageInformation("La cuenta por pagar ya se encuentra anulada.");
                }
            }
            else
            {
                OptionPane.MessageInformation("No hay registros para anular.");
            }
        }

        private void tsSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cbCriterio_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (Convert.ToInt32(cbCriterio.SelectedValue).Equals(1))
            {
                this.txtNit.Enabled = true;
                this.btnBuscarTercero.Enabled = true;
            }
            else
            {
                this.txtNit.Enabled = false;
                this.btnBuscarTercero.Enabled = false;
            }
        }

        private void btnBuscarTercero_Click(object sender, EventArgs e)
        {
            var frmBeneficio = new Beneficiario.FrmBeneficio();
            frmBeneficio.tcBeneficio.SelectTab(1);
            this.Transfer = true;
            /*miError.SetError(txtConcepto, null);
            miError.SetError(txtCantidad, null);
            miError.SetError(txtValor, null);*/
            frmBeneficio.ShowDialog();
        }

        private void txtNit_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar.Equals((char)Keys.Enter))
            {
                btnBuscar_Click(txtNit, new EventArgs());
            }
        }

        private void cbFecha_SelectionChangeCommitted(object sender, EventArgs e)
        {
            switch (Convert.ToInt32(cbFecha.SelectedValue))
            {
                case 1:
                    {
                        dtpFecha1.Enabled = false;
                        dtpFecha2.Enabled = false;
                        break;
                    }
                case 2:
                    {
                        dtpFecha1.Enabled = true;
                        dtpFecha2.Enabled = false;
                        break;
                    }
                case 3:
                    {
                        dtpFecha1.Enabled = true;
                        dtpFecha2.Enabled = true;
                        break;
                    }
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                this.BtnSearch = true;
                var criterio = Convert.ToInt32(cbCriterio.SelectedValue);
                this.dgvFactura.AutoGenerateColumns = false;
                this.RowCuenta = 0;
                this.CurrentPageCuenta = 1;
                this.NitTercero = this.txtNit.Text;
                this.FechaActual = dtpFecha1.Value;
                this.FechaActual2 = dtpFecha2.Value;
                this.miError.SetError(this.txtNit, null);
                switch (Convert.ToInt32(cbFecha.SelectedValue))
                {
                    case 1:  // Vacio
                        {
                            if (criterio.Equals(1)) // Tercero
                            {
                                if (!String.IsNullOrEmpty(txtNit.Text))
                                {
                                    Iteracion = 2;
                                    this.dgvFactura.DataSource =
                                        miBussinesCuentaPagar.CuentasPorPagar(this.NitTercero, RowCuenta, RowMaxCuenta);
                                    this.TotalRowCuenta = miBussinesCuentaPagar.GetRowsCuentasPorPagar(this.NitTercero);
                                }
                                else
                                {
                                    this.miError.SetError(this.txtNit, "El campo de busqueda es requerido.");
                                }
                            }
                            else  // Todos
                            {
                                Iteracion = 1;
                                this.dgvFactura.DataSource =
                                    miBussinesCuentaPagar.CuentasPorPagar(RowCuenta, RowMaxCuenta);
                                this.TotalRowCuenta = miBussinesCuentaPagar.GetRowsCuentasPorPagar();
                            }
                            break;
                        }
                    case 2: // Fecha
                        {
                            if (criterio.Equals(1)) // Tercero
                            {
                                if (!String.IsNullOrEmpty(txtNit.Text))
                                {
                                    Iteracion = 5;
                                    this.dgvFactura.DataSource =
                                        miBussinesCuentaPagar.CuentasPorPagar(NitTercero, FechaActual, RowCuenta, RowMaxCuenta);
                                    this.TotalRowCuenta = miBussinesCuentaPagar.GetRowsCuentasPorPagar(NitTercero, FechaActual);
                                }
                                else
                                {
                                    this.miError.SetError(this.txtNit, "El campo de busqueda es requerido.");
                                }
                            }
                            else  // Todos
                            {
                                Iteracion = 3;
                                this.dgvFactura.DataSource =
                                    miBussinesCuentaPagar.CuentasPorPagar(FechaActual, RowCuenta, RowMaxCuenta);
                                this.TotalRowCuenta = miBussinesCuentaPagar.GetRowsCuentasPorPagar(FechaActual);
                            }
                            break;
                        }
                    case 3: // Periodo
                        {
                            if (criterio.Equals(1)) // Tercero
                            {
                                if (!String.IsNullOrEmpty(txtNit.Text))
                                {
                                    Iteracion = 6;
                                    this.dgvFactura.DataSource = miBussinesCuentaPagar.CuentasPorPagar
                                        (NitTercero, FechaActual, FechaActual2, RowCuenta, RowMaxCuenta);
                                    this.TotalRowCuenta =
                                        miBussinesCuentaPagar.GetRowsCuentasPorPagar(NitTercero, FechaActual, FechaActual2);
                                }
                                else
                                {
                                    this.miError.SetError(this.txtNit, "El campo de busqueda es requerido.");
                                }
                            }
                            else  // Todos
                            {
                                Iteracion = 4;
                                this.dgvFactura.DataSource = miBussinesCuentaPagar.
                                    CuentasPorPagar(FechaActual, FechaActual2, RowCuenta, RowMaxCuenta);
                                this.TotalRowCuenta =
                                    miBussinesCuentaPagar.GetRowsCuentasPorPagar(FechaActual, FechaActual2);
                            }
                            break;
                        }
                }
                CalcularPaginas();
                ColorearPagadas();
                this.dgvFactura_CellClick(this.dgvFactura, null);
                if (this.dgvFactura.RowCount.Equals(0))
                {
                    OptionPane.MessageInformation("No se encontrarón registros de la consulta.\n");
                }
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
        }

        private void dgvFactura_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (this.dgvFactura.RowCount != 0)
            {
                try
                {
                    this.dgConceptos.AutoGenerateColumns = false;
                    this.dgConceptos.DataSource =
                        miBussinesCuentaPagar.Detalles(Convert.ToInt32(this.dgvFactura.CurrentRow.Cells["IdCuenta"].Value));
                    txtSubTotal.Text = "0";
                    foreach (DataGridViewRow gRow in this.dgConceptos.Rows)
                    {
                        txtSubTotal.Text = UseObject.InsertSeparatorMil(
                            (UseObject.RemoveSeparatorMil(txtSubTotal.Text) + Convert.ToDouble(gRow.Cells["Valor"].Value)).ToString());
                    }
                    var tRetenciones = miBussinesCuentaPagar.Retenciones(Convert.ToInt32(this.dgvFactura.CurrentRow.Cells["IdCuenta"].Value));
                    if (tRetenciones.Rows.Count != 0)
                    {
                        var query = tRetenciones.AsEnumerable().First();
                        this.Retencion.Id = Convert.ToInt32(query["id"]);
                        this.Retencion.Concepto = query["concepto"].ToString();
                        this.Retencion.CifraUVT = Convert.ToDouble(query["cifra_uvt"]);
                        this.Retencion.CifraPesos = Convert.ToDouble(query["cifra_pesos"]);
                        this.Retencion.Tarifa = Convert.ToDouble(query["tarifa"]);

                        this.txtRetencion.Text = UseObject.InsertSeparatorMil((Convert.ToInt32(
                            UseObject.RemoveSeparatorMil(txtSubTotal.Text) * Convert.ToDouble(query["tarifa"]) / 100)).ToString());
                        this.lblTasaRetencion.Text = query["tarifa"].ToString() + "%";
                        miToolTip.SetToolTip(btnInfoRete, query["concepto"].ToString());
                    }
                    else
                    {
                        this.Retencion.Id = 0;
                        this.Retencion.Concepto = "";
                        this.Retencion.CifraUVT = 0;
                        this.Retencion.CifraPesos = 0;
                        this.Retencion.Tarifa = 0;

                        this.txtRetencion.Text = "0";
                        this.lblTasaRetencion.Text = "0%";
                        miToolTip.SetToolTip(btnInfoRete, null);
                    }
                    txtTotal.Text = UseObject.InsertSeparatorMil((
                        UseObject.RemoveSeparatorMil(txtSubTotal.Text) - UseObject.RemoveSeparatorMil(txtRetencion.Text)).ToString());

                    if (Convert.ToBoolean(this.dgvFactura.CurrentRow.Cells["Estado"].Value))
                    {
                        txtAbonos.Text = UseObject.InsertSeparatorMil((miBussinesCuentaPagar.AbonosCuentasPorPagar(Convert.ToInt32(
                            this.dgvFactura.CurrentRow.Cells["IdCuenta"].Value)).AsEnumerable().Sum(s => s.Field<int>("valor"))).ToString());

                        txtCruces.Text = UseObject.InsertSeparatorMil((miBussinesCuentaPagar.CrucesCuentasPorPagar(Convert.ToInt32(
                            this.dgvFactura.CurrentRow.Cells["IdCuenta"].Value)).AsEnumerable().Sum(s => s.Field<int>("valor"))).ToString());

                        txtResta.Text = UseObject.InsertSeparatorMil(Convert.ToInt32(UseObject.RemoveSeparatorMil(txtTotal.Text) -
                            UseObject.RemoveSeparatorMil(txtAbonos.Text) - UseObject.RemoveSeparatorMil(txtCruces.Text)).ToString());
                    }
                    else
                    {
                        txtAbonos.Text = "0";
                        txtCruces.Text = "0";
                        txtResta.Text = "0";
                    }
                }
                catch (Exception ex)
                {
                    OptionPane.MessageError(ex.Message);
                }
            }
            else
            {
                LimpriarConsulta();
            }
        }

        private void dgvFactura_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyData.Equals(Keys.Up) || e.KeyData.Equals(Keys.Down))
            {
                this.dgvFactura_CellClick(this.dgvFactura, null);
            }
        }

        private void tsEditar_Click(object sender, EventArgs e)
        {
            if (this.dgvFactura.RowCount != 0)
            {
                try
                {
                    var gridRow = this.dgvFactura.CurrentRow;
                    var cuenta = new CuentaPagar();
                    cuenta.Id = Convert.ToInt32(gridRow.Cells["IdCuenta"].Value);
                    cuenta.Tercero = miBussinesTercero.BeneficiarioId(Convert.ToInt32(gridRow.Cells["IdTercero"].Value));
                    cuenta.IdTipo = cuenta.IdTipoEdit = Convert.ToInt32(gridRow.Cells["IdDocumento"].Value);
                    cuenta.Documento = gridRow.Cells["Documento"].Value.ToString();
                    cuenta.Numero = gridRow.Cells["Numero"].Value.ToString();
                    cuenta.Fecha = Convert.ToDateTime(gridRow.Cells["FechaIngreso"].Value);
                    cuenta.FechaDocumento = Convert.ToDateTime(gridRow.Cells["FechaDocumento"].Value);
                    cuenta.FechaLimite = Convert.ToDateTime(gridRow.Cells["FechaLimite"].Value);
                    cuenta.Activo = Convert.ToBoolean(gridRow.Cells["Estado"].Value);
                    cuenta.Pago = Convert.ToBoolean(gridRow.Cells["Pago"].Value);

                    var frmEditar = new FrmEditarCuentaPagar();
                    frmEditar.Cuenta = cuenta;
                    frmEditar.Retencion = this.Retencion;
                    frmEditar.SubTotal = Convert.ToInt32(UseObject.RemoveSeparatorMil(this.txtSubTotal.Text));
                    frmEditar.ShowDialog();
                }
                catch (Exception ex)
                {
                    OptionPane.MessageError(ex.Message);
                }
            }
            else
            {
                OptionPane.MessageInformation("No hay registros para editar.");
            }
        }

        private void btnInicio_Click(object sender, EventArgs e)
        {
            if (CurrentPageCuenta > 1)
            {
                var paginaActual = CurrentPageCuenta;
                for (int i = paginaActual; i > 1; i--)
                {
                    RowCuenta = RowCuenta - RowMaxCuenta;
                    CurrentPageCuenta--;
                }
                try
                {
                    switch (Iteracion)
                    {
                        case 1:
                            {
                                this.dgvFactura.DataSource =
                                    miBussinesCuentaPagar.CuentasPorPagar(RowCuenta, RowMaxCuenta);
                                break;
                            }
                        case 2:
                            {
                                this.dgvFactura.DataSource =
                                        miBussinesCuentaPagar.CuentasPorPagar(this.NitTercero, RowCuenta, RowMaxCuenta);
                                break;
                            }
                        case 3:
                            {
                                this.dgvFactura.DataSource =
                                    miBussinesCuentaPagar.CuentasPorPagar(FechaActual, RowCuenta, RowMaxCuenta);
                                break;
                            }
                        case 4:
                            {
                                this.dgvFactura.DataSource = miBussinesCuentaPagar.
                                    CuentasPorPagar(FechaActual, FechaActual2, RowCuenta, RowMaxCuenta);
                                break;
                            }
                        case 5:
                            {
                                this.dgvFactura.DataSource =
                                        miBussinesCuentaPagar.CuentasPorPagar(NitTercero, FechaActual, RowCuenta, RowMaxCuenta);
                                break;
                            }
                        case 6:
                            {
                                this.dgvFactura.DataSource = miBussinesCuentaPagar.CuentasPorPagar
                                        (NitTercero, FechaActual, FechaActual2, RowCuenta, RowMaxCuenta);
                                break;
                            }
                    }
                    ColorearPagadas();
                    lblStatus.Text = CurrentPageCuenta + " / " + PaginasCuenta;
                    this.dgvFactura_CellClick(this.dgvFactura, null);
                }
                catch (Exception ex)
                {
                    OptionPane.MessageError(ex.Message);
                }
            }
        }

        private void btnAnterior_Click(object sender, EventArgs e)
        {
            if (CurrentPageCuenta > 1)
            {
                RowCuenta = RowCuenta - RowMaxCuenta;
                if (RowCuenta <= 0)
                    RowCuenta = 0;
                try
                {
                    switch (Iteracion)
                    {
                        case 1:
                            {
                                this.dgvFactura.DataSource =
                                    miBussinesCuentaPagar.CuentasPorPagar(RowCuenta, RowMaxCuenta);
                                break;
                            }
                        case 2:
                            {
                                this.dgvFactura.DataSource =
                                        miBussinesCuentaPagar.CuentasPorPagar(this.NitTercero, RowCuenta, RowMaxCuenta);
                                break;
                            }
                        case 3:
                            {
                                this.dgvFactura.DataSource =
                                    miBussinesCuentaPagar.CuentasPorPagar(FechaActual, RowCuenta, RowMaxCuenta);
                                break;
                            }
                        case 4:
                            {
                                this.dgvFactura.DataSource = miBussinesCuentaPagar.
                                    CuentasPorPagar(FechaActual, FechaActual2, RowCuenta, RowMaxCuenta);
                                break;
                            }
                        case 5:
                            {
                                this.dgvFactura.DataSource =
                                        miBussinesCuentaPagar.CuentasPorPagar(NitTercero, FechaActual, RowCuenta, RowMaxCuenta);
                                break;
                            }
                        case 6:
                            {
                                this.dgvFactura.DataSource = miBussinesCuentaPagar.CuentasPorPagar
                                        (NitTercero, FechaActual, FechaActual2, RowCuenta, RowMaxCuenta);
                                break;
                            }
                    }
                    ColorearPagadas();
                    CurrentPageCuenta--;
                    lblStatus.Text = CurrentPageCuenta + " / " + PaginasCuenta;
                    this.dgvFactura_CellClick(this.dgvFactura, null);
                }
                catch (Exception ex)
                {
                    OptionPane.MessageError(ex.Message);
                }
            }
        }

        private void btnSiguiente_Click(object sender, EventArgs e)
        {
            if (CurrentPageCuenta < PaginasCuenta)
            {
                RowCuenta = RowCuenta + RowMaxCuenta;
                try
                {
                    switch (Iteracion)
                    {
                        case 1:
                            {
                                this.dgvFactura.DataSource =
                                    miBussinesCuentaPagar.CuentasPorPagar(RowCuenta, RowMaxCuenta);
                                break;
                            }
                        case 2:
                            {
                                this.dgvFactura.DataSource =
                                        miBussinesCuentaPagar.CuentasPorPagar(this.NitTercero, RowCuenta, RowMaxCuenta);
                                break;
                            }
                        case 3:
                            {
                                this.dgvFactura.DataSource =
                                    miBussinesCuentaPagar.CuentasPorPagar(FechaActual, RowCuenta, RowMaxCuenta);
                                break;
                            }
                        case 4:
                            {
                                this.dgvFactura.DataSource = miBussinesCuentaPagar.
                                    CuentasPorPagar(FechaActual, FechaActual2, RowCuenta, RowMaxCuenta);
                                break;
                            }
                        case 5:
                            {
                                this.dgvFactura.DataSource =
                                        miBussinesCuentaPagar.CuentasPorPagar(NitTercero, FechaActual, RowCuenta, RowMaxCuenta);
                                break;
                            }
                        case 6:
                            {
                                this.dgvFactura.DataSource = miBussinesCuentaPagar.CuentasPorPagar
                                        (NitTercero, FechaActual, FechaActual2, RowCuenta, RowMaxCuenta);
                                break;
                            }
                    }
                    ColorearPagadas();
                    CurrentPageCuenta++;
                    lblStatus.Text = CurrentPageCuenta + " / " + PaginasCuenta;
                    this.dgvFactura_CellClick(this.dgvFactura, null);
                }
                catch (Exception ex)
                {
                    OptionPane.MessageError(ex.Message);
                }
            }
        }

        private void btnFin_Click(object sender, EventArgs e)
        {
            if (CurrentPageCuenta < PaginasCuenta)
            {
                var paginaActual = CurrentPageCuenta;
                for (int i = paginaActual; i < PaginasCuenta; i++)
                {
                    RowCuenta = RowCuenta + RowMaxCuenta;
                    CurrentPageCuenta++;
                }
                try
                {
                    switch (Iteracion)
                    {
                        case 1:
                            {
                                this.dgvFactura.DataSource =
                                    miBussinesCuentaPagar.CuentasPorPagar(RowCuenta, RowMaxCuenta);
                                break;
                            }
                        case 2:
                            {
                                this.dgvFactura.DataSource =
                                        miBussinesCuentaPagar.CuentasPorPagar(this.NitTercero, RowCuenta, RowMaxCuenta);
                                break;
                            }
                        case 3:
                            {
                                this.dgvFactura.DataSource =
                                    miBussinesCuentaPagar.CuentasPorPagar(FechaActual, RowCuenta, RowMaxCuenta);
                                break;
                            }
                        case 4:
                            {
                                this.dgvFactura.DataSource = miBussinesCuentaPagar.
                                    CuentasPorPagar(FechaActual, FechaActual2, RowCuenta, RowMaxCuenta);
                                break;
                            }
                        case 5:
                            {
                                this.dgvFactura.DataSource =
                                        miBussinesCuentaPagar.CuentasPorPagar(NitTercero, FechaActual, RowCuenta, RowMaxCuenta);
                                break;
                            }
                        case 6:
                            {
                                this.dgvFactura.DataSource = miBussinesCuentaPagar.CuentasPorPagar
                                        (NitTercero, FechaActual, FechaActual2, RowCuenta, RowMaxCuenta);
                                break;
                            }
                    }
                    ColorearPagadas();
                    lblStatus.Text = CurrentPageCuenta + " / " + PaginasCuenta;
                    this.dgvFactura_CellClick(this.dgvFactura, null);
                }
                catch (Exception ex)
                {
                    OptionPane.MessageError(ex.Message);
                }
            }
        }

        private void tsAgregarConcepto_Click(object sender, EventArgs e)
        {
            if (this.dgvFactura.RowCount != 0)
            {
                var frmNewConcepto = new FrmNewConceptoCuenta();
                frmNewConcepto.IdCuenta = Convert.ToInt32(this.dgvFactura.CurrentRow.Cells["IdCuenta"].Value);
                frmNewConcepto.ShowDialog();
            }
            else
            {
                OptionPane.MessageInformation("No hay Cuenta para agregar Conceptos.");
            }
        }

        private void tsEliminar_Click(object sender, EventArgs e)
        {
            if (this.dgConceptos.RowCount != 0)
            {
                string rta = OptionPane.OptionBox("Ingrese contraseña de Administrador.",
                    "Administrador", OptionPane.Icon.LoginAdmin);
                if (!rta.Equals("false"))
                {
                    try
                    {
                        if (miBussinesUsuario.VerificarUsuarioAdmin(Encode.Encrypt(rta)))
                        {
                            miBussinesCuentaPagar.EliminarDetalle(Convert.ToInt32(
                                this.dgConceptos.CurrentRow.Cells["Id"].Value));
                            this.dgvFactura_CellClick(this.dgvFactura, null);
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
                OptionPane.MessageInformation("No hay Conceptos para eliminar.");
            }
        }

        private void CargarDatos()
        {
            var lst = new List<Inventario.Producto.Criterio>();
            lst.Add(new Inventario.Producto.Criterio
            {
                Id = 1,
                Nombre = "Tercero"
            });
            lst.Add(new Inventario.Producto.Criterio
            {
                Id = 2,
                Nombre = "Todos los Terceros"
            });
            cbCriterio.DataSource = lst;

            lst = new List<Inventario.Producto.Criterio>();
            lst.Add(new Inventario.Producto.Criterio
            {
                Id = 1,
                Nombre = ""
            });
            lst.Add(new Inventario.Producto.Criterio
            {
                Id = 2,
                Nombre = "Fecha"
            });
            lst.Add(new Inventario.Producto.Criterio
            {
                Id = 3,
                Nombre = "Periodo"
            });
            cbFecha.DataSource = lst;
        }

        private void CalcularPaginas()
        {
            PaginasCuenta = TotalRowCuenta / RowMaxCuenta;
            if (TotalRowCuenta % RowMaxCuenta != 0)
                PaginasCuenta++;
            if (CurrentPageCuenta > PaginasCuenta)
                CurrentPageCuenta = 0;
            lblStatus.Text = CurrentPageCuenta + " / " + PaginasCuenta;
        }

        private void ColorearPagadas()
        {
            foreach (DataGridViewRow row in this.dgvFactura.Rows)
            {
                if (Convert.ToBoolean(row.Cells["Pago"].Value))
                {
                    row.DefaultCellStyle.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
                }
            }

            foreach (DataGridViewRow row in this.dgvFactura.Rows)
            {
                if (!Convert.ToBoolean(row.Cells["Estado"].Value))
                {
                    row.DefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(200, 128, 128);
                }
            }

            /*foreach (DataGridViewRow row in this.dgvConceptos.Rows)
            {
                if (!Convert.ToBoolean(row.Cells["Estado"].Value))
                {
                    row.DefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(200, 128, 128);
                }
            }*/
        }

        private void LimpriarConsulta()
        {
            while (this.dgConceptos.RowCount != 0)
            {
                this.dgConceptos.Rows.RemoveAt(0);
            }
            this.txtSubTotal.Text = "0";
            this.txtRetencion.Text = "0";
            this.txtTotal.Text = "0";
            this.txtAbonos.Text = "0";
            this.txtCruces.Text = "0";
            this.txtResta.Text = "0";
            this.lblTasaRetencion.Text = "0%";
            miToolTip.SetToolTip(btnInfoRete, null);
        }

        private int Anticipos(int idCuenta, int idTercero)
        {
            try
            {
                var anticipo = 0;
                var valor = 0;
                var pago = 0;
                var tAnticipos = miBussinesAnticipo.AnticiposATerceroNoPagos(idCuenta, idTercero);
                foreach (DataRow aRow in tAnticipos.Rows)
                {
                    valor = miBussinesAnticipo.PagosAnticiposTercero
                        (Convert.ToInt32(aRow["id"])).AsEnumerable().Sum(s => s.Field<int>("valor"));
                    pago = miBussinesAnticipo.PagosAnticipo
                        (Convert.ToInt32(aRow["id"])).AsEnumerable().Sum(s => s.Field<int>("valor"));
                    if (valor > pago)
                    {
                        anticipo += valor - pago;
                    }
                }
                return anticipo;
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
                return 0;
            }
        }

        void CompletaEventos_Completaz(CompletaArgumentosDeEventoz args)
        {
            try
            {
                if (Transfer)
                {
                    txtNit.Text = ((Cliente)args.MiZona).NitCliente;
                    //txtNit_KeyPress(this.txtNit, new KeyPressEventArgs((char)Keys.Enter));
                    Transfer = false;
                }
            }
            catch { }
        }

        void CompletaEventos_Completa(CompletaArgumentosDeEvento args)
        {
            try
            {
                if (this.Transfer)
                {
                    var objeto = (ObjectAbstract)args.MiObjeto;
                    if (objeto.Id.Equals(255))
                    {
                        if (this.TipoPago)
                        {
                            RealizarAbonoGeneral((List<FormaPago>)objeto.Objeto);
                        }
                        else
                        {
                            RealizarAbono((List<FormaPago>)objeto.Objeto);
                        }
                    }
                    this.Transfer = false;
                }

                var obj = (ObjectAbstract)args.MiObjeto;
                if (obj.Id.Equals(360))
                {
                    if (this.BtnSearch)
                    {
                        this.btnBuscar_Click(this.btnBuscar, new EventArgs());
                    }
                    else
                    {
                        this.tsBtnTodos_Click(this.tsBtnTodos, new EventArgs());
                    }
                }
                else
                {
                    if (obj.Id.Equals(460))
                    {
                        this.dgvFactura_CellClick(this.dgvFactura, null);
                    }
                }
            }
            catch { }
        }

        private void RealizarAbono(List<FormaPago> pagos)
        {
            try
            {
                var idCuenta = Convert.ToInt32(this.dgvFactura.CurrentRow.Cells["IdCuenta"].Value);
                var idCaja = Convert.ToInt32(AppConfiguracion.ValorSeccion("id_caja"));
                var idUsuario = Convert.ToInt32(AppConfiguracion.ValorSeccion("id_user"));
                var idTercero = Convert.ToInt32(this.dgvFactura.CurrentRow.Cells["IdTercero"].Value);
                var cruces = new List<CruceCuentaPagar>();
                if (pagos.Where(p => p.IdFormaPago.Equals(1) || 
                    p.IdFormaPago.Equals(4)).ToArray().Length != 0)
                {
                    // Ingresar pagos a cuenta.
                    foreach (FormaPago pago in pagos)
                    {
                        // 1 Efectivo.
                        // 2 Transacción
                        if (!pago.IdFormaPago.Equals(0))
                        {
                            pago.Id = idCuenta;
                            pago.Caja.Id = idCaja;
                            pago.Usuario.Id = idUsuario;
                            pago.Fecha = DateTime.Now;
                            miBussinesCuentaPagar.IngresarAbonoCuentaPorPagar(pago);
                            pago.Id = 0;
                        }
                    }
                    // Ingresar Egreso.
                    var egreso = new DTO.Clases.Egreso();
                    egreso.IdCaja = idCaja;
                    egreso.IdUsuario = idUsuario;
                    egreso.Numero = miBussinesConsecutivo.Consecutivo("Egreso");
                    egreso.Fecha = DateTime.Now;
                    egreso.Total = Convert.ToInt32(pagos.Where(p => p.IdFormaPago != 0).Sum(s => s.Valor));
                    egreso.TipoBeneficiario = idTercero;
                    egreso.Estado = true;

                    egreso.Cuentas.Add(new ConceptoEgreso
                    {
                        IdCuenta = Convert.ToInt32(AppConfiguracion.ValorSeccion("ctaEgreso")),
                        Nombre = "ABONO A " + this.dgvFactura.CurrentRow.Cells["Documento"].Value.ToString()
                                 + " NÚMERO " + this.dgvFactura.CurrentRow.Cells["Numero"].Value.ToString(),
                        Numero = egreso.Total.ToString()
                    });
                    egreso.Pagos = pagos;
                    egreso.Id = miBussinesEgreso.IngresarEgreso(egreso);
                    PrintEgreso(egreso);
                }

                // Ingresar cruces a Cuenta por Pagar.
                foreach (FormaPago pago in pagos)
                {
                    // id 1 Anticipo
                    //    2 prestamo
                    CruceCuentaPagar cruce;
                    if (pago.Id.Equals(1))  // Cruce de anticipo.
                    {
                        cruce = new CruceCuentaPagar();
                        cruce.IdCuentaPagar = idCuenta;
                        cruce.Caja.Id = idCaja;
                        cruce.Usuario.Id = idUsuario;
                        cruce.Numero = miBussinesConsecutivo.Consecutivo("CruceCuentaPagar");
                        cruce.Fecha = DateTime.Now;
                        cruce.Concepto = "CRUCE CON ANTICIPO A " + this.dgvFactura.CurrentRow.Cells["Documento"].Value.ToString() +
                            " NÚMERO " + this.dgvFactura.CurrentRow.Cells["Numero"].Value.ToString();
                        cruce.Valor = pago.Valor;
                        cruce.Resta = Anticipos(this.IdCuentaAnticipo, idTercero) - Convert.ToInt32(pago.Valor);
                        miBussinesCuentaPagar.IngresarCruceCuentaPorPagar(cruce);
                        miBussinesAnticipo.IngresarCruceAnticipo(this.IdCuentaAnticipo, idTercero, cruce);
                        cruces.Add(cruce);
                    }
                    if (pago.Id.Equals(2))  // Cruce de prestamo.
                    {
                        cruce = new CruceCuentaPagar();
                        cruce.IdCuentaPagar = idCuenta;
                        cruce.Caja.Id = idCaja;
                        cruce.Usuario.Id = idUsuario;
                        cruce.Numero = miBussinesConsecutivo.Consecutivo("CruceCuentaPagar");
                        cruce.Fecha = DateTime.Now;
                        cruce.Concepto = "CRUCE CON PRESTAMO A " + this.dgvFactura.CurrentRow.Cells["Documento"].Value.ToString() +
                            " NÚMERO " + this.dgvFactura.CurrentRow.Cells["Numero"].Value.ToString();
                        cruce.Valor = pago.Valor;
                        cruce.Resta = Anticipos(this.IdCuentaPrestamo, idTercero) - Convert.ToInt32(pago.Valor);
                        miBussinesCuentaPagar.IngresarCruceCuentaPorPagar(cruce);
                        miBussinesAnticipo.IngresarCruceAnticipo(this.IdCuentaPrestamo, idTercero, cruce);
                        cruces.Add(cruce);
                    }
                }
                OptionPane.MessageInformation("Las operaciones se realizaron con éxito.");
                this.dgvFactura_CellClick(this.dgvFactura, null);
                foreach (CruceCuentaPagar cruce in cruces)
                {
                    PrintCruce(cruce, idTercero);
                }
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
        }

        private void RealizarAbonoGeneral(List<FormaPago> pagos)
        {
            try
            {
                var montoPago = Convert.ToInt32(pagos.Where(p => p.IdFormaPago.Equals(1) || 
                                                p.IdFormaPago.Equals(2)).Sum(s => s.Valor));
                var montoCruce = Convert.ToInt32(pagos.Where(p => p.Id.Equals(1) || p.Id.Equals(2)).Sum(s => s.Valor));
                var idTercero = Convert.ToInt32(this.dgvFactura.CurrentRow.Cells["IdTercero"].Value);
                var tCuentas = miBussinesCuentaPagar.CuentasPorPagarNoSaldadas(idTercero);
                var total = 0;
                var retencion = 0;
                var pagosCruce = 0;
                foreach (DataRow cRow in tCuentas.Rows)
                {
                    if (montoPago > 0)
                    {
                        total = miBussinesCuentaPagar.Detalles
                            (Convert.ToInt32(cRow["id"])).AsEnumerable().Sum(s => s.Field<int>("valor"));
                        foreach (DataRow rRow in miBussinesCuentaPagar.Retenciones(Convert.ToInt32(cRow["id"])).Rows)
                        {
                            retencion += Convert.ToInt32(total * Convert.ToDouble(rRow["tarifa"]) / 100);
                        }
                        total -= retencion;
                        pagosCruce = miBussinesCuentaPagar.AbonosCuentasPorPagar
                            (Convert.ToInt32(cRow["id"])).AsEnumerable().Sum(s => s.Field<int>("valor")) +
                                     miBussinesCuentaPagar.CrucesCuentasPorPagar
                            (Convert.ToInt32(cRow["id"])).AsEnumerable().Sum(s => s.Field<int>("valor"));
                        if (total < pagosCruce)  // cuenta sin cancelar.
                        {

                        }
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
            try
            {
                FrmPrint frmPrint = new FrmPrint();
                frmPrint.StringCaption = "Cuenta por Pagar";
                frmPrint.StringMessage = "Impresión del Comprobante de Egreso";
                DialogResult rta = frmPrint.ShowDialog();
                if (!rta.Equals(DialogResult.Cancel))
                {
                    var tercero = miBussinesTercero.BeneficiarioId(egreso.TipoBeneficiario);
                    var frmPrintEgreso = new Egreso.FrmPrintComprobante();
                    frmPrintEgreso.Numero = egreso.Numero;
                    frmPrintEgreso.Fecha = egreso.Fecha;
                    frmPrintEgreso.Remite = tercero.NombresCliente + " CC o NIT : " + tercero.NitCliente;
                    frmPrintEgreso.Cuentas = miBussinesEgreso.Cuentas(egreso.Id);
                    frmPrintEgreso.Efectivo = egreso.Pagos.Where(p => p.IdFormaPago.Equals(1)).Sum(s => s.Valor).ToString();
                    frmPrintEgreso.Cheque = egreso.Pagos.Where(p => p.IdFormaPago.Equals(2)).Sum(s => s.Valor).ToString();
                    frmPrintEgreso.Transaccion  = egreso.Pagos.Where(p => p.IdFormaPago.Equals(4)).Sum(s => s.Valor).ToString();
                    if (rta.Equals(DialogResult.Yes))
                    {
                        Imprimir print = new Imprimir();
                        print.Report = frmPrintEgreso.CargarDatos();
                        print.Print(Imprimir.TamanioPapel.MediaCarta);
                        frmPrintEgreso.ResetReport();
                    }
                    else
                    {
                        frmPrintEgreso.ShowDialog();
                    }
                }
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
        }

        private void PrintCruce(CruceCuentaPagar cruce, int idTercero)
        {
            try
            {
                FrmPrint frmPrint = new FrmPrint();
                frmPrint.StringCaption = "Cuenta por Pagar";
                frmPrint.StringMessage = "Impresión del Documento de Cruce";
                DialogResult rta = frmPrint.ShowDialog();
                if (!rta.Equals(DialogResult.Cancel))
                {
                    var tercero = miBussinesTercero.BeneficiarioId(idTercero);
                    var frmPrintCruce = new Ventas.Factura.FrmComprobanteCruce();
                    frmPrintCruce.Venta = false;
                    frmPrintCruce.Numero = cruce.Numero;
                    frmPrintCruce.Fecha = cruce.Fecha;
                    frmPrintCruce.Cliente = tercero.NombresCliente;
                    frmPrintCruce.Nit = tercero.NitCliente;
                    frmPrintCruce.Direccion = " ";
                    frmPrintCruce.Valor = cruce.Valor.ToString();
                    frmPrintCruce.Concepto = cruce.Concepto;
                    frmPrintCruce.VRestante = cruce.Resta;
                    frmPrintCruce.ReportPath = AppConfiguracion.ValorSeccion("report") + @"\reports\ComprobanteCruceCuentaPagar.rdlc";
                    if (rta.Equals(DialogResult.Yes))
                    {
                        Imprimir print = new Imprimir();
                        print.Report = frmPrintCruce.CargarDatos();
                        print.Print(Imprimir.TamanioPapel.MediaCarta);
                        frmPrintCruce.ResetReport();
                    }
                    else
                    {
                        frmPrintCruce.ShowDialog();
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