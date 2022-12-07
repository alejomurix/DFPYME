using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using Aplicacion.Compras.Proveedor;
using Utilities;

namespace Aplicacion.Compras.IngresarCompra
{
    public partial class IngresarCompras : Form
    {
        ArrayList l = new ArrayList();
        List<FormaPago> lista = new List<FormaPago>();

        private frmProveedor formProveedor;

        private CompraProveedor miCompraProveedor;

        public IngresarCompras()
        {
            InitializeComponent();
        }

        void CompletaEventos_Completo( CompletaArgumentosDeEvento args ) 
        {
            miCompraProveedor = (CompraProveedor)args.MiObjeto;
            txtCodigoProveedor.Text = Convert.ToString( miCompraProveedor.CodigoProveedor );
            txtNombreProveedor.Text = miCompraProveedor.NombreProveedor;
        }

        private void IngresarCompras_Load(object sender, EventArgs e)
        {
            CompletaEventos.Completa += 
                new CompletaEventos.CompletaAccion( CompletaEventos_Completo );
            //cbFormaPago.DisplayMember = "Descripcion";
            //this.panelIngresarCompra.Enabled = false;
            //this.pDatos.Visible = false;
            
            /*l.Add(new Compra { Codigo = "11111111111111111",
                               Producto = "Leche en polvo el rodeo",
                               Valor = "20.000"
                             }
                );
            l.Add(new Compra
            {
                Codigo = "2222222222222222222",
                Producto = "añjfasfjslñfjaslfjssffsffsdfs",
                Valor = "2"
            });
            //dgvDatosCompras.CellBorderStyle = DataGridViewCellBorderStyle.Single;
            dgvDatosCompras.DataSource = l;
            //dataGridView1.DataSource = l;*/

            cbFormaPago.DataSource = Listado();
            
        }

        public List<FormaPago> Listado()
        {
            return new List<FormaPago>
            {
                new FormaPago{ Id = 1, Descripcion = "Contado" },
                new FormaPago{ Id = 2, Descripcion = "Credito" }
            };
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            //MessageBox.Show("Es el Boton");
            MessageBox.Show(cbFormaPago.SelectedValue.ToString());
        }

        private void txtCantidad_Leave(object sender, EventArgs e)
        {
            //MessageBox.Show("Correcto");
        }

        private void txtCantidad_KeyPress(object sender, KeyPressEventArgs e)
        {
            MessageBox.Show("este es...");
        }

        

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            this.panelIngresarCompra.Enabled = false;
        }

        private void lkbGenerarLote_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MessageBox.Show("jjjjjjjjjj");
        }

        private void btnBuscarProveedor_Click(object sender, EventArgs e)
        {
            formProveedor = new frmProveedor();
            formProveedor.Extension = true;
            formProveedor.Show();
        }
    }

    public class Compra
    {
        public string Codigo { set; get; }
        public string Producto { set; get; }
        public string Valor { set; get; }
    }

    public class FormaPago
    {
        public int Id { set; get; }
        public string Descripcion { set; get; }
    }
}