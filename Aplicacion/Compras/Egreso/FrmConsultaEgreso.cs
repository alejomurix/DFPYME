using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BussinesLayer.Clases;
using DTO.Clases;
using CustomControl;
using Utilities;
using Microsoft.Reporting.WinForms;
using System.Threading;

namespace Aplicacion.Compras.Egreso
{
    public partial class frmConsultarEgreso : Form
    {
        private int IdCuentaEgreso { set; get; }

        private int IdCuentaRetencion { set; get; }

        private BussinesEgreso miBussinesEgreso;

        private BussinesUsuario miBussinesUsuario;

        private BussinesCliente miBussinesCliente;

        private BussinesProveedor miBussinesProveedor;

        private BussinesBeneficio miBussinesBeneficio;

        private BussinesFormaPago miBussinesPago;

        private bool BtnSearch { set; get; }

        /// <summary>
        /// Obteien o establece el numero que indica que iteracion se realizo.
        /// </summary>
        private int Iteracion;

        /// <summary>
        /// Obtiene o establece el valor del registro a segir o registro base.
        /// </summary>
        private int RowEgreso;

        /// <summary>
        /// Obtiene o establece el número maximo de registro a cargar.
        /// </summary>
        private int RowMaxEgreso;

        /// <summary>
        /// Obtiene o establece el total de registros en la base de datos.
        /// </summary>
        private long TotalRowEgreso;

        /// <summary>
        /// Obtiene o establece el número total de paginas que componen la consulta.
        /// </summary>
        private long PaginasEgreso;

        /// <summary>
        /// Obtiene o establece el número de la pagina actual.
        /// </summary>
        private int CurrentPageEgreso;

        private int CriterioPrint { set; get; }

        private DataTable TablaInforme { set; get; }

        private bool AnuladoActual;

        private string NumeroActual { set; get; }

        private DateTime FechaActual;

        private DateTime FechaActual1;

        private int IdBeneficioActual;

        private ErrorProvider miError;

        private Thread miThread;

        private OptionPane miOption;

        private ToolTip miToolTip;

        List<RetencionConcepto> Retenciones { set; get; }

        public frmConsultarEgreso()
        {
            InitializeComponent();
            this.TransPago = false;
            this.BtnSearch = false;
            this.miToolTip = new ToolTip();
            chkAnulado.Checked = true;
            this.CriterioPrint = 0;
            miError = new ErrorProvider();
            this.Retenciones = new List<RetencionConcepto>();
            miBussinesEgreso = new BussinesEgreso();
            miBussinesUsuario = new BussinesUsuario();
            miBussinesCliente = new BussinesCliente();
            miBussinesProveedor = new BussinesProveedor();
            miBussinesBeneficio = new BussinesBeneficio();
            miBussinesPago = new BussinesFormaPago();
            RowMaxEgreso = 10;
            try
            {
                this.IdCuentaEgreso = Convert.ToInt32(AppConfiguracion.ValorSeccion("ctaEgreso"));
                this.IdCuentaRetencion = Convert.ToInt32(AppConfiguracion.ValorSeccion("ctaRetencion"));
            }
            catch (Exception)
            {
                this.IdCuentaEgreso = 0;
                this.IdCuentaRetencion = 0;
            }
        }

        private void FrmConsultaEgreso_Load(object sender, EventArgs e)
        {
            CargarUtilidades();
            this.miToolTip.SetToolTip(this.btnEditarEgreso, "Editar Egreso");
            this.miToolTip.SetToolTip(this.btnEditarConcepto, "Editar Concepto");
            this.miToolTip.SetToolTip(this.btnRetencion, "Agregar Retención");
            this.miToolTip.SetToolTip(this.btnEliminar, "Eliminar Retención");
            this.miToolTip.SetToolTip(this.btnEditarPago, "Editar Pagos");
            dgvEgreso.AutoGenerateColumns = false;
            dgvCuentas.AutoGenerateColumns = false;
            CompletaEventos.Completaz += new CompletaEventos.CompletaAccionz(CompletaEventos_Completaz);
            CompletaEventos.Completaeb += new CompletaEventos.CompletaAccioneb(CompletaEventos_Completaeb);
        }

