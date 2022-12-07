using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FormulariosSistema
{
    public partial class FrmElectronicDocument_ : Form
    {
        public FrmElectronicDocument_()
        {
            InitializeComponent();
        }

        private void FrmElectronicDocument__Load(object sender, EventArgs e)
        {
            this.dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(79, 129, 189);
        }
    }
}
