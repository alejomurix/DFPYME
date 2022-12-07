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

namespace Aplicacion.Administracion.Puntos
{
    public partial class FrmCanje : Form
    {
        private bool CanjeMatch;

        private bool ConceptoMatch;

        private ErrorProvider miError;

        private Punto miPunto;

        private BussinesCliente miBussinesCliente;

        private BussinesPunto miBussinesPunto;

        public FrmCanje()
        {
            InitializeComponent();
            try
            {
                this.CanjeMatch = false;
                this.ConceptoMatch = false;
                this.miError = new ErrorProvider();
                this.miBussinesCliente = new BussinesCliente();
                this.miBussinesPunto = new BussinesPunto();

                this.miPunto = this.miBussinesPunto.CargarPunto();
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
        }

        private void FrmCanje_Load(object sender, EventArgs e)
        {
        }

        private void FrmCanje_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData.Equals((char)Keys.Escape))
            {
                this.Close();
            }
        }

        private void txtCanje_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar.Equals((char)Keys.Enter))
            {
                this.txtConcepto.Focus();
                //this.btnOk_Click(this.btnOk, new EventArgs());
            }
        }

        private void txtCanje_Validating(object sender, CancelEventArgs e)
        {
            if (String.IsNullOrEmpty(this.txtCanje.Text))
            {
                this.miError.SetError(this.txtCanje, "El campo es requerido.");
                this.CanjeMatch = false;
            }
            else
            {
                if (Validacion.ValidarEntero(this.txtCanje.Text))
                {
                    if (Convert.ToInt64(this.txtCanje.Text) <=
                        Convert.ToInt64(UseObject.RemoveSeparatorMil(this.txtPuntos.Text)))
                    {
                        this.miError.SetError(this.txtCanje, null);
                        this.CanjeMatch = true;
                    }
                    else
                    {
                        this.miError.SetError(this.txtCanje, "El valor del canje no debe ser superior al de los puntos.");
                        this.CanjeMatch = false;
                    }
                }
                else
                {
                    this.miError.SetError(this.txtCanje, "El valor es incorrecto.");
                    this.CanjeMatch = false;
                }
            }
        }

        private void txtConcepto_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar.Equals((char)Keys.Enter))
            {
                //this.txtConcepto.Focus();
                this.btnOk_Click(this.btnOk, new EventArgs());
            }
        }

        private void txtConcepto_Validating(object sender, CancelEventArgs e)
        {
            if (String.IsNullOrEmpty(this.txtConcepto.Text))
            {
                this.miError.SetError(this.txtConcepto, "El campo es requerido.");
                this.ConceptoMatch = false;
            }
            else
            {
                this.miError.SetError(this.txtConcepto, null);
                this.ConceptoMatch = true;
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            // validacion
            this.txtCanje_Validating(this.txtCanje, new CancelEventArgs());
            this.txtConcepto_Validating(this.txtConcepto, new CancelEventArgs());
            if (this.CanjeMatch && ConceptoMatch)
            {
                this.txtConcepto.Text = this.txtConcepto.Text.ToUpper();
                var frmConfirmarCanje = new FrmConfirmarCanje();
                frmConfirmarCanje.txtPuntos.Text = UseObject.InsertSeparatorMil(this.txtCanje.Text);
                DialogResult rta = frmConfirmarCanje.ShowDialog();
                if (rta.Equals(DialogResult.Yes))
                {
                    try
                    {
                        var canje = new Canje();
                        canje.NitCliente = this.txtNit.Text;
                        canje.Fecha = DateTime.Now;
                        canje.Concepto = this.txtConcepto.Text;
                        canje.PuntosAntes = Convert.ToInt64(UseObject.RemoveSeparatorMil(this.txtPuntos.Text));
                        canje.Puntos = Convert.ToInt64(this.txtCanje.Text);
                        canje.Valor_ = Convert.ToInt64(canje.Puntos * this.miPunto.ValorPunto);
                        this.miBussinesCliente.InsertarCanje(canje);
                        this.miBussinesCliente.EditarPuntos(canje.NitCliente, (canje.PuntosAntes - canje.Puntos));
                        OptionPane.MessageInformation("El canje de puntos se realizo con éxito.");
                        CompletaEventos.CapturaEvento(new ObjectAbstract { Id = 232 });
                        this.Close();
                    }
                    catch (Exception ex)
                    {
                        OptionPane.MessageError(ex.Message);
                    }
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}