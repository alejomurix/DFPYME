using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CustomControl;
using BussinesLayer.Clases;
using Microsoft.Reporting.WinForms;
using Utilities;

namespace Aplicacion.Ventas.Cartera
{
    public partial class FrmPrintCartera : Form
    {
        public DataTable Tabla { set; get; }

        public DataTable TIva { set; get; }

        public string ReportPath { set; get; }

        public DateTime Fecha { set; get; }

        public DateTime Fecha2 { set; get; }

        public string Reporte { set; get; }

        public int SubTotal { set; get; }

        public int Iva { set; get; }

        public int Total { set; get; }

        public bool Compra { set; get; }

        public bool ConsultaCompra { set; get; }

        public Imprimir.TamanioPapel Tamanio;

        private BussinesEmpresa miBussinesEmpresa;

        public FrmPrintCartera()
        {
            InitializeComponent();
            miBussinesEmpresa = new BussinesEmpresa();
            this.Fecha = DateTime.Now;
            this.Compra = false;
            this.ConsultaCompra = false;
        }

        private void FrmPrintFactura_Load(object sender, EventArgs e)
        {
            try
            {
                this.RptvCartera.LocalReport.DataSources.Clear();
                this.RptvCartera.LocalReport.Dispose();
                this.RptvCartera.Reset();

                this.RptvCartera.LocalReport.DataSources.Add(
                    new Microsoft.Reporting.WinForms.ReportDataSource("DsEmpresa", miBussinesEmpresa.PrintEmpresa().Tables[0]));
                this.RptvCartera.LocalReport.DataSources.Add(
                                    new Microsoft.Reporting.WinForms.ReportDataSource("DsCartera", Tabla));
                if (this.ConsultaCompra)
                {
                    this.RptvCartera.LocalReport.DataSources.Add(
                        new Microsoft.Reporting.WinForms.ReportDataSource("DsIvaGravado", this.TIva));
                }

                this.RptvCartera.LocalReport.ReportPath = this.ReportPath;

                var pFecha = new ReportParameter();
                pFecha.Name = "Fecha";
                if (Compra)
                {
                    pFecha.Values.Add(Fecha.ToShortDateString());
                }
                else
                {
                    pFecha.Values.Add(Fecha.ToLongDateString());
                }

                this.RptvCartera.LocalReport.SetParameters(pFecha);

                var pReport = new ReportParameter();
                pReport.Name = "Informe";
                pReport.Values.Add(Reporte);

                this.RptvCartera.LocalReport.SetParameters(pReport);

                if (Compra)
                {
                    var pFecha2 = new ReportParameter();
                    pFecha2.Name = "Fecha2";
                    pFecha2.Values.Add(Fecha2.ToShortDateString());
                    this.RptvCartera.LocalReport.SetParameters(pFecha2);

                    var pSubTotal = new ReportParameter();
                    pSubTotal.Name = "SubTotal";
                    pSubTotal.Values.Add(SubTotal.ToString());
                    this.RptvCartera.LocalReport.SetParameters(pSubTotal);

                    var pIva = new ReportParameter();
                    pIva.Name = "Iva";
                    pIva.Values.Add(Iva.ToString());
                    this.RptvCartera.LocalReport.SetParameters(pIva);

                    var pTotal = new ReportParameter();
                    pTotal.Name = "Total";
                    pTotal.Values.Add(Total.ToString());
                    this.RptvCartera.LocalReport.SetParameters(pTotal);
                }

                this.RptvCartera.RefreshReport();
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
        }

        private void RptvCartera_Print(object sender, ReportPrintEventArgs e)
        {
            Imprimir print = new Imprimir();
            print.Report = this.RptvCartera.LocalReport;
            print.Print(Tamanio);
            e.Cancel = true;
        }

        private void FrmPrintFactura_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.RptvCartera.Reset();
        }

