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
    public partial class frmProgressBar : Form
    {
        /// <summary>
        /// Obtiene o establece el valor que indica si se cerrara el formulario.
        /// </summary>
        public bool Closed_ { set; get; }

        /// <summary>
        /// Inicializa una nueva instancia de la clase frmProgressBar.
        /// </summary>
        public frmProgressBar()
        {
            InitializeComponent();
            this.Closed_ = true;
        }

        private void frmProgressBar_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (Closed_)
                e.Cancel = true;
        }
    }
}