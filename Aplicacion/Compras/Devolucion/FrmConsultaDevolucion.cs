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
using Microsoft.Reporting.WinForms;

namespace Aplicacion.Compras.Devolucion
{
    public partial class FrmConsultaDevolucion : Form
    {
        private BussinesEmpresa miBussinesEmpresa;

        private ToolTip miToolTip;

        #region Paginación

        /// <summary>
        /// Obteien o establece el numero que indica que iteracion se realizo.
        /// </summary>
        private int Iteracion;

        /// <summary>
        /// Obtiene o establece el valor del registro a segir o registro base.
        /// </summary>
        private int RowFactura;

        /// <summary>
        /// Obtiene o establece el número maximo de registro a cargar.
        /// </summary>
        private int RowMaxFactura;

        /// <summary>
        /// Obtiene o establece el total de registros en la base de datos.
        /// </summary>
        private long TotalRowFactura;

        /// <summary>
        /// Obtiene o establece el número total de paginas que componen la consulta.
        /// </summary>
        private long PaginasFactura;

        /// <summary>
        /// Obtiene o establece el número de la pagina actual.
        /// </summary>
        private int CurrentPageFactura;

        /// <summary>
        /// Obtiene o establece el valor del Cliente actual de la factura a consultar.
        /// </summary>
        private string ProveedorActual;

        /// <summary>
        /// Obtiene o establece el valor de la primera fecha actual de la factura a consultar.
        /// </summary>
        private DateTime Fecha1Actual;

        /// <summary>
        /// Obtiene o establece el valor de la segunda fecha actual de la factura a consultar.
        /// </summary>
        private DateTime Fecha2Actual;

        #endregion

        private BussinesDevolucion miBussinesDevolucion;

        public FrmConsultaDevolucion()
        {
            InitializeComponent();
            miBussinesDevolucion = new BussinesDevolucion();
            miBussinesEmpresa = new BussinesEmpresa();
            miToolTip = new ToolTip();
            RowMaxFactura = 5;
        }

        private void FrmConsulta_Load(object sender, EventArgs e)
        {
            CargarUtilidades();
        }

        private void tsBtnCopia_Click(object sender, EventArgs e)
        {
            try
            {
                if (!dgvFactura.RowCount.Equals(0))
                {
                    var devolucion = miBussinesDevolucion.DevolucionesDeCompra(
                                          Convert.ToInt32(dgvFactura.CurrentRow.Cells["Id"].Value));
                    if (Convert.ToBoolean(AppConfiguracion.ValorSeccion("printNotaCredito")))
                    {
                        PrintCopiaPos(devolucion);
                    }
                    else
                    {
                        PrintCopia(devolucion);
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

        private void tsBtnVerSaldo_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.dgvFactura.RowCount > 0)
                {
                    var frmSaldo = new IngresarCompra.Saldos.FrmSaldoProveedor();
                    frmSaldo.txtNit.Text = 
                        UseObject.InsertSeparatorMilMasDigito(this.dgvFactura.CurrentRow.Cells["Nit"].Value.ToString());
                    frmSaldo.txtProveedor.Text = this.dgvFactura.CurrentRow.Cells["Cliente"].Value.ToString();
                    frmSaldo.txtSaldo.Text = UseObject.InsertSeparatorMil(this.miBussinesDevolucion.SaldoCompra(
                        Convert.ToInt32(this.dgvFactura.CurrentRow.Cells["CodigoP"].Value)).ToString());
                    frmSaldo.ShowDialog();
                }
                else
                {
                    OptionPane.MessageInformation("Debe cargar una consulta.");
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

        private void cbCriterio_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (Convert.ToInt32(cbCriterio.SelectedValue).Equals(1))
            {
                cbCriterio3.SelectedValue = 1;
                cbCriterio3.Enabled = false;
                txtCodigo.Enabled = true;
            }
            else
            {
                if (Convert.ToInt32(cbCriterio.SelectedValue).Equals(2))
                {
                    cbCriterio3.Enabled = true;
                    txtCodigo.Enabled = true;
                }
                else
                {
                    cbCriterio3.Enabled = true;
                    txtCodigo.Enabled = false;
                }
            }
        }

        private void cbCriterio3_SelectionChangeCommitted(object sender, EventArgs e)
        {
            var criterio3 = Convert.ToInt32(cbCriterio3.SelectedValue);
            if (criterio3 == 2)
            {
                dtpFecha1.Enabled = true;
                dtpFecha2.Enabled = false;
            }
            else
            {
                if (criterio3 == 3)
                {
                    dtpFecha1.Enabled = true;
                    dtpFecha2.Enabled = true;
                }
            }
        }

        private void txtCodigo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar.Equals((char)Keys.Enter))
            {
                this.btnBuscar1_Click(this.btnBuscar1, new EventArgs());
            }
        }

        private void btnBuscar1_Click(object sender, EventArgs e)
        {
            dgvFactura.AutoGenerateColumns = false;
            switch (Convert.ToInt32(cbCriterio.SelectedValue))
            {
                case 1:
                    {
                        ConsultaDevolucion(txtCodigo.Text);
                        break;
                    }
                case 2:
                    {
                        ConsultaDevolucionProveedor(txtCodigo.Text);
                        break;
                    }
                case 3:
                    {
                        ConsultaPorFecha();
                        break;
                    }
            }
            if (dgvFactura.RowCount != 0)
            {
                this.dgvFactura_CellClick(this.dgvFactura, null);
            }
            else
            {
                LimpiarGridProducto();
                LimpiarTotales();
            }
        }

        private void dgvFactura_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            dgvListaArticulos.AutoGenerateColumns = false;
            if (dgvFactura.RowCount != 0)
            {
                var tabla = miBussinesDevolucion.DetalleDevolucionCompra(
                            Convert.ToInt32(dgvFactura.CurrentRow.Cells["Id"].Value));
                dgvListaArticulos.DataSource = tabla;
                CalcularTotales(tabla);
            }
        }

