using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;

namespace FormulariosSistema.InformesForms
{
    public partial class FrmReportViewer : Form
    {
        

        public FrmReportViewer()
        {
            InitializeComponent();
            
        }

        private void FrmReportViewer_Load(object sender, EventArgs e)
        {
            this.reportViewer.RefreshReport();
        }

        public void RefreshReport()
        {
            this.reportViewer.LocalReport.DataSources.Clear();
            this.reportViewer.LocalReport.Dispose();
            this.reportViewer.Reset();
        }
    }
}