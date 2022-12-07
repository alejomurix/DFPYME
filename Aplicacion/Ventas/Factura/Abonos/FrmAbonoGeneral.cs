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

namespace Aplicacion.Ventas.Factura.Abonos
{
    public partial class FrmAbonoGeneral : Form
    {
        public string NitCliente { set; get; }

        public int CodigoProveedor { set; get; }

        public bool EsFactura { set; get; }

        public bool EsAbonoGeneral = false;

        public List<FacturaVenta> Cartera { set; get; }

        private int CuentaPuc;

        public string IdFactura { set; get; }

        public string NumeroFactura { set; get; }

        public DataRow RowEmpresa { set; get; }

        private BussinesFormaPago miBussinesPago;

        private BussinesIngreso miBussinesIngreso;

        private BussinesEgreso miBussinesEgreso;

        private BussinesBeneficio miBussinesBeneficio;

        private BussinesConsecutivo miBussinesConsecutivo;

        private Validacion validacion;

        private bool AbonoMatch = false;

        private bool EfectivoMatch = false;

        //private bool ChequeMatch = false;

       // private bool TarjetaMatch = false;

        private bool TransacionMatch = false;

        public FrmAbonoGeneral()
        {
            InitializeComponent();
            EsFactura = true;
            miBussinesPago = new BussinesFormaPago();
            miBussinesIngreso = new BussinesIngreso();
            miBussinesEgreso = new BussinesEgreso();
            miBussinesBeneficio = new BussinesBeneficio();
            miBussinesConsecutivo = new BussinesConsecutivo();
            validacion = new Validacion();
            //CuentaPuc = Convert.ToInt32(AppConfiguracion.ValorSeccion("abonocomprafac"));
        }

        private void FrmAbonoCompra_Load(object sender, EventArgs e)
        {
            this.txtSaldo.Text = UseObject.InsertSeparatorMil(this.Cartera.Sum(s => s.Saldo).ToString());
            CargarUtilidades();
            txtNit.Text = NitCliente;
        }

