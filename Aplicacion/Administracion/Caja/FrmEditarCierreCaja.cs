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

namespace Aplicacion.Administracion.Caja
{
    public partial class FrmEditarCierreCaja : Form
    {
        public int IdCierre { set; get; }

        private ErrorProvider miError;

        private bool EfectivoMatch;

        private bool ChequeMatch;

        private bool TarjetaMatch;

        private bool TransaccionMatch;

        private BussinesCierre miBussinesCierre;

        private BussinesApertura miBussinesApertura;

        public FrmEditarCierreCaja()
        {
            InitializeComponent();
            this. miError = new ErrorProvider();
            this.EfectivoMatch = false;
            this.ChequeMatch = false;
            this.TarjetaMatch = false;
            this.TransaccionMatch = false;
            this.miBussinesCierre = new BussinesCierre();
            this.miBussinesApertura = new BussinesApertura();
        }

        private void FrCierreCaja_Load(object sender, EventArgs e)
        {
        }

        private void FrCierreCaja_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData.Equals(Keys.F2))
            {
                //this.btnGuardar_Click(this.btnGuardar, new EventArgs());
            }
            else
            {
                if (e.KeyData.Equals(Keys.Escape))
                {
                    this.Close();
                }
            }
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
            if (!String.IsNullOrEmpty(this.txtEfectivo.Text))
            {
                if (Validacion.ConFormato
                    (Validacion.TipoValidacion.Numeros, this.txtEfectivo, miError, "El valor tiene formato incorrecto."))
                {
                    this.EfectivoMatch = true;
                }
                else
                {
                    this.EfectivoMatch = false;
                }
            }
            else
            {
                this.txtEfectivo.Text = "0";
                this.EfectivoMatch = true;
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
                if (Validacion.ConFormato
                    (Validacion.TipoValidacion.Numeros, txtCheque, miError, "El valor tiene formato incorrecto."))
                {
                    ChequeMatch = true;
                }
                else
                {
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
                txtTransaccion.Focus();
            }
        }

        private void txtTarjeta_Validating(object sender, CancelEventArgs e)
        {
            if (!String.IsNullOrEmpty(txtTarjeta.Text))
            {
                if (Validacion.ConFormato
                    (Validacion.TipoValidacion.Numeros, txtTarjeta, miError, "El valor tiene formato incorrecto."))
                {
                    TarjetaMatch = true;
                }
                else
                {
                    TarjetaMatch = false;
                }
            }
            else
            {
                txtTarjeta.Text = "0";
                TarjetaMatch = true;
            }
        }

        private void txtTransaccion_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar.Equals((char)Keys.Enter))
            {
                btnGuardar_Click(this.btnGuardar, new EventArgs());
            }
        }

        private void txtTransaccion_Validating(object sender, CancelEventArgs e)
        {
            if (!String.IsNullOrEmpty(txtTransaccion.Text))
            {
                if (Validacion.ConFormato
                    (Validacion.TipoValidacion.Numeros, txtTransaccion, miError, "El valor tiene formato incorrecto."))
                {
                    TransaccionMatch = true;
                }
                else
                {
                    TransaccionMatch = false;
                }
            }
            else
            {
                txtTransaccion.Text = "0";
                TransaccionMatch = true;
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try 
            {
                this.txtEfectivo_Validating(this.txtEfectivo, new CancelEventArgs(false));
                this.txtCheque_Validating(this.txtCheque, new CancelEventArgs(false));
                this.txtTarjeta_Validating(this.txtTarjeta, new CancelEventArgs(false));
                this.txtTransaccion_Validating(this.txtTransaccion, new CancelEventArgs(false));
                if (this.EfectivoMatch &&
                    this.ChequeMatch &&
                    this.TarjetaMatch &&
                    this.TransaccionMatch)
                {
                    if ((Convert.ToInt32(this.txtEfectivo.Text) + Convert.ToInt32(this.txtCheque.Text) +
                         Convert.ToInt32(this.txtTarjeta.Text) + Convert.ToInt32(this.txtTransaccion.Text)) > 0)
                    {
                        DialogResult rta = MessageBox.Show("¿Está seguro(a) de guardar el cierre?", "Edición de cierre",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (rta.Equals(DialogResult.Yes))
                        {
                            this.miBussinesCierre.EliminarPagosCierre(this.IdCierre);
                            if (Convert.ToInt32(this.txtEfectivo.Text) > 0)
                            {
                                this.miBussinesCierre.IngresarValor
                                    (new FormaPago { IdEgreso = this.IdCierre, IdFormaPago = 1, Valor = Convert.ToInt32(this.txtEfectivo.Text) });
                            }
                            if (Convert.ToInt32(this.txtCheque.Text) > 0)
                            {
                                this.miBussinesCierre.IngresarValor
                                    (new FormaPago { IdEgreso = this.IdCierre, IdFormaPago = 2, Valor = Convert.ToInt32(this.txtCheque.Text) });
                            }
                            if (Convert.ToInt32(this.txtTarjeta.Text) > 0)
                            {
                                this.miBussinesCierre.IngresarValor
                                    (new FormaPago { IdEgreso = this.IdCierre, IdFormaPago = 3, Valor = Convert.ToInt32(this.txtTarjeta.Text) });
                            }
                            if (Convert.ToInt32(this.txtTransaccion.Text) > 0)
                            {
                                this.miBussinesCierre.IngresarValor
                                    (new FormaPago { IdEgreso = this.IdCierre, IdFormaPago = 4, Valor = Convert.ToInt32(this.txtTransaccion.Text) });
                            }
                            CompletaEventos.CapturaEvento(new ObjectAbstract { Id = 555888779 });
                            OptionPane.MessageInformation("Los datos se editaron con éxito.");
                        }
                    }
                    else
                    {
                        OptionPane.MessageInformation("Al menos una forma de pago debe ser superior a cero.");
                    }
                }
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
        }
    }
}