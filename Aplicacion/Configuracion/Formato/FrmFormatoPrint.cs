using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Utilities;
using CustomControl;

namespace Aplicacion.Configuracion.Formato
{
    public partial class FrmFormatoPrint : Form
    {
        public FrmFormatoPrint()
        {
            InitializeComponent();
        }

        private void FrmFormatoPrint_Load(object sender, EventArgs e)
        {
            try
            {
                this.cbFuenteImpresion.DataSource = new List<MiCriterio> 
                { 
                    new MiCriterio 
                        { 
                            id = 1, 
                            Nombre = "Lucida Console"
                        },
                    new MiCriterio 
                        { 
                            id = 2, 
                            Nombre = "Lucida Sans Unicode"
                        },
                    new MiCriterio 
                        { 
                            id = 3, 
                            Nombre = "Courier New"
                        },
                    new MiCriterio 
                        { 
                            id = 4, 
                            Nombre = "LUCIDA SANS TYPEWRITER"
                        }
                };
                this.cbFuenteImpresion.SelectedValue = Convert.ToInt32(AppConfiguracion.ValorSeccion("id_fuente_impresion"));

                this.nudTamanioFuente.Value = Convert.ToInt32(AppConfiguracion.ValorSeccion("tamanio_fuente_impresion"));

                this.txtImpresora.Text = AppConfiguracion.ValorSeccion("impresora");

                if (Convert.ToBoolean(AppConfiguracion.ValorSeccion("print_termal_80mm")))
                {
                    chkPrinter80mm.Checked = true;
                    cbFuenteImpresion.Enabled = true;
                    nudTamanioFuente.Enabled = true;
                    chkPrinter58mm.Checked = false;
                }
                else
                {
                    chkPrinter58mm.Checked = true;
                    cbFuenteImpresion.Enabled = false;
                    nudTamanioFuente.Enabled = false;
                    chkPrinter80mm.Checked = false;
                }

                chkNegrita58mm.Checked = Convert.ToBoolean(AppConfiguracion.ValorSeccion("negrita_prt_term_58mm"));
                //


                if (Convert.ToBoolean(AppConfiguracion.ValorSeccion("printInventario")))
                {
                    RInventarioTirilla.Checked = true;
                }
                else
                {
                    RInventarioMCarta.Checked = true;
                }

                if (Convert.ToBoolean(AppConfiguracion.ValorSeccion("printDocEquivalente")))
                {
                    REquivalenteTirilla.Checked = true;
                }
                else
                {
                    REquivalenteMCarta.Checked = true;
                }

                if (Convert.ToBoolean(AppConfiguracion.ValorSeccion("printEditFrv")))
                {
                    RFrvEdicionTirilla.Checked = true;
                }
                else
                {
                    RFrvEdicionMCarta.Checked = true;
                }

                if (Convert.ToBoolean(AppConfiguracion.ValorSeccion("printEgreso")))
                {
                    REgresoTirilla.Checked = true;
                }
                else
                {
                    REgresoMCarta.Checked = true;
                }

                if (Convert.ToBoolean(AppConfiguracion.ValorSeccion("printIngreso")))
                {
                    RIngresoTirilla.Checked = true;
                }
                else
                {
                    RIngresoMCarta.Checked = true;
                }

                if (Convert.ToBoolean(AppConfiguracion.ValorSeccion("printRboCaja")))
                {
                    RRboCajaTirilla.Checked = true;
                }
                else
                {
                    RRboCajaMCarta.Checked = true;
                }

                if (Convert.ToBoolean(AppConfiguracion.ValorSeccion("printRboAnticpo")))
                {
                    RRboAnticipoTirilla.Checked = true;
                }
                else
                {
                    RRboAnticipoMCarta.Checked = true;
                }

                if (Convert.ToBoolean(AppConfiguracion.ValorSeccion("printNotaCredito")))
                {
                    RNCreditoTirilla.Checked = true;
                }
                else
                {
                    RNCreditoMCarta.Checked = true;
                }

                if (Convert.ToBoolean(AppConfiguracion.ValorSeccion("printCompDiario")))
                {
                    RCompDiarioTirilla.Checked = true;
                }
                else
                {
                    RCompDiarioMCarta.Checked = true;
                }

                if (Convert.ToBoolean(AppConfiguracion.ValorSeccion("printCopiaFVenta")))
                {
                    RCopiaFVentaTirilla.Checked = true;
                }
                else
                {
                    RCopiaFVentaMCarta.Checked = true;
                }

                if (Convert.ToBoolean(AppConfiguracion.ValorSeccion("printCopiaRemision")))
                {
                    RCopiaRemisionTirilla.Checked = true;
                }
                else
                {
                    RCopiaRemisionMCarta.Checked = true;
                }

                if (Convert.ToBoolean(AppConfiguracion.ValorSeccion("printEgresoDevVenta")))
                {
                    REgresoDevolVentaTirilla.Checked = true;
                }
                else
                {
                    REgresoDevolVentaMCarta.Checked = true;
                }

                if (Convert.ToBoolean(AppConfiguracion.ValorSeccion("printNotaCreCliente")))
                {
                    RNotaCreClienteTirilla.Checked = true;
                }
                else
                {
                    RNotaCreClienteMCarta.Checked = true;
                }

                if (Convert.ToBoolean(AppConfiguracion.ValorSeccion("printCompDevolVenta")))
                {
                    RCompDevolVentaTirilla.Checked = true;
                }
                else
                {
                    RCompDevolVentaMCarta.Checked = true;
                }

                //RCarteraClienteMCarta
                if (Convert.ToBoolean(AppConfiguracion.ValorSeccion("printCarteraCliente")))
                {
                    RCarteraClienteTirilla.Checked = true;
                }
                else
                {
                    RCarteraClienteMCarta.Checked = true;
                }

                //RCarteraProveedorTirilla
                //printCarteraProveedor
                if (Convert.ToBoolean(AppConfiguracion.ValorSeccion("printCarteraProveedor")))
                {
                    RCarteraProveedorTirilla.Checked = true;
                }
                else
                {
                    RCarteraProveedorMCarta.Checked = true;
                }

                //printInformeRetiro
                //RInformeRetiroTirilla
                if (Convert.ToBoolean(AppConfiguracion.ValorSeccion("printInformeRetiro")))
                {
                    RInformeRetiroTirilla.Checked = true;
                }
                else
                {
                    RInformeRetiroMCarta.Checked = true;
                }


            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
        }

        private void FrmFormatoPrint_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData.Equals(Keys.Escape))
            {
                this.Close();
            }
        }

