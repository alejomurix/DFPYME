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

namespace Aplicacion.Configuracion.Compra
{
    public partial class FrmConfiguracion : Form
    {
        public FrmConfiguracion()
        {
            InitializeComponent();
        }

        private void FrmConfiguracion_Load(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToBoolean(AppConfiguracion.ValorSeccion("cargaProveedorCompra")))
                {
                    rbtnProveedorCodigo.Checked = true;
                }
                else
                {
                    rbtnProveedorNit.Checked = true;
                }

                if (Convert.ToBoolean(AppConfiguracion.ValorSeccion("menuConsCompra")))
                {
                    chkMenuCompras.Checked = true;
                }
                else
                {
                    chkMenuCompras.Checked = false;
                }

                if (Convert.ToBoolean(AppConfiguracion.ValorSeccion("medidaCantidadCompraSimple")))
                {
                    rbtKilogramo.Checked = true;
                }
                else
                {
                    rbtnArroba.Checked = true;
                }
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            try
            {
                if (rbtnProveedorCodigo.Checked)
                {
                    AppConfiguracion.SaveConfiguration("cargaProveedorCompra", "true");
                }
                else
                {
                    AppConfiguracion.SaveConfiguration("cargaProveedorCompra", "false");
                }

                if (rbtKilogramo.Checked)
                {
                    AppConfiguracion.SaveConfiguration("medidaCantidadCompraSimple", "true");
                }
                else
                {
                    AppConfiguracion.SaveConfiguration("medidaCantidadCompraSimple", "false");
                }

                var frmPrincipal = (Principal.frmPrincipal)this.MdiParent;

                if (chkMenuCompras.Checked)
                {
                    AppConfiguracion.SaveConfiguration("menuConsCompra", "true");
                    frmPrincipal.HabilitarMenuCosultaCompra(true);
                }
                else
                {
                    AppConfiguracion.SaveConfiguration("menuConsCompra", "false");
                    frmPrincipal.HabilitarMenuCosultaCompra(false);
                }

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