using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using BussinesLayer.Clases;
using CustomControl;
using DTO.Clases;
using Utilities;

namespace Aplicacion.Ventas.Consultas
{
    public partial class FrmConsultaComprasContable : Form
    {
        private DateTime FechaActual;

        private DateTime FechaActual2;

        private Thread miThread;

        private OptionPane miOption;

        private DataSet dsEmpresa;

        private List<ConsultaFacturaProducto> Consultas;

        private List<ConsultaComprasCuentas> ConsCompras;

        //private BussinesEmpresa miBussinesEmpresa;

        private BussinesConsultaFacturaProducto miBussinesConsulta;

        public FrmConsultaComprasContable()
        {
            InitializeComponent();
            //miBussinesEmpresa = new BussinesEmpresa();
            miBussinesConsulta = new BussinesConsultaFacturaProducto();
        }

        private void FrmConsultaImpuestos_Load(object sender, EventArgs e)
        {
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                FechaActual = dtpFecha1.Value;
                FechaActual2 = dtpFecha2.Value;

                this.miOption = new OptionPane();
                this.miOption.FrmProgressBar.barraProgreso.Style = ProgressBarStyle.Marquee;
                this.miOption.FrmProgressBar.Closed_ = true;
                this.miOption.ProgressShow("Espere mientras se realizan las operaciones necesarias...",
                    "Operacion en progreso");
                this.Enabled = false;
                this.miThread = new Thread(Cargar);
                this.miThread.Start();
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
        }

        private void Cargar()
        {
            try
            {
                //dsEmpresa = miBussinesEmpresa.PrintEmpresa();
                //Consultas = miBussinesConsulta.Consulta(FechaActual, FechaActual2);
                ConsCompras = miBussinesConsulta.ConsultaCompras(FechaActual, FechaActual2);

                if (this.InvokeRequired)
                {
                    this.Invoke(new Action(Finalizar));
                }
            }
            catch (Exception ex)
            {
                if (this.InvokeRequired)
                {
                    this.Invoke(new Action(Finalizar));
                }
                OptionPane.MessageError(ex.Message);
            }
        }

        private void Finalizar()
        {
            try
            {
                miOption.FrmProgressBar.barraProgreso.Style = ProgressBarStyle.Blocks;
                miOption.FrmProgressBar.Closed_ = false;
                miOption.FrmProgressBar.Close();
                this.Enabled = true;

                if (ConsCompras.Count != 0)
                {
                    var frmPrintInforme = new FrmVerReporte();
                    frmPrintInforme.Text = "Informe de compras";
                    frmPrintInforme.rptVerInforme.LocalReport.DataSources.Clear();
                    frmPrintInforme.rptVerInforme.LocalReport.Dispose();
                    frmPrintInforme.rptVerInforme.Reset();

                    /*frmPrintInforme.rptVerInforme.LocalReport.DataSources.Add(
                        new Microsoft.Reporting.WinForms.ReportDataSource("DsEmpresa", dsEmpresa.Tables["Empresa"]));*/
                    frmPrintInforme.rptVerInforme.LocalReport.DataSources.Add(
                        new Microsoft.Reporting.WinForms.ReportDataSource("ComprasContable", ConsCompras));

                    frmPrintInforme.rptVerInforme.LocalReport.ReportPath = AppConfiguracion.ValorSeccion("report") + @"\reports\Informe_Contable_Compras.rdlc";
                    //frmPrintInforme.rptVerInforme.LocalReport.ReportPath = @"C:\reports\Informe_Contable_Compras.rdlc";

                    /*var pFecha = new Microsoft.Reporting.WinForms.ReportParameter();
                    pFecha.Name = "Fecha";
                    pFecha.Values.Add(FechaActual.ToShortDateString());
                    frmPrintInforme.rptVerInforme.LocalReport.SetParameters(pFecha);

                    var pFecha2 = new Microsoft.Reporting.WinForms.ReportParameter();
                    pFecha2.Name = "Fecha2";
                    pFecha2.Values.Add(FechaActual2.ToShortDateString());
                    frmPrintInforme.rptVerInforme.LocalReport.SetParameters(pFecha2);*/

                    frmPrintInforme.rptVerInforme.RefreshReport();
                    frmPrintInforme.Show();
                }
            }
            catch (Exception ex)
            {
                miOption.FrmProgressBar.barraProgreso.Style = ProgressBarStyle.Blocks;
                miOption.FrmProgressBar.Closed_ = false;
                miOption.FrmProgressBar.Close();
                this.Enabled = true;
                OptionPane.MessageError(ex.Message);
            }
        }
    }
}