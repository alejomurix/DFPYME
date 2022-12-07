using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CustomControl;
using BussinesLayer.Clases;
using Utilities;

namespace Aplicacion.Administracion.Caja
{
    public partial class FrmEditarRetiro : Form
    {
        public int Id { set; get; }

        private BussinesRetiro miBussinesRetiro;

        private ErrorProvider miError;

        public FrmEditarRetiro()
        {
            InitializeComponent();
            this.miBussinesRetiro = new BussinesRetiro();
            this.miError = new ErrorProvider();
        }

        private void FrmEditarRetiro_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData.Equals(Keys.Escape))
            {
                this.Close();
            }
        }

        private void FrmEditarRetiro_FormClosing(object sender, FormClosingEventArgs e)
        {

        }

        private void txtRetiro_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar.Equals((char)Keys.Enter))
            {
                if (!String.IsNullOrEmpty(this.txtRetiro.Text))
                {
                    if (ValidarInt(this.txtRetiro.Text))
                    {
                        this.miError.SetError(this.txtRetiro, null);
                        DialogResult rta = MessageBox.Show("¿Está seguro(a) de guardar el valor del retiro?", "Edición de retiro",
                            MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (rta.Equals(DialogResult.Yes))
                        {
                            try
                            {
                                this.miBussinesRetiro.EditarRetiro(this.Id, Convert.ToInt32(this.txtRetiro.Text));
                                OptionPane.MessageInformation("El retiro se edito con éxito.");
                                CompletaEventos.CapturaEvento(new ObjectAbstract { Id = 98987 });
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
                        this.miError.SetError(this.txtRetiro, "El valor que ingreso es incorrecto.");
                    }
                }
                else
                {
                    this.miError.SetError(this.txtRetiro, "El campo no debe estar vacio.");
                }
            }
        }

        private bool ValidarInt(string numero)
        {
            var pass = false;
            try
            {
                Convert.ToInt32(numero);
                pass = true;
            }
            catch (FormatException)
            {
                pass = false;
            }
            return pass;
        }
    }
}