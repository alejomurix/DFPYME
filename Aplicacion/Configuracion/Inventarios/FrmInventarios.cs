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

namespace Aplicacion.Configuracion.Inventarios
{
    public partial class FrmInventarios : Form
    {
        private ToolTip miTool;

        public FrmInventarios()
        {
            InitializeComponent();
            miTool = new ToolTip();
        }

        private void FrmInventarios_Load(object sender, EventArgs e)
        {
            try
            {
                miTool.SetToolTip(btnInfoNivleCero,
                "Establece el valor del inventario en cero, de aquellos artículos que no presentan cantidades físicas en inventario.");
                miTool.SetToolTip(btnInfoInventarioSistema, 
                "Establece, como cantidades en inventario, las cantidades que el sistema venga registrando para cada inventario realizado y sistematizado en la unidad económica.");
                miTool.SetToolTip(btnInfoFacturaCero, 
                "Permite emitir factura de venta sin tener en cuenta las cantidades en inventario de los artículos facturados.");

                //frm_consulta_inventario
                if (Convert.ToBoolean(AppConfiguracion.ValorSeccion("frm_consulta_inventario")))
                {
                    chkFrmConsultaInventario.Checked = true;
                }
                else
                {
                    chkFrmConsultaInventario.Checked = false;
                }

                if (Convert.ToBoolean(AppConfiguracion.ValorSeccion("verCosto")))
                {
                    chkVerCostoInventario.Checked = true;
                }
                else
                {
                    chkVerCostoInventario.Checked = false;
                }

                if (Convert.ToBoolean(AppConfiguracion.ValorSeccion("costoMasIva")))
                {
                    chkCostoConIva.Checked = true;
                }
                else
                {
                    chkCostoConIva.Checked = false;
                }

                if (Convert.ToBoolean(AppConfiguracion.ValorSeccion("trasaldo_inven_cant_negativa")))
                {
                    chkNegativoTraslado.Checked = true;
                }
                else
                {
                    chkNegativoTraslado.Checked = false;
                }

                if (Convert.ToBoolean(AppConfiguracion.ValorSeccion("nivelcero")))
                {
                    chkNivelar.Checked = true;
                }
                else
                {
                    chkNivelar.Checked = false;
                }

                if (Convert.ToBoolean(AppConfiguracion.ValorSeccion("inventariosistema")))
                {
                    chkInventarioSistema.Checked = true;
                }
                else
                {
                    chkInventarioSistema.Checked = false;
                }

                if (Convert.ToBoolean(AppConfiguracion.ValorSeccion("fact-negativo")))
                {
                    chkFacturaNegativo.Checked = true;
                }
                else
                {
                    chkFacturaNegativo.Checked = false;
                }
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
        }

        private void FrmInventarios_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData.Equals(Keys.Escape))
            {
                this.Close();
            }
        }

        private void btnInfoNivleCero_Click(object sender, EventArgs e)
        {
            OptionPane.MessageInformation("Establece el valor del inventario en cero, de aquellos artículos que no presentan " +
                                          "cantidades físicas en inventario.");
        }

        private void btnInfoInventarioSistema_Click(object sender, EventArgs e)
        {
            OptionPane.MessageInformation("Establece, como cantidades en inventario, las cantidades que el sistema venga" +
                                          "registrando para cada inventario realizado y sistematizado en la unidad económica.");
        }

        private void btnInfoFacturaCero_Click(object sender, EventArgs e)
        {
            OptionPane.MessageInformation("Permite emitir factura de venta sin tener en cuenta las cantidades en inventario" +
                                          "de los artículos facturados.");
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            try
            {
                //chkFrmConsultaInventario  frm_consulta_inventario
                if (chkFrmConsultaInventario.Checked)
                {
                    AppConfiguracion.SaveConfiguration("frm_consulta_inventario", "true");
                }
                else
                {
                    AppConfiguracion.SaveConfiguration("frm_consulta_inventario", "false");
                }
                var frmPrincipal = (Principal.frmPrincipal)this.MdiParent;
                frmPrincipal._ConsultaInventario = Convert.ToBoolean(AppConfiguracion.ValorSeccion("frm_consulta_inventario"));

                if (chkVerCostoInventario.Checked)
                {
                    AppConfiguracion.SaveConfiguration("verCosto", "true");
                }
                else
                {
                    AppConfiguracion.SaveConfiguration("verCosto", "false");
                }

                if (chkCostoConIva.Checked)
                {
                    AppConfiguracion.SaveConfiguration("costoMasIva", "true");
                }
                else
                {
                    AppConfiguracion.SaveConfiguration("costoMasIva", "false");
                }

                if (chkNegativoTraslado.Checked)
                {
                    AppConfiguracion.SaveConfiguration("trasaldo_inven_cant_negativa", "true");
                }
                else
                {
                    AppConfiguracion.SaveConfiguration("trasaldo_inven_cant_negativa", "false");
                }

                if (chkNivelar.Checked)
                {
                    AppConfiguracion.SaveConfiguration("nivelcero", "true");
                }
                else
                {
                    AppConfiguracion.SaveConfiguration("nivelcero", "false");
                }

                if (chkInventarioSistema.Checked)
                {
                    AppConfiguracion.SaveConfiguration("inventariosistema", "true");
                }
                else
                {
                    AppConfiguracion.SaveConfiguration("inventariosistema", "false");
                }

                if (chkFacturaNegativo.Checked)
                {
                    AppConfiguracion.SaveConfiguration("fact-negativo", "true");
                }
                else
                {
                    AppConfiguracion.SaveConfiguration("fact-negativo", "false");
                }
                OptionPane.MessageInformation("Los cambios se almacenarón con exito.");
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