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

namespace Aplicacion.Ventas.EditarPrecio
{
    public partial class FrmPrecioProducto : Form
    {
        private ErrorProvider MiError;

        private bool FormInventario = false;

        private BussinesEmpresa miBussinesEmpresa;

        private BussinesProducto miBussinesProducto;

        private BussinesValorUnidadMedida miBussinesMedida;

        private BussinesFacturaProveedor miBussinesFacturaProveedor;

        private BussinesColor miBussinesColor;

        private BussinesIva miBussinesIva;

        private DTO.Clases.Producto MiProducto;

        private ValorUnidadMedida miMedida;

        private Compras.IngresarCompra.TallaYcolor miTallaYcolor;

        Validacion validacion;

        private bool UtilidadMatch = false;

        private bool CostoMatch = false;

        private bool PrecioMatch = false;

        private Empresa MiEmpresa { set; get; }

        private bool EdicionCosto { set; get; }

        private ToolTip miBtnTexto;

        public FrmPrecioProducto()
        {
            InitializeComponent();
            miBtnTexto = new ToolTip();
            MiError = new ErrorProvider();
            miBussinesEmpresa = new BussinesEmpresa();
            miBussinesProducto = new BussinesProducto();
            miBussinesMedida = new BussinesValorUnidadMedida();
            miBussinesColor = new BussinesColor();
            miBussinesIva = new BussinesIva();
            miBussinesFacturaProveedor = new BussinesFacturaProveedor();
            EdicionCosto = false;
            validacion = new Validacion();
            try
            {
                MiEmpresa = miBussinesEmpresa.ObtenerEmpresa();
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
            // ExtendForms = false;
        }

        private void FrmPrecioProducto_Load(object sender, EventArgs e)
        {
            CargarUtilidades();
            CompletaEventos.CompAxTInvFactProvee +=
                new CompletaEventos.ComAxTransferInvFactProve(CompletaEventos_CompAxTInvFactProvee);
            CompletaEventos.CompletaVenta += new CompletaEventos.CompletaAccionVenta(CompletaEventosVenta_Completo);
            CompletaEventos.Completaz += new CompletaEventos.CompletaAccionz(CompletaEventos_Completaz);
        }

        private void FrmPrecioProducto_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData.Equals(Keys.F2))
            {
                this.btnActualizar_Click(this.btnActualizar, new EventArgs());
            }
            else
            {
                if (e.KeyData.Equals(Keys.F3))
                {
                    var formInventario = new Inventario.Consulta.FrmConsultaInventario();
                    formInventario.ExtendVenta = true;
                    formInventario.IsCompra = true;
                    FormInventario = true;
                    // this.Transfer = true;
                    formInventario.ShowDialog();

                    /*var formInventario = new Inventario.Consulta.FrmConsultaInventario();
                            formInventario.MdiParent = this.MdiParent;
                            formInventario.ExtendVenta = true;
                            formInventario.IsCompra = true;
                            formInventario.txtCodigoNombre.Text = txtCodigoArticulo.Text;
                            FormInventario = true;
                            formInventario.Show();
                            formInventario.dgvInventario.Focus();*/
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

        private void txtCodigoArticulo_KeyPress(object sender, KeyPressEventArgs e)
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
                                if (!btnTallaYcolor.Enabled)
                                {
                                    btnInfoCosto.Enabled = false;
                                    CargarInformacion();
                                    this.txtCodigoArticulo.Focus();
                                    //this.txtCosto.Focus();
                                }
                            }
                            else
                            {
                                DialogResult rta = MessageBox.Show("El Producto no existe.\n¿Desea Crearlo?",
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
                                        FormInventario = true;
                                        formProducto.Show();
                                    }
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
        }

        private void tsConsultaProducto_Click(object sender, EventArgs e)
        {
            var formInventario = new Inventario.Consulta.FrmConsultaInventario();
            formInventario.ExtendVenta = true;
            formInventario.IsCompra = true;
            FormInventario = true;
            // this.Transfer = true;
            formInventario.ShowDialog();
        }

        private void tsEditar_Click(object sender, EventArgs e)
        {
            if (MiProducto != null)
            {
                var FrmEditarProducto = new Inventario.Producto.frmEditarProducto();
                FrmEditarProducto.MdiParent = this.MdiParent;
                FrmEditarProducto.CodigoProducto = MiProducto.CodigoInternoProducto;
                FrmEditarProducto.Show();
            }
        }

        private void tsbSalir_Click(object sender, EventArgs e)
        {
            DialogResult rta = MessageBox.Show("¿Esta seguro de querer salir?", "Editar Precio",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rta.Equals(DialogResult.Yes))
            {
                this.Close();
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

        private void txtCosto_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar.Equals((char)Keys.Enter))
            {
                CalcularInformacion();
                this.txtUtilidad.Focus();
                //this.txtPrecioVenta_KeyPress(this.txtPrecioVenta, new KeyPressEventArgs((char)Keys.Enter));
            }
        }

        private void txtCosto_KeyUp(object sender, KeyEventArgs e)
        {
            this.txtUtilidad_KeyUp(this.txtUtilidad, null);
        }

        private void btnEditarCosto_Click(object sender, EventArgs e)
        {
            EdicionCosto = true;
            btnInfoCosto.Enabled = true;
            //     txtCosto.ReadOnly = false;
            //    txtCosto.Enabled = true;
            txtCosto.BackColor = Color.White;
            txtCosto.Focus();
            txtCosto.SelectAll();
        }

        private void txtUtilidad_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar.Equals((char)Keys.Enter))
            {
                this.txtPrecioVenta.Focus();
            }
        }

