using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CustomControl
{
    public partial class FrmDocumento : Form
    {
        public string StringCaption { set; get; }

        public FrmDocumento()
        {
            InitializeComponent();
            this.StringCaption = "Selección de documento";
        }

        private void FrmPrint_Load(object sender, EventArgs e)
        {
            this.Text = this.StringCaption;
        }
    }
}