        private void FrmAbonoCompra_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.F6)
            {
                try
                {
                    Validar();
                    if (!txtAbono.Text.Equals("0"))
                    {
                        if (AbonoMatch && EfectivoMatch && TransacionMatch)
                        {
                            if (UseObject.RemoveSeparatorMil(txtSaldo.Text) >= UseObject.RemoveSeparatorMil(txtAbono.Text))
                            {
                                if (UseObject.RemoveSeparatorMil(txtAbono.Text).Equals(
                                    (UseObject.RemoveSeparatorMil(txtEfectivo.Text) + UseObject.RemoveSeparatorMil(txtTransaccion.Text))))
                                {
                                    DialogResult rta = MessageBox.Show("¿Está seguro(a) de querer realizar el abono?",
                                            "Realizar Abono", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                                    if (rta.Equals(DialogResult.Yes))
                                    {
                                        //Genero el Ingreso:
                                        var ingreso = new Ingreso();
                                        ingreso.Numero = miBussinesConsecutivo.Consecutivo("Ingreso");//AppConfiguracion.ValorSeccion("ingreso");
                                        ingreso.NitCliente = this.NitCliente;
                                        ingreso.Concepto = "Abono a Facturas Número: ";
                                        //ingreso.Tipo = 2;
                                        ingreso.Fecha = DateTime.Now;
                                        ingreso.Estado = true;

                                        var miBussinesFactura = new BussinesFacturaVenta();
                                        var pago = new FormaPago();
                                        pago.IdEgreso = Convert.ToInt32(AppConfiguracion.ValorSeccion("idturno"));
                                        if (txtEfectivo.Text != "0")
                                        {
                                            pago.IdFormaPago = 1;
                                        }
                                        else
                                        {
                                            pago.IdFormaPago = 4;
                                        }
                                        ingreso.IdUsuario = pago.Usuario.Id = Convert.ToInt32(AppConfiguracion.ValorSeccion("id_user"));
                                        ingreso.IdCaja = pago.Caja.Id = Convert.ToInt32(AppConfiguracion.ValorSeccion("id_caja"));
                                        pago.Fecha = DateTime.Now;
                                        pago.Valor = Convert.ToInt32(UseObject.RemoveSeparatorMil(txtAbono.Text));

                                        //var factura = miBussinesFactura.IngresarPagoGeneral(NitCliente, pago, ingreso);
                                        miBussinesFactura.IngresarPagoGeneral(NitCliente, pago, ingreso, this.Cartera);
                                        pago.Valor = ingreso.Valor = Convert.ToInt32(UseObject.RemoveSeparatorMil(txtAbono.Text));
                                        pago.NombreFormaPago = ingreso.Concepto;

                                        ingreso.FormasPago = FormasDePago();
                                       /* ingreso.FormasPago.Add(new FormaPago
                                        {
                                            IdFormaPago = 1,
                                            Valor = ingreso.Valor
                                        });*/
                                        miBussinesIngreso.Ingresar(ingreso, false);
                                        OptionPane.MessageInformation("El abono se ingreso con exito.");
                                        /*rta = MessageBox.Show("¿Desea imprimir el comprobante de ingreso?", "Abono a Factura",
                                                        MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                                        if (rta.Equals(DialogResult.Yes))
                                        {*/

                                        if (Convert.ToBoolean(AppConfiguracion.ValorSeccion("printIngreso")))
                                        {
                                            CompletaEventos.CapEvenAbonoFact(ingreso.Numero);
                                            if (Convert.ToBoolean(AppConfiguracion.ValorSeccion("print_termal_80mm")))
                                            {
                                                PrintIngresoPos(ingreso.Numero);
                                            }
                                            else
                                            {
                                                PrintIngresoPos50mm(ingreso.Numero);
                                            }
                                            if (ingreso.FormasPago.Where(p => p.IdFormaPago.Equals(4)).Count() > 0)
                                            {
                                                PrintTicket pt = new PrintTicket();
                                                pt.UseItem = false;
                                                pt.empresaRow = this.RowEmpresa;
                                                pt.PrintPayments(new FacturaVenta
                                                {
                                                    FechaIngreso = ingreso.Fecha,
                                                    FormasDePago = ingreso.FormasPago
                                                });
                                            }
                                        }
                                        else
                                        {
                                            CompletaEventos.CapEvenAbonoFact(new List<FormaPago> { pago });
                                            PrintIngreso(ingreso.Numero);
                                        }
                                        //}
                                        if (EsFactura)
                                        {
                                            CompletaEventos.CapEvenAbonoFact(ingreso.Numero);
                                        }
                                        this.Close();

                                        /*var miBussinesFactura = new BussinesFacturaProveedor();
                                        var pago = new FormaPago();
                                        pago.IdFormaPago = 1;
                                        pago.Usuario.Id = Convert.ToInt32(AppConfiguracion.ValorSeccion("id_user"));
                                        pago.Caja.Id = Convert.ToInt32(AppConfiguracion.ValorSeccion("id_caja"));
                                        pago.Fecha = DateTime.Now;
                                        pago.Valor = Convert.ToInt32(UseObject.RemoveSeparatorMil(txtEfectivo.Text));
                                        var factura = miBussinesFactura.IngresarPagoGeneral(CodigoProveedor, pago, EsFactura);

                                        //TOCA GENERAR EL EGRESO
                                        var egreso = new DTO.Clases.Egreso();
                                        egreso.IdCaja = Convert.ToInt32(AppConfiguracion.ValorSeccion("id_caja"));
                                        egreso.IdUsuario = Convert.ToInt32(AppConfiguracion.ValorSeccion("id_user"));
                                        egreso.Numero = AppConfiguracion.ValorSeccion("numero-e");
                                        egreso.Fecha = DateTime.Now;
                                        var b = miBussinesBeneficio.BeneficiariosNit(NitCliente);
                                        var bRow = b.Rows[0];
                                        egreso.TipoBeneficiario = Convert.ToInt32(bRow["id"]);
                                        egreso.Pagos.Add(new FormaPago
                                        {
                                            IdFormaPago = 1,
                                            Valor = Convert.ToInt32(UseObject.RemoveSeparatorMil(txtEfectivo.Text))
                                        });
                                        egreso.Total = Convert.ToInt32(UseObject.RemoveSeparatorMil(txtEfectivo.Text));
                                        egreso.Estado = true;
                                        egreso.Cuentas.Add(new SubCuentaPuc
                                        {
                                            IdCuenta = CuentaPuc,
                                            Id = Convert.ToInt32(AppConfiguracion.ValorSeccion("ctaabonocomprafac")),
                                            Nombre = "Abonos a Facturas de Proveedor Números: " + factura,
                                            Numero = egreso.Total.ToString()
                                        });
                                        miBussinesEgreso.IngresarEgreso(egreso);
                                        if (Convert.ToInt32(egreso.Numero) < 99)
                                        {
                                            AppConfiguracion.SaveConfiguration
                                                ("numero-e", IncrementaConsecutivo(egreso.Numero));
                                        }
                                        else
                                        {
                                            AppConfiguracion.SaveConfiguration
                                                ("numero-e", (Convert.ToInt32(egreso.Numero) + 1).ToString());
                                        }
                                        OptionPane.MessageInformation("El abono se realizó correctamente.");
                                        CompletaEventos.CapEventoAbonoEgreso(egreso);
                                        this.Close();*/
                                    }
                                }
                                else
                                {
                                    OptionPane.MessageInformation("La suma de los pagos debe ser igual al abono.");
                                }
                            }
                            else
                            {
                                OptionPane.MessageInformation("El valor del abono debe ser menor o igual al saldo.");
                            }
                        }
                    }
                    else
                    {
                        OptionPane.MessageInformation("El valor de abono debe ser una cantidad superior a cero.");
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
            /*
            if (e.KeyData == Keys.F6)
            {
                Validar();
                if (/*!txtAbono.Text.Equals("0")/true)
                {
                    if (AbonoMatch && EfectivoMatch && ChequeMatch && TarjetaMatch && TransacionMatch)
                    {
                        var suma = UseObject.RemoveSeparatorMil(txtEfectivo.Text) /*+
                                   UseObject.RemoveSeparatorMil(txtCheque.Text) +
                                   UseObject.RemoveSeparatorMil(txtTarjeta.Text) +
                                   UseObject.RemoveSeparatorMil(txtTransaccion.Text);
                        if (/*suma == UseObject.RemoveSeparatorMil(txtAbono.Text)true)
                        {
                            DialogResult rta = MessageBox.Show("¿Está seguro(a) de querer realizar el abono?",
                                    "Realizar Abono", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                            if (rta.Equals(DialogResult.Yes))
                            {
                                if (!EsAbonoGeneral)
                                {
                                    var egreso = new DTO.Clases.Egreso();
                                    egreso.IdCaja = Convert.ToInt32(AppConfiguracion.ValorSeccion("id_caja"));
                                    egreso.IdUsuario = Convert.ToInt32(AppConfiguracion.ValorSeccion("id_user"));
                                    egreso.Numero = AppConfiguracion.ValorSeccion("numero-e");
                                    egreso.Fecha = DateTime.Now;
                                    egreso.TipoBeneficiario = 1;
                                    egreso.Beneficiario = NitProveedor;
                                    //egreso.Total = Convert.ToInt32(UseObject.RemoveSeparatorMil(txtAbono.Text));
                                    egreso.Estado = true;
                                    var pagos = FormasDePago();
                                    egreso.Pagos.Add(new FormaPago
                                    {
                                        IdFormaPago = 1,
                                        Valor = pagos.
                                        Where(p => p.IdFormaPago == 1 || p.IdFormaPago == 3 || p.IdFormaPago == 4).
                                        Sum(s => s.Valor)
                                    });
                                    egreso.Pagos.Add(new FormaPago
                                    {
                                        IdFormaPago = 2,
                                        Valor = pagos.Where(p => p.IdFormaPago == 2).Sum(s => s.Valor) //Single(p => p.IdFormaPago == 2).Valor
                                    });
                                    egreso.Cuentas.Add(new SubCuentaPuc
                                    {
                                        IdCuenta = CuentaPuc,
                                        Id = Convert.ToInt32(AppConfiguracion.ValorSeccion("ctaabonocomprafac")),
                                        Nombre = "Abono a Factura Proveedor Número " + NumeroFactura,
                                        Numero = egreso.Total.ToString()
                                    });
                                    try
                                    {
                                        miBussinesEgreso.IngresarEgreso(egreso);
                                        foreach (FormaPago pago in pagos)
                                        {
                                            if (pago.Valor != 0)
                                            {
                                                //lleno los datos del objeto pago:
                                                pago.NumeroFactura = IdFactura.ToString();
                                                pago.Usuario.Id = Convert.ToInt32(AppConfiguracion.ValorSeccion("id_user"));
                                                pago.Caja.Id = Convert.ToInt32(AppConfiguracion.ValorSeccion("id_caja"));
                                                pago.Fecha = DateTime.Now;

                                                //Ingreso el respectivo pago
                                                miBussinesPago.IngresaPagoAProveedor(pago, EsFactura);
                                            }
                                        }
                                        if (Convert.ToInt32(egreso.Numero) < 99)
                                        {
                                            AppConfiguracion.SaveConfiguration
                                                ("numero-e", IncrementaConsecutivo(egreso.Numero));
                                        }
                                        else
                                        {
                                            AppConfiguracion.SaveConfiguration
                                                ("numero-e", (Convert.ToInt32(egreso.Numero) + 1).ToString());
                                        }


                                        OptionPane.MessageInformation("El abono se realizó correctamente.");
                                        //var miEgreso = new IngresarCompra.MiEgreso();
                                        //miEgreso.Egreso = egreso.Numero;

                                        CompletaEventos.CapEventoAbonoEgreso(egreso);
                                        this.Close();
                                    }
                                    catch (Exception ex)
                                    {
                                        OptionPane.MessageError(ex.Message);
                                    }
                                }
                                else
                                {
                                    var miBussinesFactura = new BussinesFacturaProveedor();
                                    var pago = new FormaPago();
                                    pago.NumeroFactura = IdFactura.ToString();
                                    pago.Usuario.Id = Convert.ToInt32(AppConfiguracion.ValorSeccion("id_user"));
                                    pago.Caja.Id = Convert.ToInt32(AppConfiguracion.ValorSeccion("id_caja"));
                                    pago.Fecha = DateTime.Now;
                                    pago.Valor = FormasDePago().Sum(s => s.Valor);
                                    miBussinesFactura.IngresarPagoGeneral(CodigoProveedor, pago, EsFactura);
                                }
                            }
                        }
                        else
                        {
                            OptionPane.MessageInformation("La suma de las cantidades deben ser igual al valor del abono.");
                            txtEfectivo.Focus();
                        }
                    }
                }
                else
                {
                    OptionPane.MessageInformation("El valor de abono debe ser una cantidad superior a cero.");
                    //txtAbono.Focus();
                }
            }*/
            /*
            if (e.KeyData == Keys.F6)
            {
                Validar();
                if (!txtAbono.Text.Equals("0"))
                {
                    if (AbonoMatch && EfectivoMatch && ChequeMatch && TarjetaMatch && TransacionMatch)
                    {
                        var suma = UseObject.RemoveSeparatorMil(txtEfectivo.Text) +
                                       UseObject.RemoveSeparatorMil(txtCheque.Text) +
                                       UseObject.RemoveSeparatorMil(txtTarjeta.Text) +
                                       UseObject.RemoveSeparatorMil(txtTransaccion.Text);
                        if (suma == UseObject.RemoveSeparatorMil(txtAbono.Text))
                        {
                            DialogResult rta = MessageBox.Show("¿Está seguro(a) de querer realizar el abono?",
                                    "Realizar Abono", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                            if (rta.Equals(DialogResult.Yes))
                            {
                                var formas = FormasDePago();
                                try
                                {
                                    //creo el objeto egreso y asigno datos al mismo.
                                    var egreso = new DTO.Clases.Egreso();
                                    egreso.Numero = AppConfiguracion.ValorSeccion("const-e") +
                                                    AppConfiguracion.ValorSeccion("numero-e");
                                    if (!String.IsNullOrEmpty(AppConfiguracion.ValorSeccion("id_base")))
                                    {
                                        egreso.IdBaseCaja = Convert.ToInt32(AppConfiguracion.ValorSeccion("id_base"));
                                        egreso.Concepto = "Abono a Factura Proveedor Número " + NumeroFactura;
                                        if ((int)cbRegistro.SelectedValue == 1)
                                        {
                                            egreso.Registradora = true;
                                        }
                                        else
                                        {
                                            egreso.Registradora = false;
                                        }
                                        egreso.Hora = DateTime.Now;

                                        //recorro cada forma de pago para crear su objeto e igresarlo.
                                        foreach (FormaPago pago in formas)
                                        {
                                            if (pago.Valor != 0)
                                            {
                                                //lleno los datos del objeto pago:
                                                pago.NumeroFactura = IdFactura.ToString();
                                                pago.Usuario.Id = Convert.ToInt32(AppConfiguracion.ValorSeccion("id_user"));
                                                pago.Caja.Id = Convert.ToInt32(AppConfiguracion.ValorSeccion("id_caja"));
                                                pago.Fecha = DateTime.Now;

                                                //Ingreso el respectivo pago
                                                miBussinesPago.IngresaPagoAProveedor(pago);

                                                if (pago.IdFormaPago != 4)
                                                {
                                                    //Agrego otros datos de pago al egreso:
                                                    egreso.IdPago = pago.IdFormaPago;
                                                    egreso.Valor = pago.Valor;

                                                    //inserto el egreso en la base de datos:
                                                    miBussinesEgreso.IngresarEgreso(egreso);
                                                }
                                            }
                                        }
                                        AppConfiguracion.SaveConfiguration("numero-e",
                                            (Convert.ToInt32(AppConfiguracion.ValorSeccion("numero-e")) + 1).ToString());
                                        OptionPane.MessageInformation("El abono se realizó correctamente.");
                                        var miEgreso = new IngresarCompra.MiEgreso();
                                        miEgreso.Egreso = egreso.Numero;
                                        CompletaEventos.CapturaEvento(miEgreso);
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
                            OptionPane.MessageInformation("La suma de las cantidades deben ser igual al valor del abono.");
                            txtEfectivo.Focus();
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
            */
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
                    txtAbono.Text = UseObject.InsertSeparatorMil(txtAbono.Text);
                    AbonoMatch = true;
                }
                else
                {
                    OptionPane.MessageError("El valor del abono es inválido.");
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
                this.txtTransaccion.Focus();
                //FrmAbonoCompra_KeyDown(this, new KeyEventArgs(Keys.F6));
                //txtCheque.Focus();
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
                    OptionPane.MessageError("El valor del efectivo es inválido.");
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
                    OptionPane.MessageError("El valor de la transacción es inválido.");
                    TransacionMatch = false;
                }
            }
            else
            {
                txtTransaccion.Text = "0";
                TransacionMatch = true;
            }
        }

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
        private List<FormaPago> FormasDePago()
        {
            var Abono = UseObject.RemoveSeparatorMil(txtAbono.Text);
            var Efectivo = UseObject.RemoveSeparatorMil(txtEfectivo.Text);
            var Cheque = 0;
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
           // txtCheque_Validating(this.txtCheque, new CancelEventArgs(false));
            //txtTarjeta_Validating(this.txtTarjeta, new CancelEventArgs(false));
            txtTransaccion_Validating(this.txtTransaccion, new CancelEventArgs(false));
        }

        private void FrmAbonoCompra_FormClosing(object sender, FormClosingEventArgs e)
        {
            CompletaEventos.CapturaEvento(15);
        }

        private void PrintIngreso(string numero)
        {
            try
            {
                /*DialogResult rta = MessageBox.Show("¿Desea visualizar la impresión del comprobante de ingreso?", "Abono a Factura",
                    MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);*/
                FrmPrint frmPrint = new FrmPrint();
                frmPrint.StringCaption = "Abono a Factura";
                frmPrint.StringMessage = "Impresión del comprobante de ingreso";
                DialogResult rta = frmPrint.ShowDialog();

                if (!rta.Equals(DialogResult.Cancel))
                {
                    var miBussinesIngreso = new BussinesIngreso();
                    var miBussinesFactura = new BussinesFacturaVenta();
                    var miBussinesCliente = new BussinesCliente();
                    var miBussinesRemision = new BussinesRemision();

                    var ingresoRow = miBussinesIngreso.Ingresos(numero).AsEnumerable().First();
                    var tPagos = miBussinesIngreso.FormasPagoIngresoVenta(Convert.ToInt32(ingresoRow["id"]));
                    var cliente = miBussinesCliente.ClienteAEditar(ingresoRow["nitcliente"].ToString());

                    /*var tIngresos = miBussinesIngreso.IngresosMultiple(numero);
                    var tPagos = miBussinesIngreso.PagosIngreso(Convert.ToInt32(ingresoRow["tipo"]), tIngresos.Rows);

                    var queryFactura = from item in tPagos.AsEnumerable()
                                       group item by item["NoFactura"].ToString()
                                           into g
                                           select g;
                    DataRow clienteRow = null;
                    if (queryFactura.ToArray().Length != 0)
                    {
                        if (Convert.ToInt32(ingresoRow["tipo"]).Equals(2))
                        {
                            clienteRow = miBussinesFactura.ClienteDeFacutura(queryFactura.First().Key).AsEnumerable().First();
                        }
                        else
                        {
                            clienteRow = miBussinesRemision.ClienteDeRemsion(Convert.ToInt32(queryFactura.First().Key)).AsEnumerable().First();
                        }
                    }
                    var cliente = miBussinesCliente.ClienteAEditar(clienteRow["nitcliente"].ToString());*/

                    var printComprobante = new Cliente.FrmPrintAnticipo();
                    printComprobante.Numero = numero;
                    printComprobante.Fecha = Convert.ToDateTime(ingresoRow["fecha"]);
                    printComprobante.Cliente = cliente.NombresCliente;
                    printComprobante.Nit = cliente.NitCliente;
                    printComprobante.Direccion =
                        cliente.DireccionCliente + "  " + cliente.Ciudad + "  " + cliente.Departamento;
                    printComprobante.Concepto = ingresoRow["concepto"].ToString();
                    printComprobante.Valor = ingresoRow["valor"].ToString();
                    printComprobante.Efectivo = tPagos.AsEnumerable().Where(p => p.Field<int>("idforma_pago").
                                                Equals(1)).Sum(s => s.Field<int>("valor")).ToString();
                    printComprobante.Cheque = tPagos.AsEnumerable().Where(p => p.Field<int>("idforma_pago").
                                              Equals(2)).Sum(s => s.Field<int>("valor")).ToString();
                    printComprobante.Transaccion = tPagos.AsEnumerable().Where(p => p.Field<int>("idforma_pago").
                                              Equals(4)).Sum(s => s.Field<int>("valor")).ToString();

                    /*var efectivo = 0;
                    foreach (DataRow pRow in tPagos.Rows)
                    {
                        if (Convert.ToInt32(pRow["IdPago"]).Equals(1) || Convert.ToInt32(pRow["IdPago"]).Equals(3))
                        {
                            efectivo += Convert.ToInt32(pRow["Valor"]);
                        }
                    }
                    printComprobante.Efectivo = efectivo.ToString();
                    printComprobante.Cheque = tPagos.AsEnumerable().Where(t => t.Field<int>("IdPago").Equals(2)).
                                                                    Sum(s => s.Field<int>("Valor")).ToString();*/
                    // "Abono a Factura Número: " + numero;

                    if (rta.Equals(DialogResult.No))
                    {
                        printComprobante.ShowDialog();
                    }
                    else
                    {
                        Imprimir print = new Imprimir();
                        print.Report = printComprobante.CargarDatos();
                        print.Print(Imprimir.TamanioPapel.MediaCarta);
                        printComprobante.ResetReport();
                    }
                }
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
        }

        private void PrintIngresoPos(string numero)
        {
            try
            {
                DialogResult rta = MessageBox.Show("¿Desea imprimir el comprobante de ingreso?", "Abono a Factura",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (rta.Equals(DialogResult.Yes))
                {
                    var miBussinesEmpresa = new BussinesEmpresa();
                    var miBussinesUsuario = new BussinesUsuario();
                    var miBussinesFactura = new BussinesFacturaVenta();
                    var miBussinesIngreso = new BussinesIngreso();
                    var miBussinesCliente = new BussinesCliente();
                    var miBussinesCaja = new BussinesCaja();

                    var empresaRow = miBussinesEmpresa.PrintEmpresa().
                                     Tables[0].AsEnumerable().First();
                    var ingresoRow = miBussinesIngreso.Ingresos(numero).AsEnumerable().First();
                    var tPagos = miBussinesIngreso.FormasPagoIngresoVenta(Convert.ToInt32(ingresoRow["id"]));
                    var cliente = miBussinesCliente.ClienteAEditar(ingresoRow["nitcliente"].ToString());
                    var usuario = miBussinesUsuario.ConsultaUsuario(Convert.ToInt32(ingresoRow["idusuario"])).
                        AsEnumerable().First()["nombre"].ToString();
                    var caja = miBussinesCaja.CajaId(Convert.ToInt32(ingresoRow["idcaja"]));

                    /*var tIngresos = miBussinesIngreso.IngresosMultiple(numero);
                    var tPagos = miBussinesIngreso.PagosIngreso(Convert.ToInt32(ingresoRow["tipo"]), tIngresos.Rows);
                    var query = from item in tPagos.AsEnumerable()
                                group item by item["NoCaja"].ToString()
                                    into g
                                    select g;
                    var noCaja = "";
                    if (query.ToArray().Length != 0)
                    {
                        noCaja = query.First().Key;
                    }
                    var usuario = "";
                    var queryUser = from item in tPagos.AsEnumerable()
                                    group item by item["IdUser"].ToString()
                                        into g
                                        select g;
                    if (queryUser.ToArray().Length != 0)
                    {
                        usuario = queryUser.First().Key;
                    }
                    usuario = miBussinesUsuario.ConsultaUsuario(Convert.ToInt32(usuario)).
                                                AsEnumerable().First()["nombre"].ToString();
                    var queryFactura = from item in tPagos.AsEnumerable()
                                       group item by item["NoFactura"].ToString()
                                           into g
                                           select g;
                    DataRow clienteRow = null;
                    if (queryFactura.ToArray().Length != 0)
                    {
                        clienteRow = miBussinesFactura.ClienteDeFacutura(queryFactura.First().Key).AsEnumerable().First();
                    }*/

                    Ticket ticket = new Ticket();
                    ticket.UseItem = false;

                    ticket.AddHeaderLine(empresaRow["Nombre"].ToString().ToUpper());
                    ticket.AddHeaderLine(empresaRow["Juridico"].ToString());
                    ticket.AddHeaderLine("NIT " + UseObject.InsertSeparatorMilMasDigito(empresaRow["Nit"].ToString()));
                    ticket.AddHeaderLine(empresaRow["Direccion"].ToString());
                    ticket.AddHeaderLine("Tels. " + empresaRow["Telefono"].ToString());
                    ticket.AddHeaderLine("Fecha : " + Convert.ToDateTime(ingresoRow["fecha"]).ToShortDateString() +
                                         "    Caja : " + caja.Numero);
                    ticket.AddHeaderLine("Cajero(a)  :  " + usuario);
                    ticket.AddHeaderLine("===================================");
                    ticket.AddHeaderLine("COMPROBANTE DE INGRESO Nro " + numero);
                    ticket.AddHeaderLine("===================================");
                    ticket.AddHeaderLine("Recibido de : " + cliente.NombresCliente.ToUpper());
                    ticket.AddHeaderLine("NIT o C.C.  : " + UseObject.InsertSeparatorMilMasDigito(cliente.NitCliente));
                    ticket.AddHeaderLine("===================================");
                    ticket.AddHeaderLine("");
                    ticket.AddHeaderLine("      CONCEPTO               VALOR ");
                    ticket.AddHeaderLine("");
                    int maxCharacters_18 = 18;
                    int maxCharacters_15 = 15;
                    string valor = "";
                    List<string> datos = new List<string>();
                    datos = UseObject.StringBuilderDataIzquierda(ingresoRow["Concepto"].ToString(), maxCharacters_18);
                    valor = UseObject.InsertSeparatorMil(ingresoRow["Valor"].ToString());
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
                    ticket.AddHeaderLine("");
                    ticket.AddHeaderLine("===================================");
                    ticket.AddHeaderLine("");
                    ticket.AddHeaderLine("            TOTAL :" + UseObject.StringBuilderDetalleTotal(
                        UseObject.InsertSeparatorMil(ingresoRow["valor"].ToString())));
                    ticket.AddHeaderLine("");
                    string formaPago = "";

                    /*ticket.AddItem("",
                                   ingresoRow["concepto"].ToString(),
                                   UseObject.InsertSeparatorMil(ingresoRow["valor"].ToString()));

                    ticket.AddTotal("TOTAL ", UseObject.InsertSeparatorMil(ingresoRow["valor"].ToString()));

                    ticket.AddTotal(" ", " ");*/
                    foreach (DataRow pRow in tPagos.Rows)
                    {
                        formaPago = pRow["nombre"].ToString();
                        valor = UseObject.InsertSeparatorMil(pRow["valor"].ToString());
                        ticket.AddHeaderLine(UseObject.FuncionEspacio(17 - formaPago.Length) + formaPago + " :" +
                            UseObject.FuncionEspacio(16 - valor.Length) + valor);
                       /* ticket.AddTotal(pRow["nombre"].ToString(),
                               UseObject.InsertSeparatorMil(pRow["valor"].ToString()));*/
                    }
                    /*IEnumerable<IGrouping<string, DataRow>> queryPago = from item in tPagos.AsEnumerable()
                                                                        group item by item["FormaPago"].ToString()
                                                                            into g
                                                                            select g;
                    var tPagosGroup = PagosGroup(queryPago);
                    foreach (DataRow pRow in tPagosGroup.Rows)
                    {
                        ticket.AddTotal(pRow["FormaPago"].ToString(),
                                        UseObject.InsertSeparatorMil(pRow["Valor"].ToString()));
                        var t = pRow["FormaPago"].ToString() + " " +
                                        UseObject.InsertSeparatorMil(pRow["Valor"].ToString());
                    }*/

                    //Convert.ToInt32(UseObject.RemoveSeparatorMil(txtAbono.Text));
                   /* ticket.AddFooterLine("Saldo : $" + UseObject.InsertSeparatorMil(
                        miBussinesFactura.SaldoPorCliente(2, cliente.NitCliente).ToString()));*/

                    //var suma = this.Cartera.Sum(c => c.Saldo);// -Convert.ToInt32(UseObject.RemoveSeparatorMil(txtAbono.Text));
                    valor = UseObject.InsertSeparatorMil(this.Cartera.Sum(c => c.Saldo).ToString());
                    ticket.AddHeaderLine("");
                    ticket.AddHeaderLine("            SALDO :" + UseObject.FuncionEspacio(16 - valor.Length) + valor);
                    //ticket.AddHeaderLine("Saldo : $" + UseObject.RemoveSeparatorMil(this.Cartera.Sum(c => c.Saldo).ToString()).ToString());

                    ticket.AddHeaderLine("===================================");
                    ticket.AddHeaderLine("");
                    ticket.AddHeaderLine("");
                    ticket.AddHeaderLine("Firma:");
                    ticket.AddHeaderLine("-----------------------------------");
                    ticket.AddHeaderLine("C.C. o NIT:");
                    ticket.AddHeaderLine("-----------------------------------");
                    ticket.AddHeaderLine("Fecha:");
                    ticket.AddHeaderLine("-----------------------------------");
                    ticket.AddHeaderLine("");
                    ticket.AddHeaderLine("Software: DFPyme");
                    //ticket.AddFooterLine("Soluciones Tecnológicas A&C.");
                   // ticket.AddFooterLine("Cel. 3128068807");
                    ticket.AddHeaderLine("");

                    ticket.PrintTicket("IMPREPOS");
                    //ticket.PrintTicket("Microsoft XPS Document Writer");
                }
            }
            catch (Exception ex)
            {
                OptionPane.MessageError("Ocurrió un error al imprimir el comprobante.\n" + ex.Message);
            }
        }

        private void PrintIngresoPos50mm(string numero)
        {
            try
            {
                DialogResult rta = MessageBox.Show("¿Desea imprimir el comprobante de ingreso?", "Abono a Factura",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (rta.Equals(DialogResult.Yes))
                {
                    var miBussinesEmpresa = new BussinesEmpresa();
                    var miBussinesUsuario = new BussinesUsuario();
                    var miBussinesFactura = new BussinesFacturaVenta();
                    var miBussinesIngreso = new BussinesIngreso();
                    var miBussinesCliente = new BussinesCliente();
                    var miBussinesCaja = new BussinesCaja();

                    var empresaRow = miBussinesEmpresa.PrintEmpresa().
                                     Tables[0].AsEnumerable().First();
                    var ingresoRow = miBussinesIngreso.Ingresos(numero).AsEnumerable().First();
                    var tPagos = miBussinesIngreso.FormasPagoIngresoVenta(Convert.ToInt32(ingresoRow["id"]));
                    var cliente = miBussinesCliente.ClienteAEditar(ingresoRow["nitcliente"].ToString());
                    var usuario = miBussinesUsuario.ConsultaUsuario(Convert.ToInt32(ingresoRow["idusuario"])).
                        AsEnumerable().First()["nombre"].ToString();
                    var caja = miBussinesCaja.CajaId(Convert.ToInt32(ingresoRow["idcaja"]));


                    Ticket ticket = new Ticket();
                    ticket.UseItem = false;
                    ticket.Printer80mm = false;

                    ticket.AddHeaderLine(empresaRow["Nombre"].ToString().ToUpper());
                    ticket.AddHeaderLine(empresaRow["Juridico"].ToString().ToUpper());
                    ticket.AddHeaderLine(empresaRow["Nit"].ToString().ToUpper());
                    ticket.AddHeaderLine(empresaRow["direccion_"].ToString().ToUpper());
                    ticket.AddHeaderLine(empresaRow["ciudad"].ToString().ToUpper() + " " +
                        empresaRow["departamento"].ToString().ToUpper());
                    ticket.AddHeaderLine(empresaRow["celularempresa"].ToString().ToUpper());

                    ticket.AddHeaderLine("---------------------------");
                    ticket.AddHeaderLine("Rbo. Abono No. " + numero);
                    ticket.AddHeaderLine("Fecha: " + Convert.ToDateTime(ingresoRow["fecha"]).ToShortDateString());
                    ticket.AddHeaderLine("---------------------------");
                    if (cliente.NombresCliente.Length > 17)
                    {
                        cliente.NombresCliente = cliente.NombresCliente.Substring(0, 17);
                    }
                    ticket.AddHeaderLine(cliente.NombresCliente);
                    ticket.AddHeaderLine(cliente.NitCliente);
                    ticket.AddHeaderLine("---------------------------");


                    string valor = "";
                    List<string> datos = new List<string>();
                    datos = UseObject.StringBuilderDataIzquierda(ingresoRow["Concepto"].ToString(), 27);
                    valor = UseObject.InsertSeparatorMil(ingresoRow["Valor"].ToString());
                    for (int i = 0; i < datos.Count; i++)
                    {
                        ticket.AddHeaderLine(datos[i]);
                        /*if (i == datos.Count - 1)
                        {
                            ticket.AddHeaderLine(datos[i] + UseObject.FuncionEspacio(maxCharacters_18 - datos[i].Length) + "  " +
                                UseObject.FuncionEspacio(maxCharacters_15 - valor.Length) + valor);
                        }
                        else
                        {
                            ticket.AddHeaderLine(datos[i]);
                        }*/
                    }
                    ticket.AddHeaderLine("---------------------------");
                    ticket.AddHeaderLine("TOTAL: $       " + valor);
                    ticket.AddHeaderLine("---------------------------");
                    ticket.AddHeaderLine("EFECTIVO: $     " + UseObject.InsertSeparatorMil(tPagos.AsEnumerable().Sum(s => s.Field<int>("valor")).ToString()));
                    ticket.AddHeaderLine("---------------------------");
                    ticket.AddHeaderLine("SALDO: $        " + UseObject.RemoveSeparatorMil(this.Cartera.Sum(c => c.Saldo).ToString()));
                    ticket.AddHeaderLine("---------------------------");
                    ticket.AddHeaderLine("");
                    ticket.AddHeaderLine("");
                    ticket.AddHeaderLine("Atendido por: " + usuario.Substring(0, 13));
                    ticket.AddHeaderLine("");
                    ticket.PrintTicket("");






                    /*ticket.AddHeaderLine(empresaRow["Nombre"].ToString().ToUpper());
                    ticket.AddHeaderLine(empresaRow["Juridico"].ToString());
                    ticket.AddHeaderLine("NIT " + UseObject.InsertSeparatorMilMasDigito(empresaRow["Nit"].ToString()));
                    ticket.AddHeaderLine(empresaRow["Direccion"].ToString());
                    ticket.AddHeaderLine("Tels. " + empresaRow["Telefono"].ToString());
                    ticket.AddHeaderLine("Fecha : " + Convert.ToDateTime(ingresoRow["fecha"]).ToShortDateString() +
                                         "    Caja : " + caja.Numero);
                    ticket.AddHeaderLine("Cajero(a)  :  " + usuario);
                    ticket.AddHeaderLine("===================================");
                    ticket.AddHeaderLine("COMPROBANTE DE INGRESO Nro " + numero);
                    ticket.AddHeaderLine("===================================");
                    ticket.AddHeaderLine("Recibido de : " + cliente.NombresCliente.ToUpper());
                    ticket.AddHeaderLine("NIT o C.C.  : " + UseObject.InsertSeparatorMilMasDigito(cliente.NitCliente));
                    ticket.AddHeaderLine("===================================");
                    ticket.AddHeaderLine("");
                    ticket.AddHeaderLine("      CONCEPTO               VALOR ");
                    ticket.AddHeaderLine("");
                    int maxCharacters_18 = 18;
                    int maxCharacters_15 = 15;
                    string valor = "";
                    List<string> datos = new List<string>();
                    datos = UseObject.StringBuilderDataIzquierda(ingresoRow["Concepto"].ToString(), maxCharacters_18);
                    valor = UseObject.InsertSeparatorMil(ingresoRow["Valor"].ToString());
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
                    ticket.AddHeaderLine("");
                    ticket.AddHeaderLine("===================================");
                    ticket.AddHeaderLine("");
                    ticket.AddHeaderLine("            TOTAL :" + UseObject.StringBuilderDetalleTotal(
                        UseObject.InsertSeparatorMil(ingresoRow["valor"].ToString())));
                    ticket.AddHeaderLine("");
                    string formaPago = "";

                    foreach (DataRow pRow in tPagos.Rows)
                    {
                        formaPago = pRow["nombre"].ToString();
                        valor = UseObject.InsertSeparatorMil(pRow["valor"].ToString());
                        ticket.AddHeaderLine(UseObject.FuncionEspacio(17 - formaPago.Length) + formaPago + " :" +
                            UseObject.FuncionEspacio(16 - valor.Length) + valor);
                    }

                    //var suma = this.Cartera.Sum(c => c.Saldo);// -Convert.ToInt32(UseObject.RemoveSeparatorMil(txtAbono.Text));
                    valor = UseObject.InsertSeparatorMil(this.Cartera.Sum(c => c.Saldo).ToString());
                    ticket.AddHeaderLine("");
                    ticket.AddHeaderLine("            SALDO :" + UseObject.FuncionEspacio(16 - valor.Length) + valor);
                    //ticket.AddHeaderLine("Saldo : $" + UseObject.RemoveSeparatorMil(this.Cartera.Sum(c => c.Saldo).ToString()).ToString());

                    ticket.AddHeaderLine("===================================");
                    ticket.AddHeaderLine("");
                    ticket.AddHeaderLine("");
                    ticket.AddHeaderLine("Firma:");
                    ticket.AddHeaderLine("-----------------------------------");
                    ticket.AddHeaderLine("C.C. o NIT:");
                    ticket.AddHeaderLine("-----------------------------------");
                    ticket.AddHeaderLine("Fecha:");
                    ticket.AddHeaderLine("-----------------------------------");
                    ticket.AddHeaderLine("");
                    ticket.AddHeaderLine("Software: DFPyme");
                    //ticket.AddFooterLine("Soluciones Tecnológicas A&C.");
                    // ticket.AddFooterLine("Cel. 3128068807");
                    ticket.AddHeaderLine("");

                    ticket.PrintTicket("IMPREPOS");*/
                    //ticket.PrintTicket("Microsoft XPS Document Writer");
                }
            }
            catch (Exception ex)
            {
                OptionPane.MessageError("Ocurrió un error al imprimir el comprobante.\n" + ex.Message);
            }
        }

        private DataTable PagosGroup(IEnumerable<IGrouping<string, DataRow>> dataRows)
        {
            var tabla = new DataTable();
            tabla.Columns.Add(new DataColumn("FormaPago", typeof(string)));
            tabla.Columns.Add(new DataColumn("Valor", typeof(int)));
            foreach (IGrouping<string, DataRow> item in dataRows)
            {
                DataRow r = tabla.NewRow();
                r["FormaPago"] = item.Key;
                r["Valor"] = item.Sum<DataRow>(d => Convert.ToInt32(d["Valor"]));
                tabla.Rows.Add(r);
            }
            return tabla;
        }        
    }
}