        private void txtUtilidad_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                var empresa = miBussinesEmpresa.ObtenerEmpresa();
                var valorIva = ((Iva)cbIvaEditar.SelectedItem).PorcentajeIva;
                txtUtilidad.Text = txtUtilidad.Text.Replace(',', '.');
                var utilidad = txtUtilidad.Text;
                //var costo = UseObject.RemoveSeparatorMil(txtCosto.Text).ToString();
                //var costo = txtCosto.Text.Replace('.', ',');
                var costo = txtCosto.Text;
                if (String.IsNullOrEmpty(utilidad))
                {
                    utilidad = "0";
                }
                if (validacion.ValidarNumeroDecima(utilidad))
                {
                    MiError.SetError(txtUtilidad, null);
                    if (String.IsNullOrEmpty(costo))
                    {
                        costo = "0";
                    }
                    if (validacion.ValidarNumeroDecima(costo)) //if (validacion.ValidarNumeroInt(costo))
                    {
                        MiError.SetError(txtCosto, null);
                        costo = costo.Replace('.', ',');
                        if (empresa.Regimen.IdRegimen.Equals(1))//  Regimen   (Comun)                                                          (1)
                        {
                            if (Convert.ToBoolean(AppConfiguracion.ValorSeccion("costoIva")))//  Precio de Costo                                   (2)
                            {
                                //costo = Convert.ToInt32((Convert.ToInt32(costo) / (1 + (valorIva / 100)))).ToString();
                                costo = Math.Round((Convert.ToDouble(costo) / (1 + (valorIva / 100))), 2).ToString().Replace('.', ',');
                            }
                        }
                        else
                        {
                            if (!Convert.ToBoolean(AppConfiguracion.ValorSeccion("costoIva")))//  Precio de Costo                                   (2)
                            {
                                //costo = Convert.ToInt32(Convert.ToInt32(costo) + (Convert.ToInt32(costo) * valorIva / 100)).ToString();
                                costo = 
                                Math.Round((Convert.ToInt32(costo) + (Convert.ToInt32(costo) * valorIva / 100)), 2).ToString().Replace('.', ',');
                            }
                        }
                        var precioUtil = 0.0;
                        var precioVenta = 0;
                        if (!Convert.ToBoolean(AppConfiguracion.ValorSeccion("utilidad_mas_iva")))   // Utilidad antes de IVA.                       (3)
                        {
                            if (Convert.ToBoolean(AppConfiguracion.ValorSeccion("calculo_util_multiplica"))) // Incremento de Utilidad         (4)
                            {
                                /*precioUtil = UseObject.RemoveSeparatorMil(costo) +
                                             (UseObject.RemoveSeparatorMil(costo) * Convert.ToDouble(utilidad.Replace('.', ',')) / 100);*/
                                precioUtil = 
                                Convert.ToDouble(costo) + (Convert.ToDouble(costo) * Convert.ToDouble(utilidad.Replace('.', ',')) / 100);
                            }
                            else
                            {
                                /*precioUtil = UseObject.RemoveSeparatorMil(costo) / ((100 -
                                             Convert.ToDouble(utilidad.Replace('.', ','))) / 100);*/
                                precioUtil = Convert.ToDouble(costo) / ((100 - Convert.ToDouble(utilidad.Replace('.', ','))) / 100);
                            }
                            if (empresa.Regimen.IdRegimen.Equals(1))//  Regimen                                                                (1)
                            {
                                precioVenta = Convert.ToInt32(precioUtil + (precioUtil * valorIva / 100));
                            }
                            else
                            {
                                precioVenta = Convert.ToInt32(precioUtil);
                            }
                        }
                        else   // Utilidad despues de IVA.
                        {
                            if (empresa.Regimen.IdRegimen.Equals(1))//  Regimen                                                                (1)
                            {
                                precioUtil = Convert.ToInt32(Convert.ToDouble(costo) + (Convert.ToDouble(costo) * valorIva / 100));
                            }
                            else
                            {
                                precioUtil = Convert.ToInt32(costo);
                            }

                            if (Convert.ToBoolean(AppConfiguracion.ValorSeccion("calculo_util_multiplica"))) // Incremento de Utilidad         (4)
                            {
                                precioVenta = Convert.ToInt32(precioUtil + (precioUtil * Convert.ToDouble(utilidad.Replace('.', ',')) / 100));
                            }
                            else
                            {
                                precioVenta = Convert.ToInt32(
                                    precioUtil / ((100 - Convert.ToDouble(utilidad.Replace('.', ','))) / 100));
                            }
                        }

                        txtPrecioSugerido.Text = UseObject.InsertSeparatorMil(Convert.ToInt32(precioVenta).ToString());
                        txtPrecioAprox.Text = UseObject.InsertSeparatorMil(
                            UseObject.Aproximar(precioVenta, Convert.ToBoolean(AppConfiguracion.ValorSeccion("tipo_aprox_precio"))).ToString());

                        /*precioVenta = UseObject.Aproximar(precioVenta, Convert.ToBoolean(AppConfiguracion.ValorSeccion("tipo_aprox_precio")));
                        txtPrecioVenta.Text = precioVenta.ToString();*/

                        UtilidadMatch = true;
                    }
                    else
                    {
                        MiError.SetError(txtCosto, "El valor que ingreso es invalido.");
                        UtilidadMatch = false;
                    }
                }
                else
                {
                    MiError.SetError(txtUtilidad, "El valor que ingreso es invalido.");
                    UtilidadMatch = false;
                }



