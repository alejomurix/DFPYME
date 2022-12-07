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
    public partial class FrmConsultaCajaFecha : Form
    {
        private BussinesLayer.Clases.BussinesCaja miBussinesCaja;

        private BussinesLayer.Clases.BussinesFacturaVenta miBussinesFactura;

        private Administracion.CajaDiario.FrmCajaDiario frmCaja;

        private DialogResult Rta { set; get; }

        private DateTime Fecha;

        private int IdCaja;

        List<DTO.Clases.Impuesto> Impuestos;

        int IdQuery;

        private System.Threading.Thread thread;

        public FrmConsultaCajaFecha()
        {
            InitializeComponent();
            this.miBussinesCaja = new BussinesLayer.Clases.BussinesCaja();
            this.miBussinesFactura = new BussinesLayer.Clases.BussinesFacturaVenta();
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
                frmCaja.PrintComprobantePos_2();
            }
        }

        private void btnFiscal_Click(object sender, EventArgs e)
        {
            this.Fecha = this.dtpFecha.Value;
            this.IdCaja = Convert.ToInt32(this.cbCajas.SelectedValue);
            this.IdQuery = 1;

            gbCaja.Enabled = false;
            gbGeneral.Enabled = false;
            gbPeriodo.Enabled = false;

            thread = new System.Threading.Thread(LoadData);
            thread.Start();

            /**
            frmCaja = new FrmCajaDiario();
            frmCaja.Soporte = false;
            frmCaja.Numeracion = true;
            frmCaja.General = false;
            frmCaja.RetroActivo = false;
            frmCaja.Fecha = this.Fecha;
            frmCaja.IdCaja = this.IdCaja;
            frmCaja.Impuestos = this.Impuestos;

            frmCaja.ReportPath = AppConfiguracion.ValorSeccion("report") + @"\reports\Informe_Fiscal_Ventas_V2_ACT.rdlc";
            frmCaja.ReportPath = @"C:\reports\Informe_Fiscal_Ventas_V2_ACT.rdlc";
            */
            

            //frmCaja.ReportPath = @"C:\reports\Informe_Fiscal_Ventas_V2_ACT.rdlc";

           /* frmCaja.ReportPath = @"
C:\Users\alejoQ2009\Documents\Visual Studio 2010\Projects\Edicion\DFPYME\Aplicacion\Informes\Informe_Fiscal_Ventas_V2.rdlc";*/
           /* DialogResult rta = MessageBox.Show("¿Desea visualizar la impresión del Informe Fiscal?", "Comprobante Diario",
                    MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);*/
            

            

            /**
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
            */
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
            this.Fecha = this.dtpFecha.Value;
            this.IdCaja = Convert.ToInt32(this.cbCajas.SelectedValue);
            this.IdQuery = 2;

            gbCaja.Enabled = false;
            gbGeneral.Enabled = false;
            gbPeriodo.Enabled = false;

            thread = new System.Threading.Thread(LoadData);
            thread.Start();


            /**
            frmCaja = new FrmCajaDiario();
            frmCaja.Soporte = false;
            frmCaja.Numeracion = true;
            frmCaja.General = true;
            frmCaja.RetroActivo = false;
            frmCaja.Fecha = dtpFecha.Value;
            //frmCaja.ReportPath = AppConfiguracion.ValorSeccion("report") + @"\reports\Informe_Fiscal_Ventas_General.rdlc";
            frmCaja.ReportPath = AppConfiguracion.ValorSeccion("report") + @"\reports\Informe_Fiscal_Ventas_General_ACT.rdlc";*/
            ///frmCaja.ReportPath = @"C:\reports\Informe_Fiscal_Ventas_General_ACT.rdlc";

            //frmCaja.ReportPath = @"
//C:\Users\alejo_cq\Documents\Visual Studio 2010\Projects\DFPYME\Aplicacion\Informes\Informe_Fiscal_Ventas_General.rdlc";

            /*DialogResult rta = MessageBox.Show("¿Desea visualizar la impresión del Informe Fiscal?", "Comprobante Diario",
                    MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);*/
            
            /**FrmPrint frmPrint = new FrmPrint();
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
            }*/
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

            //this.frmCaja.Fecha2 = this.frmCaja.Fecha.AddDays(7);
            this.frmCaja.Fecha2 = this.frmCaja.Fecha.AddMonths(1).AddDays(-1);

            frmCaja.FechaParameter = "Periodo: " + frmCaja.Fecha.ToShortDateString() + " a " + frmCaja.Fecha2.ToShortDateString();

            //this.frmCaja.ReportPath = AppConfiguracion.ValorSeccion("report") + @"\reports\Informe_Fiscal_Ventas_General_Periodo.rdlc";

            ///frmCaja.ReportPath = AppConfiguracion.ValorSeccion("report") + @"\reports\Informe_Fiscal_Ventas_General_Periodo_ACT.rdlc";

            frmCaja.ReportPath = AppConfiguracion.ValorSeccion("report") + @"\reports\Informe_Fiscal_Ventas_new_2022.rdlc"; // new nov. 2022
            //frmCaja.ReportPath = @"C:\reports\Informe_Fiscal_Ventas_new_2022.rdlc";


            ///frmCaja.ReportPath = @"C:\reports\Informe_Fiscal_Ventas_General_Periodo_ACT.rdlc";
            //frmCaja.ReportPath = @"C:\reports\Informe_Fiscal_Ventas_General_Periodo_ACT.rdlc";

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

        private void LoadData()
        {
            try
            {
                /*frmCaja = new FrmCajaDiario();
                frmCaja.Soporte = false;
                frmCaja.Numeracion = true;
                frmCaja.General = false;
                frmCaja.RetroActivo = false;
                frmCaja.Fecha = this.Fecha;
                frmCaja.IdCaja = this.IdCaja;
                frmCaja.ReportPath = AppConfiguracion.ValorSeccion("report") + @"\reports\Informe_Fiscal_Ventas_V2_ACT.rdlc";
                frmCaja.ReportPath = @"C:\reports\Informe_Fiscal_Ventas_V2_ACT.rdlc";*/

                //this.frmCaja.LoadData();
                if (this.IdQuery.Equals(1))
                {
                    //Impuestos = miBussinesFactura.TotalesImpuesto(IdCaja, Fecha);
                    Impuestos = miBussinesFactura.TotalesImpuesto(IdCaja, Fecha, Fecha);
                }
                else
                {
                    if (this.IdQuery.Equals(2))
                    {
                        //Impuestos = miBussinesFactura.TotalesImpuesto(Fecha);
                        Impuestos = miBussinesFactura.TotalesImpuesto(0, Fecha, Fecha);
                    }
                }

                //this.Impuestos = miBussinesFactura.TotalesImpuesto(IdCaja, Fecha);
                
                if (this.InvokeRequired)
                {
                    this.Invoke(new Action(EndLoad));
                }
            }
            catch (Exception ex)
            {
                if (this.InvokeRequired)
                {
                    this.Invoke(new Action(EndLoad));
                }
                OptionPane.MessageError(ex.Message);
            }
        }

        private void EndLoad()
        {
            frmCaja = new FrmCajaDiario();
            frmCaja.Fecha = this.Fecha;
            frmCaja.FechaParameter = "Fecha: " + this.Fecha.ToShortDateString();

            if (this.IdQuery.Equals(1))
            {
                //
                frmCaja.Soporte = false;
                frmCaja.Numeracion = true;
                frmCaja.General = false;
                frmCaja.RetroActivo = false;
                //frmCaja.Fecha = this.Fecha;
                frmCaja.IdCaja = this.IdCaja;
                frmCaja.Impuestos = this.Impuestos;

                ///frmCaja.ReportPath = AppConfiguracion.ValorSeccion("report") + @"\reports\Informe_Fiscal_Ventas_V2_ACT.rdlc";
                //frmCaja.ReportPath = @"C:\reports\Informe_Fiscal_Ventas_V2_ACT.rdlc";

                frmCaja.ReportPath = AppConfiguracion.ValorSeccion("report") + @"\reports\Informe_Fiscal_Ventas_new_2022.rdlc"; // new nov. 2022
                //frmCaja.ReportPath = @"C:\reports\Informe_Fiscal_Ventas_new_2022.rdlc"; // new nov. 2022

                /*FrmPrint frmPrint = new FrmPrint();
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
                }*/
                
            }
            else
            {
                if (this.IdQuery.Equals(2))
                {
                    //frmCaja = new FrmCajaDiario();
                    frmCaja.Soporte = false;
                    frmCaja.Numeracion = true;
                    frmCaja.General = true;
                    frmCaja.RetroActivo = false;
                    //frmCaja.Fecha = this.Fecha;
                    frmCaja.Impuestos = this.Impuestos;

                    ///frmCaja.ReportPath = AppConfiguracion.ValorSeccion("report") + @"\reports\Informe_Fiscal_Ventas_General_ACT.rdlc";
                    //frmCaja.ReportPath = @"C:\reports\Informe_Fiscal_Ventas_General_ACT.rdlc";


                    frmCaja.ReportPath = AppConfiguracion.ValorSeccion("report") + @"\reports\Informe_Fiscal_Ventas_new_2022.rdlc"; // new nov. 2022
                    //frmCaja.ReportPath = @"C:\reports\Informe_Fiscal_Ventas_new_2022.rdlc"; // new nov. 2022
                }
            }
            frmCaja.ShowDialog();

            gbCaja.Enabled = true;
            gbGeneral.Enabled = true;
            gbPeriodo.Enabled = true;

            //this.thread.Suspend();



            /*gbCaja.Enabled = true;
            gbGeneral.Enabled = true;
            gbPeriodo.Enabled = true;*/

            //frmCaja.ShowDialog();

           /* FrmPrint frmPrint = new FrmPrint();
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
            }*/
        }
    }
}