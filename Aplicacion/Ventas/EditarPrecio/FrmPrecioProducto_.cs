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
using DTO.Clases;
using BussinesLayer.Clases;

namespace Aplicacion.Ventas.EditarPrecio
{
    public partial class FrmPrecioProducto_ : Form
    {
        private enum Calculo { Util_, Pventa, Descto };

        private ErrorProvider MiError;

        private Empresa miEmpresa;

        private bool UtilidadAntesIva;

        private bool CalculoUtilMultiplicado;

        private bool AproxPrecio;

        private bool RedondearPrecio2;

        private bool _ConsultaInventario;

        private bool DefaultUtilPercentage;

        private ValorUnidadMedida miMedida;

        private DTO.Clases.Producto MiProducto;

        private BussinesEmpresa miBussinesEmpresa;

        private BussinesIva miBussinesIva;

        private BussinesProducto miBussinesProducto;

        private BussinesValorUnidadMedida miBussinesMedida;

        private bool CostoNoIvaMatch;

        private bool CostoIvaMatch;

        private bool UtilMatch;

        private bool Util2Match;

        private bool Util3Match;

        private bool PrecioVentaMatch;

        private bool PrecioVenta2Match;

        private bool PrecioVenta3Match;

        private bool Descto2Match;

        private bool Descto3Match;

