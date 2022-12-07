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

namespace Aplicacion.Administracion.Retencion
{
    public partial class FrmRetencion : Form
    {
        private ToolTip miToolTip;

        private BussinesRegimen miBussinesRegimen;

        private BussinesRetencion miBussinesRetencion;

        public FrmRetencion()
        {
            InitializeComponent();
            miToolTip = new ToolTip();
            miBussinesRegimen = new BussinesRegimen();
            miBussinesRetencion = new BussinesRetencion();
            CompletaEventos.Completaz += new CompletaEventos.CompletaAccionz(CompletaEventos_Completaz);
        }

        private void FrmRetencion_Load(object sender, EventArgs e)
        {
            //miToolTip.SetToolTip(btnAgregarRubro, "");
            dgvReteConcepto.AutoGenerateColumns = false;
            CargarDatos();
        }

        private void dgvRubro_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvRubro.RowCount != 0)
            {
                dgvReteConcepto.DataSource = miBussinesRetencion.Conceptos
                    (Convert.ToInt32(dgvRubro.CurrentRow.Cells["IdRubro"].Value));
            }
        }

        private void btnAgregarRubro_Click(object sender, EventArgs e)
        {
            var frmNuevoRubro = new FrmNuevoRubro();
            frmNuevoRubro.ShowDialog();
        }

        private void btnEditarRubro_Click(object sender, EventArgs e)
        {
            if (dgvRubro.RowCount != 0)
            {
                var frmEditarRubro = new FrmEditarRubro();
                frmEditarRubro.IdRubro = Convert.ToInt32(dgvRubro.CurrentRow.Cells["IdRubro"].Value);
                frmEditarRubro.txtRubro.Text = dgvRubro.CurrentRow.Cells["NombreRubro"].Value.ToString();
                frmEditarRubro.ShowDialog();
            }
            else
            {
                OptionPane.MessageInformation("No hay registros para editar.");
            }
        }

        private void btnEliminarRubro_Click(object sender, EventArgs e)
        {
            if (dgvRubro.RowCount != 0)
            {
                try
                {
                    DialogResult rta = MessageBox.Show("¿Esta seguro(a) de eliminar el registro?", "Retenciones",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (rta.Equals(DialogResult.Yes))
                    {
                        var c = miBussinesRetencion.Conceptos(
                            Convert.ToInt32(dgvRubro.CurrentRow.Cells["IdRubro"].Value));
                        if (c.Rows.Count != 0)
                        {
                            OptionPane.MessageInformation("El Rubro no se puede eliminar porque tiene registros asociados.");
                        }
                        else
                        {
                            miBussinesRetencion.EliminarRubro(
                               Convert.ToInt32(dgvRubro.CurrentRow.Cells["IdRubro"].Value));
                            CargarDatos();
                        }
                    }
                }
                catch (Exception ex)
                {
                    OptionPane.MessageError(ex.Message);
                }
            }
            else
            {
                OptionPane.MessageInformation("No hay registros para eliminar.");
            }
        }

        private void btnAgregarConcepto_Click(object sender, EventArgs e)
        {
            if (dgvRubro.RowCount != 0)
            {
                var frmNuevoConcepto = new FrmNuevoConcepto();
                frmNuevoConcepto.IdRubro = Convert.ToInt32(dgvRubro.CurrentRow.Cells["IdRubro"].Value);
                frmNuevoConcepto.ShowDialog();
            }
            else
            {
                OptionPane.MessageInformation("No hay Retenciones cargadas.");
            }
        }

        private void btnEditarConcepto_Click(object sender, EventArgs e)
        {
            if (dgvReteConcepto.RowCount != 0)
            {
                var gridRow = this.dgvReteConcepto.CurrentRow;
                var frmEditarConcepto = new FrmEditarConcepto();
                frmEditarConcepto.IdConcepto = Convert.ToInt32(gridRow.Cells["IdConcepto"].Value);
                frmEditarConcepto.txtConcepto.Text = gridRow.Cells["Concepto"].Value.ToString();
                frmEditarConcepto.txtCifraUvt.Text = gridRow.Cells["CifraUVT"].Value.ToString().Replace(',', '.');
                frmEditarConcepto.txtCifraPesos.Text = gridRow.Cells["CifraPesos"].Value.ToString().Replace(',', '.');
                frmEditarConcepto.txtTarifa.Text = gridRow.Cells["Tarifa"].Value.ToString().Replace(',', '.');
                frmEditarConcepto.ShowDialog();
            }
            else
            {
                OptionPane.MessageInformation("No hay Retenciones cargadas.");
            }
        }

        private void btnEliminarConcepto_Click(object sender, EventArgs e)
        {
            if (this.dgvReteConcepto.RowCount != 0)
            {
                try
                {
                    DialogResult rta = MessageBox.Show("¿Esta seguro(a) de eliminar el registro?", "Retenciones",
			                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (rta.Equals(DialogResult.Yes))
                    {
                        var id = Convert.ToInt32(this.dgvReteConcepto.CurrentRow.Cells["IdConcepto"].Value);
                        if (!miBussinesRetencion.ExisteReteConceptoCompra(id) &&
                            !miBussinesRetencion.ExisteReteConceptoVenta(id))
                        {
                            miBussinesRetencion.EliminarConcepto(id);
                            this.dgvRubro_CellClick(this.dgvRubro, null);
                        }
                        else
                        {
                            OptionPane.MessageInformation("El Concepto no se puede eliminar por que se encuentra aplicado.");
                        }
                    }
                }
                catch (Exception ex)
                {
                    OptionPane.MessageError(ex.Message);
                }
            }
            else
            {
                OptionPane.MessageInformation("No hay registros para eliminar.");
            }
        }

        private void CargarDatos()
        {
            try
            {
                dgvRubro.DataSource = miBussinesRetencion.Rubros();
                dgvRubro_CellClick(this.dgvRubro, null);
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
        }

        void CompletaEventos_Completaz(CompletaArgumentosDeEventoz args)
        {
            try
            {
                if (Convert.ToInt32(args.MiZona).Equals(10))
                {
                    CargarDatos();
                }
                else
                {
                    if (Convert.ToInt32(args.MiZona).Equals(20))
                    {
                        this.dgvRubro_CellClick(this.dgvRubro, null);
                    }
                }
            }
            catch { }
        }
    }
}