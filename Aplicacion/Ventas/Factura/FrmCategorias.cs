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
using DTO.Clases;

namespace Aplicacion.Ventas.Factura
{
    public partial class FrmCategorias : Form
    {
        private BussinesCategoria miBussinesCategoria;

        public FrmCategorias()
        {
            InitializeComponent();
            this.miBussinesCategoria = new BussinesCategoria();
        }

        private void FrmCategorias_Load(object sender, EventArgs e)
        {
            try
            {
                this.dgvCategorias.AutoGenerateColumns = false;
                this.dgvCategorias.DataSource = this.miBussinesCategoria.ListadoCategoria();
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
        }

        private void dgvCategorias_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (this.dgvCategorias.IsCurrentCellDirty)
            {
                this.dgvCategorias.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            var lst = new List<Categoria>();
            foreach (DataGridViewRow chk in this.dgvCategorias.Rows)
            {
                if (chk.Cells["Seleccionar"].Value != null)
                {
                    var chek = (bool)chk.Cells["Seleccionar"].Value;
                    if (chek)
                    {
                        lst.Add(new DTO.Clases.Categoria
                        {
                            CodigoCategoria = chk.Cells["Codigo"].Value.ToString(),
                            NombreCategoria = chk.Cells["Categoria"].Value.ToString()
                        });
                       // OptionPane.MessageInformation(chk.Cells["Categoria"].Value.ToString());
                    }
                }
            }
            lst.Add(new DTO.Clases.Categoria { NombreCategoria = "DEMAS" });
            if (lst.Count > 3)
            {
                OptionPane.MessageInformation("Debe seleccionar solo dos categorías.");
            }
            else
            {
                CompletaEventos.CapturaEventom(lst);
                this.Close();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}