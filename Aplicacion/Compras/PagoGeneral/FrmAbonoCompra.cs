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

namespace Aplicacion.Compras.PagoGeneral
{
    public partial class FrmAbonoCompra : Form
    {
        public string NitProveedor { set; get; }

        public int CodigoProveedor { set; get; }

        public bool EsFactura { set; get; }

        public bool EsAbonoGeneral = false;

        private int CuentaPuc;

        public int IdFactura { set; get; }

        public string NumeroFactura { set; get; }

        public RetencionConcepto Retencion { set; get; }

        private ErrorProvider miError;

        private BussinesFormaPago miBussinesPago;

        private BussinesEgreso miBussinesEgreso;

        private BussinesBeneficio miBussinesBeneficio;

        private BussinesConsecutivo miBussinesConsecutivo;

        private BussinesAnticipo miBussinesAnticipo;

        private Validacion validacion;

        private bool AbonoMatch = false;

        private bool EfectivoMatch = false;

        private bool ChequeMatch = false;

        private bool TarjetaMatch = false;

        private bool TransacionMatch = false;

        private bool AnticipoMatch = false;

        public FrmAbonoCompra()
        {
            InitializeComponent();
            miError = new ErrorProvider();
            EsFactura = true;
            miBussinesPago = new BussinesFormaPago();
            miBussinesEgreso = new BussinesEgreso();
            miBussinesBeneficio = new BussinesBeneficio();
            miBussinesConsecutivo = new BussinesConsecutivo();
            miBussinesAnticipo = new BussinesAnticipo();
            validacion = new Validacion();
            //CuentaPuc = Convert.ToInt32(AppConfiguracion.ValorSeccion("abonocomprafac"));
        }

        private void FrmAbonoCompra_Load(object sender, EventArgs e)
        {
            CargarUtilidades();
            txtNit.Text = NitProveedor;
        }

        private void FrmAbonoCompra_FormClosing(object sender, FormClosingEventArgs e)
        {
            CompletaEventos.CapturaEvento(false);
        }

