using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using BussinesLayer.Clases;
using CustomControl;
using DTO.Clases;
using Utilities;

namespace Aplicacion.Compras.IngresarCompra
{
    public partial class FrmConsultaDeCompras : Form
    {
        private DataTable Tabla { set; get; }

        private DataTable TablaIva { set; get; }

        private List<Iva> LstIva;

        private int NombreWith { set; get; }

        private int CriterioPrint { set; get; }

        private DateTime FechaActual { set; get; }

        private DateTime FechaActual2 { set; get; }

        private int cProveedor, cCodigo, cFecha;

        private string Consulta;

        private int ProveedorPrint { set; get; }

        private BussinesProveedor miBussinesProveedor;

        private BussinesFacturaProveedor miBussinesFactura;

        private ErrorProvider miError;

        private Thread miThread;

        private OptionPane miOption;

        public FrmConsultaDeCompras()
        {
            InitializeComponent();
            this.Tabla = new DataTable();
            TablaIva = new DataTable();
            this.LstIva = new List<Iva>();
            NombreWith = Nombre.Width;
            this.CriterioPrint = 2;
            this.ProveedorPrint = 0;
            miBussinesProveedor = new BussinesProveedor();
            miBussinesFactura = new BussinesFacturaProveedor();
            miError = new ErrorProvider();
        }

        private void FrmCartera_Load(object sender, EventArgs e)
        {
            CargarComponentes();
            this.dgvIva.AutoGenerateColumns = false;
            CompletaEventos.Completa += new CompletaEventos.CompletaAccion(CompletaEventos_Completo);
        }

        private void tsBtnImprimir_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvCartera.RowCount != 0)
                {
                    FrmPrint frmPrint_ = new FrmPrint();
                    frmPrint_.StringCaption = "Consulta de Compras";
                    frmPrint_.StringMessage = "Impresión de Consulta de Compras";
                    DialogResult rta = frmPrint_.ShowDialog();

                    if (!rta.Equals(DialogResult.Cancel))
                    {
                        var frmPrint = new Ventas.Cartera.FrmPrintCartera();
                        frmPrint.Reporte = "INFORME DE COMPRAS";
                        frmPrint.Compra = true;
                        frmPrint.ConsultaCompra = true;
                        frmPrint.Fecha = FechaActual;
                        frmPrint.Fecha2 = FechaActual2;
                        frmPrint.Tamanio = Imprimir.TamanioPapel.CartaHorizontal;
                        frmPrint.Tabla = Tabla;
                        frmPrint.TIva = this.ListToDataTable();

                        frmPrint.SubTotal = Convert.ToInt32(this.LstIva.Sum(s => s.BaseI));
                        frmPrint.Iva = Convert.ToInt32(this.LstIva.Sum(s => s.ValorIva));
                        frmPrint.Total = Convert.ToInt32(this.LstIva.Sum(s => s.Total));

                        /*frmPrint.SubTotal = Convert.ToInt32(
                            TablaIva.AsEnumerable().Sum(s => s.Field<double>("Base")));
                        frmPrint.Iva = Convert.ToInt32(
                            TablaIva.AsEnumerable().Sum(s => s.Field<double>("VIva")));
                        frmPrint.Total = Convert.ToInt32(
                            TablaIva.AsEnumerable().Sum(s => s.Field<double>("Total")));*/

                        frmPrint.ReportPath = AppConfiguracion.ValorSeccion("report") + @"\reports\ConsultaDeCompras.rdlc";
                        //frmPrint.ReportPath = @"C:\reports\ConsultaDeCompras.rdlc";

                        if (rta.Equals(DialogResult.No))
                        {
                            frmPrint.ShowDialog();
                        }
                        else
                        {
                            Imprimir print = new Imprimir();
                            print.Report = frmPrint.Load_();
                            print.Print(Imprimir.TamanioPapel.CartaHorizontal);
                            frmPrint.ResetReport();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
        }

        private DataTable ListToDataTable()
        {
            var tabla = new DataTable();
            tabla.Columns.Add(new DataColumn("Iva", typeof(string)));
            tabla.Columns.Add(new DataColumn("Base", typeof(double)));
            tabla.Columns.Add(new DataColumn("VIva", typeof(double)));
            tabla.Columns.Add(new DataColumn("SubTotal", typeof(double)));

            foreach (var iva in this.LstIva)
            {
                tabla.Rows.Add(iva.ConceptoIva, iva.BaseI, iva.ValorIva, iva.Total);
            }

            return tabla;
        }

        private void tsBtnImprimirResumen_Click(object sender, EventArgs e)
        {
            try
            {
                /*var frmPrint = new FrmPrintCartera();
                frmPrint.Tabla = miBussinesFactura.ResumenCarteraClientes(false);
                frmPrint.ReportPath = AppConfiguracion.ValorSeccion("report") + @"\reports\ResumenCarteraDeClientes.rdlc";
                frmPrint.ShowDialog();*/
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

        private void cbContado_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Convert.ToInt32(cbProveedor.SelectedValue).Equals(2))
            {
                cbCodigo.Enabled = true;
            }
            else
            {
                cbCodigo.Enabled = false;
            }
            txtConsulta.Text = "";
            txtConsulta.Focus();
        }

        private void txtConsulta_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar.Equals((char)Keys.Enter))
            {
                this.btnBuscar_Click(this.btnBuscar, new EventArgs());
            }
        }

