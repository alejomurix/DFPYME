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
    public partial class FrmAdelanto : Form
    {
        #region Atributos

        /// <summary>
        /// Obtiene o establece el Nit del Cliente de la búsqueda.
        /// </summary>
        private string NitCliente { set; get; }

        private ToolTip miToolTip;

        #endregion

        #region lógica

        /// <summary>
        /// Encapsula la lógica de negocio de Cliente.
        /// </summary>
        private BussinesCliente miBussinesCliente;

        /// <summary>
        /// Encapsula la lógica de negocio de Saldo.
        /// </summary>
        private BussinesSaldo miBussinesSaldo;

        #endregion

        #region Validación

        /// <summary>
        /// Componente para mostrar mensajes de error en el formulario.
        /// </summary>
        private ErrorProvider miError;

        /// <summary>
        /// Obtiene o establece el valor que indica si se tiene un formulario de extensión en ejecución.
        /// </summary>
        private bool ExtendForm = false;

        private bool RetiroMatch = false;

        /// <summary>
        /// Representa el texto: El campo Nit o C.C. es requerido.
        /// </summary>
        private string NitReq = "El campo Nit o C.C. es requerido.";

        /// <summary>
        /// Representa el texto: El Nit o C.C. que ingreso es inválido.
        /// </summary>
        private string NitFormato = "El Nit o C.C. que ingreso es inválido.";

        #endregion

        #region Paginación Saldo

        /// <summary>
        /// Obteien o establece el numero que indica que iteracion se realizo.
        /// </summary>
        private int Iteracion;

        /// <summary>
        /// Obtiene o establece el valor del registro a segir o registro base.
        /// </summary>
        private int RowIndexSaldo;

        /// <summary>
        /// Obtiene o establece el número maximo de registro a cargar.
        /// </summary>
        private int RowMaxSaldo;

        /// <summary>
        /// Obtiene o establece el total de registros en la base de datos.
        /// </summary>
        private long TotalRowSaldo;

        /// <summary>
        /// Obtiene o establece el número total de paginas que componen la consulta.
        /// </summary>
        private long PaginasSaldo;

        /// <summary>
        /// Obtiene o establece el número de la pagina actual.
        /// </summary>
        private int CurrentPageSaldo;

        #endregion

        #region Paginación Canje

        /// <summary>
        /// Obteien o establece el numero que indica que iteracion se realizo.
        /// </summary>
        //private int Iteracion;

        /// <summary>
        /// Obtiene o establece el valor del registro a segir o registro base.
        /// </summary>
        private int RowIndexCanje;

        /// <summary>
        /// Obtiene o establece el número maximo de registro a cargar.
        /// </summary>
        private int RowMaxCanje;

        /// <summary>
        /// Obtiene o establece el total de registros en la base de datos.
        /// </summary>
        private long TotalRowCanje;

        /// <summary>
        /// Obtiene o establece el número total de paginas que componen la consulta.
        /// </summary>
        private long PaginasCanje;

        /// <summary>
        /// Obtiene o establece el número de la pagina actual.
        /// </summary>
        private int CurrentPageCanje;

        #endregion

        public FrmAdelanto()
        {
            InitializeComponent();
            RowMaxSaldo = 12;
            RowMaxCanje = 12;
            miToolTip = new ToolTip();
            miError = new ErrorProvider();
            miBussinesCliente = new BussinesCliente();
            miBussinesSaldo = new BussinesSaldo();
        }

        private void FrmAdelanto_Load(object sender, EventArgs e)
        {
            miToolTip.SetToolTip(btnBuscarCliente, "Buscar Cliente [F3]");
            CompletaEventos.CompletaRemision += 
                new CompletaEventos.CompletaAccionRemision(CompletaEventos_CompletaRemision);
            CompletaEventos.Completabo += 
                new CompletaEventos.CompletaAccionbo(CompletaEventos_Completabo);
            CompletaEventos.CompletaAdelanto += 
                new CompletaEventos.CompletaAccionAdelanto(CompletaEventos_CompletaAdelanto);
            CompletaEventos.CompletaRetiroAdelanto += 
                new CompletaEventos.CompletaAccionRetiroAdelanto(CompletaEventos_CompletaRetiroAdelanto);
        }

        private void FrmAdelanto_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void FrmAdelanto_FormClosing(object sender, FormClosingEventArgs e)
        {

        }

        private void tsBtnNuevo_Click(object sender, EventArgs e)
        {
            if (!ExtendForm)
            {
                if (!String.IsNullOrEmpty(NitCliente))
                {
                    var frmNewAdelanto = new FrmNuevoAdelanto();
                    frmNewAdelanto.NitCliente = NitCliente;
                   // frmNewAdelanto.MdiParent = this.MdiParent;
                    frmNewAdelanto.ShowDialog();
                    ExtendForm = true;
                }
                else
                {
                    OptionPane.MessageInformation("Debe primero seleccionar un Cliente.");
                }
            }
        }

        private void tsBtnRetirarSaldo_Click(object sender, EventArgs e)
        {
            if (!dgvAdelantos.RowCount.Equals(0))
            {
                if (!txtSaldo.Text.Equals("0"))
                {
                    if (!ExtendForm)
                    {
                        var frmRetiro = new Retiro.Adelanto.FrmRetiroAdelanto();
                        frmRetiro.MaxValor = Convert.ToInt32(UseObject.RemoveSeparatorMil(txtSaldo.Text));
                        frmRetiro.MdiParent = this.MdiParent;
                        frmRetiro.Show();
                        ExtendForm = true;
                        RetiroMatch = true;
                    }
                }
                else
                {
                    OptionPane.MessageInformation("El cliente no cuenta con saldo en Adelantos.");
                }
            }
            else
            {
                OptionPane.MessageInformation("No hay Adelantos para retirar.");
            }
        }

        private void tsBtnCopia_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvAdelantos.RowCount != 0)
                {
                    if (Convert.ToBoolean(AppConfiguracion.ValorSeccion("printRboAnticpo")))
                    {
                        PrintAnticipoPos(Convert.ToInt32(
                            dgvAdelantos.CurrentRow.Cells["Id"].Value));
                    }
                    else
                    {
                        PrintAnticipo(Convert.ToInt32(
                            dgvAdelantos.CurrentRow.Cells["Id"].Value));
                    }
                }
                else
                {
                    OptionPane.MessageInformation("No hay registros para imprimir.");
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

        private DTO.Clases.Cliente cliente { set; get; }
        private void txtCliente_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar.Equals((char)Keys.Enter))
            {
                if (!Validacion.EsVacio(txtCliente, miError, NitReq))
                {
                    if (Validacion.ConFormato(Validacion.TipoValidacion.NumeroGuion,
                        txtCliente, miError, NitFormato))
                    {
                        if (!txtCliente.Text.Equals("1000"))
                        {
                            try
                            {
                                cliente = miBussinesCliente.ClienteAEditar(txtCliente.Text);
                                NitCliente = cliente.NitCliente;
                                if (!String.IsNullOrEmpty(cliente.NitCliente))
                                {
                                    txtNombreCliente.Text = cliente.NitCliente + " - " + cliente.NombresCliente;
                                    CargarSaldos(NitCliente);
                                    CargarCanjes(NitCliente);
                                }
                                else
                                {
                                    txtNombreCliente.Text = "";
                                    LimpiarGridAdelantos();
                                    LimpiarGridTransaccion();
                                    DialogResult rta = MessageBox.Show("El cliente no existe. ¿Desea crearlo?",
                                        "Saldo Cliente", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                                    if (rta.Equals(DialogResult.Yes))
                                    {
                                        if (!ExtendForm)
                                        {
                                            var frmCliente = new FrmClienteBasico();
                                            frmCliente.MdiParent = this.MdiParent;
                                            frmCliente.txtNit.Text = txtCliente.Text;
                                            frmCliente.Show();
                                        }
                                    }
                                }
                                CargarUltimoSaldo();
                            }
                            catch (Exception ex)
                            {
                                OptionPane.MessageError(ex.Message);
                            }
                        }
                        else
                        {
                            miError.SetError(txtCliente, "El cliente a buscar no puede ser el Cliente General.");
                        }
                    }
                }
            }
        }

        private void btnBuscarCliente_Click(object sender, EventArgs e)
        {
            if (!ExtendForm)
            {
                var frmCliente = new Cliente.frmCliente();
                frmCliente.Remision = true;
                frmCliente.MdiParent = this.MdiParent;
                frmCliente.tcClientes.SelectedIndex = 1;
                frmCliente.Show();
                ExtendForm = true;
            }
        }





        private void btnInicio_Click(object sender, EventArgs e)
        {
            if (CurrentPageSaldo > 1)
            {
                var paginaActual = CurrentPageSaldo;
                for (int i = paginaActual; i > 1; i--)
                {
                    RowIndexSaldo = RowIndexSaldo - RowMaxSaldo;
                    CurrentPageSaldo--;
                }
                try
                {
                    dgvAdelantos.DataSource =
                        miBussinesSaldo.SaldosCliente(NitCliente, RowIndexSaldo, RowMaxSaldo);
                    lblStatusSaldo.Text = CurrentPageSaldo + " / " + PaginasSaldo;
                }
                catch (Exception ex)
                {
                    OptionPane.MessageError(ex.Message);
                }
            }
        }

        private void btnAnterior_Click(object sender, EventArgs e)
        {
            if (CurrentPageSaldo > 1)
            {
                RowIndexSaldo = RowIndexSaldo - RowMaxSaldo;
                if (RowIndexSaldo <= 0)
                    RowIndexSaldo = 0;
                try
                {
                    dgvAdelantos.DataSource =
                        miBussinesSaldo.SaldosCliente(NitCliente, RowIndexSaldo, RowMaxSaldo);
                    CurrentPageSaldo--;
                    lblStatusSaldo.Text = CurrentPageSaldo + " / " + PaginasSaldo;
                }
                catch (Exception ex)
                {
                    OptionPane.MessageError(ex.Message);
                }
            }
        }

        private void btnSiguiente_Click(object sender, EventArgs e)
        {
            if (CurrentPageSaldo < PaginasSaldo)
            {
                RowIndexSaldo = RowIndexSaldo + RowMaxSaldo;
                try
                {
                    dgvAdelantos.DataSource =
                        miBussinesSaldo.SaldosCliente(NitCliente, RowIndexSaldo, RowMaxSaldo);
                    CurrentPageSaldo++;
                    lblStatusSaldo.Text = CurrentPageSaldo + " / " + PaginasSaldo;
                }
                catch (Exception ex)
                {
                    OptionPane.MessageError(ex.Message);
                }
            }
        }

        private void btnFin_Click(object sender, EventArgs e)
        {
            if (CurrentPageSaldo < PaginasSaldo)
            {
                var paginaActual = CurrentPageSaldo;
                for (int i = paginaActual; i < PaginasSaldo; i++)
                {
                    RowIndexSaldo = RowIndexSaldo + RowMaxSaldo;
                    CurrentPageSaldo++;
                }
                try
                {
                    dgvAdelantos.DataSource =
                        miBussinesSaldo.SaldosCliente(NitCliente, RowIndexSaldo, RowMaxSaldo);
                    lblStatusSaldo.Text = CurrentPageSaldo + " / " + PaginasSaldo;
                }
                catch (Exception ex)
                {
                    OptionPane.MessageError(ex.Message);
                }
            }
        }

        private void btnInicioC_Click(object sender, EventArgs e)
        {
            if (CurrentPageCanje > 1)
            {
                var paginaActual = CurrentPageCanje;
                for (int i = paginaActual; i > 1; i--)
                {
                    RowIndexCanje = RowIndexCanje - RowMaxCanje;
                    CurrentPageCanje--;
                }
                try
                {
                    dgvCanje.DataSource =
                        miBussinesSaldo.CanjesCliente(NitCliente, RowIndexSaldo, RowMaxSaldo);
                    lblStatusCanje.Text = CurrentPageCanje + " / " + PaginasCanje;
                }
                catch (Exception ex)
                {
                    OptionPane.MessageError(ex.Message);
                }
            }
        }

        private void btnAnteriorC_Click(object sender, EventArgs e)
        {
            if (CurrentPageCanje > 1)
            {
                RowIndexCanje = RowIndexCanje - RowMaxCanje;
                if (RowIndexCanje <= 0)
                    RowIndexCanje = 0;
                try
                {
                    dgvCanje.DataSource =
                        miBussinesSaldo.CanjesCliente(NitCliente, RowIndexSaldo, RowMaxSaldo);
                    CurrentPageCanje--;
                    lblStatusCanje.Text = CurrentPageCanje + " / " + PaginasCanje;
                }
                catch (Exception ex)
                {
                    OptionPane.MessageError(ex.Message);
                }
            }
        }

        private void btnSiguienteC_Click(object sender, EventArgs e)
        {
            if (CurrentPageCanje < PaginasCanje)
            {
                RowIndexCanje = RowIndexCanje + RowMaxCanje;
                try
                {
                    dgvCanje.DataSource =
                        miBussinesSaldo.CanjesCliente(NitCliente, RowIndexSaldo, RowMaxSaldo);
                    CurrentPageCanje++;
                    lblStatusCanje.Text = CurrentPageCanje + " / " + PaginasCanje;
                }
                catch (Exception ex)
                {
                    OptionPane.MessageError(ex.Message);
                }
            }
        }

        private void btnFinC_Click(object sender, EventArgs e)
        {
            if (CurrentPageCanje < PaginasCanje)
            {
                var paginaActual = CurrentPageCanje;
                for (int i = paginaActual; i < PaginasCanje; i++)
                {
                    RowIndexCanje = RowIndexCanje + RowMaxCanje;
                    CurrentPageCanje++;
                }
                try
                {
                    dgvCanje.DataSource =
                        miBussinesSaldo.CanjesCliente(NitCliente, RowIndexSaldo, RowMaxSaldo);
                    lblStatusCanje.Text = CurrentPageCanje + " / " + PaginasCanje;
                }
                catch (Exception ex)
                {
                    OptionPane.MessageError(ex.Message);
                }
            }
        }


        void CompletaEventos_CompletaRemision(CompletaArgumentosDeEventoRemision args)
        {
            try
            {
                txtCliente.Text = (string)args.MiObjeto;
                txtCliente_KeyPress(this.txtCliente, new KeyPressEventArgs((char)Keys.Enter));
            }
            catch { }

            try
            {
                ExtendForm = Convert.ToBoolean(args.MiObjeto);
            }
            catch { }
        }

        void CompletaEventos_Completabo(CompletaArgumentosDeEventobo args)
        {
            try
            {
                txtCliente.Text = (string)args.MiBodegabo;
                txtCliente_KeyPress(this.txtCliente, new KeyPressEventArgs((char)Keys.Enter));
            }
            catch { }

            try
            {
                ExtendForm = Convert.ToBoolean(args.MiBodegabo);
            }
            catch { }
        }

        void CompletaEventos_CompletaAdelanto(CompletaArgumentosDeAdelanto args)
        {
            try
            {
                var pagos = (List<FormaPago>)args.MiObjeto;
                txtCliente_KeyPress(this.txtCliente, new KeyPressEventArgs((char)Keys.Enter));
                //IngresarAdelanto(pagos);
                /*var valor = Convert.ToInt32(args.MiObjeto);
                if (!valor.Equals(0))
                {
                    IngresarAdelanto(valor);
                }*/
            }
            catch { }
        }

        void CompletaEventos_CompletaRetiroAdelanto(CompletaArgumentosRetiroAdelanto args)
        {
            try
            {
                var valor = Convert.ToInt32(args.MiObjeto);
                if (!valor.Equals(0))
                {
                    if (RetiroMatch)
                    {
                        IngresarCanje(valor);
                        RetiroMatch = false;
                    }
                }
            }
            catch { }

            try 
            {
                ExtendForm = Convert.ToBoolean(args.MiObjeto);
            }
            catch { }
        }

        private void CargarSaldos(string nit)
        {
            RowIndexSaldo = 0;
            CurrentPageSaldo = 1;
            try
            {
                dgvAdelantos.AutoGenerateColumns = false;
                dgvAdelantos.DataSource = miBussinesSaldo.SaldosCliente(nit, RowIndexSaldo, RowMaxSaldo);
                if (dgvAdelantos.RowCount.Equals(0))
                {
                    //OptionPane.MessageInformation("No se encontraron Saldos para este Cliente.");
                    LimpiarGridAdelantos();
                }
                TotalRowSaldo = miBussinesSaldo.GetRowsSaldosCliente(nit);
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
            CalcularPaginas();
        }

        private void CargarCanjes(string nit)
        {
            RowIndexCanje = 0;
            CurrentPageCanje = 1;
            try
            {
                dgvCanje.AutoGenerateColumns = false;
                dgvCanje.DataSource = miBussinesSaldo.CanjesCliente(nit, RowIndexCanje, RowMaxCanje);
                if (dgvCanje.RowCount.Equals(0))
                {
                    //OptionPane.MessageInformation("No se encontraron Transacciones para este Cliente.");
                    LimpiarGridTransaccion();
                }
                TotalRowCanje = miBussinesSaldo.GetRowsCanjesCliente(nit);
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
            CalcularPaginasCanje();
        }

        private void CargarUltimoSaldo()
        {
            if (dgvAdelantos.RowCount != 0)
            {
                var maxFecha = dgvAdelantos.Rows.Cast<DataGridViewRow>().
                               Max(r => Convert.ToDateTime(r.Cells["Fecha"].Value));
                List<DataGridViewRow> row = (from item in dgvAdelantos.Rows.Cast<DataGridViewRow>()
                                             let fecha = Convert.ToDateTime(item.Cells["Fecha"].Value)
                                             where fecha == maxFecha
                                             select item).ToList<DataGridViewRow>();
                txtSaldo.Text = UseObject.InsertSeparatorMil(
                                  row.Single().Cells["Saldo"].Value.ToString());
            }
            else
            {
                txtSaldo.Text = "0";
            }
        }

        /// <summary>
        /// Limpia los registros de los Grid de Adelantos.
        /// </summary>
        private void LimpiarGridAdelantos()
        {
            while (dgvAdelantos.RowCount != 0)
            {
                dgvAdelantos.Rows.RemoveAt(0);
            }
        }

        /// <summary>
        /// Limpia los registros de los Grid de Transacción.
        /// </summary>
        private void LimpiarGridTransaccion()
        {
            while (dgvCanje.RowCount != 0)
            {
                dgvCanje.Rows.RemoveAt(0);
            }
        }

        /// <summary>
        /// Calcula y muestra el número de paginas devueltas en la consulta.
        /// </summary>
        private void CalcularPaginas()
        {
            PaginasSaldo = TotalRowSaldo / RowMaxSaldo;
            if (TotalRowSaldo % RowMaxSaldo != 0)
                PaginasSaldo++;
            if (CurrentPageSaldo > PaginasSaldo)
                CurrentPageSaldo = 0;
            lblStatusSaldo.Text = CurrentPageSaldo + " / " + PaginasSaldo;
        }

        /// <summary>
        /// Calcula y muestra el número de paginas devueltas en la consulta.
        /// </summary>
        private void CalcularPaginasCanje()
        {
            PaginasCanje = TotalRowCanje / RowMaxCanje;
            if (TotalRowCanje % RowMaxCanje != 0)
                PaginasCanje++;
            if (CurrentPageCanje > PaginasCanje)
                CurrentPageCanje = 0;
            lblStatusCanje.Text = CurrentPageCanje + " / " + PaginasCanje;
        }

        /// <summary>
        /// Cargar un objeto saldo y lo guarda en base de datos.
        /// </summary>
        /// <param name="valor">Valor del adelanto del saldo.</param>
        private void IngresarAdelanto(List<FormaPago> pagos)
        {
            var saldo = new Saldo();
            saldo.NitCliente = NitCliente;
            saldo.IdUsuario = Convert.ToInt32(AppConfiguracion.ValorSeccion("id_user"));
            saldo.IdCaja = Convert.ToInt32(AppConfiguracion.ValorSeccion("id_caja"));
            saldo.Fecha = DateTime.Now;
            saldo.Valor = Convert.ToInt32(pagos.Sum(s => s.Valor));
            saldo.FormasPago = pagos;
            saldo.Ingreso.Numero = AppConfiguracion.ValorSeccion("ingreso");
            saldo.Ingreso.Concepto = "Anticipo.";
            //saldo.Ingreso.Tipo = 1;
            saldo.Ingreso.Fecha = saldo.Fecha;
            saldo.Ingreso.Valor = saldo.Valor;
            saldo.Ingreso.Estado = true;
            try
            {
                long n = miBussinesSaldo.IngresarSaldo(saldo);
                OptionPane.MessageInformation("El anticipo se almaceno correctamente.");
                txtCliente_KeyPress(this.txtCliente, new KeyPressEventArgs((char)Keys.Enter));
                DialogResult rta = MessageBox.Show("¿Desea imprimir el recibo de ingreso?", "Anticipo Cliente",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (rta.Equals(DialogResult.Yes))
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
                    printCompIng.Numero = n.ToString();
                    printCompIng.Concepto = "Anticipo.";
                    printCompIng.MdiParent = this.MdiParent;
                    printCompIng.Show();
                    /*if (Convert.ToInt32(printCompIng.Numero) < 99)
                    {
                        AppConfiguracion.SaveConfiguration
                            ("ingreso", IncrementaConsecutivo(printCompIng.Numero));
                    }
                    else
                    {
                        AppConfiguracion.SaveConfiguration
                            ("ingreso", (Convert.ToInt32(printCompIng.Numero) + 1).ToString());
                    }*/
                }
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
        }

        private void PrintAnticipo(int id)
        {
            try
            {
               /* DialogResult rta = MessageBox.Show("¿Desea visualizar la impresión del recibo de ingreso?", "Anticipo Cliente",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);*/
                FrmPrint frmPrint = new FrmPrint();
                frmPrint.StringCaption = "Anticipo Cliente";
                frmPrint.StringMessage = "Impresión del Recibo de Anticipo";
                DialogResult rta = frmPrint.ShowDialog();
               /* if (rta.Equals(DialogResult.Yes))
                {*/
                    var anticipo = miBussinesSaldo.Saldo(id);
                    var printCompIng = new FrmPrintAnticipo();
                    printCompIng.Recibo = true;
                    printCompIng.TipoRecibo = 2;
                    printCompIng.Fecha = anticipo.Fecha;
                    printCompIng.Cliente = cliente.NombresCliente;
                    printCompIng.Nit = NitCliente;
                    printCompIng.Direccion =
                        cliente.DireccionCliente + "  " + cliente.Ciudad + "  " + cliente.Departamento;
                    printCompIng.Valor = anticipo.Valor.ToString();
                    if (anticipo.FormasPago.Where(p => p.IdFormaPago == 1).ToArray().Length > 0)
                    {
                        printCompIng.Efectivo = anticipo.FormasPago.Where(p => p.IdFormaPago == 1).Single().Valor.ToString();
                    }
                    else
                    {
                        printCompIng.Efectivo = "0";
                    }
                    if (anticipo.FormasPago.Where(p => p.IdFormaPago == 2).ToArray().Length > 0)
                    {
                        printCompIng.Cheque = anticipo.FormasPago.Where(p => p.IdFormaPago == 2).Single().Valor.ToString();
                    }
                    else
                    {
                        printCompIng.Cheque = "0";
                    }
                    printCompIng.Numero = anticipo.Numero;
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
                //}
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
                var empresaRow = miBussinesEmpresa.PrintEmpresa().Tables[0].AsEnumerable().First();
                var caja = miBussinesCaja.CajaId(anticipo.IdCaja);
                var usuarioRow = miBussinesUsuario.ConsultaUsuario(anticipo.IdUsuario).AsEnumerable().First();

                Ticket ticket = new Ticket();

                ticket.AddHeaderLine(empresaRow["Nombre"].ToString().ToUpper());
                ticket.AddHeaderLine(empresaRow["Juridico"].ToString());
                ticket.AddHeaderLine("NIT " + UseObject.InsertSeparatorMilMasDigito(empresaRow["Nit"].ToString()));
                ticket.AddHeaderLine(empresaRow["Direccion"].ToString());
                ticket.AddHeaderLine("Tels. " + empresaRow["Telefono"].ToString());
                ticket.AddHeaderLine("Fecha : " + anticipo.Fecha.ToShortDateString() +
                                     "    Caja : " + caja.Numero);
                ticket.AddHeaderLine("Cajero(a)  :  " + usuarioRow["nombre"].ToString());
                ticket.AddHeaderLine("===================================");
                ticket.AddHeaderLine("RECIBO DE ANTICIPO No " + anticipo.Ingreso.Numero);
                ticket.AddHeaderLine("===================================");
                ticket.AddHeaderLine("Recibido de : " + cliente.NombresCliente.ToUpper());
                ticket.AddHeaderLine("NIT o C.C.  : " + UseObject.InsertSeparatorMilMasDigito(cliente.NitCliente));
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
                ticket.AddFooterLine("Cel. 3128068807");
                ticket.AddFooterLine(".");

                ticket.PrintTicket("IMPREPOS");
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
        }

        private void IngresarCanje(int valor)
        {
            var canje = new Canje();
            canje.NitCliente = NitCliente;
            canje.IdUsuario = Convert.ToInt32(AppConfiguracion.ValorSeccion("id_user"));
            canje.IdCaja = Convert.ToInt32(AppConfiguracion.ValorSeccion("id_caja"));
            canje.Fecha = DateTime.Now;
            canje.Concepto = "Retiro de Efectivo.";
            canje.Valor = valor;
            try
            {
                miBussinesSaldo.IngresarCanje(canje);
                var bussinesReciboRetiro = new BussinesComprobanteCruce();
                var retiro = new ComprobanteCruce();
                retiro.Fecha = DateTime.Now;
                retiro.NitCliente = NitCliente;
                retiro.Concepto = "Retiro de Anticipo.";
                retiro.Valor = valor;
                retiro.Restante = "Anticipo Restante : ";
                retiro.ValorRestante = miBussinesSaldo.SaldoEnAdelantos(NitCliente);
                retiro.Id = bussinesReciboRetiro.IngresarReciboRetiro(retiro);
                PrintReciboRetiro(retiro);
                txtCliente_KeyPress(this.txtCliente, new KeyPressEventArgs((char)Keys.Enter));
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
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

        private void PrintReciboRetiro(ComprobanteCruce cruce)
        {
            try
            {
               /* DialogResult rta = MessageBox.Show("¿Desea visualizar la impresión del comprobante de cruce?", "Anticipo Cliente",
                    MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);*/
                FrmPrint frmPrint = new FrmPrint();
                frmPrint.StringCaption = "Anticipo Cliente";
                frmPrint.StringMessage = "Impresión del Recibo de Retiro";
                DialogResult rta = frmPrint.ShowDialog();

                if (!rta.Equals(DialogResult.Cancel))
                {
                    var print = new Factura.FrmComprobanteCruce();
                    var cliente = miBussinesCliente.ClienteAEditar(cruce.NitCliente);
                    print.Numero = cruce.Id.ToString();
                    print.Titulo = "Recibo de retiro No.";
                    print.Fecha = cruce.Fecha;
                    print.Nit = cliente.NitCliente;
                    print.Cliente = cliente.NombresCliente;
                    print.Direccion = cliente.DireccionCliente + " " + cliente.Ciudad + " " + cliente.Departamento;
                    print.Concepto = cruce.Concepto;
                    print.Valor = cruce.Valor.ToString();
                    print.Restante = cruce.Restante;
                    print.VRestante = cruce.ValorRestante;

                    if (rta.Equals(DialogResult.No))
                    {
                        print.ShowDialog();
                    }
                    else
                    {
                        Imprimir print_ = new Imprimir();
                        print_.Report = print.CargarDatos();
                        print_.Print(Imprimir.TamanioPapel.MediaCarta);
                        print.ResetReport();
                    }
                }
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
        }
    }
}