using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Utilities;
using CustomControl;
using BussinesLayer.Clases;
using DTO.Clases;
using Microsoft.Reporting.WinForms;

namespace Aplicacion.Ventas.Cliente.Anticipos
{
    public partial class FrmNuevo : Form
    {
        public bool Extend { set; get; }

        public string Nit { set; get; }

        private ErrorProvider miError;

        private bool EfectivoMatch;

        private bool TransaccionMatch;

        private DTO.Clases.Cliente Cliente;

        private BussinesCliente miBussinesCliente;

        private BussinesSaldo miBussinesSaldo;

        private BussinesConsecutivo miBussinesConsecutivo;

        private BussinesEmpresa miBussinesEmpresa;

        public FrmNuevo()
        {
            InitializeComponent();
            this.Extend = false;
            this.Nit = "";
            this.miError = new ErrorProvider();
            this.EfectivoMatch = false;
            this.TransaccionMatch = false;
            this.Cliente = new DTO.Clases.Cliente();
            this.miBussinesCliente = new BussinesCliente();
            this.miBussinesSaldo = new BussinesSaldo();
            this.miBussinesConsecutivo = new BussinesConsecutivo();
            this.miBussinesEmpresa = new BussinesEmpresa();
        }

        private void FrmNuevo_Load(object sender, EventArgs e)
        {
            CompletaEventos.CompletaRemision += new CompletaEventos.CompletaAccionRemision(CompletaEventos_CompletaRemision);

            if(this.Extend)
            {
                this.txtCliente.Text = this.Nit;
                this.txtCliente_KeyPress(this.txtCliente, new KeyPressEventArgs((char)Keys.Enter));
            }
        }

        private void FrmNuevo_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void tsBtnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                this.txtEfectivo_Validating(this.txtEfectivo, new CancelEventArgs(false));
                this.txtTransaccion_Validating(this.txtTransaccion, new CancelEventArgs(false));
                if(this.EfectivoMatch && this.TransaccionMatch)
                {
                    if (UseObject.RemoveSeparatorMil(this.txtEfectivo.Text) > 0 || UseObject.RemoveSeparatorMil(this.txtTransaccion.Text) < 0)
                    {
                        var saldo = new Saldo();
                        saldo.NitCliente = this.Cliente.NitCliente;
                        saldo.IdUsuario = Convert.ToInt32(AppConfiguracion.ValorSeccion("id_user"));
                        saldo.IdCaja = Convert.ToInt32(AppConfiguracion.ValorSeccion("id_caja"));
                        saldo.Fecha = DateTime.Now;
                        saldo.FormasPago = Pagos();
                        saldo.Valor = Convert.ToInt32(saldo.FormasPago.Sum(s => s.Valor));
                        saldo.Ingreso.Numero = miBussinesConsecutivo.Consecutivo("Anticipo");
                        saldo.Ingreso.Concepto = "AANTICIPO.";
                        saldo.Ingreso.Fecha = saldo.Fecha;
                        saldo.Ingreso.Valor = saldo.Valor;
                        saldo.Ingreso.Estado = true;
                        int id = Convert.ToInt32(miBussinesSaldo.IngresarSaldo(saldo));
                        OptionPane.MessageInformation("El anticipo se guardo con exito.");
                        if (Convert.ToBoolean(AppConfiguracion.ValorSeccion("printRboAnticpo")))
                        {
                            PrintAnticipoPos(id);
                        }
                        else
                        {
                            PrintAnticipo(id);
                        }
                        this.Cliente = new DTO.Clases.Cliente();
                        this.txtCliente.Text = "";
                        this.txtNombreCliente.Text = "";
                        this.txtEfectivo.Text = "0";
                        this.txtTransaccion.Text = "0";
                        this.txtCliente.Focus();
                    }
                }
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
        }

