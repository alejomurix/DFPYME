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

namespace Aplicacion.Inventario.Conversion
{
    public partial class FrmConversion : Form
    {
        private bool LoadProducto;

        private ErrorProvider miError;

       // private int ContadorId;

        

        private DataTable tConversion;

        private DataTable tConversionAso;


        private DTO.Clases.Producto MiProducto;

        private ValorUnidadMedida miMedida;

        private DTO.Clases.Inventario miInventario;

        private DTO.Clases.Conversion miConversion;


        private BussinesProducto miBussinesProducto;

        private BussinesValorUnidadMedida miBussinesMedida;

        private BussinesInventario miBussinesInventario;

        private BussinesConversionProducto miBussinesConversion;

        private BussinesKardex miBussinesKardex;

        public FrmConversion()
        {
            InitializeComponent();
            this.dgvProducto.AutoGenerateColumns = false;
            this.dgvProductoAso.AutoGenerateColumns = false;
            this.dgvProductoDetalleAso.AutoGenerateColumns = false;
            this.dgvProductosC.AutoGenerateColumns = false;

            this.LoadProducto = true;

            this.miError = new ErrorProvider();
            //this.ContadorId = 1;

            CreateDataTable();

            this.miConversion = new DTO.Clases.Conversion();
            this.miBussinesProducto = new BussinesProducto();
            this.miBussinesMedida = new BussinesValorUnidadMedida();
            this.miBussinesInventario = new BussinesInventario();
            this.miBussinesConversion = new BussinesConversionProducto();
            this.miBussinesKardex = new BussinesKardex();
        }

        private void FrmConversion_Load(object sender, EventArgs e)
        {
            this.txtProducto.Select();
        }

