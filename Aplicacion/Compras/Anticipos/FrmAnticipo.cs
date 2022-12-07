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

namespace Aplicacion.Compras.Anticipos
{
    public partial class FrmAnticipo : Form
    {
        private bool Transfer { set; get; }

        private int CuentaTerceros { set; get; }

        private int IdCuentaEgreso { set; get; }

        private Cliente Tercero { set; get; }

        private DataTable TConceptos { set; get; }

        private ErrorProvider miError;

        private bool ConceptoMatch { set; get; }

        private bool ValorMatch { set; get; }

        private int Contador { set; get; }

        private bool EfectivoMatch { set; get; }

        private bool ChequeMatch { set; get; }

        private bool TransaccionMatch { set; get; }

        private BindingSource miBindingSource;

        private BussinesPuc miBussinesPuc;

        private BussinesBeneficio miBussinesTercero;

        private BussinesEgreso miBussinesEgreso;

        private BussinesAnticipo miBussinesAnticipo;

        private BussinesConsecutivo miBussinesConsecutivo;

        public FrmAnticipo()
        {
            InitializeComponent();
            this.Transfer = false;
            //this.CuentaTerceros = 2;
            try
            {
                this.CuentaTerceros = Convert.ToInt32(AppConfiguracion.ValorSeccion("prestamoAnticipo"));
                this.IdCuentaEgreso = Convert.ToInt32(AppConfiguracion.ValorSeccion("ctaEgreso"));
            }
            catch(Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
            this.TConceptos = new DataTable();
            this.miError = new ErrorProvider();
            this.ConceptoMatch = false;
            this.ValorMatch = false;
            this.Contador = 1;
            this.miBindingSource = new BindingSource();
            this.EfectivoMatch = false;
            this.ChequeMatch = false;
            this.TransaccionMatch = false;

            miBussinesPuc = new BussinesPuc();
            miBussinesTercero = new BussinesBeneficio();
            miBussinesEgreso = new BussinesEgreso();
            miBussinesAnticipo = new BussinesAnticipo();
            miBussinesConsecutivo = new BussinesConsecutivo();
        }

        private void FrmAnticipo_Load(object sender, EventArgs e)
        {
            CargarDatos();
            CompletaEventos.Completaz += 
                new CompletaEventos.CompletaAccionz(CompletaEventos_Completaz);

            dgvConceptos.AutoGenerateColumns = false;
            dgvConceptos.DataSource = miBindingSource;
        }

        private void FrmAnticipo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData.Equals(Keys.F2))
            {
                this.tsBtnGuardar_Click(this.tsBtnGuardar, new EventArgs());
            }
            else
            {
                if (e.KeyData.Equals(Keys.Escape))
                {
                    this.Close();
                }
            }
        }

