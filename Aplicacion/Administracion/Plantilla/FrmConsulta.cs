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

namespace Aplicacion.Administracion.Plantilla
{
    public partial class FrmConsulta : Form
    {
        private BussinesPlantilla miBussinesPlantilla;

        private bool Transfer { set; get; }

        public FrmConsulta()
        {
            InitializeComponent();
            miBussinesPlantilla = new BussinesPlantilla();
            this.Transfer = false;
        }

        private void FrmConsulta_Load(object sender, EventArgs e)
        {
            CompletaEventos.Completa += new CompletaEventos.CompletaAccion(CompletaEventos_Completa);
            CargarDatos();
        }

        private void FrmConsulta_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnNuevoPlantilla_Click(object sender, EventArgs e)
        {
            var frmPlantilla = new FrmNuevaPlantilla();
            this.Transfer = true;
            frmPlantilla.ShowDialog();
        }

        private void CargarDatos()
        {
            try
            {
                this.dgPlantillas.AutoGenerateColumns = false;
                this.dgPlantillas.DataSource = miBussinesPlantilla.Plantillas();
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
                if (this.Transfer)
                {
                    var obj = (ObjectAbstract)args.MiObjeto;
                    if (obj.Id.Equals(240))
                    {
                        CargarDatos();
                        this.Transfer = false;
                    }
                }
            }
            catch { }
        }
    }
}