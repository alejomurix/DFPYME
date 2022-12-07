using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Aplicacion.Administracion.Caja
{
    public partial class FrmConsultaCierre : Form
    {
        public DataTable Cierres { set; get; }

        public FrmConsultaCierre()
        {
            InitializeComponent();
            Cierres = new DataTable();
        }

        private void FrmConsultaCierre_Load(object sender, EventArgs e)
        {
            try
            {
                dgvCierre.AutoGenerateColumns = false;
                dgvCierre.DataSource = Cierres;
                txtCierre.Text = Utilities.UseObject.InsertSeparatorMil(
                    Cierres.AsEnumerable().Sum(s => s.Field<int>("valor")).ToString());
            }
            catch (Exception ex)
            {
                CustomControl.OptionPane.MessageError(ex.Message);
            }
        }

        private void tsBtnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}