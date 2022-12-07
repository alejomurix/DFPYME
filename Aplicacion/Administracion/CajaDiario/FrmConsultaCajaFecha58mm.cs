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

namespace Aplicacion.Administracion.CajaDiario
{
    public partial class FrmConsultaCajaFecha58mm : Form
    {
        private BussinesLayer.Clases.BussinesCaja miBussinesCaja;

        private Administracion.CajaDiario.FrmCajaDiario frmCaja;

        private DialogResult Rta { set; get; }

        public FrmConsultaCajaFecha58mm()
        {
            InitializeComponent();
            this.miBussinesCaja = new BussinesLayer.Clases.BussinesCaja();
            try
            {
                //this.frmCaja = new Administracion.CajaDiario.FrmCajaDiario();
                ImageList imgList = new ImageList();

               /*imgList.Images.Add("Convencional", Image.FromFile(
                    AppConfiguracion.ValorSeccion("report") + @"\resource\convencional.ico"));*/
                imgList.Images.Add("Retroactivo", Image.FromFile(
                    AppConfiguracion.ValorSeccion("report") + @"\resource\consulta-inventario.ico"));

                /*imgList.Images.Add("Convencional", Image.FromFile(
                    @"D:\Proyectos\SistemaFacturacion\SVN-SIF-I\Test-Setup-1\BackUp-3\Edit-Home\SistemaFactura\Aplicacion\Recursos\Iconos\convencional.ico"));
                imgList.Images.Add("Retroactivo", Image.FromFile(
                    @"D:\Proyectos\SistemaFacturacion\SVN-SIF-I\Test-Setup-1\BackUp-3\Edit-Home\SistemaFactura\Aplicacion\Recursos\Iconos\consulta-inventario.ico"));
                */

                //@"D:\Proyectos\SistemaFacturacion\SVN-SIF-I\Test-Setup-1\BackUp-3\Edit-Home\SistemaFactura\Aplicacion\Recursos\Iconos\convencional.ico"));

                //@"D:\Proyectos\SistemaFacturacion\SVN-SIF-I\Test-Setup-1\BackUp-3\Edit-Home\SistemaFactura\Aplicacion\Recursos\Iconos\consulta-inventario.ico"));

                tcCajaDiario.ImageList = imgList;
                tpConvencional.ImageIndex = 0;
                tpRetroActivo.ImageIndex = 1;
            }
            catch (Exception ex)
            {
                CustomControl.OptionPane.MessageError(ex.Message);
            }
        }

