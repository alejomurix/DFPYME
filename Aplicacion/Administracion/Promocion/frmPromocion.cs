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
using CustomControl;
using Utilities;
using System.Collections;

namespace Aplicacion.Administracion.Promocion
{
    public partial class frmdescuento : Form
    {
        /// <summary>
        /// Objeto categoría.
        /// </summary>
        private DTO.Clases.Categoria MiCategoria;

        /// <summary>
        /// Objeto producto.
        /// </summary>
        private DTO.Clases.Producto MiProducto;

        /// <summary>
        /// Objeto marca
        /// </summary>
        private DTO.Clases.Marca MiMarca;

        /// <summary>
        /// Objeto del Modelo de negocios.
        /// </summary>
        private BussinesPromocion miPromocion;

        /// <summary>
        /// Objeto de modelo de negocios.
        /// </summary>
        private BussinesDescuento miDescuento;

        /// <summary>
        /// Objeto de modelo de negocios.
        /// </summary>
        private BussinesCategoria miCategoria;

        /// <summary>
        /// Objeto de modelo de negocios
        /// </summary>
        private BussinesMarca mimarca;

        /// <summary>
        /// Objeto de modelo de negocios.
        /// </summary>
        private BussinesTipoSorteo miTipo;

        /// <summary>
        /// Objeto de modelo de negocios.
        /// </summary>
        private BussinesProducto miProducto;

        /// <summary>
        /// Carga los criterios de búsqueda de promoción.
        /// </summary>
        private CargarCriterioPromocion miCriteriopromocion;

        /// <summary>
        /// Carga los criterios de búsqueda por fechas simple o periodos de fechas.
        /// </summary>
        private CargaCriterioFechaSorteo miFecha;

        /// <summary>
        /// Colección el origen de datos de un objeto.
        /// </summary>
        private DataTable miTabla;

        /// <summary>
        /// Colecciona el origen de datos de un objeto.
        /// </summary>
        private BindingSource miBindingSource;

        /// <summary>
        /// Probador de mensajes de error.
        /// </summary>
        private ErrorProvider er;

        /// <summary>
        /// Colección de objetos (categoría).
        /// </summary>
        private ArrayList arrayCategoria;

        /// <summary>
        /// Colección de objetos(Producto)
        /// </summary>
        private ArrayList arrayProducto;

        /// <summary>
        /// Determina el estado en la validación.
        /// </summary>
        private bool keyPress;

        /// <summary>
        /// Determina el estado de un contador.
        /// </summary>
        private int contador = 0;

        /// <summary>
        /// Obtiene o establece el valor del registro a seguir en la base de datos.
        /// </summary>
        private int RowPromocion;

        /// <summary>
        /// Obtiene o establece el valor máximo de registros.
        /// </summary>
        private int rowMaxPromocion;

        /// <summary>
        /// Obtiene o establece la cantidad de promociones en la base de datos.
        /// </summary>
        private long totalRowPromocion;

        /// <summary>
        /// Obtiene o establece la cantidad de las páginas.
        /// </summary>
        private long paginaPromocion;

        /// <summary>
        /// Obtiene o establece los registros de promoción.
        /// </summary>
        private int currenPagePromocion;

        /// <summary>
        /// Obtiene o establece la condición de búsqueda.
        /// </summary>
        private int interacion;

        /// <summary>
        /// Obtiene el tipo promoción en la búsqueda.
        /// </summary>
        private int idTipoConsulta;

        /// <summary>
        /// Obtiene o establece el valor de código en la búsqueda.
        /// </summary>
        private string CodigoMarcaCategoriaProducto;

        /// <summary>
        /// Obtiene la fecha inicio en la búsqueda.
        /// </summary>
        private DateTime fechaInicio;

        /// <summary>
        /// Obtiene la fecha fin en la búsqueda.
        /// </summary>
        private DateTime fechaFin;

        /// <summary>
        /// Determina el estado de la validación.
        /// </summary>
        private bool matchAPromocionar = false;

        /// <summary>
        /// Determina el estado de fecha n la validación.
        /// </summary>
        private bool fecha = false;

        /// <summary>
        /// Determina el valor consulta en la validación.
        /// </summary>
        private bool Consulta = false;

        /// <summary>
        /// Determina el valor clic en la validación.
        /// </summary>
        private bool click = false;

        public frmdescuento()
        {
            InitializeComponent();
            miPromocion = new BussinesPromocion();
            miDescuento = new BussinesDescuento();
            miTipo = new BussinesTipoSorteo();
            miProducto = new BussinesProducto();
            miCategoria = new BussinesCategoria();
            miTabla = CrearTablePromocion();
            miBindingSource = new BindingSource();
            er = new ErrorProvider();
            miCriteriopromocion = new CargarCriterioPromocion();
            miFecha = new CargaCriterioFechaSorteo();
            rowMaxPromocion = 6;

        }



        private void frmdescuento_Load(object sender, EventArgs e)
        {
            CompletaEventos.Completam += new CompletaEventos.CompletaAccionm(CompletaEventosm_Completo);
            CargarComboBox();
            CargarLinkBox();
            dgvPromocion.AutoGenerateColumns = false;
            dgvPromocion.DataSource = miBindingSource;
            cbxCriterioFecha.DataSource = miCriteriopromocion.listacriteriopromocion;
            lblCategoriamarcaProducto.Text = "Seleccione la marca";
            btnBuscar.Location = new Point(611, 31);
            txtListarPromocionCategoriaPoductoMarca.Enabled = false;

        }

