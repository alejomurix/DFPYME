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

namespace Aplicacion.Inventario.Kardex
{
    public partial class FrmPrint : Form
    {
        public DataTable Tabla { set; get; }

        public string ReportPath { set; get; }

        public string Criterio { set; get; }

        public string Codigo { set; get; }

        public string Barras { set; get; }

        public string Nombre { set; get; }

        public string Total { set; get; }

        public string VTotal { set; get; }

        private BussinesEmpresa miBussinesEmpresa;

        public FrmPrint()
        {
            InitializeComponent();
            this.Total = " ";
            this.VTotal = " ";
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
                    new Microsoft.Reporting.WinForms.ReportDataSource("DsKardex", Tabla));

                this.RptViewInforme.LocalReport.ReportPath = this.ReportPath;

                var pCriterio = new ReportParameter();
                pCriterio.Name = "Criterio";
                pCriterio.Values.Add(Criterio);
                this.RptViewInforme.LocalReport.SetParameters(pCriterio);

                var pCodigo = new ReportParameter();
                pCodigo.Name = "Codigo";
                pCodigo.Values.Add(Codigo);
                this.RptViewInforme.LocalReport.SetParameters(pCodigo);

                var pBarras = new ReportParameter();
                pBarras.Name = "Barras";
                pBarras.Values.Add(Barras);
                this.RptViewInforme.LocalReport.SetParameters(pBarras);

                var pNombre = new ReportParameter();
                pNombre.Name = "NombreProducto";
                pNombre.Values.Add(Nombre);
                this.RptViewInforme.LocalReport.SetParameters(pNombre);

                var pTotal = new ReportParameter();
                pTotal.Name = "Total";
                pTotal.Values.Add(Total);
                this.RptViewInforme.LocalReport.SetParameters(pTotal);

                var pVTotal = new ReportParameter();
                pVTotal.Name = "VTotal";
                pVTotal.Values.Add(VTotal);
                this.RptViewInforme.LocalReport.SetParameters(pVTotal);

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