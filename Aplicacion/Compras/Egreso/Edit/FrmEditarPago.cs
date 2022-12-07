using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DTO.Clases;
using Utilities;
using CustomControl;
using BussinesLayer.Clases;

namespace Aplicacion.Compras.Egreso.Edit
{
    public partial class FrmEditarPago : Form
    {
        private Validacion validacion;

        private bool EfectivoMatch = false;

        private bool ChequeMatch = false;

        private bool TarjetaMatch = false;

        private bool TransacionMatch = false;

        public FrmEditarPago()
        {
            InitializeComponent();
            this.validacion = new Validacion();
        }

        private void FrmCancelarCompra_Load(object sender, EventArgs e)
        {
        }

        private void FrmCancelarCompra_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData.Equals(Keys.F6))
            {
                Validar();
                if (EfectivoMatch && ChequeMatch && TarjetaMatch && TransacionMatch)
                {
                    var suma = UseObject.RemoveSeparatorMil(txtEfectivo.Text) +
                               UseObject.RemoveSeparatorMil(txtCheque.Text) +
                               UseObject.RemoveSeparatorMil(txtTarjeta.Text) +
                               UseObject.RemoveSeparatorMil(txtTransaccion.Text);
                    if (suma == UseObject.RemoveSeparatorMil(txtTotal.Text))
                    {
                        DialogResult rta = MessageBox.Show("¿Está seguro(a) de querer editar el pago?",
                                    "Editar Pago", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (rta == DialogResult.Yes)
                        {
                            try
                            {
                                CompletaEventos.CapturaEventoz(new ObjectAbstract
                                {
                                    Id = 235,
                                    Objeto = FormasDePago()
                                });
                                this.Close();
                            }
                            catch (Exception ex)
                            {
                                OptionPane.MessageError(ex.Message);
                            }
                        }
                    }
                    else
                    {
                        OptionPane.MessageInformation("La suma de las cantidades deben ser igual al valor total.");
                        txtEfectivo.Focus();
                    }
                }
            }
            else
            {
                if (e.KeyData.Equals(Keys.Escape))
                {
                    this.Close();
                }
            }
        }

        private void FrmCancelarCompra_FormClosing(object sender, FormClosingEventArgs e)
        {
            CompletaEventos.CapturaEventoz(false);
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
                txtTransaccion.Focus();
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
                txtTransaccion.Focus();
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

        private void txtTransaccion_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar.Equals((char)Keys.Enter))
            {
                FrmCancelarCompra_KeyDown(this, new KeyEventArgs(Keys.F6));
            }
        }

        private void txtTransaccion_Validating(object sender, CancelEventArgs e)
        {
            if (!String.IsNullOrEmpty(txtTransaccion.Text))
            {
                txtTransaccion.Text = txtTransaccion.Text.Replace(".", "");
                if (validacion.ValidarNumeroInt(txtTransaccion.Text))
                {
                    txtTransaccion.Text = UseObject.InsertSeparatorMil(txtTransaccion.Text);
                    TransacionMatch = true;
                }
                else
                {
                    OptionPane.MessageError("El valor de la Transacción es inválido.");
                    TransacionMatch = false;
                }
            }
            else
            {
                txtTransaccion.Text = "0";
                TransacionMatch = true;
            }
        }

        /// <summary>
        /// Obtiene las formas de pago usadas en el Pago a Proveedor.
        /// </summary>
        /// <returns></returns>
        private List<FormaPago> FormasDePago()
        {
            var Total = UseObject.RemoveSeparatorMil(txtTotal.Text);
            var Efectivo = UseObject.RemoveSeparatorMil(txtEfectivo.Text);
            var Cheque = UseObject.RemoveSeparatorMil(txtCheque.Text);
            var Tarjeta = UseObject.RemoveSeparatorMil(txtTarjeta.Text);
            var Transaccion = UseObject.RemoveSeparatorMil(txtTransaccion.Text);

            var Formas = new List<DTO.Clases.FormaPago>();
            if (Efectivo <= Total)
            {
                if (Efectivo != 0)
                {
                    Formas.Add(new FormaPago
                    {
                        IdFormaPago = 1,
                        Valor = Convert.ToInt32(Efectivo)
                    });
                }
                if (Cheque <= (Total - Efectivo))
                {
                    if (Cheque != 0)
                    {
                        Formas.Add(new FormaPago
                        {
                            IdFormaPago = 2,
                            Valor = Convert.ToInt32(Cheque)
                        });
                    }
                    if (Tarjeta <= (Total - (Efectivo + Cheque)))
                    {
                        if (Tarjeta != 0)
                        {
                            Formas.Add(new FormaPago
                            {
                                IdFormaPago = 3,
                                Valor = Convert.ToInt32(Tarjeta)
                            });
                        }
                        if (Transaccion <= (Total - (Efectivo + Cheque + Tarjeta)))
                        {
                            if (Transaccion != 0)
                            {
                                Formas.Add(new FormaPago
                                {
                                    IdFormaPago = 4,
                                    Valor = Convert.ToInt32(Transaccion)
                                });
                            }
                        }
                        else
                        {
                            Formas.Add(new FormaPago
                            {
                                IdFormaPago = 4,
                                Valor = Convert.ToInt32(Total - (Efectivo + Cheque + Tarjeta))
                            });
                        }
                    }
                    else
                    {
                        Formas.Add(new FormaPago
                        {
                            IdFormaPago = 3,
                            Valor = Convert.ToInt32(Total - (Efectivo - Cheque))
                        });
                    }
                }
                else
                {
                    Formas.Add(new FormaPago
                    {
                        IdFormaPago = 2,
                        Valor = Convert.ToInt32(Total - Efectivo)
                    });
                }
            }
            else
            {
                Formas.Add(new FormaPago
                {
                    IdFormaPago = 1,
                    Valor = Convert.ToInt32(Total)
                });
            }

            return Formas;
        }

        /// <summary>
        /// Valida de nuevo los campos de texto.
        /// </summary>
        private void Validar()
        {
            txtEfectivo_Validating(this.txtEfectivo, new CancelEventArgs(false));
            txtCheque_Validating(this.txtCheque, new CancelEventArgs(false));
            txtTarjeta_Validating(this.txtTarjeta, new CancelEventArgs(false));
            txtTransaccion_Validating(this.txtTransaccion, new CancelEventArgs(false));
        }
    }
}