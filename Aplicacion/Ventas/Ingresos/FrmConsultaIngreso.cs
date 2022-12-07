using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CustomControl;
using BussinesLayer.Clases;
using Utilities;

namespace Aplicacion.Ventas.Ingresos
{
    public partial class FrmConsultaIngreso : Form
    {
        private BussinesIngreso miBussinesIngreso;

        private BussinesCliente miBussinesCliente;

        private BussinesBeneficio miBussinesTercero;

        public FrmConsultaIngreso()
        {
            InitializeComponent();
            miBussinesIngreso = new BussinesIngreso();
            miBussinesCliente = new BussinesCliente();
            miBussinesTercero = new BussinesBeneficio();
        }

        private void FrmConsultaIngreso_Load(object sender, EventArgs e)
        {
            CargarUtilidades();
            dgvIvaContado.AutoGenerateColumns = false;

            CompletaEventos.Completabo += new CompletaEventos.CompletaAccionbo(CompletaEventos_Completabo);
        }

        private void FrmConsultaIngreso_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData.Equals(Keys.F5))
            {
                string rta = CustomControl.OptionPane.OptionBox
                    ("Ingresar contraseña. .", "Contraseña", CustomControl.OptionPane.Icon.LoginAdmin);
                if (rta.Equals("ingreso2014"))
                {
                    try
                    {
                        miBussinesIngreso.ActualizarNit();
                        OptionPane.MessageInformation("Los datos se ajustarón con exito.");
                    }
                    catch (Exception ex)
                    {
                        OptionPane.MessageError(ex.Message);
                    }
                }
            }
            else
            {
                if (e.KeyData.Equals(Keys.F4))
                {
                    string rta = CustomControl.OptionPane.OptionBox
                        ("Ingresar contraseña. .", "Contraseña", CustomControl.OptionPane.Icon.LoginAdmin);
                    if (rta.Equals("ingreso2014"))
                    {
                        try
                        {
                            var frmReplica = new FrmReplicas();
                            frmReplica.dgvReplicas.DataSource = miBussinesIngreso.Replicas();
                            frmReplica.Show();
                        }
                        catch (Exception ex)
                        {
                            OptionPane.MessageError(ex.Message);
                        }
                    }
                }
                else
                {
                    if (e.KeyData.Equals(Keys.F3))
                    {
                        string rta = CustomControl.OptionPane.OptionBox
                            ("Ingresar contraseña. .", "Contraseña", CustomControl.OptionPane.Icon.LoginAdmin);
                        if (rta.Equals("ingreso2014"))
                        {
                            try
                            {
                                var frmReplica = new FrmReplicas();
                                frmReplica.dgvReplicas.DataSource = miBussinesIngreso.VerIngresosRemision();
                                frmReplica.Show();
                            }
                            catch (Exception ex)
                            {
                                OptionPane.MessageError(ex.Message);
                            }
                        }
                    }
                }
            }
        }

        private void tsBtnListarTodos_Click(object sender, EventArgs e)
        {
            try
            {
                dgvIvaContado.DataSource = miBussinesIngreso.Ingresos(0, 1000000);
                ColorearGrid();
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
        }

        private void tsBtnCopia_Click(object sender, EventArgs e)
        {
            if (dgvIvaContado.RowCount != 0)
            {
                try
                {
                    /*DialogResult rta = MessageBox.Show("¿Desea visualizar la impresión del comprobante de ingreso?", "Abono a Factura",
                    MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);*/
                    var numero = dgvIvaContado.CurrentRow.Cells["Numero"].Value.ToString();
                    if (Convert.ToBoolean(AppConfiguracion.ValorSeccion("printIngreso")))
                    {
                        if (Convert.ToBoolean(AppConfiguracion.ValorSeccion("print_termal_80mm")))
                        {
                            PrintIngresoPos(numero);
                        }
                        else
                        {
                            PrintIngresoPos50mm(numero);
                        }
                    }
                    else
                    {
                        FrmPrint frmPrint = new FrmPrint();
                        frmPrint.StringCaption = "Consulta de Ingresos";
                        frmPrint.StringMessage = "Impresión del Comprobante de Ingreso";
                        DialogResult rta = frmPrint.ShowDialog();

                        if (!rta.Equals(DialogResult.Cancel))
                        {

                            //var idTipo = Convert.ToInt32(dgvIvaContado.CurrentRow.Cells["Tipo"].Value);
                            var gridRow = this.dgvIvaContado.CurrentRow;

                            //var cliente = miBussinesCliente.ClienteAEditar(gridRow.Cells["NitCliente"].Value.ToString());
                            DTO.Clases.Cliente cliente;
                            if (Convert.ToInt32(dgvIvaContado.CurrentRow.Cells["Tipo"].Value).Equals(1))
                            {
                                cliente = miBussinesCliente.ClienteAEditar(gridRow.Cells["NitCliente"].Value.ToString());
                            }
                            else
                            {
                                cliente = miBussinesTercero.BeneficiarioNit(gridRow.Cells["NitCliente"].Value.ToString());
                            }

                            var tPagos = miBussinesIngreso.FormasPagoIngresoVenta(Convert.ToInt32(gridRow.Cells["Id"].Value));

                            var printIngreso = new Cliente.FrmPrintAnticipo();
                            printIngreso.Numero = numero;
                            printIngreso.Fecha = Convert.ToDateTime(gridRow.Cells["Fecha"].Value);
                            printIngreso.Cliente = cliente.NombresCliente;
                            printIngreso.Nit = cliente.NitCliente;
                            printIngreso.Direccion =
                                cliente.DireccionCliente + "  " + cliente.Ciudad + "  " + cliente.Departamento;
                            printIngreso.Concepto = gridRow.Cells["Concepto"].Value.ToString();
                            printIngreso.Valor = gridRow.Cells["Valor"].Value.ToString();
                            printIngreso.Efectivo = tPagos.AsEnumerable().
                                Where(p => p.Field<int>("idforma_pago").Equals(1)).Sum(s => s.Field<int>("valor")).ToString();
                            printIngreso.Cheque = tPagos.AsEnumerable().
                                Where(p => p.Field<int>("idforma_pago").Equals(2)).Sum(s => s.Field<int>("valor")).ToString();
                            printIngreso.Transaccion = tPagos.AsEnumerable().
                                Where(p => p.Field<int>("idforma_pago").Equals(4)).Sum(s => s.Field<int>("valor")).ToString();

                            if (rta.Equals(DialogResult.No))
                            {
                                printIngreso.ShowDialog();
                            }
                            else
                            {
                                Imprimir print = new Imprimir();
                                print.Report = printIngreso.CargarDatos();
                                print.Print(Imprimir.TamanioPapel.MediaCarta);
                                printIngreso.ResetReport();
                            }


                            /*var printIngreso = new Cliente.FrmPrintAnticipo();
                            printIngreso.Fecha = Convert.ToDateTime(dgvIvaContado.CurrentRow.Cells["Fecha"].Value);
                            printIngreso.Numero = numero;
                            printIngreso.Concepto = dgvIvaContado.CurrentRow.Cells["Concepto"].Value.ToString();
                            printIngreso.Valor = dgvIvaContado.CurrentRow.Cells["Valor"].Value.ToString();

                            var cliente = miBussinesIngreso.ClienteConSaldo(numero, idTipo);
                            if (cliente.Rows.Count != 0)
                            {
                                var query = (from d in cliente.AsEnumerable() select d).First();
                                printIngreso.Nit = query["nitcliente"].ToString();
                                printIngreso.Cliente = query["nombrescliente"].ToString();
                                printIngreso.Direccion = query["telefonocliente"].ToString() + "  " +
                                                         query["celularcliente"].ToString() + "  " +
                                                         query["emailcliente"].ToString();
                            }
                            if (idTipo.Equals(1))
                            {
                                var pagos = miBussinesIngreso.PagosAnticipoCliente(numero, idTipo);
                                printIngreso.Efectivo = pagos.AsEnumerable().
                                            Where(p => p.Field<int>("id_forma_pago").Equals(1)).
                                            Sum(s => s.Field<int>("valor")).ToString();
                                printIngreso.Cheque = pagos.AsEnumerable().
                                            Where(p => p.Field<int>("id_forma_pago").Equals(2)).
                                            Sum(s => s.Field<int>("valor")).ToString();
                            }
                            else
                            {
                                //printIngreso.DsFormas = miBussinesIngreso.AbonosVenta(numero, idTipo);
                                var pagos = miBussinesIngreso.AbonosVenta(numero, idTipo);
                                printIngreso.Efectivo = pagos.AsEnumerable().
                                            Where(p => p.Field<int>("IdForma").Equals(1)).
                                            Sum(s => s.Field<int>("Valor")).ToString();
                                printIngreso.Cheque = pagos.AsEnumerable().
                                            Where(p => p.Field<int>("IdForma").Equals(2)).
                                            Sum(s => s.Field<int>("Valor")).ToString();
                            }
                            printIngreso.MdiParent = this.MdiParent;
                            if (rta.Equals(DialogResult.No))
                            {
                                printIngreso.Show();
                            }
                            else
                            {
                                Imprimir print = new Imprimir();
                                print.Report = printIngreso.CargarDatos();
                                print.Print(Imprimir.TamanioPapel.MediaCarta);
                                printIngreso.ResetReport();
                            }*/
                            //}
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
                OptionPane.MessageInformation("No hay registros para imprimir.");
            }
        }

        private void tsBtnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cbCriterio_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (Convert.ToInt32(cbCriterio.SelectedValue).Equals(1))
            {
                cbFecha.SelectedIndex = 0;
                cbFecha_SelectionChangeCommitted(this.cbFecha, new EventArgs());
                txtNumero.Enabled = true;
                txtNumero.Focus();
                cbFecha.Enabled = false;
                dtpFecha.Enabled = false;
                dtpFecha1.Enabled = false;
                btnBuscarCliente.Enabled = false;
            }
            else
            {
                if (Convert.ToInt32(cbCriterio.SelectedValue).Equals(2))
                {
                    btnBuscarCliente.Enabled = false;
                    txtNumero.Enabled = false;
                    cbFecha.Enabled = true;
                    dtpFecha.Enabled = true;
                    this.txtNumero.Text = "";
                }
                else
                {
                    btnBuscarCliente.Enabled = true;
                    cbFecha.Enabled = true;
                    dtpFecha.Enabled = true;
                    txtNumero.Text = "";
                    txtNumero.Enabled = true;

                    cbFecha.SelectedIndex = 0;
                    cbFecha_SelectionChangeCommitted(this.cbFecha, new EventArgs());
                }
            }
        }

        private void cbFecha_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (Convert.ToInt32(cbFecha.SelectedValue).Equals(0))
            {
                dtpFecha.Enabled = false;
                dtpFecha1.Enabled = false;
            }
            else
            {
                if (Convert.ToInt32(cbFecha.SelectedValue).Equals(1))
                {
                    dtpFecha.Enabled = true;
                    dtpFecha1.Enabled = false;
                }
                else
                {
                    dtpFecha.Enabled = true;
                    dtpFecha1.Enabled = true;
                }
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(cbCriterio.SelectedValue).Equals(1))//número
            {
                Ingresos(txtNumero.Text);
            }
            else//fecha
            {
                if (Convert.ToInt32(cbCriterio.SelectedValue).Equals(2)) // fecha
                {
                    if (Convert.ToInt32(cbFecha.SelectedValue).Equals(1))//simple
                    {
                        Ingresos(dtpFecha.Value);
                    }
                    else//periodo
                    {
                        Ingresos(dtpFecha.Value, dtpFecha1.Value);
                    }
                }
                else   //  cliente
                {
                    if (Convert.ToInt32(cbFecha.SelectedValue).Equals(1))//simple
                    {
                        Ingresos(txtNumero.Text, dtpFecha.Value, dtpFecha.Value);
                    }
                    else//periodo
                    {
                        Ingresos(txtNumero.Text, dtpFecha.Value, dtpFecha1.Value);
                    }
                }
            }
            ColorearGrid();
        }

        private void txtNumero_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar.Equals((char)Keys.Enter))
            {
                this.btnBuscar_Click(this.btnBuscar, new EventArgs());
            }
        }

        private void CargarUtilidades()
        {
            var lst = new List<Aplicacion.Inventario.Producto.Criterio>();
            lst.Add(new Inventario.Producto.Criterio
            {
                Id = 1,
                Nombre = "Número"
            });
            lst.Add(new Inventario.Producto.Criterio
            {
                Id = 2,
                Nombre = "Fecha"
            });
            lst.Add(new Inventario.Producto.Criterio
            {
                Id = 3,
                Nombre = "Cliente"
            });
            cbCriterio.DataSource = lst;

            lst = new List<Inventario.Producto.Criterio>();
            /*lst.Add(new Inventario.Producto.Criterio
            {
                Id = 1,
                Nombre = ""
            });*/
            lst.Add(new Inventario.Producto.Criterio
            {
                Id = 1,
                Nombre = "Fecha"
            });
            lst.Add(new Inventario.Producto.Criterio
            {
                Id = 2,
                Nombre = "Periodo"
            });
            cbFecha.DataSource = lst;
        }

        private void Ingresos(string numero)
        {
            try
            {
                dgvIvaContado.DataSource = miBussinesIngreso.Ingresos(numero);
                if (dgvIvaContado.RowCount.Equals(0))
                {
                    OptionPane.MessageInformation("No se encontrarón registros con ese Número.");
                }
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
        }

        private void Ingresos(DateTime fecha)
        {
            try
            {
                dgvIvaContado.DataSource = miBussinesIngreso.Ingresos(fecha);
                if (dgvIvaContado.RowCount.Equals(0))
                {
                    OptionPane.MessageInformation("No se encontrarón registros en esa fecha.");
                }
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
        }

        private void Ingresos(DateTime fecha, DateTime fecha2)
        {
            try
            {
                dgvIvaContado.DataSource = miBussinesIngreso.Ingresos(fecha, fecha2);
                if (dgvIvaContado.RowCount.Equals(0))
                {
                    OptionPane.MessageInformation("No se encontrarón registros en ese periodo.");
                }
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
        }

        private void Ingresos(string nitCliente, DateTime fecha, DateTime fecha2)
        {
            try
            {
                dgvIvaContado.DataSource = miBussinesIngreso.Ingresos(nitCliente, fecha, fecha2);
                if (dgvIvaContado.RowCount.Equals(0))
                {
                    OptionPane.MessageInformation("No se encontrarón registros en ese periodo.");
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
                tIngresos = miBussinesIngreso.Ingresos(numero);
                var ingresoRow = tIngresos.AsEnumerable().First();
                tPagos = miBussinesIngreso.FormasPagoIngresoVenta(Convert.ToInt32(ingresoRow["id"]));

                var caja = miBussinesCaja.CajaId(Convert.ToInt32(ingresoRow["idcaja"]));
                var usuario = miBussinesUsuario.ConsultaUsuario(Convert.ToInt32(ingresoRow["idusuario"])).
                    AsEnumerable().First()["nombre"].ToString();

                //var cliente = miBussinesCliente.ClienteAEditar(ingresoRow["nitcliente"].ToString());
                DTO.Clases.Cliente cliente;
                if (Convert.ToInt32(dgvIvaContado.CurrentRow.Cells["Tipo"].Value).Equals(1))
                {
                    cliente = miBussinesCliente.ClienteAEditar(ingresoRow["nitcliente"].ToString());
                }
                else
                {
                    cliente = miBussinesTercero.BeneficiarioNit(ingresoRow["nitcliente"].ToString());
                }

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
                ticket.AddHeaderLine("Recibido de : " + cliente.NombresCliente);
                ticket.AddHeaderLine("NIT o C.C.  : " + UseObject.InsertSeparatorMilMasDigito(cliente.NitCliente));
                ticket.AddHeaderLine("===================================");
                /*ticket.AddItem("",
                               ingresoRow["concepto"].ToString(),
                               UseObject.InsertSeparatorMil(ingresoRow["valor"].ToString()));

                ticket.AddTotal("TOTAL ", UseObject.InsertSeparatorMil(ingresoRow["valor"].ToString()));

                ticket.AddTotal(" ", " ");
                foreach (DataRow pRow in tPagos.Rows)
                {
                    ticket.AddTotal(pRow["nombre"].ToString(),
                                UseObject.InsertSeparatorMil(pRow["valor"].ToString()));
                }
                ticket.AddFooterLine("===================================");
                ticket.AddFooterLine("Saldo : $" + UseObject.InsertSeparatorMil(
                    miBussinesFactura.SaldoPorCliente(2, cliente.NitCliente).ToString()));*/

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
                valor = UseObject.InsertSeparatorMil(
                    miBussinesFactura.SaldoPorCliente(2, cliente.NitCliente).ToString());
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
                ticket.AddHeaderLine("Software: Digital Fact Pyme");
                //ticket.AddFooterLine("solucionestecnologicasayc@gmail.com");
                ticket.AddHeaderLine("");

                ticket.PrintTicket("IMPREPOS");
                //ticket.PrintTicket("Microsoft XPS Document Writer");


                /*var miBussinesEmpresa = new BussinesEmpresa();
                var miBussinesIngreso = new BussinesIngreso();
                var miBussinesUsuario = new BussinesUsuario();
                var miBussinesFactura = new BussinesFacturaVenta();

                var empresaRow = miBussinesEmpresa.PrintEmpresa().
                                 Tables[0].AsEnumerable().First();
                var ingresoRow = miBussinesIngreso.Ingresos(numero).AsEnumerable().First();

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
                    clienteRow = miBussinesFactura.ClienteDeFacutura(queryFactura.First().Key).AsEnumerable().First();
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
                ticket.AddHeaderLine("Recibido de : " + clienteRow["nombrescliente"].ToString());
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
                    var j = pRow["FormaPago"].ToString() + 
                                    UseObject.InsertSeparatorMil(pRow["Valor"].ToString());
                }
                ticket.AddFooterLine("===================================");
                ticket.AddFooterLine("Saldo : $" + 
                    UseObject.InsertSeparatorMil(ingresoRow["saldo"].ToString()));
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
            catch (Exception ex)
            {
                OptionPane.MessageError("Ocurrió un error al imprimir el comprobante.\n" + ex.Message);
            }
        }

        private void PrintIngresoPos50mm(string numero)
        {
            try
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
                tIngresos = miBussinesIngreso.Ingresos(numero);
                var ingresoRow = tIngresos.AsEnumerable().First();
                tPagos = miBussinesIngreso.FormasPagoIngresoVenta(Convert.ToInt32(ingresoRow["id"]));

                var caja = miBussinesCaja.CajaId(Convert.ToInt32(ingresoRow["idcaja"]));
                var usuario = miBussinesUsuario.ConsultaUsuario(Convert.ToInt32(ingresoRow["idusuario"])).
                    AsEnumerable().First()["nombre"].ToString();

                //var cliente = miBussinesCliente.ClienteAEditar(ingresoRow["nitcliente"].ToString());
                DTO.Clases.Cliente cliente;
                if (Convert.ToInt32(dgvIvaContado.CurrentRow.Cells["Tipo"].Value).Equals(1))
                {
                    cliente = miBussinesCliente.ClienteAEditar(ingresoRow["nitcliente"].ToString());
                }
                else
                {
                    cliente = miBussinesTercero.BeneficiarioNit(ingresoRow["nitcliente"].ToString());
                }

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
                ticket.AddHeaderLine("SALDO: $        " + UseObject.InsertSeparatorMil(
                    miBussinesFactura.SaldoPorCliente(2, cliente.NitCliente).ToString()));
                ticket.AddHeaderLine("---------------------------");
                ticket.AddHeaderLine("");
                ticket.AddHeaderLine("");
                ticket.AddHeaderLine("Atendido por: " + usuario.Substring(0, 13));
                ticket.AddHeaderLine("");
                ticket.PrintTicket("");




                /*
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
                ticket.AddHeaderLine("Recibido de : " + cliente.NombresCliente);
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
                valor = UseObject.InsertSeparatorMil(
                    miBussinesFactura.SaldoPorCliente(2, cliente.NitCliente).ToString());
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
                ticket.AddHeaderLine("Software: Digital Fact Pyme");
                //ticket.AddFooterLine("solucionestecnologicasayc@gmail.com");
                ticket.AddHeaderLine("");

                ticket.PrintTicket("IMPREPOS");*/
                //ticket.PrintTicket("Microsoft XPS Document Writer");


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

        private void ColorearGrid()
        {
            foreach (DataGridViewRow row in this.dgvIvaContado.Rows)
            {
                if (!Convert.ToBoolean(row.Cells["Estado"].Value))
                {
                    row.DefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(200, 128, 128);
                }
            }
        }

        private void btnBuscarCliente_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(cbCriterio.SelectedValue).Equals(3))
            {
                
                    var frmCliente = new Cliente.frmCliente();
                    //frmCliente.MdiParent = this.MdiParent;
                    frmCliente.tcClientes.SelectedIndex = 1;
                    frmCliente.ConsultaVenta = true;
                    frmCliente.ShowDialog();
                
            }
        }


        void CompletaEventos_Completabo(CompletaArgumentosDeEventobo args)
        {
            try
            {
                txtNumero.Text = (string)args.MiBodegabo;
            }
            catch { }
            //CapturaEventobo
        }
    }
}