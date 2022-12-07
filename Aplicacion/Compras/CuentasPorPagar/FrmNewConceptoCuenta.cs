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

namespace Aplicacion.Compras.CuentasPorPagar
{
    public partial class FrmNewConceptoCuenta : Form
    {
        private BussinesCuentaPagar miBussinesCuentaPagar;

        public int IdCuenta { set; get; }

        private DataTable TConcepto { set; get; }

        private ToolTip miToolTip;

        private int Contador;

        private bool ConceptoMatch;

        private bool CantidadMatch;

        private bool ValorMatch;

        private BindingSource miBindingSource;

        private ErrorProvider miError;

        public FrmNewConceptoCuenta()
        {
            InitializeComponent();
            miBussinesCuentaPagar = new BussinesCuentaPagar();
            this.IdCuenta = 0;
            CrearDatos();
            this.miToolTip = new ToolTip();
            this.Contador = 1;
            this.miBindingSource = new BindingSource();
            this.ConceptoMatch = false;
            this.CantidadMatch = false;
            this.ValorMatch = false;
            this.miError = new ErrorProvider();
        }

        private void FrmCuentaPagar_Load(object sender, EventArgs e)
        {
            this.dgvConceptos.AutoGenerateColumns = false;
            this.dgvConceptos.DataSource = this.miBindingSource;
        }

