using BussinesLayer.Clases;
using CustomControl;
using DTO.Clases;
using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Utilities;

namespace Aplicacion.Ventas.Cliente.Anticipos
{
    public partial class FrmAnticipo : Form
    {
        private bool Search;

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

        private string NitActual;

        private string NitCanjeActual;

        private DateTime FechaActual;

        private DateTime Fecha2Actual;


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

        private BussinesSaldo miBussinesSaldo;

        private BussinesCliente miBussinesCliente;

        public FrmAnticipo()
        {
            InitializeComponent();
            this.Search = false;

            this.RowMaxSaldo = 12;
            this.RowMaxCanje = 12;
            this.miBussinesSaldo = new BussinesSaldo();
            this.miBussinesCliente = new BussinesCliente();
        }

        private void FrmAnticipo_Load(object sender, EventArgs e)
        {
            this.dgvAnticipos.AutoGenerateColumns = false;
            this.dgvCanje.AutoGenerateColumns = false;

            CompletaEventos.CompletaRemision += new CompletaEventos.CompletaAccionRemision(CompletaEventos_CompletaRemision);
            CompletaEventos.CompletaRetiroAdelanto += new CompletaEventos.CompletaAccionRetiroAdelanto(CompletaEventos_CompletaRetiroAdelanto);

            var lst = new List<Inventario.Producto.Criterio>();
            lst.Add(new Inventario.Producto.Criterio
            {
                Id = 1,
                Nombre = "Todos",
            });
            lst.Add(new Inventario.Producto.Criterio
            {
                Id = 2,
                Nombre = "Cliente",
            });
            lst.Add(new Inventario.Producto.Criterio
            {
                Id = 3,
                Nombre = "Clientes con saldo",
            });
            cbCriterio.DataSource = lst;

            lst = new List<Inventario.Producto.Criterio>();
            lst.Add(new Inventario.Producto.Criterio
            {
                Id = 1,
                Nombre = "Fecha",
            });
            lst.Add(new Inventario.Producto.Criterio
            {
                Id = 2,
                Nombre = "Periodo",
            });
            cbFecha.DataSource = lst;
        }

