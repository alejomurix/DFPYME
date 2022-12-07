using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BussinesLayer.Clases;
using DTO.Clases;
using CustomControl;
using Utilities;

namespace Aplicacion.Ventas.Ingresos
{
    public partial class FrmConsultaOtro : Form
    {
        //private BussinesEgreso miBussinesEgreso;

        private BussinesOtroIngreso miBussinesIngreso;

        private BussinesUsuario miBussinesUsuario;

        private BussinesCliente miBussinesCliente;

        private BussinesProveedor miBussinesProveedor;

        private BussinesBeneficio miBussinesBeneficio;

        /// <summary>
        /// Obteien o establece el numero que indica que iteracion se realizo.
        /// </summary>
        private int Iteracion;

        /// <summary>
        /// Obtiene o establece el valor del registro a segir o registro base.
        /// </summary>
        private int RowIngreso;

        /// <summary>
        /// Obtiene o establece el número maximo de registro a cargar.
        /// </summary>
        private int RowMaxIngreso;

        /// <summary>
        /// Obtiene o establece el total de registros en la base de datos.
        /// </summary>
        private long TotalRowIngreso;

        /// <summary>
        /// Obtiene o establece el número total de paginas que componen la consulta.
        /// </summary>
        private long PaginasIngreso;

        /// <summary>
        /// Obtiene o establece el número de la pagina actual.
        /// </summary>
        private int CurrentPageIngreso;

        private bool AnuladoActual;

        private DateTime FechaActual;

        private DateTime FechaActual1;

        private DataTable DsConcepto;

        public FrmConsultaOtro()
        {
            InitializeComponent();
            //miBussinesEgreso = new BussinesEgreso();
            miBussinesIngreso = new BussinesOtroIngreso();
            miBussinesUsuario = new BussinesUsuario();
            miBussinesCliente = new BussinesCliente();
            miBussinesProveedor = new BussinesProveedor();
            miBussinesBeneficio = new BussinesBeneficio();
            DsConcepto = new DataTable();
            RowMaxIngreso = 10;
        }

        private void FrmConsultaEgreso_Load(object sender, EventArgs e)
        {
            CargarUtilidades();
            dgvEgreso.AutoGenerateColumns = false;
            dgvCuentas.AutoGenerateColumns = false;
        }