        private void btnInicio_Click(object sender, EventArgs e)
        {
            if (CurrentPageFactura > 1)
            {
                var paginaActual = CurrentPageFactura;
                for (int i = paginaActual; i > 1; i--)
                {
                    RowFactura = RowFactura - RowMaxFactura;
                    CurrentPageFactura--;
                }
                try
                {
                    switch (Iteracion)
                    {
                        case 1:
                            {
                                dgvFactura.DataSource = miBussinesDevolucion.
                                    DevolucionesDeCompraProveedor(ProveedorActual, RowFactura, RowMaxFactura);
                                break;
                            }
                        case 2:
                            {
                                dgvFactura.DataSource =
                                    miBussinesDevolucion.DevolucionesDeCompra(Fecha1Actual, RowFactura, RowMaxFactura);
                                break;
                            }
                        case 3:
                            {
                                dgvFactura.DataSource = miBussinesDevolucion.
                                    DevolucionesDeCompra(Fecha1Actual, Fecha2Actual, RowFactura, RowMaxFactura);
                                break;
                            }
                    }
                    lblStatusFactura.Text = CurrentPageFactura + " / " + PaginasFactura;
                    dgvFactura_CellClick(this.dgvFactura, null);
                }
                catch (Exception ex)
                {
                    OptionPane.MessageError(ex.Message);
                }
            }
        }

        private void btnAnterior_Click(object sender, EventArgs e)
        {
            if (CurrentPageFactura > 1)
            {
                RowFactura = RowFactura - RowMaxFactura;
                if (RowFactura <= 0)
                    RowFactura = 0;
                try
                {
                    switch (Iteracion)
                    {
                        case 1:
                            {
                                dgvFactura.DataSource = miBussinesDevolucion.
                                    DevolucionesDeCompraProveedor(ProveedorActual, RowFactura, RowMaxFactura);
                                break;
                            }
                        case 2:
                            {
                                dgvFactura.DataSource =
                                    miBussinesDevolucion.DevolucionesDeCompra(Fecha1Actual, RowFactura, RowMaxFactura);
                                break;
                            }
                        case 3:
                            {
                                dgvFactura.DataSource = miBussinesDevolucion.
                                    DevolucionesDeCompra(Fecha1Actual, Fecha2Actual, RowFactura, RowMaxFactura);
                                break;
                            }
                    }
                    CurrentPageFactura--;
                    lblStatusFactura.Text = CurrentPageFactura + " / " + PaginasFactura;
                    dgvFactura_CellClick(this.dgvFactura, null);
                }
                catch (Exception ex)
                {
                    OptionPane.MessageError(ex.Message);
                }
            }
        }

