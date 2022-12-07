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
using DTO.Clases;
using Utilities;

namespace Aplicacion.Compras.Egreso
{
    public partial class FrmAplicaRetencion : Form
    {
        public bool AplicaCompra { set; get; }

        public bool AplicaVenta { set; get; }

        public bool AplicaEgreso { set; get; }

        public int IdTipoEmpresa { set; get; }

        public int IdTipoBeneficio { set; get; }

        public int Valor { set; get; }

        private BussinesRetencion miBussinessRetencion;

        private List<RetencionConcepto> Retenciones { set; get; }

        public FrmAplicaRetencion()
        {
            InitializeComponent();
            AplicaCompra = false;
            AplicaVenta = false;
            AplicaEgreso = false;
            Retenciones = new List<RetencionConcepto>();
            miBussinessRetencion = new BussinesRetencion();


            /*IdTipoEmpresa = 1;
            IdTipoBeneficio = 2;
            Valor = 800000;*/
        }

        private void FrmAplicaRetencion_Load(object sender, EventArgs e)
        {
            CargarRubro();
        }

        private void dgvRubro_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            CargarRetencionesAaplicar();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (dgvReteConceptoAplica.RowCount != 0)
            {
                DialogResult rta = MessageBox.Show("¿Está seguro(a) de agregar la retención?", "Retenciones",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (rta.Equals(DialogResult.Yes))
                {
                    try
                    {
                        int selectedRowCount =
                            dgvReteConceptoAplica.Rows.GetRowCount(DataGridViewElementStates.Selected);
                        if (selectedRowCount > 0)
                        {
                            for (int i = 0; i < selectedRowCount; i++)
                            {
                                var row = dgvReteConceptoAplica.Rows
                                    [dgvReteConceptoAplica.SelectedRows[i].Index];
                                if (AplicaEgreso)
                                {
                                    if (Valor >= Convert.ToInt32(row.Cells["CifraPesosAplica"].Value))
                                    {
                                        //buscar a row en Retenciones
                                        var query = Retenciones.Where(r => r.Id.Equals(Convert.ToInt32(row.Cells["IdConceptoAplica"].Value)));
                                        if (!(query.ToArray().Length > 0))
                                        {
                                            Retenciones.Add(new RetencionConcepto
                                            {
                                                Id = Convert.ToInt32(row.Cells["IdConceptoAplica"].Value),
                                                IdCuentaPuc = Convert.ToInt32(AppConfiguracion.ValorSeccion("ctaRetencion")),
                                                Concepto = "Retención por " + row.Cells["ConceptoAplica"].Value.ToString(),
                                                Tarifa = Convert.ToDouble(row.Cells["TarifaAplica"].Value),
                                                CifraPesos = (Valor * Convert.ToDouble(row.Cells["TarifaAplica"].Value) / 100) * -1
                                            });
                                        }
                                    }
                                }
                                else
                                {
                                    var query = Retenciones.Where(r => r.Id.Equals(Convert.ToInt32(row.Cells["IdConceptoAplica"].Value)));
                                    if (!(query.ToArray().Length > 0))
                                    {
                                        Retenciones.Add(new RetencionConcepto
                                        {
                                            Id = Convert.ToInt32(row.Cells["IdConceptoAplica"].Value),
                                            IdCuentaPuc = Convert.ToInt32(AppConfiguracion.ValorSeccion("ctaRetencion")),
                                            Concepto = "Retención por " + row.Cells["ConceptoAplica"].Value.ToString(),
                                            CifraPesos = Convert.ToDouble(row.Cells["CifraPesosAplica"].Value),
                                            CifraUVT = Convert.ToDouble(row.Cells["CifraUVTAplica"].Value),
                                            Tarifa = Convert.ToDouble(row.Cells["TarifaAplica"].Value)
                                        });
                                    }
                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        OptionPane.MessageError(ex.Message);
                    }
                }
                /*foreach (var o in Retenciones)
                {
                    MessageBox.Show(o.Concepto + " - " + o.CifraPesos.ToString());
                }*/
            }
            else
            {
                OptionPane.MessageInformation("No hay registros para agregar.");
            }
        }

        private void CargarRubro()
        {
            try
            {
                dgvRubro.AutoGenerateColumns = false;
                dgvRubro.DataSource = miBussinessRetencion.Rubros();
                if (dgvRubro.RowCount != 0)
                {
                    CargarRetencionesAaplicar();
                }
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
        }

        private void CargarRetencionesAaplicar()
        {
            try
            {
                if (AplicaVenta)
                {
                    dgvReteConceptoAplica.AutoGenerateColumns = false;
                    dgvReteConceptoAplica.DataSource = miBussinessRetencion.RetencionesAplicadasAVenta
                        (IdTipoEmpresa, IdTipoBeneficio, Convert.ToInt32(dgvRubro.CurrentRow.Cells["IdRubro"].Value));
                }
                else
                {
                    dgvReteConceptoAplica.AutoGenerateColumns = false;
                    dgvReteConceptoAplica.DataSource = miBussinessRetencion.RetencionesAplicadasACompra
                            (IdTipoEmpresa, IdTipoBeneficio, Convert.ToInt32(dgvRubro.CurrentRow.Cells["IdRubro"].Value));
                }
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
        }

        private void btnAplicar_Click(object sender, EventArgs e)
        {
            if (this.dgvReteConceptoAplica.RowCount > 0)
            {
                var gRow = this.dgvReteConceptoAplica.CurrentRow;
                Retenciones.Add(new RetencionConcepto
                {
                    Id = Convert.ToInt32(gRow.Cells["IdConceptoAplica"].Value),
                    IdCuentaPuc = Convert.ToInt32(AppConfiguracion.ValorSeccion("ctaRetencion")),
                    Concepto = "Retención por " + gRow.Cells["ConceptoAplica"].Value.ToString(),
                    CifraPesos = Convert.ToDouble(gRow.Cells["CifraPesosAplica"].Value),
                    CifraUVT = Convert.ToDouble(gRow.Cells["CifraUVTAplica"].Value),
                    Tarifa = Convert.ToDouble(gRow.Cells["TarifaAplica"].Value)
                });
            }

            if (AplicaEgreso)
            {
                CompletaEventos.CapturaEventoeb(Retenciones);
            }
            else
            {
                if (AplicaCompra)
                {
                    CompletaEventos.CapturaEventobo(Retenciones);
                }
                else
                {
                    CompletaEventos.CapturaEventoz(Retenciones);
                }
            }
        }
    }
}