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
using Utilities;
using DTO.Clases;

namespace Aplicacion.Ventas.Cliente
{
    public partial class FrmBonos : Form
    {
        #region Atributos

        /// <summary>
        /// Obtiene o establece el Nit del Cliente de la búsqueda.
        /// </summary>
        private string NitCliente { set; get; }

        private int IdCaja;

        private int IdUsuario;

        private ToolTip miToolTip;

        private bool ExtendForm = false;

        #endregion

        #region lógica

        /// <summary>
        /// Encapsula la lógica de negocio de Cliente.
        /// </summary>
        private BussinesCliente miBussinesCliente;

        /// <summary>
        /// Encapsula la lógica de negocio de Bono.
        /// </summary>
        private BussinesBono miBussinesBono;

        #endregion

        #region Validación

        /// <summary>
        /// Componente para mostrar mensajes de error en el formulario.
        /// </summary>
        private ErrorProvider miError;

        /// <summary>
        /// Representa el texto: El campo Nit o C.C. es requerido.
        /// </summary>
        private string NitReq = "El campo Nit o C.C. es requerido.";

        /// <summary>
        /// Representa el texto: El Nit o C.C. que ingreso es inválido.
        /// </summary>
        private string NitFormato = "El Nit o C.C. que ingreso es inválido.";

        #endregion

        #region Paginación Bono

        /// <summary>
        /// Obteien o establece el numero que indica que iteracion se realizo.
        /// </summary>
        //private int Iteracion;

        /// <summary>
        /// Obtiene o establece el valor del registro a segir o registro base.
        /// </summary>
        private int RowIndex;

        /// <summary>
        /// Obtiene o establece el número maximo de registro a cargar.
        /// </summary>
        private int RowMax;

        /// <summary>
        /// Obtiene o establece el total de registros en la base de datos.
        /// </summary>
        private long TotalRow;

        /// <summary>
        /// Obtiene o establece el número total de paginas que componen la consulta.
        /// </summary>
        private long Paginas;

        /// <summary>
        /// Obtiene o establece el número de la pagina actual.
        /// </summary>
        private int CurrentPage;

        #endregion

        public FrmBonos()
        {
            InitializeComponent();
            RowMax = 15;
            IdCaja = Convert.ToInt32(AppConfiguracion.ValorSeccion("id_caja"));
            IdUsuario = Convert.ToInt32(AppConfiguracion.ValorSeccion("id_user"));
            miError = new ErrorProvider();
            miBussinesCliente = new BussinesCliente();
            miBussinesBono = new BussinesBono();
        }

        private void FrmBonos_Load(object sender, EventArgs e)
        {
            CompletaEventos.CompletaRetiroBono += 
                new CompletaEventos.CompletaAccionRetiroBono(CompletaEventos_CompletaRetiroBono);
            CompletaEventos.CompletaRetiroSaldo += 
                new CompletaEventos.CompletaAccionRetiroSaldo(CompletaEventos_CompletaRetiroSaldo);
            ///CompletaEventos.CapturaEventoRemision
            CompletaEventos.CompletaRemision += new CompletaEventos.CompletaAccionRemision(CompletaEventos_CompletaRemision);
        }