        private void tsBtnListarTodos_Click(object sender, EventArgs e)
        {
            RowIngreso = 0;
            Iteracion = 3;
            CurrentPageIngreso = 1;
            AnuladoActual = chkAnulado.Checked;
            try
            {
                dgvEgreso.DataSource =
                    miBussinesIngreso.Ingresos(RowIngreso, RowMaxIngreso);
                TotalRowIngreso = miBussinesIngreso.GetRowsIngresos();
                //TotalRowIngreso = miBussinesEgreso.GetRowslistado(chkAnulado.Checked);
                if (!dgvEgreso.RowCount.Equals(0))
                {
                    dgvEgreso_CellClick(this.dgvEgreso, null);
                }
                else
                {
                    OptionPane.MessageInformation("No hay registros de Ingresos.");
                }
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
            CalcularPaginas();
        }

        private void tsBtnCopia_Click(object sender, EventArgs e)
        {
            if (dgvEgreso.RowCount != 0)
            {
                var registro = dgvEgreso.Rows[dgvEgreso.CurrentCell.RowIndex];
                if (registro.Cells["Estado"].Value.ToString().Equals("OK"))
                {
                    try
                    {
                        if (Convert.ToBoolean(AppConfiguracion.ValorSeccion("printRboCaja")))
                        {
                            var otroIngreso = miBussinesIngreso.Ingreso(registro.Cells["numero"].Value.ToString());
                            ImpirmirPos(otroIngreso);
                        }
                        else
                        {
                            var frmPrintIngreso = new FrmPrintIngreso();
                            frmPrintIngreso.Fecha = Convert.ToDateTime(registro.Cells["Fecha"].Value);

                            var c = miBussinesBeneficio.BeneficiarioId(Convert.ToInt32(registro.Cells["IdBeneficio"].Value));
                            frmPrintIngreso.Cliente = c.NombresCliente;
                            frmPrintIngreso.Nit = c.NitCliente;
                            frmPrintIngreso.Valor = registro.Cells["Valor"].Value.ToString();
                            frmPrintIngreso.Numero = registro.Cells["numero"].Value.ToString();
                            frmPrintIngreso.DsConcepto = DsConcepto;

                            var tPagos = miBussinesIngreso.FormasDePago(Convert.ToInt32(registro.Cells["Id"].Value));
                            frmPrintIngreso.Efectivo =
                                tPagos.AsEnumerable().Where(p => p.Field<int>("idforma_pago").Equals(1)).Sum(s => s.Field<int>("valor")).ToString();
                            frmPrintIngreso.Cheque =
                                tPagos.AsEnumerable().Where(p => p.Field<int>("idforma_pago").Equals(2)).Sum(s => s.Field<int>("valor")).ToString();
                            frmPrintIngreso.Transaccion =
                                tPagos.AsEnumerable().Where(p => p.Field<int>("idforma_pago").Equals(4)).Sum(s => s.Field<int>("valor")).ToString();

                            /*DialogResult rta = MessageBox.Show("¿Desea visualizar la impresión del Recibo de Caja?", "Recibo de Caja",
                                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);*/

                            FrmPrint frmPrint = new FrmPrint();
                            frmPrint.StringCaption = "Consulta Recibo de Caja";
                            frmPrint.StringMessage = "Impresión del Recibo de Caja";
                            DialogResult rta = frmPrint.ShowDialog();

                            if (rta.Equals(DialogResult.No))
                            {
                                frmPrintIngreso.ShowDialog();
                            }
                            else
                            {
                                if (rta.Equals(DialogResult.Yes))
                                {
                                    Imprimir print = new Imprimir();
                                    print.Report = frmPrintIngreso.CargarDatos();
                                    print.Print(Imprimir.TamanioPapel.MediaCarta);
                                    frmPrintIngreso.ResetReport();
                                }
                            }
                        }

                        /*var frmPrint = new Aplicacion.Compras.Egreso.FrmPrintComprobante();
                        frmPrint.MdiParent = this.MdiParent;
                        frmPrint.Numero = registro.Cells["Numero"].Value.ToString();
                        frmPrint.Fecha = Convert.ToDateTime(registro.Cells["Fecha"].Value);
                        var beneficia = "";
                        var c = miBussinesBeneficio.BeneficiarioId(Convert.ToInt32(registro.Cells["Tipo"].Value));
                        beneficia = c.NombresCliente + "  CC o NIT: " + c.NitCliente;
                        frmPrint.Remite = beneficia;
                        //Beneficia
                        var pagos = new List<FormaPago>();
                        try
                        {
                            pagos = miBussinesEgreso.PagosEgreso(Convert.ToInt32(registro.Cells["Id"].Value));
                        }
                        catch (Exception ex)
                        {
                            OptionPane.MessageError(ex.Message);
                        }
                        var efe = 0;
                        var che = 0;
                        foreach (var pago in pagos)
                        {
                            if (pago.IdFormaPago.Equals(1))
                            {
                                efe += pago.Valor;
                            }
                            else
                            {
                                che += pago.Valor;
                            }
                        }
                        frmPrint.Cheque = che.ToString();
                        frmPrint.Efectivo = efe.ToString();
                        frmPrint.Cuentas = Cuentas(Convert.ToInt32(registro.Cells["Id"].Value));
                        frmPrint.Show();*/
                    }
                    catch (Exception ex)
                    {
                        OptionPane.MessageError(ex.Message);
                    }
                }
                else
                {
                    OptionPane.MessageInformation("El registro de Egreso no se puede imprimir porque esta anulado.");
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
                txtNumero.Enabled = true;
                cbFecha.Enabled = false;
                dtpFecha.Enabled = false;
                dtpFecha1.Enabled = false;
            }
            else
            {
                txtNumero.Enabled = false;
                dtpFecha.Enabled = true;
                cbFecha.Enabled = true;
            }
        }

        private void txtNumero_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar.Equals((char)Keys.Enter))
            {
                btnBuscar_Click(btnBuscarFe, new EventArgs());
            }
        }

