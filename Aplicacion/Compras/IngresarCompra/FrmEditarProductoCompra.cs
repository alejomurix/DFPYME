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

namespace Aplicacion.Compras.IngresarCompra
{
    public partial class FrmEditarProductoCompra : Form
    {
        private ErrorProvider miError;

        private Producto producto;

        private ValorUnidadMedida miMedida;

        private TallaYcolor miTallaYcolor;

        private bool SingleSize;

        private bool SingleColor;



        private BussinesProducto miBussinesProducto;

        private BussinesValorUnidadMedida miBussinesMedida;

        private BussinesColor miBussinesColor;



        public FrmEditarProductoCompra()
        {
            InitializeComponent();
            this.miError = new ErrorProvider();
            this.miTallaYcolor = new TallaYcolor();
            this.SingleSize = false;
            this.SingleColor = false;

            this.miBussinesProducto = new BussinesProducto();
            this.miBussinesMedida = new BussinesValorUnidadMedida();
            this.miBussinesColor = new BussinesColor();
        }

        private void FrmEditarProductoCompra_Load(object sender, EventArgs e)
        {
            CompletaEventos.CompAxTInvFactProvee += new CompletaEventos.ComAxTransferInvFactProve(CompletaEventos_CompAxTInvFactProvee);
        }

        private void FrmEditarProductoCompra_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData.Equals(Keys.Escape))
            {
                this.Close();
            }
        }

        private void FrmEditarProductoCompra_FormClosing(object sender, FormClosingEventArgs e)
        {
            CompletaEventos.CapturaEvento(false);
        }

        private void txtCodigoArticulo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                if (!String.IsNullOrEmpty(this.txtCodigoArticulo.Text))
                {
                    if (CodigoOrString(this.txtCodigoArticulo.Text))
                    {
                        if (ExisteProducto(this.txtCodigoArticulo.Text))
                        {
                            CargarProducto(this.txtCodigoArticulo.Text);
                            this.txtCodigoArticulo.Text = "";
                            this.miError.SetError(this.txtCodigoArticulo, null);
                            if (this.btnTallaYcolor.Enabled)
                            {
                                this.btnTallaYcolor.Focus();
                            }
                        }
                        else
                        {
                            this.miError.SetError(this.txtCodigoArticulo, "");
                            this.txtCodigoArticulo.Focus();
                        }
                    }
                    else
                    {
                        var formInventario = new Inventario.Consulta.FrmConsultaInventario();
                        formInventario.MdiParent = this.MdiParent;
                        formInventario.ExtendVenta = true;
                        formInventario.IsCompra = true;
                        formInventario.txtCodigoNombre.Text = this.txtCodigoArticulo.Text;
                        formInventario.Show();
                        formInventario.dgvInventario.Focus();
                    }
                }
            }
        }

        private void btnTallaYcolor_Click(object sender, EventArgs e)
        {

        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            try
            {
                this.producto.ValorCosto = this.miBussinesProducto.PrecioDeCosto(this.producto.CodigoInternoProducto);
                //double iva = Math.Round((this.producto.ValorCosto * producto.ValorIva / 100), 2);
                //this.producto.ValorCosto = Convert.ToInt32(this.producto.ValorCosto + iva);
                if (this.SingleSize)
                {
                    this.producto.IdMedida = this.miMedida.IdValorUnidadMedida;
                }
                else
                {
                    this.producto.IdMedida = this.miTallaYcolor.IdTalla;
                }
                if (this.SingleColor)
                {
                    this.producto.IdColor = 0;
                }
                else
                {
                    this.producto.IdColor = this.miTallaYcolor.IdColor;
                }
                CompletaEventos.CapturaEvento(new ObjectAbstract { Id = 19888, Objeto = this.producto });
                this.Close();
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
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

        private void CargarProducto(string codigo)
        {
            try
            {
                var ArrayProducto = miBussinesProducto.ProductoBasico(codigo);
                this.producto = (DTO.Clases.Producto)ArrayProducto[0];
                var tabla = this.miBussinesMedida.MedidasDeProducto(this.producto.CodigoInternoProducto);
                if (!this.producto.AplicaTalla)
                {
                    this.miMedida = (ValorUnidadMedida)ArrayProducto[1];
                    this.SingleSize = true;
                }
                else
                {
                    if (tabla.Rows.Count == 1)
                    {
                        var q = (from d in tabla.AsEnumerable()
                                 select d).Single();
                        this.miTallaYcolor.IdTalla = Convert.ToInt32(q["idvalor_unidad_medida"]);
                        this.miTallaYcolor.Talla = q["descripcionvalor_unidad_medida"].ToString();
                        q = null;
                        this.SingleSize = true;
                    }
                    else
                    {
                        this.SingleSize = false;
                    }
                }
                if (this.producto.AplicaColor)
                {
                    if (tabla.Rows.Count == 1)
                    {
                        var q = (from d in tabla.AsEnumerable()
                                 select d).Single();
                        var tablaColor = this.miBussinesColor.ColoresDeProducto
                            (this.producto.CodigoInternoProducto, Convert.ToInt32(q["idvalor_unidad_medida"]));
                        if (tablaColor.Rows.Count.Equals(1))
                        {
                            var c = (from d in tablaColor.AsEnumerable()
                                     select d).Single();
                            this.miTallaYcolor.IdColor = Convert.ToInt32(c["idcolor"]);
                            this.miTallaYcolor.Color = (Image)c["ImagenBit"];
                            this.SingleColor = true;
                        }
                        else
                        {
                            this.SingleColor = false;
                        }
                    }
                    else
                    {
                        this.SingleColor = false;
                    }
                }
                else
                {
                    this.SingleColor = true;
                }
                this.lblDatosProducto.Text = this.producto.CodigoInternoProducto + " - " + this.producto.NombreProducto;
                if (!this.SingleSize || !this.SingleColor)
                {
                    this.btnTallaYcolor.Enabled = true;
                }
                else
                {
                    this.btnTallaYcolor.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
        }

        void CompletaEventos_CompAxTInvFactProvee(CompletaTransInvFactProvee args)
        {
            try
            {
                var producto = (DTO.Clases.Producto)args.MiObjeto;
                txtCodigoArticulo.Text = producto.CodigoInternoProducto;
                txtCodigoArticulo_KeyPress(this.txtCodigoArticulo, new KeyPressEventArgs((char)Keys.Enter));
            }
            catch { }
        }
    }
}