        private void FrmBonos_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData.Equals(Keys.F5))
            {
                tsBtnCanjeBono_Click(this.tsBtnCanjeBono, new EventArgs());
            }
            else
            {
                if (e.KeyData.Equals(Keys.F6))
                {
                    tsBtnCanjeSaldo_Click(this.tsBtnCanjeSaldo, new EventArgs());
                }
                else
                {
                    if (e.KeyData.Equals(Keys.Escape))
                    {
                        this.Close();
                    }
                }
            }
        }

        private void tsBtnCanjeBono_Click(object sender, EventArgs e)
        {
            if (!dgvBonos.RowCount.Equals(0))
            {
                if (!txtSaldoBono.Text.Equals("0"))
                {
                    if (!ExtendForm)
                    {
                        var frmRetiro = new Retiro.Bono.FrmRetiroBono();
                        frmRetiro.MaxValor = Convert.ToInt32(
                            UseObject.RemoveSeparatorMil(txtSaldoBono.Text));
                        frmRetiro.MdiParent = this.MdiParent;
                        frmRetiro.Show();
                        ExtendForm = true;
                    }
                }
                else
                {
                    OptionPane.MessageInformation("El Bono que selecciono ya ha sido retirado.");
                }
            }
            else
            {
                OptionPane.MessageInformation("No hay Bonos para retirar.");
            }
        }

        private void tsBtnCanjeSaldo_Click(object sender, EventArgs e)
        {
            if (!dgvBonos.RowCount.Equals(0))
            {
                if (!txtSaldo.Text.Equals("0"))
                {
                    if (!ExtendForm)
                    {
                        var frmRetiro = new Retiro.Bono.FrmRetiroSaldo();
                        frmRetiro.MaxValor = Convert.ToInt32(
                            UseObject.RemoveSeparatorMil(txtSaldo.Text));
                        frmRetiro.MdiParent = this.MdiParent;
                        frmRetiro.Show();
                        ExtendForm = true;
                    }
                }
                else
                {
                    OptionPane.MessageInformation("El cliente no cuenta con saldo en Bonos.");
                }
            }
            else
            {
                OptionPane.MessageInformation("No hay Bonos para retirar.");
            }
        }

        private void tsBtnCopia_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvBonos.RowCount != 0)
                {
                    var notaCredito = miBussinesBono.NotaCredito(Convert.ToInt32(
                                                     dgvBonos.CurrentRow.Cells["Id"].Value));
                    if (Convert.ToBoolean(AppConfiguracion.ValorSeccion("printNotaCreCliente")))
                    {
                        PrintNotaCreditoPos(notaCredito, NitCliente);
                    }
                    else
                    {
                        PrintNotaCredito(notaCredito, NitCliente);
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
                                var cliente = miBussinesCliente.ClienteAEditar(txtCliente.Text);
                                NitCliente = cliente.NitCliente;
                                if (!String.IsNullOrEmpty(cliente.NitCliente))
                                {
                                    miError.SetError(txtCliente, null);
                                    txtNombreCliente.Text = cliente.NitCliente + " - " + cliente.NombresCliente;
                                    CargarBonos(NitCliente);
                                    //CargarSaldos(NitCliente);
                                    //CargarCanjes(NitCliente);
                                }
                                else
                                {
                                    OptionPane.MessageError("El cliente que ingreso no existe.");
                                    miError.SetError(txtCliente, "El cliente que ingreso no existe.");
                                    txtNombreCliente.Text = "";
                                }
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
            var frmCliente = new Cliente.frmCliente();
            frmCliente.Remision = true;
            frmCliente.MdiParent = this.MdiParent;
            frmCliente.tcClientes.SelectedIndex = 1;
            frmCliente.Show();
        }

        private void chkCanje_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(txtCliente.Text))
            {
                txtCliente_KeyPress(this.txtCliente, new KeyPressEventArgs((char)Keys.Enter));
            }
        }

        private void dgvBonos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            var id = (int)dgvBonos.CurrentRow.Cells["Id"].Value;
            try
            {
                dgvSeguimiento.AutoGenerateColumns = false;
                dgvSeguimiento.DataSource = miBussinesBono.Seguimientos(id);
                CalcularSaldoEnBono();
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
        }

        private void dgvBonos_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyData.Equals(Keys.Up) || e.KeyData.Equals(Keys.Down))
            {
                dgvBonos_CellClick(this.dgvBonos,
                new DataGridViewCellEventArgs(this.dgvBonos.CurrentCell.ColumnIndex, this.dgvBonos.CurrentCell.RowIndex));
            }
        }

        private void btnInicio_Click(object sender, EventArgs e)
        {
            if (CurrentPage > 1)
            {
                var paginaActual = CurrentPage;
                for (int i = paginaActual; i > 1; i--)
                {
                    RowIndex = RowIndex - RowMax;
                    CurrentPage--;
                }
                try
                {
                    dgvBonos.DataSource = miBussinesBono.Bonos(NitCliente, chkCanje.Checked, RowIndex, RowMax);
                    CurrentPage--;
                    lblStatusBono.Text = CurrentPage + " / " + Paginas;
                }
                catch (Exception ex)
                {
                    OptionPane.MessageError(ex.Message);
                }
            }
        }

        private void btnAnterior_Click(object sender, EventArgs e)
        {
            if (CurrentPage > 1)
            {
                RowIndex = RowIndex - RowMax;
                if (RowIndex <= 0)
                    RowIndex = 0;
                try
                {
                    dgvBonos.DataSource = miBussinesBono.Bonos(NitCliente, chkCanje.Checked, RowIndex, RowMax);
                    lblStatusBono.Text = CurrentPage + " / " + Paginas;
                }
                catch (Exception ex)
                {
                    OptionPane.MessageError(ex.Message);
                }
            }
        }

        private void btnSiguiente_Click(object sender, EventArgs e)
        {
            if (CurrentPage < Paginas)
            {
                RowIndex = RowIndex + RowMax;
                try
                {
                    dgvBonos.DataSource =
                        miBussinesBono.Bonos(NitCliente, chkCanje.Checked, RowIndex, RowMax);
                    CurrentPage++;
                    lblStatusBono.Text = CurrentPage + " / " + Paginas;
                }
                catch (Exception ex)
                {
                    OptionPane.MessageError(ex.Message);
                }
            }
        }

        private void btnFin_Click(object sender, EventArgs e)
        {
            if (CurrentPage < Paginas)
            {
                var paginaActual = CurrentPage;
                for (int i = paginaActual; i < Paginas; i++)
                {
                    RowIndex = RowIndex + RowMax;
                    CurrentPage++;
                }
                try
                {
                    dgvBonos.DataSource =
                        miBussinesBono.Bonos(NitCliente, chkCanje.Checked, RowIndex, RowMax);
                    lblStatusBono.Text = CurrentPage + " / " + Paginas;
                }
                catch (Exception ex)
                {
                    OptionPane.MessageError(ex.Message);
                }
            }
        }

        /// <summary>
        /// Carga el Grid de Bonos con el resultado de la consulta de Bonos de un Cliente.
        /// </summary>
        /// <param name="cliente">Cliente a consultar.</param>
        private void CargarBonos(string cliente)
        {
            RowIndex = 0;
            CurrentPage = 1;
            try
            {
                dgvBonos.AutoGenerateColumns = false;
                dgvBonos.DataSource = miBussinesBono.Bonos(cliente, chkCanje.Checked, RowIndex, RowMax);
                if (dgvBonos.RowCount != 0)
                {
                    dgvBonos_CellClick(this.dgvBonos,
                    new DataGridViewCellEventArgs(this.dgvBonos.CurrentCell.ColumnIndex, this.dgvBonos.CurrentCell.RowIndex));
                    CalcularSaldo(NitCliente);
                }
                else
                {
                    while (dgvSeguimiento.RowCount != 0)
                    {
                        dgvSeguimiento.Rows.RemoveAt(0);
                    }
                    txtSaldo.Text = "0";
                    txtSaldoBono.Text = "0";
                }
                TotalRow = miBussinesBono.GetRowsBonos(cliente, chkCanje.Checked);
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
            CalcularPaginas();
        }

        /// <summary>
        /// Calcula y muestra el número de paginas devueltas en la consulta.
        /// </summary>
        private void CalcularPaginas()
        {
            Paginas = TotalRow / RowMax;
            if (TotalRow % RowMax != 0)
                Paginas++;
            if (CurrentPage > Paginas)
                CurrentPage = 0;
            lblStatusBono.Text = CurrentPage + " / " + Paginas;
        }

        /// <summary>
        /// Consulta el saldo disponible en bonos de un cliente.
        /// </summary>
        /// <param name="cliente">Cliente a consultar.</param>
        private void CalcularSaldo(string cliente)
        {
            try
            {
                txtSaldo.Text = UseObject.InsertSeparatorMil
                                          (miBussinesBono.SaldoEnBonos(cliente).ToString());
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
        }

        /// <summary>
        /// Calcula el saldo disponeble en cada bono el cliente.
        /// </summary>
        private void CalcularSaldoEnBono()
        {
            var totalB = (int)dgvBonos.CurrentRow.Cells["Valor"].Value;
            var totalS = dgvSeguimiento.Rows.Cast<DataGridViewRow>().
                         Sum(s => Convert.ToInt32(s.Cells["ValorS"].Value));
            txtSaldoBono.Text = UseObject.InsertSeparatorMil((totalB - totalS).ToString());
        }

        void CompletaEventos_CompletaRemision(CompletaArgumentosDeEventoRemision args)
        {
            try
            {
                this.txtCliente.Text = (string)args.MiObjeto;
                this.txtCliente_KeyPress(this.txtCliente, new KeyPressEventArgs((char)Keys.Enter));
            }
            catch { }
        }

        void CompletaEventos_CompletaRetiroBono(CompletaArgumentosRetiroBono args)
        {
            try
            {
                var valor = Convert.ToInt32(args.MiObjeto);
                if (!valor.Equals(0))
                {
                    RetirarBono(valor);
                }
            }
            catch { }

            try
            {
                ExtendForm = Convert.ToBoolean(args.MiObjeto);
            }
            catch { }
        }

        void CompletaEventos_CompletaRetiroSaldo(CompletaArgumentosRetiroSaldo args)
        {
            try
            {
                var valor = Convert.ToInt32(args.MiObjeto);
                if (!valor.Equals(0))
                {
                    RetiraSaldo(valor, IdCaja, IdUsuario);
                }
            }
            catch { }

            try
            {
                ExtendForm = Convert.ToBoolean(args.MiObjeto);
            }
            catch { }
        }

        private void PrintNotaCreditoPos(Bono notaCredito, string cliente)
        {
            DialogResult rta = MessageBox.Show("¿Desea imprimir la nota crédito a cliente?", "Devolución Venta",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rta.Equals(DialogResult.Yes))
            {
                try
                {
                    var miBussinesEmpresa = new BussinesEmpresa();
                    var miBussinesCaja = new BussinesCaja();
                    var miBussinesUsuario = new BussinesUsuario();
                    var miBussinesCliente = new BussinesCliente();

                    var empresaRow = miBussinesEmpresa.PrintEmpresa().
                                     Tables[0].AsEnumerable().First();
                    var caja = miBussinesCaja.CajaId(notaCredito.IdCaja);
                    var ususarioRow = miBussinesUsuario.ConsultaUsuario(notaCredito.IdUsuario).AsEnumerable().First();
                    var clienteDB = miBussinesCliente.ClienteAEditar(cliente);

                    Ticket ticket = new Ticket();

                    ticket.AddHeaderLine(empresaRow["Nombre"].ToString().ToUpper());
                    ticket.AddHeaderLine(empresaRow["Juridico"].ToString());
                    ticket.AddHeaderLine("NIT " + UseObject.InsertSeparatorMilMasDigito(empresaRow["Nit"].ToString()));
                    ticket.AddHeaderLine(empresaRow["Direccion"].ToString());
                    ticket.AddHeaderLine("Tels. " + empresaRow["Telefono"].ToString());
                    ticket.AddHeaderLine("Fecha   : " + notaCredito.Fecha.ToShortDateString());
                    ticket.AddHeaderLine("Caja No : " + caja.Numero.ToString());
                    ticket.AddHeaderLine("Cajero(a)  :  " + ususarioRow["nombre"].ToString());
                    ticket.AddHeaderLine("===================================");
                    //ticket.AddHeaderLine("COMPROBANTE DE SALDO Nro " + ingreso.Numero);
                    ticket.AddHeaderLine("NOTA CRÉDITO A CLIENTE No " + notaCredito.Numero);
                    ticket.AddHeaderLine("===================================");
                    ticket.AddHeaderLine("Recibido de : " + clienteDB.NombresCliente);
                    ticket.AddHeaderLine("NIT o C.C.  : " + UseObject.InsertSeparatorMilMasDigito(clienteDB.NitCliente));
                    ticket.AddHeaderLine("===================================");
                    ticket.AddItem("",
                                   notaCredito.Concepto,
                                   UseObject.InsertSeparatorMil(notaCredito.Valor.ToString()));
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
        }

        private void PrintNotaCredito(Bono notaCredito, string cliente)  //PrintNotaCredito
        {
            DialogResult rta = MessageBox.Show("¿Desea visualizar la impresión de la nota crédito a cliente?", "Devolución Venta",
                MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
            if (!rta.Equals(DialogResult.Cancel))
            {
                try
                {
                    var printCompIng = new Cliente.FrmPrintAnticipo();
                    printCompIng.Numero = notaCredito.Numero;
                    printCompIng.Fecha = notaCredito.Fecha;
                    var bussinesCliente = new BussinesCliente();
                    var cliente_ = bussinesCliente.ClienteAEditar(cliente);
                    printCompIng.Nit = cliente_.NitCliente;
                    printCompIng.Cliente = cliente_.NombresCliente;
                    printCompIng.Direccion = cliente_.DireccionCliente + "  " +
                        cliente_.Ciudad + "  " + cliente_.Departamento;
                    printCompIng.Concepto = notaCredito.Concepto;
                    printCompIng.Valor = notaCredito.Valor.ToString();

                    printCompIng.AplicaPago = false;
                    printCompIng.TipoRecibo = 3;
                    printCompIng.ReportPath = AppConfiguracion.ValorSeccion("report") + @"\reports\ComprobanteSaldo.rdlc";

                    if (rta.Equals(DialogResult.Yes))
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
                catch (Exception ex)
                {
                    OptionPane.MessageError(ex.Message);
                }
            }
        }

        /// <summary>
        /// Realiza el proceso de retiro del Bono ya sea parte o completo.
        /// </summary>
        /// <param name="valor">Valor a retirar del Bono.</param>
        private void RetirarBono(int valor)
        {
            try
            {
                var bono = new Bono();
                if (dgvBonos.CurrentRow != null)
                {
                    bono.Id = (int)dgvBonos.CurrentRow.Cells["Id"].Value;
                }
                else
                {
                    return;
                }
                bono.Fecha = DateTime.Now;
                bono.IdCaja = IdCaja;
                bono.IdUsuario = IdUsuario;
                bono.Valor = valor;
                //miBussinesBono.IngresarSeguimiento(bono); OJO PARA EDITAR POR LA RELACION CON FACTURA VENTA
                if (valor.Equals(
                    Convert.ToInt32(UseObject.RemoveSeparatorMil(txtSaldoBono.Text))))
                {
                    miBussinesBono.CanjeBono(bono.Id);
                }
                txtCliente_KeyPress(this.txtCliente, new KeyPressEventArgs((char)Keys.Enter));
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
        }

        /// <summary>
        /// Realiza el proceso de retiro de Saldo del Bono ya sea parte o completo.
        /// </summary>
        /// <param name="valor">Valor a retirar del Bono.</param>
        private void RetiraSaldo(int valor, int idCaja, int idUser)
        {
            try
            {
                //miBussinesBono.IngresarSeguimiento(NitCliente, valor, idCaja, idUser);
                //OJO PARA EDITAR POR LA RELACION CON FACTURA VENTA
                txtCliente_KeyPress(this.txtCliente, new KeyPressEventArgs((char)Keys.Enter));
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
        }
    }
}