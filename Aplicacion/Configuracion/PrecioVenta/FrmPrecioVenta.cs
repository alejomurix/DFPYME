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

namespace Aplicacion.Configuracion.PrecioVenta
{
    public partial class FrmPrecioVenta : Form
    {
        private Validacion miValidacion;

        private ToolTip miToolTip;

        private ErrorProvider miError;

        private bool PromedioMatch = false;

        private bool ValorAproxMatch = false;

        public FrmPrecioVenta()
        {
            InitializeComponent();
            miValidacion = new Validacion();
            miToolTip = new ToolTip();
            miError = new ErrorProvider();
        }

        private void FrmPrecioVenta_Load(object sender, EventArgs e)
        {
            CargarUtilidades();
        }

        private void rbtnAsignado_Click(object sender, EventArgs e)
        {
            //txtNumPromedio.Enabled = false;
            gbIva.Enabled = true;
        }

        private void rbtnPromedio_Click(object sender, EventArgs e)
        {
            //txtNumPromedio.Enabled = true;
            //txtNumPromedio.Focus();

            /*rbtnNoIncluye.Checked = true;
            gbIva.Enabled = false;*/
        }

        private void txtNumPromedio_KeyUp(object sender, KeyEventArgs e)
        {
            if (!Validacion.EsVacio(txtNumPromedio, miError, "El campo es requerido."))
            {
                if (Validacion.ConFormato
                    (Validacion.TipoValidacion.Numeros, txtNumPromedio, miError, "El valor que ingreso es invalido."))
                {
                    PromedioMatch = true;
                }
                else
                {
                    PromedioMatch = false;
                }
            }
            else
            {
                PromedioMatch = false;
            }
        }

