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

namespace Aplicacion.Compras.CarteraRemision
{
    public partial class FrmCartera : Form
    {
        private DataTable Tabla { set; get; }

        private int NombreWith { set; get; }

        private int CCriterio { set; get; }

        private string Consulta { set; get; }

        private int CriterioPrint { set; get; }

        private int ProveedorPrint { set; get; }

        private BussinesProveedor miBussinesProveedor;

        private BussinesFacturaProveedor miBussinesFactura;

        private BussinesRemision miBussinesRemision;

        private Thread miThread;

        private OptionPane miOption;

        private ErrorProvider miError;

        public FrmCartera()
        {
            InitializeComponent();
            miError = new ErrorProvider();
            this.Tabla = new DataTable();
            NombreWith = Nombre.Width;
            this.CriterioPrint = 2;
            this.ProveedorPrint = 0;
            miBussinesProveedor = new BussinesProveedor();
            miBussinesFactura = new BussinesFacturaProveedor();
        }

        private void FrmCartera_Load(object sender, EventArgs e)
        {
            CargarComponentes();
            miBussinesRemision = new BussinesRemision();
            CompletaEventos.Completa += new CompletaEventos.CompletaAccion(CompletaEventos_Completo);
        }

        private void tsBtnImprimir_Click(object sender, EventArgs e)
        {
            try
            {
                var id = Convert.ToInt32(cbContado.SelectedValue);
                 var tabla = new DataTable();
                 switch (CriterioPrint)
                 {
                     case 1:
                         {
                             //tabla = miBussinesFactura.CarteraProveedores(false, false, 0);
                             tabla = miBussinesRemision.CarteraProveedores(false, false, 0);                             
                             break;
                         }
                     case 2:
                         {
                             //tabla = miBussinesFactura.CarteraProveedores(true, false, 0);
                             tabla = miBussinesRemision.CarteraProveedores(true, false, 0);
                             break;
                         }
                     case 3:
                         {
                             //tabla = miBussinesFactura.CarteraProveedores(false, true, this.ProveedorPrint);
                             tabla = miBussinesRemision.CarteraProveedores(false, true, this.ProveedorPrint);
                             break;
                         }
                 }
                 if (dgvCartera.RowCount != 0)
                 {
                     var frmPrint = new Ventas.Cartera.FrmPrintCartera();
                     frmPrint.Reporte = "CARTERA REMISIÓN DE PROVEEDORES.";
                     frmPrint.Tabla = tabla;
                     if (Convert.ToBoolean(AppConfiguracion.ValorSeccion("printCarteraProveedor")))
                     {
                         frmPrint.PrintPos(false);
                     }
                     else
                     {
                         frmPrint.ReportPath = AppConfiguracion.ValorSeccion("report") + @"\reports\CarteraDeProveedores.rdlc";
                         frmPrint.ShowDialog();
                     }
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
                var frmPrint = new Ventas.Cartera.FrmPrintCartera();
                frmPrint.Reporte = "RESUMEN CARTERA DE CLIENTES.";
                frmPrint.Tabla = miBussinesRemision.ResumenCarteraProveedores();
                if (Convert.ToBoolean(AppConfiguracion.ValorSeccion("printCarteraProveedor")))
                {
                    frmPrint.PrintPos(true);
                }
                else
                { 
                    //frmPrint.ReportPath = 
                    //@"C:\Users\Admin\Documents\Visual Studio 2010\Projects\DFPYME\Aplicacion\Informes\ResumenCarteraDeProveedores.rdlc";

                    //frmPrint.ReportPath = @"c:\reports\ResumenCarteraDeProveedores.rdlc";
                    frmPrint.ReportPath = AppConfiguracion.ValorSeccion("report") + @"\reports\ResumenCarteraDeProveedores.rdlc";
                    frmPrint.ShowDialog();
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

        private void cbContado_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Convert.ToInt32(cbContado.SelectedValue).Equals(3))
            {
                cbCriterioProveedor.Enabled = true;
            }
            else
            {
                cbCriterioProveedor.Enabled = false;
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
            var formProveedor = new Proveedor.frmProveedor();
            formProveedor.Extension = true;
            formProveedor.tcProveedor.SelectTab(1);
            formProveedor.ShowDialog();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            CCriterio = Convert.ToInt32(cbCriterioProveedor.SelectedValue);
            Consulta = txtConsulta.Text;
            var Consulta_ = true;
            if (Convert.ToInt32(cbContado.SelectedValue).Equals(3) && CCriterio.Equals(1))
            {
                try
                {
                    Convert.ToInt32(Consulta);
                    Consulta_ = true;
                    miError.SetError(txtConsulta, null);
                }
                catch (FormatException)
                {
                    miError.SetError(txtConsulta, "El Código no tiene formato correcto.");
                    Consulta_ = false;
                }
            }

            if (Consulta_)
            {
                CriterioPrint = Convert.ToInt32(cbContado.SelectedValue);
                dgvCartera.AutoGenerateColumns = false;

                miOption = new OptionPane();
                miOption.FrmProgressBar.barraProgreso.Style = ProgressBarStyle.Marquee;
                miOption.FrmProgressBar.Closed_ = true;
                miOption.ProgressShow("Espere mientras se realizan las operaciones necesarias...",
                    "Operacion en progreso");
                miThread = new Thread(Consultar);
                miThread.Start();
            }

            /*try
            {
                var tabla = new DataTable();
                var id = Convert.ToInt32(cbContado.SelectedValue);
                CriterioPrint = id;
                dgvCartera.AutoGenerateColumns = false;
                switch (id)
                {
                    case 1:
                        {
                            this.ProveedorPrint = 0;
                            //Tabla = miBussinesFactura.CarteraProveedores(false, false, 0);
                            Tabla = miBussinesRemision.CarteraProveedores(false, false, 0);
                            break;
                        }
                    case 2:
                        {
                            this.ProveedorPrint = 0;
//                            Tabla = miBussinesFactura.CarteraProveedores(true, false, 0);
                            Tabla = miBussinesRemision.CarteraProveedores(true, false, 0);
                            break;
                        }
                    case 3:
                        {
                            var tProveedor = new DTO.Clases.Proveedor();
                            if (Convert.ToInt32(cbCriterioProveedor.SelectedValue).Equals(1))
                            {
                                try
                                {
                                    tProveedor = miBussinesProveedor.ConsultarPrveedorBasico(Convert.ToInt32(txtConsulta.Text));
                                }
                                catch (FormatException)
                                {
                                    OptionPane.MessageInformation("El Código no tiene formato correcto.");
                                }
                            }
                            else
                            {
                                tProveedor = miBussinesProveedor.ConsultarPrveedorBasico(txtConsulta.Text);
                            }
                            //Tabla = miBussinesFactura.CarteraProveedores(false, true, tProveedor.CodigoInternoProveedor);
                            Tabla = miBussinesRemision.CarteraProveedores(false, true, tProveedor.CodigoInternoProveedor);
                            ProveedorPrint = tProveedor.CodigoInternoProveedor;
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

        private void CargarComponentes()
        {
            var lst = new List<Inventario.Producto.Criterio>();
           /* lst.Add(new Inventario.Producto.Criterio
            {
                Id = 1,
                Nombre = "Todos los Proveedores"
            });*/
            lst.Add(new Inventario.Producto.Criterio
            {
                Id = 2,
                Nombre = "Proveedores con saldo"
            });
            lst.Add(new Inventario.Producto.Criterio
            {
                Id = 3,
                Nombre = "Proveedor"
            });
            cbContado.DataSource = lst;

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
            cbCriterioProveedor.DataSource = lst;
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
            txtNombre.Text = dgvCartera.CurrentRow.Cells["Nombre"].Value.ToString();
            txtSaldoProveedor.Text = UseObject.InsertSeparatorMil(
                Tabla.AsEnumerable().Where(d => d.Field<string>("Cedula").Equals(cedula)).Sum(s => s.Field<int>("Saldo")).ToString());
        }

        void CompletaEventos_Completo(CompletaArgumentosDeEvento args)
        {
            try
            {
                var proveedor = (DTO.Clases.Proveedor)args.MiObjeto;
                txtConsulta.Text = proveedor.CodigoInternoProveedor.ToString();
                this.btnBuscar_Click(this.btnBuscar, new EventArgs());
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
                            this.ProveedorPrint = 0;
                            Tabla = miBussinesRemision.CarteraProveedores(false, false, 0);
                            break;
                        }
                    case 2:
                        {
                            this.ProveedorPrint = 0;
                            Tabla = miBussinesRemision.CarteraProveedores(true, false, 0);
                            break;
                        }
                    case 3:
                        {
                            var tProveedor = new DTO.Clases.Proveedor();
                            if (CCriterio.Equals(1))
                            {
                                tProveedor = miBussinesProveedor.ConsultarPrveedorBasico(Convert.ToInt32(this.Consulta));
                            }
                            else
                            {
                                tProveedor = miBussinesProveedor.ConsultarPrveedorBasico(this.Consulta);
                            }
                            Tabla = miBussinesRemision.CarteraProveedores(false, true, tProveedor.CodigoInternoProveedor);
                            ProveedorPrint = tProveedor.CodigoInternoProveedor;
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