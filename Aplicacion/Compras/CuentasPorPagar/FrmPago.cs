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

namespace Aplicacion.Compras.CuentasPorPagar
{
    public partial class FrmPago : Form
    {
        private ErrorProvider miError;

        Validacion validacion;

        private bool AbonoMatch;

        private bool EfectivoMatch;

        private bool TransaccionMatch;

        private bool AnticipoMatch;

        private bool PrestamoMatch;

        public FrmPago()
        {
            InitializeComponent();
            miError = new ErrorProvider();
            validacion = new Validacion();
            this.AbonoMatch = false;
            this.EfectivoMatch = false;
            this.TransaccionMatch = false;
            this.AnticipoMatch = false;
            this.PrestamoMatch = false;
        }

        private void FrmCancelarVenta_Load(object sender, EventArgs e)
        {
            
        }

        private void FrmCancelarVenta_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData.Equals(Keys.F6))
            {
                this.txtAbono_Validating(this.txtAbono, new CancelEventArgs(false));
                this.txtEfectivo_Validating(this.txtEfectivo, new CancelEventArgs(false));
                this.txtTransaccion_Validating(this.txtTransaccion, new CancelEventArgs(false));
                this.txtAnticipo_Validating(this.txtAnticipo, new CancelEventArgs(false));
                this.txtPrestamo_Validating(this.txtPrestamo, new CancelEventArgs(false));

                if (this.AbonoMatch && this.EfectivoMatch && this.TransaccionMatch 
                    && this.AnticipoMatch && this.PrestamoMatch)
                {
                    var suma = UseObject.RemoveSeparatorMil(txtEfectivo.Text) +
                               UseObject.RemoveSeparatorMil(txtTransaccion.Text) +
                               UseObject.RemoveSeparatorMil(txtAnticipo.Text) +
                               UseObject.RemoveSeparatorMil(txtPrestamo.Text);
                    if (suma >= UseObject.RemoveSeparatorMil(txtAbono.Text))
                    {
                        if (!UseObject.RemoveSeparatorMil(txtAbono.Text).Equals(0))
                        {
                            miError.SetError(txtAbono, null);
                            miError.SetError(txtEfectivo, null);
                            miError.SetError(txtTransaccion, null);
                            miError.SetError(txtAnticipo, null);
                            miError.SetError(txtPrestamo, null);
                            DialogResult rta = MessageBox.Show("¿Está seguro(a) de realizar el pago?",
                                        "Cuentas por Pagar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                            if (rta == DialogResult.Yes)
                            {
                                var formas = FormasDePago();
                                var objeto = new ObjectAbstract();
                                objeto.Id = 255;
                                objeto.Objeto = formas;
                                CompletaEventos.CapturaEvento(objeto);
                                this.Close();
                            }
                        }
                        else
                        {
                            OptionPane.MessageInformation("El valor del abono debe ser superior a cero.");
                            miError.SetError(txtAbono, "El valor del abono debe ser superior a cero.");
                            this.txtAbono.Focus();
                        }
                    }
                    else
                    {
                        OptionPane.MessageInformation("La suma de los pagos no debe ser menor al Total.");
                        miError.SetError(txtEfectivo, "La suma de los pagos no debe ser menor al Total.");
                        miError.SetError(txtTransaccion, "La suma de los pagos no debe ser menor al Total.");
                        miError.SetError(txtAnticipo, "La suma de los pagos no debe ser menor al Total.");
                        miError.SetError(txtPrestamo, "La suma de los pagos no debe ser menor al Total.");
                        this.txtEfectivo.Focus();
                    }
                }
            }
        }

        private void FrmCancelarVenta_FormClosing(object sender, FormClosingEventArgs e)
        {
            //CompletaEventos.CapturaEvento(false);
        }

