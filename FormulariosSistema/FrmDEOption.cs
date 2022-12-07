using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Utilities;

namespace FormulariosSistema
{
    public partial class FrmDEOption : Form
    {
        public bool Extend { set; get; }

        public int TransferValue { set; get; }

        private ErrorProvider Error;

        public FrmDEOption()
        {
            InitializeComponent();
            this.TransferValue = 0;
            this.Extend = false;
            this.Error = new ErrorProvider();
        }

        private void FrmDEOption_Load(object sender, EventArgs e)
        {
            this.txtValue.SelectAll();
        }

        private void FrmDEOption_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Escape))
            {
                this.Close();
            }
        }

        private void txtValue_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar.Equals((char)Keys.Enter))
            {
                if (!String.IsNullOrEmpty(this.txtValue.Text))
                {
                    if (ValidateDouble(this.txtValue.Text))
                    {
                        if (this.Extend)
                        {
                            this.Error.SetError(this.txtValue, null);
                            CompletaEventos.CapturaEvento(new
                            ObjectAbstract { Id = this.TransferValue, Objeto = this.txtValue.Text });
                            this.Close();
                        }
                    }
                    else
                    {
                        this.Error.SetError(this.txtValue, "El valor es incorrecto");
                    }
                }
                else
                {
                    this.Error.SetError(this.txtValue, "El valor no puede ser vacio.");
                }
            }
        }

        private bool ValidateDouble(string val)
        {
            var pass = false;
            try
            {
                Convert.ToDouble(val);
                pass = true;
            }
            catch (FormatException)
            {
                pass = false;
            }
            try
            {
                Convert.ToInt32(Convert.ToDouble(val));
                pass = true;
            }
            catch (OverflowException)
            {
                pass = false;
            }
            catch (FormatException)
            {
                pass = false;
            }
            return pass;
        }
    }
}