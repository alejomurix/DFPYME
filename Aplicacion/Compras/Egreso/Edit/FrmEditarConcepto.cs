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
    public partial class FrmEditarConcepto : Form
    {
        public int IdConcepto { set; get; }

        public string Concepto { set; get; }

        public string Valor { set; get; }

        private ErrorProvider miError;

        private BussinesCuentaPuc miBussinesCuentaPuc;

        public FrmEditarConcepto()
        {
            InitializeComponent();
            this.miError = new ErrorProvider();
            miBussinesCuentaPuc = new BussinesCuentaPuc();
        }

        private void FrmEditarConcepto_Load(object sender, EventArgs e)
        {
            this.txtConcepto.Text = this.Concepto;
            this.txtValor.Text = UseObject.InsertSeparatorMil(this.Valor);
        }

        private void FrmEditarConcepto_KeyDown(object sender, KeyEventArgs e)
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

        private void tsBtnGuardar_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(this.txtConcepto.Text))
            {
                miError.SetError(this.txtConcepto, null);
                if (!String.IsNullOrEmpty(this.txtValor.Text))
                {
                    miError.SetError(this.txtValor, null);
                    try
                    {
                        miBussinesCuentaPuc.EditarEgresoCuenta(new ConceptoEgreso
                        {
                            Id = this.IdConcepto,
                            Nombre = this.txtConcepto.Text,
                            Numero = UseObject.RemoveSeparatorMil(this.txtValor.Text).ToString()
                        });
                        OptionPane.MessageInformation("El concepto se edito con exito.");
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
                else
                {
                    miError.SetError(this.txtValor, "El valor es requerido.");
                }
            }
            else
            {
                miError.SetError(this.txtConcepto, "El concepto es requerido.");
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
                this.txtValor.Focus();
            }
        }

        private void txtValor_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar.Equals((char)Keys.Enter))
            {
                this.tsBtnGuardar_Click(this.tsBtnGuardar, new EventArgs());
            }
        }
    }
}