        private void cbFecha_SelectionChangeCommitted(object sender, EventArgs e)
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

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            var id = Convert.ToInt32(cbCriterio.SelectedValue);
            if (id.Equals(1))//numero
            {
                CurrentPageIngreso = 1;
                PaginasIngreso = 1;
                Iteracion = 0;
                try
                {
                    dgvEgreso.DataSource = miBussinesIngreso.Ingresos(txtNumero.Text);
                    if (dgvEgreso.RowCount.Equals(0))
                    {
                        LimpiarCuentas();
                        OptionPane.MessageInformation("No se encontrarón registros de Egreso con ese Número.");
                    }
                }
                catch (Exception ex)
                {
                    OptionPane.MessageError(ex.Message);
                }
                lblStatusEgreso.Text = "1 / 1";
            }
            else//fecha
            {
                if (Convert.ToInt32(cbFecha.SelectedValue).Equals(1))
                {
                    RowIngreso = 0;
                    Iteracion = 1;
                    CurrentPageIngreso = 1;
                    FechaActual = dtpFecha.Value;
                    try
                    {
                        dgvEgreso.DataSource =
                            miBussinesIngreso.Ingresos(FechaActual, RowIngreso, RowMaxIngreso);
                        TotalRowIngreso = miBussinesIngreso.GetRowsIngresos(FechaActual);
                        if (dgvEgreso.RowCount.Equals(0))
                        {
                            LimpiarCuentas();
                            OptionPane.MessageInformation("No se encontrarón registros de Egreso en esa Fecha.");
                        }
                    }
                    catch (Exception ex)
                    {
                        OptionPane.MessageError(ex.Message);
                    }
                }
                else  // periodo
                {
                    RowIngreso = 0;
                    Iteracion = 2;
                    CurrentPageIngreso = 1;
                    FechaActual = dtpFecha.Value;
                    FechaActual1 = dtpFecha1.Value;
                    try
                    {
                       /* dgvEgreso.DataSource = miBussinesEgreso.Listado
                            (dtpFecha.Value, dtpFecha1.Value, chkAnulado.Checked, RowIngreso, RowMaxIngreso);
                        TotalRowIngreso = miBussinesEgreso.GetRowslistado
                            (dtpFecha.Value, dtpFecha1.Value, chkAnulado.Checked);*/
                        dgvEgreso.DataSource =
                            miBussinesIngreso.Ingresos(FechaActual, FechaActual1, RowIngreso, RowMaxIngreso);
                        TotalRowIngreso = miBussinesIngreso.GetRowsIngresos(FechaActual, FechaActual1);
                        if (dgvEgreso.RowCount.Equals(0))
                        {
                            LimpiarCuentas();
                            OptionPane.MessageInformation("No se encontrarón registros de Ingresos en ese periodo.");
                        }
                    }
                    catch (Exception ex)
                    {
                        OptionPane.MessageError(ex.Message);
                    }
                }
                CalcularPaginas();
            }
            if (!dgvEgreso.RowCount.Equals(0))
            {
                dgvEgreso_CellClick(this.dgvEgreso, null);
            }
        }

