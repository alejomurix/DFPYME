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
using DTO.Clases;
using Microsoft.Reporting.WinForms;
using Utilities;

namespace Aplicacion.Ventas.Consultas
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