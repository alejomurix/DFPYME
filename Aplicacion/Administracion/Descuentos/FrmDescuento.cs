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

namespace Aplicacion.Administracion.Descuentos
{
    public partial class FrmDescuento : Form
    {
        public int IdGrupo { set; get; }

        private bool Transfer { set; get; }

        private int IdCuenta { set; get; }

        private BussinesPuc miBussinesPuc;

        private BussinesAplicaDescuento miBussinesDescuento;

        private ErrorProvider miError;

        private bool CodigoMatch;

        private bool ConceptoMatch;

        private bool PorcentajeMatch;

        private bool ValorMatch;

        public FrmDescuento()
        {
            InitializeComponent();
            this.IdGrupo = 0;
            this.Transfer = false;
            this.IdCuenta = 0;
            this.miBussinesPuc = new BussinesPuc();
            this.miBussinesDescuento = new BussinesAplicaDescuento();
            this.miError = new ErrorProvider();
            this.CodigoMatch = false;
            this.ConceptoMatch = false;
            this.PorcentajeMatch = false;
            this.ValorMatch = false;
        }

        private void FrmDescuento_Load(object sender, EventArgs e)
        {
            CompletaEventos.Completa += new CompletaEventos.CompletaAccion(CompletaEventos_Completa);
        }

        private void FrmDescuento_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData.Equals(Keys.Escape))
            {
                this.Close();
            }
        }

        private void txtCodigo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar.Equals((char)Keys.Enter))
            {
                this.txtConcepto.Focus();
            }
        }

        private void txtCodigo_Validating(object sender, CancelEventArgs e)
        {
            if (!String.IsNullOrEmpty(this.txtCodigo.Text))
            {
                this.miError.SetError(this.txtCodigo, null);
                this.CodigoMatch = true;
            }
            else
            {
                this.miError.SetError(this.txtCodigo, "El campo es requerido.");
                this.CodigoMatch = false;
            }
        }

        private void txtConcepto_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar.Equals((char)Keys.Enter))
            {
                this.btnBuscar.Focus();
            }
        }

        private void txtConcepto_Validating(object sender, CancelEventArgs e)
        {
            if (!String.IsNullOrEmpty(this.txtConcepto.Text))
            {
                this.miError.SetError(this.txtConcepto, null);
                this.ConceptoMatch = true;
                this.txtConcepto.Text = this.txtConcepto.Text.ToUpper();
            }
            else
            {
                this.miError.SetError(this.txtConcepto, "El campo es requerido.");
                this.ConceptoMatch = false;
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            var frmPuc = new Puc.FrmConsultaPucUtil();
            frmPuc.Extend = true;
            this.Transfer = true;
            frmPuc.ShowDialog();
        }

        private void txtPorcejante_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar.Equals((char)Keys.Enter))
            {
                this.txtValor.Focus();
            }
        }

        private void txtPorcejante_Validating(object sender, CancelEventArgs e)
        {
            if (!String.IsNullOrEmpty(this.txtPorcejante.Text))
            {
                this.miError.SetError(this.txtPorcejante, null);
                this.PorcentajeMatch = true;
            }
            else
            {
                this.miError.SetError(this.txtPorcejante, "El campo es requerido.");
                this.PorcentajeMatch = false;
            }
        }

        private void txtValor_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar.Equals((char)Keys.Enter))
            {
                this.btnAceptar.Focus();
            }
        }

        private void txtValor_Validating(object sender, CancelEventArgs e)
        {
            if (!String.IsNullOrEmpty(this.txtValor.Text))
            {
                this.miError.SetError(this.txtValor, null);
                this.ValorMatch = true;
            }
            else
            {
                this.miError.SetError(this.txtValor, "El campo es requerido.");
                this.ValorMatch = false;
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (!this.IdCuenta.Equals(0))
            {
                this.miError.SetError(this.txtCuenta, null);
                this.txtCodigo_Validating(this.txtCodigo, new CancelEventArgs(false));
                this.txtConcepto_Validating(this.txtConcepto, new CancelEventArgs(false));
                this.txtPorcejante_Validating(this.txtPorcejante, new CancelEventArgs(false));
                this.txtValor_Validating(this.txtValor, new CancelEventArgs(false));
                if (this.CodigoMatch && this.ConceptoMatch && this.PorcentajeMatch && this.ValorMatch)
                {
                    try
                    {
                        var descuento = new AplicaDescuento();
                        descuento.IdGrupo = this.IdGrupo;
                        descuento.Codigo = this.txtCodigo.Text;
                        descuento.Concepto = this.txtConcepto.Text;
                        descuento.IdCuenta = this.IdCuenta;
                        descuento.Porcentaje = Convert.ToDouble(this.txtPorcejante.Text.Replace('.', ','));
                        descuento.Valor = Convert.ToInt32(this.txtValor.Text);
                        if (this.rbtnAplicaPorcentaje.Checked)
                        {
                            descuento.Aplica = true;
                        }
                        else
                        {
                            descuento.Aplica = false;
                        }
                        miBussinesDescuento.Ingresar(descuento);
                        OptionPane.MessageInformation("El descuento se ingresó con éxito.\n");
                        CompletaEventos.CapturaEvento(new ObjectAbstract { Id = 235 });
                        this.Close();
                    }
                    catch (Exception ex)
                    {
                        OptionPane.MessageError(ex.Message);
                    }
                }
            }
            else
            {
                this.miError.SetError(this.txtCuenta, "Debe cargar una cuenta.");
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        void CompletaEventos_Completa(CompletaArgumentosDeEvento args)
        {
            try
            {
                if (this.Transfer)
                {
                    var obj = (ObjectAbstract)args.MiObjeto;
                    if (obj.Id.Equals(650))
                    {
                        this.txtCuenta.Text = (string)obj.Objeto;
                        //this.txtCuenta_KeyPress(this.txtCuenta, new KeyPressEventArgs((char)Keys.Enter));
                        this.IdCuenta = miBussinesPuc.Cuenta(this.txtCuenta.Text).Id;
                        this.txtPorcejante.Focus();
                    }
                    this.Transfer = false;
                }
            }
            catch { }
        }
    }
}