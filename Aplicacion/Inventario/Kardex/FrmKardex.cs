using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DTO.Clases;
using BussinesLayer.Clases;
using Utilities;
using CustomControl;

namespace Aplicacion.Inventario.Kardex
{
    public partial class FrmKardex : Form
    {
        private BussinesProducto miBussinesProducto;

        private BussinesKardex miBussinesKardex;

        private int Iteracion;

        private int Rowkardex;

        private int RowMaxKardex;

        private long Pages;

        private long TotalRows;

        private int CurrentPage;

        private string CodigoActual;

        private DateTime FechaActual;

        private DateTime FechaActual2;

        private int MoveActual;

        private ErrorProvider miError;

        private DTO.Clases.Producto producto;

        public FrmKardex()
        {
            InitializeComponent();
            miError = new ErrorProvider();
            miBussinesProducto = new BussinesProducto();
            miBussinesKardex = new BussinesKardex();
            RowMaxKardex = 15;
        }

        private void FrmKardex_Load(object sender, EventArgs e)
        {
            CargarRecursos();
            CompletaEventos.CompTProductoFact += new CompletaEventos.ComAxTransferProductFact(CompletaEventos_CompTProductoFact);
        }

        private void FrmKardex_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyData)
            {
                case Keys.F3:
                    {
                        this.tsConsultarProducto_Click(this.tsConsultarProducto, new EventArgs());
                        break;
                    }
                case Keys.F5:
                    {
                        this.tsVerResumen_Click(this.tsVerResumen, new EventArgs());
                        break;
                    }
                case Keys.F7:
                    {
                        this.dgvKardex.Focus();
                        break;
                    }
                case Keys.F10:
                    {
                        this.tsBtnImprimir_Click(this.tsBtnImprimir, new EventArgs());
                        break;
                    }
                case Keys.Add: // " + "
                    {
                        if (this.dgvKardex.Focused)
                        {
                            this.btnSiguiente_Click(this.btnSiguiente, new EventArgs());
                        }
                        break;
                    }
                case Keys.Subtract:  // " - "
                    {
                        if (this.dgvKardex.Focused)
                        {
                            this.btnAnterior_Click(this.btnAnterior, new EventArgs());
                        }
                        break;
                    }
                case Keys.Escape:
                    {
                        this.Close();
                        break;
                    }
            }
        }

        private void tsConsultarProducto_Click(object sender, EventArgs e)
        {
            var formInventario = new Inventario.Consulta.FrmConsultaInventario();
            formInventario.MdiParent = this.MdiParent;
            formInventario.ExtendVenta = true;
            //formInventario.txtCodigoNombre.Text = txtProducto.Text;
            //xtendForms = true;
            formInventario.Show();
            formInventario.dgvInventario.Focus();
            formInventario.ColorearGrid();
        }

        private void tsVerResumen_Click(object sender, EventArgs e)
        {
            if (dgvKardex.RowCount != 0)
            {
                var frmResumen = new FrmResumenKardex();
                frmResumen.Codigo = CodigoActual;
                frmResumen.Fecha = dtpFecha1.Value;
                frmResumen.Fecha2 = dtpFecha2.Value;
                if (Convert.ToInt32(cbFecha.SelectedValue).Equals(2)) // Periodo
                {
                    frmResumen.Periodo = true;
                }
                frmResumen.ShowDialog();
            }
            else
            {
                OptionPane.MessageInformation("No hay registros para resumir.");
            }
        }

        private void tsBtnSelecionaGrid_Click(object sender, EventArgs e)
        {
            this.dgvKardex.Focus();
        }

        private void tsBtnImprimir_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.dgvKardex.RowCount != 0)
                {
                    string criterio = "";
                    var tabla = new DataTable();
                    if (Convert.ToInt32(cbMovimiento.SelectedValue).Equals(0)) // Todos los movimientos
                    {
                        if (Convert.ToInt32(cbFecha.SelectedValue).Equals(1)) // Fecha
                        {
                            criterio = "Fecha: " + this.dtpFecha1.Value.ToShortDateString();
                            tabla = this.miBussinesKardex.Kardex(this.dtpFecha1.Value, this.producto.CodigoInternoProducto);
                        }
                        else   //  periodo
                        {
                            criterio = "Periodo: " + this.dtpFecha1.Value.ToShortDateString() + " a " + this.dtpFecha2.Value.ToShortDateString();
                            tabla = this.miBussinesKardex.Kardex(this.dtpFecha1.Value, this.dtpFecha2.Value, this.producto.CodigoInternoProducto);
                        }
                    }
                    else
                    {
                        if (Convert.ToInt32(cbFecha.SelectedValue).Equals(1)) // Fecha
                        {
                            criterio = "Fecha: " + this.dtpFecha1.Value.ToShortDateString();
                            tabla = this.miBussinesKardex.Kardex(Convert.ToInt32(this.cbMovimiento.SelectedValue), this.dtpFecha1.Value, this.producto.CodigoInternoProducto);
                        }
                        else   //  periodo
                        {
                            criterio = "Periodo: " + this.dtpFecha1.Value.ToShortDateString() + " a " + this.dtpFecha2.Value.ToShortDateString();
                            tabla = this.miBussinesKardex.Kardex(Convert.ToInt32(this.cbMovimiento.SelectedValue),
                                this.dtpFecha1.Value, this.dtpFecha2.Value, this.producto.CodigoInternoProducto);
                        }
                    }

                    var frmPrint = new FrmPrint();
                    frmPrint.Tabla = tabla;
                    frmPrint.ReportPath = AppConfiguracion.ValorSeccion("report") + @"\reports\InformeKardex.rdlc";
                    //frmPrint.ReportPath = @"C:\reports\InformeKardex.rdlc";
                    //frmPrint.ReportPath = @"D:\Proyectos\DFPYME_NO_CONT\SistemaFactura\Aplicacion\Informes\Inventario\InformeKardex.rdlc";
                    frmPrint.Criterio = criterio;
                    frmPrint.Codigo = this.producto.CodigoInternoProducto;
                    frmPrint.Barras = this.producto.CodigoBarrasProducto;
                    frmPrint.Nombre = this.producto.NombreProducto;

                    if (!(Convert.ToInt32(cbMovimiento.SelectedValue).Equals(0))) // Todos los movimientos
                    {
                        frmPrint.Total = tabla.AsEnumerable().Sum(s => s.Field<double>("cantidad")).ToString();
                        frmPrint.VTotal = tabla.AsEnumerable().Sum(s => s.Field<double>("cantidad") * s.Field<double>("valor")).ToString();
                    }
                    else
                    {
                        frmPrint.Total = "0";
                        frmPrint.VTotal = "0";
                    }

                    frmPrint.ShowDialog();
                }
                else
                {
                    OptionPane.MessageInformation("Debe cargar una consulta");
                }
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
        }

        private void tsSalir_Click(object sender, EventArgs e)
        {
            this.Close();
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

        private void txtProducto_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar.Equals((char)Keys.Enter))
            {
                try
                {
                    if (!String.IsNullOrEmpty(this.txtProducto.Text))
                    {
                        if (CodigoOrString(txtProducto.Text))
                        {
                            dgvKardex.AutoGenerateColumns = false;
                            var arrayProducto = miBussinesProducto.ProductoBasico(txtProducto.Text);
                            /*if (arrayProducto.Count > 0)
                            {*/
                            try
                            {
                                //miError.SetError(txtProducto, null);
                                if (arrayProducto.Count != 0)
                                {
                                    producto = (DTO.Clases.Producto)arrayProducto[0];
                                    lblDatosProducto.Text = producto.CodigoInternoProducto + " - " + producto.NombreProducto;
                                    if (Convert.ToInt32(cbMovimiento.SelectedValue).Equals(0)) // Todos los movimientos
                                    {
                                        if (Convert.ToInt32(cbFecha.SelectedValue).Equals(1)) // Fecha
                                        {
                                            Kardex(dtpFecha1.Value, producto.CodigoInternoProducto);
                                        }
                                        else // Periodo
                                        {
                                            Kardex(dtpFecha1.Value, dtpFecha2.Value, producto.CodigoInternoProducto);
                                        }
                                    }
                                    else
                                    {
                                        if (Convert.ToInt32(cbFecha.SelectedValue).Equals(1)) // Fecha
                                        {
                                            Kardex(Convert.ToInt32(cbMovimiento.SelectedValue), dtpFecha1.Value, producto.CodigoInternoProducto);
                                        }
                                        else // Periodo
                                        {
                                            Kardex(Convert.ToInt32(cbMovimiento.SelectedValue), dtpFecha1.Value,
                                                                dtpFecha2.Value, producto.CodigoInternoProducto);
                                        }
                                    }
                                    txtProducto.Text = "";
                                    if (dgvKardex.RowCount != 0)
                                    {
                                        this.dgvKardex_CellClick(this.dgvKardex, null);
                                    }
                                }
                                else
                                {
                                    OptionPane.MessageInformation("El producto no existe.");
                                }
                            }
                            catch (InvalidCastException)
                            {
                                //miError.SetError(txtProducto, "No se encontraron registros con ese código.");
                                OptionPane.MessageInformation("EL articulo no existe.");
                            }
                            /*}
                            else
                            {
                                miError.SetError(txtProducto, "No se encontraron registros con ese código.");
                            }*/
                        }
                        else
                        {
                            var formInventario = new Inventario.Consulta.FrmConsultaInventario();
                            formInventario.MdiParent = this.MdiParent;
                            formInventario.ExtendVenta = true;
                            formInventario.txtCodigoNombre.Text = txtProducto.Text;
                            //xtendForms = true;
                            formInventario.Show();
                            formInventario.dgvInventario.Focus();
                            formInventario.ColorearGrid();
                        }
                    }
                }
                catch (Exception ex)
                {
                    OptionPane.MessageError(ex.Message);
                }
            }
        }

        private void dgvKardex_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Up || e.KeyData == Keys.Down)
            {
                this.dgvKardex_CellClick(this.dgvKardex, null);
            }
        }

        private void dgvKardex_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvKardex.RowCount != 0)
            {
                var documento = "";
                var No = dgvKardex.CurrentRow.Cells["NoDocumento"].Value.ToString();
                var id = Convert.ToInt32(dgvKardex.CurrentRow.Cells["IdConcepto"].Value);
                switch (id)
                {
                        // Entradas
                    case 1:
                        {
                            documento = "Factura Proveedor No. " + No;
                            break;
                        }
                    case 2:
                        {
                            documento = "Remisión Proveedor No. " + No;
                            break;
                        }
                    case 3:
                        {
                            documento = "Devolución venta No " + No;
                            break;
                        }
                    case 5:
                        {
                            documento = "Factura Proveedor No. " + No;
                            break;
                        }
                    case 6:
                        {
                            documento = "Remisión Proveedor No. " + No;
                            break;
                        }
                    case 18:
                        {
                            documento = "Factura venta No. " + No;
                            break;
                        }

                        // Salidas
                    case 10:
                        {
                            documento = "Factura venta No. " + No;
                            break;
                        }
                    case 11:
                        {
                            documento = "Remisión de cliente No. " + No;
                            break;
                        }
                    case 12:
                        {
                            documento = "Devolución a Proveedor No. " + No;
                            break;
                        }
                    case 14:
                        {
                            documento = "Factura Proveedor No. " + No;
                            break;
                        }
                    case 15:
                        {
                            documento = "Remisión Proveedor No. " + No;
                            break;
                        }
                    case 16:
                        {
                            documento = "Factura Proveedor No. " + No;
                            break;
                        }
                    case 17:
                        {
                            documento = "Remisión Proveedor No. " + No;
                            break;
                        }
                    case 19:
                        {
                            documento = "Factura venta No. " + No;
                            break;
                        }
                }
                txtDocumento.Text = documento;
            }
        }

        private void btnInicio_Click(object sender, EventArgs e)
        {
            if (CurrentPage > 1)
            {
                var page = CurrentPage;
                for (int i = page; i > 1; i--)
                {
                    Rowkardex = Rowkardex - RowMaxKardex;
                    CurrentPage--;
                }
                try
                {
                    switch (Iteracion)
                    {
                        case 1:
                            {
                                dgvKardex.DataSource =
                                    miBussinesKardex.Kardex(FechaActual, CodigoActual, Rowkardex, RowMaxKardex);
                                break;
                            }
                        case 2:
                            {
                                dgvKardex.DataSource =
                                    miBussinesKardex.Kardex(MoveActual, FechaActual, CodigoActual, Rowkardex, RowMaxKardex);
                                break;
                            }
                        case 3:
                            {
                                dgvKardex.DataSource = miBussinesKardex.Kardex
                                       (FechaActual, FechaActual2, CodigoActual, Rowkardex, RowMaxKardex);
                                break;
                            }
                        case 4:
                            {
                                dgvKardex.DataSource = miBussinesKardex.Kardex
                                (MoveActual, FechaActual, FechaActual2, CodigoActual, Rowkardex, RowMaxKardex);
                                break;
                            }
                    }
                    lblStatus.Text = CurrentPage + " / " + Pages;
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
                Rowkardex = Rowkardex - RowMaxKardex;
                if (Rowkardex <= 0)
                    Rowkardex = 0;
                try
                {
                    switch (Iteracion)
                    {
                        case 1:
                            {
                                dgvKardex.DataSource =
                                    miBussinesKardex.Kardex(FechaActual, CodigoActual, Rowkardex, RowMaxKardex);
                                break;
                            }
                        case 2:
                            {
                                dgvKardex.DataSource =
                                    miBussinesKardex.Kardex(MoveActual, FechaActual, CodigoActual, Rowkardex, RowMaxKardex);
                                break;
                            }
                        case 3:
                            {
                                dgvKardex.DataSource = miBussinesKardex.Kardex
                                       (FechaActual, FechaActual2, CodigoActual, Rowkardex, RowMaxKardex);
                                break;
                            }
                        case 4:
                            {
                                dgvKardex.DataSource = miBussinesKardex.Kardex
                                (MoveActual, FechaActual, FechaActual2, CodigoActual, Rowkardex, RowMaxKardex);
                                break;
                            }
                    }
                    CurrentPage--;
                    lblStatus.Text = CurrentPage + " / " + Pages;
                }
                catch (Exception ex)
                {
                    OptionPane.MessageError(ex.Message);
                }
            }
        }

        private void btnSiguiente_Click(object sender, EventArgs e)
        {
            if (CurrentPage < Pages)
            {
                Rowkardex = Rowkardex + RowMaxKardex;
                try
                {
                    switch (Iteracion)
                    {
                        case 1:
                            {
                                dgvKardex.DataSource =
                                    miBussinesKardex.Kardex(FechaActual, CodigoActual, Rowkardex, RowMaxKardex);
                                break;
                            }
                        case 2:
                            {
                                dgvKardex.DataSource =
                                    miBussinesKardex.Kardex(MoveActual, FechaActual, CodigoActual, Rowkardex, RowMaxKardex);
                                break;
                            }
                        case 3:
                            {
                                dgvKardex.DataSource = miBussinesKardex.Kardex
                                       (FechaActual, FechaActual2, CodigoActual, Rowkardex, RowMaxKardex);
                                break;
                            }
                        case 4:
                            {
                                dgvKardex.DataSource = miBussinesKardex.Kardex
                                (MoveActual, FechaActual, FechaActual2, CodigoActual, Rowkardex, RowMaxKardex);
                                break;
                            }
                    }
                    CurrentPage++;
                    lblStatus.Text = CurrentPage + " / " + Pages;
                }
                catch (Exception ex)
                {
                    OptionPane.MessageError(ex.Message);
                }
            }
        }

        private void btnFin_Click(object sender, EventArgs e)
        {
            if (CurrentPage < Pages)
            {
                var page = CurrentPage;
                for (int i = page; i < Pages; i++)
                {
                    Rowkardex = Rowkardex + RowMaxKardex;
                    CurrentPage++;
                }
                try
                {
                    switch (Iteracion)
                    {
                        case 1:
                            {
                                dgvKardex.DataSource =
                                    miBussinesKardex.Kardex(FechaActual, CodigoActual, Rowkardex, RowMaxKardex);
                                break;
                            }
                        case 2:
                            {
                                dgvKardex.DataSource =
                                    miBussinesKardex.Kardex(MoveActual, FechaActual, CodigoActual, Rowkardex, RowMaxKardex);
                                break;
                            }
                        case 3:
                            {
                                dgvKardex.DataSource = miBussinesKardex.Kardex
                                       (FechaActual, FechaActual2, CodigoActual, Rowkardex, RowMaxKardex);
                                break;
                            }
                        case 4:
                            {
                                dgvKardex.DataSource = miBussinesKardex.Kardex
                                (MoveActual, FechaActual, FechaActual2, CodigoActual, Rowkardex, RowMaxKardex);
                                break;
                            }
                    }
                    lblStatus.Text = CurrentPage + " / " + Pages;
                }
                catch (Exception ex)
                {
                    OptionPane.MessageError(ex.Message);
                }
            }
        }

        private void CargarRecursos()
        {
            var lst = new List<Producto.Criterio>();
            lst.Add(new Producto.Criterio
            {
                Id = 0,
                Nombre = "Todos los movimientos"
            });
            lst.Add(new Producto.Criterio
            {
                Id = 1,
                Nombre = "Entradas"
            });
            lst.Add(new Producto.Criterio
            {
                Id = 2,
                Nombre = "Salidas"
            });
            cbMovimiento.DataSource = lst;

            lst = new List<Producto.Criterio>();
            lst.Add(new Producto.Criterio
            {
                Id = 1,
                Nombre = "Fecha"
            });
            lst.Add(new Producto.Criterio
            {
                Id = 2,
                Nombre = "Periodo"
            });
            cbFecha.DataSource = lst;
        }

        private bool CodigoOrString(string numero)
        {
            var num = true;
            try
            {
                Convert.ToInt64(numero);
            }
            catch (FormatException)
            {
                num = false;
            }
            catch (OverflowException)
            {
                num = true;
            }
            return num;
        }

        void CompletaEventos_CompTProductoFact(CompletaTransferProductFact args)
        {
            try
            {
                var producto = (DTO.Clases.Producto)args.MiObjeto;
                txtProducto.Text = producto.CodigoInternoProducto;
                this.txtProducto_KeyPress(this.txtProducto, new KeyPressEventArgs((char)Keys.Enter));
            }
            catch { }
        }

        private void Kardex(DateTime fecha, string codigo)
        {
            try
            {
                Rowkardex = 0;
                Iteracion = 1;
                CurrentPage = 1;
                FechaActual = fecha;
                CodigoActual = codigo;
                dgvKardex.DataSource = miBussinesKardex.Kardex(fecha, codigo, Rowkardex, RowMaxKardex);
                TotalRows = miBussinesKardex.GetsRowsKardex(fecha, codigo);
                //ColorearGrid();
                CalcularPaginas();
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
        }

        private void Kardex(int idOperacion, DateTime fecha, string codigo)
        {
            try
            {
                Rowkardex = 0;
                Iteracion = 2;
                CurrentPage = 1;
                MoveActual = idOperacion;
                FechaActual = fecha;
                CodigoActual = codigo;
                dgvKardex.DataSource = 
                    miBussinesKardex.Kardex(idOperacion, fecha, codigo, Rowkardex, RowMaxKardex);
                TotalRows = miBussinesKardex.GetsRowsKardex(idOperacion, fecha, codigo);
                //ColorearGrid();
                CalcularPaginas();
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
        }

        public void Kardex
            (DateTime fecha, DateTime fecha2, string codigo)
        {
            try
            {
                Rowkardex = 0;
                Iteracion = 3;
                CurrentPage = 1;
                FechaActual = fecha;
                FechaActual2 = fecha2;
                CodigoActual = codigo;
                dgvKardex.DataSource = miBussinesKardex.Kardex
                                       (fecha, fecha2, codigo, Rowkardex, RowMaxKardex);
                TotalRows = miBussinesKardex.GetsRowsKardex(fecha, fecha2, codigo);
                CalcularPaginas();
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
        }

        public void Kardex
            (int idOperacion, DateTime fecha, DateTime fecha2, string codigo)
        {
            try
            {
                Rowkardex = 0;
                Iteracion = 4;
                CurrentPage = 1;
                MoveActual = idOperacion;
                FechaActual = fecha;
                FechaActual2 = fecha2;
                CodigoActual = codigo;
                dgvKardex.DataSource =
                    miBussinesKardex.Kardex(idOperacion, fecha, fecha2, codigo, Rowkardex, RowMaxKardex);
                TotalRows = miBussinesKardex.GetsRowsKardex(idOperacion, fecha, fecha2, codigo);
                CalcularPaginas();
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
        }

        public void ColorearGrid()
        {
            var cont = 0;
            foreach (DataGridViewRow row in dgvKardex.Rows)
            {
                cont++;
                if (cont % 2 != 0)
                {
                    row.DefaultCellStyle.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
                }
            }
        }

        private void CalcularPaginas()
        {
            Pages = TotalRows / RowMaxKardex;
            if (TotalRows % RowMaxKardex != 0)
                Pages++;
            if (CurrentPage > Pages)
                CurrentPage = 0;
            lblStatus.Text = CurrentPage + " / " + Pages;
        }

        
    }
}