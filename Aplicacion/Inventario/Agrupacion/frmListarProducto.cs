using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DTO.Clases;
using Aplicacion.Compras.IngresarCompra;
using Utilities;
using BussinesLayer.Clases;
using CustomControl;

namespace Aplicacion.Inventario.Agrupacion
{
    public partial class frmListarProducto : Form
    {
        /// <summary>
        /// Atributos de modelo de negocios.
        /// </summary>
        private BussinesInventario miInventario;

        public frmListarProducto()
        {
            InitializeComponent();
            miInventario = new BussinesInventario();
        }

        private void frmListarProducto_Load(object sender, EventArgs e)
        {
            
        }

        private void frmListarProducto_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.F12)
            {
                tsAceptar_Click(null, null);
            }
            else
            {
                if (e.KeyData == Keys.Escape)
                {
                    this.Close();
                }
            }
        }

        private void frmListarProducto_FormClosing(object sender, FormClosingEventArgs e)
        {
            CompletaEventos.CapturaEvento(false);
        }

        private void tsAceptar_Click(object sender, EventArgs e)
        {
            dgvListaArticulo_CellDoubleClick(null, null);
        }

        private void tsAgregar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void dgvListaArticulo_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvListaArticulo.RowCount != 0)
            {
                var tallaYColor = new TallaYcolor();
                DataGridViewRow row =
                    this.dgvListaArticulo.Rows[this.dgvListaArticulo.CurrentCell.RowIndex];
                tallaYColor.IdColor = Convert.ToInt32(row.Cells["IdColor"].Value);
                tallaYColor.Color = (Image)row.Cells["Color"].Value;
                tallaYColor.IdTalla = Convert.ToInt32(row.Cells["IdValorMedida"].Value);
                tallaYColor.Talla = Convert.ToString(row.Cells["ValorMedida"].Value);
                CompletaEventos.CapturaEvento(tallaYColor);
                this.Close();
            }
        }

        /// <summary>
        /// Carga el gid con los artículos que haya seleccionado en el formulario.
        /// </summary>
        /// <param name="codigo">codigo a consultar</param>
        public void CargarProducto(string codigo)
        {
            try
            {
                dgvListaArticulo.AutoGenerateColumns = false;
                dgvListaArticulo.DataSource = miInventario.ListarCantidadInventario(codigo);
            }
            catch(Exception ex)
            {
                OptionPane.MessageInformation(ex.Message);
            }
        }

    }
}