        private void dgvEgreso_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvEgreso.RowCount != 0)
            {
                var id = (int)dgvEgreso.CurrentRow.Cells["Id"].Value;
                try
                {
                    dgvCuentas.DataSource =  DsConcepto = miBussinesIngreso.ConceptosDeIngreso(id);
                    var beneficio = miBussinesBeneficio.BeneficiarioId
                                   (Convert.ToInt32(dgvEgreso.CurrentRow.Cells["IdBeneficio"].Value));
                    txtNit.Text = beneficio.NitCliente;
                    txtNombre.Text = beneficio.NombresCliente;
                }
                catch (Exception ex)
                {
                    OptionPane.MessageError(ex.Message);
                }
            }
        }

        private void btnFormasPago_Click(object sender, EventArgs e)
        {
            /*if (dgvEgreso.RowCount != 0)
            {
                var frmPagos = new Aplicacion.Compras.Egreso.FrmPagosEgreso();
                frmPagos.MdiParent = this.MdiParent;
                frmPagos.txtNoEgreso.Text = dgvEgreso.CurrentRow.Cells["Numero"].Value.ToString();
                var pagos = new List<FormaPago>();
                try
                {
                    pagos = miBussinesEgreso.PagosEgreso(Convert.ToInt32(dgvEgreso.CurrentRow.Cells["Id"].Value));
                }
                catch (Exception ex)
                {
                    OptionPane.MessageError(ex.Message);
                }
                var efe = 0;
                var che = 0;
                foreach (var pago in pagos)
                {
                    if (pago.IdFormaPago.Equals(1))
                    {
                        efe += Convert.ToInt32(pago.Valor);
                    }
                    else
                    {
                        che += Convert.ToInt32(pago.Valor);
                    }
                }
                frmPagos.txtEfectivo.Text = UseObject.InsertSeparatorMil(efe.ToString());
                frmPagos.txtCheque.Text = UseObject.InsertSeparatorMil(che.ToString());
                frmPagos.Show();
            }
            else
            {
                OptionPane.MessageInformation("No hay registros para consultar.");
            }*/
        }

        private void btnAnular_Click(object sender, EventArgs e)
        {
            if (dgvEgreso.RowCount != 0)
            {
                if (dgvEgreso.CurrentRow.Cells["Estado"].Value.ToString().Equals("OK"))
                {
                    DialogResult rta = MessageBox.Show("¿Está seguro(a) de querer anular el Recibo de Caja?", "Egreso",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (rta.Equals(DialogResult.Yes))
                    {
                        try
                        {
                            miBussinesIngreso.AnularIngreso
                                (Convert.ToInt32(dgvEgreso.CurrentRow.Cells["Id"].Value));
                            /*miBussinesEgreso.AnularEgreso
                                (Convert.ToInt32(dgvEgreso.CurrentRow.Cells["Id"].Value));*/
                            btnBuscar_Click(this.btnBuscarFe, new EventArgs());
                        }
                        catch (Exception ex)
                        {
                            OptionPane.MessageError(ex.Message);
                        }
                    }
                }
                else
                {
                    OptionPane.MessageInformation("El Egreso ya está anulado.");
                }
            }
            else
            {
                OptionPane.MessageInformation("No hay registros para anular.");
            }
        }

        private void btnInicio_Click(object sender, EventArgs e)
        {
            if (CurrentPageIngreso > 1)
            {
                var paginaActual = CurrentPageIngreso;
                for (int i = paginaActual; i > 1; i--)
                {
                    RowIngreso = RowIngreso - RowMaxIngreso;
                    CurrentPageIngreso--;
                }
                try
                {
                    switch (Iteracion)
                    {
                        case 1:
                            {
                                dgvEgreso.DataSource =
                                    miBussinesIngreso.Ingresos(FechaActual, RowIngreso, RowMaxIngreso);
                                break;
                            }
                        case 2:
                            {
                                dgvEgreso.DataSource =
                                    miBussinesIngreso.Ingresos(FechaActual, FechaActual1, RowIngreso, RowMaxIngreso);
                                break;
                            }
                        case 3:
                            {
                                dgvEgreso.DataSource =
                                    miBussinesIngreso.Ingresos(RowIngreso, RowMaxIngreso);
                                break;
                            }
                    }
                    lblStatusEgreso.Text = CurrentPageIngreso + " / " + PaginasIngreso;
                    if (!dgvEgreso.RowCount.Equals(0))
                    {
                        dgvEgreso_CellClick(this.dgvEgreso, null);
                    }
                }
                catch (Exception ex)
                {
                    OptionPane.MessageError(ex.Message);
                }
            }
        }

        private void btnAnterior_Click(object sender, EventArgs e)
        {
            if (CurrentPageIngreso > 1)
            {
                RowIngreso = RowIngreso - RowMaxIngreso;
                if (RowIngreso <= 0)
                    RowIngreso = 0;
                try
                {
                    switch (Iteracion)
                    {
                        case 1:
                            {
                                dgvEgreso.DataSource =
                                    miBussinesIngreso.Ingresos(FechaActual, RowIngreso, RowMaxIngreso);
                                break;
                            }
                        case 2:
                            {
                                dgvEgreso.DataSource =
                                    miBussinesIngreso.Ingresos(FechaActual, FechaActual1, RowIngreso, RowMaxIngreso);
                                break;
                            }
                        case 3:
                            {
                                dgvEgreso.DataSource =
                                    miBussinesIngreso.Ingresos(RowIngreso, RowMaxIngreso);
                                break;
                            }
                    }
                    CurrentPageIngreso--;
                    lblStatusEgreso.Text = CurrentPageIngreso + " / " + PaginasIngreso;
                    if (!dgvEgreso.RowCount.Equals(0))
                    {
                        dgvEgreso_CellClick(this.dgvEgreso, null);
                    }
                }
                catch (Exception ex)
                {
                    OptionPane.MessageError(ex.Message);
                }
            }
        }

        private void btnSiguiente_Click(object sender, EventArgs e)
        {
            if (CurrentPageIngreso < PaginasIngreso)
            {
                RowIngreso = RowIngreso + RowMaxIngreso;
                try
                {
                    switch (Iteracion)
                    {
                        case 1:
                            {
                                dgvEgreso.DataSource =
                                    miBussinesIngreso.Ingresos(FechaActual, RowIngreso, RowMaxIngreso);
                                break;
                            }
                        case 2:
                            {
                                dgvEgreso.DataSource =
                                    miBussinesIngreso.Ingresos(FechaActual, FechaActual1, RowIngreso, RowMaxIngreso);
                                break;
                            }
                        case 3:
                            {
                                dgvEgreso.DataSource =
                                    miBussinesIngreso.Ingresos(RowIngreso, RowMaxIngreso);
                                break;
                            }
                    }
                    CurrentPageIngreso++;
                    lblStatusEgreso.Text = CurrentPageIngreso + " / " + PaginasIngreso;
                    if (!dgvEgreso.RowCount.Equals(0))
                    {
                        dgvEgreso_CellClick(this.dgvEgreso, null);
                    }
                }
                catch (Exception ex)
                {
                    OptionPane.MessageError(ex.Message);
                }
            }
        }

        private void btnFin_Click(object sender, EventArgs e)
        {
            if (CurrentPageIngreso < PaginasIngreso)
            {
                var paginaActual = CurrentPageIngreso;
                for (int i = paginaActual; i < PaginasIngreso; i++)
                {
                    RowIngreso = RowIngreso + RowMaxIngreso;
                    CurrentPageIngreso++;
                    try
                    {
                        switch (Iteracion)
                        {
                            case 1:
                                {
                                    dgvEgreso.DataSource =
                                        miBussinesIngreso.Ingresos(FechaActual, RowIngreso, RowMaxIngreso);
                                    break;
                                }
                            case 2:
                                {
                                    dgvEgreso.DataSource =
                                        miBussinesIngreso.Ingresos(FechaActual, FechaActual1, RowIngreso, RowMaxIngreso);
                                    break;
                                }
                            case 3:
                                {
                                    dgvEgreso.DataSource =
                                        miBussinesIngreso.Ingresos(RowIngreso, RowMaxIngreso);
                                    break;
                                }
                        }
                        lblStatusEgreso.Text = CurrentPageIngreso + " / " + PaginasIngreso;
                        if (!dgvEgreso.RowCount.Equals(0))
                        {
                            dgvEgreso_CellClick(this.dgvEgreso, null);
                        }
                    }
                    catch (Exception ex)
                    {
                        OptionPane.MessageError(ex.Message);
                    }
                }
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
            cbCriterio.DataSource = lst;

            lst = new List<Inventario.Producto.Criterio>();
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

        private void CalcularPaginas()
        {
            PaginasIngreso = TotalRowIngreso / RowMaxIngreso;
            if (TotalRowIngreso % RowMaxIngreso != 0)
                PaginasIngreso++;
            if (CurrentPageIngreso > PaginasIngreso)
                CurrentPageIngreso = 0;
            lblStatusEgreso.Text = CurrentPageIngreso + " / " + PaginasIngreso;
        }

        private void LimpiarCuentas()
        {
            while (dgvCuentas.RowCount != 0)
            {
                dgvCuentas.Rows.RemoveAt(0);
            }
        }

        public void ImpirmirPos(OtroIngreso ingreso)
        {
            try
            {
                var bussinesEmpresa = new BussinesEmpresa();
                var bussinesCaja = new BussinesCaja();
                var bussinesUser = new BussinesUsuario();

                var MiEmpresa = bussinesEmpresa.ObtenerEmpresa();
                var caja = bussinesCaja.CajaId(ingreso.IdCaja);
                var usuario = bussinesUser.ConsultaUsuario(ingreso.IdUsuario).AsEnumerable().First()["nombre"].ToString();
                var cliente = miBussinesBeneficio.BeneficiarioId(ingreso.Relacion);

                Ticket ticket = new Ticket();

                ticket.AddHeaderLine(MiEmpresa.NombreComercialEmpresa.ToUpper());
                ticket.AddHeaderLine(MiEmpresa.NombreJuridicoEmpresa.ToString());
                ticket.AddHeaderLine("NIT " + UseObject.InsertSeparatorMilMasDigito(MiEmpresa.NitEmpresa));
                ticket.AddHeaderLine(MiEmpresa.DireccionEmpresa);
                ticket.AddHeaderLine("Tels. " + MiEmpresa.TelefonoEmpresa);
                ticket.AddHeaderLine("Fecha : " + ingreso.Fecha.ToShortDateString() +
                                     "    Caja : " + caja.Numero);
                ticket.AddHeaderLine("Cajero(a)  :  " + usuario);
                ticket.AddHeaderLine("===================================");
                ticket.AddHeaderLine("RECIBO DE CAJA Nro " + ingreso.Numero);
                ticket.AddHeaderLine("===================================");
                ticket.AddHeaderLine("Recibido de : " + cliente.NombresCliente);
                ticket.AddHeaderLine("NIT o C.C.  : " + UseObject.InsertSeparatorMilMasDigito(cliente.NitCliente));
                ticket.AddHeaderLine("===================================");
                foreach (DataRow concepto in this.DsConcepto.Rows)
                {
                    ticket.AddItem("",
                                   concepto["concepto"].ToString(),
                                   UseObject.InsertSeparatorMil(concepto["valor"].ToString()));
                }
                ticket.AddTotal("TOTAL ", UseObject.InsertSeparatorMil(ingreso.Valor.ToString()));
                ticket.AddTotal(" ", " ");
                foreach (DataRow pago in miBussinesIngreso.FormasDePago(ingreso.Id).Rows)
                {
                    string namePago = "";
                    switch (Convert.ToInt32(pago["idforma_pago"]))
                    {
                        case 1:
                            {
                                namePago = "Efectivo";
                                break;
                            }
                        case 2:
                            {
                                namePago = "Cheque";
                                break;
                            }
                        case 4:
                            {
                                namePago = "Transacción";
                                break;
                            }
                    }
                    ticket.AddTotal(namePago,
                                    UseObject.InsertSeparatorMil(pago["valor"].ToString()));
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
                ticket.AddFooterLine("solucionestecnologicasayc@gmail.com");
                ticket.AddFooterLine(".");

                ticket.PrintTicket("IMPREPOS");
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
        }

       // private DataTable Cuentas(int idEgreso)
        //{
           // var tabla = new DataTable();
            /*tabla.TableName = "CuentaPuc";
            tabla.Columns.Add(new DataColumn("Codigo", typeof(int)));
            tabla.Columns.Add(new DataColumn("Concepto", typeof(string)));
            tabla.Columns.Add(new DataColumn("Valor", typeof(int)));
            try
            {
                var t = miBussinesEgreso.EgresoPuc(idEgreso);
                foreach (DataRow row in t.Rows)
                {
                    var row_ = tabla.NewRow();
                    row_["Codigo"] = row["codigo"];
                    row_["Concepto"] = row["concepto"];
                    row_["Valor"] = row["valor"];
                    tabla.Rows.Add(row_);
                }
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }*/

            //return tabla;
       // }
    }
}