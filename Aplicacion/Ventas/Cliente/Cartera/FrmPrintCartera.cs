using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BussinesLayer.Clases;
using Utilities;
using CustomControl;
using Microsoft.Reporting.WinForms;

namespace Aplicacion.Ventas.Cliente.Cartera
{
    public partial class FrmPrintCartera : Form
    {
        public DateTime Fecha { set; get; }

        public string NitCliente { set; get; }

        public string Cliente { set; get; }

        private DataSet DsEmpresa;

        public DataTable DsCartera { set; get; }

        public DataTable DsTransaccion { set; get; }

        public int TotalCartera { set; get; }

        private BussinesEmpresa miBussinesEmpresa;

        public FrmPrintCartera()
        {
            InitializeComponent();
            miBussinesEmpresa = new BussinesEmpresa();
            DsEmpresa = new DataSet();
        }

        private void FrmCajaDiario_Load(object sender, EventArgs e)
        {
            this.rptCartera.RefreshReport();
            CargarDatos();
        }

        private void rptCartera_Print(object sender, ReportPrintEventArgs e)
        {
            Imprimir print = new Imprimir();
            print.Report = this.rptCartera.LocalReport;
            print.Print(Imprimir.TamanioPapel.Carta);
        }

        private void FrmCajaDiario_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.rptCartera.Reset();
        }

        public LocalReport CargarDatos()
        {
            try
            {
                this.rptCartera.LocalReport.DataSources.Clear();
                this.rptCartera.LocalReport.Dispose();
                this.rptCartera.Reset();

                DsEmpresa = miBussinesEmpresa.PrintEmpresa();

                this.rptCartera.LocalReport.DataSources.Add(
                    new ReportDataSource("DsEmpresa", DsEmpresa.Tables["Empresa"]));
                this.rptCartera.LocalReport.DataSources.Add(
                    new ReportDataSource("DsCartera", DsCartera));
                this.rptCartera.LocalReport.DataSources.Add(
                    new ReportDataSource("DsTransaccion", DsTransaccion));

                this.rptCartera.LocalReport.ReportPath = AppConfiguracion.ValorSeccion("report") + @"\reports\ResumenCartera.rdlc";

                var pFecha = new ReportParameter();
                pFecha.Name = "Fecha";
                pFecha.Values.Add(Fecha.ToShortDateString());
                this.rptCartera.LocalReport.SetParameters(pFecha);

                var pCliente = new ReportParameter();
                pCliente.Name = "Remite";
                pCliente.Values.Add(Cliente + " CC o NIT: " + NitCliente);
                this.rptCartera.LocalReport.SetParameters(pCliente);

                var pTotal = new ReportParameter();
                pTotal.Name = "TotalCartera";
                pTotal.Values.Add(TotalCartera.ToString());
                this.rptCartera.LocalReport.SetParameters(pTotal);

                //TotalCartera

                this.rptCartera.RefreshReport();

                return this.rptCartera.LocalReport;
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
                return null;
            }
        }

        public void ResetReport()
        {
            this.rptCartera.Reset();
        }
    }
}