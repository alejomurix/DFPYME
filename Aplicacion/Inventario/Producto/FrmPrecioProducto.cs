using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Utilities;
using CustomControl;
using BussinesLayer.Clases;
using DTO.Clases;

namespace Aplicacion.Inventario.Producto
{
    public partial class FrmPrecioProducto : Form
    {
        private ErrorProvider MiError;

        private bool FormInventario = false;

        private BussinesProducto miBussinesProducto;

        private BussinesValorUnidadMedida miBussinesMedida;

        private BussinesFacturaProveedor miBussinesFacturaProveedor;

        private BussinesColor miBussinesColor;

        private DTO.Clases.Producto MiProducto;

        private ValorUnidadMedida miMedida;

        private Compras.IngresarCompra.TallaYcolor miTallaYcolor;

        Validacion validacion;

        private bool UtilidadMatch = false;

        private bool PrecioMatch = false;

        public FrmPrecioProducto()
        {
            InitializeComponent();
            MiError = new ErrorProvider();
            miBussinesProducto = new BussinesProducto();
            miBussinesMedida = new BussinesValorUnidadMedida();
            miBussinesColor = new BussinesColor();
            miBussinesFacturaProveedor = new BussinesFacturaProveedor();
            validacion = new Validacion();
        }

        private void FrmPrecioProducto_Load(object sender, EventArgs e)
        {
            CompletaEventos.CompAxTInvFactProvee +=
                new CompletaEventos.ComAxTransferInvFactProve(CompletaEventos_CompAxTInvFactProvee);
            
        }