        private void tsBtnListarTodos_Click(object sender, EventArgs e)
        {
            try
            {
                this.Search = false;
                this.Iteracion = 1;
                this.RowIndexSaldo = 0;
                this.CurrentPageSaldo = 1;
                this.dgvAnticipos.DataSource = this.miBussinesSaldo.Anticipos(this.RowIndexSaldo, this.RowMaxSaldo);
                this.TotalRowSaldo = this.miBussinesSaldo.GetRowsAnticipos();
                this.txtSaldo.Text = UseObject.InsertSeparatorMil(this.miBussinesSaldo.TotalAnticiposSaldo().ToString());

                this.CalcularPaginas();
                this.ColorGridAnticipos();
                this.dgvAnticipos_CellClick(this.dgvAnticipos, null);
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.dgvAnticipos.Rows.Count > 0)
                {
                    var tabla = new DataTable();
                    switch(this.Iteracion)
                    {
                        case 1:
                            {
                                tabla = this.miBussinesSaldo.AnticiposSaldo();
                                break;
                            }
                        case 2:
                            {
                                tabla = this.miBussinesSaldo.AnticiposSaldo(this.FechaActual);
                                break;
                            }
                        case 3:
                            {
                                tabla = this.miBussinesSaldo.AnticiposSaldo(this.FechaActual, this.Fecha2Actual);
                                break;
                            }
                        case 4:
                            {
                                tabla = this.miBussinesSaldo.AnticiposSaldo(this.NitActual, this.FechaActual);
                                break;
                            }
                        case 5:
                            {
                                tabla = this.miBussinesSaldo.AnticiposSaldo(this.NitActual, this.FechaActual, this.Fecha2Actual);
                                break;
                            }
                        case 6:
                            {
                                tabla = this.miBussinesSaldo.AnticiposSaldo();
                                break;
                            }
                    }
                    tabla.TableName = "AnticiposCliente";

                    var miBussinesEmpresa = new BussinesEmpresa();
                    var frmPrint = new Compras.Egreso.FrmPrintInforme();

                    frmPrint.rpvEgresos.LocalReport.DataSources.Clear();
                    frmPrint.rpvEgresos.LocalReport.Dispose();
                    frmPrint.rpvEgresos.Reset();

                    frmPrint.rpvEgresos.LocalReport.DataSources.Add(
                                new ReportDataSource("DsEmpresa", miBussinesEmpresa.PrintEmpresa().Tables[0]));
                    frmPrint.rpvEgresos.LocalReport.DataSources.Add(new ReportDataSource("DsAnticiposCliente", tabla));
                    frmPrint.rpvEgresos.LocalReport.ReportPath = AppConfiguracion.ValorSeccion("report") + @"\reports\InformeAnticiposCliente.rdlc";
                    //frmPrint.rpvEgresos.LocalReport.ReportPath = @"C:\reports\InformeAnticiposCliente.rdlc";

                    var pFecha = new ReportParameter();
                    pFecha.Name = "Consulta";
                    if (this.Iteracion.Equals(1) || this.Iteracion.Equals(6))
                    {
                        pFecha.Values.Add("Fecha: " + DateTime.Now.ToShortDateString());
                    }
                    else
                    {
                        if (Convert.ToInt32(this.cbFecha.SelectedValue).Equals(1))
                        {
                            pFecha.Values.Add("Fecha: " + this.FechaActual.ToShortDateString());
                        }
                        else
                        {
                            pFecha.Values.Add("Periodo: " + this.FechaActual.ToShortDateString() + " a " + this.Fecha2Actual.ToShortDateString());
                        }
                    }
                    frmPrint.rpvEgresos.LocalReport.SetParameters(pFecha);

                    frmPrint.rpvEgresos.RefreshReport();
                    frmPrint.ShowDialog();
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

        private void btnImprimirCopia_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.dgvAnticipos.RowCount != 0)
                {
                    if (Convert.ToBoolean(AppConfiguracion.ValorSeccion("printRboAnticpo")))
                    {
                        PrintAnticipoPos(Convert.ToInt32(this.dgvAnticipos.CurrentRow.Cells["Id"].Value));
                    }
                    else
                    {
                        PrintAnticipo(Convert.ToInt32(this.dgvAnticipos.CurrentRow.Cells["Id"].Value));
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

        private void btnImprimirRetiro_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.dgvCanje.Rows.Count > 0)
                {
                    var canje = this.miBussinesSaldo.Canje(Convert.ToInt32(this.dgvCanje.CurrentRow.Cells["IdC"].Value));
                    if (Convert.ToBoolean(AppConfiguracion.ValorSeccion("printRboAnticpo")))
                    {
                        PrintReciboRetiroPos(canje);
                    }
                    else
                    {
                        PrintReciboRetiro(canje);
                    }
                }
                else
                {
                    OptionPane.MessageInformation("No hay retiros para imprimir.");
                }
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
        }

        private void tsBtnRetiro_Click(object sender, EventArgs e)
        {
            if (!this.dgvAnticipos.RowCount.Equals(0))
            {
                if (Convert.ToBoolean(this.dgvAnticipos.CurrentRow.Cells["Estado"].Value))
                {
                    int saldo = this.miBussinesSaldo.SaldoEnAdelantos(this.dgvAnticipos.CurrentRow.Cells["Nit"].Value.ToString());
                    if (saldo > 0)
                    {
                        var frmRetiro = new Retiro.Adelanto.FrmRetiroAdelanto();
                        frmRetiro.MaxValor = saldo;
                        //frmRetiro.MaxValor = Convert.ToInt32(this.dgvAnticipos.CurrentRow.Cells["Saldo"].Value);
                        frmRetiro.ShowDialog();
                    }
                    else
                    {
                        OptionPane.MessageInformation("El cliente no presenta saldo en anticipos.");
                    }
                }
                else
                {
                    OptionPane.MessageInformation("El anticipo se encuentra anulado.");
                }
            }
            else
            {
                OptionPane.MessageInformation("Debe cargar una consulta.");
            }
        }

        private void tsBtnAnular_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.dgvAnticipos.Rows.Count > 0)
                {
                    if (Convert.ToBoolean(this.dgvAnticipos.CurrentRow.Cells["Estado"].Value))
                    {
                        if (this.dgvCanje.Rows.Count.Equals(0))
                        {
                            DialogResult rta = MessageBox.Show("¿Esta seguro(a) de anular el anticipo?", "Anticipos de cliente",
                                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                            if (rta.Equals(DialogResult.Yes))
                            {
                                this.miBussinesSaldo.AnularSaldo(Convert.ToInt32(this.dgvAnticipos.CurrentRow.Cells["Id"].Value));
                                OptionPane.MessageInformation("El anticipo se anulo con exito.");
                                this.btnBuscar_Click(this.btnBuscar, new EventArgs());
                            }
                        }
                        else
                        {
                            OptionPane.MessageInformation("El anticipo no se puede anular.");
                        }
                    }
                    else
                    {
                        OptionPane.MessageInformation("El anticipo ya esta anulado.");
                    }
                }
                else
                {

                }
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
        }

