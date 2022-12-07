using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Utilities;

namespace Aplicacion.Ventas.Cliente.Retiro.Adelanto
{
    public partial class FrmRetiroAdelanto : Form
    {
        public int MaxValor = 0;

        private ErrorProvider miError;

        private bool ValorMatch = false;

        private string ValorFormat = "El número que ingreso es invalido.";

        public FrmRetiroAdelanto()
        {
            InitializeComponent();
            miError = new ErrorProvider();
        }

        private void FrmRetiroAdelanto_Load(object sender, EventArgs e)
        {
            txtValor.SelectAll();
        }

        private void FrmRetiroAdelanto_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData.Equals(Keys.Escape))
            {
                this.Close();
            }
        }

        private void FrmRetiroAdelanto_FormClosing(object sender, FormClosingEventArgs e)
        {
            CompletaEventos.CapturaEventoRetiroAdelanto(false);
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
                    this.miError.SetError(this.txtValor, null);
                    DialogResult rta = MessageBox.Show("¿Está seguro(a) de realizar el retiro?", "Retiro de Adelanto",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (rta.Equals(DialogResult.Yes))
                    {
                        //CompletaEventos.CapturaEventoRetiroAdelanto(Convert.ToInt32(txtValor.Text));
                        CompletaEventos.CapturaEventoRetiroAdelanto(new ObjectAbstract { Id = 90001, Objeto = Convert.ToInt32(txtValor.Text) });
                        this.Close();
                    }
                }
                else
                {
                    this.miError.SetError(this.txtValor, "El valor no debe superar el saldo del cliente.");
                    //CustomControl.OptionPane.MessageInformation("El valor del retiro debe ser menor o igua al valor de Saldo de los Adelantos.");
                }
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}