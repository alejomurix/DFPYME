using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DTO.Clases;
using BussinesLayer.Clases;
using CustomControl;
using Utilities;
using System.Threading;

namespace Aplicacion.Ventas.Remisiones
{
    public partial class FrmResumenRemision : Form
    {
        private BussinesRemision miBussinesRemision;

        private DateTime FechaActual;

        private DateTime FechaActual2;

        private Thread miThread;

        private OptionPane miOption;

        private DataTable TivaVenta;

        private DataTable TivaCompra;

        private List<Impuesto> Devoluciones;

        private double TotalCosto;

        public FrmResumenRemision()
        {   
            InitializeComponent();
            miBussinesRemision = new BussinesRemision();
            this.dgvIvaVenta.AutoGenerateColumns = false;
            this.dgvDevoluciones.AutoGenerateColumns = false;
            this.dgvIvaCompras.AutoGenerateColumns = false;
        }

        private void FrmResumenRemision_Load(object sender, EventArgs e)
        {        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                FechaActual = dtpFecha1.Value;
                FechaActual2 = dtpFecha2.Value;

                this.miOption = new OptionPane();
                this.miOption.FrmProgressBar.barraProgreso.Style = ProgressBarStyle.Marquee;
                this.miOption.FrmProgressBar.Closed_ = true;
                this.miOption.ProgressShow("Espere mientras se realizan las operaciones necesarias...",
                    "Operacion en progreso");
                this.Enabled = false;
                this.miThread = new Thread(Cargar);
                this.miThread.Start();
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
        }

        private void Cargar()
        {
            try
            {
                TivaVenta = miBussinesRemision.ResumenIvaVentas(FechaActual, FechaActual2);
                TivaCompra = miBussinesRemision.ResumenIvaCompras(FechaActual, FechaActual2);
                TotalCosto = TivaVenta.AsEnumerable().Sum(s => (s.Field<double>("costo") / (1 + (s.Field<double>("iva") / 100))));
                Devoluciones = miBussinesRemision.ResumenDevolucion(FechaActual, FechaActual2);
                ///TotalCosto = miBussinesRemision.TotalCostoVenta(FechaActual, FechaActual2);
                
                if (this.InvokeRequired)
                {
                    this.Invoke(new Action(Finalizar));
                }
            }
            catch (Exception ex)
            {
                if (this.InvokeRequired)
                {
                    this.Invoke(new Action(Finalizar));
                }
                OptionPane.MessageError(ex.Message);
            }
        }

        private void Finalizar()
        {
            try
            {
                dgvIvaVenta.DataSource = TivaVenta;
                dgvIvaCompras.DataSource = TivaCompra;
                txtVentas.Text = UseObject.InsertSeparatorMil(TivaVenta.AsEnumerable().Sum(s => s.Field<double>("base")).ToString());
                dgvDevoluciones.DataSource = Devoluciones;
                txtCosto.Text = UseObject.InsertSeparatorMil(Math.Round(TotalCosto, 0).ToString());
                txtDiferencia.Text = UseObject.InsertSeparatorMil((
                    UseObject.RemoveSeparatorMil(txtVentas.Text) - UseObject.RemoveSeparatorMil(txtCosto.Text)).ToString());

                miOption.FrmProgressBar.barraProgreso.Style = ProgressBarStyle.Blocks;
                miOption.FrmProgressBar.Closed_ = false;
                miOption.FrmProgressBar.Close();
                this.Enabled = true;
                OptionPane.MessageInformation("La operación se realizó con éxito.");
            }
            catch (Exception ex)
            {
                miOption.FrmProgressBar.barraProgreso.Style = ProgressBarStyle.Blocks;
                miOption.FrmProgressBar.Closed_ = false;
                miOption.FrmProgressBar.Close();
                this.Enabled = true;
                OptionPane.MessageError(ex.Message);
            }
        }
    }
}