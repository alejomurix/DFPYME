using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BussinesLayer.Clases;
using Utilities;
using CustomControl;

namespace Aplicacion.Compras.IngresarCompra
{
    public partial class FrmConsultaCompras : Form
    {

        private BussinesFacturaProveedor miBussinesFactura;

        public FrmConsultaCompras()
        {
            InitializeComponent();
            miBussinesFactura = new BussinesFacturaProveedor();
        }

        private void FrmConsultaCompras_Load(object sender, EventArgs e)
        {

        }

        private void FrmConsultaCompras_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData.Equals(Keys.Escape))
            {
                this.Close();
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                var compras = miBussinesFactura.ComprasAproveedor(dtpFecha1.Value, dtpFecha2.Value);
                dgvCompras.DataSource = compras;
                if (dgvCompras.RowCount != 0)
                {
                    txtTotal.Text = UseObject.InsertSeparatorMil
                        (compras.AsEnumerable().Sum(s => s.Field<double>("Cant")).ToString());
                }
                else
                {
                    txtTotal.Text = "0";
                }
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
        }
    }
}