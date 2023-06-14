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
        private bool closed;

        private ToolTip toolTip;

        public bool Segment { set; get; }

        public bool Electronic { set; get; }

        public frmSegmentar()
        {
            InitializeComponent();

            closed = false;
            toolTip = new ToolTip();
            toolTip.SetToolTip(OK, "Segmentar POS");
            toolTip.SetToolTip(btnYes, "Orden de pedido");
            toolTip.SetToolTip(btnRetry, "Segmentar POS mas Orden");
            toolTip.SetToolTip(btnNo, "Factura Electronica");
        }

        private void frmPassword_Load(object sender, EventArgs e)
        {
            lblSegment.Visible = false;
            OK.Enabled = true;
            btnYes.Enabled = true;
            btnRetry.Enabled = true;
            OK.Focus();

            if (!Segment)
            {
                lblSegment.Visible = true;
                btnNo.Focus();
                OK.Enabled = false;
                btnYes.Enabled = false;
                btnRetry.Enabled = false;
            }
            if (!Electronic)
            {
                btnNo.Enabled = false;
            }
        }

        private void frmPassword_KeyDown(object sender, KeyEventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            if (Segment)
            {
                switch (e.KeyData)
                {
                    case Keys.D1:
                    case Keys.NumPad1:
                        if (Segment)
                        {
                            this.DialogResult = DialogResult.OK;
                            closed = true;
                            this.Close();
                        }
                        break;
                    case Keys.D2:
                    case Keys.NumPad2:
                        if (Segment)
                        {
                            this.DialogResult = DialogResult.Yes;
                            closed = true;
                            this.Close();
                        }
                        break;
                    case Keys.D3:
                    case Keys.NumPad3:
                        if (Segment)
                        {
                            this.DialogResult = DialogResult.Retry;
                            closed = true;
                            this.Close();
                        }
                        break;
                    case Keys.D4:
                    case Keys.NumPad4:
                        if (Electronic)
                        {
                            this.DialogResult = DialogResult.No;
                            closed = true;
                            this.Close();
                        }
                        break;
                    case Keys.Escape:
                        closed = true;
                        this.Close();
                        break;
                }
            }
            else
            {
                if (Electronic && (e.KeyData.Equals(Keys.D4) || e.KeyData.Equals(Keys.NumPad4)))
                {
                    this.DialogResult = DialogResult.No;
                    closed = true;
                    this.Close();
                }
            }

            /*
            if (e.KeyData.Equals(Keys.Escape))
            {
                this.Close();
            }
            else
            {
                if (e.KeyData.Equals(Keys.D1))
                {
                    this.DialogResult = DialogResult.OK;
                }
            }*/
        }

        private void frmSegmentar_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = !closed;
        }
    }
}