        private void cbCriterio_SelectionChangeCommitted(object sender, EventArgs e)
        {
            switch(Convert.ToInt32(this.cbCriterio.SelectedValue))
            {
                case 1:
                    {
                        this.txtTercero.Enabled = false;
                        this.btnBuscarTercero.Enabled = false;
                        this.cbFecha.Enabled = true;
                        this.cbFecha.SelectedIndex = 0;
                        this.cbFecha_SelectionChangeCommitted(this.cbFecha, new EventArgs());
                        break;
                    }
                case 2:
                    {
                        this.txtTercero.Enabled = true;
                        this.btnBuscarTercero.Enabled = true;
                        this.cbFecha.Enabled = true;
                        this.cbFecha.SelectedIndex = 0;
                        this.cbFecha_SelectionChangeCommitted(this.cbFecha, new EventArgs());
                        break;
                    }
                case 3:
                    {
                        this.txtTercero.Enabled = false;
                        this.btnBuscarTercero.Enabled = false;
                        this.cbFecha.Enabled = false;
                        break;
                    }
            }
        }

        private void btnBuscarTercero_Click(object sender, EventArgs e)
        {
            var frmCliente = new Cliente.frmCliente();
            frmCliente.Remision = true;
            frmCliente.tcClientes.SelectedIndex = 1;
            frmCliente.ShowDialog();
        }

