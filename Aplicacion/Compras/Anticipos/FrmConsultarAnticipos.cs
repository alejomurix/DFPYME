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
using Microsoft.Reporting.WinForms;

namespace Aplicacion.Compras.Anticipos
{
    public partial class FrmConsultarAnticipos : Form
    {
        private BussinesAnticipo miBussinesAnticipo;

        private BussinesBeneficio miBussinesTercero;

        private BussinesIngreso miBussinesIngreso;

        private BussinesConsecutivo miBussinesConsecutivo;

        private BussinesOtroIngreso miBussinesOtroIngreso;

        private bool BtnSearch;

        /// <summary>
        /// Obteien o establece el numero que indica que iteracion se realizo.
        /// </summary>
        private int Iteracion;

        /// <summary>
        /// Obtiene o establece el valor del registro a segir o registro base.
        /// </summary>
        private int RowAnticipo;

        /// <summary>
        /// Obtiene o establece el número maximo de registro a cargar.
        /// </summary>
        private int RowMaxAnticipo;

        /// <summary>
        /// Obtiene o establece el total de registros en la base de datos.
        /// </summary>
        private long TotalRowAnticipo;

        /// <summary>
        /// Obtiene o establece el número total de paginas que componen la consulta.
        /// </summary>
        private long PaginasAnticipo;

        /// <summary>
        /// Obtiene o establece el número de la pagina actual.
        /// </summary>
        private int CurrentPageAnticipo;

        private int IdTercero;

        private int IdCuentaAnticipo;

        private int IdCuentaPrestamo;

        private DateTime FechaActual;

        private DateTime FechaActual2;

        private int PrintConsulta { set; get; }

        private ErrorProvider miError;

        private bool Transfer { set; get; }

