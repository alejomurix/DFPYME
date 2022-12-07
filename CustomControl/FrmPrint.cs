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
    public partial class FrmPrint : Form
    {
        public string StringCaption { set; get; }

        public string StringMessage { set; get; }

        public FrmPrint()
        {
            InitializeComponent();
            this.StringCaption = "Imprimir";
            this.StringMessage = "Imprimir";
        }

        private void FrmPrint_Load(object sender, EventArgs e)
        {
            this.Text = this.StringCaption;
            this.lblInfo.Text = this.StringMessage;
        }
    }
}