        private void cbFecha_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (Convert.ToInt32(this.cbFecha.SelectedValue).Equals(1))
            {
                this.dtpFecha1.Enabled = true;
                this.dtpFecha2.Enabled = false;
            }
            else
            {
                this.dtpFecha1.Enabled = true;
                this.dtpFecha2.Enabled = true;
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                this.Search = true;
                this.RowIndexSaldo = 0;
                this.CurrentPageSaldo = 1;
                this.NitActual = this.txtTercero.Text;
                this.FechaActual = this.dtpFecha1.Value;
                this.Fecha2Actual = this.dtpFecha2.Value;
                if(Convert.ToInt32(this.cbCriterio.SelectedValue) != 3)
                {
                    if (Convert.ToInt32(this.cbCriterio.SelectedValue).Equals(1))  // TODOS + FECHA
                    {
                        if (Convert.ToInt32(this.cbFecha.SelectedValue).Equals(1)) // FECHA
                        {
                            this.Iteracion = 2;
                            this.dgvAnticipos.DataSource = this.miBussinesSaldo.Anticipos(this.FechaActual, RowIndexSaldo, RowMaxSaldo);
                            this.TotalRowSaldo = this.miBussinesSaldo.GetRowsAnticipos(this.FechaActual);
                            this.txtSaldo.Text = UseObject.InsertSeparatorMil(this.miBussinesSaldo.TotalAnticiposSaldo(this.FechaActual).ToString());
                        }
                        else   //  PERIODO
                        {
                            this.Iteracion = 3;
                            this.dgvAnticipos.DataSource = this.miBussinesSaldo.Anticipos(this.FechaActual, this.Fecha2Actual, RowIndexSaldo, RowMaxSaldo);
                            this.TotalRowSaldo = this.miBussinesSaldo.GetRowsAnticipos(this.FechaActual, this.Fecha2Actual);
                            this.txtSaldo.Text = 
                                UseObject.InsertSeparatorMil(this.miBussinesSaldo.TotalAnticiposSaldo(this.FechaActual, this.Fecha2Actual).ToString());
                        }
                    }
                    else  // CLIENTE
                    {
                        if (Convert.ToInt32(this.cbFecha.SelectedValue).Equals(1))  // CLIENTE + FECHA
                        {
                            this.Iteracion = 4;
                            this.dgvAnticipos.DataSource = this.miBussinesSaldo.Anticipos(this.NitActual, this.FechaActual, RowIndexSaldo, RowMaxSaldo);
                            this.TotalRowSaldo = this.miBussinesSaldo.GetRowsAnticipos(this.NitActual, this.FechaActual);
                            this.txtSaldo.Text = UseObject.InsertSeparatorMil(this.miBussinesSaldo.TotalAnticiposSaldo(this.NitActual, this.FechaActual).ToString());
                        }
                        else  // PERIODO
                        {
                            this.Iteracion = 5;
                            this.Fecha2Actual = this.dtpFecha2.Value;
                            this.dgvAnticipos.DataSource = this.miBussinesSaldo.Anticipos
                                                (this.NitActual, this.FechaActual, this.Fecha2Actual, RowIndexSaldo, RowMaxSaldo);
                            this.TotalRowSaldo = this.miBussinesSaldo.GetRowsAnticipos(this.NitActual, this.FechaActual, this.Fecha2Actual);
                            this.txtSaldo.Text =
                                UseObject.InsertSeparatorMil(this.miBussinesSaldo.TotalAnticiposSaldo(this.NitActual, this.FechaActual, this.Fecha2Actual).ToString());
                        }
                    }
                }
                else // CLIENTES CON SALDO
                {
                    this.Iteracion = 6;
                    this.dgvAnticipos.DataSource = this.miBussinesSaldo.AnticiposSaldo(this.RowIndexSaldo, this.RowMaxSaldo);
                    this.TotalRowSaldo = this.miBussinesSaldo.GetRowsAnticiposSaldo();
                    this.txtSaldo.Text = UseObject.InsertSeparatorMil(this.miBussinesSaldo.TotalAnticiposSaldo().ToString());
                }
                this.CalcularPaginas();
                this.ColorGridAnticipos();
                this.dgvAnticipos_CellClick(this.dgvAnticipos, null);
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
        }

        private void dgvAnticipos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (this.dgvAnticipos.Rows.Count > 0)
                {
                    this.RowIndexCanje = 0;
                    this.CurrentPageCanje = 1;
                    this.NitCanjeActual = this.dgvAnticipos.CurrentRow.Cells["Nit"].Value.ToString();
                    try
                    {
                        this.dgvCanje.DataSource = miBussinesSaldo.Canjes(Convert.ToInt32(this.dgvAnticipos.CurrentRow.Cells["Id"].Value));
                        this.TotalRowCanje = 0;
                        //this.dgvCanje.DataSource = miBussinesSaldo.CanjesCliente(this.NitCanjeActual, this.RowIndexCanje, this.RowMaxCanje);
                        //this.TotalRowCanje = miBussinesSaldo.GetRowsCanjesCliente(this.NitCanjeActual);
                    }
                    catch (Exception ex)
                    {
                        OptionPane.MessageError(ex.Message);
                    }
                    CalcularPaginasCanje();
                }
                else
                {
                    this.dgvCanje.DataSource = null;
                    this.TotalRowCanje = 0;
                    CalcularPaginasCanje();
                }
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
        }

