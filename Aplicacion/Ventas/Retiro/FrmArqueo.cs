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
using DTO.Clases;
using Utilities;

namespace Aplicacion.Ventas.Retiro
{
    public partial class FrmArqueo : Form
    {
        private int idCaja;

        private BussinesEgreso miBussinesEgreso;

        private Validacion validacion;

        private bool EfectivoMatch = false;

        private bool ChequeMatch = false;

        private bool TarjetaMatch = false;

        public FrmArqueo()
        {
            InitializeComponent();
            miBussinesEgreso = new BussinesEgreso();
            validacion = new Validacion();
            idCaja = Convert.ToInt32(AppConfiguracion.ValorSeccion("id_caja"));
        }

        private void FrmArqueo_Load(object sender, EventArgs e)
        {
            CargarTotal();
        }

        private void FrmArqueo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData.Equals(Keys.Escape))
            {
                this.Close();
            }
        }

        private void FrmArqueo_FormClosing(object sender, FormClosingEventArgs e)
        {

        }

        private void txtEfectivo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar.Equals((char)Keys.Enter))
            {
                txtCheque.Focus();
            }
        }

        private void txtEfectivo_Validating(object sender, CancelEventArgs e)
        {
            if (!String.IsNullOrEmpty(txtEfectivo.Text))
            {
                txtEfectivo.Text = txtEfectivo.Text.Replace(".", "");
                if (validacion.ValidarNumeroInt(txtEfectivo.Text))
                {
                    txtEfectivo.Text = UseObject.InsertSeparatorMil(txtEfectivo.Text);
                    EfectivoMatch = true;
                    Suma();
                }
                else
                {
                    OptionPane.MessageError("El valor del Efectivo es inválido.");
                    EfectivoMatch = false;
                }
            }
            else
            {
                txtEfectivo.Text = "0";
                EfectivoMatch = true;
            }
        }

        private void txtCheque_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar.Equals((char)Keys.Enter))
            {
                txtTarjeta.Focus();
            }
        }

        private void txtCheque_Validating(object sender, CancelEventArgs e)
        {
            if (!String.IsNullOrEmpty(txtCheque.Text))
            {
                txtCheque.Text = txtCheque.Text.Replace(".", "");
                if (validacion.ValidarNumeroInt(txtCheque.Text))
                {
                    txtCheque.Text = UseObject.InsertSeparatorMil(txtCheque.Text);
                    ChequeMatch = true;
                    Suma();
                }
                else
                {
                    OptionPane.MessageError("El valor del Cheque es inválido.");
                    ChequeMatch = false;
                }
            }
            else
            {
                txtCheque.Text = "0";
                ChequeMatch = true;
            }
        }

        private void txtTarjeta_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar.Equals((char)Keys.Enter))
            {
                btnAceptar.Focus();
            }
        }

        private void txtTarjeta_Validating(object sender, CancelEventArgs e)
        {
            if (!String.IsNullOrEmpty(txtTarjeta.Text))
            {
                txtTarjeta.Text = txtTarjeta.Text.Replace(".", "");
                if (validacion.ValidarNumeroInt(txtTarjeta.Text))
                {
                    txtTarjeta.Text = UseObject.InsertSeparatorMil(txtTarjeta.Text);
                    TarjetaMatch = true;
                    Suma();
                }
                else
                {
                    OptionPane.MessageError("El valor de la Tarjeta es inválido.");
                    TarjetaMatch = false;
                }
            }
            else
            {
                txtTarjeta.Text = "0";
                TarjetaMatch = true;
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            txtEfectivo_Validating(this.txtEfectivo, new CancelEventArgs(false));
            txtCheque_Validating(this.txtCheque, new CancelEventArgs(false));
            txtTarjeta_Validating(this.txtTarjeta, new CancelEventArgs(false));
            if (EfectivoMatch && ChequeMatch && TarjetaMatch)
            {
                var arqueo = new Arqueo();
                arqueo.Fecha = DateTime.Now;
                arqueo.Caja.Id = idCaja;
                arqueo.Usuario.Id = Convert.ToInt32(AppConfiguracion.ValorSeccion("id_user"));
               // arqueo.Apertura = Convert.ToInt32(UseObject.RemoveSeparatorMil(txtEfectivo.Text));
                arqueo.Cierre = Convert.ToInt32(UseObject.RemoveSeparatorMil(txtCheque.Text));
                arqueo.Tarjeta = Convert.ToInt32(UseObject.RemoveSeparatorMil(txtTarjeta.Text));
                try
                {
                    miBussinesEgreso.IngresarArqueo(arqueo);
                    OptionPane.MessageInformation("Los datos del Arqueo se ingresaron con éxito.");
                    txtEfectivo.Focus();
                    LimpiarCampos();
                    CargarTotal();
                }
                catch (Exception ex)
                {
                    OptionPane.MessageError(ex.Message);
                }
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CargarTotal()
        {
            try
            {
                txtTotalAnt.Text = UseObject.InsertSeparatorMil(
                    miBussinesEgreso.TotalArqueo(idCaja, DateTime.Now).ToString());
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
        }

        private void Suma()
        {
            txtTotal.Text = UseObject.InsertSeparatorMil(
                (UseObject.RemoveSeparatorMil(txtEfectivo.Text) +
                 UseObject.RemoveSeparatorMil(txtCheque.Text) +
                 UseObject.RemoveSeparatorMil(txtTarjeta.Text)
                ).ToString());
        }

        private void LimpiarCampos()
        {
            txtEfectivo.Text = "0";
            txtCheque.Text = "0";
            txtTarjeta.Text = "0";
            txtTotal.Text = "0";
        }
    }
}