        private void btnSiguiente_Click(object sender, EventArgs e)
        {
            if (CurrentPageFactura < PaginasFactura)
            {
                RowFactura = RowFactura + RowMaxFactura;
                try
                {
                    switch (Iteracion)
                    {
                        case 1:
                            {
                                dgvFactura.DataSource = miBussinesDevolucion.
                                    DevolucionesDeCompraProveedor(ProveedorActual, RowFactura, RowMaxFactura);
                                break;
                            }
                        case 2:
                            {
                                dgvFactura.DataSource =
                                    miBussinesDevolucion.DevolucionesDeCompra(Fecha1Actual, RowFactura, RowMaxFactura);
                                break;
                            }
                        case 3:
                            {
                                dgvFactura.DataSource = miBussinesDevolucion.
                                    DevolucionesDeCompra(Fecha1Actual, Fecha2Actual, RowFactura, RowMaxFactura);
                                break;
                            }
                    }
                    CurrentPageFactura++;
                    lblStatusFactura.Text = CurrentPageFactura + " / " + PaginasFactura;
                    dgvFactura_CellClick(this.dgvFactura, null);
                }
                catch (Exception ex)
                {
                    OptionPane.MessageError(ex.Message);
                }
            }
        }

        private void btnFin_Click(object sender, EventArgs e)
        {
            if (CurrentPageFactura < PaginasFactura)
            {
                var paginaActual = CurrentPageFactura;
                for (int i = paginaActual; i < PaginasFactura; i++)
                {
                    RowFactura = RowFactura + RowMaxFactura;
                    CurrentPageFactura++;
                }
                try
                {
                    switch (Iteracion)
                    {
                        case 1:
                            {
                                dgvFactura.DataSource = miBussinesDevolucion.
                                    DevolucionesDeCompraProveedor(ProveedorActual, RowFactura, RowMaxFactura);
                                break;
                            }
                        case 2:
                            {
                                dgvFactura.DataSource =
                                    miBussinesDevolucion.DevolucionesDeCompra(Fecha1Actual, RowFactura, RowMaxFactura);
                                break;
                            }
                        case 3:
                            {
                                dgvFactura.DataSource = miBussinesDevolucion.
                                    DevolucionesDeCompra(Fecha1Actual, Fecha2Actual, RowFactura, RowMaxFactura);
                                break;
                            }
                    }
                    lblStatusFactura.Text = CurrentPageFactura + " / " + PaginasFactura;
                    dgvFactura_CellClick(this.dgvFactura, null);
                }
                catch (Exception ex)
                {
                    OptionPane.MessageError(ex.Message);
                }
            }
        }


        // Otros metodos
        private void CargarUtilidades()
        {
            var lst = new List<Inventario.Producto.Criterio>();
            lst.Add(new Inventario.Producto.Criterio
            {
                Id = 1,
                Nombre = "Número"
            });
            lst.Add(new Inventario.Producto.Criterio
            {
                Id = 2,
                Nombre = "Proveedor"
            });
            lst.Add(new Inventario.Producto.Criterio
            {
                Id = 3,
                Nombre = "Fecha"
            });
            cbCriterio.DataSource = lst;


            lst = new List<Inventario.Producto.Criterio>();
            lst.Add(new Inventario.Producto.Criterio
            {
                Id = 1,
                Nombre = ""
            });
            lst.Add(new Inventario.Producto.Criterio
            {
                Id = 2,
                Nombre = "Fecha simple"
            });
            lst.Add(new Inventario.Producto.Criterio
            {
                Id = 3,
                Nombre = "Periodo de fechas"
            });
            cbCriterio3.DataSource = lst;
        }

        private void ConsultaPorFecha()
        {
            if (Convert.ToInt32(cbCriterio3.SelectedValue).Equals(2))
            {
                ConsultaDevolucion(dtpFecha1.Value);
            }
            else
            {
                if (Convert.ToInt32(cbCriterio3.SelectedValue).Equals(3))
                {
                    InvertirFechas();
                    ConsultaDevolucion(dtpFecha1.Value, dtpFecha2.Value);
                }
            }
        }

