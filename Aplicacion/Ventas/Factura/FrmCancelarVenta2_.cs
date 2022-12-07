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

namespace Aplicacion.Ventas.Factura
{
    public partial class FrmCancelarVenta2 : Form
    {
        private BussinesFormaPago miBussinesPago;

        //public DateTime Fecha { set; get; }
        public string NumeroFactura { set; get; }
        public bool EsVenta = true;
        Validacion validacion;
        private bool Efectivo = false;
        private bool Cheque = false;
        private bool Tarjeta = false;
        private bool Venta = true;
        public bool Abono = false;

        public FrmCancelarVenta2()
        {
            InitializeComponent();
            miBussinesPago = new BussinesFormaPago();
            validacion = new Validacion();
        }

        private void FrmCancelarVenta_Load(object sender, EventArgs e)
        {
        }

        private void FrmCancelarVenta_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.F6)
            {
                txtEfectivo_Validating(txtEfectivo, new CancelEventArgs(false));
                txtCheque_Validating(txtCheque, new CancelEventArgs(false));
                txtTarjeta_Validating(txtTarjeta, new CancelEventArgs(false));
                if (Venta)
                {
                    if (!Abono)
                    {
                        if (Efectivo && Cheque && Tarjeta)
                        {
                            var suma = UseObject.RemoveSeparatorMil(txtEfectivo.Text) +
                                       UseObject.RemoveSeparatorMil(txtCheque.Text) +
                                       UseObject.RemoveSeparatorMil(txtTarjeta.Text);
                            if (suma >= UseObject.RemoveSeparatorMil(txtTotal.Text))
                            {
                                txtCambio.Text = UseObject.InsertSeparatorMil
                                    (
                                        ((UseObject.RemoveSeparatorMil(txtEfectivo.Text) +
                                         UseObject.RemoveSeparatorMil(txtCheque.Text) +
                                         UseObject.RemoveSeparatorMil(txtTarjeta.Text)) -
                                         UseObject.RemoveSeparatorMil(txtTotal.Text))
                                         .ToString()
                                    );
                                var msn = "";
                                if (EsVenta)
                                {
                                    msn = "¿Está seguro(a) de querer cerrar la Venta?";
                                }
                                else
                                {
                                    msn = "¿Está seguro(a) de querer cerrar la Remisión?";
                                }
                                DialogResult rta = MessageBox.Show(msn,
                                "Cancelar", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                                if (rta == DialogResult.Yes)
                                {
                                    var formas = FormasDePago();
                                    if (EsVenta)
                                    {
                                        CompletaEventos.CapturaEvento(formas);
                                    }
                                    else
                                    {
                                        CompletaEventos.CapturaEventoem(formas);
                                    }
                                    Venta = false;
                                    formas = null;
                                    this.Close();
                                }
                            }
                            else
                            {
                                OptionPane.MessageInformation("El valor ingresado debe ser superior " +
                                    "al de la venta.");
                            }
                        }
                        /*DialogResult rta = MessageBox.Show("¿Está seguro(a) de querer cerrar la venta?",
                                "Cerrar Venta", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                        if (rta == DialogResult.Yes)
                        {
                            
                        }*/
                    }
                    else
                    {
                        DialogResult rta = MessageBox.Show("¿Está seguro(a) de querer realizar el abono?",
                                "Realizar Abono", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                        if (rta == DialogResult.Yes)
                        {
                            if (Efectivo && Cheque && Tarjeta)
                            {
                                var suma = UseObject.RemoveSeparatorMil(txtEfectivo.Text) +
                                           UseObject.RemoveSeparatorMil(txtCheque.Text) +
                                           UseObject.RemoveSeparatorMil(txtTarjeta.Text);

                                var formas = FormasDePago();

                                try
                                {
                                    foreach (FormaPago pago in formas)
                                    {
                                        if (pago.Valor != 0)
                                        {
                                            pago.NumeroFactura = NumeroFactura;
                                            pago.Fecha = DateTime.Now;
                                            miBussinesPago.IngresarPagoAFactura(pago, true, Convert.ToBoolean(AppConfiguracion.ValorSeccion("printIngreso")));

                                        }
                                    }
                                    OptionPane.MessageInformation("El abono se realizó con éxito.");
                                }
                                catch (Exception ex)
                                {
                                    OptionPane.MessageError(ex.Message);
                                }
                            }
                        }
                    }
                }
            }
            else
            {
                if (e.KeyData == Keys.Escape)
                {
                    this.Close();
                    /*DialogResult rta = MessageBox.Show("¿Está seguro(a) de querer cerrar la venta?",
                        "Cerrar Venta", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                    if (rta == DialogResult.Yes)
                    {
                        OptionPane.MessageSuccess("La venta se realizó con éxito!");
                        CompletaEventos.CapturaEvento(true);
                        this.Close();
                    }*/
                }
            }
        }

        private void FrmCancelarVenta_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (EsVenta)
            {
                CompletaEventos.CapturaEvento(false);
            }
            else
            {
                CompletaEventos.CapturaEventoem(false);
            }
        }