        //
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
                    switch(this.Iteracion)
                    {
                        case 1:
                            {
                                this.dgvAnticipos.DataSource = this.miBussinesSaldo.Anticipos(this.RowIndexSaldo, this.RowMaxSaldo);
                                break;
                            }
                        case 2:
                            {
                                this.dgvAnticipos.DataSource = this.miBussinesSaldo.Anticipos(this.FechaActual, RowIndexSaldo, RowMaxSaldo);
                                break;
                            }
                        case 3:
                            {
                                this.dgvAnticipos.DataSource = this.miBussinesSaldo.Anticipos(this.FechaActual, this.Fecha2Actual, RowIndexSaldo, RowMaxSaldo);
                                break;
                            }
                        case 4:
                            {
                                this.dgvAnticipos.DataSource = this.miBussinesSaldo.Anticipos(this.NitActual, this.FechaActual, RowIndexSaldo, RowMaxSaldo);
                                break;
                            }
                        case 5:
                            {
                                this.dgvAnticipos.DataSource = 
                                    this.miBussinesSaldo.Anticipos(this.NitActual, this.FechaActual, this.Fecha2Actual, RowIndexSaldo, RowMaxSaldo);
                                break;
                            }
                        case 6:
                            {
                                this.dgvAnticipos.DataSource = this.miBussinesSaldo.AnticiposSaldo(this.RowIndexSaldo, this.RowMaxSaldo);
                                break;
                            }
                    }
                    this.dgvAnticipos_CellClick(this.dgvAnticipos, null);
                    lblStatusSaldo.Text = CurrentPageSaldo + " / " + PaginasSaldo;
                    this.ColorGridAnticipos();
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
                    switch (this.Iteracion)
                    {
                        case 1:
                            {
                                this.dgvAnticipos.DataSource = this.miBussinesSaldo.Anticipos(this.RowIndexSaldo, this.RowMaxSaldo);
                                break;
                            }
                        case 2:
                            {
                                this.dgvAnticipos.DataSource = this.miBussinesSaldo.Anticipos(this.FechaActual, RowIndexSaldo, RowMaxSaldo);
                                break;
                            }
                        case 3:
                            {
                                this.dgvAnticipos.DataSource = this.miBussinesSaldo.Anticipos(this.FechaActual, this.Fecha2Actual, RowIndexSaldo, RowMaxSaldo);
                                break;
                            }
                        case 4:
                            {
                                this.dgvAnticipos.DataSource = this.miBussinesSaldo.Anticipos(this.NitActual, this.FechaActual, RowIndexSaldo, RowMaxSaldo);
                                break;
                            }
                        case 5:
                            {
                                this.dgvAnticipos.DataSource =
                                    this.miBussinesSaldo.Anticipos(this.NitActual, this.FechaActual, this.Fecha2Actual, RowIndexSaldo, RowMaxSaldo);
                                break;
                            }
                        case 6:
                            {
                                this.dgvAnticipos.DataSource = this.miBussinesSaldo.AnticiposSaldo(this.RowIndexSaldo, this.RowMaxSaldo);
                                break;
                            }
                    }
                    this.dgvAnticipos_CellClick(this.dgvAnticipos, null);