        private void tsBtnGuardar_Click(object sender, EventArgs e)
        {
            if (dgvConceptos.RowCount != 0)
            {
                this.txtEfectivo_Validating(this.txtEfectivo, null);
                this.txtCheque_Validating(this.txtCheque, null);
                this.txtTransaccion_Validating(this.txtTransaccion, null);
                if (EfectivoMatch && ChequeMatch && TransaccionMatch)
                {
                    if (this.Tercero != null)
                    {
                        var suma = Convert.ToInt32(UseObject.RemoveSeparatorMil(txtEfectivo.Text)) +
                                   Convert.ToInt32(UseObject.RemoveSeparatorMil(txtCheque.Text)) +
                                   Convert.ToInt32(UseObject.RemoveSeparatorMil(txtTransaccion.Text));
                        if (suma.Equals(Convert.ToInt32(UseObject.RemoveSeparatorMil(txtTotal.Text))))
                        {
                            DialogResult rta = MessageBox.Show
                                ("¿Está seguro de querer generar el Préstamo/Anticipo?", "Préstamos y Anticipos",
                                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                            if (rta.Equals(DialogResult.Yes))
                            {
                                try
                                {
                                    var egreso = new DTO.Clases.Egreso();
                                    egreso.IdUsuario = Convert.ToInt32(AppConfiguracion.ValorSeccion("id_user"));
                                    egreso.IdCaja = Convert.ToInt32(AppConfiguracion.ValorSeccion("id_caja"));
                                    egreso.Numero = miBussinesConsecutivo.Consecutivo("Egreso");
                                    egreso.Fecha = DateTime.Now;
                                    egreso.Total = Convert.ToInt32(UseObject.RemoveSeparatorMil(txtTotal.Text));
                                    egreso.TipoBeneficiario = this.Tercero.IdCiudad;
                                    egreso.Cuentas = Conceptos();
                                    egreso.Pagos = Pagos();
                                    var idEgreso = egreso.Id = miBussinesEgreso.IngresarEgreso(egreso);

                                    var anticipo = new Anticipo();
                                    anticipo.IdCuenta = Convert.ToInt32(cbCuentas.SelectedValue);
                                    anticipo.TipoBeneficiario = this.Tercero.IdCiudad;
                                    anticipo.IdEgreso = idEgreso;
                                    anticipo.Fecha = DateTime.Now;
                                    anticipo.Conceptos = egreso.Cuentas;
                                    anticipo.Pagos = egreso.Pagos;
                                    miBussinesAnticipo.IngresarAnticipoTercero(anticipo);

                                    if (Convert.ToBoolean(AppConfiguracion.ValorSeccion("printEgreso")))
                                    {
                                        PrintEgresoPos(egreso.Numero);
                                    }
                                    else
                                    {
                                        PrintEgreso(egreso);
                                    }
                                    LimpiarFormulario();
                                }
                                catch (Exception ex)
                                {
                                    OptionPane.MessageError(ex.Message);
                                }
                            }
                        }
                        else
                        {
                            OptionPane.MessageInformation("La suma de las formas de pago debe igual al total.");
                        }
                    }
                    else
                    {
                        OptionPane.MessageInformation("Debe ingresar un Tercero.");
                    }
                }
            }
            else
            {
                OptionPane.MessageInformation("Debe cargar al menos un concepto");
            }
        }

        private void tsBtnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtNit_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar.Equals((char)Keys.Enter))
            {
                try
                {
                    var tTercero = miBussinesTercero.BeneficiariosNit(txtNit.Text);
                    if (tTercero.Rows.Count.Equals(0))
                    {
                        DialogResult rta = MessageBox.Show("El Tercero no existe. \n¿Desea Crearlo?", "Anticipos y Préstamos",
                            MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (rta.Equals(DialogResult.Yes))
                        {
                            var frmBeneficia = new Beneficiario.FrmBeneficio();
                            frmBeneficia.txtId.Text = txtNit.Text;
                            frmBeneficia.Add = true;
                            Transfer = true;
                            frmBeneficia.ShowDialog();
                        }
                    }
                    else
                    {
                        var query = (from data in tTercero.AsEnumerable()
                                     select data).First();
                        this.Tercero = new Cliente
                        {
                            IdCiudad = Convert.ToInt32(query["id"]),
                            IdRegimen = Convert.ToInt32(query["idregimen"]),
                            NitCliente = query["nit"].ToString(),
                            NombresCliente = query["nombre"].ToString()
                        };
                        txtTercero.Text = "NIT o CC: " + Tercero.NitCliente + " - " + Tercero.NombresCliente;
                        txtNit.Text = "";
                        cbCuentas.Focus();
                    }
                }
                catch (Exception ex)
                {
                    OptionPane.MessageError(ex.Message);
                }
            }
        }

        private void btnBuscarTercero_Click(object sender, EventArgs e)
        {
            var frmBeneficio = new Beneficiario.FrmBeneficio();
            frmBeneficio.tcBeneficio.SelectTab(1);
            this.Transfer = true;
            frmBeneficio.ShowDialog();
        }

