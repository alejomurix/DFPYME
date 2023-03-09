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

namespace Aplicacion.Ventas.Remisiones
{
    public partial class FrmAbonoGeneral : Form
    {
        private bool AbonoMatch = false;

        private bool EfectivoMatch = false;

        //private readonly Validacion validacion;

        private readonly ErrorProvider error;

        private readonly BussinesFormaPago miBussinesPago;

        private readonly FormaPago pago;

        public DTO.Clases.Cliente Cliente { set; get; }


        public FrmAbonoGeneral()
        {
            InitializeComponent();

            //validacion = new Validacion();
            error = new ErrorProvider();
            miBussinesPago = new BussinesFormaPago();

            pago = new FormaPago
            {
                Usuario = new Usuario { Id = Convert.ToInt32(AppConfiguracion.ValorSeccion("id_user")) },
                Caja = new Caja { Id = Convert.ToInt32(AppConfiguracion.ValorSeccion("id_caja")) },
                Fecha = DateTime.Now
            };



            /*EsFactura = true;
            
            miBussinesIngreso = new BussinesIngreso();
            miBussinesEgreso = new BussinesEgreso();
            miBussinesBeneficio = new BussinesBeneficio();
            miBussinesConsecutivo = new BussinesConsecutivo();
            */
            //CuentaPuc = Convert.ToInt32(AppConfiguracion.ValorSeccion("abonocomprafac"));
        }

        private void FrmAbonoGeneral_Load(object sender, EventArgs e)
        {
            txtNit.Text = Cliente.NitCliente;
            txtProveedor.Text = Cliente.NombresCliente;
            txtSaldo.Text = UseObject.InsertSeparatorMil(Cliente.Sales.Sum(s => s.Saldo).ToString());
        }

        private void FrmAbonoGeneral_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyData.Equals(Keys.Escape))
            {
                Close();
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
            AbonoMatch = false;
            if (!string.IsNullOrEmpty(txtAbono.Text))
            {
                if(Validacion.ValidNumber(txtAbono.Text))
                {
                    // dif de cero
                    pago.Valor = UseObject.RemoveSeparatorMil(txtAbono.Text);
                    if (pago.Valor > 0)
                    {
                        if (pago.Valor <= Cliente.Sales.Sum(s => s.Saldo))
                        {
                            error.SetError(txtAbono, null);
                            AbonoMatch = true;
                        }
                        else
                        {
                            error.SetError(txtAbono, "El valor del abono no puede ser mayor al saldo.");
                        }
                    }
                    else
                    {
                        error.SetError(txtAbono, "El valor debe ser superior a cero.");
                    }
                }
                else
                {
                    error.SetError(txtAbono, "El valor del abono es inválido.");
                }


                /*
                txtAbono.Text = txtAbono.Text.Replace(".", "");
                if (validacion.ValidarNumeroInt(txtAbono.Text))
                {
                    txtAbono.Text = UseObject.InsertSeparatorMil(txtAbono.Text);
                    AbonoMatch = true;
                }
                else
                {
                    error.SetError(txtAbono, "El valor del abono es inválido.");
                    //OptionPane.MessageError("El valor del abono es inválido.");
                    AbonoMatch = false;
                }
                */
            }
            else
            {
                error.SetError(txtAbono, "El abono no puede estar vacio.");
                //txtAbono.Text = "0";
                //AbonoMatch = true;
            }
        }

