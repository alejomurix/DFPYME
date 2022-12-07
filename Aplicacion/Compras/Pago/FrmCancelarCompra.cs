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

namespace Aplicacion.Compras.Pago
{
    public partial class FrmCancelarCompra : Form
    {
        public string NitProveedor { set; get; }

        public bool EsFactura { set; get; }

        public bool DocEquivalente { set; get; }

        private int CuentaPuc;

        private BussinesFormaPago miBussinesPago;

        private BussinesEgreso miBussinesEgreso;

        private BussinesBeneficio miBussinesBeneficio;

        private BussinesConsecutivo miBussinesConsecutivo;

        public string IdFactura { set; get; }

        public string NumeroFactura { set; get; }

        public bool AplicaRetencion { set; get; }

        public RetencionConcepto Retencion { set; get; }

        private Validacion validacion;

        private bool EfectivoMatch = false;

        private bool ChequeMatch = false;

        private bool TarjetaMatch = false;

        private bool TransacionMatch = false;

        public FrmCancelarCompra()
        {
            InitializeComponent();
            DocEquivalente = false;
            miBussinesPago = new BussinesFormaPago();
            miBussinesEgreso = new BussinesEgreso();
            miBussinesBeneficio = new BussinesBeneficio();
            miBussinesConsecutivo = new BussinesConsecutivo();
            validacion = new Validacion();
            CuentaPuc = Convert.ToInt32(AppConfiguracion.ValorSeccion("comprafac"));
            AplicaRetencion = false;
            Retencion = new RetencionConcepto();
        }