        private void ConsultaDevolucion(string numero)
        {
            try
            {
                dgvFactura.DataSource = miBussinesDevolucion.DevolucionesDeCompra(numero);
                if (dgvFactura.RowCount == 0)
                {
                    lblStatusFactura.Text = "0 / 0";
                    OptionPane.MessageInformation("No se encontrarón registros con ese número.");
                }
                else
                {
                    lblStatusFactura.Text = "1 / 1";
                }
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
        }

        private void ConsultaDevolucionProveedor(string proveedor)
        {
            try
            {
                Iteracion = 1;
                ProveedorActual = proveedor;
                CurrentPageFactura = 1;
                dgvFactura.DataSource = miBussinesDevolucion.DevolucionesDeCompraProveedor(proveedor, RowFactura, RowMaxFactura);
                TotalRowFactura = miBussinesDevolucion.GetRowsDevolucionesDeCompraProveedor(proveedor);
                if (dgvFactura.RowCount == 0)
                {
                    OptionPane.MessageInformation("No se encontrarón registros con ese Proveedor.");
                }
                CalcularPaginas();
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
        }

        private void ConsultaDevolucion(DateTime fecha)
        {
            try
            {
                Iteracion = 2;
                Fecha1Actual = fecha;
                CurrentPageFactura = 1;
                dgvFactura.DataSource = miBussinesDevolucion.DevolucionesDeCompra(fecha, RowFactura, RowMaxFactura);
                TotalRowFactura = miBussinesDevolucion.GetRowsDevolucionesDeCompra(fecha);
                if (dgvFactura.RowCount == 0)
                {
                    OptionPane.MessageInformation("No se encontrarón registros en esa fecha.");
                }
                CalcularPaginas();
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
        }

        private void ConsultaDevolucion(DateTime fecha, DateTime fecha2)
        {
            try
            {
                Iteracion = 3;
                Fecha1Actual = fecha;
                Fecha2Actual = fecha2;
                CurrentPageFactura = 1;
                dgvFactura.DataSource = miBussinesDevolucion.DevolucionesDeCompra(fecha, fecha2, RowFactura, RowMaxFactura);
                TotalRowFactura = miBussinesDevolucion.GetRowsDevolucionesDeCompra(fecha, fecha2);
                if (dgvFactura.RowCount == 0)
                {
                    OptionPane.MessageInformation("No se encontrarón registros entre esas fechas.");
                }
                CalcularPaginas();
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
        }



        private void InvertirFechas()
        {
            if (dtpFecha1.Value > dtpFecha2.Value)
            {
                var temp = dtpFecha1.Value;
                dtpFecha1.Value = dtpFecha2.Value;
                dtpFecha2.Value = temp;
            }
        }

        /// <summary>
        /// Consulta y calcula los totales correspondientes a la factura.
        /// </summary>
        /// <param name="tabla">Tabla que almacena los registros de articulos de la factura.</param>
        private void CalcularTotales(DataTable tabla)
        {
            txtSubTotal.Text = UseObject.InsertSeparatorMil
                (Convert.ToInt32
                  (tabla.AsEnumerable().Sum(s => (s.Field<double>("ValorUnit") *
                                            s.Field<double>("Cantidad")))).ToString()
                );

            txtDescuento.Text = UseObject.InsertSeparatorMil
                (Convert.ToInt32(tabla.AsEnumerable().Sum(d => d.Field<double>("ValorDesto"))).ToString());

            txtIva.Text = UseObject.InsertSeparatorMil
                (Convert.ToInt32
                  (tabla.AsEnumerable().Sum(i => (i.Field<double>("ValorIva")))).ToString()
                );

            txtTotal.Text = UseObject.InsertSeparatorMil
                (
                  (Convert.ToInt32(tabla.AsEnumerable().Sum(t => t.Field<double>("Total_")))).ToString()
                );
        }

        // metodos print
        private void PrintCopia(FacturaProveedor devolucion)
        {
            try
            {
                /**DialogResult rta = MessageBox.Show("¿Desea visualizar la impresión de la Nota Crédito?", "Devolución Proveedor",
                                        MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);*/
                FrmPrint frmPrint_ = new FrmPrint();
                frmPrint_.StringCaption = "Consulta Devolución Proveedor";
                frmPrint_.StringMessage = "Impresión de la Nota Crédito a Proveedor";
                DialogResult rta = frmPrint_.ShowDialog();

                if (!rta.Equals(DialogResult.Cancel))
                {
                    var dsEmpresa = miBussinesEmpresa.PrintEmpresa();
                    var dsDetalle = miBussinesDevolucion.DetalleDevolucionCompra(devolucion.Id);

                    var frmPrint = new FrmPrintDevolucion();

                    frmPrint.RptvFactura.LocalReport.DataSources.Clear();
                    frmPrint.RptvFactura.LocalReport.Dispose();
                    frmPrint.RptvFactura.Reset();

                    frmPrint.RptvFactura.LocalReport.DataSources.Add(
                       new ReportDataSource("DsDetalle", dsDetalle));
                    frmPrint.RptvFactura.LocalReport.DataSources.Add(
                        new ReportDataSource("DsEmpresa", dsEmpresa.Tables["Empresa"]));

                    frmPrint.RptvFactura.LocalReport.ReportPath =
                        AppConfiguracion.ValorSeccion("report") + @"\reports\ComprobanteDevolucionCompra.rdlc";

                    Label NoFactura = new Label();
                    NoFactura.AutoSize = true;
                    NoFactura.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                    NoFactura.Text = devolucion.Numero;

                    var pNoFact = new ReportParameter();
                    pNoFact.Name = "No";
                    pNoFact.Values.Add(NoFactura.Text);
                    frmPrint.RptvFactura.LocalReport.SetParameters(pNoFact);

                    var pFecha = new ReportParameter();
                    pFecha.Name = "Fecha";
                    pFecha.Values.Add(devolucion.FechaIngreso.ToShortDateString());
                    frmPrint.RptvFactura.LocalReport.SetParameters(pFecha);

                    var pConcepto = new ReportParameter();
                    pConcepto.Name = "Concepto";
                    pConcepto.Values.Add(devolucion.Proveedor.DescripcionProveedor);
                    frmPrint.RptvFactura.LocalReport.SetParameters(pConcepto);

                    var pNit = new ReportParameter();
                    pNit.Name = "Nit";
                    pNit.Values.Add(devolucion.Proveedor.NitProveedor);
                    frmPrint.RptvFactura.LocalReport.SetParameters(pNit);

                    var pProveedor = new ReportParameter();
                    pProveedor.Name = "Proveedor";
                    pProveedor.Values.Add(devolucion.Proveedor.RazonSocialProveedor);
                    frmPrint.RptvFactura.LocalReport.SetParameters(pProveedor);

                    var pSubTotal = new ReportParameter();
                    pSubTotal.Name = "SubTotal";
                    pSubTotal.Values.Add(SubTotal(dsDetalle).ToString());
                    frmPrint.RptvFactura.LocalReport.SetParameters(pSubTotal);

                    var pDescuento = new ReportParameter();
                    pDescuento.Name = "Descuento";
                    pDescuento.Values.Add(ValorDescuento(dsDetalle).ToString());
                    frmPrint.RptvFactura.LocalReport.SetParameters(pDescuento);

                    var pIva = new ReportParameter();
                    pIva.Name = "Iva";
                    pIva.Values.Add(ValorIva(dsDetalle).ToString());
                    frmPrint.RptvFactura.LocalReport.SetParameters(pIva);

                    var pTotal = new ReportParameter();
                    pTotal.Name = "Total";
                    pTotal.Values.Add(((SubTotal(dsDetalle) - ValorDescuento(dsDetalle)) + ValorIva(dsDetalle)).ToString());
                    frmPrint.RptvFactura.LocalReport.SetParameters(pTotal);

                    frmPrint.RptvFactura.RefreshReport();

                    if (rta.Equals(DialogResult.No))
                    {
                        frmPrint.ShowDialog();
                    }
                    else
                    {
                        Imprimir print = new Imprimir();
                        print.Report = frmPrint.RptvFactura.LocalReport;
                        print.Print(Imprimir.TamanioPapel.MediaCarta);
                        frmPrint.RptvFactura.Reset();
                    }
                }
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
        }

        private void PrintCopiaPos(FacturaProveedor devolucion)
        {
            try
            {

                var empresaRow = miBussinesEmpresa.PrintEmpresa().
                                 Tables[0].AsEnumerable().First();
                var Detalle = miBussinesDevolucion.DetalleDevolucionCompra(devolucion.Id);

                Ticket ticket = new Ticket();

                ticket.AddHeaderLine(empresaRow["Nombre"].ToString().ToUpper());
                ticket.AddHeaderLine(empresaRow["Juridico"].ToString());
                ticket.AddHeaderLine("NIT " + UseObject.InsertSeparatorMilMasDigito(empresaRow["Nit"].ToString()));
                ticket.AddHeaderLine(empresaRow["Direccion"].ToString());
                ticket.AddHeaderLine("Tels. " + empresaRow["Telefono"].ToString());
                ticket.AddHeaderLine("===================================");
                ticket.AddHeaderLine("NOTA CRÉDITO PROVEEDOR No " + devolucion.Numero);
                ticket.AddHeaderLine("Fecha : " + devolucion.FechaIngreso.ToShortDateString());
                ticket.AddHeaderLine("===================================");
                ticket.AddHeaderLine("Proveedor :" + devolucion.Proveedor.RazonSocialProveedor);
                ticket.AddHeaderLine("Nit       :" + devolucion.Proveedor.NitProveedor);
                ticket.AddHeaderLine("===================================");
                ticket.AddHeaderLine("");
                ticket.AddHeaderLine(devolucion.Proveedor.DescripcionProveedor);
                ticket.AddHeaderLine("===================================");

                ticket.AddHeaderLine("");
                foreach (DataRow row in Detalle.Rows)
                {
                    ticket.AddItem(row["Cantidad"].ToString(),
                                   row["Producto"].ToString(),
                                   UseObject.InsertSeparatorMil(Convert.ToInt32(row["Total_"]).ToString()));
                }
               // var s_ = Detalle.AsEnumerable().Sum(s => s.Field<int>("Total_")).ToString();
                ticket.AddTotal("TOTAL : ", UseObject.InsertSeparatorMil(
                    Convert.ToInt32(Detalle.AsEnumerable().Sum(s => s.Field<double>("Total_"))).ToString()));

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

        private int SubTotal(DataTable table)
        {
            int sTotal = 0;
            foreach (DataRow tRow in table.Rows)
            {
                sTotal += Convert.ToInt32(Convert.ToInt32(tRow["ValorUnit"]) * Convert.ToDouble(tRow["Cantidad"]));
            }
            return sTotal;
        }

        private int ValorDescuento(DataTable table)
        {
            int descto = 0;
            foreach (DataRow tRow in table.Rows)
            {
                descto += Convert.ToInt32((Convert.ToInt32(tRow["ValorUnit"]) - Convert.ToDouble(tRow["ValorMenosDesto"]))
                          * Convert.ToDouble(tRow["Cantidad"]));
            }
            return descto;
        }

        private int ValorIva(DataTable table)
        {
            int vIva = 0;
            foreach (DataRow tRow in table.Rows)
            {
                vIva += Convert.ToInt32(Convert.ToDouble(tRow["ValorIva"]) * Convert.ToDouble(tRow["Cantidad"]));
                //TotalMasIva
            }
            return vIva;
        }

        /// <summary>
        /// Calcula y muestra el número de paginas devueltas en la consulta.
        /// </summary>
        private void CalcularPaginas()
        {
            PaginasFactura = TotalRowFactura / RowMaxFactura;
            if (TotalRowFactura % RowMaxFactura != 0)
                PaginasFactura++;
            if (CurrentPageFactura > PaginasFactura)
                CurrentPageFactura = 0;
            lblStatusFactura.Text = CurrentPageFactura + " / " + PaginasFactura;
        }

        /// <summary>
        /// Limpia los registro del DataGrid de Producto.
        /// </summary>
        private void LimpiarGridProducto()
        {
            while (dgvListaArticulos.RowCount != 0)
            {
                dgvListaArticulos.Rows.RemoveAt(0);
            }
        }

        private void LimpiarTotales()
        {
            txtSubTotal.Text = "0";
            txtDescuento.Text = "0";
            txtIva.Text = "0";
            txtTotal.Text = "0";
        }

        
    }
}