        private void FrmConsultaCaja_Load(object sender, EventArgs e)
        {
            try
            {
                this.tcCajaDiario.Controls.Remove(tpRetroActivo);
                this.cbCajas.DataSource = miBussinesCaja.Cajas();
                this.cbCajas.SelectedValue = Convert.ToInt32(AppConfiguracion.ValorSeccion("id_caja"));
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
            /*try
            {
                if (Convert.ToBoolean(Utilities.AppConfiguracion.ValorSeccion("install"))) //Compilacion para instalar
                {
                    Utilities.AppConfiguracion.SaveConfiguration("report", Application.StartupPath);
                }
                else
                {
                    Utilities.AppConfiguracion.SaveConfiguration("report", "C:");
                }
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }*/
        }

        private void btnComprobante_Click(object sender, EventArgs e)
        {
            frmCaja = new FrmCajaDiario();
            this.frmCaja.PeriodoFecha = false;
            frmCaja.Soporte = true;
            frmCaja.Numeracion = true;
            frmCaja.General = false;
            frmCaja.RetroActivo = false;
            frmCaja.Fecha = dtpFecha.Value;
            frmCaja.IdCaja = Convert.ToInt32(this.cbCajas.SelectedValue);
            //frmCaja.ReportPath = @"C:\reports\ComprobanteDiario_V2.rdlc";
            frmCaja.ReportPath = AppConfiguracion.ValorSeccion("report") + @"\reports\ComprobanteDiario_V2.rdlc";

            if (!Convert.ToBoolean(AppConfiguracion.ValorSeccion("printCompDiario")))
            {
                /*DialogResult rta = MessageBox.Show("¿Desea visualizar la impresión del comprobante diario?", "Comprobante Diario",
                    MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);*/
                FrmPrint frmPrint = new FrmPrint();
                frmPrint.StringCaption = "Comprobante Diario";
                frmPrint.StringMessage = "Impresión del Comprobante de Diario";
                DialogResult rta = frmPrint.ShowDialog();

                if (rta.Equals(DialogResult.No))
                {
                    frmCaja.ShowDialog();
                }
                else
                {
                    if (rta.Equals(DialogResult.Yes))
                    {
                        frmCaja.LoadReport();
                        frmCaja.rptVCajaDiario_Print(null, null);
                    }
                }
            }
            else
            {
                frmCaja.Print58mm();
            }
        }

        private void btnFiscal_Click(object sender, EventArgs e)
        {
            frmCaja = new FrmCajaDiario();
            frmCaja.Soporte = false;
            frmCaja.Numeracion = true;
            frmCaja.General = false;
            frmCaja.RetroActivo = false;
            frmCaja.Fecha = dtpFecha.Value;
            frmCaja.IdCaja = Convert.ToInt32(this.cbCajas.SelectedValue);
            frmCaja.ReportPath = AppConfiguracion.ValorSeccion("report") + @"\reports\Informe_Fiscal_Ventas_V2_ACT.rdlc";
            //frmCaja.ReportPath = @"C:\reports\Informe_Fiscal_Ventas_V2.rdlc";

           /* frmCaja.ReportPath = @"
C:\Users\alejoQ2009\Documents\Visual Studio 2010\Projects\Edicion\DFPYME\Aplicacion\Informes\Informe_Fiscal_Ventas_V2.rdlc";*/
           /* DialogResult rta = MessageBox.Show("¿Desea visualizar la impresión del Informe Fiscal?", "Comprobante Diario",
                    MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);*/
            FrmPrint frmPrint = new FrmPrint();
            frmPrint.StringCaption = "Comprobante Diario";
            frmPrint.StringMessage = "Impresión del Informe Fiscal";
            DialogResult rta = frmPrint.ShowDialog();

            if (rta.Equals(DialogResult.No))
            {
                frmCaja.ShowDialog();
            }
            else
            {
                if (rta.Equals(DialogResult.Yes))
                {
                    frmCaja.LoadReport();
                    frmCaja.rptVCajaDiario_Print(null, null);
                }
            }
        }

        private void btnComprobanteGeneral_Click(object sender, EventArgs e)
        {
            frmCaja = new FrmCajaDiario();
            frmCaja.Soporte = true;
            frmCaja.Numeracion = true;
            frmCaja.General = true;
            frmCaja.RetroActivo = false;
            frmCaja.Fecha = dtpFecha.Value;
            frmCaja.ReportPath = AppConfiguracion.ValorSeccion("report") + @"\reports\ComprobanteDiarioGeneral.rdlc";
            //frmCaja.ReportPath = @"c:\reports\ComprobanteDiarioGeneral.rdlc";

            if (!Convert.ToBoolean(AppConfiguracion.ValorSeccion("printCompDiario")))
            {
                /*DialogResult rta = MessageBox.Show("¿Desea visualizar la impresión del comprobante diario?", "Comprobante Diario",
                    MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);*/
                FrmPrint frmPrint = new FrmPrint();
                frmPrint.StringCaption = "Comprobante Diario";
                frmPrint.StringMessage = "Impresión del Comprobante de Diario";
                DialogResult rta = frmPrint.ShowDialog();

                if (rta.Equals(DialogResult.No))
                {
                    frmCaja.ShowDialog();
                }
                else
                {
                    if (rta.Equals(DialogResult.Yes))
                    {
                        frmCaja.LoadReport();
                        frmCaja.rptVCajaDiario_Print(null, null);
                    }
                }
            }
            else
            {
                frmCaja.PrintComprobantePos_2();
            }
        }

        private void btnFiscalGeneral_Click(object sender, EventArgs e)
        {
            frmCaja = new FrmCajaDiario();
            frmCaja.Soporte = false;
            frmCaja.Numeracion = true;
            frmCaja.General = true;
            frmCaja.RetroActivo = false;
            frmCaja.Fecha = dtpFecha.Value;
            frmCaja.ReportPath = AppConfiguracion.ValorSeccion("report") + @"\reports\Informe_Fiscal_Ventas_General.rdlc";
            //frmCaja.ReportPath = @"C:\reports\Informe_Fiscal_Ventas_General.rdlc";

            //frmCaja.ReportPath = @"
//C:\Users\alejo_cq\Documents\Visual Studio 2010\Projects\DFPYME\Aplicacion\Informes\Informe_Fiscal_Ventas_General.rdlc";

            /*DialogResult rta = MessageBox.Show("¿Desea visualizar la impresión del Informe Fiscal?", "Comprobante Diario",
                    MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);*/
            FrmPrint frmPrint = new FrmPrint();
            frmPrint.StringCaption = "Comprobante Diario";
            frmPrint.StringMessage = "Impresión del Informe Fiscal";
            DialogResult rta = frmPrint.ShowDialog();

            if (rta.Equals(DialogResult.No))
            {
                frmCaja.ShowDialog();
            }
            else
            {
                if (rta.Equals(DialogResult.Yes))
                {
                    frmCaja.LoadReport();
                    frmCaja.rptVCajaDiario_Print(null, null);
                }
            }
        }

        private void btnComprobanteCajaR_Click(object sender, EventArgs e)
        {
            frmCaja = new FrmCajaDiario();
            frmCaja.Soporte = true;
            frmCaja.Numeracion = true;
            frmCaja.General = false;
            frmCaja.RetroActivo = true;
            frmCaja.Fecha = dtpFecha.Value;
            frmCaja.IdCaja = Convert.ToInt32(this.cbCajas.SelectedValue);
            frmCaja.ReportPath = AppConfiguracion.ValorSeccion("report") + @"\reports\ComprobanteDiario_V2.rdlc";
            if (!Convert.ToBoolean(AppConfiguracion.ValorSeccion("printCompDiario")))
            {
                /*DialogResult rta = MessageBox.Show("¿Desea visualizar la impresión del comprobante diario?", "Comprobante Diario",
                    MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);*/
                FrmPrint frmPrint = new FrmPrint();
                frmPrint.StringCaption = "Comprobante Diario";
                frmPrint.StringMessage = "Impresión del Comprobante de Diario";
                DialogResult rta = frmPrint.ShowDialog();

                if (rta.Equals(DialogResult.No))
                {
                    frmCaja.ShowDialog();
                }
                else
                {
                    if (rta.Equals(DialogResult.Yes))
                    {
                        frmCaja.LoadReport();
                        frmCaja.rptVCajaDiario_Print(null, null);
                    }
                }
            }
            else
            {
                frmCaja.PrintComprobantePos();
            }
        }

        private void btnFiscalCajaR_Click(object sender, EventArgs e)
        {
            frmCaja = new FrmCajaDiario();
            frmCaja.Soporte = false;
            frmCaja.Numeracion = true;
            frmCaja.General = false;
            frmCaja.RetroActivo = true;
            frmCaja.Fecha = dtpFecha.Value;
            frmCaja.IdCaja = Convert.ToInt32(this.cbCajas.SelectedValue);
            frmCaja.ReportPath = AppConfiguracion.ValorSeccion("report") + @"\reports\Informe_Fiscal_Ventas_V2.rdlc";
            /*DialogResult rta = MessageBox.Show("¿Desea visualizar la impresión del Informe Fiscal?", "Comprobante Diario",
                    MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);*/
            FrmPrint frmPrint = new FrmPrint();
            frmPrint.StringCaption = "Comprobante Diario";
            frmPrint.StringMessage = "Impresión del Informe Fiscal";
            DialogResult rta = frmPrint.ShowDialog();

            if (rta.Equals(DialogResult.No))
            {
                frmCaja.ShowDialog();
            }
            else
            {
                if (rta.Equals(DialogResult.Yes))
                {
                    frmCaja.LoadReport();
                    frmCaja.rptVCajaDiario_Print(null, null);
                }
            }
        }

        private void btnCompGralR_Click(object sender, EventArgs e)
        {
            frmCaja = new FrmCajaDiario();
            frmCaja.Soporte = true;
            frmCaja.Numeracion = true;
            frmCaja.General = true;
            frmCaja.RetroActivo = true;
            frmCaja.Fecha = dtpFecha.Value;
            frmCaja.ReportPath = AppConfiguracion.ValorSeccion("report") + @"\reports\ComprobanteDiarioGeneral.rdlc";
            if (!Convert.ToBoolean(AppConfiguracion.ValorSeccion("printCompDiario")))
            {
                /*DialogResult rta = MessageBox.Show("¿Desea visualizar la impresión del comprobante diario?", "Comprobante Diario",
                    MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);*/
                FrmPrint frmPrint = new FrmPrint();
                frmPrint.StringCaption = "Comprobante Diario";
                frmPrint.StringMessage = "Impresión del Comprobante de Diario";
                DialogResult rta = frmPrint.ShowDialog();

                if (rta.Equals(DialogResult.No))
                {
                    frmCaja.ShowDialog();
                }
                else
                {
                    if (rta.Equals(DialogResult.Yes))
                    {
                        frmCaja.LoadReport();
                        frmCaja.rptVCajaDiario_Print(null, null);
                    }
                }
            }
            else
            {
                frmCaja.PrintComprobantePos();
            }
        }

        private void btnFiscalGralR_Click(object sender, EventArgs e)
        {
            frmCaja = new FrmCajaDiario();
            frmCaja.Soporte = false;
            frmCaja.Numeracion = true;
            frmCaja.General = true;
            frmCaja.RetroActivo = true;
            frmCaja.Fecha = dtpFecha.Value;
            frmCaja.ReportPath = AppConfiguracion.ValorSeccion("report") + @"\reports\Informe_Fiscal_Ventas_General.rdlc";
            /*DialogResult rta = MessageBox.Show("¿Desea visualizar la impresión del Informe Fiscal?", "Comprobante Diario",
                    MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);*/
            FrmPrint frmPrint = new FrmPrint();
            frmPrint.StringCaption = "Comprobante Diario";
            frmPrint.StringMessage = "Impresión del Informe Fiscal";
            DialogResult rta = frmPrint.ShowDialog();

            if (rta.Equals(DialogResult.No))
            {
                frmCaja.ShowDialog();
            }
            else
            {
                if (rta.Equals(DialogResult.Yes))
                {
                    frmCaja.LoadReport();
                    frmCaja.rptVCajaDiario_Print(null, null);
                }
            }
        }



        private void btnNotaContable_Click(object sender, EventArgs e)
        {
            /*BussinesLayer.Clases.BussinesFacturaVenta b =
                new BussinesLayer.Clases.BussinesFacturaVenta();
            Form1 frm = new Form1();
            frm.dataGridView1.DataSource = b.ListaIvaContado(1, dtpFecha.Value, true);
            frm.Show();*/


            // nota contable...
            var b = new BussinesLayer.Clases.BussinesFacturaVenta();
            Form1 frm = new Form1();
            frm.dataGridView1.DataSource = b.TotalFacturasCredito(2, 1, dtpFecha.Value, true).Tables[0];
            frm.Show();

            /*frmCaja = new FrmCajaDiario();
            frmCaja.Fecha = dtpFecha.Value;
            //frmCaja.ReportPath = @"C:\reports\NotaContable.rdlc";
            frmCaja.ReportPath = AppConfiguracion.ValorSeccion("report") + @"\reports\NotaContable.rdlc";
            frmCaja.ShowDialog();*/
        }

        

        private void btnVer_Click(object sender, EventArgs e)
        {
            //frmCaja.MdiParent = this.MdiParent;
            frmCaja.Fecha = dtpFecha.Value;
            frmCaja.Numeracion = true;
            //frmCaja.ReportPath = @"C:\reports\ComprobanteDiario.rdlc";
            frmCaja.ReportPath = AppConfiguracion.ValorSeccion("report") + @"\reports\ComprobanteDiario.rdlc";
            frmCaja.Soporte = true;
            frmCaja.ShowDialog();

            frmCaja = new FrmCajaDiario();
            frmCaja.Fecha = dtpFecha.Value;
            //frmCaja.ReportPath = @"C:\reports\NotaContable.rdlc";
            frmCaja.ReportPath = AppConfiguracion.ValorSeccion("report") + @"\reports\NotaContable.rdlc";
            frmCaja.ShowDialog();

            frmCaja = new FrmCajaDiario();
            frmCaja.Fecha = dtpFecha.Value;
            frmCaja.Numeracion = true;
            //frmCaja.ReportPath = @"C:\reports\Informe_Fiscal_Ventas.rdlc";
            frmCaja.ReportPath = AppConfiguracion.ValorSeccion("report") + @"\reports\Informe_Fiscal_Ventas.rdlc";
            frmCaja.ShowDialog();
            //this.Close();
        }

        private void FrmConsultaCajaFecha_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData.Equals(Keys.F5))
            {
                string rta = CustomControl.OptionPane.OptionBox
                    ("Ingresar contraseña de Administrador .", "Administrador", CustomControl.OptionPane.Icon.LoginAdmin);
                if (rta.Equals("1002-105-AJUST"))
                {
                    this.frmCaja = new FrmCajaDiario();
                    this.frmCaja.Soporte = true;
                    this.frmCaja.Numeracion = true;
                    this.frmCaja.General = false;
                    this.frmCaja.RetroActivo = false;
                    this.frmCaja.IdCaja = Convert.ToInt32(this.cbCajas.SelectedValue);
                    //this.frmCaja.AnexoInfo = true;

                    this.frmCaja.Fecha = this.dtpFecha.Value;
                    this.frmCaja.Fecha = new DateTime(this.frmCaja.Fecha.Year, this.frmCaja.Fecha.Month, 3);

                    int dia = 3;  // 3
                    while (dia != 93) // 32
                    {
                        this.frmCaja.Dia_ = dia;
                        this.frmCaja.PrintComprobantePos_2();
                        this.frmCaja.Fecha = this.frmCaja.Fecha.AddDays(1);
                        dia++;
                    }
                    //OptionPane.MessageInformation("Go");


                    //frmCaja.ReportPath = @"C:\reports\ComprobanteDiario_V2.rdlc";
                   // frmCaja.ReportPath = AppConfiguracion.ValorSeccion("report") + @"\reports\ComprobanteDiario_V2.rdlc";

                    /*if (!Convert.ToBoolean(AppConfiguracion.ValorSeccion("printCompDiario")))
                    {
                        FrmPrint frmPrint = new FrmPrint();
                        frmPrint.StringCaption = "Comprobante Diario";
                        frmPrint.StringMessage = "Impresión del Comprobante de Diario";
                        DialogResult rta = frmPrint.ShowDialog();

                        if (rta.Equals(DialogResult.No))
                        {
                            frmCaja.ShowDialog();
                        }
                        else
                        {
                            if (rta.Equals(DialogResult.Yes))
                            {
                                frmCaja.LoadReport();
                                frmCaja.rptVCajaDiario_Print(null, null);
                            }
                        }
                    }
                    else
                    {
                        frmCaja.PrintComprobantePos_2();
                    }*/
                }
            }

