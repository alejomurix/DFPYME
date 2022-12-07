using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DTO.Clases;
using BussinesLayer.Clases;
using Utilities;
using CustomControl;

namespace Aplicacion.Compras.Egreso.Edit
{
    public partial class FrmEditarEgreso : Form
    {
        public int Id { set; get; }

        public DateTime Fecha { set; get; }

        public int IdTercero { set; get; }

        public string Numero { set; get; }

        private BussinesBeneficio miBussinesTercero;

        private BussinesEgreso miBussinesEgreso;

        public FrmEditarEgreso()
        {
            InitializeComponent();
            miBussinesTercero = new BussinesBeneficio();
            miBussinesEgreso = new BussinesEgreso();
        }

        private void FrmEditarEgreso_Load(object sender, EventArgs e)
        {
            this.dtpFecha.Value = this.Fecha;
            try
            {
                var tercero = miBussinesTercero.BeneficiarioId(IdTercero);
                this.lblNumero.Text = this.Numero;
                this.txtNombre.Text = "NIT o C.C. " + tercero.NitCliente + "  " + tercero.NombresCliente;
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
            CompletaEventos.Completa += new CompletaEventos.CompletaAccion(CompletaEventos_Completa);
        }

        private void FrmEditarEgreso_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyData)
            {
                case Keys.F2:
                    {
                        this.tsBtnGuardar_Click(this.tsBtnGuardar, new EventArgs());
                        break;
                    }
                case Keys.Escape:
                    {
                        this.Close();
                        break;
                    }
            }
        }

        private void FrmEditarEgreso_FormClosing(object sender, FormClosingEventArgs e)
        {
            CompletaEventos.CapturaEventoz(false);
        }

        private void tsBtnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                miBussinesEgreso.EditarEgreso(new DTO.Clases.Egreso
                {
                    Id = this.Id,
                    TipoBeneficiario = this.IdTercero,
                    Fecha = this.dtpFecha.Value
                });
                OptionPane.MessageInformation("Los datos se editaron correctamente.");
                CompletaEventos.CapturaEventoz(new ObjectAbstract
                {
                    Id = 233
                });
                this.Close();
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

        private void btnBuscarTercero_Click(object sender, EventArgs e)
        {
            var frmBeneficio = new Beneficiario.FrmBeneficio();
            frmBeneficio.Edit = true;
            frmBeneficio.tcBeneficio.SelectTab(1);
            frmBeneficio.ShowDialog();
        }

        void CompletaEventos_Completa(CompletaArgumentosDeEvento args)
        {
            try
            {
                ObjectAbstract obj = (ObjectAbstract)args.MiObjeto;
                if (obj.Id.Equals(125))
                {
                    var tercero = (Cliente)obj.Objeto;
                    IdTercero = tercero.IdCiudad;
                    this.txtNombre.Text = "NIT C.C. " + tercero.NitCliente + "  " + tercero.NombresCliente;
                }
            }
            catch { }
        }
    }
}