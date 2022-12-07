using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DTO.Clases;
using BussinesLayer.Clases;

namespace Aplicacion.Compras.Proveedor
{
    public partial class frmCargarCuentaBancariaProveedor : Form
    {
        //objeto para llamar a los metodos que me traen los datos
        private BussinesTipoCuenta cuentabancaria = new BussinesTipoCuenta();
        
        public frmCargarCuentaBancariaProveedor()
        {
            InitializeComponent();
        }
        private void btnCargarInformacionBancaria_Click(object sender, EventArgs e)
        {
            //creo el objeto tipo Cuenta
            Cuenta c = new Cuenta();
            //cargo el objeto 
            c.NumeroCuenta = txtNumeroCuentaProveedor.Text;
            c.IdTipoCuenta = Convert.ToInt32(cbTipoCuenta.SelectedValue);
            c.TitularCuenta = txtTitularCuentaProveedor.Text;
            c.BancoCuenta = txtNombreBancoProveedor.Text;
            //llamo el meto satico cargar datos 
            frmCrearProveedor.CargarDatos(c);
            //cierro formulario
            this.Close();
        }

        private void cbTipoCuenta_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void frmCargarCuentaBancariaProveedor_Load(object sender, EventArgs e)
        {
           //crago el select
            cbTipoCuenta.DataSource = cuentabancaria.listadoTipoCuenta();
        
        }
    }
}
