using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Aplicacion.Ventas.Cliente;

namespace Aplicacion.Ventas.Cliente
{
    public partial class frmCliente1 : Form
    {
        public frmCliente1()
        {
            InitializeComponent();
        }

        private void frmCliente_Load(object sender, EventArgs e)
        {
            
        }

        private void tsbNuevoCliente_Click(object sender, EventArgs e)
        {
            frmCliente ingresarCliente = new frmCliente();
            ingresarCliente.MdiParent = this;
            ingresarCliente.Show();
        }
    }
}
