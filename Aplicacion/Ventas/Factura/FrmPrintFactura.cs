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

namespace Aplicacion.Ventas.Factura
{
    public partial class FrmPrintFactura : Form
    {
        public FrmPrintFactura()
        {
            InitializeComponent();
        }

        private void FrmPrintFactura_Load(object sender, EventArgs e)
        {
            this.RptvFactura.RefreshReport();
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

        public void ResetReport()
        {
            this.RptvFactura.Reset();
        }
    }
}