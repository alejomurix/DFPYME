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
using Utilities;
using DTO.Clases;

namespace Aplicacion.Administracion.Iva
{
    public partial class FrmAjuste : Form
    {
        private BussinesIva miBussinesIva;

        private BussinesCategoria miBussinesCategoria;

        private string codigoCategoria;

        private ErrorProvider miError;

        public FrmAjuste()
        {
            InitializeComponent();
            this.codigoCategoria = "";
            this.miError = new ErrorProvider();
            this.miBussinesIva = new BussinesIva();
            this.miBussinesCategoria = new BussinesCategoria();
        }

        private void FrmAjuste_Load(object sender, EventArgs e)
        {
            try
            {
                CompletaEventos.Completam += new CompletaEventos.CompletaAccionm(CompletaEventosm_Completo);
                this.cbIva.DataSource = miBussinesIva.ListadoIva();
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
        }

        private void FrmAjuste_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData.Equals(Keys.Escape))
            {
                this.Close();
            }
        }

        private void tsbSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtCodigoCategoria_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                if (!String.IsNullOrEmpty(txtCodigoCategoria.Text))
                {
                    if (CodigoOString(txtCodigoCategoria.Text))
                    {
                        CargarCategoria(txtCodigoCategoria.Text);
                    }
                    else
                    {
                        var frmCategoria = new Inventario.Categoria.FrmCategoriaNuevo();
                        frmCategoria.Extension = true;
                        frmCategoria.PressBoton = false;
                        frmCategoria.txtConsulta.Text = this.txtCodigoCategoria.Text;
                        DialogResult rta = frmCategoria.ShowDialog();
                        
                    }
                }
                else
                {
                    this.btnBuscar_Click(this.btnBuscar, new EventArgs());
                }
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            var frmCategoria = new Inventario.Categoria.FrmCategoriaNuevo();
            frmCategoria.Extension = true;
            frmCategoria.ShowDialog();
        }

        private void btnCambiar_Click(object sender, EventArgs e)
        {
            try
            {
                if (codigoCategoria != "")
                {
                    this.miError.SetError(this.txtCategoria, null);
                    this.miBussinesCategoria.CambiarIva(codigoCategoria, Convert.ToInt32(this.cbIva.SelectedValue));
                    OptionPane.MessageInformation(" El cambio se realizó con éxito.");
                    this.cbIva.SelectedIndex = 0;
                    this.codigoCategoria = "";
                    this.txtCodigoCategoria.Text = "";
                    this.txtCategoria.Text = "";
                }
                else
                {
                    this.miError.SetError(this.txtCategoria, "Debe cargar una categoria.");
                }
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
        }

        private void btnRestablecer_Click(object sender, EventArgs e)
        {
            try
            {
                if (codigoCategoria != "")
                {
                    this.miError.SetError(this.txtCategoria, null);
                    this.miBussinesCategoria.RestablecerIva(codigoCategoria);
                    OptionPane.MessageInformation(" El cambio se realizó con éxito.");
                    this.cbIva.SelectedIndex = 0;
                    this.codigoCategoria = "";
                    this.txtCodigoCategoria.Text = "";
                    this.txtCategoria.Text = "";
                }
                else
                {
                    this.miError.SetError(this.txtCategoria, "Debe cargar una categoria.");
                }
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
        }

        private bool CodigoOString(string codigo)
        {
            var num = true;
            try
            {
                Convert.ToInt64(codigo);
                num = true;
            }
            catch (FormatException)
            {
                num = false;
            }
            return num;
        }

        private void CargarCategoria(string codigo)
        {
            try
            {
                var arrCategoria = miBussinesCategoria.consultaCategoriaCodigo(codigo);
                if (arrCategoria.Count > 0)
                {
                    var categoria = (DTO.Clases.Categoria)arrCategoria[0];
                    codigoCategoria = categoria.CodigoCategoria;
                    txtCodigoCategoria.Text = categoria.CodigoCategoria;
                    txtCategoria.Text = categoria.NombreCategoria;
                }
                else
                {
                    OptionPane.MessageInformation("No existe Categoría con ese código.");
                }
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
        }

        void CompletaEventosm_Completo(CompletaArgumentosDeEventom args)
        {
            try
            {
                Categoria c = (Categoria)args.MiMarca;
                codigoCategoria = c.CodigoCategoria;
                txtCodigoCategoria.Text = c.CodigoCategoria;
                txtCategoria.Text = c.NombreCategoria;
            }
            catch{}
        }
    }
}