        private void FrmCancelarCompra_Load(object sender, EventArgs e)
        {
            CargarUtilidades();
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
                        DialogResult rta = MessageBox.Show("¿Está seguro(a) de querer realizar el pago?",
                                    "Realizar Pago", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (rta == DialogResult.Yes)
                        {
                            try
                            {
                                var egreso = new DTO.Clases.Egreso();
                                egreso.IdCaja = Convert.ToInt32(AppConfiguracion.ValorSeccion("id_caja"));
                                egreso.IdUsuario = Convert.ToInt32(AppConfiguracion.ValorSeccion("id_user"));
                                egreso.Numero = miBussinesConsecutivo.Consecutivo("Egreso");//AppConfiguracion.ValorSeccion("numero-e");
                                egreso.Fecha = DateTime.Now;
                                var Total = 0;
                                if (AplicaRetencion)
                                {
                                    Total = Convert.ToInt32(UseObject.RemoveSeparatorMil(txtTotal.Text));
                                    egreso.Total = Total - Convert.ToInt32(Total * Retencion.Tarifa / 100);
                                }
                                else
                                {
                                    egreso.Total = Convert.ToInt32(UseObject.RemoveSeparatorMil(txtTotal.Text));
                                }
                                /*egreso.TipoBeneficiario = 1;
                                egreso.Beneficiario = NitProveedor;*/
                                var b = miBussinesBeneficio.BeneficiariosNit(NitProveedor);
                                var bRow = b.Rows[0];
                                egreso.TipoBeneficiario = Convert.ToInt32(bRow["id"]);
                                egreso.Estado = true;
                                var pagos = FormasDePago();
                                var efectivo = pagos.
                                    Where(p => p.IdFormaPago == 1 || p.IdFormaPago == 3 || p.IdFormaPago == 4).
                                    Sum(s => s.Valor);
                                efectivo = efectivo - Convert.ToInt32(Total * Retencion.Tarifa / 100);
                                egreso.Pagos.Add(new FormaPago
                                {
                                    IdFormaPago = 1,
                                    Valor = efectivo
                                });
                                egreso.Pagos.Add(new FormaPago
                                {
                                    IdFormaPago = 2,
                                    Valor = pagos.Where(p => p.IdFormaPago == 2).Sum(s => s.Valor)
                                });

                                var Concepto = "";
                                if (DocEquivalente)
                                {
                                    Concepto = "Pago a Documento Equivalente número ";
                                }
                                else
                                {
                                    Concepto = "Pago Factura Proveedor Número ";
                                }

                                if (AplicaRetencion)
                                {
                                    egreso.Cuentas.Add(new ConceptoEgreso
                                    {
                                        IdCuenta = CuentaPuc,
                                        Id = Convert.ToInt32(AppConfiguracion.ValorSeccion("ctacomprafac")),
                                        Nombre = Concepto + NumeroFactura,
                                        Numero = Total.ToString()
                                    });

                                    egreso.Cuentas.Add(new ConceptoEgreso
                                    {
                                        IdCuenta = CuentaPuc,
                                        Id = Convert.ToInt32(AppConfiguracion.ValorSeccion("ctacomprafac")),
                                        Nombre = Retencion.Concepto,
                                        Numero = ((Total * Retencion.Tarifa / 100) * -1).ToString()
                                    });
                                }
                                else
                                {
                                    egreso.Cuentas.Add(new ConceptoEgreso
                                    {
                                        IdCuenta = CuentaPuc,
                                        Id = Convert.ToInt32(AppConfiguracion.ValorSeccion("ctacomprafac")),
                                        Nombre = Concepto + NumeroFactura,
                                        Numero = egreso.Total.ToString()
                                    });
                                }

                                /*  try
                                  {*/
                                if (EsFactura)
                                {
                                    miBussinesEgreso.IngresarEgreso(egreso);
                                }
                                foreach (FormaPago pago in pagos)
                                {
                                    if (pago.Valor != 0)
                                    {
                                        pago.NumeroFactura = IdFactura;
                                        pago.Usuario.Id = Convert.ToInt32(AppConfiguracion.ValorSeccion("id_user"));
                                        pago.Caja.Id = Convert.ToInt32(AppConfiguracion.ValorSeccion("id_caja"));
                                        pago.Fecha = DateTime.Now;
                                        miBussinesPago.IngresaPagoAProveedor(pago, EsFactura);
                                    }
                                }
                                if (EsFactura)
                                {
                                    /* if (Convert.ToInt32(egreso.Numero) < 99)
                                     {
                                         AppConfiguracion.SaveConfiguration
                                             ("numero-e", IncrementaConsecutivo(egreso.Numero));
                                     }
                                     else
                                     {
                                         AppConfiguracion.SaveConfiguration
                                             ("numero-e", (Convert.ToInt32(egreso.Numero) + 1).ToString());
                                     }*/
                                }
                                /*AppConfiguracion.SaveConfiguration("numero-e",
                                            (Convert.ToInt32(AppConfiguracion.ValorSeccion("numero-e")) + 1).ToString());*/
                                OptionPane.MessageInformation("Los datos del pago a la Factura se guardarón correctamente.");
                                CompletaEventos.CapturaEvento(egreso);
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
                        OptionPane.MessageInformation("La suma de las cantidades deben ser igual al valor total de la Factura.");
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
            /*
            if (e.KeyData == Keys.F6)
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
                        DialogResult rta = MessageBox.Show("¿Está seguro(a) de querer realizar el pago?",
                                    "Realizar Pago", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (rta == DialogResult.Yes)
                        {
                            var formas = FormasDePago();
                            try
                            {
                                var egreso = new DTO.Clases.Egreso();
                                egreso.Numero = AppConfiguracion.ValorSeccion("const-e") +
                                                AppConfiguracion.ValorSeccion("numero-e");
                                if (!String.IsNullOrEmpty(AppConfiguracion.ValorSeccion("id_base")))
                                {
                                    egreso.IdBaseCaja = Convert.ToInt32(AppConfiguracion.ValorSeccion("id_base"));
                                    egreso.Concepto = "Pago Factura Proveedor Número " + NumeroFactura;
                                    if ((int)cbRegistro.SelectedValue == 1)
                                    {
                                        egreso.Registradora = true;
                                    }
                                    else
                                    {
                                        egreso.Registradora = false;
                                    }
                                    egreso.Hora = DateTime.Now;

                                    foreach (FormaPago pago in formas)
                                    {
                                        if (pago.Valor != 0)
                                        {
                                            pago.NumeroFactura = IdFactura;
                                            pago.Usuario.Id = Convert.ToInt32(AppConfiguracion.ValorSeccion("id_user"));
                                            pago.Caja.Id = Convert.ToInt32(AppConfiguracion.ValorSeccion("id_caja"));
                                            pago.Fecha = DateTime.Now;
                                            miBussinesPago.IngresaPagoAProveedor(pago);

                                            if (pago.IdFormaPago != 4)
                                            {
                                                egreso.IdPago = pago.IdFormaPago;
                                                egreso.Valor = pago.Valor;
                                                miBussinesEgreso.IngresarEgreso(egreso);
                                            }
                                        }
                                    }
                                    AppConfiguracion.SaveConfiguration("numero-e",
                                            (Convert.ToInt32(AppConfiguracion.ValorSeccion("numero-e")) + 1).ToString());
                                    OptionPane.MessageInformation("El pago se realizó correctamente.");
                                    CompletaEventos.CapturaEvento(10);
                                    this.Close();
                                }
                                else
                                {
                                    OptionPane.MessageInformation("No ha ingresado apertura de caja.");
                                }
                            }
                            catch (Exception ex)
                            {
                                OptionPane.MessageError(ex.Message);
                            }
                        }
                    }
                    else
                    {
                        OptionPane.MessageInformation("La suma de las cantidades deben ser igual al valor total de la Factura.");
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
            */
        }

        private void FrmCancelarCompra_FormClosing(object sender, FormClosingEventArgs e)
        {
            CompletaEventos.CapturaEvento(false);
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
        /// Carga los datos necesarios para el uso del formulario.
        /// </summary>
        private void CargarUtilidades()
        {
            //lblNumeroFactura.Text = "Pago a Factura N° " + NumeroFactura;
            var lst = new List<Inventario.Producto.Criterio>();
            lst.Add(new Inventario.Producto.Criterio
            {
                Id = 1,
                Nombre = "Caja Registradora"
            });
            lst.Add(new Inventario.Producto.Criterio
            {
                Id = 2,
                Nombre = "Caja General"
            });
            /*cbRegistro.DataSource = lst;
            cbRegistro.SelectedValue = 2;*/
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

        public string IncrementaConsecutivo(string numero)
        {
            var num = "";
            if (Convert.ToInt32(numero) >= 10)
            {
                num += "0" + (Convert.ToInt32(numero) + 1).ToString();
            }
            else
            {
                num += "00" + (Convert.ToInt32(numero) + 1).ToString();
            }
            return num;
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