        public FrmPrecioProducto_()
        {
            InitializeComponent();
            this.MiError = new ErrorProvider();

            this.miBussinesEmpresa = new BussinesEmpresa();
            this.miBussinesIva = new BussinesIva();
            this.miBussinesProducto = new BussinesProducto();
            this.miBussinesMedida = new BussinesValorUnidadMedida();

            this.CostoNoIvaMatch = false;
            this.CostoIvaMatch = false;
            this.UtilMatch = false;
            this.Util2Match = false;
            this.Util3Match = false;
            this.PrecioVentaMatch = false;
            this.PrecioVenta2Match = false;
            this.PrecioVenta3Match = false;
            this.Descto2Match = false;
            this.Descto3Match = false;

            try
            {
                this.miEmpresa = this.miBussinesEmpresa.ObtenerEmpresa();
                this.UtilidadAntesIva = Convert.ToBoolean(AppConfiguracion.ValorSeccion("utilidad_mas_iva"));
                this.CalculoUtilMultiplicado = Convert.ToBoolean(AppConfiguracion.ValorSeccion("calculo_util_multiplica"));
                this.AproxPrecio = Convert.ToBoolean(AppConfiguracion.ValorSeccion("tipo_aprox_precio"));
                this.RedondearPrecio2 = Convert.ToBoolean(AppConfiguracion.ValorSeccion("redondeo_precio_dos"));
                _ConsultaInventario = Convert.ToBoolean(AppConfiguracion.ValorSeccion("frm_consulta_inventario"));

                DefaultUtilPercentage = Convert.ToBoolean(AppConfiguracion.ValorSeccion("default_util_percent"));
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
        }

        private void FrmPrecioProducto__Load(object sender, EventArgs e)
        {
            try
            {
                this.cbIvaEditar.DataSource = this.miBussinesIva.ListadoIva();

                CompletaEventos.CompAxTInvFactProvee +=
                        new CompletaEventos.ComAxTransferInvFactProve(CompletaEventos_CompAxTInvFactProvee);
                CompletaEventos.Completaz += new CompletaEventos.CompletaAccionz(CompletaEventos_Completaz);
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
        }

        private void FrmPrecioProducto__KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData.Equals(Keys.F2))
            {
                this.tsBtnGuardar_Click(this.tsBtnGuardar, new EventArgs());
            }
            else
            {
                if (e.KeyData.Equals(Keys.F3))
                {
                    this.tsConsultaProducto_Click(this.tsConsultaProducto, new EventArgs());
                }
                else
                {
                    if (e.KeyData.Equals(Keys.F4))
                    {
                        this.tsEditar_Click(this.tsEditar, new EventArgs());
                    }
                    else
                    {
                        if (e.KeyData.Equals(Keys.F5))
                        {
                            this.txtCodigoArticulo.Focus();
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
            }
            if (e.KeyData.Equals(Keys.F12))
            {
                this.Ajuste();
            }
        }

        private void FrmPrecioProducto__FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult rta = MessageBox.Show("¿Está seguro(a) de salir?",
                   "Edición de precio", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (rta.Equals(DialogResult.Yes))
            {
                e.Cancel = false;
            }
            else
            {
                e.Cancel = true;
            }
        }


        private void tsConsultaProducto_Click(object sender, EventArgs e)
        {
            var formInventario = new Inventario.Consulta.FrmConsultaInventario();
            formInventario.ExtendVenta = true;
            formInventario.IsCompra = true;
            formInventario.ShowDialog();
        }

        private void tsBtnGuardar_Click(object sender, EventArgs e)
        {
            if (this.MiProducto != null)
            {
                try
                {
                    if (ValidacionGuardado())
                    {
                        DialogResult rta_ = MessageBox.Show("¿Esta seguro(a) de guardar los cambios?", "Edición de precio",
                            MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (rta_.Equals(DialogResult.Yes))
                        {
                            Producto p = new Producto();
                            p.CodigoInternoProducto = this.MiProducto.CodigoInternoProducto;
                            p.UtilidadPorcentualProducto = Convert.ToDouble(this.txtUtilidadP1.Text.Replace('.', ','));
                            p.ValorVentaProducto = Convert.ToInt32(this.txtValorVentaP1.Text);
                            p.IdIvaTemp = p.IdIva = Convert.ToInt32(this.cbIvaEditar.SelectedValue);
                            p.ValorCosto = Convert.ToDouble(this.txtCostoNoIvaP1.Text.Replace('.', ','));
                            p.Impoconsumo = Convert.ToDouble(this.txtIcoP1.Text.Replace('.', ','));
                            /*p.DescuentoMayor = Convert.ToDouble(this.txtDescuentoP2.Text.Replace('.', ','));
                            p.DescuentoDistribuidor = Convert.ToDouble(this.txtDescuentoP3.Text.Replace('.', ','));*/
                            p.DescuentoMayor = Convert.ToDouble(this.txtDescuentoP2DB.Text.Replace('.', ','));
                            p.DescuentoDistribuidor = Convert.ToDouble(this.txtDescuentoP3DB.Text.Replace('.', ','));
                            p.DescuentoPrecio4 = Convert.ToDouble(this.txtDescuentoP4DB.Text.Replace('.', ','));
                            p.Utilidad2 = Convert.ToDouble(this.txtUtilidadP2.Text.Replace('.', ','));
                            p.Utilidad3 = Convert.ToDouble(this.txtUtilidadP3.Text.Replace('.', ','));
                            this.miBussinesProducto.EditarPrecios(p);
                            OptionPane.MessageInformation("La información del producto se ha almacenado correctamente.");

                            this.MiProducto = null;
                            this.txtCodigoArticulo.Focus();

                            this.lblCodigo.Text = "";
                            this.lblBarras.Text = "";
                            this.lblNombreProducto.Text = "";
                            this.txtCostoNoIvaP1.Text = "";

                            this.cbIvaEditar.Visible = false;
                            this.txtIvaP1.Visible = true;
                            this.txtIvaP1.Text = "";
                            this.btnEditarIva.Visible = true;

                            this.txtValorIvaP1.Text = "";
                            this.txtIcoP1.Text = "";
                            this.txtCostoConIvaP1.Text = "";
                            this.txtUtilidadP1.Text = "";
                            this.txtValorUtilidadP1.Text = "";
                            this.txtValIvaUtilidadP1.Text = "";
                            this.txtIcoPV1.Text = "";
                            this.txtValorVentaP1.Text = "";
                            this.txtValorSugeridoP1.Text = "";


                            this.txtCostoNoIvaP2.Text = "";
                            this.txtIvaP2.Text = "";
                            this.txtValorIvaP2.Text = "";
                            this.txtIcoP2.Text = "";
                            this.txtCostoConIvaP2.Text = "";
                            this.txtUtilidadP2.Text = "";
                            this.txtValorUtilidadP2.Text = "";
                            this.txtValIvaUtilidadP2.Text = "";
                            this.txtIcoPV2.Text = "";
                            this.txtValorVentaP2.Text = "";
                            this.txtValorSugeridoP2.Text = "";
                            this.txtDescuentoP2DB.Text = "";
                            this.txtDescuentoP2.Text = "";

                            this.txtCostoNoIvaP3.Text = "";
                            this.txtIvaP3.Text = "";
                            this.txtValorIvaP3.Text = "";
                            this.txtIcoP3.Text = "";
                            this.txtCostoConIvaP3.Text = "";
                            this.txtUtilidadP3.Text = "";
                            this.txtValorUtilidadP3.Text = "";
                            this.txtValIvaUtilidadP3.Text = "";
                            this.txtIcoPV3.Text = "";
                            this.txtValorVentaP3.Text = "";
                            this.txtValorSugeridoP3.Text = "";
                            this.txtDescuentoP3DB.Text = "";
                            this.txtDescuentoP3.Text = "";

                            this.txtCostoNoIvaP4.Text = "";
                            this.txtIvaP4.Text = "";
                            this.txtValorIvaP4.Text = "";
                            this.txtIcoP4.Text = "";
                            this.txtCostoConIvaP4.Text = "";
                            this.txtUtilidadP4.Text = "";
                            this.txtValorUtilidadP4.Text = "";
                            this.txtValIvaUtilidadP4.Text = "";
                            this.txtIcoPV4.Text = "";
                            this.txtValorVentaP4.Text = "";
                            this.txtValorSugeridoP4.Text = "";
                            this.txtDescuentoP4DB.Text = "";
                            this.txtDescuentoP4.Text = "";
                        }
                    }
                }
                catch (Exception ex)
                {
                    OptionPane.MessageError(ex.Message);
                }
            }
            else
            {
                OptionPane.MessageInformation("Debe cargar un producto.");
            }
        }

        private void tsEditar_Click(object sender, EventArgs e)
        {
            if (MiProducto != null)
            {
                var FrmEditarProducto = new Inventario.Producto.frmEditarProducto();
                //FrmEditarProducto.MdiParent = this.MdiParent;
                FrmEditarProducto.CodigoProducto = MiProducto.CodigoInternoProducto;
                FrmEditarProducto.ShowDialog();
            }
            else
            {
                OptionPane.MessageInformation("Debe cargar un producto.");
            }
        }

        private void tsSincronizar_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult rta = MessageBox.Show("¿Está seguro(a) de sincronizar los datos?",
                   "Edición de precio", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (rta.Equals(DialogResult.Yes))
                {
                    var bussinesTraslado = new BussinesTrasladoInventario();
                    var caja_ = bussinesTraslado.SincronizarPrecio();
                    if (caja_.Equals(""))
                    {
                        OptionPane.MessageInformation("Los datos se sincronizarón con éxito.");
                    }
                    else
                    {
                        OptionPane.MessageWarning("Ocurrió un error al establecer la conexión, cajas: " + caja_);
                    }
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

        private void txtCodigoArticulo_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (e.KeyChar == (char)Keys.Enter)
                {
                    if (!String.IsNullOrEmpty(this.txtCodigoArticulo.Text))
                    {
                        if (CodigoOrString())
                        {
                            if (ValidarCodigo() || ValidarCodigoBarras())
                            {
                                if (ExisteProducto(txtCodigoArticulo.Text))
                                {
                                    CargarProducto(txtCodigoArticulo.Text);
                                    CargarPrecioUno();
                                    CargarPrecioDos();
                                    CargarPrecioTres();
                                    CargarPrecioCuatro();
                                    miBussinesProducto.EditarInical(MiProducto.CodigoInternoProducto);

                                    /* if (!btnTallaYcolor.Enabled)
                                     {
                                         btnInfoCosto.Enabled = false;
                                         CargarInformacion();
                                         this.txtCodigoArticulo.Focus();
                                     }*/
                                }
                                else
                                {
                                    OptionPane.MessageInformation("El producto no existe.");
                                    this.txtCodigoArticulo.Text = "";
                                    /* DialogResult rta = MessageBox.Show("El Producto no existe.\n¿Desea Crearlo?",
                                         "Factura Venta", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                                     if (rta.Equals(DialogResult.Yes))
                                     {
                                         if (!FormInventario)
                                         {
                                             //derechos de administrador.
                                             var formProducto = new Inventario.Producto.FrmIngresarProducto();
                                             formProducto.MdiParent = this.MdiParent;
                                             formProducto.Extend = true;
                                             //formProducto.Fact = true;
                                             //FormInventario = true;
                                             formProducto.Show();
                                         }
                                     }*/
                                }
                            }
                        }
                        else
                        {
                            if (_ConsultaInventario)
                            {
                                var formInventario = new Inventario.Consulta.FrmConsultaInventario();
                                formInventario.MdiParent = this.MdiParent;
                                formInventario.ExtendVenta = true;
                                formInventario.IsCompra = true;
                                formInventario.EditPrice = true;
                                formInventario.txtCodigoNombre.Text = txtCodigoArticulo.Text;
                                //FormInventario = true;
                                formInventario.Show();
                                formInventario.dgvInventario.Focus();
                            }
                            else
                            {
                                var formInventario = new Inventario.Consulta.FrmInventario();
                                formInventario.MdiParent = this.MdiParent;
                                formInventario.ExtendVenta = true;
                                formInventario.IsCompra = true;
                                formInventario.txtCodigoNombre.Text = txtCodigoArticulo.Text;
                                formInventario.Show();
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
        }



        private void txtCostoNoIvaP1_KeyPress(object sender, KeyPressEventArgs e)
        {
            LimpiarErrorProvider();
            if (e.KeyChar.Equals((char)Keys.Enter))
            {
                if (!String.IsNullOrEmpty(this.txtCostoNoIvaP1.Text))
                {
                    MiError.SetError(this.txtCostoNoIvaP1, null);
                    if (ValidarDouble(this.txtCostoNoIvaP1.Text.Replace('.', ',')))
                    {
                        MiError.SetError(this.txtCostoNoIvaP1, null);
                        EditaCostoPrecioUno(false, Convert.ToDouble(this.txtCostoNoIvaP1.Text.Replace('.', ',')));
                        //EditaCostoPrecioDos(false, Convert.ToDouble(this.txtCostoNoIvaP1.Text.Replace('.', ',')));
                        //EditaCostoPrecioTres(false, Convert.ToDouble(this.txtCostoNoIvaP1.Text.Replace('.', ',')));
                        //EditaCostoPrecioCuatro(false, Convert.ToDouble(this.txtCostoNoIvaP1.Text.Replace('.', ',')));
                        this.txtCostoConIvaP1.Focus();
                    }
                    else
                    {
                        MiError.SetError(this.txtCostoNoIvaP1, "El valor que ingreso es incorrecto.");
                    }
                }
                else
                {
                    MiError.SetError(this.txtCostoNoIvaP1, "Debe ingresar un valor.");
                }
            }
        }

        private void btnEditarIva_Click(object sender, EventArgs e)
        {
            if (this.MiProducto != null)
            {
                this.cbIvaEditar.SelectedValue = this.MiProducto.IdIva;
                this.txtIvaP1.Visible = false;
                this.cbIvaEditar.Visible = true;
                this.btnEditarIva.Visible = false;
                LimpiarErrorProvider();
                this.cbIvaEditar.Focus();
            }
            else
            {
                OptionPane.MessageInformation("Debe cargar primero un articulo.");
            }
        }

        private void cbIvaEditar_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (this.MiProducto != null)
            {
                LimpiarErrorProvider();
                this.MiProducto.IdIva = ((Iva)cbIvaEditar.SelectedItem).IdIva;
                this.MiProducto.ValorIva = ((Iva)cbIvaEditar.SelectedItem).PorcentajeIva;
                this.AjusteCostoIva();
                // this.txtValorVentaP2.Text = this.txtValorSugeridoP2.Text;
                // this.txtValorVentaP3.Text = this.txtValorSugeridoP3.Text;
                this.txtValorVentaP1_KeyPress(this.txtValorVentaP1, new KeyPressEventArgs((char)Keys.Enter));
                this.txtValorVentaP2_KeyPress(this.txtValorVentaP2, new KeyPressEventArgs((char)Keys.Enter));
                this.txtValorVentaP3_KeyPress(this.txtValorVentaP3, new KeyPressEventArgs((char)Keys.Enter));
                this.txtValorVentaP4_KeyPress(this.txtValorVentaP4, new KeyPressEventArgs((char)Keys.Enter));
                this.cbIvaEditar.Focus();
            }
        }

        private void txtIcoP1_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                LimpiarErrorProvider();
                if (e.KeyChar.Equals((char)Keys.Enter))
                {
                    if (!String.IsNullOrEmpty(this.txtIcoP1.Text))
                    {
                        this.MiError.SetError(this.txtIcoP1, null);
                        if (ValidarDouble(this.txtIcoP1.Text.Replace('.', ',')))
                        {
                            this.MiError.SetError(this.txtIcoP1, null);
                            this.txtIcoPV1.Text = this.txtIcoPV2.Text = this.txtIcoPV3.Text = this.txtIcoPV4.Text =
                            this.txtIcoP2.Text = this.txtIcoP3.Text = this.txtIcoP4.Text = this.txtIcoP1.Text;

                            EditaCostoPrecioUno(true, Convert.ToDouble(this.txtCostoConIvaP1.Text.Replace('.', ',')));
                            this.txtUtilidadP1_KeyPress(this.txtUtilidadP1, new KeyPressEventArgs((char)Keys.Enter));
                            this.txtUtilidadP2_KeyPress(this.txtUtilidadP2, new KeyPressEventArgs((char)Keys.Enter));
                            this.txtUtilidadP3_KeyPress(this.txtUtilidadP3, new KeyPressEventArgs((char)Keys.Enter));
                            this.txtUtilidadP4_KeyPress(this.txtUtilidadP4, new KeyPressEventArgs((char)Keys.Enter));


                            //EditaCostoPrecioUno(false, Convert.ToDouble(this.txtCostoNoIvaP1.Text.Replace('.', ',')));
                            /*this.txtDescuentoP2_KeyPress(this.txtDescuentoP2, new KeyPressEventArgs((char)Keys.Enter));
                            this.txtDescuentoP3_KeyPress(this.txtDescuentoP3, new KeyPressEventArgs((char)Keys.Enter));
                            this.txtDescuentoP4_KeyPress(this.txtDescuentoP4, new KeyPressEventArgs((char)Keys.Enter));*/
                            //EditaCostoPrecioDos(true, Convert.ToDouble(this.txtCostoConIvaP1.Text.Replace('.', ',')));
                            //EditaCostoPrecioTres(true, Convert.ToDouble(this.txtCostoConIvaP1.Text.Replace('.', ',')));
                            //EditaCostoPrecioCuatro(true, Convert.ToDouble(this.txtCostoConIvaP1.Text.Replace('.', ',')));
                            this.txtCostoConIvaP1.Focus();
                        }
                        else
                        {
                            this.MiError.SetError(this.txtIcoP1, "El valor que ingreso es incorrecto.");
                        }
                    }
                    else
                    {
                        this.MiError.SetError(this.txtIcoP1, "Debe ingresar un valor.");
                    }
                }
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
        }

        private void txtCostoConIvaP1_KeyPress(object sender, KeyPressEventArgs e)
        {
            LimpiarErrorProvider();
            if (e.KeyChar.Equals((char)Keys.Enter))
            {
                if (!String.IsNullOrEmpty(this.txtCostoConIvaP1.Text))
                {
                    MiError.SetError(this.txtCostoConIvaP1, null);
                    if (ValidarDouble(this.txtCostoConIvaP1.Text.Replace('.', ',')))
                    {
                        MiError.SetError(this.txtCostoConIvaP1, null);
                        EditaCostoPrecioUno(true, Convert.ToDouble(this.txtCostoConIvaP1.Text.Replace('.', ',')));
                        //EditaCostoPrecioDos(true, Convert.ToDouble(this.txtCostoConIvaP1.Text.Replace('.', ',')));
                        //EditaCostoPrecioTres(true, Convert.ToDouble(this.txtCostoConIvaP1.Text.Replace('.', ',')));
                        //EditaCostoPrecioCuatro(true, Convert.ToDouble(this.txtCostoConIvaP1.Text.Replace('.', ',')));
                        this.txtUtilidadP1.Focus();
                    }
                    else
                    {
                        MiError.SetError(this.txtCostoConIvaP1, "El valor que ingreso es incorrecto.");
                    }
                }
                else
                {
                    MiError.SetError(this.txtCostoConIvaP1, "Debe ingresar un valor.");
                }
            }
        }


        private void txtUtilidadP1_KeyPress(object sender, KeyPressEventArgs e)
        {
            LimpiarErrorProvider();
            if (e.KeyChar.Equals((char)Keys.Enter))
            {
                if (!String.IsNullOrEmpty(this.txtUtilidadP1.Text))
                {
                    MiError.SetError(this.txtUtilidadP1, null);
                    if (ValidarDouble(this.txtUtilidadP1.Text.Replace('.', ',')))
                    {
                        MiError.SetError(this.txtUtilidadP1, null);
                        if (DefaultUtilPercentage)
                        {
                            EditPriceOne(false, Convert.ToDouble(this.txtUtilidadP1.Text.Replace('.', ',')));
                        }
                        else
                        {
                            EditaVentaPrecioUno(false, Convert.ToDouble(this.txtUtilidadP1.Text.Replace('.', ',')));
                        }
                        this.txtValorVentaP1.Focus();
                    }
                    else
                    {
                        MiError.SetError(this.txtUtilidadP1, "El valor que ingreso es incorrecto.");
                    }
                }
                else
                {
                    MiError.SetError(this.txtUtilidadP1, "Debe ingresar un valor.");
                }
            }
        }

        private void txtValorVentaP1_KeyPress(object sender, KeyPressEventArgs e)
        {
            LimpiarErrorProvider();
            if (e.KeyChar.Equals((char)Keys.Enter))
            {
                if (!String.IsNullOrEmpty(this.txtValorVentaP1.Text))
                {
                    MiError.SetError(this.txtValorVentaP1, null);
                    if (ValidarInt(this.txtValorVentaP1.Text))
                    {
                        MiError.SetError(this.txtValorVentaP1, null);
                        if (DefaultUtilPercentage)
                        {
                            EditPriceOne(true, Convert.ToDouble(this.txtValorVentaP1.Text.Replace('.', ',')));
                        }
                        else
                        {
                            EditaVentaPrecioUno(true, Convert.ToDouble(this.txtValorVentaP1.Text.Replace('.', ',')));
                        }
                        this.txtUtilidadP2.Focus();
                    }
                    else
                    {
                        MiError.SetError(this.txtValorVentaP1, "El valor que ingreso es incorrecto.");
                    }
                }
                else
                {
                    MiError.SetError(this.txtValorVentaP1, "Debe ingresar un valor.");
                }
            }
        }

        private void txtUtilidadP2_KeyPress(object sender, KeyPressEventArgs e)
        {
            LimpiarErrorProvider();
            if (e.KeyChar.Equals((char)Keys.Enter))
            {
                if (!String.IsNullOrEmpty(this.txtUtilidadP2.Text))
                {
                    MiError.SetError(this.txtUtilidadP2, null);
                    if (ValidarDouble(this.txtUtilidadP2.Text))
                    {
                        MiError.SetError(this.txtUtilidadP2, null);
                        //EditaVentaPrecioUno(true, Convert.ToDouble(this.txtUtilidadP2.Text.Replace('.', ',')));
                        EditaVentaPrecioDos(Calculo.Util_, Convert.ToDouble(this.txtUtilidadP2.Text.Replace('.', ',')));
                        this.txtValorVentaP2.Focus();
                    }
                    else
                    {
                        MiError.SetError(this.txtUtilidadP2, "El valor que ingreso es incorrecto.");
                    }
                }
                else
                {
                    MiError.SetError(this.txtUtilidadP2, "Debe ingresar un valor.");
                }
            }
        }

        private void txtValorVentaP2_KeyPress(object sender, KeyPressEventArgs e)
        {
            LimpiarErrorProvider();
            if (e.KeyChar.Equals((char)Keys.Enter))
            {
                if (!String.IsNullOrEmpty(this.txtValorVentaP2.Text))
                {
                    MiError.SetError(this.txtValorVentaP2, null);
                    if (ValidarInt(this.txtValorVentaP2.Text))
                    {
                        MiError.SetError(this.txtValorVentaP2, null);
                        //EditaVentaPrecioUno(true, Convert.ToDouble(this.txtUtilidadP2.Text.Replace('.', ',')));
                        EditaVentaPrecioDos(Calculo.Pventa, Convert.ToDouble(this.txtValorVentaP2.Text.Replace('.', ',')));
                        this.txtDescuentoP2.Focus();
                    }
                    else
                    {
                        MiError.SetError(this.txtValorVentaP2, "El valor que ingreso es incorrecto.");
                    }
                }
                else
                {
                    MiError.SetError(this.txtValorVentaP2, "Debe ingresar un valor.");
                }
            }
        }

        private void txtDescuentoP2_KeyPress(object sender, KeyPressEventArgs e)
        {
            LimpiarErrorProvider();
            if (e.KeyChar.Equals((char)Keys.Enter))
            {
                if (!String.IsNullOrEmpty(this.txtDescuentoP2.Text))
                {
                    MiError.SetError(this.txtDescuentoP2, null);
                    if (ValidarDouble(this.txtDescuentoP2.Text))
                    {
                        MiError.SetError(this.txtDescuentoP2, null);
                        /*int pVenta2 = Convert.ToInt32(Convert.ToInt32(this.txtValorSugeridoP1.Text) -
                            (Convert.ToInt32(this.txtValorSugeridoP1.Text) * Convert.ToDouble(this.txtDescuentoP2.Text.Replace('.', ',')) / 100));*/

                        this.txtDescuentoP2DB.Text = this.txtDescuentoP2.Text;
                        //int pVenta2 = Convert.ToInt32(this.txtValorVentaP1.Text) - Convert.ToInt32(this.MiProducto.Impoconsumo);  Convert.ToDouble(this.txtIcoPV1.Text.Replace('.', ','))
                        int pVenta2 = Convert.ToInt32(this.txtValorVentaP1.Text) - Convert.ToInt32(Convert.ToDouble(this.txtIcoP1.Text.Replace('.', ',')));
                        pVenta2 = Convert.ToInt32(pVenta2 - (pVenta2 * Convert.ToDouble(this.txtDescuentoP2.Text.Replace('.', ',')) / 100));

                        /*int pVenta2 = Convert.ToInt32(Convert.ToInt32(this.txtValorVentaP1.Text) -
                            (Convert.ToInt32(this.txtValorVentaP1.Text) * Convert.ToDouble(this.txtDescuentoP2.Text.Replace('.', ',')) / 100));*/

                        /*if (this.RedondearPrecio2)
                        {
                            pVenta2 = UseObject.Aproximar(pVenta2, AproxPrecio);
                        }*/

                        EditaVentaPrecioDos(Calculo.Descto, Convert.ToDouble(pVenta2));
                        this.txtUtilidadP3.Focus();
                    }
                    else
                    {
                        MiError.SetError(this.txtDescuentoP2, "El valor que ingreso es incorrecto.");
                    }
                }
                else
                {
                    MiError.SetError(this.txtDescuentoP2, "Debe ingresar un valor.");
                }
            }
        }

        private void txtUtilidadP3_KeyPress(object sender, KeyPressEventArgs e)
        {
            LimpiarErrorProvider();
            if (e.KeyChar.Equals((char)Keys.Enter))
            {
                if (!String.IsNullOrEmpty(this.txtUtilidadP3.Text))
                {
                    MiError.SetError(this.txtUtilidadP3, null);
                    if (ValidarDouble(this.txtUtilidadP3.Text))
                    {
                        MiError.SetError(this.txtUtilidadP3, null);
                        //EditaVentaPrecioUno(true, Convert.ToDouble(this.txtUtilidadP2.Text.Replace('.', ',')));
                        EditaVentaPrecioTres(Calculo.Util_, Convert.ToDouble(this.txtUtilidadP3.Text.Replace('.', ',')));
                        this.txtValorVentaP3.Focus();
                    }
                    else
                    {
                        MiError.SetError(this.txtUtilidadP3, "El valor que ingreso es incorrecto.");
                    }
                }
                else
                {
                    MiError.SetError(this.txtUtilidadP3, "Debe ingresar un valor.");
                }
            }
        }

        private void txtValorVentaP3_KeyPress(object sender, KeyPressEventArgs e)
        {
            LimpiarErrorProvider();
            if (e.KeyChar.Equals((char)Keys.Enter))
            {
                if (!String.IsNullOrEmpty(this.txtValorVentaP3.Text))
                {
                    this.MiError.SetError(this.txtValorVentaP3, null);
                    if (ValidarInt(this.txtValorVentaP3.Text))
                    {
                        this.MiError.SetError(this.txtValorVentaP3, null);
                        //EditaVentaPrecioUno(true, Convert.ToDouble(this.txtUtilidadP2.Text.Replace('.', ',')));
                        EditaVentaPrecioTres(Calculo.Pventa, Convert.ToDouble(this.txtValorVentaP3.Text.Replace('.', ',')));
                        this.txtDescuentoP3.Focus();
                    }
                    else
                    {
                        this.MiError.SetError(this.txtValorVentaP3, "El valor que ingreso es incorrecto.");
                    }
                }
                else
                {
                    this.MiError.SetError(this.txtValorVentaP3, "Debe ingresar un valor.");
                }
            }
        }

        private void txtDescuentoP3_KeyPress(object sender, KeyPressEventArgs e)
        {
            LimpiarErrorProvider();
            if (e.KeyChar.Equals((char)Keys.Enter))
            {
                if (!String.IsNullOrEmpty(this.txtDescuentoP3.Text))
                {
                    MiError.SetError(this.txtDescuentoP3, null);
                    if (ValidarDouble(this.txtDescuentoP3.Text))
                    {
                        MiError.SetError(this.txtDescuentoP3, null);
                        /*int pVenta2 = Convert.ToInt32(Convert.ToInt32(this.txtValorSugeridoP1.Text) -
                            (Convert.ToInt32(this.txtValorSugeridoP1.Text) * Convert.ToDouble(this.txtDescuentoP3.Text.Replace('.', ',')) / 100));*/

                        this.txtDescuentoP3DB.Text = this.txtDescuentoP3.Text;
                        //int pVenta2 = Convert.ToInt32(this.txtValorVentaP1.Text) - Convert.ToInt32(this.MiProducto.Impoconsumo);
                        int pVenta2 = Convert.ToInt32(this.txtValorVentaP1.Text) - Convert.ToInt32(Convert.ToDouble(this.txtIcoP1.Text.Replace('.', ',')));
                        pVenta2 = Convert.ToInt32(pVenta2 - (pVenta2 * Convert.ToDouble(this.txtDescuentoP3.Text.Replace('.', ',')) / 100));

                        /*int pVenta2 = Convert.ToInt32(Convert.ToInt32(this.txtValorVentaP1.Text) -
                            (Convert.ToInt32(this.txtValorVentaP1.Text) * Convert.ToDouble(this.txtDescuentoP3.Text.Replace('.', ',')) / 100));*/

                        /*if (this.RedondearPrecio2)
                        {
                            pVenta2 = UseObject.Aproximar(pVenta2, AproxPrecio);
                        }*/

                        //pVenta2 = UseObject.Aproximar(pVenta2, AproxPrecio);
                        EditaVentaPrecioTres(Calculo.Descto, Convert.ToDouble(pVenta2));
                        this.txtUtilidadP4.Focus();
                    }
                    else
                    {
                        MiError.SetError(this.txtDescuentoP3, "El valor que ingreso es incorrecto.");
                    }
                }
                else
                {
                    MiError.SetError(this.txtDescuentoP3, "Debe ingresar un valor.");
                }
            }
        }

        private void txtUtilidadP4_KeyPress(object sender, KeyPressEventArgs e)
        {
            LimpiarErrorProvider();
            if (e.KeyChar.Equals((char)Keys.Enter))
            {
                if (!String.IsNullOrEmpty(this.txtUtilidadP4.Text))
                {
                    MiError.SetError(this.txtUtilidadP4, null);
                    if (ValidarDouble(this.txtUtilidadP4.Text))
                    {
                        MiError.SetError(this.txtUtilidadP4, null);
                        //EditaVentaPrecioUno(true, Convert.ToDouble(this.txtUtilidadP2.Text.Replace('.', ',')));
                        EditaVentaPrecioCuatro(Calculo.Util_, Convert.ToDouble(this.txtUtilidadP4.Text.Replace('.', ',')));
                        this.txtValorVentaP4.Focus();
                    }
                    else
                    {
                        MiError.SetError(this.txtUtilidadP4, "El valor que ingreso es incorrecto.");
                    }
                }
                else
                {
                    MiError.SetError(this.txtUtilidadP4, "Debe ingresar un valor.");
                }
            }
        }

        private void txtValorVentaP4_KeyPress(object sender, KeyPressEventArgs e)
        {
            LimpiarErrorProvider();
            if (e.KeyChar.Equals((char)Keys.Enter))
            {
                if (!String.IsNullOrEmpty(this.txtValorVentaP4.Text))
                {
                    this.MiError.SetError(this.txtValorVentaP4, null);
                    if (ValidarInt(this.txtValorVentaP4.Text))
                    {
                        this.MiError.SetError(this.txtValorVentaP4, null);
                        //EditaVentaPrecioUno(true, Convert.ToDouble(this.txtUtilidadP2.Text.Replace('.', ',')));
                        EditaVentaPrecioCuatro(Calculo.Pventa, Convert.ToDouble(this.txtValorVentaP4.Text.Replace('.', ',')));
                        this.txtDescuentoP4.Focus();
                    }
                    else
                    {
                        this.MiError.SetError(this.txtValorVentaP4, "El valor que ingreso es incorrecto.");
                    }
                }
                else
                {
                    this.MiError.SetError(this.txtValorVentaP4, "Debe ingresar un valor.");
                }
            }
        }

        private void txtDescuentoP4_KeyPress(object sender, KeyPressEventArgs e)
        {
            this.LimpiarErrorProvider();
            if (e.KeyChar.Equals((char)Keys.Enter))
            {
                if (!String.IsNullOrEmpty(this.txtDescuentoP4.Text))
                {
                    this.MiError.SetError(this.txtDescuentoP4, null);
                    if (ValidarDouble(this.txtDescuentoP4.Text))
                    {
                        this.MiError.SetError(this.txtDescuentoP4, null);
                        this.txtDescuentoP4DB.Text = this.txtDescuentoP4.Text;
                        //int pVenta2 = Convert.ToInt32(this.txtValorVentaP1.Text) - Convert.ToInt32(this.MiProducto.Impoconsumo); 
                        int pVenta2 = Convert.ToInt32(this.txtValorVentaP1.Text) - Convert.ToInt32(Convert.ToDouble(this.txtIcoP1.Text.Replace('.', ',')));
                        pVenta2 = Convert.ToInt32(pVenta2 - (pVenta2 * Convert.ToDouble(this.txtDescuentoP4.Text.Replace('.', ',')) / 100));
                        
                        /*int pVenta2 = Convert.ToInt32(Convert.ToInt32(this.txtValorVentaP1.Text) -
                            (Convert.ToInt32(this.txtValorVentaP1.Text) * Convert.ToDouble(this.txtDescuentoP4.Text.Replace('.', ',')) / 100));*/

                        /*if (this.RedondearPrecio2)   //  No usar por valor desigual cuando se establecia el descuento.
                        {
                            pVenta2 = UseObject.Aproximar(pVenta2, this.AproxPrecio);
                        }*/

                        this.EditaVentaPrecioCuatro(Calculo.Descto, Convert.ToDouble(pVenta2));
                        //this.EditaVentaPrecioCuatro(Calculo.Pventa, Convert.ToInt32(this.txtValorSugeridoP1.Text));
                    }
                    else
                    {
                        this.MiError.SetError(this.txtDescuentoP4, "El valor que ingreso es incorrecto.");
                    }
                }
                else
                {
                    this.MiError.SetError(this.txtDescuentoP4, "Debe ingresar un valor.");
                }
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

        private bool ValidarInt(string valor)
        {
            try
            {
                Convert.ToInt32(valor);
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
            this.MiProducto = this.miBussinesProducto.ProductoCompleto(this.MiProducto.CodigoInternoProducto);
            this.cbIvaEditar.SelectedValue = MiProducto.IdIva;
            this.lblCodigo.Text = this.MiProducto.CodigoInternoProducto;
            this.lblBarras.Text = this.MiProducto.CodigoBarrasProducto;
            //this.lblReferencia.Text = this.MiProducto.ReferenciaProducto;
            this.lblNombreProducto.Text = this.MiProducto.NombreProducto;

            this.txtCodigoArticulo.Text = "";
        }

        private void CargarPrecioUno()
        {
            var costo = this.miBussinesProducto.PrecioDeCosto(this.MiProducto.CodigoInternoProducto);
            //var producto = this.miBussinesProducto.ProductoCompleto(this.MiProducto.CodigoInternoProducto);
            this.txtCostoNoIvaP1.Text = costo.ToString().Replace(',', '.');

            // this.MiProducto = producto;
            //this.MiProducto.IdIva = producto.IdIva;

            //this.cbIvaEditar.SelectedValue = this.MiProducto.IdIva;

            this.txtIvaP1.Text = this.MiProducto.ValorIva.ToString().Replace(',', '.');
            this.txtIvaP1.Text = ((Iva)cbIvaEditar.SelectedItem).ConceptoIva;


            this.txtValorIvaP1.Text = Math.Round((costo * this.MiProducto.ValorIva / 100), 2).ToString().Replace(',', '.');
            this.txtIcoP1.Text = this.MiProducto.Impoconsumo.ToString().Replace(',', '.');
            var costoMasIva = Math.Round((costo + Math.Round((costo * this.MiProducto.ValorIva / 100), 4)), 2) +
                this.MiProducto.Impoconsumo;
            this.txtCostoConIvaP1.Text = costoMasIva.ToString().Replace(',', '.');

            this.txtUtilidadP1.Text = this.MiProducto.UtilidadPorcentualProducto.ToString().Replace(',', '.');

            var valUtil = 0.0;
            var valIvaUtil = 0.0;
            var venta = 0;

            if (!DefaultUtilPercentage)
            {

                if (!this.UtilidadAntesIva)  // Utilidad antes de IVA.
                {
                    if (!this.miEmpresa.Regimen.IdRegimen.Equals(1))  // Nuevo cod.
                    {
                        costo = costoMasIva;
                    }
                    if (this.CalculoUtilMultiplicado)  // Incremento de utilidad multiplic.
                    {
                        valUtil = Math.Round((costo * this.MiProducto.UtilidadPorcentualProducto / 100), 2);
                    }
                    else
                    {
                        valUtil = Math.Round(((costo / ((100 - this.MiProducto.UtilidadPorcentualProducto) / 100)) - costo), 2);
                    }
                    //valIvaUtil = Math.Round((valUtil * this.MiProducto.ValorIva / 100), 2);
                    if (this.miEmpresa.Regimen.IdRegimen.Equals(1))
                    {
                        valIvaUtil = Math.Round((valUtil * this.MiProducto.ValorIva / 100), 2);
                        //venta = Convert.ToInt32(costoMasIva + valUtil + valIvaUtil);
                    }
                    else
                    {
                        //venta = Convert.ToInt32(costoMasIva + valUtil);
                    }
                    venta = Convert.ToInt32(costoMasIva + valUtil + valIvaUtil);
                    //venta = Convert.ToInt32(costo + valUtil + valIvaUtil);
                }
                else
                {
                    if (this.CalculoUtilMultiplicado)  // Incremento de utilidad multiplic.
                    {
                        valUtil = Math.Round((costoMasIva * this.MiProducto.UtilidadPorcentualProducto / 100), 2);
                    }
                    else
                    {
                        valUtil = Math.Round(((costoMasIva / ((100 - this.MiProducto.UtilidadPorcentualProducto) / 100)) - costoMasIva), 2);
                    }
                    //valIvaUtil = costoMasIva - costo;  // Nuevo cod.
                    venta = Convert.ToInt32(costoMasIva + valUtil); // + valIvaUtil);  // Nuevo cod.
                    //venta = Convert.ToInt32(costo + valUtil + valIvaUtil);
                }
                venta = UseObject.Aproximar(venta, AproxPrecio);

            }
            else
            {
                venta = Convert.ToInt32(PriceProduct.GetPrice(new PriceProduct
                {
                    Costo = costoMasIva,
                    Util = this.MiProducto.UtilidadPorcentualProducto
                }));
            }

            this.txtIcoPV1.Text = this.MiProducto.Impoconsumo.ToString().Replace(',', '.');

            this.txtValorUtilidadP1.Text = valUtil.ToString().Replace(',', '.');
            this.txtValIvaUtilidadP1.Text = valIvaUtil.ToString().Replace(',', '.');
            //this.txtValorVentaP1.Text = venta.ToString();
            //venta += Convert.ToInt32(this.MiProducto.Impoconsumo);
            ///this.txtValorSugeridoP1.Text = UseObject.Aproximar(venta, AproxPrecio).ToString().Replace(',', '.');
            this.txtValorSugeridoP1.Text = venta.ToString().Replace(',', '.');

            this.txtValorVentaP1.Text = this.MiProducto.ValorVentaProducto.ToString();
            
        }

        private void CargarPrecioDos()
        {
            this.txtCostoNoIvaP2.Text = this.txtCostoNoIvaP1.Text;
            this.txtIvaP2.Text = this.txtIvaP1.Text;
            this.txtValorIvaP2.Text = this.txtValorIvaP1.Text;
            this.txtIcoP2.Text = this.txtIcoP1.Text;
            this.txtCostoConIvaP2.Text = this.txtCostoConIvaP1.Text;
            this.txtUtilidadP2.Text = this.MiProducto.Utilidad2.ToString().Replace(',', '.');

            var costo = Convert.ToDouble(this.txtCostoNoIvaP2.Text.Replace('.', ','));
            var costoMasIva = Convert.ToDouble(this.txtCostoConIvaP2.Text.Replace('.', ','));
            var valUtil = 0.0;
            var valIvaUtil = 0.0;
            var venta = 0;

            if (!this.UtilidadAntesIva)  // Utilidad antes de IVA.
            {
                if (this.CalculoUtilMultiplicado)  // Incremento de utilidad multiplic.
                {
                    valUtil = Math.Round((costo * this.MiProducto.Utilidad2 / 100), 2);
                }
                else
                {
                    valUtil = Math.Round(((costo / ((100 - this.MiProducto.Utilidad2) / 100)) - costo), 2);
                }
                //valIvaUtil = Math.Round((valUtil * this.MiProducto.ValorIva / 100), 2);
                if (this.miEmpresa.Regimen.IdRegimen.Equals(1))
                {
                    valIvaUtil = Math.Round((valUtil * this.MiProducto.ValorIva / 100), 2);
                    //venta = Convert.ToInt32(costoMasIva + valUtil + valIvaUtil);
                }
                else
                {
                    //venta = Convert.ToInt32(costoMasIva + valUtil);
                }
            }
            else
            {
                if (this.CalculoUtilMultiplicado)  // Incremento de utilidad multiplic.
                {
                    valUtil = Math.Round((costoMasIva * this.MiProducto.Utilidad2 / 100), 2);
                }
                else
                {
                    valUtil = Math.Round(((costoMasIva / ((100 - this.MiProducto.Utilidad2) / 100)) - costoMasIva), 2);
                }
            }
            venta = Convert.ToInt32(costoMasIva + valUtil + valIvaUtil);
            //venta = Convert.ToInt32(costo + valUtil + valIvaUtil);

            this.txtIcoPV2.Text = this.txtIcoPV1.Text;
            this.txtValorUtilidadP2.Text = valUtil.ToString().Replace(',', '.');
            this.txtValIvaUtilidadP2.Text = valIvaUtil.ToString().Replace(',', '.');
            /*this.txtValorVentaP2.Text = venta.ToString();
            this.txtValorSugeridoP2.Text = UseObject.Aproximar(venta, AproxPrecio).ToString().Replace(',', '.');
            this.txtDescuentoP2.Text = this.MiProducto.DescuentoMayor.ToString().Replace(',', '.');*/

            //venta += Convert.ToInt32(this.MiProducto.Impoconsumo);

            this.txtValorSugeridoP2.Text = UseObject.Aproximar(venta, AproxPrecio).ToString().Replace(',', '.');
            venta = Convert.ToInt32(this.txtValorVentaP1.Text) - Convert.ToInt32(this.MiProducto.Impoconsumo);
            double valor__ = Math.Round((venta * this.MiProducto.DescuentoMayor / 100), 1); //
            int pVenta2 = Convert.ToInt32(venta - valor__);
            //int pVenta2 = Convert.ToInt32(venta - (venta * this.MiProducto.DescuentoMayor / 100));
            pVenta2 += Convert.ToInt32(this.MiProducto.Impoconsumo);
            
            //int pVenta2 = Convert.ToInt32(Convert.ToInt32(this.txtValorVentaP1.Text) -
                            //(Convert.ToInt32(this.txtValorVentaP1.Text) * this.MiProducto.DescuentoMayor / 100));
            if (this.RedondearPrecio2)
            {
                pVenta2 = UseObject.Aproximar(pVenta2, AproxPrecio);
            }
            this.txtValorVentaP2.Text = pVenta2.ToString();
            this.txtDescuentoP2DB.Text = this.txtDescuentoP2.Text = this.MiProducto.DescuentoMayor.ToString().Replace(',', '.');
        }

        private void CargarPrecioTres()
        {
            this.txtCostoNoIvaP3.Text = this.txtCostoNoIvaP1.Text;
            this.txtIvaP3.Text = this.txtIvaP1.Text;
            this.txtValorIvaP3.Text = this.txtValorIvaP1.Text;
            this.txtIcoP3.Text = this.txtIcoP1.Text;
            this.txtCostoConIvaP3.Text = this.txtCostoConIvaP1.Text;
            this.txtUtilidadP3.Text = this.MiProducto.Utilidad3.ToString().Replace(',', '.');

            var costo = Convert.ToDouble(this.txtCostoNoIvaP3.Text.Replace('.', ','));
            var costoMasIva = Convert.ToDouble(this.txtCostoConIvaP3.Text.Replace('.', ','));
            var valUtil = 0.0;
            var valIvaUtil = 0.0;
            var venta = 0;

            if (!this.UtilidadAntesIva)  // Utilidad antes de IVA.
            {
                if (this.CalculoUtilMultiplicado)  // Incremento de utilidad multiplic.
                {
                    valUtil = Math.Round((costo * this.MiProducto.Utilidad3 / 100), 2);
                }
                else
                {
                    valUtil = Math.Round(((costo / ((100 - this.MiProducto.Utilidad3) / 100)) - costo), 2);
                }
                //valIvaUtil = Math.Round((valUtil * this.MiProducto.ValorIva / 100), 2);
                if (this.miEmpresa.Regimen.IdRegimen.Equals(1))
                {
                    valIvaUtil = Math.Round((valUtil * this.MiProducto.ValorIva / 100), 2);
                    //venta = Convert.ToInt32(costoMasIva + valUtil + valIvaUtil);
                }
                else
                {
                    //venta = Convert.ToInt32(costoMasIva + valUtil);
                }
            }
            else
            {
                if (this.CalculoUtilMultiplicado)  // Incremento de utilidad multiplic.
                {
                    valUtil = Math.Round((costoMasIva * this.MiProducto.Utilidad3 / 100), 2);
                }
                else
                {
                    valUtil = Math.Round(((costoMasIva / ((100 - this.MiProducto.Utilidad3) / 100)) - costoMasIva), 2);
                }
            }
            venta = Convert.ToInt32(costoMasIva + valUtil + valIvaUtil);
            //venta = Convert.ToInt32(costo + valUtil + valIvaUtil);

            this.txtIcoPV3.Text = this.txtIcoP1.Text;
            this.txtValorUtilidadP3.Text = valUtil.ToString().Replace(',', '.');
            this.txtValIvaUtilidadP3.Text = valIvaUtil.ToString().Replace(',', '.');
            /*this.txtValorVentaP3.Text = venta.ToString();
            this.txtValorSugeridoP3.Text = UseObject.Aproximar(venta, AproxPrecio).ToString().Replace(',', '.');
            this.txtDescuentoP3.Text = this.MiProducto.DescuentoDistribuidor.ToString().Replace(',', '.');*/

            //venta += Convert.ToInt32(this.MiProducto.Impoconsumo);

            this.txtValorSugeridoP3.Text = UseObject.Aproximar(venta, AproxPrecio).ToString().Replace(',', '.');
            venta = Convert.ToInt32(this.txtValorVentaP1.Text) - Convert.ToInt32(this.MiProducto.Impoconsumo);
            int pVenta3 = Convert.ToInt32(venta - (venta * this.MiProducto.DescuentoDistribuidor / 100));
            pVenta3 += Convert.ToInt32(this.MiProducto.Impoconsumo);

            //int pVenta3 = Convert.ToInt32(Convert.ToInt32(this.txtValorVentaP1.Text) -
                            ///(Convert.ToInt32(this.txtValorVentaP1.Text) * this.MiProducto.DescuentoDistribuidor / 100));
            if (this.RedondearPrecio2)
            {
                pVenta3 = UseObject.Aproximar(pVenta3, AproxPrecio);
            }
            this.txtValorVentaP3.Text = pVenta3.ToString();
            this.txtDescuentoP3DB.Text = this.txtDescuentoP3.Text = this.MiProducto.DescuentoDistribuidor.ToString().Replace(',', '.');
        }

        private void CargarPrecioCuatro()
        {
            this.txtCostoNoIvaP4.Text = this.txtCostoNoIvaP1.Text;
            this.txtIvaP4.Text = this.txtIvaP1.Text;
            this.txtValorIvaP4.Text = this.txtValorIvaP1.Text;
            this.txtIcoPV4.Text = this.txtIcoP4.Text = this.txtIcoP1.Text;
            this.txtCostoConIvaP4.Text = this.txtCostoConIvaP1.Text;

            this.txtDescuentoP4DB.Text = this.txtDescuentoP4.Text = this.MiProducto.DescuentoPrecio4.ToString().Replace(',', '.');
            //this.cbIvaEditar.SelectedValue = this.MiProducto.IdIva;
            this.txtDescuentoP4_KeyPress(this.txtDescuentoP4, new KeyPressEventArgs((char)Keys.Enter));

            /*
            this.txtUtilidadP4.Text = this.MiProducto.Utilidad3.ToString().Replace(',', '.');

            var costo = Convert.ToDouble(this.txtCostoNoIvaP4.Text.Replace('.', ','));
            var costoMasIva = Convert.ToDouble(this.txtCostoConIvaP4.Text.Replace('.', ','));
            var valUtil = 0.0;
            var valIvaUtil = 0.0;
            var venta = 0;

            if (!this.UtilidadAntesIva)  // Utilidad antes de IVA.
            {
                if (this.CalculoUtilMultiplicado)  // Incremento de utilidad multiplic.
                {
                    valUtil = Math.Round((costo * this.MiProducto.Utilidad3 / 100), 2);
                }
                else
                {
                    valUtil = Math.Round(((costo / ((100 - this.MiProducto.Utilidad3) / 100)) - costo), 2);
                }
                //valIvaUtil = Math.Round((valUtil * this.MiProducto.ValorIva / 100), 2);
                if (this.miEmpresa.Regimen.IdRegimen.Equals(1))
                {
                    valIvaUtil = Math.Round((valUtil * this.MiProducto.ValorIva / 100), 2);
                    //venta = Convert.ToInt32(costoMasIva + valUtil + valIvaUtil);
                }
                else
                {
                    //venta = Convert.ToInt32(costoMasIva + valUtil);
                }
            }
            else
            {
                if (this.CalculoUtilMultiplicado)  // Incremento de utilidad multiplic.
                {
                    valUtil = Math.Round((costoMasIva * this.MiProducto.Utilidad3 / 100), 2);
                }
                else
                {
                    valUtil = Math.Round(((costoMasIva / ((100 - this.MiProducto.Utilidad3) / 100)) - costoMasIva), 2);
                }
            }
            venta = Convert.ToInt32(costoMasIva + valUtil + valIvaUtil);

            this.txtValorUtilidadP3.Text = valUtil.ToString().Replace(',', '.');
            this.txtValIvaUtilidadP3.Text = valIvaUtil.ToString().Replace(',', '.');

            this.txtValorSugeridoP3.Text = UseObject.Aproximar(venta, AproxPrecio).ToString().Replace(',', '.');
            int pVenta3 = Convert.ToInt32(Convert.ToInt32(this.txtValorVentaP1.Text) -
                            (Convert.ToInt32(this.txtValorVentaP1.Text) * this.MiProducto.DescuentoDistribuidor / 100));
            if (this.RedondearPrecio2)
            {
                pVenta3 = UseObject.Aproximar(pVenta3, AproxPrecio);
            }
            this.txtValorVentaP3.Text = pVenta3.ToString();
            this.txtDescuentoP3DB.Text = this.txtDescuentoP3.Text = this.MiProducto.DescuentoDistribuidor.ToString().Replace(',', '.');
            */
        }


        private void AjusteCostoIva()
        {
            try
            {
                double costo = Convert.ToDouble(this.txtCostoConIvaP1.Text.Replace('.', ',')) -
                    Convert.ToDouble(this.txtIcoP1.Text.Replace('.', ','));
                var costoNoIva = Math.Round((costo / (1 + (this.MiProducto.ValorIva / 100))), 2);
                var valorIva = Math.Round((costo - costoNoIva), 2);

                this.txtValorIvaP1.Text = this.txtValorIvaP2.Text =
                    this.txtValorIvaP3.Text = this.txtValorIvaP4.Text = valorIva.ToString().Replace(',', '.');

                this.txtCostoNoIvaP1.Text = this.txtCostoNoIvaP2.Text =
                    this.txtCostoNoIvaP3.Text = this.txtCostoNoIvaP4.Text = costoNoIva.ToString().Replace(',', '.');

                this.txtIvaP1.Text = this.txtIvaP2.Text =
                    this.txtIvaP3.Text = this.txtIvaP4.Text = ((Iva)cbIvaEditar.SelectedItem).ConceptoIva;
                    //this.MiProducto.ValorIva.ToString().Replace(',', '.');
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
        }

        private void EditaCostoPrecioUno(bool iva_, double costo)
        {
            try
            {
                double ivaEdit = ((Iva)cbIvaEditar.SelectedItem).PorcentajeIva;
                double utilEdit = Convert.ToDouble(this.txtUtilidadP1.Text.ToString().Replace('.', ','));
                if (iva_)  // indica costo con iva
                {
                    costo -= Convert.ToDouble(this.txtIcoP1.Text.Replace('.', ','));

                    var costoNoIva = Math.Round((costo / (1 + (this.MiProducto.ValorIva / 100))), 2);
                    this.txtCostoNoIvaP1.Text = costoNoIva.ToString().Replace(',', '.');
                    this.txtValorIvaP1.Text = Math.Round((costo - costoNoIva), 2).ToString().Replace(',', '.');

                    var valUtil = 0.0;
                    var valIvaUtil = 0.0;
                    var venta = 0;

                    if (!DefaultUtilPercentage)
                    {

                        if (!this.UtilidadAntesIva)  // Utilidad antes de IVA.
                        {
                            if (this.CalculoUtilMultiplicado)  // Incremento de utilidad multiplic.
                            {
                                valUtil = Math.Round((costoNoIva * utilEdit / 100), 2);
                            }
                            else
                            {
                                valUtil = Math.Round(((costoNoIva / ((100 - utilEdit) / 100)) - costoNoIva), 2);
                            }
                            //valIvaUtil = Math.Round((valUtil * this.MiProducto.ValorIva / 100), 2);
                            if (this.miEmpresa.Regimen.IdRegimen.Equals(1))
                            {
                                valIvaUtil = Math.Round((valUtil * ivaEdit / 100), 2);
                                //venta = Convert.ToInt32(costo + valUtil + valIvaUtil);
                            }
                            else
                            {
                                //venta = Convert.ToInt32(costo + valUtil);
                            }
                            //venta = Convert.ToInt32(costo + valUtil + valIvaUtil);
                        }
                        else
                        {
                            if (this.CalculoUtilMultiplicado)  // Incremento de utilidad multiplic.
                            {
                                valUtil = Math.Round((costo * utilEdit / 100), 2);
                            }
                            else
                            {
                                valUtil = Math.Round(((costo / ((100 - utilEdit) / 100)) - costo), 2);
                            }
                        }
                        venta = Convert.ToInt32(costo + valUtil + valIvaUtil);
                        venta += Convert.ToInt32(Convert.ToDouble(this.txtIcoPV1.Text.Replace('.', ',')));
                        venta = UseObject.Aproximar(venta, AproxPrecio);
                    }
                    else
                    {
                        venta = Convert.ToInt32(PriceProduct.GetPrice(new PriceProduct
                        {
                            Costo = costo,
                            Util = utilEdit
                        }));
                    }

                    this.txtValorUtilidadP1.Text = valUtil.ToString().Replace(',', '.');
                    this.txtValIvaUtilidadP1.Text = valIvaUtil.ToString().Replace(',', '.');
                    //this.txtValorVentaP1.Text = venta.ToString();
                    ///this.txtValorSugeridoP1.Text = UseObject.Aproximar(venta, AproxPrecio).ToString().Replace(',', '.');
                    this.txtValorSugeridoP1.Text = venta.ToString();
                }
                else  //  indica costo sin iva
                {
                    this.txtValorIvaP1.Text = Math.Round((costo * ivaEdit / 100), 2).ToString().Replace(',', '.');
                    var costoMasIva = Math.Round((costo + Math.Round((costo * ivaEdit / 100), 2)), 2);
                    costoMasIva += Convert.ToDouble(this.txtIcoP1.Text.Replace('.', ','));
                    this.txtCostoConIvaP1.Text = costoMasIva.ToString().Replace(',', '.');

                    var valUtil = 0.0;
                    var valIvaUtil = 0.0;
                    var venta = 0;

                    if (!DefaultUtilPercentage)
                    {

                        if (!this.UtilidadAntesIva)  // Utilidad antes de IVA.
                        {
                            if (this.CalculoUtilMultiplicado)  // Incremento de utilidad multiplic.
                            {
                                valUtil = Math.Round((costo * utilEdit / 100), 2);
                            }
                            else
                            {
                                valUtil = Math.Round(((costo / ((100 - utilEdit) / 100)) - costo), 2);
                            }
                            //valIvaUtil = Math.Round((valUtil * this.MiProducto.ValorIva / 100), 2);
                            if (this.miEmpresa.Regimen.IdRegimen.Equals(1))
                            {
                                valIvaUtil = Math.Round((valUtil * ivaEdit / 100), 2);
                                //venta = Convert.ToInt32(costoMasIva + valUtil + valIvaUtil);
                            }
                            else
                            {
                                //venta = Convert.ToInt32(costoMasIva + valUtil);
                            }
                        }
                        else
                        {
                            if (this.CalculoUtilMultiplicado)  // Incremento de utilidad multiplic.
                            {
                                valUtil = Math.Round((costoMasIva * utilEdit / 100), 2);
                            }
                            else
                            {
                                valUtil = Math.Round(((costoMasIva / ((100 - utilEdit) / 100)) - costoMasIva), 2);
                            }
                        }
                        venta = Convert.ToInt32(costoMasIva + valUtil + valIvaUtil);
                        //venta += Convert.ToInt32(Convert.ToDouble(this.txtIcoPV1.Text.Replace('.', ',')));
                        venta = UseObject.Aproximar(venta, AproxPrecio);
                    }
                    else
                    {
                        venta = Convert.ToInt32(PriceProduct.GetPrice(new PriceProduct
                        {
                            Costo = costoMasIva,
                            Util = utilEdit
                        }));
                    }

                    this.txtValorUtilidadP1.Text = valUtil.ToString().Replace(',', '.');
                    this.txtValIvaUtilidadP1.Text = valIvaUtil.ToString().Replace(',', '.');
                    // this.txtValorVentaP1.Text = venta.ToString();
                    ///this.txtValorSugeridoP1.Text = UseObject.Aproximar(venta, AproxPrecio).ToString().Replace(',', '.');
                    this.txtValorSugeridoP1.Text = venta.ToString();
                }
                this.txtCostoNoIvaP2.Text = this.txtCostoNoIvaP3.Text = this.txtCostoNoIvaP4.Text = this.txtCostoNoIvaP1.Text;
                this.txtValorIvaP2.Text = this.txtValorIvaP3.Text = this.txtValorIvaP4.Text = this.txtValorIvaP1.Text;
                this.txtCostoConIvaP2.Text = this.txtCostoConIvaP3.Text = this.txtCostoConIvaP4.Text = this.txtCostoConIvaP1.Text;
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
        }

        private void EditaVentaPrecioUno(bool venta_, double valor)
        {
            try
            {
                double ivaEdit = ((Iva)cbIvaEditar.SelectedItem).PorcentajeIva;
                double utilEdit = Convert.ToDouble(this.txtUtilidadP1.Text.ToString().Replace('.', ','));

                double costo = Convert.ToDouble(this.txtCostoNoIvaP1.Text.Replace('.', ','));
                double costoMasIva = Convert.ToDouble(this.txtCostoConIvaP1.Text.Replace('.', ','));
                double costoCalculado = 0.0;
                if (venta_) // indica edicion de precio de venta
                {
                    var util = 0.0;
                    var valUtil = 0.0;
                    var valIvaUtil = 0.0;

                    //this.txtValorSugeridoP1.Text = this.txtValorVentaP1.Text;
                    this.txtValorSugeridoP1.Text = UseObject.Aproximar(Convert.ToInt32(valor), AproxPrecio).ToString().Replace(',', '.');
                    valor -= Convert.ToInt32(Convert.ToDouble(this.txtIcoPV1.Text.Replace('.', ',')));
                    if (this.miEmpresa.Regimen.IdRegimen.Equals(1)) //  Regimen   (Comun) 
                    {
                        costoCalculado = costo;
                    }
                    else   //  Regimen   (Simplificado) 
                    {
                        costoCalculado = costoMasIva;
                    }
                    if (!this.UtilidadAntesIva)  // Utilidad antes de IVA.
                    {
                        if (this.miEmpresa.Regimen.IdRegimen.Equals(1)) //  Regimen   (Comun) 
                        {
                            valor = Convert.ToInt32(valor / (1 + (ivaEdit / 100)));
                        }
                    }

                    if (CalculoUtilMultiplicado)
                    {
                        util = Math.Round(Convert.ToDouble(((valor - costoCalculado) * 100) / costoCalculado), 2);
                    }
                    else
                    {
                        var div = Math.Round((costoCalculado / valor), 2);
                        util = Math.Round((100 - ((costoCalculado / valor) * 100)), 1);
                    }
                    //valUtil = Math.Round((valor - costoCalculado), 2);
                    valUtil = Math.Round(((costoCalculado / ((100 - util) / 100)) - costoCalculado), 2);
                    if (this.miEmpresa.Regimen.IdRegimen.Equals(1)) //  Regimen   (Comun) 
                    {
                        valIvaUtil = Math.Round((valUtil * ivaEdit / 100), 2);
                    }

                    this.txtUtilidadP1.Text = util.ToString().Replace(',', '.');
                    this.txtValorUtilidadP1.Text = valUtil.ToString().Replace(',', '.');
                    this.txtValIvaUtilidadP1.Text = valIvaUtil.ToString().Replace(',', '.');
                }
                else  // indica edicion de utilidad
                {
                    var valUtil = 0.0;
                    var valIvaUtil = 0.0;
                    var venta = 0;

                    if (!this.UtilidadAntesIva)  // Utilidad antes de IVA.
                    {
                        if (this.CalculoUtilMultiplicado)  // Incremento de utilidad multiplic.
                        {
                            valUtil = Math.Round((costo * valor / 100), 2);
                        }
                        else
                        {
                            valUtil = Math.Round(((costo / ((100 - valor) / 100)) - costo), 2);
                        }
                        //valIvaUtil = Math.Round((valUtil * this.MiProducto.ValorIva / 100), 2);
                        if (this.miEmpresa.Regimen.IdRegimen.Equals(1))
                        {
                            valIvaUtil = Math.Round((valUtil * ivaEdit / 100), 2);
                            //venta = Convert.ToInt32(costoMasIva + valUtil + valIvaUtil);
                        }
                        else
                        {
                            //venta = Convert.ToInt32(costoMasIva + valUtil);
                        }
                    }
                    else
                    {
                        if (this.CalculoUtilMultiplicado)  // Incremento de utilidad multiplic.
                        {
                            valUtil = Math.Round((costoMasIva * valor / 100), 2);
                        }
                        else
                        {
                            valUtil = Math.Round(((costoMasIva / ((100 - valor) / 100)) - costoMasIva), 2);
                        }
                    }
                    venta = Convert.ToInt32(costoMasIva + valUtil + valIvaUtil);

                    this.txtValorUtilidadP1.Text = valUtil.ToString().Replace(',', '.');
                    this.txtValIvaUtilidadP1.Text = valIvaUtil.ToString().Replace(',', '.');
                    // this.txtValorVentaP1.Text = venta.ToString();
                    this.txtValorSugeridoP1.Text = UseObject.Aproximar(venta, AproxPrecio).ToString().Replace(',', '.');
                }
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
        }

        private void EditPriceOne(bool venta_, double valor)
        {
            PriceProduct p = new PriceProduct
            {
                Costo = Convert.ToDouble(this.txtCostoConIvaP1.Text.Replace('.', ',')),
                Util = Convert.ToDouble(this.txtUtilidadP1.Text.Replace('.', ',')),
                Price = Convert.ToDouble(this.txtValorVentaP1.Text.Replace('.', ','))
            };

            if (venta_)
            {
                this.txtValorSugeridoP1.Text = valor.ToString();
                this.txtUtilidadP1.Text = PriceProduct.GetUtil(p).ToString().Replace(',', '.');
            }
            else
            {
                this.txtValorSugeridoP1.Text = PriceProduct.GetPrice(p).ToString();
            }
        }


        private void EditaCostoPrecioDos(bool iva_, double costo)
        {
            try
            {
                this.txtCostoConIvaP2.Text = this.txtCostoConIvaP1.Text;
                double ivaEdit = ((Iva)cbIvaEditar.SelectedItem).PorcentajeIva;
                double util2Edit = Convert.ToDouble(this.txtUtilidadP2.Text.ToString().Replace('.', ','));
                if (iva_)  // indica costo con iva
                {
                    var costoNoIva = Math.Round((costo / (1 + (ivaEdit / 100))), 2);
                    this.txtCostoNoIvaP2.Text = costoNoIva.ToString().Replace(',', '.');
                    this.txtValorIvaP2.Text = Math.Round((costo - costoNoIva), 2).ToString().Replace(',', '.');

                    var valUtil = 0.0;
                    var valIvaUtil = 0.0;
                    var venta = 0;

                    if (!this.UtilidadAntesIva)  // Utilidad antes de IVA.
                    {
                        if (this.CalculoUtilMultiplicado)  // Incremento de utilidad multiplic.
                        {
                            valUtil = Math.Round((costoNoIva * util2Edit / 100), 2);
                        }
                        else
                        {
                            valUtil = Math.Round(((costoNoIva / ((100 - util2Edit) / 100)) - costoNoIva), 2);
                        }
                        //valIvaUtil = Math.Round((valUtil * this.MiProducto.ValorIva / 100), 2);
                        if (this.miEmpresa.Regimen.IdRegimen.Equals(1))
                        {
                            valIvaUtil = Math.Round((valUtil * ivaEdit / 100), 2);
                            //venta = Convert.ToInt32(costo + valUtil + valIvaUtil);
                        }
                        else
                        {
                            // venta = Convert.ToInt32(costo + valUtil);
                        }
                    }
                    else
                    {
                        if (this.CalculoUtilMultiplicado)  // Incremento de utilidad multiplic.
                        {
                            valUtil = Math.Round((costo * util2Edit / 100), 2);
                        }
                        else
                        {
                            valUtil = Math.Round(((costo / ((100 - util2Edit) / 100)) - costo), 2);
                        }
                    }
                    venta = Convert.ToInt32(costo + valUtil + valIvaUtil);
                    //var pVenta = Convert.ToDouble(this.txtValorSugeridoP1.Text);
                    //var descto = Math.Round((((pVenta - venta) / pVenta) * 100), 1);
                    var pVenta = Convert.ToDouble(this.txtValorVentaP1.Text);
                    var descto = Math.Round((((pVenta - UseObject.Aproximar(venta, AproxPrecio)) / pVenta) * 100), 1);

                    this.txtValorUtilidadP2.Text = valUtil.ToString().Replace(',', '.');
                    this.txtValIvaUtilidadP2.Text = valIvaUtil.ToString().Replace(',', '.');
                    //this.txtValorVentaP2.Text = venta.ToString();
                    this.txtValorSugeridoP2.Text = UseObject.Aproximar(venta, AproxPrecio).ToString().Replace(',', '.');
                    this.txtDescuentoP2.Text = descto.ToString().Replace(',', '.');
                }
                else  //  indica costo sin iva
                {
                    this.txtValorIvaP2.Text = Math.Round((costo * ivaEdit / 100), 2).ToString().Replace(',', '.');
                    var costoMasIva = Math.Round((costo + Math.Round((costo * ivaEdit / 100), 2)), 2);
                    this.txtCostoConIvaP2.Text = costoMasIva.ToString().Replace(',', '.');

                    var valUtil = 0.0;
                    var valIvaUtil = 0.0;
                    var venta = 0;

                    if (!this.UtilidadAntesIva)  // Utilidad antes de IVA.
                    {
                        if (this.CalculoUtilMultiplicado)  // Incremento de utilidad multiplic.
                        {
                            valUtil = Math.Round((costo * util2Edit / 100), 2);
                        }
                        else
                        {
                            valUtil = Math.Round(((costo / ((100 - util2Edit) / 100)) - costo), 2);
                        }
                        //valIvaUtil = Math.Round((valUtil * this.MiProducto.ValorIva / 100), 2);
                        if (this.miEmpresa.Regimen.IdRegimen.Equals(1))
                        {
                            valIvaUtil = Math.Round((valUtil * ivaEdit / 100), 2);
                            //venta = Convert.ToInt32(costoMasIva + valUtil + valIvaUtil);
                        }
                        else
                        {
                            //venta = Convert.ToInt32(costoMasIva + valUtil);
                        }
                    }
                    else
                    {
                        if (this.CalculoUtilMultiplicado)  // Incremento de utilidad multiplic.
                        {
                            valUtil = Math.Round((costoMasIva * util2Edit / 100), 2);
                        }
                        else
                        {
                            valUtil = Math.Round(((costoMasIva / ((100 - util2Edit) / 100)) - costoMasIva), 2);
                        }
                    }
                    venta = Convert.ToInt32(costoMasIva + valUtil + valIvaUtil);
                    //var pVenta = Convert.ToDouble(this.txtValorSugeridoP1.Text);
                    //var descto = Math.Round((((pVenta - venta) / pVenta) * 100), 1);
                    var pVenta = Convert.ToDouble(this.txtValorVentaP1.Text);
                    var descto = Math.Round((((pVenta - UseObject.Aproximar(venta, AproxPrecio)) / pVenta) * 100), 1);

                    this.txtValorUtilidadP2.Text = valUtil.ToString().Replace(',', '.');
                    this.txtValIvaUtilidadP2.Text = valIvaUtil.ToString().Replace(',', '.');
                    //this.txtValorVentaP2.Text = venta.ToString();
                    this.txtValorSugeridoP2.Text = UseObject.Aproximar(venta, AproxPrecio).ToString().Replace(',', '.');
                    this.txtDescuentoP2.Text = descto.ToString().Replace(',', '.');
                }
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
        }

        private void EditaVentaPrecioDos(Calculo c, double valor)
        {
            try
            {
                double ivaEdit = ((Iva)cbIvaEditar.SelectedItem).PorcentajeIva;
                double util2Edit = Convert.ToDouble(this.txtUtilidadP2.Text.ToString().Replace('.', ','));

                //double pVenta = Convert.ToDouble(this.txtValorSugeridoP1.Text);
                double pVenta = Convert.ToDouble(this.txtValorVentaP1.Text);
                double costo = Convert.ToDouble(this.txtCostoNoIvaP2.Text.Replace('.', ','));
                double costoMasIva = Convert.ToDouble(this.txtCostoConIvaP2.Text.Replace('.', ','));
                double costoCalculado = 0.0;
                var util = 0.0;
                var valUtil = 0.0;
                var valIvaUtil = 0.0;
                var venta = 0;
                var descto = 0.0;
                switch (c)
                {
                    case Calculo.Util_:
                        {
                            //***************************************************************************************************************************

                            if (!this.UtilidadAntesIva)  // Utilidad antes de IVA.
                            {
                                if (this.CalculoUtilMultiplicado)  // Incremento de utilidad multiplic.
                                {
                                    valUtil = Math.Round((costo * valor / 100), 2);
                                }
                                else
                                {
                                    valUtil = Math.Round(((costo / ((100 - valor) / 100)) - costo), 2);
                                }
                                //valIvaUtil = Math.Round((valUtil * this.MiProducto.ValorIva / 100), 2);
                                if (this.miEmpresa.Regimen.IdRegimen.Equals(1))
                                {
                                    valIvaUtil = Math.Round((valUtil * ivaEdit / 100), 2);
                                    //venta = Convert.ToInt32(costoMasIva + valUtil + valIvaUtil);
                                }
                                else
                                {
                                    //venta = Convert.ToInt32(costoMasIva + valUtil);
                                }
                            }
                            else
                            {
                                if (this.CalculoUtilMultiplicado)  // Incremento de utilidad multiplic.
                                {
                                    valUtil = Math.Round((costoMasIva * valor / 100), 2);
                                }
                                else
                                {
                                    valUtil = Math.Round(((costoMasIva / ((100 - valor) / 100)) - costoMasIva), 2);
                                }
                            }
                            venta = Convert.ToInt32(costoMasIva + valUtil + valIvaUtil);
                            if (this.RedondearPrecio2)
                            {
                                venta = UseObject.Aproximar(venta, AproxPrecio);
                            }
                            this.txtValorSugeridoP2.Text = venta.ToString().Replace(',', '.');

                            venta -= Convert.ToInt32(Convert.ToDouble(this.txtIcoPV1.Text.Replace('.', ',')));
                            pVenta -= Convert.ToInt32(Convert.ToDouble(this.txtIcoPV1.Text.Replace('.', ',')));

                            descto = Math.Round((((pVenta - venta) / pVenta) * 100), 3);

                            this.txtValorUtilidadP2.Text = valUtil.ToString().Replace(',', '.');
                            this.txtValIvaUtilidadP2.Text = valIvaUtil.ToString().Replace(',', '.');
                              //this.txtValorVentaP2.Text = venta.ToString();
                              //this.txtValorSugeridoP2.Text = UseObject.Aproximar(venta, AproxPrecio).ToString().Replace(',', '.');
                            this.txtDescuentoP2.Text = descto.ToString().Replace(',', '.');


                            /*venta = Convert.ToInt32(costoMasIva + valUtil + valIvaUtil);
                              //descto = Math.Round((((pVenta - venta) / pVenta) * 100), 1);
                            descto = Math.Round((((pVenta - UseObject.Aproximar(venta, AproxPrecio)) / pVenta) * 100), 3);

                            this.txtValorUtilidadP2.Text = valUtil.ToString().Replace(',', '.');
                            this.txtValIvaUtilidadP2.Text = valIvaUtil.ToString().Replace(',', '.');
                              //this.txtValorVentaP2.Text = venta.ToString();
                            this.txtValorSugeridoP2.Text = UseObject.Aproximar(venta, AproxPrecio).ToString().Replace(',', '.');
                            this.txtDescuentoP2.Text = descto.ToString().Replace(',', '.');*/

                            //***************************************************************************************************************************
                            break;
                        }
                    case Calculo.Pventa:
                        {
                            //***************************************************************************************************************************

                            this.txtValorSugeridoP2.Text = UseObject.Aproximar(Convert.ToInt32(valor), AproxPrecio).ToString().Replace(',', '.');

                            var valorTemp = valor - Convert.ToInt32(Convert.ToDouble(this.txtIcoPV1.Text.Replace('.', ',')));
                            //this.txtValorSugeridoP2.Text = this.txtValorVentaP2.Text;

                            valor -= Convert.ToInt32(Convert.ToDouble(this.txtIcoPV1.Text.Replace('.', ',')));

                            if (this.miEmpresa.Regimen.IdRegimen.Equals(1)) //  Regimen   (Comun) 
                            {
                                costoCalculado = costo;
                            }
                            else   //  Regimen   (Simplificado) 
                            {
                                costoCalculado = costoMasIva;
                            }
                            if (!this.UtilidadAntesIva)  // Utilidad antes de IVA.
                            {
                                if (this.miEmpresa.Regimen.IdRegimen.Equals(1)) //  Regimen   (Comun) 
                                {
                                    valor = Convert.ToInt32(valor / (1 + (ivaEdit / 100)));
                                }
                            }

                            if (CalculoUtilMultiplicado)
                            {
                                util = Math.Round(Convert.ToDouble(((valor - costoCalculado) * 100) / costoCalculado), 2);
                            }
                            else
                            {
                                var div = Math.Round((costoCalculado / valor), 2);
                                util = Math.Round((100 - ((costoCalculado / valor) * 100)), 1);
                            }
                            //valUtil = Math.Round((valor - costoCalculado), 2);
                            valUtil = Math.Round(((costoCalculado / ((100 - util) / 100)) - costoCalculado), 2);
                            if (this.miEmpresa.Regimen.IdRegimen.Equals(1)) //  Regimen   (Comun) 
                            {
                                valIvaUtil = Math.Round((valUtil * ivaEdit / 100), 2);
                            }
                            pVenta -= Convert.ToInt32(Convert.ToDouble(this.txtIcoPV1.Text.Replace('.', ',')));
                            descto = Math.Round((((pVenta - valorTemp) / pVenta) * 100), 3);  //

                            this.txtUtilidadP2.Text = util.ToString().Replace(',', '.');
                            this.txtValorUtilidadP2.Text = valUtil.ToString().Replace(',', '.');
                            this.txtValIvaUtilidadP2.Text = valIvaUtil.ToString().Replace(',', '.');
                            this.txtDescuentoP2.Text = descto.ToString().Replace(',', '.');

                            //***************************************************************************************************************************
                            break;
                        }
                    case Calculo.Descto:
                        {
                            //***************************************************************************************************************************
                            // valor  viene sin impoconsumo.
                            var valorTemp = valor;

                            //valor -= Convert.ToInt32(Convert.ToDouble(this.txtIcoPV1.Text.Replace('.', ',')));

                            //this.txtValorSugeridoP2.Text = this.txtValorVentaP2.Text;
                            if (this.miEmpresa.Regimen.IdRegimen.Equals(1)) //  Regimen   (Comun) 
                            {
                                costoCalculado = costo;
                            }
                            else   //  Regimen   (Simplificado) 
                            {
                                costoCalculado = costoMasIva;
                            }
                            if (!this.UtilidadAntesIva)  // Utilidad antes de IVA.
                            {
                                if (this.miEmpresa.Regimen.IdRegimen.Equals(1)) //  Regimen   (Comun) 
                                {
                                    valor = Convert.ToInt32(valor / (1 + (ivaEdit / 100)));
                                }
                            }

                            if (CalculoUtilMultiplicado)
                            {
                                util = Math.Round(Convert.ToDouble(((valor - costoCalculado) * 100) / costoCalculado), 2);
                            }
                            else
                            {
                                var div = Math.Round((costoCalculado / valor), 2);
                                util = Math.Round((100 - ((costoCalculado / valor) * 100)), 1);
                            }
                            //valUtil = Math.Round((valor - costoCalculado), 2);
                            valUtil = Math.Round(((costoCalculado / ((100 - util) / 100)) - costoCalculado), 2);
                            if (this.miEmpresa.Regimen.IdRegimen.Equals(1)) //  Regimen   (Comun) 
                            {
                                valIvaUtil = Math.Round((valUtil * ivaEdit / 100), 2);
                            }
                            //descto = Math.Round((((pVenta - valorTemp) / pVenta) * 100), 1);  Convert.ToInt32(Convert.ToDouble(this.txtIcoP1.Text.Replace('.', ',')));

                            valorTemp += Convert.ToInt32(Convert.ToDouble(this.txtIcoP1.Text.Replace('.', ','))); //  Convert.ToInt32(this.MiProducto.Impoconsumo);  revisar como utilizar el objeto producto.impoconsumo para esta linea.

                            this.txtUtilidadP2.Text = util.ToString().Replace(',', '.');
                            this.txtValorUtilidadP2.Text = valUtil.ToString().Replace(',', '.');
                            this.txtValIvaUtilidadP2.Text = valIvaUtil.ToString().Replace(',', '.');
                            this.txtValorVentaP2.Text = valorTemp.ToString();
                            this.txtValorSugeridoP2.Text = UseObject.Aproximar(Convert.ToInt32(valorTemp), AproxPrecio).ToString().Replace(',', '.');
                            //this.txtDescuentoP2.Text = descto.ToString().Replace(',', '.');

                            //***************************************************************************************************************************
                            break;
                        }
                }
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
        }


        private void EditaCostoPrecioTres(bool iva_, double costo)
        {
            try
            {
                this.txtCostoConIvaP3.Text = this.txtCostoConIvaP1.Text;
                double ivaEdit = ((Iva)cbIvaEditar.SelectedItem).PorcentajeIva;
                double util3Edit = Convert.ToDouble(this.txtUtilidadP3.Text.ToString().Replace('.', ','));
                if (iva_)  // indica costo con iva
                {
                    var costoNoIva = Math.Round((costo / (1 + (this.MiProducto.ValorIva / 100))), 2);
                    this.txtCostoNoIvaP3.Text = costoNoIva.ToString().Replace(',', '.');
                    this.txtValorIvaP3.Text = Math.Round((costo - costoNoIva), 2).ToString().Replace(',', '.');

                    var valUtil = 0.0;
                    var valIvaUtil = 0.0;
                    var venta = 0;

                    if (!this.UtilidadAntesIva)  // Utilidad antes de IVA.
                    {
                        if (this.CalculoUtilMultiplicado)  // Incremento de utilidad multiplic.
                        {
                            valUtil = Math.Round((costoNoIva * util3Edit / 100), 2);
                        }
                        else
                        {
                            valUtil = Math.Round(((costoNoIva / ((100 - util3Edit) / 100)) - costoNoIva), 2);
                        }
                        //valIvaUtil = Math.Round((valUtil * this.MiProducto.ValorIva / 100), 2);
                        if (this.miEmpresa.Regimen.IdRegimen.Equals(1))
                        {
                            valIvaUtil = Math.Round((valUtil * ivaEdit / 100), 2);
                            //venta = Convert.ToInt32(costo + valUtil + valIvaUtil);
                        }
                        else
                        {
                            //venta = Convert.ToInt32(costo + valUtil);
                        }
                    }
                    else
                    {
                        if (this.CalculoUtilMultiplicado)  // Incremento de utilidad multiplic.
                        {
                            valUtil = Math.Round((costo * util3Edit / 100), 2);
                        }
                        else
                        {
                            valUtil = Math.Round(((costo / ((100 - util3Edit) / 100)) - costo), 2);
                        }
                    }
                    venta = Convert.ToInt32(costo + valUtil + valIvaUtil);
                    var pVenta = Convert.ToDouble(this.txtValorSugeridoP1.Text);
                    //var descto = Math.Round((((pVenta - venta) / pVenta) * 100), 1);
                    var descto = Math.Round((((pVenta - UseObject.Aproximar(venta, AproxPrecio)) / pVenta) * 100), 1);


                    this.txtValorUtilidadP3.Text = valUtil.ToString().Replace(',', '.');
                    this.txtValIvaUtilidadP3.Text = valIvaUtil.ToString().Replace(',', '.');
                    //this.txtValorVentaP3.Text = venta.ToString();
                    this.txtValorSugeridoP3.Text = UseObject.Aproximar(venta, AproxPrecio).ToString().Replace(',', '.');
                    this.txtDescuentoP3.Text = descto.ToString().Replace(',', '.');
                }
                else  //  indica costo sin iva
                {
                    this.txtValorIvaP3.Text = Math.Round((costo * this.MiProducto.ValorIva / 100), 2).ToString().Replace(',', '.');
                    var costoMasIva = Math.Round((costo + Math.Round((costo * this.MiProducto.ValorIva / 100), 2)), 2);
                    this.txtCostoConIvaP3.Text = costoMasIva.ToString().Replace(',', '.');

                    var valUtil = 0.0;
                    var valIvaUtil = 0.0;
                    var venta = 0;

                    if (!this.UtilidadAntesIva)  // Utilidad antes de IVA.
                    {
                        if (this.CalculoUtilMultiplicado)  // Incremento de utilidad multiplic.
                        {
                            valUtil = Math.Round((costo * util3Edit / 100), 2);
                        }
                        else
                        {
                            valUtil = Math.Round(((costo / ((100 - util3Edit) / 100)) - costo), 2);
                        }
                        //valIvaUtil = Math.Round((valUtil * this.MiProducto.ValorIva / 100), 2);
                        if (this.miEmpresa.Regimen.IdRegimen.Equals(1))
                        {
                            valIvaUtil = Math.Round((valUtil * ivaEdit / 100), 2);
                            //venta = Convert.ToInt32(costoMasIva + valUtil + valIvaUtil);
                        }
                        else
                        {
                            // venta = Convert.ToInt32(costoMasIva + valUtil);
                        }
                    }
                    else
                    {
                        if (this.CalculoUtilMultiplicado)  // Incremento de utilidad multiplic.
                        {
                            valUtil = Math.Round((costoMasIva * util3Edit / 100), 2);
                        }
                        else
                        {
                            valUtil = Math.Round(((costoMasIva / ((100 - util3Edit) / 100)) - costoMasIva), 2);
                        }
                    }
                    venta = Convert.ToInt32(costoMasIva + valUtil + valIvaUtil);
                    var pVenta = Convert.ToDouble(this.txtValorSugeridoP1.Text);
                    //var descto = Math.Round((((pVenta - venta) / pVenta) * 100), 1);
                    var descto = Math.Round((((pVenta - UseObject.Aproximar(venta, AproxPrecio)) / pVenta) * 100), 1);

                    this.txtValorUtilidadP3.Text = valUtil.ToString().Replace(',', '.');
                    this.txtValIvaUtilidadP3.Text = valIvaUtil.ToString().Replace(',', '.');
                    //this.txtValorVentaP3.Text = venta.ToString();
                    this.txtValorSugeridoP3.Text = UseObject.Aproximar(venta, AproxPrecio).ToString().Replace(',', '.');
                    this.txtDescuentoP3.Text = descto.ToString().Replace(',', '.');
                }
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
        }

        private void EditaVentaPrecioTres(Calculo c, double valor)
        {
            try
            {
                double ivaEdit = ((Iva)cbIvaEditar.SelectedItem).PorcentajeIva;
                //double util3Edit = Convert.ToDouble(this.txtUtilidadP3.Text.ToString().Replace('.', ','));

                //double pVenta = Convert.ToDouble(this.txtValorSugeridoP1.Text);
                double pVenta = Convert.ToDouble(this.txtValorVentaP1.Text);
                double costo = Convert.ToDouble(this.txtCostoNoIvaP3.Text.Replace('.', ','));
                double costoMasIva = Convert.ToDouble(this.txtCostoConIvaP3.Text.Replace('.', ','));
                double costoCalculado = 0.0;
                var util = 0.0;
                var valUtil = 0.0;
                var valIvaUtil = 0.0;
                var venta = 0;
                var descto = 0.0;
                switch (c)
                {
                    case Calculo.Util_:
                        {
                            //***************************************************************************************************************************

                            if (!this.UtilidadAntesIva)  // Utilidad antes de IVA.
                            {
                                if (this.CalculoUtilMultiplicado)  // Incremento de utilidad multiplic.
                                {
                                    valUtil = Math.Round((costo * valor / 100), 2);
                                }
                                else
                                {
                                    valUtil = Math.Round(((costo / ((100 - valor) / 100)) - costo), 2);
                                }
                                //valIvaUtil = Math.Round((valUtil * this.MiProducto.ValorIva / 100), 2);
                                if (this.miEmpresa.Regimen.IdRegimen.Equals(1))
                                {
                                    valIvaUtil = Math.Round((valUtil * ivaEdit / 100), 2);
                                    //venta = Convert.ToInt32(costoMasIva + valUtil + valIvaUtil);
                                }
                                else
                                {
                                    //venta = Convert.ToInt32(costoMasIva + valUtil);
                                }
                            }
                            else
                            {
                                if (this.CalculoUtilMultiplicado)  // Incremento de utilidad multiplic.
                                {
                                    valUtil = Math.Round((costoMasIva * valor / 100), 2);
                                }
                                else
                                {
                                    valUtil = Math.Round(((costoMasIva / ((100 - valor) / 100)) - costoMasIva), 2);
                                }
                            }
                            venta = UseObject.Aproximar(Convert.ToInt32(costoMasIva + valUtil + valIvaUtil), AproxPrecio);
                            /*if (this.RedondearPrecio2)
                            {
                                venta = UseObject.Aproximar(venta, AproxPrecio);
                            }*/
                            this.txtValorSugeridoP3.Text = venta.ToString().Replace(',', '.');

                            venta -= Convert.ToInt32(Convert.ToDouble(this.txtIcoPV1.Text.Replace('.', ',')));
                            pVenta -= Convert.ToInt32(Convert.ToDouble(this.txtIcoPV1.Text.Replace('.', ',')));

                            descto = Math.Round((((pVenta - venta) / pVenta) * 100), 3);

                              //descto = Math.Round((((pVenta - UseObject.Aproximar(venta, AproxPrecio)) / pVenta) * 100), 3);

                            this.txtValorUtilidadP3.Text = valUtil.ToString().Replace(',', '.');
                            this.txtValIvaUtilidadP3.Text = valIvaUtil.ToString().Replace(',', '.');
                              //this.txtValorVentaP3.Text = venta.ToString();
                              //this.txtValorSugeridoP3.Text = UseObject.Aproximar(venta, AproxPrecio).ToString().Replace(',', '.');
                            this.txtDescuentoP3.Text = descto.ToString().Replace(',', '.');

                            //***************************************************************************************************************************
                            break;
                        }
                    case Calculo.Pventa:
                        {
                            //***************************************************************************************************************************
                            var valorTemp = valor - Convert.ToInt32(Convert.ToDouble(this.txtIcoPV1.Text.Replace('.', ',')));

                            this.txtValorSugeridoP3.Text = UseObject.Aproximar(Convert.ToInt32(valor), AproxPrecio).ToString().Replace(',', '.');

                            valor -= Convert.ToInt32(Convert.ToDouble(this.txtIcoPV1.Text.Replace('.', ',')));

                            //this.txtValorSugeridoP3.Text = this.txtValorVentaP3.Text;
                            
                            if (this.miEmpresa.Regimen.IdRegimen.Equals(1)) //  Regimen   (Comun) 
                            {
                                costoCalculado = costo;
                            }
                            else   //  Regimen   (Simplificado) 
                            {
                                costoCalculado = costoMasIva;
                            }
                            if (!this.UtilidadAntesIva)  // Utilidad antes de IVA.
                            {
                                if (this.miEmpresa.Regimen.IdRegimen.Equals(1)) //  Regimen   (Comun) 
                                {
                                    valor = Convert.ToInt32(valor / (1 + (ivaEdit / 100)));
                                }
                            }

                            if (CalculoUtilMultiplicado)
                            {
                                util = Math.Round(Convert.ToDouble(((valor - costoCalculado) * 100) / costoCalculado), 2);
                            }
                            else
                            {
                                var div = Math.Round((costoCalculado / valor), 2);
                                util = Math.Round((100 - ((costoCalculado / valor) * 100)), 1);
                            }
                            //valUtil = Math.Round((valor - costoCalculado), 2);
                            valUtil = Math.Round(((costoCalculado / ((100 - util) / 100)) - costoCalculado), 2);
                            if (this.miEmpresa.Regimen.IdRegimen.Equals(1)) //  Regimen   (Comun) 
                            {
                                valIvaUtil = Math.Round((valUtil * ivaEdit / 100), 2);
                            }
                            pVenta -= Convert.ToInt32(Convert.ToDouble(this.txtIcoPV1.Text.Replace('.', ',')));
                            descto = Math.Round((((pVenta - valorTemp) / pVenta) * 100), 3);

                            this.txtUtilidadP3.Text = util.ToString().Replace(',', '.');
                            this.txtValorUtilidadP3.Text = valUtil.ToString().Replace(',', '.');
                            this.txtValIvaUtilidadP3.Text = valIvaUtil.ToString().Replace(',', '.');
                            this.txtDescuentoP3.Text = descto.ToString().Replace(',', '.');

                            //***************************************************************************************************************************
                            break;
                        }
                    case Calculo.Descto:
                        {
                            //***************************************************************************************************************************

                            var valorTemp = valor;

                            //valor -= Convert.ToInt32(Convert.ToDouble(this.txtIcoPV1.Text.Replace('.', ',')));

                            // this.txtValorSugeridoP3.Text = this.txtValorVentaP3.Text;
                            if (this.miEmpresa.Regimen.IdRegimen.Equals(1)) //  Regimen   (Comun) 
                            {
                                costoCalculado = costo;
                            }
                            else   //  Regimen   (Simplificado) 
                            {
                                costoCalculado = costoMasIva;
                            }
                            if (!this.UtilidadAntesIva)  // Utilidad antes de IVA.
                            {
                                if (this.miEmpresa.Regimen.IdRegimen.Equals(1)) //  Regimen   (Comun) 
                                {
                                    valor = Convert.ToInt32(valor / (1 + (ivaEdit / 100)));
                                }
                            }

                            if (CalculoUtilMultiplicado)
                            {
                                util = Math.Round(Convert.ToDouble(((valor - costoCalculado) * 100) / costoCalculado), 2);
                            }
                            else
                            {
                                var div = Math.Round((costoCalculado / valor), 2);
                                util = Math.Round((100 - ((costoCalculado / valor) * 100)), 1);
                            }
                            //valUtil = Math.Round((valor - costoCalculado), 2);
                            valUtil = Math.Round(((costoCalculado / ((100 - util) / 100)) - costoCalculado), 2);
                            if (this.miEmpresa.Regimen.IdRegimen.Equals(1)) //  Regimen   (Comun) 
                            {
                                valIvaUtil = Math.Round((valUtil * ivaEdit / 100), 3);
                            }
                            //descto = Math.Round((((pVenta - valorTemp) / pVenta) * 100), 1);

                            //valorTemp += Convert.ToInt32(this.MiProducto.Impoconsumo);
                            valorTemp += Convert.ToInt32(Convert.ToDouble(this.txtIcoP1.Text.Replace('.', ','))); //  Convert.ToInt32(this.MiProducto.Impoconsumo);  revisar como utilizar el objeto producto.impoconsumo para esta linea.

                            this.txtUtilidadP3.Text = util.ToString().Replace(',', '.');
                            this.txtValorUtilidadP3.Text = valUtil.ToString().Replace(',', '.');
                            this.txtValIvaUtilidadP3.Text = valIvaUtil.ToString().Replace(',', '.');
                            this.txtValorVentaP3.Text = valorTemp.ToString();
                            this.txtValorSugeridoP3.Text = UseObject.Aproximar(Convert.ToInt32(valorTemp), AproxPrecio).ToString().Replace(',', '.');
                            //this.txtDescuentoP2.Text = descto.ToString().Replace(',', '.');

                            //***************************************************************************************************************************
                            break;
                        }
                }
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
        }


        private void EditaCostoPrecioCuatro(bool iva_, double costo)
        {
            try
            {
                this.txtCostoConIvaP4.Text = this.txtCostoConIvaP1.Text;
                double ivaEdit = ((Iva)cbIvaEditar.SelectedItem).PorcentajeIva;
                double util4Edit = Convert.ToDouble(this.txtUtilidadP4.Text.ToString().Replace('.', ','));
                if (iva_)  // indica costo con iva
                {
                    var costoNoIva = Math.Round((costo / (1 + (this.MiProducto.ValorIva / 100))), 2);
                    this.txtCostoNoIvaP4.Text = costoNoIva.ToString().Replace(',', '.');
                    this.txtValorIvaP4.Text = Math.Round((costo - costoNoIva), 2).ToString().Replace(',', '.');

                    var valUtil = 0.0;
                    var valIvaUtil = 0.0;
                    var venta = 0;

                    if (!this.UtilidadAntesIva)  // Utilidad antes de IVA.
                    {
                        if (this.CalculoUtilMultiplicado)  // Incremento de utilidad multiplic.
                        {
                            valUtil = Math.Round((costoNoIva * util4Edit / 100), 2);
                        }
                        else
                        {
                            valUtil = Math.Round(((costoNoIva / ((100 - util4Edit) / 100)) - costoNoIva), 2);
                        }
                        //valIvaUtil = Math.Round((valUtil * this.MiProducto.ValorIva / 100), 2);
                        if (this.miEmpresa.Regimen.IdRegimen.Equals(1))
                        {
                            valIvaUtil = Math.Round((valUtil * ivaEdit / 100), 2);
                            //venta = Convert.ToInt32(costo + valUtil + valIvaUtil);
                        }
                        else
                        {
                            //venta = Convert.ToInt32(costo + valUtil);
                        }
                    }
                    else
                    {
                        if (this.CalculoUtilMultiplicado)  // Incremento de utilidad multiplic.
                        {
                            valUtil = Math.Round((costo * util4Edit / 100), 2);
                        }
                        else
                        {
                            valUtil = Math.Round(((costo / ((100 - util4Edit) / 100)) - costo), 2);
                        }
                    }
                    venta = Convert.ToInt32(costo + valUtil + valIvaUtil);
                    var pVenta = Convert.ToDouble(this.txtValorSugeridoP1.Text);
                    //var descto = Math.Round((((pVenta - venta) / pVenta) * 100), 1);
                    var descto = Math.Round((((pVenta - UseObject.Aproximar(venta, AproxPrecio)) / pVenta) * 100), 1);


                    this.txtValorUtilidadP4.Text = valUtil.ToString().Replace(',', '.');
                    this.txtValIvaUtilidadP4.Text = valIvaUtil.ToString().Replace(',', '.');
                    //this.txtValorVentaP3.Text = venta.ToString();
                    this.txtValorSugeridoP4.Text = UseObject.Aproximar(venta, AproxPrecio).ToString().Replace(',', '.');
                    this.txtDescuentoP4.Text = descto.ToString().Replace(',', '.');
                }
                else  //  indica costo sin iva
                {
                    this.txtValorIvaP4.Text = Math.Round((costo * this.MiProducto.ValorIva / 100), 2).ToString().Replace(',', '.');
                    var costoMasIva = Math.Round((costo + Math.Round((costo * this.MiProducto.ValorIva / 100), 2)), 2);
                    this.txtCostoConIvaP4.Text = costoMasIva.ToString().Replace(',', '.');

                    var valUtil = 0.0;
                    var valIvaUtil = 0.0;
                    var venta = 0;

                    if (!this.UtilidadAntesIva)  // Utilidad antes de IVA.
                    {
                        if (this.CalculoUtilMultiplicado)  // Incremento de utilidad multiplic.
                        {
                            valUtil = Math.Round((costo * util4Edit / 100), 2);
                        }
                        else
                        {
                            valUtil = Math.Round(((costo / ((100 - util4Edit) / 100)) - costo), 2);
                        }
                        //valIvaUtil = Math.Round((valUtil * this.MiProducto.ValorIva / 100), 2);
                        if (this.miEmpresa.Regimen.IdRegimen.Equals(1))
                        {
                            valIvaUtil = Math.Round((valUtil * ivaEdit / 100), 2);
                            //venta = Convert.ToInt32(costoMasIva + valUtil + valIvaUtil);
                        }
                        else
                        {
                            // venta = Convert.ToInt32(costoMasIva + valUtil);
                        }
                    }
                    else
                    {
                        if (this.CalculoUtilMultiplicado)  // Incremento de utilidad multiplic.
                        {
                            valUtil = Math.Round((costoMasIva * util4Edit / 100), 2);
                        }
                        else
                        {
                            valUtil = Math.Round(((costoMasIva / ((100 - util4Edit) / 100)) - costoMasIva), 2);
                        }
                    }
                    venta = Convert.ToInt32(costoMasIva + valUtil + valIvaUtil);
                    var pVenta = Convert.ToDouble(this.txtValorSugeridoP1.Text);
                    //var descto = Math.Round((((pVenta - venta) / pVenta) * 100), 1);
                    var descto = Math.Round((((pVenta - UseObject.Aproximar(venta, AproxPrecio)) / pVenta) * 100), 1);

                    this.txtValorUtilidadP4.Text = valUtil.ToString().Replace(',', '.');
                    this.txtValIvaUtilidadP4.Text = valIvaUtil.ToString().Replace(',', '.');
                    //this.txtValorVentaP3.Text = venta.ToString();
                    this.txtValorSugeridoP4.Text = UseObject.Aproximar(venta, AproxPrecio).ToString().Replace(',', '.');
                    this.txtDescuentoP4.Text = descto.ToString().Replace(',', '.');
                }
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
        }

        private void EditaVentaPrecioCuatro(Calculo c, double valor)
        {
            try
            {
                double ivaEdit = ((Iva)cbIvaEditar.SelectedItem).PorcentajeIva;
                //double util3Edit = Convert.ToDouble(this.txtUtilidadP3.Text.ToString().Replace('.', ','));

                //double pVenta = Convert.ToDouble(this.txtValorSugeridoP1.Text);
                double pVenta = Convert.ToDouble(this.txtValorVentaP1.Text);
                double costo = Convert.ToDouble(this.txtCostoNoIvaP4.Text.Replace('.', ','));
                double costoMasIva = Convert.ToDouble(this.txtCostoConIvaP4.Text.Replace('.', ','));
                double costoCalculado = 0.0;
                var util = 0.0;
                var valUtil = 0.0;
                var valIvaUtil = 0.0;
                var venta = 0;
                var descto = 0.0;
                switch (c)
                {
                    case Calculo.Util_:
                        {
                            //***************************************************************************************************************************

                            if (!this.UtilidadAntesIva)  // Utilidad antes de IVA.
                            {
                                if (this.CalculoUtilMultiplicado)  // Incremento de utilidad multiplic.
                                {
                                    valUtil = Math.Round((costo * valor / 100), 2);
                                }
                                else
                                {
                                    valUtil = Math.Round(((costo / ((100 - valor) / 100)) - costo), 2);
                                }
                                //valIvaUtil = Math.Round((valUtil * this.MiProducto.ValorIva / 100), 2);
                                if (this.miEmpresa.Regimen.IdRegimen.Equals(1))
                                {
                                    valIvaUtil = Math.Round((valUtil * ivaEdit / 100), 2);
                                    //venta = Convert.ToInt32(costoMasIva + valUtil + valIvaUtil);
                                }
                                else
                                {
                                    //venta = Convert.ToInt32(costoMasIva + valUtil);
                                }
                            }
                            else
                            {
                                if (this.CalculoUtilMultiplicado)  // Incremento de utilidad multiplic.
                                {
                                    valUtil = Math.Round((costoMasIva * valor / 100), 2);
                                }
                                else
                                {
                                    valUtil = Math.Round(((costoMasIva / ((100 - valor) / 100)) - costoMasIva), 2);
                                }
                            }
                            venta = UseObject.Aproximar(Convert.ToInt32(costoMasIva + valUtil + valIvaUtil), AproxPrecio);
                            this.txtValorSugeridoP4.Text = venta.ToString().Replace(',', '.');

                            venta -= Convert.ToInt32(Convert.ToDouble(this.txtIcoPV1.Text.Replace('.', ',')));
                            pVenta -= Convert.ToInt32(Convert.ToDouble(this.txtIcoPV1.Text.Replace('.', ',')));

                            descto = Math.Round((((pVenta - venta) / pVenta) * 100), 3);

                              //venta = Convert.ToInt32(costo + valUtil + valIvaUtil);
                              //
                              //descto = Math.Round((((pVenta - UseObject.Aproximar(venta, AproxPrecio)) / pVenta) * 100), 3);

                            this.txtValorUtilidadP4.Text = valUtil.ToString().Replace(',', '.');
                            this.txtValIvaUtilidadP4.Text = valIvaUtil.ToString().Replace(',', '.');

                            //venta += Convert.ToInt32(this.MiProducto.Impoconsumo); 

                            //this.txtValorVentaP3.Text = venta.ToString();
                            //this.txtValorSugeridoP4.Text = UseObject.Aproximar(venta, AproxPrecio).ToString().Replace(',', '.');
                            this.txtDescuentoP4.Text = descto.ToString().Replace(',', '.');

                            //***************************************************************************************************************************
                            break;
                        }
                    case Calculo.Pventa:
                        {
                            //***************************************************************************************************************************
                            //valor -= Convert.ToDouble(this.txtIcoP1.Text.Replace('.', ','));
                            var valorTemp = valor - Convert.ToInt32(Convert.ToDouble(this.txtIcoPV1.Text.Replace('.', ',')));
                            this.txtValorSugeridoP4.Text = UseObject.Aproximar(Convert.ToInt32(valor), AproxPrecio).ToString().Replace(',', '.');

                            valor -= Convert.ToInt32(Convert.ToDouble(this.txtIcoPV1.Text.Replace('.', ',')));
                           
                            if (this.miEmpresa.Regimen.IdRegimen.Equals(1)) //  Regimen   (Comun) 
                            {
                                costoCalculado = costo;
                            }
                            else   //  Regimen   (Simplificado) 
                            {
                                costoCalculado = costoMasIva;
                            }
                            if (!this.UtilidadAntesIva)  // Utilidad antes de IVA.
                            {
                                if (this.miEmpresa.Regimen.IdRegimen.Equals(1)) //  Regimen   (Comun) 
                                {
                                    valor = Convert.ToInt32(valor / (1 + (ivaEdit / 100)));
                                }
                            }

                            if (CalculoUtilMultiplicado)
                            {
                                util = Math.Round(Convert.ToDouble(((valor - costoCalculado) * 100) / costoCalculado), 2);
                            }
                            else
                            {
                                var div = Math.Round((costoCalculado / valor), 2);
                                util = Math.Round((100 - ((costoCalculado / valor) * 100)), 1);
                            }
                            //valUtil = Math.Round((valor - costoCalculado), 2);
                            valUtil = Math.Round(((costoCalculado / ((100 - util) / 100)) - costoCalculado), 2);
                            if (this.miEmpresa.Regimen.IdRegimen.Equals(1)) //  Regimen   (Comun) 
                            {
                                valIvaUtil = Math.Round((valUtil * ivaEdit / 100), 2);
                            }
                            pVenta -= Convert.ToInt32(Convert.ToDouble(this.txtIcoPV1.Text.Replace('.', ',')));
                            descto = Math.Round((((pVenta - valorTemp) / pVenta) * 100), 3);

                            this.txtUtilidadP4.Text = util.ToString().Replace(',', '.');
                            this.txtValorUtilidadP4.Text = valUtil.ToString().Replace(',', '.');
                            this.txtValIvaUtilidadP4.Text = valIvaUtil.ToString().Replace(',', '.');
                            this.txtDescuentoP4.Text = descto.ToString().Replace(',', '.');

                            //***************************************************************************************************************************
                            break;
                        }
                    case Calculo.Descto:
                        {
                            //***************************************************************************************************************************

                            var valorTemp = valor;

                            //valor -= Convert.ToInt32(Convert.ToDouble(this.txtIcoPV1.Text.Replace('.', ',')));

                            // this.txtValorSugeridoP3.Text = this.txtValorVentaP3.Text;
                            if (this.miEmpresa.Regimen.IdRegimen.Equals(1)) //  Regimen   (Comun) 
                            {
                                costoCalculado = costo;
                            }
                            else   //  Regimen   (Simplificado) 
                            {
                                costoCalculado = costoMasIva;
                            }
                            if (!this.UtilidadAntesIva)  // Utilidad antes de IVA.
                            {
                                if (this.miEmpresa.Regimen.IdRegimen.Equals(1)) //  Regimen   (Comun) 
                                {
                                    valor = Convert.ToInt32(valor / (1 + (ivaEdit / 100)));
                                }
                            }

                            if (CalculoUtilMultiplicado)
                            {
                                util = Math.Round(Convert.ToDouble(((valor - costoCalculado) * 100) / costoCalculado), 2);
                            }
                            else
                            {
                                var div = Math.Round((costoCalculado / valor), 2);
                                util = Math.Round((100 - ((costoCalculado / valor) * 100)), 1);
                            }
                            //valUtil = Math.Round((valor - costoCalculado), 2);
                            valUtil = Math.Round(((costoCalculado / ((100 - util) / 100)) - costoCalculado), 2);
                            if (this.miEmpresa.Regimen.IdRegimen.Equals(1)) //  Regimen   (Comun) 
                            {
                                valIvaUtil = Math.Round((valUtil * ivaEdit / 100), 2);
                            }
                            //descto = Math.Round((((pVenta - valorTemp) / pVenta) * 100), 1);

                            //valorTemp += Convert.ToInt32(this.MiProducto.Impoconsumo);
                            valorTemp += Convert.ToInt32(Convert.ToDouble(this.txtIcoP1.Text.Replace('.', ','))); //  Convert.ToInt32(this.MiProducto.Impoconsumo);  revisar como utilizar el objeto producto.impoconsumo para esta linea.

                            this.txtUtilidadP4.Text = util.ToString().Replace(',', '.');
                            this.txtValorUtilidadP4.Text = valUtil.ToString().Replace(',', '.');
                            this.txtValIvaUtilidadP4.Text = valIvaUtil.ToString().Replace(',', '.');
                            this.txtValorVentaP4.Text = valorTemp.ToString();
                            this.txtValorSugeridoP4.Text = UseObject.Aproximar(Convert.ToInt32(valorTemp), AproxPrecio).ToString().Replace(',', '.');
                            //this.txtDescuentoP2.Text = descto.ToString().Replace(',', '.');

                            //***************************************************************************************************************************
                            break;
                        }
                }
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
        }





        private bool ValidacionGuardado()
        {
            if (Convert.ToDouble(this.txtCostoNoIvaP1.Text.Replace('.', ',')) < 0)
            {
                this.MiError.SetError(this.txtCostoNoIvaP1, "El valor es incorrecto.");
                this.CostoNoIvaMatch = false;
            }
            else
            {
                this.MiError.SetError(this.txtCostoNoIvaP1, null);
                this.CostoNoIvaMatch = true;
            }

            if (Convert.ToDouble(this.txtCostoConIvaP1.Text.Replace('.', ',')) < 0)
            {
                this.MiError.SetError(this.txtCostoConIvaP1, "El valor es incorrecto.");
                this.CostoIvaMatch = false;
            }
            else
            {
                this.MiError.SetError(this.txtCostoConIvaP1, null);
                this.CostoIvaMatch = true;
            }

            if (Convert.ToDouble(this.txtUtilidadP1.Text.Replace('.', ',')) < 0)
            {
                this.MiError.SetError(this.txtUtilidadP1, "El valor es incorrecto.");
                this.UtilMatch = false;
            }
            else
            {
                this.MiError.SetError(this.txtUtilidadP1, null);
                this.UtilMatch = true;
            }
            this.Util2Match = true;
            this.Util3Match = true;

            /*if (Convert.ToDouble(this.txtUtilidadP2.Text.Replace('.', ',')) < 0)
            {
                this.MiError.SetError(this.txtUtilidadP2, "El valor es incorrecto.");
                this.Util2Match = false;
            }
            else
            {
                this.MiError.SetError(this.txtUtilidadP2, null);
                this.Util2Match = true;
            }

            if (Convert.ToDouble(this.txtUtilidadP3.Text.Replace('.', ',')) < 0)
            {
                this.MiError.SetError(this.txtUtilidadP3, "El valor es incorrecto.");
                this.Util3Match = false;
            }
            else
            {
                this.MiError.SetError(this.txtUtilidadP3, null);
                this.Util3Match = true;
            }*/

            if (Convert.ToDouble(this.txtValorVentaP1.Text.Replace('.', ',')) < 0)
            {
                this.MiError.SetError(this.txtValorVentaP1, "El valor es incorrecto.");
                this.PrecioVentaMatch = false;
            }
            else
            {
                this.MiError.SetError(this.txtValorVentaP1, null);
                this.PrecioVentaMatch = true;
            }

            if (Convert.ToDouble(this.txtValorVentaP2.Text.Replace('.', ',')) < 0)
            {
                this.MiError.SetError(this.txtValorVentaP2, "El valor es incorrecto.");
                this.PrecioVenta2Match = false;
            }
            else
            {
                this.MiError.SetError(this.txtValorVentaP2, null);
                this.PrecioVenta2Match = true;
            }

            if (Convert.ToDouble(this.txtValorVentaP3.Text.Replace('.', ',')) < 0)
            {
                this.MiError.SetError(this.txtValorVentaP3, "El valor es incorrecto.");
                this.PrecioVenta3Match = false;
            }
            else
            {
                this.MiError.SetError(this.txtValorVentaP3, null);
                this.PrecioVenta3Match = true;
            }

            if (Convert.ToDouble(this.txtDescuentoP2DB.Text.Replace('.', ',')) < 0)
            {
                this.MiError.SetError(this.txtDescuentoP2DB, "El valor es incorrecto.");
                this.Descto2Match = false;
            }
            else
            {
                this.MiError.SetError(this.txtDescuentoP2DB, null);
                this.Descto2Match = true;
            }

            if (Convert.ToDouble(this.txtDescuentoP3DB.Text.Replace('.', ',')) < 0)
            {
                this.MiError.SetError(this.txtDescuentoP3DB, "El valor es incorrecto.");
                this.Descto3Match = false;
            }
            else
            {
                this.MiError.SetError(this.txtDescuentoP3DB, null);
                this.Descto3Match = true;
            }

            if (this.CostoNoIvaMatch &&
                this.CostoIvaMatch &&
                this.UtilMatch &&
                this.Util2Match &&
                this.Util3Match &&
                this.PrecioVentaMatch &&
                this.PrecioVenta2Match &&
                this.PrecioVenta3Match &&
                this.Descto2Match &&
                this.Descto3Match)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void LimpiarErrorProvider()
        {
            this.MiError.SetError(this.txtCostoNoIvaP1, null);
            this.MiError.SetError(this.txtCostoConIvaP1, null);
            this.MiError.SetError(this.txtUtilidadP1, null);
            this.MiError.SetError(this.txtUtilidadP2, null);
            this.MiError.SetError(this.txtUtilidadP3, null);
            this.MiError.SetError(this.txtValorVentaP1, null);
            this.MiError.SetError(this.txtValorVentaP2, null);
            this.MiError.SetError(this.txtValorVentaP3, null);
            this.MiError.SetError(this.txtDescuentoP2DB, null);
            this.MiError.SetError(this.txtDescuentoP3DB, null);
        }


        void CompletaEventos_CompAxTInvFactProvee(CompletaTransInvFactProvee args)
        {
            try
            {
                var producto = (DTO.Clases.Producto)args.MiObjeto;
                this.txtCodigoArticulo.Text = producto.CodigoInternoProducto;
                this.txtCodigoArticulo_KeyPress(this.txtCodigoArticulo, new KeyPressEventArgs((char)Keys.Enter));
            }
            catch { }
        }

        void CompletaEventos_Completaz(CompletaArgumentosDeEventoz args)
        {
            try
            {
                this.txtCodigoArticulo.Text = MiProducto.CodigoInternoProducto;
                this.txtCodigoArticulo_KeyPress(this.txtCodigoArticulo, new KeyPressEventArgs((char)Keys.Enter));
            }
            catch { }
        }

        string code_ = "";
        private void Ajuste()
        {
            try
            {
                DataTable tProductos = this.miBussinesProducto.ProductosAll();
                foreach (DataRow pRow in tProductos.Rows)
                {
                    string codigo = pRow["codigo"].ToString();
                    code_ = codigo;
                    double costo = Convert.ToDouble(pRow["costo"]);
                    double util = Convert.ToDouble(pRow["util"]);
                    int ventaDB = Convert.ToInt32(pRow["venta"]);
                    double iva = Convert.ToDouble(pRow["iva"]);
                    double descto1 = Convert.ToDouble(pRow["descto1"]);
                    double descto2 = Convert.ToDouble(pRow["descto2"]);

                    if (code_ == "2224")
                    {
                        var j = code_;
                    }

                    if (costo > 5)
                    {

                        var valUtil = 0.0;
                        var valIvaUtil = 0.0;
                        var venta = 0;
                        /* if (util > 0)
                         {
                             var costoMasIva = Math.Round((costo + Math.Round((costo * iva / 100), 4)), 2);
                             if (!this.UtilidadAntesIva)  // Utilidad antes de IVA.
                             {
                                 if (this.CalculoUtilMultiplicado)  // Incremento de utilidad multiplic.
                                 {
                                     valUtil = Math.Round((costo * util / 100), 2);
                                 }
                                 else
                                 {
                                     valUtil = Math.Round(((costo / ((100 - util) / 100)) - costo), 2);
                                 }
                                 //valIvaUtil = Math.Round((valUtil * this.MiProducto.ValorIva / 100), 2);
                                 if (this.miEmpresa.Regimen.IdRegimen.Equals(1))
                                 {
                                     valIvaUtil = Math.Round((valUtil * iva / 100), 2);
                                     //venta = Convert.ToInt32(costoMasIva + valUtil + valIvaUtil);
                                 }
                                 else
                                 {
                                     //venta = Convert.ToInt32(costoMasIva + valUtil);
                                 }
                                 venta = Convert.ToInt32(costoMasIva + valUtil + valIvaUtil);
                             }
                             else
                             {
                                 if (this.CalculoUtilMultiplicado)  // Incremento de utilidad multiplic.
                                 {
                                     valUtil = Math.Round((costoMasIva * util / 100), 2);
                                 }
                                 else
                                 {
                                     valUtil = Math.Round(((costoMasIva / ((100 - util) / 100)) - costoMasIva), 2);
                                 }
                                 venta = Convert.ToInt32(costoMasIva + valUtil + valIvaUtil);
                             }
                             venta = UseObject.Aproximar(venta, AproxPrecio);
                         }
                         else
                         {
                             venta = ventaDB;
                         }*/
                        venta = ventaDB;

                        int precio2 = Convert.ToInt32(venta - (venta * descto1 / 100));
                        int precio3 = Convert.ToInt32(venta - (venta * descto2 / 100));

                        precio2 = UseObject.Aproximar(precio2, AproxPrecio);
                        precio3 = UseObject.Aproximar(precio3, AproxPrecio);

                        //int valor = venta;
                        double ivaEdit = iva;
                        double costoCalculado = costo;
                        double util_ = 0.0;
                        double util2 = 0.0;

                        if (!this.UtilidadAntesIva)  // Utilidad antes de IVA.
                        {
                            if (this.miEmpresa.Regimen.IdRegimen.Equals(1)) //  Regimen   (Comun) 
                            {
                                precio2 = Convert.ToInt32(precio2 / (1 + (ivaEdit / 100)));
                                precio3 = Convert.ToInt32(precio3 / (1 + (ivaEdit / 100)));
                            }
                        }

                        if (CalculoUtilMultiplicado)
                        {
                            util_ = Math.Round(Convert.ToDouble(((precio2 - costoCalculado) * 100) / costoCalculado), 2);
                            util2 = Math.Round(Convert.ToDouble(((precio3 - costoCalculado) * 100) / costoCalculado), 2);
                        }
                        else
                        {
                            var div = Math.Round((costoCalculado / precio2), 2);
                            util_ = Math.Round((100 - ((costoCalculado / precio2) * 100)), 1);

                            var div_ = Math.Round((costoCalculado / precio3), 2);
                            util2 = Math.Round((100 - ((costoCalculado / precio3) * 100)), 1);
                        }
                        this.miBussinesProducto.EditarUtilidad2_3(codigo, util_, util2);

                    }
                    //
                }

                OptionPane.MessageInformation("El ajuste se realizo con exito.");
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message + "\n" + code_);
            }
        }

        private void Ajuste2()
        {
            try
            {
                DataTable tProductos = this.miBussinesProducto.ProductosAll();
                foreach (DataRow pRow in tProductos.Rows)
                {
                    string codigo = pRow["codigo"].ToString();

                    //  if (codigo == "325")
                    //{

                    code_ = codigo;
                    double costo = Convert.ToDouble(pRow["costo"]);
                    double util = Convert.ToDouble(pRow["util"]);
                    int ventaDB = Convert.ToInt32(pRow["venta"]);
                    double iva = Convert.ToDouble(pRow["iva"]);
                    double descto1 = Convert.ToDouble(pRow["descto1"]);
                    double descto2 = Convert.ToDouble(pRow["descto2"]);

                    /*     if (code_ == "1015")
                         {
                             var j = code_;
                         }*/
                    if (iva == 19 && util > 0)
                    {
                        var valUtil = 0.0;
                        var valIvaUtil = 0.0;
                        var venta = 0;

                        var costoMasIva = Math.Round((costo + Math.Round((costo * iva / 100), 4)), 2);
                        valUtil = Convert.ToInt32(ventaDB - costoMasIva);
                        valIvaUtil = Math.Round((valUtil * iva / 100), 2);
                        venta = Convert.ToInt32(costoMasIva + valUtil + valIvaUtil);
                        venta = UseObject.Aproximar(venta, AproxPrecio);

                        var valor = Convert.ToInt32(venta / (1 + (iva / 100)));

                        var div = Math.Round((costo / valor), 2);
                        util = Math.Round((100 - ((costo / valor) * 100)), 0);


                        int precio2 = Convert.ToInt32(venta - (venta * descto1 / 100));
                        int precio3 = Convert.ToInt32(venta - (venta * descto2 / 100));

                        precio2 = UseObject.Aproximar(precio2, AproxPrecio);
                        precio3 = UseObject.Aproximar(precio3, AproxPrecio);
                        //int valor = venta;
                        double ivaEdit = iva;
                        double costoCalculado = costo;
                        double util_ = 0.0;
                        double util2 = 0.0;

                        if (!this.UtilidadAntesIva)  // Utilidad antes de IVA.
                        {
                            if (this.miEmpresa.Regimen.IdRegimen.Equals(1)) //  Regimen   (Comun) 
                            {
                                precio2 = Convert.ToInt32(precio2 / (1 + (ivaEdit / 100)));
                                precio3 = Convert.ToInt32(precio3 / (1 + (ivaEdit / 100)));
                            }
                        }

                        if (CalculoUtilMultiplicado)
                        {
                            util_ = Math.Round(Convert.ToDouble(((precio2 - costoCalculado) * 100) / costoCalculado), 2);
                            util2 = Math.Round(Convert.ToDouble(((precio3 - costoCalculado) * 100) / costoCalculado), 2);
                        }
                        else
                        {
                            var div1 = Math.Round((costoCalculado / precio2), 2);
                            util_ = Math.Round((100 - ((costoCalculado / precio2) * 100)), 0);

                            var div_ = Math.Round((costoCalculado / precio3), 2);
                            util2 = Math.Round((100 - ((costoCalculado / precio3) * 100)), 0);
                        }
                        this.miBussinesProducto.EditarUtilidad_2_3(codigo, venta, util, util_, util2);
                    }

                    //}//

                }
                OptionPane.MessageInformation("El ajuste se realizo con exito.");
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message + "\n" + code_);
            }
        }

    }
}