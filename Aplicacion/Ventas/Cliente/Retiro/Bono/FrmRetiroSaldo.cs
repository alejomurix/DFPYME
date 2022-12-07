using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Utilities;

namespace Aplicacion.Ventas.Cliente.Retiro.Bono
{
    public partial class FrmRetiroSaldo : Form
    {
        public int MaxValor = 0;

        private ErrorProvider miError;

        private bool ValorMatch = false;

        private string ValorFormat = "El número que ingreso es invalido.";

        public FrmRetiroSaldo()
        {
            InitializeComponent();
            miError = new ErrorProvider();
        }

        private void FrmRetiroSaldo_Load(object sender, EventArgs e)
        {
            txtValor.SelectAll();
        }

        private void FrmRetiroSaldo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData.Equals(Keys.Escape))
            {
                this.Close();
            }
        }

        private void FrmRetiroSaldo_FormClosing(object sender, FormClosingEventArgs e)
        {
            CompletaEventos.CapturaEventoRetiroSaldo(false);
        }

        private void txtValor_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar.Equals((char)Keys.Enter))
            {
                if (String.IsNullOrEmpty(txtValor.Text))
                {
                    txtValor.Text = "0";
                    ValorMatch = true;
                }
                else
                {
                    if (Validacion.ConFormato
                       (Validacion.TipoValidacion.Numeros, txtValor, miError, ValorFormat))
                    {
                        ValorMatch = true;
                        btnAceptar_Click(this.btnAceptar, new EventArgs());
                    }
                    else
                    {
                        ValorMatch = false;
                    }
                }
            }
        }

        private void txtValor_Validating(object sender, CancelEventArgs e)
        {
            if (String.IsNullOrEmpty(txtValor.Text))
            {
                txtValor.Text = "0";
                ValorMatch = true;
            }
            else
            {
                if (Validacion.ConFormato
                   (Validacion.TipoValidacion.Numeros, txtValor, miError, ValorFormat))
                {
                    ValorMatch = true;
                }
                else
                {
                    ValorMatch = false;
                }
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (ValorMatch)
            {
                if (Convert.ToInt32(txtValor.Text) <= MaxValor)
                {
                    CompletaEventos.CapturaEventoRetiroSaldo(Convert.ToInt32(txtValor.Text));
                    this.Close();
                }
                else
                {
                    CustomControl.OptionPane.MessageInformation("El valor del retiro debe ser menor o igual al valor de Saldo del Bono.");
                }
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}