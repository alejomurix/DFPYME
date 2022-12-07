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
using Microsoft.Reporting.WinForms;

namespace Aplicacion.Ventas.Ingresos
{
    public partial class FrmPrintIngreso : Form
    {
        public DateTime Fecha { set; get; }

        public string Cliente { set; get; }

        public string Nit { set; get; }

        public string Valor { set; get; }

        public string Numero { set; get; }

        public DataTable DsConcepto { set; get; }

        public string Efectivo { set; get; }

        public string Cheque { set; get; }

        public string Transaccion { set; get; }

        public string ReportPath { set; get; }

        private BussinesEmpresa miBussinesEmpresa;

        private DataSet DsEmpresa;

        public FrmPrintIngreso()
        {
            InitializeComponent();
            this.Efectivo = "0";
            this.Cheque = "0";
            this.Transaccion = "0";
            this.ReportPath = AppConfiguracion.ValorSeccion("report") + @"\reports\ReciboCaja.rdlc";
            miBussinesEmpresa = new BussinesEmpresa();
            DsEmpresa = new DataSet();
        }

        private void FrmPrintAnticipo_Load(object sender, EventArgs e)
        {
            this.rpvAnticipo.RefreshReport();
            CargarDatos();
        }

        private void rpvAnticipo_Print(object sender, ReportPrintEventArgs e)
        {
            Imprimir print = new Imprimir();
            print.Report = this.rpvAnticipo.LocalReport;
            print.Print(Imprimir.TamanioPapel.MediaCarta);
        }

        private void FrmPrintAnticipo_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.rpvAnticipo.Reset();
        }

        public LocalReport CargarDatos()
        {
            try
            {
                DsEmpresa = miBussinesEmpresa.PrintEmpresa();

                rpvAnticipo.LocalReport.DataSources.Clear();
                rpvAnticipo.LocalReport.Dispose();
                rpvAnticipo.Reset();

                this.rpvAnticipo.LocalReport.DataSources.Add(
                    new ReportDataSource("DsEmpresa", DsEmpresa.Tables["Empresa"]));
                this.rpvAnticipo.LocalReport.DataSources.Add(
                    new ReportDataSource("DsCuentaPuc", DsConcepto));

                rpvAnticipo.LocalReport.ReportPath = this.ReportPath;

                Label NoComIngreso = new Label();
                NoComIngreso.AutoSize = true;
                NoComIngreso.Font = new System.Drawing.Font
                    ("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                NoComIngreso.Text = Numero;

                var pRecibo = new ReportParameter();
                pRecibo.Name = "Recibo";
                pRecibo.Values.Add("Recibo de Caja No. ");
                this.rpvAnticipo.LocalReport.SetParameters(pRecibo);

                var pNo = new ReportParameter();
                pNo.Name = "No";
                pNo.Values.Add(NoComIngreso.Text);
                this.rpvAnticipo.LocalReport.SetParameters(pNo);

                var pFecha = new ReportParameter();
                pFecha.Name = "Fecha";
                pFecha.Values.Add(Fecha.ToShortDateString());
                this.rpvAnticipo.LocalReport.SetParameters(pFecha);

                var pCliente = new ReportParameter();
                pCliente.Name = "Cliente";
                pCliente.Values.Add(Cliente);
                this.rpvAnticipo.LocalReport.SetParameters(pCliente);

                var pNit = new ReportParameter();
                pNit.Name = "Nit";
                pNit.Values.Add(Nit);
                this.rpvAnticipo.LocalReport.SetParameters(pNit);

                var pValor = new ReportParameter();
                pValor.Name = "Valor";
                pValor.Values.Add(Valor);
                this.rpvAnticipo.LocalReport.SetParameters(pValor);

                var pEfectivo = new ReportParameter();
                pEfectivo.Name = "Efectivo";
                pEfectivo.Values.Add(this.Efectivo);
                this.rpvAnticipo.LocalReport.SetParameters(pEfectivo);

                var pCheque = new ReportParameter();
                pCheque.Name = "Cheque";
                pCheque.Values.Add(this.Cheque);
                this.rpvAnticipo.LocalReport.SetParameters(pCheque);

                var pTransaccion = new ReportParameter();
                pTransaccion.Name = "Transaccion";
                pTransaccion.Values.Add(this.Transaccion);
                this.rpvAnticipo.LocalReport.SetParameters(pTransaccion);

                rpvAnticipo.RefreshReport();
                return rpvAnticipo.LocalReport;
            }
            catch (Exception ex)
            {
                CustomControl.OptionPane.MessageError(ex.Message);
                return null;
            }
        }

        public void ResetReport()
        {
            this.rpvAnticipo.Reset();
        }
    }
}