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

namespace Aplicacion.Compras.Devolucion
{
    public partial class FrmPrintDevolucion : Form
    {
        /*public string numero { set; get; }

        public string Pago { set; get; }

        public DateTime fecha { set; get; }

        public string Proveedor { set; get; }

        public string Nit { set; get; }

        public string Telefono { set; get; }

        public string Direccion { set; get; }

        public DataTable DsDetalle { set; get; }*/

        public FrmPrintDevolucion()
        {
            InitializeComponent();
           /* this.DsDetalle = new DataTable();
            this.DsDetalle.TableName = "Detalle";*/
        }

        private void FrmPrintFactura_Load(object sender, EventArgs e)
        {
            this.RptvFactura.RefreshReport();
            //CargarDatos();
        }

        private void RptvFactura_Print(object sender, ReportPrintEventArgs e)
        {
            Imprimir print = new Imprimir();
            print.Report = this.RptvFactura.LocalReport;
            print.Print(Imprimir.TamanioPapel.MediaCarta);
        }

        private void FrmPrintFactura_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.RptvFactura.Reset();
        }

        /*private void CargarDatos()
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
                this.RptvFactura.LocalReport.ReportPath = AppConfiguracion.ValorSeccion("report") + @"\reports\DocumentoEquivalente.rdlc";

                Label NoFactura = new Label();
                NoFactura.AutoSize = true;
                NoFactura.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                NoFactura.Text = "Documento Equivalente No. " + numero;

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
                pFecha.Values.Add(fecha.ToShortDateString());
                this.RptvFactura.LocalReport.SetParameters(pFecha);

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

                this.RptvFactura.RefreshReport();
            }
            catch (Exception ex)
            {
                CustomControl.OptionPane.MessageError(ex.Message);
            }
        }*/
    }
}