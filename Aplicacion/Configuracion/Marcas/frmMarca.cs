using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using BussinesLayer.Clases;
using DTO.Clases;
using Aplicacion.Inventario.Producto;
using System.Collections;
using Utilities;

namespace Aplicacion.Configuracion.Marcas
{
    public partial class frmMarca : Form
    {
        /// <summary>
        /// Objeto de logica de negocio de Marca.
        /// </summary>
        private BussinesMarca miBussinesMarca;

        /// <summary>
        /// Representa un objeto para mensajes de Error.
        /// </summary>
        private ErrorProvider miError = new ErrorProvider();

        /// <summary>
        /// Representa el texto : El campo nombre es requerido. 
        /// </summary>
        private string msgNombreReq = "El campo nombre es requerido. ";

        /// <summary>
        /// Representa el texto : El campo nombre tiene formato incorrecto..
        /// </summary>
        private string msnNombreFormato = "El campo nombre tiene formato incorrecto. ";

        /// <summary>
        /// Indica que se a presionado el boton nueva marca.
        /// </summary>
        private bool nuevaMarca = false;

        /// <summary>
        /// Indica si cancela o no el ingreso de una nueva marca.
        /// </summary>
        private bool cancelNewMarca = true;

        /// <summary>
        /// Indica que se a presionado el boton editar marca
        /// </summary>
        private bool editMarca = false;

        /// <summary>
        /// Indica si cancela o no la edicion de una marca.
        /// </summary>
        private bool cancelEditMarca = true;

        /// <summary>
        /// Establece el valor del Id de la Marca.
        /// </summary>
        private int idMarca = 0;

        /// <summary>
        /// Indica que se ha editado una marca.
        /// </summary>
        private bool edicion = false;

        /// <summary>
        /// Indica que si se modifico la marca o no.
        /// </summary>
        private bool msnEditMarca = false;

        /// <summary>
        /// 
        /// </summary>
        public bool Extension = false;

        public bool PressBoton;

        public frmMarca()
        {
            InitializeComponent();
            PressBoton = true;
            miBussinesMarca = new BussinesMarca();
        }

        private void frmMarca_Load(object sender, EventArgs e)
        {
            if (Extension)
            {
                tsBtnCriterio.Visible = true;
                tsBtnSeleccionar.Visible = true;
                if (PressBoton)
                {
                    this.tsbtnListarTodos_Click(this.tsbtnListarTodos, new EventArgs());
                }
                else
                {
                    btnBuscarMarcaNombre_Click(this.btnBuscarMarcaNombre, new EventArgs());
                }
            }
        }