        private void FrmAbonoCompra_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.F6)
            {
                try
                {
                    Validar();
                    if (AbonoMatch && EfectivoMatch && TransacionMatch && AnticipoMatch)
                    {
                        if (!txtAbono.Text.Equals("0"))
                        {
                            if (UseObject.RemoveSeparatorMil(txtSaldo.Text) >= UseObject.RemoveSeparatorMil(txtAbono.Text))
                            {
                                var suma = UseObject.RemoveSeparatorMil(txtEfectivo.Text) +
                                           UseObject.RemoveSeparatorMil(txtTransaccion.Text) +
                                           UseObject.RemoveSeparatorMil(txtAnticipo.Text);
                                //var monto = Convert.ToInt32(UseObject.RemoveSeparatorMil(txtAbono.Text));
                                if (suma == UseObject.RemoveSeparatorMil(this.txtAbono.Text))
                                {
                                    DialogResult rta = MessageBox.Show("¿Está seguro(a) de querer realizar el abono?",
                                            "Realizar Abono", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                                    if (rta.Equals(DialogResult.Yes))
                                    {
                                        var miBussinesFactura = new BussinesFacturaProveedor();
                                        var miBussinesRetencion = new BussinesRetencion();
                                        var pago = new FormaPago();
                                        pago.IdFormaPago = 1;
                                        pago.Usuario.Id = Convert.ToInt32(AppConfiguracion.ValorSeccion("id_user"));
                                        pago.Caja.Id = Convert.ToInt32(AppConfiguracion.ValorSeccion("id_caja"));
                                        pago.Fecha = DateTime.Now;
                                        pago.Valor = Convert.ToInt32(UseObject.RemoveSeparatorMil(txtAbono.Text));
                                        var factura = miBussinesFactura.IngresarPagoGeneral(CodigoProveedor, pago, EsFactura);
                                        var facturas = miBussinesFactura.GetArrayFacturas();

                                        if (UseObject.RemoveSeparatorMil(this.txtAnticipo.Text) > 0)
                                        {
                                            var cruce = new CruceCuentaPagar();
                                            //cruce.IdCuentaPagar = idCuenta;
                                            cruce.Caja.Id = Convert.ToInt32(AppConfiguracion.ValorSeccion("id_caja"));
                                            cruce.Usuario.Id = Convert.ToInt32(AppConfiguracion.ValorSeccion("id_user"));
                                            cruce.Numero = miBussinesConsecutivo.Consecutivo("CruceCuentaPagar");
                                            cruce.Fecha = DateTime.Now;
                                            cruce.Concepto = "CRUCE CON ANTICIPO A FACTURA DE COMPRA No. " + NumeroFactura;
                                            cruce.Valor = UseObject.RemoveSeparatorMil(this.txtAnticipo.Text);
                                            cruce.Resta = Convert.ToInt32(UseObject.RemoveSeparatorMil(this.txtAnticipos.Text) - cruce.Valor);

                                            miBussinesAnticipo.IngresarCruceAnticipo(this.NitProveedor, cruce);
                                        }

                                        if (FormasDePago().Sum(s => s.Valor) > 0)
                                        {
                                            //TOCA GENERAR EL EGRESO
                                            var egreso = new DTO.Clases.Egreso();
                                            egreso.IdCaja = Convert.ToInt32(AppConfiguracion.ValorSeccion("id_caja"));
                                            egreso.IdUsuario = Convert.ToInt32(AppConfiguracion.ValorSeccion("id_user"));
                                            egreso.Numero = miBussinesConsecutivo.Consecutivo("Egreso");
                                            egreso.Fecha = DateTime.Now;
                                            var b = miBussinesBeneficio.BeneficiariosNit(NitProveedor);
                                            var bRow = b.Rows[0];
                                            egreso.TipoBeneficiario = Convert.ToInt32(bRow["id"]);

                                            egreso.Pagos = FormasDePago();
                                            egreso.Total = Convert.ToInt32(egreso.Pagos.Sum(s => s.Valor));
                                            egreso.Estado = true;

                                            egreso.Cuentas.Add(new ConceptoEgreso
                                            {
                                                IdCuenta = Convert.ToInt32(AppConfiguracion.ValorSeccion("ctaEgreso")),
                                                Nombre = "Abonos a Facturas de Proveedor Números: " + factura,
                                                Numero = egreso.Total.ToString()
                                            });
                                            egreso.Total = Convert.ToInt32(UseObject.RemoveSeparatorMil(txtAbono.Text));

                                            egreso.Id = miBussinesEgreso.IngresarEgreso(egreso);

                                            foreach (int id in miBussinesFactura.GetArrayIds())
                                            {
                                                miBussinesPago.IngresarEgresoPago(egreso.Id, id);
                                            }

                                            OptionPane.MessageInformation("El abono se realizó correctamente.");
                                            CompletaEventos.CapEventoAbonoEgreso(egreso);
                                            if (Convert.ToBoolean(AppConfiguracion.ValorSeccion("printEgreso")))
                                            {
                                                PrintEgresoPos(egreso);
                                            }
                                        }
                                        this.Close();
                                    }
                                }
                                else
                                {
                                    OptionPane.MessageInformation("Las formas de pago deben ser igual al abono.");
                                }
                            }
                            else
                            {
                                OptionPane.MessageInformation("El valor del abono debe ser menor o igual al Saldo del Proveddor.");
                            }
                        }
                        else
                        {
                            OptionPane.MessageInformation("El valor de abono debe ser una cantidad superior a cero.");
                        }
                    }
                }
                catch (Exception ex)
                {
                    OptionPane.MessageError(ex.Message);
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
                    miError.SetError(txtAbono, null);
                    txtAbono.Text = UseObject.InsertSeparatorMil(txtAbono.Text);
                    AbonoMatch = true;
                }
                else
                {
                    miError.SetError(txtAbono, "El valor que ingreso es incorrecto.");
                    AbonoMatch = false;
                }
            }
            else
            {
                txtAbono.Text = "0";
                AbonoMatch = true;
            }
        }

