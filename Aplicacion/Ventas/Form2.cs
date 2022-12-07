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
    public partial class Form2 : Form
    {
        BussinesIva miBussinesIva;

        BussinesFacturaVenta miBussines;

        public Form2()
        {
            InitializeComponent();
            miBussinesIva = new BussinesIva();
            miBussines = new BussinesFacturaVenta();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            try
            {
                cbIvaEditar.DataSource = miBussinesIva.ListadoIva();
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                //Convert.ToInt32(cbIvaEditar.SelectedValue))
                //miBussines.AjusteVentaIva(Convert.ToInt32(cbIvaEditar.SelectedValue));

                BussinesConsultaSQL consulta = new BussinesConsultaSQL();
                consulta.ProductAjust();
                OptionPane.MessageInformation("El ajuste se relizó con éxito.");
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
        }
    }
}