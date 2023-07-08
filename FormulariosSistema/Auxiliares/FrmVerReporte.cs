using System;
using System.Windows.Forms;

namespace FormulariosSistema.Auxiliares
{
    public partial class FrmVerReporte : Form
    {

        public FrmVerReporte()
        {
            InitializeComponent();
        }

        private void FrmVerReporte_Load(object sender, EventArgs e)
        {
            this.rptVerInforme.RefreshReport();
        }

        private void FrmVerReporte_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.rptVerInforme.Reset();
        }
    }
}