        private void tsBtnListarTodos_Click(object sender, EventArgs e)
        {
            this.BtnSearch = false;
            RowEgreso = 0;
            Iteracion = 3;
            CurrentPageEgreso = 1;
            AnuladoActual = chkAnulado.Checked;
            try
            {
                dgvEgreso.DataSource =
                    miBussinesEgreso.Listado(chkAnulado.Checked, RowEgreso, RowMaxEgreso);
                TotalRowEgreso = miBussinesEgreso.GetRowslistado(chkAnulado.Checked);
                if (!dgvEgreso.RowCount.Equals(0))
                {
                    dgvEgreso_CellClick(this.dgvEgreso, null);
                }
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
            CalcularPaginas();
            ColorearAnualados();
        }

        private void tsBtnEditar_Click(object sender, EventArgs e)
        {
            /* if (dgvEgreso.RowCount != 0)
             {
                 string rta = CustomControl.OptionPane.OptionBox
                     ("Ingresar contraseña de Administrador .", "Administrador", CustomControl.OptionPane.Icon.LoginAdmin);
                 if (!rta.Equals("false"))
                 {
                     if (miBussinesUsuario.VerificarUsuarioAdmin(Encode.Encrypt(rta)))
                     {
                         var frmEdit = new Edit.FrmEgreso();
                         frmEdit.Id = Convert.ToInt32(dgvEgreso.CurrentRow.Cells["Id"].Value);
                         frmEdit.MdiParent = this.MdiParent;
                         frmEdit.Show();
                     }
                     else
                     {
                         MessageBox.Show("La contraseña es Incorrecta.", "Egresos",
                             MessageBoxButtons.OK, MessageBoxIcon.Error);
                     }
                 }
             }
             else
             {
                 OptionPane.MessageInformation("No hay registros para editar.");
             }*/
        }

        private void tsBtnCopia_Click(object sender, EventArgs e)
        {
            if (dgvEgreso.RowCount != 0)
            {
                //this.dgvListadocategoria.Rows[this.dgvListadocategoria.CurrentCell.RowIndex];
                var registro = dgvEgreso.Rows[dgvEgreso.CurrentCell.RowIndex];
                if (registro.Cells["Estado"].Value.ToString().Equals("Activo"))
                {
                    try
                    {
                        if (Convert.ToBoolean(AppConfiguracion.ValorSeccion("printEgreso")))
                        {
                            var items = miBussinesEgreso.EgresoPuc(Convert.ToInt32(registro.Cells["Id"].Value));
                            PrintEgresoPos(registro.Cells["Numero"].Value.ToString(), items);
                        }
                        else
                        {
                            var frmPrint = new FrmPrintComprobante();
                            // frmPrint.MdiParent = this.MdiParent;
                            frmPrint.Numero = registro.Cells["Numero"].Value.ToString();
                            frmPrint.Fecha = Convert.ToDateTime(registro.Cells["Fecha"].Value);
                            var beneficia = "";
                            var c = miBussinesBeneficio.BeneficiarioId(Convert.ToInt32(registro.Cells["Tipo"].Value));
                            beneficia = c.NombresCliente + "  CC o NIT: " + c.NitCliente;
                            frmPrint.Remite = beneficia;
                            //Beneficia
                            var pagos = new List<FormaPago>();
                            try
                            {
                                pagos = miBussinesEgreso.PagosEgreso(Convert.ToInt32(registro.Cells["Id"].Value));
                            }
                            catch (Exception ex)
                            {
                                OptionPane.MessageError(ex.Message);
                            }
                            //frmPrint.Cuentas = Cuentas(Convert.ToInt32(registro.Cells["Id"].Value));
                            frmPrint.Cuentas = miBussinesEgreso.Cuentas(Convert.ToInt32(registro.Cells["Id"].Value));

                            frmPrint.Efectivo = pagos.Where(p => p.IdFormaPago.Equals(1)).Sum(s => s.Valor).ToString();
                            //frmPrint.Efectivo = frmPrint.Cuentas.AsEnumerable().Sum(s => s.Field<int>("Valor")).ToString();
                            frmPrint.Cheque = pagos.Where(p => p.IdFormaPago.Equals(2)).Sum(s => s.Valor).ToString();
                            frmPrint.Transaccion = pagos.Where(p => p.IdFormaPago.Equals(4)).Sum(s => s.Valor).ToString();
                            /*var efe = 0;
                            var che = 0;
                            foreach (var pago in pagos)
                            {
                                if (pago.IdFormaPago.Equals(1))
                                {
                                    efe += Convert.ToInt32(pago.Valor);
                                }
                                else
                                {
                                    che += Convert.ToInt32(pago.Valor);
                                }
                            }
                            frmPrint.Cheque = che.ToString();
                            frmPrint.Efectivo = efe.ToString();*/


                            /*DialogResult rta = MessageBox.Show("¿Desea visualizar la impresión del egreso?", "Comprobante de Egreso",
                                                                  MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);*/
                            FrmPrint frmPrint_ = new FrmPrint();
                            frmPrint_.StringCaption = "Consulta de Egresos";
                            frmPrint_.StringMessage = "Impresión del Comprobante de Egreso";
                            DialogResult rta = frmPrint_.ShowDialog();

                            if (rta.Equals(DialogResult.No))
                            {
                                frmPrint.ShowDialog();
                            }
                            else
                            {
                                if (rta.Equals(DialogResult.Yes))
                                {
                                    var no = Convert.ToInt32(AppConfiguracion.ValorSeccion("copyEgreso"));
                                    Imprimir print = new Imprimir();
                                    for (int i = 1; i <= no; i++)
                                    {
                                        print.Report = frmPrint.CargarDatos();
                                        print.Print(Imprimir.TamanioPapel.MediaCarta);
                                        frmPrint.ResetReport();
                                    }
                                }
                            }
                            //frmPrint.ShowDialog();
                        }
                    }
                    catch (Exception ex)
                    {
                        OptionPane.MessageError(ex.Message);
                    }
                }
                else
                {
                    OptionPane.MessageInformation("El registro de Egreso no se puede imprimir porque esta anulado.");
                }
            }
            else
            {
                OptionPane.MessageInformation("No hay registros para imprimir.");
            }
        }

        private void tsBtnImprimirConsulta_Click(object sender, EventArgs e)
        {
            try
            {
                TablaInforme = new DataTable();
                miOption = new OptionPane();
                miOption.FrmProgressBar.barraProgreso.Style = ProgressBarStyle.Marquee;
                miOption.FrmProgressBar.Closed_ = true;
                miOption.ProgressShow("Espere mientras se realizan las operaciones necesarias...",
                    "Operacion en progreso");
                miThread = new Thread(Consulta);
                miThread.Start();
                /* switch (CriterioPrint)
                 {
                     case 1:
                         {
                             TablaInforme = miBussinesEgreso.Egresos(this.IdCuentaEgreso, NumeroActual);
                             break;
                         }
                     case 2:
                         {
                             TablaInforme = miBussinesEgreso.Egresos(this.IdCuentaEgreso, FechaActual);
                             break;
                         }
                     case 3:
                         {
                             TablaInforme = 
                                 miBussinesEgreso.Egresos(this.IdCuentaEgreso, FechaActual, FechaActual1);
                             break;
                         }
                     case 4:
                         {
                             TablaInforme = miBussinesEgreso.Egresos(this.IdCuentaEgreso, IdBeneficioActual);
                             break;
                         }
                     case 5:
                         {
                             TablaInforme =
                                 miBussinesEgreso.Egresos(this.IdCuentaEgreso, IdBeneficioActual, FechaActual);
                             break;
                         }
                     case 6:
                         {
                             TablaInforme = miBussinesEgreso.Egresos(
                                 this.IdCuentaEgreso, IdBeneficioActual, FechaActual, FechaActual1);
                             break;
                         }
                 }*/
                /*var miBussinesEmpresa = new BussinesEmpresa();
                var frmPrint = new FrmPrintInforme();

                frmPrint.rpvEgresos.LocalReport.DataSources.Clear();
                frmPrint.rpvEgresos.LocalReport.Dispose();
                frmPrint.rpvEgresos.Reset();

                frmPrint.rpvEgresos.LocalReport.DataSources.Add(
                    new ReportDataSource("DsEmpresa",
                        miBussinesEmpresa.PrintEmpresa().Tables[0]));
                frmPrint.rpvEgresos.LocalReport.DataSources.Add(
                    new ReportDataSource("DsEgresos", TablaInforme));
                frmPrint.rpvEgresos.LocalReport.ReportPath = AppConfiguracion.ValorSeccion("report") + @"\reports\InformeDeEgresos.rdlc";
                var pFecha = new ReportParameter();
                pFecha.Name = "Fecha";
                pFecha.Values.Add(FechaActual.ToShortDateString());
                frmPrint.rpvEgresos.LocalReport.SetParameters(pFecha);
                var pFecha2 = new ReportParameter();
                pFecha2.Name = "Fecha2";
                pFecha2.Values.Add(FechaActual1.ToShortDateString());
                frmPrint.rpvEgresos.LocalReport.SetParameters(pFecha2);
                frmPrint.rpvEgresos.RefreshReport();
                frmPrint.ShowDialog();*/
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
        }

        private void tsBtnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cbCriterio_SelectionChangeCommitted(object sender, EventArgs e)
        {
            switch (Convert.ToInt32(cbCriterio.SelectedValue))
            {
                case 1:
                    {
                        lblName.Text = "Número";
                        txtNumero.Text = "";
                        txtNumero.Enabled = true;
                        btnBuscarBeneficiario.Enabled = false;
                        cbFecha.Enabled = false;
                        dtpFecha.Enabled = false;
                        dtpFecha1.Enabled = false;
                        break;
                    }
                case 2:
                    {
                        lblName.Text = "Número";
                        txtNumero.Text = "";
                        txtNumero.Enabled = false;
                        btnBuscarBeneficiario.Enabled = false;
                        dtpFecha.Enabled = true;
                        cbFecha.Enabled = true;
                        break;
                    }
                case 3:
                    {
                        lblName.Text = "C.C. o NIT";
                        txtNumero.Text = "";
                        txtNumero.Enabled = true;
                        btnBuscarBeneficiario.Enabled = true;
                        cbFecha.Enabled = false;
                        dtpFecha.Enabled = false;
                        dtpFecha1.Enabled = false;
                        cbFecha.Enabled = true;
                        cbFecha.SelectedIndex = 0;
                        break;
                    }
            }
            /*if (Convert.ToInt32(cbCriterio.SelectedValue).Equals(1))
            {
                txtNumero.Enabled = true;
                cbFecha.Enabled = false;
                dtpFecha.Enabled = false;
                dtpFecha1.Enabled = false;
            }
            else
            {
                
                txtNumero.Enabled = false;
                dtpFecha.Enabled = true;
                cbFecha.Enabled = true;
            }*/
        }

        private void btnBuscarBeneficiario_Click(object sender, EventArgs e)
        {
            var frmBeneficio = new Beneficiario.FrmBeneficio();
            //frmBeneficio.MdiParent = this.MdiParent;
            frmBeneficio.tcBeneficio.SelectTab(1);
            frmBeneficio.ShowDialog();
        }

        private void txtNumero_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar.Equals((char)Keys.Enter))
            {
                btnBuscar_Click(btnBuscarFe, new EventArgs());
            }
        }

        private void cbFecha_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (Convert.ToInt32(cbFecha.SelectedValue).Equals(1))
            {
                dtpFecha.Enabled = true;
                dtpFecha1.Enabled = false;
            }
            else
            {
                dtpFecha.Enabled = true;
                dtpFecha1.Enabled = true;
            }
        }

