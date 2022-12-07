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
    public partial class FrmTipoRetencion : Form
    {
        private BussinesRegimen miBussinesRegimen;

        private BussinesRetencion miBussinesRetencion;

        private DataTable TablaCompra;

        private DataTable TablaVenta;

        private BindingSource miBindingSource;

        private ToolTip miToolTip;

        public FrmTipoRetencion()
        {
            InitializeComponent();
            CrearTablas();
            miBussinesRegimen = new BussinesRegimen();
            miBussinesRetencion = new BussinesRetencion();
            miBindingSource = new BindingSource();
            this.miToolTip = new ToolTip();
        }

        private void FrmTipoRetencion_Load(object sender, EventArgs e)
        {
            
            dgvReteConcepto.AutoGenerateColumns = false;
            dgvReteConceptoAplica.AutoGenerateColumns = false;
            
            
            dgvReteConceptoAplica.DataSource = miBindingSource;
            CargarDatos();

           // miToolTip.SetToolTip(this.btnEliminar, "");
        }

        private void cbTipoEmpresa_SelectionChangeCommitted(object sender, EventArgs e)
        {
            CargarRetenciones();
        }

        private void cbTipoOperacion_SelectionChangeCommitted(object sender, EventArgs e)
        {
            CargarRetenciones();
        }

        #region Retenciones en Compras

        /*private void btnGuardarReteCompra_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvReteConceptoAplica.RowCount != 0)
                {
                    DialogResult rta = MessageBox.Show("¿Esta seguro(a) de guardar los cambios?", "Retenciones",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (rta.Equals(DialogResult.Yes))
                    {
                        var id = miBussinesRetencion.IngresarReteCompra
                                    (Convert.ToInt32(cbTipoEmpresa.SelectedValue), Convert.ToInt32(cbTipoOperacion.SelectedValue));
                        foreach (DataGridViewRow gridRow in dgvReteConceptoAplica.Rows)
                        {
                            //IdConceptoAplica
                            miBussinesRetencion.IngresarAplicaReteCompra
                                (Convert.ToInt32(id), Convert.ToInt32(gridRow.Cells["IdConceptoAplica"].Value));
                        }
                    }
                }
                else
                {
                    OptionPane.MessageInformation("Debe cargar al menos una Retención.");
                }
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
        }*/

        private void dgvRubro_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvRubro.RowCount != 0)
            {
                dgvReteConcepto.DataSource = miBussinesRetencion.Conceptos
                    (Convert.ToInt32(dgvRubro.CurrentRow.Cells["IdRubro"].Value));
                CargarRetenciones();
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (dgvReteConcepto.RowCount != 0)
            {
                try
                {
                    var idEmpresa = Convert.ToInt32(cbTipoEmpresa.SelectedValue);
                    var idOperacion = Convert.ToInt32(cbTipoOperacion.SelectedValue);
                    var idReteCompra = 0;
                    if (miBussinesRetencion.ExisteReteCompra(idEmpresa, idOperacion))
                    {
                        idReteCompra = miBussinesRetencion.IdReteCompra(idEmpresa, idOperacion);
                    }
                    else
                    {
                        idReteCompra = Convert.ToInt32(
                                       miBussinesRetencion.IngresarReteCompra(idEmpresa, idOperacion));
                    }
                    var idReteConcepto = Convert.ToInt32(dgvReteConcepto.CurrentRow.Cells["IdConcepto"].Value);
                    if (miBussinesRetencion.ExisteAplicaReteCompra(idReteCompra, idReteConcepto))
                    {
                        OptionPane.MessageInformation("La retención que que selecciono ya esta aplicada.");
                    }
                    else
                    {
                        miBussinesRetencion.IngresarAplicaReteCompra(idReteCompra, idReteConcepto);
                        CargarRetenciones();
                    }
                }
                catch (Exception ex)
                {
                    OptionPane.MessageError(ex.Message);
                }
            }
        }

        private void btnAgregarTodos_Click(object sender, EventArgs e)
        {
            if (dgvReteConcepto.RowCount != 0)
            {
                try
                {
                    var idEmpresa = Convert.ToInt32(cbTipoEmpresa.SelectedValue);
                    var idOperacion = Convert.ToInt32(cbTipoOperacion.SelectedValue);
                    var idReteCompra = 0;
                    if (miBussinesRetencion.ExisteReteCompra(idEmpresa, idOperacion))
                    {
                        idReteCompra = miBussinesRetencion.IdReteCompra(idEmpresa, idOperacion);
                    }
                    else
                    {
                        idReteCompra = Convert.ToInt32(
                                       miBussinesRetencion.IngresarReteCompra(idEmpresa, idOperacion));
                    }
                    foreach (DataGridViewRow gRow in dgvReteConcepto.Rows)
                    {
                        var idReteConcepto = Convert.ToInt32(gRow.Cells["IdConcepto"].Value);
                        if (miBussinesRetencion.ExisteAplicaReteCompra(idReteCompra, idReteConcepto))
                        {
                        }
                        else
                        {
                            miBussinesRetencion.IngresarAplicaReteCompra(idReteCompra, idReteConcepto);
                            CargarRetenciones();
                        }
                    }
                }
                catch (Exception ex)
                {
                    OptionPane.MessageError(ex.Message);
                }
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvReteConceptoAplica.RowCount != 0)
            {
                DialogResult rta = MessageBox.Show("¿Está seguro(a) de eliminar los registros seleccionados?", "Retenciones",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (rta.Equals(DialogResult.Yes))
                {
                    var lst = new List<int>();
                    try
                    {
                        this.miBussinesRetencion.EliminarAplicaReteCompra(Convert.ToInt32(
                            this.dgvReteConceptoAplica.CurrentRow.Cells["IdAplica"].Value));
                        CargarRetenciones();
                       /* int selectedRowCount =
                            dgvReteConceptoAplica.Rows.GetRowCount(DataGridViewElementStates.Selected);
                        if (selectedRowCount > 0)
                        {
                            for (int i = 0; i < selectedRowCount; i++)
                            {
                                lst.Add(Convert.ToInt32(
                                        dgvReteConceptoAplica.Rows[dgvReteConceptoAplica.SelectedRows[i].Index].
                                        Cells["IdAplica"].Value));
                            }
                            foreach (int id in lst)
                            {
                                miBussinesRetencion.EliminarAplicaReteCompra(id);
                            }
                            CargarRetenciones();
                        }*/
                    }
                    catch (Exception ex)
                    {
                        OptionPane.MessageError(ex.Message);
                    }
                }
            }
            else
            {
                OptionPane.MessageInformation("No hay registros para eliminar.");
            }
        }

        private void btnDefinirRete_Click(object sender, EventArgs e)
        {
            if (dgvReteConceptoAplica.RowCount != 0)
            {
                try
                {
                    DialogResult rta = MessageBox.Show("¿Esta seguro(a) de establecer por defecto esta retención?", "Retenciones",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (rta.Equals(DialogResult.Yes))
                    {
                        var gRow = dgvReteConceptoAplica.Rows[dgvReteConceptoAplica.CurrentRow.Index];
                        AppConfiguracion.SaveConfiguration("concepto", gRow.Cells["ConceptoAplica"].Value.ToString());
                        AppConfiguracion.SaveConfiguration("uvt", gRow.Cells["CifraUVTAplica"].Value.ToString());
                        AppConfiguracion.SaveConfiguration("pesos", gRow.Cells["CifraPesosAplica"].Value.ToString());
                        AppConfiguracion.SaveConfiguration("tasa", gRow.Cells["TarifaAplica"].Value.ToString());
                        OptionPane.MessageInformation("La retencion se ha establecido como predeterminada.");
                    }
                }
                catch (Exception ex)
                {
                    OptionPane.MessageError(ex.Message);
                }
            }
        }

        private void tsBtnLimpiarReteDefecto_Click(object sender, EventArgs e)
        {
            //if (dgvReteConceptoAplica.RowCount != 0)
            // {
            try
            {
                DialogResult rta = MessageBox.Show("¿Esta seguro(a) de quitar la retención por defecto?", "Retenciones",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (rta.Equals(DialogResult.Yes))
                {
                    //var gRow = dgvReteConceptoAplica.Rows[dgvReteConceptoAplica.CurrentRow.Index];
                    AppConfiguracion.SaveConfiguration("concepto", "");
                    AppConfiguracion.SaveConfiguration("uvt", "0");
                    AppConfiguracion.SaveConfiguration("pesos", "0");
                    AppConfiguracion.SaveConfiguration("tasa", "0");
                    OptionPane.MessageInformation("La retencion se ha establecido como predeterminada.");
                }
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
            // }
        }

        private void CargarRetenciones()
        {
            try
            {
                dgvReteConceptoAplica.AutoGenerateColumns = false;
                dgvReteConceptoAplica.DataSource =
                    miBussinesRetencion.RetencionesAplicadasACompra
                                        (Convert.ToInt32(cbTipoEmpresa.SelectedValue), 
                                         Convert.ToInt32(cbTipoOperacion.SelectedValue),
                                         Convert.ToInt32(dgvRubro.CurrentRow.Cells["IdRubro"].Value));
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
        }

        #endregion

        #region Retenciones en Ventas

        private void tcRetencion_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tcRetencion.SelectedIndex.Equals(1))
            {
                if (dgvRubroVenta.RowCount != 0)
                {
                    dgvRubroVenta_CellClick(this.dgvRubroVenta, null);
                }
            }
        }

        private void cbTipoEmpresaVenta_SelectionChangeCommitted(object sender, EventArgs e)
        {
            CargarRetencionesVenta();
        }

        private void cbTipoOperacionVenta_SelectionChangeCommitted(object sender, EventArgs e)
        {
            CargarRetencionesVenta();
        }

        private void dgvRubroVenta_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvRubroVenta.RowCount != 0)
            {
                dgvReteConceptoVenta.DataSource = miBussinesRetencion.Conceptos
                    (Convert.ToInt32(dgvRubroVenta.CurrentRow.Cells["IdRubroVenta"].Value));
                CargarRetencionesVenta();
            }
        }

        private void btnAgregarVenta_Click(object sender, EventArgs e)
        {
            if (dgvReteConceptoVenta.RowCount != 0)
            {
                try
                {
                    var idEmpresa = Convert.ToInt32(cbTipoEmpresaVenta.SelectedValue);
                    var idOperacion = Convert.ToInt32(cbTipoOperacionVenta.SelectedValue);
                    var idReteVenta = 0;
                    if (miBussinesRetencion.ExisteReteVenta(idEmpresa, idOperacion))
                    {
                        idReteVenta = miBussinesRetencion.IdReteVenta(idEmpresa, idOperacion);
                    }
                    else
                    {
                        idReteVenta = Convert.ToInt32(miBussinesRetencion.IngresarReteVenta
                                                                    (idEmpresa, idOperacion));
                    }
                    var idReteConcepto = Convert.ToInt32(dgvReteConceptoVenta.CurrentRow.Cells["IdConceptoVenta"].Value);
                    if (miBussinesRetencion.ExisteAplicaReteVenta(idReteVenta, idReteConcepto))
                    {
                        OptionPane.MessageInformation("La retención que que selecciono ya esta aplicada.");
                    }
                    else
                    {
                        miBussinesRetencion.IngresarAplicaReteVenta(idReteVenta, idReteConcepto);
                        CargarRetencionesVenta();
                    }
                }
                catch (Exception ex)
                {
                    OptionPane.MessageError(ex.Message);
                }
            }
        }

        private void btnAgregarTodosVenta_Click(object sender, EventArgs e)
        {
            if (dgvReteConceptoVenta.RowCount != 0)
            {
                try
                {
                    var idEmpresa = Convert.ToInt32(cbTipoEmpresaVenta.SelectedValue);
                    var idOperacion = Convert.ToInt32(cbTipoOperacionVenta.SelectedValue);
                    var idReteVenta = 0;
                    if (miBussinesRetencion.ExisteReteVenta(idEmpresa, idOperacion))
                    {
                        idReteVenta = miBussinesRetencion.IdReteVenta(idEmpresa, idOperacion);
                    }
                    else
                    {
                        idReteVenta = Convert.ToInt32(
                                      miBussinesRetencion.IngresarReteVenta(idEmpresa, idOperacion));
                    }
                    foreach (DataGridViewRow gRow in dgvReteConceptoVenta.Rows)
                    {
                        var idReteConcepto = Convert.ToInt32(gRow.Cells["IdConceptoVenta"].Value); //IdConceptoVenta
                        if (!miBussinesRetencion.ExisteAplicaReteVenta(idReteVenta, idReteConcepto))
                        {
                            miBussinesRetencion.IngresarAplicaReteVenta(idReteVenta, idReteConcepto);
                            CargarRetencionesVenta();
                        }
                    }
                }
                catch (Exception ex)
                {
                    OptionPane.MessageError(ex.Message);
                }
            }
        }

        private void btnEliminarVenta_Click(object sender, EventArgs e)
        {
            if (dgvReteConceptoAplicaVenta.RowCount != 0)
            {
                DialogResult rta = MessageBox.Show("¿Está seguro(a) de eliminar los registros seleccionados?", "Retenciones",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (rta.Equals(DialogResult.Yes))
                {
                    var lst = new List<int>();
                    try
                    {
                        this.miBussinesRetencion.EliminarAplicaReteVenta
                            (Convert.ToInt32(this.dgvReteConceptoAplicaVenta.CurrentRow.Cells["IdAplicaVenta"].Value));
                        CargarRetencionesVenta();
                       /* int selectedRowCount =
                            dgvReteConceptoAplicaVenta.Rows.GetRowCount(DataGridViewElementStates.Selected);
                        if (selectedRowCount > 0)
                        {
                            for (int i = 0; i < selectedRowCount; i++)
                            {
                                lst.Add(Convert.ToInt32(
                                        dgvReteConceptoAplicaVenta.Rows[dgvReteConceptoAplicaVenta.SelectedRows[i].Index].
                                        Cells["IdAplicaVenta"].Value));
                            }
                            foreach (int id in lst)
                            {
                                miBussinesRetencion.EliminarAplicaReteVenta(id);
                            }
                            CargarRetencionesVenta();
                        }*/
                    }
                    catch (Exception ex)
                    {
                        OptionPane.MessageError(ex.Message);
                    }
                }
            }
            else
            {
                OptionPane.MessageInformation("No hay registros para eliminar.");
            }
        }

        private void tsBtnPredeterminadaVenta_Click(object sender, EventArgs e)
        {
            if (dgvReteConceptoAplicaVenta.RowCount != 0)
            {
                try
                {
                    DialogResult rta = MessageBox.Show("¿Esta seguro(a) de establecer por defecto esta retención?", "Retenciones",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (rta.Equals(DialogResult.Yes))
                    {
                        var gRow = dgvReteConceptoAplicaVenta.Rows[dgvReteConceptoAplica.CurrentRow.Index];
                        AppConfiguracion.SaveConfiguration("concepto_v", gRow.Cells["ConceptoAplicaVenta"].Value.ToString());
                        AppConfiguracion.SaveConfiguration("uvt_v", gRow.Cells["CifraUVTAplicaVenta"].Value.ToString());
                        AppConfiguracion.SaveConfiguration("pesos_v", gRow.Cells["CifraPesosAplicaVenta"].Value.ToString());
                        AppConfiguracion.SaveConfiguration("tasa_v", gRow.Cells["TarifaAplicaVenta"].Value.ToString());
                        OptionPane.MessageInformation("La retencion se ha establecido como predeterminada.");
                    }
                }
                catch (Exception ex)
                {
                    OptionPane.MessageError(ex.Message);
                }
            }
        }

        private void tsBtnLimpiarPredeterminadaVenta_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult rta = MessageBox.Show("¿Esta seguro(a) de quitar la retención por defecto?", "Retenciones",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (rta.Equals(DialogResult.Yes))
                {
                    //var gRow = dgvReteConceptoAplica.Rows[dgvReteConceptoAplica.CurrentRow.Index];
                    AppConfiguracion.SaveConfiguration("concepto_v", "");
                    AppConfiguracion.SaveConfiguration("uvt_v", "0");
                    AppConfiguracion.SaveConfiguration("pesos_v", "0");
                    AppConfiguracion.SaveConfiguration("tasa_v", "0");
                    OptionPane.MessageInformation("La retencion se ha establecido como predeterminada.");
                }
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
        }

        private void CargarRetencionesVenta()
        {
            try
            {
                dgvReteConceptoAplicaVenta.AutoGenerateColumns = false;
                dgvReteConceptoAplicaVenta.DataSource =
                    miBussinesRetencion.RetencionesAplicadasAVenta(Convert.ToInt32(cbTipoEmpresaVenta.SelectedValue),
                                                                   Convert.ToInt32(cbTipoOperacionVenta.SelectedValue),
                                                                   Convert.ToInt32(dgvRubroVenta.CurrentRow.Cells["IdRubroVenta"].Value));
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
        }

        #endregion

        private void CargarDatos()
        {
            try
            {
                //Compra
                cbTipoEmpresa.DataSource = miBussinesRegimen.ListadoRegimen();

                cbTipoOperacion.DataSource = miBussinesRegimen.ListadoRegimen();

                dgvRubro.DataSource = miBussinesRetencion.Rubros();
                if (dgvRubro.RowCount != 0)
                {
                    dgvRubro_CellClick(this.dgvRubro, null);
                }

                CargarRetenciones();

                //Venta
                cbTipoEmpresaVenta.DataSource = miBussinesRegimen.ListadoRegimen();
                cbTipoOperacionVenta.DataSource = miBussinesRegimen.ListadoRegimen();
                dgvRubroVenta.DataSource = miBussinesRetencion.Rubros();
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
        }

        private void CrearTablas()
        {
            TablaCompra = new DataTable();
            TablaCompra.Columns.Add(new DataColumn("IdConceptoAplica", typeof(int)));
            TablaCompra.Columns.Add(new DataColumn("IdRetencionAplica", typeof(int)));
            TablaCompra.Columns.Add(new DataColumn("RubroAplica", typeof(string)));
            TablaCompra.Columns.Add(new DataColumn("ConceptoAplica", typeof(string)));
            TablaCompra.Columns.Add(new DataColumn("CifraUVTAplica", typeof(double)));
            TablaCompra.Columns.Add(new DataColumn("CifraPesosAplica", typeof(double)));
            TablaCompra.Columns.Add(new DataColumn("TarifaAplica", typeof(double)));

            
        }

        private void RecargarGridCompra()
        {
            IEnumerable<DataRow> query = from data in TablaCompra.AsEnumerable()
                                         orderby data.Field<int>("IdRetencionAplica") ascending
                                         select data;
            DataTable copy = query.CopyToDataTable<DataRow>();
            miBindingSource.DataSource = copy;
        }

        /*
         IdConceptoAplica
IdRetencionAplica
ConceptoAplica
CifraUVTAplica
CifraPesosAplica
TarifaAplica
         */
    }
}