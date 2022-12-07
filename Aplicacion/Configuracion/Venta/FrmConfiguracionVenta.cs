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

namespace Aplicacion.Configuracion.Venta
{
    public partial class FrmConfiguracionVenta : Form
    {
        public FrmConfiguracionVenta()
        {
            InitializeComponent();
        }

        private void FrmConfiguracionVenta_Load(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToBoolean(AppConfiguracion.ValorSeccion("cargarCliente")))
                {
                    rbtnClienteSi.Checked = true;
                }
                else
                {
                    rbtnClienteNo.Checked = true;
                }

                if (Convert.ToBoolean(AppConfiguracion.ValorSeccion("reqCantidad")))
                {
                    rbtnCantidadSi.Checked = true;
                }
                else
                {
                    rbtnCantidadNo.Checked = true;
                }

                //pagoFactRemision
                if (Convert.ToBoolean(AppConfiguracion.ValorSeccion("pagoFactRemision")))
                {
                    rbtnRemisionContado.Checked = true;
                }
                else
                {
                    rbtnRemisionCredito.Checked = true;
                }

                if (Convert.ToBoolean(AppConfiguracion.ValorSeccion("permitirDesctoMayor")))
                {
                    rbtnDesctoMayorSi.Checked = true;
                }
                else
                {
                    rbtnDesctoMayorNo.Checked = true;
                }

                if (Convert.ToBoolean(AppConfiguracion.ValorSeccion("permitirDesctoDistrib")))
                {
                    rbtnDesctoDistibSi.Checked = true;
                }
                else
                {
                    rbtnDesctoDistibNo.Checked = true;
                }

                if (Convert.ToBoolean(AppConfiguracion.ValorSeccion("consultaVenta")))
                {
                    this.rbtnPorDia.Checked = true;
                }
                else 
                {
                    this.rbtnPorApertura.Checked = true;
                }

                if (Convert.ToBoolean(AppConfiguracion.ValorSeccion("preguntaPrintVenta")))
                {
                    this.chkPrintFacturaVenta.Checked = true;
                }
                else
                {
                    this.chkPrintFacturaVenta.Checked = false;
                }

                if (Convert.ToBoolean(AppConfiguracion.ValorSeccion("datos_cliente")))
                {
                    this.chkDatosCliente.Checked = true;
                }
                else
                {
                    this.chkDatosCliente.Checked = false;
                }

                if (Convert.ToBoolean(AppConfiguracion.ValorSeccion("permitir_cambio_usuario")))
                {
                    this.chkCambioUsuario.Checked = true;
                }
                else
                {
                    this.chkCambioUsuario.Checked = false;
                }

                if (Convert.ToBoolean(AppConfiguracion.ValorSeccion("cod_barras_cant_peso")))
                {
                    this.chkCodBarrasCantPeso.Checked = true;
                }
                else
                {
                    this.chkCodBarrasCantPeso.Checked = false;
                }

                if (Convert.ToBoolean(AppConfiguracion.ValorSeccion("redondeo_precio_dos")))
                {
                    this.chkRedondearPrecioDos.Checked = true;
                }
                else
                {
                    this.chkRedondearPrecioDos.Checked = false;
                }


                if (Convert.ToBoolean(AppConfiguracion.ValorSeccion("activa_funcion_expulsa_cajon")))
                {
                    this.chkFuncionExpulsaCajonF11.Checked = true;
                }
                else
                {
                    this.chkFuncionExpulsaCajonF11.Checked = false;
                }

                if (Convert.ToBoolean(AppConfiguracion.ValorSeccion("f_11_impsto_bolsa")))
                {
                    this.chkImpuestoBolsa.Checked = true;
                }
                else
                {
                    this.chkImpuestoBolsa.Checked = false;
                }
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
        }

