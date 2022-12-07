using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using BussinesLayer.Clases;
using CustomControl;
using DTO.Clases;
using Utilities;

namespace Aplicacion.Ventas.Descuentos
{
    public partial class FrmDescuentosPorMarca : Form
    {
        private BussinesMarca miBussinesMarca;

        private BussinesProducto miBussinesProducto;

        private ErrorProvider miError;

        private Marca marca;

        private Thread miThread;

        private OptionPane miOption;

        public FrmDescuentosPorMarca()
        {
            InitializeComponent();
            this.dgvDescuentos.AutoGenerateColumns = false;
            this.miBussinesMarca = new BussinesMarca();
            this.miBussinesProducto = new BussinesProducto();
            this.miError = new ErrorProvider();
        }

        private void FrmDescuentosPorMarca_Load(object sender, EventArgs e)
        {
            CompletaEventos.Completam += new CompletaEventos.CompletaAccionm(CompletaEventosm_Completo);
            try
            {
                this.dgvDescuentos.DataSource = this.miBussinesMarca.MarcaDescuentos();
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
        }

        private void txtCodigoMarca_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                if (!String.IsNullOrEmpty(this.txtCodigoMarca.Text))
                {
                    if (this.CodigoOString(this.txtCodigoMarca.Text))
                    {
                        //CargarMarca(this.txtCodigoMarca.Text);
                        try
                        {
                            var marca = this.miBussinesMarca.Marca(Convert.ToInt32(this.txtCodigoMarca.Text));
                            if (!marca.NombreMarca.Equals(""))
                            {
                                //idMarca = Convert.ToInt32(marca.IdMarca);
                                //txtCodigoMarca.Text = marca.IdMarca.ToString();
                                this.txtNombreMarca.Text = marca.NombreMarca;
                                this.txtDescuento.Focus();
                            }
                            else
                            {
                                OptionPane.MessageInformation("No existe Marca con ese código.");
                            }
                        }
                        catch (Exception ex)
                        {
                            OptionPane.MessageError(ex.Message);
                        }
                    }
                    else
                    {
                        var frmMarca = new Configuracion.Marcas.FrmMarcaNuevo();
                        frmMarca.PressBoton = false;
                        frmMarca.txtConsulta.Text = this.txtCodigoMarca.Text;
                        frmMarca.Extension = true;
                        frmMarca.ShowDialog();
                        this.txtDescuento.Focus();
                    }
                }
                else
                {
                    this.btnBuscarMarca_Click(this.btnBuscarMarca, new EventArgs());
                }
            }
        }

        private void btnBuscarMarca_Click(object sender, EventArgs e)
        {
            var frmMarca = new Configuracion.Marcas.FrmMarcaNuevo();
            frmMarca.Extension = true;
            frmMarca.ShowDialog();
            this.txtDescuento.Focus();
        }

