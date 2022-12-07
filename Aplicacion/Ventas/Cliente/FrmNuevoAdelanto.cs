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

namespace Aplicacion.Ventas.Cliente
{
    public partial class FrmNuevoAdelanto : Form
    {
        public string NitCliente { set; get; }

        private ErrorProvider miError;

        private bool ValorMatch = false;

        private bool ChequeMatch = false;

        private string ValorFormat = "El número que ingreso es invalido.";

        public FrmNuevoAdelanto()
        {
            InitializeComponent();
            miError = new ErrorProvider();
        }

        private void FrmNuevoAdelanto_Load(object sender, EventArgs e)
        {
            txtValor.SelectAll();
        }

        private void FrmNuevoAdelanto_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData.Equals(Keys.Escape))
            {
                this.Close();
            }
        }

        private void FrmNuevoAdelanto_FormClosing(object sender, FormClosingEventArgs e)
        {
            CompletaEventos.CapturaEventobo(false);
        }

        private void txtValor_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar.Equals((char)Keys.Enter))
            {
                if (String.IsNullOrEmpty(txtValor.Text))
                {
                    txtValor.Text = "0";
                    ValorMatch = true;
                }
                else
                {
                    if (Validacion.ConFormato
                       (Validacion.TipoValidacion.Numeros, txtValor, miError, ValorFormat))
                    {
                        ValorMatch = true;
                        //btnAceptar_Click(this.btnAceptar, new EventArgs());
                        txtCheque.Focus();
                    }
                    else
                    {
                        ValorMatch = false;
                    }
                }
            }
        }

        private void txtValor_Validating(object sender, CancelEventArgs e)
        {
            if (String.IsNullOrEmpty(txtValor.Text))
            {
                txtValor.Text = "0";
                ValorMatch = true;
            }
            else
            {
                if (Validacion.ConFormato
                   (Validacion.TipoValidacion.Numeros, txtValor, miError, ValorFormat))
                {
                    ValorMatch = true;
                }
                else
                {
                    ValorMatch = false;
                }
            }
        }

        private void txtCheque_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar.Equals((char)Keys.Enter))
            {
                if (String.IsNullOrEmpty(txtCheque.Text))
                {
                    txtCheque.Text = "0";
                    ChequeMatch = true;
                }
                else
                {
                    if (Validacion.ConFormato
                       (Validacion.TipoValidacion.Numeros, txtCheque, miError, ValorFormat))
                    {
                        ChequeMatch = true;
                        btnAceptar_Click(this.btnAceptar, new EventArgs());
                    }
                    else
                    {
                        ChequeMatch = false;
                    }
                }
            }
        }

        private void txtCheque_Validating(object sender, CancelEventArgs e)
        {
            if (String.IsNullOrEmpty(txtCheque.Text))
            {
                txtCheque.Text = "0";
                ChequeMatch = true;
            }
            else
            {
                if (Validacion.ConFormato
                   (Validacion.TipoValidacion.Numeros, txtCheque, miError, ValorFormat))
                {
                    ChequeMatch = true;
                }
                else
                {
                    ChequeMatch = false;
                }
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (ValorMatch && ChequeMatch)
            {
                if (!txtValor.Text.Equals("0") || !txtCheque.Text.Equals("0"))
                {
                    var anticipo = new List<DTO.Clases.FormaPago>();
                    //if (!txtValor.Text.Equals("0"))
                    //{
                    anticipo.Add(new DTO.Clases.FormaPago
                    {
                        IdFormaPago = 1,
                        NombreFormaPago = "Efectivo",
                        Valor = Convert.ToInt32(txtValor.Text)
                    });
                    //}
                    //if (!txtCheque.Text.Equals("0"))
                    //{
                    anticipo.Add(new DTO.Clases.FormaPago
                    {
                        IdFormaPago = 2,
                        NombreFormaPago = "Cheque",
                        Valor = Convert.ToInt32(txtCheque.Text)
                    });
                    //}
                    IngresarAdelanto(anticipo);
                    CompletaEventos.CapturaEventoAdelanto(anticipo);
                    this.Close();
                }
                else
                {
                    CustomControl.OptionPane.MessageInformation("Los valores deben ser mayores a cero.");
                }
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void IngresarAdelanto(List<FormaPago> pagos)
        {
            try
            {
                var miBussinesConsecutivo = new BussinesConsecutivo();
                var miBussinesSaldo = new BussinesSaldo();
                var miBussinesCliente = new BussinesCliente();
                var cliente = miBussinesCliente.ClienteAEditar(NitCliente);

                var saldo = new Saldo();
                saldo.NitCliente = NitCliente;
                saldo.IdUsuario = Convert.ToInt32(AppConfiguracion.ValorSeccion("id_user"));
                saldo.IdCaja = Convert.ToInt32(AppConfiguracion.ValorSeccion("id_caja"));
                saldo.Fecha = DateTime.Now;
                saldo.Valor = Convert.ToInt32(pagos.Sum(s => s.Valor));
                saldo.FormasPago = pagos;
                saldo.Ingreso.Numero = miBussinesConsecutivo.Consecutivo("Anticipo");
                saldo.Ingreso.Concepto = "Anticipo.";
               // saldo.Ingreso.Tipo = 1;
                saldo.Ingreso.Fecha = saldo.Fecha;
                saldo.Ingreso.Valor = saldo.Valor;
                saldo.Ingreso.Estado = true;

                long n = miBussinesSaldo.IngresarSaldo(saldo);
                OptionPane.MessageInformation("El anticipo se almaceno correctamente.");
                //txtCliente_KeyPress(this.txtCliente, new KeyPressEventArgs((char)Keys.Enter));

                /*DialogResult rta = MessageBox.Show("¿Desea visualizar la impresión del recibo de ingreso?", "Anticipo Cliente",
                    MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);*/
                FrmPrint frmPrint = new FrmPrint();
                frmPrint.StringCaption = "Anticipo Cliente";
                frmPrint.StringMessage = "Impresión del Recibo de Anticipo";
                DialogResult rta = frmPrint.ShowDialog();

                if (!rta.Equals(DialogResult.Cancel))
                {
                    var printCompIng = new FrmPrintAnticipo();
                    printCompIng.Recibo = true;
                    printCompIng.TipoRecibo = 2;
                    printCompIng.Fecha = DateTime.Now;
                    printCompIng.Cliente = cliente.NombresCliente;
                    printCompIng.Nit = NitCliente;
                    printCompIng.Direccion =
                        cliente.DireccionCliente + "  " + cliente.Ciudad + "  " + cliente.Departamento;
                    printCompIng.Valor = saldo.Valor.ToString();
                    printCompIng.Efectivo = pagos.Where(p => p.IdFormaPago == 1).Single().Valor.ToString();
                    printCompIng.Cheque = pagos.Where(p => p.IdFormaPago == 2).Single().Valor.ToString();
                    printCompIng.Numero = saldo.Ingreso.Numero;
                    printCompIng.Concepto = "Anticipo.";

                    if (rta.Equals(DialogResult.No))
                    {
                        printCompIng.ShowDialog();
                    }
                    else
                    {
                        Imprimir print = new Imprimir();
                        print.Report = printCompIng.CargarDatos();
                        print.Print(Imprimir.TamanioPapel.MediaCarta);
                        printCompIng.ResetReport();
                    }
                }
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
        }

        private void IngresarAdelantoPrintPos(List<FormaPago> pagos)
        {
            try
            {
                var miBussinesConsecutivo = new BussinesConsecutivo();
                var miBussinesSaldo = new BussinesSaldo();
                var miBussinesCliente = new BussinesCliente();
                var cliente = miBussinesCliente.ClienteAEditar(NitCliente);

                var saldo = new Saldo();
                saldo.NitCliente = NitCliente;
                saldo.IdUsuario = Convert.ToInt32(AppConfiguracion.ValorSeccion("id_user"));
                saldo.IdCaja = Convert.ToInt32(AppConfiguracion.ValorSeccion("id_caja"));
                saldo.Fecha = DateTime.Now;
                saldo.Valor = Convert.ToInt32(pagos.Sum(s => s.Valor));
                saldo.FormasPago = pagos;
                saldo.Ingreso.Numero = miBussinesConsecutivo.Consecutivo("Anticipo");
                //saldo.Ingreso.Tipo = 1;
                saldo.Ingreso.Fecha = saldo.Fecha;
                saldo.Ingreso.Valor = saldo.Valor;
                saldo.Ingreso.Estado = true;

                long n = miBussinesSaldo.IngresarSaldo(saldo);
                OptionPane.MessageInformation("El anticipo se almaceno correctamente.");
                //txtCliente_KeyPress(this.txtCliente, new KeyPressEventArgs((char)Keys.Enter));
                DialogResult rta = MessageBox.Show("¿Desea imprimir el recibo de ingreso?", "Anticipo Cliente",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (rta.Equals(DialogResult.Yes))
                {
                    var miBussinesEmpresa = new BussinesEmpresa();
                    var miBussinesCaja = new BussinesCaja();
                    var miBussinesUsuario = new BussinesUsuario();
                    var empresaRow = miBussinesEmpresa.PrintEmpresa().Tables[0].AsEnumerable().First();
                    var caja = miBussinesCaja.CajaId(saldo.IdCaja);
                    var usuarioRow = miBussinesUsuario.ConsultaUsuario(saldo.IdUsuario).AsEnumerable().First();

                    Ticket ticket = new Ticket();

                    ticket.AddHeaderLine(empresaRow["Nombre"].ToString().ToUpper());
                    ticket.AddHeaderLine(empresaRow["Juridico"].ToString());
                    ticket.AddHeaderLine("NIT " + UseObject.InsertSeparatorMilMasDigito(empresaRow["Nit"].ToString()));
                    ticket.AddHeaderLine(empresaRow["Direccion"].ToString());
                    ticket.AddHeaderLine("Tels. " + empresaRow["Telefono"].ToString());
                    ticket.AddHeaderLine("Fecha : " + saldo.Fecha.ToShortDateString() +
                                         "    Caja : " + caja.Numero);
                    ticket.AddHeaderLine("Cajero(a)  :  " + usuarioRow["nombre"].ToString());
                    ticket.AddHeaderLine("===================================");
                    ticket.AddHeaderLine("RECIBO DE ANTICIPO No " + saldo.Ingreso.Numero);
                    ticket.AddHeaderLine("===================================");
                    ticket.AddHeaderLine("Recibido de : " + cliente.NombresCliente.ToUpper());
                    ticket.AddHeaderLine("NIT o C.C.  : " + UseObject.InsertSeparatorMilMasDigito(cliente.NitCliente));
                    ticket.AddHeaderLine("===================================");

                    ticket.AddItem("",
                                   "Anticipo.", UseObject.InsertSeparatorMil(saldo.Valor.ToString()));

                    ticket.AddTotal("TOTAL ", UseObject.InsertSeparatorMil(saldo.Valor.ToString()));

                    ticket.AddTotal(" ", " ");

                    foreach (var pago in pagos)
                    {
                        ticket.AddTotal(pago.NombreFormaPago,
                            UseObject.InsertSeparatorMil(pago.Valor.ToString()));
                    }

                   /* foreach (DataRow pRow in tPagosGroup.Rows)
                    {
                        ticket.AddTotal(pRow["FormaPago"].ToString(),
                                        UseObject.InsertSeparatorMil(pRow["Valor"].ToString()));
                        var t = pRow["FormaPago"].ToString() + " " +
                                        UseObject.InsertSeparatorMil(pRow["Valor"].ToString());
                    }*/
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



                    /*var printCompIng = new FrmPrintAnticipo();
                    printCompIng.Recibo = true;
                    printCompIng.TipoRecibo = 2;
                    printCompIng.Fecha = DateTime.Now;
                    printCompIng.Cliente = cliente.NombresCliente;
                    printCompIng.Nit = NitCliente;
                    printCompIng.Direccion =
                        cliente.DireccionCliente + "  " + cliente.Ciudad + "  " + cliente.Departamento;
                    printCompIng.Valor = saldo.Valor.ToString();
                    printCompIng.Efectivo = pagos.Where(p => p.IdFormaPago == 1).Single().Valor.ToString();
                    printCompIng.Cheque = pagos.Where(p => p.IdFormaPago == 2).Single().Valor.ToString();
                    printCompIng.Numero = n.ToString();
                    printCompIng.Concepto = "Anticipo.";
                    // printCompIng.MdiParent = this.MdiParent;
                    printCompIng.ShowDialog();*/
                }
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
        }
    }
}