        /*private void btnBuscarNo_Click(object sender, EventArgs e)
        {
            CurrentPageEgreso = 1;
            try
            {
                dgvEgreso.DataSource = miBussinesEgreso.Listado(txtNumero.Text.ToUpper());
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
            lblStatusEgreso.Text = "1 / 1";
        }*/

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            this.BtnSearch = true;
            var id = Convert.ToInt32(cbCriterio.SelectedValue);
            if (id.Equals(1))//numero
            {
                CurrentPageEgreso = 1;
                PaginasEgreso = 1;
                Iteracion = 0;
                try
                {
                    NumeroActual = txtNumero.Text;
                    dgvEgreso.DataSource = miBussinesEgreso.Listado(txtNumero.Text.ToUpper());
                    if (dgvEgreso.RowCount.Equals(0))
                    {
                        LimpiarCuentas();
                        OptionPane.MessageInformation("No se encontrarón registros de Egreso con ese Número.");
                    }
                    CriterioPrint = 1;
                }
                catch (Exception ex)
                {
                    OptionPane.MessageError(ex.Message);
                }
                lblStatusEgreso.Text = "1 / 1";
            }
            else
            {
                if (id.Equals(2))//fecha
                {
                    if (Convert.ToInt32(cbFecha.SelectedValue).Equals(1))// Fecha simple
                    {
                        RowEgreso = 0;
                        Iteracion = 1;
                        CurrentPageEgreso = 1;
                        FechaActual = dtpFecha.Value;
                        FechaActual1 = dtpFecha1.Value;
                        AnuladoActual = chkAnulado.Checked;
                        try
                        {
                            dgvEgreso.DataSource =
                                miBussinesEgreso.Listado(dtpFecha.Value, chkAnulado.Checked, RowEgreso, RowMaxEgreso);
                            TotalRowEgreso = miBussinesEgreso.GetRowslistado(dtpFecha.Value, chkAnulado.Checked);
                            if (dgvEgreso.RowCount.Equals(0))
                            {
                                LimpiarCuentas();
                                OptionPane.MessageInformation("No se encontrarón registros de Egreso en esa Fecha.");
                            }
                            CriterioPrint = 2;
                        }
                        catch (Exception ex)
                        {
                            OptionPane.MessageError(ex.Message);
                        }
                    }
                    else // periodo
                    {
                        RowEgreso = 0;
                        Iteracion = 2;
                        CurrentPageEgreso = 1;
                        FechaActual = dtpFecha.Value;
                        FechaActual1 = dtpFecha1.Value;
                        AnuladoActual = chkAnulado.Checked;
                        try
                        {
                            dgvEgreso.DataSource = miBussinesEgreso.Listado
                                (dtpFecha.Value, dtpFecha1.Value, chkAnulado.Checked, RowEgreso, RowMaxEgreso);
                            TotalRowEgreso = miBussinesEgreso.GetRowslistado
                                (dtpFecha.Value, dtpFecha1.Value, chkAnulado.Checked);
                            if (dgvEgreso.RowCount.Equals(0))
                            {
                                LimpiarCuentas();
                                OptionPane.MessageInformation("No se encontrarón registros de Egreso en ese periodo.");
                            }
                            CriterioPrint = 3;
                        }
                        catch (Exception ex)
                        {
                            OptionPane.MessageError(ex.Message);
                        }
                    }
                }
                else // Beneficiario
                {
                    try
                    {
                        if (!String.IsNullOrEmpty(txtNumero.Text))
                        {
                            miError.SetError(txtNumero, null);
                            var tTercero = miBussinesBeneficio.BeneficiariosNit(txtNumero.Text);
                            if (tTercero.Rows.Count > 0)
                            {
                                IdBeneficioActual = Convert.ToInt32(tTercero.AsEnumerable().First()["id"]);
                                RowEgreso = 0;
                                // Iteracion = 4;
                                CurrentPageEgreso = 1;
                                FechaActual = dtpFecha.Value;
                                FechaActual1 = dtpFecha1.Value;
                            }
                            switch (Convert.ToInt32(cbFecha.SelectedValue))
                            {
                                case 0: // Beneficio
                                    {
                                        Iteracion = 4;
                                        dgvEgreso.DataSource = miBussinesEgreso.Listado(IdBeneficioActual, RowEgreso, RowMaxEgreso);
                                        TotalRowEgreso = miBussinesEgreso.GetRowslistado(IdBeneficioActual);
                                        CriterioPrint = 4;
                                        break;
                                    }
                                case 1: // Beneficio fecha
                                    {
                                        Iteracion = 5;
                                        dgvEgreso.DataSource = miBussinesEgreso.Listado
                                            (IdBeneficioActual, FechaActual, RowEgreso, RowMaxEgreso);
                                        TotalRowEgreso = miBussinesEgreso.GetRowslistado(IdBeneficioActual, FechaActual);
                                        CriterioPrint = 5;
                                        break;
                                    }
                                case 2: // Beneficio Periodo
                                    {
                                        /*var frm = new Form1();
                                        frm.dataGridView1.DataSource =
                                        miBussinesEgreso.Egresos(1, IdBeneficioActual, FechaActual, FechaActual1);
                                        frm.ShowDialog();
                                        */
                                        /*var frmPrint = new FrmPrintInforme();
                                        frmPrint.rpvEgresos.LocalReport.DataSources.Clear();
                                        frmPrint.rpvEgresos.LocalReport.Dispose();
                                        frmPrint.rpvEgresos.Reset();

                                        var bussinesEmpresa = new BussinesEmpresa();
                                        frmPrint.rpvEgresos.LocalReport.DataSources.Add(
                                            new Microsoft.Reporting.WinForms.ReportDataSource("DsEmpresa",
                                                bussinesEmpresa.PrintEmpresa().Tables[0]));
                                        frmPrint.rpvEgresos.LocalReport.DataSources.Add(
                                            new Microsoft.Reporting.WinForms.ReportDataSource("DsEgresos",
                                                miBussinesEgreso.Egresos(1, IdBeneficioActual, FechaActual, FechaActual1)));
                                        frmPrint.rpvEgresos.LocalReport.ReportPath = @"C:\reports\InformeDeEgresos.rdlc";
                                        frmPrint.rpvEgresos.RefreshReport();
                                        frmPrint.ShowDialog();*/

                                        Iteracion = 6;
                                        dgvEgreso.DataSource = miBussinesEgreso.Listado
                                            (IdBeneficioActual, FechaActual, FechaActual1, RowEgreso, RowMaxEgreso);
                                        TotalRowEgreso = miBussinesEgreso.GetRowslistado(IdBeneficioActual, FechaActual, FechaActual1);
                                        CriterioPrint = 6;
                                        break;
                                    }
                            }
                            if (dgvEgreso.RowCount.Equals(0))
                            {
                                LimpiarCuentas();
                                OptionPane.MessageInformation("No se encontrarón registros de Egreso en ese beneficiario.");
                            }
                            CalcularPaginas();
                        }
                        else
                        {
                            miError.SetError(txtNumero, "El campo Beneficiario es requerido.");
                        }
                    }
                    catch (Exception ex)
                    {
                        OptionPane.MessageError(ex.Message);
                    }



                    /*tTercero = miBussinesBeneficio.BeneficiariosNit(txtNumero.Text);
                    if (tTercero.Rows.Count > 0)
                    {
                        IdBeneficioActual = Convert.ToInt32(tTercero.AsEnumerable().First()["id"]);
                        RowEgreso = 0;
                        Iteracion = 4;
                        CurrentPageEgreso = 1;
                        try
                        {
                            dgvEgreso.DataSource = miBussinesEgreso.Listado(IdBeneficioActual, RowEgreso, RowMaxEgreso);
                            TotalRowEgreso = miBussinesEgreso.GetRowslistado(IdBeneficioActual);
                            if (dgvEgreso.RowCount.Equals(0))
                            {
                                LimpiarCuentas();
                                OptionPane.MessageInformation("No se encontrarón registros de Egreso en ese beneficiario.");
                            }
                        }
                        catch (Exception ex)
                        {
                            OptionPane.MessageError(ex.Message);
                        }
                    }
                    else
                    {
                        OptionPane.MessageInformation("El beneficiario que ingreso no se encuentra registrado.");
                    }*/
                }
                CalcularPaginas();
                ColorearAnualados();

            }
            if (!dgvEgreso.RowCount.Equals(0))
            {
                dgvEgreso_CellClick(this.dgvEgreso, null);
            }
        }

        private void btnEditarEgreso_Click(object sender, EventArgs e)
        {
            if (this.dgvEgreso.RowCount != 0)
            {
                //string rta = "";
                //bool userAdmin = false;
                try
                {
                    this.TransPago = true;
                    var egresoRow = this.dgvEgreso.CurrentRow;
                    var frmEditar = new Edit.FrmEditarEgreso();
                    frmEditar.Id = Convert.ToInt32(egresoRow.Cells["Id"].Value);
                    frmEditar.Fecha = Convert.ToDateTime(egresoRow.Cells["Fecha"].Value);
                    frmEditar.Numero = egresoRow.Cells["Numero"].Value.ToString();
                    frmEditar.IdTercero = Convert.ToInt32(egresoRow.Cells["IdBeneficio"].Value);
                    frmEditar.ShowDialog();
                    /*while (!userAdmin)
                    {
                        rta = CustomControl.OptionPane.OptionBox
                                ("Ingresar contraseña de Administrador .", "Administrador", CustomControl.OptionPane.Icon.LoginAdmin);
                        if (rta.Equals("false"))
                        {
                            break;
                        }
                        else
                        {
                            userAdmin = miBussinesUsuario.VerificarUsuarioAdmin(Utilities.Encode.Encrypt(rta));
                            if (userAdmin)
                            {
                                this.TransPago = true;
                                var egresoRow = this.dgvEgreso.CurrentRow;
                                var frmEditar = new Edit.FrmEditarEgreso();
                                frmEditar.Id = Convert.ToInt32(egresoRow.Cells["Id"].Value);
                                frmEditar.Fecha = Convert.ToDateTime(egresoRow.Cells["Fecha"].Value);
                                frmEditar.Numero = egresoRow.Cells["Numero"].Value.ToString();
                                frmEditar.IdTercero = Convert.ToInt32(egresoRow.Cells["IdBeneficio"].Value);
                                frmEditar.ShowDialog();
                            }
                        }
                    }*/
                }
                catch (Exception ex)
                {
                    OptionPane.MessageError(ex.Message);
                }
            }
            else
            {
                OptionPane.MessageInformation("No hay egresos para editar");
            }
        }

        private void btnEditarConcepto_Click(object sender, EventArgs e)
        {
            if (this.dgvCuentas.RowCount != 0)
            {
               // string rta = "";
               // bool userAdmin = false;
                try
                {
                    this.TransPago = true;
                    var conceptoRow = this.dgvCuentas.CurrentRow;
                    var frmEditar = new Edit.FrmEditarConcepto();
                    frmEditar.IdConcepto = Convert.ToInt32(conceptoRow.Cells["IdC"].Value);
                    frmEditar.Concepto = conceptoRow.Cells["Concepto"].Value.ToString();
                    frmEditar.Valor = conceptoRow.Cells["ValorC"].Value.ToString();
                    frmEditar.ShowDialog();
                    /*while (!userAdmin)
                    {
                        rta = CustomControl.OptionPane.OptionBox
                                ("Ingresar contraseña de Administrador .", "Administrador", CustomControl.OptionPane.Icon.LoginAdmin);
                        if (rta.Equals("false"))
                        {
                            break;
                        }
                        else
                        {
                            userAdmin = miBussinesUsuario.VerificarUsuarioAdmin(Utilities.Encode.Encrypt(rta));
                            if (userAdmin)
                            {
                                this.TransPago = true;
                                var conceptoRow = this.dgvCuentas.CurrentRow;
                                var frmEditar = new Edit.FrmEditarConcepto();
                                frmEditar.IdConcepto = Convert.ToInt32(conceptoRow.Cells["IdC"].Value);
                                frmEditar.Concepto = conceptoRow.Cells["Concepto"].Value.ToString();
                                frmEditar.Valor = conceptoRow.Cells["ValorC"].Value.ToString();
                                frmEditar.ShowDialog();
                            }
                        }
                    }*/
                }
                catch (Exception ex)
                {
                    OptionPane.MessageError(ex.Message);
                }
            }
            else
            {
                OptionPane.MessageInformation("No hay conceptos para editar.");
            }
        }

        private void btnRetencion_Click(object sender, EventArgs e)
        {
            if (this.dgvRetenciones.RowCount.Equals(0))
            {
                var miBussinesRetencion = new BussinesRetencion();
                var miBussinesEmpresa = new BussinesEmpresa();
                var miBussinesCuenta = new BussinesCuentaPuc();
                var regimenEmpresa = miBussinesEmpresa.ObtenerEmpresa().Regimen.IdRegimen;
                var regimenTercero = miBussinesBeneficio.BeneficiarioNit(this.txtNit.Text).IdRegimen;
                try
                {
                    DialogResult rta;
                    var id = miBussinesRetencion.IdReteCompra(regimenEmpresa, regimenTercero);
                    if (miBussinesRetencion.ExisteAplicaReteCompra(id))
                    {
                        var frmReteCompra = new FrmAplicaRetencion();
                        frmReteCompra.AplicaEgreso = true;
                        frmReteCompra.IdTipoBeneficio = regimenTercero;
                        frmReteCompra.IdTipoEmpresa = regimenEmpresa;
                        frmReteCompra.Valor = Convert.ToInt32(UseObject.RemoveSeparatorMil(this.txtTotal.Text));
                        rta = frmReteCompra.ShowDialog();
                    }
                    else
                    {
                        rta = DialogResult.No;
                    }

                    if (rta.Equals(DialogResult.Yes))
                    {
                        if (this.Retenciones.Count != 0)
                        {
                            foreach (RetencionConcepto retencion in Retenciones)
                            {
                                miBussinesCuenta.IngresarEgresoCuenta(new ConceptoEgreso
                                {
                                    Id = Convert.ToInt32(this.dgvEgreso.CurrentRow.Cells["Id"].Value),
                                    IdCuenta = retencion.IdCuentaPuc,
                                    Nombre = retencion.Concepto,
                                    Numero = retencion.CifraPesos.ToString(),
                                    Tarifa = retencion.Tarifa
                                });

                            }
                            if (this.BtnSearch)
                            {
                                this.btnBuscar_Click(this.btnBuscarFe, new EventArgs());
                            }
                            else
                            {
                                this.tsBtnListarTodos_Click(this.tsBtnListarTodos, new EventArgs());
                            }
                        }
                    }

                    /*string rta_ = "";
                    bool userAdmin = false;
                    while (!userAdmin)
                    {
                        rta_ = CustomControl.OptionPane.OptionBox
                                ("Ingresar contraseña de Administrador .", "Administrador", CustomControl.OptionPane.Icon.LoginAdmin);
                        if (rta_.Equals("false"))
                        {
                            break;
                        }
                        else
                        {
                            userAdmin = miBussinesUsuario.VerificarUsuarioAdmin(Utilities.Encode.Encrypt(rta_));
                            if (userAdmin)
                            {
                                DialogResult rta;
                                var id = miBussinesRetencion.IdReteCompra(regimenEmpresa, regimenTercero);
                                if (miBussinesRetencion.ExisteAplicaReteCompra(id))
                                {
                                    var frmReteCompra = new FrmAplicaRetencion();
                                    frmReteCompra.AplicaEgreso = true;
                                    frmReteCompra.IdTipoBeneficio = regimenTercero;
                                    frmReteCompra.IdTipoEmpresa = regimenEmpresa;
                                    frmReteCompra.Valor = Convert.ToInt32(UseObject.RemoveSeparatorMil(this.txtTotal.Text));
                                    rta = frmReteCompra.ShowDialog();
                                }
                                else
                                {
                                    rta = DialogResult.No;
                                }

                                if (rta.Equals(DialogResult.Yes))
                                {
                                    if (this.Retenciones.Count != 0)
                                    {
                                        foreach (RetencionConcepto retencion in Retenciones)
                                        {
                                            miBussinesCuenta.IngresarEgresoCuenta(new ConceptoEgreso
                                            {
                                                Id = Convert.ToInt32(this.dgvEgreso.CurrentRow.Cells["Id"].Value),
                                                IdCuenta = retencion.IdCuentaPuc,
                                                Nombre = retencion.Concepto,
                                                Numero = retencion.CifraPesos.ToString(),
                                                Tarifa = retencion.Tarifa
                                            });

                                        }
                                        if (this.BtnSearch)
                                        {
                                            this.btnBuscar_Click(this.btnBuscarFe, new EventArgs());
                                        }
                                        else
                                        {
                                            this.tsBtnListarTodos_Click(this.tsBtnListarTodos, new EventArgs());
                                        }
                                    }
                                }
                            }
                        }
                    }*/
                    
                   /* DialogResult rta;
                    var id = miBussinesRetencion.IdReteCompra(regimenEmpresa, regimenTercero);
                    if (miBussinesRetencion.ExisteAplicaReteCompra(id))
                    {
                        var frmReteCompra = new FrmAplicaRetencion();
                        frmReteCompra.AplicaEgreso = true;
                        frmReteCompra.IdTipoBeneficio = regimenTercero;
                        frmReteCompra.IdTipoEmpresa = regimenEmpresa;
                        frmReteCompra.Valor = Convert.ToInt32(UseObject.RemoveSeparatorMil(this.txtTotal.Text));
                        rta = frmReteCompra.ShowDialog();
                    }
                    else
                    {
                        rta = DialogResult.No;
                    }

                    if (rta.Equals(DialogResult.Yes))
                    {
                        if (this.Retenciones.Count != 0)
                        {
                            foreach (RetencionConcepto retencion in Retenciones)
                            {
                                miBussinesCuenta.IngresarEgresoCuenta(new ConceptoEgreso
                                {
                                    Id = Convert.ToInt32(this.dgvEgreso.CurrentRow.Cells["Id"].Value),
                                    IdCuenta = retencion.IdCuentaPuc,
                                    Nombre = retencion.Concepto,
                                    Numero = retencion.CifraPesos.ToString(),
                                    Tarifa = retencion.Tarifa
                                });
                                
                            }
                            if (this.BtnSearch)
                            {
                                this.btnBuscar_Click(this.btnBuscarFe, new EventArgs());
                            }
                            else
                            {
                                this.tsBtnListarTodos_Click(this.tsBtnListarTodos, new EventArgs());
                            }
                        }
                    }*/

                }
                catch (Exception ex)
                {
                    OptionPane.MessageError(ex.Message);
                }
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (!this.dgvRetenciones.RowCount.Equals(0))
            {
                try
                {
                    var miBussinesCuenta = new BussinesCuentaPuc();
                    DialogResult rta = MessageBox.Show("¿Esta seguro(a) de eliminar la retención?", "Consulta de egresos",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (rta.Equals(DialogResult.Yes))
                    {
                        miBussinesCuenta.EliminarEgresoCuenta(Convert.ToInt32(this.dgvRetenciones.CurrentRow.Cells["IdRetencion"].Value));
                        if (this.BtnSearch)
                        {
                            this.btnBuscar_Click(this.btnBuscarFe, new EventArgs());
                        }
                        else
                        {
                            this.tsBtnListarTodos_Click(this.tsBtnListarTodos, new EventArgs());
                        }
                    }

                    /*string rta_ = "";
                    bool userAdmin = false;
                    while (!userAdmin)
                    {
                        rta_ = CustomControl.OptionPane.OptionBox
                                ("Ingresar contraseña de Administrador .", "Administrador", CustomControl.OptionPane.Icon.LoginAdmin);
                        if (rta_.Equals("false"))
                        {
                            break;
                        }
                        else
                        {
                            userAdmin = miBussinesUsuario.VerificarUsuarioAdmin(Utilities.Encode.Encrypt(rta_));
                            if (userAdmin)
                            {
                                var miBussinesCuenta = new BussinesCuentaPuc();
                                DialogResult rta = MessageBox.Show("¿Esta seguro(a) de eliminar la retención?", "Consulta de egresos",
                                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                                if (rta.Equals(DialogResult.Yes))
                                {
                                    miBussinesCuenta.EliminarEgresoCuenta(Convert.ToInt32(this.dgvRetenciones.CurrentRow.Cells["IdRetencion"].Value));
                                    if (this.BtnSearch)
                                    {
                                        this.btnBuscar_Click(this.btnBuscarFe, new EventArgs());
                                    }
                                    else
                                    {
                                        this.tsBtnListarTodos_Click(this.tsBtnListarTodos, new EventArgs());
                                    }
                                }
                            }
                        }
                    }*/
                    

                   /* var miBussinesCuenta = new BussinesCuentaPuc();
                    DialogResult rta = MessageBox.Show("¿Esta seguro(a) de eliminar la retención?", "Consulta de egresos",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (rta.Equals(DialogResult.Yes))
                    {
                        miBussinesCuenta.EliminarEgresoCuenta(Convert.ToInt32(this.dgvRetenciones.CurrentRow.Cells["IdRetencion"].Value));
                        if (this.BtnSearch)
                        {
                            this.btnBuscar_Click(this.btnBuscarFe, new EventArgs());
                        }
                        else
                        {
                            this.tsBtnListarTodos_Click(this.tsBtnListarTodos, new EventArgs());
                        }
                    }*/

                }
                catch (Exception ex)
                {
                    OptionPane.MessageError(ex.Message);
                }
            }
            else
            {
                OptionPane.MessageInformation("No hay retenciones para eliminar.");
            }
        }

        private bool TransPago;
        private void btnEditarPago_Click(object sender, EventArgs e)
        {
           // string rta = "";
           // bool userAdmin = false;
            try
            {
                if (this.dgvEgreso.RowCount != 0)
                {
                    this.TransPago = true;
                    var frmPago = new Edit.FrmEditarPago();
                    frmPago.txtTotal.Text = this.txtValorPagado.Text;
                    frmPago.ShowDialog();
                }

                /*while (!userAdmin)
                {
                    rta = CustomControl.OptionPane.OptionBox
                            ("Ingresar contraseña de Administrador .", "Administrador", CustomControl.OptionPane.Icon.LoginAdmin);
                    if (rta.Equals("false"))
                    {
                        break;
                    }
                    else
                    {
                        userAdmin = miBussinesUsuario.VerificarUsuarioAdmin(Utilities.Encode.Encrypt(rta));
                        if (userAdmin)
                        {
                            if (this.dgvEgreso.RowCount != 0)
                            {
                                this.TransPago = true;
                                var frmPago = new Edit.FrmEditarPago();
                                frmPago.txtTotal.Text = this.txtValorPagado.Text;
                                frmPago.ShowDialog();
                            }
                        }
                    }
                }*/
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }

            /*if (this.dgvEgreso.RowCount != 0)
            {
                var frmPago = new Edit.FrmEditarPago();
                frmPago.txtTotal.Text = this.txtValorPagado.Text;
                frmPago.ShowDialog();
            }*/
        }

        private void dgvEgreso_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Up || e.KeyData == Keys.Down)
            {
                this.dgvEgreso_CellClick(this.dgvEgreso, null);
            }
        }

        private void dgvEgreso_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvEgreso.RowCount != 0)
            {
                var id = (int)dgvEgreso.CurrentRow.Cells["Id"].Value;
                try
                {
                    dgvCuentas.AutoGenerateColumns = false;
                    dgvRetenciones.AutoGenerateColumns = false;

                    var tEgresos = miBussinesEgreso.EgresoPuc(id, this.IdCuentaEgreso);
                    var tRetenciones = miBussinesEgreso.EgresoPuc(id, this.IdCuentaRetencion);
                    var tPagos = miBussinesEgreso.PagosEgreso(id);

                    dgvCuentas.DataSource = tEgresos;
                    dgvRetenciones.DataSource = tRetenciones;

                    var beneficio = miBussinesBeneficio.BeneficiarioId
                        (Convert.ToInt32(dgvEgreso.CurrentRow.Cells["IdBeneficio"].Value));
                    txtNit.Text = beneficio.NitCliente;
                    txtNombre.Text = beneficio.NombresCliente;

                    if (dgvEgreso.CurrentRow.Cells["Estado"].Value.ToString().Equals("Activo"))
                    {
                        txtTotal.Text = UseObject.InsertSeparatorMil(
                            tEgresos.AsEnumerable().Sum(s => s.Field<int>("valor")).ToString());
                        txtTotalRetencion.Text = UseObject.InsertSeparatorMil(
                            tRetenciones.AsEnumerable().Sum(s => s.Field<int>("valor")).ToString());
                        txtValorPagado.Text = UseObject.InsertSeparatorMil((
                            tEgresos.AsEnumerable().Sum(s => s.Field<int>("valor")) +
                            tRetenciones.AsEnumerable().Sum(s => s.Field<int>("valor"))).ToString());

                        txtEfectivo.Text = UseObject.InsertSeparatorMil(
                            tPagos.Where(p => p.IdFormaPago.Equals(1)).Sum(s => s.Valor).ToString());
                        txtCheque.Text = UseObject.InsertSeparatorMil(
                            tPagos.Where(p => p.IdFormaPago.Equals(2)).Sum(s => s.Valor).ToString());
                        txtTransaccion.Text = UseObject.InsertSeparatorMil(
                            tPagos.Where(p => p.IdFormaPago.Equals(4)).Sum(s => s.Valor).ToString());
                    }
                    else
                    {
                        txtTotal.Text = "0";
                        txtTotalRetencion.Text = "0";
                        txtValorPagado.Text = "0";
                        txtEfectivo.Text = "0";
                        txtCheque.Text = "0";
                        txtTransaccion.Text = "0";
                    }
                }
                catch (Exception ex)
                {
                    OptionPane.MessageError(ex.Message);
                }
            }
        }

        private void btnFormasPago_Click(object sender, EventArgs e)
        {
            if (dgvEgreso.RowCount != 0)
            {
                var frmPagos = new FrmPagosEgreso();
                frmPagos.MdiParent = this.MdiParent;
                frmPagos.txtNoEgreso.Text = dgvEgreso.CurrentRow.Cells["Numero"].Value.ToString();
                var pagos = new List<FormaPago>();
                try
                {
                    pagos = miBussinesEgreso.PagosEgreso(Convert.ToInt32(dgvEgreso.CurrentRow.Cells["Id"].Value));
                }
                catch (Exception ex)
                {
                    OptionPane.MessageError(ex.Message);
                }
                var efe = 0;
                var che = 0;
                foreach (var pago in pagos)
                {
                    if (pago.IdFormaPago.Equals(1))
                    {
                        efe += Convert.ToInt32(pago.Valor);
                    }
                    else
                    {
                        che += Convert.ToInt32(pago.Valor);
                    }
                }
                frmPagos.txtEfectivo.Text = UseObject.InsertSeparatorMil(efe.ToString());
                frmPagos.txtCheque.Text = UseObject.InsertSeparatorMil(che.ToString());
                frmPagos.Show();
            }
            else
            {
                OptionPane.MessageInformation("No hay registros para consultar.");
            }
        }

        private void btnAnular_Click(object sender, EventArgs e)
        {
            if (dgvEgreso.RowCount != 0)
            {
                if (dgvEgreso.CurrentRow.Cells["Estado"].Value.ToString().Equals("Activo"))
                {
                    DialogResult rta = MessageBox.Show("¿Está seguro(a) de querer anular el Egreso?", "Egreso",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (rta.Equals(DialogResult.Yes))
                    {
                        try
                        {
                            miBussinesEgreso.AnularEgreso
                                (Convert.ToInt32(dgvEgreso.CurrentRow.Cells["Id"].Value));
                            var egresosPagos = miBussinesPago.EgresosPagos(Convert.ToInt32(dgvEgreso.CurrentRow.Cells["Id"].Value));

                            miBussinesPago.EliminarEgresoPagos(Convert.ToInt32(dgvEgreso.CurrentRow.Cells["Id"].Value));
                            foreach (DataRow eRow in egresosPagos.Rows)
                            {
                                miBussinesPago.EliminarPagoDeCompra(Convert.ToInt32(eRow["id_pago_compra"]));
                            }
                            if (Iteracion != 3)
                            {
                                btnBuscar_Click(this.btnBuscarFe, new EventArgs());
                            }
                            else
                            {
                                this.tsBtnListarTodos_Click(this.tsBtnListarTodos, new EventArgs());
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
                    OptionPane.MessageInformation("El Egreso ya está anulado.");
                }
            }
            else
            {
                OptionPane.MessageInformation("No hay registros para anular.");
            }
        }

        /*private void btnFormasPago_Click(object sender, EventArgs e)
        {

        }

        private void btnEditarEgreso_Click(object sender, EventArgs e)
        {

        }

        private void btnAnular_Click(object sender, EventArgs e)
        {

        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {

        }

        private void btnEditarCuenta_Click(object sender, EventArgs e)
        {

        }

        private void btnEliminarCuenta_Click(object sender, EventArgs e)
        {

        }*/

        private void btnInicio_Click(object sender, EventArgs e)
        {
            if (CurrentPageEgreso > 1)
            {
                var paginaActual = CurrentPageEgreso;
                for (int i = paginaActual; i > 1; i--)
                {
                    RowEgreso = RowEgreso - RowMaxEgreso;
                    CurrentPageEgreso--;
                }
                try
                {
                    switch (Iteracion)
                    {
                        case 1:
                            {
                                dgvEgreso.DataSource =
                                    miBussinesEgreso.Listado(FechaActual, AnuladoActual, RowEgreso, RowMaxEgreso);
                                break;
                            }
                        case 2:
                            {
                                dgvEgreso.DataSource =
                                    miBussinesEgreso.Listado(FechaActual, FechaActual1, AnuladoActual, RowEgreso, RowMaxEgreso);
                                break;
                            }
                        case 3:
                            {
                                dgvEgreso.DataSource =
                                    miBussinesEgreso.Listado(AnuladoActual, RowEgreso, RowMaxEgreso);
                                break;
                            }
                        case 4:
                            {
                                dgvEgreso.DataSource =
                                    miBussinesEgreso.Listado(IdBeneficioActual, RowEgreso, RowMaxEgreso);
                                break;
                            }
                        case 5:
                            {
                                dgvEgreso.DataSource = miBussinesEgreso.Listado
                                    (IdBeneficioActual, FechaActual, RowEgreso, RowMaxEgreso);
                                break;
                            }
                        case 6:
                            {
                                dgvEgreso.DataSource = miBussinesEgreso.Listado
                                    (IdBeneficioActual, FechaActual, FechaActual1, RowEgreso, RowMaxEgreso);
                                break;
                            }
                    }
                    lblStatusEgreso.Text = CurrentPageEgreso + " / " + PaginasEgreso;
                    ColorearAnualados();
                    if (!dgvEgreso.RowCount.Equals(0))
                    {
                        dgvEgreso_CellClick(this.dgvEgreso, null);
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
            if (CurrentPageEgreso > 1)
            {
                RowEgreso = RowEgreso - RowMaxEgreso;
                if (RowEgreso <= 0)
                    RowEgreso = 0;
                try
                {
                    switch (Iteracion)
                    {
                        case 1:
                            {
                                dgvEgreso.DataSource =
                                    miBussinesEgreso.Listado(FechaActual, AnuladoActual, RowEgreso, RowMaxEgreso);
                                break;
                            }
                        case 2:
                            {
                                dgvEgreso.DataSource =
                                    miBussinesEgreso.Listado(FechaActual, FechaActual1, AnuladoActual, RowEgreso, RowMaxEgreso);
                                break;
                            }
                        case 3:
                            {
                                dgvEgreso.DataSource =
                                    miBussinesEgreso.Listado(AnuladoActual, RowEgreso, RowMaxEgreso);
                                break;
                            }
                        case 4:
                            {
                                dgvEgreso.DataSource =
                                    miBussinesEgreso.Listado(IdBeneficioActual, RowEgreso, RowMaxEgreso);
                                break;
                            }
                        case 5:
                            {
                                dgvEgreso.DataSource = miBussinesEgreso.Listado
                                    (IdBeneficioActual, FechaActual, RowEgreso, RowMaxEgreso);
                                break;
                            }
                        case 6:
                            {
                                dgvEgreso.DataSource = miBussinesEgreso.Listado
                                    (IdBeneficioActual, FechaActual, FechaActual1, RowEgreso, RowMaxEgreso);
                                break;
                            }
                    }
                    ColorearAnualados();
                    CurrentPageEgreso--;
                    lblStatusEgreso.Text = CurrentPageEgreso + " / " + PaginasEgreso;
                    if (!dgvEgreso.RowCount.Equals(0))
                    {
                        dgvEgreso_CellClick(this.dgvEgreso, null);
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
            if (CurrentPageEgreso < PaginasEgreso)
            {
                RowEgreso = RowEgreso + RowMaxEgreso;
                try
                {
                    switch (Iteracion)
                    {
                        case 1:
                            {
                                dgvEgreso.DataSource =
                                    miBussinesEgreso.Listado(FechaActual, AnuladoActual, RowEgreso, RowMaxEgreso);
                                break;
                            }
                        case 2:
                            {
                                dgvEgreso.DataSource =
                                    miBussinesEgreso.Listado(FechaActual, FechaActual1, AnuladoActual, RowEgreso, RowMaxEgreso);
                                break;
                            }
                        case 3:
                            {
                                dgvEgreso.DataSource =
                                    miBussinesEgreso.Listado(AnuladoActual, RowEgreso, RowMaxEgreso);
                                break;
                            }
                        case 4:
                            {
                                dgvEgreso.DataSource =
                                    miBussinesEgreso.Listado(IdBeneficioActual, RowEgreso, RowMaxEgreso);
                                break;
                            }
                        case 5:
                            {
                                dgvEgreso.DataSource = miBussinesEgreso.Listado
                                    (IdBeneficioActual, FechaActual, RowEgreso, RowMaxEgreso);
                                break;
                            }
                        case 6:
                            {
                                dgvEgreso.DataSource = miBussinesEgreso.Listado
                                    (IdBeneficioActual, FechaActual, FechaActual1, RowEgreso, RowMaxEgreso);
                                break;
                            }
                    }
                    ColorearAnualados();
                    CurrentPageEgreso++;
                    lblStatusEgreso.Text = CurrentPageEgreso + " / " + PaginasEgreso;
                    if (!dgvEgreso.RowCount.Equals(0))
                    {
                        dgvEgreso_CellClick(this.dgvEgreso, null);
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
            if (CurrentPageEgreso < PaginasEgreso)
            {
                var paginaActual = CurrentPageEgreso;
                for (int i = paginaActual; i < PaginasEgreso; i++)
                {
                    RowEgreso = RowEgreso + RowMaxEgreso;
                    CurrentPageEgreso++;
                }
                try
                {
                    switch (Iteracion)
                    {
                        case 1:
                            {
                                dgvEgreso.DataSource =
                                    miBussinesEgreso.Listado(FechaActual, AnuladoActual, RowEgreso, RowMaxEgreso);
                                break;
                            }
                        case 2:
                            {
                                dgvEgreso.DataSource =
                                    miBussinesEgreso.Listado(FechaActual, FechaActual1, AnuladoActual, RowEgreso, RowMaxEgreso);
                                break;
                            }
                        case 3:
                            {
                                dgvEgreso.DataSource =
                                    miBussinesEgreso.Listado(AnuladoActual, RowEgreso, RowMaxEgreso);
                                break;
                            }
                        case 4:
                            {
                                dgvEgreso.DataSource =
                                    miBussinesEgreso.Listado(IdBeneficioActual, RowEgreso, RowMaxEgreso);
                                break;
                            }
                        case 5:
                            {
                                dgvEgreso.DataSource = miBussinesEgreso.Listado
                                    (IdBeneficioActual, FechaActual, RowEgreso, RowMaxEgreso);
                                break;
                            }
                        case 6:
                            {
                                dgvEgreso.DataSource = miBussinesEgreso.Listado
                                    (IdBeneficioActual, FechaActual, FechaActual1, RowEgreso, RowMaxEgreso);
                                break;
                            }
                    }
                    ColorearAnualados();
                    lblStatusEgreso.Text = CurrentPageEgreso + " / " + PaginasEgreso;
                    if (!dgvEgreso.RowCount.Equals(0))
                    {
                        dgvEgreso_CellClick(this.dgvEgreso, null);
                    }
                }
                catch (Exception ex)
                {
                    OptionPane.MessageError(ex.Message);
                }
                //}
            }
        }

        private void CargarUtilidades()
        {
            var lst = new List<Aplicacion.Inventario.Producto.Criterio>();
            lst.Add(new Inventario.Producto.Criterio
            {
                Id = 1,
                Nombre = "Número"
            });
            lst.Add(new Inventario.Producto.Criterio
            {
                Id = 2,
                Nombre = "Fecha"
            });
            lst.Add(new Inventario.Producto.Criterio
            {
                Id = 3,
                Nombre = "Tercero"
            });
            cbCriterio.DataSource = lst;

            lst = new List<Inventario.Producto.Criterio>();
            lst.Add(new Inventario.Producto.Criterio
            {
                Id = 0,
                Nombre = ""
            });
            lst.Add(new Inventario.Producto.Criterio
            {
                Id = 1,
                Nombre = "Fecha"
            });
            lst.Add(new Inventario.Producto.Criterio
            {
                Id = 2,
                Nombre = "Periodo"
            });
            cbFecha.DataSource = lst;
        }

        /// <summary>
        /// Calcula y muestra el número de paginas devueltas en la consulta.
        /// </summary>
        private void CalcularPaginas()
        {
            PaginasEgreso = TotalRowEgreso / RowMaxEgreso;
            if (TotalRowEgreso % RowMaxEgreso != 0)
                PaginasEgreso++;
            if (CurrentPageEgreso > PaginasEgreso)
                CurrentPageEgreso = 0;
            lblStatusEgreso.Text = CurrentPageEgreso + " / " + PaginasEgreso;
        }

        private void ColorearAnualados()
        {
            //var cont = 0;
            foreach (DataGridViewRow row in dgvEgreso.Rows)
            {
                if (!row.Cells["Estado"].Value.ToString().Equals("Activo"))
                {
                    row.DefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(200, 128, 128);
                }
                /*cont++;
                if (cont % 2 != 0)
                {
                    row.DefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(200, 128, 128);
                }*/
            }
        }

        private void LimpiarCuentas()
        {
            txtNit.Text = "";
            txtNombre.Text = "";
            while (dgvCuentas.RowCount != 0)
            {
                dgvCuentas.Rows.RemoveAt(0);
            }
            while (dgvRetenciones.RowCount != 0)
            {
                dgvRetenciones.Rows.RemoveAt(0);
            }
            txtTotal.Text = "0";
            txtTotalRetencion.Text = "0";
            txtValorPagado.Text = "0";
            txtEfectivo.Text = "0";
            txtCheque.Text = "0";
            txtTransaccion.Text = "0";
        }

        private DataTable Cuentas(int idEgreso)
        {
            var tabla = new DataTable();
            tabla.TableName = "CuentaPuc";
            tabla.Columns.Add(new DataColumn("Codigo", typeof(int)));
            tabla.Columns.Add(new DataColumn("Concepto", typeof(string)));
            tabla.Columns.Add(new DataColumn("Valor", typeof(int)));
            try
            {
                var t = miBussinesEgreso.EgresoPuc(idEgreso);
                foreach (DataRow row in t.Rows)
                {
                    var row_ = tabla.NewRow();
                    row_["Codigo"] = row["codigo"];
                    row_["Concepto"] = row["concepto"];
                    row_["Valor"] = row["valor"];
                    tabla.Rows.Add(row_);
                }
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
            return tabla;
        }

        private void PrintEgresoPos(string numero, DataTable items)
        {
            try
            {
                int MaxCharacters = 35;

                var miBussinesEmpresa = new BussinesEmpresa();
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
                //ticket.AddHeaderLine(empresaRow["Direccion"].ToString());
                ticket.AddHeaderLine("Tels. " + empresaRow["Telefono"].ToString());
                ticket.AddHeaderLine("Fecha : " + egreso.Fecha.ToShortDateString() +
                                     "    Caja " + caja.Numero.ToString());
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
                foreach (DataRow row in items.Rows)
                {
                    valor = UseObject.InsertSeparatorMil(row["Valor"].ToString());
                    datos = UseObject.StringBuilderDataIzquierda(row["Concepto"].ToString(), maxCharacters_18);
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
                ticket.AddHeaderLine("");
                ticket.AddHeaderLine("===================================");
                ticket.AddHeaderLine("");
                /*foreach (var cuenta in egreso.Cuentas)
                {
                    valor = UseObject.InsertSeparatorMil(cuenta.Numero);
                    datos = UseObject.StringBuilderDataIzquierda(cuenta.Nombre, maxCharacters_18);
                    for (int i = 0; i < datos.Count; i++)
                    {
                        if (i == datos.Count - 1)
                        {
                            ticket.AddHeaderLine(cuenta.Nombre + UseObject.FuncionEspacio(maxCharacters_15 - valor.Length) + "  " +
                                UseObject.FuncionEspacio(maxCharacters_15 - valor.Length) + valor);
                        }
                        else
                        {
                            ticket.AddHeaderLine(cuenta.Nombre);
                        }
                    }
                }*/
                /*foreach (DataRow row in items.Rows)
                {
                    ticket.AddItem("",
                                   row["Concepto"].ToString(),
                                   UseObject.InsertSeparatorMil(row["Valor"].ToString()));
                }*/

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
                ticket.AddHeaderLine("         SUBTOTAL :" + UseObject.StringBuilderDetalleTotal(
                        UseObject.InsertSeparatorMil(sTotal.ToString())));
                ticket.AddHeaderLine("      RETENCIONES :" + UseObject.StringBuilderDetalleTotal(
                    UseObject.InsertSeparatorMil(retencion.ToString())));
                ticket.AddHeaderLine("            TOTAL :" + UseObject.StringBuilderDetalleTotal(
                    UseObject.InsertSeparatorMil((sTotal + retencion).ToString())));
                ticket.AddHeaderLine("");
                /*ticket.AddTotal("SUBTOTAL     : ", UseObject.InsertSeparatorMil(sTotal.ToString()));
                ticket.AddTotal("RETENCIONES  : ", UseObject.InsertSeparatorMil(retencion.ToString()));
                ticket.AddTotal("TOTAL        : ", UseObject.InsertSeparatorMil((sTotal + retencion).ToString()));
                ticket.AddTotal("", "");
                ticket.AddTotal("", "");

                ticket.AddTotal("FORMAS DE PAGO", "");
                ticket.AddTotal("", "");*/
                var pEfectivo = egreso.Pagos.Where(d => d.IdFormaPago.Equals(1));
                var pCheque = egreso.Pagos.Where(d => d.IdFormaPago.Equals(2));
                var pTransaccion = egreso.Pagos.Where(d => d.IdFormaPago.Equals(4));
                if (pEfectivo.ToArray().Length != 0)
                {
                   // ticket.AddTotal("EFECTIVO  : ", UseObject.InsertSeparatorMil(pEfectivo.Sum(d => d.Valor).ToString()));
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
               // ticket.AddHeaderLine("Soluciones Tecnológicas A&C.");
                //ticket.AddHeaderLine("Cel. 3128068807");
                ticket.AddHeaderLine("");

                ticket.PrintTicket("");
                //ticket.PrintTicket("Microsoft XPS Document Writer");
            }
            catch (Exception ex)
            {
                OptionPane.MessageError("Ocurrió un error al imprimir el Egreso.\n" + ex.Message);
            }
        }

        void CompletaEventos_Completaz(CompletaArgumentosDeEventoz args)
        {
            try
            {
                txtNumero.Text = ((DTO.Clases.Cliente)args.MiZona).NitCliente;
                txtNumero.Focus();
            }
            catch { }

            try
            {
                if (this.TransPago)
                {
                    ObjectAbstract obj = (ObjectAbstract)args.MiZona;
                    if (obj.Id.Equals(233))  // Edicion de egreso.
                    {
                        if (this.BtnSearch)
                        {
                            this.btnBuscar_Click(this.btnBuscarFe, new EventArgs());
                        }
                        else
                        {
                            this.tsBtnListarTodos_Click(this.tsBtnListarTodos, new EventArgs());
                        }
                    }
                
                    if (obj.Id.Equals(235))  // Edicion de pago.
                    {
                        IngresarPagos((List<FormaPago>)obj.Objeto);
                        
                    }
                    this.TransPago = false;
                }

            }
            catch { }

            try 
            {
                this.TransPago = (bool)args.MiZona;
            }
            catch
            {
            }
        }

        void CompletaEventos_Completaeb(CompletaArgumentosDeEventoeb args)
        {
            try
            {
                Retenciones = (List<RetencionConcepto>)args.MiBodegaeb;
            }
            catch { }
        }

        private void IngresarPagos(List<FormaPago> pagos)
        {
            try
            {
                var miBussinesPago = new BussinesFormaPago();
                var idEgreso = Convert.ToInt32(this.dgvEgreso.CurrentRow.Cells["Id"].Value);
                miBussinesPago.EliminarEgresoPago(idEgreso);
                foreach (FormaPago pago in pagos)
                {
                    pago.Caja.Id = idEgreso;
                    miBussinesPago.IngresarEgresoPago(pago);
                }
                OptionPane.MessageInformation("Los pagos se cargarón con exito.");
                if (this.BtnSearch)
                {
                    this.btnBuscar_Click(this.btnBuscarFe, new EventArgs());
                }
                else
                {
                    this.tsBtnListarTodos_Click(this.tsBtnListarTodos, new EventArgs());
                }
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
        }

        private void Consulta()
        {
            try
            {
                switch (CriterioPrint)
                {
                    case 1:
                        {
                            TablaInforme = miBussinesEgreso.Egresos(this.IdCuentaEgreso, NumeroActual);
                            break;
                        }
                    case 2:
                        {
                            TablaInforme = miBussinesEgreso.Egresos(this.IdCuentaEgreso, FechaActual);
                            break;
                        }
                    case 3:
                        {
                            TablaInforme =
                                miBussinesEgreso.Egresos(this.IdCuentaEgreso, FechaActual, FechaActual1);
                            break;
                        }
                    case 4:
                        {
                            TablaInforme = miBussinesEgreso.Egresos(this.IdCuentaEgreso, IdBeneficioActual);
                            break;
                        }
                    case 5:
                        {
                            TablaInforme =
                                miBussinesEgreso.Egresos(this.IdCuentaEgreso, IdBeneficioActual, FechaActual);
                            break;
                        }
                    case 6:
                        {
                            TablaInforme = miBussinesEgreso.Egresos(
                                this.IdCuentaEgreso, IdBeneficioActual, FechaActual, FechaActual1);
                            break;
                        }
                }
                if (this.InvokeRequired)
                    this.Invoke(new Action(Finalizar));
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
                if (this.InvokeRequired)
                    this.Invoke(new Action(Finalizar));
            }
        }

        private void Finalizar()
        {
            try
            {
                miOption.FrmProgressBar.barraProgreso.Style = ProgressBarStyle.Blocks;
                miOption.FrmProgressBar.Closed_ = false;
                miOption.FrmProgressBar.Close();

                var miBussinesEmpresa = new BussinesEmpresa();
                var frmPrint = new FrmPrintInforme();

                frmPrint.rpvEgresos.LocalReport.DataSources.Clear();
                frmPrint.rpvEgresos.LocalReport.Dispose();
                frmPrint.rpvEgresos.Reset();

                frmPrint.rpvEgresos.LocalReport.DataSources.Add(
                    new ReportDataSource("DsEmpresa",
                        miBussinesEmpresa.PrintEmpresa().Tables[0]));
                frmPrint.rpvEgresos.LocalReport.DataSources.Add(
                    new ReportDataSource("DsEgresos", TablaInforme));
                frmPrint.rpvEgresos.LocalReport.ReportPath = AppConfiguracion.ValorSeccion("report") + @"\reports\InformeDeEgresos.rdlc";
                //@"\reports\InformeDeEgresos.rdlc";
                var pFecha = new ReportParameter();
                pFecha.Name = "Fecha";
                pFecha.Values.Add(FechaActual.ToShortDateString());
                frmPrint.rpvEgresos.LocalReport.SetParameters(pFecha);
                var pFecha2 = new ReportParameter();
                pFecha2.Name = "Fecha2";
                pFecha2.Values.Add(FechaActual1.ToShortDateString());
                frmPrint.rpvEgresos.LocalReport.SetParameters(pFecha2);
                frmPrint.rpvEgresos.RefreshReport();
                frmPrint.ShowDialog();
            }
            catch (Exception ex)
            {
                miOption.FrmProgressBar.barraProgreso.Style = ProgressBarStyle.Blocks;
                miOption.FrmProgressBar.Closed_ = false;
                miOption.FrmProgressBar.Close();

                OptionPane.MessageError(ex.Message);
            }
        }

        private void btnAnular_Click_1(object sender, EventArgs e)
        {

        }
    }
}