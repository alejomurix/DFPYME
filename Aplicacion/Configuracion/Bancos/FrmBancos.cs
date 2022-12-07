using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BussinesLayer.Clases;
using CustomControl;

namespace Aplicacion.Configuracion.Bancos
{
    public partial class FrmBancos : Form
    {
        private BussinesTipoCuenta miBussinesTipoCuenta;

        private BussinesPuc miBussinesPuc;

        private BussinesConsecutivo miBussinesConsecutivo;

        public FrmBancos()
        {
            InitializeComponent();
            this.miBussinesTipoCuenta = new BussinesTipoCuenta();
            this.miBussinesPuc = new BussinesPuc();
            this.miBussinesConsecutivo = new BussinesConsecutivo();
        }

        private void Bancos_Load(object sender, EventArgs e)
        {
            CargarDatos();
        }

        private void tsbtnGuardar_Click(object sender, EventArgs e)
        {

        }

        private void tsbtnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cbTipoCuenta_SelectionChangeCommitted(object sender, EventArgs e)
        {
            this.txtNombreAuxiliar.Text = ((DataRowView)this.cbTipoCuenta.SelectedItem)["descripciontipo_cuenta"].ToString() +
                                          " " + this.txtBanco.Text + " " + this.txtNumero.Text;
        }

        private void txtNumero_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar.Equals((char)Keys.Enter))
            {
                this.txtTitular.Focus();
            }
        }

        private void txtNumero_KeyUp(object sender, KeyEventArgs e)
        {
            this.txtNombreAuxiliar.Text = ((DataRowView)this.cbTipoCuenta.SelectedItem)["descripciontipo_cuenta"].ToString() +
                                          " " + this.txtBanco.Text + " " + this.txtNumero.Text;
        }

        private void txtTitular_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar.Equals((char)Keys.Enter))
            {
                this.txtTitular.Text = this.txtTitular.Text.ToUpper();
                this.txtBanco.Focus();
            }
        }

        private void txtBanco_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar.Equals((char)Keys.Enter))
            {
                this.txtBanco.Text = this.txtBanco.Text.ToUpper();
                this.txtSucursal.Focus();
            }
        }

        private void txtBanco_KeyUp(object sender, KeyEventArgs e)
        {
            this.txtNombreAuxiliar.Text = ((DataRowView)this.cbTipoCuenta.SelectedItem)["descripciontipo_cuenta"].ToString() +
                                          " " + this.txtBanco.Text + " " + this.txtNumero.Text;
        }

        private void txtSucursal_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar.Equals((char)Keys.Enter))
            {
                this.txtSucursal.Text = this.txtSucursal.Text.ToUpper();
                this.txtDireccion.Focus();
            }
        }

        private void txtDireccion_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar.Equals((char)Keys.Enter))
            {

            }
        }


        private void CargarDatos()
        {
            try
            {
                this.cbTipoCuenta.DataSource = miBussinesTipoCuenta.listadoTipoCuenta();

                var cuenta = this.miBussinesPuc.CuentaPuc("1110");
                this.txtCuenta.Text = cuenta.Numero;
                this.txtNombre.Text = cuenta.Nombre;

                this.txtCuentaAuxiliar.Text = cuenta.Numero + miBussinesConsecutivo.Consecutivo("CuentaAuxBanco");
                this.txtNombreAuxiliar.Text = ((DataRowView)this.cbTipoCuenta.SelectedItem)["descripciontipo_cuenta"].ToString();
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
        }
    }
}