        private void tsBtnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtCliente_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (e.KeyChar.Equals((char)Keys.Enter))
                {
                    this.Cliente = this.miBussinesCliente.ClienteAEditar(this.txtCliente.Text);
                    if (this.Cliente.NitCliente == "")
                    {
                        this.miError.SetError(this.txtCliente, "El cliente no existe.");
                    }
                    else
                    {
                        this.miError.SetError(this.txtCliente, null);
                        this.txtNombreCliente.Text = this.Cliente.NombresCliente;
                        this.txtEfectivo.Focus();
                    }
                }
            }
            catch(Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
        }

        private void btnBuscarCliente_Click(object sender, EventArgs e)
        {
            var frmCliente = new Cliente.frmCliente();
            frmCliente.Remision = true;
            frmCliente.tcClientes.SelectedIndex = 1;
            frmCliente.ShowDialog();
        }

        private void txtEfectivo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar.Equals((char)Keys.Enter))
            {
                this.txtTransaccion.Focus();
            }
        }

        private void txtEfectivo_Validating(object sender, CancelEventArgs e)
        {
            if (String.IsNullOrEmpty(this.txtEfectivo.Text))
            {
                this.txtEfectivo.Text = "0";
                this.EfectivoMatch = true;
            }
            else
            {
                if (Validacion.ConFormato
                   (Validacion.TipoValidacion.Numeros, this.txtEfectivo, this.miError, "El valor es incorrecto."))
                {
                    this.EfectivoMatch = true;
                }
                else
                {
                    this.EfectivoMatch = false;
                }
            }
        }

        private void txtTransaccion_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar.Equals((char)Keys.Enter))
            {
                this.tsBtnGuardar_Click(this.tsBtnGuardar, new EventArgs());
            }
        }

        private void txtTransaccion_Validating(object sender, CancelEventArgs e)
        {
            if (String.IsNullOrEmpty(this.txtTransaccion.Text))
            {
                this.txtTransaccion.Text = "0";
                this.TransaccionMatch = true;
            }
            else
            {
                if (Validacion.ConFormato
                   (Validacion.TipoValidacion.Numeros, this.txtTransaccion, this.miError, "El valor es incorrecto."))
                {
                    this.TransaccionMatch = true;
                }
                else
                {
                    this.TransaccionMatch = false;
                }
            }
        }



        void CompletaEventos_CompletaRemision(CompletaArgumentosDeEventoRemision args)
        {
            try
            {
                this.txtCliente.Text = (string)args.MiObjeto;
                this.txtCliente_KeyPress(this.txtCliente, new KeyPressEventArgs((char)Keys.Enter));
                //this.txtTercero_KeyPress(this.txtTercero, new KeyPressEventArgs((char)Keys.Enter));
            }
            catch { }

            try
            {
                //ExtendForm = Convert.ToBoolean(args.MiObjeto);
            }
            catch { }
        }

        private List<FormaPago> Pagos()
        {
            var pagos = new List<FormaPago>();
            if(Convert.ToInt32(this.txtEfectivo.Text) > 0)
            {
                pagos.Add(new FormaPago
                    {
                        IdFormaPago = 1,
                        Valor = Convert.ToInt32(this.txtEfectivo.Text)
                    });
            }
            if (Convert.ToInt32(this.txtTransaccion.Text) > 0)
            {
                pagos.Add(new FormaPago
                {
                    IdFormaPago = 4,
                    Valor = Convert.ToInt32(this.txtTransaccion.Text)
                });
            }
            return pagos;
        }

        private void PrintAnticipo(int id)
        {
            try
            {
                FrmPrint frmPrint = new FrmPrint();
                frmPrint.StringCaption = "Anticipo Cliente";
                frmPrint.StringMessage = "Impresión del Recibo de Anticipo";
                DialogResult rta = frmPrint.ShowDialog();
                var anticipo = miBussinesSaldo.Saldo(id);
                var cliente = this.miBussinesCliente.ClienteAEditar(anticipo.NitCliente);

                var frmPrint_ = new Compras.Egreso.FrmPrintInforme();

                frmPrint_.rpvEgresos.LocalReport.DataSources.Clear();
                frmPrint_.rpvEgresos.LocalReport.Dispose();
                frmPrint_.rpvEgresos.Reset();

                frmPrint_.rpvEgresos.LocalReport.DataSources.Add
                    (new ReportDataSource("DsEmpresa", this.miBussinesEmpresa.PrintEmpresa().Tables[0]));

                frmPrint_.rpvEgresos.LocalReport.ReportPath = AppConfiguracion.ValorSeccion("report") + @"\reports\ReciboAnticipoCliente.rdlc";
                //frmPrint_.rpvEgresos.LocalReport.ReportPath = @"C:\reports\ReciboAnticipoCliente.rdlc";

                var pNo = new ReportParameter();
                pNo.Name = "No";
                pNo.Values.Add(anticipo.Numero);
                frmPrint_.rpvEgresos.LocalReport.SetParameters(pNo);

                var pFecha = new ReportParameter();
                pFecha.Name = "Fecha";
                pFecha.Values.Add(anticipo.Fecha.ToShortDateString());
                frmPrint_.rpvEgresos.LocalReport.SetParameters(pFecha);

                var pCliente = new ReportParameter();
                pCliente.Name = "Cliente";
                pCliente.Values.Add(cliente.NombresCliente);
                frmPrint_.rpvEgresos.LocalReport.SetParameters(pCliente);

                var pNit = new ReportParameter();
                pNit.Name = "Nit";
                pNit.Values.Add(cliente.NitCliente);
                frmPrint_.rpvEgresos.LocalReport.SetParameters(pNit);

                var pDireccion = new ReportParameter();
                pDireccion.Name = "Dir";
                pDireccion.Values.Add(cliente.DireccionCliente + " " + cliente.Ciudad);
                frmPrint_.rpvEgresos.LocalReport.SetParameters(pDireccion);

                var pValor = new ReportParameter();
                pValor.Name = "Valor";
                pValor.Values.Add(anticipo.Valor.ToString());
                frmPrint_.rpvEgresos.LocalReport.SetParameters(pValor);

                var pConcepto = new ReportParameter();
                pConcepto.Name = "Concepto";
                pConcepto.Values.Add("ANTICIPO DE CLIENTE");
                frmPrint_.rpvEgresos.LocalReport.SetParameters(pConcepto);

                var pEfectivo = new ReportParameter();
                pEfectivo.Name = "Efectivo";
                if (anticipo.FormasPago.Where(p => p.IdFormaPago == 1).ToArray().Length > 0)
                {
                    pEfectivo.Values.Add(anticipo.FormasPago.Where(p => p.IdFormaPago == 1).Single().Valor.ToString());
                }
                else
                {
                    pEfectivo.Values.Add("0");
                }
                frmPrint_.rpvEgresos.LocalReport.SetParameters(pEfectivo);

                var pCheque = new ReportParameter();
                pCheque.Name = "Cheque";
                if (anticipo.FormasPago.Where(p => p.IdFormaPago == 2).ToArray().Length > 0)
                {
                    pCheque.Values.Add(anticipo.FormasPago.Where(p => p.IdFormaPago == 2).Single().Valor.ToString());
                }
                else
                {
                    pCheque.Values.Add("0");
                }
                frmPrint_.rpvEgresos.LocalReport.SetParameters(pCheque);


                var pTransaccion = new ReportParameter();
                pTransaccion.Name = "Transaccion";
                if (anticipo.FormasPago.Where(p => p.IdFormaPago == 4).ToArray().Length > 0)
                {
                    pTransaccion.Values.Add(anticipo.FormasPago.Where(p => p.IdFormaPago == 4).Single().Valor.ToString());
                }
                else
                {
                    pTransaccion.Values.Add("0");
                }
                frmPrint_.rpvEgresos.LocalReport.SetParameters(pTransaccion);

                frmPrint_.rpvEgresos.RefreshReport();
                frmPrint_.ShowDialog();
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
        }

        private void PrintAnticipoPos(int id)
        {
            try
            {
                var anticipo = miBussinesSaldo.Saldo(id);

                var miBussinesEmpresa = new BussinesEmpresa();
                var miBussinesCaja = new BussinesCaja();
                var miBussinesUsuario = new BussinesUsuario();
                //var empresaRow = miBussinesEmpresa.PrintEmpresa().Tables[0].AsEnumerable().First();
                var caja = miBussinesCaja.CajaId(anticipo.IdCaja);
                var usuarioRow = miBussinesUsuario.ConsultaUsuario(anticipo.IdUsuario).AsEnumerable().First();
                
                PrintTicket printTicket = new PrintTicket();
                printTicket.UseItem = false;

                printTicket.empresaRow = this.miBussinesEmpresa.PrintEmpresa().Tables[0].AsEnumerable().First();
                printTicket.anticipo = anticipo;
                printTicket.NoCaja = caja.Numero.ToString();
                printTicket.Cliente = this.Cliente;
                printTicket.DetalleRbo = "Anticipo.";
                printTicket.ValorRbo = UseObject.InsertSeparatorMil(anticipo.Valor.ToString());
                printTicket.PagosRbo = anticipo.FormasPago;
                printTicket.ImprimirRboAnticipo();

                /*Ticket ticket = new Ticket();

                ticket.AddHeaderLine(empresaRow["Nombre"].ToString().ToUpper());
                ticket.AddHeaderLine(empresaRow["Juridico"].ToString());
                ticket.AddHeaderLine("NIT " + UseObject.InsertSeparatorMilMasDigito(empresaRow["Nit"].ToString()));
                ticket.AddHeaderLine(empresaRow["Direccion"].ToString());
                ticket.AddHeaderLine("Tels. " + empresaRow["Telefono"].ToString());
                ticket.AddHeaderLine("Fecha : " + anticipo.Fecha.ToShortDateString() +
                                     "    Caja : " + caja.Numero);
                ticket.AddHeaderLine("Cajero(a)  :  " + usuarioRow["nombre"].ToString());
                ticket.AddHeaderLine("===================================");
                ticket.AddHeaderLine("RECIBO DE ANTICIPO No " + anticipo.Numero);
                ticket.AddHeaderLine("===================================");
                ticket.AddHeaderLine("Recibido de : " + this.Cliente.NombresCliente.ToUpper());
                ticket.AddHeaderLine("NIT o C.C.  : " + UseObject.InsertSeparatorMilMasDigito(this.Cliente.NitCliente));
                ticket.AddHeaderLine("===================================");

                ticket.AddItem("",
                               "Anticipo.", UseObject.InsertSeparatorMil(anticipo.Valor.ToString()));

                ticket.AddTotal("TOTAL ", UseObject.InsertSeparatorMil(anticipo.Valor.ToString()));

                ticket.AddTotal(" ", " ");

                foreach (var pago in anticipo.FormasPago)
                {
                    ticket.AddTotal(pago.NombreFormaPago,
                        UseObject.InsertSeparatorMil(pago.Valor.ToString()));
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
                ticket.AddFooterLine("solucionestecnologicasayc@gmail.com");
                ticket.AddFooterLine(".");

                ticket.PrintTicket("IMPREPOS");*/
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
        }
    }
}