        private void tsbtnGuardarPromocion_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (DataRow row in miTabla.Rows)
                {
                    var mIPromocion = new DTO.Clases.Promocion();
                    mIPromocion.idTipo = Convert.ToInt32(row["IdTipo"]);
                    mIPromocion.idDescuento = Convert.ToInt32(row["IdDescuento"]);
                    mIPromocion.fechaInicio = Convert.ToDateTime(row["FechaInicio"]);
                    mIPromocion.fechaFin = Convert.ToDateTime(row["FechaFin"]);
                    if (mIPromocion.idTipo == 2)
                    {
                        mIPromocion.Marca = Convert.ToInt32(row["Codigo"]);
                    }
                    else
                    {
                        if (mIPromocion.idTipo == 3)
                        {
                            mIPromocion.Categoria = Convert.ToString(row["Codigo"]);
                        }
                        else
                        {
                            if (mIPromocion.idTipo == 4)
                            {
                                mIPromocion.cantidad = Convert.ToInt32(row["Cantidad"]);
                                mIPromocion.Producto = Convert.ToString(row["Codigo"]);
                            }
                        }
                    }
                    miPromocion.InsertarPromocion(mIPromocion);
                }
                OptionPane.MessageInformation("Se a guardado exitosamente");
                if (miTabla.Rows.Count != 0)
                {
                    miTabla.Rows.Clear();
                }
                while (dgvPromocion.RowCount != 0)
                {
                    dgvPromocion.Rows.RemoveAt(0);
                }
            }
            catch (Exception ex)
            {
                OptionPane.MessageError("Error al guardar el sorteo" + ex.Message);
            }
        }

        private void tsbtnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvResultado.RowCount != 0)
            {
                DialogResult r = (MessageBox.Show("Desea eliminar el registro", "Eliminar"
                    , MessageBoxButtons.OKCancel, MessageBoxIcon.Information));
                if (r == DialogResult.OK)
                {
                    try
                    {
                        var id = (int)dgvResultado.CurrentRow.Cells["idPromocion"].Value;
                        miPromocion.EliminaPromocion(id);

                        dgvResultado.Rows.RemoveAt(dgvResultado.CurrentCell.RowIndex);
                        OptionPane.MessageInformation("Se a eliminado con exito.");
                    }
                    catch (Exception ex)
                    {
                        OptionPane.MessageError(ex.Message);
                    }
                }
            }
            else
            {
                OptionPane.MessageInformation("No hay registros a eliminar.");
            }
        }

        private void tsbtnModificar_Click(object sender, EventArgs e)
        {
            if (dgvResultado.RowCount != 0)
            {
                frmEditarPromocion editaPromocion = new frmEditarPromocion();
                var id = (int)dgvResultado.CurrentRow.Cells["idPromocion"].Value;
                var idTipo = (int)dgvResultado.CurrentRow.Cells["idTipo"].Value;
                editaPromocion.CargarPromocion(id, idTipo);
                editaPromocion.Show();
            }
            else
            {
                OptionPane.MessageInformation("No hay registros a modificar.");
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
          
            var tipo = (int)cbxTipo.SelectedValue;
            var criterioFecha = (int)cbxCriterioFecha.SelectedValue;

            if (tipo == 2)
            {
                if (cbxListarTodo.Checked)
                {
                    if (criterioFecha == 1)
                    {                       
                        ConsultarPromocionMarcaFechas(tipo, dtpfechaIni.Value);
                    }
                    else
                    {                       
                        ConsultarPromocionMarcaPeriodo(tipo, dtpfechaIni.Value, dtpFechaFi.Value);
                    }
                }
                else
                {
                    if (MiMarca != null)
                    {
                        er.SetError(txtListarPromocionCategoriaPoductoMarca, null);
                        if (criterioFecha == 1)
                        {
                            
                            ConsultarPromocionMarcaFechas(tipo, MiMarca.IdMarca, dtpfechaIni.Value);
                        }
                        else
                        {
                            CodigoMarcaCategoriaProducto = Convert.ToString(MiMarca.IdMarca);
                            ConsultarPromocionMarcaPeriodo(tipo, MiMarca.IdMarca, dtpfechaIni.Value, dtpFechaFi.Value);
                        }
                    }
                    else
                    {
                        er.SetError(txtListarPromocionCategoriaPoductoMarca, "El campo es requerido.");
                    }
                }
            }
            else
            {
                if (tipo == 3)
                {
                    if (cbxListarTodo.Checked)
                    {
                        if (criterioFecha == 1)
                        {                           
                            ConsultarPromocionCategoriaFechas(tipo, dtpfechaIni.Value);
                        }
                        else
                        {
                            ConsultarPromocionCategoriaPeriodo(tipo, dtpfechaIni.Value, dtpFechaFi.Value);
                        }
                    }
                    else
                    {
                        if (MiCategoria != null)
                        {
                            er.SetError(txtListarPromocionCategoriaPoductoMarca, null);
                            if (criterioFecha == 1)
                            {
                                ConsultarPromocionCategoriaFechas(tipo, MiCategoria.CodigoCategoria, dtpfechaIni.Value);
                            }
                            else
                            {
                                CodigoMarcaCategoriaProducto = Convert.ToString(MiCategoria.CodigoCategoria);
                                ConsultarPromocionCategoriaPeriodo(tipo, MiCategoria.CodigoCategoria, dtpfechaIni.Value, dtpFechaFi.Value);
                            }
                        }
                        else
                        {
                            er.SetError(txtListarPromocionCategoriaPoductoMarca, "El campo es requerido");
                        }
                    }
                }
                else
                {
                    if (tipo == 4)
                    {
                        if (cbxListarTodo.Checked)
                        {
                            if (criterioFecha == 1)
                            {
                                ConsultarPromocionProductoFechas(tipo, dtpfechaIni.Value);
                            }
                            else
                            {
                                ConsultarPromocionProductoPeriodo(tipo,dtpfechaIni.Value,dtpFechaFin.Value);
                            }
                        }
                        else
                        {
                            if (MiProducto != null)
                            {
                                er.SetError(txtListarPromocionCategoriaPoductoMarca, null);
                                if (criterioFecha == 1)
                                {
                                    ConsultarPromocionProductoFechas(tipo, MiProducto.CodigoInternoProducto, dtpfechaIni.Value);
                                }
                                else
                                {
                                    CodigoMarcaCategoriaProducto = Convert.ToString(MiProducto.CodigoInternoProducto);
                                    ConsultarPromocionProductoPeriodo(tipo, MiProducto.CodigoInternoProducto, dtpfechaIni.Value, dtpFechaFi.Value);
                                }
                            }
                            else
                            {
                                er.SetError(txtListarPromocionCategoriaPoductoMarca, "El campo es requerido");
                            }
                        }
                    }
                }
            }
            if (dgvResultado.RowCount == 0)
            {
                OptionPane.MessageInformation("No se encontraron registros");
                LimpiaObjeto();
            }
        }

        private void btnBuscarMarcaCategoriaProducto_Click(object sender, EventArgs e)
        {
            var criterio = (int)cbxTipodePromocion.SelectedValue;
            if (criterio == 2)
            {
                Configuracion.Marcas.frmMarca marca = new Configuracion.Marcas.frmMarca();
                marca.Extension = true;
                marca.CargaGrillaMarca();
                marca.Show();
            }
            else
            {
                if (criterio == 3)
                {
                    Inventario.Categoria.FrmCategoria categoria = new Inventario.Categoria.FrmCategoria();
                    categoria.Extencion = true;
                    categoria.CargarGridCategorias();
                    categoria.Show();
                }
                else
                {
                    Inventario.Producto.FrmIngresarProducto producto =
                        new Inventario.Producto.FrmIngresarProducto();
                    producto.Show();
                }
            }
        }

        private void tsbtnEliminarRegistro_Click(object sender, EventArgs e)
        {
            if (dgvPromocion.RowCount != 0)
            {
                var id = (int)dgvPromocion.CurrentRow.Cells["Id"].Value;
                var row = (from registro in miTabla.AsEnumerable()
                           where registro.Field<int>("Id") == id
                           select registro);
                DataRow delete = null;
                foreach (DataRow r in row)
                {
                    delete = r;
                }
                miTabla.Rows.Remove(delete);
                if (miTabla.Rows.Count != 0)
                {
                    RecargarGridview();
                }
                else
                {
                    dgvPromocion.Rows.RemoveAt(dgvPromocion.CurrentCell.RowIndex);
                }
            }
            else
            {
                OptionPane.MessageInformation("No hay registros a eliminar.");
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            var obj = false;
            Revalidar();
            
            if (fecha)
            {
                var IdTipo = (int)cbxTipodePromocion.SelectedValue;
                if (IdTipo == 2)
                {
                    if (MiMarca != null)
                    {
                        obj = true;
                        er.SetError(txtagregarMarcaCategoriaProducto, null);
                    }
                    else
                    {
                        obj = false;
                        er.SetError(txtagregarMarcaCategoriaProducto, "El campo es requerido.");
                    }
                }
                else
                {
                    if (IdTipo == 3)
                    {
                        if (MiCategoria != null)
                        {
                            obj = true;
                            er.SetError(txtagregarMarcaCategoriaProducto, null);
                        }
                        else
                        {
                            obj = false;
                            er.SetError(txtagregarMarcaCategoriaProducto, "El campo es requerido.");
                        }
                    }
                    else
                    {
                        if (matchAPromocionar)
                        {
                            if (MiProducto != null)
                            {
                                obj = true;
                                er.SetError(txtagregarMarcaCategoriaProducto, null);
                            }
                            else
                            {
                                obj = false;
                                er.SetError(txtagregarMarcaCategoriaProducto, "El campo es requerido.");
                            }
                        }
                    }

                }
                if (IdTipo == 4)
                {
                    if (obj && matchAPromocionar)
                    {

                        if (!ExistePromocion())
                        {
                            CargarRegistro();
                        }
                        else
                        {
                            OptionPane.MessageError("Ya existe un registro con este tipo de promocion.");
                        }
                    }
                }
                else
                {
                    if (obj)
                    {
                        if (!ExistePromocion())
                        {
                            CargarRegistro();
                        }
                        else
                        {
                            OptionPane.MessageError("Ya existe un registro con este tipo de promocion.");
                        }
                    }
                }
            }
        }

        private void tsbtnsalir_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void tsbtnsal_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnBuscarListar_Click(object sender, EventArgs e)
        {
            Consulta = true;
            var tipo = (int)cbxTipo.SelectedValue;
            if (tipo == 2)
            {
                Configuracion.Marcas.frmMarca miMarca = new Configuracion.Marcas.frmMarca();
                miMarca.Extension = true;
                miMarca.CargaGrillaMarca();
                miMarca.Show();
            }
            else
            {
                if (tipo == 3)
                {
                    Inventario.Categoria.FrmCategoria miCategoria = new Inventario.Categoria.FrmCategoria();
                    miCategoria.Extencion = true;
                    miCategoria.CargarGridCategorias();
                    miCategoria.Show();
                }
                else
                {
                    Inventario.Producto.FrmIngresarProducto miProducto = new Inventario.Producto.FrmIngresarProducto();
                    miProducto.Show();
                }
            }
        }

        private void tsbtnInicio_Click(object sender, EventArgs e)
        {
            //pagina de inicio
            if (currenPagePromocion > 1)
            {
                var paginaActual = currenPagePromocion;
                for (int i = paginaActual; i > 1; i--)
                {
                    RowPromocion = RowPromocion - rowMaxPromocion;
                    currenPagePromocion--;
                }
                try
                {
                    if (interacion == 1)
                    {
                        dgvResultado.DataSource = miPromocion.ConsultarPromocionMarcaFechas
                                (idTipoConsulta, fechaInicio, RowPromocion, rowMaxPromocion);                       
                    }
                    else
                    {
                        if (interacion == 2)
                        {
                            dgvResultado.DataSource = miPromocion.ConsultarPromocionMarcaPeriodo
                            (idTipoConsulta, Convert.ToInt32(CodigoMarcaCategoriaProducto), fechaInicio, fechaFin, RowPromocion, rowMaxPromocion);
                        }
                        else
                        {
                            if (interacion == 3)
                            {
                                dgvResultado.DataSource = miPromocion.ConsultarPromocionMarcaPeriodo
                                    (idTipoConsulta, fechaInicio, fechaFin, RowPromocion, rowMaxPromocion);
                            }
                            else
                            {
                                if (interacion == 4)
                                {
                                    dgvResultado.DataSource = miPromocion.ConsultarPromocionCategoriaFechas
                                            (idTipoConsulta, fechaInicio, RowPromocion, rowMaxPromocion);
                                   
                                }
                                else
                                {
                                    if (interacion == 5)
                                    {
                                        dgvResultado.DataSource = miPromocion.ConsultarPromocionCategoriaPeriodo
                                          (idTipoConsulta, CodigoMarcaCategoriaProducto, fechaInicio, fechaFin, RowPromocion, rowMaxPromocion);   
                                    }
                                    else
                                    {
                                        if (interacion == 6)
                                        {
                                            dgvResultado.DataSource = miPromocion.ConsultarPromocionCategoriaPeriodo
                                                (idTipoConsulta, fechaInicio, fechaFin, RowPromocion, rowMaxPromocion);
                                        }
                                        else
                                        {
                                            if (interacion == 7)
                                            {
                                                dgvResultado.DataSource = miPromocion.ConsultarPromocionProductoFechas
                                                    (idTipoConsulta, fechaInicio, RowPromocion, rowMaxPromocion);                                                
                                            }
                                            else
                                            {
                                                if (interacion == 8)
                                                {
                                                    dgvResultado.DataSource = miPromocion.ConsultarPromocionProductoFechas
                                                    (idTipoConsulta, fechaInicio, RowPromocion, rowMaxPromocion);
                                                }
                                                else
                                                {
                                                    if (interacion == 9)
                                                    {
                                                        dgvResultado.DataSource = miPromocion.ConsultarPromocionProductoPeriodo
                                                            (idTipoConsulta, fechaInicio, fechaFin, RowPromocion, rowMaxPromocion);
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    OptionPane.MessageError(ex.Message);
                }
                tslblConteo.Text = currenPagePromocion + " / " + paginaPromocion;
            }
        }

        private void tsbtnAtras_Click(object sender, EventArgs e)
        {
            //retrosede a la pagina anterior
            if (currenPagePromocion > 1)
            {
                try
                {
                    RowPromocion = RowPromocion - rowMaxPromocion;
                    if (RowPromocion <= 0)
                        RowPromocion = 0;
                    if (interacion == 1)
                    {
                        dgvResultado.DataSource = miPromocion.ConsultarPromocionMarcaFechas
                                (idTipoConsulta, fechaInicio, RowPromocion, rowMaxPromocion);
                    }
                    else
                    {
                        if (interacion == 2)
                        {
                            dgvResultado.DataSource = miPromocion.ConsultarPromocionMarcaPeriodo
                            (idTipoConsulta, Convert.ToInt32(CodigoMarcaCategoriaProducto), fechaInicio, fechaFin, RowPromocion, rowMaxPromocion);
                        }
                        else
                        {
                            if (interacion == 3)
                            {
                                dgvResultado.DataSource = miPromocion.ConsultarPromocionMarcaPeriodo
                                    (idTipoConsulta, fechaInicio, fechaFin, RowPromocion, rowMaxPromocion);
                            }
                            else
                            {
                                if (interacion == 4)
                                {
                                    dgvResultado.DataSource = miPromocion.ConsultarPromocionCategoriaFechas
                                            (idTipoConsulta, fechaInicio, RowPromocion, rowMaxPromocion);

                                }
                                else
                                {
                                    if (interacion == 5)
                                    {
                                        dgvResultado.DataSource = miPromocion.ConsultarPromocionCategoriaPeriodo
                                          (idTipoConsulta, CodigoMarcaCategoriaProducto, fechaInicio, fechaFin, RowPromocion, rowMaxPromocion);
                                    }
                                    else
                                    {
                                        if (interacion == 6)
                                        {
                                            dgvResultado.DataSource = miPromocion.ConsultarPromocionCategoriaPeriodo
                                                (idTipoConsulta, fechaInicio, fechaFin, RowPromocion, rowMaxPromocion);
                                        }
                                        else
                                        {
                                            if (interacion == 7)
                                            {
                                                dgvResultado.DataSource = miPromocion.ConsultarPromocionProductoFechas
                                                    (idTipoConsulta, fechaInicio, RowPromocion, rowMaxPromocion);
                                            }
                                            else
                                            {
                                                if (interacion == 8)
                                                {
                                                    dgvResultado.DataSource = miPromocion.ConsultarPromocionProductoFechas
                                                    (idTipoConsulta, fechaInicio, RowPromocion, rowMaxPromocion);
                                                }
                                                else
                                                {
                                                    if (interacion == 9)
                                                    {
                                                        dgvResultado.DataSource = miPromocion.ConsultarPromocionProductoPeriodo
                                                            (idTipoConsulta, fechaInicio, fechaFin, RowPromocion, rowMaxPromocion);
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    OptionPane.MessageError(ex.Message);
                }
                currenPagePromocion--;
                tslblConteo.Text = currenPagePromocion + " / " + paginaPromocion;
            }
        }

        private void tsbtnSiguiente_Click(object sender, EventArgs e)
        {
            // siguiente pagina
            if (currenPagePromocion < paginaPromocion)
            {
                RowPromocion = RowPromocion + rowMaxPromocion;
                try
                {
                    if (interacion == 1)
                    {
                        dgvResultado.DataSource = miPromocion.ConsultarPromocionMarcaFechas
                                (idTipoConsulta, fechaInicio, RowPromocion, rowMaxPromocion);
                    }
                    else
                    {
                        if (interacion == 2)
                        {
                            dgvResultado.DataSource = miPromocion.ConsultarPromocionMarcaPeriodo
                            (idTipoConsulta, Convert.ToInt32(CodigoMarcaCategoriaProducto), fechaInicio, fechaFin, RowPromocion, rowMaxPromocion);
                        }
                        else
                        {
                            if (interacion == 3)
                            {
                                dgvResultado.DataSource = miPromocion.ConsultarPromocionMarcaPeriodo
                                    (idTipoConsulta, fechaInicio, fechaFin, RowPromocion, rowMaxPromocion);
                            }
                            else
                            {
                                if (interacion == 4)
                                {
                                    dgvResultado.DataSource = miPromocion.ConsultarPromocionCategoriaFechas
                                            (idTipoConsulta, fechaInicio, RowPromocion, rowMaxPromocion);

                                }
                                else
                                {
                                    if (interacion == 5)
                                    {
                                        dgvResultado.DataSource = miPromocion.ConsultarPromocionCategoriaPeriodo
                                          (idTipoConsulta, CodigoMarcaCategoriaProducto, fechaInicio, fechaFin, RowPromocion, rowMaxPromocion);
                                    }
                                    else
                                    {
                                        if (interacion == 6)
                                        {
                                            dgvResultado.DataSource = miPromocion.ConsultarPromocionCategoriaPeriodo
                                                (idTipoConsulta, fechaInicio, fechaFin, RowPromocion, rowMaxPromocion);
                                        }
                                        else
                                        {
                                            if (interacion == 7)
                                            {
                                                dgvResultado.DataSource = miPromocion.ConsultarPromocionProductoFechas
                                                    (idTipoConsulta, fechaInicio, RowPromocion, rowMaxPromocion);
                                            }
                                            else
                                            {
                                                if (interacion == 8)
                                                {
                                                    dgvResultado.DataSource = miPromocion.ConsultarPromocionProductoFechas
                                                    (idTipoConsulta, fechaInicio, RowPromocion, rowMaxPromocion);
                                                }
                                                else
                                                {
                                                    if (interacion == 9)
                                                    {
                                                        dgvResultado.DataSource = miPromocion.ConsultarPromocionProductoPeriodo
                                                            (idTipoConsulta, fechaInicio, fechaFin, RowPromocion, rowMaxPromocion);
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    OptionPane.MessageError(ex.Message);
                }
                currenPagePromocion++;
                tslblConteo.Text = currenPagePromocion + " / " + paginaPromocion;
            }
        }

        private void tsbtnFinal_Click(object sender, EventArgs e)
        {
            //ultima pagina
            if (currenPagePromocion < paginaPromocion)
            {
                var paginaActual = currenPagePromocion;
                for (int i = paginaActual; i < paginaPromocion; i++)
                {
                    RowPromocion = RowPromocion + rowMaxPromocion;
                    currenPagePromocion++;
                }
                try
                {
                    if (interacion == 1)
                    {
                        dgvResultado.DataSource = miPromocion.ConsultarPromocionMarcaFechas
                                (idTipoConsulta, fechaInicio, RowPromocion, rowMaxPromocion);
                    }
                    else
                    {
                        if (interacion == 2)
                        {
                            dgvResultado.DataSource = miPromocion.ConsultarPromocionMarcaPeriodo
                            (idTipoConsulta, Convert.ToInt32(CodigoMarcaCategoriaProducto), fechaInicio, fechaFin, RowPromocion, rowMaxPromocion);
                        }
                        else
                        {
                            if (interacion == 3)
                            {
                                dgvResultado.DataSource = miPromocion.ConsultarPromocionMarcaPeriodo
                                    (idTipoConsulta, fechaInicio, fechaFin, RowPromocion, rowMaxPromocion);
                            }
                            else
                            {
                                if (interacion == 4)
                                {
                                    dgvResultado.DataSource = miPromocion.ConsultarPromocionCategoriaFechas
                                            (idTipoConsulta, fechaInicio, RowPromocion, rowMaxPromocion);

                                }
                                else
                                {
                                    if (interacion == 5)
                                    {
                                        dgvResultado.DataSource = miPromocion.ConsultarPromocionCategoriaPeriodo
                                          (idTipoConsulta, CodigoMarcaCategoriaProducto, fechaInicio, fechaFin, RowPromocion, rowMaxPromocion);
                                    }
                                    else
                                    {
                                        if (interacion == 6)
                                        {
                                            dgvResultado.DataSource = miPromocion.ConsultarPromocionCategoriaPeriodo
                                                (idTipoConsulta, fechaInicio, fechaFin, RowPromocion, rowMaxPromocion);
                                        }
                                        else
                                        {
                                            if (interacion == 7)
                                            {
                                                dgvResultado.DataSource = miPromocion.ConsultarPromocionProductoFechas
                                                    (idTipoConsulta, fechaInicio, RowPromocion, rowMaxPromocion);
                                            }
                                            else
                                            {
                                                if (interacion == 8)
                                                {
                                                    dgvResultado.DataSource = miPromocion.ConsultarPromocionProductoFechas
                                                    (idTipoConsulta, fechaInicio, RowPromocion, rowMaxPromocion);
                                                }
                                                else
                                                {
                                                    if (interacion == 9)
                                                    {
                                                        dgvResultado.DataSource = miPromocion.ConsultarPromocionProductoPeriodo
                                                            (idTipoConsulta, fechaInicio, fechaFin, RowPromocion, rowMaxPromocion);
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    OptionPane.MessageError(ex.Message);
                }
                tslblConteo.Text = currenPagePromocion + " / " + paginaPromocion;
            }
        }

        private void txtagregarMarcaCategoriaProducto_KeyPress(object sender, KeyPressEventArgs e)
        {
            var tipo = (int)cbxTipodePromocion.SelectedValue;

            if (e.KeyChar == (char)Keys.Enter)
            {
                if (ValidaCodigo() || ValidaBarras())
                {
                    if (Existe(txtagregarMarcaCategoriaProducto.Text, tipo))
                    {
                        cargar(tipo, false);
                        txtagregarMarcaCategoriaProducto.Text = "";
                        er.SetError(txtagregarMarcaCategoriaProducto, null);
                        keyPress = true;
                        lbxDescuento.Focus();
                    }
                    else
                    {
                        OptionPane.MessageInformation("No existe el codigo en la base de datos.");
                        txtagregarMarcaCategoriaProducto.Text = "";
                        er.SetError(txtagregarMarcaCategoriaProducto, "No existe el codigo en la base de datos.");
                        txtagregarMarcaCategoriaProducto.Focus();
                    }
                }
                else
                {
                    lbxDescuento.Focus();
                }
            }
            else
            {
                keyPress = false;
            }

        }

        private void txtListarPromocionCategoriaPoductoMarca_KeyPress(object sender, KeyPressEventArgs e)
        {
            var tipo = (int)cbxTipo.SelectedValue;
            if (e.KeyChar == (char)Keys.Enter)
            {
                if (ValidaCod() || ValidaBar())
                {
                    if (Existe(txtListarPromocionCategoriaPoductoMarca.Text, tipo))
                    {
                        cargar(tipo, true);
                        txtListarPromocionCategoriaPoductoMarca.Text = "";
                        er.SetError(txtListarPromocionCategoriaPoductoMarca, null);
                        keyPress = true;
                        btnBuscar.Focus();
                    }
                    else
                    {
                        OptionPane.MessageInformation("No existe el codigo dentro de la base de datos.");
                        txtListarPromocionCategoriaPoductoMarca.Text = "";
                        er.SetError(txtListarPromocionCategoriaPoductoMarca, "No existe el codigo dentro de la base de datos.");
                        txtListarPromocionCategoriaPoductoMarca.Focus();
                    }
                }
                else
                {
                    txtListarPromocionCategoriaPoductoMarca.Focus();
                }
            }
            else
            {
                keyPress = false;
            }
        }

        private void txtagregarMarcaCategoriaProducto_Validating(object sender, CancelEventArgs e)
        {
            var tipo = (int)cbxTipodePromocion.SelectedValue;
            if (!keyPress)
            {
                if (ValidaCodigo() || ValidaBarras())
                {
                    if (Existe(txtagregarMarcaCategoriaProducto.Text, tipo))
                    {
                        cargar(tipo, false);
                        er.SetError(txtagregarMarcaCategoriaProducto, null);
                        lbxDescuento.Focus();
                    }
                    else
                    {
                        er.SetError(txtagregarMarcaCategoriaProducto, "El codigo ingresado no esta dentro de la base de datos.");
                        lbxDescuento.Focus();
                    }
                }
                else
                {
                    txtagregarMarcaCategoriaProducto.Focus();
                }
            }
        }

        private void txtListarPromocionCategoriaPoductoMarca_Validating(object sender, CancelEventArgs e)
        {
            var tipo = (int)cbxTipo.SelectedValue;
            if (!keyPress)
            {
                if (ValidaCod() || ValidaBar())
                {
                    if (Existe(txtListarPromocionCategoriaPoductoMarca.Text, tipo))
                    {
                        cargar(tipo, false);
                        er.SetError(txtListarPromocionCategoriaPoductoMarca, null);
                        btnBuscar.Focus();
                    }
                    else
                    {
                        er.SetError(txtListarPromocionCategoriaPoductoMarca, "El codigo ingresado no esta dentro de la base de datos.");
                        txtListarPromocionCategoriaPoductoMarca.Focus();
                    }
                }
                else
                {
                    txtListarPromocionCategoriaPoductoMarca.Focus();
                }
            }
        }

        private void txtAPromocionar_Validating(object sender, CancelEventArgs e)
        {

            var criterio = (int)cbxTipodePromocion.SelectedValue;
            if (criterio == 4)
            {
                if (!String.IsNullOrEmpty(txtAPromocionar.Text))
                {
                    if (Validacion.ConFormato(Validacion.TipoValidacion.Numeros, txtAPromocionar, er, "Formato incorrecto"))
                    {
                        matchAPromocionar = true;
                        er.SetError(txtAPromocionar, null);
                    }
                    else
                        matchAPromocionar = false;
                }
                else
                {
                    er.SetError(txtAPromocionar, "El campo es requerido");
                    matchAPromocionar = false;
                }
            }
        }

        private void dtpFechaFin_Validating(object sender, CancelEventArgs e)
        {
            var fechaInicio = new DateTime(dtpFechaInicio.Value.Year, dtpFechaInicio.Value.Month, dtpFechaInicio.Value.Day);
            var fechaFin = new DateTime(dtpFechaFin.Value.Year, dtpFechaFin.Value.Month, dtpFechaFin.Value.Day);
            if (fechaInicio <= fechaFin)
            {
                fecha = true;
                er.SetError(dtpFechaFin, null);
            }
            else
            {
                fecha = false;
                er.SetError(dtpFechaFin, "La fecha de inicio debe ser menor a la fecha final");
            }
        }

        private void cbxTipodePromocion_SelectionChangeCommitted(object sender, EventArgs e)
        {
            var criterio = (int)cbxTipodePromocion.SelectedValue;
            if (criterio == 2)
            {
                lblCategoriamarcaProducto.Text = "Seleccione la marca";
                txtagregarMarcaCategoriaProducto.Enabled = false;
                lblMarcaCategoriaProducto.Text = "";
                txtAPromocionar.Enabled = false;
            }
            else
            {
                if (criterio == 3)
                {
                    lblCategoriamarcaProducto.Text = "Seleccione la categoria";
                    txtagregarMarcaCategoriaProducto.Enabled = true;
                    txtagregarMarcaCategoriaProducto.Text = "";
                    lblMarcaCategoriaProducto.Text = "";
                    txtAPromocionar.Enabled = false;
                }
                else
                {
                    if (criterio == 4)
                    {
                        lblCategoriamarcaProducto.Text = "Seleccione el producto";
                        txtagregarMarcaCategoriaProducto.Enabled = true;
                        txtagregarMarcaCategoriaProducto.Text = "";
                        lblMarcaCategoriaProducto.Text = "";
                        txtAPromocionar.Enabled = true;
                    }
                }

            }
        }

        private void cbxCriterioFecha_SelectionChangeCommitted(object sender, EventArgs e)
        {
            var criterioFecha = (int)cbxCriterioFecha.SelectedValue;
            if (criterioFecha == 1)
            {
                dtpFechaFi.Visible = false;
                btnBuscar.Location = new Point(611, 31);

            }
            else
            {
                dtpFechaFi.Visible = true;
                btnBuscar.Location = new Point(705, 31);
            }
        }

        private void cbxListarTodo_Click(object sender, EventArgs e)
        {
            if (cbxListarTodo.Checked)
            {
                txtListarPromocionCategoriaPoductoMarca.Enabled = false;
                btnBuscarListar.Enabled = false;
                dtpFechaFi.Visible = false;
                btnBuscarListar.Enabled = false;
                btnBuscar.Location = new Point(611, 31);
            }
            else
            {
                txtListarPromocionCategoriaPoductoMarca.Enabled = true;
                btnBuscarListar.Enabled = true;
            }
        }

        private void cbxTipo_SelectionChangeCommitted(object sender, EventArgs e)
        {
            var tipo = (int)cbxTipo.SelectedValue;
            if (tipo == 2)
            {
                LimpiaObjeto();
                if (cbxListarTodo.Checked)
                {
                    txtListarPromocionCategoriaPoductoMarca.Enabled = false;
                    btnBuscarListar.Enabled = false;
                }
                else
                {
                    txtListarPromocionCategoriaPoductoMarca.Enabled = false;
                    btnBuscarListar.Enabled = true;
                }
            }
            else
            {
                if (tipo == 3)
                {
                    LimpiaObjeto();
                    if (cbxListarTodo.Checked)
                    {
                        txtListarPromocionCategoriaPoductoMarca.Enabled = false;
                        btnBuscarListar.Enabled = false;
                    }
                    else
                    {
                        txtListarPromocionCategoriaPoductoMarca.Enabled = true;
                        btnBuscarListar.Enabled = true;
                    }
                }
                else
                {
                    LimpiaObjeto();
                    if (cbxListarTodo.Checked)
                    {
                        txtListarPromocionCategoriaPoductoMarca.Enabled = false;
                        btnBuscarListar.Enabled = false;
                    }
                    else
                    {
                        txtListarPromocionCategoriaPoductoMarca.Enabled = true;
                        btnBuscarListar.Enabled = true;
                    }
                }

            }

        }

        /// <summary>
        /// Carga combo box de tipo de promoción;
        /// </summary>
        private void CargarComboBox()
        {
            try
            {
                cbxTipodePromocion.DataSource = miTipo.ListaTipoPromocion();
                cbxTipo.DataSource = miTipo.ListaTipoPromocion();

            }
            catch (Exception ex)
            {
                OptionPane.MessageError("Error al cargar el tipo de promocion" + ex.Message);
            }
        }

        /// <summary>
        /// Carga link box de descuento.
        /// </summary>
        private void CargarLinkBox()
        {
            try
            {
                lbxDescuento.DataSource = miDescuento.ListadoDescuento();
            }
            catch (Exception ex)
            {
                OptionPane.MessageError("Error al cargar lista de descuento." + ex.Message);
            }
        }

        /// <summary>
        /// Valida el campo de búsqueda por código.
        /// </summary>
        /// <returns></returns>
        private bool ValidaCodigo()
        {
            var validaCodigo = false;

            if (!Validacion.EsVacio(txtagregarMarcaCategoriaProducto, er, "Campo requerido"))
            {
                if (Validacion.ConFormato(Validacion.TipoValidacion.NumeroEspacionGuion, txtagregarMarcaCategoriaProducto, er, "Formato incorecto."))
                {
                    return validaCodigo = true;
                }
            }
            return validaCodigo = false;
        }

        /// <summary>
        /// valida el campo de búsqueda por barras.
        /// </summary>
        /// <returns></returns>
        private bool ValidaBarras()
        {
            var validabarras = false;
            if (!Validacion.EsVacio(txtagregarMarcaCategoriaProducto, er, "El campo es requerido"))
            {
                if (Validacion.ConFormato(Validacion.TipoValidacion.Numeros, txtagregarMarcaCategoriaProducto, er, "FormatoIncorrecto"))
                {
                    return validabarras = true;
                }
            }
            return validabarras = false;
        }

        /// <summary>
        /// valida campo vacío y formato
        /// </summary>
        /// <returns></returns>
        private bool ValidaCod()
        {
            var validaCod = false;
            if (!Validacion.EsVacio(txtListarPromocionCategoriaPoductoMarca, er, "El campo es requerido"))
            {
                if (Validacion.ConFormato(Validacion.TipoValidacion.NumeroEspacionGuion, txtListarPromocionCategoriaPoductoMarca, er, "Formato incorrecto")) 
                {
                    return validaCod = true;
                }
            }
            return validaCod = false;
        }

        /// <summary>
        /// valida campo vacío y formato
        /// </summary>
        /// <returns></returns>
        private bool ValidaBar()
        {
            var validaBar = false;
            if (!Validacion.EsVacio(txtListarPromocionCategoriaPoductoMarca, er, "El campo es requerido"))
            {
                if (Validacion.ConFormato(Validacion.TipoValidacion.Numeros, txtListarPromocionCategoriaPoductoMarca, er, "Formato incorrecto"))
                {
                    return validaBar = true;
                }
            }
            return validaBar = false;
        }

        /// <summary>
        /// Comprueba si el código ingresado en la búsqueda esta
        /// </summary>
        /// <returns></returns>
        private bool Existe(string codigo, int idTipo)
        {
            try
            {
                if (idTipo == 3)
                {

                    var codigoCategoria = miCategoria.existecategoria(codigo);
                    if (codigoCategoria)
                    {
                        return true;
                    }

                }
                else
                {
                    if (idTipo == 4)
                    {

                        var codex = miProducto.ExisteCodigo(codigo);
                        var barras = miProducto.ExisteCodigoBarras(codigo);
                        if (codex || barras)
                        {
                            return true;
                        }
                    }
                }

                return false;
            }

            catch (Exception ex)
            {
                OptionPane.MessageInformation("Error de busqueda." + ex.Message);
                return false;
            }
        }

        /// <summary>
        /// Carga la búsqueda en el label categoría marca producto
        /// </summary>        
        private void cargar(int idTipo, bool consulta)
        {
            try
            {
                if (idTipo == 3)
                {
                    if (consulta)
                    {
                        arrayCategoria = miCategoria.consultaCategoriaCodigo(txtListarPromocionCategoriaPoductoMarca.Text);
                    }
                    else
                    {
                        arrayCategoria = miCategoria.consultaCategoriaCodigo(txtagregarMarcaCategoriaProducto.Text);
                    }
                    MiCategoria = (DTO.Clases.Categoria)arrayCategoria[0];
                    if (consulta)
                    {
                        lblListarMarcaCategoriaProducto.Text = MiCategoria.CodigoCategoria + " - " + MiCategoria.NombreCategoria;
                    }
                    else
                    {
                        lblMarcaCategoriaProducto.Text = MiCategoria.CodigoCategoria + " - " + MiCategoria.NombreCategoria;
                    }
                }
                else
                {
                    if (idTipo == 4)
                    {
                        if (consulta)
                        {
                            arrayProducto = miProducto.ProductoBasico(txtListarPromocionCategoriaPoductoMarca.Text);
                        }
                        else
                        {
                            arrayProducto = miProducto.ProductoBasico(txtagregarMarcaCategoriaProducto.Text);
                        }
                        MiProducto = (DTO.Clases.Producto)arrayProducto[0];
                        if (consulta)
                        {
                            lblListarMarcaCategoriaProducto.Text = MiProducto.CodigoInternoProducto + " - " + MiProducto.NombreProducto;
                        }
                        else
                        {
                            lblMarcaCategoriaProducto.Text = MiProducto.CodigoInternoProducto + "-" + MiProducto.NombreProducto;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                OptionPane.MessageError("Error de carga" + ex.Message);
            }
        }

        /// <summary>
        /// objeto completa evento
        /// </summary>
        /// <param name="arg"></param>
        void CompletaEventosm_Completo(CompletaArgumentosDeEventom arg)
        {
            try
            {
                TransferirMarca m = (TransferirMarca)arg.MiMarca;
                var consultaM = (from datos in miTabla.AsEnumerable()
                                 where datos.Field<string>("Codigo") == m.IdMarca.ToString()
                                 select datos).ToList();

                if (consultaM.Count == 0)
                {
                    MiMarca = new Marca();
                    MiMarca.IdMarca = m.IdMarca;
                    MiMarca.NombreMarca = m.NombreMarca;
                    if (Consulta)
                    {
                        txtListarPromocionCategoriaPoductoMarca.Text = MiMarca.NombreMarca;
                        lblListarMarcaCategoriaProducto.Text = MiMarca.NombreMarca;
                    }
                    else
                    {
                        txtagregarMarcaCategoriaProducto.Text = MiMarca.NombreMarca;
                        lblMarcaCategoriaProducto.Text = MiMarca.NombreMarca;
                    }
                }
                else
                {
                    OptionPane.MessageInformation("El registro ya existe.");
                }
            }
            catch
            { }
            try
            {
                DTO.Clases.Categoria c = (DTO.Clases.Categoria)arg.MiMarca;
                var consultaC = (from datos in miTabla.AsEnumerable()
                                 where datos.Field<string>("Codigo") == c.CodigoCategoria
                                 select datos).ToList();
                if (consultaC.Count == 0)
                {
                    MiCategoria = new Categoria();
                    MiCategoria.CodigoCategoria = c.CodigoCategoria;
                    MiCategoria.NombreCategoria = c.NombreCategoria;
                    if (Consulta)
                    {
                        txtListarPromocionCategoriaPoductoMarca.Text = "";
                        lblListarMarcaCategoriaProducto.Text = MiCategoria.CodigoCategoria + " - " + MiCategoria.NombreCategoria;
                    }
                    else
                    {
                        lblMarcaCategoriaProducto.Text = MiCategoria.CodigoCategoria + " - " + MiCategoria.NombreCategoria;
                    }
                }
                else
                {
                    OptionPane.MessageInformation("El registro ya existe.");
                }
            }
            catch
            { }
            try
            {
                Producto p = (Producto)arg.MiMarca;
                var consultaP = (from datos in miTabla.AsEnumerable()
                                 where datos.Field<string>("Codigo") == p.CodigoInternoProducto
                                 select datos).ToList();
                if (consultaP.Count == 0)
                {
                    MiProducto = new Producto();
                    MiProducto.CodigoInternoProducto = p.CodigoInternoProducto;
                    MiProducto.NombreProducto = p.NombreProducto;
                    if (Consulta)
                    {
                        txtListarPromocionCategoriaPoductoMarca.Text = "";
                        lblListarMarcaCategoriaProducto.Text = MiProducto.CodigoInternoProducto + " - " + MiProducto.NombreProducto;
                    }
                    else
                    {
                        lblMarcaCategoriaProducto.Text = MiProducto.CodigoInternoProducto + " - " + MiProducto.NombreProducto;
                    }
                }
                else
                {
                    OptionPane.MessageInformation("El registro ya existe.");
                }
            }
            catch
            { }
        }

        /// <summary>
        /// Carga la tabla
        /// </summary>
        private void CargarRegistro()
        {
            try
            {
                contador++;
                var row = miTabla.NewRow();
                var idTipo = (int)cbxTipodePromocion.SelectedValue;
                row["Id"] = contador;
                row["IdTipo"] = idTipo;
                var DataRow_ = (DataRowView)cbxTipodePromocion.SelectedItem;
                row["Tipo"] = DataRow_.Row.ItemArray[1];
                if (idTipo == 2)
                {
                    row["Codigo"] = MiMarca.IdMarca.ToString();
                    row["Nombre"] = MiMarca.NombreMarca;
                    row["cantidad"] = "  --  ";
                }
                else
                {
                    if (idTipo == 3)
                    {
                        row["Codigo"] = MiCategoria.CodigoCategoria;
                        row["Nombre"] = MiCategoria.NombreCategoria;
                        row["cantidad"] = "  --  ";
                    }
                    else
                    {
                        row["codigo"] = MiProducto.CodigoInternoProducto;
                        row["Nombre"] = MiProducto.NombreProducto;
                        row["cantidad"] = txtAPromocionar.Text;
                    }
                }
                row["FechaInicio"] = dtpFechaInicio.Value.ToShortDateString();
                row["FechaFin"] = dtpFechaFin.Value.ToShortDateString();
                row["IdDescuento"] = lbxDescuento.SelectedValue;
                var descuento = (Descuento)lbxDescuento.SelectedItem;
                row["Descuento"] = descuento.ValorDescuento;
                miTabla.Rows.Add(row);
                RecargarGridview();
                LimpiaCampos();

            }
            catch
            { }
        }

        /// <summary>
        /// Recarga el datagid según la tabla.
        /// </summary>
        private void RecargarGridview()
        {
            IEnumerable<DataRow> query = from datos in miTabla.AsEnumerable()
                                         orderby datos.Field<int>("id") descending
                                         select datos;
            DataTable copy = query.CopyToDataTable<DataRow>();
            miBindingSource.DataSource = copy;
        }

        /// <summary>
        /// limpia campos de promoción.
        /// </summary>
        private void LimpiaCampos()
        {
            txtagregarMarcaCategoriaProducto.Text = "";
            lblMarcaCategoriaProducto.Text = "";
            txtAPromocionar.Text = "";
            MiProducto = null;
            MiCategoria = null;
            MiMarca = null;
        }

        /// <summary>
        /// Limpia el objeto marca categoría a producto al consultar.
        /// </summary>
        private void LimpiaObjeto()
        {
            MiMarca = null;
            MiCategoria = null;
            MiProducto = null;
            txtListarPromocionCategoriaPoductoMarca.Text = "";
            lblListarMarcaCategoriaProducto.Text = "";
        }

        /// <summary>
        /// Revalida campos.
        /// </summary>
        private void Revalidar()
        {
            txtAPromocionar_Validating(null, null);
            dtpFechaFin_Validating(null, null);
        }

        /// <summary>
        /// consultar promoción marca por fechas
        /// </summary>
        /// <param name="idTipo">id tipo de promoción (marca) a consultar</param>
        /// <param name="idMarca">id marca  a consultar</param>
        /// <param name="fecha">fecha a consultar</param>

        private void ConsultarPromocionMarcaFechas
            (int idTipo, int idMarca, DateTime fecha)
        {           
            interacion = 0;
            try
            {
                dgvResultado.DataSource = miPromocion.ConsultarPromocionMarcaFechas(idTipo, idMarca, fecha);
                tslblConteo.Text = "1/1";
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
        }

        /// <summary>
        /// Consulta promoción tipo marca
        /// </summary>
        /// <param name="idTipo">id tipo de promoción(marca) a consultar </param>
        /// <param name="fecha">fecha a consultar</param>
        private void ConsultarPromocionMarcaFechas
            (int idTipo, DateTime fecha)
        {
            idTipoConsulta = (int)cbxTipo.SelectedValue;
            fechaInicio = dtpfechaIni.Value;
            RowPromocion = 0;
            currenPagePromocion = 1;
            interacion = 1;
            try
            {
                dgvResultado.DataSource = miPromocion.ConsultarPromocionMarcaFechas
                    (idTipo, fecha, RowPromocion, rowMaxPromocion);
                totalRowPromocion = miPromocion.RowListarPromocionMarca(idTipoConsulta, fechaInicio);

            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
            paginaPromocion = totalRowPromocion / rowMaxPromocion;
            if (totalRowPromocion % rowMaxPromocion != 0)
                paginaPromocion++;
            if (currenPagePromocion > paginaPromocion)
                currenPagePromocion = 0;
            tslblConteo.Text = currenPagePromocion + " / " + paginaPromocion;
        }

        /// <summary>
        /// Consulta promoción marca periodo
        /// </summary>
        /// <param name="idTipo">id tipo de promoción(marca)  consultar</param>
        /// <param name="idMarca">id marca a consultar</param>
        /// <param name="fecha1">fecha inicio a consultar</param>
        /// <param name="fecha2">fecha final a consultar</param>

        private void ConsultarPromocionMarcaPeriodo
            (int idTipo, int idMarca, DateTime fecha1, DateTime fecha2)
        {
            idTipoConsulta = (int)cbxTipo.SelectedValue;
            fechaInicio = dtpfechaIni.Value;
            fechaFin = dtpFechaFin.Value;
            RowPromocion = 0;
            currenPagePromocion = 1;
            interacion = 2;
            try
            {
                dgvResultado.DataSource = miPromocion.ConsultarPromocionMarcaPeriodo(idTipo, idMarca, fecha1, fecha2, RowPromocion, rowMaxPromocion);
                totalRowPromocion = miPromocion.RowListarPromocionMarcafechas(idTipoConsulta, idMarca, fechaInicio, fechaFin);
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
            paginaPromocion = totalRowPromocion / rowMaxPromocion;
            if (totalRowPromocion % rowMaxPromocion != 0)
                paginaPromocion++;
            if (currenPagePromocion > paginaPromocion)
                currenPagePromocion = 0;
            tslblConteo.Text = currenPagePromocion + " / " + paginaPromocion;
        }

        /// <summary>
        /// Consulta promocion Tipo marca periodo
        /// </summary>
        /// <param name="idTipo">id tipo promocion(marca) a consultar</param>
        /// <param name="fecha1">fecha inicio a consultar</param>
        /// <param name="fecha2">fecha final a consultar</param>
        private void ConsultarPromocionMarcaPeriodo(int idTipo, DateTime fecha1, DateTime fecha2)
        {
            idTipoConsulta = (int)cbxTipo.SelectedValue;
            fechaInicio = dtpfechaIni.Value;
            fechaFin = dtpFechaFin.Value;
            RowPromocion = 0;
            currenPagePromocion = 1;
            interacion = 3;
            try
            {
                dgvResultado.DataSource = miPromocion.ConsultarPromocionMarcaPeriodo
                                         (idTipo, fecha1, fecha2, RowPromocion, rowMaxPromocion);
                totalRowPromocion = miPromocion.RowListarPromocionMarca(idTipoConsulta, fechaInicio, fechaFin);
                    
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
            paginaPromocion = totalRowPromocion / rowMaxPromocion;
            if (totalRowPromocion % rowMaxPromocion != 0)
                paginaPromocion++;
            if (currenPagePromocion > paginaPromocion)
                currenPagePromocion = 0;
            tslblConteo.Text = currenPagePromocion + " / " + paginaPromocion;
        }

        /// <summary>
        /// Consulta promocion categoria fechas
        /// </summary>
        /// <param name="idTipo">id tipo promocion(categoria) a consultar</param>
        /// <param name="codigocategoria">codigo categoria a consultar</param>
        /// <param name="fecha">fecha a consultar</param>
        private void ConsultarPromocionCategoriaFechas(int idTipo, string codigocategoria, DateTime fecha)
        {
            interacion = 0;
            try
            {
                dgvResultado.DataSource = miPromocion.ConsultarPromocionCategoriaFechas(idTipo, codigocategoria, fecha);
                tslblConteo.Text = " 1/1 ";
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
        }

        /// <summary>
        /// Consultar promocion tipo categoria fechas
        /// </summary>
        /// <param name="idtipo">id tipo promocion(categoria) a consultar</param>
        /// <param name="fecha">fecha a consultar</param>
        private void ConsultarPromocionCategoriaFechas(int idTipo, DateTime fecha)
        {
            idTipoConsulta = (int)cbxTipo.SelectedValue;
            fechaInicio = dtpfechaIni.Value;
            RowPromocion = 0;
            currenPagePromocion = 1;
            interacion = 4;
            try
            {
                dgvResultado.DataSource = miPromocion.ConsultarPromocionCategoriaFechas(idTipo, fecha, RowPromocion, rowMaxPromocion);
                totalRowPromocion = miPromocion.RowListarPromocionCategoria(idTipoConsulta, fechaInicio);
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
            paginaPromocion = totalRowPromocion / rowMaxPromocion;
            if (totalRowPromocion % rowMaxPromocion != 0)
                paginaPromocion++;
            if (currenPagePromocion > paginaPromocion)
                currenPagePromocion = 0;
            tslblConteo.Text = currenPagePromocion + " / " + paginaPromocion;
        }

        /// <summary>
        /// Consultar promocion categoria periodos
        /// </summary>
        /// <param name="idTipo">id tipo promocion(categoria) a consultar</param>
        /// <param name="codigoCategoria">codigo Categoria a consultar</param>
        /// <param name="fecha">fecha a consultar</param>
        private void ConsultarPromocionCategoriaPeriodo(int idTipo, string codigoCategoria, DateTime fecha1, DateTime fecha2)
        {
            idTipoConsulta = (int)cbxTipo.SelectedValue;
            fechaInicio = dtpfechaIni.Value;
            fechaFin = dtpFechaFin.Value;
            RowPromocion = 0;
            currenPagePromocion = 1;
            interacion = 5;
            try
            {
                dgvResultado.DataSource = miPromocion.ConsultarPromocionCategoriaPeriodo(idTipo, codigoCategoria, fecha1, fecha2,RowPromocion,rowMaxPromocion);
                totalRowPromocion = miPromocion.RowListarPromocionCategoriaFechas(idTipoConsulta, codigoCategoria, fechaInicio, fechaFin);
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
            paginaPromocion = totalRowPromocion / rowMaxPromocion;
            if (totalRowPromocion % rowMaxPromocion != 0)
                paginaPromocion++;
            if (currenPagePromocion > paginaPromocion)
                currenPagePromocion = 0;
            tslblConteo.Text = currenPagePromocion + " / " + paginaPromocion;
        }

        /// <summary>
        /// Consultar promocion tipo categoria periodo
        /// </summary>
        /// <param name="idTipo">id tipo promocion(categoria) a consultar </param>
        /// <param name="fecha1">fecha inicio a consultar</param>
        /// <param name="fecha2">fecha fin a consultar</param>
        private void ConsultarPromocionCategoriaPeriodo(int idTipo, DateTime fecha1, DateTime fecha2)
        {
            idTipoConsulta = (int)cbxTipo.SelectedValue;
            fechaInicio = dtpfechaIni.Value;
            fechaFin = dtpFechaFi.Value;
            RowPromocion = 0;
            currenPagePromocion = 1;
            interacion = 6;
            try
            {
                dgvResultado.DataSource = miPromocion.ConsultarPromocionCategoriaPeriodo(idTipo, fecha1, fecha2, RowPromocion, rowMaxPromocion);
                totalRowPromocion = miPromocion.RowListarPromocionCategoria(idTipoConsulta, fechaInicio, fechaFin);

            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
            paginaPromocion = totalRowPromocion / rowMaxPromocion;
            if (totalRowPromocion % rowMaxPromocion != 0)
                paginaPromocion++;
            if (currenPagePromocion > paginaPromocion)
                currenPagePromocion = 0;
            tslblConteo.Text = currenPagePromocion + " / " + paginaPromocion;
        }

        /// <summary>
        /// Consulta promocion producto fechas
        /// </summary>
        /// <param name="idTipo">id tipo promocion(prioducto) a consultar</param>
        /// <param name="codigoInternoProducto">codigo interno producto a consultar</param>
        /// <param name="fecha">fecha a consultar</param>
        private void ConsultarPromocionProductoFechas(int idTipo, string codigoInternoProducto, DateTime fecha)
        {
            interacion = 0;
            try
            {
                dgvResultado.Columns["Cant"].Visible = true;
                dgvResultado.DataSource = miPromocion.ConsultarPromocionProductoFechas(idTipo, codigoInternoProducto, fecha);
                tslblConteo.Text = " 1/1 ";
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
        }

        /// <summary>
        /// Consulta promocion tipo producto fechas
        /// </summary>
        /// <param name="idTipo">id tipo promocion(producto)a consultar</param>
        /// <param name="fecha">fecha a consultar</param>
        private void ConsultarPromocionProductoFechas(int idTipo, DateTime fecha)
        {
            idTipoConsulta = (int)cbxTipo.SelectedValue;
            fechaInicio = dtpfechaIni.Value;
            RowPromocion = 0;
            currenPagePromocion = 1;
            interacion = 7;
            try
            {
                dgvResultado.Columns["Cant"].Visible = true;
                dgvResultado.DataSource = miPromocion.ConsultarPromocionProductoFechas(idTipo, fecha, RowPromocion, rowMaxPromocion);
                totalRowPromocion = miPromocion.RowListarPromocionProducto(idTipoConsulta, fechaInicio);

            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
            paginaPromocion = totalRowPromocion / rowMaxPromocion;
            if (totalRowPromocion % rowMaxPromocion != 0)
                paginaPromocion++;
            if (currenPagePromocion > paginaPromocion)
                currenPagePromocion = 0;
            tslblConteo.Text = currenPagePromocion + " / " + paginaPromocion;
        }

        /// <summary>
        /// Consulta promocion categoria periodo
        /// </summary>
        /// <param name="idTipo">id tipo promocion(producto) a consultar</param>
        /// <param name="codigoInternoProducto">codigo Interno producto a consultar</param>
        /// <param name="fecha1">fecha inicio a consultar</param>
        /// <param name="fecha2">fecha final a consultar</param>
        private void ConsultarPromocionProductoPeriodo(int idTipo, string codigoInternoProducto, DateTime fecha1, DateTime fecha2)
        {
            idTipoConsulta = (int)cbxTipo.SelectedValue;
            fechaInicio = dtpfechaIni.Value;
            fechaFin = dtpFechaFin.Value;
            RowPromocion = 0;
            currenPagePromocion = 1;
            interacion = 8;
            try
            {
                dgvResultado.Columns["Cant"].Visible = true;
                dgvResultado.DataSource = miPromocion.ConsultarPromocionProductoPeriodo(idTipo, codigoInternoProducto, fecha1, fecha2, RowPromocion, rowMaxPromocion);
                totalRowPromocion = miPromocion.RowListarPromocionProductoFechas(idTipoConsulta, codigoInternoProducto, fechaInicio, fechaFin);
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
            paginaPromocion = totalRowPromocion / rowMaxPromocion;
            if (totalRowPromocion % rowMaxPromocion != 0)
                paginaPromocion++;
            if (currenPagePromocion > paginaPromocion)
                currenPagePromocion = 0;
            tslblConteo.Text = currenPagePromocion + " / " + paginaPromocion;
        }

        /// <summary>
        /// Consulta promocion tipo promocion periodo.
        /// </summary>
        /// <param name="idTipo">id tipo promocion (producto) a consultar</param>
        /// <param name="fecha1">fecha inicio a consultar</param>
        /// <param name="fecha2">fecha fin a consultar</param>
        private void ConsultarPromocionProductoPeriodo(int idTipo, DateTime fecha1,DateTime fecha2)
        {
            idTipoConsulta = (int)cbxTipo.SelectedValue;
            fechaInicio = dtpfechaIni.Value;
            fechaFin = dtpFechaFin.Value;
            RowPromocion = 0;
            currenPagePromocion = 1;
            interacion = 9;
            try
            {
                dgvResultado.Columns["Cant"].Visible = true;
                dgvResultado.DataSource = miPromocion.ConsultarPromocionProductoPeriodo(idTipo, fecha1, fecha2, RowPromocion, rowMaxPromocion);
                totalRowPromocion = miPromocion.RowListarPromocionProducto(idTipoConsulta, fechaInicio, fechaFin);
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
            paginaPromocion = totalRowPromocion / rowMaxPromocion;
            if (totalRowPromocion % rowMaxPromocion != 0)
                paginaPromocion++;
            if (currenPagePromocion > paginaPromocion)
                currenPagePromocion = 0;
            tslblConteo.Text = currenPagePromocion + " / " + paginaPromocion;
        }

        /// <summary>
        /// Cambia de fechas para la busqueda.
        /// </summary>       
        private void CambioFecha()
        {
            var tem = dtpfechaIni.Value;
            dtpfechaIni.Value = dtpFechaFi.Value;
            dtpFechaFi.Value = tem;
        }

        /// <summary>
        /// Valida el existe promocion eln la base de datos
        /// </summary>
        /// <returns></returns>
        private bool ExistePromocion()
        {           
                var tipo = (int)cbxTipodePromocion.SelectedValue;
            
            var existe = false;
            try
            {
                if (tipo == 2)
                {
                    existe = miPromocion.ExistePromocionMarca(MiMarca.IdMarca, dtpFechaInicio.Value, dtpFechaFin.Value);

                }
                else
                {
                    if (tipo == 3)
                    {
                        existe = miPromocion.ExistePromocionCategoria(MiCategoria.CodigoCategoria, dtpfechaIni.Value, dtpFechaFi.Value);

                    }
                    else
                    {
                        existe = miPromocion.ExistePromocionProducto(MiProducto.CodigoInternoProducto, dtpfechaIni.Value, dtpFechaFi.Value);
                    }
                }
                return existe;
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
                return existe;
            }
        }

        /// <summary>
        /// Obtiene un atabla especifica para varias registros.
        /// </summary>
        /// <returns></returns>
        private DataTable CrearTablePromocion()
        {
            var general = new DataTable();
            general.Columns.Add(new DataColumn("Id", typeof(int)));
            general.Columns.Add(new DataColumn("IdTipo", typeof(int)));
            general.Columns.Add(new DataColumn("Tipo", typeof(string)));
            general.Columns.Add(new DataColumn("Codigo", typeof(string)));
            general.Columns.Add(new DataColumn("Nombre", typeof(string)));
            general.Columns.Add(new DataColumn("FechaInicio", typeof(DateTime)));
            general.Columns.Add(new DataColumn("FechaFin", typeof(DateTime)));
            general.Columns.Add(new DataColumn("IdDescuento", typeof(int)));
            general.Columns.Add(new DataColumn("Descuento", typeof(int)));
            general.Columns.Add(new DataColumn("Cantidad", typeof(string)));
            return general;
        }

       
    }
}
    

