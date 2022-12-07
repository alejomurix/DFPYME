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

namespace Aplicacion.Tesoreria.CuentasPorCobrar
{
    public partial class FrmConsultaCuentaCobrar : Form
    {
        private int IdCuentaAnticipo;

        private int IdCuentaPrestamo;

        private BussinesEmpresa miBussinesEmpresa;

        private BussinesFacturaVenta miBussinesFactura;

        private BussinesAnticipo miBussinesAnticipo;

        public FrmConsultaCuentaCobrar()
        {
            InitializeComponent();
            miBussinesEmpresa = new BussinesEmpresa();
            miBussinesFactura = new BussinesFacturaVenta();
            miBussinesAnticipo = new BussinesAnticipo();

            try
            {
                this.IdCuentaAnticipo = Convert.ToInt32(AppConfiguracion.ValorSeccion("ctaAnticipo"));
                this.IdCuentaPrestamo = Convert.ToInt32(AppConfiguracion.ValorSeccion("ctaPrestamo"));
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
        }

        private void FrmConsultaCuentaCobrar_Load(object sender, EventArgs e)
        {

        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            try
            {
                var frmPrint = new Compras.Egreso.FrmPrintInforme();

                frmPrint.rpvEgresos.LocalReport.DataSources.Clear();
                frmPrint.rpvEgresos.LocalReport.Dispose();
                frmPrint.rpvEgresos.Reset();

                frmPrint.rpvEgresos.LocalReport.DataSources.Add(
                new ReportDataSource("DsEmpresa",
                    miBussinesEmpresa.PrintEmpresa().Tables[0]));

                frmPrint.rpvEgresos.LocalReport.DataSources.Add(
                new ReportDataSource("DsCartera",
                    miBussinesFactura.CarteraClientes(this.dtFecha.Value, this.dtFecha2.Value)));

                /*var tabla = miBussinesAnticipo.AnticiposATercero(IdCuentaAnticipo, this.dtFecha.Value, this.dtFecha2.Value, false);
                var tabla1 = miBussinesAnticipo.AnticiposATercero(IdCuentaPrestamo, this.dtFecha.Value, this.dtFecha2.Value, false);*/

                //DsPrestamoAnticipo
                frmPrint.rpvEgresos.LocalReport.DataSources.Add(
                new ReportDataSource("DsPrestamoAnticipo",
                    miBussinesAnticipo.AnticiposATercero(IdCuentaAnticipo, this.dtFecha.Value, this.dtFecha2.Value, false)));

                frmPrint.rpvEgresos.LocalReport.DataSources.Add(
                new ReportDataSource("DsPrestamoAnticipo_",
                    miBussinesAnticipo.AnticiposATercero(IdCuentaPrestamo, this.dtFecha.Value, this.dtFecha2.Value, false)));

              /*  frmPrint.rpvEgresos.LocalReport.DataSources.Add(
                new ReportDataSource("DsPrestamoAnticipo", tabla));

                frmPrint.rpvEgresos.LocalReport.DataSources.Add(
                new ReportDataSource("DsPrestamoAnticipo_", tabla1));*/

                frmPrint.rpvEgresos.LocalReport.ReportPath = AppConfiguracion.ValorSeccion("report") + @"\reports\InformeDeCuentasPorCobrar.rdlc";

                frmPrint.rpvEgresos.RefreshReport();
                frmPrint.ShowDialog();

                /*var miBussinesEmpresa = new BussinesEmpresa();
                var frmPrint = new Egreso.FrmPrintInforme();

                frmPrint.rpvEgresos.LocalReport.DataSources.Clear();
                frmPrint.rpvEgresos.LocalReport.Dispose();
                frmPrint.rpvEgresos.Reset();

                frmPrint.rpvEgresos.LocalReport.DataSources.Add(
                new ReportDataSource("DsEmpresa",
                    miBussinesEmpresa.PrintEmpresa().Tables[0]));
                frmPrint.rpvEgresos.LocalReport.DataSources.Add(
                new ReportDataSource("DsPrestamoAnticipo",
                   miBussinesAnticipo.AnticiposATercero()));
                frmPrint.rpvEgresos.LocalReport.ReportPath = AppConfiguracion.ValorSeccion("report") + @"\reports\InformeDePrestamosAnticipos.rdlc";

                var pFecha = new ReportParameter();
                pFecha.Name = "Fecha";
                pFecha.Values.Add(DateTime.Now.ToShortDateString());
                frmPrint.rpvEgresos.LocalReport.SetParameters(pFecha);

                frmPrint.rpvEgresos.RefreshReport();
                frmPrint.ShowDialog();*/
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
        }
    }
}