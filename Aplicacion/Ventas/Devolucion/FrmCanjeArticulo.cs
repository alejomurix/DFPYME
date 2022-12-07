using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CustomControl;
using BussinesLayer.Clases;
using DTO.Clases;
using Utilities;

namespace Aplicacion.Ventas.Devolucion
{
    public partial class FrmCanjeArticulo : Form
    {
        private bool Transfer { set; get; }

        private bool SearchTallaColor { set; get; }

        private Producto MiProducto { set; get; }

        private Compras.IngresarCompra.TallaYcolor tallaColor { set; get; }

        private ErrorProvider miError;

        private bool CantidadMatch { set; get; }

        private bool PrecioMatch { set; get; }

        private int IdTipoInventarioProductoNoFabricado = 1;

        private int IdTipoInventarioProductoFabricado = 3;

        private BussinesProducto miBussinesProducto;

        private BussinesValorUnidadMedida miBussinesMedida;

        private BussinesColor miBussinesColor;

        private BussinesConsecutivo miBussinesConsecutivo;

        private BussinesDevolucion miBussinesDevolucion;

        public FrmCanjeArticulo()
        {
            InitializeComponent();
            this.Transfer = false;
            this.SearchTallaColor = false;
            this.tallaColor = new Compras.IngresarCompra.TallaYcolor();
            this.miError = new ErrorProvider();
            this.CantidadMatch = false;
            this.PrecioMatch = false;
            miBussinesProducto = new BussinesProducto();
            miBussinesMedida = new BussinesValorUnidadMedida();
            miBussinesColor = new BussinesColor();
            miBussinesConsecutivo = new BussinesConsecutivo();
            miBussinesDevolucion = new BussinesDevolucion();
        }

        private void FrmCanjeArticulo_Load(object sender, EventArgs e)
        {
            CompletaEventos.CompTProductoFact += new CompletaEventos.ComAxTransferProductFact(CompletaEventos_CompTProductoFact);
        }

