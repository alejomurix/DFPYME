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
using Microsoft.Reporting.WinForms;
using Utilities;

namespace Aplicacion.Inventario.Producto
{
    public partial class FrmInformeProducto : Form
    {
        public DataTable Tabla { set; get; }

        public string ReportPath { set; get; }

        public string AddIva { set; get; }

        public string Total { set; get; }

        private BussinesEmpresa miBussinesEmpresa;

        public FrmInformeProducto()
        {
            InitializeComponent();
            miBussinesEmpresa = new BussinesEmpresa();
        }

        private void FrmInformeInventario_Load(object sender, EventArgs e)
        {
            try
            {
                this.RptViewInforme.LocalReport.DataSources.Clear();
                this.RptViewInforme.LocalReport.Dispose();
                this.RptViewInforme.Reset();

                this.RptViewInforme.LocalReport.DataSources.Add(
                    new Microsoft.Reporting.WinForms.ReportDataSource("DsEmpresa", miBussinesEmpresa.PrintEmpresa().Tables[0]));
                this.RptViewInforme.LocalReport.DataSources.Add(
                    new Microsoft.Reporting.WinForms.ReportDataSource("DsProducto", Tabla));

                this.RptViewInforme.LocalReport.ReportPath = this.ReportPath;

                var PAddIva = new ReportParameter();
                PAddIva.Name = "AddIva";
                PAddIva.Values.Add(AddIva);
                this.RptViewInforme.LocalReport.SetParameters(PAddIva);

                var pTotal = new ReportParameter();
                pTotal.Name = "Total";
                pTotal.Values.Add(Total);
                this.RptViewInforme.LocalReport.SetParameters(pTotal);

                this.RptViewInforme.RefreshReport();
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
        }

        private void FrmInformeInventario_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.RptViewInforme.Reset();
        }
    }
}