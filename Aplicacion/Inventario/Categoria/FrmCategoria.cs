using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Aplicacion.Clases;
using BussinesLayer.Clases;
using CustomControl;
using DTO.Clases;
using Utilities;

namespace Aplicacion.Inventario.Categoria
{
    public partial class FrmCategoria : Form
    {
        /// <summary>
        /// Objeto para mostrar errores. 
        /// </summary>
        ErrorProvider er;

        /// <summary>
        /// Reune las filas seleccionadas de un  grid
        /// </summary>
        private DataGridViewRow registro;

        /// <summary>
        /// Atributos de modelo de negocios.
        /// </summary>
        public BussinesCategoria Buscat;

        /// <summary>
        /// carga los criterios de busqueda de categoria
        /// </summary>
        private CargarCriterioCategoria miCarga;

        /// <summary>
        /// Obtiene o establece el valor del registro a segir o registro base.
        /// </summary>
        private int rowCategoria;

        /// <summary>
        /// Obtiene o establece el valor maximo de registros.
        /// </summary>
        private int maxRowCategoria;

        /// <summary>
        /// obtiene o establece la cantidad de categortias en la base de datos.
        /// </summary>
        private long totalRowCategoria;

        ///<summary>
        /// Obtiene o establece el total de paginas.
        /// </summary>
        private long paginaCategoria;

        /// <summary>
        /// Obtiene o establece los registros de categoria.
        /// </summary>
        private int currenPageCategoria;

        /// <summary>
        /// Obtiene o establece el valor de la iteración a la que corresponde la consulta.
        /// </summary>
        private int Iteracion;

        /// <summary>
        /// Obtiene o establece el Nombre de la Categoría.
        /// </summary>
        private string Nombre;

        /// <summary>
        /// Establese la condicion de la validacion de codigo categoria.
        /// </summary>
        private bool codigocategoria = false;

        /// <summary>
        /// Establese la condicion de la validacion de nombre categoria
        /// </summary>
        private bool nombrecategoria = false;

        /// <summary>
        /// Establece la condicion de la validacion de descripcion categoria
        /// </summary>
        private bool descripcioncategoria = false;

        /// <summary>
        /// Establece el valor que indica que el formulario se usa como extencio de otro.
        /// </summary>
        public bool Extencion = false;

        public bool PresBoton;

        /// <summary>
        /// inicializA el formilario
        /// </summary>
        public FrmCategoria()
        {
            InitializeComponent();
            Buscat = new BussinesCategoria();
            er = new ErrorProvider();
            maxRowCategoria = 7;
            PresBoton = true;
        }

        /// <summary>
        /// la grilla se adapta a la infirmacion de el objeto
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmCategoria_Load(object sender, EventArgs e)
        {
            this.dgvListadocategoria.AutoGenerateColumns = false;
            miCarga = new CargarCriterioCategoria();
            cbxbuscar.DataSource = miCarga.Lista1;
            cbxbuscar2.DataSource = miCarga.Lista2;
            if (Extencion)
            {
                if (PresBoton)
                {
                    tsBtnCriterio.Visible = true;
                    tsBtnSeleccionar.Visible = true;
                    cbxbuscar.SelectedIndex = 1;
                    cbxbuscar_SelectionChangeCommitted(this.cbxbuscar, new EventArgs());
                    this.btnlistarcategoria_Click_1(this.btnlistarcategoria, new EventArgs());
                }
                else
                {
                    tsBtnCriterio.Visible = true;
                    tsBtnSeleccionar.Visible = true;
                    cbxbuscar.SelectedIndex = 1;
                    //cbxbuscar2.SelectedIndex = 2;
                    cbxbuscar_SelectionChangeCommitted(this.cbxbuscar, new EventArgs());
                    btnbuscar_Click(this.btnbuscar, new EventArgs());
                }
            }
        }