        private void txtEfectivo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar.Equals((char)Keys.Enter))
            {
                //txtCheque.Focus();
                this.txtTarjeta_KeyPress(this.txtTarjeta, new KeyPressEventArgs((char)Keys.Enter));
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
                    Efectivo = true;
                    if (!txtEfectivo.Text.Equals("0"))
                    {
                        txtCambio.Text = UseObject.InsertSeparatorMil
                                (
                                    (UseObject.RemoveSeparatorMil(txtEfectivo.Text) -
                                        UseObject.RemoveSeparatorMil(txtTotal.Text))
                                        .ToString()
                                );
                    }
                }
                else
                {
                    OptionPane.MessageError("El valor del Efectivo es incorrecto.");
                    Efectivo = false;
                }
            }
            else
            {
                txtEfectivo.Text = "0";
                Efectivo = true;
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
                    Cheque = true;
                    if (!txtCheque.Text.Equals("0"))
                    {
                        txtCambio.Text = UseObject.InsertSeparatorMil
                                (
                                    ((UseObject.RemoveSeparatorMil(txtEfectivo.Text) +
                                        UseObject.RemoveSeparatorMil(txtCheque.Text)) -
                                        UseObject.RemoveSeparatorMil(txtTotal.Text))
                                        .ToString()
                                );
                    }
                }
                else
                {
                    OptionPane.MessageError("El valor del Cheque es incorrecto.");
                    Cheque = false;
                }
            }
            else
            {
                txtCheque.Text = "0";
                Cheque = true;
            }
        }

        private void txtTarjeta_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar.Equals((char)Keys.Enter))
            {
                FrmCancelarVenta_KeyDown(this, new KeyEventArgs(Keys.F6));
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
                    Tarjeta = true;
                    if (!txtTarjeta.Text.Equals("0"))
                    {
                        txtCambio.Text = UseObject.InsertSeparatorMil
                                (
                                    ((UseObject.RemoveSeparatorMil(txtEfectivo.Text) +
                                        UseObject.RemoveSeparatorMil(txtCheque.Text) +
                                        UseObject.RemoveSeparatorMil(txtTarjeta.Text)) -
                                        UseObject.RemoveSeparatorMil(txtTotal.Text))
                                        .ToString()
                                );
                    }
                }
                else
                {
                    OptionPane.MessageError("El valor de la Tarjeta es incorrecto.");
                    Tarjeta = false;
                }
            }
            else
            {
                txtTarjeta.Text = "0";
                Tarjeta = true;
            }
        }

        private List<DTO.Clases.FormaPago> FormasDePago()
        {
            var Total = UseObject.RemoveSeparatorMil(txtTotal.Text);
            var Efectivo = UseObject.RemoveSeparatorMil(txtEfectivo.Text);
            var Cheque = UseObject.RemoveSeparatorMil(txtCheque.Text);
            var Tarjeta = UseObject.RemoveSeparatorMil(txtTarjeta.Text);

            var Formas = new List<DTO.Clases.FormaPago>();
            if (Efectivo <= Total)
            {
                if (Efectivo != 0)
                {
                    Formas.Add(new DTO.Clases.FormaPago
                    {
                        IdEgreso = Convert.ToInt32(AppConfiguracion.ValorSeccion("idturno")),
                        IdFormaPago = 1,
                        Valor = Convert.ToInt32(Efectivo),
                        Pago = Convert.ToInt32(Efectivo)
                    });
                }
                if (Cheque <= (Total - Efectivo))
                {
                    if (Cheque != 0)
                    {
                        Formas.Add(new DTO.Clases.FormaPago
                        {
                            IdEgreso = Convert.ToInt32(AppConfiguracion.ValorSeccion("idturno")),
                            IdFormaPago = 2,
                            Valor = Convert.ToInt32(Cheque),
                            Pago = Convert.ToInt32(Cheque)
                        });
                    }
                    if (Tarjeta <= (Total - (Efectivo + Cheque)))
                    {
                        if (Tarjeta != 0)
                        {
                            Formas.Add(new DTO.Clases.FormaPago
                            {
                                IdEgreso = Convert.ToInt32(AppConfiguracion.ValorSeccion("idturno")),
                                IdFormaPago = 3,
                                Valor = Convert.ToInt32(Tarjeta),
                                Pago = Convert.ToInt32(Tarjeta)
                            });
                        }
                    }
                    else
                    {
                        Formas.Add(new DTO.Clases.FormaPago
                        {
                            IdEgreso = Convert.ToInt32(AppConfiguracion.ValorSeccion("idturno")),
                            IdFormaPago = 3,
                            Valor = Convert.ToInt32(Total - (Efectivo + Cheque)),
                            Pago = Convert.ToInt32(Tarjeta)
                        });
                    }
                }
                else
                {
                    Formas.Add(new DTO.Clases.FormaPago
                    {
                        IdEgreso = Convert.ToInt32(AppConfiguracion.ValorSeccion("idturno")),
                        IdFormaPago = 2,
                        Valor = Convert.ToInt32(Total - Efectivo),
                        Pago = Convert.ToInt32(Cheque)
                    });
                }
            }
            else
            {
                Formas.Add(new DTO.Clases.FormaPago
                {
                    IdEgreso = Convert.ToInt32(AppConfiguracion.ValorSeccion("idturno")),
                    IdFormaPago = 1,
                    Valor = Convert.ToInt32(Total),
                    Pago = Convert.ToInt32(Efectivo)
                });
            }
            return Formas;

            /*var efe = UseObject.RemoveSeparatorMil(txtEfectivo.Text);
            var che = UseObject.RemoveSeparatorMil(txtCheque.Text);
            var tar = UseObject.RemoveSeparatorMil(txtTarjeta.Text);
            var Formas = new List<DTO.Clases.FormaPago>();
            if (efe > 0 &&
                che.Equals(0) &&
                tar.Equals(0))
            {
                //solo efectivo
                Formas.Add(new DTO.Clases.FormaPago
                {
                    IdEgreso = Convert.ToInt32(AppConfiguracion.ValorSeccion("idturno")),
                    IdFormaPago = 1,
                    Valor = Convert.ToInt32
                    (UseObject.RemoveSeparatorMil(txtEfectivo.Text))
                });
            }
            else
            {
                if (efe.Equals(0) &&
                    che > 0 &&
                    tar.Equals(0))
                {
                    //solo cheque
                    Formas.Add(new DTO.Clases.FormaPago
                    {
                        IdEgreso = Convert.ToInt32(AppConfiguracion.ValorSeccion("idturno")),
                        IdFormaPago = 2,
                        Valor = Convert.ToInt32
                        (UseObject.RemoveSeparatorMil(txtCheque.Text))
                    });
                }
                else
                {
                    if (efe.Equals(0) &&
                        che.Equals(0) &&
                        tar > 0)
                    {
                        //solo tarjeta
                        Formas.Add(new DTO.Clases.FormaPago
                        {
                            IdEgreso = Convert.ToInt32(AppConfiguracion.ValorSeccion("idturno")),
                            IdFormaPago = 3,
                            Valor = Convert.ToInt32
                            (UseObject.RemoveSeparatorMil(txtTarjeta.Text))
                        });
                    }
                    else
                    {
                        if (efe > 0 &&
                            che > 0 &&
                            tar.Equals(0))
                        {
                            //efectivo y cheque
                            Formas.Add(new DTO.Clases.FormaPago
                            {
                                IdEgreso = Convert.ToInt32(AppConfiguracion.ValorSeccion("idturno")),
                                IdFormaPago = 1,
                                Valor = Convert.ToInt32
                                (UseObject.RemoveSeparatorMil(txtEfectivo.Text))
                            });
                            Formas.Add(new DTO.Clases.FormaPago
                            {
                                IdEgreso = Convert.ToInt32(AppConfiguracion.ValorSeccion("idturno")),
                                IdFormaPago = 2,
                                Valor = Convert.ToInt32
                                (UseObject.RemoveSeparatorMil(txtCheque.Text))
                            });
                        }
                        else
                        {
                            if (efe > 0 &&
                                che.Equals(0) &&
                                tar > 0)
                            {
                                //efectivo y tarjeta
                                Formas.Add(new DTO.Clases.FormaPago
                                {
                                    IdEgreso = Convert.ToInt32(AppConfiguracion.ValorSeccion("idturno")),
                                    IdFormaPago = 1,
                                    Valor = Convert.ToInt32
                                    (UseObject.RemoveSeparatorMil(txtEfectivo.Text))
                                });
                                Formas.Add(new DTO.Clases.FormaPago
                                {
                                    IdEgreso = Convert.ToInt32(AppConfiguracion.ValorSeccion("idturno")),
                                    IdFormaPago = 3,
                                    Valor = Convert.ToInt32
                                    (UseObject.RemoveSeparatorMil(txtTarjeta.Text))
                                });
                            }
                            else
                            {
                                //cheque y tarjeta
                                Formas.Add(new DTO.Clases.FormaPago
                                {
                                    IdEgreso = Convert.ToInt32(AppConfiguracion.ValorSeccion("idturno")),
                                    IdFormaPago = 2,
                                    Valor = Convert.ToInt32
                                    (UseObject.RemoveSeparatorMil(txtCheque.Text))
                                });
                                Formas.Add(new DTO.Clases.FormaPago
                                {
                                    IdEgreso = Convert.ToInt32(AppConfiguracion.ValorSeccion("idturno")),
                                    IdFormaPago = 3,
                                    Valor = Convert.ToInt32
                                    (UseObject.RemoveSeparatorMil(txtTarjeta.Text))
                                });
                            }
                        }
                    }
                }
            }*/
            
            /*Formas.Add(new DTO.Clases.FormaPago
            {
                IdFormaPago = 1,
                Valor = Convert.ToInt32
                (UseObject.RemoveSeparatorMil(txtEfectivo.Text))
            });
            Formas.Add(new DTO.Clases.FormaPago
            {
                IdFormaPago = 2,
                Valor = Convert.ToInt32
                (UseObject.RemoveSeparatorMil(txtCheque.Text))
            });
            Formas.Add(new DTO.Clases.FormaPago
            {
                IdFormaPago = 3,
                Valor = Convert.ToInt32
                (UseObject.RemoveSeparatorMil(txtTarjeta.Text))
            });*/
            //return Formas;
        }
    }
}