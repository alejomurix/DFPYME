using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BussinesLayer.Clases;
using CustomControl;
using Utilities;

namespace Aplicacion.Administracion.Usuario
{
    public partial class FrmUsuarios : Form
    {
        private BussinesUsuario miBussinesUsuario;

        public FrmUsuarios()
        {
            InitializeComponent();

            this.miBussinesUsuario = new BussinesUsuario();
        }

        private void FrmUsuarios_Load(object sender, EventArgs e)
        {
            try
            {
                this.dgvUsuarios.AutoGenerateColumns = false;
                this.dgvUsuarios.DataSource = this.miBussinesUsuario.Usuarios();
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
        }

        private void FrmUsuarios_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData.Equals(Keys.F12))
            {
                this.dgvUsuarios_CellContentDoubleClick(this.dgvUsuarios, null);
            }
            else
            {
                if (e.KeyData.Equals(Keys.Escape))
                {
                    this.Close();
                }
            }
        }

        private void dgvUsuarios_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (this.dgvUsuarios.RowCount > 0)
            {
                DataGridViewRow gRow = this.dgvUsuarios.CurrentRow;
                CompletaEventos.CapturaEvento(new ObjectAbstract
                {
                    Id = 822114433,
                    Objeto = new DTO.Clases.Usuario
                    {
                        Id = Convert.ToInt32(gRow.Cells["IdUsuario"].Value),
                        Nombres = gRow.Cells["NameUsuario"].Value.ToString()
                    }
                });
                this.Close();
            }
        }
    }
}