           /* if (e.KeyData.Equals(Keys.F3))
            {
                var frm = new Form1();
                var bussinesFactua = new BussinesLayer.Clases.BussinesFacturaVenta();
                frm.dataGridView1.DataSource = bussinesFactua.TotalAbonos(Convert.ToInt32(this.cbCajas.SelectedValue), this.dtpFecha.Value).Tables[0];
                frm.ShowDialog();
                //frm.dataGridView1.DataSource = 
            }*/
        }

        private void btnFiscalGeneralMes_Click(object sender, EventArgs e)
        {
            this.frmCaja = new FrmCajaDiario();
            this.frmCaja.PeriodoFecha = true;
            this.frmCaja.Soporte = false;
            this.frmCaja.Numeracion = false;
            this.frmCaja.General = true;
            this.frmCaja.RetroActivo = false;
            this.frmCaja.Fecha = dtpFecha.Value;

            this.frmCaja.Fecha = new DateTime(this.frmCaja.Fecha.Year, this.frmCaja.Fecha.Month, 1);
           //this.frmCaja.Fecha2 = this.frmCaja.Fecha.AddDays(2);
            this.frmCaja.Fecha2 = this.frmCaja.Fecha.AddMonths(1).AddDays(-1);
            this.frmCaja.ReportPath = AppConfiguracion.ValorSeccion("report") + @"\reports\Informe_Fiscal_Ventas_General_Periodo_ACT.rdlc";
            //frmCaja.ReportPath = @"C:\reports\Informe_Fiscal_Ventas_General_Periodo.rdlc";

            FrmPrint frmPrint = new FrmPrint();
            frmPrint.StringCaption = "Comprobante Diario";
            frmPrint.StringMessage = "Impresión del Informe Fiscal";
            DialogResult rta = frmPrint.ShowDialog();

            if (rta.Equals(DialogResult.No))
            {
                this.frmCaja.ShowDialog();
            }
            else
            {
                if (rta.Equals(DialogResult.Yes))
                {
                    this.frmCaja.LoadReport();
                    this.frmCaja.rptVCajaDiario_Print(null, null);
                }
            }
        }