        private void txtCodigoArticulo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                if (CodigoOrString())
                {
                    if (ValidarCodigo() || ValidarCodigoBarras())
                    {
                        if (ExisteProducto(txtCodigoArticulo.Text))
                        {
                            CargarProducto(txtCodigoArticulo.Text);
                            if (!btnTallaYcolor.Enabled)
                            {
                                CargarInformacion();
                                txtCodigoArticulo.Text = "";
                            }
                        }
                    }
                }
                else
                {
                    if (!FormInventario)
                    {
                        var formInventario = new Inventario.Consulta.FrmConsultaInventario();
                        formInventario.MdiParent = this.MdiParent;
                        formInventario.ExtendVenta = true;
                        formInventario.IsCompra = true;
                        formInventario.txtCodigoNombre.Text = txtCodigoArticulo.Text;
                        FormInventario = true;
                        formInventario.Show();
                        formInventario.dgvInventario.Focus();
                    }
                }
            }
        }

        private void btnTallaYcolor_Click(object sender, EventArgs e)
        {
            if (MiProducto != null)
            {
                if (MiProducto.AplicaTalla || MiProducto.AplicaColor)
                {
                    var FrmTallaColor = new Compras.IngresarCompra.frmMedidaColor();
                    FrmTallaColor.MdiParent = this.MdiParent;
                    FrmTallaColor.AplicaTalla = MiProducto.AplicaTalla;
                    FrmTallaColor.AplicaColor = MiProducto.AplicaColor;
                    FrmTallaColor.CodigoProducto = MiProducto.CodigoInternoProducto;
                    FrmTallaColor.Venta_ = true;
                    if (MiProducto.AplicaColor && !MiProducto.AplicaTalla)
                    {
                        FrmTallaColor.IdMedida_ = miMedida.IdValorUnidadMedida;
                    }
                    if (/*EnableColor && */MiProducto.AplicaColor)
                    {
                        FrmTallaColor.Show();
                    }
                    else
                    {
                        if (MiProducto.AplicaTalla)
                        {
                            FrmTallaColor.AplicaColor = false;
                            FrmTallaColor.Show();
                        }
                    }
                }
            }
            else
            {
                OptionPane.MessageInformation("Debe cargar un Articulo primero.");
            }
        }

        private void txtUtilidad_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                var utilidad = txtUtilidad.Text;
                if (String.IsNullOrEmpty(utilidad))
                {
                    utilidad = "0";
                }
                if (!String.IsNullOrEmpty(utilidad))/*txtUtilidad.Text))*/
                {
                    if (validacion.ValidarNumeroInt(utilidad))
                    {
                        MiError.SetError(txtUtilidad, null);
                        UtilidadMatch = true;
                        var precioUtil = 0.0;
                        if (Convert.ToBoolean(AppConfiguracion.ValorSeccion("calculo_util_multiplica")))
                        {
                            precioUtil = UseObject.RemoveSeparatorMil(txtCosto.Text) +
                                         (UseObject.RemoveSeparatorMil(txtCosto.Text) * Convert.ToDouble(utilidad.Replace('.', ',')) / 100);
                        }
                        else
                        {
                            precioUtil = UseObject.RemoveSeparatorMil(txtCosto.Text) / ((100 -
                                                    Convert.ToDouble(utilidad.Replace('.', ','))) / 100);
                        }

                        var precioSug = Convert.ToInt32(precioUtil + (precioUtil * MiProducto.ValorIva / 100));

                        txtPrecioSugerido.Text = UseObject.InsertSeparatorMil(Convert.ToInt32(precioSug).ToString());

                        char[] precioChar = precioSug.ToString().ToCharArray();
                        var precioAprox = 0;

                        if (Convert.ToBoolean(AppConfiguracion.ValorSeccion("calculo_util_multiplica"))) //Aprox centena
                        {
                            var digito = Convert.ToInt32(precioChar[precioChar.Length - 2].ToString()
                                                        + precioChar[precioChar.Length - 1].ToString());
                            if (digito > 50)
                            {
                                precioAprox = precioSug + (100 - digito);
                            }
                            else
                            {
                                precioAprox = precioSug - digito;
                            }
                        }
                        else  //aprox decena
                        {
                            if (Convert.ToInt32(precioChar[precioChar.Length - 1].ToString()) > 5)
                            {
                                precioAprox = precioSug + (10 - Convert.ToInt32(precioChar[precioChar.Length - 1].ToString()));
                            }
                            else
                            {
                                precioAprox = precioSug - Convert.ToInt32(precioChar[precioChar.Length - 1].ToString());
                            }
                        }
                        txtPrecioAprox.Text = UseObject.InsertSeparatorMil(precioAprox.ToString());
                    }
                    else
                    {
                        MiError.SetError(txtUtilidad, "El valor que ingreso es incorrecto.\n");
                        UtilidadMatch = false;
                    }
                }
                else
                {
                    txtPrecioSugerido.Text = txtCosto.Text;
                }
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
        }

        private void txtPrecioVenta_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                var venta = UseObject.RemoverPunto(txtPrecioVenta.Text);
                if (String.IsNullOrEmpty(venta))
                {
                    venta = "0";
                }
                else
                {
                    if (validacion.ValidarNumeroInt(venta))
                    {
                        MiError.SetError(txtPrecioVenta, null);
                        PrecioMatch = true;
                        var precioVenta = Convert.ToInt32(venta);
                        var precioCosto = Convert.ToInt32(UseObject.RemoveSeparatorMil(txtCosto.Text));
                        var pVentaNoIva = Convert.ToInt32(precioVenta / (1 + (MiProducto.ValorIva / 100)));

                        var utili = 0.0;
                        if (Convert.ToBoolean(AppConfiguracion.ValorSeccion("calculo_util_multiplica"))) //multiplica la utilidad
                        {
                            utili = Math.Round(Convert.ToDouble(((pVentaNoIva - precioCosto) * 100) / precioCosto), 2);
                        }
                        else  //divide la utilidad
                        {
                            var div = Math.Round(Convert.ToDouble(precioCosto) / Convert.ToDouble(pVentaNoIva), 2);
                            utili = 100 - (div * 100);
                        }
                        txtUtilidad.Text = utili.ToString();
                        var precioSug = Convert.ToInt32(venta);
                        char[] precioChar = precioSug.ToString().ToCharArray();
                        var precioAprox = 0;

                        if (precioChar.Length > 1)
                        {
                            if (Convert.ToBoolean(AppConfiguracion.ValorSeccion("calculo_util_multiplica"))) //Aprox centena
                            {
                                var digito = Convert.ToInt32(precioChar[precioChar.Length - 2].ToString()
                                                            + precioChar[precioChar.Length - 1].ToString());
                                if (digito > 50)
                                {
                                    precioAprox = precioSug + (100 - digito);
                                }
                                else
                                {
                                    precioAprox = precioSug - digito;
                                }
                            }
                            else  //aprox decena
                            {
                                if (Convert.ToInt32(precioChar[precioChar.Length - 1].ToString()) > 5)
                                {
                                    precioAprox = precioSug + (10 - Convert.ToInt32(precioChar[precioChar.Length - 1].ToString()));
                                }
                                else
                                {
                                    precioAprox = precioSug - Convert.ToInt32(precioChar[precioChar.Length - 1].ToString());
                                }
                            }
                        }
                        txtPrecioVenta.Text = UseObject.InsertSeparatorMil(venta);
                        txtPrecioSugerido.Text = txtPrecioVenta.Text;
                        txtPrecioAprox.Text = UseObject.InsertSeparatorMil(precioAprox.ToString());
                    }
                    else
                    {
                        MiError.SetError(txtPrecioVenta, "El valor que ingreso es incorrecto.");
                        PrecioMatch = false;
                    }
                }
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            if (MiProducto != null)
            {
                txtUtilidad_KeyUp(this.txtUtilidad, null);
                txtPrecioVenta_KeyUp(this.txtPrecioVenta, null);
                if (UtilidadMatch && PrecioMatch)
                {
                    var utilSave = UseObject.RemoveSeparatorMil(lblVUtilidad.Text);
                    var precioVentaSave = 
                        Convert.ToInt32(UseObject.RemoveSeparatorMil(lblValorVenta.Text));
                    DialogResult rta;
                    if (Convert.ToBoolean(AppConfiguracion.ValorSeccion("pregunta_act_util")))
                    {
                        rta = MessageBox.Show("¿Está seguro(a) de actualizar la utilidad?", "Ingresar Compra",
                                   MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (rta.Equals(DialogResult.Yes))
                        {
                            utilSave = Convert.ToDouble(txtUtilidad.Text.Replace('.', ','));
                        }
                    }
                    else
                    {
                        utilSave = Convert.ToDouble(txtUtilidad.Text.Replace('.', ','));
                    }
                    if (Convert.ToBoolean(AppConfiguracion.ValorSeccion("pregunta_act_pventa")))
                    {
                        rta = MessageBox.Show("¿Está seguro(a) de actualizar el precio de venta?", "Ingresar Compra",
                                   MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (rta.Equals(DialogResult.Yes))
                        {
                            precioVentaSave = Convert.ToInt32(UseObject.RemoveSeparatorMil(txtPrecioVenta.Text));
                        }
                    }
                    else
                    {
                        precioVentaSave = Convert.ToInt32(UseObject.RemoveSeparatorMil(txtPrecioVenta.Text));
                    }
                    try
                    {
                        miBussinesProducto.EditarUtilidadVenta
                            (MiProducto.CodigoInternoProducto,
                            utilSave,
                            precioVentaSave,
                            Convert.ToInt32(UseObject.RemoveSeparatorMil(txtCosto.Text)));
                        OptionPane.MessageInformation("La información del producto se ha almacenado correctamente.");
                        txtCodigoArticulo.Focus();
                    }
                    catch (Exception ex)
                    {
                        OptionPane.MessageError(ex.Message);
                    }
                }
            }
            else
            {
                OptionPane.MessageInformation("Debe cargar primero un articulo.\n");
            }
        }

        private bool CodigoOrString()
        {
            try
            {
                Convert.ToInt64(txtCodigoArticulo.Text);
                return true;
            }
            catch
            {
                return false;
            }
        }

        private bool ValidarCodigo()
        {
            bool resultado = false;
            if (!Validacion.EsVacio(txtCodigoArticulo, MiError, "El campo es requerido."))
            {
                if (Validacion.ConFormato(Validacion.TipoValidacion.LetrasGuionNumeros, 
                                          txtCodigoArticulo, MiError, "El valor que ingreso es invalido."))
                {
                    resultado = true;
                }
            }
            return resultado;
        }

        private bool ValidarCodigoBarras()
        {
            bool resultado = false;
            if (!Validacion.EsVacio(txtCodigoArticulo, MiError, "El campo es requerido."))
            {
                if (Validacion.ConFormato(
                    Validacion.TipoValidacion.Numeros, txtCodigoArticulo, MiError, "El valor que ingreso es invalido."))
                {
                    resultado = true;
                }
            }
            return resultado;
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

            try
            {
                FormInventario = Convert.ToBoolean(args.MiObjeto);
            }
            catch { }
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

        private void CargarProducto(string codigo)
        {
            try
            {
                miMedida = new ValorUnidadMedida();
                miTallaYcolor = new Compras.IngresarCompra.TallaYcolor();
                var SingleSize = true;
                var SingleColor = true;
                var ArrayProducto = miBussinesProducto.ProductoBasico(codigo);
                MiProducto = (DTO.Clases.Producto)ArrayProducto[0];
                var tabla = miBussinesMedida.MedidasDeProducto(MiProducto.CodigoInternoProducto);
                if (!MiProducto.AplicaTalla)
                {
                    miMedida = (ValorUnidadMedida)ArrayProducto[1];
                    miTallaYcolor.IdTalla = miMedida.IdValorUnidadMedida;
                    SingleSize = true;
                }
                else
                {
                    if (tabla.Rows.Count == 1)
                    {
                        var q = (from d in tabla.AsEnumerable()
                                 select d).Single();
                        miTallaYcolor.IdTalla = Convert.ToInt32(q["idvalor_unidad_medida"]);
                        miTallaYcolor.Talla = q["descripcionvalor_unidad_medida"].ToString();
                        q = null;
                        SingleSize = true;
                    }
                    else
                    {
                        SingleSize = false;
                    }
                }
                if (MiProducto.AplicaColor)
                {
                    if (tabla.Rows.Count == 1)
                    {
                        var q = (from d in tabla.AsEnumerable()
                                 select d).Single();
                        var tablaColor = miBussinesColor.ColoresDeProducto
                            (MiProducto.CodigoInternoProducto, Convert.ToInt32(q["idvalor_unidad_medida"]));
                        if (tablaColor.Rows.Count.Equals(1))
                        {
                            var c = (from d in tablaColor.AsEnumerable()
                                     select d).Single();
                            miTallaYcolor.IdColor = Convert.ToInt32(c["idcolor"]);
                            miTallaYcolor.Color = (Image)c["ImagenBit"];
                            SingleColor = true;
                        }
                        else
                        {
                            miTallaYcolor.IdColor = 0;
                            SingleColor = false;
                        }
                    }
                    else
                    {
                        miTallaYcolor.IdColor = 0;
                        SingleColor = false;
                    }
                }
                else
                {
                    miTallaYcolor.IdColor = 0;
                    SingleColor = true;
                }
                lblDatosProducto.Text = MiProducto.NombreProducto + "  --  " + MiProducto.NombreMarca;
                if (!SingleSize || !SingleColor)
                {
                    btnTallaYcolor.Enabled = true;
                    this.btnTallaYcolor_Click(this.btnTallaYcolor, new EventArgs());
                }
                else
                {
                    btnTallaYcolor.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
        }

        private void CargarInformacion()
        {
            try
            {
                var costo = miBussinesProducto.PrecioDeCosto(MiProducto.CodigoInternoProducto);
                var inventario = new DTO.Clases.Inventario();
                inventario.CodigoProducto = MiProducto.CodigoInternoProducto;
                inventario.IdMedida = miTallaYcolor.IdTalla;
                inventario.IdColor = miTallaYcolor.IdColor;
                inventario.Cantidad = Convert.ToInt32(AppConfiguracion.ValorSeccion("num_promedio"));
                var tProductos = miBussinesFacturaProveedor.ProductosDeFactura(inventario);
                if (tProductos.Rows.Count != 0)
                {
                    var cant = 0.0;
                    var total = 0;
                    foreach (DataRow tRow in tProductos.Rows)
                    {
                        cant += Convert.ToDouble(tRow["cantidad"]);
                        var vUnit = Convert.ToInt32(tRow["valor"]) -
                            (Convert.ToInt32(tRow["valor"]) * Convert.ToInt32(tRow["descuento"]) / 100);
                        if (Convert.ToBoolean(AppConfiguracion.ValorSeccion("utilidad_mas_iva")))   // Utilidad despues de IVA
                        {
                            total += Convert.ToInt32(
                            (vUnit + Convert.ToInt32(vUnit * Convert.ToDouble(tRow["iva"]) / 100)) * Convert.ToDouble(tRow["cantidad"]));
                        }
                        else
                        {
                            total += Convert.ToInt32(vUnit * Convert.ToDouble(tRow["cantidad"]));
                        }
                    }
                    txtCosto.Text = UseObject.InsertSeparatorMil((Convert.ToInt32(total / cant)).ToString());
                }
                else
                {
                    txtCosto.Text = UseObject.InsertSeparatorMil(costo.ToString());

                }
                var producto = miBussinesProducto.ProductoCompleto(MiProducto.CodigoInternoProducto);
                txtUtilidad.Text = producto.UtilidadPorcentualProducto.ToString();

                var precioSug = 0;

                if (Convert.ToBoolean(AppConfiguracion.ValorSeccion("calculo_util_multiplica"))) // mutliplica
                {
                    var precioUtil = UseObject.RemoveSeparatorMil(txtCosto.Text) +
                                 (UseObject.RemoveSeparatorMil(txtCosto.Text) * producto.UtilidadPorcentualProducto / 100);
                    precioSug = Convert.ToInt32(precioUtil + (precioUtil * producto.ValorIva / 100));
                }
                else  // divide
                {
                    var UtilComplemento = 100.0 - UseObject.RemoveSeparatorMil(txtUtilidad.Text);
                    var precioUtil = UseObject.RemoveSeparatorMil(txtCosto.Text) / (UtilComplemento / 100);
                    precioSug = Convert.ToInt32(precioUtil + (precioUtil * producto.ValorIva / 100));
                }
                txtPrecioSugerido.Text = UseObject.InsertSeparatorMil(precioSug.ToString());

                char[] precioChar = precioSug.ToString().ToCharArray();
                var precioAprox = 0;

                if (Convert.ToBoolean(AppConfiguracion.ValorSeccion("tipo_aprox_precio"))) //Aprox centena
                {
                    var digito = Convert.ToInt32(precioChar[precioChar.Length - 2].ToString()
                                                + precioChar[precioChar.Length - 1].ToString());
                    if (digito > 50)
                    {
                        precioAprox = precioSug + (100 - digito);
                    }
                    else
                    {
                        precioAprox = precioSug - digito;
                    }
                }
                else  //aprox decena
                {
                    if (Convert.ToInt32(precioChar[precioChar.Length - 1].ToString()) > 5)
                    {
                        precioAprox = precioSug + (10 - Convert.ToInt32(precioChar[precioChar.Length - 1].ToString()));
                    }
                    else
                    {
                        precioAprox = precioSug - Convert.ToInt32(precioChar[precioChar.Length - 1].ToString());
                    }
                }
                txtPrecioAprox.Text = UseObject.InsertSeparatorMil(precioAprox.ToString());
                txtPrecioVenta.Text = UseObject.InsertSeparatorMil(producto.ValorVentaProducto.ToString());

                lblValorCosto.Text = UseObject.InsertSeparatorMil(costo.ToString());
                lblVUtilidad.Text = producto.UtilidadPorcentualProducto.ToString();
                lblValorSugerido.Text = txtPrecioSugerido.Text;
                lblValorAprox.Text = txtPrecioAprox.Text;
                lblValorVenta.Text = UseObject.InsertSeparatorMil(producto.ValorVentaProducto.ToString());
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
        }
    }
}