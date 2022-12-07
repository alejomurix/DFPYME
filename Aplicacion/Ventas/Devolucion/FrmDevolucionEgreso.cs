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

namespace Aplicacion.Ventas.Devolucion
{
    public partial class FrmDevolucionEgreso : Form
    {
        BussinesEgreso miBussinesEgreso;
        private bool FormExtend = false;

        private ErrorProvider miError;

        private DTO.Clases.Cliente MiCliente;

        public FrmDevolucionEgreso()
        {
            InitializeComponent();
            miBussinesEgreso = new BussinesEgreso();
            miError = new ErrorProvider();
        }

        private void FrmDevolucionEgreso_Load(object sender, EventArgs e)
        {
            CompletaEventos.Completaz += new CompletaEventos.CompletaAccionz(CompletaEventos_Completaz);
        }

        private void txtNit_KeyPress(object sender, KeyPressEventArgs e)
        {
            var miBussinesBeneficia = new BussinesBeneficio();
            if (e.KeyChar.Equals((char)Keys.Enter))
            {
                try
                {
                    if (txtNit.Text.Equals(""))
                    {
                        this.btnBuscarBeneficiario_Click(this.btnBuscarBeneficiario, new EventArgs());
                    }
                    else
                    {
                        var beneficia = miBussinesBeneficia.BeneficiariosNit(txtNit.Text);
                        if (beneficia.Rows.Count.Equals(0))
                        {
                            DialogResult rta = MessageBox.Show("El Beneficiario no existe. \n¿Desea Crearlo?", "Egreso",
                                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                            if (rta.Equals(DialogResult.Yes))
                            {
                                if (!FormExtend)
                                {
                                    var frmBeneficia = new Compras.Beneficiario.FrmBeneficio();
                                    frmBeneficia.MdiParent = this.MdiParent;
                                    frmBeneficia.txtId.Text = txtNit.Text;
                                    frmBeneficia.Add = true;
                                    frmBeneficia.Show();
                                    frmBeneficia.txtId.Focus();
                                    FormExtend = true;
                                }
                            }
                        }
                        else
                        {
                            if (beneficia.Rows.Count > 1)
                            {
                                if (!FormExtend)
                                {
                                    var frmBeneficia = new Compras.Beneficiario.FrmBeneficio();
                                    frmBeneficia.MdiParent = this.MdiParent;
                                    frmBeneficia.tcBeneficio.SelectTab(1);
                                    frmBeneficia.txtConsulta.Text = txtNit.Text;
                                    frmBeneficia.Search = true;
                                    frmBeneficia.Show();
                                    FormExtend = true;
                                }
                            }
                            else
                            {
                                var query = (from data in beneficia.AsEnumerable()
                                             select data).Single();
                                this.MiCliente = new DTO.Clases.Cliente
                                {
                                    IdCiudad = Convert.ToInt32(query["id"]),
                                    IdRegimen = Convert.ToInt32(query["idregimen"]),
                                    NitCliente = query["nit"].ToString(),
                                    NombresCliente = query["nombre"].ToString()
                                };
                                txtNombre.Text = MiCliente.NombresCliente;
                                btnCobro.Focus();
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    OptionPane.MessageError(ex.Message);
                }
            }
        }

        private void btnBuscarBeneficiario_Click(object sender, EventArgs e)
        {
            if (!FormExtend)
            {
                var frmBeneficio = new Compras.Beneficiario.FrmBeneficio();
                frmBeneficio.MdiParent = this.MdiParent;
                frmBeneficio.tcBeneficio.SelectTab(1);
                frmBeneficio.Show();
                frmBeneficio.txtConsulta.Focus();
                FormExtend = true;
            }
        }

        private void btnCobro_Click(object sender, EventArgs e)
        {
            if (MiCliente != null)
            {
                try
                {
                    var miBussinesRetiro = new BussinesRetiro();
                    miError.SetError(txtNombre, null);
                    var egreso = ReintegroEfectivo(MiCliente,
                         Convert.ToInt32( UseObject.RemoveSeparatorMil(txtTotalDevolucion.Text)));
                   /* DialogResult rta = MessageBox.Show("¿Desea imprimir el Egreso?", "Devolución",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (rta.Equals(DialogResult.Yes))
                    {*/
                        if (Convert.ToBoolean(AppConfiguracion.ValorSeccion("printEgresoDevVenta")))
                        {
                            DialogResult rta = MessageBox.Show("¿Desea imprimir el Egreso?", "Devolución",
                                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                            if (rta.Equals(DialogResult.Yes))
                            {
                                PrintEgresoPos(egreso.Numero, miBussinesEgreso.EgresoPuc(egreso.Id));
                            }
                        }
                        else
                        {
                            PrintEgreso(egreso, MiCliente);
                        }
                    //}
                    /*var retiro = new DTO.Clases.Retiro();
                    retiro.Fecha = DateTime.Now;
                    retiro.Caja.Id = Convert.ToInt32(AppConfiguracion.ValorSeccion("id_caja"));
                    retiro.Turno.Id = Convert.ToInt32(AppConfiguracion.ValorSeccion("idturno"));
                    retiro.Usuario.Id = Convert.ToInt32(AppConfiguracion.ValorSeccion("id_user"));
                    retiro.Valores.Add(new FormaPago
                    {
                        IdFormaPago = 1,
                        NombreFormaPago = "EFECTIVO",
                        NumeroFactura = "DEVOLUCIÓN A CLIENTE",
                        Valor = Convert.ToInt32(UseObject.RemoveSeparatorMil(txtTotalDevolucion.Text))
                    });
                    miBussinesRetiro.Ingresar(retiro);
                    PrintRetiroPos(retiro);*/
                    CompletaEventos.CapturaEventoeb(MiCliente);
                    this.Close();
                }
                catch { }
            }
            else
            {
                OptionPane.MessageError("Los datos del beneficiario son requeridos.");
                miError.SetError(txtNombre, "Los datos del beneficiario son requeridos.");
            }
        }

        private void btnCambio_Click(object sender, EventArgs e)
        {
            CompletaEventos.CapturaEventoeb(2001);
            this.Close();
        }

        void CompletaEventos_Completaz(CompletaArgumentosDeEventoz args)
        {
            try
            {
                txtNit.Text = ((DTO.Clases.Cliente)args.MiZona).NitCliente;
                txtNit_KeyPress(this.txtNit, new KeyPressEventArgs((char)Keys.Enter));
            }
            catch { }

            try
            {
                FormExtend = Convert.ToBoolean(args.MiZona);
            }
            catch { }
        }

        private DTO.Clases.Egreso ReintegroEfectivo(DTO.Clases.Cliente cliente, int valorDev)
        {
            try
            {
                var miBussinesConsecutivos = new BussinesConsecutivo();
                var bussinesEgreso = new BussinesEgreso();
                var egreso = new DTO.Clases.Egreso();
                egreso.TipoBeneficiario = cliente.IdCiudad;
                egreso.IdCaja = Convert.ToInt32(AppConfiguracion.ValorSeccion("id_caja"));
                egreso.IdUsuario = Convert.ToInt32(AppConfiguracion.ValorSeccion("id_user"));
                egreso.Numero = miBussinesConsecutivos.Consecutivo("Egreso");
                egreso.Fecha = DateTime.Now;
                egreso.Total = valorDev;
                egreso.Estado = true;
                egreso.Pagos.Add(new DTO.Clases.FormaPago
                {
                    IdFormaPago = 1,
                    Valor = egreso.Total
                });
                egreso.Cuentas.Add(new ConceptoEgreso
                {
                    IdCuenta = Convert.ToInt32(AppConfiguracion.ValorSeccion("ctaEgreso")),
                    Id = Convert.ToInt32(AppConfiguracion.ValorSeccion("ctadevolucioncliente")),
                    Nombre = "Devoluciones de Cliente.",
                    Numero = egreso.Total.ToString()
                });
                egreso.Id = miBussinesEgreso.IngresarEgreso(egreso);
                OptionPane.MessageInformation("El egreso se generó correctamente.");
                return egreso;
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
                return null;
            }
        }

        private void PrintEgreso(Egreso egreso, DTO.Clases.Cliente beneficio)
        {
            try
            {
                /*DialogResult rta = MessageBox.Show("¿Desea visualizar la impresión del Egreso?", "Devolución",
                        MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);*/
                FrmPrint frmPrint = new FrmPrint();
                frmPrint.StringCaption = "Devolución Venta";
                frmPrint.StringMessage = "Impresión del Comprobante de Egreso";
                DialogResult rta = frmPrint.ShowDialog();

                if (!rta.Equals(DialogResult.Cancel))
                {
                    var miBussinesPuc = new BussinesPuc();
                    var tabla = new DataTable();
                    tabla.TableName = "CuentaPuc";
                    tabla.Columns.Add(new DataColumn("Codigo", typeof(int)));
                    tabla.Columns.Add(new DataColumn("Concepto", typeof(string)));
                    tabla.Columns.Add(new DataColumn("Valor", typeof(int)));
                    foreach (var cuenta in egreso.Cuentas)
                    {
                        var row = tabla.NewRow();
                        row["Codigo"] = miBussinesPuc.GetSubCuenta(cuenta.IdCuenta);
                        row["Concepto"] = cuenta.Nombre;
                        row["Valor"] = Convert.ToInt32(cuenta.Numero);
                        tabla.Rows.Add(row);
                    }
                    var printEgreso = new Compras.Egreso.FrmPrintComprobante();
                    printEgreso.Numero = egreso.Numero;
                    printEgreso.Fecha = egreso.Fecha;
                    printEgreso.Remite = beneficio.NombresCliente + "  CC o NIT : " +
                                         beneficio.NitCliente;
                    printEgreso.Cuentas = tabla;
                    printEgreso.Cheque = egreso.Pagos.Where(p => p.IdFormaPago == 2).Sum(s => s.Valor).ToString();
                    printEgreso.Efectivo = egreso.Pagos.Where(p => p.IdFormaPago == 1).Sum(s => s.Valor).ToString();
                    printEgreso.Transaccion = egreso.Pagos.Where(p => p.IdFormaPago == 4).Sum(s => s.Valor).ToString();

                    if (rta.Equals(DialogResult.No))
                    {
                        printEgreso.ShowDialog();
                    }
                    else
                    {
                        Imprimir print = new Imprimir();
                        print.Report = printEgreso.CargarDatos();
                        print.Print(Imprimir.TamanioPapel.MediaCarta);
                        printEgreso.ResetReport();
                    }
                }
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
        }

        private void PrintEgresoPos(string numero, DataTable items)
        {
            try
            {
                int MaxCharacters = 35;

                var miBussinesEmpresa = new BussinesEmpresa();
                var miBussinesUsuario = new BussinesUsuario();
                var miBussinesCaja = new BussinesCaja();
                var miBussinesBeneficia = new BussinesBeneficio();

                var empresaRow = miBussinesEmpresa.PrintEmpresa().
                                 Tables[0].AsEnumerable().First();
                var egreso = miBussinesEgreso.EgresoNumero(numero);
                egreso.Pagos = miBussinesEgreso.PagosEgreso(egreso.Id);
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
                ticket.AddHeaderLine("NIT " + UseObject.InsertSeparatorMilMasDigito(empresaRow["Nit"].ToString()));
                foreach (var datos_ in UseObject.StringBuilderDataIzquierda(empresaRow["Direccion"].ToString().ToUpper(), MaxCharacters))
                {
                    ticket.AddHeaderLine(datos_);
                }
                ticket.AddHeaderLine("Tels. " + empresaRow["Telefono"].ToString());
                ticket.AddHeaderLine("Fecha : " + egreso.Fecha.ToShortDateString() +
                                     "    Caja " + caja.Numero.ToString());
                ticket.AddHeaderLine("Cajero(a)  :  " + usuario["nombre"].ToString());
                ticket.AddHeaderLine("===================================");
                ticket.AddHeaderLine("COMPROBANTE DE EGRESO Nro " + egreso.Numero);
                ticket.AddHeaderLine("===================================");

                foreach (var datos_ in UseObject.StringBuilderDataIzquierda("Remite a : " + beneficio.NombresCliente.ToUpper(), MaxCharacters))
                {
                    ticket.AddHeaderLine(datos_);
                }
                ticket.AddHeaderLine("NIT: " + UseObject.InsertSeparatorMilMasDigito(beneficio.NitCliente));
                ticket.AddHeaderLine("===================================");
                ticket.AddHeaderLine("");
                ticket.AddHeaderLine("      CONCEPTO               VALOR ");
                ticket.AddHeaderLine("");
                int maxCharacters_18 = 18;
                int maxCharacters_15 = 15;
                string valor = "";
                List<string> datos = new List<string>();
                foreach (DataRow cuenta in items.Rows)
                {
                    valor = UseObject.InsertSeparatorMil(cuenta["valor"].ToString());
                    datos = UseObject.StringBuilderDataIzquierda(cuenta["concepto"].ToString(), maxCharacters_18);
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
               // var sTotal = 0;
               // var retencion = 0;
                //var qConcepto = items.AsEnumerable().Where(d => d.Field<int>("IdCuenta") != 0);
                //var qRetenciones = items.AsEnumerable().Where(d => d.Field<int>("IdCuenta") == 0);
                /*if (qConcepto.ToArray().Length != 0)
                {
                    sTotal = Convert.ToInt32(qConcepto.Sum(d => d.Field<int>("Valor")));
                }*/
                /*if (qRetenciones.ToArray().Length != 0)
                {
                    retencion = Convert.ToInt32(qRetenciones.Sum(d => d.Field<int>("Valor")));
                }*/
                /*ticket.AddHeaderLine("         SUBTOTAL :" + UseObject.StringBuilderDetalleTotal(
                        UseObject.InsertSeparatorMil(sTotal.ToString())));*/

                //ticket.AddHeaderLine("      RETENCIONES :" + UseObject.StringBuilderDetalleTotal("0"));

                ticket.AddHeaderLine("            TOTAL :" + UseObject.StringBuilderDetalleTotal(
                    UseObject.InsertSeparatorMil((items.AsEnumerable().Sum(s => s.Field<int>("valor"))).ToString())));


                ticket.AddHeaderLine("");
                var pEfectivo = egreso.Pagos.Where(d => d.IdFormaPago.Equals(1));
                var pCheque = egreso.Pagos.Where(d => d.IdFormaPago.Equals(2));
                var pTransaccion = egreso.Pagos.Where(d => d.IdFormaPago.Equals(4));

                if (pEfectivo.ToArray().Length != 0)
                {
                    ticket.AddHeaderLine("         EFECTIVO :" + UseObject.StringBuilderDetalleTotal(
                    UseObject.InsertSeparatorMil(pEfectivo.Sum(d => d.Valor).ToString())));
                }
                if (pCheque.ToArray().Length != 0)
                {
                    ticket.AddHeaderLine("           CHEQUE :" + UseObject.StringBuilderDetalleTotal(
                    UseObject.InsertSeparatorMil(pCheque.Sum(d => d.Valor).ToString())));
                }
                if (pTransaccion.ToArray().Length != 0)
                {
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
                ticket.AddHeaderLine("");
                ticket.PrintTicket("");



                /*
                ticket.AddHeaderLine(empresaRow["Nombre"].ToString().ToUpper());
                ticket.AddHeaderLine(empresaRow["Juridico"].ToString());
                ticket.AddHeaderLine("NIT " + UseObject.InsertSeparatorMilMasDigito(empresaRow["Nit"].ToString()));
                ticket.AddHeaderLine(empresaRow["Direccion"].ToString());
                ticket.AddHeaderLine("Tels. " + empresaRow["Telefono"].ToString());
                ticket.AddHeaderLine("Fecha : " + egreso.Fecha.ToShortDateString() +
                                     "    Caja " + caja.Numero.ToString());
                ticket.AddHeaderLine("Cajero(a)  :  " + usuario["nombre"].ToString());
                ticket.AddHeaderLine("===================================");
                ticket.AddHeaderLine("COMPROBANTE DE EGRESO Nro " + egreso.Numero);
                ticket.AddHeaderLine("===================================");
                ticket.AddHeaderLine("Remite a : " + beneficio.NombresCliente.ToUpper());
                ticket.AddHeaderLine("NIT: " + UseObject.InsertSeparatorMilMasDigito(beneficio.NitCliente));
                ticket.AddHeaderLine("===================================");
                foreach (DataRow row in items.Rows)
                {
                    ticket.AddItem("",
                                   row["Concepto"].ToString(),
                                   UseObject.InsertSeparatorMil(row["Valor"].ToString()));
                }

                var sTotal = 0;
                var retencion = 0;
                var qConceptos = items.AsEnumerable().Where(d => d.Field<int>("valor") > 0);
                var qRetenciones = items.AsEnumerable().Where(d => d.Field<int>("valor") < 0);
                if (qConceptos.ToArray().Length != 0)
                {
                    sTotal = qConceptos.Sum(d => d.Field<int>("Valor"));
                }
                if (qRetenciones.ToArray().Length != 0)
                {
                    retencion = qRetenciones.Sum(d => d.Field<int>("Valor"));
                }
                ticket.AddTotal("SUBTOTAL     : ", UseObject.InsertSeparatorMil(sTotal.ToString()));
                ticket.AddTotal("RETENCIONES  : ", UseObject.InsertSeparatorMil(retencion.ToString()));
                ticket.AddTotal("TOTAL        : ", UseObject.InsertSeparatorMil((sTotal + retencion).ToString()));
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

                ticket.AddFooterLine("Software: DFPYME");
                ticket.AddFooterLine(".");

                ticket.PrintTicket("");
                */
            }
            catch (Exception ex)
            {
                OptionPane.MessageError("Ocurrió un error al imprimir el Egreso.\n" + ex.Message);
            }
        }

        private void PrintRetiroPos(DTO.Clases.Retiro retiro)
        {
            try
            {
                DialogResult rta = MessageBox.Show("¿Desea imprimir el comprobante de retiro?", "Devolución venta",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (rta.Equals(DialogResult.Yes))
                {
                    var miBussinesEmpresa = new BussinesEmpresa();
                    var miBussinesUsuario = new BussinesUsuario();
                    var miBussinesCaja = new BussinesCaja();
                    var miBussinesTurno = new BussinesTurno();

                    DataRow empresaRow = miBussinesEmpresa.PrintEmpresa().
                            Tables[0].AsEnumerable().First();

                    var usuarioRow = miBussinesUsuario.ConsultaUsuario(retiro.Usuario.Id).
                                                                   AsEnumerable().First();
                    Ticket ticket = new Ticket();
                    ticket.UseItem = false;

                    ticket.AddHeaderLine(empresaRow["Nombre"].ToString().ToUpper());
                    ticket.AddHeaderLine(empresaRow["Juridico"].ToString());
                    ticket.AddHeaderLine("NIT " + UseObject.InsertSeparatorMilMasDigito(empresaRow["Nit"].ToString()));
                    ticket.AddHeaderLine("Régimen: " + empresaRow["Regimen"].ToString());
                    ticket.AddHeaderLine(empresaRow["Direccion"].ToString());
                    ticket.AddHeaderLine("");
                    ticket.AddHeaderLine("RECIBO DE RETIRO");
                    ticket.AddHeaderLine("");
                    ticket.AddHeaderLine("Fecha   : " + retiro.Fecha.ToShortDateString());
                    ticket.AddHeaderLine("Hora    : " + retiro.Fecha.ToShortTimeString());
                    ticket.AddHeaderLine("Usuario : " + usuarioRow["nombre"].ToString());
                    ticket.AddHeaderLine("Caja    : " + miBussinesCaja.CajaId(retiro.Caja.Id).Numero.ToString());
                    ticket.AddHeaderLine("Turno   : " + miBussinesTurno.TurnoId(retiro.Turno.Id).Numero.ToString());
                    ticket.AddHeaderLine("");
                    ticket.AddHeaderLine("");
                    foreach (FormaPago pago in retiro.Valores)
                    {
                        ticket.AddHeaderLine("Concepto : " + pago.NumeroFactura);
                        ticket.AddHeaderLine(pago.NombreFormaPago + " : " +
                            UseObject.InsertSeparatorMil(pago.Valor.ToString()));
                    }
                    ticket.AddHeaderLine("");
                    ticket.AddHeaderLine("");
                    ticket.AddHeaderLine("Frima:");
                    ticket.AddHeaderLine("");
                    ticket.AddHeaderLine("-----------------------------------");
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