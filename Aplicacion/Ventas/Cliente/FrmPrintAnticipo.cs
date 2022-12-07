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

namespace Aplicacion.Ventas.Cliente
{
    public partial class FrmPrintAnticipo : Form
    {
        public string NombreDoc { set; get; }

        public DateTime Fecha { set; get; }

        public string Cliente { set; get; }

        public string Nit { set; get; }

        public string Direccion { set; get; }

        public string Valor { set; get; }

        public string Efectivo { set; get; }

        public string Cheque { set; get; }

        public string Transaccion { set; get; }

        public string Numero { set; get; }

        public string Concepto { set; get; }

        public bool AplicaPago { set; get; }

        public bool Recibo { set; get; }

        public int TipoRecibo { set; get; }

        public string ReportPath { set; get; }

        private BussinesEmpresa miBussinesEmpresa;

        private BussinesUsuario miBussinesUsuario;

        private DataSet DsEmpresa;

        private DataSet DsUsuario;

        public DataTable DsFormas;

        public FrmPrintAnticipo()
        {
            InitializeComponent();
            this.AplicaPago = true;
            this.Recibo = false;
            TipoRecibo = 1; //Comp. de Ingreso.
            this.NombreDoc = "Comprobante de Ingreso No. ";
            this.ReportPath = AppConfiguracion.ValorSeccion("report") + @"\reports\ComprobanteIngreso.rdlc";
            //this.ReportPath = @"c:\reports\ComprobanteIngreso.rdlc";
            miBussinesEmpresa = new BussinesEmpresa();
            miBussinesUsuario = new BussinesUsuario();
            DsEmpresa = new DataSet();
            DsUsuario = new DataSet();
            DsFormas = new DataTable();
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
            //this.Close();
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

                /*this.rpvAnticipo.LocalReport.DataSources.Add(
                                 new ReportDataSource("DsFormas", DsFormas));*/

                rpvAnticipo.LocalReport.ReportPath = this.ReportPath;

                Label NoComIngreso = new Label();
                NoComIngreso.AutoSize = true;
                NoComIngreso.Font = new System.Drawing.Font
                    ("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                NoComIngreso.Text = Numero;

                var pRecibo = new ReportParameter();
                pRecibo.Name = "Recibo";
                pRecibo.Values.Add(this.NombreDoc);
                this.rpvAnticipo.LocalReport.SetParameters(pRecibo);
                /*switch (TipoRecibo)
                {
                    case 1: // Comprobante de Ingreso.
                        {
                            pRecibo.Values.Add("Comprobante de Ingreso No. ");
                            this.rpvAnticipo.LocalReport.SetParameters(pRecibo);
                            break;
                        }
                    case 2: // Recibo de Ingreso.
                        {
                            pRecibo.Values.Add("Recibo de Anticipo No. ");
                            this.rpvAnticipo.LocalReport.SetParameters(pRecibo);
                            break;
                        }
                }*/

                var pNo = new ReportParameter();
                pNo.Name = "No";
                pNo.Values.Add(NoComIngreso.Text);
                this.rpvAnticipo.LocalReport.SetParameters(pNo);

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

                if (AplicaPago)
                {
                    var pEfectivo = new ReportParameter();
                    pEfectivo.Name = "Efectivo";
                    pEfectivo.Values.Add(this.Efectivo);
                    this.rpvAnticipo.LocalReport.SetParameters(pEfectivo);

                    var pCheque = new ReportParameter();
                    pCheque.Name = "Cheque";
                    pCheque.Values.Add(this.Cheque);
                    this.rpvAnticipo.LocalReport.SetParameters(pCheque);

                    //Transaccion
                    var pTransaccion = new ReportParameter();
                    pTransaccion.Name = "Transaccion";
                    pTransaccion.Values.Add(this.Transaccion);
                    this.rpvAnticipo.LocalReport.SetParameters(pTransaccion);
                }
                

                var pConcepto = new ReportParameter();
                pConcepto.Name = "Concepto";
                pConcepto.Values.Add(Concepto);
                this.rpvAnticipo.LocalReport.SetParameters(pConcepto);

                rpvAnticipo.RefreshReport();

                return rpvAnticipo.LocalReport;
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