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
using CustomControl;
using Utilities;

namespace Aplicacion.Ventas.Factura
{
    public partial class FrmImpuestoBolsa : Form
    {
        private const int IdImpuestoBolsas = 1;

        private ErrorProvider miError;

        private BussinesImpuestoBolsa miBussinesImpuesto;

        public FrmImpuestoBolsa()
        {
            InitializeComponent();
            this.miError = new ErrorProvider();
            this.miBussinesImpuesto = new BussinesImpuestoBolsa();
        }

        private void FrmImpuestoBolsa_Load(object sender, EventArgs e)
        {
            try
            {
                var impuesto = this.miBussinesImpuesto.ImpuestoBolsa(IdImpuestoBolsas);
                this.txtValorUnitario.Text = impuesto.Valor.ToString();
                this.txtValorTotal.Text =
                    (Convert.ToDouble(this.txtCantidad.Text) * impuesto.Valor).ToString();
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
        }

        private void FrmImpuestoBolsa_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData.Equals(Keys.Escape))
            {
                this.Close();
            }
        }

        private void txtCantidad_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar.Equals((char)Keys.Enter))
            {
                if (!String.IsNullOrEmpty(this.txtCantidad.Text))
                {
                    if (ValidarNumero(this.txtCantidad.Text))
                    {
                        if (Convert.ToDouble(this.txtCantidad.Text) > 0)
                        {
                            this.miError.SetError(this.txtCantidad, null);
                            this.txtValorTotal.Text =
                            (Convert.ToDouble(this.txtCantidad.Text) * Convert.ToDouble(this.txtValorUnitario.Text)).ToString();
                            //this.btnAceptar.Focus();
                            this.btnAceptar_Click(this.btnAceptar, new EventArgs());
                        }
                        else
                        {
                            this.miError.SetError(this.txtCantidad, "El valor debe ser mayor a cero.");
                        }
                    }
                    else
                    {
                        this.miError.SetError(this.txtCantidad, "El valor es incorrecto.");
                    }
                }
                else
                {
                    this.miError.SetError(this.txtCantidad, "El campo no debe ser vacio.");
                }
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            CompletaEventos.CapturaEvento(new ObjectAbstract
            {
                Id = 88997766,
                Objeto =
                new ImpuestoBolsa { Cantidad = Convert.ToDouble(this.txtCantidad.Text), Valor = Convert.ToDouble(this.txtValorUnitario.Text) }
            });
            this.Close();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private bool ValidarNumero(string numero)
        {
            try
            {
                Convert.ToDouble(numero);
                return true;
            }
            catch (FormatException)
            {
                return false;
            }
        }

    }
}