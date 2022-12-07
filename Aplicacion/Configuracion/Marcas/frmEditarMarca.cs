using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Aplicacion.Configuracion.Marcas;
using Aplicacion.Clases;
using BussinesLayer.Clases;
using DTO.Clases;
using Utilities;

namespace Aplicacion.Configuracion.Marcas
{
    public partial class frmEditarMarca : Form
    {
        public frmEditarMarca()
        {
            InitializeComponent();
        }

        private void EditarMarca_Load(object sender, EventArgs e)
        {
            CompletaEventos.Completaem += new CompletaEventos.CompletaAccionem(CompletaEventosem_Completo);
        }

        void CompletaEventosem_Completo(CompletaArgumentosDeEventoem args)
        {
            TransferirMarcaem em = (TransferirMarcaem)args.MiMarcaed;
            txtIdEditarMarca.Text = Convert.ToString(em.IdMarca);
            txtEditarMarca.Text = em.NombreMarca;
        }

        

        private void tsbSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tsbGuardarCambios_Click(object sender, EventArgs e)
        {
            BussinesMarca editamarca = new BussinesMarca();
            DTO.Clases.Marca m2 = new Marca();
            m2.IdMarca = Convert.ToInt32(txtIdEditarMarca.Text);
            m2.NombreMarca = txtEditarMarca.Text;
            editamarca.EditarMarca(m2);
            MessageBox.Show("La edicion se ha realizado correctamente");

        }

        private void tsbCancelarEditarMarca_Click(object sender, EventArgs e)
        {
            txtEditarMarca.Clear();
            txtIdEditarMarca.Clear();
        }
   
   }
}