        private void btnBuscarProveedor_Click(object sender, EventArgs e)
        {
            if (cbProveedor.SelectedValue.Equals(2))
            {
                var formProveedor = new Proveedor.frmProveedor();
                formProveedor.Extension = true;
                formProveedor.tcProveedor.SelectTab(1);
                formProveedor.ShowDialog();
            }
        }

        private void cbFecha_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (Convert.ToInt32(cbFecha.SelectedValue).Equals(1))
            {
                dtpFecha2.Enabled = false;
            }
            else
            {
                dtpFecha2.Enabled = true;
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            dgvCartera.AutoGenerateColumns = false;
            cProveedor = Convert.ToInt32(cbProveedor.SelectedValue);
            cCodigo = Convert.ToInt32(cbCodigo.SelectedValue);
            cFecha = Convert.ToInt32(cbFecha.SelectedValue);
            Consulta = txtConsulta.Text;
            FechaActual = dtpFecha1.Value;
            FechaActual2 = dtpFecha2.Value;
            bool consulta = true;
            if (cProveedor.Equals(2)) // Proveedor.
            {
                if (cCodigo.Equals(1))
                {
                    try
                    {
                        Convert.ToInt32(txtConsulta.Text);
                        consulta = true;
                        miError.SetError(txtConsulta, null);
                    }
                    catch (FormatException)
                    {
                        consulta = false;
                        miError.SetError(txtConsulta, "El Código no tiene formato correcto.");
                    }
                }
            }
            if (consulta)
            {
                miOption = new OptionPane();
                miOption.FrmProgressBar.barraProgreso.Style = ProgressBarStyle.Marquee;
                miOption.FrmProgressBar.Closed_ = true;
                miOption.ProgressShow("Espere mientras se realizan las operaciones necesarias...",
                    "Operacion en progreso");
                miThread = new Thread(Consultar);
                miThread.Start();
            }
        }

