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

namespace Aplicacion.Compras.Cartera
{
    public partial class FrmCompras : Form
    {
        private DataTable Tabla { set; get; }

        private int NombreWith { set; get; }

        private int CriterioPrint { set; get; }

        private int ProveedorPrint { set; get; }

        private BussinesProveedor miBussinesProveedor;

        private BussinesFacturaProveedor miBussinesFactura;

        public FrmCompras()
        {
            InitializeComponent();
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
            //CompletaEventos.Completabo += new CompletaEventos.CompletaAccionbo(CompletaEventos_Completabo);
        }

        private void tsBtnImprimir_Click(object sender, EventArgs e)
        {
            
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

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                //dgvCartera.DataSource = miBussinesFactura.CarteraProveedores();
                var tabla = new DataTable();
                var id = Convert.ToInt32(cbContado.SelectedValue);
                CriterioPrint = id;
                dgvCartera.AutoGenerateColumns = false;
                switch (id)
                {
                    case 1:
                        {
                            this.ProveedorPrint = 0;
                            Tabla = miBussinesFactura.CarteraProveedores(false, false, 0);
                            break;
                        }
                    case 2:
                        {
                            this.ProveedorPrint = 0;
                            Tabla = miBussinesFactura.CarteraProveedores(true, false, 0);
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
                            Tabla = miBussinesFactura.CarteraProveedores2(false, true, tProveedor.CodigoInternoProveedor);
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




                //var tabla = new DataTable();
                /*var id = Convert.ToInt32(cbContado.SelectedValue);
                CriterioPrint = id;
                dgvCartera.AutoGenerateColumns = false;
                switch (id)
                {
                    case 1:
                        {
                            this.ProveedorPrint = "";
                            Tabla = miBussinesFactura.CarteraClientes(false, false, null);
                            break;
                        }
                    case 2:
                        {
                            this.ProveedorPrint = "";
                            Tabla = miBussinesFactura.CarteraClientes(true, false, null);
                            break;
                        }
                    case 3:
                        {
                            var tCliente = miBussinesCliente.ConsultaClienteNit(this.txtConsulta.Text);
                            if (tCliente.Rows.Count != 0)
                            {
                                this.ProveedorPrint = txtConsulta.Text;
                                Tabla = miBussinesFactura.CarteraClientes(false, true, this.txtConsulta.Text);
                            }
                            else
                            {
                                /*var frmCliente = new Cliente.frmCliente();
                                frmCliente.ConsultaVenta = true;
                                frmCliente.SubConsulta = true;
                                frmCliente.txtParametro.Text = this.txtConsulta.Text;
                                frmCliente.ShowDialog();*/
                           /* }
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
                ColorSaldoLimite();*/
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
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
            lst.Add(new Inventario.Producto.Criterio
            {
                Id = 1,
                Nombre = "Todos los Proveedores"
            });
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

        /*void CompletaEventos_Completabo(CompletaArgumentosDeEventobo args)
        {
            try
            {
                this.txtConsulta.Text = (string)args.MiBodegabo;
            }
            catch { }
        }*/
    }
}