        private void txtEfectivo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar.Equals((char)Keys.Enter))
            {
                try
                {
                    Validar();
                    if (AbonoMatch && EfectivoMatch)
                    {
                        if (pago.Valor <= pago.Pago)
                        {
                            txtCambio.Text = UseObject.InsertSeparatorMil((pago.Pago - pago.Valor)
                                .ToString());

                            DialogResult rta = MessageBox.Show("¿Está seguro(a) de querer realizar el abono?",
                                "Pago de remisión", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                            if (rta.Equals(DialogResult.Yes))
                            {
                                //PaymentProcess(Convert.ToInt32(txtAbono.Text));
                                //pago.Valor = UseObject.RemoveSeparatorMil(txtAbono.Text); //Convert.ToInt32(txtAbono.Text);
                                miBussinesPago.IngresarPagoRemision(Cliente, pago);

                                CompletaEventos.CapEvenAbonoRemision(pago);

                                OptionPane.MessageSuccess("El pago a cliente se realizó con éxito.");
                                this.Close();
                            }
                        }
                        else
                        {
                            error.SetError(txtEfectivo, "La forma de pago debe ser igual o mayor al abono.");
                        }
                    }
                }
                catch(Exception ex)
                {
                    OptionPane.MessageError(ex.Message);
                }
            }
        }

        private void txtEfectivo_Validating(object sender, CancelEventArgs e)
        {
            EfectivoMatch = false;
            if (!string.IsNullOrEmpty(txtEfectivo.Text))
            {
                if (Validacion.ValidNumber(txtEfectivo.Text))
                {
                    // dif de cero
                    pago.Pago = Convert.ToInt64(UseObject.RemoveSeparatorMil(txtEfectivo.Text));
                    if (pago.Pago > 0)
                    {
                        pago.IdFormaPago = 1;

                        error.SetError(txtEfectivo, null);
                        EfectivoMatch = true;
                    }
                    else
                    {
                        error.SetError(txtEfectivo, "El valor debe ser superior a cero.");
                    }
                }
                else
                {
                    error.SetError(txtEfectivo, "El valor del efectivo es inválido.");
                }

                /*
                txtEfectivo.Text = txtEfectivo.Text.Replace(".", "");
                if (validacion.ValidarNumeroInt(txtEfectivo.Text))
                {
                    txtEfectivo.Text = UseObject.InsertSeparatorMil(txtEfectivo.Text);
                    EfectivoMatch = true;
                }
                else
                {
                    error.SetError(txtEfectivo, "El valor del efectivo es inválido.");
                    //OptionPane.MessageError("El valor del efectivo es inválido.");
                    //EfectivoMatch = false;
                }*/
            }
            else
            {
                error.SetError(txtEfectivo, "El valor del efectivo no puede ser vacio.");
                //txtEfectivo.Text = "0";
                //EfectivoMatch = true;
            }
        }


        /// <summary>
        /// Valida de nuevo los campos de texto.
        /// </summary>
        private void Validar()
        {
            txtAbono_Validating(this.txtAbono, new CancelEventArgs(false));
            txtEfectivo_Validating(this.txtEfectivo, new CancelEventArgs(false));
        }

        private void PaymentProcess(int paymentValue)
        {
            try
            {
                pago.Valor = paymentValue;
                miBussinesPago.IngresarPagoRemision(Cliente, pago);
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
        }















        /*

        public string NitCliente { set; get; }

        public int CodigoProveedor { set; get; }

        public bool EsFactura { set; get; }

        public bool EsAbonoGeneral = false;

        public List<FacturaVenta> Cartera { set; get; }

        private int CuentaPuc;

        public string IdFactura { set; get; }

        public string NumeroFactura { set; get; }

        public DataRow RowEmpresa { set; get; }



        private BussinesIngreso miBussinesIngreso;

        private BussinesEgreso miBussinesEgreso;

        private BussinesBeneficio miBussinesBeneficio;

        private BussinesConsecutivo miBussinesConsecutivo;

        




        private bool TransacionMatch = false;
        */


        /*
        private void FrmAbonoCompra_Load(object sender, EventArgs e)
        {

        }

        private void FrmAbonoCompra_KeyDown(object sender, KeyEventArgs e)
        {

        }
     
        */




        /*

        private void txtTransaccion_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void txtTransaccion_Validating(object sender, CancelEventArgs e)
        {

        }

       
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



        private void FrmAbonoCompra_FormClosing(object sender, FormClosingEventArgs e)
        {
            CompletaEventos.CapturaEvento(15);
        }

        private void PrintIngreso(string numero)
        {
            try
            {
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

                    
                    foreach (DataRow pRow in tPagos.Rows)
                    {
                        formaPago = pRow["nombre"].ToString();
                        valor = UseObject.InsertSeparatorMil(pRow["valor"].ToString());
                        ticket.AddHeaderLine(UseObject.FuncionEspacio(17 - formaPago.Length) + formaPago + " :" +
                            UseObject.FuncionEspacio(16 - valor.Length) + valor);
                       
                    }
                    
                    
                    valor = UseObject.InsertSeparatorMil(this.Cartera.Sum(c => c.Saldo).ToString());
                    ticket.AddHeaderLine("");
                    ticket.AddHeaderLine("            SALDO :" + UseObject.FuncionEspacio(16 - valor.Length) + valor);
                    

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

        */


    }
}