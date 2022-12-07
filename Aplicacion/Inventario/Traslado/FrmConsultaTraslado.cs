using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DTO.Clases;

namespace Aplicacion.Inventario.Traslado
{
    public partial class FrmConsultaTraslado : Form
    {
        public FrmConsultaTraslado()
        {
            InitializeComponent();
        }

        private void FrmConsultaTraslado_Load(object sender, EventArgs e)
        {
            var lista = new List<Criterio>();
            lista.Add(new Criterio { Id = 1, Nombre = "TODOS" });
            lista.Add(new Criterio { Id = 2, Nombre = "FECHA" });
            lista.Add(new Criterio { Id = 3, Nombre = "PERIODO" });
            cbCriterio.DataSource = lista;
        }
    }
}