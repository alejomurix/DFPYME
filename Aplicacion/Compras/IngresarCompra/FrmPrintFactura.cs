using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;
using Utilities;

namespace Aplicacion.Compras.IngresarCompra
{
    public partial class FrmPrintFactura : Form
    {
        public int Tipo { set; get; }

        public string numero { set; get; }

        public string Pago { set; get; }

        public DateTime Fecha { set; get; }

        public DateTime Limite { set; get; }

        public string Proveedor { set; get; }

        public string Nit { set; get; }

        public string Telefono { set; get; }

        public string Direccion { set; get; }

        public DataTable DsDetalle { set; get; }

        public int Retencion { set; get; }

        public string ReportPath { set; get; }

        public FrmPrintFactura()
        {
            InitializeComponent();
            try
            {
                this.Retencion = 0;
                this.DsDetalle = new DataTable();
                this.DsDetalle.TableName = "Detalle";
                this.ReportPath = AppConfiguracion.ValorSeccion("report") + @"\reports\DocumentoEquivalente.rdlc";
                //this.ReportPath = @"c:\reports\DocumentoEquivalente.rdlc";
            }
            catch (Exception ex)
            {
                CustomControl.OptionPane.MessageError(ex.Message);
            }
        }

        private void FrmPrintFactura_Load(object sender, EventArgs e)
        {
            this.RptvFactura.RefreshReport();
            CargarDatos();
        }

        private void RptvFactura_Print(object sender, ReportPrintEventArgs e)
        {
            Imprimir print = new Imprimir();
            print.Report = this.RptvFactura.LocalReport;
            print.Print(Imprimir.TamanioPapel.MediaCarta);
            e.Cancel = true;
        }

        private void FrmPrintFactura_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.RptvFactura.Reset();
        }

        public LocalReport CargarDatos()
        {
            var dsEmpresa = new DataSet();
            try
            {
                var miBussinesEmpresa = new BussinesLayer.Clases.BussinesEmpresa();

                dsEmpresa = miBussinesEmpresa.PrintEmpresa();

                this.RptvFactura.LocalReport.DataSources.Clear();
                this.RptvFactura.LocalReport.Dispose();
                this.RptvFactura.Reset();

                this.RptvFactura.LocalReport.DataSources.Add(
                    new ReportDataSource("DsEmpresa", dsEmpresa.Tables["Empresa"]));
                this.RptvFactura.LocalReport.DataSources.Add(
                   new ReportDataSource("DsDetalle", DsDetalle));

                //this.RptvFactura.LocalReport.ReportPath = @"C:\reports\DocumentoEquivalente.rdlc";
                this.RptvFactura.LocalReport.ReportPath = this.ReportPath; //AppConfiguracion.ValorSeccion("report") + @"\reports\DocumentoEquivalente.rdlc";

                Label NoFactura = new Label();
                NoFactura.AutoSize = true;
                NoFactura.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                switch (Tipo)
                {
                    case 1:
                        {
                            NoFactura.Text = "Factura de Compra No. " + numero;
                            break;
                        }
                    case 2:
                        {
                            NoFactura.Text = "Remisión de Compra No. " + numero;
                            break;
                        }
                    case 3:
                        {

                            NoFactura.Text = "Documento Equivalente No. " + numero;
                            break;
                        }
                }

                var Fact = new ReportParameter();
                Fact.Name = "Fact";
                Fact.Values.Add(NoFactura.Text);
                this.RptvFactura.LocalReport.SetParameters(Fact);

                var pPago = new ReportParameter();
                pPago.Name = "pago";
                pPago.Values.Add(Pago);
                this.RptvFactura.LocalReport.SetParameters(pPago);

                var pFecha = new ReportParameter();
                pFecha.Name = "Fecha";
                pFecha.Values.Add(Fecha.ToShortDateString());
                this.RptvFactura.LocalReport.SetParameters(pFecha);

                var pLimite = new ReportParameter();
                pLimite.Name = "Limite";
                pLimite.Values.Add(Limite.ToShortDateString());
                this.RptvFactura.LocalReport.SetParameters(pLimite);

                var pProveedor = new ReportParameter();
                pProveedor.Name = "Proveedor";
                pProveedor.Values.Add(Proveedor);
                this.RptvFactura.LocalReport.SetParameters(pProveedor);

                var pNit = new ReportParameter();
                pNit.Name = "Nit";
                pNit.Values.Add(Nit);
                this.RptvFactura.LocalReport.SetParameters(pNit);

                var pTelefono = new ReportParameter();
                pTelefono.Name = "Telefono";
                pTelefono.Values.Add(Telefono);
                this.RptvFactura.LocalReport.SetParameters(pTelefono);

                var pDireccion = new ReportParameter();
                pDireccion.Name = "Direccion";
                pDireccion.Values.Add(Direccion);
                this.RptvFactura.LocalReport.SetParameters(pDireccion);

                var pRetencion = new ReportParameter();
                pRetencion.Name = "Retencion";
                pRetencion.Values.Add(Retencion.ToString());
                this.RptvFactura.LocalReport.SetParameters(pRetencion);

                this.RptvFactura.RefreshReport();
                return this.RptvFactura.LocalReport;
            }
            catch (Exception ex)
            {
                CustomControl.OptionPane.MessageError(ex.Message);
                return null;
            }
        }

        public void ResetRepor()
        {
            this.RptvFactura.Reset();
        }
    }
}