        private void FrmCanjeArticulo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData.Equals(Keys.F2))
            {
                this.tsBtnGuardar_Click(this.tsBtnGuardar, new EventArgs());
            }
            else
            {
                if (e.KeyData.Equals(Keys.F3))
                {
                    this.tsConsultarProducto_Click(this.tsConsultarProducto, new EventArgs());
                }
                else
                {
                    if (e.KeyData.Equals(Keys.Escape))
                    {
                        this.Close();
                    }
                }
            }
        }

        private void tsBtnGuardar_Click(object sender, EventArgs e)
        {
            if (MiProducto != null)
            {
                DialogResult rta = MessageBox.Show("¿Esta seguro(a) de realizar la devolución?", "Devolución venta",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (rta.Equals(DialogResult.Yes))
                {
                    try
                    {
                        this.txtCantidad_Validating(this.txtCantidad, null);
                        this.txtPrecio_Validating(this.txtPrecio, null);
                        if (this.CantidadMatch && this.PrecioMatch)
                        {
                            var devolucion = new FacturaProveedor();
                            devolucion.Numero = miBussinesConsecutivo.Consecutivo("DevolucionVenta");
                            devolucion.Proveedor.NitProveedor = "1000";
                            devolucion.FechaIngreso = DateTime.Now;
                            devolucion.Usuario.Id = Convert.ToInt32(AppConfiguracion.ValorSeccion("id_user"));
                            devolucion.Caja.Id = Convert.ToInt32(AppConfiguracion.ValorSeccion("id_caja"));
                            devolucion.Turno.Id = Convert.ToInt32(AppConfiguracion.ValorSeccion("idturno"));

                            var detalle = new ProductoFacturaProveedor();
                            detalle.Inventario.CodigoProducto = this.MiProducto.CodigoInternoProducto;
                            detalle.Inventario.IdMedida = this.tallaColor.IdTalla;
                            detalle.Inventario.IdColor = tallaColor.IdColor;
                            detalle.Producto.Impoconsumo = this.MiProducto.Impoconsumo;
                            detalle.Producto.ValorCosto = Convert.ToInt32(this.txtPrecio.Text) - Convert.ToInt32(this.MiProducto.Impoconsumo);
                            detalle.Producto.ValorVentaProducto = Convert.ToInt32(this.txtPrecio.Text);
                            //detalle.Producto.ValorCosto = Convert.ToInt32(this.MiProducto.ValorVentaProducto / (1 + (this.MiProducto.ValorIva / 100)));
                            detalle.Producto.ValorCosto = Math.Round((detalle.Producto.ValorCosto / (1 + (this.MiProducto.ValorIva / 100))), 1);
                            detalle.Producto.ValorIva = this.MiProducto.ValorIva;
                            detalle.Producto.IdTipoInventario = MiProducto.IdTipoInventario;
                            
                            detalle.Inventario.Cantidad = Convert.ToDouble(this.txtCantidad.Text.Replace('.', ','));

                            devolucion.Productos.Add(detalle);
                            devolucion.DevolucionEfectivo = Convert.ToInt32(detalle.Producto.ValorVentaProducto * detalle.Inventario.Cantidad);
                            miBussinesDevolucion.IngresarVenta(devolucion);
                            OptionPane.MessageInformation("El canje se realizó correctamente.");

                            this.txtCodigoArticulo.Focus();
                            this.MiProducto = null;
                            this.tallaColor = new Compras.IngresarCompra.TallaYcolor();
                            this.CantidadMatch = false;
                            this.PrecioMatch = false;
                            this.SearchTallaColor = false;
                            this.txtCantidad.Text = "1";
                            this.txtPrecio.Text = "";
                            this.lblDatosProducto.Text = "";
                            this.lblTotal.Text = "";
                        }
                    }
                    catch (Exception ex)
                    {
                        OptionPane.MessageError(ex.Message);
                    }
                }
            }
        }

        private void tsConsultarProducto_Click(object sender, EventArgs e)
        {
            this.Transfer = true;
            var formInventario = new Inventario.Consulta.FrmConsultaInventario();
            // formInventario.MdiParent = this.MdiParent;
            formInventario.ExtendVenta = true;
            formInventario.txtCodigoNombre.Text = txtCodigoArticulo.Text;
            formInventario.ShowDialog();
            formInventario.dgvInventario.Focus();
            formInventario.ColorearGrid();
        }

        private void tsBtnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void txtCodigoArticulo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar.Equals((char)Keys.Enter))
            {
                this.txtCantidad_Validating(this.txtCantidad, new CancelEventArgs(false));
                if (!String.IsNullOrEmpty(this.txtCodigoArticulo.Text))
                {
                    if (CodigoOrString())
                    {
                        if (ExisteProducto(this.txtCodigoArticulo.Text))
                        {
                            if (this.CantidadMatch)
                            {
                                if (CargarProducto(this.txtCodigoArticulo.Text))
                                {
                                    if (this.SearchTallaColor)
                                    {
                                        CargarTallaColor();
                                    }
                                    this.txtCantidad.Focus();
                                }
                            }
                        }
                        else
                        {
                            OptionPane.MessageInformation("El producto no se encuentra registrado.");
                        }
                    }
                    else
                    {
                        this.Transfer = true;
                        var formInventario = new Inventario.Consulta.FrmConsultaInventario();
                        // formInventario.MdiParent = this.MdiParent;
                        formInventario.ExtendVenta = true;
                        formInventario.txtCodigoNombre.Text = txtCodigoArticulo.Text;
                        formInventario.ShowDialog();
                        formInventario.dgvInventario.Focus();
                        formInventario.ColorearGrid();
                    }
                }
            }
        }


        private void txtCantidad_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar.Equals((char)Keys.Enter))
            {
                this.txtPrecio.Focus();
            }
        }

        private void txtCantidad_Validating(object sender, CancelEventArgs e)
        {
            if (String.IsNullOrEmpty(this.txtCantidad.Text))
            {
                this.txtCantidad.Text = "1";
                this.CantidadMatch = true;
            }
            else
            {
                if (ValidarDecimal(this.txtCantidad.Text))
                    /*(Validacion.ConFormato
                    (Validacion.TipoValidacion.NumerosYPunto, this.txtCodigoArticulo, this.miError, "El valor es incorrecto"))*/
                {
                    if (Convert.ToDouble(this.txtCantidad.Text.Replace('.', ',')) <= 0)
                    {
                        this.miError.SetError(this.txtCantidad, "El valor debe ser superior a cero.");
                        this.CantidadMatch = false;
                    }
                    else
                    {
                        this.miError.SetError(this.txtCantidad, null);
                        this.CantidadMatch = true;
                    }
                    //this.CantidadMatch = true;
                }
                else
                {
                    this.miError.SetError(this.txtCantidad, "El valor es incorrecto");
                    this.CantidadMatch = false;
                }
            }
        }

        private void txtPrecio_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar.Equals((char)Keys.Enter))
            {
                this.tsBtnGuardar_Click(this.tsBtnGuardar, new EventArgs());
            }
        }

        private void txtPrecio_Validating(object sender, CancelEventArgs e)
        {
            if (!String.IsNullOrEmpty(this.txtPrecio.Text))
            {
                if (ValidarEntero(this.txtPrecio.Text))
                {
                    if (Convert.ToInt32(this.txtPrecio.Text) > 0)
                    {
                        this.miError.SetError(this.txtPrecio, null);
                        this.PrecioMatch = true;
                    }
                    else
                    {
                        this.miError.SetError(this.txtPrecio, "El valor debe ser superior a cero.");
                        this.PrecioMatch = false;
                    }
                }
                else
                {
                    this.miError.SetError(this.txtPrecio, "El valor es incorrecto.");
                    this.PrecioMatch = false;
                }
            }
            else
            {
                this.miError.SetError(this.txtPrecio, "El campo es requerido.");
                this.PrecioMatch = false;
            }
        }

        private bool ValidarDecimal(string numero)
        {
            try
            {
                Convert.ToDouble(numero.Replace('.', ','));
                return true;
            }
            catch (FormatException)
            {
                return false;
            }
        }

        private bool ValidarEntero(string numero)
        {
            try
            {
                Convert.ToInt64(numero);
                return true;
            }
            catch (FormatException)
            {
                return false;
            }
        }

        private bool CodigoOrString()
        {
            var num = true;
            try
            {
                Convert.ToInt64(txtCodigoArticulo.Text);
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

        private bool ExisteProducto(string codigo)
        {
            try
            {
                var barras = miBussinesProducto.ExisteCodigoBarras(codigo);
                var code = miBussinesProducto.ExisteCodigo(codigo);
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

        private bool CargarProducto(string producto)
        {
            //var resultado = false;
            //var idMedidaTemp = 0;
            var singleSize = false;
            var singleColor = false;
            try
            {
                var arrProducto = miBussinesProducto.ProductoBasico(producto);
                MiProducto = (Producto)arrProducto[0];
                if (MiProducto.IdTipoInventario.Equals(IdTipoInventarioProductoNoFabricado) ||
                    MiProducto.IdTipoInventario.Equals(IdTipoInventarioProductoFabricado))
                {
                    var tabla = miBussinesMedida.MedidasDeProducto(MiProducto.CodigoInternoProducto);
                    if (!MiProducto.AplicaTalla)  //No aplica talla.
                    {
                        this.tallaColor.IdTalla = ((ValorUnidadMedida)arrProducto[1]).IdValorUnidadMedida;
                        singleSize = true;
                    }
                    else  //Si aplica talla.
                    {
                        if (tabla.Rows.Count == 1)
                        {
                            var qRow = (from data in tabla.AsEnumerable()
                                        select data).Single();
                            this.tallaColor.IdTalla = Convert.ToInt32(qRow["idvalor_unidad_medida"]);
                            qRow = null;
                            singleSize = true;
                        }
                        else
                        {
                            singleSize = false;
                        }
                    }
                    if (MiProducto.AplicaColor)
                    {
                        if (tabla.Rows.Count == 1)
                        {
                            var tablaColor = miBussinesColor.ColoresDeProducto
                                (MiProducto.CodigoInternoProducto, this.tallaColor.IdTalla);
                            if (tablaColor.Rows.Count == 1)
                            {
                                var cRow = (from data in tablaColor.AsEnumerable()
                                            select data).Single();
                                this.tallaColor.IdColor = Convert.ToInt32(cRow["idcolor"]);
                                singleColor = true;
                            }
                            else
                            {
                                singleColor = false;
                            }
                        }
                        else
                        {
                            singleColor = false;
                        }
                    }
                    else
                    {
                        singleColor = true;
                    }
                    this.txtPrecio.Text = MiProducto.ValorVentaProducto.ToString();
                    this.lblDatosProducto.Text = MiProducto.CodigoInternoProducto + "  -  " + MiProducto.NombreProducto;
                    this.lblTotal.Text = "$ " + UseObject.InsertSeparatorMil((MiProducto.ValorVentaProducto *
                        Convert.ToDouble(this.txtCantidad.Text.Replace('.', ','))).ToString());
                    if (!singleSize || !singleColor)
                    {
                        this.SearchTallaColor = true;
                    }
                    else
                    {
                        this.SearchTallaColor = false;
                    }
                    this.txtCodigoArticulo.Text = "";
                    return true;
                }
                else
                {
                    OptionPane.MessageInformation("Este producto no se puede devolver.");
                    return false;
                }
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
                return false;
            }
        }

        private void CargarTallaColor()
        {
            var frmTallaColor = new Compras.IngresarCompra.frmMedidaColor();
            frmTallaColor.AplicaTalla = this.MiProducto.AplicaTalla;
            frmTallaColor.AplicaColor = this.MiProducto.AplicaColor;
            frmTallaColor.CodigoProducto = this.MiProducto.CodigoInternoProducto;
            if (this.MiProducto.AplicaColor && !this.MiProducto.AplicaTalla)
            {
                frmTallaColor.IdMedida_ = this.tallaColor.IdTalla;
            }
            if (this.MiProducto.AplicaColor)
            {
                frmTallaColor.ShowDialog();
            }
            else
            {
                if (this.MiProducto.AplicaTalla)
                {
                    frmTallaColor.AplicaColor = false;
                    frmTallaColor.ShowDialog();
                }
            }
        }

        void CompletaEventos_CompTProductoFact(CompletaTransferProductFact args)
        {
            try
            {
                var producto = (Producto)args.MiObjeto;
                txtCodigoArticulo.Text = producto.CodigoInternoProducto;
                txtCodigoArticulo_KeyPress(this.txtCodigoArticulo, new KeyPressEventArgs((char)Keys.Enter));
            }
            catch { }
        }

    }
}