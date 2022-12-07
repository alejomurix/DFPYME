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

namespace Aplicacion.Inventario.Kardex
{
    public partial class FrmResumenKardex : Form
    {
        public bool Periodo { set; get; }

        public DateTime Fecha { set; get; }

        public DateTime Fecha2 { set; get; }

        public string Codigo { set; get; }

        private BussinesKardex miBussinesKardex;

        public FrmResumenKardex()
        {
            InitializeComponent();
            this.Periodo = false;
            miBussinesKardex = new BussinesKardex();
        }

        private void FrmResumenKardex_Load(object sender, EventArgs e)
        {
            try
            {
                dgvKardexEntrada.AutoGenerateColumns = false;
                dgvKardexSalida.AutoGenerateColumns = false;
                if (Periodo)
                {
                    dgvKardexEntrada.DataSource = miBussinesKardex.Resumen(1, Fecha, Fecha2, Codigo);
                    dgvKardexSalida.DataSource = miBussinesKardex.Resumen(2, Fecha, Fecha2, Codigo);
                }
                else
                {
                    dgvKardexEntrada.DataSource = miBussinesKardex.Resumen(1, Fecha, Codigo);
                    dgvKardexSalida.DataSource = miBussinesKardex.Resumen(2, Fecha, Codigo);
                }
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
        }
    }
}