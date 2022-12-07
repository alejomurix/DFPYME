using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Aplicacion.Ventas.Devolucion
{
    public partial class FrmDatosDevolucion : Form
    {
        /// <summary>
        /// Obtiene o establece el valor que indica si la factura es de contado o crédito.
        /// </summary>
        public bool Contado { set; get; }

        public FrmDatosDevolucion()
        {
            InitializeComponent();
            this.Contado = true;
        }

        private void FrmDatosDevolucion_Load(object sender, EventArgs e)
        {
           /* if (!Contado)
            {
                lblSaloCliente.Text = "Generar Saldo a Cliente.";
            }*/
        }

        private void FrmDatosDevolucion_FormClosing(object sender, FormClosingEventArgs e)
        {
        }
    }
}