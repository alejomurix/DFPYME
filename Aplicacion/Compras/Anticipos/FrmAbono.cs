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

namespace Aplicacion.Compras.Anticipos
{
    public partial class FrmAbono : Form
    {
        private Validacion validacion;

        private bool AbonoMatch = false;

        private bool EfectivoMatch = false;

        private bool ChequeMatch = false;

        private bool TransacionMatch = false;

        public FrmAbono()
        {
            InitializeComponent();
            validacion = new Validacion();
        }

        private void FrmAbonoCompra_Load(object sender, EventArgs e)
        {
        }

        private void FrmAbonoCompra_FormClosing(object sender, FormClosingEventArgs e)
        {
            CompletaEventos.CapturaEvento(false);
        }

        private void FrmAbonoCompra_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.F6)
            {
                Validar();
                if (!txtAbono.Text.Equals("0"))
                {
                    if (AbonoMatch && EfectivoMatch && ChequeMatch && TransacionMatch)
                    {
                        var suma = UseObject.RemoveSeparatorMil(txtEfectivo.Text) +
                                   UseObject.RemoveSeparatorMil(txtCheque.Text) +
                                   UseObject.RemoveSeparatorMil(txtTransaccion.Text);
                        if (!UseObject.RemoveSeparatorMil(this.txtAbono.Text).Equals(0))
                        {
                            if (suma == UseObject.RemoveSeparatorMil(txtAbono.Text))
                            {

                                var objeto = new ObjectAbstract();
                                objeto.Id = 200;
                                objeto.Objeto = FormasDePago();
                                CompletaEventos.CapturaEvento(objeto);
                                this.Close();

                            }
                            else
                            {
                                OptionPane.MessageInformation("La suma de las cantidades deben ser igual al valor del abono.");
                                this.txtEfectivo.Focus();
                            }
                        }
                        else
                        {
                            OptionPane.MessageInformation("La suma de las cantidades deben ser igual al valor del abono.");
                            this.txtAbono.Focus();
                        }
                    }
                }
                else
                {
                    OptionPane.MessageInformation("El valor de abono debe ser una cantidad superior a cero.");
                    txtAbono.Focus();
                }
            }
        }

        private void txtAbono_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar.Equals((char)Keys.Enter))
            {
                txtEfectivo.Focus();
            }
        }

        private void txtAbono_Validating(object sender, CancelEventArgs e)
        {
            if (!String.IsNullOrEmpty(txtAbono.Text))
            {
                txtAbono.Text = txtAbono.Text.Replace(".", "");
                if (validacion.ValidarNumeroInt(txtAbono.Text))
                {
                    if (Convert.ToInt32(txtAbono.Text) <= UseObject.RemoveSeparatorMil(txtTotal.Text))
                    {
                        txtAbono.Text = UseObject.InsertSeparatorMil(txtAbono.Text);
                        AbonoMatch = true;
                    }
                    else
                    {
                        OptionPane.MessageError("El valor del Abono no debe ser superior al Total.");
                        AbonoMatch = false;
                    }
                }
                else
                {
                    OptionPane.MessageError("El valor del Abono es invalido.");
                    AbonoMatch = false;
                }
            }
            else
            {
                txtAbono.Text = "0";
                AbonoMatch = false;
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

        private void txtTransaccion_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar.Equals((char)Keys.Enter))
            {
                FrmAbonoCompra_KeyDown(this, new KeyEventArgs(Keys.F6));
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
            var Abono = UseObject.RemoveSeparatorMil(txtAbono.Text);
            var Efectivo = UseObject.RemoveSeparatorMil(txtEfectivo.Text);
            var Cheque = UseObject.RemoveSeparatorMil(txtCheque.Text);
            var Transaccion = UseObject.RemoveSeparatorMil(txtTransaccion.Text);
            var Tarjeta = 0;
            var Formas = new List<DTO.Clases.FormaPago>();
            if (Efectivo <= Abono)
            {
                if (Efectivo != 0)
                {
                    Formas.Add(new FormaPago
                    {
                        IdFormaPago = 1,
                        Valor = Convert.ToInt32(Efectivo)
                    });
                }
                if (Cheque <= (Abono - Efectivo))
                {
                    if (Cheque != 0)
                    {
                        Formas.Add(new FormaPago
                        {
                            IdFormaPago = 2,
                            Valor = Convert.ToInt32(Cheque)
                        });
                    }
                    if (Tarjeta <= (Abono - (Efectivo + Cheque)))
                    {
                        if (Tarjeta != 0)
                        {
                            Formas.Add(new FormaPago
                            {
                                IdFormaPago = 3,
                                Valor = Convert.ToInt32(Tarjeta)
                            });
                        }
                        if (Transaccion <= (Abono - (Efectivo + Cheque + Tarjeta)))
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
                                Valor = Convert.ToInt32(Abono - (Efectivo + Cheque + Tarjeta))
                            });
                        }
                    }
                    else
                    {
                        Formas.Add(new FormaPago
                        {
                            IdFormaPago = 3,
                            Valor = Convert.ToInt32(Abono - (Efectivo - Cheque))
                        });
                    }
                }
                else
                {
                    Formas.Add(new FormaPago
                    {
                        IdFormaPago = 2,
                        Valor = Convert.ToInt32(Abono - Efectivo)
                    });
                }
            }
            else
            {
                Formas.Add(new FormaPago
                {
                    IdFormaPago = 1,
                    Valor = Convert.ToInt32(Abono)
                });
            }

            return Formas;
        }

        /// <summary>
        /// Valida de nuevo los campos de texto.
        /// </summary>
        private void Validar()
        {
            txtAbono_Validating(this.txtAbono, new CancelEventArgs(false));
            txtEfectivo_Validating(this.txtEfectivo, new CancelEventArgs(false));
            txtCheque_Validating(this.txtCheque, new CancelEventArgs(false));
            txtTransaccion_Validating(this.txtTransaccion, new CancelEventArgs(false));
        }
    }
}