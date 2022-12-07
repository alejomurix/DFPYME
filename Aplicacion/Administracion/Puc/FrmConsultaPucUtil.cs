using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BussinesLayer.Clases;
using Utilities;
using CustomControl;

namespace Aplicacion.Administracion.Puc
{
    public partial class FrmConsultaPucUtil : Form
    {
        public bool Extend { set; get; }

        private BussinesPuc miBussinesPuc;

        private DataTable tData;

        private BindingSource bSource;

        public FrmConsultaPucUtil()
        {
            InitializeComponent();
            this.Extend = false;
            this.miBussinesPuc = new BussinesPuc();
            TData();
            this.bSource = new BindingSource();
        }

        private void FrmConsultaPuc_Load(object sender, EventArgs e)
        {
            CargarDatos();
        }

        private void FrmConsultaPuc_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyData)
            {
                case Keys.F12:
                    {
                        this.tsBtnSeleccionar_Click(this.tsBtnSeleccionar, new EventArgs());
                        break;
                    }
                case Keys.Escape:
                    {
                        this.Close();
                        break;
                    }
            }
        }

        private void tsBtnSeleccionar_Click(object sender, EventArgs e)
        {
            this.dgvCuentas_CellDoubleClick(this.dgvCuentas, null);
        }

        private void tsSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void rBtnTodos_Click(object sender, EventArgs e)
        {
            if (this.rBtnTodos.Checked)
            {
                this.bSource.DataSource = this.tData;
                this.dgvCuentas.Columns["Nombre"].Width = 350;
                ColorGrid();
            }
        }

        private void rBtnGrupo1_Click(object sender, EventArgs e)
        {
            if (this.rBtnGrupo1.Checked)
            {
                RecargarGrid(1);
            }
        }

        private void rBtnGrupo2_Click(object sender, EventArgs e)
        {
            if (this.rBtnGrupo2.Checked)
            {
                RecargarGrid(2);
            }
        }

        private void rBtnGrupo3_Click(object sender, EventArgs e)
        {
            if (this.rBtnGrupo3.Checked)
            {
                RecargarGrid(3);
            }
        }

        private void rBtnGrupo4_Click(object sender, EventArgs e)
        {
            if (this.rBtnGrupo4.Checked)
            {
                RecargarGrid(4);
            }
        }

        private void rBtnGrupo5_Click(object sender, EventArgs e)
        {
            if (this.rBtnGrupo5.Checked)
            {
                RecargarGrid(5);
            }
        }

        private void rBtnGrupo6_Click(object sender, EventArgs e)
        {
            if (this.rBtnGrupo6.Checked)
            {
                RecargarGrid(6);
            }
        }

        private void rBtnGrupo7_Click(object sender, EventArgs e)
        {
            if (this.rBtnGrupo7.Checked)
            {
                RecargarGrid(7);
            }
        }

        private void rBtnGrupo8_Click(object sender, EventArgs e)
        {
            if (this.rBtnGrupo8.Checked)
            {
                RecargarGrid(8);
            }
        }

        private void rBtnGrupo9_Click(object sender, EventArgs e)
        {
            if (this.rBtnGrupo9.Checked)
            {
                RecargarGrid(9);
            }
        }

        private void dgvCuentas_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (this.Extend)
            {
                if (this.dgvCuentas.RowCount != 0)
                {
                    if (Convert.ToBoolean(this.dgvCuentas.CurrentRow.Cells["Aplica"].Value))
                    {
                        CompletaEventos.CapturaEvento(new ObjectAbstract
                        {
                            Id = 650,
                            Objeto = this.dgvCuentas.CurrentRow.Cells["Numero"].Value.ToString()
                        });
                        this.Close();
                    }
                    else
                    {
                        OptionPane.MessageInformation("La selección debe ser una cuenta auxiliar.");
                    }
                }
            }
        }

        private void TData()
        {
            this.tData = new DataTable();
            this.tData.Columns.Add(new DataColumn("Id", typeof(int)));
            this.tData.Columns.Add(new DataColumn("Grupo", typeof(int)));
            this.tData.Columns.Add(new DataColumn("Numero", typeof(string)));
            this.tData.Columns.Add(new DataColumn("Nombre", typeof(string)));
            this.tData.Columns.Add(new DataColumn("Clase", typeof(bool)));
            this.tData.Columns.Add(new DataColumn("Aplica", typeof(bool)));
        }

        private void CargarDatos()
        {
            try
            {
                var tClases = this.miBussinesPuc.Clases();
                foreach (DataRow clRow in tClases.Rows)
                {
                    if (miBussinesPuc.ExisteSubCuentas(Convert.ToInt32(clRow["id"])))
                    {
                        DataRow dRow = tData.NewRow();
                        dRow["Grupo"] = Convert.ToInt32(clRow["numero"]);
                        dRow["Numero"] = clRow["numero"].ToString();
                        dRow["Nombre"] = clRow["nombre"].ToString();
                        dRow["Clase"] = true;
                        dRow["Aplica"] = false;
                        tData.Rows.Add(dRow);

                        var tGrupos = miBussinesPuc.Grupos(Convert.ToInt32(clRow["id"]));
                        foreach (DataRow gRow in tGrupos.Rows)
                        {
                            dRow = tData.NewRow();
                            dRow["Grupo"] = Convert.ToInt32(clRow["numero"]);
                            dRow["Numero"] = clRow["numero"].ToString() + gRow["numero"].ToString();
                            dRow["Nombre"] = gRow["nombre"].ToString();
                            dRow["Clase"] = false;
                            dRow["Aplica"] = false;
                            tData.Rows.Add(dRow);

                            var tCuentas = miBussinesPuc.Cuentas(Convert.ToInt32(gRow["id"]));
                            foreach (DataRow cRow in tCuentas.Rows)
                            {
                                dRow = tData.NewRow();
                                dRow["Grupo"] = Convert.ToInt32(clRow["numero"]);
                                dRow["Numero"] = clRow["numero"].ToString() + gRow["numero"].ToString() + cRow["numero"].ToString();
                                dRow["Nombre"] = cRow["nombre"].ToString();
                                dRow["Clase"] = false;
                                dRow["Aplica"] = false;
                                tData.Rows.Add(dRow);

                                var tSCuentas = miBussinesPuc.SubCuentas(Convert.ToInt32(cRow["id"]));
                                foreach (DataRow scRow in tSCuentas.Rows)
                                {
                                    dRow = tData.NewRow();
                                    dRow["Id"] = scRow["id"];
                                    dRow["Grupo"] = Convert.ToInt32(clRow["numero"]);
                                    dRow["Numero"] = clRow["numero"].ToString() + gRow["numero"].ToString() + cRow["numero"].ToString() + scRow["numero"].ToString();
                                    dRow["Nombre"] = scRow["nombre"].ToString();
                                    dRow["Clase"] = false;
                                    dRow["Aplica"] = true;
                                    tData.Rows.Add(dRow);
                                }
                            }
                        }
                    }
                }
                this.dgvCuentas.AutoGenerateColumns = false;
                this.dgvCuentas.DataSource = this.bSource;

                this.bSource.DataSource = this.tData;
                ColorGrid();
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
        }

        private void RecargarGrid(int grupo)
        {
            IEnumerable<DataRow> query = from data in this.tData.AsEnumerable()
                                         where data.Field<int>("Grupo").Equals(grupo)
                                         select data;
            if (query.ToArray().Length != 0)
            {
                DataTable copy = query.CopyToDataTable<DataRow>();
                this.bSource.DataSource = copy;

                if (this.dgvCuentas.RowCount > 15)
                {
                    this.dgvCuentas.Columns["Nombre"].Width = 350;
                }
                else
                {
                    this.dgvCuentas.Columns["Nombre"].Width = 368;
                }
                ColorGrid();
            }
            else
            {
                this.bSource.DataSource = null;
            }
        }

        private void ColorGrid()
        {
            foreach (DataGridViewRow gRow in this.dgvCuentas.Rows)
            {
                if (Convert.ToBoolean(gRow.Cells["Clase"].Value))
                {
                    gRow.DefaultCellStyle.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
                }
            }

            /*foreach (DataGridViewRow gRow in this.dgvCuentas.Rows)
            {
                if (!Convert.ToBoolean(gRow.Cells["Aplica"].Value))
                {
                    gRow.Cells["Estado"].Style.BackColor = System.Drawing.SystemColors.ControlLight;
                    gRow.Cells["Estado"].ReadOnly = true;
                }

                if (Convert.ToBoolean(gRow.Cells["Estado"].Value))
                {
                    gRow.DefaultCellStyle.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
                }
            }*/
        }
    }
}