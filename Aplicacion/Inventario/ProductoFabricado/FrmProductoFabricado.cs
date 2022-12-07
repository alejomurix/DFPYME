using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CustomControl;
using Utilities;
using DTO.Clases;
using BussinesLayer.Clases;

namespace Aplicacion.Inventario.ProductoFabricado
{
    public partial class FrmProductoFabricado : Form
    {
        private bool LoadProducto;

        private ErrorProvider miError;

        private int ContadorId;

        private DataTable tProducto;

        private DataTable tConversion;


        private int IdTipoInventario;


        private DTO.Clases.Producto MiProducto;

        private ValorUnidadMedida miMedida;

        private DTO.Clases.Conversion miConversion;


        private BussinesProducto miBussinesProducto;

        private BussinesValorUnidadMedida miBussinesMedida;

        private BussinesConversionProducto miBussinesConversion;

        public FrmProductoFabricado()
        {
            InitializeComponent();
            this.dgvProductoP.AutoGenerateColumns = false;
            this.dgvProductoC.AutoGenerateColumns = false;

            this.dgvProducto.AutoGenerateColumns = false;
            this.dgvDetalleProducto.AutoGenerateColumns = false;

            this.LoadProducto = true;

            this.miError = new ErrorProvider();
            this.ContadorId = 1;

            CreateDataTable();

            this.miConversion = new DTO.Clases.Conversion();
            this.miBussinesProducto = new BussinesProducto();
            this.miBussinesMedida = new BussinesValorUnidadMedida();
            this.miBussinesConversion = new BussinesConversionProducto();

            try
            {
                IdTipoInventario = 3;
                this.dgvProducto.DataSource = miBussinesConversion.ProductosFabricados(IdTipoInventario);
                //this.dgvProducto_CellClick(dgvProducto, null);
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
        }

        private void FrmConfConversion_Load(object sender, EventArgs e)
        {
            CompletaEventos.CompAxTInvFactProvee +=
                        new CompletaEventos.ComAxTransferInvFactProve(CompletaEventos_CompAxTInvFactProvee);
        }

        private void FrmConfConversion_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyData)
            {
                case Keys.F2:
                    {
                        this.tsBtnGuardar_Click(tsBtnGuardar, new EventArgs());
                        break;
                    }
                case Keys.F3:
                    {
                        this.txtProductoP.Focus();
                        break;
                    }
                case Keys.F4:
                    {
                        this.txtProductoC.Focus();
                        break;
                    }
                case Keys.Escape:
                    {
                        this.tsbSalir_Click(this.tsbSalir, new EventArgs());
                        break;
                    }
            }
        }

