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
using BussinesLayer.Clases;

namespace Aplicacion.Compras.IngresarCompra
{
    public partial class FrmEditarCompraSimple : Form
    {
        public int CodigoProveedor { set; get; }

        private BussinesProveedor miBussinesProveedor;

        public FrmEditarCompraSimple()
        {
            InitializeComponent();


            this.miBussinesProveedor = new BussinesProveedor();
        }

        private void FrmEditarCompraSimple_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData.Equals(Keys.Escape))
            {
                this.Close();
            }
        }

        private void tsGuardar_Click(object sender, EventArgs e)
        {

        }

        private void tsSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtCodigo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar.Equals((char)Keys.Enter))
            {
                try
                {
                    if (this.miBussinesProveedor.ExisteProveedorConNit(this.txtCodigo.Text))
                    {
                        var proveedor = this.miBussinesProveedor.ConsultarPrveedorBasico(this.txtCodigo.Text);
                        this.txtNombreProveedor.Text = proveedor.CodigoInternoProveedor + " - NIT: " + proveedor.NitProveedor
                            + " - " + proveedor.RazonSocialProveedor;
                        this.CodigoProveedor = proveedor.CodigoInternoProveedor;
                        this.txtCodigo.Text = "";
                    }
                    else
                    {
                        OptionPane.MessageInformation("El proveedor no existe.");
                    }
                }
                catch (Exception ex)
                {
                    OptionPane.MessageError(ex.Message);
                }
            }
        }

        private void btnBuscarCodigo_Click(object sender, EventArgs e)
        {

        }
    }
}