        private void txtDescuento_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar.Equals((char)Keys.Enter))
            {
                this.btnAgregar_Click(this.btnAgregar, new EventArgs());
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                if (ValidarDescuento(this.txtDescuento.Text))
                {
                    this.miError.SetError(this.txtDescuento, null);
                    DialogResult rta = MessageBox.Show("¿Esta seguro de guardar el descuento?", "Descuentos por marca",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (rta.Equals(DialogResult.Yes))
                    {

                        this.marca = new Marca
                                      {
                                          IdMarca = Convert.ToInt32(this.txtCodigoMarca.Text),
                                          Descuento = Convert.ToDouble(this.txtDescuento.Text.Replace('.', ','))
                                      };

                        this.miOption = new OptionPane();
                        this.miOption.FrmProgressBar.barraProgreso.Style = ProgressBarStyle.Marquee;
                        this.miOption.FrmProgressBar.Closed_ = true;
                        this.miOption.ProgressShow("Espere mientras se realizan las operaciones necesarias...",
                            "Operacion en progreso");
                        this.Enabled = false;
                        this.miThread = new Thread(CargarDescuento);
                        this.miThread.Start();

                        /*this.miBussinesMarca.IngresarDescuento(marca);
                        this.miBussinesMarca.AplicarDescuentoMarca(marca);*/


                        /*this.dgvDescuentos.DataSource = this.miBussinesMarca.MarcaDescuentos();
                        this.txtCodigoMarca.Focus();
                        this.txtCodigoMarca.Text = "";
                        this.txtNombreMarca.Text = "";
                        this.txtDescuento.Text = "";
                        OptionPane.MessageInformation("El descuento se agrego con éxito.");*/
                    }
                }
                else
                {
                    this.miError.SetError(this.txtDescuento, "El descuento no es valido.");
                }
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
        }

        public void CargarDescuento()
        {
            try
            {
                //this.miBussinesProducto.EliminarValorDeProducto();
                if (!(this.miBussinesProducto.CountValorDeProducto() > 0))
                {
                    this.miBussinesProducto.IngresarValorDeProducto();
                }
                //this.miBussinesProducto.IngresarValorDeProducto(this.marca.IdMarca);
                this.miBussinesMarca.IngresarDescuento(this.marca);
                this.miBussinesMarca.AplicarDescuentoMarca(this.marca);

                if (this.InvokeRequired)
                {
                    this.Invoke(new Action(FinalizarCargarDescuento));
                }
            }
            catch (Exception ex)
            {
                if (this.InvokeRequired)
                {
                    this.Invoke(new Action(FinalizarCargarDescuento));
                }
                OptionPane.MessageError(ex.Message);
            }
        }

        public void FinalizarCargarDescuento()
        {
            try
            {
                miOption.FrmProgressBar.barraProgreso.Style = ProgressBarStyle.Blocks;
                miOption.FrmProgressBar.Closed_ = false;
                miOption.FrmProgressBar.Close();
                this.Enabled = true;

                this.dgvDescuentos.DataSource = this.miBussinesMarca.MarcaDescuentos();
                this.txtCodigoMarca.Focus();
                this.txtCodigoMarca.Text = "";
                this.txtNombreMarca.Text = "";
                this.txtDescuento.Text = "";
                OptionPane.MessageInformation("El descuento se agrego con éxito.");
            }
            catch (Exception ex)
            {
                miOption.FrmProgressBar.barraProgreso.Style = ProgressBarStyle.Blocks;
                miOption.FrmProgressBar.Closed_ = false;
                miOption.FrmProgressBar.Close();
                this.Enabled = true;
                OptionPane.MessageError(ex.Message);
            }
        }

        private void tsBtnRestablecer_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult rta = MessageBox.Show("¿Esta seguro de restablecer los valores de venta?", "Descuentos por marca",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (rta.Equals(DialogResult.Yes))
                {
                    this.miBussinesProducto.RestablecerValor(Convert.ToInt32(this.dgvDescuentos.CurrentRow.Cells["IdMarca"].Value));
                    this.miBussinesMarca.EliminarDescuento(Convert.ToInt32(this.dgvDescuentos.CurrentRow.Cells["Id"].Value));
                    if (!(this.miBussinesMarca.CountDescuentoMarca() > 0))
                    {
                        this.miBussinesProducto.EliminarValorDeProducto();
                        this.miBussinesMarca.ReiniciarSecuenciaDescuento();
                    }
                   /* else
                    {
                        this.miBussinesProducto.EliminarValorDeProducto(Convert.ToInt32(this.dgvDescuentos.CurrentRow.Cells["IdMarca"].Value));
                    }*/
                   /* if (!(this.miBussinesProducto.CountValorDeProducto() > 0))
                    {
                        this.miBussinesProducto.ReiniciarSecuenciaProductoValor();
                    }*/
                    this.dgvDescuentos.DataSource = this.miBussinesMarca.MarcaDescuentos();
                    OptionPane.MessageInformation("Los valores de venta se restablecieron con éxito.");
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

        void CompletaEventosm_Completo(CompletaArgumentosDeEventom args)
        {
            try
            {
                TransferirMarca m = (TransferirMarca)args.MiMarca;
                //idMarca = Convert.ToInt32(m.IdMarca);
                txtCodigoMarca.Text = m.IdMarca.ToString();
                txtNombreMarca.Text = m.NombreMarca;
                //this.Extencion = false;
                //txtDescripcionProducto.Focus();
            }
            catch { }
        }

        private bool ValidarDescuento(string numero)
        {
            try
            {
                Convert.ToDouble(numero);
                return true;
            }
            catch
            {
                return false;
            }
        }

    }
}