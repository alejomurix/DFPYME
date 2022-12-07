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

namespace Aplicacion.Administracion.Puntos
{
    public partial class frmPuntos : Form
    {
        private Punto miPunto;

        public BussinesPunto miBussinesPunto;

        private ErrorProvider er;

        private bool ventaminima = false;

        private bool numeropunto = false;
        
        private bool valorpunto = false;

        public frmPuntos()
        {
            InitializeComponent();
            this.er = new ErrorProvider();
            this.miBussinesPunto = new BussinesPunto();
        }

        private void frmPuntos_Load(object sender, EventArgs e)
        {
            CargaPunto();
        }
        
        private void frmPuntos_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData.Equals(Keys.Escape))
            {
                this.Close();
            }
        }

        private void txtVentaMinima_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar.Equals((char)Keys.Enter))
            {
                this.txtNumeroPuntos.Focus();
            }
        }

        private void txtVentaMinima_Validating(object sender, CancelEventArgs e)
        {
            if (!Validacion.EsVacio(this.txtVentaMinima, this.er, "El campo es requerido."))
            {
                if (Validacion.ConFormato(Validacion.TipoValidacion.Numeros, this.txtVentaMinima, this.er, "El número que ingreso es incorrecto."))
                {
                    this.ventaminima = true;
                }
                else
                {
                    this.ventaminima = false;
                }
            }
            else
            {
                this.ventaminima = false;
            }
        }

        private void txtNumeroPuntos_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar.Equals((char)Keys.Enter))
            {
                this.txtValorPuntos.Focus();
            }
        }

        private void txtValorPuntos_Validating(object sender, CancelEventArgs e)
        {
            if (!Validacion.EsVacio(this.txtVentaMinima, this.er, "El campo es requerido."))
            {
                if (Validacion.ConFormato(Validacion.TipoValidacion.Numeros, this.txtValorPuntos, this.er, "El número que ingreso es incorrecto."))
                {
                    this.valorpunto = true;
                }
                else
                {
                    this.valorpunto = false;
                }
            }
            else
            {
                this.valorpunto = false;
            }
        }

        private void txtValorPuntos_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar.Equals((char)Keys.Enter))
            {
                this.btnOk_Click(this.btnOk, new EventArgs());
            }
        }

        private void txtNumeroPuntos_Validating(object sender, CancelEventArgs e)
        {
            if (!Validacion.EsVacio(this.txtNumeroPuntos, this.er, "El campo es requerido."))
            {
                if (Validacion.ConFormato(Validacion.TipoValidacion.Numeros, this.txtNumeroPuntos, this.er, "El número que ingreso es incorrecto."))
                {
                    this.numeropunto = true;
                }
                else
                {
                    this.numeropunto = false;
                }
            }
            else
            {
                this.numeropunto = false;
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            this.txtVentaMinima_Validating(this.txtVentaMinima, new CancelEventArgs());
            this.txtValorPuntos_Validating(this.txtValorPuntos, new CancelEventArgs());
            this.txtNumeroPuntos_Validating(this.txtNumeroPuntos, new CancelEventArgs());

            if (this.numeropunto && this.valorpunto && this.ventaminima)
            {
                DialogResult r = MessageBox.Show("¿Desea guardar los cambios?", "Puntos",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (r.Equals(DialogResult.Yes))
                {
                    try
                    {
                        this.miBussinesPunto.ModificaPunto(new Punto
                        {
                            IdPuntos = this.miPunto.IdPuntos,
                            ValorVentaMinPunto = Convert.ToInt32(txtVentaMinima.Text),
                            NumeroPuntos = Convert.ToDouble(txtNumeroPuntos.Text),
                            ValorPunto = Convert.ToDouble(txtValorPuntos.Text),
                            EstadoPunto = this.chkAplicar.Checked
                        });
                        OptionPane.MessageInformation("Los datos se almacenaron con éxito.");
                        this.txtVentaMinima.Focus();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CargaPunto()
        {
            try
            {
                this.miPunto = miBussinesPunto.CargarPunto();
                this.txtVentaMinima.Text = this.miPunto.ValorVentaMinPunto.ToString();
                this.txtNumeroPuntos.Text = this.miPunto.NumeroPuntos.ToString();
                this.txtValorPuntos.Text = this.miPunto.ValorPunto.ToString();
                this.chkAplicar.Checked = this.miPunto.EstadoPunto;
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
        }
    }
}