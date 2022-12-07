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

namespace Aplicacion.Ventas.Ingresos
{
    public partial class FrmConsultaConcepto : Form
    {
        private ErrorProvider miError;

        private BussinesOtroIngreso miBussinesIngreso;

        public FrmConsultaConcepto()
        {
            InitializeComponent();
            miError = new ErrorProvider();
            miBussinesIngreso = new BussinesOtroIngreso();
        }

        private void FrmConsultaConcepto_Load(object sender, EventArgs e)
        {
            CargarDatos();
        }

        private void FrmConsultaConcepto_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData.Equals(Keys.F12))
            {
                this.dgvConcepto_CellClick(this.dgvConcepto, null);
            }
            else
            {
                if (e.KeyData.Equals(Keys.Escape))
                {
                    this.Close();
                }
            }
        }

        private void cbCriterio_SelectionChangeCommitted(object sender, EventArgs e)
        {
            txtCriterio.Focus();
        }

        private void txtCriterio_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar.Equals((Char)Keys.Enter))
            {
                this.btnBuscar_Click(this.btnBuscar, new EventArgs());
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            dgvConcepto.AutoGenerateColumns = false;
            try
            {
                if (Convert.ToInt32(cbCriterio.SelectedValue).Equals(1))
                {
                    if (!Validacion.EsVacio(txtCriterio, miError, "El campo para Nombre es requerido."))
                    {
                        dgvConcepto.DataSource = miBussinesIngreso.Conceptos(txtCriterio.Text);
                    }
                }
                else
                {
                    if (!Validacion.EsVacio(txtCriterio, miError, "El campo para Código es requerido."))
                    {
                        if (Validacion.ConFormato(Validacion.TipoValidacion.Numeros, txtCriterio, miError,
                            "El Código que ingreso es invalido."))
                        {
                            dgvConcepto.DataSource = 
                                miBussinesIngreso.Conceptos(Convert.ToInt32(txtCriterio.Text));
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
        }

        private void dgvConcepto_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvConcepto.RowCount != 0)
            {
                var concepto = new ConceptoOtroIngreso();
                concepto.Codigo = Convert.ToInt32(dgvConcepto.CurrentRow.Cells["Codigo"].Value);
                concepto.Nombre = dgvConcepto.CurrentRow.Cells["Nombre"].Value.ToString();
                CompletaEventos.CapturaEventoAdelanto(concepto);
                this.Close();
            }
            else
            {
                OptionPane.MessageInformation("No hay registros para cargar.");
            }
        }

        private void CargarDatos()
        {
            var lst = new List<Inventario.Producto.Criterio>();
            lst.Add(new Inventario.Producto.Criterio
            {
                Id = 1,
                Nombre = "Nombre"
            });
            lst.Add(new Inventario.Producto.Criterio
            {
                Id = 2,
                Nombre = "Código"
            });
            cbCriterio.DataSource = lst;

            try
            {
                this.dgvConcepto.DataSource = this.miBussinesIngreso.Conceptos("");
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
        }
    }
}