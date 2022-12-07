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

namespace Aplicacion.Compras.Pago
{
    public partial class FrmAbonoGeneralCompra : Form
    {
        public int CodigoProveedor { set; get; }

        public List<FacturaProveedor> Cartera { set; get; }

        private Validacion validacion;

        private ErrorProvider miError;

        private BussinesCompraSimple miBussinesCompraSimple;

        private BussinesConsecutivo miBussinesConsecutivo;

        private BussinesBeneficio miBussinesBeneficio;

        private BussinesEgreso miBussinesEgreso;

        public FrmAbonoGeneralCompra()
        {
            InitializeComponent();

            this.validacion = new Validacion();
            this.miError = new ErrorProvider();
            this.miBussinesCompraSimple = new BussinesCompraSimple();
            this.miBussinesConsecutivo = new BussinesConsecutivo();
            this.miBussinesBeneficio = new BussinesBeneficio();
            this.miBussinesEgreso = new BussinesEgreso();
        }

        private void FrmAbonoCompra_Load(object sender, EventArgs e)
        {
            this.txtSaldo.Text = UseObject.InsertSeparatorMil(this.Cartera.Sum(s => s.Saldo).ToString());
        }

        private void FrmAbonoCompra_KeyDown(object sender, KeyEventArgs e){}

        private void FrmAbonoCompra_FormClosing(object sender, FormClosingEventArgs e){}

        private void txtAbono_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar.Equals((char)Keys.Enter))
            {
                try
                {
                    this.txtAbono.Text = this.txtAbono.Text.Replace(".", "");
                    if (!String.IsNullOrEmpty(this.txtAbono.Text))
                    {
                        this.miError.SetError(this.txtAbono, null);
                        if (this.validacion.ValidarNumeroInt(this.txtAbono.Text))
                        {
                            this.miError.SetError(this.txtAbono, null);
                            if (UseObject.RemoveSeparatorMil(this.txtSaldo.Text) >= Convert.ToDouble(this.txtAbono.Text))
                            {
                                this.miError.SetError(this.txtAbono, null);
                                DialogResult rta = MessageBox.Show("¿Está seguro(a) de pagar la compra?", "Pago a compra",
                                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                                if (rta.Equals(DialogResult.Yes))
                                {
                                    string facturas = this.miBussinesCompraSimple.IngresarPagoGeneral
                                                        (this.CodigoProveedor, Convert.ToInt32(this.txtAbono.Text), this.Cartera);
                                    PrintEgresoPos(GenerarEgreso(facturas));
                                    OptionPane.MessageInformation("El pago se ingresío con éxito.");
                                    CompletaEventos.CapturaEvento(new ObjectAbstract { Id = 555666888 });
                                    this.Close();
                                }
                            }
                            else
                            {
                                this.miError.SetError(this.txtAbono, "El valor del pago no debe ser superior al total.");
                            }
                        }
                        else
                        {
                            this.miError.SetError(this.txtAbono, "El valor que ingreso es incorrecto.");
                        }
                    }
                    else
                    {
                        this.miError.SetError(this.txtAbono, "Debe ingresar un valor.");
                    }
                }
                catch (Exception ex)
                {
                    OptionPane.MessageError(ex.Message);
                }
            }
        }

        private DTO.Clases.Egreso GenerarEgreso(string facturas)
        {
            try
            {
                var egreso = new DTO.Clases.Egreso();
                egreso.IdCaja = Convert.ToInt32(AppConfiguracion.ValorSeccion("id_caja"));
                egreso.IdUsuario = Convert.ToInt32(AppConfiguracion.ValorSeccion("id_user"));
                egreso.Numero = miBussinesConsecutivo.Consecutivo("Egreso");
                egreso.Fecha = DateTime.Now;
                egreso.TipoBeneficiario = this.miBussinesBeneficio.BeneficiarioNit(
                    UseObject.RemoveSeparatorMil(this.txtNit.Text).ToString()).IdTipoCliente;
                egreso.Pagos.Add(new FormaPago { IdFormaPago = 1, Valor = Convert.ToInt32(this.txtAbono.Text) });
                    //new List<FormaPago> { new FormaPago { IdFormaPago = 1, Valor = Convert.ToInt32(this.txtAbono.Text) } };
                egreso.Total = Convert.ToInt32(this.txtAbono.Text);
                egreso.Estado = true;
                egreso.Cuentas.Add( new ConceptoEgreso
                {
                    IdCuenta = Convert.ToInt32(AppConfiguracion.ValorSeccion("ctaEgreso")),
                    Nombre = "Abono a compras de proveedor número: " + facturas, 
                    Numero = egreso.Total.ToString()
                });
                egreso.Id = this.miBussinesEgreso.IngresarEgreso(egreso);
                return egreso;
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
                return null;
            }
        }

        private void PrintEgresoPos(DTO.Clases.Egreso egreso)
        {
            try
            {
                DialogResult rta = MessageBox.Show("¿Desea imprimir el comprobante de egreso?", "Compra proveedor",
                                   MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (rta.Equals(DialogResult.Yes))
                {
                   // var miBussinesCaja = new BussinesCaja();
                    var miBussinesEmpresa = new BussinesEmpresa();
                    var miBussinesUsuario = new BussinesUsuario();
                    var miBussinesBeneficia = new BussinesBeneficio();

                    var empresaRow = miBussinesEmpresa.PrintEmpresa().
                                 Tables[0].AsEnumerable().First();
                   // var caja = miBussinesCaja.CajaId(egreso.IdCaja);
                   // var usuario = miBussinesUsuario.ConsultaUsuario(egreso.IdUsuario).AsEnumerable().First();
                    var beneficio = miBussinesBeneficia.BeneficiarioId(egreso.TipoBeneficiario);

                    Ticket ticket = new Ticket();

                    ticket.AddHeaderLine(empresaRow["Nombre"].ToString().ToUpper());
                    ticket.AddHeaderLine(empresaRow["Juridico"].ToString());
                    ticket.AddHeaderLine("NIT " + UseObject.InsertSeparatorMilMasDigito(empresaRow["Nit"].ToString()));
                    ticket.AddHeaderLine(empresaRow["Direccion"].ToString());
                    ticket.AddHeaderLine("Tels. " + empresaRow["Telefono"].ToString());
                    ticket.AddHeaderLine("Fecha : " + egreso.Fecha.ToShortDateString());// +
                                   //  "    Caja : " + caja.Numero.ToString());
                   // ticket.AddHeaderLine("Cajero(a)  :  " + usuario["nombre"].ToString());
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

                    /*var sTotal = 0;
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
                    }*/
                   // ticket.AddTotal("SUBTOTAL     : ", UseObject.InsertSeparatorMil(sTotal.ToString()));
                    //ticket.AddTotal("RETENCIONES  : ", UseObject.InsertSeparatorMil(retencion.ToString()));
                    //ticket.AddTotal("TOTAL        : ", UseObject.InsertSeparatorMil(egreso.Total.ToString()));
                    ticket.AddHeaderLine("            TOTAL :" + UseObject.StringBuilderDetalleTotal(
                        UseObject.InsertSeparatorMil(egreso.Total.ToString())));
                    ticket.AddHeaderLine("");

                    //ticket.AddTotal("FORMAS DE PAGO", "");
                    //ticket.AddTotal("", "");

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
                }
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
        }
    }
}