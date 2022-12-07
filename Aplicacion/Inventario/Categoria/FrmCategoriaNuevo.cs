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

namespace Aplicacion.Inventario.Categoria
{
    public partial class FrmCategoriaNuevo : Form
    {
        public bool Extension { set; get; }

        public bool PressBoton { set; get; }

        private bool Editar { set; get; }

        private bool CodigoMatch { set; get; }

        private bool NombreMatch { set; get; }

        private DTO.Clases.Categoria MiCategoria { set; get; }

        private ErrorProvider miError;


        private BussinesCategoria miBussinesCategoria;

        public FrmCategoriaNuevo()
        {
            InitializeComponent();
            this.Extension = false;
            this.PressBoton = true;
            this.Editar = false;
            this.CodigoMatch = false;
            this.NombreMatch = false;
            this.MiCategoria = new DTO.Clases.Categoria();
            this.miError = new ErrorProvider();

            miBussinesCategoria = new BussinesCategoria();
        }

        private void FrmCategoriaNuevo_Load(object sender, EventArgs e)
        {
            CargarDatos();
            if (this.Extension)
            {
                this.gbCategoria.TabIndex = 1;
                this.gbConsulta.TabIndex = 0;
                this.txtConsulta.TabIndex = 1;
                this.dgvCategorias.TabIndex = 0;
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

        private void FrmCategoriaNuevo_KeyDown(object sender, KeyEventArgs e)
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
                case Keys.F11:
                    {
                        try
                        {
                            string rta = CustomControl.OptionPane.OptionBox
                                ("Ingresar contraseña de Administrador .", "Administrador", CustomControl.OptionPane.Icon.LoginAdmin);
                            if (rta.Equals("ajuste2014"))
                            {
                                miBussinesCategoria.AjustarCodigosCategoria();
                                OptionPane.MessageInformation("Los datos se ajustaron con exito.");
                            }
                        }
                        catch (Exception ex)
                        {
                            OptionPane.MessageError(ex.Message);
                        }
                        break;
                    }
                case Keys.F12:
                    {
                        this.tsBtnSeleccionar_Click(this.tsBtnSeleccionar, new EventArgs());
                        break;
                    }
                case Keys.Escape:
                    {
                        this.Close();
                        break;
                    }
            }
        }

        private void FrmCategoriaNuevo_FormClosing(object sender, FormClosingEventArgs e)
        {
            CompletaEventos.CapturaEventom(false);
        }