        private void tsBtnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.dgvProductoP.RowCount > 0 && this.dgvProductoC.RowCount > 0)
                {
                    DialogResult rta = MessageBox.Show("¿Esta seguro(a) de guardar los datos?", "Producto fabricado",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (rta.Equals(DialogResult.Yes))
                    {
                        foreach (DataRow cRow in this.tConversion.Rows)
                        {
                            miBussinesConversion.InsertarProductoFabricado
                                (miConversion.CodigoProducto, cRow["Codigo"].ToString(), Convert.ToDouble(cRow["Cantidad"]));
                        }

                        /*foreach (DataRow cRow in this.tConversion.Rows)
                        {
                            this.miConversion.Detalles.Add(new DetalleConversion
                            {
                                CodigoProducto = cRow["Codigo"].ToString(),
                                Cantidad = Convert.ToDouble(cRow["Cantidad"])
                            });
                        }
                        this.miBussinesConversion.IngresarConversion(this.miConversion);*/
                        OptionPane.MessageInformation("Los datos se almacenarón con éxito.");

                        this.tProducto.Rows.Clear();
                        this.tConversion.Rows.Clear();
                        this.txtProductoP.ReadOnly = false;
                        this.txtProductoP.Focus();
                        this.lblDataProductoP.Text = "";
                        this.lblDataProductoC.Text = "";
                        this.miConversion = new DTO.Clases.Conversion();
                        this.ContadorId = 1;
                    }
                }
                else
                {
                    OptionPane.MessageInformation("Se requiere mas registros para almacenar.");
                }
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
        }

        private void tsbSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtProductoP_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (e.KeyChar == (char)Keys.Enter)
                {
                    if (!String.IsNullOrEmpty(this.txtProductoP.Text))
                    {
                        if (CodigoOrString(this.txtProductoP.Text))
                        {
                            if (ExisteProducto(this.txtProductoP.Text))
                            {
                                if (!this.miBussinesConversion.ExisteConversion(this.txtProductoP.Text))
                                {
                                    this.miError.SetError(this.txtProductoP, null);
                                    CargarProducto(this.txtProductoP.Text, this.lblDataProductoP);
                                    var pRow = this.tProducto.NewRow();
                                    pRow["Id"] = 1;
                                    pRow["Codigo"] = this.miConversion.CodigoProducto = this.MiProducto.CodigoInternoProducto;
                                    pRow["Producto"] = this.MiProducto.NombreProducto;
                                    pRow["Presentacion"] = this.MiProducto.UnidadVentaProducto + " " + this.miMedida.DescripcionValorUnidadMedida; //this.MiProducto.ValorVentaProducto;
                                    pRow["Cantidad"] = this.miConversion.Cantidad = 1;
                                    this.tProducto.Rows.Add(pRow);
                                    this.dgvProductoP.DataSource = this.tProducto;
                                    this.MiProducto = null;
                                    this.txtProductoP.Text = "";
                                    this.txtProductoP.ReadOnly = true;
                                    this.txtProductoC.Focus();
                                }
                                else
                                {
                                    this.miError.SetError(this.txtProductoP, "El producto ya tiene una conversión.");
                                }
                            }
                            else
                            {
                                this.miError.SetError(this.txtProductoP, "El producto no existe");
                                this.txtProductoP.Text = "";
                            }
                        }
                        else
                        {
                            this.LoadProducto = true;
                            var formInventario = new Inventario.Consulta.FrmConsultaInventario();
                            formInventario.MdiParent = this.MdiParent;
                            formInventario.ExtendVenta = true;
                            formInventario.IsCompra = true;
                            formInventario.txtCodigoNombre.Text = this.txtProductoP.Text;
                            formInventario.Show();
                            formInventario.dgvInventario.Focus();
                        }
                    }
                }
                else
                {
                    this.miError.SetError(this.txtProductoP, null);
                }
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
        }

        private void tsBtnEliminarP_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.dgvProductoP.RowCount != 0)
                {
                    DialogResult rta = MessageBox.Show("¿Esta seguro(a) de elminar el registro?", "Conversión de producto",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (rta.Equals(DialogResult.Yes))
                    {
                        var id = Convert.ToInt32(this.dgvProductoP.CurrentRow.Cells["Id"].Value);
                        var query = (from datos in this.tProducto.AsEnumerable()
                                     where datos.Field<int>("Id") == id
                                     select datos).Single();
                        this.tProducto.Rows.RemoveAt(this.tProducto.Rows.IndexOf(query));
                        //this.dgvProductoP.DataSource = null;
                        this.lblDataProductoP.Text = "";
                        this.txtProductoP.ReadOnly = false;
                        this.txtProductoP.Focus();
                    }
                }
                else
                {
                    OptionPane.MessageInformation("No hay registros para eliminar.");
                }
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
        }

        private void txtProductoC_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (e.KeyChar == (char)Keys.Enter)
                {
                    if (!String.IsNullOrEmpty(this.txtProductoC.Text))
                    {
                        if (CodigoOrString(this.txtProductoC.Text))
                        {
                            if (ExisteProducto(this.txtProductoC.Text))
                            {
                                this.miError.SetError(this.txtProductoC, null);
                                CargarProducto(this.txtProductoC.Text, this.lblDataProductoC);
                                this.txtProductoC.Text = "";
                                this.txtCantidad.Focus();
                            }
                            else
                            {
                                this.miError.SetError(this.txtProductoC, "El producto no existe");
                                this.txtProductoC.Text = "";
                            }
                        }
                        else
                        {
                            this.LoadProducto = false;
                            var formInventario = new Inventario.Consulta.FrmConsultaInventario();
                            formInventario.MdiParent = this.MdiParent;
                            formInventario.ExtendVenta = true;
                            formInventario.IsCompra = true;
                            formInventario.txtCodigoNombre.Text = this.txtProductoC.Text;
                            formInventario.Show();
                            formInventario.dgvInventario.Focus();
                        }
                    }
                }
                else
                {
                    this.miError.SetError(this.txtProductoC, null);
                }
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
        }

        private void txtCantidad_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (e.KeyChar == (char)Keys.Enter)
                {
                    if (this.MiProducto != null)
                    {
                        if (!String.IsNullOrEmpty(this.txtCantidad.Text))
                        {
                            if (ValidarDouble(this.txtCantidad.Text))
                            {
                                if (Convert.ToDouble(this.txtCantidad.Text) > 0)
                                {
                                    this.miError.SetError(this.txtCantidad, null);
                                    var cRow = this.tConversion.NewRow();
                                    cRow["Id"] = this.ContadorId;
                                    cRow["Codigo"] = this.MiProducto.CodigoInternoProducto;
                                    cRow["Producto"] = this.MiProducto.NombreProducto;
                                    cRow["Presentacion"] = this.MiProducto.UnidadVentaProducto + " " + this.miMedida.DescripcionValorUnidadMedida;
                                    //cRow["Venta"] = this.MiProducto.ValorVentaProducto;
                                    cRow["Cantidad"] = Convert.ToDouble(this.txtCantidad.Text.Replace('.', ','));
                                    this.tConversion.Rows.Add(cRow);
                                    this.dgvProductoC.DataSource = this.tConversion;
                                    this.MiProducto = null;
                                    this.ContadorId++;
                                    this.txtCantidad.Text = "1";
                                    this.txtProductoC.Focus();
                                }
                                else
                                {
                                    this.miError.SetError(this.txtCantidad, "La cantidad debe ser mayor a cero");
                                }
                            }
                            else
                            {
                                this.miError.SetError(this.txtCantidad, "La cantidad tiene formato incorrecto");
                            }
                        }
                        else
                        {
                            this.miError.SetError(this.txtCantidad, "La cantidad no debe ser vacia");
                        }
                    }
                    else
                    {
                        this.miError.SetError(this.panelProductoC, "Debe cargar un producto");
                    }
                }
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
        }

        private void tsBtnEliminarC_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.dgvProductoC.RowCount != 0)
                {
                    DialogResult rta = MessageBox.Show("¿Esta seguro(a) de elminar el registro?", "Conversión de producto",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (rta.Equals(DialogResult.Yes))
                    {
                        var id = Convert.ToInt32(this.dgvProductoC.CurrentRow.Cells["IdC"].Value);
                        var query = (from datos in this.tConversion.AsEnumerable()
                                     where datos.Field<int>("Id") == id
                                     select datos).Single();
                        this.tConversion.Rows.RemoveAt(this.tConversion.Rows.IndexOf(query));
                        if (this.tConversion.Rows.Count == 0)
                        {
                            this.lblDataProductoC.Text = "";
                        }
                        this.txtProductoC.Focus();
                    }
                }
                else
                {
                    OptionPane.MessageInformation("No hay registros para eliminar.");
                }
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
        }

        private void CreateDataTable()
        {
            this.tProducto = new DataTable();
            tProducto.Columns.Add(new DataColumn("Id", typeof(int)));
            tProducto.Columns.Add(new DataColumn("Codigo", typeof(string)));
            tProducto.Columns.Add(new DataColumn("Producto", typeof(string)));
            tProducto.Columns.Add(new DataColumn("Venta", typeof(int)));
            tProducto.Columns.Add(new DataColumn("Presentacion", typeof(string)));
            tProducto.Columns.Add(new DataColumn("Cantidad", typeof(double)));

            this.tConversion = new DataTable();
            tConversion.Columns.Add(new DataColumn("Id", typeof(int)));
            tConversion.Columns.Add(new DataColumn("Codigo", typeof(string)));
            tConversion.Columns.Add(new DataColumn("Producto", typeof(string)));
            tConversion.Columns.Add(new DataColumn("Venta", typeof(int)));
            tConversion.Columns.Add(new DataColumn("Presentacion", typeof(string)));
            tConversion.Columns.Add(new DataColumn("Cantidad", typeof(double)));
        }

        private bool CodigoOrString(string codigo)
        {
            try
            {
                Convert.ToInt64(codigo);
                return true;
            }
            catch
            {
                return false;
            }
        }

        private bool ValidarDouble(string valor)
        {
            try
            {
                Convert.ToDouble(valor);
                return true;
            }
            catch
            {
                return false;
            }
        }

        private bool ValidarCantidad(string valor, Control c)
        {
            bool valida = true;
            if (!String.IsNullOrEmpty(valor))
            {
                if (ValidarDouble(valor))
                {
                    if (Convert.ToDouble(valor) > 0)
                    {
                        valida = true;
                        this.miError.SetError(c, null);
                    }
                    else
                    {
                        valida = false;
                        this.miError.SetError(c, "Debe ser mayor a cero.");
                    }
                }
                else
                {
                    valida = false;
                    this.miError.SetError(c, "El valor es incorrecto.");
                }
            }
            else
            {
                valida = false;
                this.miError.SetError(c, "El campo no debe ser vacio.");
            }
            return valida;
        }

        private bool ExisteProducto(string codigo)
        {
            try
            {
                var barras = this.miBussinesProducto.ExisteCodigoBarras(codigo);
                var code = this.miBussinesProducto.ExisteCodigo(codigo);
                if (barras || code)
                    return true;
                else
                    return false;
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
                return false;
            }
        }

        private void CargarProducto(string codigo, Label lbl)
        {
            this.miMedida = new ValorUnidadMedida();
            var ArrayProducto = this.miBussinesProducto.ProductoBasico(codigo);
            this.MiProducto = (DTO.Clases.Producto)ArrayProducto[0];
            var tabla = this.miBussinesMedida.MedidasDeProducto(this.MiProducto.CodigoInternoProducto);
            if (!MiProducto.AplicaTalla)
            {
                miMedida = (ValorUnidadMedida)ArrayProducto[1];
            }
            else
            {
                var q = (from d in tabla.AsEnumerable()
                         select d).First();
                this.miMedida.IdValorUnidadMedida = Convert.ToInt32(q["idvalor_unidad_medida"]);
                this.miMedida.DescripcionValorUnidadMedida = q["descripcionvalor_unidad_medida"].ToString();
                q = null;
            }
            lbl.Text = this.MiProducto.CodigoInternoProducto + " - " + this.MiProducto.NombreProducto +
                "  -  " + this.MiProducto.UnidadVentaProducto + " " + this.miMedida.DescripcionValorUnidadMedida;
        }

        void CompletaEventos_CompAxTInvFactProvee(CompletaTransInvFactProvee args)
        {
            try
            {
                var producto = (DTO.Clases.Producto)args.MiObjeto;
                if (this.tcConversion.SelectedIndex == 0)
                {
                    if (this.LoadProducto)
                    {
                        this.txtProductoP.Text = producto.CodigoInternoProducto;
                        this.txtProductoP_KeyPress(this.txtProductoP, new KeyPressEventArgs((char)Keys.Enter));
                    }
                    else
                    {
                        this.txtProductoC.Text = producto.CodigoInternoProducto;
                        this.txtProductoC_KeyPress(this.txtProductoC, new KeyPressEventArgs((char)Keys.Enter));
                    }
                }
                else
                {
                    if (this.panelAgregarProducto.Visible)
                    {
                        this.txtProductoPanel.Text = producto.CodigoInternoProducto;
                        this.txtProductoPanel_KeyPress(this.txtProductoPanel, new KeyPressEventArgs((char)Keys.Enter));
                    }
                    else
                    {
                        this.txtProducto.Text = producto.CodigoInternoProducto;
                        this.txtProducto_KeyPress(this.txtProducto, new KeyPressEventArgs((char)Keys.Enter));
                    }
                }
            }
            catch { }
        }

        private void tsBtnListarTodos_Click(object sender, EventArgs e)
        {
            try
            {
                this.dgvProducto.DataSource = this.miBussinesConversion.Conversiones();
                if (this.dgvProducto.RowCount > 0)
                {
                    this.dgvProducto_CellClick(this.dgvProducto, null);
                }
                else
                {
                    while (this.dgvProductoC.RowCount != 0)
                    {
                        this.dgvProductoC.Rows.RemoveAt(0);
                    }
                    OptionPane.MessageInformation("No hay registros de conversiones.");
                }
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
        }

        private void tsBtnSalirConsulta_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtProducto_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                try
                {
                    if (!String.IsNullOrEmpty(this.txtProducto.Text))
                    {
                        if (CodigoOrString(this.txtProducto.Text))
                        {
                            var arrayProducto = this.miBussinesProducto.ProductoBasico(this.txtProducto.Text);
                            if (arrayProducto.Count > 0)
                            {
                                var p = (DTO.Clases.Producto)arrayProducto[0];
                                this.dgvProducto.DataSource = this.miBussinesConversion.Conversiones(p.CodigoInternoProducto);
                                if (this.dgvProducto.RowCount > 0)
                                {
                                    this.dgvProducto_CellClick(this.dgvProducto, null);
                                }
                                else
                                {
                                    while (this.dgvDetalleProducto.RowCount != 0)
                                    {
                                        this.dgvDetalleProducto.Rows.RemoveAt(0);
                                    }
                                    OptionPane.MessageInformation("No hay registros de conversiones.");
                                }
                                this.txtProducto.Text = "";
                            }
                            else
                            {
                                while (this.dgvDetalleProducto.RowCount != 0)
                                {
                                    this.dgvDetalleProducto.Rows.RemoveAt(0);
                                }
                                OptionPane.MessageInformation("El producto no existe.");
                            }
                            //this.dgvProducto.DataSource = this.miBussinesConversion.Conversiones(p.CodigoInternoProducto);
                            /*if (this.dgvProducto.RowCount > 0)
                            {
                                this.dgvProducto_CellClick(this.dgvProducto, null);
                            }
                            else
                            {
                                while (this.dgvDetalleProducto.RowCount != 0)
                                {
                                    this.dgvDetalleProducto.Rows.RemoveAt(0);
                                }
                                OptionPane.MessageInformation("No hay registros de conversiones.");
                            }
                            this.txtProducto.Text = "";*/
                        }
                        else
                        {
                            // this.LoadProducto = false;
                            var formInventario = new Inventario.Consulta.FrmConsultaInventario();
                            formInventario.MdiParent = this.MdiParent;
                            formInventario.ExtendVenta = true;
                            formInventario.IsCompra = true;
                            formInventario.txtCodigoNombre.Text = this.txtProducto.Text;
                            formInventario.Show();
                            formInventario.dgvInventario.Focus();
                        }
                    }
                }
                catch (Exception ex)
                {
                    OptionPane.MessageError(ex.Message);
                }
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(this.txtProducto.Text))
            {
                this.tsBtnListarTodos_Click(this.tsBtnListarTodos, new EventArgs());
            }
            else
            {
                this.txtProducto_KeyPress(this.txtProducto, new KeyPressEventArgs((char)Keys.Enter));
            }
        }

        private void dgvProducto_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyData.Equals(Keys.Up) || e.KeyData.Equals(Keys.Down))
            {
                this.dgvProducto_CellClick(this.dgvProducto, null);
            }
        }

        private void dgvProducto_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (this.dgvProducto.RowCount > 0)
                {
                    this.dgvDetalleProducto.DataSource =
                        miBussinesConversion.ProductosReceta(this.dgvProducto.CurrentRow.Cells["CodigoConsulta"].Value.ToString());
                    /*this.dgvDetalleProducto.DataSource =
                        this.miBussinesConversion.DetallesConversion(Convert.ToInt32(this.dgvProducto.CurrentRow.Cells["IdConsulta"].Value));*/
                    /* if (!(this.dgvProductoC.RowCount > 0))
                     {
                         while (this.dgvProductoC.RowCount != 0)
                         {
                             this.dgvProductoC.Rows.RemoveAt(0);
                         }
                     }*/
                }
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
        }

        private void tsBtnEliminarP__Click(object sender, EventArgs e)
        {
            try
            {
                if (this.dgvProducto.RowCount > 0)
                {
                    if (this.dgvDetalleProducto.RowCount > 0)
                    {
                        OptionPane.MessageInformation("No se puede eliminar el registro, tiene productos asociados.");
                    }
                    else
                    {
                        DialogResult rta = MessageBox.Show("¿Esta seguro(a) de eliminar el registro?", "Conversión de producto",
                            MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (rta.Equals(DialogResult.Yes))
                        {
                            this.miBussinesConversion.EliminarConversion(Convert.ToInt32(this.dgvProducto.CurrentRow.Cells["IdConsulta"].Value));
                            int index = this.dgvProducto.CurrentRow.Index;
                            this.btnBuscar_Click(this.btnBuscar, new EventArgs());
                            if (this.dgvProducto.RowCount > 1 && index > 1)
                            {
                                this.dgvProducto.Rows[index - 1].Selected = true;
                                this.dgvProducto.CurrentCell = this.dgvProducto.Rows[index - 1].Cells[1];
                            }
                            if (!(this.dgvProducto.RowCount > 0))
                            {
                                while (this.dgvDetalleProducto.RowCount != 0)
                                {
                                    this.dgvDetalleProducto.Rows.RemoveAt(0);
                                }
                            }
                            this.dgvProducto_CellClick(this.dgvProducto, null);
                        }
                    }
                }
                else
                {
                    OptionPane.MessageInformation("No hay registros para eliminar.");
                }
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
        }

        private void tsBtnAgregar_Click(object sender, EventArgs e)
        {
            if (this.dgvProducto.RowCount > 0)
            {
                this.panelAgregarProducto.Visible = true;
                this.txtProductoPanel.Focus();
            }
            else
            {
                OptionPane.MessageInformation("Debe cargar una consulta para agregar productos.");
            }
        }

        private void tsBtnEliminarD_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.dgvDetalleProducto.RowCount > 0)
                {
                    DialogResult rta = MessageBox.Show("¿Esta seguro(a) de eliminar el registro?", "Producto fabricado",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (rta.Equals(DialogResult.Yes))
                    {
                        /*this.miBussinesConversion.EliminarDetalle(Convert.ToInt32
                            (this.dgvDetalleProducto.CurrentRow.Cells["IdConsultaDetalle"].Value));*/
                        miBussinesConversion.EliminarProductoReceta(Convert.ToInt32
                            (this.dgvDetalleProducto.CurrentRow.Cells["IdConsultaDetalle"].Value));
                        this.dgvProducto_CellClick(this.dgvProducto, null);
                        //IdConsultaDetalle
                    }
                }
                else
                {
                    OptionPane.MessageInformation("No hay registros para eliminar.");
                }
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
        }



        private void txtProductoPanel_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar.Equals((char)Keys.Enter))
            {
                try
                {
                    if (!String.IsNullOrEmpty(this.txtProductoPanel.Text))
                    {
                        if (CodigoOrString(this.txtProductoPanel.Text))
                        {
                            CargarProducto(this.txtProductoPanel.Text, lblDataProductoPanel);
                            this.txtProductoPanel.Text = "";
                            this.txtCantidadPanel.Focus();
                        }
                        else
                        {
                            var formInventario = new Inventario.Consulta.FrmConsultaInventario();
                            formInventario.MdiParent = this.MdiParent;
                            formInventario.ExtendVenta = true;
                            formInventario.IsCompra = true;
                            formInventario.txtCodigoNombre.Text = this.txtProductoPanel.Text;
                            formInventario.Show();
                            formInventario.dgvInventario.Focus();
                        }
                    }
                }
                catch (Exception ex)
                {
                    OptionPane.MessageError(ex.Message);
                }
            }
        }

        private void txtCantidadPanel_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar.Equals((char)Keys.Enter))
            {
                this.btnAceptar_Click(this.btnAceptar, new EventArgs());
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.MiProducto != null)
                {
                    if (this.ValidarCantidad(this.txtCantidadPanel.Text, this.txtCantidadPanel))
                    {
                        DialogResult rta = MessageBox.Show("¿Esta seguro(a) de agregar el registro?", "Producto fabricado",
                            MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (rta.Equals(DialogResult.Yes))
                        {
                            this.miError.SetError(this.panelAgregar, null);
                            var detalle = new DetalleConversion();
                            //detalle.IdConversion = Convert.ToInt32(this.dgvProducto.CurrentRow.Cells["IdConsulta"].Value); //CodigoConsulta 
                            
                            detalle.CodigoProducto = this.MiProducto.CodigoInternoProducto;
                            detalle.Cantidad = Convert.ToDouble(this.txtCantidadPanel.Text.Replace('.', ','));

                            miBussinesConversion.InsertarProductoFabricado
                                (dgvProducto.CurrentRow.Cells["CodigoConsulta"].Value.ToString(), detalle.CodigoProducto, detalle.Cantidad);

                            /*foreach (DataRow cRow in this.tConversion.Rows)
                            {
                                miBussinesConversion.InsertarProductoFabricado
                                    (miConversion.CodigoProducto, cRow["Codigo"].ToString(), Convert.ToDouble(cRow["Cantidad"]));
                            }*/

                            //this.miBussinesConversion.IngresarDetalleConversion(detalle);
                            OptionPane.MessageInformation("El producto se agrego con éxito.");
                            this.dgvProducto_CellClick(this.dgvProducto, null);
                            this.MiProducto = null;
                            this.lblDataProductoPanel.Text = "";
                            this.txtCantidadPanel.Text = "1";
                            this.txtProductoPanel.Focus();
                            this.panelAgregarProducto.Visible = false;
                        }
                    }
                }
                else
                {
                    this.miError.SetError(this.panelAgregar, "Debe cargar un producto");
                }

            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.MiProducto = null;
            this.lblDataProductoPanel.Text = "";
            this.txtCantidad.Text = "1";
            this.panelAgregarProducto.Visible = false;
        }

        private void tcConversion_Click(object sender, EventArgs e)
        {
            try
            {
                this.dgvProducto_CellClick(dgvProducto, null);
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
        }

    }
}