using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CustomControl;
using BussinesLayer.Clases;

namespace Aplicacion.Ventas
{
    public partial class Form1 : Form
    {
        BussinesFacturaVenta miBussines;

        public Form1()
        {
            InitializeComponent();
            //miBussines = new BussinesFacturaVenta();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                //this.dataGridView1.DataSource = miBussines.PagosDeFactura(Convert.ToInt32(textBox1.Text), dateTimePicker1.Value, dateTimePicker2.Value);
                //this.dataGridView1.DataSource = miBussines.Clientes();
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);   
            }
        }
    }
}
