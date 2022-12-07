using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BussinesLayer.Clases;
using DTO.Clases;
using Utilities;
using CustomControl;

namespace Aplicacion.Ventas.Ingresos
{
    public partial class FrmConceptoIngreso : Form
    {
        private ErrorProvider miError;

        private bool CodigoMatch = false;

        private bool NombreMatch = false;

        private BussinesOtroIngreso miBussinesConcepto;

        public FrmConceptoIngreso()
        {
            InitializeComponent();
            miError = new ErrorProvider();
            miBussinesConcepto = new BussinesOtroIngreso();
        }

        private void FrmConceptoIngreso_Load(object sender, EventArgs e)
        {
            try
            {
                this.txtRubro.Text = (this.miBussinesConcepto.MaxCodigo() + 1).ToString();
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
        }

        private void FrmConceptoIngreso_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData.Equals(Keys.Escape))
            {
                this.Close();
            }
        }

        private void txtRubro_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar.Equals((char)Keys.Enter))
            {
                txtNombre.Focus();
            }
        }

        private void txtRubro_Validating(object sender, CancelEventArgs e)
        {
            if (!Validacion.EsVacio(txtRubro, miError, "El campo del Código es requerido."))
            {
                if (Validacion.ConFormato
                    (Validacion.TipoValidacion.Numeros, txtRubro, miError, "El Código que ingreso es invalido."))
                {
                    CodigoMatch = true;
                }
                else
                {
                    CodigoMatch = false;
                }
            }
            else
            {
                CodigoMatch = false;
            }
        }

        private void txtNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar.Equals((char)Keys.Enter))
            {
                btnOk.Focus();
            }
        }

        private void txtNombre_Validating(object sender, CancelEventArgs e)
        {
            if (!Validacion.EsVacio(txtNombre, miError, "El campo del Nombre es requerido."))
            {
                NombreMatch = true;
            }
            else
            {
                NombreMatch = false;
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            txtRubro_Validating(this.txtRubro, new CancelEventArgs(false));
            txtNombre_Validating(this.txtNombre, new CancelEventArgs(false));
            if (CodigoMatch && NombreMatch)
            {
                try
                {
                    var concepto = new ConceptoOtroIngreso
                        {
                            Codigo = Convert.ToInt32(txtRubro.Text),
                            Nombre = txtNombre.Text
                        };
                    miBussinesConcepto.AlmacenarConcepto(concepto);
                    CompletaEventos.CapturaEventoAdelanto(concepto);
                    this.Close();
                }
                catch (Exception ex)
                {
                    OptionPane.MessageError(ex.Message);
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}