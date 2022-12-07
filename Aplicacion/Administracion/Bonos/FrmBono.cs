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

namespace Aplicacion.Administracion.Bonos
{
    public partial class FrmBonos : Form
    {
        private Marca miMarca;


        private BussinesMarca miBussinesMarca;

        private BussinesBonoRifa miBussinesBonoRifa;

        private ErrorProvider miError;

        private bool NumSorteo = false;

        private bool VentaMin = false;

        

       // private bool numeropunto = false;
        
       // private bool valorpunto = false;

        public FrmBonos()
        {
            InitializeComponent();
            this.miMarca = new Marca();

            this.miBussinesMarca = new BussinesMarca();
            this.miBussinesBonoRifa = new BussinesBonoRifa();
            this.miError = new ErrorProvider();
        }

        private void FrmBonos_Load(object sender, EventArgs e)
        {
            CompletaEventos.Completam += new CompletaEventos.CompletaAccionm(CompletaEventosm_Completo);
            this.dgvBonos.AutoGenerateColumns = false;
            this.CargarBonos();
        }

        private void FrmBonos_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData.Equals(Keys.Escape))
            {
                this.Close();
            }
        }
        
        /*private void frmPuntos_Load(object sender, EventArgs e)
        {
            CargaPunto();
        }
        
        private void frmPuntos_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData.Equals(Keys.Escape))
            {
                this.Close();
            }
        }*/


        private void txtNoSorteo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar.Equals((char)Keys.Enter))
            {
                this.txtVentaMinima.Focus();
            }
        }

        private void txtNoSorteo_Validating(object sender, CancelEventArgs e)
        {
            if (!Validacion.EsVacio(this.txtNoSorteo, this.miError, "El campo es requerido."))
            {
                this.NumSorteo = true;
            }
            else
            {
                this.NumSorteo = false;
            }
        }

        private void txtVentaMinima_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar.Equals((char)Keys.Enter))
            {
                this.chkAplicar.Focus();
                //this.btnGuardar.Focus();
            }
        }

        private void txtVentaMinima_Validating(object sender, CancelEventArgs e)
        {
            if (!Validacion.EsVacio(this.txtVentaMinima, this.miError, "El campo es requerido."))
            {
                if (Validacion.ConFormato(Validacion.TipoValidacion.Numeros, this.txtVentaMinima, this.miError, "El número que ingreso es incorrecto."))
                {
                    this.VentaMin = true;
                }
                else
                {
                    this.VentaMin = false;
                }
            }
            else
            {
                this.VentaMin = false;
            }
        }

        private void chkAplicar_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar.Equals((char)Keys.Enter))
            {
                this.txtNota.Focus();
            }
        }

        private void chkAplicar_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                this.miBussinesBonoRifa.EditarEstado(this.chkAplicar.Checked);
                /*if (this.chkAplicar.Checked)
                {
                    OptionPane.MessageInformation("Si");
                }
                else
                {
                    OptionPane.MessageInformation("No");
                }*/
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
        }

        private void txtNota_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar.Equals((char)Keys.Enter))
            {
                this.btnGuardar.Focus();
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                this.txtNoSorteo_Validating(this.txtNoSorteo, null);
                this.txtVentaMinima_Validating(this.txtVentaMinima, null);
                if (this.NumSorteo && this.VentaMin)
                {
                    DialogResult rta = MessageBox.Show("¿Está seguro de crear el sorteo? ", "Sorteos",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (rta.Equals(DialogResult.Yes))
                    {
                        var bonoRifa = new Bono();
                        bonoRifa.Numero = this.txtNoSorteo.Text;
                        bonoRifa.Fecha = this.dtpFecha.Value;
                        bonoRifa.Valor = Convert.ToInt32(this.txtVentaMinima.Text);
                        bonoRifa.Canje = this.chkAplicar.Checked;
                        bonoRifa.Concepto = this.txtNota.Text;
                        this.miBussinesBonoRifa.Ingresar(bonoRifa);
                        this.CargarBonos();
                        
                        this.txtNoSorteo.Focus();
                        this.txtNoSorteo.Text = "";
                        this.dtpFecha.Value = DateTime.Now;
                        this.txtVentaMinima.Text = "";
                        this.txtNota.Text = "";
                        OptionPane.MessageInformation("Los datos del bono se almacenaron con exito.");
                    }
                }
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
        }

        private void dgvBonos_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (this.dgvBonos.IsCurrentCellDirty)
            {
                this.dgvBonos.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        private void dgvBonos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (this.dgvBonos.Rows.Count > 0)
                {
                    this.dgvMarcas.DataSource = this.miBussinesBonoRifa.MarcasDeBono(Convert.ToInt32(this.dgvBonos.CurrentRow.Cells["Id"].Value));
                }
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
        }

        private void btnEliminarBono_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.dgvBonos.Rows.Count > 0)
                {
                    if (!(this.dgvMarcas.Rows.Count > 0))
                    {
                        DialogResult rta = MessageBox.Show("¿Está seguro de eliminar el sorteo? ", "Sorteos",
                            MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (rta.Equals(DialogResult.Yes))
                        {
                            this.miBussinesBonoRifa.Eliminar(Convert.ToInt32(this.dgvBonos.CurrentRow.Cells["Id"].Value));
                            this.CargarBonos();
                            OptionPane.MessageInformation("El bono se eliminó con éxito.");
                        }
                    }
                    else
                    {
                        OptionPane.MessageInformation("Debe primero eliminar las marcas de este sorteo.");
                    }
                }
                else
                {
                    OptionPane.MessageInformation("No hay sorteos para eliminar.");
                }
            }
            catch (Exception ex)
            {
                OptionPane.MessageInformation(ex.Message);
            }
        }






        private void CargarBonos()
        {
            try
            {
                this.dgvBonos.DataSource = this.miBussinesBonoRifa.BonosRifa();
                this.chkAplicar.Checked = this.miBussinesBonoRifa.BonoRifa().Canje;

                if (this.dgvBonos.Rows.Count > 0)
                {
                    this.dgvMarcas.DataSource = this.miBussinesBonoRifa.MarcasDeBono(Convert.ToInt32(this.dgvBonos.CurrentRow.Cells["Id"].Value));
                }
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
                        try
                        {
                            var marca = this.miBussinesMarca.Marca(Convert.ToInt32(this.txtCodigoMarca.Text));
                            if (!marca.NombreMarca.Equals(""))
                            {
                                this.miMarca.IdMarca = marca.IdMarca;
                                this.txtMarca.Text = this.miMarca.NombreMarca = marca.NombreMarca;
                                this.txtCodigoMarca.Text = "";
                                this.btnAceptar.Focus();
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
                        this.btnAceptar.Focus();
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
            this.btnAceptar.Focus();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.dgvBonos.Rows.Count > 0)
                {
                    if (this.miMarca.IdMarca != 0)
                    {
                        DialogResult rta = MessageBox.Show("¿Está seguro de agregar la marca? ", "Sorteos",
                            MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (rta.Equals(DialogResult.Yes))
                        {
                            this.miBussinesBonoRifa.IngresarMarcaDeBono
                                (Convert.ToInt32(this.dgvBonos.CurrentRow.Cells["Id"].Value), this.miMarca.IdMarca);
                            this.dgvMarcas.DataSource = 
                                this.miBussinesBonoRifa.MarcasDeBono(Convert.ToInt32(this.dgvBonos.CurrentRow.Cells["Id"].Value));
                            OptionPane.MessageInformation("La marca se agregó con éxito.");
                            this.txtCodigoMarca.Focus();
                            this.miMarca = new Marca();
                            this.txtCodigoMarca.Text = "";
                            this.txtMarca.Text = "";
                        }
                    }
                    else
                    {
                        this.miError.SetError(this.txtMarca, "Debe cargar una marca.");
                    }
                }
                else
                {
                    this.miError.SetError(this.dgvBonos, "Debe cargar al menos un sorteo.");
                }
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
        }

        private void btnEliminarMarca_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.dgvMarcas.Rows.Count > 0)
                {
                    DialogResult rta = MessageBox.Show("¿Está seguro de eliminar la marca? ", "Sorteos",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (rta.Equals(DialogResult.Yes))
                    {
                        this.miBussinesBonoRifa.EliminarMarcaDeBono(Convert.ToInt32(this.dgvMarcas.CurrentRow.Cells["IdBonoRifaMarca"].Value));
                        OptionPane.MessageInformation("La marca se eliminó con éxito.");
                        this.dgvMarcas.DataSource = 
                            this.miBussinesBonoRifa.MarcasDeBono(Convert.ToInt32(this.dgvBonos.CurrentRow.Cells["Id"].Value));
                    }
                }
                else
                {
                    OptionPane.MessageInformation("No hay marcas para eliminar.");
                }


                /*if (this.dgvBonos.Rows.Count > 0)
                {
                    if (this.miMarca.IdMarca != 0)
                    {
                        DialogResult rta = MessageBox.Show("¿Está seguro de agregar la marca? ", "Sorteos",
                            MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (rta.Equals(DialogResult.Yes))
                        {
                            this.miBussinesBonoRifa.IngresarMarcaDeBono
                                (Convert.ToInt32(this.dgvBonos.CurrentRow.Cells["Id"].Value), this.miMarca.IdMarca);
                            OptionPane.MessageInformation("La marca se agregó con éxito.");
                            this.txtCodigoMarca.Focus();
                            this.miMarca = new Marca();
                            this.txtCodigoMarca.Text = "";
                            this.txtMarca.Text = "";
                        }
                    }
                    else
                    {
                        this.miError.SetError(this.txtMarca, "Debe cargar una marca.");
                    }
                }
                else
                {
                    this.miError.SetError(this.dgvBonos, "Debe cargar al menos un sorteo.");
                }*/
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
                this.txtCodigoMarca.Text = m.IdMarca.ToString();
                this.txtCodigoMarca_KeyPress(this.txtCodigoMarca, new KeyPressEventArgs((char)Keys.Enter));
                //this.txtMarca.Text = m.NombreMarca;
            }
            catch { }
        }
        
    }
}