        private void Consultar()
        {
            try
            {
                if (cProveedor.Equals(1)) // Todos los proveedores.
                {
                    if (cFecha.Equals(1)) // Fecha
                    {
                        Tabla = miBussinesFactura.ConsultaCompras(0, FechaActual, FechaActual);
                        this.LstIva = miBussinesFactura.ConsultaIvaCompras(0, FechaActual, FechaActual);
                    }
                    else  // Periodo
                    {
                        Tabla = miBussinesFactura.ConsultaCompras(0, FechaActual, FechaActual2);
                        this.LstIva = miBussinesFactura.ConsultaIvaCompras(0, FechaActual, FechaActual2);
                        //this.TablaIva = this.miBussinesFactura.ConsultaIvaCompras_(0, FechaActual, FechaActual2);
                    }
                }
                else // Proveedor
                {
                    var proveedor = new DTO.Clases.Proveedor();
                    if (cCodigo.Equals(1))
                    {
                        proveedor = miBussinesProveedor.ConsultarPrveedorBasico(Convert.ToInt32(Consulta));
                    }
                    else
                    {
                        proveedor = miBussinesProveedor.ConsultarPrveedorBasico(Consulta);
                    }
                    if (cFecha.Equals(1)) // Fecha
                    {
                        Tabla = miBussinesFactura.
                            ConsultaCompras(proveedor.CodigoInternoProveedor, FechaActual, FechaActual);
                        this.LstIva = miBussinesFactura.
                            ConsultaIvaCompras(proveedor.CodigoInternoProveedor, FechaActual, FechaActual);
                    }
                    else   // Periodo
                    {
                        Tabla = miBussinesFactura.
                            ConsultaCompras(proveedor.CodigoInternoProveedor, FechaActual, FechaActual2);
                        this.LstIva = miBussinesFactura.
                            ConsultaIvaCompras(proveedor.CodigoInternoProveedor, FechaActual, FechaActual2);
                    }
                }
                if (this.InvokeRequired)
                    this.Invoke(new Action(FinishProcess));
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
                if (this.InvokeRequired)
                    this.Invoke(new Action(FinishProcess));
            }
            /*try
            {
                dgvCartera.AutoGenerateColumns = false;
                if (Convert.ToInt32(cbProveedor.SelectedValue).Equals(1)) // Todos los proveedores.*
                {
                    if (Convert.ToInt32(cbFecha.SelectedValue).Equals(1)) // Fecha
                    {
                        Tabla = miBussinesFactura.ConsultaCompras(0, dtpFecha1.Value, dtpFecha1.Value);
                        TablaIva = miBussinesFactura.ConsultaIvaCompras(0, dtpFecha1.Value, dtpFecha1.Value);
                    }
                    else  // Periodo
                    {
                        Tabla = miBussinesFactura.ConsultaCompras(0, dtpFecha1.Value, dtpFecha2.Value);
                        TablaIva = miBussinesFactura.ConsultaIvaCompras(0, dtpFecha1.Value, dtpFecha2.Value);
                    }
                }
                else // Proveedor
                {
                    var proveedor = new DTO.Clases.Proveedor();
                    if (Convert.ToInt32(cbCodigo.SelectedValue).Equals(1))
                    {
                        try
                        {
                            proveedor = miBussinesProveedor.ConsultarPrveedorBasico(Convert.ToInt32(txtConsulta.Text));
                            miError.SetError(txtConsulta, null);
                        }
                        catch (FormatException)
                        {
                            miError.SetError(txtConsulta, "El Código no tiene formato correcto.");
                        }
                    }
                    else
                    {
                        proveedor = miBussinesProveedor.ConsultarPrveedorBasico(txtConsulta.Text);
                    }
                    if (Convert.ToInt32(cbFecha.SelectedValue).Equals(1)) // Fecha
                    {
                        Tabla = miBussinesFactura.
                            ConsultaCompras(proveedor.CodigoInternoProveedor, dtpFecha1.Value, dtpFecha1.Value);
                        TablaIva = miBussinesFactura.
                            ConsultaCompras(proveedor.CodigoInternoProveedor, dtpFecha1.Value, dtpFecha1.Value);
                    }
                    else  // Periodo
                    {
                        Tabla = miBussinesFactura.
                            ConsultaCompras(proveedor.CodigoInternoProveedor, dtpFecha1.Value, dtpFecha2.Value);
                        TablaIva = miBussinesFactura.
                            ConsultaCompras(proveedor.CodigoInternoProveedor, dtpFecha1.Value, dtpFecha2.Value);
                    }
                }
                FechaActual = dtpFecha1.Value;
                FechaActual2 = dtpFecha2.Value;
                dgvCartera.DataSource = Tabla;
                if (TablaIva.Rows.Count != 0)
                {
                    txtSubTotal.Text = UseObject.InsertSeparatorMil(Convert.ToInt32(
                        TablaIva.AsEnumerable().Sum(s => s.Field<double>("Base"))).ToString());
                    txtIva.Text = UseObject.InsertSeparatorMil(Convert.ToInt32(
                        TablaIva.AsEnumerable().Sum(s => s.Field<double>("VIva"))).ToString());
                    txtTotal.Text = UseObject.InsertSeparatorMil(Convert.ToInt32(
                        TablaIva.AsEnumerable().Sum(s => s.Field<double>("Total"))).ToString());
                }
                else
                {
                    txtSubTotal.Text = "0";
                    txtIva.Text = "0";
                    txtTotal.Text = "0";
                }
                ColorGrid();
                /*if(this.InvokeRequired)
                    this.Invoke(new Action(FinishProcess));
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
                /*if (this.InvokeRequired)
                    this.Invoke(new Action(FinishProcess));
            }*/
        }