        private void btnComprobanteMes_Click(object sender, EventArgs e)
        {
            frmCaja = new FrmCajaDiario();
            frmCaja.PeriodoFecha = true;
            frmCaja.Soporte = true;
            frmCaja.Numeracion = true;
            frmCaja.General = false;
            frmCaja.RetroActivo = false;

            frmCaja.Fecha = dtpFecha.Value;
            frmCaja.Fecha = new DateTime(this.frmCaja.Fecha.Year, this.frmCaja.Fecha.Month, 1);
            frmCaja.Fecha2 = this.frmCaja.Fecha.AddMonths(1).AddDays(-1);

            frmCaja.IdCaja = Convert.ToInt32(this.cbCajas.SelectedValue);
            //frmCaja.ReportPath = @"C:\reports\ComprobanteDiario_V2.rdlc";
            frmCaja.ReportPath = AppConfiguracion.ValorSeccion("report") + @"\reports\ComprobanteDiario_V2.rdlc";

            if (!Convert.ToBoolean(AppConfiguracion.ValorSeccion("printCompDiario")))
            {
                /*DialogResult rta = MessageBox.Show("¿Desea visualizar la impresión del comprobante diario?", "Comprobante Diario",
                    MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);*/
                FrmPrint frmPrint = new FrmPrint();
                frmPrint.StringCaption = "Comprobante Diario";
                frmPrint.StringMessage = "Impresión del Comprobante de Diario";
                DialogResult rta = frmPrint.ShowDialog();

                if (rta.Equals(DialogResult.No))
                {
                    frmCaja.ShowDialog();
                }
                else
                {
                    if (rta.Equals(DialogResult.Yes))
                    {
                        frmCaja.LoadReport();
                        frmCaja.rptVCajaDiario_Print(null, null);
                    }
                }
            }
            else
            {
                frmCaja.Print58mm();
            }
        } 
    }
}