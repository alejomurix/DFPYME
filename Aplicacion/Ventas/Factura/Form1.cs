using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DTO.Clases;

namespace Aplicacion.Ventas.Factura
{
    public partial class Form1 : Form
    {
        public List<ProductoFacturaProveedor> products;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = products;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Ventas.Factura.FrmFacturaPos ventaPOS = new Ventas.Factura.FrmFacturaPos();
            ventaPOS.Usuario_ = new DTO.Clases.Usuario { Id = 6 };
            ventaPOS.FacturaPos = true;
            ventaPOS.CargaCliente = true;

            ventaPOS.idFactura = Convert.ToInt32(textBox1.Text);
            ventaPOS.LoadProducts();
            ventaPOS.SegmentaProducts(100000);

            List<ProductoFacturaProveedor> products = new List<ProductoFacturaProveedor>();
            int num = 0;

            foreach(var fact in ventaPOS.facturas)
            {
                num++;
                foreach(var prod in fact.Productos)
                {
                    prod.NumeroFactura = num.ToString();
                    products.Add(prod);
                }
            }

            dataGridView1.DataSource = products;
        }
    }
}
