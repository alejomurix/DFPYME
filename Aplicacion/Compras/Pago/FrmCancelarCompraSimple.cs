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
    public partial class FrmCancelarCompraSimple : Form
    {
        public int IdCompra { set; get; }

        public string Nit { set; get; }

        private Validacion miValidacion;

        private ErrorProvider miError;

        private BussinesCompraSimple miBussinesCompraSimple;

        private BussinesConsecutivo miBussinesConsecutivo;

        private BussinesBeneficio miBussinesBeneficio;

        private BussinesEgreso miBussinesEgreso;

        public FrmCancelarCompraSimple()
        {
            InitializeComponent();

            this.miValidacion = new Validacion();
            this.miError = new ErrorProvider();
            this.miBussinesCompraSimple = new BussinesCompraSimple();
            this.miBussinesConsecutivo = new BussinesConsecutivo();
            this.miBussinesBeneficio = new BussinesBeneficio();
            this.miBussinesEgreso = new BussinesEgreso();
        }
        
        private void FrmCancelarVenta_Load(object sender, EventArgs e){}

        private void FrmCancelarVenta_KeyDown(object sender, KeyEventArgs e){}

        private void FrmCancelarVenta_FormClosing(object sender, FormClosingEventArgs e){}

        private void txtValor_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar.Equals((char)Keys.Enter))
            {
                try
                {
                    this.txtValor.Text = this.txtValor.Text.Replace(".", "");
                    if (!String.IsNullOrEmpty(this.txtValor.Text))
                    {
                        this.miError.SetError(this.txtValor, null);
                        if (this.miValidacion.ValidarNumeroInt(this.txtValor.Text))
                        {
                            this.miError.SetError(this.txtValor, null);
                            if (UseObject.RemoveSeparatorMil(this.txtTotal.Text) >= Convert.ToDouble(this.txtValor.Text))
                            {
                                this.miError.SetError(this.txtValor, null);
                                DialogResult rta = MessageBox.Show("¿Está seguro(a) de pagar la compra?", "Pago a compra",
                                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                                if (rta.Equals(DialogResult.Yes))
                                {
                                    this.miBussinesCompraSimple.IngresarPagoCompra(
                                        new FormaPago
                                        {
                                            IdFactura = this.IdCompra,
                                            Fecha = DateTime.Now,
                                            Valor = UseObject.RemoveSeparatorMil(this.txtValor.Text)
                                        });
                                    OptionPane.MessageInformation("El pago se ingresío con éxito.");
                                    PrintEgresoPos(GenerarEgreso(this.IdCompra.ToString()));
                                    CompletaEventos.CapturaEvento(new ObjectAbstract { Id = 555666888 });
                                    this.Close();
                                }
                            }
                            else
                            {
                                this.miError.SetError(this.txtValor, "El valor del pago no debe ser superior al total.");
                            }
                        }
                        else
                        {
                            this.miError.SetError(this.txtValor, "El valor que ingreso es incorrecto.");
                        }
                    }
                    else
                    {
                        this.miError.SetError(this.txtValor, "Debe ingresar un valor.");
                    }
                }
                catch (Exception ex)
                {
                    OptionPane.MessageError(ex.Message);
                }
            }
        }



        private DTO.Clases.Egreso GenerarEgreso(string factura)
        {
            try
            {
                var egreso = new DTO.Clases.Egreso();
                egreso.IdCaja = Convert.ToInt32(AppConfiguracion.ValorSeccion("id_caja"));
                egreso.IdUsuario = Convert.ToInt32(AppConfiguracion.ValorSeccion("id_user"));
                egreso.Numero = miBussinesConsecutivo.Consecutivo("Egreso");
                egreso.Fecha = DateTime.Now;
                egreso.TipoBeneficiario = this.miBussinesBeneficio.BeneficiarioNit(
                    UseObject.RemoveSeparatorMil(this.Nit).ToString()).IdTipoCliente;
                egreso.Pagos.Add(new FormaPago { IdFormaPago = 1, Valor = Convert.ToInt32(this.txtValor.Text) });
                egreso.Total = Convert.ToInt32(this.txtValor.Text);
                egreso.Estado = true;
                egreso.Cuentas.Add(new ConceptoEgreso
                {
                    IdCuenta = Convert.ToInt32(AppConfiguracion.ValorSeccion("ctaEgreso")),
                    Nombre = "Abono a compra de proveedor número: " + factura,
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
                    foreach (var cuenta in egreso.Cuentas)
                    {
                        ticket.AddItem("",
                                       cuenta.Nombre,
                                       UseObject.InsertSeparatorMil(cuenta.Numero));
                    }

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
                    ticket.AddTotal("TOTAL        : ", UseObject.InsertSeparatorMil(egreso.Total.ToString()));
                    ticket.AddTotal("", "");
                    ticket.AddTotal("", "");

                    ticket.AddTotal("FORMAS DE PAGO", "");
                    ticket.AddTotal("", "");
                    var pEfectivo = egreso.Pagos.Where(d => d.IdFormaPago.Equals(1));
                    var pCheque = egreso.Pagos.Where(d => d.IdFormaPago.Equals(2));
                    var pTransaccion = egreso.Pagos.Where(d => d.IdFormaPago.Equals(4));
                    if (pEfectivo.ToArray().Length != 0)
                    {
                        ticket.AddTotal("EFECTIVO  : ", UseObject.InsertSeparatorMil(pEfectivo.Sum(d => d.Valor).ToString()));
                    }
                    if (pCheque.ToArray().Length != 0)
                    {
                        ticket.AddTotal("CHEQUE    : ", UseObject.InsertSeparatorMil(pCheque.Sum(d => d.Valor).ToString()));
                    }
                    if (pTransaccion.ToArray().Length != 0)
                    {
                        ticket.AddTotal("TRANSACCIÓN :", UseObject.InsertSeparatorMil(pTransaccion.Sum(d => d.Valor).ToString()));
                    }

                    ticket.AddFooterLine("===================================");
                    ticket.AddFooterLine(".");
                    ticket.AddFooterLine(".");
                    ticket.AddFooterLine("___________________________________");
                    ticket.AddFooterLine("Aprobado:");
                    ticket.AddFooterLine(".");
                    ticket.AddFooterLine("___________________________________");
                    ticket.AddFooterLine("Beneficiario");
                    ticket.AddFooterLine(".");
                    ticket.AddFooterLine(".");

                    ticket.AddFooterLine("Software: Digital Fact Pyme");
                    ticket.AddFooterLine("Soluciones Tecnológicas A&C.");
                    ticket.AddHeaderLine("solucionestecnologicasayc@gmail.com");
                    ticket.AddFooterLine(".");

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