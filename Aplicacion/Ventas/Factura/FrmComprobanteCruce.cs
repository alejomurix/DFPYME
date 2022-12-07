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

namespace Aplicacion.Ventas.Factura
{
    public partial class FrmComprobanteCruce : Form
    {
        public bool Venta { set; get; }

        public string Titulo { set; get; }

        public string Numero { set; get; }

        public DateTime Fecha { set; get; }

        public string Cliente { set; get; }

        public string Nit { set; get; }

        public string Direccion { set; get; }

        public string Valor { set; get; }

        public string Concepto { set; get; }

        public string Restante { set; get; }

        public int VRestante { set; get; }

        public string ReportPath { set; get; }

        private BussinesEmpresa miBussinesEmpresa;

        private DataSet DsEmpresa;

        public FrmComprobanteCruce()
        {
            InitializeComponent();
            this.Venta = true;
            this.Titulo = "Comprobante de Cruce No. ";
            this.ReportPath = AppConfiguracion.ValorSeccion("report") + @"\reports\ComprobanteCruce.rdlc";
            //this.ReportPath = @"C:\reports\ComprobanteCruce.rdlc";
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

                this.rpvAnticipo.LocalReport.ReportPath = this.ReportPath;

                Label NoComIngreso = new Label();
                NoComIngreso.AutoSize = true;
                NoComIngreso.Font = new System.Drawing.Font
                    ("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                NoComIngreso.Text = Numero;

                if (this.Venta)
                {
                    var pTitulo = new ReportParameter();
                    pTitulo.Name = "Titulo";
                    pTitulo.Values.Add(this.Titulo);
                    this.rpvAnticipo.LocalReport.SetParameters(pTitulo);
                }

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

                var pDir = new ReportParameter();
                pDir.Name = "Dir";
                pDir.Values.Add(Direccion);
                this.rpvAnticipo.LocalReport.SetParameters(pDir);

                var pValor = new ReportParameter();
                pValor.Name = "Valor";
                pValor.Values.Add(Valor);
                this.rpvAnticipo.LocalReport.SetParameters(pValor);

                var pNo = new ReportParameter();
                pNo.Name = "No";
                pNo.Values.Add(NoComIngreso.Text);
                this.rpvAnticipo.LocalReport.SetParameters(pNo);

                var pConcepto = new ReportParameter();
                pConcepto.Name = "Concepto";
                pConcepto.Values.Add(Concepto);
                this.rpvAnticipo.LocalReport.SetParameters(pConcepto);

                if (this.Venta)
                {
                    //restante
                    var pRestante = new ReportParameter();
                    pRestante.Name = "Restante";
                    pRestante.Values.Add(Restante);
                    this.rpvAnticipo.LocalReport.SetParameters(pRestante);
                }

                //valor restante
                var pVRestante = new ReportParameter();
                pVRestante.Name = "VRest";
                pVRestante.Values.Add(VRestante.ToString());
                this.rpvAnticipo.LocalReport.SetParameters(pVRestante);

                rpvAnticipo.RefreshReport();
                return this.rpvAnticipo.LocalReport;
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