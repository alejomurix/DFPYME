using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BussinesLayer.Clases;
using Microsoft.Reporting.WinForms;
using Utilities;

namespace Aplicacion.Compras.Egreso
{
    public partial class FrmPrintComprobante : Form
    {
        public string Numero { set; get; }

        public DateTime Fecha { set; get; }

        public string Remite { set; get; }

        //public int IdEgreso { set; get; }
        public DataTable Cuentas { set; get; }

        public string Cheque { set; get; }

        public string Efectivo { set; get; }

        public string Transaccion { set; get; }

        public string ReportPath { set; get; }

        private BussinesEmpresa miBussinesEmpresa;

        public DataTable DsFormas;

        public FrmPrintComprobante()
        {
            InitializeComponent();
            miBussinesEmpresa = new BussinesEmpresa();
            DsFormas = new DataTable();
            this.ReportPath = AppConfiguracion.ValorSeccion("report") + @"\reports\ComprobanteEgreso.rdlc";
            //this.ReportPath =  @"C:\reports\ComprobanteEgreso.rdlc";
        }

        private void FrmPrintComprobante_Load(object sender, EventArgs e)
        {
            CargarDatos();
            this.rpvEgreso.RefreshReport();
        }

        private void rpvEgreso_Print(object sender, ReportPrintEventArgs e)
        {
            Imprimir print = new Imprimir();
            print.Report = this.rpvEgreso.LocalReport;
            print.Print(Imprimir.TamanioPapel.MediaCarta);
        }

        private void FrmPrintComprobante_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.rpvEgreso.Reset();
        }

        public LocalReport CargarDatos()
        {
            try
            {
                var DsEmpresa = new DataSet();
                var DsCuentaPuc = new DataSet();

                DsEmpresa = miBussinesEmpresa.PrintEmpresa();
                DsCuentaPuc.Tables.Add(Cuentas);

                rpvEgreso.LocalReport.DataSources.Clear();
                rpvEgreso.LocalReport.Dispose();
                rpvEgreso.Reset();

                rpvEgreso.LocalReport.DataSources.Add(
                    new ReportDataSource("DsEmpresa", DsEmpresa.Tables["Empresa"]));
                rpvEgreso.LocalReport.DataSources.Add(
                    new ReportDataSource("DsCuentaPuc", DsCuentaPuc.Tables["CuentaPuc"]));

               /* rpvEgreso.LocalReport.DataSources.Add(
                    new ReportDataSource("DsFormas", DsFormas));*/

                //rpvEgreso.LocalReport.ReportPath = @"C:\reports\ComprobanteEgreso.rdlc";
                //rpvEgreso.LocalReport.ReportPath = Application.StartupPath + @"\reports\ComprobanteEgreso.rdlc";
                rpvEgreso.LocalReport.ReportPath = this.ReportPath; //AppConfiguracion.ValorSeccion("report") + @"\reports\ComprobanteEgreso.rdlc";

                Label NoComEgreso = new Label();
                NoComEgreso.AutoSize = true;
                NoComEgreso.Font = new System.Drawing.Font
                    ("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                NoComEgreso.Text = Numero;

                var pNumero = new ReportParameter();
                pNumero.Name = "No";
                pNumero.Values.Add(NoComEgreso.Text);
                rpvEgreso.LocalReport.SetParameters(pNumero);

                var pFecha = new ReportParameter();
                pFecha.Name = "Fecha";
                pFecha.Values.Add(Fecha.ToShortDateString());
                rpvEgreso.LocalReport.SetParameters(pFecha);

                var pRemite = new ReportParameter();
                pRemite.Name = "Remite";
                pRemite.Values.Add(Remite);
                rpvEgreso.LocalReport.SetParameters(pRemite);

                var pCheque = new ReportParameter();
                pCheque.Name = "Cheque";
                pCheque.Values.Add(Cheque);
                rpvEgreso.LocalReport.SetParameters(pCheque);

                var pEfectivo = new ReportParameter();
                pEfectivo.Name = "Efectivo";
                pEfectivo.Values.Add(Efectivo);
                rpvEgreso.LocalReport.SetParameters(pEfectivo);

                var pTransaccion = new ReportParameter();
                pTransaccion.Name = "Transaccion";
                pTransaccion.Values.Add(Transaccion);
                rpvEgreso.LocalReport.SetParameters(pTransaccion);

                rpvEgreso.RefreshReport();
                return rpvEgreso.LocalReport;
            }
            catch (Exception ex)
            {
                CustomControl.OptionPane.MessageError(ex.Message);
                return null;
            }
        }

        public void ResetReport()
        {
            this.rpvEgreso.Reset();
        }
    }
}