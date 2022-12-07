using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Aplicacion.Compras.Proveedor;
using DTO.Clases;

namespace Aplicacion.Compras.Proveedor
{
    public partial class frmCrearProveedor : Form
    {
        // Objeto listaCuenta tipo List<Cuenta> para almacenar cuentas
        public static List<Cuenta> listaCuenta = new List<Cuenta>();
        

        public frmCrearProveedor()
        {
            InitializeComponent();
        }

        private void btnAgregarInformacionBancaria_Click(object sender, EventArgs e)
        {
          //llamar form para cargar cuenta bancaria 
            frmCargarCuentaBancariaProveedor cuentaBancaria = new frmCargarCuentaBancariaProveedor();
            cuentaBancaria.Show();
        }

        /// <summary>
        /// Metodo para cargar la grilla con datos
        /// </summary>
        public static void CargarDatos(Cuenta cuenta)
        {
            dgvDatosBancario.DataSource = null;
            listaCuenta.Add(cuenta);
            dgvDatosBancario.DataSource = listaCuenta;           
        }

        private void dgvDatosBancario_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
