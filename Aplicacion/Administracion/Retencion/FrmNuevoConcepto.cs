using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Utilities;
using BussinesLayer.Clases;

namespace Aplicacion.Administracion.Retencion
{
    public partial class FrmNuevoConcepto : Form
    {
        public int IdRubro { set; get; }

        private ErrorProvider miError;

        private bool ConceptoMatch;

        private bool CifraUVT;

        private bool CifraPesos;

        private bool Tarifa;

        private BussinesRetencion miBussinesRetencion;

        public FrmNuevoConcepto()
        {
            InitializeComponent();
            IdRubro = 0;
            miError = new ErrorProvider();
            ConceptoMatch = false;
            CifraUVT = false;
            CifraPesos = false;
            Tarifa = false;
            miBussinesRetencion = new BussinesRetencion();
        }

        private void FrmNuevoConcepto_KeyDown(object sender, KeyEventArgs e)
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
                this.txtCifraUvt.Focus();
            }
        }

        private void txtConcepto_Validating(object sender, CancelEventArgs e)
        {
            if (!Validacion.EsVacio(txtConcepto, miError, "El campo es requerido."))
            {
                ConceptoMatch = true;
            }
            else
            {
                ConceptoMatch = false;
            }
        }

        private void txtCifraUvt_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar.Equals((char)Keys.Enter))
            {
                this.txtCifraPesos.Focus();
            }
        }

        private void txtCifraUvt_Validating(object sender, CancelEventArgs e)
        {
            if (!Validacion.EsVacio(txtCifraUvt, miError, "El campo es requerido."))
            {
                if (Validacion.ConFormato(Validacion.TipoValidacion.NumerosYPunto, txtCifraUvt, miError, "El valor que ingreso e incorrecto"))
                {
                    CifraUVT = true;
                }
                else
                {
                    CifraUVT = false;
                }
            }
            else
            {
                Tarifa = false;
            }
        }

        private void txtCifraPesos_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar.Equals((char)Keys.Enter))
            {
                this.txtTarifa.Focus();
            }
        }

        private void txtCifraPesos_Validating(object sender, CancelEventArgs e)
        {
            if (!Validacion.EsVacio(txtCifraPesos, miError, "El campo es requerido."))
            {
                if (Validacion.ConFormato(Validacion.TipoValidacion.NumerosYPunto, txtCifraPesos, miError, "El valor que ingreso e incorrecto"))
                {
                    CifraPesos = true;
                }
                else
                {
                    CifraPesos = false;
                }
            }
            else
            {
                CifraPesos = false;
            }
        }

        private void txtTarifa_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar.Equals((char)Keys.Enter))
            {
                this.btnOk.Focus();
            }
        }

        private void txtTarifa_Validating(object sender, CancelEventArgs e)
        {
            if (!Validacion.EsVacio(txtTarifa, miError, "El campo es requerido."))
            {
                if (Validacion.ConFormato(Validacion.TipoValidacion.NumerosYPunto, txtTarifa, miError, "El valor que ingreso e incorrecto"))
                {
                    Tarifa = true;
                }
                else
                {
                    Tarifa= false;
                }
            }
            else
            {
                Tarifa = false;
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            txtConcepto_Validating(this.txtConcepto, new CancelEventArgs(false));
            txtCifraUvt_Validating(this.txtCifraUvt, new CancelEventArgs(false));
            txtCifraPesos_Validating(this.txtCifraPesos, new CancelEventArgs(false));
            txtTarifa_Validating(this.txtTarifa, new CancelEventArgs(false));
            if (ConceptoMatch && CifraUVT && CifraPesos && Tarifa)
            {
                miBussinesRetencion.IngresarConcepto(
                    new DTO.Clases.RetencionConcepto
                    {
                        Id = IdRubro,
                        Concepto = txtConcepto.Text,
                        CifraUVT = Convert.ToDouble(txtCifraUvt.Text),
                        CifraPesos = Convert.ToDouble(txtCifraPesos.Text),
                        Tarifa = Convert.ToDouble(txtTarifa.Text.Replace('.', ','))
                    });
                CompletaEventos.CapturaEventoz(20);
                this.Close();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}