        private void tsBtnListado_Click(object sender, EventArgs e)
        {
            try
            {
                this.PressBoton = true;
                this.dgvCategorias.AutoGenerateColumns = false;
                this.dgvCategorias.DataSource = miBussinesCategoria.ListadoCategoria();
                if (this.dgvCategorias.RowCount > 13)
                {
                    this.dgvCategorias.Columns["Nombre"].Width = 236;
                }
                else
                {
                    this.dgvCategorias.Columns["Nombre"].Width = 250;
                }
                this.dgvCategorias.Focus();
                this.miError.SetError(this.txtCodigo, null);
                this.miError.SetError(this.txtNombre, null);
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
        }

        private void tsbtnEditar_Click(object sender, EventArgs e)
        {
            if (this.dgvCategorias.RowCount != 0)
            {
                var gridRow = this.dgvCategorias.CurrentRow;
                this.txtCodigo.Text = gridRow.Cells["Codigo"].Value.ToString();
                this.txtNombre.Text = gridRow.Cells["Nombre"].Value.ToString();
                this.MiCategoria.CodigoCategoria = this.txtCodigo.Text;
                this.MiCategoria.NombreCategoria = this.txtNombre.Text;
                this.Editar = true;
            }
            else
            {
                OptionPane.MessageInformation("No hay registros para editar.");
            }
        }

        private void tsbtnEliminar_Click(object sender, EventArgs e)
        {
            if (this.dgvCategorias.RowCount != 0)
            {
                DialogResult rta = MessageBox.Show("¿Esta seguro(a) de eliminar la categoria?", "Categoria",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (rta.Equals(DialogResult.Yes))
                {
                    try
                    {
                        this.miBussinesCategoria.EliminarCategoria(this.dgvCategorias.CurrentRow.Cells["Codigo"].Value.ToString());
                        OptionPane.MessageInformation("La categoria se elimino con exito.");
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
            this.dgvCategorias_CellDoubleClick(this.dgvCategorias, null);
        }

        private void tsbtnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnNueva_Click(object sender, EventArgs e)
        {
            this.Editar = false;
            this.txtCodigo.Focus();
            this.txtCodigo.Text = "";
            this.txtNombre.Text = "";
            this.miError.SetError(this.txtCodigo, null);
            this.miError.SetError(this.txtNombre, null);
        }

        private void txtCodigo_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void txtCodigo_Validating(object sender, CancelEventArgs e)
        {
            if (!Validacion.EsVacio(this.txtCodigo, miError, "El campo es requerido."))
            {
                if (this.ExisteCodigo(this.txtCodigo.Text))
                {
                    this.miError.SetError(this.txtCodigo, "El código ya esta registrado.");
                    this.CodigoMatch = false;
                }
                else
                {
                    this.miError.SetError(this.txtCodigo, null);
                    this.CodigoMatch = true;
                }
            }
            else
            {
                this.CodigoMatch = false;
            }
        }

        private void lklGenerarCodigo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                this.txtCodigo.Text = miBussinesCategoria.ObtenerCodigocategoria().ToString();
                this.txtNombre.Focus();
                this.txtCodigo_Validating(this.txtCodigo, null);
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
        }

        private void txtNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar.Equals((char)Keys.Enter))
            {
                this.btnGuardar_Click(this.btnGuardar, new EventArgs());
            }
        }

        private void txtNombre_Validating(object sender, CancelEventArgs e)
        {
            if (!Validacion.EsVacio(this.txtNombre, miError, "El campo es requerido."))
            {
                if (this.ExisteNombre(this.txtNombre.Text))
                {
                    this.miError.SetError(this.txtNombre, "El nombre ya esta registrado.");
                    this.NombreMatch = false;
                }
                else
                {
                    this.miError.SetError(this.txtNombre, null);
                    this.NombreMatch = true;
                }
            }
            else
            {
                this.NombreMatch = false;
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(this.txtCodigo.Text))
            {
                if (!String.IsNullOrEmpty(this.txtNombre.Text))
                {
                    try
                    {
                        miError.SetError(this.txtCodigo, null);
                        miError.SetError(this.txtNombre, null);
                        this.txtCodigo.Text = this.txtCodigo.Text.ToUpper();
                        this.txtNombre.Text = this.txtNombre.Text.ToUpper();

                        if (this.Editar)
                        {
                            if (this.MiCategoria.CodigoCategoria != this.txtCodigo.Text)
                            {
                                this.txtCodigo_Validating(this.txtCodigo, null);
                            }
                            else
                            {
                                this.CodigoMatch = true;
                            }
                            if (this.MiCategoria.NombreCategoria != this.txtNombre.Text)
                            {
                                this.txtNombre_Validating(this.txtNombre, null);
                            }
                            else
                            {
                                this.NombreMatch = true;
                            }
                            if (this.CodigoMatch && this.NombreMatch)
                            {
                                miBussinesCategoria.ModificarCategoria(new DTO.Clases.Categoria
                                {
                                    CodigoCategoria = this.MiCategoria.CodigoCategoria,
                                    CodigoNuevo = this.txtCodigo.Text,
                                    NombreCategoria = this.txtNombre.Text
                                });
                                OptionPane.MessageInformation("La categoria se edito con exito.");
                                this.txtConsulta.Text = this.txtNombre.Text;
                                this.btnBuscar_Click(this.btnBuscar, new EventArgs());
                                this.txtCodigo.Text = "";
                                this.txtNombre.Text = "";
                                miError.SetError(this.txtCodigo, null);
                                miError.SetError(this.txtNombre, null);
                            }
                        }
                        else
                        {
                            this.txtCodigo_Validating(this.txtCodigo, null);
                            this.txtNombre_Validating(this.txtNombre, null);
                            if (this.CodigoMatch && this.NombreMatch)
                            {
                                miBussinesCategoria.insertarCategoria(new DTO.Clases.Categoria
                                {
                                    CodigoCategoria = this.txtCodigo.Text,
                                    NombreCategoria = this.txtNombre.Text
                                });
                                OptionPane.MessageInformation("La categorioa se guardo con exito.");
                                this.txtConsulta.Text = this.txtNombre.Text;
                                this.btnBuscar_Click(this.btnBuscar, new EventArgs());
                                this.txtCodigo.Text = "";
                                this.txtNombre.Text = "";
                                miError.SetError(this.txtCodigo, null);
                                miError.SetError(this.txtNombre, null);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        OptionPane.MessageError(ex.Message);
                    }
                }
                else
                {
                    miError.SetError(this.txtNombre, "El campo es requerido.");
                }
            }
            else
            {
                miError.SetError(this.txtCodigo, "El campo es requerido.");
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
            if (!String.IsNullOrEmpty(this.txtConsulta.Text))
            {
                try
                {
                    this.PressBoton = false;
                    this.dgvCategorias.AutoGenerateColumns = false;
                    if (Convert.ToInt32(this.cbCriterio.SelectedValue).Equals(1))
                    {
                        this.dgvCategorias.DataSource =
                            miBussinesCategoria.ConsultaPorNombre(this.txtConsulta.Text);
                    }
                    else
                    {
                        this.dgvCategorias.DataSource =
                            miBussinesCategoria.consultaCategoriaCodigo(this.txtConsulta.Text);
                    }
                    if (this.dgvCategorias.RowCount != 0)
                    {
                        this.dgvCategorias.Focus();
                    }
                    else
                    {
                        DialogResult rta = MessageBox.Show("La Categoria no existe.\n¿Desea crearla?", "Categoria",
                                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (rta.Equals(DialogResult.Yes))
                        {
                            this.txtNombre.Text = this.txtConsulta.Text.ToUpper();
                            this.txtNombre.Focus();
                            this.txtConsulta.Text = "";
                        }
                    }

                    if (this.dgvCategorias.RowCount > 13)
                    {
                        this.dgvCategorias.Columns["Nombre"].Width = 236;
                    }
                    else
                    {
                        this.dgvCategorias.Columns["Nombre"].Width = 250;
                    }
                }
                catch (Exception ex)
                {
                    OptionPane.MessageError(ex.Message);
                }
            }
            else
            {
                this.miError.SetError(this.txtConsulta, "El campo es requerido.");
            }
        }

        private void dgvCategorias_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (this.dgvCategorias.RowCount != 0)
            {
                if (this.Extension)
                {
                    var gridRow = this.dgvCategorias.CurrentRow;
                    var categoria = new DTO.Clases.Categoria();
                    categoria.CodigoCategoria = gridRow.Cells["Codigo"].Value.ToString();
                    categoria.NombreCategoria = gridRow.Cells["Nombre"].Value.ToString();
                    CompletaEventos.CapturaEventom(categoria);
                    this.Close();
                }
            }
        }

        private void CargarDatos()
        {
            var lst = new List<Inventario.Producto.Criterio>();
            lst.Add(new Producto.Criterio
            {
                Id = 1,
                Nombre = "Nombre"
            });
            lst.Add(new Producto.Criterio
            {
                Id = 2,
                Nombre = "Código"
            });
            this.cbCriterio.DataSource = lst;
        }

        private bool ExisteCodigo(string codigo)
        {
            try
            {
                return miBussinesCategoria.existecategoria(codigo);
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
                return false;
            }
        }

        private bool ExisteNombre(string nombre)
        {
            try
            {
                return miBussinesCategoria.ExisteNombreCategoria(nombre);
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
                return false;
            }
        }
    }
}