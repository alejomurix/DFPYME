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

namespace Aplicacion.Configuracion.Marcas
{
    public partial class FrmMarcaNuevo : Form
    {
        public bool Extension { set; get; }

        public bool PressBoton { set; get; }

        private bool Editar { set; get; }

        private ErrorProvider miError;


        private BussinesMarca miBussinesMarca;

        public FrmMarcaNuevo()
        {
            InitializeComponent();
            this.Extension = false;
            this.PressBoton = true;
            this.Editar = false;
            this.miError = new ErrorProvider();

            this.miBussinesMarca = new BussinesMarca();
        }

        private void FrmMarcaNuevo_Load(object sender, EventArgs e)
        {
            try
            {
                if (miBussinesMarca.ListarMarcas().Count > 0)
                {
                    this.txtCodigo.Text = (this.miBussinesMarca.UltimoId() + 1).ToString();
                }
                else
                {
                    this.txtCodigo.Text = "1";
                }
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }

            if (this.Extension)
            {
                this.gbMarca.TabIndex = 1;
                this.gbConsulta.TabIndex = 0;
                this.txtConsulta.TabIndex = 1;
                this.dgvMarcas.TabIndex = 0;
                this.tsBtnSeleccionar.Visible = true;
                if (this.PressBoton)
                {
                    this.tsBtnListado_Click(this.tsBtnListado, new EventArgs());
                }
                else
                {
                    this.btnBuscar_Click(this.btnBuscar, new EventArgs());
                }
            }
        }

