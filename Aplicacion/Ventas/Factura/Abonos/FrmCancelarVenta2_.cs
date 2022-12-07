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
    public partial class FrmCancelarVenta2_ : Form
    {
        private BussinesFormaPago miBussinesPago;

        private BussinesFacturaVenta miBussinesFactura;

        private BussinesIngreso miBussinesIngreso;

        private BussinesConsecutivo miBussinesConsecutivo;

        //public DateTime Fecha { set; get; }
        public string NitCliente { set; get; }
        public string NumeroFactura { set; get; }
        public bool EsVenta = true;
        Validacion validacion;
        private bool Efectivo = false;
        private bool Cheque = false;
        private bool Tarjeta = false;
        private bool Venta = true;
        public bool Abono = false;
        private bool AbonoMatch = false;

        public FrmCancelarVenta2_()
        {
            InitializeComponent();
            miBussinesPago = new BussinesFormaPago();
            miBussinesFactura = new BussinesFacturaVenta();
            miBussinesIngreso = new BussinesIngreso();
            miBussinesConsecutivo = new BussinesConsecutivo();
            validacion = new Validacion();
        }

        private void FrmCancelarVenta_Load(object sender, EventArgs e)
        {
            
        }

        string Numero = "";
        private void FrmCancelarVenta_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.F6)
            {
                txtAbono_Validating(txtAbono, new CancelEventArgs(false));
                txtEfectivo_Validating(txtEfectivo, new CancelEventArgs(false));
                txtCheque_Validating(txtCheque, new CancelEventArgs(false));
                txtTarjeta_Validating(txtTarjeta, new CancelEventArgs(false));
                //DialogResult rta = MessageBox.Show("¿Está seguro(a) de querer realizar el abono?",
                //  "Realizar Abono", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                //if (rta == DialogResult.Yes)
                //{
                if (AbonoMatch && Efectivo && Cheque && Tarjeta)
                {
                    var suma = UseObject.RemoveSeparatorMil(txtEfectivo.Text) +
                               UseObject.RemoveSeparatorMil(txtCheque.Text) +
                               UseObject.RemoveSeparatorMil(txtTarjeta.Text);
                    if (suma >= UseObject.RemoveSeparatorMil(txtAbono.Text))
                    {
                        if (!UseObject.RemoveSeparatorMil(this.txtAbono.Text).Equals(0))
                        {
                            txtCambio.Text = UseObject.InsertSeparatorMil
                                   ((suma - UseObject.RemoveSeparatorMil(txtAbono.Text)).ToString());
                            DialogResult rta = MessageBox.Show("¿Está seguro(a) de querer realizar el abono?",
                               "Realizar Abono", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                            if (rta == DialogResult.Yes)
                            {
                                var formas = FormasDePago();
                                try
                                {
                                    foreach (FormaPago pago in formas)
                                    {
                                        if (pago.Valor != 0)
                                        {
                                            pago.NumeroFactura = NumeroFactura;
                                            pago.Usuario.Id = Convert.ToInt32(AppConfiguracion.ValorSeccion("id_user"));
                                            pago.Caja.Id = Convert.ToInt32(AppConfiguracion.ValorSeccion("id_caja"));
                                            pago.Fecha = DateTime.Now;
                                            if (EsVenta)
                                            {
                                                miBussinesPago.IngresarPagoAFactura(pago, true, false);
                                            }
                                            else
                                            {
                                                miBussinesPago.IngresarPagoRemision(pago);
                                            }

                                            /*var ingreso = new Ingreso();
                                            var concepto = "";
                                            if (EsVenta)
                                            {
                                                ingreso.Numero = miBussinesConsecutivo.Consecutivo("Ingreso");//AppConfiguracion.ValorSeccion("ingreso");
                                                concepto = "Abono a Factura Número: ";
                                                ingreso.Tipo = 2;
                                            }
                                            else
                                            {
                                                ingreso.Numero = miBussinesConsecutivo.Consecutivo("ConsIngresoRemision") +
                                                                 miBussinesConsecutivo.Consecutivo("IngresoRemision");
                                                //AppConfiguracion.ValorSeccion("cing_remision") + AppConfiguracion.ValorSeccion("ing_remision");
                                                concepto = "Abono a Remisión Número: ";
                                                ingreso.Tipo = 3;
                                            }
                                            Numero = ingreso.Numero;
                                            ingreso.Concepto = concepto + NumeroFactura;
                                            ingreso.Fecha = pago.Fecha;
                                            ingreso.NitCliente = this.NitCliente;
                                            ingreso.Valor = Convert.ToInt32(formas.Sum(f => f.Valor));//pago.Valor;
                                            ingreso.Estado = true;
                                            if (EsVenta)
                                            {
                                                ingreso.Relacion = miBussinesPago.IngresarPagoAFactura
                                                    (pago, true, false);
                                                // ingreso.Saldo = 
                                                ingreso.Saldo = miBussinesFactura.SaldoPorCliente(2, NitCliente);
                                                miBussinesIngreso.Ingresar(ingreso, false);
                                            }
                                            else
                                            {
                                                ingreso.Relacion = miBussinesPago.IngresarPagoRemision(pago);
                                                miBussinesIngreso.IngresoDeRemision(ingreso);
                                            }*/
                                        }
                                    }
                                    var ingreso = new Ingreso();
                                    var concepto = "";
                                    if (EsVenta)
                                    {
                                        ingreso.Numero = miBussinesConsecutivo.Consecutivo("Ingreso");
                                        concepto = "Abono a Factura Número: ";
                                        //ingreso.Tipo = 2;
                                    }
                                    else
                                    {
                                        ingreso.Numero = miBussinesConsecutivo.Consecutivo("IngresoRemision"); //+
                                        // miBussinesConsecutivo.Consecutivo("IngresoRemision");
                                        concepto = "Abono a Remisión Número: ";
                                        //ingreso.Tipo = 3;
                                    }
                                    Numero = ingreso.Numero;
                                    ingreso.Concepto = concepto + NumeroFactura;
                                    ingreso.Fecha = DateTime.Now;
                                    ingreso.NitCliente = this.NitCliente;
                                    ingreso.Valor = Convert.ToInt32(formas.Sum(f => f.Valor));//pago.Valor;
                                    ingreso.IdCaja = Convert.ToInt32(AppConfiguracion.ValorSeccion("id_caja"));
                                    ingreso.IdUsuario = Convert.ToInt32(AppConfiguracion.ValorSeccion("id_user"));
                                    ingreso.FormasPago = FormasDePago();
                                    ingreso.Estado = true;
                                    if (EsVenta)
                                    {
                                        ingreso.Saldo = miBussinesFactura.SaldoPorCliente(2, NitCliente);
                                        miBussinesIngreso.Ingresar(ingreso, false);
                                    }
                                    else
                                    {
                                        miBussinesIngreso.IngresoDeRemision(ingreso);
                                    }



                                    OptionPane.MessageInformation("El abono se realizó con éxito.");
                                    /*rta = MessageBox.Show("El abono se realizó con éxito.\n¿Desea imprimir el comprobante de ingreso?", "Abono a Factura",
                                          MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                                    if (rta.Equals(DialogResult.Yes))
                                    {*/
                                    if (Convert.ToBoolean(AppConfiguracion.ValorSeccion("printIngreso")))
                                    {
                                        PrintIngresoPos(Numero);
                                    }
                                    else
                                    {
                                        PrintIngreso(Numero);
                                    }
                                    //}
                                    if (EsVenta)
                                    {
                                        CompletaEventos.CapEvenAbonoFact(110); // true
                                    }
                                    else
                                    {
                                        CompletaEventos.CapEvenAbonoRemision(Numero);
                                    }
                                    /*OptionPane.MessageInformation("El abono se realizó con éxito.");
                                    if (EsVenta)
                                    {
                                        if (Convert.ToBoolean(AppConfiguracion.ValorSeccion("printIngreso")))
                                        {
                                            CompletaEventos.CapEvenAbonoFact(Numero);
                                            //
                                            //PrintIngresoPos(Numero);
                                        }
                                        else
                                        {
                                            CompletaEventos.CapEvenAbonoFact(formas);
                                        }
                                    }
                                    else
                                    {
                                        CompletaEventos.CapEvenAbonoRemision(formas);
                                    }*/


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
                            OptionPane.MessageInformation("El valor del abono debe ser superior a Cero.");
                            this.txtAbono.Focus();
                        }
                    }
                    else
                    {
                        OptionPane.MessageInformation("Las formas de pago deben superar el valor del abono.");
                        this.txtEfectivo.Focus();
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
            CompletaEventos.CapturaEvento(15);
        }

        private void txtAbono_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar.Equals((Char)Keys.Enter))
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
                    OptionPane.MessageError("El valor del Abono es incorrecto.");
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
            if (e.KeyChar.Equals((Char)Keys.Enter))
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
                                        UseObject.RemoveSeparatorMil(txtAbono.Text))
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
            if (e.KeyChar.Equals((Char)Keys.Enter))
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
                                        UseObject.RemoveSeparatorMil(txtAbono.Text))
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
            if (e.KeyChar.Equals((Char)Keys.Enter))
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
                                        UseObject.RemoveSeparatorMil(txtAbono.Text))
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
            var Abono = UseObject.RemoveSeparatorMil(txtAbono.Text);
            var Efectivo = UseObject.RemoveSeparatorMil(txtEfectivo.Text);
            var Cheque = UseObject.RemoveSeparatorMil(txtCheque.Text);
            var Tarjeta = UseObject.RemoveSeparatorMil(txtTarjeta.Text);

            var Formas = new List<DTO.Clases.FormaPago>();
            if (Efectivo <= Abono)
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
                if (Cheque <= (Abono - Efectivo))
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
                    if (Tarjeta <= (Abono - (Efectivo + Cheque)))
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
                            Valor = Convert.ToInt32(Abono - (Efectivo + Cheque)),
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
                        Valor = Convert.ToInt32(Abono - Efectivo),
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
                    Valor = Convert.ToInt32(Abono),
                    Pago = Convert.ToInt32(Efectivo)
                });
            }
            return Formas;
        }

        private void PrintIngreso(string numero)
        {
            try
            {
                /* DialogResult rta = MessageBox.Show("¿Desea visualizar la impresión del comprobante de ingreso?", "Abono a Factura",
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

                    var tIngresos = new DataTable();
                    var tPagos = new DataTable();
                    if (EsVenta)
                    {
                        tIngresos = miBussinesIngreso.Ingresos(numero);
                    }
                    else
                    {
                        tIngresos = miBussinesIngreso.IngresosRemision(numero);
                    }
                    var ingresoRow = tIngresos.AsEnumerable().First();
                    if (EsVenta)
                    {
                        tPagos = miBussinesIngreso.FormasPagoIngresoVenta(Convert.ToInt32(ingresoRow["id"]));
                    }
                    else
                    {
                        tPagos = miBussinesIngreso.FormasPagoIngresoRemision(Convert.ToInt32(ingresoRow["id"]));
                    }

                    var cliente = miBussinesCliente.ClienteAEditar(ingresoRow["nitcliente"].ToString());

                    var printComprobante = new Cliente.FrmPrintAnticipo();
                    if (!EsVenta)
                    {
                        printComprobante.NombreDoc = "Recibo de Pago de Remisión No. ";
                    }
                    printComprobante.Numero = numero;
                    printComprobante.Fecha = Convert.ToDateTime(ingresoRow["fecha"]);
                    printComprobante.Cliente = cliente.NombresCliente;
                    printComprobante.Nit = cliente.NitCliente;
                    printComprobante.Direccion =
                        cliente.DireccionCliente + "  " + cliente.Ciudad + "  " + cliente.Departamento;
                    printComprobante.Concepto = ingresoRow["concepto"].ToString();
                    printComprobante.Valor = ingresoRow["valor"].ToString();
                    printComprobante.Efectivo =
                        tPagos.AsEnumerable().Where(p => p.Field<int>("idforma_pago").Equals(1)).Sum(s => s.Field<int>("valor")).ToString();
                    printComprobante.Cheque =
                        tPagos.AsEnumerable().Where(p => p.Field<int>("idforma_pago").Equals(2)).Sum(s => s.Field<int>("valor")).ToString();

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
                    var cliente = miBussinesCliente.ClienteAEditar(clienteRow["nitcliente"].ToString());

                    var printComprobante = new Cliente.FrmPrintAnticipo();
                    printComprobante.Numero = numero;
                    printComprobante.Fecha = Convert.ToDateTime(ingresoRow["fecha"]);
                    printComprobante.Cliente = cliente.NombresCliente;
                    printComprobante.Nit = cliente.NitCliente;
                    printComprobante.Direccion =
                        cliente.DireccionCliente + "  " + cliente.Ciudad + "  " + cliente.Departamento;
                    printComprobante.Valor = ingresoRow["valor"].ToString();

                    IEnumerable<IGrouping<string, DataRow>> queryPago = from item in tPagos.AsEnumerable()
                                                                        group item by item["FormaPago"].ToString()
                                                                            into g
                                                                            select g;
                    var efectivo = 0;
                    foreach (DataRow pRow in tPagos.Rows)
                    {
                        if (Convert.ToInt32(pRow["IdPago"]).Equals(1) || Convert.ToInt32(pRow["IdPago"]).Equals(3))
                        {
                            efectivo += Convert.ToInt32(pRow["Valor"]);
                        }
                    }
                    printComprobante.Efectivo = efectivo.ToString();
                    printComprobante.Cheque = tPagos.AsEnumerable().Where(t => t.Field<int>("IdPago").Equals(2)).
                                                                    Sum(s => s.Field<int>("Valor")).ToString();
                    printComprobante.Concepto = ingresoRow["concepto"].ToString();*/

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
                    var miBussinesCaja = new BussinesCaja();
                    var miBussinesUsuario = new BussinesUsuario();
                    var miBussinesFactura = new BussinesFacturaVenta();
                    var miBussinesRemision = new BussinesRemision();
                    var miBussinesIngreso = new BussinesIngreso();
                    var miBussinesCliente = new BussinesCliente();

                    var empresaRow = miBussinesEmpresa.PrintEmpresa().
                                     Tables[0].AsEnumerable().First();


                    var tIngresos = new DataTable();
                    var tPagos = new DataTable();
                    if (EsVenta)
                    {
                        tIngresos = miBussinesIngreso.Ingresos(numero);
                    }
                    else
                    {
                        tIngresos = miBussinesIngreso.IngresosRemision(numero);
                    }
                    var ingresoRow = tIngresos.AsEnumerable().First();
                    if (EsVenta)
                    {
                        tPagos = miBussinesIngreso.FormasPagoIngresoVenta(Convert.ToInt32(ingresoRow["id"]));
                    }
                    else
                    {
                        tPagos = miBussinesIngreso.FormasPagoIngresoRemision(Convert.ToInt32(ingresoRow["id"]));
                    }

                    var caja = miBussinesCaja.CajaId(Convert.ToInt32(ingresoRow["idcaja"]));
                    var usuario = miBussinesUsuario.ConsultaUsuario(Convert.ToInt32(ingresoRow["idusuario"])).
                        AsEnumerable().First()["nombre"].ToString();
                    var cliente = miBussinesCliente.ClienteAEditar(ingresoRow["nitcliente"].ToString());

                    Ticket ticket = new Ticket();

                    ticket.AddHeaderLine(empresaRow["Nombre"].ToString().ToUpper());
                    ticket.AddHeaderLine(empresaRow["Juridico"].ToString());
                    ticket.AddHeaderLine("NIT " + UseObject.InsertSeparatorMilMasDigito(empresaRow["Nit"].ToString()));
                    ticket.AddHeaderLine(empresaRow["Direccion"].ToString());
                    ticket.AddHeaderLine("Tels. " + empresaRow["Telefono"].ToString());
                    ticket.AddHeaderLine("Fecha : " + Convert.ToDateTime(ingresoRow["fecha"]).ToShortDateString() +
                                         "    Caja : " + caja.Numero);
                    ticket.AddHeaderLine("Cajero(a)  :  " + usuario);
                    ticket.AddHeaderLine("===================================");
                    if (EsVenta)
                    {
                        ticket.AddHeaderLine("COMPROBANTE DE INGRESO Nro " + numero);
                    }
                    else
                    {
                        ticket.AddHeaderLine("RECIBO DE PAGO DE REMISIÓN Nro " + numero);
                    }
                    ticket.AddHeaderLine("===================================");
                    ticket.AddHeaderLine("Recibido de : " + cliente.NombresCliente);
                    ticket.AddHeaderLine("NIT o C.C.  : " + UseObject.InsertSeparatorMilMasDigito(cliente.NitCliente));
                    ticket.AddHeaderLine("===================================");
                    ticket.AddItem("",
                                   ingresoRow["concepto"].ToString(),
                                   UseObject.InsertSeparatorMil(ingresoRow["valor"].ToString()));

                    ticket.AddTotal("TOTAL ", UseObject.InsertSeparatorMil(ingresoRow["valor"].ToString()));

                    ticket.AddTotal(" ", " ");
                    foreach (DataRow pRow in tPagos.Rows)
                    {
                        ticket.AddTotal(pRow["nombre"].ToString(),
                                    UseObject.InsertSeparatorMil(pRow["valor"].ToString()));
                    }
                    if (EsVenta)
                    {
                        ticket.AddFooterLine("===================================");
                        ticket.AddFooterLine("Saldo : $" + UseObject.InsertSeparatorMil(
                            miBussinesFactura.SaldoPorCliente(2, cliente.NitCliente).ToString()));
                    }

                    ticket.AddFooterLine("===================================");
                    ticket.AddFooterLine(".");
                    ticket.AddFooterLine(".");
                    ticket.AddFooterLine("Firma:");
                    ticket.AddFooterLine("-----------------------------------");
                    ticket.AddFooterLine("C.C. o NIT:");
                    ticket.AddFooterLine("-----------------------------------");
                    ticket.AddFooterLine("Fecha:");
                    ticket.AddFooterLine("-----------------------------------");
                    ticket.AddFooterLine(".");
                    ticket.AddFooterLine("Software: Digital Fact Pyme");
                    ticket.AddFooterLine("Soluciones Tecnológicas A&C.");
                    ticket.AddFooterLine("Cel. 3128068807");
                    ticket.AddFooterLine(".");

                    ticket.PrintTicket("IMPREPOS");
                    /*
                                        var tIngresos = miBussinesIngreso.IngresosMultiple(numero);
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
                                            if (Convert.ToInt32(ingresoRow["tipo"]).Equals(2))
                                            {
                                                clienteRow = miBussinesFactura.ClienteDeFacutura(queryFactura.First().Key).AsEnumerable().First();
                                            }
                                            else
                                            {
                                                clienteRow = miBussinesRemision.ClienteDeRemsion(Convert.ToInt32(queryFactura.First().Key)).AsEnumerable().First();
                                            }
                                        }

                                        Ticket ticket = new Ticket();

                                        ticket.AddHeaderLine(empresaRow["Nombre"].ToString().ToUpper());
                                        ticket.AddHeaderLine(empresaRow["Juridico"].ToString());
                                        ticket.AddHeaderLine("NIT " + UseObject.InsertSeparatorMilMasDigito(empresaRow["Nit"].ToString()));
                                        ticket.AddHeaderLine(empresaRow["Direccion"].ToString());
                                        ticket.AddHeaderLine("Tels. " + empresaRow["Telefono"].ToString());
                                        ticket.AddHeaderLine("Fecha : " + Convert.ToDateTime(ingresoRow["fecha"]).ToShortDateString() +
                                                             "    Caja : " + noCaja);
                                        ticket.AddHeaderLine("Cajero(a)  :  " + usuario);
                                        ticket.AddHeaderLine("===================================");
                                        ticket.AddHeaderLine("COMPROBANTE DE INGRESO Nro " + numero);
                                        ticket.AddHeaderLine("===================================");
                                        ticket.AddHeaderLine("Recibido de : " + clienteRow["nombrescliente"].ToString().ToUpper());
                                        ticket.AddHeaderLine("NIT o C.C.  : " + UseObject.InsertSeparatorMilMasDigito(clienteRow["nitcliente"].ToString()));
                                        ticket.AddHeaderLine("===================================");
                                        ticket.AddItem("",
                                                       ingresoRow["concepto"].ToString(),
                                                       UseObject.InsertSeparatorMil(ingresoRow["valor"].ToString()));

                                        ticket.AddTotal("TOTAL ", UseObject.InsertSeparatorMil(ingresoRow["valor"].ToString()));

                                        ticket.AddTotal(" ", " ");
                                        IEnumerable<IGrouping<string, DataRow>> queryPago = from item in tPagos.AsEnumerable()
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
                                        }
                                        ticket.AddFooterLine("===================================");
                                        ticket.AddFooterLine("Saldo : $" + UseObject.InsertSeparatorMil(
                                            miBussinesFactura.SaldoPorCliente(2, clienteRow["nitcliente"].ToString()).ToString()));
                                        ticket.AddFooterLine("===================================");
                                        ticket.AddFooterLine(".");
                                        ticket.AddFooterLine(".");
                                        ticket.AddFooterLine("Firma:");
                                        ticket.AddFooterLine("-----------------------------------");
                                        ticket.AddFooterLine("C.C. o NIT:");
                                        ticket.AddFooterLine("-----------------------------------");
                                        ticket.AddFooterLine("Fecha:");
                                        ticket.AddFooterLine("-----------------------------------");
                                        ticket.AddFooterLine(".");
                                        ticket.AddFooterLine("Software: Digital Fact Pyme");
                                        ticket.AddFooterLine("Soluciones Tecnológicas A&C.");
                                        ticket.AddFooterLine("Cel. 3128068807");
                                        ticket.AddFooterLine(".");

                                        ticket.PrintTicket("IMPREPOS");*/
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