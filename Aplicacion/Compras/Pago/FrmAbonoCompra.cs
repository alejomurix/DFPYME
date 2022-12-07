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
using Microsoft.Reporting.WinForms;

namespace Aplicacion.Compras.Pago
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

        private BussinesFacturaProveedor miBussinesFactura;

        private BussinesFormaPago miBussinesPago;

        private BussinesEgreso miBussinesEgreso;

        private BussinesBeneficio miBussinesBeneficio;

        private BussinesConsecutivo miBussinesConsecutivo;

        private BussinesAnticipo miBussinesAnticipo;

        private BussinesDevolucion miBussinesDevolucion;

        private Validacion validacion;

        private ErrorProvider miError;

        private bool AbonoMatch = false;

        private bool EfectivoMatch = false;

        private bool ChequeMatch = false;

        private bool TarjetaMatch = false;

        private bool TransacionMatch = false;

        private bool AnticipoMatch = false;

        private bool DevolucionMatch = false;

        private bool DescuentoMatch = false;

        private bool AplicaRete;

        public FrmAbonoCompra()
        {
            InitializeComponent();
            EsFactura = true;
            AplicaRete = false;
            miBussinesPago = new BussinesFormaPago();
            miBussinesEgreso = new BussinesEgreso();
            miBussinesBeneficio = new BussinesBeneficio();
            miBussinesFactura = new BussinesFacturaProveedor();
            miBussinesConsecutivo = new BussinesConsecutivo();
            miBussinesAnticipo = new BussinesAnticipo();
            miBussinesDevolucion = new BussinesDevolucion();
            validacion = new Validacion();
            miError = new ErrorProvider();
            //CuentaPuc = Convert.ToInt32(AppConfiguracion.ValorSeccion("abonocomprafac"));
        }

        private void FrmAbonoCompra_Load(object sender, EventArgs e)
        {
            CargarUtilidades();
        }

        private void FrmAbonoCompra_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.F6)
            {
                Validar();
                if (!txtAbono.Text.Equals("0"))
                {
                    if (AbonoMatch && EfectivoMatch && ChequeMatch && TarjetaMatch &&
                        TransacionMatch && AnticipoMatch && DevolucionMatch && DescuentoMatch)
                    {
                        var suma = UseObject.RemoveSeparatorMil(txtEfectivo.Text) +
                                   UseObject.RemoveSeparatorMil(txtCheque.Text) +
                                   UseObject.RemoveSeparatorMil(txtTarjeta.Text) +
                                   UseObject.RemoveSeparatorMil(txtTransaccion.Text) +
                                   UseObject.RemoveSeparatorMil(txtAnticipo.Text) +
                                   UseObject.RemoveSeparatorMil(txtDevolucion.Text) +
                                   UseObject.RemoveSeparatorMil(txtDescuento.Text);
                        if (!UseObject.RemoveSeparatorMil(txtAbono.Text).Equals(0))
                        {
                            if (suma == UseObject.RemoveSeparatorMil(txtAbono.Text))
                            {
                                DialogResult rta = MessageBox.Show("¿Está seguro(a) de querer realizar el abono?",
                                        "Realizar Abono", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                                if (rta.Equals(DialogResult.Yes))
                                {
                                    try
                                    {
                                        var b = miBussinesBeneficio.BeneficiariosNit(NitProveedor);
                                        if (b.Rows.Count != 0)
                                        {
                                            var miBussinesRetencion = new BussinesRetencion();
                                            var tRete = miBussinesRetencion.RetencionesACompra(IdFactura);
                                            var tasaRete = 0.0;
                                            var conceptoRete = "";
                                            if (tRete.Rows.Count != 0)
                                            {
                                                tasaRete = Convert.ToDouble(tRete.AsEnumerable().Single()["tarifa"]);
                                                conceptoRete = tRete.AsEnumerable().Single()["concepto"].ToString();
                                                AplicaRete = true;
                                            }
                                            var egreso = new DTO.Clases.Egreso();
                                            //egreso.Estado = false;
                                            egreso.IdCaja = Convert.ToInt32(AppConfiguracion.ValorSeccion("id_caja"));
                                            egreso.IdUsuario = Convert.ToInt32(AppConfiguracion.ValorSeccion("id_user"));
                                            if (EsFactura)
                                            {
                                                egreso.Numero = miBussinesConsecutivo.Consecutivo("Egreso");
                                            }
                                            else
                                            {
                                                egreso.Numero = miBussinesConsecutivo.Consecutivo("EgresoRemision");
                                            }
                                            egreso.Fecha = DateTime.Now;

                                            //validar por q el proveedor no existe como beneficiario
                                            var bRow = b.Rows[0];
                                            egreso.TipoBeneficiario = Convert.ToInt32(bRow["id"]);
                                            egreso.Beneficiario = bRow["nombre"].ToString();
                                            //var Total = 0;
                                            /*if (AplicaRete)
                                            {
                                                Total = Convert.ToInt32(UseObject.RemoveSeparatorMil(txtAbono.Text));
                                                egreso.Total = Total - Convert.ToInt32(Total * tasaRete / 100);
                                            }
                                            else
                                            {
                                                egreso.Total = Convert.ToInt32(UseObject.RemoveSeparatorMil(txtAbono.Text));
                                            }*/
                                            //egreso.Total = Convert.ToInt32(UseObject.RemoveSeparatorMil(txtAbono.Text));
                                            egreso.Estado = true;

                                            egreso.Pagos = FormasDePago();
                                            egreso.Total = Convert.ToInt32(egreso.Pagos.Sum(s => s.Valor));

                                            var concepto = "";
                                            if (EsFactura)
                                            {
                                                if (miBussinesFactura.EsFacturaVenta(IdFactura))
                                                {
                                                    concepto = "Pago Factura Proveedor Número ";
                                                }
                                                else
                                                {
                                                    concepto = "Pago a Documento Equivalente número ";
                                                }
                                            }
                                            else
                                            {
                                                concepto = "Pago Remisión Proveedor Número ";
                                            }
                                            /*if (AplicaRete)
                                            {
                                                egreso.Cuentas.Add(new ConceptoEgreso
                                                {
                                                    IdCuenta = Convert.ToInt32(AppConfiguracion.ValorSeccion("ctaEgreso")),
                                                    Nombre = concepto + NumeroFactura,
                                                    Numero = Total.ToString()
                                                });

                                                egreso.Cuentas.Add(new ConceptoEgreso
                                                {
                                                    IdCuenta = Convert.ToInt32(AppConfiguracion.ValorSeccion("ctaRetencion")),
                                                    Nombre = this.Retencion.Concepto,
                                                    Tarifa = this.Retencion.Tarifa,
                                                    Numero = Math.Round(((Total * tasaRete / 100) * -1), 0).ToString()
                                                });
                                            }
                                            else
                                            {
                                                egreso.Cuentas.Add(new ConceptoEgreso
                                                {
                                                    IdCuenta = Convert.ToInt32(AppConfiguracion.ValorSeccion("ctaEgreso")),
                                                    Nombre = concepto + NumeroFactura,
                                                    Numero = egreso.Total.ToString()
                                                });
                                            }*/
                                            egreso.Cuentas.Add(new ConceptoEgreso
                                            {
                                                IdCuenta = Convert.ToInt32(AppConfiguracion.ValorSeccion("ctaEgreso")),
                                                Nombre = concepto + NumeroFactura,
                                                Numero = egreso.Total.ToString()
                                            });
                                            if (egreso.Pagos.Sum(s => s.Valor) > 0)
                                            {
                                                if (EsFactura)
                                                {
                                                    egreso.Id = miBussinesEgreso.IngresarEgreso(egreso);
                                                }
                                                else
                                                {
                                                    miBussinesEgreso.IngresarEgresoRemision(egreso);
                                                }
                                            }
                                            else
                                            {
                                                egreso.Estado = false;
                                            }

                                            egreso.Pagos = FormasDePagoYanticipo();
                                            List<int> pagos = new List<int>();
                                            foreach (FormaPago pago in egreso.Pagos)
                                            {
                                                if (pago.Valor != 0)
                                                {
                                                    //lleno los datos del objeto pago:
                                                    pago.NumeroFactura = IdFactura.ToString();
                                                    pago.Usuario.Id = Convert.ToInt32(AppConfiguracion.ValorSeccion("id_user"));
                                                    pago.Caja.Id = Convert.ToInt32(AppConfiguracion.ValorSeccion("id_caja"));
                                                    pago.Fecha = DateTime.Now;

                                                    //Ingreso el respectivo pago
                                                    pago.Id = miBussinesPago.IngresaPagoAProveedor(pago, EsFactura);
                                                    pagos.Add(pago.Id);
                                                }
                                            }
                                            /*   foreach (int id in pagos)
                                               {
                                                   miBussinesPago.IngresarEgresoPago(egreso.Id, id);
                                               }*/

                                            if (UseObject.RemoveSeparatorMil(this.txtAnticipo.Text) > 0)
                                            {
                                                var cruce = new CruceCuentaPagar();
                                                //cruce.IdCuentaPagar = idCuenta;
                                                cruce.Caja.Id = egreso.IdCaja;
                                                cruce.Usuario.Id = egreso.IdUsuario;
                                                cruce.Numero = miBussinesConsecutivo.Consecutivo("CruceCuentaPagar");
                                                cruce.Fecha = DateTime.Now;
                                                cruce.Concepto = "CRUCE CON ANTICIPO A FACTURA DE COMPRA No. " + NumeroFactura;
                                                cruce.Valor = UseObject.RemoveSeparatorMil(this.txtAnticipo.Text);
                                                cruce.Resta = Convert.ToInt32(UseObject.RemoveSeparatorMil(this.txtAnticipos.Text) - cruce.Valor);

                                                miBussinesAnticipo.IngresarCruceAnticipo(this.NitProveedor, cruce);
                                            }
                                            if (UseObject.RemoveSeparatorMil(this.txtDevolucion.Text) > 0)
                                            {
                                                int saldoDev = this.miBussinesDevolucion.SaldoCompra(this.CodigoProveedor);
                                                this.miBussinesDevolucion.EditarSaldoCompra(this.CodigoProveedor,
                                                    (saldoDev - Convert.ToInt32(UseObject.RemoveSeparatorMil(this.txtDevolucion.Text))));
                                            }

                                            OptionPane.MessageInformation("El abono se realizó correctamente.");
                                            egreso.Pagos = FormasDePago();
                                            if (egreso.Estado)
                                            {
                                                if (Convert.ToBoolean(AppConfiguracion.ValorSeccion("printEgreso")))
                                                {
                                                    //CompletaEventos.CapEventoAbonoEgreso(egreso);
                                                    PrintEgresoPos(egreso, EsFactura);
                                                }
                                                else
                                                {
                                                    //CompletaEventos.CapEventoAbonoEgreso(egreso);
                                                }
                                            }
                                            if (EsFactura)
                                            {
                                                CompletaEventos.CapEventoAbonoEgreso(egreso);
                                            }
                                            else
                                            {
                                                CompletaEventos.CapEvenAbonoRemision(egreso);
                                            }
                                            if (UseObject.RemoveSeparatorMil(this.txtAnticipo.Text) != 0 ||
                                                UseObject.RemoveSeparatorMil(this.txtDevolucion.Text) != 0 ||
                                                UseObject.RemoveSeparatorMil(this.txtDescuento.Text) != 0)
                                            {
                                                rta = MessageBox.Show("¿Desea imprimir el comprobante de cruce?", "Pago proveedor",
                                                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                                                if (rta.Equals(DialogResult.Yes))
                                                {
                                                    int valor = Convert.ToInt32(UseObject.RemoveSeparatorMil(this.txtAnticipo.Text) +
                                                                UseObject.RemoveSeparatorMil(this.txtDevolucion.Text) +
                                                                UseObject.RemoveSeparatorMil(this.txtDescuento.Text));
                                                    if (Convert.ToBoolean(AppConfiguracion.ValorSeccion("printCompDevolVenta")))
                                                    {
                                                        PrintComprobanteCrucePos
                                                        (egreso.IdCaja, egreso.IdUsuario, egreso.TipoBeneficiario, egreso.Fecha, NumeroFactura, valor, FormasDePagoYanticipo());
                                                    }
                                                    else
                                                    {
                                                        PrintComprobanteCruce
                                                        (egreso.Fecha, NitProveedor, egreso.Beneficiario, NumeroFactura, valor, FormasDePagoYanticipo());
                                                    }
                                                }
                                            }
                                        }
                                        else
                                        {
                                            OptionPane.MessageInformation("El proveedor no esta relacionado como tercero.");
                                        }

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
                                OptionPane.MessageInformation("La suma de las cantidades deben ser igual al valor del abono.");
                                txtEfectivo.Focus();
                            }
                        }
                        else
                        {
                            OptionPane.MessageInformation("El valor del abono debe ser superior a cero.");
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

        private void txtAnticipo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar.Equals((char)Keys.Enter))
            {
                this.txtDevolucion.Focus();
            }
        }

        private void txtAnticipo_Validating(object sender, CancelEventArgs e)
        {
            if (!String.IsNullOrEmpty(txtAnticipo.Text))
            {
                txtAnticipo.Text = txtAnticipo.Text.Replace(".", "");
                if (validacion.ValidarNumeroInt(txtAnticipo.Text))
                {
                    txtAnticipo.Text = UseObject.InsertSeparatorMil(txtAnticipo.Text);
                    AnticipoMatch = true;
                }
                else
                {
                    OptionPane.MessageError("El valor del anticipo es inválido.");
                    AnticipoMatch = false;
                }
            }
            else
            {
                txtAnticipo.Text = "0";
                AnticipoMatch = true;
            }
        }


        private void txtDevolucion_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar.Equals((char)Keys.Enter))
            {
                this.txtDescuento.Focus();
            }
        }

        private void txtDevolucion_Validating(object sender, CancelEventArgs e)
        {
            if (!String.IsNullOrEmpty(txtDevolucion.Text))
            {
                txtDevolucion.Text = txtDevolucion.Text.Replace(".", "");
                if (validacion.ValidarNumeroInt(txtDevolucion.Text))
                {
                    txtDevolucion.Text = UseObject.InsertSeparatorMil(txtDevolucion.Text);
                    miError.SetError(txtDevolucion, null);
                    DevolucionMatch = true;
                }
                else
                {
                    miError.SetError(txtDevolucion, "El valor es incorrecto.");
                    DevolucionMatch = false;
                }
            }
            else
            {
                txtDevolucion.Text = "0";
                miError.SetError(txtDevolucion, null);
                DevolucionMatch = true;
            }
        }

        private void txtDescuento_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar.Equals((char)Keys.Enter))
            {
                FrmAbonoCompra_KeyDown(this, new KeyEventArgs(Keys.F6));
            }
        }

        private void txtDescuento_Validating(object sender, CancelEventArgs e)
        {
            if (!String.IsNullOrEmpty(txtDescuento.Text))
            {
                txtDescuento.Text = txtDescuento.Text.Replace(".", "");
                if (validacion.ValidarNumeroInt(txtDescuento.Text))
                {
                    txtDescuento.Text = UseObject.InsertSeparatorMil(txtDescuento.Text);
                    miError.SetError(txtDescuento, null);
                    DescuentoMatch = true;
                }
                else
                {
                    miError.SetError(txtDescuento, "El valor es incorrecto.");
                    DescuentoMatch = false;
                }
            }
            else
            {
                txtDescuento.Text = "0";
                miError.SetError(txtDescuento, null);
                DescuentoMatch = true;
            }
        }

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
        private List<FormaPago> FormasDePago()
        {
            var Abono = UseObject.RemoveSeparatorMil(txtAbono.Text);
            var Efectivo = UseObject.RemoveSeparatorMil(txtEfectivo.Text);
            var Cheque = UseObject.RemoveSeparatorMil(txtCheque.Text);
            var Tarjeta = UseObject.RemoveSeparatorMil(txtTarjeta.Text);
            var Transaccion = UseObject.RemoveSeparatorMil(txtTransaccion.Text);
            //var anticipo = UseObject.RemoveSeparatorMil(txtAnticipo.Text);

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
            /*  if (anticipo != 0)
              {
                  Formas.Add(new FormaPago
                  {
                      IdFormaPago = 1,
                      Valor = Convert.ToInt32(anticipo)
                  });
              }*/


            /*if (Efectivo <= Abono)
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

            return Formas;
        }

        private List<FormaPago> FormasDePagoYanticipo()
        {
            var Abono = UseObject.RemoveSeparatorMil(txtAbono.Text);
            var Efectivo = UseObject.RemoveSeparatorMil(txtEfectivo.Text);
            var Cheque = UseObject.RemoveSeparatorMil(txtCheque.Text);
            var Tarjeta = UseObject.RemoveSeparatorMil(txtTarjeta.Text);
            var Transaccion = UseObject.RemoveSeparatorMil(txtTransaccion.Text);
            var anticipo = UseObject.RemoveSeparatorMil(txtAnticipo.Text);
            var devolucion = UseObject.RemoveSeparatorMil(txtDevolucion.Text);
            var descuento = UseObject.RemoveSeparatorMil(txtDescuento.Text);

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
                    IdFormaPago = 5,
                    Valor = Convert.ToInt32(anticipo)
                });
            }
            if (devolucion != 0)
            {
                Formas.Add(new FormaPago
                {
                    IdFormaPago = 6,
                    Valor = Convert.ToInt32(devolucion)
                });
            }
            if (descuento != 0)
            {
                Formas.Add(new FormaPago
                {
                    IdFormaPago = 7,
                    Valor = Convert.ToInt32(descuento)
                });
            }


            /*if (Efectivo <= Abono)
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
            txtAbono_Validating(this.txtAbono, new CancelEventArgs(false));
            txtEfectivo_Validating(this.txtEfectivo, new CancelEventArgs(false));
            txtCheque_Validating(this.txtCheque, new CancelEventArgs(false));
            txtTarjeta_Validating(this.txtTarjeta, new CancelEventArgs(false));
            txtTransaccion_Validating(this.txtTransaccion, new CancelEventArgs(false));
            txtAnticipo_Validating(this.txtAnticipo, new CancelEventArgs(false));
            txtDevolucion_Validating(this.txtDevolucion, new CancelEventArgs(false));
            txtDescuento_Validating(this.txtDescuento, new CancelEventArgs(false));
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

            if (UseObject.RemoveSeparatorMil(this.txtDevolucion.Text) <= UseObject.RemoveSeparatorMil(this.txtSaldoDevolucion.Text))
            {
                this.miError.SetError(this.txtDevolucion, null);
                this.DevolucionMatch = true;
            }
            else
            {
                this.miError.SetError(this.txtDevolucion, "El valor a descontar no debe superar el saldo de anticipos.");
                this.DevolucionMatch = false;
            }
        }

        private void FrmAbonoCompra_FormClosing(object sender, FormClosingEventArgs e)
        {
            CompletaEventos.CapturaEvento(false);
        }

        private void PrintEgresoPos(DTO.Clases.Egreso egreso, bool factura)
        {
            try
            {
                DialogResult rta = MessageBox.Show("¿Desea imprimir el Comprobante de Egreso?", "Factura Proveedor",
                                   MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (rta.Equals(DialogResult.Yes))
                {
                    int MaxCharacters = 35;

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

                    foreach (var datos_ in UseObject.StringBuilderDataCenter(empresaRow["Nombre"].ToString().ToUpper(), MaxCharacters))
                    {
                        ticket.AddHeaderLine(datos_);
                    }
                    foreach (var datos_ in UseObject.StringBuilderDataCenter(empresaRow["Juridico"].ToString().ToUpper(), MaxCharacters))
                    {
                        ticket.AddHeaderLine(datos_);
                    }
                    //ticket.AddHeaderLine(empresaRow["Nombre"].ToString().ToUpper());
                    //ticket.AddHeaderLine(empresaRow["Juridico"].ToString());
                    ticket.AddHeaderLine("NIT " + UseObject.InsertSeparatorMilMasDigito(empresaRow["Nit"].ToString()));

                    foreach (var datos_ in UseObject.StringBuilderDataIzquierda(empresaRow["Direccion"].ToString().ToUpper(), MaxCharacters))
                    {
                        ticket.AddHeaderLine(datos_);
                    }
                    //ticket.AddHeaderLine(empresaRow["Direccion"].ToString());
                    ticket.AddHeaderLine("Tels. " + empresaRow["Telefono"].ToString());
                    ticket.AddHeaderLine("Fecha : " + egreso.Fecha.ToShortDateString() +
                                     "    Caja : " + caja.Numero.ToString());
                    ticket.AddHeaderLine("Cajero(a)  :  " + usuario["nombre"].ToString());
                    ticket.AddHeaderLine("===================================");
                    if (factura)
                    {
                        ticket.AddHeaderLine("COMPROBANTE DE EGRESO Nro " + egreso.Numero);
                    }
                    else
                    {
                        ticket.AddHeaderLine("COMPROBANTE EGRESO DE REMISIÓN Nro " + egreso.Numero);
                    }
                    ticket.AddHeaderLine("===================================");

                    foreach (var datos_ in UseObject.StringBuilderDataIzquierda("Remite a : " + beneficio.NombresCliente.ToUpper(), MaxCharacters))
                    {
                        ticket.AddHeaderLine(datos_);
                    }
                    //ticket.AddHeaderLine("Remite a : " + beneficio.NombresCliente.ToUpper());
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
                   /* ticket.AddTotal("SUBTOTAL     : ", UseObject.InsertSeparatorMil(sTotal.ToString()));
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

                    ticket.AddHeaderLine("Software: DFPYME");
                    //ticket.AddFooterLine("Soluciones Tecnológicas A&C.");
                    //ticket.AddFooterLine("Cel. 3128068807");
                    ticket.AddHeaderLine("");

                    ticket.PrintTicket("");
                    //ticket.PrintTicket("Microsoft XPS Document Writer");
                }
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
        }

        private void PrintComprobanteCrucePos
            (int idCaja, int idUser, int idBeneficiario, DateTime fecha, string numero, int valor, List<FormaPago> pagos)
        {
          //  DialogResult rta = MessageBox.Show("¿Desea imprimir el comprobante de cruce?", "Pago proveedor",
          //      MessageBoxButtons.YesNo, MessageBoxIcon.Question);
          //  if (rta.Equals(DialogResult.Yes))
           // {
            try
            {
                var miBussinesCaja = new BussinesCaja();
                var miBussinesEmpresa = new BussinesEmpresa();
                var miBussinesUsuario = new BussinesUsuario();
                var miBussinesBeneficia = new BussinesBeneficio();

                var empresaRow = miBussinesEmpresa.PrintEmpresa().
                             Tables[0].AsEnumerable().First();
                var caja = miBussinesCaja.CajaId(idCaja);
                var usuario = miBussinesUsuario.ConsultaUsuario(idUser).AsEnumerable().First();
                var beneficio = miBussinesBeneficia.BeneficiarioId(idBeneficiario);

                Ticket ticket = new Ticket();

                ticket.AddHeaderLine(empresaRow["Nombre"].ToString().ToUpper());
                ticket.AddHeaderLine(empresaRow["Juridico"].ToString());
                ticket.AddHeaderLine("NIT " + UseObject.InsertSeparatorMilMasDigito(empresaRow["Nit"].ToString()));
                ticket.AddHeaderLine(empresaRow["Direccion"].ToString());
                ticket.AddHeaderLine("Tels. " + empresaRow["Telefono"].ToString());
                ticket.AddHeaderLine("Fecha : " + fecha.ToShortDateString() +
                                 "    Caja : " + caja.Numero.ToString());
                ticket.AddHeaderLine("Cajero(a)  :  " + usuario["nombre"].ToString());
                ticket.AddHeaderLine("===================================");
                ticket.AddHeaderLine("COMPROBANTE CRUCE DE SALDO CON ");
                ticket.AddHeaderLine("PROVEEDOR");
                ticket.AddHeaderLine("===================================");
                ticket.AddHeaderLine("Remite a : " + beneficio.NombresCliente.ToUpper());
                ticket.AddHeaderLine("NIT: " + UseObject.InsertSeparatorMilMasDigito(beneficio.NitCliente));
                ticket.AddHeaderLine("===================================");
                ticket.AddHeaderLine("");
                ticket.AddHeaderLine("CRUCE DE SALDO CON FACTURA");
                ticket.AddHeaderLine("PROVEEDOR No " + numero);
                ticket.AddHeaderLine("");
                ticket.AddTotal("TOTAL        : ", UseObject.InsertSeparatorMil(valor.ToString()).ToString());
                ticket.AddTotal("", "");
                ticket.AddTotal("FORMAS DE PAGO", "");
                ticket.AddTotal("", "");
                var pAnticipo = pagos.Where(d => d.IdFormaPago.Equals(5));
                var pDevolucion = pagos.Where(d => d.IdFormaPago.Equals(6));
                var pDescuento = pagos.Where(d => d.IdFormaPago.Equals(7));

                if (pAnticipo.ToArray().Length != 0)
                {
                    ticket.AddTotal("ANTICIPO   : ", UseObject.InsertSeparatorMil(pAnticipo.Sum(d => d.Valor).ToString()));
                }
                if (pDevolucion.ToArray().Length != 0)
                {
                    ticket.AddTotal("DEVOLUCIÓN : ", UseObject.InsertSeparatorMil(pDevolucion.Sum(d => d.Valor).ToString()));
                }
                if (pDescuento.ToArray().Length != 0)
                {
                    ticket.AddTotal("DESCUENTO  :", UseObject.InsertSeparatorMil(pDescuento.Sum(d => d.Valor).ToString()));
                }
                ticket.AddFooterLine(".");
                ticket.AddFooterLine("===================================");
                ticket.AddFooterLine(".");
                ticket.AddFooterLine(".");
                ticket.AddFooterLine("___________________________________");
                ticket.AddFooterLine("FIRMA:");
                ticket.AddFooterLine(".");
                ticket.AddFooterLine(".");

                ticket.AddFooterLine("Software: Digital Fact Pyme");
                ticket.AddFooterLine("Soluciones Tecnológicas A&C.");
                //ticket.AddFooterLine("Cel. 3128068807");
                ticket.AddFooterLine(".");

                ticket.PrintTicket("IMPREPOS");
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
          //  }
        }

        private void PrintComprobanteCruce(DateTime fecha, string nit, string nombre, string numero, int valor, List<FormaPago> pagos)
        {
            try
            {
                FrmPrint frmPrint_ = new FrmPrint();
                DialogResult rta = frmPrint_.ShowDialog();

                if (!rta.Equals(DialogResult.Cancel))
                {
                    var miBussinesEmpresa = new BussinesEmpresa();
                    var dsEmpresa = miBussinesEmpresa.PrintEmpresa();

                    var frmPrint = new Devolucion.FrmPrintDevolucion();

                    frmPrint.RptvFactura.LocalReport.DataSources.Clear();
                    frmPrint.RptvFactura.LocalReport.Dispose();
                    frmPrint.RptvFactura.Reset();
                    
                    frmPrint.RptvFactura.LocalReport.DataSources.Add(
                        new ReportDataSource("DsEmpresa", dsEmpresa.Tables["Empresa"]));

                    frmPrint.RptvFactura.LocalReport.ReportPath = 
                    AppConfiguracion.ValorSeccion("report") + @"\reports\ComprobanteCrucePagoProveedor.rdlc";
                   // frmPrint.RptvFactura.LocalReport.ReportPath = 
 // @"C:\Users\alejoQ2009\Documents\Visual Studio 2010\Projects\Edicion\DFPYME\Aplicacion\Informes\ComprobanteCrucePagoProveedor.rdlc";

                    var pFecha = new ReportParameter();
                    pFecha.Name = "Fecha";
                    pFecha.Values.Add(fecha.ToShortDateString());
                    frmPrint.RptvFactura.LocalReport.SetParameters(pFecha);

                    var pRemite = new ReportParameter();
                    pRemite.Name = "Remite";
                    pRemite.Values.Add("C.C. o NIT " + nit + "  " + nombre);
                    frmPrint.RptvFactura.LocalReport.SetParameters(pRemite);

                    var pConcepto = new ReportParameter();
                    pConcepto.Name = "Concepto";
                    pConcepto.Values.Add("CRUCE DE SALDO CON FACTURA PROVEEDOR No " + numero);
                    frmPrint.RptvFactura.LocalReport.SetParameters(pConcepto);

                    var pValor = new ReportParameter();
                    pValor.Name = "Valor";
                    pValor.Values.Add(valor.ToString());
                    frmPrint.RptvFactura.LocalReport.SetParameters(pValor);

                    var pAnticipo = new ReportParameter();
                    pAnticipo.Name = "Anticipo";
                    pAnticipo.Values.Add(pagos.Where(p => p.IdFormaPago == 5).Sum(s => s.Valor).ToString());
                    frmPrint.RptvFactura.LocalReport.SetParameters(pAnticipo);

                    var pDevolucion = new ReportParameter();
                    pDevolucion.Name = "Devolucion";
                    pDevolucion.Values.Add(pagos.Where(p => p.IdFormaPago == 6).Sum(s => s.Valor).ToString());
                    frmPrint.RptvFactura.LocalReport.SetParameters(pDevolucion);

                    var pDescuento = new ReportParameter();
                    pDescuento.Name = "Descuento";
                    pDescuento.Values.Add(pagos.Where(p => p.IdFormaPago == 7).Sum(s => s.Valor).ToString());
                    frmPrint.RptvFactura.LocalReport.SetParameters(pDescuento);

                    frmPrint.RptvFactura.RefreshReport();

                    if (rta.Equals(DialogResult.No))
                    {
                        frmPrint.ShowDialog();
                    }
                    else
                    {
                        Imprimir print = new Imprimir();
                        print.Report = frmPrint.RptvFactura.LocalReport;
                        print.Print(Imprimir.TamanioPapel.MediaCarta);
                        frmPrint.RptvFactura.Reset();
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