        private void FrmConversion_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyData)
            {
                case Keys.F2:
                    {
                        if (this.tabControlConversion.SelectedIndex == 0)
                        {
                            this.tsBtnGuardar_Click(this.tsBtnGuardar, new EventArgs());
                        }
                        else
                        {
                            this.tsBtnGuardarAso_Click(this.tsBtnGuardarAso, new EventArgs());
                        }
                        break;
                    }
                case Keys.F3:
                    {
                        this.txtProductoAso.Focus();
                        break;
                    }
                case Keys.F4:
                    {
                        this.txtProductoAsoC.Focus();
                        break;
                    }
                case Keys.F5:
                    {
                        this.dgvProductoAso.Focus();
                        break;
                    }
                case Keys.PageUp:
                    {
                        this.tabControlConversion.SelectedIndex = 0;
                        this.txtProducto.Focus();
                        break;
                    }
                case Keys.PageDown:
                    {
                        this.tabControlConversion.SelectedIndex = 1;
                        this.txtProductoAso.Focus();
                        break;
                    }
                case Keys.Escape:
                    {
                        this.Close();
                        break;
                    }
            }
        }


        private void tsBtnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.dgvProducto.RowCount > 0)
                {
                    DialogResult rta_ = MessageBox.Show("¿Esta seguro(a) de guardar los cambios?", "Conversión",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (rta_.Equals(DialogResult.Yes))
                    {
                        this.miInventario.Cantidad = Convert.ToDouble(this.txtCantidadResumen.Text.Replace('.', ','));
                        this.miBussinesInventario.ActualizarInventario(this.miInventario, true);

                        var kardex = new DTO.Clases.Kardex();
                        kardex.Codigo = this.miInventario.CodigoProducto;
                        kardex.IdUsuario = Convert.ToInt32(AppConfiguracion.ValorSeccion("id_user"));
                        kardex.IdConcepto = 20;
                        kardex.Fecha = DateTime.Now;
                        kardex.Cantidad = this.miInventario.Cantidad;
                        kardex.Valor = this.MiProducto.ValorVentaProducto;
                        kardex.Total = kardex.Valor * kardex.Cantidad;
                        this.miBussinesKardex.Insertar(kardex);

                        foreach (DataGridViewRow gRow in this.dgvProducto.Rows)
                        {
                            var invent = new DTO.Clases.Inventario();
                            invent.CodigoProducto = gRow.Cells["Codigo"].Value.ToString();
                            invent.IdMedida = Convert.ToInt32(gRow.Cells["IdMedida"].Value);
                            invent.Cantidad = Convert.ToDouble(gRow.Cells["CantidadCo"].Value);
                            this.miBussinesInventario.ActualizarInventario(invent, false);

                            kardex = new DTO.Clases.Kardex();
                            kardex.Codigo = invent.CodigoProducto;
                            kardex.IdUsuario = Convert.ToInt32(AppConfiguracion.ValorSeccion("id_user"));
                            kardex.IdConcepto = 21;
                            kardex.Fecha = DateTime.Now;
                            kardex.Cantidad = invent.Cantidad;
                            kardex.Valor = Convert.ToDouble(gRow.Cells["Venta"].Value);
                            kardex.Total = kardex.Valor * kardex.Cantidad;
                            this.miBussinesKardex.Insertar(kardex);
                        }
                        OptionPane.MessageInformation("Los datos se almacenaron con exito.");
                        LimpiarCampos();
                        this.txtProducto.Focus();
                    }
                }
                else
                {
                    OptionPane.MessageInformation("Debe cargar los productos de la conversión.");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private void tsbSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtProducto_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (e.KeyChar == (char)Keys.Enter)
                {
                    if (!String.IsNullOrEmpty(this.txtProducto.Text))
                    {
                        if (CodigoOrString(this.txtProducto.Text))
                        {
                            if (ExisteProducto(this.txtProducto.Text))
                            {
                                this.miError.SetError(this.txtProducto, null);
                                this.CargarProducto(this.txtProducto.Text, this.lblDataProducto);

                                //this.MiProducto = null;
                                this.txtProducto.Text = "";
                                if (this.miConversion.Id > 0)
                                {
                                    this.miError.SetError(this.panelConversion, null);
                                    this.txtCantidad.Focus();
                                    this.txtCantidad.SelectAll();
                                }
                                else
                                {
                                    this.miError.SetError(this.panelConversion, "El producto no tiene configuración de conversión.");
                                    this.txtCantidadResumen.Text = "";
                                    this.txtInventarioActual.Text = "";
                                    this.txtInvetarioNuevo.Text = "";
                                    while (this.dgvProducto.RowCount != 0)
                                    {
                                        this.dgvProducto.Rows.RemoveAt(0);
                                    }
                                }

                                //this.txtCantidad.Focus();
                                //this.txtCantidad.SelectAll();
                                //this.txtProducto.ReadOnly = true;

                                /*this.txtProductoAsoC.Text = "";
                                if (this.miConversion.Id > 0)
                                {
                                    this.miError.SetError(this.panelConversion, null);
                                    this.txtCantidad.Focus();
                                    this.txtCantidad.SelectAll();
                                }
                                else
                                {
                                    this.miError.SetError(this.panelConversion, "El producto no tiene configuración de conversión.");
                                }*/
                            }
                            else
                            {
                                this.miError.SetError(this.txtProducto, "El producto no existe");
                                this.txtProducto.Text = "";
                            }
                        }
                        else
                        {
                            this.LoadProducto = true;
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
                else
                {
                    this.miError.SetError(this.txtProducto, null);
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
                        this.miError.SetError(this.txtProducto, null);
                        if (this.miConversion.Id > 0)
                        {
                            if (!String.IsNullOrEmpty(this.txtCantidad.Text))
                            {
                                if (ValidarDouble(this.txtCantidad.Text))
                                {
                                    if (Convert.ToDouble(this.txtCantidad.Text.Replace('.', ',')) > 0)
                                    {
                                        this.miError.SetError(this.txtCantidad, null);
                                        this.txtCantidadResumen.Text = this.txtCantidad.Text;
                                        this.txtInventarioActual.Text = this.miInventario.Cantidad.ToString();
                                        this.txtInvetarioNuevo.Text =
                                            (this.miInventario.Cantidad - Convert.ToDouble(this.txtCantidad.Text.Replace('.', ','))).ToString();

                                        this.dgvProducto.DataSource =
                                            DetalleConversion(this.miConversion.Id, Convert.ToDouble(this.txtCantidad.Text.Replace('.', ',')));
                                       /* this.dgvProducto.DataSource = DetalleConversion
                                            (this.MiProducto.CodigoInternoProducto, Convert.ToDouble(this.txtCantidad.Text.Replace('.', ',')));*/

                                        this.txtCantidad.Text = "1";
                                        this.txtProducto.Focus();
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
                    }
                    else
                    {
                        this.miError.SetError(this.txtProducto, "Debe primero cargar un producto");
                    }
                }
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
        }


        private void CreateDataTable()
        {
            this.tConversion = new DataTable();
            tConversion.Columns.Add(new DataColumn("Id", typeof(int)));
            tConversion.Columns.Add(new DataColumn("Codigo", typeof(string)));
            tConversion.Columns.Add(new DataColumn("Producto", typeof(string)));
            tConversion.Columns.Add(new DataColumn("Venta", typeof(int)));
            tConversion.Columns.Add(new DataColumn("Cantidad", typeof(double)));

            this.tConversionAso = new DataTable();
            tConversionAso.Columns.Add(new DataColumn("Id", typeof(int)));
            tConversionAso.Columns.Add(new DataColumn("Codigo", typeof(string)));
            tConversionAso.Columns.Add(new DataColumn("Producto", typeof(string)));
            tConversionAso.Columns.Add(new DataColumn("Venta", typeof(int)));
            tConversionAso.Columns.Add(new DataColumn("Cantidad", typeof(double)));
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
            this.miInventario = new DTO.Clases.Inventario();
            this.miInventario.CodigoProducto = this.MiProducto.CodigoInternoProducto;
            this.miInventario.IdMedida = this.miMedida.IdValorUnidadMedida;
            this.miInventario.Cantidad = this.miBussinesInventario.CantidadInventario(this.miInventario);
            //this.miConversion = this.miBussinesConversion.Conversion(codigo);
            this.miConversion = this.miBussinesConversion.Conversion(this.MiProducto.CodigoInternoProducto);
            lbl.Text = this.MiProducto.CodigoInternoProducto + " - " + this.MiProducto.NombreProducto;

        }

        private DTO.Clases.Inventario CargarProducto(string codigo)
        {
            var medida = new ValorUnidadMedida();
            var ArrayProducto = this.miBussinesProducto.ProductoBasico(codigo);
            var producto = (DTO.Clases.Producto)ArrayProducto[0];
            if (!producto.AplicaTalla)
            {
                medida = (ValorUnidadMedida)ArrayProducto[1];
            }
            else
            {
                var tabla = this.miBussinesMedida.MedidasDeProducto(producto.CodigoInternoProducto);
                var q = (from d in tabla.AsEnumerable()
                         select d).First();
                medida.IdValorUnidadMedida = Convert.ToInt32(q["idvalor_unidad_medida"]);
                medida.DescripcionValorUnidadMedida = q["descripcionvalor_unidad_medida"].ToString();
                q = null;
            }
            var inventario = new DTO.Clases.Inventario();
            inventario.CodigoProducto = producto.CodigoInternoProducto;
            inventario.IdMedida = medida.IdValorUnidadMedida;
            inventario.Cantidad = this.miBussinesInventario.CantidadInventario(inventario);
            return inventario;
        }

        public DataTable DetalleConversion(string productoConversion, double cantidad)
        {
            var tabla = new DataTable();
            tabla.Columns.Add(new DataColumn("Codigo", typeof(string)));
            tabla.Columns.Add(new DataColumn("Producto", typeof(string)));
            tabla.Columns.Add(new DataColumn("Venta", typeof(int)));
            tabla.Columns.Add(new DataColumn("Cantidad", typeof(double)));
            tabla.Columns.Add(new DataColumn("CantidadC", typeof(double)));
            tabla.Columns.Add(new DataColumn("IdMedida", typeof(int)));
            tabla.Columns.Add(new DataColumn("Inventario", typeof(double)));
            tabla.Columns.Add(new DataColumn("InventarioNuevo", typeof(double)));
            var tDetalle = this.miBussinesConversion.DetalleConversion(productoConversion);
            foreach (DataRow dRow in tDetalle.Rows)
            {
                var tRow = tabla.NewRow();
                tRow["Codigo"] = dRow["codigo"];
                var c = dRow["codigo"].ToString();
                tRow["Producto"] = dRow["nombre"];
                tRow["Venta"] = dRow["valor"];
                tRow["Cantidad"] = dRow["cantidad"];
                tRow["CantidadC"] = Math.Round((Convert.ToDouble(tRow["Cantidad"]) * cantidad), 1);
                var invent = CargarProducto(dRow["codigo"].ToString());
                tRow["IdMedida"] = invent.IdMedida;
                tRow["Inventario"] = invent.Cantidad;
                tRow["InventarioNuevo"] =
                    Math.Round((Convert.ToDouble(tRow["Inventario"]) + (Convert.ToDouble(tRow["Cantidad"]) * cantidad)), 1);
                tabla.Rows.Add(tRow);

            }
            return tabla;
        }

        public DataTable DetalleConversion(int idConversion, double cantidad)
        {
            var tabla = new DataTable();
            tabla.Columns.Add(new DataColumn("Codigo", typeof(string)));
            tabla.Columns.Add(new DataColumn("Producto", typeof(string)));
            tabla.Columns.Add(new DataColumn("Venta", typeof(int)));
            tabla.Columns.Add(new DataColumn("Cantidad", typeof(double)));
            tabla.Columns.Add(new DataColumn("CantidadC", typeof(double)));
            tabla.Columns.Add(new DataColumn("IdMedida", typeof(int)));
            tabla.Columns.Add(new DataColumn("Inventario", typeof(double)));
            tabla.Columns.Add(new DataColumn("InventarioNuevo", typeof(double)));
            var tDetalle = this.miBussinesConversion.DetallesConversion(idConversion);
            foreach (DataRow dRow in tDetalle.Rows)
            {
                var tRow = tabla.NewRow();
                tRow["Codigo"] = dRow["codigo"];
                var c = dRow["codigo"].ToString();
                tRow["Producto"] = dRow["nombre"];
                tRow["Venta"] = dRow["valor"];
                tRow["Cantidad"] = dRow["cantidad"];
                tRow["CantidadC"] = Math.Round((Convert.ToDouble(tRow["Cantidad"]) * cantidad), 1);
                var invent = CargarProducto(dRow["codigo"].ToString());
                tRow["IdMedida"] = invent.IdMedida;
                tRow["Inventario"] = invent.Cantidad;
                tRow["InventarioNuevo"] =
                    Math.Round((Convert.ToDouble(tRow["Inventario"]) + (Convert.ToDouble(tRow["Cantidad"]) * cantidad)), 1);
                tabla.Rows.Add(tRow);

            }
            return tabla;
        }

        public void LimpiarCampos()
        {
            this.MiProducto = new DTO.Clases.Producto();
            this.miInventario = new DTO.Clases.Inventario();
            this.miConversion = new DTO.Clases.Conversion();
            this.lblDataProducto.Text = "";
            this.txtCantidadResumen.Text = "";
            this.txtInventarioActual.Text = "";
            this.txtInvetarioNuevo.Text = "";
            while (this.dgvProducto.RowCount != 0)
            {
                this.dgvProducto.Rows.RemoveAt(0);
            }
        }

        public void LimpiarCamposAso()
        {
            this.MiProducto = new DTO.Clases.Producto();
            this.miInventario = new DTO.Clases.Inventario();
            this.miConversion = new DTO.Clases.Conversion();
            this.lblDataProductoAso.Text = "";
            while (this.dgvProductoAso.RowCount != 0)
            {
                this.dgvProductoAso.Rows.RemoveAt(0);
            }
            while (this.dgvProductoDetalleAso.RowCount != 0)
            {
                this.dgvProductoDetalleAso.Rows.RemoveAt(0);
            }

            this.lblDataProductoC.Text = "";
            this.txtCantidadResumenAsoC.Text = "";
            this.txtInventarioActualC.Text = "";
            this.txtInventarioNuevoC.Text = "";
            while (this.dgvProductosC.RowCount != 0)
            {
                this.dgvProductosC.Rows.RemoveAt(0);
            }
        }

        void CompletaEventos_CompAxTInvFactProvee(CompletaTransInvFactProvee args)
        {
            try
            {
                var producto = (DTO.Clases.Producto)args.MiObjeto;
                if (this.LoadProducto)
                {
                    this.txtProducto.Text = producto.CodigoInternoProducto;
                    //this.txtProductoP_KeyPress(this.txtProducto, new KeyPressEventArgs((char)Keys.Enter));
                }
                else
                {
                    //this.txtProductoC.Text = producto.CodigoInternoProducto;
                    //this.txtProductoC_KeyPress(this.txtProductoC, new KeyPressEventArgs((char)Keys.Enter));
                }
            }
            catch { }
        }



        private void txtProductoAso_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (e.KeyChar == (char)Keys.Enter)
                {
                    if (!String.IsNullOrEmpty(this.txtProductoAso.Text))
                    {
                        if (CodigoOrString(this.txtProductoAso.Text))
                        {
                            if (ExisteProducto(this.txtProductoAso.Text))
                            {
                                this.miError.SetError(this.txtProductoAso, null);
                                CargarProducto(this.txtProductoAso.Text, this.lblDataProductoAso);
                                this.dgvProductoAso.DataSource = 
                                    this.miBussinesConversion.ConversionDetalle(this.MiProducto.CodigoInternoProducto);
                                this.dgvProductoAso_CellClick(this.dgvProductoAso, null);
                                if (this.dgvProductoAso.RowCount > 0)
                                {
                                    this.miError.SetError(this.panelProductoAso, null);
                                    this.dgvProductoAso.Focus();
                                }
                                else
                                {
                                    this.miError.SetError(this.panelProductoAso, "El producto no tiene configuración de conversión.");
                                    while (this.dgvProductoDetalleAso.RowCount != 0)
                                    {
                                        this.dgvProductoDetalleAso.Rows.RemoveAt(0);
                                    }
                                }
                                this.txtProductoAso.Text = "";
                                //this.dgvProductoAso.Focus();
                            }
                            else
                            {
                                this.miError.SetError(this.txtProductoAso, "El producto no existe");
                                this.txtProductoAso.Text = "";
                            }
                        }
                        else
                        {
                            this.LoadProducto = true;
                            var formInventario = new Inventario.Consulta.FrmConsultaInventario();
                            formInventario.MdiParent = this.MdiParent;
                            formInventario.ExtendVenta = true;
                            formInventario.IsCompra = true;
                            formInventario.txtCodigoNombre.Text = this.txtProductoAso.Text;
                            formInventario.Show();
                            formInventario.dgvInventario.Focus();
                        }
                    }
                }
                else
                {
                    this.miError.SetError(this.txtProductoAso, null);
                }
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
        }

        private void dgvProductoAso_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyData.Equals(Keys.Up) || e.KeyData.Equals(Keys.Down))
            {
                this.dgvProductoAso_CellClick(this.dgvProductoAso, null);
            }
        }

        private void dgvProductoAso_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar.Equals((char)Keys.Enter))
            {
               // this.CargarConversionAsociado();
            }
        }

        private void dgvProductoAso_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (this.dgvProductoAso.RowCount > 0)
                {
                    this.dgvProductoDetalleAso.DataSource = this.miBussinesConversion.DetallesConversion
                        (Convert.ToInt32(this.dgvProductoAso.CurrentRow.Cells["IdAso"].Value));
                }
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
        }

        private void CargarConversionAsociado()
        {
            try
            {
                if (this.dgvProductoAso.RowCount > 0)
                {
                   // OptionPane.MessageInformation(dgvProductoAso.Rows[dgvProductoAso.CurrentRow.Index].Cells["IdAso"].Value.ToString());
                    //dgvProductoAso.Rows[dgvProductoAso.CurrentRow.Index].Cells["IdAso"].Value
                    //CargarProducto(this.txtProducto.Text, this.lblDataProducto);
                    //CargarProducto(this.dgvProductoAso.CurrentRow.Cells["CodigoAso"].Value.ToString(), lblDataProductoC);

                    this.txtProductoAsoC.Text =
                        dgvProductoAso.Rows[dgvProductoAso.CurrentRow.Index].Cells["CodigoAso"].Value.ToString();
                    this.txtProductoAsoC_KeyPress(this.txtProductoAsoC, new KeyPressEventArgs((char)Keys.Enter));
                    this.txtCantidadAsoC.Focus();
                    this.txtCantidadAsoC.SelectAll();
                }
                else
                {
                    OptionPane.MessageInformation("Debe cargar una consulta de producto asociado.");
                }
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
        }


        private void txtProductoAsoC_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (e.KeyChar == (char)Keys.Enter)
                {
                    if (!String.IsNullOrEmpty(this.txtProductoAsoC.Text))
                    {
                        if (CodigoOrString(this.txtProductoAsoC.Text))
                        {
                            if (ExisteProducto(this.txtProductoAsoC.Text))
                            {

                                this.miError.SetError(this.txtProductoAsoC, null);
                                this.CargarProducto(this.txtProductoAsoC.Text, this.lblDataProductoC);
                                this.txtProductoAsoC.Text = "";
                                if (this.miConversion.Id > 0)
                                {
                                    this.miError.SetError(this.panelConversionAsoC, null);
                                    this.txtCantidadAsoC.Focus();
                                    this.txtCantidadAsoC.SelectAll();
                                }
                                else
                                {
                                    this.miError.SetError(this.panelConversionAsoC, "El producto no tiene configuración de conversión.");
                                    this.txtCantidadResumenAsoC.Text = "";
                                    this.txtInventarioActualC.Text = "";
                                    this.txtInventarioNuevoC.Text = "";
                                    while (this.dgvProductosC.RowCount != 0)
                                    {
                                        this.dgvProductosC.Rows.RemoveAt(0);
                                    }
                                }
                                //this.txtCantidadAsoC.Focus();
                                //this.txtCantidadAsoC.SelectAll();

                                /* this.dgvProductoAso.DataSource =
                                     this.miBussinesConversion.ConversionDetalle(this.MiProducto.CodigoInternoProducto);
                                 this.dgvProductoAso_CellClick(this.dgvProductoAso, null);
                                 if (this.dgvProductoAso.RowCount > 0)
                                 {
                                     this.miError.SetError(this.panelProductoAso, null);
                                 }
                                 else
                                 {
                                     this.miError.SetError(this.panelProductoAso, "El producto no tiene configuración de conversión.");
                                 }
                                 this.txtProductoAso.Text = "";
                                 this.dgvProductoAso.Focus();*/
                            }
                            else
                            {
                                this.miError.SetError(this.txtProductoAsoC, "El producto no existe");
                                this.txtProductoAsoC.Text = "";
                            }
                        }
                        else
                        {
                            this.LoadProducto = true;
                            var formInventario = new Inventario.Consulta.FrmConsultaInventario();
                            formInventario.MdiParent = this.MdiParent;
                            formInventario.ExtendVenta = true;
                            formInventario.IsCompra = true;
                            formInventario.txtCodigoNombre.Text = this.txtProductoAsoC.Text;
                            formInventario.Show();
                            formInventario.dgvInventario.Focus();
                        }
                    }
                }
                else
                {
                    this.miError.SetError(this.txtProductoAsoC, null);
                }
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }


            /* if (e.KeyChar.Equals((char)Keys.Enter))
             {
                 this.CargarProducto(this.txtProductoAsoC.Text, this.lblDataProductoC);
                 this.txtCantidadAsoC.Focus();
                 this.txtCantidadAsoC.SelectAll();
             }*/
        }

        private void txtCantidadAsoC_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (e.KeyChar == (char)Keys.Enter)
                {
                    if (this.MiProducto != null)
                    {
                        this.miError.SetError(this.txtProductoAsoC, null);
                        if (this.miConversion.Id > 0)
                        {
                            if (!String.IsNullOrEmpty(this.txtCantidadAsoC.Text))
                            {
                                if (ValidarDouble(this.txtCantidadAsoC.Text))
                                {
                                    if (Convert.ToDouble(this.txtCantidadAsoC.Text.Replace('.', ',')) > 0)
                                    {
                                        this.miError.SetError(this.txtCantidadAsoC, null);
                                        this.txtCantidadResumenAsoC.Text = this.txtCantidadAsoC.Text;
                                        this.txtInventarioActualC.Text = this.miInventario.Cantidad.ToString();
                                        this.txtInventarioNuevoC.Text =
                                            (this.miInventario.Cantidad - Convert.ToDouble(this.txtCantidadAsoC.Text.Replace('.', ','))).ToString();
                                        
                                        /*this.dgvProductosC.DataSource = DetalleConversion
                                            (this.MiProducto.CodigoInternoProducto, Convert.ToDouble(this.txtCantidadAsoC.Text.Replace('.', ',')));*/
                                        this.dgvProductosC.DataSource = 
                                            DetalleConversion(this.miConversion.Id, Convert.ToDouble(this.txtCantidadAsoC.Text.Replace('.', ',')));
                                        this.txtCantidadAsoC.Text = "1";
                                        this.dgvProductoAso.Focus();

                                        /*this.dgvProducto.DataSource = DetalleConversion
                                            (this.MiProducto.CodigoInternoProducto, Convert.ToDouble(this.txtCantidad.Text.Replace('.', ',')));
                                        this.txtCantidad.Text = "";
                                        this.txtProducto.Focus();*/
                                    }
                                    else
                                    {
                                        this.miError.SetError(this.txtCantidadAsoC, "La cantidad debe ser mayor a cero");
                                    }
                                }
                                else
                                {
                                    this.miError.SetError(this.txtCantidadAsoC, "La cantidad tiene formato incorrecto");
                                }
                            }
                            else
                            {
                                this.miError.SetError(this.txtCantidadAsoC, "La cantidad no debe ser vacia");
                            }
                        }
                    }
                    else
                    {
                        this.miError.SetError(this.txtProductoAsoC, "Debe primero cargar un producto");
                    }
                }
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
        }

        private void tsBtnGuardarAso_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.dgvProductosC.RowCount > 0)
                {
                    DialogResult rta_ = MessageBox.Show("¿Esta seguro(a) de guardar los cambios?", "Conversión",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (rta_.Equals(DialogResult.Yes))
                    {
                        this.miInventario.Cantidad = Convert.ToDouble(this.txtCantidadResumenAsoC.Text.Replace('.', ','));
                        this.miBussinesInventario.ActualizarInventario(this.miInventario, true);

                        var kardex = new DTO.Clases.Kardex();
                        kardex.Codigo = this.miInventario.CodigoProducto;
                        kardex.IdUsuario = Convert.ToInt32(AppConfiguracion.ValorSeccion("id_user"));
                        kardex.IdConcepto = 20;
                        kardex.Fecha = DateTime.Now;
                        kardex.Cantidad = this.miInventario.Cantidad;
                        kardex.Valor = this.MiProducto.ValorVentaProducto;
                        kardex.Total = kardex.Valor * kardex.Cantidad;
                        this.miBussinesKardex.Insertar(kardex);

                        foreach (DataGridViewRow gRow in this.dgvProductosC.Rows)
                        {
                            var invent = new DTO.Clases.Inventario();
                            invent.CodigoProducto = gRow.Cells["CodigoC"].Value.ToString();
                            invent.IdMedida = Convert.ToInt32(gRow.Cells["IdMedidaAso"].Value);
                            invent.Cantidad = Convert.ToDouble(gRow.Cells["CantidadAsoCo"].Value);
                            this.miBussinesInventario.ActualizarInventario(invent, false);

                            kardex = new DTO.Clases.Kardex();
                            kardex.Codigo = invent.CodigoProducto;
                            kardex.IdUsuario = Convert.ToInt32(AppConfiguracion.ValorSeccion("id_user"));
                            kardex.IdConcepto = 21;
                            kardex.Fecha = DateTime.Now;
                            kardex.Cantidad = invent.Cantidad;
                            kardex.Valor = Convert.ToDouble(gRow.Cells["VentaC"].Value);
                            kardex.Total = kardex.Valor * kardex.Cantidad;
                            this.miBussinesKardex.Insertar(kardex);
                        }
                        OptionPane.MessageInformation("Los datos se almacenaron con exito.");
                        this.LimpiarCamposAso();
                        this.txtProductoAso.Focus();
                    }
                }
                else
                {
                    OptionPane.MessageInformation("Debe cargar los productos de la conversión.");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private void dgvProductoAso_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                //this.CargarDatos();
                this.CargarConversionAsociado();
            }
        }

        private void tabControlConversion_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.tabControlConversion.SelectedIndex == 0)
            {
                this.txtProducto.Focus();
            }
            else
            {
                this.txtProductoAso.Focus();
            }
        }

        private void tsBtnSalirAso_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        
    }
}