                    CurrentPageSaldo--;
                    lblStatusSaldo.Text = CurrentPageSaldo + " / " + PaginasSaldo;
                    this.ColorGridAnticipos();
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
                    switch (this.Iteracion)
                    {
                        case 1:
                            {
                                this.dgvAnticipos.DataSource = this.miBussinesSaldo.Anticipos(this.RowIndexSaldo, this.RowMaxSaldo);
                                break;
                            }
                        case 2:
                            {
                                this.dgvAnticipos.DataSource = this.miBussinesSaldo.Anticipos(this.FechaActual, RowIndexSaldo, RowMaxSaldo);
                                break;
                            }
                        case 3:
                            {
                                this.dgvAnticipos.DataSource = this.miBussinesSaldo.Anticipos(this.FechaActual, this.Fecha2Actual, RowIndexSaldo, RowMaxSaldo);
                                break;
                            }
                        case 4:
                            {
                                this.dgvAnticipos.DataSource = this.miBussinesSaldo.Anticipos(this.NitActual, this.FechaActual, RowIndexSaldo, RowMaxSaldo);
                                break;
                            }
                        case 5:
                            {
                                this.dgvAnticipos.DataSource =
                                    this.miBussinesSaldo.Anticipos(this.NitActual, this.FechaActual, this.Fecha2Actual, RowIndexSaldo, RowMaxSaldo);
                                break;
                            }
                        case 6:
                            {
                                this.dgvAnticipos.DataSource = this.miBussinesSaldo.AnticiposSaldo(this.RowIndexSaldo, this.RowMaxSaldo);
                                break;
                            }
                    }
                    this.dgvAnticipos_CellClick(this.dgvAnticipos, null);