        private void chkPrinter58mm_CheckedChanged(object sender, EventArgs e)
        {
            //ValidarMMprinter();
            if (chkPrinter58mm.Checked)
            {
                cbFuenteImpresion.Enabled = false;
                nudTamanioFuente.Enabled = false;
                chkPrinter80mm.Checked = false;
            }
            else
            {
                cbFuenteImpresion.Enabled = true;
                nudTamanioFuente.Enabled = true;
                chkPrinter80mm.Checked = true;
            }
        }

        private void chkPrinter80mm_CheckedChanged(object sender, EventArgs e)
        {
            //ValidarMMprinter();
            if (chkPrinter80mm.Checked)
            {
                cbFuenteImpresion.Enabled = true;
                nudTamanioFuente.Enabled = true;
                chkPrinter58mm.Checked = false;
            }
            else
            {
                cbFuenteImpresion.Enabled = false;
                nudTamanioFuente.Enabled = false;
                chkPrinter58mm.Checked = true;
            }
        }

        private void ValidarMMprinter()
        {
            if (chkPrinter58mm.Checked)
            {
                cbFuenteImpresion.Enabled = false;
                nudTamanioFuente.Enabled = false;
                chkPrinter80mm.Checked = false;
            }
            else
            {
                cbFuenteImpresion.Enabled = true;
                nudTamanioFuente.Enabled = true;
                chkPrinter80mm.Checked = true;
            }
        }