        private void FrmMarcaNuevo_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyData)
            {
                case Keys.F2:
                    {
                        this.btnGuardar_Click(this.btnGuardar, new EventArgs());
                        break;
                    }
                case Keys.F3:
                    {
                        this.tsBtnListado_Click(this.tsBtnListado, new EventArgs());
                        break;
                    }
                case Keys.F4:
                    {
                        this.tsbtnEditar_Click(this.tsbtnEditar, new EventArgs());
                        break;
                    }
                case Keys.F5:
                    {
                        this.tsbtnEliminar_Click(this.tsbtnEliminar, new EventArgs());
                        break;
                    }
                case Keys.F6:
                    {
                        this.dgvMarcas.Focus();
                        break;
                    }
                case Keys.F11:
                    {
                        try
                        {
                            string rta = CustomControl.OptionPane.OptionBox
                                        ("Ingresar contraseña de Administrador .", "Administrador", CustomControl.OptionPane.Icon.LoginAdmin);
                            if (rta.Equals("ajuste2014"))
                            {
                                miBussinesMarca.Ajustar();
                                CustomControl.OptionPane.MessageInformation("El ajuste se realizo con exito.");
                            }
                        }
                        catch (Exception ex)
                        {
                            CustomControl.OptionPane.MessageError(ex.Message);
                        }
                        break;
                    }
                case Keys.F12:
                    {
                        this.dgvMarcas_CellDoubleClick(this.dgvMarcas, null);
                        break;
                    }
                case Keys.Escape:
                    {
                        this.tsbtnSalir_Click(this.tsbtnSalir, new EventArgs());
                        break;
                    }
            }
        }

        private void FrmMarcaNuevo_FormClosing(object sender, FormClosingEventArgs e)
        {
            CompletaEventos.CapturaEventom(false);
        }

        private void tsBtnListado_Click(object sender, EventArgs e)
        {
            try
            {
                this.PressBoton = true;
                this.dgvMarcas.AutoGenerateColumns = false;
                this.dgvMarcas.DataSource = this.miBussinesMarca.ListarMarcas();
                this.dgvMarcas.Focus();
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
        }

        private void tsbtnEditar_Click(object sender, EventArgs e)
        {
            if (this.dgvMarcas.RowCount != 0)
            {
                var gridRow = this.dgvMarcas.CurrentRow;
                this.txtCodigo.Text = gridRow.Cells["Codigo"].Value.ToString();
                this.txtNombre.Text = gridRow.Cells["Nombre"].Value.ToString();
                this.Editar = true;
            }
            else
            {
                OptionPane.MessageInformation("No hay registros para editar.");
            }
        }

        private void tsbtnEliminar_Click(object sender, EventArgs e)
        {
            if (this.dgvMarcas.RowCount != 0)
            {
                DialogResult rta = MessageBox.Show("¿Esta seguro(a) de eliminar la marca?", "Marca",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (rta.Equals(DialogResult.Yes))
                {
                    try
                    {
                        this.miBussinesMarca.EliminarMarca(Convert.ToInt32(this.dgvMarcas.CurrentRow.Cells["Codigo"].Value));
                        OptionPane.MessageInformation("La marca se elimino con exito.");
                        if (this.PressBoton)
                        {
                            this.tsBtnListado_Click(this.tsBtnListado, new EventArgs());
                        }
                        else
                        {
                            this.btnBuscar_Click(this.btnBuscar, new EventArgs());
                        }
                    }
                    catch (Exception ex)
                    {
                        OptionPane.MessageError(ex.Message);
                    }
                }
            }
            else
            {
                OptionPane.MessageInformation("No hay registros para eliminar.");
            }
        }

        private void tsBtnSeleccionar_Click(object sender, EventArgs e)
        {
            this.dgvMarcas_CellDoubleClick(this.dgvMarcas, null);
        }

        private void tsbtnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar.Equals((char)Keys.Enter))
            {
                this.btnGuardar_Click(this.btnGuardar, new EventArgs());
            }
        }

        private void btnNueva_Click(object sender, EventArgs e)
        {
            try
            {
                if (miBussinesMarca.ListarMarcas().Count > 0)
                {
                    this.txtCodigo.Text = (this.miBussinesMarca.UltimoId() + 1).ToString();
                }
                else
                {
                    this.txtCodigo.Text = "1";
                }
                //this.txtCodigo.Text = (this.miBussinesMarca.UltimoId() + 1).ToString();
                this.txtNombre.Focus();
                this.txtNombre.Text = "";
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (!String.IsNullOrEmpty(this.txtNombre.Text))
                {
                    this.miError.SetError(this.txtNombre, null);
                    if (!miBussinesMarca.Existe(this.txtNombre.Text.ToUpper()))
                    {
                        this.miError.SetError(this.txtNombre, null);
                        this.txtNombre.Text = this.txtNombre.Text.ToUpper();

                        if (this.Editar)
                        {
                            miBussinesMarca.EditarMarca(new Marca
                            {
                                IdMarca = Convert.ToInt32(this.txtCodigo.Text),
                                NombreMarca = this.txtNombre.Text
                            });
                            OptionPane.MessageInformation("La marca se edito con exito.");
                            this.Editar = false;
                        }
                        else
                        {
                            miBussinesMarca.InsertarMarca(new Marca
                            {
                                NombreMarca = this.txtNombre.Text
                            });
                            OptionPane.MessageInformation("La marca se guardo con exito.");
                        }
                        this.txtCodigo.Text = (miBussinesMarca.UltimoId() + 1).ToString();
                        this.txtConsulta.Text = this.txtNombre.Text;
                        this.btnBuscar_Click(this.btnBuscar, new EventArgs());
                        this.txtNombre.Text = "";
                    }
                    else
                    {
                        this.miError.SetError(this.txtNombre, "El nombre de la marca ya existe.");
                    }
                }
                else
                {
                    this.miError.SetError(this.txtNombre, "El campo es requerido.");
                }
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
        }

        private void txtConsulta_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar.Equals((char)Keys.Enter))
            {
                this.btnBuscar_Click(this.btnBuscar, new EventArgs());
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                this.PressBoton = false;
                this.dgvMarcas.AutoGenerateColumns = false;
                this.dgvMarcas.DataSource = this.miBussinesMarca.ListaMarcasNombre(this.txtConsulta.Text);
                if (this.dgvMarcas.RowCount.Equals(0))
                {
                    DialogResult rta = MessageBox.Show("La marca no existe.\n¿Desea crearla?", "Marca",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (rta.Equals(DialogResult.Yes))
                    {
                        this.txtNombre.Text = this.txtConsulta.Text.ToUpper();
                        this.txtNombre.Focus();
                        this.txtConsulta.Text = "";
                    }
                }
                else
                {
                    this.dgvMarcas.Focus();
                }
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
        }

        private void dgvMarcas_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (this.dgvMarcas.RowCount != 0)
            {
                if (this.Extension)
                {
                    DataGridViewRow currentRow = this.dgvMarcas.Rows[this.dgvMarcas.CurrentCell.RowIndex];
                    TransferirMarca miMarca = TransferirMarca.Instanciam();
                    miMarca.IdMarca = Convert.ToInt32(currentRow.Cells[0].Value);
                    miMarca.NombreMarca = Convert.ToString(currentRow.Cells[1].Value);
                    CompletaEventos.CapturaEventom(miMarca);
                    this.Close();
                }
            }
        }
    }
}