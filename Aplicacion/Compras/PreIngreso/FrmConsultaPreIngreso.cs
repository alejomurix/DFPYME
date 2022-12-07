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

namespace Aplicacion.Compras.PreIngreso
{
    public partial class FrmConsultaPreIngreso : Form
    {
        private bool Form_;
        
        private BussinesFacturaProveedor miBussinesFactura;

        public FrmConsultaPreIngreso()
        {
            InitializeComponent();
            this.Form_ = false;
            this.miBussinesFactura = new BussinesFacturaProveedor();
        }

        private void FrmConsultaPreIngreso_Load(object sender, EventArgs e)
        {
            try
            {
                CompletaEventos.Completa += new CompletaEventos.CompletaAccion(CompletaEventos_Completa);

                this.dgvPreIngresos.AutoGenerateColumns = false;
                this.dgvPreIngresos.DataSource = this.miBussinesFactura.ComprasTemporales();
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
        }

        private void FrmConsultaPreIngreso_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData.Equals(Keys.F2))
            {
                this.tsFacturar_Click(this.tsFacturar, new EventArgs());
            }
            else
            {
                if (e.KeyData.Equals(Keys.Escape))
                {
                    this.Close();
                }
            }
        }

        private void tsFacturar_Click(object sender, EventArgs e)
        {
            if (this.dgvPreIngresos.RowCount != 0)
            {
                if (!this.Form_)
                {
                    var frmFacturar = new FrmFacturar();
                    frmFacturar.MdiParent = this.MdiParent;
                    frmFacturar.Id = Convert.ToInt32(this.dgvPreIngresos.CurrentRow.Cells["Id"].Value);
                    this.Form_ = true;
                    frmFacturar.Show();
                }
            }
            else
            {
                OptionPane.MessageInformation("No hay registros para facturar.");
            }
        }

        private void tsEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.dgvPreIngresos.RowCount != 0)
                {
                    DialogResult rta = MessageBox.Show("¿Esta seguro(a) de eliminar el registo?", "Preingreso de compras.",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (rta.Equals(DialogResult.Yes))
                    {
                        this.miBussinesFactura.EliminarCompraTemporal(Convert.ToInt32(this.dgvPreIngresos.CurrentRow.Cells["Id"].Value));
                        this.dgvPreIngresos.DataSource = this.miBussinesFactura.ComprasTemporales();
                    }
                }
                else
                {
                    OptionPane.MessageInformation("No hay registros para eliminar.");
                }
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
        }

        private void tsSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        void CompletaEventos_Completa(CompletaArgumentosDeEvento args)
        {
            try
            {
                var obj = (ObjectAbstract)args.MiObjeto;
                if (obj.Id.Equals(4455))
                {
                    this.dgvPreIngresos.DataSource = this.miBussinesFactura.ComprasTemporales();
                }
            }
            catch { }

            try
            {
                this.Form_ = (bool)args.MiObjeto;
            }
            catch { }
        }
    }
}