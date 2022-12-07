using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DataAccessLayer.Repository;
using DataAccessLayer.Models;
using CustomControl;
using DTO;
using Utilities;
using BussinesLayer.Clases;


namespace FormulariosSistema
{
    public partial class FrmProductList : Form
    {
        private BussinesProducto bProduct;

        public FrmProductList()
        {
            InitializeComponent();
            this.dgvListItems.AutoGenerateColumns = false;

            try
            {
                this.bProduct = new BussinesProducto();
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
        }

        private void FrmProductList_Load(object sender, EventArgs e)
        {

        }

        private void FrmProductList_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void txtSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                this.btnSearch_Click(this.btnSearch, new EventArgs());
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                //dgvInventario.DataSource = miBussinesProducto.Productos(txtCodigoNombre.Text.Split(' '));
                this.dgvListItems.DataSource = this.bProduct.Productos(this.txtSearch.Text.Split(' '));
                ColorearGrid();
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
        }

        private void chkVerId_CheckedChanged(object sender, EventArgs e)
        {

        }

        public void ColorearGrid()
        {
            var cont = 0;
            foreach (DataGridViewRow row in this.dgvListItems.Rows)
            {
                cont++;
                if (cont % 2 != 0)
                {
                    row.DefaultCellStyle.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
                }
            }
        }
        
    }
}