        private void FrmCategoria_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData.Equals(Keys.F5))
            {
                txtbuscarporcategoria.Focus();
            }
            else
            {
                if (e.KeyData.Equals(Keys.F12))
                {
                    this.dgvListadocategoria_CellDoubleClick(this.dgvListadocategoria, null);
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
                                Buscat.AjustarCodigosCategoria();
                            }
                        }
                        catch (Exception ex)
                        {
                            OptionPane.MessageError(ex.Message);
                        }
                    }
                }
            }
        }

        private void btnguardacategoria_Click(object sender, EventArgs e)
        {
            validacion();
            if (codigocategoria && nombrecategoria && descripcioncategoria)
            {
                lklblGenerarCodigoCategoria.Focus();
                var Ingrecat = new DTO.Clases.Categoria();
                try
                {
                    Ingrecat.CodigoCategoria = txtCodigoCategoria.Text;
                    Ingrecat.NombreCategoria = txtNombreCategoria.Text;
                    Ingrecat.DescripcionCategoria = txtDescripcionCategoria.Text;
                    Ingrecat.EstadoCategoria = true;

                    Buscat.insertarCategoria(Ingrecat);
                    MessageBox.Show
                      ("La Categoria se creo exitosamente", "Categoria", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LimpiCampos();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void btnlistarcategoria_Click_1(object sender, EventArgs e)
        {
            rowCategoria = 0;
            currenPageCategoria = 1;
            Iteracion = 1;
            try
            {
                dgvListadocategoria.AutoGenerateColumns = false;
                this.dgvListadocategoria.DataSource = null;
                this.dgvListadocategoria.DataSource = Buscat.ListarCategoria(
                    rowCategoria, maxRowCategoria);
                totalRowCategoria = Buscat.RowTotalCategoria();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            paginaCategoria = totalRowCategoria / maxRowCategoria;
            if (totalRowCategoria % maxRowCategoria != 0)
                paginaCategoria++;
            if (currenPageCategoria > paginaCategoria)
                currenPageCategoria = 0;
            tslblPaginacion.Text = currenPageCategoria + " / " + paginaCategoria;
        }

        private void btnbuscar_Click(object sender, EventArgs e)
        {
            try
            {
                listarCategoria();
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
        }

        private void txtbuscarporcategoria_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                btnbuscar_Click(null, null);
                if (dgvListadocategoria.Rows.Count != 0)
                {
                    dgvListadocategoria.Focus();
                }
            }
        }

        private void btnmodificarcate_Click(object sender, EventArgs e)
        {
            if (this.dgvListadocategoria.RowCount != 0)
            {
                try
                {
                    registro = this.dgvListadocategoria.Rows[this.dgvListadocategoria.CurrentCell.RowIndex];
                    FrmModificarCategoria modificar = new FrmModificarCategoria();
                    modificar.MdiParent = this.MdiParent;
                    modificar.CargarCategoria(registro);
                    modificar.Show();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                MessageBox.Show("No hay registros a modificar");
            }
        }

        private void btmeliminarcategoria_Click(object sender, EventArgs e)
        {
            if (this.dgvListadocategoria.RowCount != 0)
            {
                DialogResult rta = MessageBox.Show("¿Esta seguro de eliminar el registro?", "Categoria",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (rta == DialogResult.Yes)
                {
                    try
                    {
                        var codigo = Convert.ToString(this.dgvListadocategoria.CurrentRow.Cells[0].Value);
                        Buscat.EliminarCategoria(codigo);
                        MessageBox.Show("El registro se ha eliminado exitosamente.",
                            "Categoria", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        btnlistarcategoria_Click_1(null, null);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }
            else
            {
                MessageBox.Show("No hay registros a eliminar");
            }
        }

        private void lklblGenerarCodigoCategoria_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                txtCodigoCategoria.Text = Convert.ToString(Buscat.ObtenerCodigocategoria());
                txtCodigoCategoria.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error" + ex.Message);
            }
        }

        private void tsbtnSalirCrear_Click(object sender, EventArgs e)
        {
            this.Close();
            CompletaEventos.CapturaEventoEditProveedor(false);
        }

        private void tsBtnCriterio_Click(object sender, EventArgs e)
        {
            txtbuscarporcategoria.Focus();
        }

        private void tsBtnSeleccionar_Click(object sender, EventArgs e)
        {
            this.dgvListadocategoria_CellDoubleClick(this.dgvListadocategoria, null);
        }

        private void tsbtnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cbxbuscar_SelectionChangeCommitted(object sender, EventArgs e)
        {
            var id = (int)cbxbuscar.SelectedValue;
            if (id == 1)
            {
                cbxbuscar2.SelectedValue = 1;
                cbxbuscar2.Enabled = false;
            }
            else
            {
                cbxbuscar2.Enabled = true;
                cbxbuscar2.SelectedValue = 2;
            }
        }

        private void txtCodigoCategoria_Validating(object sender, CancelEventArgs e)
        {
            if (!Validacion.EsVacio(txtCodigoCategoria, er, "El campo es requerido"))
            {
                if (Validacion.ConFormato(Validacion.TipoValidacion.PalabrasNumeroCaracter, txtCodigoCategoria, er, "Formato es incorrecto"))
                {
                    if (ExisteCodigoCategoria(txtCodigoCategoria.Text))
                    {
                        codigocategoria = false;
                        er.SetError(txtCodigoCategoria, "Ya existe una categoria con ese codigo en la base de datos.");
                    }
                    else
                    {
                        codigocategoria = true;
                        er.SetError(txtCodigoCategoria, null);
                    }
                }
                else
                {
                    codigocategoria = false;
                }
            }
            else
            {
                codigocategoria = false;
            }
        }

        private void txtNombreCategoria_Validating(object sender, CancelEventArgs e)
        {
            if (!Validacion.EsVacio(txtNombreCategoria, er, "El campo es requerido"))
            {
                /*if (Validacion.ConFormato(Validacion.TipoValidacion.Palabras, txtNombreCategoria, er, "Formato incorrecto"))
                {*/
                    nombrecategoria = true;
                /*}
                else
                {
                    nombrecategoria = false;
                }*/
            }
            else
            {
                nombrecategoria = false;
            }

        }

        private void txtDescripcionCategoria_Validating(object sender, CancelEventArgs e)
        {
            if (!Validacion.EsVacio(txtDescripcionCategoria, er, "el campo es requerido"))
            {
                /*if (Validacion.ConFormato(Validacion.TipoValidacion.Palabras, txtDescripcionCategoria, er, "formato incorrecto"))
                {*/
                    descripcioncategoria = true;
                /*}
                else
                {
                    descripcioncategoria = false;
                }*/
            }
            else
            {
                descripcioncategoria = false;
            }

        }

        private void rowInicio_Click(object sender, EventArgs e)
        {
            if (currenPageCategoria > 1)
            {
                var paginaActual = currenPageCategoria;
                for (int i = paginaActual; i > 1; i--)
                {
                    rowCategoria = rowCategoria - maxRowCategoria;
                    currenPageCategoria--;
                }
                try
                {
                    if (Iteracion == 1)
                    {
                        dgvListadocategoria.DataSource = Buscat.ListarCategoria(
                            rowCategoria, maxRowCategoria);
                    }
                    else
                    {
                        dgvListadocategoria.DataSource = Buscat.Filtrarcategorianombre
                            (Nombre, rowCategoria, maxRowCategoria);
                    }
                }
                catch
                { }
                tslblPaginacion.Text = currenPageCategoria + " / " + paginaCategoria;
            }
        }

        private void rowAnterior_Click(object sender, EventArgs e)
        {
            if (currenPageCategoria > 1)
            {
                rowCategoria = rowCategoria - maxRowCategoria;
                if (rowCategoria <= 0)
                {
                    rowCategoria = 0;
                }
                try
                {
                    if (Iteracion == 1)
                    {
                        dgvListadocategoria.DataSource = Buscat.ListarCategoria(
                            rowCategoria, maxRowCategoria);
                    }
                    else
                    {
                        dgvListadocategoria.DataSource = Buscat.Filtrarcategorianombre
                            (Nombre, rowCategoria, maxRowCategoria);
                    }
                }
                catch
                { }
                currenPageCategoria--;
                tslblPaginacion.Text = currenPageCategoria + " / " + paginaCategoria;
            }
        }

        private void rowSiguiente_Click(object sender, EventArgs e)
        {
            if (currenPageCategoria < paginaCategoria)
            {
                rowCategoria = rowCategoria + maxRowCategoria;
                try
                {
                    if (Iteracion == 1)
                    {
                        dgvListadocategoria.DataSource = Buscat.ListarCategoria(
                            rowCategoria, maxRowCategoria);
                    }
                    else
                    {
                        dgvListadocategoria.DataSource = Buscat.Filtrarcategorianombre
                            (Nombre, rowCategoria, maxRowCategoria);
                    }
                }
                catch
                { }
                currenPageCategoria++;
                tslblPaginacion.Text = currenPageCategoria + " / " + paginaCategoria;
            }
        }

        private void rowFinal_Click(object sender, EventArgs e)
        {
            if (currenPageCategoria < paginaCategoria)
            {
                var paginaActual = currenPageCategoria;
                for (int i = paginaActual; i < paginaCategoria; i++)
                {
                    rowCategoria = rowCategoria + maxRowCategoria;
                    currenPageCategoria++;
                }
                try
                {
                    if (Iteracion == 1)
                    {
                        dgvListadocategoria.DataSource = Buscat.ListarCategoria(
                            rowCategoria, maxRowCategoria);
                    }
                    else
                    {
                        dgvListadocategoria.DataSource = Buscat.Filtrarcategorianombre
                            (Nombre, rowCategoria, maxRowCategoria);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                tslblPaginacion.Text = currenPageCategoria + " / " + paginaCategoria;
            }
        }

        /// <summary>
        /// Lista categoria Por criterios de busqueda
        /// </summary>
        public void listarCategoria()
        {
            int criterio1 = Convert.ToInt32(this.cbxbuscar.SelectedValue);
            int criterio2 = Convert.ToInt32(this.cbxbuscar2.SelectedValue);
            if (!String.IsNullOrEmpty(txtbuscarporcategoria.Text))
            {
                if (criterio1 == 1 && criterio2 == 1)
                {
                    this.ConsultaCodigo(txtbuscarporcategoria.Text);
                    Iteracion = 0;
                }
                else
                {
                    if (criterio1 == 1 && criterio2 == 2)
                    {
                        this.FiltraCodigo(txtbuscarporcategoria.Text);
                    }
                    else
                    {
                        if (criterio1 == 2 && criterio2 == 1)
                        {
                            this.ConsultaNombre(txtbuscarporcategoria.Text);
                            Iteracion = 0;
                        }
                        else
                        {
                            if (criterio1 == 2 && criterio2 == 2)
                            {
                                this.FiltraNombre(txtbuscarporcategoria.Text);
                            }
                        }
                    }
                }
            }
            else
            {
                this.dgvListadocategoria.DataSource = null;
                MessageBox.Show("El campo busqueda es requerido.", "Categoria", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        /// <summary>
        /// Filtra objeto categoria por nombre
        /// </summary>
        /// <param name="nombre"></param>
        private void FiltraNombre(string nombre)
        {
            rowCategoria = 0;
            currenPageCategoria = 1;
            Iteracion = 2;
            Nombre = nombre;
            try
            {
                this.dgvListadocategoria.DataSource = Buscat.Filtrarcategorianombre
                    (nombre, rowCategoria, maxRowCategoria);
                totalRowCategoria = Buscat.RowFiltroCategoriaNombreContenga(nombre);
                if (dgvListadocategoria.RowCount == 0)
                {
                    OptionPane.MessageInformation("No se encontro ningun registro.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            paginaCategoria = totalRowCategoria / maxRowCategoria;
            if (totalRowCategoria % maxRowCategoria != 0)
                paginaCategoria++;
            if (currenPageCategoria > paginaCategoria)
                currenPageCategoria = 0;
            tslblPaginacion.Text = currenPageCategoria + " / " + paginaCategoria;
        }

        /// <summary>
        /// Filtra objeto categoria por codigo
        /// </summary>
        /// <param name="codigo"></param>
        private void FiltraCodigo(string codigo)
        {
            try
            {
                this.dgvListadocategoria.DataSource = null;
                this.dgvListadocategoria.DataSource = Buscat.FiltrarcategoriaCodigo(codigo);
                if (dgvListadocategoria.RowCount == 0)
                {
                    MessageBox.Show("No se encontro ningun registro");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// Consultar categoria por codigo
        /// </summary>
        /// <param name="codigo"></param>
        private void ConsultaCodigo(string codigo)
        {
            try
            {
                this.dgvListadocategoria.DataSource = null;
                this.dgvListadocategoria.DataSource = Buscat.consultaCategoriaCodigo(codigo);
                tslblPaginacion.Text = "1 / 1";
                if (dgvListadocategoria.RowCount == 0)
                {
                    MessageBox.Show("No se encontro ningun registro");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// Consulta categoria por nombre
        /// </summary>
        /// <param name="nombre"></param>
        private void ConsultaNombre(string nombre)
        {
            try
            {
                this.dgvListadocategoria.DataSource = null;
                this.dgvListadocategoria.DataSource = Buscat.consultarCategoriaNombre(nombre);
                tslblPaginacion.Text = "1 / 1";
                if (dgvListadocategoria.RowCount == 0)
                {
                    MessageBox.Show("No se encontro ningun registro");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// Comprueba si el codigo de la categoria existe en la base de datos.
        /// </summary>
        /// <param name="codigo">Codigo a verificar.</param>
        /// <returns></returns>
        private bool ExisteCodigoCategoria(string codigo)
        {
            try
            {
                return Buscat.existecategoria(codigo);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }

        /// <summary>
        /// validacion de los campos
        /// </summary>
        private void validacion()
        {
            this.txtCodigoCategoria_Validating(null, null);
            this.txtNombreCategoria_Validating(null, null);
            this.txtDescripcionCategoria_Validating(null, null);
        }

        /// <summary>
        /// lipia campos
        /// </summary>
        private void LimpiCampos()
        {
            this.txtCodigoCategoria.Text = "";
            this.txtNombreCategoria.Text = "";
            this.txtDescripcionCategoria.Text = "";
        }

        /// <summary>
        /// Carga el grid con los datos de las categorias.
        /// </summary>
        public void CargarGridCategorias()
        {
            btnlistarcategoria_Click_1(null, null);
        }

        private void dgvListadocategoria_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (Extencion)
            {
                DataGridViewRow row =
                    this.dgvListadocategoria.Rows[this.dgvListadocategoria.CurrentCell.RowIndex];
                DTO.Clases.Categoria miCategoria = new DTO.Clases.Categoria();
                miCategoria.CodigoCategoria = Convert.ToString(row.Cells["Column1"].Value);
                miCategoria.NombreCategoria = Convert.ToString(row.Cells["Column2"].Value);
                CompletaEventos.CapturaEventom(miCategoria);
                Extencion = false;
                this.Close();
            }
        }
    }
}