        public void PrintPos(bool resumen)
        {
            try
            {
                var empresaRow = miBussinesEmpresa.PrintEmpresa().Tables[0].AsEnumerable().First();

                Ticket ticket = new Ticket();
                ticket.UseItem = false;

                ticket.AddHeaderLine(empresaRow["Nombre"].ToString().ToUpper());
                ticket.AddHeaderLine(empresaRow["Juridico"].ToString());
                ticket.AddHeaderLine("NIT " + UseObject.InsertSeparatorMilMasDigito(empresaRow["Nit"].ToString()));
                ticket.AddHeaderLine(empresaRow["Direccion"].ToString());
                ticket.AddHeaderLine("Fecha : " + Fecha.ToShortDateString());
                ticket.AddHeaderLine("===================================");
                ticket.AddHeaderLine(Reporte);
                ticket.AddHeaderLine("===================================");
                ticket.AddHeaderLine("");
                ticket.AddHeaderLine("");
                foreach (DataRow row in Tabla.Rows)
                {
                    ticket.AddHeaderLine("Cedula  : " + row["Cedula"].ToString());
                    ticket.AddHeaderLine("Nombre  : " + row["Nombre"].ToString());
                    if (!resumen)
                    {
                        ticket.AddHeaderLine("FRV No. : " + row["Factura"].ToString());
                    }
                    ticket.AddHeaderLine("Saldo   : " + UseObject.InsertSeparatorMilMasDigito(row["Saldo"].ToString()));
                    ticket.AddHeaderLine("");
                }
                ticket.AddHeaderLine("");
                ticket.AddHeaderLine("");
                var total = UseObject.InsertSeparatorMilMasDigito(Tabla.AsEnumerable().Sum(s => s.Field<int>("Saldo")).ToString());
                ticket.AddHeaderLine("TOTAL CARTERA : $" +
                    UseObject.InsertSeparatorMilMasDigito(Tabla.AsEnumerable().Sum(s => s.Field<int>("Saldo")).ToString()));
                ticket.AddHeaderLine("");
                ticket.AddHeaderLine("");
                ticket.AddFooterLine("-----------------------------------");
                ticket.AddFooterLine("Software: Digital Fact Pyme");
                ticket.AddFooterLine("Soluciones Tecnológicas A&C.");
                ticket.AddFooterLine("Cel. 3128068807");
                ticket.AddFooterLine(".");

                ticket.PrintTicket("IMPREPOS");
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
        }

        public LocalReport Load_()
        {
            try
            {
                this.RptvCartera.LocalReport.DataSources.Clear();
                this.RptvCartera.LocalReport.Dispose();
                this.RptvCartera.Reset();

                this.RptvCartera.LocalReport.DataSources.Add(
                    new Microsoft.Reporting.WinForms.ReportDataSource("DsEmpresa", miBussinesEmpresa.PrintEmpresa().Tables[0]));
                this.RptvCartera.LocalReport.DataSources.Add(
                                    new Microsoft.Reporting.WinForms.ReportDataSource("DsCartera", Tabla));
                this.RptvCartera.LocalReport.ReportPath = this.ReportPath;

                var pFecha = new ReportParameter();
                pFecha.Name = "Fecha";
                if (Compra)
                {
                    pFecha.Values.Add(Fecha.ToShortDateString());
                }
                else
                {
                    pFecha.Values.Add(Fecha.ToLongDateString());
                }

                this.RptvCartera.LocalReport.SetParameters(pFecha);

                var pReport = new ReportParameter();
                pReport.Name = "Informe";
                pReport.Values.Add(Reporte);

                this.RptvCartera.LocalReport.SetParameters(pReport);

                if (Compra)
                {
                    var pFecha2 = new ReportParameter();
                    pFecha2.Name = "Fecha2";
                    pFecha2.Values.Add(Fecha2.ToShortDateString());
                    this.RptvCartera.LocalReport.SetParameters(pFecha2);

                    var pSubTotal = new ReportParameter();
                    pSubTotal.Name = "SubTotal";
                    pSubTotal.Values.Add(SubTotal.ToString());
                    this.RptvCartera.LocalReport.SetParameters(pSubTotal);

                    var pIva = new ReportParameter();
                    pIva.Name = "Iva";
                    pIva.Values.Add(Iva.ToString());
                    this.RptvCartera.LocalReport.SetParameters(pIva);

                    var pTotal = new ReportParameter();
                    pTotal.Name = "Total";
                    pTotal.Values.Add(Total.ToString());
                    this.RptvCartera.LocalReport.SetParameters(pTotal);
                }

                this.RptvCartera.RefreshReport();
                return this.RptvCartera.LocalReport;
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
                return null;
            }
        }

        public void ResetReport()
        {
            this.RptvCartera.Reset();
        }
    }
}