        private void cbCuentas_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar.Equals((char)Keys.Enter))
            {
                this.txtConcepto.Focus();
            }
        }

        private void txtConcepto_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar.Equals((char)Keys.Enter))
            {
                txtValor.Focus();
            }
        }

        private void txtConcepto_Validating(object sender, CancelEventArgs e)
        {
            if (!String.IsNullOrEmpty(txtConcepto.Text))
            {
                this.ConceptoMatch = true;
                miError.SetError(txtConcepto, null);
                this.txtConcepto.Text = this.txtConcepto.Text.ToUpper();
            }
            else
            {
                miError.SetError(txtConcepto, "El campo Concepto es requerido.");
                this.ConceptoMatch = false;
            }
        }

        private void txtValor_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar.Equals((char)Keys.Enter))
            {
                this.btnAgregar_Click(this.btnAgregar, new EventArgs());
            }
        }

        private void txtValor_Validating(object sender, CancelEventArgs e)
        {
            if (!String.IsNullOrEmpty(txtValor.Text))
            {
                if (Validacion.ConFormato
                    (Validacion.TipoValidacion.Numeros, txtValor, miError, "El valor es incorrecto."))
                {
                    this.ValorMatch = true;
                    miError.SetError(txtValor, null);
                }
                else
                {
                    this.ValorMatch = false;
                }
            }
            else
            {
                miError.SetError(txtValor, "El campo Valor es requerido.");
                this.ValorMatch = false;
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            this.txtConcepto_Validating(this.txtConcepto, null);
            this.txtValor_Validating(this.txtValor, null);
            if (this.ConceptoMatch && this.ValorMatch)
            {
                try
                {
                    var row = TConceptos.NewRow();
                    row["Id"] = Contador;
                    row["IdCuenta"] = IdCuentaEgreso;
                    row["Concepto"] = txtConcepto.Text;
                    row["Valor"] = Convert.ToInt32(txtValor.Text);
                    TConceptos.Rows.Add(row);
                    this.Contador++;
                    RecargarGridView();
                    txtConcepto.Focus();
                    txtConcepto.Text = "";
                    txtValor.Text = "";
                }
                catch (Exception ex)
                {
                    OptionPane.MessageError(ex.Message);
                }
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvConceptos.RowCount != 0)
            {
                DialogResult rta = MessageBox.Show("¿Está seguro(a) de retirar el registro?", "Préstamos y Anticipos",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (rta.Equals(DialogResult.Yes))
                {
                    try
                    {
                        var id = Convert.ToInt32(dgvConceptos.CurrentRow.Cells["Id"].Value);
                        var row = (from data in TConceptos.AsEnumerable()
                                   where data.Field<int>("Id").Equals(id)
                                   select data).First();
                        TConceptos.Rows.Remove(row);
                        if (TConceptos.Rows.Count != 0)
                        {
                            RecargarGridView();
                        }
                        else
                        {
                            this.dgvConceptos.Rows.RemoveAt(
                                this.dgvConceptos.CurrentCell.RowIndex);
                            txtTotal.Text = "0";
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
                OptionPane.MessageInformation("No hay registro para retirar.");
            }
        }

        private void txtEfectivo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar.Equals((char)Keys.Enter))
            {
                this.miError.SetError(this.txtConcepto, null);
                this.miError.SetError(this.txtValor, null);
                txtCheque.Focus();
            }
        }

        private void txtEfectivo_Validating(object sender, CancelEventArgs e)
        {
            if (!String.IsNullOrEmpty(txtEfectivo.Text))
            {
                this.txtEfectivo.Text = this.txtEfectivo.Text.Replace(".", "");
                if (Validacion.ConFormato
                    (Validacion.TipoValidacion.Numeros, txtEfectivo, miError, "El valor que ingreso es incorrecto."))
                {
                    this.txtEfectivo.Text = UseObject.InsertSeparatorMil(this.txtEfectivo.Text);
                    EfectivoMatch = true;
                }
                else
                {
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
                this.txtCheque.Text = this.txtCheque.Text.Replace(".", "");
                if (Validacion.ConFormato
                    (Validacion.TipoValidacion.Numeros, txtCheque, miError, "El valor que ingreso es incorrecto."))
                {
                    this.txtCheque.Text = UseObject.InsertSeparatorMil(this.txtCheque.Text);
                    ChequeMatch = true;
                }
                else
                {
                    ChequeMatch = false;
                }
            }
            else
            {
                txtCheque.Text = "0";
                ChequeMatch = true;
            }
        }

        private void txtTransaccion_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar.Equals((char)Keys.Enter))
            {
                this.txtTransaccion_Validating(this.txtTransaccion, null);
                this.tsBtnGuardar_Click(this.tsBtnGuardar, new EventArgs());
            }
        }

        private void txtTransaccion_Validating(object sender, CancelEventArgs e)
        {
            if (!String.IsNullOrEmpty(txtTransaccion.Text))
            {
                this.txtTransaccion.Text = this.txtTransaccion.Text.Replace(".", "");
                if (Validacion.ConFormato
                    (Validacion.TipoValidacion.Numeros, txtTransaccion, miError, "El valor que ingreso es incorrecto."))
                {
                    this.txtTransaccion.Text = UseObject.InsertSeparatorMil(this.txtTransaccion.Text);
                    TransaccionMatch = true;
                }
                else
                {
                    TransaccionMatch = false;
                }
            }
            else
            {
                txtTransaccion.Text = "0";
                TransaccionMatch = true;
            }
        }

        private void CargarDatos()
        {
            try
            {
                lblDataFecha.Text = DateTime.Now.ToLongDateString();
                cbCuentas.DataSource = miBussinesPuc.SubCuentas(this.CuentaTerceros);

                TConceptos.Columns.Add(new DataColumn("Id", typeof(int)));
                TConceptos.Columns.Add(new DataColumn("IdCuenta", typeof(int)));
                TConceptos.Columns.Add(new DataColumn("Concepto", typeof(string)));
                TConceptos.Columns.Add(new DataColumn("Valor", typeof(int)));
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
        }

        void CompletaEventos_Completaz(CompletaArgumentosDeEventoz args)
        {
            try
            {
                if (Transfer)
                {
                    txtNit.Text = ((Cliente)args.MiZona).NitCliente;
                    txtNit_KeyPress(this.txtNit, new KeyPressEventArgs((char)Keys.Enter));
                    Transfer = false;
                    cbCuentas.Focus();
                }
            }
            catch { }
        }

        private void RecargarGridView()
        {
            IEnumerable<DataRow> query = from datos in TConceptos.AsEnumerable()
                                         orderby datos.Field<int>("Id") ascending
                                         select datos;
            DataTable copy = query.CopyToDataTable<DataRow>();
            miBindingSource.DataSource = copy;
            txtTotal.Text = UseObject.InsertSeparatorMil
                (TConceptos.AsEnumerable().Sum(s => s.Field<int>("Valor")).ToString());
        }

        private List<ConceptoEgreso> Conceptos()
        {
            var lst = new List<ConceptoEgreso>();
            foreach (DataRow row in TConceptos.Rows)
            {
                lst.Add(new ConceptoEgreso
                {
                    IdCuenta = Convert.ToInt32(row["IdCuenta"]),
                    Nombre = row["Concepto"].ToString(),
                    Numero = row["Valor"].ToString()
                });
            }
            return lst;
        }

        private List<FormaPago> Pagos()
        {
            var lst = new List<FormaPago>();
            if (!txtEfectivo.Text.Equals("0"))
            {
                lst.Add(new FormaPago
                {
                    IdFormaPago = 1,
                    Valor = Convert.ToInt32(UseObject.RemoveSeparatorMil(txtEfectivo.Text))
                });
            }
            if (!txtCheque.Text.Equals("0"))
            {
                lst.Add(new FormaPago
                {
                    IdFormaPago = 2,
                    Valor = Convert.ToInt32(UseObject.RemoveSeparatorMil(txtCheque.Text))
                });
            }
            if (!txtTransaccion.Text.Equals("0"))
            {
                lst.Add(new FormaPago
                {
                    IdFormaPago = 4,
                    Valor = Convert.ToInt32(UseObject.RemoveSeparatorMil(txtTransaccion.Text))
                });
            }
            return lst;
        }

        private void PrintEgreso(DTO.Clases.Egreso egreso)
        {
            FrmPrint frmPrint = new FrmPrint();
            frmPrint.StringCaption = "Préstamos y anticipos";
            frmPrint.StringMessage = "Impresión del Comprobante de Egreso";
            DialogResult rta = frmPrint.ShowDialog();
            if (!rta.Equals(DialogResult.Cancel))
            {
                var printEgreso = new Egreso.FrmPrintComprobante();
                printEgreso.Numero = egreso.Numero;
                printEgreso.Fecha = egreso.Fecha;
                printEgreso.Remite = this.Tercero.NombresCliente + "  CC O NIT: " + this.Tercero.NitCliente;
                var tCuentas = miBussinesEgreso.EgresoPuc(egreso.Id);
                tCuentas.TableName = "CuentaPuc";
                printEgreso.Cuentas = tCuentas;
                printEgreso.Efectivo = egreso.Pagos.Where(p => p.IdFormaPago.Equals(1)).Sum(s => s.Valor).ToString();
                printEgreso.Cheque = egreso.Pagos.Where(p => p.IdFormaPago.Equals(2)).Sum(s => s.Valor).ToString();
                printEgreso.Transaccion = egreso.Pagos.Where(p => p.IdFormaPago.Equals(4)).Sum(s => s.Valor).ToString();

                if (rta.Equals(DialogResult.Yes))
                {
                    Imprimir print = new Imprimir();
                    print.Report = printEgreso.CargarDatos();
                    print.Print(Imprimir.TamanioPapel.MediaCarta);
                    printEgreso.ResetReport();
                }
                else
                {
                    printEgreso.ShowDialog();
                }
            }
        }

        private void PrintEgresoPos(string numero)
        {
            try
            {
                DialogResult rta = MessageBox.Show("¿Desea imprimir el comprobante de Egreso?", "Préstamos y anticipos",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (rta.Equals(DialogResult.Yes))
                {
                    var miBussinesEmpresa = new BussinesEmpresa();
                    var miBussinesUsuario = new BussinesUsuario();
                    var miBussinesCaja = new BussinesCaja();

                    var empresaRow = miBussinesEmpresa.PrintEmpresa().
                                     Tables[0].AsEnumerable().First();
                    var egreso = miBussinesEgreso.EgresoNumero(numero);
                    egreso.Pagos = miBussinesEgreso.PagosEgreso(egreso.Id);
                    var caja = miBussinesCaja.CajaId(egreso.IdCaja);
                    var usuario = miBussinesUsuario.ConsultaUsuario(egreso.IdUsuario).AsEnumerable().First();
                    var beneficio = miBussinesTercero.BeneficiarioId(egreso.TipoBeneficiario);
                    var items = miBussinesEgreso.EgresoPuc(egreso.Id);

                    Ticket ticket = new Ticket();
                    ticket.AddHeaderLine(empresaRow["Nombre"].ToString().ToUpper());
                    ticket.AddHeaderLine(empresaRow["Juridico"].ToString());
                    ticket.AddHeaderLine("NIT " + UseObject.InsertSeparatorMilMasDigito(empresaRow["Nit"].ToString()));
                    ticket.AddHeaderLine(empresaRow["Direccion"].ToString());
                    ticket.AddHeaderLine("Tels. " + empresaRow["Telefono"].ToString());
                    ticket.AddHeaderLine("Fecha : " + egreso.Fecha.ToShortDateString() +
                                         "    Caja : " + caja.Numero.ToString());
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
                    ticket.AddTotal("TOTAL        : ", UseObject.InsertSeparatorMil(
                        items.AsEnumerable().Sum(s => s.Field<int>("Valor")).ToString()));

                    ticket.AddTotal("FORMAS DE PAGO", "");
                    ticket.AddTotal("", "");
                    var pEfectivo = egreso.Pagos.Where(d => d.IdFormaPago.Equals(1));
                    var pCheque = egreso.Pagos.Where(d => d.IdFormaPago.Equals(2));
                    var pTransaccion = egreso.Pagos.Where(d => d.IdFormaPago.Equals(4));
                    if (pEfectivo.ToArray().Length != 0)
                    {
                        ticket.AddTotal("EFECTIVO    : ", UseObject.InsertSeparatorMil(pEfectivo.Sum(d => d.Valor).ToString()));
                    }
                    if (pCheque.ToArray().Length != 0)
                    {
                        ticket.AddTotal("CHEQUE      : ", UseObject.InsertSeparatorMil(pCheque.Sum(d => d.Valor).ToString()));
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
                    ticket.AddFooterLine("Cel. 3128068807");
                    ticket.AddFooterLine(".");

                    ticket.PrintTicket("IMPREPOS");
                }
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
        }

        private void LimpiarFormulario()
        {
            txtNit.Focus();
            miError.SetError(txtConcepto, null);
            miError.SetError(txtValor, null);
            this.Tercero = null;
            txtTercero.Text = "";
            txtConcepto.Text = "";
            txtValor.Text = "";
            ConceptoMatch = false;
            ValorMatch = false;
            while (dgvConceptos.RowCount != 0)
            {
                dgvConceptos.Rows.RemoveAt(0);
            }
            TConceptos.Rows.Clear();
            Contador = 0;
            txtTotal.Text = "0";
            txtEfectivo.Text = "0";
            txtCheque.Text = "0";
            txtTransaccion.Text = "";
            EfectivoMatch = false;
            ChequeMatch = false;
            TransaccionMatch = false;
        }
    }
}