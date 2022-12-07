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

namespace Aplicacion.Administracion.Descuentos
{
    public partial class FrmConsulta : Form
    {
        private bool Transer { set; get; }

        private BussinesGrupoDescuento miBussinesGrupo;

        private BussinesAplicaDescuento miBussinesDescuento;

        public FrmConsulta()
        {
            InitializeComponent();
            this.Transer = false;
            this.miBussinesGrupo = new BussinesGrupoDescuento();
            this.miBussinesDescuento = new BussinesAplicaDescuento();
        }

        private void FrmConsulta_Load(object sender, EventArgs e)
        {
            CargarDatos();
            CompletaEventos.Completa += new CompletaEventos.CompletaAccion(CompletaEventos_Completa);
        }

        private void FrmConsulta_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyData)
            {
                case Keys.F3:
                    {
                        this.btnNuevoGrupo_Click(this.btnNuevoGrupo, new EventArgs());
                        break;
                    }
                case Keys.F4:
                    {
                        this.btnNuevoDescuento_Click(this.btnNuevoDescuento, new EventArgs());
                        break;
                    }
                case Keys.Escape:
                    {
                        this.Close();
                        break;
                    }
            }
        }

        private void tsBtnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnNuevoGrupo_Click(object sender, EventArgs e)
        {
            var frmGrupo = new FrmGrupo();
            this.Transer = true;
            frmGrupo.ShowDialog();
        }

        private void dgvGrupos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (this.dgvGrupos.RowCount != 0)
                {
                    this.dgDescuentos.AutoGenerateColumns = false;
                    this.dgDescuentos.DataSource =
                        miBussinesDescuento.Descuentos(Convert.ToInt32(this.dgvGrupos.CurrentRow.Cells["IdGrupo"].Value));
                }
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
        }

        private void dgvGrupos_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyData.Equals(Keys.Up) || e.KeyData.Equals(Keys.Down))
            {
                this.dgvGrupos_CellClick(this.dgvGrupos, null);
            }
        }

        private void btnNuevoDescuento_Click(object sender, EventArgs e)
        {
            var frmDescuento = new FrmDescuento();
            frmDescuento.IdGrupo = Convert.ToInt32(this.dgvGrupos.CurrentRow.Cells["IdGrupo"].Value);
            this.Transer = true;
            frmDescuento.ShowDialog();
        }

        private void CargarDatos()
        {
            try
            {
                this.dgvGrupos.AutoGenerateColumns = false;
                this.dgvGrupos.DataSource = miBussinesGrupo.Grupos();
                this.dgvGrupos_CellClick(this.dgvGrupos, null);
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
        }

        void CompletaEventos_Completa(CompletaArgumentosDeEvento args)
        {
            try
            {
                if (this.Transer)
                {
                    var obj = (ObjectAbstract)args.MiObjeto;
                    if (obj.Id.Equals(230))
                    {
                        IngresarGrupo((string)obj.Objeto);
                        this.Transer = false;
                    }
                    else
                    {
                        if (obj.Id.Equals(235))
                        {
                            this.dgvGrupos_CellClick(this.dgvGrupos, null);
                        }
                    }
                }
            }
            catch { }
        }

        private void IngresarGrupo(string codigo)
        {
            try
            {
                miBussinesGrupo.Ingresar(new GrupoDescuento { Codigo = codigo });
                OptionPane.MessageInformation("El grupo se ingresó con exito.");
                CargarDatos();
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
        }
    }
}