        private void txtEfectivo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar.Equals((char)Keys.Enter))
            {
                txtTransaccion.Focus();
            }
        }

        private void txtEfectivo_Validating(object sender, CancelEventArgs e)
        {
            if (!String.IsNullOrEmpty(txtEfectivo.Text))
            {
                txtEfectivo.Text = txtEfectivo.Text.Replace(".", "");
                if (validacion.ValidarNumeroInt(txtEfectivo.Text))
                {
                    miError.SetError(txtEfectivo, null);
                    txtEfectivo.Text = UseObject.InsertSeparatorMil(txtEfectivo.Text);
                    EfectivoMatch = true;
                }
                else
                {
                    miError.SetError(txtEfectivo, "El valor que ingreso es incorrecto.");
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
                    miError.SetError(txtCheque, null);
                    txtCheque.Text = UseObject.InsertSeparatorMil(txtCheque.Text);
                    ChequeMatch = true;
                }
                else
                {
                    miError.SetError(txtCheque, "El valor que ingreso es incorrecto.");
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
                this.txtAnticipo.Focus();
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
                    miError.SetError(txtTransaccion, "El valor que ingreso es incorrecto.");
                    TransacionMatch = false;
                }
            }
            else
            {
                txtTransaccion.Text = "0";
                TransacionMatch = true;
            }
        }

        private void txtAnticipo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar.Equals((char)Keys.Enter))
            {
                this.txtTransaccion_Validating(this.txtTransaccion, null);
                this.FrmAbonoCompra_KeyDown(this, new KeyEventArgs(Keys.F6));
            }
        }

        private void txtAnticipo_Validating(object sender, CancelEventArgs e)
        {
            if (!String.IsNullOrEmpty(txtAnticipo.Text))
            {
                txtAnticipo.Text = txtAnticipo.Text.Replace(".", "");
                if (validacion.ValidarNumeroInt(txtAnticipo.Text))
                {
                    miError.SetError(txtAnticipo, null);
                    txtAnticipo.Text = UseObject.InsertSeparatorMil(txtAnticipo.Text);
                    AnticipoMatch = true;
                }
                else
                {
                    miError.SetError(txtAnticipo, "El valor que ingreso es incorrecto.");
                    AnticipoMatch = false;
                }
            }
            else
            {
                txtAnticipo.Text = "0";
                AnticipoMatch = true;
            }
        }





        /*
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
        */

        /**
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
            }*/

        /*
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
        */
        /// <summary>
        /// Carga los datos necesarios para el uso del formulario.
        /// </summary>
        private void CargarUtilidades()
        {
            //lblNumeroFactura.Text = "Abono a Factura N° " + NumeroFactura;
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
            //cbRegistro.DataSource = lst;
            //cbRegistro.SelectedValue = 2;
        }

        /// <summary>
        /// Obtiene las formas de pago usadas en el Pago a Proveedor.
        /// </summary>
        /// <returns></returns>
        //private List<FormaPago> FormasDePago()
        //{
        //var Abono = UseObject.RemoveSeparatorMil(txtAbono.Text);
        // var Efectivo = UseObject.RemoveSeparatorMil(txtAbono.Text);
        /*var Cheque = UseObject.RemoveSeparatorMil(txtCheque.Text);
        var Tarjeta = UseObject.RemoveSeparatorMil(txtTarjeta.Text);
        var Transaccion = UseObject.RemoveSeparatorMil(txtTransaccion.Text);

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
        }*/

        // return null;
        // }

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

        private void Validar()
        {
            this.txtAbono_Validating(this.txtAbono, new CancelEventArgs(false));
            this.txtEfectivo_Validating(this.txtAbono, new CancelEventArgs(false));
            this.txtTransaccion_Validating(this.txtTransaccion, new CancelEventArgs(false));
            this.txtAnticipo_Validating(this.txtAnticipo, new CancelEventArgs(false));
            if (UseObject.RemoveSeparatorMil(this.txtAnticipo.Text) <= UseObject.RemoveSeparatorMil(this.txtAnticipos.Text))
            {
                this.miError.SetError(this.txtAnticipo, null);
                this.AnticipoMatch = true;
            }
            else
            {
                this.miError.SetError(this.txtAnticipo, "El valor a descontar no debe superar el saldo de anticipos.");
                this.AnticipoMatch = false;
            }
        }

        private List<FormaPago> FormasDePago()
        {
            var Abono = UseObject.RemoveSeparatorMil(txtAbono.Text);
            var Efectivo = UseObject.RemoveSeparatorMil(txtEfectivo.Text);
            var Cheque = UseObject.RemoveSeparatorMil(txtCheque.Text);
            var Tarjeta = 0;
            var Transaccion = UseObject.RemoveSeparatorMil(txtTransaccion.Text);

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

        private List<FormaPago> FormasDePagoYanticipo()
        {
            var Abono = UseObject.RemoveSeparatorMil(txtAbono.Text);
            var Efectivo = UseObject.RemoveSeparatorMil(txtEfectivo.Text);
            var Cheque = UseObject.RemoveSeparatorMil(txtCheque.Text);
            var Transaccion = UseObject.RemoveSeparatorMil(txtTransaccion.Text);
            var anticipo = UseObject.RemoveSeparatorMil(txtAnticipo.Text);

            var Formas = new List<DTO.Clases.FormaPago>();

            if (Efectivo != 0)
            {
                Formas.Add(new FormaPago
                {
                    IdFormaPago = 1,
                    Valor = Convert.ToInt32(Efectivo)
                });
            }
            if (Cheque != 0)
            {
                Formas.Add(new FormaPago
                {
                    IdFormaPago = 2,
                    Valor = Convert.ToInt32(Cheque)
                });
            }
            if (Transaccion != 0)
            {
                Formas.Add(new FormaPago
                {
                    IdFormaPago = 4,
                    Valor = Convert.ToInt32(Transaccion)
                });
            }
            if (anticipo != 0)
            {
                Formas.Add(new FormaPago
                {
                    IdFormaPago = 1,
                    Valor = Convert.ToInt32(anticipo)
                });
            }
            return Formas;
        }

        private void PrintEgresoPos(DTO.Clases.Egreso egreso)
        {
            try
            {
                DialogResult rta = MessageBox.Show("¿Desea imprimir el Comprobante de Egreso?", "Factura Proveedor",
                                   MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (rta.Equals(DialogResult.Yes))
                {
                    var miBussinesCaja = new BussinesCaja();
                    var miBussinesEmpresa = new BussinesEmpresa();
                    var miBussinesUsuario = new BussinesUsuario();
                    var miBussinesBeneficia = new BussinesBeneficio();

                    var empresaRow = miBussinesEmpresa.PrintEmpresa().
                                 Tables[0].AsEnumerable().First();
                    var caja = miBussinesCaja.CajaId(egreso.IdCaja);
                    var usuario = miBussinesUsuario.ConsultaUsuario(egreso.IdUsuario).AsEnumerable().First();
                    var beneficio = miBussinesBeneficia.BeneficiarioId(egreso.TipoBeneficiario);

                    Ticket ticket = new Ticket();
                    ticket.UseItem = false;

                    ticket.AddHeaderLine(empresaRow["Nombre"].ToString().ToUpper());
                    ticket.AddHeaderLine(empresaRow["Juridico"].ToString());
                    ticket.AddHeaderLine("NIT " + UseObject.InsertSeparatorMilMasDigito(empresaRow["Nit"].ToString()));
                    ticket.AddHeaderLine(empresaRow["Direccion"].ToString());
                    ticket.AddHeaderLine("Tels. " + empresaRow["Telefono"].ToString());
                    ticket.AddHeaderLine("Fecha : " + egreso.Fecha.ToShortDateString() +
                                     "    Caja : " + caja.Numero.ToString());
                    ticket.AddHeaderLine("Cajero(a)  :  " + usuario["nombre"].ToString());
                    ticket.AddHeaderLine("===================================");
                    ticket.AddHeaderLine("COMPROBANTE DE EGRESO Nro " + egreso.Numero);
                    ticket.AddHeaderLine("===================================");
                    ticket.AddHeaderLine("Remite a : " + beneficio.NombresCliente.ToUpper());
                    ticket.AddHeaderLine("NIT: " + UseObject.InsertSeparatorMilMasDigito(beneficio.NitCliente));
                    ticket.AddHeaderLine("===================================");
                    ticket.AddHeaderLine("");
                    ticket.AddHeaderLine("      CONCEPTO               VALOR ");
                    ticket.AddHeaderLine("");
                    int maxCharacters_18 = 18;
                    int maxCharacters_15 = 15;
                    string valor = "";
                    List<string> datos = new List<string>();
                    foreach (var cuenta in egreso.Cuentas)
                    {
                        valor = UseObject.InsertSeparatorMil(cuenta.Numero);
                        datos = UseObject.StringBuilderDataIzquierda(cuenta.Nombre, maxCharacters_18);
                        for (int i = 0; i < datos.Count; i++)
                        {
                            if (i == datos.Count - 1)
                            {
                                ticket.AddHeaderLine(datos[i] + UseObject.FuncionEspacio(maxCharacters_18 - datos[i].Length) + "  " +
                                    UseObject.FuncionEspacio(maxCharacters_15 - valor.Length) + valor);
                            }
                            else
                            {
                                ticket.AddHeaderLine(datos[i]);
                            }
                        }
                    }
                    ticket.AddHeaderLine("");
                    ticket.AddHeaderLine("===================================");
                    ticket.AddHeaderLine("");
                    /*foreach (var cuenta in egreso.Cuentas)
                    {
                        ticket.AddItem("",
                                       cuenta.Nombre,
                                       UseObject.InsertSeparatorMil(cuenta.Numero));
                    }*/

                    var sTotal = 0;
                    var retencion = 0;
                    var qConcepto = egreso.Cuentas.Where(d => d.IdCuenta != 0);
                    var qRetenciones = egreso.Cuentas.Where(d => d.IdCuenta.Equals(0));
                    if (qConcepto.ToArray().Length != 0)
                    {
                        sTotal = qConcepto.Sum(d => Convert.ToInt32(d.Numero));
                    }
                    if (qRetenciones.ToArray().Length != 0)
                    {
                        retencion = qRetenciones.Sum(d => Convert.ToInt32(d.Numero));
                    }
                    ticket.AddHeaderLine("         SUBTOTAL :" + UseObject.StringBuilderDetalleTotal(
                        UseObject.InsertSeparatorMil(sTotal.ToString())));
                    ticket.AddHeaderLine("      RETENCIONES :" + UseObject.StringBuilderDetalleTotal(
                        UseObject.InsertSeparatorMil(retencion.ToString())));
                    ticket.AddHeaderLine("            TOTAL :" + UseObject.StringBuilderDetalleTotal(
                        UseObject.InsertSeparatorMil((sTotal + retencion).ToString())));
                    ticket.AddHeaderLine("");
                    /*ticket.AddTotal("SUBTOTAL     : ", UseObject.InsertSeparatorMil(sTotal.ToString()));
                    ticket.AddTotal("RETENCIONES  : ", UseObject.InsertSeparatorMil(retencion.ToString()));
                    ticket.AddTotal("TOTAL        : ", UseObject.InsertSeparatorMil((sTotal + retencion).ToString()));
                    ticket.AddTotal("", "");
                    ticket.AddTotal("", "");

                    ticket.AddTotal("FORMAS DE PAGO", "");
                    ticket.AddTotal("", "");*/
                    var pEfectivo = egreso.Pagos.Where(d => d.IdFormaPago.Equals(1));
                    var pCheque = egreso.Pagos.Where(d => d.IdFormaPago.Equals(2));
                    var pTransaccion = egreso.Pagos.Where(d => d.IdFormaPago.Equals(4));
                    if (pEfectivo.ToArray().Length != 0)
                    {
                        //ticket.AddTotal("EFECTIVO  : ", UseObject.InsertSeparatorMil(pEfectivo.Sum(d => d.Valor).ToString()));
                        ticket.AddHeaderLine("         EFECTIVO :" + UseObject.StringBuilderDetalleTotal(
                        UseObject.InsertSeparatorMil(pEfectivo.Sum(d => d.Valor).ToString())));
                    }
                    if (pCheque.ToArray().Length != 0)
                    {
                        //ticket.AddTotal("CHEQUE    : ", UseObject.InsertSeparatorMil(pCheque.Sum(d => d.Valor).ToString()));
                        ticket.AddHeaderLine("           CHEQUE :" + UseObject.StringBuilderDetalleTotal(
                        UseObject.InsertSeparatorMil(pCheque.Sum(d => d.Valor).ToString())));
                    }
                    if (pTransaccion.ToArray().Length != 0)
                    {
                        //ticket.AddTotal("TRANSACCIÓN :", UseObject.InsertSeparatorMil(pTransaccion.Sum(d => d.Valor).ToString()));
                        ticket.AddHeaderLine("      TRANSACCIÓN :" + UseObject.StringBuilderDetalleTotal(
                        UseObject.InsertSeparatorMil(pTransaccion.Sum(d => d.Valor).ToString())));
                    }
                    ticket.AddHeaderLine("");
                    ticket.AddHeaderLine("===================================");
                    ticket.AddHeaderLine("");
                    ticket.AddHeaderLine("");
                    ticket.AddHeaderLine("___________________________________");
                    ticket.AddHeaderLine("Aprobado:");
                    ticket.AddHeaderLine("");
                    ticket.AddHeaderLine("___________________________________");
                    ticket.AddHeaderLine("Beneficiario");
                    ticket.AddHeaderLine("");
                    ticket.AddHeaderLine("");

                    ticket.AddHeaderLine("Software: Digital Fact Pyme");
                    //ticket.AddFooterLine("Soluciones Tecnológicas A&C.");
                    //ticket.AddFooterLine("Cel. 3128068807");
                    ticket.AddHeaderLine("");

                    ticket.PrintTicket("IMPREPOS");
                    //ticket.PrintTicket("Microsoft XPS Document Writer");
                }
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
        }

        

    }
}