                /*if (!txtCosto.Text.Equals("0"))
                {
                    var utilidad = txtUtilidad.Text;
                    if (String.IsNullOrEmpty(utilidad))
                    {
                        utilidad = "0";
                    }
                    else
                    {
                        utilidad = utilidad.Replace(',', '.');
                    }
                    if (!String.IsNullOrEmpty(utilidad))
                    {
                        if (validacion.ValidarNumeroDecima(utilidad))
                        {
                            MiError.SetError(txtUtilidad, null);
                            UtilidadMatch = true;
                            var precioUtil = 0.0;
                            var precioSug = 0;
                            //
                            if (EdicionCosto)  // si el costo fue ingresado.
                            {
                                if (String.IsNullOrEmpty(txtCosto.Text))
                                {
                                    txtCosto.Text = "0";
                                }
                                if (validacion.ValidarNumeroInt(txtCosto.Text))
                                {
                                    CostoMatch = true;
                                    MiError.SetError(txtCosto, null);
                                    var costo = 0;

                                    if (EdicionCosto)
                                    {
                                        if (MiEmpresa.Regimen.IdRegimen.Equals(1))//  Regimen   (Comun)                                                          (1)
                                        {
                                            if (Convert.ToBoolean(AppConfiguracion.ValorSeccion("costoIva")))//  Precio de Costo                                   (2)
                                            {
                                                costo = Convert.ToInt32(UseObject.RemoveSeparatorMil(txtCosto.Text) / (1 + (MiProducto.ValorIva / 100)));
                                            }
                                            else
                                            {
                                                costo = Convert.ToInt32(UseObject.RemoveSeparatorMil(txtCosto.Text)); //+
                                                //(UseObject.RemoveSeparatorMil(txtCosto.Text) * MiProducto.ValorIva / 100));
                                            }
                                        }
                                        else
                                        {
                                            if (Convert.ToBoolean(AppConfiguracion.ValorSeccion("costoIva")))//  Precio de Costo                                   (2)
                                            {
                                                costo = Convert.ToInt32(UseObject.RemoveSeparatorMil(txtCosto.Text));
                                            }
                                            else
                                            {
                                                costo = Convert.ToInt32(UseObject.RemoveSeparatorMil(txtCosto.Text) +
                                                    (UseObject.RemoveSeparatorMil(txtCosto.Text) * MiProducto.ValorIva / 100));
                                            }
                                            //costo = Convert.ToInt32(UseObject.RemoveSeparatorMil(txtCosto.Text));
                                        }
                                    }
                                    else
                                    {
                                        if (Convert.ToBoolean(AppConfiguracion.ValorSeccion("costoMasIva")))
                                        {
                                            costo = Convert.ToInt32(
                                                Convert.ToInt32(UseObject.RemoveSeparatorMil(txtCosto.Text)) / (1 - (MiProducto.ValorIva / 100)));
                                        }
                                        else
                                        {
                                            costo = Convert.ToInt32(UseObject.RemoveSeparatorMil(txtCosto.Text));
                                        }
                                    }

                                    if (!Convert.ToBoolean(AppConfiguracion.ValorSeccion("utilidad_mas_iva")))   // Utilidad antes de IVA.                       (3)
                                    {
                                        if (Convert.ToBoolean(AppConfiguracion.ValorSeccion("calculo_util_multiplica"))) // Incremento de Utilidad         (4)
                                        {
                                            precioUtil = costo + 
                                                (costo * UseObject.RemoveSeparatorMil(txtUtilidad.Text) / 100);
                                        }
                                        else
                                        {
                                            precioUtil = costo / ((100 - UseObject.RemoveSeparatorMil(txtUtilidad.Text)) / 100);
                                        }
                                        if (MiEmpresa.Regimen.IdRegimen.Equals(1))//  Regimen                                                                (1)
                                        {
                                            precioSug = Convert.ToInt32(precioUtil + (precioUtil * MiProducto.ValorIva / 100));
                                        }
                                        else
                                        {
                                            precioSug = Convert.ToInt32(precioUtil);
                                        }
                                    }
                                    else   // Utilidad despues de IVA.
                                    {
                                        if (MiEmpresa.Regimen.IdRegimen.Equals(1))//  Regimen                                                                (1)
                                        {
                                            precioUtil = Convert.ToInt32(costo + (costo * MiProducto.ValorIva / 100));
                                        }
                                        else
                                        {
                                            precioUtil = Convert.ToInt32(costo);
                                        }
                                        if (Convert.ToBoolean(AppConfiguracion.ValorSeccion("calculo_util_multiplica"))) // Incremento de Utilidad         (4)
                                        {
                                            precioSug = Convert.ToInt32(
                                                precioUtil + (precioUtil * UseObject.RemoveSeparatorMil(txtUtilidad.Text) / 100));
                                        }
                                        else
                                        {
                                            precioSug = Convert.ToInt32(
                                                precioUtil / ((100 - (UseObject.RemoveSeparatorMil(txtUtilidad.Text) / 100))));
                                        }
                                    }
                                }
                                else
                                {
                                    MiError.SetError(txtCosto, "El valor que ingreso es invalido.");
                                    CostoMatch = false;
                                }
                            }
                            else  // si el costo es el que viene con el producto.
                            {
                                var costo = 0;
                                if (Convert.ToBoolean(AppConfiguracion.ValorSeccion("costoMasIva")))
                                {
                                    costo = Convert.ToInt32(UseObject.RemoveSeparatorMil(txtCosto.Text) / (1 + (MiProducto.ValorIva / 100)));
                                }
                                else
                                {
                                    costo = Convert.ToInt32(UseObject.RemoveSeparatorMil(txtCosto.Text));
                                }
                                if (!Convert.ToBoolean(AppConfiguracion.ValorSeccion("utilidad_mas_iva")))   // Utilidad antes de IVA.                       (3)
                                {
                                    if (Convert.ToBoolean(AppConfiguracion.ValorSeccion("calculo_util_multiplica"))) // Incremento de Utilidad         (4)
                                    {
                                        precioUtil = costo + (costo * Convert.ToDouble(txtUtilidad.Text.Replace('.', ',')) / 100);
                                    }
                                    else
                                    {
                                        precioUtil = costo / ((100 - Convert.ToDouble(txtUtilidad.Text.Replace('.', ','))) / 100);
                                    }
                                    if (MiEmpresa.Regimen.IdRegimen.Equals(1))//  Regimen                                                                (1)
                                    {
                                        precioSug = Convert.ToInt32(precioUtil + (precioUtil * MiProducto.ValorIva / 100));
                                    }
                                    else
                                    {
                                        precioSug = Convert.ToInt32(precioUtil);
                                    }
                                }
                                else    // Utilidad despues de IVA.
                                {
                                    if (MiEmpresa.Regimen.IdRegimen.Equals(1))//  Regimen                                                                (1)
                                    {
                                        precioUtil = costo + (costo * MiProducto.ValorIva / 100);
                                    }
                                    else
                                    {
                                        precioUtil = costo;
                                    }
                                    if (Convert.ToBoolean(AppConfiguracion.ValorSeccion("calculo_util_multiplica"))) // Incremento de Utilidad         (4)
                                    {
                                        precioSug = Convert.ToInt32(precioUtil +
                                                        (precioUtil * Convert.ToDouble(txtUtilidad.Text.Replace('.', ',')) / 100));
                                    }
                                    else
                                    {
                                        precioSug = Convert.ToInt32(precioUtil /
                                                    ((100 - Convert.ToDouble(txtUtilidad.Text.Replace('.', ','))) / 100));
                                    }
                                }
                            }
                            txtPrecioSugerido.Text = UseObject.InsertSeparatorMil(Convert.ToInt32(precioSug).ToString());
                            txtPrecioAprox.Text = UseObject.InsertSeparatorMil(
                                UseObject.Aproximar(precioSug, Convert.ToBoolean(AppConfiguracion.ValorSeccion("tipo_aprox_precio"))).ToString());
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
                    MiError.SetError(txtCosto, null);
                }
                else
                {
                    MiError.SetError(txtCosto, "El artículo no presenta precio de costo, por favor edítelo.");
                }*/
            }
            catch (Exception ex)
            {
                //OptionPane.MessageError(ex.Message);
            }
        }

        private void cbIvaEditar_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (MiProducto != null)
            {
                //cbIvaEditar.SelectedValue = MiProducto.ValorIva;
                MiProducto.IdIva = ((Iva)cbIvaEditar.SelectedItem).IdIva;
                MiProducto.ValorIva = ((Iva)cbIvaEditar.SelectedItem).PorcentajeIva;
               // this.txtUtilidad_KeyUp(this.txtUtilidad, null);
                this.txtPrecioVenta_KeyPress(this.txtPrecioVenta, new KeyPressEventArgs((char)Keys.Enter));
            }
        }

        private void btnEditarIva_Click(object sender, EventArgs e)
        {
            if (MiProducto != null)
            {
                cbIvaEditar.SelectedValue = MiProducto.IdIva;
                txtIva.Visible = false;
                cbIvaEditar.Visible = true;
                btnEditarIva.Enabled = false;
                cbIvaEditar.Focus();
            }
            else
            {
                OptionPane.MessageInformation("Debe cargar primero un articulo.");
            }
        }

        private void txtPrecioVenta_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar.Equals((char)Keys.Enter))
            {
                try
                {
                    var empresa = miBussinesEmpresa.ObtenerEmpresa();
                    var valorIva = ((Iva)cbIvaEditar.SelectedItem).PorcentajeIva;
                    var valorIvaAnterior = MiProducto.ValorIvaAnterior;
                    var venta = UseObject.RemoveSeparatorMil(txtPrecioVenta.Text).ToString();
                    if (String.IsNullOrEmpty(venta))
                    {
                        venta = "0";
                    }
                    //var costo = UseObject.RemoveSeparatorMil(txtCosto.Text).ToString();
                    var costo = this.txtCosto.Text;
                    if (String.IsNullOrEmpty(costo))
                    {
                        costo = "0";
                    }
                    if (validacion.ValidarNumeroInt(venta))
                    {
                        MiError.SetError(txtPrecioVenta, null);
                        var valorCosto = Convert.ToDouble(costo.Replace('.', ','));
                        var valorVenta = Convert.ToInt32(venta);
                        var util = 0.0;
                        if (empresa.Regimen.IdRegimen.Equals(1))//  Regimen   (Comun)                                                          (1)
                        {
                            if (Convert.ToBoolean(AppConfiguracion.ValorSeccion("costoIva")))//  Precio de Costo                                   (2)
                            {
                                valorCosto = Convert.ToInt32((valorCosto / (1 + (valorIva / 100))));
                            }
                        }
                        else
                        {
                            if (!Convert.ToBoolean(AppConfiguracion.ValorSeccion("costoIva")))//  Precio de Costo                                   (2)
                            {
                                valorCosto = Convert.ToInt32(valorCosto + (valorCosto * valorIva / 100));
                            }
                        }
                        if (!Convert.ToBoolean(AppConfiguracion.ValorSeccion("utilidad_mas_iva")))   // Utilidad antes de IVA.                       (3)
                        {
                            // Retiro el IVA del precio de venta.
                            if (empresa.Regimen.IdRegimen.Equals(1))//  Regimen   (Comun)                                                          (1)
                            {
                                valorVenta = Convert.ToInt32((valorVenta / (1 + (valorIva / 100))));
                            }
                        }
                        else     // Utilidad despues de IVA.
                        {
                            if (empresa.Regimen.IdRegimen.Equals(1))//  Regimen   (Comun)                                                          (1)
                            {
                                valorCosto = Convert.ToInt32((valorCosto / (1 + (valorIva / 100))));
                            }
                        }
                        // Incremento de la Utilidad.
                        if (Convert.ToBoolean(AppConfiguracion.ValorSeccion("calculo_util_multiplica"))) // Incremento de Utilidad         (4)
                        {
                            // Costo x Util
                            util = Math.Round(Convert.ToDouble(((valorVenta - valorCosto) * 100) / valorCosto), 3);
                        }
                        else
                        {
                            var div = Math.Round(Convert.ToDouble(valorCosto) / Convert.ToDouble(valorVenta), 3);
                            util = 100 - (div * 100);
                        }
                        txtUtilidad.Text = Math.Round(util, 1).ToString();
                        PrecioMatch = true;
                        //  valorVentaMatch = true;

                        /*if (Convert.ToBoolean(AppConfiguracion.ValorSeccion("calculo_util_multiplica"))) //multiplica la utilidad
                        {
                            if (valorCosto != 0)
                            {
                                util = Math.Round(Convert.ToDouble(((pVentaNoIva - valorCosto) * 100) / valorCosto), 2);
                            }
                            else
                            {
                                util = 0;
                            }
                        }
                        else
                        {
                            var div = Math.Round(Convert.ToDouble(valorCosto) / Convert.ToDouble(pVentaNoIva), 2);
                            util = 100 - (div * 100);
                        }*/

                    }
                    else
                    {
                        MiError.SetError(txtPrecioVenta, "El valor que ingreso es invalido.");
                        PrecioMatch = false;
                        //valorVentaMatch = false;
                    }
                    this.txtDesctoMayor.Focus();
                }
                catch (Exception ex)
                {
                    MiError.SetError(txtPrecioVenta, "ERROR.\n" + ex.Message);
                    //OptionPane.MessageError(ex.Message);
                }



                /*
                try
                {
                    if (!txtCosto.Text.Equals("0"))
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
                                var valorCosto = Convert.ToInt32(UseObject.RemoveSeparatorMil(txtCosto.Text));
                                var valorVenta = Convert.ToInt32(venta);
                                var util = 0.0;
                                if (EdicionCosto)
                                {
                                    if (MiEmpresa.Regimen.IdRegimen.Equals(1))
                                    {
                                        if (Convert.ToBoolean(AppConfiguracion.ValorSeccion("costoIva")))
                                        {
                                            valorCosto = Convert.ToInt32((valorCosto / (1 + (MiProducto.ValorIva / 100))));
                                        }
                                    }
                                    else
                                    {
                                        if (!Convert.ToBoolean(AppConfiguracion.ValorSeccion("costoIva")))
                                        {
                                            valorCosto = Convert.ToInt32(valorCosto + (valorCosto * MiProducto.ValorIva / 100));
                                        }
                                    }
                                }
                                else
                                {
                                   //alorCosto = Convert.ToInt32((valorCosto / (1 + (MiProducto.ValorIva / 100))));
                                    if (Convert.ToBoolean(AppConfiguracion.ValorSeccion("costoMasIva")))
                                    {
                                        valorCosto = Convert.ToInt32(
                                            Convert.ToInt32(UseObject.RemoveSeparatorMil(txtCosto.Text)) / (1 + (MiProducto.ValorIva / 100)));
                                    }
                                    else
                                    {
                                        valorCosto = Convert.ToInt32(UseObject.RemoveSeparatorMil(txtCosto.Text));
                                    }
                                }

                                if (!Convert.ToBoolean(AppConfiguracion.ValorSeccion("utilidad_mas_iva")))   // Utilidad antes de IVA.                       (3)
                                {
                                    if (MiEmpresa.Regimen.IdRegimen.Equals(1))//  Regimen   (Comun)                                                          (1)
                                    {
                                        valorVenta = Convert.ToInt32(valorVenta / (1 + (MiProducto.ValorIva / 100)));
                                    }
                                }
                                else
                                {
                                }

                                // Incremento de la Utilidad.
                                if (Convert.ToBoolean(AppConfiguracion.ValorSeccion("calculo_util_multiplica"))) // Incremento de Utilidad         (4)
                                {
                                    // Costo x Util
                                    util = Math.Round(Convert.ToDouble(((valorVenta - valorCosto) * 100) / valorCosto), 3);
                                }
                                else
                                {
                                    var div = Math.Round(Convert.ToDouble(valorCosto) / Convert.ToDouble(valorVenta), 3);
                                    util = 100 - (div * 100);
                                }
                                txtUtilidad.Text = Math.Round(util, 1).ToString();

                                txtPrecioVenta.Text = UseObject.InsertSeparatorMil(venta);
                                txtPrecioSugerido.Text = txtPrecioVenta.Text;
                                txtPrecioAprox.Text = UseObject.InsertSeparatorMil(
                                    UseObject.Aproximar(Convert.ToInt32(venta),
                                    Convert.ToBoolean(AppConfiguracion.ValorSeccion("tipo_aprox_precio"))).ToString());

                                var precioMayor = Convert.ToInt32(Convert.ToInt32(venta) - (Convert.ToInt32(venta) * 
                                Convert.ToDouble(txtDesctoMayor.Text.Replace('.', ',')) / 100));
                                lblPrecioPorMayor.Text = UseObject.InsertSeparatorMil(
                                    UseObject.Aproximar(precioMayor, Convert.ToBoolean(AppConfiguracion.ValorSeccion("tipo_aprox_precio"))).ToString());
                                
                                var precioDistribuidor = Convert.ToInt32(Convert.ToInt32(venta) - (Convert.ToInt32(venta) * 
                                Convert.ToDouble(txtDesctoDistribuidor.Text.Replace('.', ',')) / 100));
                                lblPrecioDistribuidor.Text = UseObject.InsertSeparatorMil(
                                    UseObject.Aproximar(precioDistribuidor, Convert.ToBoolean(AppConfiguracion.ValorSeccion("tipo_aprox_precio"))).ToString());

                            }
                            else
                            {
                                MiError.SetError(txtPrecioVenta, "El valor que ingreso es incorrecto.");
                                PrecioMatch = false;
                            }
                        }
                    }
                    else
                    {
                        MiError.SetError(txtCosto, "El artículo no presenta precio de costo, por favor edítelo.");
                    }
                }
                catch (Exception ex)
                {
                    OptionPane.MessageError(ex.Message);
                }*/
            }
        }

        private void txtPrecioVenta_KeyUp(object sender, KeyEventArgs e)
        {
            /*try
            {
                if (!txtCosto.Text.Equals("0"))
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
                                var valor = Convert.ToDouble((pVentaNoIva - precioCosto) * 100);
                                utili = Math.Round((valor / precioCosto), 1);
                                //utili = Math.Round(Convert.ToDouble(((pVentaNoIva - precioCosto) * 100) / precioCosto), 2);
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

                            var precioMayor = Convert.ToInt32(Convert.ToInt32(venta) - (Convert.ToInt32(venta) * MiProducto.DescuentoMayor / 100));
                            lblPrecioPorMayor.Text = UseObject.InsertSeparatorMil(
                                UseObject.Aproximar(precioMayor, Convert.ToBoolean(AppConfiguracion.ValorSeccion("tipo_aprox_precio"))).ToString());
                            var precioDistribuidor = Convert.ToInt32(Convert.ToInt32(venta) - (Convert.ToInt32(venta) * MiProducto.DescuentoDistribuidor / 100));
                            lblPrecioDistribuidor.Text = UseObject.InsertSeparatorMil(
                                UseObject.Aproximar(precioDistribuidor, Convert.ToBoolean(AppConfiguracion.ValorSeccion("tipo_aprox_precio"))).ToString());
                        }
                        else
                        {
                            MiError.SetError(txtPrecioVenta, "El valor que ingreso es incorrecto.");
                            PrecioMatch = false;
                        }
                    }
                }
                else
                {
                    MiError.SetError(txtCosto, "El artículo no presenta precio de costo, por favor edítelo.");
                }
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }*/
        }

        private void txtDesctoMayor_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                var precioVenta = txtPrecioVenta.Text;
                if (String.IsNullOrEmpty(precioVenta))
                {
                    precioVenta = "0";
                }
                var destoMayor = txtDesctoMayor.Text.Replace('.', ',');
                if (String.IsNullOrEmpty(destoMayor))
                {
                    destoMayor = "0";
                }

                var precioMayor = Convert.ToInt32(UseObject.RemoveSeparatorMil(precioVenta) -
                    (UseObject.RemoveSeparatorMil(precioVenta) * Convert.ToDouble(destoMayor) / 100));
                lblPrecioPorMayor.Text = UseObject.InsertSeparatorMil(precioMayor.ToString());
                /*lblPrecioPorMayor.Text = UseObject.InsertSeparatorMil(
                               UseObject.Aproximar(precioMayor, Convert.ToBoolean(AppConfiguracion.ValorSeccion("tipo_aprox_precio"))).ToString());*/
            }
            catch (Exception ex)
            {
                this.txtDesctoMayor.Text = "0";
                //this.MiError.SetError(this.txtDesctoMayor, ex.Message);
                //OptionPane.MessageError(ex.Message);
            }
        }

        private void txtDesctoMayor_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar.Equals((char)Keys.Enter))
            {
                this.txtDesctoDistribuidor.Focus();
            }
        }

        private void txtDesctoDistribuidor_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                var precioVenta = txtPrecioVenta.Text;
                if (String.IsNullOrEmpty(precioVenta))
                {
                    precioVenta = "0";
                }
                var destoDistribuidor = txtDesctoDistribuidor.Text.Replace('.', ',');
                if (String.IsNullOrEmpty(destoDistribuidor))
                {
                    destoDistribuidor = "0";
                }
                var precioDistri = Convert.ToInt32(UseObject.RemoveSeparatorMil(precioVenta) -
                    (UseObject.RemoveSeparatorMil(precioVenta) * Convert.ToDouble(destoDistribuidor) / 100));
                lblPrecioDistribuidor.Text = UseObject.InsertSeparatorMil(precioDistri.ToString());
                /*lblPrecioDistribuidor.Text = UseObject.InsertSeparatorMil(
                    UseObject.Aproximar(precioDistri, Convert.ToBoolean(AppConfiguracion.ValorSeccion("tipo_aprox_precio"))).ToString());*/
            }
            catch (Exception ex)
            {
                this.txtDesctoDistribuidor.Text = "0";
                //this.MiError.SetError(this.txtDesctoDistribuidor, ex.Message);
            }
        }

        private void txtDesctoDistribuidor_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar.Equals((char)Keys.Enter))
            {
                this.btnActualizar_Click(this.btnActualizar, new EventArgs());
            }
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            if (MiProducto != null)
            {
                txtUtilidad_KeyUp(this.txtUtilidad, null);
                txtPrecioVenta_KeyPress(this.txtPrecioVenta, new KeyPressEventArgs((char)Keys.Enter));
                if (UtilidadMatch && PrecioMatch)
                {
                    DialogResult rta_ = MessageBox.Show("¿Esta seguro(a) de guardar los cambios?", "Edición de precio",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (rta_.Equals(DialogResult.Yes))
                    {
                        var utilSave = UseObject.RemoveCharacter(lblVUtilidad.Text, '%');
                        //UseObject.RemoveSeparatorMil(lblVUtilidad.Text);
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
                            double costo = 0;
                            if (EdicionCosto)
                            {
                                if (Convert.ToBoolean(AppConfiguracion.ValorSeccion("costoIva"))) //TRUE indica q el costo si incluye iva
                                {
                                    //costo = Convert.ToInt32(UseObject.RemoveSeparatorMil(txtCosto.Text));
                                    costo = Math.Round(Convert.ToDouble(txtCosto.Text.Replace('.', ',')), 1);
                                }
                                else
                                {
                                    /*costo = Convert.ToInt32(UseObject.RemoveSeparatorMil(txtCosto.Text)) +
                                        Convert.ToInt32(Convert.ToInt32(UseObject.RemoveSeparatorMil(txtCosto.Text)) *
                                         ((Iva)cbIvaEditar.SelectedItem).PorcentajeIva / 100);*/
                                    costo = Math.Round((Convert.ToDouble(txtCosto.Text.Replace('.', ',')) +
                                            Convert.ToDouble(Convert.ToDouble(txtCosto.Text.Replace('.', ',')) *
                                            ((Iva)cbIvaEditar.SelectedItem).PorcentajeIva / 100)), 1);
                                }
                            }
                            else
                            {
                                if (Convert.ToBoolean(AppConfiguracion.ValorSeccion("costoIva")))
                                {
                                    //costo = Convert.ToDouble(Convert.ToDouble(txtCosto.Text.Replace('.', ',')) / (1 + (MiProducto.ValorIva / 100)));
                                    costo = Math.Round((Convert.ToDouble(txtCosto.Text.Replace('.', ',')) / (1 + (MiProducto.ValorIva / 100))), 1);
                                }
                                else
                                {
                                    //costo = Convert.ToDouble(Convert.ToDouble(txtCosto.Text.Replace('.', ',')));
                                    costo = Convert.ToDouble(txtCosto.Text.Replace('.', ','));
                                }
                                // costo = Convert.ToInt32(UseObject.RemoveSeparatorMil(txtCosto.Text));
                            }
                            //var i = MiProducto.IdIva;
                            miBussinesProducto.EditarUtilidadVenta
                                (MiProducto.CodigoInternoProducto,
                                utilSave,
                                precioVentaSave,
                                costo);//Convert.ToInt32(UseObject.RemoveSeparatorMil(txtCosto.Text)));
                            miBussinesProducto.EditarIva
                                (MiProducto.CodigoInternoProducto,
                                 MiProducto.IdIva);//Convert.ToInt32(cbIvaEditar.SelectedValue));
                            miBussinesProducto.EditarDescuentos
                                (MiProducto.CodigoInternoProducto,
                                Convert.ToDouble(txtDesctoMayor.Text.Replace('.', ',')),
                                Convert.ToDouble(txtDesctoDistribuidor.Text.Replace('.', ',')));

                            OptionPane.MessageInformation("La información del producto se ha almacenado correctamente.");
                            //  txtCosto.Enabled = false;
                            btnEditarIva.Enabled = true;
                            btnInfoCosto.Enabled = false;
                            cbIvaEditar.Visible = false;
                            txtIva.Visible = true;
                            txtCodigoArticulo.Focus();
                            LimpiarFormulario();
                        }
                        catch (Exception ex)
                        {
                            OptionPane.MessageError(ex.Message);
                        }
                    }
                }
            }
            else
            {
                OptionPane.MessageInformation("Debe cargar primero un articulo.\n");
            }
        }

        private void CargarUtilidades()
        {
            try
            {
                cbIvaEditar.DataSource = miBussinesIva.ListadoIva();
                // cbIvaEditar.SelectedValue = MiProducto.ValorIva;

                if (Convert.ToBoolean(AppConfiguracion.ValorSeccion("costoIva")))
                {
                    miBtnTexto.SetToolTip(btnInfoCosto, "El costo incluye IVA.");
                }
                else
                {
                    miBtnTexto.SetToolTip(btnInfoCosto, "El costo no incluye IVA.");
                }
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
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


        private void CalcularInformacion()
        {
            try
            {
                var empresa = miBussinesEmpresa.ObtenerEmpresa();
                var valorIva = ((Iva)cbIvaEditar.SelectedItem).PorcentajeIva;
                var venta = txtPrecioVenta.Text;
                if (String.IsNullOrEmpty(venta))
                {
                    venta = "0";
                }
                //var costo = UseObject.RemoveSeparatorMil(txtCosto.Text).ToString();
                var costo = txtCosto.Text.Replace('.', ',');
                if (String.IsNullOrEmpty(costo))
                {
                    costo = "0";
                }
                if (validacion.ValidarNumeroInt(venta))
                {
                    MiError.SetError(txtPrecioVenta, null);
                    var valorCosto = Convert.ToDouble(costo);
                    var valorVenta = Convert.ToInt32(venta);
                    var util = 0.0;
                    if (empresa.Regimen.IdRegimen.Equals(1))//  Regimen   (Comun)                                                          (1)
                    {
                        if (Convert.ToBoolean(AppConfiguracion.ValorSeccion("costoIva")))//  Precio de Costo                                   (2)
                        {
                            //valorCosto = Convert.ToInt32((valorCosto / (1 + (valorIva / 100))));
                            valorCosto = Math.Round((valorCosto / (1 + (valorIva / 100))), 2);
                        }
                    }
                    else
                    {
                        if (!Convert.ToBoolean(AppConfiguracion.ValorSeccion("costoIva")))//  Precio de Costo                                   (2)
                        {
                            //valorCosto = Convert.ToInt32(valorCosto + (valorCosto * valorIva / 100));
                            valorCosto = Math.Round((valorCosto + (valorCosto * valorIva / 100)), 2);
                        }
                    }
                    if (!Convert.ToBoolean(AppConfiguracion.ValorSeccion("utilidad_mas_iva")))   // Utilidad antes de IVA.                       (3)
                    {
                        // Retiro el IVA del precio de venta.
                        if (empresa.Regimen.IdRegimen.Equals(1))//  Regimen   (Comun)                                                          (1)
                        {
                            valorVenta = Convert.ToInt32((valorVenta / (1 + (valorIva / 100))));
                        }
                    }
                    else     // Utilidad despues de IVA.
                    {
                        if (empresa.Regimen.IdRegimen.Equals(1))//  Regimen   (Comun)                                                          (1)
                        {
                            //valorCosto = Convert.ToInt32((valorCosto / (1 + (valorIva / 100))));
                            valorCosto = Math.Round((valorCosto / (1 + (valorIva / 100))), 2);
                        }
                    }
                    // Incremento de la Utilidad.
                    if (Convert.ToBoolean(AppConfiguracion.ValorSeccion("calculo_util_multiplica"))) // Incremento de Utilidad         (4)
                    {
                        // Costo x Util
                        util = Math.Round(Convert.ToDouble(((valorVenta - valorCosto) * 100) / valorCosto), 3);
                    }
                    else
                    {
                        var div = Math.Round(Convert.ToDouble(valorCosto) / Convert.ToDouble(valorVenta), 3);
                        util = 100 - (div * 100);
                    }
                    txtUtilidad.Text = Math.Round(util, 1).ToString();
                    PrecioMatch = true;
                }
                else
                {
                    MiError.SetError(txtPrecioVenta, "El valor que ingreso es invalido.");
                    PrecioMatch = false;
                    //valorVentaMatch = false;
                }
            }
            catch (Exception ex)
            {
                MiError.SetError(txtPrecioVenta, "ERROR.\n" + ex.Message);
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

            try
            {
                FormInventario = Convert.ToBoolean(args.MiObjeto);
            }
            catch { }
        }

        void CompletaEventosVenta_Completo(CompletaArgumentosDeEventoVenta args)
        {
            try
            {
                miTallaYcolor = (Compras.IngresarCompra.TallaYcolor)args.objeto;
                CargarInformacion();
            }
            catch { }
        }

        void CompletaEventos_Completaz(CompletaArgumentosDeEventoz args)
        {
            try
            {
                txtCodigoArticulo.Text = MiProducto.CodigoInternoProducto;
                txtCodigoArticulo_KeyPress(this.txtCodigoArticulo, new KeyPressEventArgs((char)Keys.Enter));
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
                lblDatosProducto.Text = MiProducto.CodigoInternoProducto + " - " + MiProducto.NombreProducto;
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
                var costoTmp = costo;
                var inventario = new DTO.Clases.Inventario();
                inventario.CodigoProducto = MiProducto.CodigoInternoProducto;
                if (!MiProducto.AplicaTalla)
                {
                    inventario.IdMedida = miMedida.IdValorUnidadMedida;
                }
                else
                {
                    inventario.IdMedida = miTallaYcolor.IdTalla;
                }
                //inventario.IdMedida = miTallaYcolor.IdTalla;
                inventario.IdColor = miTallaYcolor.IdColor;
                inventario.Cantidad = Convert.ToInt32(AppConfiguracion.ValorSeccion("num_promedio"));
                /*var tProductos = miBussinesFacturaProveedor.ProductosDeFactura(inventario);
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
                }*/

                var producto = miBussinesProducto.ProductoCompleto(MiProducto.CodigoInternoProducto);

                if (Convert.ToBoolean(AppConfiguracion.ValorSeccion("costoIva")))
                {
                    /*txtCosto.Text =
                        UseObject.InsertSeparatorMil((Convert.ToInt32(costo) + Convert.ToInt32(costo * producto.ValorIva / 100)).ToString());*/
                    var d = Math.Round((Convert.ToDouble(costo) + Convert.ToDouble(costo * producto.ValorIva / 100)), 2);
                    txtCosto.Text = 
                            Math.Round((Convert.ToDouble(costo) + Convert.ToDouble(costo * producto.ValorIva / 100)), 2).ToString().Replace(',', '.');
                }
                else
                {
                    txtCosto.Text = Math.Round(costo, 2).ToString();
                }

                MiProducto = producto;
                MiProducto.IdIva = producto.IdIva;
                txtUtilidad.Text = producto.UtilidadPorcentualProducto.ToString();

                //CargarUtilidades();
                //cbIvaEditar.SelectedValue = MiProducto.ValorIva;
                cbIvaEditar.SelectedValue = MiProducto.IdIva;
                cbIvaEditar.Visible = false;
                txtIva.Visible = true;
                txtIva.Text = MiProducto.ValorIva.ToString() + "%"; // producto.ValorIva.ToString() + "%";
               // var i = producto.ValorIva;
                btnEditarIva.Enabled = true;

                var precioSug = 0;
                var precioUtil = 0.0;
                /* if (MiEmpresa.Regimen.IdRegimen.Equals(1))//  Regimen   (Comun)                                                          (1)
                 {

                     costo = Convert.ToInt32(UseObject.RemoveSeparatorMil(txtCosto.Text) / (1 + (producto.ValorIva / 100)));
                 }
                 else
                 {
                     costo = Convert.ToInt32(UseObject.RemoveSeparatorMil(txtCosto.Text));
                 }*/

                if (!Convert.ToBoolean(AppConfiguracion.ValorSeccion("utilidad_mas_iva")))   // Utilidad antes de IVA.                       (3)
                {
                    if (Convert.ToBoolean(AppConfiguracion.ValorSeccion("calculo_util_multiplica"))) // Incremento de Utilidad         (4)
                    {
                        precioUtil = costo + (costo * Convert.ToDouble(txtUtilidad.Text.Replace('.', ',')) / 100);
                    }
                    else
                    {
                        precioUtil = costo / ((100 - Convert.ToDouble(txtUtilidad.Text.Replace('.', ','))) / 100);
                    }
                    if (MiEmpresa.Regimen.IdRegimen.Equals(1))//  Regimen                                                                (1)
                    {
                        precioSug = Convert.ToInt32(precioUtil + (precioUtil * producto.ValorIva / 100));
                    }
                    else
                    {
                        precioSug = Convert.ToInt32(precioUtil);
                    }
                }
                else   // Utilidad despues de IVA.
                {
                    precioUtil = costo + (costo * producto.ValorIva / 100);
                    /*if (MiEmpresa.Regimen.IdRegimen.Equals(1))//  Regimen                                                                (1)
                    {
                        precioUtil = costo + (costo * producto.ValorIva / 100);
                    }
                    else
                    {
                        precioUtil = costo;
                    }*/
                    if (Convert.ToBoolean(AppConfiguracion.ValorSeccion("calculo_util_multiplica"))) // Incremento de Utilidad         (4)
                    {
                        precioSug = Convert.ToInt32(precioUtil +
                                        (precioUtil * Convert.ToDouble(txtUtilidad.Text.Replace('.', ',')) / 100));
                    }
                    else
                    {
                        precioSug = Convert.ToInt32(precioUtil /
                                    ((100 - Convert.ToDouble(txtUtilidad.Text.Replace('.', ','))) / 100));
                    }
                }

                txtPrecioSugerido.Text = UseObject.InsertSeparatorMil(precioSug.ToString());
                txtPrecioAprox.Text = UseObject.InsertSeparatorMil(
                    UseObject.Aproximar(precioSug, Convert.ToBoolean(AppConfiguracion.ValorSeccion("tipo_aprox_precio"))).ToString());
                //txtPrecioVenta.Text = UseObject.InsertSeparatorMil(producto.ValorVentaProducto.ToString());
                txtPrecioVenta.Text = producto.ValorVentaProducto.ToString();

                txtDesctoMayor.Text = producto.DescuentoMayor.ToString();
                txtDesctoDistribuidor.Text = producto.DescuentoDistribuidor.ToString();
                if (Convert.ToBoolean(AppConfiguracion.ValorSeccion("costoIva")))
                {
                    lblValorCosto.Text =
                    UseObject.InsertSeparatorMil((Convert.ToInt32(costo) + Convert.ToInt32(costo * producto.ValorIva / 100)).ToString());
                }
                else
                {
                    lblValorCosto.Text = UseObject.InsertSeparatorMil(Convert.ToInt32(costo).ToString());
                }


                lblVUtilidad.Text = producto.UtilidadPorcentualProducto.ToString() + "%";
                lblValorIva.Text = producto.ValorIva.ToString() + "%";
                lblValorSugerido.Text = txtPrecioSugerido.Text;
                lblValorAprox.Text = txtPrecioAprox.Text;
                lblValorVenta.Text = UseObject.InsertSeparatorMil(producto.ValorVentaProducto.ToString());

                var precioMayor = Convert.ToInt32(producto.ValorVentaProducto - (producto.ValorVentaProducto * producto.DescuentoMayor / 100));

                lblPrecioPorMayor.Text = UseObject.InsertSeparatorMil(precioMayor.ToString());
                /*lblPrecioPorMayor.Text = UseObject.InsertSeparatorMil(
                    UseObject.Aproximar(precioMayor, Convert.ToBoolean(AppConfiguracion.ValorSeccion("tipo_aprox_precio"))).ToString());*/

                var precioDistribuidor = Convert.ToInt32(producto.ValorVentaProducto - (producto.ValorVentaProducto * producto.DescuentoDistribuidor / 100));

                lblPrecioDistribuidor.Text = UseObject.InsertSeparatorMil(precioDistribuidor.ToString());

                this.txtCosto_KeyPress(this.txtCosto, new KeyPressEventArgs((char)Keys.Enter));
                this.txtUtilidad_KeyUp(this.txtUtilidad, null);
                /*lblPrecioDistribuidor.Text = UseObject.InsertSeparatorMil(
                    UseObject.Aproximar(precioDistribuidor, Convert.ToBoolean(AppConfiguracion.ValorSeccion("tipo_aprox_precio"))).ToString());*/


                /*
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
                    if (precioSug > 10)
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

                txtDesctoMayor.Text = producto.DescuentoMayor.ToString();
                txtDesctoDistribuidor.Text = producto.DescuentoDistribuidor.ToString();

                lblValorCosto.Text = UseObject.InsertSeparatorMil(costo.ToString());
                lblVUtilidad.Text = producto.UtilidadPorcentualProducto.ToString() + "%";
                lblValorIva.Text = producto.ValorIva.ToString() + "%";
                lblValorSugerido.Text = txtPrecioSugerido.Text;
                lblValorAprox.Text = txtPrecioAprox.Text;
                lblValorVenta.Text = UseObject.InsertSeparatorMil(producto.ValorVentaProducto.ToString());

                var precioMayor = Convert.ToInt32(producto.ValorVentaProducto - (producto.ValorVentaProducto * producto.DescuentoMayor / 100));
                lblPrecioPorMayor.Text = UseObject.InsertSeparatorMil(
                    UseObject.Aproximar(precioMayor, Convert.ToBoolean(AppConfiguracion.ValorSeccion("tipo_aprox_precio"))).ToString());
                var precioDistribuidor = Convert.ToInt32(producto.ValorVentaProducto - (producto.ValorVentaProducto * producto.DescuentoDistribuidor / 100));
                lblPrecioDistribuidor.Text = UseObject.InsertSeparatorMil(
                    UseObject.Aproximar(precioDistribuidor, Convert.ToBoolean(AppConfiguracion.ValorSeccion("tipo_aprox_precio"))).ToString());
                */
                //(Convert.ToInt32(row["mayorista"]), Convert.ToBoolean(AppConfiguracion.ValorSeccion("tipo_aprox_precio")));

                txtCodigoArticulo.Text = "";
                EdicionCosto = false;
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
        }

        private void LimpiarFormulario()
        {
            MiProducto = null;
            lblDatosProducto.Text = "";
            txtCosto.Text = "";
            txtUtilidad.Text = "";
            txtIva.Text = "";
            txtPrecioSugerido.Text = "";
            txtPrecioAprox.Text = "";
            txtPrecioVenta.Text = "";
            txtDesctoMayor.Text = "";
            txtDesctoDistribuidor.Text = "";
            lblValorCosto.Text = "0";
            lblVUtilidad.Text = "0";
            lblValorIva.Text = "0";
            lblValorSugerido.Text = "0";
            lblValorAprox.Text = "0";
            lblValorVenta.Text = "0";
            lblPrecioPorMayor.Text = "0";
            lblPrecioDistribuidor.Text = "0";
            EdicionCosto = false;
        }
    }
}