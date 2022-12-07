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
using Aplicacion.Compras.IngresarCompra;

namespace Aplicacion.Compras.PreIngreso
{
    public partial class FrmAgregarProductoCompra : Form
    {
        public int ID { set; get; }

        private ErrorProvider miError;

        private bool CantidadMatch;

        private bool CostoMatch;

        private bool CostoIvaMatch;

        private bool D1Match;

        private bool D2Match;

        private Producto producto;

        private ValorUnidadMedida miMedida;

        private TallaYcolor miTallaYcolor;

        private bool SingleSize;

        private bool SingleColor;



        private BussinesProducto miBussinesProducto;

        private BussinesValorUnidadMedida miBussinesMedida;

        private BussinesColor miBussinesColor;

        private BussinesFacturaProveedor miBussinesCompra;


        private int IdTipoInventarioProductoNoFabricado = 3;

        private int IdTipoInventarioProductoFabricado = 4;


        public FrmAgregarProductoCompra()
        {
            InitializeComponent();

            this.CantidadMatch = false;
            this.CostoMatch = false;
            this.CostoIvaMatch = false;
            this.D1Match = false;
            this.D2Match = false;

            this.miError = new ErrorProvider();
            this.miTallaYcolor = new TallaYcolor();
            this.SingleSize = false;
            this.SingleColor = false;

            this.miBussinesProducto = new BussinesProducto();
            this.miBussinesMedida = new BussinesValorUnidadMedida();
            this.miBussinesColor = new BussinesColor();
            this.miBussinesCompra = new BussinesFacturaProveedor();
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

        private void FrmAgregarProductoCompra_FormClosing(object sender, FormClosingEventArgs e)
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
                            else
                            {
                                this.txtCantidad.Focus();
                            }
                        }
                        else
                        {
                            this.miError.SetError(this.txtCodigoArticulo, "El articulo no existe.");
                            this.txtCodigoArticulo.Focus();
                        }
                    }
                    else
                    {
                        var formInventario = new Inventario.Consulta.FrmConsultaInventario();
                        formInventario.MdiParent = this.MdiParent;
                        formInventario.ExtendVenta = true;
                        formInventario.IsCompra = true;

                        formInventario.IdTipoInventarioNoFabricado = IdTipoInventarioProductoNoFabricado;
                        formInventario.IdTipoInventarioFabricado = IdTipoInventarioProductoFabricado;

                        formInventario.txtCodigoNombre.Text = this.txtCodigoArticulo.Text;
                        formInventario.Show();
                        formInventario.dgvInventario.Focus();
                    }
                }
            }
        }

        private void txtCantidad_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                this.txtCostoBase.Focus();
                //this.btnOk_Click(this.btnOk, new EventArgs());
            }
        }

        private void txtCantidad_Validating(object sender, CancelEventArgs e)
        {
            if (!String.IsNullOrEmpty(this.txtCantidad.Text))
            {
                if (ValidarDecimal(this.txtCantidad.Text))
                {
                    this.miError.SetError(this.txtCantidad, null);
                    this.CantidadMatch = true;
                }
                else
                {
                    this.miError.SetError(this.txtCantidad, "El valor es incorrecto.");
                    this.CantidadMatch = false;
                }
            }
            else
            {
                this.miError.SetError(this.txtCantidad, "El campo es requerido.");
                this.CantidadMatch = false;
            }
        }

        private void txtCostoBase_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                if (!String.IsNullOrEmpty(this.txtCostoBase.Text))
                {
                    if (ValidarDecimal(this.txtCostoBase.Text))
                    {
                        this.miError.SetError(this.txtCostoBase, null);
                        this.CostoMatch = true;

                        this.txtCostoMasIva.Text = Math.Round((Convert.ToDouble(this.txtCostoBase.Text.Replace('.', ',')) +
                        (Convert.ToDouble(this.txtCostoBase.Text.Replace('.', ',')) * this.producto.ValorIva / 100)), 2).ToString().Replace(',', '.');

                        /*
                        this.txtCostoMasIva.Text = Math.Round(Convert.ToDouble(txtCostoBase.Text.Replace(',', '.')) +
                            (Convert.ToDouble(txtCostoBase.Text.Replace(',', '.')) * this.producto.ValorIva / 100), 0).ToString();*/

                        this.txtCostoMasIva.Focus();
                    }
                    else
                    {
                        this.miError.SetError(this.txtCostoBase, "El valor es incorrecto.");
                        this.CostoMatch = false;
                    }
                }
                else
                {
                    this.miError.SetError(this.txtCostoBase, "El campo es requerido.");
                    this.CostoMatch = false;
                }
            }
        }

        private void txtCostoMasIva_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                if (!String.IsNullOrEmpty(this.txtCostoMasIva.Text))
                {
                    if (ValidarDecimal(this.txtCostoMasIva.Text))
                    {
                        this.miError.SetError(this.txtCostoMasIva, null);
                        this.CostoIvaMatch = true;

                        this.txtCostoBase.Text = Math.Round(
                            (Convert.ToDouble(this.txtCostoMasIva.Text.Replace('.', ',')) / (1 + (this.producto.ValorIva / 100))), 2).
                             ToString().Replace(',', '.');

                        this.txtDescuento1.Focus();
                    }
                    else
                    {
                        this.miError.SetError(this.txtCostoMasIva, "El valor es incorrecto.");
                        this.CostoIvaMatch = false;
                    }
                }
                else
                {
                    this.miError.SetError(this.txtCostoMasIva, "El campo es requerido.");
                    this.CostoIvaMatch = false;
                }
            }
        }

        private void txtDescuento1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                if (!String.IsNullOrEmpty(this.txtDescuento1.Text))
                {
                    if (ValidarDecimal(this.txtDescuento1.Text))
                    {
                        this.miError.SetError(this.txtDescuento1, null);
                        this.D1Match = true;
                        this.txtDescuento2.Focus();
                    }
                    else
                    {
                        this.miError.SetError(this.txtDescuento1, "El valor es incorrecto.");
                        this.D1Match = false;
                    }
                }
                else
                {
                    this.txtDescuento1.Text = "0";
                    this.D1Match = false;
                }
            }
        }

        private void txtDescuento2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                if (!String.IsNullOrEmpty(this.txtDescuento2.Text))
                {
                    if (ValidarDecimal(this.txtDescuento2.Text))
                    {
                        this.miError.SetError(this.txtDescuento2, null);
                        this.D2Match = true;
                        this.btnOk_Click(this.btnOk, new EventArgs());
                    }
                    else
                    {
                        this.miError.SetError(this.txtDescuento2, "El valor es incorrecto.");
                        this.D2Match = false;
                    }
                }
                else
                {
                    this.txtDescuento2.Text = "0";
                    this.D2Match = false;
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
                this.txtCantidad_Validating(this.txtCantidad, new CancelEventArgs(false));
                if (this.producto != null)
                {
                    this.miError.SetError(this.txtCodigoArticulo, null);
                    if (CantidadMatch && CostoMatch && CostoIvaMatch && D1Match && D2Match)
                    {
                        this.miBussinesCompra.IngresarProductoTemporal(
                            new ProductoFacturaProveedor
                            {
                                IdFactura = this.ID, 
                                Producto = new Producto
                                {
                                    CodigoInternoProducto = producto.CodigoInternoProducto,
                                    ValorCosto = Convert.ToDouble(txtCostoBase.Text.Replace('.', ',')),
                                    ValorIva = producto.ValorIva,
                                    Descuento = Convert.ToDouble(txtDescuento1.Text.Replace('.', ',')),
                                    DescuentoMayor = Convert.ToDouble(txtDescuento2.Text.Replace('.', ','))
                                },
                                Inventario = new DTO.Clases.Inventario
                                {
                                    IdMedida = this.producto.IdMedida,
                                    IdColor = this.producto.IdColor
                                },
                                //row["Lote"] = this.Producto.CodigoInternoProducto + "-" + CambiarSeparadorFecha(DateTime.Now.ToShortDateString());
                                Lote = new Lote
                                {
                                    CodigoProducto = this.producto.CodigoInternoProducto,
                                    Numero = this.producto.CodigoInternoProducto + "-" + CambiarSeparadorFecha(DateTime.Now.ToShortDateString()),
                                    Fecha = DateTime.Now
                                },
                                Cantidad = Convert.ToDouble(txtCantidad.Text.Replace('.', ','))
                            });
                        CompletaEventos.CapturaEvento(new ObjectAbstract { Id = 19888 });

                        this.txtCodigoArticulo.Focus();
                        this.producto = null;
                        this.lblDatosProducto.Text = "";
                        this.txtCantidad.Text = "";
                        this.txtCostoBase.Text = "";
                        this.txtCostoMasIva.Text = "";
                        this.txtDescuento1.Text = "0";
                        this.txtDescuento2.Text = "0";
                        


                        /**
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
                        this.producto.Cantidad = Convert.ToDouble(this.txtCantidad.Text);
                        CompletaEventos.CapturaEvento(new ObjectAbstract { Id = 19888, Objeto = this.producto });
                        this.Close();
                        */
                    }
                }
                else
                {
                    this.miError.SetError(this.txtCodigoArticulo, "Debe cargar un articulo.");
                }
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
                this.txtCostoBase.Text = this.producto.ValorCosto.ToString();
                this.txtCostoMasIva.Text = Math.Round(this.producto.ValorCosto + (this.producto.ValorCosto * this.producto.ValorIva / 100), 0).ToString();

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

        private bool ValidarDecimal(string numero)
        {
            try
            {
                Convert.ToDouble(numero);
                return true;
            }
            catch (FormatException)
            {
                return false;
            }
        }

        private string CambiarSeparadorFecha(string fecha)
        {
            var miFecha = fecha.Split('/');
            string fechaResult = miFecha[0] + miFecha[1] + miFecha[2];
            return fechaResult;
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