        private void frmMarca_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData.Equals(Keys.F5))
            {
                txtMarcaNombre.Focus();
            }
            else
            {
                if (e.KeyData.Equals(Keys.F12))
                {
                    this.grillamarca_CellDoubleClick(this.grillamarca, null);
                }
                else
                {
                    if (e.KeyData.Equals(Keys.F11))
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
                    }
                }
            }
        }

        private void tsbtnNuevaMarca_Click(object sender, EventArgs e)
        {
            if (cancelNewMarca)
            {
                lblNombre.Text = "Nueva Marca";
                tsbtnListarTodos.Enabled = false;
                tsbtnEditarMarca.Enabled = false;
                tsbtnEliminarMarca.Enabled = false;
                btnBuscarMarcaNombre.Enabled = false;
                txtMarcaNombre.Text = "";
                txtMarcaNombre.Focus();
                this.tsbtnNuevaMarca.Image =
                    ((System.Drawing.Image)(miResources.GetObject("recurso.Image")));
                this.tsbtnNuevaMarca.Text = "Cancelar";
                nuevaMarca = true;
                cancelNewMarca = false;
                PrestEditaMarca();
            }
            else
            {
                if (nuevaMarca)
                {
                    lblNombre.Text = "Buscar Marca";
                    tsbtnListarTodos.Enabled = true;
                    tsbtnEditarMarca.Enabled = true;
                    tsbtnEliminarMarca.Enabled = true;
                    btnBuscarMarcaNombre.Enabled = true;
                    this.tsbtnNuevaMarca.Image =
                        ((System.Drawing.Image)(miResources.GetObject("tsbtnNuevaMarca.Image")));
                    this.tsbtnNuevaMarca.Text = "Nuevo";
                    nuevaMarca = false;
                    cancelNewMarca = true;
                    tsbtnGuardarMarca.Enabled = false;
                }
            }
        }

        private void tsbtnGuardarMarca_Click(object sender, EventArgs e)
        {
            if (!Validacion.EsVacio(txtMarcaNombre, miError, msgNombreReq))
            {
                if (Validacion.ConFormato
                    (Validacion.TipoValidacion.Palabras, txtMarcaNombre, miError, msnNombreFormato))
                {
                    if (edicion)
                        EditarMarca();
                    else
                    {
                        GuardarMarca();
                    }
                    if (!msnEditMarca)
                    {
                        tsbtnGuardarMarca.Enabled = false;
                        tsbtnListarTodos_Click(null, null);

                        tsbtnNuevaMarca_Click(null, null);
                        tsbtnEditarMarca_Click(null, null);
                    }
                }
            }
        }

        private void tsbtnEditarMarca_Click(object sender, EventArgs e)
        {
            if (grillamarca.CurrentCell != null)
            {
                if (cancelEditMarca)
                {
                    lblNombre.Text = "Editar Marca";
                    DataGridViewRow currentRow = grillamarca.Rows[grillamarca.CurrentCell.RowIndex];
                    idMarca = Convert.ToInt32(currentRow.Cells[0].Value);
                    txtMarcaNombre.Text = Convert.ToString(currentRow.Cells[1].Value);
                    tsbtnListarTodos.Enabled = false;
                    tsbtnNuevaMarca.Enabled = false;
                    tsbtnEliminarMarca.Enabled = false;
                    btnBuscarMarcaNombre.Enabled = false;
                    tsbtnEditarMarca.Image =
                        ((System.Drawing.Image)(miResources.GetObject("recurso.Image")));
                    tsbtnEditarMarca.Text = "Cancelar";
                    editMarca = true;
                    cancelEditMarca = false;
                    edicion = true;
                    PrestNuevaMarca();
                }
                else
                {
                    if (editMarca)
                    {
                        lblNombre.Text = "Buscar Marca";
                        idMarca = 0;
                        txtMarcaNombre.Text = "";
                        tsbtnListarTodos.Enabled = true;
                        tsbtnNuevaMarca.Enabled = true;
                        tsbtnEliminarMarca.Enabled = true;
                        btnBuscarMarcaNombre.Enabled = true;
                        tsbtnGuardarMarca.Enabled = false;
                        tsbtnEditarMarca.Image =
                            ((System.Drawing.Image)(miResources.GetObject("tsbtnEditarMarca.Image")));
                        tsbtnEditarMarca.Text = "Editar";
                        editMarca = false;
                        cancelEditMarca = true;
                        edicion = false;
                    }
                }
            }
        }

        private void tsbtnEliminarMarca_Click(object sender, EventArgs e)
        {
            if (this.grillamarca.CurrentCell != null)
            {
                DialogResult rta = MessageBox.Show(
                  "¿Esta seguro de eliminar el registro?", "Marca", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (rta == DialogResult.Yes)
                {
                    var id = Convert.ToInt32(this.grillamarca.CurrentRow.Cells[0].Value);
                    try
                    {
                        miBussinesMarca.EliminarMarca(id);
                        MessageBox.Show
                            ("La Marca se ha eliminado con Exito. ", "Marca", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        tsbtnListarTodos_Click(null, null);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Marca", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            tsbtnGuardarMarca.Enabled = false;
        }

        private void tsbtnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tsbtnListarTodos_Click(object sender, EventArgs e)
        {
            try
            {
                this.grillamarca.AutoGenerateColumns = false;
                grillamarca.DataSource = null;
                grillamarca.DataSource = miBussinesMarca.ListarMarcas();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            if (this.grillamarca.RowCount != 0)
            {
                EstablecerEditarEliminar(true);
            }
            tsbtnGuardarMarca.Enabled = false;
        }

        private void tsBtnCriterio_Click(object sender, EventArgs e)
        {
            txtMarcaNombre.Focus();
        }

        private void tsBtnSeleccionar_Click(object sender, EventArgs e)
        {
            this.grillamarca_CellDoubleClick(this.grillamarca, null);
        }

        private void btnBuscarMarcaNombre_Click(object sender, EventArgs e)
        {
            try
            {
                grillamarca.DataSource = null;
                grillamarca.AutoGenerateColumns = false;
                if (!String.IsNullOrEmpty(txtMarcaNombre.Text))
                {
                    grillamarca.DataSource = miBussinesMarca.ListaMarcasNombre(txtMarcaNombre.Text);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            tsbtnGuardarMarca.Enabled = false;
        }

        private void grillamarca_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (Extension)
            {
                if (!grillamarca.RowCount.Equals(0))
                {
                    DataGridViewRow currentRow = grillamarca.Rows[grillamarca.CurrentCell.RowIndex];
                    TransferirMarca miMarca = TransferirMarca.Instanciam();
                    miMarca.IdMarca = Convert.ToInt32(currentRow.Cells[0].Value);
                    miMarca.NombreMarca = Convert.ToString(currentRow.Cells[1].Value);
                    CompletaEventos.CapturaEventom(miMarca);
                    Extension = false;
                    this.Close();
                }
            }
        }

        private void txtMarcaNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(!cancelNewMarca || !cancelEditMarca)
                tsbtnGuardarMarca.Enabled = true;
            if (e.KeyChar == (char)Keys.Enter)
            {
                if (!tsbtnGuardarMarca.Enabled)
                {
                    btnBuscarMarcaNombre_Click(null, null);
                    if (grillamarca.Rows.Count != 0)
                    {
                        grillamarca.Focus();
                    }
                }
            }
        }

        /// <summary>
        /// Establece el Enable de los botones de Editar y Eliminar Marca.
        /// </summary>
        /// <param name="estado">Estado a establecer.</param>
        private void EstablecerEditarEliminar(bool estado)
        {
            this.tsbtnEditarMarca.Enabled = estado;
            this.tsbtnEliminarMarca.Enabled = estado;
        }

        /// <summary>
        /// Carga un obejeto marca del formulario y lo ingresa en la base de datos.
        /// </summary>
        private void GuardarMarca()
        {
            Marca mimarca = new Marca();
            try
            {
                mimarca.NombreMarca = txtMarcaNombre.Text;
                if (miBussinesMarca.InsertarMarca(mimarca))
                {
                    MessageBox.Show
                        ("La Marca se ingreso con exito. ", "Marca", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtMarcaNombre.Text = "";
                    cancelEditMarca = false;
                    editMarca = true;
                }
                else
                    MessageBox.Show
                        ("La Marca que ingreso ya existe. ", "Marca", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message,"Marca", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Cargar un objeto Marca del formulario y lo edita en la base de datos.
        /// </summary>
        private void EditarMarca()
        {
            Marca miMarca = new Marca();
            miMarca.IdMarca = idMarca;
            miMarca.NombreMarca = txtMarcaNombre.Text;
            try
            {
                if (miBussinesMarca.EditarMarca(miMarca))
                {
                    MessageBox.Show
                        ("La edicion se realizo con exito. ", "Edicion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtMarcaNombre.Text = "";
                    msnEditMarca = false;
                    cancelEditMarca = false;
                    cancelNewMarca = false;
                    nuevaMarca = true;
                }
                else
                {
                    MessageBox.Show
                       ("La Marca que ingreso ya existe, o esta intentando editar la misma", "Marca",
                       MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    msnEditMarca = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Establece las propiedades para ingresar una nueva marca.
        /// </summary>
        private void PrestNuevaMarca()
        {
            //btnBuscarMarcaNombre.Enabled = true;
            this.tsbtnNuevaMarca.Image =
                ((System.Drawing.Image)(miResources.GetObject("tsbtnNuevaMarca.Image")));
            this.tsbtnNuevaMarca.Text = "Nuevo";
            nuevaMarca = false;
            cancelNewMarca = true;
            tsbtnGuardarMarca.Enabled = false;
        }

        /// <summary>
        /// Establece las propiedades para editar una marca.
        /// </summary>
        private void PrestEditaMarca()
        {
            idMarca = 0;
            txtMarcaNombre.Text = "";
            //tsbtnListarTodos.Enabled = true;
            //btnBuscarMarcaNombre.Enabled = true;
            tsbtnEditarMarca.Image =
                ((System.Drawing.Image)(miResources.GetObject("tsbtnEditarMarca.Image")));
            tsbtnEditarMarca.Text = "Editar";
            editMarca = false;
            cancelEditMarca = true;
            edicion = false;
        }

        /// <summary>
        /// Carga el GridView con datos desde la base de datos.
        /// </summary>
        public void CargaGrillaMarca()
        {
            tsbtnListarTodos_Click(null, null);
        }
    }
}