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
using System.Threading;

namespace Aplicacion.Ventas.CarteraRemision
{
    public partial class FrmCartera : Form
    {
        private DataTable Tabla { set; get; }

        private int NombreWith { set; get; }

        private int CriterioPrint { set; get; }

        private string ClientePrint { set; get; }

        private BussinesCliente miBussinesCliente;

        private BussinesFacturaVenta miBussinesFactura;

        private BussinesRemision miBussinesRemision;

        private Thread miThread;

        private OptionPane miOption;

        public FrmCartera()
        {
            InitializeComponent();
            this.Tabla = new DataTable();
            NombreWith = Nombre.Width;
            this.CriterioPrint = 2;
            this.ClientePrint = "";
            miBussinesCliente = new BussinesCliente();
            miBussinesFactura = new BussinesFacturaVenta();
            miBussinesRemision = new BussinesRemision();
        }

        private void FrmCartera_Load(object sender, EventArgs e)
        {
            CargarComponentes();
            CompletaEventos.Completabo += new CompletaEventos.CompletaAccionbo(CompletaEventos_Completabo);
        }

        private void tsBtnImprimir_Click(object sender, EventArgs e)
        {
            try
            {
                //var id = Convert.ToInt32(cbContado.SelectedValue);
                var tabla = new DataTable();
                switch (CriterioPrint)
                {
                    case 1:
                        {
                            tabla = miBussinesRemision.CarteraClientes(false, false, null);
                            break;
                        }
                    case 2:
                        {
                            tabla = miBussinesRemision.CarteraClientes(true, false, null);
                            break;
                        }
                    case 3:
                        {
                            tabla = miBussinesRemision.CarteraClientes(false, true, this.ClientePrint);
                            break;
                        }
                }
                if (dgvCartera.RowCount != 0)
                {
                    var frmPrint = new Cartera.FrmPrintCartera();
                    frmPrint.Reporte = "CARTERA REMISIONES A CLIENTE.";
                    frmPrint.Tabla = tabla;
                    if (Convert.ToBoolean(AppConfiguracion.ValorSeccion("printCarteraCliente")))
                    {
                        frmPrint.PrintPos(false);
                    }
                    else
                    {
                        frmPrint.ReportPath = AppConfiguracion.ValorSeccion("report") + @"\reports\CarteraDeClientes.rdlc";
                        frmPrint.ShowDialog();
                    }
                }
                else
                {
                    OptionPane.MessageInformation("No se ha cargado ninguna consulta para el informe.");
                }
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
        }

        private void tsBtnImprimirResumen_Click(object sender, EventArgs e)
        {
            try
            {
                var frmPrint = new Cartera.FrmPrintCartera();
                frmPrint.Reporte = "RESUMEN CARTERA DE REMISIONES.";
                frmPrint.Tabla = miBussinesRemision.ResumenCarteraClientes();
                if (Convert.ToBoolean(AppConfiguracion.ValorSeccion("printCarteraCliente")))
                {
                    frmPrint.PrintPos(true);
                }
                else
                {
                    frmPrint.ReportPath = AppConfiguracion.ValorSeccion("report") + @"\reports\ResumenCarteraDeClientes.rdlc";
                    frmPrint.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
        }

        private void btnPrintPos_Click(object sender, EventArgs e)
        {
            /*try
            {
                var frmPrint = new Cartera.FrmPrintCartera();
                frmPrint.Reporte = "RESUMEN CARTERA DE REMISIONES.";
                frmPrint.Tabla = miBussinesFactura.ResumenCarteraClientes(false);
                frmPrint.PrintPos();
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }*/
        }

        private void tsBtnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cbContado_SelectedIndexChanged(object sender, EventArgs e)
        {
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

        private void btnBuscarCliente_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(cbContado.SelectedValue).Equals(3))
            {
                var frmCliente = new Cliente.frmCliente();
                frmCliente.tcClientes.SelectTab(1);
                frmCliente.ConsultaVenta = true;
                frmCliente.ShowDialog();
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            this.CriterioPrint = Convert.ToInt32(cbContado.SelectedValue);
            this.ClientePrint = txtConsulta.Text;
            dgvCartera.AutoGenerateColumns = false;
            miOption = new OptionPane();
            miOption.FrmProgressBar.barraProgreso.Style = ProgressBarStyle.Marquee;
            miOption.FrmProgressBar.Closed_ = true;
            miOption.ProgressShow("Espere mientras se realizan las operaciones necesarias...",
                "Operacion en progreso");
            miThread = new Thread(Consultar);
            miThread.Start();

            /*try
            {
                //var tabla = new DataTable();
                var id = Convert.ToInt32(cbContado.SelectedValue);
                CriterioPrint = id;
                dgvCartera.AutoGenerateColumns = false;
                switch (id)
                {
                    case 1:
                        {
                            this.ClientePrint = "";
                            Tabla = miBussinesRemision.CarteraClientes(false, false, null);
                            //Tabla = miBussinesFactura.CarteraClientes(false, false, null);
                            break;
                        }
                    case 2:
                        {
                            this.ClientePrint = "";
                            Tabla = miBussinesRemision.CarteraClientes(true, false, null);
                           // Tabla = miBussinesFactura.CarteraClientes(true, false, null);
                            break;
                        }
                    case 3:
                        {
                            var tCliente = miBussinesCliente.ConsultaClienteNit(this.txtConsulta.Text);
                            if (tCliente.Rows.Count != 0)
                            {
                                this.ClientePrint = txtConsulta.Text;
                                Tabla = miBussinesRemision.CarteraClientes(false, true, this.txtConsulta.Text);
                                //Tabla = miBussinesFactura.CarteraClientes(false, true, this.txtConsulta.Text);
                            }
                            else
                            {
                                var frmCliente = new Cliente.frmCliente();
                                frmCliente.ConsultaVenta = true;
                                frmCliente.SubConsulta = true;
                                frmCliente.txtParametro.Text = this.txtConsulta.Text;
                                frmCliente.ShowDialog();
                            }
                            break;
                        }
                }
                dgvCartera.DataSource = Tabla;
                txtTotal.Text = UseObject.InsertSeparatorMil(Tabla.AsEnumerable().Sum(s => s.Field<int>("Saldo")).ToString());
                if (dgvCartera.Rows.Count > 15 && NombreWith.Equals(Nombre.Width))
                {
                    dgvCartera.Columns["Nombre"].Width = Nombre.Width - 5;
                }
                if (dgvCartera.RowCount != 0)
                {
                    SaldoDeCliente();
                }
                ColorGrid();
                ColorSaldoLimite();
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }*/
        }

        private void dgvCartera_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            SaldoDeCliente();
        }

        private void dgvCartera_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            ColorGrid();
            ColorSaldoLimite();
        }

        private void dgvCartera_KeyUp(object sender, KeyEventArgs e)
        {
            SaldoDeCliente();
        }

        /*private DataTable CarteraPorCliente(string cliente)
        {
           // var tabla = new DataTable();
            try
            {
                var tCliente = miBussinesCliente.ConsultaClienteNit(cliente);
                if (tCliente.Rows.Count != 0)
                {
                    txtConsulta.Text = "";
                    return miBussinesFactura.CarteraClientes(false, true, cliente);
                }
                else
                {
                    var frmCliente = new Cliente.frmCliente();
                    frmCliente.ConsultaVenta = true;
                    frmCliente.SubConsulta = true;
                    frmCliente.txtParametro.Text = cliente;
                    frmCliente.ShowDialog();
                    //return new DataTable();
                }
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
                return new DataTable();
            }
        }*/

        private void CargarComponentes()
        {
            var lst = new List<Inventario.Producto.Criterio>();
            lst.Add(new Inventario.Producto.Criterio
            {
                Id = 1,
                Nombre = "Todos los Clientes"
            });
            lst.Add(new Inventario.Producto.Criterio
            {
                Id = 2,
                Nombre = "Clientes con saldo"
            });
            lst.Add(new Inventario.Producto.Criterio
            {
                Id = 3,
                Nombre = "Cliente"
            });
            cbContado.DataSource = lst;
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
            if (dgvCartera.RowCount != 0)
            {
                var cedula = dgvCartera.CurrentRow.Cells["Cedula"].Value.ToString();
                txtNombre.Text = dgvCartera.CurrentRow.Cells["Nombre"].Value.ToString();
                txtSaldoCliente.Text = UseObject.InsertSeparatorMil(
                    Tabla.AsEnumerable().Where(d => d.Field<string>("Cedula").Equals(cedula)).Sum(s => s.Field<int>("Saldo")).ToString());
            }
        }

        void CompletaEventos_Completabo(CompletaArgumentosDeEventobo args)
        {
            try
            {
                this.txtConsulta.Text = (string)args.MiBodegabo;
            }
            catch { }
        }

        private void Consultar()
        {
            try
            {
                switch (CriterioPrint)
                {
                    case 1:
                        {
                            this.ClientePrint = "";
                            Tabla = miBussinesRemision.CarteraClientes(false, false, null);
                            break;
                        }
                    case 2:
                        {
                            this.ClientePrint = "";
                            Tabla = miBussinesRemision.CarteraClientes(true, false, null);
                            break;
                        }
                    case 3:
                        {
                            Tabla = miBussinesRemision.CarteraClientes(false, true, this.ClientePrint);
                            break;
                        }
                }
                if (this.InvokeRequired)
                    this.Invoke(new Action(Finalizar));
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
                if (this.InvokeRequired)
                    this.Invoke(new Action(Finalizar));
            }
        }

        private void Finalizar()
        {
            try
            {
                dgvCartera.DataSource = Tabla;
                txtTotal.Text = UseObject.InsertSeparatorMil(Tabla.AsEnumerable().Sum(s => s.Field<int>("Saldo")).ToString());
                if (dgvCartera.Rows.Count > 15 && NombreWith.Equals(Nombre.Width))
                {
                    dgvCartera.Columns["Nombre"].Width = Nombre.Width - 5;
                }
                if (dgvCartera.RowCount != 0)
                {
                    SaldoDeCliente();
                }
                ColorGrid();
                ColorSaldoLimite();

                miOption.FrmProgressBar.barraProgreso.Style = ProgressBarStyle.Blocks;
                miOption.FrmProgressBar.Closed_ = false;
                miOption.FrmProgressBar.Close();
            }
            catch (Exception ex)
            {
                miOption.FrmProgressBar.barraProgreso.Style = ProgressBarStyle.Blocks;
                miOption.FrmProgressBar.Closed_ = false;
                miOption.FrmProgressBar.Close();
                OptionPane.MessageError(ex.Message);

            }
        }
    }
}