        private void rbtnDecena_Click(object sender, EventArgs e)
        {
            try
            {
                txtValorAprox.Text = AppConfiguracion.ValorSeccion("aprox_decena");
                CalcularUtilidad();
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
        }

        private void rbtnCentena_Click(object sender, EventArgs e)
        {
            try
            {
                txtValorAprox.Text = AppConfiguracion.ValorSeccion("aprox_centena");
                CalcularUtilidad();
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
        }

        private void txtValorAprox_KeyUp(object sender, KeyEventArgs e)
        {
            if (!Validacion.EsVacio(txtValorAprox, miError, "El campo es requerido."))
            {
                if (Validacion.ConFormato
                    (Validacion.TipoValidacion.Numeros, txtValorAprox, miError, "El valor que ingreso es invalido."))
                {
                    ValorAproxMatch = true;
                }
                else
                {
                    ValorAproxMatch = false;
                }
            }
            else
            {
                ValorAproxMatch = false;
            }
        }

        private void txtCosto_KeyUp(object sender, KeyEventArgs e)
        {
            CalcularUtilidad();
        }

        private void txtUtilidad_KeyUp(object sender, KeyEventArgs e)
        {
            CalcularUtilidad();
        }

        private void btnInfoPor_MouseLeave(object sender, EventArgs e)
        {
            PanelInfo.Visible = false;
        }

        private void btnInfoPor_MouseMove(object sender, MouseEventArgs e)
        {
            PanelInfo.Visible = true; txtInfo.Text =
             "Determina el precio de venta multiplicando el valor porcentual de la utilidad y sumando este al costo del producto.                  Costo + (Costo * Utilidad%)";
        }

        private void btnInfoSobre_MouseLeave(object sender, EventArgs e)
        {
            PanelInfo.Visible = false;
        }

        private void btnInfoSobre_MouseMove(object sender, MouseEventArgs e)
        {
            PanelInfo.Visible = true;
            txtInfo.Text =
                "Determina el precio de venta dividiendo el complemento de la utilidad porcentual al costo del producto.                                      Costo / ((100 - Utilidad) / 100)";
        }

        private void CargarUtilidades()
        {
            var j = txtNumPromedio.Enabled;
            try
            {
                if (Convert.ToBoolean(AppConfiguracion.ValorSeccion("promedio")))
                {
                    rbtnPromedio.Checked = true;
                }
                else
                {
                    rbtnAsignado.Checked = true;
                    //txtNumPromedio.Enabled = false;
                }
                txtNumPromedio.Text = AppConfiguracion.ValorSeccion("num_promedio");

                if (Convert.ToBoolean(AppConfiguracion.ValorSeccion("precio_venta_iva")))
                {
                    rbtnIncluye.Checked = true;
                }
                else
                {
                    rbtnNoIncluye.Checked = true;
                }

                if (Convert.ToBoolean(AppConfiguracion.ValorSeccion("tipo_aprox_precio")))
                {
                    rbtnCentena.Checked = true;
                    txtValorAprox.Text = AppConfiguracion.ValorSeccion("aprox_centena");
                }
                else
                {
                    rbtnDecena.Checked = true;
                    txtValorAprox.Text = AppConfiguracion.ValorSeccion("aprox_decena");
                }

                if (Convert.ToBoolean(AppConfiguracion.ValorSeccion("calculo_util_multiplica")))
                {
                    rbtnPorUtilidad.Checked = true;
                }
                else
                {
                    rbtnSobreUtilidad.Checked = true;
                }

                if (Convert.ToBoolean(AppConfiguracion.ValorSeccion("pregunta_act_util")))
                {
                    chkPreguntarUtil.Checked = true;
                }
                else
                {
                    chkPreguntarUtil.Checked = false;
                }

                if (Convert.ToBoolean(AppConfiguracion.ValorSeccion("pregunta_act_pventa")))
                {
                    chkPreguntaPrecioVenta.Checked = true;
                }
                else
                {
                    chkPreguntaPrecioVenta.Checked = false;
                }

                if (Convert.ToBoolean(AppConfiguracion.ValorSeccion("utilidad_mas_iva")))
                {
                    rbtnDespuesIva.Checked = true;
                }
                else
                {
                    rbtnAntesIva.Checked = true;
                }

                if (Convert.ToBoolean(AppConfiguracion.ValorSeccion("costoIva")))
                {
                    rbtnCostoIva.Checked = true;
                }
                else
                {
                    rbtnCostoNoIva.Checked = true;
                }
            }
            catch (Exception ex)
            {
                OptionPane.MessageError("Ocurrió un error al cargar la configuración.\n" + ex.Message);
            }
            //miToolTip.SetToolTip(btnInfo, "Ultimos registros de compra.");
            miToolTip.SetToolTip(btnInfoAprox, "Valor base a aplicar aproximación.");

            CalcularUtilidad();
            // Valor por utilidad.
           /* txtCostoPor.Text = UseObject.InsertSeparatorMil(txtCosto.Text);
            txtUtilPor.Text = UseObject.InsertSeparatorMil(
                              Convert.ToInt32(
                              Convert.ToInt32(txtCosto.Text) *
                              Convert.ToDouble(txtUtilidad.Text.Replace('.', ',')) / 100).ToString());
            txtValorPor.Text = UseObject.InsertSeparatorMil(
                Convert.ToInt32(UseObject.RemoveSeparatorMil(txtCostoPor.Text) +
                                UseObject.RemoveSeparatorMil(txtUtilPor.Text)).ToString());

            // Valor sobre utilidad
            txtCostoSobre.Text = UseObject.InsertSeparatorMil(txtCosto.Text);
            var precio = Convert.ToInt32(
                Convert.ToInt32(txtCosto.Text) / ((100 - Convert.ToDouble(txtUtilidad.Text)) / 100));
            var precioAprox = 0;
            if (rbtnDecena.Checked)
            {
                precioAprox = UseObject.Aproximar(precio, false);
            }
            else
            {
                precioAprox = UseObject.Aproximar(precio, true);
            }
            txtUtilSobre.Text = UseObject.InsertSeparatorMil((precioAprox - Convert.ToInt32(txtCosto.Text)).ToString());
            txtValorSobre.Text = UseObject.InsertSeparatorMil(precioAprox.ToString());*/
        }

        private void CalcularUtilidad()
        {
            var costo = "0";
            var util = "0";
            if (!String.IsNullOrEmpty(txtCosto.Text))
            {
                costo = txtCosto.Text;
            }
            if (!String.IsNullOrEmpty(txtUtilidad.Text))
            {
                util = txtUtilidad.Text;
            }
            if (miValidacion.ValidarNumeroInt(costo))
            {
                miError.SetError(txtCosto, null);
                if (miValidacion.ValidarNumeroDecima(util))
                {
                    miError.SetError(txtUtilidad, null);
                    // Valor por utilidad.
                    txtCostoPor.Text = UseObject.InsertSeparatorMil(costo);
                    txtUtilPor.Text = UseObject.InsertSeparatorMil(
                                      Convert.ToInt32(
                                      Convert.ToInt32(costo) *
                                      Convert.ToDouble(util.Replace('.', ',')) / 100).ToString());
                    txtValorPor.Text = UseObject.InsertSeparatorMil(
                        Convert.ToInt32(UseObject.RemoveSeparatorMil(txtCostoPor.Text) +
                                        UseObject.RemoveSeparatorMil(txtUtilPor.Text)).ToString());

                    // Valor sobre utilidad
                    txtCostoSobre.Text = UseObject.InsertSeparatorMil(costo);
                    var precio = Convert.ToInt32(
                        Convert.ToInt32(costo) / ((100 - Convert.ToDouble(util.Replace('.', ','))) / 100));
                    var precioAprox = 0;
                    if (rbtnDecena.Checked)
                    {
                        precioAprox = UseObject.Aproximar(precio, false);
                    }
                    else
                    {
                        precioAprox = UseObject.Aproximar(precio, true);
                    }
                    txtUtilSobre.Text = UseObject.InsertSeparatorMil((precioAprox - Convert.ToInt32(costo)).ToString());
                    txtValorSobre.Text = UseObject.InsertSeparatorMil(precioAprox.ToString());
                }
                else
                {
                    miError.SetError(txtUtilidad, "El valor que ingreso es invalido.");
                }
            }
            else
            {
                miError.SetError(txtCosto, "El valor que ingreso es invalido.");
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            try
            {
                txtNumPromedio_KeyUp(this.txtNumPromedio, null);
                txtValorAprox_KeyUp(this.txtValorAprox, null);
                if (PromedioMatch && ValorAproxMatch)
                {
                    if (rbtnAsignado.Checked)
                    {
                        AppConfiguracion.SaveConfiguration("promedio", "false");
                    }
                    else
                    {
                        AppConfiguracion.SaveConfiguration("promedio", "true");
                    }
                    AppConfiguracion.SaveConfiguration("num_promedio", txtNumPromedio.Text);

                    if (rbtnIncluye.Checked)
                    {
                        AppConfiguracion.SaveConfiguration("precio_venta_iva", "true");
                    }
                    else
                    {
                        AppConfiguracion.SaveConfiguration("precio_venta_iva", "false");
                    }

                    if (rbtnDecena.Checked)
                    {
                        AppConfiguracion.SaveConfiguration("tipo_aprox_precio", "false");
                        AppConfiguracion.SaveConfiguration("aprox_decena", txtValorAprox.Text);
                    }
                    else
                    {
                        AppConfiguracion.SaveConfiguration("tipo_aprox_precio", "true");
                        AppConfiguracion.SaveConfiguration("aprox_centena", txtValorAprox.Text);
                    }

                    if (rbtnPorUtilidad.Checked)
                    {
                        AppConfiguracion.SaveConfiguration("calculo_util_multiplica", "true");
                    }
                    else
                    {
                        AppConfiguracion.SaveConfiguration("calculo_util_multiplica", "false");
                    }

                    if (chkPreguntarUtil.Checked)
                    {
                        AppConfiguracion.SaveConfiguration("pregunta_act_util", "true");
                    }
                    else
                    {
                        AppConfiguracion.SaveConfiguration("pregunta_act_util", "false");
                    }

                    if (chkPreguntaPrecioVenta.Checked)
                    {
                        AppConfiguracion.SaveConfiguration("pregunta_act_pventa", "true");
                    }
                    else
                    {
                        AppConfiguracion.SaveConfiguration("pregunta_act_pventa", "false");
                    }

                    if (rbtnDespuesIva.Checked)
                    {
                        AppConfiguracion.SaveConfiguration("utilidad_mas_iva", "true");
                    }
                    else
                    {
                        AppConfiguracion.SaveConfiguration("utilidad_mas_iva", "false");
                    }

                    if (rbtnCostoIva.Checked)
                    {
                        AppConfiguracion.SaveConfiguration("costoIva", "true");
                    }
                    else
                    {
                        AppConfiguracion.SaveConfiguration("costoIva", "false");
                    }

                    OptionPane.MessageInformation("La configuración se ha almacenó con exito.");
                    OptionPane.MessageInformation("Para que los cambios surtan efectos deberá cerrar todas las ventanas del sistema.");
                }
                /*if (String.IsNullOrEmpty(txtNumPromedio.Text))
                {
                    txtNumPromedio.Text = "1";
                }
                else
                {
                    if (miValidacion.ValidarNumeroInt(txtNumPromedio.Text))
                    {
                        if (rbtnAsignado.Checked)
                        {
                            AppConfiguracion.SaveConfiguration("promedio", "false");
                        }
                        else
                        {
                            AppConfiguracion.SaveConfiguration("promedio", "true");
                        }
                        AppConfiguracion.SaveConfiguration("num_promedio", txtNumPromedio.Text);
                        miError.SetError(txtNumPromedio, null);
                        OptionPane.MessageInformation("La configuración se ha almacenó con exito.");
                    }
                    else
                    {
                        miError.SetError(txtNumPromedio, "El número que ingreso es invalido.");
                    }
                }*/
            }
            catch (Exception ex)
            {
                OptionPane.MessageError("Ocurrió un error al guardar la configuración.\n" + ex.Message);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}