        private void txtAbono_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar.Equals((char)Keys.Enter))
            {
                this.txtEfectivo.Focus();
            }
        }

        private void txtAbono_Validating(object sender, CancelEventArgs e)
        {
            if (!String.IsNullOrEmpty(txtAbono.Text))
            {
                txtAbono.Text = txtAbono.Text.Replace(".", "");
                if (validacion.ValidarNumeroInt(txtAbono.Text))
                {
                    if (UseObject.RemoveSeparatorMil(txtAbono.Text) <=
                        UseObject.RemoveSeparatorMil(txtTotal.Text))
                    {
                        this.txtAbono.Text = UseObject.InsertSeparatorMil(this.txtAbono.Text);
                        miError.SetError(txtAbono, null);
                        this.AbonoMatch = true;
                    }
                    else
                    {
                        miError.SetError(txtAbono, "El valor del Abono no debe superior al Total.");
                        this.AbonoMatch = false;
                        this.txtAbono.Focus();
                    }
                }
                else
                {
                    miError.SetError(txtAbono, "El valor en Abono es incorrecto.");
                    this.AbonoMatch = false;
                    this.txtAbono.Focus();
                }
            }
            else
            {
                miError.SetError(txtAbono, "El valor de Abono es requerido");
                this.AbonoMatch = false;
                this.txtAbono.Focus();
            }
        }

        private void txtEfectivo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar.Equals((char)Keys.Enter))
            {
                this.txtTransaccion.Focus();
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
                    miError.SetError(txtEfectivo, null);
                    if (!txtEfectivo.Text.Equals("0"))
                    {
                        txtCambio.Text = UseObject.InsertSeparatorMil
                                (
                                    (UseObject.RemoveSeparatorMil(txtEfectivo.Text) -
                                        UseObject.RemoveSeparatorMil(txtAbono.Text))
                                        .ToString()
                                );
                    }
                }
                else
                {
                    OptionPane.MessageError("El valor en Efectivo es incorrecto.");
                    miError.SetError(txtEfectivo, "El valor en Efectivo es incorrecto.");
                    EfectivoMatch = false;
                }
            }
            else
            {
                txtEfectivo.Text = "0";
                EfectivoMatch = true;
            }
        }

        private void txtTransaccion_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar.Equals((char)Keys.Enter))
            {
                txtAnticipo.Focus();
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
                    TransaccionMatch = true;
                    miError.SetError(txtTransaccion, null);
                    if (!txtTransaccion.Text.Equals("0"))
                    {
                        txtCambio.Text = UseObject.InsertSeparatorMil
                                (
                                    ((UseObject.RemoveSeparatorMil(txtEfectivo.Text) +
                                        UseObject.RemoveSeparatorMil(txtTransaccion.Text)) -
                                        UseObject.RemoveSeparatorMil(txtAbono.Text))
                                        .ToString()
                                );
                    }
                }
                else
                {
                    OptionPane.MessageError("El valor en Transacción es incorrecto.");
                    miError.SetError(txtTransaccion, "El valor en Transacción es incorrecto.");
                    TransaccionMatch = false;
                }
            }
            else
            {
                txtTransaccion.Text = "0";
                TransaccionMatch = true;
            }
        }

        private void txtAnticipo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar.Equals((char)Keys.Enter))
            {
                txtPrestamo.Focus();
            }
        }

        private void txtAnticipo_Validating(object sender, CancelEventArgs e)
        {
            if (!String.IsNullOrEmpty(txtAnticipo.Text))
            {
                txtAnticipo.Text = txtAnticipo.Text.Replace(".", "");
                if (validacion.ValidarNumeroInt(txtAnticipo.Text))
                {
                    if (!txtAnticipo.Text.Equals("0"))
                    {
                        if (UseObject.RemoveSeparatorMil(txtAnticipos.Text) >=
                            UseObject.RemoveSeparatorMil(txtAnticipo.Text))
                        {
                            txtAnticipo.Text = UseObject.InsertSeparatorMil(txtAnticipo.Text);
                            miError.SetError(txtAnticipo, null);
                            AnticipoMatch = true;
                            if (!txtAnticipo.Text.Equals("0"))
                            {
                                txtCambio.Text = UseObject.InsertSeparatorMil
                                        (
                                            ((UseObject.RemoveSeparatorMil(txtEfectivo.Text) +
                                                UseObject.RemoveSeparatorMil(txtTransaccion.Text) +
                                                UseObject.RemoveSeparatorMil(txtAnticipo.Text)) -
                                                UseObject.RemoveSeparatorMil(txtAbono.Text))
                                                .ToString()
                                        );
                            }
                        }
                        else
                        {
                            AnticipoMatch = false;
                            OptionPane.MessageInformation("El pago del Adelanto no puede superar el Adelanto del Cliente.");
                            miError.SetError(txtAnticipo, "El pago del Adelanto no puede superar el Adelanto del Cliente.");
                            txtAnticipo.Focus();
                        }
                    }
                    else
                    {
                        AnticipoMatch = true;
                    }
                }
                else
                {
                    OptionPane.MessageError("El valor del Adelanto es incorrecto.");
                    miError.SetError(txtAnticipo, "El valor del Adelanto es incorrecto.");
                    AnticipoMatch = false;
                }
            }
            else
            {
                txtAnticipo.Text = "0";
                AnticipoMatch = true;
            }
        }

        private void txtPrestamo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar.Equals((char)Keys.Enter))
            {
                FrmCancelarVenta_KeyDown(this, new KeyEventArgs(Keys.F6));
            }
        }

        private void txtPrestamo_Validating(object sender, CancelEventArgs e)
        {
            if (!String.IsNullOrEmpty(txtPrestamo.Text))
            {
                txtPrestamo.Text = txtPrestamo.Text.Replace(".", "");
                if (validacion.ValidarNumeroInt(txtPrestamo.Text))
                {
                    if (!txtPrestamo.Text.Equals("0"))
                    {
                        if (UseObject.RemoveSeparatorMil(txtPrestamos.Text) >=
                            UseObject.RemoveSeparatorMil(txtPrestamo.Text))
                        {
                            txtPrestamo.Text = UseObject.InsertSeparatorMil(txtPrestamo.Text);
                            miError.SetError(txtPrestamo, null);
                            PrestamoMatch = true;
                            if (!txtPrestamo.Text.Equals("0"))
                            {
                                txtCambio.Text = UseObject.InsertSeparatorMil
                                        (
                                            ((UseObject.RemoveSeparatorMil(txtEfectivo.Text) +
                                                UseObject.RemoveSeparatorMil(txtTransaccion.Text) +
                                                UseObject.RemoveSeparatorMil(txtAnticipo.Text) +
                                                UseObject.RemoveSeparatorMil(txtPrestamo.Text)) -
                                                UseObject.RemoveSeparatorMil(txtAbono.Text))
                                                .ToString()
                                        );
                            }
                        }
                        else
                        {
                            PrestamoMatch = false;
                            OptionPane.MessageInformation("El valor en Prestamo no puede ser superior al del Tercero.");
                            miError.SetError(txtPrestamo, "El valor en Prestamo no puede ser superior al del Tercero.");
                            txtPrestamo.Focus();
                        }
                    }
                    else
                    {
                        PrestamoMatch = true;
                    }
                }
                else
                {
                    OptionPane.MessageError("El valor en Prestamo es incorrecto.");
                    miError.SetError(txtPrestamo, "El valor en Prestamo es incorrecto.");
                    PrestamoMatch = false;
                }
            }
            else
            {
                txtPrestamo.Text = "0";
                PrestamoMatch = true;
            }
        }

        private List<DTO.Clases.FormaPago> FormasDePago()
        {
            var Total = UseObject.RemoveSeparatorMil(txtAbono.Text);
            var Efectivo = UseObject.RemoveSeparatorMil(txtEfectivo.Text);
            var Transaccion = UseObject.RemoveSeparatorMil(txtTransaccion.Text);
            var anticipo = UseObject.RemoveSeparatorMil(txtAnticipo.Text);
            var prestamo = UseObject.RemoveSeparatorMil(txtPrestamo.Text);

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
                if (Transaccion <= (Total - Efectivo))
                {
                    if (Transaccion != 0)
                    {
                        Formas.Add(new DTO.Clases.FormaPago
                        {
                            IdFormaPago = 4,
                            Valor = Convert.ToInt32(Transaccion)
                        });
                    }
                    //
                    if (anticipo <= (Total - (Efectivo + Transaccion)))
                    {
                        if (anticipo != 0)
                        {
                            Formas.Add(new DTO.Clases.FormaPago
                            {
                                Id = 1,
                                Valor = Convert.ToInt32(anticipo)
                            });
                        }
                        if (prestamo <= (Total - (Efectivo + Transaccion + anticipo)))
                        {
                            if (prestamo != 0)
                            {
                                Formas.Add(new DTO.Clases.FormaPago
                                {
                                    Id = 2,
                                    Valor = Convert.ToInt32(prestamo)
                                });
                            }
                        }
                        else
                        {
                            Formas.Add(new DTO.Clases.FormaPago
                            {
                                Id = 2,
                                Valor = Convert.ToInt32(Total)
                            });
                        }
                    }
                    else
                    {
                        Formas.Add(new DTO.Clases.FormaPago
                        {
                            Id = 1,
                            Valor = Convert.ToInt32(Total)
                        });
                    }
                }
                else
                {
                    Formas.Add(new DTO.Clases.FormaPago
                    {
                        IdFormaPago = 4,
                        Valor = Convert.ToInt32(Total)
                    });
                }
            }
            else
            {
                Formas.Add(new DTO.Clases.FormaPago
                {
                    IdFormaPago = 1,
                    Valor = Convert.ToInt32(Total)
                });
            }
            return Formas;
        }
    }
}