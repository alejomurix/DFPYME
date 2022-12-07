using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BussinesLayer.Clases;
using CustomControl;

namespace Aplicacion.Ventas.Factura
{
    public partial class FrmUtilidad : Form
    {
        private BussinesFacturaVenta miBussinesFactura;

        private OptionPane miOption;

        private bool Success;

        private DataTable Tabla;

        private System.Threading.Thread miThread;

        public FrmUtilidad()
        {
            InitializeComponent();
            Success = false;
            Tabla = new DataTable();
            this.miBussinesFactura = new BussinesFacturaVenta();
        }

        private void FrmUtilidad_Load(object sender, EventArgs e)
        {

        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                miOption = new OptionPane();
                miOption.FrmProgressBar.barraProgreso.Style = ProgressBarStyle.Marquee;
                miOption.FrmProgressBar.Closed_ = true;
                miOption.ProgressShow("Espere mientras se realizan las operaciones necesarias...",
                    "Operacion en progreso");
                this.Enabled = false;
                miThread = new System.Threading.Thread(Iniciar);
                miThread.Start();
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
        }

        private void Iniciar()
        {
            try
            {
                Tabla = miBussinesFactura.ResumenDeUtilidad(this.dtpFecha1.Value, this.dtpFecha2.Value);
                Success = true;
                if (this.InvokeRequired)
                    this.Invoke(new Action(Finalizar));
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
                Success = false;
                if (this.InvokeRequired)
                    this.Invoke(new Action(Finalizar));
            }
        }

        private void Finalizar()
        {
            miOption.FrmProgressBar.barraProgreso.Style = ProgressBarStyle.Blocks;
            miOption.FrmProgressBar.Closed_ = false;
            miOption.FrmProgressBar.Close();
            this.Enabled = true;
            if (Success)
            {
                this.dgvUtilidad.DataSource = Tabla;
            }
        }
    }
}