        public FrmConsultarAnticipos()
        {
            InitializeComponent();
            miBussinesAnticipo = new BussinesAnticipo();
            miBussinesTercero = new BussinesBeneficio();
            miBussinesIngreso = new BussinesIngreso();
            miBussinesConsecutivo = new BussinesConsecutivo();
            miBussinesOtroIngreso = new BussinesOtroIngreso();
            RowMaxAnticipo = 11;
            IdTercero = 0;
            miError = new ErrorProvider();
            this.Transfer = false;
            this.PrintConsulta = 0;
            //IdCuentaAnticipo = 3;
            //IdCuentaPrestamo = 4;
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

        private void FrmConsultarAnticipos_Load(object sender, EventArgs e)
        {
            CargarDatos();
            CompletaEventos.Completaz +=
                new CompletaEventos.CompletaAccionz(CompletaEventos_Completaz);
            CompletaEventos.Completa += new CompletaEventos.CompletaAccion(CompletaEventos_Completa);
        }

        private void tsBtnListarTodos_Click(object sender, EventArgs e)
        {
            try
            {
                this.BtnSearch = false;
                dgvConceptos.AutoGenerateColumns = false;
                this.RowAnticipo = 0;
                Iteracion = 1;
                this.PrintConsulta = 1;
                CurrentPageAnticipo = 1;
                dgvConceptos.DataSource = miBussinesAnticipo.AnticiposATercero(RowAnticipo, RowMaxAnticipo);
                TotalRowAnticipo = miBussinesAnticipo.GetRowsAnticiposATercero();
                this.txtSaldo.Text = UseObject.InsertSeparatorMil(miBussinesAnticipo.SaldoAnticipos().ToString());
                ColorearPagadas();
                CalcularPaginas();
                dgvConceptos_CellClick(null, null);
                if (dgvConceptos.RowCount.Equals(0))
                {
                    OptionPane.MessageInformation("No se encontraron registros de la consulta.");
                }
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
        }

        private void tsBtnAbono_Click(object sender, EventArgs e)
        {
            if (this.dgvConceptos.RowCount != 0)
            {
                if (Convert.ToBoolean(this.dgvConceptos.CurrentRow.Cells["Estado"].Value))
                {
                    if (!this.txtResta.Text.Equals("0"))
                    {
                        Transfer = true;
                        var frmAbono = new FrmAbono();
                        frmAbono.txtTotal.Text = txtResta.Text;
                        frmAbono.ShowDialog();
                    }
                    else
                    {
                        OptionPane.MessageInformation("No hay valor para saldar.");
                    }
                }
                else
                {
                    OptionPane.MessageInformation("El prestamo/anticipo no se puede abonar por que se encuentar anulado.");
                }
            }
            else
            {
                OptionPane.MessageInformation("No hay registros para realizar abonos.");
            }
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.Iteracion != 0)
                {
                    var tabla = new DataTable();
                    switch (Iteracion)
                    {
                        case 1: // Todos.
                            {
                                tabla = miBussinesAnticipo.AnticiposATercero(true);
                                break;
                            }
                        case 2:
                            {
                                tabla = miBussinesAnticipo.AnticiposATercero_(IdTercero, FechaActual, true);
                                break;
                            }
                        case 3:
                            {
                                tabla = miBussinesAnticipo.AnticiposATercero(IdCuentaAnticipo, FechaActual, true);
                                break;
                            }
                        case 4:
                            {
                                tabla = miBussinesAnticipo.AnticiposATercero(IdCuentaPrestamo, FechaActual, true);
                                break;
                            }
                        case 5:
                            {
                                tabla = miBussinesAnticipo.AnticiposATercero_(IdTercero, FechaActual, FechaActual2, true);
                                break;
                            }
                        case 6:
                            {
                                tabla = miBussinesAnticipo.AnticiposATercero
                                        (IdCuentaAnticipo, FechaActual, FechaActual2, true);
                                break;
                            }
                        case 7:
                            {
                                tabla = miBussinesAnticipo.AnticiposATercero
                                (IdCuentaPrestamo, FechaActual, FechaActual2, true);
                                break;
                            }
                        case 8:
                            {
                                tabla = miBussinesAnticipo.AnticiposATercero(this.FechaActual, true);
                                break;
                            }
                        case 9:
                            {
                                tabla = miBussinesAnticipo.AnticiposATercero(this.FechaActual, this.FechaActual2, true);
                                break;
                            }
                        case 10:
                            {
                                tabla = miBussinesAnticipo.AnticiposATercero(true);
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
                    new ReportDataSource("DsPrestamoAnticipo", tabla));
                    frmPrint.rpvEgresos.LocalReport.ReportPath = AppConfiguracion.ValorSeccion("report") + @"\reports\InformeDePrestamosAnticipos.rdlc";
                    //frmPrint.rpvEgresos.LocalReport.ReportPath = @"C:\reports\InformeDePrestamosAnticipos.rdlc";

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

        private void tsBtnAnular_Click(object sender, EventArgs e)
        {
            if (this.dgvConceptos.RowCount != 0)
            {
                if (Convert.ToBoolean(this.dgvConceptos.CurrentRow.Cells["Estado"].Value))
                {
                    if (this.txtAbono.Text.Equals("0") && this.txtCruce.Text.Equals("0"))
                    {
                        DialogResult rta = MessageBox.Show("¿Esta seguro(a) de querer anular el prestamo/anticipo?", "Consultar prestamos y anticipos",
                            MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (rta.Equals(DialogResult.Yes))
                        {
                            miBussinesAnticipo.AnularAnticipo(Convert.ToInt32(this.dgvConceptos.CurrentRow.Cells["Id"].Value));
                            if (this.BtnSearch)
                            {
                                this.btnBuscar_Click(this.btnBuscar, new EventArgs());
                            }
                            else
                            {
                                this.tsBtnListarTodos_Click(this.tsBtnListarTodos, new EventArgs());
                            }
                        }
                    }
                    else
                    {
                        OptionPane.MessageInformation("El prestamo/anticipo no se puede anular.");
                    }
                }
                else
                {
                    OptionPane.MessageInformation("El prestamo/anticipo ya se encuentra anulado");
                }
            }
            else
            {
                OptionPane.MessageInformation("No hay registros para anular.");
            }
        }

        private void tsBtnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        //*****

        private void cbCriterio_SelectionChangeCommitted(object sender, EventArgs e)
        {
            switch (Convert.ToInt32(cbCriterio.SelectedValue))
            {
                case 0:
                    {
                        this.txtTercero.Enabled = false;
                        this.btnBuscarTercero.Enabled = false;
                        this.cbFecha.Enabled = true;
                        this.dtpFecha1.Enabled = true;
                        this.dtpFecha2.Enabled = false;
                        break;
                    }
                case 1:
                    {
                        this.txtTercero.Enabled = true;
                        this.btnBuscarTercero.Enabled = true;
                        this.cbFecha.Enabled = true;
                        this.dtpFecha1.Enabled = true;
                        this.dtpFecha2.Enabled = false;
                        break;
                    }
                case 2:
                    {
                        this.txtTercero.Enabled = false;
                        this.btnBuscarTercero.Enabled = false;
                        this.cbFecha.Enabled = false;
                        this.dtpFecha1.Enabled = false;
                        this.dtpFecha2.Enabled = false;
                        break;
                    }
            }

           /* if (Convert.ToInt32(cbCriterio.SelectedValue).Equals(1))
            {
                txtTercero.Enabled = true;
                btnBuscarTercero.Enabled = true;
            }
            else
            {
                txtTercero.Enabled = false;
                btnBuscarTercero.Enabled = false;
                if (Convert.ToInt32(cbCriterio.SelectedValue).Equals(2))
                {
                    this.cbFecha.SelectedIndex = 0;
                }
            }*/
        }

        private void txtTercero_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar.Equals((char)Keys.Enter))
            {
                this.btnBuscar_Click(this.btnBuscar, new EventArgs());
            }
        }

        private void btnBuscarTercero_Click(object sender, EventArgs e)
        {
            var frmBeneficio = new Beneficiario.FrmBeneficio();
            frmBeneficio.tcBeneficio.SelectTab(1);
            frmBeneficio.ShowDialog();
        }

        private void cbFecha_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (Convert.ToInt32(cbFecha.SelectedValue).Equals(1))
            {
                dtpFecha2.Enabled = false;
            }
            else
            {
                dtpFecha2.Enabled = true;
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                int saldo = 0;
                this.BtnSearch = true;
                if (Convert.ToInt32(cbCriterio.SelectedValue).Equals(1))
                {
                    if (!String.IsNullOrEmpty(txtTercero.Text))
                    {
                        var tTercero = miBussinesTercero.BeneficiariosNit(txtTercero.Text);
                        if (tTercero.Rows.Count.Equals(0))
                        {
                            IdTercero = 0;
                        }
                        else
                        {
                            IdTercero = Convert.ToInt32(tTercero.AsEnumerable().First()["id"]);
                        }
                    }
                }

                if (Convert.ToInt32(cbCriterio.SelectedValue).Equals(2))
                {
                    Iteracion = 10;
                    dgvConceptos.DataSource = miBussinesAnticipo.AnticiposSaldo(RowAnticipo, RowMaxAnticipo);
                    TotalRowAnticipo = miBussinesAnticipo.GetRowsAnticiposSaldo();
                    saldo = miBussinesAnticipo.SaldoAnticipos();
                }
                else
                {
                    dgvConceptos.AutoGenerateColumns = false;
                    RowAnticipo = 0;
                    CurrentPageAnticipo = 1;
                    if (Convert.ToInt32(cbFecha.SelectedValue).Equals(1)) // Fecha
                    {
                        FechaActual = dtpFecha1.Value;
                        switch (Convert.ToInt32(cbCriterio.SelectedValue))
                        {
                            case 0:
                                {
                                    Iteracion = 8;
                                    this.dgvConceptos.DataSource =
                                        miBussinesAnticipo.AnticiposATercero(this.dtpFecha1.Value, RowAnticipo, RowMaxAnticipo);
                                    this.TotalRowAnticipo = miBussinesAnticipo.GetRowsAnticiposATercero(this.dtpFecha1.Value);
                                    saldo = miBussinesAnticipo.SaldoAnticipos(this.dtpFecha1.Value);
                                    break;
                                }
                            case 1: // Tercero
                                {
                                    if (!String.IsNullOrEmpty(txtTercero.Text))
                                    {
                                        miError.SetError(txtTercero, null);
                                        Iteracion = 2;
                                        dgvConceptos.DataSource = miBussinesAnticipo.
                                            AnticiposATercero(IdTercero, dtpFecha1.Value, RowAnticipo, RowMaxAnticipo);
                                        TotalRowAnticipo = miBussinesAnticipo.GetRowsAnticiposATercero(IdTercero, FechaActual);
                                        saldo = miBussinesAnticipo.SaldoAnticipos(IdTercero, FechaActual);
                                    }
                                    else
                                    {
                                        miError.SetError(txtTercero, "El campo de consulta es requerido.");
                                    }
                                    break;
                                }
                            case 2: // Anticipo
                                {
                                    Iteracion = 3;
                                    //this.PrintConsulta = 3;
                                    dgvConceptos.DataSource = miBussinesAnticipo.
                                        AnticiposATerceroCuenta(IdCuentaAnticipo, FechaActual, RowAnticipo, RowMaxAnticipo);
                                    TotalRowAnticipo = miBussinesAnticipo.GetRowsAnticiposATerceroCuenta(IdCuentaAnticipo, FechaActual);
                                    break;
                                }
                            case 3: // Prestamo
                                {
                                    Iteracion = 4;
                                    //this.PrintConsulta = 4;
                                    dgvConceptos.DataSource = miBussinesAnticipo.
                                        AnticiposATerceroCuenta(IdCuentaPrestamo, FechaActual, RowAnticipo, RowMaxAnticipo);
                                    TotalRowAnticipo = miBussinesAnticipo.GetRowsAnticiposATerceroCuenta(IdCuentaPrestamo, FechaActual);
                                    break;
                                }
                        }
                    }
                    else
                    {
                        FechaActual = dtpFecha1.Value;
                        FechaActual2 = dtpFecha2.Value;
                        switch (Convert.ToInt32(cbCriterio.SelectedValue))
                        {
                            case 0:
                                {
                                    Iteracion = 9;
                                    this.dgvConceptos.DataSource =
                                    miBussinesAnticipo.AnticiposATercero(this.dtpFecha1.Value, this.dtpFecha2.Value, RowAnticipo, RowMaxAnticipo);
                                    this.TotalRowAnticipo = miBussinesAnticipo.GetRowsAnticiposATercero(this.dtpFecha1.Value, this.dtpFecha2.Value);
                                    saldo = miBussinesAnticipo.SaldoAnticipos(this.dtpFecha1.Value, this.dtpFecha2.Value);
                                    break;
                                }
                            case 1: // Tercero
                                {
                                    Iteracion = 5;
                                    //this.PrintConsulta = 5;
                                    dgvConceptos.DataSource = miBussinesAnticipo.AnticiposATercero
                                        (IdTercero, FechaActual, FechaActual2, RowAnticipo, RowMaxAnticipo);
                                    TotalRowAnticipo = miBussinesAnticipo.GetRowsAnticiposATercero(IdTercero, FechaActual, FechaActual2);
                                    saldo = miBussinesAnticipo.SaldoAnticipos(IdTercero, FechaActual, FechaActual2);
                                    break;
                                }
                            case 2: // Anticipo
                                {
                                    Iteracion = 6;
                                    dgvConceptos.DataSource = miBussinesAnticipo.AnticiposATerceroCuenta
                                        (IdCuentaAnticipo, FechaActual, FechaActual2, RowAnticipo, RowMaxAnticipo);
                                    TotalRowAnticipo = miBussinesAnticipo.GetRowsAnticiposATerceroCuenta(IdCuentaAnticipo, FechaActual, FechaActual2);
                                    break;
                                }
                            case 3: // Prestamo
                                {
                                    Iteracion = 7;
                                    dgvConceptos.DataSource = miBussinesAnticipo.AnticiposATerceroCuenta
                                        (IdCuentaPrestamo, FechaActual, FechaActual2, RowAnticipo, RowMaxAnticipo);
                                    TotalRowAnticipo = miBussinesAnticipo.GetRowsAnticiposATerceroCuenta(IdCuentaPrestamo, FechaActual, FechaActual2);
                                    break;
                                }
                        }
                    }
                }
                this.txtSaldo.Text = UseObject.InsertSeparatorMil(saldo.ToString());
                ColorearPagadas();
                CalcularPaginas();
                dgvConceptos_CellClick(null, null);
                if (dgvConceptos.RowCount.Equals(0))
                {
                    OptionPane.MessageInformation("No se encontraron registros de la consulta.");
                }
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
        }

        private void dgvConceptos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvConceptos.RowCount != 0)
            {
                try
                {
                    var gRow = this.dgvConceptos.CurrentRow;
                   /* var tercero = miBussinesTercero.BeneficiarioId(Convert.ToInt32(gRow.Cells["IdTercero_"].Value));
                    txtNit.Text = tercero.NitCliente;
                    txtNombre.Text = tercero.NombresCliente;*/
                    var idAnticipo = Convert.ToInt32(gRow.Cells["Id"].Value);
                    var tabla = miBussinesAnticipo.PagosAnticiposTercero(idAnticipo);

                    if (Convert.ToBoolean(this.dgvConceptos.CurrentRow.Cells["Estado"].Value))
                    {
                        txtEfectivo.Text = UseObject.InsertSeparatorMil(tabla.AsEnumerable().
                          Where(t => t.Field<int>("id_forma_pago").Equals(1)).Sum(s => s.Field<int>("valor")).ToString());
                        txtCheque.Text = UseObject.InsertSeparatorMil(tabla.AsEnumerable().
                          Where(t => t.Field<int>("id_forma_pago").Equals(2)).Sum(s => s.Field<int>("valor")).ToString());
                        txtTransaccion.Text = UseObject.InsertSeparatorMil(tabla.AsEnumerable().
                          Where(t => t.Field<int>("id_forma_pago").Equals(4)).Sum(s => s.Field<int>("valor")).ToString());

                        var tPagos = miBussinesAnticipo.PagosAnticipo(idAnticipo);
                        txtAbono.Text = UseObject.InsertSeparatorMil(tPagos.AsEnumerable().
                            Where(t => t.Field<int>("idconcepto").Equals(1)).Sum(s => s.Field<int>("valor")).ToString());
                        txtCruce.Text = UseObject.InsertSeparatorMil(tPagos.AsEnumerable().
                            Where(t => t.Field<int>("idconcepto").Equals(2)).Sum(s => s.Field<int>("valor")).ToString());
                        txtResta.Text = UseObject.InsertSeparatorMil((Convert.ToInt32(gRow.Cells["Valor"].Value) -
                            (Convert.ToInt32(UseObject.RemoveSeparatorMil(txtAbono.Text)) +
                             Convert.ToInt32(UseObject.RemoveSeparatorMil(txtCruce.Text)))).ToString());
                    }
                    else
                    {
                        txtEfectivo.Text = "0";
                        txtCheque.Text = "0";
                        txtTransaccion.Text = "0";

                        txtAbono.Text = "0";
                        txtCruce.Text = "0";
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
                this.txtEfectivo.Text = "0";
                this.txtCheque.Text = "0";
                this.txtTransaccion.Text = "0";
                this.txtAbono.Text = "0";
                this.txtCruce.Text = "0";
                this.txtResta.Text = "0";
            }
        }

        private void dgvConceptos_KeyUp(object sender, KeyEventArgs e)
        {

        }

        private void btnInicio_Click(object sender, EventArgs e)
        {
            if (CurrentPageAnticipo > 1)
            {
                var paginaActual = CurrentPageAnticipo;
                for (int i = paginaActual; i > 1; i--)
                {
                    RowAnticipo = RowAnticipo - RowMaxAnticipo;
                    CurrentPageAnticipo--;
                }
                try
                {
                    switch (Iteracion)
                    {
                        case 1: // Todos.
                            {
                                dgvConceptos.DataSource = miBussinesAnticipo.AnticiposATercero(RowAnticipo, RowMaxAnticipo);
                                break;
                            }
                        case 2:
                            {
                                dgvConceptos.DataSource = miBussinesAnticipo.
                                    AnticiposATercero(IdTercero, FechaActual, RowAnticipo, RowMaxAnticipo);
                                break;
                            }
                        case 3:
                            {
                                dgvConceptos.DataSource = miBussinesAnticipo.
                                AnticiposATerceroCuenta(IdCuentaAnticipo, FechaActual, RowAnticipo, RowMaxAnticipo);
                                break;
                            }
                        case 4:
                            {
                                dgvConceptos.DataSource = miBussinesAnticipo.
                                AnticiposATerceroCuenta(IdCuentaPrestamo, FechaActual, RowAnticipo, RowMaxAnticipo);
                                break;
                            }
                        case 5:
                            {
                                dgvConceptos.DataSource = miBussinesAnticipo.AnticiposATercero
                                (IdTercero, FechaActual, FechaActual2, RowAnticipo, RowMaxAnticipo);
                                break;
                            }
                        case 6:
                            {
                                dgvConceptos.DataSource = miBussinesAnticipo.AnticiposATerceroCuenta
                                (IdCuentaAnticipo, FechaActual, FechaActual2, RowAnticipo, RowMaxAnticipo);
                                break;
                            }
                        case 7:
                            {
                                dgvConceptos.DataSource = miBussinesAnticipo.AnticiposATerceroCuenta
                                (IdCuentaPrestamo, FechaActual, FechaActual2, RowAnticipo, RowMaxAnticipo);
                                break;
                            }
                        case 10:
                            {
                                dgvConceptos.DataSource = miBussinesAnticipo.AnticiposSaldo(RowAnticipo, RowMaxAnticipo);
                                break;
                            }
                    }
                    ColorearPagadas();
                    lblStatus.Text = CurrentPageAnticipo + " / " + PaginasAnticipo;
                    if (!dgvConceptos.RowCount.Equals(0))
                    {
                        dgvConceptos_CellClick(this.dgvConceptos, null);
                    }
                }
                catch (Exception ex)
                {
                    OptionPane.MessageError(ex.Message);
                }
            }
        }

        private void btnAnterior_Click(object sender, EventArgs e)
        {
            if (CurrentPageAnticipo > 1)
            {
                RowAnticipo = RowAnticipo - RowMaxAnticipo;
                if(RowAnticipo <= 0)
                    RowAnticipo = 0;
                try
                {
                    switch (Iteracion)
                    {
                        case 1: // Todos.
                            {
                                dgvConceptos.DataSource = miBussinesAnticipo.AnticiposATercero(RowAnticipo, RowMaxAnticipo);
                                break;
                            }
                        case 2:
                            {
                                dgvConceptos.DataSource = miBussinesAnticipo.
                                    AnticiposATercero(IdTercero, FechaActual, RowAnticipo, RowMaxAnticipo);
                                break;
                            }
                        case 3:
                            {
                                dgvConceptos.DataSource = miBussinesAnticipo.
                                AnticiposATerceroCuenta(IdCuentaAnticipo, FechaActual, RowAnticipo, RowMaxAnticipo);
                                break;
                            }
                        case 4:
                            {
                                dgvConceptos.DataSource = miBussinesAnticipo.
                                AnticiposATerceroCuenta(IdCuentaPrestamo, FechaActual, RowAnticipo, RowMaxAnticipo);
                                break;
                            }
                        case 5:
                            {
                                dgvConceptos.DataSource = miBussinesAnticipo.AnticiposATercero
                                (IdTercero, FechaActual, FechaActual2, RowAnticipo, RowMaxAnticipo);
                                break;
                            }
                        case 6:
                            {
                                dgvConceptos.DataSource = miBussinesAnticipo.AnticiposATerceroCuenta
                                (IdCuentaAnticipo, FechaActual, FechaActual2, RowAnticipo, RowMaxAnticipo);
                                break;
                            }
                        case 7:
                            {
                                dgvConceptos.DataSource = miBussinesAnticipo.AnticiposATerceroCuenta
                                (IdCuentaPrestamo, FechaActual, FechaActual2, RowAnticipo, RowMaxAnticipo);
                                break;
                            }
                        case 10:
                            {
                                dgvConceptos.DataSource = miBussinesAnticipo.AnticiposSaldo(RowAnticipo, RowMaxAnticipo);
                                break;
                            }
                    }
                    ColorearPagadas();
                    CurrentPageAnticipo--;
                    lblStatus.Text = CurrentPageAnticipo + " / " + PaginasAnticipo;
                    if (!dgvConceptos.RowCount.Equals(0))
                    {
                        dgvConceptos_CellClick(this.dgvConceptos, null);
                    }
                }
                catch (Exception ex)
                {
                    OptionPane.MessageError(ex.Message);
                }
            }
        }

        private void btnSiguiente_Click(object sender, EventArgs e)
        {
            if (CurrentPageAnticipo < PaginasAnticipo)
            {
                RowAnticipo = RowAnticipo + RowMaxAnticipo;
                try
                {
                    switch (Iteracion)
                    {
                        case 1: // Todos.
                            {
                                dgvConceptos.DataSource = miBussinesAnticipo.AnticiposATercero(RowAnticipo, RowMaxAnticipo);
                                break;
                            }
                        case 2:
                            {
                                dgvConceptos.DataSource = miBussinesAnticipo.
                                    AnticiposATercero(IdTercero, FechaActual, RowAnticipo, RowMaxAnticipo);
                                break;
                            }
                        case 3:
                            {
                                dgvConceptos.DataSource = miBussinesAnticipo.
                                AnticiposATerceroCuenta(IdCuentaAnticipo, FechaActual, RowAnticipo, RowMaxAnticipo);
                                break;
                            }
                        case 4:
                            {
                                dgvConceptos.DataSource = miBussinesAnticipo.
                                AnticiposATerceroCuenta(IdCuentaPrestamo, FechaActual, RowAnticipo, RowMaxAnticipo);
                                break;
                            }
                        case 5:
                            {
                                dgvConceptos.DataSource = miBussinesAnticipo.AnticiposATercero
                                (IdTercero, FechaActual, FechaActual2, RowAnticipo, RowMaxAnticipo);
                                break;
                            }
                        case 6:
                            {
                                dgvConceptos.DataSource = miBussinesAnticipo.AnticiposATerceroCuenta
                                (IdCuentaAnticipo, FechaActual, FechaActual2, RowAnticipo, RowMaxAnticipo);
                                break;
                            }
                        case 7:
                            {
                                dgvConceptos.DataSource = miBussinesAnticipo.AnticiposATerceroCuenta
                                (IdCuentaPrestamo, FechaActual, FechaActual2, RowAnticipo, RowMaxAnticipo);
                                break;
                            }
                        case 10:
                            {
                                dgvConceptos.DataSource = miBussinesAnticipo.AnticiposSaldo(RowAnticipo, RowMaxAnticipo);
                                break;
                            }
                    }
                    ColorearPagadas();
                    CurrentPageAnticipo++;
                    lblStatus.Text = CurrentPageAnticipo + " / " + PaginasAnticipo;
                    if (!dgvConceptos.RowCount.Equals(0))
                    {
                        dgvConceptos_CellClick(this.dgvConceptos, null);
                    }
                }
                catch (Exception ex)
                {
                    OptionPane.MessageError(ex.Message);
                }
            }
        }

        private void btnFin_Click(object sender, EventArgs e)
        {
            if (CurrentPageAnticipo < PaginasAnticipo)
            {
                var paginaActual = CurrentPageAnticipo;
                for (int i = paginaActual; i < PaginasAnticipo; i++)
                {
                    RowAnticipo = RowAnticipo + RowMaxAnticipo;
                    CurrentPageAnticipo++;
                }
                try
                {
                    switch (Iteracion)
                    {
                        case 1: // Todos.
                            {
                                dgvConceptos.DataSource = miBussinesAnticipo.AnticiposATercero(RowAnticipo, RowMaxAnticipo);
                                break;
                            }
                        case 2:
                            {
                                dgvConceptos.DataSource = miBussinesAnticipo.
                                    AnticiposATercero(IdTercero, FechaActual, RowAnticipo, RowMaxAnticipo);
                                break;
                            }
                        case 3:
                            {
                                dgvConceptos.DataSource = miBussinesAnticipo.
                                AnticiposATerceroCuenta(IdCuentaAnticipo, FechaActual, RowAnticipo, RowMaxAnticipo);
                                break;
                            }
                        case 4:
                            {
                                dgvConceptos.DataSource = miBussinesAnticipo.
                                AnticiposATerceroCuenta(IdCuentaPrestamo, FechaActual, RowAnticipo, RowMaxAnticipo);
                                break;
                            }
                        case 5:
                            {
                                dgvConceptos.DataSource = miBussinesAnticipo.AnticiposATercero
                                (IdTercero, FechaActual, FechaActual2, RowAnticipo, RowMaxAnticipo);
                                break;
                            }
                        case 6:
                            {
                                dgvConceptos.DataSource = miBussinesAnticipo.AnticiposATerceroCuenta
                                (IdCuentaAnticipo, FechaActual, FechaActual2, RowAnticipo, RowMaxAnticipo);
                                break;
                            }
                        case 7:
                            {
                                dgvConceptos.DataSource = miBussinesAnticipo.AnticiposATerceroCuenta
                                (IdCuentaPrestamo, FechaActual, FechaActual2, RowAnticipo, RowMaxAnticipo);
                                break;
                            }
                        case 10:
                            {
                                dgvConceptos.DataSource = miBussinesAnticipo.AnticiposSaldo(RowAnticipo, RowMaxAnticipo);
                                break;
                            }
                    }
                    ColorearPagadas();
                    lblStatus.Text = CurrentPageAnticipo + " / " + PaginasAnticipo;
                    if (!dgvConceptos.RowCount.Equals(0))
                    {
                        dgvConceptos_CellClick(this.dgvConceptos, null);
                    }
                }
                catch (Exception ex)
                {
                    OptionPane.MessageError(ex.Message);
                }
            }
        }

        public void CargarDatos()
        {
            try
            {
                var lst = new List<Inventario.Producto.Criterio>();
                lst.Add(new Inventario.Producto.Criterio
                {
                    Id = 0,
                    Nombre = "Todos",
                });
                lst.Add(new Inventario.Producto.Criterio
                {
                    Id = 1,
                    Nombre = "Tercero",
                });
                lst.Add(new Inventario.Producto.Criterio
                {
                    Id = 2,
                    Nombre = "Terceros con saldo",
                });
               /* lst.Add(new Inventario.Producto.Criterio
                {
                    Id = 2,
                    Nombre = "Anticipo",
                });
                lst.Add(new Inventario.Producto.Criterio
                {
                    Id = 3,
                    Nombre = "Préstamo",
                });*/
                cbCriterio.DataSource = lst;

                lst = new List<Inventario.Producto.Criterio>();
              /*  lst.Add(new Inventario.Producto.Criterio
                {
                    Id = 0,
                    Nombre = "",
                });*/
                lst.Add(new Inventario.Producto.Criterio
                {
                    Id = 1,
                    Nombre = "Fecha",
                });
                lst.Add(new Inventario.Producto.Criterio
                {
                    Id = 2,
                    Nombre = "Periodo",
                });
                cbFecha.DataSource = lst;
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
                txtTercero.Text = ((Cliente)args.MiZona).NitCliente;
            }
            catch { }
        }

        void CompletaEventos_Completa(CompletaArgumentosDeEvento args)
        {
            try
            {
                if (Transfer)
                {
                    var objeto = (ObjectAbstract)args.MiObjeto;
                    if (objeto.Id.Equals(200))
                    {
                        var pagos = (List<FormaPago>)objeto.Objeto;
                        CargarAbono(pagos);
                        this.dgvConceptos_CellClick(this.dgvConceptos, null);
                    }
                    Transfer = false;
                }
            }
            catch { }
        }

        private void ColorearPagadas()
        {
            foreach (DataGridViewRow row in this.dgvConceptos.Rows)
            {
                if (Convert.ToBoolean(row.Cells["Pago"].Value))
                {
                    row.DefaultCellStyle.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
                }
            }

            foreach (DataGridViewRow row in this.dgvConceptos.Rows)
            {
                if (!Convert.ToBoolean(row.Cells["Estado"].Value))
                {
                    row.DefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(200, 128, 128);
                }
            }
        }

        /// <summary>
        /// Calcula y muestra el número de paginas devueltas en la consulta.
        /// </summary>
        private void CalcularPaginas()
        {
            PaginasAnticipo = TotalRowAnticipo / RowMaxAnticipo;
            if (TotalRowAnticipo % RowMaxAnticipo != 0)
                PaginasAnticipo++;
            if (CurrentPageAnticipo > PaginasAnticipo)
                CurrentPageAnticipo = 0;
            lblStatus.Text = CurrentPageAnticipo + " / " + PaginasAnticipo;
        }

        private void CargarAbono(List<FormaPago> pagos)
        {
            var rowAnticipo = dgvConceptos.CurrentRow;
            var idCuenta = Convert.ToInt32(rowAnticipo.Cells["IdSubCuenta"].Value);
            var frmDocumento = new FrmDocumento();
            DialogResult rta = DialogResult.No;
            if (rta.Equals(DialogResult.Yes)) // Comprobante de Ingresos
            {
                try
                {
                    var ingreso = new Ingreso();
                    ingreso.Numero = miBussinesConsecutivo.Consecutivo("Ingreso");
                    if (idCuenta.Equals(IdCuentaAnticipo))
                    {
                        ingreso.Concepto = "REINTEGRO DE ANTICIPO.";
                    }
                    else
                    {
                        ingreso.Concepto = "ABONO A PRÉSTAMO.";
                    }
                    ingreso.Tipo = 2;
                    ingreso.Relacion = Convert.ToInt32(rowAnticipo.Cells["IdTercero_"].Value);
                    ingreso.Fecha = DateTime.Now;
                    ingreso.Valor = Convert.ToInt32(pagos.Sum(s => s.Valor));
                    ingreso.NitCliente = rowAnticipo.Cells["Nit"].Value.ToString();
                    ingreso.IdCaja = Convert.ToInt32(AppConfiguracion.ValorSeccion("id_caja"));
                    ingreso.IdUsuario = Convert.ToInt32(AppConfiguracion.ValorSeccion("id_user"));
                    ingreso.FormasPago = pagos;
                    var id = miBussinesIngreso.Ingresar(ingreso, false);
                    /*foreach (FormaPago pago in pagos)
                    {
                        pago.IdEgreso = id;
                        miBussinesIngreso.IngresarFormasPago(pago);
                    }*/
                    //guardar pago_anticipo_prestamo
                    var pagoAnticipo = new PagoAnticipo();
                    pagoAnticipo.IdAnticipo = Convert.ToInt32(rowAnticipo.Cells["Id"].Value);
                    pagoAnticipo.IdConcepto = 1; // 1 Abono.
                    pagoAnticipo.Tipo = 2;       // 2 Comprobante de Ingreso.
                    pagoAnticipo.Concepto = "COMPROBANTE DE INGRESO";
                    pagoAnticipo.NoDocumento = ingreso.Numero;
                    pagoAnticipo.Valor = ingreso.Valor;
                    pagoAnticipo.Fecha = ingreso.Fecha;
                    pagoAnticipo.Pagos = pagos;
                    miBussinesAnticipo.IngresarPagoAnticipo(pagoAnticipo);

                    PrintIngreso(ingreso);
                }
                catch (Exception ex)
                {
                    OptionPane.MessageError(ex.Message);
                }
            }
            else  // Recibo de Caja
            {
                try
                {
                    var otroIngreso = new OtroIngreso();
                    otroIngreso.Numero = miBussinesConsecutivo.Consecutivo("ReciboCaja");
                    otroIngreso.IdUsuario = Convert.ToInt32(AppConfiguracion.ValorSeccion("id_user"));
                    otroIngreso.IdCaja = Convert.ToInt32(AppConfiguracion.ValorSeccion("id_caja"));
                    otroIngreso.Tipo = Convert.ToInt32(rowAnticipo.Cells["IdTercero_"].Value);
                    otroIngreso.Fecha = DateTime.Now;
                    otroIngreso.Valor = Convert.ToInt32(pagos.Sum(s => s.Valor));
                    if (idCuenta.Equals(IdCuentaAnticipo))
                    {
                        otroIngreso.Conceptos.Add(new ConceptoOtroIngreso
                        {
                            Codigo = 1,
                            Nombre = "REINTEGRO DE ANTICIPO.",
                            Valor = otroIngreso.Valor
                        });
                        //ingreso.Concepto = "REINTEGRO DE ANTICIPO.";
                    }
                    else
                    {
                        otroIngreso.Conceptos.Add(new ConceptoOtroIngreso
                        {
                            Codigo = 2,
                            Nombre = "ABONO A PRÉSTAMO.",
                            Valor = otroIngreso.Valor
                        });
                        //ingreso.Concepto = "ABONO A PRÉSTAMO.";
                    }
                    otroIngreso.FormasPago = pagos;
                    otroIngreso.Id = miBussinesOtroIngreso.AlmacenarIngreso(otroIngreso);

                    //guardar pago_anticipo_prestamo
                    var pagoAnticipo = new PagoAnticipo();
                    pagoAnticipo.IdAnticipo = Convert.ToInt32(rowAnticipo.Cells["Id"].Value);
                    pagoAnticipo.IdConcepto = 1; // 1 Abono.
                    pagoAnticipo.Tipo = 3;       // 3 Recibo de Caja.
                    pagoAnticipo.Concepto = "RECIBO DE CAJA";
                    pagoAnticipo.NoDocumento = otroIngreso.Numero;
                    pagoAnticipo.Valor = otroIngreso.Valor;
                    pagoAnticipo.Fecha = otroIngreso.Fecha;
                    pagoAnticipo.Pagos = pagos;
                    miBussinesAnticipo.IngresarPagoAnticipo(pagoAnticipo);

                    if (this.BtnSearch)
                    {
                        this.btnBuscar_Click(this.btnBuscar, new EventArgs());
                    }
                    else
                    {
                        this.tsBtnListarTodos_Click(this.tsBtnListarTodos, new EventArgs());
                    }

                    PrintReciboCaja(otroIngreso);
                }
                catch (Exception ex)
                {
                    OptionPane.MessageError(ex.Message);
                }
            }
        }

        private void PrintIngreso(Ingreso ingreso)
        {
            try
            {
                FrmPrint frmPrint = new FrmPrint();
                frmPrint.StringCaption = "Préstamos y anticipos";
                frmPrint.StringMessage = "Impresión del comprobante de ingreso";
                DialogResult rta = frmPrint.ShowDialog();

                if (!rta.Equals(DialogResult.Cancel))
                {
                    var tercero = miBussinesTercero.BeneficiarioId(ingreso.Relacion);

                    var printComprobante = new Ventas.Cliente.FrmPrintAnticipo();
                    printComprobante.Numero = ingreso.Numero;
                    printComprobante.Fecha = ingreso.Fecha;
                    printComprobante.Cliente = tercero.NombresCliente;
                    printComprobante.Nit = tercero.NitCliente;
                    printComprobante.Direccion = " ";
                    printComprobante.Valor = ingreso.Valor.ToString();
                    printComprobante.Concepto = ingreso.Concepto;
                    printComprobante.Efectivo =
                     ingreso.FormasPago.Where(p => p.IdFormaPago.Equals(1)).Sum(s => s.Valor).ToString();
                    printComprobante.Cheque =
                     ingreso.FormasPago.Where(p => p.IdFormaPago.Equals(2)).Sum(s => s.Valor).ToString();
                    printComprobante.Transaccion =
                        ingreso.FormasPago.Where(p => p.IdFormaPago.Equals(4)).Sum(s => s.Valor).ToString();

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
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
        }

        private void PrintReciboCaja(OtroIngreso otroIngreso)
        {
            try
            {
                if (Convert.ToBoolean(AppConfiguracion.ValorSeccion("printRboCaja")))
                {
                    var bussinesEmpresa = new BussinesEmpresa();
                    var bussinesCaja = new BussinesCaja();
                    var bussinesUser = new BussinesUsuario();

                    var MiEmpresa = bussinesEmpresa.ObtenerEmpresa();
                    var caja = bussinesCaja.CajaId(otroIngreso.IdCaja);
                    var usuario = bussinesUser.ConsultaUsuario(otroIngreso.IdUsuario).AsEnumerable().First()["nombre"].ToString();
                    var cliente = miBussinesTercero.BeneficiarioId(otroIngreso.Tipo);

                    Ticket ticket = new Ticket();

                    ticket.AddHeaderLine(MiEmpresa.NombreComercialEmpresa.ToUpper());
                    ticket.AddHeaderLine(MiEmpresa.NombreJuridicoEmpresa.ToString());
                    ticket.AddHeaderLine("NIT " + UseObject.InsertSeparatorMilMasDigito(MiEmpresa.NitEmpresa));
                    ticket.AddHeaderLine(MiEmpresa.DireccionEmpresa);
                    ticket.AddHeaderLine("Tels. " + MiEmpresa.TelefonoEmpresa);
                    ticket.AddHeaderLine("Fecha : " + otroIngreso.Fecha.ToShortDateString() +
                                         "    Caja : " + caja.Numero);
                    ticket.AddHeaderLine("Cajero(a)  :  " + usuario);
                    ticket.AddHeaderLine("===================================");
                    ticket.AddHeaderLine("RECIBO DE CAJA Nro " + otroIngreso.Numero);
                    ticket.AddHeaderLine("===================================");
                    ticket.AddHeaderLine("Recibido de : " + cliente.NombresCliente);
                    ticket.AddHeaderLine("NIT o C.C.  : " + UseObject.InsertSeparatorMilMasDigito(cliente.NitCliente));
                    ticket.AddHeaderLine("===================================");
                    foreach (DataRow concepto in miBussinesOtroIngreso.ConceptosDeIngreso(otroIngreso.Id).Rows)
                    {
                        ticket.AddItem("",
                                       concepto["concepto"].ToString(),
                                       UseObject.InsertSeparatorMil(concepto["valor"].ToString()));
                    }
                    ticket.AddTotal("TOTAL ", UseObject.InsertSeparatorMil(otroIngreso.Valor.ToString()));
                    ticket.AddTotal(" ", " ");
                    foreach (DataRow pago in miBussinesOtroIngreso.FormasDePago(otroIngreso.Id).Rows)
                    {
                        string namePago = "";
                        switch (Convert.ToInt32(pago["idforma_pago"]))
                        {
                            case 1:
                                {
                                    namePago = "Efectivo";
                                    break;
                                }
                            case 2:
                                {
                                    namePago = "Cheque";
                                    break;
                                }
                            case 4:
                                {
                                    namePago = "Transacción";
                                    break;
                                }
                        }
                        ticket.AddTotal(namePago,
                                        UseObject.InsertSeparatorMil(pago["valor"].ToString()));
                    }
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
                    ticket.AddFooterLine("solucionestecnologicasayc@gmail.com");
                    ticket.AddFooterLine(".");

                    ticket.PrintTicket("IMPREPOS");
                }
                else
                {
                    FrmPrint frmPrint = new FrmPrint();
                    frmPrint.StringCaption = "Préstamos y anticipos";
                    frmPrint.StringMessage = "Impresión del Recibo de Caja";
                    DialogResult rta = frmPrint.ShowDialog();

                    if (!rta.Equals(DialogResult.Cancel))
                    {
                        var tercero = miBussinesTercero.BeneficiarioId(otroIngreso.Tipo);
                        var frmPrintIngreso = new Ventas.Ingresos.FrmPrintIngreso();
                        frmPrintIngreso.Numero = otroIngreso.Numero;
                        frmPrintIngreso.Fecha = otroIngreso.Fecha;
                        frmPrintIngreso.Cliente = tercero.NombresCliente;
                        frmPrintIngreso.Nit = tercero.NitCliente;
                        frmPrintIngreso.DsConcepto = miBussinesOtroIngreso.ConceptosDeIngreso(
                            miBussinesOtroIngreso.Ingreso(otroIngreso.Numero).Id);
                        frmPrintIngreso.Valor = otroIngreso.Valor.ToString();
                        frmPrintIngreso.Efectivo =
                            otroIngreso.FormasPago.Where(p => p.IdFormaPago.Equals(1)).Sum(s => s.Valor).ToString();
                        frmPrintIngreso.Cheque =
                            otroIngreso.FormasPago.Where(p => p.IdFormaPago.Equals(2)).Sum(s => s.Valor).ToString();
                        frmPrintIngreso.Transaccion =
                            otroIngreso.FormasPago.Where(p => p.IdFormaPago.Equals(4)).Sum(s => s.Valor).ToString();

                        if (rta.Equals(DialogResult.No))
                        {
                            frmPrintIngreso.ShowDialog();
                        }
                        else
                        {
                            if (rta.Equals(DialogResult.Yes))
                            {
                                Imprimir print = new Imprimir();
                                print.Report = frmPrintIngreso.CargarDatos();
                                print.Print(Imprimir.TamanioPapel.MediaCarta);
                                frmPrintIngreso.ResetReport();
                            }
                        }
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