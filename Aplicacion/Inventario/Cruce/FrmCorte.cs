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
using Utilities;

namespace Aplicacion.Inventario.Cruce
{
    public partial class FrmCorte : Form
    {
        private BussinesInventario miBussinesInventario;

        public FrmCorte()
        {
            InitializeComponent();
            miBussinesInventario = new BussinesInventario();
        }

        private void FrmCorte_Load(object sender, EventArgs e)
        {
            try
            {
                dgvCorte.AutoGenerateColumns = false;
                dgvCorte.DataSource = miBussinesInventario.TablaCorte();
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
        }

        private void FrmCorte_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData.Equals(Keys.F12))
            {
                if (dgvCorte.Rows.Count > 0)
                {
                    /*CompletaEventos.CapturaEvento(Convert.ToDateTime(dgvCorte.CurrentRow.Cells["Fecha"].Value));
                    this.Close();*/
                    CompletaEventos.CapturaEvento(
                    new DTO.Clases.Corte
                    {
                        Numero = Convert.ToInt32(dgvCorte.CurrentRow.Cells["Numero"].Value),
                        Fecha = Convert.ToDateTime(dgvCorte.CurrentRow.Cells["Fecha"].Value)
                    });
                    //Convert.ToDateTime(dgvCorte.CurrentRow.Cells["Fecha"].Value));
                    this.Close();
                }
            }
            else
            {
                if (e.KeyData.Equals(Keys.Escape))
                {
                    this.Close();
                }
            }
        }

        private void dgvCorte_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvCorte.Rows.Count > 0)
            {
                CompletaEventos.CapturaEvento(
                    new DTO.Clases.Corte
                    {
                        Numero = Convert.ToInt32(dgvCorte.CurrentRow.Cells["Numero"].Value),
                        Fecha = Convert.ToDateTime(dgvCorte.CurrentRow.Cells["Fecha"].Value)
                    });
                    //Convert.ToDateTime(dgvCorte.CurrentRow.Cells["Fecha"].Value));
                this.Close();
            }
        }
    }
}