        private void FrmNewConceptoCuenta_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData.Equals(Keys.F2))
            {
                this.tsBtnGuardar_Click(this.tsBtnGuardar, new EventArgs());
            }
            else
            {
                if (e.KeyData.Equals(Keys.Escape))
                {
                    this.Close();
                }
            }
        }

        private void tsBtnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (DetalleCuentaPagar detalle in Detalles())
                {
                    miBussinesCuentaPagar.IngresarDetalle(detalle);
                }
                CompletaEventos.CapturaEvento(new ObjectAbstract
                {
                    Id = 460,
                    Objeto = null
                });
                OptionPane.MessageInformation("Los conceptos se agregaron exitosamente.");
                this.txtConcepto.Text = "";
                this.txtCantidad.Text = "";
                this.txtValor.Text = "";
                while (this.dgvConceptos.RowCount != 0)
                {
                    this.dgvConceptos.Rows.RemoveAt(0);
                }
                this.TConcepto.Rows.Clear();
                this.txtTotal.Text = "0";
                this.Contador = 1;
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
        }

        private void tsBtnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtConcepto_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar.Equals((char)Keys.Enter))
            {
                this.txtConcepto.Text = this.txtConcepto.Text.ToUpper();
                this.txtCantidad.Focus();
            }
        }

        private void txtConcepto_Validating(object sender, CancelEventArgs e)
        {
            if (!String.IsNullOrEmpty(txtConcepto.Text))
            {
                miError.SetError(txtConcepto, null);
                this.ConceptoMatch = true;
            }
            else
            {
                miError.SetError(txtConcepto, "El campo Concepto es requerido.");
                this.ConceptoMatch = false;
            }
        }

        private void txtCantidad_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar.Equals((char)Keys.Enter))
            {
                this.txtValor.Focus();
            }
        }

        private void txtCantidad_Validating(object sender, CancelEventArgs e)
        {
            if (!String.IsNullOrEmpty(txtCantidad.Text))
            {
                if (Validacion.ConFormato
                    (Validacion.TipoValidacion.NumerosYPunto, txtCantidad, miError, "El valor es incorrecto."))
                {
                    this.CantidadMatch = true;
                    miError.SetError(txtCantidad, null);
                }
                else
                {
                    this.CantidadMatch = false;
                }
            }
            else
            {
                miError.SetError(txtCantidad, "El campo Cantidad es requerido.");
                this.CantidadMatch = false;
            }
        }

        private void txtValor_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar.Equals((char)Keys.Enter))
            {
                this.btnAgregar.Focus();
                this.btnAgregar_Click(this.btnAgregar, new EventArgs());
            }
        }

        private void txtValor_Validating(object sender, CancelEventArgs e)
        {
            if (!String.IsNullOrEmpty(txtValor.Text))
            {
                if (Validacion.ConFormato
                    (Validacion.TipoValidacion.Numeros, txtValor, miError, "El valor es incorrecto."))
                {
                    this.ValorMatch = true;
                    miError.SetError(txtValor, null);
                }
                else
                {
                    this.ValorMatch = false;
                }
            }
            else
            {
                miError.SetError(txtValor, "El campo Valor es requerido.");
                this.ValorMatch = false;
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            this.txtConcepto_Validating(this.txtConcepto, null);
            this.txtCantidad_Validating(this.txtCantidad, null);
            this.txtValor_Validating(this.txtValor, null);
            if (ConceptoMatch && CantidadMatch && ValorMatch)
            {
                try
                {
                    var row = TConcepto.NewRow();
                    row["Id"] = Contador;
                    row["Producto"] = txtConcepto.Text;
                    row["Cantidad"] = Convert.ToDouble(txtCantidad.Text.Replace('.', ','));
                    row["Valor_"] = Convert.ToInt32(txtValor.Text);
                    TConcepto.Rows.Add(row);
                    this.Contador++;
                    RecargarGridView();
                    txtConcepto.Focus();
                    txtConcepto.Text = "";
                    txtCantidad.Text = "";
                    txtValor.Text = "";
                }
                catch (Exception ex)
                {
                    OptionPane.MessageError(ex.Message);
                }
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (this.dgvConceptos.RowCount != 0)
            {
                DialogResult rta = MessageBox.Show("¿Está seguro(a) de retirar el registro?", "Cuentas por Pagar",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (rta.Equals(DialogResult.Yes))
                {
                    try
                    {
                        var id = Convert.ToInt32(dgvConceptos.CurrentRow.Cells["Id"].Value);
                        var row = (from data in TConcepto.AsEnumerable()
                                   where data.Field<int>("Id").Equals(id)
                                   select data).First();
                        TConcepto.Rows.Remove(row);
                        if (TConcepto.Rows.Count != 0)
                        {
                            RecargarGridView();
                        }
                        else
                        {
                            this.dgvConceptos.Rows.RemoveAt(
                                this.dgvConceptos.CurrentCell.RowIndex);
                            txtTotal.Text = "0";
                        }
                        miError.SetError(txtConcepto, null);
                        miError.SetError(txtCantidad, null);
                        miError.SetError(txtValor, null);
                    }
                    catch (Exception ex)
                    {
                        OptionPane.MessageError(ex.Message);
                    }
                }
            }
            else
            {
                OptionPane.MessageInformation("No hay registro para retirar.");
            }
        }

        private void CrearDatos()
        {
            TConcepto = new DataTable();
            TConcepto.Columns.Add(new DataColumn("Id", typeof(int)));
            TConcepto.Columns.Add(new DataColumn("Producto", typeof(string)));
            TConcepto.Columns.Add(new DataColumn("Cantidad", typeof(double)));
            TConcepto.Columns.Add(new DataColumn("Valor_", typeof(int)));
        }

        private void RecargarGridView()
        {
            IEnumerable<DataRow> query = from data in TConcepto.AsEnumerable()
                                         orderby data.Field<int>("Id") ascending
                                         select data;
            miBindingSource.DataSource = query.CopyToDataTable<DataRow>();
            this.txtTotal.Text = UseObject.InsertSeparatorMil(
                this.TConcepto.AsEnumerable().Sum(s => s.Field<int>("Valor_")).ToString());
        }

        private List<DetalleCuentaPagar> Detalles()
        {
            var detalles = new List<DetalleCuentaPagar>();
            foreach (DataRow row in TConcepto.Rows)
            {
                detalles.Add(new DetalleCuentaPagar
                {
                    IdCuentaPagar = this.IdCuenta,
                    Concepto = row["Producto"].ToString(),
                    Cantidad = Convert.ToDouble(row["Cantidad"]),
                    Valor = Convert.ToInt32(row["Valor_"])
                });
            }
            return detalles;
        }
    }
}