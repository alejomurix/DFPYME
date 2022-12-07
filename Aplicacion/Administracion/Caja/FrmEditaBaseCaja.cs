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

namespace Aplicacion.Administracion.Caja
{
    public partial class FrmEditaBaseCaja : Form
    {
        public int Id { set; get; }

        private BussinesApertura miBussinesCaja;

        private ErrorProvider miError;

        private bool AperturaMatch = false;

        private bool CierreMatch = false;

        public FrmEditaBaseCaja()
        {
            miBussinesCaja = new BussinesApertura();
            miError = new ErrorProvider();
            InitializeComponent();
        }

        private void FrmEditaBaseCaja_Load(object sender, EventArgs e)
        {
            CargarDatos();
        }

        private void FrmEditaBaseCaja_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult rta = MessageBox.Show("Está a punto de salir. ¿Desea guardar los cambios?", "Caja",
                MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);
            if (rta.Equals(DialogResult.Yes))
            {
                this.tsBtnGuardar_Click(this.tsBtnGuardar, new EventArgs());
            }
            else
            {
                if (rta.Equals(DialogResult.Cancel))
                {
                    e.Cancel = true;
                }
            }
        }

        private void tsBtnGuardar_Click(object sender, EventArgs e)
        {
            txtApertura_Validating(this.txtApertura, new CancelEventArgs(false));
            txtCierre_Validating(this.txtCierre, new CancelEventArgs(false));
            if (AperturaMatch && CierreMatch)
            {
                var caja = new Apertura();
                caja.Id = Id;
                caja.Fecha = dtpFecha.Value;
                //caja.Apertura = Convert.ToInt32(txtApertura.Text);
                caja.Cierre = Convert.ToInt32(txtCierre.Text);
                try
                {
                    DialogResult rta = MessageBox.Show("¿Está seguro(a) de guardar los cambios?", "Caja",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (rta.Equals(DialogResult.Yes))
                    {
                        if (!txtCierre.Text.Equals("0"))
                        {
                            DialogResult rta1 = MessageBox.Show("¿Está seguro(a) de realizar el Cierre?", "Caja",
                                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                            if (rta1.Equals(DialogResult.Yes))
                            {
                               // miBussinesCaja.Edita(caja);
                                OptionPane.MessageInformation("Los datos se editaron correctamente.");
                                if (caja.Cierre != 0)
                                {
                                   // AppConfiguracion.SaveConfiguration("id_base", "");
                                }
                            }
                        }
                        else
                        {
                            //miBussinesCaja.Edita(caja);
                            OptionPane.MessageInformation("Los datos se editaron correctamente.");
                        }
                    }
                }
                catch (Exception ex)
                {
                    OptionPane.MessageError(ex.Message);
                }
            }
        }

        private void tsBtnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnEditarFecha_Click(object sender, EventArgs e)
        {
            this.txtFecha.Visible = false;
            this.dtpFecha.Visible = true;
        }

        private void txtApertura_Validating(object sender, CancelEventArgs e)
        {
            if (!String.IsNullOrEmpty(txtApertura.Text))
            {
                if (Validacion.ConFormato
                    (Validacion.TipoValidacion.Numeros, txtApertura, miError, "El valor de la apertura tiene formato incorrecto."))
                {
                    AperturaMatch = true;
                }
                else
                {
                    AperturaMatch = false;
                }
            }
            else
            {
                txtApertura.Text = "0";
                AperturaMatch = true;
            }
        }

        private void txtCierre_Validating(object sender, CancelEventArgs e)
        {
            if (!String.IsNullOrEmpty(txtCierre.Text))
            {
                if (Validacion.ConFormato
                    (Validacion.TipoValidacion.Numeros, txtCierre, miError, "El valor del cierre tiene formato incorrecto."))
                {
                    CierreMatch = true;
                }
                else
                {
                    CierreMatch = false;
                }
            }
            else
            {
                txtCierre.Text = "0";
                CierreMatch = true;
            }
        }

        private void CargarDatos()
        {
            try
            {
                /*var caja = miBussinesCaja.Caja(Id);
                txtFecha.Text = caja.Fecha.ToLongDateString();
                dtpFecha.Value = caja.Fecha;
                //txtApertura.Text = caja.Apertura.ToString();
                txtCierre.Text = caja.Cierre.ToString();*/
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
        }

    }
}