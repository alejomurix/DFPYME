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

namespace Aplicacion.Inventario.Cruce
{
    public partial class FrmInformeInventario : Form
    {
        public DataTable Tabla { set; get; }

        public string ReportPath { set; get; }

        public DateTime Fecha { set; get; }

        public string NoCaja { set; get; }

        private BussinesEmpresa miBussinesEmpresa;

        private BussinesInventario miBussinesInventario;

        public FrmInformeInventario()
        {
            NoCaja = "";
            InitializeComponent();
            miBussinesEmpresa = new BussinesEmpresa();
            miBussinesInventario = new BussinesInventario();
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
                    new Microsoft.Reporting.WinForms.ReportDataSource("DsInventario", Tabla));
                /*this.RptViewInforme.LocalReport.DataSources.Add(
                    new Microsoft.Reporting.WinForms.ReportDataSource("DsInventario", miBussinesInventario.InformeInventario()));*/

                this.RptViewInforme.LocalReport.ReportPath = this.ReportPath;
                //this.RptViewInforme.LocalReport.ReportPath = AppConfiguracion.ValorSeccion("report") + @"\reports\InformeInventario.rdlc";
            //    @"D:\Proyectos\SistemaFacturacion\SVN-SIF-I\Test-Setup-1\BackUp-3\Edit-Home\SistemaFactura\Aplicacion\Informes\Inventario\InformeInventario.rdlc";

                var pFecha = new ReportParameter();
                pFecha.Name = "Fecha";
                pFecha.Values.Add(Fecha.ToLongDateString());
                this.RptViewInforme.LocalReport.SetParameters(pFecha);

                if (NoCaja != "")
                {
                    var pCaja = new ReportParameter();
                    pCaja.Name = "Caja";
                    pCaja.Values.Add(NoCaja);
                    this.RptViewInforme.LocalReport.SetParameters(pCaja);
                }

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