        private void FrmConfiguracionVenta_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyData.Equals(Keys.Escape))
            {
                this.Close();
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            try
            {
                if (rbtnClienteSi.Checked)
                {
                    AppConfiguracion.SaveConfiguration("cargarCliente", "true");
                }
                else
                {
                    AppConfiguracion.SaveConfiguration("cargarCliente", "false");
                }

                if (rbtnCantidadSi.Checked)
                {
                    AppConfiguracion.SaveConfiguration("reqCantidad", "true");
                }
                else
                {
                    AppConfiguracion.SaveConfiguration("reqCantidad", "false");
                }

                if (rbtnRemisionContado.Checked)
                {
                    AppConfiguracion.SaveConfiguration("pagoFactRemision", "true");
                }
                else
                {
                    AppConfiguracion.SaveConfiguration("pagoFactRemision", "false");
                }

                if (rbtnDesctoMayorSi.Checked)
                {
                    AppConfiguracion.SaveConfiguration("permitirDesctoMayor", "true");
                }
                else
                {
                    AppConfiguracion.SaveConfiguration("permitirDesctoMayor", "false");
                }

                if (rbtnDesctoDistibSi.Checked)
                {
                    AppConfiguracion.SaveConfiguration("permitirDesctoDistrib", "true");
                }
                else
                {
                    AppConfiguracion.SaveConfiguration("permitirDesctoDistrib", "false");
                }

                if (this.rbtnPorApertura.Checked)
                {
                    AppConfiguracion.SaveConfiguration("consultaVenta", "false");
                }
                else
                {
                    AppConfiguracion.SaveConfiguration("consultaVenta", "true");
                }

                if (this.chkPrintFacturaVenta.Checked)
                {
                    AppConfiguracion.SaveConfiguration("preguntaPrintVenta", "true");
                }
                else
                {
                    AppConfiguracion.SaveConfiguration("preguntaPrintVenta", "false");
                }

                //chkDatosCliente
                if (this.chkDatosCliente.Checked)
                {
                    AppConfiguracion.SaveConfiguration("datos_cliente", "true");
                }
                else
                {
                    AppConfiguracion.SaveConfiguration("datos_cliente", "false");
                }

                if (this.chkCambioUsuario.Checked)
                {
                    AppConfiguracion.SaveConfiguration("permitir_cambio_usuario", "true");
                }
                else
                {
                    AppConfiguracion.SaveConfiguration("permitir_cambio_usuario", "false");
                }

                if (this.chkRedondearPrecioDos.Checked)
                {
                    AppConfiguracion.SaveConfiguration("redondeo_precio_dos", "true");
                }
                else
                {
                    AppConfiguracion.SaveConfiguration("redondeo_precio_dos", "false");
                }
                
                if (this.chkCodBarrasCantPeso.Checked)
                {
                    AppConfiguracion.SaveConfiguration("cod_barras_cant_peso", "true");
                }
                else
                {
                    AppConfiguracion.SaveConfiguration("cod_barras_cant_peso", "false");
                }

                if (this.chkFuncionExpulsaCajonF11.Checked)
                {
                    AppConfiguracion.SaveConfiguration("activa_funcion_expulsa_cajon", "true");
                }
                else
                {
                    AppConfiguracion.SaveConfiguration("activa_funcion_expulsa_cajon", "false");
                }

                if (this.chkImpuestoBolsa.Checked)
                {
                    AppConfiguracion.SaveConfiguration("f_11_impsto_bolsa", "true");
                }
                else
                {
                    AppConfiguracion.SaveConfiguration("f_11_impsto_bolsa", "false");
                }



                /*permitirDesctoMayor" value="false"/>
 <add key="permitirDesctoDistrib" value="false"/>*/

                var frmPrincipal = (Principal.frmPrincipal)this.MdiParent;
                frmPrincipal.CargarCliente();
                OptionPane.MessageInformation("La configuración se ha almacenó con exito.");
                OptionPane.MessageInformation("Para que los cambios surtan efectos deberá cerrar todas las ventanas del sistema.");
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
    }
}