                    CurrentPageSaldo++;
                    lblStatusSaldo.Text = CurrentPageSaldo + " / " + PaginasSaldo;
                    this.ColorGridAnticipos();
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
                    switch (this.Iteracion)
                    {
                        case 1:
                            {
                                this.dgvAnticipos.DataSource = this.miBussinesSaldo.Anticipos(this.RowIndexSaldo, this.RowMaxSaldo);
                                break;
                            }
                        case 2:
                            {
                                this.dgvAnticipos.DataSource = this.miBussinesSaldo.Anticipos(this.FechaActual, RowIndexSaldo, RowMaxSaldo);
                                break;
                            }
                        case 3:
                            {
                                this.dgvAnticipos.DataSource = this.miBussinesSaldo.Anticipos(this.FechaActual, this.Fecha2Actual, RowIndexSaldo, RowMaxSaldo);
                                break;
                            }
                        case 4:
                            {
                                this.dgvAnticipos.DataSource = this.miBussinesSaldo.Anticipos(this.NitActual, this.FechaActual, RowIndexSaldo, RowMaxSaldo);
                                break;
                            }
                        case 5:
                            {
                                this.dgvAnticipos.DataSource =
                                    this.miBussinesSaldo.Anticipos(this.NitActual, this.FechaActual, this.Fecha2Actual, RowIndexSaldo, RowMaxSaldo);
                                break;
                            }
                        case 6:
                            {
                                this.dgvAnticipos.DataSource = this.miBussinesSaldo.AnticiposSaldo(this.RowIndexSaldo, this.RowMaxSaldo);
                                break;
                            }
                    }
                    this.dgvAnticipos_CellClick(this.dgvAnticipos, null);
                    lblStatusSaldo.Text = CurrentPageSaldo + " / " + PaginasSaldo;
                    this.ColorGridAnticipos();
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
                        miBussinesSaldo.CanjesCliente(NitCanjeActual, RowIndexSaldo, RowMaxSaldo);
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
                        miBussinesSaldo.CanjesCliente(NitCanjeActual, RowIndexSaldo, RowMaxSaldo);
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
                        miBussinesSaldo.CanjesCliente(NitCanjeActual, RowIndexSaldo, RowMaxSaldo);
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
                        miBussinesSaldo.CanjesCliente(NitCanjeActual, RowIndexSaldo, RowMaxSaldo);
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
                this.txtTercero.Text = (string)args.MiObjeto;
                //this.txtTercero_KeyPress(this.txtTercero, new KeyPressEventArgs((char)Keys.Enter));
            }
            catch { }

            try
            {
                //ExtendForm = Convert.ToBoolean(args.MiObjeto);
            }
            catch { }
        }

        void CompletaEventos_CompletaRetiroAdelanto(CompletaArgumentosRetiroAdelanto args)
        {
            try
            {
                var obj = (ObjectAbstract)args.MiObjeto;
                if (obj.Id.Equals(90001))
                {
                    IngresarCanje(Convert.ToInt32(obj.Objeto));
                }
            }
            catch { }
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

        private void ColorGridAnticipos()
        {
            foreach(DataGridViewRow gRow in this.dgvAnticipos.Rows)
            {
                if (!(Convert.ToInt32(gRow.Cells["Saldo"].Value) > 0))
                {
                    gRow.DefaultCellStyle.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
                }
                if(!Convert.ToBoolean(gRow.Cells["Estado"].Value))
                {
                    gRow.DefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(200, 128, 128);
                }
            }
        }

        private void PrintAnticipo(int id)
        {
            try
            {
                var miBussinesEmpresa = new BussinesEmpresa();

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
                    (new ReportDataSource("DsEmpresa", miBussinesEmpresa.PrintEmpresa().Tables[0]));

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
                ticket.AddHeaderLine("RECIBO DE ANTICIPO No " + anticipo.Numero);
                ticket.AddHeaderLine("===================================");
                ticket.AddHeaderLine("Recibido de : " + this.dgvAnticipos.CurrentRow.Cells["Nombre"].Value.ToString().ToUpper());
                ticket.AddHeaderLine("NIT o C.C.  : " + UseObject.InsertSeparatorMilMasDigito(anticipo.NitCliente));
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
            //  canje.IdSaldo = Convert.ToInt32(this.dgvAnticipos.CurrentRow.Cells["Id"].Value);
            canje.NitCliente = this.dgvAnticipos.CurrentRow.Cells["Nit"].Value.ToString();
            canje.IdUsuario = Convert.ToInt32(AppConfiguracion.ValorSeccion("id_user"));
            canje.IdCaja = Convert.ToInt32(AppConfiguracion.ValorSeccion("id_caja"));
            canje.Fecha = DateTime.Now;
            canje.Concepto = "RETIRO DE EFECTIVO.";
            // canje.Valor = valor;
            //canje.VSaldo = miBussinesSaldo.SaldoEnAdelantos(canje.NitCliente);
            try
            {
                var bussinesReciboRetiro = new BussinesComprobanteCruce();
                var canjes = miBussinesSaldo.IngresarCanje(canje, valor);
                foreach (Canje canje_ in canjes)
                {
                    var retiro = new ComprobanteCruce();
                    retiro.Fecha = DateTime.Now;
                    retiro.NitCliente = canje.NitCliente;
                    retiro.Concepto = "RETIRO DE ANTICIPO.";
                    retiro.Valor = valor;
                    retiro.Restante = "SALDO : ";
                    retiro.ValorRestante = canje_.VSaldo;
                    retiro.Id = bussinesReciboRetiro.IngresarReciboRetiro(retiro);
                    if (Convert.ToBoolean(AppConfiguracion.ValorSeccion("printRboAnticpo")))
                    {
                        PrintReciboRetiroPos(canje_);
                    }
                    else
                    {
                        PrintReciboRetiro(canje_);
                    }
                }
                if (this.Search)
                {
                    this.btnBuscar_Click(this.btnBuscar, new EventArgs());
                }
                else
                {
                    this.tsBtnListarTodos_Click(this.tsBtnListarTodos, new EventArgs());
                }
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
        }

        private void PrintReciboRetiro(Canje canje)
        {
            try
            {
                FrmPrint frmPrint = new FrmPrint();
                frmPrint.StringCaption = "Anticipo Cliente";
                frmPrint.StringMessage = "Impresión del Recibo de Retiro";
                DialogResult rta = frmPrint.ShowDialog();

                if (!rta.Equals(DialogResult.Cancel))
                {
                    var print = new Factura.FrmComprobanteCruce();
                    var cliente = miBussinesCliente.ClienteAEditar(canje.NitCliente);
                    print.Numero = canje.Id.ToString();
                    print.Titulo = "Retiro de anticipo No.";
                    print.Fecha = canje.Fecha;
                    print.Nit = cliente.NitCliente;
                    print.Cliente = cliente.NombresCliente;
                    print.Direccion = cliente.DireccionCliente + " " + cliente.Ciudad + " " + cliente.Departamento;
                    print.Concepto = canje.Concepto;
                    print.Valor = canje.Valor.ToString();
                    print.Restante = "SALDO: ";
                    //print.VRestante = canje.VSaldo;
                    print.VRestante = this.miBussinesSaldo.SaldoEnAdelantos(canje.NitCliente);

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

        private void PrintReciboRetiroPos(Canje canje)
        {
            try
            {
                var miBussinesEmpresa = new BussinesEmpresa();
                var miBussinesCaja = new BussinesCaja();
                var miBussinesUsuario = new BussinesUsuario();
                var empresaRow = miBussinesEmpresa.PrintEmpresa().Tables[0].AsEnumerable().First();
                var caja = miBussinesCaja.CajaId(canje.IdCaja);
                var usuarioRow = miBussinesUsuario.ConsultaUsuario(canje.IdUsuario).AsEnumerable().First();

                Ticket ticket = new Ticket();

                ticket.AddHeaderLine(empresaRow["Nombre"].ToString().ToUpper());
                ticket.AddHeaderLine(empresaRow["Juridico"].ToString());
                ticket.AddHeaderLine("NIT " + UseObject.InsertSeparatorMilMasDigito(empresaRow["Nit"].ToString()));
                ticket.AddHeaderLine(empresaRow["Direccion"].ToString());
                ticket.AddHeaderLine("Tels. " + empresaRow["Telefono"].ToString());
                ticket.AddHeaderLine("Fecha : " + canje.Fecha.ToShortDateString() +
                                     "    Caja : " + caja.Numero);
                ticket.AddHeaderLine("Cajero(a)  :  " + usuarioRow["nombre"].ToString());
                ticket.AddHeaderLine("===================================");
                ticket.AddHeaderLine("RETIRO DE ANTICIPO No. " + canje.Id.ToString());
                ticket.AddHeaderLine("===================================");
                ticket.AddHeaderLine("AUTORIZADO POR : " + this.dgvAnticipos.CurrentRow.Cells["Nombre"].Value.ToString().ToUpper());
                ticket.AddHeaderLine("NIT o C.C.  : " + UseObject.InsertSeparatorMilMasDigito(canje.NitCliente));
                ticket.AddHeaderLine("===================================");

                ticket.AddItem("",
                               canje.Concepto, UseObject.InsertSeparatorMil(canje.Valor.ToString()));
                ticket.AddItem("", "", "");
                ticket.AddItem("", "SALDO", UseObject.InsertSeparatorMil(this.miBussinesSaldo.SaldoEnAdelantos(canje.NitCliente).ToString()));

               // ticket.AddTotal("TOTAL ", UseObject.InsertSeparatorMil(canje.Valor.ToString()));

                //ticket.AddTotal(" ", " ");

                //ticket.AddFooterLine("===================================");
               // ticket.AddFooterLine("SALDO: " + UseObject.InsertSeparatorMil(canje.VSaldo.ToString()));
                //ticket.AddFooterLine(".");
                ticket.AddFooterLine(".");
                ticket.AddFooterLine("Firma:");
                ticket.AddFooterLine("-----------------------------------");
                ticket.AddFooterLine("C.C. o NIT:");
                ticket.AddFooterLine("-----------------------------------");
              /*  ticket.AddFooterLine("Fecha:");
                ticket.AddFooterLine("-----------------------------------");*/
                ticket.AddFooterLine(".");
                ticket.AddFooterLine("Software: Digital Fact Pyme");
                ticket.AddFooterLine("Soluciones Tecnológicas A&C.");
                ticket.AddFooterLine("solucionestecnologicasayc@gmail.com");
                ticket.AddFooterLine(".");

                ticket.PrintTicket("IMPREPOS");
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
        }
    }
}