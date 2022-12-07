using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Aplicacion.Ventas.Factura
{
    public partial class FrmMuestra : Form
    {
        public FrmMuestra()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
           /* var frm = new FrmDinamicCancelar();
            frm.ShowDialog();*/
        }
        /*
        private void Print(string numero, bool descto, string cliente, bool contado, int idEstado)
        {
            var miBussinesRetencion = new BussinesRetencion();
            var dsDetalle = new DataSet();
            var dsEmpresa = new DataSet();
            var dsFactura = new DataSet();
            var dsUsuario = new DataSet();
            var dsCliente = new DataSet();
            var dsDian = new DataSet();
            try
            {
                dsDetalle = miBussinesFactura.PrintProducto(numero, descto);
                dsEmpresa = miBussinesEmpresa.PrintEmpresa();
                dsFactura = miBussinesFactura.PrintFacturaVenta(numero);
                dsUsuario = miBussinesUsuario.PrintUsuario(numero);
                dsCliente = miBussinesCliente.PrintCliente(cliente);
                if (contado)
                {
                    dsDian = miBussinesDian.Print(true);
                }
                else
                {
                    dsDian = miBussinesDian.Print(false);
                }

                var frmPrint = new FrmPrintFactura();
                //frmPrint.MdiParent = this.MdiParent;

                frmPrint.RptvFactura.LocalReport.DataSources.Clear();
                frmPrint.RptvFactura.LocalReport.Dispose();
                frmPrint.RptvFactura.Reset();

                frmPrint.RptvFactura.LocalReport.DataSources.Add(
                    new ReportDataSource("DsDian", dsDian.Tables["TDian"]));
                frmPrint.RptvFactura.LocalReport.DataSources.Add(
                   new ReportDataSource("DsDetalle", dsDetalle.Tables["Detalle"]));
                frmPrint.RptvFactura.LocalReport.DataSources.Add(
                    new ReportDataSource("DsEmpresa", dsEmpresa.Tables["Empresa"]));
                frmPrint.RptvFactura.LocalReport.DataSources.Add(
                    new ReportDataSource("DsFacturaVenta", dsFactura.Tables["FacturaVenta"]));
                frmPrint.RptvFactura.LocalReport.DataSources.Add(
                    new ReportDataSource("DsUsuario", dsUsuario.Tables["Usuario"]));
                frmPrint.RptvFactura.LocalReport.DataSources.Add(
                    new ReportDataSource("DsCliente", dsCliente.Tables["Cliente"]));

                //frmPrint.RptvFactura.LocalReport.ReportPath = @"..\..\Ventas\Reportes\RptFacturaVenta.rdlc";
                //frmPrint.RptvFactura.LocalReport.ReportPath = @"C:\reports\RptFacturaVenta.rdlc";
                frmPrint.RptvFactura.LocalReport.ReportPath = AppConfiguracion.ValorSeccion("report") + @"\reports\RptFacturaVenta.rdlc";

                Label NoFactura = new Label();
                NoFactura.AutoSize = true;
                NoFactura.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                NoFactura.Text = numero;

                var Fact = new ReportParameter();
                Fact.Name = "Fact";
                if (idEstado == 1 || IdEstado == 2)
                {
                    Fact.Values.Add("FACTURA DE VENTA No.  " + NoFactura.Text);
                }
                else
                {
                    if (IdEstado == 4)
                    {
                        Fact.Values.Add("COTIZACIÓN");
                    }
                }
                frmPrint.RptvFactura.LocalReport.SetParameters(Fact);

                var pago = new ReportParameter();
                pago.Name = "pago";
                if (idEstado == 1)
                {
                    pago.Values.Add("Contado");
                }
                else
                {
                    if (idEstado == 2)
                    {
                        pago.Values.Add("Crédito");
                    }
                }
                frmPrint.RptvFactura.LocalReport.SetParameters(pago);

                var totalRete = miBussinesRetencion.ValorRetencionAventa(numero, descto);
                var tReteParam = new ReportParameter();
                tReteParam.Name = "Retencion";
                tReteParam.Values.Add(totalRete.ToString());
                frmPrint.RptvFactura.LocalReport.SetParameters(tReteParam);


                frmPrint.RptvFactura.RefreshReport();
                frmPrint.ShowDialog();
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
        }
        */
    }


}