        private void btnPruebaImpresion_Click(object sender, EventArgs e)
        {
            try
            {
                AppConfiguracion.SaveConfiguration("id_fuente_impresion", this.cbFuenteImpresion.SelectedValue.ToString());
                AppConfiguracion.SaveConfiguration("fuente_impresion", this.cbFuenteImpresion.Text);
                AppConfiguracion.SaveConfiguration("tamanio_fuente_impresion", this.nudTamanioFuente.Value.ToString());
                AppConfiguracion.SaveConfiguration("impresora", this.txtImpresora.Text);

                int MaxCharacters = 30; //35;
                Ticket ticket = new Ticket();
                ticket.UseItem = false;
                foreach (var datos in UseObject.StringBuilderDataCenter("MI EMPRESA", MaxCharacters))
                {
                    ticket.AddHeaderLine(datos);
                }
                foreach (var datos in UseObject.StringBuilderDataCenter("NIT  111111111-1", MaxCharacters))
                {
                    ticket.AddHeaderLine(datos);
                }
                foreach (var datos in UseObject.StringBuilderDataCenter("TEL  312 000 00 00", MaxCharacters))
                {
                    ticket.AddHeaderLine(datos);
                }
                ticket.AddHeaderLine("");
                ticket.AddHeaderLine("-----------------------------------");
                ticket.AddHeaderLine("");

                ticket.AddHeaderLine("         SUBTOTAL :" + UseObject.StringBuilderDetalleTotal("84"));
                ticket.AddHeaderLine("              IVA :" + UseObject.StringBuilderDetalleTotal("16"));
                ticket.AddHeaderLine("       TOTAL NETO :" + UseObject.StringBuilderDetalleTotal("100"));
                
                ticket.AddHeaderLine("");
                ticket.AddHeaderLine("----------[ DETALLE IVA ]----------");
                ticket.AddHeaderLine(UseObject.StringBuilderDetalleIva(16, "100", "84", "16"));
                ticket.PrintTicket("");


                /*ticket.AddHeaderLine("AUTOSERVICIO 4 ESQUINAS");
                ticket.AddHeaderLine("CORR SAN LORENZO");
                ticket.AddHeaderLine("RIOSUCIO");
                ticket.AddHeaderLine("CALDAS");
                ticket.AddHeaderLine("N.I.T.: 9.911.893-2");
                //ticket.AddHeaderLine("_____________________________");
                ticket.AddHeaderLine("---------------------------");
                ticket.AddHeaderLine("Ticket Venta No. ");
                ticket.AddHeaderLine("Fecha: ");*/
                //ticket.AddHeaderLine("_____________________________");
               /* ticket.AddHeaderLine("---------------------------");
                ticket.AddHeaderLine("ARTICULO CANT. V UND. TOTAL");
                ticket.AddHeaderLine("---------------------------");
                ticket.AddHeaderLine("ACEITE CREMOSO LA BUENA 330");
                ticket.AddHeaderLine("      1  200.000  2.200.000");*/
                /*ticket.AddHeaderLine("");
                ticket.AddHeaderLine("");
                ticket.AddHeaderLine("");
                ticket.AddHeaderLine("");//
                ticket.AddHeaderLine("---------------------------");
                ticket.AddHeaderLine("TOTAL:  $         2.000.000");
                ticket.AddHeaderLine("---------------------------");
                ticket.AddHeaderLine("Efectivo: $       2.000.000");
                ticket.AddHeaderLine("Cambio  : $             0");
                ticket.AddHeaderLine("");
                ticket.AddHeaderLine("Atendido por: CAJERO 01");
                ticket.AddHeaderLine("REGIMEN SIMPLIFICADO");*/


                ticket.PrintTicket("");
            }
            catch(Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            try
            {
                AppConfiguracion.SaveConfiguration("id_fuente_impresion", this.cbFuenteImpresion.SelectedValue.ToString());
                AppConfiguracion.SaveConfiguration("fuente_impresion", this.cbFuenteImpresion.Text);
                AppConfiguracion.SaveConfiguration("tamanio_fuente_impresion", this.nudTamanioFuente.Value.ToString());
                AppConfiguracion.SaveConfiguration("impresora", this.txtImpresora.Text);

                if (chkPrinter80mm.Checked)
                {
                    AppConfiguracion.SaveConfiguration("print_termal_80mm", "true");
                }
                else
                {
                    AppConfiguracion.SaveConfiguration("print_termal_80mm", "false");
                }

                if (chkNegrita58mm.Checked)
                {
                    AppConfiguracion.SaveConfiguration("negrita_prt_term_58mm", "true");
                }
                else
                {
                    AppConfiguracion.SaveConfiguration("negrita_prt_term_58mm", "false");
                }

                if (RInventarioTirilla.Checked)
                {
                    AppConfiguracion.SaveConfiguration("printInventario", "true");
                }
                else
                {
                    AppConfiguracion.SaveConfiguration("printInventario", "false");
                }

                if (RFrvEdicionTirilla.Checked)
                {
                    AppConfiguracion.SaveConfiguration("printEditFrv", "true");
                }
                else
                {
                    AppConfiguracion.SaveConfiguration("printEditFrv", "false");
                }

                if (REquivalenteTirilla.Checked)
                {
                    AppConfiguracion.SaveConfiguration("printDocEquivalente", "true");
                }
                else
                {
                    AppConfiguracion.SaveConfiguration("printDocEquivalente", "false");
                }

                if (REgresoTirilla.Checked)
                {
                    AppConfiguracion.SaveConfiguration("printEgreso", "true");
                }
                else
                {
                    AppConfiguracion.SaveConfiguration("printEgreso", "false");
                }

                if (RIngresoTirilla.Checked)
                {
                    AppConfiguracion.SaveConfiguration("printIngreso", "true");
                }
                else
                {
                    AppConfiguracion.SaveConfiguration("printIngreso", "false");
                }

                if (RRboCajaTirilla.Checked)
                {
                    AppConfiguracion.SaveConfiguration("printRboCaja", "true");
                }
                else
                {
                    AppConfiguracion.SaveConfiguration("printRboCaja", "false");
                }

                if (RRboAnticipoTirilla.Checked)
                {
                    AppConfiguracion.SaveConfiguration("printRboAnticpo", "true");
                }
                else
                {
                    AppConfiguracion.SaveConfiguration("printRboAnticpo", "false");
                }

                if (RNCreditoTirilla.Checked)
                {
                    AppConfiguracion.SaveConfiguration("printNotaCredito", "true");
                }
                else
                {
                    AppConfiguracion.SaveConfiguration("printNotaCredito", "false");
                }

                if (RCompDiarioTirilla.Checked)
                {
                    AppConfiguracion.SaveConfiguration("printCompDiario", "true");
                }
                else
                {
                    AppConfiguracion.SaveConfiguration("printCompDiario", "false");
                }

                if (RCopiaFVentaTirilla.Checked)
                {
                    AppConfiguracion.SaveConfiguration("printCopiaFVenta", "true");
                }
                else
                {
                    AppConfiguracion.SaveConfiguration("printCopiaFVenta", "false");
                }

                if (RCopiaRemisionTirilla.Checked)
                {
                    AppConfiguracion.SaveConfiguration("printCopiaRemision", "true");
                }
                else
                {
                    AppConfiguracion.SaveConfiguration("printCopiaRemision", "false");
                }

                if (REgresoDevolVentaTirilla.Checked)
                {
                    AppConfiguracion.SaveConfiguration("printEgresoDevVenta", "true");
                }
                else
                {
                    AppConfiguracion.SaveConfiguration("printEgresoDevVenta", "false");
                }

                //RNotaCreClienteTirilla
                if (RNotaCreClienteTirilla.Checked)
                {
                    AppConfiguracion.SaveConfiguration("printNotaCreCliente", "true");
                }
                else
                {
                    AppConfiguracion.SaveConfiguration("printNotaCreCliente", "false");
                }

                if (RCompDevolVentaTirilla.Checked)
                {
                    AppConfiguracion.SaveConfiguration("printCompDevolVenta", "true");
                }
                else
                {
                    AppConfiguracion.SaveConfiguration("printCompDevolVenta", "false");
                }

                if (RCarteraClienteTirilla.Checked)
                {
                    AppConfiguracion.SaveConfiguration("printCarteraCliente", "true");
                }
                else
                {
                    AppConfiguracion.SaveConfiguration("printCarteraCliente", "false");
                }

                if (RCarteraProveedorTirilla.Checked)
                {
                    AppConfiguracion.SaveConfiguration("printCarteraProveedor", "true");
                }
                else
                {
                    AppConfiguracion.SaveConfiguration("printCarteraProveedor", "false");
                }

                //printInformeRetiro
                //RInformeRetiroTirilla
                if (RInformeRetiroTirilla.Checked)
                {
                    AppConfiguracion.SaveConfiguration("printInformeRetiro", "true");
                }
                else
                {
                    AppConfiguracion.SaveConfiguration("printInformeRetiro", "false");
                }

                OptionPane.MessageInformation("Los datos se almacenarón con exito!");
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