        private void FinishProcess()
        {
            this.dgvCartera.DataSource = Tabla;
            this.dgvIva.DataSource = this.LstIva;
            if(this.LstIva.Count > 0) //if (TablaIva.Rows.Count != 0)
            {
                this.txtSubTotal.Text = UseObject.InsertSeparatorMil(Convert.ToInt32(
                    this.LstIva.Sum(s => s.BaseI)).ToString());
                this.txtIva.Text = UseObject.InsertSeparatorMil(Convert.ToInt32(
                    this.LstIva.Sum(s => s.ValorIva)).ToString());
               /* this.txtTotal.Text = UseObject.InsertSeparatorMil(Convert.ToInt32(
                    this.LstIva.Sum(s => s.Total)).ToString());*/

                this.txtTotal.Text = UseObject.InsertSeparatorMil(Convert.ToInt32(
                    this.Tabla.AsEnumerable().Sum(s => s.Field<int>("Valor"))).ToString());
                /*txtSubTotal.Text = UseObject.InsertSeparatorMil(Convert.ToInt32(
                    TablaIva.AsEnumerable().Sum(s => s.Field<double>("Base"))).ToString());
                txtIva.Text = UseObject.InsertSeparatorMil(Convert.ToInt32(
                    TablaIva.AsEnumerable().Sum(s => s.Field<double>("VIva"))).ToString());
                txtTotal.Text = UseObject.InsertSeparatorMil(Convert.ToInt32(
                    TablaIva.AsEnumerable().Sum(s => s.Field<double>("Total"))).ToString());*/
            }
            else
            {
                txtSubTotal.Text = "0";
                txtIva.Text = "0";
                txtTotal.Text = "0";
            }
            ColorGrid();
            miOption.FrmProgressBar.barraProgreso.Style = ProgressBarStyle.Blocks;
            miOption.FrmProgressBar.Closed_ = false;
            miOption.FrmProgressBar.Close();
        }

        private void dgvCartera_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //SaldoDeCliente();
        }

        private void dgvCartera_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            ColorGrid();
           // ColorSaldoLimite();
        }

        private void dgvCartera_KeyUp(object sender, KeyEventArgs e)
        {
            //SaldoDeCliente();
        }

        private void CargarComponentes()
        {
            var lst = new List<Inventario.Producto.Criterio>();
            lst.Add(new Inventario.Producto.Criterio
            {
                Id = 1,
                Nombre = "Todos los Proveedores"
            });
            lst.Add(new Inventario.Producto.Criterio
            {
                Id = 2,
                Nombre = "Proveedor"
            });
            cbProveedor.DataSource = lst;

            lst = new List<Inventario.Producto.Criterio>();
            lst.Add(new Inventario.Producto.Criterio
            {
                Id = 1,
                Nombre = "Código"
            });
            lst.Add(new Inventario.Producto.Criterio
            {
                Id = 2,
                Nombre = "Nit"
            });
            cbCodigo.DataSource = lst;

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

        private void ColorGrid()
        {
            var cont = 0;
            foreach (DataGridViewRow gRow in dgvCartera.Rows)
            {
                if (cont % 2 == 0)
                {
                    gRow.DefaultCellStyle.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
                }
                cont++;
            }
        }

        private void ColorSaldoLimite()
        {
            foreach (DataGridViewRow gRow in dgvCartera.Rows)
            {
                if (Convert.ToDateTime(gRow.Cells["Limite"].Value) < DateTime.Now &&
                    Convert.ToInt32(gRow.Cells["Saldo"].Value) != 0)
                {
                    gRow.Cells["Saldo"].Style.ForeColor = Color.Red;
                }
            }
        }

        private void SaldoDeCliente()
        {
            var cedula = dgvCartera.CurrentRow.Cells["Nit"].Value.ToString();
            txtSubTotal.Text = dgvCartera.CurrentRow.Cells["Nombre"].Value.ToString();
            txtIva.Text = UseObject.InsertSeparatorMil(
                Tabla.AsEnumerable().Where(d => d.Field<string>("Cedula").Equals(cedula)).Sum(s => s.Field<int>("Saldo")).ToString());
        }

        void CompletaEventos_Completo(CompletaArgumentosDeEvento args)
        {
            try
            {
                var proveedor = (DTO.Clases.Proveedor)args.MiObjeto;
                cbCodigo.SelectedIndex = 0;
                txtConsulta.Text = proveedor.CodigoInternoProveedor.ToString();
                cbFecha.Focus();
                //this.btnBuscar_Click(this.btnBuscar, new EventArgs());
            }
            catch { }
        }
    }
}