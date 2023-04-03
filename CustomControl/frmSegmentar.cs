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
    public partial class frmSegmentar : Form
    {
        public bool Segment { set; get; }

        public frmSegmentar()
        {
            InitializeComponent();
        }

        private void frmPassword_Load(object sender, EventArgs e)
        {
            lblSegment.Visible = false;
            OK.Enabled = true;
            OK.Focus();

            if (!Segment)
            {
                lblSegment.Visible = true;
                Cancel.Focus();
                OK.Enabled = false;
            }
        }

        private void frmPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData.Equals(Keys.Escape))
            {
                this.Close();
            }
        }
    }
}